using System;
using System.Drawing;

namespace Boat.Utilities.Geometry
{
    /// <summary>
    ///     Provides some usefull methods for the geometry.
    /// </summary>
    public static class GeometryUtilities
    {
        /// <summary>
        ///     Gets the distance between the initial and the final position.
        /// </summary>
        /// <param name="initial">Initial position</param>
        /// <param name="final">Final position</param>
        /// <returns>Distance between the two points.</returns>
        public static uint GetDistance(Point initial, Point final)
        {
            return (uint) (Math.Sqrt(Math.Pow(final.X - initial.X, 2.0) + Math.Pow(final.Y - initial.Y, 2.0)));
        }

        /// <summary>
        ///     Gets the angle between the initial and the final position.
        /// </summary>
        /// <param name="initial">Initial position</param>
        /// <param name="final">Final position</param>
        /// <returns>Current angle between the two points.</returns>
        public static double GetAngle(Point initial, Point final)
        {
            if ((final.X - initial.X) != 0)
                return Math.Atan((double) (final.Y - initial.Y)/(final.X - initial.X)) +
                       GetQuadrantAdjustment(initial, final);

            if ((final.X - initial.X) == 0 && (final.Y - initial.Y) >= 0)
                return Math.PI/2;

            return 3*Math.PI/2;
        }

        /// <summary>
        ///     Gets the quadrant ajustement based on the initial and the final position.
        /// </summary>
        /// <param name="initial">Initial position</param>
        /// <param name="final">Final position</param>
        /// <returns>Adjustement angle between the two points.</returns>
        private static double GetQuadrantAdjustment(Point initial, Point final)
        {
            if (((final.Y - initial.Y) >= 0 && (final.X - initial.X) < 0) ||
                ((final.Y - initial.Y) <= 0 && (final.X - initial.X) < 0))
                return Math.PI;
            if ((final.Y - initial.Y) <= 0 && (final.X - initial.X) > 0)
                return 2*Math.PI;

            return 0;
        }
    }
}