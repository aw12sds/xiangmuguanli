using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Aspose.Cells;

namespace 项目管理系统.项目总览
{
    public partial class Frkongjian1 : UserControl
    {
        public Frkongjian1()
        {
            InitializeComponent();
            
        }
        public string yonghu;
        public DataTable dtt;
        public string gonglinghao;
        public string xiangmu;
        public string shebei;
        public DataTable dt;     
        public string shuliang11;
        public int a;
        public string name;
        private long fileSize = 0;//文件大小
        private string fileName = null;//文件名字
        private string fileType = null;//文件类型
        private byte[] files;//文件
        private BinaryReader read = null;//二进制读取
        public string mingcheng;
        DataTable dttt;
        private void Frkongjian1_Load(object sender, EventArgs e)
        {
            //string  sql="select "
            Reload();
        }
        public void Reload()
        {
            for (int i = 0; i < dtt.Rows.Count; i++)
            {
                string gonglinghao = dtt.Rows[i]["客户名称"].ToString();
                string jikuhumingcheng = dtt.Rows[i]["交货日期"].ToString();
                string riqi = Convert.ToDateTime(jikuhumingcheng).ToString("yyyy-MM-dd");
                string aaaaa = dtt.Rows[i]["工作令号"].ToString().Trim();
                dtt.Rows[i]["工作令号"] = aaaaa + "                " + "客户名称：" + gonglinghao + "               " + "交货日期：" + riqi;
            }
           
            gridControl1.DataSource = dtt;
            dttt = dtt;
          
           
        }
        private void buttonItem1_Click(object sender, EventArgs e)
        {
            //dtt.Clear();
            //if (comboBoxItem1.Text == "线缆事业部")
            //{

            //    string sql = "select  id,工作令号,项目名称,客户名称,交货日期,反馈,项目负责人,采购负责人,装配负责人,完成进度 from tb_xiangmu where 项目主管='张炎兵' and 未交货项目=1 and 维修 is null";

            //    dtt = SQLhelp.GetDataTable(sql, CommandType.Text);

            //    for (int i = 0; i < dtt.Rows.Count; i++)
            //    {
            //        string gonglinghao = dtt.Rows[i]["客户名称"].ToString();
            //        string jikuhumingcheng = dtt.Rows[i]["交货日期"].ToString();
            //        string riqi = Convert.ToDateTime(jikuhumingcheng).ToString("yyyy-MM-dd");
            //        string aaaaa = dtt.Rows[i]["工作令号"].ToString().Trim();
            //        dtt.Rows[i]["工作令号"] = aaaaa + "               " + "客户名称：" + gonglinghao + "               " + "交货日期：" + riqi;                    
            //    }
            //    gridControl1.DataSource = dtt;

            //}
            //if (comboBoxItem1.Text == "精工事业部")
            //{

            //    string sql = "select  id,工作令号,项目名称,客户名称,交货日期,反馈,项目负责人,采购负责人,装配负责人,完成进度 from tb_xiangmu where 项目主管='袁鹏' and 未交货项目=1 and 维修 is null";

            //    dtt = SQLhelp.GetDataTable(sql, CommandType.Text);

            //    for (int i = 0; i < dtt.Rows.Count; i++)
            //    {
            //        string gonglinghao = dtt.Rows[i]["客户名称"].ToString();
            //        string jikuhumingcheng = dtt.Rows[i]["交货日期"].ToString();
            //        string riqi = Convert.ToDateTime(jikuhumingcheng).ToString("yyyy-MM-dd");
            //        string aaaaa = dtt.Rows[i]["工作令号"].ToString().Trim();
            //        dtt.Rows[i]["工作令号"] = aaaaa + "              " + "客户名称：" + gonglinghao + "               " + "交货日期：" + riqi;



            //    }
            //    gridControl1.DataSource = dtt;


            //}
            //if (comboBoxItem1.Text == "石英事业部")
            //{
            //    string sql = "select  id,工作令号,项目名称,客户名称,交货日期,反馈,项目负责人,采购负责人,装配负责人,完成进度 from tb_xiangmu where 项目主管='蒋云' and 未交货项目=1 and 维修 is null";

            //    dtt = SQLhelp.GetDataTable(sql, CommandType.Text);

            //    for (int i = 0; i < dtt.Rows.Count; i++)
            //    {
            //        string gonglinghao = dtt.Rows[i]["客户名称"].ToString();
            //        string jikuhumingcheng = dtt.Rows[i]["交货日期"].ToString();
            //        string riqi = Convert.ToDateTime(jikuhumingcheng).ToString("yyyy-MM-dd");
            //        string aaaaa = dtt.Rows[i]["工作令号"].ToString().Trim();
            //        dtt.Rows[i]["工作令号"] = aaaaa + "              " + "客户名称：" + gonglinghao + "               " + "交货日期：" + riqi;



            //    }
            //    gridControl1.DataSource = dtt;

            //}
            //if (comboBoxItem1.Text == "新材事业部")
            //{
            //    string sql = "select  id,工作令号,项目名称,客户名称,交货日期,反馈,项目负责人,采购负责人,装配负责人,完成进度 from tb_xiangmu where 项目主管='沈维佳' and 未交货项目=1 and 维修 is null";

            //    dtt = SQLhelp.GetDataTable(sql, CommandType.Text);

            //    for (int i = 0; i < dtt.Rows.Count; i++)
            //    {
            //        string gonglinghao = dtt.Rows[i]["客户名称"].ToString();
            //        string jikuhumingcheng = dtt.Rows[i]["交货日期"].ToString();
            //        string riqi = Convert.ToDateTime(jikuhumingcheng).ToString("yyyy-MM-dd");
            //        string aaaaa = dtt.Rows[i]["工作令号"].ToString().Trim();
            //        dtt.Rows[i]["工作令号"] = aaaaa + "              " + "客户名称：" + gonglinghao + "               " + "交货日期：" + riqi;



            //    }
            //    gridControl1.DataSource = dtt;

            //}
            //if (comboBoxItem1.Text == "薄材事业部")
            //{
            //    string sql = "select  id,工作令号,项目名称,客户名称,交货日期,反馈,项目负责人,采购负责人,装配负责人,完成进度 from tb_xiangmu where 项目主管='曹伟伟' and 未交货项目=1 and 维修 is null";

            //    dtt = SQLhelp.GetDataTable(sql, CommandType.Text);

            //    for (int i = 0; i < dtt.Rows.Count; i++)
            //    {
            //        string gonglinghao = dtt.Rows[i]["客户名称"].ToString();
            //        string jikuhumingcheng = dtt.Rows[i]["交货日期"].ToString();
            //        string riqi = Convert.ToDateTime(jikuhumingcheng).ToString("yyyy-MM-dd");
            //        string aaaaa = dtt.Rows[i]["工作令号"].ToString().Trim();
            //        dtt.Rows[i]["工作令号"] = aaaaa + "              " + "客户名称：" + gonglinghao + "               " + "交货日期：" + riqi;



            //    }
            //    gridControl1.DataSource = dtt;


            //}
            //if (comboBoxItem1.Text == "智能事业部")
            //{
            //    string sql = "select  id,工作令号,项目名称,客户名称,交货日期,反馈,项目负责人,采购负责人,装配负责人,完成进度 from tb_xiangmu where 项目主管='蔡守军' and 未交货项目=1 and 维修 is null";

            //    dtt = SQLhelp.GetDataTable(sql, CommandType.Text);

            //    for (int i = 0; i < dtt.Rows.Count; i++)
            //    {
            //        string gonglinghao = dtt.Rows[i]["客户名称"].ToString();
            //        string jikuhumingcheng = dtt.Rows[i]["交货日期"].ToString();
            //        string riqi = Convert.ToDateTime(jikuhumingcheng).ToString("yyyy-MM-dd");
            //        string aaaaa = dtt.Rows[i]["工作令号"].ToString().Trim();
            //        dtt.Rows[i]["工作令号"] = aaaaa + "             " + "客户名称：" + gonglinghao + "               " + "交货日期：" + riqi;



            //    }
            //    gridControl1.DataSource = dtt;
            //}
        }

        private void 查看合同ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }
            string a = "";
            string b = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号"));
            if (b.Length > 5)
            {
                string bb = b.Substring(0, 20);
                a = bb.Trim();
            }
            if (a != "")
            {
                string gongzuolingaho = a;
                string xiangmumingcheng = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "项目名称").ToString();

                string sql1 = "Select 合同类型 From tb_xiangmu  Where 工作令号='" + gongzuolingaho + "' and  项目名称='" + xiangmumingcheng + "' ";
                string hetongleixing = SQLhelp.ExecuteScalar(sql1, CommandType.Text).ToString();

                string sql2 = "Select 合同名称 From tb_xiangmu  Where 工作令号='" + gongzuolingaho + "' and  项目名称='" + xiangmumingcheng + "' ";
                string hetongmingcheng = SQLhelp.ExecuteScalar(sql2, CommandType.Text).ToString();

                string sql = "Select 合同 From tb_xiangmu  Where 工作令号='" + gongzuolingaho + "' and  项目名称='" + xiangmumingcheng + "' ";
                byte[] mypdffile = null;
                mypdffile = SQLhelp.duqu(sql, CommandType.Text);


                string aaaa = System.Environment.CurrentDirectory;
                string lujing = aaaa + "\\" + hetongmingcheng + "." + hetongleixing;
                FileStream fs = new FileStream(lujing, FileMode.Create);
                fs.Write(mypdffile, 0, mypdffile.Length);
                fs.Flush();
                fs.Close();


                System.Diagnostics.Process.Start(lujing);
            }

        }

        private void 查看里程碑计划表ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (gridView1.RowCount <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }
            string a = "";
            string b = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号"));
            if (b.Length > 5)
            {
                string bb = b.Substring(0, 20);
                a = bb.Trim();
            }
            if (a != "")
            {
                string gongzuolingaho = a;
                string xiangmumingcheng = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "项目名称").ToString();

                string sql1 = "Select 里程碑计划表类型 From tb_xiangmu  Where 工作令号='" + gongzuolingaho + "' and  项目名称='" + xiangmumingcheng + "' ";
                string hetongleixing = SQLhelp.ExecuteScalar(sql1, CommandType.Text).ToString();

                string sql2 = "Select 里程碑计划表名称 From tb_xiangmu  Where 工作令号='" + gongzuolingaho + "' and  项目名称='" + xiangmumingcheng + "' ";
                string hetongmingcheng = SQLhelp.ExecuteScalar(sql2, CommandType.Text).ToString();

                string sql = "Select 里程碑计划表 From tb_xiangmu  Where 工作令号='" + gongzuolingaho + "' and  项目名称='" + xiangmumingcheng + "' ";
                byte[] mypdffile = null;
                mypdffile = SQLhelp.duqu(sql, CommandType.Text);


                string aaaa = System.Environment.CurrentDirectory;
                string lujing = aaaa + "\\" + hetongmingcheng + "." + hetongleixing;
                FileStream fs = new FileStream(lujing, FileMode.Create);
                fs.Write(mypdffile, 0, mypdffile.Length);
                fs.Flush();
                fs.Close();


                System.Diagnostics.Process.Start(lujing);
            }
        }

        private void 下载生产任务书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }
            string a = "";
            string b = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号"));
            if (b.Length > 5)
            {
                string bb = b.Substring(0, 20);
                a = bb.Trim();
            }
            if (a != "")
            {
                string gongzuolingaho = a;
                string xiangmumingcheng = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "项目名称").ToString();

                string sql1 = "Select 生产任务书类型 From tb_xiangmu  Where 工作令号='" + gongzuolingaho + "' and  项目名称='" + xiangmumingcheng + "' ";
                string hetongleixing = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));

                if (hetongleixing == "")
                {
                    MessageBox.Show("没有生产任务书！");
                    return;

                }

                string sql2 = "Select 生产任务书名称 From tb_xiangmu  Where 工作令号='" + gongzuolingaho + "' and  项目名称='" + xiangmumingcheng + "' ";
                string hetongmingcheng = SQLhelp.ExecuteScalar(sql2, CommandType.Text).ToString();

                string sql = "Select 生产任务书 From tb_xiangmu  Where 工作令号='" + gongzuolingaho + "' and  项目名称='" + xiangmumingcheng + "' ";
                byte[] mypdffile = null;
                mypdffile = SQLhelp.duqu(sql, CommandType.Text);


                string aaaa = System.Environment.CurrentDirectory;
                string lujing = aaaa + "\\" + hetongmingcheng + "." + hetongleixing;
                FileStream fs = new FileStream(lujing, FileMode.Create);
                fs.Write(mypdffile, 0, mypdffile.Length);
                fs.Flush();
                fs.Close();


                System.Diagnostics.Process.Start(lujing);
            }

        }

        private void 查看指示项ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string a = "";
            string b = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号"));
            if (b.Length > 5)
            {
                string bb = b.Substring(0, 20);
                a = bb.Trim();
            }
            if (a != "")
            {
                FrFankuixiangxi form = new FrFankuixiangxi();
                form.gongzuolinghao = a;
                form.xiangmumingcheng = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "项目名称").ToString();
                form.yonghu = yonghu;
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    Reload();
                }
            }
        }

        private void 上传项目清单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string a = "";
            string b = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号"));
            if (b.Length > 5)
            {
                string bb = b.Substring(0, 20);
                a = bb.Trim();
            }
            if (a != "")
            {
                string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();

                //打开对话框
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo info = new FileInfo(dialog.FileName);
                    //获得文件大小
                    fileSize = info.Length;
                    //提取文件名,三步走
                    int index = info.FullName.LastIndexOf(".");
                    fileName = info.FullName.Remove(index);
                    fileName = fileName.Substring(fileName.LastIndexOf(@"\") + 1);
                    mingcheng = fileName;
                    //获得文件扩展名
                    fileType = info.Extension.Replace(".", "");
                    //把文件转换成二进制流
                    files = new byte[Convert.ToInt32(fileSize)];
                    FileStream file = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read);
                    read = new BinaryReader(file);
                    read.Read(files, 0, Convert.ToInt32(fileSize));

                    string ConStr = "update tb_xiangmu  set 项目清单=@pic where id='" + id + "'";
                    SQLhelp.ExecuteNonquery(ConStr, CommandType.Text, files);

                    string sql = "update tb_xiangmu set 项目清单名称='" + mingcheng + "',项目清单类型='" + fileType + "' where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql, CommandType.Text);
                    MessageBox.Show("上传成功！");
                }
            }
        }

        private void 确认完成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string a = "";
            string b = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号"));
            if (b.Length > 5)
            {
                string bb = b.Substring(0, 20);
                a = bb.Trim();
            }
            if (a != "")
            {
                if (yonghu == "韩小建" || yonghu == "徐魏魏" || yonghu == "蔡红兵")
                {
                    if (MessageBox.Show("确认提交吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
                        string sql = "update tb_xiangmu set 未交货项目 =NULL , 已交货未调试项目=1 where id='" + id + "'";
                        SQLhelp.ExecuteScalar(sql, CommandType.Text);
                        MessageBox.Show("确认成功！");
                        Reload();
                        //Reload2();
                        //Reload3();
                        //Reload4();
                    }
                }
                else
                {

                    MessageBox.Show("无权限！");
                    return;
                }
            }
        }

        private void 下载项目清单发货布局等ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string a = "";
            string b = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号"));
            if (b.Length > 14)
            {
                string bb = b.Substring(0, 14);
                a = bb.Trim();
            }
            if (a != "")
            {
                string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
                string sql = "select 项目清单名称 from tb_xiangmu  where id='" + id + "'";

                string jiance = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();

                if (jiance == "")
                {
                    MessageBox.Show("无附件！");
                    return;

                }
                FolderBrowserDialog lujingg = new FolderBrowserDialog();

                if (lujingg.ShowDialog() == DialogResult.OK)

                {
                    string xuanzelujing = lujingg.SelectedPath;
                    string sql1 = "select 项目清单名称 from tb_xiangmu  where id='" + id + "'";
                    string mingcheng = SQLhelp.ExecuteScalar(sql1, CommandType.Text).ToString();
                    string sql12 = "select 项目清单类型 from tb_xiangmu  where id='" + id + "'";

                    string leixing = SQLhelp.ExecuteScalar(sql12, CommandType.Text).ToString();
                    string lujing = xuanzelujing + "\\" + mingcheng + "." + leixing;
                    try
                    {
                        if (jiance != "")
                        {

                            string sql123 = "select 项目清单 from tb_xiangmu where id='" + id + "'";
                            byte[] mypdffile = SQLhelp.duqu(sql123, CommandType.Text);
                            FileStream fs = new FileStream(lujing, FileMode.Create);
                            fs.Write(mypdffile, 0, mypdffile.Length);
                            fs.Flush();
                            fs.Close();
                            MessageBox.Show("下载成功！");//显示异常信息                   
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);//显示异常信息
                    }

                }
            }
        }

        private void 下载该项目设备清单ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string a = "";
            string b = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号"));
            if (b.Length > 5)
            {
                string bb = b.Substring(0, 20);
                a = bb.Trim();
            }
            if (a != "")
            {
                string gongzuolinghao = a;
                string xiangmumingcheng = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "项目名称").ToString();


                string sql1 = "select  工作令号,项目名称,设备名称,数量,制造类型 from tb_jishubumen  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 技术部通过='1'";
                DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                string lujing = "";
                SaveFileDialog op = new SaveFileDialog();
                op.Filter = "EXCEL文件|*.xls;*,xlsx;";
                if (op.ShowDialog() == DialogResult.OK)//显示保存文件对话框
                {
                    lujing = op.FileName;
                    string savePath = lujing;

                    Workbook book = new Workbook();
                    Worksheet sheet = book.Worksheets[0];
                    Cells cells = sheet.Cells;


                    int Colnum = dt.Columns.Count;//表格列数   
                    int Rownum = dt.Rows.Count;//表格行数   



                    //生成行 列名行   
                    for (int i = 0; i < Colnum; i++)
                    {
                        cells[0, i].PutValue(dt.Columns[i].ColumnName);
                    }


                    //生成数据行   
                    for (int i = 0; i < Rownum; i++)
                    {
                        for (int k = 0; k < Colnum; k++)
                        {
                            cells[1 + i, k].PutValue(dt.Rows[i][k].ToString());
                        }
                    }

                    book.Save(savePath);


                    FileInfo fileInf = new FileInfo(savePath);

                    MessageBox.Show("导出成功！");
                }

            }
        }

        private void 上传项目采购预算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string a = "";
            string b = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号"));
            if (b.Length > 5)
            {
                string bb = b.Substring(0, 20);
                a = bb.Trim();
            }
            if (a != "")
            {
                string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();

                //打开对话框
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo info = new FileInfo(dialog.FileName);
                    //获得文件大小
                    fileSize = info.Length;
                    //提取文件名,三步走
                    int index = info.FullName.LastIndexOf(".");
                    fileName = info.FullName.Remove(index);
                    fileName = fileName.Substring(fileName.LastIndexOf(@"\") + 1);
                    mingcheng = fileName;
                    //获得文件扩展名
                    fileType = info.Extension.Replace(".", "");
                    //把文件转换成二进制流
                    files = new byte[Convert.ToInt32(fileSize)];
                    FileStream file = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read);
                    read = new BinaryReader(file);
                    read.Read(files, 0, Convert.ToInt32(fileSize));


                    string sql1 = "update tb_xiangmu  set 采购预算清单=@pic where id='" + id + "'";
                    SQLhelp.ExecuteNonquery(sql1, CommandType.Text, files);

                    string sql = "update tb_xiangmu set 采购预算清单名称='" + mingcheng + "',采购预算清单类型='" + fileType + "' where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql, CommandType.Text);
                    MessageBox.Show("上传成功！");
                }
            }
        }

        private void 下载项目采购预算ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string a = "";
            string b = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号"));
            if (b.Length > 5)
            {
                string bb = b.Substring(0, 20);
                a = bb.Trim();
            }
            if (a != "")
            {
                string xaingmufuzeren = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "项目负责人").ToString();
                string sql1234 = "select 部门 from tb_operator where 用户名='" + yonghu + "'";
                string bumen = sqlhelp111.ExecuteScalar(sql1234, CommandType.Text).ToString();
                if (bumen == "物流部" || yonghu == xaingmufuzeren)
                {



                    string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
                    string sql = "select 采购预算清单名称 from tb_xiangmu  where id='" + id + "'";

                    string jiance = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();

                    if (jiance == "")
                    {
                        MessageBox.Show("无附件！");
                        return;

                    }
                    FolderBrowserDialog lujingg = new FolderBrowserDialog();

                    if (lujingg.ShowDialog() == DialogResult.OK)

                    {
                        string xuanzelujing = lujingg.SelectedPath;
                        string sql1 = "select 采购预算清单名称 from tb_xiangmu  where id='" + id + "'";
                        string mingcheng = SQLhelp.ExecuteScalar(sql1, CommandType.Text).ToString();
                        string sql12 = "select 采购预算清单类型 from tb_xiangmu  where id='" + id + "'";

                        string leixing = SQLhelp.ExecuteScalar(sql12, CommandType.Text).ToString();
                        string lujing = xuanzelujing + "\\" + mingcheng + "." + leixing;
                        try
                        {
                            if (jiance != "")
                            {

                                string sql123 = "select 采购预算清单 from tb_xiangmu where id='" + id + "'";
                                byte[] mypdffile = SQLhelp.duqu(sql123, CommandType.Text);
                                FileStream fs = new FileStream(lujing, FileMode.Create);
                                fs.Write(mypdffile, 0, mypdffile.Length);
                                fs.Flush();
                                fs.Close();
                                MessageBox.Show("下载成功！");//显示异常信息                   
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);//显示异常信息
                        }
                    }
                }
                else
                {

                    MessageBox.Show("无权限下载采购预算！");
                    return;

                }
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
            {
                string a = "";
                string b = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号"));
                if (b.Length > 5)
                {
                    string bb = b.Substring(0, 20);
                    a = bb.Trim();
                }
                if (a != "")
                {
                    Frdashujv form1 = new Frdashujv();
                    form1.gongzuolinghao = a;

                    form1.xiangmumingcheng = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "项目名称").ToString();
                    form1.ShowDialog();
                }

            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }
    }
}
