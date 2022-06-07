using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.LinkedList
{
    public class RemoveNthNodeFromEndOfList
    {
        public static ListNode UsingRecursion(ListNode head, int n)
        {
            int Recursion(ListNode node, int n)
            {
                if (node.next == null)
                    return n - 1;

                var position = Recursion(node.next, n);
                if (position == 0)
                {
                    var erased = node.next;
                    var substitute = erased.next;
                    node.next = substitute;
                    erased.next = null;
                }

                return position - 1;

            }

            int position = Recursion(head, n);
            if (position == 0)
            {
                if (head.next == null)
                    return null;
                else
                {
                    var newHead = head.next;
                    head.next = null;
                    return newHead;
                }

            }

            return head;
        }


        public static ListNode NeetCode(ListNode head, int n)
        {
            var dummy = new ListNode(0, head);
            var left = dummy;
            var right = head;

            while (n > 0 && right != null)
            {
                right = right.next;
                n--;
            }

            while (right != null)
            {
                left = left.next;
                right = right.next;
            }

            left.next = left.next.next;
            
            return dummy.next;
        }
    }
}
