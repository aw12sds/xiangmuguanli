using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.技术部
{
    public partial class FrLiaodanshezhi : Office2007Form
    {
        public FrLiaodanshezhi()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }
        public string hangshu;
        private void FrLiaodanshezhi_Load(object sender, EventArgs e)
        {

        }

        private void textBoxX1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            hangshu = textBoxX1.Text.Trim();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        
    }
}
