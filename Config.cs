using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Student_Shuffle
{
    public class Config
    {
        public IEnumerable<String> Students { get; set; }
        public int GroupsNumber { get; set; }

        public static Config CreateFromXML(string filepath)
        {
            XmlReader reader = XmlReader.Create(filepath);
            Config newConfig = new Config();

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if(reader.Name == "groupNumber")
                    {
                        reader.Read();
                        newConfig.GroupsNumber = Convert.ToInt32(reader.Value);
                    }
                    else if (reader.Name == "file")
                    {
                        reader.Read();
                        FlatFileReader fileReader = new FlatFileReader(reader.Value);
                        newConfig.Students = fileReader.ExtractFileLines();
                    }
                }
            }
            return newConfig;
        }
    }
}
