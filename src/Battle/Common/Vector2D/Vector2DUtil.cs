using System;

namespace Battle.Common
{
    /// <summary>
    /// Provides basic utilites for Vectors.
    /// </summary>
    public static class Vector2DUtil
    {
        /// <summary>
        /// Returns the dot product of the vectors.
        /// </summary>
        /// <param name="v1">The first vector2D. </param>
        /// <param name="v2">The second vector2D. </param>
        /// <returns>The dot product of the vectors. </returns>
        public static float Dot(Vector2D v1, Vector2D v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y;
        }

        /// <summary>
        /// Returns the cross product of the vectors.
        /// </summary>
        /// <param name="v1">The first vector2D. </param>
        /// <param name="v2">The second vector2D. </param>
        /// <returns>The cross product of the vectors. </returns>
        public static float Cross(Vector2D v1, Vector2D v2)
        {
            return v1.X * v2.Y - v1.Y * v2.X;
        }

        /// <summary>
        /// Returns the angle between two vectors.
        /// </summary>
        /// <param name="v1">The first vector2D. </param>
        /// <param name="v2">The second vector2D. </param>
        /// <returns>The angle between two vectors. </returns>
        public static float Angle(Vector2D v1, Vector2D v2)
        {
            return (float)Math.Acos(Dot(Normalize(v1), Normalize(v2)));
        }

        /// <summary>
        /// Returns the angle between a vector2D and the unitX vector2D.
        /// </summary>
        /// <param name="v1">The vector2D. </param>
        /// <returns>The angle between a vector2D and the unitX vector2D.. </returns>
        public static float Angle(Vector2D v1)
        {
            return (float)Math.Acos(Dot(Normalize(v1), Normalize(Vector2D.UnitX)));
        }

        /// <summary>
        /// Normalises a vector2D.
        /// </summary>
        /// <param name="v">The vector2D to normalize.</param>
        /// <returns>The normalized vector2D.</returns>
        public static Vector2D Normalize(Vector2D v)
        {
            if (v == Vector2D.Zero)
            {
                return Vector2D.Zero;
            }
            return v / v.Length;
        }

        /// <summary>
        /// Sets the length of the vector2D.
        /// </summary>
        /// <param name="v">The vector2D whose length to set.</param>
        /// <param name="length">The length of the vector2D.</param>
        /// <returns>The vector2D with correct length.</returns>
        public static Vector2D SetLength(Vector2D v, float length)
        {
            return Normalize(v) * length;
        }

        /// <summary>
        /// Rotates the vector2D left by a 90 degrees turn.
        /// </summary>
        /// <param name="v">The vector2D to turn. </param>
        /// <returns>The rotated vector2D. </returns>
        public static Vector2D TurnLeft(Vector2D v)
        {
            return new Vector2D(-v.Y, v.X);
        }

        /// <summary>
        /// Rotates the vector2D right by a 90 degrees turn.
        /// </summary>
        /// <param name="v">The vector2D to turn. </param>
        /// <returns>The rotated vector2D. </returns>
        public static Vector2D TurnRight(Vector2D v)
        {
            return new Vector2D(v.Y, -v.X);
        }

        /// <summary>
        /// Determines the distance between the two vectors.
        /// </summary>
        /// <param name="v1">The first vector2D. </param>
        /// <param name="v2">The second vector2D. </param>
        /// <returns>The distance between the vectors.</returns>
        public static float Distance(Vector2D v1, Vector2D v2)
        {
            return (v1 - v2).Length;
        }

        /// <summary>
        /// Determines the squared distance between the two vectors.
        /// </summary>
        /// <param name="v1">The first vector2D. </param>
        /// <param name="v2">The second vector2D. </param>
        /// <returns>The squared distance between the vectors.</returns>
        public static float SquaredDistance(Vector2D v1, Vector2D v2)
        {
            return (v1 - v2).SquaredLength;
        }

        /// <summary>
        /// Interpolates linearly between two vectors. 
        /// </summary>
        /// <param name="v1">The first vector2D. </param>
        /// <param name="v2">The second vector2D. </param>
        /// <param name="fraction">The fraction to interpolate with. </param>
        /// <returns>The interpolated vector2D. </returns>
        public static Vector2D Lerp(Vector2D v1, Vector2D v2, float fraction)
        {
            return (1 - fraction) * v1 + fraction * v2;
        }

        /// <summary>
        /// Reflect a vector2D along a normal.
        /// </summary>
        /// <param name="v">The vector2D to reflect.</param>
        /// <param name="normal">The normal to reflect it along.</param>
        /// <returns>The reflected vector2D. </returns>
        public static Vector2D Reflect(Vector2D v, Vector2D normal)
        {
            Vector2D n = Normalize(normal);
            return 2 * (Dot(v, n)) * n - v;
        }

        /// <summary>
        /// Clamps the vector2D length between the two imput lengths (inclusive).
        /// </summary>
        /// <param name="v">The vector2D to clampl</param>
        /// <param name="min">The inclusive minimum length.</param>
        /// <param name="max">The inclusive maximum length.</param>
        /// <returns>The clamped vector2D.</returns>
        public static Vector2D ClampLength(Vector2D v, float min, float max)
        {
            float vLength = v.Length;
            if (vLength < min)
            {
                return SetLength(v, min);
            }
            if (vLength > max)
            {
                return SetLength(v, max);
            }
            return v;
        }

        /// <summary>
        /// Checks if the parameter vector2D is inside of the rectangle created by the other vectors.
        /// </summary>
        /// <param name="vector2D">The vector2D to check</param>
        /// <param name="topLeft">The top left of the rectangle.</param>
        /// <param name="bottomRight">The bottom right of the rectangle.</param>
        /// <returns>True if inside</returns>
        public static bool InsideRectangle(Vector2D vector2D, Vector2D topLeft, Vector2D bottomRight)
        {
            bool horizontal = (vector2D.X < bottomRight.X) && (vector2D.X > topLeft.X);
            bool vertical = (vector2D.Y > bottomRight.Y) && (vector2D.Y < topLeft.Y);
            return horizontal && vertical;
        }
    }
}
