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


        public class Judge
        {
            public int[][] PersonJude;
            public int NoOfPeople;
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
            List<Judge> inputs = new List<Judge>();
            inputs.Add(new Judge() { PersonJude = new int[][] { new int[] { 1, 2 } }, NoOfPeople = 2 });

            inputs.Add(new Judge()
            {
                PersonJude = new int[][] {
                                     new int[] {1, 3 },
                                     new int[] {2, 3 }
                                    },
                NoOfPeople = 3
            });

            inputs.Add(new Judge()
            {
                PersonJude = new int[][] {
                                     new int[] { 1, 3 },
                                     new int[] { 2, 3 },
                                     new int[] { 3, 1 }
                                    },
                NoOfPeople = 3
            });

            inputs.Add(new Judge()
            {
                PersonJude = new int[][] {
                                     new int[] { 1, 2 },
                                     new int[] { 2, 3 }
                                    },
                NoOfPeople = 3
            });

            inputs.Add(new Judge()
            {
                PersonJude = new int[][] {
                                     new int[] { 1, 3 },
                                     new int[] { 1, 4 },
                                     new int[] { 2, 3 },
                                     new int[] { 2, 4 },
                                     new int[] { 4, 1 }
                                    },
                NoOfPeople = 4
            });

            inputs.Add(new Judge()
            {
                PersonJude = new int[][] {
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
                NoOfPeople = 11
            });


            foreach (var input in inputs)
            {
                result.AppendLine($"The Judge is { this.FindJudge(input.NoOfPeople, input.PersonJude) } for the given inputs{Environment.NewLine}{this.PrintJaggedArrayForJudeges(input.PersonJude)}");

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
    }
}
