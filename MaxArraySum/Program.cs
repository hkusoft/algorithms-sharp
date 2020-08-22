using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxArraySum
{
    public class Program
    {
        public static int MaxSubsetSum(List<int> list)
        {
            if (list.Count <= 2)
                return list.Max();

            if (list.Count == 3)
            {
                var sum13 = list[0] + list[2];
                return Math.Max(list.Max(), sum13);
            }

            var last = list.Last();

            var list0 = list.Take(list.Count - 1).ToList();
            var max0 = MaxSubsetSum(list0);
            var max1 = Math.Max(max0, last);

            var list1 = list0.Take(list0.Count - 1).ToList();
            var max2 = MaxSubsetSum(list1);

            return Math.Max(max1, max2 + last);
        }


        static void Main(string[] args)
        {

            var list = new List<int>() { 2, 1, 5 };
            Console.WriteLine(MaxSubsetSum(list));  //7

            list = new List<int>() { 2, 1 };
            Console.WriteLine(MaxSubsetSum(list));  //2

            list = new List<int>() { 1 };
            Console.WriteLine(MaxSubsetSum(list));  //1

            list = new List<int>() { 2, 1, 5, 8 };
            Console.WriteLine(MaxSubsetSum(list));  //10

            list = new List<int>() { 2, 1, 5, 8, 4 };
            Console.WriteLine(MaxSubsetSum(list));  //11

        }
    }
}
