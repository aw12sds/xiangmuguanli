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
    public partial class Frjiagongweiwancheng : DevExpress.XtraEditors.XtraForm
    {
        public Frjiagongweiwancheng()
        {
            InitializeComponent();
        }
        public string xiangmumingcheng;
        public string gongzuolinghao;
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }

        private void Frjiagongweiwancheng_Load(object sender, EventArgs e)
        {

            string sql11 = "select 工作令号,项目名称,时间,设备名称,设备负责人,加工完成进度  from tb_jishubumen  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'  and 技术部通过=1  and 制造类型='自制' and 生产部确认=1 and 加工确认=0  ";
            DataTable dt = SQLhelp.GetDataTable(sql11, CommandType.Text);
            gridControl1.DataSource = dt;
            gridView1.Columns["时间"].Visible = false;

        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
            {

              Frweiwanchengjiagongliaodan form = new Frweiwanchengjiagongliaodan();
                form.gongzuolinghao = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号").ToString();
                form.xiangmumingcheng = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "项目名称").ToString();
                form.shebeimingcheng = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "设备名称").ToString();
                form.shijian = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "时间").ToString();

                form.ShowDialog();
            }
        }
    }
}