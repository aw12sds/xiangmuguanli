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
    public partial class Frshoudngruku : Office2007Form
    {
        public Frshoudngruku()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string id;
        public string leixing = "";
        public string[] daohuo;
        public string shijidaohuo;
        public string yonghu;
        public string shijicaigou;
        public string kucun;
        private void Frshoudngruku_Load(object sender, EventArgs e)
        {

            shijidaohuo = "";
            shijicaigou = "";

            kucun = "";

            string sql1 = " select 工作令号,项目名称,设备名称,编码,型号,名称,制造类型,实际采购数量,实际到货数量,合同号,库存数量 from tb_caigouliaodan where id='" + id + "'";
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
            txthetonghao.Text = dt.Rows[0]["合同号"].ToString();

            shijidaohuo = dt.Rows[0]["实际到货数量"].ToString();
            shijicaigou = dt.Rows[0]["实际采购数量"].ToString();
            kucun = dt.Rows[0]["库存数量"].ToString();
            if (kucun == "")
            {
                kucun = "0";
            }

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (txtshuru.Text.Trim() == "")
            {

                MessageBox.Show("输入的数量不许为空！");
                return;
            }
            if (shijidaohuo == shijicaigou)
            {
                MessageBox.Show("已全入库，不需要再入库！");
                return;
            }
            if (txtkuweihao.Text.Trim() == "")
            {
                MessageBox.Show("请输入库位号！");
                return;
            }

            if (txtbianma.Text.Trim() == "")
            {
                MessageBox.Show("没有编码拒绝入库！");
                return;
            }
            if (txtshijicaigoushuliang.Text.Trim() == "")
            {
                MessageBox.Show("数量为空！");
                return;
            }
            if (shijidaohuo == "")
            {
                if (id != "")
                {
                    if (Convert.ToDouble(txtshuru.Text) > Convert.ToDouble(shijicaigou))
                    {
                        MessageBox.Show("入库数量超过实际采购数量，请重新输入！");
                        return;
                    }
                    if (txtkuweihao.Text == "")
                    {
                        MessageBox.Show("请输入库位号！");
                        return;
                    }
                    if (shijicaigou == txtshuru.Text)
                    {
                        string sql111 = "update tb_caigouliaodan set 实际到货数量='" + txtshuru.Text.Trim() + "',库位号='" + txtkuweihao.Text + "',仓库确认=1,仓库确认时间='" + DateTime.Now + "',当前状态='9已到货',库存数量='" + txtshuru.Text.Trim() + "',到货时间='" + DateTime.Now + "',区分='新' where id='" + id + "'";
                        SQLhelp.GetDataTable(sql111, CommandType.Text);
                        string sql1 = " select 工作令号,项目名称,设备名称,编码,型号,名称,制造类型,实际采购数量,单位,合同号,采购单价,供方名称 from tb_caigouliaodan where id='" + id + "'";
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
                        if (danjia == "")
                        {
                            danjia = "0";
                        }
                        double zongjia = Convert.ToDouble(danjia) * Convert.ToDouble(txtshuru.Text.Trim());
                        string sqlll = "select 料单类型 from tb_caigouliaodan where id='" + id + "'";
                        string leixing = SQLhelp.ExecuteScalar(sqlll, CommandType.Text).ToString();
                        string sql12 = "insert into tb_ruku (工作令号,项目名称,设备名称,编码,型号,名称,制造类型,实际采购数量,入库数量,入库时间,入库人,定位,单位,库位号,合同号,采购单价,总价,供方名称,料单类型,区分) values ('" + txtgongzuolinghao.Text + "','" + txtxiangmumingcheng.Text + "','" + txtshebeimingcheng.Text + "','" + txtbianma.Text + "','" + txtxinghao.Text + "','" + txtmingcheng.Text + "','" + txtzhizaoleixing.Text + "','" + txtshijicaigoushuliang.Text + "','" + txtshuru.Text + "','" + DateTime.Now + "','" + yonghu + "','" + id + "','" + dt.Rows[0]["单位"].ToString() + "','" + txtkuweihao.Text.Trim() + "','" + txthetonghao.Text.Trim() + "','" + danjia + "','" + zongjia + "','" + dt.Rows[0]["供方名称"].ToString() + "','" + leixing + "','新')";
                        SQLhelp.ExecuteScalar(sql12, CommandType.Text);
                        this.DialogResult = DialogResult.OK;
                        MessageBox.Show("登记成功！");
                        this.Close();
                    }
                    if (shijicaigou != txtshuru.Text)
                    {

                        string sql111 = "update tb_caigouliaodan set 实际到货数量='" + txtshuru.Text.Trim() + "',库位号='" + txtkuweihao.Text + "',库存数量='" + txtshuru.Text.Trim() + "',到货时间='" + DateTime.Now + "',区分='新' where id='" + id + "'";
                        SQLhelp.GetDataTable(sql111, CommandType.Text);                                       
                        string sql1 = " select 工作令号,项目名称,设备名称,编码,型号,名称,制造类型,实际采购数量,单位,合同号,采购单价,供方名称 from tb_caigouliaodan where id='" + id + "'";
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
                        if (danjia == "")
                        {
                            danjia = "0";
                        }
                        double zongjia = Convert.ToDouble(danjia) * Convert.ToDouble(txtshuru.Text.Trim());
                        string sqlll = "select 料单类型 from tb_caigouliaodan where id='" + id + "'";
                        string leixing = SQLhelp.ExecuteScalar(sqlll, CommandType.Text).ToString();
                        string sql12 = "insert into tb_ruku (工作令号,项目名称,设备名称,编码,型号,名称,制造类型,实际采购数量,入库数量,入库时间,入库人,定位,单位,库位号,合同号,采购单价,总价,供方名称,料单类型,区分) values ('" + txtgongzuolinghao.Text + "','" + txtxiangmumingcheng.Text + "','" + txtshebeimingcheng.Text + "','" + txtbianma.Text + "','" + txtxinghao.Text + "','" + txtmingcheng.Text + "','" + txtzhizaoleixing.Text + "','" + txtshijicaigoushuliang.Text + "','" + txtshuru.Text + "','" + DateTime.Now + "','" + yonghu + "','" + id + "','" + dt.Rows[0]["单位"].ToString() + "','" + txtkuweihao.Text.Trim() + "','" + txthetonghao.Text.Trim() + "','" + danjia + "','" + zongjia + "','" + dt.Rows[0]["供方名称"].ToString() + "','" + leixing + "','新')";
                        SQLhelp.ExecuteScalar(sql12, CommandType.Text);
                        this.DialogResult = DialogResult.OK;
                        MessageBox.Show("登记成功！");
                        this.Close();
                    }
                }
            }
            if (shijidaohuo != "")
            {
                if (id == "")
                {
                    MessageBox.Show("先扫码！");
                    return;

                }
                if (id != "")
                {
                    double querendaohuo = Convert.ToDouble(shijidaohuo) + Convert.ToDouble(txtshuru.Text);
                    if (querendaohuo > Convert.ToDouble(shijicaigou))
                    {
                        MessageBox.Show("输入数量超过实际采购数量，请重新输入！");
                        return;
                    }
                    if (querendaohuo <= Convert.ToDouble(shijicaigou))
                    {
                        if (querendaohuo < Convert.ToDouble(shijicaigou))
                        {
                            double kucunshu = Convert.ToDouble(txtshuru.Text) + Convert.ToDouble(kucun);
                            double ruku = Convert.ToDouble(txtshuru.Text) + Convert.ToDouble(shijidaohuo);
                            string sql111 = "update tb_caigouliaodan set 实际到货数量='" + ruku + "',库位号='" + txtkuweihao.Text + "',库存数量='" + kucunshu + "',到货时间='" + DateTime.Now + "',区分='新' where id='" + id + "'";
                            SQLhelp.GetDataTable(sql111, CommandType.Text);                                           
                        }
                        if (querendaohuo == Convert.ToDouble(shijicaigou))
                        {
                            double kucunshu = Convert.ToDouble(txtshuru.Text) + Convert.ToDouble(kucun);
                            double ruku = Convert.ToDouble(txtshuru.Text) + Convert.ToDouble(shijidaohuo);

                            string sql111 = "update tb_caigouliaodan set 实际到货数量='" + shijicaigou + "',库位号='" + txtkuweihao.Text + "',仓库确认=1,仓库确认时间='" + DateTime.Now + "',当前状态='9已到货',库存数量='" + kucunshu + "',到货时间='" + DateTime.Now + "',区分='新' where id='" + id + "'";
                            SQLhelp.GetDataTable(sql111, CommandType.Text);                           
                        }
                        string sql1 = " select 工作令号,项目名称,设备名称,编码,型号,名称,制造类型,实际采购数量,单位,合同号,采购单价,供方名称 from tb_caigouliaodan where id='" + id + "'";
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
                        if (danjia == "")
                        {
                            danjia = "0";
                        }
                        double zongjia = Convert.ToDouble(danjia) * Convert.ToDouble(txtshuru.Text.Trim());
                        string sqlll = "select 料单类型 from tb_caigouliaodan where id='" + id + "'";
                        string leixing = SQLhelp.ExecuteScalar(sqlll, CommandType.Text).ToString();
                        string sql12 = "insert into tb_ruku (工作令号,项目名称,设备名称,编码,型号,名称,制造类型,实际采购数量,入库数量,入库时间,入库人,定位,单位,库位号,合同号,采购单价,总价,供方名称,料单类型,区分) values ('" + txtgongzuolinghao.Text + "','" + txtxiangmumingcheng.Text + "','" + txtshebeimingcheng.Text + "','" + txtbianma.Text + "','" + txtxinghao.Text + "','" + txtmingcheng.Text + "','" + txtzhizaoleixing.Text + "','" + txtshijicaigoushuliang.Text + "','" + txtshuru.Text + "','" + DateTime.Now + "','" + yonghu + "','" + id + "','" + dt.Rows[0]["单位"].ToString() + "','" + txtkuweihao.Text.Trim() + "','" + txthetonghao.Text.Trim() + "','" + danjia + "','" + zongjia + "','" + dt.Rows[0]["供方名称"].ToString() + "','" + leixing + "','新')";
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
