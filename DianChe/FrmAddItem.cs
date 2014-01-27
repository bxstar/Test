using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DianChe.BLL;
using DianChe.Model;
using Common;
using log4net;

namespace DianChe
{
    public partial class FrmAddItem : Form
    {
        /// <summary>
        /// 主窗口类
        /// </summary>
        public FrmItemMag frmItemMag = null;

        //日志类
        ILog logAX = LogManager.GetLogger("Logger");
        /// <summary>
        /// 当前宝贝
        /// </summary>
        private EntityItemTask currentItem = new EntityItemTask();

        BllItemTask bllMyItem = new BllItemTask();

        public FrmAddItem()
        {
            InitializeComponent();
        }

        private void FrmAddItem_Load(object sender, EventArgs e)
        {
            lblEndTime.Enabled = lblStartTime.Enabled = dtEndTime.Enabled = dtStartTime.Enabled = false;
        }

        private void btnGetItem_Click(object sender, EventArgs e)
        {
            if (txtInputUrl.Text.ToLower().Contains("&id") || txtInputUrl.Text.ToLower().Contains("?id"))
            {
                long item_id = Strings.GetItemId(txtInputUrl.Text.ToLower());
                string jsonItem = FrmMain.ws.GetItemOnline(item_id);
                if (!string.IsNullOrEmpty(jsonItem) && !jsonItem.Contains("sub_code"))
                {
                    currentItem = ModelUtil.ConvertWsToLocal(FrmMain.ws.GetItemTaskFromJson(jsonItem));
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
            currentItem.local_item_task_id = Guid.NewGuid();
            //获取宝贝图片内容及其他设置
            Image image = picItem.Image;
            System.IO.MemoryStream ImageMem = new System.IO.MemoryStream();
            image.Save(ImageMem, System.Drawing.Imaging.ImageFormat.Bmp);
            currentItem.img_data = ImageMem.GetBuffer();
            currentItem.max_click = Convert.ToInt32(numMaxClick.Value);
            currentItem.run_days = Convert.ToInt32(numRunDays.Value);
            currentItem.creative_one_title = txtCreativeOne.Text.Trim();
            currentItem.creative_two_title = txtCreativeTwo.Text.Trim();
            currentItem.keyword = txtKeyword.Text.Trim();
            if (cbkEffectTime.Checked)
            {
                currentItem.effect_start_time = dtStartTime.Value.ToString("HHss");
                currentItem.effect_end_time = dtEndTime.Value.ToString("HHss");
            }
            currentItem.remark = txtRemark.Text.Trim();
            currentItem.create_time = currentItem.update_time = DateTime.Now;
            currentItem.is_enable = true;
            try
            {
                string result = FrmMain.ws.AddMyItem(ModelUtil.ConvertLocalToWs(currentItem));
                if (result.Length == 0)
                {
                    bllMyItem.AddMyItem(currentItem);
                    frmItemMag.InitData();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(result);
                }
            }
            catch (Exception se)
            {
                logAX.Error("添加宝贝失败！", se);
                MessageBox.Show("添加宝贝失败，请联系管理员！");
                return;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbkEffectTime_CheckedChanged(object sender, EventArgs e)
        {
            lblEndTime.Enabled = lblStartTime.Enabled = dtEndTime.Enabled = dtStartTime.Enabled = cbkEffectTime.Checked;
        }




    }
}
