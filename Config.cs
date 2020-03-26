using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using CommandLine;
using System.Xml.Linq;
using System.IO;
using System.Linq;

namespace Student_Shuffle
{
    public class Config
    {
        public IEnumerable<Student> Students { get; set; }
        public int GroupsNumber { get; set; }
       
        public static Config Create(Options options)
        {
            int groupsNumber;
            var currentDirectory = Directory.GetCurrentDirectory();
            var studentsFilepath = Path.Combine(currentDirectory, options.ConfigPath);
            XElement studentGetter = XElement.Load(studentsFilepath);
            
            if (options.GroupsNumber == 0)
            {
                groupsNumber = 
                    Convert.ToInt32(studentGetter.Descendants("groupNumber").Select(x => x.Value).First());
            }
            else
            {
                groupsNumber = options.GroupsNumber;
            }
            Config config = new Config();
            config.GroupsNumber = groupsNumber;
            config.Students = studentGetter.Descendants("Student").Select(x => new Student { FirstName = (string)x.Attribute("FirstName"), 
                LastName = (string)x.Attribute("LastName"), Quote = (string)x.Attribute("Quote")
            });

            return config;
        }



    }
}
