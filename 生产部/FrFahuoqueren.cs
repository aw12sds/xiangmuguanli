using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 项目管理系统.仓库;

namespace 项目管理系统.生产部
{
    public partial class FrFahuoqueren : Office2007Form
    {
        public FrFahuoqueren()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string yonghu;
        private void FrFahuoqueren_Load(object sender, EventArgs e)
        {
            Reload();
        }
        public void Reload()
        {

            string sql = "select id,工作令号,项目名称,设备名称,项目主管,数量,时间 from tb_jishubumen where 制造类型='自制' and 仓库确认=1 and 发货确认流程 IS NULL";

           
            dataGridViewX2.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);

            string sql1 = "select id,工作令号,项目名称,设备名称,项目主管,数量,时间 from tb_jishubumen where 制造类型='自制' and 仓库确认=1 and 发货确认流程 =1";

            
            dataGridViewX1.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);


            string sql2 = "select id,工作令号,项目名称,设备名称,项目主管,数量,时间 from tb_jishubumen where 制造类型='自制' and 仓库确认=1 and 发货确认流程 =0";

           
            dataGridViewX3.DataSource = SQLhelp.GetDataTable(sql2, CommandType.Text);

            string sql4 = "select  id,工作令号,项目名称,设备名称,时间,流程类型,创建人,创建时间,发货确认流程标记,流程状态 from  tb_zongliucheng  where  流程状态='到达生产部' and 流程类型='发货确认流程'";
            DataTable dt1 = SQLhelp.GetDataTable(sql4, CommandType.Text);
            dataGridViewX4.DataSource = dt1;

        }

        private void 发起发货确认流程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString();
            string gonglinghao = dataGridViewX2.CurrentRow.Cells["工作令号"].Value.ToString();
            string xiangmumingcheng = dataGridViewX2.CurrentRow.Cells["项目名称"].Value.ToString();
            string shebeimingcheng = dataGridViewX2.CurrentRow.Cells["设备名称"].Value.ToString();
            string shijian = dataGridViewX2.CurrentRow.Cells["时间"].Value.ToString();

            string id = dataGridViewX2.CurrentRow.Cells["id"].Value.ToString();


            string sql111 = "select 项目负责人 from tb_jishubumen where id='" + id + "'";
            string fuzeren = SQLhelp.ExecuteScalar(sql111, CommandType.Text).ToString();

            string sql112 = "select 项目主管 from tb_jishubumen where id='" + id + "'";
            string fuzeren1 = SQLhelp.ExecuteScalar(sql112, CommandType.Text).ToString();

            string sql113 = "select 采购项目负责人 from tb_jishubumen where id='" + id + "'";
            string fuzeren2 = SQLhelp.ExecuteScalar(sql113, CommandType.Text).ToString();

            try
            {

                string sql1 = "insert into tb_zongliucheng(流程类型,创建人,创建时间,发货确认流程标记,工作令号,项目名称,设备名称,时间,流程状态,项目负责人,项目主管,采购项目负责人) values('发货确认流程','" + yonghu + "','" + time + "','" + time + "','" + gonglinghao + "','" + xiangmumingcheng + "','" + shebeimingcheng + "','" + shijian + "','到达技术部','" + fuzeren + "','" + fuzeren1 + "','" + fuzeren2 + "') ";
                SQLhelp.ExecuteScalar(sql1, CommandType.Text);

                string sql2 = "insert into tb_liuchengxiangxi(流程类型,创建人,创建时间,流程标记,工作令号,项目名称,设备名称,时间,流程内容) values('发货确认流程','" + yonghu + "','" + time + "','" + time + "','" + gonglinghao + "','" + xiangmumingcheng + "','" + shebeimingcheng + "','" + shijian + "','已组装完毕，发起发货确认流程') ";
                SQLhelp.ExecuteScalar(sql2, CommandType.Text);


                string sql3 = "update  tb_jishubumen set  发货确认流程=1   where id='" + id + "' ";
                SQLhelp.ExecuteScalar(sql3, CommandType.Text);

                MessageBox.Show("发起成功！");
                Reload();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dataGridViewX2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewX1.Rows.Count <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }
            string gonglinghao = dataGridViewX2.CurrentRow.Cells["工作令号2"].Value.ToString();
            string xiangmumingcheng = dataGridViewX2.CurrentRow.Cells["项目名称2"].Value.ToString();
            string shebeimingcheng = dataGridViewX2.CurrentRow.Cells["设备名称2"].Value.ToString();
            string shijian = dataGridViewX2.CurrentRow.Cells["时间2"].Value.ToString();
            string id = dataGridViewX2.CurrentRow.Cells["id2"].Value.ToString();
            

            FrFahuoquerenliaodan form = new FrFahuoquerenliaodan();
            form.gongzuolinghao = gonglinghao;
            form.xiangmumingcheng = xiangmumingcheng;
            form.yonghu = yonghu;
            form.shijian = shijian;
            form.id1 = id;
           
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {


            }
        }

        private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewX1.Rows.Count <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }
            string gonglinghao = dataGridViewX1.CurrentRow.Cells["工作令号2"].Value.ToString();
            string xiangmumingcheng = dataGridViewX1.CurrentRow.Cells["项目名称2"].Value.ToString();
            string shebeimingcheng = dataGridViewX1.CurrentRow.Cells["设备名称2"].Value.ToString();
            string shijian = dataGridViewX1.CurrentRow.Cells["时间2"].Value.ToString();
            string id = dataGridViewX1.CurrentRow.Cells["id2"].Value.ToString();
           
            FrFahuoquerenliaodan form = new FrFahuoquerenliaodan();
            form.gongzuolinghao = gonglinghao;
            form.xiangmumingcheng = xiangmumingcheng;
            form.yonghu = yonghu;
            form.shijian = shijian;
            form.id1 = id;
            
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {


            }

        }

        private void 查看流程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string gonglinghao = dataGridViewX1.CurrentRow.Cells["工作令号2"].Value.ToString();
            string xiangmumingcheng = dataGridViewX1.CurrentRow.Cells["项目名称2"].Value.ToString();
            string shebeimingcheng = dataGridViewX1.CurrentRow.Cells["设备名称2"].Value.ToString();
            string shijian = dataGridViewX1.CurrentRow.Cells["时间2"].Value.ToString();
            string id = dataGridViewX1.CurrentRow.Cells["id2"].Value.ToString();

            FrFahuoquerenzongliucheng form = new FrFahuoquerenzongliucheng();
            form.gongzuolinghao = gonglinghao;
            form.xiangmumingcheng = xiangmumingcheng;
            form.yonghu = yonghu;
            form.shijian = shijian;
            form.id1 = id;

            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {


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

        private void dataGridViewX3_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void 查看料单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewX4.Rows.Count <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }
            string gonglinghao = dataGridViewX4.CurrentRow.Cells["工作令号4"].Value.ToString();
            string xiangmumingcheng = dataGridViewX4.CurrentRow.Cells["项目名称4"].Value.ToString();
            string shebeimingcheng = dataGridViewX4.CurrentRow.Cells["设备名称4"].Value.ToString();
            string shijian = dataGridViewX4.CurrentRow.Cells["时间4"].Value.ToString();
            string id = dataGridViewX4.CurrentRow.Cells["id4"].Value.ToString();


            FrFahuoquerenliaodan form = new FrFahuoquerenliaodan();
            form.gongzuolinghao = gonglinghao;
            form.xiangmumingcheng = xiangmumingcheng;
            form.yonghu = yonghu;
            form.shijian = shijian;
            form.id1 = id;

            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {


            }
        }

        private void 处理流程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewX4.Rows.Count <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }
            string gonglinghao = dataGridViewX4.CurrentRow.Cells["工作令号4"].Value.ToString();
            string xiangmumingcheng = dataGridViewX4.CurrentRow.Cells["项目名称4"].Value.ToString();
            string shebeimingcheng = dataGridViewX4.CurrentRow.Cells["设备名称4"].Value.ToString();
            string shijian = dataGridViewX4.CurrentRow.Cells["时间4"].Value.ToString();
            string id = dataGridViewX4.CurrentRow.Cells["id4"].Value.ToString();
            string liuchengbiaoji = dataGridViewX4.CurrentRow.Cells["发货确认流程标记4"].Value.ToString();

            FrFahuoquerenfankui form = new FrFahuoquerenfankui();
            form.gongzuolinghao = gonglinghao;
            form.xiangmumingcheng = xiangmumingcheng;
            form.yonghu = yonghu;
            form.shijian = shijian;
            form.id1 = id;
            form.biaoji = liuchengbiaoji;
            form.shebeimingcheng = shebeimingcheng;
           

            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                Reload();

            }

        }

        private void 确认发货ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString();
            string gonglinghao = dataGridViewX1.CurrentRow.Cells["工作令号2"].Value.ToString();
            string xiangmumingcheng = dataGridViewX1.CurrentRow.Cells["项目名称2"].Value.ToString();
            string shebeimingcheng = dataGridViewX1.CurrentRow.Cells["设备名称2"].Value.ToString();
            string shijian = dataGridViewX1.CurrentRow.Cells["时间2"].Value.ToString();

            string id = dataGridViewX1.CurrentRow.Cells["id2"].Value.ToString();
            

            try
            {

                string sql4 = "update tb_zongliucheng  set 流程状态='归档'  where 工作令号='" + gonglinghao + "'  and  项目名称='" + xiangmumingcheng + "' and  时间='" + shijian+ "' ";
                SQLhelp.ExecuteScalar(sql4, CommandType.Text);

                string sql2 = "insert into tb_liuchengxiangxi(流程类型,创建人,创建时间,流程标记,工作令号,项目名称,设备名称,时间,流程内容) values('发货确认流程','" + yonghu + "','" + time + "','" + time + "','" + gonglinghao + "','" + xiangmumingcheng + "','" + shebeimingcheng + "','" + shijian + "','已发货') ";
                SQLhelp.ExecuteScalar(sql2, CommandType.Text);


                string sql3 = "update  tb_jishubumen set  发货确认流程=0   where id='" + id + "' ";
                SQLhelp.ExecuteScalar(sql3, CommandType.Text);

               

                MessageBox.Show("发起成功！");
                Reload();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void dataGridViewX3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void 查看了流程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string gonglinghao = dataGridViewX3.CurrentRow.Cells["工作令号3"].Value.ToString();
            string xiangmumingcheng = dataGridViewX3.CurrentRow.Cells["项目名称3"].Value.ToString();
            string shebeimingcheng = dataGridViewX3.CurrentRow.Cells["设备名称3"].Value.ToString();
            string shijian = dataGridViewX3.CurrentRow.Cells["时间3"].Value.ToString();
            string id = dataGridViewX3.CurrentRow.Cells["id3"].Value.ToString();

            FrFahuoquerenzongliucheng form = new FrFahuoquerenzongliucheng();
            form.gongzuolinghao = gonglinghao;
            form.xiangmumingcheng = xiangmumingcheng;
            form.yonghu = yonghu;
            form.shijian = shijian;
            form.id1 = id;

            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {


            }
        }
    }
}
