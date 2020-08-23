using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxArraySum
{
    public class Program
    {
        public static int MaxSubsetSum(int [] arr)
        {
            if (arr.Length <= 2)
                return arr.Max();

            if (arr.Length == 3)
            {
                var sum13 = arr[0] + arr[2];
                return Math.Max(arr.Max(), sum13);
            }

            var last = arr[^1];
            var list0 = arr[..^1];
            var max0 = MaxSubsetSum(list0);
            var max1 = Math.Max(max0, last);

            var list1 = arr[..^2];
            var max2 = MaxSubsetSum(list1);

            return Math.Max(max1, max2 + last);
        }


        static void Main(string[] args)
        {

            var list = new [] { 2, 1, 5 };
            Console.WriteLine(MaxSubsetSum(list));  //7

            list = new[] { 2, 1 };
            Console.WriteLine(MaxSubsetSum(list));  //2

            list = new []  { 1 };
            Console.WriteLine(MaxSubsetSum(list));  //1

            list = new []  { 2, 1, 5, 8 };
            Console.WriteLine(MaxSubsetSum(list));  //10

            list = new []  { 2, 1, 5, 8, 4 };
            Console.WriteLine(MaxSubsetSum(list));  //11

            list = new[] { -2, -3, 4, -1, -2, 1, 5, -3};
            Console.WriteLine(MaxSubsetSum(list));  //7

        }
    }
}
