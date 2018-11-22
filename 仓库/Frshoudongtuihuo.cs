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
    public partial class Frshoudongtuihuo : Office2007Form
    {
        public Frshoudongtuihuo()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string id;
        public string yonghu;
        public string shijichuhuo;
        public string shijicaigou;
        string kucun;
        private void Frshoudongtuihuo_Load(object sender, EventArgs e)
        {
            shijichuhuo = "";
            shijicaigou = "";
            string sql1 = " select 工作令号,项目名称,设备名称,编码,型号,名称,制造类型,实际采购数量,实际到货数量,出库数量,库位号,合同号,供方名称,库存数量  from tb_caigouliaodan where id='" + id + "'";
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
            kucun = dt.Rows[0]["库存数量"].ToString();
            if (kucun == "")
            {
                kucun = "0";
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            
            if (  kucun !="" && kucun != "0")
            {
                if (txtshijidaohuo.Text == "")
                {
                    MessageBox.Show("还未入库，无需退货！");
                    return;
                }              
                if (id == "")
                {
                    MessageBox.Show("先扫码！");
                    return;
                }
                if (id != "")
                {
                    if (Convert.ToDouble(txtshuru.Text.Trim()) > Convert.ToDouble(txtshijidaohuo.Text.Trim()))
                    {
                        MessageBox.Show("退货数量超过入库数量，请重新输入！");
                        return;
                    }
                    double shijituihuo = Convert.ToDouble(txtshijidaohuo.Text.Trim()) - Convert.ToDouble(txtshuru.Text.Trim());
                    double kucunshuliang = Convert.ToDouble(kucun) - Convert.ToDouble(txtshuru.Text.Trim());
                    string sql = "update tb_caigouliaodan set 实际到货数量='" + shijituihuo + "' , 库存数量='" + kucunshuliang + "' where id='" + id + "'";
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
                    txtkuweihao.Text = dt.Rows[0]["库位号"].ToString();
                    txthetonghao.Text = dt.Rows[0]["合同号"].ToString();
                    string danjia = dt.Rows[0]["采购单价"].ToString(); ;
                    if (danjia == "")
                    {
                        danjia = "0";
                    }
                    double zongjia = -Convert.ToDouble(danjia) * Convert.ToDouble(txtshuru.Text.Trim());
                    string sqlll = "select 料单类型 from tb_caigouliaodan where id='" + id + "'";
                    string leixing = SQLhelp.ExecuteScalar(sqlll, CommandType.Text).ToString();
                    string sql12 = "insert into tb_ruku (工作令号,项目名称,设备名称,编码,型号,名称,制造类型,实际采购数量,入库数量,入库时间,入库人,定位,单位,合同号,采购单价,总价,供方名称,料单类型,区分) values ('" + txtgongzuolinghao.Text + "','" + txtxiangmumingcheng.Text + "','" + txtshebeimingcheng.Text + "','" + txtbianma.Text + "','" + txtxinghao.Text + "','" + txtmingcheng.Text + "','" + txtzhizaoleixing.Text + "','" + txtshijicaigoushuliang.Text + "','" + -Convert.ToDouble(txtshuru.Text) + "','" + DateTime.Now + "','" + yonghu + "','" + id + "','" + dt.Rows[0]["单位"].ToString() + "','" + txthetonghao.Text + "','" + danjia + "','" + zongjia + "','" + dt.Rows[0]["供方名称"].ToString() + "','" + leixing + "','新')";
                    SQLhelp.ExecuteScalar(sql12, CommandType.Text);
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("登记成功！");
                    this.Close();
                }
            }
            if (kucun == ""|| kucun == "0")
            {
                MessageBox.Show("库存为0，无法退货！");
                return;
            }         
        }
    }
}
