using Aspose.Cells;
using DevComponents.DotNetBar;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.项目总览
{
    public partial class FrMujvbuxiangmu : Office2007Form
    {
        public FrMujvbuxiangmu()
        {
            this.EnableGlass = false;//关键
            InitializeComponent();
        }

        private void FrMujvbuxiangmu_Load(object sender, EventArgs e)
        {
            Reload();
        }
        public string gonglinghao;
        public string gonglinghaotiaojian;
        public void Reload()
        {

            if (gonglinghao != null)
            {
                gonglinghaotiaojian = " and a.工作令号='" + gonglinghao + "'";
            }
            string sql = "select   a.id,a.模具部项目名称,cast(a.模具部接单日期 as datetime) as 模具部接单日期,a.工作令号,a.图纸上传次数,b.statename,a.当前状态,a.模具部生产车间,a.制造类型,a.项目名称,a.模具部订单号申请号,a.编码,a.模具部销售合同号,cast(a.模具部交货日期 as datetime) as 模具部交货日期,a.模具部申请人,a.模具部客户,a.模具部联系人,a.型号,a.名称,a.供方名称,a.单位,a.实际采购数量 as 数量,a.制造类型,a.模具部销售单价,a.模具部自制外协修改,实际采购数量*Cast(a.模具部销售单价 as float) as '销售总价',a.模具部销售开票日期,a.模具部实际交货日期,a.模具部销售开票金额,a.模具部成本分摊,a.采购单价 as 成本单价,a.总价 as 成本总价,a.合同类型,a.合同名称,a.供应商开票日期,a.模具部发货确认,a.供应商开票金额,a.模具部发货数量," + "a.附件名称,a.附件类型," + "(CASE  WHEN a.合同类型 is null THEN '无合同' WHEN a.合同类型 = '' THEN '无合同' else '有合同'  END) as '是否有合同'," + "(CASE  WHEN a.附件类型 is null THEN  '无附件'  WHEN 附件类型 = '' THEN '无合同' else '有附件'  END) as '是否有图纸',a.备注 " + " from tb_caigouliaodan a left join tb_state b on a.当前状态 = b.state  and b.cato='模具部' where a.料单类型 = '模具部'" + gonglinghaotiaojian + "  ORDER BY (left(a.工作令号, 2)+0) DESC,(substring(a.工作令号, 7,500)+0) DESC";

            gridControl1.DataSource = SQLhelp.GetDataTable(sql, CommandType.Text);


            string sql1 = "select a.id,a.项目名称,a.名称,a.模具部接单日期,a.工作令号,b.statename,a.型号,a.编码,a.模具部成本是否工序 as 是否工序,a.实际到货日期,a.模具部交货日期,a.实际到货数量,a.出库数量,a.库存数量,a.模具部申请人,a.采购单价 as 模具部成本单价,a.实际到货日期,a.供应商开票日期,a.税率,a.供应商开票金额,a.模具部成本总价,a.型号,a.供方名称,a.类型 as 材质,a.实际采购数量 as 数量,a.单位,a.模具部发货确认,a.备注," +"a.附件名称,a.模具部申请人,a.附件类型," + "(CASE  WHEN a.附件类型 is null THEN  '无附件'  WHEN 附件类型 = '' THEN '无合同' else '有附件'  END) as '是否有图纸'" +" from tb_caigouliaodan a left join tb_state b on a.当前状态 = b.state and b.cato='模具部原材料' where a.料单类型 = '模具部原材料'  " + gonglinghaotiaojian + "  ORDER BY 模具部接单日期 desc";
            gridControl2.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
            
        }
        
    }
}


