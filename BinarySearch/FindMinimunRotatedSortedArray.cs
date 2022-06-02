using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.BinarySearch
{
    public class FindMinimunRotatedSortedArray
    {
        /// <summary>
        /// reused the last binary monkey search in SearchRotatedSortedArray to find the pivot 
        /// once we found the pivot we just found the anwser
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int MonkeyCode(int[] nums)
        {
            int left = 0, right = nums.Length - 1, middle = nums.Length >> 1;

            //[4, 5, 6, 7, 0, 1, 2, 3]
            // l        m           r
            //middle is in the left portion
            if (nums[middle] > nums[left])
            {
                while (middle < right && nums[middle] < nums[middle + 1])
                    middle++;

                if (middle != right)
                    return nums[middle + 1];
            }
            //[5, 6, 7, 0, 1, 2, 3
            // l        m        
            //middle is in the right por
            else if (nums[middle] < nums[right])
            {
                while (middle > left && nums[middle] > nums[middle - 1])
                    middle--;

                if (middle != left)
                    return nums[middle];
            }

            return Math.Min(nums[left], nums[right]);
        }

        public static int NeetCode(int[] nums)
        {
            int res = nums[0], l = 0, r = nums.Length - 1, m;
            while (l <= r)
            {
                if (nums[l] < nums[r])
                {
                    res = Math.Min(res, nums[l]);
                    break;
                }
                m = (l + r) >> 1;
                res = Math.Min(res, nums[m]);
                if (nums[m] >= nums[l])
                    l = m + 1;
                else
                    r = m - 1;
            }

            return res;
        }
    }
}
