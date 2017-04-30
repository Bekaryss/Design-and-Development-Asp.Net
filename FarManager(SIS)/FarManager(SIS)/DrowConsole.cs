using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarManager_SIS_
{
    public class DrowConsole
    {
        public int BoxX { get; set; }
        public int BoxY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public int Start { get; set; }
        public int Finish { get; set; }
        public DrowConsole(int x, int y, int w, int h)
        {
            BoxX = x;
            BoxY = y;
            Width = w;
            Height = h;
        }

        public void ClBox(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }
    }
}
