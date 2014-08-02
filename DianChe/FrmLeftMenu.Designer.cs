namespace DianChe
{
    partial class FrmLeftMenu
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
            this.gbtnWeb = new Glass.GlassButton();
            this.gbtnUserEdit = new Glass.GlassButton();
            this.SuspendLayout();
            // 
            // gbtnWeb
            // 
            this.gbtnWeb.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbtnWeb.Location = new System.Drawing.Point(14, 41);
            this.gbtnWeb.Name = "gbtnWeb";
            this.gbtnWeb.Size = new System.Drawing.Size(121, 48);
            this.gbtnWeb.TabIndex = 0;
            this.gbtnWeb.Text = "浏览器";
            // 
            // gbtnUserEdit
            // 
            this.gbtnUserEdit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbtnUserEdit.Location = new System.Drawing.Point(14, 118);
            this.gbtnUserEdit.Name = "gbtnUserEdit";
            this.gbtnUserEdit.Size = new System.Drawing.Size(121, 48);
            this.gbtnUserEdit.TabIndex = 0;
            this.gbtnUserEdit.Text = "注册信息维护";
            this.gbtnUserEdit.Click += new System.EventHandler(this.gbtnUserEdit_Click);
            // 
            // FrmLeftMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(147, 565);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.gbtnUserEdit);
            this.Controls.Add(this.gbtnWeb);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FrmLeftMenu";
            this.Text = "菜单窗口";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLeftMenu_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private Glass.GlassButton gbtnWeb;
        private Glass.GlassButton gbtnUserEdit;
    }
}