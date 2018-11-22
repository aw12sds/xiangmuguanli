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
    public partial class Frzizhizhuanwaixiejilu : DevExpress.XtraEditors.XtraForm
    {
        public Frzizhizhuanwaixiejilu()
        {
            InitializeComponent();
        }

        private void Frzizhizhuanwaixiejilu_Load(object sender, EventArgs e)
        {
            string sql = "select * from tb_jiuxiuxiugai";
            gridControl2.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
            gridView2.Columns["id"].Visible = false;
            string sql1 = "select * from tb_zizhizhuanwaixie";
            gridControl1.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridView1.Columns["id"].Visible = false;

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