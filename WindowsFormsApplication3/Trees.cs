using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Trees : Form
    {

        StringBuilder datas = new StringBuilder();
        public Trees()
        {
            InitializeComponent();
        }

        private void btn_Same_Tree_Click(object sender, EventArgs e)
        {
            /*
                Given two binary trees, write a function to check if they are the same or not.
                Two binary trees are considered the same if they are structurally identical and the nodes have the same value.
                Example 1:
                Input:     1         1
                          / \       / \
                         2   3     2   3

                        [1,2,3],   [1,2,3]

                Output: true
                Example 2:
                Input:     1         1
                          /           \
                         2             2

                        [1,2],     [1,null,2]

                Output: false
                Example 3:
                Input:     1         1
                          / \       / \
                         2   1     1   2

                        [1,2,1],   [1,1,2]
                Output: false             
                
                Time Complexity : O(n + m) where n is the list of nodes in Tree1 and m is the list of nodes in Tree2
                Spacd Complexity : O(1) constant space
             */



            List<TreeSame> inputs = new List<TreeSame>();
            StringBuilder result = new StringBuilder();

            Node p1 = new Node() {data = 1 };
            p1.left = new Node() { data = 2 };
            p1.right = new Node() { data = 3 };
            Node q1 = new Node() { data = 1 };
            q1.left = new Node() { data = 2 };
            q1.right = new Node() { data = 3 };
            TreeSame ts1 = new TreeSame() { Tree1 = p1, Tree2 = q1 };
            inputs.Add(ts1);
            
            Node p2 = new Node() {data = 1 };
            p2.left = new Node() { data = 2 };              
            Node q2 = new Node() { data = 1 };           
            q2.right = new Node() { data = 2 };
            TreeSame ts2 = new TreeSame() { Tree1 = p2, Tree2 = q2 };
            inputs.Add(ts2);

            Node p3 = new Node() { data = 1 };
            p3.right = new Node() { data = 1 };
            Node q3 = new Node() { data = 1 };
            q3.right = new Node() { data = 1 };
            TreeSame ts3 = new TreeSame() { Tree1 = p3, Tree2 = q3 };
            inputs.Add(ts3);

            Node p4 = new Node() { data = 10 };
            p4.left = new Node() { data = 5 };
            p4.right = new Node() { data = 15 };
            Node q4 = new Node() { data = 10 };
            q4.left = new Node() { data = 5 };            
            q4.left.right = new Node() { data = 15 };            
            TreeSame ts4 = new TreeSame() { Tree1 = p4, Tree2 = q4 };
            inputs.Add(ts4);


            Node p = null;
            Node q = null; 
            foreach (var input in inputs)
            {
                p = input.Tree1;
                q = input.Tree2;
                result.AppendLine($"The below two given trees {(this.IsSameTree(p, q) ? "Same" : "Not same")}\np: {(this.TreeTraverse(p))} \nq: {(this.TreeTraverse(q))} \n"); 
            }
            
            MessageBox.Show(result.ToString());
        }

        public class TreeSame
        {
            public Node Tree1;
            public Node Tree2;
        }

        public bool IsSameTree(Node p, Node q)
        {

            if (p == null || q == null)
            {
                return false;
            }

            Queue<Node> qp = new Queue<Node>();
            Queue<Node> qq = new Queue<Node>();

            Node tp = null;
            Node tq = null;

            qp.Enqueue(p);
            qq.Enqueue(q);

            while (qp.Count > 0 &&  qq.Count > 0)
            {

                tp = qp.Dequeue();
                tq = qq.Dequeue();

                if (
                        (tp != null && tq != null && tp.data != tq.data) ||
                         (tp != null && tq == null) ||
                         (tp == null && tq != null)
                   )
                {
                    return false;
                }

                if (tp != null && (tp.left != null || tp.right != null))
                {
                    qp.Enqueue(tp.left);
                    qp.Enqueue(tp.right);
                }

                if (tq != null && (tq.left != null || tq.right != null))
                {
                    qq.Enqueue(tq.left);
                    qq.Enqueue(tq.right);
                }

            }
            return true;
        }


        private string TreeTraverse(Node node)
        {
            StringBuilder result = new StringBuilder();
            Queue<Node> q = new Queue<Node>();
            Node t = null;
            q.Enqueue(node);

            while (q.Count > 0)
            {
                t = q.Dequeue();

                if (t!=null)
                {
                    q.Enqueue(t.left);
                    q.Enqueue(t.right);
                }
                result.Append($"{(t == null ? "NULL" : t.data.ToString())} ");
            }
            return result.ToString();

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

        public class Node
        {
            public int data;
            public Node right;
            public Node left;
        }

        private void btn_Find_Binary_is_Symmetric_Tree_Click(object sender, EventArgs e)
        {
            /*
                Given a binary tree, check whether it is a mirror of itself (ie, symmetric around its center).
                For example, this binary tree [1,2,2,3,4,4,3] is symmetric:

                    1
                   / \
                  2   2
                 / \ / \
                3  4 4  3
 

                But the following [1,2,2,null,3,null,3] is not:

                    1
                   / \
                  2   2
                   \   \
                   3    3

            Time Complexity : O(n) where n is the total number of nodes
            Space Complexity: O(1)  constant space
             */


            List<Node> inputs = new List<Node>();
            StringBuilder result = new StringBuilder();


            Node t1 = new Node() { data = 1 };
            t1.left = new Node() { data = 2 };
            t1.right = new Node() { data = 2 };
            t1.left.left = new Node() { data = 3 };
            t1.left.right = new Node() { data = 4 };
            t1.right.left = new Node() { data = 4 };
            t1.right.right = new Node() { data = 3 };
            inputs.Add(t1); //Symmetric

            Node t2 = new Node();
            inputs.Add(t2); //Symmetric

            Node t3 = new Node() {data = 2 };            
            inputs.Add(t3); //Symmetric

            Node t4 = new Node() { data = 2 };
            t4.left = new Node() { data = 3 };
            t4.right = new Node() { data = 3 };
            t4.left.left = new Node() { data = 4 };
            t4.left.right = new Node() { data = 5 };
            t4.right.left = new Node() { data = 5 };
            t4.right.right = new Node() { data = 4 };
            t4.left.right.left = new Node() { data = 8 };
            t4.left.right.right = new Node() { data = 9 };
            t4.right.right.left = new Node() { data = 9 };
            t4.right.right.right = new Node() { data = 8 };
            inputs.Add(t4); //Symmetric

            Node t5 = new Node() { data = 1 };
            t5.left = new Node() {data = 2 };
            t5.right = new Node() { data = 2 };
            t5.left.right = new Node() { data = 3 };
            t5.right.left = new Node() { data = 3 };
            inputs.Add(t5); // Symmetric

            Node t6 = new Node() { data = 2 };
            t6.left = new Node() { data = 3 };
            t6.right = new Node() { data = 3 };
            t6.left.left= new Node() { data = 4 };
            t6.left.right = new Node() { data = 5 };
            t6.right.left = new Node() { data = 5 };
            inputs.Add(t6); //non Symmetric


            foreach (var input in inputs)
            {            
                result.AppendLine($"This binary tree {(this.TreeTraverse(input))} is {(this.IsBinaryTreeSymmetric(input) ? "Symmetric" : "not symmetric")} \n");
            }

            MessageBox.Show(result.ToString());

        }

        private bool IsBinaryTreeSymmetric(Node root)
        {
            if (root == null)
            {
                return true;
            }

            Queue<Node> lq = new Queue<Node>();
            Queue<Node> rq = new Queue<Node>();

            Node l = null;
            Node r = null;

            lq.Enqueue(root.left);
            rq.Enqueue(root.right);

            while (lq.Count > 0 && rq.Count > 0)
            {
                l = lq.Dequeue();
                r = rq.Dequeue();

                if (l == null && r == null)
                {
                    continue;
                }

                if ((l == null || r == null) || (l.data != r.data))
                {
                    return false;
                }

                lq.Enqueue(l.left);
                lq.Enqueue(l.right);
                rq.Enqueue(r.right);
                rq.Enqueue(r.left);
            }

            return true;

        }
    }
}
