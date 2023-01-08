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
namespace InsertionSortAdvancedAnalysis
{
    class Result
    {
        // number of shifts = number of inversions
        public static long Merge(List<int> arr, int l, int m, int r)
        {
            int lLength = m - l + 1;
            int rLength = r - m;

            int[] tempLeft = new int[lLength];
            int[] tempRight = new int[rLength];

            long shifts = 0;

            int i = 0, j = 0;
            for (i = 0; i < lLength; i++) tempLeft[i] = arr[l + i];
            for (j = 0; j < rLength; j++) tempRight[j] = arr[m + j + 1];

            i = 0;
            j = 0;
            int k = l;

            while (i < lLength && j < rLength)
            {
                if (tempLeft[i] <= tempRight[j]) arr[k++] = tempLeft[i++];
                else
                {
                    arr[k++] = tempRight[j++];
                    shifts += (long)(lLength - i);
                }
            }

            while (i < lLength) arr[k++] = tempLeft[i++];
            while (j < rLength) arr[k++] = tempRight[j++];

            return shifts;
        }
        public static long Sort(List<int> arr, int l, int r)
        {
            if (l >= r) return 0;
            int mid = l + (r - l) / 2;
            long shifts = 0;

            shifts += Sort(arr, l, mid);
            shifts += Sort(arr, (mid + 1), r);
            shifts += Merge(arr, l, mid, r);

            return shifts;
        }
        public static long InsertionSort(List<int> arr)
        {
            return Result.Sort(arr, 0, (arr.Count - 1));
        }

    }

    class Solution
    {
        public static void Main(string[] args)
        {
            // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int t = Convert.ToInt32(Console.ReadLine().Trim());

            for (int tItr = 0; tItr < t; tItr++)
            {
                int n = Convert.ToInt32(Console.ReadLine().Trim());

                List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

                long result = Result.InsertionSort(arr);

                Console.WriteLine(result);
                // textWriter.WriteLine(result);
            }

            // textWriter.Flush();
            // textWriter.Close();
        }
    }
}


// 38046
// 78149
// 97560
// 174498
// 3083