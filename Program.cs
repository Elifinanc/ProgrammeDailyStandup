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

            [Option('g', "group", HelpText = "Create two groups of students")]
            public bool Group { get; set; }
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
                List<List<string>> studentsGroups = IO.GetGroups(studentsListRandomized, 2);
                IO.DisplayGroups(studentsGroups);
            }
            else
            {
                IO.DisplayNames(studentsListRandomized);
            }
            
        }



    }

    
}
