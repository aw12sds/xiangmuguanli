using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace 项目管理系统.生产部
{
    public partial class Frjijiagongtongji : Form
    {
        public Frjijiagongtongji()
        {
            InitializeComponent();
        }
        public string yonghu;
        private void Frjijiagongtongji_Load(object sender, EventArgs e)
        {

        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            Frxinzengtongji form1 = new Frxinzengtongji();
            form1.yonghu = yonghu;

            form1.ShowDialog();
        }

        #region 查询该日统计时间
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (dateEdit1.Text.ToString() == "")
            {

                MessageBox.Show("请输入日期再查询！");
                return;
            }

            string shijian1 = dateEdit1.Text.ToString();
            DateTime dateTime = Convert.ToDateTime(shijian1);
            DateTime a = dateTime.AddDays(1);
            string shijian2 = a.ToString("yyyy-MM-dd 00:00:000");
            string sql1 = "select *  from  tb_yixianbaobiao  where 完成日期>= '" + shijian1 + "' and  完成日期< '" + shijian2 + "' ";
            gridControl4.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridView4.Columns["id"].Visible = false;
            gridView4.Columns["记录人"].Visible = false;
            gridView4.Columns["记录时间"].Visible = false;

        } 
        #endregion

        private void gridView4_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }

        private void 删除该条记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (yonghu == "王兆平" || yonghu == "黄霞")
            {
                string id = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id"));
                string sql = "delete from tb_yixianbaobiao where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);
                MessageBox.Show("删除成功！");
                string shijian = Convert.ToDateTime(dateEdit1.Text.ToString()).ToString("yyyy-MM-dd 00:00:000");
                DateTime a = Convert.ToDateTime(dateEdit1.Text.ToString()).AddDays(1);
                string shijian2 = a.ToString("yyyy-MM-dd 00:00:000");
                string sql1 = "select *  from  tb_yixianbaobiao  where 完成日期>= '" + shijian + "' and  完成日期< '" + shijian2 + "' ";
                gridControl4.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
            }
        }

        #region 查询改时间段
        private void simpleButton2_Click(object sender, EventArgs e)
        {

            if (Convert.ToDateTime(dateEdit2.Text.ToString()) > Convert.ToDateTime(dateEdit3.Text.ToString()))
            {
                MessageBox.Show("开始时间不能大于结束时间！");
                return;
            }

            string sql1 = "select *  from  tb_yixianbaobiao  where 完成日期>= '" + dateEdit2.Text.ToString() + "' and  完成日期<= '" + dateEdit3.Text.Trim() + "' ";
            gridControl4.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridView4.Columns["id"].Visible = false;
            gridView4.Columns["记录人"].Visible = false;
            gridView4.Columns["记录时间"].Visible = false;
        } 
        #endregion

        //private void buttonItem2_Click(object sender, EventArgs e)
        //{
        //    if (gridView4.RowCount == 0)
        //    {
        //        MessageBox.Show("请先查询到记录再生成统计表!");
        //        return;
        //    }
        //    TimeSpan a = dateTimeInput3.Value.AddDays(1) - dateTimeInput2.Value;
            
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("姓名");
        //    DataTable dtttt = new DataTable();
        //    dtttt.Columns.Add("日期");
        //    dtttt.Columns.Add("金额");
        //    for (int i = 0; i < a.Days; i++)
        //    {
        //        DateTime c = dateTimeInput2.Value.AddDays(i);
        //        string d = c.ToString("m");
        //        dt.Columns.Add(d);
        //        dtttt.Rows.Add();
        //        dtttt.Rows[i]["日期"] = d;
        //    }
           
        //    string sql1 = "select * from tb_operator where 机加工=1";
        //    DataTable dttt = sqlhelp111.GetDataTable(sql1, CommandType.Text);
        //    for (int j = 0; j < dttt.Rows.Count; j++)
        //    {
        //        string fuzeren = dttt.Rows[j]["用户名"].ToString();
        //        dt.Rows.Add();
        //        dt.Rows[j]["姓名"] = fuzeren;
        //        for (int i = 0; i < a.Days; i++)
        //        {
        //            DateTime c = dateTimeInput2.Value.AddDays(i);
        //            string d = c.Date.ToString();
        //            string f = c.ToString("m");
        //            string sql = "select * from tb_yixianbaobiao where 完成人='" + fuzeren + "' and 完成日期='" + d + "'";
        //            DataTable dtt = SQLhelp.GetDataTable(sql, CommandType.Text);

        //            if (dtt.Rows.Count == 0)
        //            {
        //                dt.Rows[j][f] = 0;


        //            }
        //            if (dtt.Rows.Count > 0)
        //            {
        //                double aaa = 0;
        //                for (int n = 0; n < dtt.Rows.Count; n++)
        //                {
        //                    aaa += Convert.ToDouble(dtt.Rows[n]["总薪酬"]);

        //                    dt.Rows[j][f] = aaa;

        //                }
        //            }

        //        }
        //    }
        //    dt.Columns.Add("汇总");
        //    for (int t = 0; t < dtttt.Rows.Count; t++)
        //    {
        //        double aaa = 0;

        //        for (int z = 0; z < dt.Rows.Count; z++)
        //        {
        //            aaa += Convert.ToDouble(dt.Rows[z][t + 1]);

        //        }

        //        dtttt.Rows[t]["金额"] = aaa;

        //    }
           
        //    for (int aaaa =0; aaaa < dt.Rows.Count; aaaa++)
        //    {
        //        double huizong = 0;

        //        for (int z =1; z < dt.Columns.Count-1; z++)
        //        {
        //            huizong += Convert.ToDouble(dt.Rows[aaaa][z]);

        //        }

        //        dt.Rows[aaaa]["汇总"] = huizong;

        //    }


        //    Frtongjibiao form1 = new Frtongjibiao();
        //    form1.dt = dt;
        //    form1.dttt = dtttt;
        //    form1.dtt = dtttt;
        //    form1.ShowDialog();
        //}

        #region 新增统计
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Frxinzengtongji form1 = new Frxinzengtongji();
            form1.yonghu = yonghu;
            form1.ShowDialog();
        } 
        #endregion
        #region 生成统计表
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (gridView4.RowCount == 0)
            {
                MessageBox.Show("请先查询到记录再生成统计表!");
                return;
            }
            string strtime2 = dateEdit2.Text.ToString();//字符串时间2
            string strtime3 = dateEdit3.Text.ToString();//字符串时间3
            DateTime datetime2 = Convert.ToDateTime(strtime2);//日期时间格式2
            DateTime datetime3 = Convert.ToDateTime(strtime3);//日期时间格式3
            TimeSpan a = datetime3.AddDays(1) -datetime2;//时间间隔
            DataTable dt = new DataTable();
            dt.Columns.Add("姓名");
            DataTable dtttt = new DataTable();
            dtttt.Columns.Add("日期");
            dtttt.Columns.Add("金额");
            for (int i = 0; i < a.Days; i++)
            {
                DateTime c = datetime2.AddDays(i);
                string d = c.ToString("m");
                dt.Columns.Add(d);
                dtttt.Rows.Add();
                dtttt.Rows[i]["日期"] = d;
            }

            string sql1 = "select * from tb_operator where 机加工=1";
            DataTable dttt = sqlhelp111.GetDataTable(sql1, CommandType.Text);
            for (int j = 0; j < dttt.Rows.Count; j++)
            {
                string fuzeren = dttt.Rows[j]["用户名"].ToString();
                dt.Rows.Add();
                dt.Rows[j]["姓名"] = fuzeren;
                for (int i = 0; i < a.Days; i++)
                {
                    DateTime c = datetime2.AddDays(i);
                    string d = c.Date.ToString();
                    string f = c.ToString("m");
                    string sql = "select * from tb_yixianbaobiao where 完成人='" + fuzeren + "' and 完成日期='" + d + "'";
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

            Frtongjibiao form1 = new Frtongjibiao();
            form1.dt = dt;
            form1.dttt = dtttt;
            form1.dtt = dtttt;
            form1.ShowDialog();
        } 
        #endregion

    }
}
