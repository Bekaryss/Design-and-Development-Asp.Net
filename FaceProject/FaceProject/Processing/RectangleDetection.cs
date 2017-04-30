using FaceProject.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceProject.Processing
{
    /// <summary>
    /// Represents Class which is responsible for detection of rectangles
    /// </summary>
    public class RectangleDetection
    {
        /// <summary>
        /// Gets FcImage Class instance and checks the situation of rectangles
        /// </summary>
        /// <param name="img">FcImage instance</param>
        /// <returns>FcImage image</returns>
        public FcImage RectangleSensor(FcImage img)
        {
            double topBlackP = 0;
            double leftBlackP = 0;
            double rightBlackP = 0;
            double bottomBlackP = 0;

            double leftWhiteP = 0;
            double rightWhiteP = 0;
            double bottomWhiteP = 0;

            for (int i = img.MainRect.X; i <= img.MainRect.X + img.MainRect.Height; i++)
            {
                for (int j = img.MainRect.Y; j <= img.MainRect.Y + img.MainRect.Width; j++)
                {
                    Color pixel = img.CurrentImage.GetPixel(j, i);
                    if (j == img.MainRect.Y || (j == img.MainRect.Y + img.MainRect.Width && i < img.MainRect.X + img.MainRect.Height))
                    {
                        img.CurrentImage.SetPixel(j, i, Color.Red);
                    }
                    else
                    if (i == img.MainRect.X || (i == img.MainRect.X + img.MainRect.Height && j < img.MainRect.Y + img.MainRect.Width))
                    {
                        img.CurrentImage.SetPixel(j, i, Color.Red);
                    }
                    else
                    //img.TopSens
                    if (i >= img.TopRect.X + img.MainRect.X && i <= img.TopRect.X + img.MainRect.X + img.TopRect.Height && j >= img.TopRect.Y + img.MainRect.Y && j <= img.TopRect.Y + img.MainRect.Y + img.TopRect.Width)
                    {
                        if ((pixel.R >= 100 && pixel.G >= 100 && pixel.B >= 100) && (pixel.R < 170 && pixel.G < 170 && pixel.B < 170))
                        {
                            // img.CurrentImage.SetPixel(j, i, Color.Green);
                            topBlackP++;
                        }
                        else if (pixel.R < 100 && pixel.G < 100 && pixel.B < 100)
                        {
                            // img.CurrentImage.SetPixel(j, i, Color.Blue);
                            topBlackP++;
                        }
                        else if ((pixel.R >= 170 && pixel.G >= 170 && pixel.B >= 170) && (pixel.R <= 230 && pixel.G <= 230 && pixel.B <= 230))
                        {
                            // img.CurrentImage.SetPixel(j, i, Color.Yellow);
                            topBlackP++;
                        }
                        else
                        {
                            // img.CurrentImage.SetPixel(j, i, Color.White);
                        }
                    }
                    //img.LeftSens Eye
                    else if (i <= img.EyeLeftRect.X + img.MainRect.X + img.EyeLeftRect.Height && i >= img.EyeLeftRect.X + img.MainRect.X && j <= img.EyeLeftRect.Y + img.MainRect.Y + img.EyeLeftRect.Width && j >= img.EyeLeftRect.Y + img.MainRect.Y)
                    {
                        if ((pixel.R >= 100 && pixel.G >= 100 && pixel.B >= 100) && (pixel.R < 170 && pixel.G < 170 && pixel.B < 170))
                        {
                            // img.CurrentImage.SetPixel(j, i, Color.Green);
                            leftWhiteP++;
                        }
                        else if (pixel.R < 100 && pixel.G < 100 && pixel.B < 100)
                        {
                            // img.CurrentImage.SetPixel(j, i, Color.Blue);
                            leftWhiteP++;
                        }
                        else if ((pixel.R >= 170 && pixel.G >= 170 && pixel.B >= 170) && (pixel.R <= 230 && pixel.G <= 230 && pixel.B <= 230))
                        {
                            // img.CurrentImage.SetPixel(j, i, Color.Yellow);
                            leftWhiteP++;
                        }
                        else
                        {
                            // img.CurrentImage.SetPixel(j, i, Color.White);
                        }
                    }
                    //img.RightSens Eye
                    else if (i <= img.EyeRightRect.X + img.MainRect.X + img.EyeRightRect.Height && i >= img.EyeRightRect.X + img.MainRect.X && j <= img.EyeRightRect.Y + img.MainRect.Y + img.EyeRightRect.Width && j >= img.EyeRightRect.Y + img.MainRect.Y)
                    {
                        if ((pixel.R >= 100 && pixel.G >= 100 && pixel.B >= 100) && (pixel.R < 170 && pixel.G < 170 && pixel.B < 170))
                        {
                            //  img.CurrentImage.SetPixel(j, i, Color.Green);
                            rightWhiteP++;
                        }
                        else if (pixel.R < 100 && pixel.G < 100 && pixel.B < 100)
                        {
                            // img.CurrentImage.SetPixel(j, i, Color.Blue);
                            rightWhiteP++;
                        }
                        else if ((pixel.R >= 170 && pixel.G >= 170 && pixel.B >= 170) && (pixel.R <= 230 && pixel.G <= 230 && pixel.B <= 230))
                        {
                            //   img.CurrentImage.SetPixel(j, i, Color.Yellow);
                            rightWhiteP++;
                        }
                        else
                        {
                            //   img.CurrentImage.SetPixel(j, i, Color.White);
                        }
                    }
                    //img.LeftSens
                    else if (i <= img.LeftRect.X + img.MainRect.X + img.LeftRect.Height && i >= img.LeftRect.X + img.MainRect.X && j <= img.LeftRect.Y + img.MainRect.Y + img.LeftRect.Width && j >= img.LeftRect.Y + img.MainRect.Y)
                    {
                        if ((pixel.R >= 100 && pixel.G >= 100 && pixel.B >= 100) && (pixel.R < 170 && pixel.G < 170 && pixel.B < 170))
                        {
                            //  img.CurrentImage.SetPixel(j, i, Color.Green);
                            leftBlackP++;
                        }
                        else if (pixel.R < 100 && pixel.G < 100 && pixel.B < 100)
                        {
                            //  img.CurrentImage.SetPixel(j, i, Color.Blue);
                            leftBlackP++;
                        }
                        else if ((pixel.R >= 170 && pixel.G >= 170 && pixel.B >= 170) && (pixel.R <= 230 && pixel.G <= 230 && pixel.B <= 230))
                        {
                            //  img.CurrentImage.SetPixel(j, i, Color.Yellow);
                            leftBlackP++;
                        }
                        else
                        {
                            // img.CurrentImage.SetPixel(j, i, Color.White);
                        }
                    }
                    //img.RightSens
                    else if (i <= img.RightRect.X + img.MainRect.X + img.RightRect.Height && i >= img.RightRect.X + img.MainRect.X && j <= img.RightRect.Y + img.MainRect.Y + img.RightRect.Width && j >= img.RightRect.Y + img.MainRect.Y)
                    {
                        if ((pixel.R >= 100 && pixel.G >= 100 && pixel.B >= 100) && (pixel.R < 170 && pixel.G < 170 && pixel.B < 170))
                        {
                            //  img.CurrentImage.SetPixel(j, i, Color.Green);
                            rightBlackP++;
                        }
                        else if (pixel.R < 100 && pixel.G < 100 && pixel.B < 100)
                        {
                            //  img.CurrentImage.SetPixel(j, i, Color.Blue);
                            rightBlackP++;
                        }
                        else if ((pixel.R >= 170 && pixel.G >= 170 && pixel.B >= 170) && (pixel.R <= 230 && pixel.G <= 230 && pixel.B <= 230))
                        {
                            // img.CurrentImage.SetPixel(j, i, Color.Yellow);
                            rightBlackP++;
                        }
                        else
                        {
                            //img.CurrentImage.SetPixel(j, i, Color.White);
                        }
                    }
                    //img.BottomSens
                    else if (i <= img.BottomRect.X + img.MainRect.X + img.BottomRect.Height && i >= img.BottomRect.X + img.MainRect.X && j <= img.BottomRect.Y + img.MainRect.Y + img.BottomRect.Width && j >= img.BottomRect.Y + img.MainRect.Y)
                    {
                        if ((pixel.R >= 100 && pixel.G >= 100 && pixel.B >= 100) && (pixel.R < 170 && pixel.G < 170 && pixel.B < 170))
                        {
                            //  img.CurrentImage.SetPixel(j, i, Color.Green);
                            bottomBlackP++;
                        }
                        else if (pixel.R < 100 && pixel.G < 100 && pixel.B < 100)
                        {
                            //  img.CurrentImage.SetPixel(j, i, Color.Blue);
                            bottomBlackP++;
                        }
                        else if ((pixel.R >= 170 && pixel.G >= 170 && pixel.B >= 170) && (pixel.R <= 230 && pixel.G <= 230 && pixel.B <= 230))
                        {
                            //  img.CurrentImage.SetPixel(j, i, Color.Yellow);
                            bottomBlackP++;
                        }
                        else
                        {
                            // img.CurrentImage.SetPixel(j, i, Color.White);
                        }
                    }
                    //img.BottomSens Mouth
                    else if (i <= img.MouthBottomRect.X + img.MainRect.X + img.MouthBottomRect.Height && i >= img.MouthBottomRect.X + img.MainRect.X && j <= img.MouthBottomRect.Y + img.MainRect.Y + img.MouthBottomRect.Width && j >= img.MouthBottomRect.Y + img.MainRect.Y)
                    {
                        if ((pixel.R >= 100 && pixel.G >= 100 && pixel.B >= 100) && (pixel.R < 170 && pixel.G < 170 && pixel.B < 170))
                        {
                            //  img.CurrentImage.SetPixel(j, i, Color.Green);
                            bottomWhiteP++;
                        }
                        else if (pixel.R < 100 && pixel.G < 100 && pixel.B < 100)
                        {
                            // img.CurrentImage.SetPixel(j, i, Color.Blue);
                            bottomWhiteP++;
                        }
                        else if ((pixel.R >= 170 && pixel.G >= 170 && pixel.B >= 170) && (pixel.R <= 230 && pixel.G <= 230 && pixel.B <= 230))
                        {
                            //img.CurrentImage.SetPixel(j, i, Color.Yellow);
                            bottomWhiteP++;
                        }
                        else
                        {
                            // img.CurrentImage.SetPixel(j, i, Color.White);
                        }
                    }
                }
            }
            List<bool> test = new List<bool>();
            double topProc = topBlackP / (img.TopRect.Width * img.TopRect.Height) * 100;
            if (topProc < 35)
            {
                img.TopSens = true;
                test.Add(img.TopSens);
            }
            double leftProc = leftBlackP / (img.LeftRect.Width * img.LeftRect.Height) * 100;
            if (leftProc < 40)
            {
                img.LeftSens = true;
                test.Add(img.LeftSens);
            }
            double rightProc = rightBlackP / (img.RightRect.Width * img.RightRect.Height) * 100;
            if (rightProc < 40)
            {
                img.RightSens = true;
                test.Add(img.RightSens);
            }
            double bottomProc = bottomBlackP / (img.BottomRect.Width * img.BottomRect.Height) * 100;
            if (bottomProc < 50)
            {
                img.BottomSens = true;
                test.Add(img.BottomSens);
            }
            double leftEyeProc = leftWhiteP / (img.EyeLeftRect.Width * img.EyeLeftRect.Height) * 100;
            if (leftEyeProc > 60)
            {
                img.LeftEyeSens = true;
                test.Add(img.LeftEyeSens);
            }

            double rightEyeProc = rightWhiteP / (img.EyeRightRect.Width * img.EyeRightRect.Height) * 100;
            if (rightEyeProc > 60)
            {
                img.RightEyeSens = true;
                test.Add(img.RightEyeSens);
            }
            double bottomProcM = bottomWhiteP / (img.MouthBottomRect.Width * img.MouthBottomRect.Height) * 100;
            if (bottomProcM > 50)
            {
                img.BottomMouthSens = true;
                test.Add(img.BottomMouthSens);
            }
            for (int i = 0; i < test.Count; i++)
            {
                if (test[i] == true)
                {
                    img.SensorCount++;
                }
            }
            return img;
        }
        /// <summary>
        /// Gets FcImagePro Class instance and checks the situation of rectangles with additional rectangle for nose bridge
        /// </summary>
        /// <param name="img">FcImagePro instance</param>
        /// <returns>FcImagePro image</returns>
        public FcImagePro RectangleSensorPro(FcImagePro img)
        {
            double topBlackP = 0;
            double leftBlackP = 0;
            double rightBlackP = 0;
            double bottomBlackP = 0;
            double betweenBlackP = 0;

            double leftWhiteP = 0;
            double rightWhiteP = 0;
            double bottomWhiteP = 0;

            for (int i = img.MainRect.X; i <= img.MainRect.X + img.MainRect.Height; i++)
            {
                for (int j = img.MainRect.Y; j <= img.MainRect.Y + img.MainRect.Width; j++)
                {
                    Color pixel = img.CurrentImage.GetPixel(j, i);
                    if (j == img.MainRect.Y || (j == img.MainRect.Y + img.MainRect.Width && i < img.MainRect.X + img.MainRect.Height))
                    {
                        img.CurrentImage.SetPixel(j, i, Color.Red);
                    }
                    else
                    if (i == img.MainRect.X || (i == img.MainRect.X + img.MainRect.Height && j < img.MainRect.Y + img.MainRect.Width))
                    {
                        img.CurrentImage.SetPixel(j, i, Color.Red);
                    }
                    else
                    //img.TopSens
                    if (i >= img.TopRect.X + img.MainRect.X && i <= img.TopRect.X + img.MainRect.X + img.TopRect.Height && j >= img.TopRect.Y + img.MainRect.Y && j <= img.TopRect.Y + img.MainRect.Y + img.TopRect.Width)
                    {
                        if ((pixel.R >= 100 && pixel.G >= 100 && pixel.B >= 100) && (pixel.R < 170 && pixel.G < 170 && pixel.B < 170))
                        {
                            // img.CurrentImage.SetPixel(j, i, Color.Green);
                            topBlackP++;
                        }
                        else if (pixel.R < 100 && pixel.G < 100 && pixel.B < 100)
                        {
                            // img.CurrentImage.SetPixel(j, i, Color.Blue);
                            topBlackP++;
                        }
                        else if ((pixel.R >= 170 && pixel.G >= 170 && pixel.B >= 170) && (pixel.R <= 230 && pixel.G <= 230 && pixel.B <= 230))
                        {
                            // img.CurrentImage.SetPixel(j, i, Color.Yellow);
                            topBlackP++;
                        }
                        else
                        {
                            // img.CurrentImage.SetPixel(j, i, Color.White);
                        }
                    }
                    //img.LeftSens Eye
                    else if (i <= img.EyeLeftRect.X + img.MainRect.X + img.EyeLeftRect.Height && i >= img.EyeLeftRect.X + img.MainRect.X && j <= img.EyeLeftRect.Y + img.MainRect.Y + img.EyeLeftRect.Width && j >= img.EyeLeftRect.Y + img.MainRect.Y)
                    {
                        if ((pixel.R >= 100 && pixel.G >= 100 && pixel.B >= 100) && (pixel.R < 170 && pixel.G < 170 && pixel.B < 170))
                        {
                            // img.CurrentImage.SetPixel(j, i, Color.Green);
                            leftWhiteP++;
                        }
                        else if (pixel.R < 100 && pixel.G < 100 && pixel.B < 100)
                        {
                            // img.CurrentImage.SetPixel(j, i, Color.Blue);
                            leftWhiteP++;
                        }
                        else if ((pixel.R >= 170 && pixel.G >= 170 && pixel.B >= 170) && (pixel.R <= 230 && pixel.G <= 230 && pixel.B <= 230))
                        {
                            // img.CurrentImage.SetPixel(j, i, Color.Yellow);
                            leftWhiteP++;
                        }
                        else
                        {
                            // img.CurrentImage.SetPixel(j, i, Color.White);
                        }
                    }
                    //img.RightSens Eye
                    else if (i <= img.EyeRightRect.X + img.MainRect.X + img.EyeRightRect.Height && i >= img.EyeRightRect.X + img.MainRect.X && j <= img.EyeRightRect.Y + img.MainRect.Y + img.EyeRightRect.Width && j >= img.EyeRightRect.Y + img.MainRect.Y)
                    {
                        if ((pixel.R >= 100 && pixel.G >= 100 && pixel.B >= 100) && (pixel.R < 170 && pixel.G < 170 && pixel.B < 170))
                        {
                            //  img.CurrentImage.SetPixel(j, i, Color.Green);
                            rightWhiteP++;
                        }
                        else if (pixel.R < 100 && pixel.G < 100 && pixel.B < 100)
                        {
                            // img.CurrentImage.SetPixel(j, i, Color.Blue);
                            rightWhiteP++;
                        }
                        else if ((pixel.R >= 170 && pixel.G >= 170 && pixel.B >= 170) && (pixel.R <= 230 && pixel.G <= 230 && pixel.B <= 230))
                        {
                            //   img.CurrentImage.SetPixel(j, i, Color.Yellow);
                            rightWhiteP++;
                        }
                        else
                        {
                            //   img.CurrentImage.SetPixel(j, i, Color.White);
                        }
                    }
                    //img.LeftSens
                    else if (i <= img.LeftRect.X + img.MainRect.X + img.LeftRect.Height && i >= img.LeftRect.X + img.MainRect.X && j <= img.LeftRect.Y + img.MainRect.Y + img.LeftRect.Width && j >= img.LeftRect.Y + img.MainRect.Y)
                    {
                        if ((pixel.R >= 100 && pixel.G >= 100 && pixel.B >= 100) && (pixel.R < 170 && pixel.G < 170 && pixel.B < 170))
                        {
                            //  img.CurrentImage.SetPixel(j, i, Color.Green);
                            leftBlackP++;
                        }
                        else if (pixel.R < 100 && pixel.G < 100 && pixel.B < 100)
                        {
                            //  img.CurrentImage.SetPixel(j, i, Color.Blue);
                            leftBlackP++;
                        }
                        else if ((pixel.R >= 170 && pixel.G >= 170 && pixel.B >= 170) && (pixel.R <= 230 && pixel.G <= 230 && pixel.B <= 230))
                        {
                            //  img.CurrentImage.SetPixel(j, i, Color.Yellow);
                            leftBlackP++;
                        }
                        else
                        {
                            // img.CurrentImage.SetPixel(j, i, Color.White);
                        }
                    }
                    //img.RightSens
                    else if (i <= img.RightRect.X + img.MainRect.X + img.RightRect.Height && i >= img.RightRect.X + img.MainRect.X && j <= img.RightRect.Y + img.MainRect.Y + img.RightRect.Width && j >= img.RightRect.Y + img.MainRect.Y)
                    {
                        if ((pixel.R >= 100 && pixel.G >= 100 && pixel.B >= 100) && (pixel.R < 170 && pixel.G < 170 && pixel.B < 170))
                        {
                            //  img.CurrentImage.SetPixel(j, i, Color.Green);
                            rightBlackP++;
                        }
                        else if (pixel.R < 100 && pixel.G < 100 && pixel.B < 100)
                        {
                            //  img.CurrentImage.SetPixel(j, i, Color.Blue);
                            rightBlackP++;
                        }
                        else if ((pixel.R >= 170 && pixel.G >= 170 && pixel.B >= 170) && (pixel.R <= 230 && pixel.G <= 230 && pixel.B <= 230))
                        {
                            // img.CurrentImage.SetPixel(j, i, Color.Yellow);
                            rightBlackP++;
                        }
                        else
                        {
                            //img.CurrentImage.SetPixel(j, i, Color.White);
                        }
                    }
                    //Between Eye
                    else if (i <= img.EyeBetweenRect.X + img.MainRect.X + img.EyeBetweenRect.Height && i >= img.EyeBetweenRect.X + img.MainRect.X && j <= img.EyeBetweenRect.Y + img.MainRect.Y + img.EyeBetweenRect.Width && j >= img.EyeBetweenRect.Y + img.MainRect.Y)
                    {
                        if ((pixel.R >= 100 && pixel.G >= 100 && pixel.B >= 100) && (pixel.R <= 230 && pixel.G <= 230 && pixel.B <= 230))
                        {
                            //  newCIMG.SetPixel(j, i, Color.Blue);
                            betweenBlackP++;
                        }
                        else
                        {
                            //   newCIMG.SetPixel(j, i, Color.White);
                        }
                    }
                    //img.BottomSens
                    else if (i <= img.BottomRect.X + img.MainRect.X + img.BottomRect.Height && i >= img.BottomRect.X + img.MainRect.X && j <= img.BottomRect.Y + img.MainRect.Y + img.BottomRect.Width && j >= img.BottomRect.Y + img.MainRect.Y)
                    {
                        if ((pixel.R >= 100 && pixel.G >= 100 && pixel.B >= 100) && (pixel.R < 170 && pixel.G < 170 && pixel.B < 170))
                        {
                            //  img.CurrentImage.SetPixel(j, i, Color.Green);
                            bottomBlackP++;
                        }
                        else if (pixel.R < 100 && pixel.G < 100 && pixel.B < 100)
                        {
                            //  img.CurrentImage.SetPixel(j, i, Color.Blue);
                            bottomBlackP++;
                        }
                        else if ((pixel.R >= 170 && pixel.G >= 170 && pixel.B >= 170) && (pixel.R <= 230 && pixel.G <= 230 && pixel.B <= 230))
                        {
                            //  img.CurrentImage.SetPixel(j, i, Color.Yellow);
                            bottomBlackP++;
                        }
                        else
                        {
                            // img.CurrentImage.SetPixel(j, i, Color.White);
                        }
                    }
                    //img.BottomSens Mouth
                    else if (i <= img.MouthBottomRect.X + img.MainRect.X + img.MouthBottomRect.Height && i >= img.MouthBottomRect.X + img.MainRect.X && j <= img.MouthBottomRect.Y + img.MainRect.Y + img.MouthBottomRect.Width && j >= img.MouthBottomRect.Y + img.MainRect.Y)
                    {
                        if ((pixel.R >= 100 && pixel.G >= 100 && pixel.B >= 100) && (pixel.R < 170 && pixel.G < 170 && pixel.B < 170))
                        {
                            //  img.CurrentImage.SetPixel(j, i, Color.Green);
                            bottomWhiteP++;
                        }
                        else if (pixel.R < 100 && pixel.G < 100 && pixel.B < 100)
                        {
                            // img.CurrentImage.SetPixel(j, i, Color.Blue);
                            bottomWhiteP++;
                        }
                        else if ((pixel.R >= 170 && pixel.G >= 170 && pixel.B >= 170) && (pixel.R <= 230 && pixel.G <= 230 && pixel.B <= 230))
                        {
                            //img.CurrentImage.SetPixel(j, i, Color.Yellow);
                            bottomWhiteP++;
                        }
                        else
                        {
                            // img.CurrentImage.SetPixel(j, i, Color.White);
                        }
                    }
                }
            }
            List<bool> test = new List<bool>();
            double topProc = topBlackP / (img.TopRect.Width * img.TopRect.Height) * 100;
            if (topProc < 35)
            {
                img.TopSens = true;
                test.Add(img.TopSens);
            }
            double leftProc = leftBlackP / (img.LeftRect.Width * img.LeftRect.Height) * 100;
            if (leftProc < 40)
            {
                img.LeftSens = true;
                test.Add(img.LeftSens);
            }
            double rightProc = rightBlackP / (img.RightRect.Width * img.RightRect.Height) * 100;
            if (rightProc < 40)
            {
                img.RightSens = true;
                test.Add(img.RightSens);
            }
            double eyesBtwProcM = betweenBlackP / (img.EyeBetweenRect.Width * img.EyeBetweenRect.Height) * 100;
            if (eyesBtwProcM < 40)
            {
                img.BetweenEyeSens = true;
                test.Add(img.BetweenEyeSens);
            }
            double bottomProc = bottomBlackP / (img.BottomRect.Width * img.BottomRect.Height) * 100;
            if (bottomProc < 50)
            {
                img.BottomSens = true;
                test.Add(img.BottomSens);
            }
            double leftEyeProc = leftWhiteP / (img.EyeLeftRect.Width * img.EyeLeftRect.Height) * 100;
            if (leftEyeProc > 60)
            {
                img.LeftEyeSens = true;
                test.Add(img.LeftEyeSens);
            }

            double rightEyeProc = rightWhiteP / (img.EyeRightRect.Width * img.EyeRightRect.Height) * 100;
            if (rightEyeProc > 60)
            {
                img.RightEyeSens = true;
                test.Add(img.RightEyeSens);
            }
            double bottomProcM = bottomWhiteP / (img.MouthBottomRect.Width * img.MouthBottomRect.Height) * 100;
            if (bottomProcM > 50)
            {
                img.BottomMouthSens = true;
                test.Add(img.BottomMouthSens);
            }
            for (int i = 0; i < test.Count; i++)
            {
                if (test[i] == true)
                {
                    img.SensorCount++;
                }
            }
            return img;
        }
    }
}
