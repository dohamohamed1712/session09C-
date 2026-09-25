using System;
using System.Collections.Generic;
using System.Text;

namespace session09C_
{
    internal static class TextHelper
    {
        // Bonus: normal static method first
        // public static bool IsShorterThan(string value, int length)
        // {
        //     return value.Length < length;
        // }

        // Converted to Extension Method using 'this' keyword
        public static bool IsShorterThan(this string value, int length)
        {
            return value.Length < length;
        }

        public static string Repeat(this string value, int times)
        {
            string result = "";
            for (int i = 0; i < times; i++)
            {
                result += value;
            }
            return result;
        }
    }
}
