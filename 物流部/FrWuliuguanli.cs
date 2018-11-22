using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 项目管理系统.技术部;

namespace 项目管理系统.物流部
{
    public partial class FrWuliuguanli : DevExpress.XtraEditors.XtraForm
    {
        public FrWuliuguanli()
        {         
            InitializeComponent();
        }
        public string yonghu;
        public DataTable dt;

        private void FrWuliuguanli_Load(object sender, EventArgs e)
        {

            gridControl4.DataSource = dt;

        }
        
    }
}
