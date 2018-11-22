using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 项目管理系统.物流部;

namespace 项目管理系统.生产部
{
    public partial class Frgongxuwaixie : Office2007Form
    {
        public Frgongxuwaixie()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string yonghu;
        private void Frgongxuwaixie_Load(object sender, EventArgs e)
        {
            Reload();
        }

        public void Reload()
        {

            string sql1 = "select id, 工作令号, 项目名称, 设备名称, 名称, 型号, 实际采购数量, 工序要求, 父id,供方名称,采购料单备注,合同号,实际到货日期 from tb_gonxuwaixieguanli  where 工序外协 = 0";
           gridControl1.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridView1.Columns["id"].Visible = false;
            string sql12 = "select id, 工作令号, 项目名称, 设备名称, 名称, 型号, 实际采购数量, 工序要求, 父id,供方名称,采购料单备注,合同号,实际到货日期 from tb_gonxuwaixieguanli  where 工序外协 = 1";
            gridControl2.DataSource = SQLhelp.GetDataTable(sql12, CommandType.Text);
            gridView2.Columns["id"].Visible = false;
            gridView1.Columns["父id"].Visible = false;
            gridView2.Columns["父id"].Visible = false;

        }
        

        private void 确认完成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认完成吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                int[] a = gridView1.GetSelectedRows();
                foreach (int i in a)
                {
                    string id = this.gridView1.GetRowCellValue(i, "id").ToString();
                    string sql = "update tb_gonxuwaixieguanli set 工序外协=1,工序外协完成时间='" + DateTime.Now + "' where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql, CommandType.Text);
                }
                MessageBox.Show("确认成功！");
                Reload();

            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string id = this.gridView1.GetRowCellValue(i, "id").ToString();
                string gongxuyaoqiu = this.gridView1.GetRowCellValue(i, "工序要求").ToString();
                string shuliang= this.gridView1.GetRowCellValue(i, "实际采购数量").ToString();

                string sql4 = "update tb_gonxuwaixieguanli  set  工序要求='" + gongxuyaoqiu + "',实际采购数量='"+ shuliang +"'  where id='" + id + "' ";
                SQLhelp.ExecuteScalar(sql4, CommandType.Text); 
            }
            MessageBox.Show("保存成功！");
            Reload();

        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
            {
                
                string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();

                string sql = "select 附件名称 from tb_caigouliaodan where id='" + id + "'";
                string mingcheng = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
                if (mingcheng == "")
                {
                    MessageBox.Show("没有附件！");
                    return;
                }

                string sql2 = "select 附件类型 from tb_caigouliaodan where id='" + id + "'";
                string leixing = SQLhelp.ExecuteScalar(sql2, CommandType.Text).ToString();

                byte[] mypdffile = null;

                string sql4 = "Select 附件 From tb_caigouliaodan Where id='" + id + "' ";

                mypdffile = SQLhelp.duqu(sql4, CommandType.Text);
                this.Cursor = Cursors.WaitCursor;

                string aaaa = System.Environment.CurrentDirectory;
                string lujing = aaaa + "\\" + mingcheng + "1" + "." + leixing;
                FileStream fs = new FileStream(lujing, FileMode.Create);
                fs.Write(mypdffile, 0, mypdffile.Length);
                fs.Flush();
                fs.Close();
                this.Cursor = Cursors.Default;
                System.Diagnostics.Process.Start(lujing);
            }
            
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

        }

        private void 查看图纸ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
            string 父id= this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "父id").ToString();
            string sql = "select 附件名称 from tb_caigouliaodan where id='" + 父id + "'";
            string mingcheng = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (mingcheng == "")
            {
                MessageBox.Show("没有附件！");
                return;
            }

            string sql2 = "select 附件类型 from tb_caigouliaodan where id='" + 父id + "'";
            string leixing = SQLhelp.ExecuteScalar(sql2, CommandType.Text).ToString();

            byte[] mypdffile = null;

            string sql4 = "Select 附件 From tb_caigouliaodan Where id='" + 父id + "' ";

            mypdffile = SQLhelp.duqu(sql4, CommandType.Text);
            this.Cursor = Cursors.WaitCursor;

            string aaaa = System.Environment.CurrentDirectory;
            string lujing = aaaa + "\\" + mingcheng + "1" + "." + leixing;
            FileStream fs = new FileStream(lujing, FileMode.Create);
            fs.Write(mypdffile, 0, mypdffile.Length);
            fs.Flush();
            fs.Close();
            this.Cursor = Cursors.Default;
            System.Diagnostics.Process.Start(lujing);
        }

        private void 查看图纸ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string id = this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id").ToString();
            string 父id = this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "父id").ToString();
            string sql = "select 附件名称 from tb_caigouliaodan where id='" + 父id + "'";
            string mingcheng = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (mingcheng == "")
            {
                MessageBox.Show("没有附件！");
                return;
            }

            string sql2 = "select 附件类型 from tb_caigouliaodan where id='" + 父id + "'";
            string leixing = SQLhelp.ExecuteScalar(sql2, CommandType.Text).ToString();

            byte[] mypdffile = null;

            string sql4 = "Select 附件 From tb_caigouliaodan Where id='" + 父id + "' ";

            mypdffile = SQLhelp.duqu(sql4, CommandType.Text);
            this.Cursor = Cursors.WaitCursor;

            string aaaa = System.Environment.CurrentDirectory;
            string lujing = aaaa + "\\" + mingcheng + "1" + "." + leixing;
            FileStream fs = new FileStream(lujing, FileMode.Create);
            fs.Write(mypdffile, 0, mypdffile.Length);
            fs.Flush();
            fs.Close();
            this.Cursor = Cursors.Default;
            System.Diagnostics.Process.Start(lujing);
        }

      

    }
}
