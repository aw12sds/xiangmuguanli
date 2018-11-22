using Aspose.Words;
using Aspose.Words.Drawing;
using DevComponents.DotNetBar;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThoughtWorks.QRCode.Codec;

namespace 项目管理系统.物流部
{
    public partial class Frhetongmoban : Office2007Form
    {
        public Frhetongmoban()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string gongzuolinghao;
        public string xiangmumingcheng;
        public string shijian;
        public string lujing;

        public double zongjia = 0;
        public DataTable dt;
        public string yonghu;
        public string zongjia1;

        public string zhonglei;
        private void Frhetongmoban_Load(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = dt;

        }

        private void 计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
            {
                if (Convert.ToString(dataGridViewX1.Rows[i].Cells["采购单价"].Value) != "")
                {
                    double shuliang = Convert.ToDouble(dataGridViewX1.Rows[i].Cells["实际采购数量"].Value);
                    double danjia = Convert.ToDouble(dataGridViewX1.Rows[i].Cells["采购单价"].Value);
                    decimal zuizhong = decimal.Round(decimal.Parse((shuliang * danjia).ToString()), 2);
                    dataGridViewX1.Rows[i].Cells["总价"].Value = zuizhong;

                }
                if (Convert.ToString(dataGridViewX1.Rows[i].Cells["采购单价"].Value) == "")
                {
                    dataGridViewX1.Rows[i].Cells["总价"].Value = 0;

                }

            }

            zongjia = 0;
            for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
            {
                if (Convert.ToString(dataGridViewX1.Rows[i].Cells["总价"].Value) != "")
                {
                    double jiage = Convert.ToDouble(dataGridViewX1.Rows[i].Cells["总价"].Value);
                    zongjia += jiage;

                }


            }
            zongjia1 = zongjia.ToString();
            MessageBox.Show(zongjia.ToString());
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


        private void textBoxX1_KeyUp(object sender, KeyEventArgs e)
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

                int i = txtZerenren1.Text.LastIndexOf(";");
                if (i == -1)
                {
                    string chongxin = "";
                    chongxin = this.listBox1.SelectedItem.ToString();//把选中的值给文本框
                    txtZerenren1.Text = chongxin;
                    string sql = "select * from tb_gongfang where 单位名称='" + txtZerenren1.Text.Trim() + "'";
                    txtgongfangfuzerendianhua.Text = Convert.ToString(SQLhelp.GetDataTable(sql, CommandType.Text).Rows[0]["生产负责人电话"]);
                    txtgangfangfuzeren.Text = Convert.ToString(SQLhelp.GetDataTable(sql, CommandType.Text).Rows[0]["生产负责人名称"]);
                    this.txtZerenren1.SelectionStart = this.txtZerenren1.TextLength;
                    listBox1.Visible = false;//隐藏这个控件

                }
                if (i != -1)
                {
                    string jiequ = txtZerenren1.Text.Substring(0, i + 1);

                    txtZerenren1.Text = jiequ + this.listBox1.SelectedItem.ToString() + ";";
                    this.txtZerenren1.SelectionStart = this.txtZerenren1.TextLength;
                    string sql = "select * from tb_gongfang where 单位名称='" + txtZerenren1.Text.Trim() + "'";
                    txtgongfangfuzerendianhua.Text = Convert.ToString(SQLhelp.GetDataTable(sql, CommandType.Text).Rows[0]["生产负责人电话"]);
                    txtgangfangfuzeren.Text = Convert.ToString(SQLhelp.GetDataTable(sql, CommandType.Text).Rows[0]["生产负责人名称"]);


                    listBox1.Visible = false;//隐藏这个控件

                }
            }
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {

            if (!txtZerenren1.Text.Contains("\r\n"))
            {

                listBox1.Items.Clear();//先清空一下这个控件的值.  不然就会造成文本框里不输时,这里面全部都是值

                string sql = "select 单位名称 from tb_gongfang ";
                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                int b = txtZerenren1.Text.LastIndexOf(";");

                if (b != -1)
                {
                    string jiequ = txtZerenren1.Text.Substring(b + 1);


                    DataRow[] drr = dt.Select("单位名称 like'%" + jiequ + "%'");
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

                DataRow[] dr = dt.Select("单位名称 like'%" + txtZerenren1.Text + "%'");
                DataTable newdt = new DataTable(); //再新创建一个表,
                newdt = dt.Clone();//复制dt表的所有结构

                foreach (DataRow row in dr)
                {
                    newdt.Rows.Add(row.ItemArray);
                }

                if (newdt.Rows.Count > 0 && (txtZerenren1.Text != ""))
                {
                    listBox1.Visible = true;
                    for (int i = 0; i < newdt.Rows.Count; i++)
                    {
                        listBox1.Items.Add(newdt.Rows[i]["单位名称"].ToString());//
                    }
                }

                if (listBox1.Items.Count > 0)
                {
                    listBox1.SelectedIndex = 0;

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

            int i = txtZerenren1.Text.LastIndexOf(";");
            if (i == -1)
            {
                string chongxin = "";
                chongxin = this.listBox1.SelectedItem.ToString();//把选中的值给文本框
                txtZerenren1.Text = chongxin;
                string sql = "select * from tb_gongfang where 单位名称='" + txtZerenren1.Text.Trim() + "'";
                txtgongfangfuzerendianhua.Text = Convert.ToString(SQLhelp.GetDataTable(sql, CommandType.Text).Rows[0]["生产负责人电话"]);
                txtgangfangfuzeren.Text = Convert.ToString(SQLhelp.GetDataTable(sql, CommandType.Text).Rows[0]["生产负责人名称"]);
                this.txtZerenren1.SelectionStart = this.txtZerenren1.TextLength;
                listBox1.Visible = false;//隐藏这个控件

            }
            if (i != -1)
            {
                string jiequ = txtZerenren1.Text.Substring(0, i + 1);

                txtZerenren1.Text = jiequ + this.listBox1.SelectedItem.ToString() + ";";
                string sql = "select * from tb_gongfang where 单位名称='" + txtZerenren1.Text.Trim() + "'";
                txtgongfangfuzerendianhua.Text = Convert.ToString(SQLhelp.GetDataTable(sql, CommandType.Text).Rows[0]["生产负责人电话"]);
                txtgangfangfuzeren.Text = Convert.ToString(SQLhelp.GetDataTable(sql, CommandType.Text).Rows[0]["生产负责人名称"]);

                this.txtZerenren1.SelectionStart = this.txtZerenren1.TextLength;
                listBox1.Visible = false;//隐藏这个控件
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (zhonglei == "普通")
            {


                string sql1 = "select 编号,号码 from tb_hetonghao1 where 号码=( select max(号码)from   tb_hetonghao1  where 用户名='" + yonghu + "' ) and 用户名='" + yonghu + "'";
                DataTable da1 = SQLhelp.GetDataTable(sql1, CommandType.Text);
                if (da1.Rows.Count == 0)
                {
                    MessageBox.Show("无此权限，请联系信息事业部！");
                }
                else
                {
                    int haoma1 = Convert.ToInt32(da1.Rows[0][1]) + 1;
                    string bianma1 = da1.Rows[0][0].ToString();
                    string sql12 = "insert into tb_hetonghao1 (用户名,编号,号码) values('" + yonghu + "','" + bianma1 + "','" + haoma1 + "') ";
                    SQLhelp.ExecuteScalar(sql12, CommandType.Text);
                    MessageBox.Show("生到" + haoma1 + "!");
                }
            }
            if (zhonglei == "采购")
            {

                string sql1 = "select 编号,号码 from tb_hetonghao1 where 号码=( select max(号码)from  tb_hetonghao1  where 用户名='" + yonghu + "' ) and 用户名='" + yonghu + "'";
                DataTable da1 = SQLhelp.GetDataTable(sql1, CommandType.Text);
                if (da1.Rows.Count == 0)
                {
                    MessageBox.Show("无此权限，请联系信息事业部！");
                }else
                {
                    int haoma1 = Convert.ToInt32(da1.Rows[0][1]) + 1;
                    string bianma1 = da1.Rows[0][0].ToString();
                    string sql12 = "insert into tb_hetonghao1 (用户名,编号,号码) values('" + yonghu + "','" + bianma1 + "','" + haoma1 + "') ";
                    SQLhelp.ExecuteScalar(sql12, CommandType.Text);
                    MessageBox.Show("生到" + haoma1 + "!");
                }
            }
            if (zhonglei == "设备")
            {
                    string sql1 = "select 编号,号码 from tb_hetonghao1 where 号码=( select max(号码)from  tb_hetonghao1  where 用户名='" + yonghu + "' ) and 用户名='" + yonghu + "'";
                    DataTable da1 = SQLhelp.GetDataTable(sql1, CommandType.Text);
                if (da1.Rows.Count == 0)
                {
                    MessageBox.Show("无此权限，请联系信息事业部！");
                }
                else
                {
                    int haoma1 = Convert.ToInt32(da1.Rows[0][1]) + 1;
                    string bianma1 = da1.Rows[0][0].ToString();
                    string sql12 = "insert into tb_hetonghao1 (用户名,编号,号码) values('" + yonghu + "','" + bianma1 + "','" + haoma1 + "') ";
                    SQLhelp.ExecuteScalar(sql12, CommandType.Text);
                    MessageBox.Show("生到" + haoma1 + "!");
                }

            }
            
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (zhonglei == "工序")
            {

                if (txtZerenren1.Text.Trim() == "")
                {
                    MessageBox.Show("请填写供应商名称！");
                    return;

                }
                DataTable dt1 = new DataTable();

                string sql = "select 编号,号码 from tb_hetonghao1 where 号码=( select max(号码)from   tb_hetonghao1  where 用户名='" + yonghu + "' ) and 用户名='" + yonghu + "' ";
                DataTable da = SQLhelp.GetDataTable(sql, CommandType.Text);
                string haoma = da.Rows[0][1].ToString();
                string bianhao = da.Rows[0][0].ToString();

                if (haoma.Length == 1)
                {
                    haoma = "000" + haoma;
                }
                if (haoma.Length == 2)
                {
                    haoma = "00" + haoma;
                }
                if (haoma.Length == 3)
                {
                    haoma = "0" + haoma;
                }
                string hetonghao = bianhao + haoma;
                if (radioButton2.Checked == true)
                {
                    hetonghao = txthetonghaobianhao.Text.Trim();
                }
                DateTime a = DateTime.Now;
                DateTime b = a.AddDays(3);
                DateTime c = a.AddDays(33);
                string qiandingshijian = b.ToString("yyyy年MM月dd日");
                string jiaohuoriqi = c.ToString("yyyy年MM月dd日");
                string qiandingyifang = txtZerenren1.Text.Trim();
                string heji = zongjia1;
                string sql1 = "select 单位名称,单位地址,法定代表人,委托代理人,电话,传真,税务登记号,开户银行,帐号,邮箱 from tb_gongfang where 单位名称='" + txtZerenren1.Text.Trim() + "'";
                DataTable daa = SQLhelp.GetDataTable(sql1, CommandType.Text);

                string danweidizhi = daa.Rows[0][1].ToString();
                string fadingdaibiaoren = daa.Rows[0][2].ToString();
                string weituodailiren = daa.Rows[0][3].ToString();
                string dianhua = daa.Rows[0][4].ToString();
                string chuanzhen = daa.Rows[0][5].ToString();
                string shuiwudengjihao = daa.Rows[0][6].ToString();
                string kaihuyinhang = daa.Rows[0][7].ToString();
                string zhanghao = daa.Rows[0][8].ToString();
                string youxiang = daa.Rows[0][9].ToString();


                string sql12 = "select 电话  from tb_operator1 where 用户名='" + yonghu + "'";
                string caigoudianhua = Convert.ToString(SQLhelp.ExecuteScalar(sql12, CommandType.Text));

                dt1.Columns.Add("邮箱", typeof(string));
                dt1.Columns.Add("生产进度负责人", typeof(string));
                dt1.Columns.Add("负责人电话", typeof(string));
                dt1.Columns.Add("合同编号", typeof(string));
                dt1.Columns.Add("签订时间", typeof(string));
                dt1.Columns.Add("签订乙方", typeof(string));
                dt1.Columns.Add("合计", typeof(string));
                dt1.Columns.Add("用户", typeof(string));
                dt1.Columns.Add("单位名称", typeof(string));
                dt1.Columns.Add("单位地址", typeof(string));
                dt1.Columns.Add("法定代表人", typeof(string));
                dt1.Columns.Add("委托代理人", typeof(string));
                dt1.Columns.Add("电话", typeof(string));
                dt1.Columns.Add("传真", typeof(string));
                dt1.Columns.Add("税务登记号", typeof(string));
                dt1.Columns.Add("开户银行", typeof(string));
                dt1.Columns.Add("帐号", typeof(string));
                dt1.Columns.Add("税务登记号1", typeof(string));
                dt1.Columns.Add("开户银行1", typeof(string));
                dt1.Columns.Add("单位名称1", typeof(string));
                dt1.Columns.Add("帐号1", typeof(string));

                for (int i = 0; i < 100; i++)
                {
                    dt1.Columns.Add("单位" + (i + 1), typeof(string));
                    dt1.Columns.Add("ERP" + (i + 1), typeof(string));
                    dt1.Columns.Add("产品名称" + (i + 1), typeof(string));
                    dt1.Columns.Add("规格型号" + (i + 1), typeof(string));
                    dt1.Columns.Add("数量" + (i + 1), typeof(string));
                    dt1.Columns.Add("单价" + (i + 1), typeof(string));
                    dt1.Columns.Add("总金额" + (i + 1), typeof(string));
                    dt1.Columns.Add("备注" + (i + 1), typeof(string));
                    dt1.Columns.Add("序号" + (i + 1), typeof(string));
                }

                DataRow dr1 = dt1.NewRow();

                for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
                {
                    if (dataGridViewX1.Rows[i].Cells["编码"].Value == null)
                    {
                        dr1["ERP" + (i + 1)] = "";
                    }
                    if (dataGridViewX1.Rows[i].Cells["编码"].Value != null)
                    {
                        dr1["ERP" + (i + 1)] = dataGridViewX1.Rows[i].Cells["编码"].Value.ToString();
                    }
                    if (dataGridViewX1.Rows[i].Cells["名称"].Value == null)
                    {
                        dr1["产品名称" + (i + 1)] = "";
                    }
                    if (dataGridViewX1.Rows[i].Cells["名称"].Value != null)
                    {
                        dr1["产品名称" + (i + 1)] = dataGridViewX1.Rows[i].Cells["名称"].Value.ToString();
                        dr1["序号" + (i + 1)] = i + 1;
                    }

                    if (dataGridViewX1.Rows[i].Cells["型号"].Value == null)
                    {
                        dr1["规格型号" + (i + 1)] = "";
                    }

                    if (dataGridViewX1.Rows[i].Cells["型号"].Value != null)
                    {
                        dr1["规格型号" + (i + 1)] = dataGridViewX1.Rows[i].Cells["型号"].Value.ToString();
                    }

                    if (dataGridViewX1.Rows[i].Cells["实际采购数量"].Value == null)
                    {
                        dr1["数量" + (i + 1)] = "";
                    }

                    if (dataGridViewX1.Rows[i].Cells["实际采购数量"].Value != null)
                    {
                        dr1["数量" + (i + 1)] = dataGridViewX1.Rows[i].Cells["实际采购数量"].Value.ToString();
                    }


                    if (dataGridViewX1.Rows[i].Cells["采购单价"].Value == null)
                    {
                        dr1["单价" + (i + 1)] = "";
                    }

                    if (dataGridViewX1.Rows[i].Cells["采购单价"].Value != null)
                    {
                        dr1["单价" + (i + 1)] = dataGridViewX1.Rows[i].Cells["采购单价"].Value.ToString();
                    }

                    if (dataGridViewX1.Rows[i].Cells["单位"].Value == null)
                    {
                        dr1["单位" + (i + 1)] = "";
                    }

                    if (dataGridViewX1.Rows[i].Cells["单位"].Value != null)
                    {
                        dr1["单位" + (i + 1)] = dataGridViewX1.Rows[i].Cells["单位"].Value.ToString();
                    }


                    if (dataGridViewX1.Rows[i].Cells["总价"].Value == null)
                    {
                        dr1["总金额" + (i + 1)] = "";
                    }

                    if (dataGridViewX1.Rows[i].Cells["总价"].Value != null)
                    {
                        dr1["总金额" + (i + 1)] = dataGridViewX1.Rows[i].Cells["总价"].Value.ToString();
                    }

                    if (dataGridViewX1.Rows[i].Cells["工作令号"].Value == null)
                    {
                        dr1["备注" + (i + 1)] = "";
                    }
                    if (dataGridViewX1.Rows[i].Cells["工作令号"].Value != null)
                    {
                        dr1["备注" + (i + 1)] = dataGridViewX1.Rows[i].Cells["工作令号"].Value.ToString();
                    }
                }
                dr1["邮箱"] = youxiang;
                dr1["合同编号"] = hetonghao;
                dr1["签订时间"] = qiandingshijian;
                dr1["签订乙方"] = qiandingyifang;
                dr1["合计"] = heji;
                dr1["用户"] = yonghu;
                dr1["单位名称"] = txtZerenren1.Text;
                dr1["单位地址"] = danweidizhi;
                dr1["法定代表人"] = fadingdaibiaoren;
                dr1["委托代理人"] = weituodailiren;
                dr1["电话"] = dianhua;
                dr1["传真"] = chuanzhen;
                dr1["税务登记号"] = shuiwudengjihao;
                dr1["开户银行"] = kaihuyinhang;
                dr1["帐号"] = zhanghao;
                dr1["税务登记号1"] = shuiwudengjihao;
                dr1["开户银行1"] = kaihuyinhang;
                dr1["单位名称1"] = txtZerenren1.Text;
                dr1["帐号1"] = zhanghao;
                dr1["生产进度负责人"] = txtgangfangfuzeren.Text.Trim();
                dr1["负责人电话"] = txtgongfangfuzerendianhua.Text.Trim();
                dt1.Rows.Add(dr1);
                string tempFile = Application.StartupPath + "\\设备合同模板.doc";
                Document doc = new Document(tempFile);
                DocumentBuilder builder = new DocumentBuilder(doc);
                NodeCollection allTables = doc.GetChildNodes(NodeType.Table, true);
                Dictionary<string, string> dic = new Dictionary<string, string>();
                DataRow dr = dt1.Rows[0];
                dic.Add("生产进度负责人", dr["生产进度负责人"].ToString());
                dic.Add("负责人电话", dr["负责人电话"].ToString());
                dic.Add("合同编号", dr["合同编号"].ToString());
                dic.Add("签订时间", dr["签订时间"].ToString());
                dic.Add("签订乙方", dr["签订乙方"].ToString());
                dic.Add("合计", dr["合计"].ToString());
                dic.Add("用户", dr["用户"].ToString());
                dic.Add("单位名称", dr["单位名称"].ToString());
                dic.Add("单位地址", dr["单位地址"].ToString());
                dic.Add("法定代表人", dr["法定代表人"].ToString());
                dic.Add("委托代理人", dr["委托代理人"].ToString());
                dic.Add("电话", dr["电话"].ToString());
                dic.Add("传真", dr["传真"].ToString());
                dic.Add("税务登记号", dr["税务登记号"].ToString());
                dic.Add("开户银行", dr["开户银行"].ToString());
                dic.Add("帐号", dr["帐号"].ToString());
                dic.Add("单位名称1", dr["单位名称1"].ToString());
                dic.Add("帐号1", dr["帐号1"].ToString());
                dic.Add("开户银行1", dr["开户银行1"].ToString());
                dic.Add("税务登记号1", dr["税务登记号1"].ToString());
                for (int i = 0; i < 100; i++)
                {
                    dic.Add("ERP" + (i + 1), dr["ERP" + (i + 1)].ToString());
                    dic.Add("单位" + (i + 1), dr["单位" + (i + 1)].ToString());
                    dic.Add("产品名称" + (i + 1), dr["产品名称" + (i + 1)].ToString());
                    dic.Add("规格型号" + (i + 1), dr["规格型号" + (i + 1)].ToString());
                    dic.Add("数量" + (i + 1), dr["数量" + (i + 1)].ToString());
                    dic.Add("单价" + (i + 1), dr["单价" + (i + 1)].ToString());
                    dic.Add("总金额" + (i + 1), dr["总金额" + (i + 1)].ToString());
                    dic.Add("备注" + (i + 1), dr["备注" + (i + 1)].ToString());
                    dic.Add("序号" + (i + 1), dr["序号" + (i + 1)].ToString());
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                    qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
                    string id = Convert.ToString(dt.Rows[i]["id"]);
                    string gonglinghao = Convert.ToString(dt.Rows[i]["工作令号"]);
                    string xiangmumingcheng = Convert.ToString(dt.Rows[i]["项目名称"]);
                    string shebeimingcheng = Convert.ToString(dt.Rows[i]["设备名称"]);
                    string bianma = Convert.ToString(dt.Rows[i]["编码"]);
                    string mingcheng1 = Convert.ToString(dt.Rows[i]["名称"]);
                    string xinghao1 = Convert.ToString(dt.Rows[i]["型号"]);
                    string shuliang = "采购数量：" + Convert.ToString(dt.Rows[i]["实际采购数量"]);
                    string gongyingshang = txtZerenren1.Text;
                    string hetonghao1 = hetonghao;
                    string dataCode = id + "|" + bianma + "|" + gongyingshang + "|" + hetonghao1 + "|";
                    Image image;
                    string data = dataCode;
                    image = qrCodeEncoder.Encode(data, Encoding.UTF8);
                    System.Drawing.Bitmap newImg;
                    newImg = new Bitmap(image.Width + 200, image.Height + 40);
                    Graphics g = Graphics.FromImage(newImg);
                    g.Clear(Color.White);
                    g.DrawImageUnscaled(image, 0, 0);
                    System.Drawing.Font font = new System.Drawing.Font("黑体", 11, FontStyle.Bold);
                    SolidBrush brush = new SolidBrush(Color.Black);
                    g.DrawString(gonglinghao, font, brush, image.Width, 0);
                    g.DrawString(bianma, font, brush, image.Width, 25);
                    g.DrawString(mingcheng1, font, brush, image.Width, 50);
                    g.DrawString(xinghao1, font, brush, image.Width, 75);
                    g.DrawString(gongyingshang, font, brush, image.Width, 100);
                    g.DrawString(hetonghao1, font, brush, image.Width, 125);
                    g.DrawString(shuliang, font, brush, image.Width, 150);
                    image = newImg;
                    string erweima = "二维码" + i;

                    builder.MoveToBookmark(erweima);
                    builder.InsertImage(image, RelativeHorizontalPosition.Margin, 1, RelativeVerticalPosition.Margin, 1, 180, 117, WrapType.Square);
                }

                foreach (var key in dic.Keys)
                {
                    builder.MoveToBookmark(key);
                    builder.Write(dic[key]);
                }
                Random suiji = new Random();
                int n = suiji.Next(0, 1000);
                string mingcheng = yonghu + DateTime.Now.ToString("yyyy-MM-dd") + "设备合同模板" + n + ".doc";
                FileInfo info1 = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\" + mingcheng);
                string fileName11 = info1.Name.ToString();
                string floderName = fileName11.Substring(0, fileName11.Length - 4).ToString();
                doc.Save(info1.DirectoryName + "\\" + fileName11);
                string pathfilesave = info1.DirectoryName + "\\" + mingcheng;
                MessageBox.Show("已保存到桌面！");
                System.Diagnostics.Process.Start(pathfilesave);
            }
            if (zhonglei == "设备")
            {
                if (zongjia1 == "" || zongjia1 == "0" ||zongjia1==null)
                {
                    MessageBox.Show("请计算合同总价！");
                    return;
                }

                if (txtZerenren1.Text.Trim() == "")
                {
                    MessageBox.Show("请填写供应商名称！");
                    return;
                }
                if (datehetong.Text == "")
                {
                    MessageBox.Show("请选择日期");
                    return;
                }
                DataTable dt1 = new DataTable();

                string sql = "select 编号,号码 from tb_hetonghao1 where 号码=( select max(号码)from   tb_hetonghao1  where 用户名='" + yonghu + "' ) and 用户名='" + yonghu + "' ";
                DataTable da = SQLhelp.GetDataTable(sql, CommandType.Text);
                string haoma = da.Rows[0][1].ToString();
                string bianhao = da.Rows[0][0].ToString();

                if (haoma.Length == 1)
                {
                    haoma = "000" + haoma;
                }
                if (haoma.Length == 2)
                {
                    haoma = "00" + haoma;
                }
                if (haoma.Length == 3)
                {
                    haoma = "0" + haoma;
                }
                string hetonghao = bianhao + haoma;
                if (radioButton2.Checked == true)
                {
                    hetonghao = txthetonghaobianhao.Text.Trim();
                }
                DateTime a = DateTime.Now;
                DateTime b = a.AddDays(3);
                DateTime c = a.AddDays(33);
                string qiandingshijian = b.ToString("yyyy年MM月dd日");
                string jiaohuoriqi = c.ToString("yyyy年MM月dd日");
                string qiandingyifang = txtZerenren1.Text.Trim();
                string heji = zongjia1;
                string sql1 = "select 单位名称,单位地址,法定代表人,委托代理人,电话,传真,税务登记号,开户银行,帐号,邮箱 from tb_gongfang where 单位名称='" + txtZerenren1.Text.Trim() + "'";
                DataTable daa = SQLhelp.GetDataTable(sql1, CommandType.Text);

                string danweidizhi = daa.Rows[0][1].ToString();
                string fadingdaibiaoren = daa.Rows[0][2].ToString();
                string weituodailiren = daa.Rows[0][3].ToString();
                string dianhua = daa.Rows[0][4].ToString();
                string chuanzhen = daa.Rows[0][5].ToString();
                string shuiwudengjihao = daa.Rows[0][6].ToString();
                string kaihuyinhang = daa.Rows[0][7].ToString();
                string zhanghao = daa.Rows[0][8].ToString();
                string youxiang = daa.Rows[0][9].ToString();


                string sql12 = "select 电话  from tb_operator1 where 用户名='" + yonghu + "'";
                string caigoudianhua = Convert.ToString(SQLhelp.ExecuteScalar(sql12, CommandType.Text));

                dt1.Columns.Add("邮箱", typeof(string));
                dt1.Columns.Add("生产进度负责人", typeof(string));
                dt1.Columns.Add("负责人电话", typeof(string));
                dt1.Columns.Add("合同编号", typeof(string));
                dt1.Columns.Add("签订时间", typeof(string));
                dt1.Columns.Add("签订乙方", typeof(string));
                dt1.Columns.Add("合计", typeof(string));
                dt1.Columns.Add("用户", typeof(string));
                dt1.Columns.Add("单位名称", typeof(string));
                dt1.Columns.Add("单位地址", typeof(string));
                dt1.Columns.Add("法定代表人", typeof(string));
                dt1.Columns.Add("委托代理人", typeof(string));
                dt1.Columns.Add("电话", typeof(string));
                dt1.Columns.Add("传真", typeof(string));
                dt1.Columns.Add("税务登记号", typeof(string));
                dt1.Columns.Add("开户银行", typeof(string));
                dt1.Columns.Add("帐号", typeof(string));
                dt1.Columns.Add("税务登记号1", typeof(string));
                dt1.Columns.Add("开户银行1", typeof(string));
                dt1.Columns.Add("单位名称1", typeof(string));
                dt1.Columns.Add("帐号1", typeof(string));
                dt1.Columns.Add("合计大写", typeof(string));
                for (int i = 0; i < 100; i++)
                {
                    dt1.Columns.Add("单位" + (i + 1), typeof(string));
                    dt1.Columns.Add("ERP" + (i + 1), typeof(string));
                    dt1.Columns.Add("产品名称" + (i + 1), typeof(string));
                    dt1.Columns.Add("规格型号" + (i + 1), typeof(string));
                    dt1.Columns.Add("数量" + (i + 1), typeof(string));
                    dt1.Columns.Add("单价" + (i + 1), typeof(string));
                    dt1.Columns.Add("总金额" + (i + 1), typeof(string));
                    dt1.Columns.Add("备注" + (i + 1), typeof(string));
                    dt1.Columns.Add("序号" + (i + 1), typeof(string));
                }

                DataRow dr1 = dt1.NewRow();

                for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
                {
                    if (dataGridViewX1.Rows[i].Cells["编码"].Value == null)
                    {
                        dr1["ERP" + (i + 1)] = "";
                    }
                    if (dataGridViewX1.Rows[i].Cells["编码"].Value != null)
                    {
                        dr1["ERP" + (i + 1)] = dataGridViewX1.Rows[i].Cells["编码"].Value.ToString();
                    }
                    if (dataGridViewX1.Rows[i].Cells["名称"].Value == null)
                    {
                        dr1["产品名称" + (i + 1)] = "";
                    }
                    if (dataGridViewX1.Rows[i].Cells["名称"].Value != null)
                    {
                        dr1["产品名称" + (i + 1)] = dataGridViewX1.Rows[i].Cells["名称"].Value.ToString();
                        dr1["序号" + (i + 1)] = i + 1;
                    }

                    if (dataGridViewX1.Rows[i].Cells["型号"].Value == null)
                    {
                        dr1["规格型号" + (i + 1)] = "";
                    }

                    if (dataGridViewX1.Rows[i].Cells["型号"].Value != null)
                    {
                        dr1["规格型号" + (i + 1)] = dataGridViewX1.Rows[i].Cells["型号"].Value.ToString();
                    }

                    if (dataGridViewX1.Rows[i].Cells["实际采购数量"].Value == null)
                    {
                        dr1["数量" + (i + 1)] = "";
                    }

                    if (dataGridViewX1.Rows[i].Cells["实际采购数量"].Value != null)
                    {
                        dr1["数量" + (i + 1)] = dataGridViewX1.Rows[i].Cells["实际采购数量"].Value.ToString();
                    }


                    if (dataGridViewX1.Rows[i].Cells["采购单价"].Value == null)
                    {
                        dr1["单价" + (i + 1)] = "";
                    }

                    if (dataGridViewX1.Rows[i].Cells["采购单价"].Value != null)
                    {
                        dr1["单价" + (i + 1)] = dataGridViewX1.Rows[i].Cells["采购单价"].Value.ToString();
                    }

                    if (dataGridViewX1.Rows[i].Cells["单位"].Value == null)
                    {
                        dr1["单位" + (i + 1)] = "";
                    }

                    if (dataGridViewX1.Rows[i].Cells["单位"].Value != null)
                    {
                        dr1["单位" + (i + 1)] = dataGridViewX1.Rows[i].Cells["单位"].Value.ToString();
                    }


                    if (dataGridViewX1.Rows[i].Cells["总价"].Value == null)
                    {
                        dr1["总金额" + (i + 1)] = "";
                    }

                    if (dataGridViewX1.Rows[i].Cells["总价"].Value != null)
                    {
                        dr1["总金额" + (i + 1)] = dataGridViewX1.Rows[i].Cells["总价"].Value.ToString();
                    }

                    if (dataGridViewX1.Rows[i].Cells["工作令号"].Value == null)
                    {
                        dr1["备注" + (i + 1)] = "";
                    }
                    if (dataGridViewX1.Rows[i].Cells["工作令号"].Value != null)
                    {
                        dr1["备注" + (i + 1)] = dataGridViewX1.Rows[i].Cells["工作令号"].Value.ToString();
                    }
                }
                
                dr1["邮箱"] = youxiang;
                dr1["合同编号"] = hetonghao;
                dr1["签订时间"] = qiandingshijian;
                dr1["签订乙方"] = qiandingyifang;
                dr1["合计"] = heji;
                dr1["合计大写"] = MoneyToChinese(heji);
                dr1["用户"] = yonghu;
                dr1["单位名称"] = txtZerenren1.Text;
                dr1["单位地址"] = danweidizhi;
                dr1["法定代表人"] = fadingdaibiaoren;
                dr1["委托代理人"] = weituodailiren;
                dr1["电话"] = dianhua;
                dr1["传真"] = chuanzhen;
                dr1["税务登记号"] = shuiwudengjihao;
                dr1["开户银行"] = kaihuyinhang;
                dr1["帐号"] = zhanghao;
                dr1["税务登记号1"] = shuiwudengjihao;
                dr1["开户银行1"] = kaihuyinhang;
                dr1["单位名称1"] = txtZerenren1.Text;
                dr1["帐号1"] = zhanghao;
                dr1["生产进度负责人"] = txtgangfangfuzeren.Text.Trim();
                dr1["负责人电话"] = txtgongfangfuzerendianhua.Text.Trim();
                dt1.Rows.Add(dr1);
                string tempFile = Application.StartupPath + "\\设备合同模板.doc";
                Document doc = new Document(tempFile);
                DocumentBuilder builder = new DocumentBuilder(doc);
                NodeCollection allTables = doc.GetChildNodes(NodeType.Table, true);
                Dictionary<string, string> dic = new Dictionary<string, string>();
                DataRow dr = dt1.Rows[0];
                dic.Add("生产进度负责人", dr["生产进度负责人"].ToString());
                dic.Add("负责人电话", dr["负责人电话"].ToString());
                dic.Add("合同编号", dr["合同编号"].ToString());
                dic.Add("签订时间", dr["签订时间"].ToString());
                dic.Add("签订乙方", dr["签订乙方"].ToString());
                dic.Add("合计", dr["合计"].ToString());
                dic.Add("用户", dr["用户"].ToString());
                dic.Add("单位名称", dr["单位名称"].ToString());
                dic.Add("单位地址", dr["单位地址"].ToString());
                dic.Add("法定代表人", dr["法定代表人"].ToString());
                dic.Add("委托代理人", dr["委托代理人"].ToString());
                dic.Add("电话", dr["电话"].ToString());
                dic.Add("传真", dr["传真"].ToString());
                dic.Add("税务登记号", dr["税务登记号"].ToString());
                dic.Add("开户银行", dr["开户银行"].ToString());
                dic.Add("帐号", dr["帐号"].ToString());
                dic.Add("单位名称1", dr["单位名称1"].ToString());
                dic.Add("帐号1", dr["帐号1"].ToString());
                dic.Add("开户银行1", dr["开户银行1"].ToString());
                dic.Add("税务登记号1", dr["税务登记号1"].ToString());
                dic.Add("合计大写", dr["合计大写"].ToString());
                for (int i = 0; i < 100; i++)
                {
                    dic.Add("ERP" + (i + 1), dr["ERP" + (i + 1)].ToString());
                    dic.Add("单位" + (i + 1), dr["单位" + (i + 1)].ToString());
                    dic.Add("产品名称" + (i + 1), dr["产品名称" + (i + 1)].ToString());
                    dic.Add("规格型号" + (i + 1), dr["规格型号" + (i + 1)].ToString());
                    dic.Add("数量" + (i + 1), dr["数量" + (i + 1)].ToString());
                    dic.Add("单价" + (i + 1), dr["单价" + (i + 1)].ToString());
                    dic.Add("总金额" + (i + 1), dr["总金额" + (i + 1)].ToString());
                    dic.Add("备注" + (i + 1), dr["备注" + (i + 1)].ToString());
                    dic.Add("序号" + (i + 1), dr["序号" + (i + 1)].ToString());
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                    qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
                    string id = Convert.ToString(dt.Rows[i]["id"]);
                    string gonglinghao = Convert.ToString(dt.Rows[i]["工作令号"]);
                    string xiangmumingcheng = Convert.ToString(dt.Rows[i]["项目名称"]);
                    string shebeimingcheng = Convert.ToString(dt.Rows[i]["设备名称"]);
                    string bianma = Convert.ToString(dt.Rows[i]["编码"]);
                    string mingcheng1 = Convert.ToString(dt.Rows[i]["名称"]);
                    string xinghao1 = Convert.ToString(dt.Rows[i]["型号"]);
                    string shuliang = "采购数量：" + Convert.ToString(dt.Rows[i]["实际采购数量"]);
                    string gongyingshang = txtZerenren1.Text;
                    string hetonghao1 = hetonghao;
                    string sql3 = "select 料单序号 from tb_caigouliaodan where id='" + id + "'";
                    string liaodanxuhao = Convert.ToString(SQLhelp.ExecuteScalar(sql3, CommandType.Text));
                    string dataCode = id + "|" + bianma + "|" + gongyingshang + "|" + hetonghao1 + "|";
                    Image image;
                    string data = dataCode;
                    image = qrCodeEncoder.Encode(data, Encoding.UTF8);
                    System.Drawing.Bitmap newImg;
                    newImg = new Bitmap(image.Width + 200, image.Height + 40);
                    Graphics g = Graphics.FromImage(newImg);
                    g.Clear(Color.White);
                    g.DrawImageUnscaled(image, 0, 0);
                    System.Drawing.Font font = new System.Drawing.Font("黑体", 11, FontStyle.Bold);
                    SolidBrush brush = new SolidBrush(Color.Black);
                    g.DrawString(gonglinghao, font, brush, image.Width, 0);
                    g.DrawString(bianma, font, brush, image.Width, 25);
                    g.DrawString(mingcheng1, font, brush, image.Width, 50);
                    g.DrawString(xinghao1, font, brush, image.Width, 75);
                    g.DrawString(gongyingshang, font, brush, image.Width, 100);
                    g.DrawString(hetonghao1, font, brush, image.Width, 125);
                    g.DrawString(shuliang, font, brush, image.Width, 150);
                    g.DrawString("序列号:" + liaodanxuhao, font, brush, image.Width, 175);
                    image = newImg;
                    string erweima = "二维码" + i;

                    builder.MoveToBookmark(erweima);
                    builder.InsertImage(image, RelativeHorizontalPosition.Margin, 1, RelativeVerticalPosition.Margin, 1, 180, 117, WrapType.Square);
                }

                foreach (var key in dic.Keys)
                {
                    builder.MoveToBookmark(key);
                    builder.Write(dic[key]);
                }
                Random suiji = new Random();
                int n = suiji.Next(0, 1000);
                string mingcheng = yonghu + DateTime.Now.ToString("yyyy-MM-dd") + "设备合同模板" + n + ".doc";
                FileInfo info1 = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\" + mingcheng);
                string fileName11 = info1.Name.ToString();
                string floderName = fileName11.Substring(0, fileName11.Length - 4).ToString();
                doc.Save(info1.DirectoryName + "\\" + fileName11);
                string pathfilesave = info1.DirectoryName + "\\" + mingcheng;
                MessageBox.Show("已保存到桌面！");
                System.Diagnostics.Process.Start(pathfilesave);
            }
            if (zhonglei == "采购")
            {
                if (zongjia1 == "" || zongjia1 == "0"||zongjia1==null)
                {
                    MessageBox.Show("请计算合同总价！");
                    return;
                }
                if (txtZerenren1.Text.Trim() == "")
                {
                    MessageBox.Show("请填写供应商名称！");
                    return;

                }
                if(datehetong.Text=="")
                {
                    MessageBox.Show("请选择日期");
                    return;
                }
                DataTable dt1 = new DataTable();

                string sql = "select 编号,号码 from tb_hetonghao1 where 号码=( select max(号码)from   tb_hetonghao1  where 用户名='" + yonghu + "' ) and 用户名='" + yonghu + "' ";
                DataTable da = SQLhelp.GetDataTable(sql, CommandType.Text);
                string haoma = da.Rows[0][1].ToString();
                string bianhao = da.Rows[0][0].ToString();

                if (haoma.Length == 1)
                {
                    haoma = "000" + haoma;
                }
                if (haoma.Length == 2)
                {
                    haoma = "00" + haoma;
                }
                if (haoma.Length == 3)
                {
                    haoma = "0" + haoma;
                }
                string hetonghao = bianhao + haoma;
                if (radioButton2.Checked == true)
                {
                    hetonghao = txthetonghaobianhao.Text.Trim();
                }
                //"yyyy年MM月dd日"
                DateTime a = DateTime.Now;
                DateTime b = a.AddDays(3);
                DateTime c = a.AddDays(33);
                string qiandingshijian = b.ToString("yyyy年MM月dd日");
                string jiaohuoriqi = c.ToString("yyyy年MM月dd日");
                string qiandingyifang = txtZerenren1.Text.Trim();
                string daohuoshijian = datehetong.Text;
                string heji = zongjia1;

                string sql1 = "select 单位名称,单位地址,法定代表人,委托代理人,电话,传真,税务登记号,开户银行,帐号,邮箱 from tb_gongfang where 单位名称='" + txtZerenren1.Text.Trim() + "'";
                DataTable daa = SQLhelp.GetDataTable(sql1, CommandType.Text);

                string danweidizhi = daa.Rows[0][1].ToString();
                string fadingdaibiaoren = daa.Rows[0][2].ToString();
                string weituodailiren = daa.Rows[0][3].ToString();
                string dianhua = daa.Rows[0][4].ToString();
                string chuanzhen = daa.Rows[0][5].ToString();
                string shuiwudengjihao = daa.Rows[0][6].ToString();
                string kaihuyinhang = daa.Rows[0][7].ToString();
                string zhanghao = daa.Rows[0][8].ToString();
                string youxiang = daa.Rows[0][9].ToString();

                string sql12 = "select 电话  from tb_operator1 where 用户名='" + yonghu + "'";
                string caigoudianhua = Convert.ToString(SQLhelp.ExecuteScalar(sql12, CommandType.Text));

                dt1.Columns.Add("邮箱", typeof(string));
                dt1.Columns.Add("生产进度负责人", typeof(string));
                dt1.Columns.Add("负责人电话", typeof(string));
                dt1.Columns.Add("采购员电话", typeof(string));
                dt1.Columns.Add("交货日期", typeof(string));
                dt1.Columns.Add("合同编号", typeof(string));
                dt1.Columns.Add("签订时间", typeof(string));
                dt1.Columns.Add("签订乙方", typeof(string));
                dt1.Columns.Add("合计", typeof(string));
                dt1.Columns.Add("合计大写", typeof(string));
                dt1.Columns.Add("到货时间", typeof(string));
                dt1.Columns.Add("用户", typeof(string));
                dt1.Columns.Add("单位名称", typeof(string));
                dt1.Columns.Add("单位地址", typeof(string));
                dt1.Columns.Add("法定代表人", typeof(string));
                dt1.Columns.Add("委托代理人", typeof(string));
                dt1.Columns.Add("电话", typeof(string));
                dt1.Columns.Add("传真", typeof(string));
                dt1.Columns.Add("税务登记号", typeof(string));
                dt1.Columns.Add("开户银行", typeof(string));
                dt1.Columns.Add("帐号", typeof(string));
                dt1.Columns.Add("用户1", typeof(string));
                dt1.Columns.Add("传真1", typeof(string));
                dt1.Columns.Add("单位地址1", typeof(string));

                for (int i = 0; i < 200; i++)
                {
                    dt1.Columns.Add("单位" + (i + 1), typeof(string));
                    dt1.Columns.Add("ERP" + (i + 1), typeof(string));
                    dt1.Columns.Add("产品名称" + (i + 1), typeof(string));
                    dt1.Columns.Add("规格型号" + (i + 1), typeof(string));
                    dt1.Columns.Add("数量" + (i + 1), typeof(string));
                    dt1.Columns.Add("单价" + (i + 1), typeof(string));
                    dt1.Columns.Add("总金额" + (i + 1), typeof(string));
                    dt1.Columns.Add("备注" + (i + 1), typeof(string));
                    dt1.Columns.Add("序号" + (i + 1), typeof(string));
                    dt1.Columns.Add("类型" + (i + 1), typeof(string));
                    dt1.Columns.Add("工令号" + (i + 1), typeof(string));

                }

                DataRow dr1 = dt1.NewRow();

                for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
                {
                    if (dataGridViewX1.Rows[i].Cells["编码"].Value == null)
                    {
                        dr1["ERP" + (i + 1)] = "";
                    }
                    if (dataGridViewX1.Rows[i].Cells["编码"].Value != null)
                    {
                        dr1["ERP" + (i + 1)] = dataGridViewX1.Rows[i].Cells["编码"].Value.ToString();
                    }
                    if (dataGridViewX1.Rows[i].Cells["名称"].Value == null)
                    {
                        dr1["产品名称" + (i + 1)] = "";
                    }
                    if (dataGridViewX1.Rows[i].Cells["名称"].Value != null)
                    {
                        dr1["产品名称" + (i + 1)] = dataGridViewX1.Rows[i].Cells["名称"].Value.ToString();
                        dr1["序号" + (i + 1)] = i + 1;
                    }

                    if (dataGridViewX1.Rows[i].Cells["型号"].Value == null)
                    {
                        dr1["规格型号" + (i + 1)] = "";
                    }

                    if (dataGridViewX1.Rows[i].Cells["型号"].Value != null)
                    {
                        dr1["规格型号" + (i + 1)] = dataGridViewX1.Rows[i].Cells["型号"].Value.ToString();
                    }

                    if (dataGridViewX1.Rows[i].Cells["类型"].Value == null)
                    {
                        dr1["类型" + (i + 1)] = "";
                    }
                    if (dataGridViewX1.Rows[i].Cells["类型"].Value != null)
                    {
                        dr1["类型" + (i + 1)] = dataGridViewX1.Rows[i].Cells["类型"].Value.ToString();
                    }
                    if (dataGridViewX1.Rows[i].Cells["实际采购数量"].Value == null)
                    {
                        dr1["数量" + (i + 1)] = "";
                    }

                    if (dataGridViewX1.Rows[i].Cells["实际采购数量"].Value != null)
                    {
                        dr1["数量" + (i + 1)] = dataGridViewX1.Rows[i].Cells["实际采购数量"].Value.ToString();
                    }


                    if (dataGridViewX1.Rows[i].Cells["采购单价"].Value == null)
                    {
                        dr1["单价" + (i + 1)] = "";
                    }

                    if (dataGridViewX1.Rows[i].Cells["采购单价"].Value != null)
                    {
                        dr1["单价" + (i + 1)] = dataGridViewX1.Rows[i].Cells["采购单价"].Value.ToString();
                    }

                    if (dataGridViewX1.Rows[i].Cells["单位"].Value == null)
                    {
                        dr1["单位" + (i + 1)] = "";
                    }

                    if (dataGridViewX1.Rows[i].Cells["单位"].Value != null)
                    {
                        dr1["单位" + (i + 1)] = dataGridViewX1.Rows[i].Cells["单位"].Value.ToString();
                    }


                    if (dataGridViewX1.Rows[i].Cells["总价"].Value == null)
                    {
                        dr1["总金额" + (i + 1)] = "";
                    }

                    if (dataGridViewX1.Rows[i].Cells["总价"].Value != null)
                    {
                        dr1["总金额" + (i + 1)] = dataGridViewX1.Rows[i].Cells["总价"].Value.ToString();
                    }

                    if (dataGridViewX1.Rows[i].Cells["工作令号"].Value == null)
                    {
                        dr1["备注" + (i + 1)] = "";
                    }
                    if (dataGridViewX1.Rows[i].Cells["工作令号"].Value != null)
                    {
                        dr1["备注" + (i + 1)] = dataGridViewX1.Rows[i].Cells["工作令号"].Value.ToString();
                    }

                    if (dataGridViewX1.Rows[i].Cells["备注"].Value == null)
                    {
                        dr1["工令号" + (i + 1)] = "";
                    }
                    if (dataGridViewX1.Rows[i].Cells["备注"].Value != null)
                    {
                        dr1["工令号" + (i + 1)] = dataGridViewX1.Rows[i].Cells["备注"].Value.ToString();
                    }

                } 
                dr1["邮箱"] = youxiang;
                dr1["合同编号"] = hetonghao;
                dr1["签订时间"] = qiandingshijian;
                dr1["签订乙方"] = qiandingyifang;
                dr1["合计"] = heji;
                dr1["合计大写"] = MoneyToChinese(heji);

                dr1["到货时间"] = shengchennianyueri(daohuoshijian);
                dr1["用户"] = yonghu;
                dr1["单位名称"] = txtZerenren1.Text;
                dr1["单位地址"] = danweidizhi;
                dr1["法定代表人"] = fadingdaibiaoren;
                dr1["委托代理人"] = weituodailiren;
                dr1["电话"] = dianhua;
                dr1["传真"] = chuanzhen;
                dr1["税务登记号"] = shuiwudengjihao;
                dr1["开户银行"] = kaihuyinhang;
                dr1["帐号"] = zhanghao;
                dr1["交货日期"] = jiaohuoriqi;
                dr1["用户1"] = yonghu;
                dr1["传真1"] = chuanzhen;
                dr1["单位地址1"] = danweidizhi;
                dr1["采购员电话"] = caigoudianhua;
                dr1["生产进度负责人"] = txtgangfangfuzeren.Text.Trim();
                dr1["负责人电话"] = txtgongfangfuzerendianhua.Text.Trim();

                dt1.Rows.Add(dr1);

                string tempFile = Application.StartupPath + "\\采购合同模板.doc";
                Document doc = new Document(tempFile);
                DocumentBuilder builder = new DocumentBuilder(doc);
                NodeCollection allTables = doc.GetChildNodes(NodeType.Table, true);

                Dictionary<string, string> dic = new Dictionary<string, string>();
                DataRow dr = dt1.Rows[0];


                dic.Add("邮箱", dr["邮箱"].ToString());
                dic.Add("生产进度负责人", dr["生产进度负责人"].ToString());
                dic.Add("负责人电话", dr["负责人电话"].ToString());
                dic.Add("合同编号", dr["合同编号"].ToString());
                dic.Add("签订时间", dr["签订时间"].ToString());
                dic.Add("签订乙方", dr["签订乙方"].ToString());
                dic.Add("合计", dr["合计"].ToString());
                dic.Add("到货时间", dr["到货时间"].ToString()+"前");
                dic.Add("合计大写", dr["合计大写"].ToString());
                dic.Add("用户", dr["用户"].ToString());
                dic.Add("单位名称", dr["单位名称"].ToString());
                dic.Add("单位地址", dr["单位地址"].ToString());
                dic.Add("法定代表人", dr["法定代表人"].ToString());
                dic.Add("委托代理人", dr["委托代理人"].ToString());
                dic.Add("电话", dr["电话"].ToString());
                dic.Add("传真", dr["传真"].ToString());
                dic.Add("税务登记号", dr["税务登记号"].ToString());
                dic.Add("开户银行", dr["开户银行"].ToString());
                dic.Add("帐号", dr["帐号"].ToString());
                dic.Add("用户1", dr["用户1"].ToString());
                dic.Add("传真1", dr["传真1"].ToString());
                dic.Add("单位地址1", dr["单位地址1"].ToString());
                dic.Add("采购员电话", dr["采购员电话"].ToString());



                for (int i = 0; i < 200; i++)
                {
                    dic.Add("ERP" + (i + 1), dr["ERP" + (i + 1)].ToString());
                    dic.Add("单位" + (i + 1), dr["单位" + (i + 1)].ToString());
                    dic.Add("产品名称" + (i + 1), dr["产品名称" + (i + 1)].ToString());
                    dic.Add("规格型号" + (i + 1), dr["规格型号" + (i + 1)].ToString());
                    dic.Add("数量" + (i + 1), dr["数量" + (i + 1)].ToString());
                    dic.Add("单价" + (i + 1), dr["单价" + (i + 1)].ToString());
                    dic.Add("总金额" + (i + 1), dr["总金额" + (i + 1)].ToString());
                    dic.Add("备注" + (i + 1), dr["备注" + (i + 1)].ToString());
                    dic.Add("序号" + (i + 1), dr["序号" + (i + 1)].ToString());
                    dic.Add("类型" + (i + 1), dr["类型" + (i + 1)].ToString());
                    dic.Add("工令号" + (i + 1), dr["工令号" + (i + 1)].ToString());
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                    qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
                    string id = Convert.ToString(dt.Rows[i]["id"]);
                    string gonglinghao = Convert.ToString(dt.Rows[i]["工作令号"]);
                    string xiangmumingcheng = Convert.ToString(dt.Rows[i]["项目名称"]);
                    string shebeimingcheng = Convert.ToString(dt.Rows[i]["设备名称"]);
                    string bianma = Convert.ToString(dt.Rows[i]["编码"]);
                    string mingcheng1 = Convert.ToString(dt.Rows[i]["名称"]);
                    string xinghao1 = Convert.ToString(dt.Rows[i]["型号"]);
                    string shuliang = "采购数量：" + Convert.ToString(dt.Rows[i]["实际采购数量"]);
                    string gongyingshang = txtZerenren1.Text;
                    string hetonghao1 = hetonghao;
                    string dataCode = id + "|" + bianma + "|" + gongyingshang + "|" + hetonghao1 + "|";
                    string sql3 = "select 料单序号 from tb_caigouliaodan where id='"+id+"'";
                    string liaodanxuhao = Convert.ToString(SQLhelp.ExecuteScalar(sql3, CommandType.Text));
                    Image image;
                    string data = dataCode;
                    image = qrCodeEncoder.Encode(data, Encoding.UTF8);
                    System.Drawing.Bitmap newImg;
                    newImg = new Bitmap(image.Width + 200, image.Height + 40);
                    Graphics g = Graphics.FromImage(newImg);
                    g.Clear(Color.White);
                    g.DrawImageUnscaled(image, 0, 0);
                    System.Drawing.Font font = new System.Drawing.Font("黑体", 11, FontStyle.Bold);
                    SolidBrush brush = new SolidBrush(Color.Black);
                    g.DrawString(gonglinghao, font, brush, image.Width, 0);
                    g.DrawString(bianma, font, brush, image.Width, 25);
                    g.DrawString(mingcheng1, font, brush, image.Width, 50);
                    g.DrawString(xinghao1, font, brush, image.Width, 75);
                    g.DrawString(gongyingshang, font, brush, image.Width, 100);
                    g.DrawString(hetonghao1, font, brush, image.Width, 125);
                    g.DrawString(shuliang, font, brush, image.Width, 150);
                    g.DrawString("序列号:" + liaodanxuhao, font, brush, image.Width, 175);
                    image = newImg;
                    string erweima = "二维码" + i;
                    builder.MoveToBookmark(erweima);
                    builder.InsertImage(image, RelativeHorizontalPosition.Margin, 1, RelativeVerticalPosition.Margin, 1, 180, 117, WrapType.Square);
                   
                }

                foreach (var key in dic.Keys)
                {
                    builder.MoveToBookmark(key);
                    builder.Write(dic[key]);
                }
                Random suiji = new Random();
                int n = suiji.Next(0, 1000);

                string mingcheng = yonghu + DateTime.Now.ToString("yyyy-MM-dd") + "采购合同模板" + n + ".doc";
                FileInfo info1 = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\" + mingcheng);
                string fileName11 = info1.Name.ToString();
                string floderName = fileName11.Substring(0, fileName11.Length - 4).ToString();
                doc.Save(info1.DirectoryName + "\\" + fileName11);
                string pathfilesave = info1.DirectoryName + "\\" + mingcheng;
                MessageBox.Show("已保存到桌面！");
                System.Diagnostics.Process.Start(pathfilesave);
            }
            if (zhonglei == "普通")
            {
                if (txtZerenren1.Text.Trim() == "")
                {
                    MessageBox.Show("请填写供应商名称！");
                    return;
                }
                if (zongjia1 == "" || zongjia1 == "0"|| zongjia1==null)
                {
                    MessageBox.Show("请计算合同总价！");
                    return;
                }
                if (datehetong.Text == "")
                {
                    MessageBox.Show("请选择日期");
                    return;
                }
                DataTable dt1 = new DataTable();
                string sql = "select 编号,号码 from tb_hetonghao1 where 号码=( select max(号码)from   tb_hetonghao1  where 用户名='" + yonghu + "' ) and 用户名='" + yonghu + "' ";
                DataTable da = SQLhelp.GetDataTable(sql, CommandType.Text);
                string haoma = da.Rows[0][1].ToString();
                string bianhao = da.Rows[0][0].ToString();

                if (haoma.Length == 1)
                {
                    haoma = "000" + haoma;
                }
                if (haoma.Length == 2)
                {
                    haoma = "00" + haoma;
                }
                if (haoma.Length == 3)
                {
                    haoma = "0" + haoma;
                }
                string hetonghao = bianhao + haoma;
                if (radioButton2.Checked == true)
                {
                    hetonghao = txthetonghaobianhao.Text.Trim();
                }
                DateTime a = DateTime.Now;
                DateTime b = a.AddDays(3);
                DateTime c = a.AddDays(33);
                string qiandingshijian = b.ToString("yyyy年MM月dd日");
                string jiaohuoriqi = c.ToString("yyyy年MM月dd日");
                string qiandingyifang = txtZerenren1.Text.Trim();
                string heji = zongjia1;
                string daohuoshijian = datehetong.Text;
                string sql1 = "select 单位名称,单位地址,法定代表人,委托代理人,电话,传真,税务登记号,开户银行,帐号,邮箱 from tb_gongfang where 单位名称='" + txtZerenren1.Text.Trim() + "'";
                DataTable daa = SQLhelp.GetDataTable(sql1, CommandType.Text);
                string danweidizhi = daa.Rows[0][1].ToString();
                string fadingdaibiaoren = daa.Rows[0][2].ToString();
                string weituodailiren = daa.Rows[0][3].ToString();
                string dianhua = daa.Rows[0][4].ToString();
                string chuanzhen = daa.Rows[0][5].ToString();
                string shuiwudengjihao = daa.Rows[0][6].ToString();
                string kaihuyinhang = daa.Rows[0][7].ToString();
                string zhanghao = daa.Rows[0][8].ToString();
                string youxiang = daa.Rows[0][9].ToString();
                string sql12 = "select 电话  from tb_operator1 where 用户名='" + yonghu + "'";
                string caigoudianhua = Convert.ToString(SQLhelp.ExecuteScalar(sql12, CommandType.Text));
                dt1.Columns.Add("邮箱", typeof(string));
                dt1.Columns.Add("生产进度负责人", typeof(string));
                dt1.Columns.Add("负责人电话", typeof(string));
                dt1.Columns.Add("采购员电话", typeof(string));
                dt1.Columns.Add("合计1", typeof(string));
                dt1.Columns.Add("交货日期", typeof(string));
                dt1.Columns.Add("合同编号", typeof(string));
                dt1.Columns.Add("签订时间", typeof(string));
                dt1.Columns.Add("签订乙方", typeof(string));
                dt1.Columns.Add("合计", typeof(string));
                dt1.Columns.Add("合计大写", typeof(string));
                dt1.Columns.Add("到货时间", typeof(string));
                dt1.Columns.Add("用户", typeof(string));
                dt1.Columns.Add("单位名称", typeof(string));
                dt1.Columns.Add("单位地址", typeof(string));
                dt1.Columns.Add("法定代表人", typeof(string));
                dt1.Columns.Add("委托代理人", typeof(string));
                dt1.Columns.Add("电话", typeof(string));
                dt1.Columns.Add("传真", typeof(string));
                dt1.Columns.Add("税务登记号", typeof(string));
                dt1.Columns.Add("开户银行", typeof(string));
                dt1.Columns.Add("帐号", typeof(string));
                for (int i = 0; i < 200; i++)
                {
                    dt1.Columns.Add("单位" + (i + 1), typeof(string));
                    dt1.Columns.Add("ERP" + (i + 1), typeof(string));
                    dt1.Columns.Add("产品名称" + (i + 1), typeof(string));
                    dt1.Columns.Add("规格型号" + (i + 1), typeof(string));
                    dt1.Columns.Add("数量" + (i + 1), typeof(string));
                    dt1.Columns.Add("单价" + (i + 1), typeof(string));
                    dt1.Columns.Add("总金额" + (i + 1), typeof(string));
                    dt1.Columns.Add("备注" + (i + 1), typeof(string));
                    dt1.Columns.Add("序号" + (i + 1), typeof(string));
                    dt1.Columns.Add("类型" + (i + 1), typeof(string));
                    dt1.Columns.Add("工令号" + (i + 1), typeof(string));
                }
                DataRow dr1 = dt1.NewRow();
                for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
                {
                    if (dataGridViewX1.Rows[i].Cells["编码"].Value == null)
                    {
                        dr1["ERP" + (i + 1)] = "";
                    }
                    if (dataGridViewX1.Rows[i].Cells["编码"].Value != null)
                    {
                        dr1["ERP" + (i + 1)] = dataGridViewX1.Rows[i].Cells["编码"].Value.ToString();
                    }
                    if (dataGridViewX1.Rows[i].Cells["名称"].Value == null)
                    {
                        dr1["产品名称" + (i + 1)] = "";
                    }
                    if (dataGridViewX1.Rows[i].Cells["名称"].Value != null)
                    {
                        dr1["产品名称" + (i + 1)] = dataGridViewX1.Rows[i].Cells["名称"].Value.ToString();
                        dr1["序号" + (i + 1)] = i + 1;
                    }

                    if (dataGridViewX1.Rows[i].Cells["型号"].Value == null)
                    {
                        dr1["规格型号" + (i + 1)] = "";
                    }

                    if (dataGridViewX1.Rows[i].Cells["型号"].Value != null)
                    {
                        dr1["规格型号" + (i + 1)] = dataGridViewX1.Rows[i].Cells["型号"].Value.ToString();
                    }

                    if (dataGridViewX1.Rows[i].Cells["实际采购数量"].Value == null)
                    {
                        dr1["数量" + (i + 1)] = "";
                    }

                    if (dataGridViewX1.Rows[i].Cells["实际采购数量"].Value != null)
                    {
                        dr1["数量" + (i + 1)] = dataGridViewX1.Rows[i].Cells["实际采购数量"].Value.ToString();
                    }


                    if (dataGridViewX1.Rows[i].Cells["采购单价"].Value == null)
                    {
                        dr1["单价" + (i + 1)] = "";
                    }

                    if (dataGridViewX1.Rows[i].Cells["采购单价"].Value != null)
                    {
                        dr1["单价" + (i + 1)] = dataGridViewX1.Rows[i].Cells["采购单价"].Value.ToString();
                    }

                    if (dataGridViewX1.Rows[i].Cells["总价"].Value == null)
                    {
                        dr1["总金额" + (i + 1)] = "";
                    }

                    if (dataGridViewX1.Rows[i].Cells["总价"].Value != null)
                    {
                        dr1["总金额" + (i + 1)] = dataGridViewX1.Rows[i].Cells["总价"].Value.ToString();
                    }

                    if (dataGridViewX1.Rows[i].Cells["工作令号"].Value == null)
                    {
                        dr1["备注" + (i + 1)] = "";
                    }
                    if (dataGridViewX1.Rows[i].Cells["工作令号"].Value != null)
                    {
                        dr1["备注" + (i + 1)] = dataGridViewX1.Rows[i].Cells["工作令号"].Value.ToString();
                    }

                    if (dataGridViewX1.Rows[i].Cells["单位"].Value == null)
                    {
                        dr1["单位" + (i + 1)] = "";
                    }

                    if (dataGridViewX1.Rows[i].Cells["单位"].Value != null)
                    {
                        dr1["单位" + (i + 1)] = dataGridViewX1.Rows[i].Cells["单位"].Value.ToString();
                    }

                    if (dataGridViewX1.Rows[i].Cells["备注"].Value == null)
                    {
                        dr1["工令号" + (i + 1)] = "";
                    }

                    if (dataGridViewX1.Rows[i].Cells["备注"].Value != null)
                    {
                        dr1["工令号" + (i + 1)] = dataGridViewX1.Rows[i].Cells["备注"].Value.ToString();
                    }

                    if (dataGridViewX1.Rows[i].Cells["类型"].Value == null)
                    {
                        dr1["类型" + (i + 1)] = "";
                    }

                    if (dataGridViewX1.Rows[i].Cells["类型"].Value != null)
                    {
                        dr1["类型" + (i + 1)] = dataGridViewX1.Rows[i].Cells["类型"].Value.ToString();
                    }

                }
                dr1["邮箱"] = youxiang;
                dr1["合同编号"] = hetonghao;
                dr1["签订时间"] = qiandingshijian;
                dr1["签订乙方"] = qiandingyifang;
                dr1["合计"] = heji;
                dr1["合计大写"] = MoneyToChinese(heji);
                dr1["合计1"] = MoneyToChinese(heji);
                dr1["到货时间"] = shengchennianyueri(daohuoshijian);
                dr1["用户"] = yonghu;
                dr1["单位名称"] = txtZerenren1.Text;
                dr1["单位地址"] = danweidizhi;
                dr1["法定代表人"] = fadingdaibiaoren;
                dr1["委托代理人"] = weituodailiren;
                dr1["电话"] = dianhua;
                dr1["传真"] = chuanzhen;
                dr1["税务登记号"] = shuiwudengjihao;
                dr1["开户银行"] = kaihuyinhang;
                dr1["帐号"] = zhanghao;
                dr1["交货日期"] = jiaohuoriqi;
                dr1["生产进度负责人"] = txtgangfangfuzeren.Text.Trim();
                dr1["负责人电话"] = txtgongfangfuzerendianhua.Text.Trim();
                dt1.Rows.Add(dr1);
                string tempFile = Application.StartupPath + "\\合同标准模板.doc";
                Document doc = new Document(tempFile);
                DocumentBuilder builder = new DocumentBuilder(doc);
                NodeCollection allTables = doc.GetChildNodes(NodeType.Table, true);
                Dictionary<string, string> dic = new Dictionary<string, string>();
                DataRow dr = dt1.Rows[0];
                dic.Add("负责人电话", dr["负责人电话"].ToString());
                dic.Add("生产进度负责人", dr["生产进度负责人"].ToString());
                dic.Add("合同编号", dr["合同编号"].ToString());
                dic.Add("签订时间", dr["签订时间"].ToString());
                dic.Add("签订乙方", dr["签订乙方"].ToString());
                dic.Add("合计", dr["合计"].ToString());
                dic.Add("用户", dr["用户"].ToString());
                dic.Add("单位名称", dr["单位名称"].ToString());
                dic.Add("单位地址", dr["单位地址"].ToString());
                dic.Add("法定代表人", dr["法定代表人"].ToString());
                dic.Add("委托代理人", dr["委托代理人"].ToString());
                dic.Add("电话", dr["电话"].ToString());
                dic.Add("传真", dr["传真"].ToString());
                dic.Add("税务登记号", dr["税务登记号"].ToString());
                dic.Add("开户银行", dr["开户银行"].ToString());
                dic.Add("帐号", dr["帐号"].ToString());
                dic.Add("合计1", dr["合计1"].ToString());
                dic.Add("合计大写", dr["合计大写"].ToString());
                dic.Add("到货时间", dr["到货时间"].ToString()+"前");


                for (int i = 0; i < 200; i++)
                {
                    dic.Add("ERP" + (i + 1), dr["ERP" + (i + 1)].ToString());
                    dic.Add("单位" + (i + 1), dr["单位" + (i + 1)].ToString());
                    dic.Add("产品名称" + (i + 1), dr["产品名称" + (i + 1)].ToString());
                    dic.Add("规格型号" + (i + 1), dr["规格型号" + (i + 1)].ToString());
                    dic.Add("数量" + (i + 1), dr["数量" + (i + 1)].ToString());
                    dic.Add("单价" + (i + 1), dr["单价" + (i + 1)].ToString());
                    dic.Add("总金额" + (i + 1), dr["总金额" + (i + 1)].ToString());
                    dic.Add("备注" + (i + 1), dr["备注" + (i + 1)].ToString());
                    dic.Add("序号" + (i + 1), dr["序号" + (i + 1)].ToString());
                    dic.Add("类型" + (i + 1), dr["类型" + (i + 1)].ToString());
                    dic.Add("工令号" + (i + 1), dr["工令号" + (i + 1)].ToString());
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                    qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
                    string id = Convert.ToString(dt.Rows[i]["id"]);
                    string gonglinghao = Convert.ToString(dt.Rows[i]["工作令号"]);
                    string xiangmumingcheng = Convert.ToString(dt.Rows[i]["项目名称"]);
                    string shebeimingcheng = Convert.ToString(dt.Rows[i]["设备名称"]);
                    string bianma = Convert.ToString(dt.Rows[i]["编码"]);
                    string mingcheng1 = Convert.ToString(dt.Rows[i]["名称"]);
                    string xinghao1 = Convert.ToString(dt.Rows[i]["型号"]);
                    string shuliang = "采购数量：" + Convert.ToString(dt.Rows[i]["实际采购数量"]);
                    string gongyingshang = txtZerenren1.Text;
                    string hetonghao1 = hetonghao;
                    string sql3 = "select 料单序号 from tb_caigouliaodan where id='" + id + "'";
                    string liaodanxuhao = Convert.ToString(SQLhelp.ExecuteScalar(sql3, CommandType.Text));
                    string dataCode = id + "|" + bianma + "|" + gongyingshang + "|" + hetonghao1 + "|";
                    Image image;
                    string data = dataCode;
                    image = qrCodeEncoder.Encode(data, Encoding.UTF8);
                    System.Drawing.Bitmap newImg;
                    newImg = new Bitmap(image.Width + 200, image.Height + 40);
                    Graphics g = Graphics.FromImage(newImg);
                    g.Clear(Color.White);
                    g.DrawImageUnscaled(image, 0, 0);
                    System.Drawing.Font font = new System.Drawing.Font("黑体", 11, FontStyle.Bold);
                    SolidBrush brush = new SolidBrush(Color.Black);
                    g.DrawString(gonglinghao, font, brush, image.Width, 0);
                    g.DrawString(bianma, font, brush, image.Width, 25);
                    g.DrawString(mingcheng1, font, brush, image.Width, 50);
                    g.DrawString(xinghao1, font, brush, image.Width, 75);
                    g.DrawString(gongyingshang, font, brush, image.Width, 100);
                    g.DrawString(hetonghao1, font, brush, image.Width, 125);
                    g.DrawString(shuliang, font, brush, image.Width, 150);
                    g.DrawString("序列号:" + liaodanxuhao, font, brush, image.Width, 175);
                    image = newImg;
                    string erweima = "二维码" + i;
                    builder.MoveToBookmark(erweima);
                    builder.InsertImage(image, RelativeHorizontalPosition.Margin, 1, RelativeVerticalPosition.Margin, 1, 180, 117, WrapType.Square);
                }

                foreach (var key in dic.Keys)
                {
                    builder.MoveToBookmark(key);
                    builder.Write(dic[key]);
                }
                Random suiji = new Random();
                int n = suiji.Next(0, 1000);
                string mingcheng = yonghu + DateTime.Now.ToString("yyyy-MM-dd") + "成缆合同模板" + n + ".doc";
                FileInfo info1 = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\" + mingcheng);
                string fileName11 = info1.Name.ToString();
                string floderName = fileName11.Substring(0, fileName11.Length - 4).ToString();


                doc.Save(info1.DirectoryName + "\\" + fileName11);
                string pathfilesave = info1.DirectoryName + "\\" + mingcheng;
                MessageBox.Show("已保存到桌面！");
                System.Diagnostics.Process.Start(pathfilesave);
            }

        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                btnzidong.Enabled = true;
                btnzidingyi.Enabled = false;
                txthetonghaobianhao.Enabled = false;

            }
        }
        private void btnzidong_Click(object sender, EventArgs e)
        {
            if (zhonglei == "工序")
            {
                if (txtZerenren1.Text.Trim() == "")
                {
                    MessageBox.Show("请填写供应商名称！");
                    return;
                }
                if (zongjia1 == "" || zongjia1 == "0")
                {
                    MessageBox.Show("请计算合同总价！");
                    return;
                }

                string sql111222 = "select * from tb_gongfang  where 单位名称='" + txtZerenren1.Text + "'";
                DataTable dttt = SQLhelp.GetDataTable(sql111222, CommandType.Text);
                if (dttt.Rows.Count == 0)
                {
                    MessageBox.Show("供应商名录没有此供应商，请添加！");
                    return;
                }
                if (comshuilv.Text == "")
                {
                    MessageBox.Show("请填写税率");
                    return;
                }
                for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
                {
                    float a = 0;
                    if (float.TryParse(dataGridViewX1.Rows[i].Cells["采购单价"].Value.ToString(), out a) == false)
                    {
                        MessageBox.Show("其中有的采购单价写的不是数字，请重新填写！");
                        return;
                    }

                }
                if (datehetong.Text.Trim() == "")
                {
                    MessageBox.Show("请填写合同到货时间！");
                    return;
                }
                for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
                {
                    string a = Convert.ToString(dataGridViewX1.Rows[i].Cells["实际采购数量"].Value);
                    if (a == "")
                    {
                        MessageBox.Show("请填数量！");
                        return;
                    }
                }

                if (txtgangfangfuzeren.Text.Trim() == "")
                {
                    MessageBox.Show("请先输入供方负责人名称！");
                    return;
                }
                if (comshuilv.Text == "")
                {
                    MessageBox.Show("请填写税率");
                    return;
                }
                if (txtgongfangfuzerendianhua.Text.Trim() == "")
                {
                    MessageBox.Show("请先输入供方负责人电话！");
                    return;
                }
                string sql = "select 编号,号码 from tb_hetonghao1 where 号码=( select max(号码)from   tb_hetonghao1  where 用户名='" + yonghu + "' ) and 用户名='" + yonghu + "'";
                DataTable da = SQLhelp.GetDataTable(sql, CommandType.Text);
                string haoma = da.Rows[0][1].ToString();
                string bianhao = da.Rows[0][0].ToString();

                if (haoma.Length == 1)
                {
                    haoma = "000" + haoma;
                }
                if (haoma.Length == 2)
                {
                    haoma = "00" + haoma;
                }
                if (haoma.Length == 3)
                {
                    haoma = "0" + haoma;
                }
                string hetonghao = bianhao + haoma;

                string chaxun = "select * from tb_caigoutaizhang where 合同号='" + hetonghao + "'";
                DataTable dt2233 = SQLhelp.GetDataTable(chaxun, CommandType.Text);
                if (dt2233.Rows.Count == 0)
                {
                    string sql1112222 = "select * from tb_gongfang  where 单位名称='" + txtZerenren1.Text + "'";
                    DataTable dttt1 = SQLhelp.GetDataTable(sql1112222, CommandType.Text);
                    string sql112 = "insert into tb_caigoutaizhang (合同号,供方名称,银行账号,开户银行,银行行号,合同总价,采购员) values ('" + hetonghao + "','" + txtZerenren1.Text + "','" + dttt1.Rows[0]["帐号"].ToString() + "','" + dttt1.Rows[0]["开户银行"].ToString() + "','" + dttt1.Rows[0]["行号"].ToString() + "','" + zongjia1 + "','" + yonghu + "')";
                    SQLhelp.ExecuteScalar(sql112, CommandType.Text);

                }

                if (dt2233.Rows.Count != 0)
                {
                    string sql1112222 = "select * from tb_gongfang  where 单位名称='" + txtZerenren1.Text + "'";
                    DataTable dttt1 = SQLhelp.GetDataTable(sql1112222, CommandType.Text);
                    string sql112 = "update tb_caigoutaizhang set 供方名称='" + txtZerenren1.Text + "',银行账号='" + dttt1.Rows[0]["帐号"].ToString() + "',开户银行='" + dttt1.Rows[0]["开户银行"].ToString() + "',银行行号='" + dttt1.Rows[0]["行号"].ToString() + "',合同总价='" + zongjia1 + "',采购员='" + yonghu + "' where 合同号='" + txthetonghaobianhao.Text + "'";
                    SQLhelp.ExecuteScalar(sql112, CommandType.Text);

                }


                for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
                {
                    string id = Convert.ToString(dataGridViewX1.Rows[i].Cells["id"].Value);
                    string hetonghaoma = hetonghao;
                    string gongfangmingcheng = txtZerenren1.Text;
                    string caigoudanjia = Convert.ToString(dataGridViewX1.Rows[i].Cells["采购单价"].Value);
                    string shualiang = Convert.ToString(dataGridViewX1.Rows[i].Cells["实际采购数量"].Value);
                    string danwei = Convert.ToString(dataGridViewX1.Rows[i].Cells["单位"].Value);
                    string sql11 = "select 当前状态 from tb_caigouliaodan where id='" + id + "'";
                    string panduan = SQLhelp.ExecuteScalar(sql11, CommandType.Text).ToString();


                    string shuilv = comshuilv.Text.Replace("%", string.Empty);
                    double shuilv1 = Convert.ToDouble(shuilv) * 0.01;
                    decimal zongjia = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(dataGridViewX1.Rows[i].Cells["实际采购数量"].Value) * Convert.ToDouble(dataGridViewX1.Rows[i].Cells["采购单价"].Value))), 2);
                    decimal jinge = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(zongjia) / (1 + shuilv1))), 2);
                    decimal shuie = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(zongjia) - Convert.ToDouble(jinge))), 2);
                    decimal jingdanjia = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(dataGridViewX1.Rows[i].Cells["采购单价"].Value) / (1 + shuilv1))), 10);

                    string sql123 = "update  tb_caigouliaodan set 合同号='" + hetonghaoma + "',供方名称='" + gongfangmingcheng + "' where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql123, CommandType.Text);
                }
                MessageBox.Show("已自动匹配！");
            }





            if (zhonglei == "设备")
            {
                if (txtZerenren1.Text.Trim() == "")
                {
                    MessageBox.Show("请填写供应商名称！");
                    return;
                }
                if (zongjia1 == ""|| zongjia1 == "0")
                {
                    MessageBox.Show("请计算合同总价！");
                    return;
                }

                string sql111222 = "select * from tb_gongfang  where 单位名称='" + txtZerenren1.Text + "'";
                DataTable dttt = SQLhelp.GetDataTable(sql111222, CommandType.Text);
                if (dttt.Rows.Count == 0)
                {
                    MessageBox.Show("供应商名录没有此供应商，请添加！");
                    return;
                }
                if (comshuilv.Text == "")
                {
                    MessageBox.Show("请填写税率");
                    return;
                }
                for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
                {
                    string id = Convert.ToString(dataGridViewX1.Rows[i].Cells["id"].Value);
                    string sql1 = "select 发票匹配,名称,实际到货数量 from tb_caigouliaodan where id='" + id + "'";
                    DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                    if (Convert.ToString(dt.Rows[0]["发票匹配"]) != "")
                    {
                        string migncheng = dt.Rows[0]["名称"].ToString();
                        MessageBox.Show(migncheng + "已录入发票，无法再修改！");
                        return;
                    }
                    float a = 0;
                    if (float.TryParse(dataGridViewX1.Rows[i].Cells["采购单价"].Value.ToString(), out a) == false)
                    {
                        MessageBox.Show("其中有的采购单价写的不是数字，请重新填写！");
                        return;
                    }

                    if (Convert.ToString(dt.Rows[0]["实际到货数量"]) != "")
                    {
                        string migncheng = dt.Rows[0]["名称"].ToString();
                        MessageBox.Show(migncheng + "仓库已入库操作！无法修改");
                        return;
                    }
                }
                if (datehetong.Text.Trim() == "")
                {
                    MessageBox.Show("请填写合同到货时间！");
                    return;
                }
                for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
                {
                    string a = Convert.ToString(dataGridViewX1.Rows[i].Cells["实际采购数量"].Value);
                    if (a == "")
                    {
                        MessageBox.Show("请填数量！");
                        return;
                    }
                }

                if (txtgangfangfuzeren.Text.Trim() == "")
                {
                    MessageBox.Show("请先输入供方负责人名称！");
                   return;
                }
                if (comshuilv.Text == "")
                {
                    MessageBox.Show("请填写税率");
                    return;
                }
                if (txtgongfangfuzerendianhua.Text.Trim() == "")
                {
                    MessageBox.Show("请先输入供方负责人电话！");
                    return;
                }
                string sql = "select 编号,号码 from tb_hetonghao1 where 号码=( select max(号码)from   tb_hetonghao1  where 用户名='" + yonghu + "' ) and 用户名='" + yonghu + "'";
                DataTable da = SQLhelp.GetDataTable(sql, CommandType.Text);
                string haoma = da.Rows[0][1].ToString();
                string bianhao = da.Rows[0][0].ToString();

                if (haoma.Length == 1)
                {
                    haoma = "000" + haoma;
                }
                if (haoma.Length == 2)
                {
                    haoma = "00" + haoma;
                }
                if (haoma.Length == 3)
                {
                    haoma = "0" + haoma;
                }
                string hetonghao = bianhao + haoma;


                string chaxun = "select * from tb_caigoutaizhang where 合同号='" + hetonghao + "'";
                DataTable dt2233 = SQLhelp.GetDataTable(chaxun, CommandType.Text);
                if (dt2233.Rows.Count == 0)
                {
                    string sql1112222 = "select * from tb_gongfang  where 单位名称='" + txtZerenren1.Text + "'";
                    DataTable dttt1 = SQLhelp.GetDataTable(sql1112222, CommandType.Text);
                    string sql112 = "insert into tb_caigoutaizhang (合同号,供方名称,银行账号,开户银行,银行行号,合同总价,采购员) values ('" + hetonghao + "','" + txtZerenren1.Text + "','" + dttt1.Rows[0]["帐号"].ToString() + "','" + dttt1.Rows[0]["开户银行"].ToString() + "','" + dttt1.Rows[0]["行号"].ToString() + "','" + zongjia1 + "','" + yonghu + "')";
                    SQLhelp.ExecuteScalar(sql112, CommandType.Text);

                }

                if (dt2233.Rows.Count != 0)
                {
                    string sql1112222 = "select * from tb_gongfang  where 单位名称='" + txtZerenren1.Text + "'";
                    DataTable dttt1 = SQLhelp.GetDataTable(sql1112222, CommandType.Text);
                    string sql112 = "update tb_caigoutaizhang set 供方名称='" + txtZerenren1.Text + "',银行账号='" + dttt1.Rows[0]["帐号"].ToString() + "',开户银行='" + dttt1.Rows[0]["开户银行"].ToString() + "',银行行号='" + dttt1.Rows[0]["行号"].ToString() + "',合同总价='" + zongjia1 + "',采购员='" + yonghu + "' where 合同号='" + txthetonghaobianhao.Text + "'";
                    SQLhelp.ExecuteScalar(sql112, CommandType.Text);

                }


                for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
                {
                    string id = Convert.ToString(dataGridViewX1.Rows[i].Cells["id"].Value);
                    string hetonghaoma = hetonghao;
                    string gongfangmingcheng = txtZerenren1.Text;
                    string caigoudanjia = Convert.ToString(dataGridViewX1.Rows[i].Cells["采购单价"].Value);
                    string shualiang = Convert.ToString(dataGridViewX1.Rows[i].Cells["实际采购数量"].Value);
                    string danwei = Convert.ToString(dataGridViewX1.Rows[i].Cells["单位"].Value);
                    string sql11 = "select 当前状态 from tb_caigouliaodan where id='" + id + "'";
                    string panduan = SQLhelp.ExecuteScalar(sql11, CommandType.Text).ToString();


                    string shuilv = comshuilv.Text.Replace("%", string.Empty);
                    double shuilv1 = Convert.ToDouble(shuilv) * 0.01;
                    decimal zongjia = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(dataGridViewX1.Rows[i].Cells["实际采购数量"].Value) * Convert.ToDouble(dataGridViewX1.Rows[i].Cells["采购单价"].Value))), 2);
                    decimal jinge = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(zongjia) / (1 + shuilv1))), 2);
                    decimal shuie = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(zongjia) - Convert.ToDouble(jinge))), 2);
                    decimal jingdanjia = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(dataGridViewX1.Rows[i].Cells["采购单价"].Value) / (1 + shuilv1))), 10);

                    if (panduan == "9已到货" || panduan == "10已出库" || panduan == "已发货" || panduan == "已出库" || panduan == "已到货")
                    {
                        string sql123 = "update  tb_caigouliaodan set 合同号='" + hetonghaoma + "',供方名称='" + gongfangmingcheng + "',采购单价='" + caigoudanjia + "',合同预计时间='" + datehetong.Text + "',合同价='" + zongjia + "',生成合同时间='" + DateTime.Now + "',生产负责人电话='" + txtgongfangfuzerendianhua.Text.Trim() + "',生产负责人='" + txtgangfangfuzeren.Text.Trim() + "',实际采购数量='" + shualiang + "',总价预留= '" + zongjia + "',税率='" + comshuilv.Text + "',净单价='" + jingdanjia + "',采购单价预留='" + caigoudanjia + "',采购员='"+yonghu+"' where id='" + id + "'";
                        SQLhelp.ExecuteScalar(sql123, CommandType.Text);

                    }
                    if (panduan != "9已到货" && panduan != "10已出库" && panduan != "已发货" && panduan != "已出库" && panduan != "已到货")
                    {
                        string sql123 = "update  tb_caigouliaodan set 当前状态='5生产制作中',合同号='" + hetonghaoma + "',供方名称='" + gongfangmingcheng + "',采购单价='" + caigoudanjia + "',合同预计时间='" + datehetong.Text + "',合同价='" + zongjia + "',生成合同时间='" + DateTime.Now + "',生产负责人电话='" + txtgongfangfuzerendianhua.Text.Trim() + "',生产负责人='" + txtgangfangfuzeren.Text.Trim() + "',实际采购数量='" + shualiang + "',总价预留= '" + zongjia + "',税率='" + comshuilv.Text + "',净单价='" + jingdanjia + "',采购单价预留='" + caigoudanjia + "',采购员='" + yonghu + "'  where id='" + id + "'";
                        SQLhelp.ExecuteScalar(sql123, CommandType.Text);
                    }
                }
                MessageBox.Show("已自动匹配！");
            }
            if (zhonglei == "普通")
            {
                if (txtZerenren1.Text.Trim() == "")
                {
                    MessageBox.Show("请填写供应商名称！");
                    return;
                }
                if (comshuilv.Text == "")
                {
                    MessageBox.Show("请填写税率");
                    return;
                }

                string sql111222 = "select * from tb_gongfang  where 单位名称='" + txtZerenren1.Text + "'";
                DataTable dttt = SQLhelp.GetDataTable(sql111222, CommandType.Text);
                if (dttt.Rows.Count == 0)
                {
                    MessageBox.Show("供应商名录没有此供应商，请添加！");
                    return;
                }




                for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
                {
                    string id = Convert.ToString(dataGridViewX1.Rows[i].Cells["id"].Value);
                    string sql1 = "select 发票匹配,名称,实际到货数量 from tb_caigouliaodan where id='" + id + "'";
                    DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                    if (Convert.ToString(dt.Rows[0]["发票匹配"]) != "")
                    {
                        string migncheng = dt.Rows[0]["名称"].ToString();
                        MessageBox.Show(migncheng + "已录入发票，无法再修改！");
                        return;
                    }
                    float a = 0;
                    if (float.TryParse(dataGridViewX1.Rows[i].Cells["采购单价"].Value.ToString(), out a) == false)
                    {

                        MessageBox.Show("其中有的采购单价写的不是数字，请重新填写！");
                        return;

                    }

                    if (Convert.ToString(dt.Rows[0]["实际到货数量"]) != "")
                    {
                        string migncheng = dt.Rows[0]["名称"].ToString();
                        MessageBox.Show(migncheng + "仓库已入库操作！无法修改");
                        return;
                    }
                }
                for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
                {
                    string a = Convert.ToString(dataGridViewX1.Rows[i].Cells["实际采购数量"].Value);
                    if (a == "")
                    {
                        MessageBox.Show("请填数量！");
                        return;
                    }
                }
                if (datehetong.Text.Trim() == "")
                {
                    MessageBox.Show("请填写合同到货时间！");
                    return;


                }

                if (zongjia == 0)
                {
                    MessageBox.Show("请先计算总价！");
                    return;

                }

                if (txtgangfangfuzeren.Text.Trim() == "")
                {
                    MessageBox.Show("请先输入供方负责人名称！");
                    return;

                }

                if (txtgongfangfuzerendianhua.Text.Trim() == "")
                {
                    MessageBox.Show("请先输入供方负责人电话！");
                    return;

                }
                string sql = "select 编号,号码 from tb_hetonghao1 where 号码=( select max(号码)from   tb_hetonghao1  where 用户名='" + yonghu + "' ) and 用户名='" + yonghu + "'";
                DataTable da = SQLhelp.GetDataTable(sql, CommandType.Text);
                string haoma = da.Rows[0][1].ToString();
                string bianhao = da.Rows[0][0].ToString();

                if (haoma.Length == 1)
                {
                    haoma = "000" + haoma;
                }
                if (haoma.Length == 2)
                {
                    haoma = "00" + haoma;
                }
                if (haoma.Length == 3)
                {
                    haoma = "0" + haoma;
                }
                string hetonghao = bianhao + haoma;

                string chaxun = "select * from tb_caigoutaizhang where 合同号='" + hetonghao + "'";
                DataTable dt2233 = SQLhelp.GetDataTable(chaxun, CommandType.Text);
                if (dt2233.Rows.Count == 0)
                {
                    string sql1112222 = "select * from tb_gongfang  where 单位名称='" + txtZerenren1.Text + "'";
                    DataTable dttt1 = SQLhelp.GetDataTable(sql1112222, CommandType.Text);
                    string sql112 = "insert into tb_caigoutaizhang (合同号,供方名称,银行账号,开户银行,银行行号,合同总价,采购员) values ('" + hetonghao + "','" + txtZerenren1.Text + "','" + dttt1.Rows[0]["帐号"].ToString() + "','" + dttt1.Rows[0]["开户银行"].ToString() + "','" + dttt1.Rows[0]["行号"].ToString() + "','" + zongjia1 + "','" + yonghu + "')";
                    SQLhelp.ExecuteScalar(sql112, CommandType.Text);

                }

                if (dt2233.Rows.Count != 0)
                {
                    string sql1112222 = "select * from tb_gongfang  where 单位名称='" + txtZerenren1.Text + "'";
                    DataTable dttt1 = SQLhelp.GetDataTable(sql1112222, CommandType.Text);
                    string sql112 = "update tb_caigoutaizhang set 供方名称='" + txtZerenren1.Text + "',银行账号='" + dttt1.Rows[0]["帐号"].ToString() + "',开户银行='" + dttt1.Rows[0]["开户银行"].ToString() + "',银行行号='" + dttt1.Rows[0]["行号"].ToString() + "',合同总价='" + zongjia1 + "',采购员='" + yonghu + "' where 合同号='" + txthetonghaobianhao.Text + "'";
                    SQLhelp.ExecuteScalar(sql112, CommandType.Text);

                }
                for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
                {
                    string id = Convert.ToString(dataGridViewX1.Rows[i].Cells["id"].Value);
                    string hetonghaoma = hetonghao;
                    string gongfangmingcheng = txtZerenren1.Text;
                    string caigoudanjia = Convert.ToString(dataGridViewX1.Rows[i].Cells["采购单价"].Value);
                    string shualiang = Convert.ToString(dataGridViewX1.Rows[i].Cells["实际采购数量"].Value);
                    string danwei = Convert.ToString(dataGridViewX1.Rows[i].Cells["单位"].Value);
                    string sql11 = "select 当前状态 from tb_caigouliaodan where id='" + id + "'";
                    string panduan = SQLhelp.ExecuteScalar(sql11, CommandType.Text).ToString();


                    string shuilv = comshuilv.Text.Replace("%", string.Empty);
                    double shuilv1 = Convert.ToDouble(shuilv) * 0.01;
                    decimal zongjia = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(dataGridViewX1.Rows[i].Cells["实际采购数量"].Value) * Convert.ToDouble(dataGridViewX1.Rows[i].Cells["采购单价"].Value))), 2);
                    decimal jinge = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(zongjia) / (1 + shuilv1))), 2);
                    decimal shuie = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(zongjia) - Convert.ToDouble(jinge))), 2);
                    decimal jingdanjia = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(dataGridViewX1.Rows[i].Cells["采购单价"].Value) / (1 + shuilv1))), 10);


                    if (panduan == "9已到货" || panduan == "10已出库" || panduan == "已发货" || panduan == "已出库" || panduan == "已到货")
                    {
                        string sql123 = "update  tb_caigouliaodan set 合同号='" + hetonghaoma + "',供方名称='" + gongfangmingcheng + "',采购单价='" + caigoudanjia + "',合同预计时间='" + datehetong.Text + "',合同价='" + zongjia + "',生成合同时间='" + DateTime.Now + "',生产负责人电话='" + txtgongfangfuzerendianhua.Text.Trim() + "',生产负责人='" + txtgangfangfuzeren.Text.Trim() + "',实际采购数量='" + shualiang + "',总价预留= '" + zongjia + "',税率='" + comshuilv.Text + "',净单价='" + jingdanjia + "',采购单价预留='" + caigoudanjia + "',采购员='" + yonghu + "'  where id='" + id + "'";
                        SQLhelp.ExecuteScalar(sql123, CommandType.Text);


                    }
                    if (panduan != "9已到货" && panduan != "10已出库" && panduan != "已发货" && panduan != "已出库" && panduan != "已到货")
                    {
                        string sql123 = "update  tb_caigouliaodan set 当前状态='5生产制作中',合同号='" + hetonghaoma + "',供方名称='" + gongfangmingcheng + "',采购单价='" + caigoudanjia + "',合同预计时间='" + datehetong.Text + "',合同价='" + zongjia + "',生成合同时间='" + DateTime.Now + "',生产负责人电话='" + txtgongfangfuzerendianhua.Text.Trim() + "',生产负责人='" + txtgangfangfuzeren.Text.Trim() + "',实际采购数量='" + shualiang + "',总价预留= '" + zongjia + "',税率='" + comshuilv.Text + "',净单价='" + jingdanjia + "',采购单价预留='" + caigoudanjia + "',采购员='" + yonghu + "' where id='" + id + "'";
                        SQLhelp.ExecuteScalar(sql123, CommandType.Text);

                    }

                }
                MessageBox.Show("已自动匹配！");

            }
            if (zhonglei == "采购")
            {
                if (txtZerenren1.Text.Trim() == "")
                {
                    MessageBox.Show("请填写供应商名称！");
                    return;
                }
                if (comshuilv.Text == "")
                {
                    MessageBox.Show("请填写税率");
                    return;
                }

                string sql111222 = "select * from tb_gongfang  where 单位名称='" + txtZerenren1.Text + "'";
                DataTable dttt = SQLhelp.GetDataTable(sql111222, CommandType.Text);
                if (dttt.Rows.Count == 0)
                {
                    MessageBox.Show("供应商名录没有此供应商，请添加！");
                    return;
                }


                for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
                {
                    string id = Convert.ToString(dataGridViewX1.Rows[i].Cells["id"].Value);
                    string sql1 = "select 发票匹配,名称,实际到货数量 from tb_caigouliaodan where id='" + id + "'";
                    DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                    if (Convert.ToString(dt.Rows[0]["发票匹配"]) != "")
                    {
                        string migncheng = dt.Rows[0]["名称"].ToString();
                        MessageBox.Show(migncheng + "已录入发票，无法再修改！");
                        return;
                    }
                    float a = 0;
                    if (float.TryParse(dataGridViewX1.Rows[i].Cells["采购单价"].Value.ToString(), out a) == false)
                    {

                        MessageBox.Show("其中有的采购单价写的不是数字，请重新填写！");
                        return;
                    }
                    if (Convert.ToString(dt.Rows[0]["实际到货数量"]) != "")
                    {
                        string migncheng = dt.Rows[0]["名称"].ToString();
                        MessageBox.Show(migncheng + "仓库已入库操作！无法修改");
                        return;
                    }
                }
                for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
                {
                    string a = Convert.ToString(dataGridViewX1.Rows[i].Cells["实际采购数量"].Value);
                    if (a == "")
                    {
                        MessageBox.Show("请填数量！");
                        return;
                    }

                }
                if (datehetong.Text.Trim() == "")
                {
                    MessageBox.Show("请填写合同到货时间！");
                    return;
                }
                if (zongjia == 0)
                {
                    MessageBox.Show("请先计算总价！");
                    return;

                }

                if (txtgangfangfuzeren.Text.Trim() == "")
                {
                    MessageBox.Show("请先输入供方负责人名称！");
                    return;

                }

                if (txtgongfangfuzerendianhua.Text.Trim() == "")
                {
                    MessageBox.Show("请先输入供方负责人电话！");
                    return;

                }
                string sql = "select 编号,号码 from tb_hetonghao1 where 号码=( select max(号码)from   tb_hetonghao1  where 用户名='" + yonghu + "' ) and 用户名='" + yonghu + "'";
                DataTable da = SQLhelp.GetDataTable(sql, CommandType.Text);
                string haoma = da.Rows[0][1].ToString();
                string bianhao = da.Rows[0][0].ToString();

                if (haoma.Length == 1)
                {
                    haoma = "000" + haoma;
                }
                if (haoma.Length == 2)
                {
                    haoma = "00" + haoma;
                }
                if (haoma.Length == 3)
                {
                    haoma = "0" + haoma;
                }
                string hetonghao = bianhao + haoma;


                string chaxun = "select * from tb_caigoutaizhang where 合同号='" + hetonghao + "'";
                DataTable dt2233 = SQLhelp.GetDataTable(chaxun, CommandType.Text);
                if (dt2233.Rows.Count == 0)
                {
                    string sql1112222 = "select * from tb_gongfang  where 单位名称='" + txtZerenren1.Text + "'";
                    DataTable dttt1 = SQLhelp.GetDataTable(sql1112222, CommandType.Text);
                    string sql112 = "insert into tb_caigoutaizhang (合同号,供方名称,银行账号,开户银行,银行行号,合同总价,采购员) values ('" + hetonghao + "','" + txtZerenren1.Text + "','" + dttt1.Rows[0]["帐号"].ToString() + "','" + dttt1.Rows[0]["开户银行"].ToString() + "','" + dttt1.Rows[0]["行号"].ToString() + "','" + zongjia1 + "','" + yonghu + "')";
                    SQLhelp.ExecuteScalar(sql112, CommandType.Text);

                }

                if (dt2233.Rows.Count != 0)
                {
                    string sql1112222 = "select * from tb_gongfang  where 单位名称='" + txtZerenren1.Text + "'";
                    DataTable dttt1 = SQLhelp.GetDataTable(sql1112222, CommandType.Text);
                    string sql112 = "update tb_caigoutaizhang set 供方名称='" + txtZerenren1.Text + "',银行账号='" + dttt1.Rows[0]["帐号"].ToString() + "',开户银行='" + dttt1.Rows[0]["开户银行"].ToString() + "',银行行号='" + dttt1.Rows[0]["行号"].ToString() + "',合同总价='" + zongjia1 + "',采购员='" + yonghu + "' where 合同号='" + txthetonghaobianhao.Text + "'";
                    SQLhelp.ExecuteScalar(sql112, CommandType.Text);

                }
                
                for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
                {
                    string id = Convert.ToString(dataGridViewX1.Rows[i].Cells["id"].Value);
                    string hetonghaoma = hetonghao;
                    string gongfangmingcheng = txtZerenren1.Text;
                    string caigoudanjia = Convert.ToString(dataGridViewX1.Rows[i].Cells["采购单价"].Value);
                    string shualiang = Convert.ToString(dataGridViewX1.Rows[i].Cells["实际采购数量"].Value);
                    string danwei = Convert.ToString(dataGridViewX1.Rows[i].Cells["单位"].Value);
                    string sql11 = "select 当前状态 from tb_caigouliaodan where id='" + id + "'";
                    string panduan = SQLhelp.ExecuteScalar(sql11, CommandType.Text).ToString();


                    string shuilv = comshuilv.Text.Replace("%", string.Empty);
                    double shuilv1 = Convert.ToDouble(shuilv) * 0.01;
                    decimal zongjia = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(dataGridViewX1.Rows[i].Cells["实际采购数量"].Value) * Convert.ToDouble(dataGridViewX1.Rows[i].Cells["采购单价"].Value))), 2);
                    decimal jinge = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(zongjia) / (1 + shuilv1))), 2);
                    decimal shuie = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(zongjia) - Convert.ToDouble(jinge))), 2);
                    decimal jingdanjia = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(dataGridViewX1.Rows[i].Cells["采购单价"].Value) / (1 + shuilv1))), 10);


                    if (panduan == "9已到货" || panduan == "10已出库" || panduan == "已发货" || panduan == "已出库" || panduan == "已到货")
                    {
                        string sql123 = "update  tb_caigouliaodan set 合同号='" + hetonghaoma + "',供方名称='" + gongfangmingcheng + "',采购单价='" + caigoudanjia + "',合同预计时间='" + datehetong.Text + "',合同价='" + zongjia + "',生成合同时间='" + DateTime.Now + "',生产负责人电话='" + txtgongfangfuzerendianhua.Text.Trim() + "',生产负责人='" + txtgangfangfuzeren.Text.Trim() + "',实际采购数量='" + shualiang + "',总价预留= '" + zongjia + "',税率='" + comshuilv.Text + "',净单价='" + jingdanjia + "',采购单价预留='" + caigoudanjia + "',采购员='" + yonghu + "' where id='" + id + "'";
                        SQLhelp.ExecuteScalar(sql123, CommandType.Text);
                    }
                    if (panduan != "9已到货" && panduan != "10已出库" && panduan != "已发货" && panduan != "已出库" && panduan != "已到货")
                    {
                        string sql123 = "update  tb_caigouliaodan set 当前状态='5生产制作中',合同号='" + hetonghaoma + "',供方名称='" + gongfangmingcheng + "',采购单价='" + caigoudanjia + "',合同预计时间='" + datehetong.Text + "',合同价='" + zongjia + "',生成合同时间='" + DateTime.Now + "',生产负责人电话='" + txtgongfangfuzerendianhua.Text.Trim() + "',生产负责人='" + txtgangfangfuzeren.Text.Trim() + "',实际采购数量='" + shualiang + "',总价预留= '" + zongjia + "',税率='" + comshuilv.Text + "',净单价='" + jingdanjia + "',采购单价预留='" + caigoudanjia + "',采购员='" + yonghu + "' where id='" + id + "'";
                        SQLhelp.ExecuteScalar(sql123, CommandType.Text);
                    }
                }
                MessageBox.Show("已自动匹配！");
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                btnzidong.Enabled = false;
                btnzidingyi.Enabled = true;
                txthetonghaobianhao.Enabled = true;
            }
        }

        private void btnzidingyi_Click(object sender, EventArgs e)
        {
            if (zhonglei == "工序")
            {
                if (txtZerenren1.Text.Trim() == "")
                {
                    MessageBox.Show("请填写供应商名称！");
                    return;
                }
                if (zongjia1 == "" || zongjia1 == "0")
                {
                    MessageBox.Show("请计算合同总价！");
                    return;
                }

                string sql111222 = "select * from tb_gongfang  where 单位名称='" + txtZerenren1.Text + "'";
                DataTable dttt = SQLhelp.GetDataTable(sql111222, CommandType.Text);
                if (dttt.Rows.Count == 0)
                {
                    MessageBox.Show("供应商名录没有此供应商，请添加！");
                    return;
                }
                if (comshuilv.Text == "")
                {
                    MessageBox.Show("请填写税率");
                    return;
                }
                for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
                {
                    float a = 0;
                    if (float.TryParse(dataGridViewX1.Rows[i].Cells["采购单价"].Value.ToString(), out a) == false)
                    {
                        MessageBox.Show("其中有的采购单价写的不是数字，请重新填写！");
                        return;
                    }

                }
                if (datehetong.Text.Trim() == "")
                {
                    MessageBox.Show("请填写合同到货时间！");
                    return;
                }
                for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
                {
                    string a = Convert.ToString(dataGridViewX1.Rows[i].Cells["实际采购数量"].Value);
                    if (a == "")
                    {
                        MessageBox.Show("请填数量！");
                        return;
                    }
                }

                if (txtgangfangfuzeren.Text.Trim() == "")
                {
                    MessageBox.Show("请先输入供方负责人名称！");
                    return;
                }
                if (comshuilv.Text == "")
                {
                    MessageBox.Show("请填写税率");
                    return;
                }
                if (txtgongfangfuzerendianhua.Text.Trim() == "")
                {
                    MessageBox.Show("请先输入供方负责人电话！");
                    return;
                }
               
                string chaxun = "select * from tb_caigoutaizhang where 合同号='" + txthetonghaobianhao.Text + "'";
                DataTable dt2233 = SQLhelp.GetDataTable(chaxun, CommandType.Text);
                if (dt2233.Rows.Count == 0)
                {
                    string sql1112222 = "select * from tb_gongfang  where 单位名称='" + txtZerenren1.Text + "'";
                    DataTable dttt1 = SQLhelp.GetDataTable(sql1112222, CommandType.Text);
                    string sql112 = "insert into tb_caigoutaizhang (合同号,供方名称,银行账号,开户银行,银行行号,合同总价,采购员) values ('" + txthetonghaobianhao.Text + "','" + txtZerenren1.Text + "','" + dttt1.Rows[0]["帐号"].ToString() + "','" + dttt1.Rows[0]["开户银行"].ToString() + "','" + dttt1.Rows[0]["行号"].ToString() + "','" + zongjia1 + "','" + yonghu + "')";
                    SQLhelp.ExecuteScalar(sql112, CommandType.Text);

                }

                if (dt2233.Rows.Count != 0)
                {
                    string sql1112222 = "select * from tb_gongfang  where 单位名称='" + txtZerenren1.Text + "'";
                    DataTable dttt1 = SQLhelp.GetDataTable(sql1112222, CommandType.Text);
                    string sql112 = "update tb_caigoutaizhang set 供方名称='" + txtZerenren1.Text + "',银行账号='" + dttt1.Rows[0]["帐号"].ToString() + "',开户银行='" + dttt1.Rows[0]["开户银行"].ToString() + "',银行行号='" + dttt1.Rows[0]["行号"].ToString() + "',合同总价='" + zongjia1 + "',采购员='" + yonghu + "' where 合同号='" + txthetonghaobianhao.Text + "'";
                    SQLhelp.ExecuteScalar(sql112, CommandType.Text);

                }


                for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
                {
                    string id = Convert.ToString(dataGridViewX1.Rows[i].Cells["id"].Value);
                    string hetonghaoma = txthetonghaobianhao.Text;
                    string gongfangmingcheng = txtZerenren1.Text;
                    string caigoudanjia = Convert.ToString(dataGridViewX1.Rows[i].Cells["采购单价"].Value);
                    string shualiang = Convert.ToString(dataGridViewX1.Rows[i].Cells["实际采购数量"].Value);
                    string danwei = Convert.ToString(dataGridViewX1.Rows[i].Cells["单位"].Value);
                    string sql11 = "select 当前状态 from tb_caigouliaodan where id='" + id + "'";
                    string panduan = SQLhelp.ExecuteScalar(sql11, CommandType.Text).ToString();


                    string shuilv = comshuilv.Text.Replace("%", string.Empty);
                    double shuilv1 = Convert.ToDouble(shuilv) * 0.01;
                    decimal zongjia = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(dataGridViewX1.Rows[i].Cells["实际采购数量"].Value) * Convert.ToDouble(dataGridViewX1.Rows[i].Cells["采购单价"].Value))), 2);
                    decimal jinge = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(zongjia) / (1 + shuilv1))), 2);
                    decimal shuie = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(zongjia) - Convert.ToDouble(jinge))), 2);
                    decimal jingdanjia = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(dataGridViewX1.Rows[i].Cells["采购单价"].Value) / (1 + shuilv1))), 10);

                    string sql123 = "update  tb_caigouliaodan set 合同号='" + hetonghaoma + "',供方名称='" + gongfangmingcheng + "' where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql123, CommandType.Text);
                }
                MessageBox.Show("已自动匹配！");
            }
            if (zhonglei == "设备")
            {
                if (comshuilv.Text == "")
                {
                    MessageBox.Show("请填写税率");
                    return;
                }
                string sql111222 = "select * from tb_gongfang  where 单位名称='" + txtZerenren1.Text + "'";
                DataTable dttt = SQLhelp.GetDataTable(sql111222, CommandType.Text);
                if (dttt.Rows.Count == 0)
                {
                    MessageBox.Show("供应商名录没有此供应商，请添加！");
                    return;
                }
                for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
                {
                    string id = Convert.ToString(dataGridViewX1.Rows[i].Cells["id"].Value);
                    string sql = "select 发票匹配,名称,实际到货数量 from tb_caigouliaodan where id='" + id + "'";
                    DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
                    if (Convert.ToString(dt.Rows[0]["发票匹配"]) != "")
                    {
                        string migncheng = dt.Rows[0]["名称"].ToString();
                        MessageBox.Show(migncheng + "已录入发票，无法再修改！");
                        return;
                    }                    
                    float a = 0;
                    if (float.TryParse(dataGridViewX1.Rows[i].Cells["采购单价"].Value.ToString(), out a) == false)
                    {
                       MessageBox.Show("其中有的采购单价写的不是数字，请重新填写！");
                        return;
                    }
                    if (Convert.ToString(dt.Rows[0]["实际到货数量"]) != "")
                    {
                        string migncheng = dt.Rows[0]["名称"].ToString();
                        MessageBox.Show(migncheng + "仓库已入库操作！无法修改");
                        return;
                    }
                    
                }
                    if (txtZerenren1.Text.Trim() == "")
                {
                    MessageBox.Show("请填写供应商名称！");
                    return;
                }
                if (zongjia1== ""|| zongjia1 == "0")
                {
                    MessageBox.Show("请计算合同总价！");
                    return;
                }
                if (datehetong.Text.Trim() == "")
                {
                    MessageBox.Show("请填写合同到货时间！");
                   return;
                }
                if (txtgangfangfuzeren.Text.Trim() == "")
                {
                    MessageBox.Show("请先输入供方负责人名称！");
                    return;
                }
                if (txtgongfangfuzerendianhua.Text.Trim() == "")
                {
                    MessageBox.Show("请先输入供方负责人电话！");
                    return;
                }
                for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
                {
                    string a= Convert.ToString(dataGridViewX1.Rows[i].Cells["实际采购数量"].Value);
                    if(a=="")
                    {
                        MessageBox.Show("请填数量！");
                        return;
                    }
                }

                string chaxun = "select * from tb_caigoutaizhang where 合同号='" + txthetonghaobianhao.Text + "'";
                DataTable dt2233 = SQLhelp.GetDataTable(chaxun, CommandType.Text);
                if (dt2233.Rows.Count == 0)
                {
                    string sql1112222 = "select * from tb_gongfang  where 单位名称='" + txtZerenren1.Text + "'";
                    DataTable dttt1 = SQLhelp.GetDataTable(sql1112222, CommandType.Text);
                    string sql112 = "insert into tb_caigoutaizhang (合同号,供方名称,银行账号,开户银行,银行行号,合同总价,采购员) values ('" + txthetonghaobianhao.Text + "','" + txtZerenren1.Text + "','" + dttt1.Rows[0]["帐号"].ToString() + "','" + dttt1.Rows[0]["开户银行"].ToString() + "','" + dttt1.Rows[0]["行号"].ToString() + "','" + zongjia1 + "','" + yonghu + "')";
                    SQLhelp.ExecuteScalar(sql112, CommandType.Text);

                }

                if (dt2233.Rows.Count != 0)
                {
                    string sql1112222 = "select * from tb_gongfang  where 单位名称='" + txtZerenren1.Text + "'";
                    DataTable dttt1 = SQLhelp.GetDataTable(sql1112222, CommandType.Text);
                    string sql112 = "update tb_caigoutaizhang set 供方名称='" + txtZerenren1.Text + "',银行账号='" + dttt1.Rows[0]["帐号"].ToString() + "',开户银行='" + dttt1.Rows[0]["开户银行"].ToString() + "',银行行号='" + dttt1.Rows[0]["行号"].ToString() + "',合同总价='" + zongjia1 + "',采购员='" + yonghu + "' where 合同号='" + txthetonghaobianhao.Text + "'";
                    SQLhelp.ExecuteScalar(sql112, CommandType.Text);

                }
                for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
                {
                    string id = Convert.ToString(dataGridViewX1.Rows[i].Cells["id"].Value);
                    string hetonghaoma = txthetonghaobianhao.Text.Trim();
                    string gongfangmingcheng = txtZerenren1.Text;
                    string caigoudanjia = Convert.ToString(dataGridViewX1.Rows[i].Cells["采购单价"].Value);
                    string shualiang = Convert.ToString(dataGridViewX1.Rows[i].Cells["实际采购数量"].Value);
                    string danwei = Convert.ToString(dataGridViewX1.Rows[i].Cells["单位"].Value);
                    string sql11 = "select 当前状态 from tb_caigouliaodan where id='" + id + "'";
                    string panduan = SQLhelp.ExecuteScalar(sql11, CommandType.Text).ToString();

                    string shuilv = comshuilv.Text.Replace("%", string.Empty);
                    double shuilv1 = Convert.ToDouble(shuilv) * 0.01;
                    decimal zongjia = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(dataGridViewX1.Rows[i].Cells["实际采购数量"].Value) * Convert.ToDouble(dataGridViewX1.Rows[i].Cells["采购单价"].Value))), 2);
                    decimal jinge = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(zongjia) / (1+shuilv1))), 2);
                    decimal shuie = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(zongjia) - Convert.ToDouble(jinge))), 2);
                    decimal jingdanjia= decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(dataGridViewX1.Rows[i].Cells["采购单价"].Value)/ (1 + shuilv1))), 10);
                  
                    if (panduan == "9已到货" || panduan == "10已出库" || panduan == "已发货" || panduan == "已出库" || panduan == "已到货"  )
                    {
                        string sql123 = "update  tb_caigouliaodan set 合同号='" + hetonghaoma + "',供方名称='" + gongfangmingcheng + "',采购单价='" + caigoudanjia + "',合同预计时间='" + datehetong.Text + "',合同价='" + zongjia + "',生成合同时间='" + DateTime.Now + "',生产负责人电话='" + txtgongfangfuzerendianhua.Text.Trim() + "',生产负责人='" + txtgangfangfuzeren.Text.Trim() + "',实际采购数量='" + shualiang + "',总价预留= '" + zongjia + "',税率='"+comshuilv.Text+"',净单价='" + jingdanjia + "',采购单价预留='" + caigoudanjia + "',采购员='" + yonghu + "' where id='" + id + "'";
                        SQLhelp.ExecuteScalar(sql123, CommandType.Text);
                    }
                    if (panduan != "9已到货" && panduan != "10已出库" && panduan != "已发货" && panduan != "已出库" && panduan != "已到货")
                    {
                        string sql123 = "update  tb_caigouliaodan set 当前状态='5生产制作中',合同号='" + hetonghaoma + "',供方名称='" + gongfangmingcheng + "',采购单价='" + caigoudanjia + "',合同预计时间='" + datehetong.Text + "',合同价='" + zongjia + "',生成合同时间='" + DateTime.Now + "',生产负责人电话='" + txtgongfangfuzerendianhua.Text.Trim() + "',生产负责人='" + txtgangfangfuzeren.Text.Trim() + "',实际采购数量='" + shualiang + "',总价预留= '" + zongjia + "',税率='" + comshuilv.Text + "',净单价='" + jingdanjia + "',采购单价预留='" + caigoudanjia + "',采购员='" + yonghu + "'  where id='" + id + "'";
                        SQLhelp.ExecuteScalar(sql123, CommandType.Text);
                    }

                }
                MessageBox.Show("已自动匹配！");

            }
            if (zhonglei == "普通")
            {
                if (txtZerenren1.Text.Trim() == "")
                {
                    MessageBox.Show("请填写供应商名称！");
                    return;
                }
                if (comshuilv.Text == "")
                {
                    MessageBox.Show("请填写税率");
                    return;
                }
                if (zongjia1 == "" || zongjia1 == "0")
                {
                    MessageBox.Show("请计算合同总价！");
                    return;
                }
                for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
                {
                    string id = Convert.ToString(dataGridViewX1.Rows[i].Cells["id"].Value);
                    string sql = "select 发票匹配,名称,实际到货数量 from tb_caigouliaodan where id='" + id + "'";
                    DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
                    if (Convert.ToString(dt.Rows[0]["发票匹配"]) != "")
                    {
                        string migncheng = dt.Rows[0]["名称"].ToString();
                        MessageBox.Show(migncheng + "已录入发票，无法再修改！");
                        return;
                    }
                    float a = 0;
                    if (float.TryParse(dataGridViewX1.Rows[i].Cells["采购单价"].Value.ToString(), out a) == false)
                    {

                        MessageBox.Show("其中有的采购单价写的不是数字，请重新填写！");
                        return;

                    }

                    if (Convert.ToString(dt.Rows[0]["实际到货数量"]) != "")
                    {
                        string migncheng = dt.Rows[0]["名称"].ToString();
                        MessageBox.Show(migncheng + "仓库已入库操作！无法修改");
                        return;
                    }
                }
                if (txthetonghaobianhao.Text.Trim() == "")
                {
                    MessageBox.Show("请填写合同号！");
                    return;


                }
                if (datehetong.Text.Trim() == "")
                {
                    MessageBox.Show("请填写合同到货时间！");
                    return;


                }
                for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
                {
                    string a = Convert.ToString(dataGridViewX1.Rows[i].Cells["实际采购数量"].Value);
                    if (a == "")
                    {
                        MessageBox.Show("请填数量！");
                        return;
                    }
                }
                if (zongjia == 0)
                {
                    MessageBox.Show("请先计算总价！");
                    return;

                }

                if (txtgangfangfuzeren.Text.Trim() == "")
                {
                    MessageBox.Show("请先输入供方负责人名称！");
                    return;

                }

                if (txtgongfangfuzerendianhua.Text.Trim() == "")
                {
                    MessageBox.Show("请先输入供方负责人电话！");
                    return;

                }


                string chaxun = "select * from tb_caigoutaizhang where 合同号='" + txthetonghaobianhao.Text + "'";
                DataTable dt2233 = SQLhelp.GetDataTable(chaxun, CommandType.Text);
                if (dt2233.Rows.Count == 0)
                {
                    string sql1112222 = "select * from tb_gongfang  where 单位名称='" + txtZerenren1.Text + "'";
                    DataTable dttt1 = SQLhelp.GetDataTable(sql1112222, CommandType.Text);
                    string sql112 = "insert into tb_caigoutaizhang (合同号,供方名称,银行账号,开户银行,银行行号,合同总价,采购员) values ('" + txthetonghaobianhao.Text + "','" + txtZerenren1.Text + "','" + dttt1.Rows[0]["帐号"].ToString() + "','" + dttt1.Rows[0]["开户银行"].ToString() + "','" + dttt1.Rows[0]["行号"].ToString() + "','" + zongjia1 + "','" + yonghu + "')";
                    SQLhelp.ExecuteScalar(sql112, CommandType.Text);

                }

                if (dt2233.Rows.Count != 0)
                {
                    string sql1112222 = "select * from tb_gongfang  where 单位名称='" + txtZerenren1.Text + "'";
                    DataTable dttt1 = SQLhelp.GetDataTable(sql1112222, CommandType.Text);
                    string sql112 = "update tb_caigoutaizhang set 供方名称='" + txtZerenren1.Text + "',银行账号='" + dttt1.Rows[0]["帐号"].ToString() + "',开户银行='" + dttt1.Rows[0]["开户银行"].ToString() + "',银行行号='" + dttt1.Rows[0]["行号"].ToString() + "',合同总价='" + zongjia1 + "',采购员='" + yonghu + "' where 合同号='" + txthetonghaobianhao.Text + "'";
                    SQLhelp.ExecuteScalar(sql112, CommandType.Text);

                }
                for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
                {                
                    string id = Convert.ToString(dataGridViewX1.Rows[i].Cells["id"].Value);
                    string hetonghaoma = txthetonghaobianhao.Text.Trim();
                    string gongfangmingcheng = txtZerenren1.Text;
                    string caigoudanjia = Convert.ToString(dataGridViewX1.Rows[i].Cells["采购单价"].Value);
                    string sql11 = "select 当前状态 from tb_caigouliaodan where id='" + id + "'";
                    string shualiang = Convert.ToString(dataGridViewX1.Rows[i].Cells["实际采购数量"].Value);
                    string danwei = Convert.ToString(dataGridViewX1.Rows[i].Cells["单位"].Value);
                    string panduan = SQLhelp.ExecuteScalar(sql11, CommandType.Text).ToString();

                    string shuilv = comshuilv.Text.Replace("%", string.Empty);
                    double shuilv1 = Convert.ToDouble(shuilv) * 0.01;
                    decimal zongjia = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(dataGridViewX1.Rows[i].Cells["实际采购数量"].Value) * Convert.ToDouble(dataGridViewX1.Rows[i].Cells["采购单价"].Value))), 2);
                    decimal jinge = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(zongjia) / (1 + shuilv1))), 2);
                    decimal shuie = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(zongjia) - Convert.ToDouble(jinge))), 2);
                    decimal jingdanjia = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(dataGridViewX1.Rows[i].Cells["采购单价"].Value) / (1 + shuilv1))), 10);

                    if (panduan == "9已到货" || panduan == "10已出库" || panduan == "已发货" || panduan == "已出库" || panduan == "已到货")
                    {
                        string sql123 = "update  tb_caigouliaodan set 合同号='" + hetonghaoma + "',供方名称='" + gongfangmingcheng + "',采购单价='" + caigoudanjia + "',合同预计时间='" + datehetong.Text + "',合同价='" + zongjia + "',生成合同时间='" + DateTime.Now + "',生产负责人电话='" + txtgongfangfuzerendianhua.Text.Trim() + "',生产负责人='" + txtgangfangfuzeren.Text.Trim() + "',实际采购数量='" + shualiang + "',总价预留= '" + zongjia + "',税率='" + comshuilv.Text + "',净单价='" + jingdanjia + "',采购单价预留='" + caigoudanjia + "',采购员='" + yonghu + "' where id='" + id + "'";
                        SQLhelp.ExecuteScalar(sql123, CommandType.Text);
                    }
                    if (panduan != "9已到货" && panduan != "10已出库" && panduan != "已发货" && panduan != "已出库" && panduan != "已到货")
                    {
                        string sql123 = "update  tb_caigouliaodan set 当前状态='5生产制作中',合同号='" + hetonghaoma + "',供方名称='" + gongfangmingcheng + "',采购单价='" + caigoudanjia + "',合同预计时间='" + datehetong.Text + "',合同价='" + zongjia + "',生成合同时间='" + DateTime.Now + "',生产负责人电话='" + txtgongfangfuzerendianhua.Text.Trim() + "',生产负责人='" + txtgangfangfuzeren.Text.Trim() + "',实际采购数量='" + shualiang + "',总价预留= '" + zongjia + "',税率='" + comshuilv.Text + "',净单价='" + jingdanjia + "',采购单价预留='" + caigoudanjia + "',采购员='" + yonghu + "' where id='" + id + "'";
                        SQLhelp.ExecuteScalar(sql123, CommandType.Text);
                    }
                }
                MessageBox.Show("已自动匹配！");
            }
            if (zhonglei == "采购")
            {
                if (txtZerenren1.Text.Trim() == "")
                {
                    MessageBox.Show("请填写供应商名称！");
                    return;
                }
                if (comshuilv.Text == "")
                {
                    MessageBox.Show("请填写税率");
                    return;
                }
                for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
                {
                    string a = Convert.ToString(dataGridViewX1.Rows[i].Cells["实际采购数量"].Value);
                    if (a == "")
                    {
                        MessageBox.Show("请填数量！");
                        return;
                    }
                }
                for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
                {
                    string id = Convert.ToString(dataGridViewX1.Rows[i].Cells["id"].Value);
                    string sql = "select 发票匹配,名称,实际到货数量 from tb_caigouliaodan where id='" + id + "'";
                    DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
                    if (Convert.ToString(dt.Rows[0]["发票匹配"]) != "")
                    {
                        string migncheng = dt.Rows[0]["名称"].ToString();
                        MessageBox.Show(migncheng + "已录入发票，无法再修改！");
                        return;
                    }
                    float a = 0;
                    if (float.TryParse(dataGridViewX1.Rows[i].Cells["采购单价"].Value.ToString(), out a) == false)
                    {

                        MessageBox.Show("其中有的采购单价写的不是数字，请重新填写！");
                        return;
                    }
                    if (Convert.ToString(dt.Rows[0]["实际到货数量"]) != "")
                    {
                        string migncheng = dt.Rows[0]["名称"].ToString();
                        MessageBox.Show(migncheng + "仓库已入库操作！无法修改");
                        return;
                    }
                }
                if (txthetonghaobianhao.Text.Trim() == "")
                {
                    MessageBox.Show("请填写合同号！");
                    return;
                }
                if (datehetong.Text.Trim() == "")
                {
                    MessageBox.Show("请填写合同到货时间！");
                    return;
                }
                if (zongjia == 0)
                {
                    MessageBox.Show("请先计算总价！");
                    return;

                }

                if (txtgangfangfuzeren.Text.Trim() == "")
                {
                    MessageBox.Show("请先输入供方负责人名称！");
                    return;

                }

                if (txtgongfangfuzerendianhua.Text.Trim() == "")
                {
                    MessageBox.Show("请先输入供方负责人电话！");
                    return;

                }


                string chaxun = "select * from tb_caigoutaizhang where 合同号='" + txthetonghaobianhao.Text + "'";
                DataTable dt2233 = SQLhelp.GetDataTable(chaxun, CommandType.Text);
                if (dt2233.Rows.Count == 0)
                {
                    string sql1112222 = "select * from tb_gongfang  where 单位名称='" + txtZerenren1.Text + "'";
                    DataTable dttt1 = SQLhelp.GetDataTable(sql1112222, CommandType.Text);
                    string sql112 = "insert into tb_caigoutaizhang (合同号,供方名称,银行账号,开户银行,银行行号,合同总价,采购员) values ('" + txthetonghaobianhao.Text + "','" + txtZerenren1.Text + "','" + dttt1.Rows[0]["帐号"].ToString() + "','" + dttt1.Rows[0]["开户银行"].ToString() + "','" + dttt1.Rows[0]["行号"].ToString() + "','" + zongjia1 + "','" + yonghu + "')";
                    SQLhelp.ExecuteScalar(sql112, CommandType.Text);

                }

                if (dt2233.Rows.Count != 0)
                {
                    string sql1112222 = "select * from tb_gongfang  where 单位名称='" + txtZerenren1.Text + "'";
                    DataTable dttt1 = SQLhelp.GetDataTable(sql1112222, CommandType.Text);
                    string sql112 = "update tb_caigoutaizhang set 供方名称='" + txtZerenren1.Text + "',银行账号='" + dttt1.Rows[0]["帐号"].ToString() + "',开户银行='" + dttt1.Rows[0]["开户银行"].ToString() + "',银行行号='" + dttt1.Rows[0]["行号"].ToString() + "',合同总价='" + zongjia1 + "',采购员='" + yonghu + "' where 合同号='" + txthetonghaobianhao.Text + "'";
                    SQLhelp.ExecuteScalar(sql112, CommandType.Text);

                }

                for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
                {
                    string id = Convert.ToString(dataGridViewX1.Rows[i].Cells["id"].Value);
                    string hetonghaoma = txthetonghaobianhao.Text.Trim();
                    string gongfangmingcheng = txtZerenren1.Text;
                    string caigoudanjia = Convert.ToString(dataGridViewX1.Rows[i].Cells["采购单价"].Value);
                    string shualiang = Convert.ToString(dataGridViewX1.Rows[i].Cells["实际采购数量"].Value);
                    string danwei = Convert.ToString(dataGridViewX1.Rows[i].Cells["单位"].Value);
                    string sql11 = "select 当前状态 from tb_caigouliaodan where id='" + id + "'";
                    string panduan = SQLhelp.ExecuteScalar(sql11, CommandType.Text).ToString();

                    string shuilv = comshuilv.Text.Replace("%", string.Empty);
                    double shuilv1 = Convert.ToDouble(shuilv) * 0.01;
                    decimal zongjia = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(dataGridViewX1.Rows[i].Cells["实际采购数量"].Value) * Convert.ToDouble(dataGridViewX1.Rows[i].Cells["采购单价"].Value))), 2);
                    decimal jinge = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(zongjia) / (1 + shuilv1))), 2);
                    decimal shuie = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(zongjia) - Convert.ToDouble(jinge))), 2);
                    decimal jingdanjia = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(dataGridViewX1.Rows[i].Cells["采购单价"].Value) / (1 + shuilv1))), 10);
                    if (panduan == "9已到货" || panduan == "10已出库" || panduan == "已发货" || panduan == "已出库" || panduan == "已到货")
                    {
                        string sql123 = "update  tb_caigouliaodan set 合同号='" + hetonghaoma + "',供方名称='" + gongfangmingcheng + "',采购单价='" + caigoudanjia + "',合同预计时间='" + datehetong.Text + "',合同价='" + zongjia + "',生成合同时间='" + DateTime.Now + "',生产负责人电话='" + txtgongfangfuzerendianhua.Text.Trim() + "',生产负责人='" + txtgangfangfuzeren.Text.Trim() + "',实际采购数量='" + shualiang + "',总价预留= '" + zongjia + "',税率='" + comshuilv.Text + "',净单价='" + jingdanjia + "',采购单价预留='" + caigoudanjia + "',采购员='" + yonghu + "' where id='" + id + "'";
                        SQLhelp.ExecuteScalar(sql123, CommandType.Text);
                    }
                    if (panduan != "9已到货" && panduan != "10已出库" && panduan != "已发货" && panduan != "已出库" && panduan != "已到货")
                    {
                        string sql123 = "update  tb_caigouliaodan set 当前状态='5生产制作中',合同号='" + hetonghaoma + "',供方名称='" + gongfangmingcheng + "',采购单价='" + caigoudanjia + "',合同预计时间='" + datehetong.Text + "',合同价='" + zongjia + "',生成合同时间='" + DateTime.Now + "',生产负责人电话='" + txtgongfangfuzerendianhua.Text.Trim() + "',生产负责人='" + txtgangfangfuzeren.Text.Trim() + "',实际采购数量='" + shualiang + "',总价预留= '" + zongjia + "',税率='" + comshuilv.Text + "',净单价='" + jingdanjia + "',采购单价预留='" + caigoudanjia + "',采购员='" + yonghu + "' where id='" + id + "'";
                        SQLhelp.ExecuteScalar(sql123, CommandType.Text);
                    }
                }
                MessageBox.Show("已自动匹配！");
            }
        }

        private void Frhetongmoban_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void 匹配单价ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
            {
                string mingcheng = dataGridViewX1.Rows[i].Cells["编码"].Value.ToString();
                string id = dataGridViewX1.Rows[i].Cells["id"].Value.ToString();


                string sql = "select 采购单价 from tb_caigouliaodan where 编码='" + mingcheng + "'";

                dataGridViewX1.Rows[i].Cells["采购单价"].Value = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Frhetongmoban_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        /// <summary>
        /// 数字转大写金额
        /// </summary>
        /// <param name="LowerMoney"></param>
        /// <returns></returns>
        private string MoneyToChinese(string LowerMoney)
        {
          
            string functionReturnValue = null;
            bool IsNegative = false; // 是否是负数
            if (LowerMoney.Trim().Substring(0, 1) == "-")
            {
                // 是负数则先转为正数
                LowerMoney = LowerMoney.Trim().Remove(0, 1);
                IsNegative = true;
            }
            string strLower = null;
            string strUpart = null;
            string strUpper = null;
            int iTemp = 0;
            // 保留两位小数 123.489→123.49　　123.4→123.4
            LowerMoney = Math.Round(double.Parse(LowerMoney), 2).ToString();
            if (LowerMoney.IndexOf(".") > 0)
            {
                if (LowerMoney.IndexOf(".") == LowerMoney.Length - 2)
                {
                    LowerMoney = LowerMoney + "0";
                }
            }
            else
            {
                LowerMoney = LowerMoney + ".00";
            }
            strLower = LowerMoney;
            iTemp = 1;
            strUpper = "";
            while (iTemp <= strLower.Length)
            {
                switch (strLower.Substring(strLower.Length - iTemp, 1))
                {
                    case ".":
                        strUpart = "圆";
                        break;
                    case "0":
                        strUpart = "零";
                        break;
                    case "1":
                        strUpart = "壹";
                        break;
                    case "2":
                        strUpart = "贰";
                        break;
                    case "3":
                        strUpart = "叁";
                        break;
                    case "4":
                        strUpart = "肆";
                        break;
                    case "5":
                        strUpart = "伍";
                        break;
                    case "6":
                        strUpart = "陆";
                        break;
                    case "7":
                        strUpart = "柒";
                        break;
                    case "8":
                        strUpart = "捌";
                        break;
                    case "9":
                        strUpart = "玖";
                        break;
                }

                switch (iTemp)
                {
                    case 1:
                        strUpart = strUpart + "分";
                        break;
                    case 2:
                        strUpart = strUpart + "角";
                        break;
                    case 3:
                        strUpart = strUpart + "";
                        break;
                    case 4:
                        strUpart = strUpart + "";
                        break;
                    case 5:
                        strUpart = strUpart + "拾";
                        break;
                    case 6:
                        strUpart = strUpart + "佰";
                        break;
                    case 7:
                        strUpart = strUpart + "仟";
                        break;
                    case 8:
                        strUpart = strUpart + "万";
                        break;
                    case 9:
                        strUpart = strUpart + "拾";
                        break;
                    case 10:
                        strUpart = strUpart + "佰";
                        break;
                    case 11:
                        strUpart = strUpart + "仟";
                        break;
                    case 12:
                        strUpart = strUpart + "亿";
                        break;
                    case 13:
                        strUpart = strUpart + "拾";
                        break;
                    case 14:
                        strUpart = strUpart + "佰";
                        break;
                    case 15:
                        strUpart = strUpart + "仟";
                        break;
                    case 16:
                        strUpart = strUpart + "万";
                        break;
                    default:
                        strUpart = strUpart + "";
                        break;
                }

                strUpper = strUpart + strUpper;
                iTemp = iTemp + 1;
            }

            strUpper = strUpper.Replace("零拾", "零");
            strUpper = strUpper.Replace("零佰", "零");
            strUpper = strUpper.Replace("零仟", "零");
            strUpper = strUpper.Replace("零零零", "零");
            strUpper = strUpper.Replace("零零", "零");
            strUpper = strUpper.Replace("零角零分", "整");
            strUpper = strUpper.Replace("零分", "整");
            strUpper = strUpper.Replace("零角", "零");
            strUpper = strUpper.Replace("零亿零万零圆", "亿圆");
            strUpper = strUpper.Replace("亿零万零圆", "亿圆");
            strUpper = strUpper.Replace("零亿零万", "亿");
            strUpper = strUpper.Replace("零万零圆", "万圆");
            strUpper = strUpper.Replace("零亿", "亿");
            strUpper = strUpper.Replace("零万", "万");
            strUpper = strUpper.Replace("零圆", "圆");
            strUpper = strUpper.Replace("零零", "零");

            // 对壹圆以下的金额的处理
            if (strUpper.Substring(0, 1) == "圆")
            {
                strUpper = strUpper.Substring(1, strUpper.Length - 1);
            }
            if (strUpper.Substring(0, 1) == "零")
            {
                strUpper = strUpper.Substring(1, strUpper.Length - 1);
            }
            if (strUpper.Substring(0, 1) == "角")
            {
                strUpper = strUpper.Substring(1, strUpper.Length - 1);
            }
            if (strUpper.Substring(0, 1) == "分")
            {
                strUpper = strUpper.Substring(1, strUpper.Length - 1);
            }
            if (strUpper.Substring(0, 1) == "整")
            {
                strUpper = "零圆整";
            }
            functionReturnValue = strUpper;

            if (IsNegative == true)
            {
                return "负" + functionReturnValue;
            }
            else
            {
                return functionReturnValue;
            }
        }
        private string shengchennianyueri(string daohuoriqi )
        {

           string[] a=daohuoriqi.Split('/');
            string b = a[0]+"年"+a[1]+"月"+a[2]+"日";
            return b;
        }
    }
}

