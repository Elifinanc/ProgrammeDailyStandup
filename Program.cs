using System;
using System.IO;
using System.Text;
using CommandLine;
using System.Linq;
using System.Collections.Generic;


namespace Student_Shuffle
{
    public class Options
    {
        [Option('g', "group", SetName = "group", HelpText = "Create two groups of students")]
        public bool Group { get; set; }

        [Option('n', "count", SetName = "group", HelpText = "Number of groups", Default = 0)]
        public int GroupsNumber { get; set; }

        [Option('c', "config", HelpText = "XML config path", Default = "StudentShuffler.xml")]
        public string ConfigPath { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CommandLine.Parser.Default.ParseArguments<Options>(args)
            .WithParsed(RunOptions);
        }    

        static void RunOptions(Options options)
        {
            Config config = Config.Create(options);
            
            StudentShuffler studentShuffler = new StudentShuffler(config);
            List<Student> studentsListRandomized = studentShuffler.GetStudents();

            if(options.Group)
            {
                List<List<Student>> studentsGroups = studentShuffler.GetRandomizedGroups();
                List<List<String>> studentsGroupsFirstNames = new List<List<string>>();
                foreach (List<Student> studentsGroup in studentsGroups)
                {
                    var firstNameGroup = studentsGroup.Select(x => x.FirstName).ToList();
                    studentsGroupsFirstNames.Add(firstNameGroup);
                }
                IO.DisplayGroups(studentsGroupsFirstNames);
            }
            else
            {
                List<string> studentsListRandomizedFirstNames = studentsListRandomized.Select(x => x.FirstName).ToList();
                IO.DisplayNames(studentsListRandomizedFirstNames);
            }
        }  
    }
}
