using System;
using System.Collections.Generic;


namespace ThreeSequences
{
    class Sequences
    {
        public static HashSet<long> first = new HashSet<long>();
        public static HashSet<long> second = new HashSet<long>();
        public static HashSet<long> third = new HashSet<long>();
        public static long FirstSequence(int ammount)
        {
            if (ammount > 0)
            {
                ammount--;
                long a = (FirstSequence(ammount) * 2) + 3;
                first.Add(a);
                return a;
            }
            else
            {
                int minValue = 1;
                first.Add(minValue);
                return minValue;
            }
        }

        public static long SecondSequence(int ammount)
        {
            if (ammount > 0)
            {
                ammount--;
                long a = (SecondSequence(ammount) * 3) + 1;
                second.Add(a);
                return a;
            }
            else
            {
                int minValue = 2;
                second.Add(minValue);
                return minValue;
            }
        }

        public static long ThirdSequence(int ammount)
        {
            if (ammount > 0)
            {
                ammount--;
                long a = (ThirdSequence(ammount) * 2) - 1;
                third.Add(a);
                return a;
            }
            else
            {
                int minValue = 2;
                third.Add(minValue);
                return minValue;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Sequences.FirstSequence(15);
            Sequences.SecondSequence(15);
            Sequences.ThirdSequence(15);
            Sequences.first.UnionWith(Sequences.second);

            foreach (int ele in Sequences.first)
            {
                Console.Write(ele + " ");
            }
            Console.WriteLine();
            Sequences.second.UnionWith(Sequences.third);

            foreach (int ele in Sequences.second)
            {
                Console.Write(ele + " ");
            }
        }
    }
}
