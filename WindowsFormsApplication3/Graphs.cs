using System;
using System.Collections;
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
    public partial class Graphs : Form
    {
        public Graphs()
        {
            InitializeComponent();
        }

        private void btn_Traverse_a_graph_with_Depth_First_Search_Click(object sender, EventArgs e)
        {
              /*
                A->B,C
                B->A,C,D
                C->B,D
                D->B,C
                E->F
                F->E
             */

            Graph graph = new Graph() { Nodes = new Dictionary<string, GraphNode>()};

            GraphNode a = new GraphNode() { data = "A", edges = new List<GraphNode>() };
            GraphNode b = new GraphNode() { data = "B", edges = new List<GraphNode>() };
            GraphNode c = new GraphNode() { data = "C", edges = new List<GraphNode>() };
            GraphNode d = new GraphNode() { data = "D", edges = new List<GraphNode>() };
            GraphNode ee = new GraphNode() { data = "E", edges = new List<GraphNode>() };
            GraphNode f = new GraphNode() { data = "F", edges = new List<GraphNode>() };

            a.edges.Add(b);
            b.edges.Add(a);
            b.edges.Add(c);
            b.edges.Add(d);
            c.edges.Add(b);
            c.edges.Add(d);
            d.edges.Add(b);
            d.edges.Add(c);
            ee.edges.Add(f);
            f.edges.Add(ee);

            graph.Nodes.Add(a.data, a);
            graph.Nodes.Add(ee.data, ee);
            graph.Nodes.Add(f.data, f);

            if (graph == null)
            {
                MessageBox.Show("Empty Graph");
            }

            List<string> visited = new List<string>();
            
            StringBuilder result = new StringBuilder();
            

            foreach(string key in graph.Nodes.Keys)
            {                                    
                DepthFirstRecursive(visited, graph.Nodes[key]);                                
            }

            result.Append("Depth First Traversal of a graph \n" );

            foreach (var key in visited)
            {
                result.Append($" {key} ");
            }

            visited.Clear();
            result.Append("\n Breadth First Traversal of a graph \n");
            BreadthFirstRecursive(visited, graph);

            foreach (var key in visited)
            {
                result.Append($" {key} ");
            }

            MessageBox.Show(result.ToString());


        }
        
        public void DepthFirstRecursive(List<string> visited, GraphNode edges)
        {
            if (edges != null)
            {                
                if (!visited.Contains(edges.data))
                {
                    visited.Add(edges.data);
                    foreach (var edge in edges.edges)
                    {
                        DepthFirstRecursive(visited, edge);
                    }
                }
            }            
        }


        public void BreadthFirstRecursive(List<string> visited, Graph graph)
        {
            if (graph != null)
            {                    
                    Queue<GraphNode> queue = new Queue<GraphNode>();
                    foreach (var key in graph.Nodes.Keys)
                    {                       
                        queue.Enqueue(graph.Nodes[key]);
                    }

                    while (queue.Count > 0)
                    {
                        var node = queue.Dequeue();

                        if (!visited.Contains(node.data))
                        {
                            visited.Add(node.data);
                            foreach (var n in node.edges)
                            {                              
                                queue.Enqueue(n);                               
                            }
                        }
                    }
            }                            
        }


        
        private void btn_Traverse_a_graph_with_Depth_First_Search_To_Find_Dependencies_Of_A_Node_Click(object sender, EventArgs e)
        {
            /* Job B has to start after Job A completes
               A->B
               F->B
               E->A
               C->D                              
               G->E
               G->F
            
            Order of the Job
            f ,g ,e ,a ,b ,c ,d
            g, f, e, a, b, c, d
            
            g->e->a->f->b->c->d
            


            */

            Graph graph = new Graph() { Nodes = new Dictionary<string, GraphNode>() };

            GraphNode a = new GraphNode() { data = "A", edges = new List<GraphNode>() };
            GraphNode b = new GraphNode() { data = "B", edges = new List<GraphNode>() };
            GraphNode c = new GraphNode() { data = "C", edges = new List<GraphNode>() };
            GraphNode d = new GraphNode() { data = "D", edges = new List<GraphNode>() };
            GraphNode ee = new GraphNode() { data = "E", edges = new List<GraphNode>() };
            GraphNode f = new GraphNode() { data = "F", edges = new List<GraphNode>() };
            GraphNode g = new GraphNode() { data = "G", edges = new List<GraphNode>() };

            b.edges.Add(a);
            a.edges.Add(ee);
            ee.edges.Add(g);
            b.edges.Add(f);
            f.edges.Add(g);
            d.edges.Add(c);
            
            graph.Nodes.Add(b.data, b);                     
            graph.Nodes.Add(d.data, d);



            if (graph == null)
            {
                MessageBox.Show("Empty Graph");
            }

            List<string> visited = new List<string>();

            StringBuilder result = new StringBuilder();

            foreach (string key in graph.Nodes.Keys)
            {
                DepthFirstRecursiveForDependencies(visited, graph.Nodes[key]);
            }

            result.Append("Depth First Traversal of a graph \n");
            foreach (var key in visited)
            {
                result.Append($" {key} ");
            }

            visited.Clear();
            Stack<string> visitedStack = new Stack<string>();
            result.Append("\n Breadth First Traversal of a graph \n");
            BreadthFirstRecursiveForDependencies(visitedStack, graph);
            
            foreach (var key in visitedStack)
            {
                result.Append($" {key} ");
            }

            MessageBox.Show(result.ToString());            
        }

        public void DepthFirstRecursiveForDependencies(List<string> visited, GraphNode edges)
        {
            if (edges != null)
            {
                if (!visited.Contains(edges.data))
                {                    
                    foreach (var edge in edges.edges)
                    {
                        DepthFirstRecursiveForDependencies(visited, edge);                        
                    }
                    visited.Add(edges.data);
                }
            }
        }

        public void BreadthFirstRecursiveForDependencies(Stack<string> visited, Graph graph)
        {
            if (graph!= null)
            {
                Stack s = new Stack();                
                Queue<GraphNode> queue = new Queue<GraphNode>();
                
                foreach (var key in graph.Nodes.Keys)
                {
                    queue.Enqueue(graph.Nodes[key]);
                }

                while (queue.Count > 0)
                {
                    var node = queue.Dequeue();

                    if (!visited.Contains(node.data))
                    {                        
                        foreach (var edge in node.edges)
                        {
                            queue.Enqueue(edge);
                        }
                        visited.Push(node.data);
                    }
                }
            }
        }

        public class Graph
        {
            public Dictionary<string, GraphNode> Nodes;
        }


        public class GraphNode
        {
            public string data;
            public List<GraphNode> edges;
        }
    }
}
