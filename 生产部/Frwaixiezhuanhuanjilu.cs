using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace 项目管理系统.生产部
{
    public partial class Frwaixiezhuanhuanjilu : DevExpress.XtraEditors.XtraForm
    {
        public Frwaixiezhuanhuanjilu()
        {
            InitializeComponent();
        }

        private void Frwaixiezhuanhuanjilu_Load(object sender, EventArgs e)
        {
            string sql = "select 工作令号,项目名称,设备名称,名称,型号,单位,实际采购数量,修改时间,修改内容 from tb_zizhizhuanwaixie";
            gridControl1.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);


            string sql1 = "select 接单编号,工件名称,加工内容,计量单位,机修件数量,加工单位备注,修改时间,修改时间,修改内容 from tb_jiuxiuxiugai";
            gridControl2.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);

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