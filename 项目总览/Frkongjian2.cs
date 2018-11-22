using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.项目总览
{
    public partial class Frkongjian2 : UserControl
    {
        public Frkongjian2()
        {
            InitializeComponent();
        }
        public DataTable dt;
       
        private void Frkongjian2_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = dt;
            gridView1.Columns["id"].Visible = false;
            gridView1.Columns["机修与模具交货时间"].Caption = "交货日期";

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
