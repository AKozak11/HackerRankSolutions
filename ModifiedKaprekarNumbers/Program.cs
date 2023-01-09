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

namespace ModifiedKaprekarNumbers
{
    class Result
    {

        public static bool IsKaprekarNumber(int num)
        {
            long square = (long)num * (long)num;

            int digits = num.ToString().Length;
            long divisor = (long)Math.Pow((double)10, (double)digits);

            int x = (int)(square % divisor);
            square /= divisor;

            int y = (int)square;

            if ((x + y) == num) return true;

            return false;
        }

        public static void kaprekarNumbers(int p, int q)
        {
            int count = 0;
            while (p <= q)
            {
                if (IsKaprekarNumber(p))
                {
                    Console.Write($"{p} ");
                    count++;
                }
                p++;
            }
            if (count.Equals(0)) Console.Write("INVALID RANGE");
        }

    }

    class Solution
    {
        public static void Main(string[] args)
        {
            Result.kaprekarNumbers(1, 99999);
            Console.WriteLine(Result.IsKaprekarNumber(45));
            Console.WriteLine(Result.IsKaprekarNumber(82656));
            Console.WriteLine(Result.IsKaprekarNumber(55));
            Console.WriteLine(Result.IsKaprekarNumber(77));
        }
    }
}