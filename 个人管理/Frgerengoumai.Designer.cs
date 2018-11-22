namespace 项目管理系统.个人管理
{
    partial class Frgerengoumai
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip();
            this.添加附件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.工作令号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.新编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.型号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.单位 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.类型 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.要求到货日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.备注 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.申购人 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.当前状态 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.合同号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.供方名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.附件名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.附件 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.驳回原因 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.流程状态 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.附件)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bar1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(731, 21);
            this.panel1.TabIndex = 0;
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bar1.DockSide = DevComponents.DotNetBar.eDockSide.Top;
            this.bar1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem1});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(731, 26);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 0;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            this.bar1.ItemClick += new System.EventHandler(this.bar1_ItemClick);
            // 
            // buttonItem1
            // 
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "新建采购申请";
            this.buttonItem1.Click += new System.EventHandler(this.buttonItem1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 21);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(731, 461);
            this.panel2.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemProgressBar1,
            this.repositoryItemTextEdit1,
            this.附件});
            this.gridControl1.Size = new System.Drawing.Size(731, 461);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加附件ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 26);
            // 
            // 添加附件ToolStripMenuItem
            // 
            this.添加附件ToolStripMenuItem.Name = "添加附件ToolStripMenuItem";
            this.添加附件ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.添加附件ToolStripMenuItem.Text = "添加附件";
            this.添加附件ToolStripMenuItem.Click += new System.EventHandler(this.添加附件ToolStripMenuItem_Click);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.工作令号,
            this.编码,
            this.新编码,
            this.型号,
            this.名称,
            this.单位,
            this.数量,
            this.类型,
            this.要求到货日期,
            this.备注,
            this.申购人,
            this.当前状态,
            this.合同号,
            this.供方名称,
            this.附件名称,
            this.驳回原因,
            this.流程状态});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 50;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // id
            // 
            this.id.Caption = "id";
            this.id.FieldName = "id";
            this.id.Name = "id";
            // 
            // 工作令号
            // 
            this.工作令号.Caption = "流水号";
            this.工作令号.FieldName = "工作令号";
            this.工作令号.Name = "工作令号";
            this.工作令号.Visible = true;
            this.工作令号.VisibleIndex = 0;
            // 
            // 编码
            // 
            this.编码.Caption = "编码";
            this.编码.FieldName = "编码";
            this.编码.Name = "编码";
            this.编码.Visible = true;
            this.编码.VisibleIndex = 1;
            // 
            // 新编码
            // 
            this.新编码.Caption = "新编码";
            this.新编码.FieldName = "新编码";
            this.新编码.Name = "新编码";
            this.新编码.Visible = true;
            this.新编码.VisibleIndex = 2;
            // 
            // 型号
            // 
            this.型号.Caption = "型号";
            this.型号.FieldName = "型号";
            this.型号.Name = "型号";
            this.型号.Visible = true;
            this.型号.VisibleIndex = 3;
            // 
            // 名称
            // 
            this.名称.Caption = "名称";
            this.名称.FieldName = "名称";
            this.名称.Name = "名称";
            this.名称.Visible = true;
            this.名称.VisibleIndex = 4;
            // 
            // 单位
            // 
            this.单位.Caption = "单位";
            this.单位.FieldName = "单位";
            this.单位.Name = "单位";
            this.单位.Visible = true;
            this.单位.VisibleIndex = 5;
            // 
            // 数量
            // 
            this.数量.Caption = "数量";
            this.数量.FieldName = "数量";
            this.数量.Name = "数量";
            this.数量.Visible = true;
            this.数量.VisibleIndex = 6;
            // 
            // 类型
            // 
            this.类型.Caption = "类型";
            this.类型.FieldName = "类型";
            this.类型.Name = "类型";
            this.类型.Visible = true;
            this.类型.VisibleIndex = 7;
            // 
            // 要求到货日期
            // 
            this.要求到货日期.Caption = "要求到货日期";
            this.要求到货日期.FieldName = "要求到货日期";
            this.要求到货日期.Name = "要求到货日期";
            this.要求到货日期.Visible = true;
            this.要求到货日期.VisibleIndex = 8;
            // 
            // 备注
            // 
            this.备注.Caption = "备注";
            this.备注.FieldName = "备注";
            this.备注.Name = "备注";
            this.备注.Visible = true;
            this.备注.VisibleIndex = 9;
            // 
            // 申购人
            // 
            this.申购人.Caption = "申购人";
            this.申购人.FieldName = "申购人";
            this.申购人.Name = "申购人";
            this.申购人.Visible = true;
            this.申购人.VisibleIndex = 10;
            // 
            // 当前状态
            // 
            this.当前状态.Caption = "当前状态";
            this.当前状态.FieldName = "当前状态";
            this.当前状态.Name = "当前状态";
            this.当前状态.Visible = true;
            this.当前状态.VisibleIndex = 11;
            // 
            // 合同号
            // 
            this.合同号.Caption = "合同号";
            this.合同号.FieldName = "当前状态";
            this.合同号.Name = "合同号";
            this.合同号.Visible = true;
            this.合同号.VisibleIndex = 12;
            // 
            // 供方名称
            // 
            this.供方名称.Caption = "供方名称";
            this.供方名称.FieldName = "供方名称";
            this.供方名称.Name = "供方名称";
            this.供方名称.Visible = true;
            this.供方名称.VisibleIndex = 13;
            // 
            // 附件名称
            // 
            this.附件名称.Caption = "附件名称";
            this.附件名称.ColumnEdit = this.附件;
            this.附件名称.FieldName = "附件名称";
            this.附件名称.Name = "附件名称";
            this.附件名称.Visible = true;
            this.附件名称.VisibleIndex = 14;
            // 
            // 附件
            // 
            this.附件.AutoHeight = false;
            this.附件.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.附件.LookAndFeel.SkinName = "Office 2016 Colorful";
            this.附件.Name = "附件";
            // 
            // 驳回原因
            // 
            this.驳回原因.Caption = "驳回原因";
            this.驳回原因.FieldName = "驳回原因";
            this.驳回原因.Name = "驳回原因";
            this.驳回原因.Visible = true;
            this.驳回原因.VisibleIndex = 16;
            // 
            // 流程状态
            // 
            this.流程状态.Caption = "流程状态";
            this.流程状态.FieldName = "流程状态";
            this.流程状态.Name = "流程状态";
            this.流程状态.Visible = true;
            this.流程状态.VisibleIndex = 15;
            // 
            // repositoryItemProgressBar1
            // 
            this.repositoryItemProgressBar1.Name = "repositoryItemProgressBar1";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // Frgerengoumai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 482);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Frgerengoumai";
            this.Text = "Frgerengoumai";
            this.Load += new System.EventHandler(this.Frgerengoumai_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.附件)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn 工作令号;
        private DevExpress.XtraGrid.Columns.GridColumn 编码;
        private DevExpress.XtraGrid.Columns.GridColumn 型号;
        private DevExpress.XtraGrid.Columns.GridColumn 名称;
        private DevExpress.XtraGrid.Columns.GridColumn 单位;
        private DevExpress.XtraGrid.Columns.GridColumn 数量;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn 新编码;
        private DevExpress.XtraGrid.Columns.GridColumn 类型;
        private DevExpress.XtraGrid.Columns.GridColumn 要求到货日期;
        private DevExpress.XtraGrid.Columns.GridColumn 备注;
        private DevExpress.XtraGrid.Columns.GridColumn 申购人;
        private DevExpress.XtraGrid.Columns.GridColumn 附件名称;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit 附件;
        private DevExpress.XtraGrid.Columns.GridColumn 当前状态;
        private DevExpress.XtraGrid.Columns.GridColumn 合同号;
        private DevExpress.XtraGrid.Columns.GridColumn 供方名称;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 添加附件ToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn 流程状态;
        private DevExpress.XtraGrid.Columns.GridColumn 驳回原因;
    }
}