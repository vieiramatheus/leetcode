using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.ArrayHash
{
    /// <summary>
    /// Given an unsorted array of integers nums, return the length of the longest consecutive elements sequence.
    /// You must write an algorithm that runs in O(n) time.
    /// </summary>
    public class LongestConsecutiveSequence
    {
        /// <summary>
        /// This is a solution that I invented, basically you store every number into a dictionary (hashmap)
        /// Then you track sequences by doing a iteration that goes min -> max number
        /// It works, but it is too slow
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int Solution1(int[] nums)
        {
            var bucket = new Dictionary<int, int>();

            int max = 0;
            int min = int.MaxValue;
            for (int index = 0; index < nums.Length; index++)
            {
                bucket.TryAdd(nums[index], nums[index]);
                if (max < nums[index])
                    max = nums[index];
                if (min > nums[index])
                    min = nums[index];
            }

            var sequence = 0;
            var maxSequence = 0;
            for (int index = min; index <= max; index++)
            {
                if (bucket.ContainsKey(index))
                    sequence++;

                else if (sequence > (nums.Length / 2))
                    index = max;
                else
                    sequence = 0;

                if (maxSequence < sequence)
                    maxSequence = sequence;


            }

            return maxSequence;
        }

        /// <summary>
        /// This solution uses a HashSet to bucket values
        /// But it has a better way to find sequences;
        /// You pass through array and try to find in bucket a left neighboor
        /// If you dont, this is the first element of the sequence
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int Solution2(int[] nums)
        {
            var bucket = new HashSet<int>();
            for (int index = 0; index < nums.Length; index++)
                bucket.Add(nums[index]);

            int maxSequence = 0;

            for (int index = 0; index < nums.Length; index++)
            {
                int num = nums[index];
                if (!bucket.Contains(num - 1))
                {
                    int length = 0;
                    while (bucket.Contains(num + length))
                        length++;

                    maxSequence = Math.Max(length, maxSequence);
                }
            }

            return maxSequence;
        }
    }
}
