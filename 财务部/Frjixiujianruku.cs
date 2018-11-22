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
    public partial class Frjixiujianruku : Form
    {
        public Frjixiujianruku()
        {
            InitializeComponent();
        }
        double zongjia;
        string mingxi;
 
        private void Frjixiujianruku_Load(object sender, EventArgs e)
        {
           
            
            //string sql1 = "select id,接单编号,客户名称,部门,工件名称,加工内容,计量单位,机修件数量,接单日期,预交时间,联系人,责任人,加工单位备注,当前状态,生产部确认,生产部确认时间 from  tb_caigouliaodan  where  机修件数量 is not null and 加工单位备注='自制' and 生产部确认=1  ";


            //DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            //dt.Columns.Add("价格");
            //dt.Columns.Add("明细");
            //dt.Columns.Add("材料1");
            //dt.Columns.Add("重量1");
            //dt.Columns.Add("材料2");
            //dt.Columns.Add("重量2");
            //dt.Columns.Add("材料3");
            //dt.Columns.Add("重量3");
            //dt.Columns.Add("材料4");
            //dt.Columns.Add("重量4");
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    mingxi = "";
            //    zongjia = 0;
            //    string sql = "  Select 价格,机修件数量,工序内容,材料,重量 from db_gongxu111 where  接单编号='" + dt.Rows[i]["接单编号"] + "'";
            //    DataTable jiage = sqlhelp1.GetDataTable(sql, CommandType.Text);
            //    for (int j = 0; j < jiage.Rows.Count; j++)
            //    {
            //        double shuliang = Convert.ToDouble(jiage.Rows[j]["机修件数量"]);
            //        string jiage1 = Convert.ToString(jiage.Rows[j]["价格"]);
            //        if (jiage1 != "")
            //        {
            //            zongjia += Convert.ToDouble(jiage.Rows[j]["价格"]) * (shuliang);
            //        }                   
            //        mingxi += jiage.Rows[j]["工序内容"].ToString() + "|";
            //        if (j < 4)
            //        {
            //            dt.Rows[i]["材料" + (j + 1)] = jiage.Rows[j]["材料"];
            //            dt.Rows[i]["重量" + (j + 1)] = jiage.Rows[j]["重量"];
            //        }
            //    }
            //    dt.Rows[i]["价格"] = zongjia;
            //    dt.Rows[i]["明细"] = mingxi;
            //}
            //dataGridViewX1.DataSource = dt;
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
        #region 查询OLD
        //private void buttonX1_Click(object sender, EventArgs e)
        //{
        //    string shijian = dateTimeInput1.Value.ToString("yyyy-MM-dd 00:00:000");
        //    DateTime a = dateTimeInput1.Value.AddDays(1);
        //    string shijian2 = a.ToString("yyyy-MM-dd 00:00:000");
        //    string sql1 = "select id,接单编号,客户名称,部门,工件名称,加工内容,计量单位,机修件数量,接单日期,预交时间,联系人,责任人,加工单位备注,当前状态,生产部确认,生产部确认时间 from  tb_caigouliaodan  where  机修件数量 is not null and 加工单位备注='自制' and 生产部确认=1 and 生产部确认时间>'"+shijian+ "' and 生产部确认时间<'" + shijian2 + "' ";

        //    DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
        //    dt.Columns.Add("价格");
        //    dt.Columns.Add("明细");
        //    dt.Columns.Add("材料1");
        //    dt.Columns.Add("重量1");
        //    dt.Columns.Add("材料2");
        //    dt.Columns.Add("重量2");
        //    dt.Columns.Add("材料3");
        //    dt.Columns.Add("重量3");
        //    dt.Columns.Add("材料4");
        //    dt.Columns.Add("重量4");
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        mingxi = "";
        //        zongjia = 0;
        //        string sql = "  Select 价格,机修件数量,工序内容,材料,重量 from db_gongxu111 where  接单编号='" + dt.Rows[i]["接单编号"] + "'";
        //        DataTable jiage = sqlhelp1.GetDataTable(sql, CommandType.Text);
        //        for (int j = 0; j < jiage.Rows.Count; j++)
        //        {
        //            double shuliang = Convert.ToDouble(jiage.Rows[j]["机修件数量"]);
        //            string jiage1 = Convert.ToString(jiage.Rows[j]["价格"]);
        //            if (jiage1 != "")
        //            {
        //                zongjia += Convert.ToDouble(jiage.Rows[j]["价格"]) * (shuliang);
        //            }
        //            mingxi += jiage.Rows[j]["工序内容"].ToString() + "|";
        //            if (j < 4)
        //            {
        //                dt.Rows[i]["材料" + (j + 1)] = jiage.Rows[j]["材料"];
        //                dt.Rows[i]["重量" + (j + 1)] = jiage.Rows[j]["重量"];
        //            }
        //        }
        //        dt.Rows[i]["价格"] = zongjia;
        //        dt.Rows[i]["明细"] = mingxi;
        //    }
        //    dataGridViewX1.DataSource = dt;
        //} 
        #endregion
        #region 查询
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //string shijian = dateTimeInput1.Value.ToString("yyyy-MM-dd 00:00:000");
            //MessageBox.Show(shijian + shijian2); 
            //DateTime a = dateTimeInput1.Value.AddDays(1);
            //string shijian2 = a.ToString("yyyy-MM-dd 00:00:000");
            string shijian =dateRiqi.Text.ToString();
            DateTime a = dateRiqi.DateTime.AddDays(1);
            string shijian2 = Convert.ToString(a);
            string sql1 = "select id,接单编号,客户名称,部门,工件名称,加工内容,计量单位,机修件数量,接单日期,预交时间,联系人,责任人,加工单位备注,当前状态,生产部确认,生产部确认时间 from  tb_caigouliaodan  where  机修件数量 is not null and 加工单位备注='自制' and 生产部确认=1 and 生产部确认时间>'" + shijian + "' and 生产部确认时间<'" + shijian2 + "' ";
            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            dt.Columns.Add("价格");
            dt.Columns.Add("明细");
            dt.Columns.Add("材料1");
            dt.Columns.Add("重量1");
            dt.Columns.Add("材料2");
            dt.Columns.Add("重量2");
            dt.Columns.Add("材料3");
            dt.Columns.Add("重量3");
            dt.Columns.Add("材料4");
            dt.Columns.Add("重量4");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                mingxi = "";
                zongjia = 0;
                string sql = "  Select 价格,机修件数量,工序内容,材料,重量 from db_gongxu111 where  接单编号='" + dt.Rows[i]["接单编号"] + "'";
                DataTable jiage = sqlhelp1.GetDataTable(sql, CommandType.Text);
                for (int j = 0; j < jiage.Rows.Count; j++)
                {
                    double shuliang = Convert.ToDouble(jiage.Rows[j]["机修件数量"]);
                    string jiage1 = Convert.ToString(jiage.Rows[j]["价格"]);
                    if (jiage1 != "")
                    {
                        zongjia += Convert.ToDouble(jiage.Rows[j]["价格"]) * (shuliang);
                    }
                    mingxi += jiage.Rows[j]["工序内容"].ToString() + "|";
                    if (j < 4)
                    {
                        dt.Rows[i]["材料" + (j + 1)] = jiage.Rows[j]["材料"];
                        dt.Rows[i]["重量" + (j + 1)] = jiage.Rows[j]["重量"];
                    }
                }
                dt.Rows[i]["价格"] = zongjia;
                dt.Rows[i]["明细"] = mingxi;
            }
            gridControl1.DataSource = dt;
            gridView1.Columns["id"].Visible = false;
           // dataGridViewX1.DataSource = dt;
        }
        #endregion
        #region GridView显示列表序号
        /// <summary>
        /// GridView显示列表序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
        #endregion

        #region 导出EXECEL表
        private void btnDaochuExecel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel文件(*.xls)|*.xls";
            sfd.Title = "导出Execel";
            DialogResult dialoResult = sfd.ShowDialog(this);
            if (dialoResult==DialogResult.OK)
            {
                DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                gridControl1.ExportToXls(sfd.FileName);
                DevExpress.XtraEditors.XtraMessageBox.Show("导出成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        } 
        #endregion
    }
}
