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
using Common;

namespace DianChe
{
    public partial class FrmItemMag : DockContent
    {

        /// <summary>
        /// 表格中当前选中的宝贝
        /// </summary>
        public EntityItemTask currSelectedItem
        {
            get;
            set;
        }

        private static ILog logger = log4net.LogManager.GetLogger("Logger");

        BllItemClick bllItemClick = new BllItemClick();
        BllItemTask bllItemTask = new BllItemTask();

        public FrmItemMag()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();

            if (dgvMyItem.Rows.Count > 0)
            {
                currSelectedItem = dgvMyItem.Rows[0].DataBoundItem as EntityItemTask;
            }
        }

        public void LoadData()
        {
            dgvMyItem.DataSource = null;
            dgvMyItem.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvMyItem.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvMyItem.RowTemplate.Height = 90;
            dgvMyItem.AutoGenerateColumns = false;
            List<EntityItemTask> lstMyItem = bllItemTask.GetMyItem();
            if (lstMyItem != null && lstMyItem.Count() > 0)
                dgvMyItem.DataSource = new SortableBindingList<EntityItemTask>(lstMyItem);
        }

        private void 新增宝贝点击ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddItem frm = new FrmAddItem();
            frm.frmItemMag = this;
            frm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string mac_address = Helper.GetMacAddress();
            try
            {
                var lstWsItemClick = FrmMain.ws.DispatchItemClick(mac_address).ToList();
                List<EntityItemClick> lstItemClick = ModelUtil.ConvertWsToLocal(lstWsItemClick);

                foreach (var itemClick in lstItemClick)
                {
                    bllItemClick.AddItemClick(itemClick);
                }
            }
            catch (System.Net.WebException se)
            {
                logger.Error("获取点击任务失败", se);
            }
        }

        private void 编辑宝贝点击ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEditItem frm = new FrmEditItem();
            frm.frmItemMag = this;
            frm.currentItem = currSelectedItem;
            frm.Show();
        }

        private void 删除宝贝点击ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format("是否要删除宝贝“{0}”的点击任务", currSelectedItem.item_title), "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                try
                {
                    string result = FrmMain.ws.DeleteMyItem(currSelectedItem.local_item_task_id.ToString());
                    if (result.Length == 0)
                    {
                        bllItemTask.DeleteMyItem(currSelectedItem.local_item_task_id);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show(result);
                    }
                }
                catch (Exception se)
                {
                    MessageBox.Show("删除宝贝失败，请联系管理员！\r\n" + se.Message);
                    return;
                }
                
            }
        }

        private void dgvMyItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                EntityItemTask item = dgvMyItem.Rows[e.RowIndex].DataBoundItem as EntityItemTask;
                currSelectedItem = item;
            }
        }

        private void dgvMyItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmEditItem frm = new FrmEditItem();
            frm.frmItemMag = this;
            frm.currentItem = currSelectedItem;
            frm.Show();
        }

        public void RefreshDgv()
        {
            dgvMyItem.Refresh();
        }
    }
}
