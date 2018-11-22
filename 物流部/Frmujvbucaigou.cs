using MySql.Data.MySqlClient;
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
    public partial class Frmujvbucaigou : Form
    {
        public Frmujvbucaigou()
        {
            InitializeComponent();
        }
        public string yonghu;
      
        private void Frmujvbucaigou_Load(object sender, EventArgs e)
        {
            Reload();
        }
        public string qingdan;
        public string qingdan1;
        public void Reload()
        {
            DataTable inv1 = new DataTable();
            inv1.Columns.Add("state");
            inv1.Columns["state"].DataType = Type.GetType("System.String");
            string conn = "Data Source=10.15.1.252;User ID=root;Password=root;DataBase=zkxj_erp_new";
            MySqlConnection con = new MySqlConnection(conn);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select a.id,a.product_order_number,a.zttordertime,a.client,a.product_name,a.amount,a.supplier_name,a.End_data,a.send_time,a.state,a.contract_number,a.erp_number,a.stardard,a.cost_single_price,a.unit,b.xt_userinfo_realName  from ztt_order a,xt_userinfo b where cato_type='outside' and a.apply_id=b.xt_userinfo_id ORDER BY (left(product_order_number, 2)+0) DESC,(substring(product_order_number, 7)+0) DESC ", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            inv1.Load(dr);
           
            for (int i = 0; i < inv1.Rows.Count; i++)
            {
                string state = inv1.Rows[i]["state"].ToString();

                if (state == "61")
                {
                    inv1.Rows[i]["state"] = "1询价中";
                }

                if (state == "62")
                {
                    inv1.Rows[i]["state"] = "2技术沟通中";
                }

                if (state == "63")
                {
                    inv1.Rows[i]["state"] = "3合同编制评审中";
                }
                if (state == "64")
                {
                    inv1.Rows[i]["state"] = "4预付款审批中";
                }
                if (state == "65")
                {
                    inv1.Rows[i]["state"] = "5生产制作中";
                }
                if (state == "66")
                {
                    inv1.Rows[i]["state"] = "6提货款审批中";
                }
                if (state == "67")
                {
                    inv1.Rows[i]["state"] = "7厂验安排中";
                }
                if (state == "68")
                {
                    inv1.Rows[i]["state"] = "8整改返工中";
                }
                if (state == "69")
                {
                    inv1.Rows[i]["state"] = "9已到货";
                }
                if (state == "70")
                {
                    inv1.Rows[i]["state"] = "10已出库";
                }
                if (state != "61" && state != "62" && state != "63" && state != "64" && state != "65" && state != "66" && state != "67" && state != "68" && state != "69" && state != "70")
                {
                    inv1.Rows[i]["state"] = "";

                }

            }


            dataGridViewX2.DataSource = inv1;



            DataTable inv2 = new DataTable();
            inv2.Columns.Add("state");
            inv2.Columns["state"].DataType = Type.GetType("System.String");
            string conn2 = "Data Source=10.15.1.252;User ID=root;Password=root;DataBase=zkxj_erp_new";
            MySqlConnection con2 = new MySqlConnection(conn2);
            con2.Open();
            MySqlCommand cmd2 = new MySqlCommand("select id,Product_order_number,purchase_name,purchase_stardard,material,amount,hope_end_data,apply_time,supply_name,single_price,contract_number,state,erp_number,unit,comment  from ztt_purchase order by apply_time desc", con2);
            MySqlDataReader dr2 = cmd2.ExecuteReader(); 
            inv2.Load(dr2);

            for (int i = 0; i < inv2.Rows.Count; i++)
            {
                string state = inv2.Rows[i]["state"].ToString();

                if (state == "61")
                {
                    inv2.Rows[i]["state"] = "1询价中";
                }

                if (state == "62")
                {
                    inv2.Rows[i]["state"] = "2技术沟通中";
                }

                if (state == "63")
                {
                    inv2.Rows[i]["state"] = "3合同编制评审中";
                }
                if (state == "64")
                {
                    inv2.Rows[i]["state"] = "4预付款审批中";
                }
                if (state == "65")
                {
                    inv2.Rows[i]["state"] = "5生产制作中";
                }
                if (state == "66")
                {
                    inv2.Rows[i]["state"] = "6提货款审批中";
                }
                if (state == "67")
                {
                    inv2.Rows[i]["state"] = "7厂验安排中";
                }
                if (state == "68")
                {
                    inv2.Rows[i]["state"] = "8整改返工中";
                }
                if (state == "69")
                {
                    inv2.Rows[i]["state"] = "9已到货";
                }
                if (state == "70")
                {
                    inv2.Rows[i]["state"] = "10已出库";
                }
                if (state != "61" && state != "62" && state != "63" && state != "64" && state != "65" && state != "66" && state != "67" && state != "68" && state != "69" && state != "70")
                {
                    inv2.Rows[i]["state"] = "";

                }

            }


            dataGridViewX1.DataSource = inv2;







        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < dataGridViewX2.Rows.Count; i++)
            {
                string id = dataGridViewX2.Rows[i].Cells["id"].Value.ToString();
                string gongfangmingcheng = Convert.ToString(dataGridViewX2.Rows[i].Cells["供方名称"].Value);
                string hetonghao = Convert.ToString(dataGridViewX2.Rows[i].Cells["合同号"].Value);
                string dangqianzhuangtai = dataGridViewX2.Rows[i].Cells["当前状态"].Value.ToString();
                string cost_single_price= dataGridViewX2.Rows[i].Cells["成本单价"].Value.ToString();
               
                if (dangqianzhuangtai == "1询价中")
                {
                    dangqianzhuangtai = "61";
                }
                if (dangqianzhuangtai == "2技术沟通中")
                {
                    dangqianzhuangtai = "62";
                }
                if (dangqianzhuangtai == "3合同编制评审中")
                {
                    dangqianzhuangtai = "63";
                }
                if (dangqianzhuangtai == "4预付款审批中")
                {
                    dangqianzhuangtai = "64";
                }
                if (dangqianzhuangtai == "5生产制作中")
                {
                    dangqianzhuangtai = "65";
                }
                if (dangqianzhuangtai == "6提货款审批中")
                {
                    dangqianzhuangtai = "66";
                }
                if (dangqianzhuangtai == "7厂验安排中")
                {
                    dangqianzhuangtai = "66";
                }
                if (dangqianzhuangtai == "8整改返工中")
                {
                    dangqianzhuangtai = "68";
                }
                if (dangqianzhuangtai == "9已到货")
                {
                    dangqianzhuangtai = "69";
                }
                if (dangqianzhuangtai == "10已出库")
                {
                    dangqianzhuangtai = "70";
                }
                if (dangqianzhuangtai == "")
                {
                    dangqianzhuangtai = "55";
                }

                string conn = "Data Source=10.15.1.252;User ID=root;Password=root;DataBase=zkxj_erp_new";
                MySqlConnection con = new MySqlConnection(conn);
                con.Open();
                string sql = "update  ztt_order set state='" + dangqianzhuangtai + "',supplier_name='" + gongfangmingcheng + "',contract_number='" + hetonghao + "',cost_single_price='" + cost_single_price + "' where id='" + id + "'";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteScalar();
                con.Close();
            }
            MessageBox.Show("保存成功！");


        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {

            DataTable dt1 = new DataTable();
            DataTable zongbiao1 = new DataTable();
            dt1.Columns.Add("id");
            dt1.Columns.Add("product_order_number");
            dt1.Columns.Add("erp_number");
            dt1.Columns.Add("product_name");
            dt1.Columns.Add("stardard");
            dt1.Columns.Add("unit");
            dt1.Columns.Add("amount");
            dt1.Columns.Add("采购单价");
            dt1.Columns.Add("总价");

            zongbiao1.Columns.Add("id");
            zongbiao1.Columns.Add("product_order_number");
            zongbiao1.Columns.Add("erp_number");
            zongbiao1.Columns.Add("product_name");
            zongbiao1.Columns.Add("stardard");
            zongbiao1.Columns.Add("amount");
            zongbiao1.Columns.Add("unit");
            zongbiao1.Columns.Add("采购单价");
            zongbiao1.Columns.Add("总价");



            for (int i = 0; i < dataGridViewX2.Rows.Count; i++)
            {
                string shaixuan = Convert.ToString(dataGridViewX2.Rows[i].Cells["筛选"].Value);
                if (shaixuan == "1")
                {
                    
                    string id = Convert.ToString(dataGridViewX2.Rows[i].Cells["id"].Value);

                    string conn = "Data Source=10.15.1.252;User ID=root;Password=root;DataBase=zkxj_erp_new";
                    MySqlConnection con = new MySqlConnection(conn);
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("select id,product_order_number,erp_number,product_name,stardard,amount,unit from  ztt_order where id='" + id + "'", con);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    dt1.Load(dr);
                    con.Close();
                 

                    zongbiao1.Merge(dt1, true, MissingSchemaAction.Ignore);
                    dt1.Clear();

                }


            }
            zongbiao1.Columns["erp_number"].ColumnName = "编码";
            zongbiao1.Columns["product_order_number"].ColumnName = "工作令号";
            zongbiao1.Columns["product_name"].ColumnName = "名称";
            zongbiao1.Columns["stardard"].ColumnName = "型号";
            zongbiao1.Columns["amount"].ColumnName = "实际采购数量";
            zongbiao1.Columns["unit"].ColumnName = "单位";

            Frhetongmoban form1 = new Frhetongmoban();
            form1.dt = zongbiao1;
            form1.zhonglei = "模具部";
            form1.yonghu = yonghu;
            form1.Show();
        }

        private void dataGridViewX2_CellPainting_1(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex < 0 && e.RowIndex >= 0)
            {
                e.Paint(e.ClipBounds, DataGridViewPaintParts.All);
                Rectangle rectangle = e.CellBounds;
                rectangle.Inflate(-2, -2);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.CellStyle.Font, rectangle, e.CellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
                e.Handled = true;
            }
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            DataTable inv1 = new DataTable();
            inv1.Columns.Add("state");
            inv1.Columns["state"].DataType = Type.GetType("System.String");
            string conn = "Data Source=10.15.1.252;User ID=root;Password=root;DataBase=zkxj_erp_new";
            MySqlConnection con = new MySqlConnection(conn);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select a.id,a.product_order_number,a.zttordertime,a.client,a.product_name,a.amount,a.supplier_name,a.End_data,a.send_time,a.state,a.contract_number,a.erp_number,a.stardard,a.cost_single_price,a.unit,b.xt_userinfo_realName  from ztt_order a,xt_userinfo b where cato_type='outside' and a.apply_id=b.xt_userinfo_id ORDER BY (left(product_order_number, 2)+0) DESC,(substring(product_order_number, 7)+0) DESC ", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            inv1.Load(dr);
            DataTable newdt = new DataTable();
            newdt = inv1.Clone();

            DataRow[] rows = inv1.Select("product_order_number like '%" + txtgonglinghao.Text.Trim() + "%'");
            foreach (DataRow row in rows)  // 将查询的结果添加到dt中； 
            {
                newdt.Rows.Add(row.ItemArray);
            }

            for (int i = 0; i < newdt.Rows.Count; i++)
            {
                string state = newdt.Rows[i]["state"].ToString();

                if (state == "61")
                {
                    newdt.Rows[i]["state"] = "1询价中";
                }

                if (state == "62")
                {
                    newdt.Rows[i]["state"] = "2技术沟通中";
                }

                if (state == "63")
                {
                    newdt.Rows[i]["state"] = "3合同编制评审中";
                }
                if (state == "64")
                {
                    newdt.Rows[i]["state"] = "4预付款审批中";
                }
                if (state == "65")
                {
                    newdt.Rows[i]["state"] = "5生产制作中";
                }
                if (state == "66")
                {
                    newdt.Rows[i]["state"] = "6提货款审批中";
                }
                if (state == "67")
                {
                    newdt.Rows[i]["state"] = "7厂验安排中";
                }
                if (state == "68")
                {
                    newdt.Rows[i]["state"] = "8整改返工中";
                }
                if (state == "69")
                {
                    newdt.Rows[i]["state"] = "9已到货";
                }
                if (state == "70")
                {
                    newdt.Rows[i]["state"] = "10已出库";
                }
                if (state != "61" && state != "62" && state != "63" && state != "64" && state != "65" && state != "66" && state != "67" && state != "68" && state != "69" && state != "70")
                {
                    newdt.Rows[i]["state"] = "";

                }

            }

            dataGridViewX2.DataSource = newdt;
            
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            DataTable inv1 = new DataTable();
            inv1.Columns.Add("state");
            inv1.Columns["state"].DataType = Type.GetType("System.String");
            string conn = "Data Source=10.15.1.252;User ID=root;Password=root;DataBase=zkxj_erp_new";
            MySqlConnection con = new MySqlConnection(conn);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select id,Product_order_number,purchase_name,purchase_stardard,material,amount,hope_end_data,apply_time,supply_name,single_price,contract_number,state,erp_number,unit,comment  from ztt_purchase order by apply_time desc ", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            inv1.Load(dr);
            DataTable newdt = new DataTable();
            newdt = inv1.Clone();


            DataRow[] rows = inv1.Select("product_order_number like '%" + txtgonglinghao2.Text.Trim() + "%'");
            foreach (DataRow row in rows)  // 将查询的结果添加到dt中； 
            {
                newdt.Rows.Add(row.ItemArray);
            }

            for (int i = 0; i < newdt.Rows.Count; i++)
            {
                string state = newdt.Rows[i]["state"].ToString();

                if (state == "61")
                {
                    newdt.Rows[i]["state"] = "1询价中";
                }

                if (state == "62")
                {
                    newdt.Rows[i]["state"] = "2技术沟通中";
                }

                if (state == "63")
                {
                    newdt.Rows[i]["state"] = "3合同编制评审中";
                }
                if (state == "64")
                {
                    newdt.Rows[i]["state"] = "4预付款审批中";
                }
                if (state == "65")
                {
                    newdt.Rows[i]["state"] = "5生产制作中";
                }
                if (state == "66")
                {
                    newdt.Rows[i]["state"] = "6提货款审批中";
                }
                if (state == "67")
                {
                    newdt.Rows[i]["state"] = "7厂验安排中";
                }
                if (state == "68")
                {
                    newdt.Rows[i]["state"] = "8整改返工中";
                }
                if (state == "69")
                {
                    newdt.Rows[i]["state"] = "9已到货";
                }
                if (state == "70")
                {
                    newdt.Rows[i]["state"] = "10已出库";
                }
                if (state != "61" && state != "62" && state != "63" && state != "64" && state != "65" && state != "66" && state != "67" && state != "68" && state != "69" && state != "70")
                {
                    newdt.Rows[i]["state"] = "";

                }

            }

            dataGridViewX1.DataSource = newdt;
        }

        private void dataGridViewX1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex < 0 && e.RowIndex >= 0)
            {
                e.Paint(e.ClipBounds, DataGridViewPaintParts.All);
                Rectangle rectangle = e.CellBounds;
                rectangle.Inflate(-2, -2);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.CellStyle.Font, rectangle, e.CellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
                e.Handled = true;
            }
        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            DataTable inv2 = new DataTable();
            inv2.Columns.Add("state");
            inv2.Columns["state"].DataType = Type.GetType("System.String");
            string conn2 = "Data Source=10.15.1.252;User ID=root;Password=root;DataBase=zkxj_erp_new";
            MySqlConnection con2 = new MySqlConnection(conn2);
            con2.Open();
            MySqlCommand cmd2 = new MySqlCommand("select id,Product_order_number,purchase_name,purchase_stardard,material,amount,hope_end_data,apply_time,supply_name,contract_number,state,unit,comment  from ztt_purchase where end_data='' ", con2);
            MySqlDataReader dr2 = cmd2.ExecuteReader();
            inv2.Load(dr2);

            for (int i = 0; i < inv2.Rows.Count; i++)
            {
                string state = inv2.Rows[i]["state"].ToString();

                if (state == "61")
                {
                    inv2.Rows[i]["state"] = "1询价中";
                }

                if (state == "62")
                {
                    inv2.Rows[i]["state"] = "2技术沟通中";
                }

                if (state == "63")
                {
                    inv2.Rows[i]["state"] = "3合同编制评审中";
                }
                if (state == "64")
                {
                    inv2.Rows[i]["state"] = "4预付款审批中";
                }
                if (state == "65")
                {
                    inv2.Rows[i]["state"] = "5生产制作中";
                }
                if (state == "66")
                {
                    inv2.Rows[i]["state"] = "6提货款审批中";
                }
                if (state == "67")
                {
                    inv2.Rows[i]["state"] = "7厂验安排中";
                }
                if (state == "68")
                {
                    inv2.Rows[i]["state"] = "8整改返工中";
                }
                if (state == "69")
                {
                    inv2.Rows[i]["state"] = "9已到货";
                }
                if (state == "70")
                {
                    inv2.Rows[i]["state"] = "10已出库";
                }
                if (state != "61" && state != "62" && state != "63" && state != "64" && state != "65" && state != "66" && state != "67" && state != "68" && state != "69" && state != "70")
                {
                    inv2.Rows[i]["state"] = "";

                }

            }


            dataGridViewX1.DataSource = inv2;
        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {

            DataTable dt1 = new DataTable();
            DataTable zongbiao1 = new DataTable();
            dt1.Columns.Add("id");
            dt1.Columns.Add("Product_order_number");
            dt1.Columns.Add("erp_number");
            dt1.Columns.Add("purchase_name");
            dt1.Columns.Add("purchase_stardard");
            dt1.Columns.Add("amount");
            dt1.Columns.Add("unit");
            dt1.Columns.Add("采购单价");
            dt1.Columns.Add("总价");
            

            zongbiao1.Columns.Add("id");
            zongbiao1.Columns.Add("Product_order_number");
            zongbiao1.Columns.Add("erp_number");
            zongbiao1.Columns.Add("purchase_name");
            zongbiao1.Columns.Add("purchase_stardard");
            zongbiao1.Columns.Add("amount");
            zongbiao1.Columns.Add("unit");
            zongbiao1.Columns.Add("采购单价");
            zongbiao1.Columns.Add("总价");



            for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
            {
                string shaixuan = Convert.ToString(dataGridViewX1.Rows[i].Cells["筛选1"].Value);
                if (shaixuan == "1")
                {

                    string id = Convert.ToString(dataGridViewX1.Rows[i].Cells["id1"].Value);

                    string conn = "Data Source=10.15.1.252;User ID=root;Password=root;DataBase=zkxj_erp_new";
                    MySqlConnection con = new MySqlConnection(conn);
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("select id,Product_order_number,erp_number,purchase_name,purchase_stardard,amount,unit from  ztt_purchase where id='" + id + "'", con);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    dt1.Load(dr);
                    con.Close();
                    //string sql1 = "select 编码,名称,型号,实际采购数量,工作令号,备注 from  tb_caigouliaodan  where id ='" + id + "' ";
                    //dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);

                    zongbiao1.Merge(dt1, true, MissingSchemaAction.Ignore);
                    dt1.Clear();

                }


            }
            zongbiao1.Columns["erp_number"].ColumnName = "编码";
            zongbiao1.Columns["Product_order_number"].ColumnName = "工作令号";
            zongbiao1.Columns["purchase_name"].ColumnName = "名称";
            zongbiao1.Columns["purchase_stardard"].ColumnName = "型号";
            zongbiao1.Columns["amount"].ColumnName = "实际采购数量";
            zongbiao1.Columns["unit"].ColumnName = "单位";

            Frhetongmoban form1 = new Frhetongmoban();
            form1.dt = zongbiao1;
            form1.zhonglei = "模具部原材料";
            form1.yonghu = yonghu;
            form1.Show();
        }

        private void 保存ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
            {
                string id = dataGridViewX1.Rows[i].Cells["id1"].Value.ToString();
                string gongfangmingcheng = Convert.ToString(dataGridViewX1.Rows[i].Cells["supply_name1"].Value);
                string hetonghao = Convert.ToString(dataGridViewX1.Rows[i].Cells["contract_number1"].Value);
                string dangqianzhuangtai = dataGridViewX1.Rows[i].Cells["state1"].Value.ToString();
                string danwei = dataGridViewX1.Rows[i].Cells["unit1"].Value.ToString();
                string shuliang = dataGridViewX1.Rows[i].Cells["amount1"].Value.ToString();
                if (dangqianzhuangtai == "1询价中")
                {
                    dangqianzhuangtai = "61";
                }
                if (dangqianzhuangtai == "2技术沟通中")
                {
                    dangqianzhuangtai = "62";
                }
                if (dangqianzhuangtai == "3合同编制评审中")
                {
                    dangqianzhuangtai = "63";
                }
                if (dangqianzhuangtai == "4预付款审批中")
                {
                    dangqianzhuangtai = "64";
                }
                if (dangqianzhuangtai == "5生产制作中")
                {
                    dangqianzhuangtai = "65";
                }
                if (dangqianzhuangtai == "6提货款审批中")
                {
                    dangqianzhuangtai = "66";
                }
                if (dangqianzhuangtai == "7厂验安排中")
                {
                    dangqianzhuangtai = "66";
                }
                if (dangqianzhuangtai == "8整改返工中")
                {
                    dangqianzhuangtai = "68";
                }
                if (dangqianzhuangtai == "9已到货")
                {
                    dangqianzhuangtai = "69";
                }
                if (dangqianzhuangtai == "10已出库")
                {
                    dangqianzhuangtai = "70";
                }
                if (dangqianzhuangtai == "")
                {
                    dangqianzhuangtai = "55";
                }

                string conn = "Data Source=10.15.1.252;User ID=root;Password=root;DataBase=zkxj_erp_new";
                MySqlConnection con = new MySqlConnection(conn);
                con.Open();
                string sql = "update  ztt_purchase set state='" + dangqianzhuangtai + "',supply_name='" + gongfangmingcheng + "',contract_number='" + hetonghao + "',unit='" + danwei + "',amount='" + shuliang + "' where id='" + id + "'";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteScalar();
                con.Close();
            }
            MessageBox.Show("保存成功！");
        }

        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonItem7_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
            {
                if (Convert.ToString(dataGridViewX1.Rows[i].Cells["筛选1"].Value) == "1")
                {
                    string id = dataGridViewX1.Rows[i].Cells["id1"].Value.ToString();
                    qingdan += id + "|";

                }
                
            }

            MessageBox.Show("已加入购物车！");
           
            
        }

        private void buttonItem8_Click(object sender, EventArgs e)
        {

            DataTable dt1 = new DataTable();
            DataTable zongbiao1 = new DataTable();
            dt1.Columns.Add("id");
            dt1.Columns.Add("Product_order_number");
            dt1.Columns.Add("erp_number");
            dt1.Columns.Add("purchase_name");
            dt1.Columns.Add("purchase_stardard");
            dt1.Columns.Add("amount");
            dt1.Columns.Add("unit");
            dt1.Columns.Add("采购单价");
            dt1.Columns.Add("总价");


            zongbiao1.Columns.Add("id");
            zongbiao1.Columns.Add("Product_order_number");
            zongbiao1.Columns.Add("erp_number");
            zongbiao1.Columns.Add("purchase_name");
            zongbiao1.Columns.Add("purchase_stardard");
            zongbiao1.Columns.Add("amount");
            zongbiao1.Columns.Add("unit");
            zongbiao1.Columns.Add("采购单价");
            zongbiao1.Columns.Add("总价");

            string[] strArray = qingdan.Split('|'); //字符串转数组

            for (int i = 0; i < strArray.Length; i++)
            {
               
            
                string conn = "Data Source=10.15.1.252;User ID=root;Password=root;DataBase=zkxj_erp_new";
                MySqlConnection con = new MySqlConnection(conn);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select id,Product_order_number,erp_number,purchase_name,purchase_stardard,amount,unit from  ztt_purchase where id='" + strArray[i] + "'", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                dt1.Load(dr);
                con.Close();
                //string sql1 = "select 编码,名称,型号,实际采购数量,工作令号,备注 from  tb_caigouliaodan  where id ='" + id + "' ";
                //dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);

                zongbiao1.Merge(dt1, true, MissingSchemaAction.Ignore);
                dt1.Clear();



            }
            zongbiao1.Columns["erp_number"].ColumnName = "编码";
            zongbiao1.Columns["Product_order_number"].ColumnName = "工作令号";
            zongbiao1.Columns["purchase_name"].ColumnName = "名称";
            zongbiao1.Columns["purchase_stardard"].ColumnName = "型号";
            zongbiao1.Columns["amount"].ColumnName = "实际采购数量";
            zongbiao1.Columns["unit"].ColumnName = "单位";

            Frhetongmoban form1 = new Frhetongmoban();
            form1.dt = zongbiao1;
            form1.zhonglei = "模具部原材料";
            form1.yonghu = yonghu;
            form1.ShowDialog();
        }

        private void buttonItem9_Click(object sender, EventArgs e)
        {
            qingdan= "";
            MessageBox.Show("已清空！");
        }

        private void buttonItem10_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewX2.Rows.Count; i++)
            {
                if (Convert.ToString(dataGridViewX2.Rows[i].Cells["筛选"].Value) == "1")
                {
                    string id = dataGridViewX2.Rows[i].Cells["id"].Value.ToString();
                    qingdan1 += id + "|";

                }

            }

            MessageBox.Show("已加入购物车！");
        }

        private void buttonItem11_Click(object sender, EventArgs e)
        {

            DataTable dt1 = new DataTable();
            DataTable zongbiao1 = new DataTable();
            dt1.Columns.Add("id");
            dt1.Columns.Add("product_order_number");
            dt1.Columns.Add("erp_number");
            dt1.Columns.Add("product_name");
            dt1.Columns.Add("stardard");
            dt1.Columns.Add("unit");
            dt1.Columns.Add("amount");
            dt1.Columns.Add("采购单价");
            dt1.Columns.Add("总价");

            zongbiao1.Columns.Add("id");
            zongbiao1.Columns.Add("product_order_number");
            zongbiao1.Columns.Add("erp_number");
            zongbiao1.Columns.Add("product_name");
            zongbiao1.Columns.Add("stardard");
            zongbiao1.Columns.Add("amount");
            zongbiao1.Columns.Add("unit");
            zongbiao1.Columns.Add("采购单价");
            zongbiao1.Columns.Add("总价");


            string[] strArray = qingdan1.Split('|'); //字符串转数组

            for (int i = 0; i < strArray.Length; i++)
            {
              
                    string conn = "Data Source=10.15.1.252;User ID=root;Password=root;DataBase=zkxj_erp_new";
                    MySqlConnection con = new MySqlConnection(conn);
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("select id,product_order_number,erp_number,product_name,stardard,amount,unit from  ztt_order where id='" + strArray[i] + "'", con);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    dt1.Load(dr);
                    con.Close();


                    zongbiao1.Merge(dt1, true, MissingSchemaAction.Ignore);
                    dt1.Clear();
                
            }
            zongbiao1.Columns["erp_number"].ColumnName = "编码";
            zongbiao1.Columns["product_order_number"].ColumnName = "工作令号";
            zongbiao1.Columns["product_name"].ColumnName = "名称";
            zongbiao1.Columns["stardard"].ColumnName = "型号";
            zongbiao1.Columns["amount"].ColumnName = "实际采购数量";
            zongbiao1.Columns["unit"].ColumnName = "单位";

            Frhetongmoban form1 = new Frhetongmoban();
            form1.dt = zongbiao1;
            form1.zhonglei = "模具部";
            form1.yonghu = yonghu;
            form1.ShowDialog();
        }

        private void buttonItem12_Click(object sender, EventArgs e)
        {
            qingdan1 = "";
            MessageBox.Show("已清空！");
        }
    }
}
