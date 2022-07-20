using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace BusinessLayer
{
    public class Genom
    {
        public List<Chromosome> chromosomes { get; }
        public String name { get; }
        public String pathToFile { get; }
        public String pathToIndexer { get; }
        public List<VCF> vcfs { get; }

        public Genom(String pathToFile, String pathToIndexer)
        {
            this.pathToFile = pathToFile;
            this.pathToIndexer = pathToIndexer;
            vcfs = new List<VCF>();
            name = GetNameOfGenom();
            chromosomes = GetChroms();
        }
        private List<Chromosome> GetChroms()
        {
            List<Chromosome> chromosomes = new List<Chromosome>();
            string line;

            if(pathToIndexer == "-")
            {
                using (var file = new StreamReader(pathToFile))
                {
                    long _startIndex = 0, _countCharsOnLine = 0, _length = 0;
                    while ((line = file.ReadLine()) != null)
                    {
                        if (IsNameOfChrom(line))
                        {
                            chromosomes.Add(new Chromosome(line.Substring(1, line.Length - 1)));
                            _startIndex += line.Length + 1;
                            chromosomes[chromosomes.Count - 1].startIndex = _startIndex;
                            if (chromosomes.Count > 1)
                            {
                                chromosomes[chromosomes.Count - 2].length = _length;
                                chromosomes[chromosomes.Count - 2].countChars = _countCharsOnLine;
                                chromosomes[chromosomes.Count - 2].countCharsWithEnd = _countCharsOnLine + 1;
                            }
                            _length = 0;
                            _countCharsOnLine = 0;
                        }
                        else
                        {
                            if (_countCharsOnLine == 0) _countCharsOnLine = line.Length;
                            _startIndex += line.Length + 1;
                            _length += line.Length;
                        }
                    }
                    chromosomes[chromosomes.Count - 1].length = _length;
                    chromosomes[chromosomes.Count - 1].countChars = _countCharsOnLine;
                    chromosomes[chromosomes.Count - 1].countCharsWithEnd = _countCharsOnLine + 1;
                }
            }
            else
            {
                using (var file = new StreamReader(pathToIndexer))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        String[] segments = line.Split('\t');
                        chromosomes.Add(new Chromosome(segments[0], Int64.Parse(segments[1]), Int64.Parse(segments[2]), Int64.Parse(segments[3]), Int64.Parse(segments[4])));
                    }
                }
            }
            return chromosomes;          
        }
        
        private bool IsNameOfChrom(String str)
        {
            if (str.StartsWith(">chr")) return true;
            return false;
        }
        private String GetNameOfGenom()
        {
            var i = 0;
            for (i = pathToFile.Length - 1; i > -1; i--){
                if (pathToFile[i] == '\\') break;
            }
            return pathToFile.Substring(i + 1, pathToFile.Length - i - 1);
        }       
        public Chromosome GetChromByName(string chromosomeName)
        {
            foreach(var chrom in chromosomes)
            {
                if (chrom.name == chromosomeName) return chrom;
            }
            return null;
        }       

        /*public Base GetCharacter(Chromosome chrom, long position)
        {
            var newPosition = chrom.startIndex + chrom.GetPosition(position);

            using (FileStream fs = File.Open(pathToFile, FileMode.Open))
            {
                char c;
                fs.Seek(newPosition, 0);
                c = (char)fs.ReadByte();
                if (c == '\n')
                {
                    newPosition = newPosition - 1;
                    fs.Seek(newPosition, 0);
                    c = ((char)fs.ReadByte());
                }

                fs.Close();
                return new Base(c, position);
            }
        }*/
        public List<Base> GetBases(Chromosome chrom, long position, long count)
        {
            List<Base> chars = new List<Base>();
            long startIndex, endIndex = 0;
            //long startIndexPlus = 0, endIndexPlus = 0;
            if (position - count <= 0)
            {
                startIndex = 1;
                endIndex = -(position - count);
            }
            else startIndex = position - count;
            
            if (position + count > chrom.length)
            { 
                endIndex = chrom.length;
                startIndex += endIndex - count - position;
            }
            else endIndex += position + count + 1;

            var positionInFile = chrom.startIndex + chrom.GetPosition(startIndex);

            return Gateway.LoadBases(positionInFile, startIndex, endIndex, pathToFile);
        }
     
    }
}
