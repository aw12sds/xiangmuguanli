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
    public partial class Frzonglanxiangqing : Office2007Form
    {
        public Frzonglanxiangqing()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string gongzuolinghao;
        public string xiangmumingcheng;
        private void Frzonglanxiangqing_Load(object sender, EventArgs e)
        {
            string sql = "select id,工作令号,项目名称,设备名称,项目主管,数量,采购项目负责人,时间,物流部完成时间 from tb_jishubumen where ( 工作令号='"+gongzuolinghao+"' and 项目名称='"+xiangmumingcheng+ "' and 制造类型='外购' and 是否提交=1 and 技术部通过=1 and 物流部确认=1 and 图纸下达=1 and 物流部最终确认 is null) or (工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 制造类型='自制' and 是否提交=1 and 技术部通过=1  and 生产部确认=1 and 物流部确认=1 and 图纸下达=1 and 物流部最终确认 is null) ";
          DataTable  dt = SQLhelp.GetDataTable(sql, CommandType.Text);

            DataColumn column1 = new DataColumn();
            //该列的数据类型
            column1.DataType = System.Type.GetType("System.String");
            //该列得名称
            column1.ColumnName = "预计采购结束时间";
            dt.Columns.Add(column1);
            DataColumn column2 = new DataColumn();
            //该列的数据类型
            column2.DataType = System.Type.GetType("System.String");
            //该列得名称
            column2.ColumnName = "到货进度";
            dt.Columns.Add(column2);


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string gongzuolinghao = dt.Rows[i]["工作令号"].ToString();
                string xiangmumingcheng = dt.Rows[i]["项目名称"].ToString();
                string shijian = dt.Rows[i]["时间"].ToString();

                string sql3 = "select 预计采购结束时间  from tb_xiangmu where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'";
                string shijian1 = SQLhelp.ExecuteScalar(sql3, CommandType.Text).ToString();

                dt.Rows[i]["预计采购结束时间"] = shijian1;

                string sql2 = "select count(*)  from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "'and 制造类型!='自制零部件' and 制造类型!='装配零部件' and 制造类型!='库存件' and 当前状态='9已到货'";

                int jiagonggeshu = Convert.ToInt32(SQLhelp.ExecuteScalar(sql2, CommandType.Text));

                string sql4 = "select count(*)  from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "' and 制造类型!='自制零部件' and 制造类型!='装配零部件' and 制造类型!='库存件' ";

                int zonggeshu = Convert.ToInt32(SQLhelp.ExecuteScalar(sql4, CommandType.Text));

                if (zonggeshu != 0)
                {
                    dt.Rows[i]["到货进度"] = (100 * jiagonggeshu / zonggeshu);
                }

            }
            dataGridViewX2.DataSource = dt;
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

        private void dataGridViewX2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string gonglinghao = dataGridViewX2.CurrentRow.Cells["工作令号"].Value.ToString();
            string xiangmumingcheng = dataGridViewX2.CurrentRow.Cells["项目名称"].Value.ToString();
            string shebeimingcheng = dataGridViewX2.CurrentRow.Cells["设备名称"].Value.ToString();
            string shijian = dataGridViewX2.CurrentRow.Cells["时间"].Value.ToString();

            FrWuliubuliaodan form = new FrWuliubuliaodan();
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
