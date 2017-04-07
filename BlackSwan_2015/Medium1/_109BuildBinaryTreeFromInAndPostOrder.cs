using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Medium1
{
    internal class _109BuildBinaryTreeFromInAndPostOrder : ILeetcode
    {
        public void DoIt()
        {
            int[] inorder = {1, 3, 2};
            int[] postorder = {3, 2, 1};
            BuildTree(inorder, postorder);
        }

        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            if (inorder == null || postorder == null || inorder.Length != postorder.Length || inorder.Length == 0) return null;

            return Helper(inorder, postorder, 0, inorder.Length - 1, 0, postorder.Length - 1);
        }

        private TreeNode Helper(int[] inorder, int[] postorder, int inorderStart, int inorderEnd, int postorderStart, int postorderEnd)
        {
            if (inorderStart > inorderEnd || postorderStart > postorderEnd) return null;

            int val = postorder[postorderEnd];
            TreeNode root = new TreeNode(val);

            int index = 0;
            for (; index < inorderEnd - inorderStart; index++)
            {
                if (inorder[index + inorderStart] == val)
                {
                    break;
                }
            }

            root.left = Helper(inorder, postorder, inorderStart, index + inorderStart - 1, postorderStart, index + postorderStart - 1);
            root.right = Helper(inorder, postorder, index + inorderStart + 1, inorderEnd, index + postorderStart, postorderEnd - 1);

            return root;
        }
    }
}
