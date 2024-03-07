using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPPPPP
{
    public class Equipement
    {
        public string Nom { get; set; }
        public int Prix { get; set; }

        public Equipement(string nom, int prix)
        {
            Nom = nom;
            Prix = prix;
        }
    }

}
