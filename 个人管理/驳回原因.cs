using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.个人管理
{
    public partial class 驳回原因 : DevExpress.XtraEditors.XtraForm
    {
        public string id;
        public 驳回原因(string id)
        {
            InitializeComponent();
            this.id = id;
        }
        
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string 驳回原因 = richTextBox1.Text;
            string sql1 = "update tb_caigouliaodan  set 流程状态='驳回',驳回原因='" + 驳回原因 + "' where id='" + id + "'";
            SQLhelp.ExecuteScalar(sql1, CommandType.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
