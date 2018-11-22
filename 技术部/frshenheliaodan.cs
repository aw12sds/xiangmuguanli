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

namespace 项目管理系统.技术部
{
    public partial class frshenheliaodan : Office2007Form
    {
        public frshenheliaodan()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }
        public string gonglinghao;
        public string xiangmu;
        public string shebei;
        public DataTable dt;
        public string shijian;
        public string shuliang11;
        public int a;
        public string name;
        private void frshenheliaodan_Load(object sender, EventArgs e)
        {
            string sql1 = "select  id,工作令号,项目名称,时间,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,附件名称,实际采购数量 from  tb_caigouliaodan  where 工作令号='" + gonglinghao + "' and 项目名称='" + xiangmu + "'and 时间='" + shijian + "'";
            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
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
            if (CIndex == 16)
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
    }
}
