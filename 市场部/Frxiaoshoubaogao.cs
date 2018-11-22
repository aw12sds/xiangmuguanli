using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace 项目管理系统.市场部
{
    public partial class Frxiaoshoubaogao : DevExpress.XtraEditors.XtraForm
    {
        public Frxiaoshoubaogao()
        {
            InitializeComponent();
        }
        public string yonghu;
        private void buttonItem1_Click(object sender, EventArgs e)
        {
            if(txtxianlan1.Text=="")
            {
                txtxianlan1.Text = "0";
            }
            if (txtxianlan2.Text == "")
            {
                txtxianlan2.Text = "0";
            }
            if (txtxianlan3.Text == "")
            {
                txtxianlan3.Text = "0";
            }
            if (txtshiying1.Text == "")
            {
                txtshiying1.Text = "0";
            }
            if (txtshiying2.Text == "")
            {
                txtshiying2.Text = "0";
            }
            if (txtshiying3.Text == "")
            {
                txtshiying3.Text = "0";
            }
            if (txtbaocai1.Text == "")
            {
                txtbaocai1.Text = "0";
            }
            if (txtbaocai2.Text == "")
            {
                txtbaocai2.Text = "0";
            }
            if (txtbaocai3.Text == "")
            {
                txtbaocai3.Text = "0";
            }
            if (txtxincai1.Text == "")
            {
                txtxincai1.Text = "0";
            }
            if (txtxincai2.Text == "")
            {
                txtxincai2.Text = "0";
            }
            if (txtxincai3.Text == "")
            {
                txtxincai3.Text = "0";
            }
            if (txtzhineng1.Text == "")
            {
                txtzhineng1.Text = "0";
            }
            if (txtzhineng2.Text == "")
            {
                txtzhineng2.Text = "0";
            }
            if (txtzhineng3.Text == "")
            {
                txtzhineng3.Text = "0";
            }
            if (txtjinggong1.Text == "")
            {
                txtjinggong1.Text = "0";
            }
            if (txtjinggong2.Text == "")
            {
                txtjinggong2.Text = "0";
            }
            if (txtjinggong3.Text == "")
            {
                txtjinggong3.Text = "0";
            }
            if (txtmujv1.Text == "")
            {
                txtmujv1.Text = "0";
            }
            if (txtmujv2.Text == "")
            {
                txtmujv2.Text = "0";
            }
            if (txtmujv3.Text == "")
            {
                txtmujv3.Text = "0";
            }



            string sql1 = "insert into tb_xiaoshou (销售部,销售额,产值,开票额,提交时间,提交人) values ('线缆装备销售部','" + txtxianlan1.Text.Trim() + "','" + txtxianlan2.Text.Trim() + "','" + txtxianlan3.Text.Trim() + "','" + DateTime.Now+ "','" +yonghu + "')";
            SQLhelp.ExecuteScalar(sql1, CommandType.Text);
            string sql2 = "insert into tb_xiaoshou (销售部,销售额,产值,开票额,提交时间,提交人) values ('石英装备销售部','" + txtshiying1.Text.Trim() + "','" + txtshiying2.Text.Trim() + "','" + txtshiying3.Text.Trim() + "','" + DateTime.Now + "','" + yonghu + "')";
            SQLhelp.ExecuteScalar(sql2, CommandType.Text);
            string sql3 = "insert into tb_xiaoshou (销售部,销售额,产值,开票额,提交时间,提交人) values ('薄材装备销售部','" + txtbaocai1.Text.Trim() + "','" + txtbaocai2.Text.Trim() + "','" + txtbaocai3.Text.Trim() + "','" + DateTime.Now + "','" + yonghu + "')";
            SQLhelp.ExecuteScalar(sql3, CommandType.Text);
            string sql4 = "insert into tb_xiaoshou (销售部,销售额,产值,开票额,提交时间,提交人) values ('新材装备销售部','" + txtxincai1.Text.Trim() + "','" + txtxincai2.Text.Trim() + "','" + txtxincai3.Text.Trim() + "','" + DateTime.Now + "','" + yonghu + "')";
            SQLhelp.ExecuteScalar(sql4, CommandType.Text);
            string sql5 = "insert into tb_xiaoshou (销售部,销售额,产值,开票额,提交时间,提交人) values ('智能装备销售部','" + txtzhineng1.Text.Trim() + "','" + txtzhineng2.Text.Trim() + "','" + txtzhineng3.Text.Trim() + "','" + DateTime.Now + "','" + yonghu + "')";
            SQLhelp.ExecuteScalar(sql5, CommandType.Text);
            string sql6 = "insert into tb_xiaoshou (销售部,销售额,产值,开票额,提交时间,提交人) values ('精工配件销售部','" + txtjinggong1.Text.Trim() + "','" + txtjinggong2.Text.Trim() + "','" + txtjinggong3.Text.Trim() + "','" + DateTime.Now + "','" + yonghu + "')";
            SQLhelp.ExecuteScalar(sql6, CommandType.Text);
            string sql7 = "insert into tb_xiaoshou (销售部,销售额,产值,开票额,提交时间,提交人) values ('模具销售部','" + txtmujv1.Text.Trim() + "','" + txtmujv2.Text.Trim() + "','" + txtmujv3.Text.Trim() + "','" + DateTime.Now + "','" + yonghu + "')";
            SQLhelp.ExecuteScalar(sql7, CommandType.Text);
            MessageBox.Show("提交成功");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Frxiaoshoubaogao_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            buttonItem1_Click(sender,e);
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;

            //小数点的处理。
            if ((int)e.KeyChar == 46)                           //小数点
            {
                if (((TextEdit)sender).Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(((TextEdit)sender).Text, out oldf);
                    b2 = float.TryParse(((TextEdit)sender).Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

     
    }
}