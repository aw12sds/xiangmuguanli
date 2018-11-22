using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.物流部
{
    public partial class Franquankucuncaigou : Form
    {
        public Franquankucuncaigou()
        {
            InitializeComponent();
        }
        public string yonghu;
        private void Franquankucuncaigou_Load(object sender, EventArgs e)
        {
            Reload();
        }
        public void Reload()
        {

            string sql = "select id,新编号,三级,四级,单位,实时库存数,需购买量 from tb_xinerp where 安全库存=1 and   需购买量!=0";
            gridControl1.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
            gridView1.Columns["id"].Visible = false;

            string sql1 = "select  id,工作令号,编码,型号,名称,实际采购数量,申购人,当前状态,到货情况,采购类型,收到料单日期,合同号,供方名称,单位,采购单价   from  tb_caigouliaodan where 料单类型='安全库存'";
            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridControl2.DataSource = dt;

        }

        private void 采购ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认新增安全库存采购吗,新增完后，勾选的料单需采购数量将清空！", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string liushuihao = "WL" + DateTime.Now.ToString("yyyyMMddHHmmss");

               
                int[] a = gridView1.GetSelectedRows();

                foreach (int i in a)
                {
                        string sql = "insert into tb_caigouliaodan (工作令号,编码,型号,名称,单位,数量,类型,要求到货日期1,备注,申购人,实际采购数量,收到料单日期,料单类型,采购类型)  values ('" + liushuihao + "','" + gridView1.GetRowCellValue(i, "新编号").ToString() + "','" + gridView1.GetRowCellValue(i, "四级").ToString() + "','" + gridView1.GetRowCellValue(i, "三级").ToString() + "','" + gridView1.GetRowCellValue(i, "单位").ToString() + "','" + gridView1.GetRowCellValue(i, "需购买量").ToString() + "','','','','" + yonghu + "','" + gridView1.GetRowCellValue(i, "需购买量").ToString() + "','" + DateTime.Now + "','安全库存','物流部')  ";
                        SQLhelp.ExecuteScalar(sql, CommandType.Text);
                        string sql1 = "update tb_xinerp  set  需购买量=0 where id='" + gridView1.GetRowCellValue(i, "id").ToString() + "'";
                    SQLhelp.ExecuteScalar(sql1, CommandType.Text);
                }
                MessageBox.Show("生成成功！");
                Reload();
            }
        }

        private void 生成采购合同ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DataTable dt1 = new DataTable();
            DataTable zongbiao1 = new DataTable();

            dt1.Columns.Add("id");
            dt1.Columns.Add("工作令号");
            dt1.Columns.Add("项目名称");
            dt1.Columns.Add("设备名称");
            dt1.Columns.Add("编码");
            dt1.Columns.Add("名称");
            dt1.Columns.Add("型号");
            dt1.Columns.Add("类型");
            dt1.Columns.Add("实际采购数量");
            dt1.Columns.Add("采购单价");
            dt1.Columns.Add("总价");
            dt1.Columns.Add("备注");
            dt1.Columns.Add("单位");
            zongbiao1.Columns.Add("id");
            zongbiao1.Columns.Add("工作令号");
            zongbiao1.Columns.Add("项目名称");
            zongbiao1.Columns.Add("设备名称");
            zongbiao1.Columns.Add("编码");
            zongbiao1.Columns.Add("名称");
            zongbiao1.Columns.Add("型号");
            zongbiao1.Columns.Add("类型");
            zongbiao1.Columns.Add("实际采购数量");
            zongbiao1.Columns.Add("采购单价");
            zongbiao1.Columns.Add("总价");
            zongbiao1.Columns.Add("备注");
            zongbiao1.Columns.Add("单位");

            int b = 0;
            int[] a = gridView2.GetSelectedRows();

            foreach (int i in a)
            {
                b += 1;
                if (b <= 200)
                {
                    string id = gridView2.GetRowCellValue(i, "id").ToString();

                    string sql1 = "select id,编码,名称,型号,实际采购数量,工作令号,备注,设备名称,项目名称,类型,单位,采购单价 from  tb_caigouliaodan  where id ='" + id + "' ";
                    dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);

                    zongbiao1.Merge(dt1, true, MissingSchemaAction.Ignore);
                }
            }
            Frhetongmoban form1 = new Frhetongmoban();
            form1.dt = zongbiao1;
            form1.yonghu = yonghu;
            form1.zhonglei = "采购";
            form1.ShowDialog();
            Reload();
        }

        private void 查询安全库存明细ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string bianhao = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "新编号"));
            string sql = "select 工作令号,项目名称,设备名称,编码,名称,型号,类型,备注,制造类型,实际采购数量,收到料单日期,申购人 from tb_caigouliaodan where 编码='" + bianhao + "' and 安全库存=1";
            FrWuliuguanli form1 = new FrWuliuguanli();
            form1.dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            form1.ShowDialog();

        }
    }
}
