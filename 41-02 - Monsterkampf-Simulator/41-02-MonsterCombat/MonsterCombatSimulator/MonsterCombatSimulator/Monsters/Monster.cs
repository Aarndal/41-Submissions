using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Combat_Simulator
{
    internal class Monster
    {
        protected static string? monsterType = null;

        /// <summary>
        /// Constructor for the Monster class.
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


        /// <summary>
        /// Defines the Monster Type of the Monster. Two Monsters of the same type cannot fight against each other.
        /// </summary>
        public static string? Type 
        { 
            get => monsterType;
            protected set
            {
                monsterType = value;
            }
        }

        /// <summary>
        /// Defines the Health Points of the Monster. If the Monster's HP drop to 0 or below, it is dead.
        /// </summary>
        public float HP { get; protected set; }

        /// <summary>
        /// Defines the Attack Power of the Monster. This is the amount of damage the Monster can deal to another Monster per Attack action.
        /// </summary>
        public float AP { get; protected set; }

        /// <summary>
        /// Defines the Defense Points of the Monster. This is the amount of damage the Monster can block from another Monster's attack per Attack action.
        /// </summary>
        public float DP { get; protected set; }

        /// <summary>
        /// Defines the Speed of the Monster. The higher the Monster's Speed, the more often it can use the Attack action per round.
        /// </summary>
        public float S { get; protected set; }

        /// <summary>
        /// Returns true if the Monster's HP are 0 or below.
        /// </summary>
        public bool IsDead { get; protected set; }

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
        /// Method to attack another Monster object. Returns the damage dealt to the other Monster.
        /// </summary>
        /// <param name="_monster"></param>
        public float Attack(Monster _monster)
        {
            float damage = AP - _monster.DP;
            if (damage <= 0) 
                return damage = 0;
            return damage;
        }

        /// <summary>
        /// Method to take damage from another Monster object. Returns true if the Monster is dead.
        /// </summary>
        /// <param name="_damage"></param>
        /// <returns></returns>
        public bool TakeDamage(float _damage)
        {
            this.HP -= _damage;
            if (this.HP <= 0)
                return IsDead = true;
            return IsDead = false;
        }
    }
}
