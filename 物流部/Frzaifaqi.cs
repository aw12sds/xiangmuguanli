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
    public partial class Frzaifaqi : DevExpress.XtraEditors.XtraForm
    {
        public Frzaifaqi()
        {
            InitializeComponent();
        }
        public DataTable dt;
        public string yonghu;

        

        private void Frzaifaqi_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = dt;
            gridView1.Columns["id"].Visible = false;
        }

        private void 提交ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] c = gridView1.GetSelectedRows();
            foreach (int i in c)
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
                string buhegeshuliang = Convert.ToString(this.gridView1.GetRowCellValue(i, "不合格数量"));
                float a = 0;
                if (daohuoyanshoushuliang.Trim() == "")
                {
                    MessageBox.Show("请填写本次到货验收数量！");
                    return;
                }

                if (float.TryParse(daohuoyanshoushuliang, out a) == false)
                {
                    MessageBox.Show("本次数量必须是数字！");
                    return;
                }

                
                if (Convert.ToInt32(daohuoyanshoushuliang) > Convert.ToInt32(buhegeshuliang))
                {
                    MessageBox.Show("本次到货验收数量大于不合格数量，请重新提交！");
                    return;
                }
            }
            if (MessageBox.Show("确认提交吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                int[] a = gridView1.GetSelectedRows();
                bool b = false;
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
                    string buhegeshuliang = Convert.ToString(this.gridView1.GetRowCellValue(i, "不合格数量"));
                    string tijiaoshijian = DateTime.Now.ToString();

                    if (daohuoyanshoushuliang.Trim() == "")
                    {
                        MessageBox.Show("请填写本次到货验收数量！");
                        return;
                    }
                    if (Convert.ToInt32(daohuoyanshoushuliang) <= Convert.ToInt32(buhegeshuliang))
                    {
                        string sql = "update tb_caigouliaodan set 本次到货验收数量='" + daohuoyanshoushuliang + "',到货验收流程状态='1待检验',提交类型='物流部再发起' where id ='" + id + "'";
                        SQLhelp.ExecuteScalar(sql, CommandType.Text);

                        string sql2 = "insert into tb_daohuojilu (工作令号,项目名称,设备名称,名称,型号,单位,定位,到货数量,提交人,提交时间,供方名称,提交类型) values ('" + gongzuolinghao + "','" + xiangmumingcheng + "','" + shebeimingcheng + "','" + mingcheng + "','" + xinghao + "','" + danwei + "','" + id + "','" + daohuoyanshoushuliang + "','" + yonghu + "','" + tijiaoshijian + "','" + gongfangmingcheng + "','物流部再发起')";
                        SQLhelp.ExecuteScalar(sql2, CommandType.Text);
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
                    string id1 = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
                    string hetonghao = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "合同号"));
                    string gongfangmingcheng1 = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "供方名称"));
                    string sql11 = "select 到货检验人 from tb_caigouliaodan where id='" + id1 + "'";
                    string wuliuyuan = SQLhelp.ExecuteScalar(sql11, CommandType.Text).ToString();

                    string sendmessage = yonghu + " 未通过一份" + hetonghao + "\r\n" + gongfangmingcheng1 + " 的到货验收流程" + "\r\n" +
                      "请检验员" + wuliuyuan + "检验！";
                    NetWork3J NetWork3J = new NetWork3J(yonghu, "http://" + MyGlobal.ip + ":81/");
                    NetWork3J.sendmessageById(wuliuyuan, sendmessage);
                    
                }
            }
            
            else
            {
                MessageBox.Show("取消！");
                return;
            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            string daohuoshuliang = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "本次数量"));
            string shijicaigoushuliang = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "实际采购数量"));
            string buhegeshuliang = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "不合格数量"));
            float a = 0;

            if (float.TryParse(daohuoshuliang, out a) == false)
            {                
                MessageBox.Show("必须输入数字！");
                return;
            }
            if (Convert.ToInt32(buhegeshuliang) < Convert.ToInt32(daohuoshuliang))
            {
                MessageBox.Show("本次到货验收数量大于不合格数量，请重新提交！");
            }
        }

        

        

        
        

        
    }
}
