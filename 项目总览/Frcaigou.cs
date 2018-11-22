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
    public partial class Frcaigou : DevExpress.XtraEditors.XtraForm
    {
        public Frcaigou()
        {
            InitializeComponent();
        }
        public string gongzuolinghao;
        public string xiangmumingcheng;
        private void Frcaigou_Load(object sender, EventArgs e)
        {
            string sql1 = "select 工作令号,项目名称,时间,设备名称,设备负责人,物流部完成时间,采购项目负责人,合同考核绩效点,采购项目完成进展 from tb_jishubumen  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 物流部确认='1'";
            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridControl2.DataSource = dt;
            gridView2.Columns["时间"].Visible = false;
        }

        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
            {

                string gonglinghao = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "工作令号"));

                string xiangmumingcheng = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "项目名称"));
                string shebeimingcheng = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "设备名称"));
                string shijian = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "时间"));
                FrCaigouxiangqing form = new FrCaigouxiangqing();
                form.gongzuolinghao = gonglinghao;
                form.xiangmumingcheng = xiangmumingcheng;
                form.shijian = shijian;

                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {


                }
            }
        }
    }
}