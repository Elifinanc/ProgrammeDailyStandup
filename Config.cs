using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using CommandLine;

namespace Student_Shuffle
{
    public class Config
    {
        public IEnumerable<String> Students { get; set; }
        public int GroupsNumber { get; set; }

        public static Config Create(Options options)
        {
            int groupsNumber = 0;
            String filepath = String.Empty;
            if (options.Filepath == null)
            {
                filepath = Config.LoadElement("file", options.ConfigPath);
            }
            else
            {
                filepath = options.Filepath;
            }
            if (options.GroupsNumber == 0)
            {
                groupsNumber = Convert.ToInt32(Config.LoadElement("groupNumber", options.ConfigPath));
            }
            else
            {
                groupsNumber = options.GroupsNumber;
            }
            Config config = new Config();
            config.GroupsNumber = groupsNumber;
            config.Students = FlatFileReader.ExtractFileLines(filepath);

            return config;
        }

        public static string LoadElement(string elementName, string filepath)
        {
            XmlReader reader = XmlReader.Create(filepath);
            
            string content = null;

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name == elementName)
                    {
                        reader.Read();
                        content = (reader.Value);
                    }
                }
            }
            if (content == null)
            {
                throw new Exception($"Invalid element {elementName}");
            }
            return content;
        }

    }
}
