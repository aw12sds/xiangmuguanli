using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.项目总览
{
    public partial class Frwujinfucaixiangmu : Office2007Form
    {
        public Frwujinfucaixiangmu()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }

        private void Frwujinfucaixiangmu_Load(object sender, EventArgs e)
        {
            string sql1 = "select  id,工作令号,项目名称,设备名称,编码,型号,名称,数量,要求到货日期1,申购人,备注,当前状态,到货情况,采购类型,收到料单日期   from  tb_caigouliaodan where 采购类型 IS NOT NULL and 到货情况=0 ";
            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            dataGridViewX2.DataSource = dt;

            string sql11 = "select  id,工作令号,项目名称,设备名称,编码,型号,名称,数量,要求到货日期1,申购人,备注,当前状态,到货情况,采购类型,收到料单日期 from  tb_caigouliaodan where 采购类型 IS NOT NULL and 到货情况=1";
            DataTable dt1 = SQLhelp.GetDataTable(sql11, CommandType.Text);
            dataGridViewX1.DataSource = dt1;
        }

        private void dataGridViewX2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex < 0 && e.RowIndex >= 0)
            {
                e.Paint(e.ClipBounds, DataGridViewPaintParts.All);
                Rectangle rectangle = e.CellBounds;
                rectangle.Inflate(-2, -2);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.CellStyle.Font, rectangle, e.CellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
                e.Handled = true;
            }
        }

        private void dataGridViewX1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex < 0 && e.RowIndex >= 0)
            {
                e.Paint(e.ClipBounds, DataGridViewPaintParts.All);
                Rectangle rectangle = e.CellBounds;
                rectangle.Inflate(-2, -2);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.CellStyle.Font, rectangle, e.CellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
                e.Handled = true;
            }
        }
    }
}
