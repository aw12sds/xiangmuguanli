using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace 项目管理系统.市场部
{
    public partial class FrXiangmuguanli2 : DevExpress.XtraEditors.XtraForm
    {
        public FrXiangmuguanli2()
        {
            InitializeComponent();
        }
        public string yonghu;
        public void Reload()
        {
                string sql = "select id,工作令号,交货日期,预计设计开始时间,预计设计结束时间,预计加工开始时间,预计加工结束时间,预计采购开始时间,预计采购结束时间,预计装配开始时间,预计装配结束时间,预计调试开始时间,预计调试结束时间,合同名称,合同类型,里程碑计划表名称,里程碑计划表类型,加工天数,采购天数,装配天数,调试天数,状态,营销组 from xiangmuzongbiao  order by 预计设计开始时间 desc";
                DataTable jieguo = SQLhelp.GetDataTable(sql, CommandType.Text);
                gridControl1.DataSource = jieguo;

            
            gridView1.Columns["id"].Visible = false;

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void FrXiangmuguanli2_Load(object sender, EventArgs e)
        {
            Reload();
        }
    }
}