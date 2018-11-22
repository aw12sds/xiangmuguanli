using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.物流部
{
    public partial class Frfenjie : Office2007Form
    {
        public Frfenjie()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string shuliang;
        public string xinde;
        private void Frfenjie_Load(object sender, EventArgs e)
        {
            textBoxX1.Text = shuliang;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            xinde = txtxinde.Text.Trim();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
