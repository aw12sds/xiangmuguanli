using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace 项目管理系统.生产部
{
    public partial class Frgongyichaxun : DevExpress.XtraEditors.XtraForm
    {
        public Frgongyichaxun()
        {
            InitializeComponent();
        }
        public string yonghu;
        public string dingwei;
        public string leixing;
        private void Frgongyichaxun_Load(object sender, EventArgs e)
        {
            DataTable zongbiao = new DataTable();
            zongbiao.Columns.Add("工作令号");
            zongbiao.Columns.Add("项目名称");
            zongbiao.Columns.Add("设备名称");
            zongbiao.Columns.Add("id");
            zongbiao.Columns.Add("图号");
            zongbiao.Columns.Add("名称");
            zongbiao.Columns.Add("数量");
            zongbiao.Columns.Add("工序名称");
            zongbiao.Columns.Add("价格");
            zongbiao.Columns.Add("重量");
            zongbiao.Columns.Add("负责人");
            zongbiao.Columns.Add("登记状态");
            zongbiao.Columns.Add("类型");



            string sql = "select id,工作令号,项目名称,设备名称,图号,名称,数量,工序名称,价格,重量,负责人,登记状态 from db_gongxu1 where 负责人='" + yonghu + "'";
            DataTable dt = sqlhelp1.GetDataTable(sql, CommandType.Text);
            dt.Columns.Add("类型");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["类型"] = "普通";

            }


            zongbiao.Merge(dt, true, MissingSchemaAction.Ignore);

            string sql1 = "select id,接单编号,机修件数量,工件名称,工序名称,价格,重量,负责人,登记状态 from db_gongxu111 where 负责人='" + yonghu + "'";
            DataTable dt1 = sqlhelp1.GetDataTable(sql1, CommandType.Text);
            dt1.Columns["接单编号"].ColumnName = "图号";
            dt1.Columns["机修件数量"].ColumnName = "数量";
            dt1.Columns["工件名称"].ColumnName = "名称";
            dt1.Columns.Add("工作令号");
            dt1.Columns.Add("项目名称");
            dt1.Columns.Add("设备名称");
            dt1.Columns.Add("类型");
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                dt1.Rows[i]["类型"] = "机修";

            }
            zongbiao.Merge(dt1, true, MissingSchemaAction.Ignore);

            gridControl4.DataSource = zongbiao;
            gridView4.Columns["id"].Visible = false;
            gridView4.Columns["类型"].Visible = false;
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
             leixing = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "类型"));
                string id = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id"));
                if (leixing == "普通")
                {
                    if (MessageBox.Show("确认添加该行吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        string sql = "update db_gongxu1 set 登记='已登记' where id='" + id + "'";
                        sqlhelp1.ExecuteScalar(sql, CommandType.Text);
                        dingwei = id;
                      
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        
                    }
                }
                if (leixing == "机修")
                {
                    if (MessageBox.Show("确认添加该行吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        string sql = "update db_gongxu111 set 登记='已登记' where id='" + id + "'";
                        sqlhelp1.ExecuteScalar(sql, CommandType.Text);
                        dingwei = id;
                        
                        this.DialogResult = DialogResult.OK;
                        this.Close();

                    }
                }
            }

        }
    }
}