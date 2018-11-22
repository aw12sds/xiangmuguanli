using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 项目管理系统.生产部;

namespace 项目管理系统.档案室
{
    public partial class Frdayin1 : Form
    {
        public Frdayin1()
        {
            InitializeComponent();
        }

        private void Frdayin1_Load(object sender, EventArgs e)
        {
            Reload();
        }
        public void Reload()
        {

            string sql = "select id,工作令号,项目名称,设备名称,设备负责人,数量,图纸下达时间,时间 from tb_jishubumen where 制造类型='自制' and 是否提交=1 and 技术部通过=1  and 生产部确认=0 and 图纸下达=1 ";

           gridControl4.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
            gridView4.Columns["id"].Visible = false;
            gridView4.Columns["时间"].Visible = false;
        }
        
        private void buttonItem1_Click(object sender, EventArgs e)
        {
            string sql = "select id,工作令号,项目名称,设备名称,设备负责人,数量,图纸下达时间,时间 from tb_jishubumen where 设备名称 like '%" + textBoxItem1.Text.Trim() + "%' ";

            gridControl4.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
            gridView4.Columns["id"].Visible = false;
            gridView4.Columns["时间"].Visible = false;
          
        }

        private void gridView4_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }

        private void gridView4_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {


            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
            {
                string gonglinghao = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "工作令号"));
                string xiangmumingcheng = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "项目名称"));
                string shebeimingcheng = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "设备名称"));
                string shijian = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "时间"));
                string sql1 = "select 序号,工作令号,项目名称,id,编码,型号,名称,单位,制造类型,实际采购数量,附件名称,附件类型 from  tb_caigouliaodan  where 工作令号='" + gonglinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "'";
                Frdayindeyulan form1 = new Frdayindeyulan();
                form1.dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                form1.ShowDialog();

            }
        }
    }
}
