using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.生产部
{
    public partial class Frshengqingdan : Office2007Form
    {
        public Frshengqingdan()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }
        public string yonghu;
        private void Frshengqingdan_Load(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if(comleixing.Text=="")
            {
                MessageBox.Show("请选择类型！");
                return;
            }
            string a = dateTimeInput1.Text;
            if (dateTimeInput1.Text == "")
            {
                MessageBox.Show("请选择要求到货日期！");
                return;
            }
            if (txtdanwei.Text == "")
            {
                MessageBox.Show("请填写单位！");
                return;
            }
            if (txtbianma.Text == "")
            {
                MessageBox.Show("请填写ERP编码！");
                return;
            }
            if (txtxinghao.Text == "")
            {
                MessageBox.Show("请填写型号！");
                return;
            }
            if (txtmingcheng.Text == "")
            {
                MessageBox.Show("请填写名称！");
                return;
            }
            if (txtshuliang.Text == "")
            {
                MessageBox.Show("请填写数量！");
                return;
            }
            if (comleixing.Text == "五金辅材")
            {
                if (MessageBox.Show("确认提交吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    string caigouleixing = comleixing.Text;
                    string gongzuolinghao = txtgonglinghao.Text;
                    string shebeimingcheng = txtshebei.Text;
                    string xiangmumingcheng = txtxiangmu.Text;
                    string xinghao = txtxinghao.Text;
                    string bianma = txtbianma.Text;
                    string danwei = txtdanwei.Text;
                    string mingcheng = txtmingcheng.Text;
                    string yaoqiudaohuoriqi = dateTimeInput1.Text;
                    string shuliang = txtshuliang.Text;
                    string beizhu = txtbeizhu.Text;
                    string sql2 = "insert into tb_caigouliaodan (工作令号,项目名称,设备名称,编码,型号,名称,数量,要求到货日期1,申购人,备注,采购类型,收到料单日期,采购负责人,到货情况,单位,实际采购数量,料单类型) values('" + gongzuolinghao + "','" + xiangmumingcheng + "','" + shebeimingcheng + "','" + bianma + "','" + xinghao + "','" + mingcheng + "','" + shuliang + "','" + yaoqiudaohuoriqi + "','" + yonghu + "','" + beizhu + "','" + caigouleixing + "','" + DateTime.Now + "','唐亚男',0,'" + danwei + "', '"+shuliang+"','五金辅材')";
                    SQLhelp.ExecuteScalar(sql2, CommandType.Text);
                    MessageBox.Show("提交成功！");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            if (comleixing.Text == "原材料")
            {
                if (MessageBox.Show("确认提交吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    string caigouleixing = comleixing.Text;
                    string gongzuolinghao = txtgonglinghao.Text;
                    string shebeimingcheng = txtshebei.Text;
                    string xiangmumingcheng = txtxiangmu.Text;
                    string xinghao = txtxinghao.Text;
                    string bianma = txtbianma.Text;
                    string danwei = txtdanwei.Text;
                    string mingcheng = txtmingcheng.Text;
                    string yaoqiudaohuoriqi = dateTimeInput1.Text;
                    string shuliang = txtshuliang.Text;
                    string beizhu = txtbeizhu.Text;
                    string sql2 = "insert into tb_caigouliaodan (工作令号,项目名称,设备名称,编码,型号,名称,数量,要求到货日期1,申购人,备注,采购类型,收到料单日期,采购负责人,到货情况,单位,实际采购数量,料单类型) values('" + gongzuolinghao + "','" + xiangmumingcheng + "','" + shebeimingcheng + "','" + bianma + "','" + xinghao + "','" + mingcheng + "','" + shuliang + "','" + yaoqiudaohuoriqi + "','" + yonghu + "','" + beizhu + "','" + caigouleixing + "','" + DateTime.Now + "','缪新鑫',0,'" + danwei + "', '" + shuliang + "','五金辅材')";
                    SQLhelp.ExecuteScalar(sql2, CommandType.Text);
                    MessageBox.Show("提交成功！");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
