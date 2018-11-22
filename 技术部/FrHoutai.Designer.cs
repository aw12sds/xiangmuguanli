namespace 项目管理系统.技术部
{
    partial class FrHoutai
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
            this.dataGridViewX2 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.项目主管 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.工作令号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.项目名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.设备名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.技术指标 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.方向 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.数量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.制造类型 = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.设备预计结束时间 = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.附件名称 = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.优先级 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.领导回复 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX2)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewX2
            // 
            this.dataGridViewX2.AllowUserToAddRows = false;
            this.dataGridViewX2.AllowUserToDeleteRows = false;
            this.dataGridViewX2.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
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
            this.项目主管,
            this.工作令号,
            this.项目名称,
            this.设备名称,
            this.技术指标,
            this.方向,
            this.数量,
            this.制造类型,
            this.设备预计结束时间,
            this.附件名称,
            this.时间,
            this.优先级,
            this.领导回复});
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
            this.dataGridViewX2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX2.Size = new System.Drawing.Size(1003, 624);
            this.dataGridViewX2.TabIndex = 43;
            this.dataGridViewX2.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridViewX2_CellPainting);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(109, 28);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.保存ToolStripMenuItem.Text = "保存";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // 项目主管
            // 
            this.项目主管.DataPropertyName = "项目主管";
            this.项目主管.HeaderText = "项目主管";
            this.项目主管.Name = "项目主管";
            this.项目主管.Visible = false;
            // 
            // 工作令号
            // 
            this.工作令号.DataPropertyName = "工作令号";
            this.工作令号.HeaderText = "工作令号";
            this.工作令号.Name = "工作令号";
            this.工作令号.ReadOnly = true;
            this.工作令号.Width = 200;
            // 
            // 项目名称
            // 
            this.项目名称.DataPropertyName = "项目名称";
            this.项目名称.HeaderText = "项目名称";
            this.项目名称.Name = "项目名称";
            this.项目名称.ReadOnly = true;
            this.项目名称.Width = 200;
            // 
            // 设备名称
            // 
            this.设备名称.DataPropertyName = "设备名称";
            this.设备名称.HeaderText = "设备名称";
            this.设备名称.Name = "设备名称";
            this.设备名称.Width = 200;
            // 
            // 技术指标
            // 
            this.技术指标.DataPropertyName = "技术指标";
            this.技术指标.HeaderText = "技术指标";
            this.技术指标.Name = "技术指标";
            this.技术指标.Width = 600;
            // 
            // 方向
            // 
            this.方向.DataPropertyName = "方向";
            this.方向.HeaderText = "方向";
            this.方向.Name = "方向";
            this.方向.Width = 200;
            // 
            // 数量
            // 
            this.数量.DataPropertyName = "数量";
            this.数量.HeaderText = "数量";
            this.数量.Name = "数量";
            this.数量.Width = 200;
            // 
            // 制造类型
            // 
            this.制造类型.DataPropertyName = "制造类型";
            this.制造类型.DisplayMember = "Text";
            this.制造类型.DropDownHeight = 106;
            this.制造类型.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.制造类型.DropDownWidth = 121;
            this.制造类型.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.制造类型.HeaderText = "制造类型";
            this.制造类型.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.制造类型.IntegralHeight = false;
            this.制造类型.ItemHeight = 20;
            this.制造类型.Items.AddRange(new object[] {
            "自制",
            "外购"});
            this.制造类型.Name = "制造类型";
            this.制造类型.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.制造类型.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.制造类型.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.制造类型.Width = 200;
            // 
            // 设备预计结束时间
            // 
            // 
            // 
            // 
            this.设备预计结束时间.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.设备预计结束时间.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.设备预计结束时间.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.设备预计结束时间.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText;
            this.设备预计结束时间.ButtonDropDown.Visible = true;
            this.设备预计结束时间.CustomFormat = "yyyy-MM-dd HH:mm";
            this.设备预计结束时间.DataPropertyName = "设备预计结束时间";
            this.设备预计结束时间.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.设备预计结束时间.HeaderText = "设计预计结束时间";
            this.设备预计结束时间.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            // 
            // 
            // 
            // 
            // 
            // 
            this.设备预计结束时间.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.设备预计结束时间.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            // 
            // 
            // 
            this.设备预计结束时间.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.设备预计结束时间.MonthCalendar.DisplayMonth = new System.DateTime(2018, 2, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.设备预计结束时间.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.设备预计结束时间.Name = "设备预计结束时间";
            this.设备预计结束时间.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.设备预计结束时间.Width = 200;
            // 
            // 附件名称
            // 
            this.附件名称.DataPropertyName = "附件名称";
            this.附件名称.HeaderText = "附件名称";
            this.附件名称.Name = "附件名称";
            this.附件名称.Text = null;
            this.附件名称.Width = 300;
            // 
            // 时间
            // 
            this.时间.DataPropertyName = "时间";
            this.时间.HeaderText = "时间";
            this.时间.Name = "时间";
            this.时间.Visible = false;
            // 
            // 优先级
            // 
            this.优先级.DataPropertyName = "优先级";
            this.优先级.HeaderText = "优先级";
            this.优先级.Name = "优先级";
            this.优先级.Visible = false;
            // 
            // 领导回复
            // 
            this.领导回复.DataPropertyName = "技术要求反馈内容";
            this.领导回复.HeaderText = "领导回复";
            this.领导回复.Name = "领导回复";
            this.领导回复.ReadOnly = true;
            this.领导回复.Width = 300;
            // 
            // FrHoutai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 624);
            this.Controls.Add(this.dataGridViewX2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrHoutai";
            this.Text = "FrHoutai";
            this.Load += new System.EventHandler(this.FrHoutai_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX2)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn 项目主管;
        private System.Windows.Forms.DataGridViewTextBoxColumn 工作令号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 项目名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 设备名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 技术指标;
        private System.Windows.Forms.DataGridViewTextBoxColumn 方向;
        private System.Windows.Forms.DataGridViewTextBoxColumn 数量;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn 制造类型;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn 设备预计结束时间;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn 附件名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 优先级;
        private System.Windows.Forms.DataGridViewTextBoxColumn 领导回复;
    }
}