using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hard_1
{
    class _23MergedKSortedList : ILeetCode
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

            ListNode[] lists = { node1, node2, node7 };
            ListNode result = MergeKLists(lists);

            while (result != null)
            {
                Console.WriteLine(result.val);
                result = result.next;
            }
        }

        #region Divide and Concour
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists.Count() == 0) return null;

            return MergeLinkedList(lists, 0, lists.Count() - 1);
        }

        private ListNode MergeLinkedList(ListNode[] lists, int lo, int hi)
        {
            if (lo == hi)
                return lists[lo];

            int mid = lo + (hi - lo) / 2;
            ListNode left = MergeLinkedList(lists, lo, mid);
            ListNode right = MergeLinkedList(lists, mid + 1, hi);
            return MergeTwoLinkedList(left, right);
        }

        private ListNode MergeTwoLinkedList(ListNode node1, ListNode node2)
        {
            ListNode result = new ListNode(0);
            ListNode pointer = result;

            while (node1 != null && node2 != null)
            {
                if (node1.val < node2.val)
                {
                    pointer.next = node1;
                    node1 = node1.next;
                }
                else
                {
                    pointer.next = node2;
                    node2 = node2.next;
                }
                pointer = pointer.next;
            }

            while (node1 != null)
            {
                pointer.next = node1;
                node1 = node1.next;
                pointer = pointer.next;
            }
            while (node2 != null)
            {
                pointer.next = node2;
                node2 = node2.next;
                pointer = pointer.next;
            }

            return result.next;
        }
        #endregion

        #region Heap
        public ListNode MergeKLists1(ListNode[] lists)
        {
            ListNode result = new ListNode(0);
            ListNode pointer = result;

            MinHeap mh = new MinHeap();
            foreach (ListNode node in lists)
            {
                if (node != null)
                {
                    mh.Add(node);
                }
            }

            while (mh.Count > 0)
            {
                ListNode node = mh.PopMin();
                if (node.next != null)
                {
                    mh.Add(node.next);
                }
                pointer.next = node;
                pointer = pointer.next;
            }


            return result.next;

        }

        public class MinHeap
        {
            private List<ListNode> mListOfListNodes;
            public MinHeap()
            {
                mListOfListNodes = new List<ListNode>();
            }

            public void Add(ListNode node)
            {
                mListOfListNodes.Add(node);
                Heapify();
            }

            public ListNode PopMin()
            {
                if (mListOfListNodes.Count > 0)
                {
                    ListNode node = mListOfListNodes[0];
                    mListOfListNodes.RemoveAt(0);
                    Heapify();
                    return node;
                }

                return null;
            }

            public int Count
            {
                get
                {
                    return mListOfListNodes.Count;
                }
            }

            private void Heapify()
            {
                for (int i = mListOfListNodes.Count - 1; i > 0; i--)
                {
                    int parentIndex = (i - 1) / 2;
                    if (mListOfListNodes[parentIndex].val > mListOfListNodes[i].val)
                    {
                        ListNode temp = mListOfListNodes[parentIndex];
                        mListOfListNodes[parentIndex] = mListOfListNodes[i];
                        mListOfListNodes[i] = temp;
                    }
                }
            }
        }
        #endregion

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
