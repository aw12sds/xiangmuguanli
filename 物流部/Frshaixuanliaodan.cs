using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.物流部
{
    public partial class Frshaixuanliaodan : DevExpress.XtraEditors.XtraForm
    {
        public Frshaixuanliaodan()
        {
           
            InitializeComponent();
        }
        public DataTable dt;
        public string yonghu;
        public string zhonglei;
        public string qingdan;
        private void Frshaixuanliaodan_Load(object sender, EventArgs e)
        {
            gridControl4.DataSource = dt;
            if (zhonglei == "付款")
            {
                //comdangqian.Visible = false;
                //buttonItem7.Visible = false;
                buttonItem8.Visible = false;
                buttonItem9.Visible = false;
            }
            gridView4.Columns["id"].Visible = false;
        }
        
        private void buttonItem7_Click(object sender, EventArgs e)
        {
           
        }

        private void buttonItem8_Click(object sender, EventArgs e)
        {
            int[] a = gridView4.GetSelectedRows();
            foreach (int i in a)
            {
                string id = Convert.ToString(gridView4.GetRowCellValue(i, "id"));
                string sql1 = "select 发票匹配,名称,实际到货数量 from tb_caigouliaodan where id='" + id + "'";
                DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                if (Convert.ToString(dt.Rows[0]["发票匹配"]) != "")
                {
                    string migncheng = dt.Rows[0]["名称"].ToString();
                    MessageBox.Show(migncheng + "已录入发票，无法再修改！");
                    return;
                }
                if (Convert.ToString(dt.Rows[0]["实际到货数量"]) != "")
                {
                    string migncheng = dt.Rows[0]["名称"].ToString();
                    MessageBox.Show(migncheng + "仓库已入库操作！无法修改");
                    return;
                }
            }


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

            int b = 0;
  
            foreach (int i in a)
            {
                b += 1;
                if (b <= 200)
                {
                    string id = gridView4.GetRowCellValue(i, "id").ToString();

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
               
                zongbiao.Columns.Add("要求到货日期");
                zongbiao.Columns.Add("备注");
                zongbiao.Columns.Add("制造类型");
                zongbiao.Columns.Add("申购人");
                zongbiao.Columns.Add("收到料单日期");
                zongbiao.Columns.Add("供方名称");
                zongbiao.Columns.Add("合同号");
                zongbiao.Columns.Add("实际采购数量");             
                zongbiao.Columns.Add("当前状态");
                zongbiao.Columns.Add("采购料单备注");              
                zongbiao.Columns.Add("附件名称");
               

                for (int i = 0; i < gridView4.RowCount; i++)
                {
                    string id = gridView4.GetRowCellValue(i, "id").ToString();
                    string sql1 = "select id,工作令号,项目名称,设备名称,编码,型号,名称,单位,数量,类型,要求到货日期,备注,制造类型,申购人,收到料单日期,供方名称,合同号,实际采购数量,采购单价,采购料单备注,附件名称,当前状态 from  tb_caigouliaodan  where id='" + id + "'";
                    dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                    zongbiao.Merge(dt, true, MissingSchemaAction.Ignore);
                }
                gridControl4.DataSource = zongbiao;
                gridView4.Columns["id"].Visible = false;
            }

        }

        private void buttonItem9_Click(object sender, EventArgs e)
        {
            int[] a = gridView4.GetSelectedRows();
            foreach (int i in a)
            {
                string id = Convert.ToString(gridView4.GetRowCellValue(i, "id"));
                string sql1 = "select 发票匹配,名称,实际到货数量 from tb_caigouliaodan where id='" + id + "'";
                DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                if (Convert.ToString(dt.Rows[0]["发票匹配"]) != "")
                {
                    string migncheng = dt.Rows[0]["名称"].ToString();
                    MessageBox.Show(migncheng + "已录入发票，无法再修改！");
                    return;
                }
                if (Convert.ToString(dt.Rows[0]["实际到货数量"]) != "")
                {
                    string migncheng = dt.Rows[0]["名称"].ToString();
                    MessageBox.Show(migncheng + "仓库已入库操作！无法修改");
                    return;
                }
            }

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

            int b = 0;
        

            foreach (int i in a)
            {
                b += 1;
                if (b <= 200)
                {
                    string id = gridView4.GetRowCellValue(i, "id").ToString();

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

                zongbiao.Columns.Add("要求到货日期");
                zongbiao.Columns.Add("备注");
                zongbiao.Columns.Add("制造类型");
                zongbiao.Columns.Add("申购人");
                zongbiao.Columns.Add("收到料单日期");
                zongbiao.Columns.Add("供方名称");
                zongbiao.Columns.Add("合同号");
                zongbiao.Columns.Add("实际采购数量");

                zongbiao.Columns.Add("当前状态");
                zongbiao.Columns.Add("采购料单备注");

                zongbiao.Columns.Add("附件名称");

                for (int i = 0; i < gridView4.RowCount; i++)
                {
                    string id = gridView4.GetRowCellValue(i, "id").ToString();
                    string sql1 = "select id,工作令号,项目名称,设备名称,编码,型号,名称,单位,数量,类型,要求到货日期,备注,制造类型,申购人,收到料单日期,供方名称,合同号,实际采购数量,采购单价,采购料单备注,附件名称,当前状态 from  tb_caigouliaodan  where id='" + id + "'";
                    dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                    zongbiao.Merge(dt, true, MissingSchemaAction.Ignore);

                }
                gridControl4.DataSource = zongbiao;
                gridView4.Columns["id"].Visible = false;

            }
        }

        private void buttonItem10_Click(object sender, EventArgs e)
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

            int b = 0;
            int[] a = gridView4.GetSelectedRows();

            foreach (int i in a)
            {
                b += 1;
                if (b <= 200)
                {
                    string id = gridView4.GetRowCellValue(i, "id").ToString();

                    string sql1 = "select id,编码,名称,型号,实际采购数量,工作令号,备注,设备名称,项目名称,类型,单位,采购单价 from  tb_caigouliaodan  where id ='" + id + "' ";
                    dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);

                    zongbiao1.Merge(dt1, true, MissingSchemaAction.Ignore);
                }

            }
            Frfukuan form1 = new Frfukuan();
            form1.dt = zongbiao1;
            form1.yonghu = yonghu;
            form1.zhonglei = "采购";
            form1.ShowDialog();
        }


        private void buttonItem6_Click_1(object sender, EventArgs e)
        {

        }

        private void buttonItem11_Click(object sender, EventArgs e)
        {
            int[] a = gridView4.GetSelectedRows();
            foreach (int i in a)
            {
                string id = Convert.ToString(gridView4.GetRowCellValue(i, "id"));
                string sql1 = "select 发票匹配,名称,实际到货数量 from tb_caigouliaodan where id='" + id + "'";
                DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                if (Convert.ToString(dt.Rows[0]["发票匹配"]) != "")
                {
                    string migncheng = dt.Rows[0]["名称"].ToString();
                    MessageBox.Show(migncheng + "已录入发票，无法再修改！");
                    return;
                }
                if (Convert.ToString(dt.Rows[0]["实际到货数量"]) != "")
                {
                    string migncheng = dt.Rows[0]["名称"].ToString();
                    MessageBox.Show(migncheng + "仓库已入库操作！无法修改");
                    return;
                }
            }

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

            int b = 0;
          

            foreach (int i in a)
            {
                b += 1;
                if (b <= 200)
                {
                    string id = gridView4.GetRowCellValue(i, "id").ToString();

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
                zongbiao.Columns.Add("要求到货日期");
                zongbiao.Columns.Add("备注");
                zongbiao.Columns.Add("制造类型");
                zongbiao.Columns.Add("申购人");
                zongbiao.Columns.Add("收到料单日期");
                zongbiao.Columns.Add("供方名称");
                zongbiao.Columns.Add("合同号");
                zongbiao.Columns.Add("实际采购数量");
                zongbiao.Columns.Add("当前状态");
                zongbiao.Columns.Add("采购料单备注");
                zongbiao.Columns.Add("附件名称");

                for (int i = 0; i < gridView4.RowCount; i++)
                {
                    string id = gridView4.GetRowCellValue(i, "id").ToString();
                    string sql1 = "select id,工作令号,项目名称,设备名称,编码,型号,名称,单位,数量,类型,要求到货日期,备注,制造类型,申购人,收到料单日期,供方名称,合同号,实际采购数量,采购单价,采购料单备注,附件名称,当前状态 from  tb_caigouliaodan  where id='" + id + "'";
                    dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                    zongbiao.Merge(dt, true, MissingSchemaAction.Ignore);

                }
                gridControl4.DataSource = zongbiao;
                gridView4.Columns["id"].Visible = false;

            }
        }

        private void buttonItem12_Click(object sender, EventArgs e)
        {
            int[] a = gridView4.GetSelectedRows();
            foreach (int i in a)
            {
                string id = gridView4.GetRowCellValue(i, "id").ToString();
                qingdan += id + "|";
            }
            MessageBox.Show("已加入购物车！");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonItem13_Click(object sender, EventArgs e)
        {
            int[] a = gridView4.GetSelectedRows();
            foreach (int i in a)
            {
                string id = Convert.ToString(gridView4.GetRowCellValue(i, "id"));
                string sql1 = "select 发票匹配,名称,实际到货数量 from tb_caigouliaodan where id='" + id + "'";
                DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                if (Convert.ToString(dt.Rows[0]["发票匹配"]) != "")
                {
                    string migncheng = dt.Rows[0]["名称"].ToString();
                    MessageBox.Show(migncheng + "已录入发票，无法再修改！");
                    return;
                }
                if (Convert.ToString(dt.Rows[0]["实际到货数量"]) != "")
                {
                    string migncheng = dt.Rows[0]["名称"].ToString();
                    MessageBox.Show(migncheng + "仓库已入库操作！无法修改");
                    return;
                }
            }

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
            int b = 0;
         

            foreach (int i in a)
            {
                b += 1;
                if (b <= 200)
                {
                    string id = gridView4.GetRowCellValue(i, "id").ToString();

                    string sql1 = "select id,编码,名称,型号,实际采购数量,工作令号,备注,设备名称,项目名称,类型,单位,采购单价 from  tb_caigouliaodan  where id ='" + id + "' ";
                    dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);

                    zongbiao1.Merge(dt1, true, MissingSchemaAction.Ignore);
                }
            }
            Frxunjia form1 = new Frxunjia();
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

                zongbiao.Columns.Add("要求到货日期");
                zongbiao.Columns.Add("备注");
                zongbiao.Columns.Add("制造类型");
                zongbiao.Columns.Add("申购人");
                zongbiao.Columns.Add("收到料单日期");
                zongbiao.Columns.Add("供方名称");
                zongbiao.Columns.Add("合同号");
                zongbiao.Columns.Add("实际采购数量");

                zongbiao.Columns.Add("当前状态");
                zongbiao.Columns.Add("采购料单备注");

                zongbiao.Columns.Add("附件名称");


                for (int i = 0; i < gridView4.RowCount; i++)
                {
                    string id = gridView4.GetRowCellValue(i, "id").ToString();
                    string sql1 = "select id,工作令号,项目名称,设备名称,编码,型号,名称,单位,数量,类型,要求到货日期,备注,制造类型,申购人,收到料单日期,供方名称,合同号,实际采购数量,采购单价,采购料单备注,附件名称,当前状态 from  tb_caigouliaodan  where id='" + id + "'";
                    dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                    zongbiao.Merge(dt, true, MissingSchemaAction.Ignore);

                }
                gridControl4.DataSource = zongbiao;
                gridView4.Columns["id"].Visible = false;
            }
        }

        private void buttonItem14_Click(object sender, EventArgs e)
        {
            int[] a = gridView4.GetSelectedRows();
            foreach (int i in a)
            {
                string id = Convert.ToString(gridView4.GetRowCellValue(i, "id"));
                string sql1 = "select 发票匹配,名称,实际到货数量 from tb_caigouliaodan where id='" + id + "'";
                DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                if (Convert.ToString(dt.Rows[0]["发票匹配"]) != "")
                {
                    string migncheng = dt.Rows[0]["名称"].ToString();
                    MessageBox.Show(migncheng + "已录入发票，无法再修改！");
                    return;
                }
                if (Convert.ToString(dt.Rows[0]["实际到货数量"]) != "")
                {
                    string migncheng = dt.Rows[0]["名称"].ToString();
                    MessageBox.Show(migncheng + "仓库已入库操作！无法修改");
                    return;
                }
            }

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

            int b = 0;
           

            foreach (int i in a)
            {
                b += 1;
                if (b <= 200)
                {
                    string id = gridView4.GetRowCellValue(i, "id").ToString();

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

                zongbiao.Columns.Add("要求到货日期");
                zongbiao.Columns.Add("备注");
                zongbiao.Columns.Add("制造类型");
                zongbiao.Columns.Add("申购人");
                zongbiao.Columns.Add("收到料单日期");
                zongbiao.Columns.Add("供方名称");
                zongbiao.Columns.Add("合同号");
                zongbiao.Columns.Add("实际采购数量");

                zongbiao.Columns.Add("当前状态");
                zongbiao.Columns.Add("采购料单备注");

                zongbiao.Columns.Add("附件名称");


                for (int i = 0; i < gridView4.RowCount; i++)
                {
                    string id = gridView4.GetRowCellValue(i, "id").ToString();
                    string sql1 = "select id,工作令号,项目名称,设备名称,编码,型号,名称,单位,数量,类型,要求到货日期,备注,制造类型,申购人,收到料单日期,供方名称,合同号,实际采购数量,采购单价,采购料单备注,附件名称,当前状态 from  tb_caigouliaodan  where id='" + id + "'";
                    dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                    zongbiao.Merge(dt, true, MissingSchemaAction.Ignore);

                }
                gridControl4.DataSource = zongbiao;
                gridView4.Columns["id"].Visible = false;

            }
        }



        private void buttonItem5_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog lujingg = new FolderBrowserDialog();
            if (lujingg.ShowDialog() == DialogResult.OK)
            {
                string xuanzelujing = lujingg.SelectedPath;
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    string mingcheng = Convert.ToString(dt.Rows[i]["附件名称"]);
                    string id = Convert.ToString(dt.Rows[i]["id"]);

                    string sql = "select 附件类型 from tb_caigouliaodan where id='" + id + "'";

                    if (mingcheng != "")
                    {

                        string leixing = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();

                        byte[] mypdffile = null;
                        string ConStr = "Select 附件 From tb_caigouliaodan Where id='" + id + "'";
                        mypdffile = SQLhelp.duqu(ConStr, CommandType.Text);
                        string lujing = xuanzelujing + "\\" + mingcheng + "." + leixing;
                        FileStream fs = new FileStream(lujing, FileMode.Create);
                        fs.Write(mypdffile, 0, mypdffile.Length);
                        fs.Flush();
                        fs.Close();

                    }

                }
                MessageBox.Show("下载成功");//显示异常信息
            }
        }

        private void gridView4_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
            {

                string id = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id"));

                string sql = "select 附件名称 from tb_caigouliaodan where id='" + id + "'";
                string mingcheng = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
                if (mingcheng == "")
                {
                    MessageBox.Show("没有附件！");
                    return;
                }

                string sql2 = "select 附件类型 from tb_caigouliaodan where id='" + id + "'";
                string leixing = SQLhelp.ExecuteScalar(sql2, CommandType.Text).ToString();

                byte[] mypdffile = null;

                string sql4 = "Select 附件 From tb_caigouliaodan Where id='" + id + "' ";

                mypdffile = SQLhelp.duqu(sql4, CommandType.Text);
                this.Cursor = Cursors.WaitCursor;

                string aaaa = System.Environment.CurrentDirectory;
                string bbbb = mingcheng.Replace("?", "1");
                string lujing = aaaa + "\\" + bbbb + "1" + "." + leixing;
                FileStream fs = new FileStream(lujing, FileMode.Create);
                fs.Write(mypdffile, 0, mypdffile.Length);
                fs.Flush();
                fs.Close();
                this.Cursor = Cursors.Default;
                System.Diagnostics.Process.Start(lujing);
            }
        }

        private void gridView4_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }


        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            try
            {
                int[] a = gridView4.GetSelectedRows();
                foreach (int i in a)
                {
                    string id = gridView4.GetRowCellValue(i, "id").ToString();
                    
                    string sql2 = "update tb_caigouliaodan  set 当前状态= '9已到货'  where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql2, CommandType.Text);
                }

                MessageBox.Show("修改成功！");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

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

            for (int i = 0; i < gridView4.RowCount; i++)
            {
                string id = gridView4.GetRowCellValue(i, "id").ToString();
                string sql1 = "select id,工作令号,项目名称,设备名称,编码,型号,名称,单位,数量,类型,要求到货日期,备注,制造类型,申购人,收到料单日期,供方名称,合同号,实际采购数量,采购单价,采购料单备注,附件名称,当前状态 from  tb_caigouliaodan  where id='" + id + "'";
                dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                zongbiao.Merge(dt, true, MissingSchemaAction.Ignore);

            }
            gridControl4.DataSource = zongbiao;
            gridView4.Columns["id"].Visible = false;
        }

        private void bar1_ItemClick(object sender, EventArgs e)
        {

        }
    }
}

