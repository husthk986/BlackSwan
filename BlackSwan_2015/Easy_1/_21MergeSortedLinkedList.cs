using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy_1
{
    class _21MergeSortedLinkedList : ILeetcode
    {
        public void DoIt()
        {
            ListNode node1 = new ListNode(1);
            ListNode node2 = new ListNode(2);
            ListNode node3 = new ListNode(3);
            ListNode node4 = new ListNode(4);
            ListNode node5 = new ListNode(5);
            ListNode node6 = new ListNode(6);
            ListNode node7 = new ListNode(7);

            node1.next = node3;
            node2.next = node4;
            node3.next = node5;
            node4.next = node6;
            node6.next = node7;

            ListNode result = MergeTwoLists(node1, node2);

            while (result != null)
            {
                Console.WriteLine(result.val);
                result = result.next;
            }
        }

        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;

            ListNode result = new ListNode(0);
            ListNode root = result;

            while (l1 != null && l2 != null)
            {
                if (l1 != null && l2 != null && l1.val <= l2.val)
                {
                    result.next = l1;
                    l1 = l1.next;
                    result = result.next;
                }
                else if (l1 != null && l2 != null && l1.val > l2.val)
                {
                    result.next = l2;
                    l2 = l2.next;
                    result = result.next;
                }

            }

            while (l1 != null)
            {
                result.next = l1;
                l1 = l1.next;
                result = result.next;
            }

            while (l2 != null)
            {
                result.next = l2;
                l2 = l2.next;
                result = result.next;
            }

            return root.next;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode(int x)
            {
                val = x;
            }
        }
    }
}


