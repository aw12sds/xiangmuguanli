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

namespace 项目管理系统.总经办
{
    public partial class Frzongjingbanshenpi : DevExpress.XtraEditors.XtraForm
    {
        public Frzongjingbanshenpi()
        {
            InitializeComponent();
        }
        public string yonghu;
        public string xuanzhong = "";
        
        private void Frzongjingbanshenpi_Load(object sender, EventArgs e)
        {
            reload();
            gridView1.OptionsSelection.ResetSelectionClickOutsideCheckboxSelector = true;
            Reload1();
        }

        public void reload()
        {
            string sql1 = "select id,工作令号,项目名称,设备名称,供方名称,型号,名称,单位,本次到货验收数量,发起到货验收数量,人工数,检验时间数,特殊耗材,报价总额,批复,合格数量,不合格数量,不合格描述,实际采购数量,供应商返工,自家返工,让步接受数,报废,合同号 from  tb_caigouliaodan  where  到货验收流程状态='5总经办审批'";
            gridControl1.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridView1.Columns["id"].Visible = false;
        }
        private void Reload1()
        {
            string sql1 = "select id,工作令号,项目名称,设备名称,实际采购数量,供方名称,型号,名称,单位,本次到货验收数量,发起到货验收数量,合同号,退回原因 from  tb_caigouliaodan  where 到货检验人='" + yonghu + "' and 到货验收流程状态='1待收货'";
            gridControl2.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridView2.Columns["id"].Visible = false;
            gridView2.Columns["发起到货验收数量"].Visible = false;
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void 通过审批ToolStripMenuItem_Click(object sender, EventArgs e)
        {                        
            if (MessageBox.Show("确认提交吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                int[] a = gridView1.GetSelectedRows();
                foreach (int i in a)
                {
                    string id = Convert.ToString(this.gridView1.GetRowCellValue(i, "id"));
                    string pifu = Convert.ToString(this.gridView1.GetRowCellValue(i, "批复"));
                    string daohuoyanshoushuliang = Convert.ToString(this.gridView1.GetRowCellValue(i, "本次到货验收数量"));
                    string gongzuolinghao = Convert.ToString(this.gridView1.GetRowCellValue(i, "工作令号"));
                    string xiangmumingcheng = Convert.ToString(this.gridView1.GetRowCellValue(i, "项目名称"));
                    string shebeimingcheng = Convert.ToString(this.gridView1.GetRowCellValue(i, "设备名称"));
                    string hetonghao1 = Convert.ToString(this.gridView1.GetRowCellValue(i, "合同号"));
                    string mingcheng = Convert.ToString(this.gridView1.GetRowCellValue(i, "名称"));
                    string xinghao = Convert.ToString(this.gridView1.GetRowCellValue(i, "型号"));
                    string shijicaigoushuliang = Convert.ToString(this.gridView1.GetRowCellValue(i, "实际采购数量"));
                    string danwei = Convert.ToString(this.gridView1.GetRowCellValue(i, "单位"));
                    string rengongshu = Convert.ToString(this.gridView1.GetRowCellValue(i, "人工数"));
                    string jianyanshijianshu = Convert.ToString(this.gridView1.GetRowCellValue(i, "检验时间数"));
                    string teshu = Convert.ToString(this.gridView1.GetRowCellValue(i, "特殊耗材"));
                    string baojia = Convert.ToString(this.gridView1.GetRowCellValue(i, "报价总额"));
                    string gongfangmingcheng = Convert.ToString(this.gridView1.GetRowCellValue(i, "供方名称"));
                    string buhegeshuliang = Convert.ToString(this.gridView1.GetRowCellValue(i, "不合格数量"));
                    string hegeshuliang = Convert.ToString(this.gridView1.GetRowCellValue(i, "合格数量"));
                    string miaoshu = Convert.ToString(this.gridView1.GetRowCellValue(i, "不合格描述"));
                    string tijiaoshijian = DateTime.Now.ToString();                                        
                    

                    string sql = "update tb_caigouliaodan set 批复='" + pifu + "',到货验收流程状态='6待采购',提交类型='总经理审批' where id ='" + id + "'";
                    SQLhelp.ExecuteScalar(sql, CommandType.Text);

                    string sql2 = "insert into tb_daohuojilu (工作令号,项目名称,设备名称,名称,型号,单位,定位,到货数量,提交人,提交时间,人工数,检验时间数,特殊耗材,批复,报价总额,供方名称,不合格数量,合格数量,不合格描述,提交类型,实际采购数量) values ('" + gongzuolinghao + "','" + xiangmumingcheng + "','" + shebeimingcheng + "','" + mingcheng + "','" + xinghao + "','" + danwei + "','" + id + "','" + daohuoyanshoushuliang + "','" + yonghu + "','" + tijiaoshijian + "','" + rengongshu + "','" + jianyanshijianshu + "','" + teshu + "','" + pifu + "','" + baojia + "','"+ gongfangmingcheng + "','"+ buhegeshuliang + "','"+ hegeshuliang + "','"+ miaoshu + "','总经理审批','"+shijicaigoushuliang+"')";
                    SQLhelp.ExecuteScalar(sql2, CommandType.Text);
                }
                MessageBox.Show("提交成功！");

                string id1 = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
                string hetonghao = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "合同号"));
                string gongfangmingcheng1 = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "供方名称"));
                string sql11 = "select 物流员 from tb_caigouliaodan where id='" + id1 + "'";
                string wuliuyuan = SQLhelp.ExecuteScalar(sql11, CommandType.Text).ToString();

                string sendmessage = yonghu + "  通过了一份" + hetonghao + "\r\n" + gongfangmingcheng1 + " 的到货验收流程" + "\r\n" +
                  "请物流员" + wuliuyuan + "检验！";
                NetWork3J NetWork3J = new NetWork3J(yonghu, "http://" + MyGlobal.ip + ":81/");
                NetWork3J.sendmessageById(wuliuyuan, sendmessage);

                reload();
            }
           
            else
            {
                MessageBox.Show("取消！");
                return;
            }
        }

        private void 不通过审批ToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            if (MessageBox.Show("确认提交吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                int[] a = gridView1.GetSelectedRows();
                
                foreach (int i in a)
                {
                    string id = Convert.ToString(this.gridView1.GetRowCellValue(i, "id"));
                    string pifu = Convert.ToString(this.gridView1.GetRowCellValue(i, "批复"));
                    string daohuoyanshoushuliang = Convert.ToString(this.gridView1.GetRowCellValue(i, "本次到货验收数量"));
                    string gongzuolinghao = Convert.ToString(this.gridView1.GetRowCellValue(i, "工作令号"));
                    string xiangmumingcheng = Convert.ToString(this.gridView1.GetRowCellValue(i, "项目名称"));
                    string shebeimingcheng = Convert.ToString(this.gridView1.GetRowCellValue(i, "设备名称"));
                    string hetonghao1 = Convert.ToString(this.gridView1.GetRowCellValue(i, "合同号"));
                    string mingcheng = Convert.ToString(this.gridView1.GetRowCellValue(i, "名称"));
                    string xinghao = Convert.ToString(this.gridView1.GetRowCellValue(i, "型号"));
                    string shijicaigoushuliang = Convert.ToString(this.gridView1.GetRowCellValue(i, "实际采购数量"));
                    string danwei = Convert.ToString(this.gridView1.GetRowCellValue(i, "单位"));
                    string rengongshu = Convert.ToString(this.gridView1.GetRowCellValue(i, "人工数"));
                    string jianyanshijianshu = Convert.ToString(this.gridView1.GetRowCellValue(i, "检验时间数"));
                    string teshu = Convert.ToString(this.gridView1.GetRowCellValue(i, "特殊耗材"));
                    string baojia = Convert.ToString(this.gridView1.GetRowCellValue(i, "报价总额"));
                    string gongfangmingcheng = Convert.ToString(this.gridView1.GetRowCellValue(i, "供方名称"));
                    string buhegeshuliang = Convert.ToString(this.gridView1.GetRowCellValue(i, "不合格数量"));
                    string hegeshuliang = Convert.ToString(this.gridView1.GetRowCellValue(i, "合格数量"));
                    string miaoshu = Convert.ToString(this.gridView1.GetRowCellValue(i, "不合格描述"));
                    string tijiaoshijian = DateTime.Now.ToString();
                    

                    string sql = "update tb_caigouliaodan set 批复='" + pifu + "',到货验收流程状态='4不合格待评审',提交类型='总经理审批' where id ='" + id + "'";
                    SQLhelp.ExecuteScalar(sql, CommandType.Text);

                    string sql2 = "insert into tb_daohuojilu (工作令号,项目名称,设备名称,名称,型号,单位,定位,到货数量,提交人,提交时间,人工数,检验时间数,特殊耗材,批复,报价总额,供方名称,不合格数量,合格数量,不合格描述,提交类型,实际采购数量) values ('" + gongzuolinghao + "','" + xiangmumingcheng + "','" + shebeimingcheng + "','" + mingcheng + "','" + xinghao + "','" + danwei + "','" + id + "','" + daohuoyanshoushuliang + "','" + yonghu + "','" + tijiaoshijian + "','" + rengongshu + "','" + jianyanshijianshu + "','" + teshu + "','" + pifu + "','" + baojia + "','" + gongfangmingcheng + "','" + buhegeshuliang + "','" + hegeshuliang + "','" + miaoshu + "','总经理审批','"+shijicaigoushuliang+"')";
                    SQLhelp.ExecuteScalar(sql2, CommandType.Text);
                }
                MessageBox.Show("提交成功！");

                string id1 = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
                string hetonghao = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "合同号"));
                string gongfangmingcheng1 = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "供方名称"));

                string sql13 = "select 到货检验人 from  tb_caigouliaodan  where id='" + id1 + "'";
                string jianyanrenyuan = Convert.ToString(SQLhelp.ExecuteScalar(sql13, CommandType.Text));

                string sql14 = "select 部门 from tb_operator where 用户名='" + jianyanrenyuan + "'";
                string bumen = Convert.ToString(sqlhelp111.ExecuteScalar(sql14, CommandType.Text));

                if (bumen == "精工事业部")
                {
                    string sendmessage = yonghu + "  未通过一份" + hetonghao + "\r\n" + gongfangmingcheng1 + "  的不合格评审流程" + "\r\n" +
              "请不合格评审员袁鹏评审！";
                    NetWork3J NetWork3J = new NetWork3J(yonghu, "http://" + MyGlobal.ip + ":81/");
                    NetWork3J.sendmessageById("袁鹏", sendmessage);
                }
                else
                {
                    string sendmessage = yonghu + "  未通过一份" + hetonghao + "\r\n" + gongfangmingcheng1 + "  的不合格评审流程" + "\r\n" +
              "请不合格评审员吴贞国评审！";
                    NetWork3J NetWork3J = new NetWork3J(yonghu, "http://" + MyGlobal.ip + ":81/");
                    NetWork3J.sendmessageById("吴贞国", sendmessage);
                }

                reload();
            }
            else
            {
                MessageBox.Show("取消！");
                return;
            }
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
            dt.Columns.Add("合格数量");
            dt.Columns.Add("不合格数量");
            dt.Columns.Add("不合格描述");
            dt.Columns.Add("提交人");
            dt.Columns.Add("提交时间");
            dt.Columns.Add("提交类型");
            dt.Columns.Add("供应商返工");
            dt.Columns.Add("让步接受数");
            dt.Columns.Add("报废");
            dt.Columns.Add("自家返工");
            dt.Columns.Add("人工数");
            dt.Columns.Add("检验时间数");
            dt.Columns.Add("特殊耗材");
            dt.Columns.Add("报价总额");
            dt.Columns.Add("物流部发票名称");
            dt.Columns.Add("物流部送货单名称");
            dt.Columns.Add("合格证名称");
            dt.Columns.Add("自检报告名称");
            dt.Columns.Add("验收图纸名称");
            dt.Columns.Add("检验员附件名称");
            dt.Columns.Add("质监员附件名称");
            dt.Columns.Add("不合格审批附件名称");
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
            dt1.Columns.Add("合格数量");
            dt1.Columns.Add("不合格数量");
            dt1.Columns.Add("不合格描述");
            dt1.Columns.Add("提交人");
            dt1.Columns.Add("提交时间");
            dt1.Columns.Add("提交类型");
            dt1.Columns.Add("供应商返工");
            dt1.Columns.Add("让步接受数");
            dt1.Columns.Add("报废");
            dt1.Columns.Add("自家返工");
            dt1.Columns.Add("人工数");
            dt1.Columns.Add("检验时间数");
            dt1.Columns.Add("特殊耗材");
            dt1.Columns.Add("报价总额");
            dt1.Columns.Add("物流部发票名称");
            dt1.Columns.Add("物流部送货单名称");
            dt1.Columns.Add("合格证名称");
            dt1.Columns.Add("自检报告名称");
            dt1.Columns.Add("验收图纸名称");
            dt1.Columns.Add("检验员附件名称");
            dt1.Columns.Add("质监员附件名称");
            dt1.Columns.Add("不合格审批附件名称");
            dt1.Columns.Add("查看该批次");

            string id = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id").ToString();
            string sql = "select id,工作令号,项目名称,设备名称,供方名称,型号,名称,单位,实际采购数量,到货数量,合格数量,不合格数量,不合格描述,提交人,提交时间,物流部发票名称,物流部送货单名称,合格证名称,自检报告名称,验收图纸名称,检验员附件名称,质监员附件名称,供应商返工,让步接受数,报废,自家返工,人工数,检验时间数,特殊耗材,报价总额,不合格审批附件名称,查看该批次,提交类型 from tb_daohuojilu where 定位 = '" + id + "'";
            dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            dt1.Merge(dt, true, MissingSchemaAction.Ignore);

            string sql1 = "select 查看该批次 from tb_daohuojilu where 定位 = '" + id + "'";
            string qingdan = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));

            Frjilu form = new Frjilu();
            form.dt = dt1;
            form.qingdan = qingdan;
            form.yonghu = yonghu;
            form.ShowDialog();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            
            string rengongshu = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "人工数"));
            string jianyanshijianshu = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "检验时间数"));
            string teshu = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "特殊耗材"));
            string baojia = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "报价总额"));

            float a, b, c;
            float.TryParse(rengongshu, out a);
            float.TryParse(jianyanshijianshu, out b);
            float.TryParse(teshu, out c);

            baojia = (a * 500 + b * 250 + c).ToString();

            if (e.Column.FieldName == "人工数" || e.Column.FieldName == "检验时间数" || e.Column.FieldName == "特殊耗材")
            {
                gridView1.SetRowCellValue(e.RowHandle, "报价总额", baojia);
            }
            else
            {
                return;
            }
            
        }

        private void gridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (gridView1.FocusedColumn.Name == "人工数" || gridView1.FocusedColumn.Name == "检验时间数"|| gridView1.FocusedColumn.Name == "特殊耗材")
            {
                float a = 0;
                float b = 0;
                float c = 0;
                string rengongshu = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "人工数"));
                string jianyanshijianshu = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "检验时间数"));
                string teshu = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "特殊耗材"));
                if (float.TryParse(rengongshu, out a) == false || float.TryParse(jianyanshijianshu, out b) == false || float.TryParse(teshu, out c) == false)
                {
                    MessageBox.Show("数量必须是数字！");
                    return;
                }
            }
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reload();
        }

        private void 修改价格ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            //DataTable dt2 = new DataTable();
            string id1 = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
            string sql3 = "select id,工作令号,项目名称,设备名称,合同号,供方名称,型号,名称,单位,本次到货验收数量,发起到货验收数量,不合格数量,不合格描述,人工数,检验时间数,特殊耗材,报价总额,查看该批次 from  tb_caigouliaodan  where id ='" + id1 + "'";
            dt1 = SQLhelp.GetDataTable(sql3, CommandType.Text);
            //dt2.Merge(dt1, true, MissingSchemaAction.Ignore);
            //dt2 = dt1.Clone();
            Frxiugaijiage form = new Frxiugaijiage();
            form.dt = dt1;            
            form.yonghu = yonghu;
            form.ShowDialog();
            reload();
        }

        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void 确认到货ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认完成吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                int[] c = gridView2.GetSelectedRows();
                string tijiaoshijian = DateTime.Now.ToString();
                foreach (int i in c)
                {
                    string id1 = Convert.ToString(this.gridView2.GetRowCellValue(i, "id"));

                    string sq2 = "update tb_caigouliaodan set 到货验收流程状态='2已收货',提交类型='收货人进行确认' where id ='" + id1 + "'";
                    SQLhelp.ExecuteScalar(sq2, CommandType.Text);

                    string sql4 = "update tb_caigouliaodan set 提交时间='" + tijiaoshijian + "',提交人='" + yonghu + "' where id ='" + id1 + "'";
                    SQLhelp.ExecuteScalar(sql4, CommandType.Text);

                    string sql3 = "insert into tb_daohuojilu  (工作令号,项目名称,设备名称,名称,供方名称,型号,单位,定位,到货数量,提交人,提交时间,提交类型,实际采购数量)select 工作令号,项目名称,设备名称,名称,供方名称,型号,单位,id,本次到货验收数量,提交人,提交时间,提交类型,实际采购数量  from tb_caigouliaodan where id ='" + id1 + "'";
                    SQLhelp.ExecuteScalar(sql3, CommandType.Text);
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

        private void 退回ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认提交吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                int[] c = gridView2.GetSelectedRows();
                string tijiaoshijian = DateTime.Now.ToString();
                foreach (int i in c)
                {
                    string id1 = Convert.ToString(this.gridView2.GetRowCellValue(i, "id"));
                    string tuihuiyuanyin = Convert.ToString(this.gridView2.GetRowCellValue(i, "退回原因"));
                    string sq2 = "update tb_caigouliaodan set 到货验收流程状态='3退回',提交类型='收货人进行退回',提交时间='" + tijiaoshijian + "',提交人='" + yonghu + "',退回原因='" + tuihuiyuanyin + "' where id ='" + id1 + "'";
                    SQLhelp.ExecuteScalar(sq2, CommandType.Text);

                    string sql3 = "insert into tb_daohuojilu  (工作令号,项目名称,设备名称,名称,供方名称,型号,单位,定位,到货数量,提交人,提交时间,提交类型,实际采购数量,退回原因)select 工作令号,项目名称,设备名称,名称,供方名称,型号,单位,id,本次到货验收数量,提交人,提交时间,提交类型,实际采购数量,退回原因  from tb_caigouliaodan where id ='" + id1 + "'";
                    SQLhelp.ExecuteScalar(sql3, CommandType.Text);
                }
                MessageBox.Show("提交成功！");
                string id = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id"));
                string hetonghao = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "合同号"));
                string gongfangmingcheng = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "供方名称"));

                string sql1 = "select 物流员 from tb_caigouliaodan where id='" + id + "'";
                string jianyanyuan = SQLhelp.ExecuteScalar(sql1, CommandType.Text).ToString();

                string sendmessage = yonghu + "  退回了一份" + hetonghao + "\r\n" + gongfangmingcheng + " 的到货验收流程" + "\r\n" +
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


            string id = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "id").ToString();

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

        private void 刷新ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reload1();
        }
    }
}
