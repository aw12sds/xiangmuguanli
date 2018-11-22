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

namespace 项目管理系统.个人管理
{
    public partial class Frgerengoumai : Form
    {
        public Frgerengoumai()
        {
            InitializeComponent();
        }
        public string yonghu;
        public string bumen;
        public string name;
        private long fileSize = 0;//文件大小
        private string fileName = null;//文件名字
        private string fileType = null;//文件类型
        private byte[] files;//文件
        private BinaryReader read = null;//二进制读取
        public string mingcheng;
        public string dingwei;
        private void buttonItem1_Click(object sender, EventArgs e)
        {
            Frgerencaigoushenqing form1 = new Frgerencaigoushenqing();
            form1.yonghu = yonghu;
            form1.leixing = "部门";
            form1.ShowDialog();
            if(form1.DialogResult==DialogResult.OK)
            {
                Reload();
            }
        }

        private void Frgerengoumai_Load(object sender, EventArgs e)
        {
            Reload();
        }
         public void Reload()
        {
            string sql112 = "select 部门 from  tb_operator where 用户名='" + yonghu + "'";
            string bumen= sqlhelp111.ExecuteScalar(sql112, CommandType.Text).ToString();
            string sql = "select id,工作令号,编码,新编码,型号,名称,单位,数量,类型,要求到货日期,备注,申购人,附件名称,附件类型,合同号,供方名称,当前状态,流程状态,驳回原因 from tb_caigouliaodan where 料单类型='" + bumen + "' order by 要求到货日期";
            gridControl1.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
            gridView1.Columns["id"].Visible = false;


        }

        private void 添加附件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0)
            {
                MessageBox.Show("没有料单，请先导入！");
                return;
            }
            string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));

            //打开对话框
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                name = dialog.FileName;
                FileInfo info = new FileInfo(name);
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
                FileStream file = new FileStream(name, FileMode.Open, FileAccess.Read);
                read = new BinaryReader(file);
                read.Read(files, 0, Convert.ToInt32(fileSize));
                string sql = "update tb_caigouliaodan  set 附件=@pic where id='" + id + "'";
                SQLhelp.ExecuteNonquery(sql, CommandType.Text, files);
             
                string sql1 = "update tb_caigouliaodan  set 附件名称='" + mingcheng + "',附件类型='" + fileType + "' where id='" + id + "'";
                 SQLhelp.ExecuteScalar(sql1, CommandType.Text);
                MessageBox.Show("添加成功！");

                Reload();

            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
            {
                
                string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
                string sql = "select 附件名称 from tb_caigouliaodan where id='" + id + "'";
                string mingcheng = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
                if (mingcheng == "")
                {
                    MessageBox.Show("没有附件！");
                    return;
                }

                string sql2 = "select 附件类型 from tb_caigouliaodan where id='" + id + "'";
                string leixing = SQLhelp.ExecuteScalar(sql2, CommandType.Text).ToString();

                byte[] mypdffile = null;

                string sql4 = "Select 附件 From tb_caigouliaodan Where id='" + id + "' ";

                mypdffile = SQLhelp.duqu(sql4, CommandType.Text);
                this.Cursor = Cursors.WaitCursor;

                string aaaa = System.Environment.CurrentDirectory;
                string bbbb = mingcheng.Replace("?", "1");
                string lujing = aaaa + "\\" + bbbb + "1" + "." + leixing;
                FileStream fs = new FileStream(lujing, FileMode.Create);
                fs.Write(mypdffile, 0, mypdffile.Length);
                fs.Flush();
                fs.Close();
                this.Cursor = Cursors.Default;
                System.Diagnostics.Process.Start(lujing);

            }
        }

        private void bar1_ItemClick(object sender, EventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
