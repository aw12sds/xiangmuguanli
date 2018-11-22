using DevComponents.DotNetBar;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
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
    public partial class FrWuliurenwu : Office2007Form
    {
        public FrWuliurenwu()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        DataTable dt;
        DataTable dt1;
        public string yonghu;
        public string gouwuche="";      
        private void FrWuliurenwu_Load(object sender, EventArgs e)
        {
            
        }      
        public void Reload()
        {
            
            dt = null;
            dt1 = null;

            if (yonghu == "尤奇" || yonghu == "庄卫星" || yonghu == "聂燕"|| yonghu == "田星星" || yonghu == "郭玉玺" || yonghu == "于嘉嘉" || yonghu == "张敏明" || yonghu == "唐亚男" || yonghu == "朱天伟" || yonghu == "何然" || yonghu == "王军花" || yonghu == "钱飞"|| yonghu == "丁雪松" || yonghu == "钱陆亦")
            {
                string sql = "select id,工作令号,项目名称,设备名称,数量,采购项目负责人,时间,物流部完成时间,预计采购结束时间,采购项目完成进展 from tb_jishubumen where (制造类型='外购' and 是否提交=1 and 技术部通过=1 and 物流部确认=1 and 图纸下达=1 and 物流部最终确认=0) or (制造类型='自制' and 是否提交=1 and 技术部通过=1  and 生产部确认=1 and 物流部确认=1 and 图纸下达=1 and 物流部最终确认=0) ";
                 dt = SQLhelp.GetDataTable(sql, CommandType.Text);
                string sql1 = "select id,工作令号,项目名称,设备名称,数量,采购项目负责人,时间,物流部最终确认时间,采购项目完成进展 from tb_jishubumen where (制造类型='外购' and 是否提交=1 and 技术部通过=1 and 物流部确认=1 and 图纸下达=1 and 物流部最终确认 =1) or (制造类型='自制' and 是否提交=1 and 技术部通过=1  and 生产部确认=1 and 物流部确认=1 and 图纸下达=1 and 物流部最终确认 =1) ";
                dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);
            }
            else
            {
                string sql = "select id,工作令号,项目名称,设备名称,数量,采购项目负责人,时间,物流部完成时间,预计采购结束时间,采购项目完成进展 from tb_jishubumen  where (制造类型='外购' and 是否提交=1 and 技术部通过=1 and 物流部确认=1 and 图纸下达=1 and 采购项目负责人='" + yonghu + "' and 物流部最终确认=0) or (制造类型='自制' and 是否提交=1 and 技术部通过=1  and 生产部确认=1 and 物流部确认=1 and 图纸下达=1 and 采购项目负责人='" + yonghu + "' and 物流部最终确认=0) ";
                 dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                string sql1 = "select id,工作令号,项目名称,设备名称,数量,采购项目负责人,时间,物流部最终确认时间,采购项目完成进展 from tb_jishubumen where (制造类型='外购' and 是否提交=1 and 技术部通过=1 and 物流部确认=1 and 图纸下达=1 and 采购项目负责人='" + yonghu + "' and 物流部最终确认 =1) or (制造类型='自制' and 是否提交=1 and 技术部通过=1  and 生产部确认=1 and 物流部确认=1 and 图纸下达=1 and 采购项目负责人='" + yonghu + "' and 物流部最终确认 =1) ";
                dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);
            }

           gridControl4.DataSource = dt;
           gridControl1.DataSource = dt1;
        }             
        private void 确认完成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认完成吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                if (yonghu == Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "采购项目负责人")))
                {
                    string id = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "id"));
                    string xiangmumingcheng = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "项目名称"));
                    string shebeimingcheng = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "设备名称"));
                    string caigoufuzeren = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "采购项目负责人"));
                    string gongzuolinghao = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "工作令号"));
                    string shijian = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "时间"));
                    string sql12345 = "update tb_jishubumen  set 物流部最终确认=1 ,物流部最终确认时间='" + DateTime.Now + "'   where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql12345, CommandType.Text);

                    string caigoushijian = DateTime.Now.ToString();
                    string sql123456 = "update  tb_xiangmu  set 实际采购结束时间='" + caigoushijian + "' where 工作令号= '" + gongzuolinghao + "' and 项目名称= '" + xiangmumingcheng + "' ";
                    SQLhelp.ExecuteScalar(sql123456, CommandType.Text);

                    MessageBox.Show("确认成功！");
                    dt = null;
                    dt1 = null;
                    
                    string sql = "select id,工作令号,项目名称,设备名称,数量,采购项目负责人,时间,物流部完成时间,预计采购结束时间,采购项目完成进展 from tb_jishubumen where (制造类型='外购' and 是否提交=1 and 技术部通过=1 and 物流部确认=1 and 图纸下达=1 and 物流部最终确认=0 and 工作令号 like'%" + txtgonglinghao.Text.Trim() + "%') or (制造类型='自制' and 是否提交=1 and 技术部通过=1  and 生产部确认=1 and 物流部确认=1 and 图纸下达=1 and 物流部最终确认=0 and 工作令号 like'%" + txtgonglinghao.Text.Trim() + "%') ";
                    dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                    string sql1 = "select id,工作令号,项目名称,设备名称,数量,采购项目负责人,时间,物流部最终确认时间,采购项目完成进展 from tb_jishubumen where (制造类型='外购' and 是否提交=1 and 技术部通过=1 and 物流部确认=1 and 图纸下达=1 and 物流部最终确认 =1 and 工作令号 like'%" + txtgonglinghao.Text.Trim() + "%') or (制造类型='自制' and 是否提交=1 and 技术部通过=1  and 生产部确认=1 and 物流部确认=1 and 图纸下达=1 and 物流部最终确认 =1 and 工作令号 like'%" + txtgonglinghao.Text.Trim() + "%') ";
                    dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);
                    
                    gridControl4.DataSource = dt;
                    gridControl1.DataSource = dt1;

                }

                else
                {
                    MessageBox.Show("非该项目采购负责人无权限确认完成！");
                    return;
                }
            }

        }    
        private void buttonItem1_Click(object sender, EventArgs e)
        {
            dt = null;
            dt1 = null;


            if (yonghu == "尤奇" || yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "田星星" || yonghu == "郭玉玺" || yonghu == "于嘉嘉" || yonghu == "张敏明" || yonghu == "唐亚男" || yonghu == "朱天伟" || yonghu == "何然" || yonghu == "王军花" || yonghu == "钱飞" || yonghu == "丁雪松" || yonghu == "钱陆亦")
            {

                string sql = "select id,工作令号,项目名称,设备名称,数量,采购项目负责人,时间,物流部完成时间,预计采购结束时间,采购项目完成进展  from tb_jishubumen where (制造类型='外购' and 是否提交=1 and 技术部通过=1 and 物流部确认=1 and 图纸下达=1 and 物流部最终确认=0 and 工作令号 like'%" + txtgonglinghao.Text.Trim() + "%') or (制造类型='自制' and 是否提交=1 and 技术部通过=1  and 生产部确认=1 and 物流部确认=1 and 图纸下达=1 and 物流部最终确认=0 and 工作令号 like'%" + txtgonglinghao.Text.Trim() + "%') ";
                dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                string sql1 = "select id,工作令号,项目名称,设备名称,数量,采购项目负责人,时间,物流部最终确认时间,采购项目完成进展 from tb_jishubumen where (制造类型='外购' and 是否提交=1 and 技术部通过=1 and 物流部确认=1 and 图纸下达=1 and 物流部最终确认 =1 and 工作令号 like'%" + txtgonglinghao.Text.Trim() + "%') or (制造类型='自制' and 是否提交=1 and 技术部通过=1  and 生产部确认=1 and 物流部确认=1 and 图纸下达=1 and 物流部最终确认 =1 and 工作令号 like'%" + txtgonglinghao.Text.Trim() + "%') ";
                dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);

            }
            else
            {
                string sql = "select id,工作令号,项目名称,设备名称,数量,采购项目负责人,时间,物流部完成时间,预计采购结束时间,采购项目完成进展 from tb_jishubumen where (制造类型='外购' and 是否提交=1 and 技术部通过=1 and 物流部确认=1 and 图纸下达=1 and 采购项目负责人='" + yonghu + "' and 物流部最终确认=0 and 工作令号 like'%" + txtgonglinghao.Text.Trim() + "%') or (制造类型='自制' and 是否提交=1 and 技术部通过=1  and 生产部确认=1 and 物流部确认=1 and 图纸下达=1 and 采购项目负责人='" + yonghu + "' and 物流部最终确认=0 and 工作令号 like'%" + txtgonglinghao.Text.Trim() + "%') ";
                dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                string sql1 = "select id,工作令号,项目名称,设备名称,数量,采购项目负责人,时间,物流部最终确认时间,采购项目完成进展 from tb_jishubumen where (制造类型='外购' and 是否提交=1 and 技术部通过=1 and 物流部确认=1 and 图纸下达=1 and 采购项目负责人='" + yonghu + "' and 物流部最终确认 =1 and 工作令号 like'%" + txtgonglinghao.Text.Trim() + "%') or (制造类型='自制' and 是否提交=1 and 技术部通过=1  and 生产部确认=1 and 物流部确认=1 and 图纸下达=1 and 采购项目负责人='" + yonghu + "' and 物流部最终确认 =1 and 工作令号 like'%" + txtgonglinghao.Text.Trim() + "%') ";
                dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);



            }

          gridControl4.DataSource = dt;
            gridControl1.DataSource = dt1;
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            Reload();
        }
      
        
        
        private void buttonItem3_Click(object sender, EventArgs e)
        {
            
            DataTable dt = new DataTable();
            DataTable zongbiao = new DataTable();
            dt.Columns.Add("工作令号");
            dt.Columns.Add("项目名称");
            dt.Columns.Add("设备名称");
            dt.Columns.Add("id");
            dt.Columns.Add("编码");
            dt.Columns.Add("型号");
            dt.Columns.Add("名称");
            dt.Columns.Add("单位");
            dt.Columns.Add("数量");
            dt.Columns.Add("类型");          
            dt.Columns.Add("要求到货日期");
            dt.Columns.Add("备注");
            dt.Columns.Add("制造类型");
            dt.Columns.Add("申购人");
            dt.Columns.Add("收到料单日期");
            dt.Columns.Add("供方名称");
            dt.Columns.Add("合同号");
            dt.Columns.Add("实际采购数量");         
            dt.Columns.Add("当前状态");
            dt.Columns.Add("采购料单备注");           
            dt.Columns.Add("附件名称");
           


            zongbiao.Columns.Add("工作令号");
            zongbiao.Columns.Add("项目名称");
            zongbiao.Columns.Add("设备名称");
            zongbiao.Columns.Add("id");
            zongbiao.Columns.Add("编码");
            zongbiao.Columns.Add("型号");
            zongbiao.Columns.Add("名称");
            zongbiao.Columns.Add("单位");
            zongbiao.Columns.Add("数量");
            zongbiao.Columns.Add("类型");      
            zongbiao.Columns.Add("要求到货日期");
            zongbiao.Columns.Add("备注");
            zongbiao.Columns.Add("制造类型");
            zongbiao.Columns.Add("申购人");
            zongbiao.Columns.Add("收到料单日期");
            zongbiao.Columns.Add("供方名称");
            zongbiao.Columns.Add("合同号");
            zongbiao.Columns.Add("实际采购数量");        
            zongbiao.Columns.Add("当前状态");
            zongbiao.Columns.Add("采购料单备注");      
            zongbiao.Columns.Add("附件名称");
            

            int[] a = gridView4.GetSelectedRows();

            foreach (int i in a)
            {
             
                string gonglinghao = Convert.ToString(gridView4.GetRowCellValue(i, "工作令号"));
                string xiangmumingcheng = Convert.ToString(gridView4.GetRowCellValue(i, "项目名称")) ;
                string shebeimingcheng = Convert.ToString(gridView4.GetRowCellValue(i, "设备名称")); ;
                string shijian = Convert.ToString(gridView4.GetRowCellValue(i, "时间"));

                string sql1 = "select id,工作令号,项目名称,设备名称,编码,型号,名称,单位,数量,类型,要求到货日期,备注,制造类型,申购人,收到料单日期,供方名称,合同号,实际采购数量,采购单价,采购料单备注,附件名称,当前状态 from  tb_caigouliaodan  where 工作令号='" + gonglinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" +shebeimingcheng+ "'  and 时间='" + shijian + "' and   制造类型='外协零部件' and (合同号='' or 合同号 is  null) ";
                dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                zongbiao.Merge(dt, true, MissingSchemaAction.Ignore);
            }
            
            Frshaixuanliaodan form1 = new Frshaixuanliaodan();
            form1.dt = zongbiao;
            form1.yonghu = yonghu;
            form1.zhonglei = "合同";
            form1.ShowDialog();
            if(form1.DialogResult==DialogResult.OK)
            {
                gouwuche += form1.qingdan;
                
            }



        }
        
        private void 查看料单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string gonglinghao = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "工作令号"));
            string xiangmumingcheng = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "项目名称"));
            string shebeimingcheng = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "设备名称"));
            string shijian = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "时间"));

            FrWuliubuliaodan form = new FrWuliubuliaodan();
            form.gongzuolinghao = gonglinghao;
            form.xiangmumingcheng = xiangmumingcheng;
            form.yonghu = yonghu;
            form.shijian = shijian;
            form.shebei = shebeimingcheng;
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {


            }
        }
        
        private void buttonItem7_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            DataTable zongbiao = new DataTable();
        
            dt.Columns.Add("工作令号");
            dt.Columns.Add("项目名称");
            dt.Columns.Add("设备名称");
            dt.Columns.Add("id");
            dt.Columns.Add("编码");
            dt.Columns.Add("型号");
            dt.Columns.Add("名称");
            dt.Columns.Add("单位");
            dt.Columns.Add("数量");
            dt.Columns.Add("类型");

            dt.Columns.Add("要求到货日期");
            dt.Columns.Add("备注");
            dt.Columns.Add("制造类型");
            dt.Columns.Add("申购人");
            dt.Columns.Add("收到料单日期");
            dt.Columns.Add("供方名称");
            dt.Columns.Add("合同号");
            dt.Columns.Add("实际采购数量");

            dt.Columns.Add("当前状态");
            dt.Columns.Add("采购料单备注");

            dt.Columns.Add("附件名称");



            zongbiao.Columns.Add("工作令号");
            zongbiao.Columns.Add("项目名称");
            zongbiao.Columns.Add("设备名称");
            zongbiao.Columns.Add("id");
            zongbiao.Columns.Add("编码");
            zongbiao.Columns.Add("型号");
            zongbiao.Columns.Add("名称");
            zongbiao.Columns.Add("单位");
            zongbiao.Columns.Add("数量");
            zongbiao.Columns.Add("类型");

            zongbiao.Columns.Add("要求到货日期");
            zongbiao.Columns.Add("备注");
            zongbiao.Columns.Add("制造类型");
            zongbiao.Columns.Add("申购人");
            zongbiao.Columns.Add("收到料单日期");
            zongbiao.Columns.Add("供方名称");
            zongbiao.Columns.Add("合同号");
            zongbiao.Columns.Add("实际采购数量");

            zongbiao.Columns.Add("当前状态");
            zongbiao.Columns.Add("采购料单备注");

            zongbiao.Columns.Add("附件名称");

            int[] a = gridView4.GetSelectedRows();

            foreach (int i in a)
            {

                string gonglinghao = Convert.ToString(gridView4.GetRowCellValue(i, "工作令号"));
                string xiangmumingcheng = Convert.ToString(gridView4.GetRowCellValue(i, "项目名称"));
                string shebeimingcheng = Convert.ToString(gridView4.GetRowCellValue(i, "设备名称")); ;
                string shijian = Convert.ToString(gridView4.GetRowCellValue(i, "时间"));

                string sql1 = "select id,工作令号,项目名称,设备名称,编码,型号,名称,单位,数量,类型,要求到货日期,备注,制造类型,申购人,收到料单日期,供方名称,合同号,实际采购数量,采购单价,采购料单备注,附件名称,当前状态 from  tb_caigouliaodan  where 工作令号='" + gonglinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "' and 时间='" + shijian + "' and   制造类型='机械标准件' and (合同号='' or 合同号 is  null) ";
                dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                zongbiao.Merge(dt, true, MissingSchemaAction.Ignore);
            }
            
            Frshaixuanliaodan form1 = new Frshaixuanliaodan();
            form1.dt = zongbiao;
            form1.yonghu = yonghu;
            form1.zhonglei = "合同";
            form1.ShowDialog();
            if (form1.DialogResult == DialogResult.OK)
            {
                gouwuche += form1.qingdan;

            }
        }

        private void buttonItem8_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable zongbiao = new DataTable();
            dt.Columns.Add("工作令号");
            dt.Columns.Add("项目名称");
            dt.Columns.Add("设备名称");
            dt.Columns.Add("id");
            dt.Columns.Add("编码");
            dt.Columns.Add("型号");
            dt.Columns.Add("名称");
            dt.Columns.Add("单位");
            dt.Columns.Add("数量");
            dt.Columns.Add("类型");

            dt.Columns.Add("要求到货日期");
            dt.Columns.Add("备注");
            dt.Columns.Add("制造类型");
            dt.Columns.Add("申购人");
            dt.Columns.Add("收到料单日期");
            dt.Columns.Add("供方名称");
            dt.Columns.Add("合同号");
            dt.Columns.Add("实际采购数量");

            dt.Columns.Add("当前状态");
            dt.Columns.Add("采购料单备注");

            dt.Columns.Add("附件名称");



            zongbiao.Columns.Add("工作令号");
            zongbiao.Columns.Add("项目名称");
            zongbiao.Columns.Add("设备名称");
            zongbiao.Columns.Add("id");
            zongbiao.Columns.Add("编码");
            zongbiao.Columns.Add("型号");
            zongbiao.Columns.Add("名称");
            zongbiao.Columns.Add("单位");
            zongbiao.Columns.Add("数量");
            zongbiao.Columns.Add("类型");

            zongbiao.Columns.Add("要求到货日期");
            zongbiao.Columns.Add("备注");
            zongbiao.Columns.Add("制造类型");
            zongbiao.Columns.Add("申购人");
            zongbiao.Columns.Add("收到料单日期");
            zongbiao.Columns.Add("供方名称");
            zongbiao.Columns.Add("合同号");
            zongbiao.Columns.Add("实际采购数量");

            zongbiao.Columns.Add("当前状态");
            zongbiao.Columns.Add("采购料单备注");

            zongbiao.Columns.Add("附件名称");

            int[] a = gridView4.GetSelectedRows();

            foreach (int i in a)
            {

                string gonglinghao = Convert.ToString(gridView4.GetRowCellValue(i, "工作令号"));
                string xiangmumingcheng = Convert.ToString(gridView4.GetRowCellValue(i, "项目名称"));
                string shebeimingcheng = Convert.ToString(gridView4.GetRowCellValue(i, "设备名称")); ;
                string shijian = Convert.ToString(gridView4.GetRowCellValue(i, "时间"));

                string sql1 = "select id,工作令号,项目名称,设备名称,编码,型号,名称,单位,数量,类型,要求到货日期,备注,制造类型,申购人,收到料单日期,供方名称,合同号,实际采购数量,采购单价,采购料单备注,附件名称,当前状态 from  tb_caigouliaodan  where 工作令号='" + gonglinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "' and 时间='" + shijian + "' and   制造类型='电气标准件' and (合同号='' or 合同号 is  null) ";
                dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                zongbiao.Merge(dt, true, MissingSchemaAction.Ignore);
            }
            
            Frshaixuanliaodan form1 = new Frshaixuanliaodan();
            form1.dt = zongbiao;
            form1.yonghu = yonghu;
            form1.zhonglei = "合同";
            form1.ShowDialog();
            if (form1.DialogResult == DialogResult.OK)
            {
                gouwuche += form1.qingdan;

            }
        }

        private void buttonItem9_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            DataTable zongbiao = new DataTable();
            dt.Columns.Add("工作令号");
            dt.Columns.Add("项目名称");
            dt.Columns.Add("设备名称");
            dt.Columns.Add("id");
            dt.Columns.Add("编码");
            dt.Columns.Add("型号");
            dt.Columns.Add("名称");
            dt.Columns.Add("单位");
            dt.Columns.Add("数量");
            dt.Columns.Add("类型");
            dt.Columns.Add("要求到货日期");
            dt.Columns.Add("备注");
            dt.Columns.Add("制造类型");
            dt.Columns.Add("申购人");
            dt.Columns.Add("收到料单日期");
            dt.Columns.Add("供方名称");
            dt.Columns.Add("合同号");
            dt.Columns.Add("实际采购数量");
            dt.Columns.Add("当前状态");
            dt.Columns.Add("采购料单备注");
            dt.Columns.Add("附件名称");



            zongbiao.Columns.Add("工作令号");
            zongbiao.Columns.Add("项目名称");
            zongbiao.Columns.Add("设备名称");
            zongbiao.Columns.Add("id");
            zongbiao.Columns.Add("编码");
            zongbiao.Columns.Add("型号");
            zongbiao.Columns.Add("名称");
            zongbiao.Columns.Add("单位");
            zongbiao.Columns.Add("数量");
            zongbiao.Columns.Add("类型");

            zongbiao.Columns.Add("要求到货日期");
            zongbiao.Columns.Add("备注");
            zongbiao.Columns.Add("制造类型");
            zongbiao.Columns.Add("申购人");
            zongbiao.Columns.Add("收到料单日期");
            zongbiao.Columns.Add("供方名称");
            zongbiao.Columns.Add("合同号");
            zongbiao.Columns.Add("实际采购数量");

            zongbiao.Columns.Add("当前状态");
            zongbiao.Columns.Add("采购料单备注");

            zongbiao.Columns.Add("附件名称");
            int[] a = gridView4.GetSelectedRows();

            foreach (int i in a)
            {

                string gonglinghao = Convert.ToString(gridView4.GetRowCellValue(i, "工作令号"));
                string xiangmumingcheng = Convert.ToString(gridView4.GetRowCellValue(i, "项目名称"));
                string shebeimingcheng = Convert.ToString(gridView4.GetRowCellValue(i, "设备名称")); ;
                string shijian = Convert.ToString(gridView4.GetRowCellValue(i, "时间"));

                string sql1 = "select id,工作令号,项目名称,设备名称,编码,型号,名称,单位,数量,类型,要求到货日期,备注,制造类型,申购人,收到料单日期,供方名称,合同号,实际采购数量,采购单价,采购料单备注,附件名称,当前状态 from  tb_caigouliaodan  where 工作令号='" + gonglinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "' and 时间='" + shijian + "' and   制造类型='外购' and (合同号='' or 合同号 is  null) ";
                dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                zongbiao.Merge(dt, true, MissingSchemaAction.Ignore);
            }
            
            Frshaixuanliaodan form1 = new Frshaixuanliaodan();
            form1.dt = zongbiao;
            form1.yonghu = yonghu;
            form1.zhonglei = "合同";
            form1.ShowDialog();
            if (form1.DialogResult == DialogResult.OK)
            {
                gouwuche += form1.qingdan;

            }
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable zongbiao = new DataTable();
            dt.Columns.Add("工作令号");
            dt.Columns.Add("项目名称");
            dt.Columns.Add("设备名称");
            dt.Columns.Add("id");
            dt.Columns.Add("编码");
            dt.Columns.Add("型号");
            dt.Columns.Add("名称");
            dt.Columns.Add("单位");
            dt.Columns.Add("数量");
            dt.Columns.Add("类型");
            dt.Columns.Add("项目工令号");
            dt.Columns.Add("要求到货日期");
            dt.Columns.Add("备注");
            dt.Columns.Add("制造类型");
            dt.Columns.Add("申购人");
            dt.Columns.Add("收到料单日期");
            dt.Columns.Add("供方名称");
            dt.Columns.Add("合同号");
            dt.Columns.Add("实际采购数量");
            dt.Columns.Add("实际到货日期");
            dt.Columns.Add("当前状态");
            dt.Columns.Add("采购料单备注");
            dt.Columns.Add("附件类型");
            dt.Columns.Add("附件名称");
            dt.Columns.Add("合同预计时间");


            zongbiao.Columns.Add("工作令号");
            zongbiao.Columns.Add("项目名称");
            zongbiao.Columns.Add("设备名称");
            zongbiao.Columns.Add("id");
            zongbiao.Columns.Add("编码");
            zongbiao.Columns.Add("型号");
            zongbiao.Columns.Add("名称");
            zongbiao.Columns.Add("单位");
            zongbiao.Columns.Add("数量");
            zongbiao.Columns.Add("类型");
            zongbiao.Columns.Add("项目工令号");
            zongbiao.Columns.Add("要求到货日期");
            zongbiao.Columns.Add("备注");
            zongbiao.Columns.Add("制造类型");
            zongbiao.Columns.Add("申购人");
            zongbiao.Columns.Add("收到料单日期");
            zongbiao.Columns.Add("供方名称");
            zongbiao.Columns.Add("合同号");
            zongbiao.Columns.Add("实际采购数量");
            zongbiao.Columns.Add("实际到货日期");
            zongbiao.Columns.Add("当前状态");
            zongbiao.Columns.Add("采购料单备注");
            zongbiao.Columns.Add("附件类型");
            zongbiao.Columns.Add("附件名称");
            zongbiao.Columns.Add("合同预计时间");

            int[] a = gridView4.GetSelectedRows();

            foreach (int i in a)
            {

                string gonglinghao = Convert.ToString(gridView4.GetRowCellValue(i, "工作令号"));
                string xiangmumingcheng = Convert.ToString(gridView4.GetRowCellValue(i, "项目名称"));
                string shebeimingcheng = Convert.ToString(gridView4.GetRowCellValue(i, "设备名称")); ;
                string shijian = Convert.ToString(gridView4.GetRowCellValue(i, "时间"));

                string sql1 = "select id,工作令号,项目名称,设备名称,id,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,申购人,收到料单日期,供方名称,合同号,实际采购数量,报价, 采购单价,实际到货日期,当前状态,采购料单备注,附件名称,附件类型,合同预计时间 from  tb_caigouliaodan  where 工作令号='" + gonglinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "' and 设备名称='" + shebeimingcheng + "'  and   制造类型='外协零部件' and (合同号='' or 合同号 is  null) ";
                dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                zongbiao.Merge(dt, true, MissingSchemaAction.Ignore);
            }
            
            Frshaixuanliaodan form1 = new Frshaixuanliaodan();
            form1.dt = zongbiao;
            form1.yonghu = yonghu;
            form1.zhonglei = "付款";
            form1.ShowDialog();
        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable zongbiao = new DataTable();
            dt.Columns.Add("工作令号");
            dt.Columns.Add("项目名称");
            dt.Columns.Add("设备名称");
            dt.Columns.Add("id");
            dt.Columns.Add("编码");
            dt.Columns.Add("型号");
            dt.Columns.Add("名称");
            dt.Columns.Add("单位");
            dt.Columns.Add("数量");
            dt.Columns.Add("类型");
            dt.Columns.Add("项目工令号");
            dt.Columns.Add("要求到货日期");
            dt.Columns.Add("备注");
            dt.Columns.Add("制造类型");
            dt.Columns.Add("申购人");
            dt.Columns.Add("收到料单日期");
            dt.Columns.Add("供方名称");
            dt.Columns.Add("合同号");
            dt.Columns.Add("实际采购数量");
            dt.Columns.Add("实际到货日期");
            dt.Columns.Add("当前状态");
            dt.Columns.Add("采购料单备注");
            dt.Columns.Add("附件类型");
            dt.Columns.Add("附件名称");
            dt.Columns.Add("合同预计时间");


            zongbiao.Columns.Add("工作令号");
            zongbiao.Columns.Add("项目名称");
            zongbiao.Columns.Add("设备名称");
            zongbiao.Columns.Add("id");
            zongbiao.Columns.Add("编码");
            zongbiao.Columns.Add("型号");
            zongbiao.Columns.Add("名称");
            zongbiao.Columns.Add("单位");
            zongbiao.Columns.Add("数量");
            zongbiao.Columns.Add("类型");
            zongbiao.Columns.Add("项目工令号");
            zongbiao.Columns.Add("要求到货日期");
            zongbiao.Columns.Add("备注");
            zongbiao.Columns.Add("制造类型");
            zongbiao.Columns.Add("申购人");
            zongbiao.Columns.Add("收到料单日期");
            zongbiao.Columns.Add("供方名称");
            zongbiao.Columns.Add("合同号");
            zongbiao.Columns.Add("实际采购数量");
            zongbiao.Columns.Add("实际到货日期");
            zongbiao.Columns.Add("当前状态");
            zongbiao.Columns.Add("采购料单备注");
            zongbiao.Columns.Add("附件类型");
            zongbiao.Columns.Add("附件名称");
            zongbiao.Columns.Add("合同预计时间");

            int[] a = gridView4.GetSelectedRows();

            foreach (int i in a)
            {

                string gonglinghao = Convert.ToString(gridView4.GetRowCellValue(i, "工作令号"));
                string xiangmumingcheng = Convert.ToString(gridView4.GetRowCellValue(i, "项目名称"));
                string shebeimingcheng = Convert.ToString(gridView4.GetRowCellValue(i, "设备名称")); ;
                string shijian = Convert.ToString(gridView4.GetRowCellValue(i, "时间"));

                string sql1 = "select id,工作令号,项目名称,设备名称,id,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,申购人,收到料单日期,供方名称,合同号,实际采购数量,报价, 采购单价,实际到货日期,当前状态,采购料单备注,附件名称,附件类型,合同预计时间 from  tb_caigouliaodan  where 工作令号='" + gonglinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "' and 设备名称='" + shebeimingcheng + "'  and   制造类型='机械标准件' and (合同号='' or 合同号 is  null) ";
                dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                zongbiao.Merge(dt, true, MissingSchemaAction.Ignore);
            }



            Frshaixuanliaodan form1 = new Frshaixuanliaodan();
            form1.dt = zongbiao;
            form1.yonghu = yonghu;
            form1.zhonglei = "付款";
            form1.ShowDialog();
        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable zongbiao = new DataTable();
            dt.Columns.Add("工作令号");
            dt.Columns.Add("项目名称");
            dt.Columns.Add("设备名称");
            dt.Columns.Add("id");
            dt.Columns.Add("编码");
            dt.Columns.Add("型号");
            dt.Columns.Add("名称");
            dt.Columns.Add("单位");
            dt.Columns.Add("数量");
            dt.Columns.Add("类型");
            dt.Columns.Add("项目工令号");
            dt.Columns.Add("要求到货日期");
            dt.Columns.Add("备注");
            dt.Columns.Add("制造类型");
            dt.Columns.Add("申购人");
            dt.Columns.Add("收到料单日期");
            dt.Columns.Add("供方名称");
            dt.Columns.Add("合同号");
            dt.Columns.Add("实际采购数量");
            dt.Columns.Add("实际到货日期");
            dt.Columns.Add("当前状态");
            dt.Columns.Add("采购料单备注");
            dt.Columns.Add("附件类型");
            dt.Columns.Add("附件名称");
            dt.Columns.Add("合同预计时间");


            zongbiao.Columns.Add("工作令号");
            zongbiao.Columns.Add("项目名称");
            zongbiao.Columns.Add("设备名称");
            zongbiao.Columns.Add("id");
            zongbiao.Columns.Add("编码");
            zongbiao.Columns.Add("型号");
            zongbiao.Columns.Add("名称");
            zongbiao.Columns.Add("单位");
            zongbiao.Columns.Add("数量");
            zongbiao.Columns.Add("类型");
            zongbiao.Columns.Add("项目工令号");
            zongbiao.Columns.Add("要求到货日期");
            zongbiao.Columns.Add("备注");
            zongbiao.Columns.Add("制造类型");
            zongbiao.Columns.Add("申购人");
            zongbiao.Columns.Add("收到料单日期");
            zongbiao.Columns.Add("供方名称");
            zongbiao.Columns.Add("合同号");
            zongbiao.Columns.Add("实际采购数量");
            zongbiao.Columns.Add("实际到货日期");
            zongbiao.Columns.Add("当前状态");
            zongbiao.Columns.Add("采购料单备注");
            zongbiao.Columns.Add("附件类型");
            zongbiao.Columns.Add("附件名称");
            zongbiao.Columns.Add("合同预计时间");
            int[] a = gridView4.GetSelectedRows();

            foreach (int i in a)
            {

                string gonglinghao = Convert.ToString(gridView4.GetRowCellValue(i, "工作令号"));
                string xiangmumingcheng = Convert.ToString(gridView4.GetRowCellValue(i, "项目名称"));
                string shebeimingcheng = Convert.ToString(gridView4.GetRowCellValue(i, "设备名称")); ;
                string shijian = Convert.ToString(gridView4.GetRowCellValue(i, "时间"));

                string sql1 = "select id,工作令号,项目名称,设备名称,id,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,申购人,收到料单日期,供方名称,合同号,实际采购数量,报价, 采购单价,实际到货日期,当前状态,采购料单备注,附件名称,附件类型,合同预计时间 from  tb_caigouliaodan  where 工作令号='" + gonglinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "' and 设备名称='" + shebeimingcheng + "'   and   制造类型='电气标准件' and (合同号='' or 合同号 is  null) ";
                dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                zongbiao.Merge(dt, true, MissingSchemaAction.Ignore);
            }




            Frshaixuanliaodan form1 = new Frshaixuanliaodan();
            form1.dt = zongbiao;
            form1.yonghu = yonghu;
            form1.zhonglei = "付款";
            form1.ShowDialog();
        }

        private void buttonItem10_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable zongbiao = new DataTable();
            dt.Columns.Add("工作令号");
            dt.Columns.Add("项目名称");
            dt.Columns.Add("设备名称");
            dt.Columns.Add("id");
            dt.Columns.Add("编码");
            dt.Columns.Add("型号");
            dt.Columns.Add("名称");
            dt.Columns.Add("单位");
            dt.Columns.Add("数量");
            dt.Columns.Add("类型");
            dt.Columns.Add("项目工令号");
            dt.Columns.Add("要求到货日期");
            dt.Columns.Add("备注");
            dt.Columns.Add("制造类型");
            dt.Columns.Add("申购人");
            dt.Columns.Add("收到料单日期");
            dt.Columns.Add("供方名称");
            dt.Columns.Add("合同号");
            dt.Columns.Add("实际采购数量");
            dt.Columns.Add("实际到货日期");
            dt.Columns.Add("当前状态");
            dt.Columns.Add("采购料单备注");
            dt.Columns.Add("附件类型");
            dt.Columns.Add("附件名称");
            dt.Columns.Add("合同预计时间");


            zongbiao.Columns.Add("工作令号");
            zongbiao.Columns.Add("项目名称");
            zongbiao.Columns.Add("设备名称");
            zongbiao.Columns.Add("id");
            zongbiao.Columns.Add("编码");
            zongbiao.Columns.Add("型号");
            zongbiao.Columns.Add("名称");
            zongbiao.Columns.Add("单位");
            zongbiao.Columns.Add("数量");
            zongbiao.Columns.Add("类型");
            zongbiao.Columns.Add("项目工令号");
            zongbiao.Columns.Add("要求到货日期");
            zongbiao.Columns.Add("备注");
            zongbiao.Columns.Add("制造类型");
            zongbiao.Columns.Add("申购人");
            zongbiao.Columns.Add("收到料单日期");
            zongbiao.Columns.Add("供方名称");
            zongbiao.Columns.Add("合同号");
            zongbiao.Columns.Add("实际采购数量");
            zongbiao.Columns.Add("实际到货日期");
            zongbiao.Columns.Add("当前状态");
            zongbiao.Columns.Add("采购料单备注");
            zongbiao.Columns.Add("附件类型");
            zongbiao.Columns.Add("附件名称");
            zongbiao.Columns.Add("合同预计时间");

            int[] a = gridView4.GetSelectedRows();

            foreach (int i in a)
            {

                string gonglinghao = Convert.ToString(gridView4.GetRowCellValue(i, "工作令号"));
                string xiangmumingcheng = Convert.ToString(gridView4.GetRowCellValue(i, "项目名称"));
                string shebeimingcheng = Convert.ToString(gridView4.GetRowCellValue(i, "设备名称")); ;
                string shijian = Convert.ToString(gridView4.GetRowCellValue(i, "时间"));

                string sql1 = "select id,工作令号,项目名称,设备名称,id,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,申购人,收到料单日期,供方名称,合同号,实际采购数量,报价, 采购单价,实际到货日期,当前状态,采购料单备注,附件名称,附件类型,合同预计时间 from  tb_caigouliaodan  where 工作令号='" + gonglinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "'  and 设备名称='" + shebeimingcheng + "' and   制造类型='外购' and (合同号='' or 合同号 is  null) ";
                dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                zongbiao.Merge(dt, true, MissingSchemaAction.Ignore);
            }


            
            Frshaixuanliaodan form1 = new Frshaixuanliaodan();
            form1.dt = zongbiao;
            form1.yonghu = yonghu;
            form1.zhonglei = "付款";
            form1.ShowDialog();
        }

        private void buttonItem11_Click(object sender, EventArgs e)
        {
            dt = null;
            dt1 = null;

            if (yonghu == "尤奇" || yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "田星星" || yonghu == "郭玉玺" || yonghu == "于嘉嘉" || yonghu == "张敏明" || yonghu == "唐亚男" || yonghu == "朱天伟" || yonghu == "何然" || yonghu == "王军花" || yonghu == "钱飞")
            {

                string sql = "select id,工作令号,项目名称,设备名称,数量,采购项目负责人,时间,物流部完成时间,预计采购结束时间,采购项目完成进展 from tb_jishubumen where (制造类型='外购' and 是否提交=1 and 技术部通过=1 and 物流部确认=1 and 图纸下达=1 and 物流部最终确认=0 and 设备名称 like'%" + txtshebeimingcheng.Text.Trim() + "%') or (制造类型='自制' and 是否提交=1 and 技术部通过=1  and 生产部确认=1 and 物流部确认=1 and 图纸下达=1 and 物流部最终确认=0 and 设备名称 like'%" + txtshebeimingcheng.Text.Trim() + "%') ";
                dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                string sql1 = "select id,工作令号,项目名称,设备名称,数量,采购项目负责人,时间,物流部最终确认时间,采购项目完成进展 from tb_jishubumen where (制造类型='外购' and 是否提交=1 and 技术部通过=1 and 物流部确认=1 and 图纸下达=1 and 物流部最终确认 =1 and 设备名称 like'%" + txtshebeimingcheng.Text.Trim() + "%') or (制造类型='自制' and 是否提交=1 and 技术部通过=1  and 生产部确认=1 and 物流部确认=1 and 图纸下达=1 and 物流部最终确认=1 and 设备名称 like'%" + txtshebeimingcheng.Text.Trim() + "%') ";
                dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);

            }
            else
            {
                string sql = "select id,工作令号,项目名称,设备名称,数量,采购项目负责人,时间,物流部完成时间,预计采购结束时间,采购项目完成进展 from tb_jishubumen where (制造类型='外购' and 是否提交=1 and 技术部通过=1 and 物流部确认=1 and 图纸下达=1 and 采购项目负责人='" + yonghu + "' and 物流部最终确认=0 and 设备名称 like'%" + txtshebeimingcheng.Text.Trim() + "%') or (制造类型='自制' and 是否提交=1 and 技术部通过=1  and 生产部确认=1 and 物流部确认=1 and 图纸下达=1 and 采购项目负责人='" + yonghu + "' and 物流部最终确认=0 and 设备名称 like'%" + txtshebeimingcheng.Text.Trim() + "%') ";
                dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                string sql1 = "select id,工作令号,项目名称,设备名称,数量,采购项目负责人,时间,物流部最终确认时间,采购项目完成进展  from tb_jishubumen where (制造类型='外购' and 是否提交=1 and 技术部通过=1 and 物流部确认=1 and 图纸下达=1 and 采购项目负责人='" + yonghu + "' and 物流部最终确认 =1 and 设备名称 like'%" + txtshebeimingcheng.Text.Trim() + "%') or (制造类型='自制' and 是否提交=1 and 技术部通过=1  and 生产部确认=1 and 物流部确认=1 and 图纸下达=1 and 采购项目负责人='" + yonghu + "' and 物流部最终确认 =1 and 设备名称 like'%" + txtshebeimingcheng.Text.Trim() + "%') ";
                dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);
                
            }
           gridControl4.DataSource = dt;
            gridControl1.DataSource = dt1;
        }

      
        private void buttonItem14_Click(object sender, EventArgs e)
        {
            gouwuche = "";
            MessageBox.Show("已清空！");
        }

        private void buttonItem13_Click(object sender, EventArgs e)
        {
            if(gouwuche=="")
            {
                MessageBox.Show("购物车没有东西,请添加！");
                return;              
            }
            DataTable dt = new DataTable();
            DataTable zongbiao = new DataTable();
            dt.Columns.Add("工作令号");
            dt.Columns.Add("项目名称");
            dt.Columns.Add("设备名称");
            dt.Columns.Add("id");
            dt.Columns.Add("编码");
            dt.Columns.Add("型号");
            dt.Columns.Add("名称");
            dt.Columns.Add("单位");
            dt.Columns.Add("数量");
            dt.Columns.Add("类型");
            dt.Columns.Add("项目工令号");
            dt.Columns.Add("要求到货日期");
            dt.Columns.Add("备注");
            dt.Columns.Add("制造类型");
            dt.Columns.Add("申购人");
            dt.Columns.Add("收到料单日期");
            dt.Columns.Add("供方名称");
            dt.Columns.Add("合同号");
            dt.Columns.Add("实际采购数量");
            dt.Columns.Add("实际到货日期");
            dt.Columns.Add("当前状态");
            dt.Columns.Add("采购料单备注");
            dt.Columns.Add("附件类型");
            dt.Columns.Add("附件名称");
            dt.Columns.Add("合同预计时间");


            zongbiao.Columns.Add("工作令号");
            zongbiao.Columns.Add("项目名称");
            zongbiao.Columns.Add("设备名称");
            zongbiao.Columns.Add("id");
            zongbiao.Columns.Add("编码");
            zongbiao.Columns.Add("型号");
            zongbiao.Columns.Add("名称");
            zongbiao.Columns.Add("单位");
            zongbiao.Columns.Add("数量");
            zongbiao.Columns.Add("类型");
            zongbiao.Columns.Add("项目工令号");
            zongbiao.Columns.Add("要求到货日期");
            zongbiao.Columns.Add("备注");
            zongbiao.Columns.Add("制造类型");
            zongbiao.Columns.Add("申购人");
            zongbiao.Columns.Add("收到料单日期");
            zongbiao.Columns.Add("供方名称");
            zongbiao.Columns.Add("合同号");
            zongbiao.Columns.Add("实际采购数量");
            zongbiao.Columns.Add("实际到货日期");
            zongbiao.Columns.Add("当前状态");
            zongbiao.Columns.Add("采购料单备注");
            zongbiao.Columns.Add("附件类型");
            zongbiao.Columns.Add("附件名称");
            zongbiao.Columns.Add("合同预计时间");

            string[] strArray = gouwuche.Split('|'); //字符串转数组
            List<string> list = new List<string>();
            for (int i = 0; i < strArray.Length; i++)//遍历数组成员
            {
                if (list.IndexOf(strArray[i].ToLower()) == -1)//对每个成员做一次新数组查询如果没有相等的则加到新数组
                    list.Add(strArray[i]);
            }




            for (int i = 0; i < list.Count; i++)
            {
                string dingwei = list[i];
                
                string sql1 = "select id,工作令号,项目名称,设备名称,编码,型号,名称,单位,数量,类型,要求到货日期,备注,制造类型,申购人,收到料单日期,供方名称,合同号,实际采购数量,采购单价,当前状态,采购料单备注,附件名称,附件类型 from  tb_caigouliaodan  where id ='" + dingwei + "' ";
                dt = SQLhelp.GetDataTable(sql1, CommandType.Text);

                zongbiao.Merge(dt, true, MissingSchemaAction.Ignore);

            }
            Frshaixuanliaodan form1 = new Frshaixuanliaodan();
            form1.dt = zongbiao;
            form1.yonghu = yonghu;          
            form1.ShowDialog();
          
        }
        
        private void buttonItem15_Click_1(object sender, EventArgs e)
        {
            Frhetongliaodan form1 = new Frhetongliaodan();
            form1.hetonghao = txthetonghao.Text.Trim();
            form1.yonghu = yonghu;
            form1.ShowDialog();
        }
        
        private void buttonItem16_Click_1(object sender, EventArgs e)
        {
            Frxunjialiaodan form1 = new Frxunjialiaodan();
            form1.xunjiabiaoji =txtxunjia.Text.Trim();
            form1.yonghu = yonghu;
            form1.ShowDialog();
        }
        
        private void gridView4_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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
                

                string gonglinghao = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号"));

                string xiangmumingcheng =
              Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "项目名称"));
                string shebeimingcheng = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "设备名称"));
                string shijian = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "时间"));

                FrWuliubuliaodan form = new FrWuliubuliaodan();
                form.gongzuolinghao = gonglinghao;
                form.xiangmumingcheng = xiangmumingcheng;

                form.shijian = shijian;
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {


                }
                
            }
        }

        private void 查看料单ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string gonglinghao = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号"));
            string xiangmumingcheng = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "项目名称"));
            string shebeimingcheng = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "设备名称"));
            string shijian = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "时间"));

            FrWuliubuliaodan form = new FrWuliubuliaodan();
            form.gongzuolinghao = gonglinghao;
            form.xiangmumingcheng = xiangmumingcheng;
            form.yonghu = yonghu;
            form.shijian = shijian;
            form.shebei = shebeimingcheng;
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {


            }
        }

        private void toolTipController1_GetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            GridHitInfo hitInfo = gridView4.CalcHitInfo(e.ControlMousePosition);

            if (hitInfo.RowHandle < 0 || hitInfo.Column == null )
            {
                toolTipController1.HideHint();
                return;
            }
           string gonglinghao = gridView4.GetRowCellValue(hitInfo.RowHandle, "工作令号").ToString();
            string sql = "select * from tb_fukuanfangshi where 工作令号 like '%" + gonglinghao.Trim() + "%'";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            if (dt.Rows.Count > 0)
            {
                DataRow row = gridView4.GetDataRow(hitInfo.RowHandle);
               
                   
                    e.Info = new ToolTipControlInfo("", dt.Rows[0]["付款方式"].ToString());
                
            }
        }

        private void 撤回到待处理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认撤回吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                if (yonghu == Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "采购项目负责人")))
                {
                    string id = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "id"));
                    string xiangmumingcheng = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "项目名称"));
                    string shebeimingcheng = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "设备名称"));
                    string caigoufuzeren = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "采购项目负责人"));
                    string shijian = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "时间"));
                    string sql12345 = "update tb_jishubumen  set 物流部最终确认=0    where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql12345, CommandType.Text);
                    MessageBox.Show("确认成功！");
                    dt = null;
                    dt1 = null;

                    string sql = "select id,工作令号,项目名称,设备名称,数量,采购项目负责人,时间,物流部完成时间,预计采购结束时间,采购项目完成进展 from tb_jishubumen where (制造类型='外购' and 是否提交=1 and 技术部通过=1 and 物流部确认=1 and 图纸下达=1 and 物流部最终确认=0 and 工作令号 like'%" + txtgonglinghao.Text.Trim() + "%') or (制造类型='自制' and 是否提交=1 and 技术部通过=1  and 生产部确认=1 and 物流部确认=1 and 图纸下达=1 and 物流部最终确认=0 and 工作令号 like'%" + txtgonglinghao.Text.Trim() + "%') ";
                    dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                    string sql1 = "select id,工作令号,项目名称,设备名称,数量,采购项目负责人,时间,物流部最终确认时间,采购项目完成进展 from tb_jishubumen where (制造类型='外购' and 是否提交=1 and 技术部通过=1 and 物流部确认=1 and 图纸下达=1 and 物流部最终确认 =1 and 工作令号 like'%" + txtgonglinghao.Text.Trim() + "%') or (制造类型='自制' and 是否提交=1 and 技术部通过=1  and 生产部确认=1 and 物流部确认=1 and 图纸下达=1 and 物流部最终确认 =1 and 工作令号 like'%" + txtgonglinghao.Text.Trim() + "%') ";
                    dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);

                    gridControl4.DataSource = dt;
                    gridControl1.DataSource = dt1;

                }

                else
                {
                    MessageBox.Show("非该项目采购负责人无权限确认完成！");
                    return;
                }
            }

        }

        private void buttonItem12_Click(object sender, EventArgs e)
        {
            Frchaxunxunjiadan form1 = new Frchaxunxunjiadan();
            form1.Show();
        }

        private void gridControl4_Click(object sender, EventArgs e)
        {

        }
    }
}
