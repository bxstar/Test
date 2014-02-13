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
        /// <summary>
        /// 访问网址
        /// </summary>
        public string url = null;



        public FrmWeb()
        {
            InitializeComponent();
        }

        private void FrmWeb_Load(object sender, EventArgs e)
        {
            
        }

        public void Navigate()
        {
            webBrowser1.Navigate(url);
        }
    }
}
