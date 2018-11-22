using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace 项目管理系统.财务部
{
    public partial class Frchukumingxi : DevExpress.XtraEditors.XtraForm
    {
        public Frchukumingxi()
        {
            InitializeComponent();
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
        public string kaishi;
        public string jieshu;
        public string gongzuolinghao;
        public string xiangmumingcheng;
        public string shebei;

        private void Frchukumingxi_Load(object sender, EventArgs e)
        {
            string sql = "select 工作令号,项目名称,设备划分,名称,型号,编码,出库数量,出库时间,净单价,净额,描述 from tb_chuku where 出库时间>'" + kaishi + "' and 出库时间<'" + jieshu + "' and 设备划分='" + shebei + "'  and 工作令号='" + gongzuolinghao + "'  and 项目名称='" + xiangmumingcheng + "' ";
            gridControl1.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
        }
    }
}