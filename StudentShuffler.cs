using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Student_Shuffle
{
    // Violation du SRP: Il y a deux raisons de modifier la classe
    //                       * Si je veux changer la manière dont le fichier des étudiants est parsé
    //                       * Si je veux changer les algorithmes de randomisation
    class StudentShuffler
    {
        // Si on sépare la lecture du fichier de la randomisation, plus besoin de cet attribut.
        private string _fichier;
        // Effet de bord: On risque un effet de bord dès lors que _studentsName est modifiée
        //                il faudrait se débarrasser de cette variable ou la rendre private readonly.
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

        // Violation du DIP: StudentShuffler connaît les détails d'implémentation de la lecture d'un fichier
        // Violation de l'OCP: Si je veux ajouter un format de fichier ou un nouvel algorithme de parsing, je dois modifier cette méthode
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

        public List<List<string>> GetRandomizedGroups(int numberOfGroup)
        {
            List<List<string>> groups = new List<List<string>>();
            int studentsRemainder;
            int studentsPerGroupCount = Math.DivRem(_studentsName.Count, numberOfGroup, out studentsRemainder);
            string[] tail = new string[_studentsName.Count];
            _studentsName.CopyTo(tail);
            // Split the initial group in a given number of groups
            for (int i=0; i < numberOfGroup; i++)
            {
                List<string> shuffledGroup = tail.Take(studentsPerGroupCount).ToList();
                groups.Add(shuffledGroup);
                tail = tail.Skip(studentsPerGroupCount).ToArray();
            }
            // If there are students remaining, put each of them in a group until there is no more
            for (int i=0; i < studentsRemainder; i++)
            {
                List<string> groupWithOneRemainder = groups[i];
                groupWithOneRemainder.Add(tail[i]);
            }
            return groups;
        }
    }
}
