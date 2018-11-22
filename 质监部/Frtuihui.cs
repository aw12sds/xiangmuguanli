using NetWork.util;
using NetWorkLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.质监部
{
    public partial class Frtuihui : Form
    {
        public Frtuihui()
        {
            InitializeComponent();
        }
        public string id;
        public DataTable dt;
        public string yonghu;

        private long fileSize2 = 0;//文件大小
        private string fileName2 = null;//文件名字
        private string fileType2 = null;//文件类型
        private byte[] files2;//文件
        private BinaryReader read2 = null;//二进制读取
        public string lujing2;
        private void Frtuihui_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string tijiaoshijian = DateTime.Now.ToString();
            if (yonghu == "张占生")
            {
                if (txtfujian.Text == "")
                {
                    MessageBox.Show("请上传附件！");
                    return;
                }
                else
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string id = dt.Rows[i]["id"].ToString();
                        string sql2 = "update tb_caigouliaodan  set 到货审批附件=@pic where id ='" + id + "'  ";
                        SQLhelp.ExecuteNonquery(sql2, CommandType.Text, files2);


                        string sql3 = "update tb_caigouliaodan  set 到货审批附件名称='" + fileName2 + "',到货审批附件类型='" + fileType2 + "'  where id ='" + id + "' ";
                        SQLhelp.ExecuteScalar(sql3, CommandType.Text);

                        string sql1 = "update tb_caigouliaodan set 提交类型='质监员退回',到货验收流程状态='7再发起',提交人='"+yonghu+"',提交时间='"+tijiaoshijian+"' where id ='" + id + "'";
                        SQLhelp.ExecuteScalar(sql1, CommandType.Text);

                        string sql20 = "insert into tb_daohuojilu  (工作令号,项目名称,设备名称,名称,供方名称,型号,单位,定位,质监员附件,质监员附件名称,质监员附件类型,到货数量,合格数量,不合格数量,提交人,提交时间,不合格描述,提交类型,实际采购数量,退回原因)select 工作令号,项目名称,设备名称,名称,供方名称,型号,单位,id ,到货审批附件,到货审批附件名称,到货审批附件类型,本次到货验收数量,合格数量,不合格数量,提交人,提交时间,不合格描述,提交类型,实际采购数量,退回原因  from tb_caigouliaodan where id ='" + id + "'";
                        SQLhelp.ExecuteScalar(sql20, CommandType.Text);

                    }
                }
                
                MessageBox.Show("提交成功！");
                this.DialogResult = DialogResult.OK;
                this.Close();

                string id1 = Convert.ToString(this.dt.Rows[0]["id"]);
                string hetonghao = Convert.ToString(this.dt.Rows[0]["合同号"]);
                string gongfangmingcheng = Convert.ToString(this.dt.Rows[0]["供方名称"]);

                string sql13 = "select 物流员 from  tb_caigouliaodan  where id='" + id1 + "'";
                string jianyanyuan = Convert.ToString(SQLhelp.ExecuteScalar(sql13, CommandType.Text));

                string sendmessage = yonghu + "  退回了一份" + hetonghao + "\r\n" + gongfangmingcheng + " 的到货验收流程" + "\r\n" +
                  "请物流员" + jianyanyuan + "查看！";
                NetWork3J NetWork3J = new NetWork3J(yonghu, "http://" + MyGlobal.ip + ":81/");
                NetWork3J.sendmessageById(jianyanyuan, sendmessage);

            }
           
            else
            {
                bool b = false;
                if (txtfujian.Text != "")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string id = dt.Rows[i]["id"].ToString();
                        string sql2 = "update tb_caigouliaodan  set 到货审批附件=@pic where id ='" + id + "'  ";
                        SQLhelp.ExecuteNonquery(sql2, CommandType.Text, files2);


                        string sql3 = "update tb_caigouliaodan  set 到货审批附件名称='" + fileName2 + "',到货审批附件类型='" + fileType2 + "'  where id ='" + id + "' ";
                        SQLhelp.ExecuteScalar(sql3, CommandType.Text);

                        string sql1 = "update tb_caigouliaodan set 提交类型='质监员退回',到货验收流程状态='7再发起',提交人='" + yonghu + "',提交时间='" + tijiaoshijian + "' where id ='" + id + "'";
                        SQLhelp.ExecuteScalar(sql1, CommandType.Text);

                        string sql20 = "insert into tb_daohuojilu  (工作令号,项目名称,设备名称,名称,供方名称,型号,单位,定位,质监员附件,质监员附件名称,质监员附件类型,到货数量,合格数量,不合格数量,提交人,提交时间,不合格描述,提交类型,实际采购数量,退回原因)select 工作令号,项目名称,设备名称,名称,供方名称,型号,单位,id ,到货审批附件,到货审批附件名称,到货审批附件类型,本次到货验收数量,合格数量,不合格数量,提交人,提交时间,不合格描述,提交类型,实际采购数量,退回原因  from tb_caigouliaodan where id ='" + id + "'";
                        SQLhelp.ExecuteScalar(sql20, CommandType.Text);

                        b = true;
                    }
                    if (b)
                    {
                        MessageBox.Show("提交成功！");
                        this.DialogResult = DialogResult.OK;
                        this.Close();

                        string id1 = Convert.ToString(this.dt.Rows[0]["id"]);
                        string hetonghao = Convert.ToString(this.dt.Rows[0]["合同号"]);
                        string gongfangmingcheng = Convert.ToString(this.dt.Rows[0]["供方名称"]);

                        string sql13 = "select 物流员 from  tb_caigouliaodan  where id='" + id1 + "'";
                        string jianyanyuan = Convert.ToString(SQLhelp.ExecuteScalar(sql13, CommandType.Text));

                        string sendmessage = yonghu + "  退回了一份" + hetonghao + "\r\n" + gongfangmingcheng + " 的到货验收流程" + "\r\n" +
                          "请物流员" + jianyanyuan + "查看！";
                        NetWork3J NetWork3J = new NetWork3J(yonghu, "http://" + MyGlobal.ip + ":81/");
                        NetWork3J.sendmessageById(jianyanyuan, sendmessage);
                    }
                }
                else
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string id = dt.Rows[i]["id"].ToString();
                        

                        string sql1 = "update tb_caigouliaodan set 提交类型='质监员退回',到货验收流程状态='7再发起',提交人='" + yonghu + "',提交时间='" + tijiaoshijian + "' where id ='" + id + "'";
                        SQLhelp.ExecuteScalar(sql1, CommandType.Text);

                        string sql20 = "insert into tb_daohuojilu  (工作令号,项目名称,设备名称,名称,供方名称,型号,单位,定位,质监员附件,质监员附件名称,质监员附件类型,到货数量,合格数量,不合格数量,提交人,提交时间,不合格描述,提交类型,实际采购数量,退回原因)select 工作令号,项目名称,设备名称,名称,供方名称,型号,单位,id ,到货审批附件,到货审批附件名称,到货审批附件类型,本次到货验收数量,合格数量,不合格数量,提交人,提交时间,不合格描述,提交类型,实际采购数量,退回原因  from tb_caigouliaodan where id ='" + id + "'";
                        SQLhelp.ExecuteScalar(sql20, CommandType.Text);

                        b = true;
                    }
                    if (b)
                    {
                        MessageBox.Show("提交成功！");
                        this.DialogResult = DialogResult.OK;
                        this.Close();

                        string id1 = Convert.ToString(this.dt.Rows[0]["id"]);
                        string hetonghao = Convert.ToString(this.dt.Rows[0]["合同号"]);
                        string gongfangmingcheng = Convert.ToString(this.dt.Rows[0]["供方名称"]);

                        string sql13 = "select 物流员 from  tb_caigouliaodan  where id='" + id1 + "'";
                        string jianyanyuan = Convert.ToString(SQLhelp.ExecuteScalar(sql13, CommandType.Text));

                        string sendmessage = yonghu + "  退回了一份" + hetonghao + "\r\n" + gongfangmingcheng + " 的到货验收流程" + "\r\n" +
                          "请物流员" + jianyanyuan + "查看！";
                        NetWork3J NetWork3J = new NetWork3J(yonghu, "http://" + MyGlobal.ip + ":81/");
                        NetWork3J.sendmessageById(jianyanyuan, sendmessage);
                    }
                }
                
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                //打开对话框
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo info = new FileInfo(dialog.FileName);
                    //获得文件扩展名
                    fileType2 = info.Extension.Replace(".", "");
                    if (fileType2 == "pdf")
                    {
                        //获得文件大小
                        fileSize2 = info.Length;
                        //提取文件名,三步走
                        int index = info.FullName.LastIndexOf(".");
                        fileName2 = info.FullName.Remove(index);
                        fileName2 = fileName2.Substring(fileName2.LastIndexOf(@"\") + 1);
                        txtfujian.Text = fileName2;

                        //把文件转换成二进制流
                        files2 = new byte[Convert.ToInt32(fileSize2)];
                        FileStream file1 = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read);
                        read2 = new BinaryReader(file1);
                        read2.Read(files2, 0, Convert.ToInt32(fileSize2));
                    }
                    else
                    {
                        MessageBox.Show("必须上传PDF格式的文件！");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("选择文件时候发生了　　" + ex.Message);
            }
        }
    }
}
