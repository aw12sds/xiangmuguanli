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

namespace 项目管理系统.我的任务
{
    public partial class FrJinzhantixing : Office2007Form
    {
        public FrJinzhantixing()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string yonghu;
        private void FrJinzhantixing_Load(object sender, EventArgs e)
        {
            Reload();

        }
        public void Reload()
        {
            if (yonghu == "徐魏魏")
            {
                string sql3 = "select id,工作令号,项目名称,设备名称,技术指标,项目负责人,设备负责人,机械负责人,电气负责人,项目主管,方向,数量,制造类型,设备预计结束时间,时间,技术要求反馈内容,附件名称 from tb_jishubumen  where 是否提交=1  and 技术部通过=0  and 项目主管!='袁鹏' and 项目主管!='刘国庆'";
                DataTable liebiao = SQLhelp.GetDataTable(sql3, CommandType.Text);               
                gridControl1.DataSource = liebiao;
                gridView1.Columns["id"].Visible = false;
            }
            if (yonghu == "刘国庆")
            {
                string sql3 = "select id,工作令号,项目名称,设备名称,技术指标,项目负责人,设备负责人,机械负责人,电气负责人,项目主管,方向,数量,制造类型,设备预计结束时间,时间,技术要求反馈内容,附件名称 from tb_jishubumen  where 是否提交=1  and 技术部通过=0  and 项目主管='刘国庆'";
                DataTable liebiao = SQLhelp.GetDataTable(sql3, CommandType.Text);            
                gridControl1.DataSource = liebiao;
                gridView1.Columns["id"].Visible = false;
            }
            if (yonghu == "袁鹏")
            {
                string sql3 = "select id,工作令号,项目名称,设备名称,技术指标,项目负责人,设备负责人,机械负责人,电气负责人,项目主管,方向,数量,制造类型,设备预计结束时间,时间,技术要求反馈内容,附件名称 from tb_jishubumen  where 是否提交=1  and 技术部通过=0  and 项目主管='袁鹏' ";
                DataTable liebiao = SQLhelp.GetDataTable(sql3, CommandType.Text);              
                gridControl1.DataSource = liebiao;
                gridView1.Columns["id"].Visible = false;
            }
            if (yonghu == "吴贞国")
            {
                string sql3 = "select id,工作令号,项目名称,设备名称,技术指标,项目负责人,设备负责人,机械负责人,电气负责人,项目主管,方向,数量,制造类型,设备预计结束时间,时间,技术要求反馈内容,附件名称 from tb_jishubumen  where 是否提交=1  and 技术部通过=0  and 项目主管='吴贞国' ";
                DataTable liebiao = SQLhelp.GetDataTable(sql3, CommandType.Text);
                gridControl1.DataSource = liebiao;
                gridView1.Columns["id"].Visible = false;
            }
            if (yonghu != "袁鹏" && yonghu != "刘国庆" && yonghu != "徐魏魏")
            {
                string sql3 = "select id,工作令号,项目名称,设备名称,技术指标,项目负责人,设备负责人,机械负责人,电气负责人,项目主管,方向,数量,制造类型,设备预计结束时间,时间,技术要求反馈内容,附件名称 from tb_jishubumen  where 是否提交=1  and 技术部通过=0  and 项目主管!='袁鹏' and 项目主管!='刘国庆'";
                DataTable liebiao = SQLhelp.GetDataTable(sql3, CommandType.Text);             
                gridControl1.DataSource = liebiao;
                gridView1.Columns["id"].Visible = false;
            }

        }

        private void 审核通过ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行");
                return;
            }
            if (yonghu != "袁鹏" && yonghu != "刘国庆" && yonghu != "徐魏魏" && yonghu != "吴贞国")
            {
                MessageBox.Show("无权限！");          
                return;
            }
                if (MessageBox.Show("确认提交吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
                string gongzuolinghao = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号"));
                string xiangmumingcheng = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "项目名称"));
                string shijian = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "时间"));
                string sql1 = "select 预计设计开始时间 from tb_xiangmu where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'";
                DateTime panduan = Convert.ToDateTime(SQLhelp.ExecuteScalar(sql1, CommandType.Text));
                DateTime panduan1 = panduan.AddDays(7);
                if (panduan1 < DateTime.Now)
                {
                    TimeSpan  a= DateTime.Now - panduan1;
                    int b =Convert.ToInt32( a.TotalDays)+1;
                    int c = b * 2;
                    string dangqianshijian = DateTime.Now.ToString();
                    string sql = "update tb_jishubumen set 技术部通过=1 ,实际完成时间='" + dangqianshijian + "' ,技术方案考核绩效点='"+c+"'   where   id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql, CommandType.Text);
                    MessageBox.Show("确认成功！");
                    Reload();
                }
                if (panduan1 > DateTime.Now)
                {
                    string dangqianshijian = DateTime.Now.ToString();
                    string sql = "update tb_jishubumen set 技术部通过=1 ,实际完成时间='" + dangqianshijian + "' ,技术方案考核绩效点=0   where   id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql, CommandType.Text);
                    MessageBox.Show("确认成功！");
                    Reload();
                }
            }
                
        }
        private void 退回重改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行");
                return;
            }
            if (yonghu != "袁鹏" && yonghu != "刘国庆" && yonghu != "徐魏魏")
            {
                MessageBox.Show("无权限！");
                return;
            }
            if (MessageBox.Show("确认退回吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));

                string sql = "update tb_jishubumen set 是否提交=0  where   id='" + id + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);
                MessageBox.Show("退回成功！");
                Reload();
            }
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            string sql = "select id,工作令号,项目名称,设备名称,数量,方向,技术部通过 from tb_jishubumen where   工作令号 like '%" + txtgonglinghao.Text.Trim() + "%'";

            gridControl2.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
            gridView2.Columns["id"].Visible = false;
        }

        private void dataGridViewX1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex < 0 && e.RowIndex >= 0)
            {
                e.Paint(e.ClipBounds, DataGridViewPaintParts.All);
                Rectangle rectangle = e.CellBounds;
                rectangle.Inflate(-2, -2);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.CellStyle.Font, rectangle, e.CellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
                e.Handled = true;
            }
        }
        
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void 反馈ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行");
                return;
            }
            FrFankuixiangxi form = new FrFankuixiangxi();
            form.gongzuolinghao = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号"));
            form.xiangmumingcheng = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "项目名称"));
            form.shijian = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "时间"));
            form.shebeimingcheng = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "设备名称"));
            form.yonghu = yonghu;

            form.ShowDialog();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
            {

                string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));

                string sql = "select 附件名称 from tb_jishubumen where id='" + id + "'";
                string mingcheng = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
                if (mingcheng == "")
                {
                    MessageBox.Show("没有附件！");
                    return;
                }

                string sql2 = "select 附件类型 from tb_jishubumen where id='" + id + "'";
                string leixing = SQLhelp.ExecuteScalar(sql2, CommandType.Text).ToString();

                byte[] mypdffile = null;

                string sql4 = "Select 附件 From tb_jishubumen Where id='" + id + "' ";

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

        private void 查看附件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));

            string sql = "select 附件名称 from tb_jishubumen where id='" + id + "'";
            string mingcheng = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (mingcheng == "")
            {
                MessageBox.Show("没有附件！");
                return;
            }

            string sql2 = "select 附件类型 from  tb_jishubumen where id='" + id + "'";
            string leixing = SQLhelp.ExecuteScalar(sql2, CommandType.Text).ToString();

            byte[] mypdffile = null;

            string sql4 = "Select 附件 From tb_jishubumen Where id='" + id + "' ";

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

        private void 批量审核通过ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] aa = gridView1.GetSelectedRows();
            if (yonghu != "袁鹏" && yonghu != "刘国庆" && yonghu != "徐魏魏")
            {
                MessageBox.Show("无权限！");
                return;
            }
            if (MessageBox.Show("确认提交吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                foreach (int i in aa)
                {
                    string id = gridView1.GetRowCellValue(i, "id").ToString();

                    string gongzuolinghao = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号"));
                    string xiangmumingcheng = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "项目名称"));
                    string shijian = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "时间"));
                    string sql1 = "select 预计设计开始时间 from tb_xiangmu where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'";
                    DateTime panduan = Convert.ToDateTime(SQLhelp.ExecuteScalar(sql1, CommandType.Text));
                    DateTime panduan1 = panduan.AddDays(7);
                    if (panduan1 < DateTime.Now)
                    {
                        TimeSpan a = DateTime.Now - panduan1;
                        int b = Convert.ToInt32(a.TotalDays) + 1;
                        int c = b * 2;
                        string dangqianshijian = DateTime.Now.ToString();
                        string sql = "update tb_jishubumen set 技术部通过=1 ,实际完成时间='" + dangqianshijian + "' ,技术方案考核绩效点='" + c + "'   where   id='" + id + "'";
                        SQLhelp.ExecuteScalar(sql, CommandType.Text);
                    }
                    if (panduan1 > DateTime.Now)
                    {
                        string dangqianshijian = DateTime.Now.ToString();
                        string sql = "update tb_jishubumen set 技术部通过=1 ,实际完成时间='" + dangqianshijian + "' ,技术方案考核绩效点=0   where   id='" + id + "'";
                        SQLhelp.ExecuteScalar(sql, CommandType.Text);
                    }
                }
            }

            MessageBox.Show("确认成功！");
            Reload();
        }
    }
}
