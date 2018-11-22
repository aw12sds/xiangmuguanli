namespace 项目管理系统.市场部
{
    partial class FrXiangmuguanli1
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip();
            this.查看明细ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.审批ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.驳回ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.状态 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.工作令号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.预计设计开始时间 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.预计设计结束时间 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.合同名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemProgressBar3 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.repositoryItemCheckEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckedComboBoxEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit();
            this.repositoryItemProgressBar2 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.repositoryItemCheckedComboBoxEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit();
            this.营销组 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckedComboBoxEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckedComboBoxEdit3)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看明细ToolStripMenuItem,
            this.审批ToolStripMenuItem,
            this.驳回ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 70);
            // 
            // 查看明细ToolStripMenuItem
            // 
            this.查看明细ToolStripMenuItem.Name = "查看明细ToolStripMenuItem";
            this.查看明细ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.查看明细ToolStripMenuItem.Text = "查看明细";
            this.查看明细ToolStripMenuItem.Click += new System.EventHandler(this.查看明细ToolStripMenuItem_Click);
            // 
            // 审批ToolStripMenuItem
            // 
            this.审批ToolStripMenuItem.Name = "审批ToolStripMenuItem";
            this.审批ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.审批ToolStripMenuItem.Text = "审批";
            this.审批ToolStripMenuItem.Click += new System.EventHandler(this.审批ToolStripMenuItem_Click);
            // 
            // 驳回ToolStripMenuItem
            // 
            this.驳回ToolStripMenuItem.Name = "驳回ToolStripMenuItem";
            this.驳回ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.驳回ToolStripMenuItem.Text = "驳回";
            this.驳回ToolStripMenuItem.Click += new System.EventHandler(this.驳回ToolStripMenuItem_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(2);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemProgressBar3,
            this.repositoryItemCheckEdit3,
            this.repositoryItemCheckEdit4,
            this.repositoryItemCheckedComboBoxEdit2,
            this.repositoryItemProgressBar2,
            this.repositoryItemCheckedComboBoxEdit3});
            this.gridControl1.Size = new System.Drawing.Size(824, 582);
            this.gridControl1.TabIndex = 61;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click_1);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("黑体", 9F);
            this.gridView1.Appearance.EvenRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("黑体", 9F);
            this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView1.Appearance.ViewCaption.Font = new System.Drawing.Font("黑体", 9F);
            this.gridView1.Appearance.ViewCaption.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.状态,
            this.工作令号,
            this.预计设计开始时间,
            this.预计设计结束时间,
            this.合同名称,
            this.营销组});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 50;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // id
            // 
            this.id.Caption = "id";
            this.id.FieldName = "id";
            this.id.Name = "id";
            // 
            // 状态
            // 
            this.状态.Caption = "状态";
            this.状态.FieldName = "状态";
            this.状态.Name = "状态";
            this.状态.Visible = true;
            this.状态.VisibleIndex = 0;
            this.状态.Width = 244;
            // 
            // 工作令号
            // 
            this.工作令号.Caption = "工作令号";
            this.工作令号.FieldName = "工作令号";
            this.工作令号.Name = "工作令号";
            this.工作令号.Visible = true;
            this.工作令号.VisibleIndex = 1;
            this.工作令号.Width = 332;
            // 
            // 预计设计开始时间
            // 
            this.预计设计开始时间.Caption = "预计设计开始时间";
            this.预计设计开始时间.FieldName = "预计设计开始时间";
            this.预计设计开始时间.Name = "预计设计开始时间";
            this.预计设计开始时间.Visible = true;
            this.预计设计开始时间.VisibleIndex = 2;
            this.预计设计开始时间.Width = 332;
            // 
            // 预计设计结束时间
            // 
            this.预计设计结束时间.Caption = "预计设计结束时间";
            this.预计设计结束时间.FieldName = "预计设计结束时间";
            this.预计设计结束时间.Name = "预计设计结束时间";
            this.预计设计结束时间.Visible = true;
            this.预计设计结束时间.VisibleIndex = 3;
            this.预计设计结束时间.Width = 332;
            // 
            // 合同名称
            // 
            this.合同名称.Caption = "合同名称";
            this.合同名称.FieldName = "合同名称";
            this.合同名称.Name = "合同名称";
            this.合同名称.Visible = true;
            this.合同名称.VisibleIndex = 4;
            this.合同名称.Width = 338;
            // 
            // repositoryItemProgressBar3
            // 
            this.repositoryItemProgressBar3.Name = "repositoryItemProgressBar3";
            // 
            // repositoryItemCheckEdit3
            // 
            this.repositoryItemCheckEdit3.AutoHeight = false;
            this.repositoryItemCheckEdit3.Name = "repositoryItemCheckEdit3";
            // 
            // repositoryItemCheckEdit4
            // 
            this.repositoryItemCheckEdit4.AutoHeight = false;
            this.repositoryItemCheckEdit4.Name = "repositoryItemCheckEdit4";
            // 
            // repositoryItemCheckedComboBoxEdit2
            // 
            this.repositoryItemCheckedComboBoxEdit2.AutoHeight = false;
            this.repositoryItemCheckedComboBoxEdit2.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("5生产制作中", "5生产制作中"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("9已到货", "9已到货"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("取消", "取消")});
            this.repositoryItemCheckedComboBoxEdit2.Name = "repositoryItemCheckedComboBoxEdit2";
            // 
            // repositoryItemProgressBar2
            // 
            this.repositoryItemProgressBar2.Name = "repositoryItemProgressBar2";
            // 
            // repositoryItemCheckedComboBoxEdit3
            // 
            this.repositoryItemCheckedComboBoxEdit3.AutoHeight = false;
            this.repositoryItemCheckedComboBoxEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCheckedComboBoxEdit3.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("5生产制作中", "5生产制作中"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("9已到货", "9已到货"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("取消", "取消")});
            this.repositoryItemCheckedComboBoxEdit3.Name = "repositoryItemCheckedComboBoxEdit3";
            // 
            // 营销组
            // 
            this.营销组.Caption = "营销组";
            this.营销组.FieldName = "营销组";
            this.营销组.Name = "营销组";
            this.营销组.Visible = true;
            this.营销组.VisibleIndex = 5;
            // 
            // FrXiangmuguanli1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 582);
            this.Controls.Add(this.gridControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrXiangmuguanli1";
            this.Text = "FrXiangmuguanli1";
            this.Load += new System.EventHandler(this.FrXiangmuguanli1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckedComboBoxEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckedComboBoxEdit3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 审批ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 驳回ToolStripMenuItem;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn 工作令号;
        private DevExpress.XtraGrid.Columns.GridColumn 预计设计开始时间;
        private DevExpress.XtraGrid.Columns.GridColumn 预计设计结束时间;
        private DevExpress.XtraGrid.Columns.GridColumn 合同名称;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar3;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit4;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit repositoryItemCheckedComboBoxEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit repositoryItemCheckedComboBoxEdit3;
        private System.Windows.Forms.ToolStripMenuItem 查看明细ToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn 状态;
        private DevExpress.XtraGrid.Columns.GridColumn 营销组;
    }
}