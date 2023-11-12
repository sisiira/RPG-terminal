using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPPPPP
{
    public class Necromant : Personnage
    {
        public Necromant(string nom) : base(nom)
        {
            HP = 310;
            mana = 248;
            defense = 31;
            degats = 38;
        }
    }
}
