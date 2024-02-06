using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Combat_Simulator.Monsters
{
    abstract class Monster
    {
        public enum MonsterType
        {
            MONSTER = 0,
            GOBLIN = 1,
            ORC = 2,
            TROLL = 3,
        }

        protected string? m_monsterType;
        private float m_healthPoints;
        private float m_attackPower;
        private float m_defensePoints;
        private float m_speed;

        /// <summary>
        /// Constructor for the Monster class.
        /// </summary>
        protected Monster(float _health, float _attack, float _defense, float _speed)
        {
            Type = "Monster";
            HP = _health;
            AP = _attack;
            DP = _defense;
            SP = _speed;
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
            protected set
            {
                m_healthPoints = value;
                if (m_healthPoints <= 0)
                    m_healthPoints = 0;
            }
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
        /// Defines the SpeedPoints of the Monster. The Monster with the higher Speed will attack first.
        /// </summary>
        public float SP
        {
            get => m_speed;
            protected set => m_speed = value;
        }

        /// <summary>
        /// Defines if the Monster is dead or not. If the Monster's HP drop to 0 or below, it returns true.
        /// </summary>
        public bool IsDead { get => this.HP <= 0; }

        public abstract Boundaries HealthBoundaries { get; }
        public abstract Boundaries AttackBoundaries { get; }
        public abstract Boundaries DefenseBoundaries { get; }
        public abstract Boundaries SpeedBoundaries { get; }

        public Monster SetStats(float _health, float _attack, float _defense, float _speed)
        {
            this.HP = _health;
            this.AP = _attack;
            this.DP = _defense;
            this.SP = _speed;

            return this;
        }

        /// <summary>
        /// Method to print the properties/stats of an object of the Monster class to the console.
        /// </summary>
        public void PrintStats()
        {
            Console.WriteLine("Hit Points: " + HP);
            Console.WriteLine("Attack Power: " + AP);
            Console.WriteLine("Defense Points: " + DP);
            Console.WriteLine("Speed Points: " + SP);
        }

        public void Attack(Monster? _target)
        {
            float dmg;

            if (_target is not null)
            {
                dmg = this.AP - _target.DP;

                if (dmg <= 0)
                    dmg = 1;

                _target.HP -= dmg;
            }
        }
    }
}
