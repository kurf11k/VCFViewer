using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class VCF
    {
        public List<List<Variant>> variants{ get; }
        public String name { get; }
        public String pathToFile { get; }
        public List<Dictionary<string, string>> info { get; set; }
        public List<Dictionary<string, string>> format { get; set; }
        public bool isFormat { get; set; }
        public bool moreColumns { get; }
        public List<String> formatNames { get; }

        public VCF(String pathToFile)
        {
            info = new List<Dictionary<string, string>>();
            this.format = new List<Dictionary<string, string>>();
            variants = new List<List<Variant>>();
            this.name = GetName(pathToFile);
            this.pathToFile = pathToFile;

            moreColumns = false;


            List<String> properities = new List<string>();

            using(var file = new StreamReader(pathToFile))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    if (!line.StartsWith("#"))
                    {
                        String[] columns = line.Split('\t');
                        String[] alt = columns[4].Split(',');
                        String[] info = columns[7].Split(';');

                        for (var i = 0; i < info.Length; i++)
                        {
                            string[] newInfo = info[i].Split('=');
                            bool isAtList = false;
                            foreach (var item in this.info)
                            {
                                if (item["ID"] == newInfo[0])
                                {
                                    isAtList = true;
                                    break;
                                }
                            }
                            if (!isAtList)
                            {
                                this.info.Add(new Dictionary<string, string>());
                                this.info[this.info.Count - 1].Add("ID", newInfo[0]);
                            }
                        }


                        if (columns.Length > 8)
                        {
                            string[] formatProperities = columns[8].Split(':');
                            for (var i = 0; i < formatProperities.Length; i++)
                            {
                                bool isAtList = false;
                                foreach (var item in this.format)
                                {                                  
                                    if (item["ID"] == formatProperities[i] + " (FORMAT)")
                                    {
                                        isAtList = true;
                                        break;
                                    }
                                }
                                if (!isAtList)
                                {
                                    this.format.Add(new Dictionary<string, string>());
                                    this.format[this.format.Count - 1].Add("ID", formatProperities[i] + " (FORMAT)");                         
                                }

                            }
                            if (columns.Length > 10) moreColumns = true;


                            
                            for (var i = 9; i < columns.Length; i++)
                            {
                                                                  
                                string[] formatValues = columns[i].Split(':');
                                var index = GetIndexOfFormatProperty("AD", columns[8].Split(':'));

                                if (index != null)
                                {
                                    string[] ADs = formatValues[index.Value].Split(',');

                                    for (var k = 1; k < ADs.Length; k++)
                                    {
                                        string format = "";
                                        for (var l = 0; l < formatValues.Length; l++)
                                        {
                                            var prop = formatValues[l];
                                            if (l == index.Value)
                                            {
                                                prop = ADs[0] + "," + ADs[k];
                                            }
                                            if (format.Length == 0) format = prop;
                                            else format += ":" + prop;

                                        }
                                        variants[i - 9].Add(new Variant(columns[0], Int64.Parse(columns[1]), columns[2], columns[3], alt[k - 1], columns[5], columns[6], columns[7], columns[8] + "\t" + format, i - 8));
                                    }

                                }
                                else
                                {
                                    variants[i - 9].Add(new Variant(columns[0], Int64.Parse(columns[1]), columns[2], columns[3], alt[0], columns[5], columns[6], columns[7], columns[8] + "\t" + columns[i], i - 8));
                                }


                            }
                        }
                        else
                        {
                            variants.Add(new List<Variant>());
                            foreach (String item in alt)
                            {                               
                                variants[9].Add(new Variant(columns[0], Int64.Parse(columns[1]), columns[2], columns[3], item, columns[5], columns[6], columns[7]));
                            }

                        }
                    }
                    else if (line.StartsWith("#CHROM"))
                    {
                        string[] columns = line.Split('\t');
                        if (columns.Length == 8) isFormat = false;                 
                        else isFormat = true;
                        formatNames = new List<string>();

                        
                        for (var i = 9; i < columns.Length; i++)
                        {
                            variants.Add(new List<Variant>());
                            formatNames.Add(columns[i]);
                        }

                    }
                    else if (line.StartsWith("##INFO") || line.StartsWith("##FORMAT")) properities.Add(line);
                }
            }

            FindDescriptions(properities);
                
        }

        private void FindDescriptions(List<String> properities)
        {
            var lastProperty = "";
            foreach(var prop in properities)
            {
                var field = new Dictionary<string, string>();
                string[] segments = (prop.Split('<'))[1].Split('>')[0].Split(',');

                for (var i = 0; i < segments.Length; i++)
                {
                    if (segments[i].Contains("="))
                    {
                        string[] subsegments = segments[i].Split('=');
                        field.Add(subsegments[0], subsegments[1]);
                        lastProperty = subsegments[0];
                    }
                    else
                    {
                        field[lastProperty] += segments[i];
                    }
                }
                if (prop.StartsWith("##FORMAT")) AddPropertiesToFormat(field);
                else AddPropertiesToInfo(field);
                        
            }                  
                
            
        }
        private String GetName(String fileName)
        {
            string[] segments = fileName.Split('\\');
            return segments[segments.Length - 1];
        }

        private void AddPropertiesToInfo(Dictionary<string, string> field) 
        {
            for (var i = 0; i < info.Count; i++)
            {
                if (info[i]["ID"] == field["ID"])  
                {
                    info[i] = field;
                    break;
                }             
            }         
        }


        private void AddPropertiesToFormat(Dictionary<string, string> field)
        {
            for (var i = 0; i < format.Count; i++)
            {
                if (format[i]["ID"] == field["ID"] + " (FORMAT)")
                {
                    format[i] = field;
                    format[i]["ID"] += " (FORMAT)";
                    break;
                }
            }
        }

        private int? GetIndexOfFormatProperty(string propertyId, string[] properties)
        {
            for (var i = 0; i < properties.Length; i++)
            {
                if (properties[i] == propertyId) return i;
            }
            return null;
        }

        
    }
}
