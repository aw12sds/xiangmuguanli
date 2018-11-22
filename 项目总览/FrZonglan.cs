using Aspose.Cells;
using DevComponents.DotNetBar;
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

namespace 项目管理系统.项目总览
{
    public partial class FrZonglan : Office2007Form
    {
        public FrZonglan()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string yonghu;
        int jindu = 0;
        DataTable dtt;



        public string gonglinghao;
        public string xiangmu;
        public string shebei;
        public DataTable dt;
        public string shijian;
        public string shuliang11;
        public int a;
        public string name;

        private long fileSize = 0;//文件大小
        private string fileName = null;//文件名字
        private string fileType = null;//文件类型
        private byte[] files;//文件
        private BinaryReader read = null;//二进制读取
        public string mingcheng;
        private void FrZonglan_Load(object sender, EventArgs e)
        {
            xtraTabControl1.SelectedTabPage = 未交货项目;
            Reload();
            Reload2();
            Reload3();
            Reload4();
        }

        private void DrawProgressBar(DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            decimal percent = Convert.ToDecimal(e.CellValue);
            int width = (int)(10 * Math.Abs(percent) * e.Bounds.Width / 100);//涨跌幅最大为10%，所以要乘以10来计算比例，沾满一个单元格为10%  
            Rectangle rect = new Rectangle(e.Bounds.X, e.Bounds.Y, width, e.Bounds.Height);
            Brush b = Brushes.Green;
            if (percent < 0)
                b = Brushes.Green;
            else if (percent < 2.5m)
                b = Brushes.Purple;
            else if (percent < 5.0m)
                b = Brushes.Red;
            else if (percent < 7.5m)
                b = Brushes.Yellow;
            e.Graphics.FillRectangle(b, rect);
        }





        public void Reload4()

        {
            string sql = "select id,工作令号,项目名称,客户名称,交货日期,反馈,项目负责人,采购负责人,装配负责人  from tb_xiangmu  where 未交货项目=1 and 维修=1";

            dtt = SQLhelp.GetDataTable(sql, CommandType.Text);

            DataColumn column1 = new DataColumn();

            column1.DataType = System.Type.GetType("System.Int32");

            column1.ColumnName = "完成进度";

            dtt.Columns.Add(column1);


            for (int j = 0; j < dtt.Rows.Count; j++)
            {
                string gongzuolinghao = dtt.Rows[j]["工作令号"].ToString();
                string xiangmumingcheng = dtt.Rows[j]["项目名称"].ToString();


                string sql1 = "select 工作令号,项目名称,时间,技术部通过,生产部确认,加工确认,装配确认,调试确认,制造类型,仓库确认 from tb_jishubumen where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'";


                DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                if (dt.Rows.Count == 1)
                {
                    jindu = 0;
                    string jishubu = dt.Rows[0]["技术部通过"].ToString();
                    string shengchanbuqueren = dt.Rows[0]["生产部确认"].ToString();
                    string jiagongqueren = dt.Rows[0]["加工确认"].ToString();
                    string zhuangpeiqueren = dt.Rows[0]["装配确认"].ToString();
                    string tiaoshiqueren = dt.Rows[0]["调试确认"].ToString();
                    string zhizaoleixing = dt.Rows[0]["制造类型"].ToString();
                    string cangkuqueren = dt.Rows[0]["仓库确认"].ToString();
                    if (zhizaoleixing == "自制")
                    {
                        if (jishubu == "0")
                        {

                            dtt.Rows[j]["完成进度"] = 0;

                        }
                        if (jishubu == "1" && shengchanbuqueren == "0")
                        {

                            dtt.Rows[j]["完成进度"] = 20;

                        }

                        if (jishubu == "1" && shengchanbuqueren == "1" && jiagongqueren == "0")
                        {

                            dtt.Rows[j]["完成进度"] = 40;

                        }


                        if (jishubu == "1" && shengchanbuqueren == "1" && jiagongqueren == "1" && zhuangpeiqueren == "0")
                        {

                            dtt.Rows[j]["完成进度"] = 60;

                        }
                        if (jishubu == "1" && shengchanbuqueren == "1" && jiagongqueren == "1" && zhuangpeiqueren == "1" && tiaoshiqueren == "0")
                        {

                            dtt.Rows[j]["完成进度"] = 80;

                        }
                        if (jishubu == "1" && shengchanbuqueren == "1" && jiagongqueren == "1" && zhuangpeiqueren == "1" && tiaoshiqueren == "1")
                        {

                            dtt.Rows[j]["完成进度"] = 100;

                        }
                    }
                    if (zhizaoleixing != "自制")
                    {
                        if (jishubu == "0")
                        {

                            dtt.Rows[j]["完成进度"] = 0;

                        }
                        if (jishubu == "1" && cangkuqueren == "0")
                        {

                            dtt.Rows[j]["完成进度"] = 50;

                        }
                        if (jishubu == "1" && cangkuqueren == "1")
                        {

                            dtt.Rows[j]["完成进度"] = 100;

                        }

                    }


                }
                if (dt.Rows.Count != 1)
                {
                    jindu = 0;
                    int geshu = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int jishubu = Convert.ToInt32(dt.Rows[i]["技术部通过"]);
                        int shengchanbuqueren = Convert.ToInt32(dt.Rows[i]["生产部确认"]);
                        int jiagongqueren = Convert.ToInt32(dt.Rows[i]["加工确认"]);
                        int zhuangpeiqueren = Convert.ToInt32(dt.Rows[i]["装配确认"]);
                        int tiaoshiqueren = Convert.ToInt32(dt.Rows[i]["调试确认"]);
                        string zhizaoleixing = dt.Rows[i]["制造类型"].ToString();
                        int cangkuqueren = Convert.ToInt32(dt.Rows[i]["仓库确认"]);

                        if (zhizaoleixing == "自制")
                        {
                            if (jishubu == 0)
                            {

                                jindu += 0;

                            }
                            if (jishubu == 1 && shengchanbuqueren == 0)
                            {

                                jindu += (int)(20 / geshu + 0.5);

                            }
                            if (jishubu == 1 && shengchanbuqueren == 1 && jiagongqueren == 0)
                            {

                                jindu += (int)(40 / geshu + 0.5);

                            }
                            if (jishubu == 1 && shengchanbuqueren == 1 && jiagongqueren == 1 && zhuangpeiqueren == 0)
                            {

                                jindu += (int)(60 / geshu + 0.5);

                            }
                            if (jishubu == 1 && shengchanbuqueren == 1 && jiagongqueren == 1 && zhuangpeiqueren == 1 && tiaoshiqueren == 0)
                            {

                                jindu += (int)(80 / geshu + 0.5);

                            }
                            if (jishubu == 1 && shengchanbuqueren == 1 && jiagongqueren == 1 && zhuangpeiqueren == 1 && tiaoshiqueren == 1)
                            {

                                jindu += (int)(100 / geshu + 0.5);

                            }

                        }
                        if (zhizaoleixing != "自制")

                        {
                            if (jishubu == 0)
                            {

                                jindu += 0;

                            }


                            if (jishubu == 1 && cangkuqueren == 0)
                            {

                                jindu += (int)(50 / geshu + 0.5);

                            }
                            if (jishubu == 1 && cangkuqueren == 1)
                            {

                                jindu += (int)(100 / geshu + 0.5);

                            }

                        }
                    }
                    dtt.Rows[j]["完成进度"] = jindu;
                }


            }
            dataGridViewX4.DataSource = dtt;





        }

        public void Reload()

        {
            string sql = "select id,工作令号,项目名称,客户名称,交货日期,反馈,项目负责人,采购负责人,装配负责人  from tb_xiangmu  where 未交货项目=1 and 维修 is null";

             dtt = SQLhelp.GetDataTable(sql, CommandType.Text);

            DataColumn column1 = new DataColumn();

            column1.DataType = System.Type.GetType("System.Int32");

            column1.ColumnName = "完成进度";

            dtt.Columns.Add(column1);


            for (int j = 0; j < dtt.Rows.Count; j++)
            {
                string gongzuolinghao = dtt.Rows[j]["工作令号"].ToString();
                string xiangmumingcheng = dtt.Rows[j]["项目名称"].ToString();
                

                string sql1 = "select 工作令号,项目名称,时间,技术部通过,生产部确认,加工确认,装配确认,调试确认,制造类型,仓库确认 from tb_jishubumen where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'";


                DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                if (dt.Rows.Count == 1)
                {
                    jindu = 0;
                    string jishubu = dt.Rows[0]["技术部通过"].ToString();
                    string shengchanbuqueren = dt.Rows[0]["生产部确认"].ToString();
                    string jiagongqueren = dt.Rows[0]["加工确认"].ToString();
                    string zhuangpeiqueren = dt.Rows[0]["装配确认"].ToString();
                    string tiaoshiqueren = dt.Rows[0]["调试确认"].ToString();
                    string zhizaoleixing = dt.Rows[0]["制造类型"].ToString();
                    string cangkuqueren = dt.Rows[0]["仓库确认"].ToString();
                    if (zhizaoleixing == "自制")
                    {
                        if (jishubu == "0")
                        {

                            dtt.Rows[j]["完成进度"] = 0;

                        }
                        if (jishubu == "1" && shengchanbuqueren == "0")
                        {

                            dtt.Rows[j]["完成进度"] = 20;

                        }

                        if (jishubu == "1" && shengchanbuqueren == "1" && jiagongqueren == "0")
                        {

                            dtt.Rows[j]["完成进度"] = 40;

                        }


                        if (jishubu == "1" && shengchanbuqueren == "1" && jiagongqueren == "1" && zhuangpeiqueren == "0")
                        {

                            dtt.Rows[j]["完成进度"] = 60;

                        }
                        if (jishubu == "1" && shengchanbuqueren == "1" && jiagongqueren == "1" && zhuangpeiqueren == "1" && tiaoshiqueren == "0")
                        {

                            dtt.Rows[j]["完成进度"] = 80;

                        }
                        if (jishubu == "1" && shengchanbuqueren == "1" && jiagongqueren == "1" && zhuangpeiqueren == "1" && tiaoshiqueren == "1")
                        {

                            dtt.Rows[j]["完成进度"] = 100;

                        }
                    }
                    if (zhizaoleixing != "自制")
                    {
                        if (jishubu == "0")
                        {

                            dtt.Rows[j]["完成进度"] = 0;

                        }
                        if (jishubu == "1" && cangkuqueren == "0")
                        {

                            dtt.Rows[j]["完成进度"] = 50;

                        }
                        if (jishubu == "1" && cangkuqueren == "1")
                        {

                            dtt.Rows[j]["完成进度"] = 100;

                        }

                    }


                }
                if (dt.Rows.Count != 1)
                {
                    jindu = 0;
                    int geshu = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int jishubu = Convert.ToInt32(dt.Rows[i]["技术部通过"]);
                        int shengchanbuqueren = Convert.ToInt32(dt.Rows[i]["生产部确认"]);
                        int jiagongqueren = Convert.ToInt32(dt.Rows[i]["加工确认"]);
                        int zhuangpeiqueren = Convert.ToInt32(dt.Rows[i]["装配确认"]);
                        int tiaoshiqueren = Convert.ToInt32(dt.Rows[i]["调试确认"]);
                        string zhizaoleixing = dt.Rows[i]["制造类型"].ToString();
                        int cangkuqueren = Convert.ToInt32(dt.Rows[i]["仓库确认"]);

                        if (zhizaoleixing == "自制")
                        {
                            if (jishubu == 0)
                            {

                                jindu += 0;

                            }
                            if (jishubu == 1 && shengchanbuqueren == 0)
                            {

                                jindu += (int)(20 / geshu + 0.5);

                            }
                            if (jishubu == 1 && shengchanbuqueren == 1 && jiagongqueren == 0)
                            {

                                jindu += (int)(40 / geshu + 0.5);

                            }
                            if (jishubu == 1 && shengchanbuqueren == 1 && jiagongqueren == 1 && zhuangpeiqueren == 0)
                            {

                                jindu += (int)(60 / geshu + 0.5);

                            }
                            if (jishubu == 1 && shengchanbuqueren == 1 && jiagongqueren == 1 && zhuangpeiqueren == 1 && tiaoshiqueren == 0)
                            {

                                jindu += (int)(80 / geshu + 0.5);

                            }
                            if (jishubu == 1 && shengchanbuqueren == 1 && jiagongqueren == 1 && zhuangpeiqueren == 1 && tiaoshiqueren == 1)
                            {

                                jindu += (int)(100 / geshu + 0.5);

                            }

                        }
                        if (zhizaoleixing != "自制")

                        {
                            if (jishubu == 0)
                            {

                                jindu += 0;

                            }


                            if (jishubu == 1 && cangkuqueren == 0)
                            {
                              
                                jindu += (int)(50 / geshu + 0.5);

                            }
                            if (jishubu == 1 && cangkuqueren == 1)
                            {
                               
                                jindu += (int)(100 / geshu + 0.5);

                            }

                        }
                    }
                    dtt.Rows[j]["完成进度"] = jindu;
                }


            }
            dataGridViewX2.DataSource = dtt;

          


        }

        public void Reload2()

        {
            string sql = "select id,工作令号,项目名称,客户名称,交货日期,反馈,项目负责人,采购负责人,装配负责人  from tb_xiangmu where 已交货未调试项目=1 and 维修 is null";

            dtt = SQLhelp.GetDataTable(sql, CommandType.Text);

            DataColumn column1 = new DataColumn();

            column1.DataType = System.Type.GetType("System.Int32");

            column1.ColumnName = "完成进度";

            dtt.Columns.Add(column1);


            for (int j = 0; j < dtt.Rows.Count; j++)
            {
                string gongzuolinghao = dtt.Rows[j]["工作令号"].ToString();
                string xiangmumingcheng = dtt.Rows[j]["项目名称"].ToString();
                
                string sql1 = "select 工作令号,项目名称,时间,技术部通过,生产部确认,加工确认,装配确认,调试确认,制造类型,仓库确认 from tb_jishubumen where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'";


                DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                if (dt.Rows.Count == 1)
                {
                    jindu = 0;
                    string jishubu = dt.Rows[0]["技术部通过"].ToString();
                    string shengchanbuqueren = dt.Rows[0]["生产部确认"].ToString();
                    string jiagongqueren = dt.Rows[0]["加工确认"].ToString();
                    string zhuangpeiqueren = dt.Rows[0]["装配确认"].ToString();
                    string tiaoshiqueren = dt.Rows[0]["调试确认"].ToString();
                    string zhizaoleixing = dt.Rows[0]["制造类型"].ToString();
                    string cangkuqueren = dt.Rows[0]["仓库确认"].ToString();
                    if (zhizaoleixing == "自制")
                    {
                        if (jishubu == "0")
                        {

                            dtt.Rows[j]["完成进度"] = 0;

                        }
                        if (jishubu == "1" && shengchanbuqueren == "0")
                        {

                            dtt.Rows[j]["完成进度"] = 20;

                        }

                        if (jishubu == "1" && shengchanbuqueren == "1" && jiagongqueren == "0")
                        {

                            dtt.Rows[j]["完成进度"] = 40;

                        }


                        if (jishubu == "1" && shengchanbuqueren == "1" && jiagongqueren == "1" && zhuangpeiqueren == "0")
                        {

                            dtt.Rows[j]["完成进度"] = 60;

                        }
                        if (jishubu == "1" && shengchanbuqueren == "1" && jiagongqueren == "1" && zhuangpeiqueren == "1" && tiaoshiqueren == "0")
                        {

                            dtt.Rows[j]["完成进度"] = 80;

                        }
                        if (jishubu == "1" && shengchanbuqueren == "1" && jiagongqueren == "1" && zhuangpeiqueren == "1" && tiaoshiqueren == "1")
                        {

                            dtt.Rows[j]["完成进度"] = 100;

                        }
                    }
                    if (zhizaoleixing != "自制")
                    {
                        if (jishubu == "0")
                        {

                            dtt.Rows[j]["完成进度"] = 0;

                        }
                        if (jishubu == "1" && cangkuqueren == "0")
                        {

                            dtt.Rows[j]["完成进度"] = 50;

                        }
                        if (jishubu == "1" && cangkuqueren == "1")
                        {

                            dtt.Rows[j]["完成进度"] = 100;

                        }

                    }
                   
                }
                if (dt.Rows.Count != 1)
                {
                    jindu = 0;
                    int geshu = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int jishubu = Convert.ToInt32(dt.Rows[i]["技术部通过"]);
                        int shengchanbuqueren = Convert.ToInt32(dt.Rows[i]["生产部确认"]);
                        int jiagongqueren = Convert.ToInt32(dt.Rows[i]["加工确认"]);
                        int zhuangpeiqueren = Convert.ToInt32(dt.Rows[i]["装配确认"]);
                        int tiaoshiqueren = Convert.ToInt32(dt.Rows[i]["调试确认"]);
                        string zhizaoleixing = dt.Rows[i]["制造类型"].ToString();
                        int cangkuqueren = Convert.ToInt32(dt.Rows[i]["仓库确认"]);

                        if (zhizaoleixing == "自制")
                        {
                            if (jishubu == 0)
                            {

                                jindu += 0;

                            }
                            if (jishubu == 1 && shengchanbuqueren == 0)
                            {

                                jindu += (int)(20 / geshu + 0.5);

                            }
                            if (jishubu == 1 && shengchanbuqueren == 1 && jiagongqueren == 0)
                            {

                                jindu += (int)(40 / geshu + 0.5);

                            }
                            if (jishubu == 1 && shengchanbuqueren == 1 && jiagongqueren == 1 && zhuangpeiqueren == 0)
                            {

                                jindu += (int)(60 / geshu + 0.5);

                            }
                            if (jishubu == 1 && shengchanbuqueren == 1 && jiagongqueren == 1 && zhuangpeiqueren == 1 && tiaoshiqueren == 0)
                            {

                                jindu += (int)(80 / geshu + 0.5);

                            }
                            if (jishubu == 1 && shengchanbuqueren == 1 && jiagongqueren == 1 && zhuangpeiqueren == 1 && tiaoshiqueren == 1)
                            {

                                jindu += (int)(100 / geshu + 0.5);

                            }

                        }
                        if (zhizaoleixing != "自制")

                        {
                            if (jishubu == 0)
                            {

                                jindu += 0;

                            }


                            if (jishubu == 1 && cangkuqueren == 0)
                            {
                                //dtt.Rows[j]["到达阶段"] = "研发阶段";
                                jindu += (int)(50 / geshu + 0.5);

                            }
                            if (jishubu == 1 && cangkuqueren == 1)
                            {
                                //dtt.Rows[j]["到达阶段"] = "研发阶段";
                                jindu += (int)(100 / geshu + 0.5);

                            }

                        }
                    }
                    dtt.Rows[j]["完成进度"] = jindu;
                }


            }
            dataGridViewX1.DataSource = dtt;



        }

        public void Reload3()

        {
            string sql = "select id,工作令号,项目名称,客户名称,交货日期,反馈,项目负责人,采购负责人,装配负责人  from tb_xiangmu where 验收通过项目=1 and 维修 is null ";

            dtt = SQLhelp.GetDataTable(sql, CommandType.Text);

            DataColumn column1 = new DataColumn();

            column1.DataType = System.Type.GetType("System.Int32");

            column1.ColumnName = "完成进度";

            dtt.Columns.Add(column1);


            for (int j = 0; j < dtt.Rows.Count; j++)
            {
                string gongzuolinghao = dtt.Rows[j]["工作令号"].ToString();
                string xiangmumingcheng = dtt.Rows[j]["项目名称"].ToString();


                //string sql1 = "select 工作令号,项目名称,时间,技术部通过,生产部确认,加工确认,装配确认,调试确认,制造类型,仓库确认 from tb_jishubumen where 工作令号='17-ZTZN-HK016' and 项目名称='非晶分合卷项目'";

                string sql1 = "select 工作令号,项目名称,时间,技术部通过,生产部确认,加工确认,装配确认,调试确认,制造类型,仓库确认 from tb_jishubumen where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'";


                DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                if (dt.Rows.Count == 1)
                {
                    jindu = 0;
                    string jishubu = dt.Rows[0]["技术部通过"].ToString();
                    string shengchanbuqueren = dt.Rows[0]["生产部确认"].ToString();
                    string jiagongqueren = dt.Rows[0]["加工确认"].ToString();
                    string zhuangpeiqueren = dt.Rows[0]["装配确认"].ToString();
                    string tiaoshiqueren = dt.Rows[0]["调试确认"].ToString();
                    string zhizaoleixing = dt.Rows[0]["制造类型"].ToString();
                    string cangkuqueren = dt.Rows[0]["仓库确认"].ToString();
                    if (zhizaoleixing == "自制")
                    {
                        if (jishubu == "0")
                        {

                            dtt.Rows[j]["完成进度"] = 0;

                        }
                        if (jishubu == "1" && shengchanbuqueren == "0")
                        {

                            dtt.Rows[j]["完成进度"] = 20;

                        }

                        if (jishubu == "1" && shengchanbuqueren == "1" && jiagongqueren == "0")
                        {

                            dtt.Rows[j]["完成进度"] = 40;

                        }


                        if (jishubu == "1" && shengchanbuqueren == "1" && jiagongqueren == "1" && zhuangpeiqueren == "0")
                        {

                            dtt.Rows[j]["完成进度"] = 60;

                        }
                        if (jishubu == "1" && shengchanbuqueren == "1" && jiagongqueren == "1" && zhuangpeiqueren == "1" && tiaoshiqueren == "0")
                        {

                            dtt.Rows[j]["完成进度"] = 80;

                        }
                        if (jishubu == "1" && shengchanbuqueren == "1" && jiagongqueren == "1" && zhuangpeiqueren == "1" && tiaoshiqueren == "1")
                        {

                            dtt.Rows[j]["完成进度"] = 100;

                        }
                    }
                    if (zhizaoleixing != "自制")
                    {
                        if (jishubu == "0")
                        {

                            dtt.Rows[j]["完成进度"] = 0;

                        }
                        if (jishubu == "1" && cangkuqueren == "0")
                        {

                            dtt.Rows[j]["完成进度"] = 50;

                        }
                        if (jishubu == "1" && cangkuqueren == "1")
                        {

                            dtt.Rows[j]["完成进度"] = 100;

                        }

                    }


                }
                if (dt.Rows.Count != 1)
                {
                    jindu = 0;
                    int geshu = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int jishubu = Convert.ToInt32(dt.Rows[i]["技术部通过"]);
                        int shengchanbuqueren = Convert.ToInt32(dt.Rows[i]["生产部确认"]);
                        int jiagongqueren = Convert.ToInt32(dt.Rows[i]["加工确认"]);
                        int zhuangpeiqueren = Convert.ToInt32(dt.Rows[i]["装配确认"]);
                        int tiaoshiqueren = Convert.ToInt32(dt.Rows[i]["调试确认"]);
                        string zhizaoleixing = dt.Rows[i]["制造类型"].ToString();
                        int cangkuqueren = Convert.ToInt32(dt.Rows[i]["仓库确认"]);

                        if (zhizaoleixing == "自制")
                        {
                            if (jishubu == 0)
                            {

                                jindu += 0;

                            }
                            if (jishubu == 1 && shengchanbuqueren == 0)
                            {

                                jindu += (int)(20 / geshu + 0.5);

                            }
                            if (jishubu == 1 && shengchanbuqueren == 1 && jiagongqueren == 0)
                            {

                                jindu += (int)(40 / geshu + 0.5);

                            }
                            if (jishubu == 1 && shengchanbuqueren == 1 && jiagongqueren == 1 && zhuangpeiqueren == 0)
                            {

                                jindu += (int)(60 / geshu + 0.5);

                            }
                            if (jishubu == 1 && shengchanbuqueren == 1 && jiagongqueren == 1 && zhuangpeiqueren == 1 && tiaoshiqueren == 0)
                            {

                                jindu += (int)(80 / geshu + 0.5);

                            }
                            if (jishubu == 1 && shengchanbuqueren == 1 && jiagongqueren == 1 && zhuangpeiqueren == 1 && tiaoshiqueren == 1)
                            {

                                jindu += (int)(100 / geshu + 0.5);

                            }

                        }
                        if (zhizaoleixing != "自制")

                        {
                            if (jishubu == 0)
                            {

                                jindu += 0;

                            }


                            if (jishubu == 1 && cangkuqueren == 0)
                            {
                                //dtt.Rows[j]["到达阶段"] = "研发阶段";
                                jindu += (int)(50 / geshu + 0.5);

                            }
                            if (jishubu == 1 && cangkuqueren == 1)
                            {
                                //dtt.Rows[j]["到达阶段"] = "研发阶段";
                                jindu += (int)(100 / geshu + 0.5);

                            }

                        }
                    }
                    dtt.Rows[j]["完成进度"] = jindu;
                }


            }
            dataGridViewX3.DataSource = dtt;



        }

        private void dataGridViewX2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            FrXiangxi form = new FrXiangxi();
            form.gongzuolinghao = dataGridViewX2.CurrentRow.Cells["工作令号"].Value.ToString();
            form.xiangmumingcheng = dataGridViewX2.CurrentRow.Cells["项目名称"].Value.ToString();
            
            form.yonghu = yonghu;
            form.ShowDialog();

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

        private void 查看合同ToolStripMenuItem_Click(object sender, EventArgs e)
        {



            if (dataGridViewX2.Rows.Count <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }
            string gongzuolingaho = dataGridViewX2.CurrentRow.Cells["工作令号"].Value.ToString();
            string xiangmumingcheng = dataGridViewX2.CurrentRow.Cells["项目名称"].Value.ToString();

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

        private void 查看里程碑计划表ToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (dataGridViewX2.Rows.Count <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }
            string gongzuolingaho = dataGridViewX2.CurrentRow.Cells["工作令号"].Value.ToString();
            string xiangmumingcheng = dataGridViewX2.CurrentRow.Cells["项目名称"].Value.ToString();

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

        private void 查看指示项ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrFankuixiangxi form = new FrFankuixiangxi();
            form.gongzuolinghao = dataGridViewX2.CurrentRow.Cells["工作令号"].Value.ToString();
            form.xiangmumingcheng = dataGridViewX2.CurrentRow.Cells["项目名称"].Value.ToString();
          
            form.yonghu = yonghu;
          

            form.ShowDialog();
            if(form.DialogResult==DialogResult.OK)
            {
                Reload();
            }
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            dtt.Clear();
            if (comboBoxItem1.Text == "线缆事业部")
            {
               
                string sql = "select  id,工作令号,项目名称,客户名称,交货日期,反馈,项目负责人,采购负责人,装配负责人 from tb_xiangmu where 项目主管='张炎兵' and 未交货项目=1";

                dtt = SQLhelp.GetDataTable(sql, CommandType.Text);
                DataColumn column1 = new DataColumn();

                column1.DataType = System.Type.GetType("System.Int32");

                column1.ColumnName = "完成进度";

                dtt.Columns.Add(column1);

                for (int j = 0; j < dtt.Rows.Count; j++)
                {
                    string gongzuolinghao = dtt.Rows[j]["工作令号"].ToString();
                    string xiangmumingcheng = dtt.Rows[j]["项目名称"].ToString();


                    //string sql1 = "select 工作令号,项目名称,时间,技术部通过,生产部确认,加工确认,装配确认,调试确认,制造类型,仓库确认 from tb_jishubumen where 工作令号='17-ZTZN-HK016' and 项目名称='非晶分合卷项目'";

                    string sql1 = "select 工作令号,项目名称,时间,技术部通过,生产部确认,加工确认,装配确认,调试确认,制造类型,仓库确认 from tb_jishubumen where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'";


                    DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                    if (dt.Rows.Count == 1)
                    {
                        jindu = 0;
                        string jishubu = dt.Rows[0]["技术部通过"].ToString();
                        string shengchanbuqueren = dt.Rows[0]["生产部确认"].ToString();
                        string jiagongqueren = dt.Rows[0]["加工确认"].ToString();
                        string zhuangpeiqueren = dt.Rows[0]["装配确认"].ToString();
                        string tiaoshiqueren = dt.Rows[0]["调试确认"].ToString();
                        string zhizaoleixing = dt.Rows[0]["制造类型"].ToString();
                        string cangkuqueren = dt.Rows[0]["仓库确认"].ToString();
                        if (zhizaoleixing == "自制")
                        {
                            if (jishubu == "0")
                            {

                                dtt.Rows[j]["完成进度"] = 0;

                            }
                            if (jishubu == "1" && shengchanbuqueren == "0")
                            {

                                dtt.Rows[j]["完成进度"] = 20;

                            }

                            if (jishubu == "1" && shengchanbuqueren == "1" && jiagongqueren == "0")
                            {

                                dtt.Rows[j]["完成进度"] = 40;

                            }


                            if (jishubu == "1" && shengchanbuqueren == "1" && jiagongqueren == "1" && zhuangpeiqueren == "0")
                            {

                                dtt.Rows[j]["完成进度"] = 60;

                            }
                            if (jishubu == "1" && shengchanbuqueren == "1" && jiagongqueren == "1" && zhuangpeiqueren == "1" && tiaoshiqueren == "0")
                            {

                                dtt.Rows[j]["完成进度"] = 80;

                            }
                            if (jishubu == "1" && shengchanbuqueren == "1" && jiagongqueren == "1" && zhuangpeiqueren == "1" && tiaoshiqueren == "1")
                            {

                                dtt.Rows[j]["完成进度"] = 100;

                            }
                        }
                        if (zhizaoleixing != "自制")
                        {
                            if (jishubu == "0")
                            {

                                dtt.Rows[j]["完成进度"] = 0;

                            }
                            if (jishubu == "1" && cangkuqueren == "0")
                            {

                                dtt.Rows[j]["完成进度"] = 50;

                            }
                            if (jishubu == "1" && cangkuqueren == "1")
                            {

                                dtt.Rows[j]["完成进度"] = 100;

                            }

                        }


                    }
                    if (dt.Rows.Count != 1)
                    {
                        jindu = 0;
                        int geshu = dt.Rows.Count;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int jishubu = Convert.ToInt32(dt.Rows[i]["技术部通过"]);
                            int shengchanbuqueren = Convert.ToInt32(dt.Rows[i]["生产部确认"]);
                            int jiagongqueren = Convert.ToInt32(dt.Rows[i]["加工确认"]);
                            int zhuangpeiqueren = Convert.ToInt32(dt.Rows[i]["装配确认"]);
                            int tiaoshiqueren = Convert.ToInt32(dt.Rows[i]["调试确认"]);
                            string zhizaoleixing = dt.Rows[i]["制造类型"].ToString();
                            int cangkuqueren = Convert.ToInt32(dt.Rows[i]["仓库确认"]);

                            if (zhizaoleixing == "自制")
                            {
                                if (jishubu == 0)
                                {

                                    jindu += 0;

                                }
                                if (jishubu == 1 && shengchanbuqueren == 0)
                                {

                                    jindu += (int)(20 / geshu + 0.5);

                                }
                                if (jishubu == 1 && shengchanbuqueren == 1 && jiagongqueren == 0)
                                {

                                    jindu += (int)(40 / geshu + 0.5);

                                }
                                if (jishubu == 1 && shengchanbuqueren == 1 && jiagongqueren == 1 && zhuangpeiqueren == 0)
                                {

                                    jindu += (int)(60 / geshu + 0.5);

                                }
                                if (jishubu == 1 && shengchanbuqueren == 1 && jiagongqueren == 1 && zhuangpeiqueren == 1 && tiaoshiqueren == 0)
                                {

                                    jindu += (int)(80 / geshu + 0.5);

                                }
                                if (jishubu == 1 && shengchanbuqueren == 1 && jiagongqueren == 1 && zhuangpeiqueren == 1 && tiaoshiqueren == 1)
                                {

                                    jindu += (int)(100 / geshu + 0.5);

                                }

                            }
                            if (zhizaoleixing != "自制")

                            {
                                if (jishubu == 0)
                                {

                                    jindu += 0;

                                }


                                if (jishubu == 1 && cangkuqueren == 0)
                                {
                                    //dtt.Rows[j]["到达阶段"] = "研发阶段";
                                    jindu += (int)(50 / geshu + 0.5);

                                }
                                if (jishubu == 1 && cangkuqueren == 1)
                                {
                                    //dtt.Rows[j]["到达阶段"] = "研发阶段";
                                    jindu += (int)(100 / geshu + 0.5);

                                }

                            }
                        }
                        dtt.Rows[j]["完成进度"] = jindu;
                    }


                }
               
                dataGridViewX2.DataSource = dtt;
            }
            if (comboBoxItem1.Text == "精工事业部")
            {

                string sql = "select  id,工作令号,项目名称,客户名称,交货日期,反馈,项目负责人,采购负责人,装配负责人 from tb_xiangmu where 项目主管='袁鹏' and 未交货项目=1";

                dtt = SQLhelp.GetDataTable(sql, CommandType.Text);
                DataColumn column1 = new DataColumn();

                column1.DataType = System.Type.GetType("System.Int32");

                column1.ColumnName = "完成进度";

                dtt.Columns.Add(column1);

                for (int j = 0; j < dtt.Rows.Count; j++)
                {
                    string gongzuolinghao = dtt.Rows[j]["工作令号"].ToString();
                    string xiangmumingcheng = dtt.Rows[j]["项目名称"].ToString();


                    //string sql1 = "select 工作令号,项目名称,时间,技术部通过,生产部确认,加工确认,装配确认,调试确认,制造类型,仓库确认 from tb_jishubumen where 工作令号='17-ZTZN-HK016' and 项目名称='非晶分合卷项目'";

                    string sql1 = "select 工作令号,项目名称,时间,技术部通过,生产部确认,加工确认,装配确认,调试确认,制造类型,仓库确认 from tb_jishubumen where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'";


                    DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                    if (dt.Rows.Count == 1)
                    {
                        jindu = 0;
                        string jishubu = dt.Rows[0]["技术部通过"].ToString();
                        string shengchanbuqueren = dt.Rows[0]["生产部确认"].ToString();
                        string jiagongqueren = dt.Rows[0]["加工确认"].ToString();
                        string zhuangpeiqueren = dt.Rows[0]["装配确认"].ToString();
                        string tiaoshiqueren = dt.Rows[0]["调试确认"].ToString();
                        string zhizaoleixing = dt.Rows[0]["制造类型"].ToString();
                        string cangkuqueren = dt.Rows[0]["仓库确认"].ToString();
                        if (zhizaoleixing == "自制")
                        {
                            if (jishubu == "0")
                            {

                                dtt.Rows[j]["完成进度"] = 0;

                            }
                            if (jishubu == "1" && shengchanbuqueren == "0")
                            {

                                dtt.Rows[j]["完成进度"] = 20;

                            }

                            if (jishubu == "1" && shengchanbuqueren == "1" && jiagongqueren == "0")
                            {

                                dtt.Rows[j]["完成进度"] = 40;

                            }


                            if (jishubu == "1" && shengchanbuqueren == "1" && jiagongqueren == "1" && zhuangpeiqueren == "0")
                            {

                                dtt.Rows[j]["完成进度"] = 60;

                            }
                            if (jishubu == "1" && shengchanbuqueren == "1" && jiagongqueren == "1" && zhuangpeiqueren == "1" && tiaoshiqueren == "0")
                            {

                                dtt.Rows[j]["完成进度"] = 80;

                            }
                            if (jishubu == "1" && shengchanbuqueren == "1" && jiagongqueren == "1" && zhuangpeiqueren == "1" && tiaoshiqueren == "1")
                            {

                                dtt.Rows[j]["完成进度"] = 100;

                            }
                        }
                        if (zhizaoleixing != "自制")
                        {
                            if (jishubu == "0")
                            {

                                dtt.Rows[j]["完成进度"] = 0;

                            }
                            if (jishubu == "1" && cangkuqueren == "0")
                            {

                                dtt.Rows[j]["完成进度"] = 50;

                            }
                            if (jishubu == "1" && cangkuqueren == "1")
                            {

                                dtt.Rows[j]["完成进度"] = 100;

                            }

                        }


                    }
                    if (dt.Rows.Count != 1)
                    {
                        jindu = 0;
                        int geshu = dt.Rows.Count;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int jishubu = Convert.ToInt32(dt.Rows[i]["技术部通过"]);
                            int shengchanbuqueren = Convert.ToInt32(dt.Rows[i]["生产部确认"]);
                            int jiagongqueren = Convert.ToInt32(dt.Rows[i]["加工确认"]);
                            int zhuangpeiqueren = Convert.ToInt32(dt.Rows[i]["装配确认"]);
                            int tiaoshiqueren = Convert.ToInt32(dt.Rows[i]["调试确认"]);
                            string zhizaoleixing = dt.Rows[i]["制造类型"].ToString();
                            int cangkuqueren = Convert.ToInt32(dt.Rows[i]["仓库确认"]);

                            if (zhizaoleixing == "自制")
                            {
                                if (jishubu == 0)
                                {

                                    jindu += 0;

                                }
                                if (jishubu == 1 && shengchanbuqueren == 0)
                                {

                                    jindu += (int)(20 / geshu + 0.5);

                                }
                                if (jishubu == 1 && shengchanbuqueren == 1 && jiagongqueren == 0)
                                {

                                    jindu += (int)(40 / geshu + 0.5);

                                }
                                if (jishubu == 1 && shengchanbuqueren == 1 && jiagongqueren == 1 && zhuangpeiqueren == 0)
                                {

                                    jindu += (int)(60 / geshu + 0.5);

                                }
                                if (jishubu == 1 && shengchanbuqueren == 1 && jiagongqueren == 1 && zhuangpeiqueren == 1 && tiaoshiqueren == 0)
                                {

                                    jindu += (int)(80 / geshu + 0.5);

                                }
                                if (jishubu == 1 && shengchanbuqueren == 1 && jiagongqueren == 1 && zhuangpeiqueren == 1 && tiaoshiqueren == 1)
                                {

                                    jindu += (int)(100 / geshu + 0.5);

                                }

                            }
                            if (zhizaoleixing != "自制")

                            {
                                if (jishubu == 0)
                                {

                                    jindu += 0;

                                }


                                if (jishubu == 1 && cangkuqueren == 0)
                                {
                                    //dtt.Rows[j]["到达阶段"] = "研发阶段";
                                    jindu += (int)(50 / geshu + 0.5);

                                }
                                if (jishubu == 1 && cangkuqueren == 1)
                                {
                                    //dtt.Rows[j]["到达阶段"] = "研发阶段";
                                    jindu += (int)(100 / geshu + 0.5);

                                }

                            }
                        }
                        dtt.Rows[j]["完成进度"] = jindu;
                    }


                }

                dataGridViewX2.DataSource = dtt;
            }
            if (comboBoxItem1.Text == "石英事业部")
            {
                string sql = "select  id,工作令号,项目名称,客户名称,交货日期,反馈,项目负责人,采购负责人,装配负责人 from tb_xiangmu where 项目主管='蒋云'";

                 dtt = SQLhelp.GetDataTable(sql, CommandType.Text);

                DataColumn column1 = new DataColumn();

                column1.DataType = System.Type.GetType("System.Int32");

                column1.ColumnName = "完成进度";

                dtt.Columns.Add(column1);


                for (int j = 0; j < dtt.Rows.Count; j++)
                {
                    string gongzuolinghao = dtt.Rows[j]["工作令号"].ToString();
                    string xiangmumingcheng = dtt.Rows[j]["项目名称"].ToString();


                    //string sql1 = "select 工作令号,项目名称,时间,技术部通过,生产部确认,加工确认,装配确认,调试确认,制造类型,仓库确认 from tb_jishubumen where 工作令号='17-ZTZN-HK016' and 项目名称='非晶分合卷项目'";

                    string sql1 = "select 工作令号,项目名称,时间,技术部通过,生产部确认,加工确认,装配确认,调试确认,制造类型,仓库确认 from tb_jishubumen where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'";


                    DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                    if (dt.Rows.Count == 1)
                    {
                        jindu = 0;
                        string jishubu = dt.Rows[0]["技术部通过"].ToString();
                        string shengchanbuqueren = dt.Rows[0]["生产部确认"].ToString();
                        string jiagongqueren = dt.Rows[0]["加工确认"].ToString();
                        string zhuangpeiqueren = dt.Rows[0]["装配确认"].ToString();
                        string tiaoshiqueren = dt.Rows[0]["调试确认"].ToString();
                        string zhizaoleixing = dt.Rows[0]["制造类型"].ToString();
                        string cangkuqueren = dt.Rows[0]["仓库确认"].ToString();
                        if (zhizaoleixing == "自制")
                        {
                            if (jishubu == "0")
                            {

                                dtt.Rows[j]["完成进度"] = 0;

                            }
                            if (jishubu == "1" && shengchanbuqueren == "0")
                            {

                                dtt.Rows[j]["完成进度"] = 20;

                            }

                            if (jishubu == "1" && shengchanbuqueren == "1" && jiagongqueren == "0")
                            {

                                dtt.Rows[j]["完成进度"] = 40;

                            }


                            if (jishubu == "1" && shengchanbuqueren == "1" && jiagongqueren == "1" && zhuangpeiqueren == "0")
                            {

                                dtt.Rows[j]["完成进度"] = 60;

                            }
                            if (jishubu == "1" && shengchanbuqueren == "1" && jiagongqueren == "1" && zhuangpeiqueren == "1" && tiaoshiqueren == "0")
                            {

                                dtt.Rows[j]["完成进度"] = 80;

                            }
                            if (jishubu == "1" && shengchanbuqueren == "1" && jiagongqueren == "1" && zhuangpeiqueren == "1" && tiaoshiqueren == "1")
                            {

                                dtt.Rows[j]["完成进度"] = 100;

                            }
                        }
                        if (zhizaoleixing != "自制")
                        {
                            if (jishubu == "0")
                            {

                                dtt.Rows[j]["完成进度"] = 0;

                            }
                            if (jishubu == "1" && cangkuqueren == "0")
                            {

                                dtt.Rows[j]["完成进度"] = 50;

                            }
                            if (jishubu == "1" && cangkuqueren == "1")
                            {

                                dtt.Rows[j]["完成进度"] = 100;

                            }

                        }


                    }
                    if (dt.Rows.Count != 1)
                    {
                        jindu = 0;
                        int geshu = dt.Rows.Count;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int jishubu = Convert.ToInt32(dt.Rows[i]["技术部通过"]);
                            int shengchanbuqueren = Convert.ToInt32(dt.Rows[i]["生产部确认"]);
                            int jiagongqueren = Convert.ToInt32(dt.Rows[i]["加工确认"]);
                            int zhuangpeiqueren = Convert.ToInt32(dt.Rows[i]["装配确认"]);
                            int tiaoshiqueren = Convert.ToInt32(dt.Rows[i]["调试确认"]);
                            string zhizaoleixing = dt.Rows[i]["制造类型"].ToString();
                            int cangkuqueren = Convert.ToInt32(dt.Rows[i]["仓库确认"]);

                            if (zhizaoleixing == "自制")
                            {
                                if (jishubu == 0)
                                {

                                    jindu += 0;

                                }
                                if (jishubu == 1 && shengchanbuqueren == 0)
                                {

                                    jindu += (int)(20 / geshu + 0.5);

                                }
                                if (jishubu == 1 && shengchanbuqueren == 1 && jiagongqueren == 0)
                                {

                                    jindu += (int)(40 / geshu + 0.5);

                                }
                                if (jishubu == 1 && shengchanbuqueren == 1 && jiagongqueren == 1 && zhuangpeiqueren == 0)
                                {

                                    jindu += (int)(60 / geshu + 0.5);

                                }
                                if (jishubu == 1 && shengchanbuqueren == 1 && jiagongqueren == 1 && zhuangpeiqueren == 1 && tiaoshiqueren == 0)
                                {

                                    jindu += (int)(80 / geshu + 0.5);

                                }
                                if (jishubu == 1 && shengchanbuqueren == 1 && jiagongqueren == 1 && zhuangpeiqueren == 1 && tiaoshiqueren == 1)
                                {

                                    jindu += (int)(100 / geshu + 0.5);

                                }

                            }
                            if (zhizaoleixing != "自制")

                            {
                                if (jishubu == 0)
                                {

                                    jindu += 0;

                                }


                                if (jishubu == 1 && cangkuqueren == 0)
                                {
                                    //dtt.Rows[j]["到达阶段"] = "研发阶段";
                                    jindu += (int)(50 / geshu + 0.5);

                                }
                                if (jishubu == 1 && cangkuqueren == 1)
                                {
                                    //dtt.Rows[j]["到达阶段"] = "研发阶段";
                                    jindu += (int)(100 / geshu + 0.5);

                                }

                            }
                        }
                        dtt.Rows[j]["完成进度"] = jindu;
                    }


                }
               
                dataGridViewX2.DataSource = dtt;




            }
            if (comboBoxItem1.Text == "新材事业部")
            {
                string sql = "select  id,工作令号,项目名称,客户名称,交货日期,反馈,项目负责人,采购负责人,装配负责人 from tb_xiangmu where 项目主管='沈维佳'";
 dtt = SQLhelp.GetDataTable(sql, CommandType.Text);


                DataColumn column1 = new DataColumn();

                column1.DataType = System.Type.GetType("System.Int32");

                column1.ColumnName = "完成进度";

                dtt.Columns.Add(column1);

                for (int j = 0; j < dtt.Rows.Count; j++)
                {
                    string gongzuolinghao = dtt.Rows[j]["工作令号"].ToString();
                    string xiangmumingcheng = dtt.Rows[j]["项目名称"].ToString();


                    //string sql1 = "select 工作令号,项目名称,时间,技术部通过,生产部确认,加工确认,装配确认,调试确认,制造类型,仓库确认 from tb_jishubumen where 工作令号='17-ZTZN-HK016' and 项目名称='非晶分合卷项目'";

                    string sql1 = "select 工作令号,项目名称,时间,技术部通过,生产部确认,加工确认,装配确认,调试确认,制造类型,仓库确认 from tb_jishubumen where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'";


                    DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                    if (dt.Rows.Count == 1)
                    {
                        jindu = 0;
                        string jishubu = dt.Rows[0]["技术部通过"].ToString();
                        string shengchanbuqueren = dt.Rows[0]["生产部确认"].ToString();
                        string jiagongqueren = dt.Rows[0]["加工确认"].ToString();
                        string zhuangpeiqueren = dt.Rows[0]["装配确认"].ToString();
                        string tiaoshiqueren = dt.Rows[0]["调试确认"].ToString();
                        string zhizaoleixing = dt.Rows[0]["制造类型"].ToString();
                        string cangkuqueren = dt.Rows[0]["仓库确认"].ToString();
                        if (zhizaoleixing == "自制")
                        {
                            if (jishubu == "0")
                            {

                                dtt.Rows[j]["完成进度"] = 0;

                            }
                            if (jishubu == "1" && shengchanbuqueren == "0")
                            {

                                dtt.Rows[j]["完成进度"] = 20;

                            }

                            if (jishubu == "1" && shengchanbuqueren == "1" && jiagongqueren == "0")
                            {

                                dtt.Rows[j]["完成进度"] = 40;

                            }


                            if (jishubu == "1" && shengchanbuqueren == "1" && jiagongqueren == "1" && zhuangpeiqueren == "0")
                            {

                                dtt.Rows[j]["完成进度"] = 60;

                            }
                            if (jishubu == "1" && shengchanbuqueren == "1" && jiagongqueren == "1" && zhuangpeiqueren == "1" && tiaoshiqueren == "0")
                            {

                                dtt.Rows[j]["完成进度"] = 80;

                            }
                            if (jishubu == "1" && shengchanbuqueren == "1" && jiagongqueren == "1" && zhuangpeiqueren == "1" && tiaoshiqueren == "1")
                            {

                                dtt.Rows[j]["完成进度"] = 100;

                            }
                        }
                        if (zhizaoleixing != "自制")
                        {
                            if (jishubu == "0")
                            {

                                dtt.Rows[j]["完成进度"] = 0;

                            }
                            if (jishubu == "1" && cangkuqueren == "0")
                            {

                                dtt.Rows[j]["完成进度"] = 50;

                            }
                            if (jishubu == "1" && cangkuqueren == "1")
                            {

                                dtt.Rows[j]["完成进度"] = 100;

                            }

                        }


                    }
                    if (dt.Rows.Count != 1)
                    {
                        jindu = 0;
                        int geshu = dt.Rows.Count;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int jishubu = Convert.ToInt32(dt.Rows[i]["技术部通过"]);
                            int shengchanbuqueren = Convert.ToInt32(dt.Rows[i]["生产部确认"]);
                            int jiagongqueren = Convert.ToInt32(dt.Rows[i]["加工确认"]);
                            int zhuangpeiqueren = Convert.ToInt32(dt.Rows[i]["装配确认"]);
                            int tiaoshiqueren = Convert.ToInt32(dt.Rows[i]["调试确认"]);
                            string zhizaoleixing = dt.Rows[i]["制造类型"].ToString();
                            int cangkuqueren = Convert.ToInt32(dt.Rows[i]["仓库确认"]);

                            if (zhizaoleixing == "自制")
                            {
                                if (jishubu == 0)
                                {

                                    jindu += 0;

                                }
                                if (jishubu == 1 && shengchanbuqueren == 0)
                                {

                                    jindu += (int)(20 / geshu + 0.5);

                                }
                                if (jishubu == 1 && shengchanbuqueren == 1 && jiagongqueren == 0)
                                {

                                    jindu += (int)(40 / geshu + 0.5);

                                }
                                if (jishubu == 1 && shengchanbuqueren == 1 && jiagongqueren == 1 && zhuangpeiqueren == 0)
                                {

                                    jindu += (int)(60 / geshu + 0.5);

                                }
                                if (jishubu == 1 && shengchanbuqueren == 1 && jiagongqueren == 1 && zhuangpeiqueren == 1 && tiaoshiqueren == 0)
                                {

                                    jindu += (int)(80 / geshu + 0.5);

                                }
                                if (jishubu == 1 && shengchanbuqueren == 1 && jiagongqueren == 1 && zhuangpeiqueren == 1 && tiaoshiqueren == 1)
                                {

                                    jindu += (int)(100 / geshu + 0.5);

                                }

                            }
                            if (zhizaoleixing != "自制")

                            {
                                if (jishubu == 0)
                                {

                                    jindu += 0;

                                }


                                if (jishubu == 1 && cangkuqueren == 0)
                                {
                                    //dtt.Rows[j]["到达阶段"] = "研发阶段";
                                    jindu += (int)(50 / geshu + 0.5);

                                }
                                if (jishubu == 1 && cangkuqueren == 1)
                                {
                                    //dtt.Rows[j]["到达阶段"] = "研发阶段";
                                    jindu += (int)(100 / geshu + 0.5);

                                }

                            }
                        }
                        dtt.Rows[j]["完成进度"] = jindu;
                    }


                }
               
                dataGridViewX2.DataSource = dtt;




            }
            if (comboBoxItem1.Text == "薄材事业部")
            {
                string sql = "select  id,工作令号,项目名称,客户名称,交货日期,反馈,项目负责人,采购负责人,装配负责人 from tb_xiangmu where 项目主管='曹伟伟'";

                dtt = SQLhelp.GetDataTable(sql, CommandType.Text);
                DataColumn column1 = new DataColumn();

                column1.DataType = System.Type.GetType("System.Int32");

                column1.ColumnName = "完成进度";

                dtt.Columns.Add(column1);



                for (int j = 0; j < dtt.Rows.Count; j++)
                {
                    string gongzuolinghao = dtt.Rows[j]["工作令号"].ToString();
                    string xiangmumingcheng = dtt.Rows[j]["项目名称"].ToString();


                    //string sql1 = "select 工作令号,项目名称,时间,技术部通过,生产部确认,加工确认,装配确认,调试确认,制造类型,仓库确认 from tb_jishubumen where 工作令号='17-ZTZN-HK016' and 项目名称='非晶分合卷项目'";

                    string sql1 = "select 工作令号,项目名称,时间,技术部通过,生产部确认,加工确认,装配确认,调试确认,制造类型,仓库确认 from tb_jishubumen where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'";


                    DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                    if (dt.Rows.Count == 1)
                    {
                        jindu = 0;
                        string jishubu = dt.Rows[0]["技术部通过"].ToString();
                        string shengchanbuqueren = dt.Rows[0]["生产部确认"].ToString();
                        string jiagongqueren = dt.Rows[0]["加工确认"].ToString();
                        string zhuangpeiqueren = dt.Rows[0]["装配确认"].ToString();
                        string tiaoshiqueren = dt.Rows[0]["调试确认"].ToString();
                        string zhizaoleixing = dt.Rows[0]["制造类型"].ToString();
                        string cangkuqueren = dt.Rows[0]["仓库确认"].ToString();
                        if (zhizaoleixing == "自制")
                        {
                            if (jishubu == "0")
                            {

                                dtt.Rows[j]["完成进度"] = 0;

                            }
                            if (jishubu == "1" && shengchanbuqueren == "0")
                            {

                                dtt.Rows[j]["完成进度"] = 20;

                            }

                            if (jishubu == "1" && shengchanbuqueren == "1" && jiagongqueren == "0")
                            {

                                dtt.Rows[j]["完成进度"] = 40;

                            }


                            if (jishubu == "1" && shengchanbuqueren == "1" && jiagongqueren == "1" && zhuangpeiqueren == "0")
                            {

                                dtt.Rows[j]["完成进度"] = 60;

                            }
                            if (jishubu == "1" && shengchanbuqueren == "1" && jiagongqueren == "1" && zhuangpeiqueren == "1" && tiaoshiqueren == "0")
                            {

                                dtt.Rows[j]["完成进度"] = 80;

                            }
                            if (jishubu == "1" && shengchanbuqueren == "1" && jiagongqueren == "1" && zhuangpeiqueren == "1" && tiaoshiqueren == "1")
                            {

                                dtt.Rows[j]["完成进度"] = 100;

                            }
                        }
                        if (zhizaoleixing != "自制")
                        {
                            if (jishubu == "0")
                            {

                                dtt.Rows[j]["完成进度"] = 0;

                            }
                            if (jishubu == "1" && cangkuqueren == "0")
                            {

                                dtt.Rows[j]["完成进度"] = 50;

                            }
                            if (jishubu == "1" && cangkuqueren == "1")
                            {

                                dtt.Rows[j]["完成进度"] = 100;

                            }

                        }


                    }
                    if (dt.Rows.Count != 1)
                    {
                        jindu = 0;
                        int geshu = dt.Rows.Count;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int jishubu = Convert.ToInt32(dt.Rows[i]["技术部通过"]);
                            int shengchanbuqueren = Convert.ToInt32(dt.Rows[i]["生产部确认"]);
                            int jiagongqueren = Convert.ToInt32(dt.Rows[i]["加工确认"]);
                            int zhuangpeiqueren = Convert.ToInt32(dt.Rows[i]["装配确认"]);
                            int tiaoshiqueren = Convert.ToInt32(dt.Rows[i]["调试确认"]);
                            string zhizaoleixing = dt.Rows[i]["制造类型"].ToString();
                            int cangkuqueren = Convert.ToInt32(dt.Rows[i]["仓库确认"]);

                            if (zhizaoleixing == "自制")
                            {
                                if (jishubu == 0)
                                {

                                    jindu += 0;

                                }
                                if (jishubu == 1 && shengchanbuqueren == 0)
                                {

                                    jindu += (int)(20 / geshu + 0.5);

                                }
                                if (jishubu == 1 && shengchanbuqueren == 1 && jiagongqueren == 0)
                                {

                                    jindu += (int)(40 / geshu + 0.5);

                                }
                                if (jishubu == 1 && shengchanbuqueren == 1 && jiagongqueren == 1 && zhuangpeiqueren == 0)
                                {

                                    jindu += (int)(60 / geshu + 0.5);

                                }
                                if (jishubu == 1 && shengchanbuqueren == 1 && jiagongqueren == 1 && zhuangpeiqueren == 1 && tiaoshiqueren == 0)
                                {

                                    jindu += (int)(80 / geshu + 0.5);

                                }
                                if (jishubu == 1 && shengchanbuqueren == 1 && jiagongqueren == 1 && zhuangpeiqueren == 1 && tiaoshiqueren == 1)
                                {

                                    jindu += (int)(100 / geshu + 0.5);

                                }

                            }
                            if (zhizaoleixing != "自制")

                            {
                                if (jishubu == 0)
                                {

                                    jindu += 0;

                                }


                                if (jishubu == 1 && cangkuqueren == 0)
                                {
                                    //dtt.Rows[j]["到达阶段"] = "研发阶段";
                                    jindu += (int)(50 / geshu + 0.5);

                                }
                                if (jishubu == 1 && cangkuqueren == 1)
                                {
                                    //dtt.Rows[j]["到达阶段"] = "研发阶段";
                                    jindu += (int)(100 / geshu + 0.5);

                                }

                            }
                        }
                        dtt.Rows[j]["完成进度"] = jindu;
                    }


                }
               
                dataGridViewX2.DataSource = dtt;




            }
            if (comboBoxItem1.Text == "智能事业部")
            {
                string sql = "select  id,工作令号,项目名称,客户名称,交货日期,反馈,项目负责人,采购负责人,装配负责人 from tb_xiangmu where 项目主管='蔡守军'";

               dtt = SQLhelp.GetDataTable(sql, CommandType.Text);

                DataColumn column1 = new DataColumn();

                column1.DataType = System.Type.GetType("System.Int32");

                column1.ColumnName = "完成进度";

                dtt.Columns.Add(column1);


                for (int j = 0; j < dtt.Rows.Count; j++)
                {
                    string gongzuolinghao = dtt.Rows[j]["工作令号"].ToString();
                    string xiangmumingcheng = dtt.Rows[j]["项目名称"].ToString();


                    //string sql1 = "select 工作令号,项目名称,时间,技术部通过,生产部确认,加工确认,装配确认,调试确认,制造类型,仓库确认 from tb_jishubumen where 工作令号='17-ZTZN-HK016' and 项目名称='非晶分合卷项目'";

                    string sql1 = "select 工作令号,项目名称,时间,技术部通过,生产部确认,加工确认,装配确认,调试确认,制造类型,仓库确认 from tb_jishubumen where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'";


                    DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                    if (dt.Rows.Count == 1)
                    {
                        jindu = 0;
                        string jishubu = dt.Rows[0]["技术部通过"].ToString();
                        string shengchanbuqueren = dt.Rows[0]["生产部确认"].ToString();
                        string jiagongqueren = dt.Rows[0]["加工确认"].ToString();
                        string zhuangpeiqueren = dt.Rows[0]["装配确认"].ToString();
                        string tiaoshiqueren = dt.Rows[0]["调试确认"].ToString();
                        string zhizaoleixing = dt.Rows[0]["制造类型"].ToString();
                        string cangkuqueren = dt.Rows[0]["仓库确认"].ToString();
                        if (zhizaoleixing == "自制")
                        {
                            if (jishubu == "0")
                            {

                                dtt.Rows[j]["完成进度"] = 0;

                            }
                            if (jishubu == "1" && shengchanbuqueren == "0")
                            {

                                dtt.Rows[j]["完成进度"] = 20;

                            }

                            if (jishubu == "1" && shengchanbuqueren == "1" && jiagongqueren == "0")
                            {

                                dtt.Rows[j]["完成进度"] = 40;

                            }


                            if (jishubu == "1" && shengchanbuqueren == "1" && jiagongqueren == "1" && zhuangpeiqueren == "0")
                            {

                                dtt.Rows[j]["完成进度"] = 60;

                            }
                            if (jishubu == "1" && shengchanbuqueren == "1" && jiagongqueren == "1" && zhuangpeiqueren == "1" && tiaoshiqueren == "0")
                            {

                                dtt.Rows[j]["完成进度"] = 80;

                            }
                            if (jishubu == "1" && shengchanbuqueren == "1" && jiagongqueren == "1" && zhuangpeiqueren == "1" && tiaoshiqueren == "1")
                            {

                                dtt.Rows[j]["完成进度"] = 100;

                            }
                        }
                        if (zhizaoleixing != "自制")
                        {
                            if (jishubu == "0")
                            {

                                dtt.Rows[j]["完成进度"] = 0;

                            }
                            if (jishubu == "1" && cangkuqueren == "0")
                            {

                                dtt.Rows[j]["完成进度"] = 50;

                            }
                            if (jishubu == "1" && cangkuqueren == "1")
                            {

                                dtt.Rows[j]["完成进度"] = 100;

                            }

                        }


                    }
                    if (dt.Rows.Count != 1)
                    {
                        jindu = 0;
                        int geshu = dt.Rows.Count;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int jishubu = Convert.ToInt32(dt.Rows[i]["技术部通过"]);
                            int shengchanbuqueren = Convert.ToInt32(dt.Rows[i]["生产部确认"]);
                            int jiagongqueren = Convert.ToInt32(dt.Rows[i]["加工确认"]);
                            int zhuangpeiqueren = Convert.ToInt32(dt.Rows[i]["装配确认"]);
                            int tiaoshiqueren = Convert.ToInt32(dt.Rows[i]["调试确认"]);
                            string zhizaoleixing = dt.Rows[i]["制造类型"].ToString();
                            int cangkuqueren = Convert.ToInt32(dt.Rows[i]["仓库确认"]);

                            if (zhizaoleixing == "自制")
                            {
                                if (jishubu == 0)
                                {

                                    jindu += 0;

                                }
                                if (jishubu == 1 && shengchanbuqueren == 0)
                                {

                                    jindu += (int)(20 / geshu + 0.5);

                                }
                                if (jishubu == 1 && shengchanbuqueren == 1 && jiagongqueren == 0)
                                {

                                    jindu += (int)(40 / geshu + 0.5);

                                }
                                if (jishubu == 1 && shengchanbuqueren == 1 && jiagongqueren == 1 && zhuangpeiqueren == 0)
                                {

                                    jindu += (int)(60 / geshu + 0.5);

                                }
                                if (jishubu == 1 && shengchanbuqueren == 1 && jiagongqueren == 1 && zhuangpeiqueren == 1 && tiaoshiqueren == 0)
                                {

                                    jindu += (int)(80 / geshu + 0.5);

                                }
                                if (jishubu == 1 && shengchanbuqueren == 1 && jiagongqueren == 1 && zhuangpeiqueren == 1 && tiaoshiqueren == 1)
                                {

                                    jindu += (int)(100 / geshu + 0.5);

                                }

                            }
                            if (zhizaoleixing != "自制")

                            {
                                if (jishubu == 0)
                                {

                                    jindu += 0;

                                }


                                if (jishubu == 1 && cangkuqueren == 0)
                                {
                                    //dtt.Rows[j]["到达阶段"] = "研发阶段";
                                    jindu += (int)(50 / geshu + 0.5);

                                }
                                if (jishubu == 1 && cangkuqueren == 1)
                                {
                                    //dtt.Rows[j]["到达阶段"] = "研发阶段";
                                    jindu += (int)(100 / geshu + 0.5);

                                }

                            }
                        }
                        dtt.Rows[j]["完成进度"] = jindu;
                    }


                }
               
                dataGridViewX2.DataSource = dtt;

            }

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

        private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewX1.Rows.Count == 0)
            {
                MessageBox.Show("请选中行！");
                return;

            }

            FrXiangxi form = new FrXiangxi();
            form.gongzuolinghao = dataGridViewX1.CurrentRow.Cells["工作令号2"].Value.ToString();
            form.xiangmumingcheng = dataGridViewX1.CurrentRow.Cells["项目名称2"].Value.ToString();
            form.yonghu = yonghu;
            form.ShowDialog();
            
        }

        private void dataGridViewX3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewX3.Rows.Count==0)
            {
                MessageBox.Show("请选中行！");
                return;

            }

            FrXiangxi form = new FrXiangxi();
            form.gongzuolinghao = dataGridViewX3.CurrentRow.Cells["工作令号"].Value.ToString();
            form.xiangmumingcheng = dataGridViewX3.CurrentRow.Cells["项目名称"].Value.ToString();
            form.yonghu= yonghu;
            form.ShowDialog();
        }

        private void 确认完成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (yonghu == "韩小建")
            {
                if (MessageBox.Show("确认提交吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    string id = dataGridViewX2.CurrentRow.Cells["id"].Value.ToString();
                    string sql = "update tb_xiangmu set 未交货项目 =NULL , 已交货未调试项目=1 where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql, CommandType.Text);
                    MessageBox.Show("确认成功！");
                    Reload();
                    Reload2();
                    Reload3();
                }
            }
            if(yonghu!="韩小建")
            {
                
                MessageBox.Show("无权限！");
                return;
            }

        }

        private void 上传项目清单ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string id = dataGridViewX2.CurrentRow.Cells["id"].Value.ToString();

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
                
             
                string sql1= "update tb_xiangmu  set 项目清单=@pic where id='" + id + "'";
                SQLhelp.ExecuteNonquery(sql1, CommandType.Text, files);
                string sql = "update tb_xiangmu set 项目清单名称='" + mingcheng + "',项目清单类型='" + fileType + "' where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);
                MessageBox.Show("上传成功！");
            }

        }

        private void 下载项目清单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = dataGridViewX2.CurrentRow.Cells["id"].Value.ToString();
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
                string lujing = xuanzelujing + "\\" +mingcheng + "." + leixing;
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

        private void 下载该项目设备清单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string gongzuolinghao = dataGridViewX2.CurrentRow.Cells["工作令号"].Value.ToString();
            string xiangmumingcheng = dataGridViewX2.CurrentRow.Cells["项目名称"].Value.ToString();
        

            string sql1 = "select  工作令号,项目名称,设备名称,数量,制造类型 from tb_jishubumen  where 工作令号='" +gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 技术部通过='1'";
            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

            string lujing = "";
            SaveFileDialog op = new SaveFileDialog();
            op.Filter = "EXCEL文件|*.xls;*,xlsx;";
            if (op.ShowDialog() == DialogResult.OK)//显示保存文件对话框
            {



                lujing = op.FileName;

            }

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

        private void dataGridViewX4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            FrXiangxi form = new FrXiangxi();
            form.gongzuolinghao = dataGridViewX4.CurrentRow.Cells["工作令号4"].Value.ToString();
            form.xiangmumingcheng = dataGridViewX4.CurrentRow.Cells["项目名称4"].Value.ToString();

            form.yonghu = yonghu;
            form.ShowDialog();
        }

        private void dataGridViewX4_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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



