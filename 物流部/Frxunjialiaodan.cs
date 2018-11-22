using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.物流部
{
    public partial class Frxunjialiaodan : Office2007Form
    {
        public Frxunjialiaodan()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }
        public string xunjiabiaoji;
        public string yonghu;
        private void Frxunjialiaodan_Load(object sender, EventArgs e)
        {
            string sql1 = "select id,工作令号,项目名称,设备名称, 序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,申购人,收到料单日期,供方名称,合同号,实际采购数量,报价, 采购单价,实际到货日期,当前状态,采购料单备注,附件名称,附件类型 from  tb_caigouliaodan  where 询价标记='" + xunjiabiaoji + "'";

            dataGridViewX2.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
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

        private void 生成合同ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DataTable dt1 = new DataTable();
            DataTable zongbiao1 = new DataTable();
            dt1.Columns.Add("id");
            dt1.Columns.Add("工作令号");
            dt1.Columns.Add("项目名称");
            dt1.Columns.Add("设备名称");
            dt1.Columns.Add("编码");
            dt1.Columns.Add("名称");
            dt1.Columns.Add("型号");
            dt1.Columns.Add("类型");
            dt1.Columns.Add("实际采购数量");
            dt1.Columns.Add("采购单价");
            dt1.Columns.Add("总价");
            dt1.Columns.Add("备注");
            dt1.Columns.Add("单位");
            zongbiao1.Columns.Add("id");
            zongbiao1.Columns.Add("工作令号");
            zongbiao1.Columns.Add("项目名称");
            zongbiao1.Columns.Add("设备名称");
            zongbiao1.Columns.Add("编码");
            zongbiao1.Columns.Add("名称");
            zongbiao1.Columns.Add("型号");
            zongbiao1.Columns.Add("类型");
            zongbiao1.Columns.Add("实际采购数量");
            zongbiao1.Columns.Add("采购单价");
            zongbiao1.Columns.Add("总价");
            zongbiao1.Columns.Add("备注");
            zongbiao1.Columns.Add("单位");


            for (int i = 0; i < dataGridViewX2.Rows.Count; i++)
            {
                string shaixuan = Convert.ToString(dataGridViewX2.Rows[i].Cells[0].Value);
                if (shaixuan == "1")
                {
                    string id = Convert.ToString(dataGridViewX2.Rows[i].Cells["id"].Value);

                    string sql1 = "select id,编码,名称,型号,实际采购数量,工作令号,备注,设备名称,项目名称,类型,单位,采购单价 from  tb_caigouliaodan  where id ='" + id + "' ";
                    dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);

                    zongbiao1.Merge(dt1, true, MissingSchemaAction.Ignore);

                }

            }
            Frhetongmoban form1 = new Frhetongmoban();
            form1.dt = zongbiao1;
            form1.yonghu = yonghu;
            form1.zhonglei = "普通";
            form1.ShowDialog();
            if (form1.DialogResult == DialogResult.OK)
            {
                DataTable dt = new DataTable();
                DataTable zongbiao = new DataTable();
                zongbiao.Columns.Add("工作令号");
                zongbiao.Columns.Add("项目名称");
                zongbiao.Columns.Add("设备名称");
                zongbiao.Columns.Add("id");
                zongbiao.Columns.Add("编码");
                zongbiao.Columns.Add("型号");
                zongbiao.Columns.Add("名称");
                zongbiao.Columns.Add("单位");
                zongbiao.Columns.Add("数量");
                zongbiao.Columns.Add("类型");
                zongbiao.Columns.Add("项目工令号");
                zongbiao.Columns.Add("要求到货日期");
                zongbiao.Columns.Add("备注");
                zongbiao.Columns.Add("制造类型");
                zongbiao.Columns.Add("申购人");
                zongbiao.Columns.Add("收到料单日期");
                zongbiao.Columns.Add("供方名称");
                zongbiao.Columns.Add("合同号");
                zongbiao.Columns.Add("实际采购数量");
                zongbiao.Columns.Add("实际到货日期");
                zongbiao.Columns.Add("当前状态");
                zongbiao.Columns.Add("采购料单备注");
                zongbiao.Columns.Add("附件类型");
                zongbiao.Columns.Add("附件名称");
                zongbiao.Columns.Add("合同预计时间");

                for (int i = 0; i < dataGridViewX2.Rows.Count; i++)
                {
                   
                    string id = Convert.ToString(dataGridViewX2.Rows[i].Cells["id"].Value);

                    string sql1 = "select id,工作令号,项目名称,设备名称,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,申购人,收到料单日期,供方名称,合同号,实际采购数量,报价, 采购单价,实际到货日期,当前状态,采购料单备注,附件名称,附件类型,合同预计时间 from  tb_caigouliaodan  where id='" + id + "' ";
                    dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                    zongbiao.Merge(dt, true, MissingSchemaAction.Ignore);

                }
                dataGridViewX2.DataSource = zongbiao;


            }

        }

        private void 生成采购合同ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DataTable dt1 = new DataTable();
            DataTable zongbiao1 = new DataTable();

            dt1.Columns.Add("id");
            dt1.Columns.Add("工作令号");
            dt1.Columns.Add("项目名称");
            dt1.Columns.Add("设备名称");
            dt1.Columns.Add("编码");
            dt1.Columns.Add("名称");
            dt1.Columns.Add("型号");
            dt1.Columns.Add("类型");
            dt1.Columns.Add("实际采购数量");
            dt1.Columns.Add("采购单价");
            dt1.Columns.Add("总价");
            dt1.Columns.Add("备注");
            dt1.Columns.Add("单位");
            zongbiao1.Columns.Add("id");
            zongbiao1.Columns.Add("工作令号");
            zongbiao1.Columns.Add("项目名称");
            zongbiao1.Columns.Add("设备名称");
            zongbiao1.Columns.Add("编码");
            zongbiao1.Columns.Add("名称");
            zongbiao1.Columns.Add("型号");
            zongbiao1.Columns.Add("类型");
            zongbiao1.Columns.Add("实际采购数量");
            zongbiao1.Columns.Add("采购单价");
            zongbiao1.Columns.Add("总价");
            zongbiao1.Columns.Add("备注");
            zongbiao1.Columns.Add("单位");



            for (int i = 0; i < dataGridViewX2.Rows.Count; i++)
            {
                string shaixuan = Convert.ToString(dataGridViewX2.Rows[i].Cells[0].Value);
                if (shaixuan == "1")
                {
                    string id = Convert.ToString(dataGridViewX2.Rows[i].Cells["id"].Value);


                    string sql1 = "select id,编码,名称,型号,实际采购数量,工作令号,备注,设备名称,项目名称,类型,单位,采购单价 from  tb_caigouliaodan  where id ='" + id + "' ";
                    dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);

                    zongbiao1.Merge(dt1, true, MissingSchemaAction.Ignore);

                }

            }
            Frhetongmoban form1 = new Frhetongmoban();
            form1.dt = zongbiao1;
            form1.yonghu = yonghu;
            form1.zhonglei = "采购";
            form1.ShowDialog();
            if (form1.DialogResult == DialogResult.OK)
            {
                DataTable dt = new DataTable();
                DataTable zongbiao = new DataTable();
                zongbiao.Columns.Add("工作令号");
                zongbiao.Columns.Add("项目名称");
                zongbiao.Columns.Add("设备名称");
                zongbiao.Columns.Add("id");
                zongbiao.Columns.Add("编码");
                zongbiao.Columns.Add("型号");
                zongbiao.Columns.Add("名称");
                zongbiao.Columns.Add("单位");
                zongbiao.Columns.Add("数量");
                zongbiao.Columns.Add("类型");
                zongbiao.Columns.Add("项目工令号");
                zongbiao.Columns.Add("要求到货日期");
                zongbiao.Columns.Add("备注");
                zongbiao.Columns.Add("制造类型");
                zongbiao.Columns.Add("申购人");
                zongbiao.Columns.Add("收到料单日期");
                zongbiao.Columns.Add("供方名称");
                zongbiao.Columns.Add("合同号");
                zongbiao.Columns.Add("实际采购数量");
                zongbiao.Columns.Add("实际到货日期");
                zongbiao.Columns.Add("当前状态");
                zongbiao.Columns.Add("采购料单备注");
                zongbiao.Columns.Add("附件类型");
                zongbiao.Columns.Add("附件名称");
                zongbiao.Columns.Add("合同预计时间");

                for (int i = 0; i < dataGridViewX2.Rows.Count; i++)
                {
                    

                    string id = Convert.ToString(dataGridViewX2.Rows[i].Cells["id"].Value);

                    string sql1 = "select id,工作令号,项目名称,设备名称,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,申购人,收到料单日期,供方名称,合同号,实际采购数量,报价, 采购单价,实际到货日期,当前状态,采购料单备注,附件名称,附件类型,合同预计时间 from  tb_caigouliaodan  where id='" + id + "' ";
                    dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                    zongbiao.Merge(dt, true, MissingSchemaAction.Ignore);

                }
                dataGridViewX2.DataSource = zongbiao;


            }
        }

        private void 生成设备合同ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DataTable dt1 = new DataTable();
            DataTable zongbiao1 = new DataTable();

            dt1.Columns.Add("id");
            dt1.Columns.Add("工作令号");
            dt1.Columns.Add("项目名称");
            dt1.Columns.Add("设备名称");
            dt1.Columns.Add("编码");
            dt1.Columns.Add("名称");
            dt1.Columns.Add("型号");
            dt1.Columns.Add("类型");
            dt1.Columns.Add("实际采购数量");
            dt1.Columns.Add("采购单价");
            dt1.Columns.Add("总价");
            dt1.Columns.Add("备注");
            dt1.Columns.Add("单位");
            zongbiao1.Columns.Add("id");
            zongbiao1.Columns.Add("工作令号");
            zongbiao1.Columns.Add("项目名称");
            zongbiao1.Columns.Add("设备名称");
            zongbiao1.Columns.Add("编码");
            zongbiao1.Columns.Add("名称");
            zongbiao1.Columns.Add("型号");
            zongbiao1.Columns.Add("类型");
            zongbiao1.Columns.Add("实际采购数量");
            zongbiao1.Columns.Add("采购单价");
            zongbiao1.Columns.Add("总价");
            zongbiao1.Columns.Add("备注");
            zongbiao1.Columns.Add("单位");




            for (int i = 0; i < dataGridViewX2.Rows.Count; i++)
            {

                string shaixuan = Convert.ToString(dataGridViewX2.Rows[i].Cells[0].Value);
                if (shaixuan == "1")
                {
                    string id = Convert.ToString(dataGridViewX2.Rows[i].Cells["id"].Value);

                    string sql1 = "select id,编码,名称,型号,实际采购数量,工作令号,备注,设备名称,项目名称,类型,单位,采购单价 from  tb_caigouliaodan  where id ='" + id + "' ";
                    dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);

                    zongbiao1.Merge(dt1, true, MissingSchemaAction.Ignore);


                }
            }
            Frhetongmoban form1 = new Frhetongmoban();
            form1.dt = zongbiao1;
            form1.yonghu = yonghu;
            form1.zhonglei = "设备";
            form1.ShowDialog();
            if (form1.DialogResult == DialogResult.OK)
            {
                DataTable dt = new DataTable();
                DataTable zongbiao = new DataTable();
                zongbiao.Columns.Add("工作令号");
                zongbiao.Columns.Add("项目名称");
                zongbiao.Columns.Add("设备名称");
                zongbiao.Columns.Add("id");
                zongbiao.Columns.Add("编码");
                zongbiao.Columns.Add("型号");
                zongbiao.Columns.Add("名称");
                zongbiao.Columns.Add("单位");
                zongbiao.Columns.Add("数量");
                zongbiao.Columns.Add("类型");
                zongbiao.Columns.Add("项目工令号");
                zongbiao.Columns.Add("要求到货日期");
                zongbiao.Columns.Add("备注");
                zongbiao.Columns.Add("制造类型");
                zongbiao.Columns.Add("申购人");
                zongbiao.Columns.Add("收到料单日期");
                zongbiao.Columns.Add("供方名称");
                zongbiao.Columns.Add("合同号");
                zongbiao.Columns.Add("实际采购数量");
                zongbiao.Columns.Add("实际到货日期");
                zongbiao.Columns.Add("当前状态");
                zongbiao.Columns.Add("采购料单备注");
                zongbiao.Columns.Add("附件类型");
                zongbiao.Columns.Add("附件名称");
                zongbiao.Columns.Add("合同预计时间");

                for (int i = 0; i < dataGridViewX2.Rows.Count; i++)
                {
                    
                    string id = Convert.ToString(dataGridViewX2.Rows[i].Cells["id"].Value);

                    string sql1 = "select id,工作令号,项目名称,设备名称,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,申购人,收到料单日期,供方名称,合同号,实际采购数量,报价, 采购单价,实际到货日期,当前状态,采购料单备注,附件名称,附件类型,合同预计时间 from  tb_caigouliaodan  where id='" + id + "' ";
                    dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                    zongbiao.Merge(dt, true, MissingSchemaAction.Ignore);

                }
                dataGridViewX2.DataSource = zongbiao;


            }
        }

        private void 生成订货单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            DataTable zongbiao1 = new DataTable();

            dt1.Columns.Add("id");
            dt1.Columns.Add("工作令号");
            dt1.Columns.Add("项目名称");
            dt1.Columns.Add("设备名称");
            dt1.Columns.Add("编码");
            dt1.Columns.Add("名称");
            dt1.Columns.Add("型号");
            dt1.Columns.Add("类型");
            dt1.Columns.Add("实际采购数量");
            dt1.Columns.Add("采购单价");
            dt1.Columns.Add("总价");
            dt1.Columns.Add("备注");
            dt1.Columns.Add("单位");
            zongbiao1.Columns.Add("id");
            zongbiao1.Columns.Add("工作令号");
            zongbiao1.Columns.Add("项目名称");
            zongbiao1.Columns.Add("设备名称");
            zongbiao1.Columns.Add("编码");
            zongbiao1.Columns.Add("名称");
            zongbiao1.Columns.Add("型号");
            zongbiao1.Columns.Add("类型");
            zongbiao1.Columns.Add("实际采购数量");
            zongbiao1.Columns.Add("采购单价");
            zongbiao1.Columns.Add("总价");
            zongbiao1.Columns.Add("备注");
            zongbiao1.Columns.Add("单位");




            for (int i = 0; i < dataGridViewX2.Rows.Count; i++)
            {
                string shaixuan = Convert.ToString(dataGridViewX2.Rows[i].Cells[0].Value);
                if (shaixuan == "1")
                {

                    string id = Convert.ToString(dataGridViewX2.Rows[i].Cells["id"].Value);


                    string sql1 = "select id,编码,名称,型号,实际采购数量,工作令号,备注,设备名称,项目名称,类型,单位,采购单价 from  tb_caigouliaodan  where id ='" + id + "' ";
                    dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);

                    zongbiao1.Merge(dt1, true, MissingSchemaAction.Ignore);
                }

            }
            Frdingdan form1 = new Frdingdan();
            form1.dt = zongbiao1;
            form1.yonghu = yonghu;
            form1.zhonglei = "订单";
            form1.ShowDialog();
            if (form1.DialogResult == DialogResult.OK)
            {
                DataTable dt = new DataTable();
                DataTable zongbiao = new DataTable();
                zongbiao.Columns.Add("工作令号");
                zongbiao.Columns.Add("项目名称");
                zongbiao.Columns.Add("设备名称");
                zongbiao.Columns.Add("id");
                zongbiao.Columns.Add("编码");
                zongbiao.Columns.Add("型号");
                zongbiao.Columns.Add("名称");
                zongbiao.Columns.Add("单位");
                zongbiao.Columns.Add("数量");
                zongbiao.Columns.Add("类型");
                zongbiao.Columns.Add("项目工令号");
                zongbiao.Columns.Add("要求到货日期");
                zongbiao.Columns.Add("备注");
                zongbiao.Columns.Add("制造类型");
                zongbiao.Columns.Add("申购人");
                zongbiao.Columns.Add("收到料单日期");
                zongbiao.Columns.Add("供方名称");
                zongbiao.Columns.Add("合同号");
                zongbiao.Columns.Add("实际采购数量");
                zongbiao.Columns.Add("实际到货日期");
                zongbiao.Columns.Add("当前状态");
                zongbiao.Columns.Add("采购料单备注");
                zongbiao.Columns.Add("附件类型");
                zongbiao.Columns.Add("附件名称");
                zongbiao.Columns.Add("合同预计时间");

                for (int i = 0; i < dataGridViewX2.Rows.Count; i++)
                {
                   
                    string id = Convert.ToString(dataGridViewX2.Rows[i].Cells["id"].Value);

                    string sql1 = "select id,工作令号,项目名称,设备名称,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,申购人,收到料单日期,供方名称,合同号,实际采购数量,报价, 采购单价,实际到货日期,当前状态,采购料单备注,附件名称,附件类型,合同预计时间 from  tb_caigouliaodan  where id='" + id + "' ";
                    dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                    zongbiao.Merge(dt, true, MissingSchemaAction.Ignore);

                }
                dataGridViewX2.DataSource = zongbiao;


            }
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewX2.Rows.Count; i++)
            {
                if (i < 5000)
                {
                    dataGridViewX2.Rows[i].Cells["筛选"].Value = 1;
                }

            }
        }
    }
}
