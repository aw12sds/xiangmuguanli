﻿namespace 项目管理系统.物流部
{
    partial class Frxunjialiaodan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frxunjialiaodan));
            this.dataGridViewX2 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.筛选 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.工作令号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.项目名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.设备名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.序号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.编码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.型号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.单位 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.数量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.类型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.项目工令号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.要求到货日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.备注 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.制造类型 = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.申购人 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.收到料单日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.供方名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.合同号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.实际采购数量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.报价 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.采购单价 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.实际到货日期 = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.合同到货时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.当前状态 = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.采购料单备注 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.附件名称 = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.附件类型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.生成合同ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.生成采购合同ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.生成设备合同ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.生成订货单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX2)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewX2
            // 
            this.dataGridViewX2.AllowUserToAddRows = false;
            this.dataGridViewX2.AllowUserToDeleteRows = false;
            this.dataGridViewX2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewX2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewX2.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.筛选,
            this.时间,
            this.工作令号,
            this.项目名称,
            this.设备名称,
            this.序号,
            this.编码,
            this.型号,
            this.名称,
            this.单位,
            this.数量,
            this.类型,
            this.项目工令号,
            this.要求到货日期,
            this.备注,
            this.制造类型,
            this.申购人,
            this.收到料单日期,
            this.供方名称,
            this.合同号,
            this.实际采购数量,
            this.报价,
            this.采购单价,
            this.实际到货日期,
            this.合同到货时间,
            this.当前状态,
            this.采购料单备注,
            this.附件名称,
            this.附件类型});
            this.dataGridViewX2.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewX2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX2.EnableHeadersVisualStyles = false;
            this.dataGridViewX2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX2.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX2.Name = "dataGridViewX2";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX2.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX2.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewX2.RowTemplate.Height = 27;
            this.dataGridViewX2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewX2.Size = new System.Drawing.Size(1243, 596);
            this.dataGridViewX2.TabIndex = 48;
            this.dataGridViewX2.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridViewX2_CellPainting);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // 筛选
            // 
            this.筛选.DataPropertyName = "筛选";
            this.筛选.FalseValue = "0";
            this.筛选.HeaderText = "筛选";
            this.筛选.Name = "筛选";
            this.筛选.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.筛选.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.筛选.TrueValue = "1";
            // 
            // 时间
            // 
            this.时间.DataPropertyName = "时间";
            this.时间.HeaderText = "时间";
            this.时间.Name = "时间";
            this.时间.Visible = false;
            // 
            // 工作令号
            // 
            this.工作令号.DataPropertyName = "工作令号";
            this.工作令号.HeaderText = "工作令号";
            this.工作令号.Name = "工作令号";
            this.工作令号.ReadOnly = true;
            // 
            // 项目名称
            // 
            this.项目名称.DataPropertyName = "项目名称";
            this.项目名称.HeaderText = "项目名称";
            this.项目名称.Name = "项目名称";
            this.项目名称.ReadOnly = true;
            // 
            // 设备名称
            // 
            this.设备名称.DataPropertyName = "设备名称";
            this.设备名称.HeaderText = "设备名称";
            this.设备名称.Name = "设备名称";
            this.设备名称.ReadOnly = true;
            // 
            // 序号
            // 
            this.序号.DataPropertyName = "序号";
            this.序号.HeaderText = "序号";
            this.序号.Name = "序号";
            this.序号.ReadOnly = true;
            // 
            // 编码
            // 
            this.编码.DataPropertyName = "编码";
            this.编码.HeaderText = "编码";
            this.编码.Name = "编码";
            this.编码.ReadOnly = true;
            // 
            // 型号
            // 
            this.型号.DataPropertyName = "型号";
            this.型号.HeaderText = "型号";
            this.型号.Name = "型号";
            this.型号.ReadOnly = true;
            // 
            // 名称
            // 
            this.名称.DataPropertyName = "名称";
            this.名称.HeaderText = "名称";
            this.名称.Name = "名称";
            this.名称.ReadOnly = true;
            // 
            // 单位
            // 
            this.单位.DataPropertyName = "单位";
            this.单位.HeaderText = "单位";
            this.单位.Name = "单位";
            this.单位.Visible = false;
            // 
            // 数量
            // 
            this.数量.DataPropertyName = "数量";
            this.数量.HeaderText = "数量";
            this.数量.Name = "数量";
            this.数量.ReadOnly = true;
            // 
            // 类型
            // 
            this.类型.DataPropertyName = "类型";
            this.类型.HeaderText = "类型";
            this.类型.Name = "类型";
            this.类型.ReadOnly = true;
            // 
            // 项目工令号
            // 
            this.项目工令号.DataPropertyName = "项目工令号";
            this.项目工令号.HeaderText = "库存数";
            this.项目工令号.Name = "项目工令号";
            this.项目工令号.ReadOnly = true;
            this.项目工令号.Visible = false;
            // 
            // 要求到货日期
            // 
            this.要求到货日期.DataPropertyName = "要求到货日期";
            this.要求到货日期.HeaderText = "要求到货日期";
            this.要求到货日期.Name = "要求到货日期";
            this.要求到货日期.ReadOnly = true;
            // 
            // 备注
            // 
            this.备注.DataPropertyName = "备注";
            this.备注.HeaderText = "备注";
            this.备注.Name = "备注";
            this.备注.ReadOnly = true;
            // 
            // 制造类型
            // 
            this.制造类型.DataPropertyName = "制造类型";
            this.制造类型.DropDownHeight = 106;
            this.制造类型.DropDownWidth = 121;
            this.制造类型.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.制造类型.HeaderText = "制造类型";
            this.制造类型.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.制造类型.IntegralHeight = false;
            this.制造类型.ItemHeight = 20;
            this.制造类型.Items.AddRange(new object[] {
            "外协零部件",
            "机械标准件",
            "电气标准件",
            "外购"});
            this.制造类型.Name = "制造类型";
            this.制造类型.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.制造类型.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // 申购人
            // 
            this.申购人.DataPropertyName = "申购人";
            this.申购人.HeaderText = "申购人";
            this.申购人.Name = "申购人";
            this.申购人.ReadOnly = true;
            // 
            // 收到料单日期
            // 
            this.收到料单日期.DataPropertyName = "收到料单日期";
            this.收到料单日期.HeaderText = "收到料单日期";
            this.收到料单日期.Name = "收到料单日期";
            this.收到料单日期.ReadOnly = true;
            // 
            // 供方名称
            // 
            this.供方名称.DataPropertyName = "供方名称";
            this.供方名称.HeaderText = "供方名称";
            this.供方名称.Name = "供方名称";
            // 
            // 合同号
            // 
            this.合同号.DataPropertyName = "合同号";
            this.合同号.HeaderText = "合同号";
            this.合同号.Name = "合同号";
            // 
            // 实际采购数量
            // 
            this.实际采购数量.DataPropertyName = "实际采购数量";
            this.实际采购数量.HeaderText = "实际采购数量";
            this.实际采购数量.Name = "实际采购数量";
            // 
            // 报价
            // 
            this.报价.DataPropertyName = "报价";
            this.报价.HeaderText = "报价";
            this.报价.Name = "报价";
            this.报价.Visible = false;
            // 
            // 采购单价
            // 
            this.采购单价.DataPropertyName = "采购单价";
            this.采购单价.HeaderText = "采购单价";
            this.采购单价.Name = "采购单价";
            this.采购单价.Visible = false;
            // 
            // 实际到货日期
            // 
            // 
            // 
            // 
            this.实际到货日期.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.实际到货日期.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.实际到货日期.ButtonDropDown.Visible = true;
            this.实际到货日期.CustomFormat = "yyyy-MM-dd HH:mm";
            this.实际到货日期.DataPropertyName = "实际到货日期";
            this.实际到货日期.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.实际到货日期.HeaderText = "实际到货日期";
            this.实际到货日期.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            // 
            // 
            // 
            // 
            // 
            // 
            this.实际到货日期.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.实际到货日期.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            // 
            // 
            // 
            this.实际到货日期.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.实际到货日期.MonthCalendar.DisplayMonth = new System.DateTime(2018, 2, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.实际到货日期.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.实际到货日期.Name = "实际到货日期";
            this.实际到货日期.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.实际到货日期.Visible = false;
            // 
            // 合同到货时间
            // 
            this.合同到货时间.DataPropertyName = "合同到货时间";
            this.合同到货时间.HeaderText = "合同到货时间";
            this.合同到货时间.Name = "合同到货时间";
            // 
            // 当前状态
            // 
            this.当前状态.DataPropertyName = "当前状态";
            this.当前状态.DropDownHeight = 106;
            this.当前状态.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.当前状态.DropDownWidth = 121;
            this.当前状态.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.当前状态.HeaderText = "当前状态";
            this.当前状态.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.当前状态.IntegralHeight = false;
            this.当前状态.ItemHeight = 20;
            this.当前状态.Items.AddRange(new object[] {
            "1询比价",
            "2采购合同已下达",
            "9已到货"});
            this.当前状态.Name = "当前状态";
            this.当前状态.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.当前状态.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // 采购料单备注
            // 
            this.采购料单备注.DataPropertyName = "采购料单备注";
            this.采购料单备注.HeaderText = "采购料单备注";
            this.采购料单备注.Name = "采购料单备注";
            // 
            // 附件名称
            // 
            this.附件名称.DataPropertyName = "附件名称";
            this.附件名称.HeaderText = "附件名称";
            this.附件名称.Name = "附件名称";
            this.附件名称.ReadOnly = true;
            this.附件名称.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.附件名称.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.附件名称.Text = null;
            // 
            // 附件类型
            // 
            this.附件类型.DataPropertyName = "附件类型";
            this.附件类型.HeaderText = "附件类型";
            this.附件类型.Name = "附件类型";
            this.附件类型.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.生成合同ToolStripMenuItem,
            this.生成采购合同ToolStripMenuItem,
            this.生成设备合同ToolStripMenuItem,
            this.生成订货单ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(176, 128);
            // 
            // 生成合同ToolStripMenuItem
            // 
            this.生成合同ToolStripMenuItem.Name = "生成合同ToolStripMenuItem";
            this.生成合同ToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.生成合同ToolStripMenuItem.Text = "生成成缆合同";
            this.生成合同ToolStripMenuItem.Click += new System.EventHandler(this.生成合同ToolStripMenuItem_Click);
            // 
            // 生成采购合同ToolStripMenuItem
            // 
            this.生成采购合同ToolStripMenuItem.Name = "生成采购合同ToolStripMenuItem";
            this.生成采购合同ToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.生成采购合同ToolStripMenuItem.Text = "生成采购合同";
            this.生成采购合同ToolStripMenuItem.Click += new System.EventHandler(this.生成采购合同ToolStripMenuItem_Click);
            // 
            // 生成设备合同ToolStripMenuItem
            // 
            this.生成设备合同ToolStripMenuItem.Name = "生成设备合同ToolStripMenuItem";
            this.生成设备合同ToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.生成设备合同ToolStripMenuItem.Text = "生成设备合同";
            this.生成设备合同ToolStripMenuItem.Click += new System.EventHandler(this.生成设备合同ToolStripMenuItem_Click);
            // 
            // 生成订货单ToolStripMenuItem
            // 
            this.生成订货单ToolStripMenuItem.Name = "生成订货单ToolStripMenuItem";
            this.生成订货单ToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.生成订货单ToolStripMenuItem.Text = "生成订货单";
            this.生成订货单ToolStripMenuItem.Click += new System.EventHandler(this.生成订货单ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bar1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1243, 29);
            this.panel1.TabIndex = 49;
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
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(1243, 30);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 0;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // buttonItem1
            // 
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "选中全部";
            this.buttonItem1.Click += new System.EventHandler(this.buttonItem1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridViewX2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1243, 596);
            this.panel2.TabIndex = 50;
            // 
            // Frxunjialiaodan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 625);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frxunjialiaodan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "询价单";
            this.Load += new System.EventHandler(this.Frxunjialiaodan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX2)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 生成合同ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 生成采购合同ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 生成设备合同ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 生成订货单ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 筛选;
        private System.Windows.Forms.DataGridViewTextBoxColumn 时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 工作令号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 项目名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 设备名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 序号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 编码;
        private System.Windows.Forms.DataGridViewTextBoxColumn 型号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 单位;
        private System.Windows.Forms.DataGridViewTextBoxColumn 数量;
        private System.Windows.Forms.DataGridViewTextBoxColumn 类型;
        private System.Windows.Forms.DataGridViewTextBoxColumn 项目工令号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 要求到货日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn 备注;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn 制造类型;
        private System.Windows.Forms.DataGridViewTextBoxColumn 申购人;
        private System.Windows.Forms.DataGridViewTextBoxColumn 收到料单日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn 供方名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 合同号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 实际采购数量;
        private System.Windows.Forms.DataGridViewTextBoxColumn 报价;
        private System.Windows.Forms.DataGridViewTextBoxColumn 采购单价;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn 实际到货日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn 合同到货时间;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn 当前状态;
        private System.Windows.Forms.DataGridViewTextBoxColumn 采购料单备注;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn 附件名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 附件类型;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private System.Windows.Forms.Panel panel2;
    }
}