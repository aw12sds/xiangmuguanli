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
    public partial class Frbuhegepingshen : DevExpress.XtraEditors.XtraForm
    {
        public Frbuhegepingshen()
        {
            InitializeComponent();
        }
        public DataTable dt;
        public string yonghu;
        public string id1;
        public string xuanzhong = "";
        private void Frbuhegepingshen_Load(object sender, EventArgs e)
        {
            string sql3 = "select 到货检验人 from  tb_caigouliaodan  where 到货验收流程状态='4不合格待评审'";
            string jianyanrenyuan = Convert.ToString(SQLhelp.ExecuteScalar(sql3, CommandType.Text));            
            
            string sql4 = "select 部门 from tb_operator where 用户名='"+jianyanrenyuan+"'";
            string bumen = Convert.ToString(sqlhelp111.ExecuteScalar(sql4, CommandType.Text));
            
            string sql5 = "select 部门 from tb_operator where 用户名='"+yonghu+"'";
            string bumen1 = Convert.ToString(sqlhelp111.ExecuteScalar(sql5, CommandType.Text));
            
            if (bumen == bumen1)
            {
                reload();
            }
        }
        public void reload()
        {
            
            string sql1 = "select id,工作令号,项目名称,设备名称,供方名称,型号,名称,单位,发起到货验收数量,本次到货验收数量,合格数量,不合格数量,不合格描述,供应商返工,让步接受数,报废,自家返工,实际采购数量,合同号,批复 from  tb_caigouliaodan  where 到货验收流程状态='4不合格待评审'";
            gridControl1.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
            
            gridView1.Columns["id"].Visible = false;
        }

        private void 提交ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] c = gridView1.GetSelectedRows();
            foreach (int i in c)
            {
                string id = Convert.ToString(this.gridView1.GetRowCellValue(i, "id"));
                id1 = id;
                string gongyingshangfangong = Convert.ToString(this.gridView1.GetRowCellValue(i, "供应商返工"));
                string rangbujieshoushu = Convert.ToString(this.gridView1.GetRowCellValue(i, "让步接受数"));
                string baofei = Convert.ToString(this.gridView1.GetRowCellValue(i, "报废"));
                string zijiafangong = Convert.ToString(this.gridView1.GetRowCellValue(i, "自家返工"));
                string buhegeshuliang = Convert.ToString(this.gridView1.GetRowCellValue(i, "不合格数量"));

                if (gongyingshangfangong.Trim() == "")
                {
                    gongyingshangfangong = "0";
                }
                if (rangbujieshoushu.Trim() == "")
                {
                    rangbujieshoushu = "0";
                }
                if (baofei.Trim() == "")
                {
                    baofei = "0";
                }
                if (zijiafangong.Trim() == "")
                {
                    zijiafangong = "0";
                }
                if (Convert.ToInt32(gongyingshangfangong) + Convert.ToInt32(rangbujieshoushu) + Convert.ToInt32(baofei) + Convert.ToInt32(zijiafangong) != Convert.ToInt32(buhegeshuliang))
                {
                    int a1 = i + 1;
                    string msg ="第"+ a1 + "行供应商返工加让步接受数加报废加自家返工不等于不合格数量，请重新提交！";
                    MessageBox.Show(msg);
                    return;
                }
            }
            if (MessageBox.Show("确认完成吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                int[] a = gridView1.GetSelectedRows();
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                string id1 = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
                string sql3 = "select id,工作令号,项目名称,设备名称,合同号,供方名称,型号,名称,单位,本次到货验收数量,发起到货验收数量,不合格数量,不合格描述,供应商返工,让步接受数,报废,自家返工 from  tb_caigouliaodan  where id ='" + id1 + "'";
                dt1 = SQLhelp.GetDataTable(sql3, CommandType.Text);
                dt2 = dt1.Clone();
                bool b = false;
                foreach (int i in a)
                {
                    string id = Convert.ToString(this.gridView1.GetRowCellValue(i, "id"));
                    id1 = id;
                    string gongyingshangfangong = Convert.ToString(this.gridView1.GetRowCellValue(i, "供应商返工"));
                    string rangbujieshoushu = Convert.ToString(this.gridView1.GetRowCellValue(i, "让步接受数"));
                    string baofei = Convert.ToString(this.gridView1.GetRowCellValue(i, "报废"));
                    string zijiafangong = Convert.ToString(this.gridView1.GetRowCellValue(i, "自家返工"));
                    string buhegeshuliang = Convert.ToString(this.gridView1.GetRowCellValue(i, "不合格数量"));

                    if (gongyingshangfangong.Trim() == "")
                    {
                        gongyingshangfangong = "0";
                    }
                    if (rangbujieshoushu.Trim() == "")
                    {
                        rangbujieshoushu = "0";
                    }
                    if (baofei.Trim() == "")
                    {
                        baofei = "0";
                    }
                    if (zijiafangong.Trim() == "")
                    {
                        zijiafangong = "0";
                    }


                    if (Convert.ToInt32(gongyingshangfangong) + Convert.ToInt32(rangbujieshoushu) + Convert.ToInt32(baofei) + Convert.ToInt32(zijiafangong) == Convert.ToInt32(buhegeshuliang))
                    {
                        string sql1 = "update tb_caigouliaodan set 供应商返工='" + gongyingshangfangong + "',让步接受数='" + rangbujieshoushu + "',报废='" + baofei + "',自家返工='" + zijiafangong + "' where id='" + id + "'";
                        SQLhelp.ExecuteScalar(sql1, CommandType.Text);

                        string sql2 = "select id,工作令号,项目名称,设备名称,合同号,供方名称,型号,名称,单位,本次到货验收数量,发起到货验收数量,不合格数量,不合格描述,供应商返工,让步接受数,报废,自家返工 from  tb_caigouliaodan  where id ='" + id + "'";
                        dt1 = SQLhelp.GetDataTable(sql2, CommandType.Text);
                        dt2.Merge(dt1, true, MissingSchemaAction.Ignore);
                        b = true;
                        
                    }
                    else
                    {
                        MessageBox.Show("提交失败！");
                    }

                }
                if (b)
                {
                    Frbaojia form = new Frbaojia();
                    form.id = id1;
                    form.yonghu = yonghu;
                    form.dt = dt2;
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.OK)
                    {
                        reload();
                    }
                }
            }
            else
            {
                MessageBox.Show("取消！");
                return;
            }

        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
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
            dt.Columns.Add("合格数量");
            dt.Columns.Add("不合格数量");
            dt.Columns.Add("不合格描述");
            dt.Columns.Add("提交人");
            dt.Columns.Add("提交时间");
            dt.Columns.Add("提交类型");
            dt.Columns.Add("物流部发票名称");
            dt.Columns.Add("物流部送货单名称");
            dt.Columns.Add("合格证名称");
            dt.Columns.Add("自检报告名称");
            dt.Columns.Add("验收图纸名称");
            dt.Columns.Add("检验员附件名称");
            dt.Columns.Add("质监员附件名称");
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
            dt1.Columns.Add("合格数量");
            dt1.Columns.Add("不合格数量");
            dt1.Columns.Add("不合格描述");
            dt1.Columns.Add("提交人");
            dt1.Columns.Add("提交时间");
            dt1.Columns.Add("提交类型");
            dt1.Columns.Add("物流部发票名称");
            dt1.Columns.Add("物流部送货单名称");
            dt1.Columns.Add("合格证名称");
            dt1.Columns.Add("自检报告名称");
            dt1.Columns.Add("验收图纸名称");
            dt1.Columns.Add("检验员附件名称");
            dt1.Columns.Add("质监员附件名称");
            dt1.Columns.Add("查看该批次");


            string id = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
            string sql = "select id,工作令号,项目名称,设备名称,供方名称,型号,名称,单位,实际采购数量,到货数量,合格数量,不合格数量,不合格描述,提交人,提交时间,物流部发票名称,物流部送货单名称,合格证名称,自检报告名称,验收图纸名称,检验员附件名称,质监员附件名称,查看该批次,提交类型 from tb_daohuojilu where 定位 = '" + id + "'";
            dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            dt1.Merge(dt, true, MissingSchemaAction.Ignore);

            string sql1 = "select 查看该批次 from tb_daohuojilu where 定位 = '" + id + "'";
            string qingdan = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));

            Frchakan form = new Frchakan();
            form.dt = dt1;
            form.qingdan = qingdan;
            form.yonghu = yonghu;
            form.ShowDialog();
        }

        private void gridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (gridView1.FocusedColumn.Name == "供方返工" || gridView1.FocusedColumn.Name == "代返工" || gridView1.FocusedColumn.Name == "让步接收" || gridView1.FocusedColumn.Name == "报废")
            {
                float a = 0;
                float b = 0;
                float c = 0;
                float d = 0;
                string gongfang = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "供方返工"));
                string daifangong = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "代返工"));
                string rangbu = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "让步接收"));
                string baofei = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "报废"));

                if (float.TryParse(gongfang, out a) == false || float.TryParse(daifangong, out b) == false || float.TryParse(rangbu, out c) == false|| float.TryParse(baofei, out d) == false)
                {
                    MessageBox.Show("数量必须是数字！");
                    return;
                }
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            string gongyingshangfangong = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "供应商返工"));
            string rangbujieshoushu = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "让步接受数"));
            string baofei = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "报废"));
            string zijiafangong = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "自家返工"));
            string buhegeshuliang = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "不合格数量"));

        }
    }
}
