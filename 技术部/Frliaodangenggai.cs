using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.技术部
{
    public partial class Frliaodangenggai : Form
    {
        public Frliaodangenggai()
        {
            InitializeComponent();
        }
        public string yonghu;
        private void Frliaodangenggai_Load(object sender, EventArgs e)
        {
            string sql1 = "select id,工作令号,项目名称,设备名称,数量,时间 from tb_jishubumen where 设备负责人='"+yonghu+"'";
           gridControl2.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridView2.Columns["id"].Visible = false;
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            string gonglinghao = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "工作令号"));

            string xiangmumingcheng = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "项目名称"));
            string shebeimingcheng = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "设备名称"));

            string shijian = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "时间"));

            FRliaodanbianji form = new FRliaodanbianji();
            form.gongzuolinghao = gonglinghao;
            form.xiangmumingcheng = xiangmumingcheng;

            form.shijian = shijian;
            form.yonghu = yonghu;
            form.ShowDialog();

        }

        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }
    }
}
