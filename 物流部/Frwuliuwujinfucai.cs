using Aspose.Cells;
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
    public partial class Frwuliuwujinfucai : Form
    {
        public Frwuliuwujinfucai()
        {
            InitializeComponent();
        }
        public string yonghu;

        private void Frwuliuwujinfucai_Load(object sender, EventArgs e)
        {
            Reload();

        }
        public void Reload()
        {
            string sql = "select * from tb_operator where 用户名='" + yonghu + "'";
            DataTable dtt = sqlhelp111.GetDataTable(sql, CommandType.Text);
            string yuancailiao = Convert.ToString(dtt.Rows[0]["原材料采购"]);
            string wujinfucaicaigou = Convert.ToString(dtt.Rows[0]["五金辅材采购"]);
            if (yuancailiao == "1")
            {
                string sql1 = "select  id,工作令号,项目名称,设备名称,编码,型号,名称,实际采购数量,要求到货日期1,申购人,备注,当前状态,到货情况,采购类型,收到料单日期,合同号,供方名称,单位,采购单价,类型,采购员,采购料单备注  from  tb_caigouliaodan where  (采购类型='原材料' and 当前状态 !='9已到货'  and   当前状态 !='10已出库') or (采购类型='原材料' and   当前状态 is null)    ";
                DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                gridControl4.DataSource = dt;

                string sql11 = "select  id,工作令号,项目名称,设备名称,编码,型号,名称,实际采购数量,要求到货日期1,申购人,备注,当前状态,到货情况,采购类型,收到料单日期,合同号,供方名称,单位,采购单价,类型,采购员,采购料单备注 from  tb_caigouliaodan  where (采购类型='原材料' and 当前状态 ='9已到货' ) or ( 采购类型='原材料' and 当前状态 ='10已出库')";
                DataTable dt1 = SQLhelp.GetDataTable(sql11, CommandType.Text);
                gridControl1.DataSource = dt1;
            }
            if (yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "钱陆亦")
            {
                string sql1 = "select  id,工作令号,项目名称,设备名称,编码,型号,名称,实际采购数量,要求到货日期1,申购人,备注,当前状态,到货情况,采购类型,收到料单日期,合同号,供方名称,单位,采购单价,类型,采购员,采购料单备注   from  tb_caigouliaodan where  (采购类型 is not null and 当前状态 !='9已到货'  and   当前状态 !='10已出库') or (采购类型  is not null   and   当前状态  is null)   ";
                DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                gridControl4.DataSource = dt;
                string sql11 = "select  id,工作令号,项目名称,设备名称,编码,型号,名称,实际采购数量,要求到货日期1,申购人,备注,当前状态,到货情况,采购类型,收到料单日期,合同号,供方名称,单位,采购单价,类型,采购员,采购料单备注   from  tb_caigouliaodan where  (采购类型 is not null and 当前状态 ='9已到货' ) or (采购类型  is not null   and   当前状态 ='10已出库')   ";
                DataTable dt1 = SQLhelp.GetDataTable(sql11, CommandType.Text);
                gridControl1.DataSource = dt1;
            }
            if (wujinfucaicaigou == "1")
            {
                string sql1 = "select  id,工作令号,项目名称,设备名称,编码,型号,名称,实际采购数量,要求到货日期1,申购人,备注,当前状态,到货情况,采购类型,收到料单日期,合同号,供方名称,单位,采购单价,类型,采购员,采购料单备注   from  tb_caigouliaodan where  (采购类型='五金辅材' and 当前状态 !='9已到货' and   当前状态 !='10已出库' and 流程状态='同意') or (采购类型='五金辅材' and   当前状态  is null  and 流程状态='同意')   ";
                DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                gridControl4.DataSource = dt;
                string sql11 = "select  id,工作令号,项目名称,设备名称,编码,型号,名称,实际采购数量,要求到货日期1,申购人,备注,当前状态,到货情况,采购类型,收到料单日期,合同号,供方名称,单位,采购单价,类型,采购员,采购料单备注  from  tb_caigouliaodan where  (采购类型='五金辅材' and 当前状态 ='9已到货' ) or ( 采购类型='五金辅材' and 当前状态 ='10已出库')";
                DataTable dt1 = SQLhelp.GetDataTable(sql11, CommandType.Text);
                gridControl1.DataSource = dt1;
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] a = gridView4.GetSelectedRows();
            foreach (int i in a)
            {
                string id = Convert.ToString(gridView4.GetRowCellValue(i, "id"));
                string sql1 = "select 发票匹配,名称,实际到货数量 from tb_caigouliaodan where id='" + id + "'";
                DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                if (Convert.ToString(dt.Rows[0]["发票匹配"]) != "")
                {
                    string migncheng = dt.Rows[0]["名称"].ToString();
                    MessageBox.Show(migncheng + "已录入发票，无法再修改！");
                    return;
                }
                if (Convert.ToString(dt.Rows[0]["实际到货数量"]) != "")
                {
                    string migncheng = dt.Rows[0]["名称"].ToString();
                    MessageBox.Show(migncheng + "仓库已入库操作！无法修改");
                    return;
                }
            }


            foreach (int i in a)
            {
                string id = Convert.ToString(gridView4.GetRowCellValue(i, "id"));
                string zhuangtai = Convert.ToString(gridView4.GetRowCellValue(i, "当前状态"));
                string shuliang = Convert.ToString(gridView4.GetRowCellValue(i, "数量"));
                string hetonghao = Convert.ToString(gridView4.GetRowCellValue(i, "合同号"));
                string xinghao = Convert.ToString(gridView4.GetRowCellValue(i, "型号"));
                string danwei = Convert.ToString(gridView4.GetRowCellValue(i, "单位"));
                string beizhu = Convert.ToString(gridView4.GetRowCellValue(i, "备注"));
                string danjia = Convert.ToString(gridView4.GetRowCellValue(i, "采购单价"));
                string beizhu1 = Convert.ToString(gridView4.GetRowCellValue(i, "采购料单备注"));
                string sql12 = "select 发票匹配,名称 from tb_caigouliaodan where id='" + id + "'";
                DataTable dt = SQLhelp.GetDataTable(sql12, CommandType.Text);
                if (Convert.ToString(dt.Rows[0]["发票匹配"]) != "")
                {
                    string migncheng = dt.Rows[0]["名称"].ToString();
                    MessageBox.Show(migncheng + "已录入发票，无法再修改！");
                    return;
                }

                string sql2 = "update tb_caigouliaodan  set 采购料单备注='" + beizhu1 + "' where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql2, CommandType.Text);
            }
            MessageBox.Show("保存成功！");
            Reload();
        }

        private void 分解ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认分解吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string id = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id"));
                string sql = "insert into tb_caigouliaodan (设备名称,类型,项目工令号,要求到货日期,备注,时间,生产部确认,生产部确认时间,加工预计结束时间,仓库确认,仓库确认时间,申购人,收到料单日期,供方名称,合同号,报价,实际到货日期,检验,生产部检验,技术部检验,质检部检验,生成时间,附件,附件名称,附件类型,流程状态,到货验收流程按钮,到货验收流程标记,流程类型,采购料单备注,车,铣,钳,磨,镗,线切割,表面处理,热处理,采购类型,到货情况,要求到货日期1,采购负责人,工序外协,技术更改,工序要求,备料,工序外协状态,技术更改要求,机修件类型,客户名称,部门,工件名称,加工内容,计量单位,机修件数量,接单编号,预交时间,联系人,责任人,加工单位备注,接单日期,完成,合同预计时间,合同价,发票价,生成合同时间,收到发票日期,备料时间,发票日期,发票金额,发票号,生产负责人,生产负责人电话,工艺顺序1,工艺顺序2,工艺顺序3,备料人,工序外协时间,工序外协完成时间,询价时间,合同绩效点,询价标记,库位号,机修件ERP,技术更改入库时间,出库确认,出库时间,税额,税率,应开票数量,已开票数量,净额,含税额,净税额,净单价,个人部门,新编码,定位,合同名称,合同类型,模具部销售开票日期,模具部实际交货日期,模具部发货数量,合同,模具部成本单价,模具部成本总价,模具部销售开票金额,供应商开票日期,供应商开票金额,模具部发货确认,模具部发货时间,模具部成本是否工序,安全库存,领用登记数量,模具部自制外协修改,输入待领用数量,申请付款金额1,申请付款金额2,申请付款金额3,申请付款金额4,申请付款金额5,开户行以及账户,合同要求付款日期及方式,图纸上传次数,工作令号,模具部接单日期,当前状态,项目名称,单位,编码,型号,模具部生产车间,制造类型,模具部订单号申请号,模具部销售合同号,模具部交货日期,模具部申请人,模具部客户,模具部联系人,名称,模具部成本分摊,模具部销售单价,出库数量,库存数量,实际到货数量,料单类型,实际采购数量,模具部数量,数量,序号,模具部项目名称,申请付款日期1,申请付款日期2,申请付款日期3,申请付款日期4,申请付款日期5,模具部产品类型,模具部bom清单名称,模具部bom清单类型,bom清单,模具部驳回原因,物料理论到货时间,采购单价预留,采购单价,总价,总价预留,发票匹配,到货时间,驳回原因,确认到票,首次合格率,发起到货验收数量,物资分类,临时,机修与模具交货时间,理论净额,机修与模具完成,区分,采购员) select 设备名称,类型,项目工令号,要求到货日期,备注,时间,生产部确认,生产部确认时间,加工预计结束时间,仓库确认,仓库确认时间,申购人,收到料单日期,供方名称,合同号,报价,实际到货日期,检验,生产部检验,技术部检验,质检部检验,生成时间,附件,附件名称,附件类型,流程状态,到货验收流程按钮,到货验收流程标记,流程类型,采购料单备注,车,铣,钳,磨,镗,线切割,表面处理,热处理,采购类型,到货情况,要求到货日期1,采购负责人,工序外协,技术更改,工序要求,备料,工序外协状态,技术更改要求,机修件类型,客户名称,部门,工件名称,加工内容,计量单位,机修件数量,接单编号,预交时间,联系人,责任人,加工单位备注,接单日期,完成,合同预计时间,合同价,发票价,生成合同时间,收到发票日期,备料时间,发票日期,发票金额,发票号,生产负责人,生产负责人电话,工艺顺序1,工艺顺序2,工艺顺序3,备料人,工序外协时间,工序外协完成时间,询价时间,合同绩效点,询价标记,库位号,机修件ERP,技术更改入库时间,出库确认,出库时间,税额,税率,应开票数量,已开票数量,净额,含税额,净税额,净单价,个人部门,新编码,定位,合同名称,合同类型,模具部销售开票日期,模具部实际交货日期,模具部发货数量,合同,模具部成本单价,模具部成本总价,模具部销售开票金额,供应商开票日期,供应商开票金额,模具部发货确认,模具部发货时间,模具部成本是否工序,安全库存,领用登记数量,模具部自制外协修改,输入待领用数量,申请付款金额1,申请付款金额2,申请付款金额3,申请付款金额4,申请付款金额5,开户行以及账户,合同要求付款日期及方式,图纸上传次数,工作令号,模具部接单日期,当前状态,项目名称,单位,编码,型号,模具部生产车间,制造类型,模具部订单号申请号,模具部销售合同号,模具部交货日期,模具部申请人,模具部客户,模具部联系人,名称,模具部成本分摊,模具部销售单价,出库数量,库存数量,实际到货数量,料单类型,实际采购数量,模具部数量,数量,序号,模具部项目名称,申请付款日期1,申请付款日期2,申请付款日期3,申请付款日期4,申请付款日期5,模具部产品类型,模具部bom清单名称,模具部bom清单类型,bom清单,模具部驳回原因,物料理论到货时间,采购单价预留,采购单价,总价,总价预留,发票匹配,到货时间,驳回原因,确认到票,首次合格率,发起到货验收数量,物资分类,临时,机修与模具交货时间,理论净额,机修与模具完成,区分,采购员  from tb_caigouliaodan where id = '" + id + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);


                MessageBox.Show("分解成功！");
            }
            Reload();
        }

        #region 生成询价单
        private void buttonItem2_Click(object sender, EventArgs e)
        {
            int[] a = gridView4.GetSelectedRows();
            foreach (int i in a)
            {
                string id = Convert.ToString(gridView4.GetRowCellValue(i, "id"));
                string sql1 = "select 发票匹配,名称,实际到货数量 from tb_caigouliaodan where id='" + id + "'";
                DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                if (Convert.ToString(dt.Rows[0]["发票匹配"]) != "")
                {
                    string migncheng = dt.Rows[0]["名称"].ToString();
                    MessageBox.Show(migncheng + "已录入发票，无法再修改！");
                    return;
                }
                if (Convert.ToString(dt.Rows[0]["实际到货数量"]) != "")
                {
                    string migncheng = dt.Rows[0]["名称"].ToString();
                    MessageBox.Show(migncheng + "仓库已入库操作！无法修改");
                    return;
                }
            }
            DataTable dt1 = new DataTable();
            DataTable zongbiao1 = new DataTable();
            dt1.Columns.Add("id");
            dt1.Columns.Add("工作令号");
            dt1.Columns.Add("项目名称");
            dt1.Columns.Add("设备名称");
            dt1.Columns.Add("编码");
            dt1.Columns.Add("名称");
            dt1.Columns.Add("型号");
            dt1.Columns.Add("类型");
            dt1.Columns.Add("实际采购数量");
            dt1.Columns.Add("采购单价");
            dt1.Columns.Add("总价");
            dt1.Columns.Add("备注");
            dt1.Columns.Add("单位");
            zongbiao1.Columns.Add("id");
            zongbiao1.Columns.Add("工作令号");
            zongbiao1.Columns.Add("项目名称");
            zongbiao1.Columns.Add("设备名称");
            zongbiao1.Columns.Add("编码");
            zongbiao1.Columns.Add("名称");
            zongbiao1.Columns.Add("型号");
            zongbiao1.Columns.Add("类型");
            zongbiao1.Columns.Add("实际采购数量");
            zongbiao1.Columns.Add("采购单价");
            zongbiao1.Columns.Add("总价");
            zongbiao1.Columns.Add("备注");
            zongbiao1.Columns.Add("单位");
            int b = 0;        
            foreach (int i in a)
            {
                b += 1;
                if (b <= 200)
                {
                    string id = gridView4.GetRowCellValue(i, "id").ToString();

                    string sql1 = "select id,编码,名称,型号,实际采购数量,工作令号,备注,设备名称,项目名称,类型,单位,采购单价 from  tb_caigouliaodan  where id ='" + id + "' ";
                    dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);

                    zongbiao1.Merge(dt1, true, MissingSchemaAction.Ignore);
                }

            }

            Frxunjia form1 = new Frxunjia();
            form1.dt = zongbiao1;
            form1.yonghu = yonghu;
            form1.zhonglei = "设备";
            form1.ShowDialog();
            if (form1.DialogResult == DialogResult.OK)
            {
                Reload();

            }
        }
        #endregion

        #region 生成订货单
        private void buttonItem3_Click(object sender, EventArgs e)
        {
            int[] a = gridView4.GetSelectedRows();
            foreach (int i in a)
            {
                string id = Convert.ToString(gridView4.GetRowCellValue(i, "id"));
                string sql1 = "select 发票匹配,名称,实际到货数量 from tb_caigouliaodan where id='" + id + "'";
                DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                if (Convert.ToString(dt.Rows[0]["发票匹配"]) != "")
                {
                    string migncheng = dt.Rows[0]["名称"].ToString();
                    MessageBox.Show(migncheng + "已录入发票，无法再修改！");
                    return;
                }
                if (Convert.ToString(dt.Rows[0]["实际到货数量"]) != "")
                {
                    string migncheng = dt.Rows[0]["名称"].ToString();
                    MessageBox.Show(migncheng + "仓库已入库操作！无法修改");
                    return;
                }
            }


            DataTable dt1 = new DataTable();
            DataTable zongbiao1 = new DataTable();


            dt1.Columns.Add("id");
            dt1.Columns.Add("工作令号");
            dt1.Columns.Add("项目名称");
            dt1.Columns.Add("设备名称");
            dt1.Columns.Add("编码");
            dt1.Columns.Add("名称");
            dt1.Columns.Add("型号");
            dt1.Columns.Add("类型");
            dt1.Columns.Add("实际采购数量");
            dt1.Columns.Add("采购单价");
            dt1.Columns.Add("总价");
            dt1.Columns.Add("备注");
            dt1.Columns.Add("单位");
            zongbiao1.Columns.Add("id");
            zongbiao1.Columns.Add("工作令号");
            zongbiao1.Columns.Add("项目名称");
            zongbiao1.Columns.Add("设备名称");
            zongbiao1.Columns.Add("编码");
            zongbiao1.Columns.Add("名称");
            zongbiao1.Columns.Add("型号");
            zongbiao1.Columns.Add("类型");
            zongbiao1.Columns.Add("实际采购数量");
            zongbiao1.Columns.Add("采购单价");
            zongbiao1.Columns.Add("总价");
            zongbiao1.Columns.Add("备注");
            zongbiao1.Columns.Add("单位");


            int b = 0;
         

            foreach (int i in a)
            {
                b += 1;
                if (b <= 200)
                {
                    string id = gridView4.GetRowCellValue(i, "id").ToString();

                    string sql1 = "select id,编码,名称,型号,实际采购数量,工作令号,备注,设备名称,项目名称,类型,单位,采购单价 from  tb_caigouliaodan  where id ='" + id + "' ";
                    dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);

                    zongbiao1.Merge(dt1, true, MissingSchemaAction.Ignore);
                }

            }
            Frdingdan form1 = new Frdingdan();
            form1.dt = zongbiao1;
            form1.yonghu = yonghu;
            form1.zhonglei = "订单";
            form1.ShowDialog();
            if (form1.DialogResult == DialogResult.OK)
            {
                Reload();

            }
        }
        #endregion

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }

        #region 生成采购合同
        private void buttonItem1_Click(object sender, EventArgs e)
        {
            int[] a = gridView4.GetSelectedRows();
            foreach (int i in a)
            {
                string id = Convert.ToString(gridView4.GetRowCellValue(i, "id"));
                string sql1 = "select 发票匹配,名称,实际到货数量 from tb_caigouliaodan where id='" + id + "'";
                DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                if (Convert.ToString(dt.Rows[0]["发票匹配"]) != "")
                {
                    string migncheng = dt.Rows[0]["名称"].ToString();
                    MessageBox.Show(migncheng + "已录入发票，无法再修改！");
                    return;
                }
                if (Convert.ToString(dt.Rows[0]["实际到货数量"]) != "")
                {
                    string migncheng = dt.Rows[0]["名称"].ToString();
                    MessageBox.Show(migncheng + "仓库已入库操作！无法修改");
                    return;
                }
            }
            

            DataTable dt1 = new DataTable();
            DataTable zongbiao1 = new DataTable();

            dt1.Columns.Add("id");
            dt1.Columns.Add("工作令号");
            dt1.Columns.Add("项目名称");
            dt1.Columns.Add("设备名称");
            dt1.Columns.Add("编码");
            dt1.Columns.Add("名称");
            dt1.Columns.Add("型号");
            dt1.Columns.Add("类型");
            dt1.Columns.Add("实际采购数量");
            dt1.Columns.Add("采购单价");
            dt1.Columns.Add("总价");
            dt1.Columns.Add("备注");
            dt1.Columns.Add("单位");
            zongbiao1.Columns.Add("id");
            zongbiao1.Columns.Add("工作令号");
            zongbiao1.Columns.Add("项目名称");
            zongbiao1.Columns.Add("设备名称");
            zongbiao1.Columns.Add("编码");
            zongbiao1.Columns.Add("名称");
            zongbiao1.Columns.Add("型号");
            zongbiao1.Columns.Add("类型");
            zongbiao1.Columns.Add("实际采购数量");
            zongbiao1.Columns.Add("采购单价");
            zongbiao1.Columns.Add("总价");
            zongbiao1.Columns.Add("备注");
            zongbiao1.Columns.Add("单位");
            int b = 0;
          

            foreach (int i in a)
            {
                b += 1;
                if (b <= 200)
                {
                    string id = gridView4.GetRowCellValue(i, "id").ToString();

                    string sql1 = "select id,编码,名称,型号,实际采购数量,工作令号,备注,设备名称,项目名称,类型,单位,采购单价 from  tb_caigouliaodan  where id ='" + id + "' ";
                    dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);

                    zongbiao1.Merge(dt1, true, MissingSchemaAction.Ignore);
                }

            }

            Frhetongmoban form1 = new Frhetongmoban();
            form1.dt = zongbiao1;
            form1.yonghu = yonghu;
            form1.zhonglei = "采购";
            form1.ShowDialog();
            if (form1.DialogResult == DialogResult.OK)
            {
                Reload();

            }
        }
        #endregion


        private void 设置到未完成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认撤回吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));

                string sql11 = "update  tb_caigouliaodan set 到货情况=0   where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql11, CommandType.Text);
                MessageBox.Show("确认成功！");
                Reload();
            }
        }

        private void 查看附件ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string id = this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id").ToString();

            string sql = "select 附件名称 from tb_caigouliaodan where id='" + id + "'";
            string mingcheng = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (mingcheng == "")
            {
                MessageBox.Show("没有附件！");
                return;
            }

            string sql2 = "select 附件类型 from tb_caigouliaodan where id='" + id + "'";
            string leixing = SQLhelp.ExecuteScalar(sql2, CommandType.Text).ToString();

            byte[] mypdffile = null;

            string sql4 = "Select 附件 From tb_caigouliaodan Where id='" + id + "' ";

            mypdffile = SQLhelp.duqu(sql4, CommandType.Text);
            this.Cursor = Cursors.WaitCursor;

            string aaaa = System.Environment.CurrentDirectory;
            string bbbb = mingcheng.Replace("?", "1");
            string lujing = aaaa + "\\" + bbbb + "1" + "." + leixing;
            FileStream fs = new FileStream(lujing, FileMode.Create);
            fs.Write(mypdffile, 0, mypdffile.Length);
            fs.Flush();
            fs.Close();
            this.Cursor = Cursors.Default;
            System.Diagnostics.Process.Start(lujing);
        }
        #region 加入购物车（已完成）
        private void buttonItem5_Click(object sender, EventArgs e)
        {
            int[] a = gridView1.GetSelectedRows();
            foreach (int i in a)
            {
                string id = gridView1.GetRowCellValue(i, "id").ToString();
                qingdan += id + "|";
            }
            MessageBox.Show("已加入购物车！");
        }
        #endregion
        public string qingdan;
        #region 加入购物车（未完成）
        private void buttonItem4_Click(object sender, EventArgs e)
        {
            int[] a = gridView4.GetSelectedRows();
            foreach (int i in a)
            {
                string id = gridView4.GetRowCellValue(i, "id").ToString();
                qingdan += id + "|";
            }
            MessageBox.Show("已加入购物车！");
        }
        #endregion

        private void buttonItem6_Click(object sender, EventArgs e)
        {

            if (qingdan == "")
            {
                MessageBox.Show("购物车没有东西,请添加！");
                return;
            }
            DataTable dt1 = new DataTable();
            DataTable zongbiao1 = new DataTable();

            dt1.Columns.Add("id");
            dt1.Columns.Add("工作令号");
            dt1.Columns.Add("项目名称");
            dt1.Columns.Add("设备名称");
            dt1.Columns.Add("编码");
            dt1.Columns.Add("名称");
            dt1.Columns.Add("型号");
            dt1.Columns.Add("类型");
            dt1.Columns.Add("实际采购数量");
            dt1.Columns.Add("采购单价");
            dt1.Columns.Add("总价");
            dt1.Columns.Add("备注");
            dt1.Columns.Add("单位");
            zongbiao1.Columns.Add("id");
            zongbiao1.Columns.Add("工作令号");
            zongbiao1.Columns.Add("项目名称");
            zongbiao1.Columns.Add("设备名称");
            zongbiao1.Columns.Add("编码");
            zongbiao1.Columns.Add("名称");
            zongbiao1.Columns.Add("型号");
            zongbiao1.Columns.Add("类型");
            zongbiao1.Columns.Add("实际采购数量");
            zongbiao1.Columns.Add("采购单价");
            zongbiao1.Columns.Add("总价");
            zongbiao1.Columns.Add("备注");
            zongbiao1.Columns.Add("单位");

            string[] strArray = qingdan.Split('|'); //字符串转数组
            List<string> list = new List<string>();
            for (int i = 0; i < strArray.Length; i++)//遍历数组成员
            {
                if (list.IndexOf(strArray[i].ToLower()) == -1)//对每个成员做一次新数组查询如果没有相等的则加到新数组
                    list.Add(strArray[i]);
            }
            for (int i = 0; i < list.Count; i++)
            {
                string dingwei = list[i];


                string sql1 = "select id,编码,名称,型号,实际采购数量,工作令号,备注,设备名称,项目名称,类型,单位,采购单价 from  tb_caigouliaodan  where id ='" + dingwei + "' ";
                dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);

                zongbiao1.Merge(dt1, true, MissingSchemaAction.Ignore);
            }
            Frhetongmoban form1 = new Frhetongmoban();
            form1.dt = zongbiao1;
            form1.yonghu = yonghu;
            form1.zhonglei = "采购";
            form1.ShowDialog();
            if (form1.DialogResult == DialogResult.OK)
            {
                Reload();
            }

        }

        private void buttonItem9_Click(object sender, EventArgs e)
        {
            if (qingdan == "")
            {
                MessageBox.Show("购物车没有东西,请添加！");
                return;
            }
            DataTable dt1 = new DataTable();
            DataTable zongbiao1 = new DataTable();

            dt1.Columns.Add("id");
            dt1.Columns.Add("工作令号");
            dt1.Columns.Add("项目名称");
            dt1.Columns.Add("设备名称");
            dt1.Columns.Add("编码");
            dt1.Columns.Add("名称");
            dt1.Columns.Add("型号");
            dt1.Columns.Add("类型");
            dt1.Columns.Add("实际采购数量");
            dt1.Columns.Add("采购单价");
            dt1.Columns.Add("总价");
            dt1.Columns.Add("备注");
            dt1.Columns.Add("单位");
            zongbiao1.Columns.Add("id");
            zongbiao1.Columns.Add("工作令号");
            zongbiao1.Columns.Add("项目名称");
            zongbiao1.Columns.Add("设备名称");
            zongbiao1.Columns.Add("编码");
            zongbiao1.Columns.Add("名称");
            zongbiao1.Columns.Add("型号");
            zongbiao1.Columns.Add("类型");
            zongbiao1.Columns.Add("实际采购数量");
            zongbiao1.Columns.Add("采购单价");
            zongbiao1.Columns.Add("总价");
            zongbiao1.Columns.Add("备注");
            zongbiao1.Columns.Add("单位");

            string[] strArray = qingdan.Split('|'); //字符串转数组
            List<string> list = new List<string>();
            for (int i = 0; i < strArray.Length; i++)//遍历数组成员
            {
                if (list.IndexOf(strArray[i].ToLower()) == -1)//对每个成员做一次新数组查询如果没有相等的则加到新数组
                    list.Add(strArray[i]);
            }
            for (int i = 0; i < list.Count; i++)
            {
                string dingwei = list[i];


                string sql1 = "select id,编码,名称,型号,实际采购数量,工作令号,备注,设备名称,项目名称,类型,单位,采购单价 from  tb_caigouliaodan  where id ='" + dingwei + "' ";
                dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);

                zongbiao1.Merge(dt1, true, MissingSchemaAction.Ignore);
            }

            Frdingdan form1 = new Frdingdan();
            form1.dt = zongbiao1;
            form1.yonghu = yonghu;
            form1.zhonglei = "订单";
            form1.ShowDialog();
            if (form1.DialogResult == DialogResult.OK)
            {
                Reload();
            }

        }

        private void buttonItem8_Click(object sender, EventArgs e)
        {
            qingdan = "";
            MessageBox.Show("已清空！");
        }

        private void buttonItem7_Click(object sender, EventArgs e)
        {
            int[] a = gridView4.GetSelectedRows();
            foreach (int i in a)
            {
                string id = Convert.ToString(gridView4.GetRowCellValue(i, "id"));
                string sql1 = "select 发票匹配,名称,实际到货数量 from tb_caigouliaodan where id='" + id + "'";
                DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                if (Convert.ToString(dt.Rows[0]["发票匹配"]) != "")
                {
                    string migncheng = dt.Rows[0]["名称"].ToString();
                    MessageBox.Show(migncheng + "已录入发票，无法再修改！");
                    return;
                }
                if (Convert.ToString(dt.Rows[0]["实际到货数量"]) != "")
                {
                    string migncheng = dt.Rows[0]["名称"].ToString();
                    MessageBox.Show(migncheng + "仓库已入库操作！无法修改");
                    return;
                }
            }


            DataTable dt1 = new DataTable();
            DataTable zongbiao1 = new DataTable();

            dt1.Columns.Add("id");
            dt1.Columns.Add("工作令号");
            dt1.Columns.Add("项目名称");
            dt1.Columns.Add("设备名称");
            dt1.Columns.Add("编码");
            dt1.Columns.Add("名称");
            dt1.Columns.Add("型号");
            dt1.Columns.Add("类型");
            dt1.Columns.Add("实际采购数量");
            dt1.Columns.Add("采购单价");
            dt1.Columns.Add("总价");
            dt1.Columns.Add("备注");
            dt1.Columns.Add("单位");
            zongbiao1.Columns.Add("id");
            zongbiao1.Columns.Add("工作令号");
            zongbiao1.Columns.Add("项目名称");
            zongbiao1.Columns.Add("设备名称");
            zongbiao1.Columns.Add("编码");
            zongbiao1.Columns.Add("名称");
            zongbiao1.Columns.Add("型号");
            zongbiao1.Columns.Add("类型");
            zongbiao1.Columns.Add("实际采购数量");
            zongbiao1.Columns.Add("采购单价");
            zongbiao1.Columns.Add("总价");
            zongbiao1.Columns.Add("备注");
            zongbiao1.Columns.Add("单位");

            int b = 0;
      
            foreach (int i in a)
            {
                b += 1;
                if (b <= 200)
                {
                    string id = gridView4.GetRowCellValue(i, "id").ToString();

                    string sql1 = "select id,编码,名称,型号,实际采购数量,工作令号,备注,设备名称,项目名称,类型,单位,采购单价 from  tb_caigouliaodan  where id ='" + id + "' ";
                    dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);

                    zongbiao1.Merge(dt1, true, MissingSchemaAction.Ignore);
                }

            }
            Frhetongmoban form1 = new Frhetongmoban();
            form1.dt = zongbiao1;
            form1.yonghu = yonghu;
            form1.zhonglei = "普通";
            form1.ShowDialog();
            if (form1.DialogResult == DialogResult.OK)
            {
                Reload();
            }

        }

        private void 取消ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] a = gridView4.GetSelectedRows();
            foreach (int i in a)
            {

                string id = Convert.ToString(gridView4.GetRowCellValue(i, "id"));
                string sql1 = "select 发票匹配,名称,实际到货数量 from tb_caigouliaodan where id='" + id + "'";
                DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
                if (Convert.ToString(dt.Rows[0]["发票匹配"]) != "")
                {
                    string migncheng = dt.Rows[0]["名称"].ToString();
                    MessageBox.Show(migncheng + "已录入发票，无法再修改！");
                    return;
                }
                if (Convert.ToString(dt.Rows[0]["实际到货数量"]) != "")
                {
                    string migncheng = dt.Rows[0]["名称"].ToString();
                    MessageBox.Show(migncheng + "仓库已入库操作！无法修改");
                    return;
                }

            }
            foreach (int i in a)
            {
                string id = this.gridView4.GetRowCellValue(i, "id").ToString();
                string sql = "update tb_caigouliaodan set 合同号='取消' ,当前状态='取消' where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);

            }
            MessageBox.Show("取消成功！");
            Reload();

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}

       
    
