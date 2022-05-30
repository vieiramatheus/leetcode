﻿using System;

namespace Algoritmos
{
    class Program
    {
        static void Main(string[] args)
        {

            var result = TwoPointer.TwoSumII.TwoSum(new int[] { 1, 3, 4, 5 }, 9);

            foreach (var item in result)
            {
                Console.WriteLine("{0}, ", item);
            }

            ///ValidPalindrome
            //var result = TwoPointer.ValidPalindrome.Solution2("A man, a plan, a canal: Panama");
            //var result = TwoPointer.ValidPalindrome.Solution2("race a car");

            //Console.WriteLine(result);

            /// -> Length of the longest consecutive elements sequence.
            //var result = ArrayHash.LongestConsecutiveSequence.Solution1(new int[] { 0, 1, 2, 4, 8, 5, 6, 7, 9, 3, 55, 88, 77, 99, 999999999 });
            //Console.WriteLine(result);

            /// -> EncodeDecodeStrings
            //Console.WriteLine("Write encoding stuff:");
            //var result1 = ArrayHash.EncodeDecodeStrings.Encode(new string[] { "lint", "code", "love", "you" });
            //Console.WriteLine(result1);

            //Console.WriteLine("Write decoding stuff:");
            //var result2 = ArrayHash.EncodeDecodeStrings.Decode(result1);
            //foreach (var item in result2)
            //{
            //    Console.WriteLine("{0}, ", item);
            //}
        }
    }
}