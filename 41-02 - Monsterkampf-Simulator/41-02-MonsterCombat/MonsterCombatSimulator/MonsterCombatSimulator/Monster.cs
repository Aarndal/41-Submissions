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
            Type = null;
            HP = _health;
            AP = _attack;
            DP = _defense;
            S = _speed;
        }

        protected static string monsterType = null;

        // Properties for the Monster class.
        
        /// <summary>
        /// Defines the Monster Type of the Monster. Two Monsters of the same type cannot fight against each other.
        /// </summary>
        public static string Type { 
            get => monsterType;
            protected set
            {
                monsterType = value;
            }
        }

        /// <summary>
        /// Defines the Health Points of the Monster. If the Monster's HP drop to 0 or below, it is dead.
        /// </summary>
        public float HP { get; set; }

        /// <summary>
        /// Defines the Attack Power of the Monster. This is the amount of damage the Monster can deal to another Monster per Attack action.
        /// </summary>
        public float AP { get; set; }

        /// <summary>
        /// Defines the Defense Points of the Monster. This is the amount of damage the Monster can block from another Monster's attack per Attack action.
        /// </summary>
        public float DP { get; set; }

        /// <summary>
        /// Defines the Speed of the Monster. The higher the Monster's Speed, the more often it can use the Attack action per round.
        /// </summary>
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
