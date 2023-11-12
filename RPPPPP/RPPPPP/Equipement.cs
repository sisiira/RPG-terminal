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
        public int BonusHP { get; set; }
        public int BonusDegats { get; set; }
        public int BonusDefense { get; set; }
        public int BonusMana { get; set; }

        public Equipement(string nom, int bonusHP, int bonusDegats, int bonusDefense, int bonusMana)
        {
            Nom = nom;
            BonusHP = bonusHP;
            BonusDegats = bonusDegats;
            BonusDefense = bonusDefense;
            BonusMana = bonusMana;
        }
    }

}
