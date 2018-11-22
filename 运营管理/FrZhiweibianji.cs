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
    public partial class FrZhiweibianji : Office2007Form
    {
        public FrZhiweibianji()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }

        private void FrZhiweibianji_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtOperatorName.Text.Trim()))
            {
                MessageBox.Show("职位名称不许为空！", "软件提示");
                txtOperatorName.Focus();
                return;
            }


            string strSql = string.Format(@"insert into tb_zhiwei(职位) values('{0}')", txtOperatorName.Text);

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

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
