using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPPPPP
{
    public class Guerrier : Personnage
    {
        public Guerrier(string nom) : base(nom)
        {
            HP = 410;
            mana = 240;
            defense = 49;
            degats = 18;
        }
    }
}
