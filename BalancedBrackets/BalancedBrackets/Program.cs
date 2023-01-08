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

namespace HackerRankBalancedBrackets
{
    class Result
    {

        /*
         * Complete the 'isBalanced' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts STRING s as parameter.
         */

        public static bool IsOpen(char c)
        {
            string openChars = "({[";
            return openChars.IndexOf(c) != -1;
        }
        public static bool IsClose(char c)
        {
            string closeChars = ")}]";
            return closeChars.IndexOf(c) != -1;
        }
        public static bool IsMatching(char x, char y)
        {
            string openChars = "({[";
            string closeChars = ")}]";
            return openChars.IndexOf(x) == closeChars.IndexOf(y);
        }
        public static bool IsBalanced(string s, string stack)
        {
            if (string.IsNullOrEmpty(s))
            {
                if (string.IsNullOrEmpty(stack)) return true;
                return false;
            }
            // if open char, add to stack
            else if (IsOpen(s[0]))
            {
                return IsBalanced(s.Substring(1), s[0] + stack);
            }
            // if closing char, verify that it matches opening character at top of stack
            else if (IsClose(s[0]))
            {
                if (!string.IsNullOrEmpty(stack) && IsMatching(stack[0], s[0]))
                {
                    return IsBalanced(s.Substring(1), stack.Substring(1));
                }
                else return false;
            }
            else return IsBalanced(s.Substring(1), stack);
        }

        public static string isBalanced(string s)
        {
            bool isBalanced = false;
            string stack = string.Empty;

            isBalanced = IsBalanced(s, stack);

            if (isBalanced) return "YES";
            return "NO";
        }

    }

    class Solution
    {
        public static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int t = Convert.ToInt32(Console.ReadLine().Trim());

            for (int tItr = 0; tItr < t; tItr++)
            {
                string s = Console.ReadLine();

                string result = Result.isBalanced(s);

                textWriter.WriteLine(result);
            }

            textWriter.Flush();
            textWriter.Close();
        }
    }
}