namespace 项目管理系统.个人管理
{
    partial class Frtuzhishenhe
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
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.工作令号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.项目名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.设备名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.项目负责人 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.设备负责人 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.技术指标 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.方向 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.数量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.制造类型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.设备预计结束时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.反馈 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.查看料单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.审核通过ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退回重录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX2)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewX2
            // 
            this.dataGridViewX2.AllowUserToAddRows = false;
            this.dataGridViewX2.AllowUserToDeleteRows = false;
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
            this.工作令号,
            this.项目名称,
            this.设备名称,
            this.项目负责人,
            this.设备负责人,
            this.技术指标,
            this.方向,
            this.数量,
            this.制造类型,
            this.设备预计结束时间,
            this.时间,
            this.反馈});
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
            this.dataGridViewX2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX2.Size = new System.Drawing.Size(762, 449);
            this.dataGridViewX2.TabIndex = 44;
            this.dataGridViewX2.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridViewX2_CellPainting);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // 工作令号
            // 
            this.工作令号.DataPropertyName = "工作令号";
            this.工作令号.HeaderText = "工作令号";
            this.工作令号.Name = "工作令号";
            this.工作令号.ReadOnly = true;
            this.工作令号.Width = 150;
            // 
            // 项目名称
            // 
            this.项目名称.DataPropertyName = "项目名称";
            this.项目名称.HeaderText = "项目名称";
            this.项目名称.Name = "项目名称";
            this.项目名称.ReadOnly = true;
            this.项目名称.Width = 150;
            // 
            // 设备名称
            // 
            this.设备名称.DataPropertyName = "设备名称";
            this.设备名称.HeaderText = "设备名称";
            this.设备名称.Name = "设备名称";
            this.设备名称.ReadOnly = true;
            this.设备名称.Width = 150;
            // 
            // 项目负责人
            // 
            this.项目负责人.DataPropertyName = "项目负责人";
            this.项目负责人.HeaderText = "项目负责人";
            this.项目负责人.Name = "项目负责人";
            this.项目负责人.ReadOnly = true;
            // 
            // 设备负责人
            // 
            this.设备负责人.DataPropertyName = "设备负责人";
            this.设备负责人.HeaderText = "设备负责人";
            this.设备负责人.Name = "设备负责人";
            this.设备负责人.ReadOnly = true;
            // 
            // 技术指标
            // 
            this.技术指标.DataPropertyName = "技术指标";
            this.技术指标.HeaderText = "技术指标";
            this.技术指标.Name = "技术指标";
            this.技术指标.ReadOnly = true;
            this.技术指标.Width = 400;
            // 
            // 方向
            // 
            this.方向.DataPropertyName = "方向";
            this.方向.HeaderText = "方向";
            this.方向.Name = "方向";
            this.方向.ReadOnly = true;
            this.方向.Width = 150;
            // 
            // 数量
            // 
            this.数量.DataPropertyName = "数量";
            this.数量.HeaderText = "数量";
            this.数量.Name = "数量";
            this.数量.ReadOnly = true;
            this.数量.Width = 150;
            // 
            // 制造类型
            // 
            this.制造类型.DataPropertyName = "制造类型";
            this.制造类型.HeaderText = "制造类型";
            this.制造类型.Name = "制造类型";
            this.制造类型.ReadOnly = true;
            this.制造类型.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.制造类型.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.制造类型.Width = 150;
            // 
            // 设备预计结束时间
            // 
            this.设备预计结束时间.DataPropertyName = "设备预计结束时间";
            this.设备预计结束时间.HeaderText = "设计预计结束时间";
            this.设备预计结束时间.Name = "设备预计结束时间";
            this.设备预计结束时间.ReadOnly = true;
            this.设备预计结束时间.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.设备预计结束时间.Width = 150;
            // 
            // 时间
            // 
            this.时间.DataPropertyName = "时间";
            this.时间.HeaderText = "时间";
            this.时间.Name = "时间";
            this.时间.ReadOnly = true;
            this.时间.Visible = false;
            // 
            // 反馈
            // 
            this.反馈.DataPropertyName = "技术要求反馈内容";
            this.反馈.HeaderText = "反馈";
            this.反馈.Name = "反馈";
            this.反馈.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看料单ToolStripMenuItem,
            this.审核通过ToolStripMenuItem,
            this.退回重录ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(139, 76);
            // 
            // 查看料单ToolStripMenuItem
            // 
            this.查看料单ToolStripMenuItem.Name = "查看料单ToolStripMenuItem";
            this.查看料单ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.查看料单ToolStripMenuItem.Text = "查看料单";
            this.查看料单ToolStripMenuItem.Click += new System.EventHandler(this.查看料单ToolStripMenuItem_Click);
            // 
            // 审核通过ToolStripMenuItem
            // 
            this.审核通过ToolStripMenuItem.Name = "审核通过ToolStripMenuItem";
            this.审核通过ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.审核通过ToolStripMenuItem.Text = "审核通过";
            this.审核通过ToolStripMenuItem.Click += new System.EventHandler(this.审核通过ToolStripMenuItem_Click);
            // 
            // 退回重录ToolStripMenuItem
            // 
            this.退回重录ToolStripMenuItem.Name = "退回重录ToolStripMenuItem";
            this.退回重录ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.退回重录ToolStripMenuItem.Text = "退回重录";
            this.退回重录ToolStripMenuItem.Click += new System.EventHandler(this.退回重录ToolStripMenuItem_Click);
            // 
            // Frtuzhishenhe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 449);
            this.Controls.Add(this.dataGridViewX2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frtuzhishenhe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frtuzhishenhe";
            this.Load += new System.EventHandler(this.Frtuzhishenhe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX2)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX2;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn 工作令号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 项目名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 设备名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 项目负责人;
        private System.Windows.Forms.DataGridViewTextBoxColumn 设备负责人;
        private System.Windows.Forms.DataGridViewTextBoxColumn 技术指标;
        private System.Windows.Forms.DataGridViewTextBoxColumn 方向;
        private System.Windows.Forms.DataGridViewTextBoxColumn 数量;
        private System.Windows.Forms.DataGridViewTextBoxColumn 制造类型;
        private System.Windows.Forms.DataGridViewTextBoxColumn 设备预计结束时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 反馈;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 查看料单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 审核通过ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退回重录ToolStripMenuItem;
    }
}