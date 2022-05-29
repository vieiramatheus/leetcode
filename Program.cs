namespace Algoritmos
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = ArrayHash.TopKFrequentElements.Solution1(new int[] { 1, 1, 1, 2, 2, 3 }, 2);
            foreach (var item in result)
            {
                System.Console.WriteLine(item);
            }            
        }
    }
}