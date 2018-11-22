using DevComponents.DotNetBar;
using NetWork.util;
using NetWorkLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 项目管理系统.技术部;

namespace 项目管理系统.生产部
{
    public partial class FrJiagongliaodan : DevExpress.XtraEditors.XtraForm
    {
        public FrJiagongliaodan()
        {

            InitializeComponent();
        }
        public string gongzuolinghao;
        public string xiangmumingcheng;
        public string shijian;
        public string leixing;
        public string shebeimingcheng;
        public string yonghu;
        private void FrJiagongliaodan_Load(object sender, EventArgs e)
        {
            Reload();

        }
        public DataTable gongong;
        public void Reload()
        {

            if (leixing == "加工")
            {
                string sql1 = "select id,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,生产部确认,生产部确认时间,当前状态,实际采购数量,附件名称,加工预计结束时间,工序外协,技术更改,工作令号,项目名称,设备名称  from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 设备名称='" + shebeimingcheng + "' and 时间='" + shijian + "' and   制造类型='自制零部件'  ";
                DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                gongong = SQLhelp.GetDataTable(sql1, CommandType.Text);
                gridControl4.DataSource = dt;
            }
            if (leixing == "装配")
            {
                string sql1 = "select id,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,生产部确认,生产部确认时间,当前状态,实际采购数量,附件名称,加工预计结束时间,工序外协,技术更改,工作令号,项目名称,设备名称 from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'  and 设备名称='" + shebeimingcheng + "'   and 时间='" + shijian + "' and   制造类型='装配零部件'  ";
                DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                gongong = SQLhelp.GetDataTable(sql1, CommandType.Text);
                gridControl4.DataSource = dt;

            }

            if (leixing == "技改")
            {
                string sql1 = "select id,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,生产部确认,生产部确认时间,当前状态,实际采购数量,附件名称,加工预计结束时间,工序外协,技术更改,工作令号,项目名称,设备名称 from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "'   and 时间='" + shijian + "'   ";
                DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                gongong = SQLhelp.GetDataTable(sql1, CommandType.Text);
                gridControl4.DataSource = dt;

            }

        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView4.RowCount; i++)
            {
                string id = gridView4.GetRowCellValue(i, "id").ToString();
                string queren = gridView4.GetRowCellValue(i, "生产部确认").ToString();
                string mingcheng = gridView4.GetRowCellValue(i, "名称").ToString();
                string time = DateTime.Now.ToString();
                if (queren == "1")
                {
                    string sql1 = "select  生产部确认  from tb_caigouliaodan    where id='" + id + "' ";
                    string duibi = SQLhelp.ExecuteScalar(sql1, CommandType.Text).ToString();
                    if (duibi == "0")
                    {
                        string sql = "select * from db_gongxu1 where 序号='" + id + "'";
                        DataTable dtt = sqlhelp1.GetDataTable(sql, CommandType.Text);
                        if (dtt.Rows.Count == 0)
                        {
                            MessageBox.Show(mingcheng + "没有编工艺，无法入库！");
                            return;
                        }

                        string sql2 = "update tb_caigouliaodan  set 生产部确认=1 ,生产部确认时间='" + time + "'  where id ='" + id + "' ";
                        SQLhelp.ExecuteScalar(sql2, CommandType.Text);

                        string sql3 = "update tb_caigouliaodan  set  当前状态='已加工'  from tb_caigouliaodan    where id='" + id + "' ";
                        SQLhelp.ExecuteScalar(sql3, CommandType.Text);
                    }
                }

            }
            MessageBox.Show("保存成功！");
            Reload();
        }
        private void buttonItem1_Click(object sender, EventArgs e)
        {
            if (leixing == "加工")
            {
                string sql1 = "select id,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,生产部确认,生产部确认时间,当前状态,实际采购数量,附件名称,加工预计结束时间,工序外协,技术更改,工作令号,项目名称,设备名称 from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "' and   制造类型='自制零部件'  and   型号 like  '%" + txtxinghao.Text + "%' ";
                DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                gridControl4.DataSource = dt;
            }
            if (leixing == "装配")
            {
                string sql1 = "select id,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,生产部确认,生产部确认时间,当前状态,实际采购数量,附件名称,加工预计结束时间,工序外协,技术更改,工作令号,项目名称,设备名称 from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "' and   制造类型='装配零部件'  and   型号 like  '%" + txtxinghao.Text + "%' ";
                DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                gridControl4.DataSource = dt;
            }
            if (leixing == "技改")
            {
                string sql1 = "select id,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,生产部确认,生产部确认时间,当前状态,实际采购数量,附件名称,加工预计结束时间,工序外协,技术更改,工作令号,项目名称,设备名称 from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "'   ";
                DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                gridControl4.DataSource = dt;

            }
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            if (leixing == "加工")
            {
                string sql1 = "select id,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,生产部确认,生产部确认时间,当前状态,实际采购数量,附件名称,加工预计结束时间,工序外协,技术更改,工作令号,项目名称,设备名称 from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "' and   制造类型='自制零部件' ";
                DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                gridControl4.DataSource = dt;
            }

            if (leixing == "装配")
            {
                string sql1 = "select id,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,生产部确认,生产部确认时间,当前状态,实际采购数量,附件名称,加工预计结束时间,工序外协,技术更改,工作令号,项目名称,设备名称 from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "' and   制造类型='装配零部件' ";
                DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                gridControl4.DataSource = dt;
            }
            if (leixing == "技改")
            {
                string sql1 = "select id,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,生产部确认,生产部确认时间,当前状态,实际采购数量,附件名称,加工预计结束时间,工序外协,技术更改,工作令号,项目名称,设备名称 from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "'   ";
                DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                gridControl4.DataSource = dt;

            }
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            if (leixing == "加工")
            {
                string sql1 = "select id,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,生产部确认,生产部确认时间,当前状态,实际采购数量,附件名称,加工预计结束时间,工序外协,技术更改,工作令号,项目名称,设备名称 from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "' and   制造类型='自制零部件' and   名称 like  '%" + txtmingcheng.Text + "%' ";
                DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                gridControl4.DataSource = dt;
            }

            if (leixing == "装配")
            {
                string sql1 = "select id,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,生产部确认,生产部确认时间,当前状态,实际采购数量,附件名称,加工预计结束时间,工序外协,技术更改,工作令号,项目名称,设备名称 from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "' and   制造类型='装配零部件' and   名称 like  '%" + txtmingcheng.Text + "%' ";
                DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                gridControl4.DataSource = dt;
            }
            if (leixing == "技改")
            {
                string sql1 = "select id,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,生产部确认,生产部确认时间,当前状态,实际采购数量,附件名称,加工预计结束时间,工序外协,技术更改,工作令号,项目名称,设备名称 from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "'   ";
                DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                gridControl4.DataSource = dt;

            }
        }

        private void 转工序外协ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] a = gridView4.GetSelectedRows();
            if (a.Length == 0)
            {
                MessageBox.Show("请选中需要的行");
                return;
            }
            foreach (int i in a)
            {
                string id = gridView4.GetRowCellValue(i, "id").ToString();
                string sqlquary = "select * from tb_caigouliaodan where id='" + id + "'";
                DataTable dtq = SQLhelp.GetDataTable(sqlquary, CommandType.Text);
                string 工作令号 = dtq.Rows[0]["工作令号"].ToString();
                string 项目名称 = dtq.Rows[0]["项目名称"].ToString();
                string 设备名称 = dtq.Rows[0]["设备名称"].ToString();
                string 名称 = dtq.Rows[0]["名称"].ToString();
                string 型号 = dtq.Rows[0]["型号"].ToString();
                string 实际采购数量 = dtq.Rows[0]["实际采购数量"].ToString();


                if (leixing == "装配")
                {

                    string sql = "insert into tb_gonxuwaixieguanli(工作令号,项目名称,设备名称,名称,型号,实际采购数量,工序外协,工序外协时间,父id) values('" + 工作令号 + "','" + 项目名称 + "','" + 设备名称 + "','" +
                        名称 + "','" + 型号 + "','" + 实际采购数量 + "','0','" + DateTime.Now + "','" + id + "')";
                    SQLhelp.ExecuteScalar(sql, CommandType.Text);
                    MessageBox.Show("申请成功！");
                    string sql1 = "select id,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,生产部确认,生产部确认时间,当前状态,实际采购数量,附件名称,加工预计结束时间,工序外协,技术更改,工作令号,项目名称,设备名称 from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "' and   制造类型='装配零部件'  ";
                    DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                    gridControl4.DataSource = dt;

                }
                if (leixing == "加工")
                {
                    string sql = "insert into tb_gonxuwaixieguanli(工作令号,项目名称,设备名称,名称,型号,实际采购数量,工序外协,工序外协时间,父id) values('" + 工作令号 + "','" + 项目名称 + "','" + 设备名称 + "','" +
                        名称 + "','" + 型号 + "','" + 实际采购数量 + "','0','" + DateTime.Now + "','" + id + "')";
                    SQLhelp.ExecuteScalar(sql, CommandType.Text);
                    MessageBox.Show("申请成功！");
                    string sql1 = "select id,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,生产部确认,生产部确认时间,当前状态,实际采购数量,附件名称,加工预计结束时间,工序外协,技术更改,工作令号,项目名称,设备名称 from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "' and   制造类型='自制零部件'  ";
                    DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                    gridControl4.DataSource = dt;

                }

                if (leixing == "技改")
                {
                    string sql = "insert into tb_gonxuwaixieguanli(工作令号,项目名称,设备名称,名称,型号,实际采购数量,工序外协,工序外协时间,父id) values('" + 工作令号 + "','" + 项目名称 + "','" + 设备名称 + "','" +
                        名称 + "','" + 型号 + "','" + 实际采购数量 + "','0','" + DateTime.Now + "','" + id + "')";
                    SQLhelp.ExecuteScalar(sql, CommandType.Text);
                    MessageBox.Show("申请成功！");
                    string sql1 = "select id,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,生产部确认,生产部确认时间,当前状态,实际采购数量,附件名称,加工预计结束时间,工序外协,技术更改,工作令号,项目名称,设备名称 from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "'   ";
                    DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                    gridControl4.DataSource = dt;

                }





            }




            //    string id = dataGridViewX2.CurrentRow.Cells["id"].Value.ToString();
            //string sqlquary = "select * from tb_caigouliaodan where id='" + id + "'";
            //DataTable dtq = SQLhelp.GetDataTable(sqlquary, CommandType.Text);
            //string 工作令号 = dtq.Rows[0]["工作令号"].ToString();
            //string 项目名称 = dtq.Rows[0]["项目名称"].ToString();
            //string 设备名称 = dtq.Rows[0]["设备名称"].ToString();
            //string 名称 = dtq.Rows[0]["名称"].ToString();
            //string 型号 = dtq.Rows[0]["型号"].ToString();
            //string 实际采购数量 = dtq.Rows[0]["实际采购数量"].ToString();
            //if (leixing == "装配")
            //{

            //    string sql = "insert into tb_gonxuwaixieguanli(工作令号,项目名称,设备名称,名称,型号,实际采购数量,工序外协,工序外协时间,父id) values('" + 工作令号 + "','" + 项目名称 + "','" + 设备名称 + "','" +
            //        名称 + "','" + 型号 + "','" + 实际采购数量 + "','0','"+ DateTime.Now+"','"+id+"')";
            //    SQLhelp.ExecuteScalar(sql, CommandType.Text);
            //    MessageBox.Show("申请成功！");
            //    string sql1 = "select id,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,生产部确认,生产部确认时间,当前状态,实际采购数量,附件名称,加工预计结束时间,工序外协,技术更改,工作令号,项目名称,设备名称 from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "' and   制造类型='装配零部件'  ";
            //    DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            //    dataGridViewX2.DataSource = dt;

            //}
            //if (leixing == "加工")
            //{
            //    string sql = "insert into tb_gonxuwaixieguanli(工作令号,项目名称,设备名称,名称,型号,实际采购数量,工序外协,工序外协时间,父id) values('" + 工作令号 + "','" + 项目名称 + "','" + 设备名称 + "','" +
            //        名称 + "','" + 型号 + "','" + 实际采购数量 + "','0','" + DateTime.Now + "','" + id+ "')";
            //    SQLhelp.ExecuteScalar(sql, CommandType.Text);
            //    MessageBox.Show("申请成功！");
            //    string sql1 = "select id,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,生产部确认,生产部确认时间,当前状态,实际采购数量,附件名称,加工预计结束时间,工序外协,技术更改,工作令号,项目名称,设备名称 from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "' and   制造类型='自制零部件'  ";
            //    DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            //    dataGridViewX2.DataSource = dt;

            //}

            //if (leixing == "技改")
            //{
            //    string sql = "insert into tb_gonxuwaixieguanli(工作令号,项目名称,设备名称,名称,型号,实际采购数量,工序外协,工序外协时间,父id) values('" + 工作令号 + "','" + 项目名称 + "','" + 设备名称 + "','" +
            //        名称 + "','" + 型号 + "','" + 实际采购数量 + "','0','" + DateTime.Now + "','" + id + "')";
            //    SQLhelp.ExecuteScalar(sql, CommandType.Text);
            //    MessageBox.Show("申请成功！");
            //    string sql1 = "select id,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,生产部确认,生产部确认时间,当前状态,实际采购数量,附件名称,加工预计结束时间,工序外协,技术更改,工作令号,项目名称,设备名称 from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "'   ";
            //    DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            //    dataGridViewX2.DataSource = dt;

            //}



        }

        private void 转技术更改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] a = gridView4.GetSelectedRows();
            if (a.Length == 0)
            {
                MessageBox.Show("请选中需要的行");
                return;
            }
            foreach (int i in a)
            {
                if (leixing == "装配")
                {
                    string id = gridView4.GetRowCellValue(i, "id").ToString();

                    string sql = "update tb_caigouliaodan set 技术更改=0 where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql, CommandType.Text);
                    MessageBox.Show("申请成功！");
                    string sql1 = "select id,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,生产部确认,生产部确认时间,当前状态,实际采购数量,附件名称,加工预计结束时间,工序外协,技术更改,工作令号,项目名称,设备名称 from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "' and  制造类型='装配零部件'";
                    DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                    gridControl4.DataSource = dt;

                }
                if (leixing == "加工")
                {
                    string id = gridView4.GetRowCellValue(i, "id").ToString();
                    string sql = "update tb_caigouliaodan set 技术更改=0 where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql, CommandType.Text);
                    MessageBox.Show("申请成功！");
                    string sql1 = "select id,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,生产部确认,生产部确认时间,当前状态,实际采购数量,附件名称,加工预计结束时间,工序外协,技术更改,工作令号,项目名称,设备名称 from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "' and   制造类型='自制零部件'  ";
                    DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                    gridControl4.DataSource = dt;

                }

                if (leixing == "技改")
                {
                    string id = gridView4.GetRowCellValue(i, "id").ToString();
                    string sql = "update tb_caigouliaodan set 技术更改=0 where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql, CommandType.Text);
                    MessageBox.Show("申请成功！");
                    string sql1 = "select id,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,生产部确认,生产部确认时间,当前状态,实际采购数量,附件名称,加工预计结束时间,工序外协,技术更改,工作令号,项目名称,设备名称 from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "'   ";
                    DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                    gridControl4.DataSource = dt;

                }
            }
        }

        private void 转外协零部件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认转外协吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                int[] a = gridView4.GetSelectedRows();
                if (a.Length == 0)
                {
                    MessageBox.Show("请选中需要的行");
                    return;
                }
                foreach (int i in a)
                {
                    string aa = Convert.ToString(gridView4.GetRowCellValue(i, "制造类型"));
                    if (aa != "自制零部件")
                    {
                        MessageBox.Show("只有自制零部件才可以转外协，请重新确认！");
                        return;
                    }
                    if (aa == "自制零部件")
                    {
                        Frxiugailiaodan form1 = new Frxiugailiaodan();
                        form1.id = gridView4.GetRowCellValue(i, "id").ToString();
                        form1.ShowDialog();
                        string xiangmuming = xiangmumingcheng;
                        string shebei = shebeimingcheng;
                        string migncheng = gridView4.GetRowCellValue(i, "名称").ToString();
                        if (form1.DialogResult == DialogResult.OK)
                        {
                            string sendmessage = yonghu + "将" + gongzuolinghao + "\r\n" + xiangmuming + "  " + shebei + "的" + migncheng + "改成外协" + "\r\n" + "请物流部注意！";
                            NetWork3J NetWork3J = new NetWork3J(yonghu, "http://" + MyGlobal.ip + ":81/");
                            string sqlgetderp = "select 用户名 FROM tb_operator1 where 部门='物流部'";
                            DataTable mingdan = SQLhelp.GetDataTable(sqlgetderp, CommandType.Text);
                            NetWork3J.sendmessageById("聂燕", sendmessage);
                            for (int j = 0; j < mingdan.Rows.Count; j++)
                            {
                                string name = mingdan.Rows[j]["用户名"].ToString();
                                NetWork3J.sendmessageById(name, sendmessage);
                            }
                            string id = gridView4.GetRowCellValue(i, "id").ToString();
                            string sql = "update tb_caigouliaodan set 制造类型='自制转外协',流程状态='转物流部审批' where id='" + id + "'";
                            SQLhelp.ExecuteScalar(sql, CommandType.Text);
                            string gonglinghao = gridView4.GetRowCellValue(i, "工作令号").ToString();
                            string xuhao = gridView4.GetRowCellValue(i, "序号").ToString();
                            string bianma = gridView4.GetRowCellValue(i, "编码").ToString();
                            string xinghao = gridView4.GetRowCellValue(i, "型号").ToString();
                            string mingcheng = gridView4.GetRowCellValue(i, "名称").ToString();
                            string shuliang = gridView4.GetRowCellValue(i, "数量").ToString();
                            string danwei = gridView4.GetRowCellValue(i, "单位").ToString();
                            string shijicaigoushuliang = gridView4.GetRowCellValue(i, "实际采购数量").ToString();
                            string sql3 = "INSERT INTO tb_zizhizhuanwaixie(工作令号,项目名称,设备名称,序号,编码,型号,名称,单位,数量,类型,时间,实际采购数量,修改时间,修改内容) VALUES( '" + gonglinghao + "', '" + xiangmumingcheng + "', '" + shebeimingcheng + "','" + xuhao + "', '" + bianma + "', '" + xinghao + "', '" + mingcheng + "','" + danwei + "', '" + shuliang + "', '" + leixing + "', '" + shijian + "','" + shijicaigoushuliang + "','" + DateTime.Now + "','自制转外协')";
                            SQLhelp.ExecuteScalar(sql3, CommandType.Text);
                            MessageBox.Show("申请成功！");
                            string sql1 = "select id,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,生产部确认,生产部确认时间,当前状态,实际采购数量,附件名称,加工预计结束时间,工序外协,技术更改,工作令号,项目名称,设备名称 from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "' and   制造类型='自制零部件'  ";
                            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                            gridControl4.DataSource = dt;
                        }
                    }
                }
            }
        }

        private void 更改图纸ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name;

            long fileSize = 0;//文件大小
            string fileName = null;//文件名字
            string fileType = null;//文件类型
            byte[] files;//文件
            BinaryReader read = null;//二进制读取
            string mingcheng;
            string id = gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id").ToString();
            //打开对话框
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                name = dialog.FileName;
                FileInfo info = new FileInfo(name);
                //获得文件大小
                fileSize = info.Length;
                //提取文件名,三步走
                int index = info.FullName.LastIndexOf(".");
                fileName = info.FullName.Remove(index);
                fileName = fileName.Substring(fileName.LastIndexOf(@"\") + 1);
                mingcheng = fileName;
                //获得文件扩展名
                fileType = info.Extension.Replace(".", "");
                //把文件转换成二进制流
                files = new byte[Convert.ToInt32(fileSize)];
                FileStream file = new FileStream(name, FileMode.Open, FileAccess.Read);
                read = new BinaryReader(file);
                read.Read(files, 0, Convert.ToInt32(fileSize));
                string ConStr = "update tb_caigouliaodan  set 附件=@pic where id='" + id + "'";
                SQLhelp.ExecuteNonquery(ConStr, CommandType.Text, files);
                string sql = "update tb_caigouliaodan  set 附件名称='" + mingcheng + "',附件类型='" + fileType + "' where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);
                Reload();
            }
        }

        private void 打印预览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frdayinyulan form1 = new Frdayinyulan();
            string sql1 = "select 编码,型号,名称,单位,数量,类型,备注,制造类型 from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "' order by 序号  ";
            form1.gonggong1 = SQLhelp.GetDataTable(sql1, CommandType.Text); ;
            form1.ShowDialog();
        }

        private void 转ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认转派工单吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                int[] a = gridView4.GetSelectedRows();
                if (a.Length == 0)
                {
                    MessageBox.Show("请选中需要的行");
                    return;
                }
                foreach (int i in a)
                {
                    string id = Convert.ToString(this.gridView4.GetRowCellValue(i, "id"));
                    DateTime time = DateTime.Now;
                    string sql = "select * from tb_caigouliaodan where id='" + id + "'";
                    DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
                    DataRow dr = dt.Rows[0];
                    string sql1 = "insert into tb_Paigongdan (工作令号,项目名称,设备名称,序号,编码,型号,名称,单位,数量,类型,时间,制造类型,下达时间,下达人,状态,number) values('" + dr["工作令号"] + "','" + dr["项目名称"] + "','" + dr["设备名称"] + "','" + dr["序号"] + "','" + dr["编码"] + "','" + dr["型号"] + "','" + dr["名称"] + "','" + dr["单位"] + "','" + dr["数量"] + "','" + dr["类型"] + "','" + dr["时间"] + "','" + dr["制造类型"] + "','" + time + "','" + yonghu + "','0','" + id + "')";
                    SQLhelp.ExecuteScalar(sql1, CommandType.Text);

                    MessageBox.Show("转派工单成功！", "提示");
                }
            }
        }
        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string a = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id"));
            if (a == "")
            {
                MessageBox.Show("没有附件！");
                return;
            }
            if (a != null)
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
        }
        private void gridView4_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
    }
}


