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
    public partial class Frcaigougenzongliaodan : DevExpress.XtraEditors.XtraForm
    {
        public Frcaigougenzongliaodan()
        {
            InitializeComponent();
        }
        public string gongzuolinghao;
        public string xiangmumingcheng;
        private void Frcaigougenzongliaodan_Load(object sender, EventArgs e)
        {
            string caigouweiwanchengliang = "select  编码,型号,名称,单位,实际采购数量,类型,要求到货日期,备注,制造类型,当前状态 from tb_caigouliaodan where (工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 制造类型!='自制零部件'  and 制造类型!='装配零部件'  and 制造类型!='库存件'  and 制造类型!='零件'  and 当前状态!='9已到货' and 当前状态!='10已出库' and 当前状态!='5生产制作中') or (工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 制造类型!='自制零部件'  and 制造类型!='装配零部件'  and 制造类型!='库存件'  and 制造类型!='零件'  and 当前状态 is null) ";
            gridControl4.DataSource = SQLhelp.GetDataTable(caigouweiwanchengliang, CommandType.Text);
            this.WindowState = FormWindowState.Maximized;
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