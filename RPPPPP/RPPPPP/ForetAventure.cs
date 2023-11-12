using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPPPPP
{
    public class ForetAventure : Aventure
    {
        public ForetAventure() : base("Aventure en Forêt", "Vous entrez dans une forêt sombre et mystérieuse.")
        {
        }

        public override void CommencerAventure(Personnage personnage)
        {
            Console.WriteLine("Vous commencez l'aventure : " + Titre);
            Console.WriteLine(Description);

            Console.WriteLine("Vous trouvez un coffre caché. Que voulez-vous faire?");
            Console.WriteLine("1- Ouvrir le coffre");
            Console.WriteLine("2- Continuer votre chemin");

            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    Console.WriteLine("Vous avez trouvé un trésor !");
                    personnage.gagnerExperience(10);
                    Console.WriteLine("Vous gagnez 10 points d'expérience.");
                    break;
                case "2":
                    Console.WriteLine("Vous continuez votre chemin.");
                    break;
            }
        }
    }


}

