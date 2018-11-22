using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.技术部
{
    public partial class FrTiaoshiguanli : Office2007Form
    {
        public FrTiaoshiguanli()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string yonghu;
        private void FrTiaoshiguanli_Load(object sender, EventArgs e)
        {
            Reload();
        }
        public void Reload()
        {

            string sql = "select 工作令号,项目名称,设备名称,项目主管,数量,设备预计结束时间,时间,调试确认 from tb_jishubumen where 制造类型='自制' and 是否提交=1 and 技术部通过=1  and 生产部确认=1 and 加工确认=1 and 装配确认=1   and 调试确认=0 ";

            dataGridViewX2.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);


        }

        private void 确认完成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string gonglinghao = dataGridViewX2.CurrentRow.Cells["工作令号"].Value.ToString();
            string xiangmumingcheng = dataGridViewX2.CurrentRow.Cells["项目名称"].Value.ToString();
            string shebeimingcheng = dataGridViewX2.CurrentRow.Cells["设备名称"].Value.ToString();
            string shijian = dataGridViewX2.CurrentRow.Cells["时间"].Value.ToString();
            string sql = "update tb_jishubumen  set 调试确认=1 , 调试完成时间='" + DateTime.Now.ToString() + "'  where 工作令号='" + gonglinghao + "'  and 项目名称='" + xiangmumingcheng + "' and 时间='" + shijian + "'";
            SQLhelp.ExecuteScalar(sql, CommandType.Text);

            Reload();
        }

        private void dataGridViewX2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrTiaoshifankui form = new FrTiaoshifankui();
            form.gongzuolinghao = dataGridViewX2.CurrentRow.Cells["工作令号"].Value.ToString();
            form.xiangmumingcheng = dataGridViewX2.CurrentRow.Cells["项目名称"].Value.ToString();
            form.shijian = dataGridViewX2.CurrentRow.Cells["时间"].Value.ToString();
            form.shebeimingcheng = dataGridViewX2.CurrentRow.Cells["设备名称"].Value.ToString();
            form.yonghu = yonghu;
            form.ShowDialog();
        }
    }
}
