using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Combat_Simulator
{
    internal class Monster
    {
        protected string? m_monsterType;
        private float m_healthPoints;
        private float m_attackPower;
        private float m_defensePoints;
        private float m_speed;

        /// <summary>
        /// Constructor for the Monster class.
        /// </summary>
        protected Monster()
        {
            Type = "Monster";

        }

        /// <summary>
        /// Defines the Monster Type of the Monster. Two Monsters of the same type cannot fight against each other.
        /// </summary>
        public string? Type
        {
            get => m_monsterType;
            protected set => m_monsterType = value;
        }

        /// <summary>
        /// Defines the Health Points of the Monster. If the Monster's HP drop to 0 or below, it is dead.
        /// </summary>
        public float HP
        {
            get => m_healthPoints;
            protected set => m_healthPoints = value;
        }

        /// <summary>
        /// Defines the Attack Power of the Monster. This is the amount of damage the Monster can deal to another Monster per Attack action.
        /// </summary>
        public float AP
        {
            get => m_attackPower;
            protected set => m_attackPower = value;
        }

        /// <summary>
        /// Defines the Defense Points of the Monster. This is the amount of damage the Monster can block from another Monster's attack per Attack action.
        /// </summary>
        public float DP
        {
            get => m_defensePoints;
            protected set => m_defensePoints = value;
        }

        /// <summary>
        /// Defines the Speed of the Monster. The higher the Monster's Speed, the more often it can use the Attack action per round.
        /// </summary>
        public float S
        {
            get => m_speed;
            protected set => m_speed = value;
        }

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

        public void Attack(Monster _target)
        {
            float dmg;
            dmg = this.AP - _target.DP;

            if (dmg <= 0)
                dmg = 1;

            _target.HP -= dmg;
            if (_target.HP <= 0)
                _target.HP = 0;
            // !!! To-DO: Include in HP Property
        }

        public void IsMonsterDead()
        {
            if (this.HP <= 0)
                this.IsDead = true;
            this.IsDead = false;
        }
    }
}
