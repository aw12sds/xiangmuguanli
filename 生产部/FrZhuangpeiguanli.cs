using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.生产部
{
    public partial class FrZhuangpeiguanli : Office2007Form
    {
        public FrZhuangpeiguanli()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string gongzuolinghao;
        public string xiangmumingcheng;
        public string shebeimingcheng;
        public string shijian;
        public string yonghu;
        private void FrZhuangpeiguanli_Load(object sender, EventArgs e)
        {
            Reload();
        }
        public void Reload()
        {

            string sql = "select id,工作令号,项目名称,设备名称,装配负责人,数量,时间 from tb_jishubumen where 制造类型='自制' and 是否提交=1 and 技术部通过=1  and 生产部确认=1  and 装配确认=0 ";

           gridControl1.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
            gridView1.Columns["id"].Visible = false;
            gridView1.Columns["时间"].Visible = false;

            string sql1 = "select id,工作令号,项目名称,设备名称,装配负责人,数量,时间  from tb_jishubumen where 制造类型='自制' and 是否提交=1 and 技术部通过=1  and 生产部确认=1  and 装配确认=1 ";

            gridControl2.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridView2.Columns["id"].Visible = false;
            gridView2.Columns["时间"].Visible = false;

        }

        private void 确认完成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认下达吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string gonglinghao = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号"));
                string xiangmumingcheng = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "项目名称"));
                string shebeimingcheng = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "设备名称"));
                string shijian = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "时间"));
                string sql = "update tb_jishubumen  set 装配确认=1 , 装配完成时间='" + DateTime.Now.ToString() + "'  where 工作令号='" + gonglinghao + "'  and 项目名称='" + xiangmumingcheng + "' and 时间='" + shijian + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);

                string zhuangpeishijian = DateTime.Now.ToString();
                string sql123456 = "update  tb_xiangmu  set 实际装配结束时间='" + zhuangpeishijian + "' where 工作令号= '" + gonglinghao + "' and 项目名称= '" + xiangmumingcheng + "' ";
                SQLhelp.ExecuteScalar(sql123456, CommandType.Text);

                Reload();
            }
        }
        
        private void 查看料单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string gonglinghao = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号"));
            string xiangmumingcheng = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "项目名称"));
            string shebeimingcheng = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "设备名称"));
            string shijian = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "时间"));

            FrJiagongliaodan form = new FrJiagongliaodan();
            form.gongzuolinghao = gonglinghao;
            form.xiangmumingcheng = xiangmumingcheng;
            form.leixing = "装配";
            form.shijian = shijian;
            form.shebeimingcheng = shebeimingcheng;
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {


            }
        }
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
                string fuzeren = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "装配负责人"));

                string sql3 = "update tb_jishubumen  set  装配负责人='" + fuzeren + "'      where id='" + id + "' ";
                    SQLhelp.ExecuteScalar(sql3, CommandType.Text);

                }

            }

        private void 查看备料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string gonglinghao = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号"));
            string xiangmumingcheng = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "项目名称"));
            string shebeimingcheng = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "设备名称"));
            string shijian = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "时间"));

            FrJiagongliaodan form = new FrJiagongliaodan();
            form.gongzuolinghao = gonglinghao;
            form.xiangmumingcheng = xiangmumingcheng;
            form.leixing = "技改";
            form.shijian = shijian;
            form.shebeimingcheng = shebeimingcheng;
            form.yonghu = yonghu;
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {


            }

        }
        
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
            {                
                FrZhuangpeifankui form = new FrZhuangpeifankui();
                form.gongzuolinghao = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号").ToString();
                form.xiangmumingcheng = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "项目名称").ToString();
                form.shijian = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "时间").ToString(); 
                form.shebeimingcheng = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "设备名称").ToString();
                form.yonghu = yonghu;

                form.ShowDialog();
            }

        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
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

                FrJiagongliaodan form = new FrJiagongliaodan();
                form.gongzuolinghao = gonglinghao;
                form.xiangmumingcheng = xiangmumingcheng;
                form.leixing = "技改";
                form.shijian = shijian;
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {


                }
            }

        }
    } }
