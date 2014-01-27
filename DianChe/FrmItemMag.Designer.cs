namespace DianChe
{
    partial class FrmItemMag
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.宝贝管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新增宝贝点击ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelButtom = new System.Windows.Forms.Panel();
            this.dgvMyItem = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.colItemTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImg = new System.Windows.Forms.DataGridViewImageColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaxClick = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRunDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastRunDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEffectTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreativeOne = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreativeTwo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKeyword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUpdateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEnable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyItem)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.宝贝管理ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(943, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 宝贝管理ToolStripMenuItem
            // 
            this.宝贝管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新增宝贝点击ToolStripMenuItem});
            this.宝贝管理ToolStripMenuItem.Name = "宝贝管理ToolStripMenuItem";
            this.宝贝管理ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.宝贝管理ToolStripMenuItem.Text = "宝贝管理";
            // 
            // 新增宝贝点击ToolStripMenuItem
            // 
            this.新增宝贝点击ToolStripMenuItem.Name = "新增宝贝点击ToolStripMenuItem";
            this.新增宝贝点击ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.新增宝贝点击ToolStripMenuItem.Text = "新增宝贝点击";
            this.新增宝贝点击ToolStripMenuItem.Click += new System.EventHandler(this.新增宝贝点击ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(943, 46);
            this.panel1.TabIndex = 1;
            // 
            // panelButtom
            // 
            this.panelButtom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelButtom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtom.Location = new System.Drawing.Point(0, 432);
            this.panelButtom.Name = "panelButtom";
            this.panelButtom.Size = new System.Drawing.Size(943, 30);
            this.panelButtom.TabIndex = 11;
            // 
            // dgvMyItem
            // 
            this.dgvMyItem.AllowUserToAddRows = false;
            this.dgvMyItem.AllowUserToDeleteRows = false;
            this.dgvMyItem.AllowUserToOrderColumns = true;
            this.dgvMyItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMyItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colItemTitle,
            this.colImg,
            this.colPrice,
            this.colMaxClick,
            this.colRunDays,
            this.colLastRunDate,
            this.colEffectTime,
            this.colCreativeOne,
            this.colCreativeTwo,
            this.colKeyword,
            this.colRemark,
            this.colCreateTime,
            this.colUpdateTime,
            this.colEnable});
            this.dgvMyItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMyItem.Location = new System.Drawing.Point(0, 71);
            this.dgvMyItem.Name = "dgvMyItem";
            this.dgvMyItem.ReadOnly = true;
            this.dgvMyItem.RowTemplate.Height = 23;
            this.dgvMyItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMyItem.Size = new System.Drawing.Size(943, 361);
            this.dgvMyItem.TabIndex = 12;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // colItemTitle
            // 
            this.colItemTitle.DataPropertyName = "item_title";
            this.colItemTitle.HeaderText = "标题";
            this.colItemTitle.Name = "colItemTitle";
            this.colItemTitle.ReadOnly = true;
            this.colItemTitle.Width = 200;
            // 
            // colImg
            // 
            this.colImg.DataPropertyName = "img_display";
            this.colImg.HeaderText = "宝贝图片";
            this.colImg.Name = "colImg";
            this.colImg.ReadOnly = true;
            this.colImg.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colImg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colPrice
            // 
            this.colPrice.DataPropertyName = "price";
            this.colPrice.HeaderText = "价格";
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            this.colPrice.Width = 60;
            // 
            // colMaxClick
            // 
            this.colMaxClick.DataPropertyName = "max_click";
            this.colMaxClick.HeaderText = "每日点击";
            this.colMaxClick.Name = "colMaxClick";
            this.colMaxClick.ReadOnly = true;
            this.colMaxClick.Width = 60;
            // 
            // colRunDays
            // 
            this.colRunDays.DataPropertyName = "run_days";
            this.colRunDays.HeaderText = "执行天数";
            this.colRunDays.Name = "colRunDays";
            this.colRunDays.ReadOnly = true;
            this.colRunDays.Width = 60;
            // 
            // colLastRunDate
            // 
            this.colLastRunDate.DataPropertyName = "last_run_date";
            this.colLastRunDate.HeaderText = "截止日期";
            this.colLastRunDate.Name = "colLastRunDate";
            this.colLastRunDate.ReadOnly = true;
            this.colLastRunDate.Width = 80;
            // 
            // colEffectTime
            // 
            this.colEffectTime.DataPropertyName = "effect_time_span";
            this.colEffectTime.HeaderText = "有效时间段";
            this.colEffectTime.Name = "colEffectTime";
            this.colEffectTime.ReadOnly = true;
            this.colEffectTime.Width = 80;
            // 
            // colCreativeOne
            // 
            this.colCreativeOne.DataPropertyName = "creative_one_title";
            this.colCreativeOne.HeaderText = "创意一";
            this.colCreativeOne.Name = "colCreativeOne";
            this.colCreativeOne.ReadOnly = true;
            // 
            // colCreativeTwo
            // 
            this.colCreativeTwo.DataPropertyName = "creative_two_title";
            this.colCreativeTwo.HeaderText = "创意二";
            this.colCreativeTwo.Name = "colCreativeTwo";
            this.colCreativeTwo.ReadOnly = true;
            // 
            // colKeyword
            // 
            this.colKeyword.DataPropertyName = "keyword";
            this.colKeyword.HeaderText = "关键词";
            this.colKeyword.Name = "colKeyword";
            this.colKeyword.ReadOnly = true;
            this.colKeyword.Width = 120;
            // 
            // colRemark
            // 
            this.colRemark.DataPropertyName = "remark";
            this.colRemark.HeaderText = "备注";
            this.colRemark.Name = "colRemark";
            this.colRemark.ReadOnly = true;
            this.colRemark.Width = 120;
            // 
            // colCreateTime
            // 
            this.colCreateTime.DataPropertyName = "create_time";
            this.colCreateTime.HeaderText = "添加时间";
            this.colCreateTime.Name = "colCreateTime";
            this.colCreateTime.ReadOnly = true;
            // 
            // colUpdateTime
            // 
            this.colUpdateTime.DataPropertyName = "update_time";
            this.colUpdateTime.HeaderText = "修改时间";
            this.colUpdateTime.Name = "colUpdateTime";
            this.colUpdateTime.ReadOnly = true;
            // 
            // colEnable
            // 
            this.colEnable.DataPropertyName = "is_enable_display";
            this.colEnable.HeaderText = "状态";
            this.colEnable.Name = "colEnable";
            this.colEnable.ReadOnly = true;
            this.colEnable.Width = 60;
            // 
            // FrmItemMag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 462);
            this.Controls.Add(this.dgvMyItem);
            this.Controls.Add(this.panelButtom);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmItemMag";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "云点车";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 宝贝管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新增宝贝点击ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelButtom;
        private System.Windows.Forms.DataGridView dgvMyItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemTitle;
        private System.Windows.Forms.DataGridViewImageColumn colImg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaxClick;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRunDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastRunDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEffectTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreativeOne;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreativeTwo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKeyword;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUpdateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEnable;
    }
}

