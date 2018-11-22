using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace 项目管理系统.市场部
{
    public partial class Frdailixiang : DevExpress.XtraEditors.XtraForm
    {
        public Frdailixiang()
        {
            InitializeComponent();
        }
        public string yonghu;
        private void buttonItem1_Click(object sender, EventArgs e)
        {
            Frshangchuan form1 = new Frshangchuan();
            form1.yonghu = yonghu;
            form1.ShowDialog();
            if(form1.DialogResult==DialogResult.OK)
            {
                Reload();
            }
        }

        private void Frdailixiang_Load(object sender, EventArgs e)
        {
            Reload();
        }
        public void Reload()
        {
            string sql = "select * from tb_xiangmugongxiang ";
            gridControl1.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
            gridView1.Columns["id"].Visible = false;


        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
            string sql = "delete from tb_xiangmugongxiang where id='" + id + "'";
            SQLhelp.ExecuteScalar(sql, CommandType.Text);
            Reload();
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for(int i=0;i<gridView1.RowCount;i++)
            {
                string id = gridView1.GetRowCellValue(i, "id").ToString();
                string xiangmu = gridView1.GetRowCellValue(i, "项目名称").ToString();
                string xiangmumaioshu = gridView1.GetRowCellValue(i, "项目描述").ToString();

                string sql = "update tb_xiangmugongxiang  set 项目名称='" + xiangmu + "',项目描述='" + xiangmumaioshu + "' where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);
            }
            MessageBox.Show("修改成功！");
            Reload();
        }
    }
}