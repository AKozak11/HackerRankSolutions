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

namespace FraudActivityNotifications
{
    class Result
    {
        private static Dictionary<int, int> freq;

        public static int GetMedian(int index)
        {
            int total = 0;
            for (int i = 0; i <= 200; i++)
            {
                if (freq.ContainsKey(i)) total += freq[i];
                if (total >= index) return i;
            }
            return total;
        }

        public static int ActivityNotifications(List<int> expenditure, int d)
        {
            freq = new Dictionary<int, int>();
            for (int i = 0; i < d; i++)
            {
                if (freq.ContainsKey(expenditure[i])) freq[expenditure[i]]++;
                else freq.Add(expenditure[i], 1);
            }

            int count = 0;
            for (int i = d; i < expenditure.Count; i++)
            {
                int median = GetMedian(d / 2 + d % 2);
                int maxExpenditure = median * 2;

                if (d % 2 == 0) maxExpenditure = median + GetMedian(d / 2 + 1);

                if (expenditure[i] >= maxExpenditure) count++;

                if (freq.ContainsKey(expenditure[i])) freq[expenditure[i]]++;
                else freq.Add(expenditure[i], 1);

                freq[expenditure[i - d]]--;
            }
            return count;
        }
    }

    class Solution
    {
        public static void Main(string[] args)
        {
            // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int d = Convert.ToInt32(firstMultipleInput[1]);

            List<int> expenditure = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(expenditureTemp => Convert.ToInt32(expenditureTemp)).ToList();

            int result = Result.ActivityNotifications(expenditure, d);

            Console.WriteLine(result);

            // textWriter.Flush();
            // textWriter.Close();
        }
    }
}