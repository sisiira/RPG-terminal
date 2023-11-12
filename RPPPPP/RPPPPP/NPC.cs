using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPPPPP
{
    public class NPC : Entity
    {
        public NPC(string nom) : base(nom)
        {
            HP = 10;
        }

        public void Parler()
        {
            Console.WriteLine(nom + ": Bonjour, aventurier!");
        }

    }

}
