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

namespace BiggerIsGreater
{
    class Result
    {
        public static string NO_ANSWER = "no answer";
        public static string NextPermutation(string s)
        {

            // find beginning of suffix
            int l = (s.Length - 1);
            int i = l;
            while (i > 0 && s[i - 1] >= s[i]) i--;

            if (i <= 0) return NO_ANSWER;

            //find next index after end of prefix
            int j = l;
            while (s[j] <= s[i - 1]) j--;

            List<char> sList = s.ToList();
            //swap elements at end of prefix and end of suffix
            char temp = sList[i - 1];
            sList[i - 1] = sList[j];
            sList[j] = temp;

            // sort suffix
            while (i < l)
            {
                // since suffix is already in descending order, just swap i and j for ascending ordered suffix
                temp = sList[i];
                sList[i] = sList[l];
                sList[l] = temp;
                i++;
                l--;
            }
            List<char> suffix = sList.GetRange(i, (s.Length - i));
            suffix.Sort();

            return string.Join("", sList.GetRange(0, i)) + string.Join("", suffix);
        }

        public static string BiggerIsGreater(string w)
        {
            return NextPermutation(w);
        }

    }

    class Solution
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Result.BiggerIsGreater("lmno"));
        }
    }
}