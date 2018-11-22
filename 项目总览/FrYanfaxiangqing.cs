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
using xiangmuguanli.技术部;

namespace 项目管理系统.项目总览
{
    public partial class FrYanfaxiangqing : Office2007Form
    {
        public FrYanfaxiangqing()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
            fpro = new FrJindutiao();
        }
        public string gongzuolinghao;
        public string xiangmumingcheng;
        public string shijian;


        public string xuanzelujing;
        public FrJindutiao fpro = null;
        private void FrYanfaxiangqing_Load(object sender, EventArgs e)
        {
            string sql3 = "select 工作令号,项目名称,设备名称,技术指标,项目负责人,设备负责人,机械负责人,电气负责人,项目主管,方向,数量,制造类型,设备预计结束时间,附件名称,时间 from tb_jishubumen  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "'   ";
            DataTable liebiao = SQLhelp.GetDataTable(sql3, CommandType.Text);
            dataGridViewX2.DataSource = liebiao;


            string sql1 = "select  id,序号,编码,型号,名称,单位,数量,类型,要求到货日期,备注,制造类型,实际采购数量,当前状态 from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "'  ";

            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            dataGridViewX1.DataSource = dt;





        }

        private void dataGridViewX2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int CIndex = e.ColumnIndex;
            //按钮所在列为第五列，列下标从0开始的  
            if (CIndex == 14)
            {
                //获取在同一行第一列的单元格中的字段值  
              string  gonglinghao = dataGridViewX2.CurrentRow.Cells["工作令号"].Value.ToString();
               string  xiangmu = dataGridViewX2.CurrentRow.Cells["项目名称"].Value.ToString();
              
              string  shijian = dataGridViewX2.CurrentRow.Cells["时间"].Value.ToString();

                string sql = "select 附件名称 from tb_jishubumen where 工作令号= '" + gonglinghao + "' and 项目名称= '" + xiangmu + "' and 时间='" + shijian + "'";
                string jiance = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
                if (jiance == "")
                {
                    MessageBox.Show("没有附件！");
                    return;
                }

                FolderBrowserDialog lujingg = new FolderBrowserDialog();

                if (lujingg.ShowDialog() == DialogResult.OK)

                {
                    xuanzelujing = lujingg.SelectedPath;


                    this.backgroundWorker1.RunWorkerAsync();

                    fpro.ShowDialog(this);




                }

            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                byte[] mypdffile = null;
                string ConStr = "Select 附件 From tb_jishubumen where 工作令号= '" + gongzuolinghao + "' and 项目名称= '" + xiangmumingcheng + "' and 时间='" + shijian + "'";
                
                mypdffile = SQLhelp.duqu(ConStr, CommandType.Text);

                string sql1111 = "select 附件名称,附件类型  From tb_jishubumen where 工作令号= '" + gongzuolinghao + "' and 项目名称= '" + xiangmumingcheng + "' and 时间='" + shijian + "'";
                DataTable dttt = SQLhelp.GetDataTable(sql1111, CommandType.Text);
                string mingcheng = dttt.Rows[0]["附件名称"].ToString();
                string leixing = dttt.Rows[0]["附件类型"].ToString();

                string lujing = xuanzelujing + "\\" + mingcheng + "." + leixing;
                FileStream fs = new FileStream(lujing, FileMode.Create);
                fs.Write(mypdffile, 0, mypdffile.Length);
                fs.Flush();
                fs.Close();
                
                MessageBox.Show("下载成功");//显示异常信息
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);//显示异常信息
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            fpro.Close();
        }

        private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

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
    }
}
