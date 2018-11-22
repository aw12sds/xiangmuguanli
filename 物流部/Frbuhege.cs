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
    public partial class Frbuhege : DevExpress.XtraEditors.XtraForm
    
    {
        public Frbuhege()
        {
            InitializeComponent();
        }

        private void Frbuhege_Load(object sender, EventArgs e)
        {
            reload();
        }
        public string yonghu;
        public void reload()
        {
            string sql1 = "select id,工作令号,项目名称,设备名称,供方名称,型号,名称,单位,发起到货验收数量,本次到货验收数量,合格数量,不合格数量,不合格描述,实际采购数量,合同号 from  tb_caigouliaodan  where 到货验收流程状态='4不合格待评审'";
            gridControl1.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridView1.Columns["id"].Visible = false;
        }
    }
}
