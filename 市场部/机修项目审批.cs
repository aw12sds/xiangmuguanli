using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;

namespace 项目管理系统.市场部
{
    public partial class 机修项目审批 : DevExpress.XtraEditors.XtraForm
    {
        public string yonghu;
        public 机修项目审批(string flag,string yonghu)
        {
            this.yonghu = yonghu;
            InitializeComponent();
           
            
            if (flag.Equals("自制"))
            {
                if (yonghu.Equals("袁天坤")|| yonghu.Equals("石海波"))
                {
                    Reload();
                }
               else if (yonghu.Equals("袁鹏"))
                {
                    Reload2();
                }

            }
            else if (flag.Equals("外协"))
            {
                Reload1();
            }
        }

        public void Reload()
        {
            string sql1= "select id,接单编号,机修件ERP,客户名称,部门,工件名称,加工内容,计量单位,机修件数量,接单日期,预交时间,联系人,责任人,加工单位备注,当前状态,合同号,供方名称,附件名称  from  tb_caigouliaodan where 加工单位备注='自制' and 完成='机修待审批' and 当前状态='待责任人审核' order by 接单日期";
            SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridControl1.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
        }
        public void Reload2()
        {
            string sql1 = "select id,接单编号,机修件ERP,客户名称,部门,工件名称,加工内容,计量单位,机修件数量,接单日期,预交时间,联系人,责任人,加工单位备注,当前状态,合同号,供方名称,附件名称  from  tb_caigouliaodan where 加工单位备注='自制' and 完成='机修待审批' and 当前状态='机修待袁鹏审批'  order by 接单日期";
            SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridControl1.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
        }
        public void Reload1()
        {
            string sql1 = "select id,接单编号,机修件ERP,客户名称,部门,工件名称,加工内容,计量单位,机修件数量,接单日期,预交时间,联系人,责任人,加工单位备注,当前状态,合同号,供方名称,附件名称  from  tb_caigouliaodan where 加工单位备注='外协' and 完成='机修待审批'  order by 接单日期";
            SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridControl1.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
        }
        private void 查看附件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));


            string sql = "select 附件名称 from tb_caigouliaodan where id='" + id + "'";
            string mingcheng = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (mingcheng == "")
            {
                MessageBox.Show("没有附件！");
                return;
            }

            string sql2 = "select 附件类型 from tb_caigouliaodan where id='" + id + "'";
            string leixing = SQLhelp.ExecuteScalar(sql2, CommandType.Text).ToString();

            byte[] mypdffile = null;

            string sql4 = "Select 附件 From tb_caigouliaodan Where id='" + id + "' ";

            mypdffile = SQLhelp.duqu(sql4, CommandType.Text);
            this.Cursor = Cursors.WaitCursor;

            string aaaa = System.Environment.CurrentDirectory;
            string bbbb = mingcheng.Replace("?", "1");
            string lujing = aaaa + "\\" + bbbb + "1" + "." + leixing;

            FileStream fs = new FileStream(lujing, FileMode.Create);
            fs.Write(mypdffile, 0, mypdffile.Length);
            fs.Flush();
            fs.Close();
            this.Cursor = Cursors.Default;
            System.Diagnostics.Process.Start(lujing);
        }

        private void 机修项目审批_Load(object sender, EventArgs e)
        {

        }

        private void 同意ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (yonghu.Equals("袁天坤"))
            {
                string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
                string sql = "update tb_caigouliaodan set 当前状态='机修待袁鹏审批' where id='"+id+"'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);
                Reload();
            }else if (yonghu.Equals("袁鹏"))
            {
                string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
                string sql = "update tb_caigouliaodan set 当前状态='已审批',完成='未完成' where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);
                Reload2();
            }
           
        }
    }
}