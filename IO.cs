using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Student_Shuffle
{
    class IO
    {

        public static void DisplayNames(List<string> studentsName)
        {
            // Factoriser la restitution des informations à l'écran dans une fonction

            foreach (String name in studentsName)
            {
                Console.WriteLine("Au tour de " + name + " de parler");
                Console.WriteLine("Appuyez sur une touche pour continuer ...");
                Console.ReadKey();
            }
        }

        public static void DisplayGroups(List<List<string>> studentsGroups)
        {
            for(int i = 0; i < studentsGroups.Count; i++)
            {
                Console.WriteLine("Group {0} ", i);
                List<string> currentStudentsGroup = studentsGroups[i];
                foreach (string students in currentStudentsGroup)
                {
                    Console.WriteLine("\t{0}", students);
                }
                Console.WriteLine();
                

            }

        }
    }
}
