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
    public partial class Frbeiliao1 : DevExpress.XtraEditors.XtraForm
    {
        public Frbeiliao1()
        {
            InitializeComponent();
        }
        public string gongzuolinghao;
        public string xiangmumingcheng;
        private void Frbeiliao_Load(object sender, EventArgs e)
        {
            string sql1 = "select 工作令号,项目名称,时间,设备名称,设备负责人,制造类型,工艺顺序总数量,工艺顺序未制定数量  from tb_jishubumen  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 图纸下达='1' ";
            gridControl3.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridView3.Columns["时间"].Visible = false;
            string sql11 = "select 工作令号,项目名称,时间,设备名称,设备负责人,制造类型,备料总数量,已备料数量,加工完成进度  from tb_jishubumen  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 图纸下达='1' ";
            DataTable dt = SQLhelp.GetDataTable(sql11, CommandType.Text);
            gridControl4.DataSource = dt;
            gridView4.Columns["时间"].Visible = false;

        }

        private void gridView3_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView4_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView3_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
            {

                string gonglinghao = Convert.ToString(this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "工作令号"));

                string xiangmumingcheng = Convert.ToString(this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "项目名称"));

                string shijian = Convert.ToString(this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "时间"));

                Frgongyishunxuliaodan form = new Frgongyishunxuliaodan();
                form.gongzuolinghao = gonglinghao;
                form.xiangmumingcheng = xiangmumingcheng;
                form.shijian = shijian;

                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {


                }
            }
        }

        private void gridView4_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
            {

                string gonglinghao = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "工作令号"));

                string xiangmumingcheng = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "项目名称"));

                string shijian = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "时间"));
                FrJiagongxiangqing form = new FrJiagongxiangqing();
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