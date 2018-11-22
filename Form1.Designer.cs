namespace 项目管理系统
{
    partial class Form1
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
            this.dataGridViewX2 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.采购员 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ERP号码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.工作令号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.下单日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.申请号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.合同编号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.客户单位 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.联系人 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.规格 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.单位 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.数量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.供应商 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.交货日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.实际交货日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.发货数量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewX2
            // 
            this.dataGridViewX2.AllowUserToAddRows = false;
            this.dataGridViewX2.AllowUserToDeleteRows = false;
            this.dataGridViewX2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewX2.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.采购员,
            this.ERP号码,
            this.工作令号,
            this.下单日期,
            this.申请号,
            this.合同编号,
            this.客户单位,
            this.联系人,
            this.名称,
            this.规格,
            this.单位,
            this.数量,
            this.供应商,
            this.交货日期,
            this.实际交货日期,
            this.发货数量});
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
            this.dataGridViewX2.Size = new System.Drawing.Size(282, 253);
            this.dataGridViewX2.TabIndex = 42;
            // 
            // 采购员
            // 
            this.采购员.DataPropertyName = "采购员";
            this.采购员.HeaderText = "采购员";
            this.采购员.Name = "采购员";
            this.采购员.ReadOnly = true;
            // 
            // ERP号码
            // 
            this.ERP号码.DataPropertyName = "ERP号码";
            this.ERP号码.HeaderText = "ERP号码";
            this.ERP号码.Name = "ERP号码";
            this.ERP号码.ReadOnly = true;
            // 
            // 工作令号
            // 
            this.工作令号.DataPropertyName = "工作令号";
            this.工作令号.HeaderText = "工作令号";
            this.工作令号.Name = "工作令号";
            this.工作令号.ReadOnly = true;
            // 
            // 下单日期
            // 
            this.下单日期.DataPropertyName = "下单日期";
            this.下单日期.HeaderText = "下单日期";
            this.下单日期.Name = "下单日期";
            this.下单日期.ReadOnly = true;
            // 
            // 申请号
            // 
            this.申请号.DataPropertyName = "申请号";
            this.申请号.HeaderText = "申请号";
            this.申请号.Name = "申请号";
            this.申请号.ReadOnly = true;
            // 
            // 合同编号
            // 
            this.合同编号.DataPropertyName = "合同编号";
            this.合同编号.HeaderText = "合同编号";
            this.合同编号.Name = "合同编号";
            this.合同编号.ReadOnly = true;
            // 
            // 客户单位
            // 
            this.客户单位.DataPropertyName = "客户单位";
            this.客户单位.HeaderText = "客户单位";
            this.客户单位.Name = "客户单位";
            this.客户单位.ReadOnly = true;
            // 
            // 联系人
            // 
            this.联系人.DataPropertyName = "联系人";
            this.联系人.HeaderText = "联系人";
            this.联系人.Name = "联系人";
            this.联系人.ReadOnly = true;
            // 
            // 名称
            // 
            this.名称.DataPropertyName = "名称";
            this.名称.HeaderText = "名称";
            this.名称.Name = "名称";
            this.名称.ReadOnly = true;
            // 
            // 规格
            // 
            this.规格.DataPropertyName = "规格";
            this.规格.HeaderText = "规格";
            this.规格.Name = "规格";
            this.规格.ReadOnly = true;
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
            // 供应商
            // 
            this.供应商.DataPropertyName = "供应商";
            this.供应商.HeaderText = "供应商";
            this.供应商.Name = "供应商";
            this.供应商.ReadOnly = true;
            // 
            // 交货日期
            // 
            this.交货日期.DataPropertyName = "交货日期";
            this.交货日期.HeaderText = "交货日期";
            this.交货日期.Name = "交货日期";
            this.交货日期.ReadOnly = true;
            // 
            // 实际交货日期
            // 
            this.实际交货日期.DataPropertyName = "实际交货日期";
            this.实际交货日期.HeaderText = "实际交货日期";
            this.实际交货日期.Name = "实际交货日期";
            this.实际交货日期.ReadOnly = true;
            // 
            // 发货数量
            // 
            this.发货数量.DataPropertyName = "发货数量";
            this.发货数量.HeaderText = "发货数量";
            this.发货数量.Name = "发货数量";
            this.发货数量.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.dataGridViewX2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 采购员;
        private System.Windows.Forms.DataGridViewTextBoxColumn ERP号码;
        private System.Windows.Forms.DataGridViewTextBoxColumn 工作令号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 下单日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn 申请号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 合同编号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 客户单位;
        private System.Windows.Forms.DataGridViewTextBoxColumn 联系人;
        private System.Windows.Forms.DataGridViewTextBoxColumn 名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 规格;
        private System.Windows.Forms.DataGridViewTextBoxColumn 单位;
        private System.Windows.Forms.DataGridViewTextBoxColumn 数量;
        private System.Windows.Forms.DataGridViewTextBoxColumn 供应商;
        private System.Windows.Forms.DataGridViewTextBoxColumn 交货日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn 实际交货日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn 发货数量;
    }
}