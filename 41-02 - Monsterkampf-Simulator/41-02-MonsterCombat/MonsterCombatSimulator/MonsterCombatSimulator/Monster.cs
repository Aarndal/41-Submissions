using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Combat_Simulator
{
    internal class Monster
    {
        /// <summary>
        /// Constructor for the Monster class. Takes in 4 floats and sets them to the appropriate properties.
        /// </summary>
        /// <param name="_health"></param>
        /// <param name="_attack"></param>
        /// <param name="_defense"></param>
        /// <param name="_speed"></param>
        protected Monster(float _health, float _attack, float _defense, float _speed)
        {
            HP = _health;
            AP = _attack;
            DP = _defense;
            S = _speed;
        }

        /// <summary>
        /// Properties for the Monster class. HP, AP, DP, and S. HP is Health Points, AP is Attack Power, DP is Defense Points, and S is Speed.
        /// </summary>
        public float HP { get; set; }
        public float AP { get; set; }
        public float DP { get; set; }
        public float S { get; set; }
        
        /// <summary>
        /// Method to print the properties/stats of an object of the Monster class to the console.
        /// </summary>
        public void PrintStats()
        {
            Console.WriteLine("Health Points: " + HP);
            Console.WriteLine("Attack Power: " + AP);
            Console.WriteLine("Defense Points: " + DP);
            Console.WriteLine("Speed: " + S);
        }

        /// <summary>
        /// Method to attack another Monster object. Takes in a Monster object and subtracts the attacking Monster's AP from the defending Monster's HP.
        /// </summary>
        /// <param name="_monster"></param>
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
