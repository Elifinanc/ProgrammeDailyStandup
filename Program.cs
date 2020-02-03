using System;
using System.IO;
using System.Text;
using CommandLine;
using System.Linq;
using System.Collections.Generic;


namespace Student_Shuffle
{
    class Program
    {
        class Options
        {
            [Option ('f', "filepath", HelpText = "Provide a filepath")]
            public string Filepath { get; set; }

            [Option('g', "group", SetName="group", HelpText = "Create two groups of students")]
            public bool Group { get; set; }

            [Option('n', "count", SetName="group", HelpText = "Number of groups", Default=2)]
            public int GroupsNumber { get; set; }
        }
        
        static void Main(string[] args)
        {
            CommandLine.Parser.Default.ParseArguments<Options>(args)
            .WithParsed(RunOptions);
        }

        static void RunOptions (Options options)
        {
            string path = options.Filepath;
            StudentShuffler studentShuffler = new StudentShuffler(path);
            List<string> studentsListRandomized = studentShuffler.GetStudents();

            if(options.Group)
            {
                List<List<string>> studentsGroups = studentShuffler.GetRandomizedGroups(options.GroupsNumber);
                IO.DisplayGroups(studentsGroups);
            }
            else
            {
                IO.DisplayNames(studentsListRandomized);
            }
            
        }



    }

    
}
