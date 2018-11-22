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
    public partial class Frsheji : DevExpress.XtraEditors.XtraForm
    {
        public Frsheji()
        {
            InitializeComponent();
        }
        public string gongzuolinghao;
        public string xiangmumingcheng;
        private void Frsheji_Load(object sender, EventArgs e)
        {
            string sql1 = "select  工作令号,项目名称,时间,项目负责人,设备负责人,设备名称,图纸下达时间,实际完成时间,制造类型,技术方案考核绩效点,料单考核绩效点,超期天数,完成周期 from tb_jishubumen  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 技术部通过='1'";
            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridControl1.DataSource = dt;
            gridView1.Columns["时间"].Visible = false;
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
            {

                string gonglinghao = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号"));
                string xiangmumingcheng = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "项目名称"));

                string shijian = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "时间"));
                FrYanfaxiangqing form = new FrYanfaxiangqing();
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