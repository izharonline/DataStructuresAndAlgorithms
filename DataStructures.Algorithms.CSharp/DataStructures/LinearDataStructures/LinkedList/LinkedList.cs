using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAlgorithms.CSharp.DataStructures.LinearDataStructures.LinkedList
{
    public class LinkedList
    {
        private class Node
        {
            public int Value { get; set; }
            public Node Next { get; set; }

            public Node(int value)
            {
                this.Value = value;
            }
        }

        private Node first;
        private Node last;
        private int size;

        //Time: O(1)
        public void AddLast(int item)
        {
            var node = new Node(item);

            if (IsEmpty())
            {
                first = last = node;
            }
            else
            {
                last.Next = node;
                last = node;
            }

            size++;
        }

        //Time: O(1)
        public void AddFirst(int item)
        {
            var node = new Node(item);

            if (IsEmpty())
            {
                first = last = node;
            }
            else
            {
                node.Next = first;
                first = node;
            }

            size++;
        }

        private bool IsEmpty()
        {
            return first == null;
        }

        //Time: O(n)
        public int IndexOf(int item)
        {
            int index = 0;
            var current = first;

            while (current != null)
            {
                if (current.Value == item)
                {
                    return index;
                }

                current = current.Next;
                index++;
            }

            return -1;
        }

        //Time: O(n)
        public bool Contains(int item)
        {
            return IndexOf(item) != -1;
        }

        //Time: O(1)
        public void RemoveFirst()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The LinkedList is empty.");
            }

            if (first == last)
            {
                first = last = null;                
            }
            else
            {
                var second = first.Next;
                first.Next = null;
                first = second;
            }           

            size--;
        }

        //Time: O(n)
        public void RemoveLast()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The LinkedList is empty.");
            }

            if (first == last)
            {
                first = last = null;                
            }
            else
            {
                var previous = GetPrevious(last);
                last = previous;
                previous.Next = null;
            }            

            size--;
        }

        private Node GetPrevious(Node node)
        {
            var current = first;

            while (current != null)
            {
                if (current.Next == node)
                {
                    return current;
                }

                current = current.Next;
            }

            return null;
        }

        //Time: O(1)
        public int Size()
        {
            return size;
        }

        //Time: O(n)
        public int[] ToArray()
        {
            int[] array = new int[size];
            var current = first;
            var index = 0;

            while (current != null)
            {
                array[index++] = current.Value;
                current = current.Next;
            }

            return array;
        }

        //Time: O(n)
        public void Reverse()
        {
            if (IsEmpty())
            {
                return;
            }

            var previous = first;
            var current = first.Next;

            while (current != null)
            {
                var next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }

            last = first;
            last.Next = null;
            first = previous;
        }

        //O(n)
        public int GetKthFromTheEnd(int k)
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The LinkedList is empty.");
            }

            var a = first;
            var b = first;

            for (int i = 0; i < k - 1; i++)
            {
                b = b.Next;

                if (b == null)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }

            while (b != last)
            {
                a = a.Next;
                b = b.Next;
            }

            return a.Value;
        }

        //Time: O(n)
        public void PrintMiddle()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The LinkedList is empty.");
            }

            var a = first;
            var b = first;

            while (b != last && b.Next != last)
            {
                b = b.Next.Next;
                a = a.Next;
            }

            if (b == last)
            {
                Console.WriteLine(a.Value);
            }
            else
            {
                Console.WriteLine(a.Value + ", " + a.Next.Value);
            }
        }

        //Time O(n)
        public bool HasLoop()
        {
            var slow = first;
            var fast = first;

            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;

                if (slow == fast)
                {
                    return true;
                }
            }            

            return false;
        }

        public static LinkedList CreateWithLoop()
        {
            var list = new LinkedList();
            list.AddLast(10);
            list.AddLast(20);
            list.AddLast(30);

            // Get a reference to 30
            var node = list.last;

            list.AddLast(40);
            list.AddLast(50);

            // Create the loop
            list.last.Next = node;

            return list;
        }
    }
}
