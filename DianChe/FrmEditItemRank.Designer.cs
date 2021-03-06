﻿namespace DianChe
{
    partial class FrmEditItemRank
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkMailNotify = new System.Windows.Forms.CheckBox();
            this.chkSmsNotify = new System.Windows.Forms.CheckBox();
            this.chkZtc = new System.Windows.Forms.CheckBox();
            this.numLowestZtcRank = new System.Windows.Forms.NumericUpDown();
            this.chkNature = new System.Windows.Forms.CheckBox();
            this.lblZtc = new System.Windows.Forms.Label();
            this.numLowestNatureRank = new System.Windows.Forms.NumericUpDown();
            this.numHighestZtcRank = new System.Windows.Forms.NumericUpDown();
            this.lblNature = new System.Windows.Forms.Label();
            this.numHighestNatureRank = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNickName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtItemTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.picItem = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.txtInputUrl = new Common.Control.WatermakTextBox();
            this.txtRemark = new Common.Control.WatermakTextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLowestZtcRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLowestNatureRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHighestZtcRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHighestNatureRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picItem)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(537, 410);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtRemark);
            this.groupBox1.Controls.Add(this.chkMailNotify);
            this.groupBox1.Controls.Add(this.chkSmsNotify);
            this.groupBox1.Controls.Add(this.chkZtc);
            this.groupBox1.Controls.Add(this.numLowestZtcRank);
            this.groupBox1.Controls.Add(this.chkNature);
            this.groupBox1.Controls.Add(this.lblZtc);
            this.groupBox1.Controls.Add(this.numLowestNatureRank);
            this.groupBox1.Controls.Add(this.numHighestZtcRank);
            this.groupBox1.Controls.Add(this.lblNature);
            this.groupBox1.Controls.Add(this.numHighestNatureRank);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtKeyword);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtPrice);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtNickName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtItemTitle);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.picItem);
            this.groupBox1.Location = new System.Drawing.Point(13, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(701, 301);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "宝贝详情";
            // 
            // chkMailNotify
            // 
            this.chkMailNotify.AutoSize = true;
            this.chkMailNotify.Location = new System.Drawing.Point(590, 31);
            this.chkMailNotify.Name = "chkMailNotify";
            this.chkMailNotify.Size = new System.Drawing.Size(72, 16);
            this.chkMailNotify.TabIndex = 30;
            this.chkMailNotify.Text = "邮件告警";
            this.chkMailNotify.UseVisualStyleBackColor = true;
            // 
            // chkSmsNotify
            // 
            this.chkSmsNotify.AutoSize = true;
            this.chkSmsNotify.Location = new System.Drawing.Point(471, 31);
            this.chkSmsNotify.Name = "chkSmsNotify";
            this.chkSmsNotify.Size = new System.Drawing.Size(72, 16);
            this.chkSmsNotify.TabIndex = 29;
            this.chkSmsNotify.Text = "短信告警";
            this.chkSmsNotify.UseVisualStyleBackColor = true;
            // 
            // chkZtc
            // 
            this.chkZtc.AutoSize = true;
            this.chkZtc.Location = new System.Drawing.Point(259, 195);
            this.chkZtc.Name = "chkZtc";
            this.chkZtc.Size = new System.Drawing.Size(204, 16);
            this.chkZtc.TabIndex = 27;
            this.chkZtc.Text = "监控直通车排名（超出范围预警）";
            this.chkZtc.UseVisualStyleBackColor = true;
            // 
            // numLowestZtcRank
            // 
            this.numLowestZtcRank.Location = new System.Drawing.Point(599, 192);
            this.numLowestZtcRank.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numLowestZtcRank.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLowestZtcRank.Name = "numLowestZtcRank";
            this.numLowestZtcRank.Size = new System.Drawing.Size(63, 21);
            this.numLowestZtcRank.TabIndex = 26;
            this.numLowestZtcRank.Value = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            // 
            // chkNature
            // 
            this.chkNature.AutoSize = true;
            this.chkNature.Location = new System.Drawing.Point(259, 161);
            this.chkNature.Name = "chkNature";
            this.chkNature.Size = new System.Drawing.Size(192, 16);
            this.chkNature.TabIndex = 27;
            this.chkNature.Text = "监控自然排名（超出范围预警）";
            this.chkNature.UseVisualStyleBackColor = true;
            // 
            // lblZtc
            // 
            this.lblZtc.AutoSize = true;
            this.lblZtc.Location = new System.Drawing.Point(558, 196);
            this.lblZtc.Name = "lblZtc";
            this.lblZtc.Size = new System.Drawing.Size(17, 12);
            this.lblZtc.TabIndex = 25;
            this.lblZtc.Text = "至";
            // 
            // numLowestNatureRank
            // 
            this.numLowestNatureRank.Location = new System.Drawing.Point(599, 160);
            this.numLowestNatureRank.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numLowestNatureRank.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLowestNatureRank.Name = "numLowestNatureRank";
            this.numLowestNatureRank.Size = new System.Drawing.Size(63, 21);
            this.numLowestNatureRank.TabIndex = 26;
            this.numLowestNatureRank.Value = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            // 
            // numHighestZtcRank
            // 
            this.numHighestZtcRank.Location = new System.Drawing.Point(471, 194);
            this.numHighestZtcRank.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numHighestZtcRank.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHighestZtcRank.Name = "numHighestZtcRank";
            this.numHighestZtcRank.Size = new System.Drawing.Size(63, 21);
            this.numHighestZtcRank.TabIndex = 24;
            this.numHighestZtcRank.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblNature
            // 
            this.lblNature.AutoSize = true;
            this.lblNature.Location = new System.Drawing.Point(558, 162);
            this.lblNature.Name = "lblNature";
            this.lblNature.Size = new System.Drawing.Size(17, 12);
            this.lblNature.TabIndex = 25;
            this.lblNature.Text = "至";
            // 
            // numHighestNatureRank
            // 
            this.numHighestNatureRank.Location = new System.Drawing.Point(471, 160);
            this.numHighestNatureRank.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numHighestNatureRank.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHighestNatureRank.Name = "numHighestNatureRank";
            this.numHighestNatureRank.Size = new System.Drawing.Size(63, 21);
            this.numHighestNatureRank.TabIndex = 24;
            this.numHighestNatureRank.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(257, 256);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 22;
            this.label10.Text = "备注：";
            // 
            // txtKeyword
            // 
            this.txtKeyword.Location = new System.Drawing.Point(314, 98);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(350, 21);
            this.txtKeyword.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(312, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "（编辑时仅支持单个关键词）";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(253, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "关键词：";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(524, 62);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(140, 21);
            this.txtPrice.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(469, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "价格：";
            // 
            // txtNickName
            // 
            this.txtNickName.Enabled = false;
            this.txtNickName.Location = new System.Drawing.Point(312, 62);
            this.txtNickName.Name = "txtNickName";
            this.txtNickName.Size = new System.Drawing.Size(140, 21);
            this.txtNickName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(257, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "商家：";
            // 
            // txtItemTitle
            // 
            this.txtItemTitle.Location = new System.Drawing.Point(78, 29);
            this.txtItemTitle.Name = "txtItemTitle";
            this.txtItemTitle.Size = new System.Drawing.Size(374, 21);
            this.txtItemTitle.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "宝贝标题：";
            // 
            // picItem
            // 
            this.picItem.BackColor = System.Drawing.Color.Transparent;
            this.picItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picItem.Location = new System.Drawing.Point(6, 62);
            this.picItem.Name = "picItem";
            this.picItem.Size = new System.Drawing.Size(229, 233);
            this.picItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picItem.TabIndex = 7;
            this.picItem.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "宝贝网址：";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(401, 410);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "确定";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(91, 410);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(91, 23);
            this.btnStart.TabIndex = 18;
            this.btnStart.Text = "启用排名监控";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(244, 410);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(86, 23);
            this.btnStop.TabIndex = 18;
            this.btnStop.Text = "暂停排名监控";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // txtInputUrl
            // 
            this.txtInputUrl.EmptyTextTip = "输入宝贝网址，再点击获取，相关属性会自动填充，宝贝网址可以从浏览器中复制";
            this.txtInputUrl.EmptyTextTipColor = System.Drawing.Color.Silver;
            this.txtInputUrl.Enabled = false;
            this.txtInputUrl.Location = new System.Drawing.Point(91, 31);
            this.txtInputUrl.Name = "txtInputUrl";
            this.txtInputUrl.Size = new System.Drawing.Size(497, 21);
            this.txtInputUrl.TabIndex = 19;
            // 
            // txtRemark
            // 
            this.txtRemark.EmptyTextTip = "记录备注信息，例如宝贝上下架时间等";
            this.txtRemark.EmptyTextTipColor = System.Drawing.Color.Silver;
            this.txtRemark.Location = new System.Drawing.Point(314, 239);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(350, 56);
            this.txtRemark.TabIndex = 31;
            // 
            // FrmEditItemRank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 462);
            this.Controls.Add(this.txtInputUrl);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Name = "FrmEditItemRank";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "编辑宝贝监控";
            this.Load += new System.EventHandler(this.FrmEditItemRank_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLowestZtcRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLowestNatureRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHighestZtcRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHighestNatureRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkZtc;
        private System.Windows.Forms.NumericUpDown numLowestZtcRank;
        private System.Windows.Forms.CheckBox chkNature;
        private System.Windows.Forms.Label lblZtc;
        private System.Windows.Forms.NumericUpDown numLowestNatureRank;
        private System.Windows.Forms.NumericUpDown numHighestZtcRank;
        private System.Windows.Forms.Label lblNature;
        private System.Windows.Forms.NumericUpDown numHighestNatureRank;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNickName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtItemTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.CheckBox chkMailNotify;
        private System.Windows.Forms.CheckBox chkSmsNotify;
        private Common.Control.WatermakTextBox txtInputUrl;
        private Common.Control.WatermakTextBox txtRemark;
    }
}