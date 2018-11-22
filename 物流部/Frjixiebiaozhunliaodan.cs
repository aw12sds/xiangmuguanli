using Aspose.Cells;
using DevComponents.DotNetBar;
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
    public partial class Frjixiebiaozhunliaodan : Office2007Form
    {
        public Frjixiebiaozhunliaodan()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string gongzuolinghao;
        public string xiangmumingcheng;
        public string shijian;
        public string lujing;
        DataTable dt;
        private void Frjixiebiaozhunliaodan_Load(object sender, EventArgs e)
        {
            Reload();

        }
        public void Reload()
        {
            string sql1 = "select id, 序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,申购人,收到料单日期,供方名称,合同号,实际采购数量,报价, 采购单价,实际到货日期,当前状态,采购料单备注,附件名称,附件类型 from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "' and   制造类型 ='机械标准件' ";
            dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            dataGridViewX2.DataSource = dt;


        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                for (int i = 0; i < dataGridViewX2.Rows.Count; i++)
                {
                    string id = Convert.ToString(dataGridViewX2.Rows[i].Cells["id"].Value);
                    string xuhao = Convert.ToString(dataGridViewX2.Rows[i].Cells["序号"].Value);
                    string bianma = Convert.ToString(dataGridViewX2.Rows[i].Cells["编码"].Value);
                    string xinghao = Convert.ToString(dataGridViewX2.Rows[i].Cells["型号"].Value);
                    string mingcheng = Convert.ToString(dataGridViewX2.Rows[i].Cells["名称"].Value);
                    string shuliang = Convert.ToString(dataGridViewX2.Rows[i].Cells["数量"].Value);
                    string leixing = Convert.ToString(dataGridViewX2.Rows[i].Cells["类型"].Value);
                    string danwei = Convert.ToString(dataGridViewX2.Rows[i].Cells["单位"].Value);
                    string xiangmugonglinghao = Convert.ToString(dataGridViewX2.Rows[i].Cells["项目工令号"].Value);
                    string yaoqiudaohuoriqi = Convert.ToString(dataGridViewX2.Rows[i].Cells["要求到货日期"].Value);

                    string zhizaoleixing = Convert.ToString(dataGridViewX2.Rows[i].Cells["制造类型"].Value);
                    string beizhu = Convert.ToString(dataGridViewX2.Rows[i].Cells["备注"].Value);
                    string gongfangmingcheng = Convert.ToString(dataGridViewX2.Rows[i].Cells["供方名称"].Value);
                    string hetonghao = Convert.ToString(dataGridViewX2.Rows[i].Cells["合同号"].Value);
                    //string shijicaigoushuliang = dataGridViewX2.Rows[i].Cells["实际采购数量"].Value.ToString();
                    string baojia = Convert.ToString(dataGridViewX2.Rows[i].Cells["报价"].Value);
                    string caigoudanjia = Convert.ToString(dataGridViewX2.Rows[i].Cells["采购单价"].Value);
                    string shijidaohuoriqi = Convert.ToString(dataGridViewX2.Rows[i].Cells["实际到货日期"].Value);
                    string dangqianzhuangtai = Convert.ToString(dataGridViewX2.Rows[i].Cells["当前状态"].Value);
                    string caigouliaodanbeizhu = Convert.ToString(dataGridViewX2.Rows[i].Cells["采购料单备注"].Value);


                    if (shijidaohuoriqi != "")
                    {

                        string shijicaigoushuliang = dataGridViewX2.Rows[i].Cells["实际采购数量"].Value.ToString();

                        string sql2 = "update tb_caigouliaodan  set 供方名称= '" + gongfangmingcheng + "',合同号= '" + hetonghao + "',实际采购数量=  '" + shijicaigoushuliang + "',报价= '" + baojia + "',采购单价 ='" + caigoudanjia + "',实际到货日期= '" + shijidaohuoriqi + "',当前状态= '" + dangqianzhuangtai + "',采购料单备注='" + caigouliaodanbeizhu + "',制造类型='" + zhizaoleixing + "'  where id='" + id + "'";
                        SQLhelp.ExecuteScalar(sql2, CommandType.Text);
                        //}

                    }
                    if (shijidaohuoriqi == "")
                    {
                        string shijicaigoushuliang = dataGridViewX2.Rows[i].Cells["实际采购数量"].Value.ToString();

                        string sql2 = "update tb_caigouliaodan  set 供方名称= '" + gongfangmingcheng + "',合同号= '" + hetonghao + "',实际采购数量=  '" + shijicaigoushuliang + "',报价= '" + baojia + "',采购单价 ='" + caigoudanjia + "',当前状态= '" + dangqianzhuangtai + "' ,采购料单备注='" + caigouliaodanbeizhu + "' ,制造类型='" + zhizaoleixing + "' where id='" + id + "'";
                        SQLhelp.ExecuteScalar(sql2, CommandType.Text);
                    }
                }
                MessageBox.Show("提交成功！");
                Reload();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void 导出料单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog op = new SaveFileDialog();
            op.Filter = "EXCEL文件|*.xls;*,xlsx;";
            if (op.ShowDialog() == DialogResult.OK)//显示保存文件对话框
            {



                lujing = op.FileName;

            }

            string savePath = lujing;

            Workbook book = new Workbook();
            Worksheet sheet = book.Worksheets[0];
            Cells cells = sheet.Cells;


            int Colnum = dt.Columns.Count;//表格列数   
            int Rownum = dt.Rows.Count;//表格行数   

            for (int i = 0; i < Colnum; i++)
            {
                cells[0, i].PutValue(dt.Columns[i].ColumnName);
            }

            for (int i = 0; i < Rownum; i++)
            {
                for (int k = 0; k < Colnum; k++)
                {
                    cells[1 + i, k].PutValue(dt.Rows[i][k].ToString());
                }
            }

            book.Save(savePath);
            MessageBox.Show("导出成功！");
            this.Close();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            try
            {

                for (int i = 0; i < dataGridViewX2.Rows.Count; i++)
                {
                    string id = Convert.ToString(dataGridViewX2.Rows[i].Cells["id"].Value);

                    string gongfangmingcheng = txtgongfang.Text.Trim();


                    string sql2 = "update tb_caigouliaodan  set 供方名称= '" + gongfangmingcheng + "'  where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql2, CommandType.Text);

                }
                MessageBox.Show("修改成功！");
                Reload();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            try
            {

                for (int i = 0; i < dataGridViewX2.Rows.Count; i++)
                {
                    string id = Convert.ToString(dataGridViewX2.Rows[i].Cells["id"].Value);

                    string hetonghao = txthetonghao.Text.Trim();


                    string sql2 = "update tb_caigouliaodan  set 合同号= '" + hetonghao + "'  where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql2, CommandType.Text);



                }
                MessageBox.Show("修改成功！");
                Reload();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            try
            {

                for (int i = 0; i < dataGridViewX2.Rows.Count; i++)
                {
                    string id = Convert.ToString(dataGridViewX2.Rows[i].Cells["id"].Value);

                    string sql2 = "update tb_caigouliaodan  set 实际到货日期= '" + DateTime.Now + "'  where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql2, CommandType.Text);

                }
                MessageBox.Show("修改成功！");
                Reload();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            try
            {

                for (int i = 0; i < dataGridViewX2.Rows.Count; i++)
                {
                    string id = Convert.ToString(dataGridViewX2.Rows[i].Cells["id"].Value);

                    string sql2 = "update tb_caigouliaodan  set 当前状态= '" + comboBoxItem1.Text.Trim() + "'  where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql2, CommandType.Text);

                }
                MessageBox.Show("修改成功！");
                Reload();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
