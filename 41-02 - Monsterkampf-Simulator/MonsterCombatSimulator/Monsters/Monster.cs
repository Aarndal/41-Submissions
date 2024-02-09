using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Combat_Simulator.Monsters
{
    abstract class Monster
    {
        // Enum for the Monster types, to be used in the GameManager class.
        public enum MonsterType
        {
            GOBLIN = 1,
            ORC = 2,
            TROLL = 3,
        }

        // Member variables of the Monster class.
        protected string? m_monsterType;
        private float m_healthPoints, m_attackPower, m_defensePoints, m_speed;

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

        #region Properties
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

        // Properties for the min/max values of the Monster's stats.
        public abstract Boundaries HealthBoundaries { get; }
        public abstract Boundaries AttackBoundaries { get; }
        public abstract Boundaries DefenseBoundaries { get; }
        public abstract Boundaries SpeedBoundaries { get; }
        #endregion

        #region Methods
        /// <summary>
        /// Method to attack another Monster object and deal damage to it.
        /// </summary>
        /// <param name="_target">Targeted Monster object.</param>
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

        /// <summary>
        /// Checks if the user's input for the Monster's stat is valid and within the given boundaries.
        /// </summary>
        /// <param name="_statName"></param>
        /// <param name="_boundaries"></param>
        /// <returns></returns>
        public static float CheckStatInput(Boundaries _boundaries, string _statName)
        {
            do
            {
                $"{_statName} (Min: {_boundaries.MinValue} | Max: {_boundaries.MaxValue}): ".Write();

                if (!float.TryParse(s: Console.ReadLine(), result: out float statInput) || !_boundaries.IsWithinBoundaries(statInput))
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ConsoleEx.ClearCurrentConsoleLine();
                }
                else
                    return statInput;

            } while (true);
        }

        /// <summary>
        /// Creates a new object of the Monster class, depending on the given Monster Type.
        /// </summary>
        /// <param name="_type"></param>
        /// <returns>Returns either a Goblin, Orc, or Troll.</returns>
        public static Monster? CreateMonster(MonsterType _type)
        {
            return _type switch
            {
                MonsterType.GOBLIN => new Goblin(),
                MonsterType.ORC => new Orc(),
                MonsterType.TROLL => new Troll(),
                _ => null,
            };
        }

        /// <summary>
        /// Method to print the properties/stats of an object of the Monster class to the console.
        /// </summary>
        public void PrintStats()
        {
            Console.WriteLine("Hit Points: " + this.HP);
            Console.WriteLine("Attack Power: " + this.AP);
            Console.WriteLine("Defense Points: " + this.DP);
            Console.WriteLine("Speed Points: " + this.SP);
        }

        /// <summary>
        /// Sets the stats of the Monster object.
        /// </summary>
        public void SetStats()
        {
            this.HP = CheckStatInput(this.HealthBoundaries, "Hit Points");
            this.AP = CheckStatInput(this.AttackBoundaries, "Attack Power");
            this.DP = CheckStatInput(this.DefenseBoundaries, "Defense Points");
            this.SP = CheckStatInput(this.SpeedBoundaries, "Speed Points");
        }
        #endregion
    }
}
