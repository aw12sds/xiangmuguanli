using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace 项目管理系统.个人管理
{
    public partial class Frxinzengxiangmuqiux : DevExpress.XtraEditors.XtraForm
    {
        public Frxinzengxiangmuqiux()
        {
            InitializeComponent();
        }
        public string yonghu;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
          
            string sql = "insert into tb_ruanjianxuqiu (软件需求,需求人,需求时间) values ('"+ memoEdit1.Text+"','"+yonghu+"','"+DateTime.Now+"')  ";
            SQLhelp.ExecuteScalar(sql, CommandType.Text);
            MessageBox.Show("已提交");
            this.DialogResult = DialogResult.OK;
            this.Close();

        }
    }
}