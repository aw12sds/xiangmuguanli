using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace 项目管理系统.个人管理
{
    public partial class Frgerencaigoushenqing : DevExpress.XtraEditors.XtraForm
    {
        public Frgerencaigoushenqing()
        {
            InitializeComponent();
           
        }
        public string yonghu;
        public DataTable dt;
        public string mingcheng;
        public string bumen;
        public string liushuihaokaitou;
        public string liushuihao;
        public string leixing;
        public string gonglinghao;
        public string xiangmumingcheng;
        public string shebeimingcheng;
        public string shijian;
        public string shuliang;
        private void Frgerencaigoushenqing_Load(object sender, EventArgs e)
        {
            string sql = "select 部门 from tb_operator where 用户名='" + yonghu + "'";
            bumen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
           
            if (bumen == "线缆事业部")
            {
                liushuihaokaitou = "XL";
            }
            if (bumen == "石英事业部")
            {
                liushuihaokaitou = "SY";
            }
            if (bumen == "薄材事业部")
            {
                liushuihaokaitou = "BC";
            }
            if (bumen == "智能事业部")
            {
                liushuihaokaitou = "ZN";
            }
            if (bumen == "新材事业部")
            {
                liushuihaokaitou = "XC";
            }
            if (bumen == "精工事业部")
            {
                liushuihaokaitou = "JG";
            }
            if (bumen == "模具事业部")
            {
                liushuihaokaitou = "MJ";

            }
            if (bumen == "信息化事业部")
            {
                liushuihaokaitou = "XX";
            }
            if (bumen == "人力资源部")
            {
                liushuihaokaitou = "RL";
            }
            if (bumen == "物流部")
            {
                liushuihaokaitou = "WL";
            }
            if (bumen == "办公室")
            {
                liushuihaokaitou = "BG";
            }
            if (bumen == "市场部")
            {
                liushuihaokaitou = "SC";
            }
            if (bumen == "仓库")
            {
                liushuihaokaitou = "CK";
            }
            if (bumen == "财务部")
            {
                liushuihaokaitou = "CW";
            }
            if (bumen == "研发部")
            {
                liushuihaokaitou = "YF";
            }
            if (bumen == "总经办")
            {
                liushuihaokaitou = "ZJB";
            }
            if (bumen == "质监部")
            {
                liushuihaokaitou = "ZJ";
            }

            liushuihao = liushuihaokaitou + DateTime.Now.ToString("yyyyMMddHHmmss");
            if(leixing=="项目")
            {
                dataGridViewX2.Columns["流水号"].Visible = false;
            }
            if (leixing == "部门")
            {
                dataGridViewX2.Columns["制造类型"].Visible = false;
                dataGridViewX2.Columns["库存数"].Visible = false;
            }
            if (leixing == "五金辅材")
            {
                dataGridViewX2.Columns["制造类型"].Visible = false;
                dataGridViewX2.Columns["库存数"].Visible = false;
                dataGridViewX2.Columns["流水号"].HeaderText = "工令号";
            }
            if (leixing == "原材料")
            {
                dataGridViewX2.Columns["制造类型"].Visible = false;
                dataGridViewX2.Columns["库存数"].Visible = false;
                dataGridViewX2.Columns["流水号"].HeaderText = "工令号";
            }
            dt = new DataTable();
            dt.Columns.Add("流水号");
            dt.Columns.Add("原编号");
            dt.Columns.Add("新编号");
            dt.Columns.Add("型号");
            dt.Columns.Add("名称");
            dt.Columns.Add("单位");
            dt.Columns.Add("数量");
            dt.Columns.Add("类型");
            dt.Columns.Add("要求到货日期");
            dt.Columns.Add("备注");
            dt.Columns.Add("制造类型");
            dt.Columns.Add("库存数");
        }

        private void btnchaxun_Click(object sender, EventArgs e)
        {
            if (leixing== "五金辅材")
            {
                Frerpcreat form1 = new Frerpcreat();
                form1.yonghu = yonghu;
                form1.ShowDialog();
                if (form1.DialogResult == DialogResult.OK)
                {

                    string sql = "select * from tb_xinerp where 新编号='" + form1.wuzi + "'";
                    DataTable dtt = SQLhelp.GetDataTable(sql, CommandType.Text);
                    DataRow dr1 = dt.NewRow();
                   
                    dr1["原编号"] = dtt.Rows[0]["新编号"];
                    dr1["新编号"] = dtt.Rows[0]["新编号"];
                    dr1["名称"] = dtt.Rows[0]["三级"]; //通过索引赋值
                    dr1["型号"] = dtt.Rows[0]["四级"];
                    dr1["单位"] = dtt.Rows[0]["单位"];
                    dt.Rows.Add(dr1);
                    dataGridViewX2.DataSource = dt;
                }



            }
            if (leixing == "原材料")
            {
                Frerpcreat form1 = new Frerpcreat();
                form1.yonghu = yonghu;
                form1.ShowDialog();
                if (form1.DialogResult == DialogResult.OK)
                {

                    string sql = "select * from tb_xinerp where 新编号='" + form1.wuzi + "'";
                    DataTable dtt = SQLhelp.GetDataTable(sql, CommandType.Text);
                    DataRow dr1 = dt.NewRow();
                    
                    dr1["原编号"] = dtt.Rows[0]["新编号"];
                    dr1["新编号"] = dtt.Rows[0]["新编号"];
                    dr1["名称"] = dtt.Rows[0]["三级"]; //通过索引赋值
                    dr1["型号"] = dtt.Rows[0]["四级"];
                    dr1["单位"] = dtt.Rows[0]["单位"];
                    dt.Rows.Add(dr1);
                    dataGridViewX2.DataSource = dt;
                }
            }
            if (leixing == "部门")
            {
                Frerpxuanze form1 = new Frerpxuanze();
                form1.yonghu = yonghu;
                form1.ShowDialog();
                if (form1.DialogResult == DialogResult.OK)
                {

                    string sql = "select * from tb_xinerp where 新编号='" + form1.wuzi + "'";
                    DataTable dtt = SQLhelp.GetDataTable(sql, CommandType.Text);
                    DataRow dr1 = dt.NewRow();
                    dr1["流水号"] = liushuihao;
                    dr1["原编号"] = dtt.Rows[0]["新编号"];
                    dr1["新编号"] = dtt.Rows[0]["新编号"];
                    dr1["名称"] = dtt.Rows[0]["三级"]; //通过索引赋值
                    dr1["型号"] = dtt.Rows[0]["四级"];
                    dr1["单位"] = dtt.Rows[0]["单位"];
                    dt.Rows.Add(dr1);
                    dataGridViewX2.DataSource = dt;
                }
            }
        }
        

   

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string zhizaoleixing = "";
              if(radioButton1.Checked==false&& radioButton2.Checked == false)
            {
                MessageBox.Show("请选择是属于固定资产还是日常采购");
                return;
            }else if(radioButton1.Checked)
            {
                zhizaoleixing = "固定资产采购";
            }else if (radioButton2.Checked)
            {
                zhizaoleixing = "日常采购";
            }
            if (leixing == "部门")
            {
                if (dataGridViewX2.Rows.Count > 0)
                {

                    for (int i = 0; i < dataGridViewX2.Rows.Count; i++)
                    {
                        float a = 0;
                        if (float.TryParse(dataGridViewX2.Rows[i].Cells["数量"].Value.ToString(), out a) == false)
                        {
                            MessageBox.Show("数量必须是数字！");
                            return;
                        }
                       
                    }

                    for (int i = 0; i < dataGridViewX2.Rows.Count; i++)
                    {

                        string sql = "insert into tb_caigouliaodan (工作令号,编码,新编码,型号,名称,单位,数量,类型,要求到货日期,备注,申购人,实际采购数量,收到料单日期,料单类型,制造类型,到货情况)  values ('" + liushuihao + "','" + dataGridViewX2.Rows[i].Cells["新编号"].Value.ToString() + "','" + dataGridViewX2.Rows[i].Cells["新编号"].Value.ToString() + "','" + dataGridViewX2.Rows[i].Cells["型号"].Value.ToString() + "','" + dataGridViewX2.Rows[i].Cells["名称"].Value.ToString() + "','" + dataGridViewX2.Rows[i].Cells["单位"].Value.ToString() + "','" + dataGridViewX2.Rows[i].Cells["数量"].Value.ToString() + "','" + dataGridViewX2.Rows[i].Cells["类型"].Value.ToString() + "','" + dataGridViewX2.Rows[i].Cells["要求到货日期"].Value.ToString() + "','" + dataGridViewX2.Rows[i].Cells["备注"].Value.ToString() + "','" + yonghu + "','" + dataGridViewX2.Rows[i].Cells["数量"].Value.ToString() + "','" + DateTime.Now + "','" + bumen + "','"+ zhizaoleixing+"',0)  ";
                        SQLhelp.ExecuteScalar(sql, CommandType.Text);

                    }
                    MessageBox.Show("生成成功！");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                if (dataGridViewX2.Rows.Count == 0)
                {
                    MessageBox.Show("没有料单,请生成！");
                    return;
                }
            }
            if (leixing == "五金辅材")
            {
                if (dataGridViewX2.Rows.Count > 0)
                {

                    for (int i = 0; i < dataGridViewX2.Rows.Count; i++)
                    {
                        float a = 0;
                        if (float.TryParse(dataGridViewX2.Rows[i].Cells["数量"].Value.ToString(), out a) == false)
                        {
                            MessageBox.Show("数量必须是数字！");
                            return;
                        }
                      
                    }
                    for (int i = 0; i < dataGridViewX2.Rows.Count; i++)
                    {

                        string timecaigou = DateTime.Now.AddDays(7).ToString();

                        string sql = "insert into tb_caigouliaodan (工作令号,编码,新编码,型号,名称,单位,数量,类型,要求到货日期1,备注,申购人,实际采购数量,收到料单日期,料单类型,到货情况,采购类型,采购负责人)  values ('" + dataGridViewX2.Rows[i].Cells["流水号"].Value.ToString() + "','" + dataGridViewX2.Rows[i].Cells["新编号"].Value.ToString() + "','" + dataGridViewX2.Rows[i].Cells["新编号"].Value.ToString() + "','" + dataGridViewX2.Rows[i].Cells["型号"].Value.ToString() + "','" + dataGridViewX2.Rows[i].Cells["名称"].Value.ToString() + "','" + dataGridViewX2.Rows[i].Cells["单位"].Value.ToString() + "','" + dataGridViewX2.Rows[i].Cells["数量"].Value.ToString() + "','" + dataGridViewX2.Rows[i].Cells["类型"].Value.ToString() + "','" + timecaigou + "','" + dataGridViewX2.Rows[i].Cells["备注"].Value.ToString() + "','" + yonghu + "','" + dataGridViewX2.Rows[i].Cells["数量"].Value.ToString() + "','" + DateTime.Now + "','五金辅材',0,'五金辅材','唐亚男')  ";
                        SQLhelp.ExecuteScalar(sql, CommandType.Text);
                        

                    }
                    MessageBox.Show("生成成功！");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                if (dataGridViewX2.Rows.Count == 0)
                {
                    MessageBox.Show("没有料单,请生成！");
                    return;
                }
            }
            if (leixing == "原材料")
            {
                if (dataGridViewX2.Rows.Count > 0)
                {

                    for (int i = 0; i < dataGridViewX2.Rows.Count; i++)
                    {
                        float a = 0;
                        if (float.TryParse(dataGridViewX2.Rows[i].Cells["数量"].Value.ToString(), out a) == false)
                        {
                            MessageBox.Show("数量必须是数字！");
                            return;
                        }
                     

                    }
                    for (int i = 0; i < dataGridViewX2.Rows.Count; i++)
                    {
                        string timeyuancailiao = DateTime.Now.AddDays(3).ToString();

                        string sql = "insert into tb_caigouliaodan (工作令号,编码,新编码,型号,名称,单位,数量,类型,要求到货日期1,备注,申购人,实际采购数量,收到料单日期,料单类型,到货情况,采购类型,采购负责人)  values ('" + dataGridViewX2.Rows[i].Cells["流水号"].Value.ToString() + "','" + dataGridViewX2.Rows[i].Cells["新编号"].Value.ToString() + "','" + dataGridViewX2.Rows[i].Cells["新编号"].Value.ToString() + "','" + dataGridViewX2.Rows[i].Cells["型号"].Value.ToString() + "','" + dataGridViewX2.Rows[i].Cells["名称"].Value.ToString() + "','" + dataGridViewX2.Rows[i].Cells["单位"].Value.ToString() + "','" + dataGridViewX2.Rows[i].Cells["数量"].Value.ToString() + "','" + dataGridViewX2.Rows[i].Cells["类型"].Value.ToString() + "','" + timeyuancailiao + "','" + dataGridViewX2.Rows[i].Cells["备注"].Value.ToString() + "','" + yonghu + "','" + dataGridViewX2.Rows[i].Cells["数量"].Value.ToString() + "','" + DateTime.Now + "','原材料',0,'原材料','缪星鑫')  ";
                        SQLhelp.ExecuteScalar(sql, CommandType.Text);


                    }
                    MessageBox.Show("生成成功！");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                if (dataGridViewX2.Rows.Count == 0)
                {
                    MessageBox.Show("没有料单,请生成！");
                    return;
                }
            }
        }

        private void dataGridViewX2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dt = (DataTable)dataGridViewX2.DataSource;
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

        private void 新增一行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
            DataRow dr1 = dt.NewRow();

            dt.Rows.Add(dr1);
            dataGridViewX2.DataSource = dt;
        }
    }
}