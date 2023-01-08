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

namespace TheGridSearch
{
    class Result
    {

        // returns a list of indices where the substring is found in string
        public static List<int> FindIndices(string sub, string s)
        {
            List<int> result = new List<int>();
            int index = s.IndexOf(sub);

            while (index != -1)
            {
                result.Add(index);
                if (index < (s.Length - 1)) index = s.IndexOf(sub, (index + 1));
                else index = -1;
            }
            return result;
        }

        public static string GridSearch(List<string> G, List<string> P)
        {
            bool found = false;
            for (int i = 0; i < G.Count; i++)
            {
                // search grid for occurrence of first row of pattern
                List<int> indices = FindIndices(P[0], G[i]);

                if (indices.Count == 0) continue; // pattern not found, try next row

                foreach (int index in indices)
                {
                    int j = (i + 1);
                    for (int k = 1; k < P.Count; k++)
                    {
                        // search following rows for ooccurrence of each row of pattern
                        // do so by searching indices of current row for the current index
                        List<int> curIndices = FindIndices(P[k], G[j]);
                        if (curIndices.Contains(index)) found = true;
                        else
                        {
                            found = false;
                            break; // not found, try next index
                        }
                        j++;
                    }
                    if (found) break; // pattern found, no need to keep searching, break out
                }
                if (found) break;
            }
            return found ? "YES" : "NO";
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

                    int R = Convert.ToInt32(firstMultipleInput[0]);

                    int C = Convert.ToInt32(firstMultipleInput[1]);

                    List<string> G = new List<string>();

                    for (int i = 0; i < R; i++)
                    {
                        string GItem = Console.ReadLine();
                        G.Add(GItem);
                    }

                    string[] secondMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

                    int r = Convert.ToInt32(secondMultipleInput[0]);

                    int c = Convert.ToInt32(secondMultipleInput[1]);

                    List<string> P = new List<string>();

                    for (int i = 0; i < r; i++)
                    {
                        string PItem = Console.ReadLine();
                        P.Add(PItem);
                    }

                    string result = Result.GridSearch(G, P);

                    Console.WriteLine(result);
                }

                // textWriter.Flush();
                // textWriter.Close();
            }
        }
    }
}