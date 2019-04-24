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

            if (right >=1)
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
            //int[] input = new int[] { 1, 2, 3, 4, 5, 6};
            //int[] input = new int[] { 3, 4, 5, 6, 1, 2};
            //int[] input = new int[] { 3, 4, 5, 6, 7, 1, 2 };
            int[] input = { 5, 6, 7, 8, 9, 10, 1, 2, 3, 4 };
            int search = 6;
            int left = 0; int right = input.Length - 1;
            int mid = 0;
            int pivot = -1;
            int result = -1;
            if (input[left] > input[right])
            {                
                result = this.BinarySearchForRotateArray(input, 0, input.Length - 1, search);


                //while (left <= right)
                //{
                //    mid = (left + right) / 2;
                //    if (input[mid - 1] < input[mid] && input[mid] < input[mid + 1])
                //    {
                //        left = mid;
                //    }
                //    else if (input[mid - 1] > input[mid])
                //    {
                //        pivot = mid - 1;
                //        break;
                //    }
                //    else if (input[mid] > input[mid + 1])
                //    {
                //        pivot = mid;
                //        break;
                //    }
                //}
                //if (search >= input[0] && search <= input[pivot])
                //{
                //    left = 0;
                //    right = pivot;
                //}
                //else
                //{
                //    left = pivot + 1;
                //    right = input.Length - 1;
                //}
            }
            else
            {
                result = this.binarySearchIterative(input, left, right, search);
            }

            MessageBox.Show(//$"Pivot for the given array {string.Join(",", input)} is {pivot.ToString()} \n" +
                            $"Index of the given number {search.ToString()} in the array is {result.ToString()}");


        }

        private int BinarySearchForRotateArray(int[] input, int left, int right, int search)
        {
            if (input == null || input.Length == 0)
                return -1;

            if (input[left]==search)
            {
                return left;
            }
            else if (input[right] == search)
            {
                return right;
            }
            int mid = (left + right) / 2;

            int result = BinarySearchForRotateArray(input, left + 1, mid, search);
            if (result == -1)
            {
                return BinarySearchForRotateArray(input, mid + 1, right-1, search);
            }

            return result;
        

        }
      
    }
}
