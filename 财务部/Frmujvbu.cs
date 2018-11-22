using MySql.Data.MySqlClient;
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
    public partial class Frmujvbu : Form
    {
        public Frmujvbu()
        {
            InitializeComponent();
        }
        private void Frmujvbu_Load(object sender, EventArgs e)
        {
            
        }
        double zongjia;
        string mingxi;
        #region 查看 导出 OLD
        //private void buttonX1_Click(object sender, EventArgs e)
        //{
        //    string shijian = dateTimeInput1.Value.ToString("yyyy-MM-dd 00:00:000");
        //    DateTime a = dateRiqi.DateTime.AddDays(1);
        //    string shijian2 = a.ToString("yyyy-MM-dd 00:00:000");
        //    string sql1 = "select id,工作令号,项目名称,名称,型号,单位,实际采购数量 from  tb_caigouliaodan  where 模具部实际交货日期>= '" + shijian + "' and  模具部实际交货日期< '" + shijian2 + "'  and 料单类型='模具部'";
        //    DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
        //    dt.Columns.Add("价格");
        //    dt.Columns.Add("明细");
        //    dt.Columns.Add("材料1");
        //    dt.Columns.Add("重量1");
        //    dt.Columns.Add("材料2");
        //    dt.Columns.Add("重量2");
        //    dt.Columns.Add("材料3");
        //    dt.Columns.Add("重量3");
        //    dt.Columns.Add("材料4");
        //    dt.Columns.Add("重量4");
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        mingxi = "";
        //        zongjia = 0;
        //        string sql = "Select * from tb_gongxu_manage where  零件id in (select id from tb_mujubu_lingjian where 业务id = '" + dt.Rows[i]["id"].ToString() + "')";
        //        DataTable jiage = SQLhelp.GetDataTable(sql, CommandType.Text);
        //        for (int j = 0; j < jiage.Rows.Count; j++)
        //        {
        //            int shuliang = Convert.ToInt32(jiage.Rows[j]["加工数量"]);
        //            string jiage1 = Convert.ToString(jiage.Rows[j]["金额单价"]);
        //            if (jiage1 != "")
        //            {
        //                zongjia += Convert.ToDouble(jiage.Rows[j]["金额单价"]) * (shuliang);

        //            }
        //            mingxi += jiage.Rows[j]["工序内容"].ToString() + "|";
        //            if (j < 4)
        //            {
        //                dt.Rows[i]["材料" + (j + 1)] = jiage.Rows[j]["材料"];
        //                dt.Rows[i]["重量" + (j + 1)] = jiage.Rows[j]["重量"];
        //            }
        //        }
        //        dt.Rows[i]["价格"] = zongjia;
        //        dt.Rows[i]["明细"] = mingxi;

        //    }
        //    gridControl4.DataSource = dt;
        //    gridView4.Columns["id"].Visible = false;
        //}

        //private void buttonX2_Click(object sender, EventArgs e)
        //{
        //    SaveFileDialog fileDialog = new SaveFileDialog();
        //    fileDialog.Title = "导出Excel";
        //    fileDialog.Filter = "Excel文件(*.xls)|*.xls";
        //    DialogResult dialogResult = fileDialog.ShowDialog(this);
        //    if (dialogResult == DialogResult.OK)
        //    {
        //        DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
        //        gridControl4.ExportToXls(fileDialog.FileName);
        //        DevExpress.XtraEditors.XtraMessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

        #endregion
        #region 查看
        private void btnLook_Click(object sender, EventArgs e)
        {
            //string shijian = dateTimeInput1.Value.ToString("yyyy-MM-dd 00:00:000");
            string shijian = dateRiqi.Text;
            DateTime a = dateRiqi.DateTime.AddDays(1);
            string shijian2 = a.ToString("yyyy-MM-dd 00:00:000");
            string sql1 = "select id,工作令号,项目名称,名称,型号,单位,实际采购数量 from  tb_caigouliaodan  where 模具部实际交货日期>= '" + shijian + "' and  模具部实际交货日期< '" + shijian2 + "'  and 料单类型='模具部'";
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
                string sql = "Select * from tb_gongxu_manage where  零件id in (select id from tb_mujubu_lingjian where 业务id = '" + dt.Rows[i]["id"].ToString() + "')";
                DataTable jiage = SQLhelp.GetDataTable(sql, CommandType.Text);
                for (int j = 0; j < jiage.Rows.Count; j++)
                {
                    int shuliang = Convert.ToInt32(jiage.Rows[j]["加工数量"]);
                    string jiage1 = Convert.ToString(jiage.Rows[j]["金额单价"]);
                    if (jiage1 != "")
                    {
                        zongjia += Convert.ToDouble(jiage.Rows[j]["金额单价"]) * (shuliang);

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
            gridView4.Columns["id"].Visible = false;
        }
        #endregion

        #region 导出EXCELL表
        private void btnDaochu_Click(object sender, EventArgs e)
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
