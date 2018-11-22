using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.仓库
{
    public partial class Frfapiaopipei : Form
    {
        public Frfapiaopipei()
        {
            InitializeComponent();
        }
        public string yonghu;
        public DataTable zongbiao1;
        private void buttonItem1_Click(object sender, EventArgs e)
        {
            if (txthetonghao.Text.Trim() == "")
            {
                MessageBox.Show("请填写合同号！");
                return;
            }
            zongbiao1 = new DataTable();
            zongbiao1.Columns.Add("id");
            zongbiao1.Columns.Add("工作令号");
            zongbiao1.Columns.Add("项目名称");
            zongbiao1.Columns.Add("设备名称");
            zongbiao1.Columns.Add("编码");
            zongbiao1.Columns.Add("名称");
            zongbiao1.Columns.Add("型号");
            zongbiao1.Columns.Add("单位");
            zongbiao1.Columns.Add("供方名称");
            zongbiao1.Columns.Add("合同号");
            zongbiao1.Columns.Add("发票号");
            zongbiao1.Columns.Add("实际采购数量");
            zongbiao1.Columns.Add("实际到货数量");
            zongbiao1.Columns.Add("采购单价");
            zongbiao1.Columns.Add("应开票数量");
            zongbiao1.Columns.Add("已开票数量");
            zongbiao1.Columns.Add("净单价");
            zongbiao1.Columns.Add("净税额");
            zongbiao1.Columns.Add("税率");
            zongbiao1.Columns.Add("净额");
            zongbiao1.Columns.Add("总价");
            string[] shuzu = txthetonghao.Text.Split(';');


            foreach (string i in shuzu)
            {
                string sql1 = "select id,工作令号,项目名称,设备名称,编码,型号,名称,单位,实际采购数量,实际到货数量,供方名称,合同号,采购单价,发票号,总价,净税额,税率,应开票数量,已开票数量,净额,净单价 from  tb_caigouliaodan  where 合同号='" + i + "'";
                zongbiao1.Merge(SQLhelp.GetDataTable(sql1, CommandType.Text), true, MissingSchemaAction.Ignore);
            }
            for (int i = 0; i < zongbiao1.Rows.Count; i++)
            {
                string id = zongbiao1.Rows[i]["id"].ToString();
                string shijidaohuoshuliang = zongbiao1.Rows[i]["实际到货数量"].ToString();
                string yikaipiaoshulaing = zongbiao1.Rows[i]["已开票数量"].ToString();
                if (yikaipiaoshulaing == "")
                {
                    zongbiao1.Rows[i]["应开票数量"] = shijidaohuoshuliang;
                }

                if (yikaipiaoshulaing != "")
                {
                    zongbiao1.Rows[i]["应开票数量"] = Convert.ToDouble(shijidaohuoshuliang) - Convert.ToDouble(yikaipiaoshulaing);
                }

                string sql = "update tb_caigouliaodan set 应开票数量='" + zongbiao1.Rows[i]["应开票数量"].ToString() + "' where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);
            }

            gridControl1.DataSource = zongbiao1;
            gridView1.Columns["id"].Visible = false;
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {

        }
        static double panduan(string a)
        {
            double b = 0;
            if (a == "")
            {
                b = 0;

            }
            if (a != "")
            {
                b = Convert.ToDouble(a);

            }
            return b;

        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int[] a = gridView1.GetSelectedRows();
            if (txtfapiaohao.Text == "")
            {
                MessageBox.Show("请输入发票号！");
                return;
            }
            if (txtgongyinghshang.Text == "")
            {
                MessageBox.Show("请输入供应商！");
                return;
            }
            if (txthetonghao.Text == "")
            {
                MessageBox.Show("请输入合同号！");
                return;
            }
            if (txtkuweihao.Text == "")
            {
                MessageBox.Show("请输入库位号！");
                return;
            }
            if (radioButton17.Checked == false && radioButton16.Checked == false && radioButton3.Checked == false && radioButton0.Checked == false)
            {
                MessageBox.Show("请输入税率！");
                return;
            }
            string liushuihao = DateTime.Now.ToString("yyyyMMddHHmmss");
            foreach (int n in a)
            {
                string danjia = Convert.ToString(gridView1.GetRowCellValue(n, "净额"));
                if (danjia == "")
                {
                    MessageBox.Show("请先计算后再匹配！");
                    return;
                }
            }
            foreach (int i in a)
            {

                string danjia = Convert.ToString(gridView1.GetRowCellValue(i, "采购单价"));
                string id = Convert.ToString(gridView1.GetRowCellValue(i, "id"));

                if (danjia != "")
                {
                    if (radioButton17.Checked == true)
                    {
                        string shijikaipiao = Convert.ToString(gridView1.GetRowCellValue(i, "已开票数量"));
                        string yiingkaipiao = Convert.ToString(gridView1.GetRowCellValue(i, "应开票数量"));
                        double shuliang = Convert.ToDouble(gridView1.GetRowCellValue(i, "应开票数量"));
                        double shengyu = Convert.ToDouble(gridView1.GetRowCellValue(i, "实际采购数量")) - Convert.ToDouble(gridView1.GetRowCellValue(i, "应开票数量"));
                        double zongjia = Convert.ToDouble(gridView1.GetRowCellValue(i, "总价"));
                        double jinge = Convert.ToDouble(gridView1.GetRowCellValue(i, "净额"));
                        double shuie = Convert.ToDouble(gridView1.GetRowCellValue(i, "净税额"));
                        double jingdanjia = Convert.ToDouble(gridView1.GetRowCellValue(i, "净单价"));
                        string sql = "Select * from tb_caigouliaodan where id='" + id + "'";
                        DataTable chaxun = SQLhelp.GetDataTable(sql, CommandType.Text);
                        double zongjia1;
                        double jingshuie1;
                        double jinge1;

                        zongjia1 = zongjia + panduan(chaxun.Rows[0]["总价"].ToString());
                        jingshuie1 = shuie + panduan(chaxun.Rows[0]["净税额"].ToString());
                        jinge1 = jinge + panduan(chaxun.Rows[0]["净额"].ToString());
                        string fapiaohao11 = Convert.ToString(chaxun.Rows[0]["发票号"]);
                        string fapiaohao1 = "";
                        if (fapiaohao11.Trim() == "")
                        {
                            fapiaohao1 = Convert.ToString(chaxun.Rows[0]["发票号"]) + txtfapiaohao.Text;

                        }
                        if (fapiaohao11.Trim() != "")
                        {
                            fapiaohao1 = Convert.ToString(chaxun.Rows[0]["发票号"]) + ";" + txtfapiaohao.Text;

                        }

                        string sql111 = "update tb_caigouliaodan set 采购单价='" + danjia + "',总价='" + zongjia1 + "',发票号= '" + fapiaohao1 + "',税率='17%',净税额='" + jingshuie1 + "',净额='" + jinge1 + "',已开票数量='" + shuliang + "',应开票数量='" + shengyu + "',净单价='" + jingdanjia + "',收到发票日期='" + DateTime.Now + "',发票匹配=1  where id='" + id + "'";
                        SQLhelp.ExecuteScalar(sql111, CommandType.Text);

                        string sql123123 = "select * from tb_caigouliaodan where id='" + id + "'";
                        DataTable dtt = SQLhelp.GetDataTable(sql123123, CommandType.Text);

                        string sql12 = "insert into tb_fapiao (工作令号,项目名称,设备名称,合同号,编码,型号,名称,单位,制造类型,实际采购数量,开票数量,开票时间,开票人,定位,采购单价,总价,净额,税率,发票号,供方名称,净单价,库位号,流水号,供方代号,开票供方,开票供方代号,发票日期) values ('" + dtt.Rows[0]["工作令号"].ToString() + "','" + dtt.Rows[0]["项目名称"].ToString() + "','" + dtt.Rows[0]["设备名称"].ToString() + "','" + dtt.Rows[0]["合同号"].ToString() + "','" + dtt.Rows[0]["编码"].ToString() + "','" + dtt.Rows[0]["型号"].ToString() + "','" + dtt.Rows[0]["名称"].ToString() + "','" + dtt.Rows[0]["单位"].ToString() + "','" + dtt.Rows[0]["制造类型"].ToString() + "','" + dtt.Rows[0]["实际采购数量"].ToString() + "','" + yiingkaipiao + "','" + DateTime.Now + "','" + yonghu + "','" + id + "','" + danjia + "','" + zongjia + "','" + jinge + "','17%','" + txtfapiaohao.Text + "','" + dtt.Rows[0]["供方名称"].ToString() + "','" + dtt.Rows[0]["净单价"].ToString() + "','" + txtkuweihao.Text.Trim() + "','" + liushuihao + "','" + comgongyingshang.Text + "','" + txtgongyinghshang.Text + "','" + comgongyingshang2.Text + "','" + datekaipiao.Text + "')";
                        SQLhelp.ExecuteScalar(sql12, CommandType.Text);



                        //入库
                        string sqlruku = "select id,入库数量 from tb_ruku where 定位='" + id + "'";
                        DataTable ruku = SQLhelp.GetDataTable(sqlruku, CommandType.Text);
                        for (int j = 0; j < ruku.Rows.Count; j++)
                        {
                            string dingwei = ruku.Rows[j]["id"].ToString();
                            decimal zongjia2 = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(ruku.Rows[j]["入库数量"]) * Convert.ToDouble(danjia))), 2);
                            decimal jinge2 = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(zongjia2) / 1.17)), 2);
                            decimal shuie2 = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(zongjia2) - Convert.ToDouble(jinge2))), 2);


                            string sql123 = "update tb_ruku set 采购单价='" + danjia + "',总价='" + zongjia2 + "',发票号='" + fapiaohao1 + "',净额='" + jinge2 + "',税额='" + shuie2 + "',税率='17%',净单价='" + jingdanjia + "',发票匹配='1' where id='" + dingwei + "'";
                            SQLhelp.ExecuteScalar(sql123, CommandType.Text);
                        }

                        //出库
                        string sqlchuku = "select id,出库数量 from tb_chuku where 定位='" + id + "'";
                        DataTable chuku = SQLhelp.GetDataTable(sqlchuku, CommandType.Text);
                        for (int j = 0; j < chuku.Rows.Count; j++)
                        {
                            string dingwei = chuku.Rows[j]["id"].ToString();
                            decimal zongjia2 = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(chuku.Rows[j]["出库数量"]) * Convert.ToDouble(danjia))), 2);
                            decimal jinge2 = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(zongjia2) / 1.17)), 2);
                            decimal shuie2 = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(zongjia2) - Convert.ToDouble(jinge2))), 2);

                            string sql1234 = "update tb_chuku set 采购单价='" + danjia + "',总价='" + zongjia2 + "',发票号='" + fapiaohao1 + "',净额='" + jinge2 + "',税额='" + shuie2 + "',税率='17%',净单价='" + jingdanjia + "',发票匹配='1' where id='" + dingwei + "'";
                            SQLhelp.ExecuteScalar(sql1234, CommandType.Text);

                        }
                    }


                    if (radioButton16.Checked == true)
                    {
                        string shijikaipiao = Convert.ToString(gridView1.GetRowCellValue(i, "已开票数量"));
                        string yiingkaipiao = Convert.ToString(gridView1.GetRowCellValue(i, "应开票数量"));
                        double shuliang = Convert.ToDouble(gridView1.GetRowCellValue(i, "应开票数量"));
                        double shengyu = Convert.ToDouble(gridView1.GetRowCellValue(i, "实际采购数量")) - Convert.ToDouble(gridView1.GetRowCellValue(i, "应开票数量"));
                        double zongjia = Convert.ToDouble(gridView1.GetRowCellValue(i, "总价"));
                        double jinge = Convert.ToDouble(gridView1.GetRowCellValue(i, "净额"));
                        double shuie = Convert.ToDouble(gridView1.GetRowCellValue(i, "净税额"));
                        double jingdanjia = Convert.ToDouble(gridView1.GetRowCellValue(i, "净单价"));
                        string sql = "Select * from tb_caigouliaodan where id='" + id + "'";
                        DataTable chaxun = SQLhelp.GetDataTable(sql, CommandType.Text);
                        double zongjia1;
                        double jingshuie1;
                        double jinge1;

                        zongjia1 = zongjia + panduan(chaxun.Rows[0]["总价"].ToString());
                        jingshuie1 = shuie + panduan(chaxun.Rows[0]["净税额"].ToString());
                        jinge1 = jinge + panduan(chaxun.Rows[0]["净额"].ToString());
                        string fapiaohao11 = Convert.ToString(chaxun.Rows[0]["发票号"]);
                        string fapiaohao1 = "";
                        if (fapiaohao11.Trim() == "")
                        {
                            fapiaohao1 = Convert.ToString(chaxun.Rows[0]["发票号"]) + txtfapiaohao.Text;

                        }
                        if (fapiaohao11.Trim() != "")
                        {
                            fapiaohao1 = Convert.ToString(chaxun.Rows[0]["发票号"]) + ";" + txtfapiaohao.Text;

                        }

                        string sql111 = "update tb_caigouliaodan set 采购单价='" + danjia + "',总价='" + zongjia1 + "',发票号= '" + fapiaohao1 + "',税率='16%',净税额='" + jingshuie1 + "',净额='" + jinge1 + "',已开票数量='" + shuliang + "',应开票数量='" + shengyu + "',净单价='" + jingdanjia + "',收到发票日期='" + DateTime.Now + "',发票匹配='1'  where id='" + id + "'";
                        SQLhelp.ExecuteScalar(sql111, CommandType.Text);
                        string sql123123 = "select * from tb_caigouliaodan where id='" + id + "'";
                        DataTable dtt = SQLhelp.GetDataTable(sql123123, CommandType.Text);

                        string sql12 = "insert into tb_fapiao (工作令号,项目名称,设备名称,合同号,编码,型号,名称,单位,制造类型,实际采购数量,开票数量,开票时间,开票人,定位,采购单价,总价,净额,税率,发票号,供方名称,净单价,库位号,流水号,供方代号,开票供方,开票供方代号,发票日期) values ('" + dtt.Rows[0]["工作令号"].ToString() + "','" + dtt.Rows[0]["项目名称"].ToString() + "','" + dtt.Rows[0]["设备名称"].ToString() + "','" + dtt.Rows[0]["合同号"].ToString() + "','" + dtt.Rows[0]["编码"].ToString() + "','" + dtt.Rows[0]["型号"].ToString() + "','" + dtt.Rows[0]["名称"].ToString() + "','" + dtt.Rows[0]["单位"].ToString() + "','" + dtt.Rows[0]["制造类型"].ToString() + "','" + dtt.Rows[0]["实际采购数量"].ToString() + "','" + yiingkaipiao + "','" + DateTime.Now + "','" + yonghu + "','" + id + "','" + danjia + "','" + zongjia + "','" + jinge + "','16%','" + txtfapiaohao.Text + "','" + dtt.Rows[0]["供方名称"].ToString() + "','" + dtt.Rows[0]["净单价"].ToString() + "','" + txtkuweihao.Text.Trim() + "','" + liushuihao + "','" + comgongyingshang.Text + "','" + txtgongyinghshang.Text + "','" + comgongyingshang2.Text + "','" + datekaipiao.Text + "')";
                        SQLhelp.ExecuteScalar(sql12, CommandType.Text);


                        //入库
                        string sqlruku = "select id,入库数量 from tb_ruku where 定位='" + id + "'";
                        DataTable ruku = SQLhelp.GetDataTable(sqlruku, CommandType.Text);
                        for (int j = 0; j < ruku.Rows.Count; j++)
                        {
                            string dingwei = ruku.Rows[j]["id"].ToString();
                            decimal zongjia2 = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(ruku.Rows[j]["入库数量"]) * Convert.ToDouble(danjia))), 2);
                            decimal jinge2 = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(zongjia2) / 1.16)), 2);
                            decimal shuie2 = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(zongjia2) - Convert.ToDouble(jinge2))), 2);


                            string sql123 = "update tb_ruku set 采购单价='" + danjia + "',总价='" + zongjia2 + "',发票号='" + fapiaohao1 + "',净额='" + jinge2 + "',税额='" + shuie2 + "',税率='16%',净单价='" + jingdanjia + "',发票匹配='1' where id='" + dingwei + "'";
                            SQLhelp.ExecuteScalar(sql123, CommandType.Text);
                        }

                        //出库
                        string sqlchuku = "select id,出库数量 from tb_chuku where 定位='" + id + "'";
                        DataTable chuku = SQLhelp.GetDataTable(sqlchuku, CommandType.Text);
                        for (int j = 0; j < chuku.Rows.Count; j++)
                        {
                            string dingwei = chuku.Rows[j]["id"].ToString();
                            decimal zongjia2 = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(chuku.Rows[j]["出库数量"]) * Convert.ToDouble(danjia))), 2);
                            decimal jinge2 = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(zongjia2) / 1.16)), 2);
                            decimal shuie2 = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(zongjia2) - Convert.ToDouble(jinge2))), 2);

                            string sql1234 = "update tb_chuku set 采购单价='" + danjia + "',总价='" + zongjia2 + "',发票号='" + fapiaohao1 + "',净额='" + jinge2 + "',税额='" + shuie2 + "',税率='16%',净单价='" + jingdanjia + "',发票匹配='1' where id='" + dingwei + "'";
                            SQLhelp.ExecuteScalar(sql1234, CommandType.Text);

                        }

                    }
                    if (radioButton3.Checked == true)
                    {
                        string shijikaipiao = Convert.ToString(gridView1.GetRowCellValue(i, "已开票数量"));
                        string yiingkaipiao = Convert.ToString(gridView1.GetRowCellValue(i, "应开票数量"));
                        double shuliang = Convert.ToDouble(gridView1.GetRowCellValue(i, "应开票数量"));
                        double shengyu = Convert.ToDouble(gridView1.GetRowCellValue(i, "实际采购数量")) - Convert.ToDouble(gridView1.GetRowCellValue(i, "应开票数量"));
                        double zongjia = Convert.ToDouble(gridView1.GetRowCellValue(i, "总价"));
                        double jinge = Convert.ToDouble(gridView1.GetRowCellValue(i, "净额"));
                        double shuie = Convert.ToDouble(gridView1.GetRowCellValue(i, "净税额"));
                        double jingdanjia = Convert.ToDouble(gridView1.GetRowCellValue(i, "净单价"));
                        string sql = "Select * from tb_caigouliaodan where id='" + id + "'";
                        DataTable chaxun = SQLhelp.GetDataTable(sql, CommandType.Text);
                        double zongjia1;
                        double jingshuie1;
                        double jinge1;

                        zongjia1 = zongjia + panduan(chaxun.Rows[0]["总价"].ToString());
                        jingshuie1 = shuie + panduan(chaxun.Rows[0]["净税额"].ToString());
                        jinge1 = jinge + panduan(chaxun.Rows[0]["净额"].ToString());
                        string fapiaohao11 = Convert.ToString(chaxun.Rows[0]["发票号"]);
                        string fapiaohao1 = "";
                        if (fapiaohao11.Trim() == "")
                        {
                            fapiaohao1 = Convert.ToString(chaxun.Rows[0]["发票号"]) + txtfapiaohao.Text;

                        }
                        if (fapiaohao11.Trim() != "")
                        {
                            fapiaohao1 = Convert.ToString(chaxun.Rows[0]["发票号"]) + ";" + txtfapiaohao.Text;

                        }

                        string sql111 = "update tb_caigouliaodan set 采购单价='" + danjia + "',总价='" + zongjia1 + "',发票号= '" + fapiaohao1 + "',税率='3%',净税额='" + jingshuie1 + "',净额='" + jinge1 + "',已开票数量='" + shuliang + "',应开票数量='" + shengyu + "',净单价='" + jingdanjia + "',收到发票日期='" + DateTime.Now + "',发票匹配='1'  where id='" + id + "'";
                        SQLhelp.ExecuteScalar(sql111, CommandType.Text);


                        string sql123123 = "select * from tb_caigouliaodan where id='" + id + "'";
                        DataTable dtt = SQLhelp.GetDataTable(sql123123, CommandType.Text);

                        string sql12 = "insert into tb_fapiao (工作令号,项目名称,设备名称,合同号,编码,型号,名称,单位,制造类型,实际采购数量,开票数量,开票时间,开票人,定位,采购单价,总价,净额,税率,发票号,供方名称,净单价,库位号,流水号,供方代号,开票供方,开票供方代号,发票日期) values ('" + dtt.Rows[0]["工作令号"].ToString() + "','" + dtt.Rows[0]["项目名称"].ToString() + "','" + dtt.Rows[0]["设备名称"].ToString() + "','" + dtt.Rows[0]["合同号"].ToString() + "','" + dtt.Rows[0]["编码"].ToString() + "','" + dtt.Rows[0]["型号"].ToString() + "','" + dtt.Rows[0]["名称"].ToString() + "','" + dtt.Rows[0]["单位"].ToString() + "','" + dtt.Rows[0]["制造类型"].ToString() + "','" + dtt.Rows[0]["实际采购数量"].ToString() + "','" + yiingkaipiao + "','" + DateTime.Now + "','" + yonghu + "','" + id + "','" + danjia + "','" + zongjia + "','" + jinge + "','3%','" + txtfapiaohao.Text + "','" + dtt.Rows[0]["供方名称"].ToString() + "','" + dtt.Rows[0]["净单价"].ToString() + "','" + txtkuweihao.Text.Trim() + "','" + liushuihao + "','" + comgongyingshang.Text + "','" + txtgongyinghshang.Text + "','" + comgongyingshang2.Text + "','" + datekaipiao.Text + "')";
                        SQLhelp.ExecuteScalar(sql12, CommandType.Text);

                        //入库
                        string sqlruku = "select id,入库数量 from tb_ruku where 定位='" + id + "'";
                        DataTable ruku = SQLhelp.GetDataTable(sqlruku, CommandType.Text);
                        for (int j = 0; j < ruku.Rows.Count; j++)
                        {
                            string dingwei = ruku.Rows[j]["id"].ToString();
                            decimal zongjia2 = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(ruku.Rows[j]["入库数量"]) * Convert.ToDouble(danjia))), 2);
                            decimal jinge2 = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(zongjia2) / 1.03)), 2);
                            decimal shuie2 = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(zongjia2) - Convert.ToDouble(jinge2))), 2);


                            string sql123 = "update tb_ruku set 采购单价='" + danjia + "',总价='" + zongjia2 + "',发票号='" + fapiaohao1 + "',净额='" + jinge2 + "',税额='" + shuie2 + "',税率='3%',净单价='" + jingdanjia + "',发票匹配='1' where id='" + dingwei + "'";
                            SQLhelp.ExecuteScalar(sql123, CommandType.Text);
                        }

                        //出库
                        string sqlchuku = "select id,出库数量 from tb_chuku where 定位='" + id + "'";
                        DataTable chuku = SQLhelp.GetDataTable(sqlchuku, CommandType.Text);
                        for (int j = 0; j < chuku.Rows.Count; j++)
                        {
                            string dingwei = chuku.Rows[j]["id"].ToString();
                            decimal zongjia2 = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(chuku.Rows[j]["出库数量"]) * Convert.ToDouble(danjia))), 2);
                            decimal jinge2 = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(zongjia2) / 1.03)), 2);
                            decimal shuie2 = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(zongjia2) - Convert.ToDouble(jinge2))), 2);

                            string sql1234 = "update tb_chuku set 采购单价='" + danjia + "',总价='" + zongjia2 + "',发票号='" + fapiaohao1 + "',净额='" + jinge2 + "',税额='" + shuie2 + "',税率='3%',净单价='" + jingdanjia + "',发票匹配='1' where id='" + dingwei + "'";
                            SQLhelp.ExecuteScalar(sql1234, CommandType.Text);

                        }

                    }
                    if (radioButton0.Checked == true)
                    {
                        string shijikaipiao = Convert.ToString(gridView1.GetRowCellValue(i, "已开票数量"));
                        string yiingkaipiao = Convert.ToString(gridView1.GetRowCellValue(i, "应开票数量"));
                        double shuliang = Convert.ToDouble(gridView1.GetRowCellValue(i, "应开票数量"));
                        double shengyu = Convert.ToDouble(gridView1.GetRowCellValue(i, "实际采购数量")) - Convert.ToDouble(gridView1.GetRowCellValue(i, "应开票数量"));
                        double zongjia = Convert.ToDouble(gridView1.GetRowCellValue(i, "总价"));
                        double jinge = Convert.ToDouble(gridView1.GetRowCellValue(i, "净额"));
                        double shuie = Convert.ToDouble(gridView1.GetRowCellValue(i, "净税额"));
                        double jingdanjia = Convert.ToDouble(gridView1.GetRowCellValue(i, "净单价"));
                        string sql = "Select * from tb_caigouliaodan where id='" + id + "'";
                        DataTable chaxun = SQLhelp.GetDataTable(sql, CommandType.Text);
                        double zongjia1;
                        double jingshuie1;
                        double jinge1;

                        zongjia1 = zongjia + panduan(chaxun.Rows[0]["总价"].ToString());
                        jingshuie1 = shuie + panduan(chaxun.Rows[0]["净税额"].ToString());
                        jinge1 = jinge + panduan(chaxun.Rows[0]["净额"].ToString());
                        string fapiaohao11 = Convert.ToString(chaxun.Rows[0]["发票号"]);
                        string fapiaohao1 = "";
                        if (fapiaohao11.Trim() == "")
                        {
                            fapiaohao1 = Convert.ToString(chaxun.Rows[0]["发票号"]) + txtfapiaohao.Text;

                        }
                        if (fapiaohao11.Trim() != "")
                        {
                            fapiaohao1 = Convert.ToString(chaxun.Rows[0]["发票号"]) + ";" + txtfapiaohao.Text;

                        }

                        string sql111 = "update tb_caigouliaodan set 采购单价='" + danjia + "',总价='" + zongjia1 + "',发票号= '" + fapiaohao1 + "',税率='0%',净税额='" + jingshuie1 + "',净额='" + jinge1 + "',已开票数量='" + shuliang + "',应开票数量='" + shengyu + "',净单价='" + jingdanjia + "' ,收到发票日期='" + DateTime.Now + "',发票匹配='1' where id='" + id + "'";
                        SQLhelp.ExecuteScalar(sql111, CommandType.Text);

                        string sql123123 = "select * from tb_caigouliaodan where id='" + id + "'";
                        DataTable dtt = SQLhelp.GetDataTable(sql123123, CommandType.Text);

                        string sql12 = "insert into tb_fapiao (工作令号,项目名称,设备名称,合同号,编码,型号,名称,单位,制造类型,实际采购数量,开票数量,开票时间,开票人,定位,采购单价,总价,净额,税率,发票号,供方名称,净单价,库位号,流水号,供方代号,开票供方,开票供方代号,发票日期) values ('" + dtt.Rows[0]["工作令号"].ToString() + "','" + dtt.Rows[0]["项目名称"].ToString() + "','" + dtt.Rows[0]["设备名称"].ToString() + "','" + dtt.Rows[0]["合同号"].ToString() + "','" + dtt.Rows[0]["编码"].ToString() + "','" + dtt.Rows[0]["型号"].ToString() + "','" + dtt.Rows[0]["名称"].ToString() + "','" + dtt.Rows[0]["单位"].ToString() + "','" + dtt.Rows[0]["制造类型"].ToString() + "','" + dtt.Rows[0]["实际采购数量"].ToString() + "','" + yiingkaipiao + "','" + DateTime.Now + "','" + yonghu + "','" + id + "','" + danjia + "','" + zongjia + "','" + jinge + "','0%','" + txtfapiaohao.Text + "','" + dtt.Rows[0]["供方名称"].ToString() + "','" + dtt.Rows[0]["净单价"].ToString() + "','" + txtkuweihao.Text.Trim() + "','" + liushuihao + "','" + comgongyingshang.Text + "','" + txtgongyinghshang.Text + "','" + comgongyingshang2.Text + "','" + datekaipiao.Text + "')";
                        SQLhelp.ExecuteScalar(sql12, CommandType.Text);


                        //入库
                        string sqlruku = "select id,入库数量 from tb_ruku where 定位='" + id + "'";
                        DataTable ruku = SQLhelp.GetDataTable(sqlruku, CommandType.Text);
                        for (int j = 0; j < ruku.Rows.Count; j++)
                        {
                            string dingwei = ruku.Rows[j]["id"].ToString();
                            decimal zongjia2 = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(ruku.Rows[j]["入库数量"]) * Convert.ToDouble(danjia))), 2);
                            decimal jinge2 = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(zongjia2))), 2);
                            decimal shuie2 = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(zongjia2) - Convert.ToDouble(jinge2))), 2);


                            string sql123 = "update tb_ruku set 采购单价='" + danjia + "',总价='" + zongjia2 + "',发票号='" + fapiaohao1 + "',净额='" + jinge2 + "',税额='" + shuie2 + "',税率='0%',净单价='" + jingdanjia + "',发票匹配='1' where id='" + dingwei + "'";
                            SQLhelp.ExecuteScalar(sql123, CommandType.Text);
                        }

                        //出库
                        string sqlchuku = "select id,出库数量 from tb_chuku where 定位='" + id + "'";
                        DataTable chuku = SQLhelp.GetDataTable(sqlchuku, CommandType.Text);
                        for (int j = 0; j < chuku.Rows.Count; j++)
                        {
                            string dingwei = chuku.Rows[j]["id"].ToString();
                            decimal zongjia2 = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(chuku.Rows[j]["出库数量"]) * Convert.ToDouble(danjia))), 2);
                            decimal jinge2 = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(zongjia2))), 2);
                            decimal shuie2 = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(zongjia2) - Convert.ToDouble(jinge2))), 2);

                            string sql1234 = "update tb_chuku set 采购单价='" + danjia + "',总价='" + zongjia2 + "',发票号='" + fapiaohao1 + "',净额='" + jinge2 + "',税额='" + shuie2 + "',税率='0%',净单价='" + jingdanjia + "',发票匹配='1' where id='" + dingwei + "'";
                            SQLhelp.ExecuteScalar(sql1234, CommandType.Text);
                        }

                    }
                }

            }

            DataTable zongbiao1 = new DataTable();
            zongbiao1.Columns.Add("id");
            zongbiao1.Columns.Add("工作令号");
            zongbiao1.Columns.Add("项目名称");
            zongbiao1.Columns.Add("设备名称");
            zongbiao1.Columns.Add("编码");
            zongbiao1.Columns.Add("名称");
            zongbiao1.Columns.Add("型号");
            zongbiao1.Columns.Add("单位");
            zongbiao1.Columns.Add("供方名称");
            zongbiao1.Columns.Add("合同号");
            zongbiao1.Columns.Add("发票号");
            zongbiao1.Columns.Add("实际采购数量");
            zongbiao1.Columns.Add("实际到货数量");
            zongbiao1.Columns.Add("采购单价");
            zongbiao1.Columns.Add("应开票数量");
            zongbiao1.Columns.Add("已开票数量");
            zongbiao1.Columns.Add("净单价");
            zongbiao1.Columns.Add("净税额");
            zongbiao1.Columns.Add("税率");
            zongbiao1.Columns.Add("净额");
            zongbiao1.Columns.Add("总价");
            string[] shuzu = txthetonghao.Text.Split(';');
            foreach (string i in shuzu)
            {
                string sql1 = "select id,工作令号,项目名称,设备名称,编码,型号,名称,单位,实际采购数量,实际到货数量,供方名称,合同号,采购单价,发票号,总价,净税额,税率,应开票数量,已开票数量,净额,净单价 from  tb_caigouliaodan  where 合同号='" + i + "' and 实际到货数量 is not null";
                zongbiao1.Merge(SQLhelp.GetDataTable(sql1, CommandType.Text), true, MissingSchemaAction.Ignore);
            }
            gridControl1.DataSource = zongbiao1;
            gridView1.Columns["id"].Visible = false;

            string gongyingshang = txtgongyinghshang.Text;
            Workbook workbook = new Workbook(System.Environment.CurrentDirectory + "\\" + "收料报告单模板.xls");
            Worksheet worksheet = workbook.Worksheets["Sheet1"];
            worksheet.Cells["B3"].PutValue(txtkuweihao.Text);
            worksheet.Cells["D3"].PutValue(liushuihao);
            worksheet.Cells["G3"].PutValue(txthetonghao.Text);
            worksheet.Cells["B4"].PutValue(gongyingshang);
            worksheet.Cells["D4"].PutValue(txtfapiaohao.Text);
            worksheet.Cells["G4"].PutValue(datekaipiao.Text);


            int b = a.Length;
            if (b <= 3)
            {
                string ab = "";
                string bb = "";
                string c = "";
                foreach (int i in a)
                {
                    if (ab == "" && bb == "" && c == "")
                    {
                        ab = i.ToString();
                        continue;
                    }
                    if (ab != "" && bb == "" && c == "")
                    {
                        bb = i.ToString();
                        continue;
                    }
                    if (ab != "" && bb != "" && c == "")
                    {
                        c = i.ToString();
                        continue;
                    }
                }
                foreach (int i in a)
                {
                    if (ab == i.ToString())
                    {
                        worksheet.Cells["A6"].PutValue(Convert.ToString(gridView1.GetRowCellValue(i, "名称")));
                        worksheet.Cells["B6"].PutValue(Convert.ToString(gridView1.GetRowCellValue(i, "型号")));
                        worksheet.Cells["D6"].PutValue(Convert.ToString(gridView1.GetRowCellValue(i, "单位")));
                        worksheet.Cells["E6"].PutValue(Convert.ToString(gridView1.GetRowCellValue(i, "应开票数量")));
                        worksheet.Cells["F6"].PutValue(Convert.ToString(gridView1.GetRowCellValue(i, "净额")));
                    }
                    if (bb == i.ToString())
                    {
                        worksheet.Cells["A7"].PutValue(Convert.ToString(gridView1.GetRowCellValue(i, "名称")));
                        worksheet.Cells["B7"].PutValue(Convert.ToString(gridView1.GetRowCellValue(i, "型号")));
                        worksheet.Cells["D7"].PutValue(Convert.ToString(gridView1.GetRowCellValue(i, "单位")));
                        worksheet.Cells["E7"].PutValue(Convert.ToString(gridView1.GetRowCellValue(i, "应开票数量")));
                        worksheet.Cells["F7"].PutValue(Convert.ToString(gridView1.GetRowCellValue(i, "净额")));
                    }
                    if (c == i.ToString())
                    {
                        worksheet.Cells["A8"].PutValue(Convert.ToString(gridView1.GetRowCellValue(i, "名称")));
                        worksheet.Cells["B8"].PutValue(Convert.ToString(gridView1.GetRowCellValue(i, "型号")));
                        worksheet.Cells["D8"].PutValue(Convert.ToString(gridView1.GetRowCellValue(i, "单位")));
                        worksheet.Cells["E8"].PutValue(Convert.ToString(gridView1.GetRowCellValue(i, "应开票数量")));
                        worksheet.Cells["F8"].PutValue(Convert.ToString(gridView1.GetRowCellValue(i, "净额")));
                    }
                }
            }
            if (b > 3)
            {
                double zonge = 0;

                foreach (int i in a)
                {
                    zonge += Convert.ToDouble(gridView1.GetRowCellValue(i, "净额"));
                }
                worksheet.Cells["E6"].PutValue("1");
                worksheet.Cells["F6"].PutValue(zonge);
            }

            Random rd = new Random();
            string suijishu = rd.Next(10, 10000).ToString();
            string mingcheng = "收料报告单" + suijishu;
            workbook.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + mingcheng + ".xls");
            MessageBox.Show("匹配成功,自动生成收料报告单并保存到桌面！");
            System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + mingcheng + ".xls");
            this.Close();
        }

        private void Frfapiaopipei_Load(object sender, EventArgs e)
        {
            radioButton17.Checked = true;
            Reload();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (!txtgongyinghshang.Text.Contains("\r\n"))
            {

                listBox1.Items.Clear();//先清空一下这个控件的值.  不然就会造成文本框里不输时,这里面全部都是值

                string sql = "select 单位名称 from tb_gongfang ";
                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                int b = txtgongyinghshang.Text.LastIndexOf(";");

                if (b != -1)
                {
                    string jiequ = txtgongyinghshang.Text.Substring(b + 1);


                    DataRow[] drr = dt.Select("单位名称 like'%" + jiequ + "%'");
                    DataTable newdtt = new DataTable(); //再新创建一个表,
                    newdtt = dt.Clone();//复制dt表的所有结构

                    foreach (DataRow row in drr)
                    {
                        newdtt.Rows.Add(row.ItemArray);
                    }//这一句,可以改成用for循环替代,  循环内就用 newdt.ImportRow(dr[i]);



                    if (dt.Rows.Count > 0 && (jiequ != ""))//如果这个DS表里的行数总数,大于零,并且文本框不为空,就运行以下代码
                    {
                        listBox1.Visible = true;      //listBox2显示出来  
                        for (int i = 0; i < newdtt.Rows.Count; i++)//循环所有行数
                        {
                            listBox1.Items.Add(newdtt.Rows[i]["用户名"].ToString());//每行的名称值给listBox2
                        }
                    }

                }

                DataRow[] dr = dt.Select("单位名称 like'%" + txtgongyinghshang.Text + "%'");
                DataTable newdt = new DataTable(); //再新创建一个表,
                newdt = dt.Clone();//复制dt表的所有结构

                foreach (DataRow row in dr)
                {
                    newdt.Rows.Add(row.ItemArray);
                }

                if (newdt.Rows.Count > 0 && (txtgongyinghshang.Text != ""))
                {
                    listBox1.Visible = true;
                    for (int i = 0; i < newdt.Rows.Count; i++)
                    {
                        listBox1.Items.Add(newdt.Rows[i]["单位名称"].ToString());//
                    }
                }

                if (listBox1.Items.Count > 0)
                {
                    listBox1.SelectedIndex = 0;

                }
            }
        }

        private void txtgongyinghshang_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)//如果按了向上键
            {
                int idx = listBox1.SelectedIndex;//获取当前所选择的是哪一项
                if (idx == -1)//如果所选荐是-1,就表示没有选中任何值,是刚进入的
                {
                    listBox1.SelectedItem = listBox1.Items[listBox1.Items.Count - 1];//让他选中最后一个,也就是总数减1
                }
                else
                {
                    if (idx == 0)//等于零,表示此时选中的是在第一行.
                    {
                        listBox1.SelectedItem = listBox1.Items[listBox1.Items.Count - 1];//再按向上键,就跳到最后一个.
                        idx = listBox1.Items.Count;//当前选中的这一行,就是值的总数
                    }
                    listBox1.SelectedItem = listBox1.Items[idx - 1];//从下往上一直移动选择, 一直递减1
                }
            }
            else if (e.KeyCode == Keys.Down)//如果按了向下键
            {
                int idx = listBox1.SelectedIndex;//获取当前所选择的是哪一项
                if (idx == -1)//如果所选荐是-1,就表示没有选中任何值,是刚进入的
                {
                    //把下拉列里的第一个(item[0])值,赋给listBox2的SelectedItem属性, 这个属性表示当前被选中的项
                    listBox1.SelectedItem = listBox1.Items[0];
                }
                else
                {
                    if (idx == listBox1.Items.Count - 1)//如果idx等于总数减1,  就表示所选中的已经在最后一个了
                    {
                        listBox1.SelectedItem = listBox1.Items[0];//就把第一个值,赋给listBox2的SelectedItem属性. 等于从头再开始
                    }
                    else
                    {
                        listBox1.SelectedItem = listBox1.Items[idx + 1];//不是未选中,也不是最后一项,  就递增1,向下再移动的意思
                    }
                }
                idx = listBox1.SelectedIndex;//最后得出结果,再次获取当前所选择的是哪一项
            }
            else if (e.KeyCode == Keys.Enter && (listBox1.Visible == true))
            {
                //如果按了回车键,并且这个下拉框是要可见的时候.隐藏时就按回车无效
                if (listBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("请选择对应的人员！");

                    return;
                }

                int i = txtgongyinghshang.Text.LastIndexOf(";");
                if (i == -1)
                {
                    string chongxin = "";
                    chongxin = this.listBox1.SelectedItem.ToString();//把选中的值给文本框
                    txtgongyinghshang.Text = chongxin;
                    string sql = "select * from tb_gongfang where 单位名称='" + txtgongyinghshang.Text.Trim() + "'";
                    this.txtgongyinghshang.SelectionStart = this.txtgongyinghshang.TextLength;
                    listBox1.Visible = false;//隐藏这个控件

                }
                if (i != -1)
                {
                    string jiequ = txtgongyinghshang.Text.Substring(0, i + 1);

                    txtgongyinghshang.Text = jiequ + this.listBox1.SelectedItem.ToString() + ";";
                    this.txtgongyinghshang.SelectionStart = this.txtgongyinghshang.TextLength;
                    string sql = "select * from tb_gongfang where 单位名称='" + txtgongyinghshang.Text.Trim() + "'";

                    listBox1.Visible = false;//隐藏这个控件

                }
            }
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("请选择对应的人员");

                return;
            }

            int i = txtgongyinghshang.Text.LastIndexOf(";");
            if (i == -1)
            {
                string chongxin = "";
                chongxin = this.listBox1.SelectedItem.ToString();//把选中的值给文本框
                txtgongyinghshang.Text = chongxin;
                string sql = "select * from tb_gongfang where 单位名称='" + txtgongyinghshang.Text.Trim() + "'";
                this.txtgongyinghshang.SelectionStart = this.txtgongyinghshang.TextLength;
                listBox1.Visible = false;//隐藏这个控件
            }
            if (i != -1)
            {
                string jiequ = txtgongyinghshang.Text.Substring(0, i + 1);
                txtgongyinghshang.Text = jiequ + this.listBox1.SelectedItem.ToString() + ";";
                string sql = "select * from tb_gongfang where 单位名称='" + txtgongyinghshang.Text.Trim() + "'";
                this.txtgongyinghshang.SelectionStart = this.txtgongyinghshang.TextLength;
                listBox1.Visible = false;//隐藏这个控件
            }
        }

        private void buttonItem4_Click_1(object sender, EventArgs e)
        {
            if (txtfapiaohao.Text == "")
            {
                MessageBox.Show("请输入发票号！");
                return;
            }
            if (txtgongyinghshang.Text == "")
            {
                MessageBox.Show("请输入开票供应商！");
                return;
            }
            if (txthetonghao.Text == "")
            {
                MessageBox.Show("请输入合同号！");
                return;
            }
            if (txtkuweihao.Text == "")
            {
                MessageBox.Show("请输入库位号！");
                return;
            }
            if (gridView1.RowCount == 0)
            {
                MessageBox.Show("请先查询到合同料单再生成！");
                return;
            }
            if (radioButton17.Checked == false && radioButton16.Checked == false && radioButton3.Checked == false && radioButton0.Checked == false)
            {
                MessageBox.Show("请输入税率！");
                return;
            }
            string liushuihao = DateTime.Now.ToString("yyyyMMddHHmmss");

            Workbook workbook = new Workbook(System.Environment.CurrentDirectory + "\\" + "收料报告单模板.xls");
            Worksheet worksheet = workbook.Worksheets["Sheet1"];

            worksheet.Cells["B3"].PutValue(txtkuweihao.Text);
            worksheet.Cells["D3"].PutValue(liushuihao);
            worksheet.Cells["G3"].PutValue(txthetonghao.Text);
            string gongyingshang = txtgongyinghshang.Text.Trim();
            worksheet.Cells["B4"].PutValue(gongyingshang);

            worksheet.Cells["D4"].PutValue(txtfapiaohao.Text);

            worksheet.Cells["G4"].PutValue(datekaipiao.Text);

            int[] aaaaa = gridView1.GetSelectedRows();
            int b = aaaaa.Length;
            if (b <= 3)
            {
                string a = "";
                string bb = "";
                string c = "";
                foreach (int i in aaaaa)
                {
                    if (a == "" && bb == "" && c == "")
                    {
                        a = i.ToString();
                        continue;
                    }
                    if (a != "" && bb == "" && c == "")
                    {
                        bb = i.ToString();
                        continue;
                    }
                    if (a != "" && bb != "" && c == "")
                    {
                        c = i.ToString();
                        continue;
                    }
                }
                foreach (int i in aaaaa)
                {
                    if (a == i.ToString())
                    {
                        worksheet.Cells["A6"].PutValue(Convert.ToString(gridView1.GetRowCellValue(i, "名称")));
                        worksheet.Cells["B6"].PutValue(Convert.ToString(gridView1.GetRowCellValue(i, "型号")));
                        worksheet.Cells["D6"].PutValue(Convert.ToString(gridView1.GetRowCellValue(i, "单位")));
                        worksheet.Cells["E6"].PutValue(Convert.ToString(gridView1.GetRowCellValue(i, "应开票数量")));
                        worksheet.Cells["F6"].PutValue(Convert.ToString(gridView1.GetRowCellValue(i, "净额")));
                    }
                    if (bb == i.ToString())
                    {
                        worksheet.Cells["A7"].PutValue(Convert.ToString(gridView1.GetRowCellValue(i, "名称")));
                        worksheet.Cells["B7"].PutValue(Convert.ToString(gridView1.GetRowCellValue(i, "型号")));
                        worksheet.Cells["D7"].PutValue(Convert.ToString(gridView1.GetRowCellValue(i, "单位")));
                        worksheet.Cells["E7"].PutValue(Convert.ToString(gridView1.GetRowCellValue(i, "应开票数量")));
                        worksheet.Cells["F7"].PutValue(Convert.ToString(gridView1.GetRowCellValue(i, "净额")));
                    }
                    if (c == i.ToString())
                    {
                        worksheet.Cells["A8"].PutValue(Convert.ToString(gridView1.GetRowCellValue(i, "名称")));
                        worksheet.Cells["B8"].PutValue(Convert.ToString(gridView1.GetRowCellValue(i, "型号")));
                        worksheet.Cells["D8"].PutValue(Convert.ToString(gridView1.GetRowCellValue(i, "单位")));
                        worksheet.Cells["E8"].PutValue(Convert.ToString(gridView1.GetRowCellValue(i, "应开票数量")));
                        worksheet.Cells["F8"].PutValue(Convert.ToString(gridView1.GetRowCellValue(i, "净额")));
                    }
                }


            }
            if (b > 3)
            {
                double zonge = 0;

                foreach (int i in aaaaa)
                {
                    zonge += Convert.ToDouble(gridView1.GetRowCellValue(i, "净额"));

                }
                worksheet.Cells["E6"].PutValue("1");
                worksheet.Cells["F6"].PutValue(zonge);
            }


            Random rd = new Random();
            string suijishu = rd.Next(10, 10000).ToString();
            string mingcheng = "收料报告单" + suijishu;
            workbook.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + mingcheng + ".xls");
            MessageBox.Show("生成成功！");
            System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + mingcheng + ".xls");
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认删除吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                int[] a = gridView2.GetSelectedRows();

                foreach (int i in a)
                {
                    string xinfapiaohao = "";
                    double shuilvv = 0;
                    string id = Convert.ToString(gridView2.GetRowCellValue(i, "id"));
                    string dingwei1 = Convert.ToString(gridView2.GetRowCellValue(i, "定位"));
                    string fapiaohao = Convert.ToString(gridView2.GetRowCellValue(i, "发票号"));
                    string sql = "Select * from tb_caigouliaodan where id='" + dingwei1 + "'";
                    DataTable chaxun = SQLhelp.GetDataTable(sql, CommandType.Text);
                    if (fapiaohao.Contains(";"))
                    {
                        string[] piliangfapiaohao = chaxun.Rows[0]["发票号"].ToString().Split(';');

                        string[] tempChar = chaxun.Rows[0]["发票号"].ToString().Split(';');
                        List<System.String> listS = new List<System.String>(tempChar);

                        foreach (string aaa in piliangfapiaohao)
                        {
                            listS.Remove(aaa);
                            xinfapiaohao = string.Join(";", listS);
                        }
                        double yikaipiao = Convert.ToDouble(chaxun.Rows[0]["已开票数量"]) - Convert.ToDouble(gridView2.GetRowCellValue(i, "开票数量"));
                        double yingkaipiaoshuliang = Convert.ToDouble(chaxun.Rows[0]["应开票数量"]) + Convert.ToDouble(gridView2.GetRowCellValue(i, "开票数量"));
                        string shuilv = gridView2.GetRowCellValue(i, "税率").ToString();
                        double shuliang = Convert.ToDouble(gridView2.GetRowCellValue(i, "开票数量"));


                        if (shuilv == "16%")
                        {
                            shuilvv = 0.16;
                        }
                        if (shuilv == "17%")
                        {
                            shuilvv = 0.17;
                        }
                        if (shuilv == "3%")
                        {
                            shuilvv = 0.03;
                        }
                        if (shuilv == "0%")
                        {
                            shuilvv = 0;
                        }
                        decimal jinge = decimal.Round(decimal.Parse(Convert.ToString(yikaipiao * Convert.ToDouble(chaxun.Rows[0]["采购单价预留"]) / (1 + shuilvv))), 2);
                        decimal shuie = Convert.ToDecimal(yikaipiao * Convert.ToDouble(chaxun.Rows[0]["采购单价预留"])) - jinge;
                        decimal jingdanjia = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(gridView2.GetRowCellValue(i, "采购单价")) / (1 + shuilvv))), 2);
                        string sql111 = "update tb_caigouliaodan set 采购单价='" + chaxun.Rows[0]["采购单价预留"].ToString() + "',总价='" + chaxun.Rows[0]["总价预留"].ToString() + "',发票号= '',税率='" + chaxun.Rows[0]["税率"].ToString() + "',净税额='" + shuie + "',净额='" + jinge + "',已开票数量='" + yikaipiao + "',应开票数量='" + yingkaipiaoshuliang + "',净单价='" + jingdanjia + "'  where id='" + dingwei1 + "'";
                        SQLhelp.ExecuteScalar(sql111, CommandType.Text);
                    }
                    if (!fapiaohao.Contains(";"))
                    {
                        double yikaipiao = Convert.ToDouble(chaxun.Rows[0]["已开票数量"]) - Convert.ToDouble(gridView2.GetRowCellValue(i, "开票数量"));
                        double yingkaipiaoshuliang = Convert.ToDouble(chaxun.Rows[0]["应开票数量"]) + Convert.ToDouble(gridView2.GetRowCellValue(i, "开票数量"));
                        string shuilv = gridView2.GetRowCellValue(i, "税率").ToString();
                        double shuliang = Convert.ToDouble(gridView2.GetRowCellValue(i, "开票数量"));

                        if (shuilv == "16%")
                        {
                            shuilvv = 0.16;
                        }
                        if (shuilv == "17%")
                        {
                            shuilvv = 0.17;
                        }
                        if (shuilv == "3%")
                        {
                            shuilvv = 0.03;
                        }
                        if (shuilv == "0%")
                        {
                            shuilvv = 0;
                        }
                        decimal jinge = decimal.Round(decimal.Parse(Convert.ToString(yikaipiao * Convert.ToDouble(chaxun.Rows[0]["采购单价预留"]) / (1 + shuilvv))), 2);
                        decimal shuie = Convert.ToDecimal(yikaipiao * Convert.ToDouble(chaxun.Rows[0]["采购单价预留"])) - jinge;
                        decimal jingdanjia = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(gridView2.GetRowCellValue(i, "采购单价")) / (1 + shuilvv))), 2);
                        string sql111 = "update tb_caigouliaodan set 采购单价='" + chaxun.Rows[0]["采购单价预留"].ToString() + "',总价='" + chaxun.Rows[0]["总价预留"].ToString() + "',发票号= '" + xinfapiaohao + "',税率='" + chaxun.Rows[0]["税率"].ToString() + "',净税额='" + shuie + "',净额='" + jinge + "',已开票数量='" + yikaipiao + "',应开票数量='" + yingkaipiaoshuliang + "',净单价='" + jingdanjia + "'  where id='" + dingwei1 + "'";
                        SQLhelp.ExecuteScalar(sql111, CommandType.Text);
                    }

                    string sqlruku = "select id,入库数量 from tb_ruku where 定位='" + dingwei1 + "'";
                    DataTable ruku = SQLhelp.GetDataTable(sqlruku, CommandType.Text);
                    for (int j = 0; j < ruku.Rows.Count; j++)
                    {
                        decimal danjia = Convert.ToDecimal(chaxun.Rows[0]["采购单价预留"]);
                        decimal jingdanjia = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(chaxun.Rows[0]["采购单价预留"]) / (1 + shuilvv))), 2);
                        string dingwei = ruku.Rows[j]["id"].ToString();
                        decimal zongjia2 = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(ruku.Rows[j]["入库数量"]) * Convert.ToDouble(danjia))), 2);
                        decimal jinge2 = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(zongjia2) / (1 + shuilvv))), 2);
                        decimal shuie2 = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(zongjia2) - Convert.ToDouble(jinge2))), 2);
                        double shuilv1 = shuilvv * 100;
                        string sql123 = "update tb_ruku set 采购单价='" + danjia + "',总价='" + zongjia2 + "',发票号='" + xinfapiaohao + "',净额='" + jinge2 + "',税额='" + shuie2 + "',净单价='" + jingdanjia + "' where id='" + dingwei + "'";
                        SQLhelp.ExecuteScalar(sql123, CommandType.Text);
                    }

                    //出库
                    string sqlchuku = "select id,出库数量 from tb_chuku where 定位='" + dingwei1 + "'";
                    DataTable chuku = SQLhelp.GetDataTable(sqlchuku, CommandType.Text);
                    for (int j = 0; j < chuku.Rows.Count; j++)
                    {
                        decimal danjia = Convert.ToDecimal(chaxun.Rows[0]["采购单价预留"]);
                        decimal jingdanjia = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(chaxun.Rows[0]["采购单价预留"]) / (1 + shuilvv))), 2);
                        string dingwei = chuku.Rows[j]["id"].ToString();
                        decimal zongjia2 = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(chuku.Rows[j]["出库数量"]) * Convert.ToDouble(danjia))), 2);
                        decimal jinge2 = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(zongjia2) / (1 + shuilvv))), 2);
                        decimal shuie2 = decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(zongjia2) - Convert.ToDouble(jinge2))), 2);

                        string sql1234 = "update tb_chuku set 采购单价='" + danjia + "',总价='" + zongjia2 + "',发票号='" + xinfapiaohao + "',净额='" + jinge2 + "',税额='" + shuie2 + "',净单价='" + jingdanjia + "' where id='" + dingwei + "'";
                        SQLhelp.ExecuteScalar(sql1234, CommandType.Text);
                    }
                    string shanchu = "delete from tb_fapiao where id='" + id + "'";
                    SQLhelp.ExecuteScalar(shanchu, CommandType.Text);
                }
            }
            MessageBox.Show("删除成功！");
            Reload();

        }
        public void Reload()
        {
            string sql = "select id,工作令号,项目名称,设备名称,合同号,编码,型号,名称,单位,制造类型,实际采购数量,开票数量,开票时间,开票人,定位,采购单价,总价,净额,税率,发票号,供方名称,净单价,库位号,流水号,供方代号,开票供方,开票供方代号,发票日期,定位 from tb_fapiao";
            gridControl2.DataSource = SQLhelp.GetDataTable(sql, CommandType.
                Text);


            string sql1 = "select id,提交人,收到发票日期,供方名称,发票编号,发票日期,发票金额,合同号,采购员,审核确认,审核时间,审核人 from tb_fapiaodengjibiao";
            gridControl4.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);

        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (txttianjia.Text.Trim() == "")
            {
                MessageBox.Show("请输入发票号");
                return;
            }
            if (txtfapiaohao.Text.Trim() != "")
            {
                txtfapiaohao.Text += ";" + txttianjia.Text.Trim();
            }
            if (txtfapiaohao.Text.Trim() == "")
            {
                txtfapiaohao.Text += txttianjia.Text.Trim();
            }

        }

        private void 修改净额ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double zongjia = 0;
            double jingshuie = 0;
            int[] a = gridView1.GetSelectedRows();
            if (radioButton17.Checked == true)
            {
                foreach (int i in a)
                {

                    string jinge = Convert.ToString(gridView1.GetRowCellValue(i, "净额"));
                    string id = Convert.ToString(gridView1.GetRowCellValue(i, "id"));
                    if (jinge != "")
                    {
                        double shuliang = Convert.ToDouble(gridView1.GetRowCellValue(i, "应开票数量"));
                        this.gridView1.SetRowCellValue(i, gridView1.Columns["总价"], decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(gridView1.GetRowCellValue(i, "净额")) * 1.17)), 2));

                        this.gridView1.SetRowCellValue(i, gridView1.Columns["净税额"], decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(gridView1.GetRowCellValue(i, "总价")) - Convert.ToDouble(gridView1.GetRowCellValue(i, "净额")))), 2));
                        this.gridView1.SetRowCellValue(i, gridView1.Columns["税率"], "17%");
                        this.gridView1.SetRowCellValue(i, gridView1.Columns["净单价"], decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(gridView1.GetRowCellValue(i, "净额")) / Convert.ToDouble(gridView1.GetRowCellValue(i, "应开票数量")))), 10));
                        this.gridView1.SetRowCellValue(i, gridView1.Columns["采购单价"], decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(gridView1.GetRowCellValue(i, "净额")) / Convert.ToDouble(gridView1.GetRowCellValue(i, "应开票数量")) * 1.17)), 2));
                        zongjia += Convert.ToDouble(gridView1.GetRowCellValue(i, "净额"));
                        jingshuie += Convert.ToDouble(gridView1.GetRowCellValue(i, "净税额"));
                    }

                }
                MessageBox.Show("净额：" + zongjia.ToString() + "   " + "税额：" + jingshuie.ToString());

            }
            if (radioButton16.Checked == true)
            {
                foreach (int i in a)
                {

                    string jinge = Convert.ToString(gridView1.GetRowCellValue(i, "净额"));
                    string id = Convert.ToString(gridView1.GetRowCellValue(i, "id"));
                    if (jinge != "")
                    {
                        double shuliang = Convert.ToDouble(gridView1.GetRowCellValue(i, "应开票数量"));
                        this.gridView1.SetRowCellValue(i, gridView1.Columns["总价"], decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(gridView1.GetRowCellValue(i, "净额")) * 1.16)), 2));

                        this.gridView1.SetRowCellValue(i, gridView1.Columns["净税额"], decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(gridView1.GetRowCellValue(i, "总价")) - Convert.ToDouble(gridView1.GetRowCellValue(i, "净额")))), 2));
                        this.gridView1.SetRowCellValue(i, gridView1.Columns["税率"], "16%");
                        this.gridView1.SetRowCellValue(i, gridView1.Columns["净单价"], decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(gridView1.GetRowCellValue(i, "净额")) / Convert.ToDouble(gridView1.GetRowCellValue(i, "应开票数量")))), 10));
                        this.gridView1.SetRowCellValue(i, gridView1.Columns["采购单价"], decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(gridView1.GetRowCellValue(i, "净额")) / Convert.ToDouble(gridView1.GetRowCellValue(i, "应开票数量")) * 1.16)), 2));
                        zongjia += Convert.ToDouble(gridView1.GetRowCellValue(i, "净额"));
                        jingshuie += Convert.ToDouble(gridView1.GetRowCellValue(i, "净税额"));
                    }

                }
                MessageBox.Show("净额：" + zongjia.ToString() + "   " + "税额：" + jingshuie.ToString());

            }
            if (radioButton3.Checked == true)
            {
                foreach (int i in a)
                {

                    string jinge = Convert.ToString(gridView1.GetRowCellValue(i, "净额"));
                    string id = Convert.ToString(gridView1.GetRowCellValue(i, "id"));
                    if (jinge != "")
                    {
                        double shuliang = Convert.ToDouble(gridView1.GetRowCellValue(i, "应开票数量"));
                        this.gridView1.SetRowCellValue(i, gridView1.Columns["总价"], decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(gridView1.GetRowCellValue(i, "净额")) * 1.03)), 2));

                        this.gridView1.SetRowCellValue(i, gridView1.Columns["净税额"], decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(gridView1.GetRowCellValue(i, "总价")) - Convert.ToDouble(gridView1.GetRowCellValue(i, "净额")))), 2));
                        this.gridView1.SetRowCellValue(i, gridView1.Columns["税率"], "3%");
                        this.gridView1.SetRowCellValue(i, gridView1.Columns["净单价"], decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(gridView1.GetRowCellValue(i, "净额")) / Convert.ToDouble(gridView1.GetRowCellValue(i, "应开票数量")))), 10));
                        this.gridView1.SetRowCellValue(i, gridView1.Columns["采购单价"], decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(gridView1.GetRowCellValue(i, "净额")) / Convert.ToDouble(gridView1.GetRowCellValue(i, "应开票数量")) * 1.03)), 2));
                        zongjia += Convert.ToDouble(gridView1.GetRowCellValue(i, "净额"));
                        jingshuie += Convert.ToDouble(gridView1.GetRowCellValue(i, "净税额"));
                    }

                }
                MessageBox.Show("净额：" + zongjia.ToString() + "   " + "税额：" + jingshuie.ToString());
            }
            if (radioButton0.Checked == true)
            {
                foreach (int i in a)
                {

                    string jinge = Convert.ToString(gridView1.GetRowCellValue(i, "净额"));
                    string id = Convert.ToString(gridView1.GetRowCellValue(i, "id"));
                    if (jinge != "")
                    {
                        double shuliang = Convert.ToDouble(gridView1.GetRowCellValue(i, "应开票数量"));
                        this.gridView1.SetRowCellValue(i, gridView1.Columns["总价"], decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(gridView1.GetRowCellValue(i, "净额")))), 2));

                        this.gridView1.SetRowCellValue(i, gridView1.Columns["净税额"], decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(gridView1.GetRowCellValue(i, "总价")) - Convert.ToDouble(gridView1.GetRowCellValue(i, "净额")))), 2));
                        this.gridView1.SetRowCellValue(i, gridView1.Columns["税率"], "0%");
                        this.gridView1.SetRowCellValue(i, gridView1.Columns["净单价"], decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(gridView1.GetRowCellValue(i, "净额")) / Convert.ToDouble(gridView1.GetRowCellValue(i, "应开票数量")))), 10));
                        this.gridView1.SetRowCellValue(i, gridView1.Columns["采购单价"], decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(gridView1.GetRowCellValue(i, "净额")) / Convert.ToDouble(gridView1.GetRowCellValue(i, "应开票数量")))), 2));

                        zongjia += Convert.ToDouble(gridView1.GetRowCellValue(i, "净额"));
                        jingshuie += Convert.ToDouble(gridView1.GetRowCellValue(i, "净税额"));
                    }

                }
                MessageBox.Show("净额：" + zongjia.ToString() + "   " + "税额：" + jingshuie.ToString());
            }

        }

        private void 计算初始金额ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double zongjia = 0;

            int[] a = gridView1.GetSelectedRows();
            if (radioButton17.Checked == true)
            {
                foreach (int i in a)
                {

                    string danjia = Convert.ToString(gridView1.GetRowCellValue(i, "采购单价"));
                    string id = Convert.ToString(gridView1.GetRowCellValue(i, "id"));
                    if (danjia != "")
                    {
                        double shuliang = Convert.ToDouble(gridView1.GetRowCellValue(i, "应开票数量"));
                        this.gridView1.SetRowCellValue(i, gridView1.Columns["总价"], shuliang * Convert.ToDouble(danjia));
                        this.gridView1.SetRowCellValue(i, gridView1.Columns["净额"], decimal.Round(decimal.Parse(Convert.ToString(shuliang * Convert.ToDouble(danjia) / 1.17)), 2));
                        this.gridView1.SetRowCellValue(i, gridView1.Columns["净税额"], decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(gridView1.GetRowCellValue(i, "总价")) - Convert.ToDouble(gridView1.GetRowCellValue(i, "净额")))), 2));
                        this.gridView1.SetRowCellValue(i, gridView1.Columns["税率"], "17%");
                        this.gridView1.SetRowCellValue(i, gridView1.Columns["净单价"], decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(danjia) / 1.17)), 10));

                        zongjia += shuliang * Convert.ToDouble(danjia);
                    }
                }
                MessageBox.Show(zongjia.ToString());
            }
            if (radioButton16.Checked == true)
            {
                foreach (int i in a)
                {
                    string danjia = Convert.ToString(gridView1.GetRowCellValue(i, "采购单价"));
                    string id = Convert.ToString(gridView1.GetRowCellValue(i, "id"));
                    if (danjia != "")
                    {
                        double shuliang = Convert.ToDouble(gridView1.GetRowCellValue(i, "应开票数量"));
                        this.gridView1.SetRowCellValue(i, gridView1.Columns["总价"], shuliang * Convert.ToDouble(danjia));
                        this.gridView1.SetRowCellValue(i, gridView1.Columns["净额"], decimal.Round(decimal.Parse(Convert.ToString(shuliang * Convert.ToDouble(danjia) / 1.16)), 2));
                        this.gridView1.SetRowCellValue(i, gridView1.Columns["净税额"], decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(gridView1.GetRowCellValue(i, "总价")) - Convert.ToDouble(gridView1.GetRowCellValue(i, "净额")))), 2));
                        this.gridView1.SetRowCellValue(i, gridView1.Columns["税率"], "16%");
                        this.gridView1.SetRowCellValue(i, gridView1.Columns["净单价"], decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(danjia) / 1.16)), 10));
                        zongjia += shuliang * Convert.ToDouble(danjia);

                    }
                }
                MessageBox.Show(zongjia.ToString());
            }

            if (radioButton3.Checked == true)
            {
                foreach (int i in a)
                {

                    string danjia = Convert.ToString(gridView1.GetRowCellValue(i, "采购单价"));
                    string id = Convert.ToString(gridView1.GetRowCellValue(i, "id"));
                    if (danjia != "")
                    {
                        double shuliang = Convert.ToDouble(gridView1.GetRowCellValue(i, "应开票数量"));
                        this.gridView1.SetRowCellValue(i, gridView1.Columns["总价"], shuliang * Convert.ToDouble(danjia));
                        this.gridView1.SetRowCellValue(i, gridView1.Columns["净额"], decimal.Round(decimal.Parse(Convert.ToString(shuliang * Convert.ToDouble(danjia) / 1.03)), 2));
                        this.gridView1.SetRowCellValue(i, gridView1.Columns["净税额"], decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(gridView1.GetRowCellValue(i, "总价")) - Convert.ToDouble(gridView1.GetRowCellValue(i, "净额")))), 2));
                        this.gridView1.SetRowCellValue(i, gridView1.Columns["税率"], "3%");
                        this.gridView1.SetRowCellValue(i, gridView1.Columns["净单价"], decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(danjia) / 1.03)), 10));
                        zongjia += shuliang * Convert.ToDouble(danjia);

                    }
                }
                MessageBox.Show(zongjia.ToString());
            }
            if (radioButton0.Checked == true)
            {
                foreach (int i in a)
                {

                    string danjia = Convert.ToString(gridView1.GetRowCellValue(i, "采购单价"));
                    string id = Convert.ToString(gridView1.GetRowCellValue(i, "id"));
                    if (danjia != "")
                    {
                        double shuliang = Convert.ToDouble(gridView1.GetRowCellValue(i, "应开票数量"));
                        this.gridView1.SetRowCellValue(i, gridView1.Columns["总价"], shuliang * Convert.ToDouble(danjia));
                        this.gridView1.SetRowCellValue(i, gridView1.Columns["净额"], decimal.Round(decimal.Parse(Convert.ToString(shuliang * Convert.ToDouble(danjia) / 1)), 2));
                        this.gridView1.SetRowCellValue(i, gridView1.Columns["净税额"], decimal.Round(decimal.Parse(Convert.ToString(shuliang * Convert.ToDouble(danjia) * 0)), 2));
                        this.gridView1.SetRowCellValue(i, gridView1.Columns["税率"], "0%");
                        this.gridView1.SetRowCellValue(i, gridView1.Columns["净单价"], decimal.Round(decimal.Parse(Convert.ToString(Convert.ToDouble(danjia))), 10));
                        zongjia += shuliang * Convert.ToDouble(danjia);

                    }
                }
                MessageBox.Show(zongjia.ToString());
            }
        }

        private void 审批通过ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] a = gridView4.GetSelectedRows();
            foreach (int i in a)
            {
                string shenhe= Convert.ToString(gridView4.GetRowCellValue(i, "审核确认"));
                if(shenhe=="1")
                {
                    MessageBox.Show("其中有的已经确认，不要反复确认！");
                    return;
                }
            }
            foreach (int i in a)
            {
                string shenhe = Convert.ToString(gridView4.GetRowCellValue(i, "审核确认"));
                string id = Convert.ToString(gridView4.GetRowCellValue(i, "id"));
                string sql = "update tb_fapiaodengjibiao set 审核确认=1,审核人='" + yonghu + "', 审核时间='" + DateTime.Now + "' where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);
            }
            MessageBox.Show("审批成功！");
            Reload();
        }
    }
}
