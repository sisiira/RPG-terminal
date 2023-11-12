using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPPPPP
{
    public class Aventure
    {
        public string Titre { get; set; }
        public string Description { get; set; }

        public Aventure(string titre, string description)
        {
            Titre = titre;
            Description = description;
        }

        public void CommencerAventure(Personnage personnage)
        {
            Console.WriteLine("Vous commencez l'aventure : " + Titre);
            Console.WriteLine(Description);
            // Ajoutez ici la logique de l'aventure
            // Par exemple, des choix à faire, des ennemis à combattre, etc.
        }
    }

}
