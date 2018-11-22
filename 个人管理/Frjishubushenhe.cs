using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 项目管理系统.技术部;

namespace 项目管理系统.个人管理
{
    public partial class Frjishubushenhe : Form
    {
        public Frjishubushenhe()
        {
            InitializeComponent();
        }
        public string yonghu;
        public void Reload()
        {
            if (yonghu == "徐魏魏")
            {
                string sql3 = "select id,工作令号,项目名称,设备名称,技术指标,项目负责人,设备负责人,机械负责人,电气负责人,方向,数量,制造类型,设备预计结束时间,时间,技术要求反馈内容 from tb_jishubumen  where 是否提交=1  and 技术部通过=1 and 图纸审核=0 and 项目主管!='袁鹏' and 项目主管!='刘国庆' and 项目主管!='吴贞国'";
                DataTable liebiao = SQLhelp.GetDataTable(sql3, CommandType.Text);
                gridControl1.DataSource = liebiao;
                gridView1.Columns["id"].Visible = false;
            }
            if (yonghu == "蔡红兵")
            {
                string sql3 = "select id,工作令号,项目名称,设备名称,技术指标,项目负责人,设备负责人,机械负责人,电气负责人,方向,数量,制造类型,设备预计结束时间,时间,技术要求反馈内容 from tb_jishubumen  where 是否提交=1  and 技术部通过=1 and 图纸审核=0  and 项目主管!='袁鹏' and 项目主管!='刘国庆'  and 项目主管!='吴贞国'";
                DataTable liebiao = SQLhelp.GetDataTable(sql3, CommandType.Text);
                gridControl1.DataSource = liebiao;
                gridView1.Columns["id"].Visible = false;
            }
            if (yonghu == "袁鹏")
            {
                string sql3 = "select id,工作令号,项目名称,设备名称,技术指标,项目负责人,设备负责人,机械负责人,电气负责人,方向,数量,制造类型,设备预计结束时间,时间,技术要求反馈内容 from tb_jishubumen  where 是否提交=1  and 技术部通过=1 and 图纸审核=0  and 项目主管='袁鹏' and 项目主管!='吴贞国' ";
                DataTable liebiao = SQLhelp.GetDataTable(sql3, CommandType.Text);
                gridControl1.DataSource = liebiao;
                gridView1.Columns["id"].Visible = false;
            }
            if (yonghu == "刘国庆")
            {
                string sql3 = "select id,工作令号,项目名称,设备名称,技术指标,项目负责人,设备负责人,机械负责人,电气负责人,方向,数量,制造类型,设备预计结束时间,时间,技术要求反馈内容 from tb_jishubumen  where 是否提交=1  and 技术部通过=1 and 图纸审核=0  and 项目主管='刘国庆' ";
                DataTable liebiao = SQLhelp.GetDataTable(sql3, CommandType.Text);
               gridControl1.DataSource = liebiao;
                gridView1.Columns["id"].Visible = false;
            }
            if (yonghu == "吴贞国")
            {
                string sql3 = "select id,工作令号,项目名称,设备名称,技术指标,项目负责人,设备负责人,机械负责人,电气负责人,方向,数量,制造类型,设备预计结束时间,时间,技术要求反馈内容 from tb_jishubumen  where 是否提交=1  and 技术部通过=1 and 图纸审核=0  and 项目主管='吴贞国' ";
                DataTable liebiao = SQLhelp.GetDataTable(sql3, CommandType.Text);
                gridControl1.DataSource = liebiao;
                gridView1.Columns["id"].Visible = false;
            }

        }

        private void Frjishubuliaodan_Load(object sender, EventArgs e)
        {
            Reload();
        }

        private void 审核通过ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行");
                return;
            }
            if (MessageBox.Show("确认提交吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));

                string sql = "update tb_jishubumen set 图纸审核=1  where    id='" + id + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);
                MessageBox.Show("通过成功！");
                Reload();
            }
        }

        private void 退回重录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行");
                return;
            }
            if (MessageBox.Show("确认提交吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));

                string sql = "update tb_jishubumen set 图纸审核=NULL,技术部图纸审核=NULL  where    id='" + id + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);
                MessageBox.Show("退回成功！");
                Reload();
            }
        }

        private void 查看料单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string gonglinghao = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号"));
            string xiangmumingcheng = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "项目名称"));
            string shebeimingcheng = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "设备名称"));
            string shijian = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "时间"));
            string shuliang = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "数量"));
            frshenheliaodan form = new frshenheliaodan();
            form.gonglinghao = gonglinghao;
            form.xiangmu = xiangmumingcheng;
            form.shebei = shebeimingcheng;
            form.shijian = shijian;
            form.shuliang11 = shuliang;
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
