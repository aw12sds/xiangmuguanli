using DevComponents.DotNetBar;
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
    public partial class FrXiangmuguanli : Office2007Form
    {
        public FrXiangmuguanli()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string lujing;

        private void FrXiangmuguanli_Load(object sender, EventArgs e)
        {
            Reload();

        }
        public void Reload()
        {

            string sql = "select id,工作令号,交货日期,客户名称,项目名称,预计设计开始时间,预计设计结束时间,预计加工开始时间,预计加工结束时间,预计采购开始时间,预计采购结束时间,预计装配开始时间,预计装配结束时间,预计调试开始时间,预计调试结束时间,项目主管,合同名称,合同类型,里程碑计划表名称,里程碑计划表类型,加工天数,采购天数,装配天数,调试天数 from tb_xiangmu order by 预计设计开始时间 desc";
            DataTable jieguo = SQLhelp.GetDataTable(sql, CommandType.Text);
            gridControl1.DataSource = jieguo;
            gridView1.Columns["id"].Visible = false;

        }

        private void 查看合同ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (gridView1.RowCount <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }
            string gongzuolingaho = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号"));
            string xiangmumingcheng = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "项目名称"));
            string leixing = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "合同类型"));
            string mingcheng = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "合同名称"));
            string sql = "Select 合同 From tb_xiangmu  Where 工作令号='" + gongzuolingaho + "' and  项目名称='" + xiangmumingcheng + "' ";
            byte[] mypdffile = null;
            mypdffile = SQLhelp.duqu(sql, CommandType.Text);


            string aaaa = System.Environment.CurrentDirectory;
            lujing = aaaa + "\\" + mingcheng + "." + leixing;
            FileStream fs = new FileStream(lujing, FileMode.Create);
            fs.Write(mypdffile, 0, mypdffile.Length);
            fs.Flush();
            fs.Close();
            
            System.Diagnostics.Process.Start(lujing);

        }

        private void 查看里程碑计划表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }
            string gongzuolingaho = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号"));
            string xiangmumingcheng = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "项目名称"));
            string leixing = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "里程碑计划表类型"));
            string mingcheng = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "里程碑计划表名称"));
            string sql = "Select 里程碑计划表 From tb_xiangmu  Where 工作令号='" + gongzuolingaho + "' and  项目名称='" + xiangmumingcheng + "' ";
            byte[] mypdffile = null;
            mypdffile = SQLhelp.duqu(sql, CommandType.Text);
            string aaaa = System.Environment.CurrentDirectory;
            lujing = aaaa + "\\" + mingcheng + "." + leixing;
            FileStream fs = new FileStream(lujing, FileMode.Create);
            fs.Write(mypdffile, 0, mypdffile.Length);
            fs.Flush();
            fs.Close();
            System.Diagnostics.Process.Start(lujing);
        }

      

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
            string jiagong = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "加工天数"));
            string caigou = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "采购天数"));
            string zhuangpei = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "装配天数"));
            string tiaoshi= Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "调试天数"));
            string sql = "update tb_xiangmu set 加工天数='"+jiagong+ "', 采购天数='" + caigou + "', 装配天数='" + zhuangpei + "', 调试天数='" + tiaoshi + "' Where id='" + id + "'";
            SQLhelp.ExecuteScalar(sql,CommandType.Text);
            MessageBox.Show("修改成功！");
            Reload();

        }
        private long fileSize = 0;//文件大小
        private string fileName = null;//文件名字
        private string fileType = null;//文件类型
        private byte[] files;//文件
        private BinaryReader read = null;//二进制读取
        public string mingcheng;
        private long fileSize1 = 0;//文件大小
        private string fileName1 = null;//文件名字
        private string fileType1 = null;//文件类型
        private byte[] files1;//文件
        private BinaryReader read1 = null;//二进制读取
        public string mingcheng1;
        private void 上传合同ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string a = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号"));
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

                    string sql1= "update tb_xiangmu  set 合同=@pic where id='" + id + "'";
                    SQLhelp.ExecuteNonquery(sql1, CommandType.Text, files);
               
                    string sql = "update tb_xiangmu set 合同名称='" + mingcheng + "',合同类型='" + fileType + "' where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql, CommandType.Text);
                    MessageBox.Show("上传成功！");
                }
            }
            Reload();
        }

        private void 上传里程碑计划表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string a = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号"));
            if (a != "")
            {
                string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();

                //打开对话框
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo info = new FileInfo(dialog.FileName);
                    //获得文件大小
                    fileSize1 = info.Length;
                    //提取文件名,三步走
                    int index = info.FullName.LastIndexOf(".");
                    fileName1 = info.FullName.Remove(index);
                    fileName1 = fileName1.Substring(fileName1.LastIndexOf(@"\") + 1);
                    mingcheng1 = fileName1;
                    //获得文件扩展名
                    fileType1 = info.Extension.Replace(".", "");
                    //把文件转换成二进制流
                    files1 = new byte[Convert.ToInt32(fileSize1)];
                    FileStream file = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read);
                    read1 = new BinaryReader(file);
                    read1.Read(files1, 0, Convert.ToInt32(fileSize1));

                    string sql1 = "update tb_xiangmu  set 里程碑计划表=@pic where id='" + id + "'";
                    SQLhelp.ExecuteNonquery(sql1, CommandType.Text, files);

                    string sql = "update tb_xiangmu set 里程碑计划表名称='" + mingcheng + "',里程碑计划表类型='" + fileType1 + "' where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql, CommandType.Text);
                    MessageBox.Show("上传成功！");
                }
            }
            Reload();
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }


        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
