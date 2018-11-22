using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.物流部
{
    public partial class Frfukuan : Office2007Form
    {
        public Frfukuan()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string gongzuolinghao;
        public string xiangmumingcheng;
        public string shijian;
        public string lujing;

        public double zongjia;
        public DataTable dt;
        public string yonghu;
        public string zongjia1;
        public string zhonglei;
        public string[] zifuchuan;
        private void Frfukuan_Load(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = dt;
        }

        private void txtfapiaohao_TextChanged(object sender, EventArgs e)
        {


        }

        private void txtyincang_TextChanged(object sender, EventArgs e)
        {
            string[] sArray = null;
            sArray = txtyincang.Text.Split(new char[1] { ',' });
            zifuchuan = sArray;
            if (sArray.Length > 0)
            {
                txtfapiaohao.Text = sArray[3];
                txtfukuan17.Text = Convert.ToString(Convert.ToDouble(sArray[4]) * 1.17);
                txtfukuan16.Text = Convert.ToString(Convert.ToDouble(sArray[4]) * 1.16);
                txtfukuan10.Text = Convert.ToString(Convert.ToDouble(sArray[4]) * 1.10);
                txtfukuan3.Text = Convert.ToString(Convert.ToDouble(sArray[4]) * 1.03);
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                txtfukuan16.Enabled = false;
                txtfukuan17.Enabled = true;
                txtfukuan3.Enabled = false;
                txtfukuan10.Enabled = false;

            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                txtfukuan16.Enabled = true;
                txtfukuan17.Enabled = false;
                txtfukuan3.Enabled = false;
                txtfukuan10.Enabled = false;

            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                txtfukuan16.Enabled = false;
                txtfukuan17.Enabled = false;
                txtfukuan3.Enabled = false;
                txtfukuan10.Enabled = true;

            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                txtfukuan16.Enabled = false;
                txtfukuan17.Enabled = false;
                txtfukuan3.Enabled = true;
                txtfukuan10.Enabled = false;

            }

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Enabled == false && radioButton2.Enabled == false && radioButton3.Enabled == false && radioButton4.Enabled == false)
            {
                MessageBox.Show("请选择税点！");
                return;

            }
            if (radioButton1.Enabled == true)
            {
                string riqi = zifuchuan[5];
                string nian = riqi.Substring(0, 4);
                string yue = riqi.Substring(4, 2);
                string ri = riqi.Substring(6, 2);
                string fapiaoriqi = nian + "-" + yue + "-" + ri;


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string id = Convert.ToString(dt.Rows[i]["id"]);

                    string sql123 = "update  tb_caigouliaodan set 收到发票日期='" + DateTime.Now + "',发票号='" + txtfapiaohao.Text + "',发票金额='" + txtfukuan17.Text + "',发票日期='" + fapiaoriqi + "'  where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql123, CommandType.Text);

                }
                MessageBox.Show("已自动匹配！");
            }
            if (radioButton2.Enabled == true)
            {

                string riqi = zifuchuan[5];
                string nian = riqi.Substring(0, 4);
                string yue = riqi.Substring(4, 2);
                string ri = riqi.Substring(6, 2);
                string fapiaoriqi = nian + "-" + yue + "-" + ri;


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string id = Convert.ToString(dt.Rows[i]["id"]);

                    string sql123 = "update  tb_caigouliaodan set 收到发票日期='" + DateTime.Now + "',发票号='" + txtfapiaohao.Text + "',发票金额='" + txtfukuan16.Text + "',发票日期='" + fapiaoriqi + "'  where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql123, CommandType.Text);

                }
                MessageBox.Show("已自动匹配！");
            }
            if (radioButton3.Enabled == true)
            {
                
                string riqi = zifuchuan[5];
                string nian = riqi.Substring(0, 4);
                string yue = riqi.Substring(4, 2);
                string ri = riqi.Substring(6, 2);
                string fapiaoriqi = nian + "-" + yue + "-" + ri;


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string id = Convert.ToString(dt.Rows[i]["id"]);

                    string sql123 = "update  tb_caigouliaodan set 收到发票日期='" + DateTime.Now + "',发票号='" + txtfapiaohao.Text + "',发票金额='" + txtfukuan10.Text + "',发票日期='" + fapiaoriqi + "'  where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql123, CommandType.Text);

                }
                
                MessageBox.Show("已自动匹配！");
            }
            if (radioButton4.Enabled == true)
            {


                string riqi = zifuchuan[5];
                string nian = riqi.Substring(0, 4);
                string yue = riqi.Substring(4, 2);
                string ri = riqi.Substring(6, 2);
                string fapiaoriqi = nian + "-" + yue + "-" + ri;


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string id = Convert.ToString(dt.Rows[i]["id"]);

                    string sql123 = "update  tb_caigouliaodan set 收到发票日期='" + DateTime.Now + "',发票号='" + txtfapiaohao.Text + "',发票金额='" + txtfukuan3.Text + "',发票日期='" + fapiaoriqi + "'  where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql123, CommandType.Text);

                }
                
                MessageBox.Show("已自动匹配！");
            }

        }
    }
}
