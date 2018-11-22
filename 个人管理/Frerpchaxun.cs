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
    public partial class Frerpchaxun : Form
    {
        public Frerpchaxun()
        {
            InitializeComponent();
        }
        #region cbbYiji_SelectedIndexChanged[一级名称]
        private void cbbYiji_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbYiji.Text != "")
            {
                string sql = "select * from tb_xinerp where 一级='" + cbbYiji.Text + "'";
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
                    cbbErji.Properties.Items.Add(s);
                }
                cbbYiji.Enabled = false;
                string sql11 = " select * from tb_xinerp    where  一级 ='" + cbbYiji.Text.Trim() + "' ";
                gridControl4.DataSource = SQLhelp.GetDataTable(sql11, CommandType.Text);
                gridView4.Columns["id"].Visible = false;
            }
        }
        #endregion
       
        #region cbbErji_SelectedIndexChanged[二级名称]
        private void cbbErji_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbbErji.Text != "")
            {
                string sql = "select * from tb_xinerp where 二级='" + cbbErji.Text + "'";

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
                    cbbSanji.Properties.Items.Add(s);

                }
                cbbErji.Enabled = false;
                string sql11 = " select * from tb_xinerp    where  一级 ='" + cbbYiji.Text.Trim() + "' and 二级 ='" + cbbErji.Text.Trim() + "'";
                gridControl4.DataSource = SQLhelp.GetDataTable(sql11, CommandType.Text);
                gridView4.Columns["id"].Visible = false;

            }
        }
        #endregion

        #region Frerpchaxun_Load
        private void Frerpchaxun_Load(object sender, EventArgs e)
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
                cbbYiji.Properties.Items.Add(s);
                //cb1.Items.Add(s);
            }
        }
        #endregion

        #region cbbSanji_SelectedIndexChanged[三级名称]
        private void cbbSanji_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbbSanji.Text != "")
            {
                string sql = "select * from tb_xinerp where 三级='" + cbbSanji.Text + "'";
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
                    cbbSiji.Properties.Items.Add(s);
                }
                cbbSanji.Enabled = false;
                string sql11 = " select * from tb_xinerp where  一级 ='" + cbbYiji.Text.Trim() + "' and 二级 ='" + cbbErji.Text.Trim() + "' and 三级 ='" + cbbSanji.Text.Trim() + "'";
                gridControl4.DataSource = SQLhelp.GetDataTable(sql11, CommandType.Text);
                gridView4.Columns["id"].Visible = false;
            }
        }
        #endregion

        #region cbbSiji_SelectedIndexChanged[四级型号]
        private void cbbSiji_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbSiji.Text != "")
            {
                string sql = "select * from tb_xinerp where 四级='" + cbbSiji.Text + "'";
                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
                cbbSiji.Enabled = false;
                string sql11 = " select * from tb_xinerp where  四级 ='" + cbbSiji.Text.Trim() + "' ";
                gridControl4.DataSource = SQLhelp.GetDataTable(sql11, CommandType.Text);
                gridView4.Columns["id"].Visible = false;
                
            }
           
        }
        #endregion

            #region 模糊搜索
        private void simpleButton2_Click(object sender, EventArgs e)
        {

            if (txtSearchMohu.Text.Trim() == "")
            {
                MessageBox.Show("请输入需要查找的内容");
                return;
            }
            string sql = " select *  from tb_xinerp    where  一级 like '%" + txtSearchMohu.Text.Trim() + "%' or 二级 like '%" + txtSearchMohu.Text.Trim() + "%'  or 三级 like '%" + txtSearchMohu.Text.Trim() + "%'  or 四级 like '%" + txtSearchMohu.Text.Trim() + "%' ";
            gridControl4.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
            gridView4.Columns["id"].Visible = false;
        } 
        #endregion
       
        #region 查询最近生成的ERP号
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string sql = " select *  from tb_xinerp    where 生成时间 is not null";
            gridControl4.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
            gridView4.Columns["id"].Visible = false;
        } 
        #endregion
      
        #region GridView序号显示
        private void gridView4_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
        #endregion
      
        #region 清空
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            cbbYiji.Text = "";
            cbbErji.Text = "";
            cbbSanji.Text = "";
            cbbSiji.Text = "";
            gridView4.Columns.Clear();
            cbbYiji.Enabled = true;
            cbbErji.Enabled = true;
            cbbSanji.Enabled = true;
            cbbSiji.Enabled = true;
        } 
        #endregion
    }
}