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
    public partial class FrCangkuquerenliaodan : Office2007Form
    {
        public FrCangkuquerenliaodan()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string gongzuolinghao;
        public string xiangmumingcheng;
        public string shijian;

        private void FrCangkuquerenliaodan_Load(object sender, EventArgs e)
        {
            string sql1 = "select  id,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,当前状态,仓库确认,仓库确认时间,流程按钮,流程状态 from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "'  and   制造类型!='自制零部件' and   制造类型!='装配零部件'  ";
            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            dataGridViewX2.DataSource = dt;
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewX2.Rows.Count; i++)
            {
                string id = dataGridViewX2.Rows[i].Cells["id"].Value.ToString();

                string cangkuqueren = Convert.ToString(dataGridViewX2.Rows[i].Cells["仓库确认"].Value);
                string liuchengkaiqi = Convert.ToString(dataGridViewX2.Rows[i].Cells["流程按钮"].Value);
                string time = DateTime.Now.ToString();


                string sql1 = "select  流程按钮  from tb_caigouliaodan    where id='" + id + "'  ";
                string duibi = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));

                if (duibi != liuchengkaiqi)
                {

                    try
                    {
                        for (int j = 0; j < dataGridViewX2.Rows.Count; i++)
                        {
                            string id1 = dataGridViewX2.Rows[j].Cells["id"].Value.ToString();

                            string cangkuqueren1 = Convert.ToString(dataGridViewX2.Rows[j].Cells["仓库确认"].Value);
                            string liuchengkaiqi1 = Convert.ToString(dataGridViewX2.Rows[j].Cells["流程按钮"].Value);
                            string time1 = DateTime.Now.ToString();

                            if (cangkuqueren == "1")
                            {

                                string sql11 = "select  仓库确认  from tb_caigouliaodan    where id='" + id + "'  ";
                                string duibi1 = SQLhelp.ExecuteScalar(sql11, CommandType.Text).ToString();
                                if (duibi1 == "0")
                                {

                                    string sql2 = "update tb_caigouliaodan  set 仓库确认=1 ,仓库确认时间='" + time + "'  where id='" + id + "' ";
                                    SQLhelp.ExecuteScalar(sql2, CommandType.Text);
                                }
                            }


                            if (liuchengkaiqi == "1")
                            {

                                string sql11 = "select  流程按钮  from tb_caigouliaodan    where id='" + id + "'  ";
                                string duibi1 = Convert.ToString(SQLhelp.ExecuteScalar(sql11, CommandType.Text));
                                if (duibi == "")
                                {

                                    string sql2 = "update tb_caigouliaodan  set 流程按钮=1 ,流程开启时间='" + time + "',流程状态间='到达物流部'  where id='" + id + "' ";
                                    SQLhelp.ExecuteScalar(sql2, CommandType.Text);

                                    //string sql3 = "insert into tb_liucheng(创建人,流程内容)"


                                }
                            }



                        }
                        MessageBox.Show("保存成功！");
                        this.Close();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }

            }
            
        }

    }

}
