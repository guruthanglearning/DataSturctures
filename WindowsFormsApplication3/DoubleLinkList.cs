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
            MessageBox.Show(string.Format("Forward {0}", this.PrintForward(ref node)));            


        }



        private void FindPair(DoubleLL node, int sum)
        {
            StringBuilder builder = new StringBuilder();
            DoubleLL first = node;
            DoubleLL second = node;

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
            
        

        public class DoubleLL
        {
            public int Data;
            public DoubleLL Next;
            public DoubleLL Previous;
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
    }

    
}
