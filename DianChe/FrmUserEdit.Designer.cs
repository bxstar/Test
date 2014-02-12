namespace DianChe
{
    partial class FrmUserEdit
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnSave = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRegEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEditPwd = new System.Windows.Forms.Button();
            this.txtRegPhone = new Common.Control.WatermakTextBox();
            this.txtRegUserName = new Common.Control.WatermakTextBox();
            this.txtRegPwdConfirm = new Common.Control.WatermakTextBox();
            this.txtRegPwd = new Common.Control.WatermakTextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(55, 41);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(447, 320);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtRegPhone);
            this.tabPage1.Controls.Add(this.txtRegUserName);
            this.tabPage1.Controls.Add(this.btnSave);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtRegEmail);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(439, 294);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "注册信息编辑";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnEditPwd);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.txtRegPwdConfirm);
            this.tabPage2.Controls.Add(this.txtRegPwd);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(439, 294);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "修改密码";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(132, 216);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(58, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "手机号：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(58, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 19;
            this.label6.Text = "邮箱地址：";
            // 
            // txtRegEmail
            // 
            this.txtRegEmail.Location = new System.Drawing.Point(132, 149);
            this.txtRegEmail.Name = "txtRegEmail";
            this.txtRegEmail.Size = new System.Drawing.Size(249, 21);
            this.txtRegEmail.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "用户名：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(85, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 23;
            this.label5.Text = "密码确认：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 24;
            this.label3.Text = "新密码：";
            // 
            // btnEditPwd
            // 
            this.btnEditPwd.Location = new System.Drawing.Point(159, 194);
            this.btnEditPwd.Name = "btnEditPwd";
            this.btnEditPwd.Size = new System.Drawing.Size(75, 23);
            this.btnEditPwd.TabIndex = 27;
            this.btnEditPwd.Text = "保存";
            this.btnEditPwd.UseVisualStyleBackColor = true;
            this.btnEditPwd.Click += new System.EventHandler(this.btnEditPwd_Click);
            // 
            // txtRegPhone
            // 
            this.txtRegPhone.EmptyTextTip = "请使用移动手机号，否则系统无法推送消息";
            this.txtRegPhone.EmptyTextTipColor = System.Drawing.Color.Silver;
            this.txtRegPhone.Location = new System.Drawing.Point(132, 93);
            this.txtRegPhone.Name = "txtRegPhone";
            this.txtRegPhone.Size = new System.Drawing.Size(249, 21);
            this.txtRegPhone.TabIndex = 23;
            // 
            // txtRegUserName
            // 
            this.txtRegUserName.EmptyTextTip = "请使用店铺的旺旺名称";
            this.txtRegUserName.EmptyTextTipColor = System.Drawing.Color.Silver;
            this.txtRegUserName.Location = new System.Drawing.Point(132, 36);
            this.txtRegUserName.Name = "txtRegUserName";
            this.txtRegUserName.Size = new System.Drawing.Size(147, 21);
            this.txtRegUserName.TabIndex = 20;
            // 
            // txtRegPwdConfirm
            // 
            this.txtRegPwdConfirm.EmptyTextTip = "同上";
            this.txtRegPwdConfirm.EmptyTextTipColor = System.Drawing.Color.Silver;
            this.txtRegPwdConfirm.Location = new System.Drawing.Point(159, 119);
            this.txtRegPwdConfirm.Name = "txtRegPwdConfirm";
            this.txtRegPwdConfirm.Size = new System.Drawing.Size(183, 21);
            this.txtRegPwdConfirm.TabIndex = 26;
            // 
            // txtRegPwd
            // 
            this.txtRegPwd.EmptyTextTip = "必须6位或6位以上";
            this.txtRegPwd.EmptyTextTipColor = System.Drawing.Color.Silver;
            this.txtRegPwd.Location = new System.Drawing.Point(159, 69);
            this.txtRegPwd.Name = "txtRegPwd";
            this.txtRegPwd.Size = new System.Drawing.Size(166, 21);
            this.txtRegPwd.TabIndex = 25;
            // 
            // FrmUserEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 402);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmUserEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "注册信息维护";
            this.Load += new System.EventHandler(this.FrmUserEdit_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private Common.Control.WatermakTextBox txtRegPhone;
        private Common.Control.WatermakTextBox txtRegUserName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRegEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnEditPwd;
        private Common.Control.WatermakTextBox txtRegPwdConfirm;
        private Common.Control.WatermakTextBox txtRegPwd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
    }
}