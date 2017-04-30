using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorTriangle
{
    public partial class Form1 : Form
    {
        Color c1 = Color.Red;
        Color c2 = Color.Blue;
        Color c3 = Color.GreenYellow;
        Graphics g;
        public Form1()
        {
            InitializeComponent();
            g = pnl_Draw.CreateGraphics();
        }

        public void DrowCircle()
        {

        }
        
        private void pnl_Draw_Paint(object sender, PaintEventArgs e)
        {
            
            ColorRGB top = new ColorRGB(c1);
            ColorRGB left = new ColorRGB(c2);
            ColorRGB right = new ColorRGB(c3);          

            int numberOfIntervals = 50;

            IntervalRGB top_left = new IntervalRGB(c1, c2, numberOfIntervals);
            
            var current_R = top.R;
            var current_G = top.G;
            var current_B = top.B;

            var current_RL = right.R;
            var current_GL = right.G;
            var current_BL = right.B;
            int s = 5;
            int f = 5;
            var left_right = new IntervalRGB(c2, c3, numberOfIntervals);
            int js = 15;
            int jf = 15;

            int jff = 15;
            int number = numberOfIntervals;
            for (var i = 0; i <= numberOfIntervals; i++)
            {
                var color = Color.FromArgb(current_R, current_G, current_B);
                Brush brush = new SolidBrush(color);
                var colorlr = Color.FromArgb(current_RL, current_GL, current_BL);
                var current_Rj = current_R;
                var current_Gj = current_G;
                var current_Bj = current_B;               
                
                for (int j = 1; j<=number; j++)
                {
                    IntervalRGB top_right = new IntervalRGB(color, colorlr, number);
                    var colorj = Color.FromArgb(current_Rj, current_Gj, current_Bj);
                    Brush brushj = new SolidBrush(colorj);
                    g.FillEllipse(brushj, js, jf, 10, 10);
                    js = js + 10;
                    jf = jf + 10;
                    current_Rj += top_right.interval_R;
                    current_Gj += top_right.interval_G;
                    current_Bj += top_right.interval_B;
                }
                js = 15;
                jff = jff + 10;
                jf = jff;                             
                number--;
                g.FillEllipse(brush, s, f, 10, 10);
                f = f + 10;
                current_R += top_left.interval_R;
                current_G += top_left.interval_G;
                current_B += top_left.interval_B;

                current_RL -= left_right.interval_R;
                current_GL -= left_right.interval_G;
                current_BL -= left_right.interval_B;
            }
        }

        private void btn_color1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                c1 = colorDialog1.Color;
            }
            pnl_Draw.Invalidate();
            pnl_Draw.Update();
        }

        private void btn_color2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                c2 = colorDialog1.Color;
            }
            pnl_Draw.Invalidate();
            pnl_Draw.Update();
        }

        private void btn_color3_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                c3 = colorDialog1.Color;
            }
            pnl_Draw.Invalidate();
            pnl_Draw.Update();
        }
    }
    public class ColorRGB
    {
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }
        public ColorRGB(Color c)
        {
            R = c.R;
            G = c.G;
            B = c.B;
        }       
    }

    public class IntervalRGB
    {
        public int interval_R { get; set; }
        public int interval_G { get; set; }
        public int interval_B { get; set; }
        public int numberOfIntervals { get; set; }
        public IntervalRGB(Color c1, Color c2, int i)
        {
            numberOfIntervals = i;
            interval_R = (c2.R - c1.R) / numberOfIntervals;
            interval_G = (c2.G - c1.G) / numberOfIntervals;
            interval_B = (c2.B - c1.B) / numberOfIntervals;
        }
    }
}
