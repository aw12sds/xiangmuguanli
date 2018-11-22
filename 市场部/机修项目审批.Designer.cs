namespace 项目管理系统.市场部
{
    partial class 机修项目审批
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.接单编号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.机修件ERP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.客户名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.部门 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.工件名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.加工内容 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.计量单位 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.机修件数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.接单日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.预交时间 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.联系人 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.责任人 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.加工单位备注 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.当前状态 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.合同号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.供方名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.同意ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看附件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.repositoryItemProgressBar1});
            this.gridControl1.Size = new System.Drawing.Size(710, 402);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.接单编号,
            this.机修件ERP,
            this.客户名称,
            this.部门,
            this.工件名称,
            this.加工内容,
            this.计量单位,
            this.机修件数量,
            this.接单日期,
            this.预交时间,
            this.联系人,
            this.责任人,
            this.加工单位备注,
            this.当前状态,
            this.合同号,
            this.供方名称,
            this.gridColumn1});
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
            // 接单编号
            // 
            this.接单编号.Caption = "接单编号";
            this.接单编号.FieldName = "接单编号";
            this.接单编号.Name = "接单编号";
            this.接单编号.Visible = true;
            this.接单编号.VisibleIndex = 0;
            // 
            // 机修件ERP
            // 
            this.机修件ERP.Caption = "机修件ERP";
            this.机修件ERP.FieldName = "机修件ERP";
            this.机修件ERP.Name = "机修件ERP";
            this.机修件ERP.Visible = true;
            this.机修件ERP.VisibleIndex = 1;
            // 
            // 客户名称
            // 
            this.客户名称.Caption = "客户名称";
            this.客户名称.FieldName = "客户名称";
            this.客户名称.Name = "客户名称";
            this.客户名称.Visible = true;
            this.客户名称.VisibleIndex = 2;
            // 
            // 部门
            // 
            this.部门.Caption = "部门";
            this.部门.FieldName = "部门";
            this.部门.Name = "部门";
            this.部门.Visible = true;
            this.部门.VisibleIndex = 3;
            // 
            // 工件名称
            // 
            this.工件名称.Caption = "工件名称";
            this.工件名称.FieldName = "工件名称";
            this.工件名称.Name = "工件名称";
            this.工件名称.Visible = true;
            this.工件名称.VisibleIndex = 4;
            // 
            // 加工内容
            // 
            this.加工内容.Caption = "加工内容";
            this.加工内容.FieldName = "加工内容";
            this.加工内容.Name = "加工内容";
            this.加工内容.Visible = true;
            this.加工内容.VisibleIndex = 5;
            // 
            // 计量单位
            // 
            this.计量单位.Caption = "计量单位";
            this.计量单位.FieldName = "计量单位";
            this.计量单位.Name = "计量单位";
            this.计量单位.Visible = true;
            this.计量单位.VisibleIndex = 6;
            // 
            // 机修件数量
            // 
            this.机修件数量.Caption = "机修件数量";
            this.机修件数量.FieldName = "机修件数量";
            this.机修件数量.Name = "机修件数量";
            this.机修件数量.Visible = true;
            this.机修件数量.VisibleIndex = 7;
            // 
            // 接单日期
            // 
            this.接单日期.Caption = "接单日期";
            this.接单日期.FieldName = "接单日期";
            this.接单日期.Name = "接单日期";
            this.接单日期.Visible = true;
            this.接单日期.VisibleIndex = 8;
            // 
            // 预交时间
            // 
            this.预交时间.Caption = "预交时间";
            this.预交时间.FieldName = "预交时间";
            this.预交时间.Name = "预交时间";
            this.预交时间.Visible = true;
            this.预交时间.VisibleIndex = 9;
            // 
            // 联系人
            // 
            this.联系人.Caption = "联系人";
            this.联系人.FieldName = "联系人";
            this.联系人.Name = "联系人";
            this.联系人.Visible = true;
            this.联系人.VisibleIndex = 10;
            // 
            // 责任人
            // 
            this.责任人.Caption = "责任人";
            this.责任人.FieldName = "责任人";
            this.责任人.Name = "责任人";
            this.责任人.Visible = true;
            this.责任人.VisibleIndex = 11;
            // 
            // 加工单位备注
            // 
            this.加工单位备注.Caption = "加工单位备注";
            this.加工单位备注.FieldName = "加工单位备注";
            this.加工单位备注.Name = "加工单位备注";
            this.加工单位备注.Visible = true;
            this.加工单位备注.VisibleIndex = 12;
            // 
            // 当前状态
            // 
            this.当前状态.Caption = "当前状态";
            this.当前状态.FieldName = "当前状态";
            this.当前状态.Name = "当前状态";
            this.当前状态.Visible = true;
            this.当前状态.VisibleIndex = 13;
            // 
            // 合同号
            // 
            this.合同号.Caption = "合同号";
            this.合同号.FieldName = "合同号";
            this.合同号.Name = "合同号";
            this.合同号.Visible = true;
            this.合同号.VisibleIndex = 14;
            // 
            // 供方名称
            // 
            this.供方名称.Caption = "供方名称";
            this.供方名称.FieldName = "供方名称";
            this.供方名称.Name = "供方名称";
            this.供方名称.Visible = true;
            this.供方名称.VisibleIndex = 15;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "附件名称";
            this.gridColumn1.FieldName = "附件名称";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 16;
            // 
            // repositoryItemProgressBar1
            // 
            this.repositoryItemProgressBar1.Name = "repositoryItemProgressBar1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.同意ToolStripMenuItem,
            this.查看附件ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 70);
            // 
            // 同意ToolStripMenuItem
            // 
            this.同意ToolStripMenuItem.Name = "同意ToolStripMenuItem";
            this.同意ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.同意ToolStripMenuItem.Text = "通过";
            this.同意ToolStripMenuItem.Click += new System.EventHandler(this.同意ToolStripMenuItem_Click);
            // 
            // 查看附件ToolStripMenuItem
            // 
            this.查看附件ToolStripMenuItem.Name = "查看附件ToolStripMenuItem";
            this.查看附件ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.查看附件ToolStripMenuItem.Text = "查看附件";
            this.查看附件ToolStripMenuItem.Click += new System.EventHandler(this.查看附件ToolStripMenuItem_Click);
            // 
            // 机修项目审批
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 402);
            this.Controls.Add(this.gridControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "机修项目审批";
            this.Text = "机修项目审批";
            this.Load += new System.EventHandler(this.机修项目审批_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn 接单编号;
        private DevExpress.XtraGrid.Columns.GridColumn 机修件ERP;
        private DevExpress.XtraGrid.Columns.GridColumn 客户名称;
        private DevExpress.XtraGrid.Columns.GridColumn 部门;
        private DevExpress.XtraGrid.Columns.GridColumn 工件名称;
        private DevExpress.XtraGrid.Columns.GridColumn 加工内容;
        private DevExpress.XtraGrid.Columns.GridColumn 计量单位;
        private DevExpress.XtraGrid.Columns.GridColumn 机修件数量;
        private DevExpress.XtraGrid.Columns.GridColumn 接单日期;
        private DevExpress.XtraGrid.Columns.GridColumn 预交时间;
        private DevExpress.XtraGrid.Columns.GridColumn 联系人;
        private DevExpress.XtraGrid.Columns.GridColumn 责任人;
        private DevExpress.XtraGrid.Columns.GridColumn 加工单位备注;
        private DevExpress.XtraGrid.Columns.GridColumn 当前状态;
        private DevExpress.XtraGrid.Columns.GridColumn 合同号;
        private DevExpress.XtraGrid.Columns.GridColumn 供方名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 同意ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看附件ToolStripMenuItem;
    }
}