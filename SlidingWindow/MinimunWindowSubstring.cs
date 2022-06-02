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
        /// <summary>
        /// This is a Brute Force solution
        /// This creates a Dictionary tMap for t string, mapping all chars
        /// necessary with his respective quantities
        /// 
        /// Since in slidind window solution we have 'r' and 'l' pointers, 
        /// this algorithm will create and update
        /// an Dictionary sMap for every character beetween these two points
        /// then check if sMap meet the requirements described in tMap
        /// 
        /// If yes then we have a valid window, then tries to shrink this window
        /// by increasing 'l' pointer untill sMap is not valid anymore
        /// 
        /// Every time a smaller window is found, then update the respectives variables
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string BruteForce(string s, string t)
        {
            var tMap = new Dictionary<char, int>();
            foreach (char c in t)
            {
                tMap.TryGetValue(c, out var n);
                tMap[c] = n + 1;
            }

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

        /// <summary>
        /// The neetcode solution basically consists in two dictionaries haveMap and needMap
        /// But it store only the necessary chars, and ignore the ones that is not in 't' string
        /// 
        /// It's a sliding window solution, with slightly diffs
        /// 
        /// Instead of scan for the two dictionaries checking if they are matching, 
        /// He utilizes flags:
        /// Flag 'have' represent the total characters in substring['l':'r']
        /// Flag 'need' represent the total characters in 't'
        /// 
        /// While 'have' equals 'need' them we still have a valid window: 
        ///     Check if is a smaller window, then
        ///     Try to shrink this window increasing 'l' pointer
        ///     And only decrease 'have' flag if: 
        ///         - The character removed belongs to needMap 
        ///         - After removal the quantity is less than the needMap require
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string NeetCode(string s, string t)
        {
            var needMap = new Dictionary<char, int>();
            var haveMap = new Dictionary<char, int>();

            //create needMap by scanning 't' string
            foreach (var c in t)
            {
                needMap.TryGetValue(c, out int currentValue);
                needMap[c] = currentValue + 1;
            }

            int l = 0, r = 0, have = 0, need = t.Length, res = int.MaxValue, resLen = int.MaxValue;

            while (r < s.Length)
            {
                char c = s[r];
                if (needMap.ContainsKey(c))
                {
                    haveMap.TryGetValue(c, out int currentValue);
                    haveMap[c] = currentValue + 1;
                    if (haveMap[c] <= needMap[c])
                        have++;
                }

                //if meet the requirements have == need,
                while (have == need)
                {
                    
                    int size = (r - l + 1);
                    //try to find a smaller window
                    if (size < resLen)
                    {
                        res = l;
                        resLen = size;
                    }

                    //try to shrink the window
                    //and update the havemap, and have flag if necessary
                    char lc = s[l];
                    if (needMap.ContainsKey(lc))
                    {
                        haveMap[lc]--;
                        if (haveMap[lc] < needMap[lc])
                            have--;
                    }

                    l++;
                }

                r++;
            }

            return resLen != int.MaxValue ? s.Substring(res - 1, resLen) : "";
        }
    }
}
