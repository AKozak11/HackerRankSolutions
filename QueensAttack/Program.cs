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

namespace QuennsAttack
{
    class Result
    {
        private static HashSet<string> obstacleHash = new HashSet<string>();
        public static int MoveLeft(int qRow, int qCol, int count)
        {
            if (qCol < 1 || obstacleHash.Contains($"{qRow}_{qCol}")) return count - 1;
            return MoveLeft(qRow, (qCol - 1), (count + 1));
        }
        public static int MoveLeftDown(int qRow, int qCol, int count)
        {
            if (qCol < 1 || qRow < 1 || obstacleHash.Contains($"{qRow}_{qCol}")) return count - 1;
            return MoveLeftDown((qRow - 1), (qCol - 1), (count + 1));
        }
        public static int MoveDown(int qRow, int qCol, int count)
        {
            if (qRow < 1 || obstacleHash.Contains($"{qRow}_{qCol}")) return count - 1;
            return MoveDown((qRow - 1), qCol, (count + 1));
        }
        public static int MoveRightDown(int qRow, int qCol, int length, int count)
        {
            if (qRow < 1 || qCol > length || obstacleHash.Contains($"{qRow}_{qCol}")) return count - 1;
            return MoveRightDown((qRow - 1), (qCol + 1), length, (count + 1));
        }

        public static int MoveRight(int qRow, int qCol, int length, int count)
        {
            if (qCol > length || obstacleHash.Contains($"{qRow}_{qCol}")) return count - 1;
            return MoveRight(qRow, (qCol + 1), length, (count + 1));
        }
        public static int MoveRightUp(int qRow, int qCol, int length, int count)
        {
            if (qRow > length || qCol > length || obstacleHash.Contains($"{qRow}_{qCol}")) return count - 1;
            return MoveRightUp((qRow + 1), (qCol + 1), length, (count + 1));
        }
        public static int MoveUp(int qRow, int qCol, int length, int count)
        {
            if (qRow > length || obstacleHash.Contains($"{qRow}_{qCol}")) return count - 1;
            return MoveUp((qRow + 1), qCol, length, (count + 1));
        }
        public static int MoveLeftUp(int qRow, int qCol, int length, int count)
        {
            if (qRow > length || qCol < 1 || obstacleHash.Contains($"{qRow}_{qCol}")) return count - 1;
            return MoveLeftUp((qRow + 1), (qCol - 1), length, (count + 1));
        }

        public static int QueensAttack(int n, int k, int r_q, int c_q, List<List<int>> obstacles)
        {
            foreach (List<int> ob in obstacles)
            {
                obstacleHash.Add($"{ob[0]}_{ob[1]}");
            }
            int count = 0;
            count += MoveLeft(r_q, c_q, 0);
            count += MoveLeftDown(r_q, c_q, 0);
            count += MoveDown(r_q, c_q, 0);
            count += MoveRightDown(r_q, c_q, n, 0);
            count += MoveRight(r_q, c_q, n, 0);
            count += MoveRightUp(r_q, c_q, n, 0);
            count += MoveUp(r_q, c_q, n, 0);
            count += MoveLeftUp(r_q, c_q, n, 0);

            return count;
        }

    }

    class Solution
    {
        public static void Main(string[] args)
        {
            // test case 1
            // 6 |   |   |   |   |   |   |
            // 5 |   |   |   |   |   |   |
            // 4 |   |   |   |   |   |   |
            // 3 |   |   | Q |   |   |   |
            // 1 |   |   |   |   |   |   |
            // 2 |   |   |   |   |   |   |
            //     1   2   3   4   5   6

            // Count queenattack shoud return 19

            int queenRow = 3;
            int queenCol = 3;
            List<List<int>> obstacles = new List<List<int>>();
            Console.WriteLine(Result.QueensAttack(6, 0, queenRow, queenCol, obstacles));

            // test case 2
            // 6 |   |   |   |   |   |   |
            // 5 | X |   |   |   |   |   |
            // 4 |   |   |   |   |   |   |
            // 3 |   |   | Q | X |   |   |
            // 1 |   |   |   |   |   |   |
            // 2 |   |   |   |   |   |   |
            //     1   2   3   4   5   6

            // Count queenattack shoud return 15

            queenRow = 3;
            queenCol = 3;
            obstacles = new List<List<int>>{
                new List<int> {5, 1},
                new List<int> {3, 4}
            };

            Console.WriteLine(Result.QueensAttack(6, 0, queenRow, queenCol, obstacles));
        }
    }
}