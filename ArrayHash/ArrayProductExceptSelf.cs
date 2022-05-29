using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.ArrayHash
{
    /// <summary>
    /// Given an integer array nums, return an array answer such that answer[i] is equal to the product of all the elements of nums except nums[i].
    /// The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.
    /// You must write an algorithm that runs in O(n) time and without using the division operation.
    /// </summary>
    public class ArrayProductExceptSelf
    {
        /// <summary>
        /// Here we will be doing 3 arrays, 
        /// one for prefixes multiplications
        /// one for postfixes multiplications
        /// one for solution
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int[] PrefixSuffixSolution(int[] nums)
        {
            var prefixes = new int[nums.Length];
            var prefix = 1;
            prefixes[0] = 1;
            for (int index = 1; index < nums.Length; index++)
            {
                prefixes[index] = nums[index-1] * prefix;
                prefix = prefixes[index];
            }

            var sufixes = new int[nums.Length];
            var sufix = 1;
            sufixes[nums.Length - 1] = 1;
            for (int index = nums.Length-2; index >= 0; index--)
            {
                sufixes[index] = nums[index+1] * sufix;
                sufix = sufixes[index];
            }

            var solution = new int[nums.Length];
            for (int index = 0; index < nums.Length; index++)
            {
                solution[index] = prefixes[index] * sufixes[index];
            }

            return solution;
        }

        /// <summary>
        /// this solution here is basicaly the same PREFIX SUFIX solution
        /// but, we will use only one array, because prefix and sufix computing can be merged into one
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int[] LessMemorySolution(int[] nums)
        {
            var solution = new int[nums.Length];
            var prefix = 1;
            solution[0] = 1;
            for (int index = 0; index < nums.Length - 1; index++)
            {
                solution[index + 1] = prefix * nums[index];
                prefix = solution[index + 1];
            }

            int postfix = 1;
            for (int index = nums.Length - 1; index >= 0; index--)
            {
                solution[index] = solution[index] * postfix;
                postfix = nums[index] * postfix;
            }

            return solution;
        }
    }
}
