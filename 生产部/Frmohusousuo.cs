using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.生产部
{
    public partial class Frmohusousuo : Office2007Form
    {
        public Frmohusousuo()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }

        private void Frmohusousuo_Load(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            
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

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (txtwuzi.Text.Trim() == "")
            {
                MessageBox.Show("请输入需要查找的内容");
                return;
            }
            string sql = " select* from tb_xinerp    where  一级 like '%" + txtwuzi.Text.Trim() + "%' or 二级 like '%" + txtwuzi.Text.Trim() + "%'  or 三级 like '%" + txtwuzi.Text.Trim() + "%'  or 四级 like '%" + txtwuzi.Text.Trim() + "%' ";
            gridControl4.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
            gridView4.Columns["id"].Visible = false;
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
