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

            Node p1 = new Node() { data = 1 };
            p1.left = new Node() { data = 2 };
            p1.right = new Node() { data = 3 };

            Node q1 = new Node() { data = 1 };
            q1.left = new Node() { data = 2 };
            q1.right = new Node() { data = 3 };
            TreeSame ts1 = new TreeSame() { Tree1 = p1, Tree2 = q1 };
            inputs.Add(ts1);

            Node p2 = new Node() { data = 1 };
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
                //IsSameTree_V2
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

            while (qp.Count > 0 && qq.Count > 0)
            {

                tp = qp.Dequeue();
                tq = qq.Dequeue();

                if (tp == null || tq == null || tp.data != tq.data)                  
                {
                    return false;
                }

                if (tp != null)
                {
                    qp.Enqueue(tp.left);
                    qp.Enqueue(tp.right);
                }

                if (tq != null)
                {
                    qq.Enqueue(tq.left);
                    qq.Enqueue(tq.right);
                }

            }
            return true;
        }

        public bool IsSameTree_V2(Node p, Node q)
        {
            if (p == null && q == null)
                return true;

            if ((p == null && q != null) || (p != null && q == null))
                return false;

            return this.IsTreeSame(p, q);
        }


        private bool IsTreeSame(Node p, Node q)
        {

            if ((p == null && q != null) || (p != null && q == null) || (p != null && q != null && p.data != q.data))
                return false;

            if (p == null && q == null)
                return true;

            bool result = IsTreeSame(p.left, q.left);
            if (result)
                result = IsTreeSame(p.right, q.right);

            return result;

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

                if (t != null)
                {
                    q.Enqueue(t.left);
                    q.Enqueue(t.right);
                }
                result.Append($"{(t == null ? "NULL" : t.data.ToString())} ");
            }
            return result.ToString();

        }

        public string TraverseBinaryTree(Node node, bool IsNextNeed = false)
        {
            datas.Clear();
            this.InOrder(node, IsNextNeed);
            return datas.ToString();
        }

        private void InOrder(Node root, bool IsNextNeed)
        {
            Node node = root;

            if (node != null)
            {
                Stack<Node> s = new Stack<Node>();
                while(s.Count > 0 || node != null)
                {

                    while (node!= null)
                    {
                        s.Push(node);
                        node = node.left;
                    }

                    node = s.Pop();
                    if (IsNextNeed)
                        datas.Append($"{node.data}-->{(node.next != null ? node.next.data.ToString() : "NULL")} ,");
                    else
                        datas.Append($"{node.data} ,");
                    node = node.right;
                }

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
            public Node next;
            public int childCount;
            public int val;
        }

        public class NodeAndInput
        {
            public Node TreeNode;
            public int Integer;
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

            Node t3 = new Node() { data = 2 };
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
            t5.left = new Node() { data = 2 };
            t5.right = new Node() { data = 2 };
            t5.left.right = new Node() { data = 3 };
            t5.right.left = new Node() { data = 3 };
            inputs.Add(t5); // Symmetric

            Node t6 = new Node() { data = 2 };
            t6.left = new Node() { data = 3 };
            t6.right = new Node() { data = 3 };
            t6.left.left = new Node() { data = 4 };
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

        private void btn_Binary_Tree_Level_Order_Traversal_Get_Item_from_the_bottom_up_Click(object sender, EventArgs e)
        {
            /*
                Given a binary tree, return the bottom-up level order traversal of its nodes' values.
                (ie, from left to right, level by level from leaf to root).
                For example:
                Given binary tree [3,9,20,null,null,15,7],
                    3
                   / \
                  9  20
                    /  \
                   15   7
                return its bottom-up level order traversal as:
                [
                  [15,7],
                  [9,20],
                  [3]
                ]

                Time Complexity :  O(n) where n is the list of nodes in the tree
                Space Complexity : O(n) where n is the list of nodes in the tree
             */

            List<Node> inputs = new List<Node>();
            StringBuilder result = new StringBuilder();

            Node p1 = new Node() { data = 3 };
            p1.left = new Node() { data = 9 };
            p1.right = new Node() { data = 20 };
            p1.right.left = new Node() { data = 15 };
            p1.right.right = new Node() { data = 7 };
            inputs.Add(p1);

            IList<IList<int>> datas = null;
            StringBuilder inResult = new StringBuilder();

            foreach (var input in inputs)
            {

                result.AppendLine($"The bottom up traversal for this binary tree {(this.TreeTraverse(input))} is");
                datas = this.LevelOrderBottom(input);

                foreach (IList<int> data in datas)
                {
                    inResult.Clear();
                    inResult.Append("[");
                    foreach (int i in data)
                    {
                        inResult.Append($"{i.ToString()},");
                    }
                    inResult.Append("]");
                    result.Append($"\n{inResult.ToString()}");
                }
            }

            MessageBox.Show(result.ToString());

        }

        public IList<IList<int>> LevelOrderBottom(Node root)
        {
             /*
              
                        3
                       / \
                      9  20
                        /  \
                       15   7
             */

            if (root == null)
            {
                return new List<IList<int>>();
            }

            Stack<List<int>> s = new Stack<List<int>>();
            Queue<Node> q = new Queue<Node>();
            IList<IList<int>> result = new List<IList<int>>();
            List<int> t = new List<int>();
            Node tNode = null;

            q.Enqueue(root);
            q.Enqueue(null);

            while (q.Count > 0)
            {
                tNode = q.Dequeue();

                if (tNode == null)
                {
                    if (t.Count == 0)
                    {
                        break;
                    }
                    s.Push(new List<int>(t));
                    q.Enqueue(null);
                    t.Clear();
                }
                else
                {
                    if (tNode.left != null)
                    {
                        q.Enqueue(tNode.left);
                    }

                    if (tNode.right != null)
                    {
                        q.Enqueue(tNode.right);
                    }
                    t.Add(tNode.data);

                }
            }

            while (s.Count > 0)
            {
                result.Add(s.Pop());
            }

            return result;
        }

        private void btn_Heap_Click(object sender, EventArgs e)
        {
            StringBuilder result = new StringBuilder();
            int[] input = new int[] { 20, 19, 15, 18, 17, 10, 12 };
            result.AppendLine($"Heap : {string.Join(" ", input)}");
            this.InsertHeap(ref input, 29);
            result.AppendLine($"After inserting Heap : {string.Join(" ", input)}");
            this.DeleteDataFromHeap(ref input);
            result.AppendLine($"After Deleting Heap : {string.Join(" ", input)}");

            MessageBox.Show(result.ToString());
        }

        private void DeleteDataFromHeap(ref int[] input)
        {
            if (input.Length > 1)
            {
                input[0] = input[input.Length - 1];
                Array.Resize(ref input, input.Length - 1);
                ShiftDown(input, 0);
            }
        }

        private void ShiftDown(int[] input, int i)
        {
            int l = (i * 2) + 1;
            int r = (i * 2) + 2;
            int largest = i;
            int length = input.Length;
            if (l < length && input[l] > input[largest])
            {
                largest = l;
            }

            if (r < length && input[r] > input[largest])
            {
                largest = r;
            }

            if (largest != i)
            {
                this.Swap(input, largest, i);
                this.ShiftDown(input, largest);
            }
        }


        private void InsertHeap(ref int[] input, int data)
        {
            Array.Resize(ref input, input.Length + 1);
            input[input.Length - 1] = data;
            this.ShiftUp(input, input.Length - 1);

        }

        private void ShiftUp(int[] input, int i)
        {
            //20, 19, 15, 18, 17, 10, 12, 29
            if (i >= 0)
            {
                int p = i / 2;
                if (input[i] > input[p])
                {
                    this.Swap(input, i, p);
                    ShiftUp(input, p);
                }
            }
        }

        private void Swap(int[] input, int i , int j)
        {
            input[i] += input[j];
            input[j] = input[i] - input[j];
            input[i] = input[i] - input[j];
        }

        private void btn_Check_Tree_is_Balanced_Click(object sender, EventArgs e)
        {
            
            /*            
                Given a binary tree, determine if it is height-balanced.
                For this problem, a height-balanced binary tree is defined as:
                a binary tree in which the left and right subtrees of every node differ in 
                height by no more than 1.

                Example 1:
                Given the following tree [3,9,20,null,null,15,7]:

                        3
                       / \
                      9  20
                        /  \
                       15   7
                Return true.
                    
                Example 2:
                Given the following tree [1,2,2,3,3,null,null,4,4]:
                           1
                          / \
                         2   2
                        / \
                       3   3
                      / \
                     4   4
                   
                Return false.                
                */

            StringBuilder result = new StringBuilder();
            List<Node> trees = new List<Node>();
            trees.Add(this.CreateBinaryTreeFromArray(new int?[] { 3, 9, 20, null, null, 15, 7 })); //Balanced
            trees.Add(this.CreateBinaryTreeFromArray(new int?[] { 1, 2, 2, 3, 3, null, null, 4, 4 })); //Not Balanced
            trees.Add(this.CreateBinaryTreeFromArray(new int?[] { 2, 1, 3 })); // Balanced
            trees.Add(this.CreateBinaryTreeFromArray(new int?[] { 1 })); // Balanced
            trees.Add(this.CreateBinaryTreeFromArray(new int?[] {  })); // Balanced


            int value = 0;
            foreach (var tree  in trees)
            {
                value = this.IsBalancedBinaryTree(tree);
                result.AppendLine($"This binary tree {(this.TreeTraverse(tree))} is {((value >= 0) ? " Balanced" : " not Balanced")} \n");
            }

            MessageBox.Show(result.ToString());


        }

        public int IsBalancedBinaryTree(Node root)
        {
            /*
                            3  --Return True
                           / \
                          9  20
                            /  \
                           15   7    
                           
                           1 --Return False
                          / \
                         2   2
                        / \
                       3   3
                      / \
                     4   4 
                                            
            */

            if (root == null)
            {
                return 0;
            }

            int l = IsBalancedBinaryTree(root.left);
            if (l == -1)
            {
                return -1;
            }

            int r = IsBalancedBinaryTree(root.right);
            if (r == -1)
            {
                return -1;
            }

            return Math.Abs(l - r) > 1 ? -1 : Math.Max(l, r) + 1;
        }

        private Node CreateBinaryTreeFromArray(int?[] input)
        {
            /*             
                Time Complexity : O(n)             
            */

            if (input.Length > 0)
            {
                Node root = null;
                Node temp = null;
                Queue<Node> q = new Queue<Node>();
                int i = 0;
                int l = input.Length;

                for(i = 0; i < l; i++)
                {
                    if (input[i].HasValue)
                    {
                        root = new Node() { data = input[i].Value, val = input[i].Value };
                        q.Enqueue(root);
                        break;
                    }
                }

                while(i < l)
                {
                    temp = q.Dequeue();
                    if (++i < l && input[i].HasValue)
                    {
                        temp.left = new Node() {data = input[i].Value, val = input[i].Value };
                        q.Enqueue(temp.left);
                    }

                    if (++i < l && input[i].HasValue)
                    {
                        temp.right = new Node() { data = input[i].Value, val = input[i].Value };
                        q.Enqueue(temp.right);
                    }                    
                }

                return root;
            }

            return null;
        }

        private void btn_Find_longest_Path_in_a_Binary_Tree_Click(object sender, EventArgs e)
        {
            

            /*
             		        10
					   /         \  
                      /			  \
					 4			  15	
					/ \			 /	
                   /   \		/
				  6    20     1

                Time Complexity  : O(n) where is the number of nodes in a given binary tree;
                Space Complexity : Constant space.

             */

            StringBuilder result = new StringBuilder();
            List<Node> trees = new List<Node>();
            trees.Add(this.CreateBinaryTreeFromArray(new int?[] { 10, 4, 15, 6, 20, 1}));
            string longPath = string.Empty;
            int sum = 0;

            foreach (var root in trees)
            {
                sum = 0; longPath = string.Empty;
                sum = GetLongestPath(root, 0, out longPath, string.Empty);
                result.AppendLine($"Long path is {longPath} and sum of the length is {sum } for the given tree {(this.TreeTraverse(root))}");
            }

            MessageBox.Show(result.ToString());
        }


        private int GetLongestPath(Node node,  int sum, out string path, string pPath)
        {
            /*
             		        10
					   /         \  
                      /			  \
					 4			  15	
					/ \			 /	
                   /   \		/
				  6    20     1

             */

            if (node == null)
            {
                path = pPath;
                return sum;
            }

            string lpath = $"{pPath}{(string.IsNullOrEmpty(pPath) ? "" : ",")} {node.data}"; 
            int l = GetLongestPath(node.left, sum + node.data, out lpath, lpath); 

            string rpath = $"{pPath}{(string.IsNullOrEmpty(pPath) ? "" : ",")} {node.data}"; 
            int r = GetLongestPath(node.right, sum + node.data, out rpath, rpath); 

            path = l > r ? lpath : rpath;
            return Math.Max(l, r);
        }

        private void btn_Path_Sum_Click(object sender, EventArgs e)
        {
            /*            
                Given a binary tree and a sum, determine if the tree has a root-to-leaf path such 
                that adding up all the values along the path equals the given sum.
                Note: A leaf is a node with no children.

                Example:
                Given the below binary tree and sum = 22,

                      5
                     / \
                    4   8
                   /   / \
                  11  13  4
                 /  \      \
                7    2      1
                return true, as there exist a root-to-leaf path 5->4->11->2 which sum is 22.
            
                Time Complexity  : O(n) where n is the total number of nodes
                Space Complexity : Constant space 

             */

            StringBuilder result = new StringBuilder();
            List<NodeAndInput> inputs = new List<NodeAndInput>();
            inputs.Add(new NodeAndInput() {TreeNode = this.CreateBinaryTreeFromArray(new int?[] { 5, 4, 8, 11, null, 13, 4, 7, 2, null, null, null, 1 }), Integer = 22}); //true
            inputs.Add(new NodeAndInput() { TreeNode = this.CreateBinaryTreeFromArray(new int?[] { 1 }), Integer = 0 }); //false;

            bool res = false;

            foreach(var input in inputs)
            {
                res = this.PathSum(input.TreeNode, input.Integer);
                result.AppendLine($"The path {(res ? "" : "not" )} exists for sum {input.Integer} for this tree {this.TreeTraverse(input.TreeNode)}");
            }

            MessageBox.Show(result.ToString());
        }

        private bool PathSum(Node node, int sum)
        {
            /*
                              5
                             / \
                            4   8
                           /   / \
                          11  13  4
                         /  \      \
                        7    2      1
                return true, as there exist a root-to-leaf path 5->4->11->2 which sum is 22. 

            */
            if (node == null)
            {
                return false;
            }

            Queue<Node> qq = new Queue<Node>();
            Queue<int> iq = new Queue<int>();

            Node t;
            int i;

            qq.Enqueue(node);
            iq.Enqueue(sum - node.data);

            while (qq.Count > 0)
            {
                t = qq.Dequeue();
                i = iq.Dequeue();
               
                if (i == 0 && t.left == null && t.right == null)
                {
                    return true;
                }

                if (t.left != null)
                {
                    qq.Enqueue(t.left);
                    iq.Enqueue(i - t.left.data);
                }

                if (t.right != null)
                {
                    qq.Enqueue(t.right);
                    iq.Enqueue(i - t.right.data);
                }
            }

            return false;
        }

        private void btn_Remove_Node_from_Binary_Tree_if_Node_is_Less_than_the_given_input_Click(object sender, EventArgs e)
        {
            /*
            
            Given a binary tree and an integer value 12 delete the nodes which are smaller than the given integer value 12.
            For example 6 will be deleted 4 is not deleted since 20 which is child on 4 which smaller than given integer value 
            should not be deleted.

						    10
					   /         \  
                      /			  \
					 4			  15	
					/ \			 /	
                   /   \		/
				  6    20     1
	


            */

            StringBuilder result = new StringBuilder();
            Node root = this.CreateBinaryTreeFromArray(new int?[] {10,4,15,6,20,1});
            result.AppendLine("Before Deleting");
            result.AppendLine(this.TreeTraverse(root));

            this.RemoveNodeFromBinaryTreeLesserThanTheGivenValue(root, 12);

            result.AppendLine("\nAfter Deleting");
            result.AppendLine(this.TreeTraverse(root));


        }


        private void RemoveNodeFromBinaryTreeLesserThanTheGivenValue(Node root, int val)
        {
            if (root == null)
            {
                return;
            }

            Stack<Node> s = new Stack<Node>();
            Node current = root;

            while(current!= null || s.Count > 0)
            {

                while (current != null)
                {
                    s.Push(current);
                    current = current.left;
                }

                current = s.Pop();

                if (current != null)
                {
                    if (current.left == null && current.right == null && current.data <= val)
                    {
                        current = null;
                    }
                    else
                    {
                        current = current.right;
                    }
                }
            }
        }

        private void btn_Find_two_numbers_which_adds_to_Sum_from_a_binary_search_tree_Recurssion_Click(object sender, EventArgs e)
        {
            /*
                                    20
                              /         \
                             /           \
                            18           22
                           /  \         /   \
                          /    \       /     \
                        17     19    21      23
                       /
                      /
                    16

            Time Complexity : O(log N) where N is the total number of nodes in BST
            Space Complexity: O(log N) where N is the total number of nodes in BST
             */

            HashSet<int> dict = null;
            Node root = null;
            this.Insert(20, ref root);
            this.Insert(18, ref root);
            this.Insert(22, ref root);
            this.Insert(17, ref root);
            this.Insert(19, ref root);
            this.Insert(21, ref root);
            this.Insert(23, ref root);
            this.Insert(16, ref root);

            //int sum = 42;
            int sum = 39;
            int[] result = this.FindTwoNumbersForGivenSumInBST(root, sum, ref dict);

            MessageBox.Show($"The sum {sum} is formed with these two numbers {result[0]} and {result[1]} in this binary search tree  {TraverseBinaryTree(root)}");

        }


        public int[] FindTwoNumbersForGivenSumInBST(Node node, int sum, ref HashSet<int> dict)
        {
            int temp = 0;

            if (dict == null)
            {
                dict = new HashSet<int>();
            }

            if (node != null)
            {
                temp = sum - node.data;

                if (dict.Contains(temp))
                {
                    return new int[] {node.data, temp };
                }
                else
                {
                    dict.Add(node.data);
                }

                if (node.data > temp)
                {
                    return FindTwoNumbersForGivenSumInBST(node.left, sum, ref dict);
                }
                else
                {
                    return FindTwoNumbersForGivenSumInBST(node.right, sum, ref dict);
                }
            }

            return null;

        }

        private void btn_Binary_Tree_Maximum_Path_Sum_Click(object sender, EventArgs e)
        {
            StringBuilder result = new StringBuilder();
            List<Node> inputs = new List<Node>();
            inputs.Add(this.CreateBinaryTreeFromArray(new int?[] { 10, 4, 15, 6, 20, 1 })); // 50
            inputs.Add(this.CreateBinaryTreeFromArray(new int?[] { -10, 9, 20, null, null, 15, 7 })); //42
            inputs.Add(this.CreateBinaryTreeFromArray(new int?[] { -3 }));//-3
            inputs.Add(this.CreateBinaryTreeFromArray(new int?[] { 2, 1 })); //2
            inputs.Add(this.CreateBinaryTreeFromArray(new int?[] { 5, 4, 8, 11, null, 13, 4, 7, 2, null, null, null, 1 })); // 48

            foreach (Node input in inputs)
            {
                result.AppendLine($"Max sum path is {this.MaxPathSum(input)} for the given binary tree {TreeTraverse(input)}");
            }

            MessageBox.Show(result.ToString());


        }

        public int MaxPathSum(Node root)
        {
            int max = int.MinValue;
            int result = GenerateSumAndMax(root, ref max);
            return max;
        }

        public int GenerateSumAndMax(Node node, ref int max)
        {

            /*  10, 4, 15, 6, 20, 1 
                                               10
                                           /        \
                                          /          \
                                         4           15
                                       /  \         /         
                                      /    \       /
                                     6     20     1
              
             */



            if (node == null)
            {
                return 0;
            }

            int l = GenerateSumAndMax(node.left, ref max);
            int r = GenerateSumAndMax(node.right, ref max);

            int sum = 0;
            sum = node.data + Math.Max(l, 0) + Math.Max(r, 0);
            max = Math.Max(max, sum);
            sum = node.data + Math.Max(0, Math.Max(l, r));
            return sum;

        }

        private void btn_Diameter_of_Binary_Tree_Click(object sender, EventArgs e)
        {

            /*
             
            
                Given a binary tree, you need to compute the length of the diameter of the tree. The diameter of a binary tree is the length of the longest path between any two nodes in a tree. This path may or may not pass through the root.

                Example:
                Given a binary tree
                          1
                         / \
                        2   3
                       / \     
                      4   5    
                Return 3, which is the length of the path [4,2,1,3] or [5,2,1,3].
                Note: The length of path between two nodes is represented by the number of edges between them.
             
                Time Complexity     : O(N) where N is the total number of nodes
                Space Complexity    : O(1) constant space
                
             */

            StringBuilder result = new StringBuilder();
            List<Node> inputs = new List<Node>();
  
            inputs.Add(this.CreateBinaryTreeFromArray(new int?[] { 1,2,3,4,5 })); //3
            inputs.Add(this.CreateBinaryTreeFromArray(new int?[] { 1, 2, 3, 4, 5,null, 6 }));
            inputs.Add(this.CreateBinaryTreeFromArray(new int?[] { 1, 2, 3, 4, 5, null, null, 6, 7, null, 8, null, null, 9, null, 10, 11, null, 12, null, null, 13 })); //8

            foreach (Node input in inputs)
            {
                int diameter = 0;
                this.GetDiameter(input, ref diameter);
                result.AppendLine($"Diameter is {diameter} for the given binary tree {TreeTraverse(input)}");
            }

            MessageBox.Show(result.ToString());
        }


        private int GetDiameter(Node node, ref int diameter)
        {
      

            if (node == null)
            {
                return 0;
            }

            int left = GetDiameter(node.left, ref diameter);
            int right = GetDiameter(node.right, ref diameter);


            diameter = Math.Max(diameter, left + right);

            return 1 + Math.Max(left, right);

        }

        public class NodeAndInputArray
        {
            public Node TreeNode;
            public int[] arr;
        }

        private void btn_Check_If_a_String_Is_a_Valid_Sequence_from_Root_to_Leaves_Path_in_a_Binary_Tree_Click(object sender, EventArgs e)
        {

            /*
             
                Given a binary tree where each path going from the root to any leaf form a valid sequence, check if a given string is a valid sequence in such binary tree. 

                We get the given string from the concatenation of an array of integers arr and the concatenation of all values of the nodes along a path results in a sequence in the given binary tree.

                Example 1:
                Input: root = [0,1,0,0,1,0,null,null,1,0,0], arr = [0,1,0,1]
                Output: true
                Explanation: 
                The path 0 -> 1 -> 0 -> 1 is a valid sequence (green color in the figure). 
                Other valid sequences are: 
                0 -> 1 -> 1 -> 0 
                0 -> 0 -> 0

                Example 2:
                Input: root = [0,1,0,0,1,0,null,null,1,0,0], arr = [0,0,1]
                Output: false 
                Explanation: The path 0 -> 0 -> 1 does not exist, therefore it is not even a sequence.
                
                Example 3:
                Input: root = [0,1,0,0,1,0,null,null,1,0,0], arr = [0,1,1]
                Output: false
                Explanation: The path 0 -> 1 -> 1 is a sequence, but it is not a valid sequence.
                 
                Time Complexity  : O(Log N)
                Space Complexity : O(1)

             */


            StringBuilder result = new StringBuilder();
            List<NodeAndInputArray> inputs = new List<NodeAndInputArray>();

            inputs.Add(new NodeAndInputArray() { TreeNode = this.CreateBinaryTreeFromArray(new int?[] { 0, 1, 0, 0, 1, 0, null, null, 1, 0, 0 }), arr = new int[] { 0, 1, 0, 1 } }); // true
            inputs.Add(new NodeAndInputArray() { TreeNode = this.CreateBinaryTreeFromArray(new int?[] { 0, 1, 0, 0, 1, 0, null, null, 1, 0, 0 }), arr = new int[] { 0,0,1 } }); // false
            inputs.Add(new NodeAndInputArray() { TreeNode = this.CreateBinaryTreeFromArray(new int?[] { 0, 1, 0, 0, 1, 0, null, null, 1, 0, 0 }), arr = new int[] { 0, 1, 1 } }); //false
            inputs.Add(new NodeAndInputArray() { TreeNode = this.CreateBinaryTreeFromArray(new int?[] { 4, null, 2, 7, 5, 3, 4, 4 }), arr = new int[] { 4, 2, 7, 4 } });
            //inputs.Add(new NodeAndInputArray() { TreeNode = this.CreateBinaryTreeFromArray(new int?[] { 0, 9, 0, 5, 6, 6, 9, 2, 8, 1, 6, 9, 5, 6, 3, 1, 4, 1, 9, 9, 1, 0, 1, 9, 7, 0, 4, 6, 5, 2, 7, 3, 3, 6, 9, 8, 2, 9, 1, 8, 5, 9, 2, null, 5, 3, 4, 7, 6, 5, 3, 2, 7, 6, 4, 0, 2, 0, 5, 8, 4, 1, 2, 9, 0, null, 2, 7, 8, 7, 4, 9, null, 9, 3, 9, 7, 0, 7, 3, 7, null, 7, 3, 5, 4, 1, 1, 8, null, 7, 7, 9, 4, 2, 6, 0, null, 5, 5, 4, 1, 0, 7, 4, 9, 8, 2, 8, 5, 2, null, null, 1, 9, 0, 5, 7, 3, null, null, 9, 4, 3, 6, 2, 9, 1, 1, 8, 5, 0, null, 8, null, 6, 8, 4, 5, 2, 3, null, null, null, null, 0, null, 2, 9, 1, null, null, null, 8, null, 7, null, 1, 1, null, 5, 8, 9, 5, 6, null, 4, 5, 9, null, 4, 6, null, null, 1, 8, null, 6, 3, 4, 5, 7, 3, 3, 9, 8, null, 0, 1, 3, 9, 9, 0, 4, 3, 1, 3, 9, 2, 1, 9, 5, null, 1, 8, 3, 6, null, null, 5, 3, null, 2, 2, 4, 6, 9, 8, 2, null, 5, 2, null, null, 4, 1, 6, null, 9, 5, 8, 3, null, null, 8, 3, null, 7, 6, null, 6, 4, null, null, null, null, null, 7, 0, 9, 4, 6, 5, 2, 3, null, 0, 2, 1, null, null, 8, 3, null, null, null, null, null, null, 1, 0, null, null, null, 4, null, 9, null, 7, null, null, 5, 7, null, 2, null, 0, null, 5, null, null, null, null, null, 0, 4, null, 2, 3, 2, null, 5, null, 1, 5, 3, null, null, 6, 2, 4, 1, 9, 9, 3, null, null, 3, 9, 0, null, 7, 7, 2, 8, 9, 8, 8, 2, 6, 9, 4, 6, 3, 0, 5, 0, 8, null, null, 5, 5, 6, 3, 0, 6, 9, 0, 0, 1, 0, 1, 0, 7, 2, null, null, null, null, null, null, null, null, 0, 6, 8, 4, null, 5, 3, 0, 9, null, null, null, null, 5, 7, 9, 0, 8, 4, 6, 3, 5, 9, null, null, null, null, null, null, null, null, null, 9, 9, 0, null, null, 9, 1, 9, 6, 6, null, 1, 2, null, 2, 4, 4, 7, 5, 4, 0, 1, 4, 9, null, 8, 3, null, null, null, 0, null, 4, null, null, 6, null, null, null, null, null, null, null, null, 4, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, null, null, null, 2, 8, null, null, 8, 6, 1, 6, null, 4, 1, 2, 0, null, null, 0, 2, null, 2, 7, 7, 0, 6, 4, 1, 4, 1, 9, 9, 7, 0, 8, 7, 7, 3, 5, 7, 1, 8, null, 2, 8, 9, null, 5, 4, 0, 5, 4, null, 3, 6, 5, 7, 0, 4, null, 5, 7, 8, 8, 2, null, null, null, null, 3, 4, null, 1, 8, 6, 4, 7, 7, 7, 6, null, 8, 8, null, 1, 0, 9, null, null, 5, 8, 4, 7, null, 7, null, 3, 2, null, null, null, null, 4, 0, 3, 3, 5, 8, 2, null, 7, 4, 9, null, null, null, 0, 4, 8, 3, 0, 7, 0, 4, null, 3, null, null, null, 6, 8, 6, null, 1, 2, 2, 6, null, null, null, null, 3, 7, null, 0, 7, 1, 5, 3, null, null, 9, 6, null, null, null, 7, 7, 2, 6, 3, null, null, 9, 7, 0, 9, 0, null, 4, 5, 1, 3, 2, null, null, null, 7, null, null, null, null, null, null, null, null, 9, null, null, 5, 9, null, 9, null, null, 9, 6, null, 2, null, null, null, null, null, null, 6, null, 7, 9, 2, 6, 4, 3, null, 0, null, null, 1, 3, 1, 4, 3, 4, 7, null, null, null, null, null, 0, null, 7, 6, 3, 4, null, 3, 3, 9, null, null, 8, 8, 6, 4, 0, null, 4, 0, null, 4, null, 6, 3, 6, 7, null, null, null, 0, 2, 6, 0, 8, 2, null, 9, 4, 1, 5, 9, 9, 1, 0, 0, 4, 6, 1, 1, 3, null, 6, 0, 3, 7, 1, 3, 7, 4, 9, 0, null, 4, 9, null, null, 9, 4, 0, 2, 6, 4, null, null, null, 0, null, 3, 3, 4, 6, null, null, 4, null, null, null, 5, null, null, 3, 0, 3, null, null, 9, 1, 0, null, 6, 8, 2, null, null, null, null, 5, null, null, 5, null, 8, null, null, null, 6, null, 4, null, 5, null, 0, null, null, 7, 3, null, null, null, 9, null, null, 1, 9, 4, null, 4, 2, null, null, null, 3, 7, null, null, null, 5, 7, null, null, null, 8, null, null, null, null, null, null, null, 5, null, null, null, null, 2, 3, 6, null, null, 1, null, 3, 3, null, null, null, null, null, 2, 4, 0, null, 7, null, 2, 4, 1, 2, 6, null, 0, null, 8, null, 8, 8, 0, null, 8, 0, null, 0, null, null, 9, null, null, null, null, 4, 2, 4, 8, null, null, null, null, null, 7, null, null, null, null, null, 5, 1, null, null, null, 8, null, 9, 4, null, null, 1, null, 7, 5, 8, 9, 0, null, null, null, null, null, 1, 2, 7, null, null, 1, 2, 7, 4, 8, 6, 6, 4, 0, 9, 3, null, null, 2, null, null, null, null, null, null, null, null, null, 8, null, 0, null, 5, 3, 4, null, 4, 7, 5, null, null, null, null, 9, 6, 0, 7, 4, 7, 4, 7, 0, null, 0, 9, 1, 3, null, 9, null, null, null, 6, 1, null, null, 2, 9, 9, 5, 2, 9, null, null, 5, 8, 5, 4, 8, 1, 9, 6, 9, 9, 7, 8, 5, null, 0, 4, 9, 2, 1, 7, 3, 8, 7, 9, null, 0, 3, 9, 7, 9, 8, null, 3, 5, null, null, 0, 6, null, null, 2, 6, null, 9, null, null, 0, null, null, null, null, null, null, null, 2, null, null, null, null, 1, null, 4, null, null, 2, 6, 0, 2, 0, 2, null, null, null, null, null, 0, 2, 9, 5, 4, null, null, null, null, 1, 8, null, 4, null, null, null, 7, null, 4, null, null, null, 5, null, 9, null, null, 6, null, 9, 6, null, 3, null, null, null, null, 3, null, null, null, 9, 1, null, null, 7, null, null, 6, 8, null, null, null, null, null, null, null, 4, null, null, null, 9, null, null, null, null, null, 9, 8, null, 0, 7, 1, 2, 0, null, null, null, null, null, null, 7, null, null, null, null, null, null, null, null, null, null, null, 2, 1, null, null, 5, null, null, null, 5, null, null, 6, null, null, null, null, null, 1, null, null, 9, null, 3, 6, null, null, 1, 9, 3, 1, 2, 7, 8, null, null, null, 1, null, null, null, null, null, 8, 9, 0, null, 9, null, 1, null, null, null, 5, 1, 7, null, 3, 0, null, null, null, 0, null, null, null, null, 3, 4, null, null, 2, null, 0, null, 6, null, null, null, null, null, 9, null, 2, 3, 4, 4, 0, 9, 7, 4, 6, null, null, null, 5, 0, null, 6, null, null, null, 5, 2, 7, null, 5, null, 8, null, 6, 0, 4, null, null, 6, 1, 0, 6, 6, null, 2, null, null, 7, 5, 2, 7, null, 0, 2, 7, null, 3, 3, 3, null, 6, 3, 2, 4, null, 1, 9, null, 2, null, 1, 8, null, 7, 4, 0, 0, 2, 3, 3, null, null, null, null, null, null, 5, 2, 7, 4, 4, 7, 7, null, 8, 7, null, null, null, null, null, null, 7, 8, null, null, null, null, null, 7, 1, 0, null, 1, null, 8, null, null, null, null, null, null, null, 2, 1, 5, null, null, null, null, 2, 6, null, null, 8, 5, 4, 4, 0, 1, null, 7, 8, null, null, null, null, 0, null, 4, 5, 0, 2, null, 3, 9, null, null, null, 4, 9, null, 9, null, null, null, 7, 7, null, 0, null, null, null, 5, null, 6, 0, 0, null, null, null, null, null, null, null, null, null, 9, null, null, 0, null, 3, 7, null, 6, null, null, null, null, null, null, null, 1, 9, 6, null, 7, 1, 2, 7, 3, 7, 4, null, null, null, null, null, null, 3, 1, 1, 9, 2, 6, null, null, null, 3, 9, 0, 3, 1, null, null, null, null, 4, null, null, 0, null, null, null, 1, 9, 0, null, 0, 2, 8, 6, null, null, null, null, null, 1, null, 6, 4, null, null, null, null, null, null, null, null, 6, null, null, 1, null, null, null, null, 6, 4, 6, 7, null, null, 4, 5, null, null, null, 4, null, 4, null, 3, null, 1, 8, 5, null, 4, null, null, null, 6, 4, 1, 1, 0, 0, 0, 6, 4, null, 3, 4, 6, 9, null, 2, null, null, 4, null, null, 8, null, null, null, null, null, null, null, null, null, 0, 8, null, 6, null, null, 2, 0, 8, null, 9, 7, null, null, 3, 7, null, null, 8, null, null, 0, 2, null, 1, null, 6, 4, 5, 0, 0, 9, 7, 4, null, 9, 5, 7, 3, 4, null, null, null, 4, 7, 3, null, 5, 4, null, 9, null, null, 6, 7, null, null, null, null, null, null, null, 5, 2, null, null, null, null, 7, null, null, null, 3, 8, 7, null, null, null, null, null, 0, 3, null, null, 7, 5, null, null, 2, 8, null, null, null, 0, null, null, null, null, null, null, null, null, null, 4, null, null, 6, 3, null, null, null, null, null, null, null, null, 9, 0, 8, null, 6, 1, null, null, null, 9, null, null, null, 4, 3, null, null, null, 5, null, 8, 3, 2, 9, 5, 7, null, 3, 6, null, 1, null, 3, 3, null, null, 8, null, null, null, null, null, null, null, 2, 1, 3, 6, null, null, 7, null, 2, null, null, null, null, null, null, 4, 9, null, 3, null, 5, null, null, 5, null, null, null, null, null, null, null, null, null, 4, null, null, 1, null, 2, null, null, null, null, null, null, null, null, null, null, 2, 0, 0, null, null, null, null, 4, 3, 4, 1, 8, 7, 6, 1, 3, null, null, 8, null, null, null, null, null, null, null, null, null, 7, null, null, 5, 9, null, null, null, 0, 9, 5, 4, 1, 9, null, 0, 3, 8, 5, null, 9, 6, 0, null, 2, 9, 8, 1, null, null, null, 2, null, 0, 2, null, 8, null, null, null, 6, 7, 0, 0, 6, 4, null, 2, 0, null, null, null, 9, null, 2, 5, 3, null, null, null, null, null, 9, 5, null, 6, 1, null, 0, 3, 6, 8, 1, 6, 1, null, 6, 9, 2, 0, 8, 8, 5, 1, 8, 2, 8, 0, null, null, null, null, 7, null, null, null, null, null, null, null, null, null, 4, null, 4, null, 8, 7, null, null, null, null, null, 8, 6, null, 5, 2, null, null, null, null, null, 8, null, null, 6, null, 8, null, null, null, null, null, null, 5, null, null, null, 9, 7, 0, 0, null, null, null, null, null, 8, null, 1, null, null, null, null, null, null, null, null, 2, null, 7, 7, null, 7, 4, null, null, null, null, null, null, null, 8, null, null, null, 1, null, 0, 2, null, null, null, null, null, 3, null, 3, 6, 9, 5, null, 0, null, 1, null, null, 6, null, 4, null, null, null, null, null, 5, null, null, 6, null, 7, 0, 6, 8, 3, null, 5, null, 7, 7, null, null, 2, null, 5, null, null, 9, null, 6, null, null, null, 1, null, null, null, null, null, null, null, null, null, null, 5, null, null, null, null, 2, 6, 6, null, 9, null, 4, null, 2, 9, 3, null, null, 3, 7, 2, 1, 5, 6, null, null, null, null, 0, null, 6, 7, 2, 0, 5, null, null, null, null, 6, null, 6, 7, null, null, null, 4, null, null, 4, null, 5, null, null, null, null, null, null, null, null, 8, 5, null, null, null, 0, 7, 8, null, 0, 1, 6, 9, 7, 5, 0, null, 9, 7, 1, null, null, null, null, null, null, null, null, 8, 2, null, 6, null, 3, 1, 3, 1, 4, 6, 3, 5, 5, 4, 5, null, null, null, null, 7, 3, null, null, null, 3, null, 6, null, null, 5, null, 4, 9, 4, null, 3, null, null, null, null, null, null, null, null, null, null, null, 9, null, null, null, null, null, null, 6, null, null, null, null, 3, 6, null, null, null, null, null, null, 3, null, null, null, null, null, 4, null, null, null, null, null, null, 6, null, null, 1, null, null, null, null, null, null, null, null, null, null, null, null, 8, null, 9, 5, null, 9, 6, 0, 7, 3, 9, null, null, 3, 9, null, null, 4, null, null, null, null, null, null, null, null, 1, 8, null, null, null, null, 7, null, 6, 7, 5, null, null, 6, 5, null, null, null, null, null, null, null, null, null, 0, 1, null, null, null, 8, 0, 0, 3, null, null, null, null, null, 0, 0, null, null, null, 6, 3, null, 4, 5, 3, null, null, null, 9, null, null, null, null, null, 7, 5, 4, 8, 6, 5, 1, null, 4, 5, 3, null, 8, 1, 2, 7, 6, 8, 9, 6, null, null, null, null, null, 6, null, 3, 7, null, null, 6, 0, null, null, null, null, 6, 4, 9, 2, 9, 3, 1, null, 5, 7, null, null, null, null, 1, 1, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, 2, null, null, 6, null, null, null, null, null, null, 7, null, null, null, null, 0, 8, null, null, 3, null, null, null, null, null, null, null, null, null, 3, null, null, null, null, null, null, null, null, 5, null, null, null, null, 9, null, 5, null, 4, null, null, null, null, null, null, null, 2, null, null, null, 7, null, null, 1, 5, 7, 8, null, null, 8, null, null, 1, null, 3, null, null, 4, 6, null, null, 9, null, null, null, 1, 2, 4, null, 1, 1, null, null, 3, null, 4, 3, null, null, null, 5, 6, 0, 6, 4, 3, 8, null, 9, null, null, null, 9, null, null, null, 0, 7, null, null, 3, null, 9, 8, 1, 2, 7, 7, null, null, 4, null, 6, 8, 3, 9, null, null, 2, null, null, 8, null, null, null, 8, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 5, null, null, 7, null, null, null, null, null, null, null, null, null, 5, null, null, null, null, 0, null, null, null, null, null, null, null, null, null, null, null, 4, null, 3, null, 8, 2, 0, null, null, null, null, 0, null, null, 6, null, null, null, 7, null, null, 8, 3, 0, null, null, null, null, null, null, 4, 4, null, null, null, null, 1, null, null, 3, null, null, 2, null, 5, 8, null, null, null, null, null, null, null, null, null, 7, null, null, null, null, null, null, null, null, null, null, null, null, null, 2, null, null, null, null, null, null, null, null, null, null, 3, 8, 3, 5, null, null, null, 4, null, null, 8, null, 0, 0, null, 2, null, 1, null, 7, null, 5, 9, 2, null, null, null, 9, 3, 0, 3, null, null, null, null, 6, 0, 6, null, 5, 8, null, 7, 7, null, null, null, null, null, 2, 4, 9, null, null, null, null, null, 5, null, 6, null, null, null, null, null, null, 5, null, null, null, null, null, null, 8, null, 9 }), 
             //  arr = new int[] { 0, 0, 6, 9, 9, 7, 4, 6, 2, 8, 9, 4, 5, 7, 3, 8 } });




            foreach (NodeAndInputArray input in inputs)
            {
                result.AppendLine($"There is {(this.IsValidSequence(input.TreeNode, input.arr) ? "": "no" )} sequence exists  for the given binary tree {TreeTraverse(input.TreeNode)}");
            }

            MessageBox.Show(result.ToString());
        }

        public bool IsValidSequence(Node root, int[] arr)
        {

            int count = 0;
            this.CheckSequenceExists(root, arr, ref count);
            return count == arr.Length;
        }

        private void CheckSequenceExists(Node root, int[] arr, ref int count)
        {

            if (root == null)
                return;

            if (root.data == arr[count])
            {
                count++;
            }
            while (root!= null)
            {                         

                if (root.left != null && root.left.data == arr[count])
                {
                    count++;
                    root = root.left;
                }
                else if (root.right != null && root.right.data == arr[count])
                {
                    count++;
                    root = root.right;
                }
                else
                {
                    root = null;
                }

                if (count >= arr.Length)
                {
                    if  (root.right != null && root.left != null)
                    {
                        count = arr.Length + 1;
                    }
                    root = null;
                }
                else if (count < arr.Length && root != null && root.left == null && root.right == null)
                {
                    count = arr.Length;
                    root = null;
                }                
            }                       
        }

        private void btn_Cousins_in_Binary_Tree_Click(object sender, EventArgs e)
        {
            /*
             
            In a binary tree, the root node is at depth 0, and children of each depth k node are at depth k+1.

            Two nodes of a binary tree are cousins if they have the same depth, but have different parents.

            We are given the root of a binary tree with unique values, and the values x and y of two different nodes in the tree.

            Return true if and only if the nodes corresponding to the values x and y are cousins.

            Example 1:

                                                1
                                           /        \
                                          /          \
                                         2            3
                                       /  
                                      / 
                                     4  

            Input: root = [1,2,3,4], x = 4, y = 3
            Output: false

            Example 2 :
             

                                                1
                                           /        \
                                          /          \
                                         2            3
                                          \            \
                                           \            \
                                            4            5
            Input: root = [1,2,3,null,4,null,5], x = 5, y = 4
            Output: true

            Example 3: 

                                                1
                                           /        \
                                          /          \
                                         2            3
                                          \            
                                           \           
                                            4          

            Input: root = [1,2,3,null,4], x = 2, y = 3
            Output: false

            Time Complexity         : O(N) where N is the total number of nodes
            Space Complexity        : O(N) 

            */

            StringBuilder result = new StringBuilder();
            List<BinaryCousin> inputs = new List<BinaryCousin>();

            inputs.Add(new BinaryCousin() { Tree = this.CreateBinaryTreeFromArray(new int?[] { 1, 2, 3, 4 }), Cousin1 = 4, Cousin2 = 3 }); 
            inputs.Add(new BinaryCousin() { Tree = this.CreateBinaryTreeFromArray(new int?[] { 1, 2, 3, null, 4, null, 5 }), Cousin1 = 5, Cousin2 = 4 });
            inputs.Add(new BinaryCousin() { Tree = this.CreateBinaryTreeFromArray(new int?[] { 1, 2, 3, null, 4 }), Cousin1 = 2, Cousin2 = 3 });


            foreach (BinaryCousin input in inputs)
            {
                result.AppendLine($"There is {(this.IsCousins(input.Tree, input.Cousin1, input.Cousin2) ? "" : "no")} cousin for the given cousine 1: {input.Cousin1} cousine 2 :{input.Cousin1} binary tree {TreeTraverse(input.Tree)}");
            }

            MessageBox.Show(result.ToString());

        }

        public bool IsCousins(Node root, int x, int y)
        {

            if (root == null)
            {
                return false;
            }

            bool isFirstExists = false;
            bool isSecondExists = false;

            Node temp = null;

            Queue<Node> l = new Queue<Node>();
            Queue<Node> r = new Queue<Node>();

            Node c1;
            Node c2;


            if (root.left != null)
            {
                l.Enqueue(root.left.left);
                r.Enqueue(root.right.left);
            }

            if (root.right != null)
            {
                l.Enqueue(root.right.left);
                r.Enqueue(root.right.right);
            }

            l.Enqueue(null);
            r.Enqueue(null);


            while (l.Count > 0 || r.Count > 0)
            {

            }


            return isFirstExists && isSecondExists;
        }


        private void IsCousinExists(Queue<Node> l, Queue<Node> r, int c1, int c2 )
        {






        }

        public class BinaryCousin
        {
            public Node Tree;
            public int Cousin1;
            public int Cousin2;
        }

        private void btn_Kth_Smallest_Element_in_a_BST_Click(object sender, EventArgs e)
        {
            /*
             
                Given a binary search tree, write a function kthSmallest to find the kth smallest element in it.

                    Note:
                    You may assume k is always valid, 1 ≤ k ≤ BST's total elements.

                    Example 1:

                    Input: root = [3,1,4,null,2], k = 1
                       3
                      / \
                     1   4
                      \
                       2
                    Output: 1
                    Example 2:

                    Input: root = [5,3,6,2,4,null,null,1], k = 3
                           5
                          / \
                         3   6
                        / \
                       2   4
                      /
                     1
                    Output: 3


                Time Complexity     : O(height of the Tree)
                Space Complexity    : O(1)
             */

            StringBuilder result = new StringBuilder();
            List<Common> inputs = new List<Common>();
            inputs.Add(new Common() { Tree = this.CreateBST(new int[] { 3, 1, 4, 2 }), K = 1 });
            inputs.Add(new Common() { Tree = this.CreateBST(new int[] { 5, 3, 6, 2, 4, 1 }), K = 3 });
            inputs.Add(new Common() { Tree = this.CreateBST(new int[] { 5, 3, 6, 2, 4, 1 }), K = 6 });
            inputs.Add(new Common() { Tree = this.CreateBST(new int[] { 5, 3, 6, 2, 4, 1 }), K = 5 });
            foreach (var input in inputs)
            {
                result.AppendLine($"{input.K}  smallest value for the given BST tree {this.TraverseBinaryTree(input.Tree)} is {this.KthSmallest(input.Tree, input.K)}");
            }

            MessageBox.Show(result.ToString());
        }

        public class Common
        {
            public Node Tree;
            public int K;
            public int low;
            public int high;
            public List<string> operations; 
        }

        public int KthSmallest(Node root, int k)
        {
            if (root == null)
                return 0;

            int data = -1;


            Node current = root;

            while (current != null)
            {
                data = current.data;
                if (k < current.childCount)
                {
                    current = current.left;
                }
                else if (k > current.childCount)
                {
                    current = current.right;
                }
                else
                {                    
                    break;
                }
            }
            return data;
        }

        private Node CreateBST(int[] input)
        {
            Node tree = null;

            foreach(int i in input)
            {
                if (tree == null)
                {
                    tree = new Node() { data = i, val = i,childCount = 0 };
                }
                else
                    this.BST(ref tree, i);
            }

            return tree;

        }

        private void BST(ref Node root, int data)
        {

            if (root == null)
            {
                root = new Node() { data = data, val = data,childCount = 0 };
            }
            else
            {
                root.childCount++;
                if (root.data > data)
                {
                    BST(ref root.left, data);
                }
                else
                {                    
                    BST(ref root.right, data);
                }
            }
            
         
        }

        private void btn_Invert_Binary_Tree_Click(object sender, EventArgs e)
        {
            /*
                Invert a binary tree.

                Example:
                    
                            Input:

                             4
                           /   \
                          2     7
                         / \   / \
                        1   3 6   9
                
                            Output:

                             4
                           /   \
                          7     2
                         / \   / \
                        9   6 3   1

                Time Complexity     : O(N) where N is the number of nodes
                Space Complexity    : O(N)
             
             */


            StringBuilder result = new StringBuilder();
            List<Node> inputs = new List<Node>();
            inputs.Add(this.CreateBST(new int[] {4,2,7,1,3,6,9 }));
            
            foreach (var input in inputs)
            {
                result.AppendLine($"Before inverting {this.TraverseBinaryTree(input)} and after inverting {this.TraverseBinaryTree(this.InvertTree(input))} ");
            }

            MessageBox.Show(result.ToString());


        }

        public Node InvertTree(Node root)
        {
            if (root == null)
                return null;

            Node result = root;


            Queue<Node> q = new Queue<Node>();
            q.Enqueue(result);
            Node parent;
            Node temp;
            while (q.Count > 0)
            {
                parent = q.Dequeue();

                if (parent != null)
                {
                    if (parent.left!= null)
                    {
                        q.Enqueue(parent.left);
                    }

                    if (parent.right != null)
                    {
                        q.Enqueue(parent.right);
                    }

                    temp = parent.left;
                    parent.left = parent.right;
                    parent.right = temp;
                }
            }
            return root;
        }

        private void btn_Count_Complete_Tree_Nodes_Click(object sender, EventArgs e)
        {
            /*
             
            Given a complete binary tree, count the number of nodes.

                Note:

                Definition of a complete binary tree from Wikipedia:
                In a complete binary tree every level, except possibly the last, is completely filled, and all nodes in the last level are as far 
                left as possible. It can have between 1 and 2h nodes inclusive at the last level h.

                Example:

                Input: 
                    1
                   / \
                  2   3
                 / \  /
                4  5 6

                Output: 6

            */

            StringBuilder result = new StringBuilder();
            List<Node> inputs = new List<Node>();
            inputs.Add(this.CreateBST(new int[] { 1,2,3,4,5,6 }));

            foreach (var input in inputs)
            {
                result.AppendLine($"Total nodes in Complete Binary tree is {this.CountNodes(input)} for the given complete binary tree {this.TraverseBinaryTree(input)} ");
            }

            MessageBox.Show(result.ToString());


        }

        public int CountNodes(Node root)
        {

            if (root == null)
                return 0;


            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            int result = 0;
            Node t;

            while (q.Count > 0)
            {
                result++;
                t = q.Dequeue();
                if (t.left != null)
                    q.Enqueue(t.left);

                if (t.right != null)
                    q.Enqueue(t.right);

            }


            return result;



        }

        private void btn_Unique_Binary_Search_Trees_Click(object sender, EventArgs e)
        {
            

            /*

                Given n, how many structurally unique BST's (binary search trees) that store values 1 ... n?

                Example:

                Input: 3
                Output: 5
                Explanation:
                Given n = 3, there are a total of 5 unique BST's:

                   1         3     3      2      1
                    \       /     /      / \      \
                     3     2     1      1   3      2
                    /     /       \                 \
                   2     1         2                 3

                Catalan Series Formula : Sum (F(i-1)*F(N-i))
                Time Complexity     :   O(N ^ 2)
                Space Complexity    :   O(N);

            */

            StringBuilder result = new StringBuilder();
            List<int> inputs = new List<int>();
            inputs.Add(3);
            inputs.Add(7);

            foreach (var input in inputs)
            {
                result.AppendLine($"There are total of {this.NumTrees(input)} binary search trees can be created for the given {input} nodes ");
                //Also see GetCatalanBinomialCoeff O(N)
            }

            MessageBox.Show(result.ToString());


        }

        static long binomialCoeff(int n, int k)
        {
            long res = 1;

            // Since C(n, k) = C(n, n-k)  
            if (k > n - k)
            {
                k = n - k;
            }

            // Calculate value of [n*(n-1)*---*(n-k+1)] / [k*(k-1)*---*1]  
            for (int i = 0; i < k; ++i)
            {
                res *= (n - i);
                res /= (i + 1);
            }

            return res;
        }

        // A Binomial coefficient based function to find nth catalan  
        // number in O(n) time  
        private long GetCatalanBinomialCoeff(int n)
        {
            // Calculate value of 2nCn  
            long c = binomialCoeff(2 * n, n);

            // return 2nCn/(n+1)  
            return c / (n + 1);
        }

        public int NumTrees(int n)
        {
            return this.GetCatalan(n);
        }

        private int GetCatalan(int n)
        {
            int[] catalan = new int[n + 1];
            catalan[0] = 1;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                    catalan[i] += (catalan[j - 1] * catalan[i - j]);
            }

            return catalan[n];
        }

        private void btn_Sum_Root_to_Leaf_Numbers_Click(object sender, EventArgs e)
        {
            /*
                
                    Given a binary tree containing digits from 0-9 only, each root-to-leaf path could represent a number.

                    An example is the root-to-leaf path 1->2->3 which represents the number 123.

                    Find the total sum of all root-to-leaf numbers.

                    Note: A leaf is a node with no children.

                    Example:

                    Input: [1,2,3]
                        1
                       / \
                      2   3
                    Output: 25
                    Explanation:
                    The root-to-leaf path 1->2 represents the number 12.
                    The root-to-leaf path 1->3 represents the number 13.
                    Therefore, sum = 12 + 13 = 25.
                    Example 2:

                    Input: [4,9,0,5,1]
                        4
                       / \
                      9   0
                     / \
                    5   1
                    Output: 1026
                    Explanation:
                    The root-to-leaf path 4->9->5 represents the number 495.
                    The root-to-leaf path 4->9->1 represents the number 491.
                    The root-to-leaf path 4->0 represents the number 40.
                    Therefore, sum = 495 + 491 + 40 = 1026.
             
            */


            StringBuilder result = new StringBuilder();
            List<Node> inputs = new List<Node>();
            inputs.Add(this.CreateBinaryTreeFromArray(new int?[] { 1, 2, 3 }));
            inputs.Add(this.CreateBinaryTreeFromArray(new int?[] { 4,9,0,5,1}));
            inputs.Add(this.CreateBinaryTreeFromArray(new int?[] { 1,null , 3 }));
            inputs.Add(this.CreateBinaryTreeFromArray(new int?[] { 1, 3, null }));

            foreach (var input in inputs)
            {
                result.AppendLine($"Sum is {this.SumNumbers(input)} for the given binary tree {this.TraverseBinaryTree(input)} ");
            }

            MessageBox.Show(result.ToString());


        }

        public int SumNumbers(Node root)
        {

            if (root == null)
                return 0;

            return this.InOrder(root, 0);

        }

        private int InOrder(Node node, int sum)
        {
            if (node == null)
            {
                return 0;
            }

            if (node.left == null && node.right == null)
                return (sum * 10) + node.data;

            int left = 0;
            int right = 0;



            if (node.left != null)
                left = InOrder(node.left, (sum * 10) + node.data); // 495 + 491
            if (node.right != null)
                right = InOrder(node.right, (sum * 10) + node.data);

            return left + right;

        }

        private void btn_Maximum_Width_of_Binary_Tree_Click(object sender, EventArgs e)
        {
            /*

                    Given a binary tree, write a function to get the maximum width of the given tree. The width of a tree is the maximum width among all levels. The binary tree has the same structure as a full binary tree, but some nodes are null.

                    The width of one level is defined as the length between the end-nodes (the leftmost and right most non-null nodes in the level, where the null nodes between the end-nodes are also counted into the length calculation.

                    Example 1:

                    Input: 

                               1
                             /   \
                            3     2
                           / \     \  
                          5   3     9 

                    Output: 4
                    Explanation: The maximum width existing in the third level with the length 4 (5,3,null,9).
                    Example 2:

                    Input: 

                              1
                             /  
                            3    
                           / \       
                          5   3     

                    Output: 2
                    Explanation: The maximum width existing in the third level with the length 2 (5,3).
                    Example 3:

                    Input: 

                              1
                             / \
                            3   2 
                           /        
                          5      

                    Output: 2
                    Explanation: The maximum width existing in the second level with the length 2 (3,2).
                    Example 4:

                    Input: 

                              1
                             / \
                            3   2
                           /     \  
                          5       9 
                         /         \
                        6           7
                    Output: 8
                    Explanation:The maximum width existing in the fourth level with the length 8 (6,null,null,null,null,null,null,7).


                    Note: Answer will in the range of 32-bit signed integer.

                    Time Complexity     : O(N)
                    Space Complexity    : O(N)

            */

            StringBuilder result = new StringBuilder();
            List<Node> inputs = new List<Node>();
            inputs.Add(this.CreateBinaryTreeFromArray(new int?[] { 1, 3, 2, 5, 3, null, 9 }));
            

            foreach (var input in inputs)
            {
                result.AppendLine($"Width Of Binary Tree is {this.WidthOfBinaryTree(input)} for the given binary tree {this.TraverseBinaryTree(input)} ");
            }

            MessageBox.Show(result.ToString());


        }


        public class QItem
        {
            public Node Node;
            public int Index;
        }


        public int WidthOfBinaryTree(Node root)
        {

            if (root == null)
                return 0;

            int ind = -1;
            int result = 0;
            int sI = 0;
            int eI = 0;

            Queue<QItem> q = new Queue<QItem>();
            q.Enqueue(new QItem() { Node = root, Index = ++ind });
            q.Enqueue(null);
            QItem temp;

            while (q.Count > 0)
            {
                temp = q.Dequeue();
              

                if (temp == null)
                {
                    result = Math.Max(result, ((eI - sI) + 1));
                    sI = 0;
                    eI = 0;
                    if (q.Count == 0)
                        break;
                    q.Enqueue(null);
                }
                else
                {
                    if (sI == 0)
                    {
                        sI = temp.Index;
                    }

                    eI = temp.Index;
                    if (temp.Node.left != null)
                    {
                        q.Enqueue(new QItem() { Node = temp.Node.left, Index = (temp.Index * 2) + 1 });
                    }

                    if (temp.Node.right != null)
                    {
                        q.Enqueue(new QItem() { Node = temp.Node.right, Index = (temp.Index * 2) + 2 });
                    }
                }
            }

            return result;
        }

        private void btn_Binary_Tree_Zigzag_Level_Order_Traversal_Click(object sender, EventArgs e)
        {
            /*
             
                Given a binary tree, return the zigzag level order traversal of its nodes' values. (ie, from left to right, then right to left for the next level and alternate between).

                For example:
                Given binary tree [3,9,20,null,null,15,7],
                    3
                   / \
                  9  20
                    /  \
                   15   7
                return its zigzag level order traversal as:
                [
                  [3],
                  [20,9],
                  [15,7]
                ]

            Time Complexity     :  O(N) where N is the total number of nodes
            Space Complexity    : O (N)

            */


            StringBuilder result = new StringBuilder();
            List<Node> inputs = new List<Node>();
            inputs.Add(this.CreateBinaryTreeFromArray(new int?[] { 3, 9, 20, null, null, 15, 7 }));


            foreach (var input in inputs)
            {
                result.AppendLine($"ZigZag  Of Binary Tree Traversal is {this.GetDataFromListOfList(this.ZigzagLevelOrder(input))} for the given binary tree {this.TraverseBinaryTree(input)} ");
            }

            MessageBox.Show(result.ToString());
        }


        public IList<IList<int>> ZigzagLevelOrder(Node root)
        {

            List<IList<int>> result = new List<IList<int>>();

            if (root == null)
                return result;

            bool rightToLeft = false;
            Queue<Node> q = new Queue<Node>();
            Stack<int> s = new Stack<int>();
            q.Enqueue(root);
            q.Enqueue(null);
            List<int> tempList = new List<int>();
            Node temp;


            while (q.Count > 0)
            {
                temp = q.Dequeue();

                if (temp == null)
                {
                    if (rightToLeft)
                    {
                        result.Add(s.ToList());
                        s = new Stack<int>();
                    }
                    else
                    {
                        result.Add(tempList);
                        tempList = new List<int>();
                    }


                    if (q.Count == 0)
                        break;

                    q.Enqueue(null);
                    rightToLeft = !rightToLeft;
                }
                else
                {

                    if (rightToLeft)
                        s.Push(temp.data);
                    else
                        tempList.Add(temp.data);
    

                if (temp.left != null)
                        q.Enqueue(temp.left);

                    if (temp.right != null)
                        q.Enqueue(temp.right);

                }

            }

            return result;
        }


        private string GetDataFromListOfList(IList<IList<int>> inputs)
        {
            if (inputs.Count == 0)
                return string.Empty;
            StringBuilder result = new StringBuilder();

            foreach (IList<int> input in inputs)
            {
                result.AppendLine();
                result.Append($"[ {string.Join(",",input)} ]" );                
            }

            return result.ToString();
        }

        private void btn_Construct_Binary_Tree_from_Inorder_and_Postorder_Traversal_Click(object sender, EventArgs e)
        {
            /*

                Given inorder and postorder traversal of a tree, construct the binary tree.

                Note:
                You may assume that duplicates do not exist in the tree.

                For example, given

                inorder = [9,3,15,20,7]
                postorder = [9,15,7,20,3]
                Return the following binary tree:

                    3
                   / \
                  9  20
                    /  \
                   15   7

            Refer this link for creating binary tree from Inorder and PreOrder input : https://www.geeksforgeeks.org/construct-tree-from-given-inorder-and-preorder-traversal/

            Time Complexity     : O(N)
            Space Complexity    : O(1)  
                
            */

            StringBuilder result = new StringBuilder();
            List<InutArray> inputs = new List<InutArray>();
            inputs.Add(new InutArray() { InOrder = new int[] { 9, 3, 15, 20, 7 }, PostOrder = new int[] { 9, 15, 7, 20, 3 } });

            foreach (var input in inputs)
            {
                result.AppendLine($" Binary Tree from Inorder : {string.Join(",", input.InOrder)} and Postorder : {string.Join(",", input.PostOrder)} Traversal is {this.TraverseBinaryTree(this.BuildTree(input.InOrder, input.PostOrder))}");
            }

            MessageBox.Show(result.ToString());


        }

        public class InutArray
        {
            public int[] InOrder;
            public int[] PostOrder;
            public int[] PreOrder;
        }

        public Node BuildTree(int[] inorder, int[] postorder)
        {
            int pEnd = postorder.Length - 1;
            return this.Build(inorder, postorder, 0, inorder.Length - 1, ref pEnd);
        }


        private Node Build(int[] inorder, int[] postorder, int start, int end, ref int pEnd)
        {

            if (
                inorder == null || inorder.Length == 0 || 
                postorder == null || postorder.Length == 0 ||
                start > end || pEnd < 0
               )
                return null;


            Node node = null;
            int index = 0;

            index = this.Search(inorder, postorder[pEnd]); //0
            if (index >= 0)
            {
                node = new Node() { data = postorder[pEnd]};
                pEnd--;
                node.right = this.Build(inorder, postorder, index + 1, end, ref pEnd);
                node.left = this.Build(inorder, postorder, start, index - 1, ref pEnd);
            }
            
            return node;
        }


        private int Search(int[] inOrder, int search)
        {

            if (inOrder == null || inOrder.Length == 0)
                return -1;

            for (int i = 0; i < inOrder.Length; i++)
            {
                if (inOrder[i] == search)
                {
                    return i;
                }
            }

            return -1;
        }

        private void btn_Vertical_Order_Traversal_of_a_Binary_Tree_Click(object sender, EventArgs e)
        {
            /*
            
                Given a binary tree, return the vertical order traversal of its nodes values.

                For each node at position (X, Y), its left and right children respectively will be at positions (X-1, Y-1) and (X+1, Y-1).

                Running a vertical line from X = -infinity to X = +infinity, whenever the vertical line touches some nodes, we report the values of the nodes in order from top to bottom (decreasing Y coordinates).

                If two nodes have the same position, then the value of the node that is reported first is the value that is smaller.

                Return an list of non-empty reports in order of X coordinate.  Every report will have a list of values of nodes.

 

                Example 1:



                Input: [3,9,20,null,null,15,7]
                Output: [[9],[3,15],[20],[7]]
                Explanation: 
                Without loss of generality, we can assume the root node is at position (0, 0):
                Then, the node with value 9 occurs at position (-1, -1);
                The nodes with values 3 and 15 occur at positions (0, 0) and (0, -2);
                The node with value 20 occurs at position (1, -1);
                The node with value 7 occurs at position (2, -2).
                Example 2:



                Input: [1,2,3,4,5,6,7]
                Output: [[4],[2],[1,5,6],[3],[7]]
                Explanation: 
                The node with value 5 and the node with value 6 have the same position according to the given scheme.
                However, in the report "[1,5,6]", the node value of 5 comes first since 5 is smaller than 6.
 

                Note:

                The tree will have between 1 and 1000 nodes.
                Each node's value will be between 0 and 1000.

             
             */



            //List<Point> points = new List<Point>();
            //points.Add(new Point() { X = 1, Y = 2 });
            //points.Add(new Point() { X = 4, Y = 1 });
            //points.Add(new Point() { X = 3, Y = 2 });
            //points.Sort((Point X, Point Y) => X.X > Y.X ? -1 : 1 );




            StringBuilder result = new StringBuilder();
            List<Node> inputs = new List<Node>();
            //inputs.Add(this.CreateBinaryTreeFromArray(new int?[] { 1, 2, 3, 4, 5, 6, 7 }));
            //inputs.Add(this.CreateBinaryTreeFromArray(new int?[] { 3, 9, 20, null, null, 15, 7 }));
            //inputs.Add(this.CreateBinaryTreeFromArray(new int?[] { 0, 8, 1, null, null, 3, 7, null, 4, 5, null, null, 2, 6 }));
            //inputs.Add(this.CreateBinaryTreeFromArray(new int?[] { 0, 2, 1, 3, null, null, null, 4, 5, null, 7, 6, null, 10, 8, 11, 9 }));
            inputs.Add(this.CreateBinaryTreeFromArray(new int?[] { 0, 5, 1, 9, null, 2, null, null, null, null, 3, 4, 8, 6, null, null, null, 7 }));
            
            foreach (var input in inputs)
            {
                result.AppendLine($"Vertical Traversal of a tree is  {this.GetDataFromListOfList(this.VerticalTraversal(input))} for the given binary tree {this.TraverseBinaryTree(input)} ");
            }

            MessageBox.Show(result.ToString());
        }



        public IList<IList<int>> VerticalTraversal(Node root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            List<int> t = null;

            if (root == null)
                return result;

            Dictionary<int, List<Point>> dict = new Dictionary<int, List<Point>>();
            int min = 0;
            Traverse(root, ref min, dict, 0, 0);
            List<Point> temp = null;
            dict.TryGetValue(min, out temp);

            while (temp != null)
            {
                temp.Sort((Point P1, Point P2) => P1 == null && P2 ==null ? 0 : 
                                                                              ((P1 != null && P2 == null) || 
                                                                               (P1 == null && P2 != null)
                                                                              ) ? -1 :
                                                                               P1.Y < P2.Y ? 1 : 
                                                                                                P1.Y == P2.Y && P1.X > P2.X ? 1 : -1
                );

                t = new List<int>();

                foreach(var point in temp)
                {
                    t.Add(point.X);
                }

                result.Add(t);
                min++;
                dict.TryGetValue(min, out temp);

            }

            return result;
        }

        private void Traverse(Node node, ref int min, Dictionary<int, List<Point>> dict, int x, int y)
        {
            if (node == null)
                return;

            List<Point> temp = null;
            NodeWithPoint nwp = null;

            Queue<NodeWithPoint> q = new Queue<NodeWithPoint>();
            q.Enqueue(new NodeWithPoint() { Node = node, X = x, Y = y });

            while (q.Count > 0)
            {
                nwp = q.Dequeue();

                dict.TryGetValue(nwp.X, out temp);
                if (temp == null)
                {
                    temp = new List<Point>();
                    temp.Add(new Point() { X = nwp.Node.data, Y = nwp.Y });
                    dict[nwp.X] = temp;
                }
                else
                    dict[nwp.X].Add(new Point() { X = nwp.Node.data, Y = nwp.Y });

                if (nwp.X < min)
                    min = nwp.X;

                if (nwp.Node.left != null)
                    q.Enqueue(new NodeWithPoint() { Node = nwp.Node.left, X = nwp.X - 1, Y = nwp.Y - 1 });

                if (nwp.Node.right != null)
                    q.Enqueue(new NodeWithPoint() { Node = nwp.Node.right, X = nwp.X + 1, Y = nwp.Y - 1 });
            }
        }

        public class NodeWithPoint
        {
            public Node Node;
            public int X;
            public int Y;
        }

        private void btn_Sum_of_Left_Leaves_Click(object sender, EventArgs e)
        {
            /*
            
                Find the sum of all left leaves in a given binary tree.

                Example:

                    3
                   / \
                  9  20
                    /  \
                   15   7

                There are two left leaves in the binary tree, with values 9 and 15 respectively. Return 24.

                Time Complexity     : O(N)
                Space Complexity    : O(N)  we can also perform through recurrsion to avoid O(N)
            */

            StringBuilder result = new StringBuilder();
            List<Node> inputs = new List<Node>();
            //inputs.Add(this.CreateBinaryTreeFromArray(new int?[] { 1, 2, 3, 4, 5, 6, 7 }));
            //inputs.Add(this.CreateBinaryTreeFromArray(new int?[] { 3, 9, 20, null, null, 15, 7 }));
            //inputs.Add(this.CreateBinaryTreeFromArray(new int?[] { 0, 8, 1, null, null, 3, 7, null, 4, 5, null, null, 2, 6 }));
            //inputs.Add(this.CreateBinaryTreeFromArray(new int?[] { 0, 2, 1, 3, null, null, null, 4, 5, null, 7, 6, null, 10, 8, 11, 9 }));
            inputs.Add(this.CreateBinaryTreeFromArray(new int?[] { 3, 9, 20, null, null, 15, 7 }));

            foreach (var input in inputs)
            {
                result.AppendLine($"Sum of Left Leaves is  {this.SumOfLeftLeaves(input)} for the given binary tree {this.TraverseBinaryTree(input)} ");
            }

            MessageBox.Show(result.ToString());

        }

        public int SumOfLeftLeaves(Node root)
        {
            if (root == null)
                return 0;

            Queue<NodeLeftRight> q = new Queue<NodeLeftRight>();

            q.Enqueue(new NodeLeftRight() { Node = root });
            NodeLeftRight temp = null;

            int result = 0;

            while (q.Count > 0)
            {
                temp = q.Dequeue();
                if (temp.IsLeft && temp.Node.left == null && temp.Node.right == null)
                    result += temp.Node.data;

                if (temp.Node.left != null)
                    q.Enqueue(new NodeLeftRight() { Node = temp.Node.left, IsLeft = true });

                if (temp.Node.right != null)
                    q.Enqueue(new NodeLeftRight() { Node = temp.Node.right });

            }

            return result;

        }


        public class NodeLeftRight
        {
            public Node Node;
            public bool IsLeft;
        }

        private void btn_Delete_Node_in_a_BST_Click(object sender, EventArgs e)
        {
            /*
             
                Given a root node reference of a BST and a key, delete the node with the given key in the BST. Return the root node reference (possibly updated) of the BST.

                Basically, the deletion can be divided into two stages:

                Search for a node to remove.
                If the node is found, delete the node.
                Note: Time complexity should be O(height of tree).

                Example:

                root = [5,3,6,2,4,null,7]
                key = 3

                    5
                   / \
                  3   6
                 / \   \
                2   4   7

                Given key to delete is 3. So we find the node with value 3 and delete it.

                One valid answer is [5,4,6,2,null,null,7], shown in the following BST.

                    5
                   / \
                  4   6
                 /     \
                2       7

                Another valid answer is [5,2,6,null,4,null,7].

                    5
                   / \
                  2   6
                   \   \
                    4   7



            
                Time Complexity     : O(H)
                Space Complexity    : O(1)

            */


            StringBuilder result = new StringBuilder();
            List<Common> inputs = new List<Common>();
            //inputs.Add(new KthSmallestInBST() { Tree = this.CreateBST(new int[] { 5, 3, 6, 2, 4,  7 }), K = 3 });
            //inputs.Add(new KthSmallestInBST() { Tree = this.CreateBST(new int[] { 0 }), K = 0 });
            //inputs.Add(new KthSmallestInBST() { Tree = this.CreateBST(new int[] { 1,2 }), K = 2 });
            //inputs.Add(new KthSmallestInBST() { Tree = this.CreateBST(new int[] { 3, 1, 4,2 }), K = 2 });
            inputs.Add(new Common() { Tree = this.CreateBST(new int[] { 5, 3, 6, 2, 4,  7 }), K = 5 });

            foreach (var input in inputs)
            {
                result.AppendLine($"Delete BST for {this.TraverseBinaryTree(input.Tree)} is {this.TraverseBinaryTree(this.DeleteNode(input.Tree, input.K))}");
            }

            MessageBox.Show(result.ToString());


        }

        public Node DeleteNode(Node root, int key)
        {

            if (root == null)
                return null;

            root = Delete(root, key);
            return root;

        }

        private Node Delete(Node root, int key)
        {

            if (root == null) return root;

            if (key < root.data)
                root.left = Delete(root.left, key);
            else if (key > root.data)
                root.right = Delete(root.right, key);
            else
            {
                if (root.left == null)
                    return root.right;
                else if (root.right == null)
                    return root.left;

                root.data = MinValue(root.right);
                root.right = Delete(root.right, root.data);
            }
            return root;
        }


        private int MinValue(Node root)
        {            
            int minv = root.data;
            while (root.left != null)
            {
                minv = root.left.data;
                root = root.left;
            }
            return minv;
        }

        private void btn_All_Elements_in_Two_Binary_Search_Trees_Click(object sender, EventArgs e)
        {

            /*

                Given two binary search trees root1 and root2.

                Return a list containing all the integers from both trees sorted in ascending order.

                Example 1:

                     2                               1                      
                   /    \                         /     \
                1        4                      0         3

                Input: root1 = [2,1,4], root2 = [1,0,3]
                Output: [0,1,1,2,3,4]
                Example 2:

                Input: root1 = [0,-10,10], root2 = [5,1,7,0,2]
                Output: [-10,0,0,1,2,5,7,10]
                Example 3:

                Input: root1 = [], root2 = [5,1,7,0,2]
                Output: [0,1,2,5,7]
                Example 4:

                Input: root1 = [0,-10,10], root2 = []
                Output: [-10,0,10]
                Example 5:


                Input: root1 = [1,null,8], root2 = [8,1]
                Output: [1,1,8,8]
 

                Constraints:

                Each tree has at most 5000 nodes.
                Each node's value is between [-10^5, 10^5].
                   Hide Hint #1  
                Traverse the first tree in list1 and the second tree in list2.
                   Hide Hint #2  
                Merge the two trees in one list and sort it.

                Time Complexity         : O(N+M)
                Space Complexity        : O(N+M)

            */


            StringBuilder result = new StringBuilder();
            List<TreeSame> inputs = new List<TreeSame>();
            inputs.Add(new TreeSame() { Tree1 = this.CreateBST(new int[] { 2,1,4 }), Tree2 = this.CreateBST(new int[] { 1, 0, 3 }) });
         

            foreach (var input in inputs)
            {
                result.AppendLine($"All Elements in Two Binary Search Trees is {string.Join(",",this.GetAllElements(input.Tree1, input.Tree2))} for the given BST \nTree1:  { this.TraverseBinaryTree(input.Tree1)}\nTree2: {this.TraverseBinaryTree(input.Tree2)}");
            }

            MessageBox.Show(result.ToString());



        }

        public IList<int> GetAllElements(Node root1, Node root2)
        {

            List<int> result = new List<int>();
            if (root1 == null && root2 == null)
                return result;

            List<int> res1 = InOrderTraversal(root1);
            List<int> res2 = InOrderTraversal(root2);

            if (res1.Count == 0 && res2.Count > 0)
                return res2;
            else if (res1.Count > 0 && res2.Count == 0)
                return res1;
            else
                return Merge(res1, res2);


        }


        private List<int> Merge(List<int> res1, List<int> res2)
        {
            List<int> result = new List<int>();

            int ires1 = res1.Count - 1;
            int ires2 = res2.Count - 1;


            while (ires1 >= 0 && ires2 >= 0)
            {
                if (res1[ires1] >= res2[ires2])
                {
                    result.Insert(0, res1[ires1]);
                    ires1--;
                }
                else 
                {
                    result.Insert(0, res2[ires2]);
                    ires2--;
                }
                
            }

            while (ires1 >= 0)
            {
                result.Insert(0, res1[ires1]);
                ires1--;
            }

            while (ires2 >= 0)
            {
                result.Insert(0, res2[ires2]);
                ires2--;
            }

            return result;
        }


        private List<int> InOrderTraversal(Node node)
        {
            List<int> result = new List<int>();
            if (node == null)
                return result;

            Stack<Node> s = new Stack<Node>();            
            Node current = node;

            while (s.Count > 0 || current != null)
            {
                while (current != null)
                {
                    s.Push(current);
                    current = current.left;
                }
                current = s.Pop();

                result.Add(current.data);
                current = current.right;

            }

            return result;


        }

        private void btn_Sum_of_Root_To_Leaf_Binary_Numbers_Click(object sender, EventArgs e)
        {
            
            /*

                Given a binary tree, each node has value 0 or 1.  Each root-to-leaf path represents a binary number starting with the most significant bit.  For example, if the path is 0 -> 1 -> 1 -> 0 -> 1, then this could represent 01101 in binary, which is 13.
                For all leaves in the tree, consider the numbers represented by the path from the root to that leaf.
                Return the sum of these numbers.

                Example 1:

                       1
                   /       \
                  0         1
                /  \       /  \
               0    1    0    1


                Input: [1,0,1,0,1,0,1]
                Output: 22
                Explanation: (100) + (101) + (110) + (111) = 4 + 5 + 6 + 7 = 22
 

                Note:

                The number of nodes in the tree is between 1 and 1000.
                node.val is 0 or 1.
                The answer will not exceed 2^31 - 1.
            */

            StringBuilder result = new StringBuilder();
            List<Node> inputs = new List<Node>();
            //inputs.Add(this.CreateBinaryTreeFromArray(new int?[] { 1, 0, 1, 0, 1, 0, 1 }));
            inputs.Add(this.CreateBinaryTreeFromArray(new int?[] { 1, null, 0 }));
            


            foreach (var input in inputs)
            {
                result.AppendLine($"Sum of Root To Leaf Binary Numbers is {SumRootToLeaf(input)} for the given Tree1: {this.TraverseBinaryTree(input)}");
            }

            MessageBox.Show(result.ToString());

        }

        public int SumRootToLeaf(Node root)
        {
            if (root == null)
                return 0;

            return GetSum(root, 0);

        }


        private int GetSum(Node root, int sum)
        {
            if (root == null)
                return 0;

            sum = (sum << 1) + root.data;
            if (root.left == null && root.right == null)
                return sum;


            return GetSum(root.left, sum) + GetSum(root.right, sum);

        }

        private void btn_Insert_into_a_Binary_Search_Tree_Click(object sender, EventArgs e)
        {
            /*
             
                You are given the root node of a binary search tree (BST) and a value to insert into the tree. Return the root node of the BST after the insertion. It is guaranteed that the new value does not exist in the original BST.

                Notice that there may exist multiple valid ways for the insertion, as long as the tree remains a BST after insertion. You can return any of them.

 

                Example 1:


                Input: root = [4,2,7,1,3], val = 5
                Output: [4,2,7,1,3,5]
                Explanation: Another accepted tree is:

                Example 2:

                Input: root = [40,20,60,10,30,50,70], val = 25
                Output: [40,20,60,10,30,50,70,null,null,25]
                Example 3:

                Input: root = [4,2,7,1,3,null,null,null,null,null,null], val = 5
                Output: [4,2,7,1,3,5]
 

                Constraints:

                The number of nodes in the tree will be in the range [0, 104].
                -108 <= Node.val <= 108
                All the values Node.val are unique.
                -108 <= val <= 108
                It's guaranteed that val does not exist in the original BST.


                Time Complexity     :   O(H) H is the height of the tree
                Space Complexity    :   O(1)

             */




            StringBuilder result = new StringBuilder();
            List<Common> inputs = new List<Common>();
            inputs.Add(new Common() { Tree = this.CreateBST(new int[] { 4, 2, 7, 1, 3 }), K = 5 });
            inputs.Add(new Common() { Tree = this.CreateBST(new int[] { 40, 20, 60, 10, 30, 50, 70 }), K = 25 });
            inputs.Add(new Common() { Tree = this.CreateBST(new int[] { 4, 2, 7, 1, 3 }), K = 5 });            
            foreach (var input in inputs)
            {
                result.AppendLine($"For the given Binary Search Tree {string.Join(",",this.InOrderTraversal(input.Tree))} and the value {input.K} the insertion is {string.Join(", ",this.InOrderTraversal(this.InsertIntoBST(input.Tree, input.K)))}");
            }

            MessageBox.Show(result.ToString());

        }


        public Node InsertIntoBST(Node root, int val)
        {


            if (root == null)
            {
                root = new Node() { data = val, val = val };
                return root;
            }

            Node child = root;
            Node parent = root;

            
            while (child!= null)
            {
                parent = child;
                child =  val > child.val ? child.right : child.left;
            }


            if (val > parent.val)
                parent.right = new Node() {data = val, val= val };
            else
                parent.left = new Node() { data = val, val = val };

            return root;

        }

        private void btn_Serialize_and_Deserialize_BST_Click(object sender, EventArgs e)
        {
            /*
             
                Serialization is converting a data structure or object into a sequence of bits so that it can be stored in a file or memory buffer, or transmitted across a network connection link 
                to be reconstructed later in the same or another computer environment. Design an algorithm to serialize and deserialize a binary search tree. There is no restriction on how your
                serialization/deserialization algorithm should work. You need to ensure that a binary search tree can be serialized to a string, and this string can be deserialized to the original tree
                structure. The encoded string should be as compact as possible.

                Example 1:

                Input: root = [2,1,3]
                Output: [2,1,3]
                Example 2:

                Input: root = []
                Output: []
 

                Constraints:

                The number of nodes in the tree is in the range [0, 104].
                0 <= Node.val <= 104
                The input tree is guaranteed to be a binary search tree.

             */

            StringBuilder result = new StringBuilder();
            List<string> inputs = new List<string>();
            inputs.Add("3,2,4,null,null,null,5");
            inputs.Add("2,1,3");
            inputs.Add("");

            Codec codec = new Codec();

            foreach(string input in inputs)
            {
                result.AppendLine($"For the given BST  {input} {Environment.NewLine} Serialization : { codec.serialize(codec.deserialize(input)) }  {Environment.NewLine} De-serialization : { codec.serialize(codec.deserialize(input))}   ");            
            }

            MessageBox.Show(result.ToString());



        }

        public class Codec
        {

            // Encodes a tree to a single string.
            public string serialize(Node root)
            {
                return SerializeBST(root);
            }

            // Decodes your encoded data to tree.
            public Node deserialize(string data)
            {
                return CreateBST(data);

            }


            private Node CreateBST(string data)
            {
                if (string.IsNullOrEmpty(data))
                    return null;

                Queue<Node> q = new Queue<Node>();
                Node temp = null;
                string[] node = data.Split(',');
                int len = node.Length;
                int i = 0;
                Node root = new Node() { data = Convert.ToInt32(node[i]) };
                q.Enqueue(root);

                while (q.Count > 0)
                {
                    temp = q.Dequeue();
                    if (temp == null || i >= len - 1)
                        continue;

                    temp.left = node[++i] == "null" ? null : new Node() { data = Convert.ToInt32(node[i]) };
                    temp.right = node[++i] == "null" ? null : new Node() { data = Convert.ToInt32(node[i]) };

                    q.Enqueue(temp.left);
                    q.Enqueue(temp.right);
                }

                return root;
            }

            private string SerializeBST(Node root)
            {

                if (root == null)
                    return string.Empty;

                List<string> result = new List<string>();
                Node temp;
                Queue<Node> q = new Queue<Node>();
                q.Enqueue(root);

                while (q.Count > 0)
                {
                    temp = q.Dequeue();
                    result.Add($"{(temp == null ? "null" : temp.data.ToString())}");
                    if (temp != null)
                    {
                        q.Enqueue(temp.left);
                        q.Enqueue(temp.right);
                    }
                }

                return string.Join(",", result);
            }
        }

        private void btn_btn_Maximum_Difference_Between_Node_and_Ancestor_Click(object sender, EventArgs e)
        {
            /*

            Given the root of a binary tree, find the maximum value V for which there exist different nodes A and B where V = |A.val - B.val| and 
            A is an ancestor of B.

            A node A is an ancestor of B if either: any child of A is equal to B, or any child of A is an ancestor of B.

            Example 1:
                                         8
                                       /   \
                                      /     \
                                     3        10
                                  /    \       \           
                                 /      \       \
                                1        6       14
                                      /    \     /             
                                     /      \   /   
                                    4       7  13




            Input: root = [8,3,10,1,6,null,14,null,null,4,7,13]
            Output: 7
            Explanation: We have various ancestor-node differences, some of which are given below :
            |8 - 3| = 5
            |3 - 7| = 4
            |8 - 1| = 7
            |10 - 13| = 3
            Among all possible differences, the maximum value of 7 is obtained by |8 - 1| = 7.
            Example 2:


            Input: root = [1,null,2,null,0,3]
            Output: 3
 

            Constraints:

            The number of nodes in the tree is in the range [2, 5000].
            0 <= Node.val <= 105
               Hide Hint #1  
            For each subtree, find the minimum value and maximum value of its descendants.

            Time Complexity         : O(N)
            Space Complexity        : O(1)

            */

            StringBuilder result = new StringBuilder();
            List<Node> inputs = new List<Node>();
            inputs.Add(this.CreateBinaryTreeFromArray(new int?[] { 8, 3, 10, 1, 6, null, 14, null, null, 4, 7, 13 }));
            inputs.Add(this.CreateBinaryTreeFromArray(new int?[] { 1, null, 2, null, 0, 3 }));
            inputs.Add(this.CreateBinaryTreeFromArray(new int?[] { 2, 4, 3, 1, null, 0, 5, null, 6, null, null, null, 7 }));  

            foreach (var input in inputs)
            {
                result.AppendLine($"Maximum Difference Between Node and Ancestor is {MaxAncestorDiff(input)} for the given Tree: {this.TraverseBinaryTree(input)}");
            }

            MessageBox.Show(result.ToString());


        }

        public int MaxAncestorDiff(Node root)
        {
            if (root == null)
                return 0;
            int result = 0;
            GeMaxAncestorDiff(root.val, root.val, root, ref result);

            return result;
        }

        private void GeMaxAncestorDiff(int max, int min, Node root, ref int result)
        {
            if (root == null)
                return;

            result = Math.Max(result, Math.Max(Math.Abs(root.val - max), Math.Abs(root.val - min)));
            min = Math.Min(min, root.val);
            max = Math.Max(max, root.val);

            GeMaxAncestorDiff( max,  min, root.left, ref result);
            GeMaxAncestorDiff(max, min, root.right, ref result);
        }

        private void btn_Populating_Next_Right_Pointers_in_Each_Node_Click(object sender, EventArgs e)
        {
            /*
             
               Note : This solution will work only for perfect binary tree means which has left and right subtree for all the parent trees
               You are given a perfect binary tree where all leaves are on the same level, and every parent has two children. The binary tree has the following definition:

               struct Node {
                 int val;
                 Node *left;
                 Node *right;
                 Node *next;
               }
               Populate each next pointer to point to its next right node. If there is no next right node, the next pointer should be set to NULL.

               Initially, all next pointers are set to NULL.



               Follow up:

               You may only use constant extra space.
               Recursive approach is fine, you may assume implicit stack space does not count as extra space for this problem.


               Example 1:


                                            1
                                       /        \
                                      /          \
                                     2----------> 3
                                  /    \         /   \           
                                 /      \       /     \
                                4------>5----> 6------>7
                                      


               Input: root = [1,2,3,4,5,6,7]
               Output: [1,#,2,3,#,4,5,6,7,#]
               Explanation: Given the above perfect binary tree (Figure A), your function should populate each next pointer to point to its next right node, just like in Figure B. The serialized output is in level order as connected by the next pointers, with '#' signifying the end of each level.


               Constraints:

               The number of nodes in the given tree is less than 4096.
               -1000 <= node.val <= 1000

                Time Complexity     : O(N)
                Space Complexity    : O(1)

            */


            StringBuilder result = new StringBuilder();
            List<Node> inputs = new List<Node>();
            inputs.Add(this.CreateBinaryTreeFromArray(new int?[] {1, 2, 3, 4, 5, null, 7 }));

            foreach (var input in inputs)
            {
                result.AppendLine($"Populating Next Right Pointers in Each Node for the given Tree: {this.TraverseBinaryTree(input, true)} is {this.TraverseBinaryTree(ConnectToNextNodeWithAuxMemoryNoMemory(input))}");
            }

            MessageBox.Show(result.ToString());
        }


        private Node ConnectToNextNodeWithAuxMemoryNoMemory(Node root)
        {
            var leftNode = root;
            while (leftNode != null && leftNode.left != null)
            {
                PopulateNode(leftNode);
                leftNode = leftNode.left;
            }
            return root;
        }

        private void PopulateNode(Node selectedNode)
        {
            var currentNode = selectedNode;
            while (currentNode != null)
            {
               if (currentNode.left != null)
                    currentNode.left.next = currentNode.right;
                if (currentNode.next != null)
                    currentNode.right.next = currentNode.next.left!= null ? currentNode.next.left : currentNode.next.right;
                currentNode = currentNode.next;
            }
        }

        private void btn_Range_Sum_of_BST_Click(object sender, EventArgs e)
        {
            /*
                    Given the root node of a binary search tree, return the sum of values of all nodes with a value in the range [low, high].

                    Example 1:

                            
                                         10
                                       /   \
                                      /     \
                                     5        15
                                   /    \       \           
                                  /      \       \
                                 3        7       18
                                      


                    Input: root = [10,5,15,3,7,null,18], low = 7, high = 15
                    Output: 32
                    Example 2:


                    Input: root = [10,5,15,3,7,13,18,1,null,6], low = 6, high = 10
                    Output: 23
                                        10
                                       /   \
                                      /     \
                                     5        15
                                   /    \       \           
                                  /      \       \
                                 3        7       18
                                /        /
                               /        /
                              1        6
                            
                    Constraints:

                    The number of nodes in the tree is in the range [1, 2 * 104].
                    1 <= Node.val <= 105
                    1 <= low <= high <= 105
                    All Node.val are unique.
             
                    Time Complexity     : O(N)
                    Space Complexity    : O(1)
                    
             */

            StringBuilder result = new StringBuilder();
            List<Common> inputs = new List<Common>();
            inputs.Add(new Common() { Tree = this.CreateBST(new int[] { 10, 5, 15, 3, 7,  18 }), low = 7, high = 15 });
            inputs.Add(new Common() { Tree = this.CreateBST(new int[] { 10, 5, 15, 3, 7, 13, 18, 1,  6 }), low = 6, high = 10 });
            foreach (var input in inputs)
            {
                result.AppendLine($"Range Sum of BST for the given BST tree {this.TraverseBinaryTree(input.Tree)} for low: {input.low} and high : {input.high} is {this.RangeSumBST(input.Tree, input.low, input.high)}");
            }

            MessageBox.Show(result.ToString());
        }
        public int RangeSumBST(Node root, int low, int high)
        {

            return GetRangeSum(root, low, high);

        }


        private int GetRangeSum(Node root, int l, int h)
        {
            if (root == null)
                return 0;

            int result = 0;


            if (root.val >= l && root.val <= h)
            {
                result += root.val;
                result += GetRangeSum(root.left, l, h);
                result += GetRangeSum(root.right, l, h);
            }
            else if (root.val >= l)           
                result += GetRangeSum(root.left, l, h);            
            else 
                result += GetRangeSum(root.right, l, h);
            
            return result;

        }

        private void btn_Binary_Tree_Tilt_Click(object sender, EventArgs e)
        {
            /*
            
            Given the root of a binary tree, return the sum of every tree node's tilt.

            The tilt of a tree node is the absolute difference between the sum of all left subtree node values and all right subtree node values. 
            If a node does not have a left child, then the sum of the left subtree node values is treated as 0. The rule is similar if there the node does not have a
            right child.

 

            Example 1:
            
                                         1
                                       /   \
                                      /     \
                                     2       3
                           


            Input: root = [1,2,3]
            Output: 1
            Explanation: 
            Tilt of node 2 : |0-0| = 0 (no children)
            Tilt of node 3 : |0-0| = 0 (no children)
            Tile of node 1 : |2-3| = 1 (left subtree is just left child, so sum is 2; right subtree is just right child, so sum is 3)
            Sum of every tilt : 0 + 0 + 1 = 1
            
            Example 2:

            
                                         4
                                       /   \
                                      /     \
                                     2       9
                                   /    \       \           
                                  /      \       \
                                 3        5       7


            Input: root = [4,2,9,3,5,null,7]
            Output: 15
            Explanation: 
            Tilt of node 3 : |0-0| = 0 (no children)
            Tilt of node 5 : |0-0| = 0 (no children)
            Tilt of node 7 : |0-0| = 0 (no children)
            Tilt of node 2 : |3-5| = 2 (left subtree is just left child, so sum is 3; right subtree is just right child, so sum is 5)
            Tilt of node 9 : |0-7| = 7 (no left child, so sum is 0; right subtree is just right child, so sum is 7)
            Tilt of node 4 : |(3+5+2)-(9+7)| = |10-16| = 6 (left subtree values are 3, 5, and 2, which sums to 10; right subtree values are 9 and 7, which sums to 16)
            Sum of every tilt : 0 + 0 + 0 + 2 + 7 + 6 = 15
            Example 3:


            Input: root = [21,7,14,1,1,2,2,3,3]
            Output: 9
 
                    
                                         21
                                       /     \
                                      /       \
                                    7          14
                                 /    \      /     \           
                                /      \    /       \
                               1        1  2        2
                            /    \              
                           /      \  
                          3        3

            Constraints:

            The number of nodes in the tree is in the range [0, 104].
            -1000 <= Node.val <= 1000
               Hide Hint #1  
            Don't think too much, this is an easy problem. Take some small tree as an example.
               Hide Hint #2  
            Can a parent node use the values of its child nodes? How will you implement it?
               Hide Hint #3  
            May be recursion and tree traversal can help you in implementing.
               Hide Hint #4  
            What about postorder traversal, using values of left and right childs?

                Time Complexity         : O(N)
                Space Complexity        : O(1)
             
            */


            StringBuilder result = new StringBuilder();
            List<Common> inputs = new List<Common>();
            inputs.Add(new Common() { Tree = this.CreateBinaryTreeFromArray(new int?[] { 1, 2, 3 }) });
            inputs.Add(new Common() { Tree = this.CreateBinaryTreeFromArray(new int?[] { 4, 2, 9, 3, 5, null, 7 }) });
            inputs.Add(new Common() { Tree = this.CreateBinaryTreeFromArray(new int?[] { 21, 7, 14, 1, 1, 2, 2, 3, 3 }) });
            


            foreach (var input in inputs)
            {
                result.AppendLine($"Binary Tree Tilt for the given Binary tree {this.TraverseBinaryTree(input.Tree)} is {this.FindTilt(input.Tree)}");
            }

            MessageBox.Show(result.ToString());

        }

        public int FindTilt(Node root)
        {
            if (root == null)
                return 0;

            int tilt = 0;
            GetTilt(root, ref tilt);
            return tilt;

        }


        private int GetTilt(Node root, ref int sum)
        {
            if (root == null)
                return 0;

            int lr = GetTilt(root.left, ref sum);
            int rr = GetTilt(root.right, ref sum);
            sum += Math.Abs(lr - rr);

            return lr + rr + root.val;
        }

        private void btn_Increasing_Order_Search_Tree_Click(object sender, EventArgs e)
        {
            /*
             
                    Given the root of a binary search tree, rearrange the tree in in-order so that the leftmost node in the tree is now the root of the tree, and every node has no left child and only one right child.

                    Example 1:
                                		 5									1
                                       /   \								 \
                                      /     \								  2
                                     3        6								   \		
                                   /    \       \           					3
                                  /      \       \							     \
                                 2        4       8								  4
								/				 / \							   \
							   /				/	\								5		
							  1				   7	 9							     \
																					  6				
																					   \
																					    7
																						 \
																						  8
																						   \
																						    9
                                        
                    Input: root = [5,3,6,2,4,null,8,1,null,null,null,7,9]
                    Output: [1,null,2,null,3,null,4,null,5,null,6,null,7,null,8,null,9]
            
                    Example 2:
                                         5									1
                                       /   \								 \
                                      /     \								  5
                                     1       7								   \		
                                                                                7
                    Input: root = [5,1,7]
                    Output: [1,null,5,null,7]
 

                    Constraints:

                    The number of nodes in the given tree will be in the range [1, 100].
                    0 <= Node.val <= 1000
             
                    Time Complexity         :   O(N) where N is the number of nodes in BST
                    Space Complexity        :   O(N)

             */


            StringBuilder result = new StringBuilder();
            List<Common> inputs = new List<Common>();
            inputs.Add(new Common() { Tree = this.CreateBST(new int[] { 5, 3, 6, 2, 4,  8, 1, 7, 9 })});
            inputs.Add(new Common() { Tree = this.CreateBST(new int[] { 5,1,7 })});
            foreach (var input in inputs)
            {
                result.AppendLine($"Increasing Order Search Tree for the given BST tree {this.TraverseBinaryTree(input.Tree)} is {this.TraverseBinaryTree(this.IncreasingBST(input.Tree))}");
            }

            MessageBox.Show(result.ToString());
        }

        public Node IncreasingBST(Node root)
        {
            if (root == null)
                return root;


            Node result = null;
            InOrderTreeNode(root, ref result);
            return result;
        }

        private void InOrderTreeNode(Node root, ref Node result)
        {

            if (root == null)
                return;

            InOrderTreeNode(root.left, ref result);
            InsertIntoBSTForIncreasingBST(ref result, root.val);
            InOrderTreeNode(root.right, ref result);
        }


        private void InsertIntoBSTForIncreasingBST(ref Node node, int data)
        {

            if (node == null)
            {
                node = new Node() { data = data };
            }
            else
            {
                InsertIntoBSTForIncreasingBST(ref node.right, data);
            }
        }

        private void btn_Binary_Search_Tree_Iterator_Click(object sender, EventArgs e)
        {
            /*
             Implement the BSTIterator class that represents an iterator over the in-order 
             traversal of a binary search tree (BST):

                BSTIterator(TreeNode root) Initializes an object of the BSTIterator class. The root of the BST 
                is given as part of the constructor. The pointer should be initialized to a non-existent number 
                smaller than any element in the BST. 
                
                boolean hasNext() Returns true if there exists a number in the traversal to the right of the 
                pointer, otherwise returns false.
                
                int next() Moves the pointer to the right, then returns the number at the pointer.
                Notice that by initializing the pointer to a non-existent smallest number, the first call to 
                next() will return the smallest element in the BST.

                You may assume that next() calls will always be valid. That is, there will be at least a next 
                number in the in-order traversal when next() is called.

 

                Example 1:

                             		  7					
                                    /   \				
                                   /     \				
                                  3        15				                           			
                        				   / \		
                            			  /	  \		
                          				 7	   9		
                        								                        								
                Input
                ["BSTIterator", "next", "next", "hasNext", "next", "hasNext", "next", "hasNext", "next", "hasNext"]
                [[[7, 3, 15, null, null, 9, 20]], [], [], [], [], [], [], [], [], []]
                Output
                [null, 3, 7, true, 9, true, 15, true, 20, false]

                Explanation
                BSTIterator bSTIterator = new BSTIterator([7, 3, 15, null, null, 9, 20]);
                bSTIterator.next();    // return 3
                bSTIterator.next();    // return 7
                bSTIterator.hasNext(); // return True
                bSTIterator.next();    // return 9
                bSTIterator.hasNext(); // return True
                bSTIterator.next();    // return 15
                bSTIterator.hasNext(); // return True
                bSTIterator.next();    // return 20
                bSTIterator.hasNext(); // return False
 

                Constraints:

                The number of nodes in the tree is in the range [1, 105].
                0 <= Node.val <= 106
                At most 105 calls will be made to hasNext, and next.
 

                Follow up:

                Could you implement next() and hasNext() to run in average O(1) time and use O(h) memory, 
                where h is the height of the tree?
             
                Time Complexity     :   O(N) where n is the total number of nodes
                Space Complexity    :   O(N) 
                
             */
            StringBuilder result = new StringBuilder();
            List<Common> inputs = new List<Common>();
            inputs.Add(new Common() { Tree = this.CreateBST(new int[] { 7, 3, 15,9,20 }), 
                                      operations = new List<string>() { "next", "next", "hasNext", "next", "hasNext", "next", "hasNext", "next", "hasNext" } });
            foreach (var input in inputs)
            {
                BSTIterator bst = new BSTIterator(input.Tree);
                result.AppendLine($"Binary Search Tree Iterator for the given BST tree {this.TraverseBinaryTree(input.Tree)} is {Environment.NewLine}");
                foreach(string s in input.operations)
                {
                    result.AppendLine($"{s} : {(s == "next" ? bst.Next().ToString() : bst.HasNext().ToString())}");
                }
            }

            MessageBox.Show(result.ToString());
        }

        public class BSTIterator
        {

            Queue<Node> q = new Queue<Node>();
            public BSTIterator(Node root)
            {
                InOrderTraversal(root);
            }


            public int Next()
            {
                if (q.Count > 0)
                {
                    return q.Dequeue().val;
                }

                return -1;
            }

            public bool HasNext()
            {
                return q.Count > 0;
            }

            private void InOrderTraversal(Node root)
            {
                if (root == null)
                    return;

                InOrderTraversal(root.left);
                q.Enqueue(root);
                InOrderTraversal(root.right);
            }
        }

        private void btn_Validate_Binary_Search_Tree_Click(object sender, EventArgs e)
        {
            /*
                Given the root of a binary tree, determine if it is a valid binary search tree (BST).

                A valid BST is defined as follows:

                The left subtree of a node contains only nodes with keys less than the node's key.
                The right subtree of a node contains only nodes with keys greater than the node's key.
                Both the left and right subtrees must also be binary search trees.
 

                Example 1:
                                            2
                                        /       \
                                       /         \
                                      1          3



                Input: root = [2,1,3]
                Output: true
                
                Example 2:

                                            5
                                        /       \
                                       /         \
                                      1           4
                                                /   \
                                               /     \
                                              3       6

                Input: root = [5,1,4,null,null,3,6]
                Output: false
                Explanation: The root node's value is 5 but its right child's value is 4.
 

                Constraints:

                The number of nodes in the tree is in the range [1, 104].
                -231 <= Node.val <= 231 - 1
             
                Time Complexity     : O(N)
                Space Complexity    : O(1)

             */


            StringBuilder result = new StringBuilder();
            List<Common> inputs = new List<Common>();
            inputs.Add(new Common() { Tree = this.CreateBinaryTreeFromArray(new int?[] { 2,1,3 }) });
            inputs.Add(new Common() { Tree = this.CreateBinaryTreeFromArray(new int?[] { 5, 1, 4, null, null, 3, 6 }) });
            inputs.Add(new Common() { Tree = this.CreateBinaryTreeFromArray(new int?[] { 1,1}) });
            foreach (var input in inputs)
            {
                result.AppendLine($"Given BST tree {this.TraverseBinaryTree(input.Tree)} is {(this.IsValidBST(input.Tree) ? "" : "not")} BST Tree");
            }

            MessageBox.Show(result.ToString());
        }

        public bool IsValidBST(Node root)
        {

            if (root == null)
                return false;

            return IsBST(root, long.MinValue, long.MaxValue);
        }

        public bool IsBST(Node root, long min, long max)
        {
            if (root == null)
                return true;

            if (min < root.val && root.val < max)
                return (IsBST(root.left, min, root.val) && IsBST(root.right, root.val, max));

            return false;
        }

        private void btn_Construct_Binary_Tree_from__PreOrder_and_InOrder_Traversal_Click(object sender, EventArgs e)
        {
            /*
             
                Given two integer arrays preorder and inorder where preorder is the preorder traversal of a binary tree and inorder is the inorder traversal of the same tree, construct and return the binary tree.

 

                Example 1:

                    3
                   / \
                  9  20
                    /  \
                   15   7
                    

                Input: preorder = [3,9,20,15,7], inorder = [9,3,15,20,7]
                Output: [3,9,20,null,null,15,7]
                
                Example 2:
                Input: preorder = [-1], inorder = [-1]
                Output: [-1]
 

                Constraints:

                1 <= preorder.length <= 3000
                inorder.length == preorder.length
                -3000 <= preorder[i], inorder[i] <= 3000
                preorder and inorder consist of unique values.
                Each value of inorder also appears in preorder.
                preorder is guaranteed to be the preorder traversal of the tree.
                inorder is guaranteed to be the inorder traversal of the tree.
            
                Time Complexity     : O(N)
                Space Complexity    : O(1)  

             */

            StringBuilder result = new StringBuilder();
            List<InutArray> inputs = new List<InutArray>();
            inputs.Add(new InutArray() { PreOrder = new int[] { 3, 9, 20, 15, 7 }, InOrder = new int[] { 9, 3, 15, 20, 7 } });
            inputs.Add(new InutArray() { PreOrder = new int[] { 1,2 }, InOrder = new int[] { 1,2 } });

            foreach (var input in inputs)
            {
                result.AppendLine($" Binary Tree from Preorder : {string.Join(",", input.PreOrder)} and InOrder : {string.Join(",", input.InOrder)} Traversal is {this.TraverseBinaryTree(this.BuildTree_PreOrder_InOrder(input.PreOrder, input.InOrder))}");
            }

            MessageBox.Show(result.ToString());


        }


        public Node BuildTree_PreOrder_InOrder(int[] preorder, int[] inorder)
        {
            int inc = 0;
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < inorder.Length; i++)
                dict[inorder[i]] = i;

            return Build_PreOrder_InOrder(preorder, inorder, 0, inorder.Length - 1, ref inc, dict);

        }

        public Node Build_PreOrder_InOrder(int[] preOrder, int[] inOrder, int start, int end, ref int inc, Dictionary<int,int> dict)
        {

            if (inc >= preOrder.Length || start > end)
                return null;

            int index = dict[preOrder[inc]];
            Node node = new Node() { data = preOrder[inc++] };

            if (start == end)
                return node;

            if (index >= 0)
            {
                node.left = Build_PreOrder_InOrder(preOrder, inOrder, start, index - 1, ref inc, dict);
                node.right = Build_PreOrder_InOrder(preOrder, inOrder, index + 1, end, ref inc, dict);
            }
            else
                return null;
            return node;
        }
    }

}
