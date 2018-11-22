using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace 项目管理系统.物流部
{
    public partial class 驳回原因状态转换 : DevExpress.XtraEditors.XtraForm
    {
        public string id;
        public 驳回原因状态转换(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void 驳回原因状态转换_Load(object sender, EventArgs e)
        {
            string 驳回原因 = richTextBox1.Text;
            string sql1 = "update tb_caigouliaodan  set 流程状态='驳回',驳回原因='" + 驳回原因 + "' where id='" + id + "'";
            SQLhelp.ExecuteScalar(sql1, CommandType.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}