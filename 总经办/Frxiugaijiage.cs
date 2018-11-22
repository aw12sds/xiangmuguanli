using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.总经办
{
    public partial class Frxiugaijiage : DevExpress.XtraEditors.XtraForm
    {
        public Frxiugaijiage()
        {
            InitializeComponent();
        }
        public DataTable dt;
        public string yonghu;

        private void btnTijiao_Click(object sender, EventArgs e)
        {
            string tijiaoshijian = DateTime.Now.ToString();
            if (MessageBox.Show("确认提交吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                if (txtRengong.Text != "" && txtShijian.Text != "" && txtHaocai.Text != "")
                {
                    string qingdan = dt.Rows[0]["查看该批次"].ToString();
                    
                    string hetonghao= dt.Rows[0]["合同号"].ToString();

                    string[] strArray = qingdan.Split('|'); //字符串转数组
                    List<string> list = new List<string>();
                    for (int j = 0; j < strArray.Length; j++)//遍历数组成员
                    {
                        if (list.IndexOf(strArray[j].ToLower()) == -1)//对每个成员做一次新数组查询如果没有相等的则加到新数组
                        {
                            list.Add(strArray[j]);
                            string sql1 = "update tb_caigouliaodan set 人工数='" + txtRengong.Text + "',检验时间数='" + txtShijian.Text + "',特殊耗材='" + txtHaocai.Text + "',报价总额='" + txtGongji.Text + "',提交时间='" + tijiaoshijian + "',提交人='" + yonghu + "' where 合同号 ='" + hetonghao + "' and 到货验收流程状态='5总经办审批'and 查看该批次='" + qingdan + "' ";
                            SQLhelp.ExecuteScalar(sql1, CommandType.Text);                            
                        }
                    }
                }
                MessageBox.Show("修改成功！");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("取消！");
                return;
            }
        }

        private void txtRengong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46)                           //小数点
            {
                if (txtRengong.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(txtRengong.Text, out oldf);
                    b2 = float.TryParse(txtRengong.Text + e.KeyChar.ToString(), out f);
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

        private void txtShijian_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46)                           //小数点
            {
                if (txtShijian.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(txtShijian.Text, out oldf);
                    b2 = float.TryParse(txtShijian.Text + e.KeyChar.ToString(), out f);
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

        private void txtHaocai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46)                           //小数点
            {
                if (txtHaocai.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(txtHaocai.Text, out oldf);
                    b2 = float.TryParse(txtHaocai.Text + e.KeyChar.ToString(), out f);
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
        public void jisuan()
        {
            float a, b, c;
            float.TryParse(txtRengong.Text, out a);
            float.TryParse(txtShijian.Text, out b);
            float.TryParse(txtHaocai.Text, out c);
            txtGongji.Text = (a * 500 + b * 250 + c).ToString();
        }

        private void txtGongji_TextChanged(object sender, EventArgs e)
        {
            jisuan();
        }

        private void txtRengong_TextChanged(object sender, EventArgs e)
        {
            if (txtRengong.Text != "")
            {
                jisuan();
            }
            else
            {
                return;
            }
        }

        private void txtShijian_TextChanged(object sender, EventArgs e)
        {
            if (txtShijian.Text != "")
            {
                jisuan();
            }
            else
            {
                return;
            }
        }

        private void txtHaocai_TextChanged(object sender, EventArgs e)
        {
            if (txtHaocai.Text != "")
            {
                jisuan();
            }
            else
            {
                return;
            }
        }
    }
}
