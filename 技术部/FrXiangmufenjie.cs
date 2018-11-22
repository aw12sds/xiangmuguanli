using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
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
using xiangmuguanli.技术部;
using 项目管理系统.生产部;

namespace 项目管理系统.技术部
{
    public partial class FrXiangmufenjie : Office2007Form
    {
        public FrXiangmufenjie()
        {
            this.EnableGlass = false;
            InitializeComponent();
            fpro = new FrJindutiao();

        }
        public string yonghu;
        public string gonglinghao;
        public string xiangmu;
        public string shebei;
        public string shijian;
        public string xuanzelujing;
        public string jingli;
        public FrJindutiao fpro = null;
        private void FrXiangmufenjie_Load(object sender, EventArgs e)
        {
            string sql2 = "select 部门 from tb_operator1  where 用户名='" + yonghu + "'";
            string bumen = SQLhelp.ExecuteScalar(sql2, CommandType.Text).ToString();

            string sql8= "select 用户名 from tb_operator1  where 部门='" +bumen+ "' and 级别='经理'";
            jingli=  Convert.ToString( SQLhelp.ExecuteScalar(sql8, CommandType.Text));

            string sql1 = "select 用户名 from tb_operator1  where 部门='" + bumen + "' ";
            DataTable mingdan = SQLhelp.GetDataTable(sql1, CommandType.Text);        
            List<string> spaceminute1 = new List<string>();
            for (int i = 0; i < mingdan.Rows.Count; i++)
            {
                string n = mingdan.Rows[i]["用户名"].ToString();
                spaceminute1.Add(n);
            }
            foreach (string s in spaceminute1)
            {
                repositoryItemComboBox1.Items.Add(s);                                           
            }          
            if (yonghu != "庄卫星")
            {
                Reload();
            }
            if (yonghu == "庄卫星")
            {          
                string sql4 = "select id,工作令号,项目名称,设备名称,技术指标,项目负责人,设备负责人,机械负责人,电气负责人,项目主管,方向,数量,制造类型,设备预计结束时间,附件名称,时间,优先级,技术要求反馈内容 from tb_jishubumen  where  是否提交=1  and 技术部通过=0 ";

                gridControl2.DataSource = SQLhelp.GetDataTable(sql4, CommandType.Text);
                gridView2.Columns["id"].Visible = false;

                string sql5 = "select id,工作令号,项目名称,设备名称,技术指标,项目负责人,设备负责人,机械负责人,电气负责人,项目主管,方向,数量,制造类型,设备预计结束时间,附件名称,时间,优先级,技术要求反馈内容 from tb_jishubumen  where 是否提交=1  and 技术部通过=1 and 图纸下达=0 and 图纸审核 is null ";

                gridControl3.DataSource = SQLhelp.GetDataTable(sql5, CommandType.Text);
                gridView3.Columns["id"].Visible = false;
                string sql6 = "select id,工作令号,项目名称,设备名称,项目主管,时间,优先级,设备负责人,技术部通过,是否提交,图纸下达,采购项目负责人,装配负责人 from tb_jishubumen    ";

                gridControl1.DataSource = SQLhelp.GetDataTable(sql6, CommandType.Text);
              

                string sql9 = "select id,工作令号,项目名称,设备名称,技术指标,项目负责人,设备负责人,机械负责人,电气负责人,项目主管,方向,数量,制造类型,设备预计结束时间,附件名称,时间,优先级,技术要求反馈内容 from tb_jishubumen  where 是否提交=1  and 技术部通过=1 and 图纸下达=0 and 图纸审核 =1";

                gridControl5.DataSource = SQLhelp.GetDataTable(sql9, CommandType.Text);
                gridView5.Columns["id"].Visible = false;
                string sql10 = "select id,工作令号,项目名称,设备名称,技术指标,项目负责人,设备负责人,机械负责人,电气负责人,项目主管,方向,数量,制造类型,设备预计结束时间,附件名称,时间,优先级,技术要求反馈内容 from tb_jishubumen  where 是否提交=1  and 技术部通过=1 and 图纸下达=0  and 图纸审核=0";

                gridControl4.DataSource = SQLhelp.GetDataTable(sql10, CommandType.Text);
                gridView4.Columns["id"].Visible = false;
            }

        }
        public void Reload()
        {
            //string sql3 = "select id,工作令号,项目名称,设备名称,技术指标,机械负责人,电气负责人,项目主管,方向,数量,制造类型,设备预计结束时间,附件名称,时间,优先级,技术要求反馈内容,料单品种数 from tb_jishubumen  where 设备负责人='" + yonghu + "' and 是否提交=0 ";
            
            //gridControl6.DataSource = SQLhelp.GetDataTable(sql3, CommandType.Text);
            

            string sql4 = "select id,工作令号,项目名称,设备名称,技术指标,项目负责人,设备负责人,机械负责人,电气负责人,项目主管,方向,数量,制造类型,设备预计结束时间,附件名称,时间,优先级,技术要求反馈内容 from tb_jishubumen  where 设备负责人='" + yonghu + "' and 是否提交=1  and 技术部通过=0 and 图纸下达=0";

            gridControl2.DataSource = SQLhelp.GetDataTable(sql4, CommandType.Text);
            gridView2.Columns["id"].Visible = false;
            string sql5 = "select id,工作令号,项目名称,设备名称,技术指标,项目负责人,设备负责人,机械负责人,电气负责人,项目主管,方向,数量,制造类型,设备预计结束时间,附件名称,时间,优先级,技术要求反馈内容 from tb_jishubumen  where 设备负责人='" + yonghu + "' and 是否提交=1  and 技术部通过=1 and 图纸下达=0 and 技术部图纸审核 is null";
            gridControl3.DataSource = SQLhelp.GetDataTable(sql5, CommandType.Text);
            gridView3.Columns["id"].Visible = false;
            string sql6 = "select id,工作令号,项目名称,设备名称,项目主管,时间,优先级,设备负责人,技术部通过,是否提交,图纸下达,采购项目负责人,装配负责人,技术方案考核绩效点,料单考核绩效点 from tb_jishubumen  where 项目负责人='" + yonghu + "'  ";    
            gridControl1.DataSource = SQLhelp.GetDataTable(sql6, CommandType.Text);
          
            string sql9 = "select id,工作令号,项目名称,设备名称,技术指标,项目负责人,设备负责人,机械负责人,电气负责人,项目主管,方向,数量,制造类型,设备预计结束时间,附件名称,时间,优先级,技术要求反馈内容 from tb_jishubumen  where 是否提交=1  and 技术部通过=1 and 图纸下达=0 and 图纸审核 =1  and 设备负责人='" + yonghu + "' ";
            gridControl5.DataSource = SQLhelp.GetDataTable(sql9, CommandType.Text);
            gridView5.Columns["id"].Visible = false;
            string sql10= "select id,工作令号,项目名称,设备名称,技术指标,项目负责人,设备负责人,机械负责人,电气负责人,项目主管,方向,数量,制造类型,设备预计结束时间,附件名称,时间,优先级,技术要求反馈内容 from tb_jishubumen  where 是否提交=1  and 技术部通过=1 and 图纸下达=0 and 图纸审核 =0  and 设备负责人='" + yonghu + "' ";
            gridControl4.DataSource = SQLhelp.GetDataTable(sql10, CommandType.Text);
            gridView4.Columns["id"].Visible = false;

        }
       
        private void dataGridViewX2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex < 0 && e.RowIndex >= 0)
            {
                e.Paint(e.ClipBounds, DataGridViewPaintParts.All);
                Rectangle rectangle = e.CellBounds;
                rectangle.Inflate(-2, -2);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.CellStyle.Font, rectangle, e.CellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
                e.Handled = true;
            }
        }
        
        

        
        
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                byte[] mypdffile = null;
                string ConStr = "Select 附件 From tb_jishubumen where 工作令号= '" + gonglinghao + "' and 项目名称= '" + xiangmu + "' and 设备名称='" + shebei + "'";
                mypdffile = SQLhelp.duqu(ConStr, CommandType.Text);
                string sql1111= "select 附件名称,附件类型  From tb_jishubumen where 工作令号= '" + gonglinghao + "' and 项目名称= '" + xiangmu + "' and 设备名称='" + shebei + "'";
                DataTable dtt = SQLhelp.GetDataTable(sql1111, CommandType.Text);
                string mingcheng = dtt.Rows[0]["附件名称"].ToString();
                    string leixing = dtt.Rows[0]["附件类型"].ToString();

                string lujing = xuanzelujing + "\\" + mingcheng + "." + leixing;
                    FileStream fs = new FileStream(lujing, FileMode.Create);
                    fs.Write(mypdffile, 0, mypdffile.Length);
                    fs.Flush();
                    fs.Close();
                
                MessageBox.Show("下载成功");//显示异常信息
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);//显示异常信息
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            fpro.Close();
            
        }
        
        

        private void 查看料单ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string gonglinghao = Convert.ToString(this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "工作令号"));
            string xiangmumingcheng = Convert.ToString(this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "项目名称"));
            string shebeimingcheng = Convert.ToString(this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "设备名称"));
            string shijian = Convert.ToString(this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "时间"));
            string shuliang = Convert.ToString(this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "数量"));
            string dingwei = Convert.ToString(this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "id"));
            FrLiaodan form = new FrLiaodan();
            form.gonglinghao = gonglinghao;
            form.xiangmu = xiangmumingcheng;
            form.shebei = shebeimingcheng;
            form.shijian = shijian;
            form.shuliang11 = shuliang;
            form.yonghu = yonghu;
            form.dingwei = dingwei;
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
            }
        }

    
        
    
        private void 项目分解ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (gridView1.RowCount <= 0)//判断是否选中要删除的行
            {
                MessageBox.Show("请选中行！");
                return;
            }
            string gonglinghao = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号"));
            string xiangmumingcheng = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "项目名称"));
            string zhuguan = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "项目主管"));

            string caigou = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "采购项目负责人"));
            string zhuangpei = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "装配负责人"));

            

            //DateTime dangqian = DateTime.Now;
            //Random ran = new Random();
            //string shijian = dangqian.AddSeconds(Convert.ToDouble(ran.Next(1, 10000))).ToString();
            
            
            //string sql2 = "INSERT INTO tb_jishubumen(工作令号,项目名称,项目主管,时间,是否下达,生产部确认,图纸下达,技术部通过,优先级,加工确认,装配确认,调试确认,物流部确认,仓库确认,是否提交,项目负责人,采购项目负责人,装配负责人,物流部最终确认) VALUES('" + gonglinghao + "', '" + xiangmumingcheng + "', '" + zhuguan + "', '" + shijian + "',0,0,0,0,0,0,0,0,0,0,0,'" + yonghu + "','" + caigou + "','" + zhuangpei + "',0)";
            //SQLhelp.ExecuteScalar(sql2, CommandType.Text);

            //string sql3 = "select id from tb_jishubumen where 工作令号='" + gonglinghao + "'and 项目名称='" + xiangmumingcheng + "' and 项目主管='" + zhuguan + "' and 时间='" + shijian + "'";
            //string id = SQLhelp.ExecuteScalar(sql3, CommandType.Text).ToString();

            Frchuli form = new Frchuli();
            form.yonghu = yonghu;
            
            form.gonglinghao = gonglinghao;
            form.xiangmumingcheng = xiangmumingcheng;
            form.caigou = caigou;
            form.zhuangpei = zhuangpei;
            form.zhuguan = zhuguan;
            form.ShowDialog();

            Reload();

        }

       
        private void 删除该行ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string youxianji = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "优先级"));
            string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
            if (youxianji == "1")
            {
                MessageBox.Show("主项目不能删除，请删除项目分解后的一行！");
                return;

            }

            string gonglinghao = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号"));
            string xiangmumingcheng = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "项目名称"));
            string shijian = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "时间"));
            if (MessageBox.Show("确认删除吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                if (youxianji == "0")
                {
                    string sql11 = "select 技术部通过 from tb_jishubumen where id='" + id + "'";
                    string queren = SQLhelp.ExecuteScalar(sql11, CommandType.Text).ToString();

                    if (queren == "0")
                    {
                        string sql = "delete from tb_jishubumen where id='" + id + "'";
                        SQLhelp.ExecuteScalar(sql, CommandType.Text);
                        string sql1 = "delete from tb_caigouliaodan where 工作令号= '" + gonglinghao + "' and 项目名称= '" + xiangmumingcheng + "' and 时间='" + shijian + "'";
                        SQLhelp.ExecuteScalar(sql1, CommandType.Text);
                        MessageBox.Show("删除成功！");
                        Reload();
                    }
                    if (queren == "1")
                    {
                        MessageBox.Show("已通过项目无法删除！");
                        return;
                    }

                }
            }

        }

        private void 保存ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            
        }

        

        private void 查看料单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string gonglinghao = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号"));
            string xiangmumingcheng = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "项目名称"));
            string shebeimingcheng = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "设备名称"));
            string shijian = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "时间"));
            FrShengchanbuzongliaodan form = new FrShengchanbuzongliaodan();
            form.gongzuolinghao = gonglinghao;
            form.xiangmumingcheng = xiangmumingcheng;
            form.shebeimingcheng = shebeimingcheng;
            form.shijian = shijian;
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {


            }
        }

        private void 提交料单审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认提交吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string id1 = Convert.ToString(this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "id"));
                string gonglinghao = Convert.ToString(this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "工作令号"));
                string xiangmumingcheng = Convert.ToString(this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "项目名称"));
                string shebeimingcheng = Convert.ToString(this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "设备名称"));
                string shijian = Convert.ToString(this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "时间"));
                string shuliang = Convert.ToString(this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "数量"));
                string zhizaoleixing = Convert.ToString(this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "制造类型"));
                string sql = "select 制造类型,编码 from tb_caigouliaodan where 工作令号='" + gonglinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "' and 时间='" + shijian + "' ";
                DataTable dttt = SQLhelp.GetDataTable(sql, CommandType.Text);
                string sql112 = "select 料单品种数 from tb_jishubumen where id='" + id1 + "'";
                string pinzhongshu11= Convert.ToString( SQLhelp.ExecuteScalar(sql112, CommandType.Text));
                string sql22 = "select 设备划分 from tb_jishubumen where id='" + id1 + "'";
                string shebeihuafen= Convert.ToString(SQLhelp.ExecuteScalar(sql22, CommandType.Text));
                //if(pinzhongshu11=="")
                //{
                //    MessageBox.Show("未填写料单品种数！如果要修改请联系信息化事业部");
                //    return;
                //}
                //double pinzhongshu =Convert.ToDouble( SQLhelp.ExecuteScalar(sql112, CommandType.Text).ToString());
                //double jisuan = dttt.Rows.Count;
                //if(jisuan !=pinzhongshu)
                //{
                //    MessageBox.Show("填写的料单品种数与实际料单录入不符合！如果要修改请联系信息化事业部");
                //    return;
                //}
                if (shebeihuafen == "")
                {
                    MessageBox.Show("未填写设备划分！如果要修改请联系信息化事业部");
                    return;
                }
                if (dttt.Rows.Count == 0)
                {
                    MessageBox.Show("料单无内容,无法提交！");
                    return;
                }
                for (int i = 0; i < dttt.Rows.Count; i++)
                {
                    string a = Convert.ToString(dttt.Rows[i]["制造类型"]);
                    if (a == "")
                    {
                        MessageBox.Show("料单中有的没有设定具体的制造类型！");
                        return;

                    }

                    string b = Convert.ToString(dttt.Rows[i]["编码"]);

                    if (b == "" && a != "零件")
                    {
                        MessageBox.Show("必须有新编码！");
                        return;

                    }

                    if (b == "" && a != "零件")
                    {
                        MessageBox.Show("必须有新编码！");
                        return;

                    }


                }

                if(zhizaoleixing=="外购")
                {

                    for (int i = 0; i < dttt.Rows.Count; i++)
                    {
                        string a = Convert.ToString(dttt.Rows[i]["制造类型"]);
                        if (a == "")
                        {
                            MessageBox.Show("料单中有的没有设定具体的制造类型！");
                            return;
                        }

                        if (a == "零件")
                        {
                            MessageBox.Show("料单是外购，但是料单中有的制造类型是零件，请联系信息化事业部更改制造类型！");
                            return;                         
                        }
                    }
                }

                string id = Convert.ToString(this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "id"));
                string sql1 = "update tb_jishubumen set 技术部图纸审核=1,图纸审核=0 where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql1, CommandType.Text);
                MessageBox.Show("提交成功！");
                Reload();
            }

        }
        private void 下达图纸ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认下达吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string gongzuolinghao = Convert.ToString(this.gridView5.GetRowCellValue(this.gridView5.FocusedRowHandle, "工作令号"));
                string xiangmumingcheng = Convert.ToString(this.gridView5.GetRowCellValue(this.gridView5.FocusedRowHandle, "项目名称"));
                string shebeimingcheng = Convert.ToString(this.gridView5.GetRowCellValue(this.gridView5.FocusedRowHandle, "设备名称"));
                string shijian = Convert.ToString(this.gridView5.GetRowCellValue(this.gridView5.FocusedRowHandle, "时间"));

                string sql445566 = "update tb_caigouliaodan set 收到料单日期='" + DateTime.Now + "' where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "' and 时间='" + shijian + "'";
                SQLhelp.ExecuteScalar(sql445566, CommandType.Text);
                
                string sql123123 = "select * from tb_caigouliaodan where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "' and 时间='" + shijian + "'";
                DataTable xiangxi = SQLhelp.GetDataTable(sql123123, CommandType.Text);

                //修改要求到货日期
                for (int i = 0; i < xiangxi.Rows.Count; i++)
                {
                    if(Convert.ToString(xiangxi.Rows[i]["制造类型"]) == "零件")
                    {
                        DateTime timelingjian = Convert.ToDateTime(xiangxi.Rows[i]["收到料单日期"]);
                        string sqllingjian = "update tb_caigouliaodan set 要求到货日期='" + timelingjian.AddDays(30) + "' where id='" + xiangxi.Rows[i]["id"].ToString() + "'";
                       SQLhelp.ExecuteScalar(sqllingjian, CommandType.Text);
                    }
                    if(Convert.ToString(xiangxi.Rows[i]["制造类型"]) == "机械标准件")
                    {
                        DateTime timejixie = Convert.ToDateTime(xiangxi.Rows[i]["收到料单日期"]);
                        string sqljixie = "update tb_caigouliaodan set 要求到货日期='" + timejixie.AddDays(30) + "' where id='" + xiangxi.Rows[i]["id"].ToString() + "'";
                     SQLhelp.ExecuteScalar(sqljixie, CommandType.Text);
                    }
                    if (Convert.ToString(xiangxi.Rows[i]["制造类型"]) == "电气标准件")
                    {
                        DateTime timedianqi = Convert.ToDateTime(xiangxi.Rows[i]["收到料单日期"]);
                        string sqldianqi = "update tb_caigouliaodan set 要求到货日期='" + timedianqi.AddDays(30) + "' where id='" + xiangxi.Rows[i]["id"].ToString() + "'";
                        string retdianqi = Convert.ToString(SQLhelp.ExecuteScalar(sqldianqi, CommandType.Text));
                    }
                    if (Convert.ToString(xiangxi.Rows[i]["制造类型"]) == "外购")
                    {
                        DateTime timewaigou = Convert.ToDateTime(xiangxi.Rows[i]["收到料单日期"]);
                        string sqlwaigou = "update tb_caigouliaodan set 要求到货日期='" + timewaigou.AddDays(60) + "' where id='" + xiangxi.Rows[i]["id"].ToString() + "'";
                        string retwaigou = Convert.ToString(SQLhelp.ExecuteScalar(sqlwaigou, CommandType.Text));
                    }
                }


                for (int i = 0; i < xiangxi.Rows.Count; i++)
                {
                    if (Convert.ToString(xiangxi.Rows[i]["安全库存"]) == "1")
                    {
                        string idd = Convert.ToString(xiangxi.Rows[i]["id"]);
                        double shuliang = Convert.ToDouble(xiangxi.Rows[i]["实际采购数量"]);
                        string bianma = Convert.ToString(xiangxi.Rows[i]["编码"]);
                        string sql12 = "update tb_xinerp set 需购买量=需购买量+'" + shuliang + "'  where 新编号='" + bianma + "'";
                        SQLhelp.ExecuteScalar(sql12, CommandType.Text);
                        string sql3344 = "update tb_caigouliaodan set 制造类型='库存件'  where id='" + idd + "'";
                        SQLhelp.ExecuteScalar(sql3344, CommandType.Text);
                    }
                }

                string id = Convert.ToString(this.gridView5.GetRowCellValue(this.gridView5.FocusedRowHandle, "id"));

                string sql6 = "select 采购项目负责人 from tb_jishubumen where 工作令号= '" + gongzuolinghao + "' and 项目名称= '" + xiangmumingcheng + "'";
                string cgxmfur = SQLhelp.ExecuteScalar(sql6, CommandType.Text).ToString();


                string xiadaren = Convert.ToString(this.gridView5.GetRowCellValue(this.gridView5.FocusedRowHandle, "设备负责人"));
                string tuzhixiadashiian = DateTime.Now.ToString();
                string zhizaoleixing = Convert.ToString(this.gridView5.GetRowCellValue(this.gridView5.FocusedRowHandle, "制造类型"));
              
                if (zhizaoleixing == "自制")
                {
                    string sql1112 = "select 预计采购结束时间 from tb_xiangmu where 工作令号= '" + gongzuolinghao + "' and 项目名称= '" + xiangmumingcheng + "' ";
                    string caigoujieshu = SQLhelp.ExecuteScalar(sql1112, CommandType.Text).ToString();

                    string shejishijian = DateTime.Now.ToString();

                    string sql12345 = "update  tb_xiangmu  set 实际设计结束时间='" + shejishijian + "' where 工作令号= '" + gongzuolinghao + "' and 项目名称= '" + xiangmumingcheng + "' ";
                    SQLhelp.ExecuteScalar(sql12345, CommandType.Text);

                    //if (caigoujieshu == "")
                    //{
                    //    string sql11 = "select 采购天数 from tb_xiangmu where 工作令号= '" + gongzuolinghao + "' and 项目名称= '" + xiangmumingcheng + "' ";
                    //    string caigoutianshu = SQLhelp.ExecuteScalar(sql11, CommandType.Text).ToString();

                    //    DateTime caigoushijian = DateTime.Now.AddDays(Convert.ToDouble(caigoutianshu));
                    //    string shejishijian= DateTime.Now.ToString();

                    //    string sql123 = "update  tb_xiangmu  set 实际设计结束时间='" + shejishijian + "' where 工作令号= '" + gongzuolinghao + "' and 项目名称= '" + xiangmumingcheng + "' ";
                    //    SQLhelp.ExecuteScalar(sql123, CommandType.Text);
                    //}

                    string sql111 = "select 预计加工结束时间 from tb_xiangmu where 工作令号= '" + gongzuolinghao + "' and 项目名称= '" + xiangmumingcheng + "' ";
                    string yujijiagongjieshu = SQLhelp.ExecuteScalar(sql111, CommandType.Text).ToString();

                    if (yujijiagongjieshu == "")
                    {

                        string sql11 = "select 加工天数 from tb_xiangmu where 工作令号= '" + gongzuolinghao + "' and 项目名称= '" + xiangmumingcheng + "' ";
                        string jiagongtianshu = SQLhelp.ExecuteScalar(sql11, CommandType.Text).ToString();

                        DateTime jiagongshijian = DateTime.Now.AddDays(Convert.ToDouble(jiagongtianshu));

                        string sql1 = "select 预计设计结束时间 from tb_xiangmu where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'";
                        DateTime panduan = Convert.ToDateTime(SQLhelp.ExecuteScalar(sql1, CommandType.Text));
                        DateTime panduan1 = panduan.AddDays(7);
                        if (panduan1 < DateTime.Now)
                        {
                            TimeSpan a = DateTime.Now - panduan1;
                            int b = Convert.ToInt32(a.TotalDays) + 1;

                            string dangqianshijian = DateTime.Now.ToString();
                            string sql1234 = "update tb_jishubumen set 料单考核绩效点='" + b + "'  where   id='" + id + "'";
                            SQLhelp.ExecuteScalar(sql1234, CommandType.Text);

                        }

                        if (panduan1 > DateTime.Now)
                        {
                            TimeSpan a = DateTime.Now - panduan1;
                            int b = Convert.ToInt32(a.TotalDays) + 1;

                            string dangqianshijian = DateTime.Now.ToString();
                            string sql1234 = "update tb_jishubumen set 料单考核绩效点=0  where   id='" + id + "'";
                            SQLhelp.ExecuteScalar(sql1234, CommandType.Text);

                        }


                        string sql = "update  tb_jishubumen  set 图纸下达=1  ,图纸下达时间='" + tuzhixiadashiian + "' where id= '" + id + "'";
                        SQLhelp.ExecuteScalar(sql, CommandType.Text);

                        string sql123 = "update  tb_caigouliaodan  set 申购人='" + xiadaren + "' where 工作令号= '" + gongzuolinghao + "' and 项目名称= '" + xiangmumingcheng + "' and 时间='" + shijian + "' and 设备名称='" + shebeimingcheng + "'";
                        SQLhelp.ExecuteScalar(sql123, CommandType.Text);

                        //string sql12345 = "update  tb_xiangmu  set 预计加工结束时间='" + jiagongshijian + "' where 工作令号= '" + gongzuolinghao + "' and 项目名称= '" + xiangmumingcheng + "' ";
                        //SQLhelp.ExecuteScalar(sql12345, CommandType.Text);

                        MessageBox.Show("提交成功！");
                        Reload();
                    }
                    if (yujijiagongjieshu != "")
                    {
                        string sql1 = "select 预计设计结束时间 from tb_xiangmu where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'";
                        DateTime panduan = Convert.ToDateTime(SQLhelp.ExecuteScalar(sql1, CommandType.Text));
                        DateTime panduan1 = panduan.AddDays(7);
                        if (panduan1 < DateTime.Now)
                        {
                            TimeSpan a = DateTime.Now - panduan1;
                            int b = Convert.ToInt32(a.TotalDays) + 1;

                            string dangqianshijian = DateTime.Now.ToString();
                            string sql1234 = "update tb_jishubumen set 料单考核绩效点='" + b + "'  where   id='" + id + "'";
                            SQLhelp.ExecuteScalar(sql1234, CommandType.Text);

                        }

                        if (panduan1 > DateTime.Now)
                        {
                            TimeSpan a = DateTime.Now - panduan1;
                            int b = Convert.ToInt32(a.TotalDays) + 1;

                            string dangqianshijian = DateTime.Now.ToString();
                            string sql1234 = "update tb_jishubumen set 料单考核绩效点=0  where   id='" + id + "'";
                            SQLhelp.ExecuteScalar(sql1234, CommandType.Text);

                        }


                        string sql = "update  tb_jishubumen  set 图纸下达=1  ,图纸下达时间='" + tuzhixiadashiian + "' where id= '" + id + "'";
                        SQLhelp.ExecuteScalar(sql, CommandType.Text);

                        string sql1111 = "update  tb_caigouliaodan  set 申购人='" + xiadaren + "' where 工作令号= '" + gongzuolinghao + "' and 项目名称= '" + xiangmumingcheng + "' and 时间='" + shijian + "' and 设备名称='" + shebeimingcheng + "'";
                        SQLhelp.ExecuteScalar(sql1111, CommandType.Text);
                    }
                }

                if (zhizaoleixing == "外购")
                {

                    string sendmessage = xiadaren + "  下了一份" + gongzuolinghao + "\r\n" + xiangmumingcheng + "  " + shebeimingcheng + "的采购料单" + "\r\n" +
                  "请物流部" + cgxmfur + "采购员查收！" + "|" + id;
                    NetWork3J NetWork3J = new NetWork3J(yonghu, "http://" + MyGlobal.ip + ":81/");
                    string sqlgetderp = "select 用户名 FROM tb_operator1 where 部门='物流部'";
                    DataTable mingdan = SQLhelp.GetDataTable(sqlgetderp, CommandType.Text);
                    NetWork3J.sendmessageById("聂燕", sendmessage);
                    NetWork3J.sendmessageById("齐景景", sendmessage);
                    NetWork3J.sendmessageById("钱常芳", sendmessage);
                    NetWork3J.sendmessageById("仲桂华", sendmessage);
                    NetWork3J.sendmessageById("王爱红", sendmessage);
                    for (int i = 0; i < mingdan.Rows.Count; i++)
                    {
                        string name = mingdan.Rows[i]["用户名"].ToString();
                        NetWork3J.sendmessageById(name, sendmessage);
                    }


                    string sql12345 = "update  tb_jishubumen  set 物流部确认=1  ,物流部完成时间='" + DateTime.Now + "' where id= '" + id + "' ";
                    SQLhelp.ExecuteScalar(sql12345, CommandType.Text);


                    string sql1112 = "select 预计采购结束时间 from tb_xiangmu where 工作令号= '" + gongzuolinghao + "' and 项目名称= '" + xiangmumingcheng + "' ";
                    string caigoujieshu = SQLhelp.ExecuteScalar(sql1112, CommandType.Text).ToString();

                    string shejishijian = DateTime.Now.ToString();

                    string sql123 = "update  tb_xiangmu  set 实际设计结束时间='" + shejishijian + "' where 工作令号= '" + gongzuolinghao + "' and 项目名称= '" + xiangmumingcheng + "' ";
                    SQLhelp.ExecuteScalar(sql123, CommandType.Text);

                    //if (caigoujieshu == "")
                    //{
                    //    string sql11 = "select 采购天数 from tb_xiangmu where 工作令号= '" + gongzuolinghao + "' and 项目名称= '" + xiangmumingcheng + "' ";
                    //    string caigoutianshu = SQLhelp.ExecuteScalar(sql11, CommandType.Text).ToString();

                    //    DateTime caigoushijian = DateTime.Now.AddDays(Convert.ToDouble(caigoutianshu));
                    //    string shejishijian = DateTime.Now.ToString();

                    //    string sql123 = "update  tb_xiangmu  set 实际设计结束时间='" + shejishijian + "' where 工作令号= '" + gongzuolinghao + "' and 项目名称= '" + xiangmumingcheng + "' ";
                    //    SQLhelp.ExecuteScalar(sql123, CommandType.Text);
                    //}
                    
                    string sql111 = "select 预计加工结束时间 from tb_xiangmu where 工作令号= '" + gongzuolinghao + "' and 项目名称= '" + xiangmumingcheng + "' ";
                    string yujijiagongjieshu = SQLhelp.ExecuteScalar(sql111, CommandType.Text).ToString();

                    //if (yujijiagongjieshu == "")
                    //{
                    //    string sql11 = "select 加工天数 from tb_xiangmu where 工作令号= '" + gongzuolinghao + "' and 项目名称= '" + xiangmumingcheng + "' ";
                    //    string jiagongtianshu = SQLhelp.ExecuteScalar(sql11, CommandType.Text).ToString();

                    //    DateTime jiagongshijian = DateTime.Now.AddDays(Convert.ToDouble(jiagongtianshu));


                    //    string sql123 = "update  tb_xiangmu  set 预计加工结束时间='" + jiagongshijian + "' where 工作令号= '" + gongzuolinghao + "' and 项目名称= '" + xiangmumingcheng + "' ";
                    //    SQLhelp.ExecuteScalar(sql123, CommandType.Text);

                    //}
                    string sqlaa = "select 预计设计结束时间 from tb_xiangmu where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'";
                    DateTime panduan = Convert.ToDateTime(SQLhelp.ExecuteScalar(sqlaa, CommandType.Text));
                    DateTime panduan1 = panduan.AddDays(7);
                    if (panduan1 < DateTime.Now)
                    {
                        TimeSpan a = DateTime.Now - panduan1;
                        int b = Convert.ToInt32(a.TotalDays) + 1;

                        string dangqianshijian = DateTime.Now.ToString();
                        string sql1234 = "update tb_jishubumen set 料单考核绩效点='" + b + "'  where   id='" + id + "'";
                        SQLhelp.ExecuteScalar(sql1234, CommandType.Text);

                    }

                    if (panduan1 > DateTime.Now)
                    {
                        TimeSpan a = DateTime.Now - panduan1;
                        int b = Convert.ToInt32(a.TotalDays) + 1;

                        string dangqianshijian = DateTime.Now.ToString();
                        string sql1234 = "update tb_jishubumen set 料单考核绩效点=0  where   id='" + id + "'";
                        SQLhelp.ExecuteScalar(sql1234, CommandType.Text);

                    }

                    string sql = "update  tb_jishubumen  set 图纸下达=1  ,图纸下达时间='" + tuzhixiadashiian + "' where id= '" + id + "' ";
                    SQLhelp.ExecuteScalar(sql, CommandType.Text);

                    string sql1 = "update  tb_caigouliaodan  set 申购人='" + xiadaren + "' where 工作令号= '" + gongzuolinghao + "' and 项目名称= '" + xiangmumingcheng + "' and 设备名称= '" + shebeimingcheng + "' and 时间='" + shijian + "'";
                    SQLhelp.ExecuteScalar(sql1, CommandType.Text);
                  
                }

                string sql12344 = "select 采购天数 from tb_xiangmu where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'";
                string tianshu = SQLhelp.ExecuteScalar(sql12344, CommandType.Text).ToString();

                if (tianshu != "")
                {
                    string sql2 = "select 图纸下达时间 from tb_jishubumen where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'  and 设备名称='" + shebeimingcheng + "'  and 时间='" + shijian + "' ";
                    string tuzhi = Convert.ToString(SQLhelp.ExecuteScalar(sql2, CommandType.Text));
                    if (tuzhi != "")
                    {
                        int bbbb = Convert.ToInt32(tianshu);
                        DateTime aaaa = Convert.ToDateTime(tuzhi).AddDays(bbbb);

                        string sql3 = "update tb_caigouliaodan set 要求到货日期='" + aaaa + "'  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'  and 设备名称='" + shebeimingcheng + "'  and 时间='" + shijian + "' ";
                        SQLhelp.GetDataTable(sql3, CommandType.Text);
                    }
                }
                MessageBox.Show("提交成功！");
                Reload();
            }
        }
        
        private void 查看料单ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (gridView5.RowCount==0)
            {
                MessageBox.Show("无数据可以选！");
                return;
            }                 
            string gonglinghao = Convert.ToString(this.gridView5.GetRowCellValue(this.gridView5.FocusedRowHandle, "工作令号"));
            string xiangmumingcheng = Convert.ToString(this.gridView5.GetRowCellValue(this.gridView5.FocusedRowHandle, "项目名称"));
            string shebeimingcheng = Convert.ToString(this.gridView5.GetRowCellValue(this.gridView5.FocusedRowHandle, "设备名称"));
            string shijian = Convert.ToString(this.gridView5.GetRowCellValue(this.gridView5.FocusedRowHandle, "时间"));
            FrShengchanbuzongliaodan form = new FrShengchanbuzongliaodan();
            form.gongzuolinghao = gonglinghao;
            form.xiangmumingcheng = xiangmumingcheng;
            form.shebeimingcheng = shebeimingcheng;
            form.shijian = shijian;
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
            }
        }
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }
        
        private void gridView4_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }


        }
  
        private void gridView3_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
        private void gridView5_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
      
        
    }
}
