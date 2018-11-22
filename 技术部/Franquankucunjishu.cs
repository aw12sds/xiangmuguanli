using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace 项目管理系统.技术部
{
    public partial class Franquankucunjishu : DevExpress.XtraEditors.XtraForm
    {
        public Franquankucunjishu()
        {
            InitializeComponent();
        }

        private void Franquankucunjishu_Load(object sender, EventArgs e)
        {
            string sql = "select 三级,四级,实时库存数,需购买量 from tb_xinerp where 安全库存=1";
            gridControl1.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
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