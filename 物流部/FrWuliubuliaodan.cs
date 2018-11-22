using Aspose.Cells;
using Aspose.Words;
using Aspose.Words.Drawing;
using DevComponents.DotNetBar;
using NetWorkLib.View;
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
using ThoughtWorks.QRCode.Codec;

namespace 项目管理系统.物流部
{
    public partial class FrWuliubuliaodan : Office2007Form
    {
        public FrWuliubuliaodan()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string gongzuolinghao;
        public string xiangmumingcheng;
        public string shijian;
        public string lujing;
        DataTable dt;
        public string yonghu;
        public string shebei;
        private void FrWuliubuliaodan_Load(object sender, EventArgs e)
        {
            Reload();
        }

        public void Reload()
        {
            string sql1 = "select  工作令号,项目名称,设备名称,id,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,申购人,收到料单日期,供方名称,合同号,实际采购数量,采购单价,当前状态,采购料单备注,附件名称,附件类型,人工成本,原料成本 from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "' and 设备名称='" + shebei + "' and   制造类型!='自制零部件' and   制造类型!='装配零部件'  and   制造类型!='库存件'";
            dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridControl4.DataSource = dt;


        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] a = gridView4.GetSelectedRows();
            foreach (int i in a)
            {
                string id = Convert.ToString(gridView4.GetRowCellValue(i, "id"));
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
            }


            foreach (int i in a)
            {
                string id = gridView4.GetRowCellValue(i, "id").ToString(); ;

                float b = 0;
                if (float.TryParse(gridView4.GetRowCellValue(i, "实际采购数量").ToString(), out b) == false)
                {
                    MessageBox.Show("其中有的采购数量写的不是数字，请重新填写！");
                    return;
                }
                string hetonghao = Convert.ToString(gridView4.GetRowCellValue(i, "合同号"));
                string shijicaigoushuliang = gridView4.GetRowCellValue(i, "实际采购数量").ToString();
                string caigoudanjia = Convert.ToString(gridView4.GetRowCellValue(i, "采购单价"));
                string caigouliaodanbeizhu = Convert.ToString(gridView4.GetRowCellValue(i, "采购料单备注"));
                string sql2 = "update tb_caigouliaodan  set 合同号= '" + hetonghao + "',实际采购数量=  '" + shijicaigoushuliang + "',采购单价 ='" + caigoudanjia + "',采购料单备注='" + caigouliaodanbeizhu + "'where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql2, CommandType.Text);
            }
            MessageBox.Show("提交成功！");
            Reload();
        }

        private void 导出料单ToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void 导出所有附件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog lujingg = new FolderBrowserDialog();
            if (lujingg.ShowDialog() == DialogResult.OK)
            {
                string xuanzelujing = lujingg.SelectedPath;
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    string mingcheng = Convert.ToString(dt.Rows[i]["附件名称"]);
                    string id = Convert.ToString(dt.Rows[i]["id"]);
                    if (mingcheng != "")
                    {

                        string leixing = dt.Rows[i]["附件类型"].ToString();

                        try
                        {
                            byte[] mypdffile = null;
                            string ConStr = "Select 附件 From tb_caigouliaodan Where id='" + id + "'";
                            mypdffile = SQLhelp.duqu(ConStr, CommandType.Text);
                            string lujing = xuanzelujing + "\\" + mingcheng + "." + leixing;
                            FileStream fs = new FileStream(lujing, FileMode.Create);
                            fs.Write(mypdffile, 0, mypdffile.Length);
                            fs.Flush();
                            fs.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);//显示异常信息
                        }
                    }

                }
                MessageBox.Show("下载成功");//显示异常信息
            }
        }

        string shujv;
        private void 查看需要工序ToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void buttonItem11_Click(object sender, EventArgs e)
        {
            Frjisuanjine form1 = new Frjisuanjine();
            form1.gongzuolinghao = gongzuolinghao;
            form1.xiangmumingcheng = xiangmumingcheng;
            form1.shijian = shijian;
            form1.Show();
        }
        private void 分解料单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frfenjie form1 = new Frfenjie();
            form1.shuliang = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "实际采购数量"));
            int c = Convert.ToInt32(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "实际采购数量"));
            form1.ShowDialog();
            if (form1.DialogResult == DialogResult.OK)
            {
                int a = Convert.ToInt32(form1.xinde);
                int b = c - a;

                string id = this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id").ToString();

                string sql = " insert into tb_caigouliaodan (工作令号, 项目名称, 设备名称,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,时间,制造类型,生产部确认,生产部确认时间,加工预计结束时间,仓库确认,仓库确认时间,申购人,收到料单日期,供方名称,合同号,实际采购数量,报价,采购单价,实际到货日期,当前状态,附件,附件名称,附件类型,采购料单备注,车,铣,钳,磨,镗,线切割,表面处理,热处理,采购类型,料单类型) select 工作令号, 项目名称, 设备名称,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,时间,制造类型,生产部确认,生产部确认时间,加工预计结束时间,仓库确认,仓库确认时间,申购人,收到料单日期,供方名称,合同号,实际采购数量,报价,采购单价,实际到货日期,当前状态,附件,附件名称,附件类型,采购料单备注,车,铣,钳,磨,镗,线切割,表面处理,热处理,采购类型,料单类型  from tb_caigouliaodan where id = '" + id + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);
                string sql1 = "update tb_caigouliaodan set 实际采购数量='" + b + "' where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql1, CommandType.Text);
                MessageBox.Show("分解成功！");
                Reload();
            }
        }

        private void 外协转自制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认转自制吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string a = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "制造类型"));
                if (a != "外协零部件")
                {
                    MessageBox.Show("只有外协零部件才可以转自制，请重新确认！");
                    return;
                }
                if (a == "外协零部件")
                {

                    string id = this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id").ToString();


                    string sql12 = "select 发票匹配,名称 from tb_caigouliaodan where id='" + id + "'";
                    DataTable dt = SQLhelp.GetDataTable(sql12, CommandType.Text);
                    if (Convert.ToString(dt.Rows[0]["发票匹配"]) != "")
                    {
                        string migncheng = dt.Rows[0]["名称"].ToString();
                        MessageBox.Show(migncheng + "已录入发票，无法再修改！");
                        return;
                    }                    
                    string sql = "update tb_caigouliaodan set 制造类型='外协转自制',流程状态='转精工事业部审批' where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql, CommandType.Text);
                    string xinghao = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "型号"));
                    string mingcheng = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "名称"));
                    string xuhao = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "序号"));
                    string bianma = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "编码"));
                    string shuliang = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "数量"));
                    string danwei = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "单位"));
                    string leixing = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "类型"));
                    string yaoqiudaohuoriqi = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "要求到货日期"));
                    string beizhu = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "备注"));
                    string zhizaoleixing = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "制造类型"));
                    string shijian = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "时间"));

                    string shijicaigoushuliang = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "实际采购数量"));
                    string gonglinghao = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "工作令号"));
                    string shebeimingcheng = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "设备名称"));
                    string xiangmumingcheng = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "项目名称"));
                    string sql3 = "INSERT INTO tb_zizhizhuanwaixie(工作令号,项目名称,设备名称,序号,编码,型号,名称,单位,数量,类型,时间,实际采购数量,修改时间,修改内容) VALUES( '" + gonglinghao + "', '" + xiangmumingcheng + "', '" + shebeimingcheng + "','" + xuhao + "', '" + bianma + "', '" + xinghao + "', '" + mingcheng + "','" + danwei + "', '" + shuliang + "', '" + leixing + "', '" + shijian + "','" + shijicaigoushuliang + "','" + DateTime.Now + "','外协转自制')";
                    SQLhelp.ExecuteScalar(sql3, CommandType.Text);
                    MessageBox.Show("申请成功！");
                    Reload();
                }
            }

        }

        private void 更改图纸ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name;
            long fileSize = 0;//文件大小
            string fileName = null;//文件名字
            string fileType = null;//文件类型
            byte[] files;//文件
            BinaryReader read = null;//二进制读取
            string mingcheng;
            string id = this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id").ToString();
            string sql12 = "select 发票匹配,名称 from tb_caigouliaodan where id='" + id + "'";
            DataTable dt = SQLhelp.GetDataTable(sql12, CommandType.Text);
            if (Convert.ToString(dt.Rows[0]["发票匹配"]) != "")
            {
                string migncheng = dt.Rows[0]["名称"].ToString();
                MessageBox.Show(migncheng + "已录入发票，无法再修改！");
                return;
            }
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



        //private void 到货ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    string id = dataGridViewX2.CurrentRow.Cells["id"].Value.ToString();
        //    到货记录 dahuoForm = new 到货记录(id);
        //    dahuoForm.ShowDialog();



        //}

        //private void 到货记录ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    string id = dataGridViewX2.CurrentRow.Cells["id"].Value.ToString();
        //    查看到货记录 查看到货记录 = new 查看到货记录(id);
        //    查看到货记录.ShowDialog();

        //}

        //private void buttonItem1_Click_1(object sender, EventArgs e)
        //{
        //    for (int i = 0; i < dataGridViewX2.Rows.Count; i++)
        //    {
        //        if ((bool)dataGridViewX2.Rows[i].Cells["筛选"].EditedFormattedValue == true)
        //        {
        //            string id = dataGridViewX2.Rows[i].Cells["id"].Value.ToString();
        //            string 到货验收数量 = dataGridViewX2.Rows[i].Cells["到货验收数量"].Value.ToString();
        //            string sql = "insert into tb_daohuoyanshou(定位,发起人,发起时间,总数量) values('" + id+"','"+yonghu+"','" + DateTime.Now+"',"+ 到货验收数量+")";

        //            SQLhelp.ExecuteScalar(sql, CommandType.Text);
        //        }


        //    }
        //    this.Close();
        //    MessageBox.Show("发起成功");
        //}

        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id")) == "")
            {

                MessageBox.Show("没有附件！");
                return;
            }
            if (Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id")) != "")
            {
                string id = this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id").ToString();

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

        private void 取消采购ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] a = gridView4.GetSelectedRows();
            foreach (int i in a)
            {

                string id = Convert.ToString(gridView4.GetRowCellValue(i, "id"));
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

            }
            foreach (int i in a)
            {
                string dangqianzhuangtai= this.gridView4.GetRowCellValue(i, "当前状态").ToString();

                if(dangqianzhuangtai=="9已到货" || dangqianzhuangtai == "10已出库" || dangqianzhuangtai == "10已出库")
                {
                    MessageBox.Show("只能取消没到货,没出库的！");
                    return;
                }
            }
                foreach (int i in a)
            {
                string id = this.gridView4.GetRowCellValue(i, "id").ToString();
                string sql = "update tb_caigouliaodan set 合同号='取消' ,当前状态='取消' where id='"+id+"'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);
                
            }
            MessageBox.Show("取消成功！");
            Reload();
        }

        private void 生成二维码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] a = gridView4.GetSelectedRows();


            string tempFile = Application.StartupPath + "\\二维码文件.doc";
            Document doc = new Document(tempFile);
            DocumentBuilder builder = new DocumentBuilder(doc);
            NodeCollection allTables = doc.GetChildNodes(NodeType.Table, true);

            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (int i in a)
            {
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
                string id = Convert.ToString(gridView4.GetRowCellValue(i, "id"));
                string gonglinghao = Convert.ToString(gridView4.GetRowCellValue(i, "工作令号"));
                string xiangmumingcheng = Convert.ToString(gridView4.GetRowCellValue(i, "项目名称"));
                string shebeimingcheng = Convert.ToString(gridView4.GetRowCellValue(i, "设备名称"));
                string bianma = Convert.ToString(gridView4.GetRowCellValue(i, "编码"));
                string mingcheng1 = Convert.ToString(gridView4.GetRowCellValue(i, "名称"));
                string xinghao1 = Convert.ToString(gridView4.GetRowCellValue(i, "型号"));
                string gongyingshang = Convert.ToString(gridView4.GetRowCellValue(i, "供方名称"));
                string hetonghao = Convert.ToString(gridView4.GetRowCellValue(i, "合同号"));
                string shuliang = "采购数量：" + Convert.ToString(gridView4.GetRowCellValue(i, "实际采购数量"));
                string dataCode = id + "|" + bianma + "|" + gongyingshang + "|" + hetonghao + "|";
                Image image;
                string data = dataCode;
                image = qrCodeEncoder.Encode(data, Encoding.UTF8);
                System.Drawing.Bitmap newImg;
                newImg = new Bitmap(image.Width + 200, image.Height + 40);
                Graphics g = Graphics.FromImage(newImg);
                g.Clear(Color.White);
                g.DrawImageUnscaled(image, 0, 0);
                System.Drawing.Font font = new System.Drawing.Font("黑体", 11, FontStyle.Bold);
                SolidBrush brush = new SolidBrush(Color.Black);
                g.DrawString(gonglinghao, font, brush, image.Width, 0);
                g.DrawString(bianma, font, brush, image.Width, 25);
                g.DrawString(mingcheng1, font, brush, image.Width, 50);
                g.DrawString(xinghao1, font, brush, image.Width, 75);
                g.DrawString(gongyingshang, font, brush, image.Width, 100);
                g.DrawString(hetonghao, font, brush, image.Width, 125);
                g.DrawString(shuliang, font, brush, image.Width, 150);
                image = newImg;
                string erweima = "二维码" + i;
                builder.MoveToBookmark(erweima);
                builder.InsertImage(image, RelativeHorizontalPosition.Margin, 1, RelativeVerticalPosition.Margin, 1, 180, 117, WrapType.Square);
            }
            Random suiji = new Random();
            int n = suiji.Next(0, 1000);
            string mingcheng = DateTime.Now.ToString("yyyy-MM-dd") + "二维码文件" + n + ".doc";
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
