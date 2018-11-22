using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.市场部
{
    public partial class FrJiedan : DevExpress.XtraEditors.XtraForm
    {
        public FrJiedan()
        {
            //this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        private long fileSize = 0;//文件大小
        private long fileSize1 = 0;//文件大小
        private long fileSize2 = 0;//文件大小
        private string fileName = null;//文件名字
        private string fileName1 = null;//文件名字
        private string fileName2 = null;//文件名字
        private byte[] files;//文件
        private byte[] filess;
        private byte[] filess2;
        private BinaryReader read = null;//二进制读取
        private BinaryReader read1 = null;
        private BinaryReader read2 = null;
        public string zhuguan;
        public string hetongleixing;
        public string lichengbeijihuabiaoleixing;
        public string hetongmingcheng;
        public string lichengbeijihuabiaomingcheng;
        public string shenchanrenwushu;
        public string shenchanrenwushuleixing;
        public string yonghu;
        private void FrJiedan_Load(object sender, EventArgs e)
        {
            string sql1 = "select 用户名  from tb_operator  where 部门='线缆事业部' or  部门='石英事业部'  or  部门='智能事业部'  or  部门='新材事业部' or  部门='薄材事业部'   or  部门='精工事业部'  or  部门='信息化事业部'  or  部门='研发部'";
            DataTable mingdan = sqlhelp111.GetDataTable(sql1, CommandType.Text);

            string sql2 = "select 用户名  from tb_operator  where 部门='物流部'";
            DataTable mingdan1 = sqlhelp111.GetDataTable(sql2, CommandType.Text);


            string sql3 = "select 用户名  from tb_operator  where 部门='精工事业部'";
            DataTable mingdan2 = sqlhelp111.GetDataTable(sql3, CommandType.Text);


            string sql4 = "select 申请日期,申请部门,申请人,职务 from workflow";
            DataTable dt = sqlhelp111.GetDataTable(sql4, CommandType.Text);
            gridControl1.DataSource = dt;

            string sql5 = "select 申请日期,申请部门,申请人,职务,调休原因 from workflow";
            DataTable dt1 = sqlhelp111.GetDataTable(sql5, CommandType.Text);
            gridControl2.DataSource = dt1;




            List<string> spaceminute1 = new List<string>();
            for (int i = 0; i < mingdan.Rows.Count; i++)
            {

                string n = mingdan.Rows[i]["用户名"].ToString();
                spaceminute1.Add(n);

            }
            List<string> spaceminute2 = new List<string>();
            for (int i = 0; i < mingdan1.Rows.Count; i++)
            {

                string n = mingdan1.Rows[i]["用户名"].ToString();
                spaceminute2.Add(n);
            }
            List<string> spaceminute3 = new List<string>();
            for (int i = 0; i < mingdan2.Rows.Count; i++)
            {

                string n = mingdan2.Rows[i]["用户名"].ToString();
                spaceminute3.Add(n);
            }


            foreach (string s in spaceminute1)
            {
                repositoryItemComboBox1.Items.Add(s);
                repositoryItemComboBox2.Items.Add(s);
            }

            foreach (string s in spaceminute2)
            {
                repositoryItemComboBox3.Items.Add(s);
                repositoryItemComboBox5.Items.Add(s);
            }
            foreach (string s in spaceminute3)
            {
                repositoryItemComboBox4.Items.Add(s);
                repositoryItemComboBox6.Items.Add(s);
            }
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

        

        
        
       

        private void dataGridViewX2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        

        

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                //打开对话框
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    //txthetong.Text = dialog.FileName;
                    FileInfo info = new FileInfo(@dialog.FileName);
                    //获得文件大小
                    fileSize = info.Length;
                    //提取文件名,三步走
                    int index = info.FullName.LastIndexOf(".");
                    fileName = info.FullName.Remove(index);
                    fileName = fileName.Substring(fileName.LastIndexOf(@"\") + 1);
                    txthetong.Text = fileName;
                    hetongmingcheng = fileName;
                    //获得文件扩展名
                    hetongleixing = info.Extension.Replace(".", "");
                    //把文件转换成二进制流
                    files = new byte[Convert.ToInt32(fileSize)];
                    FileStream file = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read);
                    read = new BinaryReader(file);
                    read.Read(files, 0, Convert.ToInt32(fileSize));

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("选择文件时候发生了　　" + ex.Message);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                //打开对话框
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    //txtlichengbeijihuabiao.Text = dialog.FileName;
                    FileInfo info1 = new FileInfo(@dialog.FileName);
                    //获得文件大小                   
                    fileSize1 = info1.Length;
                    //提取文件名,三步走
                    int index1 = info1.FullName.LastIndexOf(".");
                    fileName1 = info1.FullName.Remove(index1);
                    fileName1 = fileName1.Substring(fileName1.LastIndexOf(@"\") + 1);
                    txtlichengbeijihuabiao.Text = fileName1;
                    lichengbeijihuabiaomingcheng = fileName1;
                    //获得文件扩展名
                    lichengbeijihuabiaoleixing = info1.Extension.Replace(".", "");
                    //把文件转换成二进制流
                    filess = new byte[Convert.ToInt32(fileSize1)];
                    FileStream file1 = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read);
                    read1 = new BinaryReader(file1);
                    read1.Read(filess, 0, Convert.ToInt32(fileSize1));

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("选择文件时候发生了　　" + ex.Message);
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                //打开对话框
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    //shengchanrenwushu.Text = dialog.FileName;
                    FileInfo info1 = new FileInfo(@dialog.FileName);
                    //获得文件大小                   
                    fileSize2 = info1.Length;
                    //提取文件名,三步走
                    int index1 = info1.FullName.LastIndexOf(".");
                    fileName2 = info1.FullName.Remove(index1);
                    fileName2 = fileName2.Substring(fileName2.LastIndexOf(@"\") + 1);
                    shengchanrenwushu.Text = fileName2;
                    shenchanrenwushu = fileName2;
                    //获得文件扩展名
                    shenchanrenwushuleixing = info1.Extension.Replace(".", "");
                    //把文件转换成二进制流
                    filess2 = new byte[Convert.ToInt32(fileSize2)];
                    FileStream file1 = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read);
                    read2 = new BinaryReader(file1);
                    read2.Read(filess2, 0, Convert.ToInt32(fileSize2));

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("选择文件时候发生了　　" + ex.Message);
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (txtgonglinghao.Text.Trim().Contains("XL"))
            {
                string sql = "select 用户名 from tb_operator where 部门= '线缆事业部' and 级别='经理'";
                zhuguan = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();

            }
            if (txtgonglinghao.Text.Trim().Contains("SY"))
            {
                string sql = "select 用户名 from tb_operator where 部门= '石英事业部' and 级别='经理'";
                zhuguan = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();

            }
            if (txtgonglinghao.Text.Trim().Contains("BC"))
            {
                string sql = "select 用户名 from tb_operator where 部门= '薄材事业部' and 级别='经理'";
                zhuguan = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();

            }
            if (txtgonglinghao.Text.Trim().Contains("XC"))
            {
                string sql = "select 用户名 from tb_operator where 部门= '新材事业部' and 级别='经理'";
                zhuguan = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();

            }
            if (txtgonglinghao.Text.Trim().Contains("ZN"))
            {
                string sql = "select 用户名 from tb_operator where 部门= '智能事业部' and 级别='经理'";
                zhuguan = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();

            }
            if (txtgonglinghao.Text.Trim().Contains("RD"))
            {
                string sql = "select 用户名 from tb_operator where 部门= '研发部' and 级别='经理'";
                zhuguan = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();

            }
            if (txtgonglinghao.Text.Trim().Contains("JG"))
            {
                string sql = "select 用户名 from tb_operator where 部门= '精工事业部' and 级别='经理'";
                zhuguan = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();

            }

            if (txtgonglinghao.Text.Trim() == "")
            {
                MessageBox.Show("工作令号不能为空！");

                return;
            }
            if (txtkehumingcheng.Text.Trim() == "")
            {
                MessageBox.Show("客户名称不能为空！");

                return;
            }
            if (cheweixiu.Checked == false)
            {
                if (txthetong.Text.Trim() == "")
                {
                    MessageBox.Show("请上传合同！");

                    return;
                }
                if (txtlichengbeijihuabiao.Text.Trim() == "")
                {
                    MessageBox.Show("请上传里程碑计划表！");

                    return;
                }
            }

        
            if (gridView2.RowCount == 1)
            {
                MessageBox.Show("请输入项目名称！");

                return;
            }
            if (radioButton1.Checked == false && radioButton2.Checked == false)
            {
                MessageBox.Show("请选择营销组！");
                return;
            }

            string id = System.Guid.NewGuid().ToString("N");
            string 营销组 = "";
            if (radioButton1.Checked)
            {
                营销组 = "新能源装备营销组";
            }
            if (radioButton2.Checked)
            {
                营销组 = "通信装备营销组";
            }
            if (cheweixiu.Checked == false)
            {
                string sql主表 = "INSERT INTO xiangmuzongbiao(id,工作令号,交货日期,客户名称,预计设计结束时间,合同名称,里程碑计划表名称,合同类型,里程碑计划表类型,生产任务书名称,生产任务书类型,预计加工结束时间,预计采购结束时间,预计装配结束时间,预计调试结束时间,预计设计开始时间,营销组) VALUES('" + id + "','" + txtgonglinghao.Text.Trim() + "', '" + datejiaohuo.Text + "', '" + txtkehumingcheng.Text.Trim() + "', '" + datesheji2.Text + "','" + hetongmingcheng + "','" + lichengbeijihuabiaomingcheng + "','" + hetongleixing + "','" + lichengbeijihuabiaoleixing + "','" + shenchanrenwushu + "','" + shenchanrenwushuleixing + "','" + datejiagong.Text + "','" + datecaigou.Text + "','" + datezhuangpei.Text + "','" + datetiaoshi.Text + "','" + DateTime.Now + "','" + 营销组 + "')";
                SQLhelp.ExecuteScalar(sql主表, CommandType.Text);
                try
                {
                    for (int i = 0; i < gridView1.RowCount-1; i++)
                    {
                        string xiangmu = Convert.ToString(this.gridView1.GetRowCellValue(i, "申请日期"));
                        string xaingfuzerenren = Convert.ToString(this.gridView1.GetRowCellValue(i, "申请部门"));
                        string cagoufuzeren = Convert.ToString(this.gridView1.GetRowCellValue(i, "申请人"));
                        string zhuangpei = Convert.ToString(this.gridView1.GetRowCellValue(i, "职务"));

                        string sql1 = "INSERT INTO tb_xiangmu1(工作令号,交货日期,客户名称,项目名称,预计设计结束时间,项目主管,合同名称,里程碑计划表名称,合同类型,里程碑计划表类型,生产任务书名称,生产任务书类型,预计加工结束时间,预计采购结束时间,预计装配结束时间,预计调试结束时间,预计设计开始时间,项目负责人,装配负责人,采购负责人,未交货项目,定位) VALUES('" + txtgonglinghao.Text.Trim() + "', '" + datejiaohuo.Text + "', '" + txtkehumingcheng.Text.Trim() + "', '" + xiangmu + "', '" + datesheji2.Text + "','" + zhuguan + "','" + hetongmingcheng + "','" + lichengbeijihuabiaomingcheng + "','" + hetongleixing + "','" + lichengbeijihuabiaoleixing + "','" + shenchanrenwushu + "','" + shenchanrenwushuleixing + "','" + datejiagong.Text + "','" + datecaigou.Text + "','" + datezhuangpei.Text + "','" + datetiaoshi.Text + "','" + DateTime.Now + "','" + xaingfuzerenren + "','" + zhuangpei + "','" + cagoufuzeren + "',1,'" + id + "')";
                        SQLhelp.ExecuteScalar(sql1, CommandType.Text);

                        string sql2 = "update tb_xiangmu1  set 合同=@pic where 工作令号='" + txtgonglinghao.Text + "' and 交货日期='" + datejiaohuo.Text + "' ";
                        SQLhelp.ExecuteNonquery(sql2, CommandType.Text, files);

                        string sql3 = "update tb_xiangmu1  set 里程碑计划表=@pic where 工作令号='" + txtgonglinghao.Text + "' and 交货日期='" + datejiaohuo.Text + "' ";
                        SQLhelp.ExecuteNonquery(sql3, CommandType.Text, filess);
                        string sql4 = "update tb_xiangmu1  set 生产任务书=@pic where 工作令号='" + txtgonglinghao.Text + "' and 交货日期='" + datejiaohuo.Text + "' ";
                        SQLhelp.ExecuteNonquery(sql4, CommandType.Text, filess2);

                    }
                    for (int i = 0; i < gridView2.RowCount-1; i++)
                    {
                        string xiangmu = Convert.ToString(this.gridView2.GetRowCellValue(i, "申请日期"));
                        string xaingfuzerenren = Convert.ToString(this.gridView2.GetRowCellValue(i, "申请人"));
                        string cagoufuzeren = Convert.ToString(this.gridView2.GetRowCellValue(i, "职务"));
                        string zhuangpei = Convert.ToString(this.gridView2.GetRowCellValue(i, "调休原因"));
                        string shebeimingcheng = Convert.ToString(this.gridView2.GetRowCellValue(i, "申请部门"));

                        DateTime dangqianshijian = DateTime.Now.AddMinutes(i + 1);

                        string sql1 = "INSERT INTO tb_jishubumen1(工作令号,项目名称,项目主管,时间,优先级,是否下达,生产部确认,图纸下达,技术部通过,加工确认,装配确认,调试确认,物流部确认,仓库确认,采购项目负责人,装配负责人,设备名称,项目负责人,是否提交,物流部最终确认,定位) VALUES('" + txtgonglinghao.Text.Trim() + "', '" + xiangmu.Trim() + "', '" + zhuguan + "','" + dangqianshijian + "',1,0,0,0,0,0,0,0,0,0,'" + cagoufuzeren + "','" + zhuangpei + "','" + shebeimingcheng + "','" + xaingfuzerenren + "',0,0,'" + id + "')";
                        SQLhelp.ExecuteScalar(sql1, CommandType.Text);
                    }
                    MessageBox.Show("提交成功");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("报错: " + ex.Message);
                }
            }
            if (cheweixiu.Checked == true)
            {
                string sql主表 = "INSERT INTO xiangmuzongbiao(id,工作令号,交货日期,客户名称,预计设计结束时间,合同名称,里程碑计划表名称,合同类型,里程碑计划表类型,生产任务书名称,生产任务书类型,预计加工结束时间,预计采购结束时间,预计装配结束时间,预计调试结束时间,预计设计开始时间,维修,营销组) VALUES('" + id + "','" + txtgonglinghao.Text.Trim() + "', '" + datejiaohuo.Text + "', '" + txtkehumingcheng.Text.Trim() + "', '" + datesheji2.Text + "','" + hetongmingcheng + "','" + lichengbeijihuabiaomingcheng + "','" + hetongleixing + "','" + lichengbeijihuabiaoleixing + "','" + shenchanrenwushu + "','" + shenchanrenwushuleixing + "','" + datejiagong.Text + "','" + datecaigou.Text + "','" + datezhuangpei.Text + "','" + datetiaoshi.Text + "','" + DateTime.Now + "','1','" + 营销组 + "')";
                SQLhelp.ExecuteScalar(sql主表, CommandType.Text);
                try
                {

                    for (int i = 0; i < gridView1.RowCount-1; i++)
                    {
                        string xiangmu = Convert.ToString(this.gridView1.GetRowCellValue(i, "申请日期"));
                        string xaingfuzerenren = Convert.ToString(this.gridView1.GetRowCellValue(i, "申请部门"));
                        string cagoufuzeren = Convert.ToString(this.gridView1.GetRowCellValue(i, "申请人"));
                        string zhuangpei = Convert.ToString(this.gridView1.GetRowCellValue(i, "职务"));

                        string sql1 = "INSERT INTO tb_xiangmu1(工作令号,交货日期,客户名称,项目名称,预计设计结束时间,项目主管,合同名称,里程碑计划表名称,合同类型,里程碑计划表类型,生产任务书名称,生产任务书类型,预计加工结束时间,预计采购结束时间,预计装配结束时间,预计调试结束时间,预计设计开始时间,项目负责人,装配负责人,采购负责人,未交货项目,维修,定位) VALUES('" + txtgonglinghao.Text.Trim() + "', '" + datejiaohuo.Text + "', '" + txtkehumingcheng.Text.Trim() + "', '" + xiangmu + "', '" + datesheji2.Text + "','" + zhuguan + "','" + hetongmingcheng + "','" + lichengbeijihuabiaomingcheng + "','" + hetongleixing + "','" + lichengbeijihuabiaoleixing + "','" + shenchanrenwushu + "','" + shenchanrenwushuleixing + "','" + datejiagong.Text + "','" + datecaigou.Text + "','" + datezhuangpei.Text + "','" + datetiaoshi.Text + "','" + DateTime.Now + "','" + xaingfuzerenren + "','" + zhuangpei + "','" + cagoufuzeren + "',1,1,'" + id + "')";
                        SQLhelp.ExecuteScalar(sql1, CommandType.Text);
                    }
                    for (int i = 0; i < gridView2.RowCount-1; i++)
                    {
                        string xiangmu = Convert.ToString(this.gridView2.GetRowCellValue(i, "申请日期"));
                        string xaingfuzerenren = Convert.ToString(this.gridView2.GetRowCellValue(i, "申请人"));
                        string cagoufuzeren = Convert.ToString(this.gridView2.GetRowCellValue(i, "职务"));
                        string zhuangpei = Convert.ToString(this.gridView2.GetRowCellValue(i, "调休原因"));
                        string shebeimingcheng = Convert.ToString(this.gridView2.GetRowCellValue(i, "申请部门"));

                        DateTime dangqianshijian = DateTime.Now.AddMinutes(i + 1);

                        string sql1 = "INSERT INTO tb_jishubumen1(工作令号,项目名称,项目主管,时间,优先级,是否下达,生产部确认,图纸下达,技术部通过,加工确认,装配确认,调试确认,物流部确认,仓库确认,采购项目负责人,装配负责人,设备名称,项目负责人,是否提交,维修,物流部最终确认,定位) VALUES('" + txtgonglinghao.Text.Trim() + "', '" + xiangmu + "', '" + zhuguan + "','" + dangqianshijian + "',1,0,0,0,0,0,0,0,0,0,'" + cagoufuzeren + "','" + zhuangpei + "','" + shebeimingcheng + "','" + xaingfuzerenren + "',0,1,0,'" + id + "')";
                        SQLhelp.ExecuteScalar(sql1, CommandType.Text);
                    }
                    MessageBox.Show("提交成功");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("报错: " + ex.Message);
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

        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                gridView1.DeleteRow(gridView1.FocusedRowHandle);
            }
        }

        private void gridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                gridView2.DeleteRow(gridView2.FocusedRowHandle);
            }
        }
    }
}
