using System;

namespace BL
{
    
    public static class Extensions
    {
        /// <summary>
        /// Convert to Radians.
        /// </summary>
        /// <param name="val">The value to convert to radians</param>
        /// <returns>The value in radians</returns>
        public static double ToRadians(this double val)
        {
            return (Math.PI / 180) * val;
        }

        public static string ToFullID(this string ID)
        {
            return ID.PadLeft(9, '0');
        }

        public static int NumberDayOfWeek(this DateTime d)
        {
            return (int)d.DayOfWeek;
        }
    }
  
}
