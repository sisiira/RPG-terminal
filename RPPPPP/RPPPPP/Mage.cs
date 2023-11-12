using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPPPPP
{
    public class Mage : Personnage
    {
        public Mage(string nom) : base(nom)
        {
            HP = 108;
            mana = 290;
            defense = 22;
            degats = 39;
        }
    }
}
