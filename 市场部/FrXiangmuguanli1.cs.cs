using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.市场部
{
    public partial class FrXiangmuguanli1 : Form
    {
        public FrXiangmuguanli1()
        {
            InitializeComponent();
        }
        public string yonghu;
        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
        public void Reload()
        {
            if (yonghu == "韩小建")
            {
                string sql = "select id,工作令号,交货日期,预计设计开始时间,预计设计结束时间,预计加工开始时间,预计加工结束时间,预计采购开始时间,预计采购结束时间,预计装配开始时间,预计装配结束时间,预计调试开始时间,预计调试结束时间,合同名称,合同类型,里程碑计划表名称,里程碑计划表类型,加工天数,采购天数,装配天数,调试天数,状态,营销组 from xiangmuzongbiao where 营销组='通信装备营销组'   order by 预计设计开始时间 desc";
                DataTable jieguo = SQLhelp.GetDataTable(sql, CommandType.Text);
                gridControl1.DataSource = jieguo;
                
            }
            else if(yonghu== "徐魏魏"|| yonghu == "徐宾宾")
            {
                string sql = "select id,工作令号,交货日期,预计设计开始时间,预计设计结束时间,预计加工开始时间,预计加工结束时间,预计采购开始时间,预计采购结束时间,预计装配开始时间,预计装配结束时间,预计调试开始时间,预计调试结束时间,合同名称,合同类型,里程碑计划表名称,里程碑计划表类型,加工天数,采购天数,装配天数,调试天数,状态,营销组 from xiangmuzongbiao where 营销组='新能源装备营销组'  order by 预计设计开始时间 desc";
                DataTable jieguo = SQLhelp.GetDataTable(sql, CommandType.Text);
                gridControl1.DataSource = jieguo;
            }
            gridView1.Columns["id"].Visible = false;

        }

        private void FrXiangmuguanli1_Load(object sender, EventArgs e)
        {
            Reload();
        }

        private void 审批ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (yonghu == "韩小建"|| yonghu == "徐宾宾" || yonghu == "徐魏魏")
            {
                string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
                string 状态 = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "状态"));
                if (id == "")
                {
                    MessageBox.Show("请选择一行");
                }
                else
                {
                    if (状态 == "")
                    {
                        string sql1 = "insert into tb_xiangmu(工作令号,交货日期,客户名称,项目名称,预计设计开始时间,预计设计结束时间,预计加工开始时间,预计加工结束时间,预计采购开始时间,预计采购结束时间,预计装配开始时间,预计装配结束时间,预计调试开始时间,预计调试结束时间,项目主管,合同名称,合同类型,里程碑计划表名称,里程碑计划表类型,加工天数,采购天数,装配天数,调试天数,维修,未交货项目,项目负责人,采购负责人,装配负责人,生产任务书,生产任务书名称,生产任务书类型,合同,里程碑计划表) " +
    "select 工作令号, 交货日期, 客户名称, 项目名称, 预计设计开始时间, 预计设计结束时间, 预计加工开始时间, 预计加工结束时间, 预计采购开始时间, 预计采购结束时间, 预计装配开始时间, 预计装配结束时间, 预计调试开始时间, 预计调试结束时间, 项目主管, 合同名称, 合同类型, 里程碑计划表名称, 里程碑计划表类型, 加工天数, 采购天数, 装配天数, 调试天数,维修,未交货项目,项目负责人,采购负责人,装配负责人,生产任务书,生产任务书名称,生产任务书类型,合同,里程碑计划表 from tb_xiangmu1 where 定位='" + id + "'";
                        SQLhelp.ExecuteScalar(sql1, CommandType.Text);
                        string sql = "update xiangmuzongbiao set 状态='同意' Where id='" + id + "'";
                        SQLhelp.ExecuteScalar(sql, CommandType.Text);

                        string sql2 = " insert into tb_jishubumen(工作令号,项目名称,项目主管,时间,优先级,是否下达,生产部确认,图纸下达,技术部通过,加工确认,装配确认,调试确认,物流部确认,仓库确认,采购项目负责人,装配负责人,设备名称,项目负责人,是否提交,物流部最终确认,维修) " +
            "select 工作令号, 项目名称, 项目主管, 时间, 优先级, 是否下达, 生产部确认, 图纸下达, 技术部通过, 加工确认, 装配确认, 调试确认, 物流部确认, 仓库确认, 采购项目负责人, 装配负责人, 设备名称, 项目负责人, 是否提交, 物流部最终确认,维修 from tb_jishubumen1 where 定位='" + id + "'";
                        SQLhelp.ExecuteScalar(sql2, CommandType.Text);
                        MessageBox.Show("已审批");
                        Reload();
                    }
                    else
                    {
                        MessageBox.Show("已通过,无法再次同意");
                    }


                }
            }
            if (yonghu != "韩小建" && yonghu != "徐宾宾"&& yonghu != "徐魏魏")
            {
                MessageBox.Show("无权限！");
                return;
            }
        }

        private void 驳回ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
            string 状态 = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "状态"));
            if (id == "")
            {
                MessageBox.Show("请选择一行");
            }
            else
            {
                if (状态 == "同意")
                {
                    MessageBox.Show("已同意,无法驳回");
                }
                else
                {
                    string sql = "update xiangmuzongbiao set 状态='驳回' Where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql, CommandType.Text);


                   
                    MessageBox.Show("已驳回");
                    Reload();
                }
                    
            }
              
        }

        private void 查看明细ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
            Frmingxi Frmingxi = new Frmingxi(id);
            Frmingxi.ShowDialog();
        }

        private void gridControl1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
