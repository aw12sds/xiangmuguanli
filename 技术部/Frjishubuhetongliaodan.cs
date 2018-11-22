using System;
using System.Data;


namespace 项目管理系统.技术部
{
    public partial class Frjishubuhetongliaodan : DevExpress.XtraEditors.XtraForm
    {
        public Frjishubuhetongliaodan()
        {
            InitializeComponent();
        }
      
        private void gridView4_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }

        private void Frjishubuhetongliaodan_Load(object sender, EventArgs e)
        {
          
        }



        private void buttonItem1_Click_1(object sender, EventArgs e)
        {
            string sql1 = "select 工作令号,项目名称,设备名称, 序号,编码,型号,名称,单位,数量,类型,要求到货日期,备注,制造类型,申购人,供方名称,合同号,实际采购数量,当前状态 from  tb_caigouliaodan  where 合同号='" + txthetonghao.Text + "'";

            gridControl4.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
        }
    }
}