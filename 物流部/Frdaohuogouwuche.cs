using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using NetWork.util;
using NetWorkLib;

namespace 项目管理系统.物流部
{
    public partial class Frdaohuogouwuche : DevExpress.XtraEditors.XtraForm
    {
        public Frdaohuogouwuche()
        {
            InitializeComponent();
        }
        public DataTable dt;
        public string yonghu;
        public string zhonglei;

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

        private void Frdaohuogouwuche_Load(object sender, EventArgs e)
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

            

            string sql1 = "select 用户名 from tb_operator where 部门='质监部'";
            DataTable b = sqlhelp111.GetDataTable(sql1, CommandType.Text);
            List<string> spaceminute1 = new List<string>();
            for (int i = 0; i < b.Rows.Count; i++)
            {

                string n = b.Rows[i]["用户名"].ToString();
                spaceminute1.Add(n);
            }

            foreach (string s in spaceminute1)
            {
                comboBoxEdit2.Properties.Items.Add(s);
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

        private void btnTijiao_Click(object sender, EventArgs e)
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
                    string msg= "第" + a1 + "行本次到货验收数量不是数字，请重新提交！";
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
                    if (Convert.ToInt32(daohuoyanshoushuliang) <= Convert.ToInt32(shijicaigoushuliang) && txtSonghuodan.Text != "" && txtHegezheng.Text != "" && txtBaogao.Text != "" && txtTuzhi.Text != "")
                    {
                        string sql = "update tb_caigouliaodan set 本次到货验收数量='" + daohuoyanshoushuliang + "',到货仓库人='" + comboBoxEdit1.Text + "',到货检验人='" + txtZerenren1.Text + "',到货质监人='" + comboBoxEdit2.Text + "',到货验收流程状态='1待检验',提交类型='物流部发起流程',到货类型='外协整机原材料' where id ='" + n + "'";
                        SQLhelp.ExecuteScalar(sql, CommandType.Text);

                        string sql1 = "update tb_caigouliaodan set  发起到货验收数量= isnull(发起到货验收数量,0) +(select 本次到货验收数量  from tb_caigouliaodan where id ='" + n + "')  where id ='" + n + "'";
                        SQLhelp.ExecuteScalar(sql1, CommandType.Text);

                        string qingdan = "";
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            qingdan += dt.Rows[j]["id"].ToString() + "|";
                        }

                        string sql2 = "update tb_caigouliaodan set 物流提交时间='" + tijiaoshijian + "',物流员='" + yonghu + "',查看该批次='"+ qingdan + "' where id ='" + n + "'";
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
                    
                    string sql1 = "select 到货检验人 from tb_caigouliaodan where id='" + id + "'";
                    string jianyanyuan = SQLhelp.ExecuteScalar(sql1, CommandType.Text).ToString();

                    string sendmessage = yonghu + "  发起了一份" + hetonghao + "\r\n" + gongfangmingcheng + " 的到货验收流程" + "\r\n" +
                  "请检验员" + jianyanyuan + "检验！" ;
                    NetWork3J NetWork3J = new NetWork3J(yonghu , "http://" + MyGlobal.ip + ":81/");                    
                    NetWork3J.sendmessageById(jianyanyuan , sendmessage);
                    
                }
            }            
        }
       
        private void txtZerenren1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)//如果按了向上键
            {
                int idx = listBox1.SelectedIndex;//获取当前所选择的是哪一项
                if (idx == -1)//如果所选荐是-1,就表示没有选中任何值,是刚进入的
                {
                    listBox1.SelectedItem = listBox1.Items[listBox1.Items.Count - 1];//让他选中最后一个,也就是总数减1
                }
                else
                {
                    if (idx == 0)//等于零,表示此时选中的是在第一行.
                    {
                        listBox1.SelectedItem = listBox1.Items[listBox1.Items.Count - 1];//再按向上键,就跳到最后一个.
                        idx = listBox1.Items.Count;//当前选中的这一行,就是值的总数
                    }
                    listBox1.SelectedItem = listBox1.Items[idx - 1];//从下往上一直移动选择, 一直递减1
                }
            }
            else if (e.KeyCode == Keys.Down)//如果按了向下键
            {
                int idx = listBox1.SelectedIndex;//获取当前所选择的是哪一项
                if (idx == -1)//如果所选荐是-1,就表示没有选中任何值,是刚进入的
                {
                    //把下拉列里的第一个(item[0])值,赋给listBox2的SelectedItem属性, 这个属性表示当前被选中的项
                    listBox1.SelectedItem = listBox1.Items[0];
                }
                else
                {
                    if (idx == listBox1.Items.Count - 1)//如果idx等于总数减1,  就表示所选中的已经在最后一个了
                    {
                        listBox1.SelectedItem = listBox1.Items[0];//就把第一个值,赋给listBox2的SelectedItem属性. 等于从头再开始
                    }
                    else
                    {
                        listBox1.SelectedItem = listBox1.Items[idx + 1];//不是未选中,也不是最后一项,  就递增1,向下再移动的意思
                    }
                }
                idx = listBox1.SelectedIndex;//最后得出结果,再次获取当前所选择的是哪一项
            }
            else if (e.KeyCode == Keys.Enter && (listBox1.Visible == true))
            {
                //如果按了回车键,并且这个下拉框是要可见的时候.隐藏时就按回车无效
                if (listBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("请选择对应的人员！");

                    return;
                }

                int i = txtZerenren1.Text.LastIndexOf(";");
                if (i == -1)
                {
                    string chongxin = "";
                    chongxin = this.listBox1.SelectedItem.ToString();//把选中的值给文本框
                    txtZerenren1.Text = chongxin;
                    this.txtZerenren1.SelectionStart = this.txtZerenren1.TextLength;
                    listBox1.Visible = false;//隐藏这个控件

                }
                if (i != -1)
                {
                    string jiequ = txtZerenren1.Text.Substring(0, i + 1);

                    txtZerenren1.Text = jiequ + this.listBox1.SelectedItem.ToString() + ";";
                    this.txtZerenren1.SelectionStart = this.txtZerenren1.TextLength;
                    listBox1.Visible = false;//隐藏这个控件
                }
            }
        }

        private void txtZerenren1_TextChanged(object sender, EventArgs e)
        {
            if (!txtZerenren1.Text.Contains("\r\n"))
            {

                listBox1.Items.Clear();//先清空一下这个控件的值.  不然就会造成文本框里不输时,这里面全部都是值

                string sql = "select 用户名 from tb_operator ";
                DataTable dt = sqlhelp111.GetDataTable(sql, CommandType.Text);

                int b = txtZerenren1.Text.LastIndexOf(";");

                if (b != -1)
                {
                    string jiequ = txtZerenren1.Text.Substring(b + 1);


                    DataRow[] drr = dt.Select("用户名 like'%" + jiequ + "%'");
                    DataTable newdtt = new DataTable(); //再新创建一个表,
                    newdtt = dt.Clone();//复制dt表的所有结构

                    foreach (DataRow row in drr)
                    {
                        newdtt.Rows.Add(row.ItemArray);
                    }//这一句,可以改成用for循环替代,  循环内就用 newdt.ImportRow(dr[i]);



                    if (dt.Rows.Count > 0 && (jiequ != ""))//如果这个DS表里的行数总数,大于零,并且文本框不为空,就运行以下代码
                    {
                        listBox1.Visible = true;      //listBox2显示出来  
                        for (int i = 0; i < newdtt.Rows.Count; i++)//循环所有行数
                        {
                            listBox1.Items.Add(newdtt.Rows[i]["用户名"].ToString());//每行的名称值给listBox2
                        }
                    }

                }

                DataRow[] dr = dt.Select("用户名 like'%" + txtZerenren1.Text + "%'");
                DataTable newdt = new DataTable(); //再新创建一个表,
                newdt = dt.Clone();//复制dt表的所有结构

                foreach (DataRow row in dr)
                {
                    newdt.Rows.Add(row.ItemArray);
                }

                if (newdt.Rows.Count > 0 && (txtZerenren1.Text != ""))
                {
                    listBox1.Visible = true;
                    for (int i = 0; i < newdt.Rows.Count; i++)
                    {
                        listBox1.Items.Add(newdt.Rows[i]["用户名"].ToString());//
                    }
                }

                if (listBox1.Items.Count > 0)
                {
                    listBox1.SelectedIndex = 0;

                }

            }
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("请选择对应的人员");

                return;
            }

            int i = txtZerenren1.Text.LastIndexOf(";");
            if (i == -1)
            {
                string chongxin = "";
                chongxin = this.listBox1.SelectedItem.ToString();//把选中的值给文本框
                txtZerenren1.Text = chongxin;
                this.txtZerenren1.SelectionStart = this.txtZerenren1.TextLength;
                listBox1.Visible = false;//隐藏这个控件

            }
            if (i != -1)
            {
                string jiequ = txtZerenren1.Text.Substring(0, i + 1);

                txtZerenren1.Text = jiequ + this.listBox1.SelectedItem.ToString() + ";";
                this.txtZerenren1.SelectionStart = this.txtZerenren1.TextLength;
                listBox1.Visible = false;//隐藏这个控件
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

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            string daohuoshuliang = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "本次数量"));
            string shijicaigoushuliang = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "实际采购数量"));
            float a = 0;

            if (float.TryParse(daohuoshuliang, out a) == false)
            {
                MessageBox.Show("必须输入数字！");
                return;
            }
            if (Convert.ToInt32(shijicaigoushuliang) < Convert.ToInt32(daohuoshuliang))
            {
                MessageBox.Show("本次到货验收数量大于实际采购数量，请重新提交！");
                return;
            }
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }
    }
    
    
}