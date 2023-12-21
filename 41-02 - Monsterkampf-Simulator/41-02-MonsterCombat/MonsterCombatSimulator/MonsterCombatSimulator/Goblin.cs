using Monster_Combat_Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Combat_Simulator
{
    internal class Goblin: Monster
    {
        public Goblin(float _health, float _attack, float _defense, float _speed) : base(_health, _attack, _defense, _speed)
        {
            Type = "Goblin";
        }

    }
}
