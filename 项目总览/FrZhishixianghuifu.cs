using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.项目总览
{
    public partial class FrZhishixianghuifu : Office2007Form
    {
        public FrZhishixianghuifu()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string gongzuolinghao;
        public string xiangmumingcheng;
        public string shebeimingcheng;
        public string shijian;
        public string yonghu;
        public string zhonglei;
        public string id;
        private void FrZhishixianghuifu_Load(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (zhonglei == "新增")
            {
                string dangqianshijian = DateTime.Now.ToString();

             
                string sql = "insert into tb_zhishixiang  (指示项,创建时间,工作令号,项目名称,时间,创建人) values( '" + richTextBoxEx1.Text + "','" + dangqianshijian + "','" + gongzuolinghao + "' ,'" + xiangmumingcheng + "'  ,'" + shijian + "','" + yonghu + "')";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);



                string sql1 = "update tb_xiangmu set 反馈='" + richTextBoxEx1.Text + "' , 更新=1 where  工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'";

                SQLhelp.ExecuteScalar(sql1, CommandType.Text);


                MessageBox.Show("提交成功！");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

            if (zhonglei == "修改")
            {
                string dangqianshijian = DateTime.Now.ToString();

                string sql = "update tb_zhishixiang set 指示项='" + richTextBoxEx1.Text + "'  where  id='" + id + "'";

                SQLhelp.ExecuteScalar(sql, CommandType.Text);

                string sql1 = "update tb_xiangmu set 反馈='" + richTextBoxEx1.Text + "' , 更新=1 where  工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'";

                SQLhelp.ExecuteScalar(sql1, CommandType.Text);


                MessageBox.Show("提交成功！");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }
    }
}
