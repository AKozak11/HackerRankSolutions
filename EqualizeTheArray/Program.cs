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
namespace EqualizeTheArray
{
    class Result
    {

        /*
         * Complete the 'equalizeArray' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts INTEGER_ARRAY arr as parameter.
         */

        public static int EqualizeArray(List<int> arr)
        {
            Dictionary<int, int> myDic = new Dictionary<int, int>();

            foreach (int num in arr.Distinct())
            {
                myDic.Add(num, 0);
            }

            for (int i = 0; i < arr.Count; i++)
            {
                myDic[arr[i]]++;
            }

            return arr.Count - myDic.Values.Max();
        }

    }

    class Solution
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Result.EqualizeArray(new List<int> { 1, 7, 4, 5, 1, 7, 8, 9, 7, 7 }));
        }
    }
}