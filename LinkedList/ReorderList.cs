using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.LinkedList
{
    public class ReorderList
    {
        /// <summary>
        /// this basically unlinks every linked list
        /// then links again with the new rules
        /// this not work because it is supposed to not use any extra memory
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static ListNode Reorder(ListNode head)
        {
            var list = new List<ListNode>();

            ListNode pivot;
            while (head != null)
            {
                pivot = head.next;
                head.next = null;
                list.Add(head);
                head = pivot;
            }

            int r = list.Count - 1, l = 0;
            while (l < r)
            {
                var left = list[l];
                var right = list[r];

                left.next = right;
                if (l + 1 < r)
                    right.next = list[l + 1];

                l++;
                r--;
            }

            return list[0];
        }

        /// <summary>
        /// this solution is something like a merge of two other solutions
        /// you invert the half of linked list then merge them
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static ListNode NeetCodeSolution(ListNode head)
        {
            var slow = head;
            var fast = head.next;

            //slow and fast pointers
            //one pointer walks twice of other
            //in the end of faster
            //slow will be exactly in the middle
            //--------------------------------------
            //[1, 2, 3, 4, 5]*
            //[s, f          | <- first iteration
            //[   s     f    | <- second iteration
            //[      s       f <- never gets here

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }


            //inversion of linked list
            // saving previous pointer in the variable
            // so in the next iteration we can invert the
            // relation by setting curr.next = prev
            // you have to save the actual correlation
            // in a tmp variable before that
            // otherwise you will lose the bond
            //----------------------------------------
            //   [3,  | 4 |,| 5 |]
            //p  [s   |tmp| |   |
            //p <-s         |   |
            //    p  <- s   |tmp|
            //          p  <- s
            //   3  <-  4  <- 5

            ListNode current = slow.next;
            ListNode prev = null;
            slow.next = null; 
            while (current != null)
            {
                var tmp = current.next;
                current.next = prev;
                prev = current;
                current = tmp;
            }

            var first = head;
            var second = prev;
            // merging of linked list
            // the principle here is the alternation
            // you have to set first.next = second
            // you have to set second.next = first.next
            // to avoid that second references himself
            // save bond in tmps variables before
            //------------------------------------------
            // [1,  2,  3] [4,  5]
            //  f  t1       s   t2
            //  f---------->s
            //     t1<-------s  
            //     f   t1       s  t2
            //     f----------->s
            //         t1<------s
            while (second != null)
            {
                var tmp1 = first.next;
                var tmp2 = second.next;

                first.next = second;
                second.next = tmp1;
                first = tmp1;
                second = tmp2;
            }

            return head;
        }
    }
}
