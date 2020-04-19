using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Algorithms.CSharp.DataStructures.LinearDataStructures.Array
{
    public class Array
    {
        private int[] items;
        private int count;

        public Array(int length)
        {
            items = new int[length];
        }

        public void Insert(int item)
        {
            ResizeIfRequired();      

            items[count++] = item;
        }

        public void InsertAt(int item, int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = count - 1; i >= index; i--)
            {
                items[i + 1] = items[i];
            }

            items[index] = item;
            count++;
        }

        private void ResizeIfRequired()
        {
            if (items.Length == count)
            {
                int[] newItems = new int[count * 2];

                for (int i = 0; i < count; i++)
                {
                    newItems[i] = items[i];
                }

                items = newItems;
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = index; i < count - 1; i++)
            {
                items[i] = items[i + 1];
            }

            items[count - 1] = 0;
            count--;
        }

        public int IndexOf(int item)
        {
            for (int i = 0; i < count; i++)
            {
                if (items[i] == item)
                {
                    return i;
                }
            }

            return -1;
        }

        public int Max()
        {
            int max = 0;

            for (int i = 0; i < count; i++)
            {
                if (items[i] > max)
                {
                    max = items[i];
                }
            }

            return max;
        }

        public Array Intersect(Array other)
        {
            var intersection = new Array(count);

            for (int i = 0; i < count; i++)
            {
                if (other.IndexOf(items[i]) >= 0)
                {
                    intersection.Insert(items[i]);
                }
            }

            return intersection;
        }

        public void Reverse()
        {
            int[] newItems = new int[count];

            for (int i = 0; i < count; i++)
            {
                newItems[i] = items[count - i - 1];
            }

            items = newItems;
        }

        public void Print()
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(items[i]);
            }
        }
    }
}
