using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.物流部
{
    public partial class Frwujinzaifaiqijilu : DevExpress.XtraEditors.XtraForm
    {
        public Frwujinzaifaiqijilu()
        {
            InitializeComponent();
        }
        public string yonghu;
        public string qingdan;
        public DataTable dt;
        private void Frwujinjilu_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = dt;
            gridView1.Columns["id"].Visible = false;
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "物流部发票名称")) == "")
            {
                MessageBox.Show("没有发票！");
                return;
            }
            if (Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "物流部发票名称")) != "")
            {
                string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));

                string sql = "select 物流部发票名称 from tb_daohuojilu where id='" + id + "'";
                string mingcheng = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
                if (mingcheng == "")
                {
                    MessageBox.Show("没有发票！");
                    return;
                }
                string sql2 = "select 物流部发票类型 from tb_daohuojilu where id='" + id + "'";
                string leixing = SQLhelp.ExecuteScalar(sql2, CommandType.Text).ToString();

                byte[] mypdffile = null;

                string sql4 = "Select 物流部发票 From tb_daohuojilu Where id='" + id + "' ";
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

        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "物流部送货单名称")) == "")
            {
                MessageBox.Show("没有送货单！");
                return;
            }
            if (Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "物流部送货单名称")) != "")
            {
                string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));

                string sql = "select 物流部送货单名称 from tb_daohuojilu where id='" + id + "'";
                string mingcheng = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
                if (mingcheng == "")
                {
                    MessageBox.Show("没有送货单！");
                    return;
                }
                string sql2 = "select 物流部送货单类型 from tb_daohuojilu where id='" + id + "'";
                string leixing = SQLhelp.ExecuteScalar(sql2, CommandType.Text).ToString();

                byte[] mypdffile = null;

                string sql4 = "Select 物流部送货单 From tb_daohuojilu Where id='" + id + "' ";
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

        private void repositoryItemButtonEdit3_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "合格证名称")) == "")
            {
                MessageBox.Show("没有合格证！");
                return;
            }
            if (Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "合格证名称")) != "")
            {
                string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));

                string sql = "select 合格证名称 from tb_daohuojilu where id='" + id + "'";
                string mingcheng = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
                if (mingcheng == "")
                {
                    MessageBox.Show("没有合格证！");
                    return;
                }
                string sql2 = "select 合格证类型 from tb_daohuojilu where id='" + id + "'";
                string leixing = SQLhelp.ExecuteScalar(sql2, CommandType.Text).ToString();

                byte[] mypdffile = null;

                string sql4 = "Select 合格证 From tb_daohuojilu Where id='" + id + "' ";
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

        private void repositoryItemButtonEdit6_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();

            dt.Columns.Add("id");
            dt.Columns.Add("工作令号");
            dt.Columns.Add("项目名称");
            dt.Columns.Add("设备名称");
            dt.Columns.Add("供方名称");
            dt.Columns.Add("型号");
            dt.Columns.Add("名称");
            dt.Columns.Add("单位");
            dt.Columns.Add("实际采购数量");
            dt.Columns.Add("到货数量");
            dt.Columns.Add("提交人");
            dt.Columns.Add("提交时间");

            dt1.Columns.Add("id");
            dt1.Columns.Add("工作令号");
            dt1.Columns.Add("项目名称");
            dt1.Columns.Add("设备名称");
            dt1.Columns.Add("供方名称");
            dt1.Columns.Add("型号");
            dt1.Columns.Add("名称");
            dt1.Columns.Add("单位");
            dt1.Columns.Add("实际采购数量");
            dt1.Columns.Add("到货数量");
            dt1.Columns.Add("提交人");
            dt1.Columns.Add("提交时间");

            string[] strArray = qingdan.Split('|'); //字符串转数组
            List<string> list = new List<string>();
            for (int j = 0; j < strArray.Length; j++)//遍历数组成员
            {
                if (list.IndexOf(strArray[j].ToLower()) == -1)//对每个成员做一次新数组查询如果没有相等的则加到新数组
                    list.Add(strArray[j]);
            }
            for (int j = 0; j < list.Count; j++)
            {
                string dingwei = list[j];
                string sql1 = "select  id,工作令号,项目名称,设备名称,供方名称,型号,名称,单位,实际采购数量,到货数量,提交人,提交时间 from  tb_daohuojilu  where 定位 ='" + dingwei + "' ";
                dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                dt1.Merge(dt, true, MissingSchemaAction.Ignore);
            }
            Frpici form = new Frpici();
            form.yonghu = yonghu;
            form.dt = dt1;
            form.ShowDialog();
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
    }
}
