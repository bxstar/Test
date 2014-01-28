using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DianChe.Model;

namespace DianChe
{
    public partial class FrmEditItem : Form
    {
        /// <summary>
        /// 主窗口类
        /// </summary>
        public FrmItemMag frmItemMag = null;


        /// <summary>
        /// 当前选中的宝贝
        /// </summary>
        public EntityItemTask currentItem;

        public FrmEditItem()
        {
            InitializeComponent();
        }

        private void FrmEditItem_Load(object sender, EventArgs e)
        {
            txtInputUrl.Text = "http://item.taobao.com/item.htm?id=" + currentItem.item_id;
            txtItemTitle.Text = currentItem.item_title;
            txtNickName.Text = currentItem.nick;
            txtPrice.Text = currentItem.price.ToString();
            txtKeyword.Text = currentItem.keyword;
            txtRemark.Text = currentItem.remark;
            picItem.Image = currentItem.img_display;
            txtCreativeOne.Text = currentItem.creative_one_title;
            txtCreativeTwo.Text = currentItem.creative_two_title;
            numMaxClick.Value = currentItem.max_click;
            numRunDays.Value = currentItem.run_days;
            if (!string.IsNullOrEmpty(currentItem.effect_start_time) && !string.IsNullOrEmpty(currentItem.effect_end_time))
            {
                cbkEffectTime.Checked = true;
                dtStartTime.Text = currentItem.effect_start_time.Insert(2, ":");
                dtEndTime.Text = currentItem.effect_end_time.Insert(2, ":");
            }
            else
            {
                cbkEffectTime.Checked = false;
            }

            if (currentItem.is_enable)
            {
                btnStart.Enabled = false;
            }
            else
            {
                btnStop.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            currentItem.remark = txtRemark.Text.Trim();
            currentItem.item_title = txtItemTitle.Text.Trim();
            currentItem.price = Convert.ToDecimal(txtPrice.Text);
            currentItem.creative_one_title = txtCreativeOne.Text.Trim();
            currentItem.creative_two_title = txtCreativeTwo.Text.Trim();
            currentItem.effect_start_time = dtStartTime.Value.ToString("HHmm");
            currentItem.effect_end_time = dtEndTime.Value.ToString("HHmm");
            try
            {
                string result = FrmMain.ws.EditMyItem(ModelUtil.ConvertLocalToWs(currentItem));
                if (result.Length == 0)
                {
                    frmItemMag.RefreshDgv();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(result);
                }
            }
            catch (Exception se)
            {
                MessageBox.Show("添加宝贝失败，请联系管理员！\r\n" + se.Message);
                return;
            }
        }

        private void cbkEffectTime_CheckedChanged(object sender, EventArgs e)
        {
            lblEndTime.Enabled = lblStartTime.Enabled = dtEndTime.Enabled = dtStartTime.Enabled = cbkEffectTime.Checked;
        }
    }
}
