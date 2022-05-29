using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.ArrayHash
{
    /// <summary>
    /// Given an array of strings strs, group the anagrams together. You can return the answer in any order.
    /// An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.
    /// </summary>
    public class GroupAnagrams
    {
        /// <summary>
        /// use a char[26] to create a hashkey that represents every anagram since strs[i] consists of lowercase English letters.
        /// then for each anagram tryadd in dictionary, if already there then add to list inside dictionary
        /// the result will be the list of this dict value
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public IList<IList<string>> Solution1(string[] strs)
        {
            var result = new Dictionary<string, IList<string>>();            

            foreach (var str in strs)
            {
                var anagram = new char[26];
                foreach (char letter in str)
                {
                    anagram[letter - 'a']++;
                }                                

                if(!result.TryAdd(new string(anagram), new List<string> { str }))
                    result[new string(anagram)].Add(str);
            }

            return result.Values.ToList();
        }

        /// <summary>
        /// use a char[26] to create a hashkey that represents every anagram since strs[i] consists of lowercase English letters.
        /// then for each anagram tryadd in dictionary, if already there then add to list inside dictionary
        /// the result will be the list of this dict value
        /// 
        /// diff from solution1 not use foreach for faster
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public IList<IList<string>> Solution2(string[] strs)
        {
            var result = new Dictionary<string, IList<string>>();

            for(int indexStr=0;indexStr<strs.Length;indexStr++)
            {
                var anagram = new char[26];
                for(int indexLetter=0; indexLetter < strs[indexStr].Length; indexLetter++)
                {
                    anagram[strs[indexStr][indexLetter] - 'a']++;
                }

                if (!result.TryAdd(new string(anagram), new List<string> { strs[indexStr] }))
                    result[new string(anagram)].Add(strs[indexStr]);
            }

            return result.Values.ToList();
        }
    }
}
