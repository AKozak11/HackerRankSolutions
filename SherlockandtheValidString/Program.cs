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

namespace SherlockandtehValidString
{
    class Result
    {

        public static string IsValid(string s)
        {
            // create frequency dictionary for each character
            Dictionary<char, int> freq = new Dictionary<char, int>();

            // add characters to frequency dictionary
            for (int i = 0; i < s.Length; i++)
            {
                if (freq.ContainsKey(s[i])) freq[s[i]]++;
                else freq.Add(s[i], 1);
            }

            int badChars = 0;
            List<int> vals = freq.Values.ToList();

            // find most common frequency because this is the value we need to test each character against
            int mode = vals.GroupBy(x => x).
                                    OrderByDescending(g => g.Count()).
                                    First().
                                    Key;

            for (int j = 0; j < vals.Count; j++)
            {
                // if frequency of current character does not equal the mode (most common)
                // the number of characters we need to delete to make it valid is either:
                // the value itself (since value - value = 0)
                // or the number of deletions to get the value to equal the mode
                if (vals[j] != mode) badChars += Math.Min(vals[j], Math.Abs(vals[j] - mode));
                if (badChars > 1) return "NO";
            }
            return "YES";
        }

    }

    class Solution
    {
        public static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string s = Console.ReadLine();

            string result = Result.IsValid(s);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}