using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.技术部
{
    public partial class FRliaodanbianji : DevExpress.XtraEditors.XtraForm
    {
        public FRliaodanbianji()
        {
           
            InitializeComponent();
        }
        public string gongzuolinghao;
        public string xiangmumingcheng;
        public string shijian;
        public string lujing;
        public string yonghu;
        
        private void FRliaodanbianji_Load(object sender, EventArgs e)
        {
            Reload();
        }
        public void Reload()
        {
            string sql1 = "select 工作令号,项目名称,设备名称,时间,id, 序号,编码,新编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,实际采购数量 from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "'";

            gridControl2.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridView2.Columns["id"].Visible = false;
            
        }


        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {



            Frxiugailiaodan form1 = new Frxiugailiaodan();
            form1.id = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id"));
            form1.yonghu = yonghu;
            form1.ShowDialog();
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
                gridControl2.ExportToXls(fileDialog.FileName);
                DevExpress.XtraEditors.XtraMessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
