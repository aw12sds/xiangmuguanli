using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.项目总览
{
    public partial class FrFankuixiangxi : Office2007Form
    {
        public FrFankuixiangxi()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string gongzuolinghao;
        public string xiangmumingcheng;
        public string shebeimingcheng;
        public string shijian;
        public string yonghu;
        private void FrFankuixiangxi_Load(object sender, EventArgs e)
        {
            Reload();
        }
        public void Reload()
        {
            string sql1 = "select  id,创建时间,工作令号,项目名称,指示项,时间,创建人 from  tb_zhishixiang  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "'   ";
            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            dataGridViewX2.DataSource = dt;

        }

        private void 回复ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrZhishixianghuifu form = new FrZhishixianghuifu();
            form.gongzuolinghao = gongzuolinghao;
            form.xiangmumingcheng = xiangmumingcheng;
          
            form.shijian = shijian;
            form.yonghu = yonghu;
            form.zhonglei = "新增";
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                Reload();
                this.DialogResult = DialogResult.OK;
                
            }
        }

        private void 删除该行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewX2.Rows.Count == 0)
            {

                MessageBox.Show("请先选中行！");
                return;
            }
            if (yonghu!="庄卫星")
            {
                MessageBox.Show("无权限！");
                return;
            }
            if (yonghu == "庄卫星")
            {
                string id = dataGridViewX2.CurrentRow.Cells["id"].Value.ToString();

                string sql = "delete from tb_zhishixiang where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);

                Reload();

            }
               
        }

        private void 修改该行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewX2.Rows.Count == 0)
            {

                MessageBox.Show("请先选中行！");
                return;
            }
            if (yonghu != "庄卫星")
            {
                MessageBox.Show("无权限！");
                return;
            }
            if (yonghu == "庄卫星")
            {

                string id = dataGridViewX2.CurrentRow.Cells["id"].Value.ToString();
                FrZhishixianghuifu form = new FrZhishixianghuifu();
                form.gongzuolinghao = gongzuolinghao;
                form.xiangmumingcheng = xiangmumingcheng;

                form.shijian = shijian;
                form.yonghu = yonghu;
                form.id = id;
                form.zhonglei = "修改";
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    Reload();
                    this.DialogResult = DialogResult.OK;

                }
            }

        }
    }
}
