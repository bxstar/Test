﻿namespace DianChe
{
    partial class FrmAddItem
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
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGetItem = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.numRunDays = new System.Windows.Forms.NumericUpDown();
            this.numMaxClick = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNickName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtItemTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.picItem = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtInputUrl = new Common.Control.WatermakTextBox();
            this.txtCreativeOne = new Common.Control.WatermakTextBox();
            this.txtCreativeTwo = new Common.Control.WatermakTextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRunDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxClick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picItem)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(174, 403);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "确定";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "宝贝网址：";
            // 
            // btnGetItem
            // 
            this.btnGetItem.Location = new System.Drawing.Point(732, 24);
            this.btnGetItem.Name = "btnGetItem";
            this.btnGetItem.Size = new System.Drawing.Size(75, 23);
            this.btnGetItem.TabIndex = 3;
            this.btnGetItem.Text = "获取";
            this.btnGetItem.UseVisualStyleBackColor = true;
            this.btnGetItem.Click += new System.EventHandler(this.btnGetItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCreativeTwo);
            this.groupBox1.Controls.Add(this.txtCreativeOne);
            this.groupBox1.Controls.Add(this.txtRemark);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.numRunDays);
            this.groupBox1.Controls.Add(this.numMaxClick);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtKeyword);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtPrice);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtNickName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtItemTitle);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.picItem);
            this.groupBox1.Location = new System.Drawing.Point(14, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(793, 301);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "宝贝详情";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(312, 242);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(352, 53);
            this.txtRemark.TabIndex = 8;
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
            // numRunDays
            // 
            this.numRunDays.Location = new System.Drawing.Point(588, 205);
            this.numRunDays.Name = "numRunDays";
            this.numRunDays.Size = new System.Drawing.Size(76, 21);
            this.numRunDays.TabIndex = 7;
            this.numRunDays.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numMaxClick
            // 
            this.numMaxClick.Location = new System.Drawing.Point(362, 205);
            this.numMaxClick.Name = "numMaxClick";
            this.numMaxClick.Size = new System.Drawing.Size(80, 21);
            this.numMaxClick.TabIndex = 6;
            this.numMaxClick.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(493, 209);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 12);
            this.label9.TabIndex = 18;
            this.label9.Text = "点击持续天数：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(255, 209);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "每天最大点击数：";
            // 
            // txtKeyword
            // 
            this.txtKeyword.Location = new System.Drawing.Point(312, 169);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(352, 21);
            this.txtKeyword.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(253, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "关键词：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(253, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "创意二：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(253, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "创意一：";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(524, 64);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(140, 21);
            this.txtPrice.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(472, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "价格：";
            // 
            // txtNickName
            // 
            this.txtNickName.Location = new System.Drawing.Point(312, 64);
            this.txtNickName.Name = "txtNickName";
            this.txtNickName.Size = new System.Drawing.Size(140, 21);
            this.txtNickName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(265, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "商家：";
            // 
            // txtItemTitle
            // 
            this.txtItemTitle.Location = new System.Drawing.Point(77, 23);
            this.txtItemTitle.Name = "txtItemTitle";
            this.txtItemTitle.Size = new System.Drawing.Size(375, 21);
            this.txtItemTitle.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 26);
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
            this.picItem.Location = new System.Drawing.Point(6, 50);
            this.picItem.Name = "picItem";
            this.picItem.Size = new System.Drawing.Size(229, 245);
            this.picItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picItem.TabIndex = 7;
            this.picItem.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(391, 403);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtInputUrl
            // 
            this.txtInputUrl.EmptyTextTip = "输入宝贝网址，再点击获取，相关属性会自动填充，宝贝网址可以从浏览器中复制";
            this.txtInputUrl.EmptyTextTipColor = System.Drawing.Color.Silver;
            this.txtInputUrl.Location = new System.Drawing.Point(91, 24);
            this.txtInputUrl.Name = "txtInputUrl";
            this.txtInputUrl.Size = new System.Drawing.Size(587, 21);
            this.txtInputUrl.TabIndex = 13;
            // 
            // txtCreativeOne
            // 
            this.txtCreativeOne.EmptyTextTip = "系统将根据创意来寻找宝贝，请正确输入";
            this.txtCreativeOne.EmptyTextTipColor = System.Drawing.Color.Silver;
            this.txtCreativeOne.Location = new System.Drawing.Point(312, 101);
            this.txtCreativeOne.Name = "txtCreativeOne";
            this.txtCreativeOne.Size = new System.Drawing.Size(352, 21);
            this.txtCreativeOne.TabIndex = 23;
            // 
            // txtCreativeTwo
            // 
            this.txtCreativeTwo.EmptyTextTip = "当创意一找不到时将使用创意二，没有创意二则不用输入";
            this.txtCreativeTwo.EmptyTextTipColor = System.Drawing.Color.Silver;
            this.txtCreativeTwo.Location = new System.Drawing.Point(312, 135);
            this.txtCreativeTwo.Name = "txtCreativeTwo";
            this.txtCreativeTwo.Size = new System.Drawing.Size(352, 21);
            this.txtCreativeTwo.TabIndex = 23;
            // 
            // FrmAddItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 450);
            this.Controls.Add(this.txtInputUrl);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGetItem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Name = "FrmAddItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新增宝贝点击";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRunDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxClick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGetItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNickName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtItemTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numRunDays;
        private System.Windows.Forms.NumericUpDown numMaxClick;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnClose;
        private Common.Control.WatermakTextBox txtInputUrl;
        private Common.Control.WatermakTextBox txtCreativeOne;
        private Common.Control.WatermakTextBox txtCreativeTwo;
    }
}