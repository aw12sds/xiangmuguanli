using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using Aspose.Words;
using System.IO;

namespace 项目管理系统.个人管理
{
    public partial class Frwuliaoshenqingdan : DevExpress.XtraEditors.XtraForm
    {
        public Frwuliaoshenqingdan(string yonghu)
        {
            InitializeComponent();
            this.yonghu = yonghu;
        }
        public DataTable dt;
        public string yonghu;
        public string liushuihao="";
        private void Frwuliaoshenqingdan_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string id = dt.Rows[i]["id"].ToString();

                string sql1 = "select 库位号 from tb_ruku where 定位='" + id + "'";
                string kuweihao = SQLhelp.ExecuteScalar(sql1, CommandType.Text).ToString();
                dt.Rows[i]["库位号"] = kuweihao;


            }
            gridControl4.DataSource = dt;
            for (int i = 0; i < gridView4.RowCount; i++)
            {
                string aa = "0";

                this.gridView4.SetRowCellValue(i, gridView4.Columns["输入待领用数量"], aa);
            }

        }

        private void 生成WORD文档ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //    gridView4.OptionsPrint.AutoWidth = false;
            //    PrintPreview(this.gridControl4);
        }

        private void gridView4_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }
        string liushuihaokaitou;

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (comboBoxEdit1.Text.Trim() == "")
            {
                MessageBox.Show("请选择领用部门！");
                return;
            }
            if (txtshenqingren.Text.Trim() == "")
            {
                MessageBox.Show("请填写申请人");
                return;
            }
            if (txtmiaoshu.Text.Trim() == "")
            {
                MessageBox.Show("请填写描述！如果是项目的请归结到项目成本！");
                return;
            }
            string sql111 = "select 部门 from tb_operator where 用户名='" + txtshenqingren.Text.Trim() + "'";
            string bumen = Convert.ToString(sqlhelp111.ExecuteScalar(sql111, CommandType.Text));
            if (bumen == "")
            {
                MessageBox.Show("该员工不存在！");
                return;
            }
            if (bumen == "线缆事业部")
            {
                liushuihaokaitou = "XL";
            }
            if (bumen == "石英事业部")
            {
                liushuihaokaitou = "SY";
            }
            if (bumen == "薄材事业部")
            {
                liushuihaokaitou = "BC";
            }
            if (bumen == "智能事业部")
            {
                liushuihaokaitou = "ZN";
            }
            if (bumen == "新材事业部")
            {
                liushuihaokaitou = "XC";
            }
            if (bumen == "精工事业部")
            {
                liushuihaokaitou = "JG";
            }
            if (bumen == "模具事业部")
            {
                liushuihaokaitou = "MJ";

            }
            if (bumen == "信息化事业部")
            {
                liushuihaokaitou = "XX";
            }
            if (bumen == "人力资源部")
            {
                liushuihaokaitou = "RL";
            }
            if (bumen == "物流部")
            {
                liushuihaokaitou = "WL";
            }
            if (bumen == "办公室")
            {
                liushuihaokaitou = "BG";
            }
            if (bumen == "市场部")
            {
                liushuihaokaitou = "SC";
            }
            if (bumen == "仓库")
            {
                liushuihaokaitou = "CK";
            }
            if (bumen == "财务部")
            {
                liushuihaokaitou = "CW";
            }
            if (bumen == "研发部")
            {
                liushuihaokaitou = "YF";
            }
            if (bumen == "总经办")
            {
                liushuihaokaitou = "ZJB";
            }
            if (bumen == "质监部")
            {
                liushuihaokaitou = "ZJ";
            }
            liushuihao = liushuihaokaitou + DateTime.Now.ToString("yyyyMMddHHmmss");

            for (int i = 0; i < gridView4.RowCount; i++)
            {
                string a = Convert.ToString(gridView4.GetRowCellValue(i, "输入待领用数量"));
                double b = Convert.ToDouble(gridView4.GetRowCellValue(i, "库存数量"));
                string id = Convert.ToString(gridView4.GetRowCellValue(i, "id"));

                String sqlkucun = "Select 库存数量,领用登记数量,实际采购数量,出库数量 From tb_caigouliaodan  Where id='" + id + "'";
                DataTable dt2 = SQLhelp.GetDataTable(sqlkucun, CommandType.Text);
                string 领用登记数量 = dt2.Rows[0]["领用登记数量"].ToString();
                string 出库数量 = dt2.Rows[0]["出库数量"].ToString();
                if (领用登记数量 == "")
                {
                    领用登记数量 = '0'+"";
                }
                if (出库数量 == "")
                {
                    出库数量 = '0' + "";
                }
                string 库存数量 = dt2.Rows[0]["库存数量"].ToString();

                if (a.Trim() == "")
                {
                    MessageBox.Show("请输入待领用数量!");
                    return;
                }

                double aaa = Convert.ToDouble(a);
                if (aaa <= 0)
                {
                    MessageBox.Show("请输入大于0的数字！");
                    return;
                }
                if (aaa > b)
                {
                    MessageBox.Show("输入的数量大于能领用的数量！");
                    return;

                }
                float 累加数量 = Convert.ToSingle(领用登记数量) + Convert.ToSingle(a);
                
                if (累加数量 > Convert.ToSingle(库存数量)+ Convert.ToSingle(出库数量))
                {
                    MessageBox.Show("不能大于库存数量！");
                    return;
                }
            }


            for (int i = 0; i < gridView4.RowCount; i++)
            {
                double a = Convert.ToDouble(gridView4.GetRowCellValue(i, "输入待领用数量"));
                double b = Convert.ToDouble(gridView4.GetRowCellValue(i, "id"));
                string gongzuolinghao = Convert.ToString(gridView4.GetRowCellValue(i, "工作令号"));
                string lingyongdengji = Convert.ToString(gridView4.GetRowCellValue(i, "领用登记数量"));
                string id = Convert.ToString(gridView4.GetRowCellValue(i, "id"));
                string xiangmumingcheng = Convert.ToString(gridView4.GetRowCellValue(i, "项目名称"));
                string shebeimingcheng = Convert.ToString(gridView4.GetRowCellValue(i, "设备名称"));
                string bianma = Convert.ToString(gridView4.GetRowCellValue(i, "编码"));
                string xinghao = Convert.ToString(gridView4.GetRowCellValue(i, "型号"));
                string mingcheng1 = Convert.ToString(gridView4.GetRowCellValue(i, "名称"));
                string lingyong = Convert.ToString(gridView4.GetRowCellValue(i, "输入待领用数量"));
                string shijian = Convert.ToString(gridView4.GetRowCellValue(i, "申请时间"));
                string hetonghao= Convert.ToString(gridView4.GetRowCellValue(i, "合同号"));
                string kuweihao= Convert.ToString(gridView4.GetRowCellValue(i, "库位号"));


                string liaodanleixing = Convert.ToString(gridView4.GetRowCellValue(i, "料单类型"));
                string shenqingren = Convert.ToString(gridView4.GetRowCellValue(i, "申请人"));
                if (lingyongdengji == "")
                {
                    string sql11 = "update tb_caigouliaodan set 领用登记数量='" + a + "' where id='" + b + "' ";
                    SQLhelp.ExecuteScalar(sql11, CommandType.Text);
                }
                if (lingyongdengji != "")
                {
                    string sql = "update tb_caigouliaodan set 领用登记数量=领用登记数量+'" + a + "' where id='" + b + "' ";
                    SQLhelp.ExecuteScalar(sql, CommandType.Text);
                }
                string sql12 = "insert into tb_lingyong (工作令号,项目名称,设备名称,编码,型号,名称,领用数量,申请时间,定位,流水号,料单类型,申请人,出库,描述,开单人,库位号,合同号,领用部门)  values ('" + gongzuolinghao + "','" + xiangmumingcheng + "','" + shebeimingcheng + "','" + bianma + "','" + xinghao + "','" + mingcheng1 + "','" + lingyong + "','" + DateTime.Now + "','" + id + "','" + liushuihao + "','" + liaodanleixing + "','" + txtshenqingren.Text + "',0,'" + txtmiaoshu.Text + "','" + yonghu + "','" + kuweihao + "','" + hetonghao + "','" + comboBoxEdit1.Text + "')";
                SQLhelp.ExecuteScalar(sql12, CommandType.Text);

            }


            DataTable dt1 = new DataTable();
            dt1.Columns.Add("创建日期", typeof(string));
            dt1.Columns.Add("申请号" , typeof(string));
            dt1.Columns.Add("申请部门", typeof(string));
            dt1.Columns.Add("申请人", typeof(string));

            for (int i = 0; i < 100; i++)
            {
                dt1.Columns.Add("单位" + (i + 1), typeof(string));
              
                dt1.Columns.Add("工令号" + (i + 1), typeof(string));
                dt1.Columns.Add("规格型号" + (i + 1), typeof(string));
                dt1.Columns.Add("数量" + (i + 1), typeof(string));
                dt1.Columns.Add("库位号" + (i + 1), typeof(string));
                dt1.Columns.Add("备注" + (i + 1), typeof(string));
                dt1.Columns.Add("序号" + (i + 1), typeof(string));
                dt1.Columns.Add("类型" + (i + 1), typeof(string));
            }
            DataRow dr1 = dt1.NewRow();
            dr1["创建日期"] = DateTime.Now.ToLongDateString();
            dr1["申请号"] = liushuihao;
            dr1["申请部门"] = bumen;
            dr1["申请人"] = txtshenqingren.Text;
            for (int i = 0; i < gridView4.RowCount; i++)
            {
                dr1["序号" + (i + 1)] = i + 1;
                dr1["备注" + (i + 1)] = Convert.ToString(gridView4.GetRowCellValue(i, "工作令号"));
                dr1["类型" + (i + 1)] = Convert.ToString(gridView4.GetRowCellValue(i, "编码"));            
                dr1["规格型号" + (i + 1)] = Convert.ToString(gridView4.GetRowCellValue(i, "名称"));
                dr1["单位" + (i + 1)] = Convert.ToString(gridView4.GetRowCellValue(i, "型号"));
                dr1["数量" + (i + 1)] = Convert.ToString(gridView4.GetRowCellValue(i, "输入待领用数量"));
                dr1["工令号" + (i + 1)] = Convert.ToString(gridView4.GetRowCellValue(i, "项目名称")) + "  " + Convert.ToString(gridView4.GetRowCellValue(i, "设备名称"));
                dr1["库位号" + (i + 1)] = Convert.ToString(gridView4.GetRowCellValue(i, "库位号"));
            }
            dt1.Rows.Add(dr1);
            string tempFile = "";
            if (gridView4.RowCount < 6)
            {
                tempFile = Application.StartupPath + "\\领料单少.doc";
            }
            if (gridView4.RowCount > 5)
            {
                tempFile = Application.StartupPath + "\\领料单.doc";
            }
            Aspose.Words.Document doc = new Aspose.Words.Document(tempFile);
            DocumentBuilder builder = new DocumentBuilder(doc);
            NodeCollection allTables = doc.GetChildNodes(NodeType.Table, true);
            Dictionary<string, string> dic = new Dictionary<string, string>();
            DataRow dr = dt1.Rows[0];           
            for (int i = 0; i < 100; i++)
            {               
                dic.Add("类型" + (i + 1), dr["类型" + (i + 1)].ToString());
                dic.Add("工令号" + (i + 1), dr["工令号" + (i + 1)].ToString());
                dic.Add("规格型号" + (i + 1), dr["规格型号" + (i + 1)].ToString());
                dic.Add("数量" + (i + 1), dr["数量" + (i + 1)].ToString());
                dic.Add("单位" + (i + 1), dr["单位" + (i + 1)].ToString());
                dic.Add("备注" + (i + 1), dr["备注" + (i + 1)].ToString());
                dic.Add("序号" + (i + 1), dr["序号" + (i + 1)].ToString());
                dic.Add("库位号" + (i + 1), dr["库位号" + (i + 1)].ToString());
            }
            dic.Add("创建日期" , dr["创建日期"].ToString());
            dic.Add("申请号", dr["申请号"].ToString());
            dic.Add("申请部门" , dr["申请部门"].ToString());
            dic.Add("申请人", dr["申请人"].ToString());
            foreach (var key in dic.Keys)
            {
                builder.MoveToBookmark(key);
                builder.Write(dic[key]);
            }
            Random suiji = new Random();
            int n = suiji.Next(0, 1000);
            string mingcheng = txtshenqingren.Text + DateTime.Now.ToString("yyyy-MM-dd") + "领料单" + n + ".doc";
            FileInfo info1 = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\" + mingcheng);
            string fileName11 = info1.Name.ToString();
            string floderName = fileName11.Substring(0, fileName11.Length - 4).ToString();
            doc.Save(info1.DirectoryName + "\\" + fileName11);
            string pathfilesave = info1.DirectoryName + "\\" + mingcheng;
            MessageBox.Show("已匹配料单,并将领料单保存到桌面！");
            System.Diagnostics.Process.Start(pathfilesave);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

      
        private void txtshenqingren_TextChanged(object sender, EventArgs e)
        {

            if (!txtshenqingren.Text.Contains("\r\n"))
            {

                listBox1.Items.Clear();//先清空一下这个控件的值.  不然就会造成文本框里不输时,这里面全部都是值

                string sql = "select 用户名 from tb_operator ";
                DataTable dt = sqlhelp111.GetDataTable(sql, CommandType.Text);

                int b = txtshenqingren.Text.LastIndexOf(";");

                if (b != -1)
                {
                    string jiequ = txtshenqingren.Text.Substring(b + 1);


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

                DataRow[] dr = dt.Select("用户名 like'%" + txtshenqingren.Text + "%'");
                DataTable newdt = new DataTable(); //再新创建一个表,
                newdt = dt.Clone();//复制dt表的所有结构

                foreach (DataRow row in dr)
                {
                    newdt.Rows.Add(row.ItemArray);
                }

                if (newdt.Rows.Count > 0 && (txtshenqingren.Text != ""))
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

        private void txtshenqingren_KeyUp(object sender, KeyEventArgs e)
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

                int i =txtshenqingren.Text.LastIndexOf(";");
                if (i == -1)
                {
                    string chongxin = "";
                    chongxin = this.listBox1.SelectedItem.ToString();//把选中的值给文本框
                   txtshenqingren.Text = chongxin;
                    this.txtshenqingren.SelectionStart = this.txtshenqingren.TextLength;
                    listBox1.Visible = false;//隐藏这个控件

                }
                if (i != -1)
                {
                    string jiequ = txtshenqingren.Text.Substring(0, i + 1);

                   txtshenqingren.Text = jiequ + this.listBox1.SelectedItem.ToString() + ";";
                    this.txtshenqingren.SelectionStart = this.txtshenqingren.TextLength;
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

            int i = txtshenqingren.Text.LastIndexOf(";");
            if (i == -1)
            {
                string chongxin = "";
                chongxin = this.listBox1.SelectedItem.ToString();//把选中的值给文本框
                txtshenqingren.Text = chongxin;
                this.txtshenqingren.SelectionStart = this.txtshenqingren.TextLength;
                listBox1.Visible = false;//隐藏这个控件

            }
            if (i != -1)
            {
                string jiequ = txtshenqingren.Text.Substring(0, i + 1);

               txtshenqingren.Text = jiequ + this.listBox1.SelectedItem.ToString() + ";";
                this.txtshenqingren.SelectionStart = this.txtshenqingren.TextLength;
                listBox1.Visible = false;//隐藏这个控件
            }
        }
    }
}