using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.LinkedList
{   
    public class ReverseLinkedList
    {
        /// <summary>
        /// Solution 2O(n), unlink everyone and put on normal list, then reverse scan this list linking them again
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static ListNode ReverseListIn_2BigO_Of_N(ListNode head)
        {
            var list = new List<ListNode>();
            var node = head;
            while (node != null)
            {
                var aux = node.next;
                node.next = null;
                list.Add(node);
                node = aux;
            }

            node = list[list.Count - 1];
            for (int i = list.Count - 2; i >= 0; i--)
            {
                node.next = list[i];
                node = list[i];
            }
            node = list[list.Count - 1];

            return node;
        }

        /// <summary>
        /// Neet code solution utilizes two pointer plus a aux variavel to scan and revert every single link in one single scan
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static ListNode ReverseListIn_BigO_Of_N(ListNode head)
        {
            ListNode prev = null, curr = head;

            while (curr != null)
            {
                var aux = curr.next;
                curr.next = prev;
                prev = curr;
                curr = aux;
            }

            return prev;
        }

        /// <summary>
        /// Neet code solution with ReverseList using recursion
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static ListNode ReverseListRecursively(ListNode head)
        {
            if (head == null)
                return null;

            var newHead = head;
            if (head.next != null)
            {
                newHead = ReverseListRecursively(head.next);
                
                var next = head.next;

                next.next = head;
            }

            head.next = null;

            return newHead;
        }
    }
}
