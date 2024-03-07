using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPPPPP
{
    public class MontagneAventure : Aventure
    {
        private Boutique boutique;
        private Personnage personnage;

        public MontagneAventure() : base("Aventure en Montagne", "Vous escaladez une montagne escarpée.")
        {
            boutique = new Boutique();
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
                Console.ForegroundColor = ConsoleColor.White;
                dragon.Attaque(personnage);
                Console.WriteLine();
                Console.ReadKey(true);

                if (personnage.EstMort())
                {
                    Console.WriteLine("Vous avez été vaincu par le dragon !");
                    Console.ReadKey();
                    RetourMenuPrincipal(personnage);
                    return;
                    
                }

                Console.ForegroundColor = ConsoleColor.White;
                personnage.Attaque(dragon);
                Console.WriteLine();
                Console.ReadKey(true);
            }

            if (!personnage.EstMort())
            {
                Console.WriteLine("Vous avez vaincu le dragon et obtenu son trésor !");
                personnage.gagnerExperience(20);
                Console.WriteLine("Vous gagnez 20 points d'expérience.");

                Console.WriteLine($"Points d'experience : {personnage.Niveau}");
                Console.WriteLine($"Pieces d'or : { personnage.PiecesOr}");
                ChoixApresCombatDragon(personnage);
            }
            else
            {
                Console.WriteLine("Vous décidez de revenir sur vos pas.");
            }

           
        }

        private void ChoixApresCombatDragon(Personnage personnage)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Que voulez-vous faire maintenant ?");
            Console.WriteLine("1- Rester en Auberge");
            Console.WriteLine("2- Retourner à la ville");
            Console.WriteLine("3- Quitter le jeu");

            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    Console.WriteLine("Vous allez maintenant dormir en Auberge");
                    DormirAuberge(personnage);
                    break;
                case "2":
                    Console.WriteLine("Vous allez maintenant retourner à la ville");
                    RetournerVille(personnage);
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Choix invalide. Veuillez sélectionner une option valide.");
                    ChoixApresCombatDragon(personnage);
                    break;
            }
        }

        private void DormirAuberge(Personnage personnage)
        {
            Console.WriteLine("Vous décidez de dormir en Auberge.");
            Console.WriteLine("Etes vous sur de votre choix ? (O/N)");
            string choix = Console.ReadLine().ToUpper();

            if (choix == "O")
            {
                Console.WriteLine("Vous profitez d'un kit de soin !");
                personnage.gagnerExperience(15);
                Console.WriteLine("Vous gagnez 15 points d'expérience.");
            }
            else
            {
                Console.WriteLine("Vous décidez de revenir sur vos pas.");
            }


            ChoixApresCombatDragon(personnage);
        }
        private void DiscuterAvecVillageois()
        {
            Console.WriteLine("Vous entrez dans la taverne et discutez avec les villageois.");
            Console.WriteLine("Les villageois vous racontent des histoires et des rumeurs sur la Montagne.");
            Console.WriteLine("Vous en apprenez un peu plus sur les mystères de la montagne.");

            RetourAuxChoix(personnage);
        }
        private void RetournerVille(Personnage personnage)
        {
            Console.WriteLine("Vous décidez de retourner à la ville.");
            Console.WriteLine("Vous êtes de retour à la ville. Que voulez-vous faire ?");
            Console.WriteLine("1- Visiter la taverne");
            Console.WriteLine("2- Consulter la boutique");
            Console.WriteLine("3- Retourner à l'aventure");

            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    DiscuterAvecVillageois();
                    break;
                case "2":
                    Console.WriteLine("Vous visitez la boutique et achetez de l'équipement.");
                    boutique.AfficherArticles();

                    Console.Write("Choisissez l'équipement que vous voulez acheter (1, 2, 3, 4), ou tapez 0 pour quitter : ");
                    int choixEquipement = int.Parse(Console.ReadLine());

                    if (choixEquipement == 0)
                    {
                        Console.WriteLine("Vous décidez de revenir sur vos pas.");
                    }
                    else
                    {
                        
                        boutique.AcheterArticle(personnage, choixEquipement);
                    }

                    break;
                case "3":
                    Console.WriteLine("Vous décidez de retourner à l'aventure.");
                    Jouer(personnage);
                    break;
                default:
                    Console.WriteLine("Choix invalide. Veuillez sélectionner une option valide.");
                    RetournerVille(personnage);
                    break;
            }
        }

        private void RetourMenuPrincipal(Personnage personnage)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Que voulez-vous faire maintenant ?");
            Console.WriteLine("1- Rester en Auberge");
            Console.WriteLine("2- Retourner à la ville");
            Console.WriteLine("3- Revenir au menu principal");

            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    Console.WriteLine("Vous allez maintenant dormir en Auberge");
                    DormirAuberge(personnage);
                    break;
                case "2":
                    Console.WriteLine("Vous allez maintenant retourner à la ville");
                    RetournerVille(personnage);
                    break;
                case "3":
                    RetourMenuPrincipal(personnage);
                    break;
                default:
                    Console.WriteLine("Choix invalide. Veuillez sélectionner une option valide.");
                    RetourMenuPrincipal(personnage);
                    break;
            }
        }
        private void RetourAuxChoix(Personnage personnage)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Que voulez-vous faire maintenant ?");
            Console.WriteLine("1- Rester en Auberge");
            Console.WriteLine("2- Retourner à la ville");
            Console.WriteLine("3- Revenir aux choix d'aventure");

            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    Console.WriteLine("Vous allez maintenant dormir en Auberge");
                    DormirAuberge(personnage);
                    break;
                case "2":
                    Console.WriteLine("Vous allez maintenant retourner à la ville");
                    RetournerVille(personnage);
                    break;
                case "3":
                    Console.WriteLine("Vous décidez de revenir aux choix d'aventure.");
                    CommencerAventure(personnage); // Réinitialisez l'aventure
                    break;
                default:
                    Console.WriteLine("Choix invalide. Veuillez sélectionner une option valide.");
                    RetourAuxChoix(personnage);
                    break;
            }
        }


        private void Jouer(Personnage personnage)
        {

        }

    }


}
