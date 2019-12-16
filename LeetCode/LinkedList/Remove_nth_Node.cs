using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LinkedList
{
    partial class LeetCodePractice
    {
        /*Remove Nth Node From End of List
         Given linked list: 1->2->3->4->5, and n = 2.
        After removing the second node from the end, the linked list becomes 1->2->3->5.*/

        public ListNode RemoveNthFromEnd1(ListNode head, int n)
        {
            ListNode dummy = new ListNode(0);
            dummy.next = head;
            ListNode slowPointer = dummy;
            ListNode fastPointer = dummy;
            int temp = 0;
            while (fastPointer != null && fastPointer.next != null)
            {
                if (temp > n - 1)
                    slowPointer = slowPointer.next;
                fastPointer = fastPointer.next;
                temp++;
            }
            slowPointer.next = slowPointer.next.next;
            return dummy.next; ;

        }

        public ListNode RemoveNthFromEnd2(ListNode head, int n)
        {
            ListNode dummy = new ListNode(0);
            dummy.next = head;
            ListNode current = dummy;
            int length = 0;
            while(current != null)
            {
                length++;
                current = current.next;
            }

            length -= n;
            current = dummy;
            while(length > 0)
            {
                dummy = dummy.next;
                length--;
            }
            current.next = current.next.next;
            return dummy.next; ;

        }
    }
}
