﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DianChe.Model;
using System.Linq;
using Common;
using WeifenLuo.WinFormsUI.Docking;

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

        /// <summary>
        /// 开始点击时间
        /// </summary>
        private DateTime dtStartClick;

        private BLL.BllItemClick bllItemClick = new BLL.BllItemClick();

        //public FrmWeb frmWeb = null;
        public FrmItemMag frmItemMag = null;
        public FrmItemRank frmItemRank = null;
        public FrmLeftMenu frmLeftMenu = null;

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
            frmItemMag = new FrmItemMag();
            frmItemRank = new FrmItemRank();
            //frmWeb = new FrmWeb();
            frmLeftMenu = new FrmLeftMenu();

            string uiFile = System.Windows.Forms.Application.StartupPath + "\\Configs\\CustomUI.xml";
            if (System.IO.File.Exists(uiFile))
            {
                DeserializeDockContent ddContent = new DeserializeDockContent(GetContentFromPersistString);
                dockPanel1.LoadFromXml(uiFile, ddContent);
            }
            else
            {
                frmItemMag.Show(dockPanel1);
                frmItemRank.Show(dockPanel1);
                frmLeftMenu.Show(dockPanel1);
                frmLeftMenu.DockTo(dockPanel1, DockStyle.Left);
                //frmWeb.Show(dockPanel1);
            }

            SaveAlive();
            if (CurrentUser != null)
                this.Text = string.Format("欢迎{0}使用{1}", "（" + CurrentUser.user_name + "）", this.Text);
        }

        /// <summary>
        /// 配置委托函数
        /// </summary>
        private IDockContent GetContentFromPersistString(string persistString)
        {
            if (persistString == typeof(FrmItemMag).ToString())
            {
                return new FrmItemMag();
            }
            else if (persistString == typeof(FrmItemRank).ToString())
            {
                return new FrmItemRank();
            }
            else if (persistString == typeof(FrmLeftMenu).ToString())
            {
                return new FrmLeftMenu();
            }
            else if (persistString == typeof(FrmWeb).ToString())
            {
                return new FrmWeb();
            }
            else
            {
                return null;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SaveAlive();

            Boolean isCanDo = false;

            if (CurrentItemClick == null)
            {
                isCanDo = true;
            }
            else
            {
                EntityItemClick ec = bllItemClick.GetItemClickById(CurrentItemClick.local_id);
                if (ec.is_succeed.HasValue || dtStartClick.AddMinutes(3) < DateTime.Now)
                {//任务完成或超过3分钟还没有完成，则可以开始下一个任务
                    isCanDo = true;
                    CurrentItemClick = null;
                }
            }

            if (isCanDo)
            {
                List<EntityItemClick> lstItemClick = bllItemClick.GetItemClick().Where(o => o.create_time.DayOfYear == DateTime.Now.DayOfYear && o.is_succeed == null).ToList();
                if (lstItemClick.Count > 0)
                {
                    Random r = new Random();        //随机选择一个宝贝点击任务，以防每次都卡在第一个宝贝的点击上
                    CurrentItemClick = lstItemClick[r.Next(lstItemClick.Count)];
                    dtStartClick = DateTime.Now;
                    System.Diagnostics.Process.Start("DianChe.Search.exe", string.Format("{0} {1} {2}", CurrentUser.user_name, CurrentUser.pwd, CurrentItemClick.local_id.ToString()));
                }
            }
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            dockPanel1.SaveAsXml(System.Windows.Forms.Application.StartupPath + "\\Configs\\CustomUI.xml");
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

        /// <summary>
        /// 清理内存，保留最大100M
        /// </summary>
        public static void SetWorkingSet()
        {
            try
            {
                Helper.SetWorkingSet(100000000);
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
            catch
            { }
        }
    }
}
