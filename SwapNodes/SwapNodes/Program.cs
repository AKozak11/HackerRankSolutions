using System;
using System.Collections.Generic;

namespace HackerRank
{
    class Node
    {
        public int Data { get; set; }
        public int Level { get; set; }
        public Node? Left { get; set; }
        public Node? Right { get; set; }
        public Node(int key)
        {
            Data = key;
        }
        public Node(int key, int depth)
        {
            Data = key;
            Level = depth;
        }
    }


    class Result
    {
        static List<Node> ParseInput(List<List<int>> indexes)
        {
            Node root = new Node(1, 1);
            List<Node> nodes = new List<Node>();
            nodes.Add(root);
            // result list for swapping with query values
            List<Node> queryNodes = new List<Node>();

            foreach (List<int> child in indexes)
            {
                Node current = nodes[0];
                nodes.RemoveAt(0);

                if (child[0] != -1)
                {
                    current.Left = new Node(child[0], current.Level + 1);
                    nodes.Add(current.Left);
                }
                if (child[1] != -1)
                {
                    current.Right = new Node(child[1], current.Level + 1);
                    nodes.Add(current.Right);
                }

                queryNodes.Add(current);
            }

            return queryNodes;

        }

        static List<Node> Swapper(List<Node> queryNodes, int query)
        {
            List<Node> result = new List<Node>();
            foreach (Node n in queryNodes)
            {
                if (n.Level % query == 0)
                {
                    Node temp = n.Left;
                    n.Left = n.Right;
                    n.Right = temp;
                }
            }
            return queryNodes;
        }
        static List<int> TraverseInOrder(Node root)
        {
            List<int> result = new List<int>();
            if (root is null)
            {
                return result;
            }

            result.AddRange(TraverseInOrder(root.Left));
            result.Add(root.Data);
            result.AddRange(TraverseInOrder(root.Right));

            return result;
        }
        public static List<List<int>> swapNodes(List<List<int>> indexes, List<int> queries)
        {
            List<Node> queryNodes = ParseInput(indexes);
            List<List<int>> result = new List<List<int>>();


            foreach (int q in queries)
            {
                queryNodes = Swapper(queryNodes, q);
                result.Add(TraverseInOrder(queryNodes[0]));
            }
            return result;

        }
    }
    class Solution
    {
        public static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<List<int>> indexes = new List<List<int>>();

            for (int i = 0; i < n; i++)
            {
                indexes.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(indexesTemp => Convert.ToInt32(indexesTemp)).ToList());
            }

            int queriesCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> queries = new List<int>();

            for (int i = 0; i < queriesCount; i++)
            {
                int queriesItem = Convert.ToInt32(Console.ReadLine().Trim());
                queries.Add(queriesItem);
            }

            List<List<int>> result = Result.swapNodes(indexes, queries);

            textWriter.WriteLine(String.Join("\n", result.Select(x => String.Join(" ", x))));

            textWriter.Flush();
            textWriter.Close();
        }

    }
}