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
    public partial class Frbeiliaoxiangmu : Office2007Form
    {
        public Frbeiliaoxiangmu()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string gongzuolinghao;
        public string xiangmumingcheng;
        public string yonghu;
        public string shebeimingcheng;
        private void Frbeiliaoxiangmu_Load(object sender, EventArgs e)
        {
            Reload();
        }
        public void Reload()
        {
            string sql1 = "select 工作令号,项目名称,时间,设备名称,设备负责人,加工完成时间,制造类型  from tb_jishubumen  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 图纸下达='1' ";
            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

            DataColumn column1 = new DataColumn();

            column1.DataType = System.Type.GetType("System.String");

            column1.ColumnName = "预计加工完成时间";

            dt.Columns.Add(column1);
            if (dt.Rows.Count != 0)
            {
                string sql = "select  预计加工结束时间 from tb_xiangmu where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'";
                DateTime yujiwanchengshijian = Convert.ToDateTime(SQLhelp.ExecuteScalar(sql, CommandType.Text));

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    dt.Rows[i]["预计加工完成时间"] = yujiwanchengshijian;

                }

                DataColumn column2 = new DataColumn();

                column2.DataType = System.Type.GetType("System.Decimal");

                column2.ColumnName = "加工完成进度";

                dt.Columns.Add(column2);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string shijian = dt.Rows[i]["时间"].ToString();


                    string sql2 = "select count(*)  from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" +shebeimingcheng + "' and 时间='" + shijian + "' and 制造类型='自制零部件' and 生产部确认=1";

                    int jiagonggeshu = Convert.ToInt32(SQLhelp.ExecuteScalar(sql2, CommandType.Text));

                    string sql3 = "select count(*)  from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "' and 时间='" + shijian + "' and 制造类型='自制零部件' ";

                    int zonggeshu = Convert.ToInt32(SQLhelp.ExecuteScalar(sql3, CommandType.Text));

                    if (zonggeshu != 0)
                    {
                        dt.Rows[i]["加工完成进度"] = (100 * jiagonggeshu / zonggeshu);
                    }

                }


                dataGridViewX3.DataSource = dt;

            }




        }

        private void dataGridViewX3_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dataGridViewX3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string gonglinghao = dataGridViewX3.CurrentRow.Cells["工作令号3"].Value.ToString();
            string xiangmumingcheng = dataGridViewX3.CurrentRow.Cells["项目名称3"].Value.ToString();
            string shebeimingcheng = dataGridViewX3.CurrentRow.Cells["设备名称2"].Value.ToString();
            string shijian = dataGridViewX3.CurrentRow.Cells["时间3"].Value.ToString();

           Frbeiliaoxiangxi form = new Frbeiliaoxiangxi();
            form.gongzuolinghao = gonglinghao;
            form.xiangmumingcheng = xiangmumingcheng;
            form.shijian = shijian;
            form.yonghu = yonghu;
            form.shebeimingcheng = shebeimingcheng;
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {


            }
        }
    }
}
