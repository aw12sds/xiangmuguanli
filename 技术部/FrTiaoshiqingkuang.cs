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
    public partial class FrTiaoshiqingkuang : Office2007Form
    {
        public FrTiaoshiqingkuang()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }
        public string gongzuolinghao;
        public string xiangmumingcheng;
        public string shebeimingcheng;
        public string shijian;
        public string yonghu;
        private void FrTiaoshiqingkuang_Load(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            string dangqianshijian = DateTime.Now.ToString();

            string sql = "insert into tb_tiaoshifankui  (调试反馈内容,创建时间,工作令号,项目名称,设备名称,时间,创建人) values( '" + richTextBoxEx1.Text + "','" + dangqianshijian + "','" + gongzuolinghao + "' ,'" + xiangmumingcheng + "' ,'" + shebeimingcheng + "'  ,'" + shijian + "','" + yonghu + "')";
            SQLhelp.ExecuteScalar(sql, CommandType.Text);
            MessageBox.Show("更新成功！");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
