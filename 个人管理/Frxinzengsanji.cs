using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace 项目管理系统.个人管理
{
    public partial class Frxinzengsanji : DevExpress.XtraEditors.XtraForm
    {
        public Frxinzengsanji()
        {
            InitializeComponent();
        }

        private void Frxinzengsanji_Load(object sender, EventArgs e)
        {
            string sql = "select * from tb_erpsecond ";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

            List<string> spaceminute1 = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                string n = dt.Rows[i]["二级"].ToString();
                spaceminute1.Add(n);

            }
            foreach (string s in spaceminute1)
            {
                comboBoxEdit3.Properties.Items.Add(s);

            }
        }

        private void comboBoxEdit3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(comboBoxEdit3.Text.Trim()=="")
            {
                MessageBox.Show("请先选择二级名称！");
                return;
                
            }
            if (txtguobiao.Text.Trim() == "")
            {
                MessageBox.Show("请输入三级名称！");
                return;

            }

            string sql = "select * from tb_erpthird where 三级='" + comboBoxEdit3.Text + "'";
            DataTable dtttt = SQLhelp.GetDataTable(sql, CommandType.Text);
            if (dtttt.Rows.Count > 0)
            {
                MessageBox.Show("该三级名称已存在！");
                return;
            }

            string sql111 = "insert into tb_erpthird (三级,关联二级) values ('" + comboBoxEdit3.Text + "','" + txtguobiao.Text.Trim() + "')  ";
            SQLhelp.ExecuteScalar(sql, CommandType.Text);
            MessageBox.Show("生成成功！");

        }
    }
}