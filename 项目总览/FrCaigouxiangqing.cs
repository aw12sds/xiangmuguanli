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
    public partial class FrCaigouxiangqing : DevExpress.XtraEditors.XtraForm
    {
        public FrCaigouxiangqing()
        {
           
            InitializeComponent();
        }
        public string gongzuolinghao;
        public string xiangmumingcheng;
        public string shijian;
        private void FrCaigouxiangqing_Load(object sender, EventArgs e)
        {
            string sql1 = "select  序号,编码,型号,名称,单位,类型,要求到货日期,备注,制造类型,当前状态,实际采购数量 from  tb_caigouliaodan  where (工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "' and   制造类型!='自制零部件' and   制造类型!='装配零部件' and   制造类型!='库存件' and   当前状态 is null)or  ( 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "' and   制造类型!='自制零部件' and   制造类型!='装配零部件' and   制造类型!='库存件' and   当前状态='' )or  ( 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "' and   制造类型!='自制零部件' and   制造类型!='装配零部件' and   制造类型!='库存件' and   当前状态='1询比价' )or  ( 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "' and   制造类型!='自制零部件' and   制造类型!='装配零部件' and   制造类型!='库存件' and   当前状态='1询价中' ) ";
            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridControl1.DataSource = dt;
            

            string sql2 = "select 序号,编码,型号,名称,单位,类型,要求到货日期,备注,制造类型,当前状态,实际采购数量,供方名称,合同号,生产负责人,生产负责人电话,合同预计时间,合同绩效点,生成合同时间,实际到货数量 from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "' and   制造类型!='自制零部件' and   制造类型!='装配零部件' and   制造类型!='库存件'  and   当前状态='5生产制作中'  ";
            DataTable dt2 = SQLhelp.GetDataTable(sql2, CommandType.Text);
            gridControl2.DataSource = dt2;
            gridView2.Columns["实际到货数量"].Caption = "入库数量";


            string sql3 = "select  序号,编码,型号,名称,单位,实际采购数量,类型,制造类型,当前状态,供方名称,合同号,实际到货数量,仓库确认时间,出库数量,出库时间 from  tb_caigouliaodan  where (工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "' and   制造类型!='自制零部件' and   制造类型!='装配零部件' and   制造类型!='库存件' and   当前状态='9已到货') or  ( 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "' and   制造类型!='自制零部件' and   制造类型!='装配零部件' and   制造类型!='库存件' and   当前状态='10已出库' )  ";
            DataTable dt3 = SQLhelp.GetDataTable(sql3, CommandType.Text);
           gridControl3.DataSource = dt3;
            gridView3.Columns["实际到货数量"].Caption = "入库数量";
            gridView3.Columns["仓库确认时间"].Caption = "入库时间";
         
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }

        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }

        private void gridView3_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }
    }
}
