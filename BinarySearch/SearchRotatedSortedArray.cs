using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.BinarySearch
{
    /// <summary>
    /// There is an integer array nums sorted in ascending order (with distinct values).
    /// Prior to being passed to your function, nums is possibly rotated at an unknown 
    /// pivot index k(1 <= k<nums.length) such that the resulting array is 
    /// [nums[k], nums[k + 1], ..., nums[n - 1], nums[0], nums[1], ..., nums[k - 1]] (0-indexed). 
    /// 
    /// For example, [0, 1, 2, 4, 5, 6, 7] might be rotated at pivot index 3 and become[4, 5, 6, 7, 0, 1, 2].
    /// Given the array nums after the possible rotation and an integer target, return the index of target if it is in nums, or -1 if it is not in nums.
    /// You must write an algorithm with O(log n) runtime complexity.
    /// </summary>
    public class SearchRotatedSortedArray
    {
        /// <summary>
        /// This is a completely brainless solution
        /// Just throwing code in the IDE, testing and failing 
        /// Until a got a solution that can be called binary search
        /// But I do not sure what it is at this point 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int MonkeyCode(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1, middle = nums.Length >> 1;
            //[4, 5, 6, 7, 0, 1, 2, 3]
            // l        m           r
            //
            // m > l -> middle is in left part portion
            // m < r -> middle is in right part portion

            //middle is in the left portion
            if (nums[middle] > nums[left])
            {
                //moving middle to the most greater position in the left
                while (middle < right && nums[middle] < nums[middle + 1])
                    middle++;

                if (target >= nums[left] && target <= nums[middle])
                    right = middle;
                else if (target <= nums[right] && target < nums[middle])
                    left = middle + 1;
                else
                    return -1;
            }

            //middle is in right portion
            else if (nums[middle] < nums[right])
            {
                //[6, 7, 0, 1, 2, 3, 4, 5]
                // l        m           r

                //moving middle to the most lesser position in the right
                while (middle > left && nums[middle] > nums[middle - 1])
                    middle--;

                if (target >= nums[middle] && target <= nums[right])
                    left = middle;
                else if (target >= nums[left] && target > nums[middle])
                    right = middle - 1;
                else
                    return -1;
            }

            if (left > right)
                return -1;

            middle = left + ((right - left) >> 1);

            if (target == nums[left])
                return left;
            if (target == nums[right])
                return right;
            if (target == nums[middle])
                return middle;

            while (target != nums[middle])
            {
                if (middle == left && middle == right)
                    return -1;
                else if (middle == left)
                    return -1;
                else if (middle == right)
                    return -1;

                if (target > nums[middle])
                    left = middle;
                else if (target < nums[middle])
                    right = middle;

                middle = left + ((right - left) >> 1);
            }

            return middle;
        }

        /// <summary>
        /// Neet Code binary search solution
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int NeetCode(int[] nums, int target)
        {
            int l = 0, r = nums.Length, m;

            while (l <= r)
            {
                m = (l + r) >> 1;
                if (target == nums[m])
                    return m;

                if (nums[l] <= nums[m])
                {
                    if (target > nums[m] || target < nums[l])
                        l = m + 1;
                    else
                        r = m - 1;
                }
                else
                {
                    if (target < nums[m] || target > nums[r])
                        r = m - 1;
                    else
                        l = m + 1;
                }
            }
            return -1;
        }
    }
}
