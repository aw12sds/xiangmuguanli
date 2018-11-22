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
using 项目管理系统.个人管理;

namespace 项目管理系统.生产部
{
    public partial class Frwujinfucai : Office2007Form
    {
        public Frwujinfucai()
        {
            InitializeComponent();
        }
        public string yonghu;
        private void Frwujinfucai_Load(object sender, EventArgs e)
        {
            Reload();
        }
        public void Reload()
        {
            string sql1 = "select  id,工作令号,编码,型号,名称,单位,数量,类型,要求到货日期1,申购人,备注,当前状态,采购类型,收到料单日期,合同号,供方名称,流程状态,驳回原因   from  tb_caigouliaodan where 采购类型 IS NOT NULL and 到货情况=0 order by 收到料单日期 desc";
            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridControl1.DataSource = dt;
            gridView1.Columns["id"].Visible = false;

            string sql11 = "select  id,工作令号,编码,型号,名称,单位,数量,类型,要求到货日期1,申购人,备注,当前状态,采购类型,收到料单日期,合同号,供方名称 from  tb_caigouliaodan where 采购类型 IS NOT NULL and 到货情况=1";
            DataTable dt1 = SQLhelp.GetDataTable(sql11, CommandType.Text);
            gridControl2.DataSource = dt1;
            gridView2.Columns["id"].Visible = false;

        }
        private void buttonItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("只能申请五金辅材，原材料申购必须走工艺申购！下到五金辅材将被考核", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Frgerencaigoushenqing form1 = new Frgerencaigoushenqing();
                form1.yonghu = yonghu;
                form1.leixing = "五金辅材";
                form1.ShowDialog();
                if (form1.DialogResult == DialogResult.OK)
                {
                    Reload();

                }
            }

        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            string sql = "select  id,工作令号,编码,型号,名称,单位,数量,类型,要求到货日期1,申购人,备注,当前状态,采购类型,收到料单日期,合同号,供方名称,流程状态,驳回原因   from  tb_caigouliaodan where 采购类型 IS NOT NULL and 到货情况=0 and  型号 like '%" + txtxinghao.Text.Trim() + "%'";

            gridControl1.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
            gridView1.Columns["id"].Visible = false;
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            string sql = "select  id,工作令号,编码,型号,名称,单位,数量,类型,要求到货日期1,申购人,备注,当前状态,采购类型,收到料单日期,合同号,供方名称,流程状态,驳回原因  from  tb_caigouliaodan where 采购类型 IS NOT NULL and 到货情况=0 and  名称 like '%" + txtmingcheng.Text.Trim() + "%'";

            gridControl1.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
            gridView1.Columns["id"].Visible = false;
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            string sql = "select  id,工作令号,编码,型号,名称,单位,数量,类型,要求到货日期1,申购人,备注,当前状态,采购类型,收到料单日期,合同号,供方名称,流程状态,驳回原因   from  tb_caigouliaodan where 采购类型 IS NOT NULL and 到货情况=0 and  名称 like '%" + txtmingcheng.Text.Trim() + "%' and  型号 like '%" + txtxinghao.Text.Trim() + "%'";

            gridControl1.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
            gridView1.Columns["id"].Visible = false;
        }


        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string hetonghao = gridView1.GetRowCellValue(i, "合同号").ToString();
                if (hetonghao == "")
                {
                    string id = gridView1.GetRowCellValue(i, "id").ToString();
                    string bianma = gridView1.GetRowCellValue(i, "编码").ToString();
                    string shuliang = gridView1.GetRowCellValue(i, "数量").ToString();
                    string xinghao = gridView1.GetRowCellValue(i, "型号").ToString();
                    string leixing = gridView1.GetRowCellValue(i, "类型").ToString();
                    string mingcheng = gridView1.GetRowCellValue(i, "名称").ToString();
                    string beizhu = gridView1.GetRowCellValue(i, "备注").ToString();
                    string sql = "update tb_caigouliaodan   set 编码='" + bianma + "',数量='" + shuliang + "',实际采购数量='" + shuliang + "',型号='" + xinghao + "',名称='" + mingcheng + "',备注='" + beizhu + "',类型='" + leixing + "' where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql, CommandType.Text);
                }


            }
            MessageBox.Show("保存成功！");
            Reload();

        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            //Frgerencaigoushenqing form1 = new Frgerencaigoushenqing();
            //form1.yonghu = yonghu;
            //form1.leixing = "原材料";

            //form1.ShowDialog();
            //if (form1.DialogResult == DialogResult.OK)
            //{
            //    Reload();

            //}
        }
        private long fileSize = 0;//文件大小
        private string fileName = null;//文件名字
        private string fileType = null;//文件类型
        private byte[] files;//文件
        private BinaryReader read = null;//二进制读取
        public string mingcheng;
        private void 添加附件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();

            //打开对话框
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo info = new FileInfo(dialog.FileName);
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
                FileStream file = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read);
                read = new BinaryReader(file);
                read.Read(files, 0, Convert.ToInt32(fileSize));

                string ConStr = "update tb_caigouliaodan  set 附件=@pic where id='" + id + "'";
                SQLhelp.ExecuteNonquery(ConStr, CommandType.Text, files);

                string sql = "update tb_caigouliaodan set 附件名称='" + mingcheng + "',附件类型='" + fileType + "' where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);
                MessageBox.Show("上传成功！");
            }
        }

        private void 查看附件ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();

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

        private void 保存ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string hetonghao = gridView1.GetRowCellValue(i, "合同号").ToString();
                if (hetonghao == "")
                {
                    string id = gridView1.GetRowCellValue(i, "id").ToString();


                    string leixing = gridView1.GetRowCellValue(i, "类型").ToString();

                    string beizhu = gridView1.GetRowCellValue(i, "备注").ToString();
                    string sql = "update tb_caigouliaodan   set 备注='" + beizhu + "',类型='" + leixing + "' where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql, CommandType.Text);
                }
            }
            MessageBox.Show("保存成功！");
            Reload();
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string liaodanleixing = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "采购类型"));
            string mingcheng = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "名称"));
            string xinghao = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "型号"));
            string sendmessage = yonghu + " 催促 " + liaodanleixing + "  " + "+" + mingcheng + "\r\n" + xinghao + "尽快购买！";
            if (liaodanleixing == "原材料")
            {
                NetWork3J NetWork3J = new NetWork3J(yonghu, "http://" + MyGlobal.ip + ":81/");
                string sqlgetderp = "select 用户名 FROM tb_operator where 原材料提示=1";
                DataTable mingdan = sqlhelp111.GetDataTable(sqlgetderp, CommandType.Text);

                for (int i = 0; i < mingdan.Rows.Count; i++)
                {
                    string name = mingdan.Rows[i]["用户名"].ToString();
                    NetWork3J.sendmessageById(name, sendmessage);
                }
                MessageBox.Show("已提醒！");
            }
            if (liaodanleixing == "五金辅材")
            {

                NetWork3J NetWork3J = new NetWork3J(yonghu, "http://" + MyGlobal.ip + ":81/");
                string sqlgetderp = "select 用户名 FROM tb_operator where 五金辅材提示=1";
                DataTable mingdan = sqlhelp111.GetDataTable(sqlgetderp, CommandType.Text);
                for (int i = 0; i < mingdan.Rows.Count; i++)
                {
                    string name = mingdan.Rows[i]["用户名"].ToString();
                    NetWork3J.sendmessageById(name, sendmessage);
                }

                MessageBox.Show("已提醒！");
            }

        }
    }
}
