using Aspose.Cells;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraTab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 项目管理系统.项目总览;
using DevExpress.XtraCharts;

namespace 项目管理系统
{
    public partial class Form2 : XtraForm
    {
        public Form2()
        {
            InitializeComponent();

        }
        public string yonghu;   
        public string gonglinghao;
        public string xiangmu;
        public string shebei;
        public DataTable dt;
        public string shijian;
        public string shuliang11;
        public int a;
        public string name;
        public string mingcheng;
       
        private long fileSize = 0;//文件大小
        private string fileName = null;//文件名字
        private string fileType = null;//文件类型
        private byte[] files;//文件
        private BinaryReader read = null;//二进制读取


        private void Form2_Load(object sender, EventArgs e)
        {
            string sql = "select * from tb_xiangmushu where id=1";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            tileBarItem1.Text = "项目总数：" + dt.Rows[0]["产线项目总数"].ToString();
            tileBarItem2.Text = "正常项目：" + dt.Rows[0]["产线正常项目"].ToString();
            tileBarItem3.Text = "延期项目：" + dt.Rows[0]["产线延期项目"].ToString();
            tileBarItem4.Text = "已交货项目：" + dt.Rows[0]["产线完成项目"].ToString();
            tileBarItem5.Text = "维修项目：" + dt.Rows[0]["维修项目"].ToString();
            tileBarItem6.Text = "取消项目：" + dt.Rows[0]["取消项目"].ToString();
            tileBarItem19.Text = "项目总数：" + dt.Rows[0]["零件项目总数"].ToString();
            tileBarItem20.Text = "正常项目：" + dt.Rows[0]["零件正常项目"].ToString();
            tileBarItem21.Text = "延期项目：" + dt.Rows[0]["零件延期项目"].ToString();
            tileBarItem22.Text = "已完成项目：" + dt.Rows[0]["零件完成项目"].ToString();
            tileBarItem23.Text = "项目总数：" + dt.Rows[0]["零件完成项目"].ToString();
            tileBarItem24.Text = "正常项目：" + dt.Rows[0]["研发正常项目"].ToString();
            tileBarItem25.Text = "延期项目：" + dt.Rows[0]["研发延期项目"].ToString();
            tileBarItem26.Text = "已交货项目：" + dt.Rows[0]["研发完成项目"].ToString();
            string sqlzhengchang = "select id,工作令号,项目名称,客户名称,交货日期,反馈,项目负责人,采购负责人,装配负责人,完成进度  from tb_xiangmu  where  维修 is null and 研发项目 is null and 未交货项目=1 and 交货日期>'" + DateTime.Now + "'";
            DataTable dtt = SQLhelp.GetDataTable(sqlzhengchang, CommandType.Text);
            for (int i = 0; i < dtt.Rows.Count; i++)
            {
                string gonglinghao = dtt.Rows[i]["客户名称"].ToString();
                string jikuhumingcheng = dtt.Rows[i]["交货日期"].ToString();
                string riqi = Convert.ToDateTime(jikuhumingcheng).ToString("yyyy-MM-dd");
                string aaaaa = dtt.Rows[i]["工作令号"].ToString().Trim();
                dtt.Rows[i]["工作令号"] = aaaaa + "                " + "客户名称：" + gonglinghao + "               " + "交货日期：" + riqi;
            }
            gridControl1.DataSource = dtt;
            string sqlyanqi = "select id,工作令号,项目名称,客户名称,交货日期,反馈,项目负责人,采购负责人,装配负责人,完成进度  from tb_xiangmu  where  维修 is null and 研发项目 is null and 未交货项目=1 and 交货日期<'" + DateTime.Now + "'";

            DataTable sqlyanqi1 = SQLhelp.GetDataTable(sqlyanqi, CommandType.Text);
            for (int i = 0; i < sqlyanqi1.Rows.Count; i++)
            {
                string gonglinghao = sqlyanqi1.Rows[i]["客户名称"].ToString();
                string jikuhumingcheng = sqlyanqi1.Rows[i]["交货日期"].ToString();
                string riqi = Convert.ToDateTime(jikuhumingcheng).ToString("yyyy-MM-dd");
                string aaaaa = sqlyanqi1.Rows[i]["工作令号"].ToString().Trim();
                sqlyanqi1.Rows[i]["工作令号"] = aaaaa + "                " + "客户名称：" + gonglinghao + "               " + "交货日期：" + riqi;
            }

            gridControl2.DataSource = sqlyanqi1;
            string sqlyanqi3 = "select id,工作令号,项目名称,客户名称,交货日期,反馈,项目负责人,采购负责人,装配负责人,完成进度  from tb_xiangmu  where  维修 is null and 研发项目 is null and 已交货未调试项目=1";

            DataTable sqlyanqi33 = SQLhelp.GetDataTable(sqlyanqi3, CommandType.Text);
            for (int i = 0; i < sqlyanqi33.Rows.Count; i++)
            {
                string gonglinghao = sqlyanqi33.Rows[i]["客户名称"].ToString();
                string jikuhumingcheng = sqlyanqi33.Rows[i]["交货日期"].ToString();
                string riqi = Convert.ToDateTime(jikuhumingcheng).ToString("yyyy-MM-dd");
                string aaaaa = sqlyanqi33.Rows[i]["工作令号"].ToString().Trim();
                sqlyanqi33.Rows[i]["工作令号"] = aaaaa + "                " + "客户名称：" + gonglinghao + "               " + "交货日期：" + riqi;
            }
            gridControl3.DataSource = sqlyanqi33;

            string sqlyanqi4 = "select id,工作令号,项目名称,客户名称,交货日期,反馈,项目负责人,采购负责人,装配负责人,完成进度  from tb_xiangmu where 维修=1 ";
            DataTable sqlyanqi44 = SQLhelp.GetDataTable(sqlyanqi4, CommandType.Text);
            gridControl4.DataSource = sqlyanqi44;
            gridView10.Columns["id"].Visible = false;


            string sqlyanqi5 = "select id,工作令号,项目名称,客户名称,交货日期,反馈,项目负责人,采购负责人,装配负责人,完成进度  from tb_xiangmu where 取消项目=1 ";
            DataTable sqlyanqi55 = SQLhelp.GetDataTable(sqlyanqi5, CommandType.Text);
            gridControl5.DataSource = sqlyanqi55;
            gridView13.Columns["id"].Visible = false;

            string sqlyanqi6 = "select  id,接单日期,工作令号,工件名称,加工内容,机修件数量,当前状态,预交时间 from  tb_caigouliaodan where  料单类型='机修件'  and 机修与模具交货时间>'" + DateTime.Now + "' and 完成='未完成'";
            DataTable sqlyanqi66 = SQLhelp.GetDataTable(sqlyanqi6, CommandType.Text);
            gridControl6.DataSource = sqlyanqi66;
            gridView16.Columns["id"].Visible = false;


            string sqlyanqi7 = "select  id,接单日期,工作令号,工件名称,加工内容,机修件数量,当前状态,预交时间 from  tb_caigouliaodan where   料单类型='机修件'  and 机修与模具交货时间<'" + DateTime.Now + "' and 完成='未完成'";
            DataTable sqlyanqi77 = SQLhelp.GetDataTable(sqlyanqi7, CommandType.Text);
            gridControl7.DataSource = sqlyanqi77;
            gridView18.Columns["id"].Visible = false;


            string sqlyanqi8 = "select  id,接单日期,工作令号,工件名称,加工内容,机修件数量,当前状态,预交时间  from  tb_caigouliaodan where  料单类型='机修件'  and 完成='完成'";
            DataTable sqlyanqi88 = SQLhelp.GetDataTable(sqlyanqi8, CommandType.Text);
            gridControl8.DataSource = sqlyanqi88;
            gridView20.Columns["id"].Visible = false;

            string sqlyanqi9 = "select id,工作令号,项目名称,客户名称,交货日期,反馈,项目负责人,采购负责人,装配负责人,完成进度  from tb_xiangmu where 研发项目=1  and 交货日期>'" + DateTime.Now + "' and 未交货项目=1";
            DataTable sqlyanqi99 = SQLhelp.GetDataTable(sqlyanqi9, CommandType.Text);
            for (int i = 0; i < sqlyanqi99.Rows.Count; i++)
            {
                string gonglinghao = sqlyanqi99.Rows[i]["客户名称"].ToString();
                string jikuhumingcheng = sqlyanqi99.Rows[i]["交货日期"].ToString();
                string riqi = Convert.ToDateTime(jikuhumingcheng).ToString("yyyy-MM-dd");
                string aaaaa = sqlyanqi99.Rows[i]["工作令号"].ToString().Trim();
                sqlyanqi99.Rows[i]["工作令号"] = aaaaa + "                " + "客户名称：" + gonglinghao + "               " + "交货日期：" + riqi;
            }
            gridControl9.DataSource = sqlyanqi99;


            string sqlyanqi10 = "select id,工作令号,项目名称,客户名称,交货日期,反馈,项目负责人,采购负责人,装配负责人,完成进度  from tb_xiangmu where 研发项目=1  and 交货日期<'" + DateTime.Now + "' and 未交货项目=1 ";
            DataTable sqlyanqi110 = SQLhelp.GetDataTable(sqlyanqi10, CommandType.Text);
            for (int i = 0; i < sqlyanqi110.Rows.Count; i++)
            {
                string gonglinghao = sqlyanqi110.Rows[i]["客户名称"].ToString();
                string jikuhumingcheng = sqlyanqi110.Rows[i]["交货日期"].ToString();
                string riqi = Convert.ToDateTime(jikuhumingcheng).ToString("yyyy-MM-dd");
                string aaaaa = sqlyanqi110.Rows[i]["工作令号"].ToString().Trim();
                sqlyanqi110.Rows[i]["工作令号"] = aaaaa + "                " + "客户名称：" + gonglinghao + "               " + "交货日期：" + riqi;
            }
            gridControl10.DataSource = sqlyanqi110;


            string sqlyanqi11 = "select id,工作令号,项目名称,客户名称,交货日期,反馈,项目负责人,采购负责人,装配负责人,完成进度  from tb_xiangmu where 研发项目=1   and 已交货未调试项目=1";
            DataTable sqlyanqi111 = SQLhelp.GetDataTable(sqlyanqi11, CommandType.Text);
            for (int i = 0; i < sqlyanqi111.Rows.Count; i++)
            {
                string gonglinghao = sqlyanqi111.Rows[i]["客户名称"].ToString();
                string jikuhumingcheng = sqlyanqi111.Rows[i]["交货日期"].ToString();
                string riqi = Convert.ToDateTime(jikuhumingcheng).ToString("yyyy-MM-dd");
                string aaaaa = sqlyanqi111.Rows[i]["工作令号"].ToString().Trim();
                sqlyanqi111.Rows[i]["工作令号"] = aaaaa + "                " + "客户名称：" + gonglinghao + "               " + "交货日期：" + riqi;
            }
            gridControl11.DataSource = sqlyanqi111;

            

            string sqllingjian2 = "select count(*)  from tb_xiangmu  where 维修 is null and 研发项目 is null and 未交货项目=1 and 交货日期<'" + DateTime.Now + "'";
            string waixie = SQLhelp.ExecuteScalar(sqllingjian2, CommandType.Text).ToString();

            DataTable bing = new DataTable();
            bing.Columns.Add("name", typeof(string));
            bing.Columns.Add("value", typeof(double));
            DataRow newRow;
            newRow = bing.NewRow();
            newRow["name"] = "延期项目";
            newRow["value"] = waixie;
            bing.Rows.Add(newRow);


            string sqllingjian23 = "select count(*)  from tb_xiangmu  where 维修 is null and 研发项目 is null and 未交货项目=1 and 交货日期>'" + DateTime.Now + "'";
            string waixie1 = SQLhelp.ExecuteScalar(sqllingjian23, CommandType.Text).ToString();
            DataRow newRow1;
            newRow1 = bing.NewRow();
            newRow1["name"] = "正常项目";
            newRow1["value"] = waixie1;
            bing.Rows.Add(newRow1);

            Series Series2 = new Series("种类分布", DevExpress.XtraCharts.ViewType.Pie);
            Series2.ArgumentScaleType = ScaleType.Qualitative;
            Series2.ArgumentDataMember = "name";
            Series2.ValueDataMembers[0] = "value";
            Series2.DataSource = bing;
            Series2.Label.TextPattern = "{A}:{VP:0.00%}";
            chartControl1.Series.Add(Series2);
            chartControl1.ToolTipEnabled = DevExpress.Utils.DefaultBoolean.True;
        



            //string sqllingjian233 = "select count(*)  from tb_xiangmu  where 维修 is null and 研发项目 is null and 未交货项目=1 and 交货日期<'" + DateTime.Now + "'";
            //string waixie33 = SQLhelp.ExecuteScalar(sqllingjian233, CommandType.Text).ToString();

            //DataTable bing = new DataTable();
            //bing.Columns.Add("name", typeof(string));
            //bing.Columns.Add("value", typeof(double));
            //DataRow newRow;
            //newRow = bing.NewRow();
            //newRow["name"] = "延期项目";
            //newRow["value"] = waixie;
            //bing.Rows.Add(newRow);


            //string sqllingjian23 = "select count(*)  from tb_xiangmu  where 维修 is null and 研发项目 is null and 未交货项目=1 and 交货日期>'" + DateTime.Now + "'";
            //string waixie1 = SQLhelp.ExecuteScalar(sqllingjian23, CommandType.Text).ToString();
            //DataRow newRow1;
            //newRow1 = bing.NewRow();
            //newRow1["name"] = "正常项目";
            //newRow1["value"] = waixie1;
            //bing.Rows.Add(newRow1);

            //Series Series2 = new Series("种类分布", DevExpress.XtraCharts.ViewType.Pie);
            //Series2.ArgumentScaleType = ScaleType.Qualitative;
            //Series2.ArgumentDataMember = "name";
            //Series2.ValueDataMembers[0] = "value";
            //Series2.DataSource = bing;

            //chartControl1.Series.Add(Series2);
            //chartControl1.ToolTipEnabled = DevExpress.Utils.DefaultBoolean.True;


        }



        private void 确认为最终完成项目ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //    string a = "";
            //    string b = Convert.ToString(this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "工作令号"));
            //    if (b.Length > 5)
            //    {
            //        string bb = b.Substring(0, 20);
            //        a = bb.Trim();
            //    }
            //    if (a != "")
            //    {
            //        if (yonghu == "韩小建" || yonghu == "徐魏魏" || yonghu == "蔡红兵")
            //        {
            //            if (MessageBox.Show("确认提交吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            //            {
            //                string id = this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "id").ToString();
            //                string sql = "update tb_xiangmu set 已交货未调试项目 =NULL , 验收通过项目=1 where id='" + id + "'";
            //                SQLhelp.ExecuteScalar(sql, CommandType.Text);
            //                MessageBox.Show("确认成功！");
            //                Reload();
            //                Reload2();
            //                Reload3();
            //                Reload4();
            //            }
            //        }
            //        else
            //        {

            //            MessageBox.Show("无权限！");
            //            return;
            //        }
            //    }
        }


        private void yanfazhengchangshu_ItemClick(object sender, TileItemEventArgs e)
        {
            panel4.Controls.Clear();
            string sql = "select id,工作令号,项目名称,客户名称,交货日期,反馈,项目负责人,采购负责人,装配负责人,完成进度  from tb_xiangmu where 研发项目=1  and 交货日期>'" + DateTime.Now + "'";
            Frkongjian1 form1 = new Frkongjian1();
            form1.dtt = SQLhelp.GetDataTable(sql, CommandType.Text);
            form1.Dock = DockStyle.Fill;
            panel4.Controls.Add(form1);
        }

        private void yanfayanqizongshu_ItemClick(object sender, TileItemEventArgs e)
        {
            panel4.Controls.Clear();
            string sql = "select id,工作令号,项目名称,客户名称,交货日期,反馈,项目负责人,采购负责人,装配负责人,完成进度  from tb_xiangmu where 研发项目=1  and 交货日期<'" + DateTime.Now + "'";
            Frkongjian1 form1 = new Frkongjian1();
            form1.dtt = SQLhelp.GetDataTable(sql, CommandType.Text);
            form1.Dock = DockStyle.Fill;
            panel4.Controls.Add(form1);
        }

        private void yanfayijiaohuo_ItemClick(object sender, TileItemEventArgs e)
        {
            panel4.Controls.Clear();
            string sql = "select id,工作令号,项目名称,客户名称,交货日期,反馈,项目负责人,采购负责人,装配负责人,完成进度  from tb_xiangmu where 研发项目=1   and 已交货未调试项目=1";
            Frkongjian1 form1 = new Frkongjian1();
            form1.dtt = SQLhelp.GetDataTable(sql, CommandType.Text);
            form1.Dock = DockStyle.Fill;
            panel4.Controls.Add(form1);
        }

        private void tileBarItem1_ItemClick(object sender, TileItemEventArgs e)
        {
            panel4.Controls.Clear();
            //string sql = "select id,工作令号,项目名称,客户名称,交货日期,反馈,项目负责人,采购负责人,装配负责人,完成进度  from tb_xiangmu where 维修=1 ";
            //Frkongjian1 form1 = new Frkongjian1();
            //form1.dtt = SQLhelp.GetDataTable(sql, CommandType.Text);
            //form1.Dock = DockStyle.Fill;
            //panel4.Controls.Add(form1);
        }

        private void zhengchangzongshu_ItemClick(object sender, TileItemEventArgs e)
        {
            panel4.Controls.Clear();
            string sql = "select  id,工作令号,项目名称,名称,型号,编码,实际采购数量,机修与模具交货时间 from  tb_caigouliaodan where  (料单类型='机修件'  and 机修与模具交货时间>'" + DateTime.Now + "' and 机修与模具完成 is  null) or (料单类型='模具部' and 机修与模具交货时间>'" + DateTime.Now + "' and 机修与模具完成 is  null)";
            Frkongjian2 form1 = new Frkongjian2();
            form1.dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            form1.Dock = DockStyle.Fill;
            panel4.Controls.Add(form1);
        }

        private void yanqizongshu_ItemClick(object sender, TileItemEventArgs e)
        {
            panel4.Controls.Clear();
            string sql = "select id,工作令号,项目名称,名称,型号,编码,实际采购数量,机修与模具交货时间   from  tb_caigouliaodan where  (料单类型='机修件' and 机修与模具交货时间<'" + DateTime.Now + "' and 机修与模具完成 is  null) or  (料单类型='模具部' and 机修与模具交货时间<'" + DateTime.Now + "' and 机修与模具完成 is  null) ";
            Frkongjian2 form1 = new Frkongjian2();
            form1.dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            form1.Dock = DockStyle.Fill;
            panel4.Controls.Add(form1);
        }

        private void yijiaozongshu_ItemClick(object sender, TileItemEventArgs e)
        {
            panel4.Controls.Clear();
            string sql = "select  id,工作令号,项目名称,名称,型号,编码,实际采购数量,机修与模具交货时间   from  tb_caigouliaodan where  (料单类型='机修件'  and 机修与模具完成 is not null) or  (料单类型='模具部'  and 机修与模具完成 is not  null) ";
            Frkongjian2 form1 = new Frkongjian2();
            form1.dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            form1.Dock = DockStyle.Fill;
            panel4.Controls.Add(form1);
        }

        private void quxiaoxiangmu_ItemClick(object sender, TileItemEventArgs e)
        {
            //panel4.Controls.Clear();
            //string sql = "select id,工作令号,项目名称,客户名称,交货日期,反馈,项目负责人,采购负责人,装配负责人,完成进度  from tb_xiangmu where 取消项目=1 ";
            //Frkongjian1 form1 = new Frkongjian1();
            //form1.dtt = SQLhelp.GetDataTable(sql, CommandType.Text);
            //form1.Dock = DockStyle.Fill;
            //panel4.Controls.Add(form1);
        }



        private void tileBarItem2_ItemClick(object sender, TileItemEventArgs e)
        {

        }

        private void 查看合同ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }
            string a = "";
            string b = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号"));
            if (b.Length > 5)
            {
                string bb = b.Substring(0, 20);
                a = bb.Trim();
            }
            if (a != "")
            {
                string gongzuolingaho = a;
                string xiangmumingcheng = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "项目名称").ToString();

                string sql1 = "Select 合同类型 From tb_xiangmu  Where 工作令号='" + gongzuolingaho + "' and  项目名称='" + xiangmumingcheng + "' ";
                string hetongleixing = SQLhelp.ExecuteScalar(sql1, CommandType.Text).ToString();

                string sql2 = "Select 合同名称 From tb_xiangmu  Where 工作令号='" + gongzuolingaho + "' and  项目名称='" + xiangmumingcheng + "' ";
                string hetongmingcheng = SQLhelp.ExecuteScalar(sql2, CommandType.Text).ToString();

                string sql = "Select 合同 From tb_xiangmu  Where 工作令号='" + gongzuolingaho + "' and  项目名称='" + xiangmumingcheng + "' ";
                byte[] mypdffile = null;
                mypdffile = SQLhelp.duqu(sql, CommandType.Text);


                string aaaa = System.Environment.CurrentDirectory;
                string lujing = aaaa + "\\" + hetongmingcheng + "." + hetongleixing;
                FileStream fs = new FileStream(lujing, FileMode.Create);
                fs.Write(mypdffile, 0, mypdffile.Length);
                fs.Flush();
                fs.Close();
                System.Diagnostics.Process.Start(lujing);
            }
        }

        private void 查看里程碑计划表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }
            string a = "";
            string b = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号"));
            if (b.Length > 5)
            {
                string bb = b.Substring(0, 20);
                a = bb.Trim();
            }
            if (a != "")
            {
                string gongzuolingaho = a;
                string xiangmumingcheng = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "项目名称").ToString();
                string sql1 = "Select 里程碑计划表类型 From tb_xiangmu  Where 工作令号='" + gongzuolingaho + "' and  项目名称='" + xiangmumingcheng + "' ";
                string hetongleixing = SQLhelp.ExecuteScalar(sql1, CommandType.Text).ToString();
                string sql2 = "Select 里程碑计划表名称 From tb_xiangmu  Where 工作令号='" + gongzuolingaho + "' and  项目名称='" + xiangmumingcheng + "' ";
                string hetongmingcheng = SQLhelp.ExecuteScalar(sql2, CommandType.Text).ToString();
                string sql = "Select 里程碑计划表 From tb_xiangmu  Where 工作令号='" + gongzuolingaho + "' and  项目名称='" + xiangmumingcheng + "' ";
                byte[] mypdffile = null;
                mypdffile = SQLhelp.duqu(sql, CommandType.Text);
                string aaaa = System.Environment.CurrentDirectory;
                string lujing = aaaa + "\\" + hetongmingcheng + "." + hetongleixing;
                FileStream fs = new FileStream(lujing, FileMode.Create);
                fs.Write(mypdffile, 0, mypdffile.Length);
                fs.Flush();
                fs.Close();
                System.Diagnostics.Process.Start(lujing);
            }
        }

        private void 下载生产任务书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }
            string a = "";
            string b = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号"));
            if (b.Length > 5)
            {
                string bb = b.Substring(0, 20);
                a = bb.Trim();
            }
            if (a != "")
            {
                string gongzuolingaho = a;
                string xiangmumingcheng = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "项目名称").ToString();

                string sql1 = "Select 生产任务书类型 From tb_xiangmu  Where 工作令号='" + gongzuolingaho + "' and  项目名称='" + xiangmumingcheng + "' ";
                string hetongleixing = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));
                if (hetongleixing == "")
                {
                    MessageBox.Show("没有生产任务书！");
                    return;
                }
                string sql2 = "Select 生产任务书名称 From tb_xiangmu  Where 工作令号='" + gongzuolingaho + "' and  项目名称='" + xiangmumingcheng + "' ";
                string hetongmingcheng = SQLhelp.ExecuteScalar(sql2, CommandType.Text).ToString();
                string sql = "Select 生产任务书 From tb_xiangmu  Where 工作令号='" + gongzuolingaho + "' and  项目名称='" + xiangmumingcheng + "' ";
                byte[] mypdffile = null;
                mypdffile = SQLhelp.duqu(sql, CommandType.Text);
                string aaaa = System.Environment.CurrentDirectory;
                string lujing = aaaa + "\\" + hetongmingcheng + "." + hetongleixing;
                FileStream fs = new FileStream(lujing, FileMode.Create);
                fs.Write(mypdffile, 0, mypdffile.Length);
                fs.Flush();
                fs.Close();
                System.Diagnostics.Process.Start(lujing);
            }

        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {

        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
            {
                string a = "";
                string b = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号"));
                if (b.Length > 5)
                {
                    string bb = b.Substring(0, 20);
                    a = bb.Trim();
                }
                if (a != "")
                {
                    Frdashujv form = new Frdashujv();
                    form.gongzuolinghao = a;
                    form.xiangmumingcheng = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "项目名称").ToString();

                    form.ShowDialog();
                }
            }

        }

        private void 查看指示项ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string a = "";
            string b = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号"));
            if (b.Length > 5)
            {
                string bb = b.Substring(0, 20);
                a = bb.Trim();
            }
            if (a != "")
            {
                FrFankuixiangxi form = new FrFankuixiangxi();
                form.gongzuolinghao = a;
                form.xiangmumingcheng = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "项目名称").ToString();
                form.yonghu = yonghu;
                form.ShowDialog();

            }
        }

        private void 确认完成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string a = "";
            string b = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号"));
            if (b.Length > 5)
            {
                string bb = b.Substring(0, 20);
                a = bb.Trim();
            }
            if (a != "")
            {
                if (yonghu == "韩小建" || yonghu == "徐魏魏" || yonghu == "蔡红兵")
                {
                    if (MessageBox.Show("确认提交吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
                        string sql = "update tb_xiangmu set 未交货项目 =NULL , 已交货未调试项目=1 where id='" + id + "'";
                        SQLhelp.ExecuteScalar(sql, CommandType.Text);
                        MessageBox.Show("确认成功！");

                        //Reload2();
                        //Reload3();
                        //Reload4();
                    }
                }
                else
                {

                    MessageBox.Show("无权限！");
                    return;
                }
            }
        }

        private void 上传项目清单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string a = "";
            string b = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号"));
            if (b.Length > 5)
            {
                string bb = b.Substring(0, 20);
                a = bb.Trim();
            }
            if (a != "")
            {
                string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();

                //打开对话框
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo info = new FileInfo(dialog.FileName);
                    //获得文件大小
                    fileSize = info.Length;
                    //提取文件名,三步走
                    int index = info.FullName.LastIndexOf(".");
                    fileName = info.FullName.Remove(index);
                    fileName = fileName.Substring(fileName.LastIndexOf(@"\") + 1);
                    mingcheng = fileName;
                    //获得文件扩展名
                    fileType = info.Extension.Replace(".", "");
                    //把文件转换成二进制流
                    files = new byte[Convert.ToInt32(fileSize)];
                    FileStream file = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read);
                    read = new BinaryReader(file);
                    read.Read(files, 0, Convert.ToInt32(fileSize));

                    string ConStr = "update tb_xiangmu  set 项目清单=@pic where id='" + id + "'";
                    SQLhelp.ExecuteNonquery(ConStr, CommandType.Text, files);

                    string sql = "update tb_xiangmu set 项目清单名称='" + mingcheng + "',项目清单类型='" + fileType + "' where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql, CommandType.Text);
                    MessageBox.Show("上传成功！");
                }
            }
        }

        private void 下载项目清单发货布局等ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string a = "";
            string b = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号"));
            if (b.Length > 14)
            {
                string bb = b.Substring(0, 14);
                a = bb.Trim();
            }
            if (a != "")
            {
                string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
                string sql = "select 项目清单名称 from tb_xiangmu  where id='" + id + "'";

                string jiance = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();

                if (jiance == "")
                {
                    MessageBox.Show("无附件！");
                    return;

                }
                FolderBrowserDialog lujingg = new FolderBrowserDialog();

                if (lujingg.ShowDialog() == DialogResult.OK)

                {
                    string xuanzelujing = lujingg.SelectedPath;
                    string sql1 = "select 项目清单名称 from tb_xiangmu  where id='" + id + "'";
                    string mingcheng = SQLhelp.ExecuteScalar(sql1, CommandType.Text).ToString();
                    string sql12 = "select 项目清单类型 from tb_xiangmu  where id='" + id + "'";

                    string leixing = SQLhelp.ExecuteScalar(sql12, CommandType.Text).ToString();
                    string lujing = xuanzelujing + "\\" + mingcheng + "." + leixing;
                    try
                    {
                        if (jiance != "")
                        {

                            string sql123 = "select 项目清单 from tb_xiangmu where id='" + id + "'";
                            byte[] mypdffile = SQLhelp.duqu(sql123, CommandType.Text);
                            FileStream fs = new FileStream(lujing, FileMode.Create);
                            fs.Write(mypdffile, 0, mypdffile.Length);
                            fs.Flush();
                            fs.Close();
                            MessageBox.Show("下载成功！");//显示异常信息                   
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);//显示异常信息
                    }

                }
            }
        }

        private void 下载该项目设备清单ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string a = "";
            string b = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号"));
            if (b.Length > 5)
            {
                string bb = b.Substring(0, 20);
                a = bb.Trim();
            }
            if (a != "")
            {
                string gongzuolinghao = a;
                string xiangmumingcheng = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "项目名称").ToString();


                string sql1 = "select  工作令号,项目名称,设备名称,数量,制造类型 from tb_jishubumen  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 技术部通过='1'";
                DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                string lujing = "";
                SaveFileDialog op = new SaveFileDialog();
                op.Filter = "EXCEL文件|*.xls;*,xlsx;";
                if (op.ShowDialog() == DialogResult.OK)//显示保存文件对话框
                {
                    lujing = op.FileName;
                    string savePath = lujing;

                    Workbook book = new Workbook();
                    Worksheet sheet = book.Worksheets[0];
                    Cells cells = sheet.Cells;


                    int Colnum = dt.Columns.Count;//表格列数   
                    int Rownum = dt.Rows.Count;//表格行数   



                    //生成行 列名行   
                    for (int i = 0; i < Colnum; i++)
                    {
                        cells[0, i].PutValue(dt.Columns[i].ColumnName);
                    }


                    //生成数据行   
                    for (int i = 0; i < Rownum; i++)
                    {
                        for (int k = 0; k < Colnum; k++)
                        {
                            cells[1 + i, k].PutValue(dt.Rows[i][k].ToString());
                        }
                    }

                    book.Save(savePath);


                    FileInfo fileInf = new FileInfo(savePath);

                    MessageBox.Show("导出成功！");
                }

            }
        }

        private void 上传项目采购预算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string a = "";
            string b = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号"));
            if (b.Length > 5)
            {
                string bb = b.Substring(0, 20);
                a = bb.Trim();
            }
            if (a != "")
            {
                string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();

                //打开对话框
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo info = new FileInfo(dialog.FileName);
                    //获得文件大小
                    fileSize = info.Length;
                    //提取文件名,三步走
                    int index = info.FullName.LastIndexOf(".");
                    fileName = info.FullName.Remove(index);
                    fileName = fileName.Substring(fileName.LastIndexOf(@"\") + 1);
                    mingcheng = fileName;
                    //获得文件扩展名
                    fileType = info.Extension.Replace(".", "");
                    //把文件转换成二进制流
                    files = new byte[Convert.ToInt32(fileSize)];
                    FileStream file = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read);
                    read = new BinaryReader(file);
                    read.Read(files, 0, Convert.ToInt32(fileSize));


                    string sql1 = "update tb_xiangmu  set 采购预算清单=@pic where id='" + id + "'";
                    SQLhelp.ExecuteNonquery(sql1, CommandType.Text, files);

                    string sql = "update tb_xiangmu set 采购预算清单名称='" + mingcheng + "',采购预算清单类型='" + fileType + "' where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql, CommandType.Text);
                    MessageBox.Show("上传成功！");
                }
            }
        }

        private void 下载项目采购预算ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string a = "";
            string b = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号"));
            if (b.Length > 5)
            {
                string bb = b.Substring(0, 20);
                a = bb.Trim();
            }
            if (a != "")
            {
                string xaingmufuzeren = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "项目负责人").ToString();
                string sql1234 = "select 部门 from tb_operator where 用户名='" + yonghu + "'";
                string bumen = sqlhelp111.ExecuteScalar(sql1234, CommandType.Text).ToString();
                if (bumen == "物流部" || yonghu == xaingmufuzeren)
                {



                    string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
                    string sql = "select 采购预算清单名称 from tb_xiangmu  where id='" + id + "'";

                    string jiance = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();

                    if (jiance == "")
                    {
                        MessageBox.Show("无附件！");
                        return;

                    }
                    FolderBrowserDialog lujingg = new FolderBrowserDialog();

                    if (lujingg.ShowDialog() == DialogResult.OK)

                    {
                        string xuanzelujing = lujingg.SelectedPath;
                        string sql1 = "select 采购预算清单名称 from tb_xiangmu  where id='" + id + "'";
                        string mingcheng = SQLhelp.ExecuteScalar(sql1, CommandType.Text).ToString();
                        string sql12 = "select 采购预算清单类型 from tb_xiangmu  where id='" + id + "'";

                        string leixing = SQLhelp.ExecuteScalar(sql12, CommandType.Text).ToString();
                        string lujing = xuanzelujing + "\\" + mingcheng + "." + leixing;
                        try
                        {
                            if (jiance != "")
                            {

                                string sql123 = "select 采购预算清单 from tb_xiangmu where id='" + id + "'";
                                byte[] mypdffile = SQLhelp.duqu(sql123, CommandType.Text);
                                FileStream fs = new FileStream(lujing, FileMode.Create);
                                fs.Write(mypdffile, 0, mypdffile.Length);
                                fs.Flush();
                                fs.Close();
                                MessageBox.Show("下载成功！");//显示异常信息                   
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);//显示异常信息
                        }
                    }
                }
                else
                {

                    MessageBox.Show("无权限下载采购预算！");
                    return;

                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (gridView2.RowCount <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }
            string a = "";
            string b = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "工作令号"));
            if (b.Length > 5)
            {
                string bb = b.Substring(0, 20);
                a = bb.Trim();
            }
            if (a != "")
            {
                string gongzuolingaho = a;
                string xiangmumingcheng = this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "项目名称").ToString();

                string sql1 = "Select 合同类型 From tb_xiangmu  Where 工作令号='" + gongzuolingaho + "' and  项目名称='" + xiangmumingcheng + "' ";
                string hetongleixing = SQLhelp.ExecuteScalar(sql1, CommandType.Text).ToString();

                string sql2 = "Select 合同名称 From tb_xiangmu  Where 工作令号='" + gongzuolingaho + "' and  项目名称='" + xiangmumingcheng + "' ";
                string hetongmingcheng = SQLhelp.ExecuteScalar(sql2, CommandType.Text).ToString();

                string sql = "Select 合同 From tb_xiangmu  Where 工作令号='" + gongzuolingaho + "' and  项目名称='" + xiangmumingcheng + "' ";
                byte[] mypdffile = null;
                mypdffile = SQLhelp.duqu(sql, CommandType.Text);


                string aaaa = System.Environment.CurrentDirectory;
                string lujing = aaaa + "\\" + hetongmingcheng + "." + hetongleixing;
                FileStream fs = new FileStream(lujing, FileMode.Create);
                fs.Write(mypdffile, 0, mypdffile.Length);
                fs.Flush();
                fs.Close();
                System.Diagnostics.Process.Start(lujing);
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (gridView2.RowCount <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }
            string a = "";
            string b = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "工作令号"));
            if (b.Length > 5)
            {
                string bb = b.Substring(0, 20);
                a = bb.Trim();
            }
            if (a != "")
            {
                string gongzuolingaho = a;
                string xiangmumingcheng = this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "项目名称").ToString();
                string sql1 = "Select 里程碑计划表类型 From tb_xiangmu  Where 工作令号='" + gongzuolingaho + "' and  项目名称='" + xiangmumingcheng + "' ";
                string hetongleixing = SQLhelp.ExecuteScalar(sql1, CommandType.Text).ToString();
                string sql2 = "Select 里程碑计划表名称 From tb_xiangmu  Where 工作令号='" + gongzuolingaho + "' and  项目名称='" + xiangmumingcheng + "' ";
                string hetongmingcheng = SQLhelp.ExecuteScalar(sql2, CommandType.Text).ToString();
                string sql = "Select 里程碑计划表 From tb_xiangmu  Where 工作令号='" + gongzuolingaho + "' and  项目名称='" + xiangmumingcheng + "' ";
                byte[] mypdffile = null;
                mypdffile = SQLhelp.duqu(sql, CommandType.Text);
                string aaaa = System.Environment.CurrentDirectory;
                string lujing = aaaa + "\\" + hetongmingcheng + "." + hetongleixing;
                FileStream fs = new FileStream(lujing, FileMode.Create);
                fs.Write(mypdffile, 0, mypdffile.Length);
                fs.Flush();
                fs.Close();
                System.Diagnostics.Process.Start(lujing);
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (gridView2.RowCount <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }
            string a = "";
            string b = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "工作令号"));
            if (b.Length > 5)
            {
                string bb = b.Substring(0, 20);
                a = bb.Trim();
            }
            if (a != "")
            {
                string gongzuolingaho = a;
                string xiangmumingcheng = this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "项目名称").ToString();

                string sql1 = "Select 生产任务书类型 From tb_xiangmu  Where 工作令号='" + gongzuolingaho + "' and  项目名称='" + xiangmumingcheng + "' ";
                string hetongleixing = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));
                if (hetongleixing == "")
                {
                    MessageBox.Show("没有生产任务书！");
                    return;
                }
                string sql2 = "Select 生产任务书名称 From tb_xiangmu  Where 工作令号='" + gongzuolingaho + "' and  项目名称='" + xiangmumingcheng + "' ";
                string hetongmingcheng = SQLhelp.ExecuteScalar(sql2, CommandType.Text).ToString();
                string sql = "Select 生产任务书 From tb_xiangmu  Where 工作令号='" + gongzuolingaho + "' and  项目名称='" + xiangmumingcheng + "' ";
                byte[] mypdffile = null;
                mypdffile = SQLhelp.duqu(sql, CommandType.Text);
                string aaaa = System.Environment.CurrentDirectory;
                string lujing = aaaa + "\\" + hetongmingcheng + "." + hetongleixing;
                FileStream fs = new FileStream(lujing, FileMode.Create);
                fs.Write(mypdffile, 0, mypdffile.Length);
                fs.Flush();
                fs.Close();
                System.Diagnostics.Process.Start(lujing);
            }

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

            string a = "";
            string b = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "工作令号"));
            if (b.Length > 5)
            {
                string bb = b.Substring(0, 20);
                a = bb.Trim();
            }
            if (a != "")
            {
                FrFankuixiangxi form = new FrFankuixiangxi();
                form.gongzuolinghao = a;
                form.xiangmumingcheng = this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "项目名称").ToString();
                form.yonghu = yonghu;
                form.ShowDialog();

            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            string a = "";
            string b = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "工作令号"));
            if (b.Length > 5)
            {
                string bb = b.Substring(0, 20);
                a = bb.Trim();
            }
            if (a != "")
            {
                if (yonghu == "韩小建" || yonghu == "徐魏魏" || yonghu == "蔡红兵")
                {
                    if (MessageBox.Show("确认提交吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        string id = this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id").ToString();
                        string sql = "update tb_xiangmu set 未交货项目 =NULL , 已交货未调试项目=1 where id='" + id + "'";
                        SQLhelp.ExecuteScalar(sql, CommandType.Text);
                        MessageBox.Show("确认成功！");

                    }
                    else
                    {

                        MessageBox.Show("无权限！");
                        return;
                    }
                }
            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            string a = "";
            string b = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "工作令号"));
            if (b.Length > 5)
            {
                string bb = b.Substring(0, 20);
                a = bb.Trim();
            }
            if (a != "")
            {
                string id = this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id").ToString();

                //打开对话框
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo info = new FileInfo(dialog.FileName);
                    //获得文件大小
                    fileSize = info.Length;
                    //提取文件名,三步走
                    int index = info.FullName.LastIndexOf(".");
                    fileName = info.FullName.Remove(index);
                    fileName = fileName.Substring(fileName.LastIndexOf(@"\") + 1);
                    mingcheng = fileName;
                    //获得文件扩展名
                    fileType = info.Extension.Replace(".", "");
                    //把文件转换成二进制流
                    files = new byte[Convert.ToInt32(fileSize)];
                    FileStream file = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read);
                    read = new BinaryReader(file);
                    read.Read(files, 0, Convert.ToInt32(fileSize));

                    string ConStr = "update tb_xiangmu  set 项目清单=@pic where id='" + id + "'";
                    SQLhelp.ExecuteNonquery(ConStr, CommandType.Text, files);

                    string sql = "update tb_xiangmu set 项目清单名称='" + mingcheng + "',项目清单类型='" + fileType + "' where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql, CommandType.Text);
                    MessageBox.Show("上传成功！");
                }
            }
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            string a = "";
            string b = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "工作令号"));
            if (b.Length > 14)
            {
                string bb = b.Substring(0, 14);
                a = bb.Trim();
            }
            if (a != "")
            {
                string id = this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id").ToString();
                string sql = "select 项目清单名称 from tb_xiangmu  where id='" + id + "'";

                string jiance = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();

                if (jiance == "")
                {
                    MessageBox.Show("无附件！");
                    return;

                }
                FolderBrowserDialog lujingg = new FolderBrowserDialog();

                if (lujingg.ShowDialog() == DialogResult.OK)

                {
                    string xuanzelujing = lujingg.SelectedPath;
                    string sql1 = "select 项目清单名称 from tb_xiangmu  where id='" + id + "'";
                    string mingcheng = SQLhelp.ExecuteScalar(sql1, CommandType.Text).ToString();
                    string sql12 = "select 项目清单类型 from tb_xiangmu  where id='" + id + "'";

                    string leixing = SQLhelp.ExecuteScalar(sql12, CommandType.Text).ToString();
                    string lujing = xuanzelujing + "\\" + mingcheng + "." + leixing;
                    try
                    {
                        if (jiance != "")
                        {

                            string sql123 = "select 项目清单 from tb_xiangmu where id='" + id + "'";
                            byte[] mypdffile = SQLhelp.duqu(sql123, CommandType.Text);
                            FileStream fs = new FileStream(lujing, FileMode.Create);
                            fs.Write(mypdffile, 0, mypdffile.Length);
                            fs.Flush();
                            fs.Close();
                            MessageBox.Show("下载成功！");//显示异常信息                   
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);//显示异常信息
                    }

                }
            }
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {

            string a = "";
            string b = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "工作令号"));
            if (b.Length > 5)
            {
                string bb = b.Substring(0, 20);
                a = bb.Trim();
            }
            if (a != "")
            {
                string gongzuolinghao = a;
                string xiangmumingcheng = this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "项目名称").ToString();


                string sql1 = "select  工作令号,项目名称,设备名称,数量,制造类型 from tb_jishubumen  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 技术部通过='1'";
                DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                string lujing = "";
                SaveFileDialog op = new SaveFileDialog();
                op.Filter = "EXCEL文件|*.xls;*,xlsx;";
                if (op.ShowDialog() == DialogResult.OK)//显示保存文件对话框
                {
                    lujing = op.FileName;
                    string savePath = lujing;

                    Workbook book = new Workbook();
                    Worksheet sheet = book.Worksheets[0];
                    Cells cells = sheet.Cells;


                    int Colnum = dt.Columns.Count;//表格列数   
                    int Rownum = dt.Rows.Count;//表格行数   



                    //生成行 列名行   
                    for (int i = 0; i < Colnum; i++)
                    {
                        cells[0, i].PutValue(dt.Columns[i].ColumnName);
                    }


                    //生成数据行   
                    for (int i = 0; i < Rownum; i++)
                    {
                        for (int k = 0; k < Colnum; k++)
                        {
                            cells[1 + i, k].PutValue(dt.Rows[i][k].ToString());
                        }
                    }

                    book.Save(savePath);


                    FileInfo fileInf = new FileInfo(savePath);

                    MessageBox.Show("导出成功！");
                }

            }
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            string a = "";
            string b = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "工作令号"));
            if (b.Length > 5)
            {
                string bb = b.Substring(0, 20);
                a = bb.Trim();
            }
            if (a != "")
            {
                string id = this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id").ToString();

                //打开对话框
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo info = new FileInfo(dialog.FileName);
                    //获得文件大小
                    fileSize = info.Length;
                    //提取文件名,三步走
                    int index = info.FullName.LastIndexOf(".");
                    fileName = info.FullName.Remove(index);
                    fileName = fileName.Substring(fileName.LastIndexOf(@"\") + 1);
                    mingcheng = fileName;
                    //获得文件扩展名
                    fileType = info.Extension.Replace(".", "");
                    //把文件转换成二进制流
                    files = new byte[Convert.ToInt32(fileSize)];
                    FileStream file = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read);
                    read = new BinaryReader(file);
                    read.Read(files, 0, Convert.ToInt32(fileSize));


                    string sql1 = "update tb_xiangmu  set 采购预算清单=@pic where id='" + id + "'";
                    SQLhelp.ExecuteNonquery(sql1, CommandType.Text, files);

                    string sql = "update tb_xiangmu set 采购预算清单名称='" + mingcheng + "',采购预算清单类型='" + fileType + "' where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql, CommandType.Text);
                    MessageBox.Show("上传成功！");
                }
            }
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {

            string a = "";
            string b = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "工作令号"));
            if (b.Length > 5)
            {
                string bb = b.Substring(0, 20);
                a = bb.Trim();
            }
            if (a != "")
            {
                string xaingmufuzeren = this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "项目负责人").ToString();
                string sql1234 = "select 部门 from tb_operator where 用户名='" + yonghu + "'";
                string bumen = sqlhelp111.ExecuteScalar(sql1234, CommandType.Text).ToString();
                if (bumen == "物流部" || yonghu == xaingmufuzeren)
                {



                    string id = this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id").ToString();
                    string sql = "select 采购预算清单名称 from tb_xiangmu  where id='" + id + "'";

                    string jiance = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();

                    if (jiance == "")
                    {
                        MessageBox.Show("无附件！");
                        return;

                    }
                    FolderBrowserDialog lujingg = new FolderBrowserDialog();

                    if (lujingg.ShowDialog() == DialogResult.OK)

                    {
                        string xuanzelujing = lujingg.SelectedPath;
                        string sql1 = "select 采购预算清单名称 from tb_xiangmu  where id='" + id + "'";
                        string mingcheng = SQLhelp.ExecuteScalar(sql1, CommandType.Text).ToString();
                        string sql12 = "select 采购预算清单类型 from tb_xiangmu  where id='" + id + "'";

                        string leixing = SQLhelp.ExecuteScalar(sql12, CommandType.Text).ToString();
                        string lujing = xuanzelujing + "\\" + mingcheng + "." + leixing;
                        try
                        {
                            if (jiance != "")
                            {

                                string sql123 = "select 采购预算清单 from tb_xiangmu where id='" + id + "'";
                                byte[] mypdffile = SQLhelp.duqu(sql123, CommandType.Text);
                                FileStream fs = new FileStream(lujing, FileMode.Create);
                                fs.Write(mypdffile, 0, mypdffile.Length);
                                fs.Flush();
                                fs.Close();
                                MessageBox.Show("下载成功！");//显示异常信息                   
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);//显示异常信息
                        }
                    }
                }
                else
                {

                    MessageBox.Show("无权限下载采购预算！");
                    return;

                }
            }
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
            {
                string a = "";
                string b = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "工作令号"));
                if (b.Length > 5)
                {
                    string bb = b.Substring(0, 20);
                    a = bb.Trim();
                }
                if (a != "")
                {
                    Frdashujv form = new Frdashujv();
                    form.gongzuolinghao = a;
                    form.xiangmumingcheng = this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "项目名称").ToString();

                    form.ShowDialog();
                }
            }
        }

        private void gridView7_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
            {
                string a = "";
                string b = Convert.ToString(this.gridView7.GetRowCellValue(this.gridView7.FocusedRowHandle, "工作令号"));
                if (b.Length > 5)
                {
                    string bb = b.Substring(0, 20);
                    a = bb.Trim();
                }
                if (a != "")
                {
                    Frdashujv form = new Frdashujv();
                    form.gongzuolinghao = a;
                    form.xiangmumingcheng = this.gridView7.GetRowCellValue(this.gridView7.FocusedRowHandle, "项目名称").ToString();

                    form.ShowDialog();
                }
            }
        }

        private void gridView10_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
            {

                Frdashujv form = new Frdashujv();
                form.gongzuolinghao = this.gridView10.GetRowCellValue(this.gridView10.FocusedRowHandle, "工作令号").ToString();
                form.xiangmumingcheng = this.gridView10.GetRowCellValue(this.gridView10.FocusedRowHandle, "项目名称").ToString();
                form.ShowDialog();

            }
        }

        private void gridView13_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
            {
               
                    Frdashujv form = new Frdashujv();
                    form.gongzuolinghao = this.gridView13.GetRowCellValue(this.gridView13.FocusedRowHandle, "工作令号").ToString();
                form.xiangmumingcheng = this.gridView13.GetRowCellValue(this.gridView13.FocusedRowHandle, "项目名称").ToString();

                    form.ShowDialog();
              
            }
        }

        private void gridView22_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
            {
                string a = "";
                string b = Convert.ToString(this.gridView22.GetRowCellValue(this.gridView22.FocusedRowHandle, "工作令号"));
                if (b.Length > 5)
                {
                    string bb = b.Substring(0, 20);
                    a = bb.Trim();
                }
                if (a != "")
                {
                    Frdashujv form = new Frdashujv();
                    form.gongzuolinghao = a;
                    form.xiangmumingcheng = this.gridView22.GetRowCellValue(this.gridView22.FocusedRowHandle, "项目名称").ToString();

                    form.ShowDialog();
                }
            }
        }

        private void gridView25_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
            {
                string a = "";
                string b = Convert.ToString(this.gridView25.GetRowCellValue(this.gridView25.FocusedRowHandle, "工作令号"));
                if (b.Length > 5)
                {
                    string bb = b.Substring(0, 20);
                    a = bb.Trim();
                }
                if (a != "")
                {
                    Frdashujv form = new Frdashujv();
                    form.gongzuolinghao = a;
                    form.xiangmumingcheng = this.gridView25.GetRowCellValue(this.gridView25.FocusedRowHandle, "项目名称").ToString();

                    form.ShowDialog();
                }
            }
        }
    }
}
