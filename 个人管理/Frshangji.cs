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
    public partial class Frshangji : DevExpress.XtraEditors.XtraForm
    {
        public Frshangji()
        {
            InitializeComponent();
        }

        private void Frshangji_Load(object sender, EventArgs e)
        {
            Reload();
        }
        public void Reload()
        {
            string sql = "select * from tb_xiangmugongxiang";
            gridControl4.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
            gridView4.Columns["id"].Visible = false;

        }



        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (MessageBox.Show("确认接受任务吗？接受了必须写相关方案，写方案就会有对应奖励，请积极应对", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {

                string id = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id"));

                string sql = "update tb_xiangmugongxiang set 确认=1 where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);

                MessageBox.Show("确认成功！");
            }
            Reload();
        }

        private void gridView4_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {

        }
    }
}