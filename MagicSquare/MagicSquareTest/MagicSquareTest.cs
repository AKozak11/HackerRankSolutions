using Xunit;
using System;
using System.Collections.Generic;
using FormingMagicSquare;

namespace FormingMagicSquareTest
{

    public class MagicSquareTest
    {
        private readonly int DEFAULT_SIZE = 3;
        private MagicSquare testObject;
        public MagicSquareTest()
        {
            testObject = new MagicSquare(DEFAULT_SIZE);
        }
        [Fact]
        public void GeneratePermutations_ShouldGenerate_ListOfPermutations()
        {
            int[] nums = { 1, 2, 3 };
            List<int[]> perms = new List<int[]>();

            testObject.Permutations(nums, perms);
            int expectedSize = 6;

            Assert.Contains(new int[] { 1, 2, 3 }, perms);
            Assert.Contains(new int[] { 2, 1, 3 }, perms);
            Assert.Contains(new int[] { 2, 3, 1 }, perms);
            Assert.Contains(new int[] { 1, 3, 2 }, perms);
            Assert.Contains(new int[] { 3, 1, 2 }, perms);
            Assert.Contains(new int[] { 3, 2, 1 }, perms);
            Assert.Equal(expectedSize, perms.Count);
        }
        [Fact]
        public void Swap_Should_SwapValues()
        {
            int[] nums = { 1, 2, 3, 4 };
            int[] expected = { 1, 3, 2, 4 };

            // swap values at index 1 and index 2
            testObject.Swap(ref nums[1], ref nums[2]);
            Assert.Equal(expected, nums);
        }
    }
}