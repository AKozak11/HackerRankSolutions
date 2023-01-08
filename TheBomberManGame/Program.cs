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
namespace BomberManGame
{
    class Result
    {
        public static List<string> GetFullGrid(int rows, int cols)
        {
            List<string> grid = new List<string>();
            for (int i = 0; i < rows; i++)
            {
                string row = string.Empty;
                for (int j = 0; j < cols; j++)
                {
                    row += 'O';
                }
                grid.Add(row);
            }
            return grid;
        }

        public static List<string> Detonate(List<string> state, List<string> grid)
        {
            for (int i = 0; i < grid.Count; i++)
            {
                List<char> currentRow = grid[i].ToList<char>();
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (state[i][j].Equals('O')) // bomb found in previous state
                    {
                        currentRow[j] = '.';

                        // left
                        if (!j.Equals(0)) currentRow[j - 1] = '.';

                        // right
                        if (j < (grid[i].Length - 1)) currentRow[j + 1] = '.';

                        // down
                        if (i < (state.Count - 1))
                        {
                            List<char> nextRow = grid[i + 1].ToList<char>();
                            nextRow[j] = '.';
                            grid[i + 1] = string.Join("", nextRow);
                        }
                        // up
                        if (!i.Equals(0))
                        {
                            List<char> previousRow = grid[i - 1].ToList<char>(); // get mutable reference to row above
                            previousRow[j] = '.'; // detonate position
                            grid[i - 1] = string.Join("", previousRow); // re assign to grid
                        }
                    }
                }
                grid[i] = string.Join("", currentRow);
            }
            return grid;
        }

        public static List<string> BomberMan(int n, List<string> grid)
        {
            // if one second, bomberman hasn't planted any bombs, return initial state
            if (n.Equals(1)) return grid;

            // if even number, bomber man has filled grid and not detonated yet
            if (n % 2 == 0) return GetFullGrid(grid.Count, grid[0].Length);

            // every other detonation will result in one of two states because each one just resets it back to the previous state
            List<string> detonatedStateOne = Detonate(grid, GetFullGrid(grid.Count, grid[0].Length));
            List<string> detonatedStateTwo = Detonate(detonatedStateOne, GetFullGrid(grid.Count, grid[0].Length));
            List<List<string>> states = new List<List<string>>() {
                detonatedStateOne, // first detonated state
                detonatedStateTwo // second detonated state
            };

            int count = 0;
            for (int i = 3; i <= n; i += 2)
            {
                count++;
            }

            if (count % 2 == 1)
            {
                return states[0];
            }
            else
            {
                return states[1];
            }
        }

    }

    class Solution
    {
        public static void Main(string[] args)
        {
            // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int r = Convert.ToInt32(firstMultipleInput[0]);

            int c = Convert.ToInt32(firstMultipleInput[1]);

            int n = Convert.ToInt32(firstMultipleInput[2]);

            List<string> grid = new List<string>();

            for (int i = 0; i < r; i++)
            {
                string gridItem = Console.ReadLine();
                grid.Add(gridItem);
            }

            List<string> result = Result.BomberMan(n, grid);

            Console.WriteLine(String.Join("\n", result));

            // textWriter.Flush();
            // textWriter.Close();
        }
    }
}