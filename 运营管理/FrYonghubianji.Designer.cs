namespace 项目管理系统.运营管理
{
    partial class FrYonghubianji
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrYonghubianji));
            this.txtAffirmPassword = new System.Windows.Forms.TextBox();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.combumen = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOperatorName = new System.Windows.Forms.TextBox();
            this.lb1 = new System.Windows.Forms.Label();
            this.comjibie = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtAffirmPassword
            // 
            this.txtAffirmPassword.Location = new System.Drawing.Point(161, 179);
            this.txtAffirmPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtAffirmPassword.MaxLength = 9;
            this.txtAffirmPassword.Name = "txtAffirmPassword";
            this.txtAffirmPassword.PasswordChar = '*';
            this.txtAffirmPassword.Size = new System.Drawing.Size(197, 25);
            this.txtAffirmPassword.TabIndex = 72;
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonX2.Location = new System.Drawing.Point(389, 269);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(84, 39);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 70;
            this.buttonX2.Text = "取消";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(223, 269);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(88, 39);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 69;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // combumen
            // 
            this.combumen.DisplayMember = "Text";
            this.combumen.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combumen.FormattingEnabled = true;
            this.combumen.ItemHeight = 19;
            this.combumen.Location = new System.Drawing.Point(501, 49);
            this.combumen.Name = "combumen";
            this.combumen.Size = new System.Drawing.Size(121, 25);
            this.combumen.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.combumen.TabIndex = 68;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(417, 52);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 67;
            this.label3.Text = "所属部门:";
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 189);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 65;
            this.label1.Text = "确认密码:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(161, 115);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.MaxLength = 9;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(197, 25);
            this.txtPassword.TabIndex = 63;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 125);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 64;
            this.label2.Text = "操作密码:";
            // 
            // txtOperatorName
            // 
            this.txtOperatorName.Location = new System.Drawing.Point(161, 49);
            this.txtOperatorName.Margin = new System.Windows.Forms.Padding(4);
            this.txtOperatorName.MaxLength = 50;
            this.txtOperatorName.Name = "txtOperatorName";
            this.txtOperatorName.Size = new System.Drawing.Size(197, 25);
            this.txtOperatorName.TabIndex = 61;
            // 
            // lb1
            // 
            this.lb1.AutoSize = true;
            this.lb1.Location = new System.Drawing.Point(80, 53);
            this.lb1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(60, 15);
            this.lb1.TabIndex = 62;
            this.lb1.Text = "用户名:";
            // 
            // comjibie
            // 
            this.comjibie.DisplayMember = "Text";
            this.comjibie.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comjibie.FormattingEnabled = true;
            this.comjibie.ItemHeight = 19;
            this.comjibie.Location = new System.Drawing.Point(501, 115);
            this.comjibie.Name = "comjibie";
            this.comjibie.Size = new System.Drawing.Size(121, 25);
            this.comjibie.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comjibie.TabIndex = 74;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(417, 118);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 15);
            this.label4.TabIndex = 73;
            this.label4.Text = "级别:";
            // 
            // FrYonghubianji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 345);
            this.Controls.Add(this.comjibie);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAffirmPassword);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.combumen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOperatorName);
            this.Controls.Add(this.lb1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrYonghubianji";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户编辑";
            this.Load += new System.EventHandler(this.FrYonghubianji_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtAffirmPassword;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.Controls.ComboBoxEx combumen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOperatorName;
        private System.Windows.Forms.Label lb1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comjibie;
        private System.Windows.Forms.Label label4;
    }
}