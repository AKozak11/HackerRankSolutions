using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace TheTimeInWords
{
    class Result
    {
        public static Dictionary<int, string> numberConversions = new Dictionary<int, string>
        {
            {1,  "one"},
            {2,  "two"},
            {3,  "three"},
            {4,  "four"},
            {5,  "five"},
            {6,  "six"},
            {7,  "seven"},
            {8,  "eight"},
            {9,  "nine"},
            {10, "ten"},
            {11, "eleven"},
            {12, "twelve"},
            {13, "thirteen"},
            {14, "fourteen"},
            {15, "fifteen"},
            {16, "sixteen"},
            {17, "seventeen"},
            {18, "eighteen"},
            {19, "nineteen"},
            {20, "twenty"},
            {40, "forty"},
            {50, "fifty"}
        };


        public static string GetConversion(int n)
        {
            string conversion = string.Empty;
            if (n > 20 && (n % 10) != 0)
            {
                string tens = numberConversions[(n / 10) * 10];
                string ones = numberConversions[n % 10];
                return $"{tens} {ones}";
            }

            return numberConversions[n];
        }

        public static string TimeInWords(int h, int m)
        {
            if (m.Equals(0))
            {
                return $"{GetConversion(h)} o' clock";
            }
            else if (m.Equals(15))
            {
                return $"quarter past {GetConversion(h)}";
            }
            else if (m < 30)
            {
                string minuteStr = m.Equals(1) ? "minute" : "minutes";
                return $"{GetConversion(m)} {minuteStr} past {GetConversion(h)}";
            }
            else if (m.Equals(30))
            {
                return $"half past {GetConversion(h)}";
            }
            else // m > 30
            {
                int difference = (60 - m);
                // set h to next hour
                if (h.Equals(12)) // if hour == 12, manually set next hour to 1
                {
                    h = 1;
                }
                else h += 1;
                if (difference.Equals(15)) return $"quarter to {GetConversion(h)}";
                string minuteStr = difference.Equals(1) ? "minute" : "minutes";
                return $"{GetConversion(difference)} {minuteStr} to {GetConversion(h)}";
            }
        }

    }

    class Solution
    {
        public static void Main(string[] args)
        {
            // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            // string result = Result.timeInWords(h, m);
            while (true)
            {
                Console.Write("Enter hour (int): ");
                int h = Convert.ToInt32(Console.ReadLine().Trim());

                Console.Write("Enter minute (int): ");
                int m = Convert.ToInt32(Console.ReadLine().Trim());
                Console.WriteLine(Result.TimeInWords(h, m));
            }

            // textWriter.WriteLine(result);

            // textWriter.Flush();
            // textWriter.Close();
        }
    }
}