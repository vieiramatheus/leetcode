using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.Trees
{
    /// <summary>
    /// Given the roots of two binary trees root and subRoot, return true if there is a subtree of root with the same structure and node values of subRoot and false otherwise.
    /// A subtree of a binary tree tree is a tree that consists of a node in tree and all of this node's descendants. The tree tree could also be considered as a subtree of itself.
    /// </summary>
    public class SubTreeofAnotherTree
    {
        public static bool IsSubtree(TreeNode root, TreeNode subRoot)
        {
            if (subRoot == null)
                return true;

            if (root == null)
                return false;

            if (IsSameTree(root, subRoot))            
                return true;
            

            bool sameLeft = IsSubtree(root.left, subRoot.left);
            bool sameRight = IsSubtree(root.right, subRoot.right);

            if (sameLeft && sameRight)
                return true;

            return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
        }

        public static bool IsSameTree(TreeNode x, TreeNode y)
        {
            if (x == null || y == null)
                return x == y;

            if (x.val == y.val)
            {
                var sameLeft = IsSameTree(x.left, y.left);
                var sameRight = IsSameTree(x.right, y.right); ;

                return sameLeft && sameRight;
            }

            return false;
        }
    }
}
