using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.个人管理
{
    public partial class Frwuzilingyong : Form
    {
        public Frwuzilingyong(string yonghu)
        {
            InitializeComponent();
            this.yonghu = yonghu;
        }
        public string yonghu;
        private void Frwuzilingyong_Load(object sender, EventArgs e)
        {
            Reload();
            Reload1();
            timer1.Start();
        }
        public void Reload()
        {
            string sql = "select id,工作令号,项目名称,设备名称,编码,名称,型号,实际采购数量,合同号,库存数量,领用登记数量,输入待领用数量,出库数量 from tb_caigouliaodan where 库存数量!=0";
            gridControl4.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);

        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            DataTable zongbiao = new DataTable();
            dt.Columns.Add("工作令号");
            dt.Columns.Add("项目名称");
            dt.Columns.Add("设备名称");
            dt.Columns.Add("id");
            dt.Columns.Add("编码");
            dt.Columns.Add("型号");
            dt.Columns.Add("名称");
            dt.Columns.Add("实际采购数量");
            dt.Columns.Add("合同号");
            dt.Columns.Add("库位号");
            dt.Columns.Add("库存数量");
            dt.Columns.Add("出库数量");
            dt.Columns.Add("输入待领用数量");
            dt.Columns.Add("料单类型");
            dt.Columns.Add("领用登记数量");

            zongbiao.Columns.Add("工作令号");
            zongbiao.Columns.Add("项目名称");
            zongbiao.Columns.Add("设备名称");
            zongbiao.Columns.Add("id");
            zongbiao.Columns.Add("编码");
            zongbiao.Columns.Add("型号");
            zongbiao.Columns.Add("名称");
            zongbiao.Columns.Add("实际采购数量");
            zongbiao.Columns.Add("合同号");
            zongbiao.Columns.Add("库位号");
            zongbiao.Columns.Add("库存数量");
            zongbiao.Columns.Add("出库数量");
            zongbiao.Columns.Add("输入待领用数量");
            zongbiao.Columns.Add("料单类型");
            zongbiao.Columns.Add("领用登记数量");
            if(qingdan=="")
            {
                MessageBox.Show("请先加入名单！");
                return;
            }
            string[] strArray = qingdan.Split('|'); //字符串转数组
            List<string> list = new List<string>();
            for (int i = 0; i < strArray.Length; i++)//遍历数组成员
            {
                if (list.IndexOf(strArray[i].ToLower()) == -1)//对每个成员做一次新数组查询如果没有相等的则加到新数组
                    list.Add(strArray[i]);
            }
            for (int i = 0; i < list.Count; i++)
            {
                string dingwei = list[i];


                string sql1 = "select id,工作令号,项目名称,设备名称,编码,型号,名称,实际采购数量,合同号,库存数量,出库数量,输入待领用数量,料单类型,领用登记数量 from  tb_caigouliaodan  where id='" + dingwei + "' ";
                dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                zongbiao.Merge(dt, true, MissingSchemaAction.Ignore);
            }
            
            Frwuliaoshenqingdan form1 = new Frwuliaoshenqingdan(yonghu);
            form1.dt = zongbiao;

            form1.ShowDialog();
            if (form1.DialogResult == DialogResult.OK)
            {
                Reload();
                Reload1();


            }
        }

        private void gridView4_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
        public string qingdan="";
        private void buttonItem2_Click(object sender, EventArgs e)
        {
            int[] a = gridView4.GetSelectedRows();
            foreach (int aa in a)
            {
                string ff = Convert.ToString(gridView4.GetRowCellValue(aa, "实际采购数量"));
                string bb = Convert.ToString(gridView4.GetRowCellValue(aa, "库存数量"));
                string cc = Convert.ToString(gridView4.GetRowCellValue(aa, "出库数量"));
                string dd = Convert.ToString(gridView4.GetRowCellValue(aa, "领用登记数量"));
                if (bb == "")
                {
                    MessageBox.Show("其中有物资没有入库！");
                    return;
                }
                double bbb = Convert.ToDouble(bb);
                if (bbb == 0)
                {
                    MessageBox.Show("其中有库存数量是0，无法领用！");
                    return;
                }
                if (dd == ff)
                {
                    MessageBox.Show("其中有的领用数量等于实际采购数量，已经全部登记领用！");
                    return;

                }
                

            }
           
            foreach (int i in a)
            {
                string id = gridView4.GetRowCellValue(i, "id").ToString();
                qingdan += id + "|";
            }
            MessageBox.Show("已加入列表！");
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            qingdan = "";
            MessageBox.Show("已清空！");
        }

        private void bar1_ItemClick(object sender, EventArgs e)
        {

        }
        public void Reload1()
        {
            string sql = "select * from tb_lingyong where 开单人='" + yonghu+"'";
            gridControl2.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);



        }

        private void 修改数量ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id").ToString();
            String sql查询1 = "Select 领用数量,定位,出库 From tb_lingyong  Where id='" + id + "'";
            DataTable dt3 = SQLhelp.GetDataTable(sql查询1, CommandType.Text);
            string 原先领用数量 = dt3.Rows[0]["领用数量"].ToString();
            string 领用数量 = this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "领用数量").ToString();
            string 定位 = dt3.Rows[0]["定位"].ToString();
            string 出库 = dt3.Rows[0]["出库"].ToString();


            String sqlkucun = "Select 库存数量,领用登记数量,实际采购数量 From tb_caigouliaodan  Where id='" + 定位 + "'";
            DataTable dt2 = SQLhelp.GetDataTable(sqlkucun, CommandType.Text);
            string 领用登记数量 = dt2.Rows[0]["领用登记数量"].ToString();
            string 库存数量 = dt2.Rows[0]["库存数量"].ToString();
            string 实际采购数量 = dt2.Rows[0]["实际采购数量"].ToString();
            float 累计数量 = Convert.ToSingle(领用登记数量) - Convert.ToSingle(原先领用数量) + Convert.ToSingle(领用数量);
            if (出库 == "1")
            {
                MessageBox.Show("已经出库,不能修改");
            }
            else
            {
                if (Convert.ToSingle(领用数量) > Convert.ToSingle(库存数量))
                {
                    MessageBox.Show("超过库存");
                    Reload1();
                }

                else if (累计数量 > Convert.ToSingle(实际采购数量))
                {
                    MessageBox.Show("累计数量超过实际采购数量");
                    Reload1();
                }
                else
                {
                    string sql = "update tb_lingyong set 领用数量=" + 领用数量 + " where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql, CommandType.Text);

                    string sql11 = "update tb_caigouliaodan set 领用登记数量='" + 累计数量 + "' where id='" + 定位 + "' ";
                    SQLhelp.ExecuteScalar(sql11, CommandType.Text);
                    MessageBox.Show("修改成功");
                    Reload1();
                }
            }
             
           
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确实要删除吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string id = this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id").ToString();
                String sql查询 = "Select 领用数量,定位,出库 From tb_lingyong  Where id='" + id + "'";
                DataTable dt1 = SQLhelp.GetDataTable(sql查询, CommandType.Text);
                string 领用数量 = dt1.Rows[0]["领用数量"].ToString();
                string 定位 = dt1.Rows[0]["定位"].ToString();
                string 出库 = dt1.Rows[0]["出库"].ToString();
                if (出库 == "1")
                {
                    MessageBox.Show("已经出库,不能删除");
                }else
                {
                    string sql11 = "update tb_caigouliaodan set 领用登记数量=领用登记数量-" + 领用数量 + " where id='" + 定位 + "' ";
                    SQLhelp.ExecuteScalar(sql11, CommandType.Text);
                    String sql = "delete from tb_lingyong where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql, CommandType.Text);
                    Reload1();
                }
               
             

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Reload();
            Reload1();
        }
    }
}

