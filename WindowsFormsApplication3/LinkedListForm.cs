﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Web.UI.WebControls;
using System.Runtime.Remoting.Messaging;
using static WindowsFormsApplication3.Arrays;

//using OfficeOpenXml;
//using OfficeOpenXml.Style;
//using OfficeOpenXml.Table.PivotTable;

namespace WindowsFormsApplication3
{

    public partial class LinkedListForm : Form
    {
        static int TWO_NODES_FOUND = 2;
        static int ONE_NODES_FOUND = 1;
        static int NO_NODES_FOUND = 0;

        StringBuilder datas = new StringBuilder();
        static int visited = 0;
        LinkList linkListNode = null;

        public LinkedListForm()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            /*
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
         */

            Node tree = null;
            /*Insert(10, ref tree);
            Insert(5, ref tree);
            Insert(20, ref tree);
            Insert(3, ref tree);
            Insert(8, ref tree);
            Insert(6, ref tree);
            Insert(15, ref tree);
            Insert(22, ref tree);
            Insert(1, ref tree);
            Insert(2, ref tree);
            Insert(4, ref tree);
            Insert(9, ref tree);*/

            InsertNoRecurrssion(new int[] { 10, 5, 20, 3, 8, 6, 15, 22, 1, 2, 4, 9 }, ref tree);

            datas.Clear();
            datas.Append("\r\n InOrder Traversal :");
            //Inorder traversal without recursion 
            //https://www.geeksforgeeks.org/inorder-tree-traversal-without-recursion/
            InOrder(tree);
            datas.Append("\r\n PreOrder Traversal :");
            PreOrder(tree);
            datas.Append("\r\n PostOrder Traversal :");
            PostORder(tree);
            datas.Append("\r\n BFS Traversal :");
            BFT(tree);
            MessageBox.Show(datas.ToString());

        }


        private void InsertNoRecurrssion(int[] input, ref Node tree)
        {
            if (input.Length == 0)
            {
                return;
            }

            if (tree == null)
            {
                tree = new Node() { data = input[0] };
            }

            Node temp = tree;
            for (int i = 1; i < input.Length; i++)
            {

                while (true)
                {

                    if (temp.data > input[i])
                    {
                        if (temp.left != null)
                        {
                            temp = temp.left;
                        }
                        else
                        {
                            temp.left = new Node() { data = input[i] };
                            break;
                        }
                    }
                    else
                    {

                        if (temp.right != null)
                        {
                            temp = temp.right;
                        }
                        else
                        {
                            temp.right = new Node() { data = input[i] };
                            break;
                        }
                    }
                }
                temp = tree;
            }

        }


        private Node Insert(int data, ref Node tree)
        {
            if (tree == null)
            {
                tree = new Node();
                tree.data = data;
            }
            else
            {
                if (data > tree.data)
                {
                    Insert(data, ref tree.right);
                }
                else if (data < tree.data)
                {
                    Insert(data, ref tree.left);
                }
            }

            return tree;
        }

        private Node InsertTreeNodeImproperly(int data, ref Node tree)
        {
            if (tree == null)
            {
                tree = new Node();
                tree.data = data;
            }
            else
            {
                if (data < tree.data)
                {
                    InsertTreeNodeImproperly(data, ref tree.right);
                }
                else if (data > tree.data)
                {
                    InsertTreeNodeImproperly(data, ref tree.left);
                }
            }

            return tree;
        }




        private NodeWithNext InsertNodeWithNext(int data, ref NodeWithNext tree)
        {
            if (tree == null)
            {
                tree = new NodeWithNext();
                tree.data = data;
            }
            else
            {
                if (data > tree.data)
                {
                    InsertNodeWithNext(data, ref tree.right);
                }
                else if (data < tree.data)
                {
                    InsertNodeWithNext(data, ref tree.left);
                }
            }

            return tree;
        }

        private void InsertBFSNode(int data, ref BFSNode tree, BFSNode parent)
        {
            if (tree == null)
            {
                tree = new BFSNode();
                tree.data = data;
                tree.parent = parent;
            }
            else
            {
                if (data > tree.data)
                {
                    InsertBFSNode(data, ref tree.right, tree);
                }
                else if (data < tree.data)
                {
                    InsertBFSNode(data, ref tree.left, tree);
                }
            }
        }


        private void InOrder(Node node)
        {
            if (node != null)
            {
                InOrder(node.left);
                datas.Append(node.data.ToString() + ",");
                InOrder(node.right);
            }
        }


        private string InOrderTravelUsingStack(Node root)
        {

            if (root == null)
            {
                return null;
            }


            StringBuilder result = new StringBuilder();
            Stack<Node> s = new Stack<Node>();
            Node current = root;

            while (current != null || s.Count > 0)
            {

                while (current != null)
                {
                    s.Push(current);
                    current = current.left;
                }

                current = s.Pop();
                result.Append($@" {current.data} ,");
                current = current.right;
            }

            return result.ToString();
        }

        private void PreOrder(Node node)
        {
            if (node != null)
            {
                datas.Append(node.data.ToString() + ",");
                PreOrder(node.left);
                PreOrder(node.right);
            }
        }

        private void PostORder(Node node)
        {
            if (node != null)
            {
                PostORder(node.left);
                PostORder(node.right);
                datas.Append(node.data.ToString() + ",");
            }
        }

        private void BFT(Node node)
        {

            Queue<Node> queue = new Queue<Node>();
            Node currentNode = null;
            datas.Append(node.data.ToString() + ",");
            queue.Enqueue(node);
            //queue.Enqueue(null);

            while (true)
            {
                if (queue.Count == 0)
                {
                    break;
                }

                currentNode = queue.Dequeue() as Node;

                //This condition needed as queue will never be empty as we are always adding one element in the queue.      
                if (currentNode == null) break;

                if (currentNode != null)
                {

                    if (currentNode.left != null)
                    {
                        datas.Append(currentNode.left.data.ToString() + ",");
                        queue.Enqueue(currentNode.left);
                    }
                    if (currentNode.right != null)
                    {
                        datas.Append(currentNode.right.data.ToString() + ",");
                        queue.Enqueue(currentNode.right);
                    }
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //int[] input = new Int32[11] { -1, 10, -2, 9, -3, 8, 0, -4, 7, -5, 6 };
            //int[] input = new Int32[11] { 1, 2, 3, 4, 5, 0, -1, -2, -3, -4, 5 };
            //int[] input = new Int32[11] { -1, -2, -3, -4, -1, -0, -1, -2, -3, -4, -5 };
            //int[] input = new Int32[11] { 1, 2, 3, 4, 1, 0, 1, 2, 3, 4, 5 };
            //int[] input = new Int32[11] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            //int[] input = new Int32[11] { -1, 10, 0, -2, 9, -3, 8, -4, 7, -5, 6 };
            //Capturing inputs
            string[] result = textBox1.Text.Split(',');
            int[] input = new Int32[result.Length];
            int t;
            for (int k = 0; k < result.Length; k++)
            {
                if (int.TryParse(result[k], out t))
                {
                    input[k] = t;
                }
            }
            //int[] input = new Int32[11] { -1, 10, 0, -2, 9, -3, 8, -4, 0, -5, 6 };
            int up = input.Length - 1;
            int down = 0;

            while (down < up)
            {
                t = 0;
                if (input[down] >= 0 && input[up] <= 0)
                {
                    t = input[down];
                    input[down] = input[up];
                    input[up] = t;
                    down++;
                    up--;
                }
                else if (input[down] >= 0 && input[up] >= 0)
                {
                    up--;
                }
                else
                {
                    down++;
                }
            }

            StringBuilder data = new StringBuilder();
            for (int j = 0; j < input.Length; j++)
            {
                data.Append(input[j] + ",");
            }
            MessageBox.Show(data.ToString());

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //int[] input = new Int32[11] { -1, 10, -2, 9, -3, 8, 0, -4, 7, -5, 6 };
            //int[] input = new Int32[11] { 1, 2, 3, 4, 5, 0, -1, -2, -3, -4, 5 };
            //int[] input = new Int32[11] { -1, -2, -3, -4, -1, -0, -1, -2, -3, -4, -5 };
            //int[] input = new Int32[11] { 1, 2, 3, 4, 1, 0, 1, 2, 3, 4, 5 };
            //int[] input = new Int32[11] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            //int[] input = new Int32[11] { -1, 10, 0, -2, 9, -3, 8, -4, 7, -5, 6 };
            //int[] input = new Int32[11] { -1, 10, 0, -2, 9, -3, 8, -4, 0, -5, 6 };
            //int[] input = new Int32[11] { -0, 10, 0, -2, 9, -3, 8, -4, 0, -5, 6 };
            //int[] input = new Int32[11] { 0, 10, 0, -2, 9, -3, 8, -4, 0, -5, 6 };

            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Inputs required");
            }
            else
            {
                //Capturing inputs
                string[] result = textBox1.Text.Split(',');
                int t;
                int[] input = new Int32[result.Length];
                for (int k = 0; k < result.Length; k++)
                {
                    if (int.TryParse(result[k], out t))
                    {
                        input[k] = t;
                    }
                }

                //Logic to arrange –ve and +ve to left and write of zero respectively
                t = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    for (int j = i + 1; j < input.Length; j++)
                    {
                        if (input[i] >= 0 && input[j] <= 0)
                        {
                            t = input[i];
                            input[i] = input[j];
                            input[j] = t;
                        }
                    }
                }

                //Displays the output
                StringBuilder data = new StringBuilder();
                for (int j = 0; j < input.Length; j++)
                {
                    data.Append(input[j] + ",");
                }
                MessageBox.Show(data.ToString());
            }
        }

        private BFSNode newNode(int data)
        {
            BFSNode node = new BFSNode();
            node.data = data;
            node.left = null;
            node.right = null;
            node.parent = null;
            return (node);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            LinkList LLNodeFirst = null;
            LLNodeFirst = InsertLinkList(LLNodeFirst, 1);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 3);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 5);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 7);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 9);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 11);
            DisplayLinkList(LLNodeFirst);
            datas.Append("\n");

            /*
             1->3->5->7->9->11
             1->2->4->6->8->10->12
            */

            LinkList LLNodeSecond = null;
            LLNodeSecond = InsertLinkList(LLNodeSecond, 1);
            LLNodeSecond = InsertLinkList(LLNodeSecond, 2);
            LLNodeSecond = InsertLinkList(LLNodeSecond, 4);
            LLNodeSecond = InsertLinkList(LLNodeSecond, 6);
            LLNodeSecond = InsertLinkList(LLNodeSecond, 8);
            LLNodeSecond = InsertLinkList(LLNodeSecond, 10);
            LLNodeSecond = InsertLinkList(LLNodeSecond, 12);

            DisplayLinkList(LLNodeSecond);
            datas.Append("\n");


            DisplayLinkList(Merge(LLNodeSecond, LLNodeFirst));
            MessageBox.Show(datas.ToString());
        }

        private LinkList InsertLinkList(LinkList LLNode, int data)
        {
            if (LLNode == null)
            {
                LLNode = new LinkList();
                LLNode.data = data;
                LLNode.next = null;

            }
            else
            {
                LLNode.next = InsertLinkList(LLNode.next, data);
            }
            return LLNode;
        }

        private LinkListCharacter InsertLinkListForCharacter(LinkListCharacter node, char data)
        {
            if (node == null)
            {
                node = new LinkListCharacter();
                node.data = data;
                node.next = null;
            }
            else
            {
                node.next = InsertLinkListForCharacter(node.next, data);
            }
            return node;
        }

        private void DisplayLinkList(LinkList Node)
        {
            if (Node != null)
            {
                datas.Append(Node.data.ToString() + ",");
                DisplayLinkList(Node.next);
            }
        }

        private string GetLinkListData(LinkList linkList)
        {
            StringBuilder result = new StringBuilder();
            while (linkList != null)
            {
                result.Append($" {linkList.data} ");
                linkList = linkList.next;
            }

            return result.ToString();
        }



        private LinkList Merge(LinkList first, LinkList second)
        {
            /*
             1->3->5->7->9->11
             1->2->4->6->8->10->12
            */

            LinkList p = first;
            LinkList q = second;
            LinkList previous = new LinkList();
            LinkList returnList = previous;

            while (p != null && q != null)
            {
                if (p.data == q.data)
                {
                    previous.next = p;
                    p = p.next;
                    q = q.next;
                }
                else if (p.data < q.data)
                {
                    previous.next = p;
                    p = p.next;
                }
                else
                {
                    previous.next = q;
                    q = q.next;
                }
                previous = previous.next;
            }

            while (p != null)
            {
                previous.next = p;
                p = p.next;
                previous = previous.next;
            }

            while (q != null)
            {
                previous.next = q;
                q = q.next;
                previous = previous.next;
            }

            return returnList.next;

        }

        private void button6_Click(object sender, EventArgs e)
        {

            LinkList LLNodeFirst = null;
            LLNodeFirst = InsertLinkList(LLNodeFirst, 4);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 4);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 5);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 1);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 0);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 11);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 1);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 1);
            datas.Clear();
            DisplayLinkList(LLNodeFirst);
            MessageBox.Show(datas.ToString());

            LinkList current, previous, next_next;
            datas.Clear();

            //current = LLNodeFirst;
            //4->4->5->1->0->11->1->2
            //current = LLNodeFirst;
            //// Delete duplicate node from a sorted linked list
            ///* Traverse list till the last node */
            //while (current.next != null)
            //{
            //    /*Compare current node with the next node */
            //    if (current.data == current.next.data)
            //    {
            //        next_next = current.next.next;
            //        current.next = null;
            //        current.next = next_next;
            //    }
            //    else
            //        // advance if no deletion               
            //        current = current.next;
            //}

            //datas.Append("\n\n Time Complexity: O(n)");
            //DisplayLinkList(LLNodeFirst);
            //MessageBox.Show(datas.ToString());

            //4->4->5->1->0->11->1->2
            //Complexity is O(n^2)
            //datas.Clear();
            //previous = LLNodeFirst;
            //current = previous.next;
            //while (current != null)
            //{
            //    LinkList runner = LLNodeFirst;
            //    while (runner != current)
            //    {
            //        if (runner.data == current.data)
            //        {
            //            LinkList temp = current.next;
            //            previous.next = temp;
            //            current = temp;
            //            break;
            //        }
            //        runner = runner.next;
            //    }

            //    if (current == runner)
            //    {
            //        previous = current;
            //        current = current.next;
            //    }
            //}

            //Removing duplicate from unsorted array
            List<int> visited = new List<int>();
            visited.Add(LLNodeFirst.data);
            previous = LLNodeFirst;
            current = previous.next;
            while (current != null)
            {
                if (visited.Contains(current.data))
                {
                    previous.next = current.next;
                }
                else
                {
                    visited.Add(current.data);
                    previous = previous.next;
                }
                current = current.next;
            }


            datas.Append("\n\n Time Complexity: O(n) Space Complexity : O(n)\n ");
            DisplayLinkList(LLNodeFirst);
            MessageBox.Show(datas.ToString());





        }

        private void button7_Click(object sender, EventArgs e)
        {
            datas.Clear();
            LinkList LLNodeFirst = null;

            /*
             1->3->5->7->9->11
             1->1->6->8->10->12
            */
            LLNodeFirst = InsertLinkList(LLNodeFirst, 1);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 3);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 5);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 7);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 9);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 11);
            DisplayLinkList(LLNodeFirst);
            datas.Append("\n\n");

            LinkList LLNodeSecond = null;
            LLNodeSecond = InsertLinkList(LLNodeSecond, 1);
            LLNodeSecond = InsertLinkList(LLNodeSecond, 1);
            LLNodeSecond = InsertLinkList(LLNodeSecond, 6);
            LLNodeSecond = InsertLinkList(LLNodeSecond, 8);
            LLNodeSecond = InsertLinkList(LLNodeSecond, 10);
            LLNodeSecond = InsertLinkList(LLNodeSecond, 12);

            DisplayLinkList(LLNodeSecond);

            datas.Append("\n\n");

            LinkList LLNode = AddLinkList(LLNodeFirst, LLNodeSecond, 0);

            DisplayLinkList(LLNode);
            MessageBox.Show(datas.ToString());

        }

        private LinkList AddLinkList(LinkList l1, LinkList l2, int carry)
        {
            /*
             1->3->5->7->9->11
             1->1->6->8->10->12
            */

            if (l1 == null && l2 == null && carry == 0)
                return null;

            LinkList result = new LinkList();
            if (l1 == null && l2 == null && carry > 0)
            {
                result.data = carry;
                return result;
            }

            int value = carry;

            if (l1 != null)
                value += l1.data;

            if (l2 != null)
                value += l2.data;

            //Mod reminder / quocent
            result.data = value % 10;

            LinkList more = AddLinkList(11 == null ? null : l1.next,
                                        l2 == null ? null : l2.next,
                                        value > 10 ? value / 10 : 0);
            result.next = more;

            return result;


        }

        private void button8_Click(object sender, EventArgs e)
        {
            /*
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
        */
            Node tree = null;
            Insert(10, ref tree);
            Insert(5, ref tree);
            Insert(20, ref tree);
            Insert(3, ref tree);
            Insert(8, ref tree);
            Insert(15, ref tree);
            Insert(22, ref tree);
            Insert(1, ref tree);
            Insert(2, ref tree);
            //Insert(15, ref tree);
            //Insert(22, ref tree);
            string max = $"Max Depth Recursive = {MaxDepthOfTheTree(tree)} Max Depth Iterative = {MaxDepthOfTheTreeWithIterative(tree)}";
            string min = $"Min Depth Recursive = {MinDepthOfTheTree(tree)} Min Depth Iterative = {MinDepthOfTheTreeIterative(tree)}";
            MessageBox.Show($"{max}\n {min}");
        }

        private int MaxDepthOfTheTree(Node node)
        {
            /*
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
            */

            if (node == null)
            {
                return 0;
            }
            return 1 + Math.Max(MaxDepthOfTheTree(node.left), MaxDepthOfTheTree(node.right));

        }

        private int MaxDepthOfTheTreeWithIterative(Node node)
        {
            /*
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
                 
            Iterative approach */
            if (node == null)
            {
                return 0;
            }

            Queue<Node> q = new Queue<Node>();
            q.Enqueue(node);
            q.Enqueue(null);

            int counter = 0;

            Node t = null;

            while (q.Peek() != null)
            {
                while (q.Peek() != null)
                {
                    t = q.Dequeue();
                    if (t.left != null)
                    {
                        q.Enqueue(t.left);
                    }

                    if (t.right != null)
                    {
                        q.Enqueue(t.right);
                    }
                }
                q.Dequeue();
                q.Enqueue(null);

                counter++;
            }

            return counter;

        }

        private int MinDepthOfTheTreeIterative(Node node)
        {
            /*
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
        */

            Node temp;
            Queue<Node> q = new Queue<Node>();

            int min = 0;

            q.Enqueue(node);
            q.Enqueue(null);


            while (q.Count > 0)
            {
                temp = q.Dequeue();

                if (temp == null)
                {
                    if (q.Count == 0)
                    {
                        break;
                    }

                    min++;
                    q.Enqueue(null);
                }
                else
                {
                    if (temp.left != null)
                    {
                        q.Enqueue(temp.left);
                    }

                    if (temp.right != null)
                    {
                        q.Enqueue(temp.right);
                    }

                    if (temp.left == null && temp.right == null)
                    {
                        min++;
                        break;
                    }
                }
            }

            return min;

        }

        private int MinDepthOfTheTree(Node node)
        {

            /*
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
              */

            if (node == null)
            {
                return 0;
            }

            return 1 + Math.Min(MinDepthOfTheTree(node.left), MinDepthOfTheTree(node.right));

        }

        private void InOrderTraversalToLinkList(Node node, ref LinkList runner, ref LinkList start)
        {

            /*
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
            */

            if (node != null)
            {
                InOrderTraversalToLinkList(node.left, ref runner, ref start);
                if (runner == null)
                {
                    runner = new LinkList() { data = node.data };
                    if (start == null)
                    {
                        start = runner;
                    }
                }
                else
                {
                    runner.next = new LinkList() { data = node.data };
                    runner = runner.next;
                }
                InOrderTraversalToLinkList(node.right, ref runner, ref start);
            }
        }


        private void button9_Click(object sender, EventArgs e)
        {
            Node tree = null;
            Insert(10, ref tree);
            Insert(5, ref tree);
            Insert(20, ref tree);
            Insert(3, ref tree);
            Insert(8, ref tree);
            Insert(15, ref tree);
            Insert(22, ref tree);
            LinkList start = null;
            LinkList runner = null;
            if (tree != null)
            {
                this.InOrderTraversalToLinkList(tree, ref runner, ref start);
            }

            runner = start;
            StringBuilder message = new StringBuilder();
            while (runner != null)
            {
                message.Append($"{runner.data.ToString()} ,");
                runner = runner.next;
            }
            MessageBox.Show($"Tree to list is {message.ToString()}");


        }

        private void button10_Click(object sender, EventArgs e)
        {
            /*
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

            The Algorithm is divided into two cases on the basis of right subtree of the input node being empty or not.

            Input: node, root // node is the node whose Inorder successor is needed.
            output: succ // succ is Inorder successor of node.

            1) If right subtree of node is not NULL, then succ lies in right subtree. Do following.
            Go to right subtree and return the node with minimum key value in right subtree.
            2) If right sbtree of node is NULL, then succ is one of the ancestors. Do following.
            Travel up using the parent pointer until you see a node which is left child of it’s parent. The parent of such a node is the succ.

         */


            //http://www.geeksforgeeks.org/inorder-successor-in-binary-search-tree/
            // Time Complexity: O(h) where h is height of tree.
            BFSNode tree = null;
            InsertBFSNode(10, ref tree, tree);
            InsertBFSNode(5, ref tree, tree);
            InsertBFSNode(20, ref tree, tree);
            InsertBFSNode(3, ref tree, tree);
            InsertBFSNode(8, ref tree, tree);
            InsertBFSNode(15, ref tree, tree);
            InsertBFSNode(22, ref tree, tree);
            InsertBFSNode(6, ref tree, tree);
            InsertBFSNode(4, ref tree, tree);
            InsertBFSNode(9, ref tree, tree);
            InsertBFSNode(2, ref tree, tree);
            InsertBFSNode(1, ref tree, tree);
            //InsertBFSNode(24, ref tree, tree);

            BFSNode inputNode = tree.right;
            BFSNode node = GetInOrderSuccessorWithParentNode(inputNode);
            MessageBox.Show($"With Parent Node {node.data.ToString()}");
            node = GetInOrderSuccessorWithoutParentNode(inputNode, tree);
            MessageBox.Show($"Without Parent Node {node.data.ToString()}");

            //BFSNode tree1 = null;
            //InsertBFSNode(50, ref tree1, tree1);
            //InsertBFSNode(55, ref tree1, tree1);
            //InsertBFSNode(40, ref tree1, tree1);
            //InsertBFSNode(30, ref tree1, tree1);
            //InsertBFSNode(20, ref tree1, tree1);            
            //InsertBFSNode(10, ref tree1, tree1);
            //InsertBFSNode(8, ref tree1, tree1);
            //InsertBFSNode(5, ref tree1, tree1);
            //InsertBFSNode(4, ref tree1, tree1);

            //node = GetInOrderSuccessor(tree1);
            //if (node != null)
            //{
            //    MessageBox.Show(node.data.ToString());
            //}
        }

        private BFSNode GetInOrderSuccessorWithParentNode(BFSNode node)
        {
            /*
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
            */

            BFSNode p = null;
            if (node != null)
            {
                if (node.right != null)
                {
                    p = LeftMostChild(node.right);
                }
                else
                {
                    //right side traversal
                    p = node.parent;
                    while (p != null && p.right == node)
                    {
                        node = p;
                        if (p.parent == null)
                        {
                            break;
                        }

                        p = p.parent;
                    }

                    //left side traversal

                    while ((p = node.parent) != null)
                    {
                        if (p.left == node)
                        {
                            break;
                        }
                        node = p;

                    }
                }
            }
            return p;
        }


        private BFSNode GetInOrderSuccessorWithoutParentNode(BFSNode node, BFSNode root)
        {
            
            /*
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
            */

            BFSNode p = null;
            if (node != null)
            {
                if (node.right != null)
                {
                    p = LeftMostChild(node.right);
                }
                else
                {
                    BFSNode succ = null;
                    while (root != null)
                    {
                        if (node.data < root.data)
                        {
                            succ = root;
                            root = root.left;
                        }
                        else if (node.data > root.data)
                        {
                           
                            root = root.right;
                        }
                        else
                        {
                            p = succ;
                            break;
                        }
                    }
                }
            }
            return p;
        }
        private BFSNode LeftMostChild(BFSNode node)
        {
            if (node == null)
                return null;

            while (node.left != null)
            {
                node = node.left;
            }
            return node;


        }

        private void button11_Click(object sender, EventArgs e)
        {

            /*
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
            */

            Node tree = null;
            Insert(10, ref tree);
            Insert(5, ref tree);
            Insert(20, ref tree);
            Insert(3, ref tree);
            Insert(8, ref tree);
            Insert(15, ref tree);
            Insert(22, ref tree);
            Insert(2, ref tree);
            Insert(4, ref tree);
            Insert(6, ref tree);
            Insert(9, ref tree);
            Insert(1, ref tree);
            //Node node = CommonAncestor(tree, tree.left.left.left, tree.left.right);
            Node node = CommonAncestorSimple(tree, tree.left.left.left, tree.right.left);
            MessageBox.Show(node.data.ToString());

        }


        private Node CommonAncestorSimple(Node root, Node p, Node q)
        {
            Node parent = root;
            while (parent != null)
            {
                if (parent.data > p.data && parent.data > q.data)
                {
                    parent = parent.left;
                }
                else if (parent.data < p.data && parent.data < q.data)
                {
                    parent = parent.right;
                }
                else
                {
                    break;
                }

            }
            return parent;
        }

        private Node CommonAncestor(Node root, Node p, Node q)
        {
            if (q == p && (root.left == q || root.right == q))
            {
                return root;
            }

            int nodesFromLeft = covers(root.left, p, q);
            if (nodesFromLeft == TWO_NODES_FOUND || p == q)
            {
                if (root.left == p || root.left == q)
                    return root.left;
                else
                    return CommonAncestor(root.left, p, q);
            }
            else if (nodesFromLeft == ONE_NODES_FOUND)
            {
                if (root == p)
                    return p;
                else if (root == q)
                    return q;
            }

            int nodesFromRight = covers(root.right, p, q);
            if (nodesFromRight == TWO_NODES_FOUND || p == q)
            {
                if (root.right == p || root.right == q)
                    return root.right;
                else
                    return CommonAncestor(root.right, p, q);
            }
            else if (nodesFromRight == ONE_NODES_FOUND)
            {
                if (root == p)
                    return p;
                else if (root == q) return q;
            }

            if (nodesFromLeft == ONE_NODES_FOUND && nodesFromRight == ONE_NODES_FOUND)
                return root;
            else
                return null;

        }

        private int covers(Node root, Node p, Node q)
        {
            int ret = NO_NODES_FOUND;
            if (root == null) return ret;
            if (root == p || root == q)
            {
                ret += 1;
            }
            ret += covers(root.left, p, q);
            if (ret == TWO_NODES_FOUND)
                return ret;
            return ret + covers(root.right, p, q);

        }

        private void button12_Click(object sender, EventArgs e)
        {
            Node tree = null;
            Insert(10, ref tree);
            Insert(5, ref tree);
            Insert(20, ref tree);
            Insert(3, ref tree);
            Insert(8, ref tree);
            Insert(15, ref tree);
            Insert(22, ref tree);
            treeToList(tree);
            printTree(tree);


        }


        private Node treeToList(Node root)
        {

            /*
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
            */

            // base case: empty tree -> empty list
            if (root == null) return (null);

            // Recursively do the subtrees (leap of faith!)
            Node aList = treeToList(root.left);
            Node bList = treeToList(root.right);

            // Make the single root node into a list length-1
            // in preparation for the appending
            //root.left = root;
            //root.right = root;

            // At this point we have three lists, and it's
            // just a matter of appending them together
            // in the right order (aList, root, bList)
            aList = append(aList, root);// 3 , 5
            aList = append(aList, bList);

            return (aList);
        }

        private Node append(Node a, Node b)
        {
            // if either is null, return the other
            if (a == null) return (b);
            if (b == null) return (a);

            // find the last node in each using the .previous pointer
            Node aLast = a.left; // null
            Node bLast = b.right; // 8

            // join the two together to make it connected and circular
            join(aLast, b); //null, 5
            join(bLast, a); // 8, 3

            return (a);
        }

        private void join(Node a, Node b)
        {
            if (a != null)
            {
                a.right = b;
            }
            if (b != null)
            {
                b.left = a;
            }
        }


        private void printTree(Node root)
        {
            if (root == null) return;
            printTree(root.left);
            datas.Append(root.data.ToString() + ",");
            printTree(root.right);
        }

        private void LinkedListForm_Load(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            LinkList LLNodeFirst = null;
            LLNodeFirst = InsertLinkList(LLNodeFirst, 4);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 3);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 5);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 1);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 0);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 11);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 2);
            DisplayLinkList(LLNodeFirst);
            datas.Append("\n");


            LinkList node = null;

            while (LLNodeFirst != null)
            {
                LinkList temp = LLNodeFirst.next;
                LLNodeFirst.next = node;
                node = LLNodeFirst;
                LLNodeFirst = temp;
            }

            DisplayLinkList(node);
            datas.Append("\n");
            MessageBox.Show(datas.ToString());


        }

        private void button14_Click(object sender, EventArgs e)
        {
            /*
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
            */

            Node tree = null;
            Insert(10, ref tree);
            Insert(5, ref tree);
            Insert(20, ref tree);
            Insert(3, ref tree);
            Insert(8, ref tree);
            Insert(15, ref tree);
            Insert(22, ref tree);
            datas.Clear();
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(tree);
            while (q.Count > 0)
            {
                Node n = q.Dequeue();
                datas.Append(n.data + ",");
                if (n.left != null)
                    q.Enqueue(n.left);
                if (n.right != null)
                    q.Enqueue(n.right);
            }

            MessageBox.Show(datas.ToString());
        }

        private void button15_Click(object sender, EventArgs e)
        {

        }


        private void button17_Click(object sender, EventArgs e)
        {

            //Time complexity is O(n) since finding min from Linklist has to be travesal once and removing is another traversal
            //1->5->4->10->110->112->3->123->24->3
            LinkList linkList = null;
            linkList = InsertLinkList(linkList, 1);
            linkList = InsertLinkList(linkList, 5);
            linkList = InsertLinkList(linkList, 4);
            linkList = InsertLinkList(linkList, 10);
            linkList = InsertLinkList(linkList, 110);
            linkList = InsertLinkList(linkList, 112);
            linkList = InsertLinkList(linkList, 3);
            linkList = InsertLinkList(linkList, 123);
            linkList = InsertLinkList(linkList, 24);
            linkList = InsertLinkList(linkList, 3);

            datas.Clear();
            DisplayLinkList(linkList);
            MessageBox.Show(datas.ToString());

            LinkList r = linkList;
            LinkList p = linkList;
            LinkList m = linkList;
            //1->5->4->10->110->112->3->123->24->3
            //5->3->10->110->112->3->123->24->3

            //Finds min node
            while (r.next != null)
            {
                if (r.next.data < m.data)
                {
                    m = r.next;
                    p = r;
                }
                r = r.next;
            }


            if (p == m) // -->This will ensure min value is present at the starting of the node
            {
                linkList = m.next;
            }
            else
            {
                p.next = m.next;
                r = p.next;

                while (r != null)
                {
                    if (r.data == m.data)
                    {
                        p.next = r.next;
                    }
                    else
                    {
                        p = r;
                    }
                    r = r.next;
                }

            }

            datas.Append("\n\n");
            DisplayLinkList(linkList);
            MessageBox.Show(datas.ToString());


        }



        private void button19_Click(object sender, EventArgs e)
        {
            LinkList LLNodeFirst = null;
            LLNodeFirst = insertInOrder(LLNodeFirst, new LinkList() { data = 1, next = null });
            LLNodeFirst = insertInOrder(LLNodeFirst, new LinkList() { data = 3, next = null });
            LLNodeFirst = insertInOrder(LLNodeFirst, new LinkList() { data = 2, next = null });
            LLNodeFirst = insertInOrder(LLNodeFirst, new LinkList() { data = 4, next = null });
            LLNodeFirst = insertInOrder(LLNodeFirst, new LinkList() { data = 5, next = null });
            DisplayLinkList(LLNodeFirst);
            datas.Append("\n");
            MessageBox.Show(datas.ToString());
        }

        public LinkList insertInOrder(LinkList head, LinkList insert)
        {
            if (head == null)
            {
                return head = insert;

            }

            LinkList previous = head;
            LinkList current = head.next;

            if (current == null)
            {
                if (previous.data < insert.data)
                {
                    previous.next = insert;
                    insert.next = null;
                    return head;
                }
                else
                {
                    insert.next = previous;
                    return insert;
                }
            }

            while (current != null)
            {
                if (previous.data < insert.data && current.data >= insert.data)
                {
                    previous.next = insert;
                    insert.next = current;
                    return head;
                }
                current = current.next;
                previous = previous.next;
            }

            previous.next = insert;

            return head;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            int nthElement = 3;

            LinkList linkList = null;
            linkList = InsertLinkList(linkList, 4);
            linkList = InsertLinkList(linkList, 3);
            linkList = InsertLinkList(linkList, 5);
            linkList = InsertLinkList(linkList, 1);
            linkList = InsertLinkList(linkList, 0);
            linkList = InsertLinkList(linkList, 11);
            linkList = InsertLinkList(linkList, 2);
            DisplayLinkList(linkList);
            datas.Append("\n");

            if (linkList == null)
            {
                MessageBox.Show("Linked List is empty");
            }

            LinkList lead = linkList;
            LinkList chase = linkList;

            for (int i = 0; i < 3; i++)
            {
                if (lead == null)
                {
                    MessageBox.Show("Invalid nth location");
                }
                lead = lead.next;
            }

            while (lead != null)
            {
                lead = lead.next;
                chase = chase.next;
            }

            MessageBox.Show("The nth element from the last of the linked list is " + chase.data.ToString());
        }

        private void button20_Click(object sender, EventArgs e)
        {
            LinkList linkList = null;
            LinkList cyclicLinkList = null;
            linkList = InsertLinkList(linkList, 4);
            linkList = InsertLinkList(linkList, 3);
            linkList = InsertLinkList(linkList, 5);
            linkList = InsertLinkList(linkList, 1);
            linkList = InsertLinkList(linkList, 0);
            linkList = InsertLinkList(linkList, 11);
            linkList = InsertLinkList(linkList, 2);
            DisplayLinkList(linkList);
            datas.Append("\n");
            MessageBox.Show(datas.ToString());

            cyclicLinkList = linkList;

            while (cyclicLinkList != null && cyclicLinkList.next != null)
            {
                cyclicLinkList = cyclicLinkList.next;
            }

            cyclicLinkList.next = linkList;


            LinkList fast = linkList;
            LinkList slow = linkList;
            bool isCylic = false;
            //4->3->5->1->0->11->2--
            //^                    |
            //|____________________|
            while (fast != null && slow != null && fast.next != null && !isCylic)
            {
                slow = slow.next;
                fast = fast.next.next;

                if (slow == fast)
                {
                    isCylic = true;
                }
            }

            if (isCylic)
            {
                MessageBox.Show("LinkList is cyclic");
            }
            else
            {
                MessageBox.Show("LinkList is not cyclic");
            }

        }

        private void button18_Click(object sender, EventArgs e)
        {
            int a, b, x, y;

            a = 1; b = 2; x = 3; y = 4;
            while (a != x && b != y)
            {
                if (a > x)
                {
                    a++;
                }
                else
                {
                    a--;
                }
                if (b > y)
                {
                    b++;
                }
                else
                {
                    b--;
                }
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            //Time Complexity is O(n) where n is the number nodes
            LinkListCharacter string1 = null;
            string1 = InsertLinkListForCharacter(string1, 'g');
            string1 = InsertLinkListForCharacter(string1, 'e');
            string1 = InsertLinkListForCharacter(string1, 'e');
            string1 = InsertLinkListForCharacter(string1, 'k');
            string1 = InsertLinkListForCharacter(string1, 's');

            LinkListCharacter string2 = null;
            string2 = InsertLinkListForCharacter(string2, 'g');
            string2 = InsertLinkListForCharacter(string2, 'e');
            string2 = InsertLinkListForCharacter(string2, 'e');
            string2 = InsertLinkListForCharacter(string2, 'k');
            string2 = InsertLinkListForCharacter(string2, 's');
            string2 = InsertLinkListForCharacter(string2, '1');

            int match = StringCompareForLinkList(string1, string2);
            if (match == -1)
            {
                MessageBox.Show("No match");
            }
            else if (match == 1)
            {
                MessageBox.Show("Partial match");
            }
            else if (match == 0)
            {
                MessageBox.Show("Match");
            }

        }

        private int StringCompareForLinkList(LinkListCharacter a, LinkListCharacter b)
        {
            /*
                Less than zero strA precedes strB in the sort order.
                Zero strA occurs in the same position as strB in the sort order.
                Greater than zero strA follows strB in the sort order.
            */

            int returnValue = 0;

            if (a == null || b == null)
            {
                return -1;
            }

            while (a != null && b != null && a.data == b.data)
            {
                a = a.next;
                b = b.next;
            }

            if (a != null && b != null)
                return a.data >= b.data ? 1 : -1;

            if (a != null && b == null)
                return 1;

            if (a == null && b != null)
                return -1;

            return returnValue;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            //Refer : http://www.geeksforgeeks.org/rearrange-a-given-linked-list-in-place/
            //Time complexity : O(n)
            /*
              Input     :   1->2->3->4->5
              Output    :   1->5->2->4->3
            */
            LinkList linkList = null;
            linkList = InsertLinkList(linkList, 1);
            linkList = InsertLinkList(linkList, 2);
            linkList = InsertLinkList(linkList, 3);
            linkList = InsertLinkList(linkList, 4);
            linkList = InsertLinkList(linkList, 5);
            DisplayLinkList(linkList);
            datas.Append("\n");

            Rearrage(linkList);
            DisplayLinkList(linkList);
            datas.Append("\n");
            MessageBox.Show(datas.ToString());
        }

        private LinkList Rearrage(LinkList node)
        {
            //1->2->3->4->5
            //1->5->2->4->3

            LinkList slow = node;
            LinkList fast = slow.next;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            LinkList head1 = node;
            LinkList head2 = slow.next;
            slow.next = null;

            //Reversing a link likst
            LinkList reverse = null;
            while (head2 != null)
            {
                LinkList temp = head2.next;
                head2.next = reverse;
                reverse = head2;
                head2 = temp;
            }

            head2 = reverse;
            node = new LinkList();
            LinkList curr = node;

            while (head1 != null || head2 != null)
            {
                if (head1 != null)
                {
                    curr.next = head1;
                    curr = curr.next;
                    head1 = head1.next;
                }

                if (head2 != null)
                {
                    curr.next = head2;
                    curr = curr.next;
                    head2 = head2.next;
                }
            }


            return node.next;

        }

        private void button23_Click(object sender, EventArgs e)
        {
            //Refer : http://www.geeksforgeeks.org/how-to-sort-a-linked-list-that-is-sorted-alternating-ascending-and-descending-orders/
            /*
             Input List:   10->40->53->30->67->12->89
             Output List:  10->12->30->43->53->67->89
             */

            linkListNode = InsertLinkList(linkListNode, 10);
            linkListNode = InsertLinkList(linkListNode, 40);
            linkListNode = InsertLinkList(linkListNode, 53);
            linkListNode = InsertLinkList(linkListNode, 30);
            linkListNode = InsertLinkList(linkListNode, 67);
            linkListNode = InsertLinkList(linkListNode, 12);
            linkListNode = InsertLinkList(linkListNode, 89);
            DisplayLinkList(linkListNode);
            datas.Append("\n");
            sort();
            DisplayLinkList(linkListNode);
            datas.Append("\n");
            MessageBox.Show(datas.ToString());

        }

        private void sort()
        {
            LinkList headA = new LinkList();
            LinkList headB = new LinkList();

            //Split the link list
            split(headA, headB);

            headB = Reverse(headB);
            linkListNode = MergeLinkList(headA, headB);
        }


        private void split(LinkList headA, LinkList headB)
        {

            LinkList asc = headA;
            LinkList desc = headB;
            LinkList current = linkListNode;

            while (current != null)
            {
                asc.next = current;
                asc = asc.next;
                current = current.next;

                if (current != null)
                {
                    desc.next = current;
                    desc = desc.next;
                    current = current.next;
                }
            }

            asc.next = null;
            desc.next = null;

            headA = headA.next;
            headB = headB.next;

        }

        private LinkList MergeLinkList(LinkList headA, LinkList headB)
        {
            LinkList mergedSortList = null;
            if (headA == null)
            {
                return headB;
            }

            if (headB == null)
            {
                return headA;
            }

            if (headA.data < headB.data)
            {
                mergedSortList = headA;
                mergedSortList.next = MergeLinkList(headA.next, headB);
            }
            else
            {
                mergedSortList = headB;
                mergedSortList.next = MergeLinkList(headA, headB.next);
            }

            return mergedSortList;
        }

        private LinkList Reverse(LinkList headB)
        {
            LinkList node = null;
            while (headB != null)
            {
                LinkList temp = headB.next;
                headB.next = node;
                node = headB;
                headB = temp;
            }
            return node;
        }




        private void button24_Click(object sender, EventArgs e)
        {
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");

            if (regexItem.IsMatch(textBox1.Text))
            {
                MessageBox.Show("Valid");
            }
            else
            {
                MessageBox.Show("InValid");
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            //Time Complexity is O(n)
            LinkList list = null;
            list = InsertLinkList(list, 4);
            list = InsertLinkList(list, 1);
            list = InsertLinkList(list, 2);
            list = InsertLinkList(list, 3);
            list = InsertLinkList(list, 4);
            list = InsertLinkList(list, 5);
            list = InsertLinkList(list, 3);

            LinkList current, previous;
            current = list;
            previous = current;

            int input = 4;

            while (current != null)
            {
                if (list == current && current.data >= input)
                {
                    list = current.next;
                }
                else if (current.data >= input)
                {
                    previous.next = current.next;
                }
                else
                {
                    previous = current;
                }
                current = current.next;
            }

            DisplayLinkList(list);
            MessageBox.Show(datas.ToString());
        }

        private void button26_Click(object sender, EventArgs e)
        {
            /* 
                http://www.geeksforgeeks.org/merge-two-sorted-linked-lists-such-that-merged-list-is-in-reverse-order/
                Time Complexity =  O(n+m) where n and m are the nodes in LinkList1 and LinkList2
                Space Complexity = O(1) since traversing element has to stored one at a time 

                Input:  a: 5->10->15->40
                        b: 2->3->20 
                Output: res: 40->20->15->10->5->3->2
            */


            LinkList LLNodeFirst = null;
            LLNodeFirst = InsertLinkList(LLNodeFirst, 1);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 3);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 5);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 7);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 9);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 11);
            DisplayLinkList(LLNodeFirst);
            datas.Append("\n");

            LinkList LLNodeSecond = null;
            LLNodeSecond = InsertLinkList(LLNodeSecond, 1);
            LLNodeSecond = InsertLinkList(LLNodeSecond, 2);
            LLNodeSecond = InsertLinkList(LLNodeSecond, 4);
            LLNodeSecond = InsertLinkList(LLNodeSecond, 6);
            LLNodeSecond = InsertLinkList(LLNodeSecond, 8);
            LLNodeSecond = InsertLinkList(LLNodeSecond, 10);
            LLNodeSecond = InsertLinkList(LLNodeSecond, 12);

            DisplayLinkList(LLNodeSecond);
            datas.Append("\n");

            DisplayLinkList(MergeTwoSortedLinkListInReverseOrder(LLNodeFirst, LLNodeSecond));
            datas.Append("\n");

            MessageBox.Show(datas.ToString());
        }

        private LinkList MergeTwoSortedLinkListInReverseOrder(LinkList first, LinkList second)
        {
            //1->3->5->7->9->11
            //1->2->4->6->8->10->12
            LinkList list1 = first;
            LinkList list2 = second;

            LinkList result = null;
            LinkList temp = null;
            while (list1 != null && list2 != null)
            {
                if (list1.data == list2.data)
                {
                    temp = list1.next;
                    list1.next = result;
                    result = list1;
                    list1 = temp;
                    list2 = list2.next;
                }
                else if (list1.data < list2.data)
                {
                    temp = list1.next;
                    list1.next = result;
                    result = list1;
                    list1 = temp;
                }
                else if (list1.data > list2.data)
                {
                    temp = list2.next;
                    list2.next = result;
                    result = list2;
                    list2 = temp;
                }
                temp = null;
            }
            temp = null;
            while (list1 != null)
            {
                temp = list1.next;
                list1.next = result;
                result = list1;
                list1 = temp;
            }
            temp = null;
            while (list2 != null)
            {
                temp = list2.next;
                list2.next = result;
                result = list2;
                list2 = temp;
            }

            return result;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            //http://www.geeksforgeeks.org/select-a-random-node-from-a-singly-linked-list/
            //Time Complexity : O(n) where n is the number of nodes in the linked list
            //1->3->5->7->9->11
            datas.Clear();
            LinkList LLNodeFirst = null;
            LLNodeFirst = InsertLinkList(LLNodeFirst, 1);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 3);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 5);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 7);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 9);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 11);
            DisplayLinkList(LLNodeFirst);
            datas.Append("\n");
            DisplayLinkList(this.GetRandomListNode(LLNodeFirst));

            MessageBox.Show(datas.ToString());
        }

        private LinkList GetRandomListNode(LinkList linkList)
        {
            //1->3->5->7->9->11
            LinkList list = linkList;
            LinkList dummy = null;
            LinkList result = linkList;

            Random r = new Random();
            for (int n = 2; list != null; n++)
            {
                if (r.Next() % n == 0)
                {
                    LinkList temp = list.next;
                    list.next = dummy;
                    result = list;
                    list = temp;
                }
                else
                {
                    list = list.next;
                }
            }

            return result;
        }

        public static IEnumerable GetData(List<int> data)
        {
            foreach (var d in data)
            {
                if (d > 50)
                    yield return d;
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            int[] test = new int[] { 1, 2 };
            LinkList list = null;
            //list = InsertLinkList(list, 5);
            list = InsertLinkList(list, 1);
            list = InsertLinkList(list, 2);
            list = InsertLinkList(list, 3);
            list = InsertLinkList(list, 2);
            list = InsertLinkList(list, 5);
            list = InsertLinkList(list, 3);

            LinkList current, previous;
            current = list;
            previous = current;


            while (current != null)
            {
                if (list == current && test.Contains(current.data))
                {
                    list = current.next;
                }
                else if (test.Contains(current.data))
                {
                    previous.next = current.next;
                }
                else
                {
                    previous = current;
                }
                current = current.next;

            }
            DisplayLinkList(list);
            MessageBox.Show(datas.ToString());




        }

        private void button29_Click(object sender, EventArgs e)
        {
            int[] data = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            datas.Clear();
            Node tree = this.CreateBST(data, 0, data.Length - 1);
            Node treeStack = this.CreateBSTUsingStack(data);
            datas.AppendLine("");
            MessageBox.Show($"Balanced BST Recurrsion:  {datas.ToString()}  \nBST Stack {this.InOrderTravelUsingStack(treeStack)}");
        }





        private Node CreateBST(int[] data, int start, int end)
        {
            if (start > end)
            {
                return null;
            }

            int mid = (start + end) / 2;
            datas.Append(data[mid].ToString() + ",");
            Node node = new Node();
            node.data = data[mid];
            node.left = CreateBST(data, start, mid - 1);
            node.right = CreateBST(data, mid + 1, end);
            return node;
        }


        public class NodeWithLeftRight
        {
            public int Left;
            public int Right;
            public Node Node;
        }

        private Node CreateBSTUsingStack(int[] data)
        {
            if (data == null || data.Length == 0)
            {
                return null;
            }


            int l = 0;
            int r = data.Length - 1;
            int m = (l + r) / 2;
            Node root = new Node() { data = data[m] };
            Node node = root;

            Stack<NodeWithLeftRight> s = new Stack<NodeWithLeftRight>();
            s.Push(new NodeWithLeftRight() { Left = l, Right = m - 1, Node = node });
            s.Push(new NodeWithLeftRight() { Left = m + 1, Right = r, Node = node });

            NodeWithLeftRight temp = null;
            Node nodeTemp = null;
            while (s.Count > 0)
            {
                temp = s.Pop();
                l = temp.Left;
                r = temp.Right;
                m = (l + r) / 2;

                if (temp.Node.data > data[m])
                {
                    temp.Node.left = new Node() { data = data[m] };
                    nodeTemp = temp.Node.left;
                }
                else
                {
                    temp.Node.right = new Node() { data = data[m] };
                    nodeTemp = temp.Node.right;
                }

                if (l <= m - 1)
                {
                    s.Push(new NodeWithLeftRight() { Left = l, Right = m - 1, Node = nodeTemp });
                }
                if (m + 1 <= r)
                {
                    s.Push(new NodeWithLeftRight() { Left = m + 1, Right = r, Node = nodeTemp });
                }
            }


            return root;

        }


        private void button30_Click(object sender, EventArgs e)
        {


            // Convert the array to a base 64 string.
            //string m = "dfsdfsdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfdsf";
            string s = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            System.Text.RegularExpressions.Regex rgx = new Regex("[^a-zA-Z0-9]");
            s = rgx.Replace(s, "");




            MessageBox.Show($"{s} length {s.Length.ToString()}");

        }

        private void FunctionTest(Test t)
        {
            t.data = "inside function";
        }

        public class Test
        {
            public int i;
            public string data;
        }


        public static int totalScore(string[] blocks, int n)
        {
            if (blocks == null || n == 0)
            {
                return 0;
            }

            int sum = 0;
            int[] scores = new int[blocks.Length];
            string blockValue = string.Empty;
            int currentScoreIndex = 0;
            for (int i = 0; i < blocks.Length; i++)
            {
                //At any given time the symbols in the blocks list should contain one character 
                blockValue = blocks[i];
                if (blockValue == "X")
                {
                    if (i - 1 >= 0)
                    {
                        scores[currentScoreIndex] = ConvertToInt(blocks[currentScoreIndex - 1]) * 2;
                        currentScoreIndex++;
                    }
                }
                else if (blockValue == "+")
                {
                    if (i - 1 >= 0)
                    {
                        if (i - 2 >= 0)
                        {
                            scores[currentScoreIndex] = scores[currentScoreIndex - 1] + scores[currentScoreIndex - 2];
                            currentScoreIndex++;
                        }
                        else
                        {
                            scores[currentScoreIndex] = scores[currentScoreIndex - 1];
                            currentScoreIndex++;
                        }
                    }
                }
                else if (blockValue == "Z")
                {
                    if (i - 1 >= 0)
                    {
                        scores[currentScoreIndex - 1] = 0;
                        currentScoreIndex--;
                    }
                }
                else
                {
                    scores[currentScoreIndex] = ConvertToInt(blocks[i]);
                    currentScoreIndex++;
                }

            }

            for (int i = 0; i < scores.Length; i++)
            {
                sum = sum + scores[i];
            }
            return sum;
        }

        private static int ConvertToInt(string blockValue)
        {
            int returnValue = 0;
            int.TryParse(blockValue, out returnValue);
            return returnValue;
        }

        class Tst
        {
            public int t = 0;
        }

        static Func<int, int> X(Func<int, int, int> f)
        {
            Console.WriteLine(f.Method.Name);
            return a => f(a, 4);
        }



        static int Sum(int x, int y)
        {
            return x + y;
        }


        private string CheckString(string line)
        {
            string returnString = "YES";
            if (string.IsNullOrEmpty(line))
            {
                return returnString;
            }

            bool startingParam = false;
            foreach (char c in line)
            {
                if (!((c >= 97 && c <= 122) || c == 32 || c == 58))
                {
                    returnString = "NO";
                    break;
                }
                else if (c == 40 && !startingParam)
                {
                    startingParam = true;
                }
                else if (c == 41 && startingParam)
                {
                    startingParam = false;
                }
                else
                {
                    returnString = "NO";
                    break;
                }
            }

            return returnString;
        }

        private void Check_if_given_sorted_sub_sequence_exists_in_binary_search_tree_Click(object sender, EventArgs e)
        {
            // http://www.geeksforgeeks.org/check-if-given-sorted-sub-sequence-exists-in-binary-search-tree/

            /*
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
            */

            Node tree = null;
            Insert(10, ref tree);
            Insert(5, ref tree);
            Insert(20, ref tree);
            Insert(3, ref tree);
            Insert(8, ref tree);
            Insert(6, ref tree);
            Insert(15, ref tree);
            Insert(22, ref tree);
            Insert(1, ref tree);
            Insert(2, ref tree);
            Insert(4, ref tree);
            Insert(9, ref tree);
            datas.Clear();
            InOrder(tree);

            int[] seq = new int[] { 4, 5, 8 };

            MessageBox.Show(isSequenceExists(tree, seq) ? string.Format("Sequence: {0} exists in tree :{1}", string.Join(",", seq), datas.ToString()) : string.Format("Sequence: {0} does not exists in tree: {1}", string.Join(",", seq), datas.ToString()));

        }

        private bool isSequenceExists(Node tree, int[] seq)
        {

            int sequenceAvail = 0;

            this.GetInOrderNode(tree, seq, ref sequenceAvail);
            return (sequenceAvail == seq.Count());


        }

        private void GetInOrderNode(Node tree, int[] seq, ref int sequenceAvailIndex)
        {

            if (tree == null)
            {
                return;
            }

            GetInOrderNode(tree.left, seq, ref sequenceAvailIndex);

            if (sequenceAvailIndex >= seq.Count())
                return;

            if (tree.data == seq[sequenceAvailIndex])
                sequenceAvailIndex++;

            GetInOrderNode(tree.right, seq, ref sequenceAvailIndex);
        }

        private void Check_whether_BST_contains_Dead_End_or_not_Click(object sender, EventArgs e)
        {

            /*
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
            */


            // http://www.geeksforgeeks.org/check-whether-bst-contains-dead-end-not/
            //Time Complexity is O(n)
            Node tree = null;
            //Insert(10, ref tree);
            //Insert(5, ref tree);
            //Insert(20, ref tree);
            //Insert(3, ref tree);
            //Insert(8, ref tree);
            //Insert(6, ref tree);
            //Insert(15, ref tree);
            //Insert(22, ref tree);
            //Insert(1, ref tree);
            //Insert(2, ref tree);
            //Insert(4, ref tree);
            //Insert(9, ref tree);
            Insert(8, ref tree);
            Insert(7, ref tree);
            Insert(10, ref tree);
            Insert(2, ref tree);
            Insert(9, ref tree);
            Insert(13, ref tree);
            //Insert(4, ref tree);
            datas.Clear();
            datas.Append("\r\n InOrder Traversal :");
            InOrder(tree);
            MessageBox.Show(datas.ToString());

            Node root = tree;
            List<int> treeNodes = new List<int>();
            List<int> leafNodes = new List<int>();

            treeNodes.Add(0);
            this.TraverseAndInsertIntoHashSet(root, treeNodes, leafNodes);

            int leafNodeCount = leafNodes.Count;
            bool isDeadEnd = false;
            for (int i = 0; i < leafNodeCount; i++)
            {
                if (

                        //treeNodes.Find(x=>x == leafNodes[i]+1) != treeNodes.Last() &&
                        //treeNodes.Find(x => x == leafNodes[i]-1) != treeNodes.Last()   
                        treeNodes.Where(w => w == leafNodes[i] + 1 || w == leafNodes[i] - 1).Count() > 0
                   )
                {
                    isDeadEnd = true;
                    break;
                }
            }

            MessageBox.Show(isDeadEnd ? "Tree is dead end" : "Tree is not dead end");
        }


        private void TraverseAndInsertIntoHashSet(Node root, List<int> treeNodes, List<int> leafNodes)
        {
            if (root == null)
            {
                return;
            }
            treeNodes.Add(root.data);

            if (root.left == null && root.right == null)
            {
                leafNodes.Add(root.data);
                return;
            }

            TraverseAndInsertIntoHashSet(root.left, treeNodes, leafNodes);
            TraverseAndInsertIntoHashSet(root.right, treeNodes, leafNodes);
        }

        private void ConnectNodes_Click(object sender, EventArgs e)
        {

            /*
                                10
                             /      \
                            /        \
                           /          \
                          /            \                           
                         /              \
                        5-------------->20
                      /  \             / \
                     /    \           /   \  
                    /      \         /     \
                   3------->8------>15----->22 
                  / \      / \ 
                 /   \    /   \
                1---->4->6---->9
                 \
                  \
                   2
            */


            NodeWithNext tree = null;
            InsertNodeWithNext(10, ref tree);
            InsertNodeWithNext(5, ref tree);
            InsertNodeWithNext(20, ref tree);
            InsertNodeWithNext(3, ref tree);
            InsertNodeWithNext(8, ref tree);
            InsertNodeWithNext(6, ref tree);
            InsertNodeWithNext(15, ref tree);
            InsertNodeWithNext(22, ref tree);
            InsertNodeWithNext(1, ref tree);
            InsertNodeWithNext(2, ref tree);
            InsertNodeWithNext(4, ref tree);
            InsertNodeWithNext(9, ref tree);
            datas.Clear();
            InOrderWithNext(tree);
            MessageBox.Show(datas.ToString());

            Queue<NodeWithNext> q = new Queue<NodeWithNext>();
            if (tree.left != null)
            {
                q.Enqueue(tree.left);
            }

            if (tree.right != null)
            {
                q.Enqueue(tree.right);
            }

            while (true)
            {
                List<NodeWithNext> nextNodes = new List<NodeWithNext>();
                while (q.Count > 0)
                {
                    nextNodes.Add(q.Dequeue());
                }

                NodeWithNext previous = null;
                NodeWithNext current = null;
                foreach (var n in nextNodes)
                {
                    if (current == null)
                    {
                        current = n;
                    }
                    else
                    {
                        previous = current;
                        current = n;
                        previous.next = current;
                        if (previous.left != null)
                        {
                            q.Enqueue(previous.left);
                        }

                        if (previous.right != null)
                        {
                            q.Enqueue(previous.right);
                        }
                    }
                }
                if (current.left != null)
                {
                    q.Enqueue(current.left);
                }

                if (current.right != null)
                {
                    q.Enqueue(current.right);
                }

                if (q.Count == 0)
                {
                    break;
                }
            }
        }

        private void InOrderWithNext(NodeWithNext node)
        {
            if (node == null)
            {
                return;
            }
            InOrderWithNext(node.left);
            datas.Append(node.data.ToString() + ",");
            InOrderWithNext(node.right);
        }

        private void btnDistance_of_two_nodes_in_Binary_Search_Tree_Click(object sender, EventArgs e)
        {
            /*
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
            */


            Node tree = null;
            Insert(10, ref tree);
            Insert(5, ref tree);
            Insert(20, ref tree);
            Insert(3, ref tree);
            Insert(8, ref tree);
            Insert(6, ref tree);
            Insert(15, ref tree);
            Insert(22, ref tree);
            Insert(1, ref tree);
            Insert(2, ref tree);
            Insert(4, ref tree);
            Insert(9, ref tree);
            datas.Clear();
            datas.Append("\r\n InOrder Traversal :");
            InOrder(tree);
            MessageBox.Show(datas.ToString());

            int input1 = 9;
            int input2 = 2;

            Node commonAccesstorNode = this.GetCommonAncestor_Distance_of_two_nodes_in_Binary_Search_Tree(tree, input1, input2);
            int distance1 = this.FindDistanceForElementInBinary_SearchTree(commonAccesstorNode, input1);
            int distance2 = -1;
            if (distance1 > 0)
            {
                distance2 = this.FindDistanceForElementInBinary_SearchTree(commonAccesstorNode, input2);
            }

            MessageBox.Show($"The distance between {input1} and {input2} is {(distance1 > 0 && distance2 > 0 ? (distance1 + distance2).ToString() : "-1")}");



        }

        private int FindDistanceForElementInBinary_SearchTree(Node node, int input)
        {
            int distance = -1;
            bool nodeExists = false;
            if (node == null)
            {
                return distance;
            }

            distance = 0;
            while (node != null)
            {
                if (node.data > input)
                {
                    node = node.left;
                    distance++;
                }
                else if (node.data < input)
                {
                    node = node.right;
                    distance++;
                }
                else if (node.data == input)
                {
                    nodeExists = true;
                    break;
                }
            }

            return nodeExists ? distance : -1;
        }

        private Node GetCommonAncestor_Distance_of_two_nodes_in_Binary_Search_Tree(Node tree, int input1, int input2)
        {
            if (tree == null)
            {
                return null;
            }

            while (tree != null)
            {
                if (tree.data > input1 && tree.data > input2)
                {
                    tree = tree.left;
                }
                else if (tree.data < input1 && tree.data < input2)
                {
                    tree = tree.right;
                }
                else
                {
                    break;
                }
            }

            return tree;
        }
      
        private void btn_Clone_a_linked_list_with_next_and_random_pointer_Click(object sender, EventArgs e)
        {
            /* 
             Time Complexity    :O(n)
             Space Complexity   :O(n)             
             http://www.geeksforgeeks.org/clone-linked-list-next-arbit-pointer-set-2/

            4----->3----->5----->1----->0----->11----->2
            |      |      ^                            ^
            |      |      |                            | 
            |      |      |                            |
            -------|-------                            |
                   |------------------------------------ 
             */

            LinkList LLNodeFirst = null;
            LLNodeFirst = InsertLinkList(LLNodeFirst, 4);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 3);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 5);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 1);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 0);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 11);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 2);
            datas.Append("Original List \n");
            DisplayLinkList(LLNodeFirst);
            datas.Append("\n");

            LLNodeFirst.random = LLNodeFirst.next.next;
            LLNodeFirst.next.random = LLNodeFirst.next.next.next.next.next.next;

            // Time Complexity    :O(n)
            // Space Complexity   :O(n)            

            Dictionary<LinkList, LinkList> storage = new Dictionary<LinkList, LinkList>();
            LinkList original = LLNodeFirst;
            LinkList clone = null;

            while (original != null)
            {
                clone = new LinkList();
                clone.data = original.data;
                storage.Add(original, clone);
                original = original.next;
            }

            original = LLNodeFirst;

            while (original != null)
            {
                clone = storage[original];
                if (original.next != null)
                {
                    clone.next = storage[original.next];
                }
                if (original.random != null)
                {
                    clone.random = storage[original.random];
                }
                original = original.next;
            }

            datas.Append("Cloned List \n");
            datas.Append("Time Complexity    :O(n) and Space Complexity   :O(n) \n\n");
            DisplayLinkList(storage[LLNodeFirst]);

            // Time Complexity    :O(n)
            // Space Complexity   :O(1)
            /* 
            Time Complexity    :O(n)
            Space Complexity   :O(n)             
            http://www.geeksforgeeks.org/clone-linked-list-next-arbit-pointer-set-2/

           4----->3----->5----->1----->0----->11----->2
           |      |      ^                            ^
           |      |      |                            | 
           |      |      |                            |
           -------|-------                            |
                  |------------------------------------ 
            */
            datas.Append("Time Complexity    :O(n) and Space Complexity   :O(1) \n\n");

            original = LLNodeFirst;
            clone = null;
            while (original != null)
            {
                LinkList temp = original.next;
                clone = new LinkList() { data = original.data };
                original.next = clone;
                clone.next = temp;
                original = temp;
            }

            original = LLNodeFirst;
            while (original != null && original.next != null)
            {
                if (original.random != null)
                {
                    original.next.random = original.random.next;
                }
                original = original.next.next;
            }

            original = LLNodeFirst;
            clone = LLNodeFirst.next;
            LinkList tempCloned = clone;

            while (original != null && clone != null)
            {
                original.next = original.next != null ? original.next.next : original.next;
                clone.next = clone.next != null ? clone.next.next : clone.next;
                original = original.next;
                clone = clone.next;
            }

            DisplayLinkList(tempCloned);

            MessageBox.Show(datas.ToString());

        }

        private void btn_Clone_a_linked_list_with_next_pointer_Click(object sender, EventArgs e)
        {
            /* 
            Time Complexity    :O(n)            
            
           4----->3----->5----->1----->0----->11----->2
           
            */

            LinkList LLNodeFirst = null;
            LLNodeFirst = InsertLinkList(LLNodeFirst, 4);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 3);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 5);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 1);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 0);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 11);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 2);
            datas.Append("Original List \n");
            DisplayLinkList(LLNodeFirst);
            datas.Append("\n");

            datas.Append("Cloned List \n");

            LinkList original = LLNodeFirst;
            LinkList clone = new LinkList();
            LinkList temp = clone;

            while (original != null)
            {
                temp.next = new LinkList() { data = original.data };
                original = original.next;
                temp = temp.next;
            }
            clone = clone.next;

            DisplayLinkList(clone);
            datas.Append("\n");

            MessageBox.Show(datas.ToString());


        }

        private void btn_Sum_of_the_nodes_at_each_level_in_a_Binary_tree_Click(object sender, EventArgs e)
        {
            /*
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
           */


            Node tree = null;
            Insert(10, ref tree);
            Insert(5, ref tree);
            Insert(20, ref tree);
            Insert(3, ref tree);
            Insert(8, ref tree);
            Insert(6, ref tree);
            Insert(15, ref tree);
            Insert(22, ref tree);
            Insert(1, ref tree);
            Insert(2, ref tree);
            Insert(4, ref tree);
            Insert(9, ref tree);
            datas.Clear();
            datas.Append("\r\n InOrder Traversal :");
            InOrder(tree);
            MessageBox.Show(datas.ToString());

            Queue que = new Queue();
            que.Enqueue(tree);
            int maxSum = 0;
            int temp = 0;
            int count = 0;
            int level = 0;
            StringBuilder builder = new StringBuilder();
            while (true)
            {
                temp = 0;
                count = que.Count;
                if (count == 0)
                {
                    break;
                }

                level++;

                while (count > 0)
                {
                    Node node = (Node)que.Dequeue();
                    if (node != null)
                    {
                        temp += node.data;
                    }

                    if (node.left != null)
                    {
                        que.Enqueue(node.left);
                    }

                    if (node.right != null)
                    {
                        que.Enqueue(node.right);
                    }
                    count--;
                }

                builder.Append($"Level {level.ToString()} sum is {temp.ToString()}\n");

                maxSum = Math.Max(maxSum, temp);
            }

            builder.Append("\n");
            builder.Append($"The max sum in tree is {maxSum.ToString()}\n\n");

            MessageBox.Show(builder.ToString());
        }

        private void btn_Build_Binary_Tree_for_the_given_arithmatic_expression_Click(object sender, EventArgs e)
        {
            //string input = "(x+1)/(((y+3)+x)*m)";
            //input = "ab+cde+**";
            //input = "a+b*c*d+e";
            //Given post fix binary tree expression, build binary tree expression and out the
            //result in infix expression
            string input = "x1+y3xm*++/";
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Expression is empty");
            }

            Stack expHolder = new Stack();
            List<char> operators = new List<char>() { '+', '-', '/', '*', '^' };
            NodeWithObjectData t = null;
            foreach (char c in input)
            {
                if (c == '(' || c == ')')
                {
                    continue;
                }
                if (!operators.Contains(c))
                {
                    t = new NodeWithObjectData() { data = c };
                }
                else
                {
                    t = new NodeWithObjectData() { data = c };
                    if (expHolder.Count > 0)
                    {
                        t.right = (NodeWithObjectData)expHolder.Pop();
                    }

                    if (expHolder.Count > 0)
                    {
                        t.left = (NodeWithObjectData)expHolder.Pop();
                    }
                }
                expHolder.Push(t);
            }

            var expressionBinaryTree = (NodeWithObjectData)expHolder.Pop();
            datas.Clear();
            this.InOrderTravel_NodeWithObjectData(expressionBinaryTree);
            MessageBox.Show($"Binary expression is { datas.ToString() } for Expression {input}");
        }

        private void InOrderTravel_NodeWithObjectData(NodeWithObjectData node)
        {
            if (node != null)
            {
                this.InOrderTravel_NodeWithObjectData(node.left);
                datas.Append(node.data.ToString());
                this.InOrderTravel_NodeWithObjectData(node.right);
            }


        }

        private void btn_Connect_Nodes_with_right_to_left_and_left_to_right_Click(object sender, EventArgs e)
        {
            /*
                               10
                            /      \
                           /        \
                          /          \
                         /            \                           
                        /              \
                       5 ------------->20
                     /  \             / \
                    /    \           /   \  
                   /      \         /     \
                  3<-------8<------15<----22 
                 / \      / \ 
                /   \    /   \
               1---->4->6---->9
                \
                 \
                  2
           */

            NodeWithNext tree = null;
            InsertNodeWithNext(10, ref tree);
            InsertNodeWithNext(5, ref tree);
            InsertNodeWithNext(20, ref tree);
            InsertNodeWithNext(3, ref tree);
            InsertNodeWithNext(8, ref tree);
            InsertNodeWithNext(6, ref tree);
            InsertNodeWithNext(15, ref tree);
            InsertNodeWithNext(22, ref tree);
            InsertNodeWithNext(1, ref tree);
            InsertNodeWithNext(2, ref tree);
            InsertNodeWithNext(4, ref tree);
            InsertNodeWithNext(9, ref tree);
            datas.Clear();
            InOrderWithNext(tree);
            MessageBox.Show(datas.ToString());

            if (tree == null)
            {
                return;
            }

            bool direction = true;
            List<NodeWithNext> nodes = new List<NodeWithNext>();

            Queue<NodeWithNext> que = new Queue<NodeWithNext>();
            if (tree.left != null)
            {
                que.Enqueue(tree.left);
            }

            if (tree.right != null)
            {
                que.Enqueue(tree.right);
            }

            que.Enqueue(null);

            NodeWithNext current = null, previous = null;
            //NodeWithNext node = null;            

            while (que.Count > 0)
            {
                if (que.Peek() == null)
                {
                    if (current == null)
                    {
                        break;
                    }

                    if (current.left != null)
                    {
                        que.Enqueue(current.left);
                    }

                    if (current.right != null)
                    {
                        que.Enqueue(current.right);
                    }

                    que.Dequeue();
                    que.Enqueue(null);
                    current = null;
                    previous = null;
                    direction = !direction;
                }
                else
                {
                    if (current == null)
                    {
                        current = que.Dequeue();
                    }
                    else
                    {
                        previous = current;
                        current = que.Dequeue();
                        if (direction)
                        {
                            previous.next = current;
                        }
                        else
                        {
                            current.next = previous;
                        }

                        if (previous.left != null)
                        {
                            que.Enqueue(previous.left);
                        }

                        if (previous.right != null)
                        {
                            que.Enqueue(previous.right);
                        }
                    }
                }
            }
        }

        private void btn_Connect_Nodes_with_iterating_queue_data_into_list_Click(object sender, EventArgs e)
        {
            //Note : This solution will work for all types of binary tree (proper and improper). Proper binary tree means which has left and right subtree for all the parent trees

            /*
                             10
                          /      \
                         /        \
                        /          \
                       /            \                           
                      /              \
                     5 ------------->20
                   /  \             / \
                  /    \           /   \  
                 /      \         /     \
                3------->8------>15---->22 
               / \      / \ 
              /   \    /   \
             1---->4->6---->9
              \
               \
                2
         */

            NodeWithNext tree = null;
            InsertNodeWithNext(10, ref tree);
            InsertNodeWithNext(5, ref tree);
            InsertNodeWithNext(20, ref tree);
            InsertNodeWithNext(3, ref tree);
            InsertNodeWithNext(8, ref tree);
            InsertNodeWithNext(6, ref tree);
            InsertNodeWithNext(15, ref tree);
            InsertNodeWithNext(22, ref tree);
            InsertNodeWithNext(1, ref tree);
            InsertNodeWithNext(2, ref tree);
            InsertNodeWithNext(4, ref tree);
            InsertNodeWithNext(9, ref tree);
            datas.Clear();
            InOrderWithNext(tree);
            MessageBox.Show(datas.ToString());

            
            Queue<NodeWithNext> q = new Queue<NodeWithNext>();
            if (tree.left != null)
            {
                q.Enqueue(tree.left);
            }

            if (tree.right != null)
            {
                q.Enqueue(tree.right);
            }

            q.Enqueue(null);
            NodeWithNext previous = null;
            NodeWithNext current = null;

            while (q.Count > 0)
            {
                if (q.Peek() == null)
                {
                    if (current.left != null)
                    {
                        q.Enqueue(current.left);
                    }

                    if (current.right != null)
                    {
                        q.Enqueue(current.right);
                    }
                    q.Dequeue();
                    q.Enqueue(null);
                    current = null;
                    previous = null;
                }

                if (current == null)
                {
                    current = q.Dequeue();
                }
                else
                {
                    previous = current;
                    current = q.Dequeue();
                    previous.next = current;
                    if (previous.left != null)
                    {
                        q.Enqueue(previous.left);
                    }

                    if (previous.right != null)
                    {
                        q.Enqueue(previous.right);
                    }
                }
            }
        }


        public void btn_Robbing_a_home_3_Click(object sender, EventArgs e)
        {

            /*
            The thief has found himself a new place for his thievery again. There is only one entrance to this area, called the "root." 
            Besides the root, each house has one and only one parent house. After a tour, the smart thief realized that "all houses in this place forms a binary tree". It will automatically contact the police if two directly-linked houses were broken into on the same night.
            Determine the maximum amount of money the thief can rob tonight without alerting the police. 
            Input: [3,2,3,null,3,null,1]

                                 3
                                / \
                               2   3
                                \   \ 
                                 3   1

            Output: 7 
            Explanation: Maximum amount of money the thief can rob = 3 + 3 + 1 = 7.

            Input: [3,4,5,1,3,null,1]

                                 3
                                / \
                               4   5
                              / \   \ 
                             1   3   1

                            Output: 9
                            Explanation: Maximum amount of money the thief can rob = 4 + 5 = 9.
 
              
             */
            NodeWithNext root = new NodeWithNext();
            root.left.left.data = 1;
            root.left.right.data = 3;
            root.left.data = 4;
            root.right.right.data = 1;
            root.right.data = 5;
            root.data = 3;

            //root.left.right.data = 3;
            //root.left.data = 2;
            //root.right.right.data = 1;
            //root.right.data = 3;
            //root.data = 3;


            datas.Clear();
            this.InOrderWithNext(root);
            int[] returnValue = this.RobHouse(root);
            MessageBox.Show($"Max value that is robbed by rollber is {(Math.Max(returnValue[0], returnValue[1]))} for the house {datas.ToString()}");

        }

        private int[] RobHouse(NodeWithNext node)
        {

            /*
                                 3
                                / \
                               4   5
                              / \   \ 
                             1   3   1

            4 -> L : 1,0 R -> 3,0 -> 4,4
            5 -> L : 0,0 R-> 1, 0 -->5,1
            3 -> 3 + 4 + 1 = 8 
                         5+4=9 

             */

            if (node == null)
            {
                return new int[2];
            }
            int[] left = RobHouse(node.left);
            int[] right = RobHouse(node.right);

            int[] current = new Int32[2];
            current[0] = node.data + left[1] + right[1];
            current[1] = Math.Max(left[0], left[1]) + Math.Max(right[0], right[1]);
            return current;
        }

        private void btn_Merge_k_Sorted_LinkLists_Click(object sender, EventArgs e)
        {
            /*             
                  1->4->5,
                  1->3->4,
                  2->6
            */
            StringBuilder result = new StringBuilder();
            List<IList<ListNode>> inputs = new List<IList<ListNode>>();
            List<ListNode> input = new List<ListNode>();
            input.Add(this.InsertListNode(new int[] { 1, 4, 5 }));
            input.Add(this.InsertListNode(new int[] { 1, 3, 4 }));
            input.Add(this.InsertListNode(new int[] { 2, 6 }));
            inputs.Add(input);
            

            foreach (var linkList in inputs)
            {

                result.AppendLine($"The result of merging k link list is { GetListNodeData(this.MergeKLists(linkList.ToArray<ListNode>()))}");
                //Refer MergeLinkedListGPT  method from DataStructure_Ext_Console.proje


            }


            MessageBox.Show(result.ToString());


        }

        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0)
                return null;
            

            return BinaryMerge(lists, 0, lists.Length - 1);
        }

        public ListNode BinaryMerge(ListNode[] lists, int start, int end)
        {

            if (start == end)
                return lists[start];

            int mid = start + ((end - start) / 2);
            ListNode l1 = BinaryMerge(lists, start, mid);
            ListNode l2 = BinaryMerge(lists, mid + 1, end);
            return Merge(l1, l2);



        }

        public ListNode Merge(ListNode a, ListNode b)
        {
            if (a == null) return b;
            if (b == null) return a;

            ListNode first;
            ListNode second;
            ListNode prev = null;

            if (a.val < b.val)
            {
                first = a;
                second = b;
            }
            else
            {
                first = b;
                second = a;
            }

            var head = first;



        while (first != null && second != null)
            {
                if (first.val <= second.val)
                {
                    prev = first;
                    first = first.next;
                }
                else
                {
                    var other = second;
                    second = second.next;
                    other.next = first;
                    prev.next = other;
                    first = prev.next;
                }
            }

            if (second != null)
                prev.next = second;

            return head;
        }

        private void btn_Searilzing_and_De_serialzing_Binary_Tree_Click(object sender, EventArgs e)
        {

            Node root = new Node() { data = 1 };
            root.left = new Node() { data = 2 };
            root.right = new Node() { data = 3 };
            root.right.left = new Node() { data = 4 };
            root.right.right = new Node() { data = 5 };

            string result = this.Serialize(root);
            this.DeSerialize(result);
            MessageBox.Show($"Serialization of binary tree is {result}");


        }


        private Node DeSerialize(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }

            string[] datas = input.Split(',');


            Node tree = new Node() { data = int.Parse(datas[0]) };
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(tree);
            //1,2,3,null,null,4,5
            for (int i = 1; i < datas.Length - 1; i++)
            {
                var parent = queue.Dequeue();
                if (!string.IsNullOrEmpty(datas[i]))
                {
                    parent.left = new Node() { data = int.Parse(datas[i]) };
                    queue.Enqueue(parent.left);
                }
                if (!string.IsNullOrEmpty(datas[++i]))
                {
                    parent.right = new Node() { data = int.Parse(datas[i]) };
                    queue.Enqueue(parent.right);
                }
            }


            return tree;

        }

        private string Serialize(Node root)
        {
            if (root == null)
            {
                return null;
            }

            /*
                            1
                           / \
                          2   3
                             / \
                            4   5

               Output : [1,2,3,null,null,4,5]
              
             */

            Queue<Node> que = new Queue<Node>();
            que.Enqueue(root);
            StringBuilder serializableString = new StringBuilder();
            int lastValidIndex = 0;
            string result;
            while (que.Count != 0)
            {
                Node node = que.Dequeue();
                if (node == null)
                {
                    serializableString.Append(",");
                    lastValidIndex++;
                }
                else
                {
                    lastValidIndex = 0;
                    serializableString.Append($"{node.data.ToString()},");
                    que.Enqueue(node.left);
                    que.Enqueue(node.right);
                }
            }

            if (lastValidIndex > 0)
            {
                result = serializableString.ToString().Substring(0, serializableString.Length - (lastValidIndex + 1));
            }
            else
            {
                result = serializableString.ToString();
            }

            return result;
        }

        private void btn_Count_the_number_of_unival_subtrees_Click(object sender, EventArgs e)
        {
            /*
             A unival tree (which stands for "universal value") is a tree where all nodes under 
             it have the same value. Given the root to a binary tree, count the number of unival subtrees.

             For example, the following tree has 5 unival subtrees:

                                    0
                                   / \
                                  1   0
                                     / \
                                    1   0
                                   / \
                                  1   1
             */

            string msg = @"  
                                    0
                                   / \
                                     0
                                     / \
                                    1   
                                   / \
                                  1   1";


            Node root = new Node() { data = 0 };
            //root.left = new Node() { data = 1 };
            root.right = new Node() { data = 0 };
            root.right.left = new Node() { data = 1 };
            //root.right.right = new Node() { data = 0 };
            root.right.left.left = new Node() { data = 1 };
            root.right.left.right = new Node() { data = 1 };

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            Node temp = null;
            int counter = 0;
            while (queue.Count > 0)
            {
                temp = queue.Dequeue();
                if (temp != null)
                {
                    if ((temp.left != null && temp.right != null && temp.data == temp.left.data && temp.left.data == temp.right.data) ||
                        (temp.left == null && temp.right == null))
                    {
                        counter++;
                    }
                }

                if (temp.left != null)
                {
                    queue.Enqueue(temp.left);
                }
                if (temp.right != null)
                {
                    queue.Enqueue(temp.right);
                }
            }

            MessageBox.Show($"Number of unival subtree in a given tree \n {msg} is \n {counter} ");
        }

        private void btn_Find_the_Deepest_Node_in_a_Binary_Tree_Click(object sender, EventArgs e)
        {

            /*
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
            */

            Node tree = null;
            Insert(10, ref tree);
            Insert(5, ref tree);
            Insert(20, ref tree);
            Insert(3, ref tree);
            Insert(8, ref tree);
            Insert(6, ref tree);
            Insert(15, ref tree);
            Insert(22, ref tree);
            Insert(1, ref tree);
            Insert(2, ref tree);
            Insert(4, ref tree);
            Insert(9, ref tree);


            int maxLevel = -1;
            int maxLevelQ = -1;

            Node result = this.FindDeepestNode(tree, -1, ref maxLevel);
            MessageBox.Show($"Deepest node in a given binary tree is \nWith Recurression {result.data.ToString()} with maxlevel {maxLevel} \nWith Queue {this.FindDeepestNodeWithQueue(tree, ref maxLevelQ).data} with maxlevel {maxLevelQ}");

        }

        public Node FindDeepestNodeWithQueue(Node root, ref int maxLevel)
        {
            if (root == null)
            {
                return null;
            }

            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            q.Enqueue(null);
            Node current = null;

            while (q.Count > 0)
            {

                if (q.Peek() == null)
                {
                    maxLevel++;
                    q.Dequeue();
                    if (q.Count == 0)
                    {
                        break;
                    }
                    q.Enqueue(null);
                }
                else
                {

                    current = q.Dequeue();
                    if (current.left != null)
                    {
                        q.Enqueue(current.left);
                    }

                    if (current.right != null)
                    {
                        q.Enqueue(current.right);
                    }
                }
            }
            return current;

        }

        public Node FindDeepestNode(Node root, int level, ref int maxLevel)
        {

            /*
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
            */
            Node result = null;
            Node temp = null;
            if (root == null)
            {
                return null;
            }

            ++level;
            temp = this.FindDeepestNode(root.left, level, ref maxLevel);
            if (level > maxLevel && temp == null)
            {
                maxLevel = level;
                result = root;
            }
            else if (temp != null)
            {
                result = temp;
            }


            temp = this.FindDeepestNode(root.right, level, ref maxLevel);
            if (temp != null)
            {
                result = temp;
            }

            return result;

        }

        private void btn_Given_Binary_tree_return_all_paths_from_the_root_to_leaves_Click(object sender, EventArgs e)
        {
            /*
             Given a binary tree, return all paths from the root to leaves.
                For example, given the tree:

                   1
                  / \
                 2   3
                    / \
                   4   5
                Return [[1, 2], [1, 3, 4], [1, 3, 5]].
             */
            Node root = new Node() { data = 1 };
            root.left = new Node() { data = 2 };
            root.right = new Node() { data = 3 };
            root.right.right = new Node() { data = 5 };
            root.right.left = new Node() { data = 4 };
            List<string> result = new List<string>();
            this.GetAllPathFromRootToLeaves(root, result, string.Empty);
            MessageBox.Show($"All Path from root to leaves are below \n {string.Join("\n", result)}");

        }

        private void GetAllPathFromRootToLeaves(Node root, List<string> result, string paths)
        {

            if (root == null)
            {
                return;
            }

            if (root.left != null)
            {
                GetAllPathFromRootToLeaves(root.left, result, $"{paths} {(string.IsNullOrEmpty(paths) ? "" : ",")} {root.data}");
            }

            if (root.right != null)
            {
                GetAllPathFromRootToLeaves(root.right, result, $"{paths} {(string.IsNullOrEmpty(paths) ? "" : ",")} {root.data}");
            }

            if (root.left == null && root.right == null)
            {
                result.Add($"{paths} {(string.IsNullOrEmpty(paths) ? "" : ",")} {root.data}");
            }
        }

        private void btn_Distribute_coin_in_a_binary_tree_Click(object sender, EventArgs e)
        {
            /*
                Given the root of a binary tree with N nodes, each node in the tree has node.val coins, and there are N coins total.
                In one move, we may choose two adjacent nodes and move one coin from one node to another.  (The move may be from parent to child, or from child to parent.)
                Return the number of moves required to make every node have exactly one coin.
                Example 1:
                    Input: [3,0,0]
                    Output: 2
                Explanation: From the root of the tree, we move one coin to its left child, and one coin to its right child.
                Example 2:
                    Input: [0,3,0]
                    Output: 3
                    Explanation: From the left child of the root, we move two coins to the root [taking two moves].  Then, we move one coin from the root of the tree to the right child.
                Example 3:
                    Input: [1,0,2]
                    Output: 2
                    Example 4:
                    Input: [1,0,0,null,3]
                    Output: 4
             */
            int numOfSteps = 0;
            Node root = new Node() { data = 1 };
            root.left = new Node() { data = 0 };
            root.left.right = new Node() { data = 3 };
            root.right = new Node() { data = 0 };
            this.Distribute(root, ref numOfSteps);
            MessageBox.Show($"No of steps taken to distribute the coin is {numOfSteps} for the given binary tree");
        }

        private int Distribute(Node root, ref int numOfSteps)
        {
            /*
                    
                                1
                            /       \
                           /         \
                          0           0
                           \
                            \
                             3
             */


            if (root == null) return 0;
            int left = this.Distribute(root.left, ref numOfSteps); // 1
            int right = this.Distribute(root.right, ref numOfSteps); //-1
            numOfSteps += Math.Abs(left) + Math.Abs(right); //2
            return root.data - 1 + left + right; //
        }

        private void btn_Sum_of_two_Linked_list_and_get_the_linklist_of_the_sum_in_reverse_order_Click(object sender, EventArgs e)
        {
            /*
            
                Time Complexity     : O(N+M) where n is the length of the List 1 and m is the length of the list 2
                Space Complexity    : O(N) where n is the length of the addition of list 1 and list 2

                Let's represent an integer in a linked list format by having each node represent a digit in the number. The nodes make up the number in reversed order.
                For example, the following linked list:

                1 -> 2 -> 3 -> 4 -> 5
                is the number 54321.

                Given two linked lists in this format, return their sum in the same linked list format.

                For example, given

                9 -> 9
                5 -> 2
                return 124 (99 + 25) as: 124

                4 -> 2 -> 1
            */


            LinkList LLNodeFirst1 = null;
            LLNodeFirst1 = InsertLinkList(LLNodeFirst1, 9);
            LLNodeFirst1 = InsertLinkList(LLNodeFirst1, 9);

            LinkList LLNodeFirst2 = null;
            LLNodeFirst2 = InsertLinkList(LLNodeFirst2, 5);
            LLNodeFirst2 = InsertLinkList(LLNodeFirst2, 2);
            LLNodeFirst2 = InsertLinkList(LLNodeFirst2, 1);

            int sum = this.GetIntDataFromListInTheReverseOrder(LLNodeFirst1) + this.GetIntDataFromListInTheReverseOrder(LLNodeFirst2);

            int reminder = 0;
            int quotent = sum;
            LinkList start = null;
            LinkList temp = null;

            while (quotent > 0)
            {
                reminder = quotent % 10;
                if (start == null)
                {
                    start = new LinkList() { data = reminder }; //4
                    temp = start;
                }
                else
                {
                    temp.next = new LinkList() { data = reminder };
                    temp = temp.next;
                }

                quotent /= 10;
            }

            MessageBox.Show($"Sum of the given link list \n {this.GetLinkListData(LLNodeFirst1)} \n {this.GetLinkListData(LLNodeFirst2)}  \n is {sum} and " +
                            $"corresponding link list in the reverse order is \n {this.GetLinkListData(start)}");
        }

        private int GetIntDataFromListInTheReverseOrder(LinkList linkList)
        {

            if (linkList != null)
            {
                int pow = 0;
                int result = 0;
                while (linkList != null)
                {
                    result = result + (linkList.data * (int)Math.Pow(10.00, pow));
                    linkList = linkList.next;
                    pow++;
                }
                return result;

            }
            return 0;

        }

        private void btn_Remove_Item_from_sorted_Linked_List_Click(object sender, EventArgs e)
        {
            /*
                Time Complexity : O(N) where N is the list of node 
                Space Complexity: O(1) constanct space
             */

            LinkList LLNodeFirst = null;
            LLNodeFirst = InsertLinkList(LLNodeFirst, 1);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 1);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 2);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 3);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 4);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 5);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 5);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 5);
            datas.Clear();
            DisplayLinkList(LLNodeFirst);

            LinkList p = LLNodeFirst;
            LinkList c = p.next;

            while (c != null)
            {
                if (p.data == c.data)
                {
                    p.next = c.next;
                    c = p.next;
                }
                else
                {
                    p = p.next;
                    c = c.next;
                }
            }

            datas.AppendLine();
            DisplayLinkList(LLNodeFirst);
            MessageBox.Show(datas.ToString());
        }

        private void btn_Arrange_Even_And_Odd_Click(object sender, EventArgs e)
        {
            //Refer : http://www.geeksforgeeks.org/rearrange-a-given-linked-list-in-place/
            //Time complexity : O(n)
            /*
              Input     :   1->2->3->4->5
              Output    :   1->3->2->5->4
            */
            LinkList linkList = null;
            linkList = InsertLinkList(linkList, 1);
            linkList = InsertLinkList(linkList, 2);
            linkList = InsertLinkList(linkList, 3);
            linkList = InsertLinkList(linkList, 4);
            linkList = InsertLinkList(linkList, 5);
            linkList = InsertLinkList(linkList, 6);
            linkList = InsertLinkList(linkList, 7);
            linkList = InsertLinkList(linkList, 8);
            linkList = InsertLinkList(linkList, 9);
            linkList = InsertLinkList(linkList, 10);
            datas.Append("Before Arrange \n");
            DisplayLinkList(linkList);
            datas.Append("\nAfter Arrange \n");
            this.RearrangeEventOdd(linkList);
            DisplayLinkList(linkList);
            MessageBox.Show(datas.ToString());

        }


        private void RearrangeEventOdd(LinkList linkList)
        {
            if (linkList == null)
            {
                return;
            }


            LinkList pointer = linkList;
            LinkList even = linkList.next;
            LinkList odd = even != null ? even.next : null;
            LinkList t;
            // 1->2->3->4->5

            while (odd != null && even != null)
            {
                t = odd.next;
                odd.next = null;
                pointer.next = odd;
                odd.next = even;
                even.next = t;
                pointer = even;
                even = even.next;
                odd = even != null ? even.next : null;
            }
        }

        private void btn_Remove_Nth_Node_From_End_of_List_Click(object sender, EventArgs e)
        {
            /*
        
                Given a linked list, remove the n-th node from the end of list and return its head.

                Example:

                Given linked list: 1->2->3->4->5, and n = 2.

                After removing the second node from the end, the linked list becomes 1->2->3->5.
                Note:

                Given n will always be valid.

             */

            LinkList linkList = null;
            linkList = InsertLinkList(linkList, 1);
            linkList = InsertLinkList(linkList, 2);
            linkList = InsertLinkList(linkList, 3);
            linkList = InsertLinkList(linkList, 4);
            linkList = InsertLinkList(linkList, 5);
            datas.Append("Before Delete \n");
            DisplayLinkList(linkList);

            linkList = this.RemoveNthFromEnd(linkList, 10);

            datas.Append("After Delete \n");
            DisplayLinkList(linkList);

            MessageBox.Show(datas.ToString());

        }

        public LinkList RemoveNthFromEnd(LinkList head, int n)
        {
            if (head == null || n == 0)
            {
                return head;
            }

            LinkList lead = head;
            LinkList chase = head;
            LinkList prev = null;

            while (n > 0)
            {
                if (lead == null)
                {
                    return null;
                }

                lead = lead.next;
                n--;
            }

            while (lead != null)
            {
                prev = chase;
                chase = chase.next;
                lead = lead.next;
            }

            if (prev == null)
            {
                head = head.next;
            }
            else
            {
                prev.next = chase.next;
            }

            return head;
        }

        private void btn_MiddleNode_Click(object sender, EventArgs e)
        {
            LinkList linkList = null;
            linkList = InsertLinkList(linkList, 1);
            linkList = InsertLinkList(linkList, 2);
            linkList = InsertLinkList(linkList, 3);
            linkList = InsertLinkList(linkList, 4);
            linkList = InsertLinkList(linkList, 5);
            linkList = InsertLinkList(linkList, 6);
            datas.Clear();
            datas.Append("Before\n");
            DisplayLinkList(linkList);
            LinkList result = this.MiddleNode(linkList);
            datas.AppendLine("After \n");
            DisplayLinkList(result);

            MessageBox.Show(datas.ToString());
        }

        public LinkList MiddleNode(LinkList head)
        {

            if (head == null)
            {
                return head;
            }

            LinkList runner = head;

            int i = 0;

            while (runner != null)
            {
                runner = runner.next;
                i++;
            }

            i = (i / 2);
            runner = head;

            for (int j = 0; j < i; j++)
            {
                runner = runner.next;
            }

            return runner;
        }

        private string GetOddEvenListData(ListNode head)
        {
            StringBuilder result = new StringBuilder();

            while (head != null)
            {
                result.Append($"{head.val}->");
                head = head.next;
            }
            result.Append("NULL");
            return result.ToString();

        }

        public ListNode OddEvenList(ListNode head)
        {
            ListNode runner = head;
            ListNode odd = null;
            ListNode even = null;
            ListNode evenStart = null;

            if (runner == null)
                return runner;

            odd = runner;
            even = runner.next;
            evenStart = even;

            while (odd != null && odd.next != null && even != null && even.next != null)
            {
                odd.next = odd.next.next;
                even.next = even.next.next;
                odd = odd.next;
                even = even.next;
            }

            odd.next = evenStart;

            return head;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
        }

        public ListNode InsertListNode(int[] data)
        {

            if (data == null || data.Length == 0)
                return null;

            ListNode listNode = null;
            ListNode result = null;


            foreach (int i in data)
            {

                if (listNode == null)
                {
                    listNode = new ListNode() { val = i };
                    result = listNode;
                }
                else
                {
                    listNode.next = new ListNode() { val = i };
                    listNode = listNode.next;
                }
            }

            return result;
        }
        private void btn_Odd_Even_Linked_List_Click(object sender, EventArgs e)
        {

            /*

                Given a singly linked list, group all odd nodes together followed by the even nodes. Please note here we are talking about the node number and not the value in the nodes.

                You should try to do it in place. The program should run in O(1) space complexity and O(nodes) time complexity.

                Example 1:

                Input: 1->2->3->4->5->NULL
                Output: 1->3->5->2->4->NULL
                Example 2:

                Input: 2->1->3->5->6->4->7->NULL
                Output: 2->3->6->7->1->5->4->NULL


                Time Complexity     : O(N)
                Space Complxity     : (1)


            */


            StringBuilder result = new StringBuilder();
            List<ListNode> inputs = new List<ListNode>();
            inputs.Add(this.InsertListNode(new int[] { 1, 2, 3, 4, 5, 6 }));
            inputs.Add(this.InsertListNode(new int[] { 2, 1, 3, 5, 6, 4, 7 }));
            string temp = string.Empty;
            foreach(var input in inputs)
            {
                temp = this.GetOddEvenListData(input);
                result.AppendLine($"The Odd Even Linked List is {this.GetOddEvenListData(this.OddEvenList(input))} for the given list {temp}");
            }
            
            MessageBox.Show(result.ToString());

        }



        private void btn_Delete_Node_in_a_Linked_List_Click(object sender, EventArgs e)
        {
            /*
             
                    Write a function to delete a node (except the tail) in a singly linked list, given only access to that node.
                    Given linked list -- head = [4,5,1,9], which looks like following:

                    Example 1:
                    Input: head = [4,5,1,9], node = 5
                    Output: [4,1,9]
                    Explanation: You are given the second node with value 5, the linked list should become 4 -> 1 -> 9 after calling your function.

                    Example 2:
                    Input: head = [4,5,1,9], node = 1
                    Output: [4,5,9]
                    Explanation: You are given the third node with value 1, the linked list should become 4 -> 5 -> 9 after calling your function.

                    Note:

                    The linked list will have at least two elements.
                    All of the nodes' values will be unique.
                    The given node will not be the tail and it will always be a valid node of the linked list.
                    Do not return anything from your function.

                Time Complexity     : O(1) 
                Space Complexity    : O(1)
             */

            StringBuilder result = new StringBuilder();
            List<Common> inputs = new List<Common>();
            ListNode temp = this.InsertListNode(new int[] { 4, 5, 1, 6 });
            inputs.Add(new Common() {Node1 = temp, Node2 = this.GetListNode(temp, 5)});
            temp = this.InsertListNode(new int[] { 4, 5, 1, 6 });
            inputs.Add(new Common() { Node1 = temp, Node2 = this.GetListNode(temp, 1) });

            foreach (var input in inputs)
            {                
                result.AppendLine($"Before deleting ListNode {this.GetListNodeData(input.Node1)} and after delete");
                this.DeleteNode(input.Node2);
                result.Append($"{this.GetListNodeData(input.Node1)} {Environment.NewLine}");
            }

            MessageBox.Show(result.ToString());
        }

        private string GetListNodeData(ListNode linkList)
        {
            StringBuilder result = new StringBuilder();
            while (linkList != null)
            {
                result.Append($" {linkList.val} ");
                linkList = linkList.next;
            }

            return result.ToString();
        }


        public class Common
        {
            public ListNode Node1;
            public ListNode Node2;
            public int Find;
            public int Left;
            public int Right;

        }


        public ListNode GetListNode(ListNode node, int data)
        {
            ListNode result = node;
            while (result != null)
            {
                if (result.val == data)
                {
                    return result;
                }
                result = result.next;
            }
            return result;
        }

        
        public void DeleteNode(ListNode node)
        { 
            if (node == null)
                return;

            if (node.next != null)
            {
                node.val = node.next.val;
                node.next = node.next.next;
            }
        }

        private void btn_Remove_Linked_List_Elements_Click(object sender, EventArgs e)
        {

            /*

                Remove all elements from a linked list of integers that have value val.

               Example:

               Input:  1->2->6->3->4->5->6, val = 6
               Output: 1->2->3->4->5

               Time Complexity     : O(N) 
               Space Complexity    : O(1)
          */

            StringBuilder result = new StringBuilder();
            List<Common> inputs = new List<Common>();
            inputs.Add(new Common() { Node1 = this.InsertListNode(new int[] { 1, 2, 3, 4, 5, 6 }), Find = 6 });
            inputs.Add(new Common() { Node1 = this.InsertListNode(new int[] { 6 }), Find = 6 });
            inputs.Add(new Common() { Node1 = this.InsertListNode(new int[] { }), Find = 6 });

            foreach (var input in inputs)
            {
                result.AppendLine($"Before deleting ListNode {this.GetListNodeData(input.Node1)} and after delete {this.GetListNodeData(this.RemoveElements(input.Node1, input.Find))}");
            }

            MessageBox.Show(result.ToString());

        }


        public ListNode RemoveElements(ListNode head, int val)
        {


            if (head == null)
                return null;

            // 1->2->6->3->4->5->6, val = 6
            // 3->4->5->6, val = 6

            while (head != null && head.val == val)
            {
                head = head.next;
            }

            
            ListNode curr = head;

            while (curr.next != null)
            {
                if (curr.next.val == val)
                {
                    curr.next = curr.next.next;
                }
                else
                {
                    curr = curr.next;
                }
            }

            return head;

        }

        private void btn_Rotate_List_Click(object sender, EventArgs e)
        {            

            /*
                Given a linked list, rotate the list to the right by k places, where k is non-negative.

                Example 1:

                Input: 1->2->3->4->5->NULL, k = 2
                Output: 4->5->1->2->3->NULL
                Explanation:
                rotate 1 steps to the right: 5->1->2->3->4->NULL
                rotate 2 steps to the right: 4->5->1->2->3->NULL
                Example 2:

                Input: 0->1->2->NULL, k = 4
                Output: 2->0->1->NULL
                Explanation:
                rotate 1 steps to the right: 2->0->1->NULL
                rotate 2 steps to the right: 1->2->0->NULL
                rotate 3 steps to the right: 0->1->2->NULL
                rotate 4 steps to the right: 2->0->1->NULL
             

                Time Complexity     : O(N)
                Space Complexity    : O(1)

             */


            StringBuilder result = new StringBuilder();
            List<Common> inputs = new List<Common>();
            inputs.Add(new Common() { Node1 = this.InsertListNode(new int[] { 1, 2, 3, 4, 5 }), Find = 2 });
            inputs.Add(new Common() { Node1 = this.InsertListNode(new int[] { 0,1, 2 }), Find = 4 });
            

            foreach (var input in inputs)
            {
                result.AppendLine($"Rotate List for the given list {this.GetListNodeData(input.Node1)}  is  {this.GetListNodeData(this.RotateRight(input.Node1, input.Find))}");
            }

            MessageBox.Show(result.ToString());

        }


        public ListNode RotateRight(ListNode head, int k)
        {

            if (head == null)
                return head;


            int len = 0;
            ListNode current = head;
            ListNode temp = head;
          
            while (current.next != null)
            {
                current = current.next;
                len++;
            }
            len++;

            current.next = head;
            current = head;

            len = len - (k % len) -1;

            while(len > 0)
            {
                current = current.next;
                len--;
            }

            temp = current.next;
            current.next = null;
            head = temp;

            return head;
        }

        private void btn_Sort_List_Click(object sender, EventArgs e)
        {
            /*
                Given the head of a linked list, return the list after sorting it in ascending order.

                Follow up: Can you sort the linked list in O(n logn) time and O(1) memory (i.e. constant space)?
 
                Example 1:


                Input: head = [4,2,1,3]
                Output: [1,2,3,4]
                Example 2:


                Input: head = [-1,5,3,4,0]
                Output: [-1,0,3,4,5]
                Example 3:

                Input: head = []
                Output: []
 

                Constraints:

                The number of nodes in the list is in the range [0, 5 * 104].
                -105 <= Node.val <= 105
             
             */


            StringBuilder result = new StringBuilder();
            List<ListNode> inputs = new List<ListNode>();
            //inputs.Add(this.InsertListNode(new int[] { 4,2,1, 3}));
            //inputs.Add(this.InsertListNode(new int[] { -1, 5, 3, 4, 0 }));
            inputs.Add(this.InsertListNode(new int[] { 3, 2, 4 }));
            
            foreach (var input in inputs)
            {
                result.AppendLine($"Sorted List for the given list {this.GetListNodeData(input)}  is  {this.GetListNodeData(this.SortList(input))}");
            }

            MessageBox.Show(result.ToString());
        }

        public ListNode SortList(ListNode head)
        {

            if (head == null || head.next == null)
                return head;

            ListNode mid = GetMiddle(head); 
            ListNode left = SortList(head); 
            ListNode right = SortList(mid);

            

            return MergeList(left, right);



        }


        private ListNode MergeList(ListNode left, ListNode right)
        {

            

            ListNode L1 = left;
            ListNode L2 = right;
            ListNode L2p = right;

            if (L1 == null || L2 == null)
                return null;
            else if (L1 == null && L2 != null)
                return L2;
            else if (L1 != null && L2 == null)
                return L1;

            /*
              L1:3
              L2:4                          
            */
            
            ListNode temp = null;

            while (L1!=null && L2!= null )
            {               

                if (L1.val > L2.val)
                {
                    temp = L1.next;
                    L1.next = null;
                    L1.next = L2.next;
                    L2.next = L1;
                    L1 = temp;
                    L2 = L2.next.next;
                }
                else
                {
                   
                    temp = L1.next;
                    L1.next = null;
                    L1.next = L2;
                    L2 = L1;
                    L1 = temp;
                    L2p = L2.next;
                    L2 = L2.next;
                    right = left;
                }
            }
           
            return right;
        }

        private ListNode GetMiddle(ListNode head) 
        {            
            ListNode slow = head;
            ListNode fast = head.next;
            ListNode med = head;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            med = slow.next;
            slow.next = null;
            
            return med;

        }

        private void btn_Linked_List_Cycle_II_Click(object sender, EventArgs e)
        {
            /*
        
                Given a linked list, return the node where the cycle begins. If there is no cycle, return null.

                There is a cycle in a linked list if there is some node in the list that can be reached again by continuously following the next pointer. Internally, pos is used to denote the index of the node that tail's next pointer is connected to. Note that pos is not passed as a parameter.

                Notice that you should not modify the linked list.

                Follow up:

                Can you solve it using O(1) (i.e. constant) memory?

 

                Example 1:
                Input: head = [3,2,0,-4], pos = 1
                Output: tail connects to node index 1
                Explanation: There is a cycle in the linked list, where tail connects to the second node.
                
                3-->2-->0-->-4
                    |--------|


                Example 2:
                Input: head = [1,2], pos = 0
                Output: tail connects to node index 0
                Explanation: There is a cycle in the linked list, where tail connects to the first node.
                Example 3:

                Input: head = [1], pos = -1
                Output: no cycle
                Explanation: There is no cycle in the linked list.
 

                Constraints:

                The number of the nodes in the list is in the range [0, 104].
                -105 <= Node.val <= 105
                pos is -1 or a valid index in the linked-list.


                Time Complexity     :   O(N)
                Space Complexity    :   O(1)

            */


            StringBuilder result = new StringBuilder();
            List<Common> inputs = new List<Common>();            
            inputs.Add(new Common() { Node1 = this.InsertListNode(new int[] { 3, 2, 0, 4 }), Find = 2 });
            inputs.Add(new Common() { Node1 = this.InsertListNode(new int[] { 1, 2 }), Find = 1 });
            inputs.Add(new Common() { Node1 = this.InsertListNode(new int[] { 1 }), Find = 0 });


            ListNode resNode = null;
            foreach (var input in inputs)
            {
                
                result.AppendLine($"Linked List Cycle II for the given list {this.GetListNodeData(input.Node1)}  is ");
                resNode = this.DetectCycle(MakeCyclicLinkedList(input.Node1, input.Find));
                result.AppendLine($"{(resNode == null ? "not exists" : resNode.val.ToString())}");
            }

            MessageBox.Show(result.ToString());

        }


        public ListNode MakeCyclicLinkedList(ListNode node, int index)
        {
            if (node == null || index == 0)
                return node;

            ListNode runner = node;
            ListNode indexNode = node;


            while (runner.next!= null)
            {
                if (index-1 > 0)
                {
                    indexNode = indexNode.next;
                    index--;
                }

                runner = runner.next;
            }

            runner.next = indexNode;

            return node;

        }


        public ListNode DetectCycle(ListNode head)
        {

            if (head == null)
                return head;

            ListNode slow = head;
            ListNode fast = slow;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;

                if (slow == fast)
                {
                    slow = head;

                    while (slow != fast)
                    {
                        slow = slow.next;
                        fast = fast.next;
                    }

                    return slow;
                }

            }


            return null;
        }

        private void btn_Add_Two_Numbers_II_Click(object sender, EventArgs e)
        {
            /*
        
                You are given two non-empty linked lists representing two non-negative integers. The most significant digit comes first and each of their nodes contain a single digit. 
                Add the two numbers and return it as a linked list.

                You may assume the two numbers do not contain any leading zero, except the number 0 itself.

                Follow up:
                What if you cannot modify the input lists? In other words, reversing the lists is not allowed.

                Example:

                Input: (7 -> 2 -> 4 -> 3) + (5 -> 6 -> 4)
                Output: 7 -> 8 -> 0 -> 7

                Time Complexity     :   O(N+M)
                Space Complexity    :   O(N+M)
                
            */



            StringBuilder result = new StringBuilder();
           List<Common> inputs = new List<Common>();            
           //inputs.Add(new Common() { Node1 = this.InsertListNode(new int[] { 7,2,4,3}), Node2 = this.InsertListNode(new int[] { 5,6,4}) });
           //inputs.Add(new Common() { Node1 = this.InsertListNode(new int[] { 0}), Node2 = this.InsertListNode(new int[] { 0 }) });
           inputs.Add(new Common() { Node1 = this.InsertListNode(new int[] { 3, 9, 9, 9, 9, 9, 9, 9, 9, 9 }), Node2 = this.InsertListNode(new int[] { 7 } )});
           inputs.Add(new Common() { Node1 = this.InsertListNode(new int[] {5 }), Node2 = this.InsertListNode(new int[] { 5 }) });



            foreach (var input in inputs)
            {

                result.AppendLine($"Add Two Numbers_2 for the given list1 :  {this.GetListNodeData(input.Node1)} and list2: {this.GetListNodeData(input.Node1)} is {this.GetListNodeData(this.AddTwoNumbers(input.Node1, input.Node2))}  ");
            }

            MessageBox.Show(result.ToString());
        
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {

            if (l1 == null)
                return l2;

            if (l2 == null)
                return l1;


            ListNode result = null;
            ListNode temp = null;

            Stack<int> ls1 = this.FillStack(l1);
            Stack<int> ls2 = this.FillStack(l2);
            int reminder = 0;
            int sum = 0;


            while (ls1.Count > 0 || ls2.Count > 0)
            {
                sum = (ls1.Count > 0 ?ls1.Pop() : 0 ) + (ls2.Count > 0 ? ls2.Pop() : 0)+ reminder;

                reminder = sum / 10;
                if (sum > 9)
                    sum = sum % 10;

                if (result == null)
                    result = new ListNode() { val = sum };
                else
                {
                    temp = new ListNode() { val = sum };
                    temp.next = result;
                    result = temp;
                }
            }

            
            if (reminder > 0)
            {
                temp = new ListNode() { val = reminder };
                temp.next = result;
                result = temp;
            }


            return result;


        }

        private Stack<int> FillStack(ListNode list)
        {
            if (list == null)
                return new Stack<int>();

            Stack<int> result = new Stack<int>();

            while (list != null)
            {
                result.Push(list.val);
                list = list.next;
            }

            return result;
        }

        private void btn_Convert_Binary_Number_in_a_Linked_List_to_Integer_Click(object sender, EventArgs e)
        {
            /*
            

            Given head which is a reference node to a singly-linked list. The value of each node in the linked list is either 0 or 1. The linked list holds the binary representation of a number.

            Return the decimal value of the number in the linked list.

            Example 1:
                    1----->0------->1


            Input: head = [1,0,1]
            Output: 5
            Explanation: (101) in base 2 = (5) in base 10
            Example 2:

            Input: head = [0]
            Output: 0
            Example 3:

            Input: head = [1]
            Output: 1
            Example 4:

            Input: head = [1,0,0,1,0,0,1,1,1,0,0,0,0,0,0]
            Output: 18880
            Example 5:

            Input: head = [0,0]
            Output: 0
 

            Constraints:

            The Linked List is not empty.
            Number of nodes will not exceed 30.
            Each node's value is either 0 or 1.
               Hide Hint #1  
            Traverse the linked list and store all values in a string or array. convert the values obtained to decimal value.
               Hide Hint #2  
            You can solve the problem in O(1) memory using bits operation. use shift left operation ( << ) and or operation ( | ) to get the decimal value in one operation.
             
             */


            StringBuilder result = new StringBuilder();
            List<Common> inputs = new List<Common>();
            inputs.Add(new Common() { Node1 = this.InsertListNode(new int[] { 1, 0, 1 }) });
            inputs.Add(new Common() { Node1 = this.InsertListNode(new int[] {0}) });
            inputs.Add(new Common() { Node1 = this.InsertListNode(new int[] { 1}) });
            inputs.Add(new Common() { Node1 = this.InsertListNode(new int[] { 1, 0, 0, 1, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0 }) });
            inputs.Add(new Common() { Node1 = this.InsertListNode(new int[] { 0,0 }) });



            foreach (var input in inputs)
            {

                result.AppendLine($"Coversation of Binary Number in a Linked List to Integer for the given list1 :  {this.GetListNodeData(input.Node1)} is {this.GetDecimalValue(input.Node1)}  ");
            }

            MessageBox.Show(result.ToString());
        }

        public int GetDecimalValue(ListNode head)
        {
            if (head == null)
                return 0;

            int result = 0;

            while (head != null)
            {
                result = (result << 1) + head.val;
                head = head.next;
            }

            return result;

        }

        private void btn_Linked_List_Random_Node_Click(object sender, EventArgs e)
        {
            /*
                Given a singly linked list, return a random node's value from the linked list. Each node must have the same probability of being chosen.

                Follow up:
                What if the linked list is extremely large and its length is unknown to you? Could you solve this efficiently without using extra space?

                Example:

                // Init a singly linked list [1,2,3].
                ListNode head = new ListNode(1);
                head.next = new ListNode(2);
                head.next.next = new ListNode(3);
                Solution solution = new Solution(head);

                // getRandom() should return either 1, 2, or 3 randomly. Each element should have equal probability of returning.
                solution.getRandom();

                Time Complexity     : O(N)
                Space Complexity    : O(1)
             
             */

            StringBuilder result = new StringBuilder();
            List<Common> inputs = new List<Common>();
            inputs.Add(new Common() { Node1 = this.InsertListNode(new int[] { 1,2,3 }), Find = 3 });
            inputs.Add(new Common() { Node1 = this.InsertListNode(new int[] { 1 }), Find = 3});
           

            foreach (var input in inputs)
            {
                RandonLinkListSolution s = new RandonLinkListSolution(input.Node1);
                StringBuilder temp = new StringBuilder();
                for (int i = 1; i <= input.Find;i++)
                {
                    temp.AppendLine($"{s.GetRandom()}");
                }
                result.AppendLine($"Random nodes from the given linked list {this.GetListNodeData(input.Node1)} are below {Environment.NewLine}{temp.ToString()}");
            }

            MessageBox.Show(result.ToString());

        }

        public class RandonLinkListSolution
        {

            Random rand = null;
            ListNode root = null;

            public RandonLinkListSolution(ListNode head)
            {
                rand = new Random();
                root = head;

            }

            public int GetRandom()
            {
                int k = 0;
                int result = 0;
                ListNode node = root;
                while (node != null)
                {
                    k++;

                    if ((rand.Next() % k) == 0)
                    {
                        result = node.val;
                    }
                    node = node.next;
                }

                return result;
            }
        }

        private void btn_Swap_Nodes_in_Pairs_Click(object sender, EventArgs e)
        {
            /*
             
                Given a linked list, swap every two adjacent nodes and return its head.

                You may not modify the values in the list's nodes. Only nodes itself may be changed.

                Example 1:

                1->2->3->4
                2->1->4->3

                Input: head = [1,2,3,4]
                Output: [2,1,4,3]
                Example 2:

                Input: head = []
                Output: []
                Example 3:

                Input: head = [1]
                Output: [1]
 

                Constraints:

                The number of nodes in the list is in the range [0, 100].
                0 <= Node.val <= 100

                Time Complexity     : O(N)
                Space Complexity    : O(1)
             */


            StringBuilder result = new StringBuilder();
            List<Common> inputs = new List<Common>();
            inputs.Add(new Common() { Node1 = this.InsertListNode(new int[] { 1, 2, 3, 4 })});
            inputs.Add(new Common() { Node1 = this.InsertListNode(new int[] { 1 })});


            foreach (var input in inputs)
            {                
                result.AppendLine($"Swap Nodes in Pairs from the given linked list {this.GetListNodeData(input.Node1)} is {Environment.NewLine} Approach 1 : {this.GetListNodeData(SwapPairs_1(input.Node1))} \n Approach 1 : {this.GetListNodeData(SwapPairs_2(input.Node1))}");
            }

            MessageBox.Show(result.ToString());
        }



        public ListNode SwapPairs_2(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            ListNode dummy = new ListNode();
            dummy.next = head;
            ListNode prev = dummy;

            while (head != null && head.next != null)
            {
                ListNode first = head;
                ListNode second = head.next;

                // Swap
                prev.next = second;
                first.next = second.next;
                second.next = first;

                // Move pointers forward
                prev = first;
                head = first.next;
            }

            return dummy.next;
        }

        public ListNode SwapPairs_1(ListNode head)
        {
            if (head == null)
                return head;
            return this.Swap(head);
        }


        private ListNode Swap(ListNode head)
        {
            ListNode root = new ListNode();
            ListNode runner = root;
            runner.next = head;

            ListNode previous = null;
            ListNode current = null;

            while (runner != null && runner.next != null && runner.next.next != null)
            {
                previous = runner.next;
                current = previous.next;
                runner.next = current;
                previous.next = current.next;
                current.next = previous;                
                runner = previous;
            }

            return root.next;
        }

        private void btn_Remove_Duplicates_from_Sorted_List_II_Click(object sender, EventArgs e)
        {
            /*
                Given the head of a sorted linked list, delete all nodes that have duplicate numbers, leaving only distinct numbers from the original list. Return the linked list sorted as well.
                Example 1:

                Input: head = [1,2,3,3,4,4,5]
                Output: [1,2,5]
            
                Example 2:
                Input: head = [1,1,1,2,3]
                Output: [2,3]
 
                Constraints:

                The number of nodes in the list is in the range [0, 300].
                -100 <= Node.val <= 100
                The list is guaranteed to be sorted in ascending order.
             
                Time Complexity     : O(N)
                Space Complexity    : O(1)

             */

            StringBuilder result = new StringBuilder();
            List<Common> inputs = new List<Common>();
            inputs.Add(new Common() { Node1 = this.InsertListNode(new int[] { 1, 2, 3, 3, 4, 4, 5 }) });
            inputs.Add(new Common() { Node1 = this.InsertListNode(new int[] { 1, 1, 1, 2, 3 }) });
            inputs.Add(new Common() { Node1 = this.InsertListNode(new int[] { 1, 1, 1 }) });
            inputs.Add(new Common() { Node1 = this.InsertListNode(new int[] { 1, 2, 2 }) });


            foreach (var input in inputs)
            {
                result.AppendLine($"Remove Duplicates from Sorted List II for the given {this.GetListNodeData(input.Node1)} is {Environment.NewLine}{this.GetListNodeData(DeleteDuplicates(input.Node1))}");
            }

            MessageBox.Show(result.ToString());

        }

        public ListNode DeleteDuplicates(ListNode head)
        {
            /* 1,2,3,3,4,4,5
               1,1,1,2,3
               1,2,2,3,3
               1
            */

            if (head == null)
                return head;

            while (head != null && head.next != null && head.val == head.next.val)
            {
                head = RemoveDuplicate(head, head.val);
            }

            ListNode current = head != null ? head.next : null;
            ListNode prev = head;


            while (current != null)
            {
                if (current.next != null && current.val == current.next.val)
                {
                    current = RemoveDuplicate(current, current.val);
                    prev.next = current;
                }
                else
                {
                    prev = current;
                    current = current.next;
                }                
            }

            return head;
        }

        public ListNode RemoveDuplicate(ListNode current, int val)
        {

            if (current == null)
                return current;

            while (current != null && current.val == val)
            {
                current = current.next;
            }

            return current;

        }

        private void btn_Reverse_Linked_List_II_Click(object sender, EventArgs e)
        {
            /*
                Given the head of a singly linked list and two integers left and right where left <= right, reverse the nodes of the list from position left to position right, and return the reversed list.

                Example 1:


                Input: head = [1,2,3,4,5], left = 2, right = 4
                Output: [1,4,3,2,5]
                Example 2:

                Input: head = [5], left = 1, right = 1
                Output: [5]
 
                Constraints:

                The number of nodes in the list is n.
                1 <= n <= 500
                -500 <= Node.val <= 500
                1 <= left <= right <= n
 

                Follow up: Could you do it in one pass?

                TC : O(N)

            */

            StringBuilder result = new StringBuilder();
            List<Common> inputs = new List<Common>();
            inputs.Add(new Common() { Node1 = this.InsertListNode(new int[] { 1, 2, 3, 4, 5 }),Left=2,Right=4 });
            inputs.Add(new Common() { Node1 = this.InsertListNode(new int[] { 1, 2, 3, 4, 5 }), Left = 4, Right = 5 });
            inputs.Add(new Common() { Node1 = this.InsertListNode(new int[] { 5 }), Left = 1, Right = 1 });
            inputs.Add(new Common() { Node1 = this.InsertListNode(new int[] { 3,5 }), Left = 1, Right = 2 });
            

            foreach (var input in inputs)
            {
                result.AppendLine($"Reverse Linked List II for the given {this.GetListNodeData(input.Node1)} is {Environment.NewLine}{this.GetListNodeData(ReverseBetween(input.Node1, input.Left, input.Right))}");
            }

            MessageBox.Show(result.ToString());
        }


        public ListNode ReverseBetween(ListNode head, int left, int right)
        {
            if (left == right)
                return head;

            ListNode dummy = new ListNode() { val = -1, next = head };
            ListNode start = dummy;
            ListNode prev = null;
            ListNode revNode = null;
            ListNode temp = null;
            ListNode it = null;
            ListNode revStartNode = null;
           

            for (int i = 0; i < left; i++)
            {
                prev = start;
                start = start.next;
            }

            it = start;

            for (int i = left; i <= right; i++)
            {
                temp = it.next;
                it.next = revNode;
                revNode = it;
                it = temp;

                if (revStartNode == null)
                    revStartNode = revNode;
            }



            prev.next = revNode;
            revStartNode.next = it;

            return dummy.next;




        }

        private void btn_Reverse_Nodes_in_k_Group_Click(object sender, EventArgs e)
        {
            /*
             
                Given a linked list, reverse the nodes of a linked list k at a time and return its modified list.

                k is a positive integer and is less than or equal to the length of the linked list. If the number of nodes is not a multiple of k then left-out nodes, in the end, should remain as it is.

                You may not alter the values in the list's nodes, only nodes themselves may be changed.

 

                Example 1:


                Input: head = [1,2,3,4,5], k = 2
                Output: [2,1,4,3,5]
                Example 2:


                Input: head = [1,2,3,4,5], k = 3
                Output: [3,2,1,4,5]
                Example 3:

                Input: head = [1,2,3,4,5], k = 1
                Output: [1,2,3,4,5]
                Example 4:

                Input: head = [1], k = 1
                Output: [1]
 

                Constraints:

                The number of nodes in the list is in the range sz.
                1 <= sz <= 5000
                0 <= Node.val <= 1000
                1 <= k <= sz
 

                Follow-up: Can you solve the problem in O(1) extra memory space?


             */

            StringBuilder result = new StringBuilder();
            List<Common> inputs = new List<Common>();
            inputs.Add(new Common() { Node1 = this.InsertListNode(new int[] { 1, 2, 3, 4, 5 }), Find = 2 });
            inputs.Add(new Common() { Node1 = this.InsertListNode(new int[] { 1, 2, 3, 4, 5 }), Find = 3 });
            inputs.Add(new Common() { Node1 = this.InsertListNode(new int[] { 1, 2, 3, 4, 5 }), Find = 1 });
            inputs.Add(new Common() { Node1 = this.InsertListNode(new int[] { 1}), Left = 1, Find = 1 });
            inputs.Add(new Common() { Node1 = this.InsertListNode(new int[] { 1, 2 }), Left = 1, Find = 2 });


            foreach (var input in inputs)
            {
                result.AppendLine($"ReverseReverse Nodes in k-Group for the given list {this.GetListNodeData(input.Node1)}  and K : {input.Find} is {Environment.NewLine}{this.GetListNodeData(ReverseKGroup_New(input.Node1, input.Find))}");
            }

            MessageBox.Show(result.ToString());

        }

        public ListNode ReverseKGroup_New(ListNode head, int k)
        {
            if (head == null || k == 0)
                return null;

            ListNode result = new ListNode();
            ListNode tail = result;
            ListNode current = head;
            ListNode temp = null;
            Stack<ListNode> dict = new Stack<ListNode>();

            while(current!=null)
            {
                temp = current;
                int i = 0;
                while (temp != null && i < k)
                {
                    dict.Push(temp);
                    temp = temp.next;
                    i++;
                }
                if (i == k)
                {
                    while (dict.Count > 0)
                    {
                        tail.next = dict.Pop();
                        tail = tail.next;
                    }
                }
                else
                {
                    ListNode[] arr = dict.ToArray();
                    
                    for(int j = arr.Length -1; j >=0; j--)
                    {
                        tail.next = arr[j];
                        tail = tail.next;
                    }                    
                }
                current = temp;
            }

            tail.next = temp;

            return result.next;


        }

        public ListNode ReverseKGroup(ListNode head, int k)
        {

            if (head == null || k < 2)
                return head;

            ListNode result = new ListNode();
            ListNode rResult = result;
            int c = 0;

            while (head != null && c == 0)
            {
                while (rResult.next != null)
                    rResult = rResult.next;
                rResult.next = GetReverse(ref head, k, out c);

            }

            if (c > 0)
                rResult.next = head;

            return result.next;
        }



        private ListNode GetReverse(ref ListNode head, int k, out int c)
        {

            ListNode temp = null;
            ListNode reverse = null;
            ListNode original = new ListNode();
            ListNode cOriginal = original;

            /*        
                    [1,2,3,4,5], k = 3

                    o : 0->1->2->3
                    r : 3->2->1

            */

            while (head != null && k > 0)
            {
                cOriginal.next = new ListNode() { val = head.val };
                temp = head.next;
                head.next = reverse;
                reverse = head;
                head = temp;
                k--;
                cOriginal = cOriginal.next;
            }

            if (k > 0)
            {
                cOriginal.next = head;
                head = original.next;
            }

            c = k;
            return k == 0 ? reverse : null;


        }
    }





    class Graph
    {
        public object data;
        public List<Graph> next;
    }

    public class Node
    {
        public int data;
        public Node right;
        public Node left;
        public Node next;
    }

    class NodeWithObjectData
    {
        public object data;
        public NodeWithObjectData right;
        public NodeWithObjectData left;
    }

    class NodeWithNext
    {
        public int data;
        public NodeWithNext right;
        public NodeWithNext left;
        public NodeWithNext next;
    }

    public class BFSNode
    {
        public int data;
        public BFSNode right;
        public BFSNode left;
        public BFSNode parent;


    }

    public class LinkList
    {
        public int data;
        public LinkList next;
        public LinkList random;
    }

    public class LinkListCharacter
    {
        public char data;
        public LinkListCharacter next;
    }

    public interface ITest
    {
        void Testing();
    }

    public abstract class AbstractTest : LinkListCharacter, ITest
    {
        public abstract void TestintAbstract();
        public void TestintAbstract1()
        {

        }

        public void Testing()
        { }
    }
        
  
}
