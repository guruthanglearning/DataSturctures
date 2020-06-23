using ExtensionMethodsDemo1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.XPath;

namespace WindowsFormsApplication3
{

    public partial class Matrix : Form
    {
        struct HeapNode
        {
            public int value;
            public int row;
            public int column;
        }


        public Matrix()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
                http://www.geeksforgeeks.org/kth-smallest-element-in-a-row-wise-and-column-wise-sorted-2d-array-set-1/
                Time Complexity : O(n + kLogn) where building min heap takes O(n) where n is the dimension of the array. 
                                  k is the smallest value and finding in the heap takes log N complexity
                Space Complexity : O(n) where is n is the dimension and storing n value in the heap
            */

            int[,] input = new int[,] { { 10, 20, 30, 40 },
                                        { 15, 25, 35, 45 },
                                        { 25, 29, 37, 48 } ,
                                        { 32, 33, 39, 50 } };
            int kthValue = kthSmallest(input, 4, 7);
            MessageBox.Show(kthValue.ToString());



        }

        // A utility function to swap two HeapNode items.
        void swap(HeapNode[] harr, int i, int j)
        {
            HeapNode temp = harr[i];
            harr[i] = harr[j];
            harr[j] = temp;
        }


        void minHeapify(HeapNode[] harr, int i, int heap_size)
        {
            /* 
                10, 15, 25, 32
                i = 1;                 
                l = 2
                r = 3
                s = 1
                hs = 4
            */
            int l = (i * 2);
            int r = (i * 2) + 1;
            int smallest = i;
            if (l < heap_size && harr[l].value < harr[i].value)
                smallest = l;
            if (r < heap_size && harr[r].value < harr[smallest].value)
                smallest = r;
            if (smallest != i)
            {
                swap(harr, i, smallest);
                minHeapify(harr, smallest, heap_size);
            }
        }

        // A utility function to convert harr[] to a max heap
        void buildHeap(HeapNode[] harr, int n)
        {
            int i = (n - 1) / 2;
            while (i >= 0)
            {
                minHeapify(harr, i, n);
                i--;
            }
        }

        int kthSmallest(int[,] mat, int n, int k)
        {
            // k must be greater than 0 and smaller than n*n
            if (k <= 0 || k > n * n)
                return -1;

            // Create a min heap of elements from first row of 2D array
            HeapNode[] harr = new HeapNode[n];
            for (int i = 0; i < n; i++)
            {
                harr[i] = new HeapNode { value = mat[i, 0], row = i, column = 0 };
            }
            buildHeap(harr, n);

            HeapNode hr = new HeapNode();
            for (int i = 0; i < k; i++)
            {
                /*  
                    { 10, 20, 30, 40 }, 
                    { 15, 25, 35, 45 },
                    { 25, 29, 37, 48 } ,
                    { 32, 33, 39, 50 }
                 */

                // Get current heap root
                hr = harr[0];

                // Get next value from column of root's value. If the
                // value stored at root was last value in its column,
                // then assign INFINITE as next value
                int nextval = (hr.column < (n - 1)) ? mat[hr.row, hr.column + 1] : int.MaxValue;

                // Update heap root with next value
                harr[0] = new HeapNode { value = nextval, row = (hr.row), column = hr.column + 1 };

                // Heapify root
                minHeapify(harr, 0, n);
            }

            // Return the value at last extracted root
            return hr.value;
        }

        private void btn_Count_Negative_Numbers_in_a_Column_Wise_and_Row_Wise_Sorted_Matrix_Click(object sender, EventArgs e)
        {
            /*
            Time complexity is O(n+m) where n= row and m=column

           http://www.geeksforgeeks.org/count-negative-numbers-in-a-column-wise-row-wise-sorted-matrix/

            */

            int[,] matrix = new int[,] {
                                            { -3, -2, -1, 1 },
                                            { -4, -3, -2, -1 },
                                            { -11, 4, 3, 2 }
                                        };

            int count = 0;
            int startRow = 0; //starting row
            int column = matrix.GetLength(1) - 1; //max columns
            int row = matrix.GetLength(0) - 1; // max rows

            while (column >= 0 && startRow <= row)
            {
                if (matrix[startRow, column] < 0)
                {
                    count += (column + 1);
                    column = matrix.GetLength(1) - 1;
                    startRow++;
                }
                else
                {
                    column--;
                }
            }

            MessageBox.Show($"Total no of negative number in matrix is {count.ToString()} ");

        }

        private void btn_Find_the_largest_square_of_1_in_a_given_matrix_Click(object sender, EventArgs e)
        {
            /*
               Time Complexity is O(n*m) 
               Space Complexity is  O(n*m) 

            */

            int[,] input = new int[,] {
                                            { 0, 1, 0, 1 },
                                            { 0, 1, 1, 1 },
                                            { 1, 1, 1, 1 },
                                            { 0, 1, 1, 1,}
                                        };

            var cache = input;
            int result = 0;
            for (int row = 0; row < input.GetLength(0); row++)
            {
                for (int column = 0; column < input.GetLength(1); column++)
                {

                    if (row > 0 && column > 0 && input[row, column] > 0)
                    {
                        cache[row, column] = 1 + Math.Min(Math.Min(cache[row, column - 1], cache[row - 1, column]), cache[row - 1, column - 1]);
                    }

                    if (cache[row, column] > result)
                        result = cache[row, column];

                }
            }

            MessageBox.Show($"Largest square in the matrix is  {result.ToString()}");

        }

        private void btn_Find_No_of_times_X_occurance_for_NXN_multiplication_table_Click(object sender, EventArgs e)
        {
            /*
               Time Complexity  = O(n)
                            
                Suppose you have a multiplication table that is N by N. That is, a 2D array where the value at the 
                i-th row and j-th column is (i + 1) * (j + 1) (if 0-indexed) or i * j (if 1-indexed).
                Given integers N and X, write a function that returns the number of times X appears as a value in an
                N by N multiplication table.
                For example, given N = 6 and X = 12, you should return 4, since the multiplication table looks like 
                this:
                | 1 | 2 | 3 | 4 | 5 | 6 |
                | 2 | 4 | 6 | 8 | 10 | 12 |
                | 3 | 6 | 9 | 12 | 15 | 18 |
                | 4 | 8 | 12 | 16 | 20 | 24 |
                | 5 | 10 | 15 | 20 | 25 | 30 |            
                | 6 | 12 | 18 | 24 | 30 | 36 |
                And there are 4 12's in the table. 
             */

            int input = 6;
            int x = 12;
            int result = 0;

            if (input > 0 && x > 0)
            {

                for (int i = 1; i <= input; i++)
                {
                    if (((x / i) <= input) && ((x % i) == 0))
                    {
                        result++;
                    }
                }
            }

            MessageBox.Show($"There are {result.ToString()} occurance of {x.ToString()} for the given {input.ToString() } X {input.ToString() } matrix");

        }

        private void btn_Find_no_of_island_for_the_given_matrix_Click(object sender, EventArgs e)
        {

            /*
                https://www.ideserve.co.in/learn/number-of-clusters-of-1s
                https://www.geeksforgeeks.org/islands-in-a-graph-using-bfs/
                Given a 2D matrix of 0s and 1s, find total number of clusters formed by elements with value 1.  
                For example, in the below shown 2D matrix there are total three such clusters.

                            {1, 0, 1, 0, 1},
                            {1, 1, 0, 0, 0},
                            {0, 1, 0, 1, 1},

                Time Complexity     : O(R*C) where R is the number of rows and C is the number of columns 
                Space Complexity    : O(R*C) where R is the number of rows and C is the number of columns 
             */

            int[,] input = new int[,] {
                                            { 1, 0, 1, 0, 1},
                                            { 1, 1, 0, 0, 0},
                                            { 0, 1, 0, 1, 1}
                                       };

            bool[,] visitedDFS = new bool[input.GetLength(0), input.GetLength(1)];
            bool[,] visitedBFS = new bool[input.GetLength(0), input.GetLength(1)];


            int[] offSet = new int[] { -1, 0, 1 };

            int islandCounterDFS = 0;
            int islandCounterBFS = 0;
            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    if (input[i, j] == 1 && !visitedDFS[i, j])
                    {
                        islandCounterDFS++;
                        DoDFSLookUpUsingStack(input, i, j, visitedDFS);
                    }
                }
            }

            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    if (input[i, j] == 1 && !visitedBFS[i, j])
                    {
                        islandCounterBFS++;
                        DoBFSLookUp(input, i, j, visitedBFS);
                    }
                }
            }

            MessageBox.Show($"There are \n {islandCounterDFS} island via DFS \n {islandCounterBFS} island in BFS \n{(this.Print2DMatrix(input))}");
        }

        private void DoBFSLookUp(int[,] input, int row, int column, bool[,] visited)
        {
            Queue<Point> q = new Queue<Point>();
            q.Enqueue(new Point() { X = row, Y = column });
            int[] offSet = new int[] { -1, 0, 1 };
            visited[row, column] = true;

            while (q.Count > 0)
            {
                Point p = q.Dequeue();

                for (int i = 0; i < offSet.Length; i++)
                {
                    for (int j = 0; j < offSet.Length; j++)
                    {
                        if (i == 1 && j == 1)
                        {
                            continue;
                        }

                        if (IsNeighbourExists(input, p.X + offSet[i], p.Y + offSet[j], visited))
                        {
                            visited[p.X + offSet[i], p.Y + offSet[j]] = true;
                            q.Enqueue(new Point() { X = p.X + offSet[i], Y = p.Y + offSet[j] });
                        }
                    }
                }
            }
        }

        private void DoDFSLookUpUsingStack(int[,] input, int row, int column, bool[,] visited)
        {
            int[] offSet = new int[] { -1, 0, 1 };
            Stack<Point> s = new Stack<Point>();
            s.Push(new Point() { X = row, Y = column });
            visited[row, column] = true;

            while (s.Count > 0)
            {
                Point p = s.Pop();

                for (int i = 0; i < offSet.Length; i++)
                {
                    for (int j = 0; j < offSet.Length; j++)
                    {
                        if (i == 1 && j == 1)
                        {
                            continue;
                        }

                        if (IsNeighbourExists(input, p.X + offSet[i], p.Y + offSet[j], visited))
                        {
                            visited[p.X + offSet[i], p.Y + offSet[j]] = true;
                            s.Push(new Point() { X = p.X + offSet[i], Y = p.Y + offSet[j] });
                        }
                    }
                }
            }
        }

        private void DoDFSLookUp(int[,] input, int row, int column, bool[,] visited)
        {

            int[] offSet = new int[] { -1, 0, 1 };
            if (visited[row, column])
            {
                return;
            }

            visited[row, column] = true;

            for (int i = 0; i < offSet.Length; i++)
            {
                for (int j = 0; j < offSet.Length; j++)
                {
                    if (i == 1 && j == 1)
                    {
                        continue;
                    }

                    if (this.IsNeighbourExists(input, row + offSet[i], column + offSet[j], visited))
                    {
                        this.DoDFSLookUp(input, row + offSet[i], column + offSet[j], visited);
                    }
                }
            }
        }

        private bool IsNeighbourExists(int[,] input, int row, int column, bool[,] visited)
        {

            if (row >= 0 && row < input.GetLength(0) && column >= 0 && column < input.GetLength(1))
            {
                if (input[row, column] == 1 && !visited[row, column])
                    return true;
            }
            return false;
        }

        private string Print2DMatrix(int[,] input)
        {
            StringBuilder result = new StringBuilder();

            for (int row = 0; row < input.GetUpperBound(0) + 1; row++)
            {
                for (int column = 0; column < input.GetUpperBound(1) + 1; column++)
                {
                    result.Append($"{input[row, column]} \t");
                }
                result.Append("\n");
            }
            return result.ToString();
        }

        private void btn_Find_Exit_for_Maze_Click(object sender, EventArgs e)
        {
            int[,] maze = new int[,]
            {
                {1, 1, 1, 1 },
                {1, 1, 0, 1 },
                {1, 0, 1, 1 },
                {1, 1, 0, 1 },
                {1, 0, 1, 1 }
            };

            bool[,] visited = new bool[maze.GetLength(0), maze.GetLength(1)];

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    result.Append($"{maze[i, j]}\t");
                }
                result.AppendLine();
            }

            MessageBox.Show($"Path for the maze {(this.DFSMaze(maze, 0, 3, visited) ? "" : " does not ")} exists");
        }

        private bool DFSMaze(int[,] input, int r, int c, bool[,] visited)
        {

            if (!this.IsMazeWayExists(input, r, c, visited))
            {
                return false;
            }


            Stack<Point> s = new Stack<Point>();
            s.Push(new Point() { X = r, Y = c });

            visited[r, c] = true;

            int[] offset = new int[] { -1, 0, 1 };

            while (s.Count > 0)
            {
                Point p = s.Pop();
                visited[p.X, p.Y] = true;
                if (IsMazeFoundExists(input, p.X, p.Y))
                {
                    return true;
                }

                for (int i = 0; i < offset.Length; i++)
                {
                    for (int j = 0; j < offset.Length; j++)
                    {
                        if (i == 1 && j == 1)
                        {
                            continue;
                        }

                        if (IsMazeWayExists(input, p.X + offset[i], p.Y + offset[j], visited))
                        {
                            visited[p.X + offset[i], p.Y + offset[j]] = true;
                            s.Push(new Point() { X = p.X + offset[i], Y = p.Y + offset[j] });
                            //    returnValue = DFSMaze(input, r + offset[i], c + offset[j], visited);
                            //    if (returnValue)
                            //        return returnValue;
                        }
                    }
                }
            }

            return false;
        }

        private bool IsMazeFoundExists(int[,] input, int r, int c)
        {
            if ((r == 0 || r == input.GetLength(0) - 1 || c == 0 || c == input.GetLength(0) - 1) && input[r, c] == 1)
            {
                return true;
            }
            return false;
        }

        private bool IsMazeWayExists(int[,] input, int r, int c, bool[,] visited)
        {
            if (r >= 0 && r < input.GetLength(0) && c >= 0 && c < input.GetLength(1) && input[r, c] == 1 && !visited[r, c])
            {
                return true;
            }
            return false;
        }

        private void btn_Navigate_from_North_West_to_South_East_of_the_building_Click(object sender, EventArgs e)
        {

            /*
             
            Building is a grid of n*m rooms each room has a door on each of the four walls a door is either 
            open or closed given a configuration of each door being open or close, starting from north-west 
            corner of the building, figure out if there is a way to reach the south-east 

                Time Complexity : O(N*M)
                Space Complexity: O(log N)  
                
            Refer : Additional test data in WindowsFormsApplication3\Data\PathFromNWToSEOf_A_Building.txt
             */


            Building building = new Building(4, 4);
            building.InsertRoom(0, 0, new Room() { Name = "00", SouthDoor = true, EastDoor = true });
            building.InsertRoom(0, 1, new Room() { Name = "01", WestDoor = true, SouthDoor = true, EastDoor = true });
            building.InsertRoom(0, 2, new Room() { Name = "02", WestDoor = true, SouthDoor = true, EastDoor = true });
            building.InsertRoom(0, 3, new Room() { Name = "03", WestDoor = true, SouthDoor = true });

            building.InsertRoom(1, 0, new Room() { Name = "10", NorthDoor = true, SouthDoor = true, EastDoor = true });
            building.InsertRoom(1, 1, new Room() { Name = "11", NorthDoor = true, SouthDoor = true, WestDoor = true, EastDoor = true });
            building.InsertRoom(1, 2, new Room() { Name = "12", NorthDoor = true, SouthDoor = true, WestDoor = true, EastDoor = true });
            building.InsertRoom(1, 3, new Room() { Name = "13", NorthDoor = true, SouthDoor = true, WestDoor = true });

            building.InsertRoom(2, 0, new Room() { Name = "20", NorthDoor = true, SouthDoor = true, EastDoor = true });
            building.InsertRoom(2, 1, new Room() { Name = "21", NorthDoor = true, SouthDoor = true, WestDoor = true, EastDoor = true });
            building.InsertRoom(2, 2, new Room() { Name = "22", NorthDoor = true, SouthDoor = true, WestDoor = true, EastDoor = true });
            building.InsertRoom(2, 3, new Room() { Name = "23", NorthDoor = true, WestDoor = true, SouthDoor = true });

            building.InsertRoom(3, 0, new Room() { Name = "30", NorthDoor = true, EastDoor = true });
            building.InsertRoom(3, 1, new Room() { Name = "31", NorthDoor = true, WestDoor = true, EastDoor = true });
            building.InsertRoom(3, 2, new Room() { Name = "32", NorthDoor = true, WestDoor = true, EastDoor = true });
            building.InsertRoom(3, 3, new Room() { Name = "33", NorthDoor = true, WestDoor = true });

            Console.WriteLine($"Path {(building.IsPathExists() ? "" : "does not") } exists from North West to South East of the building");


        }

        public class Room
        {
            public string Name;
            public bool NorthDoor;
            public bool SouthDoor;
            public bool WestDoor;
            public bool EastDoor;
        }

        public class Building
        {
            Room[,] rooms;

            public Building(int row, int column)
            {
                rooms = new Room[row, column];
            }

            /// <summary>
            /// Adding room into the building
            /// </summary>
            /// <param name="row"></param>
            /// <param name="column"></param>
            /// <param name="room"></param>
            public void InsertRoom(int row, int column, Room room)
            {
                if (row >= 0 && row < rooms.GetLength(0) && column >= 0 && column < rooms.GetLength(1))
                {
                    rooms[row, column] = room;
                }
            }


            /// <summary>
            /// This Method checks for the path existenance from NorthWest to South East of the building 
            /// </summary>
            /// <returns></returns>
            public bool IsPathExists()
            {

                if (rooms == null && rooms[0, 0] == null)
                {
                    throw new Exception("North West room is null in the building hence can't able to traverse");
                }

                // Traversing through Breadth First Algorithm. I have used Point class here to capture Row and Colum 
                // of the building rooms. I would have also used custom class by having row and column as an property but its going to be similar
                // to point class hence used Point class here.
                Queue<Point> que = new Queue<Point>();
                que.Enqueue(new Point() { X = 0, Y = 0 });

                int r = 0; int c = 0;

                int rLength = rooms.GetLength(0); //Gets row length of the multidimensional array
                int cLength = rooms.GetLength(1); //Gets column length of the multidimensional array

                bool[,] visited = new bool[rLength, cLength];
                Room room;
                Point rowColum;
                while (que.Count > 0)
                {
                    rowColum = que.Dequeue();
                    r = rowColum.X; c = rowColum.Y;
                    room = rooms[r, c];

                    if (!visited[r, c])
                    {
                        if ((r == 0 && room.NorthDoor) ||
                                (r == rLength - 1 && room.SouthDoor) ||
                                (c == 0 && room.WestDoor) ||
                                (c == cLength - 1 && room.EastDoor)
                            ) // I have code like If any door is opened that leads outside of the building then no path exists from NW to SE
                        {
                            return false;
                        }
                        else if (r == rLength - 1 && c == cLength - 1)
                        {
                            return true; //This determines there is path from NW to SE of the building
                        }
                        visited[r, c] = true;
                        this.FindPathToNextRoom(r, c, room, que, visited);

                    }
                }
                return false;
            }


            /// <summary>
            /// Traverse and finds the path to the next room
            /// </summary>
            /// <param name="r"></param>
            /// <param name="c"></param>
            /// <param name="room"></param>
            /// <param name="que"></param>
            private void FindPathToNextRoom(int r, int c, Room room, Queue<Point> que, bool[,] visited)
            {

                if (room == null || rooms == null || que == null)
                {
                    return;
                }

                int rLength = rooms.GetLength(0);
                int cLength = rooms.GetLength(1);

                if (room.NorthDoor && r - 1 >= 0 && r - 1 < rLength && rooms[r - 1, c].SouthDoor && !visited[r - 1, c])
                {
                    que.Enqueue(new Point() { X = r - 1, Y = c });
                }

                if (room.SouthDoor && r + 1 >= 0 && r + 1 < rLength && rooms[r + 1, c].NorthDoor && !visited[r + 1, c])
                {
                    que.Enqueue(new Point() { X = r + 1, Y = c });
                }

                if (room.WestDoor && c - 1 >= 0 && c - 1 < cLength && rooms[r, c - 1].EastDoor && !visited[r, c - 1])
                {
                    que.Enqueue(new Point() { X = r, Y = c - 1 });
                }

                if (room.EastDoor && c + 1 >= 0 && c + 1 < cLength && rooms[r, c + 1].WestDoor && !visited[r, c + 1])
                {
                    que.Enqueue(new Point() { X = r, Y = c + 1 });
                }
            }
        }

        private void Matrix_Load(object sender, EventArgs e)
        {

        }

        private void btn_2D_Array_DS_Click(object sender, EventArgs e)
        {
            /*   
                https://www.hackerrank.com/challenges/2d-array/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=arrays
             
                Time Complexity : O(N*M) where N and M are the length of the jagged arrays
                Space Complexity: Constant time
           */

            StringBuilder result = new StringBuilder();
            List<int[][]> inputs = new List<int[][]>();
            /*
            int[][] input = new int[6][]; // 19
            input[0] = new int[] { 1, 1, 1, 0, 0, 0 };
            input[1] = new int[] { 0, 1, 0, 0, 0, 0 };
            input[2] = new int[] { 1,1, 1, 0, 0, 0 };
            input[3] = new int[] { 0, 0, 2, 4, 4, 0 };
            input[4] = new int[] { 0, 0, 0, 2, 0, 0 };
            input[5] = new int[] { 0, 0, 1, 2, 4, 0 };
            inputs.Add(input);

            int[][] input1 = new int[6][]; // 13
            input1[0] = new int[] { 1, 1, 1, 0, 0, 0 };
            input1[1] = new int[] { 0, 1, 0, 0, 0, 0 };
            input1[2] = new int[] { 1, 1, 1, 0, 0, 0 };
            input1[3] = new int[] { 0, 9, 2, -4, -4, 0 };
            input1[4] = new int[] { 0, 0, 0, -2, 0, 0 };
            input1[5] = new int[] { 0, 0, -1, -2, -4, 0 };
            inputs.Add(input1);

            int[][] input2 = new int[6][]; //28
            input2[0] = new int[] { -9, -9, -9, 1, 1, 1 };
            input2[1] = new int[] { 0, -9, 0, 4, 3, 2 };
            input2[2] = new int[] { -9, -9, -9, 1, 2, 3 };
            input2[3] = new int[] { 0, 0, 8, 6, 6, 0 };
            input2[4] = new int[] { 0, 0, 0, -2, 0, 0 };
            input2[5] = new int[] { 0, 0, 1, 2, 4, 0 };
            inputs.Add(input2);
            */

            int[][] input3 = new int[6][]; //-19
            input3[0] = new int[] { 0, -4, -6, 0, -7, -6 };
            input3[1] = new int[] { -1, -2, -6, -8, -3, -1 };
            input3[2] = new int[] { -8, -4, -2, -8, -8, -6 };
            input3[3] = new int[] { -3, -1, -2, -5, -7, -4 };
            input3[4] = new int[] { -3, -5, -3, -6, -6, -6 };
            input3[5] = new int[] { -3, -6, 0, -8, -6, -7 };
            inputs.Add(input3);


            int[][] input4 = new int[6][]; //0
            input4[0] = new int[] { -1, 1, -1, 0, 0, 0 };
            input4[1] = new int[] { 0, -1, 0, 0, 0, 0 };
            input4[2] = new int[] { -1, -1, -1, 0, 0, 0 };
            input4[3] = new int[] { 0, -9, 2, -4, -4, 0 };
            input4[4] = new int[] { -7, 0, 0, -2, 0, 0 };
            input4[5] = new int[] { 0, 0, -1, -2, -4, 0 };
            inputs.Add(input4);

            foreach (int[][] inp in inputs)
            {
                result.AppendLine($"Max sum of the given matrix \n {(this.DisplayJaggedArrays(inp))} is {(this.HourglassSum(inp))} \n\n");
            }

            MessageBox.Show(result.ToString());

        }

        private string DisplayJaggedArrays(int[][] input)
        {

            StringBuilder result = new StringBuilder();

            foreach (int[] data in input)
            {
                foreach (int d in data)
                {
                    result.Append($"{d} \t");
                }
                result.AppendLine();
            }

            return result.ToString();
        }

        private int HourglassSum(int[][] arr)
        {

            if (arr == null)
            {
                return 0;
            }

            int max = int.MinValue;
            int sum = 0;
            for (int r = 0; r < arr.Length - 2; r++)
            {
                for (int c = 0; c < arr[r].Length - 2; c++)
                {
                    sum = SumMatrix(arr, r, c);
                    max = Math.Max(max, sum);

                }
            }

            return max;
        }

        private int SumMatrix(int[][] input, int r, int c)
        {
            if (input == null)
            {
                return 0;
            }

            int sum = 0;
            for (int i = r; i <= r + 2; i++)
            {
                if (r + 1 == i)
                {
                    continue;
                }

                for (int j = c; j <= c + 2; j++)
                {
                    sum += input[i][j];
                }
            }

            sum += input[r + 1][c + 1];
            return sum;
        }

        private void btn_btn_Find_Pattern_Exists_in_Given_Character_Matrix_Click(object sender, EventArgs e)
        {
            char[,] grid = new char[,]
                     {
                         {'A', 'B', 'C', 'D', 'E', 'F', 'G'},
                         {'M', 'I', 'Z', 'Z', 'A', 'B', 'C'},
                         {'C', 'A', 'B', 'C', 'D', 'Z', 'Z'},
                         {'A', 'R', 'O', 'F', 'T', 'A', 'A'},
                         {'B', 'S', 'G', 'B', 'A', 'T', 'G'}
                    };
            MessageBox.Show($"Pattern {(PatternExists(grid, "MICROSOFT") ? "Exists" : "do not exists")}");


        }

        public bool PatternExists(char[,] input, string pattern)
        {
            if (input == null || input.Length == 0 || string.IsNullOrEmpty(pattern))
            {
                return false;
            }

            int[] offset = new int[] { -1, 0, 1 };
            Queue<Point> q = new Queue<Point>();
            q.Enqueue(new Point() { X = 0, Y = 0 });

            int patIndex = 0;

            Point temp;

            int row = 0; int col = 0;
            int rowLength = input.GetLength(0);
            int colLength = input.GetLength(1);

            while (q.Count > 0)
            {
                temp = q.Dequeue();
                row = temp.X;
                col = temp.Y;

                for (int r = 0; r < offset.Length; r++)
                {
                    for (int c = 0; c < offset.Length; c++)
                    {
                        if (
                            (row + offset[r] >= 0 && row + offset[r] < rowLength) &&
                             (col + offset[c] >= 0 && col + offset[c] < colLength) &&
                             input[row + offset[r], col + offset[c]] == pattern[patIndex]
                           )
                        {
                            q.Enqueue(new Point() { X = row + offset[r], Y = col + offset[c] });
                            patIndex++;
                            if (pattern.Length == patIndex)
                            {
                                return true;
                            }
                        }

                    }

                }
            }
            return false;
        }

        private void btn_No_of_island_Horizontal_Vertical_Click(object sender, EventArgs e)
        {
            StringBuilder result = new StringBuilder();
            List<char[][]> inputs = new List<char[][]>();
            inputs.Add(new char[][]
                {
                        new char[]{'1','1','1','1','1','0','1','1','1','1','1','1','1','1','1','0','1','0','1','1'},
                        new char[]{'0','1','1','1','1','1','1','1','1','1','1','1','1','0','1','1','1','1','1','0'},
                        new char[]{'1','0','1','1','1','0','0','1','1','0','1','1','1','1','1','1','1','1','1','1'},
                        new char[]{'1','1','1','1','0','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1'},
                        new char[]{'1','0','0','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1'},
                        new char[]{'1','0','1','1','1','1','1','1','0','1','1','1','0','1','1','1','0','1','1','1'},
                        new char[]{'0','1','1','1','1','1','1','1','1','1','1','1','0','1','1','0','1','1','1','1'},
                        new char[]{'1','1','1','1','1','1','1','1','1','1','1','1','0','1','1','1','1','0','1','1'},
                        new char[]{'1','1','1','1','1','1','1','1','1','1','0','1','1','1','1','1','1','1','1','1'},
                        new char[]{'1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1'},
                        new char[]{'0','1','1','1','1','1','1','1','0','1','1','1','1','1','1','1','1','1','1','1'},
                        new char[]{'1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1'},
                        new char[]{'1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1'},
                        new char[]{'1','1','1','1','1','0','1','1','1','1','1','1','1','0','1','1','1','1','1','1'},
                        new char[]{'1','0','1','1','1','1','1','0','1','1','1','0','1','1','1','1','0','1','1','1'},
                        new char[]{'1','1','1','1','1','1','1','1','1','1','1','1','0','1','1','1','1','1','1','0'},
                        new char[]{'1','1','1','1','1','1','1','1','1','1','1','1','1','0','1','1','1','1','0','0'},
                        new char[]{'1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1'},
                        new char[]{'1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1'},
                        new char[]{'1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1'}
                    }
                );

            // inputs.Add(new char[][]
            // {
            //     new char[]{'1','1','1','1','0'},
            //     new char[]{'1','1','0','1','0'},
            //     new char[]{'1','1','0','0','0'},
            //     new char[]{'0','0','0','0','0'}
            // });

            // inputs.Add(new char[][]
            // {
            //     new char[]{'1','1','0','0','0'},
            //     new char[]{'1','1','0','0','0'},
            //     new char[]{'0','0','1','0','0'},
            //     new char[]{'0','0','0','1','1'}
            //});

            foreach (char[][] input in inputs)
            {
                result.AppendLine($"For the given land {Environment.NewLine} {this.PrintCharArray(input)} {Environment.NewLine} there are {this.GetNoOfIslands(input)} islands ");
            }


            MessageBox.Show(result.ToString());



        }

        private string PrintCharArray(char[][] input)
        {
            StringBuilder result = new StringBuilder();

            foreach (var data in input)
            {
                foreach (char c in data)
                {
                    result.Append($" {c}");
                }
                result.AppendLine();
            }

            return result.ToString();

        }


        public class RowCol
        {
            public int Row;
            public int Col;
        }


        private int GetNoOfIslands(char[][] gridInput)
        {
            if (gridInput == null || gridInput.Length == 0)
                return 0;

            int island = 0;

            int rowLen = gridInput.Length;
            int colLen = 0;

            Queue<RowCol> q = new Queue<RowCol>();
            RowCol temp;

            for (int i = 0; i < rowLen; i++)
            {
                colLen = gridInput[i].Length;
                for (int j = 0; j < colLen; j++)
                {
                    if (gridInput[i][j] == '1')
                    {
                        island++;

                        q.Enqueue(new RowCol() { Row = i, Col = j });

                        while (q.Count > 0)
                        {
                            temp = q.Dequeue();
                            gridInput[temp.Row][temp.Col] = '0';

                            if (this.ConvertLandToWater(temp.Row - 1, temp.Col, gridInput))
                            {
                                q.Enqueue(new RowCol() { Row = temp.Row - 1, Col = temp.Col });
                            }

                            if (this.ConvertLandToWater(temp.Row + 1, temp.Col, gridInput))
                            {
                                q.Enqueue(new RowCol() { Row = temp.Row + 1, Col = temp.Col });
                            }

                            if (this.ConvertLandToWater(temp.Row, temp.Col - 1, gridInput))
                            {
                                q.Enqueue(new RowCol() { Row = temp.Row, Col = temp.Col - 1 });
                            }

                            if (this.ConvertLandToWater(temp.Row, temp.Col + 1, gridInput))
                            {
                                q.Enqueue(new RowCol() { Row = temp.Row, Col = temp.Col + 1 });
                            }

                        }

                    }

                }
            }

            return island;

        }

        private bool ConvertLandToWater(int r, int c, char[][] input)
        {
            bool result = false;
            if (r >= 0 && r < input.Length && c >= 0 && c < input[r].Length && input[r][c] == '1')
            {
                input[r][c] = '0';
                result = true;
            }
            return result;

        }

        private void btn_MinPathSum_Click(object sender, EventArgs e)
        {

            /*
             
            Given a m x n grid filled with non-negative numbers, find a path from top left to bottom right which minimizes the sum of all numbers along its path.

            Note: You can only move either down or right at any point in time.

            Example:

            Input:
            [
              [1,3,1],
              [1,5,1],
              [4,2,1]
            ]
            Output: 7
            Explanation: Because the path 1→3→1→1→1 minimizes the sum.

            Time Complexity     : O(M*N) where M is row length and N is column length
            Space Complexity    : O(1)

            */

            StringBuilder result = new StringBuilder();

            List<int[][]> inputs = new List<int[][]>();
            inputs.Add(new int[][] {
                                        new int[] { 1, 3, 1 },
                                        new int[] { 1, 5, 1 },
                                        new int[] { 4, 2, 1 },

                                   }
                       );

            inputs.Add(new int[][] {
                                        new int[] { 9,1,4,8}
                                   }
                       );



            foreach (var input in inputs)
            {
                result.AppendLine($"For the given input {Environment.NewLine}{this.PrintJaggedArray(input)}the min path sum is {this.MinPathSum(input)}");
                result.AppendLine();
            }


            MessageBox.Show(result.ToString());

        }


        public int MinPathSum(int[][] grid)
        {
            int result = 0;
            if (grid == null || grid.Length == 0)
            {
                return 0;
            }

            int c = 1;
            int r = 1;
            int rl = grid.Length;
            int cl = grid[0].Length;

            for (c = 1; c < cl; c++)
            {
                grid[0][c] += grid[0][c - 1];
            }


            for (r = 1; r < rl; r++)
            {
                grid[r][0] += grid[r - 1][0];
            }


            for (r = 1; r < rl; r++)
            {
                for (c = 1; c < cl; c++)
                {
                    grid[r][c] += Math.Min(grid[r][c - 1], grid[r - 1][c]);
                }
            }

            return grid[rl - 1][cl - 1];
        }

        private string PrintJaggedArray(int[][] input)
        {
            StringBuilder result = new StringBuilder();

            for (int r = 0; r < input.Length; r++)
            {
                for (int c = 0; c < input[r].Length; c++)
                {
                    result.Append($"{input[r][c]} \t");
                }
                result.AppendLine();
            }

            return result.ToString();
        }

        private void btn_Flood_Fill_Click(object sender, EventArgs e)
        {

            /*
            
            An image is represented by a 2-D array of integers, each integer representing the pixel value of the image (from 0 to 65535).

            Given a coordinate (sr, sc) representing the starting pixel (row and column) of the flood fill, and a pixel value newColor, "flood fill" the image.

            To perform a "flood fill", consider the starting pixel, plus any pixels connected 4-directionally to the starting pixel of the same color as the starting pixel, plus any pixels connected 4-directionally to those pixels (also with the same color as the starting pixel), and so on. Replace the color of all of the aforementioned pixels with the newColor.

            At the end, return the modified image.

            Example 1:
            Input: 
            image = [[1,1,1],[1,1,0],[1,0,1]]
            sr = 1, sc = 1, newColor = 2
            Output: [[2,2,2],[2,2,0],[2,0,1]]
            Explanation: 
            From the center of the image (with position (sr, sc) = (1, 1)), all pixels connected 
            by a path of the same color as the starting pixel are colored with the new color.
            Note the bottom corner is not colored 2, because it is not 4-directionally connected
            to the starting pixel.

            */


            StringBuilder result = new StringBuilder();
            List<FloorFill> inputs = new List<FloorFill>();
            inputs.Add(new FloorFill()
            {
                Image = new int[][] { new int[] {1, 1 ,1 },
                                                               new int[] {1, 1, 0 },
                                                               new int[] {1, 0, 1 }
                                                            },
                Row = 1,
                Column = 1,
                NewColor = 2
            });


            inputs.Add(new FloorFill()
            {
                Image = new int[][] { new int[] {0, 0 ,0 },
                                      new int[] {0, 1, 1 }
                                     },
                Row = 1,
                Column = 1,
                NewColor = 1
            });

            string before = string.Empty;
            foreach (var input in inputs)
            {
                before = this.PrintFloorFillImage(input.Image);
                this.FloodFill(input.Image, input.Row, input.Column, input.NewColor);
                result.AppendLine($"Floor fill color for the given image {Environment.NewLine}{before}is{Environment.NewLine}{this.PrintFloorFillImage(input.Image)}");
            }

            MessageBox.Show(result.ToString());
        }


        public string PrintFloorFillImage(int[][] image)
        {
            StringBuilder result = new StringBuilder();

            for(int i = 0; i < image.Length; i++)
            {
                for(int j = 0; j < image[i].Length; j++)
                {
                    result.Append($"{image[i][j]} \t");
                }
                result.Append($"{Environment.NewLine}");
            }

            return result.ToString();


        }

        public class FloorFill
        {
            public int[][] Image;
            public int Row;
            public int Column;
            public int NewColor;
        }

        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            if (sr >= 0 && sr < image.Length && sc >= 0 && sc < image[0].Length && image[sr][sc] != newColor)
            {
                this.Fill(image, sr, sc, newColor, image[sr][sc]);
            }
            return image;

        }

        public void Fill(int[][] image, int sr, int sc, int newColor, int startingPixel)
        {
            if (image == null || image.Length == 0 || sr < 0 || sr >= image.Length || sc < 0 || sc >= image[0].Length || image[sr][sc] != startingPixel)
                return;

            image[sr][sc] = newColor;

            this.Fill(image, sr - 1, sc, newColor, startingPixel);
            this.Fill(image, sr + 1, sc, newColor, startingPixel);
            this.Fill(image, sr, sc -1, newColor, startingPixel);
            this.Fill(image, sr, sc + 1, newColor, startingPixel);

        }


        private void btn_Check_If_It_Is_a_Straight_Line_Click(object sender, EventArgs e)
        {
            /*
                You are given an array coordinates, coordinates[i] = [x, y], where [x, y] represents the coordinate of a point. Check if these points make a straight line in the XY plane. 

                Input: coordinates = [[1,2],[2,3],[3,4],[4,5],[5,6],[6,7]]
                Output: true

                Input: coordinates = [[1,1],[2,2],[3,4],[4,5],[5,6],[7,7]]
                Output: false

                Time Complexity     : O(M*N)
                Space Complexity    : O(1)
             */


            StringBuilder result = new StringBuilder();
            List<int[][]> inputs = new List<int[][]>();
            //inputs.Add(new int[][] {
            //                                                    new int[] { 1,2 },
            //                                                    new int[] { 2,3 },
            //                                                    new int[] { 3,4 },
            //                                                    new int[] { 4,5 },
            //                                                    new int[] { 5,6 },
            //                                                    new int[] { 6,7 },
            //                                                    });

            //inputs.Add(new int[][] {
            //                                                    new int[] { 1,1 },
            //                                                    new int[] { 2,2 },
            //                                                    new int[] { 3,4 },
            //                                                    new int[] { 4,5 },
            //                                                    new int[] { 5,6 },
            //                                                    new int[] { 7,7 }
            //                                                    });

            //inputs.Add(new int[][] {
            //                                                    new int[] { 0,0 },
            //                                                    new int[] { 0,1 },
            //                                                    new int[] { 0,-1 }
            //                                                    });  //true

            inputs.Add(new int[][] {
                                                                new int[] { 1,1 },
                                                                new int[] { 2,2 },
                                                                new int[] { 2,0 }
                                                                });  //true

            foreach (var input in inputs)
            {
                result.AppendLine($"Straight line { (this.CheckStraightLine(input) ? "" : " not ") } exists for the given coordinates{Environment.NewLine}{this.PrintJaggedArrayWithCordinates(input)}");

            }

            MessageBox.Show(result.ToString());
        }

        public bool CheckStraightLine(int[][] coordinates)
        {
            if (coordinates == null || coordinates.Length == 0)
                return false;

            if (coordinates.Length == 1)
                return true;
            else
            {

                //y2-y1
                //-----
                //x2-x1

                int x1 = 0;
                int y1 = 0;
                int x2 = 0;
                int y2 = 0;


                y1 = coordinates[1][1] - coordinates[0][1];
                x1 = coordinates[1][0] - coordinates[0][0];

                for (int i = 1; i < coordinates.Length - 1; i++)
                {
                    x2 = coordinates[i + 1][0] - coordinates[i][0];
                    y2 = coordinates[i + 1][1] - coordinates[i][1];

                    if (x1 * y2 != y1 * x2)
                        return false;

                }
            }
            return true;
        }


        public string PrintJaggedArrayWithCordinates(int[][] input)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {                
              result.AppendLine($"({input[i][0]} , {input[i][0]}),");
            }

            return result.ToString();
        }


        public class Common
        {
            public int[][] Input;
            public int N;
        }

        private void btn_Find_the_Town_Judge_Click(object sender, EventArgs e)
        {

            /*
                In a town, there are N people labelled from 1 to N.  There is a rumor that one of these people is secretly the town judge.

                If the town judge exists, then:

                The town judge trusts nobody.
                Everybody (except for the town judge) trusts the town judge.
                There is exactly one person that satisfies properties 1 and 2.
                You are given trust, an array of pairs trust[i] = [a, b] representing that the person labelled a trusts the person labelled b.

                If the town judge exists and can be identified, return the label of the town judge.  Otherwise, return -1.
 

                Example 1:

                Input: N = 2, trust = [[1,2]]
                Output: 2
                Example 2:

                Input: N = 3, trust = [[1,3],[2,3]]
                Output: 3
                Example 3:

                Input: N = 3, trust = [[1,3],[2,3],[3,1]]
                Output: -1
                Example 4:

                Input: N = 3, trust = [[1,2],[2,3]]
                Output: -1
                Example 5:

                Input: N = 4, trust = [[1,3],[1,4],[2,3],[2,4],[4,3]]
                Output: 3
            */


            StringBuilder result = new StringBuilder();
            List<Common> inputs = new List<Common>();
            inputs.Add(new Common() { Input = new int[][] { new int[] { 1, 2 } }, N = 2 });

            inputs.Add(new Common()
            {
                Input = new int[][] {
                                     new int[] {1, 3 },
                                     new int[] {2, 3 }
                                    },
                N = 3
            });

            inputs.Add(new Common()
            {
                Input = new int[][] {
                                     new int[] { 1, 3 },
                                     new int[] { 2, 3 },
                                     new int[] { 3, 1 }
                                    },
                N = 3
            });

            inputs.Add(new Common()
            {
                Input = new int[][] {
                                     new int[] { 1, 2 },
                                     new int[] { 2, 3 }
                                    },
                N = 3
            });

            inputs.Add(new Common()
            {
                Input = new int[][] {
                                     new int[] { 1, 3 },
                                     new int[] { 1, 4 },
                                     new int[] { 2, 3 },
                                     new int[] { 2, 4 },
                                     new int[] { 4, 1 }
                                    },
                N = 4
            });

            inputs.Add(new Common()
            {
                Input = new int[][] {
                                    new int[] {1,8},
                                    new int[] {1,3},
                                    new int[] {2,8},
                                    new int[] {2,3},
                                    new int[] {4,8},
                                    new int[] {4,3},
                                    new int[] {5,8},
                                    new int[] {5,3},
                                    new int[] {6,8},
                                    new int[] {6,3},
                                    new int[] {7,8},
                                    new int[] {7,3},
                                    new int[] {9,8},
                                    new int[] {9,3},
                                    new int[] {11,8},
                                    new int[] {11,3}
                                },
                N = 11
            });


            foreach (var input in inputs)
            {
                result.AppendLine($"The Judge is { this.FindJudge(input.N, input.Input) } for the given inputs{Environment.NewLine}{this.PrintJaggedArrayForJudeges(input.Input)}");

            }

            MessageBox.Show(result.ToString());
        }

        public int FindJudge(int N, int[][] trust)
        {
            if (trust == null || trust.Length == 0)
                return 0;

            int result = 0;
            HashSet<int> jud = new HashSet<int>();
            HashSet<int> per = new HashSet<int>();

            for (int i = 0; i < trust.Length; i++)
            {
                if (!per.Contains(trust[i][1]))
                {
                    if (jud.Contains(trust[i][0]))
                    {
                        jud.Remove(trust[i][0]);
                    }
                    else
                    {
                        jud.Add(trust[i][1]);
                    }
                    per.Add(trust[i][0]);
                }
                else
                {
                    jud.Remove(trust[i][0]);
                    per.Add(trust[i][0]);
                }
            }

            for (int i = 1; i <= N; i++)
            {
                if (!(jud.Contains(i) || per.Contains(i)))
                {
                    return -1;
                }
            }


            if (jud.Count > 0)
            {
                result = jud.First();
            }

            return result;
        }


        public string PrintJaggedArrayForJudeges(int[][] input)
        {
            StringBuilder result = new StringBuilder();
        
            for (int i = 0; i < input.Length; i++)
            {
                result.AppendLine($"({input[i][0]},{input[i][1]}),");
            }

          
            return result.ToString();
        }

        public string PrintJaggedArrayForJudegesChar(char[][] input)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                result.AppendLine("");
                for (int j = 0; j < input[0].Length; j++)
                    result.Append($"{input[i][j]}  ");
            }


            return result.ToString();
        }


        private void btn_Count_Square_Submatrices_with_All_Ones_Click(object sender, EventArgs e)
        {
         
            /*
   
                Given a m * n matrix of ones and zeros, return how many square submatrices have all ones.
                    Example 1:

                    Input: matrix =
                    [
                      [0,1,1,1],
                      [1,1,1,1],
                      [0,1,1,1]
                    ]
                    Output: 15
                    Explanation: 
                    There are 10 squares of side 1.
                    There are 4 squares of side 2.
                    There is  1 square of side 3.
                    Total number of squares = 10 + 4 + 1 = 15.
                    Example 2:

                    Input: matrix = 
                    [
                      [1,0,1],
                      [1,1,0],
                      [1,1,0]
                    ]
                    Output: 7
                    Explanation: 
                    There are 6 squares of side 1.  
                    There is 1 square of side 2. 
                    Total number of squares = 6 + 1 = 7.
                    
                    Time Complexity     : O(RC)
                    Space Complexity    : O(RC)

            */


            StringBuilder result = new StringBuilder();
            List<int[][]> inputs = new List<int[][]>();
            inputs.Add(new int[][] {                    
                                        new int[] { 0, 1, 1, 1 },
                                        new int[] { 1, 1, 1, 1 },
                                        new int[] { 0, 1, 1, 1 }
                                   });

            inputs.Add(new int[][] {
                                        new int[] { 1, 0, 1 },
                                        new int[] { 1, 1, 0 },
                                        new int[] { 1, 1, 0 }
                                   });


            foreach (var input in inputs)
            {
                result.AppendLine($"Total Square is { this.CountSquares(input) } for the given inputs{Environment.NewLine}{this.PrintJaggedArrayForJudeges(input)}");

            }

            MessageBox.Show(result.ToString());
        }

        public int CountSquares(int[][] matrix)
        {
            if (matrix == null)
                return 0;

            int count = 0;
            int rl = matrix.Length;
            int cl = matrix[0].Length;
            int[][] dict = new int[rl][] ;


            for (int i = 0; i < cl; i++)
            {
                if (dict[0] == null)
                    dict[0] = new int[cl];

                dict[0][i] = matrix[0][i];
                count += matrix[0][i] == 1 ? 1 : 0;
            }


            for (int i = 1; i < rl; i++)
            {
                if (dict[i] == null)
                    dict[i] = new int[cl];

                dict[i][0] = matrix[i][0];
                count += matrix[i][0] == 1 ? 1 : 0;
            }


            for (int r = 1; r < rl; r++)
            {
                for (int c = 1; c < cl; c++)
                {
                    if (matrix[r][c] == 1)
                    {
                        dict[r][c] = Math.Min(dict[r - 1][c - 1], Math.Min(dict[r][c - 1], dict[r - 1][c])) + 1;
                        count += dict[r][c];
                    }
                }
            }


            return count;
        }

        private void btn_Interval_List_Intersections_Click(object sender, EventArgs e)
        {
            /*

                    Given two lists of closed intervals, each list of intervals is pairwise disjoint and in sorted order.

                    Return the intersection of these two interval lists.

                    (Formally, a closed interval [a, b] (with a <= b) denotes the set of real numbers x with a <= x <= b.  The intersection of two closed intervals is a set of real numbers that is either empty, or can be represented as a closed interval.  For example, the intersection of [1, 3] and [2, 4] is [2, 3].)

                    Example 1:

                    Input: A = [[0,2],[5,10],[13,23],[24,25]], B = [[1,5],[8,12],[15,24],[25,26]]
                    Output: [[1,2],[5,5],[8,10],[15,23],[24,24],[25,25]]
                    Reminder: The inputs and the desired output are lists of Interval objects, and not arrays or lists.

                    Time Complexity     : O(N*M)
                    Space Complexity    : O(N*M)

          */
        
            StringBuilder result = new StringBuilder();
            List<IntervalIntersection> inputs = new List<IntervalIntersection>();
            inputs.Add(new IntervalIntersection() { A = new int[][] {
                                        new int[] { 0, 2},
                                        new int[] { 5, 10 },
                                        new int[] { 13, 23},                                    
                                        new int[] { 24, 25} },
                                        B= new int[][]
                                        {
                                        new int[] { 1, 5},
                                        new int[] { 8, 12 },
                                        new int[] { 15, 24},
                                        new int[] { 25, 26}
                                        }
                                   });

            inputs.Add(new IntervalIntersection()
            {
                A = new int[][] {
                                        new int[] { 1,3} 
                                },
                B = new int[][]
                                      {
                                        new int[] { 5, 9}
                                      }
            });

            foreach (var input in inputs)
            {
                result.AppendLine($"Interval Intersection is {Environment.NewLine}{ this.PrintJaggedArrayForJudeges(this.LeetCodeIntervalIntersection(input.A, input.B)) }for the given inputs{Environment.NewLine} A :{Environment.NewLine}{this.PrintJaggedArrayForJudeges(input.A)} {Environment.NewLine}B :{Environment.NewLine} {this.PrintJaggedArrayForJudeges(input.B)} ");              
            }

            MessageBox.Show(result.ToString());
        }

        public class IntervalIntersection
        {
            public int[][] A;
            public int[][] B;
        }


        public int[][] LeetCodeIntervalIntersection(int[][] A, int[][] B)
        {
            if (A == null || A.Length == 0)
                return A;

            if (B == null || B.Length == 0)
                return B;

            int al = A.Length;
            int bl = B.Length;
            int ar = 0;
            int br = 0;
            List<int[]> result = new List<int[]>();

            while (ar < al && br < bl)
            {

                if (A[ar][1] >= B[br][0] && B[br][1] >= A[ar][0])
                {
                    result.Add(new int[] { Math.Max(A[ar][0], B[br][0]), Math.Min(A[ar][1], B[br][1]) });
                }

                if (A[ar][1] < B[br][1])
                    ar++;
                else
                    br++;
            }

            return result.ToArray();

        }

        private void btn_Possible_Bipartition_Click(object sender, EventArgs e)
        {
            /*
                Given a set of N people (numbered 1, 2, ..., N), we would like to split everyone into two groups of any size.

                Each person may dislike some other people, and they should not go into the same group. 
                Formally, if dislikes[i] = [a, b], it means it is not allowed to put the people numbered a and b into the same group.
                Return true if and only if it is possible to split everyone into two groups in this way.

                Example 1:
                Input: N = 4, dislikes = [[1,2],[1,3],[2,4]]
                Output: true
                Explanation: group1 [1,4], group2 [2,3]
                
                Example 2:
                Input: N = 3, dislikes = [[1,2],[1,3],[2,3]]
                Output: false
                
                Example 3:
                Input: N = 5, dislikes = [[1,2],[2,3],[3,4],[4,5],[1,5]]
                Output: false

                Time Complexity     : O(V + E)
                Space Complexity    : O(V + E)
             */
            StringBuilder result = new StringBuilder();
            List<Common> inputs = new List<Common>();
            /*
            inputs.Add(new Common()
            {
                Input = new int[][]{
                new int[]{21,47},
                new int[]{4,41},
                new int[]{2,41},
                new int[]{36,42},
                new int[]{32,45},
                new int[]{26,28},
                new int[]{32,44},
                new int[]{5,41},
                new int[]{29,44},
                new int[]{10,46},
                new int[]{1,6},
                new int[]{7,42},
                new int[]{46,49},
                new int[]{17,46},
                new int[]{32,35},
                new int[]{11,48},
                new int[]{37,48},
                new int[]{37,43},
                new int[]{8,41},
                new int[]{16,22},
                new int[]{41,43},
                new int[]{11,27},
                new int[]{22,44},
                new int[]{22,28},
                new int[]{18,37},
                new int[]{5,11},
                new int[]{18,46},
                new int[]{22,48},
                new int[]{1,17},
                new int[]{2,32},
                new int[]{21,37},
                new int[]{7,22},
                new int[]{23,41},
                new int[]{30,39},
                new int[]{6,41},
                new int[]{10,22},
                new int[]{36,41},
                new int[]{22,25},
                new int[]{1,12},
                new int[]{2,11},
                new int[]{45,46},
                new int[]{2,22},
                new int[]{1,38},
                new int[]{47,50},
                new int[]{11,15},
                new int[]{2,37},
                new int[]{1,43},
                new int[]{30,45},
                new int[]{4,32},
                new int[]{28,37},
                new int[]{1,21},
                new int[]{23,37},
                new int[]{5,37},
                new int[]{29,40},
                new int[]{6,42},
                new int[]{3,11},
                new int[]{40,42},
                new int[]{26,49},
                new int[]{41,50},
                new int[]{13,41},
                new int[]{20,47},
                new int[]{15,26},
                new int[]{47,49},
                new int[]{5,30},
                new int[]{4,42},
                new int[]{10,30},
                new int[]{6,29},
                new int[]{20,42},
                new int[]{4,37},
                new int[]{28,42},
                new int[]{1,16},
                new int[]{8,32},
                new int[]{16,29},
                new int[]{31,47},
                new int[]{15,47},
                new int[]{1,5},
                new int[]{7,37},
                new int[]{14,47},
                new int[]{30,48},
                new int[]{1,10},
                new int[]{26,43},
                new int[]{15,46},
                new int[]{42,45},
                new int[]{18,42},
                new int[]{25,42},
                new int[]{38,41},
                new int[]{32,39},
                new int[]{6,30},
                new int[]{29,33},
                new int[]{34,37},
                new int[]{26,38},
                new int[]{3,22},
                new int[]{18,47},
                new int[]{42,48},
                new int[]{22,49},
                new int[]{26,34},
                new int[]{22,36},
                new int[]{29,36},
                new int[]{11,25},
                new int[]{41,44},
                new int[]{6,46},
                new int[]{13,22},
                new int[]{11,16},
                new int[]{10,37},
                new int[]{42,43},
                new int[]{12,32},
                new int[]{1,48},
                new int[]{26,40},
                new int[]{22,50},
                new int[]{17,26},
                new int[]{4,22},
                new int[]{11,14},
                new int[]{26,39},
                new int[]{7,11},
                new int[]{23,26},
                new int[]{1,20},
                new int[]{32,33},
                new int[]{30,33},
                new int[]{1,25},
                new int[]{2,30},
                new int[]{2,46},
                new int[]{26,45},
                new int[]{47,48},
                new int[]{5,29},
                new int[]{3,37},
                new int[]{22,34},
                new int[]{20,22},
                new int[]{9,47},
                new int[]{1,4},
                new int[]{36,46},
                new int[]{30,49},
                new int[]{1,9},
                new int[]{3,26},
                new int[]{25,41},
                new int[]{14,29},
                new int[]{1,35},
                new int[]{23,42},
                new int[]{21,32},
                new int[]{24,46},
                new int[]{3,32},
                new int[]{9,42},
                new int[]{33,37},
                new int[]{7,30},
                new int[]{29,45},
                new int[]{27,30},
                new int[]{1,7},
                new int[]{33,42},
                new int[]{17,47},
                new int[]{12,47},
                new int[]{19,41},
                new int[]{3,42},
                new int[]{24,26},
                new int[]{20,29},
                new int[]{11,23},
                new int[]{22,40},
                new int[]{9,37},
                new int[]{31,32},
                new int[]{23,46},
                new int[]{11,38},
                new int[]{27,29},
                new int[]{17,37},
                new int[]{23,30},
                new int[]{14,42},
                new int[]{28,30},
                new int[]{29,31},
                new int[]{1,8},
                new int[]{1,36},
                new int[]{42,50},
                new int[]{21,41},
                new int[]{11,18},
                new int[]{39,41},
                new int[]{32,34},
                new int[]{6,37},
                new int[]{30,38},
                new int[]{21,46},
                new int[]{16,37},
                new int[]{22,24},
                new int[]{17,32},
                new int[]{23,29},
                new int[]{3,30},
                new int[]{8,30},
                new int[]{41,48},
                new int[]{1,39},
                new int[]{8,47},
                new int[]{30,44},
                new int[]{9,46},
                new int[]{22,45},
                new int[]{7,26},
                new int[]{35,42},
                new int[]{1,27},
                new int[]{17,30},
                new int[]{20,46},
                new int[]{18,29},
                new int[]{3,29},
                new int[]{4,30},
                new int[]{3,46}
            },N = 50});

            
            inputs.Add(new Common()
            {
                Input = new int[][]
                                                        {
                                                            new int[] { 1, 2 },
                                                            new int[] { 3, 4 },
                                                            new int[] { 4, 5 },
                                                            new int[] { 3, 5 },
                                                        },N = 5});


            

            inputs.Add(new Common() { Input = new int[][] 
                                                        { 
                                                            new int[] { 1, 2 },
                                                            new int[] { 1, 3 },
                                                            new int[] { 2, 4 },
                                                        }, N = 4 });

            inputs.Add(new Common()
            {
                Input = new int[][]
                                                        {
                                                            new int[] { 1, 2 },
                                                            new int[] { 1, 3 },
                                                            new int[] { 2, 3 },
                                                        }, N =3
                
            });

            inputs.Add(new Common()
            {
                Input = new int[][]
                                      {
                                                            new int[] { 1, 2 },
                                                            new int[] { 2, 3 },
                                                            new int[] { 3, 4 },
                                                            new int[] { 4, 5 },
                                                            new int[] { 5, 1 },
                                      },
                                    N = 5
            });

            */

            inputs.Add(new Common()
            {
                Input = new int[][]
                                      {
                                                            new int[] { 1, 2 },
                                                            new int[] { 3, 4 },
                                                            new int[] { 5, 6 },
                                                            new int[] { 6, 7 },
                                                            new int[] { 8, 9 },
                                                            new int[] { 7, 8 },
                                      },
                N = 10 //10 [[1,2],[3,4],[5,6],[6,7],[8,9],[7,8]]
            });


            foreach (var input in inputs)
            {
                result.AppendLine($"There is {(this.PossibleBipartition(input.N, input.Input) ? "": "no") } possible partition for the given input {Environment.NewLine}{this.PrintJaggedArrayForJudeges(input.Input)}");

            }

            MessageBox.Show(result.ToString());
            
        }

        public bool PossibleBipartition(int N, int[][] dislikes)
        {
            if (dislikes == null)
                return false;

            if (N == 1)
                return true;
            
            int[] color = Enumerable.Repeat(-1, N + 1).ToArray<int>();                        

            List<int>[] list = new List<int>[N + 1];
            for (int r = 0; r < dislikes.Length; r++)
            {
                if (list[dislikes[r][0]] == null)                
                    list[dislikes[r][0]] = new List<int>();
                
                if (list[dislikes[r][1]] == null)
                    list[dislikes[r][1]] = new List<int>();

                list[dislikes[r][0]].Add(dislikes[r][1]);
                list[dislikes[r][1]].Add(dislikes[r][0]);
            }

            for(int i = 1; i<= N; i++)
            { 
                if (color[i] == -1)
                {
                    if (!this.IsPartitionExists(list, i, color))
                        return false; 
                }
            }

            return true;
        }

        private bool IsPartitionExists(List<int>[] list,  int start, int[] color)
        {
            bool result = true;

            int currC = 0;
            int currP = start;            
            color[start] = 1;
            Queue<int> q = new Queue<int>();
            q.Enqueue(currP);
           
            while(q.Count > 0)
            {

                currP = q.Dequeue();
                currC = color[currP];
                
                foreach (int i in list[currP])
                {
                    if (color[i] == -1)
                    {
                        color[i] = 1 - currC;
                        q.Enqueue(i);
                    }
                    else if (color[i] == currC)
                    {
                        result = false;
                        break;
                    }
                }
            }

            return result;
        }

        private void btn_Course_Schedule_Click(object sender, EventArgs e)
        {
            /*
            
                There are a total of numCourses courses you have to take, labeled from 0 to numCourses-1.

                Some courses may have prerequisites, for example to take course 0 you have to first take course 1, which is expressed as a pair: [0,1]

                Given the total number of courses and a list of prerequisite pairs, is it possible for you to finish all courses?

 

                Example 1:

                Input: numCourses = 2, prerequisites = [[1,0]]
                Output: true
                Explanation: There are a total of 2 courses to take. 
                             To take course 1 you should have finished course 0. So it is possible.
                Example 2:

                Input: numCourses = 2, prerequisites = [[1,0],[0,1]]
                Output: false
                Explanation: There are a total of 2 courses to take. 
                             To take course 1 you should have finished course 0, and to take course 0 you should
                             also have finished course 1. So it is impossible.
              

             Time Complexity    : O(V+E) where V is the vertix and E is the edges
             Space Complexity   : O(V+E) where V is the vertix and E is the edges
                
             */

            StringBuilder result = new StringBuilder();
            List<Common> inputs = new List<Common>();

            inputs.Add(new Common()
            {
                Input = new int[][]
                                      {
                                                            new int[] { 1, 0  },

                                      },
                N = 2
            });

            inputs.Add(new Common()
            {
                Input = new int[][]
                                    {
                                                            new int[] { 1, 0  },
                                                            new int[] { 0, 1  }

                                    },
                N = 2
            });

            inputs.Add(new Common()
            {
                Input = new int[][]
                                   {
                                                            new int[] { 1, 0  },
                                                            new int[] { 2, 6  },
                                                            new int[] { 1, 7  },
                                                            new int[] { 6, 4  },
                                                            new int[] { 7, 0  },
                                                            new int[] { 0, 5  },

                                   },
                N = 8
            });


            inputs.Add(new Common()
            {
                Input = new int[][]
                                   {
                                                            new int[] { 1, 0  },
                                                            new int[] { 0, 3  },
                                                            new int[] { 0, 2  },
                                                            new int[] { 3, 2  },
                                                            new int[] { 2, 5  },
                                                            new int[] { 4, 5  },
                                                            new int[] { 5, 6  },
                                                            new int[] { 2, 4  },
                                   },
                N = 7
            });

            foreach (var input in inputs)
            {
                result.AppendLine($"Course can{(this.CanFinish(input.N, input.Input) ? "" : "not") } be completed for the given courses {Environment.NewLine}{this.PrintJaggedArrayForJudeges(input.Input)}");

            }

            MessageBox.Show(result.ToString());
        }

        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            if (prerequisites == null)
                return false;

            int r = 0;
            int rl = prerequisites.Length;
            

            List<int>[] graph = new List<int>[numCourses];
            int[] visit = new int[numCourses];

            for (r = 0; r < rl; r++)
            {
                if (graph[prerequisites[r][0]] == null)
                    graph[prerequisites[r][0]] = new List<int>();

                graph[prerequisites[r][0]].Add(prerequisites[r][1]);
            }

            for (r = 0; r < rl; r++)
            {
                if (visit[r] == 0)
                {
                    if (this.IsCycleExists(graph, visit, r))
                    {
                        return false;
                    }
                }
                else if (visit[r] == 1)
                    return false;
            }

            return true;
        }


        private bool IsCycleExists(List<int>[] graph, int[] visit, int sCourse)
        {

            List<int> sources = null;
           
            if (visit[sCourse] == 0)
            {
                visit[sCourse] = 1;
                sources = graph[sCourse];
                if (sources != null)
                {
                    foreach (int c in sources)
                    {
                        if (IsCycleExists(graph, visit, c))
                            return true;
                    }
                }
                visit[sCourse] = 2;
            }
            else if (visit[sCourse] == 1)
            {
                return true;
            }
         
            return false;
        }

        private void btn_K_Closest_Points_to_Origin_Click(object sender, EventArgs e)
        {
            /*
             
                We have a list of points on the plane.  Find the K closest points to the origin (0, 0).

                (Here, the distance between two points on a plane is the Euclidean distance.)

                You may return the answer in any order.  The answer is guaranteed to be unique (except for the order that it is in.)

 

                Example 1:

                Input: points = [[1,3],[-2,2]], K = 1
                Output: [[-2,2]]
                Explanation: 
                The distance between (1, 3) and the origin is sqrt(10).
                The distance between (-2, 2) and the origin is sqrt(8).
                Since sqrt(8) < sqrt(10), (-2, 2) is closer to the origin.
                We only want the closest K = 1 points from the origin, so the answer is just [[-2,2]].
                Example 2:

                Input: points = [[3,3],[5,-1],[-2,4]], K = 2
                Output: [[3,3],[-2,4]]
                (The answer [[-2,4],[3,3]] would also be accepted.)

                Time Complexity     : O(NlogK);
                Space Complexity    : O(NlogK);
                
             */


            StringBuilder result = new StringBuilder();
            List<Common> inputs = new List<Common>();

            inputs.Add(new Common()
            {
                Input = new int[][]
                                      {
                                                            new int[] { 1, 3 },
                                                            new int[] { -2, 2 }
                                      },
                N = 2
            });


            inputs.Add(new Common()
            {
                Input = new int[][]
                                      {
                                                            new int[] { 3, 3 },
                                                            new int[] { 5, -1 },
                                                            new int[] { -2, 4 },
                                      },
                N = 2
            });

            inputs.Add(new Common()
            {
                Input = new int[][]
                                    {
                                                            new int[] { 6, 10 },
                                                            new int[] { 3, -3 },
                                                            new int[] { -2, 5 },
                                                            new int[] { 0, 2 },
                                    },
                N = 3
            });

            inputs.Add(new Common()
            {
                Input = new int[][]
                              {
                                                            new int[] { 10, -2 }, // 100+4=104      ->4
                                                            new int[] { 2, -2 },  // 4+4 = 8        ->1
                                                            new int[] { 10,10 },  // 100+100=200    ->5
                                                            new int[] { 9,4 },    // 81+16= 97      ->3
                                                            new int[] { -8,1 },   // 64+1= 65       ->2
                              },
                N = 4
            });


            inputs.Add(new Common()
            {
                Input = new int[][]
                                    {
                                                            new int[] { 3, 3 }, //18
                                                            new int[] { 5, -1 },//26
                                                            new int[] { -2, 4 } //18

                                    },
                N = 2
            });

            inputs.Add(new Common()
            {
                Input = new int[][]
                                    {
                                                            new int[] { 1, 3 },
                                                            new int[] { -2, 2 },
                                                            new int[] { -2, 2 },
                                    },
                N = 2
            });

            inputs.Add(new Common()
            {
                Input = new int[][]
                                    {
                                                            new int[] { 2, 2 },
                                                            new int[] { 2, 2 },
                                                            new int[] { 2, 2 },
                                                            new int[] { 2, 2 },
                                                            new int[] { 2, 2 },
                                                            new int[] { 2, 2 },
                                                            new int[] { 1, 1 },
                                    },
                N = 1
            });

            foreach (var input in inputs)
            {
                result.AppendLine($"{input.N} Closest Points to Origin are {Environment.NewLine}{this.PrintJaggedArrayForJudeges(this.KClosest(input.Input, input.N)) }{Environment.NewLine} for the given input {Environment.NewLine}{this.PrintJaggedArrayForJudeges(input.Input)}");
            }

            MessageBox.Show(result.ToString());


        }

        void BuildKClostHeap(Distance[] heap, int n)
        {
            int i = (n -1)/2;
            while (i >= 0)
            {
                Heapify(heap, i, n);
                i--;
            }
        }

        public int[][] KClosest(int[][] points, int K)
        {

            if (points == null)
                return new int[][] { };

            int[][] result = new int[K][];
            int l = points.Length;

            Distance[] heap = new Distance[l];

            for (int r = 0; r < l; r++)
            {
                heap[r] = new Distance() { Index = r, Value = Math.Sqrt((points[r][1] * points[r][1]) + (points[r][0] * points[r][0])) };
            }

            this.BuildKClostHeap(heap, l);

            for (int r = 0; r < K; r++)
            {
                this.Heapify(heap, 0, l);
                result[r] = points[heap[0].Index];
                heap[0] = heap[l - 1];
                l--;
            }


            return result;

        }

        public void Heapify(Distance[] heap, int start, int end)
        {

            int s = start;
            int l = (start * 2);
            int r = (start * 2) + 1;
            Distance temp;
            
            if (l < end && heap[s].Value > heap[l].Value)
                s = l;
            if (r < end && heap[s].Value > heap[r].Value)
                s = r;
            if (s != start)
            {
                temp = heap[start];
                heap[start] = heap[s];
                heap[s] = temp;
                Heapify(heap, s, end);
            }
            
        }


        public class Distance
        {
            public int Index;
            public double Value;
        }

        private void btn_Two_City_Scheduling_Click(object sender, EventArgs e)
        {
            /*
             
            There are 2N people a company is planning to interview. The cost of flying the i-th person to city A is costs[i][0], and the cost of flying the i-th person to city B is costs[i][1].
            Return the minimum cost to fly every person to a city such that exactly N people arrive in each city.

 
            Example 1:

            Input: [[10,20],[30,200],[400,50],[30,20]]
            Output: 110
            Explanation: 
            The first person goes to city A for a cost of 10.
            The second person goes to city A for a cost of 30.
            The third person goes to city B for a cost of 50.
            The fourth person goes to city B for a cost of 20.

            The total minimum cost is 10 + 30 + 50 + 20 = 110 to have half the people interviewing in each city.

            Time Complexity     : 
            Space Complexity    :

            */

            StringBuilder result = new StringBuilder();
            List<int[][]> inputs = new List<int[][]>();

            inputs.Add(new int[][]
                                      {
                                                            new int[] { 10, 20  },
                                                            new int[] { 30, 200  },
                                                            new int[] { 400, 50  },
                                                            new int[] { 30, 20  }

                                      });

            foreach (var input in inputs)
            {
                result.AppendLine($"Two City Scheduling cost is {this.TwoCitySchedCost(input)} for the input {Environment.NewLine}{this.PrintJaggedArrayForJudeges(input)}");

            }

            MessageBox.Show(result.ToString());

        }


        public int TwoCitySchedCost(int[][] costs)
        {
            if (costs == null || costs.Length == 0)
                return 0;

            //Comparer<int[]> comparer = Comparer<int[]>.Create((a,b)=>((a[1]-a[0]) > (b[1] - b[0]) ? a : b ));

            //Array.Sort(costs, comparer );

            return 0;
        }

        private void btn_Surrounded_Regions_Click(object sender, EventArgs e)
        {
            /*
                Given a 2D board containing 'X' and 'O' (the letter O), capture all regions surrounded by 'X'.

                A region is captured by flipping all 'O's into 'X's in that surrounded region.

                Example:

                X X X X
                X O O X
                X X O X
                X O X X
                After running your function, the board should be:

                X X X X
                X X X X
                X X X X
                X O X X
                Explanation:

                Surrounded regions shouldn’t be on the border, which means that any 'O' on the border of the board are not flipped to 'X'. Any 'O' that is not on the border and it is not connected to an 'O' 
                on the border will be flipped to 'X'. Two cells are connected if they are adjacent cells connected horizontally or vertically.


                Time Complexity         : 
                Space Complexity        : 
            */

            StringBuilder result = new StringBuilder();
            List<char[][]> inputs = new List<char[][]>();

            inputs.Add(new char[][]
                                      {
                                                            new char[] { 'X', 'X', 'X','X'},
                                                            new char[] { 'X', '0', '0','X' },
                                                            new char[] { 'X', 'X', '0','X' },
                                                            new char[] { 'X', '0', 'X','X' },

                                      });

            foreach (var input in inputs)
            {
                
                result.AppendLine($"Surrounded Regions for the given input{Environment.NewLine}{this.PrintJaggedArrayForJudegesChar(input)} { Environment.NewLine} is ");
                this.Solve(input);
                result.AppendLine($"{this.PrintJaggedArrayForJudegesChar(input)}");
            }

            MessageBox.Show(result.ToString());

        }

        public void Solve(char[][] board)
        {
            if (board == null || board.Length == 0)
                return;

            int rl = board.Length;
            int cl = board[0].Length;
            var bk = new char[board.Length][];

            for(int r = 0; r < rl; r++)
            {
                if (bk[r] == null)
                    bk[r] = new char[cl];

                for(int c = 0; c < cl; c++)
                {
                    bk[r][c] = board[r][c];
                }
            }

            rl--;cl--;
            
            for (int r = 1; r < rl; r++)
            {
                for (int c = 1; c < cl ; c++)
                {
                    
                    if (bk[r][c] == '0' &&
                        (
                            ((c - 1 > 0 || c + 1 < cl) && (bk[r][c] == bk[r][c - 1] || bk[r][c] == bk[r][c + 1])) ||
                            ((r - 1 > 0 || r + 1 < rl) && (bk[r][c] == bk[r - 1][c] || bk[r][c] == bk[r + 1][c]))
                         )
                       )
                    {
                        board[r][c] = 'X';
                    }
                    
                }
            }
            
        }
    }    
}
