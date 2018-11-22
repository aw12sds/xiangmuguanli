using Aspose.Words;
using Aspose.Words.Drawing;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThoughtWorks.QRCode.Codec;
using 项目管理系统.仓库;
using 项目管理系统.生产部;
using 项目管理系统.质监部;

namespace 项目管理系统.检验
{
    public partial class Frtuzhichaxun : Form
    {
        public Frtuzhichaxun()
        {
            InitializeComponent();
        }
        public string yonghu;
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
        
        public DataTable dt;
        private void buttonItem1_Click(object sender, EventArgs e)
        {
            if (txtgonglinghao.Text.Trim() == "")
            {

                MessageBox.Show("请输入工令号！");
                return;

            }
            string sql = "select id,工作令号,项目名称,设备名称,设备负责人,数量,设备预计结束时间,时间,生产部确认 from tb_jishubumen where 工作令号 like '%" + txtgonglinghao.Text.Trim() + "%' ";

            dataGridViewX1.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            if (txtxiangmu.Text.Trim() == "")
            {

                MessageBox.Show("请输入项目名称！");
                return;

            }
            string sql = "select id,工作令号,项目名称,设备名称,设备负责人,数量,设备预计结束时间,时间,生产部确认 from tb_jishubumen where 项目名称 like '%" + txtxiangmu.Text.Trim() + "%' ";

            dataGridViewX1.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            if (txtshebei.Text.Trim() == "")
            {

                MessageBox.Show("请输入设备名称！");
                return;

            }
            string sql = "select id,工作令号,项目名称,设备名称,设备负责人,数量,设备预计结束时间,时间,生产部确认 from tb_jishubumen where 设备名称 like '%" + txtshebei.Text.Trim() + "%' ";

            dataGridViewX1.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
        }

        private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string gongzuolinghao = dataGridViewX1.CurrentRow.Cells["工作令号1"].Value.ToString();
            string xiangmumingcheng = dataGridViewX1.CurrentRow.Cells["项目名称1"].Value.ToString();
            string shijian = dataGridViewX1.CurrentRow.Cells["时间1"].Value.ToString();
            Frzhijianbuliaodan form1 = new Frzhijianbuliaodan();
            form1.gongzuolinghao = gongzuolinghao;
            form1.xiangmumingcheng = xiangmumingcheng;
            form1.shijian = shijian;
            form1.ShowDialog();
        }

        private void dataGridViewX2_CellPainting_1(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            if (txtxinghao.Text.Trim() == "")
            {

                MessageBox.Show("请输入型号！");
                return;

            }

            string sql1 = "select id,工作令号,项目名称,设备名称,编码,型号,名称,单位,数量,类型,要求到货日期,备注,制造类型,当前状态,实际采购数量,合同号,供方名称,附件名称,附件类型,实际到货数量,出库数量,库存数量,申购人 from  tb_caigouliaodan  where 型号 like '%" + txtxinghao.Text.Trim() + "%' ";
            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridControl2.DataSource = dt;
            gridView2.Columns["id"].Visible = false;
            gridView2.Columns["附件类型"].Visible = false;


        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            if (txtmingcheng.Text.Trim() == "")
            {

                MessageBox.Show("请输入名称！");
                return;

            }
            string sql1 = "select id,工作令号,项目名称,设备名称,编码,型号,名称,单位,数量,类型,要求到货日期,备注,制造类型,当前状态,实际采购数量,合同号,供方名称,附件名称,附件类型,实际到货数量,出库数量,库存数量,申购人 from  tb_caigouliaodan  where 名称 like '%" + txtmingcheng.Text.Trim() + "%' ";
            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridControl2.DataSource = dt;
            gridView2.Columns["id"].Visible = false;
            gridView2.Columns["附件类型"].Visible = false;


        }

    
        private void 生成二维码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
            string id = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id"));
            string gonglinghao = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "工作令号"));
            string xiangmumingcheng = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "项目名称"));
            string shebeimingcheng = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "设备名称"));
            string bianma = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "编码"));
            string mingcheng1 = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "名称"));
            string xinghao1 =Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "型号"));
            string gongyingshang = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "供方名称"));
            string hetonghao = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "合同号"));
            string shuliang = "采购数量：" + Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "实际采购数量"));
            string dataCode = id + "|" + mingcheng1 + "|" + xinghao1 + "|";
            Image image;
            string data = dataCode;
            image = qrCodeEncoder.Encode(data, Encoding.UTF8);
            Bitmap newImg = new Bitmap(image.Width + 200, image.Height);


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

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Image files (*.jpg)|*.jpg";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Title = "导出文件保存路径";
            saveFileDialog.FileName = null;
            saveFileDialog.ShowDialog();
            string strPath = saveFileDialog.FileName;
            string pictureName = dataCode;

            image.Save(@strPath);
            image.Dispose();
            MessageBox.Show("附件另存成功！", "注意", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            string sql1 = "select id,工作令号,项目名称,设备名称,编码,型号,名称,单位,数量,类型,备注,供方名称,合同号,实际采购数量,当前状态,实际到货数量,出库数量,库存数量,采购单价,申购人 from  tb_caigouliaodan  where 合同号='" + txthetonghao + "'";
            gridControl8.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
        }
        
        private void 生成二维码ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string tempFile = Application.StartupPath + "\\二维码文件.doc";
            Document doc = new Document(tempFile);
            DocumentBuilder builder = new DocumentBuilder(doc);
            NodeCollection allTables = doc.GetChildNodes(NodeType.Table, true);

            Dictionary<string, string> dic = new Dictionary<string, string>();

            for (int i = 0; i < gridView8.RowCount; i++)
            {
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
                string id = Convert.ToString(gridView8.GetRowCellValue(i, "id"));
                string gonglinghao = Convert.ToString(gridView8.GetRowCellValue(i, "工作令号"));
                string xiangmumingcheng = Convert.ToString(gridView8.GetRowCellValue(i, "项目名称"));
                string shebeimingcheng = Convert.ToString(gridView8.GetRowCellValue(i, "设备名称"));
                string bianma = Convert.ToString(gridView8.GetRowCellValue(i, "编码"));
                string mingcheng1 = Convert.ToString(gridView8.GetRowCellValue(i, "名称"));
                string xinghao1 = Convert.ToString(gridView8.GetRowCellValue(i, "型号"));
                string gongyingshang = Convert.ToString(gridView8.GetRowCellValue(i, "供方名称"));
                string hetonghao = Convert.ToString(gridView8.GetRowCellValue(i, "合同号"));
                string shuliang = "采购数量：" + Convert.ToString(gridView8.GetRowCellValue(i, "实际采购数量"));
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

        private void buttonItem7_Click(object sender, EventArgs e)
        {
            if (comboBoxItem1.Text.Trim() == "张敏明")
            {
                string sql = "select id,工作令号,项目名称,设备名称,型号,名称,单位,类型,要求到货日期,实际采购数量,供方名称,合同号,当前状态,附件名称,附件类型,生成合同时间,合同预计时间  from tb_caigouliaodan  where 合同号 like '%zmm%'  and 制造类型='外协零部件' ";
                dt = SQLhelp.GetDataTable(sql, CommandType.Text);
                dataGridViewX4.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
            }

            if (comboBoxItem1.Text.Trim() == "于嘉嘉")
            {
                string sql = "select id,工作令号,项目名称,设备名称,型号,名称,单位,类型,要求到货日期,实际采购数量,供方名称,合同号,当前状态,附件名称,附件类型,生成合同时间,合同预计时间  from tb_caigouliaodan   where 合同号 like '%yjj%'  and 制造类型='外协零部件' ";
                dt = SQLhelp.GetDataTable(sql, CommandType.Text);
                dataGridViewX4.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
            }
            if (comboBoxItem1.Text.Trim() == "田星星")
            {
                string sql = "select id,工作令号,项目名称,设备名称,型号,名称,单位,类型,要求到货日期,实际采购数量,供方名称,合同号,当前状态,附件名称,附件类型,生成合同时间,合同预计时间  from tb_caigouliaodan  where  合同号 like '%txx%'  and 制造类型='外协零部件' ";
                dt = SQLhelp.GetDataTable(sql, CommandType.Text);
                dataGridViewX4.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
            }
            if (comboBoxItem1.Text.Trim() == "唐亚男")
            {
                string sql = "select id,工作令号,项目名称,设备名称,型号,名称,单位,类型,要求到货日期,实际采购数量,供方名称,合同号,当前状态,附件名称,附件类型,生成合同时间,合同预计时间  from tb_caigouliaodan  where  合同号 like '%tyn%'  and 制造类型='外协零部件' ";
                dt = SQLhelp.GetDataTable(sql, CommandType.Text);
                dataGridViewX4.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
            }
            if (comboBoxItem1.Text.Trim() == "钱飞")
            {
                string sql = "select id,工作令号,项目名称,设备名称,型号,名称,单位,类型,要求到货日期,实际采购数量,供方名称,合同号,当前状态,附件名称,附件类型,生成合同时间,合同预计时间  from tb_caigouliaodan  where  合同号 like '%qf%'  and 制造类型='外协零部件' ";
                dt = SQLhelp.GetDataTable(sql, CommandType.Text);
                dataGridViewX4.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
            }
            if (comboBoxItem1.Text.Trim() == "丁雪松")
            {
                string sql = "select id,工作令号,项目名称,设备名称,型号,名称,单位,类型,要求到货日期,实际采购数量,供方名称,合同号,当前状态,附件名称,附件类型,生成合同时间,合同预计时间  from tb_caigouliaodan  where  合同号 like '%dxs%'  and 制造类型='外协零部件' ";
                dt = SQLhelp.GetDataTable(sql, CommandType.Text);
                dataGridViewX4.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
            }
            if (comboBoxItem1.Text.Trim() == "何然")
            {
                string sql = "select id,工作令号,项目名称,设备名称,型号,名称,单位,类型,要求到货日期,实际采购数量,供方名称,合同号,当前状态,附件名称,附件类型,生成合同时间,合同预计时间  from tb_caigouliaodan  where  合同号 like '%hr%'  and 制造类型='外协零部件' ";
                dt = SQLhelp.GetDataTable(sql, CommandType.Text);
                dataGridViewX4.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
            }



        }

        private void dataGridViewX4_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dataGridViewX4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int CIndex = e.ColumnIndex;
            //按钮所在列为第五列，列下标从0开始的  
            if (CIndex == 14)
            {
                if (dataGridViewX4.CurrentRow.Cells["id4"].Value == null)
                {

                    MessageBox.Show("没有附件！");
                    return;
                }
                if (dataGridViewX4.CurrentRow.Cells["id4"].Value != null)
                {
                    string id = dataGridViewX4.CurrentRow.Cells["id4"].Value.ToString();

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
        }

        private void dataGridViewX4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dataGridViewX4.CurrentRow.Cells["id4"].Value.ToString();
            int CIndex = e.ColumnIndex;
            //按钮所在列为第五列，列下标从0开始的  
            if (CIndex == 2)
            {
                DataTable newdt = new DataTable();
                string gongzuolinghao = dataGridViewX4.CurrentRow.Cells["工作令号4"].Value.ToString();

                DataRow[] rows = dt.Select("工作令号= '" + gongzuolinghao + "'");
                newdt = dt.Clone();
                foreach (DataRow row in rows)  // 将查询的结果添加到dt中； 
                {
                    newdt.Rows.Add(row.ItemArray);
                }

                Frshaixuanliaodan1 form1 = new Frshaixuanliaodan1();
                form1.dt = newdt;
                form1.ShowDialog();

            }

            if (CIndex == 2)
            {
                DataTable newdt = new DataTable();
                string gongzuolinghao = dataGridViewX4.CurrentRow.Cells["工作令号4"].Value.ToString();

                DataRow[] rows = dt.Select("工作令号= '" + gongzuolinghao + "'");
                newdt = dt.Clone();
                foreach (DataRow row in rows)  // 将查询的结果添加到dt中； 
                {
                    newdt.Rows.Add(row.ItemArray);
                }

                Frshaixuanliaodan1 form1 = new Frshaixuanliaodan1();
                form1.dt = newdt;
                form1.ShowDialog();

            }

            if (CIndex == 11)
            {
                DataTable newdt = new DataTable();
                string gongzuolinghao = dataGridViewX4.CurrentRow.Cells["供方名称4"].Value.ToString();

                DataRow[] rows = dt.Select("供方名称= '" + gongzuolinghao + "'");
                newdt = dt.Clone();
                foreach (DataRow row in rows)  // 将查询的结果添加到dt中； 
                {
                    newdt.Rows.Add(row.ItemArray);
                }

                Frshaixuanliaodan1 form1 = new Frshaixuanliaodan1();
                form1.dt = newdt;
                form1.ShowDialog();

            }
        }

        private void 扫码入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "仓库")
            {
                MessageBox.Show("非仓库人员无法入库！");
                return;


            }

            Frsaomadengji form1 = new Frsaomadengji();
            form1.yonghu = yonghu;
            form1.leixing = "合同";
            form1.ShowDialog();
            if (form1.DialogResult == DialogResult.OK)
            {
                string sql1 = "select id,工作令号,项目名称,设备名称, 序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,申购人,收到料单日期,供方名称,合同号,实际采购数量,采购单价,当前状态,附件名称,附件类型,实际到货数量,出库数量,库存数量 from  tb_caigouliaodan  where 合同号='" + txthetonghao + "'";

               gridControl8.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);


            }
        }
        
        private void buttonItem8_Click(object sender, EventArgs e)
        {
            string mingxi = "";
            double zongjia = 0;
            string sql1 = "select id,接单编号,客户名称,部门,工件名称,加工内容,计量单位,机修件数量,接单日期,预交时间,联系人,责任人,加工单位备注,当前状态,生产部确认,生产部确认时间,供方名称,合同号 from  tb_caigouliaodan  where  机修件数量 is not null and 接单编号 like '%" + txtjixiu.Text.Trim() + "%' ";
            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            //dt.Columns.Add("价格");
            dt.Columns.Add("明细");
            dt.Columns.Add("材料1");
            //dt.Columns.Add("重量1");
            dt.Columns.Add("材料2");
            //dt.Columns.Add("重量2");
            dt.Columns.Add("材料3");
            //dt.Columns.Add("重量3");
            dt.Columns.Add("材料4");
            //dt.Columns.Add("重量4");


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                mingxi = "";
                zongjia = 0;
                string sql = "  Select 价格,机修件数量,工序内容,材料,重量 from db_gongxu111 where  接单编号='" + dt.Rows[i]["接单编号"] + "'";
                DataTable jiage = sqlhelp1.GetDataTable(sql, CommandType.Text);
                for (int j = 0; j < jiage.Rows.Count; j++)
                {
                    int shuliang = Convert.ToInt32(jiage.Rows[j]["机修件数量"]);
                    string jiage1 = Convert.ToString(jiage.Rows[j]["价格"]);
                    if (jiage1 != "")
                    {
                        zongjia += Convert.ToDouble(jiage.Rows[j]["价格"]) * (shuliang);

                    }
                    mingxi += jiage.Rows[j]["工序内容"].ToString() + "|";
                    if (j < 4)
                    {
                        dt.Rows[i]["材料" + (j + 1)] = jiage.Rows[j]["材料"];
                        //dt.Rows[i]["重量" + (j + 1)] = jiage.Rows[j]["重量"];
                    }
                }
                //dt.Rows[i]["价格"] = zongjia;
                dt.Rows[i]["明细"] = mingxi;

            }

            dataGridViewX5.DataSource = dt;
        }
        
        private void 手动入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "仓库")
            {
                MessageBox.Show("非仓库人员无法入库！");
                return;


            }
            Frshoudngruku form1 = new Frshoudngruku();
            form1.id = Convert.ToString(this.gridView8.GetRowCellValue(this.gridView8.FocusedRowHandle, "id"));
            form1.yonghu = yonghu;
            form1.ShowDialog();
            if (form1.DialogResult == DialogResult.OK)
            {
                string sql1 = "select id,工作令号,项目名称,设备名称, 序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,申购人,收到料单日期,供方名称,合同号,实际采购数量,采购单价,当前状态,附件名称,附件类型,实际到货数量,出库数量,库存数量 from  tb_caigouliaodan  where 合同号='" + txthetonghao + "'";

               gridControl8.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);


            }
        }
        
        private void 手动退库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "仓库")
            {
                MessageBox.Show("非仓库人员无法入库！");
                return;
            }
            Frshoudongtuiku form1 = new Frshoudongtuiku();
            form1.id = Convert.ToString(this.gridView8.GetRowCellValue(this.gridView8.FocusedRowHandle, "id"));
            form1.yonghu = yonghu;
            form1.ShowDialog();
            if (form1.DialogResult == DialogResult.OK)
            {
                string sql1 = "select id,工作令号,项目名称,设备名称, 序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,申购人,收到料单日期,供方名称,合同号,实际采购数量,采购单价,当前状态,附件名称,附件类型,实际到货数量,出库数量,库存数量 from  tb_caigouliaodan  where 合同号='" + txthetonghao + "'";

                gridControl8.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);        
            }

        }

        private void 手动退货ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "仓库")
            {
                MessageBox.Show("非仓库人员无法入库！");
                return;
            }
            Frshoudongtuihuo form1 = new Frshoudongtuihuo();
            form1.id = Convert.ToString(this.gridView8.GetRowCellValue(this.gridView8.FocusedRowHandle, "id"));
            form1.yonghu = yonghu;
            form1.ShowDialog();
            if (form1.DialogResult == DialogResult.OK)
            {
                string sql1 = "select id,工作令号,项目名称,设备名称, 序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,申购人,收到料单日期,供方名称,合同号,实际采购数量,采购单价,当前状态,附件名称,附件类型,实际到货数量,出库数量,库存数量 from  tb_caigouliaodan  where 合同号='" + txthetonghao + "'";
               gridControl8.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
            }
        }
        
        private void buttonItem13_Click(object sender, EventArgs e)
        {
            if (txtERP.Text.Trim() == "")
            {

                MessageBox.Show("请输入ERP！");
                return;

            }
            string sql1 = "select id,工作令号,项目名称,设备名称,编码,型号,名称,单位,数量,类型,要求到货日期,备注,制造类型,当前状态,实际采购数量,合同号,供方名称,附件名称,附件类型,实际到货数量,出库数量,库存数量,申购人 from  tb_caigouliaodan  where 编码 like '%" + txtERP.Text.Trim() + "%' ";
            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridControl2.DataSource = dt;
            gridView2.Columns["id"].Visible = false;
            gridView2.Columns["附件类型"].Visible = false;
        }

        private void 一键入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "仓库")
            {
                MessageBox.Show("非仓库人员无法入库！");
                return;
            }
            //if (txtkuweihao1.Text == "")
            //{
            //    MessageBox.Show("请区分，用新（老）标注");
            //    return;
            //}
            if (txtkuweihao.Text.Trim() == "")
            {
                MessageBox.Show("请设置库位号");
                return;
            }           
            int[] a = gridView8.GetSelectedRows();

            foreach (int i in a)
            {
                string bianm = Convert.ToString(gridView8.GetRowCellValue(i, "编码"));
                if (bianm.Trim() == "")
                {
                    MessageBox.Show("其中有的没有ERP编码，无法入库！");
                    return;
                }
                if (bianm.Length < 14)
                {
                    MessageBox.Show("其中有老编码，无法入库！");
                    return;
                }
                string caigou = Convert.ToString(gridView8.GetRowCellValue(i, "实际采购数量"));
                if (caigou == "")
                {
                    MessageBox.Show("没有数量！");
                    return;
                }

                string id = Convert.ToString(gridView8.GetRowCellValue(i, "id"));
                string sql22 = "select 实际到货数量 from tb_caigouliaodan where id='" + id + "'";
                string sql11 = SQLhelp.ExecuteScalar(sql22, CommandType.Text).ToString();
                if(sql11!="")
                {
                    MessageBox.Show("页面数据已更新，请刷新后再入库！");
                    return;
                }


            }
                foreach (int i in a)
            {
                string id = Convert.ToString(gridView8.GetRowCellValue(i, "id"));
                string ruku = Convert.ToString(gridView8.GetRowCellValue(i, "实际到货数量"));
                string caigou = Convert.ToString(gridView8.GetRowCellValue(i, "实际采购数量"));
                if (ruku == "")
                {                
                        string sql12 = "update tb_caigouliaodan set 实际到货数量='" + caigou + "',库位号='" + txtkuweihao.Text + "',仓库确认=1,仓库确认时间='" + DateTime.Now + "',当前状态='9已到货',库存数量='" + caigou + "',到货时间='" + DateTime.Now + "',区分='新' where id='" + id + "'";
                        SQLhelp.GetDataTable(sql12, CommandType.Text);                 
                    string sql123 = " select 工作令号,项目名称,设备名称,编码,型号,名称,制造类型,实际采购数量,单位,合同号,采购单价,供方名称 from tb_caigouliaodan where id='" + id + "'";
                    DataTable dt = SQLhelp.GetDataTable(sql123, CommandType.Text);
                    string danjia = dt.Rows[0]["采购单价"].ToString();
                    if (danjia == "")
                    {
                        danjia = "0";
                    }
                    double zongjia = Convert.ToDouble(danjia) * Convert.ToDouble(dt.Rows[0]["实际采购数量"].ToString());
                    string sqlll = "select 料单类型 from tb_caigouliaodan where id='" + id + "'";
                    string leixing = SQLhelp.ExecuteScalar(sqlll, CommandType.Text).ToString();
                    string sql12345 = "insert into tb_ruku (工作令号,项目名称,设备名称,编码,型号,名称,制造类型,实际采购数量,入库数量,入库时间,入库人,定位,单位,库位号,合同号,采购单价,总价,供方名称,料单类型,区分) values ('" + dt.Rows[0]["工作令号"].ToString() + "','" + dt.Rows[0]["项目名称"].ToString() + "','" + dt.Rows[0]["设备名称"].ToString() + "','" + dt.Rows[0]["编码"].ToString() + "','" + dt.Rows[0]["型号"].ToString() + "','" + dt.Rows[0]["名称"].ToString() + "','" + dt.Rows[0]["制造类型"].ToString() + "','" + dt.Rows[0]["实际采购数量"].ToString() + "','" + dt.Rows[0]["实际采购数量"].ToString() + "','" + DateTime.Now + "','" + yonghu + "','" + id + "','" + dt.Rows[0]["单位"].ToString() + "','" + txtkuweihao.Text + "','" + dt.Rows[0]["合同号"].ToString() + "','" + danjia + "','" + zongjia + "','" + dt.Rows[0]["供方名称"].ToString() + "','" + leixing + "','新')";
                    SQLhelp.ExecuteScalar(sql12345, CommandType.Text);
                }
            }
            MessageBox.Show("入库成功！");
            string sql1 = "select id,工作令号,项目名称,设备名称,编码,型号,名称,单位,数量,类型,备注,供方名称,合同号,实际采购数量,当前状态,实际到货数量,出库数量,库存数量 from  tb_caigouliaodan  where 合同号='" + txthetonghao + "'";
            gridControl8.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
        }
        
        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
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

  
        private void buttonItem15_Click(object sender, EventArgs e)
        {
            if (txtgongyingshang.Text.Trim() == "")
            {

                MessageBox.Show("请输入ERP！");
                return;

            }
            string sql1 = "select id,工作令号,项目名称,设备名称,编码,型号,名称,单位,数量,类型,要求到货日期,备注,制造类型,当前状态,实际采购数量,合同号,供方名称,附件名称,附件类型,实际到货数量,出库数量,库存数量,申购人 from  tb_caigouliaodan  where 供方名称 like '%" + txtgongyingshang.Text.Trim() + "%' ";
            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridControl2.DataSource = dt;
            gridView2.Columns["id"].Visible = false;
            gridView2.Columns["附件类型"].Visible = false;
        }

        private void gridView8_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
    }
}
