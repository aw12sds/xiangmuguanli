using DevComponents.DotNetBar;
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
using xiangmuguanli.技术部;

namespace 项目管理系统.技术部
{
    public partial class FrTianjiafujian : Office2007Form
    {
        public FrTianjiafujian()
        {
            this.EnableGlass = false;
            InitializeComponent();
            fpro = new FrJindutiao();
        }
        private long fileSize = 0;//文件大小
        private string fileName = null;//文件名字
        private string fileType = null;//文件类型
        private byte[] files;//文件
        private BinaryReader read = null;//二进制读取
        public string mingcheng;
        public string gonglinghao;
        public string xiangmu;
        public string shebei;
        public string shijian;
        public FrJindutiao fpro = null;
        public string zhonglei;
        public string id;
       

        private void FrTianjiafujian_Load(object sender, EventArgs e)
        {

        }
    

        private void buttonX3_Click(object sender, EventArgs e)
        {
            try
            {
                //打开对话框
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtName.Text = dialog.FileName;
                    FileInfo info = new FileInfo(@txtName.Text);
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
                    FileStream file = new FileStream(txtName.Text, FileMode.Open, FileAccess.Read);
                    read = new BinaryReader(file);
                    read.Read(files, 0, Convert.ToInt32(fileSize));

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("选择文件时候发生了　　" + ex.Message);
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
           

            if (MessageBox.Show("确认提交吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                buttonX1.Enabled = false;

                this.backgroundWorker1.RunWorkerAsync();
                
                fpro.ShowDialog(this);

            }

            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (zhonglei == "项目")
            {

                if (txtName.Text != "")
                {
                    string ConStr = "update tb_jishubumen  set 附件=@pic where 工作令号='" + gonglinghao + "' and 项目名称='" + xiangmu + "' and 时间='" + shijian + "'";
                    SQLhelp.ExecuteNonquery(ConStr, CommandType.Text, files);
                }
                string sql = "update tb_jishubumen  set 附件名称='" + mingcheng + "',附件类型='" + fileType + "' where 工作令号='" + gonglinghao + "' and 项目名称='" + xiangmu + "' and 时间='" + shijian + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);
                MessageBox.Show("提交成功！", "软件提示");
               DialogResult = DialogResult.OK;


            }

            if (zhonglei == "料单")
            {
                if (id != "")
                {
                    try
                    {
                        if (txtName.Text != "")
                        {
                            string ConStr = "update tb_caigouliaodan  set 附件=@pic where id='" + id + "'";
                            SQLhelp.ExecuteNonquery(ConStr, CommandType.Text, files);
                        }
                        string sql = "update tb_caigouliaodan  set 附件名称='" + mingcheng + "',附件类型='" + fileType + "' where id='" + id + "'";
                        SQLhelp.ExecuteScalar(sql, CommandType.Text);

                        MessageBox.Show("提交成功！", "软件提示");
                        DialogResult = DialogResult.OK;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("提交 " + fileName + " 时候发生了　　" + ex.Message);
                    }
                }
                if (id == "")
                {
                    MessageBox.Show("请先保存料单再添加附件！");
                    return;

                }


            }

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            buttonX1.Enabled = true;
            
            fpro.Close();
            this.Close();
        }
    }
}
