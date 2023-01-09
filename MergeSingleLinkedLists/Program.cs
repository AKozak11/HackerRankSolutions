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
namespace meh
{
    class Solution
    {

        class SinglyLinkedListNode
        {
            public int data;
            public SinglyLinkedListNode next;

            public SinglyLinkedListNode(int nodeData)
            {
                this.data = nodeData;
                this.next = null;
            }
        }

        class SinglyLinkedList
        {
            public SinglyLinkedListNode head;
            public SinglyLinkedListNode tail;

            public SinglyLinkedList()
            {
                this.head = null;
                this.tail = null;
            }

            public void InsertNode(int nodeData)
            {
                SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

                if (this.head == null)
                {
                    this.head = node;
                }
                else
                {
                    this.tail.next = node;
                }

                this.tail = node;
            }
        }

        static void PrintSinglyLinkedList(SinglyLinkedListNode node, string sep, TextWriter textWriter)
        {
            while (node != null)
            {
                textWriter.Write(node.data);

                node = node.next;

                if (node != null)
                {
                    textWriter.Write(sep);
                }
            }
        }
        static SinglyLinkedListNode mergeLists(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
        {
            SinglyLinkedList list3 = new SinglyLinkedList();
            SinglyLinkedListNode current1 = head1;
            SinglyLinkedListNode current2 = head2;

            // insert head node
            if (head1 is not null && head2 is not null)
            {
                if (head1.data < head2.data)
                {
                    list3.InsertNode(current1.data);
                    current1 = current1.next;
                }
                else
                {
                    list3.InsertNode(current2.data);
                    current2 = current2.next;
                }
            }
            while (current1 is not null || current2 is not null)
            {
                if (current1 is null)
                {
                    list3.InsertNode(current2.data);
                    current2 = current2.next;
                }
                else if (current2 is null)
                {
                    list3.InsertNode(current1.data);
                    current1 = current1.next;
                }
                else
                {
                    // both current nodes contain data
                    // need to set smallest value as next
                    if (current1.data < current2.data)
                    {
                        list3.InsertNode(current1.data);
                        current1 = current1.next;
                    }
                    else
                    {
                        list3.InsertNode(current2.data);
                        current2 = current2.next;
                    }
                }
            }


            return list3.head;
        }

        static void Main(string[] args)
        {
            SinglyLinkedList list1 = new SinglyLinkedList();
            SinglyLinkedList list2 = new SinglyLinkedList();
            list1.InsertNode(1);
            list1.InsertNode(2);
            list1.InsertNode(3);
            list1.InsertNode(5);
            list2.InsertNode(3);
            list2.InsertNode(4);

            SinglyLinkedListNode head3 = mergeLists(list1.head, list2.head);

            SinglyLinkedListNode current = head3;

            while (current is not null)
            {
                Console.WriteLine(current.data);
                current = current.next;
            }
        }
    }
}
