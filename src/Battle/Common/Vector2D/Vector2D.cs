using System;

namespace Battle.Common
{
    /// <summary>
    /// Provides the vector class that is the basis for this project.
    /// </summary>
    public struct Vector2D
    {
        /// <summary>
        /// Static constant for the zero vector.
        /// </summary>
        public readonly static Vector2D Zero = new Vector2D(0, 0);

        /// <summary>
        /// Static constant for the unit vector.
        /// </summary>
        public readonly static Vector2D One = new Vector2D(1, 1);

        /// <summary>
        /// Static constant for the unit X vector.
        /// </summary>
        public readonly static Vector2D UnitX = new Vector2D(1, 0);

        /// <summary>
        /// Static constant for the unit Y vector.
        /// </summary>
        public readonly static Vector2D UnitY = new Vector2D(0, 1);

        /// <summary>
        /// X coordinate.
        /// </summary>
        public float X { get; private set; }

        /// <summary>
        /// Y coordinate.
        /// </summary>
        public float Y { get; private set; }

        /// <summary>
        /// The length of the vector.
        /// </summary>
        public float Length
        {
            get
            {
                return (float)Math.Sqrt(SquaredLength);
            }
        }

        /// <summary>
        /// The squared length of the vector. Useful for optimalisation.
        /// </summary>
        public float SquaredLength
        {
            get
            {
                return X * X + Y * Y;
            }
        }

        /// <summary>
        /// The absolute angle of the vector.
        /// </summary>
        public float Angle
        {
            get
            {
                return (float)Math.Atan2(Y, X);
            }
        }

        /// <summary>
        /// Main Constructor.
        /// </summary>
        /// <param name="xValue">The x value of the vector. </param>
        /// <param name="yValue">The y value of the vector. </param>
        public Vector2D(float xValue, float yValue)
            : this()
        {
            X = xValue;
            Y = yValue;
        }

        /// <summary>
        /// Overrides the Equals method to provice better equality for vectors.
        /// </summary>
        /// <param name="obj">The object to test equality against.</param>
        /// <returns>Whether the objects are equal. </returns>
        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(obj, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, obj))
            {
                return true;
            }

            if (this.GetType() != obj.GetType())
                return false;

            Vector2D other = ((Vector2D)obj);
            return (X == other.X) && (Y == other.Y);
        }

        /// <summary>
        /// Overrides the hashcode.
        /// </summary>
        /// <returns>The hashcode for the vector.</returns>
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }

        /// <summary>
        /// ToString method overriden for easy printing/debugging.
        /// </summary>
        /// <returns>The string representation of the vector.</returns>
        public override string ToString()
        {
            return "(" + X + ", " + Y + ")";
        }

        /*----------------------- Operator overloading below ------------------------------*/
        public static bool operator ==(Vector2D v1, Vector2D v2)
        {
            if (object.ReferenceEquals(v1, null))
            {
                return object.ReferenceEquals(v2, null);
            }
            return v1.Equals(v2);
        }

        public static bool operator !=(Vector2D v1, Vector2D v2)
        {
            return !(v1 == v2);
        }

        public static Vector2D operator +(Vector2D a, Vector2D b)
        {
            return new Vector2D(a.X + b.X, a.Y + b.Y);
        }

        public static Vector2D operator -(Vector2D a, Vector2D b)
        {
            return new Vector2D(a.X - b.X, a.Y - b.Y);
        }

        public static Vector2D operator *(Vector2D a, Vector2D b)
        {
            return new Vector2D(a.X * b.X, a.Y * b.Y);
        }

        public static Vector2D operator *(Vector2D a, float b)
        {
            return new Vector2D(a.X * b, a.Y * b);
        }

        public static Vector2D operator *(float a, Vector2D b)
        {
            return new Vector2D(b.X * a, b.Y * a);
        }

        public static Vector2D operator /(Vector2D a, Vector2D b)
        {
            return new Vector2D(a.X / b.X, a.Y / b.Y);
        }

        public static Vector2D operator /(Vector2D a, float b)
        {
            return new Vector2D(a.X / b, a.Y / b);
        }

        public static Vector2D operator -(Vector2D a)
        {
            return new Vector2D(-a.X, -a.Y);
        }
    }
}