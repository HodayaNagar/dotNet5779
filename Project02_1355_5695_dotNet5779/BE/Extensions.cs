using System;
using System.Text;

namespace BE
{
    public static class Extensions
    {
        /// <summary>
        /// Calculate hashed id number by using MD5 algorithm
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static string GetHashedId(this string ID)
        {
            // step 1, calculate MD5 hash from input

            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(ID.ToFullID());

            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
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
