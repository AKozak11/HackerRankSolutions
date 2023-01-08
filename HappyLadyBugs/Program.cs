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

namespace HappyLadyBugs
{
    class Result
    {

        /*
         * Complete the 'happyLadybugs' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts STRING b as parameter.
         */

        public static string HappyLadybugs(string b)
        {
            bool happy = true;

            // loop through cells, add to dictionary to check later
            // compare adjacent cells and determine if conditions already met
            Dictionary<char, int> cells = new Dictionary<char, int>();
            for (int i = 0; i < b.Length; i++)
            {
                if (cells.ContainsKey(b[i]))
                {
                    cells[b[i]]++;
                }
                else
                {
                    cells.Add(b[i], 1);
                }

                if (i > 0 && i < (b.Length - 1))
                {
                    if (!b[i].Equals(b[i - 1]) && !b[i].Equals(b[i + 1])) happy = false;
                }
                else if (i.Equals(0) && b.Length > 1)
                {
                    if (!b[i].Equals(b[i + 1])) happy = false;
                    else continue;
                }
                else if (i.Equals(b.Length - 1) && b.Length > 1)
                {
                    if (!b[i].Equals(b[i - 1])) happy = false;
                }
            }

            if(happy && b.Length > 1) return "YES";

            // check for single ladies
            IEnumerable<KeyValuePair<char, int>> sadLadies = cells.Where(c => c.Value == 1 && c.Key != '_');

             // if any single ladies or no empty spaces, return no
            if (sadLadies.Count() > 0 || !cells.ContainsKey('_')) return "NO";
            return "YES";
        }

    }

    class Solution
    {
        public static void Main(string[] args)
        {
            // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int g = Convert.ToInt32(Console.ReadLine().Trim());

            for (int gItr = 0; gItr < g; gItr++)
            {
                int n = Convert.ToInt32(Console.ReadLine().Trim());

                string b = Console.ReadLine();

                string result = Result.HappyLadybugs(b);
                Console.WriteLine(result);
                // textWriter.WriteLine(result);
            }

            // textWriter.Flush();
            // textWriter.Close();
        }
    }
}