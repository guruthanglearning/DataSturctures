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
            //http://www.geeksforgeeks.org/kth-smallest-element-in-a-row-wise-and-column-wise-sorted-2d-array-set-1/
            int[,] input = new int[,] { {10,20,30,40 }, { 15, 25, 35, 45 }, { 25, 29, 37, 48 }, { 32, 33, 39, 50 } };
            int kthValue = kthSmallest(input, 4, 7);
            MessageBox.Show(kthValue.ToString());



        }

        // A utility function to swap two HeapNode items.
        void swap(HeapNode x, HeapNode y)
        {
            int  z = x.value;
            x.value = y.value;
            y.value = z;
        }


        void minHeapify(HeapNode[] harr, int i, int heap_size)
        {
            int l = i * 2 + 1;
            int r = i * 2 + 2;
            int smallest = i;
            if (l < heap_size && harr[l].value < harr[i].value)
                smallest = l;
            if (r < heap_size && harr[r].value < harr[smallest].value)
                smallest = r;
            if (smallest != i)
            {
                swap(harr[i], harr[smallest]);
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
                return int.MaxValue;

            // Create a min heap of elements from first row of 2D array
            HeapNode[] harr = new HeapNode[n];
            for (int i = 0; i < n; i++)
            {
                harr[i] = new HeapNode{ value = mat[0,i], row = 0, column = i };
            }
            buildHeap(harr, n);

            HeapNode hr = new HeapNode();
            for (int i = 0; i < k; i++)
            {
                // Get current heap root
                hr = harr[0];

                // Get next value from column of root's value. If the
                // value stored at root was last value in its column,
                // then assign INFINITE as next value
                int nextval = (hr.row < (n - 1)) ? mat[hr.row + 1,hr.column] : int.MaxValue;

                // Update heap root with next value
                harr[0] = new HeapNode{value= nextval, row= (hr.row) + 1, column = hr.column};

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
                                            {  4, 3, 2, 1 }
                                        };

            int count = 0;
            int i = 0; //starting row
            int j = matrix.GetLength(0); //max columns
            int n = matrix.GetUpperBound(0); // max rows

            while (j >= 0 && i < n)
            {
                if (matrix[i, j] < 0)
                {
                    count += (j + 1);
                    j = matrix.GetLength(0);
                    i++;
                }
                else
                {
                    j--;
                }
            }

            MessageBox.Show($"Total no of negative number in matrix is {count.ToString()} ");

        }

        private void btn_Find_the_largest_square_of_1_in_a_given_matrix_Click(object sender, EventArgs e)
        {
            /*
               Time Complexity is O(n^2) 
               Space Complexity is 4 X 4

            */

            int[,] input = new int[,] {
                                            { 0, 1, 0, 1 },
                                            { 0, 1, 1, 1 },
                                            { 1, 1, 1, 1 },
                                            { 0, 1, 1, 1,}
                                        };

            var cache = input;
            int result = 0;
            for (int i = 1; i <= input.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= input.GetUpperBound(0); j++)
                {
                    if (i > 0 && j > 0)
                    {
                        if (input[i, j] > 0)
                        {
                            cache[i, j] = 1 + Math.Min(Math.Min(cache[i, j - 1], cache[i - 1, j]), cache[i - 1, j - 1]);
                        }
                    }

                    if (cache[i, j] > result)
                        result = cache[i, j];

                }
            }

            MessageBox.Show($"Largest square in the matrix is  {result.ToString()}");

        }
    }
}
