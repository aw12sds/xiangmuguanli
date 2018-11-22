using Aspose.Cells;
using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 项目管理系统.个人管理;
using 项目管理系统.生产部;

namespace 项目管理系统.技术部
{
    public partial class FrLiaodan : Office2007Form
    {
        public FrLiaodan()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }
        public string gonglinghao;
        public string xiangmu;
        public string shebei;
        public DataTable dt;
        public string shijian;
        public string shuliang11;
        public int a;
        public string name;
        public string yonghu;
        private long fileSize = 0;//文件大小
        private string fileName = null;//文件名字
        private string fileType = null;//文件类型
        private byte[] files;//文件
        private BinaryReader read = null;//二进制读取
        public string mingcheng;
        public string dingwei;

        private void FrLiaodan_Load(object sender, EventArgs e)
        {
            Reload();

        }
        public void Reload()
        {
            string sql1 = "select  id,工作令号,项目名称,时间,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,附件名称,实际采购数量,新编码 from  tb_caigouliaodan  where 工作令号='" + gonglinghao + "' and 项目名称='" + xiangmu + "'and 时间='" + shijian + "' and 设备名称='" + shebei + "'";
            DataTable dt = SQLhelp.GetDataTable(sql1, CommandType.Text);
            dataGridViewX2.DataSource = dt;

        }

        private void 录入料单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrLiaodanshezhi form = new FrLiaodanshezhi();
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                try
                {
                    dt = null;
                    int hangshu = Convert.ToInt32(form.hangshu);
                    OpenFileDialog dialog = new OpenFileDialog();
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        string b = dialog.FileName;

                        Workbook book = new Workbook(b);
                        Worksheet sheet = book.Worksheets["Sheet1"];

                        dt = sheet.Cells.ExportDataTableAsString(7, 0, hangshu, 11);

                        dt.Columns["Column1"].ColumnName = "序号";

                        dt.Columns["Column2"].ColumnName = "编码";

                        dt.Columns["Column3"].ColumnName = "型号";
                        dt.Columns["Column4"].ColumnName = "名称";
                        dt.Columns["Column5"].ColumnName = "单位";
                        dt.Columns["Column6"].ColumnName = "数量";
                        dt.Columns["Column7"].ColumnName = "类型";
                        dt.Columns["Column8"].ColumnName = "项目工令号";
                        dt.Columns["Column9"].ColumnName = "要求到货日期";
                        dt.Columns["Column10"].ColumnName = "制造类型";
                        dt.Columns["Column11"].ColumnName = "备注";


                        dataGridViewX2.DataSource = dt;


                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(" 发生了" + ex.Message);
                    this.Close();
                }


            }

        }

        private void 保存料单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认保存吗？保存料单图纸将会清空!!!", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string sql1 = "delete from  tb_caigouliaodan  where 工作令号='" + gonglinghao + "' and 项目名称='" + xiangmu + "'and 设备名称='" + shebei + "' and 时间='" + shijian + "'";
                SQLhelp.ExecuteScalar(sql1, CommandType.Text);
                try
                {
                    for (int i = 0; i < dataGridViewX2.Rows.Count; i++)
                    {
                        string dangqianzhuangtai = "";
                        string xuhao = Convert.ToString(dataGridViewX2.Rows[i].Cells["序号"].Value);
                        string bianma = Convert.ToString(dataGridViewX2.Rows[i].Cells["编码"].Value);
                        string xinghao = Convert.ToString(dataGridViewX2.Rows[i].Cells["型号"].Value);
                        string mingcheng = Convert.ToString(dataGridViewX2.Rows[i].Cells["名称"].Value);
                        string shuliang = Convert.ToString(dataGridViewX2.Rows[i].Cells["数量"].Value);

                        string xiangmugonglinghao = Convert.ToString(dataGridViewX2.Rows[i].Cells["项目工令号"].Value);

                        int shijishuliang = Convert.ToInt32(shuliang11) * Convert.ToInt32(shuliang) - Convert.ToInt32(xiangmugonglinghao);
                        if (shijishuliang == 0)
                        {
                            dangqianzhuangtai = "无需加工或购买";
                        }


                        string leixing = Convert.ToString(dataGridViewX2.Rows[i].Cells["类型"].Value);
                        string danwei = Convert.ToString(dataGridViewX2.Rows[i].Cells["单位"].Value);

                        string yaoqiudaohuoriqi = Convert.ToString(dataGridViewX2.Rows[i].Cells["要求到货日期"].Value);

                        string zhizaoleixing = Convert.ToString(dataGridViewX2.Rows[i].Cells["制造类型"].Value);
                        string beizhu = Convert.ToString(dataGridViewX2.Rows[i].Cells["备注"].Value);

                        string sql2 = "INSERT INTO tb_caigouliaodan(工作令号,项目名称,设备名称,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,时间,制造类型,生产部确认,仓库确认,检验,实际采购数量,当前状态,料单类型) VALUES( '" + gonglinghao + "', '" + xiangmu + "', '" + shebei + "','" + xuhao + "', '" + bianma + "', '" + xinghao + "', '" + mingcheng + "','" + danwei + "', '" + shuliang + "', '" + leixing + "', '" + xiangmugonglinghao + "', '" + yaoqiudaohuoriqi + "', '" + beizhu + "', '" + shijian + "', '" + zhizaoleixing + "',0,0,0,'" + shijishuliang + "','" + dangqianzhuangtai + "','项目')";
                        SQLhelp.ExecuteScalar(sql2, CommandType.Text);

                    }
                    MessageBox.Show("提交成功！");
                    this.Close();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void dataGridViewX2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex < 0 && e.RowIndex >= 0)
            {
                e.Paint(e.ClipBounds, DataGridViewPaintParts.All);
                Rectangle rectangle = e.CellBounds;
                rectangle.Inflate(-2, -2);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.CellStyle.Font, rectangle, e.CellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
                e.Handled = true;
            }
        }

        private void 添加图纸ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewX2.Rows.Count == 0)
            {
                MessageBox.Show("没有料单，请先导入！");
                return;
            }
            //string id = dataGridViewX2.CurrentRow.Cells["id"].Value.ToString();

            //打开对话框
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                int a = 0;
                 int b=dialog.FileNames.Length;
                if(b>dataGridViewX2.Rows.Count)
                {
                    MessageBox.Show("选中的文件数量超过了该料单的行数！");
                    return;
                }
                foreach (string s in dialog.FileNames)
                {
                    name = s;
                    string id = dataGridViewX2.Rows[a].Cells["id"].Value.ToString();
                    FileInfo info = new FileInfo(name);
                    a += 1;
                    //获得文件大小
                    fileSize = info.Length;
                    //提取文件名,三步走
                    int index = info.FullName.LastIndexOf(".");
                    fileName = info.FullName.Remove(index);
                    fileName = fileName.Substring(fileName.LastIndexOf(@"\") + 1);
                    mingcheng = fileName;
                    //获得文件扩展名
                    fileType = info.Extension.Replace(".", "");
                    //把文件转换成二进制流
                    files = new byte[Convert.ToInt32(fileSize)];
                    FileStream file = new FileStream(name, FileMode.Open, FileAccess.Read);
                    read = new BinaryReader(file);
                    read.Read(files, 0, Convert.ToInt32(fileSize));

                    string sql = "update tb_caigouliaodan  set 附件=@pic where id='" + id + "'";
                    SQLhelp.ExecuteNonquery(sql, CommandType.Text, files);                
                    string sql1 = "update tb_caigouliaodan  set 附件名称='" + mingcheng + "',附件类型='" + fileType + "' where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql1, CommandType.Text);
                }
                
                Reload();
               
            }
        }

        private void dataGridViewX2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int CIndex = e.ColumnIndex;
            //按钮所在列为第五列，列下标从0开始的  
            if (CIndex == 16)
            {
                if (dataGridViewX2.CurrentRow.Cells["id"].Value == null)
                {

                    MessageBox.Show("没有附件！");
                    return;
                }
                if (dataGridViewX2.CurrentRow.Cells["id"].Value != null)
                {
                    string id = dataGridViewX2.CurrentRow.Cells["id"].Value.ToString();

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

            }
        }

        private void 保存更改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认保存更改吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                for (int i = 0; i < dataGridViewX2.Rows.Count; i++)
                {
                    string id = Convert.ToString(dataGridViewX2.Rows[i].Cells["id"].Value);
                    if (id == "")
                    {
                        MessageBox.Show("请先保存料单,再更改！");
                        return;
                    }
                    if (id != "")
                    {
                        string xuhao = dataGridViewX2.Rows[i].Cells["序号"].Value.ToString();
                        string bianma = dataGridViewX2.Rows[i].Cells["编码"].Value.ToString();
                        string xinbianma = dataGridViewX2.Rows[i].Cells["新编码"].Value.ToString();
                        string zhizao = dataGridViewX2.Rows[i].Cells["制造类型"].Value.ToString();
                        string leixing = dataGridViewX2.Rows[i].Cells["类型"].Value.ToString();
                        string beizhu = dataGridViewX2.Rows[i].Cells["备注"].Value.ToString();
                        string daohuo = dataGridViewX2.Rows[i].Cells["要求到货日期"].Value.ToString();
                        string xinghao = dataGridViewX2.Rows[i].Cells["型号"].Value.ToString();
                        string mingcheng = dataGridViewX2.Rows[i].Cells["名称"].Value.ToString();
                        string sql2 = "update tb_caigouliaodan  set 编码='" + bianma + "',制造类型='" + zhizao + "',类型='" + leixing + "',备注='" + beizhu + "',序号='" +xuhao + "' where id ='" + id + "' ";
                        SQLhelp.ExecuteScalar(sql2, CommandType.Text);

                        if (bianma == "")
                        {
                            string sql23 = "update tb_caigouliaodan  set 型号='" + xinghao + "',名称='" + mingcheng + "' where id ='" + id + "' ";
                            SQLhelp.ExecuteScalar(sql23, CommandType.Text);

                        }

                    }


                }
                MessageBox.Show("保存成功！");
                Reload();

            }
        }

        private void 自动匹配ERPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewX2.Rows.Count; i++)
            {
                string mingcheng = dataGridViewX2.Rows[i].Cells["制造类型"].Value.ToString();
                if (mingcheng == "机械标准件" || mingcheng == "电气标准件" || mingcheng == "库存件" || mingcheng == "外购")
                {
                    string id = Convert.ToString(dataGridViewX2.Rows[i].Cells["id"].Value);
                    if (id == "")
                    {
                        MessageBox.Show("请先保存料单,再匹配！");
                        return;
                    }
                    if (id != "")
                    {
                        string xinghao = dataGridViewX2.Rows[i].Cells["名称"].Value.ToString();
                        string xinghao1 = dataGridViewX2.Rows[i].Cells["型号"].Value.ToString();
                        string xinghao2 = xinghao + xinghao1;
                        string sql = "select 零件号 from tb_laoerp where 零件描述='" + xinghao2 + "'";

                        dataGridViewX2.Rows[i].Cells["编码"].Value = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
                    }
                }
            }
            MessageBox.Show("已匹配!");
        }

        private void 模糊搜索ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmohusousuo form1 = new Frmohusousuo();
            form1.Show();
        }
        private void buttonItem1_Click(object sender, EventArgs e)
        {
            Frgerencaigoushenqing form1 = new Frgerencaigoushenqing();
            form1.yonghu = yonghu;
            form1.leixing = "项目";
            form1.gonglinghao = gonglinghao;
            form1.xiangmumingcheng = xiangmu;
            form1.shebeimingcheng = shebei;
            form1.shijian = shijian;
            form1.shuliang = shuliang11;
            form1.ShowDialog();
            if (form1.DialogResult == DialogResult.OK)
            {
                string sql1 = "select  id,工作令号,项目名称,时间,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,附件名称,实际采购数量,新编码 from  tb_caigouliaodan  where 工作令号='" + gonglinghao + "' and 项目名称='" + xiangmu + "'and 时间='" + shijian + "' and 设备名称='" + shebei + "'";
                dataGridViewX2.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);

            }
        }

        private void 删除该行ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string id = dataGridViewX2.CurrentRow.Cells["id"].Value.ToString();
            string sql = "delete from tb_caigouliaodan where id='" + id + "'";
            SQLhelp.ExecuteScalar(sql, CommandType.Text);
            MessageBox.Show("删除成功！");
            Reload();
        }

        private void 录入料单ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrLiaodanshezhi form = new FrLiaodanshezhi();
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                try
                {
                    dt = null;
                    int hangshu = Convert.ToInt32(form.hangshu);
                    OpenFileDialog dialog = new OpenFileDialog();
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        string b = dialog.FileName;
                        Workbook book = new Workbook(b);
                        Worksheet sheet = book.Worksheets["Sheet1"];
                        dt = sheet.Cells.ExportDataTableAsString(7, 0, hangshu, 11);
                        dt.Columns["Column1"].ColumnName = "序号";
                        dt.Columns["Column2"].ColumnName = "编码";
                        dt.Columns["Column3"].ColumnName = "型号";
                        dt.Columns["Column4"].ColumnName = "名称";
                        dt.Columns["Column5"].ColumnName = "单位";
                        dt.Columns["Column6"].ColumnName = "数量";
                        dt.Columns["Column7"].ColumnName = "类型";
                        dt.Columns["Column8"].ColumnName = "库存数";
                        dt.Columns["Column9"].ColumnName = "要求到货日期";
                        dt.Columns["Column10"].ColumnName = "制造类型";
                        dt.Columns["Column11"].ColumnName = "备注";
                        if (dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                float a = 0;
                                if (float.TryParse(dt.Rows[i]["数量"].ToString(), out a) == false)
                                {
                                    int aaa = i + 1;
                                    MessageBox.Show("第" + aaa + "行料单"+"数量必须是数字！");
                                    return;
                                }

                                if (float.TryParse(shuliang11, out a) == false)
                                {
                                    MessageBox.Show("技术指标的数量必须是数字！");
                                    return;
                                }
                                if (float.TryParse(dt.Rows[i]["库存数"].ToString(), out a) == false)
                                {
                                    int aaa = i + 1;
                                    MessageBox.Show("第" + aaa + "行料单的"+"库存数必须是数字！");
                                    return;
                                }

                                if (dt.Rows[i]["制造类型"].ToString() != "零件" && dt.Rows[i]["制造类型"].ToString() != "机械标准件" && dt.Rows[i]["制造类型"].ToString() != "电气标准件" && dt.Rows[i]["制造类型"].ToString() != "库存件" && dt.Rows[i]["制造类型"].ToString() != "外购")
                                {
                                    int aaa = i + 1;
                                    MessageBox.Show("第" + aaa + "行料单的"+"制造类型必须符合规范，只能是零件、机械标准件、电气标准件、库存件、外购！");
                                    return;
                                }
                                double shijicaigou = Convert.ToDouble(shuliang11) * Convert.ToDouble(dt.Rows[i]["数量"].ToString()) - Convert.ToDouble(dt.Rows[i]["库存数"].ToString());
                                if (dt.Rows[i]["制造类型"].ToString() != "库存件")
                                {
                                    int aaa = i + 1;
                                    if (shijicaigou <= 0)
                                    {
                                        MessageBox.Show( "第"+aaa+"行料单"+"计算得出的实际采购（加工）数量存在负数或者是0，请检查！");
                                        return;

                                    }
                                }
                                if (dt.Rows[i]["制造类型"].ToString() == "库存件")
                                {
                                    int aaaa = i + 1;
                                    if (shijicaigou != 0)
                                    {
                                        MessageBox.Show("第" + aaaa+ "行料单" + "库存件算出不等于0，请重新填写库存数！");
                                        return;
                                    }
                                }

                            }
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                double shijicaigou = Convert.ToDouble(shuliang11) * Convert.ToDouble(dt.Rows[i]["数量"].ToString()) - Convert.ToDouble(dt.Rows[i]["库存数"].ToString());
                                string sql = "insert into tb_caigouliaodan (序号,工作令号,项目名称,设备名称,时间,型号,名称,单位,数量,类型,备注,申购人,实际采购数量,收到料单日期,料单类型,项目工令号,制造类型,定位)  values ('" + dt.Rows[i]["序号"].ToString() + "','" + gonglinghao + "','" + xiangmu + "','" + shebei + "','" + shijian + "','" + dt.Rows[i]["型号"].ToString().Trim() + "','" + dt.Rows[i]["名称"].ToString().Trim() + "','" + dt.Rows[i]["单位"].ToString() + "','" + dt.Rows[i]["数量"].ToString() + "','" + dt.Rows[i]["类型"].ToString() + "','" + dt.Rows[i]["备注"].ToString() + "','" + yonghu + "','" + shijicaigou + "','" + DateTime.Now + "','项目','" + dt.Rows[i]["库存数"].ToString() + "','" + dt.Rows[i]["制造类型"].ToString() + "','"+dingwei+"')  ";
                                SQLhelp.ExecuteScalar(sql, CommandType.Text);

                            }
                            MessageBox.Show("生成成功！");                           
                        }
                        string sql1 = "select  id,工作令号,项目名称,时间,序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,附件名称,实际采购数量,新编码 from  tb_caigouliaodan  where 工作令号='" + gonglinghao + "' and 项目名称='" + xiangmu + "'and 时间='" + shijian + "' and 设备名称='" + shebei + "'";
                        dataGridViewX2.DataSource = SQLhelp.GetDataTable(sql1, CommandType.Text);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(" 发生了" + ex.Message);
                    this.Close();
                }
            }
        }

        private void 匹配新ERP编码ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < dataGridViewX2.Rows.Count; i++)
            {
                string mingcheng = dataGridViewX2.Rows[i].Cells["制造类型"].Value.ToString();

                string id = Convert.ToString(dataGridViewX2.Rows[i].Cells["id"].Value);
                if (id == "")
                {
                    MessageBox.Show("请先保存料单,再匹配！");
                    return;
                }
                if (id != "")
                {
                    string xinghao = dataGridViewX2.Rows[i].Cells["名称"].Value.ToString();
                    string xinghao1 = dataGridViewX2.Rows[i].Cells["型号"].Value.ToString();

                    string sql = "select  新编号 ,安全库存,单位 from tb_xinerp where 三级='" + xinghao + "' and 四级='" + xinghao1 + "'";
                    DataTable dta = SQLhelp.GetDataTable(sql, CommandType.Text);
                    if (dta.Rows.Count >= 1)
                    {
                        if (Convert.ToString(dta.Rows[0]["安全库存"]) == "1")
                        {
                            string sql12 = "update tb_caigouliaodan set   安全库存='" + Convert.ToString(dta.Rows[0]["安全库存"]) + "',制造类型='库存件'  where id='" + id + "'";
                            SQLhelp.ExecuteScalar(sql12, CommandType.Text);
                        }
                    }
                    if (dta.Rows.Count == 1)
                    {
                        dataGridViewX2.Rows[i].Cells["编码"].Value = dta.Rows[0]["新编号"].ToString();
                        dataGridViewX2.Rows[i].Cells["单位"].Value = dta.Rows[0]["单位"].ToString();
                    }
                    if (dta.Rows.Count > 1)
                    {
                        MessageBox.Show("有相同的名称，不同的编码！");
                        return;
                    }
                }

            }
            MessageBox.Show("已匹配!");
        }

        private void 删除全部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewX2.Rows.Count; i++)
            {
                string id = Convert.ToString(dataGridViewX2.Rows[i].Cells["id"].Value);
                string sql = "delete from tb_caigouliaodan where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);
              
            }
            MessageBox.Show("删除成功！");
            Reload();

        }

        private void 查询ERPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frerpchaxun FORM1 = new Frerpchaxun();
            FORM1.Show();
            FORM1.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void 添加单张图纸ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewX2.Rows.Count == 0)
            {
                MessageBox.Show("没有料单，请先导入！");
                return;
            }
            string id = dataGridViewX2.CurrentRow.Cells["id"].Value.ToString();

            //打开对话框
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo info = new FileInfo(dialog.FileName);

                //获得文件大小
                fileSize = info.Length;
                //提取文件名,三步走
                int index = info.FullName.LastIndexOf(".");
                fileName = info.FullName.Remove(index);
                fileName = fileName.Substring(fileName.LastIndexOf(@"\") + 1);
                mingcheng = fileName;
                //获得文件扩展名
                fileType = info.Extension.Replace(".", "");
                //把文件转换成二进制流
                files = new byte[Convert.ToInt32(fileSize)];
                FileStream file = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read);
                read = new BinaryReader(file);
                read.Read(files, 0, Convert.ToInt32(fileSize));


                string ConStr = "update tb_caigouliaodan  set 附件=@pic where id='" + id + "'";
                SQLhelp.ExecuteNonquery(ConStr, CommandType.Text, files);
                
                string sql = "update tb_caigouliaodan  set 附件名称='" + mingcheng + "',附件类型='" + fileType + "' where id='" + id + "'";
                SQLhelp.ExecuteScalar(sql, CommandType.Text);
                a = this.dataGridViewX2.CurrentRow.Index;
                Reload();
                dataGridViewX2.Rows[a].Selected = true;
                dataGridViewX2.FirstDisplayedScrollingRowIndex = a;
            }
        }
    }
}

