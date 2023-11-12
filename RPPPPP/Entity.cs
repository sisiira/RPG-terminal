using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPPPPP
{
    public abstract class Entity
    {
        protected string nom;

        protected int HP;

        protected bool estMort = false;

        protected int degats;

        protected int defense;

        protected int mana;

        protected Random random = new Random();

        public Entity(string nom)
        {
            this.nom = nom;
        }

        public void Attaque(Entity entite)
        {
            int degatss = random.Next(degats);

            entite.PerdreHP(degatss);
            Console.WriteLine(this.nom + " (" + this.HP + ")" + " Attaque : " + entite.nom);
            Console.WriteLine(entite.nom + " a perdu " + degatss + " hp");
            Console.WriteLine(" il reste " + entite.HP + " HP à " + entite.nom);
            if (entite.estMort)
            {
                Console.WriteLine(entite.nom + " est mort");
            }
        }

        protected void PerdreHP(int HP)
        {
            this.HP -= HP;
            if (this.HP <= 0)
            {
                this.HP = 0;
                estMort = true;
            }
        }

        public bool EstMort()
        {
            return this.estMort;
        }





    }
}
