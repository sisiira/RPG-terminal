using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPPPPP
{
    public class MontagneAventure : Aventure
    {
        public MontagneAventure() : base("Aventure en Montagne", "Vous escaladez une montagne escarpée.")
        {
        }

        public override void CommencerAventure(Personnage personnage)
        {
            Console.WriteLine("Vous commencez l'aventure : " + Titre);
            Console.WriteLine(Description);

            Console.WriteLine("Vous atteignez un sommet et découvrez un nid de dragon. Que voulez-vous faire?");
            Console.WriteLine("1- Tenter de voler un trésor");
            Console.WriteLine("2- Revenir en arrière");

            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    Console.WriteLine("Vous essayez de voler un trésor et réveillez le dragon !");
                    Console.WriteLine("Vous devez combattre le dragon !");
                    Monstre dragon = new Monstre("Dragon");
                    CombatAventure(personnage, dragon);
                    break;
                case "2":
                    Console.WriteLine("Vous décidez de rebrousser chemin.");
                    break;
            }
        }

        private void CombatAventure(Personnage personnage, Monstre dragon)
        {
            while (!personnage.EstMort() && !dragon.EstMort())
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                dragon.Attaque(personnage);
                Console.WriteLine();
                Console.ReadKey(true);

                if (personnage.EstMort())
                {
                    Console.WriteLine("Vous avez été vaincu par le dragon !");
                    Console.ReadKey();
                    break;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                personnage.Attaque(dragon);
                Console.WriteLine();
                Console.ReadKey(true);
            }

            if (!personnage.EstMort())
            {
                Console.WriteLine("Vous avez vaincu le dragon et obtenu son trésor !");
                personnage.gagnerExperience(20);
                Console.WriteLine("Vous gagnez 20 points d'expérience.");
            }
        }
    }


}
