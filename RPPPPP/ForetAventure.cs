using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPPPPP
{
    public class ForetAventure : Aventure
    {
        private Monstre Ogre;
        private Boutique boutique;
        public ForetAventure() : base("Aventure en Forêt", "Vous entrez dans une forêt sombre et mystérieuse.")
        {
            Ogre = new Monstre("Ogre de la foret");
            boutique = new Boutique();
        }

        public override void CommencerAventure(Personnage personnage)
        {
            Console.WriteLine("Vous commencez l'aventure : " + Titre);
            Console.WriteLine(Description);

            Console.WriteLine("Vous trouvez un coffre caché. Que voulez-vous faire?");
            Console.WriteLine("1- Ouvrir le coffre");
            Console.WriteLine("2- Continuer votre chemin");
            Console.WriteLine("3- Ouvrir la boite mystèrieuse");

            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    Console.WriteLine("Vous avez trouvé un trésor !");
                    personnage.gagnerExperience(10);
                    Console.WriteLine("Vous gagnez 10 points d'expérience.");
                    RetourAuxChoixApresCoffre(personnage);
                    break;
                case "2":
                    Console.WriteLine("Vous continuez votre chemin.");
                    break;
                case "3":
                    Console.WriteLine("L'OGRE vous a piégé!");
                    CombatAventure(personnage, Ogre);
                    break;
            }
        }


        private void CombatAventure(Personnage personnage, Monstre Ogre)
        {
            while (!personnage.EstMort() && !Ogre.EstMort())
            {
                Console.ForegroundColor = ConsoleColor.White;
                Ogre.Attaque(personnage);
                Console.WriteLine();
                Console.ReadKey(true);

                if (personnage.EstMort())
                {
                    Console.WriteLine("Vous avez été vaincu par l'Ogre !");
                    Console.ReadKey();
                    RetourMenuPrincipal(personnage);
                    return;
                }

                Console.ForegroundColor = ConsoleColor.White;
                personnage.Attaque(Ogre);
                Console.WriteLine();
                Console.ReadKey(true);
            }

            if (!personnage.EstMort())
            {
                Console.WriteLine("Vous avez vaincu l'Ogre !");
                personnage.gagnerExperience(20);
                Console.WriteLine("Vous gagnez 20 points d'expérience.");
                ChoixApresCombat(personnage);
            }
        }
        private void RetourMenuPrincipal(Personnage personnage)
        {
            Console.WriteLine("Vous retournez au menu principal.");
            CommencerAventure(personnage);
        }

        private void ChoixApresCombat(Personnage personnage)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Que voulez-vous faire maintenant ?");
            Console.WriteLine("1- Explorer davantage la forêt");
            Console.WriteLine("2- Retourner à la ville");
            Console.WriteLine("3- Quitter le jeu");

            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    Console.WriteLine("Vous allez maintenant à l'autre coté de la foret");
                    ExplorerForet(personnage);
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
                    ChoixApresCombat(personnage);
                    break;
            }
        }
        private void ExplorerForet(Personnage personnage)
        {
            Console.WriteLine("Vous décidez d'explorer davantage la forêt.");
            Console.WriteLine("Vous trouvez un sentier mystérieux. Voulez-vous le suivre ? (O/N)");
            string choix = Console.ReadLine().ToUpper();

            if (choix == "O")
            {
                Console.WriteLine("Vous avez découvert un trésor caché dans une vieille cabane !");
                personnage.gagnerExperience(15);
                Console.WriteLine("Vous gagnez 15 points d'expérience.");
            }
            else
            {
                Console.WriteLine("Vous décidez de revenir sur vos pas.");
            }

            ChoixApresCombat(personnage);
            RetourAuxChoix(personnage);
        }

        private void DiscuterAvecVillageois()
        {
            Console.WriteLine("Vous entrez dans la taverne et discutez avec les villageois.");
            Console.WriteLine("Les villageois vous racontent des histoires et des rumeurs sur la forêt.");
            Console.WriteLine("Vous en apprenez un peu plus sur les mystères de la forêt.");
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
        private void RetourAuxChoix(Personnage personnage)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Que voulez-vous faire maintenant ?");
            Console.WriteLine("1- Explorer davantage la forêt");
            Console.WriteLine("2- Retourner à la ville");
            Console.WriteLine("3- Revenir aux choix d'aventure");

            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    Console.WriteLine("Vous allez maintenant à l'autre coté de la forêt");
                    ExplorerForet(personnage);
                    break;
                case "2":
                    Console.WriteLine("Vous allez maintenant retourner à la ville");
                    RetournerVille(personnage);
                    break;
                case "3":
                    Console.WriteLine("Vous décidez de revenir aux choix d'aventure.");
                    CommencerAventure(personnage);
                    break;
                default:
                    Console.WriteLine("Choix invalide. Veuillez sélectionner une option valide.");
                    RetourAuxChoix(personnage);
                    break;
            }
        }
        private void RetourAuxChoixApresCoffre(Personnage personnage)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Que voulez-vous faire maintenant ?");
            Console.WriteLine("1- Explorer davantage la forêt");
            Console.WriteLine("2- Retourner à la ville");
            Console.WriteLine("3- Revenir aux choix d'aventure");

            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    Console.WriteLine("Vous allez maintenant à l'autre côté de la forêt");
                    ExplorerForet(personnage);
                    break;
                case "2":
                    Console.WriteLine("Vous allez maintenant retourner à la ville");
                    RetournerVille(personnage);
                    break;
                case "3":
                    Console.WriteLine("Vous décidez de revenir aux choix d'aventure.");
                    CommencerAventure(personnage);
                    break;
                default:
                    Console.WriteLine("Choix invalide. Veuillez sélectionner une option valide.");
                    RetourAuxChoixApresCoffre(personnage);
                    break;
            }
        }





        private void Jouer(Personnage personnage)
        {
         
        }

    }


}

