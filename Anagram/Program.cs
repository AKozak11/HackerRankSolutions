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

namespace Anagram
{
    class Result
    {

        /*
         * Complete the 'anagram' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts STRING s as parameter.
         */
        // alternate implementation
        // public static int anagram(string s)
        // {
        //     if (s.Length % 2 != 0) return -1;

        //     int count = 0;
        //     int splitIndex = s.Length / 2;
        //     string sub1 = s.Substring(0, splitIndex);
        //     string sub2 = s.Substring(splitIndex, splitIndex);

        //     for (int i = 0; i < splitIndex; i++)
        //     {
        //         if (sub1.Contains(sub2[i])) sub1 = sub1.Remove(sub1.IndexOf(sub2[i]), 1);
        //         else count++;
        //     }
        //     return count;
        // }


        public static int anagram(string s)
        {
            if (s.Length % 2 != 0) return -1;

            int count = 0;
            int splitIndex = s.Length / 2;
            List<char> sub = s.Substring(splitIndex).ToList();

            for (int i = 0; i < splitIndex; i++)
            {
                if (sub.Contains(s[i])) sub.Remove(s[i]);
                else count++;
            }
            return count;
        }

    }

    class Solution
    {
        public static void Main(string[] args)
        {
            // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
            using (StreamReader sr = new StreamReader("./input"))
            {
                int q = Convert.ToInt32(sr.ReadLine().Trim());

                for (int qItr = 0; qItr < q; qItr++)
                {
                    string s = sr.ReadLine();

                    int result = Result.anagram(s);

                    Console.WriteLine(result);
                }

                // textWriter.Flush();
                // textWriter.Close();
            }
        }
    }
}