using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace 项目管理系统.仓库
{
    public partial class Frchukutongjiji : DevExpress.XtraEditors.XtraForm
    {
        public Frchukutongjiji()
        {
            InitializeComponent();
        }
        public string yonghu;         
        private void Frchukutongjiji_Load(object sender, EventArgs e)
        {
            Reload();
            timer1.Start();
        }
        public void Reload()
        {
            string sql = "select * from tb_lingyong where 出库=0";
            gridControl4.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
            
        }

        private void 出库新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "仓库")
            {
                MessageBox.Show("非仓库人员无法入库！");
                return;

            }
            int[] a = gridView4.GetSelectedRows();

            foreach (int i in a)
            {

                string id = Convert.ToString(gridView4.GetRowCellValue(i, "定位"));
                string dingwei = Convert.ToString(gridView4.GetRowCellValue(i, "id"));
                string chuku = Convert.ToString(gridView4.GetRowCellValue(i, "领用数量"));
                string lingyongren = Convert.ToString(gridView4.GetRowCellValue(i, "申请人"));
                string lingyongbumen = Convert.ToString(gridView4.GetRowCellValue(i, "领用部门"));
                string miaoshu = Convert.ToString(gridView4.GetRowCellValue(i, "描述"));
                string liushuihao = Convert.ToString(gridView4.GetRowCellValue(i, "流水号"));
                string sql123 = "select * from tb_caigouliaodan where id='" + id + "'";
                DataTable dt = SQLhelp.GetDataTable(sql123, CommandType.Text);
                if (chuku == dt.Rows[0]["实际采购数量"].ToString())
                {
                    string sql12 = "update tb_caigouliaodan set 出库数量='" + chuku + "',当前状态='10已出库',库存数量=0,出库确认=1,出库时间='" + DateTime.Now + "' where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql12, CommandType.Text);
                    string sql123123 = "update tb_lingyong set 出库=1 where id='" + dingwei + "'";
                    SQLhelp.ExecuteScalar(sql123123, CommandType.Text);
                    string danjia = dt.Rows[0]["采购单价"].ToString();
                    if (danjia == "")
                    {
                        danjia = "0";
                    }
                    double zongjia = Convert.ToDouble(danjia) * Convert.ToDouble(chuku);
                    string sqlll = "select 料单类型 from tb_caigouliaodan where id='" + id + "'";
                    string leixing = SQLhelp.ExecuteScalar(sqlll, CommandType.Text).ToString();

                    string sql111 = "select * from tb_caigouliaodan where id='" + id + "'";
                    DataTable dtttt = SQLhelp.GetDataTable(sql111, CommandType.Text);
                    
                    string shuilv = dtttt.Rows[0]["税率"].ToString().Replace("%", string.Empty);
                    double shuilv1 = Convert.ToDouble(shuilv) * 0.01;                 
                    decimal jinge = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(zongjia) / (1 + shuilv1))), 2);
                    decimal shuie = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(zongjia) - Convert.ToDouble(jinge))), 2);
                    decimal jingdanjia = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(danjia) / (1 + shuilv1))), 10);                
                    string sql12345 = "insert into tb_chuku (工作令号,项目名称,设备名称,编码,型号,名称,制造类型,实际采购数量,出库数量,出库时间,出库人,定位,单位,库位号,合同号,采购单价,总价,供方名称,料单类型,领用人,流水号,描述,区分,领用部门,税率,净额,税额,净单价) values ('" + dt.Rows[0]["工作令号"].ToString() + "','" + dt.Rows[0]["项目名称"].ToString() + "','" + dt.Rows[0]["设备名称"].ToString() + "','" + dt.Rows[0]["编码"].ToString() + "','" + dt.Rows[0]["型号"].ToString() + "','" + dt.Rows[0]["名称"].ToString() + "','" + dt.Rows[0]["制造类型"].ToString() + "','" + dt.Rows[0]["实际采购数量"].ToString() + "','" + dt.Rows[0]["实际采购数量"].ToString() + "','" + DateTime.Now + "','" + yonghu + "','" + id + "','" + dt.Rows[0]["单位"].ToString() + "','" + dt.Rows[0]["库位号"].ToString() + "','" + dt.Rows[0]["合同号"].ToString() + "','" + danjia + "','" + zongjia + "','" + dt.Rows[0]["供方名称"].ToString() + "','" + leixing + "','" + lingyongren + "','" + liushuihao + "','" + miaoshu + "','新','" + lingyongbumen + "','" + dtttt.Rows[0]["税率"].ToString() + "','" + jinge + "','" + shuie + "','" + jingdanjia + "')";
                    SQLhelp.ExecuteScalar(sql12345, CommandType.Text);

                }

                if (chuku != dt.Rows[0]["实际采购数量"].ToString())
                {
                    if (Convert.ToString(dt.Rows[0]["出库数量"]) == "")
                    {
                        double lingyong = Convert.ToDouble(chuku);
                        double kucun = Convert.ToDouble(dt.Rows[0]["库存数量"]);
                        double kucunshu = kucun - Convert.ToDouble(lingyong);
                        string sql12 = "update tb_caigouliaodan set 出库数量='" + chuku + "' ,库存数量='" + kucunshu + "' where id='" + id + "'";
                        SQLhelp.GetDataTable(sql12, CommandType.Text);
                        string sql123123 = "update tb_lingyong set 出库=1 where id='" + dingwei + "'";
                        SQLhelp.ExecuteScalar(sql123123, CommandType.Text);
                        string danjia = dt.Rows[0]["采购单价"].ToString();
                        if (danjia == "")
                        {
                            danjia = "0";
                        }
                        double zongjia = Convert.ToDouble(danjia) * Convert.ToDouble(chuku);
                        string sqlll = "select 料单类型 from tb_caigouliaodan where id='" + id + "'";
                        string leixing = SQLhelp.ExecuteScalar(sqlll, CommandType.Text).ToString();


                        string sql111 = "select * from tb_caigouliaodan where id='" + id + "'";
                        DataTable dtttt = SQLhelp.GetDataTable(sql111, CommandType.Text);

                        string shuilv = dtttt.Rows[0]["税率"].ToString().Replace("%", string.Empty);
                        double shuilv1 = Convert.ToDouble(shuilv) * 0.01;
                        decimal jinge = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(zongjia) / (1 + shuilv1))), 2);
                        decimal shuie = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(zongjia) - Convert.ToDouble(jinge))), 2);
                        decimal jingdanjia = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(danjia) / (1 + shuilv1))), 10);
                        string sql12345 = "insert into tb_chuku (工作令号,项目名称,设备名称,编码,型号,名称,制造类型,实际采购数量,出库数量,出库时间,出库人,定位,单位,库位号,合同号,采购单价,总价,供方名称,料单类型,领用人,流水号,描述,区分,领用部门,税率,净额,税额,净单价) values ('" + dt.Rows[0]["工作令号"].ToString() + "','" + dt.Rows[0]["项目名称"].ToString() + "','" + dt.Rows[0]["设备名称"].ToString() + "','" + dt.Rows[0]["编码"].ToString() + "','" + dt.Rows[0]["型号"].ToString() + "','" + dt.Rows[0]["名称"].ToString() + "','" + dt.Rows[0]["制造类型"].ToString() + "','" + dt.Rows[0]["实际采购数量"].ToString() + "','" + lingyong + "','" + DateTime.Now + "','" + yonghu + "','" + id + "','" + dt.Rows[0]["单位"].ToString() + "','" + dt.Rows[0]["库位号"].ToString() + "','" + dt.Rows[0]["合同号"].ToString() + "','" + danjia + "','" + zongjia + "','" + dt.Rows[0]["供方名称"].ToString() + "','" + leixing + "','" + lingyongren + "','" + liushuihao + "','" + miaoshu + "','新','" + lingyongbumen + "','" + dtttt.Rows[0]["税率"].ToString() + "','" + jinge + "','" + shuie + "','" + jingdanjia + "')";
                        SQLhelp.ExecuteScalar(sql12345, CommandType.Text);

                    }
                    if (Convert.ToString(dt.Rows[0]["出库数量"]) != "")
                    {
                        double lingyong = Convert.ToDouble(chuku);
                        double chukushuliang = Convert.ToDouble(dt.Rows[0]["出库数量"]);
                        double kucun = Convert.ToDouble(dt.Rows[0]["库存数量"]);
                        double kucunshu = kucun - Convert.ToDouble(lingyong);
                        double heji = lingyong + chukushuliang;
                        if (heji.ToString() == dt.Rows[0]["实际采购数量"].ToString())
                        {
                            string sql12 = "update tb_caigouliaodan set 出库数量=出库数量+'" + chuku + "',当前状态='10已出库',库存数量=0,出库确认=1,出库时间='" + DateTime.Now + "' where id='" + id + "'";
                            SQLhelp.GetDataTable(sql12, CommandType.Text);
                            string sql123123 = "update tb_lingyong set 出库=1 where id='" + dingwei + "'";
                            SQLhelp.ExecuteScalar(sql123123, CommandType.Text);
                        }
                        if (heji.ToString() != dt.Rows[0]["实际采购数量"].ToString())
                        {
                            string sql12 = "update tb_caigouliaodan set 出库数量=出库数量+'" + chuku + "' ,库存数量='" + kucunshu + "' where id='" + id + "'";
                            SQLhelp.GetDataTable(sql12, CommandType.Text);
                            string sql123123 = "update tb_lingyong set 出库=1 where id='" + dingwei + "'";
                            SQLhelp.ExecuteScalar(sql123123, CommandType.Text);
                        }
                        string danjia = dt.Rows[0]["采购单价"].ToString();
                        if (danjia == "")
                        {
                            danjia = "0";
                        }
                        double zongjia = Convert.ToDouble(danjia) * Convert.ToDouble(chuku);
                        string sqlll = "select 料单类型 from tb_caigouliaodan where id='" + id + "'";
                        string leixing = SQLhelp.ExecuteScalar(sqlll, CommandType.Text).ToString();


                        string sql111 = "select * from tb_caigouliaodan where id='" + id + "'";
                        DataTable dtttt = SQLhelp.GetDataTable(sql111, CommandType.Text);

                        string shuilv = dtttt.Rows[0]["税率"].ToString().Replace("%", string.Empty);
                        double shuilv1 = Convert.ToDouble(shuilv) * 0.01;
                        decimal jinge = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(zongjia) / (1 + shuilv1))), 2);
                        decimal shuie = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(zongjia) - Convert.ToDouble(jinge))), 2);
                        decimal jingdanjia = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(danjia) / (1 + shuilv1))), 10);
                        string sql12345 = "insert into tb_chuku (工作令号,项目名称,设备名称,编码,型号,名称,制造类型,实际采购数量,出库数量,出库时间,出库人,定位,单位,库位号,合同号,采购单价,总价,供方名称,料单类型,领用人,流水号,描述,区分,领用部门,税率,净额,税额,净单价) values ('" + dt.Rows[0]["工作令号"].ToString() + "','" + dt.Rows[0]["项目名称"].ToString() + "','" + dt.Rows[0]["设备名称"].ToString() + "','" + dt.Rows[0]["编码"].ToString() + "','" + dt.Rows[0]["型号"].ToString() + "','" + dt.Rows[0]["名称"].ToString() + "','" + dt.Rows[0]["制造类型"].ToString() + "','" + dt.Rows[0]["实际采购数量"].ToString() + "','" + lingyong + "','" + DateTime.Now + "','" + yonghu + "','" + id + "','" + dt.Rows[0]["单位"].ToString() + "','" + dt.Rows[0]["库位号"].ToString() + "','" + dt.Rows[0]["合同号"].ToString() + "','" + danjia + "','" + zongjia + "','" + dt.Rows[0]["供方名称"].ToString() + "','" + leixing + "','" + lingyongren + "','" + liushuihao + "','" + miaoshu + "','新','" +lingyongbumen+ "','" + dtttt.Rows[0]["税率"].ToString() + "','" + jinge + "','" + shuie + "','" + jingdanjia + "')";
                        SQLhelp.ExecuteScalar(sql12345, CommandType.Text);
                    }
                }
            }
            MessageBox.Show("出库成功！");
            Reload();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Reload();
        }

        private void gridView4_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }
    }
}