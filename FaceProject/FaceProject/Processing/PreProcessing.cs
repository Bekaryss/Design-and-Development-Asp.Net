using FaceProject.Models;
using ImageProcessor;
using ImageProcessor.Imaging.Filters.Photo;
using ImageProcessor.Imaging.Formats;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceProject.Processing
{
    /// <summary>
    /// Class that provides functionality to preprocss an image to the ready for detecting face stage.
    /// </summary>
    public class PreProcessing
    {
        /// <summary>
        /// Gets primary  image and applys to it Black&White and Comic filters. Then resizes an image.
        /// </summary>
        /// <param name="img"> Primary System.Drawing.Image </param>
        /// <returns> returns finished and changed Bitmap</returns>
        public Bitmap ChangeImage(Image img)
        {
            Bitmap newImage;
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
                    newImage = new Bitmap(outStream);
                }              
            }
            return newImage;
        }       
    }
}
