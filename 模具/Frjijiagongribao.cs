using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using 项目管理系统.生产部;

namespace 项目管理系统.模具
{
    public partial class Frjijiagongribao : DevExpress.XtraEditors.XtraForm
    {
        public string yonghu;
        public Frjijiagongribao()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 新增统计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonItem1_Click(object sender, EventArgs e)
        {
            Frxinzengtongjimuju form1 = new Frxinzengtongjimuju();
            form1.yonghu = yonghu;

            form1.ShowDialog();
        }

        /// <summary>
        /// 生成统计表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonItem2_Click(object sender, EventArgs e)
        {
            if (gridView4.RowCount == 0)
            {
                MessageBox.Show("请先查询到记录再生成统计表!");
                return;
            }
            if(dateTimeInput3.Text == "")
            {
                MessageBox.Show("请先输入时间前段!", "提示");
                return;
            }
            if(dateTimeInput2.Text == "")
            {
                MessageBox.Show("请先输入时间后段！", "提示");
                return;
            }

            TimeSpan a = dateTimeInput3.Value.AddDays(1) - dateTimeInput2.Value;

            DataTable dt = new DataTable();
            dt.Columns.Add("姓名");
            DataTable dtttt = new DataTable();
            dtttt.Columns.Add("日期");
            dtttt.Columns.Add("金额");
            for (int i = 0; i < a.Days; i++)
            {
                DateTime c = dateTimeInput2.Value.AddDays(i);
                string d = c.ToString("m");
                dt.Columns.Add(d);
                dtttt.Rows.Add();
                dtttt.Rows[i]["日期"] = d;
            }

            string sql1 = "select * from tb_personList";
            DataTable dttt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            for (int j = 0; j < dttt.Rows.Count; j++)
            {
                string fuzeren = dttt.Rows[j]["Name"].ToString();
                dt.Rows.Add();
                dt.Rows[j]["姓名"] = fuzeren.Replace("\r\n","");
                for (int i = 0; i < a.Days; i++)
                {
                    DateTime c = dateTimeInput2.Value.AddDays(i);
                    string d = c.Date.ToString();
                    string f = c.ToString("m");
                    string sql = "select * from tb_yixianbaobiaomuju where 完成人='" + fuzeren + "' and 完成日期='" + d + "'";
                    DataTable dtt = SQLhelp.GetDataTable(sql, CommandType.Text);

                    if (dtt.Rows.Count == 0)
                    {
                        dt.Rows[j][f] = 0;


                    }
                    if (dtt.Rows.Count > 0)
                    {
                        double aaa = 0;
                        for (int n = 0; n < dtt.Rows.Count; n++)
                        {
                            aaa += Convert.ToDouble(dtt.Rows[n]["总薪酬"]);

                            dt.Rows[j][f] = aaa;

                        }
                    }

                }
            }
            dt.Columns.Add("汇总");
            for (int t = 0; t < dtttt.Rows.Count; t++)
            {
                double aaa = 0;

                for (int z = 0; z < dt.Rows.Count; z++)
                {
                    aaa += Convert.ToDouble(dt.Rows[z][t + 1]);

                }

                dtttt.Rows[t]["金额"] = aaa;

            }

            for (int aaaa = 0; aaaa < dt.Rows.Count; aaaa++)
            {
                double huizong = 0;

                for (int z = 1; z < dt.Columns.Count - 1; z++)
                {
                    huizong += Convert.ToDouble(dt.Rows[aaaa][z]);

                }

                dt.Rows[aaaa]["汇总"] = huizong;

            }


            Frtongjibiaomuju form1 = new Frtongjibiaomuju();
            form1.dt = dt;
            form1.dttt = dtttt;
            form1.dtt = dtttt;
            form1.ShowDialog();
        }

        /// <summary>
        /// 查询该日的统计记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (dateTimeInput1.Text == "")
            {

                MessageBox.Show("请输入日期再查询！");
                return;
            }
            string shijian = dateTimeInput1.Value.ToString("yyyy-MM-dd 00:00:000");
            DateTime a = dateTimeInput1.Value.AddDays(1);
            string shijian2 = a.ToString("yyyy-MM-dd 00:00:000");
            string sql1 = "select *  from  tb_yixianbaobiaomuju  where 完成日期>= '" + shijian + "' and  完成日期< '" + shijian2 + "' ";
            gridControl4.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridView4.Columns["id"].Visible = false;
            gridView4.Columns["记录人"].Visible = false;
            gridView4.Columns["记录时间"].Visible = false;
        }

        /// <summary>
        /// 查询该时间段
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(dateTimeInput2.Text) > Convert.ToDateTime(dateTimeInput3.Text))
            {
                MessageBox.Show("开始时间不能大于结束时间！");
                return;
            }

            string sql1 = "select *  from  tb_yixianbaobiaomuju  where 完成日期>= '" + dateTimeInput2.Value + "' and  完成日期<= '" + dateTimeInput3.Value + "' ";
            gridControl4.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridView4.Columns["id"].Visible = false;
            gridView4.Columns["记录人"].Visible = false;
            gridView4.Columns["记录时间"].Visible = false;
        }

        private void 删除该条记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (yonghu == "邹春光")
            {
                string id = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id"));
                string sql = "delete from tb_yixianbaobiaomuju where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);
                MessageBox.Show("删除成功！");
                string shijian = dateTimeInput1.Value.ToString("yyyy-MM-dd 00:00:000");
                DateTime a = dateTimeInput1.Value.AddDays(1);
                string shijian2 = a.ToString("yyyy-MM-dd 00:00:000");
                string sql1 = "select *  from  tb_yixianbaobiaomuju  where 完成日期>= '" + shijian + "' and  完成日期< '" + shijian2 + "' ";
                gridControl4.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
            }
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