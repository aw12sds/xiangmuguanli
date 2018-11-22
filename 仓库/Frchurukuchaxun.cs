using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.仓库
{
    public partial class Frchurukuchaxun : Form
    {
        public Frchurukuchaxun()
        {
            InitializeComponent();
        }
        public DataTable dt;
        public DataTable DT1;
        public string yonghu;
        private void tabControl1_Click(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (dateTimeInput1.Text == "")
            {
                MessageBox.Show("请输入开始时间！");
                return;

            }
            if (dateTimeInput2.Text == "")
            {
                MessageBox.Show("请输入结束时间！");
                return;
            }
            if (dateTimeInput1.Value > dateTimeInput2.Value)
            {
                MessageBox.Show("开始时间不得大于结束时间");
                return;
            }
            string sql = "select * from tb_ruku where (入库时间>'" + dateTimeInput1.Text + "' and 入库时间<'" + dateTimeInput2.Text + "' and 入库人='" + yonghu + "') or (入库时间>'" + dateTimeInput1.Text + "' and 入库时间<'" + dateTimeInput2.Text + "' and 入库人='钱陆亦') ";
            gridControl4.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
            gridView4.Columns["id"].Visible = false;
            gridView4.Columns["定位"].Visible = false;

            gridView4.Columns["发票号"].Visible = false;
            gridView4.Columns["税率"].Visible = false;
            gridView4.Columns["净额"].Visible = false;
            gridView4.Columns["税额"].Visible = false;
            gridView4.Columns["净单价"].Visible = false;
            gridView4.Columns["料单类型"].Visible = false;
            gridView4.Columns["入库人"].Visible = false;
            dt = SQLhelp.GetDataTable(sql, CommandType.Text);

        }
        

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (dateTimeInput3.Text == "")
            {
                MessageBox.Show("请输入开始时间！");
                return;

            }
            if (dateTimeInput4.Text == "")
            {
                MessageBox.Show("请输入结束时间！");
                return;
            }
            if (dateTimeInput3.Value > dateTimeInput4.Value)
            {
                MessageBox.Show("开始时间不得大于结束时间");
                return;
            }
            string sql = "select * from tb_chuku where (出库时间>'" + dateTimeInput3.Text + "' and  出库时间<'" + dateTimeInput4.Text + "' and 出库人='" + yonghu + "') or (出库时间>'" + dateTimeInput3.Text + "' and  出库时间<'" + dateTimeInput4.Text + "' and 出库人='钱陆亦')";
            gridControl1.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
            gridView1.Columns["id"].Visible = false;
            gridView1.Columns["定位"].Visible = false;

            gridView1.Columns["发票号"].Visible = false;
            gridView1.Columns["税率"].Visible = false;
            gridView1.Columns["净额"].Visible = false;
            gridView1.Columns["税额"].Visible = false;
            gridView1.Columns["净单价"].Visible = false;
            gridView1.Columns["料单类型"].Visible = false;
            gridView1.Columns["出库人"].Visible = false;
            DT1 = SQLhelp.GetDataTable(sql, CommandType.Text);

        }

        private void 导出Excel表格ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView4.RowCount == 0)
            {
                MessageBox.Show("请先生成收发存报表！");
                return;
            }
            if (gridView4.RowCount > 0)
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
        }

        private void 导出Excel表格ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0)
            {
                MessageBox.Show("请先生成收发存报表！");
                return;
            }
            if (gridView1.RowCount > 0)
            {
                SaveFileDialog fileDialog = new SaveFileDialog();
                fileDialog.Title = "导出Excel";
                fileDialog.Filter = "Excel文件(*.xls)|*.xls";
                DialogResult dialogResult = fileDialog.ShowDialog(this);
                if (dialogResult == DialogResult.OK)
                {
                    DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                    gridControl1.ExportToXls(fileDialog.FileName);
                    DevExpress.XtraEditors.XtraMessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            string sql = "select * from tb_ruku where 编码 ='" + txtERP.Text + "' ";
            gridControl4.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
            gridView4.Columns["id"].Visible = false;
            gridView4.Columns["定位"].Visible = false;
            gridView4.Columns["发票号"].Visible = false;
            gridView4.Columns["税率"].Visible = false;
            gridView4.Columns["净额"].Visible = false;
            gridView4.Columns["税额"].Visible = false;
            gridView4.Columns["净单价"].Visible = false;
            gridView4.Columns["料单类型"].Visible = false;
            gridView4.Columns["出库人"].Visible = false;
            dt = SQLhelp.GetDataTable(sql, CommandType.Text);

        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            string sql = "select * from tb_chuku where 编码='" + txterp2.Text + "' ";
            gridControl1.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
            gridView1.Columns["id"].Visible = false;
            gridView1.Columns["定位"].Visible = false;
            gridView1.Columns["发票号"].Visible = false;
            gridView1.Columns["税率"].Visible = false;
            gridView1.Columns["净额"].Visible = false;
            gridView1.Columns["税额"].Visible = false;
            gridView1.Columns["净单价"].Visible = false;
            gridView1.Columns["料单类型"].Visible = false;
            gridView1.Columns["出库人"].Visible = false;
            dt = SQLhelp.GetDataTable(sql, CommandType.Text);

        }

        private void 撤回该条记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认撤回该记录吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string id = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "定位"));
                string id1 = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id"));
                double ruku = Convert.ToDouble(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "入库数量"));

                string sql = "select 实际到货数量,库存数量 from tb_caigouliaodan where id='" + id + "'";
                double shijidaohuo = Convert.ToDouble(SQLhelp.GetDataTable(sql, CommandType.Text).Rows[0]["实际到货数量"]);
                double kucun = Convert.ToDouble(SQLhelp.GetDataTable(sql, CommandType.Text).Rows[0]["库存数量"]);
                double shijidaohuo1 = shijidaohuo - ruku;
                double kucun1 = kucun - ruku;

                string sql1 = "update tb_caigouliaodan set 实际到货数量='" + shijidaohuo1 + "',库存数量='" + kucun1 + "' where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql1, CommandType.Text);

                string sql2 = "delete  from tb_ruku  where id='" + id1 + "'";
                SQLhelp.ExecuteScalar(sql2, CommandType.Text);
                MessageBox.Show("撤回成功！");
                string sql3 = "select * from tb_ruku where (入库时间>'" + dateTimeInput1.Text + "' and 入库时间<'" + dateTimeInput2.Text + "' and 入库人='" + yonghu + "') or (入库时间>'" + dateTimeInput1.Text + "' and 入库时间<'" + dateTimeInput2.Text + "' and 入库人='钱陆亦') ";
                gridControl4.DataSource = SQLhelp.GetDataTable(sql3, CommandType.Text);
            }

        }

        private void 撤回改条记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认撤回该记录吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string id = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "定位"));
                string id1 = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id"));
                double ruku = Convert.ToDouble(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "出库数量"));

                string sql = "select 出库数量,库存数量 from tb_caigouliaodan where id='" + id + "'";
                double shijidaohuo = Convert.ToDouble(SQLhelp.GetDataTable(sql, CommandType.Text).Rows[0]["出库数量"]);
                double kucun = Convert.ToDouble(SQLhelp.GetDataTable(sql, CommandType.Text).Rows[0]["库存数量"]);
                double shijidaohuo1 = shijidaohuo - ruku;
                double kucun1 = kucun + ruku;

                string sql1 = "update tb_caigouliaodan set 出库数量='" + shijidaohuo1 + "',库存数量='" + kucun1 + "' where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql1, CommandType.Text);

                string sql2 = "delete  from tb_chuku  where id='" + id1 + "'";
                SQLhelp.ExecuteScalar(sql2, CommandType.Text);
                MessageBox.Show("撤回成功！");
                string sql3 = "select * from tb_chuku where (出库时间>'" + dateTimeInput3.Text + "' and  出库时间<'" + dateTimeInput4.Text + "' and 出库人='" + yonghu + "') or (出库时间>'" + dateTimeInput3.Text + "' and  出库时间<'" + dateTimeInput4.Text + "' and 出库人='钱陆亦')";
                gridControl1.DataSource = SQLhelp.GetDataTable(sql3, CommandType.Text);

            }

        }

        private void gridView4_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }

        private void Frchurukuchaxun_Load(object sender, EventArgs e)
        {
            string sql = "select id,工作令号,项目名称,设备名称,编码,名称,型号,合同号,库存数量,库位号,申购人,到货时间,理论净额,净单价 from tb_caigouliaodan where  库存数量!=0  and 区分='新'";
            gridControl2.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
            gridView2.Columns["id"].Visible = false;
            

        }
        public Frdengdai fpro = null;
        public string  kaishi;
        public string jieshu;
      
        private void gridView3_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }
        
        DataTable biaoge = new DataTable();
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            string sqlshouru = "select * from tb_ruku where  区分='新' and 入库时间 <= '" +jieshu+ "'";
            DataTable dt = SQLhelp.GetDataTable(sqlshouru, CommandType.Text);            
            List<string> list = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)//遍历数组成员
            {
                if (dt.Rows[i]["编码"].ToString() != "")
                {
                    if (list.IndexOf(dt.Rows[i]["编码"].ToString()) == -1)//对每个成员做一次新数组查询如果没有相等的则加到新数组
                        list.Add(dt.Rows[i]["编码"].ToString());
                }
            }        
            biaoge.Columns.Add("编码");
            biaoge.Columns.Add("名称");
            biaoge.Columns.Add("型号");
            biaoge.Columns.Add("单位");
            biaoge.Columns.Add("期初数量", typeof(double));
            biaoge.Columns.Add("期初单价", typeof(double));
            biaoge.Columns.Add("期初金额", typeof(double));
            biaoge.Columns.Add("收入数量", typeof(double));
            biaoge.Columns.Add("收入单价", typeof(double));
            biaoge.Columns.Add("收入金额", typeof(double));
            biaoge.Columns.Add("发出数量", typeof(double));
            biaoge.Columns.Add("发出单价", typeof(double));
            biaoge.Columns.Add("发出金额", typeof(double));
            biaoge.Columns.Add("结存数量", typeof(double));
            biaoge.Columns.Add("结存单价", typeof(double));
            biaoge.Columns.Add("结存金额", typeof(double));
            for (int i = 0; i < list.Count; i++)//遍历数组成员
            {
                string sql = "select 编码,单位,型号,名称 from tb_ruku where 编码='" + list[i].ToString() + "'";
                DataTable shujv = SQLhelp.GetDataTable(sql, CommandType.Text);

                biaoge.Rows.Add();
                if (shujv.Rows.Count == 0)
                {
                    string sql111 = "select 编码,单位,型号,名称 from tb_chuku where 编码='" + list[i].ToString() + "'";
                    DataTable dt11 = SQLhelp.GetDataTable(sql111, CommandType.Text);
                    biaoge.Rows[i]["编码"] = dt11.Rows[0]["编码"].ToString();
                    biaoge.Rows[i]["单位"] = dt11.Rows[0]["单位"].ToString();
                    biaoge.Rows[i]["型号"] = dt11.Rows[0]["型号"].ToString();
                    biaoge.Rows[i]["名称"] = dt11.Rows[0]["名称"].ToString();

                }
                if (shujv.Rows.Count != 0)
                {
                    biaoge.Rows[i]["编码"] = shujv.Rows[0]["编码"].ToString();
                    biaoge.Rows[i]["单位"] = shujv.Rows[0]["单位"].ToString();
                    biaoge.Rows[i]["型号"] = shujv.Rows[0]["型号"].ToString();
                    biaoge.Rows[i]["名称"] = shujv.Rows[0]["名称"].ToString();
                }
            }


            for (int i = 0; i < biaoge.Rows.Count; i++)//遍历数组成员
            {
                string sqlqichu = "select * from tb_ruku where 入库时间<'" + kaishi + "' and 编码='" + biaoge.Rows[i]["编码"].ToString() + "' and 区分='新' ";

                DataTable shujv = SQLhelp.GetDataTable(sqlqichu, CommandType.Text);
                double zongjia = 0;
                double shulaing = 0;
                double danjia = 0;
                for (int j = 0; j < shujv.Rows.Count; j++)
                {
                    zongjia += Convert.ToDouble(shujv.Rows[j]["净额"]);
                    shulaing += Convert.ToDouble(shujv.Rows[j]["入库数量"]);
                   
                }
                
                string sqlqichu1 = "select * from tb_chuku where 出库时间<'" + kaishi + "' and 编码='" + biaoge.Rows[i]["编码"].ToString() + "' and 区分='新' ";
                DataTable dtttt = SQLhelp.GetDataTable(sqlqichu1, CommandType.Text);
                for (int jj = 0; jj < dtttt.Rows.Count; jj++)
                {
                    zongjia -= Convert.ToDouble(dtttt.Rows[jj]["净额"]);
                    shulaing -= Convert.ToDouble(dtttt.Rows[jj]["出库数量"]);
                }

                if (shulaing != 0)
                {
                    danjia = zongjia / shulaing;
                    
                    //string bianma = biaoge.Rows[i]["编码"].ToString();
                    //string sqlll = "select 净单价 from tb_qichu where 编码='" + bianma + "'";
                    //string panduan = SQLhelp.ExecuteScalar(sqlll, CommandType.Text).ToString();
                    //if (panduan != "")
                    //{
                    //    zongjia = shulaing * Convert.ToDouble(SQLhelp.ExecuteScalar(sqlll, CommandType.Text));
                    //    danjia = Convert.ToDouble(SQLhelp.ExecuteScalar(sqlll, CommandType.Text));
                    //}
                    //if (panduan == "")
                    //{
                    //    danjia = zongjia / shulaing;
                    //}
                }
                if (shulaing == 0)
                {
                    danjia = 0;
                }
                string str1 = String.Format("{0:F}", danjia);
                string str2 = String.Format("{0:F}", zongjia);
                biaoge.Rows[i]["期初数量"] = shulaing;
                biaoge.Rows[i]["期初单价"] = str1;
                biaoge.Rows[i]["期初金额"] = str2;

            }

            for (int i = 0; i < biaoge.Rows.Count; i++)//遍历数组成员
            {
                string sqlshouru1 = "select * from tb_ruku where 入库时间>='" + kaishi + "' and 入库时间 <= '" + jieshu + "' and 编码='" + biaoge.Rows[i]["编码"].ToString() + "' and 区分 = '新' ";

                DataTable shujv = SQLhelp.GetDataTable(sqlshouru1, CommandType.Text);
                double zongjia = 0;
                double shulaing = 0;
                double danjia = 0;
                for (int j = 0; j < shujv.Rows.Count; j++)
                {
                    zongjia += Convert.ToDouble(shujv.Rows[j]["净额"]);
                    shulaing += Convert.ToDouble(shujv.Rows[j]["入库数量"]);

                }
                if (shulaing != 0)
                {
                    danjia = zongjia / shulaing;
                }
                if (shulaing == 0)
                {
                    danjia = 0;
                }
                string str1 = String.Format("{0:F}", danjia);
                string str2 = String.Format("{0:F}", zongjia);
                biaoge.Rows[i]["收入数量"] = shulaing;
                biaoge.Rows[i]["收入单价"] = str1;
                biaoge.Rows[i]["收入金额"] = str2;

            }

            for (int i = 0; i < biaoge.Rows.Count; i++)//遍历数组成员
            {
                string sqlshouru2 = "select * from tb_chuku where 出库时间>='" + kaishi + "' and 出库时间 <= '" + jieshu + "' and 编码='" + biaoge.Rows[i]["编码"].ToString() + "' and 区分='新' ";

                DataTable shujv = SQLhelp.GetDataTable(sqlshouru2, CommandType.Text);
                double zongjia = 0;
                double shulaing = 0;
                double danjia = 0;
                for (int j = 0; j < shujv.Rows.Count; j++)
                {
                    zongjia += Convert.ToDouble(shujv.Rows[j]["净额"]);
                    shulaing += Convert.ToDouble(shujv.Rows[j]["出库数量"]);

                }
                if (shulaing != 0)
                {
                    danjia = zongjia / shulaing;
                }
                if (shulaing == 0)
                {
                    danjia = 0;
                }
                string str1 = String.Format("{0:F}", danjia);
                string str2 = String.Format("{0:F}", zongjia);
                biaoge.Rows[i]["发出数量"] = shulaing;
                biaoge.Rows[i]["发出单价"] = str1;
                biaoge.Rows[i]["发出金额"] = str2;

            }

            for (int i = 0; i < biaoge.Rows.Count; i++)//遍历数组成员
            {
                biaoge.Rows[i]["结存数量"] = Convert.ToDouble(biaoge.Rows[i]["收入数量"]) + Convert.ToDouble(biaoge.Rows[i]["期初数量"]) - Convert.ToDouble(biaoge.Rows[i]["发出数量"]);
                double jiecunshuliang = Convert.ToDouble(biaoge.Rows[i]["收入数量"]) + Convert.ToDouble(biaoge.Rows[i]["期初数量"]) - Convert.ToDouble(biaoge.Rows[i]["发出数量"]);
                biaoge.Rows[i]["结存金额"] = Convert.ToDouble(biaoge.Rows[i]["收入金额"]) + Convert.ToDouble(biaoge.Rows[i]["期初金额"]) - Convert.ToDouble(biaoge.Rows[i]["发出金额"]);
                if (jiecunshuliang == 0)
                {
                    biaoge.Rows[i]["结存金额"] = 0;
                    biaoge.Rows[i]["结存单价"] = 0;
                }
                if (jiecunshuliang != 0)
                {
                    if (biaoge.Rows[i]["结存金额"].ToString() != "0")
                    {
                        double a = Convert.ToDouble(biaoge.Rows[i]["结存金额"]) / Convert.ToDouble(biaoge.Rows[i]["结存数量"]);
                        string str1 = String.Format("{0:F}", a);
                        biaoge.Rows[i]["结存单价"] = str1;
                    }
                    if (biaoge.Rows[i]["结存金额"].ToString() == "0")
                    {
                        biaoge.Rows[i]["结存单价"] = 0;
                    }
                }

            }         
            biaoge1 = biaoge.Clone();
            DataRow[] dr =biaoge.Select("期初数量<>0 and 收入数量<>0 and 发出数量<>0 and 结存数量<>0 ");
            for (int i = 0; i < biaoge.Rows.Count; i++)
            {
                string qichu = biaoge.Rows[i]["期初数量"].ToString();
                string shouru = biaoge.Rows[i]["收入数量"].ToString();
                string fachu = biaoge.Rows[i]["发出数量"].ToString();
                string jiecun = biaoge.Rows[i]["结存数量"].ToString();
                if (qichu != "0" || shouru != "0" || fachu != "0" || jiecun != "0")
                {
                    biaoge1.ImportRow(biaoge.Rows[i]);
                }            
            }           
        }
       
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            fpro.Close();
        }
        DataTable biaoge1 = new DataTable();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (dateTimeInput6.Text == "")
            {
                MessageBox.Show("请设置开始时间！");
                return;
            }
            if (dateTimeInput5.Text == "")
            {
                MessageBox.Show("请设置结束时间！");
                return;
            }

            if (dateTimeInput6.Value >= dateTimeInput5.Value)
            {
                MessageBox.Show("开始时间不能大于结束时间");
                return;
            }
            kaishi = dateTimeInput6.Value.ToString("yyyy-MM-dd 00:00:00");
            jieshu = dateTimeInput5.Value.ToString("yyyy-MM-dd 23:59:59");

            this.backgroundWorker1.RunWorkerAsync();
            fpro = new Frdengdai();
            fpro.ShowDialog();
            gridControl3.DataSource = biaoge1;
            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (gridView3.RowCount == 0)
            {
                MessageBox.Show("请先生成收发存报表！");
                return;
            }
                if (gridView3.RowCount > 0)
            {
                SaveFileDialog fileDialog = new SaveFileDialog();
                fileDialog.Title = "导出Excel";
                fileDialog.Filter = "Excel文件(*.xls)|*.xls";
                DialogResult dialogResult = fileDialog.ShowDialog(this);
                if (dialogResult == DialogResult.OK)
                {
                    DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                    gridControl3.ExportToXls(fileDialog.FileName);
                    DevExpress.XtraEditors.XtraMessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (dateTimeInput8.Text == "")
            {
                MessageBox.Show("请输入开始时间！");
                return;

            }
            if (dateTimeInput7.Text == "")
            {
                MessageBox.Show("请输入结束时间！");
                return;
            }
            if(dateTimeInput7.Value<dateTimeInput8.Value)
            {
                MessageBox.Show("开始时间不得大于结束时间");
                return;
            }

          string  kaishi = dateTimeInput8.Value.ToString("yyyy-MM-dd 00:00:00");
            string jieshu = dateTimeInput7.Value.ToString("yyyy-MM-dd 23:59:59");


            string sql = "select * from tb_ruku where 入库时间>'" + kaishi + "' and 入库时间<'" + jieshu + "'";
            gridControl5.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
            gridView5.Columns["id"].Visible = false;
            gridView5.Columns["定位"].Visible = false;
            gridView5.Columns["税率"].Visible = false;
            gridView5.Columns["总价"].Visible = false;
            gridView5.Columns["税额"].Visible = false;
            gridView5.Columns["净单价"].Visible = false;
            gridView5.Columns["料单类型"].Visible = false;
            gridView5.Columns["入库人"].Visible = false;
          
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            if (dateTimeInput10.Text == "")
            {
                MessageBox.Show("请输入开始时间！");
                return;
            }
            if (dateTimeInput9.Text == "")
            {
                MessageBox.Show("请输入结束时间！");
                return;
            }
            if (dateTimeInput9.Value < dateTimeInput10.Value)
            {
                MessageBox.Show("开始时间不得大于结束时间");
                return;
            }
            string kaishi = dateTimeInput10.Value.ToString("yyyy-MM-dd 00:00:00");
            string jieshu = dateTimeInput9.Value.ToString("yyyy-MM-dd 23:59:59");



            string sql = "select * from tb_chuku where 出库时间>'" + kaishi + "' and 出库时间<'" + jieshu + "'";
            gridControl6.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
            gridView6.Columns["id"].Visible = false;
            gridView6.Columns["定位"].Visible = false;          
            gridView6.Columns["税率"].Visible = false;
            gridView6.Columns["总价"].Visible = false;
            gridView6.Columns["税额"].Visible = false;
            gridView6.Columns["净单价"].Visible = false;
            gridView6.Columns["料单类型"].Visible = false;
            gridView6.Columns["出库人"].Visible = false;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (gridView5.RowCount == 0)
            {
                MessageBox.Show("请先生成收发存报表！");
                return;
            }
            if (gridView5.RowCount > 0)
            {
                SaveFileDialog fileDialog = new SaveFileDialog();
                fileDialog.Title = "导出Excel";
                fileDialog.Filter = "Excel文件(*.xls)|*.xls";
                DialogResult dialogResult = fileDialog.ShowDialog(this);
                if (dialogResult == DialogResult.OK)
                {
                    DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                    gridControl5.ExportToXls(fileDialog.FileName);
                    DevExpress.XtraEditors.XtraMessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (gridView6.RowCount == 0)
            {
                MessageBox.Show("请先生成收发存报表！");
                return;
            }
            if (gridView6.RowCount > 0)
            {
                SaveFileDialog fileDialog = new SaveFileDialog();
                fileDialog.Title = "导出Excel";
                fileDialog.Filter = "Excel文件(*.xls)|*.xls";
                DialogResult dialogResult = fileDialog.ShowDialog(this);
                if (dialogResult == DialogResult.OK)
                {
                    DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                    gridControl6.ExportToXls(fileDialog.FileName);
                    DevExpress.XtraEditors.XtraMessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }
        string kaishi1;
        string jieshu1;
        private void simpleButton8_Click(object sender, EventArgs e)
        {
            dttta = new DataTable();
            if (dateTimeInput12.Text == "")
            {
                MessageBox.Show("请设置开始时间！");
                return;
            }
            if (dateTimeInput11.Text == "")
            {
                MessageBox.Show("请设置结束时间！");
                return;
            }

            if (dateTimeInput11.Value < dateTimeInput12.Value)
            {
                MessageBox.Show("开始时间不能大于结束时间");
                return;
            }
            kaishi1 = dateTimeInput12.Value.ToString("yyyy-MM-dd 00:00:00");
            jieshu1 = dateTimeInput11.Value.ToString("yyyy-MM-dd 23:59:59");

            this.backgroundWorker2.RunWorkerAsync();
            fpro = new Frdengdai();
            fpro.ShowDialog();
            gridControl7.DataSource = dttta;
            

        }
        DataTable dttta;
        
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {

            string sqlshouru = "select 供方名称,供方代号,开票供方,开票供方代号,编码,发票号,流水号,开票时间,开票人,sum(总价) as '总价',sum(开票数量) as '开票数量',sum(净额) as '净额'  from tb_fapiao  where 开票时间>='"+kaishi1+ "' and  开票时间<='" + jieshu1 + "' group by 供方名称,供方代号,开票供方,开票供方代号,编码,发票号,流水号,开票时间,开票人 ";
            
            dttta.Columns.Add("供方名称", typeof(string));
            dttta.Columns.Add("供方代号", typeof(string));
            dttta.Columns.Add("开票供方", typeof(string));
            dttta.Columns.Add("开票供方代号", typeof(string));
            dttta.Columns.Add("编码", typeof(string));
            dttta.Columns.Add("发票号", typeof(string));
            dttta.Columns.Add("流水号", typeof(string));
            dttta.Columns.Add("开票时间", typeof(string));
            dttta.Columns.Add("开票人", typeof(string));
            dttta.Columns.Add("总价", typeof(float));
            dttta.Columns.Add("开票数量", typeof(float));
            dttta.Columns.Add("净额", typeof(float));
         
            dttta = SQLhelp.GetDataTable(sqlshouru, CommandType.Text);
            dttta.Columns.Add("名称", typeof(string));
            dttta.Columns.Add("型号", typeof(string));
            dttta.Columns.Add("含税单价", typeof(float));
            dttta.Columns.Add("不含税单价", typeof(float));
            dttta.Columns.Add("税率", typeof(string));
            for (int i = 0; i < dttta.Rows.Count; i++)//遍历数组成员
            {
                string sql = " select 名称,型号,税率 from tb_fapiao where 编码='" + dttta.Rows[i]["编码"].ToString() + "'";
                DataTable dtttt = SQLhelp.GetDataTable(sql, CommandType.Text);
                dttta.Rows[i]["名称"] = dtttt.Rows[0]["名称"].ToString();
                dttta.Rows[i]["型号"] = dtttt.Rows[0]["型号"].ToString();
                dttta.Rows[i]["税率"] = dtttt.Rows[0]["税率"].ToString();
            }
            for (int i = 0; i < dttta.Rows.Count; i++)//遍历数组成员
            {
                double shuliang =Convert.ToDouble( dttta.Rows[i]["开票数量"]);
                double zongjia = Convert.ToDouble(dttta.Rows[i]["总价"]);
                double jinge = Convert.ToDouble(dttta.Rows[i]["净额"]);
                double hanshuidanjia = zongjia/shuliang;
                double buhanshuidanjia = jinge / shuliang;
                dttta.Rows[i]["含税单价"] = hanshuidanjia;
                dttta.Rows[i]["不含税单价"] = buhanshuidanjia;
            }          
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            fpro.Close();
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            if (gridView7.RowCount == 0)
            {
                MessageBox.Show("请先生成收发存报表！");
                return;
            }
            if (gridView7.RowCount > 0)
            {
                SaveFileDialog fileDialog = new SaveFileDialog();
                fileDialog.Title = "导出Excel";
                fileDialog.Filter = "Excel文件(*.xls)|*.xls";
                DialogResult dialogResult = fileDialog.ShowDialog(this);
                if (dialogResult == DialogResult.OK)
                {
                    DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                    gridControl7.ExportToXls(fileDialog.FileName);
                    DevExpress.XtraEditors.XtraMessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }
        DataTable dttaaat;     
        string jieshu2;
        private void simpleButton10_Click(object sender, EventArgs e)
        {
            dttaaat = new DataTable();
          
            if (dateTimeInput13.Text == "")
            {
                MessageBox.Show("请设置结束时间！");
                return;
            }
            
            jieshu2 = dateTimeInput13.Value.ToString("yyyy-MM-dd 23:59:59");

            this.backgroundWorker3.RunWorkerAsync();
            fpro = new Frdengdai();
            fpro.ShowDialog();
            gridControl8.DataSource = dttaaat;
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {

            string sqlshouru = "select 供方名称,合同号,发票号,编码,名称,型号,单位,实际到货数量,已开票数量,到货时间,净单价   from tb_caigouliaodan  where  (到货时间<='"+jieshu2+ "' and  已开票数量!=实际到货数量 and 区分='新' ) or  (到货时间<='" + jieshu2 + "' and  已开票数量 is null and 区分='新' )";

            dttaaat.Columns.Add("供方名称", typeof(string));
            dttaaat.Columns.Add("合同号", typeof(string));
            dttaaat.Columns.Add("发票号", typeof(string));
            dttaaat.Columns.Add("编码", typeof(string));
            dttaaat.Columns.Add("名称", typeof(string));
            dttaaat.Columns.Add("型号", typeof(string));
            dttaaat.Columns.Add("单位", typeof(string));
            dttaaat.Columns.Add("实际到货数量", typeof(string));        
            dttaaat.Columns.Add("已开票数量", typeof(string));
            dttaaat.Columns.Add("到货时间", typeof(string));
            dttaaat.Columns.Add("净单价", typeof(string));
            dttaaat = SQLhelp.GetDataTable(sqlshouru, CommandType.Text);
            dttaaat.Columns.Add("未开票数量", typeof(float));
            dttaaat.Columns.Add("未开票金额", typeof(float));

            for (int i = 0; i < dttaaat.Rows.Count; i++)//遍历数组成员
            {
                string yikaipiao =Convert.ToString(dttaaat.Rows[i]["已开票数量"]);
                if (yikaipiao != "")
                {
                    double weikaipiao = Convert.ToDouble(dttaaat.Rows[i]["实际到货数量"]) - Convert.ToDouble(dttaaat.Rows[i]["已开票数量"]);
                    double weikaipiaojine = weikaipiao * Convert.ToDouble(dttaaat.Rows[i]["净单价"]);
                    dttaaat.Rows[i]["未开票数量"] = weikaipiao;
                    dttaaat.Rows[i]["未开票金额"] = weikaipiaojine;
                }
                if (yikaipiao == "")
                {
                    double weikaipiao = Convert.ToDouble(dttaaat.Rows[i]["实际到货数量"]) ;
                    double weikaipiaojine = weikaipiao * Convert.ToDouble(dttaaat.Rows[i]["净单价"]);
                    dttaaat.Rows[i]["未开票数量"] = weikaipiao;
                    dttaaat.Rows[i]["未开票金额"] = weikaipiaojine;                    
                }
            }
           
        }

        private void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            fpro.Close();
        }

        private void gridView8_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }

        private void gridView7_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }

        private void gridView6_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }

        private void gridView5_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }

        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

            if (gridView2.RowCount == 0)
            {
                MessageBox.Show("请先生成收发存报表！");
                return;
            }
            if (gridView2.RowCount > 0)
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

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            if (gridView8.RowCount == 0)
            {
                MessageBox.Show("请先生成收发存报表！");
                return;
            }
            if (gridView8.RowCount > 0)
            {
                SaveFileDialog fileDialog = new SaveFileDialog();
                fileDialog.Title = "导出Excel";
                fileDialog.Filter = "Excel文件(*.xls)|*.xls";
                DialogResult dialogResult = fileDialog.ShowDialog(this);
                if (dialogResult == DialogResult.OK)
                {
                    DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                    gridControl8.ExportToXls(fileDialog.FileName);
                    DevExpress.XtraEditors.XtraMessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
