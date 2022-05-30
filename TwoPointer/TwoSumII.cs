using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.TwoPointer
{
    /// <summary>
    /// Given a 1-indexed array of integers numbers that is already sorted in non-decreasing order, 
    /// find two numbers such that they add up to a specific target number. 
    /// Let these two numbers be numbers[index1] and numbers[index2] where 1 <= index1 < index2 <= numbers.length.
    /// Return the indices of the two numbers, index1 and index2, added by one as an integer array[index1, index2] of length 2.
    /// The tests are generated such that there is exactly one solution.You may not use the same element twice.
    /// Your solution must use only constant extra space.
    /// </summary>
    public class TwoSumII
    {
        /// <summary>
        /// NeetCode TwoPointer solution, 
        /// basicaly you iterate in two side direction converging to center 
        /// trying to find the two sum point
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSum(int[] numbers, int target)
        {
            int l = 0, r = numbers.Length - 1, x;
            while (l < r)
            {
                x = numbers[l] + numbers[r];
                if (x == target)
                    return new int[] { l + 1, r + 1 };
                if (x > target)
                    r--;
                else
                    l++;
            }

            return new int[] { };
        }
    }
}
