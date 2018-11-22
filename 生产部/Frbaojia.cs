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

namespace 项目管理系统.生产部
{
    public partial class Frbaojia : DevExpress.XtraEditors.XtraForm
    {
        public Frbaojia()
        {
            InitializeComponent();
        }

        private long fileSize2 = 0;//文件大小
        private string fileName2 = null;//文件名字
        private string fileType2 = null;//文件类型
        private byte[] files2;//文件
        private BinaryReader read2 = null;//二进制读取
        public string lujing2;

        public DataTable dt;
        public string yonghu;
        public string id;
        public string dingwei;
        private void Frbaojia_Load(object sender, EventArgs e)
        {

        }

        private void btn_shangchuan_Click(object sender, EventArgs e)
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
            
            if (MessageBox.Show("确认提交吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                if (txtFujian.Text != "" && txtRengong.Text != "" && txtShijian.Text != "" && txtHaocai.Text != "")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string id = dt.Rows[i]["id"].ToString();
                        string sql1 = "update tb_caigouliaodan  set 到货审批附件=@pic where id ='" + id + "'  ";
                        SQLhelp.ExecuteNonquery(sql1, CommandType.Text, files2);

                        string mingcheng = "不合格审批提交附件" + fileName2;
                        string sql2 = "update tb_caigouliaodan  set 到货审批附件名称='" + mingcheng + "',到货审批附件类型='" + fileType2 + "'  where id ='" + id + "' ";
                        SQLhelp.ExecuteScalar(sql2, CommandType.Text);

                        string sql3 = "update tb_caigouliaodan set 提交时间='" + tijiaoshijian + "',提交人='" + yonghu + "',到货验收流程状态='5总经办审批' ,提交类型='提交不合格品流转数据' where id ='" + id + "'";
                        SQLhelp.ExecuteScalar(sql3, CommandType.Text);

                        string sql4 = "update tb_caigouliaodan set 人工数='" + txtRengong.Text + "',检验时间数='" + txtShijian.Text + "',特殊耗材='" + txtHaocai.Text + "' where id = '" + id + "'";
                        SQLhelp.ExecuteScalar(sql4, CommandType.Text);

                        string sql5 = "update tb_caigouliaodan set 报价总额 = (select 人工数*500  from tb_caigouliaodan where id ='" + id + "') + (select 检验时间数*250  from tb_caigouliaodan where id ='" + id + "') + (select 特殊耗材  from tb_caigouliaodan where id ='" + id + "') where id ='" + id + "'";
                        SQLhelp.ExecuteScalar(sql5, CommandType.Text);

                        string sql6 = "insert into tb_daohuojilu  (工作令号,项目名称,设备名称,名称,型号,单位,定位,不合格审批附件,不合格审批附件名称,不合格审批附件类型,到货数量,合格数量,不合格数量,提交人,提交时间,供应商返工,让步接受数,报废,自家返工,报价总额,不合格描述,供方名称,提交类型,实际采购数量)select 工作令号,项目名称,设备名称,名称,型号,单位,id ,到货审批附件,到货审批附件名称,到货审批附件类型,本次到货验收数量,合格数量,不合格数量,提交人,提交时间,供应商返工,让步接受数,报废,自家返工,报价总额,不合格描述,供方名称,提交类型,实际采购数量 from tb_caigouliaodan where id ='" + id + "'";
                        SQLhelp.ExecuteScalar(sql6, CommandType.Text);
                    }

                    MessageBox.Show("提交成功！");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    
                    string id1 = Convert.ToString(this.dt.Rows[0]["id"]);
                    string hetonghao = Convert.ToString(this.dt.Rows[0]["合同号"]);
                    string gongfangmingcheng = Convert.ToString(this.dt.Rows[0]["供方名称"]);
                                        
                    string sendmessage = yonghu + "  发起了一份" + hetonghao + "\r\n" + gongfangmingcheng + "  的不合格评审流程" + "\r\n" +
                  "请总经理审批！";
                    NetWork3J NetWork3J = new NetWork3J(yonghu, "http://" + MyGlobal.ip + ":81/");
                    NetWork3J.sendmessageById("庄卫星", sendmessage);
                    

                }
                
                else if (txtRengong.Text == "")
                {
                    MessageBox.Show("请填写人工数！");
                }
                else if (txtShijian.Text == "")
                {
                    MessageBox.Show("请填写检验时间数！");
                }
                else if(txtHaocai.Text == "") 
                {
                    MessageBox.Show("请填写特殊耗材！");
                }
                else 
                {
                    MessageBox.Show("请提交附件！");
                }
            }
                
        }

        private void txtRengong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46)                           //小数点
            {
                if (txtRengong.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(txtRengong.Text, out oldf);
                    b2 = float.TryParse(txtRengong.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

        private void txtShijian_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46)                           //小数点
            {
                if (txtShijian.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(txtShijian.Text, out oldf);
                    b2 = float.TryParse(txtShijian.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

        private void txtHaocai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46)                           //小数点
            {
                if (txtHaocai.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(txtHaocai.Text, out oldf);
                    b2 = float.TryParse(txtHaocai.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }
        public void jisuan()
        {
            float a, b, c;
            float.TryParse(txtRengong.Text, out a);
            float.TryParse(txtShijian.Text, out b);
            float.TryParse(txtHaocai.Text, out c);
            txtGongji.Text = (a * 500 + b * 250 + c).ToString();
        }

        private void txtGongji_TextChanged(object sender, EventArgs e)
        {
            jisuan();
        }

        private void txtRengong_TextChanged(object sender, EventArgs e)
        {
            if (txtRengong.Text != "")
            {
                jisuan();
            }
            else
            {
                return;
            }
        }

        private void txtShijian_TextChanged(object sender, EventArgs e)
        {
            if (txtShijian.Text != "")
            {
                jisuan();
            }
            else
            {
                return;
            }
        }

        private void txtHaocai_TextChanged(object sender, EventArgs e)
        {
            if (txtHaocai.Text != "")
            {
                jisuan();
            }
            else
            {
                return;
            }
        }
    }
}
