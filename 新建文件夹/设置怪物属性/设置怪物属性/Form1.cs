using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;

namespace 设置怪物属性
{
    public partial class Form1 : Form
    {
        //配置地址
        //data 怪物文件夹所在位置
        string monsterPath = "D:\\liwenhai\\仙境传说前台WG\\新建文件夹\\data\\sprite\\阁胶磐";
        //修改怪物目录所在位置
        string monsterModifyPath  = "D:\\liwenhai\\仙境传说前台WG\\文件修改\\主动攻击";
        //工具所在位置
        string toolPath = "D:\\liwenhai\\仙境传说前台WG\\rotool";
        //补丁所在位置
        string pachPath = "D:\\仙境传说\\data\\sprite\\阁胶磐";
        ColorPalette palette = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            

        }

        void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            //pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            this.Refresh();
            //pictureBox1.Image.

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            Bitmap MyImage = new Bitmap(openFileDialog1.FileName);
            //pictureBox1.ClientSize = new Size(xSize, ySize);
            pictureBox1.Image = (Image)MyImage;
            MyImage.Dispose();

            pictureBox1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string CurrentDirectory = System.Environment.CurrentDirectory;
            string body_path = openFileDialog1.FileName;

            favoriteImage[] FaImage = new favoriteImage[1];
            if (radioButton1.Checked) {
                FaImage[0].imagePath = CurrentDirectory + "\\Atk.bmp"; 
            }

            if (radioButton2.Checked)
            {
                FaImage[0].imagePath = CurrentDirectory + "\\Fly.bmp";
            }

            if (radioButton3.Checked)
            {
                FaImage[0].imagePath = CurrentDirectory + "\\PicUp.bmp";
            }
            if (radioButton4.Checked)
            {
                FaImage[0].imagePath = CurrentDirectory + "\\Atk1.bmp";
            }
            if (radioButton5.Checked)
            {
                FaImage[0].imagePath = CurrentDirectory + "\\Fly1.bmp";
            }
            

            FaImage[0].x = -3;
            FaImage[0].y = 70;


            
            generateWinterMark(CurrentDirectory, body_path, FaImage);
        }

        public struct favoriteImage
        {
            private string _imagePath;
            private int _x;
            private int _y;

            public int x
            {
                get
                {
                    return _x;
                }
                set
                {
                    _x = value;
                }
            }

            public int y
            {
                get
                {
                    return _y;
                }
                set
                {
                    _y = value;
                }
            }

            public string imagePath
            {
                get
                {
                    return _imagePath;
                }
                set
                {
                    _imagePath = value;
                }
            }
        }

         /// <summary>
        /// 生成水印
        /// </summary>
        /// <param name="Main">主图片路径,eg:body</param>
        /// <param name="Child">要叠加的图片路径</param>
        /// <param name="x">要叠加的图片位置的X坐标</param>
        /// <param name="y">要叠加的图片位置的Y坐标</param>
        /// <param name="isSave"></param>
        /// <returns>生成图片的路径</returns>        
        private  void generateWinterMark(string savePath, string body_path, favoriteImage[] favorite)
        {
            //create a image object containing the photograph to watermark
            Image sourcePhoto = GetFile(body_path);
            Bitmap mm = (Bitmap)sourcePhoto;
            palette = mm.Palette;

            int sourcePhotoWidth = sourcePhoto.Width;
            int sourcePhotoHeight = sourcePhoto.Height;

            //create a Bitmap the Size of the original photograph

            Bitmap newbmPhoto = new Bitmap(sourcePhotoWidth, sourcePhotoHeight, PixelFormat.Format24bppRgb);
 
            //设置此 Bitmap 的分辨率。 
            newbmPhoto.SetResolution(sourcePhoto.HorizontalResolution, sourcePhoto.VerticalResolution);


            Graphics graphicPhoto = Graphics.FromImage(newbmPhoto);

            for (int i = 0; i < favorite.Length; i++)
            {
                graphicPhoto.DrawImage(
                    sourcePhoto,                               // Photo Image object
                    new Rectangle(0, 0, sourcePhotoWidth, sourcePhotoHeight), // Rectangle structure
                    0,                                      // x-coordinate of the portion of the source image to draw. 
                    0,                                      // y-coordinate of the portion of the source image to draw. 
                    sourcePhotoWidth,                                // Width of the portion of the source image to draw. 
                    sourcePhotoHeight,                               // Height of the portion of the source image to draw. 
                    GraphicsUnit.Pixel);                    // Units of measure 
                Image imgWatermark = new Bitmap(favorite[i].imagePath);
   
                int wmWidth = imgWatermark.Width;
                int wmHeight = imgWatermark.Height;


                //Create a Bitmap based on the previously modified photograph Bitmap
                Bitmap bmWatermark = new Bitmap(newbmPhoto);

                Graphics grWatermark = Graphics.FromImage(bmWatermark);

                int xPosOfWm = favorite[i].x;
                int yPosOfWm = favorite[i].y;

                //叠加
                grWatermark.DrawImage(imgWatermark, new Rectangle(5, 5, wmWidth, wmHeight),  //Set the detination Position
                0,                  // x-coordinate of the portion of the source image to draw. 
                0,                  // y-coordinate of the portion of the source image to draw. 
                wmWidth,            // Watermark Width
                wmHeight,		    // Watermark Height
                GraphicsUnit.Pixel, // Unit of measurment
                null);   //ImageAttributes Object

                sourcePhoto = to8pic(bmWatermark); //bmWatermark;//to8pic(bmWatermark); //

                imgWatermark.Dispose();
                bmWatermark.Dispose();
                grWatermark.Dispose();
            }

            string nowTime = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
            nowTime += DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();

            string saveImagePath = savePath + "\\FA" + nowTime + ".bmp";

            sourcePhoto.Save(saveImagePath, ImageFormat.Bmp);
            
            sourcePhoto.Dispose();
            newbmPhoto.Dispose();
            graphicPhoto.Dispose();


            
            pictureBox2.Image = Image.FromFile(saveImagePath);

            if (textBox1.Text.Trim() != "") {
                string path = System.IO.Path.GetDirectoryName(openFileDialog1.FileNames[0]);

                int num = int.Parse(textBox1.Text.Trim());
                for (int i = 0; i < num; i++)
                {
                    string tt = "";
                    if (i < 10)
                    {
                        tt = "00" + i.ToString(); 
                    }
                    if (i < 100&&i>=10)
                    {
                        tt = "0" + i.ToString();
                    }

                    string newFileName = path + "\\" + System.IO.Path.GetFileName(openFileDialog1.FileName).Split('.')[0].Substring(0, System.IO.Path.GetFileName(openFileDialog1.FileName).Split('.')[0].Length - 3) + tt + ".bmp";
                    if (!Directory.Exists(path)) {
                        Directory.CreateDirectory(path);
                    }
                    
                    if(File.Exists(newFileName)){
                        File.Delete(newFileName);                    
                    }
                    File.Copy(saveImagePath, newFileName);        
                }

            }
            
            
            
            // saveImagePath;
        }

        private Bitmap to8pic(Bitmap sourceimage)
        {
            Image image = sourceimage;
            Bitmap bitmap = new Bitmap(image, image.Width, image.Height);

            Bitmap b;
            
            b = bitmap.Clone(new Rectangle(0, 0, bitmap.Width, bitmap.Height), PixelFormat.Format8bppIndexed);

            return b;
        }

        /// <summary>
        /// 24位转8位
        /// </summary>
        /// <param name="bmp24">24位图片</param>
        /// <param name="bmp8">转化后8位图片</param>
        public void Bit24To8(Bitmap bmp24, out Bitmap bmp8)
        {
            BitmapData data24 = bmp24.LockBits(new Rectangle(0, 0, bmp24.Width, bmp24.Height), ImageLockMode.ReadOnly,
                                               PixelFormat.Format24bppRgb);
            bmp8 = new Bitmap(bmp24.Width, bmp24.Height, PixelFormat.Format8bppIndexed);
            BitmapData data8 = bmp8.LockBits(new Rectangle(0, 0, bmp8.Width, bmp8.Height), ImageLockMode.WriteOnly,
                                             PixelFormat.Format8bppIndexed);

            unsafe
            {
                var ptr24 = (byte*)data24.Scan0.ToPointer();
                var ptr8 = (byte*)data8.Scan0.ToPointer();

                for (int i = 0; i < bmp8.Height; i++)
                {
                    for (int j = 0; j < bmp8.Width; j++)
                    {
                        *ptr8++ = (byte)(((*ptr24++) + (*ptr24++) + (*ptr24++)) / 3);
                    }
                    ptr24 += data24.Stride - bmp8.Width * 3;
                    ptr8 += data8.Stride - bmp8.Width;
                }
            }

            bmp8.UnlockBits(data8);
            bmp24.UnlockBits(data24);
        }




        private void openFileDialog1_FileOk_1(object sender, CancelEventArgs e)
        {
            this.Refresh();
            //pictureBox1.Image.

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            //Bitmap MyImage = new Bitmap(openFileDialog1.FileName);
            //pictureBox1.ClientSize = new Size(xSize, ySize);
            pictureBox1.Image = GetFile(openFileDialog1.FileName);


            pictureBox1.Refresh();
            //MyImage.Dispose();
            //pictureBox1.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DirectoryInfo thefolder = new DirectoryInfo(monsterPath);
            
            foreach (FileInfo nextfile in thefolder.GetFiles(textBox2.Text.Trim()+"*.spr"))
            {
                //label1.
                label1.Text = nextfile.FullName;
                return;
               
                //this.listBox1.Items.Add(nextfile.FullName);
            }          

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(label1.Text);  
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start("Explorer.exe", System.IO.Path.GetDirectoryName(openFileDialog1.FileNames[0]));
            
            //openFileDialog2.FileName = openFileDialog1.FileNames[0]+"\\new";
            //openFileDialog2.ShowDialog();
            //Clipboard.SetDataObject(System.IO.Path.GetDirectoryName(openFileDialog1.FileNames[0]));  
        }

        ///
        /// 将文件转为内存流
        ///
        /// 
        /// 
        private MemoryStream ReadFile(string path)
        {
            if (!File.Exists(path))
                return null;

            using (FileStream file = new FileStream(path, FileMode.Open))
            {
                byte[] b = new byte[file.Length];
                file.Read(b, 0, b.Length);

                MemoryStream stream = new MemoryStream(b);
                return stream;
            }
        }

        ///
        /// 将内存流转为图片
        ///
        /// 
        /// 
        private Image GetFile(string path)
        {
            MemoryStream stream = ReadFile(path);
            return stream == null ? null : Image.FromStream(stream);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(monsterModifyPath + "\\" + textBox2.Text))
            {
                Directory.CreateDirectory(monsterModifyPath + "\\" + textBox2.Text);
            }

            if (!Directory.Exists(monsterModifyPath + "\\" + textBox2.Text+"\\原BMP"))
            {
                Directory.CreateDirectory(monsterModifyPath + "\\" + textBox2.Text + "\\原BMP");
            }

            Clipboard.SetDataObject(monsterModifyPath + "\\" + textBox2.Text+"\\原BMP"); 
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(toolPath + "\\rosprtoolkit.exe");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (File.Exists(pachPath+"\\"+textBox3))
            {
                File.Delete(pachPath + "\\" + textBox3);                    
                    }

            if (File.Exists(pachPath + "\\" + textBox3.Text))
            {
                File.Delete(pachPath + "\\" + textBox3.Text);
            }
            File.Copy(monsterModifyPath + "\\" + textBox2.Text + "\\原BMP\\" + textBox3.Text, pachPath + "\\" + textBox3.Text);   
            
        }

        private void button5_Click_1(object sender, EventArgs e)
        {

        }
    }
}
