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

namespace 项目管理系统.物流部
{
    public partial class Frzaiquerenfujian : DevExpress.XtraEditors.XtraForm
    {
        public Frzaiquerenfujian()
        {
            InitializeComponent();
        }
        public DataTable dt;
        public string yonghu;

        private long fileSize2 = 0;//文件大小
        private string fileName2 = null;//文件名字
        private string fileType2 = null;//文件类型
        private byte[] files2;//文件
        private BinaryReader read2 = null;//二进制读取
        public string lujing2;

        private long fileSize1 = 0;//文件大小
        private string fileName1 = null;//文件名字
        private string fileType1 = null;//文件类型
        private byte[] files1;//文件
        private BinaryReader read1 = null;//二进制读取
        public string lujing1;

        private long fileSize3 = 0;//文件大小
        private string fileName3 = null;//文件名字
        private string fileType3 = null;//文件类型
        private byte[] files3;//文件
        private BinaryReader read3 = null;//二进制读取
        public string lujing3;

        private long fileSize4 = 0;//文件大小
        private string fileName4 = null;//文件名字
        private string fileType4 = null;//文件类型
        private byte[] files4;//文件
        private BinaryReader read4 = null;//二进制读取
        public string lujing4;

        private long fileSize5 = 0;//文件大小
        private string fileName5 = null;//文件名字
        private string fileType5 = null;//文件类型
        private byte[] files5;//文件
        private BinaryReader read5 = null;//二进制读取
        public string lujing5;
        private void Frzaiquerenfujian_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = dt;
            gridView1.Columns["id"].Visible = false;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                //打开对话框
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo info = new FileInfo(@dialog.FileName);
                    //获得文件大小
                    //fileSize2 = info.Length;
                    ////提取文件名,三步走
                    //int index = info.FullName.LastIndexOf(".");
                    //fileName2 = info.FullName.Remove(index);
                    //fileName2 = fileName2.Substring(fileName2.LastIndexOf(@"\") + 1);
                    //txtName.Text = fileName2;
                    //获得文件扩展名
                    fileType2 = info.Extension.Replace(".", "");
                    //把文件转换成二进制流
                    //files2 = new byte[Convert.ToInt32(fileSize2)];
                    //FileStream file2 = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read);
                    //read2 = new BinaryReader(file2);
                    //read2.Read(files2, 0, Convert.ToInt32(fileSize2));

                    if (fileType2 == "pdf")
                    {
                        fileSize2 = info.Length;
                        //提取文件名,三步走
                        int index = info.FullName.LastIndexOf(".");
                        fileName2 = info.FullName.Remove(index);
                        fileName2 = fileName2.Substring(fileName2.LastIndexOf(@"\") + 1);
                        txtName.Text = fileName2;
                        //把文件转换成二进制流
                        files2 = new byte[Convert.ToInt32(fileSize2)];
                        FileStream file2 = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read);
                        read2 = new BinaryReader(file2);
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

        private void btnSonghuodan_Click(object sender, EventArgs e)
        {
            try
            {
                //打开对话框
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo info = new FileInfo(@dialog.FileName);

                    //获得文件扩展名
                    fileType1 = info.Extension.Replace(".", "");
                    if (fileType1 == "pdf")
                    {
                        fileSize1 = info.Length;
                        //提取文件名,三步走
                        int index = info.FullName.LastIndexOf(".");
                        fileName1 = info.FullName.Remove(index);
                        fileName1 = fileName1.Substring(fileName1.LastIndexOf(@"\") + 1);
                        txtSonghuodan.Text = fileName1;

                        //把文件转换成二进制流
                        files1 = new byte[Convert.ToInt32(fileSize1)];
                        FileStream file1 = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read);
                        read1 = new BinaryReader(file1);
                        read1.Read(files1, 0, Convert.ToInt32(fileSize1));
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

        private void btnHegezheng_Click(object sender, EventArgs e)
        {
            try
            {
                //打开对话框
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo info = new FileInfo(@dialog.FileName);
                    //获得文件扩展名
                    fileType3 = info.Extension.Replace(".", "");
                    if (fileType3 == "pdf")
                    {
                        //获得文件大小
                        fileSize3 = info.Length;
                        //提取文件名,三步走
                        int index = info.FullName.LastIndexOf(".");
                        fileName3 = info.FullName.Remove(index);
                        fileName3 = fileName3.Substring(fileName3.LastIndexOf(@"\") + 1);
                        txtHegezheng.Text = fileName3;


                        //把文件转换成二进制流
                        files3 = new byte[Convert.ToInt32(fileSize3)];
                        FileStream file3 = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read);
                        read3 = new BinaryReader(file3);
                        read3.Read(files3, 0, Convert.ToInt32(fileSize3));
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

        private void btnZijian_Click(object sender, EventArgs e)
        {
            try
            {
                //打开对话框
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {

                    FileInfo info = new FileInfo(@dialog.FileName);
                    //获得文件扩展名
                    fileType4 = info.Extension.Replace(".", "");
                    if (fileType4 == "pdf")
                    {
                        //获得文件大小
                        fileSize4 = info.Length;
                        //提取文件名,三步走
                        int index = info.FullName.LastIndexOf(".");
                        fileName4 = info.FullName.Remove(index);
                        fileName4 = fileName4.Substring(fileName4.LastIndexOf(@"\") + 1);
                        txtBaogao.Text = fileName4;

                        //把文件转换成二进制流
                        files4 = new byte[Convert.ToInt32(fileSize4)];
                        FileStream file4 = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read);
                        read4 = new BinaryReader(file4);
                        read4.Read(files4, 0, Convert.ToInt32(fileSize4));
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

        private void btnYanshoutuzhi_Click(object sender, EventArgs e)
        {
            try
            {
                //打开对话框
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {

                    FileInfo info = new FileInfo(@dialog.FileName);
                    //获得文件扩展名
                    fileType5 = info.Extension.Replace(".", "");
                    if (fileType5 == "pdf")
                    {
                        //获得文件大小
                        fileSize5 = info.Length;
                        //提取文件名,三步走
                        int index = info.FullName.LastIndexOf(".");
                        fileName5 = info.FullName.Remove(index);
                        fileName5 = fileName5.Substring(fileName5.LastIndexOf(@"\") + 1);
                        txtTuzhi.Text = fileName5;

                        //把文件转换成二进制流
                        files5 = new byte[Convert.ToInt32(fileSize5)];
                        FileStream file5 = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read);
                        read5 = new BinaryReader(file5);
                        read5.Read(files5, 0, Convert.ToInt32(fileSize5));
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
            if (MessageBox.Show("确认提交吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                int[] a = gridView1.GetSelectedRows();

                foreach (int i in a)
                {
                    string id = Convert.ToString(this.gridView1.GetRowCellValue(i, "id"));
                    string daohuoyanshoushuliang = Convert.ToString(this.gridView1.GetRowCellValue(i, "本次数量"));
                    string gongzuolinghao = Convert.ToString(this.gridView1.GetRowCellValue(i, "工作令号"));
                    string xiangmumingcheng = Convert.ToString(this.gridView1.GetRowCellValue(i, "项目名称"));
                    string shebeimingcheng = Convert.ToString(this.gridView1.GetRowCellValue(i, "设备名称"));
                    string mingcheng = Convert.ToString(this.gridView1.GetRowCellValue(i, "名称"));
                    string xinghao = Convert.ToString(this.gridView1.GetRowCellValue(i, "型号"));
                    string danwei = Convert.ToString(this.gridView1.GetRowCellValue(i, "单位"));
                    string shijicaigoushuliang = Convert.ToString(this.gridView1.GetRowCellValue(i, "实际采购数量"));
                    string gongfangmingcheng = Convert.ToString(this.gridView1.GetRowCellValue(i, "供方名称"));
                    string faqidaohuoyanshoushuliang = Convert.ToString(this.gridView1.GetRowCellValue(i, "发起到货验收数量"));
                    string tijiaoshijian = DateTime.Now.ToString();

                    var uuid = Guid.NewGuid().ToString();

                    string sql = "update tb_caigouliaodan set 仓库确认状态='0',到货验收流程状态='3到仓库',提交类型='物流部再发起' where id ='" + id + "'";
                    SQLhelp.ExecuteScalar(sql, CommandType.Text);

                    string sql2 = "insert into tb_daohuojilu (工作令号,项目名称,设备名称,名称,型号,单位,定位,到货数量,提交人,提交时间,供方名称,提交类型,仓库确认状态,文件定位) values ('" + gongzuolinghao + "','" + xiangmumingcheng + "','" + shebeimingcheng + "','" + mingcheng + "','" + xinghao + "','" + danwei + "','" + id + "','" + daohuoyanshoushuliang + "','" + yonghu + "','" + tijiaoshijian + "','" + gongfangmingcheng + "','物流部再发起','0','"+uuid+"')";
                    SQLhelp.ExecuteScalar(sql2, CommandType.Text);

                    if (txtName.Text != "")
                    {
                        string sql4 = "update tb_daohuojilu  set 物流部发票=@pic where 文件定位 ='" + uuid + "'  ";
                        SQLhelp.ExecuteNonquery(sql4, CommandType.Text, files2);

                        string sql5 = "update tb_daohuojilu  set 物流部发票名称='" + fileName2 + "',物流部发票类型='" + fileType2 + "'  where 文件定位 ='" + uuid + "' ";
                        SQLhelp.ExecuteScalar(sql5, CommandType.Text);

                        string sql6 = "update tb_daohuojilu  set 物流部送货单=@pic where 文件定位 ='" + uuid + "'  ";
                        SQLhelp.ExecuteNonquery(sql6, CommandType.Text, files1);

                        string sql7 = "update tb_daohuojilu  set 物流部送货单名称='" + fileName1 + "',物流部送货单类型='" + fileType1 + "'  where 文件定位 ='" + uuid + "' ";
                        SQLhelp.ExecuteScalar(sql7, CommandType.Text);

                        string sql8 = "update tb_daohuojilu  set 合格证=@pic where 文件定位 ='" + uuid + "'  ";
                        SQLhelp.ExecuteNonquery(sql8, CommandType.Text, files3);

                        string sql9 = "update tb_daohuojilu  set 合格证名称='" + fileName3 + "',合格证类型='" + fileType3 + "'  where 文件定位 ='" + uuid + "' ";
                        SQLhelp.ExecuteScalar(sql9, CommandType.Text);

                        string sql10 = "update tb_daohuojilu  set 自检报告=@pic where 文件定位 ='" + uuid + "'  ";
                        SQLhelp.ExecuteNonquery(sql10, CommandType.Text, files4);

                        string sql11 = "update tb_daohuojilu  set 自检报告名称='" + fileName4 + "',自检报告类型='" + fileType4 + "'  where 文件定位 ='" + uuid + "' ";
                        SQLhelp.ExecuteScalar(sql11, CommandType.Text);

                        string sql12 = "update tb_daohuojilu  set 验收图纸=@pic where 文件定位 ='" + uuid + "'  ";
                        SQLhelp.ExecuteNonquery(sql12, CommandType.Text, files5);

                        string sql13 = "update tb_daohuojilu  set 验收图纸名称='" + fileName5 + "',验收图纸类型='" + fileType5 + "'  where 文件定位 ='" + uuid + "' ";
                        SQLhelp.ExecuteScalar(sql13, CommandType.Text);
                    }
                    else
                    {
                        string sql6 = "update tb_daohuojilu  set 物流部送货单=@pic where 文件定位 ='" + uuid + "'  ";
                        SQLhelp.ExecuteNonquery(sql6, CommandType.Text, files1);

                        string sql7 = "update tb_daohuojilu  set 物流部送货单名称='" + fileName1 + "',物流部送货单类型='" + fileType1 + "'  where 文件定位 ='" + uuid + "' ";
                        SQLhelp.ExecuteScalar(sql7, CommandType.Text);

                        string sql8 = "update tb_daohuojilu  set 合格证=@pic where 文件定位 ='" + uuid + "'  ";
                        SQLhelp.ExecuteNonquery(sql8, CommandType.Text, files3);

                        string sql9 = "update tb_daohuojilu  set 合格证名称='" + fileName3 + "',合格证类型='" + fileType3 + "'  where 文件定位 ='" + uuid + "' ";
                        SQLhelp.ExecuteScalar(sql9, CommandType.Text);

                        string sql10 = "update tb_daohuojilu  set 自检报告=@pic where 文件定位 ='" + uuid + "'  ";
                        SQLhelp.ExecuteNonquery(sql10, CommandType.Text, files4);

                        string sql11 = "update tb_daohuojilu  set 自检报告名称='" + fileName4 + "',自检报告类型='" + fileType4 + "'  where 文件定位 ='" + uuid + "' ";
                        SQLhelp.ExecuteScalar(sql11, CommandType.Text);

                        string sql12 = "update tb_daohuojilu  set 验收图纸=@pic where 文件定位 ='" + uuid + "'  ";
                        SQLhelp.ExecuteNonquery(sql12, CommandType.Text, files5);

                        string sql13 = "update tb_daohuojilu  set 验收图纸名称='" + fileName5 + "',验收图纸类型='" + fileType5 + "'  where 文件定位 ='" + uuid + "' ";
                        SQLhelp.ExecuteScalar(sql13, CommandType.Text);
                    }
                }
                MessageBox.Show("提交成功！");
                this.DialogResult = DialogResult.OK;
                this.Close();

                string id1 = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
                string hetonghao1 = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "合同号"));
                string gongfangmingcheng1 = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "供方名称"));

                string sql1 = "select 到货仓库人 from tb_caigouliaodan where id='" + id1 + "'";
                string jianyanyuan = SQLhelp.ExecuteScalar(sql1, CommandType.Text).ToString();

                string sendmessage = yonghu + "  再发起了一份" + hetonghao1 + "\r\n" + gongfangmingcheng1 + " 的到货验收流程" + "\r\n" +
              "请仓库" + jianyanyuan + "查看！";
                NetWork3J NetWork3J = new NetWork3J(yonghu, "http://" + MyGlobal.ip + ":81/");
                NetWork3J.sendmessageById(jianyanyuan, sendmessage);
                
            }
            
        }
    }
}
