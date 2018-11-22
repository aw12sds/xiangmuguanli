namespace 项目管理系统.总经办
{
    partial class Frxiugaijiage
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
            this.label4 = new System.Windows.Forms.Label();
            this.txtGongji = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHaocai = new DevExpress.XtraEditors.TextEdit();
            this.txtShijian = new DevExpress.XtraEditors.TextEdit();
            this.txtRengong = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTijiao = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtGongji.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHaocai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShijian.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRengong.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(178, 341);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 18);
            this.label4.TabIndex = 21;
            this.label4.Text = "共计：";
            // 
            // txtGongji
            // 
            this.txtGongji.Enabled = false;
            this.txtGongji.Location = new System.Drawing.Point(245, 336);
            this.txtGongji.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtGongji.Name = "txtGongji";
            this.txtGongji.Size = new System.Drawing.Size(114, 24);
            this.txtGongji.TabIndex = 20;
            this.txtGongji.TextChanged += new System.EventHandler(this.txtGongji_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(150, 266);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 18);
            this.label3.TabIndex = 19;
            this.label3.Text = "特殊耗材：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 18);
            this.label2.TabIndex = 18;
            this.label2.Text = "检验时间数（250/小时）：";
            // 
            // txtHaocai
            // 
            this.txtHaocai.Location = new System.Drawing.Point(245, 262);
            this.txtHaocai.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtHaocai.Name = "txtHaocai";
            this.txtHaocai.Size = new System.Drawing.Size(114, 24);
            this.txtHaocai.TabIndex = 17;
            this.txtHaocai.TextChanged += new System.EventHandler(this.txtHaocai_TextChanged);
            this.txtHaocai.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHaocai_KeyPress);
            // 
            // txtShijian
            // 
            this.txtShijian.Location = new System.Drawing.Point(245, 193);
            this.txtShijian.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtShijian.Name = "txtShijian";
            this.txtShijian.Size = new System.Drawing.Size(114, 24);
            this.txtShijian.TabIndex = 16;
            this.txtShijian.TextChanged += new System.EventHandler(this.txtShijian_TextChanged);
            this.txtShijian.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtShijian_KeyPress);
            // 
            // txtRengong
            // 
            this.txtRengong.Location = new System.Drawing.Point(245, 120);
            this.txtRengong.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtRengong.Name = "txtRengong";
            this.txtRengong.Size = new System.Drawing.Size(114, 24);
            this.txtRengong.TabIndex = 15;
            this.txtRengong.TextChanged += new System.EventHandler(this.txtRengong_TextChanged);
            this.txtRengong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRengong_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 18);
            this.label1.TabIndex = 14;
            this.label1.Text = "人工数（500/天）：";
            // 
            // btnTijiao
            // 
            this.btnTijiao.Location = new System.Drawing.Point(181, 410);
            this.btnTijiao.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnTijiao.Name = "btnTijiao";
            this.btnTijiao.Size = new System.Drawing.Size(106, 53);
            this.btnTijiao.TabIndex = 22;
            this.btnTijiao.Text = "提交";
            this.btnTijiao.Click += new System.EventHandler(this.btnTijiao_Click);
            // 
            // Frxiugaijiage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 488);
            this.Controls.Add(this.btnTijiao);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtGongji);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtHaocai);
            this.Controls.Add(this.txtShijian);
            this.Controls.Add(this.txtRengong);
            this.Controls.Add(this.label1);
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Frxiugaijiage";
            this.Text = "Frxiugaijiage";
            ((System.ComponentModel.ISupportInitialize)(this.txtGongji.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHaocai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShijian.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRengong.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txtGongji;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtHaocai;
        private DevExpress.XtraEditors.TextEdit txtShijian;
        private DevExpress.XtraEditors.TextEdit txtRengong;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnTijiao;
    }
}