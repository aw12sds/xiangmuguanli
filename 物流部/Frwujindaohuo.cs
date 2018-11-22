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
    public partial class Frwujindaohuo : DevExpress.XtraEditors.XtraForm
    {
        public Frwujindaohuo()
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
        private void Frwujindaohuo_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = dt;
            gridView1.Columns["id"].Visible = false;
            gridView1.Columns["发起到货验收数量"].Visible = false;
            string sql = "select 用户名 from tb_operator where 部门='仓库'";
            DataTable aaaa = sqlhelp111.GetDataTable(sql, CommandType.Text);
            List<string> spaceminute = new List<string>();
            for (int i = 0; i < aaaa.Rows.Count; i++)
            {

                string n = aaaa.Rows[i]["用户名"].ToString();
                spaceminute.Add(n);
            }

            foreach (string s in spaceminute)
            {
                comboBoxEdit1.Properties.Items.Add(s);
            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
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
                    
                    fileType2 = info.Extension.Replace(".", "");
                    

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

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string id = Convert.ToString(this.gridView1.GetRowCellValue(i, "id"));
                string daohuoyanshoushuliang = Convert.ToString(this.gridView1.GetRowCellValue(i, "本次数量"));
                string shijicaigoushuliang = Convert.ToString(this.gridView1.GetRowCellValue(i, "实际采购数量"));


                float a = 0;

                if (float.TryParse(daohuoyanshoushuliang, out a) == false)
                {
                    int a1 = i + 1;
                    string msg = "第" + a1 + "行本次到货验收数量不是数字，请重新提交！";
                    MessageBox.Show(msg);
                    return;
                }

            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string id = Convert.ToString(this.gridView1.GetRowCellValue(i, "id"));
                string daohuoyanshoushuliang = Convert.ToString(this.gridView1.GetRowCellValue(i, "本次数量"));
                string shijicaigoushuliang = Convert.ToString(this.gridView1.GetRowCellValue(i, "实际采购数量"));

                if (Convert.ToInt32(daohuoyanshoushuliang) > Convert.ToInt32(shijicaigoushuliang))
                {
                    int a1 = i + 1;
                    string msg = "第" + a1 + "行本次到货验收数量大于实际采购数量，请重新提交！";
                    MessageBox.Show(msg);
                    return;
                }
            }
            string tijiaoshijian = DateTime.Now.ToString();
            if (MessageBox.Show("确认提交吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                bool b = false;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string id = Convert.ToString(this.gridView1.GetRowCellValue(i, "id"));
                    string daohuoyanshoushuliang = Convert.ToString(this.gridView1.GetRowCellValue(i, "本次数量"));
                    string shijicaigoushuliang = Convert.ToString(this.gridView1.GetRowCellValue(i, "实际采购数量"));
                    string faqidaohuoyanshoushuliang = Convert.ToString(this.gridView1.GetRowCellValue(i, "发起到货验收数量"));
                    string gongzuolinghao = Convert.ToString(this.gridView1.GetRowCellValue(i, "工作令号"));
                    string xiangmumingcheng = Convert.ToString(this.gridView1.GetRowCellValue(i, "项目名称"));
                    string shebeimingcheng = Convert.ToString(this.gridView1.GetRowCellValue(i, "设备名称"));
                    string mingcheng = Convert.ToString(this.gridView1.GetRowCellValue(i, "名称"));
                    string xinghao = Convert.ToString(this.gridView1.GetRowCellValue(i, "型号"));
                    string gongfangmingcheng = Convert.ToString(this.gridView1.GetRowCellValue(i, "供方名称"));
                    string danwei = Convert.ToString(this.gridView1.GetRowCellValue(i, "单位"));

                    if (daohuoyanshoushuliang.Trim() == "")
                    {
                        MessageBox.Show("请填写本次到货验收数量！");
                        return;
                    }
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string id = Convert.ToString(this.gridView1.GetRowCellValue(i, "id"));
                    string daohuoyanshoushuliang = Convert.ToString(this.gridView1.GetRowCellValue(i, "本次数量"));
                    string shijicaigoushuliang = Convert.ToString(this.gridView1.GetRowCellValue(i, "实际采购数量"));
                    string faqidaohuoyanshoushuliang = Convert.ToString(this.gridView1.GetRowCellValue(i, "发起到货验收数量"));
                    string gongzuolinghao = Convert.ToString(this.gridView1.GetRowCellValue(i, "工作令号"));
                    string xiangmumingcheng = Convert.ToString(this.gridView1.GetRowCellValue(i, "项目名称"));
                    string shebeimingcheng = Convert.ToString(this.gridView1.GetRowCellValue(i, "设备名称"));
                    string mingcheng = Convert.ToString(this.gridView1.GetRowCellValue(i, "名称"));
                    string xinghao = Convert.ToString(this.gridView1.GetRowCellValue(i, "型号"));
                    string gongfangmingcheng = Convert.ToString(this.gridView1.GetRowCellValue(i, "供方名称"));
                    string danwei = Convert.ToString(this.gridView1.GetRowCellValue(i, "单位"));

                    var uuid = Guid.NewGuid().ToString();

                    string n = dt.Rows[i]["id"].ToString();

                    if (Convert.ToInt32(daohuoyanshoushuliang) <= Convert.ToInt32(shijicaigoushuliang) && txtSonghuodan.Text != "" && txtHegezheng.Text != "")
                    {
                        string sql = "update tb_caigouliaodan set 本次到货验收数量='" + daohuoyanshoushuliang + "',到货仓库人='" + comboBoxEdit1.Text + "',到货验收流程状态='1待入库',提交类型='物流部发起流程',到货类型='五金辅材标准件' where id ='" + n + "'";
                        SQLhelp.ExecuteScalar(sql, CommandType.Text);

                        string sql1 = "update tb_caigouliaodan set  发起到货验收数量= isnull(发起到货验收数量,0) +(select 本次到货验收数量  from tb_caigouliaodan where id ='" + n + "')  where id ='" + n + "'";
                        SQLhelp.ExecuteScalar(sql1, CommandType.Text);

                        string qingdan = "";
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            qingdan += dt.Rows[j]["id"].ToString() + "|";
                        }

                        string sql2 = "update tb_caigouliaodan set 物流提交时间='" + tijiaoshijian + "',物流员='" + yonghu + "',查看该批次='" + qingdan + "' where id ='" + n + "'";
                        SQLhelp.ExecuteScalar(sql2, CommandType.Text);

                        string sql3 = "insert into tb_daohuojilu (工作令号,项目名称,设备名称,名称,型号,供方名称,单位,定位,实际采购数量,到货数量,提交人,提交时间,文件定位,查看该批次,提交类型) values ('" + gongzuolinghao + "','" + xiangmumingcheng + "','" + shebeimingcheng + "','" + mingcheng + "','" + xinghao + "','" + gongfangmingcheng + "','" + danwei + "','" + id + "','" + shijicaigoushuliang + "','" + daohuoyanshoushuliang + "','" + yonghu + "','" + tijiaoshijian + "','" + uuid + "','" + qingdan + "','物流部发起流程')";
                        SQLhelp.ExecuteScalar(sql3, CommandType.Text);

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
                        }
                        b = true;
                    }
                    else
                    {
                        MessageBox.Show("提交失败！");
                    }
                }
                if (b)
                {
                    MessageBox.Show("提交成功！");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
                    string hetonghao = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "合同号"));
                    string gongfangmingcheng = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "供方名称"));

                    string sql1 = "select 到货仓库人 from tb_caigouliaodan where id='" + id + "'";
                    string jianyanyuan = SQLhelp.ExecuteScalar(sql1, CommandType.Text).ToString();

                    string sendmessage = yonghu + "  发起了一份" + hetonghao + "\r\n" + gongfangmingcheng + " 的标准件、五金辅材到货验收流程" + "\r\n" +
                  "请仓库" + jianyanyuan + "查看！";
                    NetWork3J NetWork3J = new NetWork3J(yonghu, "http://" + MyGlobal.ip + ":81/");
                    NetWork3J.sendmessageById(jianyanyuan, sendmessage);

                }
                
            }

        }
    }
}
