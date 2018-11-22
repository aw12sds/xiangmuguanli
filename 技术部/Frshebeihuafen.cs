using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.技术部
{
    public partial class Frshebeihuafen : DevExpress.XtraEditors.XtraForm
    {
        public Frshebeihuafen()
        {
            InitializeComponent();
        }
        public string yonghu;
        public string id;
        public string gonglinghao;
        public string xiangmumingcheng;
        private void Frshebeihuafen_Load(object sender, EventArgs e)
        {
            string sql = "select 设备划分 from tb_jishubumen where 工作令号='"+ gonglinghao + "'";
            DataTable aaaa = SQLhelp.GetDataTable(sql, CommandType.Text);
            List<string> spaceminute = new List<string>();
            for (int i = 0; i < aaaa.Rows.Count; i++)
            {

                string n = aaaa.Rows[i]["设备划分"].ToString();
                spaceminute.Add(n);
            }

            foreach (string s in spaceminute)
            {
                comboBoxEdit1.Properties.Items.Add(s);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string sql = "update tb_jishubumen set 设备划分='"+ comboBoxEdit1 .Text+ "' where id='"+id+"'";
            SQLhelp.ExecuteScalar(sql, CommandType.Text);

            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
