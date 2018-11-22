namespace 项目管理系统.质监部
{
    partial class Frfujian
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
            this.btnTijiao = new DevExpress.XtraEditors.SimpleButton();
            this.btnShangchuan = new DevExpress.XtraEditors.SimpleButton();
            this.txtFujian = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnTijiao
            // 
            this.btnTijiao.Location = new System.Drawing.Point(197, 220);
            this.btnTijiao.Name = "btnTijiao";
            this.btnTijiao.Size = new System.Drawing.Size(120, 50);
            this.btnTijiao.TabIndex = 19;
            this.btnTijiao.Text = "提交";
            this.btnTijiao.Click += new System.EventHandler(this.btnTijiao_Click);
            // 
            // btnShangchuan
            // 
            this.btnShangchuan.Location = new System.Drawing.Point(57, 79);
            this.btnShangchuan.Name = "btnShangchuan";
            this.btnShangchuan.Size = new System.Drawing.Size(117, 24);
            this.btnShangchuan.TabIndex = 18;
            this.btnShangchuan.Text = "上传检验记录：";
            this.btnShangchuan.Click += new System.EventHandler(this.btnShangchuan_Click);
            // 
            // txtFujian
            // 
            this.txtFujian.Location = new System.Drawing.Point(197, 81);
            this.txtFujian.Name = "txtFujian";
            this.txtFujian.ReadOnly = true;
            this.txtFujian.Size = new System.Drawing.Size(233, 83);
            this.txtFujian.TabIndex = 17;
            this.txtFujian.Text = "";
            // 
            // Frfujian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 337);
            this.Controls.Add(this.btnTijiao);
            this.Controls.Add(this.btnShangchuan);
            this.Controls.Add(this.txtFujian);
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "Frfujian";
            this.Text = "Frfujian";
            this.Load += new System.EventHandler(this.Frfujian_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnTijiao;
        private DevExpress.XtraEditors.SimpleButton btnShangchuan;
        private System.Windows.Forms.RichTextBox txtFujian;
    }
}