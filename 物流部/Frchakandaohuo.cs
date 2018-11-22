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
    public partial class Frchakandaohuo : DevExpress.XtraEditors.XtraForm
    {
        public Frchakandaohuo()
        {
            InitializeComponent();
        }
        public string yonghu;
        public string qingdan = "";
        public string hetonghao1 = "";
        private void Frchakandaohuo_Load(object sender, EventArgs e)
        {
            reload();
            reload1();
            reload2();
        }

        public void reload()
        {
            string sql1 = "select id,工作令号,项目名称,设备名称,供方名称,型号,名称,单位,发起到货验收数量,实际采购数量,合同号,合格数量,不合格数量,不合格描述,供应商返工,自家返工,让步接受数,报废,仓库描述,批复 from  tb_caigouliaodan  where (物流员='" + yonghu + "' and 到货验收流程状态='6待采购' and 到货类型='外协整机原材料') or (物流员='" + yonghu + "' and 到货验收流程状态='7再发起'and 到货类型='外协整机原材料') or (物流员='" + yonghu + "' and 仓库确认状态 IS NULL and 到货类型='外协整机原材料')";
            gridControl1.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridView1.Columns["id"].Visible = false;
            gridView1.Columns["发起到货验收数量"].Visible = false;
            
        }
        public void reload1()
        {
            string sql1 = "select id,工作令号,项目名称,设备名称,供方名称,型号,名称,单位,发起到货验收数量,实际采购数量,合同号,退回原因 from  tb_caigouliaodan  where  物流员='" + yonghu + "' and 到货验收流程状态='7再发起' and 到货类型='五金辅材标准件'";
            gridControl2.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridView2.Columns["id"].Visible = false;
            gridView2.Columns["发起到货验收数量"].Visible = false;
        }

        public void reload2()
        {
            string sql1 = "select id,工作令号,项目名称,设备名称,供方名称,型号,名称,单位,发起到货验收数量,实际采购数量,合同号,仓库描述,本次到货验收数量,退回原因 from  tb_caigouliaodan  where  物流员='" + yonghu + "' and 到货验收流程状态='3退回' and 到货类型='固定资产'";
            gridControl3.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridView3.Columns["id"].Visible = false;
            gridView3.Columns["发起到货验收数量"].Visible = false;
        }
        private void 提交ToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            int[] a = gridView1.GetSelectedRows();
            
            foreach (int i in a)
            {
                string id = gridView1.GetRowCellValue(i, "id").ToString();
                qingdan += id + "|";
            }
            foreach (int i in a)
            {
                string hetonghao = gridView1.GetRowCellValue(i, "合同号").ToString();
                hetonghao1 += hetonghao + "|";
            }

            if (qingdan == "")
            {
                MessageBox.Show("没有选中！");
                return;
            }
            DataTable dt = new DataTable();
            DataTable zongbiao = new DataTable();

            dt.Columns.Add("id");
            dt.Columns.Add("工作令号");
            dt.Columns.Add("项目名称");
            dt.Columns.Add("设备名称");
            dt.Columns.Add("供方名称");
            dt.Columns.Add("型号");
            dt.Columns.Add("名称");
            dt.Columns.Add("单位");
            dt.Columns.Add("实际采购数量");
            dt.Columns.Add("合同号");
            dt.Columns.Add("发起到货验收数量");
            dt.Columns.Add("本次数量");
            dt.Columns.Add("不合格数量");



            zongbiao.Columns.Add("id");
            zongbiao.Columns.Add("工作令号");
            zongbiao.Columns.Add("项目名称");
            zongbiao.Columns.Add("设备名称");
            zongbiao.Columns.Add("供方名称");
            zongbiao.Columns.Add("型号");
            zongbiao.Columns.Add("名称");
            zongbiao.Columns.Add("单位");
            zongbiao.Columns.Add("实际采购数量");
            zongbiao.Columns.Add("合同号");
            zongbiao.Columns.Add("发起到货验收数量");
            zongbiao.Columns.Add("本次数量");
            zongbiao.Columns.Add("不合格数量");

            string[] strArray = qingdan.Split('|'); //字符串转数组
            List<string> list = new List<string>();

            for (int i = 0; i < strArray.Length; i++)//遍历数组成员
            {
                if (list.IndexOf(strArray[i].ToLower()) == -1)//对每个成员做一次新数组查询如果没有相等的则加到新数组
                    list.Add(strArray[i]);

            }

            string[] strArray1 = hetonghao1.Split('|'); //字符串转数组
            List<string> list1 = new List<string>();
            for (int i = 0; i < strArray1.Length; i++)//遍历数组成员
            {
                if (list1.IndexOf(strArray1[i].ToLower()) == -1)//对每个成员做一次新数组查询如果没有相等的则加到新数组
                    list1.Add(strArray1[i]);

            }
            if (list1.Count > 2)
            {
                MessageBox.Show("到货验收不允许有不同的合同号！");
                qingdan = "";
                hetonghao1 = "";
                return;
            }            

            for (int i = 0; i < list.Count; i++)
            {
                string dingwei = list[i];

                string sql1 = "select id,工作令号,项目名称,设备名称,供方名称,型号,名称,单位,实际采购数量,合同号,发起到货验收数量,本次数量,不合格数量 from  tb_caigouliaodan where (id ='" + dingwei + "'and 到货验收流程状态='6待采购') or (id ='" + dingwei + "'and 到货验收流程状态='7再发起') ";
                dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                zongbiao.Merge(dt, true, MissingSchemaAction.Ignore);

            }

            Frzaifaqi form1 = new Frzaifaqi();
            form1.dt = zongbiao;
            form1.yonghu = yonghu;
            form1.ShowDialog();
        }

        private void 查看详情ToolStripMenuItem_Click(object sender, EventArgs e)
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
            dt.Columns.Add("供应商返工");
            dt.Columns.Add("让步接受数");
            dt.Columns.Add("报废");
            dt.Columns.Add("自家返工");
            dt.Columns.Add("人工数");
            dt.Columns.Add("检验时间数");
            dt.Columns.Add("特殊耗材");
            dt.Columns.Add("报价总额");
            dt.Columns.Add("批复");
            dt.Columns.Add("物流部发票名称");
            dt.Columns.Add("物流部送货单名称");
            dt.Columns.Add("合格证名称");
            dt.Columns.Add("自检报告名称");
            dt.Columns.Add("验收图纸名称");
            dt.Columns.Add("检验员附件名称");
            dt.Columns.Add("质监员附件名称");
            dt.Columns.Add("不合格审批附件名称");
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
            dt1.Columns.Add("供应商返工");
            dt1.Columns.Add("让步接受数");
            dt1.Columns.Add("报废");
            dt1.Columns.Add("自家返工");
            dt1.Columns.Add("人工数");
            dt1.Columns.Add("检验时间数");
            dt1.Columns.Add("特殊耗材");
            dt1.Columns.Add("报价总额");
            dt1.Columns.Add("批复");
            dt1.Columns.Add("物流部发票名称");
            dt1.Columns.Add("物流部送货单名称");
            dt1.Columns.Add("合格证名称");
            dt1.Columns.Add("自检报告名称");
            dt1.Columns.Add("验收图纸名称");
            dt1.Columns.Add("检验员附件名称");
            dt1.Columns.Add("质监员附件名称");
            dt1.Columns.Add("不合格审批附件名称");
            dt1.Columns.Add("查看该批次");

            string id = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
            string sql = "select id,工作令号,项目名称,设备名称,供方名称,型号,名称,单位,实际采购数量,到货数量,合格数量,不合格数量,不合格描述,提交人,提交时间,物流部发票名称,物流部送货单名称,合格证名称,自检报告名称,验收图纸名称,检验员附件名称,质监员附件名称,供应商返工,让步接受数,报废,自家返工,人工数,检验时间数,特殊耗材,报价总额,不合格审批附件名称,查看该批次,提交类型,批复 from tb_daohuojilu where 定位 = '" + id + "'";
            dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            dt1.Merge(dt, true, MissingSchemaAction.Ignore);

            string sql1 = "select 查看该批次 from tb_daohuojilu where 定位 = '" + id + "'";
            string qingdan = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));

            Frzaifaqijilu form = new Frzaifaqijilu();
            form.dt = dt1;
            form.qingdan = qingdan;
            form.yonghu = yonghu;
            form.ShowDialog();
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reload();
        }

        private void 再确认附件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] a = gridView1.GetSelectedRows();

            foreach (int i in a)
            {
                string id = gridView1.GetRowCellValue(i, "id").ToString();
                qingdan += id + "|";
            }
            foreach (int i in a)
            {
                string hetonghao = gridView1.GetRowCellValue(i, "合同号").ToString();
                hetonghao1 += hetonghao + "|";
            }

            if (qingdan == "")
            {
                MessageBox.Show("没有选中！");
                return;
            }
            DataTable dt = new DataTable();
            DataTable zongbiao = new DataTable();

            dt.Columns.Add("id");
            dt.Columns.Add("工作令号");
            dt.Columns.Add("项目名称");
            dt.Columns.Add("设备名称");
            dt.Columns.Add("供方名称");
            dt.Columns.Add("型号");
            dt.Columns.Add("名称");
            dt.Columns.Add("单位");
            dt.Columns.Add("实际采购数量");
            dt.Columns.Add("合同号");
            dt.Columns.Add("发起到货验收数量");
            dt.Columns.Add("本次数量");
            dt.Columns.Add("不合格数量");



            zongbiao.Columns.Add("id");
            zongbiao.Columns.Add("工作令号");
            zongbiao.Columns.Add("项目名称");
            zongbiao.Columns.Add("设备名称");
            zongbiao.Columns.Add("供方名称");
            zongbiao.Columns.Add("型号");
            zongbiao.Columns.Add("名称");
            zongbiao.Columns.Add("单位");
            zongbiao.Columns.Add("实际采购数量");
            zongbiao.Columns.Add("合同号");
            zongbiao.Columns.Add("发起到货验收数量");
            zongbiao.Columns.Add("本次数量");
            zongbiao.Columns.Add("不合格数量");

            string[] strArray = qingdan.Split('|'); //字符串转数组
            List<string> list = new List<string>();

            for (int i = 0; i < strArray.Length; i++)//遍历数组成员
            {
                if (list.IndexOf(strArray[i].ToLower()) == -1)//对每个成员做一次新数组查询如果没有相等的则加到新数组
                    list.Add(strArray[i]);

            }

            string[] strArray1 = hetonghao1.Split('|'); //字符串转数组
            List<string> list1 = new List<string>();
            for (int i = 0; i < strArray1.Length; i++)//遍历数组成员
            {
                if (list1.IndexOf(strArray1[i].ToLower()) == -1)//对每个成员做一次新数组查询如果没有相等的则加到新数组
                    list1.Add(strArray1[i]);

            }
            if (list1.Count > 2)
            {
                MessageBox.Show("到货验收不允许有不同的合同号！");
                qingdan = "";
                hetonghao1 = "";
                return;
            }

            for (int i = 0; i < list.Count; i++)
            {
                string dingwei = list[i];

                string sql1 = "select id,工作令号,项目名称,设备名称,供方名称,型号,名称,单位,实际采购数量,合同号,发起到货验收数量,本次数量,不合格数量 from  tb_caigouliaodan where id ='" + dingwei + "'and 到货验收流程状态='7再发起'";
                dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                zongbiao.Merge(dt, true, MissingSchemaAction.Ignore);

            }

            Frzaiquerenfujian form1 = new Frzaiquerenfujian();
            form1.dt = zongbiao;
            form1.yonghu = yonghu;
            form1.ShowDialog();
        }

        private void 再发起ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] a = gridView2.GetSelectedRows();

            foreach (int i in a)
            {
                string id = gridView2.GetRowCellValue(i, "id").ToString();
                qingdan += id + "|";
            }
            foreach (int i in a)
            {
                string hetonghao = gridView2.GetRowCellValue(i, "合同号").ToString();
                hetonghao1 += hetonghao + "|";
            }

            if (qingdan == "")
            {
                MessageBox.Show("没有选中！");
                return;
            }
            DataTable dt = new DataTable();
            DataTable zongbiao = new DataTable();

            dt.Columns.Add("id");
            dt.Columns.Add("工作令号");
            dt.Columns.Add("项目名称");
            dt.Columns.Add("设备名称");
            dt.Columns.Add("供方名称");
            dt.Columns.Add("型号");
            dt.Columns.Add("名称");
            dt.Columns.Add("单位");
            dt.Columns.Add("实际采购数量");
            dt.Columns.Add("合同号");
            dt.Columns.Add("发起到货验收数量");
            dt.Columns.Add("本次数量");
            
            zongbiao.Columns.Add("id");
            zongbiao.Columns.Add("工作令号");
            zongbiao.Columns.Add("项目名称");
            zongbiao.Columns.Add("设备名称");
            zongbiao.Columns.Add("供方名称");
            zongbiao.Columns.Add("型号");
            zongbiao.Columns.Add("名称");
            zongbiao.Columns.Add("单位");
            zongbiao.Columns.Add("实际采购数量");
            zongbiao.Columns.Add("合同号");
            zongbiao.Columns.Add("发起到货验收数量");
            zongbiao.Columns.Add("本次数量");
            

            string[] strArray = qingdan.Split('|'); //字符串转数组
            List<string> list = new List<string>();

            for (int i = 0; i < strArray.Length; i++)//遍历数组成员
            {
                if (list.IndexOf(strArray[i].ToLower()) == -1)//对每个成员做一次新数组查询如果没有相等的则加到新数组
                    list.Add(strArray[i]);

            }

            string[] strArray1 = hetonghao1.Split('|'); //字符串转数组
            List<string> list1 = new List<string>();
            for (int i = 0; i < strArray1.Length; i++)//遍历数组成员
            {
                if (list1.IndexOf(strArray1[i].ToLower()) == -1)//对每个成员做一次新数组查询如果没有相等的则加到新数组
                    list1.Add(strArray1[i]);

            }
            if (list1.Count > 2)
            {
                MessageBox.Show("到货验收不允许有不同的合同号！");
                qingdan = "";
                hetonghao1 = "";
                return;
            }

            for (int i = 0; i < list.Count; i++)
            {
                string dingwei = list[i];

                string sql1 = "select id,工作令号,项目名称,设备名称,供方名称,型号,名称,单位,实际采购数量,合同号,发起到货验收数量,本次数量,仓库描述 from  tb_caigouliaodan where id ='" + dingwei + "'and 到货验收流程状态='7再发起' and 到货类型='五金辅材标准件' ";
                dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                zongbiao.Merge(dt, true, MissingSchemaAction.Ignore);

            }

            Frwujinzaifaqi form1 = new Frwujinzaifaqi();
            form1.dt = zongbiao;
            form1.yonghu = yonghu;
            form1.ShowDialog();
        }

        private void 刷新ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            reload1();
            
        }

        private void 查看详情ToolStripMenuItem1_Click(object sender, EventArgs e)
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

            dt1.Columns.Add("查看该批次");


            string id = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id").ToString();

            string sql = "select id,工作令号,项目名称,设备名称,供方名称,型号,名称,单位,实际采购数量,到货数量,提交人,提交时间,物流部送货单名称,合格证名称,查看该批次,提交类型,物流部发票名称 from tb_daohuojilu where 定位 = '" + id + "'";
            dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            dt1.Merge(dt, true, MissingSchemaAction.Ignore);

            string sql1 = "select 查看该批次 from tb_daohuojilu where 定位 = '" + id + "'";
            string qingdan = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));

            Frwujinzaifaiqijilu form = new Frwujinzaifaiqijilu();
            form.dt = dt1;
            form.yonghu = yonghu;
            form.qingdan = qingdan;
            form.ShowDialog();
        }

        private void 再发起ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int[] a = gridView3.GetSelectedRows();

            foreach (int i in a)
            {
                string id = gridView3.GetRowCellValue(i, "id").ToString();
                qingdan += id + "|";
            }
            foreach (int i in a)
            {
                string hetonghao = gridView3.GetRowCellValue(i, "合同号").ToString();
                hetonghao1 += hetonghao + "|";
            }

            if (qingdan == "")
            {
                MessageBox.Show("没有选中！");
                return;
            }
            DataTable dt = new DataTable();
            DataTable zongbiao = new DataTable();

            dt.Columns.Add("id");
            dt.Columns.Add("工作令号");
            dt.Columns.Add("项目名称");
            dt.Columns.Add("设备名称");
            dt.Columns.Add("供方名称");
            dt.Columns.Add("型号");
            dt.Columns.Add("名称");
            dt.Columns.Add("单位");
            dt.Columns.Add("实际采购数量");
            dt.Columns.Add("合同号");
            dt.Columns.Add("发起到货验收数量");
            dt.Columns.Add("本次数量");

            zongbiao.Columns.Add("id");
            zongbiao.Columns.Add("工作令号");
            zongbiao.Columns.Add("项目名称");
            zongbiao.Columns.Add("设备名称");
            zongbiao.Columns.Add("供方名称");
            zongbiao.Columns.Add("型号");
            zongbiao.Columns.Add("名称");
            zongbiao.Columns.Add("单位");
            zongbiao.Columns.Add("实际采购数量");
            zongbiao.Columns.Add("合同号");
            zongbiao.Columns.Add("发起到货验收数量");
            zongbiao.Columns.Add("本次数量");


            string[] strArray = qingdan.Split('|'); //字符串转数组
            List<string> list = new List<string>();

            for (int i = 0; i < strArray.Length; i++)//遍历数组成员
            {
                if (list.IndexOf(strArray[i].ToLower()) == -1)//对每个成员做一次新数组查询如果没有相等的则加到新数组
                    list.Add(strArray[i]);

            }

            string[] strArray1 = hetonghao1.Split('|'); //字符串转数组
            List<string> list1 = new List<string>();
            for (int i = 0; i < strArray1.Length; i++)//遍历数组成员
            {
                if (list1.IndexOf(strArray1[i].ToLower()) == -1)//对每个成员做一次新数组查询如果没有相等的则加到新数组
                    list1.Add(strArray1[i]);

            }
            if (list1.Count > 2)
            {
                MessageBox.Show("到货验收不允许有不同的合同号！");
                qingdan = "";
                hetonghao1 = "";
                return;
            }

            for (int i = 0; i < list.Count; i++)
            {
                string dingwei = list[i];

                string sql1 = "select id,工作令号,项目名称,设备名称,供方名称,型号,名称,单位,实际采购数量,合同号,发起到货验收数量,本次数量,退回原因 from  tb_caigouliaodan where id ='" + dingwei + "'and 到货验收流程状态='3退回' and 到货类型='固定资产' ";
                dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                zongbiao.Merge(dt, true, MissingSchemaAction.Ignore);

            }

            Frgudingzichanzaifaqi form1 = new Frgudingzichanzaifaqi();
            form1.dt = zongbiao;
            form1.yonghu = yonghu;
            form1.ShowDialog();
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

        private void gridView3_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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


            string id = gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "id").ToString();

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

        private void 刷新ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            reload2();
        }
    }
}
