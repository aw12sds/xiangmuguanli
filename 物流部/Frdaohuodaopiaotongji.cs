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
    public partial class Frdaohuodaopiaotongji : Form
    {
        public Frdaohuodaopiaotongji()
        {
            InitializeComponent();
        }

        private void Frdaohuodaopiaotongji_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
          
            if (dateEdit1.Text == "")
            {
                MessageBox.Show("请设置开始时间！");
                return;
            }
            if (dateEdit2.Text == "")
            {
                MessageBox.Show("请设置结束时间！");
                return;
            }

            DateTime a = Convert.ToDateTime( Convert.ToDateTime(dateEdit1.Text).ToString("yyyy-MM-dd 00:00:00"));
            DateTime b = Convert.ToDateTime(Convert.ToDateTime(dateEdit2.Text).ToString("yyyy-MM-dd 23:59:59"));

            if (a > b)
            {
                MessageBox.Show("开始时间不能大于结束时间");
                return;
            }
            string sql = "select 工作令号,项目名称,设备名称,合同号,编码,型号,名称,单位,实际采购数量,入库数量,入库时间,净额,发票匹配,采购员  from  tb_ruku where 入库时间>'" + a + "' and 入库时间<'" + b + "' ";
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
