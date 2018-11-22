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
    public partial class Frjishugenggairuku : Form
    {
        public Frjishugenggairuku()
        {
            InitializeComponent();
        }
        double zongjia;
        string mingxi;

        private void Frjishugenggairuku_Load(object sender, EventArgs e)
        {
            
            string sql1 = "select 工作令号,项目名称,设备名称,id,编码,型号,名称,单位,数量,类型,要求到货日期,备注,制造类型,技术更改入库时间,实际采购数量 from  tb_caigouliaodan  where  技术更改=1 ";
            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            dt.Columns.Add("价格");
            dt.Columns.Add("明细");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                mingxi = "";
                zongjia = 0;
                string sql = "  Select 价格,数量,工序内容 from db_gongxu11 where  工作令号='" + dt.Rows[i]["工作令号"] + "' and  项目名称='" + dt.Rows[i]["项目名称"] + "'  and  设备名称='" + dt.Rows[i]["设备名称"] + "' and  图号='" + dt.Rows[i]["型号"] + "'";
                DataTable jiage = sqlhelp1.GetDataTable(sql, CommandType.Text);
                for (int j = 0; j < jiage.Rows.Count; j++)
                {
                    int shuliang = Convert.ToInt32(jiage.Rows[j]["数量"]);
                    string jiage1 = Convert.ToString(jiage.Rows[j]["价格"]);
                    if (jiage1 != "")
                    {
                        zongjia += Convert.ToDouble(jiage.Rows[j]["价格"]) * (shuliang);

                    }
                    mingxi += jiage.Rows[j]["工序内容"].ToString() + "|";
                }
                dt.Rows[i]["价格"] = zongjia;
                dt.Rows[i]["明细"] = mingxi;

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
    }
}
