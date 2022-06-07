using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.LinkedList
{
    public class FindDuplicateNumber
    {
        /// <summary>
        /// If programming was an anime...
        /// 
        /// problably tech recruiters will have a easier job
        /// we will know who is the best programmer just by 
        /// searching for the most stravagant haircut
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int FindDuplicate(int[] nums)
        {
            int slow = 0, fast = 0;

            do
            {
                slow = nums[slow];
                fast = nums[nums[fast]];

            } while (slow != fast);

            int slow2 = 0;
            do
            {
                slow = nums[slow];
                slow2 = nums[slow2];
            } while (slow != slow2);

            return slow;
        }
    }
}
