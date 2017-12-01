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
    public partial class Arrays : Form
    {
        StringBuilder inputDisplayBuilder = new StringBuilder();
        public Arrays()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //int[] arr1 = new int[10];
            //arr1[0] = 4;
            //arr1[1] = 5;
            //arr1[2] = 6;
            //arr1[3] = 7;
            //arr1[4] = 8;
            //arr1[5] = 9;
            //arr1[6] = 10;
            //int[] arr2 = new int[3];
            //arr2[0] = 1;
            //arr2[1] = 2;
            //arr2[2] = 3; //Worst Case O(n+m)

            //int[] arr1 = new int[10];
            //arr1[0] = 1;
            //arr1[1] = 2;
            //arr1[2] = 3;
            //arr1[3] = 7;
            //arr1[4] = 8;
            //arr1[5] = 9;
            //arr1[6] = 10;
            //int[] arr2 = new int[3];
            //arr2[0] = 4;
            //arr2[1] = 5;
            //arr2[2] = 6;//Worst Case O(n+m)

            int[] arr1 = new int[10];
            arr1[0] = 1;
            arr1[1] = 2;
            arr1[2] = 3;
            arr1[3] = 4;
            arr1[4] = 5;
            arr1[5] = 6;
            arr1[6] = 7;
            int[] arr2 = new int[3];
            arr2[0] = 3;
            arr2[1] = 9;
            arr2[2] = 10; //Best Case O(n+m)


            MessageBox.Show($"Before Arr1 = {Display(arr1)} \n Arr2 = {Display(arr2)}");

            MergeArrays(arr1, arr2);
                
            //Merge(arr2, arr1);
            MessageBox.Show($"After Arr1 = {Display(arr1)} \n Arr2 = {Display(arr2)}");

        }

        void MergeArrays(int[] arr1, int[] arr2)
        {
            int arr1Length = arr1.Length-1;
            int arr1LastFilledIndex = this.GetLastFilledArrayIndex(arr1);
            int arr2Length = arr2.Length-1;            



            while(true)
            { 
                if (arr2Length < 0)
                {
                    break;
                }

                if (arr1LastFilledIndex >= 0 &&  arr1[arr1LastFilledIndex] > arr2[arr2Length])
                {
                    arr1[arr1Length] = arr1[arr1LastFilledIndex];
                    arr1[arr1LastFilledIndex] = 0;
                    arr1LastFilledIndex--;
                }               
                else
                {
                    arr1[arr1Length] = arr2[arr2Length];
                    arr2Length--;                   
                }
                arr1Length--;
            }
        }

        private int GetLastFilledArrayIndex(int[] array)
        {
            int returnValue = -1;
            for(int i= 0; i<array.Length; i++)
            {
                if (array[i] == 0)
                {
                    returnValue =  i-1;
                    break;
                }
            }
            return returnValue;
        }

        private string Display(int[] arr)
        {
            StringBuilder builder = new StringBuilder();
            arr.ToList().ForEach(e => builder.Append($" {e.ToString()}"));
            return builder.ToString();

        }

        private void Remove_duplicate_element_in_sorted_array_Click(object sender, EventArgs e)
        {

            //Time Complexity is O(n)
            int[] buffer = new int[] { 1, 2, 3, 3, 3, 4, 4, 5, 5 };
            Array.Resize<int>(ref buffer, 12);

            //insert = 2, i =3

            int insert = 0;            
            for (int i = 1; i < buffer.Length - 1; i++)
            {
                if (buffer[i] != buffer[insert])
                {
                    insert++;

                    if (insert != i )
                    {
                        buffer[insert] = buffer[i];                        
                    }
                }                           
            }
                        
            while (insert < buffer.Length-1)
            {
                insert++;
                buffer[insert] = 0;                
            }

            StringBuilder builder = new StringBuilder();
            foreach (int j in buffer)
            {
                builder.Append($"{j.ToString()},");
            }
            MessageBox.Show(builder.ToString());
        }

        public void MergeArraysDuplicateValues(int[] arr1, int[] arr2)
        {
            int arr1Length = arr1.Length - 1;
            int arr1LastFilledIndex = this.GetLastFilledArrayIndex(arr1);
            int arr2Length = arr2.Length - 1;
            int arr1Incr = 0; int arr2Incr = 0;
            List<int> unique = new List<int>();

            int temp = 0;
            while (true)
            {
                if (arr1Incr <= arr1LastFilledIndex && arr2Incr <= arr2Length)
                {
                    if (arr1[arr1Incr] < arr2[arr2Incr])
                    {
                        arr1Incr++;
                    }
                    else if (arr1[arr1Incr] == arr2[arr2Incr])
                    {
                        arr1Incr++;
                        arr2Incr++;
                    }
                    else
                    {
                        temp = arr1[arr1Incr];
                        arr1[arr1Incr] = arr2[arr2Incr];
                        arr2[arr2Incr] = temp;
                        arr1Incr++;

                    }
                    unique.Add(arr1[arr1Incr - 1]);
                }
                else
                {
                    break;
                }
            }

            //if (arr1Incr <= arr1LastFilledIndex && arr2Incr > arr2Length)
            //{
            //    while (arr1LastFilledIndex >= arr1Incr)
            //    {
            //        arr1[arr1Length] = arr1[arr1LastFilledIndex];
            //        arr1LastFilledIndex--;
            //    }
            //    arr2Incr = 0;
            //}

            while (arr2Incr <= arr2Length)
            {
                if (!unique.Contains(arr2[arr2Incr]))
                {
                    arr1[arr1Incr] = arr2[arr2Incr];
                    arr1Incr++;
                }

                arr2Incr++;
            }

        }


        private void Merge_Two_sorted_Arrays_with_out_3rd_Array_With_duplicate(object sender, EventArgs e)
        {
            int[] arr1 = new int[10];
            arr1[0] = 1;
            arr1[1] = 2;
            arr1[2] = 3;
            arr1[3] = 3;
            arr1[4] = 6;
            arr1[5] = 7;
            //arr1[6] = 10;
            int[] arr2 = new int[3];
            arr2[0] = 3;
            arr2[1] = 4;
            arr2[2] = 10; //Best Case O(n+m)


            MessageBox.Show($"Before Arr1 = {Display(arr1)} \n Arr2 = {Display(arr2)}");

            MergeArraysDuplicateValues(arr1, arr2);

            //Merge(arr2, arr1);

            MessageBox.Show($"After Arr1 = {Display(arr1)} \n Arr2 = {Display(arr2)}");

        }

        private void Array_Reduction_Cost_Click(object sender, EventArgs e)
        {
            int[] input = new int[] { 1, 2, 3};
            if (input==null || input.Length ==0)
            {
                MessageBox.Show("Invalid inputs");
            }
            int sum= input[0];
            int reductionCost = 0;
            int incrementer = 1;
            while (incrementer <= input.Length -1)
            {
                if (incrementer == 1)
                {
                    sum += input[incrementer];
                }
                else
                {
                    reductionCost += sum;
                    sum += input[incrementer] ;
                }
                incrementer++;
            }

            reductionCost += sum;


            MessageBox.Show($"Array Reduction cost {reductionCost.ToString()}");
        }

        private void Array_Binary_digits_0_to_1_Click(object sender, EventArgs e)
        {
            int[] input = new int[] {1,1,0,0,0,1,1,1,1,1 };

            if (input == null || input.Length == 0)
            {
                MessageBox.Show("Invalid inputs");
            }

            int start = 0;
            int end = input.Length - 1;
            string before = Display(input);
            while (start < end)
            {
                if (input[start] == 0)
                {
                    start++;
                }
                else if (input[end]==1)
                {
                    end--;
                }
                else
                {
                    input[start] = 0;
                    input[end] = 1;
                }
            }

            MessageBox.Show($"Before Input = {before}\nAfter input = {Display(input)}");

        }

        public string IntToBinaryString(int number)
        {
            const int mask = 1;
            var binary = string.Empty;
            while (number > 0)
            {
                // Logical AND the number and prepend it to the result string
                binary = (number & mask) + binary;
                number = number >> 1;
            }

            return binary;
        }

        private void Sort_int_array_through_binary_digits_based_on_1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.IntToBinaryString(60));
        }

        private string FindPairs(int[] input, int sum)
        {
            // 1, 2, 10, 4, 6, 8, 8,-20
            if (input== null || input.Length ==0 )
            {
                MessageBox.Show("Invalid Inputs");
            }

            StringBuilder builder = new StringBuilder();
            List<int> hashmap = new List<int>();
            int temp = 0;
            for (int i =0; i <input.Length; i++)
            {
                temp = sum - input[i];
                if (hashmap.Contains(temp))
                {
                    builder.Append($"Pairs {temp},{input[i].ToString()}\n");
                }
                if (!hashmap.Contains(input[i]))
                {
                    hashmap.Add(input[i]);
                }
            }

            return builder.ToString();
        }

        private int[,] FindPairsAndReturnArray(int[] input, int sum)
        {
            
            // 1, 2, 10, 4, 6, 8, 8,-20
            if (input == null || input.Length == 0)
            {
                MessageBox.Show("Invalid Inputs");
            }

            StringBuilder builder = new StringBuilder();
            Dictionary<int, int>  hashmap = new Dictionary<int, int>();

            int temp = 0;
            for (int i = 0; i < input.Length; i++)
            {
                temp = sum - input[i];
                if (hashmap.ContainsKey(temp))
                {                                       
                    return new int[,] { { hashmap[temp], i } } ;                    
                }
                if (!hashmap.ContainsKey(input[i]))
                {
                    hashmap.Add(input[i], i);
                }
            }

            return null;
        }

        private void Given_an_array_and_a_number_x_check_for_pair_in_Array_with_sum_as_x_Click(object sender, EventArgs e)
        {
            //http://www.geeksforgeeks.org/write-a-c-program-that-given-a-set-a-of-n-numbers-and-another-number-x-determines-whether-or-not-there-exist-two-elements-in-s-whose-sum-is-exactly-x/
            int[] input = new int[] { 1, 2, 10, 4, 6, 8, 8,-20 };
            var t = this.FindPairsAndReturnArray(input, -16);
            MessageBox.Show(this.FindPairs(input, -16));
        }

        private void MajorityElement_Click(object sender, EventArgs e)
        {
            //http://www.geeksforgeeks.org/majority-element/
            //int[] input = new int[] { 1, 2, 3, 4, 5, 6, 8, -20 }; // 8 items
            //int[] input = new int[] { 3, 3, 4, 2, 4, 4, 2, 4, 4 }; // 9
            int[] input = new int[] { 3, 3, 4, 2, 4, 4, 2, 4 }; // 8



            int count = 1;
            int majorityIndex = 0;
            int maxOccurance = 1;

            for(int i = 1; i <input.Length; i++)
            {
                if (input[majorityIndex] == input[i])
                {
                    count++;
                    maxOccurance++;
                }
                else
                {                    
                    count--;
                }

                if (count == 0)
                {
                    majorityIndex = i;
                    count = 1;
                    maxOccurance = 1;
                }
            }

            if (maxOccurance >= (input.Length / 2))
            {
                MessageBox.Show($"Majority Element {input[majorityIndex].ToString()}");
            }
            else
            {
                MessageBox.Show($"No Majority Element present");
            }
        }

        private void Find_the_Number_Occurring_Odd_Number_of_Times_Click(object sender, EventArgs e)
        {
            //Time complexity : O(n)
            //Space Complexity : O(1)

            int[] input = new int[] { 1, 2, 3, 2, 3, 1, 3 };

            int res = 0;
            for(int i =0; i<input.Length;i++)
            {
                res = res ^ input[i];
            }

            MessageBox.Show($"Odd Number {res.ToString()}");
        }

        private void Function_rotate_that_rotates_arr_of_size_n_by_d_elements_Click(object sender, EventArgs e)
        {

            // Time complexity: O(n)
            // Auxiliary Space: O(1)

            int[] input = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            int d = 2;
            inputDisplayBuilder.Clear();
            MessageBox.Show($"Input Array is {printArray(input)}");
            this.leftRotate(input, d, input.Length);
            MessageBox.Show($"After rotation array is {printArray(input)}");

            //int i = 7;
            //int j = 10;

            //MessageBox.Show($"GCD of {i} and {j} is {this.GCD(i,j).ToString()}");

        }


        public string printArray(int[] arr)
        {

            inputDisplayBuilder.Clear();
            for (int i = 0; i < arr.Length; i++)
            {
                inputDisplayBuilder.Append(arr[i] + " ");
            }
            return inputDisplayBuilder.ToString();

        }


        private int GCD(int a, int b)
        {
            if (b==0)
            {
                return a;
            }
            return GCD(b, a % b);

        }

        private void leftRotate(int[] arr, int d, int n)
        {
            // input  1, 2, 3, 4, 5, 6, 7
            int i, j, k, temp;
            for (i = 0; i < this.GCD(d, n); i++)
            {
                /* move i-th values of blocks */
                temp = arr[i];
                j = i;
                while (1 != 0)
                {
                    k = j + d;
                    if (k >= n)
                        k = k - n;
                    if (k == i)
                        break;
                    arr[j] = arr[k];
                    j = k;
                }
                arr[j] = temp;
            }
        }


        /*This function swaps d elements starting at index fi
        with d elements starting at index si */
        private void swap(int[] arr, int fi, int si, int d)
        {
            int i, temp;
            for (i = 0; i < d; i++)
            {
                temp = arr[fi + i];
                arr[fi + i] = arr[si + i];
                arr[si + i] = temp;
            }
        }

        private void LeftRotateBlockSwap(int[] arr, int d, int n)
        {
            /* Return If number of elements to be rotated is
	        zero or equal to array size */
            if (d == 0 || d == n)
                return;

            /*If number of elements to be rotated is exactly
            half of array size */
            if (n - d == d)
            {
                this.swap(arr, 0, n - d, d);                
                return;
            }

            /* If A is shorter*/
            if (d < n - d)
            {
                this.swap(arr, 0, n - d, d);
                this.LeftRotateBlockSwap(arr, d, n - d);
            }
            else /* If B is shorter*/
            {
                this.swap(arr, 0, d, n - d);
                //this.LeftRotateBlockSwap(arr + n - d, 2 * d - n, d); /*This is tricky*/)
                if (n - d == d)
                {
                    this.swap(arr, n - d, n, d);
                }                
            }
        }

        private void btn_Block_swap_algorithm_for_array_rotation_Click(object sender, EventArgs e)
        {
            //http://www.geeksforgeeks.org/block-swap-algorithm-for-array-rotation/

            //Time Complexity : O(n)
            StringBuilder result = new StringBuilder();
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7,8, 9, 10};
            result.Append($"Before Swap {this.printArray(arr)}");
            this.LeftRotateBlockSwap(arr, 7, arr.Length);
            result.AppendLine($"After Swap {this.printArray(arr)}");
            MessageBox.Show(result.ToString());

        }        
    }
}
