using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.质监部
{
    public partial class Frshaixuanliaodan1 : Office2007Form
    {
        public Frshaixuanliaodan1()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public DataTable dt;
        private void Frshaixuanliaodan_Load(object sender, EventArgs e)
        {
            dataGridViewX4.DataSource = dt;
        }
    }
}
