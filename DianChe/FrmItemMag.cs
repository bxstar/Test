using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DianChe.BLL;
using DianChe.Model;
using System.Linq;
using WeifenLuo.WinFormsUI.Docking;
using log4net;

namespace DianChe
{
    public partial class FrmItemMag : DockContent
    {

        private static ILog logger = log4net.LogManager.GetLogger("Logger");

        BllItemClick bllItemClick = new BllItemClick();
        BllItemTask bllItemTask = new BllItemTask();

        public FrmItemMag()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitData();
        }

        public void InitData()
        {
            dgvMyItem.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvMyItem.RowTemplate.Height = 90;
            dgvMyItem.AutoGenerateColumns = false;
            List<EntityItemTask> lstMyItem = bllItemTask.GetMyItem();
            dgvMyItem.DataSource = lstMyItem;
        }

        private void 新增宝贝点击ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddItem frm = new FrmAddItem();
            frm.frmItemMag = this;
            frm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //string mac_address = Common.TechNet.GetMacAddress();
            //try
            //{
            //    var lstWsItemClick = FrmMain.ws.DispatchItemClick(mac_address).ToList();
            //    List<EntityItemClick> lstItemClick = ModelUtil.ConvertWsToLocal(lstWsItemClick);

            //    foreach (var itemClick in lstItemClick)
            //    {
            //        bllItemClick.AddItemClick(itemClick);
            //    }
            //}
            //catch (System.Net.WebException se)
            //{
            //    logger.Error("获取点击任务失败", se);
            //}
        }
    }
}
