using Monster_Combat_Simulator.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Combat_Simulator
{
    internal class Goblin: Monster
    {
        private static readonly Boundaries m_healthBoundaries = new( 4, 5);
        private static readonly Boundaries m_attackBoundaries = new( 4, 5);
        private static readonly Boundaries m_defenseBoundaries = new( 4, 5);
        private static readonly Boundaries m_speedBoundaries = new( 4, 5);

        public Goblin() 
            : base(0, 0, 0, 0)
        {
            Type = "Goblin";
        }

        public override Boundaries HealthBoundaries
        {
            get => m_healthBoundaries;
        }

        public override Boundaries AttackBoundaries
        {
            get => m_attackBoundaries;
        }
        public override Boundaries DefenseBoundaries
        {
            get => m_defenseBoundaries;
        }
        public override Boundaries SpeedBoundaries
        {
            get => m_speedBoundaries;
        }
    }
}
