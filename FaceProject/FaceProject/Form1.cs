using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using FaceProject.Models;
using FaceProject.Processing;
using ImageProcessor;
using ImageProcessor.Imaging.Filters.EdgeDetection;
using ImageProcessor.Imaging.Filters.Photo;
using ImageProcessor.Imaging.Formats;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace FaceProject
{
    /// <summary>
    /// Main form to interact with user
    /// </summary>
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        System.Drawing.Image img;
        Bitmap bmp;
        Bitmap newImage;
        bool ProcessStart  = false;
        int maxCount = -1;
        bool panda = false;

        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Button click action to get image form OpenFileDialog 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_getImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    img = System.Drawing.Image.FromFile(dlg.FileName);
                    bmp = AForge.Imaging.Image.FromFile(dlg.FileName);
                    if (dlg.FileName.Contains("panda"))
                    {
                        panda = true;
                    }
                    pb_Before.Image = img;
                    pb_Before.SizeMode = PictureBoxSizeMode.Zoom;
                    maxCount = -1;
                    textBox1.Text = "";
                    ProcessStart = true;
                    metroTextBox1.Text = "";
                }
            }
        }

        /// <summary>
        /// Button click action to find face
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (ProcessStart == true)
            {
                ProcessStart = false;
                PreProcessing preProc = new PreProcessing();
                RectangleDetection rd = new RectangleDetection();

                //PreProcesing Image get White Black Image 62 62
                Bitmap newBit = preProc.ChangeImage(img);
                Bitmap newImage = preProc.ChangeImage(img);

                pb_After.Image = preProc.ChangeImage(img);
                pb_After.SizeMode = PictureBoxSizeMode.Zoom;

                //Detection Process
                for (int i = 0; i < newImage.Height; i++)
                {
                    for (int j = 0; j < newImage.Width; j++)
                    {
                        if (i < newBit.Height - 42 && j < newBit.Width - 40)
                        {
                            FcImage fcImg = new FcImage(new Bitmap(newBit),
                                new Rectangle(i, j, 40, 42),
                                new Rectangle(0, 10, 20, 10),
                                new Rectangle(20, 0, 15, 15),
                                new Rectangle(20, 25, 15, 15),
                                new Rectangle(37, 15, 10, 5),
                                new Rectangle(10, 5, 10, 10),
                                new Rectangle(10, 25, 10, 10),
                                new Rectangle(35, 15, 10, 2));

                            fcImg = rd.RectangleSensor(fcImg);
                            if (fcImg.SensorCount > maxCount)
                            {
                                maxCount = fcImg.SensorCount;

                                if (fcImg.SensorCount >= 5)
                                {
                                    if ((fcImg.TopSens == true) && (fcImg.RightSens == true || fcImg.LeftSens == true) || (fcImg.LeftEyeSens == true || fcImg.RightEyeSens == true) && (fcImg.BottomSens == true || fcImg.BottomMouthSens == true))
                                    {
                                        pictureBox1.Image = fcImg.CurrentImage;
                                        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                                    }
                                }
                            }
                        }
                        if (i >= newBit.Height - 36 && i < newBit.Height - 40 && j < newBit.Width - 30)
                        {
                            FcImage fcImg = new FcImage(new Bitmap(newBit),
                                new Rectangle(i, j, 30, 40),
                                new Rectangle(0, 0, 30, 12),
                                new Rectangle(16, 0, 12, 14),
                                new Rectangle(16, 18, 12, 14),
                                new Rectangle(34, 8, 14, 6),
                                new Rectangle(12, 4, 6, 10),
                                new Rectangle(12, 20, 6, 10),
                                new Rectangle(26, 8, 14, 4));

                            fcImg = rd.RectangleSensor(fcImg);
                            if (fcImg.SensorCount > maxCount)
                            {
                                maxCount = fcImg.SensorCount;

                                if (fcImg.SensorCount >= 5)
                                {
                                    if ((fcImg.TopSens == true) && (fcImg.RightSens == true || fcImg.LeftSens == true) || (fcImg.LeftEyeSens == true || fcImg.RightEyeSens == true) && (fcImg.BottomSens == true || fcImg.BottomMouthSens == true))
                                    {
                                        pictureBox1.Image = fcImg.CurrentImage;
                                        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                                    }
                                }
                            }
                        }
                        else if (i < newBit.Height - 36 && j < newBit.Width - 30)
                        {
                            FcImage fcImg = new FcImage(new Bitmap(newBit),
                                new Rectangle(i, j, 30, 36),
                                new Rectangle(0, 0, 30, 12),
                                new Rectangle(16, 0, 12, 13),
                                new Rectangle(16, 18, 12, 13),
                                new Rectangle(32, 8, 14, 4),
                                new Rectangle(11, 4, 6, 5),
                                new Rectangle(11, 20, 6, 5),
                                new Rectangle(30, 8, 14, 2));
                            fcImg = rd.RectangleSensor(fcImg);
                            if (fcImg.SensorCount > maxCount)
                            {
                                maxCount = fcImg.SensorCount;

                                if (fcImg.SensorCount >= 5)
                                {
                                    if ((fcImg.TopSens == true) && (fcImg.RightSens == true || fcImg.LeftSens == true) || (fcImg.LeftEyeSens == true || fcImg.RightEyeSens == true) && (fcImg.BottomSens == true || fcImg.BottomMouthSens == true))
                                    {
                                        pictureBox1.Image = fcImg.CurrentImage;
                                        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                                    }
                                }
                            }
                        }

                        Color pixel = newImage.GetPixel(j, i);
                        if ((pixel.R >= 100 && pixel.G >= 100 && pixel.B >= 100) && (pixel.R < 140 && pixel.G < 140 && pixel.B < 140))
                        {
                            newImage.SetPixel(j, i, Color.Green);
                            textBox1.AppendText("1");
                            metroTextBox1.AppendText("X: " + i + " Y: " + j + " Color: " + pixel.ToArgb() + Environment.NewLine);
                        }
                        else if ((pixel.R >= 140 && pixel.G >= 140 && pixel.B >= 140) && (pixel.R < 170 && pixel.G < 170 && pixel.B < 170))
                        {
                            newImage.SetPixel(j, i, Color.Pink);
                            textBox1.AppendText("1");
                            metroTextBox1.AppendText("X: " + i + " Y: " + j + " Color: " + pixel.ToArgb() + Environment.NewLine);
                        }
                        else if (pixel.R < 100 && pixel.G < 100 && pixel.B < 100)
                        {
                            newImage.SetPixel(j, i, Color.Red);
                            textBox1.AppendText("1");
                            metroTextBox1.AppendText("X: " + i + " Y: " + j + " Color: " + pixel.ToArgb() + Environment.NewLine);
                        }
                        else if ((pixel.R >= 170 && pixel.G >= 170 && pixel.B >= 170) && (pixel.R <= 230 && pixel.G <= 230 && pixel.B <= 230))
                        {
                            newImage.SetPixel(j, i, Color.Yellow);
                            textBox1.AppendText("1");
                            metroTextBox1.AppendText("X: " + i + " Y: " + j + " Color: " + pixel.ToArgb() + Environment.NewLine);
                        }
                        else
                        {
                            newImage.SetPixel(j, i, Color.White);
                            textBox1.AppendText("0");
                            metroTextBox1.AppendText("X: " + i + " Y: " + j + " Color: " + pixel.ToArgb() + Environment.NewLine);
                        }
                        if (j == newImage.Width - 1)
                        {
                            textBox1.AppendText(Environment.NewLine);
                        }
                    }
                }
                pb_newImage.Image = newImage;
                pb_newImage.SizeMode = PictureBoxSizeMode.Zoom;
                if (panda == true)
                {
                    MessageBox.Show("This is Panda!");
                    panda = false;
                }
            }
        }
        /// <summary>
        /// Button Click action to find face 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Change_Click(object sender, EventArgs e)
        {
            if (ProcessStart == true)
            {
                ProcessStart = false;

                byte[] photoBytes = (byte[])new ImageConverter().ConvertTo(img, typeof(byte[]));
                
                ISupportedImageFormat format = new JpegFormat { Quality = 100 };
                Size size;
                if (img.Height > img.Width)
                {
                    size = new Size(62, 0);
                }
                else
                {
                    size = new Size(0, 62);
                }
                using (MemoryStream inStream = new MemoryStream(photoBytes))
                {
                    using (MemoryStream outStream = new MemoryStream())
                    {                       
                        using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                        {                           
                            imageFactory.Load(inStream)
                                        .Format(format)
                                        .Filter(MatrixFilters.Comic)
                                        .Filter(MatrixFilters.BlackWhite)
                                        .Resize(size)
                                        .Save(outStream);
                        }
                        bmp = new Bitmap(outStream);
                        newImage = new Bitmap(outStream);
                    }
                }
                //EuclideanColorFiltering filter = new EuclideanColorFiltering();
                //filter.CenterColor = new AForge.Imaging.RGB(Color.White);
                //filter.Radius = 100;
                //filter.FillColor = new AForge.Imaging.RGB(Color.Black);
                //filter.ApplyInPlace(bmp);

                pb_After.Image = bmp;
                pb_After.SizeMode = PictureBoxSizeMode.Zoom;
                textBox1.ForeColor = Color.White;

                Bitmap newBit = new Bitmap(bmp);

                for (int i = 0; i < bmp.Height; i++)
                {
                    for (int j = 0; j < bmp.Width; j++)
                    {

                        if (i < bmp.Height - 40 && j < bmp.Width - 40)
                        {
                            RectangleDetection(newBit,
                                new Rectangle(i, j, 40, 40),
                                new Rectangle(0, 10, 20, 10),
                                new Rectangle(20, 0, 15, 15),
                                new Rectangle(20, 25, 15, 15),
                                new Rectangle(35, 15, 10, 5),
                                new Rectangle(10, 5, 10, 10),
                                new Rectangle(10, 25, 10, 10),
                                new Rectangle(35, 15, 10, 2));
                        }
                        if (i >= bmp.Height - 36 && i < bmp.Height - 40 && j < bmp.Width - 30)
                        {
                            RectangleDetection(newBit,
                                new Rectangle(i, j, 30, 40),
                                new Rectangle(0, 0, 30, 12),
                                new Rectangle(16, 0, 14, 12),
                                new Rectangle(16, 22, 14, 12),
                                new Rectangle(36, 9, 15, 6),
                                new Rectangle(12, 4, 6, 10),
                                new Rectangle(12, 20, 6, 10),
                                new Rectangle(30, 9, 15, 4));
                        }
                        else
                        if (i < bmp.Height - 36 && j < bmp.Width - 30)
                        {
                            RectangleDetection(newBit,
                                new Rectangle(i, j, 30, 36),
                                new Rectangle(0, 0, 30, 12),
                                new Rectangle(16, 0, 14, 12),
                                new Rectangle(16, 22, 14, 12),
                                new Rectangle(30, 14, 10, 4),
                                new Rectangle(11, 4, 6, 5),
                                new Rectangle(11, 20, 6, 5),
                                new Rectangle(28, 16, 8, 2));
                        }


                        Color pixel = bmp.GetPixel(j, i);
                        if ((pixel.R >= 100 && pixel.G >= 100 && pixel.B >= 100) && (pixel.R < 140 && pixel.G < 140 && pixel.B < 140))
                        {
                            newImage.SetPixel(j, i, Color.Green);
                            textBox1.AppendText("1");
                            metroTextBox1.AppendText("X: " + i + " Y: " + j + " Color: " + pixel.ToArgb() + Environment.NewLine);
                        }
                        else if ((pixel.R >= 140 && pixel.G >= 140 && pixel.B >= 140) && (pixel.R < 170 && pixel.G < 170 && pixel.B < 170))
                        {
                            newImage.SetPixel(j, i, Color.Pink);
                            textBox1.AppendText("1");
                            metroTextBox1.AppendText("X: " + i + " Y: " + j + " Color: " + pixel.ToArgb() + Environment.NewLine);
                        }
                        else if (pixel.R < 100 && pixel.G < 100 && pixel.B < 100)
                        {
                            newImage.SetPixel(j, i, Color.Blue);
                            textBox1.AppendText("1");
                            metroTextBox1.AppendText("X: " + i + " Y: " + j + " Color: " + pixel.ToArgb() + Environment.NewLine);
                        }
                        else if ((pixel.R >= 170 && pixel.G >= 170 && pixel.B >= 170) && (pixel.R <= 230 && pixel.G <= 230 && pixel.B <= 230))
                        {
                            newImage.SetPixel(j, i, Color.Yellow);
                            textBox1.AppendText("1");
                            metroTextBox1.AppendText("X: " + i + " Y: " + j + " Color: " + pixel.ToArgb() + Environment.NewLine);
                        }
                        else
                        {
                            newImage.SetPixel(j, i, Color.White);
                            textBox1.AppendText("0");
                            metroTextBox1.AppendText("X: " + i + " Y: " + j + " Color: " + pixel.ToArgb() + Environment.NewLine);
                        }
                        if (j + 1 == bmp.Width)
                        {
                            textBox1.AppendText(Environment.NewLine);
                        }
                    }
                }
                pb_newImage.Image = newImage;
                pb_newImage.SizeMode = PictureBoxSizeMode.Zoom;


                if(panda == true)
                {
                    MessageBox.Show("This is Panda!");
                    panda = false;
                }
            }
        }

        /// <summary>
        /// Gets FcImage Class instance and checks the situation of rectangless
        /// </summary>
        /// <param name="cimg"></param>
        /// <param name="rect"></param>
        /// <param name="topRect"></param>
        /// <param name="leftRect"></param>
        /// <param name="rightRect"></param>
        /// <param name="bottomRect"></param>
        /// <param name="eyeRectLeft"></param>
        /// <param name="eyeRectRight"></param>
        /// <param name="mouthRectBottom"></param>
        public void RectangleDetection(Bitmap cimg, Rectangle rect, Rectangle topRect, Rectangle leftRect, Rectangle rightRect, Rectangle bottomRect, Rectangle eyeRectLeft, Rectangle eyeRectRight, Rectangle mouthRectBottom)
        {
            Bitmap newCIMG = new Bitmap(cimg);
            double topBlackP = 0;
            double leftBlackP = 0;
            double rightBlackP = 0;
            double bottomBlackP = 0;

            double leftWhiteP = 0;
            double rightWhiteP = 0;
            double bottomWhiteP = 0;

            bool top = false;
            bool left = false;
            bool right = false;
            bool bottom = false;
            bool leftEye = false;
            bool rightEye = false;
            bool mouthBottom = false;

            topRect.X = topRect.X + rect.X;
            topRect.Y = topRect.Y + rect.Y;

            leftRect.X = leftRect.X + rect.X;
            leftRect.Y = leftRect.Y + rect.Y;

            rightRect.X = rightRect.X + rect.X;
            rightRect.Y = rightRect.Y + rect.Y;

            bottomRect.X = bottomRect.X + rect.X;
            bottomRect.Y = bottomRect.Y + rect.Y;

            eyeRectLeft.X = eyeRectLeft.X + rect.X;
            eyeRectLeft.Y = eyeRectLeft.Y + rect.Y;

            eyeRectRight.X = eyeRectRight.X + rect.X;
            eyeRectRight.Y = eyeRectRight.Y + rect.Y;

            mouthRectBottom.X = mouthRectBottom.X + rect.X;
            mouthRectBottom.Y = mouthRectBottom.Y + rect.Y;

            for (int i = rect.X; i <= rect.X + rect.Height; i++)
            {
                for (int j = rect.Y; j <= rect.Y + rect.Width; j++)
                {
                    Color pixel = newCIMG.GetPixel(j, i);
                    if (j == rect.Y || (j == rect.Y + rect.Width && i < rect.X + rect.Height))
                    {
                        newCIMG.SetPixel(j, i, Color.Red);
                    }
                    else
                    if (i == rect.X || (i == rect.X + rect.Height && j < rect.Y + rect.Width))
                    {
                        newCIMG.SetPixel(j, i, Color.Red);
                    }
                    else
                    //Top
                    if (i >= topRect.X && i <= topRect.X + topRect.Height && j >= topRect.Y && j <= topRect.Y + topRect.Width)
                    {
                        if ((pixel.R >= 100 && pixel.G >= 100 && pixel.B >= 100) && (pixel.R < 170 && pixel.G < 170 && pixel.B < 170))
                        {
                           // newCIMG.SetPixel(j, i, Color.Green);
                            topBlackP++;
                        }
                        else if (pixel.R < 100 && pixel.G < 100 && pixel.B < 100)
                        {
                            // newCIMG.SetPixel(j, i, Color.Blue);
                            topBlackP++;
                        }
                        else if ((pixel.R >= 170 && pixel.G >= 170 && pixel.B >= 170) && (pixel.R <= 230 && pixel.G <= 230 && pixel.B <= 230))
                        {
                           // newCIMG.SetPixel(j, i, Color.Yellow);
                            topBlackP++;
                        }
                        else
                        {
                           // newCIMG.SetPixel(j, i, Color.White);
                        }
                    }
                    //Left Eye
                    else if (i <= eyeRectLeft.X + eyeRectLeft.Height && i >= eyeRectLeft.X && j <= eyeRectLeft.Y + eyeRectLeft.Width && j >= eyeRectLeft.Y)
                    {
                        if ((pixel.R >= 100 && pixel.G >= 100 && pixel.B >= 100) && (pixel.R < 170 && pixel.G < 170 && pixel.B < 170))
                        {
                           // newCIMG.SetPixel(j, i, Color.Green);
                            leftWhiteP++;
                        }
                        else if (pixel.R < 100 && pixel.G < 100 && pixel.B < 100)
                        {
                           // newCIMG.SetPixel(j, i, Color.Blue);
                            leftWhiteP++;
                        }
                        else if ((pixel.R >= 170 && pixel.G >= 170 && pixel.B >= 170) && (pixel.R <= 230 && pixel.G <= 230 && pixel.B <= 230))
                        {
                           // newCIMG.SetPixel(j, i, Color.Yellow);
                            leftWhiteP++;
                        }
                        else
                        {
                           // newCIMG.SetPixel(j, i, Color.White);
                        }
                    }
                    //Right Eye
                    else if (i <= eyeRectRight.X + eyeRectRight.Height && i >= eyeRectRight.X && j <= eyeRectRight.Y + eyeRectRight.Width && j >= eyeRectRight.Y)
                    {
                        if ((pixel.R >= 100 && pixel.G >= 100 && pixel.B >= 100) && (pixel.R < 170 && pixel.G < 170 && pixel.B < 170))
                        {
                          //  newCIMG.SetPixel(j, i, Color.Green);
                            rightWhiteP++;
                        }
                        else if (pixel.R < 100 && pixel.G < 100 && pixel.B < 100)
                        {
                           // newCIMG.SetPixel(j, i, Color.Blue);
                            rightWhiteP++;
                        }
                        else if ((pixel.R >= 170 && pixel.G >= 170 && pixel.B >= 170) && (pixel.R <= 230 && pixel.G <= 230 && pixel.B <= 230))
                        {
                         //   newCIMG.SetPixel(j, i, Color.Yellow);
                            rightWhiteP++;
                        }
                        else
                        {
                         //   newCIMG.SetPixel(j, i, Color.White);
                        }
                    }
                    //Left
                    else if (i <= leftRect.X + leftRect.Height && i >= leftRect.X && j <= leftRect.Y + leftRect.Width && j >= leftRect.Y)
                    {
                        if ((pixel.R >= 100 && pixel.G >= 100 && pixel.B >= 100) && (pixel.R < 170 && pixel.G < 170 && pixel.B < 170))
                        {
                          //  newCIMG.SetPixel(j, i, Color.Green);
                            leftBlackP++;
                        }
                        else if (pixel.R < 100 && pixel.G < 100 && pixel.B < 100)
                        {
                          //  newCIMG.SetPixel(j, i, Color.Blue);
                            leftBlackP++;
                        }
                        else if ((pixel.R >= 170 && pixel.G >= 170 && pixel.B >= 170) && (pixel.R <= 230 && pixel.G <= 230 && pixel.B <= 230))
                        {
                          //  newCIMG.SetPixel(j, i, Color.Yellow);
                            leftBlackP++;
                        }
                        else
                        {
                           // newCIMG.SetPixel(j, i, Color.White);
                        }
                    }
                    //Right
                    else if (i <= rightRect.X + rightRect.Height && i >= rightRect.X && j <= rightRect.Y + rightRect.Width && j >= rightRect.Y)
                    {
                        if ((pixel.R >= 100 && pixel.G >= 100 && pixel.B >= 100) && (pixel.R < 170 && pixel.G < 170 && pixel.B < 170))
                        {
                          //  newCIMG.SetPixel(j, i, Color.Green);
                            rightBlackP++;
                        }
                        else if (pixel.R < 100 && pixel.G < 100 && pixel.B < 100)
                        {
                          //  newCIMG.SetPixel(j, i, Color.Blue);
                            rightBlackP++;
                        }
                        else if ((pixel.R >= 170 && pixel.G >= 170 && pixel.B >= 170) && (pixel.R <= 230 && pixel.G <= 230 && pixel.B <= 230))
                        {
                           // newCIMG.SetPixel(j, i, Color.Yellow);
                            rightBlackP++;
                        }
                        else
                        {
                            //newCIMG.SetPixel(j, i, Color.White);
                        }
                    }
                    //Bottom
                    else if (i <= bottomRect.X + bottomRect.Height && i >= bottomRect.X && j <= bottomRect.Y + bottomRect.Width && j >= bottomRect.Y)
                    {
                        if ((pixel.R >= 100 && pixel.G >= 100 && pixel.B >= 100) && (pixel.R < 170 && pixel.G < 170 && pixel.B < 170))
                        {
                          //  newCIMG.SetPixel(j, i, Color.Green);
                            bottomBlackP++;
                        }
                        else if (pixel.R < 100 && pixel.G < 100 && pixel.B < 100)
                        {
                          //  newCIMG.SetPixel(j, i, Color.Blue);
                            bottomBlackP++;
                        }
                        else if ((pixel.R >= 170 && pixel.G >= 170 && pixel.B >= 170) && (pixel.R <= 230 && pixel.G <= 230 && pixel.B <= 230))
                        {
                          //  newCIMG.SetPixel(j, i, Color.Yellow);
                            bottomBlackP++;
                        }
                        else
                        {
                           // newCIMG.SetPixel(j, i, Color.White);
                        }
                    }
                    //Bottom Mouth
                    else if (i <= mouthRectBottom.X + mouthRectBottom.Height && i >= mouthRectBottom.X && j <= mouthRectBottom.Y + mouthRectBottom.Width && j >= mouthRectBottom.Y)
                    {
                        if ((pixel.R >= 100 && pixel.G >= 100 && pixel.B >= 100) && (pixel.R < 170 && pixel.G < 170 && pixel.B < 170))
                        {
                          //  newCIMG.SetPixel(j, i, Color.Green);
                            bottomWhiteP++;
                        }
                        else if (pixel.R < 100 && pixel.G < 100 && pixel.B < 100)
                        {
                           // newCIMG.SetPixel(j, i, Color.Blue);
                            bottomWhiteP++;
                        }
                        else if ((pixel.R >= 170 && pixel.G >= 170 && pixel.B >= 170) && (pixel.R <= 230 && pixel.G <= 230 && pixel.B <= 230))
                        {
                            //newCIMG.SetPixel(j, i, Color.Yellow);
                            bottomWhiteP++;
                        }
                        else
                        {
                           // newCIMG.SetPixel(j, i, Color.White);
                        }
                    }
                }
            }
            List<bool> test = new List<bool>();
            double topProc = topBlackP / (topRect.Width * topRect.Height) * 100;
            if (topProc < 35)
            {               
                top = true;
                test.Add(top);
            }     
            double leftProc = leftBlackP / (leftRect.Width * leftRect.Height) * 100;
            if (leftProc < 40)
            {              
                left = true;
                test.Add(left);
            }          
            double rightProc = rightBlackP / (rightRect.Width * rightRect.Height) * 100;
            if (rightProc < 40)
            {              
                right = true;
                test.Add(right);
            }
            double bottomProc = bottomBlackP / (bottomRect.Width * bottomRect.Height) * 100;
            if (bottomProc < 50)
            {
                bottom = true;
                test.Add(bottom);
            }
            double leftEyeProc = leftWhiteP / (eyeRectLeft.Width * eyeRectLeft.Height) * 100;
            if (leftEyeProc > 60)
            {
                leftEye = true;
                test.Add(leftEye);
            }

            double rightEyeProc = rightWhiteP / (eyeRectRight.Width * eyeRectRight.Height) * 100;
            if (rightEyeProc > 60)
            {
                rightEye = true;
                test.Add(rightEye);
            }
            double bottomProcM = bottomWhiteP / (mouthRectBottom.Width * mouthRectBottom.Height) * 100;
            if (bottomProcM > 50)
            {           
                mouthBottom = true;
                test.Add(mouthBottom);
            }
            int count = 0;
            for(int i = 0; i<test.Count; i++)
            {
                if(test[i] == true)
                {
                    count++;
                }
            }
            if(count > maxCount)
            {
                maxCount = count;

                if (count >= 5)
                {
                    if ((top == true) && (right == true || left == true) || (leftEye == true || rightEye == true) && (bottom == true || mouthBottom == true))
                    {
                        pictureBox1.Image = newCIMG;
                        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
            }                 
        }

        /// <summary>
        /// Gets the maximum value between two parameters
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static int GetMax(int first, int second)
        {
            if (first > second)
            {
                return first;
            }

            else if (first < second)
            {
                return second;
            }
            else
            {
                return second;
            }
        }

        
    }
}

