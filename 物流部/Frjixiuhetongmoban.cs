using Aspose.Words;
using Aspose.Words.Drawing;
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
using ThoughtWorks.QRCode.Codec;

namespace 项目管理系统.物流部
{
    public partial class Frjixiuhetongmoban : Office2007Form
    {
        public Frjixiuhetongmoban()
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
        private void Frjixiuhetongmoban_Load(object sender, EventArgs e)
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

        private void btnzidong_Click(object sender, EventArgs e)
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
                string hetonghaoma = txthetonghaobianhao.Text.Trim();
                string gongfangmingcheng = txtZerenren1.Text;
                string caigoudanjia = Convert.ToString(dataGridViewX1.Rows[i].Cells["采购单价"].Value);
                string erp = Convert.ToString(dataGridViewX1.Rows[i].Cells["编码"].Value);
                string shualiang = Convert.ToString(dataGridViewX1.Rows[i].Cells["实际采购数量"].Value);

                string sql1 = "select 发票匹配,名称,实际到货数量 from tb_caigouliaodan where id='" + id + "'";
                DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                if (Convert.ToString(dt.Rows[0]["发票匹配"]) != "")
                {
                    string migncheng = dt.Rows[0]["名称"].ToString();
                    MessageBox.Show(migncheng + "已录入发票，无法再修改！");
                    return;
                }
                if (Convert.ToString(dt.Rows[0]["实际到货数量"]) != "")
                {
                    string migncheng = dt.Rows[0]["名称"].ToString();
                    MessageBox.Show(migncheng + "仓库已入库操作！无法修改");
                    return;
                }
                float a = 0;
                if (float.TryParse(dataGridViewX1.Rows[i].Cells["采购单价"].Value.ToString(), out a) == false)
                {

                    MessageBox.Show("其中有的采购单价写的不是数字，请重新填写！");
                    return;

                }

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
                string shuliang = Convert.ToString(dataGridViewX1.Rows[i].Cells["实际采购数量"].Value);
                string sql1 = "select 收到发票日期,名称 from tb_caigouliaodan where id='" + id + "'";
                DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                if (Convert.ToString(dt.Rows[0]["收到发票日期"]) != "")
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
                    string sql123 = "update  tb_caigouliaodan set 合同号='" + hetonghaoma + "',供方名称='" + gongfangmingcheng + "',采购单价='" + caigoudanjia + "',合同预计时间='" + datehetong.Text + "',合同价='" + zongjia + "',生成合同时间='" + DateTime.Now + "',生产负责人电话='" + txtgongfangfuzerendianhua.Text.Trim() + "',生产负责人='" + txtgangfangfuzeren.Text.Trim() + "' ,总价='" + zongjia + "',总价预留= '" + zongjia + "',税率='" + comshuilv.Text + "',净税额='" + shuie + "',净额='" + jinge + "',净单价='" + jingdanjia + "',采购单价预留='" + caigoudanjia + "' where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql123, CommandType.Text);
                }
                if (panduan != "9已到货" && panduan != "10已出库" && panduan != "已发货" && panduan != "已出库" && panduan != "已到货")
                {
                    string sql123 = "update  tb_caigouliaodan set 当前状态='5生产制作中',合同号='" + hetonghaoma + "',供方名称='" + gongfangmingcheng + "',采购单价='" + caigoudanjia + "',合同预计时间='" + datehetong.Text + "',合同价='" + zongjia + "',生成合同时间='" + DateTime.Now + "',生产负责人电话='" + txtgongfangfuzerendianhua.Text.Trim() + "',生产负责人='" + txtgangfangfuzeren.Text.Trim() + "' ,单位= '个',总价='" + zongjia + "',总价预留= '" + zongjia + "',税率='" + comshuilv.Text + "',净税额='" + shuie + "',净额='" + jinge + "',净单价='" + jingdanjia + "',采购单价预留='" + caigoudanjia + "' where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql123, CommandType.Text);
                }
            }
            MessageBox.Show("已自动匹配！");           
        }

        private void btnzidingyi_Click(object sender, EventArgs e)
        {
            if (comshuilv.Text == "")
            {
                MessageBox.Show("请填写税率");
                return;
            }

            if (txtZerenren1.Text.Trim() == "")
            {
                MessageBox.Show("请填写供应商名称！");
                return;

            }
            string sql111222 = "select * from tb_gongfang  where 单位名称='" + txtZerenren1.Text + "'";
            DataTable dttt = SQLhelp.GetDataTable(sql111222, CommandType.Text);
            if (dttt.Rows.Count == 0)
            {
                MessageBox.Show("供应商名录没有此供应商，请添加！");
                return;
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
                string erp = Convert.ToString(dataGridViewX1.Rows[i].Cells["编码"].Value);
                string shualiang = Convert.ToString(dataGridViewX1.Rows[i].Cells["实际采购数量"].Value);

                string sql = "select 发票匹配,名称,实际到货数量 from tb_caigouliaodan where id='" + id + "'";
                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                if (Convert.ToString(dt.Rows[0]["发票匹配"]) != "")
                {
                    string migncheng = dt.Rows[0]["名称"].ToString();
                    MessageBox.Show(migncheng + "已录入发票，无法再修改！");
                    return;
                }
                if (Convert.ToString(dt.Rows[0]["实际到货数量"]) != "")
                {
                    string migncheng = dt.Rows[0]["名称"].ToString();
                    MessageBox.Show(migncheng + "仓库已入库操作！无法修改");
                    return;
                }
                float a = 0;
                if (float.TryParse(dataGridViewX1.Rows[i].Cells["采购单价"].Value.ToString(), out a) == false)
                {

                    MessageBox.Show("其中有的采购单价写的不是数字，请重新填写！");
                    return;
                }

            }
                for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
            {
                string id = Convert.ToString(dataGridViewX1.Rows[i].Cells["id"].Value);
                string hetonghaoma = txthetonghaobianhao.Text.Trim();
                string gongfangmingcheng = txtZerenren1.Text;
                string caigoudanjia = Convert.ToString(dataGridViewX1.Rows[i].Cells["采购单价"].Value);
                string erp = Convert.ToString(dataGridViewX1.Rows[i].Cells["编码"].Value);
                string shualiang = Convert.ToString(dataGridViewX1.Rows[i].Cells["实际采购数量"].Value);


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
                    string sql123 = "update  tb_caigouliaodan set 合同号='" + hetonghaoma + "',供方名称='" + gongfangmingcheng + "',采购单价='" + caigoudanjia + "',合同预计时间='" + datehetong.Text + "',合同价='" + zongjia + "',生成合同时间='" + DateTime.Now + "',生产负责人电话='" + txtgongfangfuzerendianhua.Text.Trim() + "',生产负责人='" + txtgangfangfuzeren.Text.Trim() + "',总价预留= '" + zongjia + "',单位= '个',税率='" + comshuilv.Text + "',净单价='" + jingdanjia + "',采购单价预留='" + caigoudanjia + "'  where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql123, CommandType.Text);
                }
                if (panduan != "9已到货" && panduan != "10已出库" && panduan != "已发货" && panduan != "已出库" && panduan != "已到货")
                {
                    string sql123 = "update  tb_caigouliaodan set 当前状态='5生产制作中',合同号='" + hetonghaoma + "',供方名称='" + gongfangmingcheng + "',采购单价='" + caigoudanjia + "',合同预计时间='" + datehetong.Text + "',合同价='" + zongjia + "',生成合同时间='" + DateTime.Now + "',生产负责人电话='" + txtgongfangfuzerendianhua.Text.Trim() + "',生产负责人='" + txtgangfangfuzeren.Text.Trim() + "',单位= '个',总价预留= '" + zongjia + "',税率='" + comshuilv.Text + "',净单价='" + jingdanjia + "',采购单价预留='" + caigoudanjia + "'  where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql123, CommandType.Text);
                }
            }
            MessageBox.Show("已自动匹配！");

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

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                btnzidong.Enabled = false;
                btnzidingyi.Enabled = true;
                txthetonghaobianhao.Enabled = true;
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
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (zhonglei == "普通")
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

                dt1.Columns.Add("单位1", typeof(string));
                dt1.Columns.Add("单位2", typeof(string));
                dt1.Columns.Add("单位3", typeof(string));
                dt1.Columns.Add("单位4", typeof(string));
                dt1.Columns.Add("单位5", typeof(string));
                dt1.Columns.Add("单位6", typeof(string));
                dt1.Columns.Add("单位7", typeof(string));
                dt1.Columns.Add("单位8", typeof(string));
                dt1.Columns.Add("单位9", typeof(string));
                dt1.Columns.Add("单位10", typeof(string));
                dt1.Columns.Add("单位11", typeof(string));
                dt1.Columns.Add("单位12", typeof(string));
                dt1.Columns.Add("单位13", typeof(string));
                dt1.Columns.Add("单位14", typeof(string));
                dt1.Columns.Add("单位15", typeof(string));
                dt1.Columns.Add("单位16", typeof(string));
                dt1.Columns.Add("单位17", typeof(string));
                dt1.Columns.Add("单位18", typeof(string));
                dt1.Columns.Add("单位19", typeof(string));
                dt1.Columns.Add("单位20", typeof(string));
                dt1.Columns.Add("单位21", typeof(string));
                dt1.Columns.Add("单位22", typeof(string));
                dt1.Columns.Add("单位23", typeof(string));
                dt1.Columns.Add("单位24", typeof(string));
                dt1.Columns.Add("单位25", typeof(string));
                dt1.Columns.Add("单位26", typeof(string));
                dt1.Columns.Add("单位27", typeof(string));
                dt1.Columns.Add("单位28", typeof(string));
                dt1.Columns.Add("单位29", typeof(string));
                dt1.Columns.Add("单位30", typeof(string));
                dt1.Columns.Add("单位31", typeof(string));
                dt1.Columns.Add("单位32", typeof(string));
                dt1.Columns.Add("单位33", typeof(string));
                dt1.Columns.Add("单位34", typeof(string));
                dt1.Columns.Add("单位35", typeof(string));
                dt1.Columns.Add("单位36", typeof(string));
                dt1.Columns.Add("单位37", typeof(string));
                dt1.Columns.Add("单位38", typeof(string));
                dt1.Columns.Add("单位39", typeof(string));
                dt1.Columns.Add("单位40", typeof(string));
                dt1.Columns.Add("单位41", typeof(string));
                dt1.Columns.Add("单位42", typeof(string));
                dt1.Columns.Add("单位43", typeof(string));
                dt1.Columns.Add("单位44", typeof(string));
                dt1.Columns.Add("单位45", typeof(string));
                dt1.Columns.Add("单位46", typeof(string));
                dt1.Columns.Add("单位47", typeof(string));
                dt1.Columns.Add("单位48", typeof(string));
                dt1.Columns.Add("单位49", typeof(string));
                dt1.Columns.Add("单位50", typeof(string));
                dt1.Columns.Add("单位51", typeof(string));
                dt1.Columns.Add("单位52", typeof(string));
                dt1.Columns.Add("单位53", typeof(string));
                dt1.Columns.Add("单位54", typeof(string));
                dt1.Columns.Add("单位55", typeof(string));
                dt1.Columns.Add("单位56", typeof(string));
                dt1.Columns.Add("单位57", typeof(string));
                dt1.Columns.Add("单位58", typeof(string));
                dt1.Columns.Add("单位59", typeof(string));
                dt1.Columns.Add("单位60", typeof(string));
                dt1.Columns.Add("单位61", typeof(string));
                dt1.Columns.Add("单位62", typeof(string));
                dt1.Columns.Add("单位63", typeof(string));
                dt1.Columns.Add("单位64", typeof(string));
                dt1.Columns.Add("单位65", typeof(string));
                dt1.Columns.Add("单位66", typeof(string));
                dt1.Columns.Add("单位67", typeof(string));
                dt1.Columns.Add("单位68", typeof(string));
                dt1.Columns.Add("单位69", typeof(string));
                dt1.Columns.Add("单位70", typeof(string));
                dt1.Columns.Add("单位71", typeof(string));
                dt1.Columns.Add("单位72", typeof(string));
                dt1.Columns.Add("单位73", typeof(string));
                dt1.Columns.Add("单位74", typeof(string));
                dt1.Columns.Add("单位75", typeof(string));
                dt1.Columns.Add("单位76", typeof(string));
                dt1.Columns.Add("单位77", typeof(string));
                dt1.Columns.Add("单位78", typeof(string));
                dt1.Columns.Add("单位79", typeof(string));
                dt1.Columns.Add("单位80", typeof(string));
                dt1.Columns.Add("单位81", typeof(string));
                dt1.Columns.Add("单位82", typeof(string));
                dt1.Columns.Add("单位83", typeof(string));
                dt1.Columns.Add("单位84", typeof(string));
                dt1.Columns.Add("单位85", typeof(string));
                dt1.Columns.Add("单位86", typeof(string));
                dt1.Columns.Add("单位87", typeof(string));
                dt1.Columns.Add("单位88", typeof(string));
                dt1.Columns.Add("单位89", typeof(string));
                dt1.Columns.Add("单位90", typeof(string));
                dt1.Columns.Add("单位91", typeof(string));
                dt1.Columns.Add("单位92", typeof(string));
                dt1.Columns.Add("单位93", typeof(string));
                dt1.Columns.Add("单位94", typeof(string));
                dt1.Columns.Add("单位95", typeof(string));
                dt1.Columns.Add("单位96", typeof(string));
                dt1.Columns.Add("单位97", typeof(string));
                dt1.Columns.Add("单位98", typeof(string));
                dt1.Columns.Add("单位99", typeof(string));
                dt1.Columns.Add("单位100", typeof(string));






                dt1.Columns.Add("ERP1", typeof(string));
                dt1.Columns.Add("ERP2", typeof(string));
                dt1.Columns.Add("ERP3", typeof(string));
                dt1.Columns.Add("ERP4", typeof(string));
                dt1.Columns.Add("ERP5", typeof(string));
                dt1.Columns.Add("ERP6", typeof(string));
                dt1.Columns.Add("ERP7", typeof(string));
                dt1.Columns.Add("ERP8", typeof(string));
                dt1.Columns.Add("ERP9", typeof(string));
                dt1.Columns.Add("ERP10", typeof(string));
                dt1.Columns.Add("ERP11", typeof(string));
                dt1.Columns.Add("ERP12", typeof(string));
                dt1.Columns.Add("ERP13", typeof(string));
                dt1.Columns.Add("ERP14", typeof(string));
                dt1.Columns.Add("ERP15", typeof(string));
                dt1.Columns.Add("ERP16", typeof(string));
                dt1.Columns.Add("ERP17", typeof(string));
                dt1.Columns.Add("ERP18", typeof(string));
                dt1.Columns.Add("ERP19", typeof(string));
                dt1.Columns.Add("ERP20", typeof(string));
                dt1.Columns.Add("ERP21", typeof(string));
                dt1.Columns.Add("ERP22", typeof(string));
                dt1.Columns.Add("ERP23", typeof(string));
                dt1.Columns.Add("ERP24", typeof(string));
                dt1.Columns.Add("ERP25", typeof(string));
                dt1.Columns.Add("ERP26", typeof(string));
                dt1.Columns.Add("ERP27", typeof(string));
                dt1.Columns.Add("ERP28", typeof(string));
                dt1.Columns.Add("ERP29", typeof(string));
                dt1.Columns.Add("ERP30", typeof(string));
                dt1.Columns.Add("ERP31", typeof(string));
                dt1.Columns.Add("ERP32", typeof(string));
                dt1.Columns.Add("ERP33", typeof(string));
                dt1.Columns.Add("ERP34", typeof(string));
                dt1.Columns.Add("ERP35", typeof(string));
                dt1.Columns.Add("ERP36", typeof(string));
                dt1.Columns.Add("ERP37", typeof(string));
                dt1.Columns.Add("ERP38", typeof(string));
                dt1.Columns.Add("ERP39", typeof(string));
                dt1.Columns.Add("ERP40", typeof(string));
                dt1.Columns.Add("ERP41", typeof(string));
                dt1.Columns.Add("ERP42", typeof(string));
                dt1.Columns.Add("ERP43", typeof(string));
                dt1.Columns.Add("ERP44", typeof(string));
                dt1.Columns.Add("ERP45", typeof(string));
                dt1.Columns.Add("ERP46", typeof(string));
                dt1.Columns.Add("ERP47", typeof(string));
                dt1.Columns.Add("ERP48", typeof(string));
                dt1.Columns.Add("ERP49", typeof(string));
                dt1.Columns.Add("ERP50", typeof(string));
                dt1.Columns.Add("ERP51", typeof(string));
                dt1.Columns.Add("ERP52", typeof(string));
                dt1.Columns.Add("ERP53", typeof(string));
                dt1.Columns.Add("ERP54", typeof(string));
                dt1.Columns.Add("ERP55", typeof(string));
                dt1.Columns.Add("ERP56", typeof(string));
                dt1.Columns.Add("ERP57", typeof(string));
                dt1.Columns.Add("ERP58", typeof(string));
                dt1.Columns.Add("ERP59", typeof(string));
                dt1.Columns.Add("ERP60", typeof(string));
                dt1.Columns.Add("ERP61", typeof(string));
                dt1.Columns.Add("ERP62", typeof(string));
                dt1.Columns.Add("ERP63", typeof(string));
                dt1.Columns.Add("ERP64", typeof(string));
                dt1.Columns.Add("ERP65", typeof(string));
                dt1.Columns.Add("ERP66", typeof(string));
                dt1.Columns.Add("ERP67", typeof(string));
                dt1.Columns.Add("ERP68", typeof(string));
                dt1.Columns.Add("ERP69", typeof(string));
                dt1.Columns.Add("ERP70", typeof(string));
                dt1.Columns.Add("ERP71", typeof(string));
                dt1.Columns.Add("ERP72", typeof(string));
                dt1.Columns.Add("ERP73", typeof(string));
                dt1.Columns.Add("ERP74", typeof(string));
                dt1.Columns.Add("ERP75", typeof(string));
                dt1.Columns.Add("ERP76", typeof(string));
                dt1.Columns.Add("ERP77", typeof(string));
                dt1.Columns.Add("ERP78", typeof(string));
                dt1.Columns.Add("ERP79", typeof(string));
                dt1.Columns.Add("ERP80", typeof(string));
                dt1.Columns.Add("ERP81", typeof(string));
                dt1.Columns.Add("ERP82", typeof(string));
                dt1.Columns.Add("ERP83", typeof(string));
                dt1.Columns.Add("ERP84", typeof(string));
                dt1.Columns.Add("ERP85", typeof(string));
                dt1.Columns.Add("ERP86", typeof(string));
                dt1.Columns.Add("ERP87", typeof(string));
                dt1.Columns.Add("ERP88", typeof(string));
                dt1.Columns.Add("ERP89", typeof(string));
                dt1.Columns.Add("ERP90", typeof(string));
                dt1.Columns.Add("ERP91", typeof(string));
                dt1.Columns.Add("ERP92", typeof(string));
                dt1.Columns.Add("ERP93", typeof(string));
                dt1.Columns.Add("ERP94", typeof(string));
                dt1.Columns.Add("ERP95", typeof(string));
                dt1.Columns.Add("ERP96", typeof(string));
                dt1.Columns.Add("ERP97", typeof(string));
                dt1.Columns.Add("ERP98", typeof(string));
                dt1.Columns.Add("ERP99", typeof(string));
                dt1.Columns.Add("ERP100", typeof(string));


                dt1.Columns.Add("产品名称1", typeof(string));
                dt1.Columns.Add("产品名称2", typeof(string));
                dt1.Columns.Add("产品名称3", typeof(string));
                dt1.Columns.Add("产品名称4", typeof(string));
                dt1.Columns.Add("产品名称5", typeof(string));
                dt1.Columns.Add("产品名称6", typeof(string));
                dt1.Columns.Add("产品名称7", typeof(string));
                dt1.Columns.Add("产品名称8", typeof(string));
                dt1.Columns.Add("产品名称9", typeof(string));
                dt1.Columns.Add("产品名称10", typeof(string));
                dt1.Columns.Add("产品名称11", typeof(string));
                dt1.Columns.Add("产品名称12", typeof(string));
                dt1.Columns.Add("产品名称13", typeof(string));
                dt1.Columns.Add("产品名称14", typeof(string));
                dt1.Columns.Add("产品名称15", typeof(string));
                dt1.Columns.Add("产品名称16", typeof(string));
                dt1.Columns.Add("产品名称17", typeof(string));
                dt1.Columns.Add("产品名称18", typeof(string));
                dt1.Columns.Add("产品名称19", typeof(string));
                dt1.Columns.Add("产品名称20", typeof(string));
                dt1.Columns.Add("产品名称21", typeof(string));
                dt1.Columns.Add("产品名称22", typeof(string));
                dt1.Columns.Add("产品名称23", typeof(string));
                dt1.Columns.Add("产品名称24", typeof(string));
                dt1.Columns.Add("产品名称25", typeof(string));
                dt1.Columns.Add("产品名称26", typeof(string));
                dt1.Columns.Add("产品名称27", typeof(string));
                dt1.Columns.Add("产品名称28", typeof(string));
                dt1.Columns.Add("产品名称29", typeof(string));
                dt1.Columns.Add("产品名称30", typeof(string));
                dt1.Columns.Add("产品名称31", typeof(string));
                dt1.Columns.Add("产品名称32", typeof(string));
                dt1.Columns.Add("产品名称33", typeof(string));
                dt1.Columns.Add("产品名称34", typeof(string));
                dt1.Columns.Add("产品名称35", typeof(string));
                dt1.Columns.Add("产品名称36", typeof(string));
                dt1.Columns.Add("产品名称37", typeof(string));
                dt1.Columns.Add("产品名称38", typeof(string));
                dt1.Columns.Add("产品名称39", typeof(string));
                dt1.Columns.Add("产品名称40", typeof(string));
                dt1.Columns.Add("产品名称41", typeof(string));
                dt1.Columns.Add("产品名称42", typeof(string));
                dt1.Columns.Add("产品名称43", typeof(string));
                dt1.Columns.Add("产品名称44", typeof(string));
                dt1.Columns.Add("产品名称45", typeof(string));
                dt1.Columns.Add("产品名称46", typeof(string));
                dt1.Columns.Add("产品名称47", typeof(string));
                dt1.Columns.Add("产品名称48", typeof(string));
                dt1.Columns.Add("产品名称49", typeof(string));
                dt1.Columns.Add("产品名称50", typeof(string));
                dt1.Columns.Add("产品名称51", typeof(string));
                dt1.Columns.Add("产品名称52", typeof(string));
                dt1.Columns.Add("产品名称53", typeof(string));
                dt1.Columns.Add("产品名称54", typeof(string));
                dt1.Columns.Add("产品名称55", typeof(string));
                dt1.Columns.Add("产品名称56", typeof(string));
                dt1.Columns.Add("产品名称57", typeof(string));
                dt1.Columns.Add("产品名称58", typeof(string));
                dt1.Columns.Add("产品名称59", typeof(string));
                dt1.Columns.Add("产品名称60", typeof(string));
                dt1.Columns.Add("产品名称61", typeof(string));
                dt1.Columns.Add("产品名称62", typeof(string));
                dt1.Columns.Add("产品名称63", typeof(string));
                dt1.Columns.Add("产品名称64", typeof(string));
                dt1.Columns.Add("产品名称65", typeof(string));
                dt1.Columns.Add("产品名称66", typeof(string));
                dt1.Columns.Add("产品名称67", typeof(string));
                dt1.Columns.Add("产品名称68", typeof(string));
                dt1.Columns.Add("产品名称69", typeof(string));
                dt1.Columns.Add("产品名称70", typeof(string));
                dt1.Columns.Add("产品名称71", typeof(string));
                dt1.Columns.Add("产品名称72", typeof(string));
                dt1.Columns.Add("产品名称73", typeof(string));
                dt1.Columns.Add("产品名称74", typeof(string));
                dt1.Columns.Add("产品名称75", typeof(string));
                dt1.Columns.Add("产品名称76", typeof(string));
                dt1.Columns.Add("产品名称77", typeof(string));
                dt1.Columns.Add("产品名称78", typeof(string));
                dt1.Columns.Add("产品名称79", typeof(string));
                dt1.Columns.Add("产品名称80", typeof(string));
                dt1.Columns.Add("产品名称81", typeof(string));
                dt1.Columns.Add("产品名称82", typeof(string));
                dt1.Columns.Add("产品名称83", typeof(string));
                dt1.Columns.Add("产品名称84", typeof(string));
                dt1.Columns.Add("产品名称85", typeof(string));
                dt1.Columns.Add("产品名称86", typeof(string));
                dt1.Columns.Add("产品名称87", typeof(string));
                dt1.Columns.Add("产品名称88", typeof(string));
                dt1.Columns.Add("产品名称89", typeof(string));
                dt1.Columns.Add("产品名称90", typeof(string));
                dt1.Columns.Add("产品名称91", typeof(string));
                dt1.Columns.Add("产品名称92", typeof(string));
                dt1.Columns.Add("产品名称93", typeof(string));
                dt1.Columns.Add("产品名称94", typeof(string));
                dt1.Columns.Add("产品名称95", typeof(string));
                dt1.Columns.Add("产品名称96", typeof(string));
                dt1.Columns.Add("产品名称97", typeof(string));
                dt1.Columns.Add("产品名称98", typeof(string));
                dt1.Columns.Add("产品名称99", typeof(string));
                dt1.Columns.Add("产品名称100", typeof(string));



                dt1.Columns.Add("数量1", typeof(string));
                dt1.Columns.Add("数量2", typeof(string));
                dt1.Columns.Add("数量3", typeof(string));
                dt1.Columns.Add("数量4", typeof(string));
                dt1.Columns.Add("数量5", typeof(string));
                dt1.Columns.Add("数量6", typeof(string));
                dt1.Columns.Add("数量7", typeof(string));
                dt1.Columns.Add("数量8", typeof(string));
                dt1.Columns.Add("数量9", typeof(string));
                dt1.Columns.Add("数量10", typeof(string));
                dt1.Columns.Add("数量11", typeof(string));
                dt1.Columns.Add("数量12", typeof(string));
                dt1.Columns.Add("数量13", typeof(string));
                dt1.Columns.Add("数量14", typeof(string));
                dt1.Columns.Add("数量15", typeof(string));
                dt1.Columns.Add("数量16", typeof(string));
                dt1.Columns.Add("数量17", typeof(string));
                dt1.Columns.Add("数量18", typeof(string));
                dt1.Columns.Add("数量19", typeof(string));
                dt1.Columns.Add("数量20", typeof(string));
                dt1.Columns.Add("数量21", typeof(string));
                dt1.Columns.Add("数量22", typeof(string));
                dt1.Columns.Add("数量23", typeof(string));
                dt1.Columns.Add("数量24", typeof(string));
                dt1.Columns.Add("数量25", typeof(string));
                dt1.Columns.Add("数量26", typeof(string));
                dt1.Columns.Add("数量27", typeof(string));
                dt1.Columns.Add("数量28", typeof(string));
                dt1.Columns.Add("数量29", typeof(string));
                dt1.Columns.Add("数量30", typeof(string));
                dt1.Columns.Add("数量31", typeof(string));
                dt1.Columns.Add("数量32", typeof(string));
                dt1.Columns.Add("数量33", typeof(string));
                dt1.Columns.Add("数量34", typeof(string));
                dt1.Columns.Add("数量35", typeof(string));
                dt1.Columns.Add("数量36", typeof(string));
                dt1.Columns.Add("数量37", typeof(string));
                dt1.Columns.Add("数量38", typeof(string));
                dt1.Columns.Add("数量39", typeof(string));
                dt1.Columns.Add("数量40", typeof(string));
                dt1.Columns.Add("数量41", typeof(string));
                dt1.Columns.Add("数量42", typeof(string));
                dt1.Columns.Add("数量43", typeof(string));
                dt1.Columns.Add("数量44", typeof(string));
                dt1.Columns.Add("数量45", typeof(string));
                dt1.Columns.Add("数量46", typeof(string));
                dt1.Columns.Add("数量47", typeof(string));
                dt1.Columns.Add("数量48", typeof(string));
                dt1.Columns.Add("数量49", typeof(string));
                dt1.Columns.Add("数量50", typeof(string));
                dt1.Columns.Add("数量51", typeof(string));
                dt1.Columns.Add("数量52", typeof(string));
                dt1.Columns.Add("数量53", typeof(string));
                dt1.Columns.Add("数量54", typeof(string));
                dt1.Columns.Add("数量55", typeof(string));
                dt1.Columns.Add("数量56", typeof(string));
                dt1.Columns.Add("数量57", typeof(string));
                dt1.Columns.Add("数量58", typeof(string));
                dt1.Columns.Add("数量59", typeof(string));
                dt1.Columns.Add("数量60", typeof(string));
                dt1.Columns.Add("数量61", typeof(string));
                dt1.Columns.Add("数量62", typeof(string));
                dt1.Columns.Add("数量63", typeof(string));
                dt1.Columns.Add("数量64", typeof(string));
                dt1.Columns.Add("数量65", typeof(string));
                dt1.Columns.Add("数量66", typeof(string));
                dt1.Columns.Add("数量67", typeof(string));
                dt1.Columns.Add("数量68", typeof(string));
                dt1.Columns.Add("数量69", typeof(string));
                dt1.Columns.Add("数量70", typeof(string));
                dt1.Columns.Add("数量71", typeof(string));
                dt1.Columns.Add("数量72", typeof(string));
                dt1.Columns.Add("数量73", typeof(string));
                dt1.Columns.Add("数量74", typeof(string));
                dt1.Columns.Add("数量75", typeof(string));
                dt1.Columns.Add("数量76", typeof(string));
                dt1.Columns.Add("数量77", typeof(string));
                dt1.Columns.Add("数量78", typeof(string));
                dt1.Columns.Add("数量79", typeof(string));
                dt1.Columns.Add("数量80", typeof(string));
                dt1.Columns.Add("数量81", typeof(string));
                dt1.Columns.Add("数量82", typeof(string));
                dt1.Columns.Add("数量83", typeof(string));
                dt1.Columns.Add("数量84", typeof(string));
                dt1.Columns.Add("数量85", typeof(string));
                dt1.Columns.Add("数量86", typeof(string));
                dt1.Columns.Add("数量87", typeof(string));
                dt1.Columns.Add("数量88", typeof(string));
                dt1.Columns.Add("数量89", typeof(string));
                dt1.Columns.Add("数量90", typeof(string));
                dt1.Columns.Add("数量91", typeof(string));
                dt1.Columns.Add("数量92", typeof(string));
                dt1.Columns.Add("数量93", typeof(string));
                dt1.Columns.Add("数量94", typeof(string));
                dt1.Columns.Add("数量95", typeof(string));
                dt1.Columns.Add("数量96", typeof(string));
                dt1.Columns.Add("数量97", typeof(string));
                dt1.Columns.Add("数量98", typeof(string));
                dt1.Columns.Add("数量99", typeof(string));
                dt1.Columns.Add("数量100", typeof(string));




                dt1.Columns.Add("单价1", typeof(string));
                dt1.Columns.Add("单价2", typeof(string));
                dt1.Columns.Add("单价3", typeof(string));
                dt1.Columns.Add("单价4", typeof(string));
                dt1.Columns.Add("单价5", typeof(string));
                dt1.Columns.Add("单价6", typeof(string));
                dt1.Columns.Add("单价7", typeof(string));
                dt1.Columns.Add("单价8", typeof(string));
                dt1.Columns.Add("单价9", typeof(string));
                dt1.Columns.Add("单价10", typeof(string));
                dt1.Columns.Add("单价11", typeof(string));
                dt1.Columns.Add("单价12", typeof(string));
                dt1.Columns.Add("单价13", typeof(string));
                dt1.Columns.Add("单价14", typeof(string));
                dt1.Columns.Add("单价15", typeof(string));
                dt1.Columns.Add("单价16", typeof(string));
                dt1.Columns.Add("单价17", typeof(string));
                dt1.Columns.Add("单价18", typeof(string));
                dt1.Columns.Add("单价19", typeof(string));
                dt1.Columns.Add("单价20", typeof(string));
                dt1.Columns.Add("单价21", typeof(string));
                dt1.Columns.Add("单价22", typeof(string));
                dt1.Columns.Add("单价23", typeof(string));
                dt1.Columns.Add("单价24", typeof(string));
                dt1.Columns.Add("单价25", typeof(string));
                dt1.Columns.Add("单价26", typeof(string));
                dt1.Columns.Add("单价27", typeof(string));
                dt1.Columns.Add("单价28", typeof(string));
                dt1.Columns.Add("单价29", typeof(string));
                dt1.Columns.Add("单价30", typeof(string));
                dt1.Columns.Add("单价31", typeof(string));
                dt1.Columns.Add("单价32", typeof(string));
                dt1.Columns.Add("单价33", typeof(string));
                dt1.Columns.Add("单价34", typeof(string));
                dt1.Columns.Add("单价35", typeof(string));
                dt1.Columns.Add("单价36", typeof(string));
                dt1.Columns.Add("单价37", typeof(string));
                dt1.Columns.Add("单价38", typeof(string));
                dt1.Columns.Add("单价39", typeof(string));
                dt1.Columns.Add("单价40", typeof(string));
                dt1.Columns.Add("单价41", typeof(string));
                dt1.Columns.Add("单价42", typeof(string));
                dt1.Columns.Add("单价43", typeof(string));
                dt1.Columns.Add("单价44", typeof(string));
                dt1.Columns.Add("单价45", typeof(string));
                dt1.Columns.Add("单价46", typeof(string));
                dt1.Columns.Add("单价47", typeof(string));
                dt1.Columns.Add("单价48", typeof(string));
                dt1.Columns.Add("单价49", typeof(string));
                dt1.Columns.Add("单价50", typeof(string));
                dt1.Columns.Add("单价51", typeof(string));
                dt1.Columns.Add("单价52", typeof(string));
                dt1.Columns.Add("单价53", typeof(string));
                dt1.Columns.Add("单价54", typeof(string));
                dt1.Columns.Add("单价55", typeof(string));
                dt1.Columns.Add("单价56", typeof(string));
                dt1.Columns.Add("单价57", typeof(string));
                dt1.Columns.Add("单价58", typeof(string));
                dt1.Columns.Add("单价59", typeof(string));
                dt1.Columns.Add("单价60", typeof(string));
                dt1.Columns.Add("单价61", typeof(string));
                dt1.Columns.Add("单价62", typeof(string));
                dt1.Columns.Add("单价63", typeof(string));
                dt1.Columns.Add("单价64", typeof(string));
                dt1.Columns.Add("单价65", typeof(string));
                dt1.Columns.Add("单价66", typeof(string));
                dt1.Columns.Add("单价67", typeof(string));
                dt1.Columns.Add("单价68", typeof(string));
                dt1.Columns.Add("单价69", typeof(string));
                dt1.Columns.Add("单价70", typeof(string));
                dt1.Columns.Add("单价71", typeof(string));
                dt1.Columns.Add("单价72", typeof(string));
                dt1.Columns.Add("单价73", typeof(string));
                dt1.Columns.Add("单价74", typeof(string));
                dt1.Columns.Add("单价75", typeof(string));
                dt1.Columns.Add("单价76", typeof(string));
                dt1.Columns.Add("单价77", typeof(string));
                dt1.Columns.Add("单价78", typeof(string));
                dt1.Columns.Add("单价79", typeof(string));
                dt1.Columns.Add("单价80", typeof(string));
                dt1.Columns.Add("单价81", typeof(string));
                dt1.Columns.Add("单价82", typeof(string));
                dt1.Columns.Add("单价83", typeof(string));
                dt1.Columns.Add("单价84", typeof(string));
                dt1.Columns.Add("单价85", typeof(string));
                dt1.Columns.Add("单价86", typeof(string));
                dt1.Columns.Add("单价87", typeof(string));
                dt1.Columns.Add("单价88", typeof(string));
                dt1.Columns.Add("单价89", typeof(string));
                dt1.Columns.Add("单价90", typeof(string));
                dt1.Columns.Add("单价91", typeof(string));
                dt1.Columns.Add("单价92", typeof(string));
                dt1.Columns.Add("单价93", typeof(string));
                dt1.Columns.Add("单价94", typeof(string));
                dt1.Columns.Add("单价95", typeof(string));
                dt1.Columns.Add("单价96", typeof(string));
                dt1.Columns.Add("单价97", typeof(string));
                dt1.Columns.Add("单价98", typeof(string));
                dt1.Columns.Add("单价99", typeof(string));
                dt1.Columns.Add("单价100", typeof(string));


                dt1.Columns.Add("总金额1", typeof(string));
                dt1.Columns.Add("总金额2", typeof(string));
                dt1.Columns.Add("总金额3", typeof(string));
                dt1.Columns.Add("总金额4", typeof(string));
                dt1.Columns.Add("总金额5", typeof(string));
                dt1.Columns.Add("总金额6", typeof(string));
                dt1.Columns.Add("总金额7", typeof(string));
                dt1.Columns.Add("总金额8", typeof(string));
                dt1.Columns.Add("总金额9", typeof(string));
                dt1.Columns.Add("总金额10", typeof(string));
                dt1.Columns.Add("总金额11", typeof(string));
                dt1.Columns.Add("总金额12", typeof(string));
                dt1.Columns.Add("总金额13", typeof(string));
                dt1.Columns.Add("总金额14", typeof(string));
                dt1.Columns.Add("总金额15", typeof(string));
                dt1.Columns.Add("总金额16", typeof(string));
                dt1.Columns.Add("总金额17", typeof(string));
                dt1.Columns.Add("总金额18", typeof(string));
                dt1.Columns.Add("总金额19", typeof(string));
                dt1.Columns.Add("总金额20", typeof(string));
                dt1.Columns.Add("总金额21", typeof(string));
                dt1.Columns.Add("总金额22", typeof(string));
                dt1.Columns.Add("总金额23", typeof(string));
                dt1.Columns.Add("总金额24", typeof(string));
                dt1.Columns.Add("总金额25", typeof(string));
                dt1.Columns.Add("总金额26", typeof(string));
                dt1.Columns.Add("总金额27", typeof(string));
                dt1.Columns.Add("总金额28", typeof(string));
                dt1.Columns.Add("总金额29", typeof(string));
                dt1.Columns.Add("总金额30", typeof(string));
                dt1.Columns.Add("总金额31", typeof(string));
                dt1.Columns.Add("总金额32", typeof(string));
                dt1.Columns.Add("总金额33", typeof(string));
                dt1.Columns.Add("总金额34", typeof(string));
                dt1.Columns.Add("总金额35", typeof(string));
                dt1.Columns.Add("总金额36", typeof(string));
                dt1.Columns.Add("总金额37", typeof(string));
                dt1.Columns.Add("总金额38", typeof(string));
                dt1.Columns.Add("总金额39", typeof(string));
                dt1.Columns.Add("总金额40", typeof(string));
                dt1.Columns.Add("总金额41", typeof(string));
                dt1.Columns.Add("总金额42", typeof(string));
                dt1.Columns.Add("总金额43", typeof(string));
                dt1.Columns.Add("总金额44", typeof(string));
                dt1.Columns.Add("总金额45", typeof(string));
                dt1.Columns.Add("总金额46", typeof(string));
                dt1.Columns.Add("总金额47", typeof(string));
                dt1.Columns.Add("总金额48", typeof(string));
                dt1.Columns.Add("总金额49", typeof(string));
                dt1.Columns.Add("总金额50", typeof(string));
                dt1.Columns.Add("总金额51", typeof(string));
                dt1.Columns.Add("总金额52", typeof(string));
                dt1.Columns.Add("总金额53", typeof(string));
                dt1.Columns.Add("总金额54", typeof(string));
                dt1.Columns.Add("总金额55", typeof(string));
                dt1.Columns.Add("总金额56", typeof(string));
                dt1.Columns.Add("总金额57", typeof(string));
                dt1.Columns.Add("总金额58", typeof(string));
                dt1.Columns.Add("总金额59", typeof(string));
                dt1.Columns.Add("总金额60", typeof(string));
                dt1.Columns.Add("总金额61", typeof(string));
                dt1.Columns.Add("总金额62", typeof(string));
                dt1.Columns.Add("总金额63", typeof(string));
                dt1.Columns.Add("总金额64", typeof(string));
                dt1.Columns.Add("总金额65", typeof(string));
                dt1.Columns.Add("总金额66", typeof(string));
                dt1.Columns.Add("总金额67", typeof(string));
                dt1.Columns.Add("总金额68", typeof(string));
                dt1.Columns.Add("总金额69", typeof(string));
                dt1.Columns.Add("总金额70", typeof(string));
                dt1.Columns.Add("总金额71", typeof(string));
                dt1.Columns.Add("总金额72", typeof(string));
                dt1.Columns.Add("总金额73", typeof(string));
                dt1.Columns.Add("总金额74", typeof(string));
                dt1.Columns.Add("总金额75", typeof(string));
                dt1.Columns.Add("总金额76", typeof(string));
                dt1.Columns.Add("总金额77", typeof(string));
                dt1.Columns.Add("总金额78", typeof(string));
                dt1.Columns.Add("总金额79", typeof(string));
                dt1.Columns.Add("总金额80", typeof(string));
                dt1.Columns.Add("总金额81", typeof(string));
                dt1.Columns.Add("总金额82", typeof(string));
                dt1.Columns.Add("总金额83", typeof(string));
                dt1.Columns.Add("总金额84", typeof(string));
                dt1.Columns.Add("总金额85", typeof(string));
                dt1.Columns.Add("总金额86", typeof(string));
                dt1.Columns.Add("总金额87", typeof(string));
                dt1.Columns.Add("总金额88", typeof(string));
                dt1.Columns.Add("总金额89", typeof(string));
                dt1.Columns.Add("总金额90", typeof(string));
                dt1.Columns.Add("总金额91", typeof(string));
                dt1.Columns.Add("总金额92", typeof(string));
                dt1.Columns.Add("总金额93", typeof(string));
                dt1.Columns.Add("总金额94", typeof(string));
                dt1.Columns.Add("总金额95", typeof(string));
                dt1.Columns.Add("总金额96", typeof(string));
                dt1.Columns.Add("总金额97", typeof(string));
                dt1.Columns.Add("总金额98", typeof(string));
                dt1.Columns.Add("总金额99", typeof(string));
                dt1.Columns.Add("总金额100", typeof(string));


                dt1.Columns.Add("备注1", typeof(string));
                dt1.Columns.Add("备注2", typeof(string));
                dt1.Columns.Add("备注3", typeof(string));
                dt1.Columns.Add("备注4", typeof(string));
                dt1.Columns.Add("备注5", typeof(string));
                dt1.Columns.Add("备注6", typeof(string));
                dt1.Columns.Add("备注7", typeof(string));
                dt1.Columns.Add("备注8", typeof(string));
                dt1.Columns.Add("备注9", typeof(string));
                dt1.Columns.Add("备注10", typeof(string));
                dt1.Columns.Add("备注11", typeof(string));
                dt1.Columns.Add("备注12", typeof(string));
                dt1.Columns.Add("备注13", typeof(string));
                dt1.Columns.Add("备注14", typeof(string));
                dt1.Columns.Add("备注15", typeof(string));
                dt1.Columns.Add("备注16", typeof(string));
                dt1.Columns.Add("备注17", typeof(string));
                dt1.Columns.Add("备注18", typeof(string));
                dt1.Columns.Add("备注19", typeof(string));
                dt1.Columns.Add("备注20", typeof(string));
                dt1.Columns.Add("备注21", typeof(string));
                dt1.Columns.Add("备注22", typeof(string));
                dt1.Columns.Add("备注23", typeof(string));
                dt1.Columns.Add("备注24", typeof(string));
                dt1.Columns.Add("备注25", typeof(string));
                dt1.Columns.Add("备注26", typeof(string));
                dt1.Columns.Add("备注27", typeof(string));
                dt1.Columns.Add("备注28", typeof(string));
                dt1.Columns.Add("备注29", typeof(string));
                dt1.Columns.Add("备注30", typeof(string));
                dt1.Columns.Add("备注31", typeof(string));
                dt1.Columns.Add("备注32", typeof(string));
                dt1.Columns.Add("备注33", typeof(string));
                dt1.Columns.Add("备注34", typeof(string));
                dt1.Columns.Add("备注35", typeof(string));
                dt1.Columns.Add("备注36", typeof(string));
                dt1.Columns.Add("备注37", typeof(string));
                dt1.Columns.Add("备注38", typeof(string));
                dt1.Columns.Add("备注39", typeof(string));
                dt1.Columns.Add("备注40", typeof(string));
                dt1.Columns.Add("备注41", typeof(string));
                dt1.Columns.Add("备注42", typeof(string));
                dt1.Columns.Add("备注43", typeof(string));
                dt1.Columns.Add("备注44", typeof(string));
                dt1.Columns.Add("备注45", typeof(string));
                dt1.Columns.Add("备注46", typeof(string));
                dt1.Columns.Add("备注47", typeof(string));
                dt1.Columns.Add("备注48", typeof(string));
                dt1.Columns.Add("备注49", typeof(string));
                dt1.Columns.Add("备注50", typeof(string));
                dt1.Columns.Add("备注51", typeof(string));
                dt1.Columns.Add("备注52", typeof(string));
                dt1.Columns.Add("备注53", typeof(string));
                dt1.Columns.Add("备注54", typeof(string));
                dt1.Columns.Add("备注55", typeof(string));
                dt1.Columns.Add("备注56", typeof(string));
                dt1.Columns.Add("备注57", typeof(string));
                dt1.Columns.Add("备注58", typeof(string));
                dt1.Columns.Add("备注59", typeof(string));
                dt1.Columns.Add("备注60", typeof(string));
                dt1.Columns.Add("备注61", typeof(string));
                dt1.Columns.Add("备注62", typeof(string));
                dt1.Columns.Add("备注63", typeof(string));
                dt1.Columns.Add("备注64", typeof(string));
                dt1.Columns.Add("备注65", typeof(string));
                dt1.Columns.Add("备注66", typeof(string));
                dt1.Columns.Add("备注67", typeof(string));
                dt1.Columns.Add("备注68", typeof(string));
                dt1.Columns.Add("备注69", typeof(string));
                dt1.Columns.Add("备注70", typeof(string));
                dt1.Columns.Add("备注71", typeof(string));
                dt1.Columns.Add("备注72", typeof(string));
                dt1.Columns.Add("备注73", typeof(string));
                dt1.Columns.Add("备注74", typeof(string));
                dt1.Columns.Add("备注75", typeof(string));
                dt1.Columns.Add("备注76", typeof(string));
                dt1.Columns.Add("备注77", typeof(string));
                dt1.Columns.Add("备注78", typeof(string));
                dt1.Columns.Add("备注79", typeof(string));
                dt1.Columns.Add("备注80", typeof(string));
                dt1.Columns.Add("备注81", typeof(string));
                dt1.Columns.Add("备注82", typeof(string));
                dt1.Columns.Add("备注83", typeof(string));
                dt1.Columns.Add("备注84", typeof(string));
                dt1.Columns.Add("备注85", typeof(string));
                dt1.Columns.Add("备注86", typeof(string));
                dt1.Columns.Add("备注87", typeof(string));
                dt1.Columns.Add("备注88", typeof(string));
                dt1.Columns.Add("备注89", typeof(string));
                dt1.Columns.Add("备注90", typeof(string));
                dt1.Columns.Add("备注91", typeof(string));
                dt1.Columns.Add("备注92", typeof(string));
                dt1.Columns.Add("备注93", typeof(string));
                dt1.Columns.Add("备注94", typeof(string));
                dt1.Columns.Add("备注95", typeof(string));
                dt1.Columns.Add("备注96", typeof(string));
                dt1.Columns.Add("备注97", typeof(string));
                dt1.Columns.Add("备注98", typeof(string));
                dt1.Columns.Add("备注99", typeof(string));
                dt1.Columns.Add("备注100", typeof(string));

                dt1.Columns.Add("序号1", typeof(string));
                dt1.Columns.Add("序号2", typeof(string));
                dt1.Columns.Add("序号3", typeof(string));
                dt1.Columns.Add("序号4", typeof(string));
                dt1.Columns.Add("序号5", typeof(string));
                dt1.Columns.Add("序号6", typeof(string));
                dt1.Columns.Add("序号7", typeof(string));
                dt1.Columns.Add("序号8", typeof(string));
                dt1.Columns.Add("序号9", typeof(string));
                dt1.Columns.Add("序号10", typeof(string));
                dt1.Columns.Add("序号11", typeof(string));
                dt1.Columns.Add("序号12", typeof(string));
                dt1.Columns.Add("序号13", typeof(string));
                dt1.Columns.Add("序号14", typeof(string));
                dt1.Columns.Add("序号15", typeof(string));
                dt1.Columns.Add("序号16", typeof(string));
                dt1.Columns.Add("序号17", typeof(string));
                dt1.Columns.Add("序号18", typeof(string));
                dt1.Columns.Add("序号19", typeof(string));
                dt1.Columns.Add("序号20", typeof(string));
                dt1.Columns.Add("序号21", typeof(string));
                dt1.Columns.Add("序号22", typeof(string));
                dt1.Columns.Add("序号23", typeof(string));
                dt1.Columns.Add("序号24", typeof(string));
                dt1.Columns.Add("序号25", typeof(string));
                dt1.Columns.Add("序号26", typeof(string));
                dt1.Columns.Add("序号27", typeof(string));
                dt1.Columns.Add("序号28", typeof(string));
                dt1.Columns.Add("序号29", typeof(string));
                dt1.Columns.Add("序号30", typeof(string));
                dt1.Columns.Add("序号31", typeof(string));
                dt1.Columns.Add("序号32", typeof(string));
                dt1.Columns.Add("序号33", typeof(string));
                dt1.Columns.Add("序号34", typeof(string));
                dt1.Columns.Add("序号35", typeof(string));
                dt1.Columns.Add("序号36", typeof(string));
                dt1.Columns.Add("序号37", typeof(string));
                dt1.Columns.Add("序号38", typeof(string));
                dt1.Columns.Add("序号39", typeof(string));
                dt1.Columns.Add("序号40", typeof(string));
                dt1.Columns.Add("序号41", typeof(string));
                dt1.Columns.Add("序号42", typeof(string));
                dt1.Columns.Add("序号43", typeof(string));
                dt1.Columns.Add("序号44", typeof(string));
                dt1.Columns.Add("序号45", typeof(string));
                dt1.Columns.Add("序号46", typeof(string));
                dt1.Columns.Add("序号47", typeof(string));
                dt1.Columns.Add("序号48", typeof(string));
                dt1.Columns.Add("序号49", typeof(string));
                dt1.Columns.Add("序号50", typeof(string));
                dt1.Columns.Add("序号51", typeof(string));
                dt1.Columns.Add("序号52", typeof(string));
                dt1.Columns.Add("序号53", typeof(string));
                dt1.Columns.Add("序号54", typeof(string));
                dt1.Columns.Add("序号55", typeof(string));
                dt1.Columns.Add("序号56", typeof(string));
                dt1.Columns.Add("序号57", typeof(string));
                dt1.Columns.Add("序号58", typeof(string));
                dt1.Columns.Add("序号59", typeof(string));
                dt1.Columns.Add("序号60", typeof(string));
                dt1.Columns.Add("序号61", typeof(string));
                dt1.Columns.Add("序号62", typeof(string));
                dt1.Columns.Add("序号63", typeof(string));
                dt1.Columns.Add("序号64", typeof(string));
                dt1.Columns.Add("序号65", typeof(string));
                dt1.Columns.Add("序号66", typeof(string));
                dt1.Columns.Add("序号67", typeof(string));
                dt1.Columns.Add("序号68", typeof(string));
                dt1.Columns.Add("序号69", typeof(string));
                dt1.Columns.Add("序号70", typeof(string));
                dt1.Columns.Add("序号71", typeof(string));
                dt1.Columns.Add("序号72", typeof(string));
                dt1.Columns.Add("序号73", typeof(string));
                dt1.Columns.Add("序号74", typeof(string));
                dt1.Columns.Add("序号75", typeof(string));
                dt1.Columns.Add("序号76", typeof(string));
                dt1.Columns.Add("序号77", typeof(string));
                dt1.Columns.Add("序号78", typeof(string));
                dt1.Columns.Add("序号79", typeof(string));
                dt1.Columns.Add("序号80", typeof(string));
                dt1.Columns.Add("序号81", typeof(string));
                dt1.Columns.Add("序号82", typeof(string));
                dt1.Columns.Add("序号83", typeof(string));
                dt1.Columns.Add("序号84", typeof(string));
                dt1.Columns.Add("序号85", typeof(string));
                dt1.Columns.Add("序号86", typeof(string));
                dt1.Columns.Add("序号87", typeof(string));
                dt1.Columns.Add("序号88", typeof(string));
                dt1.Columns.Add("序号89", typeof(string));
                dt1.Columns.Add("序号90", typeof(string));
                dt1.Columns.Add("序号91", typeof(string));
                dt1.Columns.Add("序号92", typeof(string));
                dt1.Columns.Add("序号93", typeof(string));
                dt1.Columns.Add("序号94", typeof(string));
                dt1.Columns.Add("序号95", typeof(string));
                dt1.Columns.Add("序号96", typeof(string));
                dt1.Columns.Add("序号97", typeof(string));
                dt1.Columns.Add("序号98", typeof(string));
                dt1.Columns.Add("序号99", typeof(string));
                dt1.Columns.Add("序号100", typeof(string));

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
                dr1["交货日期"] = jiaohuoriqi;
                dr1["合计1"] = heji;
                dr1["生产进度负责人"] = txtgangfangfuzeren.Text.Trim();
                dr1["负责人电话"] = txtgongfangfuzerendianhua.Text.Trim();

                dt1.Rows.Add(dr1);

                string tempFile = Application.StartupPath + "\\合同标准模板.doc";
                Document doc = new Document(tempFile);
                DocumentBuilder builder = new DocumentBuilder(doc);
                NodeCollection allTables = doc.GetChildNodes(NodeType.Table, true);

                Dictionary<string, string> dic = new Dictionary<string, string>();
                DataRow dr = dt1.Rows[0];


                //dic.Add("邮箱", dr["邮箱"].ToString());
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

                dic.Add("ERP1", dr["ERP1"].ToString());
                dic.Add("ERP2", dr["ERP2"].ToString());
                dic.Add("ERP3", dr["ERP3"].ToString());
                dic.Add("ERP4", dr["ERP4"].ToString());
                dic.Add("ERP5", dr["ERP5"].ToString());
                dic.Add("ERP6", dr["ERP6"].ToString());
                dic.Add("ERP7", dr["ERP7"].ToString());
                dic.Add("ERP8", dr["ERP8"].ToString());
                dic.Add("ERP9", dr["ERP9"].ToString());
                dic.Add("ERP10", dr["ERP10"].ToString());
                dic.Add("ERP11", dr["ERP11"].ToString());
                dic.Add("ERP12", dr["ERP12"].ToString());
                dic.Add("ERP13", dr["ERP13"].ToString());
                dic.Add("ERP14", dr["ERP14"].ToString());
                dic.Add("ERP15", dr["ERP15"].ToString());
                dic.Add("ERP16", dr["ERP16"].ToString());
                dic.Add("ERP17", dr["ERP17"].ToString());
                dic.Add("ERP18", dr["ERP18"].ToString());
                dic.Add("ERP19", dr["ERP19"].ToString());
                dic.Add("ERP20", dr["ERP20"].ToString());
                dic.Add("ERP21", dr["ERP21"].ToString());
                dic.Add("ERP22", dr["ERP22"].ToString());
                dic.Add("ERP23", dr["ERP23"].ToString());
                dic.Add("ERP24", dr["ERP24"].ToString());
                dic.Add("ERP25", dr["ERP25"].ToString());
                dic.Add("ERP26", dr["ERP26"].ToString());
                dic.Add("ERP27", dr["ERP27"].ToString());
                dic.Add("ERP28", dr["ERP28"].ToString());
                dic.Add("ERP29", dr["ERP29"].ToString());
                dic.Add("ERP30", dr["ERP30"].ToString());
                dic.Add("ERP31", dr["ERP31"].ToString());
                dic.Add("ERP32", dr["ERP32"].ToString());
                dic.Add("ERP33", dr["ERP33"].ToString());
                dic.Add("ERP34", dr["ERP34"].ToString());
                dic.Add("ERP35", dr["ERP35"].ToString());
                dic.Add("ERP36", dr["ERP36"].ToString());
                dic.Add("ERP37", dr["ERP37"].ToString());
                dic.Add("ERP38", dr["ERP38"].ToString());
                dic.Add("ERP39", dr["ERP39"].ToString());
                dic.Add("ERP40", dr["ERP40"].ToString());
                dic.Add("ERP41", dr["ERP41"].ToString());
                dic.Add("ERP42", dr["ERP42"].ToString());
                dic.Add("ERP43", dr["ERP43"].ToString());
                dic.Add("ERP44", dr["ERP44"].ToString());
                dic.Add("ERP45", dr["ERP45"].ToString());
                dic.Add("ERP46", dr["ERP46"].ToString());
                dic.Add("ERP47", dr["ERP47"].ToString());
                dic.Add("ERP48", dr["ERP48"].ToString());
                dic.Add("ERP49", dr["ERP49"].ToString());
                dic.Add("ERP50", dr["ERP50"].ToString());
                dic.Add("ERP51", dr["ERP51"].ToString());
                dic.Add("ERP52", dr["ERP52"].ToString());
                dic.Add("ERP53", dr["ERP53"].ToString());
                dic.Add("ERP54", dr["ERP54"].ToString());
                dic.Add("ERP55", dr["ERP55"].ToString());
                dic.Add("ERP56", dr["ERP56"].ToString());
                dic.Add("ERP57", dr["ERP57"].ToString());
                dic.Add("ERP58", dr["ERP58"].ToString());
                dic.Add("ERP59", dr["ERP59"].ToString());
                dic.Add("ERP60", dr["ERP60"].ToString());
                dic.Add("ERP61", dr["ERP61"].ToString());
                dic.Add("ERP62", dr["ERP62"].ToString());
                dic.Add("ERP63", dr["ERP63"].ToString());
                dic.Add("ERP64", dr["ERP64"].ToString());
                dic.Add("ERP65", dr["ERP65"].ToString());
                dic.Add("ERP66", dr["ERP66"].ToString());
                dic.Add("ERP67", dr["ERP67"].ToString());
                dic.Add("ERP68", dr["ERP68"].ToString());
                dic.Add("ERP69", dr["ERP69"].ToString());
                dic.Add("ERP70", dr["ERP70"].ToString());
                dic.Add("ERP71", dr["ERP71"].ToString());
                dic.Add("ERP72", dr["ERP72"].ToString());
                dic.Add("ERP73", dr["ERP73"].ToString());
                dic.Add("ERP74", dr["ERP74"].ToString());
                dic.Add("ERP75", dr["ERP75"].ToString());
                dic.Add("ERP76", dr["ERP76"].ToString());
                dic.Add("ERP77", dr["ERP77"].ToString());
                dic.Add("ERP78", dr["ERP78"].ToString());
                dic.Add("ERP79", dr["ERP79"].ToString());
                dic.Add("ERP80", dr["ERP80"].ToString());
                dic.Add("ERP81", dr["ERP81"].ToString());
                dic.Add("ERP82", dr["ERP82"].ToString());
                dic.Add("ERP83", dr["ERP83"].ToString());
                dic.Add("ERP84", dr["ERP84"].ToString());
                dic.Add("ERP85", dr["ERP85"].ToString());
                dic.Add("ERP86", dr["ERP86"].ToString());
                dic.Add("ERP87", dr["ERP87"].ToString());
                dic.Add("ERP88", dr["ERP88"].ToString());
                dic.Add("ERP89", dr["ERP89"].ToString());
                dic.Add("ERP90", dr["ERP90"].ToString());
                dic.Add("ERP91", dr["ERP91"].ToString());
                dic.Add("ERP92", dr["ERP92"].ToString());
                dic.Add("ERP93", dr["ERP93"].ToString());
                dic.Add("ERP94", dr["ERP94"].ToString());
                dic.Add("ERP95", dr["ERP95"].ToString());
                dic.Add("ERP96", dr["ERP96"].ToString());
                dic.Add("ERP97", dr["ERP97"].ToString());
                dic.Add("ERP98", dr["ERP98"].ToString());
                dic.Add("ERP99", dr["ERP99"].ToString());
                dic.Add("ERP100", dr["ERP100"].ToString());


                dic.Add("单位1", dr["单位1"].ToString());
                dic.Add("单位2", dr["单位2"].ToString());
                dic.Add("单位3", dr["单位3"].ToString());
                dic.Add("单位4", dr["单位4"].ToString());
                dic.Add("单位5", dr["单位5"].ToString());
                dic.Add("单位6", dr["单位6"].ToString());
                dic.Add("单位7", dr["单位7"].ToString());
                dic.Add("单位8", dr["单位8"].ToString());
                dic.Add("单位9", dr["单位9"].ToString());
                dic.Add("单位10", dr["单位10"].ToString());
                dic.Add("单位11", dr["单位11"].ToString());
                dic.Add("单位12", dr["单位12"].ToString());
                dic.Add("单位13", dr["单位13"].ToString());
                dic.Add("单位14", dr["单位14"].ToString());
                dic.Add("单位15", dr["单位15"].ToString());
                dic.Add("单位16", dr["单位16"].ToString());
                dic.Add("单位17", dr["单位17"].ToString());
                dic.Add("单位18", dr["单位18"].ToString());
                dic.Add("单位19", dr["单位19"].ToString());
                dic.Add("单位20", dr["单位20"].ToString());
                dic.Add("单位21", dr["单位21"].ToString());
                dic.Add("单位22", dr["单位22"].ToString());
                dic.Add("单位23", dr["单位23"].ToString());
                dic.Add("单位24", dr["单位24"].ToString());
                dic.Add("单位25", dr["单位25"].ToString());
                dic.Add("单位26", dr["单位26"].ToString());
                dic.Add("单位27", dr["单位27"].ToString());
                dic.Add("单位28", dr["单位28"].ToString());
                dic.Add("单位29", dr["单位29"].ToString());
                dic.Add("单位30", dr["单位30"].ToString());
                dic.Add("单位31", dr["单位31"].ToString());
                dic.Add("单位32", dr["单位32"].ToString());
                dic.Add("单位33", dr["单位33"].ToString());
                dic.Add("单位34", dr["单位34"].ToString());
                dic.Add("单位35", dr["单位35"].ToString());
                dic.Add("单位36", dr["单位36"].ToString());
                dic.Add("单位37", dr["单位37"].ToString());
                dic.Add("单位38", dr["单位38"].ToString());
                dic.Add("单位39", dr["单位39"].ToString());
                dic.Add("单位40", dr["单位40"].ToString());
                dic.Add("单位41", dr["单位41"].ToString());
                dic.Add("单位42", dr["单位42"].ToString());
                dic.Add("单位43", dr["单位43"].ToString());
                dic.Add("单位44", dr["单位44"].ToString());
                dic.Add("单位45", dr["单位45"].ToString());
                dic.Add("单位46", dr["单位46"].ToString());
                dic.Add("单位47", dr["单位47"].ToString());
                dic.Add("单位48", dr["单位48"].ToString());
                dic.Add("单位49", dr["单位49"].ToString());
                dic.Add("单位50", dr["单位50"].ToString());
                dic.Add("单位51", dr["单位51"].ToString());
                dic.Add("单位52", dr["单位52"].ToString());
                dic.Add("单位53", dr["单位53"].ToString());
                dic.Add("单位54", dr["单位54"].ToString());
                dic.Add("单位55", dr["单位55"].ToString());
                dic.Add("单位56", dr["单位56"].ToString());
                dic.Add("单位57", dr["单位57"].ToString());
                dic.Add("单位58", dr["单位58"].ToString());
                dic.Add("单位59", dr["单位59"].ToString());
                dic.Add("单位60", dr["单位60"].ToString());
                dic.Add("单位61", dr["单位61"].ToString());
                dic.Add("单位62", dr["单位62"].ToString());
                dic.Add("单位63", dr["单位63"].ToString());
                dic.Add("单位64", dr["单位64"].ToString());
                dic.Add("单位65", dr["单位65"].ToString());
                dic.Add("单位66", dr["单位66"].ToString());
                dic.Add("单位67", dr["单位67"].ToString());
                dic.Add("单位68", dr["单位68"].ToString());
                dic.Add("单位69", dr["单位69"].ToString());
                dic.Add("单位70", dr["单位70"].ToString());
                dic.Add("单位71", dr["单位71"].ToString());
                dic.Add("单位72", dr["单位72"].ToString());
                dic.Add("单位73", dr["单位73"].ToString());
                dic.Add("单位74", dr["单位74"].ToString());
                dic.Add("单位75", dr["单位75"].ToString());
                dic.Add("单位76", dr["单位76"].ToString());
                dic.Add("单位77", dr["单位77"].ToString());
                dic.Add("单位78", dr["单位78"].ToString());
                dic.Add("单位79", dr["单位79"].ToString());
                dic.Add("单位80", dr["单位80"].ToString());
                dic.Add("单位81", dr["单位81"].ToString());
                dic.Add("单位82", dr["单位82"].ToString());
                dic.Add("单位83", dr["单位83"].ToString());
                dic.Add("单位84", dr["单位84"].ToString());
                dic.Add("单位85", dr["单位85"].ToString());
                dic.Add("单位86", dr["单位86"].ToString());
                dic.Add("单位87", dr["单位87"].ToString());
                dic.Add("单位88", dr["单位88"].ToString());
                dic.Add("单位89", dr["单位89"].ToString());
                dic.Add("单位90", dr["单位90"].ToString());
                dic.Add("单位91", dr["单位91"].ToString());
                dic.Add("单位92", dr["单位92"].ToString());
                dic.Add("单位93", dr["单位93"].ToString());
                dic.Add("单位94", dr["单位94"].ToString());
                dic.Add("单位95", dr["单位95"].ToString());
                dic.Add("单位96", dr["单位96"].ToString());
                dic.Add("单位97", dr["单位97"].ToString());
                dic.Add("单位98", dr["单位98"].ToString());
                dic.Add("单位99", dr["单位99"].ToString());
                dic.Add("单位100", dr["单位100"].ToString());

                dic.Add("产品名称1", dr["产品名称1"].ToString());
                dic.Add("产品名称2", dr["产品名称2"].ToString());
                dic.Add("产品名称3", dr["产品名称3"].ToString());
                dic.Add("产品名称4", dr["产品名称4"].ToString());
                dic.Add("产品名称5", dr["产品名称5"].ToString());
                dic.Add("产品名称6", dr["产品名称6"].ToString());
                dic.Add("产品名称7", dr["产品名称7"].ToString());
                dic.Add("产品名称8", dr["产品名称8"].ToString());
                dic.Add("产品名称9", dr["产品名称9"].ToString());
                dic.Add("产品名称10", dr["产品名称10"].ToString());
                dic.Add("产品名称11", dr["产品名称11"].ToString());
                dic.Add("产品名称12", dr["产品名称12"].ToString());
                dic.Add("产品名称13", dr["产品名称13"].ToString());
                dic.Add("产品名称14", dr["产品名称14"].ToString());
                dic.Add("产品名称15", dr["产品名称15"].ToString());
                dic.Add("产品名称16", dr["产品名称16"].ToString());
                dic.Add("产品名称17", dr["产品名称17"].ToString());
                dic.Add("产品名称18", dr["产品名称18"].ToString());
                dic.Add("产品名称19", dr["产品名称19"].ToString());
                dic.Add("产品名称20", dr["产品名称20"].ToString());
                dic.Add("产品名称21", dr["产品名称21"].ToString());
                dic.Add("产品名称22", dr["产品名称22"].ToString());
                dic.Add("产品名称23", dr["产品名称23"].ToString());
                dic.Add("产品名称24", dr["产品名称24"].ToString());
                dic.Add("产品名称25", dr["产品名称25"].ToString());
                dic.Add("产品名称26", dr["产品名称26"].ToString());
                dic.Add("产品名称27", dr["产品名称27"].ToString());
                dic.Add("产品名称28", dr["产品名称28"].ToString());
                dic.Add("产品名称29", dr["产品名称29"].ToString());
                dic.Add("产品名称30", dr["产品名称30"].ToString());
                dic.Add("产品名称31", dr["产品名称31"].ToString());
                dic.Add("产品名称32", dr["产品名称32"].ToString());
                dic.Add("产品名称33", dr["产品名称33"].ToString());
                dic.Add("产品名称34", dr["产品名称34"].ToString());
                dic.Add("产品名称35", dr["产品名称35"].ToString());
                dic.Add("产品名称36", dr["产品名称36"].ToString());
                dic.Add("产品名称37", dr["产品名称37"].ToString());
                dic.Add("产品名称38", dr["产品名称38"].ToString());
                dic.Add("产品名称39", dr["产品名称39"].ToString());
                dic.Add("产品名称40", dr["产品名称40"].ToString());
                dic.Add("产品名称41", dr["产品名称41"].ToString());
                dic.Add("产品名称42", dr["产品名称42"].ToString());
                dic.Add("产品名称43", dr["产品名称43"].ToString());
                dic.Add("产品名称44", dr["产品名称44"].ToString());
                dic.Add("产品名称45", dr["产品名称45"].ToString());
                dic.Add("产品名称46", dr["产品名称46"].ToString());
                dic.Add("产品名称47", dr["产品名称47"].ToString());
                dic.Add("产品名称48", dr["产品名称48"].ToString());
                dic.Add("产品名称49", dr["产品名称49"].ToString());
                dic.Add("产品名称50", dr["产品名称50"].ToString());
                dic.Add("产品名称51", dr["产品名称51"].ToString());
                dic.Add("产品名称52", dr["产品名称52"].ToString());
                dic.Add("产品名称53", dr["产品名称53"].ToString());
                dic.Add("产品名称54", dr["产品名称54"].ToString());
                dic.Add("产品名称55", dr["产品名称55"].ToString());
                dic.Add("产品名称56", dr["产品名称56"].ToString());
                dic.Add("产品名称57", dr["产品名称57"].ToString());
                dic.Add("产品名称58", dr["产品名称58"].ToString());
                dic.Add("产品名称59", dr["产品名称59"].ToString());
                dic.Add("产品名称60", dr["产品名称60"].ToString());
                dic.Add("产品名称61", dr["产品名称61"].ToString());
                dic.Add("产品名称62", dr["产品名称62"].ToString());
                dic.Add("产品名称63", dr["产品名称63"].ToString());
                dic.Add("产品名称64", dr["产品名称64"].ToString());
                dic.Add("产品名称65", dr["产品名称65"].ToString());
                dic.Add("产品名称66", dr["产品名称66"].ToString());
                dic.Add("产品名称67", dr["产品名称67"].ToString());
                dic.Add("产品名称68", dr["产品名称68"].ToString());
                dic.Add("产品名称69", dr["产品名称69"].ToString());
                dic.Add("产品名称70", dr["产品名称70"].ToString());
                dic.Add("产品名称71", dr["产品名称71"].ToString());
                dic.Add("产品名称72", dr["产品名称72"].ToString());
                dic.Add("产品名称73", dr["产品名称73"].ToString());
                dic.Add("产品名称74", dr["产品名称74"].ToString());
                dic.Add("产品名称75", dr["产品名称75"].ToString());
                dic.Add("产品名称76", dr["产品名称76"].ToString());
                dic.Add("产品名称77", dr["产品名称77"].ToString());
                dic.Add("产品名称78", dr["产品名称78"].ToString());
                dic.Add("产品名称79", dr["产品名称79"].ToString());
                dic.Add("产品名称80", dr["产品名称80"].ToString());
                dic.Add("产品名称81", dr["产品名称81"].ToString());
                dic.Add("产品名称82", dr["产品名称82"].ToString());
                dic.Add("产品名称83", dr["产品名称83"].ToString());
                dic.Add("产品名称84", dr["产品名称84"].ToString());
                dic.Add("产品名称85", dr["产品名称85"].ToString());
                dic.Add("产品名称86", dr["产品名称86"].ToString());
                dic.Add("产品名称87", dr["产品名称87"].ToString());
                dic.Add("产品名称88", dr["产品名称88"].ToString());
                dic.Add("产品名称89", dr["产品名称89"].ToString());
                dic.Add("产品名称90", dr["产品名称90"].ToString());
                dic.Add("产品名称91", dr["产品名称91"].ToString());
                dic.Add("产品名称92", dr["产品名称92"].ToString());
                dic.Add("产品名称93", dr["产品名称93"].ToString());
                dic.Add("产品名称94", dr["产品名称94"].ToString());
                dic.Add("产品名称95", dr["产品名称95"].ToString());
                dic.Add("产品名称96", dr["产品名称96"].ToString());
                dic.Add("产品名称97", dr["产品名称97"].ToString());
                dic.Add("产品名称98", dr["产品名称98"].ToString());
                dic.Add("产品名称99", dr["产品名称99"].ToString());
                dic.Add("产品名称100", dr["产品名称100"].ToString());



                dic.Add("数量1", dr["数量1"].ToString());
                dic.Add("数量2", dr["数量2"].ToString());
                dic.Add("数量3", dr["数量3"].ToString());
                dic.Add("数量4", dr["数量4"].ToString());
                dic.Add("数量5", dr["数量5"].ToString());
                dic.Add("数量6", dr["数量6"].ToString());
                dic.Add("数量7", dr["数量7"].ToString());
                dic.Add("数量8", dr["数量8"].ToString());
                dic.Add("数量9", dr["数量9"].ToString());
                dic.Add("数量10", dr["数量10"].ToString());
                dic.Add("数量11", dr["数量11"].ToString());
                dic.Add("数量12", dr["数量12"].ToString());
                dic.Add("数量13", dr["数量13"].ToString());
                dic.Add("数量14", dr["数量14"].ToString());
                dic.Add("数量15", dr["数量15"].ToString());
                dic.Add("数量16", dr["数量16"].ToString());
                dic.Add("数量17", dr["数量17"].ToString());
                dic.Add("数量18", dr["数量18"].ToString());
                dic.Add("数量19", dr["数量19"].ToString());
                dic.Add("数量20", dr["数量20"].ToString());
                dic.Add("数量21", dr["数量21"].ToString());
                dic.Add("数量22", dr["数量22"].ToString());
                dic.Add("数量23", dr["数量23"].ToString());
                dic.Add("数量24", dr["数量24"].ToString());
                dic.Add("数量25", dr["数量25"].ToString());
                dic.Add("数量26", dr["数量26"].ToString());
                dic.Add("数量27", dr["数量27"].ToString());
                dic.Add("数量28", dr["数量28"].ToString());
                dic.Add("数量29", dr["数量29"].ToString());
                dic.Add("数量30", dr["数量30"].ToString());
                dic.Add("数量31", dr["数量31"].ToString());
                dic.Add("数量32", dr["数量32"].ToString());
                dic.Add("数量33", dr["数量33"].ToString());
                dic.Add("数量34", dr["数量34"].ToString());
                dic.Add("数量35", dr["数量35"].ToString());
                dic.Add("数量36", dr["数量36"].ToString());
                dic.Add("数量37", dr["数量37"].ToString());
                dic.Add("数量38", dr["数量38"].ToString());
                dic.Add("数量39", dr["数量39"].ToString());
                dic.Add("数量40", dr["数量40"].ToString());
                dic.Add("数量41", dr["数量41"].ToString());
                dic.Add("数量42", dr["数量42"].ToString());
                dic.Add("数量43", dr["数量43"].ToString());
                dic.Add("数量44", dr["数量44"].ToString());
                dic.Add("数量45", dr["数量45"].ToString());
                dic.Add("数量46", dr["数量46"].ToString());
                dic.Add("数量47", dr["数量47"].ToString());
                dic.Add("数量48", dr["数量48"].ToString());
                dic.Add("数量49", dr["数量49"].ToString());
                dic.Add("数量50", dr["数量50"].ToString());
                dic.Add("数量51", dr["数量51"].ToString());
                dic.Add("数量52", dr["数量52"].ToString());
                dic.Add("数量53", dr["数量53"].ToString());
                dic.Add("数量54", dr["数量54"].ToString());
                dic.Add("数量55", dr["数量55"].ToString());
                dic.Add("数量56", dr["数量56"].ToString());
                dic.Add("数量57", dr["数量57"].ToString());
                dic.Add("数量58", dr["数量58"].ToString());
                dic.Add("数量59", dr["数量59"].ToString());
                dic.Add("数量60", dr["数量60"].ToString());
                dic.Add("数量61", dr["数量61"].ToString());
                dic.Add("数量62", dr["数量62"].ToString());
                dic.Add("数量63", dr["数量63"].ToString());
                dic.Add("数量64", dr["数量64"].ToString());
                dic.Add("数量65", dr["数量65"].ToString());
                dic.Add("数量66", dr["数量66"].ToString());
                dic.Add("数量67", dr["数量67"].ToString());
                dic.Add("数量68", dr["数量68"].ToString());
                dic.Add("数量69", dr["数量69"].ToString());
                dic.Add("数量70", dr["数量70"].ToString());
                dic.Add("数量71", dr["数量71"].ToString());
                dic.Add("数量72", dr["数量72"].ToString());
                dic.Add("数量73", dr["数量73"].ToString());
                dic.Add("数量74", dr["数量74"].ToString());
                dic.Add("数量75", dr["数量75"].ToString());
                dic.Add("数量76", dr["数量76"].ToString());
                dic.Add("数量77", dr["数量77"].ToString());
                dic.Add("数量78", dr["数量78"].ToString());
                dic.Add("数量79", dr["数量79"].ToString());
                dic.Add("数量80", dr["数量80"].ToString());
                dic.Add("数量81", dr["数量81"].ToString());
                dic.Add("数量82", dr["数量82"].ToString());
                dic.Add("数量83", dr["数量83"].ToString());
                dic.Add("数量84", dr["数量84"].ToString());
                dic.Add("数量85", dr["数量85"].ToString());
                dic.Add("数量86", dr["数量86"].ToString());
                dic.Add("数量87", dr["数量87"].ToString());
                dic.Add("数量88", dr["数量88"].ToString());
                dic.Add("数量89", dr["数量89"].ToString());
                dic.Add("数量90", dr["数量90"].ToString());
                dic.Add("数量91", dr["数量91"].ToString());
                dic.Add("数量92", dr["数量92"].ToString());
                dic.Add("数量93", dr["数量93"].ToString());
                dic.Add("数量94", dr["数量94"].ToString());
                dic.Add("数量95", dr["数量95"].ToString());
                dic.Add("数量96", dr["数量96"].ToString());
                dic.Add("数量97", dr["数量97"].ToString());
                dic.Add("数量98", dr["数量98"].ToString());
                dic.Add("数量99", dr["数量99"].ToString());
                dic.Add("数量100", dr["数量100"].ToString());


                dic.Add("单价1", dr["单价1"].ToString());
                dic.Add("单价2", dr["单价2"].ToString());
                dic.Add("单价3", dr["单价3"].ToString());
                dic.Add("单价4", dr["单价4"].ToString());
                dic.Add("单价5", dr["单价5"].ToString());
                dic.Add("单价6", dr["单价6"].ToString());
                dic.Add("单价7", dr["单价7"].ToString());
                dic.Add("单价8", dr["单价8"].ToString());
                dic.Add("单价9", dr["单价9"].ToString());
                dic.Add("单价10", dr["单价10"].ToString());
                dic.Add("单价11", dr["单价11"].ToString());
                dic.Add("单价12", dr["单价12"].ToString());
                dic.Add("单价13", dr["单价13"].ToString());
                dic.Add("单价14", dr["单价14"].ToString());
                dic.Add("单价15", dr["单价15"].ToString());
                dic.Add("单价16", dr["单价16"].ToString());
                dic.Add("单价17", dr["单价17"].ToString());
                dic.Add("单价18", dr["单价18"].ToString());
                dic.Add("单价19", dr["单价19"].ToString());
                dic.Add("单价20", dr["单价20"].ToString());
                dic.Add("单价21", dr["单价21"].ToString());
                dic.Add("单价22", dr["单价22"].ToString());
                dic.Add("单价23", dr["单价23"].ToString());
                dic.Add("单价24", dr["单价24"].ToString());
                dic.Add("单价25", dr["单价25"].ToString());
                dic.Add("单价26", dr["单价26"].ToString());
                dic.Add("单价27", dr["单价27"].ToString());
                dic.Add("单价28", dr["单价28"].ToString());
                dic.Add("单价29", dr["单价29"].ToString());
                dic.Add("单价30", dr["单价30"].ToString());
                dic.Add("单价31", dr["单价31"].ToString());
                dic.Add("单价32", dr["单价32"].ToString());
                dic.Add("单价33", dr["单价33"].ToString());
                dic.Add("单价34", dr["单价34"].ToString());
                dic.Add("单价35", dr["单价35"].ToString());
                dic.Add("单价36", dr["单价36"].ToString());
                dic.Add("单价37", dr["单价37"].ToString());
                dic.Add("单价38", dr["单价38"].ToString());
                dic.Add("单价39", dr["单价39"].ToString());
                dic.Add("单价40", dr["单价40"].ToString());
                dic.Add("单价41", dr["单价41"].ToString());
                dic.Add("单价42", dr["单价42"].ToString());
                dic.Add("单价43", dr["单价43"].ToString());
                dic.Add("单价44", dr["单价44"].ToString());
                dic.Add("单价45", dr["单价45"].ToString());
                dic.Add("单价46", dr["单价46"].ToString());
                dic.Add("单价47", dr["单价47"].ToString());
                dic.Add("单价48", dr["单价48"].ToString());
                dic.Add("单价49", dr["单价49"].ToString());
                dic.Add("单价50", dr["单价50"].ToString());
                dic.Add("单价51", dr["单价51"].ToString());
                dic.Add("单价52", dr["单价52"].ToString());
                dic.Add("单价53", dr["单价53"].ToString());
                dic.Add("单价54", dr["单价54"].ToString());
                dic.Add("单价55", dr["单价55"].ToString());
                dic.Add("单价56", dr["单价56"].ToString());
                dic.Add("单价57", dr["单价57"].ToString());
                dic.Add("单价58", dr["单价58"].ToString());
                dic.Add("单价59", dr["单价59"].ToString());
                dic.Add("单价60", dr["单价60"].ToString());
                dic.Add("单价61", dr["单价61"].ToString());
                dic.Add("单价62", dr["单价62"].ToString());
                dic.Add("单价63", dr["单价63"].ToString());
                dic.Add("单价64", dr["单价64"].ToString());
                dic.Add("单价65", dr["单价65"].ToString());
                dic.Add("单价66", dr["单价66"].ToString());
                dic.Add("单价67", dr["单价67"].ToString());
                dic.Add("单价68", dr["单价68"].ToString());
                dic.Add("单价69", dr["单价69"].ToString());
                dic.Add("单价70", dr["单价70"].ToString());
                dic.Add("单价71", dr["单价71"].ToString());
                dic.Add("单价72", dr["单价72"].ToString());
                dic.Add("单价73", dr["单价73"].ToString());
                dic.Add("单价74", dr["单价74"].ToString());
                dic.Add("单价75", dr["单价75"].ToString());
                dic.Add("单价76", dr["单价76"].ToString());
                dic.Add("单价77", dr["单价77"].ToString());
                dic.Add("单价78", dr["单价78"].ToString());
                dic.Add("单价79", dr["单价79"].ToString());
                dic.Add("单价80", dr["单价80"].ToString());
                dic.Add("单价81", dr["单价81"].ToString());
                dic.Add("单价82", dr["单价82"].ToString());
                dic.Add("单价83", dr["单价83"].ToString());
                dic.Add("单价84", dr["单价84"].ToString());
                dic.Add("单价85", dr["单价85"].ToString());
                dic.Add("单价86", dr["单价86"].ToString());
                dic.Add("单价87", dr["单价87"].ToString());
                dic.Add("单价88", dr["单价88"].ToString());
                dic.Add("单价89", dr["单价89"].ToString());
                dic.Add("单价90", dr["单价90"].ToString());
                dic.Add("单价91", dr["单价91"].ToString());
                dic.Add("单价92", dr["单价92"].ToString());
                dic.Add("单价93", dr["单价93"].ToString());
                dic.Add("单价94", dr["单价94"].ToString());
                dic.Add("单价95", dr["单价95"].ToString());
                dic.Add("单价96", dr["单价96"].ToString());
                dic.Add("单价97", dr["单价97"].ToString());
                dic.Add("单价98", dr["单价98"].ToString());
                dic.Add("单价99", dr["单价99"].ToString());
                dic.Add("单价100", dr["单价100"].ToString());



                dic.Add("总金额1", dr["总金额1"].ToString());
                dic.Add("总金额2", dr["总金额2"].ToString());
                dic.Add("总金额3", dr["总金额3"].ToString());
                dic.Add("总金额4", dr["总金额4"].ToString());
                dic.Add("总金额5", dr["总金额5"].ToString());
                dic.Add("总金额6", dr["总金额6"].ToString());
                dic.Add("总金额7", dr["总金额7"].ToString());
                dic.Add("总金额8", dr["总金额8"].ToString());
                dic.Add("总金额9", dr["总金额9"].ToString());
                dic.Add("总金额10", dr["总金额10"].ToString());
                dic.Add("总金额11", dr["总金额11"].ToString());
                dic.Add("总金额12", dr["总金额12"].ToString());
                dic.Add("总金额13", dr["总金额13"].ToString());
                dic.Add("总金额14", dr["总金额14"].ToString());
                dic.Add("总金额15", dr["总金额15"].ToString());
                dic.Add("总金额16", dr["总金额16"].ToString());
                dic.Add("总金额17", dr["总金额17"].ToString());
                dic.Add("总金额18", dr["总金额18"].ToString());
                dic.Add("总金额19", dr["总金额19"].ToString());
                dic.Add("总金额20", dr["总金额20"].ToString());
                dic.Add("总金额21", dr["总金额21"].ToString());
                dic.Add("总金额22", dr["总金额22"].ToString());
                dic.Add("总金额23", dr["总金额23"].ToString());
                dic.Add("总金额24", dr["总金额24"].ToString());
                dic.Add("总金额25", dr["总金额25"].ToString());
                dic.Add("总金额26", dr["总金额26"].ToString());
                dic.Add("总金额27", dr["总金额27"].ToString());
                dic.Add("总金额28", dr["总金额28"].ToString());
                dic.Add("总金额29", dr["总金额29"].ToString());
                dic.Add("总金额30", dr["总金额30"].ToString());
                dic.Add("总金额31", dr["总金额31"].ToString());
                dic.Add("总金额32", dr["总金额32"].ToString());
                dic.Add("总金额33", dr["总金额33"].ToString());
                dic.Add("总金额34", dr["总金额34"].ToString());
                dic.Add("总金额35", dr["总金额35"].ToString());
                dic.Add("总金额36", dr["总金额36"].ToString());
                dic.Add("总金额37", dr["总金额37"].ToString());
                dic.Add("总金额38", dr["总金额38"].ToString());
                dic.Add("总金额39", dr["总金额39"].ToString());
                dic.Add("总金额40", dr["总金额40"].ToString());
                dic.Add("总金额41", dr["总金额41"].ToString());
                dic.Add("总金额42", dr["总金额42"].ToString());
                dic.Add("总金额43", dr["总金额43"].ToString());
                dic.Add("总金额44", dr["总金额44"].ToString());
                dic.Add("总金额45", dr["总金额45"].ToString());
                dic.Add("总金额46", dr["总金额46"].ToString());
                dic.Add("总金额47", dr["总金额47"].ToString());
                dic.Add("总金额48", dr["总金额48"].ToString());
                dic.Add("总金额49", dr["总金额49"].ToString());
                dic.Add("总金额50", dr["总金额50"].ToString());
                dic.Add("总金额51", dr["总金额51"].ToString());
                dic.Add("总金额52", dr["总金额52"].ToString());
                dic.Add("总金额53", dr["总金额53"].ToString());
                dic.Add("总金额54", dr["总金额54"].ToString());
                dic.Add("总金额55", dr["总金额55"].ToString());
                dic.Add("总金额56", dr["总金额56"].ToString());
                dic.Add("总金额57", dr["总金额57"].ToString());
                dic.Add("总金额58", dr["总金额58"].ToString());
                dic.Add("总金额59", dr["总金额59"].ToString());
                dic.Add("总金额60", dr["总金额60"].ToString());
                dic.Add("总金额61", dr["总金额61"].ToString());
                dic.Add("总金额62", dr["总金额62"].ToString());
                dic.Add("总金额63", dr["总金额63"].ToString());
                dic.Add("总金额64", dr["总金额64"].ToString());
                dic.Add("总金额65", dr["总金额65"].ToString());
                dic.Add("总金额66", dr["总金额66"].ToString());
                dic.Add("总金额67", dr["总金额67"].ToString());
                dic.Add("总金额68", dr["总金额68"].ToString());
                dic.Add("总金额69", dr["总金额69"].ToString());
                dic.Add("总金额70", dr["总金额70"].ToString());
                dic.Add("总金额71", dr["总金额71"].ToString());
                dic.Add("总金额72", dr["总金额72"].ToString());
                dic.Add("总金额73", dr["总金额73"].ToString());
                dic.Add("总金额74", dr["总金额74"].ToString());
                dic.Add("总金额75", dr["总金额75"].ToString());
                dic.Add("总金额76", dr["总金额76"].ToString());
                dic.Add("总金额77", dr["总金额77"].ToString());
                dic.Add("总金额78", dr["总金额78"].ToString());
                dic.Add("总金额79", dr["总金额79"].ToString());
                dic.Add("总金额80", dr["总金额80"].ToString());
                dic.Add("总金额81", dr["总金额81"].ToString());
                dic.Add("总金额82", dr["总金额82"].ToString());
                dic.Add("总金额83", dr["总金额83"].ToString());
                dic.Add("总金额84", dr["总金额84"].ToString());
                dic.Add("总金额85", dr["总金额85"].ToString());
                dic.Add("总金额86", dr["总金额86"].ToString());
                dic.Add("总金额87", dr["总金额87"].ToString());
                dic.Add("总金额88", dr["总金额88"].ToString());
                dic.Add("总金额89", dr["总金额89"].ToString());
                dic.Add("总金额90", dr["总金额90"].ToString());
                dic.Add("总金额91", dr["总金额91"].ToString());
                dic.Add("总金额92", dr["总金额92"].ToString());
                dic.Add("总金额93", dr["总金额93"].ToString());
                dic.Add("总金额94", dr["总金额94"].ToString());
                dic.Add("总金额95", dr["总金额95"].ToString());
                dic.Add("总金额96", dr["总金额96"].ToString());
                dic.Add("总金额97", dr["总金额97"].ToString());
                dic.Add("总金额98", dr["总金额98"].ToString());
                dic.Add("总金额99", dr["总金额99"].ToString());
                dic.Add("总金额100", dr["总金额100"].ToString());


                dic.Add("备注1", dr["备注1"].ToString());
                dic.Add("备注2", dr["备注2"].ToString());
                dic.Add("备注3", dr["备注3"].ToString());
                dic.Add("备注4", dr["备注4"].ToString());
                dic.Add("备注5", dr["备注5"].ToString());
                dic.Add("备注6", dr["备注6"].ToString());
                dic.Add("备注7", dr["备注7"].ToString());
                dic.Add("备注8", dr["备注8"].ToString());
                dic.Add("备注9", dr["备注9"].ToString());
                dic.Add("备注10", dr["备注10"].ToString());
                dic.Add("备注11", dr["备注11"].ToString());
                dic.Add("备注12", dr["备注12"].ToString());
                dic.Add("备注13", dr["备注13"].ToString());
                dic.Add("备注14", dr["备注14"].ToString());
                dic.Add("备注15", dr["备注15"].ToString());
                dic.Add("备注16", dr["备注16"].ToString());
                dic.Add("备注17", dr["备注17"].ToString());
                dic.Add("备注18", dr["备注18"].ToString());
                dic.Add("备注19", dr["备注19"].ToString());
                dic.Add("备注20", dr["备注20"].ToString());
                dic.Add("备注21", dr["备注21"].ToString());
                dic.Add("备注22", dr["备注22"].ToString());
                dic.Add("备注23", dr["备注23"].ToString());
                dic.Add("备注24", dr["备注24"].ToString());
                dic.Add("备注25", dr["备注25"].ToString());
                dic.Add("备注26", dr["备注26"].ToString());
                dic.Add("备注27", dr["备注27"].ToString());
                dic.Add("备注28", dr["备注28"].ToString());
                dic.Add("备注29", dr["备注29"].ToString());
                dic.Add("备注30", dr["备注30"].ToString());
                dic.Add("备注31", dr["备注31"].ToString());
                dic.Add("备注32", dr["备注32"].ToString());
                dic.Add("备注33", dr["备注33"].ToString());
                dic.Add("备注34", dr["备注34"].ToString());
                dic.Add("备注35", dr["备注35"].ToString());
                dic.Add("备注36", dr["备注36"].ToString());
                dic.Add("备注37", dr["备注37"].ToString());
                dic.Add("备注38", dr["备注38"].ToString());
                dic.Add("备注39", dr["备注39"].ToString());
                dic.Add("备注40", dr["备注40"].ToString());
                dic.Add("备注41", dr["备注41"].ToString());
                dic.Add("备注42", dr["备注42"].ToString());
                dic.Add("备注43", dr["备注43"].ToString());
                dic.Add("备注44", dr["备注44"].ToString());
                dic.Add("备注45", dr["备注45"].ToString());
                dic.Add("备注46", dr["备注46"].ToString());
                dic.Add("备注47", dr["备注47"].ToString());
                dic.Add("备注48", dr["备注48"].ToString());
                dic.Add("备注49", dr["备注49"].ToString());
                dic.Add("备注50", dr["备注50"].ToString());
                dic.Add("备注51", dr["备注51"].ToString());
                dic.Add("备注52", dr["备注52"].ToString());
                dic.Add("备注53", dr["备注53"].ToString());
                dic.Add("备注54", dr["备注54"].ToString());
                dic.Add("备注55", dr["备注55"].ToString());
                dic.Add("备注56", dr["备注56"].ToString());
                dic.Add("备注57", dr["备注57"].ToString());
                dic.Add("备注58", dr["备注58"].ToString());
                dic.Add("备注59", dr["备注59"].ToString());
                dic.Add("备注60", dr["备注60"].ToString());
                dic.Add("备注61", dr["备注61"].ToString());
                dic.Add("备注62", dr["备注62"].ToString());
                dic.Add("备注63", dr["备注63"].ToString());
                dic.Add("备注64", dr["备注64"].ToString());
                dic.Add("备注65", dr["备注65"].ToString());
                dic.Add("备注66", dr["备注66"].ToString());
                dic.Add("备注67", dr["备注67"].ToString());
                dic.Add("备注68", dr["备注68"].ToString());
                dic.Add("备注69", dr["备注69"].ToString());
                dic.Add("备注70", dr["备注70"].ToString());
                dic.Add("备注71", dr["备注71"].ToString());
                dic.Add("备注72", dr["备注72"].ToString());
                dic.Add("备注73", dr["备注73"].ToString());
                dic.Add("备注74", dr["备注74"].ToString());
                dic.Add("备注75", dr["备注75"].ToString());
                dic.Add("备注76", dr["备注76"].ToString());
                dic.Add("备注77", dr["备注77"].ToString());
                dic.Add("备注78", dr["备注78"].ToString());
                dic.Add("备注79", dr["备注79"].ToString());
                dic.Add("备注80", dr["备注80"].ToString());
                dic.Add("备注81", dr["备注81"].ToString());
                dic.Add("备注82", dr["备注82"].ToString());
                dic.Add("备注83", dr["备注83"].ToString());
                dic.Add("备注84", dr["备注84"].ToString());
                dic.Add("备注85", dr["备注85"].ToString());
                dic.Add("备注86", dr["备注86"].ToString());
                dic.Add("备注87", dr["备注87"].ToString());
                dic.Add("备注88", dr["备注88"].ToString());
                dic.Add("备注89", dr["备注89"].ToString());
                dic.Add("备注90", dr["备注90"].ToString());
                dic.Add("备注91", dr["备注91"].ToString());
                dic.Add("备注92", dr["备注92"].ToString());
                dic.Add("备注93", dr["备注93"].ToString());
                dic.Add("备注94", dr["备注94"].ToString());
                dic.Add("备注95", dr["备注95"].ToString());
                dic.Add("备注96", dr["备注96"].ToString());
                dic.Add("备注97", dr["备注97"].ToString());
                dic.Add("备注98", dr["备注98"].ToString());
                dic.Add("备注99", dr["备注99"].ToString());
                dic.Add("备注100", dr["备注100"].ToString());

                dic.Add("序号1", dr["序号1"].ToString());
                dic.Add("序号2", dr["序号2"].ToString());
                dic.Add("序号3", dr["序号3"].ToString());
                dic.Add("序号4", dr["序号4"].ToString());
                dic.Add("序号5", dr["序号5"].ToString());
                dic.Add("序号6", dr["序号6"].ToString());
                dic.Add("序号7", dr["序号7"].ToString());
                dic.Add("序号8", dr["序号8"].ToString());
                dic.Add("序号9", dr["序号9"].ToString());
                dic.Add("序号10", dr["序号10"].ToString());
                dic.Add("序号11", dr["序号11"].ToString());
                dic.Add("序号12", dr["序号12"].ToString());
                dic.Add("序号13", dr["序号13"].ToString());
                dic.Add("序号14", dr["序号14"].ToString());
                dic.Add("序号15", dr["序号15"].ToString());
                dic.Add("序号16", dr["序号16"].ToString());
                dic.Add("序号17", dr["序号17"].ToString());
                dic.Add("序号18", dr["序号18"].ToString());
                dic.Add("序号19", dr["序号19"].ToString());
                dic.Add("序号20", dr["序号20"].ToString());
                dic.Add("序号21", dr["序号21"].ToString());
                dic.Add("序号22", dr["序号22"].ToString());
                dic.Add("序号23", dr["序号23"].ToString());
                dic.Add("序号24", dr["序号24"].ToString());
                dic.Add("序号25", dr["序号25"].ToString());
                dic.Add("序号26", dr["序号26"].ToString());
                dic.Add("序号27", dr["序号27"].ToString());
                dic.Add("序号28", dr["序号28"].ToString());
                dic.Add("序号29", dr["序号29"].ToString());
                dic.Add("序号30", dr["序号30"].ToString());
                dic.Add("序号31", dr["序号31"].ToString());
                dic.Add("序号32", dr["序号32"].ToString());
                dic.Add("序号33", dr["序号33"].ToString());
                dic.Add("序号34", dr["序号34"].ToString());
                dic.Add("序号35", dr["序号35"].ToString());
                dic.Add("序号36", dr["序号36"].ToString());
                dic.Add("序号37", dr["序号37"].ToString());
                dic.Add("序号38", dr["序号38"].ToString());
                dic.Add("序号39", dr["序号39"].ToString());
                dic.Add("序号40", dr["序号40"].ToString());
                dic.Add("序号41", dr["序号41"].ToString());
                dic.Add("序号42", dr["序号42"].ToString());
                dic.Add("序号43", dr["序号43"].ToString());
                dic.Add("序号44", dr["序号44"].ToString());
                dic.Add("序号45", dr["序号45"].ToString());
                dic.Add("序号46", dr["序号46"].ToString());
                dic.Add("序号47", dr["序号47"].ToString());
                dic.Add("序号48", dr["序号48"].ToString());
                dic.Add("序号49", dr["序号49"].ToString());
                dic.Add("序号50", dr["序号50"].ToString());
                dic.Add("序号51", dr["序号51"].ToString());
                dic.Add("序号52", dr["序号52"].ToString());
                dic.Add("序号53", dr["序号53"].ToString());
                dic.Add("序号54", dr["序号54"].ToString());
                dic.Add("序号55", dr["序号55"].ToString());
                dic.Add("序号56", dr["序号56"].ToString());
                dic.Add("序号57", dr["序号57"].ToString());
                dic.Add("序号58", dr["序号58"].ToString());
                dic.Add("序号59", dr["序号59"].ToString());
                dic.Add("序号60", dr["序号60"].ToString());
                dic.Add("序号61", dr["序号61"].ToString());
                dic.Add("序号62", dr["序号62"].ToString());
                dic.Add("序号63", dr["序号63"].ToString());
                dic.Add("序号64", dr["序号64"].ToString());
                dic.Add("序号65", dr["序号65"].ToString());
                dic.Add("序号66", dr["序号66"].ToString());
                dic.Add("序号67", dr["序号67"].ToString());
                dic.Add("序号68", dr["序号68"].ToString());
                dic.Add("序号69", dr["序号69"].ToString());
                dic.Add("序号70", dr["序号70"].ToString());
                dic.Add("序号71", dr["序号71"].ToString());
                dic.Add("序号72", dr["序号72"].ToString());
                dic.Add("序号73", dr["序号73"].ToString());
                dic.Add("序号74", dr["序号74"].ToString());
                dic.Add("序号75", dr["序号75"].ToString());
                dic.Add("序号76", dr["序号76"].ToString());
                dic.Add("序号77", dr["序号77"].ToString());
                dic.Add("序号78", dr["序号78"].ToString());
                dic.Add("序号79", dr["序号79"].ToString());
                dic.Add("序号80", dr["序号80"].ToString());
                dic.Add("序号81", dr["序号81"].ToString());
                dic.Add("序号82", dr["序号82"].ToString());
                dic.Add("序号83", dr["序号83"].ToString());
                dic.Add("序号84", dr["序号84"].ToString());
                dic.Add("序号85", dr["序号85"].ToString());
                dic.Add("序号86", dr["序号86"].ToString());
                dic.Add("序号87", dr["序号87"].ToString());
                dic.Add("序号88", dr["序号88"].ToString());
                dic.Add("序号89", dr["序号89"].ToString());
                dic.Add("序号90", dr["序号90"].ToString());
                dic.Add("序号91", dr["序号91"].ToString());
                dic.Add("序号92", dr["序号92"].ToString());
                dic.Add("序号93", dr["序号93"].ToString());
                dic.Add("序号94", dr["序号94"].ToString());
                dic.Add("序号95", dr["序号95"].ToString());
                dic.Add("序号96", dr["序号96"].ToString());
                dic.Add("序号97", dr["序号97"].ToString());
                dic.Add("序号98", dr["序号98"].ToString());
                dic.Add("序号99", dr["序号99"].ToString());
                dic.Add("序号100", dr["序号100"].ToString());

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                    qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
                    string id = Convert.ToString(dt.Rows[i]["id"]);
                    string gonglinghao = Convert.ToString(dt.Rows[i]["接单编号"]);

                    string bianma = Convert.ToString(dt.Rows[i]["机修件ERP"]);
                    string mingcheng1 = Convert.ToString(dt.Rows[i]["工件名称"]);
                    string shuliang = "采购数量："+Convert.ToString(dt.Rows[i]["机修件数量"]);

                    string gongyingshang = txtZerenren1.Text;
                    string hetonghao1 = hetonghao;
                    string dataCode = id + "|" + bianma + "|" + gongyingshang + "|" + hetonghao1 + "|";
                    Image image;
                    string data = dataCode;
                    image = qrCodeEncoder.Encode(data, Encoding.UTF8);


                    System.Drawing.Bitmap newImg;
                    newImg = new Bitmap(image.Width + 200, image.Height+40);

                    Graphics g = Graphics.FromImage(newImg);
                    g.Clear(Color.White);
                    g.DrawImageUnscaled(image, 0, 0);
                    System.Drawing.Font font = new System.Drawing.Font("黑体", 11, FontStyle.Bold);
                    SolidBrush brush = new SolidBrush(Color.Black);
                    g.DrawString(gonglinghao, font, brush, image.Width, 0);
                    g.DrawString(bianma, font, brush, image.Width, 25);
                    g.DrawString(mingcheng1, font, brush, image.Width, 50);
                    g.DrawString(gongyingshang, font, brush, image.Width, 75);
                    g.DrawString(hetonghao1, font, brush, image.Width, 100);
                    g.DrawString(shuliang, font, brush, image.Width, 125);

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
            if (zhonglei == "订货")
            {

                if (txtZerenren1.Text.Trim() == "")
                {
                    MessageBox.Show("请填写供应商名称！");
                    return;

                }
                DataTable dt1 = new DataTable();

                string sql = "select 编号,号码 from tb_dingdanhao where 号码=( select max(号码)from   tb_dingdanhao  where 用户名='" + yonghu + "' ) and 用户名='" + yonghu + "' ";
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
                string heji = zongjia1;

                string sql1 = "select 单位名称,单位地址,法定代表人,委托代理人,电话,传真,税务登记号,开户银行,帐号 from tb_gongfang where 单位名称='" + txtZerenren1.Text.Trim() + "'";
                DataTable daa = SQLhelp.GetDataTable(sql1, CommandType.Text);


                string danweimingcheng = daa.Rows[0][0].ToString();
                string danweidizhi = daa.Rows[0][1].ToString();
                string fadingdaibiaoren = daa.Rows[0][2].ToString();
                string weituodailiren = daa.Rows[0][3].ToString();
                string dianhua = daa.Rows[0][4].ToString();
                string chuanzhen = daa.Rows[0][5].ToString();
                string shuiwudengjihao = daa.Rows[0][6].ToString();
                string kaihuyinhang = daa.Rows[0][7].ToString();
                string zhanghao = daa.Rows[0][8].ToString();


                string sql12 = "select 电话  from tb_operator1 where 用户名='" + yonghu + "'";
                string caigoudianhua = Convert.ToString(SQLhelp.ExecuteScalar(sql12, CommandType.Text));

                dt1.Columns.Add("公司", typeof(string));
                dt1.Columns.Add("委托代理人", typeof(string));
                dt1.Columns.Add("电话", typeof(string));
                dt1.Columns.Add("传真", typeof(string));
                dt1.Columns.Add("订单编号", typeof(string));
                dt1.Columns.Add("发件人", typeof(string));
                dt1.Columns.Add("日期", typeof(string));
                dt1.Columns.Add("合计", typeof(string));
                dt1.Columns.Add("经办人", typeof(string));
                dt1.Columns.Add("最终日期", typeof(string));

                for (int i = 0; i < 100; i++)
                {
                    dt1.Columns.Add("单位"+(i+1), typeof(string));
                
                }
                for (int i = 0; i < 100; i++)
                {
                    dt1.Columns.Add("ERP" + (i + 1), typeof(string));

                }
                for (int i = 0; i < 100; i++)
                {
                    dt1.Columns.Add("产品名称" + (i + 1), typeof(string));

                }

                for (int i = 0; i < 100; i++)
                {
                    dt1.Columns.Add("数量" + (i + 1), typeof(string));

                }
                for (int i = 0; i < 100; i++)
                {
                    dt1.Columns.Add("单价" + (i + 1), typeof(string));

                }

                for (int i = 0; i < 100; i++)
                {
                    dt1.Columns.Add("总金额" + (i + 1), typeof(string));

                }
                for (int i = 0; i < 100; i++)
                {
                    dt1.Columns.Add("备注" + (i + 1), typeof(string));

                }
               
                for (int i = 0; i < 100; i++)
                {
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
                }

                dr1["公司"] = danweimingcheng;
                dr1["委托代理人"] = weituodailiren;
                dr1["电话"] = dianhua;
                dr1["传真"] = chuanzhen;
                dr1["订单编号"] = hetonghao;
                dr1["发件人"] = yonghu;
                dr1["日期"] = DateTime.Now.ToString("yyyy年MM月dd日");
                dr1["合计"] = zongjia1;
                dr1["经办人"] = yonghu;
                dr1["最终日期"] = DateTime.Now.ToString("yyyy年MM月dd日");

                dt1.Rows.Add(dr1);

                string tempFile = Application.StartupPath + "\\订货通知单模板.doc";
                Document doc = new Document(tempFile);
                DocumentBuilder builder = new DocumentBuilder(doc);
                NodeCollection allTables = doc.GetChildNodes(NodeType.Table, true);

                Dictionary<string, string> dic = new Dictionary<string, string>();
                DataRow dr = dt1.Rows[0];



                dic.Add("公司", dr["公司"].ToString());
                dic.Add("委托代理人", dr["委托代理人"].ToString());
                dic.Add("电话", dr["电话"].ToString());
                dic.Add("传真", dr["传真"].ToString());
                dic.Add("订单编号", dr["订单编号"].ToString());
                dic.Add("发件人", dr["发件人"].ToString());
                dic.Add("日期", dr["日期"].ToString());
                dic.Add("合计", dr["合计"].ToString());
                dic.Add("经办人", dr["经办人"].ToString());
                dic.Add("最终日期", dr["最终日期"].ToString());


                for (int i = 0; i < 100; i++)
                {
                    dic.Add("ERP" + (i + 1), dr["ERP" + (i + 1)].ToString());

                }
                for (int i = 0; i < 100; i++)
                {
                    dic.Add("单位" + (i + 1), dr["单位" + (i + 1)].ToString());

                }

                for (int i = 0; i < 100; i++)
                {
                    dic.Add("产品名称" + (i + 1), dr["产品名称" + (i + 1)].ToString());

                }
                for (int i = 0; i < 100; i++)
                {
                    dic.Add("数量" + (i + 1), dr["数量" + (i + 1)].ToString());

                }
                for (int i = 0; i < 100; i++)
                {
                    dic.Add("单价" + (i + 1), dr["单价" + (i + 1)].ToString());

                }

                for (int i = 0; i < 100; i++)
                {
                    dic.Add("总金额" + (i + 1), dr["总金额" + (i + 1)].ToString());

                }
                for (int i = 0; i < 100; i++)
                {
                    dic.Add("备注" + (i + 1), dr["备注" + (i + 1)].ToString());

                }

                for (int i = 0; i < 100; i++)
                {
                    dic.Add("序号" + (i + 1), dr["序号" + (i + 1)].ToString());

                }
                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                    qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
                    string id = Convert.ToString(dt.Rows[i]["id"]);
                    string gonglinghao = Convert.ToString(dt.Rows[i]["接单编号"]);

                    string bianma = Convert.ToString(dt.Rows[i]["机修件ERP"]);
                    string mingcheng1 = Convert.ToString(dt.Rows[i]["工件名称"]);
                    string shuliang= "采购数量:"+Convert.ToString(dt.Rows[i]["机修件数量"]);

                    string gongyingshang = txtZerenren1.Text;
                    string hetonghao1 = hetonghao;
                    string dataCode = id + "|" + bianma + "|" + gongyingshang + "|" + hetonghao1 + "|";
                    Image image;
                    string data = dataCode;
                    image = qrCodeEncoder.Encode(data, Encoding.UTF8);


                    System.Drawing.Bitmap newImg;
                    newImg = new Bitmap(image.Width + 200, image.Height+40);

                    Graphics g = Graphics.FromImage(newImg);
                    g.Clear(Color.White);
                    g.DrawImageUnscaled(image, 0, 0);
                    System.Drawing.Font font = new System.Drawing.Font("黑体", 11, FontStyle.Bold);
                    SolidBrush brush = new SolidBrush(Color.Black);
                    g.DrawString(gonglinghao, font, brush, image.Width, 0);
                    g.DrawString(bianma, font, brush, image.Width, 25);
                    g.DrawString(mingcheng1, font, brush, image.Width, 50);
                    g.DrawString(gongyingshang, font, brush, image.Width, 75);
                    g.DrawString(hetonghao1, font, brush, image.Width, 100);
                    g.DrawString(shuliang, font, brush, image.Width, 125);

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
    }
}
