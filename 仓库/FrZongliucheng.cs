using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.仓库
{
    public partial class FrZongliucheng : Office2007Form
    {
        public FrZongliucheng()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string gongzuolinghao;
        public string xiangmumingcheng;
        public string shijian;
        public string yonghu;
        public string panduan;
        public string id1;
        public string zhonglei;
        private void FrZongliucheng_Load(object sender, EventArgs e)
        {
            string sql1 = "select  id,设备名称,项目名称,工作令号,时间,流程类型,创建人,创建时间,到货验收流程标记,流程状态 from  tb_zongliucheng  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "' and 流程类型='到货验收流程' ";
            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            dataGridViewX1.DataSource = dt;
        }

        private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewX1.Rows.Count <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }
            string gonglinghao = dataGridViewX1.CurrentRow.Cells["工作令号"].Value.ToString();
            string xiangmumingcheng = dataGridViewX1.CurrentRow.Cells["项目名称"].Value.ToString();
            string shebeimingcheng = dataGridViewX1.CurrentRow.Cells["设备名称"].Value.ToString();
            string shijian = dataGridViewX1.CurrentRow.Cells["时间"].Value.ToString();
            string id = dataGridViewX1.CurrentRow.Cells["id"].Value.ToString();
            string biaoji = dataGridViewX1.CurrentRow.Cells["到货验收流程标记"].Value.ToString();
            string liuchengleixing = dataGridViewX1.CurrentRow.Cells["流程类型"].Value.ToString();
            Frxiangxiliucheng form = new Frxiangxiliucheng();
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

        private void 入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.Rows.Count <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }
            string liuchengzhuangtai = Convert.ToString(dataGridViewX1.CurrentRow.Cells["流程状态"].Value);
            if (liuchengzhuangtai != "到达仓库")
            {

                MessageBox.Show("没到达仓库，无权入库！");
                return;

            }

            if (liuchengzhuangtai == "到达仓库")
            {
                string biaoji= Convert.ToString(dataGridViewX1.CurrentRow.Cells["到货验收流程标记"].Value);
                string shebeimingcheng= Convert.ToString(dataGridViewX1.CurrentRow.Cells["设备名称"].Value);
                DateTime dangqian = DateTime.Now;
                string sql1 = "update tb_caigouliaodan set 仓库确认=1 ,仓库确认时间='"+dangqian+ "' ,流程状态='入库'  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "'  and   制造类型!='自制零部件' and   制造类型!='装配零部件'  and   到货验收流程标记= '" + biaoji + "'";
                  SQLhelp.ExecuteScalar(sql1, CommandType.Text);

                string sql2 = "update tb_zongliucheng set 流程状态='归档'   where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "'  and   到货验收流程标记= '" + biaoji + "'";
                SQLhelp.ExecuteScalar(sql2, CommandType.Text);

                string sql3= "insert into tb_liuchengxiangxi(流程类型,创建人,创建时间,流程标记,工作令号,项目名称,设备名称,时间,流程内容) values('到货验收流程','" + yonghu + "','" + dangqian + "','" + biaoji + "','" + gongzuolinghao + "','" + xiangmumingcheng + "','" + shebeimingcheng + "','" + shijian + "','入库,流程结束') ";
                SQLhelp.ExecuteScalar(sql3, CommandType.Text);
                
            }
        }

        private void 查看对应料单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.Rows.Count <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }
            string gonglinghao = dataGridViewX1.CurrentRow.Cells["工作令号"].Value.ToString();
            string xiangmumingcheng = dataGridViewX1.CurrentRow.Cells["项目名称"].Value.ToString();
            string shebeimingcheng = dataGridViewX1.CurrentRow.Cells["设备名称"].Value.ToString();
            string shijian = dataGridViewX1.CurrentRow.Cells["时间"].Value.ToString();
            string id = dataGridViewX1.CurrentRow.Cells["id"].Value.ToString();
            string liuchengbiaoji = dataGridViewX1.CurrentRow.Cells["到货验收流程标记"].Value.ToString();
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
    }
}
