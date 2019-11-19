using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HEROGAME
{
    public struct Monstr
    {
        public double Health;    // здоровье монстра
        public double Stength;       // сила монстра
        public Monstr(double health, double stength)
        {
            this.Health = health;
            this.Stength = stength;
        }
        public double hitHero(Hero hero) // метод удара игрока
        {
            double uron = Math.Round(this.Stength * (hero.Agility / 50), 0);
            hero.Health -= uron;
            hero.ActivityStatus = "Получиен урон";
            return uron;
        }

        public void writeMonstr(Gameplay gameplay)
        {
            Math.Round(this.Health, 0);
            Math.Round(this.Health, 0);
            gameplay.label23.Text = Math.Round(this.Health, 0).ToString();
            gameplay.label22.Text = Math.Round(this.Stength, 0).ToString();

        }
    }
}
