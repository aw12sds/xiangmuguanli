using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统
{
    public partial class FrLogin : Form
    {
        public FrLogin()
        {
            InitializeComponent();
        }
        FrMain aa = new FrMain();
        private void btnDenglu_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(comboBox1.Text.Trim()))
            {
                MessageBox.Show("登录用户不许为空！", "软件提示");

                return;
            }

            if (String.IsNullOrEmpty(txtPwd.Text))
            {
                MessageBox.Show("登录密码不许为空！", "软件提示");
                txtPwd.Focus();
                return;
            }
            //用户编码不重复
            string strSql = "select * from tb_operator where 用户名 = '" + comboBox1.Text.Trim() + "'";
            if (Convert.ToString(SQLhelp.ExecuteScalar(strSql, CommandType.Text)) == "")
            {
                MessageBox.Show("登录用户不正确！", "软件提示");

                return;
            }
            try
            {

                DataTable dt = SQLhelp.GetDataTable(strSql, CommandType.Text);
                DataRow dr = dt.Rows[0];


                string a = dt.Rows[0]["用户名"].ToString(); //用户名



                if (txtPwd.Text != dt.Rows[0]["密码"].ToString())  //若密码不相同
                {
                    MessageBox.Show("登录密码不正确！", "软件提示");
                    txtPwd.Focus();
                }
                else
                {

                    this.Hide();
                    aa.yonghu = a;
                    aa.ShowDialog();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            txtPwd.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrLogin_Load(object sender, EventArgs e)
        {

            string sql = "select 用户名 from tb_operator";
            DataTable aaaa = SQLhelp.GetDataTable(sql, CommandType.Text);


            List<string> spaceminute = new List<string>();
            for (int i = 0; i < aaaa.Rows.Count; i++)
            {

                string n = aaaa.Rows[i]["用户名"].ToString();
                spaceminute.Add(n);
            }


            foreach (string s in spaceminute)
            {
                comboBox1.Items.Add(s);
            }
            comboBox1.Focus();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDenglu_Click(sender, e);
            }
        }
    }
}
