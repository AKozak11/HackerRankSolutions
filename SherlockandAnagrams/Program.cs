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

namespace SherlockAnagrams
{
    class Result
    {

        public static bool IsAnagram(string s1, string s2)
        {
            for (int i = 0; i < s1.Length; i++)
            {
                if (!s2.Contains(s1[i])) break;
                s2 = s2.Remove(s2.IndexOf(s1[i]), 1);
            }
            return string.IsNullOrEmpty(s2) ? true : false;
        }
        public static int SherlockAndAnagrams(string s)
        {
            int count = 0;
            for (int i = 0; i < (s.Length - 1); i++)
            {
                for (int j = i; j < s.Length; j++)
                {
                    string sub1 = s.Substring(i, (j - i + 1));
                    for (int k = (i + 1); (k + sub1.Length) <= s.Length; k++)
                    {
                        string sub2 = s.Substring(k, sub1.Length);
                        if (IsAnagram(sub1, sub2)) count++;
                    }
                }
            }
            return count;
        }

    }

    class Solution
    {
        public static void Main(string[] args)
        {
            // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int q = Convert.ToInt32(Console.ReadLine().Trim());

            for (int qItr = 0; qItr < q; qItr++)
            {
                string s = Console.ReadLine();

                int result = Result.SherlockAndAnagrams(s);

                Console.WriteLine(result);
            }

            // textWriter.Flush();
            // textWriter.Close();
        }
    }
}