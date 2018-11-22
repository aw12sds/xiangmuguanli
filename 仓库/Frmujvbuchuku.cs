using DevComponents.DotNetBar;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.仓库
{
    public partial class Frmujvbuchuku : Office2007Form
    {
        public Frmujvbuchuku()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string id;
        public string shijidaohuo;
        public string yonghu;
        public string shijicaigou;
        public string kucun;
        private void Frmujvbuchuku_Load(object sender, EventArgs e)
        {
            shijidaohuo = "";
            shijicaigou = "";
            kucun = "";
        
            string sql = "select id,Product_order_number,erp_number,purchase_stardard,purchase_name,amount,contract_number,ruku_amonut,chuku_amount,kucun_amount from ztt_purchase where id='" + id + "'";
            DataTable dt = Mysqlhelp.GetDataTable1(sql, CommandType.Text);
            
            txtgongzuolinghao.Text = dt.Rows[0]["Product_order_number"].ToString();
            txtbianma.Text = dt.Rows[0]["erp_number"].ToString();
            txtxinghao.Text = dt.Rows[0]["purchase_stardard"].ToString();
            txtmingcheng.Text = dt.Rows[0]["purchase_name"].ToString();
            txtshijicaigoushuliang.Text = dt.Rows[0]["amount"].ToString();
            txtshijidaohuo.Text = dt.Rows[0]["ruku_amonut"].ToString();
            txthetonghao.Text = dt.Rows[0]["contract_number"].ToString();
            txtchuku.Text= dt.Rows[0]["chuku_amount"].ToString();
            shijidaohuo = dt.Rows[0]["ruku_amonut"].ToString();
            shijicaigou = dt.Rows[0]["amount"].ToString();
            kucun = dt.Rows[0]["kucun_amount"].ToString();



        }

        private void buttonX1_Click(object sender, EventArgs e)
        {

            if (txtshuru.Text.Trim() == "")
            {

                MessageBox.Show("输入的数量不许为空！");
                return;
            }
            if (txtchuku.Text == shijicaigou)
            {
                MessageBox.Show("已全出库，不需要再出库！");
                return;
            }          
            if (txtshijidaohuo.Text == "")
            {
                MessageBox.Show("该零件没有入库，无法出库！");
                return;
            }
            if (txtchuku.Text == "")
            {

                if (id != "")
                {
                    if (Convert.ToDouble(txtshuru.Text) > Convert.ToDouble(shijicaigou))
                    {
                        MessageBox.Show("出库数量超过实际采购数量，请重新输入！");
                        return;

                    }

                    if (shijicaigou == txtshuru.Text)
                    {

                        string sql123 = "update ztt_purchase set chuku_amount='" + txtshuru.Text.Trim() + "',kucun_amount='0',state=70 where id='" + id + "'";
                        Mysqlhelp.ExecuteScalar1(sql123, CommandType.Text);
                        string sql1234 = "select id,Product_order_number,erp_number,purchase_stardard,purchase_name,amount,contract_number,ruku_amonut,chuku_amount,kucun_amount,single_price,unit,supply_name from ztt_purchase where id='" + id + "'";
                        DataTable dt = Mysqlhelp.GetDataTable1(sql1234, CommandType.Text);

                        txtgongzuolinghao.Text = dt.Rows[0]["Product_order_number"].ToString();
                        txtbianma.Text = dt.Rows[0]["erp_number"].ToString();
                        txtxinghao.Text = dt.Rows[0]["purchase_stardard"].ToString();
                        txtmingcheng.Text = dt.Rows[0]["purchase_name"].ToString();
                        txtshijicaigoushuliang.Text = dt.Rows[0]["amount"].ToString();
                        txtshijidaohuo.Text = dt.Rows[0]["ruku_amonut"].ToString();
                        txthetonghao.Text = dt.Rows[0]["contract_number"].ToString();

                        string danjia = dt.Rows[0]["single_price"].ToString();
                        if (danjia == "")
                        {
                            danjia = "0";
                        }
                        double zongjia = Convert.ToDouble(danjia) * Convert.ToDouble(txtshuru.Text.Trim());
                        string sql12 = "insert into tb_chuku (工作令号,项目名称,设备名称,编码,型号,名称,制造类型,实际采购数量,出库数量,出库时间,出库人,定位,单位,库位号,合同号,采购单价,总价,供方名称,料单类型) values ('" + txtgongzuolinghao.Text + "','" + txtxiangmumingcheng.Text + "','" + txtshebeimingcheng.Text + "','" + txtbianma.Text + "','" + txtxinghao.Text + "','" + txtmingcheng.Text + "','" + txtzhizaoleixing.Text + "','" + txtshijicaigoushuliang.Text + "','" + txtshuru.Text + "','" + DateTime.Now + "','" + yonghu + "','" + id + "','" + dt.Rows[0]["unit"].ToString() + "','" + txtkuweihao.Text.Trim() + "','" + txthetonghao.Text.Trim() + "','" + danjia + "','" + zongjia + "','" + dt.Rows[0]["supply_name"].ToString() + "','模具部原材料')";
                        SQLhelp.ExecuteScalar(sql12, CommandType.Text);
                        MessageBox.Show("登记成功！");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    if (shijicaigou != txtshuru.Text)
                    {

                        string sql12345 = "select kucun_amount from  ztt_purchase  where id='" + id + "'";
                        double kucun = Convert.ToDouble(Mysqlhelp.ExecuteScalar1(sql12345, CommandType.Text));

                        if (kucun < Convert.ToDouble(txtshuru.Text.Trim()))
                        {
                            MessageBox.Show("出库数量超过库存数量！");
                            return;

                        }

                        if (kucun >= Convert.ToDouble(txtshuru.Text.Trim()))
                        {
                            double kucunshu = kucun - Convert.ToDouble(txtshuru.Text.Trim());

                            string sql1 = "update ztt_purchase set chuku_amount='" + txtshuru.Text.Trim() + "',kucun_amount='" + txtshuru.Text.Trim() + "' where id='" + id + "'";
                            Mysqlhelp.ExecuteScalar1(sql1, CommandType.Text);
                            string sql123456 = "select id,Product_order_number,erp_number,purchase_stardard,purchase_name,amount,contract_number,ruku_amonut,chuku_amount,kucun_amount,single_price,unit,supply_name from ztt_purchase where id='" + id + "'";
                            DataTable dt = Mysqlhelp.GetDataTable1(sql123456, CommandType.Text);
                            txtgongzuolinghao.Text = dt.Rows[0]["Product_order_number"].ToString();
                            txtbianma.Text = dt.Rows[0]["erp_number"].ToString();
                            txtxinghao.Text = dt.Rows[0]["purchase_stardard"].ToString();
                            txtmingcheng.Text = dt.Rows[0]["purchase_name"].ToString();
                            txtshijicaigoushuliang.Text = dt.Rows[0]["amount"].ToString();
                            txtshijidaohuo.Text = dt.Rows[0]["ruku_amonut"].ToString();
                            txthetonghao.Text = dt.Rows[0]["contract_number"].ToString();

                            string danjia = dt.Rows[0]["single_price"].ToString();
                            if (danjia == "")
                            {
                                danjia = "0";
                            }
                            double zongjia = Convert.ToDouble(danjia) * Convert.ToDouble(txtshuru.Text.Trim());
                            string sql12 = "insert into tb_chuku (工作令号,项目名称,设备名称,编码,型号,名称,制造类型,实际采购数量,出库数量,出库时间,出库人,定位,单位,库位号,合同号,采购单价,总价,供方名称,料单类型) values ('" + txtgongzuolinghao.Text + "','" + txtxiangmumingcheng.Text + "','" + txtshebeimingcheng.Text + "','" + txtbianma.Text + "','" + txtxinghao.Text + "','" + txtmingcheng.Text + "','" + txtzhizaoleixing.Text + "','" + txtshijicaigoushuliang.Text + "','" + txtshuru.Text + "','" + DateTime.Now + "','" + yonghu + "','" + id + "','" + dt.Rows[0]["unit"].ToString() + "','" + txtkuweihao.Text.Trim() + "','" + txthetonghao.Text.Trim() + "','" + danjia + "','" + zongjia + "','" + dt.Rows[0]["supply_name"].ToString() + "','模具部原材料')";
                            SQLhelp.ExecuteScalar(sql12, CommandType.Text);
                            MessageBox.Show("登记成功！");
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                }
                

            }

            if (txtchuku.Text != "")
            {
                if (id == "")
                {
                    MessageBox.Show("先扫码！");
                    return;

                }
                if (id != "")
                {
                   
                    double querenchuhuo = Convert.ToDouble(txtchuku.Text) + Convert.ToDouble(txtshuru.Text);
                    if (querenchuhuo > Convert.ToDouble(shijicaigou))
                    {
                        MessageBox.Show("输入数量超过实际采购数量，请重新输入！");
                        return;

                    }
                    if (querenchuhuo <= Convert.ToDouble(shijicaigou))
                    {
                        if (querenchuhuo < Convert.ToDouble(shijicaigou))
                        {
                            string sql12345 = "select kucun_amount from ztt_purchase   where id='" + id + "'";
                            double kucun = Convert.ToDouble(Mysqlhelp.ExecuteScalar1(sql12345, CommandType.Text));

                            if (kucun < Convert.ToDouble(txtshuru.Text.Trim()))
                            {
                                MessageBox.Show("出库数量超过库存数量！");
                                return;

                            }
                            if (kucun >= Convert.ToDouble(txtshuru.Text.Trim()))
                            {
                                double kucunshu = kucun - Convert.ToDouble(txtshuru.Text.Trim());
                                string sql = "update ztt_purchase  set chuku_amount='" + querenchuhuo + "',kucun_amount='" + kucunshu + "'  where id='" + id + "'";

                                Mysqlhelp.ExecuteScalar1(sql, CommandType.Text);

                            }

                        }

                        if (querenchuhuo == Convert.ToDouble(shijicaigou))
                        {
                            string sql12345 = "select kucun_amount from ztt_purchase   where id='" + id + "'";
                            double kucun = Convert.ToDouble(Mysqlhelp.ExecuteScalar1(sql12345, CommandType.Text));

                            if (kucun < Convert.ToDouble(txtshuru.Text.Trim()))
                            {
                                MessageBox.Show("出库数量超过库存数量！");
                                return;

                            }
                            if (kucun >= Convert.ToDouble(txtshuru.Text.Trim()))
                            {
                                double kucunshu = kucun - Convert.ToDouble(txtshuru.Text.Trim());
                                string sql111 = "update ztt_purchase set chuku_amount='" + querenchuhuo + "',state=70,kucun_amount='" + kucunshu + "'  where id='" + id + "'";
                                Mysqlhelp.ExecuteScalar1(sql111, CommandType.Text);

                            }

                        }

                        string sql123456 = "select id,Product_order_number,erp_number,purchase_stardard,purchase_name,amount,contract_number,ruku_amonut,chuku_amount,kucun_amount,single_price,unit,supply_name from ztt_purchase where id='" + id + "'";
                        DataTable dt = Mysqlhelp.GetDataTable1(sql123456, CommandType.Text);
                        txtgongzuolinghao.Text = dt.Rows[0]["Product_order_number"].ToString();
                        txtbianma.Text = dt.Rows[0]["erp_number"].ToString();
                        txtxinghao.Text = dt.Rows[0]["purchase_stardard"].ToString();
                        txtmingcheng.Text = dt.Rows[0]["purchase_name"].ToString();
                        txtshijicaigoushuliang.Text = dt.Rows[0]["amount"].ToString();
                        txtshijidaohuo.Text = dt.Rows[0]["ruku_amonut"].ToString();
                        txthetonghao.Text = dt.Rows[0]["contract_number"].ToString();

                        string danjia = dt.Rows[0]["single_price"].ToString();
                        if (danjia == "")
                        {
                            danjia = "0";
                        }
                        double zongjia = Convert.ToDouble(danjia) * Convert.ToDouble(txtshuru.Text.Trim());
                        string sql12 = "insert into tb_chuku (工作令号,项目名称,设备名称,编码,型号,名称,制造类型,实际采购数量,出库数量,出库时间,出库人,定位,单位,库位号,合同号,采购单价,总价,供方名称,料单类型) values ('" + txtgongzuolinghao.Text + "','" + txtxiangmumingcheng.Text + "','" + txtshebeimingcheng.Text + "','" + txtbianma.Text + "','" + txtxinghao.Text + "','" + txtmingcheng.Text + "','" + txtzhizaoleixing.Text + "','" + txtshijicaigoushuliang.Text + "','" + txtshuru.Text + "','" + DateTime.Now + "','" + yonghu + "','" + id + "','" + dt.Rows[0]["unit"].ToString() + "','" + txtkuweihao.Text.Trim() + "','" + txthetonghao.Text.Trim() + "','" + danjia + "','" + zongjia + "','" + dt.Rows[0]["supply_name"].ToString() + "','模具部原材料')";
                        SQLhelp.ExecuteScalar(sql12, CommandType.Text);
                        MessageBox.Show("登记成功！");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }

                }
            }
        }
    }
}
