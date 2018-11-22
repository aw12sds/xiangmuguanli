using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.物流部
{
    public partial class Frpici : DevExpress.XtraEditors.XtraForm
    {
        public Frpici()
        {
            InitializeComponent();
        }
        public string id;
        public string yonghu;
        public DataTable dt;
        private void Frpici_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = dt;
            gridView1.Columns["id"].Visible = false;
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
