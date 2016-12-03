using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy_1
{
    class _19RemoveNthNode : ILeetcode
    {
        public void DoIt()
        {
            ListNode node1 = new ListNode(1);
            ListNode node2 = new ListNode(2);
            //ListNode node3 = new ListNode(3);
            //ListNode node4 = new ListNode(4);
            //ListNode node5 = new ListNode(5);
            node1.next = node2;
            //node2.next = node3;
            //node3.next = node4;
            //node4.next = node5;

            ListNode result = RemoveNthFromEnd(node1, 1);

            while (result != null)
            {
                Console.WriteLine(result.val);
                result = result.next;
            }

        }

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (head == null)
                return null;
            if (head.next == null && n >= 1)
                return null;

            ListNode start = new ListNode(0);
            ListNode slow = start, fast = start;
            start.next = head;

            for (int i = 0; i < n; i++)
            {
                fast = fast.next;
            }
            //Move fast to the end, maintaining the gap
            while (fast.next != null)
            {
                slow = slow.next;
                fast = fast.next;
            }
            //Skip the desired node
            slow.next = slow.next.next;
            return start.next;
        }

        public ListNode RemoveNthFromEnd1(ListNode head, int n)
        {
            if (head == null)
                return null;
            if (head.next == null && n >= 1)
                return null;

            int index = 0;
            head = GetRemovedNext(head, n, ref index);
            if (index == n)
            {
                return head.next;
            }

            return head;
        }

        private ListNode GetRemovedNext(ListNode listNode, int n, ref int index)
        {
            if (listNode.next == null)
            {
                index = 1;
                return listNode;
            }

            listNode.next = GetRemovedNext(listNode.next, n, ref index);

            if (index++ == n)
            {
                listNode.next = listNode.next.next;
            }

            return listNode;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }
}
