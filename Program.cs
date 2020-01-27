using System;
using System.IO;
using System.Text;
using CommandLine;
using System.Linq;


namespace Student_Shuffle
{
    class Program
    {
        class Options
        {
            [Option ('f', "filepath", HelpText = "Provide a filepath")]
            public string Filepath { get; set; }
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

            IO.DisplayNames(studentShuffler.GetStudents());
        }



    }

    
}
