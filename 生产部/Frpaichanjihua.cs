using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 项目管理系统.物流部;

namespace 项目管理系统.生产部
{
    public partial class Frpaichanjihua : Office2007Form
    {
        public Frpaichanjihua()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        DataTable dt;
        private void Frpaichanjihua_Load(object sender, EventArgs e)
        {
            
        }
      
        private void buttonItem5_Click(object sender, EventArgs e)
        {
            string sql = "select id,工作令号,项目名称,设备名称,数量,生产部确认时间,计划完成时间,时间,图纸下达时间 from tb_jishubumen where 制造类型='自制' and 是否提交=1 and 技术部通过=1  and 生产部确认=1 and 排产计划完成 is null  and  工作令号 like '%" + txtmingcheng + "%'";
            dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            dt.Columns.Add("自制图纸数量");
            dt.Columns.Add("自制零件数量");
            dt.Columns.Add("图纸完成数量");
            dt.Columns.Add("自制完成数量");
            dt.Columns.Add("外协图纸数量");
            dt.Columns.Add("外协零件数量");
            dt.Columns.Add("外协图纸完成数量");
            dt.Columns.Add("外协完成数量");
            dt.Columns.Add("机械标准件数量");
            dt.Columns.Add("机械标准件完成数量");
            dt.Columns.Add("电气标准件数量");
            dt.Columns.Add("电气标准件完成数量");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string sql1 = "select count(*) from tb_caigouliaodan where 工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "' and 设备名称='" + dt.Rows[i]["设备名称"] + "'  and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='自制零部件' ";

                dt.Rows[i]["自制图纸数量"] = SQLhelp.ExecuteScalar(sql1, CommandType.Text).ToString();
                
                string sql2 = "select sum(实际采购数量) from tb_caigouliaodan where 工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "' and 设备名称='" + dt.Rows[i]["设备名称"] + "'  and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='自制零部件' ";
                dt.Rows[i]["自制零件数量"] = SQLhelp.ExecuteScalar(sql2, CommandType.Text).ToString();


                string sql12 = "select count(*) from tb_caigouliaodan where 工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "'  and 设备名称='" + dt.Rows[i]["设备名称"] + "' and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='自制零部件' and 生产部确认=1";

                dt.Rows[i]["图纸完成数量"] = SQLhelp.ExecuteScalar(sql12, CommandType.Text).ToString();

                string sql3 = "select sum(实际采购数量) from tb_caigouliaodan where 工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "'  and 设备名称='" + dt.Rows[i]["设备名称"] + "' and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='自制零部件' and 生产部确认=1";

                dt.Rows[i]["自制完成数量"] = SQLhelp.ExecuteScalar(sql3, CommandType.Text).ToString();

                string sql13 = "select count(*) from tb_caigouliaodan where 工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "'  and 设备名称='" + dt.Rows[i]["设备名称"] + "' and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='外协零部件' ";

                dt.Rows[i]["外协图纸数量"] = SQLhelp.ExecuteScalar(sql13, CommandType.Text).ToString();

                string sql4 = "select sum(实际采购数量) from tb_caigouliaodan where 工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "'  and 设备名称='" + dt.Rows[i]["设备名称"] + "' and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='外协零部件' ";

                dt.Rows[i]["外协零件数量"] = SQLhelp.ExecuteScalar(sql4, CommandType.Text).ToString();

                string sql14 = "select count(*) from tb_caigouliaodan where (工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "'  and 设备名称='" + dt.Rows[i]["设备名称"] + "' and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='外协零部件'  and  当前状态='9已到货')or (工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "'  and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='外协零部件'  and  当前状态='10已出库')";

                dt.Rows[i]["外协图纸完成数量"] = SQLhelp.ExecuteScalar(sql14, CommandType.Text).ToString();

                string sql5 = "select sum(实际采购数量) from tb_caigouliaodan where (工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "'  and 设备名称='" + dt.Rows[i]["设备名称"] + "' and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='外协零部件'  and  当前状态='9已到货')or (工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "'  and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='外协零部件'  and  当前状态='10已出库')";

                dt.Rows[i]["外协完成数量"] = SQLhelp.ExecuteScalar(sql5, CommandType.Text).ToString();

                string sql15 = "select count(*) from tb_caigouliaodan where 工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "'  and 设备名称='" + dt.Rows[i]["设备名称"] + "' and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='机械标准件' ";

                dt.Rows[i]["机械标准件数量"] = SQLhelp.ExecuteScalar(sql15, CommandType.Text).ToString();


                string sql16 = "select count(*) from tb_caigouliaodan where ( 工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "'  and 设备名称='" + dt.Rows[i]["设备名称"] + "' and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='机械标准件' and  当前状态='9已到货')or (工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "'  and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='机械标准件'  and  当前状态='10已出库') ";

                dt.Rows[i]["机械标准件完成数量"] = SQLhelp.ExecuteScalar(sql16, CommandType.Text).ToString();

                string sql17 = "select count(*) from tb_caigouliaodan where 工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "' and 设备名称='" + dt.Rows[i]["设备名称"] + "'  and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='电气标准件'  ";

                dt.Rows[i]["电气标准件数量"] = SQLhelp.ExecuteScalar(sql17, CommandType.Text).ToString();

                string sql18 = "select count(*) from tb_caigouliaodan where (工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "'  and 设备名称='" + dt.Rows[i]["设备名称"] + "' and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='电气标准件' and  当前状态='9已到货') or (工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "'  and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='电气标准件'  and  当前状态='10已出库')";

                dt.Rows[i]["电气标准件完成数量"] = SQLhelp.ExecuteScalar(sql18, CommandType.Text).ToString();


            }
            gridControl4.DataSource = dt;
            gridView4.Columns["id"].Visible = false;
            gridView4.Columns["时间"].Visible = false;
            gridView4.Columns["生产部确认时间"].Caption = "下发任务时间";
            string sql1234 = "select id,工作令号,项目名称,设备名称,数量,生产部确认时间,计划完成时间,时间,图纸下达时间 from tb_jishubumen where 制造类型='自制' and 是否提交=1 and 技术部通过=1  and 生产部确认=1 and 排产计划完成=1  and  工作令号 like '%" + txtmingcheng + "%'";
            dt = SQLhelp.GetDataTable(sql1234, CommandType.Text);
            dt.Columns.Add("自制图纸数量");
            dt.Columns.Add("自制零件数量");
            dt.Columns.Add("图纸完成数量");
            dt.Columns.Add("自制完成数量");
            dt.Columns.Add("外协图纸数量");
            dt.Columns.Add("外协零件数量");
            dt.Columns.Add("外协图纸完成数量");
            dt.Columns.Add("外协完成数量");
            dt.Columns.Add("机械标准件数量");
            dt.Columns.Add("机械标准件完成数量");
            dt.Columns.Add("电气标准件数量");
            dt.Columns.Add("电气标准件完成数量");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string sql1 = "select count(*) from tb_caigouliaodan where 工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "'  and 设备名称='" + dt.Rows[i]["设备名称"] + "' and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='自制零部件' ";
                dt.Rows[i]["自制图纸数量"] = SQLhelp.ExecuteScalar(sql1, CommandType.Text).ToString();

                string sql2 = "select sum(实际采购数量) from tb_caigouliaodan where 工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "' and 设备名称='" + dt.Rows[i]["设备名称"] + "'  and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='自制零部件' ";
                dt.Rows[i]["自制零件数量"] = SQLhelp.ExecuteScalar(sql2, CommandType.Text).ToString();

                string sql12 = "select count(*) from tb_caigouliaodan where 工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "'  and 设备名称='" + dt.Rows[i]["设备名称"] + "' and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='自制零部件' and 生产部确认=1";
                dt.Rows[i]["图纸完成数量"] = SQLhelp.ExecuteScalar(sql12, CommandType.Text).ToString();

                string sql3 = "select sum(实际采购数量) from tb_caigouliaodan where 工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "'  and 设备名称='" + dt.Rows[i]["设备名称"] + "' and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='自制零部件' and 生产部确认=1";

                dt.Rows[i]["自制完成数量"] = SQLhelp.ExecuteScalar(sql3, CommandType.Text).ToString();

                string sql13 = "select count(*) from tb_caigouliaodan where 工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "'  and 设备名称='" + dt.Rows[i]["设备名称"] + "' and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='外协零部件' ";
                dt.Rows[i]["外协图纸数量"] = SQLhelp.ExecuteScalar(sql13, CommandType.Text).ToString();

                string sql4 = "select sum(实际采购数量) from tb_caigouliaodan where 工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "'  and 设备名称='" + dt.Rows[i]["设备名称"] + "' and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='外协零部件' ";

                dt.Rows[i]["外协零件数量"] = SQLhelp.ExecuteScalar(sql4, CommandType.Text).ToString();

                string sql14 = "select count(*) from tb_caigouliaodan where (工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "'  and 设备名称='" + dt.Rows[i]["设备名称"] + "' and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='外协零部件'  and  当前状态='9已到货')or (工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "'  and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='外协零部件'  and  当前状态='10已出库')";
                dt.Rows[i]["外协图纸完成数量"] = SQLhelp.ExecuteScalar(sql14, CommandType.Text).ToString();

                string sql5 = "select sum(实际采购数量) from tb_caigouliaodan where (工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "'  and 设备名称='" + dt.Rows[i]["设备名称"] + "' and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='外协零部件'  and  当前状态='9已到货')or (工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "'  and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='外协零部件'  and  当前状态='10已出库')";

                dt.Rows[i]["外协完成数量"] = SQLhelp.ExecuteScalar(sql5, CommandType.Text).ToString();

                string sql15 = "select count(*) from tb_caigouliaodan where 工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "'  and 设备名称='" + dt.Rows[i]["设备名称"] + "' and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='机械标准件' ";
                dt.Rows[i]["机械标准件数量"] = SQLhelp.ExecuteScalar(sql15, CommandType.Text).ToString();
                string sql16 = "select count(*) from tb_caigouliaodan where ( 工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "'  and 设备名称='" + dt.Rows[i]["设备名称"] + "' and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='机械标准件' and  当前状态='9已到货')or (工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "'  and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='机械标准件'  and  当前状态='10已出库') ";

                dt.Rows[i]["机械标准件完成数量"] = SQLhelp.ExecuteScalar(sql16, CommandType.Text).ToString();
                string sql17 = "select count(*) from tb_caigouliaodan where 工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "' and 设备名称='" + dt.Rows[i]["设备名称"] + "'  and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='电气标准件'  ";
                dt.Rows[i]["电气标准件数量"] = SQLhelp.ExecuteScalar(sql17, CommandType.Text).ToString();
                string sql18 = "select count(*) from tb_caigouliaodan where (工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "'  and 设备名称='" + dt.Rows[i]["设备名称"] + "' and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='电气标准件' and  当前状态='9已到货') or (工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "'  and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='电气标准件'  and  当前状态='10已出库')";
                dt.Rows[i]["电气标准件完成数量"] = SQLhelp.ExecuteScalar(sql18, CommandType.Text).ToString();
            }
            gridControl1.DataSource = dt;
            gridView1.Columns["id"].Visible = false;
            gridView1.Columns["时间"].Visible = false;
            gridView1.Columns["生产部确认时间"].Caption = "下发任务时间";
        }       
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView4.RowCount; i++)
            {
                string id = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id"));

                string jihua = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "计划完成时间"));

                if (jihua != "")
                {

                    string sql = "update tb_jishubumen set 计划完成时间='" + jihua + "' where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql, CommandType.Text);
                }
                
            }
            MessageBox.Show("保存成功！重新刷新下");
        }
        private void 确认完成ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string id = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id"));
            string sql = "update tb_jishubumen set 排产计划完成=1 where id='" + id + "'";
            SQLhelp.ExecuteScalar(sql, CommandType.Text);
            MessageBox.Show("保存成功！重新刷新下");
        }
        private void buttonItem7_Click(object sender, EventArgs e)
        {
            string sql123 = "select id,工作令号,项目名称,设备名称,生产部确认时间,计划完成时间,时间 from tb_jishubumen where 制造类型='自制' and 是否提交=1 and 技术部通过=1  and 生产部确认=1  and 排产计划完成=1";
            dt = SQLhelp.GetDataTable(sql123, CommandType.Text);
            dt.Columns.Add("自制图纸数量");
            dt.Columns.Add("图纸完成数量");
            dt.Columns.Add("外协图纸数量");
            dt.Columns.Add("外协图纸完成数量");
            dt.Columns.Add("机械标准件数量");
            dt.Columns.Add("机械标准件完成数量");
            dt.Columns.Add("电气标准件数量");
            dt.Columns.Add("电气标准件完成数量");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string sql1 = "select count(*) from tb_caigouliaodan where 工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "'  and 设备名称='" + dt.Rows[i]["设备名称"] + "' and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='自制零部件' ";

                dt.Rows[i]["自制图纸数量"] = SQLhelp.ExecuteScalar(sql1, CommandType.Text).ToString();

                string sql12 = "select count(*) from tb_caigouliaodan where 工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "'  and 设备名称='" + dt.Rows[i]["设备名称"] + "' and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='自制零部件' and 生产部确认=1";

                dt.Rows[i]["图纸完成数量"] = SQLhelp.ExecuteScalar(sql12, CommandType.Text).ToString();

                string sql13 = "select count(*) from tb_caigouliaodan where 工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "'  and 设备名称='" + dt.Rows[i]["设备名称"] + "' and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='外协零部件' ";

                dt.Rows[i]["外协图纸数量"] = SQLhelp.ExecuteScalar(sql13, CommandType.Text).ToString();

                string sql14 = "select count(*) from tb_caigouliaodan where 工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "'  and 设备名称='" + dt.Rows[i]["设备名称"] + "' and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='外协零部件'  and  当前状态='9已到货'";

                dt.Rows[i]["外协图纸完成数量"] = SQLhelp.ExecuteScalar(sql14, CommandType.Text).ToString();

                string sql15 = "select count(*) from tb_caigouliaodan where 工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "' and 设备名称='" + dt.Rows[i]["设备名称"] + "'  and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='机械标准件' ";

                dt.Rows[i]["机械标准件数量"] = SQLhelp.ExecuteScalar(sql15, CommandType.Text).ToString();


                string sql16 = "select count(*) from tb_caigouliaodan where 工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "' and 设备名称='" + dt.Rows[i]["设备名称"] + "'  and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='机械标准件' and  当前状态='9已到货' ";

                dt.Rows[i]["机械标准件完成数量"] = SQLhelp.ExecuteScalar(sql16, CommandType.Text).ToString();

                string sql17 = "select count(*) from tb_caigouliaodan where 工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "'  and 设备名称='" + dt.Rows[i]["设备名称"] + "' and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='电气标准件'  ";

                dt.Rows[i]["电气标准件数量"] = SQLhelp.ExecuteScalar(sql17, CommandType.Text).ToString();

                string sql18 = "select count(*) from tb_caigouliaodan where 工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "'  and 设备名称='" + dt.Rows[i]["设备名称"] + "' and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='电气标准件' and  当前状态='9已到货' ";

                dt.Rows[i]["电气标准件完成数量"] = SQLhelp.ExecuteScalar(sql18, CommandType.Text).ToString();

            }

            gridControl1.DataSource = dt;
        }

       

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            Frhetongliaodan form1 = new Frhetongliaodan();
            form1.hetonghao = txthetonghao.Text.Trim();
            form1.ShowDialog();
        }

        private void gridView4_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }


        }

        private void gridView4_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }


        }

        private void 查看料单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string gongzuolinghao = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "工作令号"));
            string shebeimingcheng = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "设备名称"));

            string xiangmumingcheng = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "项目名称"));
            string shijian = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "时间"));
            FrShengchanbuzongliaodan form1 = new FrShengchanbuzongliaodan();
            form1.gongzuolinghao = gongzuolinghao;
            form1.xiangmumingcheng = xiangmumingcheng;
            form1.shebeimingcheng=shebeimingcheng;
            form1.shijian = shijian;
            form1.ShowDialog();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DateTime a= Convert.ToDateTime( dateEdit1.Text);

            var firstDayOfMonth = new DateTime(a.Year, a.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);


            string sql = "select id,工作令号,项目名称,设备名称,数量,生产部确认时间,计划完成时间,时间,图纸下达时间 from tb_jishubumen where 制造类型='自制' and 是否提交=1 and 技术部通过=1  and 生产部确认=1 and 图纸下达时间>= '"+ firstDayOfMonth + "'  and  图纸下达时间<= '" + lastDayOfMonth + "'";
            dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            dt.Columns.Add("自制图纸数量");
            dt.Columns.Add("图纸完成数量");
            dt.Columns.Add("外协图纸数量");
            dt.Columns.Add("外协图纸完成数量");
            dt.Columns.Add("机械标准件数量");
            dt.Columns.Add("机械标准件完成数量");
            dt.Columns.Add("电气标准件数量");
            dt.Columns.Add("电气标准件完成数量");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string sql1 = "select count(*) from tb_caigouliaodan where 工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "'  and 设备名称='" + dt.Rows[i]["设备名称"] + "' and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='自制零部件' ";

                dt.Rows[i]["自制图纸数量"] = SQLhelp.ExecuteScalar(sql1, CommandType.Text).ToString();

                string sql12 = "select count(*) from tb_caigouliaodan where 工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "'  and 设备名称='" + dt.Rows[i]["设备名称"] + "' and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='自制零部件' and 生产部确认=1";

                dt.Rows[i]["图纸完成数量"] = SQLhelp.ExecuteScalar(sql12, CommandType.Text).ToString();

                string sql13 = "select count(*) from tb_caigouliaodan where 工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "'  and 设备名称='" + dt.Rows[i]["设备名称"] + "' and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='外协零部件' ";

                dt.Rows[i]["外协图纸数量"] = SQLhelp.ExecuteScalar(sql13, CommandType.Text).ToString();

                string sql14 = "select count(*) from tb_caigouliaodan where (工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "'  and 设备名称='" + dt.Rows[i]["设备名称"] + "' and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='外协零部件'  and  当前状态='9已到货')or (工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "'  and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='外协零部件'  and  当前状态='10已出库')";

                dt.Rows[i]["外协图纸完成数量"] = SQLhelp.ExecuteScalar(sql14, CommandType.Text).ToString();

                string sql15 = "select count(*) from tb_caigouliaodan where 工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "'  and 设备名称='" + dt.Rows[i]["设备名称"] + "' and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='机械标准件' ";

                dt.Rows[i]["机械标准件数量"] = SQLhelp.ExecuteScalar(sql15, CommandType.Text).ToString();


                string sql16 = "select count(*) from tb_caigouliaodan where ( 工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "' and 设备名称='" + dt.Rows[i]["设备名称"] + "'  and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='机械标准件' and  当前状态='9已到货')or (工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "'  and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='机械标准件'  and  当前状态='10已出库') ";

                dt.Rows[i]["机械标准件完成数量"] = SQLhelp.ExecuteScalar(sql16, CommandType.Text).ToString();

                string sql17 = "select count(*) from tb_caigouliaodan where 工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "' and 设备名称='" + dt.Rows[i]["设备名称"] + "'  and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='电气标准件'  ";

                dt.Rows[i]["电气标准件数量"] = SQLhelp.ExecuteScalar(sql17, CommandType.Text).ToString();

                string sql18 = "select count(*) from tb_caigouliaodan where (工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "'  and 设备名称='" + dt.Rows[i]["设备名称"] + "' and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='电气标准件' and  当前状态='9已到货') or (工作令号='" + dt.Rows[i]["工作令号"] + "' and 项目名称='" + dt.Rows[i]["项目名称"] + "'  and  时间='" + dt.Rows[i]["时间"] + "' and 制造类型='电气标准件'  and  当前状态='10已出库')";

                dt.Rows[i]["电气标准件完成数量"] = SQLhelp.ExecuteScalar(sql18, CommandType.Text).ToString();


            }
            gridControl2.DataSource = dt;
            gridView2.Columns["id"].Visible = false;
            gridView2.Columns["时间"].Visible = false;
            gridView2.Columns["生产部确认时间"].Caption = "下发任务时间";


            string sql111 = "select  count(*) from tb_jishubumen where 制造类型='自制' and 是否提交=1 and 技术部通过=1  and 生产部确认=1 and 图纸下达时间>= '" + firstDayOfMonth + "'  and  图纸下达时间<= '" + lastDayOfMonth + "'  and 图纸下达时间 is not null and 生产部确认时间 is not null";

             int shuliang=Convert.ToInt32( SQLhelp.ExecuteScalar(sql111, CommandType.Text));

            string sql1111 = "select  生产部确认时间,计划完成时间,时间,图纸下达时间 from tb_jishubumen where 制造类型='自制' and 是否提交=1 and 技术部通过=1  and 生产部确认=1 and 图纸下达时间>= '" + firstDayOfMonth + "'  and  图纸下达时间<= '" + lastDayOfMonth + "' and 图纸下达时间 is not null and 生产部确认时间 is not null";
            DataTable jisuan = SQLhelp.GetDataTable(sql1111, CommandType.Text);
            int hegeshulaing = 0;
            for(int i=0;i<jisuan.Rows.Count;i++)
            {
                DateTime kaishi = Convert.ToDateTime(jisuan.Rows[i]["图纸下达时间"]);
                DateTime jieshu = Convert.ToDateTime(jisuan.Rows[i]["生产部确认时间"]);
                TimeSpan aa = jieshu - kaishi;
                int aaa = aa.Days;
                if (aaa<=3)
                {
                    hegeshulaing += 1;

                }
            }
            double zuizhong = (hegeshulaing * 100) / shuliang ;
            label1.Text = "及时率是" + zuizhong+"%";

        }

        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }
    }
}

