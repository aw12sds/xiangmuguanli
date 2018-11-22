using DevComponents.DotNetBar;
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
    public partial class Frtuzhishenhe : Office2007Form
    {
        public Frtuzhishenhe()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string yonghu;
        private void Frtuzhishenhe_Load(object sender, EventArgs e)
        {

            Reload();
        }

        public void Reload()
        {
            string sql3 = "select id,工作令号,项目名称,设备名称,技术指标,项目负责人,设备负责人,机械负责人,电气负责人,方向,数量,制造类型,设备预计结束时间,时间,技术要求反馈内容 from tb_jishubumen  where 是否提交=1  and 技术部通过=1 and 技术部图纸审核=0  and 项目主管='" + yonghu + "'";
            DataTable liebiao = SQLhelp.GetDataTable(sql3, CommandType.Text);
            dataGridViewX2.DataSource = liebiao;

            
        }

        private void 查看料单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string gonglinghao = dataGridViewX2.CurrentRow.Cells["工作令号"].Value.ToString();
            string xiangmumingcheng = dataGridViewX2.CurrentRow.Cells["项目名称"].Value.ToString();
            string shebeimingcheng = dataGridViewX2.CurrentRow.Cells["设备名称"].Value.ToString();
            string shijian = dataGridViewX2.CurrentRow.Cells["时间"].Value.ToString();
            string shuliang = dataGridViewX2.CurrentRow.Cells["数量"].Value.ToString();
            frshenheliaodan form = new frshenheliaodan();
            form.gonglinghao = gonglinghao;
            form.xiangmu = xiangmumingcheng;
            form.shebei = shebeimingcheng;
            form.shijian = shijian;
            form.shuliang11 = shuliang;
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {


            }
        }

        private void 审核通过ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewX2.Rows.Count <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行");
                return;
            }
            if (MessageBox.Show("确认提交吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string id = dataGridViewX2.CurrentRow.Cells["id"].Value.ToString();
              
                string sql = "update tb_jishubumen set 技术部图纸审核=1,图纸审核=0  where    id='" + id + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);
                MessageBox.Show("通过成功！");
                Reload();
            }
        }

        private void 退回重录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewX2.Rows.Count <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行");
                return;
            }
            if (MessageBox.Show("确认退回吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string id = dataGridViewX2.CurrentRow.Cells["id"].Value.ToString();

                string sql = "update tb_jishubumen set 技术部图纸审核=NULL where    id='" + id + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);
                MessageBox.Show("退回成功！");
                Reload();
            }
        }

        private void dataGridViewX2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
    }
}
