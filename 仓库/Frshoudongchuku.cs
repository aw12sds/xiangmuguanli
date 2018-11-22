using DevComponents.DotNetBar;
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
    public partial class Frshoudongchuku : Office2007Form
    {
        public Frshoudongchuku()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string[] daohuo;
        public string id;
        public string shijichuhuo;
        
        public string yonghu;
        public string shijicaigou;
        public string leixing = "";
        private void Frshoudongchuku_Load(object sender, EventArgs e)
        {
            shijichuhuo = "";
            shijicaigou = "";          
            string sql1 = " select 工作令号,项目名称,设备名称,编码,型号,名称,制造类型,实际采购数量,实际到货数量,出库数量,库位号,合同号,供方名称  from tb_caigouliaodan where id='" + id + "'";
            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            txtgongzuolinghao.Text = dt.Rows[0]["工作令号"].ToString();
            txtxiangmumingcheng.Text = dt.Rows[0]["项目名称"].ToString();
            txtshebeimingcheng.Text = dt.Rows[0]["设备名称"].ToString();
            txtbianma.Text = dt.Rows[0]["编码"].ToString();
            txtxinghao.Text = dt.Rows[0]["型号"].ToString();
            txtmingcheng.Text = dt.Rows[0]["名称"].ToString();
            txtzhizaoleixing.Text = dt.Rows[0]["制造类型"].ToString();
            txtshijicaigoushuliang.Text = dt.Rows[0]["实际采购数量"].ToString();
            txtshijidaohuo.Text = dt.Rows[0]["实际到货数量"].ToString();
            txtchuku.Text = dt.Rows[0]["出库数量"].ToString();
            txtkuweihao.Text = dt.Rows[0]["库位号"].ToString();
            txthetonghao.Text = dt.Rows[0]["合同号"].ToString();           
            shijichuhuo = dt.Rows[0]["出库数量"].ToString();
            shijicaigou = dt.Rows[0]["实际采购数量"].ToString();
            
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (shijichuhuo == "")
            {
               
                if (id != "")
                {
                    if (txtshijidaohuo.Text == "")
                    {
                        MessageBox.Show("该零件没有入库，无法出库！");
                        return;
                    }
                    if (txtshijidaohuo.Text == "")
                    {
                        MessageBox.Show("该零件没有入库，无法出库！");
                        return;
                    }
                    if (Convert.ToDouble(txtshuru.Text) > Convert.ToDouble(shijicaigou))
                    {
                        MessageBox.Show("出库数量超过实际采购数量，请重新输入！");
                        return;

                    }

                    if (txtshuru.Text.Trim() == shijicaigou)
                    {
                        string sql = "update tb_caigouliaodan set 出库数量='" + txtshuru.Text.Trim() + "',出库确认=1,出库时间='" + DateTime.Now + "',当前状态='10已出库',库存数量=0  where id='" + id + "'";

                        SQLhelp.ExecuteScalar(sql, CommandType.Text);
                        string sql1 = " select 工作令号,项目名称,设备名称,编码,型号,名称,制造类型,实际采购数量,单位,采购单价,合同号,采购单价,实际到货数量,库位号,供方名称 from tb_caigouliaodan where id='" + id + "'";
                        DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                        txtgongzuolinghao.Text = dt.Rows[0]["工作令号"].ToString();
                        txtxiangmumingcheng.Text = dt.Rows[0]["项目名称"].ToString();
                        txtshebeimingcheng.Text = dt.Rows[0]["设备名称"].ToString();
                        txtbianma.Text = dt.Rows[0]["编码"].ToString();
                        txtxinghao.Text = dt.Rows[0]["型号"].ToString();
                        txtmingcheng.Text = dt.Rows[0]["名称"].ToString();
                        txtzhizaoleixing.Text = dt.Rows[0]["制造类型"].ToString();
                        txtshijicaigoushuliang.Text = dt.Rows[0]["实际采购数量"].ToString();
                        txtshijidaohuo.Text = dt.Rows[0]["实际到货数量"].ToString();
                        string sql123456 = "select 库位号 from tb_ruku where 定位='" + id + "'";
                        txtkuweihao.Text = SQLhelp.ExecuteScalar(sql123456, CommandType.Text).ToString();
                        txthetonghao.Text = dt.Rows[0]["合同号"].ToString();
                        string danjia = dt.Rows[0]["采购单价"].ToString(); ;
                        if (danjia == "")
                        {
                            danjia = "0";
                        }
                        double zongjia = Convert.ToDouble(danjia) * Convert.ToDouble(txtshuru.Text.Trim());
                        string sqlll = "select 料单类型 from tb_caigouliaodan where id='" + id + "'";
                        string leixing = SQLhelp.ExecuteScalar(sqlll, CommandType.Text).ToString();
                        string sql12 = "insert into tb_chuku (工作令号,项目名称,设备名称,编码,型号,名称,制造类型,实际采购数量,出库数量,出库时间,出库人,定位,单位,合同号,采购单价,总价,供方名称,库位号,料单类型) values ('" + txtgongzuolinghao.Text + "','" + txtxiangmumingcheng.Text + "','" + txtshebeimingcheng.Text + "','" + txtbianma.Text + "','" + txtxinghao.Text + "','" + txtmingcheng.Text + "','" + txtzhizaoleixing.Text + "','" + txtshijicaigoushuliang.Text + "','" + txtshuru.Text + "','" + DateTime.Now + "','" + yonghu + "','" + id + "','" + dt.Rows[0]["单位"].ToString() + "','" + txthetonghao.Text + "','" + danjia + "','" + zongjia + "','" + dt.Rows[0]["供方名称"].ToString() + "','"+txtkuweihao.Text.Trim()+"','"+leixing+"')";
                        SQLhelp.ExecuteScalar(sql12, CommandType.Text);
                        this.DialogResult = DialogResult.OK;
                        MessageBox.Show("登记成功！");
                        this.Close();
                    }

                    if (txtshuru.Text.Trim() != shijicaigou)
                    {
                        string sql12345 = "select 库存数量 from tb_caigouliaodan   where id='" + id + "'";
                        double kucun = Convert.ToDouble(SQLhelp.ExecuteScalar(sql12345, CommandType.Text));

                        if (kucun < Convert.ToDouble(txtshuru.Text.Trim()))
                        {
                            MessageBox.Show("出库数量超过库存数量！");
                            return;

                        }
                        if (kucun >= Convert.ToDouble(txtshuru.Text.Trim()))
                        {
                            double kucunshu = kucun - Convert.ToDouble(txtshuru.Text.Trim());
                            string sql = "update tb_caigouliaodan set 出库数量='" + txtshuru.Text.Trim() + "',库存数量='" + kucunshu + "'  where id='" + id + "'";

                            SQLhelp.ExecuteScalar(sql, CommandType.Text);
                            string sql1 = " select 工作令号,项目名称,设备名称,编码,型号,名称,制造类型,实际采购数量,单位,采购单价,合同号,采购单价,供方名称 from tb_caigouliaodan where id='" + id + "'";
                            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                            txtgongzuolinghao.Text = dt.Rows[0]["工作令号"].ToString();
                            txtxiangmumingcheng.Text = dt.Rows[0]["项目名称"].ToString();
                            txtshebeimingcheng.Text = dt.Rows[0]["设备名称"].ToString();
                            txtbianma.Text = dt.Rows[0]["编码"].ToString();
                            txtxinghao.Text = dt.Rows[0]["型号"].ToString();
                            txtmingcheng.Text = dt.Rows[0]["名称"].ToString();
                            txtzhizaoleixing.Text = dt.Rows[0]["制造类型"].ToString();
                            txtshijicaigoushuliang.Text = dt.Rows[0]["实际采购数量"].ToString();
                            txthetonghao.Text = dt.Rows[0]["合同号"].ToString();
                            string danjia = dt.Rows[0]["采购单价"].ToString();
                            string sql123456 = "select 库位号 from tb_ruku where 定位='" + id + "'";
                            txtkuweihao.Text = SQLhelp.ExecuteScalar(sql123456, CommandType.Text).ToString();
                            
                            if (danjia == "")
                            {
                                danjia = "0";
                            }
                            double zongjia = Convert.ToDouble(danjia) * Convert.ToDouble(txtshuru.Text.Trim());
                            string sqlll = "select 料单类型 from tb_caigouliaodan where id='" + id + "'";
                            string leixing = SQLhelp.ExecuteScalar(sqlll, CommandType.Text).ToString();
                            string sql12 = "insert into tb_chuku (工作令号,项目名称,设备名称,编码,型号,名称,制造类型,实际采购数量,出库数量,出库时间,出库人,定位,单位,合同号,采购单价,总价,供方名称,库位号,料单类型) values ('" + txtgongzuolinghao.Text + "','" + txtxiangmumingcheng.Text + "','" + txtshebeimingcheng.Text + "','" + txtbianma.Text + "','" + txtxinghao.Text + "','" + txtmingcheng.Text + "','" + txtzhizaoleixing.Text + "','" + txtshijicaigoushuliang.Text + "','" + txtshuru.Text + "','" + DateTime.Now + "','" + yonghu + "','" + id + "','" + dt.Rows[0]["单位"].ToString() + "','" + txthetonghao.Text + "','" + danjia + "','" + zongjia + "','" + dt.Rows[0]["供方名称"].ToString() + "','"+txtkuweihao.Text+"','"+leixing+"')";
                            SQLhelp.ExecuteScalar(sql12, CommandType.Text);
                            this.DialogResult = DialogResult.OK;
                            MessageBox.Show("登记成功！");
                            this.Close();

                        }
                    }
                }
               

            }

            if (shijichuhuo != "")
            {
                if (id == "")
                {
                    MessageBox.Show("先扫码！");
                    return;

                }
                if (id != "")
                {
                    if (txtshijidaohuo.Text == "")
                    {
                        MessageBox.Show("该零件没有入库，无法出库！");
                        return;

                    }
                    double querenchuhuo = Convert.ToDouble(shijichuhuo) + Convert.ToDouble(txtshuru.Text);
                    if (querenchuhuo > Convert.ToDouble(shijicaigou))
                    {
                        MessageBox.Show("输入数量超过实际采购数量，请重新输入！");
                        return;

                    }
                    if (querenchuhuo <= Convert.ToDouble(shijicaigou))
                    {
                        if (querenchuhuo < Convert.ToDouble(shijicaigou))
                        {
                            string sql12345 = "select 库存数量 from tb_caigouliaodan   where id='" + id + "'";
                            double kucun = Convert.ToDouble(SQLhelp.ExecuteScalar(sql12345, CommandType.Text));

                            if (kucun < Convert.ToDouble(txtshuru.Text.Trim()))
                            {
                                MessageBox.Show("出库数量超过库存数量！");
                                return;

                            }
                            if (kucun >= Convert.ToDouble(txtshuru.Text.Trim()))
                            {
                                double kucunshu = kucun - Convert.ToDouble(txtshuru.Text.Trim());
                                string sql = "update tb_caigouliaodan set 出库数量='" +querenchuhuo + "',库存数量='" + kucunshu + "'  where id='" + id + "'";

                                SQLhelp.ExecuteScalar(sql, CommandType.Text);

                            }

                        }

                        if (querenchuhuo == Convert.ToDouble(shijicaigou))
                        {
                            string sql12345 = "select 库存数量 from tb_caigouliaodan   where id='" + id + "'";
                            double kucun = Convert.ToDouble(SQLhelp.ExecuteScalar(sql12345, CommandType.Text));

                            if (kucun < Convert.ToDouble(txtshuru.Text.Trim()))
                            {
                                MessageBox.Show("出库数量超过库存数量！");
                                return;

                            }
                            if (kucun >= Convert.ToDouble(txtshuru.Text.Trim()))
                            {
                                double kucunshu = kucun - Convert.ToDouble(txtshuru.Text.Trim());
                                string sql111 = "update tb_caigouliaodan set 出库数量='" + querenchuhuo + "',出库确认=1,出库时间='" + DateTime.Now + "',当前状态='10已出库',库存数量='" + kucunshu + "'  where id='" + id + "'";
                                SQLhelp.ExecuteScalar(sql111, CommandType.Text);

                            }

                        }

                        string sql1 = " select 工作令号,项目名称,设备名称,编码,型号,名称,制造类型,实际采购数量,单位,采购单价,合同号,采购单价,供方名称 from tb_caigouliaodan where id='" + id + "'";
                        DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                        txtgongzuolinghao.Text = dt.Rows[0]["工作令号"].ToString();
                        txtxiangmumingcheng.Text = dt.Rows[0]["项目名称"].ToString();
                        txtshebeimingcheng.Text = dt.Rows[0]["设备名称"].ToString();
                        txtbianma.Text = dt.Rows[0]["编码"].ToString();
                        txtxinghao.Text = dt.Rows[0]["型号"].ToString();
                        txtmingcheng.Text = dt.Rows[0]["名称"].ToString();
                        txtzhizaoleixing.Text = dt.Rows[0]["制造类型"].ToString();
                        txtshijicaigoushuliang.Text = dt.Rows[0]["实际采购数量"].ToString();
                        txthetonghao.Text = dt.Rows[0]["合同号"].ToString();
                        string danjia = dt.Rows[0]["采购单价"].ToString();
                        string sql123456 = "select 库位号 from tb_ruku where 定位='" + id + "'";
                        txtkuweihao.Text = SQLhelp.ExecuteScalar(sql123456, CommandType.Text).ToString();
                        if (danjia == "")
                        {
                            danjia = "0";
                        }
                        double zongjia = Convert.ToDouble(danjia) * Convert.ToDouble(txtshuru.Text.Trim());
                        string sqlll = "select 料单类型 from tb_caigouliaodan where id='" + id + "'";
                        string leixing = SQLhelp.ExecuteScalar(sqlll, CommandType.Text).ToString();
                        string sql12 = "insert into tb_chuku (工作令号,项目名称,设备名称,编码,型号,名称,制造类型,实际采购数量,出库数量,出库时间,出库人,定位,单位,合同号,采购单价,总价,供方名称,库位号.料单类型) values ('" + txtgongzuolinghao.Text + "','" + txtxiangmumingcheng.Text + "','" + txtshebeimingcheng.Text + "','" + txtbianma.Text + "','" + txtxinghao.Text + "','" + txtmingcheng.Text + "','" + txtzhizaoleixing.Text + "','" + txtshijicaigoushuliang.Text + "','" + txtshuru.Text + "','" + DateTime.Now + "','" + yonghu + "','" + id + "','" + dt.Rows[0]["单位"].ToString() + "','" + txthetonghao.Text + "','" + danjia + "','" + zongjia + "','" + dt.Rows[0]["供方名称"].ToString() + "','"+txtkuweihao.Text+"','"+leixing+"')";
                        SQLhelp.ExecuteScalar(sql12, CommandType.Text);
                        this.DialogResult = DialogResult.OK;
                        MessageBox.Show("登记成功！");
                        this.Close();
                    }

                }
               
            }
        }
    }
    
}
