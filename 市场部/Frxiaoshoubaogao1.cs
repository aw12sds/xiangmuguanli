using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.市场部
{
    public partial class Frxiaoshoubaogao1 : Form
    {
        public Frxiaoshoubaogao1()
        {
            InitializeComponent();
        }
        public string yonghu;
        private void Frxiaoshoubaogao1_Load(object sender, EventArgs e)
        {
            load();
        }
        public void load()
        {
            string sql1 = "select * from tb_xiaoshou";
            gridControl1.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
        }
    }
}
