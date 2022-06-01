using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.SlidingWindow
{
    /// <summary>
    /// Given a string s, find the length of the longest substring without repeating characters.
    /// Example 1:
    /// Input: s = "abcabcbb"
    /// Output: 3
    /// Explanation: The answer is "abc", with the length of 3.
    /// </summary>
    public class LongestSubstring
    {
        /// <summary>
        /// Sliding window solution: two pointer solution but left and right begins in the same point
        /// and they will adjust the distance between each other based on some condition
        /// the condition here is if exists in hashset, so duplicated char
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int LengthOfLongestSubstring(string s)
        {
            var bucket = new HashSet<char>();
            int l = 0, r = 0, res = 0;
            while (r < s.Length)
            {
                if (bucket.Add(s[r]))
                {
                    r++;
                    res = Math.Max(bucket.Count, res);
                }
                else
                {
                    bucket.Remove(s[l]);
                    l++;
                    //if (l == r)
                    //    r++;
                }
            }

            return res;
        }

        /// <summary>
        /// Sliding window solution: two pointer solution but left and right begins in the same point
        /// and they will adjust the distance between each other based on some condition
        /// here the hashset is substituted for an array size 256
        /// because is lighter and faster than hashset c# implementation
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int LengthOfLongestSubstringWithoutHashSet(string s)
        {
            var bucket = new int[256];
            int l = 0, r = 0, res = 0;
            while (r < s.Length)
            {
                if (bucket[s[r]] == 0)
                {
                    bucket[s[r]] = 1;
                    r++;
                    res = Math.Max(r - l, res);
                }
                else
                {
                    bucket[s[l]] = 0;
                    l++;
                }
            }

            return res;
        }
    }
}
