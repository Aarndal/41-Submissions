using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorMath
{
    public class Vector
    {
        private static float minFloat = MathF.Pow(10f, -6f); //minFloat is used to compare floats to zero and therefore avoid division by zero
        private float x, y, z;

        /// <summary>
        /// Enum for the rotation axis of the SignedAngle Methods
        /// </summary>
        public enum CartesianAxis
        {
            X,
            Y,
            Z
        }

        #region Constructors
        /// <summary>
        /// Generates a Zero Vector.
        /// </summary>
        public Vector()
        {
            this.x = 0;
            this.y = 0;
            this.z = 0;
        }

        /// <summary>
        /// Generates a Vector with x, y, and z components.
        /// </summary>
        /// <param name="_x"></param>
        /// <param name="_y"></param>
        /// <param name="_z"></param>
        public Vector(float _x, float _y, float _z = 0)
        {
            this.x = _x;
            this.y = _y;
            this.z = _z;
        }
        #endregion

        #region VectorComponents
        /// <summary>
        /// Gets/sets the X component of the Vector.
        /// </summary>
        public float X
        {
            get => this.x;
            set => this.x = value;
        }

        /// <summary>
        /// Gets/sets the Y component of the Vector.
        /// </summary>
        public float Y
        {
            get => this.y;
            set => this.y = value;
        }

        /// <summary>
        /// Gets/sets the Z component of the Vector.
        /// </summary>
        public float Z
        {
            get => this.z;
            set => this.z = value;
        }
        #endregion

        #region StandardVectors
        /// <summary>
        /// Generates a Zero Vector.
        /// </summary>
        public static Vector Zero
        {
            get => new Vector();
        }

        /// <summary>
        /// Generates a Standard Unit Vector in the positive x direction.
        /// </summary>
        public static Vector StdUnitVectorX
        {
            get => new Vector(1, 0, 0);
        }

        /// <summary>
        /// Generates a Standard Unit Vector in the positive y direction.
        /// </summary>
        public static Vector StdUnitVectorY
        {
            get => new Vector(0, 1, 0);
        }

        /// <summary>
        /// Generates a Standard Unit Vector in the positive z direction.
        /// </summary>
        public static Vector StdUnitVectorZ
        {
            get => new Vector(0, 0, 1);
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
            Vector sumVector = new Vector();
            sumVector.x = _vector1.x + _vector2.x;
            sumVector.y = _vector1.y + _vector2.y;
            sumVector.z = _vector1.z + _vector2.z;
            return sumVector;
        }

        /// <summary>
        /// Subtracts a Vector (Subtrahend) from another Vector (Minuend) and returns the Difference Vector.
        /// </summary>
        /// <param name="_minuendVector"></param>
        /// <param name="_subtrahendVector"></param>
        /// <returns></returns>
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
        /// <returns></returns>
        public static Vector operator *(Vector _vector, float _float)
        {
            Vector scalarProductVector = new Vector();
            scalarProductVector.x = _vector.x * _float;
            scalarProductVector.y = _vector.y * _float;
            scalarProductVector.z = _vector.z * _float;
            return scalarProductVector;
        }

        /// <summary>
        /// Multiplies a Vector with an integer.
        /// </summary>
        /// <param name="_vector"></param>
        /// <param name="_integer"></param>
        /// <returns></returns>
        public static Vector operator *(Vector _vector, int _integer)
        {
            Vector scalarProductVector = new Vector();
            scalarProductVector.x = _vector.x * _integer;
            scalarProductVector.y = _vector.y * _integer;
            scalarProductVector.z = _vector.z * _integer;
            return scalarProductVector;
        }

        /// <summary>
        /// Divides a Vector by a float.
        /// </summary>
        /// <param name="_vector"></param>
        /// <param name="_float"></param>
        /// <returns></returns>
        /// <exception cref="ArithmeticException"></exception>
        public static Vector operator /(Vector _vector, float _float)
        {
            if (_float > minFloat || _float < -minFloat) //minFloat is used to avoid division by zero
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
        /// <returns></returns>
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
        /// Returns the Dot Product of two Vectors as a float.
        /// </summary>
        /// <param name="_vector1"></param>
        /// <param name="_vector2"></param>
        /// <returns></returns>
        public static float operator *(Vector _vector1, Vector _vector2)
        {
            float dotProduct = _vector1.x * _vector2.x
                + _vector1.y * _vector2.y
                + _vector1.z * _vector2.z;
            return dotProduct;
        }

        /// <summary>
        /// Returns the Cross Product of two Vectors as a Vector.
        /// </summary>
        /// <param name="_vector1"></param>
        /// <param name="_vector2"></param>
        /// <returns></returns>
        public static Vector operator %(Vector _vector1, Vector _vector2)
        {
            Vector crossProductVector = new Vector();
            crossProductVector.x = (_vector1.y * _vector2.z) - (_vector1.z * _vector2.y);
            crossProductVector.y = -(_vector1.x * _vector2.z) + (_vector1.z * _vector2.x);
            crossProductVector.z = (_vector1.x * _vector2.y) - (_vector1.y * _vector2.x);
            return crossProductVector;
        }
        #endregion

        #region OppositeVector
        /// <summary>
        /// Returns the Opposite Vector of a given Vector.
        /// </summary>
        /// <param name="_vector"></param>
        /// <returns></returns>
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
        /// Returns the squared Length of a given Vector as a float.
        /// </summary>
        /// <param name="_vector"></param>
        /// <returns></returns>
        public static float GetSqrLength(Vector _vector)
        {
            return _vector.x * _vector.x +
                _vector.y * _vector.y +
                _vector.z * _vector.z;
        }

        // Calculates the squared Length of the Vector.
        private float GetSqrLength()
        {
            return x * x + y * y + z * z;
        }

        /// <summary>
        /// Gets the squared Length of the Vector.
        /// </summary>
        public float SqrLength
        {
            get => GetSqrLength();
        }

        /// <summary>
        /// Returns the Length of a given Vector as a float.
        /// </summary>
        /// <param name="_vector"></param>
        /// <returns></returns>
        public static float GetLength(Vector _vector)
        {
            return MathF.Sqrt(GetSqrLength(_vector));
        }

        // Calculates the Legnth of the Vector.
        private float GetLength()
        {
            return MathF.Sqrt(GetSqrLength(this));
        }

        /// <summary>
        /// Gets the Length of the Vector.
        /// </summary>
        public float Length
        {
            get => GetLength();
        }
        #endregion

        #region UnitVector
        /// <summary>
        /// Returns the Unit Vector of a given Vector.
        /// </summary>
        /// <param name="_vector"></param>
        /// <returns></returns>
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

        // Normalizes the Vector by dividing it through its Length.
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
        /// Returns the normalized Direction Vector of a given Origin Vector to a given Target Vector.
        /// </summary>
        /// <param name="_origin"></param>
        /// <param name="_target"></param>
        /// <returns></returns>
        public static Vector GetDirectionVector(Vector _origin, Vector _target)
        {
            return GetUnitVector(_target - _origin);
        }

        /// <summary>
        /// Returns the normalized Direction Vector to a given Target Vector.
        /// </summary>
        /// <param name="_target"></param>
        /// <returns></returns>
        public Vector GetDirectionVectorTo(Vector _target)
        {
            return GetUnitVector(_target - this);
        }

        /// <summary>
        /// Returns the Distance between two given Vectors as a float.
        /// </summary>
        /// <param name="_origin"></param>
        /// <param name="_target"></param>
        /// <returns></returns>
        public static float GetDistanceBetween(Vector _origin, Vector _target)
        {
            return _origin.GetDistanceTo(_target);
        }

        /// <summary>
        /// Returns the Distance to a given Vector as a float.
        /// </summary>
        /// <param name="_target"></param>
        /// <returns></returns>
        public float GetDistanceTo(Vector _target)
        {
            Vector distanceVector = _target - this;
            return distanceVector.Length;
        }
        #endregion

        #region ProjectionVector
        /// <summary>
        /// Projects a given Origin Vector onto a given Target Vector and returns the Projection Vector.
        /// </summary>
        /// <param name="_origin"></param>
        /// <param name="_target"></param>
        /// <returns></returns>
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
        /// Projects the Vector on a given Target Vector and returns the Projection Vector.
        /// </summary>
        /// <param name="_target"></param>
        /// <returns></returns>
        public Vector ProjectOn(Vector _target)
        {
            return _target.Normalized * (this * _target.Normalized);
        }

        /// <summary>
        /// Projects the Vector on the x-, y- or z-Axis and returns the Projection Vector.
        /// </summary>
        /// <param name="_axis"></param>
        /// <returns></returns>
        public Vector ProjectOnAxis(CartesianAxis _axis)
        {
            Vector target = new Vector();

            switch (_axis)
            {
                case CartesianAxis.X:
                    target = StdUnitVectorX;
                    break;
                case CartesianAxis.Y:
                    target = StdUnitVectorY;

                    break;
                case CartesianAxis.Z:
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
        /// Returns the direct angle between two given Vectors as a float, but without any information on the direction of rotation.
        /// </summary>
        /// <param name="_origin">The Vector that defines the start of the angle.</param>
        /// <param name="_target">The Vector that defines the end of the angle.</param>
        /// <returns>The direct angle as a float.</returns>
        /// <exception cref="ArithmeticException"></exception>
        public static float GetAngleBetween(Vector _origin, Vector _target)
        {
            try
            {
                float dotProduct = _origin * _target;
                float sqrCosPhi = (dotProduct * dotProduct) / (_origin.SqrLength * _target.SqrLength);
                float angle = MathF.Round((MathF.Acos(MathF.Sqrt(sqrCosPhi)) * 180) / MathF.PI, 4, MidpointRounding.AwayFromZero);

                // Checks if the Dot Product of the two Vectors is negative to make a range between 0° and 180° possible.
                if (dotProduct < minFloat)
                    return angle = 180 - angle;
                return angle;
            }
            catch (ArithmeticException _exception)
            {
                throw new ArithmeticException("You can't calculate an angle to a Zero Vector.", _exception);
            }
        }

        
        public static float GetSignedAngleBetween(Vector _origin, Vector _target, CartesianAxis _rotationAxis)
        {
            //gets the "direct" angle between two vectors
            float angle = GetAngleBetween(_origin, _target);

            //gets the axis to define the sign of the angle in regards of a right hand coordinate system
            Vector rotationAxisVector = new Vector();
            switch (_rotationAxis)
            {
                case CartesianAxis.X:
                    rotationAxisVector = StdUnitVectorX;
                    break;
                case CartesianAxis.Y:
                    rotationAxisVector = StdUnitVectorY;
                    break;
                case CartesianAxis.Z:
                    rotationAxisVector = StdUnitVectorZ;
                    break;
                default:
                    break;
            }

            //checks if the angle is positive or negative in regards of the rotation axis (right hand coordinate system) and returns the signed angle
            float tripleProduct = (_origin % _target) * rotationAxisVector;
            if (tripleProduct < minFloat)
                angle = -angle;
            return angle;
        }

        public float GetAngleTo(Vector _target)
        {
            try
            {
                float dotProduct = this * _target;
                float sqrCosPhi = (dotProduct * dotProduct) / (this.SqrLength * _target.SqrLength);
                float angle = MathF.Round((MathF.Acos(MathF.Sqrt(sqrCosPhi)) * 180) / MathF.PI, 4, MidpointRounding.AwayFromZero);
                if (dotProduct < minFloat)
                    return angle = 180 - angle;
                return angle;
            }
            catch (ArithmeticException _exception)
            {
                throw new ArithmeticException("You can't calculate an angle to a Zero Vector.", _exception);
            }
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

            // checks if the angle is positive or negative in regards of the rotation axis (right hand coordinate system) and returns the signed angle
            float tripleProduct = (this % _target) * rotationAxis;
            if (tripleProduct < minFloat)
                angle = -angle;
            return angle;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_target"></param>
        /// <returns></returns>
        public float GetSignedAngleTo(Vector _target)
        {
            Vector crossProduct = this % _target;
            Vector[] cartesianAxes = new Vector[] { StdUnitVectorX, StdUnitVectorY, StdUnitVectorZ };
            float[] angles = new float[cartesianAxes.Length];

            for (int i = 0; i < cartesianAxes.Length; i++)
                angles[i] = GetAngleBetween(crossProduct, cartesianAxes[i]);

            Vector rotationAxis = cartesianAxes[Array.IndexOf(angles, angles.Min())];

            // gets the "direct" angle between two vectors
            float angle = GetAngleBetween(this, _target);

            // checks if the angle is positive or negative in regards of the rotation axis (right hand coordinate system) and returns the signed angle
            if (crossProduct * rotationAxis < minFloat)
                angle = -angle;
            return angle;
        }
        #endregion

        #region Booleans
        public bool IsZeroVector
        {
            get
            {
                if (MathF.Abs(x) > minFloat || MathF.Abs(y) > minFloat || MathF.Abs(z) > minFloat)
                    return false;
                return true;
            }
        }

        public bool IsOppositeTo(Vector _vector)
        {
            if (this == _vector.Opposite)
                return true;
            return false;
        }

        public bool IsOrthogonalTo(Vector _vector)
        {
            if (MathF.Abs(this * _vector) <= minFloat)
                return true;
            return false;
        }

        public bool IsCollinearTo(Vector _vector)
        {
            if (GetAngleTo(_vector) <= minFloat)
                return true;
            return false;
        }

        public bool IsParallelTo(Vector _vector)
        {
            float dotProduct = this * _vector;
            if (IsCollinearTo(_vector) && dotProduct > minFloat)
                return true;
            return false;
        }

        public bool IsAntiparallelTo(Vector _vector)
        {
            float dotProduct = this * _vector;
            if (IsCollinearTo(_vector) && dotProduct <= minFloat)
                return true;
            return false;
        }
        #endregion
    }
}