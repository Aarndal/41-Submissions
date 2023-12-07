using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorMath
{
    public class Vector
    {
        private float x;
        private float y;
        private float z;
        private static float minFloat = MathF.Pow(10f, -6f);

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

        #region Vector Addition & Subtraction
        public static Vector operator +(Vector _vector1, Vector _vector2)
        {
            float x = _vector1.x + _vector2.x;
            float y = _vector1.y + _vector2.y;
            float z = _vector1.z + _vector2.z;
            Vector sumVector = new Vector(x, y, z);
            return sumVector;
        }
        public static Vector operator -(Vector _vector1, Vector _vector2)
        {
            Vector differenceVector = _vector1 + GetOppositeVectorOf(_vector2);
            return differenceVector;
        }
        #endregion

        #region Scalar Multiplication & Division
        public static Vector operator *(Vector _vector, float _lambda)
        {
            float x = _vector.x * _lambda;
            float y = _vector.y * _lambda;
            float z = _vector.z * _lambda;
            Vector newVector = new Vector(x, y, z);
            return newVector;
        }

        public static Vector operator *(Vector _vector, int _lambda)
        {
            float x = _vector.x * _lambda;
            float y = _vector.y * _lambda;
            float z = _vector.z * _lambda;
            Vector newVector = new Vector(x, y, z);
            return newVector;
        }

        public static Vector operator /(Vector _vector, float _lambda)
        {
            if (_lambda > minFloat || _lambda < -minFloat)         //Ask Nicolas!!!
            {
                Vector newVector = _vector * MathF.Pow(_lambda, -1f);
                return newVector;
            }
            return _vector; //ToDo
        }

        public static Vector operator /(Vector _vector, int _lambda)
        {
            if (_lambda != 0)
            {
                Vector newVector = _vector * MathF.Pow(_lambda, -1);
                return newVector;
            }
            return _vector; //ToDo
        }
        #endregion

        #region Dot Product & Cross Product
        public static float operator *(Vector _vector1, Vector _vector2)
        {
            float scalar = _vector1.x * _vector2.x
                + _vector1.y * _vector2.y
                + _vector1.z * _vector2.z;
            return scalar;
        }

        public static Vector operator %(Vector _vector1, Vector _vector2)
        {
            float x = (_vector1.y * _vector2.z) - (_vector1.z * _vector2.y);
            float y = -(_vector1.x * _vector2.z) + (_vector1.z * _vector2.x);
            float z = (_vector1.x * _vector2.y) - (_vector1.y * _vector2.x);
            Vector newVector = new Vector(x, y, z);
            return newVector;
        }
        #endregion

        public static Vector GetOppositeVectorOf(Vector _vector)
        {
            Vector inverseVector = _vector * (-1);
            return inverseVector;
        }

        public Vector OppositeDirection()
        {
            Vector inverseVector = new Vector(this.x, this.y, this.z) * (-1);
            return inverseVector;
        }

        public static float GetSqrLengthOf(Vector _vector)
        {
            float sqrLength = _vector.x * _vector.x +
                _vector.y * _vector.y +
                _vector.z * _vector.z;
            return sqrLength;
        }

        public  float SqrLength()
        {
            Vector vector = new Vector(this.x, this.y, this.z);
            float sqrLength = vector.x * vector.x +
                vector.y * vector.y +
                vector.z * vector.z;
            return sqrLength;
        }

        public static float GetLengthOf(Vector _vector)
        {
            float length = MathF.Sqrt(GetSqrLengthOf(_vector));
            return length;
        }

        public float Length()
        {
            float length = MathF.Sqrt(GetSqrLengthOf(new Vector(this.x, this.y, this.z)));
            return length;
        }

        public static Vector GetUnitVectorOf(Vector _vector)
        {
            float sqrNorm = _vector.SqrLength();
            float norm = _vector.Length();

            if (sqrNorm > minFloat)
            {
                Vector unitVector = _vector / norm;
                return unitVector;
            }
            return _vector; //ToDo
        }

        public Vector Normalize()
        {
            Vector vector = new Vector(this.x, this.y, this.z);
            float sqrNorm = vector.SqrLength();
            float norm = vector.Length();

            if (sqrNorm > minFloat)
            {
                vector = vector / norm;
                return vector;
            }
            return vector; //ToDo
        }

        public static Vector GetDirectionVector(Vector _origin, Vector _target)
        {
            Vector directionVector = GetUnitVectorOf(_target - _origin);
            return directionVector;
        }

        public static float GetDistanceBetween(Vector _origin, Vector _target)
        {
            Vector distanceVector = _target - _origin;
            float distance = distanceVector.Length();
            return distance;
        }

        public float DistanceTo(Vector _target)
        {
            Vector distanceVector = _target - new Vector(this.x, this.y, this.z);
            float distance = distanceVector.Length();
            return distance;
        }


        /*
         * Vector v1 = new Vector(0,0,0);
         * 
         * 
         * Vector normalizedVec = Vector.Normalize(v1);  // Static method
         * 
         * 
         * v1.Normalize(); // Non-static method
         * 
         * 
         * Vector normalizedVec = v1.Normalzed; // Non-static property
         */
    }
}
