using System;

namespace Algoritmos
{
    class Program
    {
        static void Main(string[] args)
        {
            //var subTree = new Trees.TreeNode(val: 4,
            //    left: new Trees.TreeNode(val: 1),
            //    right: new Trees.TreeNode(val: 2));

            //var tree = new Trees.TreeNode(val: 3,
            //    left: new Trees.TreeNode(val: 4,
            //        left: new Trees.TreeNode(val: 1),
            //        right: new Trees.TreeNode(val: 2,
            //            left: new Trees.TreeNode(val: 0))),
            //    right: new Trees.TreeNode(5));

            //var tree = new Trees.TreeNode(1, new Trees.TreeNode(1));
            //var subtree = new Trees.TreeNode(1);

            //[3,4,5,1,null,2]
            var tree = new Trees.TreeNode(val: 3,
                left:   new Trees.TreeNode(val: 4, left: new Trees.TreeNode(1), right: null),
                right:  new Trees.TreeNode(val: 5, left: new Trees.TreeNode(2)));

            var subtree = new Trees.TreeNode(3, left: new Trees.TreeNode(1), right: new Trees.TreeNode(2));

            Console.WriteLine(Trees.SubTreeofAnotherTree.IsSubtree(tree, subtree));

            //var arvore = 
            //    new Trees.TreeNode(val: 0,
            //        left: new Trees.TreeNode(val: 2,
            //            left: new Trees.TreeNode(val: 1,
            //                left: new Trees.TreeNode(val: 5),
            //                right: new Trees.TreeNode(val: 1)),
            //            right: null),
            //        right: new Trees.TreeNode(val: 4,
            //            left: new Trees.TreeNode(val: 3,
            //                left: null,
            //                right: new Trees.TreeNode(val: 6)),
            //            right: new Trees.TreeNode(val: -1,
            //                left: new Trees.TreeNode(val: 8))));

            //var depth = Trees.MaxDepth.BFS_Iteration_Solution(arvore);

            //Console.WriteLine(depth);

            //var node1 = new LinkedList.ListNode(1, new LinkedList.ListNode(4, new LinkedList.ListNode(5)));
            //var node2 = new LinkedList.ListNode(1, new LinkedList.ListNode(3, new LinkedList.ListNode(4)));
            //var node3 = new LinkedList.ListNode(2, new LinkedList.ListNode(6));

            //var result = LinkedList.MergeKSortedLists.ThreeMerging(new LinkedList.ListNode[] { node1, node2, node3 });
            //var result = LinkedList.MergeKSortedLists.ThreeMerging(new LinkedList.ListNode[] { });

            //while (result != null)
            //{
            //    Console.WriteLine(result.val);
            //    result = result.next;
            //}

            //var result = LinkedList.HasCycle.SlowFasterPointerSolution(node);

            //Console.WriteLine(result);

            //while (head != null)
            //{
            //    Console.WriteLine(head.val);
            //    head = head.next;
            //}


            //LinkedList.ReverseLinkedList.ReverseListRecursively(node);

            //Console.WriteLine(BinarySearch.FindMinimunRotatedSortedArray.MonkeyCode(new int[] { 2, 1 }));

            //Console.WriteLine(BinarySearch.SearchRotatedSortedArray.MonkeyCode(new int[] { 3, 1 }, 4));

            //Console.WriteLine(Stack.ValidParenthesis.LeetCodeTop1FastSolution("()[]{}"));

            //minimun windows
            //Console.WriteLine(SlidingWindow.MinimunWindowSubstring.NeetCode("cabwefgewcwaefgcf", "cae"));

            //SlidingWindow.LongestRepeatingCharacterReplacement.CharacterReplacement("AABABBA", 1);

            ///LongestSubstring
            //Console.WriteLine(SlidingWindow.LongestSubstring.LengthOfLongestSubstringWithoutHashSet("abcabcbb"));

            ///Warren buffet has a Delorean
            //Console.WriteLine(SlidingWindow.WarrenBuffetStockTrader.WarrenBuffetTradeStocksInDeloreanCar(new int[] { 7, 1, 5, 3, 6, 4, 0, 9 }));

            ///Container
            //Console.WriteLine(TwoPointer.ContainerWithMostWater.MaxArea(new int[] { 1, 1 }));

            ///triplets
            //var result = TwoPointer._3SumTriplets.ThreeSum(new int[] { -1, 0, 1, 0 });

            //foreach (var item in result)
            //{
            //    Console.WriteLine("{0}, ", item);
            //}

            ///ValidPalindrome
            //var result = TwoPointer.ValidPalindrome.Solution2("A man, a plan, a canal: Panama");
            //var result = TwoPointer.ValidPalindrome.Solution2("race a car");

            //Console.WriteLine(result);

            /// -> Length of the longest consecutive elements sequence.
            //var result = ArrayHash.LongestConsecutiveSequence.Solution1(new int[] { 0, 1, 2, 4, 8, 5, 6, 7, 9, 3, 55, 88, 77, 99, 999999999 });
            //Console.WriteLine(result);

            /// -> EncodeDecodeStrings
            //Console.WriteLine("Write encoding stuff:");
            //var result1 = ArrayHash.EncodeDecodeStrings.Encode(new string[] { "lint", "code", "love", "you" });
            //Console.WriteLine(result1);

            //Console.WriteLine("Write decoding stuff:");
            //var result2 = ArrayHash.EncodeDecodeStrings.Decode(result1);
            //foreach (var item in result2)
            //{
            //    Console.WriteLine("{0}, ", item);
            //}
        }
    }
}