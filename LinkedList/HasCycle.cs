using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.LinkedList
{
    public class HasCycle
    {
        /// <summary>
        /// Floyd's Tortoise & Hare Cycle Detection
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static bool SlowFasterPointerSolution(ListNode head)
        {
            var slow = head;
            var fast = head;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Solution using hashset, but you store the entire instance
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static bool HashSetSolution(ListNode head)
        {
            var quadro = new HashSet<ListNode>();
            while (head != null)
            {
                if (quadro.Contains(head))
                    return true;

                quadro.Add(head);
                head = head.next;
            }

            return false;
        }
    }
}
