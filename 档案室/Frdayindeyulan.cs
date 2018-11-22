using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraPrinting;
using System.Data.SqlClient;
using System.IO;
using DevComponents.DotNetBar;

namespace 项目管理系统.档案室
{
    public partial class Frdayindeyulan : DevExpress.XtraEditors.XtraForm
    {
        public Frdayindeyulan()
        {
       
            InitializeComponent();
        }
        public DataTable dt;
        private void Frdayindeyulan_Load(object sender, EventArgs e)
        {
            gridControl4.DataSource = dt;
            gridView4.Columns["id"].Visible = false;
            gridView4.Columns["附件类型"].Visible = false;
            gridView4.Columns["附件名称"].Visible = false;
        }

        private void 打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            gridView4.OptionsPrint.AutoWidth = false;
            PrintPreview(this.gridControl4);




        }
      
        private void PrintPreview(DevExpress.XtraPrinting.IPrintable gridControlPrint)
        {
            DevExpress.XtraPrintingLinks.CompositeLink compositeLink = new DevExpress.XtraPrintingLinks.CompositeLink();
            DevExpress.XtraPrinting.PrintingSystem ps = new DevExpress.XtraPrinting.PrintingSystem();

            compositeLink.PrintingSystem = ps;
            compositeLink.Landscape = true;
            compositeLink.PaperKind = System.Drawing.Printing.PaperKind.A4;
            DevExpress.XtraPrinting.PrintableComponentLink link = new DevExpress.XtraPrinting.PrintableComponentLink(ps);

            ps.PageSettings.Landscape = true;
            link.Component = gridControlPrint;
            compositeLink.Links.Add(link);

            link.CreateDocument();  //建立文档
            PageHeaderFooter phf = link.PageHeaderFooter as PageHeaderFooter;
            phf.Footer.LineAlignment = BrickAlignment.Center;
            phf.Header.Content.Clear();
            string headText = "页眉内容信息";
            phf.Header.Content.Add(headText);
            //设置页眉字体
            phf.Header.Font = new System.Drawing.Font("宋体", 12, System.Drawing.FontStyle.Regular);
            ps.Links.Add(link);


            ps.PreviewFormEx.Show();//进行预览  

        }

        private void 导出所有附件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog lujingg = new FolderBrowserDialog();
            if (lujingg.ShowDialog() == DialogResult.OK)
            {
                string xuanzelujing = lujingg.SelectedPath;
                for (int i = 0; i < gridView4.RowCount; i++)
                {

                    string mingcheng = Convert.ToString(gridView4.GetRowCellValue(i, "附件名称"));
                    string id = Convert.ToString(gridView4.GetRowCellValue(i, "id"));
                    if (mingcheng != "")
                    {
                        string leixing = Convert.ToString(gridView4.GetRowCellValue(i, "附件类型"));
                        byte[] mypdffile = null;
                        string sql = "Select 附件 From tb_caigouliaodan Where id='" + id + "'";
                        mypdffile = SQLhelp.duqu(sql, CommandType.Text);
                        string bbbb = mingcheng.Replace("?", "1");
                        string lujing = xuanzelujing + "\\" + bbbb + "." + leixing;
                        FileStream fs = new FileStream(lujing, FileMode.Create);
                        fs.Write(mypdffile, 0, mypdffile.Length);
                        fs.Flush();
                        fs.Close();                      
                    }
                }
                MessageBox.Show("下载成功");//显示异常信息
            }
        }
    }
}