using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Student_Shuffle
{
    public class Config
    {
        private XmlReader _reader;
        public IEnumerable<String> Students { get; set; }
        public int GroupsNumber { get; set; }

        public Config(string filePath)
        {
            _reader = XmlReader.Create(filePath);
            while (_reader.Read())
            {
                if (_reader.NodeType == XmlNodeType.Element)
                {
                    if(_reader.Name == "groupNumber")
                    {
                        _reader.Read();
                        GroupsNumber = Convert.ToInt32(_reader.Value);
                    }
                    else if (_reader.Name == "file")
                    {
                        _reader.Read();
                        FlatFileReader fileReader = new FlatFileReader(_reader.Value);
                        Students = fileReader.ExtractFileLines();
                    }
                }
            }   
        }
    }
}
