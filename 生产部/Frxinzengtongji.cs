using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace 项目管理系统.生产部
{
    public partial class Frxinzengtongji : DevExpress.XtraEditors.XtraForm
    {
        public Frxinzengtongji()
        {
            InitializeComponent();
        }
        public string yonghu;
        public DataTable zongbiao;
        public string wanchengren;
        private void Frxinzengtongji_Load(object sender, EventArgs e)
        {
            DataTable zongbiao = new DataTable();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Frgongyichaxun form1 = new Frgongyichaxun();
            form1.yonghu = txtren.Text.Trim();
            form1.ShowDialog();
           if(form1.DialogResult==DialogResult.OK)
            {
                string dingwei = form1.dingwei;
                string leixing = form1.leixing;

                if (leixing == "普通")
                {
                    string sql = "select * from db_gongxu1 where id='" + dingwei + "'";
                    DataTable dtt = sqlhelp1.GetDataTable(sql, CommandType.Text);
                    txtgonglinghao.Text = dtt.Rows[0]["工作令号"].ToString();
                    txtxianmumingcheng.Text = dtt.Rows[0]["项目名称"].ToString();
                    txtshebei.Text = dtt.Rows[0]["设备名称"].ToString();
                    txtmingcheng.Text = dtt.Rows[0]["名称"].ToString();
                   wanchengren= dtt.Rows[0]["负责人"].ToString();
                    txtzongshuliang.Text = dtt.Rows[0]["数量"].ToString();
                    txtxinghao.Text = dtt.Rows[0]["图号"].ToString();
                    txtdanjainxinchou.Text = dtt.Rows[0]["价格"].ToString();
                    if (dtt.Rows[0]["价格"].ToString().Trim() != "")
                    {
                        double zongjiage = Convert.ToDouble(dtt.Rows[0]["价格"]) * Convert.ToDouble(dtt.Rows[0]["数量"]);

                        txtzongxinchou.Text = zongjiage.ToString(); 
                    }
                    if (dtt.Rows[0]["重量"].ToString().Trim() != "")
                    {
                        double zongzhongliang = Convert.ToDouble(dtt.Rows[0]["重量"]) * Convert.ToDouble(dtt.Rows[0]["数量"]);

                        txtzongzhongliang.Text = zongzhongliang.ToString();
                    }
                    if (dtt.Rows[0]["重量"].ToString().Trim() == "")
                    {
                      
                        txtzongzhongliang.Text = "0";
                    }

                    string sql1 = "select 序号 from tb_operator where 用户名='" + txtren.Text.Trim() + "'";
                    comgongzhong.Text = sqlhelp111.ExecuteScalar(sql1, CommandType.Text).ToString();

                    
                }

                if (leixing == "机修")
                {
                    string sql = "select * from db_gongxu111 where id='" + dingwei + "'";
                    DataTable dtt = sqlhelp1.GetDataTable(sql, CommandType.Text);
                    txtgonglinghao.Text = dtt.Rows[0]["接单编号"].ToString();
                  
                    txtmingcheng.Text = dtt.Rows[0]["工件名称"].ToString();
                    wanchengren = dtt.Rows[0]["负责人"].ToString();
                    txtzongshuliang.Text = dtt.Rows[0]["机修件数量"].ToString();
                    txtxinghao.Text = dtt.Rows[0]["接单编号"].ToString();
                    txtdanjainxinchou.Text = dtt.Rows[0]["价格"].ToString();
                    if (dtt.Rows[0]["价格"].ToString().Trim() != "")
                    {
                        double zongjiage = Convert.ToDouble(dtt.Rows[0]["价格"]) * Convert.ToDouble(dtt.Rows[0]["机修件数量"]);

                        txtzongxinchou.Text = zongjiage.ToString();
                    }
                    if (dtt.Rows[0]["机修件数量"].ToString().Trim() != "")
                    {
                        double zongzhongliang = Convert.ToDouble(dtt.Rows[0]["重量"]) * Convert.ToDouble(dtt.Rows[0]["机修件数量"]);

                        txtzongzhongliang.Text = zongzhongliang.ToString();
                    }
                    if (dtt.Rows[0]["重量"].ToString().Trim() == "")
                    {

                        txtzongzhongliang.Text = "0";
                    }

                    string sql1 = "select 序号 from tb_operator where 用户名='" + txtren.Text.Trim() + "'";
                    comgongzhong.Text = sqlhelp111.ExecuteScalar(sql1, CommandType.Text).ToString();


                }






            }
        }

        private void txtren_TextChanged(object sender, EventArgs e)
        {


            if (!txtren.Text.Contains("\r\n"))
            {

                listBox1.Items.Clear();//先清空一下这个控件的值.  不然就会造成文本框里不输时,这里面全部都是值

                string sql = "select 用户名 from tb_operator  where 部门='精工事业部'";
                DataTable dt = sqlhelp111.GetDataTable(sql, CommandType.Text);

                int b = txtren.Text.LastIndexOf(";");

                if (b != -1)
                {
                    string jiequ = txtren.Text.Substring(b + 1);


                    DataRow[] drr = dt.Select("用户名 like'%" + jiequ + "%'");
                    DataTable newdtt = new DataTable(); //再新创建一个表,
                    newdtt = dt.Clone();//复制dt表的所有结构

                    foreach (DataRow row in drr)
                    {
                        newdtt.Rows.Add(row.ItemArray);
                    }//这一句,可以改成用for循环替代,  循环内就用 newdt.ImportRow(dr[i]);



                    if (dt.Rows.Count > 0 && (jiequ != ""))//如果这个DS表里的行数总数,大于零,并且文本框不为空,就运行以下代码
                    {
                        listBox1.Visible = true;      //listBox2显示出来  
                        for (int i = 0; i < newdtt.Rows.Count; i++)//循环所有行数
                        {
                            listBox1.Items.Add(newdtt.Rows[i]["用户名"].ToString());//每行的名称值给listBox2
                        }
                    }

                }

                DataRow[] dr = dt.Select("用户名 like'%" + txtren.Text + "%'");
                DataTable newdt = new DataTable(); //再新创建一个表,
                newdt = dt.Clone();//复制dt表的所有结构

                foreach (DataRow row in dr)
                {
                    newdt.Rows.Add(row.ItemArray);
                }

                if (newdt.Rows.Count > 0 && (txtren.Text != ""))
                {
                    listBox1.Visible = true;
                    for (int i = 0; i < newdt.Rows.Count; i++)
                    {
                        listBox1.Items.Add(newdt.Rows[i]["用户名"].ToString());//
                    }
                }

                if (listBox1.Items.Count > 0)
                {
                    listBox1.SelectedIndex = 0;

                }

            }

        }

        private void txtren_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)//如果按了向上键
            {
                int idx = listBox1.SelectedIndex;//获取当前所选择的是哪一项
                if (idx == -1)//如果所选荐是-1,就表示没有选中任何值,是刚进入的
                {
                    listBox1.SelectedItem = listBox1.Items[listBox1.Items.Count - 1];//让他选中最后一个,也就是总数减1
                }
                else
                {
                    if (idx == 0)//等于零,表示此时选中的是在第一行.
                    {
                        listBox1.SelectedItem = listBox1.Items[listBox1.Items.Count - 1];//再按向上键,就跳到最后一个.
                        idx = listBox1.Items.Count;//当前选中的这一行,就是值的总数
                    }
                    listBox1.SelectedItem = listBox1.Items[idx - 1];//从下往上一直移动选择, 一直递减1
                }
            }
            else if (e.KeyCode == Keys.Down)//如果按了向下键
            {
                int idx = listBox1.SelectedIndex;//获取当前所选择的是哪一项
                if (idx == -1)//如果所选荐是-1,就表示没有选中任何值,是刚进入的
                {
                    //把下拉列里的第一个(item[0])值,赋给listBox2的SelectedItem属性, 这个属性表示当前被选中的项
                    listBox1.SelectedItem = listBox1.Items[0];
                }
                else
                {
                    if (idx == listBox1.Items.Count - 1)//如果idx等于总数减1,  就表示所选中的已经在最后一个了
                    {
                        listBox1.SelectedItem = listBox1.Items[0];//就把第一个值,赋给listBox2的SelectedItem属性. 等于从头再开始
                    }
                    else
                    {
                        listBox1.SelectedItem = listBox1.Items[idx + 1];//不是未选中,也不是最后一项,  就递增1,向下再移动的意思
                    }
                }
                idx = listBox1.SelectedIndex;//最后得出结果,再次获取当前所选择的是哪一项
            }
            else if (e.KeyCode == Keys.Enter && (listBox1.Visible == true))
            {
                //如果按了回车键,并且这个下拉框是要可见的时候.隐藏时就按回车无效
                if (listBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("请选择对应的人员！");

                    return;
                }

                int i = txtren.Text.LastIndexOf(";");
                if (i == -1)
                {
                    string chongxin = "";
                    chongxin = this.listBox1.SelectedItem.ToString();//把选中的值给文本框
                    txtren.Text = chongxin;
                    this.txtren.SelectionStart = this.txtren.TextLength;
                    listBox1.Visible = false;//隐藏这个控件

                }
                if (i != -1)
                {
                    string jiequ = txtren.Text.Substring(0, i + 1);

                    txtren.Text = jiequ + this.listBox1.SelectedItem.ToString() + ";";
                    this.txtren.SelectionStart = this.txtren.TextLength;
                    listBox1.Visible = false;//隐藏这个控件
                }
            }
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("请选择对应的人员");

                return;
            }

            int i = txtren.Text.LastIndexOf(";");
            if (i == -1)
            {
                string chongxin = "";
                chongxin = this.listBox1.SelectedItem.ToString();//把选中的值给文本框
               txtren.Text = chongxin;
                this.txtren.SelectionStart = this.txtren.TextLength;
                listBox1.Visible = false;//隐藏这个控件

            }
            if (i != -1)
            {
                string jiequ = txtren.Text.Substring(0, i + 1);

                txtren.Text = jiequ + this.listBox1.SelectedItem.ToString() + ";";
                this.txtren.SelectionStart = this.txtren.TextLength;
                listBox1.Visible = false;//隐藏这个控件
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if(datewancheng.Text=="")
            {
                MessageBox.Show("请填写完成时间！");
                return;
            }
            if (txtgonglinghao.Text == "")
            {
                MessageBox.Show("请填写工作令号！");
                return;
            }
            if (txtren.Text == "")
            {
                MessageBox.Show("请填写一线工人名字！");
                return;
            }
            if (comgongzhong.Text == "")
            {
                MessageBox.Show("请填写工种！");
                return;
            }
            string sql = " insert into tb_yixianbaobiao (工作令号,项目名称,设备名称,完成日期,名称,总重量,单件薪酬,工种,型号,总数量,总薪酬,记录人,记录时间,完成人)  values ('" + txtgonglinghao.Text.Trim() + "','" + txtxianmumingcheng.Text.Trim() + "','" + txtshebei.Text.Trim() + "','" + datewancheng.Text.Trim() + "','" + txtmingcheng.Text.Trim() + "','" + txtzongzhongliang.Text.Trim() + "','" + txtdanjainxinchou.Text.Trim() + "','" + comgongzhong.Text.Trim() + "','" + txtxinghao.Text.Trim() + "','" + txtzongshuliang.Text.Trim() + "','" + txtzongxinchou.Text.Trim() + "','" + yonghu + "','" + DateTime.Now + "','" + txtren.Text.Trim() + "')";
            SQLhelp.ExecuteScalar(sql, CommandType.Text);
            MessageBox.Show("登记成功！");
            this.Close();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (txtzongshuliang.Text.Trim() == "")
            {
                MessageBox.Show("请输入总数量！");
                return;
            }
            if (txtdanjainxinchou.Text.Trim() == "")
            {
                MessageBox.Show("请输入单件薪酬！");
                return;
            }
            double zongjiage = Convert.ToDouble(txtdanjainxinchou.Text.Trim()) * Convert.ToDouble(txtzongshuliang.Text.Trim());

            txtzongxinchou.Text = zongjiage.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}