using System;
namespace OrdreDailyStandup
{
    class Program
    {
        static void Main(string[] args)
        {
            // Constituer le tableau des étudiants à partir d'un fichier texte.
            // Chaque nom d'étudiant par ligne
            // Factoriser la récupération des étudiants
            string[] studentsNames = new string[9] { "Corentin", "Anatolie", "Elisa", "Laure", "Kevin", "Elif", "Iurii", "Jean", "Laurent" }; 
            string shuffledStudent;
            Random randomGenerator = new Random();
            int chosenStudent;
            int studentsNumber = studentsNames.Length;
            // Factorise la boucle de l'algorithme dans une fonction
            /* Implementation of the classic Fisher-Yates
               to shuffle the students
             */
            for (int i = 0; i < studentsNumber; i++)
            {
                shuffledStudent = studentsNames[i];
                chosenStudent = randomGenerator.Next(i, nbPersonne);
                studentsNames[i] = studentsNames[chosenStudent];
                studentsNames[chosenStudent] = shuffledStudent;
            }
            // Factoriser la restitution des informations à l'écran dans une fonction
            foreach(String name in studentsNames)
            {
                Console.WriteLine("Au tour de " + name + " de parler");
                Console.WriteLine("Appuyez sur une touche pour continuer ...");
                Console.ReadKey();
            }
        }
    }
}
