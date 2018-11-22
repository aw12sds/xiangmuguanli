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
    public partial class Frshejiweiwancheng : DevExpress.XtraEditors.XtraForm
    {
        public Frshejiweiwancheng()
        {
            InitializeComponent();
        }
        public string xiangmumingcheng;
        public string gongzuolinghao;
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void Frshejiweiwancheng_Load(object sender, EventArgs e)
        {
            string sql1 = "select  工作令号,项目名称,时间,项目负责人,设备负责人,设备名称,制造类型 from tb_jishubumen  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 技术部通过=1  and 图纸下达=0  ";
            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridControl1.DataSource = dt;
            gridView1.Columns["时间"].Visible = false;
        }
    }
}