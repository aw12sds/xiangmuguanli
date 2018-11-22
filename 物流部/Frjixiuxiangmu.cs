using DevComponents.DotNetBar;
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
    public partial class Frjixiuxiangmu : Office2007Form
    {
        public Frjixiuxiangmu()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }
        public string yonghu;
        private void Frjixiuxiangmu_Load(object sender, EventArgs e)
        {
            Reload();
        }
        public void Reload()
        {
            string sql123 = "select id,接单编号,客户名称,部门,工件名称,加工内容,计量单位,机修件数量,接单日期,预交时间,联系人,责任人,加工单位备注,当前状态,供方名称,合同号,采购单价,机修件ERP,采购料单备注,附件名称,附件类型  from  tb_caigouliaodan where (完成='未完成'or 完成 is null)  and 机修件数量 is not null and 加工单位备注='外协' ";
            SQLhelp.GetDataTable(sql123, CommandType.Text);
            gridControl1.DataSource = SQLhelp.GetDataTable(sql123, CommandType.Text);

            string sql12 = "select id,接单编号,客户名称,部门,工件名称,加工内容,计量单位,机修件数量,接单日期,预交时间,联系人,责任人,加工单位备注,供方名称,合同号,采购单价,机修件ERP,采购料单备注,附件名称,附件类型  from  tb_caigouliaodan where 完成='完成' and 加工单位备注='外协' ";
            DataTable dt1 = SQLhelp.GetDataTable(sql12, CommandType.Text);
            gridControl2.DataSource = dt1;

        }
        
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {          

            int[] a = gridView1.GetSelectedRows();
            foreach (int i in a)
            {
                string id = Convert.ToString(gridView1.GetRowCellValue(i, "id"));
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
                string id = Convert.ToString(gridView1.GetRowCellValue(i, "id"));            
                string shuliang = Convert.ToString(gridView1.GetRowCellValue(i, "机修件数量"));                        
                string danjia = Convert.ToString(gridView1.GetRowCellValue(i, "采购单价"));
                string beizhu = Convert.ToString(gridView1.GetRowCellValue(i, "采购料单备注"));
                string sql2 = "update tb_caigouliaodan  set 实际采购数量='" + shuliang+ "',采购单价='"+danjia+ "',采购料单备注='" + beizhu + "' where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql2, CommandType.Text);              
            }         
            MessageBox.Show("保存成功！");
            Reload();
        }
        
     
        private void buttonItem1_Click(object sender, EventArgs e)
        {
            int[] a = gridView1.GetSelectedRows();
            foreach (int i in a)
            {

                string id = Convert.ToString(gridView1.GetRowCellValue(i, "id"));
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
            dt1.Columns.Add("接单编号");
            dt1.Columns.Add("机修件ERP");            
            dt1.Columns.Add("工件名称");
            dt1.Columns.Add("计量单位");
            dt1.Columns.Add("机修件数量");
            dt1.Columns.Add("采购单价");
            dt1.Columns.Add("总价");

            zongbiao1.Columns.Add("id");
            zongbiao1.Columns.Add("接单编号");
            zongbiao1.Columns.Add("机修件ERP");
            zongbiao1.Columns.Add("工件名称");
            zongbiao1.Columns.Add("计量单位");
            zongbiao1.Columns.Add("机修件数量");
            zongbiao1.Columns.Add("采购单价");
            zongbiao1.Columns.Add("总价");

        
            foreach (int i in a)
            {

                string id = Convert.ToString(gridView1.GetRowCellValue(i, "id"));
            
                string sql1 = "select id,接单编号,机修件ERP,工件名称,计量单位,机修件数量 from  tb_caigouliaodan  where id ='" + id + "' ";
                dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);

                zongbiao1.Merge(dt1, true, MissingSchemaAction.Ignore);
            }
            
            Frjixiuhetongmoban form1 = new Frjixiuhetongmoban();
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
            int[] a = gridView1.GetSelectedRows();
            foreach (int i in a)
            {

                string id = Convert.ToString(gridView1.GetRowCellValue(i, "id"));
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
            dt1.Columns.Add("接单编号");
            dt1.Columns.Add("机修件ERP");
            dt1.Columns.Add("工件名称");
            dt1.Columns.Add("计量单位");
            dt1.Columns.Add("机修件数量");
            dt1.Columns.Add("采购单价");
            dt1.Columns.Add("总价");

            zongbiao1.Columns.Add("id");
            zongbiao1.Columns.Add("接单编号");
            zongbiao1.Columns.Add("机修件ERP");
            zongbiao1.Columns.Add("工件名称");
            zongbiao1.Columns.Add("计量单位");
            zongbiao1.Columns.Add("机修件数量");
            zongbiao1.Columns.Add("采购单价");
            zongbiao1.Columns.Add("总价");

          
            foreach (int i in a)
            {

                string id = Convert.ToString(gridView1.GetRowCellValue(i, "id"));

                string sql1 = "select id,接单编号,机修件ERP,工件名称,计量单位,机修件数量 from  tb_caigouliaodan  where id ='" + id + "' ";
                dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);

                zongbiao1.Merge(dt1, true, MissingSchemaAction.Ignore);
            }
            
            Frjixiuhetongmoban form1 = new Frjixiuhetongmoban();
            form1.dt = zongbiao1;
            form1.yonghu = yonghu;
            form1.zhonglei = "订货";
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

        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }
        public string qingdan;
        private void buttonItem3_Click(object sender, EventArgs e)
        {
            int[] a = gridView1.GetSelectedRows();
            foreach (int i in a)
            {
                string id = gridView1.GetRowCellValue(i, "id").ToString();
                qingdan += id + "|";
            }
            MessageBox.Show("已加入购物车！");
         
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            int[] a = gridView2.GetSelectedRows();
            foreach (int i in a)
            {
                string id = gridView2.GetRowCellValue(i, "id").ToString();
                qingdan += id + "|";
            }
            MessageBox.Show("已加入购物车！");

        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            if (qingdan == "")
            {
                MessageBox.Show("购物车没有东西,请添加！");
                return;
            }
            DataTable dt1 = new DataTable();
            DataTable zongbiao1 = new DataTable();

            dt1.Columns.Add("id");
            dt1.Columns.Add("接单编号");
            dt1.Columns.Add("机修件ERP");
            dt1.Columns.Add("工件名称");
            dt1.Columns.Add("计量单位");
            dt1.Columns.Add("机修件数量");
            dt1.Columns.Add("采购单价");
            dt1.Columns.Add("总价");

            zongbiao1.Columns.Add("id");
            zongbiao1.Columns.Add("接单编号");
            zongbiao1.Columns.Add("机修件ERP");
            zongbiao1.Columns.Add("工件名称");
            zongbiao1.Columns.Add("计量单位");
            zongbiao1.Columns.Add("机修件数量");
            zongbiao1.Columns.Add("采购单价");
            zongbiao1.Columns.Add("总价");

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
                string sql1 = "select id,接单编号,机修件ERP,工件名称,计量单位,机修件数量 from  tb_caigouliaodan  where id ='" + dingwei + "' ";
                dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);

                zongbiao1.Merge(dt1, true, MissingSchemaAction.Ignore);
            }
            Frjixiuhetongmoban form1 = new Frjixiuhetongmoban();
            form1.dt = zongbiao1;
            form1.yonghu = yonghu;
            form1.zhonglei = "普通";
            form1.ShowDialog();
            if (form1.DialogResult == DialogResult.OK)
            {
                Reload();
            }

        }

        private void buttonItem7_Click(object sender, EventArgs e)
        {
            if (qingdan == "")
            {
                MessageBox.Show("购物车没有东西,请添加！");
                return;
            }
            DataTable dt1 = new DataTable();
            DataTable zongbiao1 = new DataTable();

            dt1.Columns.Add("id");
            dt1.Columns.Add("接单编号");
            dt1.Columns.Add("机修件ERP");
            dt1.Columns.Add("工件名称");
            dt1.Columns.Add("计量单位");
            dt1.Columns.Add("机修件数量");
            dt1.Columns.Add("采购单价");
            dt1.Columns.Add("总价");

            zongbiao1.Columns.Add("id");
            zongbiao1.Columns.Add("接单编号");
            zongbiao1.Columns.Add("机修件ERP");
            zongbiao1.Columns.Add("工件名称");
            zongbiao1.Columns.Add("计量单位");
            zongbiao1.Columns.Add("机修件数量");
            zongbiao1.Columns.Add("采购单价");
            zongbiao1.Columns.Add("总价");

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
                string sql1 = "select id,接单编号,机修件ERP,工件名称,计量单位,机修件数量 from  tb_caigouliaodan  where id ='" + dingwei + "' ";
                dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);

                zongbiao1.Merge(dt1, true, MissingSchemaAction.Ignore);
            }
            Frjixiuhetongmoban form1 = new Frjixiuhetongmoban();
            form1.dt = zongbiao1;
            form1.yonghu = yonghu;
            form1.zhonglei = "订货";
            form1.ShowDialog();
            if (form1.DialogResult == DialogResult.OK)
            {
                Reload();
            }
        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            qingdan = "";
            MessageBox.Show("已清空！");
        }

        private void 分解ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("确认分解吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
                string sql = "insert into tb_caigouliaodan (工作令号,项目名称,设备名称,编码,型号,名称,数量,要求到货日期1,申购人,备注,采购类型,收到料单日期,采购负责人,到货情况,单位,实际采购数量,客户名称,部门,工件名称,加工内容,计量单位,机修件数量,接单编号,预交时间,联系人,责任人,加工单位备注,接单日期,完成,机修件ERP,料单类型,采购单价,采购单价预留,总价,总价预留) select 工作令号,项目名称,设备名称,编码,型号,名称,数量,要求到货日期1,申购人,备注,采购类型,收到料单日期,采购负责人,到货情况,单位,实际采购数量,客户名称,部门,工件名称,加工内容,计量单位,机修件数量,接单编号,预交时间,联系人,责任人,加工单位备注,接单日期,完成,机修件ERP,料单类型,采购单价,采购单价预留,总价,总价预留  from tb_caigouliaodan where id = '" + id + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);
                MessageBox.Show("分解成功！");
            }
            Reload();
        }

        private void 自制转外协ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认外协改自制吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {

                string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
                string sql = "update tb_caigouliaodan set 加工单位备注='外协转自制',流程状态='转精工事业部审批' where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);
                MessageBox.Show("确认成功！");
                Reload();
            }
        }

        private void 取消采购ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] a = gridView1.GetSelectedRows();
            foreach (int i in a)
            {

                string id = Convert.ToString(gridView1.GetRowCellValue(i, "id"));
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
                string dangqianzhuangtai = this.gridView1.GetRowCellValue(i, "当前状态").ToString();

                if (dangqianzhuangtai == "9已到货" || dangqianzhuangtai == "10已出库" || dangqianzhuangtai == "10已出库")
                {
                    MessageBox.Show("只能取消没到货,没出库的！");
                    return;
                }
            }
            foreach (int i in a)
            {
                string id = this.gridView1.GetRowCellValue(i, "id").ToString();
                string sql = "update tb_caigouliaodan set 合同号='取消' ,当前状态='取消' where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);

            }
            MessageBox.Show("取消成功！");
            Reload();
        }

        private void 查看图纸ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "附件名称")) == "")
            {
                MessageBox.Show("没有附件！");
                return;
            }
            if (Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "附件名称")) != "")
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
        }
    }
}
