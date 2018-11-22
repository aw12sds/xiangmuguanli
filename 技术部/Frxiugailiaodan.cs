using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace 项目管理系统.技术部
{
    public partial class Frxiugailiaodan : DevExpress.XtraEditors.XtraForm
    {
        public Frxiugailiaodan()
        {
            InitializeComponent();
        }
        public string yonghu;
        public string id;
        private void Frxiugailiaodan_Load(object sender, EventArgs e)
        {
            string sql = "select * from tb_caigouliaodan where id='" + id + "'";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            txtmingcheng.Text = dt.Rows[0]["名称"].ToString();
            txtxingaho.Text = dt.Rows[0]["型号"].ToString();
            txtdanwei.Text = dt.Rows[0]["单位"].ToString();
            txtleixing.Text = dt.Rows[0]["类型"].ToString();
            txtbeizhu.Text = dt.Rows[0]["备注"].ToString();
            txtbianma.Text= dt.Rows[0]["编码"].ToString();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认修改该行吗？将会形成修改记录，谨慎修改！！！", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string sql1 = "select * from tb_caigouliaodan where id='" + id + "'";
                DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                string sql = "select 合同号 from tb_caigouliaodan where id='" + id + "'";
                string panduan = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
                if (panduan != "")
                {
                    MessageBox.Show("已经生成合同,无法更改！");
                    return;
                }
                string sql12 = "select 生产部确认 from tb_caigouliaodan where id='" + id + "'";
                string panduan1 = SQLhelp.ExecuteScalar(sql12, CommandType.Text).ToString();
                if (panduan == "1")
                {
                    MessageBox.Show("已经加工,无法更改！");
                    return;
                }

                string xinghao =Convert.ToString(dt.Rows[0]["型号"]);
                string mingcheng = Convert.ToString(dt.Rows[0]["名称"]);
               
                string bianma = Convert.ToString(dt.Rows[0]["编码"]);
                string shuliang = Convert.ToString(dt.Rows[0]["实际采购数量"]);
                string danwei = Convert.ToString(dt.Rows[0]["单位"]);
                string leixing = Convert.ToString(dt.Rows[0]["类型"]);
             
                string beizhu = Convert.ToString(dt.Rows[0]["备注"]);
              
                string gonglinghao = Convert.ToString(dt.Rows[0]["工作令号"]);
                string shebeimingcheng = Convert.ToString(dt.Rows[0]["设备名称"]);
                string xiangmumingcheng = Convert.ToString(dt.Rows[0]["项目名称"]);
          
                string sql2 = "update tb_caigouliaodan  set 型号= '" + txtxingaho.Text + "',名称= '" + txtmingcheng.Text + "',编码='" + txtbianma.Text + "',类型='" + txtleixing.Text + "',备注='" +txtbeizhu.Text + "' where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql2, CommandType.Text);
                
                string sql3 = "INSERT INTO tb_jishubugenggai(工作令号,项目名称,设备名称,编码,型号,名称,单位,类型,备注,实际采购数量,原本型号,原本名称,修改人) VALUES( '" + gonglinghao + "', '" + xiangmumingcheng + "', '" + shebeimingcheng + "', '" + txtbianma.Text + "', '" +txtxingaho.Text + "', '" + txtmingcheng.Text + "','" + txtdanwei.Text + "', '" + leixing + "', '" + beizhu + "','" + shuliang + "','" + xinghao + "','" + mingcheng+ "','" + yonghu + "')";
                SQLhelp.ExecuteScalar(sql3, CommandType.Text);

                MessageBox.Show("修改成功！");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Frchaxunbianma form1 = new Frchaxunbianma();
            form1.ShowDialog();
            if(form1.DialogResult==DialogResult.OK)
            {
                txtbianma.Text = form1.wuzi;
                string sql = "select * from tb_xinerp where 新编号='" + txtbianma.Text + "'";
                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
                txtmingcheng.Text = dt.Rows[0]["三级"].ToString();
               txtxingaho.Text = dt.Rows[0]["四级"].ToString();
                txtbianma.Text = dt.Rows[0]["新编号"].ToString();
                txtdanwei.Text = dt.Rows[0]["单位"].ToString();
            }
        }
    }
}