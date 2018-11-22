using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThoughtWorks.QRCode.Codec;

namespace 项目管理系统.仓库
{
    public partial class Frsaomaruku : Office2007Form
    {
        public Frsaomaruku()
        {
            this.EnableGlass = false;//关键,
            InitializeComponent();
            
        }
        public SerialPort sp1 = new SerialPort("COM3", 9600, Parity.None);
        private void Frsaomaruku_Load(object sender, EventArgs e)
        {
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();

            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;

            string dataCode =  "ZTS-108-tn|" +  "南通阿达飒飒|" +  "大师|" +  "21大师";
            Image image;
            string data = dataCode;
            image = qrCodeEncoder.Encode(data, Encoding.UTF8);
            pictureBox1.Size = new Size(400, 400);
            //pictureBox1.Image = image;
            Bitmap newImg;
            newImg = new Bitmap(image.Width+150, image.Height );
            
            Graphics g = Graphics.FromImage(newImg);
            g.Clear(Color.White);
            g.DrawImageUnscaled(image, 0, 0);
            Font font = new Font("黑体", 13, FontStyle.Bold);
            SolidBrush brush = new SolidBrush(Color.Black);
            g.DrawString("171714224", font, brush, image.Width, 0);
            g.DrawString("轴承", font, brush, image.Width, 15);
            g.DrawString("ZG1123", font, brush, image.Width, 30);
            g.DrawString("南通XX公司", font, brush, image.Width, 45);
            g.DrawString("合同号XXX", font, brush, image.Width, 60);
            g.DrawString("工令号", font, brush, image.Width, 75);
            g.DrawString("项目名称", font, brush, image.Width, 90);
            g.DrawString("设备名称", font, brush, image.Width, 105);

            pictureBox1.Image = newImg;
          
            //Font font1 = new Font("宋体", 15, FontStyle.Regular);
            //g.DrawString(stu.StuName, font1, brush, backgroundImg.Width - subWidth, 295);


            //g.DrawImageUnscaled(backgroundImg, 0, 0);//从坐标0，0开始绘制第一张照片
            //g.DrawImageUnscaled(photo, backgroundImg.Width - 160, backgroundImg.Height - 320);//从第一张照片的底端开始绘制小的照片
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            
            string[] sArray = textBoxX1.Text.Split(new char[1] { '|' });
            textBoxX2.Text = sArray[0];
            textBoxX3.Text = sArray[1];
            textBoxX4.Text = sArray[2];
           
        }

        private void Frsaomaruku_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
