namespace 项目管理系统.质监部
{
    partial class Frtuihuiyuanyin
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
            this.txtneirong = new System.Windows.Forms.RichTextBox();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // txtneirong
            // 
            this.txtneirong.Location = new System.Drawing.Point(59, 29);
            this.txtneirong.Name = "txtneirong";
            this.txtneirong.Size = new System.Drawing.Size(361, 195);
            this.txtneirong.TabIndex = 0;
            this.txtneirong.Text = "";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(185, 275);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(96, 45);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "提交";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // Frtuihuiyuanyin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 357);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.txtneirong);
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "Frtuihuiyuanyin";
            this.Text = "退回原因";
            this.Load += new System.EventHandler(this.Frtuihuiyuanyin_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtneirong;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}