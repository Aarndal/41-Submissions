using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    public class Vector
    {
        private float x;
        private float y;
        private float z;

        public Vector()
        {
            x = 0;
            y = 0;
            z = 0;
        }
        public Vector(float _x, float _y, float _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }

        public Vector(float _x, float _y)
        {
            x = _x;
            y = _y;
            z = 0;
        }

        public static Vector operator +(Vector _v1, Vector _v2)
        {
            float x = _v1.x + _v2.x;
            float y = _v1.y + _v2.y;
            float z = _v1.z + _v2.z;
            Vector sumVector = new Vector(x, y, z);
            return sumVector;
        }
        public static Vector operator -(Vector _v1, Vector _v2)
        {
            Vector differenceVector = _v1 + Inverse(_v2);
            return differenceVector;
        }

        public static Vector operator *(Vector _v, float _lambda)
        {
            float x = _v.x * _lambda;
            float y = _v.y * _lambda;
            float z = _v.z * _lambda;
            Vector newVector = new Vector(x, y, z);
            return newVector;
        }

        public static Vector operator *(Vector _v, int _lambda)
        {
            float x = _v.x * _lambda;
            float y = _v.y * _lambda;
            float z = _v.z * _lambda;
            Vector newVector = new Vector(x, y, z);
            return newVector;
        }

        public static float operator *(Vector _v1, Vector _v2)
        {
            float scalar = _v1.x * _v2.x
                + _v1.y * _v2.y
                + _v1.z * _v2.z;
            return scalar;
        }

        public static Vector Inverse(Vector _v)
        {
            Vector inverseVector = _v * (-1);
            return inverseVector;
        }

        public static float SqrLength(Vector _v)
        {
            float sqrLength = _v.x * _v.x + _v.y * _v.y + _v.z * _v.z;
            return sqrLength;
        }

        public static float Length(Vector _v)
        {
            float length = MathF.Sqrt(SqrLength(_v));
            return length;
        }

        public static float Magnitude(Vector _v)
        {
            float magnitude = Length(_v);
            return magnitude;
        }

        public static Vector Normalize(Vector _v)
        {
            Vector normVector = new Vector();
            float magV = Length(_v);
            if (magV > MathF.Pow(10f, -6f))         //Ask Nicolas!!!
            {
                normVector = new Vector(_v.x / magV,
                _v.y / magV,
                _v.z / magV);
                return normVector;
            }
            return normVector;
        }

        public static float Distance(Vector _v1, Vector _v2)
        {
            float distance = Length(_v1 - _v2);
            return distance;
        }

    }
}
