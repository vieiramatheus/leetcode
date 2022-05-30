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
        /// regex solution
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool Solution1(string s)
        {
            s = s.ToLower();

            var palindrome = Regex.Replace(s, @"\s*\W*_*", "");

            int half = palindrome.Length >> 1;
            for (int index = 0; index < half; index++)
            {
                int nindex = palindrome.Length - 1 - index;
                if (palindrome[index] != palindrome[nindex])
                    return false;
            }

            return true;
        }


    }
}
