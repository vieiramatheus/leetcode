using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.Trees
{
    public class LCA_BinarySearchTree
    {
        public static TreeNode LowestCommonAncestorRecursion(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
                return null;

            if (root.val < p.val && root.val < q.val)
            {
                return LowestCommonAncestorRecursion(root.right, p, q);
            }

            if (root.val > p.val && root.val > q.val)
            {
                return LowestCommonAncestorRecursion(root.left, p, q);
            }

            return root;
        }

        public static TreeNode LowestCommonAncestorLoop(TreeNode root, TreeNode p, TreeNode q)
        {
            var current = root;
            while (current != null)
            {
                if (current.val < p.val && current.val < q.val)
                {
                    current = current.right;
                }
                else if (current.val > p.val && current.val > q.val)
                {
                    current = current.left;
                }
                else
                    return current;
            }

            return null;
        }
    }
}
