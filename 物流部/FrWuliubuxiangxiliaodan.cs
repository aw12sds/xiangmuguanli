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

namespace 项目管理系统.物流部
{
    public partial class FrWuliubuxiangxiliaodan : Office2007Form
    {
        public FrWuliubuxiangxiliaodan()
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
        public string biaoji;
        public string liuchengleixing;
        private void FrWuliubuxiangxiliaodan_Load(object sender, EventArgs e)
        {
            string sql1 = "select  id,设备名称,项目名称,工作令号,时间,流程类型,创建人,创建时间,流程内容,附件名称,流程标记,附件类型 from  tb_liuchengxiangxi  where 流程标记='" + biaoji + "' and 工作令号='" + gongzuolinghao + "'and 项目名称='" + xiangmumingcheng + "' and 时间='" + shijian + "' and 流程类型='" + liuchengleixing + "' ";
            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            dataGridViewX1.DataSource = dt;
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
        
        private void 查看附件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.Rows.Count <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }


            string fujiangeshi = dataGridViewX1.CurrentRow.Cells["附件类型"].Value.ToString();

            if (fujiangeshi == "")
            {
                MessageBox.Show("没有附件！");
                return;

            }

            string fujianmingcheng = dataGridViewX1.CurrentRow.Cells["附件名称"].Value.ToString();


            string id = dataGridViewX1.CurrentRow.Cells["id"].Value.ToString();


            string sql = "Select 附件 From tb_liuchengxiangxi  Where id='" + id + "'  ";

            byte[] mypdffile = null;
            mypdffile = SQLhelp.duqu(sql, CommandType.Text);


            string aaaa = System.Environment.CurrentDirectory;
            string lujing = aaaa + "\\" + fujianmingcheng + "." + fujiangeshi;
            FileStream fs = new FileStream(lujing, FileMode.Create);
            fs.Write(mypdffile, 0, mypdffile.Length);
            fs.Flush();
            fs.Close();

            System.Diagnostics.Process.Start(lujing);
        }
    }
}
