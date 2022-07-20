using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer

{
    public class Base
    {
        public char mark { get; set; }
        public long? position { get; set; }
        public Color color { get; set; }
        public int addedPosition { get; set; }
        public String note { get; set; }
        public Base(char mark, long? position)
        {
            this.mark = mark;
            this.position = position;
            color = GetColor(mark);
            addedPosition = 0;
        }
        private Color GetColor(char mark)
        {
            switch (mark)
            {
                case 'N':
                    return Color.FromArgb(102, 102, 102);
                case 'a':
                    return Color.FromArgb(0, 179, 60);
                case 'c':
                    return Color.FromArgb(0, 102, 255);
                case 't':
                    return Color.FromArgb(255, 51, 51);
                case 'A':
                    return Color.FromArgb(0, 179, 60);
                case 'C':
                    return Color.FromArgb(0, 102, 255);
                case 'T':
                    return Color.FromArgb(255, 51, 51);
                case 'g':
                    return Color.FromArgb(191, 128, 64);
                case 'G':
                    return Color.FromArgb(191, 128, 64);
            }
            return Color.FromArgb(0, 0, 0);
        }
    }
}
