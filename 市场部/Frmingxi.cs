using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.市场部
{
    public partial class Frmingxi : DevExpress.XtraEditors.XtraForm
    {
        public string id;
        public Frmingxi(string id)
        {
            InitializeComponent();
            this.id = id;
        }
        public string lujing;
        private void Frmingxi_Load(object sender, EventArgs e)
        {
            reload();
            string sql = "select * from tb_xiangmu1 where 定位='"+id+"'";
            DataTable dt1 = SQLhelp.GetDataTable(sql, CommandType.Text);
            gridControl1.DataSource = dt1;

            string sql2 = "select * from tb_jishubumen1 where 定位='" + id + "'";
            DataTable dt2 = SQLhelp.GetDataTable(sql2, CommandType.Text);
            gridControl2.DataSource = dt2;

            

        }
        public void reload()
        {
            string sql = "select * from xiangmuzongbiao where id='" + id + "'";
            DataTable dt1 = SQLhelp.GetDataTable(sql, CommandType.Text);
            txtgonglinghao.Text = dt1.Rows[0]["工作令号"].ToString();
            datejiaohuo.Text = dt1.Rows[0]["交货日期"].ToString();
            txtkehumingcheng.Text= dt1.Rows[0]["客户名称"].ToString();
            datesheji2.Text = dt1.Rows[0]["预计设计结束时间"].ToString();
            txtjiagong.Text = dt1.Rows[0]["加工天数"].ToString();
            txttiaoshi.Text = dt1.Rows[0]["调试天数"].ToString();
            txtcaigou.Text = dt1.Rows[0]["采购天数"].ToString();
            txtzhuangpei.Text = dt1.Rows[0]["装配天数"].ToString();
            if (dt1.Rows[0]["维修"].ToString() == "1")
            {
                cheweixiu.Checked = true;
            }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            string sql1 = "select * from tb_xiangmu1 where 定位='" + id + "'";
            DataTable dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);
            string leixing = dt1.Rows[0]["合同类型"].ToString(); 
            string mingcheng = dt1.Rows[0]["合同名称"].ToString();
            string sql = "Select 合同 From tb_xiangmu1  Where 定位='" + id + "'";
            byte[] mypdffile = null;
            mypdffile = SQLhelp.duqu(sql, CommandType.Text);


            string aaaa = System.Environment.CurrentDirectory;
            lujing = aaaa + "\\" + mingcheng + "." + leixing;
            FileStream fs = new FileStream(lujing, FileMode.Create);
            fs.Write(mypdffile, 0, mypdffile.Length);
            fs.Flush();
            fs.Close();

            System.Diagnostics.Process.Start(lujing);
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            string sql1 = "select * from tb_xiangmu1 where 定位='" + id + "'";
            DataTable dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);
            string leixing = dt1.Rows[0]["里程碑计划表类型"].ToString();
            string mingcheng = dt1.Rows[0]["里程碑计划表名称"].ToString();
            string sql = "Select 里程碑计划表 From tb_xiangmu1  Where 定位='" + id + "'";
            byte[] mypdffile = null;
            mypdffile = SQLhelp.duqu(sql, CommandType.Text);


            string aaaa = System.Environment.CurrentDirectory;
            lujing = aaaa + "\\" + mingcheng + "." + leixing;
            FileStream fs = new FileStream(lujing, FileMode.Create);
            fs.Write(mypdffile, 0, mypdffile.Length);
            fs.Flush();
            fs.Close();

            System.Diagnostics.Process.Start(lujing);
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            string sql1 = "select * from tb_xiangmu1 where 定位='" + id + "'";
            DataTable dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);
            string leixing = dt1.Rows[0]["生产任务书类型"].ToString();
            string mingcheng = dt1.Rows[0]["生产任务书名称"].ToString();
            string sql = "Select 生产任务书 From tb_xiangmu1  Where 定位='" + id + "'";
            byte[] mypdffile = null;
            mypdffile = SQLhelp.duqu(sql, CommandType.Text);


            string aaaa = System.Environment.CurrentDirectory;
            lujing = aaaa + "\\" + mingcheng + "." + leixing;
            FileStream fs = new FileStream(lujing, FileMode.Create);
            fs.Write(mypdffile, 0, mypdffile.Length);
            fs.Flush();
            fs.Close();

            System.Diagnostics.Process.Start(lujing);
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {

        }
    }
}
