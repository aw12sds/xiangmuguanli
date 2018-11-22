using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.生产部
{
    public partial class Frjixiujianxinjian : Office2007Form
    {
        public Frjixiujianxinjian()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }
        public string yonghu;
        private void Frjixiujianxinjian_Load(object sender, EventArgs e)
        {
            string sql1 = "select 部门 from tb_bumen";
            DataTable aaaa = SQLhelp.GetDataTable(sql1, CommandType.Text);


            List<string> spaceminute = new List<string>();
            for (int i = 0; i < aaaa.Rows.Count; i++)
            {
                if (aaaa.Rows[i]["部门"].ToString() == "物流部")
                {

                    string sql12 = "select 用户名 from tb_operator1 where 部门='物流部'";
                    DataTable b = SQLhelp.GetDataTable(sql12, CommandType.Text);
                    for (int j = 0; j < b.Rows.Count; j++)
                    {
                        string n = b.Rows[j]["用户名"].ToString();
                        spaceminute.Add(n);
                    }
                }

                if (aaaa.Rows[i]["部门"].ToString() == "精工事业部")
                {

                    string sql12 = "select 用户名 from tb_operator1 where 部门='精工事业部'";
                    DataTable b = SQLhelp.GetDataTable(sql12, CommandType.Text);
                    for (int j = 0; j < b.Rows.Count; j++)
                    {
                        string n = b.Rows[j]["用户名"].ToString();
                        spaceminute.Add(n);
                    }
                }

                if (aaaa.Rows[i]["部门"].ToString() == "仓库")
                {

                    string sql12 = "select 用户名 from tb_operator1 where 部门='仓库'";
                    DataTable b = SQLhelp.GetDataTable(sql12, CommandType.Text);
                    for (int j = 0; j < b.Rows.Count; j++)
                    {
                        string n = b.Rows[j]["用户名"].ToString();
                        spaceminute.Add(n);
                    }
                }
                
            }


            foreach (string s in spaceminute)
            {
                txtzerenren.Items.Add(s);
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if(comleixing.Text=="")
            {
                MessageBox.Show("请选择加工类型！");
                return;

            }

            if (datewanchengriqi.Text == "")
            {
                MessageBox.Show("请选择要求完成日期！");
                return;

            }

            if (txtzerenren.Text == "")
            {
                MessageBox.Show("请选择责任人！");
                return;

            }

            if (txtzerenbumen.Text == "")
            {
                MessageBox.Show("请选择责任部门！");
                return;

            }

            string sql = "insert into tb_jixiujian (加工单位,序号,编码,图号,名称,单套数量,加工数量,加工类型,下料,粗加工,热处理,精加工,镀涂油漆,责任人,设备名称,计划单号,工作令号,下单日期,要求完成日期,颜色,责任部门,完成情况) values('"+comleixing.Text.Trim()+ "','" + txtxuhao.Text.Trim() + "','" + txtbianma.Text.Trim() + "','" + txttuhao.Text.Trim() + "','" + txtmingcheng.Text.Trim() + "','" + txtdantaoshuliang.Text.Trim() + "','" +txtjiagongshuliang.Text.Trim() + "','" + txtjiagongleixing.Text.Trim() + "','" + txtxialiao.Text.Trim() + "','" + txtcujiagong.Text.Trim() + "','" + txtrechuli.Text.Trim() + "','" + txtjingjiagong.Text.Trim() + "','" + txtdutuyouqi.Text.Trim() + "','" + txtzerenren.Text.Trim() + "','" + txtshebeimingcheng.Text.Trim() + "','" + txtjihuadanhao.Text.Trim() + "','" + txtgonglinghao.Text.Trim() + "','" + DateTime.Now + "','" + datewanchengriqi.Text + "','" + txtyanse.Text.Trim() + "','" + txtzerenbumen.Text.Trim() + "',0)";
            SQLhelp.ExecuteScalar(sql, CommandType.Text);
            this.DialogResult = DialogResult.OK;
            MessageBox.Show("提交成功！");
            this.Close();
            
        }
    }
}
