using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium1
{
    class _61RotateList : ILeetcode
    {
        public void DoIt()
        {
            ListNode node1 = new ListNode(1);
            ListNode node2 = new ListNode(2);
            ListNode node3 = new ListNode(3);
            ListNode node4 = new ListNode(4);

            node1.next = node2;
            node2.next = node3;
            node3.next = node4;

            TestNode(node1);

            //RotateRight(node1, 2);
        }

        public void TestNode(ListNode head)
        {
            head.val = 10;

        }
        public ListNode RotateRight(ListNode head, int k)
        {
            if (head == null) return null;
            if (k == 0) return head;

            int length = GetLength(head);
            k = k % length;

            ListNode dummy = new ListNode(0);
            dummy.next = head;
            head = dummy;

            ListNode tail = dummy;
            for (int i = 0; i < k; i++)
            {
                head = head.next;
            }

            while (head.next != null)
            {
                tail = tail.next;
                head = head.next;
            }

            head.next = dummy.next;
            dummy.next = tail.next;
            tail.next = null;

            return dummy.next;
        }

        private int GetLength(ListNode head)
        {
            int length = 0;
            while (head != null)
            {
                length++;
                head = head.next;
            }

            return length;
        }
    }
}
