using System;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace Student_Shuffle
{
    public class FlatFileReader : IReadable
    {
        public string Filepath { get; private set; }

        public FlatFileReader(String filepath)
        {
            Filepath = filepath;
        }

        public IEnumerable<String> ExtractFileLines()
        {
            using var fileStream = new FileStream(Filepath, FileMode.Open, FileAccess.Read);
            using var streamReader = new StreamReader(fileStream, Encoding.UTF8);
            List<string> names = new List<string>();
            
            string line = streamReader.ReadLine();
            while(line != null)
            {
                names.Add(line);
                line = streamReader.ReadLine();
            }

            return names;
        }
    }
}