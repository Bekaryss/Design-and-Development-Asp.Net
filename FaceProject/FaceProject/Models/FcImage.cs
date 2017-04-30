using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceProject.Models
{
    /// <summary>
    /// Class Face Image processes an image to adduce it to processing format for detection of rectangles
    /// </summary>
    public class FcImage
    {
        /// <summary>
        /// the current image that we have
        /// </summary>
        public Bitmap CurrentImage { get; set; }
        /// <summary>
        /// the main area of detection of face
        /// </summary>
        public Rectangle MainRect { get; set; }
        /// <summary>
        /// the rectangle that is placed on forehead 
        /// </summary>
        public Rectangle TopRect { get; set; }
        /// <summary>
        /// the rectangle that is placed on the left cheek
        /// </summary>
        public Rectangle LeftRect { get; set; }
        /// <summary>
        /// the rectangle that is placed on the right cheek
        /// </summary>
        public Rectangle RightRect { get; set; }
        /// <summary>
        /// the rectangle tha is responsible for detecting chin
        /// </summary>
        public Rectangle BottomRect { get; set; }
        /// <summary>
        /// the rectangle for left eye detection
        /// </summary>
        public Rectangle EyeLeftRect { get; set; }
        /// <summary>
        /// the rectangle for right eye detection
        /// </summary>
        public Rectangle EyeRightRect { get; set; }
        /// <summary>
        /// the rectangle for detecting mouth
        /// </summary>
        public Rectangle MouthBottomRect { get; set; }

        /// <summary>
        /// checks if rectangle is satisfied on the forehead
        /// </summary>
        public bool TopSens { get; set; }
        /// <summary>
        /// checks if rectangle is satisfied on the left cheek
        /// </summary>
        public bool LeftSens { get; set; }
        /// <summary>
        /// checks if rectangle is satisfied on the right cheek
        /// </summary>
        public bool RightSens { get; set; }
        /// <summary>
        /// checks if rectangle is satisfied on the chin
        /// </summary>
        public bool BottomSens { get; set; }
        /// <summary>
        /// checks if rectangle is satisfied on the left eye
        /// </summary>
        public bool LeftEyeSens { get; set; }
        /// <summary>
        /// checks if rectangle is satisfied on the right eye
        /// </summary>
        public bool RightEyeSens { get; set; }
        /// <summary>
        /// checks if rectangle is satisfied on the mouth
        /// </summary>
        public bool BottomMouthSens { get; set; }
        /// <summary>
        /// checks the count of sensors found
        /// </summary>
        public int SensorCount { get; set; }
        /// <summary>
        /// Initializes a new instance of FcImage class to the value indicated by current image,main rectangle,top rectangle,left rectangle, right rectangle, bottom rectangle, left eye rectangle, right eye rectangle and mouth rectangle
        /// </summary>
        /// <param name="_cimg">CurrentImage</param>
        /// <param name="_rect">MainRect</param>
        /// <param name="_topRect"> TopRect</param>
        /// <param name="_leftRect">LeftRect</param>
        /// <param name="_rightRect">RightRect</param>
        /// <param name="_bottomRect">BottomRect</param>
        /// <param name="_eyeRectLeft">EyeLeftRect</param>
        /// <param name="_eyeRectRight">EyeRightRect</param>
        /// <param name="_mouthRectBottom">MouthBottomRect</param>
        public FcImage(Bitmap _cimg, Rectangle _rect, Rectangle _topRect, Rectangle _leftRect, Rectangle _rightRect, Rectangle _bottomRect, Rectangle _eyeRectLeft, Rectangle _eyeRectRight, Rectangle _mouthRectBottom)
        {
            CurrentImage = _cimg;
            MainRect = _rect;
            TopRect = _topRect;
            LeftRect = _leftRect;
            RightRect = _rightRect;
            BottomRect = _bottomRect;
            EyeLeftRect = _eyeRectLeft;
            EyeRightRect = _eyeRectRight;
            MouthBottomRect = _mouthRectBottom;

            TopSens = false;
            LeftSens = false;
            RightSens = false;
            BottomSens = false;
            LeftEyeSens = false;
            RightEyeSens = false;
            BottomMouthSens = false;

            SensorCount = 0;
        }
    }
}
