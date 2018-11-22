using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.财务部
{
    public partial class Frxiangmuruku : Form
    {
        public Frxiangmuruku()
        {
            InitializeComponent();
        }

        //private void buttonItem1_Click(object sender, EventArgs e)
        //{
        //    string sql1 = "select 工作令号,项目名称,设备名称,名称,实际采购数量,净单价 from tb_caigouliaodan where 工作令号 like'%" + txtgonglinghao.Text.Trim() + "%' ";
        //   gridControl1.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
         
            
        //}

        //private void buttonItem2_Click(object sender, EventArgs e)
        //{
        //    string sql1 = "select 工作令号,项目名称,设备名称,名称,实际采购数量,净单价 from tb_caigouliaodan where 项目名称 like'%" + txtxiangmumingcheng.Text.Trim() + "%' ";
        //    gridControl1.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
       
        //}

        //private void buttonItem3_Click(object sender, EventArgs e)
        //{
        //    string sql1 = "select 工作令号,项目名称,设备名称,名称,实际采购数量,净单价 from tb_caigouliaodan where 设备名称 like'%" + txtshebeimingcheng.Text.Trim() + "%' ";       
        //    gridControl1.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
         
        //}
        //#region 搜索物料名称
        //private void buttonItem4_Click(object sender, EventArgs e)
        //{
        //    string sql1 = "select 工作令号,项目名称,设备名称,名称,实际采购数量,净单价 from tb_caigouliaodan where 名称 like'%" + txtwuliao.Text.Trim() + "%' ";
        //    gridControl1.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
        //}
        //#endregion

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }




        #region 搜索工令号
        private void btnSearchGonglinhao_Click(object sender, EventArgs e)
        {
            string sql1 = "select 工作令号,项目名称,设备名称,名称,实际采购数量,净单价 from tb_caigouliaodan where 工作令号 like'%" 
                + textSearchGonlinhao.Text.Trim() + "%' ";
            gridControl1.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
        }
        #endregion

        #region 搜索项目名称
        private void btnSearchXiangmuName_Click(object sender, EventArgs e)
        {
            string sql1 = "select 工作令号,项目名称,设备名称,名称,实际采购数量,净单价 from tb_caigouliaodan where 项目名称 like'%"
                + textSearchXiangmuName.Text.Trim() + "%' ";
            gridControl1.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
        }
        #endregion

        #region 搜索设备名称
        private void btnSearchShebeiName_Click(object sender, EventArgs e)
        {
            string sql1 = "select 工作令号,项目名称,设备名称,名称,实际采购数量,净单价 from tb_caigouliaodan where 设备名称 like'%" 
                + textSearchShebeiName.Text.Trim() + "%' ";
            gridControl1.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
        }
        #endregion

        #region 搜索物料
        private void btnSearchWuliao_Click(object sender, EventArgs e)
        {
            string sql1 = "select 工作令号,项目名称,设备名称,名称,实际采购数量,净单价 from tb_caigouliaodan where 名称 like'%" + textSearchWuliao.Text.Trim() + "%' ";
            gridControl1.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
        }
        #endregion

    }
}
