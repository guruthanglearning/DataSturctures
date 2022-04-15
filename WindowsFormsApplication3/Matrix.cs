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

        private string PrintJaggedArray_String(string[][] input)
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


        private string PrintJaggedArray_char(char[][] input)
        {
            StringBuilder result = new StringBuilder();

            for (int r = 0; r < input.Length; r++)
            {
                for (int c = 0; c < input[r].Length; c++)
                {
                    result.Append($"{input[r][c]} {new String(' ',2)}");
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
            public char[][] CharInput;
            public string word;
            public int R;
            public int C;
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
            string temp = string.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                temp = string.Empty;
                for (int j = 0; j < input[0].Length; j++)
                    temp += $"{input[i][j]}   ";


                result.AppendLine($"{temp}");

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

        private void btn_Unique_Paths_Click(object sender, EventArgs e)
        {
            /*
                A robot is located at the top-left corner of a m x n grid (marked 'Start' in the diagram below).
                The robot can only move either down or right at any point in time. The robot is trying to reach the bottom-right corner of the grid 
                (marked 'Finish' in the diagram below).

                How many possible unique paths are there?

                Above is a 7 x 3 grid. How many possible unique paths are there?

                Example 1:

                Input: m = 3, n = 2
                Output: 3
                Explanation:
                From the top-left corner, there are a total of 3 ways to reach the bottom-right corner:
                1. Right -> Right -> Down
                2. Right -> Down -> Right
                3. Down -> Right -> Right
                Example 2:

                Input: m = 7, n = 3
                Output: 28
 

                Constraints:

                1 <= m, n <= 100
                It's guaranteed that the answer will be less than or equal to 2 * 10 ^ 9.

                Time Complexity          : O(RC)
                Space Complexity         : O(RC)

            */
            StringBuilder result = new StringBuilder();
            List<RowCol> inputs = new List<RowCol>();
            inputs.Add(new RowCol() {Row = 3, Col = 2  });
            inputs.Add(new RowCol() { Row = 7, Col = 3 });


            foreach (var input in inputs)
            {                               
                result.AppendLine($"There are {this.UniquePaths(input.Row, input.Col)} unique paths for the given row : {input.Row} column : {input.Col}");
            }

            MessageBox.Show(result.ToString());
        }

        public int UniquePaths(int m, int n)
        {
            int[,] dict = new int[m, n];

            for (int r = 0; r < m; r++)
                dict[r, 0] = 1;
            for (int c = 1; c < n; c++)
                dict[0, c] = 1;

            for (int r = 1; r < m; r++)
                for (int c = 1; c < n; c++)
                    dict[r, c] = dict[r - 1, c] + dict[r, c - 1];

            return dict[m - 1, n - 1];
        }

        private void btn_Island_Perimeter_Click(object sender, EventArgs e)
        {
            /*

                Island Perimeter
                You are given a map in form of a two-dimensional integer grid where 1 represents land and 0 represents water.

                Grid cells are connected horizontally/vertically (not diagonally). The grid is completely surrounded by water, and there is exactly one island (i.e., one or more connected land cells).

                The island doesn't have "lakes" (water inside that isn't connected to the water around the island). One cell is a square with side length 1. The grid is rectangular, width and height don't exceed 100. Determine the perimeter of the island.

 

                Example:

                Input: n                         
                [[0,1,0,0],
                 [1,1,1,0],
                 [0,1,0,0],
                 [1,1,0,0]]

                Output: 16

                Explanation: The perimeter is the 16 yellow stripes in the image below:

                Time Complexity     : O(RC)
                Space Complexity    : O(1)

            */


            StringBuilder result = new StringBuilder();
            List<int[][]> inputs = new List<int[][]>();

            inputs.Add(new int[][]
                                      {
                                                            new int[] { 0, 1, 0, 0 },
                                                            new int[] { 1, 1, 1, 0 },
                                                            new int[] { 0, 1, 0, 0 },
                                                            new int[] { 1, 1, 0, 0 },

                                      });

            foreach (var input in inputs)
            {
                result.AppendLine($"Perimeter of an island for the given input {Environment.NewLine}{this.PrintJaggedArrayForJudeges(input)} { Environment.NewLine} is {this.IslandPerimeter(input)}");                                
            }

            MessageBox.Show(result.ToString());

        }


        public int IslandPerimeter(int[][] grid)
        {
            if (grid == null || grid.Length == 0)
                return 0;

            int islands = 0;
            int neighbors = 0;
            int rows = grid.Length;
            int cols = grid[0].Length;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        islands++;
                        if (i + 1 < rows && grid[i + 1][j] == 1)
                        {
                            neighbors++;
                        }
                        if (j + 1 < cols && grid[i][j + 1] == 1)
                        {
                            neighbors++;
                        }
                    }
                }
            }
            return islands * 4 - neighbors * 2;
        }

        private void btn_Word_Search_Click(object sender, EventArgs e)
        {
            /*
             
                Given a 2D board and a word, find if the word exists in the grid.

                The word can be constructed from letters of sequentially adjacent cell, where "adjacent" cells are those horizontally or vertically neighboring. 
                The same letter cell may not be used more than once.

                Example:
                board =
                [
                  ['A','B','C','E'],
                  ['S','F','C','S'],
                  ['A','D','E','E']
                ]

                Given word = "ABCCED", return true.
                Given word = "SEE", return true.
                Given word = "ABCB", return false.             


                Time Complexity     : O(RC)
                Space Complexity    : O(1)
             */

            StringBuilder result = new StringBuilder();
            List<Common> inputs = new List<Common>();

            inputs.Add(new Common()
            {
                CharInput = new char[][]
                                          {
                                                                new char[] { 'A', 'B', 'C', 'E' },
                                                                new char[] { 'S', 'F', 'C', 'S' },
                                                                new char[] { 'A', 'D', 'E', 'E' }
                                          },
                word = "ABCCED"
            });


            inputs.Add(new Common()
            {
                CharInput = new char[][]
                                     {
                                                                new char[] { 'A', 'B', 'C', 'E' },
                                                                new char[] { 'S', 'F', 'C', 'S' },
                                                                new char[] { 'A', 'D', 'E', 'E' }
                                     },
                word = "SEE"
            });

            inputs.Add(new Common()
            {
                CharInput = new char[][]
                                     {
                                                                new char[] { 'A', 'B', 'C', 'E' },
                                                                new char[] { 'S', 'F', 'C', 'S' },
                                                                new char[] { 'A', 'D', 'E', 'E' }
                                     },
                word = "ABCB"
            });
            
            foreach (var input in inputs)
            {
                result.AppendLine($"Word {input.word} {(this.Exist(input.CharInput, input.word) ? "" : "not")} exists for the given dictionary {this.PrintJaggedArrayForJudegesChar(input.CharInput)}");
            }

            MessageBox.Show(result.ToString());

        }



        public bool Exist(char[][] board, string word)
        {

            if (string.IsNullOrEmpty(word) || board.Length == 0)
                return false;


            for (int r = 0; r < board.Length; r++)
            {
                for (int c = 0; c < board[0].Length; c++)
                {
                    if (board[r][c] == word[0])
                    {
                        if (IsWordExists(board, word, r, c, 0))
                            return true;
                    }
                }
            }


            return false;

        }

        private bool IsWordExists(char[][] board, string word, int r, int c, int wIndex)
        {
            int rl = board.Length;
            int cl = board[0].Length;

            if (wIndex == word.Length - 1)
                return true;

            bool result = false;

            if (word[wIndex] == board[r][c] && !result)
            {
                char chr = board[r][c];
                board[r][c] = '\0';

                if ((r >= 0 || r < rl) && c - 1 >= 0 && word[wIndex+1] == board[r][c - 1])                
                    result = this.IsWordExists(board, word, r, c - 1, wIndex + 1);                    
                
                if (!result && (r >= 0 || r < rl) && c + 1 < cl && word[wIndex + 1] == board[r][c + 1])                
                    result = this.IsWordExists(board, word, r, c + 1, wIndex + 1);                    
                
                if (!result && r - 1 >= 0 && (c >= 0 || c < cl) && word[wIndex + 1] == board[r - 1][c])                
                    result = this.IsWordExists(board, word, r-1, c , wIndex + 1);                    
                
                if (!result &&  r + 1 < rl && (c >= 0 || c < cl) && word[wIndex + 1] == board[r + 1][c])
                    result = this.IsWordExists(board, word, r + 1, c, wIndex + 1);
                    
                board[r][c] = chr;
            }
            
            return result;

        }

        private void btn_Rotting_Oranges_Click(object sender, EventArgs e)
        {
            /*
        
                In a given grid, each cell can have one of three values:

                the value 0 representing an empty cell;
                the value 1 representing a fresh orange;
                the value 2 representing a rotten orange.
                Every minute, any fresh orange that is adjacent (4-directionally) to a rotten orange becomes rotten.

                Return the minimum number of minutes that must elapse until no cell has a fresh orange.  If this is impossible, return -1 instead.

 
             
                Example 1:



                Input: [[2,1,1],[1,1,0],[0,1,1]]
                Output: 4
                Example 2:

                Input: [[2,1,1],[0,1,1],[1,0,1]]
                Output: -1
                Explanation:  The orange in the bottom left corner (row 2, column 0) is never rotten, because rotting only happens 4-directionally.
                Example 3:

                Input: [[0,2]]
                Output: 0
                Explanation:  Since there are already no fresh oranges at minute 0, the answer is just 0.
 
            */


            StringBuilder result = new StringBuilder();
            List<int[][]> inputs = new List<int[][]>();

            inputs.Add(new int[][]
                                      {
                                                            new int[] { 2, 1, 1 },
                                                            new int[] { 1, 1, 0 },
                                                            new int[] { 0, 1, 1 }
                                      });

            inputs.Add(new int[][]
                                      {
                                                            new int[] { 0, 2 }
                                                     
                                      });

            foreach (var input in inputs)
            {
                result.AppendLine($"Min Time to rotten all oranges is { this.OrangesRotting(input) } for the given input {Environment.NewLine}{this.PrintJaggedArrayForJudeges(input)}");
            }

            MessageBox.Show(result.ToString());



        }

        public int OrangesRotting(int[][] grid)
        {
            int result = 0;
            if (grid == null || grid.Length == 0)
                return result;

            int rl = grid.Length;
            int cl = grid[0].Length;

            Queue<RCR> q = new Queue<RCR>();
            result = 0;

            for (int row = 0; row < rl; row++)
            {
                for (int col = 0; col < cl; col++)
                {
                    if (grid[row][col] == 2)
                        q.Enqueue(new RCR() { Row = row, Col = col, Time = result });
                }
            }

            RCR r = null;

            /* [2,2,2],              
             [2,2,0],               2,2,4 
             [0,2,2]     */
            while (q.Count > 0)
            {
                r = q.Dequeue();

                if (r.Col + 1 < cl && grid[r.Row][r.Col + 1] == 1)
                {
                    grid[r.Row][r.Col + 1] = 2;
                    q.Enqueue(new RCR() { Row = r.Row, Col = r.Col + 1, Time = r.Time + 1 });
                    result = Math.Max(r.Time + 1, result);
                }

                if (r.Col - 1 >= 0 && grid[r.Row][r.Col - 1] == 1)
                {
                    grid[r.Row][r.Col - 1] = 2;
                    q.Enqueue(new RCR() { Row = r.Row, Col = r.Col - 1, Time = r.Time + 1 });
                    result = Math.Max(r.Time + 1, result);
                }

                if (r.Row + 1 < rl && grid[r.Row + 1][r.Col] == 1)
                {
                    grid[r.Row + 1][r.Col] = 2;
                    q.Enqueue(new RCR() { Row = r.Row + 1, Col = r.Col, Time = r.Time + 1 });
                    result = Math.Max(r.Time + 1, result);
                }


                if (r.Row - 1 >= 0 && grid[r.Row - 1][r.Col] == 1)
                {
                    grid[r.Row - 1][r.Col] = 2;
                    q.Enqueue(new RCR() { Row = r.Row - 1, Col = r.Col, Time = r.Time + 1 });
                    result = Math.Max(r.Time + 1, result);
                }
            }


            for (int row = 0; row < rl; row++)
            {
                for (int col = 0; col < cl; col++)
                {
                    if (grid[row][col] == 1)
                        return -1;
                }
            }

            return result;
        }

        public class RCR
        {
            public int Row;
            public int Col;
            public int Time;
        }

        private void btn_Count_All_Possible_Path_from_Top_Left_to_Bottom_Right_Click(object sender, EventArgs e)
        {
            /*
                https://www.geeksforgeeks.org/count-possible-paths-top-left-bottom-right-nxm-matrix/
                 

             */


            StringBuilder result = new StringBuilder();
            List<Point> inputs = new List<Point>();
            inputs.Add(new Point() { X = 3, Y = 2 });

            
            foreach (var input in inputs)
            {
                result.AppendLine($"NumberOfPath using DP: { this.NumberOfPathsUsingDP(input.X, input.Y) } and Formual: {this.NumberOfPathsUsingFomula(input.X, input.Y)} for the given matrix Row : {input.X} and Column : {input.Y}");
            }

            MessageBox.Show(result.ToString());


        }

        private int NumberOfPathsUsingFomula(int m, int n)
        {
            // We have to calculate m+n-2 C n-1 here 
            // which will be (m+n-2)! / (n-1)! (m-1)! 
            int path = 1;
            for (int i = n; i < (m + n - 1); i++)
            {
                path *= i;
                path /= (i - n + 1);
            }
            return path;
        }
        private int NumberOfPathsUsingDP(int m, int n)
        {
            // Create a 1D array to store 
            // results of subproblems 
            int[] dp = new int[n];
            dp[0] = 1;

            for (int i = 0; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    dp[j] += dp[j - 1];
                }
            }

            return dp[n - 1];
        }

        private void btn_Search_a_2D_Matrix_Click(object sender, EventArgs e)
        {
            /*
                Write an efficient algorithm that searches for a value in an m x n matrix. This matrix has the following properties:

                Integers in each row are sorted from left to right.
                The first integer of each row is greater than the last integer of the previous row.
 

                Example 1:


                Input: matrix = [[1,3,5,7],[10,11,16,20],[23,30,34,50]], target = 3
                Output: true
                Example 2:


                Input: matrix = [[1,3,5,7],[10,11,16,20],[23,30,34,50]], target = 13
                Output: false
                Example 3:

                Input: matrix = [], target = 0
                Output: false
 

                Constraints:

                m == matrix.length
                n == matrix[i].length
                0 <= m, n <= 100
                -104 <= matrix[i][j], target <= 104
           
                Time Complexity     :  O(log N)
                Space Complexity    :  O(1)


            */


            StringBuilder result = new StringBuilder();
            List<Common> inputs = new List<Common>();
            

            inputs.Add(new Common()
            {
                Input = new int[][] {
                                     new int[] {1, 3, 5, 7 },
                                     new int[] {10, 11, 16,20},
                                     new int[] {23,30,34,60}
                                    },
                N = 3
            });

            inputs.Add(new Common()
            {
                Input = new int[][] {
                                     new int[] {1, 3, 5, 7 },
                                     new int[] {10, 11, 16,20},
                                     new int[] {23,30,34,60}
                                    },
                N = 13
            });



            foreach (var input in inputs)
            {
                result.AppendLine($"Search a 2D Matrix is { this.SearchMatrix(input.Input, input.N) } for the given input array : {Environment.NewLine}{this.PrintJaggedArrayForJudeges(input.Input)} and target :{input.N}");

            }

            MessageBox.Show(result.ToString());

        }

        public bool SearchMatrix(int[][] matrix, int target)
        {
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
                return false;
            
            int r = 0;
            int cl = matrix[0].Length -1;            
           
            while (cl>=0 && r < matrix.Length)
            {
                if (matrix[r][cl] == target)
                    return true;
                else if (target > matrix[r][cl])
                    r++;
                else
                    cl--;

            }

            return false;

        }

        private void btn_Flipping_an_Image_Click(object sender, EventArgs e)
        {
            /*
             
            Given a binary matrix A, we want to flip the image horizontally, then invert it, and return the resulting image.

            To flip an image horizontally means that each row of the image is reversed.  For example, flipping [1, 1, 0] horizontally results in [0, 1, 1].

            To invert an image means that each 0 is replaced by 1, and each 1 is replaced by 0. For example, inverting [0, 1, 1] results in [1, 0, 0].

            Example 1:

            Input: [[1,1,0],[1,0,1],[0,0,0]]
            Output: [[1,0,0],[0,1,0],[1,1,1]]
            Explanation: First reverse each row: [[0,1,1],[1,0,1],[0,0,0]].
            Then, invert the image: [[1,0,0],[0,1,0],[1,1,1]]
            Example 2:

            Input: [[1,1,0,0],[1,0,0,1],[0,1,1,1],[1,0,1,0]]
            Output: [[1,1,0,0],[0,1,1,0],[0,0,0,1],[1,0,1,0]]
            Explanation: First reverse each row: [[0,0,1,1],[1,0,0,1],[1,1,1,0],[0,1,0,1]].
            Then invert the image: [[1,1,0,0],[0,1,1,0],[0,0,0,1],[1,0,1,0]]
            Notes:

            1 <= A.length = A[0].length <= 20
            0 <= A[i][j] <= 1


            Time Complexity         : O(RC)
            Space Complexity        : O(1)

            */

            StringBuilder result = new StringBuilder();
            List<int[][]> inputs = new List<int[][]>();


            inputs.Add(new int[][]
                                      {
                                                            new int[] { 1,1,0 },
                                                            new int[] { 1,0,1 },
                                                            new int[] {0,0,0 }
                                      });

            inputs.Add(new int[][]
                                      {
                                                              new int[] { 1,1,0, 0},
                                                              new int[] { 1,0,0,1 },
                                                              new int[] { 0,1,1,1 },
                                                              new int[] { 1,0,1,0 },

                                      });

            inputs.Add(new int[][]
                                      {
                                                              new int[] { 1} });

            foreach (var input in inputs)
            {
                result.AppendLine($"Flipping an Image for the given input {Environment.NewLine}{this.PrintJaggedArrayForJudeges(input)} is {Environment.NewLine} {this.PrintJaggedArrayForJudeges(FlipAndInvertImage(input))} ");
            }

            MessageBox.Show(result.ToString());


        }


        public int[][] FlipAndInvertImage(int[][] A)
        {

            Stack<int[]> s = new Stack<int[]>();
            s.ToArray<int[]>();

            if (A == null || A.Length == 0)
                return A;

            int clen = A[0].Length;
            int rlen = A.Length;
            int cl = 0;
            int cr = 0;
            int temp = 0;
            bool isLengthOdd = clen % 2 == 1;
            for (int r = 0; r < rlen; r++)
            {
                cl = 0;
                cr = clen - 1;
                while (cl < cr)
                {
                    temp = A[r][cl];
                    A[r][cl] = A[r][cr] == 0 ? 1 : 0;
                    A[r][cr] = temp == 0 ? 1 : 0;
                    cl++;
                    cr--;
                }

                if (isLengthOdd)
                    A[r][cl] = A[r][cl] == 0 ? 1 : 0;
            }

            return A;
        }

        private void btn_Merge_Intervals_Click(object sender, EventArgs e)
        {
            /*
                Given an array of intervals where intervals[i] = [starti, endi], merge all overlapping intervals, and return an array of the non-overlapping intervals that cover all the intervals in the input.

                Example 1:

                Input: intervals = [[1,3],[2,6],[8,10],[15,18]]
                Output: [[1,6],[8,10],[15,18]]
                Explanation: Since intervals [1,3] and [2,6] overlaps, merge them into [1,6].
                Example 2:

                Input: intervals = [[1,4],[4,5]]
                Output: [[1,5]]
                Explanation: Intervals [1,4] and [4,5] are considered overlapping.
 

                Constraints:

                1 <= intervals.length <= 104
                intervals[i].length == 2
                0 <= starti <= endi <= 104

                Time Complexty      :       O(NlogN)
                Space Complexity    :       O(N*M)
             
             */


            StringBuilder result = new StringBuilder();
            List<Common> inputs = new List<Common>();

 
            inputs.Add(new Common()
            {
                Input = new int[][] {
                                         new int[] {1,3},
                                         new int[] {2,6},
                                         new int[] {8,10},
                                         new int[] {15,18},
                                    }
            });

            inputs.Add(new Common()
            {
                Input = new int[][] {
                                     new int[] {1, 4 },
                                     new int[] {4,5},
                                   
                                    }
            });

            inputs.Add(new Common()
            {
                Input = new int[][] {
                                     new int[] {1, 4 },
                                     new int[] {1,4},

                                    }
            });

            inputs.Add(new Common()
            {
                Input = new int[][] {
                                     new int[] {1, 4 },
                                     new int[] {0,4},

                                    }
            });

            inputs.Add(new Common()
            {
                Input = new int[][] {
                                     new int[] {1, 4},
                                     new int[] {2, 3},

                                    }
            });

            foreach (var input in inputs)
            {
                result.AppendLine($"Merging of intervals for the given input array : {Environment.NewLine}{this.PrintJaggedArrayForJudeges(input.Input)} is {Environment.NewLine}{this.PrintJaggedArrayForJudeges(this.Merge(input.Input))}");
            }

            MessageBox.Show(result.ToString());


        }

        public int[][] Merge(int[][] intervals)
        {
            if (intervals == null || intervals.Length == 0)
                return intervals;

            Array.Sort(intervals, ((x, y) => x[0] - y[0]));
            Stack<int[]> s = new Stack<int[]>();
            s.Push(intervals[0]);
            int[] interval = new int[2];

            /*
                [[1,3],[2,6],[8,10],[15,18]]
                [[1,4],[4,5]]        
                [[1,4],[0,4]]
            */


            for (int i = 1; i < intervals.Length; i++)
            {
                interval = s.Peek();
                if (interval[0] <= intervals[i][0] && intervals[i][0] <= interval[1])
                {
                    interval[1] = Math.Max(interval[1], intervals[i][1]);
                    s.Pop();
                    s.Push(interval);
                }
                else
                    s.Push(intervals[i]);
            }

            return s.ToArray<int[]>();

        }

        private void btn_The_Skyline_Problem_Click(object sender, EventArgs e)
        {
            

            int i = 0, ri = 0;
            /*
             
             A city's skyline is the outer contour of the silhouette formed by all the buildings in that city when viewed from a distance. 
             Now suppose you are given the locations and height of all the buildings as shown on a cityscape photo (Figure A), 
             write a program to output the skyline formed by these buildings collectively (Figure B).


            The geometric information of each building is represented by a triplet of integers [Li, Ri, Hi], where Li and Ri are the x coordinates of the left and right 
            edge of the ith building, respectively, and Hi is its height. It is guaranteed that 0 ≤ Li, Ri ≤ INT_MAX, 0 < Hi ≤ INT_MAX, and Ri - Li > 0. You may assume 
            all buildings are perfect rectangles grounded on an absolutely flat surface at height 0.

            For instance, the dimensions of all buildings in Figure A are recorded as: [ [2 9 10], [3 7 15], [5 12 12], [15 20 10], [19 24 8] ] .

            The output is a list of "key points" (red dots in Figure B) in the format of [ [x1,y1], [x2, y2], [x3, y3], ... ] that uniquely defines a skyline. A key point is the left endpoint of a horizontal line segment. Note that the last key point, where the rightmost building ends, is merely used to mark the termination of the skyline, and always has zero height. Also, the ground in between any two adjacent buildings should be considered part of the skyline contour.

            For instance, the skyline in Figure B should be represented as:[ [2 10], [3 15], [7 12], [12 0], [15 10], [20 8], [24, 0] ].

            Notes:

            The number of buildings in any input list is guaranteed to be in the range [0, 10000].
            The input list is already sorted in ascending order by the left x position Li.
            The output list must be sorted by the x position.
            There must be no consecutive horizontal lines of equal height in the output skyline. 
            For instance, [...[2 3], [4 5], [7 5], [11 5], [12 7]...] is not acceptable; the three lines of height 5 should be merged into one in the final output as 
            such: [...[2 3], [4 5], [12 7], ...]

             
             
             */


            StringBuilder result = new StringBuilder();
            List<Common> inputs = new List<Common>();


            inputs.Add(new Common()
            {
                Input = new int[][] {
                                         new int[] {2,9,10},
                                         new int[] {3,7,15},
                                         new int[] {5,12,12},
                                         new int[] {15,20,10},
                                         new int[] {19,24,8}
                                    }
            });

            
            foreach (var input in inputs)
            {
                result.AppendLine($"The Skyline Problem for the given input array : {Environment.NewLine} {this.PrintJaggedArray(input.Input)} ");

                var res = this.GetSkyline(input.Input);
                foreach (var r in res)
                    result.AppendLine($"{string.Join(",", r)}");
                
            }

            MessageBox.Show(result.ToString());

        }

        public IList<IList<int>> GetSkyline(int[][] buildings)
        {
            List<IList<int>> returnValue = new List<IList<int>>();

            // BuildingPoint is the event. The isStart boolean will tell which kind
            List<BuildingPoint> points = new List<BuildingPoint>();
            for (int i = 0; i < buildings.GetLength(0); i++)
            {
                int x1 = buildings[i][0];
                int x2 = buildings[i][1];
                int y = buildings[i][2]; // in production code we should throw for y == 0
                points.Add(new BuildingPoint(x1, y, true));

                // You might think y = 0 is the right thing to add here, but we will use the
                // y in the end event to find a corresponding start event with that y and 
                // remove it from the priority queue
                points.Add(new BuildingPoint(x2, y, false));
            }
            
            points.Sort(buildingPointComparison);

            // SortedSet and SortedDictionary are tree based.
            // We can have multiple y's so we need a count to manage that 
            // Right now, you can't simply use a SortedDictionary<int, int> (of y to its count)
            // because SortedDictionary can't extract max/min in O(log n) even though it is based
            // on SortedSet, which can extract max/min in O(log n).
            // To use a SortedSet and keep a count as well, we use the NumberCount class and
            // NumberCountComparer
            SortedSet<NumberCount> setAsPriorityQueue = new SortedSet<NumberCount>(new NumberCountComparer());

            // This makes it so we allways have an oldYMax in the loop. The count of 1
            // could be anything. We will never remove this because 0 is not in the input as a height
            setAsPriorityQueue.Add(new NumberCount(0, 1));

            // Finally do what I wrote above
            foreach (BuildingPoint point in points)
            {
                int oldYMax = setAsPriorityQueue.Max.number;
                if (point.isStart)
                {
                    AddInSetAsPriorityQueue(setAsPriorityQueue, point.y);
                }
                else // the poit is an end
                {
                    RemoveFromSetAsPriorityQueue(setAsPriorityQueue, point.y);
                }

                int newYMax = setAsPriorityQueue.Max.number;
                if (newYMax != oldYMax)
                {
                    returnValue.Add(new List<int>() { point.x, newYMax });
                }
            }

            return returnValue;

        }

        private static NumberCount placeHolderNumberCount = new NumberCount(0, 0);

        /// <summary>
        /// Helper to add a new NumberCount or increment its count
        /// </summary>
        private static void AddInSetAsPriorityQueue(SortedSet<NumberCount> setAsPriorityQueue, int number)
        {
            // I wish I could use SortedDictionary. SortedSet's main scenario is Contains
            // Extracting the object we added is not the main scenario. Thankfully GetViewBetween does that
            placeHolderNumberCount.number = number;
            SortedSet<NumberCount> existing = setAsPriorityQueue.GetViewBetween(placeHolderNumberCount, placeHolderNumberCount);

            if (existing.Count == 1)
            {
                existing.Max.count++;
            }
            else
            {
                setAsPriorityQueue.Add(new NumberCount(number, 1));
            }
        }

        /// <summary>
        /// Helper to decrement a NumberCount or remove it when it reaches 0
        /// </summary>
        private static void RemoveFromSetAsPriorityQueue(SortedSet<NumberCount> setAsPriorityQueue, int number)
        {
            placeHolderNumberCount.number = number;
            SortedSet<NumberCount> existing = setAsPriorityQueue.GetViewBetween(placeHolderNumberCount, placeHolderNumberCount);

            // assert existing.Count == 1
            NumberCount numberCount = existing.Max;
            if (numberCount.count == 1)
            {
                setAsPriorityQueue.Remove(numberCount);
            }
            else
            {
                numberCount.count--;
            }
        }

        private static Comparison<BuildingPoint> buildingPointComparison = (BuildingPoint first, BuildingPoint second) =>
        {
            if (first.x != second.x)
            {
                return first.x - second.x;
            }

            // from here forward first.x == second.x

            if (first.isStart && second.isStart)
            {
                // Biggest y first means descending (second - first)
                return second.y - first.y;
            }

            if (!first.isStart && !second.isStart)
            {
                // Smallest y first is the usual ascending (first - second)
                return first.y - second.y;
            }

            // from here forward one is a start and the other is an end
            // either second.isStart (first.isEnd will be true) ...
            if (second.isStart)
            {
                return 1; // A positive value causes a swap (think first = 2, second = 1)
                          // and the regular ascending first-second
            }

            // ...or first.isStart && second.isEnd
            return -1; // causes first and second to remain as they are
        };

        class BuildingPoint
        {
            public int x;
            public int y;
            public bool isStart;
            public BuildingPoint(int x, int y, bool isStart)
            {
                this.x = x;
                this.y = y;
                this.isStart = isStart;
            }
        }

        class NumberCount
        {
            public int number;
            public int count;
            public NumberCount(int number, int count)
            {
                this.number = number;
                this.count = count;
            }
        }

        class NumberCountComparer : IComparer<NumberCount>
        {
            public int Compare(NumberCount first, NumberCount second)
            {
                return first.number - second.number;
            }
        }

        private void btn_Spiral_Matrix_II_Click(object sender, EventArgs e)
        {
            /*
             
                Given a positive integer n, generate an n x n matrix filled with elements 
                from 1 to n2 in spiral order.

                    Example 1:
                        1   2   3
                        8   9   4
                        7   6   5

                    Input: n = 3
                    Output: [[1,2,3],[8,9,4],[7,6,5]]
                    Example 2:

                    Input: n = 1
                    Output: [[1]]
 

                    Constraints:

                    1 <= n <= 20


             */

            StringBuilder result = new StringBuilder();
            List<int> inputs = new List<int>();
            inputs.Add(1);
            inputs.Add(2);
            inputs.Add(3);
            inputs.Add(4);
            inputs.Add(5);


            foreach (var input in inputs)
            {
                result.AppendLine($"Sprial Matrix 2 for the given matrix dimension {input} X {input}: {Environment.NewLine}{this.PrintJaggedArrayForJudeges(GenerateMatrix(input))}");
            }

            MessageBox.Show(result.ToString());



        }

        public int[][] GenerateMatrix(int n)
        {

            if (n == 0)
                return new int[n + 1][];

            int[][] result = new int[n][];
            for (int i = 0; i < n; i++)
                result[i] = new int[n];

            int counter = 1;
            int l = 0, r = n - 1, t = 0, d = n - 1;


            while (true)
            {
                if (l > r || t > d)
                    break;

                //Left to right
                for (int i = l; i <= r; i++)
                {
                    result[l][i] = counter++;
                }

                t++;

                if (l > r || t > d)
                    break;

                //Top to down;
                for (int i = t; i <= d; i++)
                {
                    result[i][d] = counter++;

                }

                r--;

                if (l > r || t > d)
                    break;

                //Right to left
                for (int i = r; i >= l; i--)
                {
                    result[d][i] = counter++;
                }

                d--;


                if (l > r || t > d)
                    break;

                //down to top
                for (int i = d; i >= t; i--)
                {
                    result[i][l] = counter++;
                }
                l++;

            }

            return result;
        }

        private void btn_Sort_the_Matrix_Diagonally_Click(object sender, EventArgs e)
        {
            /*
             
                A matrix diagonal is a diagonal line of cells starting from some cell in either the topmost row or leftmost column and going in the bottom-right direction until 
                reaching the matrix's end. For example, the matrix diagonal starting from mat[2][0], where mat is a 6 x 3 matrix, includes cells mat[2][0], mat[3][1], and mat[4][2].

                Given an m x n matrix mat of integers, sort each matrix diagonal in ascending order and return the resulting matrix.
                
                Example 1:
                Input: mat = [[3,3,1,1],[2,2,1,2],[1,1,1,2]]
                Output: [[1,1,1,1],[1,2,2,2],[1,2,3,3]]
 
                Constraints:

                m == mat.length
                n == mat[i].length
                1 <= m, n <= 100
                1 <= mat[i][j] <= 100
 
                Hide Hint #1  
                Use a data structure to store all values of each diagonal.
                
                Hide Hint #2  
                How to index the data structure with the id of the diagonal?
                
                Hide Hint #3  
                All cells in the same diagonal (i,j) have the same difference so we can get the diagonal of a cell using the difference i-j.
             
                Time Complexity  : O(RCD) D is the Length  of the item in the list
                Space Complexity : O(D) is the Length  of the item in the list
                    
             */


            StringBuilder result = new StringBuilder();
            List<Common> inputs = new List<Common>();


            inputs.Add(new Common()
            {
                Input = new int[][] {
                                         new int[] {3,3,1,1},
                                         new int[] {2,2,1,2},
                                         new int[] {1,1,1,2}
                                    }
            });


            foreach (var input in inputs)
            {
                result.AppendLine($"Sort the Matrix Diagonally for the given input array : {Environment.NewLine} {this.PrintJaggedArray(input.Input)} {Environment.NewLine} {this.PrintJaggedArray(this.DiagonalSort(input.Input))}");

            }

            MessageBox.Show(result.ToString());

        }

        public int[][] DiagonalSort(int[][] mat)
        {
            for (int i = 0; i < mat.Length; i++)
            {
                mat = SortDiagonal(i, 0, mat);
            }
            for (int i = 1; i < mat[0].Length; i++)
            {
                mat = SortDiagonal(0, i, mat);
            }
            return mat;
        }
        private int[][] SortDiagonal(int row, int col, int[][] mat)
        {
            List<int> diagEle = new List<int>();
            int i = row;
            int j = col;
            while (i < mat.Length && j < mat[i].Length)
            {
                diagEle.Add(mat[i][j]);
                i++;
                j++;
            }
            diagEle.Sort();
            int k = 0;
            i = row;
            j = col;
            while (i < mat.Length && j < mat[i].Length)
            {
                mat[i][j] = diagEle[k];
                k++;
                i++;
                j++;
            }
            return mat;
        }

        private void btn_Max_Area_of_Island_Click(object sender, EventArgs e)
        {
            /*
                You are given an m x n binary matrix grid. An island is a group of 1's (representing land) connected 4-directionally (horizontal or vertical.) You may assume all four edges of the grid are surrounded by water.
                The area of an island is the number of cells with a value 1 in the island.
                Return the maximum area of an island in grid. If there is no island, return 0.
                Input: grid =
                [

			                  [0,0,1,0,0,0,0,1,0,0,0,0,0],
			                  [0,0,0,0,0,0,0,1,1,1,0,0,0],
			                  [0,1,1,0,1,0,0,0,0,0,0,0,0],
			                  [0,1,0,0,1,1,0,0,1,0,1,0,0],
			                  [0,1,0,0,1,1,0,0,1,1,1,0,0],
			                  [0,0,0,0,0,0,0,0,0,0,1,0,0],
			                  [0,0,0,0,0,0,0,1,1,1,0,0,0],
			                  [0,0,0,0,0,0,0,1,1,0,0,0,0]
                ]

                Output: 6
	                Explanation: The answer is not 11, because the island must be connected 4-directionally.

                Example 2:
                Input: grid =
                [
                  [0,0,0,0,0,0,0,0]
                ]

                Output: 0
                Constraints:
	                m == grid.length
	                n == grid[i].length
	                1 <= m, n <= 50
	                grid[i][j] is either 0 or 1.


            Time Complexity         : O(RC)
            Space Complexity         : O(1)

             */


            StringBuilder result = new StringBuilder();
            List<Common> inputs = new List<Common>();


            inputs.Add(new Common()
            {
                Input = new int[][] {
                                          new int[]{0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
                                          new int[]{0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0},
                                          new int[] { 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                                          new int[]{0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0 },
                                          new int[]{0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 0 },
                                          new int[]{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                                          new int[]{0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 },
                                          new int[]{0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 }
                                    }
            });

            inputs.Add(new Common()
            {
                Input = new int[][] {
                                          new int[]{0,0,0,0,0,0,0,0 }
                                    }
            });



            foreach (var input in inputs)
            {
                result.AppendLine($"Max Area of Island for the given input array : {Environment.NewLine} {this.PrintJaggedArray(input.Input)} {Environment.NewLine} {this.MaxAreaOfIsland(input.Input)}");

            }

            MessageBox.Show(result.ToString());
        }

        public int MaxAreaOfIsland(int[][] grid)
        {
            var largestIsland = 0;
            for (var i = 0; i < grid.Length; i++)
            {
                for (var j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        var islandSize = FindIslandSize(grid, i, j);
                        if (islandSize > largestIsland) largestIsland = islandSize;
                    }
                }
            }
            return largestIsland;
        }

       public  int FindIslandSize(int[][] grid, int i, int j)
        {
            var islandSize = 0;
            if (j < 0 || i < 0 || i >= grid.Length || j >= grid[i].Length)            
                return 0;
            if (grid[i][j] == 1)
            {
                islandSize++;
                grid[i][j] = 0;
                islandSize += FindIslandSize(grid, i + 1, j);
                islandSize += FindIslandSize(grid, i - 1, j);
                islandSize += FindIslandSize(grid, i, j + 1);
                islandSize += FindIslandSize(grid, i, j - 1);
            }



            return islandSize;

        }

        private void btn_Maximum_Units_on_a_Truck_Click(object sender, EventArgs e)
        {
            /*
            
                    You are assigned to put some amount of boxes onto one truck. You are given a 2D array boxTypes, where boxTypes[i] = [numberOfBoxesi, numberOfUnitsPerBoxi]:

                    numberOfBoxesi is the number of boxes of type i.
                    numberOfUnitsPerBoxi is the number of units in each box of the type i.
                    You are also given an integer truckSize, which is the maximum number of boxes that can be put on the truck. You can choose any boxes to put on the truck as long as the number of boxes does not exceed truckSize.

                    Return the maximum total number of units that can be put on the truck.

 

                    Example 1:

                    Input: boxTypes = [[1,3],[2,2],[3,1]], truckSize = 4
                    Output: 8
                    Explanation: There are:
                    - 1 box of the first type that contains 3 units.
                    - 2 boxes of the second type that contain 2 units each.
                    - 3 boxes of the third type that contain 1 unit each.
                    You can take all the boxes of the first and second types, and one box of the third type.
                    The total number of units will be = (1 * 3) + (2 * 2) + (1 * 1) = 8.
                    Example 2:

                    Input: boxTypes = [[5,10],[2,5],[4,7],[3,9]], truckSize = 10
                    Output: 91
 

                    Constraints:

                    1 <= boxTypes.length <= 1000
                    1 <= numberOfBoxesi, numberOfUnitsPerBoxi <= 1000
                    1 <= truckSize <= 106
                       Hide Hint #1  
                    If we have space for at least one box, it's always optimal to put the box with the most units.
                       Hide Hint #2  
                    Sort the box types with the number of units per box non-increasingly.
                       Hide Hint #3  
                    Iterate on the box types and take from each type as many as you can.
             

                    TC  : O(NLogN)
                    SC  : O(1)
             
             */



            StringBuilder result = new StringBuilder();
            List<Common> inputs = new List<Common>();


            inputs.Add(new Common()
            {
                Input = new int[][] {
                                          new int[]{1,3},
                                          new int[]{2,2},
                                          new int[]{3,1}

                                    },N= 4
            });

            inputs.Add(new Common()
            {
                Input = new int[][] {
                                          new int[]{ 5, 10 },
                                          new int[]{ 2,5 },
                                          new int[]{ 4,7 },
                                          new int[]{ 3,9 }
                                    },
                N = 10
            });



            foreach (var input in inputs)
            {
                result.AppendLine($"Maximum Units on a Truck : {Environment.NewLine} {this.PrintJaggedArray(input.Input)} {Environment.NewLine} {this.MaximumUnits(input.Input, input.N)}");

            }

            MessageBox.Show(result.ToString());
        }

        public int MaximumUnits(int[][] boxTypes, int truckSize)
        {

            if (boxTypes == null || boxTypes.Length == 1)
                return 0;

            Array.Sort(boxTypes, (x, y) => y[1] - x[1]);

            int maxUnits= 0;
            int noOfBoxes = 0;

            foreach(var i in boxTypes)
            {

                if (noOfBoxes + i[0] <= truckSize)
                {
                    noOfBoxes += i[0];
                    maxUnits += (i[0] * i[1]);
                }
                else
                {
                    maxUnits += (truckSize - noOfBoxes) * i[1];
                    return maxUnits;
                }                
            }

            return maxUnits;
        }

        private void btn_Reshape_the_Matrix_Click(object sender, EventArgs e)
        {
       
            /*
            
                In MATLAB, there is a handy function called reshape which can reshape an m x n matrix into a new one with a different size r x c keeping its original data.

                You are given an m x n matrix mat and two integers r and c representing the row number and column number of the wanted reshaped matrix.

                The reshaped matrix should be filled with all the elements of the original matrix in the same row-traversing order as they were.

                If the reshape operation with given parameters is possible and legal, output the new reshaped matrix; Otherwise, output the original matrix.
 
                Example 1:
                Input: mat = [[1,2],[3,4]], r = 1, c = 4
                Output: [[1,2,3,4]]
                
                Example 2:
                Input: mat = [[1,2],[3,4]], r = 2, c = 4
                Output: [[1,2],[3,4]] 

                Constraints:
                m == mat.length
                n == mat[i].length
                1 <= m, n <= 100
                -1000 <= mat[i][j] <= 1000
                1 <= r, c <= 300
                
                Hide Hint #1  
                Do you know how 2d matrix is stored in 1d memory? Try to map 2-dimensions into one.
                
                Hide Hint #2  
                M[i][j]=M[n*i+j] , where n is the number of cols. This is the one way of converting 2-d indices into one 1-d index. Now, how will you convert 1-d index into 2-d indices?
                
                Hide Hint #3  
                Try to use division and modulus to convert 1-d index into 2-d indices.
                
                Hide Hint #4  
                M[i] => M[i/n][n%i] Will it result in right mapping? Take some example and check this formula.

                TC  : O(RC)
                SC  : O(RC)
             
             */

            StringBuilder result = new StringBuilder();
            List<Common> inputs = new List<Common>();


            inputs.Add(new Common()
            {
                Input = new int[][] {
                                          new int[]{1,2},                                          
                                          new int[]{3,4}

                                    },
                        R = 1,
                        C = 4
            });

            inputs.Add(new Common()
            {
                Input = new int[][] {
                                          new int[]{1,2},
                                          new int[]{3,4}

                                    },
                R = 2,
                C = 4
            });



            foreach (var input in inputs)
            {
                result.AppendLine($"Reshape the Matrix for the given matrix  : {Environment.NewLine} {this.PrintJaggedArray(input.Input)} {Environment.NewLine} for the Row :{input.R} and Column: {input.C} is {Environment.NewLine} {this.PrintJaggedArray(this.MatrixReshape(input.Input, input.R, input.C))}");

            }

            MessageBox.Show(result.ToString());

            
        }


        public int[][] MatrixReshape(int[][] mat, int r, int c)
        {
            if (mat == null || mat.Length == 0)
                return mat;

            int m = mat.Length;
            int n = mat[0].Length;
            int sr = 0;
            int sc = 0;

            if (m * n != r * c)
                return mat;

            int[][] result = new int[r][];
            for (int i = 0; i < r; i++)
                result[i] = new int[c];

            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                {
                    if (sc >= c)
                    {
                        sc = 0;
                        sr++;
                    }

                    result[sr][sc] = mat[i][j];
                    sc++;

                }

            return result;

        }

        private void btn_Kth_Smallest_Element_in_a_Sorted_Matrix_Click(object sender, EventArgs e)
        {
            /*
                Given an n x n matrix where each of the rows and columns are sorted in ascending order, return the kth smallest element in the matrix.

                Note that it is the kth smallest element in the sorted order, not the kth distinct element.

 

                Example 1:

                Input: matrix = [[1,5,9],[10,11,13],[12,13,15]], k = 8
                Output: 13
                Explanation: The elements in the matrix are [1,5,9,10,11,12,13,13,15], and the 8th smallest number is 13
                Example 2:

                Input: matrix = [[-5]], k = 1
                Output: -5
 

                Constraints:

                n == matrix.length
                n == matrix[i].length
                1 <= n <= 300
                -109 <= matrix[i][j] <= 109
                All the rows and columns of matrix are guaranteed to be sorted in non-decreasing order.
                1 <= k <= n2

                TC  :   NLOGK
                SC  :   O(1)
             */



            StringBuilder result = new StringBuilder();
            List<Common> inputs = new List<Common>();


            inputs.Add(new Common()
            {
                Input = new int[][] {
                                          new int[]{1,5,9},
                                          new int[]{ 10, 11, 13 },
                                          new int[]{ 12,13,15 }                                          
                                    },C = 8

            });

            inputs.Add(new Common()
            {
                Input = new int[][] {
                                          new int[]{-5}                                          
                                    },C = 1
            });

            inputs.Add(new Common()
            {
                Input = new int[][] {
                                          new int[]{1,5,9},
                                          new int[]{ 10, 11, 13 },
                                          new int[]{ 12,13,15 }
                                    },
                C = 7

            });



            foreach (var input in inputs)
            {
                result.AppendLine($"Kth Smallest Element in a Sorted Matrix for the given matrix  : {Environment.NewLine} {this.PrintJaggedArray(input.Input)} {Environment.NewLine} for the given K :{input.C} is {this.KthSmallest(input.Input, input.C)}");
            }

            MessageBox.Show(result.ToString());
        }

        public int KthSmallest(int[][] matrix, int k)
        {
            int n = matrix.Length;
            int left = matrix[0][0], right = matrix[n - 1][n - 1];
            while (left < right)
            {
                int mid = (left + right) / 2; // 13 + 13
                int count = UpperBound(matrix, mid);
                if (count >= k)
                    right = mid;
                else
                    left = mid + 1;
            }
            return left;
        }

        public int UpperBound(int[][] matrix, int target)
        {   
            int n = matrix.Length;
            int i = n - 1, j = 0, count = 0;
            while (i >= 0 && j < n)
            {
                if (matrix[i][j] <= target)
                {
                    count += i + 1;
                    j++;
                }
                else
                    i--;

            }
            return count;

        }

        private void btn_01_Matrix_Click(object sender, EventArgs e)
        {
            /*
             Given an m x n binary matrix mat, return the distance of the nearest 0 for each cell.
                
                The distance between two adjacent cells is 1.

 

                Example 1:


                Input: mat = [[0,0,0],[0,1,0],[0,0,0]]
                Output: [[0,0,0],[0,1,0],[0,0,0]]
                Example 2:


                Input: mat = [[0,0,0],[0,1,0],[1,1,1]]
                Output: [[0,0,0],[0,1,0],[1,2,1]]
 

                Constraints:

                m == mat.length
                n == mat[i].length
                1 <= m, n <= 104
                1 <= m * n <= 104
                mat[i][j] is either 0 or 1.
                There is at least one 0 in mat.

                TC  :   O(RC)
                SC  :   O(RC)
             
             */

            StringBuilder result = new StringBuilder();
            List<Common> inputs = new List<Common>();


            inputs.Add(new Common()
            {
                Input = new int[][] {
                                          new int[]{0,0,0},
                                          new int[]{ 0,1,0 },
                                          new int[]{ 0, 0, 0 }
                                    }

            });


            inputs.Add(new Common()
            {
                Input = new int[][] {
                                          new int[]{ 0, 0, 0 },
                                          new int[]{ 0, 1, 0 },
                                          new int[]{ 1, 1, 1 }
                                    }

            });



            foreach (var input in inputs)
            {
                result.AppendLine($"01 Matrix for the given matrix  : {Environment.NewLine} {this.PrintJaggedArray(input.Input)} {Environment.NewLine} is {Environment.NewLine}  {this.PrintJaggedArray(this.UpdateMatrix(input.Input))}");
            }

            MessageBox.Show(result.ToString());
        }

        public int[][] UpdateMatrix(int[][] mat)
        {
            if (mat == null || mat.Length == 0)
                return mat;


            Queue<int[]> q = new Queue<int[]>();

            int rl = mat.Length;
            int cl = mat[0].Length;
            int l = 0;
            int size = 0;
            int r = 0;
            int c = 0;

            for (r = 0; r < rl; r++)
                for (c = 0; c < cl; c++)
                    if (mat[r][c] == 0)
                        q.Enqueue(new int[] { r, c });
                    else
                        mat[r][c] = -1;


            while (q.Count > 0)
            {
                size = q.Count;
                l++;
                while(size >0)
                {
                    int[] rc = q.Dequeue();
                    r = rc[0];
                    c = rc[1];
                    
                    if (c-1 >=0 && mat[r][c-1] == -1)
                    {
                        q.Enqueue(new int[]{r,c-1 });
                        mat[r][c - 1] = l;
                    }

                    if (c + 1 < cl && mat[r][c + 1] == -1)
                    {
                        q.Enqueue(new int[] { r, c + 1 });
                        mat[r][c + 1] = l;
                    }

                    if (r - 1 >= 0 && mat[r-1][c] == -1)
                    {
                        q.Enqueue(new int[] { r-1, c });
                        mat[r-1][c] = l;
                    }

                    if (r + 1 < rl && mat[r+1][c] == -1)
                    {
                        q.Enqueue(new int[] { r+1, c});
                        mat[r+1][c] = l;
                    }

                    size--;

                }

            }


            return mat;


        }

        private void btn_Set_Matrix_Zeroes_Click(object sender, EventArgs e)
        {
            
            /*
            Given an m x n integer matrix matrix, if an element is 0, set its entire row and column to 0's, and return the matrix.

            You must do it in place.

 

            Example 1:


            Input: matrix = [[1,1,1],[1,0,1],[1,1,1]]
            Output: [[1,0,1],[0,0,0],[1,0,1]]
            Example 2:


            Input: matrix = [[0,1,2,0],[3,4,5,2],[1,3,1,5]]
            Output: [[0,0,0,0],[0,4,5,0],[0,3,1,0]]
 

            Constraints:

            m == matrix.length
            n == matrix[0].length
            1 <= m, n <= 200
            -231 <= matrix[i][j] <= 231 - 1
 

            Follow up:

            A straightforward solution using O(mn) space is probably a bad idea.
            A simple improvement uses O(m + n) space, but still not the best solution.
            Could you devise a constant space solution?
             
            Hide Hint #1  
            If any cell of the matrix has a zero we can record its row and column number using additional memory. But if you don't want to use extra memory then you can manipulate the array instead. i.e. simulating exactly what the question says.
            
            Hide Hint #2  
            Setting cell values to zero on the fly while iterating might lead to discrepancies. What if you use some other integer value as your marker? There is still a better approach for this problem with 0(1) space.
            
            Hide Hint #3  
            We could have used 2 sets to keep a record of rows/columns which need to be set to zero. But for an O(1) space solution, you can use one of the rows and and one of the columns to keep track of this information.
            
            Hide Hint #4  
            We can use the first cell of every row and column as a flag. This flag would determine whether a row or column has been set to zero.

            TC  : O(MN)
            SC  : O(1)
             
             */



            StringBuilder result = new StringBuilder();
            List<Common> inputs = new List<Common>();

            inputs.Add(new Common()
            {
                Input = new int[][] {
                                          new int[]{1},
                                          new int[]{ 0 }
                                    }

            });
            
            inputs.Add(new Common()
            {
                Input = new int[][] {
                                          new int[]{1,1,1},
                                          new int[]{ 1,0,1 },
                                          new int[]{ 1, 1, 1 }
                                    }

            });


            inputs.Add(new Common()
            {
                Input = new int[][] {
                                          new int[]{ 0,1,2,0 },
                                          new int[]{ 3,4,5,2 },
                                          new int[]{ 1, 3, 1, 5 }
                                    }

            });



            foreach (var input in inputs)
            {
                result.AppendLine($"Set Zeroes for the given matrix  : {Environment.NewLine} {this.PrintJaggedArray(input.Input)} is {Environment.NewLine}");
                  SetZeroes(input.Input);
                result.AppendLine($"{ this.PrintJaggedArray(input.Input)}");

                //Refer SetZeroes_Others
            }

            MessageBox.Show(result.ToString());
        }


        public void SetZeroes(int[][] matrix)
        {
            if (matrix == null || matrix.Length == 0)
                return;
          
            bool isFirstRowZero = false;
            bool isFirstColZero = false;

            int rl = matrix.Length;
            int cl = matrix[0].Length;

            for (int r = 0; r < rl; r++)
                for (int c = 0; c < cl; c++)
                {
                    if (matrix[r][c] == 0)
                    {
                        matrix[r][0] = 0;
                        matrix[0][c] = 0;

                        if (r==0)
                            isFirstRowZero = true;

                        if (c == 0)
                            isFirstColZero = true;
                    }
                }

            for (int r = 1; r < rl; r++)
                if (matrix[r][0] == 0)                
                    FillMatrix(matrix, rl, cl, -1, r);
                
                

            for (int c = 0; c < cl; c++)
                if (matrix[0][c] == 0)                
                    FillMatrix(matrix, rl, cl, c, -1);
                    
            
            if (isFirstRowZero)
                FillMatrix(matrix,rl,cl,-1, 0);

            if (isFirstRowZero)
                FillMatrix(matrix, rl, cl, -1, 0);
        }

        private void FillMatrix(int[][] matrix, int rl, int cl, int c, int r)
        {
            if (c > -1)
                for (int ir = 0; ir < rl; ir++)
                    matrix[ir][c] = 0;

            if (r > -1)
                for (int ic = 0; ic < cl; ic++)
                    matrix[r][ic] = 0;
        }


        public void SetZeroes_Others(int[][] matrix)
        {
            bool firstRowZero = false;
            bool firstColumnZero = false;

            for (int y = 0; y < matrix.Length; y++)
            {
                for (int x = 0; x < matrix[y].Length; x++)
                {
                    if (matrix[y][x] == 0)
                    {
                        matrix[0][x] = 0;
                        matrix[y][0] = 0;

                        if (x == 0)
                        {
                            firstColumnZero = true;
                        }
                        if (y == 0)
                        {
                            firstRowZero = true;
                        }
                    }
                }
            }

            for (int y = 1; y < matrix.Length; y++)
            {
                if (matrix[y][0] == 0)
                {
                    for (int x = 0; x < matrix[y].Length; x++)
                    {
                        matrix[y][x] = 0;
                    }
                }
            }

            for (int x = 1; x < matrix[0].Length; x++)
            {
                if (matrix[0][x] == 0)
                {
                    for (int y = 0; y < matrix.Length; y++)
                    {
                        matrix[y][x] = 0;
                    }
                }
            }

            // Clear rows + columns
            if (firstColumnZero)
            {
                for (int y = 1; y < matrix.Length; y++)
                {
                    matrix[y][0] = 0;
                }
            }

            if (firstRowZero)
            {
                for (int x = 1; x < matrix[0].Length; x++)
                {
                    matrix[0][x] = 0;
                }
            }
        }

        private void btn_Valid_Sudoku_Click(object sender, EventArgs e)
        {
            /*
                Determine if a 9 x 9 Sudoku board is valid. Only the filled cells need to be validated according to the following rules:

                Each row must contain the digits 1-9 without repetition.
                Each column must contain the digits 1-9 without repetition.
                Each of the nine 3 x 3 sub-boxes of the grid must contain the digits 1-9 without repetition.
                Note:

                A Sudoku board (partially filled) could be valid but is not necessarily solvable.
                Only the filled cells need to be validated according to the mentioned rules.
 

                Example 1:


                Input: board = 
                [["5","3",".",".","7",".",".",".","."]
                ,["6",".",".","1","9","5",".",".","."]
                ,[".","9","8",".",".",".",".","6","."]
                ,["8",".",".",".","6",".",".",".","3"]
                ,["4",".",".","8",".","3",".",".","1"]
                ,["7",".",".",".","2",".",".",".","6"]
                ,[".","6",".",".",".",".","2","8","."]
                ,[".",".",".","4","1","9",".",".","5"]
                ,[".",".",".",".","8",".",".","7","9"]]
                Output: true
                Example 2:

                Input: board = 
                [["8","3",".",".","7",".",".",".","."]
                ,["6",".",".","1","9","5",".",".","."]
                ,[".","9","8",".",".",".",".","6","."]
                ,["8",".",".",".","6",".",".",".","3"]
                ,["4",".",".","8",".","3",".",".","1"]
                ,["7",".",".",".","2",".",".",".","6"]
                ,[".","6",".",".",".",".","2","8","."]
                ,[".",".",".","4","1","9",".",".","5"]
                ,[".",".",".",".","8",".",".","7","9"]]
                Output: false
                Explanation: Same as Example 1, except with the 5 in the top left corner being modified to 8. Since there are two 8's in the top left 3x3 sub-box, it is invalid.
 

                Constraints:

                board.length == 9
                board[i].length == 9
                board[i][j] is a digit or '.'.

                TC  : O(9*9)
                SC  : O(9*9)
             
             */


            StringBuilder result = new StringBuilder();
            List<string[][]> inputs = new List<string[][]>();

            inputs.Add(new string[][]   {
                            new string[] { "8", "3", ".", ".", "7", ".", ".", ".", "." },
                            new string[] {"6",".",".","1","9","5",".",".","." },
                            new string[] {".", "9", "8", ".", ".", ".", ".", "6", "." },
                            new string[] {"8", ".", ".", ".", "6", ".", ".", ".", "3" },
                            new string[] {"4", ".", ".", "8", ".", "3", ".", ".", "1" },
                            new string[] {"7", ".", ".", ".", "2", ".", ".", ".", "6"},
                            new string[] {".", "6", ".", ".", ".", ".", "2", "8", "." },
                            new string[] {".", ".", ".", "4", "1", "9", ".", ".", "5" },
                            new string[] {".", ".", ".", ".", "8", ".", ".", "7", "9" }
                                    }
                       );
            

       



            foreach (var input in inputs)
            {
                result.AppendLine($"The Given Sudoku : {Environment.NewLine} {this.PrintJaggedArray_String(input)} is {Environment.NewLine} {(IsValidSudoku(input) ? "" : " not")} valid");
               

             
            }

            MessageBox.Show(result.ToString());

        }

        public bool IsValidSudoku(string[][] board)
        {
            if (board == null)
                return false;

            HashSet<string> dict = new HashSet<string>();

            for (int r = 0; r < board.Length; r++)
                for (int c = 0; c < board[0].Length; c++)
                {
                    if (board[r][c] != ".")
                    {
                        if ((dict.Contains($"{board[r][c]}_R_{r}")) ||
                            (dict.Contains($"{board[r][c]}_C_{c}")) ||
                            (dict.Contains($"{board[r][c]}_B_{r / 3}_{c / 3}")))
                            return false;
                        else
                        {
                            dict.Add($"{board[r][c]}_R_{r}");
                            dict.Add($"{board[r][c]}_C_{c}");
                            dict.Add($"{board[r][c]}_B_{r / 3}_{c / 3}");
                        }
                    }
                }


            return true;

        }

        private void btn_Sudoku_Solver_Click(object sender, EventArgs e)
        {
            /*
             
            Write a program to solve a Sudoku puzzle by filling the empty cells.

            A sudoku solution must satisfy all of the following rules:

            Each of the digits 1-9 must occur exactly once in each row.
            Each of the digits 1-9 must occur exactly once in each column.
            Each of the digits 1-9 must occur exactly once in each of the 9 3x3 sub-boxes of the grid.
            The '.' character indicates empty cells.

 

            Example 1:


            Input: board = [["5","3",".",".","7",".",".",".","."],["6",".",".","1","9","5",".",".","."],[".","9","8",".",".",".",".","6","."],["8",".",".",".","6",".",".",".","3"],["4",".",".","8",".","3",".",".","1"],["7",".",".",".","2",".",".",".","6"],[".","6",".",".",".",".","2","8","."],[".",".",".","4","1","9",".",".","5"],[".",".",".",".","8",".",".","7","9"]]
            Output: [["5","3","4","6","7","8","9","1","2"],["6","7","2","1","9","5","3","4","8"],["1","9","8","3","4","2","5","6","7"],["8","5","9","7","6","1","4","2","3"],["4","2","6","8","5","3","7","9","1"],["7","1","3","9","2","4","8","5","6"],["9","6","1","5","3","7","2","8","4"],["2","8","7","4","1","9","6","3","5"],["3","4","5","2","8","6","1","7","9"]]
            Explanation: The input board is shown above and the only valid solution is shown below:


 

            Constraints:

            board.length == 9
            board[i].length == 9
            board[i][j] is a digit or '.'.
            It is guaranteed that the input board has only one solution.

            TC : O(N ^ M) where N is the number of possiblities and M is the number of available spots
            SP : O(M) where M is the number of available shots to be filled

             */


            StringBuilder result = new StringBuilder();
            List<char[][]> inputs = new List<char[][]>();

            inputs.Add(new char[][]   {
                            new char[] {'5','3','.','.','7','.','.','.','.'},
                            new char[] {'6','.','.','1','9','5','.','.','.'},
                            new char[] {'.','9','8','.','.','.','.','6','.'},
                            new char[] {'8','.','.','.','6','.','.','.','3'},
                            new char[] {'4','.','.','8','.','3','.','.','1'},
                            new char[] {'7','.','.','.','2','.','.','.','6'},
                            new char[] {'.','6','.','.','.','.','2','8','.'},
                            new char[] {'.','.','.','4','1','9','.','.','5'},
                            new char[] {'.','.','.','.','8','.','.','7','9'}
                                    }
                       );

            foreach (var input in inputs)
            {
                
                result.AppendLine($"Sudoku Solver for the Given Sudoku : {Environment.NewLine} {this.PrintJaggedArray_char(input)} is {Environment.NewLine}");
                SolveSudoku(input);
                result.AppendLine($"{this.PrintJaggedArray_char(input)}");


            }

            MessageBox.Show(result.ToString());
        }

  
        public void SolveSudoku(char[][] board)
        {
            if (board == null)
                return;

            SolveSudokuPuzzle(board);
        }

        public bool SolveSudokuPuzzle(char[][] board)
        {
            for(int r = 0; r < 9; r++)
            { 
                for (int c = 0; c < 9; c++)
                {
                    if (board[r][c] == '.')
                    {
                        for(char ch = '1'; ch <= '9'; ch++)
                        {
                            if (IsValidSudokoRowCol(board, r,c, ch))
                            {
                                board[r][c] = ch;
                                if (SolveSudokuPuzzle(board))
                                    return true;                              
                               board[r][c] = '.';
                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        }

        public bool IsValidSudokoRowCol(char[][] board, int row, int col, char c )
        {
            int nR = (row / 3) * 3;
            int nC = (col/ 3) * 3;

            for(int i = 0;i < 9; i++)
            {
                if (board[row][i] == c) return false;
                if (board[i][col] == c) return false;
                if (board[nR + (i / 3)][nC + (i % 3)] == c) return false;
            }

            return true;
        }

        private void btn_Range_Addition_II_Click(object sender, EventArgs e)
        {
            /*
               You are given an m x n matrix M initialized with all 0's and an array of operations ops, where ops[i] = [ai, bi] means M[x][y] should be incremented by one for all 0 <= x < ai and 0 <= y < bi.

               Count and return the number of maximum integers in the matrix after performing all the operations.


               Example 1:

                   0   0   0           1   1   0           2   2   1
                   0   0   0           1   1   0           2   2   1
                   0   0   0           0   0   0           1   1   1


               Input: m = 3, n = 3, ops = [[2,2],[3,3]]
               Output: 4
               Explanation: The maximum integer in M is 2, and there are four of it in M. So return 4.
               Example 2:

               Input: m = 3, n = 3, ops = [[2,2],[3,3],[3,3],[3,3],[2,2],[3,3],[3,3],[3,3],[2,2],[3,3],[3,3],[3,3]]
               Output: 4
               Example 3:

               Input: m = 3, n = 3, ops = []
               Output: 9


               Constraints:

               1 <= m, n <= 4 * 104
               0 <= ops.length <= 104
               ops[i].length == 2
               1 <= ai <= m
               1 <= bi <= n

                TC : O(N) where N s the number of operation for the given matrix
                SC : O(1)
            */



            StringBuilder result = new StringBuilder();            
            List<Common> inputs = new List<Common>();

            inputs.Add(new Common()
            {
                Input = new int[][] {
                                          new int[]{2,2},
                                          new int[]{ 3,3 }
                                    }, R = 3, C = 3

            });


            foreach (var input in inputs)
            {
                result.AppendLine($"Range Addition II for the given input Matrix Row :{input.R} and Column :{input.C}  for the given Operations : {Environment.NewLine} {this.PrintJaggedArray(input.Input)} is {Environment.NewLine} {MaxCount(input.R, input.C, input.Input)}");

            }

            MessageBox.Show(result.ToString());
        }


        public int MaxCount(int m, int n, int[][] ops)
        {

            if (ops == null || ops.Length == 0)
                return m * n;

            int minRow = m;
            int minCol = n;
            for (int i = 0; i < ops.Length; i++)
            {
                minRow = Math.Min(ops[i][0], minRow);
                minCol = Math.Min(ops[i][1], minCol);
            }

            return minRow * minCol;
        }

        private void btn_Find_Winner_on_a_Tic_Tac_Toe_Game_Click(object sender, EventArgs e)
        {

            Guid t = Guid.NewGuid();
            MessageBox.Show(t.GetHashCode().ToString());

            /*
                    Tic-tac-toe is played by two players A and B on a 3 x 3 grid.

                    Here are the rules of Tic-Tac-Toe:

                    Players take turns placing characters into empty squares (" ").
                    The first player A always places "X" characters, while the second player B always places "O" characters.
                    "X" and "O" characters are always placed into empty squares, never on filled ones.
                    The game ends when there are 3 of the same (non-empty) character filling any row, column, or diagonal.
                    The game also ends if all squares are non-empty.
                    No more moves can be played if the game is over.
                    Given an array moves where each element is another array of size 2 corresponding to the row and column of the grid where they mark their respective character in the order in which A and B play.

                    Return the winner of the game if it exists (A or B), in case the game ends in a draw return "Draw", if there are still movements to play return "Pending".

                    You can assume that moves is valid (It follows the rules of Tic-Tac-Toe), the grid is initially empty and A will play first.

 

                    Example 1:

                    Input: moves = [[0,0],[2,0],[1,1],[2,1],[2,2]]
                    Output: "A"
                    Explanation: "A" wins, he always plays first.
                    "X  "    "X  "    "X  "    "X  "    "X  "
                    "   " -> "   " -> " X " -> " X " -> " X "
                    "   "    "O  "    "O  "    "OO "    "OOX"
                    Example 2:

                    Input: moves = [[0,0],[1,1],[0,1],[0,2],[1,0],[2,0]]
                    Output: "B"
                    Explanation: "B" wins.
                    "X  "    "X  "    "XX "    "XXO"    "XXO"    "XXO"
                    "   " -> " O " -> " O " -> " O " -> "XO " -> "XO " 
                    "   "    "   "    "   "    "   "    "   "    "O  "
                    Example 3:

                    Input: moves = [[0,0],[1,1],[2,0],[1,0],[1,2],[2,1],[0,1],[0,2],[2,2]]
                    Output: "Draw"
                    Explanation: The game ends in a draw since there are no moves to make.
                    "XXO"
                    "OOX"
                    "XOX"
                    Example 4:

                    Input: moves = [[0,0],[1,1]]
                    Output: "Pending"
                    Explanation: The game has not finished yet.
                    "X  "
                    " O "
                    "   "
 

                    Constraints:

                    1 <= moves.length <= 9
                    moves[i].length == 2
                    0 <= moves[i][j] <= 2
                    There are no repeated elements on moves.
                    moves follow the rules of tic tac toe.
                       Hide Hint #1  
                    It's straightforward to check if A or B won or not, check for each row/column/diag if all the three are the same.
                       Hide Hint #2  
                    Then if no one wins, the game is a draw iff the board is full, i.e. moves.length = 9 otherwise is pending.

                    TC  :   O(N)
                    SC  :   O(3*3)

             */


            StringBuilder result = new StringBuilder();
            List<Common> inputs = new List<Common>();

            inputs.Add(new Common()
            {
                Input = new int[][] {
                                          new int[]{0,0},
                                          new int[]{ 2, 0 },
                                          new int[]{ 1, 1 },
                                          new int[]{ 2, 1 },
                                          new int[]{ 2, 2 },
                                    }

            });

            inputs.Add(new Common()
            {
                Input = new int[][] {
                                          new int[]{0,0},                                          
                                          new int[]{ 1, 1 },
                                          new int[]{ 0, 1 },
                                          new int[]{ 0, 2 },
                                          new int[]{ 1, 0 },
                                          new int[]{ 2, 0 },
                                    }

            });

            inputs.Add(new Common()
            {
                Input = new int[][] {
                                          new int[]{0,0},
                                          new int[]{ 1, 1 },
                                          new int[]{ 2, 0 },
                                          new int[]{ 1, 0 },
                                          new int[]{ 1, 2 },
                                          new int[]{ 2, 1 },
                                          new int[]{ 0, 1 },
                                          new int[]{ 0, 2 },
                                          new int[]{ 2, 2 }
                                    }

            });


            inputs.Add(new Common()
            {
                Input = new int[][] {
                                          new int[]{0,0},                                          
                                          new int[]{ 1, 1 }
                                     
                                    }

            });
            foreach (var input in inputs)
            {
                result.AppendLine($"Winner on a Tic Tac Toe Game for the given moves {this.PrintJaggedArray(input.Input)} is {Tictactoe(input.Input)}");

            }

            MessageBox.Show(result.ToString());
        }

        public string Tictactoe(int[][] moves)
        {
            if (moves == null || moves.Length == 0)
                return null;

            char[][] board = new char[3][];
            for (int r = 0; r < 3; r++)
                board[r] = new char[3] { '.', '.', '.' };

            for (int i = 0; i < moves.Length; i++)
                board[moves[i][0]][moves[i][1]] = (i % 2 == 0 ? 'X' : 'O');


            /*StringBuilder print = new StringBuilder();
            for(int r= 0; r< 3; r++)
            {            
              for(int c = 0; c < 3; c++)                    
                  print.Append($"{board[r][c]} \t");
             print.AppendLine()   ;
            }

          Console.WriteLine(print);*/


            return GetStatus(board);

        }

        public string GetStatus(char[][] board)
        {

            int a = 0;
            int b = 0;
            for (int c = 0; c < 3; c++)
            {
                a = 0;
                b = 0;
                for (int r = 0; r < 3; r++)
                {
                    if (board[r][c] == 'X')
                        a++;
                    if (board[r][c] == 'O')
                        b++;
                }

                if (a == 3)
                    return "A";
                if (b == 3)
                    return "B";

            }

            a = 0;
            b = 0;
            for (int r = 0; r < 3; r++)
            {
                a = 0;
                b = 0;
                for (int c = 0; c < 3; c++)
                {
                    if (board[r][c] == 'X')
                        a++;
                    if (board[r][c] == 'O')
                        b++;
                }

                if (a == 3)
                    return "A";
                if (b == 3)
                    return "B";
            }

            if ((board[0][0] == 'X' && board[1][1] == 'X' && board[2][2] == 'X') ||
               (board[0][2] == 'X' && board[1][1] == 'X' && board[2][0] == 'X'))
                return "A";

            if ((board[0][0] == 'O' && board[1][1] == 'O' && board[2][2] == 'O') ||
               (board[0][2] == 'O' && board[1][1] == 'O' && board[2][0] == 'O'))
                return "B";

            a = 0;
            for (int r = 0; r < 3; r++)
                for (int c = 0; c < 3; c++)
                    if (board[r][c] == 'X' || board[r][c] == 'O')
                        a++;

            if (a != 9)
                return "Pending";

            return "Draw";

        }


    }

}
