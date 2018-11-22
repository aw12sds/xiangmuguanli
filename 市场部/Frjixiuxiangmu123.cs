using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.市场部
{
    public partial class Frjixiuxiangmu123 : Form
    {
        public Frjixiuxiangmu123()
        {
            InitializeComponent();
        }
        public string yonghu;
        private void Frjixiuxiangmu123_Load(object sender, EventArgs e)
        {
            Reload();
        }
        public void Reload()
        {

            string sql1 = "select id,序号,接单编号,机修件ERP,客户名称,部门,工件名称,加工内容,计量单位,机修件数量,接单日期,预交时间,联系人,责任人,加工单位备注,当前状态,合同号,供方名称,附件名称  from  tb_caigouliaodan where 完成!='完成'and 料单类型='机修件'  and  接单编号 like '%D%'  order by 接单日期";
            SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridControl1.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridView1.Columns["id"].Visible = false;


            string sql2 = "select id,接单编号,机修件ERP,客户名称,部门,工件名称,加工内容,计量单位,机修件数量,接单日期,预交时间,联系人,责任人,加工单位备注,当前状态,合同号,供方名称,附件名称  from  tb_caigouliaodan where 完成!='完成'and 料单类型='机修件'  and 接单编号 like '%HK%'  order by 接单日期";
            gridControl2.DataSource = SQLhelp.GetDataTable(sql2, CommandType.Text);
            gridView2.Columns["id"].Visible = false;


            string sql3 = "select id,接单编号,机修件ERP,客户名称,部门,工件名称,加工内容,计量单位,机修件数量,接单日期,预交时间,联系人,责任人,加工单位备注,附件名称,当前状态,合同号,供方名称   from  tb_caigouliaodan where 完成!='完成'and 料单类型='机修件部件'  and  接单编号 like '%D%'   order by 接单日期";
            gridControl3.DataSource = SQLhelp.GetDataTable(sql3, CommandType.Text);
            gridView3.Columns["id"].Visible = false;


            string sql4 = "select id,接单编号,机修件ERP,客户名称,部门,工件名称,加工内容,计量单位,机修件数量,接单日期,预交时间,联系人,责任人,加工单位备注,附件名称,当前状态,合同号,供方名称   from  tb_caigouliaodan where 完成!='完成'and 料单类型='机修件部件'  and  接单编号 like '%HK%'    order by 接单日期";
            gridControl4.DataSource = SQLhelp.GetDataTable(sql4, CommandType.Text);
            gridView4.Columns["id"].Visible = false;



            string sql5 = "select id,接单编号,机修件ERP,客户名称,部门,工件名称,加工内容,计量单位,机修件数量,接单日期,预交时间,联系人,责任人,加工单位备注,附件名称   from  tb_caigouliaodan where 完成='完成' and  接单编号 like '%D%'   order by 接单日期";
            gridControl5.DataSource = SQLhelp.GetDataTable(sql5, CommandType.Text);
            gridView5.Columns["id"].Visible = false;

            string sql6 = "select id,接单编号,机修件ERP,客户名称,部门,工件名称,加工内容,计量单位,机修件数量,接单日期,预交时间,联系人,责任人,加工单位备注,附件名称,当前状态,合同号,供方名称   from  tb_caigouliaodan where 完成='完成' and  接单编号 like '%HK%'   order by 接单日期";
            gridControl6.DataSource = SQLhelp.GetDataTable(sql6, CommandType.Text);
            gridView6.Columns["id"].Visible = false;



            string sql7 = "select id,序号,接单编号,销售单价,客户名称,部门,工件名称,加工内容,计量单位,机修件数量,接单日期,预交时间,联系人,加工单位备注,结算时间段,成本单价,销售单价*机修件数量 as 销售总价,成本单价*机修件数量 as 成本总价,附件名称   from  tb_caigouliaodan where  接单编号 like '%D%'   order by 序号";
            gridControl7.DataSource = SQLhelp.GetDataTable(sql7, CommandType.Text);
            gridView7.Columns["id"].Visible = false;


            string sql8 = "select id,序号,接单编号,销售单价,客户名称,部门,工件名称,加工内容,计量单位,机修件数量,接单日期,预交时间,联系人,加工单位备注,结算时间段,成本单价,销售单价*机修件数量 as 销售总价,成本单价*机修件数量 as 成本总价,附件名称   from  tb_caigouliaodan where  接单编号 like '%HK%'   order by 序号";
            gridControl8.DataSource = SQLhelp.GetDataTable(sql8, CommandType.Text);
            gridView8.Columns["id"].Visible = false;


        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void 确认完成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认完成吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {

                string id = this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "id").ToString();
                string sql = "update tb_caigouliaodan set 完成='完成' where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);
                MessageBox.Show("确认成功！");
                Reload();
            }
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

        private long fileSize2 = 0;//文件大小
        private string fileName2 = null;//文件名字
        private string fileType2 = null;//文件类型
        private byte[] files2;//文件
        private BinaryReader read2 = null;//二进制读取
        public string mingcheng2;
        private void 添加附件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = Convert.ToString(this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "id"));
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
                string sql = "update tb_caigouliaodan  set 附件名称='" + mingcheng1 + "',附件类型='" + fileType1 + "' ,附件=@pic where id='" + id + "'";
                int g = SQLhelp.ExecuteNonquery(sql, CommandType.Text, files1); MessageBox.Show("添加成功！");
                Reload();

            }
        }

        private void 查看附件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = Convert.ToString(this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "id"));


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

        private void 添加附件ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string id = Convert.ToString(this.gridView5.GetRowCellValue(this.gridView5.FocusedRowHandle, "id"));
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
                string sql = "update tb_caigouliaodan  set 附件名称='" + mingcheng + "',附件类型='" + fileType + "' ,附件=@pic where id='" + id + "'";
                int g = SQLhelp.ExecuteNonquery(sql, CommandType.Text, files); MessageBox.Show("添加成功！");
                Reload();

            }
        }

        private void 查看附件ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string id = Convert.ToString(this.gridView5.GetRowCellValue(this.gridView5.FocusedRowHandle, "id"));


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

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string id = Convert.ToString(gridView1.GetRowCellValue(i, "id"));
                string bianhao = Convert.ToString(gridView1.GetRowCellValue(i, "接单编号"));
                string erp = Convert.ToString(gridView1.GetRowCellValue(i, "机修件ERP"));
                string leixing = Convert.ToString(gridView1.GetRowCellValue(i, "加工单位备注"));
                string sql2 = "update tb_caigouliaodan  set 接单编号= '" + bianhao + "',加工单位备注='" + leixing + "' where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql2, CommandType.Text);
            }
            MessageBox.Show("保存成功！");
            Reload();
        }

        private void 查看料单ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 确认完成ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认完成吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {

                string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
                string sql = "update tb_caigouliaodan set 完成='完成' where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);
                MessageBox.Show("确认成功！");
                Reload();
            }
        }

        private void 添加附件ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo info = new FileInfo(dialog.FileName);
                //获得文件大小
                fileSize2 = info.Length;
                //提取文件名,三步走
                int index = info.FullName.LastIndexOf(".");
                fileName2 = info.FullName.Remove(index);
                fileName2 = fileName2.Substring(fileName2.LastIndexOf(@"\") + 1);
                mingcheng2 = fileName2;
                //获得文件扩展名
                fileType2 = info.Extension.Replace(".", "");
                //把文件转换成二进制流
                files2 = new byte[Convert.ToInt32(fileSize2)];
                FileStream file = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read);
                read2 = new BinaryReader(file);
                read2.Read(files2, 0, Convert.ToInt32(fileSize2));
                string sql = "update tb_caigouliaodan  set 附件名称='" + mingcheng2 + "',附件类型='" + fileType2 + "' ,附件=@pic where id='" + id + "'";
                int g = SQLhelp.ExecuteNonquery(sql, CommandType.Text, files2); MessageBox.Show("添加成功！");
                Reload();

            }
        }

        private void 查看附件ToolStripMenuItem2_Click(object sender, EventArgs e)
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

        private void 确认完成ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认完成吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {

                string id = this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id").ToString();
                string sql = "update tb_caigouliaodan set 完成='完成' where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);
                MessageBox.Show("确认成功！");
                Reload();
            }
        }

        private void 添加附件ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            string id = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id"));
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo info = new FileInfo(dialog.FileName);
                //获得文件大小
                fileSize2 = info.Length;
                //提取文件名,三步走
                int index = info.FullName.LastIndexOf(".");
                fileName2 = info.FullName.Remove(index);
                fileName2 = fileName2.Substring(fileName2.LastIndexOf(@"\") + 1);
                mingcheng2 = fileName2;
                //获得文件扩展名
                fileType2 = info.Extension.Replace(".", "");
                //把文件转换成二进制流
                files2 = new byte[Convert.ToInt32(fileSize2)];
                FileStream file = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read);
                read2 = new BinaryReader(file);
                read2.Read(files2, 0, Convert.ToInt32(fileSize2));
                string sql = "update tb_caigouliaodan  set 附件名称='" + mingcheng2 + "',附件类型='" + fileType2 + "' ,附件=@pic where id='" + id + "'";
                int g = SQLhelp.ExecuteNonquery(sql, CommandType.Text, files2); MessageBox.Show("添加成功！");
                Reload();

            }
        }

        private void 查看附件ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            string id = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id"));


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

        private void 查看料单ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            string id = gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "id").ToString();
            if (id == "")
            {
                MessageBox.Show("请先选择对应行！");
                return;
            }
            string shuliang = Convert.ToString(this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "机修件数量"));
            string gonglinghao = Convert.ToString(this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "接单编号"));
            string xiangmumingcheng = Convert.ToString(this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "工件名称"));
            string shebeimingcheng = Convert.ToString(this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "工件名称"));


            Frchakanliaodan form = new Frchakanliaodan();
            form.id = id;
            form.shuliang11 = shuliang;
            form.gonglinghao = gonglinghao;
            form.xiangmu = xiangmumingcheng;
            form.shebei = shebeimingcheng;
            form.yonghu = yonghu;
            form.ShowDialog();

        }

        private void 保存ToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void 确认完成ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认完成吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {

                string id = this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id").ToString();
                string sql = "update tb_caigouliaodan set 完成='完成' where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);
                MessageBox.Show("确认成功！");
                Reload();
            }
        }

        private void 添加附件ToolStripMenuItem4_Click(object sender, EventArgs e)
        {

            string id = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id"));
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
                string sql = "update tb_caigouliaodan  set 附件名称='" + mingcheng1 + "',附件类型='" + fileType1 + "' ,附件=@pic where id='" + id + "'";
                int g = SQLhelp.ExecuteNonquery(sql, CommandType.Text, files1); MessageBox.Show("添加成功！");
                Reload();

            }
        }

        private void 查看附件ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            string id = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id"));


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

        private void 查看料单ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string id = gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id").ToString();
            if (id == "")
            {
                MessageBox.Show("请先选择对应行！");
                return;
            }
            string shuliang = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "机修件数量"));
            string gonglinghao = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "接单编号"));
            string xiangmumingcheng = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "工件名称"));
            string shebeimingcheng = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "工件名称"));


            Frchakanliaodan form = new Frchakanliaodan();
            form.id = id;
            form.shuliang11 = shuliang;
            form.gonglinghao = gonglinghao;
            form.xiangmu = xiangmumingcheng;
            form.shebei = shebeimingcheng;
            form.yonghu = yonghu;
            form.ShowDialog();
        }

        private void 添加附件ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            string id = Convert.ToString(this.gridView6.GetRowCellValue(this.gridView6.FocusedRowHandle, "id"));
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
                string sql = "update tb_caigouliaodan  set 附件名称='" + mingcheng + "',附件类型='" + fileType + "' ,附件=@pic where id='" + id + "'";
                int g = SQLhelp.ExecuteNonquery(sql, CommandType.Text, files); MessageBox.Show("添加成功！");
                Reload();

            }
        }

        private void 查看附件ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            string id = Convert.ToString(this.gridView6.GetRowCellValue(this.gridView6.FocusedRowHandle, "id"));


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

        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }

        private void gridView3_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }

        private void gridView4_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }

        private void gridView5_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }

        private void gridView6_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }

        private void gridView7_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }

        private void gridView8_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }

        private void 保存ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int[] a = gridView8.GetSelectedRows();
            float aa = 0;
            foreach (int i in a)
            {
                string xiaoshoudanjia = gridView8.GetRowCellValue(i, "销售单价").ToString();
                string id = gridView8.GetRowCellValue(i, "id").ToString();
                string chengbendanjia = gridView8.GetRowCellValue(i, "成本单价").ToString();

                if (float.TryParse(xiaoshoudanjia, out aa) == false)
                {
                    MessageBox.Show("销售单价必须是数字！");
                    return;
                }
                if (float.TryParse(chengbendanjia, out aa) == false)
                {
                    MessageBox.Show("成本单价必须是数字！");
                    return;
                }
                string kehumingcheng = gridView8.GetRowCellValue(i, "客户名称").ToString();
                string bumen = gridView8.GetRowCellValue(i, "部门").ToString();
                string sql = "update tb_caigouliaodan set 销售单价='" + xiaoshoudanjia + "',成本单价='" + chengbendanjia + "',客户名称='" + kehumingcheng + "',部门='" + bumen + "' where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);

            }
            MessageBox.Show("保存成功！");
            Reload();

        }

        private void 保存ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            int[] a = gridView7.GetSelectedRows();
            float aa = 0;
            foreach (int i in a)
            {
                string  xiaoshoudanjia= gridView7.GetRowCellValue(i, "销售单价").ToString();
                string id = gridView7.GetRowCellValue(i, "id").ToString();
                string chengbendanjia = gridView7.GetRowCellValue(i, "成本单价").ToString();
               
                if (float.TryParse(xiaoshoudanjia, out aa) == false)
                {
                    MessageBox.Show("销售单价必须是数字！");
                    return;
                }
                if (float.TryParse(chengbendanjia, out aa) == false)
                {
                    MessageBox.Show("成本单价必须是数字！");
                    return;
                }
                string kehumingcheng = gridView7.GetRowCellValue(i, "客户名称").ToString();
                string bumen = gridView7.GetRowCellValue(i, "部门").ToString();
                string sql = "update tb_caigouliaodan set 销售单价='" + xiaoshoudanjia + "',成本单价='" + chengbendanjia + "',客户名称='" + kehumingcheng + "',部门='" + bumen + "' where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);

            }
            MessageBox.Show("保存成功！");
            Reload();

        }
    }
}
