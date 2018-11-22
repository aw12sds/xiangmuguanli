using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.仓库
{
    public partial class FrCangkuliaodan : Office2007Form
    {
        public FrCangkuliaodan()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string gongzuolinghao;
        public string xiangmumingcheng;
        public string shijian;
        public string yonghu;
        public string panduan;
        public string id1;
        public string zhonglei;
        public int zhongleipanduan;
       
        private void FrCangkuliaodan_Load(object sender, EventArgs e)
        {

            if (zhonglei=="待发起")
            {
                string sql1 = "select  设备名称,项目名称,工作令号,时间,id,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,当前状态,仓库确认,仓库确认时间,到货验收流程按钮,流程状态 from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "'  and   制造类型!='自制零部件' and   制造类型!='装配零部件'  and   到货验收流程按钮 IS NULL";
                DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                dataGridViewX2.DataSource = dt;
            }

            if (zhonglei == "已发起")
            {
                string sql1 = "select  设备名称,项目名称,工作令号,时间,id,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,当前状态,仓库确认,仓库确认时间,到货验收流程按钮,流程状态 from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "'  and   制造类型!='自制零部件' and   制造类型!='装配零部件'  ";
                DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                dataGridViewX2.DataSource = dt;

                contextMenuStrip1.Visible= false;
                contextMenuStrip1.Enabled = false;
            }

            
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString();
            string gonglinghao = dataGridViewX2.CurrentRow.Cells["工作令号"].Value.ToString();
            string xiangmumingcheng = dataGridViewX2.CurrentRow.Cells["项目名称"].Value.ToString();
            string shebeimingcheng = dataGridViewX2.CurrentRow.Cells["设备名称"].Value.ToString();
            string shijian = dataGridViewX2.CurrentRow.Cells["时间"].Value.ToString();

            string sql111 = "select 项目负责人 from tb_jishubumen where 工作令号='" + gonglinghao + "' and 项目名称='" + xiangmumingcheng + "'  and  设备名称='" + shebeimingcheng + "' and  时间='" + shijian + "'";
            string fuzeren = SQLhelp.ExecuteScalar(sql111, CommandType.Text).ToString();

            string sql112 = "select 项目主管 from tb_jishubumen where 工作令号='" + gonglinghao + "' and 项目名称='" + xiangmumingcheng + "'  and  设备名称='" + shebeimingcheng + "' and  时间='" + shijian + "'";
            string fuzeren1 = SQLhelp.ExecuteScalar(sql112, CommandType.Text).ToString();
            DataTable dt1 = dataGridViewX2.DataSource as DataTable;
           
                
                DataRow[] rows = dt1.Select("(制造类型 ='外协零部件' and 到货验收流程按钮=1) or (制造类型 ='机械标准件'and 到货验收流程按钮=1) or (制造类型 ='零件'and 到货验收流程按钮=1) ");
                if (rows.Length > 0)
                {
                    zhongleipanduan += 1;
                }

                DataRow[] rows1 = dt1.Select("(制造类型 ='电气标准件' and 到货验收流程按钮=1) or (制造类型 ='外购' and 到货验收流程按钮=1)");
                if (rows1.Length > 0)
                {
                    zhongleipanduan += 2;
                }

                if(zhongleipanduan==3)
                {

                    MessageBox.Show("请将外协零部件、机械标准件、零件与电气标准件、外购件分开发起！");

                    return;
                }
           
            try
            {
                for (int j = 0; j < dataGridViewX2.Rows.Count; j++)
                {
                    string id = dataGridViewX2.Rows[j].Cells["id"].Value.ToString();

                    string liuchengkaiqi = Convert.ToString(dataGridViewX2.Rows[j].Cells["到货验收流程按钮"].Value);

                    if (liuchengkaiqi == "1")
                    {


                        string sql2 = "update tb_caigouliaodan  set 到货验收流程按钮=1 ,到货验收流程标记='" + time + "',流程状态='到达物流部'  where id='" + id + "' ";
                        SQLhelp.ExecuteScalar(sql2, CommandType.Text);
                        panduan = "1";

                    }
                    
                }
                if (panduan == "1")
                {
                    string sql1 = "insert into tb_zongliucheng(流程类型,创建人,创建时间,到货验收流程标记,工作令号,项目名称,设备名称,时间,流程状态,项目负责人,项目主管) values('到货验收流程','" + yonghu + "','" + time + "','" + time + "','" + gongzuolinghao + "','" + xiangmumingcheng + "','" + shebeimingcheng + "','" + shijian + "','到达物流部','" + fuzeren + "','" + fuzeren1 + "') ";
                    SQLhelp.ExecuteScalar(sql1, CommandType.Text);

                    string sql2 = "insert into tb_liuchengxiangxi(流程类型,创建人,创建时间,流程标记,工作令号,项目名称,设备名称,时间,流程内容) values('到货验收流程','" + yonghu + "','" + time + "','" + time + "','" + gongzuolinghao + "','" + xiangmumingcheng + "','" + shebeimingcheng + "','" + shijian + "','已收到货，发起到货验收流程') ";
                    SQLhelp.ExecuteScalar(sql2, CommandType.Text);


                    string sql3 = "update  tb_jishubumen set  到货验收流程=1   where id='" + id1 + "' ";
                    SQLhelp.ExecuteScalar(sql3, CommandType.Text);

                    MessageBox.Show("发起成功！");
                    this.Close();
                }
                if (panduan != "1")
                {
                    MessageBox.Show("没有选择任何零件，无法发起流程！");
                    return;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}


