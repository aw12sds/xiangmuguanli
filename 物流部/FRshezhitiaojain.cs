using DevComponents.DotNetBar;
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
    public partial class FRshezhitiaojain : Office2007Form
    {
        public FRshezhitiaojain()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public DataTable dt;
        public string gongzuolinghao;
        public string xiangmumingcheng;
        public string shijian ;
        private void FRshezhitiaojain_Load(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (textBoxX1.Text == "" && textBoxX2.Text == "")
            {
                MessageBox.Show("请至少输入一个搜索条件！");
                return;
            }
            if (textBoxX1.Text != "" && textBoxX2.Text != "")
            {

                string sql = "select id, 序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,申购人,收到料单日期,供方名称,合同号,实际采购数量,报价, 采购单价,实际到货日期,当前状态,采购料单备注,附件名称,附件类型 from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "' and   制造类型!='自制零部件' and   制造类型!='装配零部件'  and   制造类型!='库存件' and 型号 like '%" + textBoxX1.Text + "%' and 名称 like '%" + textBoxX2.Text + "%' ";

                dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                this.DialogResult = DialogResult.OK;
                this.Close();


            }

            if (textBoxX1.Text != "" && textBoxX2.Text == "")
            {

                string sql = "select id, 序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,申购人,收到料单日期,供方名称,合同号,实际采购数量,报价, 采购单价,实际到货日期,当前状态,采购料单备注,附件名称,附件类型 from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "' and   制造类型!='自制零部件' and   制造类型!='装配零部件'  and   制造类型!='库存件' and 型号 like '%" + textBoxX1.Text + "%'";

                dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                this.DialogResult = DialogResult.OK;
                this.Close();


            }

            if (textBoxX1.Text == "" && textBoxX2.Text != "")
            {

                string sql = "select id, 序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,申购人,收到料单日期,供方名称,合同号,实际采购数量,报价, 采购单价,实际到货日期,当前状态,采购料单备注,附件名称,附件类型 from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "' and   制造类型!='自制零部件' and   制造类型!='装配零部件'  and   制造类型!='库存件'  and 名称 like '%" + textBoxX2.Text + "%' ";

                dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                this.DialogResult = DialogResult.OK;
                this.Close();


            }


        }
    }
}
