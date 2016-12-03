using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy_1
{
    class _24SwapNodesInPairs : ILeetcode
    {
        public void DoIt()
        {
            ListNode node1 = new ListNode(1);
            ListNode node2 = new ListNode(2);
            ListNode node3 = new ListNode(3);
            ListNode node4 = new ListNode(4);

            node1.next = node2;
            node2.next = node3;
            //node3.next = node4;

            ListNode result = SwapPairs(node1);

            while (result != null)
            {
                Console.WriteLine(result.val);
                result = result.next;
            }
        }

        public ListNode SwapPairs(ListNode head)
        {
            if (head == null)
                return null;
            if (head.next == null)
                return head;

            ListNode result = new ListNode(0);
            ListNode pointer = result;
            while (head != null && head.next != null)
            {
                ListNode node = head.next.next;
                pointer.next = SwapTwoNodes(head, head.next);
                head = node;
                pointer = pointer.next.next;

            }
            return result.next;
        }

        private ListNode SwapTwoNodes(ListNode node1, ListNode node2)
        {
            if (node2 == null)
                return null;

            ListNode afterNode = node2.next;
            node2.next = node1;
            node1.next = afterNode;

            return node2;
        }

        public ListNode SwapPairs1(ListNode head)
        {
            if (head == null)
                return null;
            if (head.next == null)
                return head;

            ListNode oddList = new ListNode(0);
            ListNode oddHead = oddList;
            ListNode evenList = new ListNode(0);
            ListNode evenHead = evenList;
            while (head != null)
            {
                oddList.next = head;
                oddList = oddList.next;

                evenList.next = head.next;
                if (head.next != null)
                {
                    head = head.next.next;
                    evenList = evenList.next;
                }

                if (head == null)
                    oddList.next = null;
            }

            ListNode result = new ListNode(0);
            ListNode pointer = result;
            evenHead = evenHead.next;
            oddHead = oddHead.next;
            while (oddHead != null && evenHead != null)
            {
                pointer.next = evenHead;
                evenHead = evenHead.next;
                pointer = pointer.next;

                pointer.next = oddHead;
                oddHead = oddHead.next;
                pointer = pointer.next;

            }

            while (oddHead != null)
            {
                pointer.next = oddHead;
                oddHead = oddHead.next;
                pointer = pointer.next;
            }

            return result.next;
        }

    }
}
