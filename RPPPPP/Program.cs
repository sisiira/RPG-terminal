using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RPPPPP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        static void Jouer(Personnage nomP)
        {
            Monstre monstre = new Monstre("Gros Ogre");
            bool victoire = true;
            bool suivant = false;

            while (!monstre.EstMort())
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                monstre.Attaque(nomP);
                Console.WriteLine();
                Console.ReadKey(true);

                if (nomP.EstMort())
                {
                    victoire = false;
                    break;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                nomP.Attaque(monstre);
                Console.WriteLine();
                Console.ReadKey(true);
            }

            if (victoire)
            {
                nomP.gagnerExperience(4);

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine(nomP.Stats());

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();

                while (!suivant)
                {
                    Console.WriteLine("Combat suivant ? (O/N)");
                    string saisie = Console.ReadLine().ToUpper();
                    if (saisie == "O")
                    {
                        suivant = true;
                    }
                    else if (saisie == "N")
                    {
                        Environment.Exit(0);
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine();
                Console.WriteLine("Vous avez perdu !");
                Console.ReadKey();
            }
        }
        static void Menu()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("TILTED GAME!");
            Console.WriteLine();
            Console.WriteLine("Choisis ta classe :");
            Console.WriteLine("1-Nécromant");
            Console.WriteLine("2-Guerrier");
            Console.WriteLine("3-Assassin");
            Console.WriteLine("4-Mage");
            Console.WriteLine();
            Console.WriteLine("5-Quitter le jeu");
            Console.WriteLine();

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Vous avez choisi Nécromant");
                    Console.WriteLine();
                    Jouer(new Necromant("Yorick"));
                    break;

                case "2":
                    Console.WriteLine("Vous avez choisi Guerrier");
                    Console.WriteLine();
                    Jouer(new Guerrier("Darius"));
                    break;

                case "3":
                    Console.WriteLine("Vous avez choisi Assassin");
                    Console.WriteLine();
                    Jouer(new Assassin("Akali"));
                    break;

                case "4":
                    Console.WriteLine("Vous avez choisi Mage");
                    Console.WriteLine();
                    Jouer(new Mage("Veigar"));
                    break;
            }
        }
    }
}
        
