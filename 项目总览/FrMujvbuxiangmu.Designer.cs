namespace 项目管理系统.项目总览
{
    partial class FrMujvbuxiangmu
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
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.业务 = new DevExpress.XtraTab.XtraTabPage();
            this.采购 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.模具部自制外协修改 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.id1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.模具部状态 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.接单日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.工作令号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.客户1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.模具部联系人 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.产品名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.规格 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.单位 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.业务员 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.erp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.类型 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.生产车间 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.交货日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.附件名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.模具部项目名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.项目名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.采购工作令号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.模具部状态1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.下单日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.模具部erp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.模具部申请人1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.规格1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.材质 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.单位1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.供应商 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.数量1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.模具部备注 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.业务.SuspendLayout();
            this.采购.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.业务;
            this.xtraTabControl1.Size = new System.Drawing.Size(912, 582);
            this.xtraTabControl1.TabIndex = 9;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.业务,
            this.采购});
            // 
            // 业务
            // 
            this.业务.Controls.Add(this.gridControl1);
            this.业务.Name = "业务";
            this.业务.Size = new System.Drawing.Size(905, 546);
            this.业务.Text = "业务";
            // 
            // 采购
            // 
            this.采购.Controls.Add(this.gridControl2);
            this.采购.Name = "采购";
            this.采购.Size = new System.Drawing.Size(905, 546);
            this.采购.Text = "采购";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1});
            this.gridControl1.Size = new System.Drawing.Size(905, 546);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.Yellow;
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.模具部自制外协修改,
            this.id1,
            this.模具部状态,
            this.接单日期,
            this.工作令号,
            this.客户1,
            this.模具部联系人,
            this.产品名称,
            this.规格,
            this.单位,
            this.数量,
            this.业务员,
            this.erp,
            this.类型,
            this.生产车间,
            this.交货日期,
            this.附件名称,
            this.模具部项目名称});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // 模具部自制外协修改
            // 
            this.模具部自制外协修改.Caption = "类型修改";
            this.模具部自制外协修改.FieldName = "模具部自制外协修改";
            this.模具部自制外协修改.Name = "模具部自制外协修改";
            this.模具部自制外协修改.Visible = true;
            this.模具部自制外协修改.VisibleIndex = 13;
            this.模具部自制外协修改.Width = 76;
            // 
            // id1
            // 
            this.id1.Caption = "id1";
            this.id1.FieldName = "id";
            this.id1.Name = "id1";
            this.id1.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
            // 
            // 模具部状态
            // 
            this.模具部状态.Caption = "模具部状态";
            this.模具部状态.FieldName = "statename";
            this.模具部状态.Name = "模具部状态";
            this.模具部状态.Visible = true;
            this.模具部状态.VisibleIndex = 1;
            this.模具部状态.Width = 131;
            // 
            // 接单日期
            // 
            this.接单日期.AppearanceHeader.BackColor = System.Drawing.Color.LightSkyBlue;
            this.接单日期.AppearanceHeader.Options.UseBackColor = true;
            this.接单日期.Caption = "接单日期";
            this.接单日期.FieldName = "模具部接单日期";
            this.接单日期.Name = "接单日期";
            this.接单日期.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.接单日期.Visible = true;
            this.接单日期.VisibleIndex = 15;
            this.接单日期.Width = 65;
            // 
            // 工作令号
            // 
            this.工作令号.Caption = "工作令号";
            this.工作令号.FieldName = "工作令号";
            this.工作令号.Name = "工作令号";
            this.工作令号.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.工作令号.Visible = true;
            this.工作令号.VisibleIndex = 5;
            this.工作令号.Width = 82;
            // 
            // 客户1
            // 
            this.客户1.Caption = "客户";
            this.客户1.FieldName = "模具部客户";
            this.客户1.Name = "客户1";
            this.客户1.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.客户1.Visible = true;
            this.客户1.VisibleIndex = 6;
            this.客户1.Width = 120;
            // 
            // 模具部联系人
            // 
            this.模具部联系人.Caption = "联系人";
            this.模具部联系人.FieldName = "模具部联系人";
            this.模具部联系人.Name = "模具部联系人";
            this.模具部联系人.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.模具部联系人.Visible = true;
            this.模具部联系人.VisibleIndex = 7;
            this.模具部联系人.Width = 67;
            // 
            // 产品名称
            // 
            this.产品名称.Caption = "产品名称";
            this.产品名称.FieldName = "名称";
            this.产品名称.Name = "产品名称";
            this.产品名称.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.产品名称.Visible = true;
            this.产品名称.VisibleIndex = 9;
            this.产品名称.Width = 120;
            // 
            // 规格
            // 
            this.规格.Caption = "规格";
            this.规格.FieldName = "型号";
            this.规格.Name = "规格";
            this.规格.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.规格.Visible = true;
            this.规格.VisibleIndex = 10;
            this.规格.Width = 80;
            // 
            // 单位
            // 
            this.单位.Caption = "单位";
            this.单位.FieldName = "单位";
            this.单位.Name = "单位";
            this.单位.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.单位.Visible = true;
            this.单位.VisibleIndex = 11;
            this.单位.Width = 47;
            // 
            // 数量
            // 
            this.数量.Caption = "数量";
            this.数量.FieldName = "数量";
            this.数量.Name = "数量";
            this.数量.Visible = true;
            this.数量.VisibleIndex = 12;
            this.数量.Width = 44;
            // 
            // 业务员
            // 
            this.业务员.Caption = "业务员";
            this.业务员.FieldName = "模具部申请人";
            this.业务员.Name = "业务员";
            this.业务员.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.业务员.Visible = true;
            this.业务员.VisibleIndex = 18;
            // 
            // erp
            // 
            this.erp.Caption = "erp";
            this.erp.FieldName = "编码";
            this.erp.Name = "erp";
            this.erp.Visible = true;
            this.erp.VisibleIndex = 2;
            this.erp.Width = 69;
            // 
            // 类型
            // 
            this.类型.Caption = "类型";
            this.类型.FieldName = "制造类型";
            this.类型.Name = "类型";
            this.类型.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.类型.Visible = true;
            this.类型.VisibleIndex = 3;
            this.类型.Width = 48;
            // 
            // 生产车间
            // 
            this.生产车间.Caption = "生产车间";
            this.生产车间.FieldName = "模具部生产车间";
            this.生产车间.Name = "生产车间";
            this.生产车间.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.生产车间.Visible = true;
            this.生产车间.VisibleIndex = 4;
            // 
            // 交货日期
            // 
            this.交货日期.Caption = "交货日期";
            this.交货日期.FieldName = "模具部交货日期";
            this.交货日期.Name = "交货日期";
            this.交货日期.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.交货日期.Visible = true;
            this.交货日期.VisibleIndex = 16;
            this.交货日期.Width = 81;
            // 
            // 附件名称
            // 
            this.附件名称.Caption = "附件名称";
            this.附件名称.FieldName = "附件名称";
            this.附件名称.Name = "附件名称";
            this.附件名称.Visible = true;
            this.附件名称.VisibleIndex = 17;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // 模具部项目名称
            // 
            this.模具部项目名称.Caption = "项目名称";
            this.模具部项目名称.FieldName = "项目名称";
            this.模具部项目名称.Name = "模具部项目名称";
            this.模具部项目名称.Visible = true;
            this.模具部项目名称.VisibleIndex = 8;
            this.模具部项目名称.Width = 105;
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl2.Location = new System.Drawing.Point(0, 0);
            this.gridControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(905, 546);
            this.gridControl2.TabIndex = 6;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.项目名称,
            this.名称,
            this.采购工作令号,
            this.模具部状态1,
            this.下单日期,
            this.模具部erp,
            this.模具部申请人1,
            this.规格1,
            this.材质,
            this.单位1,
            this.供应商,
            this.数量1,
            this.模具部备注});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsFind.AlwaysVisible = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // id
            // 
            this.id.Caption = "id";
            this.id.FieldName = "id";
            this.id.Name = "id";
            // 
            // 项目名称
            // 
            this.项目名称.Caption = "项目名称";
            this.项目名称.FieldName = "项目名称";
            this.项目名称.Name = "项目名称";
            this.项目名称.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.项目名称.Visible = true;
            this.项目名称.VisibleIndex = 3;
            this.项目名称.Width = 85;
            // 
            // 名称
            // 
            this.名称.Caption = "名称";
            this.名称.FieldName = "名称";
            this.名称.Name = "名称";
            this.名称.Visible = true;
            this.名称.VisibleIndex = 4;
            this.名称.Width = 81;
            // 
            // 采购工作令号
            // 
            this.采购工作令号.Caption = "工作令号";
            this.采购工作令号.FieldName = "工作令号";
            this.采购工作令号.Name = "采购工作令号";
            this.采购工作令号.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.采购工作令号.Visible = true;
            this.采购工作令号.VisibleIndex = 1;
            this.采购工作令号.Width = 76;
            // 
            // 模具部状态1
            // 
            this.模具部状态1.Caption = "模具部状态";
            this.模具部状态1.FieldName = "statename";
            this.模具部状态1.Name = "模具部状态1";
            this.模具部状态1.Visible = true;
            this.模具部状态1.VisibleIndex = 0;
            this.模具部状态1.Width = 71;
            // 
            // 下单日期
            // 
            this.下单日期.Caption = "下单日期";
            this.下单日期.FieldName = "模具部接单日期";
            this.下单日期.Name = "下单日期";
            this.下单日期.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.下单日期.Visible = true;
            this.下单日期.VisibleIndex = 11;
            this.下单日期.Width = 71;
            // 
            // 模具部erp
            // 
            this.模具部erp.Caption = "ERP";
            this.模具部erp.FieldName = "编码";
            this.模具部erp.Name = "模具部erp";
            this.模具部erp.Visible = true;
            this.模具部erp.VisibleIndex = 2;
            this.模具部erp.Width = 89;
            // 
            // 模具部申请人1
            // 
            this.模具部申请人1.Caption = "申请人";
            this.模具部申请人1.FieldName = "模具部申请人";
            this.模具部申请人1.Name = "模具部申请人1";
            this.模具部申请人1.Visible = true;
            this.模具部申请人1.VisibleIndex = 12;
            this.模具部申请人1.Width = 45;
            // 
            // 规格1
            // 
            this.规格1.Caption = "规格";
            this.规格1.FieldName = "型号";
            this.规格1.Name = "规格1";
            this.规格1.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.规格1.Visible = true;
            this.规格1.VisibleIndex = 5;
            this.规格1.Width = 78;
            // 
            // 材质
            // 
            this.材质.Caption = "材质";
            this.材质.FieldName = "材质";
            this.材质.Name = "材质";
            this.材质.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.材质.Visible = true;
            this.材质.VisibleIndex = 6;
            this.材质.Width = 65;
            // 
            // 单位1
            // 
            this.单位1.Caption = "单位";
            this.单位1.FieldName = "单位";
            this.单位1.Name = "单位1";
            this.单位1.Visible = true;
            this.单位1.VisibleIndex = 8;
            this.单位1.Width = 38;
            // 
            // 供应商
            // 
            this.供应商.Caption = "供应商";
            this.供应商.FieldName = "供方名称";
            this.供应商.Name = "供应商";
            this.供应商.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.供应商.Visible = true;
            this.供应商.VisibleIndex = 10;
            this.供应商.Width = 63;
            // 
            // 数量1
            // 
            this.数量1.Caption = "数量";
            this.数量1.FieldName = "数量";
            this.数量1.Name = "数量1";
            this.数量1.Visible = true;
            this.数量1.VisibleIndex = 9;
            this.数量1.Width = 33;
            // 
            // 模具部备注
            // 
            this.模具部备注.Caption = "备注";
            this.模具部备注.FieldName = "备注";
            this.模具部备注.Name = "模具部备注";
            this.模具部备注.Visible = true;
            this.模具部备注.VisibleIndex = 7;
            this.模具部备注.Width = 62;
            // 
            // FrMujvbuxiangmu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 582);
            this.Controls.Add(this.xtraTabControl1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrMujvbuxiangmu";
            this.Text = "FrMujvbuxiangmu";
            this.Load += new System.EventHandler(this.FrMujvbuxiangmu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.业务.ResumeLayout(false);
            this.采购.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage 业务;
        private DevExpress.XtraTab.XtraTabPage 采购;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn 模具部自制外协修改;
        private DevExpress.XtraGrid.Columns.GridColumn id1;
        private DevExpress.XtraGrid.Columns.GridColumn 模具部状态;
        private DevExpress.XtraGrid.Columns.GridColumn 接单日期;
        private DevExpress.XtraGrid.Columns.GridColumn 工作令号;
        private DevExpress.XtraGrid.Columns.GridColumn 客户1;
        private DevExpress.XtraGrid.Columns.GridColumn 模具部联系人;
        private DevExpress.XtraGrid.Columns.GridColumn 产品名称;
        private DevExpress.XtraGrid.Columns.GridColumn 规格;
        private DevExpress.XtraGrid.Columns.GridColumn 单位;
        private DevExpress.XtraGrid.Columns.GridColumn 数量;
        private DevExpress.XtraGrid.Columns.GridColumn 业务员;
        private DevExpress.XtraGrid.Columns.GridColumn erp;
        private DevExpress.XtraGrid.Columns.GridColumn 类型;
        private DevExpress.XtraGrid.Columns.GridColumn 生产车间;
        private DevExpress.XtraGrid.Columns.GridColumn 交货日期;
        private DevExpress.XtraGrid.Columns.GridColumn 附件名称;
        private DevExpress.XtraGrid.Columns.GridColumn 模具部项目名称;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn 项目名称;
        private DevExpress.XtraGrid.Columns.GridColumn 名称;
        private DevExpress.XtraGrid.Columns.GridColumn 采购工作令号;
        private DevExpress.XtraGrid.Columns.GridColumn 模具部状态1;
        private DevExpress.XtraGrid.Columns.GridColumn 下单日期;
        private DevExpress.XtraGrid.Columns.GridColumn 模具部erp;
        private DevExpress.XtraGrid.Columns.GridColumn 模具部申请人1;
        private DevExpress.XtraGrid.Columns.GridColumn 规格1;
        private DevExpress.XtraGrid.Columns.GridColumn 材质;
        private DevExpress.XtraGrid.Columns.GridColumn 单位1;
        private DevExpress.XtraGrid.Columns.GridColumn 供应商;
        private DevExpress.XtraGrid.Columns.GridColumn 数量1;
        private DevExpress.XtraGrid.Columns.GridColumn 模具部备注;
    }
}