using NetWork.util;
using NetWorkLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 项目管理系统.质监部
{
    public partial class Frtuihuiyuanyin : DevExpress.XtraEditors.XtraForm
    {
        public Frtuihuiyuanyin()
        {
            InitializeComponent();
        }
        public string id;
        public DataTable dt;
        public string yonghu;
        private void Frtuihuiyuanyin_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txtneirong.Text != "")
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string id = dt.Rows[i]["id"].ToString();
                    string sql = "update tb_caigouliaodan set 退回原因='" + txtneirong.Text + "' where id='" + id + "'";
                    SQLhelp.ExecuteScalar(sql, CommandType.Text);

                    string sql1 = "update tb_caigouliaodan set 提交类型='质监员退回',到货验收流程状态='1待检验' where id ='" + id + "'";
                    SQLhelp.ExecuteScalar(sql1, CommandType.Text);

                    string sql20 = "insert into tb_daohuojilu  (工作令号,项目名称,设备名称,名称,供方名称,型号,单位,定位,质监员附件,质监员附件名称,质监员附件类型,到货数量,合格数量,不合格数量,提交人,提交时间,不合格描述,提交类型,实际采购数量,退回原因)select 工作令号,项目名称,设备名称,名称,供方名称,型号,单位,id ,到货审批附件,到货审批附件名称,到货审批附件类型,本次到货验收数量,合格数量,不合格数量,提交人,提交时间,不合格描述,提交类型,实际采购数量,退回原因  from tb_caigouliaodan where id ='" + id + "'";
                    SQLhelp.ExecuteScalar(sql20, CommandType.Text);

                }
                MessageBox.Show("提交成功！");
                this.DialogResult = DialogResult.OK;
                this.Close();

                string id1 = Convert.ToString(this.dt.Rows[0]["id"]);
                string hetonghao = Convert.ToString(this.dt.Rows[0]["合同号"]);
                string gongfangmingcheng = Convert.ToString(this.dt.Rows[0]["供方名称"]);

                string sql13 = "select 到货检验人 from  tb_caigouliaodan  where id='" + id1 + "'";
                string jianyanyuan = Convert.ToString(SQLhelp.ExecuteScalar(sql13, CommandType.Text));

                string sendmessage = yonghu + "  退回了一份" + hetonghao + "\r\n" + gongfangmingcheng + " 的到货验收流程" + "\r\n" +
                  "请检验员" + jianyanyuan + "检验！";
                NetWork3J NetWork3J = new NetWork3J(yonghu, "http://" + MyGlobal.ip + ":81/");
                NetWork3J.sendmessageById(jianyanyuan, sendmessage);
                
            }
           
            else
            {
                MessageBox.Show("请填写退回原因！");
            }
        }
    }
}
