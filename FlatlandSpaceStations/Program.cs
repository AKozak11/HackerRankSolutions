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

namespace FlatlandSpaceStations
{


    class Result
    {   // Complete the flatlandSpaceStations function below.
        public static int FlatlandSpaceStations(int n, int[] c)
        {

            int maxDistance = 0;
            c = c.OrderBy(x => x).ToArray();

            // two cases:       
            if (c.Length == 1) // 1. only one space station - find max distance either from beginning or end of list
            {
                return Math.Max(c[0], n - c[0] - 1);
            }
            else // 2. multiple space stations - special case for i == 0 and i == c.length-1
            {
                for (int i = 0; i < c.Length; i++)
                {
                    int nearestStation = 0;
                    if (i.Equals(0)) // nearest station is either distance from start of list, or distance to city halfway between next station
                    {
                        int nextCity = (int)Math.Floor((decimal)((decimal)c[i + 1] - (decimal)c[i]) / (decimal)2);
                        nearestStation = Math.Max(c[i], nextCity);
                    }
                    else if (i.Equals(c.Length - 1)) // nearest station is either distance to end of list or distance to city halfway between previous station
                    {
                        int previousCity = (int)Math.Floor((decimal)((decimal)c[i] - (decimal)c[i - 1]) / (decimal)2);
                        nearestStation = Math.Max((n - 1 - c[i]), previousCity);
                    }
                    else // most conditions fall here, nearest station is either halfway to previous or next station
                    {
                        int nextCity = (int)Math.Floor((decimal)((decimal)c[i + 1] - (decimal)c[i]) / (decimal)2);
                        int previousCity = (int)Math.Floor((decimal)((decimal)c[i] - (decimal)c[i - 1]) / (decimal)2);
                        nearestStation = Math.Max(nextCity, previousCity);
                    }
                    if (nearestStation > maxDistance) maxDistance = nearestStation;
                }
            }
            return maxDistance;
        }
    }
    class Solution
    {
        static void Main(string[] args)
        {

            string[] nm = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nm[0]);

            int m = Convert.ToInt32(nm[1]);

            int[] c = Array.ConvertAll(Console.ReadLine().Split(' '), cTemp => Convert.ToInt32(cTemp))
            ;
            int result = Result.FlatlandSpaceStations(n, c);
            Console.WriteLine(result);
        }
    }
}