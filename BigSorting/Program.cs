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
using System.Numerics;

namespace BigSorting
{

    class Result
    {

        /*
         * Complete the 'bigSorting' function below.
         *
         * The function is expected to return a STRING_ARRAY.
         * The function accepts STRING_ARRAY unsorted as parameter.
         */

        public static List<string> BigSorting(List<string> items)
        {

            items.Sort((a, b) =>
            {
                if (a.Length > b.Length || a.Length == b.Length && a.CompareTo(b) > 0) return 1;
                else if (a.Length < b.Length || a.Length == b.Length && a.CompareTo(b) < 0) return -1;
                else return 0;
            });
            
            return items;
        }

    }

    class Solution
    {
        public static void Main(string[] args)
        {
            // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<string> unsorted = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string unsortedItem = Console.ReadLine();
                unsorted.Add(unsortedItem);
            }

            List<string> result = Result.BigSorting(unsorted);

            Console.WriteLine(String.Join("\n", result));

            // textWriter.Flush();
            // textWriter.Close();
        }
    }
}