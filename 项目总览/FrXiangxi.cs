using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 项目管理系统.仓库;

namespace 项目管理系统.项目总览
{
    public partial class FrXiangxi : DevExpress.XtraEditors.XtraForm
    {
        public FrXiangxi()
        {
          
            InitializeComponent();
        }
        public string gongzuolinghao;
        public string xiangmumingcheng;
        public string yonghu;
        public string shijian;
        private void FrXiangxi_Load(object sender, EventArgs e)
        {
            jiagong();
            sheji();
            caigou();
            zhuangpei();        
            gongyi();
        }
       
        public void gongyi()
        {
            string sql1 = "select 工作令号,项目名称,时间,设备名称,设备负责人,制造类型,工艺顺序总数量,工艺顺序未制定数量  from tb_jishubumen  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 图纸下达='1' ";
            gridControl3.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridView3.Columns["时间"].Visible = false;
        }

        public void jiagong()
        {
            string sql1 = "select 工作令号,项目名称,时间,设备名称,设备负责人,制造类型,备料总数量,已备料数量,加工完成进度  from tb_jishubumen  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 图纸下达='1' ";
            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
           gridControl4.DataSource = dt;
            gridView4.Columns["时间"].Visible = false;
        }

        public void sheji()
        {
            string sql1 = "select  工作令号,项目名称,时间,项目负责人,设备负责人,设备名称,图纸下达时间,实际完成时间,制造类型,技术方案考核绩效点,料单考核绩效点,超期天数,完成周期 from tb_jishubumen  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 技术部通过='1'";
            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);        
            gridControl1.DataSource = dt;
            gridView1.Columns["时间"].Visible = false;

        }
        public void caigou()
        {
            string sql1 = "select 工作令号,项目名称,时间,设备名称,设备负责人,物流部完成时间,采购项目负责人,合同考核绩效点,采购项目完成进展 from tb_jishubumen  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 物流部确认='1'";
            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);           
            gridControl2.DataSource = dt;
            gridView2.Columns["时间"].Visible = false;
        }

        public void zhuangpei()
        {
            string sql1 = "select  工作令号,项目名称,设备名称,时间,设备负责人,自制图纸总数量,图纸完成数量,外协图纸总数量,外协图纸完成数量,采购部件总数量,采购部件完成数量 from tb_jishubumen  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 加工确认='1' and 制造类型='自制'";
            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridControl5.DataSource = dt;
            gridView5.Columns["时间"].Visible = false;
            
        }
        
        private void 查看装配反馈ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrZhuangpeixiangqing form = new FrZhuangpeixiangqing();
            form.gongzuolinghao = dataGridViewX4.CurrentRow.Cells["工作令号4"].Value.ToString();
            form.xiangmumingcheng = dataGridViewX4.CurrentRow.Cells["项目名称4"].Value.ToString();
            form.shijian = dataGridViewX4.CurrentRow.Cells["时间4"].Value.ToString();
            form.shebeimingcheng= dataGridViewX4.CurrentRow.Cells["设备名称3"].Value.ToString();
            form.yonghu = yonghu;

            form.ShowDialog();
        }

        private void 查看调试反馈ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrTiaoshixiangqing form = new FrTiaoshixiangqing();
            form.gongzuolinghao = dataGridViewX4.CurrentRow.Cells["工作令号4"].Value.ToString();
            form.xiangmumingcheng = dataGridViewX4.CurrentRow.Cells["项目名称4"].Value.ToString();
            form.shijian = dataGridViewX4.CurrentRow.Cells["时间4"].Value.ToString();
            form.shebeimingcheng = dataGridViewX4.CurrentRow.Cells["设备名称3"].Value.ToString();
            form.yonghu = yonghu;

            form.ShowDialog();
        }
        
        private void 查看到货验收流程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string gonglinghao = dataGridViewX4.CurrentRow.Cells["工作令号4"].Value.ToString();
            string xiangmumingcheng = dataGridViewX4.CurrentRow.Cells["项目名称4"].Value.ToString();
            string shebeimingcheng = dataGridViewX4.CurrentRow.Cells["设备名称3"].Value.ToString();
            string shijian = dataGridViewX4.CurrentRow.Cells["时间4"].Value.ToString();
            string id = dataGridViewX4.CurrentRow.Cells["id4"].Value.ToString();

      
        }
        
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
            {

                string gonglinghao = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号"));
                string xiangmumingcheng = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "项目名称"));

                string shijian = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "时间"));
                FrYanfaxiangqing form = new FrYanfaxiangqing();
                form.gongzuolinghao = gonglinghao;
                form.xiangmumingcheng = xiangmumingcheng;
                form.shijian = shijian;

                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {


                }
            }
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
            {

                string gonglinghao = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "工作令号"));

                string xiangmumingcheng = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "项目名称"));
                string shebeimingcheng = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "设备名称"));
                string shijian = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "时间"));
                FrCaigouxiangqing form = new FrCaigouxiangqing();
                form.gongzuolinghao = gonglinghao;
                form.xiangmumingcheng = xiangmumingcheng;
                form.shijian = shijian;

                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {


                }
            }
        }

        private void gridView3_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
            {

                string gonglinghao = Convert.ToString(this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "工作令号"));

                string xiangmumingcheng = Convert.ToString(this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "项目名称"));

                string shijian = Convert.ToString(this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "时间"));

                Frgongyishunxuliaodan form = new Frgongyishunxuliaodan();
                form.gongzuolinghao = gonglinghao;
                form.xiangmumingcheng = xiangmumingcheng;
                form.shijian = shijian;

                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {


                }
            }
        }

        private void gridView4_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
            {

                string gonglinghao = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "工作令号"));

                string xiangmumingcheng = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "项目名称"));

                string shijian = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "时间"));
                FrJiagongxiangqing form = new FrJiagongxiangqing();
                form.gongzuolinghao = gonglinghao;
                form.xiangmumingcheng = xiangmumingcheng;
                form.shijian = shijian;

                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {


                }
            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }


        }

        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }


        }

        private void gridView3_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }


        }

        private void gridView4_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }


        }

        private void gridView5_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }


        }

        private void gridView5_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
            {

                string gonglinghao = Convert.ToString(this.gridView5.GetRowCellValue(this.gridView5.FocusedRowHandle, "工作令号"));

                string xiangmumingcheng = Convert.ToString(this.gridView5.GetRowCellValue(this.gridView5.FocusedRowHandle, "项目名称"));

                string shijian = Convert.ToString(this.gridView5.GetRowCellValue(this.gridView5.FocusedRowHandle, "时间"));
                string shebeimingcheng = Convert.ToString(this.gridView5.GetRowCellValue(this.gridView5.FocusedRowHandle, "设备名称"));
                Frzonglanzongliaodan form = new Frzonglanzongliaodan();
                form.gongzuolinghao = gonglinghao;
                form.xiangmumingcheng = xiangmumingcheng;
                form.shebeimingcheng = shebeimingcheng;
                form.shijian = shijian;

                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {


                }
            }
        }
    }
}
