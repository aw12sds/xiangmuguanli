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
    public partial class Frgongxuxuanze : Office2007Form
    {
        public Frgongxuxuanze()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string id;
        private void Frgongxuxuanze_Load(object sender, EventArgs e)
        {

        }
        int a1=0;
        int a2=0;
        int a3=0;
        int a4=0;
        int a5=0;
        int a6=0;
        int a7=0;
        int a8=0;
        

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (checkBoxX1.Checked==true)
            {
                a1 = 1;

            }
            if (checkBoxX2.Checked == true)
            {
                a2 = 1;

            }
            if (checkBoxX3.Checked == true)
            {
                a3 = 1;

            }
            if (checkBoxX4.Checked == true)
            {
                a4 = 1;

            }
            if (checkBoxX5.Checked == true)
            {
                a5 = 1;


            }
            if (checkBoxX6.Checked == true)
            {
                a6 = 1;

            }
            if (checkBoxX7.Checked == true)
            {

                a7 = 1;
            }
            if (checkBoxX8.Checked == true)
            {

                a8 = 1;
            }
            

            string sql2 = "update tb_caigouliaodan  set 车= '" + a1 + "',铣= '" + a2 + "',钳= '" + a3 + "',磨= '" +a4 + "',镗 ='" + a5 + "',线切割= '" + a6 + "',表面处理= '" + a7 + "' ,热处理= '" +a8 + "' where id='" + id + "'";
            SQLhelp.ExecuteScalar(sql2, CommandType.Text);
            MessageBox.Show("提交成功");
            this.Close();
        }
    }
}
