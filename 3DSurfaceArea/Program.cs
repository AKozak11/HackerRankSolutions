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

namespace ThreeDSurfaceArea
{

    class Result
    {

        /*
         * Complete the 'surfaceArea' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts 2D_INTEGER_ARRAY A as parameter.
         */

        public static int SurfaceArea(List<List<int>> A)
        {
            int area = 0;
            for (int i = 0; i < A.Count; i++)
            {
                // iterate through each row
                for (int j = 0; j < A[i].Count; j++)
                {
                    // bottom and top area += 1 for every non zero entry
                    if (!A[i][j].Equals(0)) area += 2; // add 2 to account for top and bottom

                    // outer left/right walls
                    if (i.Equals(0)) area += A[i][j]; // outer left wall
                    if (i.Equals(A.Count - 1)) area += A[i][j]; // outer right wall
                                                                // inner left/right walls
                    if (A.Count > 1 && i < (A.Count - 1)) // inter-column
                    {
                        // for each height, compare to height of block in next row of same column. difference is an inner wall
                        area += Math.Abs(A[i][j] - A[i + 1][j]);
                    }

                    // outer front/back walls
                    if (j.Equals(0)) area += A[i][j]; // outer front wall
                    if (j.Equals(A[i].Count - 1)) area += A[i][j]; // outer back wall
                                                                   // inner front/back walls
                    if (A[i].Count > 1 && j < (A[i].Count - 1)) // inter-row
                    {
                        // compare to next block height
                        area += Math.Abs(A[i][j] - A[i][j + 1]);
                    }
                }
            }
            return area;
        }

    }

    class Solution
    {
        public static void Main(string[] args)
        {
            // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int H = Convert.ToInt32(firstMultipleInput[0]);

            int W = Convert.ToInt32(firstMultipleInput[1]);

            List<List<int>> A = new List<List<int>>();

            for (int i = 0; i < H; i++)
            {
                A.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(ATemp => Convert.ToInt32(ATemp)).ToList());
            }

            int result = Result.SurfaceArea(A);

            Console.WriteLine(result);

            // textWriter.Flush();
            // textWriter.Close();
        }
    }
}