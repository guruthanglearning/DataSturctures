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
            while (right > 1)
            {
                mid = left + right / 2;

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
    }
}
