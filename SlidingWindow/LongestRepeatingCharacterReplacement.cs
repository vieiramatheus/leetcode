using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.SlidingWindow
{

    /// <summary>    
    /// You are given a string s and an integer k.You can choose any character of the string and change it to any other uppercase English character. You can perform this operation at most k times.
    /// Return the length of the longest substring containing the same letter you can get after performing the above operations.
    /// 
    /// Example 1:
    /// Input: s = "ABAB", k = 2
    /// Output: 4
    /// Explanation: Replace the two 'A's with two 'B's or vice versa.
    /// 
    /// Example 2:
    /// Input: s = "AABABBA", k = 1
    /// Output: 4
    /// Explanation: Replace the one 'A' in the middle with 'B' and form "AABBBBA".
    /// The substring "BBBB" has the longest repeating letters, which is 4.
    /// 
    /// s consists of only uppercase English letters.
    /// </summary>
    public class LongestRepeatingCharacterReplacement
    {

        /// <summary>
        /// Sliding window solution with O(26n) solution
        /// basically this is a solution like two pointer solution
        /// but, the two pointer starts on the same location
        /// and they will apart from each other by some condition
        /// in this case the condition is: the substring is valid?
        /// that is described by the equation: (right - left +1) - maxF
        /// wich: right is the most right point on the substring
        /// left is the most left point on the substring
        /// maxF is the most frequent character in that substring
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int SlidingWindowBigOOfTwentySixNSolution(string s, int k)
        {
            //the maxwindow = (k + length of the substring with the most frequencies)

            int[] frequencies = new int[26];
            int maxWindow = 0, left = 0, right = 0, maxF = 1, windowLen = 1;

            while (right < s.Length)
            {
                if (windowLen - maxF <= k)
                    frequencies[s[right] - 'A']++;

                maxF = 0;
                for (int fi = 0; fi < frequencies.Length; fi++)
                    maxF = Math.Max(maxF, frequencies[fi]);

                windowLen = right - left + 1;

                if (windowLen - maxF <= k)
                {
                    right++;
                    maxWindow = Math.Max(maxWindow, windowLen);
                }
                else
                {
                    frequencies[s[left] - 'A']--;
                    left++;
                }
            }

            return maxWindow;
        }
    }
}
