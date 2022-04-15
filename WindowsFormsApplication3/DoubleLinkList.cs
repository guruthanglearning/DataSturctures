using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class DoubleLinkList : Form
    {

        #region
        public class Node
        {
            public int data;
            public Node left;
            public Node right;            
        }


        public class DoubleLL
        {
            public int Data;
            public DoubleLL Next;
            public DoubleLL Previous;
            public DoubleLL Child;
        }
        #endregion


        public DoubleLinkList()
        {
            InitializeComponent();
        }

        private void Find_pairs_with_given_sum_in_doubly_linked_list_Click(object sender, EventArgs e)
        {
            //http://www.geeksforgeeks.org/find-pairs-with-given-sum-such-that-pair-elements-lie-in-different-bsts/
            //http://www.geeksforgeeks.org/find-pairs-given-sum-doubly-linked-list/

            DoubleLL node = null;
            node = this.InsertDoubleLL(node, 1);
            node = this.InsertDoubleLL(node, 4);
            node = this.InsertDoubleLL(node, 2);
            node = this.InsertDoubleLL(node, 3);

            MessageBox.Show(string.Format("Forward: {0} \nBackward: {1}", this.PrintForward(ref node), this.PrintBackward(ref node)));
            
            this.PrintBackward(ref node);
            this.FindPair(node, 3);            
        }

        private void Insert_node_in_sorted_order_Click(object sender, EventArgs e)
        {
            DoubleLL node = null;
            node = this.InsertDoubleLLSortedOrder(node, 1);
            node = this.InsertDoubleLLSortedOrder(node, 4);
            node = this.InsertDoubleLLSortedOrder(node, 3);
            node = this.InsertDoubleLLSortedOrder(node, 2);

            MessageBox.Show(string.Format("Forward {0}", this.PrintBackward(ref node)));
            MessageBox.Show(string.Format("Backward {0}", this.PrintForward(ref node)));            


        }



        private void FindPair(DoubleLL node, int sum)
        {
            StringBuilder builder = new StringBuilder();
            DoubleLL first = node;
            DoubleLL second = node;
            /*
             1-->4-->3-->2
            */
            while (second!=null && second.Next!=null)
            {
                second = second.Next;
            }

            bool isPairExists = false;
            while (first!=null && second!=null && first!=second && second.Next != first)
            {
                if (first.Data + second.Data == sum)
                {
                    isPairExists = true;
                    builder.Append(string.Format("({0},{1}),", first.Data.ToString(), second.Data.ToString()));
                    first = first.Next;
                    second = second.Previous;
                }
                else if (first.Data + second.Data < sum)
                {
                    first = first.Next;
                }
                else
                {
                    second = second.Previous;
                }

            }
            
            if (isPairExists)
            {
                MessageBox.Show(builder.ToString().Substring(0, builder.ToString().Length - 1));
            }
            else
            {
                MessageBox.Show("No Pair exists");
            }

            
        }
            
        


        public DoubleLL InsertDoubleLL(DoubleLL node, int data)
        {         
            if (node== null)
            {
                node = new DoubleLL();
                node.Data = data;                
            }
            else
            {
                DoubleLL current = node;

                while (current.Next !=null)
                {
                    current = current.Next;
                }

                DoubleLL temp = new DoubleLL() { Data = data };
                current.Next = temp;
                temp.Previous = current;
            }
            return node;
        }

        public DoubleLL InsertDoubleLLWithChildFromArray(DoubleLL node, int?[] data)
        {
            return null;
        }


        public DoubleLL InsertDoubleLLSortedOrder(DoubleLL node , int data)
        {
            //1->4->3->2

            DoubleLL current = node== null? null :node.Next;
            DoubleLL previous = node;
            DoubleLL temp = null;

            if (node == null)
            {
                node = new DoubleLL();
                node.Data = data;
                return node;
            }
            if (current == null)
            {
                temp = new DoubleLL() { Data = data };                
                if (node.Data <= data)
                {
                    node.Next = temp;
                    temp.Previous = node;
                }
                else 
                {                    
                    temp.Next = node;
                    node.Previous = temp;
                    node = temp;
                }
            }

            temp = new DoubleLL() { Data = data };

            while (current!=null)
            {                
                if (previous.Data < data && current.Data >= data)
                {
                    
                    previous.Next = temp;
                    temp.Previous = previous;
                    temp.Next = current;
                    current.Previous = temp;
                    return node;

                }              
                previous = previous.Next;
                current = current.Next;             
            }
            previous.Next = temp;
            temp.Previous = previous;
            return node;
        }

        public string PrintForward(ref DoubleLL node)
        {
            StringBuilder builder = new StringBuilder();            
            while (node != null && node.Next!=null)
            {
                builder.Append(node.Data + ",");
                node = node.Next;
            }

            if (node!=null)
            {
                builder.Append(node.Data);
            }

            return builder.ToString().Substring(0, builder.ToString().Length);                
        }

        public string PrintBackward(ref DoubleLL node)
        {
            StringBuilder builder = new StringBuilder();
            while (node != null && node.Previous != null)
            {
                builder.Append(node.Data + ",");
                node = node.Previous;
            }

            if (node != null)
            {
                builder.Append(node.Data);
            }

            return builder.ToString().Substring(0, builder.ToString().Length);
        }

        private void Delete_node_Click(object sender, EventArgs e)
        {
            DoubleLL node = null;
            int deleteNode = 10;
            node = this.InsertDoubleLLSortedOrder(node, 1);
            node = this.InsertDoubleLLSortedOrder(node, 4);
            node = this.InsertDoubleLLSortedOrder(node, 3);
            node = this.InsertDoubleLLSortedOrder(node, 2);
            node = this.InsertDoubleLLSortedOrder(node, 5);
            node = this.InsertDoubleLLSortedOrder(node, 10);
            node = this.InsertDoubleLLSortedOrder(node, 9);
            node = this.InsertDoubleLLSortedOrder(node, 4);

            MessageBox.Show(string.Format("Before deleting Forward: {0} \nBackward: {1}", this.PrintForward(ref node), this.PrintBackward(ref node)));


            DoubleLL previous = node;
            DoubleLL current = node.Next;

            if (previous.Data == deleteNode )
            {
                node = node.Next;
                node.Previous = null;
                previous = node;
                current = node.Next;
            }

            while (current != null)
            {
                if (current.Data == deleteNode)
                {
                    if (current.Next != null)
                    {
                        current = current.Next;
                        current.Previous = previous;
                        previous.Next = current;
                    }
                    else
                    {
                        previous.Next = null;
                        current = null;
                        break;
                    }
                }

                current = current.Next;
                previous = previous.Next;
                

            }

            MessageBox.Show(string.Format("After deleting Forward: {0} \nBackward: {1}", this.PrintForward(ref node), this.PrintBackward(ref node)));


        }

        DoubleLL start;
        DoubleLL runner;
        private void btn_Convert_Binary_Tree_into_Double_Linked_List_Click(object sender, EventArgs e)
        {

            /*
             https://www.geeksforgeeks.org/convert-given-binary-tree-doubly-linked-list-set-3/
                                       10
                                    /      \
                                   /        \
                                  /          \
                                 /            \                           
                                /              \
                               5               20
                             /  \             / \
                            /    \           /   \  
                           /      \         /     \
                          3        8       15     22 
                         / \      / \ 
                        /   \    /   \
                       1    4    6    9
                        \
                         \
                          2

            1   2   3   4   5   6   8   9   10  15  20  22
         */

            Node root = null;
            InsertNodeIntoBSTTree(ref root, 10);
            InsertNodeIntoBSTTree(ref root, 5);
            InsertNodeIntoBSTTree(ref root, 20);
            InsertNodeIntoBSTTree(ref root, 3);
            InsertNodeIntoBSTTree(ref root, 8);
            InsertNodeIntoBSTTree(ref root, 15);
            InsertNodeIntoBSTTree(ref root, 22);
            InsertNodeIntoBSTTree(ref root, 1);
            InsertNodeIntoBSTTree(ref root, 4);
            InsertNodeIntoBSTTree(ref root, 6);
            InsertNodeIntoBSTTree(ref root, 9);
            InsertNodeIntoBSTTree(ref root, 2);
                        
            ConvertBSTToDoubleLinkedList(root);
            runner = start;            
            MessageBox.Show($"Forward :{ PrintForward(ref runner) } \nBackward :{PrintBackward(ref runner)}");
            start = null;
        }

        private void ConvertBSTToDoubleLinkedList(Node root)
        {
                /*
                https://www.geeksforgeeks.org/convert-given-binary-tree-doubly-linked-list-set-3/
                                          10
                                       /      \
                                      /        \
                                     /          \
                                    /            \                           
                                   /              \
                                  5               20
                                /  \             / \
                               /    \           /   \  
                              /      \         /     \
                             3        8       15     22 
                            / \      / \ 
                           /   \    /   \
                          1    4    6    9
                           \
                            \
                             2

               1   2   3   4   5   6   8   9   10  15  20  22
            */

            if (root  != null)
            {
                ConvertBSTToDoubleLinkedList(root.left);

                if (runner == null)
                {
                    runner = new DoubleLL() { Data = root.data};
                    start = runner;
                }
                else
                {
                    runner.Next = new DoubleLL { Data = root.data, Previous = runner};                    
                    runner = runner.Next;
                }
                
                ConvertBSTToDoubleLinkedList(root.right);
            }
        }

        private void InsertNodeIntoBSTTree(ref Node root, int data)
        {            
            if (root == null)
            {
                root = new Node() { data = data };
            }
            else if (root.data > data)
            {
                InsertNodeIntoBSTTree(ref root.left, data);
            }
            else if(root.data < data)
            {
                InsertNodeIntoBSTTree(ref root.right, data);
            }            
        }

        private void btn_Flatten_a_Multilevel_Doubly_Linked_List_Click(object sender, EventArgs e)
        {
            /*
                    You are given a doubly linked list which in addition to the next and previous pointers, it could have a child pointer, which may or may not point to a separate doubly linked list. 
                    These child lists may have one or more children of their own, and so on, to produce a multilevel data structure, as shown in the example below.

                    Flatten the list so that all the nodes appear in a single-level, doubly linked list. You are given the head of the first level of the list.

                    Example 1:

                    Input: head = [1,2,3,4,5,6,null,null,null,7,8,9,10,null,null,11,12]
                    Output: [1,2,3,7,8,11,12,9,10,4,5,6]
                    Explanation:

                    The multilevel linked list in the input is as follows:

                    After flattening the multilevel linked list it becomes:

                    Example 2:

                    Input: head = [1,2,null,3]
                    Output: [1,3,2]
                    Explanation:

                    The input multilevel linked list is as follows:

                      1---2---NULL
                      |
                      3---NULL
                    Example 3:

                    Input: head = []
                    Output: []
 

                    How multilevel linked list is represented in test case:

                    We use the multilevel linked list from Example 1 above:

                     1---2---3---4---5---6--NULL
                             |
                             7---8---9---10--NULL
                                 |
                                 11--12--NULL
                    The serialization of each level is as follows:

                    [1,2,3,4,5,6,null]
                    [7,8,9,10,null]
                    [11,12,null]
                    To serialize all levels together we will add nulls in each level to signify no node connects to the upper node of the previous level. The serialization becomes:

                    [1,2,3,4,5,6,null]
                    [null,null,7,8,9,10,null]
                    [null,11,12,null]
                    Merging the serialization of each level and removing trailing nulls we obtain:

                    [1,2,3,4,5,6,null,null,null,7,8,9,10,null,null,11,12]
 

                    Constraints:

                        Number of Nodes will not exceed 1000.
                        1 <= Node.val <= 10^5

                    Time Complexity     : O(N)
                    Space Complexity    : O(1)
            */

            //DoubleLL child2 = new DoubleLL() { Data = 11 };
            //child2.Next = new DoubleLL() { Data = 12, Previous = child2 };

            //DoubleLL child1 = new DoubleLL() { Data = 7 };
            //child1.Next = new DoubleLL() { Data = 8, Previous = child1, Child = child2 };
            //child1.Next.Next = new DoubleLL() { Data = 9, Previous = child1.Next };
            //child1.Next.Next.Next = new DoubleLL() { Data = 10, Previous = child1.Next.Next };

            //DoubleLL head = new DoubleLL() { Data = 1 };
            //head.Next = new DoubleLL() { Data = 2, Previous = head };
            //head.Next.Next = new DoubleLL() { Data = 3, Previous = head.Next, Child = child1 };
            //head.Next.Next.Next = new DoubleLL() { Data = 4, Previous = head.Next.Next };
            //head.Next.Next.Next.Next = new DoubleLL() { Data = 5, Previous = head.Next.Next.Next };
            //head.Next.Next.Next.Next.Next = new DoubleLL() { Data = 6, Previous = head.Next.Next.Next.Next };


            StringBuilder result = new StringBuilder();
            List<DoubleLL> inputs = new List<DoubleLL>();
            inputs.Add(this.InsertDoubleLLWithChildNodes(null ,new int?[] { 1, 2, 3, 4, 5, 6, null, null, null, 7, 8, 9, 10, null, null, 11, 12 }));


            
            foreach(DoubleLL input in inputs)
            {
                this.Flatten(input);
                DoubleLL temp = input;
                result.AppendLine($"Flatten a Multilevel Doubly Linked List for the given input double linked list is {this.PrintForward(ref temp)}");
            }

            MessageBox.Show(result.ToString());            

        }

        public DoubleLL Flatten(DoubleLL head)
        {
            this.FattenNode(head);
            return head;
        }

        private DoubleLL FattenNode(DoubleLL node)
        {
            //1, 2, 3, 4, 5, 6, null, null, null, 7, 8, 9, 10, null, null, 11, 12 
            if (node == null)
                return node;

            DoubleLL runner = node;

            while (runner != null)
            {
                if (runner.Child != null)
                {
                    DoubleLL endNode = FattenNode(runner.Child);
                    if (endNode != null)
                    { 
                        endNode.Next = runner.Next;
                        if (runner.Next != null)
                            runner.Next.Previous = endNode;
                        runner.Next.Previous = endNode;
                        DoubleLL child = runner.Child;
                        runner.Child = null;
                        runner.Next = child;
                        child.Previous = runner;
                    }
                }

                if (runner.Next == null)
                {
                    return runner;                    
                }
                runner = runner.Next;
            }

            return null;
        }


        public DoubleLL InsertDoubleLLWithChildNodes(DoubleLL node, int?[] datas)
        {

            //[1,2,3,4,5,6,null,null,null,7,8,9,10,null,null,11,12]
            int nullCounter = 0;
            for (int i = 0; i < datas.Length; i++)
            {
                if (datas[i].HasValue)
                {
                    if (nullCounter > 0)
                    {

                        DoubleLL temp = node;
                        while (nullCounter > 1 && temp.Next != null)
                        {
                            temp = temp.Next;
                            nullCounter--;
                        }

                        int?[] subArray = new int?[datas.Length - i];
                        Array.Copy(datas, i, subArray, 0, datas.Length - i);

                        temp.Child = InsertDoubleLLWithChildNodes(temp.Child, subArray);
                        break;
                    }
                    else
                        node = this.InsertDoubleLL(node, datas[i].Value);
                }
                else
                {
                    nullCounter++;
                }
            }

            return node;
        }
    }
}
