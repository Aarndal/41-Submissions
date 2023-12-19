using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Combat_Simulator
{
    internal class Monster
    {
        protected Monster(float _health, float _attack, float _defense, float _speed)
        {
            HP = _health;
            AP = _attack;
            DP = _defense;
            S = _speed;
        }

        public float HP { get; set; }
        public float AP { get; set; }
        public float DP { get; set; }
        public float S { get; set; }
        
        public void PrintStats()
        {
            Console.WriteLine("Health Points: " + HP);
            Console.WriteLine("Attack Power: " + AP);
            Console.WriteLine("Defense Points: " + DP);
            Console.WriteLine("Speed: " + S);
        }

        public void Attack(Monster _monster)
        {
            float damage = AP - _monster.DP;
            if (damage < 0)
            {
                damage = 0;
            }
            _monster.HP -= damage;
        }
    }
}
