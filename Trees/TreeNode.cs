using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.Trees
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        public TreeNode Clone()
        {
            var leftClone = left?.Clone();
            var rightClone = right?.Clone();
            return new TreeNode(val, leftClone, rightClone);
        }

        public override string ToString()
        {
            var leftVal = left?.val;
            var rightVal = right?.val;
            return $"value: {val}, left: {leftVal}, right: {rightVal}.";
        }
    }
}
