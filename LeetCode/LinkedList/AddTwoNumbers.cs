using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LinkedList
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
    class AddTwoNumbers
    {
        /* 
            Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
            Output: 7 -> 0 -> 8
            Explanation: 342 + 465 = 807.
        */


        /* First and best approach is to get the same index elements of both linked list 
         * and add it, if the result greater than 10 then have a carry to 1 otherwise set to 0
         * add each element in first node data + second node + carry. Create a result node 
         * with the resulted sum
         */
        public ListNode AddTwoNumbersApproach1(ListNode l1, ListNode l2)
        {
            int sum = 0, carry = 0;
            ListNode result = null;
            ListNode temp = null;
            while (l1 != null || l2 != null)
            {
                int l1Val = 0, l2Val = 0;
                if (l1 != null)
                {
                    l1Val = l1.val;
                    l1 = l1.next;
                }
                if (l2 != null)
                {
                    l2Val = l2.val;
                    l2 = l2.next;
                }

                sum = l1Val + l2Val + carry;

                carry = sum >= 10 ? 1 : 0;
                if (sum >= 0)
                    sum = sum % 10;
                if (result == null)
                {
                    result = new ListNode(sum);
                    temp = result;
                }
                else
                {
                    temp.next = new ListNode(sum);
                    temp = temp.next;
                }
            }
            if (carry == 1)
                temp.next = new ListNode(1);

            return result;
        }

        /* In this approach iterate thorugh all the list nodes and find l1 sum of all nodes
         * and l2 sum of all nodes, get the total sum and extract each digit from the total sum
         and make a result linked list*/
        public ListNode AddTwoNumbersApproach2(ListNode l1, ListNode l2)
        {
            long l1Sum = 0, l2Sum = 0, power = 0;
            ListNode result = null;
            ListNode temp = null;
            while (l1 != null || l2 != null)
            {
                if (l1 != null)
                {
                    l1Sum += l1.val * (long)Math.Pow(10, power);
                    l1 = l1.next;
                }
                if (l2 != null)
                {
                    l2Sum += l2.val * (long)Math.Pow(10, power);
                    l2 = l2.next;
                }
                power++;
            }
            long totalSum = l1Sum + l2Sum;
            if (totalSum == 0)
                return new ListNode(0);

            while (totalSum > 0)
            {
                int remainder = (int)(totalSum % 10);
                if (result == null)
                {
                    result = new ListNode(remainder);
                    temp = result;
                }
                else
                {
                    temp.next = new ListNode(remainder);
                    temp = temp.next;
                }
                totalSum = totalSum / 10;
            }

            return result;
        }
    }
}
