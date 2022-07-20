using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class Variant
    {
        public String chrom { get; }
        public long position { get; }
        public String id { get; }
        public String reference { get; }
        public List<Base> alt { get; }
        public String qual { get; }
        public String filter { get; }
        public Dictionary<String, String> info { get; }
        public Dictionary<String, String> format { get; }
        public int formatNumber { get; }

        public Variant(String chrom, long position, String id, String reference, String alt, String qual, String filter, String info) 
            : this(chrom, position, id, reference, alt, qual, filter, info, "", 0) { }
        public Variant(String chrom, long position, String id, String reference, String alt, String qual, String filter, String info, String format, int formatNumber)
        {
            this.chrom = chrom;
            this.position = position;
            this.id = id;
            this.reference = reference;
            this.alt = MakeBases(position, reference, alt);
            this.qual = qual;
            this.filter = filter;
            this.formatNumber = formatNumber;


            this.info = new Dictionary<string, string>();
            string[] infoSegments = info.Split(';');
            foreach (var infoSegment in infoSegments)
            {
                string[] properties = infoSegment.Split('=');
                if (properties.Length > 1)
                {
                    this.info.Add(properties[0], properties[1]);
                }
                else this.info.Add(properties[0], "---");
            }

            this.format = new Dictionary<string, string>();
            if (format.Length > 0)
            {               
                string[] formatNames = format.Split('\t')[0].Split(':');
                string[] formatValues = format.Split('\t')[1].Split(':');
                for (var i = 0; i < formatNames.Length; i++)
                {
                    this.format.Add(formatNames[i] + " (FORMAT)", formatValues[i]);
                }
            }
        }
        private List<Base> MakeBases(long position, string reference, string alt)
        {
            var chars = new List<Base>();
            int endIndex;
            if (reference.Length >= alt.Length) endIndex = reference.Length;
            else endIndex = alt.Length;

            bool firstAdded = true;
            int insertPosition = 1;
            long? newPosition = position;
            char c;
            for (var i = 0; i < endIndex; i++)
            {

                if (i < alt.Length)
                {
                    if (alt[i] == '.') c = '-';
                    else c = alt[i];
                }
                else
                    c = '-';

                chars.Add(new Base(c, newPosition));

                if (i >= reference.Length)
                {
                    if (firstAdded)
                    {
                        newPosition--;
                        chars[chars.Count - 1].position = newPosition;
                        firstAdded = false;
                    }               
                    chars[chars.Count - 1].addedPosition = insertPosition;
                    insertPosition++;
                }

                else
                    newPosition++;
            }
            

            
            return chars;
        }
    }
}
