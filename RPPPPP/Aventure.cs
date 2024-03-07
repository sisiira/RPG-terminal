using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPPPPP
{
    public abstract class Aventure
    {
        public string Titre { get; set; }
        public string Description { get; set; }

        public Aventure(string titre, string description)
        {
            Titre = titre;
            Description = description;
        }

        public abstract void CommencerAventure(Personnage personnage);
    }

}
