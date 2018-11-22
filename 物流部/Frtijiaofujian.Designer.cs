namespace 项目管理系统.物流部
{
    partial class Frtijiaofujian
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
            this.txtFujian = new System.Windows.Forms.RichTextBox();
            this.btnShangchuan = new DevExpress.XtraEditors.SimpleButton();
            this.btnTijiao = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // txtFujian
            // 
            this.txtFujian.Location = new System.Drawing.Point(198, 79);
            this.txtFujian.Name = "txtFujian";
            this.txtFujian.ReadOnly = true;
            this.txtFujian.Size = new System.Drawing.Size(200, 72);
            this.txtFujian.TabIndex = 0;
            this.txtFujian.Text = "";
            // 
            // btnShangchuan
            // 
            this.btnShangchuan.Location = new System.Drawing.Point(73, 79);
            this.btnShangchuan.Name = "btnShangchuan";
            this.btnShangchuan.Size = new System.Drawing.Size(100, 21);
            this.btnShangchuan.TabIndex = 15;
            this.btnShangchuan.Text = "上传检验记录：";
            this.btnShangchuan.Click += new System.EventHandler(this.btnShangchuan_Click);
            // 
            // btnTijiao
            // 
            this.btnTijiao.Location = new System.Drawing.Point(198, 227);
            this.btnTijiao.Name = "btnTijiao";
            this.btnTijiao.Size = new System.Drawing.Size(103, 43);
            this.btnTijiao.TabIndex = 16;
            this.btnTijiao.Text = "提交";
            this.btnTijiao.Click += new System.EventHandler(this.btnTijiao_Click);
            // 
            // Frtijiaofujian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 311);
            this.Controls.Add(this.btnTijiao);
            this.Controls.Add(this.btnShangchuan);
            this.Controls.Add(this.txtFujian);
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "Frtijiaofujian";
            this.Text = "提交附件";
            this.Load += new System.EventHandler(this.Frtijiaofujian_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtFujian;
        private DevExpress.XtraEditors.SimpleButton btnShangchuan;
        private DevExpress.XtraEditors.SimpleButton btnTijiao;
    }
}