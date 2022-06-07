using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.LinkedList
{
    /// <summary>
    /// You are given an array of k linked-lists lists, each linked-list is sorted in ascending order.
    /// Merge all the linked-lists into one sorted linked-list and return it.
    /// Example 1:
    /// Input: lists = [[1,4,5],[1,3,4],[2,6]]
    /// Output: [1,1,2,3,4,4,5,6]
    /// Explanation: The linked-lists are:
    /// [
    ///   1->4->5,
    ///   1->3->4,
    ///   2->6
    /// ]
    /// merging them into one sorted list:
    /// 1->1->2->3->4->4->5->6
    /// </summary>
    public class MergeKSortedLists
    {
        /// <summary>
        /// This will iterate throughout every element 
        /// figureout who is the lesser, append to our result,
        /// then update the lists[i] to the next position
        /// Begin the comparation again
        /// complexity: O(k.N)
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        public static ListNode LinearMerge(ListNode[] lists)
        {
            var dummy = new ListNode();
            var node = dummy;
            while (node != null)
            {
                int index = 0, lesserIndex = -1;
                ListNode lesser = null;
                while (index < lists.Length)
                {
                    var current = lists[index];
                    if (current != null && (lesser == null || current.val < lesser.val))
                    {
                        lesser = current;
                        lesserIndex = index;
                    }
                    index++;
                }

                if (lesserIndex >= 0)
                {
                    lists[lesserIndex] = lesser != null ? lesser.next : null;
                }

                node.next = lesser;
                node = node.next;
            }

            return dummy.next;
        }


        /// <summary>
        /// Neet code solution.
        /// This guy will get two adjacent linked lists, 
        /// merge them using O(n) linear scan solution
        /// store the solution, them go to the next two,
        /// repeat this until in your mergedlist will 
        /// remain only one node
        /// 
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        public static ListNode ThreeMerging(ListNode[] lists)
        {
            ListNode MergeLists(ListNode list1, ListNode list2)
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

            if (lists == null || lists.Length == 0)
                return null;

            while (lists.Length > 1)
            {
                var merged = new List<ListNode>();

                for (int i = 0; i < lists.Length; i += 2)
                {
                    var l1 = lists[i];
                    var l2 = lists.Length > i + 1 ? lists[i + 1] : null;

                    merged.Add(MergeLists(l1, l2));
                }

                lists = merged.ToArray();
            }

            return lists[0];
        }

    }
}