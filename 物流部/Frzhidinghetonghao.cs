using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.物流部
{
    public partial class Frzhidinghetonghao : Office2007Form
    {
        public Frzhidinghetonghao()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string hetonghao;
        public int kaishi;
        public int jieshu;
        private void Frzhidinghetonghao_Load(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (textBoxX2.Text=="")
            {
                MessageBox.Show(" 请输入开始序号");
                return;
            }
            if (textBoxX3.Text == "")
            {
                MessageBox.Show(" 请输入结束序号");
                return;
            }
            if (Convert.ToInt32(textBoxX2.Text) >= Convert.ToInt32(textBoxX3.Text))
            {

                MessageBox.Show("开始序号不得大于结束序号");
                return;

            }

            if (Convert.ToInt32(textBoxX2.Text) < Convert.ToInt32(textBoxX3.Text))
            {

                kaishi = Convert.ToInt32(textBoxX2.Text);
                jieshu = Convert.ToInt32(textBoxX3.Text);
                hetonghao = textBoxX1.Text.Trim();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        private void textBoxX2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void textBoxX3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
