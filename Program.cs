using System;

namespace Algoritmos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write encoding stuff:");
            var result1 = ArrayHash.EncodeDecodeStrings.Encode(new string[] { "lint", "code", "love", "you" });
            Console.WriteLine(result1);

            Console.WriteLine("Write decoding stuff:");
            var result2 = ArrayHash.EncodeDecodeStrings.Decode(result1);
            foreach (var item in result2)
            {
                Console.WriteLine("{0}, ", item);
            }
        }
    }
}