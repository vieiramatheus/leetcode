using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.Trees
{
    /// <summary>
    /// Given the root of a binary tree, return its maximum depth.
    /// A binary tree's maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.
    /// </summary>
    public class MaxDepth
    {
        /// <summary>
        /// It reads the entire three using recursion ignoring lesser values
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int DFS_Recursion_Solution(TreeNode root)
        {
            if (root == null)
                return 0;

            return 1 + Math.Max(DFS_Recursion_Solution(root.left), DFS_Recursion_Solution(root.right));
        }

        /// <summary>
        /// Breadth first search it is a search that iterate througout the levels of the tree
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int BFS_Iteration_Solution(TreeNode root)
        {
            if (root == null)
                return 0;

            int level = 0;
            var q = new Queue<TreeNode>(new[] { root });

            while (q.Count > 0)
            {
                var count = q.Count;

                for (int i = 0; i < count; i++)
                {
                    var node = q.Dequeue();

                    if (node.left != null)
                        q.Enqueue(node.left);

                    if (node.right != null)
                        q.Enqueue(node.right);
                }

                level++;
            }

            return level;
        }

        public static int DFS_Iteration_Solution(TreeNode root)
        {
            if (root == null)
                return 0;

            var stack1 = new Stack<TreeNode>(new[] { root });
            var stack2 = new Stack<int>(new[] { 1 });

            var maxDepth = 1;
            while (stack1.Count > 0 && stack2.Count > 0)
            {
                var node = stack1.Pop();
                var depth = stack2.Pop();

                
                if (node.left != null)
                {
                    stack1.Push(node.left);
                    stack2.Push(depth + 1);
                }

                if (node.right != null)
                {
                    stack1.Push(node.right);
                    stack2.Push(depth + 1);
                }

                maxDepth = Math.Max(maxDepth, depth);
            }

            return maxDepth;
        }
    }
}
