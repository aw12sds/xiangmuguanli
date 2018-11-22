using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.仓库
{
    public partial class FrDuiyingliaodan : Office2007Form
    {
        public FrDuiyingliaodan()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string gongzuolinghao;
        public string xiangmumingcheng;
        public string shijian;
        public string yonghu;
        public string panduan;
        public string id1;
        public string biaoji;
        private void FrDuiyingliaodan_Load(object sender, EventArgs e)
        {
            string sql1 = "select  设备名称,项目名称,工作令号,时间,id,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,当前状态,仓库确认,仓库确认时间,到货验收流程按钮,流程状态 from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "'  and   制造类型!='自制零部件' and   制造类型!='装配零部件'  and   到货验收流程标记= '" + biaoji + "'";
            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            dataGridViewX2.DataSource = dt;
        }
    }
}
