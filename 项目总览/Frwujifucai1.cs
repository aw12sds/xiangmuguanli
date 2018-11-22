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
    public partial class Frwujifucai1 : Form
    {
        public Frwujifucai1()
        {
            InitializeComponent();
        }

        private void Frwujifucai1_Load(object sender, EventArgs e)
        {
            string sql1 = "select  id,工作令号,项目名称,设备名称,编码,型号,名称,数量,要求到货日期1,申购人,备注,当前状态,到货情况,采购类型,收到料单日期   from  tb_caigouliaodan where 采购类型!='项目' and 当前状态 !='9已到货' and 当前状态 !='10已出库'  and 采购类型!='机修件' and 采购类型!='模具部'";
            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridControl1.DataSource = dt;

            string sql11 = "select  id,工作令号,项目名称,设备名称,编码,型号,名称,数量,要求到货日期1,申购人,备注,当前状态,到货情况,采购类型,收到料单日期 from  tb_caigouliaodan where (采购类型!='项目' and  当前状态 ='9已到货'  and 采购类型!='机修件' and 采购类型!='模具部') or  (采购类型!='项目'  and 当前状态 ='10已出库' and 采购类型!='机修件' and 采购类型!='模具部')";
            DataTable dt1 = SQLhelp.GetDataTable(sql11, CommandType.Text);
            gridControl2.DataSource = dt1;
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
