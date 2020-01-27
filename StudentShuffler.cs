using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Student_Shuffle
{
    class StudentShuffler
    {
        private string _fichier;
        private List<string> _studentsName;
        public StudentShuffler(string fichier)
        {
            _fichier = fichier;
        }

        public List<string> GetStudents()
        {
            ReadTextFile();
            RandomiseName();
            return _studentsName;
        }



        public void ReadTextFile()
        {
            using var fs = new FileStream(_fichier, FileMode.Open, FileAccess.Read);
            using var sr = new StreamReader(fs, Encoding.UTF8);
            List<string> studentNames = new List<string>();
            string line = String.Empty;

            while ((line = sr.ReadLine()) != null)
            {
                studentNames.Add(line);
            }

            _studentsName = studentNames;
        }

        public List<string> RandomiseName()
        {
            // Factorise la boucle de l'algorithme dans une fonction
            /* Implementation of the classic Fisher-Yates
               to shuffle the students
             */

            string shuffledStudent;
            Random randomGenerator = new Random();
            int chosenStudent;
            int studentsNumber = _studentsName.Count;             ;

            for (int i = 0; i < studentsNumber; i++)
            {
                shuffledStudent = _studentsName[i];
                chosenStudent = randomGenerator.Next(i, studentsNumber);
                _studentsName[i] = _studentsName[chosenStudent];
                _studentsName[chosenStudent] = shuffledStudent;
            }

            return _studentsName;
        }




    }
}
