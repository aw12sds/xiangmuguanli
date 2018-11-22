namespace 项目管理系统.技术部
{
    partial class FrTiaoshiguanli
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrTiaoshiguanli));
            this.dataGridViewX2 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.确认完成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.项目主管 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.工作令号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.项目名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.设备名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.数量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.设备预计结束时间 = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.调试确认 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX2)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewX2
            // 
            this.dataGridViewX2.AllowUserToAddRows = false;
            this.dataGridViewX2.AllowUserToDeleteRows = false;
            this.dataGridViewX2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewX2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
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
            this.数量,
            this.设备预计结束时间,
            this.时间,
            this.调试确认});
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
            this.dataGridViewX2.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX2.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewX2.RowTemplate.Height = 27;
            this.dataGridViewX2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewX2.Size = new System.Drawing.Size(1099, 699);
            this.dataGridViewX2.TabIndex = 45;
            this.dataGridViewX2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX2_CellDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.确认完成ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(139, 28);
            // 
            // 确认完成ToolStripMenuItem
            // 
            this.确认完成ToolStripMenuItem.Name = "确认完成ToolStripMenuItem";
            this.确认完成ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.确认完成ToolStripMenuItem.Text = "确认完成";
            this.确认完成ToolStripMenuItem.Click += new System.EventHandler(this.确认完成ToolStripMenuItem_Click);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // 项目主管
            // 
            this.项目主管.DataPropertyName = "项目主管";
            this.项目主管.HeaderText = "项目主管";
            this.项目主管.Name = "项目主管";
            this.项目主管.ReadOnly = true;
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
            // 数量
            // 
            this.数量.DataPropertyName = "数量";
            this.数量.HeaderText = "数量";
            this.数量.Name = "数量";
            this.数量.ReadOnly = true;
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
            this.设备预计结束时间.HeaderText = "设备预计结束时间";
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
            this.设备预计结束时间.ReadOnly = true;
            this.设备预计结束时间.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // 时间
            // 
            this.时间.DataPropertyName = "时间";
            this.时间.HeaderText = "时间";
            this.时间.Name = "时间";
            this.时间.ReadOnly = true;
            this.时间.Visible = false;
            // 
            // 调试确认
            // 
            this.调试确认.DataPropertyName = "调试确认";
            this.调试确认.FalseValue = "0";
            this.调试确认.HeaderText = "调试确认";
            this.调试确认.Name = "调试确认";
            this.调试确认.ReadOnly = true;
            this.调试确认.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.调试确认.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.调试确认.TrueValue = "1";
            this.调试确认.Visible = false;
            // 
            // FrTiaoshiguanli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 699);
            this.Controls.Add(this.dataGridViewX2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrTiaoshiguanli";
            this.Text = "FrTiaoshiguanli";
            this.Load += new System.EventHandler(this.FrTiaoshiguanli_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX2)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 确认完成ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn 项目主管;
        private System.Windows.Forms.DataGridViewTextBoxColumn 工作令号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 项目名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 设备名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 数量;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn 设备预计结束时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 时间;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 调试确认;
    }
}