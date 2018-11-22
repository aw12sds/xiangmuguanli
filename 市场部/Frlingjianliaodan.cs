using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 项目管理系统.技术部;

namespace 项目管理系统.市场部
{
    public partial class Frlingjianliaodan : DevExpress.XtraEditors.XtraForm
    {
        public Frlingjianliaodan()
        {
            InitializeComponent();
        }
        public DataTable dt;

        public string name;
        public string mingcheng;
        public string shuliang11;
        public string gonglinghao;
        public string xiangmu;
        public string shebei;
        public string shijian;
        public string yonghu;
        public double shijicaigou;
        public string a;
        public string id;
        private long fileSize = 0;//文件大小
        private string fileName = null;//文件名字
        private string fileType = null;//文件类型
        private byte[] files;//文件
        private BinaryReader read = null;//二进制读取
        private void Frlingjianliaodan_Load(object sender, EventArgs e)
        {
            Reload();
        }
        public void Reload()
        {
            string sql = "select id,序号,机修件ERP,名称,型号,单位,库存数量,数量,料单类型,备注,制造类型,实际采购数量,附件名称 from tb_caigouliaodan where 定位 = '" + id + "'and 料单类型='机修件'";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            gridControl1.DataSource = dt;
            gridView1.Columns["id"].Visible = false;
            gridView1.Columns["料单类型"].Visible = false;
            gridView1.Columns["库存数量"].Visible = false;
        }

        private void 添加图纸ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0)
            {
                MessageBox.Show("没有料单，请先导入！");
                return;
            }
            //string id = dataGridViewX2.CurrentRow.Cells["id"].Value.ToString();

            //打开对话框
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                int a = 0;
                int b = dialog.FileNames.Length;
                if (b > gridView1.RowCount)
                {
                    MessageBox.Show("选中的文件数量超过了该料单的行数！");
                    return;
                }
                foreach (string s in dialog.FileNames)
                {
                    name = s;
                    //string id = gridView1.Row[a].Cells["id"].Value.ToString();
                    string id = Convert.ToString(this.gridView1.GetRowCellValue(a, "id"));
                    FileInfo info = new FileInfo(name);
                    a += 1;
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
                }

                Reload();

            }
        }

        private void 添加单张图纸ToolStripMenuItem_Click(object sender, EventArgs e)
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


                string ConStr = "update tb_caigouliaodan  set 附件=@pic where id='" + id + "'";
                SQLhelp.ExecuteNonquery(ConStr, CommandType.Text, files);

                string sql = "update tb_caigouliaodan  set 附件名称='" + mingcheng + "',附件类型='" + fileType + "' where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);
                //a = this.dataGridViewX2.CurrentRow.Index;
                a = this.gridView1.FocusedRowHandle.ToString();
                Reload();
                //dataGridViewX2.Rows[a].Selected = true;
                //dataGridViewX2.FirstDisplayedScrollingRowIndex = a;

            }
        }

        private void 保存更改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认保存更改吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    string id = Convert.ToString(this.gridView1.GetRowCellValue(i, "id"));
                    if (id == "")
                    {
                        MessageBox.Show("请先保存料单,再更改！");
                        return;
                    }
                    if (id != "")
                    {
                        string xuhao = Convert.ToString(this.gridView1.GetRowCellValue(i, "序号"));
                        string bianma = Convert.ToString(this.gridView1.GetRowCellValue(i, "编码"));
                        string mingcheng = Convert.ToString(this.gridView1.GetRowCellValue(i, "名称"));
                        string xinghao = Convert.ToString(this.gridView1.GetRowCellValue(i, "型号"));
                        string danwei = Convert.ToString(this.gridView1.GetRowCellValue(i, "单位"));
                        string shuliang = Convert.ToString(this.gridView1.GetRowCellValue(i, "数量"));
                        string leixing = Convert.ToString(this.gridView1.GetRowCellValue(i, "料单类型"));
                        string kucun = Convert.ToString(this.gridView1.GetRowCellValue(i, "库存数量"));
                        string beizhu = Convert.ToString(this.gridView1.GetRowCellValue(i, "备注"));
                        string zhizao = Convert.ToString(this.gridView1.GetRowCellValue(i, "制造类型"));

                        string sql2 = "update tb_caigouliaodan  set 编码='" + bianma + "',制造类型='" + zhizao + "',类型='" + leixing + "',备注='" + beizhu + "',序号='" + xuhao + "' where id ='" + id + "' ";
                        SQLhelp.ExecuteScalar(sql2, CommandType.Text);

                        if (bianma == "")
                        {
                            string sql = "update tb_caigouliaodan  set 型号='" + xinghao + "',名称='" + mingcheng + "' where id ='" + id + "' ";
                            SQLhelp.ExecuteScalar(sql, CommandType.Text);

                        }
                    }
                }
                MessageBox.Show("保存成功！");
                Reload();
            }
        }

        private void 删除该行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
            string sql = "delete from tb_caigouliaodan where id='" + id + "'";
            SQLhelp.ExecuteScalar(sql, CommandType.Text);
            MessageBox.Show("删除成功！");
            Reload();
        }

        private void 删除全部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string id = Convert.ToString(this.gridView1.GetRowCellValue(i, "id"));
                string sql = "delete from tb_caigouliaodan where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);
            }
            MessageBox.Show("删除成功！");
            Reload();
        }

        private void 录入料单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frhangshu form = new Frhangshu();
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                //try
                //{
                    dt = null;
                    int hangshu = Convert.ToInt32(form.hangshu);
                    OpenFileDialog dialog = new OpenFileDialog();
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        string b = dialog.FileName;

                        Workbook book = new Workbook(b);
                        Worksheet sheet = book.Worksheets["Sheet1"];
                        dt = sheet.Cells.ExportDataTableAsString(7, 0, hangshu, 11);
                        dt.Columns["Column1"].ColumnName = "序号";
                        dt.Columns["Column2"].ColumnName = "编码";
                        dt.Columns["Column3"].ColumnName = "型号";
                        dt.Columns["Column4"].ColumnName = "名称";
                        dt.Columns["Column5"].ColumnName = "单位";
                        dt.Columns["Column6"].ColumnName = "数量";
                        dt.Columns["Column7"].ColumnName = "料单类型";
                        dt.Columns["Column8"].ColumnName = "库存数量";
                        dt.Columns["Column9"].ColumnName = "实际采购数量";
                        dt.Columns["Column10"].ColumnName = "制造类型";
                        dt.Columns["Column11"].ColumnName = "备注";

                        if (dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                float a = 0;
                                if (float.TryParse(dt.Rows[i]["数量"].ToString(), out a) == false)
                                {
                                    int aaa = i + 1;
                                    MessageBox.Show("第" + aaa + "行料单" + "数量必须是数字！");
                                    return;
                                }
                                if (float.TryParse(dt.Rows[i]["库存数量"].ToString(), out a) == false)
                                {
                                    int aaa = i + 1;
                                    MessageBox.Show("第" + aaa + "行料单的" + "库存数量必须是数字！");
                                    return;
                                }
                                if (dt.Rows[i]["制造类型"].ToString() != "零件")
                                {
                                    int aaa = i + 1;
                                    MessageBox.Show("第" + aaa + "行料单的" + "制造类型必须符合规范，只能是零件！");
                                    return;
                                }
                            }
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                if (shuliang11 != "")
                                {
                                    shijicaigou = Convert.ToDouble(shuliang11) * Convert.ToDouble(dt.Rows[i]["数量"].ToString()) - Convert.ToDouble(dt.Rows[i]["库存数量"].ToString());
                                }
                            string SQL = "insert into  tb_caigouliaodan(序号,工作令号,项目名称,设备名称,时间,型号,名称,单位,数量,备注,申购人,实际采购数量,收到料单日期,料单类型,定位)values('" + dt.Rows[i]["序号"].ToString() + "','" + gonglinghao + "','" + xiangmu + "','" + shebei + "','" + shijian + "','" + dt.Rows[i]["型号"].ToString().Trim() + "','" + dt.Rows[i]["名称"].ToString().Trim() + "','" + dt.Rows[i]["单位"].ToString() + "','" + dt.Rows[i]["数量"].ToString() + "','" + dt.Rows[i]["备注"].ToString() + "','" + yonghu + "','" + shijicaigou + "','" + DateTime.Now + "','机修件','" + id + "') ";

                            SQLhelp.ExecuteScalar(SQL, CommandType.Text);
                            }
                            MessageBox.Show("生成成功！");
                        }
                        string sql1 = "select  id,工作令号,项目名称,时间,序号,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,附件名称,实际采购数量,新编码 from  tb_caigouliaodan  where 工作令号='" + gonglinghao + "' and 项目名称='" + xiangmu + "'and 时间='" + shijian + "' and 设备名称='" + shebei + "'";
                        gridControl1.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
                    }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(" 发生了" + ex.Message);
                //    this.Close();
                //}
            }
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "附件名称")) == "")
            {
                MessageBox.Show("没有附件！");
                return;
            }
            if (Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "附件名称")) != "")
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

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
    }
}
