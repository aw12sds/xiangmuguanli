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
    public partial class Frbeiliao : Office2007Form
    {
        public Frbeiliao()
        {
            InitializeComponent();
        }
        public string yonghu;
        int jindu = 0;
        DataTable dtt;
        
        private void Frbeiliao_Load(object sender, EventArgs e)
        {
            string sql = "select id,工作令号,项目名称,客户名称,交货日期,装配负责人  from tb_xiangmu  where 未交货项目=1 ";

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
           gridControl2.DataSource = dtt;
            
        }

        
        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
            {

                Frbeiliaoxiangmu form = new Frbeiliaoxiangmu();
                form.gongzuolinghao = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "工作令号"));

                form.xiangmumingcheng = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "项目名称"));

                form.yonghu = yonghu;
                form.ShowDialog();
            }
        }
    }
}
