using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace 项目管理系统.财务部
{
    public partial class Frwuliaobiao : DevExpress.XtraEditors.XtraForm
    {
        public Frwuliaobiao()
        {
            InitializeComponent();
        }
        public string yonghu;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (dateTimeInput6.Text == "")
            {
                MessageBox.Show("请输入开始时间！");
                return;
            }
            if (dateTimeInput5.Text == "")
            {
                MessageBox.Show("请输入结束时间！");
                return;
            }
            if (dateTimeInput5.Value < dateTimeInput6.Value)
            {
                MessageBox.Show("开始时间不得大于结束时间");
                return;
            }
            string kaishi = dateTimeInput6.Value.ToString("yyyy-MM-dd 00:00:00");
            string jieshu = dateTimeInput5.Value.ToString("yyyy-MM-dd 23:59:59");



            string sql = "select distinct 设备划分,工作令号,项目名称 from tb_chuku where 出库时间>'" + kaishi + "' and 出库时间<'" + jieshu + "' and 设备划分 is not null";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

            DataTable biaoge = new DataTable();
            biaoge.Columns.Add("工作令号");
            biaoge.Columns.Add("项目名称");
            biaoge.Columns.Add("设备名称");
            biaoge.Columns.Add("金额", typeof(double));
            biaoge.Columns.Add("性质");

            for (int i = 0; i < dt.Rows.Count; i++)//遍历数组成员
            {
                biaoge.Rows.Add();
                string sql1 = "select * from tb_chuku where  出库时间>'" + kaishi + "' and 出库时间<'" + jieshu + "' and 设备划分='" + dt.Rows[i]["设备划分"].ToString() + "'  and 工作令号='" + dt.Rows[i]["工作令号"].ToString() + "' and 项目名称='" + dt.Rows[i]["项目名称"].ToString() + "'";
                DataTable dtt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                double jine = 0;
                for (int j = 0; j < dtt.Rows.Count; j++)//遍历数组成员
                {
                    jine += Convert.ToDouble(dtt.Rows[j]["净额"]);
                }
                biaoge.Rows[i]["工作令号"] = dt.Rows[i]["工作令号"].ToString();
                biaoge.Rows[i]["项目名称"] = dt.Rows[i]["项目名称"].ToString();
                biaoge.Rows[i]["设备名称"] = dt.Rows[i]["设备划分"].ToString();
                biaoge.Rows[i]["金额"] = jine;
            }
            gridControl1.DataSource = biaoge;


        }

        private void 查看明细ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frchukumingxi form1 = new Frchukumingxi();
            form1.gongzuolinghao= Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号"));
            form1.xiangmumingcheng = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "项目名称"));
            form1.shebei = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "设备名称"));
            form1.kaishi = dateTimeInput6.Value.ToString("yyyy-MM-dd 00:00:00");
            form1.jieshu = dateTimeInput5.Value.ToString("yyyy-MM-dd 23:59:59");
            form1.ShowDialog();
        }
    }
}