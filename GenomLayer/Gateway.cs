using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public static class Gateway
    {
        private static string pathToFile = "data.csv";
        public static List<Genom> LoadGenoms()
        {
            try
            {
                List<Genom> genoms = new List<Genom>();
                if (!File.Exists(pathToFile)) File.Create(pathToFile).Close();

                using (var file = new StreamReader(pathToFile))
                {
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        string[] data = line.Split(';');
                        genoms.Add(new Genom(data[0], data[1]));

                        for (var i = 2; i < data.Length; i++)
                        {
                            genoms[genoms.Count - 1].vcfs.Add(new VCF(data[i]));
                        }
                    }
                    return genoms;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static void SaveGenoms(List<Genom> genoms)
        {
            try
            {
                if (!File.Exists(pathToFile)) File.Create(pathToFile).Close();

                using (var file = new StreamWriter(pathToFile, false))
                {
                    foreach (var genom in genoms)
                    {
                        file.Write(genom.pathToFile + ";" + genom.pathToIndexer);
                        foreach (var vcf in genom.vcfs)
                        {
                            file.Write(";" + vcf.pathToFile);
                        }
                        file.WriteLine();
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public static void DeleteData()
        {
            File.Delete(pathToFile);
        }

        public static List<Base> LoadBases(long positionInFile, long startPosition, long endPosition, string pathToGenom)
        {        
            List<Base> bases = new List<Base>();

            using (FileStream fs = File.Open(pathToGenom, FileMode.Open))
            {
                fs.Seek(positionInFile, 0);
                for (var i = startPosition; i <= endPosition; i++)
                {
                    char c;
                    c = (char)fs.ReadByte();
                    if (c == '\n')
                    {
                        if(i == startPosition) fs.Seek(positionInFile - 1, 0);
                        c = ((char)fs.ReadByte());
                    }
                    bases.Add(new Base(c, i));
                }
                return bases;
            }
        }
    }
}
