using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPPPPP
{
    internal class Monstre : Entity
    {
        public Monstre(string nom) : base(nom)
        {
            this.nom = nom;
            this.HP = 110;
            this.mana = 90;
            this.defense = 15;
            this.degats = 11;
        }
    }
}
