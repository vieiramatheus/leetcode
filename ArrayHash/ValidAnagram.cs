using System.Collections.Generic;

namespace Algoritmos.ArrayHash
{
    /// <summary>
    /// Given two strings s and t, return true if t is an anagram of s, and false otherwise.
    /// An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, 
    /// typically using all the original letters exactly once.
    /// </summary>
    public class ValidAnagram
    {
        /// <summary>
        /// dictionary solution, with FOREACH, breaking looping
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool Solution1(string s, string t)
        {
            var hashTable = new Dictionary<char, uint>();
            foreach (char letra in s)
            {
                if (hashTable.ContainsKey(letra))
                    hashTable[letra]++;
                else
                    hashTable.Add(letra, 1);

                hashTable.TryAdd(letra, 1);
            }

            foreach (char letra in t)
            {
                if (!hashTable.ContainsKey(letra))
                    return false;

                hashTable[letra]--;
                if (hashTable[letra] == 0)
                    hashTable.Remove(letra);
            }

            return hashTable.Count == 0;
        }

        /// <summary>
        /// dictionary solution, with FOR, breaking looping
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool Solution2(string s, string t)
        {
            int index;
            var hashTable = new Dictionary<char, uint>();
            for (index = 0; index < s.Length; index++)
            {
                if (hashTable.ContainsKey(s[index]))
                    hashTable[s[index]]++;
                else
                    hashTable.Add(s[index], 1);
            }

            for (index = 0; index < t.Length; index++)
            {
                if (!hashTable.ContainsKey(t[index]))
                    return false;

                hashTable[t[index]]--;
                if (hashTable[t[index]] == 0)
                    hashTable.Remove(t[index]);
            }

            return hashTable.Count == 0;
        }
    }
}
