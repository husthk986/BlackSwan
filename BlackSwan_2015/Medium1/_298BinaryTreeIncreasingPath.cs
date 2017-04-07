using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium1
{
    internal class _298BinaryTreeIncreasingPath : ILeetcode
    {

        public void DoIt()
        {
            TreeNode root = new TreeNode(1);
            root.right = new TreeNode(3);
            root.right.left = new TreeNode(2);
            root.right.right = new TreeNode(4);
            root.right.right.right = new TreeNode(5);

            Console.WriteLine("Should be 3 : " + LongestConsecutive(root));
        }


        public int LongestConsecutive(TreeNode root)
        {
            if (root == null) return 0;
            List<TreeNode> result = new List<TreeNode>();

            int count = 0;
            Helper(root, new List<TreeNode>(), ref count);

            return count;
        }

        private void Helper(TreeNode node, List<TreeNode> ls, ref int count)
        {
            if (node != null)
            {
                ls.Add(node);
            }

            if (node.left != null)
            {
                if (node.val == node.left.val - 1)
                {
                    Helper(node.left, ls, ref count);
                    ls.RemoveAt(ls.Count - 1);
                }
                else
                {
                    Helper(node.left, new List<TreeNode>(), ref count);
                }
            }
            count = Math.Max(count, ls.Count);

            if (node.right != null)
            {
                if (node.val == node.right.val - 1)
                {
                    Helper(node.right, ls, ref count);
                    ls.RemoveAt(ls.Count - 1);
                }
                else
                {
                    Helper(node.right, new List<TreeNode>(), ref count);
                }
            }
            count = Math.Max(count, ls.Count);
        }
    }

}
