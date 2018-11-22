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
using 项目管理系统.生产部;

namespace 项目管理系统.仓库
{
    public partial class FrCangku : Office2007Form
    {
        public FrCangku()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string yonghu;





        private void FrCangku_Load(object sender, EventArgs e)
        {
            Reload();
        }

        public void Reload()
        {


            string sql = "select id,工作令号,项目名称,设备名称,数量,时间 from tb_jishubumen where(制造类型='外购' and 是否提交=1 and 技术部通过=1 and 物流部确认=1  and 仓库确认=0 and 到货验收流程 is null) or (制造类型='自制' and 是否提交=1 and 技术部通过=1  and 生产部确认=1 and 物流部确认=1 and 仓库确认=0  ) ";

            dataGridViewX2.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);


            string sql2 = "select id,工作令号,项目名称,设备名称,数量,时间 from tb_jishubumen where(制造类型='外购' and 是否提交=1 and 技术部通过=1 and 物流部确认=1  and 仓库确认=0 and 到货验收流程=1 ) or (制造类型='自制' and 是否提交=1 and 技术部通过=1  and 生产部确认=1 and 物流部确认=1 and 仓库确认=0  and 到货验收流程=1) ";

            dataGridViewX1.DataSource = SQLhelp.GetDataTable(sql2, CommandType.Text);

            string sql1 = "select  id,工作令号,项目名称,设备名称,时间,流程类型,创建人,创建时间,到货验收流程标记,流程状态 from  tb_zongliucheng  where  流程状态='到达仓库' and 流程类型='到货验收流程'";
            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            dataGridViewX3.DataSource = dt;



            string sql3 = "select  id,工作令号,项目名称,设备名称,时间,流程类型,创建人,创建时间,发货确认流程标记,流程状态 from  tb_zongliucheng  where  流程状态='到达仓库' and 流程类型='发货确认流程'";
            DataTable dt1 = SQLhelp.GetDataTable(sql3, CommandType.Text);
            dataGridViewX4.DataSource = dt1;



        }


        private void dataGridViewX2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string gonglinghao = dataGridViewX2.CurrentRow.Cells["工作令号"].Value.ToString();
            string xiangmumingcheng = dataGridViewX2.CurrentRow.Cells["项目名称"].Value.ToString();
            string shebeimingcheng = dataGridViewX2.CurrentRow.Cells["设备名称"].Value.ToString();
            string shijian = dataGridViewX2.CurrentRow.Cells["时间"].Value.ToString();
            string id = dataGridViewX2.CurrentRow.Cells["id"].Value.ToString();

            FrCangkuliaodan form = new FrCangkuliaodan();
            form.gongzuolinghao = gonglinghao;
            form.xiangmumingcheng = xiangmumingcheng;
            form.yonghu = yonghu;
            form.shijian = shijian;
            form.id1 = id;
            form.zhonglei = "待发起";
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {


            }
        }

        private void 确认到货ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认下达吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string gonglinghao = dataGridViewX2.CurrentRow.Cells["工作令号"].Value.ToString();
                string xiangmumingcheng = dataGridViewX2.CurrentRow.Cells["项目名称"].Value.ToString();
                string shebeimingcheng = dataGridViewX2.CurrentRow.Cells["设备名称"].Value.ToString();
                string shijian = dataGridViewX2.CurrentRow.Cells["时间"].Value.ToString();
                string sql = "update tb_jishubumen  set 仓库确认=1 , 仓库完成时间='" + DateTime.Now.ToString() + "'  where 工作令号='" + gonglinghao + "'  and 项目名称='" + xiangmumingcheng + "' and 时间='" + shijian + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);

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

        private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string gonglinghao = dataGridViewX1.CurrentRow.Cells["工作令号2"].Value.ToString();
            string xiangmumingcheng = dataGridViewX1.CurrentRow.Cells["项目名称2"].Value.ToString();
            string shebeimingcheng = dataGridViewX1.CurrentRow.Cells["设备名称2"].Value.ToString();
            string shijian = dataGridViewX1.CurrentRow.Cells["时间2"].Value.ToString();
            string id = dataGridViewX1.CurrentRow.Cells["id2"].Value.ToString();

            FrZongliucheng form = new FrZongliucheng();
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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string gonglinghao = dataGridViewX1.CurrentRow.Cells["工作令号2"].Value.ToString();
            string xiangmumingcheng = dataGridViewX1.CurrentRow.Cells["项目名称2"].Value.ToString();
            string shebeimingcheng = dataGridViewX1.CurrentRow.Cells["设备名称2"].Value.ToString();
            string shijian = dataGridViewX1.CurrentRow.Cells["时间2"].Value.ToString();
            string id = dataGridViewX1.CurrentRow.Cells["id2"].Value.ToString();

            FrCangkuliaodan form = new FrCangkuliaodan();
            form.gongzuolinghao = gonglinghao;
            form.xiangmumingcheng = xiangmumingcheng;
            form.yonghu = yonghu;
            form.shijian = shijian;
            form.id1 = id;
            form.zhonglei = "已发起";
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {


            }
        }

        private void 查看对应料单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.Rows.Count <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }
            string gonglinghao = dataGridViewX3.CurrentRow.Cells["工作令号3"].Value.ToString();
            string xiangmumingcheng = dataGridViewX3.CurrentRow.Cells["项目名称3"].Value.ToString();
            string shebeimingcheng = dataGridViewX3.CurrentRow.Cells["设备名称3"].Value.ToString();
            string shijian = dataGridViewX3.CurrentRow.Cells["时间3"].Value.ToString();
            string id = dataGridViewX3.CurrentRow.Cells["id3"].Value.ToString();
            string liuchengbiaoji = dataGridViewX3.CurrentRow.Cells["到货验收流程标记3"].Value.ToString();



            FrDuiyingliaodan form = new FrDuiyingliaodan();
            form.gongzuolinghao = gonglinghao;
            form.xiangmumingcheng = xiangmumingcheng;
            form.yonghu = yonghu;
            form.shijian = shijian;
            form.id1 = id;
            form.biaoji = liuchengbiaoji;
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {


            }
        }

        private void 处理流程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewX3.Rows.Count <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }


            string gonglinghao = dataGridViewX3.CurrentRow.Cells["工作令号3"].Value.ToString();
            string xiangmumingcheng = dataGridViewX3.CurrentRow.Cells["项目名称3"].Value.ToString();
            string shebeimingcheng = dataGridViewX3.CurrentRow.Cells["设备名称3"].Value.ToString();
            string shijian = dataGridViewX3.CurrentRow.Cells["时间3"].Value.ToString();
            string id = dataGridViewX3.CurrentRow.Cells["id3"].Value.ToString();
            string biaoji = dataGridViewX3.CurrentRow.Cells["到货验收流程标记3"].Value.ToString();
            string liuchengleixing = dataGridViewX3.CurrentRow.Cells["流程类型3"].Value.ToString();
            
           
            DateTime dangqian = DateTime.Now;
            string sql1 = "update tb_caigouliaodan set 仓库确认=1 ,仓库确认时间='" + dangqian + "' ,流程状态='入库'  where 工作令号='" + gonglinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "'  and   制造类型!='自制零部件' and   制造类型!='装配零部件'  and   到货验收流程标记= '" + biaoji + "'";
            SQLhelp.ExecuteScalar(sql1, CommandType.Text);

            string sql2 = "update tb_zongliucheng set 流程状态='归档'   where 工作令号='" + gonglinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "'  and   到货验收流程标记= '" + biaoji + "'";
            SQLhelp.ExecuteScalar(sql2, CommandType.Text);

            string sql3 = "insert into tb_liuchengxiangxi(流程类型,创建人,创建时间,流程标记,工作令号,项目名称,设备名称,时间,流程内容) values('到货验收流程','" + yonghu + "','" + dangqian + "','" + biaoji + "','" + gonglinghao + "','" + xiangmumingcheng + "','" + shebeimingcheng + "','" + shijian + "','入库,流程结束') ";
            SQLhelp.ExecuteScalar(sql3, CommandType.Text);
            MessageBox.Show("归档成功！");
            Reload();
        }
    


        private void dataGridViewX3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewX1.Rows.Count <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }
            string gonglinghao = dataGridViewX3.CurrentRow.Cells["工作令号3"].Value.ToString();
            string xiangmumingcheng = dataGridViewX3.CurrentRow.Cells["项目名称3"].Value.ToString();
            string shebeimingcheng = dataGridViewX3.CurrentRow.Cells["设备名称3"].Value.ToString();
            string shijian = dataGridViewX3.CurrentRow.Cells["时间3"].Value.ToString();
            string id = dataGridViewX3.CurrentRow.Cells["id3"].Value.ToString();
            string biaoji = dataGridViewX3.CurrentRow.Cells["到货验收流程标记3"].Value.ToString();
            string liuchengleixing = dataGridViewX3.CurrentRow.Cells["流程类型3"].Value.ToString();
            FrWuliubuxiangxiliaodan form = new FrWuliubuxiangxiliaodan();
            form.gongzuolinghao = gonglinghao;
            form.xiangmumingcheng = xiangmumingcheng;
            form.yonghu = yonghu;
            form.shijian = shijian;
            form.id1 = id;
            form.biaoji = biaoji;
            form.liuchengleixing = liuchengleixing;

            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {


            }
        }

        private void 查看对应料单ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dataGridViewX2.Rows.Count <= 0)//判断是否选中要删除的行
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

        private void 处理流程ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认入库吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                DateTime huifu = DateTime.Now;

                string gongzuolinghao = dataGridViewX4.CurrentRow.Cells["工作令号4"].Value.ToString();
                string xiangmumingcheng = dataGridViewX4.CurrentRow.Cells["项目名称4"].Value.ToString();
                string shebeimingcheng = dataGridViewX4.CurrentRow.Cells["设备名称4"].Value.ToString();
                string shijian = dataGridViewX4.CurrentRow.Cells["时间4"].Value.ToString();
                string id = dataGridViewX4.CurrentRow.Cells["id4"].Value.ToString();
                string biaoji = dataGridViewX4.CurrentRow.Cells["发货确认流程标记4"].Value.ToString();

                try
                {
                    string sql2 = "insert into tb_liuchengxiangxi(流程类型,创建人,创建时间,流程标记,工作令号,项目名称,设备名称,时间,流程内容) values('发货确认流程','" + yonghu + "','" + huifu + "','" + biaoji + "','" + gongzuolinghao + "','" + xiangmumingcheng + "','" + shebeimingcheng + "','" + shijian + "','物资已入库') ";
                    SQLhelp.ExecuteScalar(sql2, CommandType.Text);
                    
                    string sql4 = "update tb_zongliucheng  set 流程状态='到达质监部'  where id='" + id + "' ";
                    SQLhelp.ExecuteScalar(sql4, CommandType.Text);
                    
                    MessageBox.Show("提交成功！");
                    this.DialogResult = DialogResult.OK;
                    Reload();

                }

                catch (Exception ex)
                {
                    MessageBox.Show( ex.Message);
                }


            }
        }
    }
}
