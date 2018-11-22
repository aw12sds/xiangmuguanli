using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace 项目管理系统.物流部
{
    public partial class Frchaxunxunjiadan : DevExpress.XtraEditors.XtraForm
    {
        public Frchaxunxunjiadan()
        {
            InitializeComponent();
        }

        private void Frchaxunxunjiadan_Load(object sender, EventArgs e)
        {
            string sql = "select 工作令号,项目名称,设备名称,编码,型号,名称,单位,数量,类型,要求到货日期,物料理论到货时间,备注,制造类型,申购人,收到料单日期,实际采购数量,供方名称,当前状态,询价标记 from  tb_caigouliaodan  where  当前状态='1询比价'";
            gridControl4.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
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