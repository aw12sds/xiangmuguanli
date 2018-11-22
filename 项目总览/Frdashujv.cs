using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraCharts;
using DevExpress.Utils;

namespace 项目管理系统.项目总览
{
    public partial class Frdashujv : DevExpress.XtraEditors.XtraForm
    {
      public Frdashujv()
        {
            InitializeComponent();
        }
        public string gongzuolinghao;
        public string xiangmumingcheng;
        public string shebeimingcheng;
        public string shijian;    
        private void Frdashujv_Load(object sender, EventArgs e)
        {
            string shebeizongshu = "select count(*) from tb_jishubumen where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'  ";
            dashboardTileBarItem.Text = dashboardTileBarItem.Text + " " + SQLhelp.ExecuteScalar(shebeizongshu, CommandType.Text).ToString();
            string shejiweiwancheng = "select count(*) from tb_jishubumen where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 技术部通过=1  and 图纸下达=0  ";
            tasksTileBarItem.Text = tasksTileBarItem.Text + " " + SQLhelp.ExecuteScalar(shejiweiwancheng, CommandType.Text).ToString();
            string jiagongweiwancheng = "select count(*) from tb_jishubumen where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 技术部通过=1  and 制造类型='自制' and 生产部确认=1 and 加工确认=0  ";
            employeesTileBarItem.Text = employeesTileBarItem.Text + " " + SQLhelp.ExecuteScalar(jiagongweiwancheng, CommandType.Text).ToString();
            string caigouwancheng = "select count(*) from tb_jishubumen where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 技术部通过=1  and 物流部确认=1 and 物流部最终确认=0  ";
            tileBarItem1.Text = tileBarItem1.Text + " " + SQLhelp.ExecuteScalar(caigouwancheng, CommandType.Text).ToString();

            string zhuangpeiuwancheng = "select count(*) from tb_jishubumen where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 技术部通过=1  and 制造类型='自制'  and 加工确认=1 and 装配确认=0  ";
            tileBarItem2.Text = tileBarItem2.Text + " " + SQLhelp.ExecuteScalar(zhuangpeiuwancheng, CommandType.Text).ToString();



            string caigouweiwanchengliang = "select count(*) from tb_caigouliaodan where (工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 制造类型!='自制零部件'  and 制造类型!='装配零部件'  and 制造类型!='库存件'  and 制造类型!='零件'  and 当前状态!='9已到货' and 当前状态!='10已出库' and 当前状态!='5生产制作中') or (工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 制造类型!='自制零部件'  and 制造类型!='装配零部件'  and 制造类型!='库存件'  and 制造类型!='零件'  and 当前状态 is null) ";

            tileBarItem3.Text = tileBarItem3.Text + " " + SQLhelp.ExecuteScalar(caigouweiwanchengliang, CommandType.Text).ToString();


            string caigouweidaohuoliang1 = "select count(*) from tb_caigouliaodan where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 制造类型!='自制零部件'  and 制造类型!='装配零部件'  and 制造类型!='库存件'  and 制造类型!='零件'  and 当前状态='5生产制作中'";

            tileBarItem4.Text = tileBarItem4.Text + " " + SQLhelp.ExecuteScalar(caigouweidaohuoliang1, CommandType.Text).ToString();



            string caigouweidaohuoliang = "select count(*) from tb_jishubumen where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 技术部通过=1  and 制造类型='自制'  and 加工确认=1 and 装配确认=0  ";
            tileBarItem2.Text = tileBarItem2.Text + " " + SQLhelp.ExecuteScalar(zhuangpeiuwancheng, CommandType.Text).ToString();






            string sqllingjian1 = "select count(*) from tb_caigouliaodan where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'  and  制造类型='自制零部件'  ";
            string zizhi = SQLhelp.ExecuteScalar(sqllingjian1, CommandType.Text).ToString();
            string sqllingjian2 = "select count(*) from tb_caigouliaodan where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'  and  制造类型='外协零部件'  ";
            string waixie = SQLhelp.ExecuteScalar(sqllingjian2, CommandType.Text).ToString();
            string sqllingjian3 = "select count(*) from tb_caigouliaodan where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'  and  制造类型='机械标准件'  ";
            string jixiebiaozhun = SQLhelp.ExecuteScalar(sqllingjian3, CommandType.Text).ToString();
            string sqllingjian4 = "select count(*) from tb_caigouliaodan where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'  and  制造类型='电气标准件'  ";
            string dianqi = SQLhelp.ExecuteScalar(sqllingjian4, CommandType.Text).ToString();
            string sqllingjian5 = "select count(*) from tb_caigouliaodan where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'  and  制造类型='外购'  ";
            string waigou = SQLhelp.ExecuteScalar(sqllingjian5, CommandType.Text).ToString();

            string sqllingjian6 = "select count(*) from tb_caigouliaodan where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'  and  制造类型='库存件'  ";
            string kucun = SQLhelp.ExecuteScalar(sqllingjian6, CommandType.Text).ToString();

            DataTable bing = new DataTable();
            bing.Columns.Add("name", typeof(string));
            bing.Columns.Add("value", typeof(double));
            DataRow newRow;
            newRow = bing.NewRow();
            newRow["name"] = "自制零部件";
            newRow["value"] = zizhi;
            bing.Rows.Add(newRow);

            DataRow newRow1;
            newRow1 = bing.NewRow();
            newRow1["name"] = "外协零部件";
            newRow1["value"] = waixie;
            bing.Rows.Add(newRow1);

            DataRow newRow2;
            newRow2 = bing.NewRow();
            newRow2["name"] = "机械标准件";
            newRow2["value"] = jixiebiaozhun;
            bing.Rows.Add(newRow2);

            DataRow newRow3;
            newRow3 = bing.NewRow();
            newRow3["name"] = "电气标准件";
            newRow3["value"] = dianqi;
            bing.Rows.Add(newRow3);

            DataRow newRow4;
            newRow4 = bing.NewRow();
            newRow4["name"] = "外购";
            newRow4["value"] = waigou;
            bing.Rows.Add(newRow4);


            DataRow newRow5;
            newRow5 = bing.NewRow();
            newRow5["name"] = "库存件";
            newRow5["value"] = kucun;
            bing.Rows.Add(newRow5);
            Series Series2 = new Series("种类分布", ViewType.Pie);
            Series2.ArgumentScaleType = ScaleType.Qualitative;
            Series2.ArgumentDataMember = "name";
            Series2.ValueDataMembers[0] = "value";
            Series2.DataSource = bing;
            Series2.Label.TextPattern = "{A}:{VP:0.00%}";
            chartControl1.Series.Add(Series2);

            chartControl1.ToolTipEnabled = DevExpress.Utils.DefaultBoolean.True;

            string sql = "select 设备名称,采购部件总数量 from tb_jishubumen where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' ";
            DataTable dtt = SQLhelp.GetDataTable(sql, CommandType.Text);
            for (int j = 0; j < dtt.Rows.Count; j++)
            {
                string b = Convert.ToString(dtt.Rows[j]["采购部件总数量"]);
                if (b == "")
                {
                    dtt.Rows[j]["采购部件总数量"] = 0;
                }
            }
            Series Series1 = new Series(dtt.Rows[0][0].ToString(), ViewType.Bar);
            Series1.ArgumentScaleType = ScaleType.Qualitative;
            DataTable table = new DataTable();
            table.Columns.Add("Name", typeof(String));
            table.Columns.Add("Value", typeof(Double));
            foreach (DataRow item in dtt.Rows)
            {
                var array = new object[] { item["设备名称"], item["采购部件总数量"] };
                table.Rows.Add(array);
            }


            Series1.ArgumentDataMember = "Name";
            Series1.ValueDataMembers[0] = "Value";
            Series1.DataSource = table;
            Series1.Label.TextPattern = "{A}:{VP:0.00%}";
            chartControl2.Series.Add(Series1);


            string sqllingjian11 = "select count(*) from tb_caigouliaodan where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'  and  当前状态='1询价中'";
            string xunjia = SQLhelp.ExecuteScalar(sqllingjian11, CommandType.Text).ToString();
            string sqllingjian22 = "select count(*) from tb_caigouliaodan where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'  and   当前状态='5生产制作中'";
            string shengchan = SQLhelp.ExecuteScalar(sqllingjian22, CommandType.Text).ToString();
            string sqllingjian33 = "select count(*) from tb_caigouliaodan where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'  and  当前状态='9已到货'";
            string daohuo = SQLhelp.ExecuteScalar(sqllingjian33, CommandType.Text).ToString();
            string sqllingjian44 = "select count(*) from tb_caigouliaodan where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and  当前状态='10已出库'";
            string chuku = SQLhelp.ExecuteScalar(sqllingjian44, CommandType.Text).ToString();
            string sqllingjian55 = "select count(*) from tb_caigouliaodan where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'  and   当前状态='已加工'";
            string jiagong = SQLhelp.ExecuteScalar(sqllingjian55, CommandType.Text).ToString();

            string sqllingjian66 = "select count(*) from tb_caigouliaodan where (工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'  and   当前状态!='已加工' and   当前状态!='1询价中' and   当前状态!='5生产制作中' and   当前状态!='9已到货' and   当前状态!='10已出库'  and  制造类型!='库存件') or (工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'  and   当前状态 is null )";
            string buqueding = SQLhelp.ExecuteScalar(sqllingjian66, CommandType.Text).ToString();

            DataTable bing1 = new DataTable();
            bing1.Columns.Add("name", typeof(string));
            bing1.Columns.Add("value", typeof(double));
            DataRow newRoww;
            newRoww = bing1.NewRow();
            newRoww["name"] = "1询价中";
            newRoww["value"] = xunjia;
            bing1.Rows.Add(newRoww);

            DataRow newRoww1;
            newRoww1 = bing1.NewRow();
            newRoww1["name"] = "5生产制作中";
            newRoww1["value"] = shengchan;
            bing1.Rows.Add(newRoww1);

            DataRow newRoww2;
            newRoww2 = bing1.NewRow();
            newRoww2["name"] = "9已到货";
            newRoww2["value"] = daohuo;
            bing1.Rows.Add(newRoww2);

            DataRow newRoww3;
            newRoww3 = bing1.NewRow();
            newRoww3["name"] = "10已出库";
            newRoww3["value"] = chuku;
            bing1.Rows.Add(newRoww3);

            DataRow newRoww4;
            newRoww4 = bing1.NewRow();
            newRoww4["name"] = "不确定";
            newRoww4["value"] = buqueding;
            bing1.Rows.Add(newRoww4);
            
            Series Seriess2 = new Series("种类分布", ViewType.Doughnut);
            Seriess2.ArgumentScaleType = ScaleType.Qualitative;
            Seriess2.ArgumentDataMember = "name";
            Seriess2.ValueDataMembers[0] = "value";
            Seriess2.DataSource = bing1;
            Seriess2.Label.TextPattern = "{A}:{VP:0.00%}";
            pieChart.Series.Add(Seriess2);

            pieChart.ToolTipEnabled = DevExpress.Utils.DefaultBoolean.True;

        
        } 
        private void tasksTileBarItem_ItemClick(object sender, TileItemEventArgs e)
        {
            Frshejiweiwancheng form1 = new Frshejiweiwancheng();
            form1.gongzuolinghao = gongzuolinghao;
            form1.xiangmumingcheng = xiangmumingcheng;
            form1.ShowDialog();
        }

        private void employeesTileBarItem_ItemClick(object sender, TileItemEventArgs e)
        {
            Frjiagongweiwancheng form1 = new Frjiagongweiwancheng();
            form1.gongzuolinghao = gongzuolinghao;
            form1.xiangmumingcheng = xiangmumingcheng;
            form1.ShowDialog();
        }

        private void tileBarItem1_ItemClick(object sender, TileItemEventArgs e)
        {
            Frcaigouweiwancheng form1 = new Frcaigouweiwancheng();
            form1.gongzuolinghao = gongzuolinghao;
            form1.xiangmumingcheng = xiangmumingcheng;
            form1.ShowDialog();
        }

        private void tileBarItem2_ItemClick(object sender, TileItemEventArgs e)
        {
            Frzhuangpeiweiwancheng form1 = new Frzhuangpeiweiwancheng();
            form1.gongzuolinghao = gongzuolinghao;
            form1.xiangmumingcheng = xiangmumingcheng;
            form1.ShowDialog();
        }

        private void tileBarItem5_ItemClick(object sender, TileItemEventArgs e)
        {
            Frsheji form1 = new Frsheji();
            form1.gongzuolinghao = gongzuolinghao;
            form1.xiangmumingcheng = xiangmumingcheng;
            form1.Show();
        }

        private void tileBarItem6_ItemClick(object sender, TileItemEventArgs e)
        {
            Frcaigou form1 = new Frcaigou();
            form1.gongzuolinghao = gongzuolinghao;
            form1.xiangmumingcheng = xiangmumingcheng;
            form1.Show();
        }

        private void tileBarItem7_ItemClick(object sender, TileItemEventArgs e)
        {
            Frzhangpei form1 = new Frzhangpei();
            form1.gongzuolinghao = gongzuolinghao;
            form1.xiangmumingcheng = xiangmumingcheng;
            form1.Show();
        }

        private void tileBarItem8_ItemClick(object sender, TileItemEventArgs e)
        {
            Frbeiliao1 form1 = new Frbeiliao1();
            form1.gongzuolinghao = gongzuolinghao;
            form1.xiangmumingcheng = xiangmumingcheng;
            form1.Show();
        }

        private void tileBarItem3_ItemClick(object sender, TileItemEventArgs e)
        {
            Frcaigougenzongliaodan form1 = new Frcaigougenzongliaodan();
            form1.gongzuolinghao = gongzuolinghao;
            form1.xiangmumingcheng = xiangmumingcheng;
            form1.Show();
           
        }

        private void tileBarItem4_ItemClick(object sender, TileItemEventArgs e)
        {
            Frliaodangenzong1 form1 = new Frliaodangenzong1();
            form1.gongzoulinghao = gongzuolinghao;
            form1.xiangmumingcheng = xiangmumingcheng;
            form1.Show();
            form1.MaximizeBox = true;
        }
    }
}