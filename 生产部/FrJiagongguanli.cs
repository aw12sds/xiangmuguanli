using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.生产部
{
    public partial class FrJiagongguanli : Office2007Form
    {
        public string yonghu;
        public FrJiagongguanli()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }

        private void FrJiagongguanli_Load(object sender, EventArgs e)
        {
            Reload();
        }
        public void Reload()
        {

            string sql = "select id,工作令号,项目名称,设备名称,设备负责人,数量,时间 from tb_jishubumen where 制造类型='自制' and 是否提交=1 and 技术部通过=1  and 生产部确认=1 and 加工确认=0 ";

            gridControl1.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);
            gridView1.Columns["id"].Visible = false;
            gridView1.Columns["时间"].Visible = false;


        }

        private void 确认完成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认下达吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string gonglinghao = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号").ToString();
                string xiangmumingcheng = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "项目名称").ToString();
                string shebeimingcheng = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "设备名称").ToString();
                string shijian = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "时间").ToString();
                string sql = "update tb_jishubumen  set 加工确认=1 , 加工完成时间='" + DateTime.Now.ToString() + "'  where 工作令号='" + gonglinghao + "'  and 项目名称='" + xiangmumingcheng + "' and 时间='" + shijian + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);

                #region 更新生产执行中db_xiangmu表的零件的完成状态

                string SQL = "update db_xiangmu set 完成=1 where 工作令号='" + gonglinghao + "'  and 项目名称='" + xiangmumingcheng + "' and 时间='" + shijian + "' and 设备名称='"+ shebeimingcheng +"'";
                SQLhelp.ExecuteNonqueryShengchan(SQL, CommandType.Text);

                #endregion


                string sql111 = "select 预计调试结束时间 from tb_xiangmu where 工作令号= '" + gonglinghao + "' and 项目名称= '" + xiangmumingcheng + "' ";
                string yujitiaoshijieshu = SQLhelp.ExecuteScalar(sql111, CommandType.Text).ToString();

                string jiagongshijian = DateTime.Now.ToString();
                string sql123 = "update  tb_xiangmu  set 实际加工结束时间='" + jiagongshijian + "' where 工作令号= '" + gonglinghao + "' and 项目名称= '" + xiangmumingcheng + "' ";
                SQLhelp.ExecuteScalar(sql123, CommandType.Text);

                //if (yujitiaoshijieshu == "")
                //{

                //    string sql11 = "select 调试天数 from tb_xiangmu where 工作令号= '" + gonglinghao + "' and 项目名称= '" + xiangmumingcheng + "' ";
                //    string tiaoshitianshu = SQLhelp.ExecuteScalar(sql11, CommandType.Text).ToString();

                //    DateTime jiagongshijian = DateTime.Now.AddDays(Convert.ToDouble(tiaoshitianshu));
                
                //    string sql123 = "update  tb_xiangmu  set 预计加工结束时间='" + jiagongshijian + "' where 工作令号= '" + gonglinghao + "' and 项目名称= '" + xiangmumingcheng + "' ";
                //    SQLhelp.ExecuteScalar(sql123, CommandType.Text);
                    
                //}


                string sql1112 = "select 预计装配结束时间 from tb_xiangmu where 工作令号= '" + gonglinghao + "' and 项目名称= '" + xiangmumingcheng + "' ";
                string yujizhuangpei = SQLhelp.ExecuteScalar(sql1112, CommandType.Text).ToString();
                //if (yujizhuangpei == "")
                //{

                //    string sql11 = "select 装配天数 from tb_xiangmu where 工作令号= '" + gonglinghao + "' and 项目名称= '" + xiangmumingcheng + "' ";
                //    string zhuangpeitianshu = SQLhelp.ExecuteScalar(sql11, CommandType.Text).ToString();

                //    DateTime zhuangpeishijian = DateTime.Now.AddDays(Convert.ToDouble(zhuangpeitianshu));

                //    string sql123 = "update  tb_xiangmu  set 预计装配结束时间='" + zhuangpeishijian + "' where 工作令号= '" + gonglinghao + "' and 项目名称= '" + xiangmumingcheng + "' ";
                //    SQLhelp.ExecuteScalar(sql123, CommandType.Text);

                //}                
                Reload();
            }
        }
        
        
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
            {
                string gonglinghao = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号").ToString();
                string xiangmumingcheng = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "项目名称").ToString();
                string shebeimingcheng = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "设备名称").ToString();
                string shijian = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "时间").ToString();

                FrJiagongliaodan form = new FrJiagongliaodan();
                form.gongzuolinghao = gonglinghao;
                form.xiangmumingcheng = xiangmumingcheng;
                form.shebeimingcheng = shebeimingcheng;
                form.leixing = "加工";
                form.shijian = shijian;
                form.yonghu = yonghu;
                form.Show();
            }

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
