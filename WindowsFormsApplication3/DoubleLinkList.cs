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
            node = this.InsertDoubleLL(node, 2);
            node = this.InsertDoubleLL(node, 3);
            node = this.InsertDoubleLL(node, 4);

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

        public DoubleLL InsertDoubleLLSortedOrder(DoubleLL node , int data)
        {
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
                else if (node.Data > data)
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
                    }
                }                
                else
                {
                    current = current.Next;
                    previous = previous.Next;
                }

            }

            MessageBox.Show(string.Format("After deleting Forward: {0} \nBackward: {1}", this.PrintForward(ref node), this.PrintBackward(ref node)));


        }

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

            DoubleLL dDLinkedList = null;
            DoubleLL tempPointer = null;
            DoubleLL previousPointer = null;
            ConvertBSTToDoubleLinkedList(ref previousPointer, root, ref tempPointer, ref dDLinkedList);
            MessageBox.Show($"Forward :{ PrintForward(ref dDLinkedList) } \nBackward :{PrintBackward(ref dDLinkedList)}");            
        }

        private void ConvertBSTToDoubleLinkedList(ref DoubleLL previous, Node root,ref DoubleLL tempPointer,  ref DoubleLL doubleLinkedList)
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
                ConvertBSTToDoubleLinkedList(ref previous, root.left, ref tempPointer, ref doubleLinkedList);

                if (tempPointer == null)
                {
                    tempPointer = new DoubleLL() { Data = root.data};
                    doubleLinkedList = tempPointer;
                }
                else
                {
                    tempPointer.Next = new DoubleLL { Data = root.data};
                    tempPointer.Next.Previous = previous;
                    tempPointer = tempPointer.Next;
                }

                previous = tempPointer;

                ConvertBSTToDoubleLinkedList(ref previous, root.right, ref tempPointer, ref  doubleLinkedList);

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
    }


}
