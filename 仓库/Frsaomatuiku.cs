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
    public partial class Frsaomatuiku : Office2007Form
    {
        public Frsaomatuiku()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string[] daohuo;
        public string id;
        public string shijichuhuo;
        string[] sArray = null;
        public string yonghu;
        public string shijicaigou;
        public string leixing = "";
        private void Frsaomatuiku_Load(object sender, EventArgs e)
        {

        }

        private void txtyincang_TextChanged(object sender, EventArgs e)
        {
            id = "";
            shijichuhuo = "";
            shijicaigou = "";
            sArray = null;
            if (txtyincang.Text.Trim() != "")
            {

                sArray = txtyincang.Text.Split(new char[1] { '|' });
                daohuo = sArray;
                if (sArray.Length < 3)
                {
                    MessageBox.Show("扫码有误，重新扫描！");
                    return;

                }
                if (sArray.Length > 3)
                {

                    string sql = " select 采购类型,计量单位 from tb_caigouliaodan where id='" + sArray[0] + "'";
                    DataTable dtt = SQLhelp.GetDataTable(sql, CommandType.Text);
                    string caiogouleixing = dtt.Rows[0]["采购类型"].ToString();
                    string jiliangdanwei = dtt.Rows[0]["计量单位"].ToString();

                    string sql1 = " select 工作令号,项目名称,设备名称,编码,型号,名称,制造类型,实际采购数量,实际到货数量,出库数量,库位号,合同号,供方名称  from tb_caigouliaodan where id='" + sArray[0] + "'";
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
                    id = sArray[0];
                    shijichuhuo = dt.Rows[0]["出库数量"].ToString();
                    shijicaigou = dt.Rows[0]["实际采购数量"].ToString();

                }
            }

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (shijichuhuo == "")
            {
                MessageBox.Show("还未出库，无法退库！");
                return;
            }
            if (id == "")
            {
                MessageBox.Show("先扫码！");
                return;

            }
            if (id != "")
            {

                if (Convert.ToDouble(txtshuru.Text.Trim()) > Convert.ToDouble(txtchuku.Text.Trim()))
                {
                    MessageBox.Show("退库数量超过出库数量，请重新输入！");
                    return;

                }
                double shijichuku = Convert.ToDouble(txtchuku.Text.Trim()) - Convert.ToDouble(txtshuru.Text.Trim());
                string sql = "update tb_caigouliaodan set 出库数量='" + shijichuku + "'  where id='" + id + "'";
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
                string sql12 = "insert into tb_chuku (工作令号,项目名称,设备名称,编码,型号,名称,制造类型,实际采购数量,出库数量,出库时间,出库人,定位,单位,合同号,采购单价,总价,供方名称,料单类型) values ('" + txtgongzuolinghao.Text + "','" + txtxiangmumingcheng.Text + "','" + txtshebeimingcheng.Text + "','" + txtbianma.Text + "','" + txtxinghao.Text + "','" + txtmingcheng.Text + "','" + txtzhizaoleixing.Text + "','" + txtshijicaigoushuliang.Text + "','" + -Convert.ToDouble(txtshuru.Text) + "','" + DateTime.Now + "','" + yonghu + "','" + id + "','" + dt.Rows[0]["单位"].ToString() + "','" + txthetonghao.Text + "','" + danjia + "','" + zongjia + "','" + dt.Rows[0]["供方名称"].ToString() + "','"+leixing+"')";
                SQLhelp.ExecuteScalar(sql12, CommandType.Text);
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("登记成功！");
                this.Close();

            }
        }
    }
}
    


