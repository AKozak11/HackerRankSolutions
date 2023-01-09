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
namespace Palindrome
{
    class Result
    {

        /*
         * Complete the 'palindromeIndex' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts STRING s as parameter.
         */
        public static bool IsPalindrome(string s)
        {
            for (int i = 0; i < s.Length / 2; i++)
            {
                if (s[i] != s[s.Length - (i + 1)]) return false;
            }
            return true;
        }
        public static int PalindromeIndex(string s)
        {

            if (IsPalindrome(s)) return -1;

            // count all occurrences of each character
            Dictionary<char, int> freq = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (freq.ContainsKey(s[i])) freq[s[i]]++;
                else freq.Add(s[i], 1);
            }

            // find all characters with odd frequency
            List<char> odds = freq.Where(x => x.Value % 2 == 1).Select(y => y.Key).ToList();

            // try removing each character with odd frequency one by one
            // and test if it is palindrome
            foreach (char j in odds)
            {
                int k = s.IndexOf(j);
                while (k != -1 && k < s.Length)
                {
                    Console.WriteLine($"{j} | {freq[j]} | {k}");
                    if (k < (s.Length - 1))
                    {
                        if (IsPalindrome(s.Substring(0, k) + s.Substring((k + 1), s.Length - (k + 1)))) return k;
                    }
                    else if (IsPalindrome(s.Substring(0, k))) return k;
                    k = s.IndexOf(j, (k + 1));
                }
            }
            return -1;
        }

    }

    class Solution
    {
        public static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int q = Convert.ToInt32(Console.ReadLine().Trim());

            for (int qItr = 0; qItr < q; qItr++)
            {
                string s = Console.ReadLine();

                int result = Result.PalindromeIndex(s);

                textWriter.WriteLine(result);
            }

            textWriter.Flush();
            textWriter.Close();
        }
    }
}