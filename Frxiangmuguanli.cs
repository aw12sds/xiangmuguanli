using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraTab;
using 项目管理系统.市场部;
using 项目管理系统.项目总览;
using 项目管理系统.技术部;
using xiangmuguanli.生产部;
using 项目管理系统.生产部;
using 项目管理系统.物流部;
using 项目管理系统.仓库;
using 项目管理系统.财务部;
using 项目管理系统.档案室;
using 项目管理系统.我的任务;
using 项目管理系统.个人管理;
using 项目管理系统.检验;
using DevExpress.LookAndFeel;

using 项目管理系统.质监部;
using 项目管理系统.模具;

using 项目管理系统.总经办;
using mujubu.taizhang;
using market;

namespace 项目管理系统
{
    public partial class Frxiangmuguanli : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public string yonghu;
        public Frxiangmuguanli()
        {
            InitializeComponent();
            UserLookAndFeel.Default.UseDefaultLookAndFeel = false;
            UserLookAndFeel.Default.SetSkinStyle("Office 2016 Colorful");
        }

        private void Frxiangmuguanli_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "事业部项目";
            Form2 form1 = new Form2();          
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.yonghu = yonghu;
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;


        }

        private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {
            DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs EArg = (DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs)e;
            string name = EArg.Page.Text;//得到关闭的选项卡的text  
            foreach (XtraTabPage page in xtraTabControl1.TabPages)//遍历得到和关闭的选项卡一样的Text  
            {
                if (page.Text == name)
                {
                    xtraTabControl1.TabPages.Remove(page);
                    page.Dispose();
                    return;
                }
            }
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {
                
                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "机修件项目";
                Frjinggongxiangmu1 form1 = new Frjinggongxiangmu1();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);                
                form1.Show();
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
            
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            //string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            //string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            //if (bummen != "最高权限")
            //{
            //    MessageBox.Show("无权限！");
            //    return;
            //}
            //else
            //{

            //    XtraTabPage newPage = new XtraTabPage();
            //    //newPage.Name = "jixiu";
            //    newPage.Text = "模具部项目";
            //    FrMujvbuxiangmu form1 = new FrMujvbuxiangmu();
            //    form1.TopLevel = false;
            //    newPage.Controls.Add(form1);
            //    form1.Show();
            //    form1.Dock = DockStyle.Fill;
            //    xtraTabControl1.TabPages.Add(newPage);
            //    xtraTabControl1.SelectedTabPage = newPage;
            //}

            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "五金辅材";
                Frwujifucai1 form1 = new Frwujifucai1();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "五金辅材";
                Frwujifucai1 form1 = new Frwujifucai1();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }

        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "市场")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {
                FrJiedan form1 = new FrJiedan();
                form1.yonghu = yonghu;
                form1.ShowDialog();
            }


        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
          
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "市场")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "事业部项目管理";
                Frshichangjixiujian form1 = new Frshichangjixiujian();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);               
                form1.Show();
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }

        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "技术")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "项目分解";
                FrXiangmufenjie form1 = new FrXiangmufenjie();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }

        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "技术")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "料单更改";
                Frliaodangenggai form1 = new Frliaodangenggai();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }

        }

        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "生产")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "生产分解";
                FrShengchanguanli form1 = new FrShengchanguanli();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }

        }

        private void barButtonItem14_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "生产")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "加工管理";
                FrJiagongguanli form1 = new FrJiagongguanli();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        private void barButtonItem15_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "生产")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "装配管理";
                FrZhuangpeiguanli form1 = new FrZhuangpeiguanli();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }

        }

        private void barButtonItem16_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "生产")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "机修业务";
                FrJixiuyewu form1 = new FrJixiuyewu();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                //form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }

        }

        private void barButtonItem17_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "生产")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "五金辅材";
                Frwujinfucai form1 = new Frwujinfucai();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        private void barButtonItem18_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "生产")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "工序外协";
                Frgongxuwaixie form1 = new Frgongxuwaixie();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                //form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        private void barButtonItem19_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "生产")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "技术更改";
                Frjishugenggai form1 = new Frjishugenggai();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                //form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        private void barButtonItem20_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "生产")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "备料";
                Frbeiliao form1 = new Frbeiliao();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }

        }

        private void barButtonItem21_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "生产")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "排产计划";
                Frpaichanjihua form1 = new Frpaichanjihua();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                //form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        private void barButtonItem22_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "物流")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "采购任务";
                FrWuliurenwu form1 = new FrWuliurenwu();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }

        }

        private void barButtonItem24_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "物流")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "五金辅材采购任务";
                Frwuliuwujinfucai form1 = new Frwuliuwujinfucai();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }

        }

        private void barButtonItem27_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "物流")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "工序采购任务";
                Frgognxuwaixieshenqing form1 = new Frgognxuwaixieshenqing();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        private void barButtonItem25_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "物流")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "机修采购任务";
                Frjixiuxiangmu form1 = new Frjixiuxiangmu();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }
      
        private void barButtonItem23_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "物流")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "采购跟踪";
                Frwuliuzonglan form1 = new Frwuliuzonglan();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }

        }

        private void barButtonItem28_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "物流")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "供应商管理";
                Frgongyingshangguanli form1 = new Frgongyingshangguanli();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                //form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        private void barButtonItem29_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "仓库")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                Frsaomadengji form1 = new Frsaomadengji();
                form1.yonghu = yonghu;
                form1.Show();
            }
        }

        private void barButtonItem30_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "仓库")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                Frsaomachuku form = new Frsaomachuku();
                form.yonghu = yonghu;
                form.Show();
            }
        }

        private void barButtonItem31_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem32_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "仓库")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "出入库查询";
                Frchurukuchaxun form1 = new Frchurukuchaxun();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        private void barButtonItem33_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();            
            XtraTabPage newPage = new XtraTabPage();
            //newPage.Name = "jixiu";
            newPage.Text = "零件查询";
            Frtuzhichaxun form1 = new Frtuzhichaxun();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.yonghu = yonghu;
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;

        }

        private void barButtonItem35_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "财务" && bummen != "生产")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "精工零件入库查询";
                Frrukuchaxun form1 = new Frrukuchaxun();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                //form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        private void barButtonItem36_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "财务")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "模具零件入库查询";
                Frmujvbu form1 = new Frmujvbu();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                //form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        private void barButtonItem37_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "财务" && bummen != "生产")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "机修零件入库查询";
                Frjixiujianruku form1 = new Frjixiujianruku();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                //form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        private void barButtonItem38_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "财务")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                
                newPage.Text = "机修零件入库查询";
                Frjishugenggairuku form1 = new Frjishugenggairuku();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
             
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }

        }

        private void barButtonItem39_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "质监")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {
                XtraTabPage newPage = new XtraTabPage();
               
                newPage.Text = "图纸查询";
                Frtuzhichaxun form1 = new Frtuzhichaxun();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }

        }

        private void barButtonItem42_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem44_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void barButtonItem45_ItemClick(object sender, ItemClickEventArgs e)
        {

            XtraTabPage newPage = new XtraTabPage();
            //newPage.Name = "jixiu";
            newPage.Text = "图纸审核";
            Frtuzhishenhe form1 = new Frtuzhishenhe();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.yonghu = yonghu;
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;


        }

        private void barButtonItem46_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem47_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void barButtonItem48_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void barButtonItem49_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void barButtonItem50_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "技术" && bummen != "生产" && bummen != "模具")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {
                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "项目分解";
                FrXiangmufenjie form1 = new FrXiangmufenjie();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        private void barButtonItem51_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "技术" && bummen != "生产" && bummen != "模具")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "料单更改";
                Frliaodangenggai form1 = new Frliaodangenggai();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }

        }

        private void barButtonItem46_ItemClick_1(object sender, ItemClickEventArgs e)
        {
           
      
        }

        private void barButtonItem52_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "技术" && bummen != "生产" && bummen != "模具")
            { 
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "合同料单";
                Frjishubuhetongliaodan form1 = new Frjishubuhetongliaodan();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
               
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        private void barButtonItem53_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 发票匹配 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "1")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();                
                newPage.Text = "发票匹配";
                Frfapiaopipei form1 = new Frfapiaopipei();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        private void barButtonItem56_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "财务")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();

                newPage.Text = "项目零件出库查询";
                Frxiangmuruku form1 = new Frxiangmuruku();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();

                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }
        
        private void barButtonItem58_ItemClick(object sender, ItemClickEventArgs e)
        {
           
            Frerpcreat form1 = new Frerpcreat();
          
            form1.yonghu = yonghu;
            form1.ShowDialog();
          
        }

        private void barButtonItem59_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "物流")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {
               
                    XtraTabPage newPage = new XtraTabPage();
                    //newPage.Name = "jixiu";
                    newPage.Text = "部门采购任务";
                    Frbumencaigou form1 = new Frbumencaigou();
                    form1.TopLevel = false;
                    newPage.Controls.Add(form1);
                    form1.Show();
                    form1.yonghu = yonghu;
                    form1.Dock = DockStyle.Fill;
                    xtraTabControl1.TabPages.Add(newPage);
                    xtraTabControl1.SelectedTabPage = newPage;
                
            }
        }

        private void barButtonItem60_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select ERP生号 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "1")
            {
                MessageBox.Show("无权限!");
                return;
            }
            Frerpcreat form1 = new Frerpcreat();
            form1.yonghu = yonghu;
            form1.Show();
        }
        
        private void barButtonItem63_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            //newPage.Name = "jixiu";
            newPage.Text = "ERP查询";
            Frerpchaxun form1 = new Frerpchaxun();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            //form1.yonghu = yonghu;
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;

        }

        private void barButtonItem64_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "生产")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "工资表统计";
                Frjijiagongtongji form1 = new Frjijiagongtongji();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;

            }
        }

        private void barButtonItem65_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            //newPage.Name = "jixiu";
            newPage.Text = "登录查询";
            Frshiyongjilu form1 = new Frshiyongjilu();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            //form1.yonghu = yonghu;
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;

        }

        private void barButtonItem66_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "财务")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "工资表统计";
                Frjijiagongtongji form1 = new Frjijiagongtongji();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;

            }
        }

        private void barButtonItem67_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "模具")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "模具部台账";
                caigoutaizhang form1= new caigoutaizhang();
                form1.IsMdiContainer = false;
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                form1.FormBorderStyle = FormBorderStyle.None;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;

            }
         
        }

        private void barButtonItem68_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "模具")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "代办项目";
                liucheng form1 = new liucheng();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                form1.FormBorderStyle = FormBorderStyle.None;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;

            }
          
        }

        private void barButtonItem69_ItemClick(object sender, ItemClickEventArgs e)
        {
            //string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            //string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            //if (bummen != "最高权限" && bummen != "模具")
            //{
            //    MessageBox.Show("无权限！");
            //    return;
            //}
            //else
            //{

            //    XtraTabPage newPage = new XtraTabPage();
            //    //newPage.Name = "jixiu";
            //    newPage.Text = "代办项目";
            //    liucheng form1 = new liucheng();
            //    form1.TopLevel = false;
            //    newPage.Controls.Add(form1);
            //    form1.Show();
            //    form1.yonghu = yonghu;
            //    form1.Dock = DockStyle.Fill;
            //    xtraTabControl1.TabPages.Add(newPage);
            //    xtraTabControl1.SelectedTabPage = newPage;

            //}
        }

        private void barButtonItem70_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "物流")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "新版模具采购任务";
               Frxinbanmujvbucaigoucs form1 = new Frxinbanmujvbucaigoucs();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;

            }

        }

        private void barButtonItem72_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void barButtonItem73_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();          
            newPage.Text = "商机项目查询";
            Frshangji form1 = new Frshangji();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();          
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem74_ItemClick(object sender, ItemClickEventArgs e)
        {
          
        }

        private void barButtonItem77_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "物流")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "安全库存采购";
                Franquankucuncaigou form1 = new Franquankucuncaigou();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;

            }

        }

        private void barButtonItem76_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "技术" && bummen != "生产")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "项目分解";
                Franquankucunjishu form1 = new Franquankucunjishu();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                //form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        private void barButtonItem78_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "仓库")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "出库";
                Frchukutongjiji form1 = new Frchukutongjiji();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        private void barButtonItem79_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void barButtonItem80_ItemClick(object sender, ItemClickEventArgs e)
        {
          
        }

        private void barButtonItem82_ItemClick(object sender, ItemClickEventArgs e)
        {
                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "已审批项目";
                FrXiangmuguanli2 form1 = new FrXiangmuguanli2();
                form1.yonghu = yonghu;
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.yonghu = yonghu;
                form1.Show();
                form1.FormBorderStyle = FormBorderStyle.None;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;

        }

        private void barButtonItem83_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frliulanexcel form1 = new Frliulanexcel();
            form1.ShowDialog();
        }

        private void barButtonItem85_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void barButtonItem75_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem86_ItemClick(object sender, ItemClickEventArgs e)
        {
            //XtraTabPage newPage = new XtraTabPage();
            ////newPage.Name = "jixiu";
            //newPage.Text = "到货验收流程";
            //Frdaohuoyanshou form1 = new Frdaohuoyanshou();
            //form1.TopLevel = false;
            //newPage.Controls.Add(form1);
            //form1.Show();
            //form1.FormBorderStyle = FormBorderStyle.None;
            //form1.Dock = DockStyle.Fill;
            //xtraTabControl1.TabPages.Add(newPage);
            //xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem87_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            //newPage.Name = "jixiu";
            newPage.Text = "采购任务";

            料单总表 form1 = new 料单总表();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.yonghu = yonghu;
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem89_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "模具")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                newPage.Text = "模具部日报表";
                Frjijiagongribao form1 = new Frjijiagongribao();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;

            }
        }

        private void barButtonItem71_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem31_ItemClick_1(object sender, ItemClickEventArgs e)
        {

            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "办公室")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {
                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "图纸打印";
                Frdayin1 form1 = new Frdayin1();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                //form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        private void barButtonItem42_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            string sql = "select 物资领用 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "1")
            {
                MessageBox.Show("无权限!");
                return;
            }

            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "物料领用";
            Frwuzilingyong form1 = new Frwuzilingyong(yonghu);
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem55_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem44_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            string sql = "select 物资领用 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "1")
            {
                MessageBox.Show("无权限!");
                return;
            }

            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "物料领用";
            Frwuzilingyong form1 = new Frwuzilingyong(yonghu);
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem46_ItemClick_2(object sender, ItemClickEventArgs e)
        {
            string sql = "select ERP生号 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "1")
            {
                MessageBox.Show("无权限!");
                return;
            }
            Frerpcreat form1 = new Frerpcreat();
            form1.yonghu = yonghu;
            form1.Show();
        }

        private void barButtonItem71_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            string sql = "select ERP生号 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "1")
            {
                MessageBox.Show("无权限!");
                return;
            }
            Frerpcreat form1 = new Frerpcreat();
            form1.yonghu = yonghu;
            form1.Show();
        }

        private void barButtonItem2_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            
        }

        private void barButtonItem4_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "物流")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "到货到票统计";
                Frdaohuodaopiaotongji form1 = new Frdaohuodaopiaotongji();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                //form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        private void barButtonItem88_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (yonghu != "庄卫星" && yonghu != "钱陆亦")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {
                XtraTabPage newPage = new XtraTabPage();
                newPage.Text = "采购料单审核";
                Frcaigoushenghe form1 = new Frcaigoushenghe();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.yonghu = yonghu;
                form1.Show();
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        private void barButtonItem26_ItemClick_1(object sender, ItemClickEventArgs e)
        {
          
            if (yonghu != "聂燕" )
            {
                MessageBox.Show("无权限！");
               return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "制造类型转换审批";
                自制转外协 form1 = new 自制转外协();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                //form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        private void barButtonItem61_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "市场")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {
                Frxiaoshoubaogao form1 = new Frxiaoshoubaogao();
                form1.yonghu = yonghu;
                form1.ShowDialog();
            }
        }


        private void barButtonItem110_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "生产" )
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {
                XtraTabPage newPage = new XtraTabPage();
                newPage.Text = "到货审批";
                Frdaohuoshenpi form2 = new Frdaohuoshenpi();
                form2.TopLevel = false;
                newPage.Controls.Add(form2);
                form2.Show();
                form2.yonghu = yonghu;
                form2.FormBorderStyle = FormBorderStyle.None;
                form2.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        



        private void barButtonItem113_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "市场")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {
                Frxiaoshoubaogao form1 = new Frxiaoshoubaogao();
                form1.yonghu = yonghu;
                form1.ShowDialog();
            }
            
        }

        private void barButtonItem116_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "物流")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {
                XtraTabPage newPage = new XtraTabPage();
                newPage.Text = "发起到货验收";
                Frfaqi form2 = new Frfaqi();
                form2.TopLevel = false;
                newPage.Controls.Add(form2);
                form2.Show();
                form2.yonghu = yonghu;
                form2.FormBorderStyle = FormBorderStyle.None;
                form2.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        private void barButtonItem93_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "模具")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {
                XtraTabPage newPage = new XtraTabPage();
                newPage.Text = "到货审批";
                Frdaohuoshenpi form2 = new Frdaohuoshenpi();
                form2.TopLevel = false;
                newPage.Controls.Add(form2);
                form2.Show();
                form2.yonghu = yonghu;
                form2.FormBorderStyle = FormBorderStyle.None;
                form2.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        private void barButtonItem117_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "质监")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {
                XtraTabPage newPage = new XtraTabPage();
                newPage.Text = "到货质监";
                Frdaohuozhijian form2 = new Frdaohuozhijian();
                form2.TopLevel = false;
                newPage.Controls.Add(form2);
                form2.Show();
                form2.yonghu = yonghu;
                form2.FormBorderStyle = FormBorderStyle.None;
                form2.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        private void barButtonItem118_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (yonghu != "袁鹏" )
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {
                XtraTabPage newPage = new XtraTabPage();
                newPage.Text = "不合格评审";
                Frbuhegepingshen form2 = new Frbuhegepingshen();
                form2.TopLevel = false;
                newPage.Controls.Add(form2);
                form2.Show();
                form2.yonghu = yonghu;
                form2.FormBorderStyle = FormBorderStyle.None;
                form2.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        private void barButtonItem119_ItemClick(object sender, ItemClickEventArgs e)
        {
            
            if (yonghu != "庄卫星")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {
                XtraTabPage newPage = new XtraTabPage();
                newPage.Text = "到货审批";
                Frzongjingbanshenpi form2 = new Frzongjingbanshenpi();
                form2.TopLevel = false;
                newPage.Controls.Add(form2);
                form2.Show();
                form2.yonghu = yonghu;
                form2.FormBorderStyle = FormBorderStyle.None;
                form2.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;

            }
            
        }

        private void barButtonItem120_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (yonghu != "吴贞国")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {
                XtraTabPage newPage = new XtraTabPage();
                newPage.Text = "不合格评审";
                Frbuhegepingshen form2 = new Frbuhegepingshen();
                form2.TopLevel = false;
                newPage.Controls.Add(form2);
                form2.Show();
                form2.yonghu = yonghu;
                form2.FormBorderStyle = FormBorderStyle.None;
                form2.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        private void barButtonItem97_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void barButtonItem97_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            
        }

        private void barButtonItem3_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "项目总览";
            Form2 form2 = new Form2();
            form2.TopLevel = false;
            newPage.Controls.Add(form2);
            form2.Show();
            form2.yonghu = yonghu;
            form2.FormBorderStyle = FormBorderStyle.None;
            form2.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem121_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "系统需求";
            Frxitongxuqiu form2 = new Frxitongxuqiu();
            form2.TopLevel = false;
            newPage.Controls.Add(form2);
            form2.Show();
            form2.yonghu = yonghu;
            form2.FormBorderStyle = FormBorderStyle.None;
            form2.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem97_ItemClick_2(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "物流")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {
                XtraTabPage newPage = new XtraTabPage();
                newPage.Text = "不合格查看";
                Frchakandaohuo form2 = new Frchakandaohuo();
                form2.TopLevel = false;
                newPage.Controls.Add(form2);
                form2.Show();
                form2.yonghu = yonghu;
                form2.FormBorderStyle = FormBorderStyle.None;
                form2.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        private void barButtonItem47_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "市场")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {
                FrJiedan form1 = new FrJiedan();
                form1.yonghu = yonghu;
                form1.ShowDialog();
            }
        }

        private void barButtonItem72_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "市场")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "待立项项目";
                Frdailixiang form1 = new Frdailixiang();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.yonghu = yonghu;
                form1.Show();
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        private void barButtonItem74_ItemClick_1(object sender, ItemClickEventArgs e)
        {

            if (yonghu != "杨天华" && yonghu != "韩小建")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "待立项项目";
                FrmMain form1 = new FrmMain();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                //form1.yonghu = yonghu;
                form1.Show();
                form1.FormBorderStyle = FormBorderStyle.None;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        private void barButtonItem48_ItemClick_1(object sender, ItemClickEventArgs e)
        {

            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "市场")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "事业部项目管理";
                FrXiangmuguanli form1 = new FrXiangmuguanli();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);

                form1.Show();
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }

        }

        private void barButtonItem2_ItemClick_2(object sender, ItemClickEventArgs e)
        {
            string sql = "select ERP生号 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "1")
            {
                MessageBox.Show("无权限!");
                return;
            }
            Frerpcreat form1 = new Frerpcreat();
            form1.yonghu = yonghu;
            form1.Show();
        }

        private void barButtonItem49_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "市场")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {
                XtraTabPage newPage = new XtraTabPage();
                newPage.Text = "机修项目管理";
                Frjixiuxiangmu123 form1 = new Frjixiuxiangmu123();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.yonghu = yonghu;
                form1.Show();
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }

        }

        private void barButtonItem61_ItemClick_1(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem109_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
           
                XtraTabPage newPage = new XtraTabPage();
                newPage.Text = "机修项目管理";
            机修项目审批 form1 = new 机修项目审批("自制",yonghu);
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem96_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();

            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "机修项目管理";
            机修项目审批 form1 = new 机修项目审批("外协",yonghu);
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem61_ItemClick_2(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem88_ItemClick_1(object sender, ItemClickEventArgs e)
        {
           
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem122_ItemClick(object sender, ItemClickEventArgs e)
        {

            if (yonghu != "袁鹏")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "自制外协转换审批";
                自制转外协审批 form1 = new 自制转外协审批();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                //form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        private void barButtonItem124_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (yonghu != "聂燕")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "自制转外协审批";
                自制转外协 form1 = new 自制转外协();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                //form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        private void barButtonItem123_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (yonghu != "袁鹏")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "自制转外协审批";
                自制转外协审批 form1 = new 自制转外协审批();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                //form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        private void barButtonItem125_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "市场")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {
                XtraTabPage newPage = new XtraTabPage();
                newPage.Text = "每日销售报告";
                Frmeirixiaoshou form1 = new Frmeirixiaoshou();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        private void barButtonItem101_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "仓库")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {
                XtraTabPage newPage = new XtraTabPage();
                newPage.Text = "到货审批";
                Frdaohuoqueren form2 = new Frdaohuoqueren();
                form2.TopLevel = false;
                newPage.Controls.Add(form2);
                form2.Show();
                form2.yonghu = yonghu;
                form2.FormBorderStyle = FormBorderStyle.None;
                form2.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        private void barButtonItem126_ItemClick(object sender, ItemClickEventArgs e)
        {
            //string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            //string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            //if (bummen != "最高权限" && bummen != "物流")
            //{
            //    MessageBox.Show("无权限！");
            //    return;
            //}
            //else
            //{
            //    XtraTabPage newPage = new XtraTabPage();
            //    newPage.Text = "查看不合格";
            //    Frbuhege form2 = new Frbuhege();
            //    form2.TopLevel = false;
            //    newPage.Controls.Add(form2);
            //    form2.Show();
            //    form2.yonghu = yonghu;
            //    form2.FormBorderStyle = FormBorderStyle.None;
            //    form2.Dock = DockStyle.Fill;
            //    xtraTabControl1.TabPages.Add(newPage);
            //    xtraTabControl1.SelectedTabPage = newPage;
            //}
        }

        private void barButtonItem104_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem106_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem127_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "财务")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {
                XtraTabPage newPage = new XtraTabPage();
                newPage.Text = "到货审批";
                Frwuliaobiao form2 = new Frwuliaobiao();
                form2.TopLevel = false;
                newPage.Controls.Add(form2);
                form2.Show();
                form2.yonghu = yonghu;
                form2.FormBorderStyle = FormBorderStyle.None;
                form2.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        private void barButtonItem129_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem130_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "自制转外协记录";
            Frzizhizhuanwaixiejilu form2 = new Frzizhizhuanwaixiejilu();
            form2.TopLevel = false;
            newPage.Controls.Add(form2);
            form2.Show();         
            form2.FormBorderStyle = FormBorderStyle.None;
            form2.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem123_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "总经办")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {
                XtraTabPage newPage = new XtraTabPage();
                newPage.Text = "固定资产到货";
                Frgudingzichandaohuo form2 = new Frgudingzichandaohuo();
                form2.TopLevel = false;
                newPage.Controls.Add(form2);
                form2.Show();
                form2.yonghu = yonghu;
                form2.FormBorderStyle = FormBorderStyle.None;
                form2.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        private void barButtonItem85_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "技术" && bummen != "生产" && bummen != "模具")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {
                XtraTabPage newPage = new XtraTabPage();
                newPage.Text = "到货审批";
                Frdaohuoshenpi form2 = new Frdaohuoshenpi();
                form2.TopLevel = false;
                newPage.Controls.Add(form2);
                form2.Show();
                form2.yonghu = yonghu;
                form2.FormBorderStyle = FormBorderStyle.None;
                form2.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        private void barButtonItem62_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "市场")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {
                XtraTabPage newPage = new XtraTabPage();
                newPage.Text = "固定资产到货";
                Frgudingzichandaohuo form2 = new Frgudingzichandaohuo();
                form2.TopLevel = false;
                newPage.Controls.Add(form2);
                form2.Show();
                form2.yonghu = yonghu;
                form2.FormBorderStyle = FormBorderStyle.None;
                form2.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        private void barButtonItem105_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "财务")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {
                XtraTabPage newPage = new XtraTabPage();
                newPage.Text = "固定资产到货";
                Frgudingzichandaohuo form2 = new Frgudingzichandaohuo();
                form2.TopLevel = false;
                newPage.Controls.Add(form2);
                form2.Show();
                form2.yonghu = yonghu;
                form2.FormBorderStyle = FormBorderStyle.None;
                form2.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        private void barButtonItem131_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "物流")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {
                XtraTabPage newPage = new XtraTabPage();
                newPage.Text = "固定资产到货";
                Frgudingzichandaohuo form2 = new Frgudingzichandaohuo();
                form2.TopLevel = false;
                newPage.Controls.Add(form2);
                form2.Show();
                form2.yonghu = yonghu;
                form2.FormBorderStyle = FormBorderStyle.None;
                form2.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }
    }
}