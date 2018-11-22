using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraCharts;
using DevExpress.Utils;

namespace 项目管理系统.生产部
{
    public partial class Frtongjibiao : DevExpress.XtraEditors.XtraForm
    {
        public Frtongjibiao()
        {
            InitializeComponent();
        }
        public DataTable dt;
        public DataTable dtt;
        public DataTable dttt;
        private void gridView4_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }
        ChartTitle ct = new ChartTitle();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            gridControl4.DataSource = dt;
            gridControl1.DataSource = dttt;
            CreateChart(dttt);
            double zonge = 0;
            for(int i=0;i<dttt.Rows.Count;i++)
            {
                zonge += Convert.ToDouble(dttt.Rows[i]["金额"]);
                
            }
            MessageBox.Show("总额:" + zonge);


        }
         private void CreateChart(DataTable dt)
        {
            chartControl1.Series.Clear();
            chartControl1.Titles.Clear();
            
            string strSelected = "工资汇总表";
            string ptitle = "";
         
            Series series1 = CreateSeries("汇总", ViewType.Line, dt, 0);
            chartControl1.Series.Add(series1);
            ptitle += strSelected + "、";
            ChartTitle title = new ChartTitle();
            
            title.Text ="汇总";
            title.Font = new Font("宋体", 10.5f);
            title.Alignment = StringAlignment.Center;

            chartControl1.Titles.Add(title);
         
            chartControl1.SeriesTemplate.LabelsVisibility = DefaultBoolean.True;
            if (chartControl1.Series.Count > 1)
            {
                for (int i = 1; i < chartControl1.Series.Count; i++)
                {
                    chartControl1.Series[i].View.Color = colorList(i);
                    if (i == 1)
                    {
                        CreateAxisY(chartControl1.Series[i], true);
                    }
                    else if (i > 1)
                    {
                        CreateAxisY(chartControl1.Series[i], false);
                    }
                }
            }
            else if (chartControl1.Series.Count == 1)
            {
                ((XYDiagram)chartControl1.Diagram).SecondaryAxesY.Clear();
            }
            else if (chartControl1.Series.Count < 1)
            {
                MessageBox.Show("请选择需要绘图的参数", "信息提示");
                return;
            }
            chartControl1.Series[0].View.Color = Color.Blue;

            ((LineSeriesView)chartControl1.Series[0].View).AxisY.Title.Text = chartControl1.Series[0].Name;
            ((LineSeriesView)chartControl1.Series[0].View).AxisY.Title.Alignment = StringAlignment.Far; //顶部对齐
           
            ((LineSeriesView)chartControl1.Series[0].View).AxisY.Title.Font = new Font("宋体", 9.0f);

            Color color = chartControl1.Series[0].View.Color;//设置坐标的颜色和图表线条颜色一致

            ((LineSeriesView)chartControl1.Series[0].View).AxisY.Title.TextColor = color;
            ((LineSeriesView)chartControl1.Series[0].View).AxisY.Label.TextColor = color;
            ((LineSeriesView)chartControl1.Series[0].View).AxisY.Color = color;
            ((LineSeriesView)chartControl1.Series[0].View).AxisY.Label.Visible = true;

        }
        private SecondaryAxisY CreateAxisY(Series series, bool isShow2)
        {
            SecondaryAxisY myAxis = new SecondaryAxisY(series.Name);
            ((XYDiagram)chartControl1.Diagram).SecondaryAxesY.Add(myAxis);
            if (isShow2 == true)
            {
                ((XYDiagram)chartControl1.Diagram).SecondaryAxesY.Clear();
                ((XYDiagram)chartControl1.Diagram).SecondaryAxesY.Add(myAxis);
            }
        ((LineSeriesView)series.View).AxisY = myAxis;
            myAxis.Title.Text = series.Name;
            myAxis.Title.Alignment = StringAlignment.Far; //顶部对齐
           
            myAxis.Title.Font = new Font("宋体", 9.0f);

            Color color = series.View.Color;//设置坐标的颜色和图表线条颜色一致

            myAxis.Title.TextColor = color;
            myAxis.Label.TextColor = color;
            myAxis.Color = color;
            return myAxis;
        }

        private Color colorList(int i)
        {
            Color pcolor = new Color();
            if (i == 0)
            {
                pcolor = Color.Yellow;
            }
            if (i == 1)
            {
                pcolor = Color.Blue;
            }
            if (i == 2)
            {
                pcolor = Color.Red;
            }
            if (i == 3)
            {
                pcolor = Color.Pink;
            }
            if (i == 4)
            {
                pcolor = Color.Gold;
            }
            return pcolor;
        }

        private void Frtongjibiao_Load(object sender, EventArgs e)
        {
            gridControl4.DataSource = dt;
            gridControl1.DataSource = dtt;
            
        }
        private Series CreateSeries(string caption, ViewType viewType, DataTable dt, int rowIndex)
        {
            Series series = new Series(caption, viewType);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string argument = dt.Rows[i]["日期"].ToString(); ;//参数名称
                double value = Convert.ToDouble(dt.Rows[i]["金额"]);//参数值
                series.Points.Add(new SeriesPoint(argument, value));
            }

            //必须设置ArgumentScaleType的类型，否则显示会转换为日期格式，导致不是希望的格式显示
            //也就是说，显示字符串的参数，必须设置类型为ScaleType.Qualitative
            series.ArgumentScaleType = ScaleType.Qualitative;
            //series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;//显示标注标签

            return series;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            for (int t = 1; t < gridView4.Columns.Count; t++)
            {
                string a = gridView4.GetRowCellValue(0, "姓名").ToString();

                this.gridView1.SetRowCellValue(t - 1, gridView1.Columns["金额"], gridView4.GetRowCellValue(0, gridView4.Columns[t]).ToString());

            }

            CreateChart((DataTable)gridControl1.DataSource);
            
        }

        private void 生成该人的工资图表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string xingming = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "姓名"));
            DataRow[] drArr = dt.Select("姓名='"+xingming+"'");//查询
            DataTable dtNew = dt.Clone();
            DataTable dtNew1 = dtt.Clone();
            
            for (int i = 0; i < drArr.Length; i++)
            {
                dtNew.ImportRow(drArr[i]);
                
            }
            for (int i = 0; i < dtNew.Columns.Count-1; i++)
            {
                
                dtNew1.Rows.Add();
                dtNew1.Rows[i]["金额"]= dtNew.Rows[0][i+1].ToString();
                dtNew1.Rows[i]["日期"] = dtNew.Columns[i + 1].ColumnName;
            }
            CreateChart(dtNew1);
            dtt = dtNew1;
            gridControl1.DataSource = dtNew1;
            //double zonge = 0;
            //for (int i = 0; i < dtNew1.Rows.Count; i++)
            //{
            //    zonge += Convert.ToDouble(dtNew1.Rows[i]["金额"]);

            //}
            //MessageBox.Show("总额:" + zonge);
        }

        private void 导出表格ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "导出Excel";
            fileDialog.Filter = "Excel文件(*.xls)|*.xls";
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                gridControl4.ExportToXls(fileDialog.FileName);
                DevExpress.XtraEditors.XtraMessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
