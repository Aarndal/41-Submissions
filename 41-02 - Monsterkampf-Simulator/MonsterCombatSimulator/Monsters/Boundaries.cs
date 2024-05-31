
namespace Monster_Combat_Simulator.Monsters
{
    internal class Boundaries
    {
        public Boundaries(float _minValue, float _maxValue)
        {
            MinValue = _minValue;
            MaxValue = _maxValue;
        }

        /// <summary>
        /// Defines the minimum value of the Property.
        /// </summary>
        public float MinValue { get; }

        /// <summary>
        /// Defines the maximum value of the Property.
        /// </summary>
        public float MaxValue { get; }

        /// <summary>
        /// Checks if the value is within the given min/max values.
        /// </summary>
        /// <param name="_value"></param>
        /// <returns>Returns true if the given value is within the boundaries.</returns>
        public bool IsWithinBoundaries(float _value)
        {
            return _value >= MinValue && _value <= MaxValue;
        }
    }
}
