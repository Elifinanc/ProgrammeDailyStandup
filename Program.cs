﻿using System;
using System.IO;
using System.Text;
using CommandLine;
using System.Linq;
using System.Collections.Generic;


namespace Student_Shuffle
{
    class Program
    {   
        static void Main(string[] args)
        {
            CommandLine.Parser.Default.ParseArguments<Options>(args)
            .WithParsed(RunOptions);
        }

        class Options
        {
            [Option('f', "filepath", HelpText = "Provide a filepath")]
            public string Filepath { get; set; }

            [Option('g', "group", SetName = "group", HelpText = "Create two groups of students")]
            public bool Group { get; set; }

            [Option('n', "count", SetName = "group", HelpText = "Number of groups", Default = 2)]
            public int GroupsNumber { get; set; }

            [Option('c', "config", HelpText = "XML config path", Default = "StudentShuffler.xml")]
            public string ConfigPath { get; set; }
        }

        static void RunOptions(Options options)
        {
            Config config = new Config(options.ConfigPath);

            StudentShuffler studentShuffler = new StudentShuffler(config);
            List<string> studentsListRandomized = studentShuffler.GetStudents();

            if(options.Group)
            {
                List<List<string>> studentsGroups = studentShuffler.GetRandomizedGroups();
                IO.DisplayGroups(studentsGroups);
            }
            else
            {
                IO.DisplayNames(studentsListRandomized);
            }
        }
    }
}
