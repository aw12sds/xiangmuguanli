using DevComponents.DotNetBar;
using NetWork.util;
using NetWorkLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 项目管理系统;
using 项目管理系统.技术部;
using 项目管理系统.生产部;

namespace xiangmuguanli.生产部
{
    public partial class FrShengchanguanli : Office2007Form
    {
        public FrShengchanguanli()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string yonghu;
        private void FrShengchanguanli_Load(object sender, EventArgs e)
        {

            Reload();

        }
        public void Reload()
        {

            string sql = "select id,工作令号,项目名称,设备名称,设备负责人,数量,时间 from tb_jishubumen where 制造类型='自制' and 是否提交=1 and 技术部通过=1  and 生产部确认=0 and 图纸下达=1 ";
           gridControl4.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
          
        }
     
        private void 确认下达ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

            if (MessageBox.Show("确认下达吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string id = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id"));
                string gonglinghao = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "工作令号"));
                string xiangmumingcheng = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "项目名称"));
                string shebeimingcheng = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "设备名称"));
                string shijian = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "时间"));
                string sql1 = "select  制造类型,id,原料成本,人工成本 from  tb_caigouliaodan   where 工作令号='" + gonglinghao+ "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "' and 时间='" + shijian + "'  ";
                DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string panduan = Convert.ToString(dt.Rows[i]["制造类型"]);

                    if (panduan.Trim() == "零件")
                    {
                        MessageBox.Show("有部分零件没有分配！");
                        return;
                    }
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string yuanliao = Convert.ToString(dt.Rows[i]["原料成本"]);
                    string rengong = Convert.ToString(dt.Rows[i]["人工成本"]);
                    string panduan = Convert.ToString(dt.Rows[i]["制造类型"]);

                    if (panduan.Trim() == "外协零部件" )
                    {
                       if(yuanliao==""|| rengong == "")
                        {
                            MessageBox.Show("请填写人工费与原料费！");
                            return;                       
                        }
                    }
                }
                string sql11 = "update tb_jishubumen  set 生产部确认=1 , 生产部确认时间='" + DateTime.Now.ToString() + "'  where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql11, CommandType.Text);
                string sql12 = "update tb_caigouliaodan  set 收到料单日期='" + DateTime.Now.ToString() + "' where 工作令号='" + gonglinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "' and 时间='" + shijian + "'  ";
                SQLhelp.ExecuteScalar(sql12, CommandType.Text);


                string sqlbiao= "select id,制造类型,收到料单日期 from tb_caigouliaodan where 工作令号='" + gonglinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "' and 时间='" + shijian + "'  ";
                DataTable biaoge = SQLhelp.GetDataTable(sqlbiao, CommandType.Text);
                //修改要求到货日期
                for (int i = 0; i < biaoge.Rows.Count; i++)
                {
                    if (Convert.ToString(biaoge.Rows[i]["制造类型"]) == "外协零部件")
                    {
                        DateTime timelingjian = Convert.ToDateTime(biaoge.Rows[i]["收到料单日期"]);
                        string sqllingjian = "update tb_caigouliaodan set 要求到货日期='" + timelingjian.AddDays(30) + "' where id='" + biaoge.Rows[i]["id"].ToString() + "'";
                        SQLhelp.ExecuteScalar(sqllingjian, CommandType.Text);
                    }
                    if (Convert.ToString(biaoge.Rows[i]["制造类型"]) == "机械标准件")
                    {
                        DateTime timejixie = Convert.ToDateTime(biaoge.Rows[i]["收到料单日期"]);
                        string sqljixie = "update tb_caigouliaodan set 要求到货日期='" + timejixie.AddDays(30) + "' where id='" + biaoge.Rows[i]["id"].ToString() + "'";
                        SQLhelp.ExecuteScalar(sqljixie, CommandType.Text);
                    }
                    if (Convert.ToString(biaoge.Rows[i]["制造类型"]) == "电气标准件")
                    {
                        DateTime timedianqi = Convert.ToDateTime(biaoge.Rows[i]["收到料单日期"]);
                        string sqldianqi = "update tb_caigouliaodan set 要求到货日期='" + timedianqi.AddDays(30) + "' where id='" + biaoge.Rows[i]["id"].ToString() + "'";
                        string retdianqi = Convert.ToString(SQLhelp.ExecuteScalar(sqldianqi, CommandType.Text));
                    }
                    if (Convert.ToString(biaoge.Rows[i]["制造类型"]) == "外购")
                    {
                        DateTime timewaigou = Convert.ToDateTime(biaoge.Rows[i]["收到料单日期"]);
                        string sqlwaigou = "update tb_caigouliaodan set 要求到货日期='" + timewaigou.AddDays(60) + "' where id='" + biaoge.Rows[i]["id"].ToString() + "'";
                        string retwaigou = Convert.ToString(SQLhelp.ExecuteScalar(sqlwaigou, CommandType.Text));
                    }
                }
                
                string sql12345 = "update  tb_jishubumen  set 物流部确认=1,物流部完成时间='" + DateTime.Now + "' where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql12345, CommandType.Text);

                string sendmessage = yonghu + "下了一份" + gonglinghao + "\r\n" + xiangmumingcheng + "  " + shebeimingcheng + "的采购订单" + "\r\n" + "请物流部注意！";
                NetWork3J NetWork3J = new NetWork3J(yonghu, "http://" + MyGlobal.ip + ":81/");
                string sqlgetderp = "select 用户名 FROM tb_operator1 where 部门='物流部'";
                DataTable mingdan = SQLhelp.GetDataTable(sqlgetderp, CommandType.Text);
                NetWork3J.sendmessageById("聂燕", sendmessage);
                //NetWork3J.sendmessageById("齐景景", sendmessage);
                //NetWork3J.sendmessageById("钱常芳", sendmessage);
                //NetWork3J.sendmessageById("仲桂华", sendmessage);
                //NetWork3J.sendmessageById("王爱红", sendmessage);
                for (int i = 0; i < mingdan.Rows.Count; i++)
                {
                    string name = mingdan.Rows[i]["用户名"].ToString();
                    NetWork3J.sendmessageById(name, sendmessage);
                }




                Reload();
            }

        }
        private void 转为外购ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认转为外购吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string id = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id"));
                string sql1 = "update tb_jishubumen  set 制造类型='外购',物流部确认=1,物流部完成时间='" + DateTime.Now + "'   where id='" + id + "' ";
                SQLhelp.ExecuteScalar(sql1, CommandType.Text);
                MessageBox.Show("转换成功！");
                Reload();
            }
        }
        
        private void gridView4_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView4_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
            {
                string gonglinghao = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "工作令号"));
                string xiangmumingcheng = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "项目名称"));
                string shebeimingcheng = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "设备名称"));
                string shijian  = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "时间"));
                string dingwei = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id"));
                FrShengchanbuliaodan form = new FrShengchanbuliaodan();
                form.gongzuolinghao = gonglinghao;
                form.xiangmumingcheng = xiangmumingcheng;
                form.shijian = shijian;
                form.dingwei = dingwei;
                form.yonghu = yonghu;
                form.shebeimingcheng = shebeimingcheng;
                form.Show();
            }
        }
    }
}
