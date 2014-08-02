using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using log4net;
using System.IO;
using DianChe.Model;

namespace DianChe.Search
{
    public partial class FrmSearch : Form
    {
        //日志类
        ILog logger = LogManager.GetLogger("Logger");

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
        /// 需要查找排名的宝贝ID集合
        /// </summary>
        public string findItemIds = string.Empty;
        /// <summary>
        /// 当前抓取排名的关键词
        /// </summary>
        public string currMonitorKeyword = string.Empty;
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
        /// 需要监控关键词自然排名的相关宝贝
        /// </summary>
        List<EntityItemRank> lstItem = new List<EntityItemRank>();

        public FrmSearch()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //隐藏窗体
            this.ShowInTaskbar = false;
            this.Hide();
            string[] arrItemIds = findItemIds.Split(',');
            foreach (var itemId in arrItemIds)
            {
                EntityItemRank ei = new EntityItemRank() { item_id = Int64.Parse(itemId), keyword = currMonitorKeyword, update_time = DateTime.MinValue };
                lstItem.Add(ei);
            }

            IsCompleteKeyWordSearch_Nature = false;
            currPageIndex = 1;
            totalGoodsCount = 0;
            string url = string.Format(TaoBaoSearchUrlTpl, currMonitorKeyword, DateTime.Now.Ticks);
            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
            webBrowser1.Url = new Uri(url);
        }

        void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
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
                            break;
                        }
                    }
                    if (item.current_nature_rank == 0 && currPageIndex >= totalPages)
                    {//找不到
                        item.current_nature_rank = -1;
                        item.update_time = DateTime.Now;
                        IsCompleteKeyWordSearch_Nature = true;
                    }
                }
            }
            else
            {//不匹配正则，不再查找
                lstItem.Where(o => o.current_nature_rank == 0).ToList().ForEach(o =>
                {
                    o.current_nature_rank = -1;
                    o.update_time = DateTime.Now;
                });
                IsCompleteKeyWordSearch_Nature = true;
            }


            if (currPageIndex >= totalPages)
            {//搜索到最后一页 
                IsCompleteKeyWordSearch_Nature = true;
            }

            if (!IsCompleteKeyWordSearch_Nature )
            {//没到最后一页并且还没找到宝贝的排名，进入下一页继续搜索
                currPageIndex++;
                Boolean isFindNextPageLink = false;     //是否找到了下一页的链接，如果没有找到也算搜索完成
                foreach (HtmlElement he in webBrowser1.Document.GetElementsByTagName("a"))
                {
                    if (he.GetAttribute("classname") == "page-next")
                    {
                        logger.InfoFormat("关键词：{0}，第{1}页", currMonitorKeyword, currPageIndex);
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
                }
            }

            if (IsCompleteKeyWordSearch_Nature)
            {
                bllItemRank.SetItemNatureRank(lstItem);
                this.Close();
            }
            
            
        }
    }
}
