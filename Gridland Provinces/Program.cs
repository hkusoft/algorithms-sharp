using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ServiceStack.Text;

namespace Gridland_Provinces
{
    public static class Program
    {
        static void Main(string[] args)
        {
            GridlandProvinces("a", "a");
            GridlandProvinces("dab", "abd");
            GridlandProvinces("ababa", "babab");
            GridlandProvinces("cccdd", "ccccc");
            GridlandProvinces("abbaa", "aaaaa");

            GridlandProvinces("abcdefghijkabcdefghijkabcdefghijkabcdefghijkabcd", "bcdefghijkabcdefghijkabcdefghijkabcdefghijkabcde");

        }
    
        public static string Reverse(this string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }


        public static string ShiftLeft(string s)
        {
            if (string.IsNullOrEmpty(s))
                return null;

            int n = s.Length;
            var first = s.Substring(0, 1);
            var rest = s.Substring(1);
            return rest + first;
        }

        public static string ShiftRight(string s)
        {
            if (string.IsNullOrEmpty(s))
                return null;

            int n = s.Length;
            var last = s.Substring(n-1);
            var rest = s.Substring(0, n-1);
            return last + rest;
        }

        

        /// <summary>
        /// This function gets a list of new strings by traversing the input string in a zigzag way
        /// 
        /// </summary>
        /// <param name="input"></param> Input string input
        /// Let the input string input be  "abcdef"
        /// First the string is split into two sub-arrays: "abcde" and "fghij"
        /// Then the array is arranged in two rows:
        ///     a   b   c   d   e
        ///     f   g   h   i   j
        ///The odd indexed char in the upper and lower row is then swapped:
        ///     a   g   c   i   e
        ///     f   b   h   d   j
        /// 
        /// <returns>The returned array is then:
        ///     afbgchdiej
        ///     afbgchdiej.Reverse();
        ///     fagbhcidje
        ///     fagbhcidje.Reverse();
        /// </returns>
        public static List<string> Zigzag(string input)
        {
            if (string.IsNullOrEmpty(input))
                return null;

            var output = new List<string>();
            int n = input.Length / 2;
            var A = input.Substring(0, n).ToCharArray();
            var B = input.Substring(n).Reverse().ToCharArray();

            for (int i = 1; i < n; i = i + 2)
            {
                var temp = A[i];
                A[i] = B[i];
                B[i] = temp;
            }

            int N = 2 * n;
            var str = new char [N];

            for (int i = 0; i < n; i++)
            {
                str[2 * i] = A[i];
                str[2 * i + 1] = B[i];
            }

            var s1 = new string(str);
            var s2 = SwapOddEvenChars(s1);
            output.Add(s1);
            output.Add(s2);
            output.Add(s1.Reverse());
            output.Add(s2.Reverse());
            return output;
        }

        public static string SwapOddEvenChars(string input)
        {
            if (string.IsNullOrEmpty(input))
                return null;

            var chars = input.ToCharArray();
            int N = input.Length;
            for (int i = 0; i < N; i = i + 2)
            {
                var temp = chars[i + 1];
                chars[i + 1] = input[i];
                chars[i] = temp;
            }
            return new string(chars);
        }

        
        static HashSet<string> GridlandProvinces(string a, string b)
        {
            var set = new HashSet<string>();
            var str1 = a + b.Reverse();
            ShiftAndZigzag(str1, ref set);

            // var str2 = a + b.Reverse();
            // ShiftAndZigzag(str2, ref set);

            Console.WriteLine($"GridlandProvinces for \t{a} | {b} \t-> {set.Count} combination(input)");
            set.PrintDump();
            return set;
        }

        public static void ShiftAndZigzag(string input, ref HashSet<string> hashSet)
        {
            string s1 = input;
            string s2 = input;

            hashSet.Add(input);
            for (int i = 0; i < input.Length - 1; i++)
            {
                s1 = ShiftLeft(s1);
                hashSet.Add(s1);
            }

            for (int i = 0; i < input.Length - 1; i++)
            {
                s2= ShiftRight(s2);
                hashSet.Add(s2);
            }

            var zigzag = Zigzag(input);
            for (int i = 0; i < zigzag.Count; i++)
            {
                hashSet.Add(zigzag[i]);
            }
        }
    }

}
