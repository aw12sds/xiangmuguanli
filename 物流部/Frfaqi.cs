using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace 项目管理系统.物流部
{
    public partial class Frfaqi : DevExpress.XtraEditors.XtraForm
    {
        public Frfaqi()
        {
            InitializeComponent();
        }
        public DataTable dt;
        public string yonghu;
        public string zhonglei;
        public string qingdan1="";
        public string qingdan2="";
        public string qingdan3="";
        public string hetonghao1 = "";
       
        private void Frfaqi_Load(object sender, EventArgs e)
        {
            gridView1.Columns["id"].Visible = false;
            
        }
        
        private void buttonItem2_Click(object sender, EventArgs e)
        {
            string sql1 = "select id,工作令号,项目名称,设备名称,供方名称,型号,名称,单位,数量,合同号,发起到货验收数量,实际采购数量 from  tb_caigouliaodan  where 合同号='" + txthetonghao + "'";
            gridControl1.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
            
        }

        
                
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void buttonItem1_Click_1(object sender, EventArgs e)
        {
            /*
            int[] a = gridView1.GetSelectedRows();
            foreach (int i in a)
            {
                string id = gridView1.GetRowCellValue(i, "id").ToString();
                qingdan1 += id + "|";
            }

            if (qingdan1 == "")
            {
                MessageBox.Show("没有选中，请选中！");
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
            


            string[] strArray = qingdan1.Split('|'); //字符串转数组
            List<string> list = new List<string>();

            for (int i = 0; i < strArray.Length; i++)//遍历数组成员
            {
                if (list.IndexOf(strArray[i].ToLower()) == -1)//对每个成员做一次新数组查询如果没有相等的则加到新数组
                    list.Add(strArray[i]);
            }

            for (int i = 0; i < list.Count; i++)
            {
                string dingwei = list[i];

                string sql1 = "select id,工作令号,项目名称,设备名称,供方名称,型号,名称,单位,实际采购数量,合同号,发起到货验收数量,本次数量 from  tb_caigouliaodan where id ='" + dingwei + "'and 到货验收流程状态 IS NULL ";
                dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                zongbiao.Merge(dt, true, MissingSchemaAction.Ignore);
            }
            
            Frdaohuogouwuche form1 = new Frdaohuogouwuche();
            form1.dt = zongbiao;

            form1.yonghu = yonghu;
            form1.ShowDialog();
            */
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            qingdan1 = "";
            qingdan2 = "";
            qingdan3 = "";
            MessageBox.Show("已清空！");
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            //string sql2 = "select id,工作令号,项目名称,设备名称,供方名称,型号,名称,单位,数量,合同号,发起到货验收数量,实际采购数量,本次到货验收数量 from  tb_caigouliaodan  where 合同号='" + txthetonghao + "' and 本次到货验收数量=实际采购数量";
            string sql2 = "select id,工作令号,项目名称,设备名称,供方名称,型号,名称,单位,数量,合同号,发起到货验收数量,实际采购数量,本次到货验收数量 from  tb_caigouliaodan  where  本次到货验收数量=实际采购数量";
            gridControl1.DataSource = SQLhelp.GetDataTable(sql2, CommandType.Text);
        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            //string sql2 = "select id,工作令号,项目名称,设备名称,供方名称,型号,名称,单位,数量,合同号,发起到货验收数量,实际采购数量,本次到货验收数量 from  tb_caigouliaodan  where 合同号='" + txthetonghao + "' and 本次到货验收数量!=实际采购数量";
            string sql2 = "select id,工作令号,项目名称,设备名称,供方名称,型号,名称,单位,数量,合同号,发起到货验收数量,实际采购数量,本次到货验收数量 from  tb_caigouliaodan  where 本次到货验收数量!=实际采购数量 or 到货验收流程状态='4不合格待评审'";
            gridControl1.DataSource = SQLhelp.GetDataTable(sql2, CommandType.Text);
        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            int[] a = gridView1.GetSelectedRows();
            foreach (int i in a)
            {
                string id = gridView1.GetRowCellValue(i, "id").ToString();
                qingdan2 += id + "|";
            }

            if (qingdan2 == "")
            {
                MessageBox.Show("没有选中，请选中！");
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



            string[] strArray = qingdan2.Split('|'); //字符串转数组
            List<string> list = new List<string>();

            for (int i = 0; i < strArray.Length; i++)//遍历数组成员
            {
                if (list.IndexOf(strArray[i].ToLower()) == -1)//对每个成员做一次新数组查询如果没有相等的则加到新数组
                    list.Add(strArray[i]);
            }

            for (int i = 0; i < list.Count; i++)
            {
                string dingwei = list[i];

                string sql1 = "select id,工作令号,项目名称,设备名称,供方名称,型号,名称,单位,实际采购数量,合同号,发起到货验收数量,本次数量 from  tb_caigouliaodan where (id ='" + dingwei + "'and 到货验收流程状态 IS NULL) or (id ='" + dingwei + "'and 到货验收流程状态='2已收货' and 实际采购数量!=发起到货验收数量)";
                dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                zongbiao.Merge(dt, true, MissingSchemaAction.Ignore);
            }

            Frgudingzichan form1 = new Frgudingzichan();
            form1.dt = zongbiao;

            form1.yonghu = yonghu;
            form1.ShowDialog();
        }

        private void buttonItem7_Click(object sender, EventArgs e)
        {
            int[] a = gridView1.GetSelectedRows();
            foreach (int i in a)
            {
                string id = gridView1.GetRowCellValue(i, "id").ToString();
                qingdan3 += id + "|";
            }

            if (qingdan3 == "")
            {
                MessageBox.Show("没有选中，请选中！");
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



            string[] strArray = qingdan3.Split('|'); //字符串转数组
            List<string> list = new List<string>();

            for (int i = 0; i < strArray.Length; i++)//遍历数组成员
            {
                if (list.IndexOf(strArray[i].ToLower()) == -1)//对每个成员做一次新数组查询如果没有相等的则加到新数组
                    list.Add(strArray[i]);
            }

            for (int i = 0; i < list.Count; i++)
            {
                string dingwei = list[i];

                string sql1 = "select id,工作令号,项目名称,设备名称,供方名称,型号,名称,单位,实际采购数量,合同号,发起到货验收数量,本次数量 from  tb_caigouliaodan where (id ='" + dingwei + "'and 到货验收流程状态 IS NULL) or (id ='" + dingwei + "'and 到货验收流程状态='8完成'and 实际采购数量!=发起到货验收数量)";
                dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                zongbiao.Merge(dt, true, MissingSchemaAction.Ignore);
            }

            Frwujindaohuo form1 = new Frwujindaohuo();
            form1.dt = zongbiao;

            form1.yonghu = yonghu;
            form1.ShowDialog();
        }

        private void buttonItem8_Click(object sender, EventArgs e)
        {
            int[] a = gridView1.GetSelectedRows();
            foreach (int i in a)
            {
                string id = gridView1.GetRowCellValue(i, "id").ToString();
                qingdan1 += id + "|";
            }

            if (qingdan1 == "")
            {
                MessageBox.Show("没有选中，请选中！");
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



            string[] strArray = qingdan1.Split('|'); //字符串转数组
            List<string> list = new List<string>();

            for (int i = 0; i < strArray.Length; i++)//遍历数组成员
            {
                if (list.IndexOf(strArray[i].ToLower()) == -1)//对每个成员做一次新数组查询如果没有相等的则加到新数组
                    list.Add(strArray[i]);
            }

            for (int i = 0; i < list.Count; i++)
            {
                string dingwei = list[i];
                
                string sql1 = "select id,工作令号,项目名称,设备名称,供方名称,型号,名称,单位,实际采购数量,合同号,发起到货验收数量,本次数量 from  tb_caigouliaodan where (id ='" + dingwei + "'and 到货验收流程状态 IS NULL) or (id ='" + dingwei + "'and 到货验收流程状态='8完成' and 实际采购数量!=发起到货验收数量) ";
                dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                zongbiao.Merge(dt, true, MissingSchemaAction.Ignore);
            }

            Frdaohuogouwuche form1 = new Frdaohuogouwuche();
            form1.dt = zongbiao;

            form1.yonghu = yonghu;
            form1.ShowDialog();
        }
    }
}