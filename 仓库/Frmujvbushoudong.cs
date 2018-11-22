using DevComponents.DotNetBar;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.仓库
{
    public partial class Frmujvbushoudong : Office2007Form
    {
        public Frmujvbushoudong()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string id;        
        public string shijidaohuo;
        public string yonghu;
        public string shijicaigou;
        public string kucun;
    
        private void Frmujvbushoudong_Load(object sender, EventArgs e)
        {
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
