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
    public partial class Frfujian : DevExpress.XtraEditors.XtraForm
    {
        public Frfujian()
        {
            InitializeComponent();
        }
        private long fileSize2 = 0;//文件大小
        private string fileName2 = null;//文件名字
        private string fileType2 = null;//文件类型
        private byte[] files2;//文件
        private BinaryReader read2 = null;//二进制读取
        public string lujing2;

        public string id;
        public string yonghu;
        public DataTable dt;
        private void Frfujian_Load(object sender, EventArgs e)
        {

        }

        private void btnShangchuan_Click(object sender, EventArgs e)
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
                        txtFujian.Text = fileName2;
                       
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

        private void btnTijiao_Click(object sender, EventArgs e)
        {
            string tijiaoshijian = DateTime.Now.ToString();
            if (yonghu == "张占生")
            {
                if (txtFujian.Text == "")
                {
                    MessageBox.Show("请提交附件！");
                    return;
                }
                else
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string id = dt.Rows[i]["id"].ToString();
                        string buhegeshuliang = dt.Rows[i]["不合格数量"].ToString();

                        string sql12 = "update tb_caigouliaodan  set 到货审批附件=@pic where id ='" + id + "'  ";
                        SQLhelp.ExecuteNonquery(sql12, CommandType.Text, files2);


                        string sql13 = "update tb_caigouliaodan  set 到货审批附件名称='" + fileName2 + "',到货审批附件类型='" + fileType2 + "'  where id ='" + id + "' ";
                        SQLhelp.ExecuteScalar(sql13, CommandType.Text);

                        string sql14 = "update tb_caigouliaodan set 提交时间='" + tijiaoshijian + "',提交人='" + yonghu + "' where id ='" + id + "'";
                        SQLhelp.ExecuteScalar(sql14, CommandType.Text);

                        string sql7 = "update tb_caigouliaodan set 到货验收流程状态='3整机到货',提交类型='质监员进行检验' where id ='" + id + "'";
                        SQLhelp.ExecuteScalar(sql7, CommandType.Text);

                        /*
                        if (Convert.ToInt32(buhegeshuliang) == 0)
                        {
                            string sql7 = "update tb_caigouliaodan set 到货验收流程状态='3到仓库',提交类型='质监员进行检验' where id ='" + id + "'";
                            SQLhelp.ExecuteScalar(sql7, CommandType.Text);
                        }
                        else
                        {
                            string sql6 = "update tb_caigouliaodan set 到货验收流程状态='4不合格待评审',提交类型='质监员进行检验' where id ='" + id + "'";
                            SQLhelp.ExecuteScalar(sql6, CommandType.Text);
                        }
                        */

                        string sql20 = "insert into tb_daohuojilu  (工作令号,项目名称,设备名称,名称,供方名称,型号,单位,定位,质监员附件,质监员附件名称,质监员附件类型,到货数量,合格数量,不合格数量,提交人,提交时间,不合格描述,提交类型,实际采购数量)select 工作令号,项目名称,设备名称,名称,供方名称,型号,单位,id ,到货审批附件,到货审批附件名称,到货审批附件类型,本次到货验收数量,合格数量,不合格数量,提交人,提交时间,不合格描述,提交类型,实际采购数量  from tb_caigouliaodan where id ='" + id + "'";
                        SQLhelp.ExecuteScalar(sql20, CommandType.Text);

                    }
                    MessageBox.Show("提交成功！");
                    this.DialogResult = DialogResult.OK;
                    this.Close();

                    
                }
            }
            
            else
            {
                if (txtFujian.Text != "")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string id = dt.Rows[i]["id"].ToString();
                        string buhegeshuliang = dt.Rows[i]["不合格数量"].ToString();

                        string sql12 = "update tb_caigouliaodan  set 到货审批附件=@pic where id ='" + id + "'  ";
                        SQLhelp.ExecuteNonquery(sql12, CommandType.Text, files2);


                        string sql13 = "update tb_caigouliaodan  set 到货审批附件名称='" + fileName2 + "',到货审批附件类型='" + fileType2 + "'  where id ='" + id + "' ";
                        SQLhelp.ExecuteScalar(sql13, CommandType.Text);

                        string sql14 = "update tb_caigouliaodan set 提交时间='" + tijiaoshijian + "',提交人='" + yonghu + "' where id ='" + id + "'";
                        SQLhelp.ExecuteScalar(sql14, CommandType.Text);

                        if (Convert.ToInt32(buhegeshuliang) == 0)
                        {
                            string sql7 = "update tb_caigouliaodan set 到货验收流程状态='3到仓库',提交类型='质监员进行检验' where id ='" + id + "'";
                            SQLhelp.ExecuteScalar(sql7, CommandType.Text);
                        }
                        else
                        {
                            string sql6 = "update tb_caigouliaodan set 到货验收流程状态='4不合格待评审',提交类型='质监员进行检验' where id ='" + id + "'";
                            SQLhelp.ExecuteScalar(sql6, CommandType.Text);
                        }

                        string sql20 = "insert into tb_daohuojilu  (工作令号,项目名称,设备名称,名称,供方名称,型号,单位,定位,质监员附件,质监员附件名称,质监员附件类型,到货数量,合格数量,不合格数量,提交人,提交时间,不合格描述,提交类型,实际采购数量)select 工作令号,项目名称,设备名称,名称,供方名称,型号,单位,id ,到货审批附件,到货审批附件名称,到货审批附件类型,本次到货验收数量,合格数量,不合格数量,提交人,提交时间,不合格描述,提交类型,实际采购数量  from tb_caigouliaodan where id ='" + id + "'";
                        SQLhelp.ExecuteScalar(sql20, CommandType.Text);

                    }
                    MessageBox.Show("提交成功！");
                    this.DialogResult = DialogResult.OK;
                    this.Close();

                    string id1 = Convert.ToString(this.dt.Rows[0]["id"]);
                    string hetonghao = Convert.ToString(this.dt.Rows[0]["合同号"]);
                    string gongfangmingcheng = Convert.ToString(this.dt.Rows[0]["供方名称"]);

                    string sql3 = "select 到货检验人 from  tb_caigouliaodan  where id='" + id + "'";
                    string jianyanrenyuan = Convert.ToString(SQLhelp.ExecuteScalar(sql3, CommandType.Text));

                    string sql4 = "select 部门 from tb_operator where 用户名='" + jianyanrenyuan + "'";
                    string bumen = Convert.ToString(sqlhelp111.ExecuteScalar(sql4, CommandType.Text));

                    if (bumen == "精工事业部")
                    {
                        string sendmessage = yonghu + "  发起了一份" + hetonghao + "\r\n" + gongfangmingcheng + "  的不合格评审流程" + "\r\n" +
                  "请不合格评审员袁鹏评审！";
                        NetWork3J NetWork3J = new NetWork3J(yonghu, "http://" + MyGlobal.ip + ":81/");
                        NetWork3J.sendmessageById("袁鹏", sendmessage);
                    }
                    else
                    {
                        string sendmessage = yonghu + "  发起了一份" + hetonghao + "\r\n" + gongfangmingcheng + "  的不合格评审流程" + "\r\n" +
                  "请不合格评审员吴贞国评审！";
                        NetWork3J NetWork3J = new NetWork3J(yonghu, "http://" + MyGlobal.ip + ":81/");
                        NetWork3J.sendmessageById("吴贞国", sendmessage);
                    }
                }
                else
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string id = dt.Rows[i]["id"].ToString();
                        string buhegeshuliang = dt.Rows[i]["不合格数量"].ToString();
                        

                        string sql14 = "update tb_caigouliaodan set 提交时间='" + tijiaoshijian + "',提交人='" + yonghu + "' where id ='" + id + "'";
                        SQLhelp.ExecuteScalar(sql14, CommandType.Text);

                        if (Convert.ToInt32(buhegeshuliang) == 0)
                        {
                            string sql7 = "update tb_caigouliaodan set 到货验收流程状态='3到仓库',提交类型='质监员进行检验' where id ='" + id + "'";
                            SQLhelp.ExecuteScalar(sql7, CommandType.Text);
                        }
                        else
                        {
                            string sql6 = "update tb_caigouliaodan set 到货验收流程状态='4不合格待评审',提交类型='质监员进行检验' where id ='" + id + "'";
                            SQLhelp.ExecuteScalar(sql6, CommandType.Text);
                        }

                        string sql20 = "insert into tb_daohuojilu  (工作令号,项目名称,设备名称,名称,供方名称,型号,单位,定位,质监员附件,质监员附件名称,质监员附件类型,到货数量,合格数量,不合格数量,提交人,提交时间,不合格描述,提交类型,实际采购数量)select 工作令号,项目名称,设备名称,名称,供方名称,型号,单位,id ,到货审批附件,到货审批附件名称,到货审批附件类型,本次到货验收数量,合格数量,不合格数量,提交人,提交时间,不合格描述,提交类型,实际采购数量  from tb_caigouliaodan where id ='" + id + "'";
                        SQLhelp.ExecuteScalar(sql20, CommandType.Text);

                    }
                    MessageBox.Show("提交成功！");
                    this.DialogResult = DialogResult.OK;
                    this.Close();

                    string id1 = Convert.ToString(this.dt.Rows[0]["id"]);
                    string hetonghao = Convert.ToString(this.dt.Rows[0]["合同号"]);
                    string gongfangmingcheng = Convert.ToString(this.dt.Rows[0]["供方名称"]);

                    string sql3 = "select 到货检验人 from  tb_caigouliaodan  where id='" + id + "'";
                    string jianyanrenyuan = Convert.ToString(SQLhelp.ExecuteScalar(sql3, CommandType.Text));

                    string sql4 = "select 部门 from tb_operator where 用户名='" + jianyanrenyuan + "'";
                    string bumen = Convert.ToString(sqlhelp111.ExecuteScalar(sql4, CommandType.Text));

                    if (bumen == "精工事业部")
                    {
                        string sendmessage = yonghu + "  发起了一份" + hetonghao + "\r\n" + gongfangmingcheng + "  的不合格评审流程" + "\r\n" +
                  "请不合格评审员袁鹏评审！";
                        NetWork3J NetWork3J = new NetWork3J(yonghu, "http://" + MyGlobal.ip + ":81/");
                        NetWork3J.sendmessageById("袁鹏", sendmessage);
                    }
                    else
                    {
                        string sendmessage = yonghu + "  发起了一份" + hetonghao + "\r\n" + gongfangmingcheng + "  的不合格评审流程" + "\r\n" +
                  "请不合格评审员吴贞国评审！";
                        NetWork3J NetWork3J = new NetWork3J(yonghu, "http://" + MyGlobal.ip + ":81/");
                        NetWork3J.sendmessageById("吴贞国", sendmessage);
                    }
                }
                
            }
        }
        
    }
}
