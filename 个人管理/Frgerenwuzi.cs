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
    public partial class Frgerenwuzi : DevExpress.XtraEditors.XtraForm
    {
        public Frgerenwuzi()
        {
            InitializeComponent();
          DevExpress. LookAndFeel. UserLookAndFeel.Default.UseDefaultLookAndFeel = false;
          DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
        }
        public string dingwei;
      
        private void Frgerenwuzi_Load(object sender, EventArgs e)
        {
            //string sql = "select id,序号";
        }

        private void gridView4_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }


        }
    }
}