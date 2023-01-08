using System;
using System.Collections.Generic;

namespace TreeLevelOrderTraversal
{
    class Node
    {
        public int Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node(int key)
        {
            Data = key;
        }
    }
    class BinarySearchTree
    {
        public Node Root { get; set; }
        public void Insert(int key)
        {
            if (Root is null)
            {
                Root = new Node(key);
            }
            else Insert(Root, key);
        }
        private void Insert(Node node, int key)
        {
            if (node is not null)
            {
                if (node.Data > key)
                {
                    if (node.Left is not null)
                    {
                        Insert(node.Left, key);
                    }
                    else node.Left = new Node(key);
                }
                else if (node.Data < key)
                {
                    if (node.Right is not null)
                    {
                        Insert(node.Right, key);
                    }
                    else node.Right = new Node(key);
                }
            }
        }
    }
    class Solution
    {

        static IEnumerable<Node?> LevelOrder(Node? root)
        {
            Queue<Node?> queue = new Queue<Node?>();
            if (root is not null)
            {
                queue.Enqueue(root);
            }

            while (queue.Count > 0)
            {

                Node? current = queue.Dequeue();
                if (current is not null)
                {
                    if (current.Left is not null)
                    {
                        queue.Enqueue(current.Left);
                    }
                    if (current.Right is not null)
                    {
                        queue.Enqueue(current.Right);
                    }
                }
                yield return current;
            }
        }
        static void Main(String[] args)
        {

            int numberLength = Convert.ToInt16(Console.ReadLine());
            var values = Console.ReadLine().Split(' ');
            var binaryTree = new BinarySearchTree();

            for (int index = 0; index < numberLength; index++)
            {
                binaryTree.Insert(Convert.ToInt32(values[index]));
            }

            foreach (var node in LevelOrder(binaryTree.Root))
            {
                Console.Write(node.Data + " ");
            }
        }
    }
}