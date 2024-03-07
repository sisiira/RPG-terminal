using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPPPPP
{
    public class Boutique
    {
        private List<Equipement> articles;

        public Boutique()
        {
            articles = new List<Equipement>
        {
            new Equipement("Épée en fer", 50),
            new Equipement("Armure légère", 30),
            new Equipement("Potion de guérison", 10),
            new Equipement("Baton magique",15)
        };
        }

        public void AfficherArticles()
        {
            Console.WriteLine("Articles disponibles à la boutique :");
            for (int i = 0; i < articles.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {articles[i].Nom} - Prix : {articles[i].Prix} pièces d'or");
            }
        }

        public void AcheterArticle(Personnage personnage, int choix)
        {
            if (choix >= 1 && choix <= articles.Count)
            {
                Equipement article = articles[choix - 1];

                if (personnage.PiecesOr >= article.Prix)
                {
                    personnage.AcheterEquipement(article);
                    Console.WriteLine($"Vous avez acheté {article.Nom}.");
                    Console.WriteLine($"Vous avez maintenant {personnage.PiecesOr} pièces d'or.");
                    personnage.PiecesOr -= article.Prix;
                }
                else
                {
                    Console.WriteLine("Vous n'avez pas assez de pièces d'or pour acheter cet article.");
                }
            }
            else
            {
                Console.WriteLine("Choix invalide. Veuillez sélectionner un article valide.");
            }
        }

    }

}
