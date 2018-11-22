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
    public partial class FrJiagongxiangqing : DevExpress.XtraEditors.XtraForm
    {
        public FrJiagongxiangqing()
        {
            
            InitializeComponent();
        }
        public string gongzuolinghao;
        public string xiangmumingcheng;
        public string shijian;
        private void FrJiagongxiangqing_Load(object sender, EventArgs e)
        {
            string sql1 = "select  序号,编码,型号,名称,单位,数量,类型,要求到货日期,备注,制造类型,实际采购数量,当前状态 from  tb_caigouliaodan  where 工作令号='"+gongzuolinghao+"' and 项目名称='"+xiangmumingcheng+"'and 时间='"+shijian+"'  ";
           
            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridControl4.DataSource = dt;
            

            string sql2 = "select  序号,编码,型号,名称,单位,数量,类型,要求到货日期,备注,制造类型,实际采购数量,当前状态 from  tb_caigouliaodan  where (工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "'  and 当前状态='9已到货' and  备料 is null) or(工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "'  and 当前状态='已加工' and  备料 is null) or(工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "'  and 当前状态='无需加工或购买' and  备料 is null)    ";

            DataTable dt2 = SQLhelp.GetDataTable(sql2, CommandType.Text);
            gridControl1.DataSource = dt2;

            string sql3 = "select  序号,编码,型号,名称,单位,数量,类型,要求到货日期,备注,制造类型,实际采购数量,当前状态,备料,备料时间 from  tb_caigouliaodan  where (工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "'  and 当前状态='9已到货' and  备料 =1) or(工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "'  and 当前状态='已加工' and  备料 =1) or(工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "'  and 当前状态='无需加工或购买' and  备料 =1)";

            DataTable dt3 = SQLhelp.GetDataTable(sql3, CommandType.Text);
            gridControl3.DataSource = dt3;

            string sql4 = "select  序号,编码,型号,名称,单位,数量,类型,要求到货日期,备注,制造类型,实际采购数量,当前状态 from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "'  and (当前状态!='9已到货' and  当前状态!='已加工' and 当前状态!='无需加工或购买')  and  备料 is null ";

            DataTable dt4 = SQLhelp.GetDataTable(sql4, CommandType.Text);
            gridControl2.DataSource = dt4;

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

        private void gridView4_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }


        }
    }
}
