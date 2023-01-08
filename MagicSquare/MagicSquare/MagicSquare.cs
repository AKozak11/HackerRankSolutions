using System;
using System.Collections.Generic;

namespace FormingMagicSquare
{
    public class MagicSquare
    {
        private int _size;
        private int[] _distinctNums;
        private List<int[]> _permutations;
        public MagicSquare(int size)
        {
            _size = size;
            _distinctNums = new int[_size * _size];
            _permutations = new List<int[]>();
            GenerateInitialList();
        }

        private void GenerateInitialList()
        {
            int length = (_size * _size); // size of 2d array is size squared
            for (int i = 0; i < length; i++)
            {
                _distinctNums[i] = (i + 1);
            }
        }
        private void GeneratePermutations()
        {
            Permutations(_distinctNums, 0, _distinctNums.Length - 1, ref _permutations);
        }

        private List<int[,]> ConvertPermutationsToTwoDimensionalArrays()
        {
            List<int[,]> perms = new List<int[,]>();
            GeneratePermutations();
            foreach (int[] perm in _permutations)
            {
                int index = 0;
                int[,] tempList = new int[_size, _size];

                for (int i = 0; i < _size; i++)
                {
                    for (int j = 0; j < _size; j++)
                    {
                        tempList[i, j] = perm[index];
                        index++;
                    }
                }
                perms.Add(tempList);
            }
            return perms;
        }
        public List<int[,]> FindAllPossibleMagicSquares()
        {
            List<int[,]> result = new List<int[,]>();
            List<int[,]> perms = ConvertPermutationsToTwoDimensionalArrays();
            foreach (int[,] perm in perms)
            {
                bool isMagic = true;
                int leftDiag = 0;
                int rightDiag = 0;
                int tempRow = 0;
                int tempCol = 0;

                for (int i = 0; i < _size; i++)
                {
                    int col = 0;
                    int row = 0;
                    for (int j = 0; j < _size; j++)
                    {
                        row += perm[i, j];
                        col += perm[j, i];
                    }
                    if (row != col) isMagic = false;
                    if (tempRow != 0 && row != tempRow) isMagic = false;
                    if (tempCol != 0 && col != tempCol) isMagic = false;

                    tempCol = col;
                    tempRow = row;
                    leftDiag += perm[i, i];
                    rightDiag += perm[i, (_size - (i + 1))];
                }
                if (leftDiag != rightDiag || leftDiag != tempRow) continue;
                if (!isMagic) continue;

                result.Add(perm);
            }
            return result;
        }
        public void Swap(ref int i, ref int j)
        {
            int temp = i;
            i = j;
            j = temp;
        }
        // public method only used for unit testing
        public List<int[]> Permutations(int[] nums, List<int[]> perms)
        {
            return Permutations(nums, 0, nums.Length - 1, ref perms);
        }
        public List<int[]> Permutations(int[] nums, int start, int end, ref List<int[]> perms)
        {
            if (start == end)
            {
                perms.Add(nums.ToArray());
            }
            else
            {
                for (int i = start; i <= end; i++)
                {
                    Swap(ref nums[start], ref nums[i]);
                    Permutations(nums, start + 1, end, ref perms);
                    Swap(ref nums[i], ref nums[start]);
                }
            }
            return perms;
        }

    }
}