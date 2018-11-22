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

namespace 项目管理系统.检验
{
    public partial class Frzhijianbuliaodan : Office2007Form
    {
        public Frzhijianbuliaodan()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }

        public string gongzuolinghao;
        public string xiangmumingcheng;
        public string shijian;


        private void Frzhijianbuliaodan_Load(object sender, EventArgs e)
        {
            string sql1 = "select 工作令号,项目名称,设备名称,id,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,当前状态,实际采购数量,合同号,供方名称,附件名称,附件类型 from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "'";
            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            dataGridViewX2.DataSource = dt;

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

        private void dataGridViewX2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int CIndex = e.ColumnIndex;
            //按钮所在列为第五列，列下标从0开始的  
            if (CIndex == 20)
            {
                if (dataGridViewX2.CurrentRow.Cells["id"].Value == null)
                {

                    MessageBox.Show("没有附件！");
                    return;
                }
                if (dataGridViewX2.CurrentRow.Cells["id"].Value != null)
                {
                    string id = dataGridViewX2.CurrentRow.Cells["id"].Value.ToString();

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

        private void 导出所有附件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog lujingg = new FolderBrowserDialog();
            if (lujingg.ShowDialog() == DialogResult.OK)
            {
                string xuanzelujing = lujingg.SelectedPath;
                for (int i = 0; i < dataGridViewX2.Rows.Count; i++)
                {

                    string mingcheng = Convert.ToString(dataGridViewX2.Rows[i].Cells["附件名称"].Value.ToString());
                    string id = Convert.ToString(dataGridViewX2.Rows[i].Cells["id"].Value.ToString());
                    if (mingcheng != "")
                    {

                        string leixing = dataGridViewX2.Rows[i].Cells["附件类型"].Value.ToString();

                        try
                        {
                            byte[] mypdffile = null;
                            string ConStr = "Data Source=10.15.1.252;Initial Catalog=db_xiangmuguanli;user id=sa;password=zttZTT123";

                            SqlConnection con = new SqlConnection(ConStr);
                            SqlCommand cmd = new SqlCommand("", con);
                            cmd.CommandText = "Select 附件 From tb_caigouliaodan Where id='" + id + "'";
                            con.Open();

                            SqlDataReader dr = cmd.ExecuteReader();
                            while (dr.Read())
                            {
                                mypdffile = (byte[])dr.GetValue(0);
                                string bbbb = mingcheng.Replace("?", "1");
                                string lujing = xuanzelujing + "\\" + bbbb + "." + leixing;
                                FileStream fs = new FileStream(lujing, FileMode.Create);
                                fs.Write(mypdffile, 0, mypdffile.Length);
                                fs.Flush();
                                fs.Close();

                            }
                            con.Close();
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

        private void 制作该行二维码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tempFile = Application.StartupPath + "\\二维码文件.doc";
            Document doc = new Document(tempFile);
            DocumentBuilder builder = new DocumentBuilder(doc);
            NodeCollection allTables = doc.GetChildNodes(NodeType.Table, true);

            Dictionary<string, string> dic = new Dictionary<string, string>();
            
            for (int i = 0; i < dataGridViewX2.Rows.Count; i++)
            {
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
                string id = Convert.ToString(dataGridViewX2.Rows[i].Cells["id"].Value.ToString());
                string gonglinghao = Convert.ToString(dataGridViewX2.Rows[i].Cells["工作令号"].Value.ToString());
                string xiangmumingcheng = Convert.ToString(dataGridViewX2.Rows[i].Cells["项目名称"].Value.ToString());
                string shebeimingcheng = Convert.ToString(dataGridViewX2.Rows[i].Cells["设备名称"].Value.ToString());
                string bianma = Convert.ToString(dataGridViewX2.Rows[i].Cells["编码"].Value.ToString());
                string mingcheng1 = Convert.ToString(dataGridViewX2.Rows[i].Cells["名称"].Value.ToString());
                string xinghao1 = Convert.ToString(dataGridViewX2.Rows[i].Cells["型号"].Value.ToString());
                string gongyingshang = Convert.ToString(dataGridViewX2.Rows[i].Cells["供方名称"].Value.ToString());
                string hetonghao = Convert.ToString(dataGridViewX2.Rows[i].Cells["合同号"].Value.ToString());

                string dataCode = id + "|" + bianma + "|" + gongyingshang + "|" + hetonghao + "|";
                Image image;
                string data = dataCode;
                image = qrCodeEncoder.Encode(data, Encoding.UTF8);


                System.Drawing.Bitmap newImg;
                newImg = new Bitmap(image.Width + 200, image.Height+15);

                Graphics g = Graphics.FromImage(newImg);
                g.Clear(Color.White);
                g.DrawImageUnscaled(image, 0, 0);
                System.Drawing.Font font = new System.Drawing.Font("黑体", 13, FontStyle.Bold);
                SolidBrush brush = new SolidBrush(Color.Black);
                g.DrawString(gonglinghao, font, brush, image.Width, 0);
                g.DrawString(bianma, font, brush, image.Width, 25);
                g.DrawString(mingcheng1, font, brush, image.Width, 50);
                g.DrawString(xinghao1, font, brush, image.Width, 75);
                g.DrawString(gongyingshang, font, brush, image.Width, 100);
                g.DrawString(hetonghao, font, brush, image.Width, 125);

                image = newImg;

                string erweima = "二维码" + i;

                builder.MoveToBookmark(erweima);
                builder.InsertImage(image, RelativeHorizontalPosition.Margin, 1, RelativeVerticalPosition.Margin, 1, 150, 114, WrapType.Square);


            }
            Random suiji = new Random();
            int n = suiji.Next(0, 1000);
            string mingcheng =  DateTime.Now.ToString("yyyy-MM-dd") + "二维码文件" + n + ".doc";
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
