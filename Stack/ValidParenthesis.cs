using System;
using System.Collections.Generic;

namespace Algoritmos.Stack
{
    /// <summary>
    /// 
    /// Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
    /// 
    /// An input string is valid if:
    /// 1. Open brackets must be closed by the same type of brackets.
    /// 2. Open brackets must be closed in the correct order.
    /// 
    /// Example 1:
    /// Input: s = "()"
    /// Output: true
    /// 
    /// Example 2:
    /// Input: s = "()[]{}"
    /// Output: true
    /// 
    /// Example 3:
    /// Input: s = "(]"
    /// Output: false
    /// </summary>
    public class ValidParenthesis
    {
        public static bool NeetCodeSolution(string s)
        {
            var closenings = new Dictionary<char, char>() { { ')', '(' }, { ']', '[' }, { '}', '{' } };
            var stack = new Stack<char>();

            int index = 0;
            while (index < s.Length)
            {
                char character = s[index];
                if (closenings.TryGetValue(character, out char closening))
                {
                    if (stack.Count > 0 && stack.Peek() == closening)
                        stack.Pop();
                    else
                        return false;
                }
                else if (character == '(' || character == '{' || character == '[')
                {
                    stack.Push(character);
                }
                else return false;

                index++;
            }

            return stack.Count == 0;
        }

        /// <summary>
        /// this is top 1 fast solution accordinly to leetcode
        /// stacking ifs is faster than mapping them into a dictionary?
        /// wonder if using a array with an absurd size instead of hashset will be faster
        /// wonder why the author bothers using hashmap in the first if
        /// and in the second not
        /// 
        /// Wonder if the leetcode metrics are reliable...
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool LeetCodeTop1FastSolution(string s)
        {
            Stack<char> stack = new Stack<char>();

            HashSet<char> open = new HashSet<char> { '(', '[', '{' };

            char cand;
            foreach (char c in s)
            {
                if (open.Contains(c))
                {
                    stack.Push(c);
                }

                else
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }

                    cand = stack.Pop();

                    if (cand == '[' && c != ']')
                    {
                        return false;
                    }

                    else if (cand == '(' && c != ')')
                    {
                        return false;
                    }

                    else if (cand == '{' && c != '}')
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }

        /// <summary>
        /// substitution of hashset<t> for array
        /// do not get the top 1 rank for some reason
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool AttemptOfFasterSolution(string s)
        {
            var stack = new Stack<char>();
            var open = new int[126];
            open['('] = ')';
            open['{'] = '}';
            open['['] = ']';

            char pop;
            foreach (char c in s)
            {
                if (open[c] == 0)
                {
                    if (!stack.TryPop(out pop))
                        return false;                    

                    if (c != open[pop])
                        return false;
                }
                else
                {
                    stack.Push(c);
                }
            }

            return stack.Count == 0;
        }
    }
}
