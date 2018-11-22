using Aspose.Cells;
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
    public partial class Frjinggongxiangmu1 : Form
    {
        public Frjinggongxiangmu1()
        {
            InitializeComponent();
        }

        private void Frjinggongxiangmu1_Load(object sender, EventArgs e)
        {
            Reload();
        }
        public void Reload()
        {
            string sql123 = "select 接单编号,客户名称,部门,工件名称,加工内容,计量单位,机修件数量,接单日期,预交时间,联系人,责任人,加工单位备注,完成,当前状态,供方名称,合同号  from  tb_caigouliaodan where ( 完成='未完成'  and 机修件数量 is not null) or (完成 is null and 机修件数量 is not null) or(完成 ='' and 机修件数量 is not null)";          
            gridControl1. DataSource= SQLhelp.GetDataTable(sql123, CommandType.Text);
            string sql12 = "select 接单编号,客户名称,部门,工件名称,加工内容,计量单位,机修件数量,接单日期,预交时间,联系人,责任人,加工单位备注  from  tb_caigouliaodan where 完成='完成' ";          
            gridControl2.DataSource = SQLhelp.GetDataTable(sql12, CommandType.Text);
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
    }
}
