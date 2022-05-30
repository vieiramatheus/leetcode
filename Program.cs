using System;

namespace Algoritmos
{
    class Program
    {
        static void Main(string[] args)
        {
            /// -> Length of the longest consecutive elements sequence.
            var result = ArrayHash.LongestConsecutiveSequence.Solution1(new int[] { 9, 1, 4, 7, 3, -1, 0, 5, 8, -1, 6 });
            Console.WriteLine(result);

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