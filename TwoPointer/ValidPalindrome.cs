using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Algoritmos.TwoPointer
{
    public class ValidPalindrome
    {
        /// <summary>
        /// solution using regex + 
        /// double half sided scan converging in center
        /// for some reason regex is fast in leet code
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool Solution1(string s)
        {
            s = s.ToLower();

            var palindrome = Regex.Replace(s, @"\s*\W*_*", "");

            int l = 0, r = palindrome.Length - 1;
            while (l < r)
            {
                if (palindrome[l] != palindrome[r])
                    return false;
                l++;
                r--;
            }

            return true;
        }

        /// <summary>
        /// this solution does not use regexp to create palindrome,
        /// uses two arrays builds one string and on in reverse
        /// use c# == operation to compare strings
        /// it works but exceed time limit in extreme cases
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool Solution2(string s)
        {
            char[] newStr = new char[] { };
            char[] reverseStr = new char[] { };
            foreach (var letter in s)
            {
                if (char.IsLetterOrDigit(letter))
                {
                    Array.Resize(ref newStr, newStr.Length + 1);
                    Array.Resize(ref reverseStr, reverseStr.Length + 1);
                    newStr[newStr.Length - 1] = char.ToLower(letter);
                    reverseStr[reverseStr.Length - 1] = char.ToLower(letter);
                }
            }

            Array.Reverse(reverseStr);


            return new string(newStr) == new string(reverseStr);
        }

        /// <summary>
        /// this solution does not use regexp ,
        /// to create palindrome uses one array only, its O(n) memory
        /// makes left and right comparison
        /// double side scan converging center direction 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool Solution3(string s)
        {
            char[] newStr = new char[] { };
            for (int index = 0; index < s.Length; index++)
            {
                if (char.IsLetterOrDigit(s[index]))
                {
                    Array.Resize(ref newStr, newStr.Length + 1);
                    newStr[newStr.Length - 1] = char.ToLower(s[index]);
                }
            }

            int l = 0, r = newStr.Length - 1;
            while (l < r)
            {
                if (newStr[l] != newStr[r])
                    return false;
                l++;
                r--;
            }

            return true;
        }

        /// <summary>
        /// this solution does not use regexp,
        /// uses a custom function to find alfa numeric
        /// to create palindrome uses one array only, its 2O(n) memory
        /// makes left and right comparison
        /// double side scan converging center direction 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool Solution4(string s)
        {
            string newStr = "";
            for (int index = 0; index < s.Length; index++)
            {
                if (('A' <= s[index] && s[index] <= 'Z'))
                {
                    newStr += char.ToLower(s[index]);

                }
                else if (('a' <= s[index] && s[index] <= 'z') || ('0' <= s[index] && s[index] <= '9'))
                {
                    newStr += s[index];
                }
            }

            int l = 0, r = newStr.Length - 1;
            while (l < r)
            {
                if (newStr[l] != newStr[r])
                    return false;
                l++;
                r--;
            }

            return true;
        }

        /// <summary>
        /// faster solution, use less memory as well
        /// for some reason builtin method functions works well in leetcode
        /// so the custom alfanumeric solution worked well
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool NeetCodeSolution(string s)
        {
            int l = 0, r = s.Length - 1;
            while (l < r)
            {
                while (l < r && !alfaNumeric(s[l]))
                    l++;
                while (l < r && !alfaNumeric(s[r]))
                    r--;
                if (char.ToLower(s[l]) != char.ToLower(s[r]))
                    return false;
                l++;
                r--;
            }

            bool alfaNumeric(char c)
            {
                return ('A' <= c && c <= 'Z') ||
                    ('a' <= c && c <= 'z') ||
                    ('0' <= c && c <= '9');
            }

            return true;
        }
    }
}
