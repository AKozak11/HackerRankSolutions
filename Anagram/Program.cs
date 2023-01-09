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
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
            using (StreamReader sr = new StreamReader("./input"))
            {
                int q = Convert.ToInt32(sr.ReadLine().Trim());

                for (int qItr = 0; qItr < q; qItr++)
                {
                    string s = sr.ReadLine();

                    int result = Result.anagram(s);

                    textWriter.WriteLine(result);
                }

                textWriter.Flush();
                textWriter.Close();
            }
        }
    }
}