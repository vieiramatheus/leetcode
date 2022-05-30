using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.TwoPointer
{
    /// <summary>
    /// Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.
    /// Notice that the solution set must not contain duplicate triplets.
    /// Example 1:
    /// Input: nums = [-1, 0, 1, 2, -1, -4]
    /// Output: [[-1,-1,2], [-1,0,1]]
    /// </summary>
    public class _3SumTriplets
    {
        /// <summary>
        /// this solution is a recombination of 2sum double pointer solution
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);

            var result = new List<IList<int>>();

            for (int index = 0; index < nums.Length; index++)
            {
                //since the nums[] already sorted
                //this is to avoid using the same number twice
                //so this will ignore the iteration by advancing to the next number
                //until find a new number
                if (index > 0 && nums[index] == nums[index - 1])
                    continue;


                //once found first new ocurrence
                //we use double pointer technique to find
                //the next two matches
                //basicaly this will work because the nums[] is already sorted
                //left pointer will be our current index location +1
                //right pointer will be the end of the nums[]
                int left = index + 1, right = nums.Length - 1;

                //once we meet in the middle, the loop will be completed
                while (left < right)
                {
                    int sum = nums[index] + nums[left] + nums[right];
                    if (sum == 0)//if we find our match, lets add to the list of list
                    {
                        result.Add(new List<int> { nums[index], nums[left], nums[right] });
                        left++;// update left pointer

                        //THIS DEMANDS A BETTER EXPLANATION: too mistical
                        //here we check if next left pointer iteration will not hit a equal value already used
                        while (nums[left] == nums[left - 1] && left < right)
                            left++;// update left pointer again, so we garantee (again since nums[] is sorted) that we are ignoring same numbers
                    }
                    else if (sum > 0)
                        right--;//because we hit higher, we have to lower our sum
                    else
                        left++; //because we hit lower, we have to raise ou sum
                }
            }

            return result;
        }
    }
}
