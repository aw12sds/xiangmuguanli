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
    public partial class FrZhuangpeifankui : Office2007Form
    {
        public FrZhuangpeifankui()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string gongzuolinghao;
        public string xiangmumingcheng;
        public string shebeimingcheng;
        public string shijian;
        public string yonghu;
        private void FrZhuangpeifankui_Load(object sender, EventArgs e)
        {
            Reload();
        }


        public void Reload()
        {

            string sql1 = "select  创建时间,工作令号,项目名称,设备名称,装配反馈内容,时间,创建人  from  tb_zhuangpeifankui  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "'   ";
            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            dataGridViewX2.DataSource = dt;
            

        }
        private void 新增反馈ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            FrZhuangpeiqingkuang form = new FrZhuangpeiqingkuang();
            form.gongzuolinghao = gongzuolinghao;
            form.xiangmumingcheng = xiangmumingcheng;
            form.shebeimingcheng = shebeimingcheng;
            form.shijian = shijian;
            form.yonghu=yonghu;
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                Reload();

            }
        }
    }
}
