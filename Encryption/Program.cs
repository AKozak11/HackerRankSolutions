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
namespace Encryption
{
    class Result
    {

        /*
         * Complete the 'encryption' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts STRING s as parameter.
         */

        public static string encryption(string s)
        {
            List<string> sArray = new List<string>();

            Regex re = new Regex(@"\s+");
            s = re.Replace(s, "");

            int rows = (int)Math.Floor(Math.Sqrt((double)s.Length));
            int columns = (int)Math.Ceiling(Math.Sqrt((double)s.Length));
            if ((rows * columns) < s.Length) rows = columns;

            // add substrings to array up to the second to last row
            // remove substring after adding to array
            for (int i = 0; i < rows - 1; i++)
            {
                sArray.Add(s.Substring(0, columns));
                s = s.Remove(0, columns);
            }
            // add remaining string to array
            sArray.Add(s);

            List<string> result = new List<string>();

            for (int i = 0; i < columns; i++)
            {
                string temp = string.Empty;
                for (int j = 0; j < rows; j++)
                {
                    if (i >= sArray[j].Length) continue;
                    temp += sArray[j][i];
                }
                result.Add(temp);
            }
            return string.Join(' ', result);
        }

    }

    class Solution
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Result.encryption("chillout"));
            Console.WriteLine(Result.encryption("feedthedog"));
        }
    }
}