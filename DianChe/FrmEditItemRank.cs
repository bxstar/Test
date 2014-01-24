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
    public partial class FrmEditItemRank : Form
    {
        /// <summary>
        /// 当前宝贝
        /// </summary>
        public EntityItemRank currentItem = null;

        BLL.BllItemRank bllItemRank = new BLL.BllItemRank();

        /// <summary>
        /// 主窗口类
        /// </summary>
        public FrmItemRank frmItemRank = null;

        public FrmEditItemRank()
        {
            InitializeComponent();
        }

        private void FrmEditItemRank_Load(object sender, EventArgs e)
        {
            txtInputUrl.Text = "http://item.taobao.com/item.htm?id=" + currentItem.item_id;
            txtItemTitle.Text = currentItem.item_title;
            txtNickName.Text = currentItem.nick;
            txtPrice.Text = currentItem.price.ToString();
            txtKeyword.Text = currentItem.keyword;
            txtRemark.Text = currentItem.remark;
            picItem.Image = currentItem.img_display;

            if (currentItem.highest_nature_rank == 0)
            {
                chkNature.Checked = false;
                numHighestNatureRank.Enabled = numLowestNatureRank.Enabled = lblNature.Enabled = false;
            }
            else
            {
                chkNature.Checked = true;
                numHighestNatureRank.Enabled = numLowestNatureRank.Enabled = lblNature.Enabled = true;
                numHighestNatureRank.Value = currentItem.highest_nature_rank;
                numLowestNatureRank.Value = currentItem.lowest_nature_rank;
            }

            if (currentItem.highest_ztc_rank == 0)
            {
                chkZtc.Checked = false;
                numHighestZtcRank.Enabled = numLowestZtcRank.Enabled = lblZtc.Enabled = false;
            }
            else
            {
                chkZtc.Checked = true;
                numHighestZtcRank.Enabled = numLowestZtcRank.Enabled = lblZtc.Enabled = true;
                numHighestZtcRank.Value = currentItem.highest_ztc_rank;
                numLowestZtcRank.Value = currentItem.lowest_ztc_rank;
            }

            chkNature.CheckedChanged+=new EventHandler(chkNature_CheckedChanged);
            chkZtc.CheckedChanged+=new EventHandler(chkZtc_CheckedChanged);
            chkSmsNotify.Checked = currentItem.is_sms_notify;
            chkMailNotify.Checked = currentItem.is_mail_notify;

            if (currentItem.is_enable)
            {
                btnStart.Enabled = false;
            }
            else
            {
                btnStop.Enabled = false;
            }
        }

        private void chkNature_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNature.Checked)
            {
                numHighestNatureRank.Enabled = numLowestNatureRank.Enabled = lblNature.Enabled = true;
            }
            else
            {
                numHighestNatureRank.Enabled = numLowestNatureRank.Enabled = lblNature.Enabled = false;
            }
        }

        private void chkZtc_CheckedChanged(object sender, EventArgs e)
        {
            if (chkZtc.Checked)
            {
                numHighestZtcRank.Enabled = numLowestZtcRank.Enabled = lblZtc.Enabled = true;
            }
            else
            {
                numHighestZtcRank.Enabled = numLowestZtcRank.Enabled = lblZtc.Enabled = false;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            currentItem.is_enable = true;
            bllItemRank.SetItemEnable(currentItem.is_enable, currentItem.local_item_rank_id.ToString());
            frmItemRank.RefreshDgv();
            this.Close();
            
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            currentItem.is_enable = false;
            bllItemRank.SetItemEnable(currentItem.is_enable, currentItem.local_item_rank_id.ToString());
            frmItemRank.RefreshDgv();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!chkNature.Checked && !chkZtc.Checked)
            {
                MessageBox.Show("自然排名或直通车排名必须选择一项！");
                return;
            }


            if (chkNature.Checked)
            {
                currentItem.highest_nature_rank = Convert.ToInt32(numHighestNatureRank.Value);
                currentItem.lowest_nature_rank = Convert.ToInt32(numLowestNatureRank.Value);
            }
            else
            {
                currentItem.highest_nature_rank = currentItem.lowest_nature_rank = 0;
            }
            if (chkZtc.Checked)
            {
                currentItem.highest_ztc_rank = Convert.ToInt32(numHighestZtcRank.Value);
                currentItem.lowest_ztc_rank = Convert.ToInt32(numLowestZtcRank.Value);
            }
            else
            {
                currentItem.highest_ztc_rank = currentItem.lowest_ztc_rank = 0;
            }
            currentItem.price = Convert.ToDecimal(txtPrice.Text);
            currentItem.keyword = txtKeyword.Text.Trim();
            currentItem.remark = txtRemark.Text.Trim();
            currentItem.update_time = DateTime.Now;
            if (chkSmsNotify.Checked)
            {
                currentItem.is_sms_notify = true;
            }
            else
            {
                currentItem.is_sms_notify = false;
            }
            if (chkMailNotify.Checked)
            {
                currentItem.is_mail_notify = true;
            }
            else
            {
                currentItem.is_mail_notify = false;
            }
            try
            {
                bllItemRank.UpdateItem(currentItem);
                frmItemRank.LoadData();
                this.Close();
            }
            catch (Exception se)
            {
                MessageBox.Show("编辑宝贝监控失败，" + se.Message);
                return;
            }
        }




    }
}
