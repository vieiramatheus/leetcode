using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.Trees
{
    public class SameTree
    {
        public static bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null || q == null)            
                return p == q;

            if (p.val == q.val)
            {
                var sameLeft = IsSameTree(p.left, q.left);
                var sameRight = IsSameTree(p.right, q.right); ;

                return sameLeft && sameRight;
            }

            return false;
        }
    }
}
