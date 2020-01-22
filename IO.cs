using System;
using System.Collections.Generic;
using System.Text;

namespace Student_Shuffle
{
    class IO
    {
        
        public static void DisplayNames(string[] studentsName)
        {
            // Factoriser la restitution des informations à l'écran dans une fonction

            foreach (String name in studentsName)
            {
                Console.WriteLine("Au tour de " + name + " de parler");
                Console.WriteLine("Appuyez sur une touche pour continuer ...");
                Console.ReadKey();
            }
        }
    }
}
