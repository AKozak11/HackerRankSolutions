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

class Result
{

    /*
     * Complete the 'almostSorted' function below.
     *
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static void AlmostSorted(List<int> arr)
    {
        List<int> swapArr = arr.Select(x => x).ToList();
        List<int> reverseArr = arr.Select(x => x).ToList();
        int l = 0, r = 0;
        // iterate through array
        while (l < (arr.Count - 1))
        {
            // compare values
            if (arr[l] < arr[l + 1]) { l++; continue; }


            r = (l + 1);
            while (r < (arr.Count - 1) && arr[l] > arr[r + 1]) r++;

            // try swapping
            int temp = swapArr[r];
            swapArr[r] = swapArr[l];
            swapArr[l] = temp;

            // try reversing
            for (int j = 0; j <= ((r - l) / 2); j++)
            {
                temp = reverseArr[l + j];
                reverseArr[l + j] = reverseArr[r - j];
                reverseArr[r - j] = temp;
            }

            break; // only one operation permitted, break out of loop
        }
        // check if either is sorted
        int x = 1;
        int y = 1;
        while (x < swapArr.Count && swapArr[x] > swapArr[x - 1]) x++;
        while (y < reverseArr.Count && reverseArr[y] > reverseArr[y - 1]) y++;

        if (x == swapArr.Count)
        {
            Console.WriteLine("yes");
            Console.WriteLine($"swap {l + 1} {r + 1}");
        }
        else if (y == reverseArr.Count)
        {
            Console.WriteLine("yes");
            Console.WriteLine($"reverse {l + 1} {r + 1}");
        }
        else Console.WriteLine("no");
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        Result.AlmostSorted(arr);
    }
}
