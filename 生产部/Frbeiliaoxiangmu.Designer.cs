namespace 项目管理系统.生产部
{
    partial class Frbeiliaoxiangmu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frbeiliaoxiangmu));
            this.dataGridViewX3 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.工作令号3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.项目名称3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.时间3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.设备名称2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.设备负责人2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.制造类型3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.加工完成进度 = new DevComponents.DotNetBar.Controls.DataGridViewProgressBarXColumn();
            this.加工实际完成时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX3)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewX3
            // 
            this.dataGridViewX3.AllowUserToAddRows = false;
            this.dataGridViewX3.AllowUserToDeleteRows = false;
            this.dataGridViewX3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewX3.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX3.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.工作令号3,
            this.项目名称3,
            this.时间3,
            this.设备名称2,
            this.设备负责人2,
            this.制造类型3,
            this.加工完成进度,
            this.加工实际完成时间});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX3.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewX3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX3.EnableHeadersVisualStyles = false;
            this.dataGridViewX3.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX3.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX3.Name = "dataGridViewX3";
            this.dataGridViewX3.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX3.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX3.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewX3.RowTemplate.Height = 27;
            this.dataGridViewX3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX3.Size = new System.Drawing.Size(1435, 926);
            this.dataGridViewX3.TabIndex = 41;
            this.dataGridViewX3.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX3_CellDoubleClick);
            this.dataGridViewX3.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridViewX3_CellPainting);
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn7.HeaderText = "id";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // 工作令号3
            // 
            this.工作令号3.DataPropertyName = "工作令号";
            this.工作令号3.HeaderText = "工作令号";
            this.工作令号3.Name = "工作令号3";
            this.工作令号3.ReadOnly = true;
            this.工作令号3.Visible = false;
            // 
            // 项目名称3
            // 
            this.项目名称3.DataPropertyName = "项目名称";
            this.项目名称3.HeaderText = "项目名称";
            this.项目名称3.Name = "项目名称3";
            this.项目名称3.ReadOnly = true;
            this.项目名称3.Visible = false;
            // 
            // 时间3
            // 
            this.时间3.DataPropertyName = "时间";
            this.时间3.HeaderText = "时间";
            this.时间3.Name = "时间3";
            this.时间3.ReadOnly = true;
            this.时间3.Visible = false;
            // 
            // 设备名称2
            // 
            this.设备名称2.DataPropertyName = "设备名称";
            this.设备名称2.HeaderText = "设备名称";
            this.设备名称2.Name = "设备名称2";
            this.设备名称2.ReadOnly = true;
            // 
            // 设备负责人2
            // 
            this.设备负责人2.DataPropertyName = "设备负责人";
            this.设备负责人2.HeaderText = "设备负责人";
            this.设备负责人2.Name = "设备负责人2";
            this.设备负责人2.ReadOnly = true;
            // 
            // 制造类型3
            // 
            this.制造类型3.DataPropertyName = "制造类型";
            this.制造类型3.HeaderText = "制造类型";
            this.制造类型3.Name = "制造类型3";
            this.制造类型3.ReadOnly = true;
            // 
            // 加工完成进度
            // 
            this.加工完成进度.DataPropertyName = "加工完成进度";
            this.加工完成进度.HeaderText = "加工完成进度";
            this.加工完成进度.Name = "加工完成进度";
            this.加工完成进度.ReadOnly = true;
            this.加工完成进度.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.加工完成进度.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.加工完成进度.Text = null;
            // 
            // 加工实际完成时间
            // 
            this.加工实际完成时间.DataPropertyName = "加工完成时间";
            this.加工实际完成时间.HeaderText = "加工实际完成时间";
            this.加工实际完成时间.Name = "加工实际完成时间";
            this.加工实际完成时间.ReadOnly = true;
            // 
            // Frbeiliaoxiangmu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1435, 926);
            this.Controls.Add(this.dataGridViewX3);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frbeiliaoxiangmu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "备料项目";
            this.Load += new System.EventHandler(this.Frbeiliaoxiangmu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn 工作令号3;
        private System.Windows.Forms.DataGridViewTextBoxColumn 项目名称3;
        private System.Windows.Forms.DataGridViewTextBoxColumn 时间3;
        private System.Windows.Forms.DataGridViewTextBoxColumn 设备名称2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 设备负责人2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 制造类型3;
        private DevComponents.DotNetBar.Controls.DataGridViewProgressBarXColumn 加工完成进度;
        private System.Windows.Forms.DataGridViewTextBoxColumn 加工实际完成时间;
    }
}