using System;

namespace FormingMagicSquare
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Permute perm = new Permute();
            // perm.PrintPermut(new int[] { 1, 2, 3, 4 }, 0, 3);

            int size = 3;
            MagicSquare testObject = new MagicSquare(size);
            List<int[]> perms = new List<int[]>();
            perms = testObject.Permutations(new int[] { 1, 2, 3 }, 0, 2, ref perms);

            foreach (int[] perm in perms)
            {
                for (int i = 0; i < perm.Length; i++)
                {
                    Console.Write($"{perm[i]} ");
                }
                Console.Write("\n");
            }

        }
    }
}