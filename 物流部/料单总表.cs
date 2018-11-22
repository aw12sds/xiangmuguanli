using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace 项目管理系统.物流部
{
    public partial class 料单总表 : DevExpress.XtraEditors.XtraForm
    {
        public 料单总表()
        {
            InitializeComponent();
        }
        public string yonghu;
        private void 料单总表_Load(object sender, EventArgs e)
        {
            reload();
            reload1();
            this.gridView1.IndicatorWidth = 60;
            this.gridView2.IndicatorWidth = 60;
        }
        public void reload()
        {
            string sql = "select 工作令号,项目名称,设备名称,id,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,申购人,收到料单日期,供方名称,合同号,实际采购数量,采购单价,当前状态,采购料单备注,附件名称,附件类型,料单类型,发起到货验收数量,首次合格率 " +
"from tb_caigouliaodan  where 料单类型 not in ('模具部原材料','模具部') and 当前状态!='9已到货'";

            DataTable jieguo = SQLhelp.GetDataTable(sql, CommandType.Text);
            for(int i=0;i< jieguo.Rows.Count; i++)
            {
                jieguo.Rows[i]["发起到货验收数量"] = jieguo.Rows[i]["实际采购数量"];
            }
            gridControl1.DataSource = jieguo;
        }
        public void reload1()
        {
            string sql = "select 工作令号,项目名称,设备名称,id,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,申购人,收到料单日期,供方名称,合同号,实际采购数量,采购单价,当前状态,采购料单备注,附件名称,附件类型,料单类型,发起到货验收数量,首次合格率 " +
"from tb_caigouliaodan  where 料单类型 not in ('模具部原材料','模具部') and 当前状态='9已到货'";
            DataTable jieguo = SQLhelp.GetDataTable(sql, CommandType.Text);
            for (int i = 0; i < jieguo.Rows.Count; i++)
            {
                jieguo.Rows[i]["发起到货验收数量"] = jieguo.Rows[i]["实际采购数量"];
            }
            gridControl2.DataSource = jieguo;
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
                }
                else if (e.RowHandle < 0 && e.RowHandle > -1000)
                {
                    e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
                    e.Info.DisplayText = "G" + e.RowHandle.ToString();
                }
            }
        }

        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
                }
                else if (e.RowHandle < 0 && e.RowHandle > -1000)
                {
                    e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
                    e.Info.DisplayText = "G" + e.RowHandle.ToString();
                }
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int[] rownumber = this.gridView1.GetSelectedRows();
            DialogResult result = MessageBox.Show("默认发起到货验收数量等于实际采购数量,如果不对,请在到货验收一列中填入实际数量", "是否要发起此到货验收", MessageBoxButtons.YesNo) ;
            if(result== DialogResult.Yes)
            {
                for (int i = 0; i < rownumber.Length; i++)
                {
                    string 发起到货验收数量 = gridView1.GetRowCellDisplayText(rownumber[i], "发起到货验收数量");
                    string id= gridView1.GetRowCellDisplayText(rownumber[i], "id");
                    string sql = "insert into tb_daohuoyanshou(定位,发起人,发起时间,总数量,状态) values('" + id + "','" + yonghu + "','" + DateTime.Now + "'," + 发起到货验收数量 + ",'"+"待检验')";

                    SQLhelp.ExecuteScalar(sql, CommandType.Text);
                    MessageBox.Show(gridView1.GetRowCellDisplayText(rownumber[i], "发起到货验收数量") + "");
                }
            }
            else
            {

            }
            
        }
    }
}