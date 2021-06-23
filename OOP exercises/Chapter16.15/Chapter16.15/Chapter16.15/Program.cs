using System;
using System.Collections.Generic;

namespace Chapter16._15
{
    class Program
    {
        public static void BubbleSort(LinkedList<int> list)
        {

        }

        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddLast(1);
            list.AddLast(3);
            list.AddLast(9);
            list.AddLast(6);
            list.AddLast(7);
            list.AddLast(4);
            list.AddLast(8);
            list.AddLast(5);
            BubbleSort(list);
        }
    }
}
