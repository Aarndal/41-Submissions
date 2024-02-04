using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Combat_Simulator.Monsters
{
    internal class Boundaries
    {
        public Boundaries(float _minValue, float _maxValue)
        {
            MinValue = _minValue;
            MaxValue = _maxValue;
        }
        
        public float MinValue
        {
            get;
        }

        public float MaxValue
        {
            get;
        }

        public bool IsWithinBoundaries(float _value)
        {
            return _value >= MinValue && _value <= MaxValue;
        }
    }
}
