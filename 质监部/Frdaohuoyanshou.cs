using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;

namespace 项目管理系统.质监部
{
    public partial class Frdaohuoyanshou : DevExpress.XtraEditors.XtraForm
    {
        public string yonghu;
        public string lujing;
        public Frdaohuoyanshou()
        {
            InitializeComponent();
        }

        private void Frdaohuoyanshou_Load(object sender, EventArgs e)
        {
            reload();
            reload1();
        }

        private void 质检员提交ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
            string 合格品数量 = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "合格品数量").ToString();
            string 状态 = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "状态").ToString();
            if (状态 != "待检验")
            {
                MessageBox.Show("当前状态无法操作此项");
                return;
            }else
            {
                MessageBox.Show("确定已提交质检记录吗?");
                string sql2 = "update tb_daohuoyanshou  set 合格品数量= '" + 合格品数量 + "',检验时间= '" + DateTime.Now + "',状态='等待质检部检验' " + "   where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql2, CommandType.Text);
            }
            reload();


        }

        private void 质检部提交ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
            string 质检部合格品数量 = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "质检部合格品数量").ToString();
            string 状态 = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "状态").ToString();
            if (状态 != "等待质检部检验")
            {
                MessageBox.Show("当前状态无法操作此项");
                return;
            }
            else
            {
                string sql2 = "update tb_daohuoyanshou  set 质检部合格品数量= '" + 质检部合格品数量 + "',质检部检验时间= '" + DateTime.Now + "',状态='已通过检验' " + "   where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql2, CommandType.Text);
            }
            reload();
        }

        private void 检验文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name;
            long fileSize = 0;//文件大小
            string fileName = null;//文件名字
            string fileType = null;//文件类型
            byte[] files;//文件
            BinaryReader read = null;//二进制读取
            string mingcheng;
            string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();

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
                string ConStr = "update tb_daohuoyanshou  set 检验文件=@pic where id='" + id + "'";
                SQLhelp.ExecuteNonquery(ConStr, CommandType.Text, files);

                string sql = "update tb_daohuoyanshou  set 检验文件名称='" + mingcheng + "',检验文件后缀='" + fileType + "' where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);
               
            }
            reload();
        }
        public void reload()
        {
            string sql = "select (CASE WHEN a.检验文件 IS NULL THEN '无' ELSE '有' END) as '有无检验文件',(CASE WHEN a.质检部检验文件 IS NULL THEN '无' ELSE '有' END) as '有无质检部检验文件',a.*,b.* from tb_daohuoyanshou a,tb_caigouliaodan b where a.定位 = b.id ";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            gridControl1.DataSource = dt;
        }
        public void reload1()
        {
            string sql = "select (CASE WHEN a.检验文件 IS NULL THEN '无' ELSE '有' END) as '有无检验文件',(CASE WHEN a.质检部检验文件 IS NULL THEN '无' ELSE '有' END) as '有无质检部检验文件',a.*,b.* from tb_daohuoyanshou a,tb_caigouliaodan b where a.定位 = b.id and a.状态='已入库'";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            gridControl2.DataSource = dt;
        }
        private void 检验文件ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
            string leixing = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "检验文件后缀").ToString();
            string mingcheng = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "检验文件名称").ToString();

                string sql1 = "Select 检验文件 From tb_daohuoyanshou  Where id='" + id + "'";
                byte[] mypdffile = null;
                mypdffile = SQLhelp.duqu(sql1, CommandType.Text);
                string aaaa = System.Environment.CurrentDirectory;
                lujing = aaaa + "\\" + mingcheng + "." + leixing;
                FileStream fs = new FileStream(lujing, FileMode.Create);
                fs.Write(mypdffile, 0, mypdffile.Length);
                fs.Flush();
                fs.Close();

                System.Diagnostics.Process.Start(lujing);
        }

        private void 质检部检验文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name;
            long fileSize = 0;//文件大小
            string fileName = null;//文件名字
            string fileType = null;//文件类型
            byte[] files;//文件
            BinaryReader read = null;//二进制读取
            string mingcheng;
            string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();

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
                string ConStr = "update tb_daohuoyanshou  set 质检部检验文件=@pic where id='" + id + "'";
                SQLhelp.ExecuteNonquery(ConStr, CommandType.Text, files);

                string sql = "update tb_daohuoyanshou  set 质检部检验名称='" + mingcheng + "',质检部检验后缀='" + fileType + "' where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);

            }
            reload();
        }

        private void 质检部检验文件ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
            string leixing = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "质检部检验后缀").ToString();
            string mingcheng = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "质检部检验名称").ToString();

            string sql1 = "Select 质检部检验文件 From tb_daohuoyanshou  Where id='" + id + "'";
            byte[] mypdffile = null;
            mypdffile = SQLhelp.duqu(sql1, CommandType.Text);
            string aaaa = System.Environment.CurrentDirectory;
            lujing = aaaa + "\\" + mingcheng + "." + leixing;
            FileStream fs = new FileStream(lujing, FileMode.Create);
            fs.Write(mypdffile, 0, mypdffile.Length);
            fs.Flush();
            fs.Close();

            System.Diagnostics.Process.Start(lujing);
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void 不合格品提交ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
            string 让步接收数量 = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "让步接收数量").ToString();
            string 供应商返工数量 = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "供应商返工数量").ToString();
            string 代返工数量 = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "代返工数量").ToString();
            string sql = "update tb_daohuoyanshou  set 让步接收数量='"+ 让步接收数量+ "',供应商返工数量='"+ 供应商返工数量+ "',代返工数量='"+ 代返工数量+"' where id='" + id + "'";
            SQLhelp.ExecuteScalar(sql, CommandType.Text);
        }
    }
}