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

namespace SeparateTheNumbers
{
    class Result
    {

        /*
         * Complete the 'separateNumbers' function below.
         *
         * The function accepts STRING s as parameter.
         */

        public static void SeparateNumbers(string s)
        {
            if (s[0] == '0') { Console.WriteLine("NO"); return; }
            if (s.Length == 1) { Console.WriteLine("NO"); return; }

            bool isB = false;
            int i = 0;
            while (i < s.Length / 2)
            {
                string curStr = s.Substring(0, (i + 1));
                long current = long.Parse(curStr);

                for (int j = (i + 1); j < s.Length; j += curStr.Length)
                {
                    current = current + 1;
                    curStr = current.ToString();

                    if ((j + curStr.Length) <= s.Length && (curStr == s.Substring(j, curStr.Length))) isB = true;
                    else isB = false;
                    if (!isB) break; // next split does not meet conditions, try next iteration
                }
                i++;
                if (isB) break; // found beautiful string, break out
            }
            string result = isB ? $"YES {s.Substring(0, i)}" : "NO";
            Console.WriteLine(result);
        }
    }

    class Solution
    {
        public static void Main(string[] args)
        {
            int q = Convert.ToInt32(Console.ReadLine().Trim());

            for (int qItr = 0; qItr < q; qItr++)
            {
                string s = Console.ReadLine();

                Result.SeparateNumbers(s);
            }
        }
    }
}




// alternate solution
// public static void separateNumbers(string s)
//     {
//             if (s[0] == '0') { Console.WriteLine("NO"); return; }
//             if (s.Length == 1) { Console.WriteLine("NO"); return; }

//             bool isB = false;
//             string curStr = string.Empty;
//             List<string> splitArr = new List<string>();

//             for (int i = 0; i < s.Length/2; i++)
//             {
//                 curStr = s.Substring(0, (i + 1));
//                 long current = long.Parse(curStr);
//                 splitArr = new List<string>{curStr};

//                 for (int j = (i + 1); j < s.Length; j += curStr.Length)
//                 {
//                     // find next largest substring
//                     // either same length as current or one digit larger
//                     if (s[0] == '0' || (j + curStr.Length) > s.Length) { isB = false; break; }

//                     string nextStr = s.Substring(j, curStr.Length);
//                     long next = long.Parse(nextStr);
//                     if (next < current)
//                     {
//                         if ((j + curStr.Length + 1) > s.Length)
//                         {
//                             isB = false;
//                             break;
//                         }
//                         nextStr = s.Substring(j, curStr.Length + 1);
//                         next = long.Parse(nextStr);
//                     }

//                     if ((next - current) == 1)
//                     {
//                         isB = true;
//                         curStr = nextStr;
//                         current = next;
//                         splitArr.Add(curStr);
//                     } else isB = false;
//                     if (!isB) break; // next split does not meet conditions, try next iteration
//                 }
//                 if (isB) break;
//             }
//             string result = isB ? $"YES {splitArr[0]}" : "NO";
//             Console.WriteLine(result);
//         }