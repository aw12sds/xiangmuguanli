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
    public partial class Frmeirixiaoshou : Form
    {
        public Frmeirixiaoshou()
        {
            InitializeComponent();
        }

        private void Frmeirixiaoshou_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void reload()
        {

            string sql = "select * from tb_xiaoshou ";
            gridControl4.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] a = gridView4.GetSelectedRows();
            foreach (int i in a)
            {

                float aa = 0;
                if (float.TryParse(Convert.ToString(gridView4.GetRowCellValue(i, "销售额")), out aa) == false)
                {
                    
                    MessageBox.Show("必须是数字！");
                    return;
                }

                if (float.TryParse(Convert.ToString(gridView4.GetRowCellValue(i, "产值")), out aa) == false)
                {
                    MessageBox.Show("必须是数字！");
                    return;
                }

                if (float.TryParse(Convert.ToString(gridView4.GetRowCellValue(i, "开票额")), out aa) == false)
                {
                    MessageBox.Show("必须是数字！");
                    return;
                }
            }
            
                foreach (int i in a)
            {
                
                string id = Convert.ToString(gridView4.GetRowCellValue(i, "id"));
                string xiaoshoue = Convert.ToString(gridView4.GetRowCellValue(i, "销售额"));
                string chanzhi = Convert.ToString(gridView4.GetRowCellValue(i, "产值"));
                string kaipiaoe = Convert.ToString(gridView4.GetRowCellValue(i, "开票额"));
                string sql = "update tb_xiaoshou set 销售额='" + xiaoshoue + "',产值='" + chanzhi + "',开票额='" + kaipiaoe + "' where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);

            }
            MessageBox.Show("保存成功！");
            reload();

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
