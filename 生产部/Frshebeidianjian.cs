using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.生产部
{
    public partial class Frshebeidianjian : Form
    {
        public Frshebeidianjian()
        {
            InitializeComponent();
        }
        public string yonghu;
        private void Frshebeidianjian_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                DataTable dt = new DataTable();
                string b = dialog.FileName;
                Workbook book = new Workbook(b);
                Worksheet sheet = book.Worksheets["Sheet1"];
                //Cells cells = sheet.Cells;                
                //DataTable dt_Import = cells.ExportDataTableAsString(0, 0, cells.MaxDataRow + 1, cells.MaxDataColumn + 1, false);

                dt = sheet.Cells.ExportDataTableAsString(1, 0,16, 29);
                dt.Columns["Column1"].ColumnName = "采购员";
                dt.Columns["Column2"].ColumnName = "供方名称";
                dt.Columns["Column3"].ColumnName = "合同号";
                dt.Columns["Column4"].ColumnName = "合同总价";
                dt.Columns["Column5"].ColumnName = "付款方式";
                dt.Columns["Column6"].ColumnName = "付款状态";
                dt.Columns["Column7"].ColumnName = "发票状态";
                dt.Columns["Column8"].ColumnName = "发票收到日期";
                dt.Columns["Column9"].ColumnName = "发票编号";
                dt.Columns["Column10"].ColumnName = "发票开具日期";
                dt.Columns["Column11"].ColumnName = "发票金额";
                dt.Columns["Column12"].ColumnName = "总计已付款金额";
                dt.Columns["Column13"].ColumnName = "申请1日期";
                dt.Columns["Column14"].ColumnName = "付款1金额";
                dt.Columns["Column15"].ColumnName = "申请1进度";
                dt.Columns["Column16"].ColumnName = "申请2日期";
                dt.Columns["Column17"].ColumnName = "付款2金额";
                dt.Columns["Column18"].ColumnName = "申请2进度";
                dt.Columns["Column19"].ColumnName = "申请3日期";
                dt.Columns["Column20"].ColumnName = "付款3金额";
                dt.Columns["Column21"].ColumnName = "申请3进度";
                dt.Columns["Column22"].ColumnName = "申请4日期";
                dt.Columns["Column23"].ColumnName = "付款4金额";
                dt.Columns["Column24"].ColumnName = "申请4进度";
                dt.Columns["Column25"].ColumnName = "有无质保金";
                dt.Columns["Column26"].ColumnName = "质保期";
                dt.Columns["Column27"].ColumnName = "开户行";
                dt.Columns["Column28"].ColumnName = "行号";
                dt.Columns["Column29"].ColumnName = "账号";


                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string chaxun = "select * from tb_caigoutaizhang where 合同号='" + dt.Rows[i]["合同号"].ToString() + "'";
                        DataTable dt2233 = SQLhelp.GetDataTable(chaxun, CommandType.Text);
                        if (dt2233.Rows.Count == 0)
                        {
                            string sql112 = "insert into tb_caigoutaizhang (付款方式,发票收到日期,发票编号,发票开具日期,发票金额,总计已付款金额,申请付款日期1,申请付款金额1,申请付款进度1,申请付款日期2,申请付款金额2,申请付款进度2,申请付款日期3,申请付款金额3,申请付款进度3,申请付款日期4,申请付款金额4,申请付款进度4,质保金,质保期,开户银行,银行行号,银行账号,合同号,供方名称,合同总价,付款状态,发票状态,采购员) values ('" + dt.Rows[i]["付款方式"].ToString() + "','" + dt.Rows[i]["发票收到日期"].ToString() + "','" + dt.Rows[i]["发票编号"].ToString() + "','" + dt.Rows[i]["发票开具日期"].ToString() + "','" + dt.Rows[i]["发票金额"].ToString() + "','" + dt.Rows[i]["总计已付款金额"].ToString() + "','" + dt.Rows[i]["申请1日期"].ToString() + "','" + dt.Rows[i]["付款1金额"].ToString() + "','" + dt.Rows[i]["申请1进度"].ToString() + "','" + dt.Rows[i]["申请2日期"].ToString() + "','" + dt.Rows[i]["付款2金额"].ToString() + "','" + dt.Rows[i]["申请2进度"].ToString() + "','" + dt.Rows[i]["申请3日期"].ToString() + "','" + dt.Rows[i]["付款3金额"].ToString() + "','" + dt.Rows[i]["申请3进度"].ToString() + "','" + dt.Rows[i]["申请4日期"].ToString() + "','" + dt.Rows[i]["付款4金额"].ToString() + "','" + dt.Rows[i]["申请4进度"].ToString() + "','" + dt.Rows[i]["有无质保金"].ToString() + "','" + dt.Rows[i]["质保期"].ToString() + "','" + dt.Rows[i]["开户行"].ToString() + "','" + dt.Rows[i]["行号"].ToString() + "','" + dt.Rows[i]["账号"].ToString() + "','" + dt.Rows[i]["合同号"].ToString() + "','" + dt.Rows[i]["供方名称"].ToString() + "','" + dt.Rows[i]["合同总价"].ToString() + "','" + dt.Rows[i]["付款状态"].ToString() + "','" + dt.Rows[i]["发票状态"].ToString() + "','" + dt.Rows[i]["采购员"].ToString() + "')";
                            SQLhelp.ExecuteScalar(sql112, CommandType.Text);
                        }
                        if (dt2233.Rows.Count != 0)
                        {
                            string sql112 = "update tb_caigoutaizhang set 付款方式='" + dt.Rows[i]["付款方式"].ToString() + "',发票收到日期='" + dt.Rows[i]["发票收到日期"].ToString() + "',发票编号='" + dt.Rows[i]["发票编号"].ToString() + "',发票开具日期='" + dt.Rows[i]["发票开具日期"].ToString() + "',发票金额='" + dt.Rows[i]["发票金额"].ToString() + "',总计已付款金额='" + dt.Rows[i]["总计已付款金额"].ToString() + "',申请付款日期1='" + dt.Rows[i]["申请1日期"].ToString() + "',申请付款金额1='" + dt.Rows[i]["付款1金额"].ToString() + "',申请付款进度1='" + dt.Rows[i]["申请1进度"].ToString() + "',申请付款日期2='" + dt.Rows[i]["申请2日期"].ToString() + "',申请付款金额2='" + dt.Rows[i]["付款2金额"].ToString() + "',申请付款进度2='" + dt.Rows[i]["申请2进度"].ToString() + "',申请付款日期3='" + dt.Rows[i]["申请3日期"].ToString() + "',申请付款金额3='" + dt.Rows[i]["付款3金额"].ToString() + "',申请付款进度3='" + dt.Rows[i]["申请3进度"].ToString() + "',申请付款日期4='" + dt.Rows[i]["申请4日期"].ToString() + "',申请付款金额4='" + dt.Rows[i]["付款4金额"].ToString() + "',申请付款进度4='" + dt.Rows[i]["申请4进度"].ToString() + "',质保金='" + dt.Rows[i]["有无质保金"].ToString() + "',质保期='" + dt.Rows[i]["质保期"].ToString() + "',合同号='" + dt.Rows[i]["合同号"].ToString() + "',开户银行='" + dt.Rows[i]["开户行"].ToString() + "',银行行号='" + dt.Rows[i]["行号"].ToString() + "',银行账号='" + dt.Rows[i]["账号"].ToString() + "',合同总价='" + dt.Rows[i]["合同总价"].ToString() + "',采购员='" + dt.Rows[i]["采购员"].ToString() + "',供方名称='" + dt.Rows[i]["供方名称"].ToString() + "',付款状态='" + dt.Rows[i]["付款状态"].ToString() + "',发票状态='" + dt.Rows[i]["发票状态"].ToString() + "' where 合同号='" + dt.Rows[i]["合同号"].ToString() + "' and 发票编号 IS NULL";

                            SQLhelp.ExecuteScalar(sql112, CommandType.Text);
                        }
                    }
                    MessageBox.Show("生成成功！");
                    
                }
            }
            }
    }
}
