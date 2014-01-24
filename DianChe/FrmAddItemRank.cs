using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DianChe.Model;
using Common;
using DianChe.BLL;
using log4net;

namespace DianChe
{
    public partial class FrmAddItemRank : Form
    {
        /// <summary>
        /// 当前宝贝
        /// </summary>
        private EntityItemRank currentItem = new EntityItemRank();

        BLL.BllItemRank bllItemRank = new BLL.BllItemRank();

        /// <summary>
        /// 主窗口类
        /// </summary>
        public FrmItemRank frmItemRank = null;

        //日志类
        ILog logAX = LogManager.GetLogger("Logger");

        public FrmAddItemRank()
        {
            InitializeComponent();
        }

        private void btnGetItem_Click(object sender, EventArgs e)
        {
            if (txtInputUrl.Text.ToLower().Contains("&id") || txtInputUrl.Text.ToLower().Contains("?id"))
            {
                long item_id = Strings.GetItemId(txtInputUrl.Text.ToLower());
                string jsonItem = FrmMain.ws.GetItemOnline(item_id);
                if (!string.IsNullOrEmpty(jsonItem) && !jsonItem.Contains("sub_code"))
                {
                    currentItem = ModelUtil.ConvertWsLocal(FrmMain.ws.GetItemRankFromJson(jsonItem));
                    picItem.Image = Helper.GetImgOnLine(currentItem.img_url);
                    txtItemTitle.Text = currentItem.item_title;
                    txtNickName.Text = currentItem.nick;
                    txtPrice.Text = currentItem.price.ToString();

                }
                else
                {
                    MessageBox.Show("获取宝贝信息失败，请过一段时间再试");
                }
            }
            else
            {
                MessageBox.Show("宝贝的网址输入错误，请使用浏览器打开宝贝，然后复制地址栏内容");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!chkNature.Checked && !chkZtc.Checked)
            {
                MessageBox.Show("自然排名或直通车排名必须选择一项！");
                return;
            }

            //获取宝贝图片内容及其他设置
            Image image = picItem.Image;
            System.IO.MemoryStream ImageMem = new System.IO.MemoryStream();
            image.Save(ImageMem, System.Drawing.Imaging.ImageFormat.Bmp);
            currentItem.img_data = ImageMem.GetBuffer();
            if (chkNature.Checked)
            {
                currentItem.highest_nature_rank = Convert.ToInt32(numHighestNatureRank.Value);
                currentItem.lowest_nature_rank = Convert.ToInt32(numLowestNatureRank.Value);
            }
            if (chkZtc.Checked)
            {
                currentItem.highest_ztc_rank = Convert.ToInt32(numHighestZtcRank.Value);
                currentItem.lowest_ztc_rank = Convert.ToInt32(numLowestZtcRank.Value);
            }
            string[] arrKeyword = txtKeyword.Text.Trim().Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            
            currentItem.remark = txtRemark.Text.Trim();
            currentItem.create_time = currentItem.update_time = DateTime.Now;
            if (chkSmsNotify.Checked)
            {
                currentItem.is_sms_notify = true;
            }
            if (chkMailNotify.Checked)
            {
                currentItem.is_mail_notify = true;
            }
            currentItem.is_enable = true;
            try
            {
                foreach (string keyword in arrKeyword)
                {
                    currentItem.local_item_rank_id = Guid.NewGuid();
                    currentItem.keyword = keyword.Trim().TrimEnd('\r');
                    bllItemRank.AddMyItem(currentItem);
                }
                
                frmItemRank.isModifyItem = true;
                frmItemRank.LoadData();
                this.Close();
            }
            catch (Exception se)
            {
                logAX.Error("添加宝贝监控失败！", se);
                MessageBox.Show("添加宝贝监控失败，请联系管理员！");
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAddItemRank_Load(object sender, EventArgs e)
        {
            numHighestNatureRank.Enabled = numLowestNatureRank.Enabled = lblNature.Enabled = false;
            numHighestZtcRank.Enabled = numLowestZtcRank.Enabled = lblZtc.Enabled = false;
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
    }
}
