using System;

namespace OrdreDailyStandup
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nomsPersonnes = new string[9] { "Corentin", "Anatolie", "Elisa", "Laure", "Kevin", "Elif", "Iurii", "Jean", "Laurent" }; 

            string personneStockee;

            Random aleatoire = new Random();
            int personneAleatoire;

            int nbPersonne = nomsPersonnes.Length;
            
            for (int i = 0; i < nbPersonne; i++) {
                personneStockee = nomsPersonnes[i]; // On stocke la peronne d'indice i 
                personneAleatoire = aleatoire.Next(i, nbPersonne); // Génère un entier compris entre i et le nombre total d'élement du tableau 
                nomsPersonnes[i]= nomsPersonnes [personneAleatoire]; // On affecte la place de la personne d'indice i à la personne dont l'indice a été pioché par notre programme de nb aléatoire
                nomsPersonnes[personneAleatoire]= personneStockee; // On affecte la place de cette persionne piochée à la personne stocké au début

                Console.WriteLine(nomsPersonnes [i]);
            }
       
        }
    }
}
