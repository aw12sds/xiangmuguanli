using Aspose.Words;
using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.物流部
{
    public partial class Frxunjia : Office2007Form
    {
        public Frxunjia()
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
        public string qingdan;
        public string zhonglei;
        private void Frxunjia_Load(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = dt;
        }

        private void txtZerenren1_TextChanged(object sender, EventArgs e)
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
                this.txtZerenren1.SelectionStart = this.txtZerenren1.TextLength;
                listBox1.Visible = false;//隐藏这个控件

            }
            if (i != -1)
            {
                string jiequ = txtZerenren1.Text.Substring(0, i + 1);

                txtZerenren1.Text = jiequ + this.listBox1.SelectedItem.ToString() + ";";
                this.txtZerenren1.SelectionStart = this.txtZerenren1.TextLength;
                listBox1.Visible = false;//隐藏这个控件
            }
        }

        private void txtZerenren1_KeyUp(object sender, KeyEventArgs e)
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
                    this.txtZerenren1.SelectionStart = this.txtZerenren1.TextLength;
                    listBox1.Visible = false;//隐藏这个控件

                }
                if (i != -1)
                {
                    string jiequ = txtZerenren1.Text.Substring(0, i + 1);

                    txtZerenren1.Text = jiequ + this.listBox1.SelectedItem.ToString() + ";";
                    this.txtZerenren1.SelectionStart = this.txtZerenren1.TextLength;
                    listBox1.Visible = false;//隐藏这个控件

                }
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (txtZerenren1.Text.Trim() == "")
            {
                MessageBox.Show("请填写供应商名称！");
                return;

            }

            if (dateTimeInput1.Text.Trim() == "")
            {
                MessageBox.Show("请填写交货期！");
                return;

            }

            DataTable dt1 = new DataTable();


            //"yyyy年MM月dd日"
            DateTime a = DateTime.Now;
            DateTime b = a.AddDays(3);
            DateTime c = a.AddDays(33);
            string qiandingshijian = b.ToString("yyyy年MM月dd日");
            string jiaohuoriqi = c.ToString("yyyy年MM月dd日");
            string qiandingyifang = txtZerenren1.Text.Trim();
            string heji = zongjia1;

            string sql1 = "select 单位名称,单位地址,法定代表人,委托代理人,电话,传真,税务登记号,开户银行,帐号,邮箱 from tb_gongfang where 单位名称='" + txtZerenren1.Text.Trim() + "'";
            DataTable daa = SQLhelp.GetDataTable(sql1, CommandType.Text);


            string weituodailiren = daa.Rows[0][3].ToString();
            string dianhua = daa.Rows[0][4].ToString();
            string chuanzhen = daa.Rows[0][5].ToString();
            string youxiang = daa.Rows[0][9].ToString();


            string sql12 = "select 电话  from tb_operator1 where 用户名='" + yonghu + "'";
            string caigoudianhua = Convert.ToString(SQLhelp.ExecuteScalar(sql12, CommandType.Text));


            dt1.Columns.Add("传真", typeof(string));
            dt1.Columns.Add("时间", typeof(string));
            dt1.Columns.Add("公司", typeof(string));
            dt1.Columns.Add("合计", typeof(string));
            dt1.Columns.Add("电话", typeof(string));
            dt1.Columns.Add("联系人", typeof(string));
            dt1.Columns.Add("联系方式", typeof(string));
            dt1.Columns.Add("邮箱", typeof(string));
            dt1.Columns.Add("采购负责人", typeof(string));

            for (int i = 0; i < 200; i++)
            {
                dt1.Columns.Add("单位" + (i + 1), typeof(string));
                dt1.Columns.Add("交货期" + (i + 1), typeof(string));
                dt1.Columns.Add("产品名称" + (i + 1), typeof(string));
                dt1.Columns.Add("规格型号" + (i + 1), typeof(string));
                dt1.Columns.Add("数量" + (i + 1), typeof(string));
                dt1.Columns.Add("单价" + (i + 1), typeof(string));
                dt1.Columns.Add("备注" + (i + 1), typeof(string));
                dt1.Columns.Add("类型" + (i + 1), typeof(string));
                dt1.Columns.Add("总金额" + (i + 1), typeof(string));
                dt1.Columns.Add("序号" + (i + 1), typeof(string));
            }
            DataRow dr1 = dt1.NewRow();

            for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
            {

                if (dataGridViewX1.Rows[i].Cells["名称"].Value == null)
                {
                    dr1["产品名称" + (i + 1)] = "";
                }
                if (dataGridViewX1.Rows[i].Cells["名称"].Value != null)
                {
                    dr1["产品名称" + (i + 1)] = dataGridViewX1.Rows[i].Cells["名称"].Value.ToString();
                    dr1["序号" + (i + 1)] = i + 1;
                    dr1["交货期" + (i + 1)] = dateTimeInput1.Value.ToString("yyyy年MM月dd日"); ;
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

                if (dataGridViewX1.Rows[i].Cells["备注"].Value == null)
                {
                    dr1["备注" + (i + 1)] = "";
                }

                if (dataGridViewX1.Rows[i].Cells["备注"].Value != null)
                {
                    dr1["备注" + (i + 1)] = dataGridViewX1.Rows[i].Cells["备注"].Value.ToString();
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

            string sql = "select 电话 from tb_operator1 where 用户名='" + yonghu + "'";
            string dianhua1 = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();


            dr1["时间"] = DateTime.Now.ToString("yyyy年MM月dd日"); ;
            dr1["合计"] = heji;
            dr1["公司"] = txtZerenren1.Text;
            dr1["联系人"] = weituodailiren;
            dr1["电话"] = dianhua;
            dr1["传真"] = chuanzhen;
            dr1["联系方式"] = dianhua1;
            dr1["采购负责人"] = yonghu;
            dr1["邮箱"] = youxiang;

            dt1.Rows.Add(dr1);

            string tempFile = Application.StartupPath + "\\询价表.doc";
            Document doc = new Document(tempFile);
            DocumentBuilder builder = new DocumentBuilder(doc);
            NodeCollection allTables = doc.GetChildNodes(NodeType.Table, true);

            Dictionary<string, string> dic = new Dictionary<string, string>();
            DataRow dr = dt1.Rows[0];



            dic.Add("时间", dr["时间"].ToString());
            dic.Add("合计", dr["合计"].ToString());
            dic.Add("公司", dr["公司"].ToString());
            dic.Add("联系人", dr["联系人"].ToString());
            dic.Add("电话", dr["电话"].ToString());
            dic.Add("联系方式", dr["联系方式"].ToString());
            dic.Add("传真", dr["传真"].ToString());
            dic.Add("采购负责人", dr["采购负责人"].ToString());
            dic.Add("邮箱", dr["邮箱"].ToString());

            for (int i = 0; i < 200; i++)
            {
                dic.Add("单位" + (i + 1), dr["单位" + (i + 1)].ToString());
            }
            for (int i = 0; i < 200; i++)
            {
                dic.Add("产品名称" + (i + 1), dr["产品名称" + (i + 1)].ToString());
            }
            for (int i = 0; i < 200; i++)
            {
                dic.Add("规格型号" + (i + 1), dr["规格型号" + (i + 1)].ToString());
            }

            for (int i = 0; i < 200; i++)
            {
                dic.Add("数量" + (i + 1), dr["数量" + (i + 1)].ToString());
            }
            for (int i = 0; i < 200; i++)
            {
                dic.Add("单价" + (i + 1), dr["单价" + (i + 1)].ToString());
            }
            for (int i = 0; i < 200; i++)
            {
                dic.Add("总金额" + (i + 1), dr["总金额" + (i + 1)].ToString());
            }
            for (int i = 0; i < 200; i++)
            {
                dic.Add("交货期" + (i + 1), dr["交货期" + (i + 1)].ToString());
            }
            for (int i = 0; i < 200; i++)
            {
                dic.Add("序号" + (i + 1), dr["序号" + (i + 1)].ToString());
            }
            for (int i = 0; i < 200; i++)
            {
                dic.Add("备注" + (i + 1), dr["备注" + (i + 1)].ToString());
            }
            for (int i = 0; i < 200; i++)
            {
                dic.Add("类型" + (i + 1), dr["类型" + (i + 1)].ToString());
            }

            foreach (var key in dic.Keys)
            {
                builder.MoveToBookmark(key);
                builder.Write(dic[key]);
            }
            Random suiji = new Random();
            int n = suiji.Next(0, 1000);
            string mingcheng = yonghu + DateTime.Now.ToString("yyyy-MM-dd") + "询价表" + n + ".doc";
            FileInfo info1 = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\" + mingcheng);
            string fileName11 = info1.Name.ToString();
            string floderName = fileName11.Substring(0, fileName11.Length - 4).ToString();
            doc.Save(info1.DirectoryName + "\\" + fileName11);
            string pathfilesave = info1.DirectoryName + "\\" + mingcheng;
            MessageBox.Show("已保存到桌面！");
            System.Diagnostics.Process.Start(pathfilesave);
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
                    dt.Rows[i]["总价"] = zuizhong;

                }
                if (Convert.ToString(dataGridViewX1.Rows[i].Cells["采购单价"].Value) == "")
                {
                    dt.Rows[i]["总价"] = 0;

                }

            }

            dataGridViewX1.DataSource = dt;



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

        private void btnzidong_Click(object sender, EventArgs e)
        {
            if (txtZerenren1.Text.Trim() == "")
            {
                MessageBox.Show("请填写供应商名称！");
                return;
                
            }
            if (txtbiaoji.Text.Trim() == "")
            {
                MessageBox.Show("请输入询价标记，方便后期直接生成合同！");
                return;

            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string id = Convert.ToString(dt.Rows[i]["id"]);
             
                string sql123 = "update  tb_caigouliaodan set 当前状态='1询比价', 询价时间='"+DateTime.Now+ "',询价标记='"+txtbiaoji.Text.Trim()+"'  where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql123, CommandType.Text);

            }
            MessageBox.Show("已自动匹配！");
        }

        private void Frxunjia_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
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
    }

}
