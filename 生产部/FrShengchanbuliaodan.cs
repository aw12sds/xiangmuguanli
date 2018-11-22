using Aspose.Cells;
using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using 项目管理系统.个人管理;

namespace 项目管理系统.生产部
{
    public partial class FrShengchanbuliaodan : DevExpress.XtraEditors.XtraForm
    {
        public FrShengchanbuliaodan()
        {
          
            InitializeComponent();
        }
        public string gongzuolinghao;
        public string xiangmumingcheng;
        public string shijian;
        DataTable dt;
       
        public string yonghu;
        public string dingwei;
        public string shebeimingcheng;
        private void FrShengchanbuliaodan_Load(object sender, EventArgs e)
        {
            Reload();
            this.WindowState = FormWindowState.Maximized;//最小化
        }
        
        public void Reload()
        {
            string sql1 = "select  id,工作令号,项目名称,设备名称,时间,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,实际采购数量,附件名称,加工预计结束时间,原料成本,人工成本 from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and  项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "' and 时间='" + shijian + "'  ";
            dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridControl4.DataSource = dt;
            
        }

        //private void 插入新行ToolStripMenuItem_Click(object sender, EventArgs e)
        //{

        //    string gonglinghao = dataGridViewX2.CurrentRow.Cells["工作令号"].Value.ToString();
        //    string xiangmumingcheng = dataGridViewX2.CurrentRow.Cells["项目名称"].Value.ToString();
        //    string shebeiingcheng = dataGridViewX2.CurrentRow.Cells["设备名称"].Value.ToString();

        //    string shijian = dataGridViewX2.CurrentRow.Cells["时间"].Value.ToString();
        //    string sqll= "select 申购人 from tb_caigouliaodan where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "' ";
        //    string chaxun = SQLhelp.ExecuteScalar(sqll, CommandType.Text).ToString();

        //    string sql2 = "INSERT INTO tb_caigouliaodan(工作令号,项目名称,设备名称,时间,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,生产部确认,仓库确认,申购人,实际采购数量) VALUES('" + gonglinghao + "', '" + xiangmumingcheng + "', '" + shebeiingcheng + "', '" + shijian + "','','','','','','','','','','','','','','"+chaxun+"','')";
        //    SQLhelp.ExecuteScalar(sql2, CommandType.Text);

        //    Reload();

        //}

        //private void 删除该行ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (dataGridViewX2.Rows.Count <= 0)//判断是否选中要删除的行
        //    {
        //        MessageBox.Show("请选中行！");
        //        return;
        //    }
            
        //    string id = dataGridViewX2.CurrentRow.Cells["id"].Value.ToString();
           

        //    string sql = "delete from tb_caigouliaodan   where id= '" + id + "' ";
            
        //    SQLhelp.ExecuteScalar(sql, CommandType.Text);
            
        //    MessageBox.Show("删除成功！");
        //    Reload();




        //}

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView4.RowCount; i++)
            {                          
                    string id = gridView4.GetRowCellValue(i, "id").ToString();
                string bianma = gridView4.GetRowCellValue(i, "编码").ToString();
                string xinghao = gridView4.GetRowCellValue(i, "型号").ToString();
                string mingcheng = gridView4.GetRowCellValue(i, "名称").ToString();
                string danwei = gridView4.GetRowCellValue(i, "单位").ToString();
                string zhizaoleixing = gridView4.GetRowCellValue(i, "制造类型").ToString();
                string yuanliaochengben = Convert.ToString( gridView4.GetRowCellValue(i, "原料成本"));
                string rengongchengben = Convert.ToString(gridView4.GetRowCellValue(i, "人工成本"));
                float a = 0;
                if (zhizaoleixing == "外协零部件")
                {
                    if (float.TryParse(yuanliaochengben, out a) == false)
                    {
                        MessageBox.Show("原料成本必须是数字！");
                        return;
                    }
                    if (float.TryParse(rengongchengben, out a) == false)
                    {
                        MessageBox.Show("人工成本必须是数字！");
                        return;
                    }
                    string sql2 = "update tb_caigouliaodan  set 制造类型= '" + zhizaoleixing + "',生产部确认= 0,编码='" + bianma + "' ,原料成本= '" + yuanliaochengben + "',人工成本= '" + rengongchengben + "' where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql2, CommandType.Text);
                }
                if (zhizaoleixing != "外协零部件")
                {
                    
                    string sql2 = "update tb_caigouliaodan  set 制造类型= '" + zhizaoleixing + "',生产部确认= 0,编码='" + bianma + "'  where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql2, CommandType.Text);
                }
            }
            MessageBox.Show("保存成功！");
            this.Close();
        }

        private void 导出表格ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "导出Excel";
            fileDialog.Filter = "Excel文件(*.xls)|*.xls";
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                gridControl4.ExportToXls(fileDialog.FileName);
                DevExpress.XtraEditors.XtraMessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        
        private void 添加更改图纸ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name;
            long fileSize = 0;//文件大小
            string fileName = null;//文件名字
            string fileType = null;//文件类型
            byte[] files;//文件
            BinaryReader read = null;//二进制读取
            string mingcheng;
            string id = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id"));

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

                string ConStr = "update tb_caigouliaodan  set 附件=@pic where id='" + id + "'";
                SQLhelp.ExecuteNonquery(ConStr, CommandType.Text, files);

                string sql = "update tb_caigouliaodan  set 附件名称='" + mingcheng + "',附件类型='" + fileType + "' where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);
              
                Reload();
                
            }
        }
        string shujv;
       
        private void 添加工序选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id"));
            Frgongxuxuanze form1 = new Frgongxuxuanze();
            form1.id = id;
            form1.ShowDialog();
            
        }
        
        private void 匹配新ERP编码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView4.RowCount; i++)
            {
                string mingcheng = gridView4.GetRowCellValue(i, "制造类型").ToString();
                if (mingcheng == "自制零部件" || mingcheng == "外协零部件" || mingcheng == "装配零部件" || mingcheng == "零件")
                {
                    string xinghao = gridView4.GetRowCellValue(i, "名称").ToString();
                    string xinghao1 = gridView4.GetRowCellValue(i, "型号").ToString();
                    string sql = "select 新编号,单位 from tb_xinerp where 三级='" + xinghao + "' and 四级='" + xinghao1 + "'";
                    DataTable dtt = SQLhelp.GetDataTable(sql, CommandType.Text);
                    if (dtt.Rows.Count > 0)
                    {
                        gridView4.SetRowCellValue(i, gridView4.Columns["编码"], dtt.Rows[0]["新编号"].ToString());
                        gridView4.SetRowCellValue(i, gridView4.Columns["单位"], dtt.Rows[0]["单位"].ToString());
                    }
                }
            }
            MessageBox.Show("匹配成功！");        
        }

        private void 查询ERPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frerpcreat from1 = new Frerpcreat();
            from1.yonghu = yonghu;
            from1.Show();
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "附件名称")) == "")
            {
                MessageBox.Show("没有附件！");
                return;
            }
            if (Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "附件名称")) != "")
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
            
        }

        private void 设置工序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shujv = "";
            string id = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id"));
            string sql = "select 车,铣,钳,磨,镗,线切割,表面处理,热处理 from tb_caigouliaodan where id='" + id + "'";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

            if (Convert.ToString(dt.Rows[0]["车"]) == "1")
            {
                shujv += "车、";


            }

            if (Convert.ToString(dt.Rows[0]["铣"]) == "1")
            {
                shujv += "铣、";


            }
            if (Convert.ToString(dt.Rows[0]["钳"]) == "1")
            {
                shujv += "钳、";


            }
            if (Convert.ToString(dt.Rows[0]["磨"]) == "1")
            {
                shujv += "磨、";


            }
            if (Convert.ToString(dt.Rows[0]["镗"]) == "1")
            {
                shujv += "镗、";


            }
            if (Convert.ToString(dt.Rows[0]["线切割"]) == "1")
            {
                shujv += "线切割、";


            }
            if (Convert.ToString(dt.Rows[0]["表面处理"]) == "1")
            {
                shujv += "表面处理、";


            }
            if (Convert.ToString(dt.Rows[0]["热处理"]) == "1")
            {
                shujv += "热处理";

            }

            MessageBox.Show(shujv);
            
        }

        private void gridControl4_Click(object sender, EventArgs e)
        {

        }
    }

}
