using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.生产部
{
    public partial class Frbeiliaoxiangxi : Office2007Form
    {
        public Frbeiliaoxiangxi()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string gongzuolinghao;
        public string xiangmumingcheng;
        public string shijian;
        public string yonghu;
        public string shebeimingcheng;
        private void frbeiliaoxiangxi_Load(object sender, EventArgs e)
        {
            Reload();
        }
        public void Reload()
        {

            string sql1 = "select  id,序号,编码,型号,名称,单位,数量,类型,要求到货日期,备注,制造类型,实际采购数量,当前状态,工艺顺序1,工艺顺序2,工艺顺序3 from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" +shebeimingcheng + "' and 时间='" + shijian + "'  ";

            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            dataGridViewX1.DataSource = dt;

            string sql2 = "select  id,序号,编码,型号,名称,单位,数量,类型,要求到货日期,备注,制造类型,实际采购数量,当前状态,备料 from  tb_caigouliaodan  where (工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "' and 时间='" + shijian + "'  and 当前状态='9已到货' and  备料 is null) or(工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "' and 时间='" + shijian + "'  and 当前状态='已加工' and  备料 is null) or(工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "' and 时间='" + shijian + "'  and 制造类型='库存件' and  备料 is null)   or(工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "' and 时间='" + shijian + "'  and 当前状态='10已出库' and  备料 is null)";

            DataTable dt2 = SQLhelp.GetDataTable(sql2, CommandType.Text);
            
            gridControl1.DataSource = dt2;
            gridView1.Columns["id"].Visible = false;

            string sql3 = "select  id,序号,编码,型号,名称,单位,数量,类型,要求到货日期,备注,制造类型,实际采购数量,当前状态,备料时间 from  tb_caigouliaodan  where (工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "' and 时间='" + shijian + "'  and 当前状态='9已到货' and  备料 =1) or(工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "' and 时间='" + shijian + "'  and 当前状态='已加工' and  备料 =1) or(工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "' and 时间='" + shijian + "'  and 当前状态='无需加工或购买' and  备料 =1) or(工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "' and 时间='" + shijian + "'  and 当前状态='10已出库' and  备料 =1)";

            DataTable dt3 = SQLhelp.GetDataTable(sql3, CommandType.Text);
            gridControl2.DataSource = dt3;
            gridView2.Columns["id"].Visible = false;
            



            string sql4 = "select  id,序号,编码,型号,名称,单位,数量,类型,要求到货日期,备注,制造类型,实际采购数量,当前状态 from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "' and 备料 is null  ";

            DataTable dt4 = SQLhelp.GetDataTable(sql4, CommandType.Text);
            gridControl3.DataSource = dt4;
            
            gridView3.Columns["id"].Visible = false;
        }

        private void dataGridViewX1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dataGridViewX3_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridViewX4_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void 保存工艺顺序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
            {
                string id = dataGridViewX1.Rows[i].Cells["id1"].Value.ToString();

                string gongyishunxu1 = Convert.ToString(dataGridViewX1.Rows[i].Cells["工艺顺序1"].Value);
                if (gongyishunxu1 == "1")
                {
                    string sql4 = "select 工艺顺序1 from tb_caigouliaodan   where id='" + id + "' ";
                     string a= SQLhelp.ExecuteScalar(sql4, CommandType.Text).ToString();
                    if(a !="1")
                    {

                        string sql5 = "update tb_caigouliaodan  set  工艺顺序1=1 from tb_caigouliaodan  where id='" + id + "' ";
                        SQLhelp.ExecuteScalar(sql5, CommandType.Text);
                        
                    }
                    

                    
                }

                if (gongyishunxu1 == "2")
                {
                    string sql4 = "select 工艺顺序2 from tb_caigouliaodan   where id='" + id + "' ";
                    string a = SQLhelp.ExecuteScalar(sql4, CommandType.Text).ToString();
                    if (a != "2")
                    {

                        string sql5 = "update tb_caigouliaodan  set  工艺顺序2=2 from tb_caigouliaodan  where id='" + id + "' ";
                        SQLhelp.ExecuteScalar(sql5, CommandType.Text);

                    }

                }

                if (gongyishunxu1 == "3")
                {
                    string sql4 = "select 工艺顺序3 from tb_caigouliaodan   where id='" + id + "' ";
                    string a = SQLhelp.ExecuteScalar(sql4, CommandType.Text).ToString();
                    if (a != "1")
                    {

                        string sql5 = "update tb_caigouliaodan  set  工艺顺序3=3 from tb_caigouliaodan  where id='" + id + "' ";
                        SQLhelp.ExecuteScalar(sql5, CommandType.Text);

                    }
                    
                }
            }
            MessageBox.Show("设置成功！");
            Reload();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {

            int[] a = gridView1.GetSelectedRows();

            foreach (int i in a)
            {
                string id = Convert.ToString(gridView1.GetRowCellValue(i, "id"));

                string beiliao = Convert.ToString(gridView1.GetRowCellValue(i, "备料"));
                
                string time = DateTime.Now.ToString();
                if (beiliao == "")
                {
                    string sql4 = "update tb_caigouliaodan  set  备料=1,备料时间='" + time + "',备料人='" + yonghu + "'  from tb_caigouliaodan    where id='" + id + "' ";
                    SQLhelp.ExecuteScalar(sql4, CommandType.Text);

                }
            }
            
            MessageBox.Show("备料成功！");
            Reload();
        }

   
       

        private void buttonItem2_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
            {
                string id = dataGridViewX1.Rows[i].Cells["id1"].Value.ToString();

                string gongyishunxu1 = Convert.ToString(dataGridViewX1.Rows[i].Cells["工艺顺序1"].Value);
                string gongyishunxu2 = Convert.ToString(dataGridViewX1.Rows[i].Cells["工艺顺序2"].Value);
                string gongyishunxu3 = Convert.ToString(dataGridViewX1.Rows[i].Cells["工艺顺序3"].Value);


                if (gongyishunxu1 == "1" && gongyishunxu2 == "1")
                {

                    MessageBox.Show("无法同时设定2次以上工艺顺序！");
                    return;
                }

                if (gongyishunxu3 == "1" && gongyishunxu2 == "1")
                {

                    MessageBox.Show("无法同时设定2次以上工艺顺序！");
                    return;
                }

                if (gongyishunxu3 == "1" && gongyishunxu1 == "1")
                {

                    MessageBox.Show("无法同时设定2次以上工艺顺序！");
                    return;
                }


                if (gongyishunxu1 == "1")
                {
                    string sql4 = "select 工艺顺序1 from tb_caigouliaodan   where id='" + id + "' ";
                    string a = SQLhelp.ExecuteScalar(sql4, CommandType.Text).ToString();
                    if (a != "1")
                    {

                        string sql5 = "update tb_caigouliaodan  set  工艺顺序1=1 from tb_caigouliaodan  where id='" + id + "' ";
                        SQLhelp.ExecuteScalar(sql5, CommandType.Text);

                    }
                    
                }

                if (gongyishunxu2 == "1")
                {
                    string sql4 = "select 工艺顺序2 from tb_caigouliaodan   where id='" + id + "' ";
                    string a = SQLhelp.ExecuteScalar(sql4, CommandType.Text).ToString();
                    if (a != "1")
                    {

                        string sql5 = "update tb_caigouliaodan  set  工艺顺序2=1 from tb_caigouliaodan  where id='" + id + "' ";
                        SQLhelp.ExecuteScalar(sql5, CommandType.Text);

                    }

                }

                if (gongyishunxu3 == "1")
                {
                    string sql4 = "select 工艺顺序3 from tb_caigouliaodan   where id='" + id + "' ";
                    string a = SQLhelp.ExecuteScalar(sql4, CommandType.Text).ToString();
                    if (a != "1")
                    {

                        string sql5 = "update tb_caigouliaodan  set  工艺顺序3=1 from tb_caigouliaodan  where id='" + id + "' ";
                        SQLhelp.ExecuteScalar(sql5, CommandType.Text);

                    }

                }
            }
            MessageBox.Show("设置成功！");
            Reload();
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView3_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
    }
}
