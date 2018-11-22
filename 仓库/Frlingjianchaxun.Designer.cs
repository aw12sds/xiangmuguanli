namespace 项目管理系统.仓库
{
    partial class Frlingjianchaxun
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.textBoxItem1 = new DevComponents.DotNetBar.TextBoxItem();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.id1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.设备负责人1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.工作令号1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.项目名称1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.设备名称1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.数量1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.设备预计结束时间1 = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.时间1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.生产部确认1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bar1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(879, 27);
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
            this.textBoxItem1,
            this.buttonItem1});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(879, 27);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 0;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // textBoxItem1
            // 
            this.textBoxItem1.Name = "textBoxItem1";
            this.textBoxItem1.WatermarkColor = System.Drawing.SystemColors.GrayText;
            // 
            // buttonItem1
            // 
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "buttonItem1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridViewX1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(879, 534);
            this.panel2.TabIndex = 1;
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewX1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewX1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewX1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id1,
            this.设备负责人1,
            this.工作令号1,
            this.项目名称1,
            this.设备名称1,
            this.数量1,
            this.设备预计结束时间1,
            this.时间1,
            this.生产部确认1});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewX1.RowTemplate.Height = 27;
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(879, 534);
            this.dataGridViewX1.TabIndex = 46;
            // 
            // id1
            // 
            this.id1.DataPropertyName = "id";
            this.id1.HeaderText = "id";
            this.id1.Name = "id1";
            this.id1.ReadOnly = true;
            this.id1.Visible = false;
            // 
            // 设备负责人1
            // 
            this.设备负责人1.DataPropertyName = "设备负责人";
            this.设备负责人1.HeaderText = "负责人";
            this.设备负责人1.Name = "设备负责人1";
            this.设备负责人1.ReadOnly = true;
            // 
            // 工作令号1
            // 
            this.工作令号1.DataPropertyName = "工作令号";
            this.工作令号1.HeaderText = "工作令号";
            this.工作令号1.Name = "工作令号1";
            this.工作令号1.ReadOnly = true;
            // 
            // 项目名称1
            // 
            this.项目名称1.DataPropertyName = "项目名称";
            this.项目名称1.HeaderText = "项目名称";
            this.项目名称1.Name = "项目名称1";
            this.项目名称1.ReadOnly = true;
            // 
            // 设备名称1
            // 
            this.设备名称1.DataPropertyName = "设备名称";
            this.设备名称1.HeaderText = "设备名称";
            this.设备名称1.Name = "设备名称1";
            this.设备名称1.ReadOnly = true;
            // 
            // 数量1
            // 
            this.数量1.DataPropertyName = "数量";
            this.数量1.HeaderText = "数量";
            this.数量1.Name = "数量1";
            this.数量1.ReadOnly = true;
            // 
            // 设备预计结束时间1
            // 
            // 
            // 
            // 
            this.设备预计结束时间1.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.设备预计结束时间1.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.设备预计结束时间1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.设备预计结束时间1.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText;
            this.设备预计结束时间1.ButtonDropDown.Visible = true;
            this.设备预计结束时间1.CustomFormat = "yyyy-MM-dd HH:mm";
            this.设备预计结束时间1.DataPropertyName = "设备预计结束时间";
            this.设备预计结束时间1.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.设备预计结束时间1.HeaderText = "设备预计结束时间";
            this.设备预计结束时间1.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            // 
            // 
            // 
            // 
            // 
            // 
            this.设备预计结束时间1.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.设备预计结束时间1.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            // 
            // 
            // 
            this.设备预计结束时间1.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.设备预计结束时间1.MonthCalendar.DisplayMonth = new System.DateTime(2018, 2, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.设备预计结束时间1.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.设备预计结束时间1.Name = "设备预计结束时间1";
            this.设备预计结束时间1.ReadOnly = true;
            this.设备预计结束时间1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.设备预计结束时间1.Visible = false;
            // 
            // 时间1
            // 
            this.时间1.DataPropertyName = "时间";
            this.时间1.HeaderText = "时间";
            this.时间1.Name = "时间1";
            this.时间1.ReadOnly = true;
            this.时间1.Visible = false;
            // 
            // 生产部确认1
            // 
            this.生产部确认1.DataPropertyName = "生产部确认";
            this.生产部确认1.FalseValue = "0";
            this.生产部确认1.HeaderText = "生产部确认";
            this.生产部确认1.Name = "生产部确认1";
            this.生产部确认1.ReadOnly = true;
            this.生产部确认1.TrueValue = "1";
            this.生产部确认1.Visible = false;
            // 
            // Frlingjianchaxun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 561);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Frlingjianchaxun";
            this.Text = "Frlingjianchaxun";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.TextBoxItem textBoxItem1;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 设备负责人1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 工作令号1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 项目名称1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 设备名称1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 数量1;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn 设备预计结束时间1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 时间1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 生产部确认1;
    }
}