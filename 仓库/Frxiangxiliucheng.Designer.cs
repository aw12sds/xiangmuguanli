﻿namespace 项目管理系统.仓库
{
    partial class Frxiangxiliucheng
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frxiangxiliucheng));
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.查看附件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.附件类型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.流程标记 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.流程类型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.创建人 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.创建时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.流程内容 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.附件名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.工作令号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.项目名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.设备名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.id,
            this.附件类型,
            this.流程标记,
            this.流程类型,
            this.创建人,
            this.创建时间,
            this.流程内容,
            this.附件名称,
            this.工作令号,
            this.项目名称,
            this.设备名称,
            this.时间});
            this.dataGridViewX1.ContextMenuStrip = this.contextMenuStrip1;
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
            this.dataGridViewX1.Size = new System.Drawing.Size(861, 528);
            this.dataGridViewX1.TabIndex = 48;
            this.dataGridViewX1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridViewX1_CellPainting);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看附件ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(145, 30);
            // 
            // 查看附件ToolStripMenuItem
            // 
            this.查看附件ToolStripMenuItem.Name = "查看附件ToolStripMenuItem";
            this.查看附件ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.查看附件ToolStripMenuItem.Text = "查看附件";
            this.查看附件ToolStripMenuItem.Click += new System.EventHandler(this.查看附件ToolStripMenuItem_Click);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // 附件类型
            // 
            this.附件类型.DataPropertyName = "附件类型";
            this.附件类型.HeaderText = "附件类型";
            this.附件类型.Name = "附件类型";
            this.附件类型.ReadOnly = true;
            this.附件类型.Visible = false;
            // 
            // 流程标记
            // 
            this.流程标记.DataPropertyName = "流程标记";
            this.流程标记.HeaderText = "流程标记";
            this.流程标记.Name = "流程标记";
            this.流程标记.ReadOnly = true;
            this.流程标记.Visible = false;
            // 
            // 流程类型
            // 
            this.流程类型.DataPropertyName = "流程类型";
            this.流程类型.HeaderText = "流程类型";
            this.流程类型.Name = "流程类型";
            this.流程类型.ReadOnly = true;
            this.流程类型.Visible = false;
            // 
            // 创建人
            // 
            this.创建人.DataPropertyName = "创建人";
            this.创建人.HeaderText = "创建人";
            this.创建人.Name = "创建人";
            this.创建人.ReadOnly = true;
            // 
            // 创建时间
            // 
            this.创建时间.DataPropertyName = "创建时间";
            this.创建时间.HeaderText = "创建时间";
            this.创建时间.Name = "创建时间";
            this.创建时间.ReadOnly = true;
            // 
            // 流程内容
            // 
            this.流程内容.DataPropertyName = "流程内容";
            this.流程内容.HeaderText = "流程内容";
            this.流程内容.Name = "流程内容";
            this.流程内容.ReadOnly = true;
            // 
            // 附件名称
            // 
            this.附件名称.DataPropertyName = "附件名称";
            this.附件名称.HeaderText = "附件名称";
            this.附件名称.Name = "附件名称";
            this.附件名称.ReadOnly = true;
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
            // 时间
            // 
            this.时间.DataPropertyName = "时间";
            this.时间.HeaderText = "时间";
            this.时间.Name = "时间";
            this.时间.ReadOnly = true;
            this.时间.Visible = false;
            // 
            // Frxiangxiliucheng
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 528);
            this.Controls.Add(this.dataGridViewX1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frxiangxiliucheng";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "详细流程";
            this.Load += new System.EventHandler(this.Frxiangxiliucheng_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 查看附件ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn 附件类型;
        private System.Windows.Forms.DataGridViewTextBoxColumn 流程标记;
        private System.Windows.Forms.DataGridViewTextBoxColumn 流程类型;
        private System.Windows.Forms.DataGridViewTextBoxColumn 创建人;
        private System.Windows.Forms.DataGridViewTextBoxColumn 创建时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 流程内容;
        private System.Windows.Forms.DataGridViewTextBoxColumn 附件名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 工作令号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 项目名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 设备名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 时间;
    }
}