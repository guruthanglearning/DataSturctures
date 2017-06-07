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

    }
}
