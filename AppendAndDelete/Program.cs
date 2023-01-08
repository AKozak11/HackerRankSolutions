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
namespace FuckThis
{

    class Result
    {

        /*
         * Complete the 'appendAndDelete' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts following parameters:
         *  1. STRING s
         *  2. STRING t
         *  3. INTEGER k
         */

        public static string AppendAndDelete(string s, string t, int k)
        {
            // find min moves
            // find max moves
            int index = 0;
            for (int i = 0; i < Math.Min(s.Length, t.Length); i++)
            {

                if (s[i] != t[i])
                {
                    break;
                }
                index++;
            }

            int maxMoves = s.Length + t.Length;
            int minMoves = (s.Length - index) + (t.Length - index);

            if (k < minMoves) return "No";
            if (minMoves == k ||
                (k - minMoves) % 2 == 0 ||
                maxMoves <= k) return "Yes";
            return "No";
        }

    }

    class Solution
    {
        public static void Main(string[] args)
        {
            // string meh = "MEHHHHH";
            // Console.Write($"{meh}");
            // meh.Insert(meh.Length, "P");
            // Console.Write($"{meh}");
            Console.WriteLine(Result.AppendAndDelete("qwerasdf", "qwerbsdf", 6));
            Console.WriteLine(Result.AppendAndDelete("y", "yu", 2));
        }
    }
}