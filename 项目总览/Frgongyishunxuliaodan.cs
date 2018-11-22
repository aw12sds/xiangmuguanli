using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.项目总览
{
    public partial class Frgongyishunxuliaodan : Office2007Form
    {
        public Frgongyishunxuliaodan()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string gongzuolinghao;
        public string xiangmumingcheng;
        public string shijian;
        private void Frgongyishunxuliaodan_Load(object sender, EventArgs e)
        {
            string sql1 = "select  编码,型号,名称,单位,数量,类型,备注,制造类型,工艺顺序1,工艺顺序2,工艺顺序3 from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "' and   制造类型!='自制零部件' and   制造类型!='装配零部件' and   制造类型!='库存件'  ";
            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridControl1.DataSource = dt;
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }


        }
    }
}
