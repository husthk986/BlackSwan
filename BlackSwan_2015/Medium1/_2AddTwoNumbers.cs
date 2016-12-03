using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Medium1
{
    class _2AddTwoNumbers : ILeetcode
    {
        public void DoIt()
        {
            //(2 -> 4 -> 3) + (5 -> 6 -> 4) ==>  7 -> 0 -> 8
            //ListNode l1 = new ListNode(2);
            //l1.next = new ListNode(4);
            //l1.next.next = new ListNode(3);

            //ListNode l2 = new ListNode(5);
            //l2.next = new ListNode(6);
            //l2.next.next = new ListNode(4);

            //1->8 + 0 => 1->8
            //ListNode l1 = new ListNode(1);
            //l1.next = new ListNode(8);

            //ListNode l2 = new ListNode(0);

            //1 + 9-> 9 => 1->0->0
            ListNode l1 = new ListNode(1);

            ListNode l2 = new ListNode(9);
            l2.next = new ListNode(9);

            ListNode add = AddTwoNumbers(l1, l2);

            while (add != null)
            {
                Console.WriteLine(add.val);
                add = add.next;
            }

        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            if (l1 == null || l2 == null)
                return null;

            int currentValue = (l1.val + l2.val) % 10;
            int currentCarry = (l1.val + l2.val) / 10;
            ListNode node = new ListNode(currentValue);

            node.next = AddTwoNumbers(l1.next, l2.next, currentCarry);
            return node;
        }
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2, int carry)
        {
            int value1 = 0;
            int value2 = 0;

            if (l1 != null) //Key1: Length of l1 and l2 may not equal.
            {
                value1 = l1.val;
            }
            if (l2 != null)
            {
                value2 = l2.val;
            }

            if (l1 != null || l2 != null)
            {
                int currentValue = (value1 + value2 + carry) % 10; //Key2: Add carry
                int currentCarry = (value1 + value2 + carry) / 10;
                ListNode node = new ListNode(currentValue);

                node.next = AddTwoNumbers(l1 == null ? null : l1.next, l2 == null ? null : l2.next, currentCarry);

                return node;
            }

            if (carry != 0) //Key3: Even l1 and l2 are end, the carry may not.
            {
                return new ListNode(carry);
            }

            return null;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
}
