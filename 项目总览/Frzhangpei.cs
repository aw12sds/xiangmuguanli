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
    public partial class Frzhangpei : DevExpress.XtraEditors.XtraForm
    {
        public Frzhangpei()
        {
            InitializeComponent();
        }
        public string gongzuolinghao;
        public string xiangmumingcheng;
        private void Frzhangpei_Load(object sender, EventArgs e)
        {
            string sql1 = "select  工作令号,项目名称,设备名称,时间,设备负责人,自制图纸总数量,图纸完成数量,外协图纸总数量,外协图纸完成数量,采购部件总数量,采购部件完成数量 from tb_jishubumen  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 加工确认='1' and 制造类型='自制'";
            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridControl5.DataSource = dt;
            gridView5.Columns["时间"].Visible = false;
        }

        private void gridView5_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
    }
}