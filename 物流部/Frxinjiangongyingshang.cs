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
    public partial class Frxinjiangongyingshang : Office2007Form
    {
        public Frxinjiangongyingshang()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }

        private void Frxinjiangongyingshang_Load(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            string sql = "insert into tb_gongfang  (单位名称,法定代表人,委托代理人,电话,传真,税务登记号,开户银行,帐号,[产品/服务类型],单位地址,邮箱,生产负责人电话,生产负责人名称,承兑行号,承兑开户银行,承兑帐号) values('" + txtdanweimingcheng.Text.Trim()+ "','" +txtfadingdaibiaoren.Text.Trim() + "','" + txtweituodailiren.Text.Trim() + "','" +txtdianhua.Text.Trim() + "','" + txtchuanzhen.Text.Trim() + "','" +txtshuiwudengjihao.Text.Trim() + "','" + txtkaihuyinhang.Text.Trim() + "','" + txtzhanghao.Text.Trim() + "','" + txtchanpinleixing.Text.Trim() + "','"+txtdanweidizhi.Text.Trim()+ "','" + txtyouxiang.Text.Trim() + "','" + txtfuzerendianhua.Text.Trim() + "','" + txtfuzerenmingcheng.Text.Trim() + "','" +txtchengduihanghao.Text.Trim() + "','" + txtchengduikaihuyinhang.Text.Trim() + "','" +txtchengyinhangzhanghao.Text.Trim() + "') ";
            SQLhelp.ExecuteScalar(sql, CommandType.Text);
            MessageBox.Show("添加成功！");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
