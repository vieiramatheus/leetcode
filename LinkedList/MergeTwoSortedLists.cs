using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.LinkedList
{
    public class MergeTwoSortedLists
    {
        /// <summary>
        /// Neet code solution you scan simultaenously the two lists
        /// 
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public static ListNode SolutionScanBigOfN(ListNode list1, ListNode list2)
        {            
            var result = new ListNode();
            var tail = result;

            while (list1 != null && list2 != null)
            {
                if (list1.val <= list2.val)
                {
                    tail.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    tail.next = list2;
                    list2 = list2.next;
                }
                tail = tail.next;
            }
            if (list1 != null)
                tail.next = list1;
            else if (list2 != null)
                tail.next = list2;

            return result.next;
        }
    }
}
