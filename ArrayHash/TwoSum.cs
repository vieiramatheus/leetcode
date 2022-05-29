using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.ArrayHash
{
    public class TwoSum
    {
        /// <summary>
        /// using dictionary to map numbers to their indexes
        /// use diff beetwen target and current number to find in dictionary
        /// for with breaking loop
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] Solution1(int[] nums, int target)
        {
            int diff, index;

            var hashMap = new Dictionary<int, int>();

            for (index = 0; index < nums.Length; index++)
            {
                diff = target - nums[index];

                if (hashMap.ContainsKey(diff))
                    return new[] { hashMap[diff], index };

                if (hashMap.ContainsKey(nums[index]))
                    hashMap[nums[index]] = index;
                else
                    hashMap.Add(nums[index], index);
            }

            return new int[] { };
        }

        /// <summary>        
        /// use a dictionary to map diffs (target - num[i]) and indexes
        /// try find that diff in dictionary
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] Solution2(int[] nums, int target)
        {
            var hashMap = new Dictionary<int, int>();

            for (int index = 0; index < nums.Length; index++)
            {
                if (hashMap.ContainsKey(nums[index]))
                    return new[] { hashMap[nums[index]], index };

                hashMap.TryAdd(target - nums[index], index);
            }

            return new int[] { };
        }
    }
}
