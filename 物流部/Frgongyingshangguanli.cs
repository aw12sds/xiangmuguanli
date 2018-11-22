using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.物流部
{
    public partial class Frgongyingshangguanli : Office2007Form
    {
        public Frgongyingshangguanli()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }

        private void Frgongyingshangguanli_Load(object sender, EventArgs e)
        {
            Reload();
        }
        public void Reload()
        {
            
            string sql = "select * from tb_gongfang  ";

            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            
            gridControl1.DataSource = dt;
            //gridView1.Columns["序号"].Visible = false;

        }

      
        private void buttonItem2_Click(object sender, EventArgs e)
        {
            string sql = "select * from tb_gongfang where 单位名称 like '%"+txtdanwei.Text.Trim()+"%'  ";

            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

           gridControl1.DataSource = dt;

        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            Frxinjiangongyingshang form1 = new Frxinjiangongyingshang();
            form1.ShowDialog();
            if(form1.DialogResult==DialogResult.OK)
            {

                Reload();
            }
        }

        private void 保存更改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                   
                    string xuhao = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "序号").ToString();
                    string xdanweimingcheng = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "单位名称").ToString();
                    string danweidizhi = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "单位地址").ToString();
                    string fadingdaibiaoren = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "法定代表人").ToString();
                    string weituodailiren = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "委托代理人").ToString();
                    string dianhua = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "电话").ToString();
                    string chuanzhen = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "传真").ToString();
                    string shuiwudengjihao = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "税务登记号").ToString();
                    string kaihuyinhang = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "开户银行").ToString();
                    string zhanghao = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "帐号").ToString();

                    string chanpinleixing = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "产品/服务类型").ToString();
                    string youxiang = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "邮箱").ToString();
                    string shengchandianhua = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "生产负责人电话").ToString();
                    string shengchanmingcheng = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "生产负责人名称").ToString();
                    string hanghao = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "行号").ToString();

                    string chengduihanghao = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "承兑行号").ToString();
                    string chengduizhanghao = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "承兑帐号").ToString();
                    string chengduikaihuyinhang = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "承兑开户银行").ToString();
                    string sql2 = "update tb_gongfang  set 单位名称= '" + xdanweimingcheng + "',单位地址= '" + danweidizhi + "',法定代表人=  '" + fadingdaibiaoren + "',委托代理人= '" + weituodailiren + "',电话 ='" + dianhua + "',传真= '" + chuanzhen + "',税务登记号= '" + shuiwudengjihao + "',开户银行='" + kaihuyinhang + "',帐号 = '" + zhanghao + "',[产品/服务类型]= '"+chanpinleixing+"',邮箱='"+youxiang+ "',生产负责人电话='" + shengchandianhua + "',生产负责人名称='" + shengchanmingcheng + "',承兑行号='" + chengduihanghao + "',承兑帐号='" + chengduizhanghao + "',承兑开户银行='" + chengduikaihuyinhang + "'   where 序号='" + xuhao + "'";
                    SQLhelp.ExecuteScalar(sql2, CommandType.Text);



                }
                MessageBox.Show("提交成功！");
                Reload();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }
    }
}
