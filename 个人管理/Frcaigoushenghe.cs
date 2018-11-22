using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;

namespace 项目管理系统.个人管理
{
    public partial class Frcaigoushenghe : DevExpress.XtraEditors.XtraForm
    {
        public Frcaigoushenghe()
        {
            InitializeComponent();
        }
        public string yonghu;
        private void Frcaigoushenghe_Load(object sender, EventArgs e)
        {
            refresh();
        }
        public void refresh()
        {
            reload();
            reload1();
            reload2();
            reload3();
            reload4();
            reload5();
        }
        public void reload()
        {
            string sql = "select * from tb_caigouliaodan where 料单类型 not in ('模具部','模具部原材料','五金辅材','项目','机修件','原材料')  and 制造类型='固定资产采购' and 流程状态 is null order by 收到料单日期 desc";
            gridControl1.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
        }
        public void reload1()
        {
            string sql = "select * from tb_caigouliaodan where 料单类型 not in ('模具部','模具部原材料','五金辅材','项目','机修件','原材料') and 流程状态 in ('同意','驳回') and 制造类型='日常采购' order by 收到料单日期 desc";
            gridControl4.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
        }
        public void reload2()
        {
            string sql = "select * from tb_caigouliaodan where 料单类型 not in ('模具部','模具部原材料','五金辅材','项目','机修件','原材料') and 流程状态 in ('同意','驳回') and 制造类型='固定资产采购' order by 收到料单日期 desc";
            gridControl2.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
        }
        public void reload3()
        {
            string sql = "select * from tb_caigouliaodan where 料单类型 not in ('模具部','模具部原材料','五金辅材','项目','机修件','原材料') and 流程状态 is null and 制造类型='日常采购' order by 收到料单日期 desc";
            gridControl3.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
        }
        public void reload4()
        {
            string sql = "select * from tb_caigouliaodan where 流程状态 is null and 采购类型='五金辅材' order by 收到料单日期 desc";
            gridControl5.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
        }
        public void reload5()
        {
            string sql = "select  top 30 * from tb_caigouliaodan where 流程状态 in ('同意','驳回') and 采购类型='五金辅材' order by 收到料单日期 desc";
            gridControl6.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
        }
        private void 同意ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
            string sql1 = "update tb_caigouliaodan  set 流程状态='同意' where id='" + id + "'";
            SQLhelp.ExecuteScalar(sql1, CommandType.Text);
            refresh();
            MessageBox.Show("审批成功！");

        }

        private void 驳回ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
            驳回原因 驳回原因 = new 驳回原因(id);
            驳回原因.ShowDialog();
            if (驳回原因.DialogResult == DialogResult.OK)
            {
                refresh();
            }

        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }

        private void 查看那附件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string a = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "附件名称"));
            if (a.Trim()=="")
            {
                MessageBox.Show("没有附件！");
                return;
            }
            if (a.Trim() != "")
            {
                string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));


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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string id = this.gridView5.GetRowCellValue(this.gridView5.FocusedRowHandle, "id").ToString();
            string sql1 = "update tb_caigouliaodan  set 流程状态='同意' where id='" + id + "'";
            SQLhelp.ExecuteScalar(sql1, CommandType.Text);
            refresh();
            MessageBox.Show("审批成功！");
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

            string id = this.gridView5.GetRowCellValue(this.gridView5.FocusedRowHandle, "id").ToString();
            驳回原因 驳回原因 = new 驳回原因(id);
            驳回原因.ShowDialog();
            if (驳回原因.DialogResult == DialogResult.OK)
            {
                refresh();
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            string a = Convert.ToString(this.gridView5.GetRowCellValue(this.gridView5.FocusedRowHandle, "附件名称"));
            if (a.Trim() == "")
            {
                MessageBox.Show("没有附件！");
                return;
            }
            if (a.Trim() != "")
            {
                string id = Convert.ToString(this.gridView5.GetRowCellValue(this.gridView5.FocusedRowHandle, "id"));


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

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            int[] a = gridView3.GetSelectedRows();

            foreach (int i in a)
            {
                string id = Convert.ToString(gridView3.GetRowCellValue(i, "id"));
                string sql1 = "update tb_caigouliaodan  set 流程状态='同意' where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql1, CommandType.Text);
            }
            refresh();
            MessageBox.Show("审批成功！");
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

            string id = this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "id").ToString();
            驳回原因 驳回原因 = new 驳回原因(id);
            驳回原因.ShowDialog();
            if (驳回原因.DialogResult == DialogResult.OK)
            {

                refresh();
            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            string a = Convert.ToString(this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "附件名称"));
            if (a.Trim() == "")
            {
                MessageBox.Show("没有附件！");
                return;
            }
            if (a.Trim() != "")
            {
                string id = Convert.ToString(this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "id"));


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
    }
}