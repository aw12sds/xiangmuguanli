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
    public partial class FrJinggongxiangmu : Office2007Form
    {
        public FrJinggongxiangmu()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }

        private void FrJinggongxiangmu_Load(object sender, EventArgs e)
        {
            Reload();
        }
        public void Reload()
        {
            string sql123 = "select id,接单编号,客户名称,部门,工件名称,加工内容,计量单位,机修件数量,接单日期,预交时间,联系人,责任人,加工单位备注,完成  from  tb_caigouliaodan where ( 完成='未完成'  and 机修件数量 is not null) or (完成 is null and 机修件数量 is not null) or(完成 ='' and 机修件数量 is not null)";
            SQLhelp.GetDataTable(sql123, CommandType.Text);
            dataGridViewX2.DataSource = SQLhelp.GetDataTable(sql123, CommandType.Text);


            string sql12 = "select id,接单编号,客户名称,部门,工件名称,加工内容,计量单位,机修件数量,接单日期,预交时间,联系人,责任人,加工单位备注  from  tb_caigouliaodan where 完成='完成' ";
            DataTable dt1 = SQLhelp.GetDataTable(sql12, CommandType.Text);
            dataGridViewX1.DataSource = dt1;
        }

     
        private void dataGridViewX2_CellPainting_1(object sender, DataGridViewCellPaintingEventArgs e)
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
