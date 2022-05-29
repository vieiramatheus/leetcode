using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos
{
    public class CustomCodingQuestion
    {
        //  Given a positive integer n, you can apply one of the following operations:
        //  If n is even, replace n with n / 2.
        //  If n is odd, replace n with either n + 1 or n - 1.
        //  Return the minimum number of operations needed for n to become 1.

        // IntegerReplacement está listado como médio
        public static uint IntegerReplacement(int n)
        {
            return IntegerReplacementBitAnalysis((uint)n);
            //return IntegerReplacementRecursive(n, 0);
        }

        public static uint IntegerReplacementBitAnalysis(uint n)
        {


            uint index = 0;
            while (n != 1)
            {
                if (n == 3)
                {
                    index += 2;
                    n = 1;
                }
                //isso é um jeito de verificar se o numero é impar através de operação binária,
                //se o digito menos significante for 1 então é impar
                else if ((n & 1) == 1)
                {
                    //e aqui vem um mistério intrigante:
                    //por algum motivo, se os dois ultimos digitos menos significantes ambos forem 1
                    //vc reduz o numero de operações ao incrementar 1
                    //POR QUE?
                    if (((n >> 1) & 1) == 1)
                        n++;
                    else
                        n--;
                }
                else
                    n = n >> 1; //shift right 1, tbm conhecido como divisão por dois

                //incrementa o contador
                index++;
            }
            return index;
        }

        public static void TestingBitWiseOperations()
        {
            uint numeropar = 324;
            uint numeroimpar = 3;

            Console.Write("Numero par em decimal: ");
            Console.WriteLine(numeropar);
            Console.Write("Numero par em binario: ");
            Console.WriteLine(Convert.ToString(numeropar, toBase: 2));
            Console.Write("Numero par & 1: ");
            Console.WriteLine(Convert.ToString((uint)(numeropar & 1), toBase: 2));
            Console.Write("Numero par >> 1: ");
            Console.WriteLine(Convert.ToString((uint)(numeropar >> 1), toBase: 2));
            Console.Write("Numero par >> 1 em decimal: ");
            Console.WriteLine(numeropar >> 1);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            //Console.WriteLine(numeropar >> 1);

            Console.Write("Numero impar em decimal: ");
            Console.WriteLine(numeroimpar);
            Console.Write("Numero impar em binario: ");
            Console.WriteLine(Convert.ToString(numeroimpar, toBase: 2));
            Console.Write("Numero impar & 1: ");
            Console.WriteLine(numeroimpar & 1);
            Console.Write("Numero impar >> 1: ");
            Console.WriteLine(Convert.ToString((numeroimpar >> 1), toBase: 2));
            Console.Write("Numero impar >> 1 em decimal: ");
            Console.WriteLine(numeroimpar >> 1);
        }

        /// <summary>
        /// Essa solução desencadeia um problema de StackOverflow para numeros muito altos
        /// </summary>
        /// <param name="n"></param>
        /// <param name="counter"></param>
        /// <returns></returns>
        public static int IntegerReplacementRecursive(int n, int counter)
        {
            if (n == 1)
                return counter;

            counter++;
            if (n % 2 == 0)
            {
                return IntegerReplacementRecursive(n / 2, counter);
            }
            else
                return Math.Min(IntegerReplacementRecursive(n - 1, counter), IntegerReplacementRecursive(n + 1, counter));
        }


        //por algum motivo esse nao foi o algoritmo mais rapido da plataforma

        //TwoSum esta listado como fácil
        public static int[] TwoSum(int[] nums, int target)
        {
            int diff = 0;
            int index = -1;

            var hashMap = new Dictionary<int, int>();

            for (index = 0; index < nums.Length; index++)
            {
                diff = target - nums[index];

                if (hashMap.ContainsKey(diff))
                    return new[] { hashMap[diff], nums[index] };

                if (hashMap.ContainsKey(nums[index]))
                    hashMap[nums[index]] = index;
                else
                    hashMap.Add(nums[index], index);
            }

            do
            {
                index++;
                diff = target - nums[index];
                hashMap.Add(nums[index], index);
            } while (!hashMap.ContainsKey(diff) && index < nums.Length);

            return new[] { hashMap[diff], index };
        }
    }
}
