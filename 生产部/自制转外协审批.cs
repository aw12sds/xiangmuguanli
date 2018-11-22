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
    public partial class 自制转外协审批 : Form
    {
        public 自制转外协审批()
        {
            InitializeComponent();
        }

        private void 自制转外协审批_Load(object sender, EventArgs e)
        {
            reload();
        }
        public void reload()
        {
            string sql = "select 工作令号,项目名称,设备名称,id,型号,名称,单位,数量,类型,备注,制造类型,当前状态,实际采购数量 from tb_caigouliaodan where  流程状态='转精工事业部审批' and 制造类型='外协转自制' and 接单编号 is null ";
            gridControl1.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
            string sql1 = "select id,接单编号,客户名称,部门,工件名称,加工内容,计量单位,机修件数量,接单日期,预交时间,联系人,责任人,加工单位备注,当前状态  from  tb_caigouliaodan where  流程状态='转精工事业部审批'  and 加工单位备注='外协转自制' and 接单编号 is not null ";
            gridControl2.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
            string sql1 = "update tb_caigouliaodan  set 流程状态='审批成功',制造类型='自制零部件'  where id='" + id + "'";
            SQLhelp.ExecuteScalar(sql1, CommandType.Text);
            reload();
            MessageBox.Show("审批成功！");
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
            string sql1 = "update tb_caigouliaodan set 制造类型='外协零部件' ,流程状态='精工事业部驳回' where id='" + id + "'";
            SQLhelp.ExecuteScalar(sql1, CommandType.Text);
            reload();
            MessageBox.Show("审批成功！");
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            string id = this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id").ToString();
            string sql1 = "update tb_caigouliaodan  set 流程状态='审批成功',加工单位备注='自制' where id='" + id + "'";
            SQLhelp.ExecuteScalar(sql1, CommandType.Text);
            reload();
            MessageBox.Show("审批成功！");
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            string id = this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id").ToString();
            string sql1 = "update tb_caigouliaodan set 加工单位备注='外协' ,流程状态='精工事业部驳回' where id='" + id + "'";
            SQLhelp.ExecuteScalar(sql1, CommandType.Text);
            reload();
            MessageBox.Show("审批成功！");
        }
    }
}
