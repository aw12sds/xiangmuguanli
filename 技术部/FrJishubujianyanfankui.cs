using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.技术部
{
    public partial class FrJishubujianyanfankui : Office2007Form
    {
        public FrJishubujianyanfankui()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string gongzuolinghao;
        public string xiangmumingcheng;
        public string shijian;
        public int panduan;
        public string id1;
        public string zhonglei;
        public string yonghu;
        public string biaoji;
        public string shebeimingcheng;

        private long fileSize = 0;//文件大小
        private string fileName = null;//文件名字
        private string fileType = null;//文件类型
        private byte[] files;//文件
        private BinaryReader read = null;//二进制读取
        public string lujing;
        private void FrJishubujianyanfankui_Load(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
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
                    //txtMingcheng.Text = fileName;
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

        private void buttonX2_Click(object sender, EventArgs e)
        {

            if (zhonglei == "到货验收")
            {
                if (radioButton1.Checked == true)

                {
                    if (MessageBox.Show("确认上传吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        DateTime huifu = DateTime.Now;

                        try
                        {
                            string sql2 = "insert into tb_liuchengxiangxi(流程类型,创建人,创建时间,流程标记,工作令号,项目名称,设备名称,时间,流程内容) values('到货验收流程','" + yonghu + "','" + huifu + "','" + biaoji + "','" + gongzuolinghao + "','" + xiangmumingcheng + "','" + shebeimingcheng + "','" + shijian + "','" + txtluoshiqingkuang.Text + "') ";
                            SQLhelp.ExecuteScalar(sql2, CommandType.Text);




                            string sql4 = "update tb_zongliucheng  set 流程状态='到达质监部'  where id='" + id1 + "' ";
                            SQLhelp.ExecuteScalar(sql4, CommandType.Text);

                            string sql41 = "update tb_caigouliaodan  set 流程状态='到达质监部' where  工作令号='" + gongzuolinghao + "' and  项目名称='" + xiangmumingcheng + "'  and  设备名称='" + shebeimingcheng + "' and  到货验收流程标记='" + biaoji + "'";
                            SQLhelp.ExecuteScalar(sql41, CommandType.Text);



                            if (txtName.Text != "")
                            {
                                string sql3 = "update tb_liuchengxiangxi  set 附件=@pic,附件名称='" + fileName + "',附件类型='" + fileType + "' where 创建时间= '" + huifu + "' and  工作令号='" + gongzuolinghao + "' and  项目名称='" + xiangmumingcheng + "'  and  设备名称='" + shebeimingcheng + "' and  流程标记='" + biaoji + "'";
                                SQLhelp.ExecuteNonquery(sql3, CommandType.Text, files);
                            }
                            MessageBox.Show("提交成功！");
                            this.DialogResult = DialogResult.OK;
                            this.Close();

                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show("提交 " + fileName + " 时候发生了　　" + ex.Message);
                        }


                    }
                }
                if (radioButton2.Checked == true)

                {

                    if (MessageBox.Show("确认上传吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        DateTime huifu = DateTime.Now;

                        try
                        {
                            string sql2 = "insert into tb_liuchengxiangxi(流程类型,创建人,创建时间,流程标记,工作令号,项目名称,设备名称,时间,流程内容) values('到货验收流程','" + yonghu + "','" + huifu + "','" + biaoji + "','" + gongzuolinghao + "','" + xiangmumingcheng + "','" + shebeimingcheng + "','" + shijian + "','" + txtluoshiqingkuang.Text + "') ";
                            SQLhelp.ExecuteScalar(sql2, CommandType.Text);




                            string sql4 = "update tb_zongliucheng  set 流程状态='到达物流部'  where id='" + id1 + "' ";
                            SQLhelp.ExecuteScalar(sql4, CommandType.Text);

                            string sql41 = "update tb_caigouliaodan  set 流程状态='到达物流部' where  工作令号='" + gongzuolinghao + "' and  项目名称='" + xiangmumingcheng + "'  and  设备名称='" + shebeimingcheng + "' and  到货验收流程标记='" + biaoji + "'";
                            SQLhelp.ExecuteScalar(sql41, CommandType.Text);



                            if (txtName.Text != "")
                            {
                                string sql3 = "update tb_liuchengxiangxi  set 附件=@pic,附件名称='" + fileName + "',附件类型='" + fileType + "' where 创建时间= '" + huifu + "' and  工作令号='" + gongzuolinghao + "' and  项目名称='" + xiangmumingcheng + "'  and  设备名称='" + shebeimingcheng + "' and  流程标记='" + biaoji + "'";
                                SQLhelp.ExecuteNonquery(sql3, CommandType.Text, files);
                            }
                            MessageBox.Show("提交成功！");
                            this.DialogResult = DialogResult.OK;
                            this.Close();

                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show("提交 " + fileName + " 时候发生了　　" + ex.Message);
                        }

                    }
                }
            }

            if (zhonglei == "发货确认")
            {
                if (radioButton1.Checked == true)

                {
                    if (MessageBox.Show("确认上传吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        DateTime huifu = DateTime.Now;

                        try
                        {
                            string sql2 = "insert into tb_liuchengxiangxi(流程类型,创建人,创建时间,流程标记,工作令号,项目名称,设备名称,时间,流程内容) values('发货确认流程','" + yonghu + "','" + huifu + "','" + biaoji + "','" + gongzuolinghao + "','" + xiangmumingcheng + "','" + shebeimingcheng + "','" + shijian + "','" + txtluoshiqingkuang.Text + "') ";
                            SQLhelp.ExecuteScalar(sql2, CommandType.Text);




                            string sql4 = "update tb_zongliucheng  set 流程状态='到达仓库'  where id='" + id1 + "' ";
                            SQLhelp.ExecuteScalar(sql4, CommandType.Text);
                            
                            if (txtName.Text != "")
                            {
                                string sql3 = "update tb_liuchengxiangxi  set 附件=@pic,附件名称='" + fileName + "',附件类型='" + fileType + "' where 创建时间= '" + huifu + "' and  工作令号='" + gongzuolinghao + "' and  项目名称='" + xiangmumingcheng + "'  and  设备名称='" + shebeimingcheng + "' and  流程标记='" + biaoji + "'";
                                SQLhelp.ExecuteNonquery(sql3, CommandType.Text, files);
                            }
                            MessageBox.Show("提交成功！");
                            this.DialogResult = DialogResult.OK;
                            this.Close();

                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show("提交 " + fileName + " 时候发生了　　" + ex.Message);
                        }


                    }
                }
                if (radioButton2.Checked == true)

                {

                    if (MessageBox.Show("确认上传吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        DateTime huifu = DateTime.Now;

                        try
                        {
                            string sql2 = "insert into tb_liuchengxiangxi(流程类型,创建人,创建时间,流程标记,工作令号,项目名称,设备名称,时间,流程内容) values('发货确认流程','" + yonghu + "','" + huifu + "','" + biaoji + "','" + gongzuolinghao + "','" + xiangmumingcheng + "','" + shebeimingcheng + "','" + shijian + "','" + txtluoshiqingkuang.Text + "') ";
                            SQLhelp.ExecuteScalar(sql2, CommandType.Text);




                            string sql4 = "update tb_zongliucheng  set 流程状态='到达生产部'  where id='" + id1 + "' ";
                            SQLhelp.ExecuteScalar(sql4, CommandType.Text);
                            
                            if (txtName.Text != "")
                            {
                                string sql3 = "update tb_liuchengxiangxi  set 附件=@pic,附件名称='" + fileName + "',附件类型='" + fileType + "' where 创建时间= '" + huifu + "' and  工作令号='" + gongzuolinghao + "' and  项目名称='" + xiangmumingcheng + "'  and  设备名称='" + shebeimingcheng + "' and  流程标记='" + biaoji + "'";
                                SQLhelp.ExecuteNonquery(sql3, CommandType.Text, files);
                            }
                            MessageBox.Show("提交成功！");
                            this.DialogResult = DialogResult.OK;
                            this.Close();

                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show("提交 " + fileName + " 时候发生了　　" + ex.Message);
                        }

                    }
                }


            }
        }
    }
}
