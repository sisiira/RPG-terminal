using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPPPPP
{
    public abstract class Personnage : Entity
    {
        public int Niveau;
        private int experience;

        public Personnage(string nom) : base(nom)
        {
            this.nom = nom;
            Niveau = 1;
            experience = 0;
        }
        public void gagnerExperience(int experience)
        {
            this.experience += experience;
            while (this.experience >= experienceRequise())
            {
                Niveau += 1;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Vous avez atteint un nouveau niveau" + Niveau + "!");

                HP += 24;
                mana += 10; 
                defense += 10;
                degats += 11;
            }
        }

        public double experienceRequise()
        {
            return Math.Round(4 * (Math.Pow(Niveau, 3) / 5));
        }
         
        public int GetLevel(int level)
        {
            return level;
        }

        public string Stats()
        {
            return this.nom + "\n" +
            "HP : " + HP + "\n" +
            "Niveau : " + Niveau + "\n" +
            "Experiences : (" + experience + "/" + experienceRequise() + ")\n" +
            "Degats : " + degats + "\n";

        }


    }
}
