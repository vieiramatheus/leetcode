using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.ArrayHash
{
    /// <summary>
    /// Given an integer array nums, return true if any value appears at 
    /// least twice in the array, and return false if every element is distinct.
    /// </summary>
    public class ContainsDuplicate
    {
        /// <summary>
        /// use hashset, with while, not breaking looping
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static bool Solution1(int[] nums)
        {
            uint index = 0;

            HashSet<int> visited = new HashSet<int>();

            bool unvisited = true;

            while (index < nums.Length && unvisited)
            {
                unvisited = visited.Add(nums[index]);
                index++;
            };

            return !unvisited;
        }


        /// <summary>
        /// use hashset, with for, breaking looping
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static bool Solution2(int[] nums)
        {
            HashSet<int> visited = new HashSet<int>();

            for (uint index = 0; index < nums.Length; index++)
            {
                if (!visited.Add(nums[index]))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// use simple sorting, breaking loop
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static bool Solution3(int[] nums)
        {
            Array.Sort(nums);

            for (int index = 0; index < nums.Length - 1; index++)
            {
                if (nums[index] == nums[index + 1]) return true;
            }

            return false;
        }
    }
}
