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

namespace InsertionSort2
{
    class Result
    {

        public static void InsertionSort2(int n, List<int> arr)
        {
            for (int i = 1; i < n; i++)
            {

                // value to insert if necessary
                int insertionValue = arr[i];

                // compare to each lower index
                // search for insertion point
                int j = i;
                while (j > 0 && insertionValue < arr[j - 1])
                {
                    j--;
                }

                if (i == j) { Console.WriteLine(string.Join(" ", arr)); continue; } // no insertion point found, print current status, continue

                for (int k = i; k > j; k--)
                {
                    arr[k] = arr[k - 1]; // shift values until insertion point reached
                }

                // insert at insertion point
                arr[j] = insertionValue;

                Console.WriteLine(string.Join(" ", arr)); // also print after each insert operation

            }
        }

    }

    class Solution
    {
        public static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            Result.InsertionSort2(n, arr);
        }
    }
}