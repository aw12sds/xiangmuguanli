using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace 项目管理系统.个人管理
{
    public partial class Frhetongliaodanshencha : DevExpress.XtraEditors.XtraForm
    {
        public Frhetongliaodanshencha()
        {
            InitializeComponent();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            if (txthetonghao.Text.Trim() == "")
            {
                MessageBox.Show("请输入合同号！");
                return;
            }
            string sql1 = "select 工作令号,项目名称,设备名称,编码,型号,名称,单位,数量,类型,备注,制造类型,申购人,收到料单日期,供方名称,合同号,实际采购数量,采购单价,当前状态 from  tb_caigouliaodan  where 合同号='" + txthetonghao.Text + "'";
            gridControl4.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
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