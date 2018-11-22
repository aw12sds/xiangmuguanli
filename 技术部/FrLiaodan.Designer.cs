namespace 项目管理系统.技术部
{
    partial class FrLiaodan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrLiaodan));
            this.dataGridViewX2 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加图纸ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加单张图纸ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存更改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除该行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除全部ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.录入料单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.匹配新ERP编码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询ERPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.工作令号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.项目名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.设备名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.序号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.编码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.新编码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.型号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.单位 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.数量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.类型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.项目工令号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.要求到货日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.备注 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.制造类型 = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.实际采购数量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.附件名称 = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX2)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewX2
            // 
            this.dataGridViewX2.AllowUserToAddRows = false;
            this.dataGridViewX2.AllowUserToDeleteRows = false;
            this.dataGridViewX2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewX2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewX2.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridViewX2.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.时间,
            this.工作令号,
            this.项目名称,
            this.设备名称,
            this.序号,
            this.编码,
            this.新编码,
            this.型号,
            this.名称,
            this.单位,
            this.数量,
            this.类型,
            this.项目工令号,
            this.要求到货日期,
            this.备注,
            this.制造类型,
            this.实际采购数量,
            this.附件名称});
            this.dataGridViewX2.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewX2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX2.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX2.Name = "dataGridViewX2";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX2.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewX2.RowTemplate.Height = 27;
            this.dataGridViewX2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewX2.Size = new System.Drawing.Size(1267, 696);
            this.dataGridViewX2.TabIndex = 43;
            this.dataGridViewX2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX2_CellClick);
            this.dataGridViewX2.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridViewX2_CellPainting);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加图纸ToolStripMenuItem,
            this.添加单张图纸ToolStripMenuItem,
            this.保存更改ToolStripMenuItem,
            this.删除该行ToolStripMenuItem,
            this.删除全部ToolStripMenuItem,
            this.录入料单ToolStripMenuItem,
            this.匹配新ERP编码ToolStripMenuItem,
            this.查询ERPToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(464, 196);
            // 
            // 添加图纸ToolStripMenuItem
            // 
            this.添加图纸ToolStripMenuItem.Name = "添加图纸ToolStripMenuItem";
            this.添加图纸ToolStripMenuItem.Size = new System.Drawing.Size(463, 24);
            this.添加图纸ToolStripMenuItem.Text = "添加图纸(支持批量导入！批量导入时间较长，请耐心等待)";
            this.添加图纸ToolStripMenuItem.Click += new System.EventHandler(this.添加图纸ToolStripMenuItem_Click);
            // 
            // 添加单张图纸ToolStripMenuItem
            // 
            this.添加单张图纸ToolStripMenuItem.Name = "添加单张图纸ToolStripMenuItem";
            this.添加单张图纸ToolStripMenuItem.Size = new System.Drawing.Size(463, 24);
            this.添加单张图纸ToolStripMenuItem.Text = "添加单张图纸";
            this.添加单张图纸ToolStripMenuItem.Click += new System.EventHandler(this.添加单张图纸ToolStripMenuItem_Click);
            // 
            // 保存更改ToolStripMenuItem
            // 
            this.保存更改ToolStripMenuItem.Name = "保存更改ToolStripMenuItem";
            this.保存更改ToolStripMenuItem.Size = new System.Drawing.Size(463, 24);
            this.保存更改ToolStripMenuItem.Text = "保存更改";
            this.保存更改ToolStripMenuItem.Click += new System.EventHandler(this.保存更改ToolStripMenuItem_Click);
            // 
            // 删除该行ToolStripMenuItem
            // 
            this.删除该行ToolStripMenuItem.Name = "删除该行ToolStripMenuItem";
            this.删除该行ToolStripMenuItem.Size = new System.Drawing.Size(463, 24);
            this.删除该行ToolStripMenuItem.Text = "删除该行";
            this.删除该行ToolStripMenuItem.Click += new System.EventHandler(this.删除该行ToolStripMenuItem_Click);
            // 
            // 删除全部ToolStripMenuItem
            // 
            this.删除全部ToolStripMenuItem.Name = "删除全部ToolStripMenuItem";
            this.删除全部ToolStripMenuItem.Size = new System.Drawing.Size(463, 24);
            this.删除全部ToolStripMenuItem.Text = "删除全部";
            this.删除全部ToolStripMenuItem.Click += new System.EventHandler(this.删除全部ToolStripMenuItem_Click);
            // 
            // 录入料单ToolStripMenuItem
            // 
            this.录入料单ToolStripMenuItem.Name = "录入料单ToolStripMenuItem";
            this.录入料单ToolStripMenuItem.Size = new System.Drawing.Size(463, 24);
            this.录入料单ToolStripMenuItem.Text = "录入料单";
            this.录入料单ToolStripMenuItem.Click += new System.EventHandler(this.录入料单ToolStripMenuItem_Click_1);
            // 
            // 匹配新ERP编码ToolStripMenuItem
            // 
            this.匹配新ERP编码ToolStripMenuItem.Name = "匹配新ERP编码ToolStripMenuItem";
            this.匹配新ERP编码ToolStripMenuItem.Size = new System.Drawing.Size(463, 24);
            this.匹配新ERP编码ToolStripMenuItem.Text = "匹配新ERP编码";
            this.匹配新ERP编码ToolStripMenuItem.Click += new System.EventHandler(this.匹配新ERP编码ToolStripMenuItem_Click);
            // 
            // 查询ERPToolStripMenuItem
            // 
            this.查询ERPToolStripMenuItem.Name = "查询ERPToolStripMenuItem";
            this.查询ERPToolStripMenuItem.Size = new System.Drawing.Size(463, 24);
            this.查询ERPToolStripMenuItem.Text = "查询ERP";
            this.查询ERPToolStripMenuItem.Click += new System.EventHandler(this.查询ERPToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridViewX2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1267, 696);
            this.panel2.TabIndex = 45;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
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
            this.工作令号.Visible = false;
            // 
            // 项目名称
            // 
            this.项目名称.DataPropertyName = "项目名称";
            this.项目名称.HeaderText = "项目名称";
            this.项目名称.Name = "项目名称";
            this.项目名称.ReadOnly = true;
            this.项目名称.Visible = false;
            // 
            // 设备名称
            // 
            this.设备名称.DataPropertyName = "设备名称";
            this.设备名称.HeaderText = "设备名称";
            this.设备名称.Name = "设备名称";
            this.设备名称.ReadOnly = true;
            this.设备名称.Visible = false;
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
            // 新编码
            // 
            this.新编码.DataPropertyName = "新编码";
            this.新编码.HeaderText = "新编码";
            this.新编码.Name = "新编码";
            this.新编码.ReadOnly = true;
            this.新编码.Visible = false;
            // 
            // 型号
            // 
            this.型号.DataPropertyName = "型号";
            this.型号.HeaderText = "型号";
            this.型号.Name = "型号";
            // 
            // 名称
            // 
            this.名称.DataPropertyName = "名称";
            this.名称.HeaderText = "名称";
            this.名称.Name = "名称";
            // 
            // 单位
            // 
            this.单位.DataPropertyName = "单位";
            this.单位.HeaderText = "单位";
            this.单位.Name = "单位";
            this.单位.ReadOnly = true;
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
            // 
            // 项目工令号
            // 
            this.项目工令号.DataPropertyName = "项目工令号";
            this.项目工令号.HeaderText = "库存数";
            this.项目工令号.Name = "项目工令号";
            this.项目工令号.ReadOnly = true;
            // 
            // 要求到货日期
            // 
            this.要求到货日期.DataPropertyName = "要求到货日期";
            this.要求到货日期.HeaderText = "要求到货日期";
            this.要求到货日期.Name = "要求到货日期";
            this.要求到货日期.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.要求到货日期.Visible = false;
            // 
            // 备注
            // 
            this.备注.DataPropertyName = "备注";
            this.备注.HeaderText = "备注";
            this.备注.Name = "备注";
            // 
            // 制造类型
            // 
            this.制造类型.DataPropertyName = "制造类型";
            this.制造类型.DropDownHeight = 106;
            this.制造类型.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.制造类型.DropDownWidth = 121;
            this.制造类型.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.制造类型.HeaderText = "制造类型";
            this.制造类型.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.制造类型.IntegralHeight = false;
            this.制造类型.ItemHeight = 20;
            this.制造类型.Items.AddRange(new object[] {
            "零件",
            "机械标准件",
            "电气标准件",
            "外购",
            "库存件"});
            this.制造类型.Name = "制造类型";
            this.制造类型.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.制造类型.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // 实际采购数量
            // 
            this.实际采购数量.DataPropertyName = "实际采购数量";
            this.实际采购数量.HeaderText = "实际采购（加工）数量";
            this.实际采购数量.Name = "实际采购数量";
            this.实际采购数量.ReadOnly = true;
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
            // FrLiaodan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1267, 696);
            this.Controls.Add(this.panel2);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrLiaodan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "料单";
            this.Load += new System.EventHandler(this.FrLiaodan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX2)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 添加图纸ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存更改ToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem 删除该行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 录入料单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 匹配新ERP编码ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除全部ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询ERPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加单张图纸ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn 时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 工作令号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 项目名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 设备名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 序号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 编码;
        private System.Windows.Forms.DataGridViewTextBoxColumn 新编码;
        private System.Windows.Forms.DataGridViewTextBoxColumn 型号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 单位;
        private System.Windows.Forms.DataGridViewTextBoxColumn 数量;
        private System.Windows.Forms.DataGridViewTextBoxColumn 类型;
        private System.Windows.Forms.DataGridViewTextBoxColumn 项目工令号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 要求到货日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn 备注;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn 制造类型;
        private System.Windows.Forms.DataGridViewTextBoxColumn 实际采购数量;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn 附件名称;
    }
}