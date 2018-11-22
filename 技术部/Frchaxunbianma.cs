using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace 项目管理系统.技术部
{
    public partial class Frchaxunbianma : DevExpress.XtraEditors.XtraForm
    {
        public Frchaxunbianma()
        {
            InitializeComponent();
        }

        private void Frchaxunbianma_Load(object sender, EventArgs e)
        {
            string sql = "select * from tb_erpfirst";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

            List<string> spaceminute1 = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                string n = dt.Rows[i]["一级"].ToString();
                spaceminute1.Add(n);

            }
            foreach (string s in spaceminute1)
            {
                commingcheng1.Properties.Items.Add(s);

            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void commingcheng1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (commingcheng1.Text != "")
            {
                string sql = "select * from tb_xinerp where 一级='" + commingcheng1.Text + "'";
                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
                DataView myDataView = new DataView(dt);
                string[] strComuns = { "一级", "二级" };
                dt = myDataView.ToTable(true, strComuns);


                List<string> spaceminute1 = new List<string>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    string n = dt.Rows[i]["二级"].ToString();
                    spaceminute1.Add(n);

                }
                foreach (string s in spaceminute1)
                {
                    commingcheng2.Properties.Items.Add(s);

                }
                commingcheng1.Enabled = false;
                string sql11 = " select * from tb_xinerp    where  一级 ='" + commingcheng1.Text.Trim() + "' ";
                gridControl4.DataSource = SQLhelp.GetDataTable(sql11, CommandType.Text);
                gridView4.Columns["id"].Visible = false;


            }
        }

        private void commingcheng2_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (commingcheng2.Text != "")
            {
                string sql = "select * from tb_xinerp where 二级='" + commingcheng2.Text + "'";

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
                DataView myDataView = new DataView(dt);
                string[] strComuns = { "二级", "三级" };
                dt = myDataView.ToTable(true, strComuns);

                List<string> spaceminute1 = new List<string>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    string n = dt.Rows[i]["三级"].ToString();
                    spaceminute1.Add(n);

                }
                foreach (string s in spaceminute1)
                {
                    commingcheng3.Properties.Items.Add(s);

                }
                commingcheng2.Enabled = false;
                string sql11 = " select * from tb_xinerp    where  一级 ='" + commingcheng1.Text.Trim() + "' and 二级 ='" + commingcheng2.Text.Trim() + "'";
                gridControl4.DataSource = SQLhelp.GetDataTable(sql11, CommandType.Text);
                gridView4.Columns["id"].Visible = false;

            }
        }

        private void commingcheng3_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (commingcheng3.Text != "")
            {
                string sql = "select * from tb_xinerp where 三级='" + commingcheng3.Text + "'";
                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
                DataView myDataView = new DataView(dt);
                string[] strComuns = { "三级", "四级" };
                dt = myDataView.ToTable(true, strComuns);
                List<string> spaceminute1 = new List<string>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    string n = dt.Rows[i]["四级"].ToString();
                    spaceminute1.Add(n);

                }
                foreach (string s in spaceminute1)
                {
                    commingcheng4.Properties.Items.Add(s);

                }
                commingcheng3.Enabled = false;
                string sql11 = " select * from tb_xinerp    where  一级 ='" + commingcheng1.Text.Trim() + "' and 二级 ='" + commingcheng2.Text.Trim() + "' and 三级 ='" + commingcheng3.Text.Trim() + "'";
                gridControl4.DataSource = SQLhelp.GetDataTable(sql11, CommandType.Text);
                gridView4.Columns["id"].Visible = false;

            }
        }

        private void commingcheng4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (commingcheng4.Text != "")
            {
                string sql = "select * from tb_xinerp where 四级='" + commingcheng4.Text + "'";
                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                commingcheng4.Enabled = false;
                string sql11 = " select * from tb_xinerp    where  四级 ='" + commingcheng4.Text.Trim() + "' ";
                gridControl4.DataSource = SQLhelp.GetDataTable(sql11, CommandType.Text);
                gridView4.Columns["id"].Visible = false;

            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            if (txtwuzi.Text.Trim() == "")
            {
                MessageBox.Show("请输入需要查找的内容");
                return;
            }
            string sql = " select *  from tb_xinerp    where  一级 like '%" + txtwuzi.Text.Trim() + "%' or 二级 like '%" + txtwuzi.Text.Trim() + "%'  or 三级 like '%" + txtwuzi.Text.Trim() + "%'  or 四级 like '%" + txtwuzi.Text.Trim() + "%' ";
            gridControl4.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
            gridView4.Columns["id"].Visible = false;
        }

        private void gridView4_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }
        public string wuzi;
        private void gridView4_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {


            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
            {

                if (MessageBox.Show("确认将该物资替换原有物资吗", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    this.wuzi = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "新编号"));
                    this.DialogResult = DialogResult.OK;
                    this.Close();


                }

            }
        }
    }
}