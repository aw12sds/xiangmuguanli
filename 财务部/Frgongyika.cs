using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.财务部
{
    public partial class Frgongyika : Office2007Form
    {
        public Frgongyika()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }
        public string gongzuolinghao;
        public string xiangmumingcheng;
        public string shebeimingcheng;
        public string xinghao;
         
        private void Frgongyika_Load(object sender, EventArgs e)
        {
            string sql = "  Select 价格,工序内容,工序顺序,负责人 from db_gongxu1 where  工作令号='" + gongzuolinghao + "' and  项目名称='" + xiangmumingcheng + "'  and  设备名称='" + shebeimingcheng + "' and  图号='" +xinghao+ "'";
            dataGridViewX2.DataSource = sqlhelp1.GetDataTable(sql, CommandType.Text);
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
    }
}
