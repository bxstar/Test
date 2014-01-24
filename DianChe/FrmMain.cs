using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DianChe.Model;
using System.Linq;

namespace DianChe
{
    public partial class FrmMain : Form
    {
        /// <summary>
        /// web代理类，除登录页面静态全局使用
        /// </summary>
        public static DianCheWebService.ItemClickService ws ;
        public static DianCheWebService.EntityUser CurrentUser = null;

        /// <summary>
        /// 正在执行点击的宝贝
        /// </summary>
        private EntityItemClick CurrentItemClick = null;

        private BLL.BllItemClick bllItemClick = new BLL.BllItemClick();

        public FrmWeb frmWeb = null;

        public FrmMain()
        {
            InitializeComponent();
            InitWebServiceProxy();
        }

        /// <summary>
        /// 初始化WebSerivce代理类，完成身份认证
        /// </summary>
        public void InitWebServiceProxy()
        {
            ws = new DianCheWebService.ItemClickService();
            if (CurrentUser != null)
            {
                DianCheWebService.MySoapHeader header = new DianCheWebService.MySoapHeader();
                header.UserName = CurrentUser.user_name;
                header.PassWord = CurrentUser.pwd;
                ws.MySoapHeaderValue = header;
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //SaveAlive();
            if (CurrentUser != null)
                this.Text = string.Format("欢迎{0}使用{1}", "（" + CurrentUser.user_name + "）", this.Text);

            FrmItemMag frmItemMag = new FrmItemMag();
            FrmItemRank frmItemRank = new FrmItemRank();
            frmWeb = new FrmWeb();

            frmItemMag.Show(dockPanel1);
            frmWeb.Show(dockPanel1);
            frmItemRank.Show(dockPanel1);
        }

        private void FindItemByWeb()
        {
            frmWeb.Navigate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //SaveAlive();
            
            //Boolean isCanDo = false;

            //if (CurrentItemClick == null)
            //{
            //    isCanDo = true;
            //}
            //else
            //{
            //    EntityItemClick ec = bllItemClick.GetItemClickById(CurrentItemClick.local_id);
            //    if (ec.is_succeed.HasValue)
            //    {//任务完成，可以开始下一个任务
            //        isCanDo = true;
            //        CurrentItemClick = null;
            //    }
            //}

            //if (isCanDo)
            //{
            //    List<EntityItemClick> lstItemClick = bllItemClick.GetItemClick().Where(o => o.create_time.DayOfYear == DateTime.Now.DayOfYear && o.is_succeed == null).ToList();
            //    if (lstItemClick.Count > 0)
            //    {
            //        CurrentItemClick = lstItemClick[0];
            //        frmWeb.FindItem = CurrentItemClick;
            //        System.Threading.Thread t1 = new System.Threading.Thread(FindItemByWeb);
            //        t1.Start();
            //    }
            //}
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// 向服务器发送表示客户端在使用中
        /// </summary>
        private void SaveAlive()
        {
            try
            {
                string mac_address = Common.Helper.GetMacAddress();
                ws.SaveAlive(mac_address);
            }
            catch (Exception se)
            {
                MessageBox.Show("请检查网络，" + se.Message);
            }
        }


    }
}
