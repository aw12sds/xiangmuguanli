using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Spreadsheet;

namespace 项目管理系统.个人管理
{
    public partial class Frliulanexcel : DevExpress.XtraEditors.XtraForm
    {
        public Frliulanexcel()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = @"EXCEL文件|*.xls;*.xlsx";


            if (dialog.ShowDialog() == DialogResult.OK)
            {
                IWorkbook workbook = spreadsheetControl1.Document;
                workbook.LoadDocument(dialog.FileName);
            }
        }

        private void Frliulanexcel_Load(object sender, EventArgs e)
        {

        }
    }
}