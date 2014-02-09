using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using log4net;
using System.Threading;
using DianChe.Model;
using Common;

namespace DianChe
{
    public partial class FrmWeb : DockContent
    {
        private BLL.BllItemClick bllItemClick = new BLL.BllItemClick();
        private static ILog logger = log4net.LogManager.GetLogger("Logger");
        public delegate void OneStringParmenters(string str);                   //1个string参数委托
        private delegate void NoParameters();                                   //无参数委托;

        /// <summary>
        /// 寻找的宝贝
        /// </summary>
        public EntityItemClick FindItem
        {
            get;
            set;
        }

        /// <summary>
        /// 寻找到第几页
        /// </summary>
        private int pageIndex
        {
            get;
            set;
        }



        public FrmWeb()
        {
            InitializeComponent();
        }

        private void FrmWeb_Load(object sender, EventArgs e)
        {
            
        }

        public void Navigate()
        {
            pageIndex = 1;
            string url = string.Format("http://s.taobao.com/search?q={0}", FindItem.keyword);
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new NoParameters(Navigate));
            }
            else
            {
                webBrowser1.Navigate(url);
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.AbsoluteUri.StartsWith("http://s.taobao.com"))
            {
                timer1.Enabled = true;
            }
            else if (e.Url.AbsoluteUri.StartsWith("http://detail.tmall.com") || e.Url.AbsoluteUri.StartsWith("http://item.taobao.com"))
            {
                long item_id = Strings.GetItemId(e.Url.AbsoluteUri);
                if (item_id == FindItem.item_id)
                {//找到了宝贝 
                    FindItem.is_succeed = true;
                    bllItemClick.SetItemClickSucceed(FindItem);
                    //TODO 更新线上的成功状态
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GoItem(FindItem);
        }

        private void GoItem(EntityItemClick item)
        {
            int i = 0;
            foreach (HtmlElement he in webBrowser1.Document.GetElementsByTagName("a"))
            {
                if (he.GetAttribute("classname") == "summary")
                {
                    string title = he.GetAttribute("title");
                    //logger.InfoFormat("第{0}页，标题：{1}", pageIndex, title);
                    if (title == item.creative_one_title || title == item.creative_two_title)
                    {
                        timer1.Enabled = false;
                        webBrowser1.Navigate(he.GetAttribute("href"));
                        return;
                    }
                    i++;
                }
            }
            if (i != 0)
            {
                timer1.Enabled = false;
                //最多第10页
                if (pageIndex <= 10)
                {
                    pageIndex++;

                    Thread.Sleep(2000);
                    GoNextPage();
                }
                //MessageBox.Show(i.ToString());
            }
        }

        private void GoNextPage()
        {
            foreach (HtmlElement he in webBrowser1.Document.GetElementsByTagName("a"))
            {
                if (he.GetAttribute("classname") == "page-next")
                {
                    he.InvokeMember("click");
                }
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (HtmlElement he in webBrowser1.Document.GetElementsByTagName("a"))
            {
                if (he.GetAttribute("classname") == "summary")
                {
                    logger.Info(he.GetAttribute("title"));
                    i++;
                }
            }
            MessageBox.Show(i.ToString());
        }
    }
}
