namespace Algoritmos
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = ArrayHash.ArrayProductExceptSelf.PrefixSuffixSolution(new int[] { 1, 2, 3, 4});

            foreach (var item in result)
            {
                System.Console.WriteLine(item);
            }
        }
    }
}