using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace 项目管理系统.财务部
{
    public partial class Frrukuchaxun : Form
    {
        public Frrukuchaxun()
        {
            InitializeComponent();
        }
        double zongjia;
        string mingxi;
        private void buttonX1_Click(object sender, EventArgs e)
        {
           
        }
        
        private void gridView4_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }

        private void gridView4_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
            {

                Frgongyika form1 = new Frgongyika();
                form1.gongzuolinghao = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "工作令号"));
                form1.xiangmumingcheng = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "项目名称"));
                form1.shebeimingcheng = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "设备名称"));
                form1.xinghao = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "型号"));
            }
        }
        #region 查询
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            //获取时间
            string shijian = dateEdit1.Text.ToString();
            //string shijian = dateTimeInput1.Value.ToString("yyyy-MM-dd 00:00:000");
            DateTime a = dateEdit1.DateTime.AddDays(1);
            string shijian2 = a.ToString("yyyy-MM-dd 00:00:000");
            string sql1 = "select 工作令号,项目名称,设备名称,型号,名称,单位,生产部确认时间,实际采购数量 from  tb_caigouliaodan  where 生产部确认时间>= '" + shijian + "' and  生产部确认时间< '" + shijian2 + "' and  机修件数量 is null and 制造类型='自制零部件'";
            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            dt.Columns.Add("价格");
            dt.Columns.Add("明细");
            dt.Columns.Add("材料1");
            dt.Columns.Add("重量1");
            dt.Columns.Add("材料2");
            dt.Columns.Add("重量2");
            dt.Columns.Add("材料3");
            dt.Columns.Add("重量3");
            dt.Columns.Add("材料4");
            dt.Columns.Add("重量4");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                mingxi = "";
                zongjia = 0;
                string sql = "  Select 价格,数量,工序内容,材料,重量 from db_gongxu1 where  工作令号='" + dt.Rows[i]["工作令号"] + "' and  项目名称='" + dt.Rows[i]["项目名称"] + "'  and  设备名称='" + dt.Rows[i]["设备名称"] + "' and  图号='" + dt.Rows[i]["型号"] + "'";
                DataTable jiage = sqlhelp1.GetDataTable(sql, CommandType.Text);
                for (int j = 0; j < jiage.Rows.Count; j++)
                {
                    int shuliang = Convert.ToInt32(jiage.Rows[j]["数量"]);
                    string jiage1 = Convert.ToString(jiage.Rows[j]["价格"]);
                    if (jiage1 != "")
                    {
                        zongjia += Convert.ToDouble(jiage.Rows[j]["价格"]) * (shuliang);

                    }
                    mingxi += jiage.Rows[j]["工序内容"].ToString() + "|";
                    if (j < 4)
                    {
                        dt.Rows[i]["材料" + (j + 1)] = jiage.Rows[j]["材料"];
                        dt.Rows[i]["重量" + (j + 1)] = jiage.Rows[j]["重量"];
                    }
                }
                dt.Rows[i]["价格"] = zongjia;
                dt.Rows[i]["明细"] = mingxi;

            }
            gridControl4.DataSource = dt;
        }
        #endregion
        #region 导出EXCEL表
        private void simpleButton2_Click(object sender, EventArgs e)
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
        #endregion
    }
}
