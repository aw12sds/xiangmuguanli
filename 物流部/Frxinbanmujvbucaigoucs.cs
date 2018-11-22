using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;

namespace 项目管理系统.物流部
{
    public partial class Frxinbanmujvbucaigoucs : DevExpress.XtraEditors.XtraForm
    {
        public Frxinbanmujvbucaigoucs()
        {
            InitializeComponent();
        }
        public string yonghu;
        private void Frxinbanmujvbucaigoucs_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void reload()
        {

            string sql = "select * from tb_operator where 用户名='" + yonghu + "'";
            DataTable dtt = sqlhelp111.GetDataTable(sql, CommandType.Text);
            string mujv = Convert.ToString(dtt.Rows[0]["模具采购"]);

            if (mujv == "1")
            {
                string sql1 = "select  a.采购料单备注,a.id,a.工作令号,a.编码,a.型号,a.名称,a.实际采购数量,a.类型,a.模具部申请人,a.备注,a.当前状态,a.收到料单日期,a.合同号,a.供方名称,a.单位,a.采购单价,a.要求到货日期,a.附件名称,a.模具部接单日期,b.statename,a.收到发票日期,a.发票号 from tb_caigouliaodan a left join tb_state b on a.当前状态 = b.state  where a.料单类型='模具部' and a.制造类型='外协' and b.cato='模具部' ";
                DataTable inv1 = SQLhelp.GetDataTable(sql1, CommandType.Text);
                gridControl4.DataSource = inv1;

                string sql11 = "select  a.采购料单备注,a.id,a.工作令号,a.编码,a.型号,a.名称,a.实际采购数量,a.项目名称,a.类型,a.模具部申请人,a.备注,a.当前状态,a.收到料单日期,a.合同号,a.供方名称,a.单位,a.模具部接单日期,a.采购单价,a.要求到货日期,a.附件名称,b.statename,a.收到发票日期,a.发票号 from tb_caigouliaodan a left join tb_state b on a.当前状态 = b.state where 料单类型='模具部原材料' and b.cato='模具部原材料'  and 模具部成本是否工序='原材料' ";
                DataTable inv2 = SQLhelp.GetDataTable(sql11, CommandType.Text);
                gridControl1.DataSource = inv2;


                string sql111 = "select  a.采购料单备注,a.id,a.工作令号,a.编码,a.型号,a.名称,a.实际采购数量,a.项目名称,a.类型,a.模具部申请人,a.备注,a.当前状态,a.收到料单日期,a.合同号,a.供方名称,a.单位,a.模具部接单日期,a.采购单价,a.要求到货日期,a.附件名称,b.statename,a.收到发票日期,a.发票号 from tb_caigouliaodan a left join tb_state b on a.当前状态 = b.state where 料单类型='模具部原材料' and b.cato='模具部原材料'  and 模具部成本是否工序='五金辅材' ";
                DataTable inv23 = SQLhelp.GetDataTable(sql111, CommandType.Text);
                gridControl2.DataSource = inv23;


                string sql112 = "select  a.采购料单备注,a.id,a.工作令号,a.编码,a.型号,a.名称,a.实际采购数量,a.项目名称,a.类型,a.模具部申请人,a.备注,a.当前状态,a.收到料单日期,a.合同号,a.供方名称,a.单位,a.模具部接单日期,a.采购单价,a.要求到货日期,a.附件名称,b.statename,a.收到发票日期,a.发票号 from tb_caigouliaodan a left join tb_state b on a.当前状态 = b.state where 料单类型='模具部原材料' and b.cato='模具部原材料'  and 模具部成本是否工序='工序外协' ";
                DataTable inv22 = SQLhelp.GetDataTable(sql112, CommandType.Text);
                gridControl3.DataSource = inv22;

            }
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            int bb = 0;
            int[] aa = gridView4.GetSelectedRows();

            foreach (int i in aa)
            {
                bb += 1;
                if (bb <= 200)
                {
                    string id = gridView4.GetRowCellValue(i, "statename").ToString().Trim();
                    string bianma = gridView4.GetRowCellValue(i, "编码").ToString().Trim();
                    if (bianma.Trim() == "")
                    {
                        MessageBox.Show("有的编码为空！，无法生成合同");
                        return;
                    }
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
            dt1.Columns.Add("单位");
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
            zongbiao1.Columns.Add("单位");
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

            Frhetongmoban form1 = new Frhetongmoban();
            form1.dt = zongbiao1;
            form1.yonghu = yonghu;
            form1.zhonglei = "普通";
            form1.ShowDialog();
            if (form1.DialogResult == DialogResult.OK)
            {
                reload();

            }

        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            int bb = 0;
            int[] aa = gridView4.GetSelectedRows();

            foreach (int i in aa)
            {
                bb += 1;
                if (bb <= 200)
                {
                    string id = gridView4.GetRowCellValue(i, "statename").ToString().Trim();
                    string bianma = gridView4.GetRowCellValue(i, "编码").ToString().Trim();
                    if (bianma.Trim() == "")
                    {
                        MessageBox.Show("有的编码为空！，无法生成合同");
                        return;
                    }

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
            dt1.Columns.Add("单位");
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
            zongbiao1.Columns.Add("单位");
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

            Frhetongmoban form1 = new Frhetongmoban();
            form1.dt = zongbiao1;
            form1.yonghu = yonghu;
            form1.zhonglei = "采购";
            form1.ShowDialog();
            if (form1.DialogResult == DialogResult.OK)
            {
                reload();

            }


        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            int bb = 0;
            int[] aa = gridView4.GetSelectedRows();

            foreach (int i in aa)
            {
                bb += 1;
                if (bb <= 200)
                {
                    string id = gridView4.GetRowCellValue(i, "statename").ToString().Trim();
                    string bianma = gridView4.GetRowCellValue(i, "编码").ToString().Trim();
                    if (bianma.Trim() == "")
                    {
                        MessageBox.Show("有的编码为空！，无法生成合同");
                        return;
                    }

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
            dt1.Columns.Add("单位");
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
            zongbiao1.Columns.Add("单位");
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
            Frxunjia form1 = new Frxunjia();
            form1.dt = zongbiao1;
            form1.yonghu = yonghu;
            form1.zhonglei = "设备";
            form1.ShowDialog();
            if (form1.DialogResult == DialogResult.OK)
            {
                reload();

            }

        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            int bb = 0;
            int[] aa = gridView4.GetSelectedRows();

            foreach (int i in aa)
            {
                bb += 1;
                if (bb <= 200)
                {
                    string id = gridView4.GetRowCellValue(i, "statename").ToString().Trim();
                    string bianma = gridView4.GetRowCellValue(i, "编码").ToString().Trim();
                    if (bianma.Trim() == "")
                    {
                        MessageBox.Show("有的编码为空！，无法生成合同");
                        return;
                    }

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
            dt1.Columns.Add("单位");
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
            zongbiao1.Columns.Add("单位");
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

            Frdingdan form1 = new Frdingdan();
            form1.dt = zongbiao1;
            form1.yonghu = yonghu;
            form1.zhonglei = "订单";

            form1.ShowDialog();
            if (form1.DialogResult == DialogResult.OK)
            {
                reload();

            }

        }

        private void gridView4_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            int bb = 0;
            int[] aa = gridView1.GetSelectedRows();

            foreach (int i in aa)
            {
                bb += 1;
                if (bb <= 200)
                {
                    string id = gridView1.GetRowCellValue(i, "statename").ToString().Trim();
                    string bianma = gridView1.GetRowCellValue(i, "编码").ToString().Trim();
                    if (bianma.Trim() == "")
                    {
                        MessageBox.Show("有的编码为空！，无法生成合同");
                        return;
                    }

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
            dt1.Columns.Add("单位");
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
            zongbiao1.Columns.Add("单位");
            zongbiao1.Columns.Add("采购单价");
            zongbiao1.Columns.Add("总价");
            zongbiao1.Columns.Add("备注");



            int b = 0;
            int[] a = gridView1.GetSelectedRows();

            foreach (int i in a)
            {
                b += 1;
                if (b <= 200)
                {
                    string id = gridView1.GetRowCellValue(i, "id").ToString();

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
                reload();

            }


        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            int bb = 0;
            int[] aa = gridView1.GetSelectedRows();

            foreach (int i in aa)
            {
                bb += 1;
                if (bb <= 200)
                {
                    string id = gridView1.GetRowCellValue(i, "statename").ToString().Trim();
                    string bianma = gridView1.GetRowCellValue(i, "编码").ToString().Trim();
                    if (bianma.Trim() == "")
                    {
                        MessageBox.Show("有的编码为空！，无法生成合同");
                        return;
                    }

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
            dt1.Columns.Add("单位");
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
            zongbiao1.Columns.Add("单位");
            zongbiao1.Columns.Add("采购单价");
            zongbiao1.Columns.Add("总价");
            zongbiao1.Columns.Add("备注");


            int b = 0;
            int[] a = gridView1.GetSelectedRows();

            foreach (int i in a)
            {
                b += 1;
                if (b <= 200)
                {
                    string id = gridView1.GetRowCellValue(i, "id").ToString();


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
                reload();

            }

        }

        private void buttonItem7_Click(object sender, EventArgs e)
        {
            int bb = 0;
            int[] aa = gridView1.GetSelectedRows();

            foreach (int i in aa)
            {
                bb += 1;
                if (bb <= 200)
                {
                    string id = gridView1.GetRowCellValue(i, "statename").ToString().Trim();
                    string bianma = gridView1.GetRowCellValue(i, "编码").ToString().Trim();
                    if (bianma.Trim() == "")
                    {
                        MessageBox.Show("有的编码为空！，无法生成合同");
                        return;
                    }

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
            dt1.Columns.Add("单位");
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
            zongbiao1.Columns.Add("单位");
            zongbiao1.Columns.Add("采购单价");
            zongbiao1.Columns.Add("总价");
            zongbiao1.Columns.Add("备注");

            int b = 0;
            int[] a = gridView1.GetSelectedRows();

            foreach (int i in a)
            {
                b += 1;
                if (b <= 200)
                {
                    string id = gridView1.GetRowCellValue(i, "id").ToString();

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
                reload();

            }

        }

        private void buttonItem8_Click(object sender, EventArgs e)
        {
            int bb = 0;
            int[] aa = gridView1.GetSelectedRows();

            foreach (int i in aa)
            {
                bb += 1;
                if (bb <= 200)
                {
                    string id = gridView1.GetRowCellValue(i, "statename").ToString().Trim();
                    string bianma = gridView1.GetRowCellValue(i, "编码").ToString().Trim();
                    if (bianma.Trim() == "")
                    {
                        MessageBox.Show("有的编码为空！，无法生成合同");
                        return;
                    }
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
            dt1.Columns.Add("单位");
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
            zongbiao1.Columns.Add("单位");
            zongbiao1.Columns.Add("采购单价");
            zongbiao1.Columns.Add("总价");
            zongbiao1.Columns.Add("备注");


            int b = 0;
            int[] a = gridView1.GetSelectedRows();

            foreach (int i in a)
            {
                b += 1;
                if (b <= 200)
                {
                    string id = gridView1.GetRowCellValue(i, "id").ToString();

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
                reload();

            }

        }

        private void 查看图纸ToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void 查看附件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));


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
        public string qingdan;
        private void buttonItem9_Click(object sender, EventArgs e)
        {
            int[] a = gridView1.GetSelectedRows();
            foreach (int i in a)
            {
                string id = gridView1.GetRowCellValue(i, "id").ToString();
                qingdan += id + "|";
            }
            MessageBox.Show("已加入购物车！");

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

        }

        private void buttonItem13_Click(object sender, EventArgs e)
        {
            qingdan = "";
            MessageBox.Show("购物车已清空！");

        }

        private void buttonItem14_Click(object sender, EventArgs e)
        {

            if (qingdan == "")
            {
                MessageBox.Show("购物车没有东西,请添加！");
                return;
            }
            DataTable dt = new DataTable();
            DataTable zongbiao = new DataTable();
            dt.Columns.Add("工作令号");
            dt.Columns.Add("项目名称");
            dt.Columns.Add("设备名称");
            dt.Columns.Add("id");
            dt.Columns.Add("编码");
            dt.Columns.Add("型号");
            dt.Columns.Add("名称");
            dt.Columns.Add("单位");
            dt.Columns.Add("数量");
            dt.Columns.Add("类型");
            dt.Columns.Add("项目工令号");
            dt.Columns.Add("要求到货日期");
            dt.Columns.Add("备注");
            dt.Columns.Add("制造类型");
            dt.Columns.Add("申购人");
            dt.Columns.Add("收到料单日期");
            dt.Columns.Add("供方名称");
            dt.Columns.Add("合同号");
            dt.Columns.Add("实际采购数量");
            dt.Columns.Add("实际到货日期");
            dt.Columns.Add("当前状态");
            dt.Columns.Add("采购料单备注");
            dt.Columns.Add("附件类型");
            dt.Columns.Add("附件名称");
            dt.Columns.Add("合同预计时间");


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

            string[] strArray = qingdan.Split('|'); //字符串转数组
            List<string> list = new List<string>();
            for (int i = 0; i < strArray.Length; i++)//遍历数组成员
            {
                if (list.IndexOf(strArray[i].ToLower()) == -1)//对每个成员做一次新数组查询如果没有相等的则加到新数组
                    list.Add(strArray[i]);

            }

            for (int i = 0; i < list.Count; i++)
            {
                string dingwei = list[i];

                string sql1 = "select id,工作令号,项目名称,设备名称,编码,型号,名称,单位,数量,类型,要求到货日期,备注,制造类型,申购人,收到料单日期,供方名称,合同号,实际采购数量,采购单价,当前状态,采购料单备注,附件名称,附件类型 from  tb_caigouliaodan  where id ='" + dingwei + "' ";
                dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                zongbiao.Merge(dt, true, MissingSchemaAction.Ignore);

            }
            Frshaixuanliaodan form1 = new Frshaixuanliaodan();
            form1.dt = zongbiao;
            form1.yonghu = yonghu;
            form1.ShowDialog();
            if (form1.DialogResult == DialogResult.OK)
            {
                reload();
            }
        }

        private void buttonItem10_Click(object sender, EventArgs e)
        {
            qingdan = "";
            MessageBox.Show("购物车已清空！");

        }

        private void buttonItem11_Click(object sender, EventArgs e)
        {
            if (qingdan == "")
            {
                MessageBox.Show("购物车没有东西,请添加！");
                return;
            }
            DataTable dt = new DataTable();
            DataTable zongbiao = new DataTable();
            dt.Columns.Add("工作令号");
            dt.Columns.Add("项目名称");
            dt.Columns.Add("设备名称");
            dt.Columns.Add("id");
            dt.Columns.Add("编码");
            dt.Columns.Add("型号");
            dt.Columns.Add("名称");
            dt.Columns.Add("单位");
            dt.Columns.Add("数量");
            dt.Columns.Add("类型");
            dt.Columns.Add("项目工令号");
            dt.Columns.Add("要求到货日期");
            dt.Columns.Add("备注");
            dt.Columns.Add("制造类型");
            dt.Columns.Add("申购人");
            dt.Columns.Add("收到料单日期");
            dt.Columns.Add("供方名称");
            dt.Columns.Add("合同号");
            dt.Columns.Add("实际采购数量");
            dt.Columns.Add("实际到货日期");
            dt.Columns.Add("当前状态");
            dt.Columns.Add("采购料单备注");
            dt.Columns.Add("附件类型");
            dt.Columns.Add("附件名称");
            dt.Columns.Add("合同预计时间");


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
            string[] strArray = qingdan.Split('|'); //字符串转数组
            List<string> list = new List<string>();
            for (int i = 0; i < strArray.Length; i++)//遍历数组成员
            {
                if (list.IndexOf(strArray[i].ToLower()) == -1)//对每个成员做一次新数组查询如果没有相等的则加到新数组
                    list.Add(strArray[i]);
            }
            for (int i = 0; i < list.Count; i++)
            {
                string dingwei = list[i];

                string sql1 = "select id,工作令号,项目名称,设备名称,编码,型号,名称,单位,数量,类型,要求到货日期,备注,制造类型,申购人,收到料单日期,供方名称,合同号,实际采购数量,采购单价,当前状态,采购料单备注,附件名称,附件类型 from  tb_caigouliaodan  where id ='" + dingwei + "' ";
                dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                zongbiao.Merge(dt, true, MissingSchemaAction.Ignore);
            }
            Frshaixuanliaodan form1 = new Frshaixuanliaodan();
            form1.dt = zongbiao;
            form1.yonghu = yonghu;
            form1.ShowDialog();
            if (form1.DialogResult == DialogResult.OK)
            {
                reload();
            }
        }
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] a = gridView4.GetSelectedRows();

            foreach (int i in a)
            {
                string id = Convert.ToString(gridView4.GetRowCellValue(i, "id"));
                string sql12 = "select 发票匹配,名称 from tb_caigouliaodan where id='" + id + "'";
                DataTable dt = SQLhelp.GetDataTable(sql12, CommandType.Text);
                if (Convert.ToString(dt.Rows[0]["发票匹配"]) != "")
                {
                    string migncheng = dt.Rows[0]["名称"].ToString();
                    MessageBox.Show(migncheng + "已录入发票，无法再修改！");
                    return;
                }
                string sql2 = "update tb_caigouliaodan  set  where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql2, CommandType.Text);

            }
            MessageBox.Show("保存成功！");
            reload();
        }
        private void 保存ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int[] a = gridView1.GetSelectedRows();

            foreach (int i in a)
            {
                string fapiaoriqi = Convert.ToString(gridView1.GetRowCellValue(i, "发票日期"));
                string id = Convert.ToString(gridView1.GetRowCellValue(i, "id"));
                string shoudaofapiaoDate = Convert.ToString(gridView1.GetRowCellValue(i, "收到发票日期"));
                string fapiaoNumber = Convert.ToString(gridView1.GetRowCellValue(i, "发票号"));
                string fapiaoDate = Convert.ToString(gridView1.GetRowCellValue(i, "发票日期"));
                string fapiaoPrice = Convert.ToString(gridView1.GetRowCellValue(i, "发票金额"));
                string shengqingjine1 = Convert.ToString(gridView1.GetRowCellValue(i, "申请付款金额1"));
                string shengqingDate1 = Convert.ToString(gridView1.GetRowCellValue(i, "申请付款日期1"));
                string shengqingjine2 = Convert.ToString(gridView1.GetRowCellValue(i, "申请付款金额2"));
                string shengqingDate2 = Convert.ToString(gridView1.GetRowCellValue(i, "申请付款日期2"));
                string shengqingjine3 = Convert.ToString(gridView1.GetRowCellValue(i, "申请付款金额3"));
                string shengqingDate3 = Convert.ToString(gridView1.GetRowCellValue(i, "申请付款日期3"));
                string shengqingjine4 = Convert.ToString(gridView1.GetRowCellValue(i, "申请付款金额4"));
                string shengqingDate4 = Convert.ToString(gridView1.GetRowCellValue(i, "申请付款日期4"));
                string shengqingjine5 = Convert.ToString(gridView1.GetRowCellValue(i, "申请付款金额5"));
                string shengqingDate5 = Convert.ToString(gridView1.GetRowCellValue(i, "申请付款日期5"));
                string kaihuhang = Convert.ToString(gridView1.GetRowCellValue(i, "开户行以及账户"));
                string hetongyaoqiu = Convert.ToString(gridView1.GetRowCellValue(i, "合同要求付款日期及方式"));
                string yaoqiudaohuoDate = Convert.ToString(gridView1.GetRowCellValue(i, "要求到货日期"));
                string sql12 = "select 发票匹配,名称 from tb_caigouliaodan where id='" + id + "'";
                DataTable dt = SQLhelp.GetDataTable(sql12, CommandType.Text);
                if (Convert.ToString(dt.Rows[0]["发票匹配"]) != "")
                {
                    string migncheng = dt.Rows[0]["名称"].ToString();
                    MessageBox.Show(migncheng + "已录入发票，无法再修改！");
                    return;
                }
                string sql2 = "update tb_caigouliaodan  set 发票日期='" + fapiaoriqi + "',申请付款金额1='" + shengqingjine1 + "',申请付款日期1='" + shengqingDate1 + "',申请付款金额2='" + shengqingjine2 + "',申请付款日期2='" + shengqingDate2 + "',申请付款金额3='" + shengqingjine3 + "',申请付款日期3='" + shengqingDate3 + "',申请付款金额4='" + shengqingjine4 + "',申请付款日期4='" + shengqingDate4 + "',申请付款金额5='" + shengqingjine5 + "',申请付款日期5='" + shengqingDate5 + "',开户行以及账户='" + kaihuhang + "',合同要求付款日期及方式='" + hetongyaoqiu + "',要求到货日期='" + yaoqiudaohuoDate + "' where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql2, CommandType.Text);
            }
            MessageBox.Show("保存成功！");
            reload();
        }
        private void 导出报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "导出Excel";
            fileDialog.Filter = "Excel文件(*.xls)|*.xls";
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                gridControl4.ExportToXls(fileDialog.FileName);
                DevExpress.XtraEditors.XtraMessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void 导出报表ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "导出Excel";
            fileDialog.Filter = "Excel文件(*.xls)|*.xls";
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                gridControl1.ExportToXls(fileDialog.FileName);
                DevExpress.XtraEditors.XtraMessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void 分解ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认分解吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string id = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id"));
                string sql = "insert into tb_caigouliaodan (设备名称,类型,项目工令号,要求到货日期,备注,时间,生产部确认,生产部确认时间,加工预计结束时间,仓库确认,仓库确认时间,申购人,收到料单日期,供方名称,合同号,报价,实际到货日期,检验,生产部检验,技术部检验,质检部检验,生成时间,附件,附件名称,附件类型,流程状态,到货验收流程按钮,到货验收流程标记,流程类型,采购料单备注,车,铣,钳,磨,镗,线切割,表面处理,热处理,采购类型,到货情况,要求到货日期1,采购负责人,工序外协,技术更改,工序要求,备料,工序外协状态,技术更改要求,机修件类型,客户名称,部门,工件名称,加工内容,计量单位,机修件数量,接单编号,预交时间,联系人,责任人,加工单位备注,接单日期,完成,合同预计时间,合同价,发票价,生成合同时间,收到发票日期,备料时间,发票日期,发票金额,发票号,生产负责人,生产负责人电话,工艺顺序1,工艺顺序2,工艺顺序3,备料人,工序外协时间,工序外协完成时间,询价时间,合同绩效点,询价标记,库位号,机修件ERP,技术更改入库时间,出库确认,出库时间,税额,税率,应开票数量,已开票数量,净额,含税额,净税额,净单价,个人部门,新编码,定位,合同名称,合同类型,模具部销售开票日期,模具部实际交货日期,模具部发货数量,合同,模具部成本单价,模具部成本总价,模具部销售开票金额,供应商开票日期,供应商开票金额,模具部发货确认,模具部发货时间,模具部成本是否工序,安全库存,领用登记数量,模具部自制外协修改,输入待领用数量,合同要求付款日期及方式,图纸上传次数,工作令号,模具部接单日期,当前状态,项目名称,单位,编码,型号,模具部生产车间,制造类型,模具部订单号申请号,模具部销售合同号,模具部交货日期,模具部申请人,模具部客户,模具部联系人,名称,模具部成本分摊,模具部销售单价,出库数量,库存数量,实际到货数量,料单类型,实际采购数量,模具部数量,数量,序号,模具部项目名称,申请付款日期1,申请付款日期2,申请付款日期3,申请付款日期4,申请付款日期5,模具部产品类型,模具部bom清单名称,模具部bom清单类型,bom清单,模具部驳回原因,物料理论到货时间,采购单价预留,采购单价,总价,总价预留,发票匹配,到货时间,驳回原因,确认到票,首次合格率,发起到货验收数量,物资分类,临时,机修与模具交货时间,理论净额,机修与模具完成,区分) select 设备名称,类型,项目工令号,要求到货日期,备注,时间,生产部确认,生产部确认时间,加工预计结束时间,仓库确认,仓库确认时间,申购人,收到料单日期,供方名称,合同号,报价,实际到货日期,检验,生产部检验,技术部检验,质检部检验,生成时间,附件,附件名称,附件类型,流程状态,到货验收流程按钮,到货验收流程标记,流程类型,采购料单备注,车,铣,钳,磨,镗,线切割,表面处理,热处理,采购类型,到货情况,要求到货日期1,采购负责人,工序外协,技术更改,工序要求,备料,工序外协状态,技术更改要求,机修件类型,客户名称,部门,工件名称,加工内容,计量单位,机修件数量,接单编号,预交时间,联系人,责任人,加工单位备注,接单日期,完成,合同预计时间,合同价,发票价,生成合同时间,收到发票日期,备料时间,发票日期,发票金额,发票号,生产负责人,生产负责人电话,工艺顺序1,工艺顺序2,工艺顺序3,备料人,工序外协时间,工序外协完成时间,询价时间,合同绩效点,询价标记,库位号,机修件ERP,技术更改入库时间,出库确认,出库时间,税额,税率,应开票数量,已开票数量,净额,含税额,净税额,净单价,个人部门,新编码,定位,合同名称,合同类型,模具部销售开票日期,模具部实际交货日期,模具部发货数量,合同,模具部成本单价,模具部成本总价,模具部销售开票金额,供应商开票日期,供应商开票金额,模具部发货确认,模具部发货时间,模具部成本是否工序,安全库存,领用登记数量,模具部自制外协修改,输入待领用数量,合同要求付款日期及方式,图纸上传次数,工作令号,模具部接单日期,当前状态,项目名称,单位,编码,型号,模具部生产车间,制造类型,模具部订单号申请号,模具部销售合同号,模具部交货日期,模具部申请人,模具部客户,模具部联系人,名称,模具部成本分摊,模具部销售单价,出库数量,库存数量,实际到货数量,料单类型,实际采购数量,模具部数量,数量,序号,模具部项目名称,申请付款日期1,申请付款日期2,申请付款日期3,申请付款日期4,申请付款日期5,模具部产品类型,模具部bom清单名称,模具部bom清单类型,bom清单,模具部驳回原因,物料理论到货时间,采购单价预留,采购单价,总价,总价预留,发票匹配,到货时间,驳回原因,确认到票,首次合格率,发起到货验收数量,物资分类,临时,机修与模具交货时间,理论净额,机修与模具完成,区分  from tb_caigouliaodan where id = '" + id + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);
                MessageBox.Show("分解成功！");
            }
            reload();
        }

        private void 分解ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认分解吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
                string sql = "insert into tb_caigouliaodan (设备名称,类型,项目工令号,要求到货日期,备注,时间,生产部确认,生产部确认时间,加工预计结束时间,仓库确认,仓库确认时间,申购人,收到料单日期,供方名称,合同号,报价,实际到货日期,检验,生产部检验,技术部检验,质检部检验,生成时间,附件,附件名称,附件类型,流程状态,到货验收流程按钮,到货验收流程标记,流程类型,采购料单备注,车,铣,钳,磨,镗,线切割,表面处理,热处理,采购类型,到货情况,要求到货日期1,采购负责人,工序外协,技术更改,工序要求,备料,工序外协状态,技术更改要求,机修件类型,客户名称,部门,工件名称,加工内容,计量单位,机修件数量,接单编号,预交时间,联系人,责任人,加工单位备注,接单日期,完成,合同预计时间,合同价,发票价,生成合同时间,收到发票日期,备料时间,发票日期,发票金额,发票号,生产负责人,生产负责人电话,工艺顺序1,工艺顺序2,工艺顺序3,备料人,工序外协时间,工序外协完成时间,询价时间,合同绩效点,询价标记,库位号,机修件ERP,技术更改入库时间,出库确认,出库时间,税额,税率,应开票数量,已开票数量,净额,含税额,净税额,净单价,个人部门,新编码,定位,合同名称,合同类型,模具部销售开票日期,模具部实际交货日期,模具部发货数量,合同,模具部成本单价,模具部成本总价,模具部销售开票金额,供应商开票日期,供应商开票金额,模具部发货确认,模具部发货时间,模具部成本是否工序,安全库存,领用登记数量,模具部自制外协修改,输入待领用数量,申请付款金额1,申请付款金额2,申请付款金额3,申请付款金额4,申请付款金额5,开户行以及账户,合同要求付款日期及方式,图纸上传次数,工作令号,模具部接单日期,当前状态,项目名称,单位,编码,型号,模具部生产车间,制造类型,模具部订单号申请号,模具部销售合同号,模具部交货日期,模具部申请人,模具部客户,模具部联系人,名称,模具部成本分摊,模具部销售单价,出库数量,库存数量,实际到货数量,料单类型,实际采购数量,模具部数量,数量,序号,模具部项目名称,申请付款日期1,申请付款日期2,申请付款日期3,申请付款日期4,申请付款日期5,模具部产品类型,模具部bom清单名称,模具部bom清单类型,bom清单,模具部驳回原因,物料理论到货时间,采购单价预留,采购单价,总价,总价预留,发票匹配,到货时间,驳回原因,确认到票,首次合格率,发起到货验收数量,物资分类,临时,机修与模具交货时间,理论净额,机修与模具完成,区分) select 设备名称,类型,项目工令号,要求到货日期,备注,时间,生产部确认,生产部确认时间,加工预计结束时间,仓库确认,仓库确认时间,申购人,收到料单日期,供方名称,合同号,报价,实际到货日期,检验,生产部检验,技术部检验,质检部检验,生成时间,附件,附件名称,附件类型,流程状态,到货验收流程按钮,到货验收流程标记,流程类型,采购料单备注,车,铣,钳,磨,镗,线切割,表面处理,热处理,采购类型,到货情况,要求到货日期1,采购负责人,工序外协,技术更改,工序要求,备料,工序外协状态,技术更改要求,机修件类型,客户名称,部门,工件名称,加工内容,计量单位,机修件数量,接单编号,预交时间,联系人,责任人,加工单位备注,接单日期,完成,合同预计时间,合同价,发票价,生成合同时间,收到发票日期,备料时间,发票日期,发票金额,发票号,生产负责人,生产负责人电话,工艺顺序1,工艺顺序2,工艺顺序3,备料人,工序外协时间,工序外协完成时间,询价时间,合同绩效点,询价标记,库位号,机修件ERP,技术更改入库时间,出库确认,出库时间,税额,税率,应开票数量,已开票数量,净额,含税额,净税额,净单价,个人部门,新编码,定位,合同名称,合同类型,模具部销售开票日期,模具部实际交货日期,模具部发货数量,合同,模具部成本单价,模具部成本总价,模具部销售开票金额,供应商开票日期,供应商开票金额,模具部发货确认,模具部发货时间,模具部成本是否工序,安全库存,领用登记数量,模具部自制外协修改,输入待领用数量,申请付款金额1,申请付款金额2,申请付款金额3,申请付款金额4,申请付款金额5,开户行以及账户,合同要求付款日期及方式,图纸上传次数,工作令号,模具部接单日期,当前状态,项目名称,单位,编码,型号,模具部生产车间,制造类型,模具部订单号申请号,模具部销售合同号,模具部交货日期,模具部申请人,模具部客户,模具部联系人,名称,模具部成本分摊,模具部销售单价,出库数量,库存数量,实际到货数量,料单类型,实际采购数量,模具部数量,数量,序号,模具部项目名称,申请付款日期1,申请付款日期2,申请付款日期3,申请付款日期4,申请付款日期5,模具部产品类型,模具部bom清单名称,模具部bom清单类型,bom清单,模具部驳回原因,物料理论到货时间,采购单价预留,采购单价,总价,总价预留,发票匹配,到货时间,驳回原因,确认到票,首次合格率,发起到货验收数量,物资分类,临时,机修与模具交货时间,理论净额,机修与模具完成,区分  from tb_caigouliaodan where id = '" + id + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);


                MessageBox.Show("分解成功！");
            }
            reload();
        }

        private void buttonItem15_Click(object sender, EventArgs e)
        {
            int bb = 0;
            int[] aa = gridView2.GetSelectedRows();

            foreach (int i in aa)
            {
                bb += 1;
                if (bb <= 200)
                {
                    string id = gridView2.GetRowCellValue(i, "statename").ToString().Trim();
                    string bianma = gridView2.GetRowCellValue(i, "编码").ToString().Trim();
                    if (bianma.Trim() == "")
                    {
                        MessageBox.Show("有的编码为空！，无法生成合同");
                        return;
                    }

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
            dt1.Columns.Add("单位");
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
            zongbiao1.Columns.Add("单位");
            zongbiao1.Columns.Add("采购单价");
            zongbiao1.Columns.Add("总价");
            zongbiao1.Columns.Add("备注");



            int b = 0;
            int[] a = gridView2.GetSelectedRows();

            foreach (int i in a)
            {
                b += 1;
                if (b <= 200)
                {
                    string id = gridView2.GetRowCellValue(i, "id").ToString();

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
                reload();

            }


        }

        private void buttonItem16_Click(object sender, EventArgs e)
        {
            int bb = 0;
            int[] aa = gridView2.GetSelectedRows();

            foreach (int i in aa)
            {
                bb += 1;
                if (bb <= 200)
                {
                    string id = gridView2.GetRowCellValue(i, "statename").ToString().Trim();
                    string bianma = gridView2.GetRowCellValue(i, "编码").ToString().Trim();
                    if (bianma.Trim() == "")
                    {
                        MessageBox.Show("有的编码为空！，无法生成合同");
                        return;
                    }

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
            dt1.Columns.Add("单位");
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
            zongbiao1.Columns.Add("单位");
            zongbiao1.Columns.Add("采购单价");
            zongbiao1.Columns.Add("总价");
            zongbiao1.Columns.Add("备注");


            int b = 0;
            int[] a = gridView2.GetSelectedRows();

            foreach (int i in a)
            {
                b += 1;
                if (b <= 200)
                {
                    string id = gridView2.GetRowCellValue(i, "id").ToString();


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
                reload();

            }
        }

        private void buttonItem17_Click(object sender, EventArgs e)
        {
            int bb = 0;
            int[] aa = gridView2.GetSelectedRows();

            foreach (int i in aa)
            {
                bb += 1;
                if (bb <= 200)
                {
                    string id = gridView2.GetRowCellValue(i, "statename").ToString().Trim();
                    string bianma = gridView2.GetRowCellValue(i, "编码").ToString().Trim();
                    if (bianma.Trim() == "")
                    {
                        MessageBox.Show("有的编码为空！，无法生成合同");
                        return;
                    }

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
            dt1.Columns.Add("单位");
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
            zongbiao1.Columns.Add("单位");
            zongbiao1.Columns.Add("采购单价");
            zongbiao1.Columns.Add("总价");
            zongbiao1.Columns.Add("备注");

            int b = 0;
            int[] a = gridView2.GetSelectedRows();

            foreach (int i in a)
            {
                b += 1;
                if (b <= 200)
                {
                    string id = gridView2.GetRowCellValue(i, "id").ToString();

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
                reload();

            }

        }

        private void buttonItem18_Click(object sender, EventArgs e)
        {
            int bb = 0;
            int[] aa = gridView2.GetSelectedRows();

            foreach (int i in aa)
            {
                bb += 1;
                if (bb <= 200)
                {
                    string id = gridView2.GetRowCellValue(i, "statename").ToString().Trim();
                    string bianma = gridView2.GetRowCellValue(i, "编码").ToString().Trim();
                    if (bianma.Trim() == "")
                    {
                        MessageBox.Show("有的编码为空！，无法生成合同");
                        return;
                    }
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
            dt1.Columns.Add("单位");
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
            zongbiao1.Columns.Add("单位");
            zongbiao1.Columns.Add("采购单价");
            zongbiao1.Columns.Add("总价");
            zongbiao1.Columns.Add("备注");


            int b = 0;
            int[] a = gridView2.GetSelectedRows();

            foreach (int i in a)
            {
                b += 1;
                if (b <= 200)
                {
                    string id = gridView2.GetRowCellValue(i, "id").ToString();

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
                reload();

            }

        }

        private void buttonItem19_Click(object sender, EventArgs e)
        {
            int[] a = gridView2.GetSelectedRows();
            foreach (int i in a)
            {
                string id = gridView2.GetRowCellValue(i, "id").ToString();
                qingdan += id + "|";
            }
            MessageBox.Show("已加入购物车！");
        }

        private void buttonItem20_Click(object sender, EventArgs e)
        {
            qingdan = "";
            MessageBox.Show("购物车已清空！");
        }

        private void buttonItem21_Click(object sender, EventArgs e)
        {
            if (qingdan == "")
            {
                MessageBox.Show("购物车没有东西,请添加！");
                return;
            }
            DataTable dt = new DataTable();
            DataTable zongbiao = new DataTable();
            dt.Columns.Add("工作令号");
            dt.Columns.Add("项目名称");
            dt.Columns.Add("设备名称");
            dt.Columns.Add("id");
            dt.Columns.Add("编码");
            dt.Columns.Add("型号");
            dt.Columns.Add("名称");
            dt.Columns.Add("单位");
            dt.Columns.Add("数量");
            dt.Columns.Add("类型");
            dt.Columns.Add("项目工令号");
            dt.Columns.Add("要求到货日期");
            dt.Columns.Add("备注");
            dt.Columns.Add("制造类型");
            dt.Columns.Add("申购人");
            dt.Columns.Add("收到料单日期");
            dt.Columns.Add("供方名称");
            dt.Columns.Add("合同号");
            dt.Columns.Add("实际采购数量");
            dt.Columns.Add("实际到货日期");
            dt.Columns.Add("当前状态");
            dt.Columns.Add("采购料单备注");
            dt.Columns.Add("附件类型");
            dt.Columns.Add("附件名称");
            dt.Columns.Add("合同预计时间");


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
            string[] strArray = qingdan.Split('|'); //字符串转数组
            List<string> list = new List<string>();
            for (int i = 0; i < strArray.Length; i++)//遍历数组成员
            {
                if (list.IndexOf(strArray[i].ToLower()) == -1)//对每个成员做一次新数组查询如果没有相等的则加到新数组
                    list.Add(strArray[i]);
            }
            for (int i = 0; i < list.Count; i++)
            {
                string dingwei = list[i];

                string sql1 = "select id,工作令号,项目名称,设备名称,编码,型号,名称,单位,数量,类型,要求到货日期,备注,制造类型,申购人,收到料单日期,供方名称,合同号,实际采购数量,采购单价,当前状态,采购料单备注,附件名称,附件类型 from  tb_caigouliaodan  where id ='" + dingwei + "' ";
                dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                zongbiao.Merge(dt, true, MissingSchemaAction.Ignore);
            }
            Frshaixuanliaodan form1 = new Frshaixuanliaodan();
            form1.dt = zongbiao;
            form1.yonghu = yonghu;
            form1.ShowDialog();
            if (form1.DialogResult == DialogResult.OK)
            {
                reload();
            }
        }

        private void buttonItem22_Click(object sender, EventArgs e)
        {
            int bb = 0;
            int[] aa = gridView3.GetSelectedRows();

            foreach (int i in aa)
            {
                bb += 1;
                if (bb <= 200)
                {
                    string id = gridView3.GetRowCellValue(i, "statename").ToString().Trim();
                    string bianma = gridView3.GetRowCellValue(i, "编码").ToString().Trim();
                    if (bianma.Trim() == "")
                    {
                        MessageBox.Show("有的编码为空！，无法生成合同");
                        return;
                    }

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
            dt1.Columns.Add("单位");
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
            zongbiao1.Columns.Add("单位");
            zongbiao1.Columns.Add("采购单价");
            zongbiao1.Columns.Add("总价");
            zongbiao1.Columns.Add("备注");



            int b = 0;
            int[] a = gridView3.GetSelectedRows();

            foreach (int i in a)
            {
                b += 1;
                if (b <= 200)
                {
                    string id = gridView3.GetRowCellValue(i, "id").ToString();

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
                reload();

            }

        }

        private void buttonItem23_Click(object sender, EventArgs e)
        {

            int bb = 0;
            int[] aa = gridView3.GetSelectedRows();

            foreach (int i in aa)
            {
                bb += 1;
                if (bb <= 200)
                {
                    string id = gridView3.GetRowCellValue(i, "statename").ToString().Trim();
                    string bianma = gridView3.GetRowCellValue(i, "编码").ToString().Trim();
                    if (bianma.Trim() == "")
                    {
                        MessageBox.Show("有的编码为空！，无法生成合同");
                        return;
                    }

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
            dt1.Columns.Add("单位");
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
            zongbiao1.Columns.Add("单位");
            zongbiao1.Columns.Add("采购单价");
            zongbiao1.Columns.Add("总价");
            zongbiao1.Columns.Add("备注");


            int b = 0;
            int[] a = gridView3.GetSelectedRows();

            foreach (int i in a)
            {
                b += 1;
                if (b <= 200)
                {
                    string id = gridView3.GetRowCellValue(i, "id").ToString();


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
                reload();

            }

        }

        private void buttonItem24_Click(object sender, EventArgs e)
        {
            int bb = 0;
            int[] aa = gridView3.GetSelectedRows();

            foreach (int i in aa)
            {
                bb += 1;
                if (bb <= 200)
                {
                    string id = gridView3.GetRowCellValue(i, "statename").ToString().Trim();
                    string bianma = gridView3.GetRowCellValue(i, "编码").ToString().Trim();
                    if (bianma.Trim() == "")
                    {
                        MessageBox.Show("有的编码为空！，无法生成合同");
                        return;
                    }

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
            dt1.Columns.Add("单位");
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
            zongbiao1.Columns.Add("单位");
            zongbiao1.Columns.Add("采购单价");
            zongbiao1.Columns.Add("总价");
            zongbiao1.Columns.Add("备注");


            int b = 0;
            int[] a = gridView3.GetSelectedRows();

            foreach (int i in a)
            {
                b += 1;
                if (b <= 200)
                {
                    string id = gridView3.GetRowCellValue(i, "id").ToString();


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
                reload();

            }
        }

        private void buttonItem25_Click(object sender, EventArgs e)
        {
            int bb = 0;
            int[] aa = gridView3.GetSelectedRows();

            foreach (int i in aa)
            {
                bb += 1;
                if (bb <= 200)
                {
                    string id = gridView3.GetRowCellValue(i, "statename").ToString().Trim();
                    string bianma = gridView3.GetRowCellValue(i, "编码").ToString().Trim();
                    if (bianma.Trim() == "")
                    {
                        MessageBox.Show("有的编码为空！，无法生成合同");
                        return;
                    }
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
            dt1.Columns.Add("单位");
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
            zongbiao1.Columns.Add("单位");
            zongbiao1.Columns.Add("采购单价");
            zongbiao1.Columns.Add("总价");
            zongbiao1.Columns.Add("备注");


            int b = 0;
            int[] a = gridView3.GetSelectedRows();

            foreach (int i in a)
            {
                b += 1;
                if (b <= 200)
                {
                    string id = gridView3.GetRowCellValue(i, "id").ToString();

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
                reload();

            }

        }

        private void buttonItem26_Click(object sender, EventArgs e)
        {
            int[] a = gridView3.GetSelectedRows();
            foreach (int i in a)
            {
                string id = gridView3.GetRowCellValue(i, "id").ToString();
                qingdan += id + "|";
            }
            MessageBox.Show("已加入购物车！");
        }

        private void buttonItem27_Click(object sender, EventArgs e)
        {
            qingdan = "";
            MessageBox.Show("购物车已清空！");
        }

        private void buttonItem28_Click(object sender, EventArgs e)
        {
            if (qingdan == "")
            {
                MessageBox.Show("购物车没有东西,请添加！");
                return;
            }
            DataTable dt = new DataTable();
            DataTable zongbiao = new DataTable();
            dt.Columns.Add("工作令号");
            dt.Columns.Add("项目名称");
            dt.Columns.Add("设备名称");
            dt.Columns.Add("id");
            dt.Columns.Add("编码");
            dt.Columns.Add("型号");
            dt.Columns.Add("名称");
            dt.Columns.Add("单位");
            dt.Columns.Add("数量");
            dt.Columns.Add("类型");
            dt.Columns.Add("项目工令号");
            dt.Columns.Add("要求到货日期");
            dt.Columns.Add("备注");
            dt.Columns.Add("制造类型");
            dt.Columns.Add("申购人");
            dt.Columns.Add("收到料单日期");
            dt.Columns.Add("供方名称");
            dt.Columns.Add("合同号");
            dt.Columns.Add("实际采购数量");
            dt.Columns.Add("实际到货日期");
            dt.Columns.Add("当前状态");
            dt.Columns.Add("采购料单备注");
            dt.Columns.Add("附件类型");
            dt.Columns.Add("附件名称");
            dt.Columns.Add("合同预计时间");


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
            string[] strArray = qingdan.Split('|'); //字符串转数组
            List<string> list = new List<string>();
            for (int i = 0; i < strArray.Length; i++)//遍历数组成员
            {
                if (list.IndexOf(strArray[i].ToLower()) == -1)//对每个成员做一次新数组查询如果没有相等的则加到新数组
                    list.Add(strArray[i]);
            }
            for (int i = 0; i < list.Count; i++)
            {
                string dingwei = list[i];

                string sql1 = "select id,工作令号,项目名称,设备名称,编码,型号,名称,单位,数量,类型,要求到货日期,备注,制造类型,申购人,收到料单日期,供方名称,合同号,实际采购数量,采购单价,当前状态,采购料单备注,附件名称,附件类型 from  tb_caigouliaodan  where id ='" + dingwei + "' ";
                dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                zongbiao.Merge(dt, true, MissingSchemaAction.Ignore);
            }
            Frshaixuanliaodan form1 = new Frshaixuanliaodan();
            form1.dt = zongbiao;
            form1.yonghu = yonghu;
            form1.ShowDialog();
            if (form1.DialogResult == DialogResult.OK)
            {
                reload();
            }
        }

        private void 查看附件ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string id = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id"));


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

        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void 保存备注ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] a = gridView4.GetSelectedRows();

            foreach (int i in a)
            {
                string id = Convert.ToString(gridView4.GetRowCellValue(i, "id"));
                string beizhu = Convert.ToString(gridView4.GetRowCellValue(i, "采购料单备注"));

                string sql = "update tb_caigouliaodan set 采购料单备注='" + beizhu + "' where id='" + id + "'";

                SQLhelp.ExecuteScalar(sql, CommandType.Text);


            }
        }

        private void 保存备注ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int[] a = gridView1.GetSelectedRows();

            foreach (int i in a)
            {
                string id = Convert.ToString(gridView1.GetRowCellValue(i, "id"));
                string beizhu = Convert.ToString(gridView1.GetRowCellValue(i, "采购料单备注"));

                string sql = "update tb_caigouliaodan set 采购料单备注='" + beizhu + "' where id='" + id + "'";

                SQLhelp.ExecuteScalar(sql, CommandType.Text);


            }
        }

        private void 保存备注ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int[] a = gridView2.GetSelectedRows();

            foreach (int i in a)
            {
                string id = Convert.ToString(gridView2.GetRowCellValue(i, "id"));
                string beizhu = Convert.ToString(gridView2.GetRowCellValue(i, "采购料单备注"));

                string sql = "update tb_caigouliaodan set 采购料单备注='" + beizhu + "' where id='" + id + "'";

                SQLhelp.ExecuteScalar(sql, CommandType.Text);


            }
        }

        private void 保存备注ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            int[] a = gridView3.GetSelectedRows();

            foreach (int i in a)
            {
                string id = Convert.ToString(gridView3.GetRowCellValue(i, "id"));
                string beizhu = Convert.ToString(gridView3.GetRowCellValue(i, "采购料单备注"));

                string sql = "update tb_caigouliaodan set 采购料单备注='" + beizhu + "' where id='" + id + "'";

                SQLhelp.ExecuteScalar(sql, CommandType.Text);


            }
        }
    }
}