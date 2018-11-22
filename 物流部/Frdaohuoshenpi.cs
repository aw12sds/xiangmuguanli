using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using NetWork.util;
using NetWorkLib;

namespace 项目管理系统.物流部
{
    public partial class Frdaohuoshenpi : DevExpress.XtraEditors.XtraForm
    {
        public Frdaohuoshenpi()
        {
            InitializeComponent();
        }
        public DataTable dt;
        
        public string yonghu;
        public string id1;
        public string xuanzhong="";

        private void Frdaohuoshenpi_Load(object sender, EventArgs e)
        {
            Reload();
            Reload1();
            //gridView1.OptionsSelection.ResetSelectionClickOutsideCheckboxSelector = true;
        }
        private void Reload()
        {
            string sql1 = "select id,工作令号,项目名称,设备名称,实际采购数量,供方名称,型号,名称,单位,本次到货验收数量,发起到货验收数量,不合格数量,不合格描述,合格数量,合同号,退回原因 from  tb_caigouliaodan  where 到货检验人='" + yonghu + "' and 到货验收流程状态='1待检验'";
            gridControl1.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridView1.Columns["id"].Visible = false;
            gridView1.Columns["发起到货验收数量"].Visible = false;
        }

        private void Reload1()
        {
            string sql1 = "select id,工作令号,项目名称,设备名称,实际采购数量,供方名称,型号,名称,单位,本次到货验收数量,发起到货验收数量,合同号,退回原因 from  tb_caigouliaodan  where 到货检验人='" + yonghu + "' and 到货验收流程状态='1待收货'";
            gridControl2.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridView2.Columns["id"].Visible = false;
            gridView2.Columns["发起到货验收数量"].Visible = false;
        }

        private void 提交ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] c = gridView1.GetSelectedRows();
            foreach (int i in c)
            {
                string id = Convert.ToString(this.gridView1.GetRowCellValue(i, "id"));
                id1 = id;
                string hegeshuliang = Convert.ToString(this.gridView1.GetRowCellValue(i, "合格数量"));
                string daohuoshuliang = Convert.ToString(this.gridView1.GetRowCellValue(i, "本次到货验收数量"));
                string miaoshu = Convert.ToString(this.gridView1.GetRowCellValue(i, "不合格描述"));
                string buhegeshuliang = Convert.ToString(this.gridView1.GetRowCellValue(i, "不合格数量"));
                string jianyanrenyuan = Convert.ToString(this.gridView1.GetRowCellValue(i, "到货检验人"));

                float a = 0;

                if (float.TryParse(hegeshuliang, out a) == false)
                {
                    MessageBox.Show("合格数量必须是数字！");
                    return;
                }
                if (Convert.ToInt32(hegeshuliang) > Convert.ToInt32(daohuoshuliang))
                {
                    MessageBox.Show("合格数量大于到货数量，请重新提交！");
                    return;
                }
            }
            if (MessageBox.Show("确认完成吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                int[] a = gridView1.GetSelectedRows();
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                string id1 = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
                string sql3 = "select id,工作令号,项目名称,设备名称,实际到货数量,合同号,供方名称,型号,名称,单位,本次到货验收数量,发起到货验收数量,不合格数量,不合格描述 from  tb_caigouliaodan  where id ='" + id1 + "'";
                dt1 = SQLhelp.GetDataTable(sql3, CommandType.Text);
                dt2 = dt1.Clone();
                bool b = false;
                foreach (int i in a)
                {
                    string id = Convert.ToString(this.gridView1.GetRowCellValue(i, "id"));
                    id1 = id;
                    string hegeshuliang = Convert.ToString(this.gridView1.GetRowCellValue(i, "合格数量"));
                    string daohuoshuliang = Convert.ToString(this.gridView1.GetRowCellValue(i, "本次到货验收数量"));
                    string miaoshu = Convert.ToString(this.gridView1.GetRowCellValue(i, "不合格描述"));

                    if (hegeshuliang.Trim() == "")
                    {
                        int a1 = i + 1;
                        string msg = "第" + a1 + "行请填写合格数量！";
                        MessageBox.Show(msg);
                        return;
                    }
                    if (Convert.ToInt32(hegeshuliang) < Convert.ToInt32(daohuoshuliang) && miaoshu.Trim() == "")
                    {
                        int a1 = i + 1;
                        string msg = "第" + a1 + "行请填写不合格描述！";
                        MessageBox.Show(msg);
                        return;
                    }
                    
                    if (Convert.ToInt32(hegeshuliang) <= Convert.ToInt32(daohuoshuliang))
                    {
                        string sql = "update tb_caigouliaodan set 合格数量='" + hegeshuliang + "',不合格描述='" + miaoshu + "' where id ='" + id + "'";
                        SQLhelp.ExecuteScalar(sql, CommandType.Text);

                        string sql1 = "update tb_caigouliaodan set  不合格数量= (select 本次到货验收数量 - 合格数量 as 不合格数量  from tb_caigouliaodan  where id ='" + id + "')  where id ='" + id + "'";
                        SQLhelp.ExecuteScalar(sql1, CommandType.Text);

                        string sql2 = "select id,工作令号,项目名称,设备名称,合同号,供方名称,型号,名称,单位,本次到货验收数量,发起到货验收数量,不合格数量,不合格描述,合格数量,实际采购数量 from  tb_caigouliaodan  where id ='" + id + "'";
                        dt1 = SQLhelp.GetDataTable(sql2, CommandType.Text);
                        dt2.Merge(dt1, true, MissingSchemaAction.Ignore);
                        b = true;                                                
                    }
                    else
                    {
                        MessageBox.Show("合格数量大于到货数量，请重新提交！");
                    }
                }
                if (b)
                {
                    Frtijiaofujian form = new Frtijiaofujian();
                    form.id = id1;
                    form.dt = dt2;
                    form.yonghu = yonghu;
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.OK)
                    {
                        Reload();
                    }
                }
            }
            else
            {
                MessageBox.Show("取消！");
                return;
            }            
        }

        private void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void 查看图纸ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
                               
            dt.Columns.Add("id");
            dt.Columns.Add("工作令号");
            dt.Columns.Add("项目名称");
            dt.Columns.Add("设备名称");
            dt.Columns.Add("供方名称");            
            dt.Columns.Add("型号");
            dt.Columns.Add("名称");
            dt.Columns.Add("单位");
            dt.Columns.Add("实际采购数量");
            dt.Columns.Add("到货数量");
            dt.Columns.Add("提交人");
            dt.Columns.Add("提交时间");
            dt.Columns.Add("提交类型");
            dt.Columns.Add("物流部发票名称");
            dt.Columns.Add("物流部送货单名称");
            dt.Columns.Add("合格证名称");
            dt.Columns.Add("自检报告名称");
            dt.Columns.Add("验收图纸名称");
            dt.Columns.Add("查看该批次");

            dt1.Columns.Add("id");
            dt1.Columns.Add("工作令号");
            dt1.Columns.Add("项目名称");
            dt1.Columns.Add("设备名称");
            dt1.Columns.Add("供方名称");            
            dt1.Columns.Add("型号");
            dt1.Columns.Add("名称");
            dt1.Columns.Add("单位");
            dt1.Columns.Add("实际采购数量");
            dt1.Columns.Add("到货数量");
            dt1.Columns.Add("提交人");
            dt1.Columns.Add("提交时间");
            dt1.Columns.Add("提交类型");
            dt1.Columns.Add("物流部发票名称");
            dt1.Columns.Add("物流部送货单名称");
            dt1.Columns.Add("合格证名称");
            dt1.Columns.Add("自检报告名称");
            dt1.Columns.Add("验收图纸名称");
            dt1.Columns.Add("查看该批次");


            string id = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
            
            string sql = "select id,工作令号,项目名称,设备名称,供方名称,型号,名称,单位,实际采购数量,到货数量,提交人,提交时间,物流部发票名称,物流部送货单名称,合格证名称,自检报告名称,验收图纸名称,查看该批次,提交类型 from tb_daohuojilu where 定位 = '" + id + "'";
            dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            dt1.Merge(dt, true, MissingSchemaAction.Ignore);

            string sql1 = "select 查看该批次 from tb_daohuojilu where 定位 = '" + id + "'";
            string qingdan = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));

            Frchakanjilu form = new Frchakanjilu();
            form.dt = dt1;
            form.yonghu = yonghu;
            form.qingdan = qingdan;
            form.ShowDialog();
        }
        
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            string hegeshuliang = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "合格数量"));
            string buhegeshuliang = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "不合格数量"));
            string daohuoshuliang = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "本次到货验收数量"));
            float c = 0;

            if (float.TryParse(hegeshuliang, out c) == false)
            {
                MessageBox.Show("必须输入数字！");
                return;
            }
            if (Convert.ToInt32(hegeshuliang) <= Convert.ToInt32(daohuoshuliang))
            {
                float a, b;
                float.TryParse(daohuoshuliang, out a);
                float.TryParse(hegeshuliang, out b);
                buhegeshuliang = (a - b).ToString();

                if (e.Column.FieldName == "合格数量")
                {
                    gridView1.SetRowCellValue(e.RowHandle, "不合格数量", buhegeshuliang);
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("合格数量大于到货数量，请重新填写！");
            }
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            
                
        }

        private void 确认ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认完成吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                int[] c = gridView2.GetSelectedRows();
                string tijiaoshijian = DateTime.Now.ToString();
                foreach (int i in c)
                {
                    string id1 = Convert.ToString(this.gridView2.GetRowCellValue(i, "id"));

                    string sq2 = "update tb_caigouliaodan set 到货验收流程状态='2已收货',提交类型='收货人进行确认' where id ='" + id1 + "'";
                    SQLhelp.ExecuteScalar(sq2, CommandType.Text);

                    string sql4 = "update tb_caigouliaodan set 提交时间='" + tijiaoshijian + "',提交人='" + yonghu + "' where id ='" + id1 + "'";
                    SQLhelp.ExecuteScalar(sql4, CommandType.Text);

                    string sql3 = "insert into tb_daohuojilu  (工作令号,项目名称,设备名称,名称,供方名称,型号,单位,定位,到货数量,提交人,提交时间,提交类型,实际采购数量)select 工作令号,项目名称,设备名称,名称,供方名称,型号,单位,id,本次到货验收数量,提交人,提交时间,提交类型,实际采购数量  from tb_caigouliaodan where id ='" + id1 + "'";
                    SQLhelp.ExecuteScalar(sql3, CommandType.Text);
                }
                MessageBox.Show("提交成功！");                
                Reload1();
            }
            else
            {
                MessageBox.Show("取消！");
                return;
            }
        }

        private void 退回ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认提交吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                int[] c = gridView2.GetSelectedRows();
                string tijiaoshijian = DateTime.Now.ToString();
                foreach (int i in c)
                {
                    string id1 = Convert.ToString(this.gridView2.GetRowCellValue(i, "id"));
                    string tuihuiyuanyin= Convert.ToString(this.gridView2.GetRowCellValue(i, "退回原因"));
                    string sq2 = "update tb_caigouliaodan set 到货验收流程状态='3退回',提交类型='收货人进行退回',提交时间='" + tijiaoshijian + "',提交人='" + yonghu + "',退回原因='"+ tuihuiyuanyin + "' where id ='" + id1 + "'";
                    SQLhelp.ExecuteScalar(sq2, CommandType.Text);

                    string sql3 = "insert into tb_daohuojilu  (工作令号,项目名称,设备名称,名称,供方名称,型号,单位,定位,到货数量,提交人,提交时间,提交类型,实际采购数量,退回原因)select 工作令号,项目名称,设备名称,名称,供方名称,型号,单位,id,本次到货验收数量,提交人,提交时间,提交类型,实际采购数量,退回原因  from tb_caigouliaodan where id ='" + id1 + "'";
                    SQLhelp.ExecuteScalar(sql3, CommandType.Text);
                }
                MessageBox.Show("提交成功！");
                string id = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id"));
                string hetonghao = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "合同号"));
                string gongfangmingcheng = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "供方名称"));

                string sql1 = "select 物流员 from tb_caigouliaodan where id='" + id + "'";
                string jianyanyuan = SQLhelp.ExecuteScalar(sql1, CommandType.Text).ToString();

                string sendmessage = yonghu + "  退回了一份" + hetonghao + "\r\n" + gongfangmingcheng + " 的到货验收流程" + "\r\n" +
              "请物流员" + jianyanyuan + "查看！";
                NetWork3J NetWork3J = new NetWork3J(yonghu, "http://" + MyGlobal.ip + ":81/");
                NetWork3J.sendmessageById(jianyanyuan, sendmessage);

                Reload1();
            }
            else
            {
                MessageBox.Show("取消！");
                return;
            }
        }

        private void 刷新ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reload1();
        }

        private void 查看记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();

            dt.Columns.Add("id");
            dt.Columns.Add("工作令号");
            dt.Columns.Add("项目名称");
            dt.Columns.Add("设备名称");
            dt.Columns.Add("供方名称");
            dt.Columns.Add("型号");
            dt.Columns.Add("名称");
            dt.Columns.Add("单位");
            dt.Columns.Add("实际采购数量");
            dt.Columns.Add("到货数量");
            dt.Columns.Add("提交人");
            dt.Columns.Add("提交时间");
            dt.Columns.Add("提交类型");
            dt.Columns.Add("物流部送货单名称");
            dt.Columns.Add("合格证名称");
            dt.Columns.Add("查看该批次");

            dt1.Columns.Add("id");
            dt1.Columns.Add("工作令号");
            dt1.Columns.Add("项目名称");
            dt1.Columns.Add("设备名称");
            dt1.Columns.Add("供方名称");
            dt1.Columns.Add("型号");
            dt1.Columns.Add("名称");
            dt1.Columns.Add("单位");
            dt1.Columns.Add("实际采购数量");
            dt1.Columns.Add("到货数量");
            dt1.Columns.Add("提交人");
            dt1.Columns.Add("提交时间");
            dt1.Columns.Add("提交类型");
            
            dt1.Columns.Add("物流部送货单名称");
            dt1.Columns.Add("合格证名称");
            
            dt1.Columns.Add("查看该批次");


            string id = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id").ToString();

            string sql = "select id,工作令号,项目名称,设备名称,供方名称,型号,名称,单位,实际采购数量,到货数量,提交人,提交时间,物流部送货单名称,合格证名称,查看该批次,提交类型 from tb_daohuojilu where 定位 = '" + id + "'";
            dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            dt1.Merge(dt, true, MissingSchemaAction.Ignore);

            string sql1 = "select 查看该批次 from tb_daohuojilu where 定位 = '" + id + "'";
            string qingdan = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));

            Frgudingzichanjilu form = new Frgudingzichanjilu();
            form.dt = dt1;
            form.yonghu = yonghu;
            form.qingdan = qingdan;
            form.ShowDialog();
        }
    }

    
}
