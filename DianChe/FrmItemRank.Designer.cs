namespace DianChe
{
    partial class FrmItemRank
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
            this.components = new System.ComponentModel.Container();
            this.宝贝管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新增宝贝监控ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.删除宝贝监控ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvMyItem = new System.Windows.Forms.DataGridView();
            this.colItemTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImg = new System.Windows.Forms.DataGridViewImageColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaxClick = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRunDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreativeOne = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreativeTwo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKeyword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colZtcRank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNatureRank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNotify = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUpdateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEnable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.新增宝贝监控ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑宝贝监控ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除宝贝监控ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.宝贝管理ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.新增宝贝监控ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑宝贝监控ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.删除宝贝监控ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.宝贝管理ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.新增宝贝监控ToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑宝贝监控ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.删除宝贝监控ToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyItem)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // 宝贝管理ToolStripMenuItem
            // 
            this.宝贝管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新增宝贝监控ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.删除宝贝监控ToolStripMenuItem});
            this.宝贝管理ToolStripMenuItem.Name = "宝贝管理ToolStripMenuItem";
            this.宝贝管理ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.宝贝管理ToolStripMenuItem.Text = "宝贝管理";
            // 
            // 新增宝贝监控ToolStripMenuItem
            // 
            this.新增宝贝监控ToolStripMenuItem.Name = "新增宝贝监控ToolStripMenuItem";
            this.新增宝贝监控ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.新增宝贝监控ToolStripMenuItem.Text = "新增宝贝监控";
            this.新增宝贝监控ToolStripMenuItem.Click += new System.EventHandler(this.新增宝贝监控ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem1.Text = "编辑宝贝监控";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // 删除宝贝监控ToolStripMenuItem
            // 
            this.删除宝贝监控ToolStripMenuItem.Name = "删除宝贝监控ToolStripMenuItem";
            this.删除宝贝监控ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.删除宝贝监控ToolStripMenuItem.Text = "删除宝贝监控";
            this.删除宝贝监控ToolStripMenuItem.Click += new System.EventHandler(this.删除宝贝监控ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(781, 46);
            this.panel1.TabIndex = 2;
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
            this.colCreativeOne,
            this.colCreativeTwo,
            this.colKeyword,
            this.colZtcRank,
            this.colNatureRank,
            this.colRemark,
            this.colNotify,
            this.colCreateTime,
            this.colUpdateTime,
            this.colEnable});
            this.dgvMyItem.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvMyItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMyItem.Location = new System.Drawing.Point(0, 71);
            this.dgvMyItem.Name = "dgvMyItem";
            this.dgvMyItem.ReadOnly = true;
            this.dgvMyItem.RowTemplate.Height = 23;
            this.dgvMyItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMyItem.Size = new System.Drawing.Size(781, 332);
            this.dgvMyItem.TabIndex = 13;
            this.dgvMyItem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMyItem_CellClick);
            this.dgvMyItem.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.toolStripMenuItem1_Click);
            // 
            // colItemTitle
            // 
            this.colItemTitle.DataPropertyName = "item_title";
            this.colItemTitle.HeaderText = "标题";
            this.colItemTitle.Name = "colItemTitle";
            this.colItemTitle.ReadOnly = true;
            this.colItemTitle.Width = 300;
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
            this.colMaxClick.Visible = false;
            // 
            // colRunDays
            // 
            this.colRunDays.DataPropertyName = "run_days";
            this.colRunDays.HeaderText = "执行天数";
            this.colRunDays.Name = "colRunDays";
            this.colRunDays.ReadOnly = true;
            this.colRunDays.Visible = false;
            // 
            // colCreativeOne
            // 
            this.colCreativeOne.DataPropertyName = "creative_one_title";
            this.colCreativeOne.HeaderText = "创意一";
            this.colCreativeOne.Name = "colCreativeOne";
            this.colCreativeOne.ReadOnly = true;
            this.colCreativeOne.Visible = false;
            // 
            // colCreativeTwo
            // 
            this.colCreativeTwo.DataPropertyName = "creative_two_title";
            this.colCreativeTwo.HeaderText = "创意二";
            this.colCreativeTwo.Name = "colCreativeTwo";
            this.colCreativeTwo.ReadOnly = true;
            this.colCreativeTwo.Visible = false;
            // 
            // colKeyword
            // 
            this.colKeyword.DataPropertyName = "keyword";
            this.colKeyword.HeaderText = "关键词";
            this.colKeyword.Name = "colKeyword";
            this.colKeyword.ReadOnly = true;
            this.colKeyword.Width = 120;
            // 
            // colZtcRank
            // 
            this.colZtcRank.DataPropertyName = "current_ztc_rank_display";
            this.colZtcRank.HeaderText = "当前直通车排名";
            this.colZtcRank.Name = "colZtcRank";
            this.colZtcRank.ReadOnly = true;
            this.colZtcRank.Width = 130;
            // 
            // colNatureRank
            // 
            this.colNatureRank.DataPropertyName = "current_nature_rank_display";
            this.colNatureRank.HeaderText = "当前自然排名";
            this.colNatureRank.Name = "colNatureRank";
            this.colNatureRank.ReadOnly = true;
            this.colNatureRank.Width = 130;
            // 
            // colRemark
            // 
            this.colRemark.DataPropertyName = "remark";
            this.colRemark.HeaderText = "备注";
            this.colRemark.Name = "colRemark";
            this.colRemark.ReadOnly = true;
            this.colRemark.Width = 120;
            // 
            // colNotify
            // 
            this.colNotify.DataPropertyName = "notify_display";
            this.colNotify.HeaderText = "告警方式";
            this.colNotify.Name = "colNotify";
            this.colNotify.ReadOnly = true;
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
            this.colUpdateTime.HeaderText = "查询时间";
            this.colUpdateTime.Name = "colUpdateTime";
            this.colUpdateTime.ReadOnly = true;
            // 
            // colEnable
            // 
            this.colEnable.DataPropertyName = "is_enable";
            this.colEnable.HeaderText = "状态";
            this.colEnable.Name = "colEnable";
            this.colEnable.ReadOnly = true;
            this.colEnable.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新增宝贝监控ToolStripMenuItem1,
            this.编辑宝贝监控ToolStripMenuItem,
            this.删除宝贝监控ToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(147, 70);
            // 
            // 新增宝贝监控ToolStripMenuItem1
            // 
            this.新增宝贝监控ToolStripMenuItem1.Name = "新增宝贝监控ToolStripMenuItem1";
            this.新增宝贝监控ToolStripMenuItem1.Size = new System.Drawing.Size(146, 22);
            this.新增宝贝监控ToolStripMenuItem1.Text = "新增宝贝监控";
            this.新增宝贝监控ToolStripMenuItem1.Click += new System.EventHandler(this.新增宝贝监控ToolStripMenuItem_Click);
            // 
            // 编辑宝贝监控ToolStripMenuItem
            // 
            this.编辑宝贝监控ToolStripMenuItem.Name = "编辑宝贝监控ToolStripMenuItem";
            this.编辑宝贝监控ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.编辑宝贝监控ToolStripMenuItem.Text = "编辑宝贝监控";
            this.编辑宝贝监控ToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // 删除宝贝监控ToolStripMenuItem1
            // 
            this.删除宝贝监控ToolStripMenuItem1.Name = "删除宝贝监控ToolStripMenuItem1";
            this.删除宝贝监控ToolStripMenuItem1.Size = new System.Drawing.Size(146, 22);
            this.删除宝贝监控ToolStripMenuItem1.Text = "删除宝贝监控";
            this.删除宝贝监控ToolStripMenuItem1.Click += new System.EventHandler(this.删除宝贝监控ToolStripMenuItem_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.webBrowser1.Location = new System.Drawing.Point(0, 234);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(781, 169);
            this.webBrowser1.TabIndex = 14;
            this.webBrowser1.Visible = false;
            // 
            // 宝贝管理ToolStripMenuItem1
            // 
            this.宝贝管理ToolStripMenuItem1.Name = "宝贝管理ToolStripMenuItem1";
            this.宝贝管理ToolStripMenuItem1.Size = new System.Drawing.Size(67, 20);
            this.宝贝管理ToolStripMenuItem1.Text = "宝贝管理";
            // 
            // 新增宝贝监控ToolStripMenuItem2
            // 
            this.新增宝贝监控ToolStripMenuItem2.Name = "新增宝贝监控ToolStripMenuItem2";
            this.新增宝贝监控ToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.新增宝贝监控ToolStripMenuItem2.Text = "新增宝贝监控";
            this.新增宝贝监控ToolStripMenuItem2.Click += new System.EventHandler(this.新增宝贝监控ToolStripMenuItem_Click);
            // 
            // 编辑宝贝监控ToolStripMenuItem1
            // 
            this.编辑宝贝监控ToolStripMenuItem1.Name = "编辑宝贝监控ToolStripMenuItem1";
            this.编辑宝贝监控ToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.编辑宝贝监控ToolStripMenuItem1.Text = "编辑宝贝监控";
            this.编辑宝贝监控ToolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // 删除宝贝监控ToolStripMenuItem2
            // 
            this.删除宝贝监控ToolStripMenuItem2.Name = "删除宝贝监控ToolStripMenuItem2";
            this.删除宝贝监控ToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.删除宝贝监控ToolStripMenuItem2.Text = "删除宝贝监控";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.宝贝管理ToolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(781, 25);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 宝贝管理ToolStripMenuItem2
            // 
            this.宝贝管理ToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新增宝贝监控ToolStripMenuItem3,
            this.编辑宝贝监控ToolStripMenuItem2,
            this.删除宝贝监控ToolStripMenuItem3});
            this.宝贝管理ToolStripMenuItem2.Name = "宝贝管理ToolStripMenuItem2";
            this.宝贝管理ToolStripMenuItem2.Size = new System.Drawing.Size(68, 21);
            this.宝贝管理ToolStripMenuItem2.Text = "宝贝管理";
            // 
            // 新增宝贝监控ToolStripMenuItem3
            // 
            this.新增宝贝监控ToolStripMenuItem3.Name = "新增宝贝监控ToolStripMenuItem3";
            this.新增宝贝监控ToolStripMenuItem3.Size = new System.Drawing.Size(152, 22);
            this.新增宝贝监控ToolStripMenuItem3.Text = "新增宝贝监控";
            this.新增宝贝监控ToolStripMenuItem3.Click += new System.EventHandler(this.新增宝贝监控ToolStripMenuItem_Click);
            // 
            // 编辑宝贝监控ToolStripMenuItem2
            // 
            this.编辑宝贝监控ToolStripMenuItem2.Name = "编辑宝贝监控ToolStripMenuItem2";
            this.编辑宝贝监控ToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.编辑宝贝监控ToolStripMenuItem2.Text = "编辑宝贝监控";
            this.编辑宝贝监控ToolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // 删除宝贝监控ToolStripMenuItem3
            // 
            this.删除宝贝监控ToolStripMenuItem3.Name = "删除宝贝监控ToolStripMenuItem3";
            this.删除宝贝监控ToolStripMenuItem3.Size = new System.Drawing.Size(152, 22);
            this.删除宝贝监控ToolStripMenuItem3.Text = "删除宝贝监控";
            this.删除宝贝监控ToolStripMenuItem3.Click += new System.EventHandler(this.删除宝贝监控ToolStripMenuItem_Click);
            // 
            // FrmItemRank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 403);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.dgvMyItem);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmItemRank";
            this.Text = "宝贝排名监控";
            this.Load += new System.EventHandler(this.FrmItemRank_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyItem)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem 宝贝管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新增宝贝监控ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvMyItem;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ToolStripMenuItem 删除宝贝监控ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 新增宝贝监控ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 编辑宝贝监控ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除宝贝监控ToolStripMenuItem1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemTitle;
        private System.Windows.Forms.DataGridViewImageColumn colImg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaxClick;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRunDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreativeOne;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreativeTwo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKeyword;
        private System.Windows.Forms.DataGridViewTextBoxColumn colZtcRank;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNatureRank;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNotify;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUpdateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEnable;
        private System.Windows.Forms.ToolStripMenuItem 宝贝管理ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 新增宝贝监控ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 编辑宝贝监控ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 删除宝贝监控ToolStripMenuItem2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 宝贝管理ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 新增宝贝监控ToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem 编辑宝贝监控ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 删除宝贝监控ToolStripMenuItem3;
    }
}