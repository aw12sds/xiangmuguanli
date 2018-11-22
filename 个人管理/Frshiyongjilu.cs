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
    public partial class Frshiyongjilu : Form
    {
        public Frshiyongjilu()
        {
            InitializeComponent();
        }

        private void Frshiyongjilu_Load(object sender, EventArgs e)
        {
         
        }
        #region 显示GridView序号
        private void gridView4_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        } 
        #endregion
        #region 搜索人
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string sql = "select 登录人,登录时间 from tb_denglu  where 登录人 like '%" + textSearchName.Text.Trim() + "%' order by 登录时间 desc ";
            gridControl4.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
        }
        #endregion
        #region 显示全部
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string sql = "select 登录人,登录时间 from tb_denglu order by 登录时间 desc";
            gridControl4.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
        } 
        #endregion
    }
}