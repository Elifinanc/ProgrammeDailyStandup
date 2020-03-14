using System;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace Student_Shuffle
{
    public static class FlatFileReader
    {
        public static IEnumerable<String> ExtractFileLines(string filepath)
        {
            using var fileStream = new FileStream(filepath, FileMode.Open, FileAccess.Read);
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