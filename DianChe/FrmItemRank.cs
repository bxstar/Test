using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using DianChe.Model;
using Microsoft.VisualStudio.OLE.Interop;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Linq;
using System.IO;
using Common;

namespace DianChe
{
    //[ComVisible(true)]        //去掉注释后，会出现安全警告，是否只查看安全传送的网页内容
    public partial class FrmItemRank : DockContent
    {
        BLL.BllItemRank bllItemRank = new BLL.BllItemRank();

        /// <summary>
        /// 宝贝的匹配正则
        /// </summary>
        Regex pattern_Treasure = new Regex(@"<div.*nid=""(\d+)"".*?>[\w\W]*?</div>", RegexOptions.IgnoreCase);
        /// <summary>
        /// 访问淘宝搜索的网址,xt参数用来防止使用缓存
        /// </summary>
        public string TaoBaoSearchUrlTpl = "http://s.taobao.com/search?q={0}&xt={1}";
        /// <summary>
        /// 宝贝当前页
        /// </summary>
        int currPageIndex = 1;
        /// <summary>
        /// 当前抓取排名的关键词
        /// </summary>
        string currMonitorKeyword = string.Empty;
        /// <summary>
        /// 需要抓取排名的宝贝
        /// </summary>
        List<EntityItemRank> lstMyItem;
        /// <summary>
        /// 自然排名默认查20页
        /// </summary>
        int totalPages = 20;
        /// <summary>
        /// 自然排名抓取关键词的宝贝数，从第一页开始算，1开始
        /// </summary>
        int totalGoodsCount = 0;
        /// <summary>
        /// 是否完成了关键词的自然排名搜索
        /// </summary>
        Boolean IsCompleteKeyWordSearch_Nature = false;
        /// <summary>
        /// 是否完成了关键词的直通车排名搜索
        /// </summary>
        Boolean IsCompleteKeyWordSearch_Ztc = false;
        /// <summary>
        /// 宝贝监控的间隔时间，单位（分钟）
        /// </summary>
        int itemMonitorInterval = 20;
        /// <summary>
        /// //查询排名的后台线程
        /// </summary>
        BackgroundWorker workerGetRank = null;

        /// <summary>
        /// 是否修改了需要监控的宝贝
        /// </summary>
        public Boolean isModifyItem
        {
            get;
            set;
        }

        /// <summary>
        /// 表格中当前选中的宝贝
        /// </summary>
        public EntityItemRank currSelectedItem
        {
            get;
            set;
        }

        public FrmItemRank()
        {
            InitializeComponent();
        }

        private void FrmItemRank_Load(object sender, EventArgs e)
        {
            dgvMyItem.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvMyItem.RowTemplate.Height = 90;
            dgvMyItem.AutoGenerateColumns = false;

            isModifyItem = false;
            LoadData();

            if (dgvMyItem.Rows.Count > 0)
            {
                currSelectedItem = dgvMyItem.Rows[0].DataBoundItem as EntityItemRank;
            }

            webBrowser1.ScriptErrorsSuppressed = true;
            //webBrowser1.Url = new Uri("http://www.baidu.com");
            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);

            //启动后台查各种排名的线程
            if (workerGetRank == null || (workerGetRank != null && !workerGetRank.IsBusy))
            {
                GetRankBackground();
            }

        }

        /// <summary>
        /// 表格从数据源中加载数据显示
        /// </summary>
        public void LoadData()
        {
            if (lstMyItem == null)
            {
                lstMyItem = bllItemRank.GetItem();
                lstMyItem.ForEach(o =>
                {//设置为最小时间，表示没有查询过排名
                    o.update_time = DateTime.MinValue;
                });
            }
            else
            {
                if (isModifyItem)
                {//宝贝有改动，比如加入了新宝贝监控
                    var newMyItem = bllItemRank.GetItem();
                    foreach (var item in newMyItem)
                    {//把新加入监控的宝贝，加入列表
                        if (lstMyItem.Find(o => o.local_item_rank_id == item.local_item_rank_id) == null)
                        {
                            item.update_time = DateTime.MinValue;
                            lstMyItem.Add(item);
                        }
                    }
                    isModifyItem = false;
                }
            }
            dgvMyItem.DataSource = null;
            if (lstMyItem != null && lstMyItem.Where(o => !o.is_delete_by_user).Count() > 0)
                dgvMyItem.DataSource = new SortableBindingList<EntityItemRank>(lstMyItem.Where(o => !o.is_delete_by_user).ToList());
        }

        /// <summary>
        /// 后台取排名
        /// </summary>
        void GetRankBackground()
        {
            workerGetRank = new BackgroundWorker();
            workerGetRank.DoWork += new DoWorkEventHandler(GetItemRank);
            workerGetRank.RunWorkerCompleted += new RunWorkerCompletedEventHandler(GetItemRank_Completed);
            workerGetRank.RunWorkerAsync();
        }

        /// <summary>
        /// 获取宝贝自然排名
        /// </summary>
        private void GetItemRank(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(5000);
            List<string> lstKeyword = lstMyItem.Where(o => !o.is_delete_by_user && o.is_enable ).Select(o => o.keyword).Distinct().ToList();
            foreach (string keyword in lstKeyword)
            {
                if (lstMyItem.Where(o => !o.is_delete_by_user && o.is_enable && o.keyword == keyword && o.update_time.AddMinutes(itemMonitorInterval) < DateTime.Now).Count() > 0)
                {//只要有宝贝的最后更新超过间隔时间，需要重新获取排名
                    lstMyItem.Where(o => o.keyword == keyword).ToList().ForEach(o =>
                    {
                        o.current_nature_rank = 0;
                        o.current_ztc_rank = 0;
                    });
                    //有需要监控直通车排名
                    if (lstMyItem.Where(o => !o.is_delete_by_user && o.is_enable && o.keyword == keyword && o.lowest_ztc_rank != 0).Count() > 0)
                        GetZtcRank(keyword);
                    else
                        IsCompleteKeyWordSearch_Ztc = true;
                    //有需要监控自然排名
                    if (lstMyItem.Where(o => !o.is_delete_by_user && o.is_enable && o.keyword == keyword && o.lowest_nature_rank != 0).Count() > 0)
                        GetNatureRank(keyword);
                    else
                        IsCompleteKeyWordSearch_Nature = true;
                }
                else
                {
                    IsCompleteKeyWordSearch_Nature = true;
                    IsCompleteKeyWordSearch_Ztc = true;
                }

                while (!IsCompleteKeyWordSearch_Nature || !IsCompleteKeyWordSearch_Ztc)
                {//由于WebBrowser的Completed异步，导致必须等待前面的词查完，后面才能继续
                    Thread.Sleep(10000);
                }
                //每查一个关键词间隔一段时间
                Thread.Sleep(60000);
            }

            //将超出范围的排名信息发送
            StringBuilder sbSms = new StringBuilder();      //短信告警的信息
            StringBuilder sbMail = new StringBuilder();     //邮件告警的信息
            foreach (var item in lstMyItem.Where(o => !o.is_delete_by_user && o.is_enable && (o.lowest_nature_rank != 0 || o.lowest_ztc_rank != 0)))
            {
                if (item.lowest_nature_rank != 0 && (item.current_nature_rank < item.highest_nature_rank || item.current_nature_rank > item.lowest_nature_rank))
                {
                    string strMsg = string.Format("宝贝：{0}，ID：{1}，自然排名：{2}", item.item_title, item.item_id, item.current_nature_rank_display);
                    sbSms.AppendFormat(strMsg + " ");
                }
                if (item.lowest_ztc_rank != 0 && (item.current_ztc_rank < item.highest_ztc_rank || item.current_ztc_rank > item.lowest_ztc_rank))
                {
                    string strMsg = string.Format("宝贝：{0}，ID：{1}，直通车排名：{2}", item.item_title, item.item_id, item.current_ztc_rank_display);
                    sbSms.AppendFormat(strMsg + " ");
                }
            }

            //try
            //{
            //    FrmMain.ws.AddMsg(FrmMain.CurrentUser.user_name, FrmMain.CurrentUser.phone, string.Empty, sbSms.ToString(), "短信");
            //}
            //catch (Exception se)
            //{
            //    MessageBox.Show("排名预警验证有误，将无法收到告警信息，" + se.Message);
            //}
        }

        /// <summary>
        /// 根据关键词取自然排名
        /// </summary>
        void GetNatureRank(string keyword)
        {
            IsCompleteKeyWordSearch_Nature = false;
            currPageIndex = 1;
            currMonitorKeyword = keyword;
            totalGoodsCount = 0;
            string url = string.Format(TaoBaoSearchUrlTpl, keyword, DateTime.Now.Ticks);
            webBrowser1.Url = new Uri(url);
        }

        /// <summary>
        /// 根据关键词取直通车排名
        /// </summary>
        void GetZtcRank(string keyword)
        {
            IsCompleteKeyWordSearch_Ztc = false;
            string strHtml = string.Empty;
            string keywordstr = System.Web.HttpUtility.UrlEncode(keyword, System.Text.Encoding.GetEncoding("GBK"));
            string url = "";
            int offset = 0;
            string[] arrItem;
            int currentRank = 0; //当前查找到的排名

            //需要监控关键词自直通车排名的相关宝贝
            List<EntityItemRank> lstItem = lstMyItem.Where(o => !o.is_delete_by_user && o.is_enable && o.keyword == keyword && o.lowest_ztc_rank != 0).ToList();

            for (int a = 0; a < totalPages; a++)
            {
                offset = a * 13;
                url = string.Format(@"http://tmatch.simba.taobao.com/?name=tbuad&catid=&pid=420434_1006,420435_1006&count=5&rct=8&o=j&keyword={0}&offset={1}&ip={2}&frontcatid=&type=0&refpid=&propertyid=&lid=&gprice=&loc=&sort=&q2cused=0&sbid=14&ismall=0&p4p=__p4p_sidebar__,__p4p_bottom__&t=1313651136497", keywordstr, offset, "");
                int tryCount = 3;//每次下载网页失败后重试3次
                for (int b = 0; b < tryCount; b++)
                {
                    try
                    {
                        strHtml = Helper.DownLoadGBKString(url);
                        b = 3;
                    }
                    catch (Exception e2)
                    {
                        Thread.Sleep(1000);
                    }
                }

                arrItem = strHtml.Split('}');
                foreach (string str in arrItem)
                {
                    if (str.Contains("RESOURCEID"))
                    {
                        currentRank++;
                        //一个关键词可能对应几个宝贝，所以此处分几次解析
                        foreach (var item in lstItem)
                        {
                            string strItem = string.Format(@",{0}RESOURCEID{0}:{0}{1}{0},", "\"", item.item_id);
                            if (str.Contains(strItem))
                            {
                                item.current_ztc_rank = currentRank;
                                item.update_time = DateTime.Now;
                                dgvMyItem.Refresh();
                            }
                        }
                    }
                }

                Thread.Sleep(500);
            }

            lstItem.Where(o => o.current_ztc_rank == 0).ToList().ForEach(o =>
            {
                o.current_ztc_rank = -1;
                o.update_time = DateTime.Now;
            });
            this.Invoke(new Action(() => { dgvMyItem.Refresh(); }));
            
            IsCompleteKeyWordSearch_Ztc = true;
        }

        //载入搜索结果
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //有iframe影响，只要主框架的html
            if (!e.Url.AbsoluteUri.StartsWith("http://s.taobao.com/search?"))
            {
                return;
            }

            string strHtml = string.Empty;
            using (StreamReader getReader = new StreamReader(this.webBrowser1.DocumentStream, System.Text.Encoding.GetEncoding("gb2312")))
            {
                strHtml = getReader.ReadToEnd();
            }
            //需要监控关键词自然排名的相关宝贝
            List<EntityItemRank> lstItem = lstMyItem.Where(o => !o.is_delete_by_user && o.is_enable && o.keyword == currMonitorKeyword && o.lowest_nature_rank != 0).ToList();

            MatchCollection matches = null;
            matches = pattern_Treasure.Matches(strHtml);

            if (matches.Count != 0)
            {//正则匹配
                totalGoodsCount += matches.Count;
                foreach (var item in lstItem)
                {
                    for (int i = 0; i < matches.Count; i++)
                    {
                        var m = matches[i];
                        if (item.item_id.ToString() == m.Groups[1].Value)
                        { //找到了该宝贝的排名，排名从1开始
                            item.current_nature_rank = totalGoodsCount - matches.Count + i + 1;
                            item.update_time = DateTime.Now;
                            dgvMyItem.Refresh();
                            break;
                        }
                    }
                    if (item.current_nature_rank == 0 && currPageIndex >= totalPages)
                    {//找不到
                        item.current_nature_rank = -1;
                        item.update_time = DateTime.Now;
                        dgvMyItem.Refresh();
                        IsCompleteKeyWordSearch_Nature = true;
                    }
                }
            }
            else
            {
                lstItem.Where(o => o.current_nature_rank == 0).ToList().ForEach(o =>
                {
                    o.current_nature_rank = -1;
                    o.update_time = DateTime.Now;
                });
                dgvMyItem.Refresh();
                IsCompleteKeyWordSearch_Nature = true;
                return;
            }


            if (currPageIndex >= totalPages)
            {//搜索到最后一页 
                IsCompleteKeyWordSearch_Nature = true;
            }

            if (!IsCompleteKeyWordSearch_Nature && lstItem.Where(o => o.current_nature_rank == 0).Count() > 0)
            {//没到最后一页并且还没找到宝贝的排名，进入下一页继续搜索
                currPageIndex++;
                Boolean isFindNextPageLink = false;     //是否找到了下一页的链接，如果没有找到也算搜索完成
                foreach (HtmlElement he in webBrowser1.Document.GetElementsByTagName("a"))
                {
                    if (he.GetAttribute("classname") == "page-next")
                    {
                        isFindNextPageLink = true;
                        he.InvokeMember("click");
                        break;
                    }
                }
                if (!isFindNextPageLink)
                {
                    IsCompleteKeyWordSearch_Nature = true;
                    lstItem.Where(o => o.current_nature_rank == 0).ToList().ForEach(o =>
                    {
                        o.current_nature_rank = -1;
                        o.update_time = DateTime.Now;
                    });
                    dgvMyItem.Refresh();
                }
                return;
            }

            IsCompleteKeyWordSearch_Nature = true;

        }

        private void 新增宝贝监控ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddItemRank frm = new FrmAddItemRank();
            frm.frmItemRank = this;
            frm.Show();
        }


        /// <summary>
        /// 循环监控
        /// </summary>
        private void GetItemRank_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            GetRankBackground();
        }

        private void 删除宝贝监控ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format("是否要删除宝贝“{0}”的监控",currSelectedItem.item_title), "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                bllItemRank.DeleteItem(currSelectedItem);
                currSelectedItem.is_delete_by_user = true;
                LoadData();
            }
        }

        private void dgvMyItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                EntityItemRank item = dgvMyItem.Rows[e.RowIndex].DataBoundItem as EntityItemRank;
                currSelectedItem = item;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmEditItemRank frm = new FrmEditItemRank();
            frm.frmItemRank = this;
            frm.currentItem = currSelectedItem;
            frm.Show();
        }

        /// <summary>
        /// 刷新宝贝列表
        /// </summary>
        public void RefreshDgv()
        {
            dgvMyItem.Refresh();
        }


    }
}
