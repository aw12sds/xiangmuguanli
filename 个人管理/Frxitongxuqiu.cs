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
    public partial class Frxitongxuqiu : DevExpress.XtraEditors.XtraForm
    {
        public Frxitongxuqiu()
        {
            InitializeComponent();
        }
        public string yonghu;
        private void Frxitongxuqiu_Load(object sender, EventArgs e)
        {
            Reload();


        }
        public void Reload()
        {

            string sql = "select * from tb_ruanjianxuqiu  ORDER BY id ";
            gridControl1.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);


        }

        private void 新增需求ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frxinzengxiangmuqiux form1 = new Frxinzengxiangmuqiux();
            form1.yonghu = yonghu;
            form1.ShowDialog();
            if (form1.DialogResult == DialogResult.OK)
            {
                Reload();
            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void 修改状态ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = "select 部门 from tb_operator where 用户名='" + yonghu + "'";
            string bumen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bumen == "信息化事业部")
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    string id = gridView1.GetRowCellValue(i, "id").ToString().Trim();
                    string zhuangtai = gridView1.GetRowCellValue(i, "当前状态").ToString().Trim();
                    string sql111 = "update tb_ruanjianxuqiu set 当前状态='" + zhuangtai + "' where id='"+id+"'";
                    SQLhelp.ExecuteScalar(sql111, CommandType.Text);

                }
                MessageBox.Show("已保存");
            }
            else
            {
                MessageBox.Show("无权限！");
            }

        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {

            Frxinzengxiangmuqiux form1 = new Frxinzengxiangmuqiux();
            form1.yonghu = yonghu;
            form1.ShowDialog();
            if (form1.DialogResult == DialogResult.OK)
            {
                Reload();
            }
        }
    }
}
