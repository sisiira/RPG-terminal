using System;

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

                Console.ForegroundColor = ConsoleColor.Red;
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

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();

                while (!suivant)
                {
                    Console.WriteLine("Combat suivant ? (O/N)");
                    string saisie = Console.ReadLine().ToUpper();
                    if (saisie == "O")
                    {
                        suivant = true;
                        Jouer(nomP);
                    }
                    else if (saisie == "N")
                    {
                        Environment.Exit(0);
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();
                Console.WriteLine("Vous avez perdu !");
                Console.ReadKey();
            }

            
            Console.WriteLine("Que voulez-vous faire maintenant?");
            Console.WriteLine("1- Parler à un NPC");
            Console.WriteLine("2- Partir à l'aventure");
            Console.WriteLine("3- Quitter le jeu");
            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    ParlerNPC(nomP);
                    break;
                case "2":
                    PartirAventure(nomP);
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Choix invalide. Veuillez sélectionner une option valide.");
                    Jouer(nomP);
                    break;
            }
        }

        static void Menu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("TILTED GAME!");
            Console.WriteLine();
            Console.WriteLine("Choisis ta classe :");
            Console.WriteLine();
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
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Choix invalide. Veuillez sélectionner une classe valide.");
                    Menu();
                    break;
            }
        }

        
        static void ParlerNPC(Personnage nomP)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("Vous avez rencontré un personnage non-joueur (NPC). Que voulez-vous dire?");
            Console.WriteLine("1- Demander des informations");
            Console.WriteLine("2- Saluer");
            Console.WriteLine("3- Retourner");
            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    Console.WriteLine("NPC: Je ne sais pas grand-chose, mais j'ai entendu dire qu'il y a un trésor caché dans la montagne.");
                    ParlerNPC(nomP);
                    break;
                case "2":
                    Console.WriteLine("NPC: Bonjour, aventurier!");
                    ParlerNPC(nomP);
                    break;
                case "3":
                    Jouer(nomP);
                    break;
                default:
                    Console.WriteLine("Choix invalide. Veuillez sélectionner une option valide.");
                    ParlerNPC(nomP);
                    break;
            }
        }

        static void PartirAventure(Personnage nomP)
        {
            Console.WriteLine("Choisissez une aventure :");
            Console.WriteLine("1- Aventure en Forêt");
            Console.WriteLine("2- Aventure en Montagne");
            Console.WriteLine("3- Retour");

            string choixAventure = Console.ReadLine();

            switch (choixAventure)
            {
                case "1":
                    Aventure foretAventure = new ForetAventure();
                    foretAventure.CommencerAventure(nomP);
                    break;

                case "2":
                    Aventure montagneAventure = new MontagneAventure();
                    montagneAventure.CommencerAventure(nomP);
                    break;

                case "3":
                    Jouer(nomP);
                    break;

                default:
                    Console.WriteLine("Choix invalide. Veuillez sélectionner une aventure valide.");
                    PartirAventure(nomP);
                    break;
            }
        }

    }
}
