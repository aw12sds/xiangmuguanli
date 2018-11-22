using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.运营管理
{
    public partial class FrYonghubianji : Office2007Form
    {
        public FrYonghubianji()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }
        public string leixing;
        public string yonghu;

        private void FrYonghubianji_Load(object sender, EventArgs e)
        {
            if (leixing == "Edit")
            {
                txtOperatorName.Text = yonghu;

                txtOperatorName.Enabled = false;
            }




            string sql = "select 部门 from tb_bumen";
            DataTable aaaa = SQLhelp.GetDataTable(sql, CommandType.Text);

            txtOperatorName.Text = yonghu;
            List<string> spaceminute = new List<string>();
            for (int i = 0; i < aaaa.Rows.Count; i++)
            {

                string n = aaaa.Rows[i]["部门"].ToString();
                spaceminute.Add(n);
            }


            foreach (string s in spaceminute)
            {
                combumen.Items.Add(s);
            }


            string sql1= "select 职位 from tb_zhiwei";
            DataTable zhiwei = SQLhelp.GetDataTable(sql1, CommandType.Text);

            
            List<string> spaceminute1 = new List<string>();
            for (int i = 0; i < zhiwei.Rows.Count; i++)
            {

                string n = zhiwei.Rows[i]["职位"].ToString();
                spaceminute1.Add(n);
            }


            foreach (string s in spaceminute1)
            {
                comjibie.Items.Add(s);
            }

            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtOperatorName.Text.Trim()))
            {
                MessageBox.Show("操作名称不许为空！", "软件提示");
                txtOperatorName.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("操作密码不许为空！", "软件提示");
                txtPassword.Focus();
                return;
            }
            if (!(txtPassword.Text == txtAffirmPassword.Text))
            {
                MessageBox.Show("确认密码与操作密码不相同！", "软件提示");
                txtAffirmPassword.Focus();
                return;
            }
            if (combumen.SelectedIndex == -1)
            {
                MessageBox.Show("请选择部门！", "软件提示");
                txtPassword.Focus();
                return;
            }
            if (comjibie.SelectedIndex == -1)
            {
                MessageBox.Show("请选择职位！", "软件提示");
                txtPassword.Focus();
                return;
            }
            if (leixing == "Add")
            {
                
                if (txtPassword.Text == txtAffirmPassword.Text)
                {
                    string strSql11 = "select 用户名 from tb_operator  where  用户名='" + txtOperatorName.Text.Trim() + "' ";
                    string result = Convert.ToString(SQLhelp.ExecuteScalar(strSql11, CommandType.Text));
                    if (result != "")
                    {
                        MessageBox.Show("该账号已存在！");
                        txtOperatorName.Focus();

                        return;
                    }

                    string strSql = string.Format(@"insert into tb_operator(用户名,密码,部门,级别) values('{0}','{1}','{2}','{3}')", txtOperatorName.Text, txtPassword.Text, combumen.Text,comjibie.Text);

                    if (MessageBox.Show("确认添加吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        string aa = Convert.ToString(SQLhelp.ExecuteScalar(strSql, CommandType.Text));
                        MessageBox.Show("保存成功！", "软件提示");
                        this.DialogResult = DialogResult.OK;
                        this.Close();

                    }
                    else
                    {

                        MessageBox.Show("保存失败！", "软件提示");
                        txtOperatorName.SelectAll();
                        txtOperatorName.Focus();

                    }
                }
                else
                {
                    MessageBox.Show("两次输入密码不同！");
                    txtPassword.Focus();
                    return;


                }
            }
            if (leixing == "Edit")
            {


                if (txtPassword.Text == txtAffirmPassword.Text)
                {

                    string strSql1 = "update tb_operator set 用户名= '" + txtOperatorName.Text + "' ,密码= " + txtPassword.Text + ",部门= '" + combumen.Text + "' ,级别= '" + comjibie.Text + "' where 用户名='" + yonghu + "'";

                    if (MessageBox.Show("确认修改吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        string aa = Convert.ToString(SQLhelp.ExecuteScalar(strSql1, CommandType.Text));
                        MessageBox.Show("保存成功！", "软件提示");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("保存失败！", "软件提示");
                        txtOperatorName.SelectAll();
                        txtOperatorName.Focus();

                    }
                }
                else
                {
                    MessageBox.Show("两次输入密码不同！");
                    txtPassword.Focus();
                    return;
                }
            }
        }
    }
}
