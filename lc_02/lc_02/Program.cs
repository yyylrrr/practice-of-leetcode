using System;
using System.Collections.Generic;

namespace lc_02
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode listNode = new ListNode();
            Solution solution = new Solution();
            ListNode l1 = listNode.GenerateList(new int[] { 1, 5, 7 });
            ListNode l2 = listNode.GenerateList(new int[] { 9, 8, 2, 9 });
            listNode.PrintList(l1);
            listNode.PrintList(l2);
            listNode.PrintList(solution.AddTwoNumbers(l1, l2));
        }

    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
        
        public ListNode GenerateList(int[] vals)
        {
            ListNode res = null;
            ListNode last = null;
            foreach (int val in vals)
            {
                if (res is null)
                {
                    res = new ListNode(val);
                    last = res;
                }
                else
                {
                    last.next = new ListNode(val);
                    last = last.next;
                }
            }
            return res;
        }
        
        public void PrintList(ListNode l)
        {
            List<int> intList = new List<int>();
            while (l != null)
            {
                intList.Add(l.val);
                l = l.next;
            }
            int[] arr = intList.ToArray();
            Console.WriteLine("[{0}]", string.Join(", ", arr));
        }
    }

    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode root = new ListNode(0);
            ListNode cursor = root;
            int carry = 0;
            while (l1 != null || l2 != null || carry != 0)
            {
                int l1Val = l1 != null ? l1.val : 0;
                int l2Val = l2 != null ? l2.val : 0;
                int sumVal = l1Val + l2Val + carry;
                carry = sumVal / 10;
                ListNode sumNode = new ListNode(sumVal % 10);
                cursor.next = sumNode;
                cursor = sumNode;
                if (l1 != null)
                    l1 = l1.next;
                if (l2 != null)
                    l2 = l2.next;
            }
            return root.next;
        }
    }
}
