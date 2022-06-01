using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.SlidingWindow
{
    /// <summary>
    /// Given two strings s and t of lengths m and n respectively, return the minimum window substring of s such that every character in t (including duplicates) is included in the window. 
    /// If there is no such substring, return the empty string "".
    /// The testcases will be generated such that the answer is unique.
    /// A substring is a contiguous sequence of characters within the string.
    /// 
    /// Example 1:
    /// Input: s = "ADOBECODEBANC", t = "ABC"
    /// Output: "BANC"
    /// Explanation: The minimum window substring "BANC" includes 'A', 'B', and 'C' from string t.
    /// 
    /// </summary>
    public class MinimunWindowSubstring
    {
        public static string BruteForce(string s, string t)
        {
            var tMap = new Dictionary<char, int>();
            foreach (char c in t)
                if (tMap.ContainsKey(c))
                    tMap[c]++;
                else
                    tMap.Add(c, 1);

            var sMap = new Dictionary<char, int>();
            int r = 0, l = 0, minWindow = s.Length, minL = 0, minR = 0;
            while (r < s.Length)
            {
                if (sMap.ContainsKey(s[r]))
                    sMap[s[r]]++;
                else
                    sMap.Add(s[r], 1);

                var match = true;
                foreach (var tItem in tMap)
                {
                    if (!sMap.ContainsKey(tItem.Key) || tItem.Value > sMap[tItem.Key])
                    {
                        match = false;
                        break;
                    }
                }

                if (match)
                {
                    int newWindow = r - l + 1;
                    if (newWindow <= minWindow)
                    {
                        minWindow = newWindow;
                        minL = l;
                        minR = r + 1;
                    }

                    sMap[s[l]]--;
                    l++;

                    sMap[s[r]]--;
                    r--;
                }

                r++;
            }

            return minR == minL && minL == 0 ? "" : s.Substring(minL, minWindow);
        }
    }
}
