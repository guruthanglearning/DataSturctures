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

                if (
                        (tp != null && tq != null && tp.data != tq.data) ||
                         (tp != null && tq == null) ||
                         (tp == null && tq != null)
                   )
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
                a binary tree in which the left and right subtrees of every node differ in height by no more than 1.

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
                        root = new Node() { data = input[i].Value };
                        q.Enqueue(root);
                        break;
                    }
                }

                while(i < l)
                {
                    temp = q.Dequeue();
                    if (++i < l && input[i].HasValue)
                    {
                        temp.left = new Node() {data = input[i].Value };
                        q.Enqueue(temp.left);
                    }

                    if (++i < l && input[i].HasValue)
                    {
                        temp.right = new Node() { data = input[i].Value };
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
                Given a binary tree and a sum, determine if the tree has a root-to-leaf path such that adding up all 
                the values along the path equals the given sum.
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
    }
}
