﻿using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 项目管理系统.仓库;
using 项目管理系统.物流部;

namespace 项目管理系统.生产部
{
    public partial class FrShengchanbujianyan : Office2007Form
    {
        public FrShengchanbujianyan()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string yonghu;

        public void Reload()
        {

            string sql1 = "select  id,工作令号,项目名称,设备名称,时间,流程类型,创建人,创建时间,到货验收流程标记,流程状态 from  tb_zongliucheng  where  流程状态='到达生产部' or  流程状态='到达技术部与生产部'";
            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            dataGridViewX1.DataSource = dt;



        }
        private void FrShengchanbujianyan_Load(object sender, EventArgs e)
        {
            Reload();

        }

        private void 查看对应料单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.Rows.Count <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }
            string gonglinghao = dataGridViewX1.CurrentRow.Cells["工作令号"].Value.ToString();
            string xiangmumingcheng = dataGridViewX1.CurrentRow.Cells["项目名称"].Value.ToString();
            string shebeimingcheng = dataGridViewX1.CurrentRow.Cells["设备名称"].Value.ToString();
            string shijian = dataGridViewX1.CurrentRow.Cells["时间"].Value.ToString();
            string id = dataGridViewX1.CurrentRow.Cells["id"].Value.ToString();
            string liuchengbiaoji = dataGridViewX1.CurrentRow.Cells["到货验收流程标记"].Value.ToString();
            FrDuiyingliaodan form = new FrDuiyingliaodan();
            form.gongzuolinghao = gonglinghao;
            form.xiangmumingcheng = xiangmumingcheng;
            form.yonghu = yonghu;
            form.shijian = shijian;
            form.id1 = id;
            form.biaoji = liuchengbiaoji;
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {


            }
        }

        private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewX1.Rows.Count <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }
            string gonglinghao = dataGridViewX1.CurrentRow.Cells["工作令号"].Value.ToString();
            string xiangmumingcheng = dataGridViewX1.CurrentRow.Cells["项目名称"].Value.ToString();
            string shebeimingcheng = dataGridViewX1.CurrentRow.Cells["设备名称"].Value.ToString();
            string shijian = dataGridViewX1.CurrentRow.Cells["时间"].Value.ToString();
            string id = dataGridViewX1.CurrentRow.Cells["id"].Value.ToString();
            string biaoji = dataGridViewX1.CurrentRow.Cells["到货验收流程标记"].Value.ToString();
            string liuchengleixing = dataGridViewX1.CurrentRow.Cells["流程类型"].Value.ToString();
            FrWuliubuxiangxiliaodan form = new FrWuliubuxiangxiliaodan();
            form.gongzuolinghao = gonglinghao;
            form.xiangmumingcheng = xiangmumingcheng;
            form.yonghu = yonghu;
            form.shijian = shijian;
            form.id1 = id;
            form.biaoji = biaoji;
            form.liuchengleixing = liuchengleixing;

            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {


            }
        }

        private void 处理流程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.Rows.Count <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }
            string gonglinghao = dataGridViewX1.CurrentRow.Cells["工作令号"].Value.ToString();
            string xiangmumingcheng = dataGridViewX1.CurrentRow.Cells["项目名称"].Value.ToString();
            string shebeimingcheng = dataGridViewX1.CurrentRow.Cells["设备名称"].Value.ToString();
            string shijian = dataGridViewX1.CurrentRow.Cells["时间"].Value.ToString();
            string id = dataGridViewX1.CurrentRow.Cells["id"].Value.ToString();
            string liuchengbiaoji = dataGridViewX1.CurrentRow.Cells["到货验收流程标记"].Value.ToString();
            
            FrShengchanjianyanfankui form = new FrShengchanjianyanfankui();
            form.gongzuolinghao = gonglinghao;
            form.xiangmumingcheng = xiangmumingcheng;
            form.yonghu = yonghu;
            form.shijian = shijian;
            form.id1 = id;
            form.biaoji = liuchengbiaoji;
            form.shebeimingcheng = shebeimingcheng;
            
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                Reload();

            }

        }
    }
}
