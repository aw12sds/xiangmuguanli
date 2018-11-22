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
using 项目管理系统.物流部;


namespace 项目管理系统.仓库
{
    public partial class Frdaohuoqueren : DevExpress.XtraEditors.XtraForm
    {
        public Frdaohuoqueren()
        {
            InitializeComponent();
        }
        public string yonghu;
        public string qingdan1="";
        public string qingdan2="";
        public string qingdan3="";
        private void Frdaohuoqueren_Load(object sender, EventArgs e)
        {
            Reload();
            Reload1();
            Reload2();
        }

        private void Reload()
        {
            //string sql1 = "select id,工作令号,项目名称,设备名称,实际采购数量,供方名称,型号,名称,单位,本次到货验收数量,发起到货验收数量,仓库描述,合同号 from  tb_caigouliaodan  where (到货仓库人='" + yonghu + "' and 仓库确认状态=0) or (到货仓库人='" + yonghu + "' and 到货验收流程状态='3到仓库')";
            string sql1 = "select id,工作令号,项目名称,设备名称,实际采购数量,供方名称,型号,名称,单位,本次到货验收数量,发起到货验收数量,仓库描述,合同号,合格数量,不合格数量 from  tb_caigouliaodan  where 到货仓库人='" + yonghu + "'and 到货类型='外协整机原材料' ";
            gridControl1.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridView1.Columns["id"].Visible = false;
        }
        public void reload()
        {
            string sql1 = "select id,工作令号,项目名称,设备名称,实际采购数量,供方名称,型号,名称,单位,本次到货验收数量,发起到货验收数量,仓库描述,合同号,合格数量,不合格数量 from  tb_caigouliaodan  where (到货仓库人='" + yonghu + "' and 发起到货验收数量!=实际采购数量 and 到货类型='外协整机原材料') or (到货仓库人='" + yonghu + "' and 合格数量=0 and 到货类型='外协整机原材料') or(到货仓库人='" + yonghu + "' and 不合格数量!=0 and 到货类型='外协整机原材料')";
            gridControl1.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridView1.Columns["id"].Visible = false;
            gridView1.Columns["发起到货验收数量"].Visible = false;
        }
        private void Reload1()
        {
            string sql1 = "select id,工作令号,项目名称,设备名称,实际采购数量,供方名称,型号,名称,单位,本次到货验收数量,发起到货验收数量,合同号,退回原因 from  tb_caigouliaodan  where 到货仓库人='" + yonghu + "' and 到货验收流程状态='1待入库'";
            gridControl2.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridView2.Columns["id"].Visible = false;
            gridView2.Columns["发起到货验收数量"].Visible = false;
        }
        private void Reload2()
        {
            string sql1 = "select id,工作令号,项目名称,设备名称,实际采购数量,供方名称,型号,名称,单位,本次到货验收数量,发起到货验收数量,合同号,退回原因 from  tb_caigouliaodan  where 到货检验人='" + yonghu + "' and 到货验收流程状态='1待收货'";
            gridControl3.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridView3.Columns["id"].Visible = false;
            gridView3.Columns["发起到货验收数量"].Visible = false;
        }
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void 提交ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认提交吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                int[] a = gridView1.GetSelectedRows();

                foreach (int i in a)
                {
                    string id = Convert.ToString(this.gridView1.GetRowCellValue(i, "id"));
                    string miaoshu = Convert.ToString(this.gridView1.GetRowCellValue(i, "仓库描述"));
                    string daohuoyanshoushuliang = Convert.ToString(this.gridView1.GetRowCellValue(i, "本次到货验收数量"));
                    string gongzuolinghao = Convert.ToString(this.gridView1.GetRowCellValue(i, "工作令号"));
                    string xiangmumingcheng = Convert.ToString(this.gridView1.GetRowCellValue(i, "项目名称"));
                    string shebeimingcheng = Convert.ToString(this.gridView1.GetRowCellValue(i, "设备名称"));
                    string mingcheng = Convert.ToString(this.gridView1.GetRowCellValue(i, "名称"));
                    string xinghao = Convert.ToString(this.gridView1.GetRowCellValue(i, "型号"));
                    string shijicaigoushuliang = Convert.ToString(this.gridView1.GetRowCellValue(i, "实际采购数量"));
                    string danwei = Convert.ToString(this.gridView1.GetRowCellValue(i, "单位"));
                    string hegeshuliang = Convert.ToString(this.gridView1.GetRowCellValue(i, "合格数量"));
                    string buhegeshuliang = Convert.ToString(this.gridView1.GetRowCellValue(i, "不合格数量"));
                    string hetonghao = Convert.ToString(this.gridView1.GetRowCellValue(i, "合同号"));
                    string gongfangmingcheng = Convert.ToString(this.gridView1.GetRowCellValue(i, "供方名称"));
                    string zhuangtai = Convert.ToString(this.gridView1.GetRowCellValue(i, "仓库确认状态"));
                                        
                    string tijiaoshijian = DateTime.Now.ToString();

                    string sql = "update tb_caigouliaodan set 仓库描述='" + miaoshu + "',仓库确认状态='1',提交类型='仓库到货审批',到货验收流程状态='8完成' where (id ='" + id + "' and 合格数量>=1 and 到货验收流程状态='3到仓库') or(id ='" + id + "' and 合格数量>=1 and 仓库确认状态=0)";
                    SQLhelp.ExecuteScalar(sql, CommandType.Text);

                    string sql2 = "insert into tb_daohuojilu (工作令号,项目名称,设备名称,名称,型号,单位,定位,到货数量,提交人,提交时间,供方名称,仓库确认状态,仓库描述,提交类型,实际采购数量,合格数量,不合格数量) values ('" + gongzuolinghao + "','" + xiangmumingcheng + "','" + shebeimingcheng + "','" + mingcheng + "','" + xinghao + "','" + danwei + "','" + id + "','" + daohuoyanshoushuliang + "','" + yonghu + "','" + tijiaoshijian + "','" + gongfangmingcheng +"','1','" + miaoshu + "','仓库到货审批','" + shijicaigoushuliang + "','"+ hegeshuliang + "','"+ buhegeshuliang + "')";
                    SQLhelp.ExecuteScalar(sql2, CommandType.Text);
                }
                MessageBox.Show("提交成功！");
                reload();
            }
            else
            {
                MessageBox.Show("取消！");
                return;
            }
        }

        private void 退回ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] a = gridView1.GetSelectedRows();
            foreach (int i in a)
            {
                string id = Convert.ToString(this.gridView1.GetRowCellValue(i, "id"));
                string miaoshu = Convert.ToString(this.gridView1.GetRowCellValue(i, "仓库描述"));

                if (miaoshu.Trim() == "")
                {
                    MessageBox.Show("请填写描述！");
                    return;
                }
            }
            if (MessageBox.Show("确认提交吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                int[] c = gridView1.GetSelectedRows();
                foreach (int i in c)
                {
                    string id = Convert.ToString(this.gridView1.GetRowCellValue(i, "id"));
                    string miaoshu = Convert.ToString(this.gridView1.GetRowCellValue(i, "仓库描述"));
                    string daohuoyanshoushuliang = Convert.ToString(this.gridView1.GetRowCellValue(i, "本次到货验收数量"));
                    string gongzuolinghao = Convert.ToString(this.gridView1.GetRowCellValue(i, "工作令号"));
                    string xiangmumingcheng = Convert.ToString(this.gridView1.GetRowCellValue(i, "项目名称"));
                    string shebeimingcheng = Convert.ToString(this.gridView1.GetRowCellValue(i, "设备名称"));
                    string mingcheng = Convert.ToString(this.gridView1.GetRowCellValue(i, "名称"));
                    string xinghao = Convert.ToString(this.gridView1.GetRowCellValue(i, "型号"));
                    string shijicaigoushuliang = Convert.ToString(this.gridView1.GetRowCellValue(i, "实际采购数量"));
                    string danwei = Convert.ToString(this.gridView1.GetRowCellValue(i, "单位"));
                    string hegeshuliang = Convert.ToString(this.gridView1.GetRowCellValue(i, "合格数量"));
                    string buhegeshuliang = Convert.ToString(this.gridView1.GetRowCellValue(i, "不合格数量"));
                    string hetonghao = Convert.ToString(this.gridView1.GetRowCellValue(i, "合同号"));
                    string gongfangmingcheng = Convert.ToString(this.gridView1.GetRowCellValue(i, "供方名称"));
                    string zhuangtai = Convert.ToString(this.gridView1.GetRowCellValue(i, "仓库确认状态"));

                    string tijiaoshijian = DateTime.Now.ToString();

                    string sql = "update tb_caigouliaodan set 仓库描述='" + miaoshu + "',仓库确认状态 = NULL,提交类型='仓库到货审批',到货验收流程状态='7再发起' where id ='" + id + "'";
                    SQLhelp.ExecuteScalar(sql, CommandType.Text);

                    string sql2 = "insert into tb_daohuojilu (工作令号,项目名称,设备名称,名称,型号,单位,定位,到货数量,提交人,提交时间,供方名称,仓库确认状态,仓库描述,提交类型,实际采购数量,合格数量,不合格数量) values ('" + gongzuolinghao + "','" + xiangmumingcheng + "','" + shebeimingcheng + "','" + mingcheng + "','" + xinghao + "','" + danwei + "','" + id + "','" + daohuoyanshoushuliang + "','" + yonghu + "','" + tijiaoshijian + "','" + gongfangmingcheng + "',NULL,'" + miaoshu + "','仓库到货审批','" + shijicaigoushuliang + "','" + hegeshuliang + "','" + buhegeshuliang + "')";
                    SQLhelp.ExecuteScalar(sql2, CommandType.Text);
                }
                MessageBox.Show("提交成功！");
                string id1 = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
                string hetonghao1 = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "合同号"));
                string gongfangmingcheng1 = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "供方名称"));

                string sql1 = "select 物流员 from tb_caigouliaodan where id='" + id1 + "'";
                string jianyanyuan = SQLhelp.ExecuteScalar(sql1, CommandType.Text).ToString();

                string sendmessage = yonghu + "  退回了一份" + hetonghao1 + "\r\n" + gongfangmingcheng1 + " 的到货验收流程" + "\r\n" +
              "请物流员" + jianyanyuan + "查看！";
                NetWork3J NetWork3J = new NetWork3J(yonghu, "http://" + MyGlobal.ip + ":81/");
                NetWork3J.sendmessageById(jianyanyuan, sendmessage);
                Reload();
            }
            
            else
            {
                MessageBox.Show("取消！");
                return;
            }
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void 查看详情ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();

            dt.Columns.Add("id");
            dt.Columns.Add("工作令号");
            dt.Columns.Add("项目名称");
            dt.Columns.Add("设备名称");
            dt.Columns.Add("供方名称");
            dt.Columns.Add("型号");
            dt.Columns.Add("名称");
            dt.Columns.Add("单位");
            dt.Columns.Add("实际采购数量");
            dt.Columns.Add("到货数量");
            dt.Columns.Add("提交人");
            dt.Columns.Add("提交时间");
            dt.Columns.Add("提交类型");
            dt.Columns.Add("物流部发票名称");
            dt.Columns.Add("物流部送货单名称");
            dt.Columns.Add("合格证名称");
            dt.Columns.Add("自检报告名称");
            dt.Columns.Add("验收图纸名称");
            dt.Columns.Add("查看该批次");

            dt1.Columns.Add("id");
            dt1.Columns.Add("工作令号");
            dt1.Columns.Add("项目名称");
            dt1.Columns.Add("设备名称");
            dt1.Columns.Add("供方名称");
            dt1.Columns.Add("型号");
            dt1.Columns.Add("名称");
            dt1.Columns.Add("单位");
            dt1.Columns.Add("实际采购数量");
            dt1.Columns.Add("到货数量");
            dt1.Columns.Add("提交人");
            dt1.Columns.Add("提交时间");
            dt1.Columns.Add("提交类型");
            dt1.Columns.Add("物流部发票名称");
            dt1.Columns.Add("物流部送货单名称");
            dt1.Columns.Add("合格证名称");
            dt1.Columns.Add("自检报告名称");
            dt1.Columns.Add("验收图纸名称");
            dt1.Columns.Add("查看该批次");


            string id = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();

            string sql = "select id,工作令号,项目名称,设备名称,供方名称,型号,名称,单位,实际采购数量,到货数量,提交人,提交时间,物流部发票名称,物流部送货单名称,合格证名称,自检报告名称,验收图纸名称,查看该批次,提交类型 from tb_daohuojilu where 定位 = '" + id + "'";
            dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            dt1.Merge(dt, true, MissingSchemaAction.Ignore);

            string sql1 = "select 查看该批次 from tb_daohuojilu where 定位 = '" + id + "'";
            string qingdan = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));

            Frchakanjilu form = new Frchakanjilu();
            form.dt = dt1;
            form.yonghu = yonghu;
            form.qingdan = qingdan;
            form.ShowDialog();
        }

        private void 确认ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] c = gridView2.GetSelectedRows();
            foreach (int i in c)
            {
                string id = gridView2.GetRowCellValue(i, "id").ToString();
                qingdan1 += id + "|";
            }

            if (qingdan1 == "")
            {
                MessageBox.Show("没有选中，请选中！");
                return;
            }

            if (MessageBox.Show("确认提交吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                int[] a = gridView2.GetSelectedRows();

                foreach (int i in a)
                {
                    string id = Convert.ToString(this.gridView2.GetRowCellValue(i, "id"));
                    string miaoshu = Convert.ToString(this.gridView2.GetRowCellValue(i, "仓库描述"));
                    string daohuoyanshoushuliang = Convert.ToString(this.gridView2.GetRowCellValue(i, "本次到货验收数量"));
                    string gongzuolinghao = Convert.ToString(this.gridView2.GetRowCellValue(i, "工作令号"));
                    string xiangmumingcheng = Convert.ToString(this.gridView2.GetRowCellValue(i, "项目名称"));
                    string shebeimingcheng = Convert.ToString(this.gridView2.GetRowCellValue(i, "设备名称"));
                    string mingcheng = Convert.ToString(this.gridView2.GetRowCellValue(i, "名称"));
                    string xinghao = Convert.ToString(this.gridView2.GetRowCellValue(i, "型号"));
                    string shijicaigoushuliang = Convert.ToString(this.gridView2.GetRowCellValue(i, "实际采购数量"));
                    string danwei = Convert.ToString(this.gridView2.GetRowCellValue(i, "单位"));
                   
                    string hetonghao = Convert.ToString(this.gridView2.GetRowCellValue(i, "合同号"));
                    string gongfangmingcheng = Convert.ToString(this.gridView2.GetRowCellValue(i, "供方名称"));
                    string zhuangtai = Convert.ToString(this.gridView2.GetRowCellValue(i, "仓库确认状态"));

                    string tijiaoshijian = DateTime.Now.ToString();

                    string sql = "update tb_caigouliaodan set 仓库描述='" + miaoshu + "',仓库确认状态='1',提交类型='仓库到货审批',到货验收流程状态='8完成' where (id ='" + id + "'  and 到货验收流程状态='1待入库') or(id ='" + id + "' and 到货类型='五金辅材标准件' and 仓库确认状态=0)";
                    SQLhelp.ExecuteScalar(sql, CommandType.Text);

                    string sql2 = "insert into tb_daohuojilu (工作令号,项目名称,设备名称,名称,型号,单位,定位,到货数量,提交人,提交时间,供方名称,仓库确认状态,仓库描述,提交类型,实际采购数量) values ('" + gongzuolinghao + "','" + xiangmumingcheng + "','" + shebeimingcheng + "','" + mingcheng + "','" + xinghao + "','" + danwei + "','" + id + "','" + daohuoyanshoushuliang + "','" + yonghu + "','" + tijiaoshijian + "','" + gongfangmingcheng + "','1','" + miaoshu + "','仓库到货审批','" + shijicaigoushuliang + "')";
                    SQLhelp.ExecuteScalar(sql2, CommandType.Text);
                }
                MessageBox.Show("提交成功！");
                Reload1();
            }
            else
            {
                MessageBox.Show("取消！");
                return;
            }
        }

        private void 退回ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int[] a = gridView2.GetSelectedRows();
            foreach (int i in a)
            {
                string id = Convert.ToString(this.gridView2.GetRowCellValue(i, "id"));
                qingdan2 += id + "|";
                string miaoshu = Convert.ToString(this.gridView2.GetRowCellValue(i, "退回原因"));

                if (miaoshu.Trim() == "")
                {
                    MessageBox.Show("请填写退回原因！");
                    return;
                }
            }
            if (qingdan2 == "")
            {
                MessageBox.Show("没有选中，请选中！");
                return;
            }
            if (MessageBox.Show("确认提交吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                int[] c = gridView2.GetSelectedRows();
                foreach (int i in c)
                {
                    string id = Convert.ToString(this.gridView2.GetRowCellValue(i, "id"));
                    string miaoshu = Convert.ToString(this.gridView2.GetRowCellValue(i, "仓库描述"));
                    string daohuoyanshoushuliang = Convert.ToString(this.gridView2.GetRowCellValue(i, "本次到货验收数量"));
                    string gongzuolinghao = Convert.ToString(this.gridView2.GetRowCellValue(i, "工作令号"));
                    string xiangmumingcheng = Convert.ToString(this.gridView2.GetRowCellValue(i, "项目名称"));
                    string shebeimingcheng = Convert.ToString(this.gridView2.GetRowCellValue(i, "设备名称"));
                    string mingcheng = Convert.ToString(this.gridView2.GetRowCellValue(i, "名称"));
                    string xinghao = Convert.ToString(this.gridView2.GetRowCellValue(i, "型号"));
                    string shijicaigoushuliang = Convert.ToString(this.gridView2.GetRowCellValue(i, "实际采购数量"));
                    string danwei = Convert.ToString(this.gridView2.GetRowCellValue(i, "单位"));
                    
                    string hetonghao = Convert.ToString(this.gridView2.GetRowCellValue(i, "合同号"));
                    string gongfangmingcheng = Convert.ToString(this.gridView2.GetRowCellValue(i, "供方名称"));
                    string zhuangtai = Convert.ToString(this.gridView2.GetRowCellValue(i, "仓库确认状态"));

                    string tijiaoshijian = DateTime.Now.ToString();

                    string sql = "update tb_caigouliaodan set 仓库描述='" + miaoshu + "',仓库确认状态 = NULL,提交类型='仓库到货审批',到货验收流程状态='7再发起' where id ='" + id + "'";
                    SQLhelp.ExecuteScalar(sql, CommandType.Text);

                    string sql2 = "insert into tb_daohuojilu (工作令号,项目名称,设备名称,名称,型号,单位,定位,到货数量,提交人,提交时间,供方名称,仓库确认状态,退回原因,提交类型,实际采购数量) values ('" + gongzuolinghao + "','" + xiangmumingcheng + "','" + shebeimingcheng + "','" + mingcheng + "','" + xinghao + "','" + danwei + "','" + id + "','" + daohuoyanshoushuliang + "','" + yonghu + "','" + tijiaoshijian + "','" + gongfangmingcheng + "',NULL,'" + miaoshu + "','仓库到货审批','" + shijicaigoushuliang + "')";
                    SQLhelp.ExecuteScalar(sql2, CommandType.Text);
                }
                MessageBox.Show("提交成功！");
                string id1 = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id"));
                string hetonghao1 = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "合同号"));
                string gongfangmingcheng1 = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "供方名称"));

                string sql1 = "select 物流员 from tb_caigouliaodan where id='" + id1 + "'";
                string jianyanyuan = SQLhelp.ExecuteScalar(sql1, CommandType.Text).ToString();

                string sendmessage = yonghu + "  退回了一份" + hetonghao1 + "\r\n" + gongfangmingcheng1 + " 的到货验收流程" + "\r\n" +
              "请物流员" + jianyanyuan + "查看！";
                NetWork3J NetWork3J = new NetWork3J(yonghu, "http://" + MyGlobal.ip + ":81/");
                NetWork3J.sendmessageById(jianyanyuan, sendmessage);
                Reload1();
            }

            else
            {
                MessageBox.Show("取消！");
                return;
            }
        }

        private void 刷新ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reload1();
        }

        private void 查看详情ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();

            dt.Columns.Add("id");
            dt.Columns.Add("工作令号");
            dt.Columns.Add("项目名称");
            dt.Columns.Add("设备名称");
            dt.Columns.Add("供方名称");
            dt.Columns.Add("型号");
            dt.Columns.Add("名称");
            dt.Columns.Add("单位");
            dt.Columns.Add("实际采购数量");
            dt.Columns.Add("到货数量");
            dt.Columns.Add("提交人");
            dt.Columns.Add("提交时间");
            dt.Columns.Add("提交类型");
            dt.Columns.Add("物流部发票名称");
            dt.Columns.Add("物流部送货单名称");
            dt.Columns.Add("合格证名称");
            
            dt.Columns.Add("查看该批次");

            dt1.Columns.Add("id");
            dt1.Columns.Add("工作令号");
            dt1.Columns.Add("项目名称");
            dt1.Columns.Add("设备名称");
            dt1.Columns.Add("供方名称");
            dt1.Columns.Add("型号");
            dt1.Columns.Add("名称");
            dt1.Columns.Add("单位");
            dt1.Columns.Add("实际采购数量");
            dt1.Columns.Add("到货数量");
            dt1.Columns.Add("提交人");
            dt1.Columns.Add("提交时间");
            dt1.Columns.Add("提交类型");
            dt1.Columns.Add("物流部发票名称");
            dt1.Columns.Add("物流部送货单名称");
            dt1.Columns.Add("合格证名称");
            
            dt1.Columns.Add("查看该批次");


            string id = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id").ToString();

            string sql = "select id,工作令号,项目名称,设备名称,供方名称,型号,名称,单位,实际采购数量,到货数量,提交人,提交时间,物流部发票名称,物流部送货单名称,合格证名称,查看该批次,提交类型 from tb_daohuojilu where 定位 = '" + id + "'";
            dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            dt1.Merge(dt, true, MissingSchemaAction.Ignore);

            string sql1 = "select 查看该批次 from tb_daohuojilu where 定位 = '" + id + "'";
            string qingdan = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));

            Frwujinjilu form = new Frwujinjilu();
            form.dt = dt1;
            form.yonghu = yonghu;
            form.qingdan = qingdan;
            form.ShowDialog();
        }

        private void 确认到货ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认完成吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                int[] c = gridView3.GetSelectedRows();
                string tijiaoshijian = DateTime.Now.ToString();
                foreach (int i in c)
                {
                    string id1 = Convert.ToString(this.gridView3.GetRowCellValue(i, "id"));

                    string sq2 = "update tb_caigouliaodan set 到货验收流程状态='2已收货',提交类型='收货人进行确认' where id ='" + id1 + "'";
                    SQLhelp.ExecuteScalar(sq2, CommandType.Text);

                    string sql4 = "update tb_caigouliaodan set 提交时间='" + tijiaoshijian + "',提交人='" + yonghu + "' where id ='" + id1 + "'";
                    SQLhelp.ExecuteScalar(sql4, CommandType.Text);

                    string sql3 = "insert into tb_daohuojilu  (工作令号,项目名称,设备名称,名称,供方名称,型号,单位,定位,到货数量,提交人,提交时间,提交类型,实际采购数量)select 工作令号,项目名称,设备名称,名称,供方名称,型号,单位,id,本次到货验收数量,提交人,提交时间,提交类型,实际采购数量  from tb_caigouliaodan where id ='" + id1 + "'";
                    SQLhelp.ExecuteScalar(sql3, CommandType.Text);
                }
                MessageBox.Show("提交成功！");
                Reload2();
            }
            else
            {
                MessageBox.Show("取消！");
                return;
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

        private void 退回ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认提交吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                int[] c = gridView3.GetSelectedRows();
                string tijiaoshijian = DateTime.Now.ToString();
                foreach (int i in c)
                {
                    string id1 = Convert.ToString(this.gridView3.GetRowCellValue(i, "id"));
                    string tuihuiyuanyin = Convert.ToString(this.gridView3.GetRowCellValue(i, "退回原因"));
                    string sq2 = "update tb_caigouliaodan set 到货验收流程状态='3退回',提交类型='收货人进行退回',提交时间='" + tijiaoshijian + "',提交人='" + yonghu + "',退回原因='" + tuihuiyuanyin + "' where id ='" + id1 + "'";
                    SQLhelp.ExecuteScalar(sq2, CommandType.Text);

                    string sql3 = "insert into tb_daohuojilu  (工作令号,项目名称,设备名称,名称,供方名称,型号,单位,定位,到货数量,提交人,提交时间,提交类型,实际采购数量,退回原因)select 工作令号,项目名称,设备名称,名称,供方名称,型号,单位,id,本次到货验收数量,提交人,提交时间,提交类型,实际采购数量,退回原因  from tb_caigouliaodan where id ='" + id1 + "'";
                    SQLhelp.ExecuteScalar(sql3, CommandType.Text);
                }
                MessageBox.Show("提交成功！");
                string id = Convert.ToString(this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "id"));
                string hetonghao = Convert.ToString(this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "合同号"));
                string gongfangmingcheng = Convert.ToString(this.gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "供方名称"));

                string sql1 = "select 物流员 from tb_caigouliaodan where id='" + id + "'";
                string jianyanyuan = SQLhelp.ExecuteScalar(sql1, CommandType.Text).ToString();

                string sendmessage = yonghu + "  退回了一份" + hetonghao + "\r\n" + gongfangmingcheng + " 的到货验收流程" + "\r\n" +
              "请物流员" + jianyanyuan + "查看！";
                NetWork3J NetWork3J = new NetWork3J(yonghu, "http://" + MyGlobal.ip + ":81/");
                NetWork3J.sendmessageById(jianyanyuan, sendmessage);

                Reload2();
            }
            else
            {
                MessageBox.Show("取消！");
                return;
            }
        }

        private void 查看记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();

            dt.Columns.Add("id");
            dt.Columns.Add("工作令号");
            dt.Columns.Add("项目名称");
            dt.Columns.Add("设备名称");
            dt.Columns.Add("供方名称");
            dt.Columns.Add("型号");
            dt.Columns.Add("名称");
            dt.Columns.Add("单位");
            dt.Columns.Add("实际采购数量");
            dt.Columns.Add("到货数量");
            dt.Columns.Add("提交人");
            dt.Columns.Add("提交时间");
            dt.Columns.Add("提交类型");
            dt.Columns.Add("物流部送货单名称");
            dt.Columns.Add("合格证名称");
            dt.Columns.Add("查看该批次");

            dt1.Columns.Add("id");
            dt1.Columns.Add("工作令号");
            dt1.Columns.Add("项目名称");
            dt1.Columns.Add("设备名称");
            dt1.Columns.Add("供方名称");
            dt1.Columns.Add("型号");
            dt1.Columns.Add("名称");
            dt1.Columns.Add("单位");
            dt1.Columns.Add("实际采购数量");
            dt1.Columns.Add("到货数量");
            dt1.Columns.Add("提交人");
            dt1.Columns.Add("提交时间");
            dt1.Columns.Add("提交类型");

            dt1.Columns.Add("物流部送货单名称");
            dt1.Columns.Add("合格证名称");

            dt1.Columns.Add("查看该批次");


            string id = gridView3.GetRowCellValue(this.gridView3.FocusedRowHandle, "id").ToString();

            string sql = "select id,工作令号,项目名称,设备名称,供方名称,型号,名称,单位,实际采购数量,到货数量,提交人,提交时间,物流部送货单名称,合格证名称,查看该批次,提交类型 from tb_daohuojilu where 定位 = '" + id + "'";
            dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            dt1.Merge(dt, true, MissingSchemaAction.Ignore);

            string sql1 = "select 查看该批次 from tb_daohuojilu where 定位 = '" + id + "'";
            string qingdan = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));

            Frgudingzichanjilu form = new Frgudingzichanjilu();
            form.dt = dt1;
            form.yonghu = yonghu;
            form.qingdan = qingdan;
            form.ShowDialog();
        }

        private void 刷新ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Reload2();
        }
    }
}
