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

namespace 项目管理系统.技术部
{
    public partial class FrHoutai : Office2007Form
    {
        public FrHoutai()
        {
            this.EnableGlass = false;//关键
            InitializeComponent();
        }

        private void FrHoutai_Load(object sender, EventArgs e)
        {

            string sql1 = "select 用户名 from tb_operator ";
            DataTable mingdan = SQLhelp.GetDataTable(sql1, CommandType.Text);

            DataGridViewComboBoxExColumn shebeizerenren = new DataGridViewComboBoxExColumn();
            shebeizerenren.Name = "设备负责人";
            shebeizerenren.DataPropertyName = "设备负责人";
            shebeizerenren.HeaderText = "设备负责人";
            shebeizerenren.Width = 150;
            shebeizerenren.DropDownStyle = ComboBoxStyle.DropDownList;

            this.dataGridViewX2.Columns.Add(shebeizerenren);
            
            DataGridViewComboBoxExColumn jixiezerenren = new DataGridViewComboBoxExColumn();
            jixiezerenren.Name = "机械负责人";
            jixiezerenren.DataPropertyName = "机械负责人";
            jixiezerenren.HeaderText = "机械负责人";
            jixiezerenren.Width = 150;
            jixiezerenren.DropDownStyle = ComboBoxStyle.DropDownList;
            this.dataGridViewX2.Columns.Add(jixiezerenren);

            DataGridViewComboBoxExColumn dianqizerenren = new DataGridViewComboBoxExColumn();
            dianqizerenren.Name = "电气负责人";
            dianqizerenren.DataPropertyName = "电气负责人";
            dianqizerenren.HeaderText = "电气负责人";
            dianqizerenren.Width = 150;
            dianqizerenren.DropDownStyle = ComboBoxStyle.DropDownList;
            this.dataGridViewX2.Columns.Add(dianqizerenren);

            DataGridViewComboBoxExColumn xiangmufuzeren = new DataGridViewComboBoxExColumn();
            xiangmufuzeren.Name = "项目负责人";
            xiangmufuzeren.DataPropertyName = "项目负责人";
            xiangmufuzeren.HeaderText = "项目负责人";
            xiangmufuzeren.Width = 150;
            xiangmufuzeren.DropDownStyle = ComboBoxStyle.DropDownList;
            this.dataGridViewX2.Columns.Add(xiangmufuzeren);

            List<string> spaceminute1 = new List<string>();
            for (int i = 0; i < mingdan.Rows.Count; i++)
            {

                string n = mingdan.Rows[i]["用户名"].ToString();
                spaceminute1.Add(n);
            }

            foreach (string s in spaceminute1)
            {
                shebeizerenren.Items.Add(s);
                jixiezerenren.Items.Add(s);
                dianqizerenren.Items.Add(s);
                xiangmufuzeren.Items.Add(s);
               
            }
            Reload();

        }
        public void Reload()
        {
            string sql3 = "select id,工作令号,项目名称,设备名称,技术指标,项目负责人,设备负责人,机械负责人,电气负责人,项目主管,方向,数量,制造类型,设备预计结束时间,附件名称,时间,优先级,技术要求反馈内容 from tb_jishubumen   ";

            dataGridViewX2.DataSource = SQLhelp.GetDataTable(sql3, CommandType.Text);



        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                for (int i = 0; i < dataGridViewX2.Rows.Count; i++)
                {
                    string id = dataGridViewX2.Rows[i].Cells["id"].Value.ToString();
                 
                    string shebeimingcheng = Convert.ToString(dataGridViewX2.Rows[i].Cells["设备名称"].Value);
                    string jishuzhibiao = Convert.ToString(dataGridViewX2.Rows[i].Cells["技术指标"].Value);
                    string fangxiang = Convert.ToString(dataGridViewX2.Rows[i].Cells["方向"].Value);
                    string shuliang = Convert.ToString(dataGridViewX2.Rows[i].Cells["数量"].Value);
                    string zhizaoleixing = Convert.ToString(dataGridViewX2.Rows[i].Cells["制造类型"].Value);

                    string shebeiyujijieshushijian = dataGridViewX2.Rows[i].Cells["设备预计结束时间"].Value.ToString();
                    string shebeifuzeren = Convert.ToString(dataGridViewX2.Rows[i].Cells["设备负责人"].Value);

                    string jixiefuzeren = Convert.ToString(dataGridViewX2.Rows[i].Cells["机械负责人"].Value);
                    string dianqifuzeren = Convert.ToString(dataGridViewX2.Rows[i].Cells["电气负责人"].Value);
                    string xiangmufuzeren = Convert.ToString(dataGridViewX2.Rows[i].Cells["项目负责人"].Value);
                    DateTime shijian = Convert.ToDateTime(dataGridViewX2.Rows[i].Cells["时间"].Value);
                   
                  
                        string sql3 = "update tb_jishubumen  set 设备名称= '" + shebeimingcheng + "',技术指标= '" + jishuzhibiao + "',方向= '" + fangxiang + "',数量= '" + shuliang + "',制造类型 ='" + zhizaoleixing + "',设备负责人= '" + shebeifuzeren + "',项目负责人 ='" + xiangmufuzeren + "',机械负责人= '" + jixiefuzeren + "',电气负责人 ='" + dianqifuzeren + "' where id='" + id + "' ";
                        SQLhelp.ExecuteScalar(sql3, CommandType.Text);
                    


                }
                MessageBox.Show("保存成功！");
                Reload();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewX2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex < 0 && e.RowIndex >= 0)
            {
                e.Paint(e.ClipBounds, DataGridViewPaintParts.All);
                Rectangle rectangle = e.CellBounds;
                rectangle.Inflate(-2, -2);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.CellStyle.Font, rectangle, e.CellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
                e.Handled = true;
            }
        }
    }
}
