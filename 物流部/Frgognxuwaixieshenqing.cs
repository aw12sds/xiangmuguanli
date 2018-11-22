using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.物流部
{
    public partial class Frgognxuwaixieshenqing : Form
    {
        public Frgognxuwaixieshenqing()
        {
            InitializeComponent();
        }
        public string yonghu;
        private void Frgognxuwaixieshenqing_Load(object sender, EventArgs e)
        {
            reload();
        }
        public void reload()
        {

            string sql1 = "select id, 工作令号, 项目名称, 设备名称, 名称, 型号, 实际采购数量, 工序要求, 父id,供方名称,采购料单备注,合同号,实际到货日期,工序外协时间 from tb_gonxuwaixieguanli  where 工序外协 = 0";

            gridControl1.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);

            string sql11 = "select id, 工作令号, 项目名称, 设备名称, 名称, 型号, 实际采购数量, 工序要求, 父id,供方名称,采购料单备注,合同号,实际到货日期,工序外协时间 from tb_gonxuwaixieguanli  where 工序外协=1";

            gridControl2.DataSource = SQLhelp.GetDataTable(sql11, CommandType.Text);
            gridView1.Columns["id"].Visible = false;
            gridView2.Columns["id"].Visible = false;
            gridView1.Columns["父id"].Visible = false;
            gridView2.Columns["父id"].Visible = false;
            //gridView1.Columns["附件类型"].Visible = false;
            //gridView2.Columns["附件类型"].Visible = false;


        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] rownumber = this.gridView1.GetSelectedRows();

            for (int i = 0; i < rownumber.Length; i++)
            {

                string id = gridView1.GetRowCellDisplayText(rownumber[i], "id");

                string gongfang = gridView1.GetRowCellDisplayText(rownumber[i], "供方名称");
                string hetonghao = gridView1.GetRowCellDisplayText(rownumber[i], "合同号");
                string caigouliaodanbeizhu = gridView1.GetRowCellDisplayText(rownumber[i], "采购料单备注");
                string shijidaohuoriqi = gridView1.GetRowCellDisplayText(rownumber[i], "实际到货日期");
                if (shijidaohuoriqi == "")
                {
                    string sql2 = "update tb_gonxuwaixieguanli  set 供方名称= '" + gongfang + "',合同号= '" + hetonghao + "',采购料单备注= '" + caigouliaodanbeizhu + "'  where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql2, CommandType.Text);
                }
                if (shijidaohuoriqi != "")
                {
                    string sql2 = "update tb_gonxuwaixieguanli  set 供方名称= '" + gongfang + "',合同号= '" + hetonghao + "',采购料单备注= '" + caigouliaodanbeizhu + "' ,实际到货日期= '" + shijidaohuoriqi + "' where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql2, CommandType.Text);
                }
            }
            MessageBox.Show("保存成功！");
            reload();

        }



        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
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
                string lujing = aaaa + "\\" + mingcheng + "1" + "." + leixing;
                FileStream fs = new FileStream(lujing, FileMode.Create);
                fs.Write(mypdffile, 0, mypdffile.Length);
                fs.Flush();
                fs.Close();
                this.Cursor = Cursors.Default;
                System.Diagnostics.Process.Start(lujing);


            }
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

        }

        private void 查看图纸ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string 父id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "父id"));
            string sql = "select 附件名称 from tb_caigouliaodan where id='" + 父id + "'";
            string mingcheng = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (mingcheng == "")
            {
                MessageBox.Show("没有附件！");
                return;
            }

            string sql2 = "select 附件类型 from tb_caigouliaodan where id='" + 父id + "'";
            string leixing = SQLhelp.ExecuteScalar(sql2, CommandType.Text).ToString();

            byte[] mypdffile = null;

            string sql4 = "Select 附件 From tb_caigouliaodan Where id='" + 父id + "' ";

            mypdffile = SQLhelp.duqu(sql4, CommandType.Text);
            this.Cursor = Cursors.WaitCursor;

            string aaaa = System.Environment.CurrentDirectory;
            string lujing = aaaa + "\\" + mingcheng + "1" + "." + leixing;
            FileStream fs = new FileStream(lujing, FileMode.Create);
            fs.Write(mypdffile, 0, mypdffile.Length);
            fs.Flush();
            fs.Close();
            this.Cursor = Cursors.Default;
            System.Diagnostics.Process.Start(lujing);
        }

        private void 查看图纸ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string id = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "父id"));

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
            string lujing = aaaa + "\\" + mingcheng + "1" + "." + leixing;
            FileStream fs = new FileStream(lujing, FileMode.Create);
            fs.Write(mypdffile, 0, mypdffile.Length);
            fs.Flush();
            fs.Close();
            this.Cursor = Cursors.Default;
            System.Diagnostics.Process.Start(lujing);
        }

        private void 生成成缆合同ToolStripMenuItem_Click(object sender, EventArgs e)
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
                    string id = gridView1.GetRowCellValue(i, "父id").ToString();

                    string sql1 = "select id,编码,名称,型号,实际采购数量,工作令号,备注,设备名称,项目名称,类型,单位 from  tb_caigouliaodan  where id ='" + id + "' ";
                    dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);

                    zongbiao1.Merge(dt1, true, MissingSchemaAction.Ignore);
                }

            }

            Frhetongmoban form1 = new Frhetongmoban();
            form1.dt = zongbiao1;
            form1.yonghu = yonghu;
            form1.zhonglei = "工序";
            form1.ShowDialog();

        }
    }

}
