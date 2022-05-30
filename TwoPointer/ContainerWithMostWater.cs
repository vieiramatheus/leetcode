using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.TwoPointer
{
    /// <summary>
    /// You are given an integer array height of length n. There are n vertical lines drawn such that the two endpoints of the ith line are (i, 0) and (i, height[i]).
    /// Find two lines that together with the x-axis form a container, such that the container contains the most water.
    /// Return the maximum amount of water a container can store.
    /// Notice that you may not slant the container
    /// 
    /// Example 1:
    /// Input: height = [1,8,6,2,5,4,8,3,7]
    /// Output: 49
    /// Explanation: The above vertical lines are represented by array 
    /// [1,8,6,2,5,4,8,3,7]. In this case: (8 in the position 2) and (7 in the position 9)
    /// will form a retangle of 7 * 7 = 49 -> the first 7 is the lower height
    /// the second 7 is the positions (pos:9 minus pos:7)
    /// that is a retangle of 7x7 which is equal 49
    /// </summary>
    public class ContainerWithMostWater
    {
        /// <summary>
        /// This is a two pointer solution
        /// Since we have to find the most extremes combination
        /// We increase our chance to find better triangle in the extremes
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public static int MaxArea(int[] height)
        {
            int left = 0, right = height.Length - 1, res = 0;
            while (left < right)
            {
                res = Math.Max((right - left) * Math.Min(height[left], height[right]), res);

                if (height[left] > height[right])
                    right--;
                else
                    left++;                
            }

            return res;
        }
    }
}
