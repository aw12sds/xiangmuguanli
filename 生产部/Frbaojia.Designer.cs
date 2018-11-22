namespace 项目管理系统.生产部
{
    partial class Frbaojia
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtRengong = new DevExpress.XtraEditors.TextEdit();
            this.txtShijian = new DevExpress.XtraEditors.TextEdit();
            this.txtHaocai = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTijiao = new DevExpress.XtraEditors.SimpleButton();
            this.txtFujian = new System.Windows.Forms.RichTextBox();
            this.btn_shangchuan = new DevExpress.XtraEditors.SimpleButton();
            this.txtGongji = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtRengong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShijian.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHaocai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGongji.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "人工数（500/天）：";
            // 
            // txtRengong
            // 
            this.txtRengong.Location = new System.Drawing.Point(208, 41);
            this.txtRengong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRengong.Name = "txtRengong";
            this.txtRengong.Size = new System.Drawing.Size(114, 24);
            this.txtRengong.TabIndex = 1;
            this.txtRengong.TextChanged += new System.EventHandler(this.txtRengong_TextChanged);
            this.txtRengong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRengong_KeyPress);
            // 
            // txtShijian
            // 
            this.txtShijian.Location = new System.Drawing.Point(208, 102);
            this.txtShijian.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtShijian.Name = "txtShijian";
            this.txtShijian.Size = new System.Drawing.Size(114, 24);
            this.txtShijian.TabIndex = 2;
            this.txtShijian.TextChanged += new System.EventHandler(this.txtShijian_TextChanged);
            this.txtShijian.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtShijian_KeyPress);
            // 
            // txtHaocai
            // 
            this.txtHaocai.Location = new System.Drawing.Point(208, 159);
            this.txtHaocai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHaocai.Name = "txtHaocai";
            this.txtHaocai.Size = new System.Drawing.Size(114, 24);
            this.txtHaocai.TabIndex = 3;
            this.txtHaocai.TextChanged += new System.EventHandler(this.txtHaocai_TextChanged);
            this.txtHaocai.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHaocai_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "检验时间数（250/小时）：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(113, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "特殊耗材：";
            // 
            // btnTijiao
            // 
            this.btnTijiao.Location = new System.Drawing.Point(152, 356);
            this.btnTijiao.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTijiao.Name = "btnTijiao";
            this.btnTijiao.Size = new System.Drawing.Size(106, 44);
            this.btnTijiao.TabIndex = 9;
            this.btnTijiao.Text = "提交";
            this.btnTijiao.Click += new System.EventHandler(this.btnTijiao_Click);
            // 
            // txtFujian
            // 
            this.txtFujian.Location = new System.Drawing.Point(208, 267);
            this.txtFujian.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFujian.Name = "txtFujian";
            this.txtFujian.ReadOnly = true;
            this.txtFujian.Size = new System.Drawing.Size(139, 52);
            this.txtFujian.TabIndex = 10;
            this.txtFujian.Text = "";
            // 
            // btn_shangchuan
            // 
            this.btn_shangchuan.Location = new System.Drawing.Point(93, 267);
            this.btn_shangchuan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_shangchuan.Name = "btn_shangchuan";
            this.btn_shangchuan.Size = new System.Drawing.Size(83, 53);
            this.btn_shangchuan.TabIndex = 11;
            this.btn_shangchuan.Text = "上传附件：";
            this.btn_shangchuan.Click += new System.EventHandler(this.btn_shangchuan_Click);
            // 
            // txtGongji
            // 
            this.txtGongji.Enabled = false;
            this.txtGongji.Location = new System.Drawing.Point(208, 221);
            this.txtGongji.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtGongji.Name = "txtGongji";
            this.txtGongji.Size = new System.Drawing.Size(114, 24);
            this.txtGongji.TabIndex = 12;
            this.txtGongji.TextChanged += new System.EventHandler(this.txtGongji_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(141, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 18);
            this.label4.TabIndex = 13;
            this.label4.Text = "共计：";
            // 
            // Frbaojia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 415);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtGongji);
            this.Controls.Add(this.btn_shangchuan);
            this.Controls.Add(this.txtFujian);
            this.Controls.Add(this.btnTijiao);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtHaocai);
            this.Controls.Add(this.txtShijian);
            this.Controls.Add(this.txtRengong);
            this.Controls.Add(this.label1);
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Frbaojia";
            this.Text = "报价";
            this.Load += new System.EventHandler(this.Frbaojia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtRengong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShijian.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHaocai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGongji.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtRengong;
        private DevExpress.XtraEditors.TextEdit txtShijian;
        private DevExpress.XtraEditors.TextEdit txtHaocai;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton btnTijiao;
        private System.Windows.Forms.RichTextBox txtFujian;
        private DevExpress.XtraEditors.SimpleButton btn_shangchuan;
        private DevExpress.XtraEditors.TextEdit txtGongji;
        private System.Windows.Forms.Label label4;
    }
}