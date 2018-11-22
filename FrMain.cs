using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 项目管理系统.市场部;
using 项目管理系统.项目总览;
using 项目管理系统.技术部;
using 项目管理系统.运营管理;
using 项目管理系统.生产部;
using 项目管理系统.物流部;
using 项目管理系统.仓库;
using 项目管理系统.我的任务;
using xiangmuguanli.生产部;
using 项目管理系统.个人管理;
using 项目管理系统.财务部;
using 项目管理系统.档案室;
using 项目管理系统.检验;
using 项目管理系统.模具部;

namespace 项目管理系统
{
    public partial class FrMain : Office2007Form
    {
        public FrMain()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
        }
        public string yonghu;
        AutoSizeFormClass asc = new AutoSizeFormClass();
        private void FrMain_Load(object sender, EventArgs e)
        {
            if (yonghu != "庄卫星" && yonghu != "钱陆亦" && yonghu != "徐魏魏" && yonghu != "蔡红兵" && yonghu != "聂燕")
            {
                expandablePanel10.Visible = false;

            }
            if (yonghu != "钱陆亦")
            {
                buttonItem8.Visible = false;
            }

        }

        private void btnJiedan_Click(object sender, EventArgs e)
        {

            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            string yonghuming = yonghu;
            if (bummen != "市场部")
            {
                if (yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "钱陆亦")
                {
                    pictureBox1.Visible = true;
                    if (this.MdiChildren.Length > 0)
                    {
                        foreach (Form myForm in this.MdiChildren)
                            myForm.Close();
                    }
                    FrJiedan form1 = new FrJiedan();

                    form1.yonghu = yonghu;

                    form1.ShowDialog();

                }
                if (yonghu != "庄卫星" && yonghu != "聂燕" && yonghu != "钱陆亦")
                {
                    MessageBox.Show("非市场部人员无权限建立项目！");
                    return;

                }

            }
            if (bummen == "市场部")
            {
                pictureBox1.Visible = true;
                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }
                FrJiedan form = new FrJiedan();
                form.yonghu = yonghu;
                form.ShowDialog();
            }

        }

        private void FrMain_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void btnXiangmuguanli_Click(object sender, EventArgs e)
        {
            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "市场部")
            {
                if (yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "钱陆亦")
                {
                    pictureBox1.Visible = false;

                    if (this.MdiChildren.Length > 0)
                    {
                        foreach (Form myForm in this.MdiChildren)
                            myForm.Close();
                    }

                    FrXiangmuguanli form1 = new FrXiangmuguanli();
                    form1.MdiParent = this;
                    form1.TopLevel = false;

                    form1.Show();
                    form1.Dock = DockStyle.Fill;

                }
                if (yonghu != "庄卫星" && yonghu != "聂燕" && yonghu != "钱陆亦")
                {
                    MessageBox.Show("非市场部人员无权限管理项目！");

                    return;
                }
            }

            if (bummen == "市场部")
            {
                pictureBox1.Visible = false;

                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }

                FrXiangmuguanli form = new FrXiangmuguanli();
                form.MdiParent = this;
                form.TopLevel = false;

                form.Show();
                form.Dock = DockStyle.Fill;
            }
        }

        private void btnXiangmufenjie_Click(object sender, EventArgs e)
        {
            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "线缆事业部" && bummen != "石英事业部" && bummen != "智能事业部" && bummen != "薄材事业部" && bummen != "新材事业部" && bummen != "研发部")
            {
                if (yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "钱陆亦")
                {
                    pictureBox1.Visible = false;
                    if (this.MdiChildren.Length > 0)
                    {
                        foreach (Form myForm in this.MdiChildren)
                            myForm.Close();
                    }

                    FrXiangmufenjie form = new FrXiangmufenjie();
                    form.MdiParent = this;
                    form.TopLevel = false;
                    form.yonghu = yonghu;
                    form.Show();
                    form.Dock = DockStyle.Fill;
                }
                if (yonghu != "庄卫星" && yonghu != "聂燕" && yonghu != "钱陆亦")
                {
                    MessageBox.Show("非技术部人员无权限打开！");

                    return;
                }
            }
            else
            {
                pictureBox1.Visible = false;
                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }

                FrXiangmufenjie form = new FrXiangmufenjie();
                form.MdiParent = this;
                form.TopLevel = false;
                form.yonghu = yonghu;
                form.Show();
                form.Dock = DockStyle.Fill;
            }
        }

        private void btnShengchanfenjie_Click(object sender, EventArgs e)
        {
            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "精工事业部")
            {
                if (yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "钱陆亦" || yonghu == "吴贞国")
                {
                    pictureBox1.Visible = false;
                    if (this.MdiChildren.Length > 0)
                    {
                        foreach (Form myForm in this.MdiChildren)
                            myForm.Close();
                    }
                    FrShengchanguanli form = new FrShengchanguanli();
                    form.MdiParent = this;
                    form.TopLevel = false;
                    //form.yonghu = yonghu;
                    form.Show();
                    form.Dock = DockStyle.Fill;

                }
                if (yonghu != "庄卫星" && yonghu != "聂燕" && yonghu != "钱陆亦")
                {
                    MessageBox.Show("非生产部人员无权限打开！");

                    return;
                }
            }

            else
            {
                if (yonghu == "袁鹏" || yonghu == "于爱青" || yonghu == "钱陆亦" || yonghu == "徐小明" || yonghu == "徐小玉")
                {
                    pictureBox1.Visible = false;
                    if (this.MdiChildren.Length > 0)
                    {
                        foreach (Form myForm in this.MdiChildren)
                            myForm.Close();
                    }
                    FrShengchanguanli form = new FrShengchanguanli();
                    form.MdiParent = this;
                    form.TopLevel = false;
                    //form.yonghu = yonghu;
                    form.Show();
                    form.Dock = DockStyle.Fill;
                }
                else
                {
                    MessageBox.Show("生产部其他人员无权打开！");
                    return;
                }
            }
        }

        private void btnWuliuguanli_Click(object sender, EventArgs e)
        {

            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "物流部")
            {
                if (yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "钱陆亦")
                {
                    pictureBox1.Visible = false;
                    if (this.MdiChildren.Length > 0)
                    {
                        foreach (Form myForm in this.MdiChildren)
                            myForm.Close();
                    }
                    FrWuliuguanli form = new FrWuliuguanli();
                    form.MdiParent = this;
                    form.TopLevel = false;
                    form.yonghu = yonghu;
                    form.Show();
                    form.Dock = DockStyle.Fill;

                }
                if (yonghu != "庄卫星" && yonghu != "聂燕" && yonghu != "钱陆亦")
                {
                    MessageBox.Show("非物流部人员无权限打开！");

                    return;
                }
            }
            else
            {
                pictureBox1.Visible = false;
                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }
                FrWuliuguanli form = new FrWuliuguanli();
                form.MdiParent = this;
                form.TopLevel = false;
                form.yonghu = yonghu;
                form.Show();
                form.Dock = DockStyle.Fill;
            }
        }

        private void btnXiangmuchaxun_Click_1(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            if (this.MdiChildren.Length > 0)
            {
                foreach (Form myForm in this.MdiChildren)
                    myForm.Close();
            }
            FrZonglan form = new FrZonglan();
            form.MdiParent = this;
            form.TopLevel = false;
            form.yonghu = yonghu;
            form.Show();
            form.Dock = DockStyle.Fill;
        }

        private void btnCangku_Click(object sender, EventArgs e)
        {
            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "仓库")
            {
                if (yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "钱陆亦" || yonghu == "桑甜")
                {
                    pictureBox1.Visible = false;
                    if (this.MdiChildren.Length > 0)
                    {
                        foreach (Form myForm in this.MdiChildren)
                            myForm.Close();
                    }
                    FrCangku form1 = new FrCangku();
                    form1.MdiParent = this;
                    form1.TopLevel = false;
                    form1.yonghu = yonghu;
                    form1.Show();
                    form1.Dock = DockStyle.Fill;

                }
                if (yonghu != "庄卫星" && yonghu != "聂燕" && yonghu != "钱陆亦" || yonghu == "桑甜")
                {
                    MessageBox.Show("非仓库人员无权限打开！");

                    return;
                }

            }
            else
            {
                pictureBox1.Visible = false;
                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }
                FrCangku form = new FrCangku();
                form.MdiParent = this;
                form.TopLevel = false;
                form.yonghu = yonghu;
                form.Show();
                form.Dock = DockStyle.Fill;
            }
        }

        private void btnYonghuguanli_Click_1(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            if (this.MdiChildren.Length > 0)
            {
                foreach (Form myForm in this.MdiChildren)
                    myForm.Close();
            }
            FrYonghuguanli form = new FrYonghuguanli();
            form.MdiParent = this;
            form.TopLevel = false;
            //form.yonghu = yonghu;
            form.Show();
            form.Dock = DockStyle.Fill;
        }

        private void btnJinzhantixing_Click(object sender, EventArgs e)
        {


            pictureBox1.Visible = false;
            if (this.MdiChildren.Length > 0)
            {
                foreach (Form myForm in this.MdiChildren)
                    myForm.Close();
            }
            FrJinzhantixing form = new FrJinzhantixing();
            form.MdiParent = this;
            form.TopLevel = false;
            form.yonghu = yonghu;
            form.Show();
            form.Dock = DockStyle.Fill;


        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "精工事业部")
            {
                if (yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "钱陆亦" || yonghu == "吴贞国")
                {
                    pictureBox1.Visible = false;
                    if (this.MdiChildren.Length > 0)
                    {
                        foreach (Form myForm in this.MdiChildren)
                            myForm.Close();
                    }
                    FrJiagongguanli form = new FrJiagongguanli();
                    form.MdiParent = this;
                    form.TopLevel = false;
                    //form.yonghu = yonghu;
                    form.Show();
                    form.Dock = DockStyle.Fill;

                }
                if (yonghu != "庄卫星" && yonghu != "聂燕" && yonghu != "钱陆亦")
                {
                    MessageBox.Show("非生产部人员无权限打开！");

                    return;
                }
            }

            else
            {
                if (yonghu == "袁鹏" || yonghu == "于爱青" || yonghu == "钱陆亦" || yonghu == "徐小明" || yonghu == "袁天坤" || yonghu == "石炜" || yonghu == "徐小玉")
                {
                    pictureBox1.Visible = false;
                    if (this.MdiChildren.Length > 0)
                    {
                        foreach (Form myForm in this.MdiChildren)
                            myForm.Close();
                    }
                    FrJiagongguanli form = new FrJiagongguanli();
                    form.MdiParent = this;
                    form.TopLevel = false;
                    //form.yonghu = yonghu;
                    form.Show();
                    form.Dock = DockStyle.Fill;
                }
                else
                {
                    MessageBox.Show("生产部其他人员无权打开！");
                    return;
                }
            }

        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {

            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "精工事业部")
            {
                if (yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "钱陆亦" || yonghu == "徐小明" || yonghu == "吴贞国")
                {
                    pictureBox1.Visible = false;
                    if (this.MdiChildren.Length > 0)
                    {
                        foreach (Form myForm in this.MdiChildren)
                            myForm.Close();
                    }
                    FrZhuangpeiguanli form1 = new FrZhuangpeiguanli();
                    form1.MdiParent = this;
                    form1.TopLevel = false;
                    form1.yonghu = yonghu;
                    form1.Show();
                    form1.Dock = DockStyle.Fill;

                }
                if (yonghu != "庄卫星" && yonghu != "聂燕" && yonghu != "钱陆亦")
                {
                    MessageBox.Show("非生产部人员无权限打开！");

                    return;
                }

            }

            else
            {

                pictureBox1.Visible = false;
                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }
                FrZhuangpeiguanli form = new FrZhuangpeiguanli();
                form.MdiParent = this;
                form.TopLevel = false;
                form.yonghu = yonghu;
                form.Show();
                form.Dock = DockStyle.Fill;
            }
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "线缆事业部" && bummen != "石英事业部" && bummen != "智能事业部" && bummen != "薄材事业部" && bummen != "新材事业部")
            {
                if (yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "钱陆亦")
                {

                    pictureBox1.Visible = false;
                    if (this.MdiChildren.Length > 0)
                    {
                        foreach (Form myForm in this.MdiChildren)
                            myForm.Close();
                    }
                    FrTiaoshiguanli form = new FrTiaoshiguanli();
                    form.MdiParent = this;
                    form.TopLevel = false;
                    form.yonghu = yonghu;

                    form.Show();
                    form.Dock = DockStyle.Fill;
                }
                if (yonghu != "庄卫星" && yonghu != "聂燕" && yonghu != "钱陆亦")
                {
                    MessageBox.Show("非技术部人员无权限打开！");

                    return;
                }


            }
            else
            {

                pictureBox1.Visible = false;
                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }
                FrTiaoshiguanli form = new FrTiaoshiguanli();
                form.MdiParent = this;
                form.TopLevel = false;
                form.yonghu = yonghu;
                //form.yonghu = yonghu;
                form.Show();
                form.Dock = DockStyle.Fill;
            }

        }

        private void btnWuliurenwu_Click(object sender, EventArgs e)
        {
            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "物流部")
            {
                if (yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "钱陆亦")
                {
                    pictureBox1.Visible = false;
                    if (this.MdiChildren.Length > 0)
                    {
                        foreach (Form myForm in this.MdiChildren)
                            myForm.Close();
                    }
                    FrWuliurenwu form = new FrWuliurenwu();
                    form.MdiParent = this;
                    form.TopLevel = false;
                    form.yonghu = yonghu;
                    form.Show();
                    form.Dock = DockStyle.Fill;

                }
                if (yonghu != "庄卫星" && yonghu != "聂燕" && yonghu != "钱陆亦")
                {
                    MessageBox.Show("非物流部人员无权限打开！");

                    return;
                }
            }
            else
            {
                pictureBox1.Visible = false;
                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }
                FrWuliurenwu form = new FrWuliurenwu();
                form.MdiParent = this;
                form.TopLevel = false;
                form.yonghu = yonghu;
                form.Show();
                form.Dock = DockStyle.Fill;
            }

        }

        private void btnJianyan_Click(object sender, EventArgs e)
        {
            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "质监部")
            {
                if (yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "钱陆亦")
                {
                    pictureBox1.Visible = false;
                    if (this.MdiChildren.Length > 0)
                    {
                        foreach (Form myForm in this.MdiChildren)
                            myForm.Close();
                    }
                    FrJianyan form = new FrJianyan();
                    form.MdiParent = this;
                    form.TopLevel = false;
                    form.yonghu = yonghu;
                    form.Show();
                    form.Dock = DockStyle.Fill;

                }
                if (yonghu != "庄卫星" && yonghu != "聂燕" && yonghu != "钱陆亦")
                {
                    MessageBox.Show("非质监部无权限打开！");

                    return;
                }
            }
            else
            {
                pictureBox1.Visible = false;
                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }
                FrJianyan form = new FrJianyan();
                form.MdiParent = this;
                form.TopLevel = false;
                form.yonghu = yonghu;
                form.Show();
                form.Dock = DockStyle.Fill;
            }
        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "物流部")
            {
                if (yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "钱陆亦")
                {
                    pictureBox1.Visible = false;
                    if (this.MdiChildren.Length > 0)
                    {
                        foreach (Form myForm in this.MdiChildren)
                            myForm.Close();
                    }
                    FrWuliurenwu form = new FrWuliurenwu();
                    form.MdiParent = this;
                    form.TopLevel = false;
                    form.yonghu = yonghu;
                    form.Show();
                    form.Dock = DockStyle.Fill;

                }
                if (yonghu != "庄卫星" && yonghu != "聂燕" && yonghu != "钱陆亦")
                {
                    MessageBox.Show("非物流部人员无权限打开！");

                    return;
                }
            }
            else
            {
                pictureBox1.Visible = false;
                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }
                FrWuliujianyan form = new FrWuliujianyan();
                form.MdiParent = this;
                form.TopLevel = false;
                form.yonghu = yonghu;
                form.Show();
                form.Dock = DockStyle.Fill;
            }

        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "精工事业部")
            {
                if (yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "钱陆亦" || yonghu == "徐小明" || yonghu == "吴贞国")
                {
                    pictureBox1.Visible = false;
                    if (this.MdiChildren.Length > 0)
                    {
                        foreach (Form myForm in this.MdiChildren)
                            myForm.Close();
                    }
                    FrShengchanbujianyan form1 = new FrShengchanbujianyan();
                    form1.MdiParent = this;
                    form1.TopLevel = false;
                    form1.yonghu = yonghu;
                    form1.Show();
                    form1.Dock = DockStyle.Fill;

                }
                if (yonghu != "庄卫星" && yonghu != "聂燕" && yonghu != "钱陆亦")
                {
                    MessageBox.Show("非生产部人员无权限打开！");

                    return;
                }

            }

            else
            {

                pictureBox1.Visible = false;
                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }
                FrShengchanbujianyan form = new FrShengchanbujianyan();
                form.MdiParent = this;
                form.TopLevel = false;
                form.yonghu = yonghu;
                form.Show();
                form.Dock = DockStyle.Fill;
            }
        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "线缆事业部" && bummen != "石英事业部" && bummen != "智能事业部" && bummen != "薄材事业部" && bummen != "新材事业部")
            {
                if (yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "钱陆亦")
                {
                    pictureBox1.Visible = false;
                    if (this.MdiChildren.Length > 0)
                    {
                        foreach (Form myForm in this.MdiChildren)
                            myForm.Close();
                    }

                    FrXiangmufenjie form = new FrXiangmufenjie();
                    form.MdiParent = this;
                    form.TopLevel = false;
                    form.yonghu = yonghu;
                    form.Show();
                    form.Dock = DockStyle.Fill;
                }
                if (yonghu != "庄卫星" && yonghu != "聂燕" && yonghu != "钱陆亦")
                {
                    MessageBox.Show("非技术部人员无权限打开！");

                    return;
                }
            }
            else
            {
                pictureBox1.Visible = false;
                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }

                FrJishubujianyan form = new FrJishubujianyan();
                form.MdiParent = this;
                form.TopLevel = false;
                form.yonghu = yonghu;
                form.Show();
                form.Dock = DockStyle.Fill;
            }
        }

        private void buttonItem7_Click(object sender, EventArgs e)
        {
            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "精工事业部")
            {
                if (yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "钱陆亦" || yonghu == "徐小明" || yonghu == "吴贞国")
                {
                    pictureBox1.Visible = false;
                    if (this.MdiChildren.Length > 0)
                    {
                        foreach (Form myForm in this.MdiChildren)
                            myForm.Close();
                    }
                    FrFahuoqueren form1 = new FrFahuoqueren();
                    form1.MdiParent = this;
                    form1.TopLevel = false;
                    //form.yonghu = yonghu;
                    form1.Show();
                    form1.Dock = DockStyle.Fill;

                }
                if (yonghu != "庄卫星" && yonghu != "聂燕" && yonghu != "钱陆亦")
                {
                    MessageBox.Show("非生产部人员无权限打开！");
                    return;
                }

            }

            else
            {
                pictureBox1.Visible = false;
                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }
                FrFahuoqueren form = new FrFahuoqueren();
                form.MdiParent = this;
                form.TopLevel = false;
                form.yonghu = yonghu;
                form.Show();
                form.Dock = DockStyle.Fill;
            }
        }

        private void buttonItem8_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            if (this.MdiChildren.Length > 0)
            {
                foreach (Form myForm in this.MdiChildren)
                    myForm.Close();
            }
            FrHoutai form1 = new FrHoutai();
            form1.MdiParent = this;
            form1.TopLevel = false;
            //form.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
        }

        private void buttonItem9_Click(object sender, EventArgs e)
        {
            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "精工事业部")
            {
                if (yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "钱陆亦" || yonghu == "徐小明" || yonghu == "吴贞国")
                {
                    pictureBox1.Visible = false;
                    if (this.MdiChildren.Length > 0)
                    {
                        foreach (Form myForm in this.MdiChildren)
                            myForm.Close();
                    }
                    FrJixiuyewu form = new FrJixiuyewu();
                    form.MdiParent = this;
                    form.TopLevel = false;
                    //form.yonghu = yonghu;
                    form.Show();
                    form.Dock = DockStyle.Fill;

                }
                if (yonghu != "庄卫星" && yonghu != "聂燕" && yonghu != "钱陆亦")
                {
                    MessageBox.Show("非生产部人员无权限打开！");

                    return;
                }
            }

            else
            {
                pictureBox1.Visible = false;
                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }
                FrJixiuyewu form = new FrJixiuyewu();
                form.MdiParent = this;
                form.TopLevel = false;
                //form.yonghu = yonghu;
                form.Show();
                form.Dock = DockStyle.Fill;
            }
        }

        private void buttonItem10_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem10_Click_1(object sender, EventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "1")
            {                
                 MessageBox.Show("非生产部人员无权限打开！");
                    return;                
            }

            else
            {
                pictureBox1.Visible = false;
                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }

                Frjinggongxiangmu1 form = new Frjinggongxiangmu1();
                form.MdiParent = this;
                form.TopLevel = false;

                form.Show();
                form.Dock = DockStyle.Fill;
            }
        }

        private void buttonItem11_Click(object sender, EventArgs e)
        {

            if (yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "徐魏魏" || yonghu == "桑甜" || yonghu == "王冬梅" || yonghu == "赵蕾蕾" || yonghu == "戴丽丽" || yonghu == "江雯雯" || yonghu == "蔡红兵" || yonghu == "唐一鸣" || yonghu == "钱陆亦" || yonghu == "韩小建" || yonghu == "林先宏")
            {
                pictureBox1.Visible = false;
                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }
                FrMujvbuxiangmu form = new FrMujvbuxiangmu();
                form.MdiParent = this;
                form.TopLevel = false;
                form.Show();
                form.Dock = DockStyle.Fill;

            }
            else
            {
                MessageBox.Show("非相关人员无法打开！");

                return;
            }
        }

        private void buttonItem12_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            if (this.MdiChildren.Length > 0)
            {
                foreach (Form myForm in this.MdiChildren)
                    myForm.Close();
            }
            Frtuzhishenhe form = new Frtuzhishenhe();
            form.MdiParent = this;
            form.TopLevel = false;
            form.yonghu = yonghu;
            form.Show();
            form.Dock = DockStyle.Fill;
        }

        private void buttonItem13_Click(object sender, EventArgs e)
        {
            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "精工事业部")
            {
                if (yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "钱陆亦" || yonghu == "吴贞国")
                {
                    pictureBox1.Visible = false;
                    if (this.MdiChildren.Length > 0)
                    {
                        foreach (Form myForm in this.MdiChildren)
                            myForm.Close();
                    }
                    Frwujinfucai form = new Frwujinfucai();
                    form.MdiParent = this;
                    form.TopLevel = false;
                    form.yonghu = yonghu;
                    form.Show();
                    form.Dock = DockStyle.Fill;

                }
                if (yonghu != "庄卫星" && yonghu != "聂燕" && yonghu != "钱陆亦")
                {
                    MessageBox.Show("非生产部人员无权限打开！");

                    return;
                }
            }

            else
            {
                if (yonghu == "袁鹏" || yonghu == "于爱青" || yonghu == "钱陆亦" || yonghu == "徐小明" || yonghu == "石炜" || yonghu == "王兆平" || yonghu == "袁天坤" || yonghu == "石炜" || yonghu == "黄霞" || yonghu == "徐小玉")
                {
                    pictureBox1.Visible = false;
                    if (this.MdiChildren.Length > 0)
                    {
                        foreach (Form myForm in this.MdiChildren)
                            myForm.Close();
                    }
                    Frwujinfucai form = new Frwujinfucai();
                    form.MdiParent = this;
                    form.TopLevel = false;
                    form.yonghu = yonghu;
                    form.Show();
                    form.Dock = DockStyle.Fill;
                }
                else
                {
                    MessageBox.Show("生产部其他人员无权打开！");
                    return;
                }
            }
        }

        private void buttonItem15_Click(object sender, EventArgs e)
        {
            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "物流部")
            {
                if (yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "钱陆亦")
                {
                    pictureBox1.Visible = false;
                    if (this.MdiChildren.Length > 0)
                    {
                        foreach (Form myForm in this.MdiChildren)
                            myForm.Close();
                    }
                    Frjixiuxiangmu form = new Frjixiuxiangmu();
                    form.MdiParent = this;
                    form.TopLevel = false;
                    form.yonghu = yonghu;
                    form.Show();
                    form.Dock = DockStyle.Fill;

                }
                if (yonghu != "庄卫星" && yonghu != "聂燕" && yonghu != "钱陆亦")
                {
                    MessageBox.Show("非物流部人员无权限打开！");

                    return;
                }
            }
            else
            {
                pictureBox1.Visible = false;
                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }
                Frjixiuxiangmu form = new Frjixiuxiangmu();
                form.MdiParent = this;
                form.TopLevel = false;
                form.yonghu = yonghu;
                form.Show();
                form.Dock = DockStyle.Fill;
            }

        }

        private void buttonItem14_Click(object sender, EventArgs e)
        {
            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "物流部")
            {
                if (yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "钱陆亦")
                {
                    pictureBox1.Visible = false;
                    if (this.MdiChildren.Length > 0)
                    {
                        foreach (Form myForm in this.MdiChildren)
                            myForm.Close();
                    }
                    Frwuliuwujinfucai form = new Frwuliuwujinfucai();
                    form.MdiParent = this;
                    form.TopLevel = false;
                    form.yonghu = yonghu;
                    form.Show();
                    form.Dock = DockStyle.Fill;

                }
                if (yonghu != "庄卫星" && yonghu != "聂燕" && yonghu != "钱陆亦")
                {
                    MessageBox.Show("非物流部人员无权限打开！");

                    return;
                }
            }
            else
            {
                pictureBox1.Visible = false;
                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }
                Frwuliuwujinfucai form = new Frwuliuwujinfucai();
                form.MdiParent = this;
                form.TopLevel = false;
                form.yonghu = yonghu;
                form.Show();
                form.Dock = DockStyle.Fill;
            }
        }

        private void buttonItem16_Click(object sender, EventArgs e)
        {
            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "物流部")
            {
                if (yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "钱陆亦")
                {
                    pictureBox1.Visible = false;
                    if (this.MdiChildren.Length > 0)
                    {
                        foreach (Form myForm in this.MdiChildren)
                            myForm.Close();
                    }
                    Frmujvbucaigou form = new Frmujvbucaigou();
                    form.MdiParent = this;
                    form.TopLevel = false;
                    form.yonghu = yonghu;
                    form.Show();
                    form.Dock = DockStyle.Fill;

                }
                if (yonghu != "庄卫星" && yonghu != "聂燕" && yonghu != "钱陆亦")
                {
                    MessageBox.Show("非物流部人员无权限打开！");

                    return;
                }
            }
            else
            {
                pictureBox1.Visible = false;
                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }
                Frmujvbucaigou form = new Frmujvbucaigou();
                form.MdiParent = this;
                form.TopLevel = false;
                form.yonghu = yonghu;
                form.Show();
                form.Dock = DockStyle.Fill;
            }
        }

        private void buttonItem18_Click(object sender, EventArgs e)
        {
            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "仓库")
            {
                if (yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "钱陆亦" || yonghu == "桑甜")
                {
                   
                    if (this.MdiChildren.Length > 0)
                    {
                        foreach (Form myForm in this.MdiChildren)
                            myForm.Close();
                    }
                    Frsaomadengji form1 = new Frsaomadengji();
                 
                    form1.yonghu = yonghu;
                    form1.Show();
                  

                }
                if (yonghu != "庄卫星" && yonghu != "聂燕" && yonghu != "钱陆亦" || yonghu == "桑甜")
                {
                    MessageBox.Show("非仓库人员无权限打开！");

                    return;
                }

            }
            else
            {
                
                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }
                Frsaomadengji form = new Frsaomadengji();               
                form.yonghu = yonghu;
                form.Show();
             
            }
          
        }

        private void buttonItem19_Click(object sender, EventArgs e)
        {
            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "物流部")
            {
                if (yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "钱陆亦")
                {
                    pictureBox1.Visible = false;
                    if (this.MdiChildren.Length > 0)
                    {
                        foreach (Form myForm in this.MdiChildren)
                            myForm.Close();
                    }
                    Frjixiebiaozhun form = new Frjixiebiaozhun();
                    form.MdiParent = this;
                    form.TopLevel = false;
                    form.yonghu = yonghu;
                    form.Show();
                    form.Dock = DockStyle.Fill;

                }
                if (yonghu != "庄卫星" && yonghu != "聂燕" && yonghu != "钱陆亦")
                {
                    MessageBox.Show("非物流部人员无权限打开！");

                    return;
                }
            }
            else
            {
                pictureBox1.Visible = false;
                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }
                Frjixiebiaozhun form = new Frjixiebiaozhun();
                form.MdiParent = this;
                form.TopLevel = false;
                form.yonghu = yonghu;
                form.Show();
                form.Dock = DockStyle.Fill;
            }
        }

        private void buttonItem17_Click(object sender, EventArgs e)
        {
            if (yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "徐魏魏" || yonghu == "桑甜" || yonghu == "王冬梅" || yonghu == "赵蕾蕾" || yonghu == "戴丽丽" || yonghu == "江雯雯" || yonghu == "蔡红兵" || yonghu == "唐一鸣" || yonghu == "钱陆亦" || yonghu == "韩小建" || yonghu == "林先宏")
            {
                pictureBox1.Visible = false;
                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }
                Frwujinfucaixiangmu form = new Frwujinfucaixiangmu();
                form.MdiParent = this;
                form.TopLevel = false;

                form.Show();
                form.Dock = DockStyle.Fill;

            }
            else
            {
                MessageBox.Show("非相关人员无法打开！");

                return;
            }
        }

        private void buttonItem21_Click(object sender, EventArgs e)
        {
            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "精工事业部")
            {
                if (yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "钱陆亦" || yonghu == "徐小明" || yonghu == "吴贞国")
                {
                    pictureBox1.Visible = false;
                    if (this.MdiChildren.Length > 0)
                    {
                        foreach (Form myForm in this.MdiChildren)
                            myForm.Close();
                    }
                    Frgongxuwaixie form = new Frgongxuwaixie();
                    form.MdiParent = this;
                    form.TopLevel = false;
                    //form.yonghu = yonghu;
                    form.Show();
                    form.Dock = DockStyle.Fill;

                }
                if (yonghu != "庄卫星" && yonghu != "聂燕" && yonghu != "钱陆亦")
                {
                    MessageBox.Show("非生产部人员无权限打开！");

                    return;
                }
            }

            else
            {
                pictureBox1.Visible = false;
                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }
                Frgongxuwaixie form = new Frgongxuwaixie();
                form.MdiParent = this;
                form.TopLevel = false;

                form.Show();
                form.Dock = DockStyle.Fill;
            }
        }

        private void buttonItem22_Click(object sender, EventArgs e)
        {

            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "物流部")
            {
                if (yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "钱陆亦")
                {
                    pictureBox1.Visible = false;
                    if (this.MdiChildren.Length > 0)
                    {
                        foreach (Form myForm in this.MdiChildren)
                            myForm.Close();
                    }
                    Frgognxuwaixieshenqing form = new Frgognxuwaixieshenqing();
                    form.MdiParent = this;
                    form.TopLevel = false;
                    //form.yonghu = yonghu;
                    form.Show();
                    form.Dock = DockStyle.Fill;

                }
                if (yonghu != "庄卫星" && yonghu != "聂燕" && yonghu != "钱陆亦")
                {
                    MessageBox.Show("非物流部人员无权限打开！");

                    return;
                }
            }
            else
            {
                pictureBox1.Visible = false;
                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }
                Frgognxuwaixieshenqing form = new Frgognxuwaixieshenqing();
                form.MdiParent = this;
                form.TopLevel = false;
                //form.yonghu = yonghu;
                form.Show();
                form.Dock = DockStyle.Fill;
            }
        }

        private void buttonItem23_Click(object sender, EventArgs e)
        {

            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "精工事业部")
            {
                if (yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "钱陆亦" || yonghu == "徐小明" || yonghu == "吴贞国")
                {
                    pictureBox1.Visible = false;
                    if (this.MdiChildren.Length > 0)
                    {
                        foreach (Form myForm in this.MdiChildren)
                            myForm.Close();
                    }
                    Frjishugenggai form = new Frjishugenggai();
                    form.MdiParent = this;
                    form.TopLevel = false;
                    //form.yonghu = yonghu;
                    form.Show();
                    form.Dock = DockStyle.Fill;

                }
                if (yonghu != "庄卫星" && yonghu != "聂燕" && yonghu != "钱陆亦")
                {
                    MessageBox.Show("非生产部人员无权限打开！");

                    return;
                }
            }

            else
            {
                pictureBox1.Visible = false;
                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }
                Frjishugenggai form = new Frjishugenggai();
                form.MdiParent = this;
                form.TopLevel = false;

                form.Show();
                form.Dock = DockStyle.Fill;
            }
        }

        private void buttonItem24_Click(object sender, EventArgs e)
        {
            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "精工事业部")
            {
                if (yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "徐魏魏" || yonghu == "桑甜" || yonghu == "王冬梅" || yonghu == "赵蕾蕾" || yonghu == "戴丽丽" || yonghu == "江雯雯" || yonghu == "蔡红兵" || yonghu == "唐一鸣" || yonghu == "钱陆亦" || yonghu == "韩小建")
                {
                    pictureBox1.Visible = false;
                    if (this.MdiChildren.Length > 0)
                    {
                        foreach (Form myForm in this.MdiChildren)
                            myForm.Close();
                    }
                    Frrukuchaxun form = new Frrukuchaxun();
                    form.MdiParent = this;
                    form.TopLevel = false;
                    //form.yonghu = yonghu;
                    form.Show();
                    form.Dock = DockStyle.Fill;

                }
                else
                {
                    MessageBox.Show("非生产部人员无权限打开！");

                    return;
                }
            }

            else
            {
                pictureBox1.Visible = false;
                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }
                Frrukuchaxun form = new Frrukuchaxun();
                form.MdiParent = this;
                form.TopLevel = false;

                form.Show();
                form.Dock = DockStyle.Fill;
            }
        }

        private void buttonItem20_Click(object sender, EventArgs e)
        {
            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "物流部")
            {
                if (yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "钱陆亦")
                {
                    pictureBox1.Visible = false;
                    if (this.MdiChildren.Length > 0)
                    {
                        foreach (Form myForm in this.MdiChildren)
                            myForm.Close();
                    }
                    Frgongyingshangguanli form = new Frgongyingshangguanli();
                    form.MdiParent = this;
                    form.TopLevel = false;
                    //form.yonghu = yonghu;
                    form.Show();
                    form.Dock = DockStyle.Fill;

                }
                if (yonghu != "庄卫星" && yonghu != "聂燕" && yonghu != "钱陆亦")
                {
                    MessageBox.Show("非物流部人员无权限打开！");

                    return;
                }
            }
            else
            {
                pictureBox1.Visible = false;
                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }
                Frgongyingshangguanli form = new Frgongyingshangguanli();
                form.MdiParent = this;
                form.TopLevel = false;
                //form.yonghu = yonghu;
                form.Show();
                form.Dock = DockStyle.Fill;
            }

        }

        private void buttonItem25_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            if (this.MdiChildren.Length > 0)
            {
                foreach (Form myForm in this.MdiChildren)
                    myForm.Close();
            }
            if (yonghu == "徐魏魏" || yonghu == "蔡红兵")
            {
               Frjishubushenhe form = new Frjishubushenhe();
                form.MdiParent = this;
                form.TopLevel = false;
                
                form.Show();
                form.Dock = DockStyle.Fill;
            }
            if (yonghu != "徐魏魏" && yonghu != "蔡红兵")
            {
                MessageBox.Show("无权限打开！");
            }
        }

        private void buttonItem26_Click(object sender, EventArgs e)
        {
            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "线缆事业部" && bummen != "石英事业部" && bummen != "智能事业部" && bummen != "薄材事业部" && bummen != "新材事业部")
            {
                if (yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "钱陆亦")
                {
                    pictureBox1.Visible = false;
                    if (this.MdiChildren.Length > 0)
                    {
                        foreach (Form myForm in this.MdiChildren)
                            myForm.Close();
                    }

                   Frliaodangenggai form = new Frliaodangenggai();
                    form.MdiParent = this;
                    form.TopLevel = false;
                    form.yonghu = yonghu;
                    form.Show();
                    form.Dock = DockStyle.Fill;
                }
                if (yonghu != "庄卫星" && yonghu != "聂燕" && yonghu != "钱陆亦")
                {
                    MessageBox.Show("非技术部人员无权限打开！");

                    return;
                }
            }
            else
            {
                pictureBox1.Visible = false;
                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }

                Frliaodangenggai form = new Frliaodangenggai();
                form.MdiParent = this;
                form.TopLevel = false;
                form.yonghu = yonghu;
                form.Show();
                form.Dock = DockStyle.Fill;
            }
        }

        private void buttonItem27_Click(object sender, EventArgs e)
        {
           
                if (yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "钱陆亦"||yonghu== "王军花")
                {
                    pictureBox1.Visible = false;
                    if (this.MdiChildren.Length > 0)
                    {
                        foreach (Form myForm in this.MdiChildren)
                            myForm.Close();
                    }
                    Frwuliuzonglan form = new Frwuliuzonglan();
                    form.MdiParent = this;
                    form.TopLevel = false;
                    form.yonghu = yonghu;
                    form.Show();
                    form.Dock = DockStyle.Fill;

                }
                if (yonghu != "庄卫星" && yonghu != "聂燕" && yonghu != "钱陆亦" || yonghu == "王军花")
                {
                    MessageBox.Show("非上级领导无权限打开！");

                    return;
                }
            
           

        }

        private void buttonItem28_Click(object sender, EventArgs e)
        {
            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "市场部")
            {
                if (yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "钱陆亦")
                {
                    pictureBox1.Visible = false;

                    if (this.MdiChildren.Length > 0)
                    {
                        foreach (Form myForm in this.MdiChildren)
                            myForm.Close();
                    }

                    Frshichangjixiujian form1 = new Frshichangjixiujian();
                    form1.MdiParent = this;
                    form1.TopLevel = false;

                    form1.Show();
                    form1.Dock = DockStyle.Fill;

                }
                if (yonghu != "庄卫星" && yonghu != "聂燕" && yonghu != "钱陆亦")
                {
                    MessageBox.Show("非市场部人员无权限管理项目！");

                    return;
                }
            }

            if (bummen == "市场部")
            {
                pictureBox1.Visible = false;

                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }

                Frshichangjixiujian form = new Frshichangjixiujian();
                form.MdiParent = this;
                form.TopLevel = false;

                form.Show();
                form.Dock = DockStyle.Fill;
            }
        }

        private void buttonItem29_Click(object sender, EventArgs e)
        {

            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "精工事业部")
            {
                if (yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "钱陆亦" || yonghu == "徐小明" || yonghu == "吴贞国")
                {
                    pictureBox1.Visible = false;
                    if (this.MdiChildren.Length > 0)
                    {
                        foreach (Form myForm in this.MdiChildren)
                            myForm.Close();
                    }
                    Frbeiliao form = new Frbeiliao();
                    form.MdiParent = this;
                    form.TopLevel = false;
                    form.yonghu = yonghu;
                    form.Show();
                    form.Dock = DockStyle.Fill;

                }
                if (yonghu != "庄卫星" && yonghu != "聂燕" && yonghu != "钱陆亦")
                {
                    MessageBox.Show("非生产部人员无权限打开！");

                    return;
                }
            }

            else
            {
                pictureBox1.Visible = false;
                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }
                Frbeiliao form = new Frbeiliao();
                form.MdiParent = this;
                form.TopLevel = false;
                form.yonghu = yonghu;
                form.Show();
                form.Dock = DockStyle.Fill;
            }
        }

        private void buttonItem31_Click(object sender, EventArgs e)
        {
            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "精工事业部")
            {
                if (yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "钱陆亦" || yonghu == "吴贞国")
                {
                    pictureBox1.Visible = false;
                    if (this.MdiChildren.Length > 0)
                    {
                        foreach (Form myForm in this.MdiChildren)
                            myForm.Close();
                    }
                    Frpaichanjihua form = new Frpaichanjihua();
                    form.MdiParent = this;
                    form.TopLevel = false;
                    //form.yonghu = yonghu;
                    form.Show();
                    form.Dock = DockStyle.Fill;

                }
                if (yonghu != "庄卫星" && yonghu != "聂燕" && yonghu != "钱陆亦")
                {
                    MessageBox.Show("非生产部人员无权限打开！");

                    return;
                }
            }

            else
            {
                if (yonghu == "袁鹏" || yonghu == "于爱青" || yonghu == "钱陆亦" || yonghu == "徐小明" || yonghu == "徐小玉")
                {
                    pictureBox1.Visible = false;
                    if (this.MdiChildren.Length > 0)
                    {
                        foreach (Form myForm in this.MdiChildren)
                            myForm.Close();
                    }
                    Frpaichanjihua form = new Frpaichanjihua();
                    form.MdiParent = this;
                    form.TopLevel = false;
                    //form.yonghu = yonghu;
                    form.Show();
                    form.Dock = DockStyle.Fill;
                }
                else
                {
                    MessageBox.Show("生产部其他人员无权打开！");
                    return;
                }
            }
        }

        private void buttonItem30_Click(object sender, EventArgs e)
        {
            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "精工事业部")
            {
                if (yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "徐魏魏" || yonghu == "桑甜" || yonghu == "王冬梅" || yonghu == "赵蕾蕾" || yonghu == "戴丽丽" || yonghu == "江雯雯" || yonghu == "蔡红兵" || yonghu == "唐一鸣" || yonghu == "钱陆亦" || yonghu == "韩小建")
                {
                    pictureBox1.Visible = false;
                    if (this.MdiChildren.Length > 0)
                    {
                        foreach (Form myForm in this.MdiChildren)
                            myForm.Close();
                    }
                    Frmujvbu form = new Frmujvbu();
                    form.MdiParent = this;
                    form.TopLevel = false;
                    //form.yonghu = yonghu;
                    form.Show();
                    form.Dock = DockStyle.Fill;

                }
                else
                {
                    MessageBox.Show("非生产部人员无权限打开！");

                    return;
                }
            }

            else
            {
                pictureBox1.Visible = false;
                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }
                Frmujvbu form = new Frmujvbu();
                form.MdiParent = this;
                form.TopLevel = false;

                form.Show();
                form.Dock = DockStyle.Fill;
            }
        }

        private void buttonItem33_Click(object sender, EventArgs e)
        {

            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "仓库")
            {
                if (yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "钱陆亦" || yonghu == "桑甜")
                {

                    if (this.MdiChildren.Length > 0)
                    {
                        foreach (Form myForm in this.MdiChildren)
                            myForm.Close();
                    }
                    Frsaomachuku form1 = new Frsaomachuku();

                    form1.yonghu = yonghu;
                    form1.Show();


                }
                if (yonghu != "庄卫星" && yonghu != "聂燕" && yonghu != "钱陆亦" || yonghu == "桑甜")
                {
                    MessageBox.Show("非仓库人员无权限打开！");

                    return;
                }

            }
            else
            {

                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }
                Frsaomachuku form = new Frsaomachuku();
                form.yonghu = yonghu;
                form.Show();

            }

        }

        private void buttonItem34_Click(object sender, EventArgs e)
        {
            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen == "办公室")
            {
                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }
                pictureBox1.Visible = false;
                Frdayin1 form = new Frdayin1();
                form.MdiParent = this;
                form.TopLevel = false;

                form.Show();
                form.Dock = DockStyle.Fill;
              
                

            }
            if (bummen != "办公室")
            {
                MessageBox.Show("非办公室无法打开！");
                return;


            }

        }

        private void buttonItem35_Click(object sender, EventArgs e)
        {
            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "质监部")
            {
                if (yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "钱陆亦")
                {
                    pictureBox1.Visible = false;
                    if (this.MdiChildren.Length > 0)
                    {
                        foreach (Form myForm in this.MdiChildren)
                            myForm.Close();
                    }
                    Frtuzhichaxun form = new Frtuzhichaxun();
                    form.MdiParent = this;
                    form.TopLevel = false;
                    form.yonghu = yonghu;
                    form.Show();
                    form.Dock = DockStyle.Fill;

                }
                if (yonghu != "庄卫星" && yonghu != "聂燕" && yonghu != "钱陆亦")
                {
                    MessageBox.Show("非质监部无权限打开！");

                    return;
                }
            }
            else
            {
                pictureBox1.Visible = false;
                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }
                Frtuzhichaxun form = new Frtuzhichaxun();
                form.MdiParent = this;
                form.TopLevel = false;
                form.yonghu = yonghu;
                form.Show();
                form.Dock = DockStyle.Fill;
            }
        }

        private void buttonItem36_Click(object sender, EventArgs e)
        {

            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "仓库" && bummen != "精工事业部")
            {
                if (yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "钱陆亦" || yonghu == "桑甜")
                {

                    if (this.MdiChildren.Length > 0)
                    {
                        foreach (Form myForm in this.MdiChildren)
                            myForm.Close();
                    }
                    pictureBox1.Visible = false;
                    Frtuzhichaxun form = new Frtuzhichaxun();
                    form.MdiParent = this;
                    form.TopLevel = false;
                    form.yonghu = yonghu;
                    form.Show();
                    form.Dock = DockStyle.Fill;


                }
                if (yonghu != "庄卫星" && yonghu != "聂燕" && yonghu != "钱陆亦" || yonghu == "桑甜")
                {
                    MessageBox.Show("非仓库人员无权限打开！");

                    return;
                }

            }
            else
            {

                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }
                pictureBox1.Visible = false;
                Frtuzhichaxun form = new Frtuzhichaxun();
                form.MdiParent = this;
                form.TopLevel = false;
                form.yonghu = yonghu;
                form.Show();
                form.Dock = DockStyle.Fill;

            }
        }

        private void buttonItem32_Click(object sender, EventArgs e)
        {
            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "仓库")
            {
                if (yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "钱陆亦" || yonghu == "桑甜")
                {

                    if (this.MdiChildren.Length > 0)
                    {
                        foreach (Form myForm in this.MdiChildren)
                            myForm.Close();
                    }
                    pictureBox1.Visible = false;
                    Frchurukuchaxun form1 = new Frchurukuchaxun();
                    form1.MdiParent = this;
                    form1.TopLevel = false;
                    form1.yonghu = yonghu;

                    form1.TopLevel = false;

                    form1.Show();
                    form1.Dock = DockStyle.Fill;


                }
                if (yonghu != "庄卫星" && yonghu != "聂燕" && yonghu != "钱陆亦" || yonghu == "桑甜")
                {
                    MessageBox.Show("非仓库人员无权限打开！");

                    return;
                }

            }
            else
            {

                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }
                pictureBox1.Visible = false;
                Frchurukuchaxun form = new Frchurukuchaxun();
                form.MdiParent = this;
                form.TopLevel = false;
                form.yonghu = yonghu;

                form.TopLevel = false;

                form.Show();
                form.Dock = DockStyle.Fill;

            }
        }

        private void buttonItem37_Click(object sender, EventArgs e)
        {
            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "精工事业部")
            {
                if (yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "徐魏魏" || yonghu == "桑甜" || yonghu == "王冬梅" || yonghu == "赵蕾蕾" || yonghu == "戴丽丽" || yonghu == "江雯雯" || yonghu == "蔡红兵" || yonghu == "唐一鸣" || yonghu == "钱陆亦" || yonghu == "韩小建")
                {
                    pictureBox1.Visible = false;
                    if (this.MdiChildren.Length > 0)
                    {
                        foreach (Form myForm in this.MdiChildren)
                            myForm.Close();
                    }
                    Frjixiujianruku form = new Frjixiujianruku();
                    form.MdiParent = this;
                    form.TopLevel = false;
                    //form.yonghu = yonghu;
                    form.Show();
                    form.Dock = DockStyle.Fill;

                }
                else
                {
                    MessageBox.Show("非生产部人员无权限打开！");

                    return;
                }
            }

            else
            {
                pictureBox1.Visible = false;
                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }
                Frjixiujianruku form = new Frjixiujianruku();
                form.MdiParent = this;
                form.TopLevel = false;
                form.Show();
                form.Dock = DockStyle.Fill;
            }
        }

        private void buttonItem38_Click(object sender, EventArgs e)
        {
            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "精工事业部")
            {
                if (yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "徐魏魏" || yonghu == "桑甜" || yonghu == "王冬梅" || yonghu == "赵蕾蕾" || yonghu == "戴丽丽" || yonghu == "江雯雯" || yonghu == "蔡红兵" || yonghu == "唐一鸣" || yonghu == "钱陆亦" || yonghu == "韩小建")
                {
                    pictureBox1.Visible = false;
                    if (this.MdiChildren.Length > 0)
                    {
                        foreach (Form myForm in this.MdiChildren)
                            myForm.Close();
                    }
                    Frjishugenggairuku form = new Frjishugenggairuku();
                    form.MdiParent = this;
                    form.TopLevel = false;
                    //form.yonghu = yonghu;
                    form.Show();
                    form.Dock = DockStyle.Fill;

                }
                else
                {
                    MessageBox.Show("非生产部人员无权限打开！");

                    return;
                }
            }

            else
            {
                pictureBox1.Visible = false;
                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }
                Frjishugenggairuku form = new Frjishugenggairuku();
                form.MdiParent = this;
                form.TopLevel = false;

                form.Show();
                form.Dock = DockStyle.Fill;
            }
        }

        private void buttonItem39_Click(object sender, EventArgs e)
        {
            string sql = "select 部门 from tb_operator1 where 用户名='" + yonghu + "'";
            string bummen = SQLhelp.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "精工事业部")
            {
                if (yonghu == "庄卫星" || yonghu == "聂燕" || yonghu == "徐魏魏" || yonghu == "桑甜" || yonghu == "王冬梅" || yonghu == "赵蕾蕾" || yonghu == "戴丽丽" || yonghu == "江雯雯" || yonghu == "蔡红兵" || yonghu == "唐一鸣" || yonghu == "钱陆亦" || yonghu == "韩小建")
                {
                    pictureBox1.Visible = false;
                    if (this.MdiChildren.Length > 0)
                    {
                        foreach (Form myForm in this.MdiChildren)
                            myForm.Close();
                    }
                    Frmujvzizhijiancs form = new Frmujvzizhijiancs();
                    form.MdiParent = this;
                    form.TopLevel = false;
                    //form.yonghu = yonghu;
                    form.Show();
                    form.Dock = DockStyle.Fill;

                }
                else
                {
                    MessageBox.Show("非生产部人员无权限打开！");

                    return;
                }
            }

            else
            {
                pictureBox1.Visible = false;
                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form myForm in this.MdiChildren)
                        myForm.Close();
                }
                Frmujvzizhijiancs form = new Frmujvzizhijiancs();
                form.MdiParent = this;
                form.TopLevel = false;

                form.Show();
                form.Dock = DockStyle.Fill;
            }
        }

        private void buttonItem40_Click(object sender, EventArgs e)
        {

        }
    }
}
