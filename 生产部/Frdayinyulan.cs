using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.生产部
{
    public partial class Frdayinyulan : Office2007Form
    {
        public Frdayinyulan()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public DataTable gonggong1;
        private void Frdayinyulan_Load(object sender, EventArgs e)
        {
            
           gridControl4.DataSource = gonggong1;

        }

        private void 打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //PrintDGV.Print_DataGridView(this.dataGridViewX1);

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
            ps.PreviewFormEx.Show();//进行预览  

        }
    }
}
