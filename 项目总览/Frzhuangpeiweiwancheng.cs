using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace 项目管理系统.项目总览
{
    public partial class Frzhuangpeiweiwancheng : DevExpress.XtraEditors.XtraForm
    {
        public Frzhuangpeiweiwancheng()
        {
            InitializeComponent();
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
        public string xiangmumingcheng;
        public string gongzuolinghao;

        private void Frzhuangpeiweiwancheng_Load(object sender, EventArgs e)
        {
            string sql1 = "select 工作令号,项目名称,时间,设备名称,设备负责人,装配负责人 from tb_jishubumen  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'  and 技术部通过=1  and 制造类型='自制'  and 加工确认=1 and 装配确认=0  ";
            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridControl1.DataSource = dt;
            gridView1.Columns["时间"].Visible = false;

        }
    }
}