using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace 项目管理系统.项目总览
{
    public partial class Frzonglanzongliaodan : DevExpress.XtraEditors.XtraForm
    {
        public Frzonglanzongliaodan()
        {
            InitializeComponent();
        }
        public string gongzuolinghao;
        public string xiangmumingcheng;
        public string shebeimingcheng;
        public string shijian;
        private void Frzonglanzongliaodan_Load(object sender, EventArgs e)
        {
            string sql1 = "select  序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,当前状态 from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "'and 时间='" + shijian + "' ";
            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridControl4.DataSource = dt;
            gridView4.Columns["项目工令号"].Caption = "库存数量";
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