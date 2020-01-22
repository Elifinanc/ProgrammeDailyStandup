using System;
using System.IO;
using System.Text;


namespace Student_Shuffle
{
    class Program
    {
        static void Main(string[] args)
        {

            StudentShuffler studentShuffler = new StudentShuffler(@"C:\Users\Student\source\repos\Student_Shuffle\StudentsName.txt");

            IO.DisplayNames(studentShuffler.GetStudents());
            

        }
        
    }

    
}
