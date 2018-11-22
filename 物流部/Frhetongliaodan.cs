using Aspose.Words;
using Aspose.Words.Drawing;
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
using ThoughtWorks.QRCode.Codec;

namespace 项目管理系统.物流部
{
    public partial class Frhetongliaodan : Office2007Form
    {
        public Frhetongliaodan()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }
        public string yonghu;
        public string hetonghao;
        private long fileSize = 0;//文件大小
        private string fileName = null;//文件名字
        private string fileType = null;//文件类型
        private byte[] files;//文件
        private BinaryReader read = null;//二进制读取
        public string mingcheng;
        private DataTable dt;

        private void Frhetongliaodan_Load(object sender, EventArgs e)
        {
            string sql1 = "select id,工作令号,项目名称,设备名称,编码,型号,名称,单位,数量,类型,备注,制造类型,申购人,收到料单日期,供方名称,合同号,实际采购数量,采购单价,当前状态,采购料单备注,料单序号 from  tb_caigouliaodan  where 合同号='" + hetonghao + "'order by 料单序号+0 ";
            dt= SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridControl1.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridView1.Columns["id"].Visible = false;


        }
        private void 生成设备合同ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            DataTable zongbiao1 = new DataTable();

            dt1.Columns.Add("id");
            dt1.Columns.Add("工作令号");
            dt1.Columns.Add("项目名称");
            dt1.Columns.Add("设备名称");
            dt1.Columns.Add("编码");
            dt1.Columns.Add("名称");
            dt1.Columns.Add("型号");
            dt1.Columns.Add("实际采购数量");
            dt1.Columns.Add("采购单价");
            dt1.Columns.Add("总价");
            dt1.Columns.Add("单位");

            zongbiao1.Columns.Add("id");
            zongbiao1.Columns.Add("工作令号");
            zongbiao1.Columns.Add("项目名称");
            zongbiao1.Columns.Add("设备名称");
            zongbiao1.Columns.Add("编码");
            zongbiao1.Columns.Add("名称");
            zongbiao1.Columns.Add("型号");
            zongbiao1.Columns.Add("实际采购数量");
            zongbiao1.Columns.Add("采购单价");
            zongbiao1.Columns.Add("总价");
            zongbiao1.Columns.Add("单位");
            for (int i = 0; i < gridView1.RowCount; i++)
            {


                string id = gridView1.GetRowCellValue(i, "id").ToString();

                string sql1 = "select id,编码,名称,单位,型号,实际采购数量,工作令号,备注,设备名称,项目名称,采购单价,类型 from  tb_caigouliaodan  where id ='" + id + "' ";
                dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);

                zongbiao1.Merge(dt1, true, MissingSchemaAction.Ignore);
            }
            Frhetongmoban form1 = new Frhetongmoban();
            form1.dt = zongbiao1;
            form1.yonghu = yonghu;
            form1.zhonglei = "设备";
            form1.ShowDialog();

        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }
        private void buttonItem1_Click(object sender, EventArgs e)
        {
            int[] a = gridView1.GetSelectedRows();
            foreach (int i in a)
            {
                string id = Convert.ToString(gridView1.GetRowCellValue(i, "id"));
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
            DataTable dt1 = new DataTable();
            DataTable zongbiao1 = new DataTable();
            dt1.Columns.Add("id");
            dt1.Columns.Add("工作令号");
            dt1.Columns.Add("项目名称");
            dt1.Columns.Add("设备名称");
            dt1.Columns.Add("编码");
            dt1.Columns.Add("名称");
            dt1.Columns.Add("型号");
            dt1.Columns.Add("类型");
            dt1.Columns.Add("实际采购数量");
            dt1.Columns.Add("采购单价");
            dt1.Columns.Add("总价");
            dt1.Columns.Add("备注");
            dt1.Columns.Add("单位");
            zongbiao1.Columns.Add("id");
            zongbiao1.Columns.Add("工作令号");
            zongbiao1.Columns.Add("项目名称");
            zongbiao1.Columns.Add("设备名称");
            zongbiao1.Columns.Add("编码");
            zongbiao1.Columns.Add("名称");
            zongbiao1.Columns.Add("型号");
            zongbiao1.Columns.Add("类型");
            zongbiao1.Columns.Add("实际采购数量");
            zongbiao1.Columns.Add("采购单价");
            zongbiao1.Columns.Add("总价");
            zongbiao1.Columns.Add("备注");
            zongbiao1.Columns.Add("单位");
            foreach (int i in a)
            {

                string id = gridView1.GetRowCellValue(i, "id").ToString();
                string sql1 = "select id,编码,名称,单位,型号,实际采购数量,工作令号,备注,设备名称,项目名称,采购单价,类型 from  tb_caigouliaodan  where id ='" + id + "' ";
                dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);
                zongbiao1.Merge(dt1, true, MissingSchemaAction.Ignore);

            }
            Frhetongmoban form1 = new Frhetongmoban();
            form1.dt = zongbiao1;
            form1.yonghu = yonghu;
            form1.zhonglei = "普通";
            form1.ShowDialog();

        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            int[] a = gridView1.GetSelectedRows();
            foreach (int i in a)
            {
                string id = Convert.ToString(gridView1.GetRowCellValue(i, "id"));
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


            DataTable dt1 = new DataTable();
            DataTable zongbiao1 = new DataTable();

            dt1.Columns.Add("id");
            dt1.Columns.Add("工作令号");
            dt1.Columns.Add("项目名称");
            dt1.Columns.Add("设备名称");
            dt1.Columns.Add("编码");
            dt1.Columns.Add("名称");
            dt1.Columns.Add("型号");
            dt1.Columns.Add("类型");
            dt1.Columns.Add("实际采购数量");
            dt1.Columns.Add("采购单价");
            dt1.Columns.Add("总价");
            dt1.Columns.Add("备注");
            dt1.Columns.Add("单位");
            zongbiao1.Columns.Add("id");
            zongbiao1.Columns.Add("工作令号");
            zongbiao1.Columns.Add("项目名称");
            zongbiao1.Columns.Add("设备名称");
            zongbiao1.Columns.Add("编码");
            zongbiao1.Columns.Add("名称");
            zongbiao1.Columns.Add("型号");
            zongbiao1.Columns.Add("类型");
            zongbiao1.Columns.Add("实际采购数量");
            zongbiao1.Columns.Add("采购单价");
            zongbiao1.Columns.Add("总价");
            zongbiao1.Columns.Add("备注");
            zongbiao1.Columns.Add("单位");


         

            foreach (int i in a)
            {



                string id = gridView1.GetRowCellValue(i, "id").ToString();
                string sql1 = "select id,编码,名称,单位,型号,实际采购数量,工作令号,备注,设备名称,项目名称,采购单价,类型 from  tb_caigouliaodan  where id ='" + id + "' ";
                dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);

                zongbiao1.Merge(dt1, true, MissingSchemaAction.Ignore);



            }
            Frhetongmoban form1 = new Frhetongmoban();
            form1.dt = zongbiao1;
            form1.yonghu = yonghu;
            form1.zhonglei = "设备";
            form1.ShowDialog();

        }
        private void buttonItem3_Click(object sender, EventArgs e)
        {
            int[] a = gridView1.GetSelectedRows();
            foreach (int i in a)
            {
                string id = Convert.ToString(gridView1.GetRowCellValue(i, "id"));
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
            DataTable dt1 = new DataTable();
            DataTable zongbiao1 = new DataTable();
            dt1.Columns.Add("id");
            dt1.Columns.Add("工作令号");
            dt1.Columns.Add("项目名称");
            dt1.Columns.Add("设备名称");
            dt1.Columns.Add("编码");
            dt1.Columns.Add("名称");
            dt1.Columns.Add("型号");
            dt1.Columns.Add("类型");
            dt1.Columns.Add("实际采购数量");
            dt1.Columns.Add("采购单价");
            dt1.Columns.Add("总价");
            dt1.Columns.Add("备注");
            dt1.Columns.Add("单位");
            zongbiao1.Columns.Add("id");
            zongbiao1.Columns.Add("工作令号");
            zongbiao1.Columns.Add("项目名称");
            zongbiao1.Columns.Add("设备名称");
            zongbiao1.Columns.Add("编码");
            zongbiao1.Columns.Add("名称");
            zongbiao1.Columns.Add("型号");
            zongbiao1.Columns.Add("类型");
            zongbiao1.Columns.Add("实际采购数量");
            zongbiao1.Columns.Add("采购单价");
            zongbiao1.Columns.Add("总价");
            zongbiao1.Columns.Add("备注");
            zongbiao1.Columns.Add("单位");
            foreach (int i in a)
            {
                string id = gridView1.GetRowCellValue(i, "id").ToString();
                string sql1 = "select id,编码,名称,单位,型号,实际采购数量,工作令号,备注,设备名称,项目名称,采购单价,类型 from  tb_caigouliaodan  where id ='" + id + "' ";
                dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);
                zongbiao1.Merge(dt1, true, MissingSchemaAction.Ignore);
            }
            Frhetongmoban form1 = new Frhetongmoban();
            form1.dt = zongbiao1;
            form1.yonghu = yonghu;
            form1.zhonglei = "采购";
            form1.ShowDialog();
        }



        private void buttonItem5_Click(object sender, EventArgs e)
        {
            int[] a = gridView1.GetSelectedRows();
            foreach (int i in a)
            {
                string id = Convert.ToString(gridView1.GetRowCellValue(i, "id"));
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

            DataTable dt1 = new DataTable();
            DataTable zongbiao1 = new DataTable();
            dt1.Columns.Add("id");
            dt1.Columns.Add("工作令号");
            dt1.Columns.Add("项目名称");
            dt1.Columns.Add("设备名称");
            dt1.Columns.Add("编码");
            dt1.Columns.Add("名称");
            dt1.Columns.Add("型号");
            dt1.Columns.Add("类型");
            dt1.Columns.Add("实际采购数量");
            dt1.Columns.Add("采购单价");
            dt1.Columns.Add("总价");
            dt1.Columns.Add("备注");
            dt1.Columns.Add("单位");
            zongbiao1.Columns.Add("id");
            zongbiao1.Columns.Add("工作令号");
            zongbiao1.Columns.Add("项目名称");
            zongbiao1.Columns.Add("设备名称");
            zongbiao1.Columns.Add("编码");
            zongbiao1.Columns.Add("名称");
            zongbiao1.Columns.Add("型号");
            zongbiao1.Columns.Add("类型");
            zongbiao1.Columns.Add("实际采购数量");
            zongbiao1.Columns.Add("采购单价");
            zongbiao1.Columns.Add("总价");
            zongbiao1.Columns.Add("备注");
            zongbiao1.Columns.Add("单位");

            

            foreach (int i in a)
            {

                string id = gridView1.GetRowCellValue(i, "id").ToString();


                string sql1 = "select id,编码,名称,单位,型号,实际采购数量,工作令号,备注,设备名称,项目名称,采购单价,类型 from  tb_caigouliaodan  where id ='" + id + "' ";
                dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);

                zongbiao1.Merge(dt1, true, MissingSchemaAction.Ignore);


            }
            Frdingdan form1 = new Frdingdan();
            form1.dt = zongbiao1;
            form1.yonghu = yonghu;
            form1.zhonglei = "订单";
            form1.ShowDialog();
        }

        private void buttonItem6_Click(object sender, EventArgs e)
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

                string sql = "select * from tb_hetong where 合同号='" + hetonghao + "'";
                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
                if (dt.Rows.Count >= 1)
                {

                    string sql1 = "update tb_hetong set 合同号='" + hetonghao + "',合同类型='" + fileType + "',上传时间='" + DateTime.Now + "' where id='" + dt.Rows[0]["id"] + "'";
                    SQLhelp.ExecuteNonquery(sql1, CommandType.Text, files);


                }
                if (dt.Rows.Count == 0)
                {
                    string sql1 = "INSERT INTO tb_hetong(合同,合同号,合同类型,上传时间) VALUES (@pic,'" + hetonghao + "','" + fileType + "','" + DateTime.Now + "')";
                    SQLhelp.ExecuteNonquery(sql1, CommandType.Text, files);
                }

                MessageBox.Show("上传成功！");
            }
        }

        private void buttonItem7_Click(object sender, EventArgs e)
        {

            string sql = "select 合同号 from tb_hetong  where 合同号='" + hetonghao + "'";

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
                string sql1 = "select 合同号 from tb_hetong  where 合同号='" + hetonghao + "'";
                string mingcheng = SQLhelp.ExecuteScalar(sql1, CommandType.Text).ToString();
                string sql12 = "select 合同类型 from tb_hetong  where 合同号='" + hetonghao + "'";

                string leixing = SQLhelp.ExecuteScalar(sql12, CommandType.Text).ToString();
                string lujing = xuanzelujing + "\\" + mingcheng + "." + leixing;
                try
                {
                    if (jiance != "")
                    {

                        string sql123 = "select 合同 from tb_hetong where 合同号='" + hetonghao + "'";
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
        private void buttonItem4_Click(object sender, EventArgs e)
        {
            string tempFile = Application.StartupPath + "\\二维码文件.doc";
            Document doc = new Document(tempFile);
            DocumentBuilder builder = new DocumentBuilder(doc);
            NodeCollection allTables = doc.GetChildNodes(NodeType.Table, true);

            Dictionary<string, string> dic = new Dictionary<string, string>();

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string liaodanxuhao = Convert.ToString(gridView1.GetRowCellValue(i, "料单序号"));
                int m = i + 1;
                if (int.Parse(liaodanxuhao) != m)
                {
                    MessageBox.Show("尚未匹配料单序号！");
                    return;
                }
            }
            int[] a = gridView1.GetSelectedRows();

            if (a.Length == 0)
            {
                MessageBox.Show("尚未勾选！");
                return;
            }

            foreach (int i in a)
            {
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
                string id = Convert.ToString(gridView1.GetRowCellValue(i, "id"));
                string gonglinghao = Convert.ToString(gridView1.GetRowCellValue(i, "工作令号"));
                string xiangmumingcheng = Convert.ToString(gridView1.GetRowCellValue(i, "项目名称"));
                string shebeimingcheng = Convert.ToString(gridView1.GetRowCellValue(i, "设备名称"));
                string bianma = Convert.ToString(gridView1.GetRowCellValue(i, "编码"));
                string mingcheng1 = Convert.ToString(gridView1.GetRowCellValue(i, "名称"));
                string xinghao1 = Convert.ToString(gridView1.GetRowCellValue(i, "型号"));
                string gongyingshang = Convert.ToString(gridView1.GetRowCellValue(i, "供方名称"));
                string hetonghao = Convert.ToString(gridView1.GetRowCellValue(i, "合同号"));
                string shuliang = "采购数量：" + Convert.ToString(gridView1.GetRowCellValue(i, "实际采购数量"));
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
                string sql3 = "select 料单序号 from tb_caigouliaodan where id='" + id + "'";
                string liaodanxuhao = Convert.ToString(SQLhelp.ExecuteScalar(sql3, CommandType.Text));
                g.DrawString("序列号:" + liaodanxuhao, font, brush, image.Width, 175);
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

        #region 匹配料单号
        private void pipeiliaodanxuhao_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string id = gridView1.GetRowCellValue(i, "id").ToString();
                int m = i + 1;
                string sql1 = "update tb_caigouliaodan set 料单序号='" + m + "'where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql1, CommandType.Text);
            }
            MessageBox.Show("已匹配料单序号");
            Frhetongliaodan_Load(this, null);

        } 
        #endregion

        #region 取消采购ToolStripMenuItem_Click
        private void 取消采购ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] a = gridView1.GetSelectedRows();
            foreach (int i in a)
            {
                string id = Convert.ToString(gridView1.GetRowCellValue(i, "id"));
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

                string id = gridView1.GetRowCellValue(i, "id").ToString();
                string sql = "update tb_caigouliaodan set 合同号='取消' ,当前状态='取消' where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);
            }
        } 
        #endregion

        #region 重新生成成缆合同ToolStripMenuItem_Click
        private void 重新生成成缆合同ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] a = gridView1.GetSelectedRows();
            DataTable dt2 = new DataTable();//选中的内容
            DataTable dt22 = new DataTable();//选中的内容

            dt2.Columns.Add("id");
            dt2.Columns.Add("工作令号");
            dt2.Columns.Add("项目名称");
            dt2.Columns.Add("设备名称");
            dt2.Columns.Add("编码");
            dt2.Columns.Add("名称");
            dt2.Columns.Add("型号");
            dt2.Columns.Add("类型");
            dt2.Columns.Add("实际采购数量");
            dt2.Columns.Add("采购单价");
            dt2.Columns.Add("总价");
            dt2.Columns.Add("备注");
            dt2.Columns.Add("单位");
            dt2.Columns.Add("总价预留");
            dt2.Columns.Add("生成合同时间");
            dt2.Columns.Add("合同预计时间");
            dt2.Columns.Add("生产负责人");
            dt2.Columns.Add("生产负责人电话");

            decimal reslut = 0;
            foreach (int i in a)
            {
                string id = gridView1.GetRowCellValue(i, "id").ToString();
                string sql11 = "select id,编码,名称,单位,型号,实际采购数量,工作令号,备注,设备名称,项目名称,采购单价,类型 ,总价预留,合同预计时间,生成合同时间,生产负责人,生产负责人电话 from  tb_caigouliaodan  where id ='" + id + "' ";
                dt22 = SQLhelp.GetDataTable(sql11, CommandType.Text);
                dt2.Merge(dt22, true, MissingSchemaAction.Ignore);

            }
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string liaodanxuhao = Convert.ToString(gridView1.GetRowCellValue(i, "料单序号")).Trim();
                int m = i + 1;
                if (liaodanxuhao == string.Empty)
                {
                    MessageBox.Show("料单序号为空请匹配！");
                    return;
                }
                else if (Convert.ToInt32(liaodanxuhao) != m)
                {
                    MessageBox.Show("料单序号未匹配请先匹配！");
                    return;
                }
            }
            if (a.Length == 0)
            {
                MessageBox.Show("尚未勾选");
                return;

            }
            DataTable dtC = new DataTable();
            string sqlC = "select id,供方名称 from tb_caigoutaizhang where 合同号='" + hetonghao + "'";
            dtC = SQLhelp.GetDataTable(sqlC, CommandType.Text);
            //string ss = Convert.ToString(dt2.Rows[0]["生成合同时间"]);
            DataTable dd = new DataTable();
            string shengchangfuzeren = "";
            string shengchangfuzerendianhua = "";
            string datetime = "";
            for (int i = 0; i < dt2.Rows.Count; i++)
            {

                if (Convert.ToString(dt2.Rows[i]["生成合同时间"]) == "" || Convert.ToString(dt2.Rows[i]["生成合同时间"]) == null)
                {
                    continue;
                }
                else
                {
                    datetime = Convert.ToString(dt2.Rows[i]["生成合同时间"]);

                }

                if (Convert.ToString(dt2.Rows[i]["生产负责人"]) == "" || Convert.ToString(dt2.Rows[i]["生产负责人"]) == null)
                {
                    continue;
                }
                else
                {
                    shengchangfuzeren = Convert.ToString(dt2.Rows[i]["生产负责人"]);

                }

                if (Convert.ToString(dt2.Rows[i]["生产负责人电话"]) == "" || Convert.ToString(dt2.Rows[i]["生产负责人电话"]) == null)
                {
                    continue;
                }
                else
                {
                    shengchangfuzerendianhua = Convert.ToString(dt2.Rows[i]["生产负责人电话"]);
                }
            }

            //DateTime datetime2 = Convert.ToDateTime(datetime);
            ////}
            //DateTime daohuoriqi = Convert.ToDateTime(dt2.Rows[0]["合同预计时间"]);\
            DateTime datetime1 = Convert.ToDateTime(datetime);
            DateTime b = datetime1.AddDays(3);
            DateTime c = datetime1.AddDays(33);
            string qiandingshijian = b.ToString("yyyy年MM月dd日");
            string jiaohuoriqi = c.ToString("yyyy年MM月dd日");
            string qiandingyifang = dtC.Rows[0][1].ToString();
            string daohuoshijian = c.ToString("yyyy年MM月dd日");

            //签订方信息
            string sql1 = "select 单位名称,单位地址,法定代表人,委托代理人,电话,传真,税务登记号,开户银行,帐号,邮箱 from tb_gongfang where 单位名称='" + qiandingyifang + "'";
            DataTable daa = SQLhelp.GetDataTable(sql1, CommandType.Text);
            string danweidizhi = daa.Rows[0][1].ToString();
            string fadingdaibiaoren = daa.Rows[0][2].ToString();
            string weituodailiren = daa.Rows[0][3].ToString();
            string dianhua = daa.Rows[0][4].ToString();
            string chuanzhen = daa.Rows[0][5].ToString();
            string shuiwudengjihao = daa.Rows[0][6].ToString();
            string kaihuyinhang = daa.Rows[0][7].ToString();
            string zhanghao = daa.Rows[0][8].ToString();
            string youxiang = daa.Rows[0][9].ToString();
            //用户电话
            string sql12 = "select 电话  from tb_operator1 where 用户名='" + yonghu + "'";
            string caigoudianhua = Convert.ToString(SQLhelp.ExecuteScalar(sql12, CommandType.Text));
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("邮箱", typeof(string));
            dt1.Columns.Add("生产进度负责人", typeof(string));
            dt1.Columns.Add("负责人电话", typeof(string));
            dt1.Columns.Add("采购员电话", typeof(string));
            dt1.Columns.Add("合计1", typeof(string));
            dt1.Columns.Add("交货日期", typeof(string));
            dt1.Columns.Add("合同编号", typeof(string));
            dt1.Columns.Add("签订时间", typeof(string));
            dt1.Columns.Add("签订乙方", typeof(string));
            dt1.Columns.Add("合计", typeof(string));
            dt1.Columns.Add("合计大写", typeof(string));
            dt1.Columns.Add("到货时间", typeof(string));
            dt1.Columns.Add("用户", typeof(string));
            dt1.Columns.Add("单位名称", typeof(string));
            dt1.Columns.Add("单位地址", typeof(string));
            dt1.Columns.Add("法定代表人", typeof(string));
            dt1.Columns.Add("委托代理人", typeof(string));
            dt1.Columns.Add("电话", typeof(string));
            dt1.Columns.Add("传真", typeof(string));
            dt1.Columns.Add("税务登记号", typeof(string));
            dt1.Columns.Add("开户银行", typeof(string));
            dt1.Columns.Add("帐号", typeof(string));
            for (int i = 0; i < 200; i++)
            {
                dt1.Columns.Add("单位" + (i + 1), typeof(string));
                dt1.Columns.Add("ERP" + (i + 1), typeof(string));
                dt1.Columns.Add("产品名称" + (i + 1), typeof(string));
                dt1.Columns.Add("规格型号" + (i + 1), typeof(string));
                dt1.Columns.Add("数量" + (i + 1), typeof(string));
                dt1.Columns.Add("单价" + (i + 1), typeof(string));
                dt1.Columns.Add("总金额" + (i + 1), typeof(string));
                dt1.Columns.Add("备注" + (i + 1), typeof(string));
                dt1.Columns.Add("序号" + (i + 1), typeof(string));
                dt1.Columns.Add("类型" + (i + 1), typeof(string));
                dt1.Columns.Add("工令号" + (i + 1), typeof(string));
            }
            DataRow dr1 = dt1.NewRow();
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                if (Convert.ToString(dt2.Rows[i]["编码"]) == null)
                {
                    dr1["ERP" + (i + 1)] = "";
                }
                if (Convert.ToString(dt2.Rows[i]["编码"]) != null)
                {
                    dr1["ERP" + (i + 1)] = Convert.ToString(dt2.Rows[i]["编码"]);
                }
                if (Convert.ToString(dt2.Rows[i]["名称"]) == null)
                {
                    dr1["产品名称" + (i + 1)] = "";
                }
                if (Convert.ToString(dt2.Rows[i]["名称"]) != null)
                {
                    dr1["产品名称" + (i + 1)] = Convert.ToString(dt2.Rows[i]["名称"]);
                    dr1["序号" + (i + 1)] = i + 1;
                }

                if (Convert.ToString(dt2.Rows[i]["型号"]) == null)
                {
                    dr1["规格型号" + (i + 1)] = "";
                }

                if (Convert.ToString(dt2.Rows[i]["型号"]) != null)
                {
                    dr1["规格型号" + (i + 1)] = Convert.ToString(dt2.Rows[i]["型号"]);
                }

                if (Convert.ToString(dt2.Rows[i]["实际采购数量"]) == null)
                {
                    dr1["数量" + (i + 1)] = "";
                }

                if (Convert.ToString(dt2.Rows[i]["实际采购数量"]) != null)
                {
                    dr1["数量" + (i + 1)] = Convert.ToString(dt2.Rows[i]["实际采购数量"]);
                }


                if (Convert.ToString(dt2.Rows[i]["采购单价"]) == null)
                {
                    dr1["单价" + (i + 1)] = "";
                }

                if (Convert.ToString(dt2.Rows[i]["采购单价"]) != null)
                {
                    dr1["单价" + (i + 1)] = Convert.ToString(dt2.Rows[i]["采购单价"]);
                }


                if (Convert.ToString(dt2.Rows[i]["总价预留"]) == null)
                {
                    dr1["总金额" + (i + 1)] = "";
                }

                if (Convert.ToString(dt2.Rows[i]["总价预留"]) != null)

                {
                    if (Convert.ToString(dt2.Rows[i]["采购单价"]) != null)
                    {
                        double shuliang = Convert.ToDouble(dt2.Rows[i]["实际采购数量"]);
                        double danjia = Convert.ToDouble(dt2.Rows[i]["采购单价"]);
                        decimal zuizhong = decimal.Round(decimal.Parse((shuliang * danjia).ToString()), 2);
                        dr1["总金额" + (i + 1)] = zuizhong;
                        reslut = reslut + zuizhong;
                    }
                }

                if (Convert.ToString(dt2.Rows[i]["单位"]) == null)
                {
                    dr1["单位" + (i + 1)] = "";
                }

                if (Convert.ToString(dt2.Rows[i]["单位"]) != null)
                {
                    dr1["单位" + (i + 1)] = Convert.ToString(dt2.Rows[i]["单位"]);
                }

                if (Convert.ToString(dt2.Rows[i]["备注"]) == null)
                {
                    dr1["工令号" + (i + 1)] = "";
                }

                if (Convert.ToString(dt2.Rows[i]["备注"]) != null)
                {
                    dr1["工令号" + (i + 1)] = (Convert.ToString(dt2.Rows[i]["备注"]));
                }

                if (Convert.ToString(dt2.Rows[i]["类型"]) == null)
                {
                    dr1["类型" + (i + 1)] = "";
                }

                if (Convert.ToString(dt2.Rows[i]["类型"]) != null)
                {
                    dr1["类型" + (i + 1)] = (Convert.ToString(dt2.Rows[i]["类型"]));
                }

            }
            string heji = Convert.ToString(reslut);
            dr1["邮箱"] = youxiang;
            dr1["合同编号"] = hetonghao;
            dr1["签订时间"] = qiandingshijian;
            dr1["签订乙方"] = qiandingyifang;
            dr1["合计"] = heji;
            dr1["合计大写"] = MoneyToChinese(heji);
            dr1["合计1"] = MoneyToChinese(heji);
            dr1["到货时间"] = daohuoshijian;
            dr1["用户"] = yonghu;
            dr1["单位名称"] = qiandingyifang;
            dr1["单位地址"] = danweidizhi;
            dr1["法定代表人"] = fadingdaibiaoren;
            dr1["委托代理人"] = weituodailiren;
            dr1["电话"] = dianhua;
            dr1["传真"] = chuanzhen;
            dr1["税务登记号"] = shuiwudengjihao;
            dr1["开户银行"] = kaihuyinhang;
            dr1["帐号"] = zhanghao;
            dr1["交货日期"] = jiaohuoriqi;
            dr1["生产进度负责人"] = shengchangfuzeren;
            dr1["负责人电话"] = shengchangfuzerendianhua;
            dt1.Rows.Add(dr1);
            string tempFile = Application.StartupPath + "\\合同标准模板.doc";
            Document doc = new Document(tempFile);
            DocumentBuilder builder = new DocumentBuilder(doc);
            NodeCollection allTables = doc.GetChildNodes(NodeType.Table, true);
            Dictionary<string, string> dic = new Dictionary<string, string>();
            DataRow dr = dt1.Rows[0];
            dic.Add("负责人电话", dr["负责人电话"].ToString());
            dic.Add("生产进度负责人", dr["生产进度负责人"].ToString());
            dic.Add("合同编号", dr["合同编号"].ToString());
            dic.Add("签订时间", dr["签订时间"].ToString());
            dic.Add("签订乙方", dr["签订乙方"].ToString());
            dic.Add("合计", dr["合计"].ToString());
            dic.Add("用户", dr["用户"].ToString());
            dic.Add("单位名称", dr["单位名称"].ToString());
            dic.Add("单位地址", dr["单位地址"].ToString());
            dic.Add("法定代表人", dr["法定代表人"].ToString());
            dic.Add("委托代理人", dr["委托代理人"].ToString());
            dic.Add("电话", dr["电话"].ToString());
            dic.Add("传真", dr["传真"].ToString());
            dic.Add("税务登记号", dr["税务登记号"].ToString());
            dic.Add("开户银行", dr["开户银行"].ToString());
            dic.Add("帐号", dr["帐号"].ToString());
            dic.Add("合计1", dr["合计1"].ToString());
            dic.Add("合计大写", dr["合计大写"].ToString());
            dic.Add("到货时间", dr["到货时间"].ToString() + "前");


            for (int i = 0; i < 200; i++)
            {
                dic.Add("ERP" + (i + 1), dr["ERP" + (i + 1)].ToString());
                dic.Add("单位" + (i + 1), dr["单位" + (i + 1)].ToString());
                dic.Add("产品名称" + (i + 1), dr["产品名称" + (i + 1)].ToString());
                dic.Add("规格型号" + (i + 1), dr["规格型号" + (i + 1)].ToString());
                dic.Add("数量" + (i + 1), dr["数量" + (i + 1)].ToString());
                dic.Add("单价" + (i + 1), dr["单价" + (i + 1)].ToString());
                dic.Add("总金额" + (i + 1), dr["总金额" + (i + 1)].ToString());
                dic.Add("备注" + (i + 1), dr["备注" + (i + 1)].ToString());
                dic.Add("序号" + (i + 1), dr["序号" + (i + 1)].ToString());
                dic.Add("类型" + (i + 1), dr["类型" + (i + 1)].ToString());
                dic.Add("工令号" + (i + 1), dr["工令号" + (i + 1)].ToString());
            }
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
                string id = Convert.ToString(dt.Rows[i]["id"]);
                string gonglinghao = Convert.ToString(dt.Rows[i]["工作令号"]);
                string xiangmumingcheng = Convert.ToString(dt.Rows[i]["项目名称"]);
                string shebeimingcheng = Convert.ToString(dt.Rows[i]["设备名称"]);
                string bianma = Convert.ToString(dt.Rows[i]["编码"]);
                string mingcheng1 = Convert.ToString(dt.Rows[i]["名称"]);
                string xinghao1 = Convert.ToString(dt.Rows[i]["型号"]);
                string shuliang = "采购数量：" + Convert.ToString(dt.Rows[i]["实际采购数量"]);
                string gongyingshang = qiandingyifang;
                string hetonghao1 = hetonghao;
                string sql3 = "select 料单序号 from tb_caigouliaodan where id='" + id + "'";
                string liaodanxuhao = Convert.ToString(SQLhelp.ExecuteScalar(sql3, CommandType.Text));
                string dataCode = id + "|" + bianma + "|" + gongyingshang + "|" + hetonghao1 + "|";
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
                g.DrawString(hetonghao1, font, brush, image.Width, 125);
                g.DrawString(shuliang, font, brush, image.Width, 150);
                g.DrawString("序列号:" + liaodanxuhao, font, brush, image.Width, 175);
                image = newImg;
                string erweima = "二维码" + i;
                builder.MoveToBookmark(erweima);
                builder.InsertImage(image, RelativeHorizontalPosition.Margin, 1, RelativeVerticalPosition.Margin, 1, 180, 117, WrapType.Square);
            }

            foreach (var key in dic.Keys)
            {
                builder.MoveToBookmark(key);
                builder.Write(dic[key]);
            }
            Random suiji = new Random();
            int n = suiji.Next(0, 1000);
            string mingcheng = yonghu + DateTime.Now.ToString("yyyy-MM-dd") + "成缆合同模板" + n + ".doc";
            FileInfo info1 = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\" + mingcheng);
            string fileName11 = info1.Name.ToString();
            string floderName = fileName11.Substring(0, fileName11.Length - 4).ToString();


            doc.Save(info1.DirectoryName + "\\" + fileName11);
            string pathfilesave = info1.DirectoryName + "\\" + mingcheng;
            MessageBox.Show("已保存到桌面！");
            System.Diagnostics.Process.Start(pathfilesave);
        }

        #endregion


        #region 重新生成设备合同ToolStripMenuItem_Click
        private void 重新生成设备合同ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] a = gridView1.GetSelectedRows();
            DataTable dt2 = new DataTable();//选中的内容
            DataTable dt22 = new DataTable();//选中的内容
            DataTable dt1 = new DataTable();
            dt2.Columns.Add("id");
            dt2.Columns.Add("工作令号");
            dt2.Columns.Add("项目名称");
            dt2.Columns.Add("设备名称");
            dt2.Columns.Add("编码");
            dt2.Columns.Add("名称");
            dt2.Columns.Add("型号");
            dt2.Columns.Add("类型");
            dt2.Columns.Add("实际采购数量");
            dt2.Columns.Add("采购单价");
            dt2.Columns.Add("总价");
            dt2.Columns.Add("备注");
            dt2.Columns.Add("单位");
            dt2.Columns.Add("总价预留");
            dt2.Columns.Add("生成合同时间");
            dt2.Columns.Add("合同预计时间");
            dt2.Columns.Add("生产负责人");
            dt2.Columns.Add("生产负责人电话");
            decimal reslut = 0;

            foreach (int i in a)
            {
                string id = gridView1.GetRowCellValue(i, "id").ToString();
                string sql11 = "select id,编码,名称,单位,型号,实际采购数量,工作令号,备注,设备名称,项目名称,采购单价,类型 ,总价预留,合同预计时间,生成合同时间,生产负责人,生产负责人电话 from  tb_caigouliaodan  where id ='" + id + "' ";
                dt22 = SQLhelp.GetDataTable(sql11, CommandType.Text);
                dt2.Merge(dt22, true, MissingSchemaAction.Ignore);
            }

                    for (int i = 0; i < gridView1.RowCount; i++)
            {
                string liaodanxuhao = Convert.ToString(gridView1.GetRowCellValue(i, "料单序号")).Trim();
                int m = i + 1;
                if (liaodanxuhao==string.Empty)
                {
                    MessageBox.Show("料单序号为空请匹配！");
                    return;
                }
                else if(Convert.ToInt32(liaodanxuhao)!=m)
                {
                    MessageBox.Show("料单序号未匹配请先匹配！");
                    return;
                }
            }
            if (a.Length == 0)
            {
                MessageBox.Show("尚未勾选");
                return;
            }

            DataTable dtC = new DataTable();
            string sqlC = "select id,供方名称 from tb_caigoutaizhang where 合同号='" + hetonghao + "'";
            dtC = SQLhelp.GetDataTable(sqlC, CommandType.Text);
            //string ss = Convert.ToString(dt2.Rows[0]["生成合同时间"]);
            DataTable dd = new DataTable();
            //DateTime datetime = DateTime.Now;
            string shengchangfuzeren="";
            string shengchangfuzerendianhua="";
            string datetime = "";
            for(int i=0;i<dt2.Rows.Count;i++)
            {

                if (Convert.ToString(dt2.Rows[i]["生成合同时间"]) == "" || Convert.ToString(dt2.Rows[i]["生成合同时间"]) == null)
                {
                    continue;
                }
                else
                {
                    datetime = Convert.ToString(dt2.Rows[i]["生成合同时间"]);

                }

                if (Convert.ToString(dt2.Rows[i]["生产负责人"]) == "" || Convert.ToString(dt2.Rows[i]["生产负责人"]) == null)
                {
                    continue;
                }
                else
                {
                    shengchangfuzeren = Convert.ToString(dt2.Rows[i]["生产负责人"]);

                }

                if (Convert.ToString(dt2.Rows[i]["生产负责人电话"]) == "" || Convert.ToString(dt2.Rows[i]["生产负责人电话"]) == null)
                {
                    continue;
                }
                else
                {
                    shengchangfuzerendianhua = Convert.ToString(dt2.Rows[i]["生产负责人电话"]);
                }
            }

            //DateTime datetime2 = Convert.ToDateTime(datetime);
            ////}
            //DateTime daohuoriqi = Convert.ToDateTime(dt2.Rows[0]["合同预计时间"]);\
            DateTime datetime1 = Convert.ToDateTime(datetime);
            DateTime b = datetime1.AddDays(3);
            DateTime c = datetime1.AddDays(33);
            string qiandingshijian = b.ToString("yyyy年MM月dd日");
            string jiaohuoriqi = c.ToString("yyyy年MM月dd日");
            string qiandingyifang = dtC.Rows[0][1].ToString();
            string daohuoshijian = c.ToString("yyyy年MM月dd日");


            //签订方信息
            string sql1 = "select 单位名称,单位地址,法定代表人,委托代理人,电话,传真,税务登记号,开户银行,帐号,邮箱 from tb_gongfang where 单位名称='" +qiandingyifang + "'";
            DataTable daa = SQLhelp.GetDataTable(sql1, CommandType.Text);
            string danweidizhi = daa.Rows[0][1].ToString();
            string fadingdaibiaoren = daa.Rows[0][2].ToString();
            string weituodailiren = daa.Rows[0][3].ToString();
            string dianhua = daa.Rows[0][4].ToString();
            string chuanzhen = daa.Rows[0][5].ToString();
            string shuiwudengjihao = daa.Rows[0][6].ToString();
            string kaihuyinhang = daa.Rows[0][7].ToString();
            string zhanghao = daa.Rows[0][8].ToString();
            string youxiang = daa.Rows[0][9].ToString();
            //用户电话
            string sql12 = "select 电话  from tb_operator1 where 用户名='" + shengchangfuzeren + "'";
            string caigoudianhua = Convert.ToString(SQLhelp.ExecuteScalar(sql12, CommandType.Text));

                    dt1.Columns.Add("邮箱", typeof(string));
                    dt1.Columns.Add("生产进度负责人", typeof(string));
                    dt1.Columns.Add("负责人电话", typeof(string));
                    dt1.Columns.Add("合同编号", typeof(string));
                    dt1.Columns.Add("签订时间", typeof(string));
                    dt1.Columns.Add("签订乙方", typeof(string));
                    dt1.Columns.Add("合计", typeof(string));
                    dt1.Columns.Add("用户", typeof(string));
                    dt1.Columns.Add("单位名称", typeof(string));
                    dt1.Columns.Add("单位地址", typeof(string));
                    dt1.Columns.Add("法定代表人", typeof(string));
                    dt1.Columns.Add("委托代理人", typeof(string));
                    dt1.Columns.Add("电话", typeof(string));
                    dt1.Columns.Add("传真", typeof(string));
                    dt1.Columns.Add("税务登记号", typeof(string));
                    dt1.Columns.Add("开户银行", typeof(string));
                    dt1.Columns.Add("帐号", typeof(string));
                    dt1.Columns.Add("税务登记号1", typeof(string));
                    dt1.Columns.Add("开户银行1", typeof(string));
                    dt1.Columns.Add("单位名称1", typeof(string));
                    dt1.Columns.Add("帐号1", typeof(string));
                    dt1.Columns.Add("合计大写", typeof(string));
                    for (int i = 0; i < 100; i++)
                    {
                        dt1.Columns.Add("单位" + (i + 1), typeof(string));
                        dt1.Columns.Add("ERP" + (i + 1), typeof(string));
                        dt1.Columns.Add("产品名称" + (i + 1), typeof(string));
                        dt1.Columns.Add("规格型号" + (i + 1), typeof(string));
                        dt1.Columns.Add("数量" + (i + 1), typeof(string));
                        dt1.Columns.Add("单价" + (i + 1), typeof(string));
                        dt1.Columns.Add("总金额" + (i + 1), typeof(string));
                        dt1.Columns.Add("备注" + (i + 1), typeof(string));
                        dt1.Columns.Add("序号" + (i + 1), typeof(string));
                    }

            DataRow dr1 = dt1.NewRow();

            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                if (Convert.ToString(dt2.Rows[i]["编码"]) == null)
                {
                    dr1["ERP" + (i + 1)] = "";
                }
                if (Convert.ToString(dt2.Rows[i]["编码"]) != null)
                {
                    dr1["ERP" + (i + 1)] = Convert.ToString(dt2.Rows[i]["编码"]);
                }
                if (Convert.ToString(dt2.Rows[i]["名称"]) == null)
                {
                    dr1["产品名称" + (i + 1)] = "";
                }
                if (Convert.ToString(dt2.Rows[i]["名称"]) != null)
                {
                    dr1["产品名称" + (i + 1)] = Convert.ToString(dt2.Rows[i]["名称"]);
                    dr1["序号" + (i + 1)] = i + 1;
                }

                if (Convert.ToString(dt2.Rows[i]["型号"]) == null)
                {
                    dr1["规格型号" + (i + 1)] = "";
                }

                if (Convert.ToString(dt2.Rows[i]["型号"]) != null)
                {
                    dr1["规格型号" + (i + 1)] = Convert.ToString(dt2.Rows[i]["型号"]);
                }

                if (Convert.ToString(dt2.Rows[i]["实际采购数量"]) == null)
                {
                    dr1["数量" + (i + 1)] = "";
                }

                if (Convert.ToString(dt2.Rows[i]["实际采购数量"]) != null)
                {
                    dr1["数量" + (i + 1)] = Convert.ToString(dt2.Rows[i]["实际采购数量"]);
                }


                if (Convert.ToString(dt2.Rows[i]["采购单价"]) == null)
                {
                    dr1["单价" + (i + 1)] = "";
                }

                if (Convert.ToString(dt2.Rows[i]["采购单价"]) != null)
                {
                    dr1["单价" + (i + 1)] = Convert.ToString(dt2.Rows[i]["采购单价"]);
                }



                if (Convert.ToString(dt2.Rows[i]["单位"]) == null)
                {
                    dr1["单位" + (i + 1)] = "";
                }

                if (Convert.ToString(dt2.Rows[i]["单位"]) != null)
                {
                    dr1["单位" + (i + 1)] = Convert.ToString(dt2.Rows[i]["单位"]);
                }

                if (Convert.ToString(dt2.Rows[i]["总价预留"]) == null)
                {
                    dr1["总金额" + (i + 1)] = "";
                }

                if (Convert.ToString(dt2.Rows[i]["总价预留"]) != null)

                {
                    if (Convert.ToString(dt2.Rows[i]["采购单价"]) != null)
                    {
                        double shuliang = Convert.ToDouble(dt2.Rows[i]["实际采购数量"]);
                        double danjia = Convert.ToDouble(dt2.Rows[i]["采购单价"]);
                        decimal zuizhong = decimal.Round(decimal.Parse((shuliang * danjia).ToString()), 2);
                        dr1["总金额" + (i + 1)] = zuizhong;
                        reslut = reslut + zuizhong;
                    }
                }

                if (Convert.ToString(dt2.Rows[i]["工作令号"]) == null)
                {
                    dr1["备注" + (i + 1)] = "";
                }

                if (Convert.ToString(dt2.Rows[i]["工作令号"]) != null)
                {
                    dr1["备注" + (i + 1)] = (Convert.ToString(dt2.Rows[i]["工作令号"]));
                }

    

            }
            string heji = Convert.ToString(reslut);
            dr1["邮箱"] = youxiang;
            dr1["合同编号"] = hetonghao;
            dr1["签订时间"] = qiandingshijian;
            dr1["签订乙方"] = qiandingyifang;
            dr1["合计"] = heji;
            dr1["合计大写"] = MoneyToChinese(heji);
            dr1["用户"] = yonghu;
            dr1["单位名称"] = qiandingyifang;
            dr1["单位地址"] = danweidizhi;
            dr1["法定代表人"] = fadingdaibiaoren;
            dr1["委托代理人"] = weituodailiren;
            dr1["电话"] = dianhua;
            dr1["传真"] = chuanzhen;
            dr1["税务登记号"] = shuiwudengjihao;
            dr1["开户银行"] = kaihuyinhang;
            dr1["帐号"] = zhanghao;
            dr1["税务登记号1"] = shuiwudengjihao;
            dr1["开户银行1"] = kaihuyinhang;
            dr1["单位名称1"] = qiandingyifang;
            dr1["帐号1"] = zhanghao;
            dr1["生产进度负责人"] = shengchangfuzeren;
            dr1["负责人电话"] = shengchangfuzerendianhua;
            dt1.Rows.Add(dr1);
            string tempFile = Application.StartupPath + "\\设备合同模板.doc";
            Document doc = new Document(tempFile);
            DocumentBuilder builder = new DocumentBuilder(doc);
            NodeCollection allTables = doc.GetChildNodes(NodeType.Table, true);
            Dictionary<string, string> dic = new Dictionary<string, string>();
            DataRow dr = dt1.Rows[0];
            dic.Add("生产进度负责人", dr["生产进度负责人"].ToString());
            dic.Add("负责人电话", dr["负责人电话"].ToString());
            dic.Add("合同编号", dr["合同编号"].ToString());
            dic.Add("签订时间", dr["签订时间"].ToString());
            dic.Add("签订乙方", dr["签订乙方"].ToString());
            dic.Add("合计", dr["合计"].ToString());
            dic.Add("用户", dr["用户"].ToString());
            dic.Add("单位名称", dr["单位名称"].ToString());
            dic.Add("单位地址", dr["单位地址"].ToString());
            dic.Add("法定代表人", dr["法定代表人"].ToString());
            dic.Add("委托代理人", dr["委托代理人"].ToString());
            dic.Add("电话", dr["电话"].ToString());
            dic.Add("传真", dr["传真"].ToString());
            dic.Add("税务登记号", dr["税务登记号"].ToString());
            dic.Add("开户银行", dr["开户银行"].ToString());
            dic.Add("帐号", dr["帐号"].ToString());
            dic.Add("单位名称1", dr["单位名称1"].ToString());
            dic.Add("帐号1", dr["帐号1"].ToString());
            dic.Add("开户银行1", dr["开户银行1"].ToString());
            dic.Add("税务登记号1", dr["税务登记号1"].ToString());
            dic.Add("合计大写", dr["合计大写"].ToString());
            for (int i = 0; i < 100; i++)
            {
                dic.Add("ERP" + (i + 1), dr["ERP" + (i + 1)].ToString());
                dic.Add("单位" + (i + 1), dr["单位" + (i + 1)].ToString());
                dic.Add("产品名称" + (i + 1), dr["产品名称" + (i + 1)].ToString());
                dic.Add("规格型号" + (i + 1), dr["规格型号" + (i + 1)].ToString());
                dic.Add("数量" + (i + 1), dr["数量" + (i + 1)].ToString());
                dic.Add("单价" + (i + 1), dr["单价" + (i + 1)].ToString());
                dic.Add("总金额" + (i + 1), dr["总金额" + (i + 1)].ToString());
                dic.Add("备注" + (i + 1), dr["备注" + (i + 1)].ToString());
                dic.Add("序号" + (i + 1), dr["序号" + (i + 1)].ToString());
            }
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
                string id = Convert.ToString(dt.Rows[i]["id"]);
                string gonglinghao = Convert.ToString(dt.Rows[i]["工作令号"]);
                string xiangmumingcheng = Convert.ToString(dt.Rows[i]["项目名称"]);
                string shebeimingcheng = Convert.ToString(dt.Rows[i]["设备名称"]);
                string bianma = Convert.ToString(dt.Rows[i]["编码"]);
                string mingcheng1 = Convert.ToString(dt.Rows[i]["名称"]);
                string xinghao1 = Convert.ToString(dt.Rows[i]["型号"]);
                string shuliang = "采购数量：" + Convert.ToString(dt.Rows[i]["实际采购数量"]);
                string gongyingshang = qiandingyifang;
                string hetonghao1 = hetonghao;
                string sql3 = "select 料单序号 from tb_caigouliaodan where id='" + id + "'";
                string liaodanxuhao = Convert.ToString(SQLhelp.ExecuteScalar(sql3, CommandType.Text));
                string dataCode = id + "|" + bianma + "|" + gongyingshang + "|" + hetonghao1 + "|";
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
                g.DrawString(hetonghao1, font, brush, image.Width, 125);
                g.DrawString(shuliang, font, brush, image.Width, 150);
                g.DrawString("序列号:" + liaodanxuhao, font, brush, image.Width, 175);
                image = newImg;
                string erweima = "二维码" + i;

                builder.MoveToBookmark(erweima);
                builder.InsertImage(image, RelativeHorizontalPosition.Margin, 1, RelativeVerticalPosition.Margin, 1, 180, 117, WrapType.Square);
            }

            foreach (var key in dic.Keys)
            {
                builder.MoveToBookmark(key);
                builder.Write(dic[key]);
            }
            Random suiji = new Random();
            int n = suiji.Next(0, 1000);
            string mingcheng = yonghu + DateTime.Now.ToString("yyyy-MM-dd") + "设备合同模板" + n + ".doc";
            FileInfo info1 = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\" + mingcheng);
            string fileName11 = info1.Name.ToString();
            string floderName = fileName11.Substring(0, fileName11.Length - 4).ToString();
            doc.Save(info1.DirectoryName + "\\" + fileName11);
            string pathfilesave = info1.DirectoryName + "\\" + mingcheng;
            MessageBox.Show("已保存到桌面！");
            System.Diagnostics.Process.Start(pathfilesave);
        }
        #endregion

        #region 数字转大写金额MoneyToChinese
        /// <summary>
        /// 数字转大写金额
        /// </summary>
        /// <param name="LowerMoney"></param>
        /// <returns></returns>
        private string MoneyToChinese(string LowerMoney)
        {

            string functionReturnValue = null;
            bool IsNegative = false; // 是否是负数
            if (LowerMoney.Trim().Substring(0, 1) == "-")
            {
                // 是负数则先转为正数
                LowerMoney = LowerMoney.Trim().Remove(0, 1);
                IsNegative = true;
            }
            string strLower = null;
            string strUpart = null;
            string strUpper = null;
            int iTemp = 0;
            // 保留两位小数 123.489→123.49　　123.4→123.4
            LowerMoney = Math.Round(double.Parse(LowerMoney), 2).ToString();
            if (LowerMoney.IndexOf(".") > 0)
            {
                if (LowerMoney.IndexOf(".") == LowerMoney.Length - 2)
                {
                    LowerMoney = LowerMoney + "0";
                }
            }
            else
            {
                LowerMoney = LowerMoney + ".00";
            }
            strLower = LowerMoney;
            iTemp = 1;
            strUpper = "";
            while (iTemp <= strLower.Length)
            {
                switch (strLower.Substring(strLower.Length - iTemp, 1))
                {
                    case ".":
                        strUpart = "圆";
                        break;
                    case "0":
                        strUpart = "零";
                        break;
                    case "1":
                        strUpart = "壹";
                        break;
                    case "2":
                        strUpart = "贰";
                        break;
                    case "3":
                        strUpart = "叁";
                        break;
                    case "4":
                        strUpart = "肆";
                        break;
                    case "5":
                        strUpart = "伍";
                        break;
                    case "6":
                        strUpart = "陆";
                        break;
                    case "7":
                        strUpart = "柒";
                        break;
                    case "8":
                        strUpart = "捌";
                        break;
                    case "9":
                        strUpart = "玖";
                        break;
                }

                switch (iTemp)
                {
                    case 1:
                        strUpart = strUpart + "分";
                        break;
                    case 2:
                        strUpart = strUpart + "角";
                        break;
                    case 3:
                        strUpart = strUpart + "";
                        break;
                    case 4:
                        strUpart = strUpart + "";
                        break;
                    case 5:
                        strUpart = strUpart + "拾";
                        break;
                    case 6:
                        strUpart = strUpart + "佰";
                        break;
                    case 7:
                        strUpart = strUpart + "仟";
                        break;
                    case 8:
                        strUpart = strUpart + "万";
                        break;
                    case 9:
                        strUpart = strUpart + "拾";
                        break;
                    case 10:
                        strUpart = strUpart + "佰";
                        break;
                    case 11:
                        strUpart = strUpart + "仟";
                        break;
                    case 12:
                        strUpart = strUpart + "亿";
                        break;
                    case 13:
                        strUpart = strUpart + "拾";
                        break;
                    case 14:
                        strUpart = strUpart + "佰";
                        break;
                    case 15:
                        strUpart = strUpart + "仟";
                        break;
                    case 16:
                        strUpart = strUpart + "万";
                        break;
                    default:
                        strUpart = strUpart + "";
                        break;
                }

                strUpper = strUpart + strUpper;
                iTemp = iTemp + 1;
            }

            strUpper = strUpper.Replace("零拾", "零");
            strUpper = strUpper.Replace("零佰", "零");
            strUpper = strUpper.Replace("零仟", "零");
            strUpper = strUpper.Replace("零零零", "零");
            strUpper = strUpper.Replace("零零", "零");
            strUpper = strUpper.Replace("零角零分", "整");
            strUpper = strUpper.Replace("零分", "整");
            strUpper = strUpper.Replace("零角", "零");
            strUpper = strUpper.Replace("零亿零万零圆", "亿圆");
            strUpper = strUpper.Replace("亿零万零圆", "亿圆");
            strUpper = strUpper.Replace("零亿零万", "亿");
            strUpper = strUpper.Replace("零万零圆", "万圆");
            strUpper = strUpper.Replace("零亿", "亿");
            strUpper = strUpper.Replace("零万", "万");
            strUpper = strUpper.Replace("零圆", "圆");
            strUpper = strUpper.Replace("零零", "零");

            // 对壹圆以下的金额的处理
            if (strUpper.Substring(0, 1) == "圆")
            {
                strUpper = strUpper.Substring(1, strUpper.Length - 1);
            }
            if (strUpper.Substring(0, 1) == "零")
            {
                strUpper = strUpper.Substring(1, strUpper.Length - 1);
            }
            if (strUpper.Substring(0, 1) == "角")
            {
                strUpper = strUpper.Substring(1, strUpper.Length - 1);
            }
            if (strUpper.Substring(0, 1) == "分")
            {
                strUpper = strUpper.Substring(1, strUpper.Length - 1);
            }
            if (strUpper.Substring(0, 1) == "整")
            {
                strUpper = "零圆整";
            }
            functionReturnValue = strUpper;

            if (IsNegative == true)
            {
                return "负" + functionReturnValue;
            }
            else
            {
                return functionReturnValue;
            }
        }
        #endregion
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void 重新生成采购合同ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] a = gridView1.GetSelectedRows();
            DataTable dt2 = new DataTable();//选中的内容
            DataTable dt22 = new DataTable();//选中的内容
            DataTable dt1 = new DataTable();
            dt2.Columns.Add("id");
            dt2.Columns.Add("工作令号");
            dt2.Columns.Add("项目名称");
            dt2.Columns.Add("设备名称");
            dt2.Columns.Add("编码");
            dt2.Columns.Add("名称");
            dt2.Columns.Add("型号");
            dt2.Columns.Add("类型");
            dt2.Columns.Add("实际采购数量");
            dt2.Columns.Add("采购单价");
            dt2.Columns.Add("总价");
            dt2.Columns.Add("备注");
            dt2.Columns.Add("单位");
            dt2.Columns.Add("总价预留");
            dt2.Columns.Add("生成合同时间");
            dt2.Columns.Add("合同预计时间");
            dt2.Columns.Add("生产负责人");
            dt2.Columns.Add("生产负责人电话");
            decimal reslut = 0;

            foreach (int i in a)
            {
                string id = gridView1.GetRowCellValue(i, "id").ToString();
                string sql11 = "select id,编码,名称,单位,型号,实际采购数量,工作令号,备注,设备名称,项目名称,采购单价,类型 ,总价预留,合同预计时间,生成合同时间,生产负责人,生产负责人电话 from  tb_caigouliaodan  where id ='" + id + "' ";
                dt22 = SQLhelp.GetDataTable(sql11, CommandType.Text);
                dt2.Merge(dt22, true, MissingSchemaAction.Ignore);
            }
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string liaodanxuhao = Convert.ToString(gridView1.GetRowCellValue(i, "料单序号")).Trim();
                int m = i + 1;
                if (liaodanxuhao==string.Empty)
                {
                    MessageBox.Show("料单序号为空请匹配！");
                    return;
                }
                else if(Convert.ToInt32(liaodanxuhao)!=m)
                {
                    MessageBox.Show("料单序号未匹配请先匹配！");
                    return;
                }
            }
            if (a.Length == 0)
            {
                MessageBox.Show("尚未勾选");
                return;
            }

            DataTable dtC = new DataTable();
            string sqlC = "select id,供方名称 from tb_caigoutaizhang where 合同号='" + hetonghao + "'";
            dtC = SQLhelp.GetDataTable(sqlC, CommandType.Text);
            //string ss = Convert.ToString(dt2.Rows[0]["生成合同时间"]);
            DataTable dd = new DataTable();
            //DateTime datetime = DateTime.Now;
            string shengchangfuzeren = "";
            string shengchangfuzerendianhua = "";
            string datetime = "";
            for (int i = 0; i < dt2.Rows.Count; i++)
            {

                if (Convert.ToString(dt2.Rows[i]["生成合同时间"]) == "" || Convert.ToString(dt2.Rows[i]["生成合同时间"]) == null)
                {
                    continue;
                }
                else
                {
                    datetime = Convert.ToString(dt2.Rows[i]["生成合同时间"]);

                }

                if (Convert.ToString(dt2.Rows[i]["生产负责人"]) == "" || Convert.ToString(dt2.Rows[i]["生产负责人"]) == null)
                {
                    continue;
                }
                else
                {
                    shengchangfuzeren = Convert.ToString(dt2.Rows[i]["生产负责人"]);

                }

                if (Convert.ToString(dt2.Rows[i]["生产负责人电话"]) == "" || Convert.ToString(dt2.Rows[i]["生产负责人电话"]) == null)
                {
                    continue;
                }
                else
                {
                    shengchangfuzerendianhua = Convert.ToString(dt2.Rows[i]["生产负责人电话"]);
                }
            }

            //DateTime datetime2 = Convert.ToDateTime(datetime);
            ////}
            //DateTime daohuoriqi = Convert.ToDateTime(dt2.Rows[0]["合同预计时间"]);\
            DateTime datetime1 = Convert.ToDateTime(datetime);
            DateTime b = datetime1.AddDays(3);
            DateTime c = datetime1.AddDays(33);
            string qiandingshijian = b.ToString("yyyy年MM月dd日");
            string jiaohuoriqi = c.ToString("yyyy年MM月dd日");
            string qiandingyifang = dtC.Rows[0][1].ToString();
            string daohuoshijian = c.ToString("yyyy年MM月dd日");


            //签订方信息
            string sql1 = "select 单位名称,单位地址,法定代表人,委托代理人,电话,传真,税务登记号,开户银行,帐号,邮箱 from tb_gongfang where 单位名称='" + qiandingyifang + "'";
            DataTable daa = SQLhelp.GetDataTable(sql1, CommandType.Text);
            string danweidizhi = daa.Rows[0][1].ToString();
            string fadingdaibiaoren = daa.Rows[0][2].ToString();
            string weituodailiren = daa.Rows[0][3].ToString();
            string dianhua = daa.Rows[0][4].ToString();
            string chuanzhen = daa.Rows[0][5].ToString();
            string shuiwudengjihao = daa.Rows[0][6].ToString();
            string kaihuyinhang = daa.Rows[0][7].ToString();
            string zhanghao = daa.Rows[0][8].ToString();
            string youxiang = daa.Rows[0][9].ToString();
            //用户电话
            string sql12 = "select 电话  from tb_operator1 where 用户名='" + shengchangfuzeren + "'";
            string caigoudianhua = Convert.ToString(SQLhelp.ExecuteScalar(sql12, CommandType.Text));
            dt1.Columns.Add("邮箱", typeof(string));
            dt1.Columns.Add("生产进度负责人", typeof(string));
            dt1.Columns.Add("负责人电话", typeof(string));
            dt1.Columns.Add("采购员电话", typeof(string));
            dt1.Columns.Add("交货日期", typeof(string));
            dt1.Columns.Add("合同编号", typeof(string));
            dt1.Columns.Add("签订时间", typeof(string));
            dt1.Columns.Add("签订乙方", typeof(string));
            dt1.Columns.Add("合计", typeof(string));
            dt1.Columns.Add("合计大写", typeof(string));
            dt1.Columns.Add("到货时间", typeof(string));
            dt1.Columns.Add("用户", typeof(string));
            dt1.Columns.Add("单位名称", typeof(string));
            dt1.Columns.Add("单位地址", typeof(string));
            dt1.Columns.Add("法定代表人", typeof(string));
            dt1.Columns.Add("委托代理人", typeof(string));
            dt1.Columns.Add("电话", typeof(string));
            dt1.Columns.Add("传真", typeof(string));
            dt1.Columns.Add("税务登记号", typeof(string));
            dt1.Columns.Add("开户银行", typeof(string));
            dt1.Columns.Add("帐号", typeof(string));
            dt1.Columns.Add("用户1", typeof(string));
            dt1.Columns.Add("传真1", typeof(string));
            dt1.Columns.Add("单位地址1", typeof(string));

            for (int i = 0; i < 200; i++)
            {
                dt1.Columns.Add("单位" + (i + 1), typeof(string));
                dt1.Columns.Add("ERP" + (i + 1), typeof(string));
                dt1.Columns.Add("产品名称" + (i + 1), typeof(string));
                dt1.Columns.Add("规格型号" + (i + 1), typeof(string));
                dt1.Columns.Add("数量" + (i + 1), typeof(string));
                dt1.Columns.Add("单价" + (i + 1), typeof(string));
                dt1.Columns.Add("总金额" + (i + 1), typeof(string));
                dt1.Columns.Add("备注" + (i + 1), typeof(string));
                dt1.Columns.Add("序号" + (i + 1), typeof(string));
                dt1.Columns.Add("类型" + (i + 1), typeof(string));
                dt1.Columns.Add("工令号" + (i + 1), typeof(string));

            }
            DataRow dr1 = dt1.NewRow();
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                if (Convert.ToString(dt2.Rows[i]["编码"]) == null)
                {
                    dr1["ERP" + (i + 1)] = "";
                }
                if (Convert.ToString(dt2.Rows[i]["编码"]) != null)
                {
                    dr1["ERP" + (i + 1)] = Convert.ToString(dt2.Rows[i]["编码"]);
                }
                if (Convert.ToString(dt2.Rows[i]["名称"]) == null)
                {
                    dr1["产品名称" + (i + 1)] = "";
                }
                if (Convert.ToString(dt2.Rows[i]["名称"]) != null)
                {
                    dr1["产品名称" + (i + 1)] = Convert.ToString(dt2.Rows[i]["名称"]);
                    dr1["序号" + (i + 1)] = i + 1;
                }

                if (Convert.ToString(dt2.Rows[i]["型号"]) == null)
                {
                    dr1["规格型号" + (i + 1)] = "";
                }

                if (Convert.ToString(dt2.Rows[i]["型号"]) != null)
                {
                    dr1["规格型号" + (i + 1)] = Convert.ToString(dt2.Rows[i]["型号"]);
                }




                if (Convert.ToString(dt2.Rows[i]["类型"]) == null)
                {
                    dr1["类型" + (i + 1)] = "";
                }

                if (Convert.ToString(dt2.Rows[i]["类型"]) != null)
                {
                    dr1["类型" + (i + 1)] = Convert.ToString(dt2.Rows[i]["类型"]);
                }


                if (Convert.ToString(dt2.Rows[i]["实际采购数量"]) == null)
                {
                    dr1["数量" + (i + 1)] = "";
                }

                if (Convert.ToString(dt2.Rows[i]["实际采购数量"]) != null)
                {
                    dr1["数量" + (i + 1)] = Convert.ToString(dt2.Rows[i]["实际采购数量"]);
                }


                if (Convert.ToString(dt2.Rows[i]["采购单价"]) == null)
                {
                    dr1["单价" + (i + 1)] = "";
                }

                if (Convert.ToString(dt2.Rows[i]["采购单价"]) != null)
                {
                    dr1["单价" + (i + 1)] = Convert.ToString(dt2.Rows[i]["采购单价"]);
                }

                if (Convert.ToString(dt2.Rows[i]["单位"]) == null)
                {
                    dr1["单位" + (i + 1)] = "";
                }

                if (Convert.ToString(dt2.Rows[i]["单位"]) != null)
                {
                    dr1["单位" + (i + 1)] = Convert.ToString(dt2.Rows[i]["单位"]);
                }

                if (Convert.ToString(dt2.Rows[i]["总价预留"]) == null)
                {
                    dr1["总金额" + (i + 1)] = "";
                }

                if (Convert.ToString(dt2.Rows[i]["总价预留"]) != null)

                {
                    if (Convert.ToString(dt2.Rows[i]["采购单价"]) != null)
                    {
                        double shuliang = Convert.ToDouble(dt2.Rows[i]["实际采购数量"]);
                        double danjia = Convert.ToDouble(dt2.Rows[i]["采购单价"]);
                        decimal zuizhong = decimal.Round(decimal.Parse((shuliang * danjia).ToString()), 2);
                        dr1["总金额" + (i + 1)] = zuizhong;
                        reslut = reslut + zuizhong;
                    }
                }

                if (Convert.ToString(dt2.Rows[i]["工作令号"]) == null)
                {
                    dr1["备注" + (i + 1)] = "";
                }

                if (Convert.ToString(dt2.Rows[i]["工作令号"]) != null)
                {
                    dr1["备注" + (i + 1)] = (Convert.ToString(dt2.Rows[i]["工作令号"]));
                }

                if (Convert.ToString(dt2.Rows[i]["备注"]) == null)
                {
                    dr1["工令号" + (i + 1)] = "";
                }
                if (Convert.ToString(dt2.Rows[i]["备注"]) != null)
                {
                    dr1["工令号" + (i + 1)] = (Convert.ToString(dt2.Rows[i]["备注"]));
                }



            }
            string heji = Convert.ToString(reslut);
            dr1["邮箱"] = youxiang;
            dr1["合同编号"] = hetonghao;
            dr1["签订时间"] = qiandingshijian;
            dr1["签订乙方"] = qiandingyifang;
            dr1["合计"] = heji;
            dr1["合计大写"] = MoneyToChinese(heji);

            dr1["到货时间"] = daohuoshijian;
            dr1["用户"] = yonghu;
            dr1["单位名称"] = qiandingyifang;
            dr1["单位地址"] = danweidizhi;
            dr1["法定代表人"] = fadingdaibiaoren;
            dr1["委托代理人"] = weituodailiren;
            dr1["电话"] = dianhua;
            dr1["传真"] = chuanzhen;
            dr1["税务登记号"] = shuiwudengjihao;
            dr1["开户银行"] = kaihuyinhang;
            dr1["帐号"] = zhanghao;
            dr1["交货日期"] = jiaohuoriqi;
            dr1["用户1"] = yonghu;
            dr1["传真1"] = chuanzhen;
            dr1["单位地址1"] = danweidizhi;
            dr1["采购员电话"] = caigoudianhua;
            dr1["生产进度负责人"] = shengchangfuzeren;
            dr1["负责人电话"] = shengchangfuzerendianhua;

            dt1.Rows.Add(dr1);

            string tempFile = Application.StartupPath + "\\采购合同模板.doc";
            Document doc = new Document(tempFile);
            DocumentBuilder builder = new DocumentBuilder(doc);
            NodeCollection allTables = doc.GetChildNodes(NodeType.Table, true);

            Dictionary<string, string> dic = new Dictionary<string, string>();
            DataRow dr = dt1.Rows[0];


            dic.Add("邮箱", dr["邮箱"].ToString());
            dic.Add("生产进度负责人", dr["生产进度负责人"].ToString());
            dic.Add("负责人电话", dr["负责人电话"].ToString());
            dic.Add("合同编号", dr["合同编号"].ToString());
            dic.Add("签订时间", dr["签订时间"].ToString());
            dic.Add("签订乙方", dr["签订乙方"].ToString());
            dic.Add("合计", dr["合计"].ToString());
            dic.Add("到货时间", dr["到货时间"].ToString() + "前");
            dic.Add("合计大写", dr["合计大写"].ToString());
            dic.Add("用户", dr["用户"].ToString());
            dic.Add("单位名称", dr["单位名称"].ToString());
            dic.Add("单位地址", dr["单位地址"].ToString());
            dic.Add("法定代表人", dr["法定代表人"].ToString());
            dic.Add("委托代理人", dr["委托代理人"].ToString());
            dic.Add("电话", dr["电话"].ToString());
            dic.Add("传真", dr["传真"].ToString());
            dic.Add("税务登记号", dr["税务登记号"].ToString());
            dic.Add("开户银行", dr["开户银行"].ToString());
            dic.Add("帐号", dr["帐号"].ToString());
            dic.Add("用户1", dr["用户1"].ToString());
            dic.Add("传真1", dr["传真1"].ToString());
            dic.Add("单位地址1", dr["单位地址1"].ToString());
            dic.Add("采购员电话", dr["采购员电话"].ToString());



            for (int i = 0; i < 200; i++)
            {
                dic.Add("ERP" + (i + 1), dr["ERP" + (i + 1)].ToString());
                dic.Add("单位" + (i + 1), dr["单位" + (i + 1)].ToString());
                dic.Add("产品名称" + (i + 1), dr["产品名称" + (i + 1)].ToString());
                dic.Add("规格型号" + (i + 1), dr["规格型号" + (i + 1)].ToString());
                dic.Add("数量" + (i + 1), dr["数量" + (i + 1)].ToString());
                dic.Add("单价" + (i + 1), dr["单价" + (i + 1)].ToString());
                dic.Add("总金额" + (i + 1), dr["总金额" + (i + 1)].ToString());
                dic.Add("备注" + (i + 1), dr["备注" + (i + 1)].ToString());
                dic.Add("序号" + (i + 1), dr["序号" + (i + 1)].ToString());
                dic.Add("类型" + (i + 1), dr["类型" + (i + 1)].ToString());
                dic.Add("工令号" + (i + 1), dr["工令号" + (i + 1)].ToString());
            }
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
                string id = Convert.ToString(dt.Rows[i]["id"]);
                string gonglinghao = Convert.ToString(dt.Rows[i]["工作令号"]);
                string xiangmumingcheng = Convert.ToString(dt.Rows[i]["项目名称"]);
                string shebeimingcheng = Convert.ToString(dt.Rows[i]["设备名称"]);
                string bianma = Convert.ToString(dt.Rows[i]["编码"]);
                string mingcheng1 = Convert.ToString(dt.Rows[i]["名称"]);
                string xinghao1 = Convert.ToString(dt.Rows[i]["型号"]);
                string shuliang = "采购数量：" + Convert.ToString(dt.Rows[i]["实际采购数量"]);
                string gongyingshang = qiandingyifang;
                string hetonghao1 = hetonghao;
                string dataCode = id + "|" + bianma + "|" + gongyingshang + "|" + hetonghao1 + "|";
                string sql3 = "select 料单序号 from tb_caigouliaodan where id='" + id + "'";
                string liaodanxuhao = Convert.ToString(SQLhelp.ExecuteScalar(sql3, CommandType.Text));
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
                g.DrawString(hetonghao1, font, brush, image.Width, 125);
                g.DrawString(shuliang, font, brush, image.Width, 150);
                g.DrawString("序列号:" + liaodanxuhao, font, brush, image.Width, 175);
                image = newImg;
                string erweima = "二维码" + i;
                builder.MoveToBookmark(erweima);
                builder.InsertImage(image, RelativeHorizontalPosition.Margin, 1, RelativeVerticalPosition.Margin, 1, 180, 117, WrapType.Square);

            }

            foreach (var key in dic.Keys)
            {
                builder.MoveToBookmark(key);
                builder.Write(dic[key]);
            }
            Random suiji = new Random();
            int n = suiji.Next(0, 1000);

            string mingcheng = yonghu + DateTime.Now.ToString("yyyy-MM-dd") + "采购合同模板" + n + ".doc";
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
