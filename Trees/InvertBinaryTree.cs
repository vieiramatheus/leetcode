using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.Trees
{
    /// <summary>
    /// Given the root of a binary tree, invert the tree, and return its root.
    /// </summary>
    public class InvertBinaryTree
    {
        public static TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
                return null;

            var left = root.left;
            root.left = root.right;
            root.right = left;

            InvertTree(root.left);
            InvertTree(root.right);

            return root;
        }
    }
}
