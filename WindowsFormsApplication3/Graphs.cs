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
            a.edges.Add(c);
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
            /*
               A->B,C
               B->A,C,D
               C->B,D
               D->B,C
               E->F
               F->E                                                                                          
            */

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
            /*
             A->B,C
             B->A,C,D
             C->B,D
             D->B,C
             E->F
             F->E                         
            
            Graph --> A
                      E
                      F
          */

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
            /* 
            
            Job B has to start after Job A completes
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
            
                                             B                              D
                                           /   \                            |
                                          /     \                           |
                                         A       F                          C
                                        /         \
                                       /           \
                                      /             \
                                     E---------------G                                 
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
            b.edges.Add(f);
            a.edges.Add(ee);
            ee.edges.Add(g);            
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
            /*
             
                                             B                              D
                                           /   \                            |
                                          /     \                           |
                                         A       F                          C
                                        /         \
                                       /           \
                                      /             \
                                     E---------------G  
                                     
               A->B
               F->B
               E->A
               C->D                              
               G->E
               G->F

             */

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

            /*
             
                                             B                              D
                                           /   \                            |
                                          /     \                           |
                                         A       F                          C
                                        /         \
                                       /           \
                                      /             \
                                     E---------------G                                
             */
            if (graph!= null)
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
                        foreach (var edge in node.edges)
                        {
                            queue.Enqueue(edge);
                        }
                        visited.Push(node.data);
                    }
                }
            }
        }

        public class GraphNode
        {
            public string data;
            public List<GraphNode> edges;
        }


        public class Graph
        {
            public Dictionary<string, GraphNode> Nodes;
        }

        public class GraphWeight
        {
            public string Data;
            public List<Edge> Edges;

            public GraphWeight()
            {
                Edges = new List<Edge>();
            }
        }

        public class Edge
        {
            public GraphWeight Node;
            public int Weight;
        }

        private void btn_Given_a_weighted_graph_print_the_path_of_the_each_node_with_weight_Click(object sender, EventArgs e)
        {

            /*
                						A
                                     /  |  \
					                /	|	\
				                   1	2	 3
				                  /		|	  \
				                 B		C	   D
				                /		|
			                   8		4
			                  /			|
			                 G-----    E                        
		                   /   \   \     |
		                  7		10  \    5
		                 /		 \   6   |
		                H 		  M   \  |
                                       \-F
             */
            GraphWeight A = new GraphWeight() { Data = "A" };
            GraphWeight B = new GraphWeight() { Data = "B" };
            GraphWeight C = new GraphWeight() { Data = "C" };
            GraphWeight D = new GraphWeight() { Data = "D" };
            GraphWeight E = new GraphWeight() { Data = "E" };
            GraphWeight F = new GraphWeight() { Data = "F" };
            GraphWeight G = new GraphWeight() { Data = "G" };
            GraphWeight H = new GraphWeight() { Data = "H" };
            GraphWeight M = new GraphWeight() { Data = "M" };

            A.Edges.Add(new Edge() {Node = B, Weight = 1 });
            A.Edges.Add(new Edge() { Node = C, Weight = 2 });
            A.Edges.Add(new Edge() { Node = D, Weight = 3 });

            B.Edges.Add(new Edge() { Node = G, Weight = 8 });

            C.Edges.Add(new Edge() { Node = E, Weight = 4 });
            E.Edges.Add(new Edge() { Node = F, Weight = 5 });
            F.Edges.Add(new Edge() { Node = G, Weight = 6 });
            G.Edges.Add(new Edge() { Node = H, Weight = 7 });
            G.Edges.Add(new Edge() { Node = M, Weight = 10 });

            Dictionary<string, string> nodeWeight = new Dictionary<string, string>();
            StringBuilder result = new StringBuilder();
            nodeWeight.Add(A.Data, "0");

            TraverseGraphForEdges(A, nodeWeight, 0);

            result.AppendLine("Depth First Traversal");
            foreach (string key in nodeWeight.Keys)
            {
                result.AppendLine($"{key} \t: {nodeWeight[key]}");
            }

            nodeWeight = new Dictionary<string, string>();

            this.TraverseGraphForEdgesBFS(A, ref nodeWeight);
            result.AppendLine();
            result.AppendLine("Breath First Traversal");
            foreach (string key in nodeWeight.Keys)
            {
                result.AppendLine($"{key} \t: {nodeWeight[key]}");
            }


            nodeWeight = new Dictionary<string, string>();
            this.TraverseGraphForEdgesDFS(A, ref nodeWeight);
            result.AppendLine();
            result.AppendLine("Depth First Traversal");
            foreach (string key in nodeWeight.Keys)
            {
                result.AppendLine($"{key} \t: {nodeWeight[key]}");
            }

            MessageBox.Show($"Node path is \n {result.ToString()}");

        }

        private void TraverseGraphForEdgesBFS(GraphWeight node, ref Dictionary<string, string> result)
        {
            if (node == null )
            {
                return;
            }

            if (result == null)
            {
                result = new Dictionary<string, string>();
            }

            Queue<GraphWeight> qg= new Queue<GraphWeight>();
            Queue<int> qt = new Queue<int>();
            qg.Enqueue(node);
            qt.Enqueue(0);

            int nodeValue = 0;
            GraphWeight graphNode = null;

            while(qg.Count > 0)
            {
                graphNode = qg.Dequeue();
                nodeValue = qt.Dequeue();

                if (result.ContainsKey(graphNode.Data))
                {
                    result[graphNode.Data] += $",{nodeValue}";
                }
                else
                {
                    result[graphNode.Data] = $"{nodeValue}";                    
                }

                foreach (Edge n in graphNode.Edges)
                {
                    qg.Enqueue(n.Node);
                    qt.Enqueue(nodeValue + n.Weight);
                }
            }
        }

        private void TraverseGraphForEdgesDFS(GraphWeight node, ref Dictionary<string, string> result)
        {
            if (node == null)
            {
                return;
            }

            if (result == null)
            {
                result = new Dictionary<string, string>();
            }

            Stack<GraphWeight> qg = new Stack<GraphWeight>();
            Stack<int> qt = new Stack<int>();
            qg.Push(node);
            qt.Push(0);

            int nodeValue = 0;
            GraphWeight graphNode = null;

            while (qg.Count > 0)
            {
                graphNode = qg.Pop();
                nodeValue = qt.Pop();

                if (result.ContainsKey(graphNode.Data))
                {
                    result[graphNode.Data] += $",{nodeValue}";
                }
                else
                {
                    result.Add(graphNode.Data, $"{nodeValue}");
                }

                foreach (Edge n in graphNode.Edges)
                {
                    qg.Push(n.Node);
                    qt.Push(nodeValue + n.Weight);
                }
            }
        }


        public void TraverseGraphForEdges(GraphWeight node, Dictionary<string, string> result, int sum)
        {
            
            if (node != null)
            {
                foreach(var edge in node.Edges)
                {
                    
                    if (!result.ContainsKey(edge.Node.Data))
                    {
                        result.Add(edge.Node.Data, $"{(sum + edge.Weight)}");
                    }
                    else
                    {
                        result[edge.Node.Data] += $", {(sum + edge.Weight)}";
                    }

                    TraverseGraphForEdges(edge.Node, result, sum + edge.Weight);
                }
            }
        }

     

        private void btn_Cheapest_Flights_Within_K_Stops_Click(object sender, EventArgs e)
        {
            /*
             
                There are n cities connected by m flights. Each flight starts from city u and arrives at v with a price w.

                Now given all the cities and flights, together with starting city src and the destination dst, your task is to find the cheapest price from src to dst with up to k stops. If there is no such route, output -1.

                Example 1:
                Input: 
                n = 3, edges = [[0,1,100],[1,2,100],[0,2,500]]
                src = 0, dst = 2, k = 1
                Output: 200
                Explanation: 
                The graph looks like this:
                                                        0
                                                    /       \
                                                  100       500
                                                  /           \
                                                 1------100----2
                                                        

                The cheapest price from city 0 to city 2 with at most 1 stop costs 200, as marked red in the picture.
                Example 2:
                Input: 
                n = 3, edges = [[0,1,100],[1,2,100],[0,2,500]]
                src = 0, dst = 2, k = 0
                Output: 500
                Explanation: 
                The graph looks like this:

                                                        0
                                                    /       \
                                                  100       500
                                                  /           \
                                                 1------100----2


                The cheapest price from city 0 to city 2 with at most 0 stop costs 500, as marked blue in the picture.
 

                Constraints:

                The number of nodes n will be in range [1, 100], with nodes labeled from 0 to n - 1.
                The size of flights will be in range [0, n * (n - 1) / 2].
                The format of each flight will be (src, dst, price).
                The price of each flight will be in the range [1, 10000].
                k is in the range of [0, n - 1].
                There will not be any duplicated flights or self cycles.


             */

            Dictionary<int, int> dict = new Dictionary<int, int>();
            //dict.Count


        }
    }
}
