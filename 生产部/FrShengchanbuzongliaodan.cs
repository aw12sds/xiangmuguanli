using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 项目管理系统.档案室;

namespace 项目管理系统.生产部
{
    public partial class FrShengchanbuzongliaodan : Office2007Form
    {
        public FrShengchanbuzongliaodan()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }

        public string gongzuolinghao;
        public string xiangmumingcheng;
        public string shijian;
        public string shebeimingcheng;
        DataTable dt;
        private void FrShengchanbuzongliaodan_Load(object sender, EventArgs e)
        {

            string sql1 = "select id,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,生产部确认,生产部确认时间,当前状态,实际采购数量,附件名称,加工预计结束时间,附件类型 from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "' and 时间='" + shijian + "'";
             dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            dataGridViewX2.DataSource = dt;

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

        private void dataGridViewX2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int CIndex = e.ColumnIndex;
            //按钮所在列为第五列，列下标从0开始的  
            if (CIndex == 20)
            {
                if (dataGridViewX2.CurrentRow.Cells["id"].Value == null)
                {

                    MessageBox.Show("没有附件！");
                    return;
                }
                if (dataGridViewX2.CurrentRow.Cells["id"].Value != null)
                {
                    string id = dataGridViewX2.CurrentRow.Cells["id"].Value.ToString();

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

        private void 导出所有附件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog lujingg = new FolderBrowserDialog();
            if (lujingg.ShowDialog() == DialogResult.OK)
            {
                string xuanzelujing = lujingg.SelectedPath;
                for (int i = 0; i < dataGridViewX2.Rows.Count; i++)
                {

                    string mingcheng = Convert.ToString(dataGridViewX2.Rows[i].Cells["附件名称"].Value.ToString());
                    string id = Convert.ToString(dataGridViewX2.Rows[i].Cells["id"].Value.ToString());
                    if (mingcheng != "")
                    {
                        string leixing = dataGridViewX2.Rows[i].Cells["附件类型"].Value.ToString();
                        byte[] mypdffile = null;
                        string ConStr = "Select 附件 From tb_caigouliaodan Where id='" + id + "'";
                        mypdffile = SQLhelp.duqu(ConStr, CommandType.Text);
                        string bbbb = mingcheng.Replace("?", "1");
                        string lujing = xuanzelujing + "\\" + bbbb + "." + leixing;
                        FileStream fs = new FileStream(lujing, FileMode.Create);
                        fs.Write(mypdffile, 0, mypdffile.Length);
                        fs.Flush();
                        fs.Close();
                    }
                }
                MessageBox.Show("下载成功");//显示异常信息
            }
        }

      
    }
}
