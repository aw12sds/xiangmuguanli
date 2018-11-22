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
    public partial class Frchuli : DevExpress.XtraEditors.XtraForm
    {
        public Frchuli()
        {
            InitializeComponent();
        }
        public string yonghu;       
        public string gonglinghao;
        public string xiangmumingcheng;
        public string caigou;
        public string zhuangpei;
        public string zhuguan;

        private long fileSize1 = 0;//文件大小
        private string fileName1 = null;//文件名字
        private string fileType1 = null;//文件类型
        private byte[] files1;//文件
        private BinaryReader read1 = null;//二进制读取
        public string lujing1;
        private void Frchuli_Load(object sender, EventArgs e)
        {
            string sql2 = "select 部门 from tb_operator  where 用户名='" + yonghu + "'";
            string bumen = sqlhelp111.ExecuteScalar(sql2, CommandType.Text).ToString();

            string sql8 = "select 用户名 from tb_operator  where 部门='" + bumen + "' and 级别='经理'";
            string jingli = Convert.ToString(sqlhelp111.ExecuteScalar(sql8, CommandType.Text));

            string sql1 = "select 用户名 from tb_operator  where 部门='" + bumen + "' ";
            DataTable mingdan = sqlhelp111.GetDataTable(sql1, CommandType.Text);
            List<string> spaceminute1 = new List<string>();
            for (int i = 0; i < mingdan.Rows.Count; i++)
            {
                string n = mingdan.Rows[i]["用户名"].ToString();
                spaceminute1.Add(n);
            }
            foreach (string s in spaceminute1)
            {
                cbjixiefuzeren.Properties.Items.Add(s);
                cbdianqifuzeren.Properties.Items.Add(s);
                cbshebeifuzeren.Properties.Items.Add(s);
            }
            string sql = "select distinct 设备划分 from tb_shebeihuafen where 项目名称='" + xiangmumingcheng + "'";
            DataTable aaaa = SQLhelp.GetDataTable(sql, CommandType.Text);
            List<string> spaceminute = new List<string>();
            for (int i = 0; i < aaaa.Rows.Count; i++)
            {

                string n = aaaa.Rows[i]["设备划分"].ToString();
                spaceminute.Add(n);
            }

            foreach (string s in spaceminute)
            {
                cbshebeimingcheng.Properties.Items.Add(s);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txtmiaoshu.Text == "")
            {
                MessageBox.Show("请先填写下单描述（设备名称）！");
                return;
            }
            if (cbzhizaoleixing.Text == "")
            {
                MessageBox.Show("请先选择制造类型！");
                return;
            }
            if (txtjishuzhibiao.Text == "")
            {
                MessageBox.Show("请先填写技术指标！");
                return;
            }
            if (txtfangxiang.Text == "")
            {
                MessageBox.Show("请先填写方向！");
                return;
            }
            if (dateEdit1.Text == "")
            {
                MessageBox.Show("请先选择预计结束时间！");
                return;
            }
            if (cbjixiefuzeren.Text == "")
            {
                MessageBox.Show("请先选择机械负责人！");
                return;
            }
            if (cbdianqifuzeren.Text == "")
            {
                MessageBox.Show("请先选择电气负责人！");
                return;
            }
            if (cbshebeifuzeren.Text == "")
            {
                MessageBox.Show("请先选择设备负责人！");
                return;
            }
            float a = 0;
            if (float.TryParse(txtshuliang.Text, out a) == false)
            {
                MessageBox.Show("数量必须是数字！");
                return;
            }
            if (cbshebeimingcheng.Text == "")
            {
                MessageBox.Show("请先填写所属设备！");
                return;
            }
            if (txtfujian.Text == "")
            {
                MessageBox.Show("请先提交附件！");
                return;
            }
            DateTime dangqian = DateTime.Now;
            Random ran = new Random();
            string shijian = dangqian.AddSeconds(Convert.ToDouble(ran.Next(1, 10000))).ToString();

            if (MessageBox.Show("确认提交吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string sql1 = "INSERT INTO tb_jishubumen(工作令号,项目名称,项目主管,时间,是否下达,生产部确认,图纸下达,技术部通过,优先级,加工确认,装配确认,调试确认,物流部确认,仓库确认,是否提交,项目负责人,采购项目负责人,装配负责人,物流部最终确认) VALUES('" + gonglinghao + "', '" + xiangmumingcheng + "', '" + zhuguan + "', '" + shijian + "',0,0,0,0,0,0,0,0,0,0,0,'" + yonghu + "','" + caigou + "','" + zhuangpei + "',0)";
                SQLhelp.ExecuteScalar(sql1, CommandType.Text);

                string sql3 = "select id from tb_jishubumen where 工作令号='" + gonglinghao + "'and 项目名称='" + xiangmumingcheng + "' and 项目主管='" + zhuguan + "' and 时间='" + shijian + "'";
                string id = SQLhelp.ExecuteScalar(sql3, CommandType.Text).ToString();

                string sql6 = "update tb_jishubumen  set 附件=@pic where  id='" + id + "' ";
                SQLhelp.ExecuteNonquery(sql6, CommandType.Text, files1);

                string sql2 = "update tb_jishubumen  set 设备名称='"+txtmiaoshu.Text+"',技术指标= '" + txtjishuzhibiao.Text + "',方向= '" + txtfangxiang.Text + "',数量= '" + txtshuliang.Text + "',制造类型 ='" + cbzhizaoleixing.Text + "',设备预计结束时间= '" + dateEdit1.Text + "',机械负责人= '" + cbjixiefuzeren.Text + "',电气负责人 ='" + cbdianqifuzeren.Text + "',设备划分='" + cbshebeimingcheng.Text + "',附件名称='"+ fileName1 + "',附件类型='"+ fileType1 + "',是否提交=1 ,设备负责人='" + cbshebeifuzeren.Text + "' where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql2, CommandType.Text);

                MessageBox.Show("提交成功！");
                this.DialogResult = DialogResult.OK;
                this.Close();
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
                    FileInfo info = new FileInfo(@dialog.FileName);

                    //获得文件扩展名
                    fileType1 = info.Extension.Replace(".", "");
                    
                        fileSize1 = info.Length;
                        //提取文件名,三步走
                        int index = info.FullName.LastIndexOf(".");
                        fileName1 = info.FullName.Remove(index);
                        fileName1 = fileName1.Substring(fileName1.LastIndexOf(@"\") + 1);
                        txtfujian.Text = fileName1;

                        //把文件转换成二进制流
                        files1 = new byte[Convert.ToInt32(fileSize1)];
                        FileStream file1 = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read);
                        read1 = new BinaryReader(file1);
                        read1.Read(files1, 0, Convert.ToInt32(fileSize1));
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("选择文件时候发生了　　" + ex.Message);
            }
        }
    }
}
