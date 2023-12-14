using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorMath
{
    public class Vector
    {
        private static float minFloat = MathF.Pow(10f, -6f);
        private float x;
        private float y;
        private float z;

        public enum CartesianAxis
        {
            X,
            Y,
            Z
        }

        #region Constructors
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
        #endregion

        #region StandardVectors
        public static Vector Zero
        {
            get
            {
                Vector vector = new Vector();
                return vector;
            }
        }

        public static Vector StdUnitVectorX
        {
            get
            {
                Vector vector = new Vector(1, 0, 0);
                return vector;
            }
        }

        public static Vector StdUnitVectorY
        {
            get
            {
                Vector vector = new Vector(0, 1, 0);
                return vector;
            }
        }

        public static Vector StdUnitVectorZ
        {
            get
            {
                Vector vector = new Vector(0, 0, 1);
                return vector;
            }
        }
        #endregion

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
            Vector differenceVector = _vector1 + GetOppositeVector(_vector2);
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
            //float x = _vector.x * _lambda;
            //float y = _vector.y * _lambda;
            //float z = _vector.z * _lambda;
            //Vector newVector = new Vector(x, y, z);
            Vector newVector = _vector * _lambda;
            return newVector;
        }

        public static Vector operator /(Vector _vector, float _lambda)
        {
            if (_lambda > minFloat || _lambda < -minFloat) //minFloat is used to avoid division by zero
            {
                Vector newVector = _vector * MathF.Pow(_lambda, -1f);
                return newVector;
            }
            return _vector; //ToDo: null Abfrage
        }

        public static Vector operator /(Vector _vector, int _lambda)
        {
            if (_lambda != 0)
            {
                Vector newVector = _vector * MathF.Pow(_lambda, -1);
                return newVector;
            }
            return _vector; //ToDo: null Abfrages
        }
        #endregion

        #region DotProduct & CrossProduct

        // Dot Product
        public static float operator *(Vector _vector1, Vector _vector2)
        {
            float scalar = _vector1.x * _vector2.x
                + _vector1.y * _vector2.y
                + _vector1.z * _vector2.z;
            return scalar;
        }

        // Cross Product
        public static Vector operator %(Vector _vector1, Vector _vector2)
        {
            float x = (_vector1.y * _vector2.z) - (_vector1.z * _vector2.y);
            float y = -(_vector1.x * _vector2.z) + (_vector1.z * _vector2.x);
            float z = (_vector1.x * _vector2.y) - (_vector1.y * _vector2.x);
            Vector newVector = new Vector(x, y, z);
            return newVector;
        }
        #endregion

        #region OppositeVector
        public static Vector GetOppositeVector(Vector _vector)
        {
            Vector oppositeVector = _vector * (-1);
            return oppositeVector;
        }

        //Turns the given vector by 180°
        private Vector Turn() //Change name to GetOppositeDirection?
        {
            Vector oppositeVector = new Vector(this.x, this.y, this.z) * (-1);
            return oppositeVector;
        }

        public Vector Turned //Change name to Opposite?
        {
            get
            {
                return this.Turn();
            }
        }
        #endregion

        #region Length & SqrLength
        public static float GetSqrLength(Vector _vector)
        {
            float sqrLength = _vector.x * _vector.x +
                _vector.y * _vector.y +
                _vector.z * _vector.z;
            return sqrLength;
        }

        private float GetSqrLength()
        {
            Vector vector = new Vector(this.x, this.y, this.z);
            float sqrLength = vector.x * vector.x +
                vector.y * vector.y +
                vector.z * vector.z;
            return sqrLength;
        }

        public float SqrLength
        {
            get
            {
                return this.GetSqrLength();
            }
        }

        public static float GetLength(Vector _vector)
        {
            float length = MathF.Sqrt(GetSqrLength(_vector));
            return length;
        }

        private float GetLength()
        {
            float length = MathF.Sqrt(GetSqrLength(new Vector(this.x, this.y, this.z)));
            return length;
        }
        public float Length
        {
            get
            {
                return this.GetLength();
            }
        }
        #endregion

        #region UnitVector
        public static Vector GetUnitVector(Vector _vector)
        {
            if (_vector.SqrLength > minFloat)
            {
                Vector unitVector = _vector / MathF.Sqrt(_vector.SqrLength);
                return unitVector;
            }
            return _vector; //ToDo: null Abfrage
        }

        private Vector Normalize()
        {
            if (this.SqrLength > minFloat)
            {
                Vector vector = this / MathF.Sqrt(this.SqrLength);
                return vector;
            }
            return this; //ToDo: null Abfrage
        }

        public Vector Normalized
        {
            get
            {
                return this.Normalize();
            }
        }
        #endregion

        #region DirectionVector & Distance
        public static Vector GetDirectionVector(Vector _origin, Vector _target)
        {
            Vector directionVector = GetUnitVector(_target - _origin);
            return directionVector;
        }

        public static float GetDistanceBetween(Vector _origin, Vector _target)
        {
            Vector distanceVector = _target - _origin;
            float distance = distanceVector.Length;
            return distance;
        }

        public float GetDistanceTo(Vector _target)
        {
            Vector distanceVector = _target - this;
            float distance = distanceVector.Length;
            return distance;
        }
        #endregion
        
        #region Projection
        public static Vector GetProjectionVector(Vector _origin, Vector _target)
        {
            _target = _target.Normalized;
            Vector projectionVector = _target * (_origin * _target);
            return projectionVector;
        }

        public Vector ProjectOn(Vector _target)
        {
            _target = _target.Normalized;
            Vector projectionVector = _target * (this * _target);
            return projectionVector;
        }

        public Vector ProjectOnAxis(CartesianAxis _axis)
        {
            Vector unitVector = new Vector();

            switch (_axis)
            {
                case CartesianAxis.X:
                    unitVector = StdUnitVectorX;
                    break;
                case CartesianAxis.Y:
                    unitVector = StdUnitVectorY;

                    break;
                case CartesianAxis.Z:
                    unitVector = StdUnitVectorZ;
                    break;
                default:
                    break;
            }
            Vector projectionVector = unitVector * (this * unitVector);
            return projectionVector;
        }
        #endregion

        #region Angles
        public static float GetAngleBetween(Vector _origin, Vector _target)
        {
            float dotProduct = _origin * _target;
            float sqrCosPhi = (dotProduct * dotProduct) / (_origin.SqrLength * _target.SqrLength);
            float angle = MathF.Round((MathF.Acos(MathF.Sqrt(sqrCosPhi)) * 180) / MathF.PI, 4, MidpointRounding.AwayFromZero);
            return angle;

            //ToDO: null Abfrage für Betrag von origin und target
        }

        public static float GetSignedAngleBetween(Vector _origin, Vector _target, CartesianAxis _rotationAxis)
        {
            //gets the "direct" angle between two vectors
            float angle = GetAngleBetween(_origin, _target);

            //gets the axis to define the sign of the angle in regards of a right hand coordinate system
            Vector rotationAxis = new Vector();
            switch (_rotationAxis)
            {
                case CartesianAxis.X:
                    rotationAxis = StdUnitVectorX;
                    break;
                case CartesianAxis.Y:
                    rotationAxis = StdUnitVectorY;

                    break;
                case CartesianAxis.Z:
                    rotationAxis = StdUnitVectorZ;
                    break;
                default:
                    break;
            }

            //checks if the angle is positive or negative in regards of the rotation axis (right hand coordinate system) and returns the signed angle
            float tripleProduct = (_origin % _target) * rotationAxis;
            if (tripleProduct < minFloat)
            {
                angle = -angle;
            }
            return angle;
        }

        public float GetAngleTo(Vector _target)
        {
            float dotProduct = this * _target;
            float sqrCosPhi = (dotProduct * dotProduct) / (this.SqrLength * _target.SqrLength);
            float angle = MathF.Round((MathF.Acos(MathF.Sqrt(sqrCosPhi)) * 180) / MathF.PI, 4, MidpointRounding.AwayFromZero);
            return angle;

            //ToDO: null Abfrage für Betrag von origin und target
        }

        public float GetSignedAngleTo(Vector _target, CartesianAxis _rotationAxis)
        {
            //gets the "direct" angle between two vectors
            float angle = GetAngleBetween(this, _target);

            //gets the axis to define the sign of the angle in regards of a right hand coordinate system
            Vector rotationAxis = new Vector();
            switch (_rotationAxis)
            {
                case CartesianAxis.X:
                    rotationAxis = StdUnitVectorX;
                    break;
                case CartesianAxis.Y:
                    rotationAxis = StdUnitVectorY;

                    break;
                case CartesianAxis.Z:
                    rotationAxis = StdUnitVectorZ;
                    break;
                default:
                    break;
            }

            //checks if the angle is positive or negative in regards of the rotation axis (right hand coordinate system) and returns the signed angle
            float tripleProduct = (this % _target) * rotationAxis;
            if (tripleProduct < minFloat)
            {
                angle = -angle;
            }
            return angle;
        }

        //public float GetSignedAngleTo(Vector _target)
        //{
        //    //gets the "direct" angle between two vectors
        //    float angle = GetAngleBetween(this, _target);
        //    Vector crossProduct = this % _target;
        //    Vector [] cartesianAxes = new Vector[] { StdUnitVectorX, StdUnitVectorY, StdUnitVectorZ };

        //    foreach (Vector axis in cartesianAxes)
        //    {
                
        //    }

        //    for (int i = 0; i < cartesianAxes.Length-1; i++)
        //    {
        //        cartesianAxes[i] = cartesianAxes[i].ProjectOnAxis((CartesianAxis)i);
        //    }

            
            
        //    //gets the axis to define the sign of the angle in regards of a right hand coordinate system
        //    //Vector rotationAxis = new Vector();
        //    //switch (_rotationAxis)
        //    //{
        //    //    case CartesianAxis.X:
        //    //        rotationAxis = StdUnitVectorX;
        //    //        break;
        //    //    case CartesianAxis.Y:
        //    //        rotationAxis = StdUnitVectorY;

        //    //        break;
        //    //    case CartesianAxis.Z:
        //    //        rotationAxis = StdUnitVectorZ;
        //    //        break;
        //    //    default:
        //    //        break;
        //    //}

        //    //checks if the angle is positive or negative in regards of the rotation axis (right hand coordinate system) and returns the signed angle
        //    float tripleProduct = crossProduct * rotationAxis;
        //    if (tripleProduct < minFloat)
        //    {
        //        angle = -angle;
        //    }
        //    return angle;
        //}
        #endregion


        public bool IsNullVector
        {
            get
            {
                if (this.x == 0 && this.y == 0 && this.z == 0)
                {
                    return true;
                }
                return false;
            }
        }

        public bool IsOrthogonalTo(Vector _vector)
        {
            if (this * _vector == 0)
            {
                return true;
            }
            return false;
        }

        //nochmal drüber nachdenken
        //public bool IsCollinearTo(Vector _vector)
        //{
        //    if (this.Normalized == _vector.Normalized || this.Normalized == _vector.Normalized.Turned)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //public bool IsParallelTo(Vector _vector)
        //{
        //    float dotProduct = this * _vector;
        //    if (this.IsCollinearTo(_vector) && dotProduct > 0)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //public bool IsAntiparallelTo(Vector _vector)
        //{
        //    float dotProduct = this * _vector;
        //    if (this.IsCollinearTo(_vector) && dotProduct < 0)
        //    {
        //        return true;
        //    }
        //    return false;
        //}


        //public bool IsOppositeTo(Vector _vector)
        //{
        //    if (this.Normalized == _vector.Normalized.Turned)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
    }
}
