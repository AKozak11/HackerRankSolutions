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

namespace AbsolutePermutation
{
    class Result
    {

        public static List<int> AbsolutePermutation(int n, int k)
        {
            List<int> result = new List<int>();
            if (k.Equals(0)) for (int i = 1; i <= n; i++) result.Add(i);
            else
            {
                List<bool> visited = new List<bool>();
                for (int i = 0; i <= n; i++) visited.Add(false);
                for (int i = 1; i <= n; i++)
                {
                    int lower = i - k;
                    int upper = i + k;

                    if (lower > 0 && !visited[lower])
                    {
                        result.Add(lower);
                        visited[lower] = true;
                    }
                    else if (upper <= n && !visited[upper])
                    {
                        result.Add(upper);
                        visited[upper] = true;
                    }
                    else // no available values to meet conditions
                    {
                        return new List<int> { -1 };
                    }
                }
            }
            return result;
        }

    }

    class Solution
    {
        public static void Main(string[] args)
        {
            // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int t = Convert.ToInt32(Console.ReadLine().Trim());

            for (int tItr = 0; tItr < t; tItr++)
            {
                string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

                int n = Convert.ToInt32(firstMultipleInput[0]);

                int k = Convert.ToInt32(firstMultipleInput[1]);

                List<int> result = Result.AbsolutePermutation(n, k);

                Console.WriteLine(String.Join(" ", result));
            }

            // textWriter.Flush();
            // textWriter.Close();
        }
    }
}