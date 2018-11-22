using Aspose.Cells;
using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.生产部
{
    public partial class FrJixiuyewu : Office2007Form
    {
        public string yonghu;
        public FrJixiuyewu()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }

        private void FrJixiuyewu_Load(object sender, EventArgs e)
        {
            Reload();
        }
        public void Reload()
        {
            string sql123 = "select id,接单编号,客户名称,部门,工件名称,加工内容,计量单位,机修件数量,接单日期,预交时间,联系人,责任人,加工单位备注,当前状态,生产部确认,生产部确认时间,机修客户申请单号,附件名称,备注  from  tb_caigouliaodan where (完成='未完成'or 完成 is null) and 加工单位备注='自制' and 机修件数量 is not null  order by 接单日期 desc";
   
            gridControl1.DataSource = SQLhelp.GetDataTable(sql123, CommandType.Text);
            gridView1.Columns["id"].Visible = false;
            string sql124 = "select id,接单编号,客户名称,部门,工件名称,加工内容,计量单位,机修件数量,接单日期,预交时间,联系人,责任人,加工单位备注,当前状态,生产部确认,生产部确认时间,机修客户申请单号,附件名称,备注  from  tb_caigouliaodan where 完成='完成' and 加工单位备注='自制' and 机修件数量 is not null ";

            gridControl2.DataSource = SQLhelp.GetDataTable(sql124, CommandType.Text);
            gridView2.Columns["id"].Visible = false;

        }
      

        private void 保存表格ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string id = Convert.ToString(gridView1.GetRowCellValue(i, "id"));
                string zhuangtai = Convert.ToString(gridView1.GetRowCellValue(i, "当前状态"));
                string shenqinghao = Convert.ToString(gridView1.GetRowCellValue(i, "机修客户申请单号"));
                string sql2 = "update tb_caigouliaodan  set 当前状态= '" + zhuangtai + "',机修客户申请单号= '" + shenqinghao + "' where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql2, CommandType.Text);

            }
            MessageBox.Show("保存成功！");
            Reload();
        }

     

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            Frjixiujianxinjian form1 = new Frjixiujianxinjian();
            form1.ShowDialog();
            if(form1.DialogResult==DialogResult.OK)
            {
                Reload();
                
            }
        }
        
        private void buttonItem5_Click(object sender, EventArgs e)
        {
            string sql = "select  接单编号,客户名称,部门,工件名称,加工内容,计量单位,机修件数量,接单日期,预交时间,联系人,责任人,加工单位备注,机修客户申请单号   from  tb_caigouliaodan where (完成 is null or 完成='未完成')  and 工件名称 like '%" + txtmingcheng.Text+"%'";

            gridControl1.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
            gridView1.Columns["id"].Visible = false;
        }


        private void 转外协ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认转外协吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
                string sql = "update tb_caigouliaodan set 加工单位备注='自制转外协',流程状态='转物流部审批' where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);

                string jiedanbianhao = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "接单编号"));
                string kehumingcheng = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "客户名称"));
                string bumen = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "部门"));
                string gongjianmingcheng = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工件名称"));
                string jiagongneirong = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "加工内容"));
                string jiliangdanwei = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "单位"));
                string jixiujianshuliang = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "数量"));

                string sql1 = "insert into tb_jiuxiuxiugai (客户名称,部门,工件名称,加工内容,计量单位,机修件数量,接单编号,加工单位备注,修改时间) values ('" + kehumingcheng + "','" + bumen + "','" + gongjianmingcheng + "','" + jiagongneirong + "','" + jiliangdanwei + "','" + jixiujianshuliang + "','" + jiedanbianhao + "','自制转外协','" + DateTime.Now + "')";
                SQLhelp.ExecuteScalar(sql1, CommandType.Text);


                MessageBox.Show("申请成功！");
                Reload();
            }
        }

        private void 转工序外协ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认转工序外协吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {

                string jiedanbianhao = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "接单编号"));
                string kehumingcheng = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "客户名称"));
                string bumen = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "部门"));
                string gongjianmingcheng = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工件名称"));
                string jiagongneirong = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "加工内容"));
                string jiliangdanwei = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "单位"));
                string jixiujianshuliang = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "数量"));

                string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
                string sql = "update tb_caigouliaodan set 工序外协=0,工序外协时间='" + DateTime.Now + "',工作令号='" + jiedanbianhao + "',名称='" + gongjianmingcheng + "',备注='" + jiagongneirong + "',单位='" + jiliangdanwei + "',实际采购数量='" + jixiujianshuliang + "' where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);


                string sqlquary = "select * from tb_caigouliaodan where id='" + id + "'";
                DataTable dtq = SQLhelp.GetDataTable(sqlquary, CommandType.Text);
                string 工作令号 = dtq.Rows[0]["工作令号"].ToString();
                string 项目名称 = dtq.Rows[0]["项目名称"].ToString();
                string 设备名称 = dtq.Rows[0]["设备名称"].ToString();
                string 名称 = dtq.Rows[0]["名称"].ToString();
                string 型号 = dtq.Rows[0]["型号"].ToString();
                string 实际采购数量 = dtq.Rows[0]["实际采购数量"].ToString();

                string sqlinsert = "insert into tb_gonxuwaixieguanli(工作令号,项目名称,设备名称,名称,型号,实际采购数量,工序外协,工序外协时间,父id) values('" + 工作令号 + "','" + 项目名称 + "','" + 设备名称 + "','" +
                   名称 + "','" + 型号 + "','" + 实际采购数量 + "','0','" + DateTime.Now + "','" + id + "')";
                SQLhelp.ExecuteScalar(sqlinsert, CommandType.Text);


                MessageBox.Show("申请成功！");
                Reload();
            }
        }

        private void 入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认入库吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
                string gongjianmingcheng = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工件名称"));
              
                string sql11 = "select * from db_gongxu111 where 序号='" + id + "'";
                DataTable dtt = sqlhelp1.GetDataTable(sql11, CommandType.Text);
                
                if (dtt.Rows.Count == 0)
                {
                    MessageBox.Show(gongjianmingcheng + "没有编工艺，无法入库！");
                    return;
                }
                
                string sql = "update tb_caigouliaodan set 生产部确认=1,生产部确认时间='" + DateTime.Now + "',当前状态='已加工' where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);
                MessageBox.Show("入库成功！");
                Reload();
            }

        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }

        private void 转派工单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认转派工单吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string id = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["id"]).ToString();
                DateTime time = DateTime.Now;
                string sql = "select * from tb_caigouliaodan where id='" + id + "'";
                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
                DataRow dr = dt.Rows[0];

                string sql1 = "insert into tb_Paigongdan (工作令号,项目名称,设备名称,型号,名称,单位,数量,时间,制造类型,下达时间,下达人,状态,number) values('" + dr["接单编号"] + "','" + dr["客户名称"] + "','" + dr["部门"] + "','" + dr["加工内容"] + "','" + dr["工件名称"] + "','" + dr["计量单位"] + "','" + dr["机修件数量"] + "','" + dr["预交时间"] + "','" + dr["加工单位备注"] + "','" + time + "','" + yonghu + "','0','" + id + "')";
                SQLhelp.ExecuteScalar(sql1, CommandType.Text);

                MessageBox.Show("转派工单成功！", "提示");


            }
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
    }
}
