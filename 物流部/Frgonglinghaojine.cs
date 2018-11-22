using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.物流部
{
    public partial class Frgonglinghaojine : Office2007Form
    {
        public Frgonglinghaojine()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public double zongjia;
        public string gonglinghao;
        private void Frgonglinghaojine_Load(object sender, EventArgs e)
        {
            string sql = "select 工作令号,项目名称,设备名称,型号,名称,制造类型,供方名称,合同号,实际采购数量,采购单价,生成合同时间 from tb_caigouliaodan where 工作令号='"+gonglinghao+"' and 生成合同时间 is not null";
            dataGridViewX2.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);

        }

        private void 计算总额ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < dataGridViewX2.Rows.Count; i++)
            {
                if (Convert.ToString(dataGridViewX2.Rows[i].Cells["采购单价"].Value) != "")
                {
                    double shuliang = Convert.ToDouble(dataGridViewX2.Rows[i].Cells["实际采购数量"].Value);
                    double danjia = Convert.ToDouble(dataGridViewX2.Rows[i].Cells["采购单价"].Value);
                    decimal zuizhong = decimal.Round(decimal.Parse((shuliang * danjia).ToString()), 2);
                    dataGridViewX2.Rows[i].Cells["总价"].Value = zuizhong;

                }
                if (Convert.ToString(dataGridViewX2.Rows[i].Cells["采购单价"].Value) == "")
                {
                    dataGridViewX2.Rows[i].Cells["总价"].Value = 0;

                }

            }
            
            zongjia = 0;
            for (int i = 0; i < dataGridViewX2.Rows.Count; i++)
            {
                if (Convert.ToString(dataGridViewX2.Rows[i].Cells["总价"].Value) != "")
                {
                    double jiage = Convert.ToDouble(dataGridViewX2.Rows[i].Cells["总价"].Value);
                    zongjia += jiage;

                }


            }
         
            MessageBox.Show(zongjia.ToString());
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
