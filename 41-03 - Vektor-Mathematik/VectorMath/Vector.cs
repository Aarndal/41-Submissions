using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorMath
{
    public class Vector
    {
        // MemberVariables
        private static readonly float m_MinFloat = MathF.Pow(10f, -6f); //minFloat is used to compare floats to zero and therefore avoid division by zero
        private float m_x, m_y, m_z;

        /// <summary>
        /// Enum for the rotation axis of the SignedAngle Methods
        /// </summary>
        public enum CartesianAxis
        {
            XAxis,
            YAxis,
            ZAxis
        }

        #region Constructors
        /// <summary>
        /// Generates a Zero Vector.
        /// </summary>
        public Vector()
        {
            this.m_x = 0;
            this.m_y = 0;
            this.m_z = 0;
        }

        /// <summary>
        /// Generates a Vector with x, y, and z components.
        /// </summary>
        /// <param name="_x"></param>
        /// <param name="_y"></param>
        /// <param name="_z"></param>
        public Vector(float _x, float _y, float _z = 0)
        {
            this.m_x = _x;
            this.m_y = _y;
            this.m_z = _z;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets/sets the X component of the Vector.
        /// </summary>
        public float X
        {
            get => this.m_x;
            set => this.m_x = value;
        }

        /// <summary>
        /// Gets/sets the Y component of the Vector.
        /// </summary>
        public float Y
        {
            get => this.m_y;
            set => this.m_y = value;
        }

        /// <summary>
        /// Gets/sets the Z component of the Vector.
        /// </summary>
        public float Z
        {
            get => this.m_z;
            set => this.m_z = value;
        }
                
        /// <summary>
        /// Gets the dimension of the Vector.
        /// </summary>
        public int Dimensions
        {
            get
            {
                if (m_x == 0 || m_y == 0 || m_z == 0)
                    return 2;
                return 3;
            }
        }
        #endregion

        #region StandardVectors
        /// <summary>
        /// Generates a Zero Vector.
        /// </summary>
        public static Vector Zero
        {
            get => new();
        }

        /// <summary>
        /// Generates a Standard Unit Vector in the positive x direction.
        /// </summary>
        public static Vector StdUnitVectorX
        {
            get => new(1, 0, 0);
        }

        /// <summary>
        /// Generates a Standard Unit Vector in the positive y direction.
        /// </summary>
        public static Vector StdUnitVectorY
        {
            get => new(0, 1, 0);
        }

        /// <summary>
        /// Generates a Standard Unit Vector in the positive z direction.
        /// </summary>
        public static Vector StdUnitVectorZ
        {
            get => new(0, 0, 1);
        }
        #endregion

        #region Vector Addition & Subtraction
        /// <summary>
        /// Adds two Vectors.
        /// </summary>
        /// <param name="_vector1"></param>
        /// <param name="_vector2"></param>
        /// <returns>Returns the sum as a Vector.</returns>
        public static Vector operator +(Vector _vector1, Vector _vector2)
        {
            Vector sumVector = new()
            {
                m_x = _vector1.m_x + _vector2.m_x,
                m_y = _vector1.m_y + _vector2.m_y,
                m_z = _vector1.m_z + _vector2.m_z
            };
            return sumVector;
        }

        /// <summary>
        /// Subtracts a Vector (Subtrahend) from another Vector (Minuend).
        /// </summary>
        /// <param name="_minuendVector">The Vector that is subtracted by the subtrahend Vector.</param>
        /// <param name="_subtrahendVector">The Vector that is subtracted from the minuend Vector.</param>
        /// <returns>Returns the difference of the minuend Vector and the subtrahend Vector as a Vector.</returns>
        public static Vector operator -(Vector _minuendVector, Vector _subtrahendVector)
        {
            Vector differenceVector = _minuendVector + GetOppositeVector(_subtrahendVector); // uses the GetOppositeVector method to reduce code clutter
            return differenceVector;
        }
        #endregion

        #region Scalar Multiplication & Division
        /// <summary>
        /// Multiplies a Vector with a float.
        /// </summary>
        /// <param name="_vector"></param>
        /// <param name="_float"></param>
        /// <returns>Returns the given Vector whose components have been multiplied by the given number.</returns>
        public static Vector operator *(Vector _vector, float _float)
        {
            Vector scalarProductVector = new()
            {
                m_x = _vector.m_x * _float,
                m_y = _vector.m_y * _float,
                m_z = _vector.m_z * _float
            };
            return scalarProductVector;
        }

        /// <summary>
        /// Multiplies a Vector with an integer.
        /// </summary>
        /// <param name="_vector"></param>
        /// <param name="_integer"></param>
        /// <returns>Returns the given Vector whose components have been multiplied by the given number.</returns>
        public static Vector operator *(Vector _vector, int _integer)
        {
            Vector scalarProductVector = new()
            {
                m_x = _vector.m_x * _integer,
                m_y = _vector.m_y * _integer,
                m_z = _vector.m_z * _integer
            };
            return scalarProductVector;
        }

        /// <summary>
        /// Divides a Vector by a float.
        /// </summary>
        /// <param name="_vector"></param>
        /// <param name="_float"></param>
        /// <returns>Returns the given Vector whose components have been divided by the given number.</returns>
        /// <exception cref="ArithmeticException"></exception>
        public static Vector operator /(Vector _vector, float _float)
        {
            if (_float > m_MinFloat || _float < -m_MinFloat) //minFloat is used to avoid division by zero
            {
                Vector scalarQuotientVector = _vector * MathF.Pow(_float, -1f);
                return scalarQuotientVector;
            }
            throw new ArithmeticException("Can't divide by Null.");
        }

        /// <summary>
        /// Divides a Vector by an integer.
        /// </summary>
        /// <param name="_vector"></param>
        /// <param name="_integer"></param>
        /// <returns>Returns the given Vector whose components have been divided by the given number.</returns>
        /// <exception cref="ArithmeticException"></exception>
        public static Vector operator /(Vector _vector, int _integer)
        {
            if (_integer != 0)
            {
                Vector scalarQuotientVector = _vector * MathF.Pow(_integer, -1);
                return scalarQuotientVector;
            }
            throw new ArithmeticException("Can't divide by Null.");
        }
        #endregion

        #region DotProduct & CrossProduct

        /// <summary>
        /// Calculates the Dot Product of two Vectors.
        /// </summary>
        /// <param name="_vector1"></param>
        /// <param name="_vector2"></param>
        /// <returns>Returns the Dot Product as a float.</returns>
        public static float operator *(Vector _vector1, Vector _vector2)
        {
            float dotProduct = _vector1.m_x * _vector2.m_x
                + _vector1.m_y * _vector2.m_y
                + _vector1.m_z * _vector2.m_z;
            return dotProduct;
        }

        /// <summary>
        /// Calculates the Cross Product of two Vectors.
        /// </summary>
        /// <param name="_vector1"></param>
        /// <param name="_vector2"></param>
        /// <returns>Returns the Cross Product as a new Vector.</returns>
        public static Vector operator %(Vector _vector1, Vector _vector2)
        {
            Vector crossProductVector = new()
            {
                m_x = (_vector1.m_y * _vector2.m_z) - (_vector1.m_z * _vector2.m_y),
                m_y = -(_vector1.m_x * _vector2.m_z) + (_vector1.m_z * _vector2.m_x),
                m_z = (_vector1.m_x * _vector2.m_y) - (_vector1.m_y * _vector2.m_x)
            };
            return crossProductVector;
        }
        #endregion

        #region OppositeVector
        /// <summary>
        /// Calculates the Opposite Vector of a given Vector.
        /// </summary>
        /// <param name="_vector"></param>
        /// <returns>Returns the Opposite Vector of a given Vector.</returns>
        public static Vector GetOppositeVector(Vector _vector)
        {
            return _vector * (-1);
        }

        // Multiplies the Vector by minus one to get the Opposite Vector of the Vector.
        private Vector OppositeDirection()
        {
            return this * (-1);
        }

        /// <summary>
        /// Gets the Opposite Vector of the Vector.
        /// </summary>
        public Vector Opposite
        {
            get => OppositeDirection();
        }
        #endregion

        #region Length & SqrLength
        /// <summary>
        /// Calculates the squared length of a given Vector.
        /// </summary>
        /// <param name="_vector"></param>
        /// <returns>Returns the squared length of a given Vector as a float.</returns>
        public static float GetSqrLength(Vector _vector)
        {
            return _vector.m_x * _vector.m_x +
                _vector.m_y * _vector.m_y +
                _vector.m_z * _vector.m_z;
        }

        // Calculates the squared Length of the Vector.
        private float GetSqrLength()
        {
            return m_x * m_x + m_y * m_y + m_z * m_z;
        }

        /// <summary>
        /// Gets the squared length of the Vector.
        /// </summary>
        public float SqrLength
        {
            get => GetSqrLength();
        }

        /// <summary>
        /// Calculates the length of a given Vector.
        /// </summary>
        /// <param name="_vector"></param>
        /// <returns>Returns the length of a given Vector as a float.</returns>
        public static float GetLength(Vector _vector)
        {
            return MathF.Sqrt(GetSqrLength(_vector));
        }

        // Calculates the length of the Vector.
        private float GetLength()
        {
            return MathF.Sqrt(GetSqrLength(this));
        }

        /// <summary>
        /// Gets the length of the Vector.
        /// </summary>
        public float Length
        {
            get => GetLength();
        }
        #endregion

        #region UnitVector
        /// <summary>
        /// Calculates the Unit Vector of a given Vector.
        /// </summary>
        /// <param name="_vector"></param>
        /// <returns>Returns the Unit Vector of a given Vector.</returns>
        /// <exception cref="ArithmeticException"></exception>
        public static Vector GetUnitVector(Vector _vector)
        {
            try
            {
                return _vector / MathF.Sqrt(_vector.SqrLength);
            }
            catch (ArithmeticException _exception)
            {
                throw new ArithmeticException("Can't create a Unit Vector of a Zero Vector.", _exception);
            }
        }

        // Normalizes the Vector by dividing it through its length.
        private Vector Normalize()
        {
            if (!this.IsZeroVector)
                return this / MathF.Sqrt(SqrLength);
            throw new ArithmeticException("Can't create a Unit Vector of a Zero Vector.");
        }

        /// <summary>
        /// Gets the Unit Vector of the Vector by normalizing it.
        /// </summary>
        public Vector Normalized
        {
            get => Normalize();
        }
        #endregion

        #region DirectionVector & Distance
        /// <summary>
        /// Calculates the normalized Direction Vector of a given Origin Vector to a given Target Vector.
        /// </summary>
        /// <param name="_origin">Origin Vector</param>
        /// <param name="_target">Target Vector</param>
        /// <returns>Returns the normalized Direction Vector.</returns>
        public static Vector GetDirectionVector(Vector _origin, Vector _target)
        {
            return GetUnitVector(_target - _origin);
        }

        /// <summary>
        /// Calculates the normalized Direction Vector to a given Vector.
        /// </summary>
        /// <param name="_target">Target Vector</param>
        /// <returns>Returns the normalized Direction Vector.</returns>
        public Vector GetDirectionVectorTo(Vector _target)
        {
            return GetUnitVector(_target - this);
        }

        /// <summary>
        /// Calculates the distance between two given Vectors.
        /// </summary>
        /// <param name="_origin">Origin Vector</param>
        /// <param name="_target">Target Vector</param>
        /// <returns>Returns the distance as a float.</returns>
        public static float GetDistanceBetween(Vector _origin, Vector _target)
        {
            return _origin.GetDistanceTo(_target);
        }

        /// <summary>
        /// Calculates the distance to a given Vector.
        /// </summary>
        /// <param name="_target">Target Vector</param>
        /// <returns>Returns the distance as a float.</returns>
        public float GetDistanceTo(Vector _target)
        {
            Vector distanceVector = _target - this;
            return distanceVector.Length;
        }
        #endregion

        #region ProjectionVector
        /// <summary>
        /// Projects a given Origin Vector onto a given Target Vector.
        /// </summary>
        /// <param name="_origin">Origin Vector</param>
        /// <param name="_target">Target Vector</param>
        /// <returns>Returns the Projection Vector.</returns>
        public static Vector GetProjectionVector(Vector _origin, Vector _target)
        {
            try
            {
                return _target.Normalized * (_origin * _target.Normalized);
            }
            catch (ArithmeticException _exception)
            {
                throw new ArithmeticException("Can't create a Projection Vector of a Zero Vector.", _exception);
            }
        }

        /// <summary>
        /// Projects the Vector on a given Target Vector.
        /// </summary>
        /// <param name="_target">Target Vector</param>
        /// <returns>Returns the Projection Vector.</returns>
        public Vector ProjectOn(Vector _target)
        {
            return _target.Normalized * (this * _target.Normalized);
        }

        /// <summary>
        /// Projects the Vector on the x-, y- or z-Axis.
        /// </summary>
        /// <param name="_axis"></param>
        /// <returns>Returns the Projection Vector.</returns>
        public Vector ProjectOn(CartesianAxis _axis)
        {
            Vector target = new();

            switch (_axis)
            {
                case CartesianAxis.XAxis:
                    target = StdUnitVectorX;
                    break;
                case CartesianAxis.YAxis:
                    target = StdUnitVectorY;

                    break;
                case CartesianAxis.ZAxis:
                    target = StdUnitVectorZ;
                    break;
                default:
                    break;
            }
            return ProjectOn(target);
        }
        #endregion

        #region Angles
        /// <summary>
        /// Calculates the direct angle between two given vectors.
        /// </summary>
        /// <param name="_firstAngleArm">The Vector that defines the start of the angle.</param>
        /// <param name="_secondAngleArm">The Vector that defines the end of the angle.</param>
        /// <returns>Returns the direct angle as a float, but without information about the direction of rotation.</returns>
        /// <exception cref="ArithmeticException"></exception>
        public static float GetAngleBetween(Vector _firstAngleArm, Vector _secondAngleArm)
        {
            try
            {
                float dotProduct = _firstAngleArm * _secondAngleArm;
                float cosPhi = dotProduct / (_firstAngleArm.Length * _secondAngleArm.Length);
                float angle = MathF.Round((MathF.Acos(cosPhi) * 180) / MathF.PI, 4, MidpointRounding.AwayFromZero);
                
                // Alternative calculation of the angle... perhaps more performant?
                //float sqrCosPhi = (dotProduct * dotProduct) / (_firstAngleArm.SqrLength * _secondAngleArm.SqrLength);
                //float angle = MathF.Round((MathF.Acos(MathF.Sqrt(sqrCosPhi)) * 180) / MathF.PI, 4, MidpointRounding.AwayFromZero);

                /* Checks if the Dot Product of the two Vectors is negative.
                 * If it is negative, the angle is an obtuse angle (between 90° and 180°) and is calculated as 180° - angle.
                 */
                //if (dotProduct < m_MinFloat)
                //    return angle = 180 - angle;
                return angle;
            }
            catch (ArithmeticException _exception)
            {
                throw new ArithmeticException("You can't calculate an angle to a Zero Vector.", _exception);
            }
        }

        /// <summary>
        /// Calculates the direct angle between the Vector and a given Target Vector.
        /// </summary>
        /// <param name="_target"></param>
        /// <returns>Returns the direct angle as a float, but without information about the direction of rotation.</returns>
        /// <exception cref="ArithmeticException"></exception>
        public float GetAngleTo(Vector _target)
        {
            try
            {
                float dotProduct = this * _target;
                float cosPhi = dotProduct / (this.Length * _target.Length);
                float angle = MathF.Round((MathF.Acos(cosPhi) * 180) / MathF.PI, 4, MidpointRounding.AwayFromZero);

                // Alternative calculation of the angle... perhaps more performant?
                //float sqrCosPhi = (dotProduct * dotProduct) / (this.SqrLength * _target.SqrLength);
                //float angle = MathF.Round((MathF.Acos(MathF.Sqrt(sqrCosPhi)) * 180) / MathF.PI, 4, MidpointRounding.AwayFromZero);

                /* Checks if the Dot Product of the two Vectors is negative.
                 * If it is negative, the angle is an obtuse angle (between 90° and 180°) and is calculated as 180° - angle.
                 */
                //if (dotProduct < m_MinFloat)
                //    return angle = 180 - angle;
                return angle;
            }
            catch (ArithmeticException _exception)
            {
                throw new ArithmeticException("You can't calculate an angle to a Zero Vector.", _exception);
            }
        }

        public static float GetSignedAngleBetween(Vector _firstAngleArm, Vector _secondAngleArm, CartesianAxis _rotationAxis)
        {
            // Gets the direct angle between two vectors
            float angle = GetAngleBetween(_firstAngleArm, _secondAngleArm);

            // Gets the axis to define the sign of the angle in regards of a right hand coordinate system
            Vector rotationAxisVector = new();
            switch (_rotationAxis)
            {
                case CartesianAxis.XAxis:
                    rotationAxisVector = StdUnitVectorX;
                    break;
                case CartesianAxis.YAxis:
                    rotationAxisVector = StdUnitVectorY;
                    break;
                case CartesianAxis.ZAxis:
                    rotationAxisVector = StdUnitVectorZ;
                    break;
                default:
                    break;
            }

            /* 
             * Calculates the triple product of the 
             * Checks if the angle is positive or negative in regards of the rotation axis (right hand coordinate system) and returns the signed angle
             */
            float tripleProduct = rotationAxisVector * (_firstAngleArm % _secondAngleArm);
            if (tripleProduct < m_MinFloat)
                angle = -angle;
            return angle;
        }

        public float GetSignedAngleTo(Vector _target, CartesianAxis _rotationAxis)
        {
            //gets the direct angle between two vectors
            float angle = GetAngleBetween(this, _target);

            //gets the axis to define the sign of the angle in regards of a right hand coordinate system
            Vector rotationAxis = new();
            switch (_rotationAxis)
            {
                case CartesianAxis.XAxis:
                    rotationAxis = StdUnitVectorX;
                    break;
                case CartesianAxis.YAxis:
                    rotationAxis = StdUnitVectorY;
                    break;
                case CartesianAxis.ZAxis:
                    rotationAxis = StdUnitVectorZ;
                    break;
                default:
                    break;
            }

            // checks if the angle is positive or negative in regards of the rotation axis (right hand coordinate system) and returns the signed angle
            float tripleProduct = rotationAxis * (this % _target);
            if (tripleProduct < m_MinFloat)
                angle = -angle;
            return angle;
        }

        // Bugged implementation of the GetSignedAngleTo method
        //public float GetSignedAngleTo(Vector _target)
        //{
        //    Vector crossProduct = this % _target;
        //    Vector[] cartesianAxes = new Vector[] { StdUnitVectorX, StdUnitVectorY, StdUnitVectorZ };
        //    float[] axisAngles = new float[cartesianAxes.Length];

        //    for (int i = 0; i < cartesianAxes.Length; i++)
        //    {
        //        //float dotProduct = crossProduct * cartesianAxes[i];
        //        //float sqrCosPhi = (dotProduct * dotProduct) / (crossProduct.SqrLength * cartesianAxes[i].SqrLength);
        //        //axisAngles[i] = MathF.Round((MathF.Acos(MathF.Sqrt(sqrCosPhi)) * 180) / MathF.PI, 4, MidpointRounding.AwayFromZero);
        //        axisAngles[i] = GetAngleBetween(crossProduct, cartesianAxes[i]);
        //    }

        //    Vector rotationAxis = cartesianAxes[Array.IndexOf(axisAngles, axisAngles.Min())];

        //    // gets the direct angle between two vectors
        //    float angle = GetAngleBetween(this, _target);

        //    // checks if the angle is positive or negative in regards of the rotation axis (right hand coordinate system) and returns the signed angle
        //    if (rotationAxis * crossProduct < m_MinFloat)
        //        angle = -angle;
        //    return angle;
        //}
        #endregion

        #region Booleans
        /// <summary>
        /// Checks if the Vector is a Zero Vector.
        /// </summary>
        /// <returns>Returns true if the Vector is a Zero Vector, otherwise false.</returns>
        public bool IsZeroVector
        {
            get
            {
                if (MathF.Abs(m_x) > m_MinFloat || MathF.Abs(m_y) > m_MinFloat || MathF.Abs(m_z) > m_MinFloat)
                    return false;
                return true;
            }
        }

        /// <summary>
        /// Checks if a given Vector has the same direction as the Vector.
        /// </summary>
        /// <param name="_vector"></param>
        /// <returns></returns>
        public bool HasSameDirectionAs(Vector _vector)
        {
            if (this.Normalized == _vector.Normalized)
                return true;
            return false;
        }

        /// <summary>
        /// Checks if a given Vector is the Opposite Vector of this Vector. 
        /// </summary>
        /// <param name="_vector"></param>
        /// <returns>Returns true if the Vector is the Opposite Vector, otherwise false.</returns>
        public bool IsOppositeTo(Vector _vector)
        {
            if (this == _vector.Opposite)
                return true;
            return false;
        }

        /// <summary>
        /// Checks if a given Vector is orthogonal to this Vector.
        /// </summary>
        /// <param name="_vector"></param>
        /// <returns>Returns true if the Vector is orthogonal, otherwise false.</returns>
        public bool IsOrthogonalTo(Vector _vector)
        {
            if (MathF.Abs(this * _vector) <= m_MinFloat) // two Vectors are orthogonal to each other if their Dot Product is 0
                return true;
            return false;
        }

        /// <summary>
        /// Checks if a given Vector is collinear to this Vector.
        /// </summary>
        /// <param name="_vector"></param>
        /// <returns>Returns true if the Vector is collinear, otherwise false.</returns>
        public bool IsCollinearTo(Vector _vector)
        {
            if (GetAngleTo(_vector) <= m_MinFloat) // two Vectors are collinear if the angle between them is 0°
                return true;
            return false;
        }

        /// <summary>
        /// Checks if a given Vector is parallel to this Vector.
        /// </summary>
        /// <param name="_vector"></param>
        /// <returns>Returns true if the Vector is parallel, otherwise false.</returns>
        public bool IsParallelTo(Vector _vector)
        {
            float dotProduct = this * _vector;
            if (IsCollinearTo(_vector) && dotProduct > m_MinFloat) // two Vectors are parallel if the angle between them is 0° and the Dot Product is greater than 0
                return true;
            return false;
        }

        /// <summary>
        /// Checks if a given Vector is antiparallel to this Vector.
        /// </summary>
        /// <param name="_vector"></param>
        /// <returns>Returns true if the Vector is antiparallel, otherwise false.</returns>
        public bool IsAntiparallelTo(Vector _vector)
        {
            float dotProduct = this * _vector;
            if (IsCollinearTo(_vector) && dotProduct < -m_MinFloat) // two Vectors are antiparallel if the angle between them is 0° and the Dot Product is less than 0
                return true;
            return false;
        }
        #endregion
    }
}