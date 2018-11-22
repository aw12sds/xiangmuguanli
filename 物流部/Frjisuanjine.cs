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
    public partial class Frjisuanjine : Office2007Form
    {
        public Frjisuanjine()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string gongzuolinghao;
        public string xiangmumingcheng;
        public string shijian;
        public string lujing;
        
        public double zongjia;
        DataTable dt;
        public string yonghu;
        private void Frjisuanjine_Load(object sender, EventArgs e)
        {
            
            

            Reload();


        }
        public void Reload()
        {
            
            string sql1 = "select id, 序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,申购人,收到料单日期,供方名称,合同号,实际采购数量,报价, 采购单价,实际到货日期,当前状态,采购料单备注,附件名称,附件类型 from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "' and   制造类型!='自制零部件' and   制造类型!='装配零部件'  and   制造类型!='库存件'";
            dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            dataGridViewX1.DataSource = dt;
            DataColumn column1 = new DataColumn();
            //该列的数据类型
            column1.DataType = System.Type.GetType("System.String");
            //该列得名称
            column1.ColumnName = "总价";
            dt.Columns.Add(column1);


        }
        private void 计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            
            
           
            for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
                {
                    if (Convert.ToString(dataGridViewX1.Rows[i].Cells["采购单价"].Value) != "")
                    {
                        int shuliang = Convert.ToInt32(dataGridViewX1.Rows[i].Cells["数量"].Value);
                        double danjia = Convert.ToDouble(dataGridViewX1.Rows[i].Cells["采购单价"].Value);
                        dt.Rows[i]["总价"] = shuliang * danjia;

                    }
                    if (Convert.ToString(dataGridViewX1.Rows[i].Cells["采购单价"].Value) == "")
                    {
                        dt.Rows[i]["总价"] = 0;

                    }

                }

            dataGridViewX1.DataSource = dt;
         
            
        }

        private void 计算总额ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zongjia = 0;
            for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
            {
                if (Convert.ToString(dataGridViewX1.Rows[i].Cells["总价"].Value) != "")
                {
                    double jiage = Convert.ToDouble(dataGridViewX1.Rows[i].Cells["总价"].Value);
                    zongjia += jiage;

                }
               

            }

            MessageBox.Show(zongjia.ToString());
        }
    }
}
