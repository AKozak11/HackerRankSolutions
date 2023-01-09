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

namespace EmasSuperComputer
{
    class Result
    {
        public static int twoPluses(List<string> grid)
        {
            // the following code creates a border around the original grid
            // to prevent out of bounds errors 
            List<string> temp = new List<string>();
            string row = string.Empty;
            for (int x = 0; x < (grid[0].Length + 2); x++) row += 'O';
            temp.Add(row);
            for (int y = 0; y < grid.Count; y++) temp.Add('O' + grid[y] + 'O');
            temp.Add(row);

            grid = temp;

            int answer = 0;

            for (int i = 1; i < (grid.Count - 1); i++)
            {
                for (int j = 1; j < (grid[i].Length - 1); j++)
                {
                    if (grid[i][j] == 'B') continue;
                    int r = 0;
                    List<char> currentRow = grid[i].ToList();
                    while (grid[i - r][j] == 'G' && grid[i + r][j] == 'G' && grid[i][j - r] == 'G' && grid[i][j + r] == 'G')
                    {
                        // mark cells as occupied (lowercase 'g')
                        List<char> previousRow = grid[i - r].ToList();
                        List<char> nextRow = grid[i + r].ToList();
                        currentRow[j - r] = 'g';
                        currentRow[j + r] = 'g';
                        previousRow[j] = 'g';
                        nextRow[j] = 'g';
                        grid[i] = string.Join("", currentRow);
                        grid[i - r] = string.Join("", previousRow);
                        grid[i + r] = string.Join("", nextRow);

                        // use same logic to find every plus and compare to answer (also compare with current plus marked with lowercase gs))
                        for (int I = 1; I < (grid.Count - 1); I++)
                        {
                            for (int J = 1; J < (grid[I].Length - 1); J++)
                            {
                                if (grid[I][J] == 'B') continue;
                                int R = 0;
                                while (grid[I - R][J] == 'G' && grid[I + R][J] == 'G' && grid[I][J - R] == 'G' && grid[I][J + R] == 'G')
                                {
                                    answer = Math.Max(answer, (r * 4 + 1) * (R * 4 + 1));
                                    R++;
                                }
                            }
                        }

                        r++;
                    }

                    // revert occupied cells
                    r = 0;
                    currentRow = grid[i].ToList<char>();
                    while (grid[i - r][j] == 'g' && grid[i + r][j] == 'g' && grid[i][j - r] == 'g' && grid[i][j + r] == 'g')
                    {
                        List<char> previousRow = grid[i - r].ToList();
                        List<char> nextRow = grid[i + r].ToList();
                        currentRow[j - r] = 'G';
                        currentRow[j + r] = 'G';
                        previousRow[j] = 'G';
                        nextRow[j] = 'G';
                        grid[i] = string.Join("", currentRow);
                        grid[i - r] = string.Join("", previousRow);
                        grid[i + r] = string.Join("", nextRow);

                        r++;
                    }
                }
            }
            return answer;
        }

    }

    class Solution
    {
        public static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int m = Convert.ToInt32(firstMultipleInput[1]);

            List<string> grid = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string gridItem = Console.ReadLine();
                grid.Add(gridItem);
            }

            int result = Result.twoPluses(grid);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}