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
    public partial class Frwuliuzonglan : Office2007Form
    {
        public Frwuliuzonglan()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
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
        DataTable dtt;
        public string yonghu;
        private void Frwuliuzonglan_Load(object sender, EventArgs e)
        {
            string sql = "select id,工作令号,项目名称,客户名称,交货日期,采购负责人  from tb_xiangmu  where 未交货项目=1";

            dtt = SQLhelp.GetDataTable(sql, CommandType.Text);
            
            dataGridViewX2.DataSource = dtt;

        }

        private void dataGridViewX2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Frzonglanxiangqing form1 = new Frzonglanxiangqing();
            form1.gongzuolinghao = dataGridViewX2.CurrentRow.Cells["工作令号"].Value.ToString();
            form1.xiangmumingcheng = dataGridViewX2.CurrentRow.Cells["项目名称"].Value.ToString();
            form1.ShowDialog();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            Frhetongliaodan form1 = new Frhetongliaodan();
            form1.hetonghao = txthetonghao.Text.Trim();
            form1.yonghu = yonghu;
            form1.ShowDialog();
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            Frgonglinghaojine form1 = new Frgonglinghaojine();
           
            form1.gonglinghao = txtgonglinghao.Text.Trim();
            form1.ShowDialog();
        }
    }
}
