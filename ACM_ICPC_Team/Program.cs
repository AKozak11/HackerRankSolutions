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

namespace ACMICPCTeam
{
    class Result
    {

        /*
         * Complete the 'acmTeam' function below.
         *
         * The function is expected to return an INTEGER_ARRAY.
         * The function accepts STRING_ARRAY topic as parameter.
         */

        public static List<int> AcmTeam(List<string> attendeeData)
        {

            int maxTopics = 0, teams = 0;
            for (int i = 0; i < attendeeData.Count - 1; i++)
            {
                for (int j = (i + 1); j < attendeeData.Count; j++)
                {
                    int count = 0;
                    for (int x = 0; x < attendeeData[0].Length; x++)
                    {
                        if (attendeeData[i][x].Equals('1') || attendeeData[j][x].Equals('1')) count++;
                    }

                    if (count == maxTopics) teams++;
                    else if (count > maxTopics)
                    {
                        maxTopics = count;
                        teams = 1;
                    }
                }


            }

            return new List<int> { maxTopics, teams };
        }

    }

    class Solution
    {
        public static void Main(string[] args)
        {
            List<string> data = new List<string>{
                "1010111",
                "1010101",
                "0100000",
                "0100010"
            };

            List<int> result = Result.AcmTeam(data);
            Console.WriteLine($"{result[0]} - {result[1]}");
        }
    }
}

// 52868049610316
// 8795858741151
// 37403538391840
// 54886391696162
// 34032980757779
// 67076898743696
// 28154198271566
// 31311204282760
// 30548223672138
// 86151466663811