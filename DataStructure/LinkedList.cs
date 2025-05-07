using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_Ext_Console
{
    public class ListNode
    {
        public int Val;
        public ListNode Next;
    }

    internal class LinkedList
    {


        public void Load()
        {

        }


        public void MergeLinkedListGPT(ListNode[] lists)
        {
            ListNode result = this.Merge(lists);
            string str = string.Empty;

            while(result != null)
            {
                str += result.Val + " -> ";
                result = result.Next;
            }

            if (str.Length == 0)            
                Console.WriteLine("No elements in the list");                
            else
                Console.WriteLine(str.TrimEnd(' ', '-', '>'));
        }

        public ListNode Merge(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0) return null;

            var pq = new PriorityQueue<ListNode, int>();

            // Add all non-null list heads to the priority queue
            foreach (var node in lists)
            {
                if (node != null)
                {
                    pq.Enqueue(node, node.Val);
                }
            }

            var dummy = new ListNode() {Val = 0 };
            var tail = dummy;

            while (pq.Count > 0)
            {
                var minNode = pq.Dequeue();
                tail.Next = minNode;
                tail = tail.Next;

                if (minNode.Next != null)
                {
                    pq.Enqueue(minNode.Next, minNode.Next.Val);
                }
            }

            return dummy.Next;
        }

        public ListNode GenerateLinkedList(int[] inputs)
        {
            ListNode result = new ListNode();
            ListNode head = result;

            foreach (int i in inputs)
            {
                result.Next = new ListNode(){ Val = i };
                result = result.Next;
            }

            return head.Next;
        }

    }
}
