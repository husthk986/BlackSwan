using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hard_1
{
    internal class _25ReverseNodesInKGroup : ILeetCode
    {
        public void DoIt()
        {
            ListNode node1 = new ListNode(1);
            ListNode node2 = new ListNode(2);
            ListNode node3 = new ListNode(3);
            ListNode node4 = new ListNode(4);
            ListNode node5 = new ListNode(5);

            node1.next = node2;
            node2.next = node3;
            //node3.next = node4;
            //node4.next = node5;

            ListNode result = ReverseKGroup(node1, 3);

            while (result != null)
            {
                Console.WriteLine(result.val);
                result = result.next;
            }

        }
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            if (head == null)
                return null;
            if (head.next == null)
                return head;

            int i = k;
            ListNode nextGroup = head;
            while (i > 0 && nextGroup != null)
            {
                nextGroup = nextGroup.next;
                i--;
            }
            if (i > 0)
            {
                return head;
            }

            i = k;
            ListNode preHead = ReverseKGroup(nextGroup, k);
            ListNode currHead = head;
            ListNode nextHead = null;
            while (i > 0)
            {
                nextHead = currHead.next;
                currHead.next = preHead;
                preHead = currHead;
                currHead = nextHead;

                i--;
            }

            return preHead;
        }

    }
}
