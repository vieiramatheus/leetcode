using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.ArrayHash
{
    /// <summary>
    /// Given an integer array nums and an integer k, return the k most frequent elements. You may return the answer in any order.
    /// Example:
    /// Input: nums = [1,1,1,2,1,1,1,2,3], k = 2
    /// Output: [1,2]
    /// </summary>
    public class TopKFrequentElements
    {
        /// <summary>
        /// coisa de maluco
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int[] Solution1(int[] nums, int k)
        {
            var counter = new List<int>[nums.Length];

            var map = new Dictionary<int, int>();

            for (int index = 0; index < nums.Length; index++)
            {
                if (!map.TryAdd(nums[index], 1))
                    map[nums[index]]++;

                counter[index] = new List<int>();
            }

            foreach (var item in map)
                counter[item.Value - 1].Add(item.Key);

            var result = new List<int>();
            for (int index = counter.Length - 1; index >= 0; index--)
            {
                foreach (var item in counter[index])
                {
                    result.Add(item);
                    if (result.Count == k)
                        return result.ToArray();
                }
            }

            return new int[] { };
        }

        /// <summary>
        /// coisa de maluco 2
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int[] Solution2(int[] nums, int k)
        {
            var map = new Dictionary<int, int>();

            for (int index = 0; index < nums.Length; index++)
            {
                if (!map.TryAdd(nums[index], 1))
                    map[nums[index]]++;
            }

            return map.OrderByDescending(x => x.Value).Select(x => x.Key).Take(k).ToArray();
        }
    }
}
