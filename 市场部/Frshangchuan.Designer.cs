namespace 项目管理系统.市场部
{
    partial class Frshangchuan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frshangchuan));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtxiangmumingcheng = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.txtxiangmumingchengmiaoshu = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
            this.txtlianxidianhua = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtxiangmumingcheng.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtlianxidianhua.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "项目描述：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "项目名称：";
            // 
            // txtxiangmumingcheng
            // 
            this.txtxiangmumingcheng.Location = new System.Drawing.Point(131, 41);
            this.txtxiangmumingcheng.Name = "txtxiangmumingcheng";
            this.txtxiangmumingcheng.Size = new System.Drawing.Size(207, 24);
            this.txtxiangmumingcheng.TabIndex = 3;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(445, 140);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(107, 37);
            this.simpleButton1.TabIndex = 4;
            this.simpleButton1.Text = "上传项目";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // txtxiangmumingchengmiaoshu
            // 
            // 
            // 
            // 
            this.txtxiangmumingchengmiaoshu.BackgroundStyle.Class = "RichTextBoxBorder";
            this.txtxiangmumingchengmiaoshu.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtxiangmumingchengmiaoshu.Location = new System.Drawing.Point(131, 98);
            this.txtxiangmumingchengmiaoshu.Name = "txtxiangmumingchengmiaoshu";
            this.txtxiangmumingchengmiaoshu.Rtf = "{\\rtf1\\ansi\\ansicpg936\\deff0\\deflang1033\\deflangfe2052{\\fonttbl{\\f0\\fnil\\fcharset" +
    "0 Tahoma;}}\r\n{\\colortbl ;\\red32\\green31\\blue53;}\r\n\\viewkind4\\uc1\\pard\\cf1\\lang20" +
    "52\\f0\\fs18\\par\r\n}\r\n";
            this.txtxiangmumingchengmiaoshu.Size = new System.Drawing.Size(207, 142);
            this.txtxiangmumingchengmiaoshu.TabIndex = 5;
            // 
            // txtlianxidianhua
            // 
            this.txtlianxidianhua.Location = new System.Drawing.Point(445, 41);
            this.txtlianxidianhua.Name = "txtlianxidianhua";
            this.txtlianxidianhua.Size = new System.Drawing.Size(207, 24);
            this.txtlianxidianhua.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(356, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "联系电话：";
            // 
            // Frshangchuan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 273);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtlianxidianhua);
            this.Controls.Add(this.txtxiangmumingchengmiaoshu);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.txtxiangmumingcheng);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "Frshangchuan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "项目上传";
            this.Load += new System.EventHandler(this.Frshangchuan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtxiangmumingcheng.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtlianxidianhua.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtxiangmumingcheng;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevComponents.DotNetBar.Controls.RichTextBoxEx txtxiangmumingchengmiaoshu;
        private DevExpress.XtraEditors.TextEdit txtlianxidianhua;
        private System.Windows.Forms.Label label3;
    }
}