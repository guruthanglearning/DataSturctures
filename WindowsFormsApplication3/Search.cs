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
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }


        private void btn_BinarySearch_Click(object sender, EventArgs e)
        {
            //http://www.geeksforgeeks.org/binary-search/
            //https://en.wikipedia.org/wiki/Binary_search_algorithm
            //Worst -case performance O(log n)
            //Best -case performance O(1)
            //Average performance O(log n)
            //Worst -case space complexity

            int[] input = new int[] {1,2,3,4,5};
            int search = 3;
            MessageBox.Show($"{search} is located in the {binarySearch(input,0, input.Length-1,search)} index of the array input\n" + 
                        $"{ search} is located in the { binarySearchIterative(input, 0, input.Length - 1, search)} index of the array input");

        }

        public int binarySearch(int[] input, int left, int right, int search)
        {

            if (right >=1 && left <= right)
            {
                int mid = (left + right) / 2;
                if (input[mid] == search)
                {
                    return mid;
                }

                if (input[mid] > search)
                {
                    return binarySearch(input, left, mid - 1, search);
                }
                else
                {
                    return binarySearch(input, mid + 1, right, search);
                }

            }

            return -1;

        }

        public int binarySearchIterative(int[] input, int left, int right, int search)
        {
            int result = -1;
            int mid = 0;
            while (left <= right)
            {
                mid = (left + right) / 2;

                if (input[mid]==search)
                {
                    result = mid;
                    break;
                }

                if (input[mid] > search)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            
            return result;
        }

        private void btn_Given_an_split_array_in_the_sorted_order_search_given_value_exists_Click(object sender, EventArgs e)
        {
            StringBuilder output = new StringBuilder();
            List<ArrayContainterForSearch> inputs = new List<ArrayContainterForSearch>();
            //inputs.Add(new ArrayContainterForSearch() { Input = new int[] { 1, 2, 3, 4, 5, 6 }, Search = 6 });
            inputs.Add(new ArrayContainterForSearch() { Input = new int[] { 3, 4, 5, 6, 1, 2 }, Search = 4 });
            //inputs.Add(new ArrayContainterForSearch() { Input = new int[] { 3, 4, 5, 6, 7, 1, 2 }, Search = 3 });
            //inputs.Add(new ArrayContainterForSearch() { Input = new int[] { 5, 6, 7, 8, 9, 10, 1, 2, 3, 4 }, Search = 11 });

            
            int left = 0; int right = 0;
            int mid = 0;
            int pivot = -1;
            int result = -1;
            int[] input = new int[] { };
            int search = 0;
            foreach (ArrayContainterForSearch arrayContainterForSearch in inputs)
            {
                input = arrayContainterForSearch.Input;
                search = arrayContainterForSearch.Search;
                left = 0; right = input.Length - 1;
                pivot = -1;
                if (input[left] > input[right])
                {                    
                    pivot = this.FindPivot(input, 0, input.Length - 1);
                    if (pivot > -1)
                    {
                        result = this.binarySearchIterative(input, left, pivot, search);
                        if (result == -1)
                        {
                            result = this.binarySearchIterative(input, pivot + 1, right, search);
                        }
                    }
                }
                else
                {
                    result = this.binarySearchIterative(input, left, right, search);
                }
                output.Append($"Index of the given number {search} in the given array {string.Join(",",input)} is {result.ToString()}\n");
            }

            MessageBox.Show(output.ToString());

        }

        private int FindPivot (int[] input, int l, int r)
        {
            // 5, 6, 7, 8, 9, 10, 1, 2, 3, 4 
            //if (input.Length > 0 && left <= right)
            //{
            //    int mid = 0;
            //    while(left <= right)
            //    {
            //        // m =7  l = 5 r= 9
            //        mid = (left + right) / 2;
            //        if (input[mid] < input[mid + 1] && input[mid - 1] < input[mid] && input[left] < input[mid])
            //        {
            //            left = mid + 1;
            //        }
            //        else if (input[left] > input[left +1])
            //        {
            //            return left;
            //        }
            //    }

            //}
            //return -1;
            int m = 0;
            while (l < r)
            {
                m = (l + r) / 2;

                if (m == 0)
                {
                    if (input[l] > input[r])
                    {
                        m = l;
                    }
                    else
                    {
                        m = -1;
                    }
                    break;
                }
                else if (input[m - 1] < input[m] && input[m] > input[m + 1])
                {
                    break;
                }
                else if (input[l] < input[m])
                {
                    l = m + 1;
                }
                else
                {
                    r = m;
                }
            }
            return m;


        }

      
        class ArrayContainterForSearch
        {
            public int[] Input;
            public int Search;
        }

    }
}
