using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BusinessLayer
{
    public class Chromosome
    {
        public String name { get;}
        public long length { get; set; }
        public long startIndex { get; set; }
        public long countChars { get; set; }
        public long countCharsWithEnd { get; set; }
        public long absolutLength { get; set; }


        public Chromosome(String name)
        {
            this.name = name;
        }
        public Chromosome(String name, long length, long startIndex, long countChars, long countCharsWithEnd) : this(name)
        {
            this.length = length;
            this.startIndex = startIndex;
            this.countChars = countChars;
            this.countCharsWithEnd = countCharsWithEnd;
            this.absolutLength = GetPosition(length);
        }

        public long GetPosition(long relativePos)
        {
            return (relativePos / countChars) + relativePos - 1;
        }
        public bool PositionCorrect(long position)
        {
            if (position < 1 || position > length) return false;
            return true;
        }
    }
}
