using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace 项目管理系统.市场部
{
    public partial class Frshangchuan : DevExpress.XtraEditors.XtraForm
    {
        public Frshangchuan()
        {
            InitializeComponent();
        }
        public string yonghu;
        private void Frshangchuan_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(txtxiangmumingcheng.Text.Trim()=="")
            {
                MessageBox.Show("项目名称不能等于0！");
                return;
            }
            if (txtxiangmumingcheng.Text.Trim() == "")
            {
                MessageBox.Show("项目描述不能为空！");
                return;
            }
            string sql = "insert into tb_xiangmugongxiang (项目名称,项目描述,上传人,上传时间) values ('" + txtxiangmumingcheng.Text + "','" + txtxiangmumingchengmiaoshu.Text + "','" + yonghu + "','" + DateTime.Now + "')";
            SQLhelp.ExecuteScalar(sql, CommandType.Text);
            MessageBox.Show("上传成功！");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}