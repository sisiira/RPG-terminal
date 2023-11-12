using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPPPPP
{
    public class Assassin : Personnage
    {
        public Assassin(string nom) : base(nom)
        {
            HP = 10;
            mana = 120;
            defense = 38;
            degats = 23;

        }
    }
}
