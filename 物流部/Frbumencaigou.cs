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
    public partial class Frbumencaigou : Form
    {
        public Frbumencaigou()
        {
            InitializeComponent();
        }
        public string yonghu;

        private void Frbumencaigou_Load(object sender, EventArgs e)
        {
            Reload();
        }
        public void Reload()
        {
            string sql = "select * from tb_operator where 用户名='" + yonghu + "'";
            DataTable dtt = sqlhelp111.GetDataTable(sql, CommandType.Text);
            string bumen = Convert.ToString(dtt.Rows[0]["部门采购"]);

            if (bumen == "1")
            {
                string sql1 = "select  id,工作令号,编码,型号,名称,数量,要求到货日期,申购人,备注,当前状态,收到料单日期,合同号,供方名称,单位,采购单价,附件名称,采购料单备注   from  tb_caigouliaodan where 料单类型!='原材料' and 到货情况=0  and  料单类型!='项目'  and  料单类型!='五金辅材' and  料单类型!='模具部' and  料单类型!='模具部原材料' and  料单类型!='机修件' and 流程状态='同意'";

                gridControl4.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);

                string sql11 = "select  id,工作令号,编码,型号,名称,数量,要求到货日期,申购人,备注,当前状态,收到料单日期,合同号,供方名称,单位,采购单价,附件名称  from  tb_caigouliaodan where 料单类型!='原材料' and 到货情况=1   and  料单类型!='项目'  and  料单类型!='五金辅材' and  料单类型!='模具部' and  料单类型!='模具部原材料' and  料单类型!='机修件' and 流程状态='同意' ";

                gridControl1.DataSource = SQLhelp.GetDataTable(sql11, CommandType.Text);
            }

        }

        private void buttonItem1_Click(object sender, EventArgs e)
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
            dt1.Columns.Add("实际采购数量");
            dt1.Columns.Add("采购单价");
            dt1.Columns.Add("总价");
            dt1.Columns.Add("单位");

            zongbiao1.Columns.Add("id");
            zongbiao1.Columns.Add("工作令号");
            zongbiao1.Columns.Add("项目名称");
            zongbiao1.Columns.Add("设备名称");
            zongbiao1.Columns.Add("编码");
            zongbiao1.Columns.Add("名称");
            zongbiao1.Columns.Add("型号");
            zongbiao1.Columns.Add("实际采购数量");
            zongbiao1.Columns.Add("采购单价");
            zongbiao1.Columns.Add("总价");
            zongbiao1.Columns.Add("单位");

        
            foreach (int i in a)
            {
                string id = gridView4.GetRowCellValue(i, "id").ToString();


                string sql1 = "select id,编码,名称,型号,实际采购数量,工作令号,备注,设备名称,项目名称,单位 from  tb_caigouliaodan  where id ='" + id + "' ";
                dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);

                zongbiao1.Merge(dt1, true, MissingSchemaAction.Ignore);
            }

            Frhetongmoban form1 = new Frhetongmoban();
            form1.dt = zongbiao1;
            form1.yonghu = yonghu;
            form1.zhonglei = "普通";
            form1.ShowDialog();
            if (form1.DialogResult == DialogResult.OK)
            {
                Reload();

            }
        }

        private void buttonItem2_Click(object sender, EventArgs e)
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
            dt1.Columns.Add("实际采购数量");
            dt1.Columns.Add("采购单价");
            dt1.Columns.Add("总价");
            dt1.Columns.Add("单位");

            zongbiao1.Columns.Add("id");
            zongbiao1.Columns.Add("工作令号");
            zongbiao1.Columns.Add("项目名称");
            zongbiao1.Columns.Add("设备名称");
            zongbiao1.Columns.Add("编码");
            zongbiao1.Columns.Add("名称");
            zongbiao1.Columns.Add("型号");
            zongbiao1.Columns.Add("实际采购数量");
            zongbiao1.Columns.Add("采购单价");
            zongbiao1.Columns.Add("总价");
            zongbiao1.Columns.Add("单位");

         

            foreach (int i in a)
            {


                string id = gridView4.GetRowCellValue(i, "id").ToString();


                string sql1 = "select id,编码,名称,单位,型号,实际采购数量,工作令号,备注,设备名称,项目名称 from  tb_caigouliaodan  where id ='" + id + "' ";
                dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);

                zongbiao1.Merge(dt1, true, MissingSchemaAction.Ignore);



            }
            Frdingdan form1 = new Frdingdan();
            form1.dt = zongbiao1;
            form1.yonghu = yonghu;
            form1.zhonglei = "订单";
            form1.ShowDialog();
            if (form1.DialogResult == DialogResult.OK)
            {
                Reload();


            }
        }

        private void buttonItem3_Click(object sender, EventArgs e)
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
            dt1.Columns.Add("实际采购数量");
            dt1.Columns.Add("采购单价");
            dt1.Columns.Add("总价");
            dt1.Columns.Add("单位");

            zongbiao1.Columns.Add("id");
            zongbiao1.Columns.Add("工作令号");
            zongbiao1.Columns.Add("项目名称");
            zongbiao1.Columns.Add("设备名称");
            zongbiao1.Columns.Add("编码");
            zongbiao1.Columns.Add("名称");
            zongbiao1.Columns.Add("型号");
            zongbiao1.Columns.Add("实际采购数量");
            zongbiao1.Columns.Add("采购单价");
            zongbiao1.Columns.Add("总价");
            zongbiao1.Columns.Add("单位");
            
            foreach (int i in a)
            {


                string id = gridView4.GetRowCellValue(i, "id").ToString();


                string sql1 = "select id,编码,名称,单位,型号,实际采购数量,工作令号,备注,设备名称,项目名称 from  tb_caigouliaodan  where id ='" + id + "' ";
                dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);

                zongbiao1.Merge(dt1, true, MissingSchemaAction.Ignore);



            }
            Frhetongmoban form1 = new Frhetongmoban();
            form1.dt = zongbiao1;
            form1.yonghu = yonghu;
            form1.zhonglei = "采购";
            form1.ShowDialog();
            if (form1.DialogResult == DialogResult.OK)
            {
                Reload();

            }
        }

        private void buttonItem4_Click(object sender, EventArgs e)
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
            dt1.Columns.Add("实际采购数量");
            dt1.Columns.Add("采购单价");
            dt1.Columns.Add("总价");
            dt1.Columns.Add("单位");

            zongbiao1.Columns.Add("id");
            zongbiao1.Columns.Add("工作令号");
            zongbiao1.Columns.Add("项目名称");
            zongbiao1.Columns.Add("设备名称");
            zongbiao1.Columns.Add("编码");
            zongbiao1.Columns.Add("名称");
            zongbiao1.Columns.Add("型号");
            zongbiao1.Columns.Add("实际采购数量");
            zongbiao1.Columns.Add("采购单价");
            zongbiao1.Columns.Add("总价");
            zongbiao1.Columns.Add("单位");
           

            foreach (int i in a)
            {


                string id = gridView4.GetRowCellValue(i, "id").ToString();


                string sql1 = "select id,编码,名称,单位,型号,实际采购数量,工作令号,备注,设备名称,项目名称 from  tb_caigouliaodan  where id ='" + id + "' ";
                dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);

                zongbiao1.Merge(dt1, true, MissingSchemaAction.Ignore);



            }
            Frdingdan form1 = new Frdingdan();
            form1.dt = zongbiao1;
            form1.yonghu = yonghu;
            form1.zhonglei = "设备";
            form1.ShowDialog();
            if (form1.DialogResult == DialogResult.OK)
            {
                Reload();


            }
        }

        private void buttonItem5_Click(object sender, EventArgs e)
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
            dt1.Columns.Add("实际采购数量");
            dt1.Columns.Add("类型");
            dt1.Columns.Add("采购单价");
            dt1.Columns.Add("总价");
            dt1.Columns.Add("单位");

            zongbiao1.Columns.Add("id");
            zongbiao1.Columns.Add("工作令号");
            zongbiao1.Columns.Add("项目名称");
            zongbiao1.Columns.Add("设备名称");
            zongbiao1.Columns.Add("编码");
            zongbiao1.Columns.Add("名称");
            zongbiao1.Columns.Add("型号");
            zongbiao1.Columns.Add("实际采购数量");
            zongbiao1.Columns.Add("类型");
            zongbiao1.Columns.Add("采购单价");
            zongbiao1.Columns.Add("总价");
            zongbiao1.Columns.Add("单位");

            int[] a = gridView4.GetSelectedRows();

            foreach (int i in a)
            {


                string id = gridView4.GetRowCellValue(i, "id").ToString();

                string sql1 = "select id,编码,名称,单位,型号,实际采购数量,类型,工作令号,备注,设备名称,项目名称 from  tb_caigouliaodan  where id ='" + id + "' ";
                dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);

                zongbiao1.Merge(dt1, true, MissingSchemaAction.Ignore);



            }
            Frhetongmoban form1 = new Frhetongmoban();
            form1.dt = zongbiao1;
            form1.yonghu = yonghu;
            form1.zhonglei = "材质";
            form1.ShowDialog();
            if (form1.DialogResult == DialogResult.OK)
            {
                Reload();

            }
        }

        private void buttonItem6_Click(object sender, EventArgs e)
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
            dt1.Columns.Add("实际采购数量");
            dt1.Columns.Add("采购单价");
            dt1.Columns.Add("总价");
            dt1.Columns.Add("单位");
            zongbiao1.Columns.Add("id");
            zongbiao1.Columns.Add("工作令号");
            zongbiao1.Columns.Add("项目名称");
            zongbiao1.Columns.Add("设备名称");
            zongbiao1.Columns.Add("编码");
            zongbiao1.Columns.Add("名称");
            zongbiao1.Columns.Add("型号");
            zongbiao1.Columns.Add("实际采购数量");
            zongbiao1.Columns.Add("采购单价");
            zongbiao1.Columns.Add("总价");
            zongbiao1.Columns.Add("单位");
          
            foreach (int i in a)
            {
                string id = gridView4.GetRowCellValue(i, "id").ToString();
                string sql1 = "select id,编码,名称,单位,型号,实际采购数量,工作令号,备注,设备名称,项目名称 from  tb_caigouliaodan  where id ='" + id + "' ";
                dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);
                zongbiao1.Merge(dt1, true, MissingSchemaAction.Ignore);
            }
            Frxunjia form1 = new Frxunjia();
            form1.dt = zongbiao1;
            form1.yonghu = yonghu;
            form1.zhonglei = "设备";
            form1.ShowDialog();
            if (form1.DialogResult == DialogResult.OK)
            {
                Reload();

            }
        }



        private void 确认完成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认完成吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string id = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id"));

                string sql11 = "update  tb_caigouliaodan set 到货情况=1   where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql11, CommandType.Text);
                MessageBox.Show("确认成功！");
                Reload();
            }
        }

        private void 查看附件ToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void bar1_ItemClick(object sender, EventArgs e)
        {

        }

        private void gridControl4_Click(object sender, EventArgs e)
        {

        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] a = gridView4.GetSelectedRows();

            foreach (int i in a)
            {
                string  id= gridView4.GetRowCellValue(i, "id").ToString();
                string beizhu= gridView4.GetRowCellValue(i, "采购料单备注").ToString();
                string sql = "update tb_caigouliaodan set 采购料单备注='" + beizhu + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);

                
            }
        }

        private void 取消采购ToolStripMenuItem_Click(object sender, EventArgs e)
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
            foreach (int i in a)
            {
                string id = this.gridView4.GetRowCellValue(i, "id").ToString();
                string sql = "update tb_caigouliaodan set 合同号='取消' ,当前状态='取消' where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);

            }
            MessageBox.Show("取消成功！");
            Reload();
        }
    }
}
