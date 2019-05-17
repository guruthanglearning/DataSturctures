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
        public struct Interval
        {
            public int Start;
            public int End;
        }

        StringBuilder inputDisplayBuilder = new StringBuilder();
        public Arrays()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // int?[] array = new int?[10]; --Nullable Array

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
            /*
               arr1 = 1  2  3   4   5   6   7   0   0   0
               arr2 = 3  9  10
            */

            int arr1Length = arr1.Length - 1;
            int arr1LastFilledIndex = this.GetLastFilledArrayIndex(arr1);
            int arr2Length = arr2.Length - 1;

            

            while (true)
            {
                if (arr2Length < 0)
                {
                    break;
                }

                if (arr1LastFilledIndex >= 0 && arr1[arr1LastFilledIndex] > arr2[arr2Length])
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
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 0)
                {
                    returnValue = i - 1;
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
        
            int insert = 0;
            for (int i = 1; i < buffer.Length - 1; i++)
            {
                /*                    
                    Index   :   0   1   2   3   4   5   6   7   8
                    buffer  :   1   2   3   4   5   4   4   5   5
                    i = 9   insert = 4
                */

                if (buffer[i] != buffer[insert])
                {
                    insert++;

                    if (insert != i)
                    {
                        buffer[insert] = buffer[i];
                    }
                }
            }

            while (insert < buffer.Length - 1)
            {
                insert++;
                buffer[insert] = 0;
            }
            
            MessageBox.Show(string.Join(",",buffer));
        }

        public void MergeArraysDuplicateValues(int[] arr1, int[] arr2)
        {
            int arr1Length = arr1.Length - 1;
            int arr1LastFilledIndex = this.GetLastFilledArrayIndex(arr1);
            int arr2Length = arr2.Length - 1;                        

            /*

             Input                  
                  arr1   :   1   2   3   3   6   7   8   0   0   0    0
                  arr2   :   3   3   4   10

            Output
                arr1LastFilledIndex = 3, arr2Length = -1 arr1Length = -3
                arr1   :   1   2   3   3   3    3   4  6   7   8   10                           

            */
            
            while (arr1LastFilledIndex >= 0 && arr2Length >= 0)
            {
                    if (arr1[arr1LastFilledIndex] > arr2[arr2Length])
                    {
                        arr1[arr1Length] = arr1[arr1LastFilledIndex];
                        arr1LastFilledIndex--;

                    }
                    else if (arr1[arr1LastFilledIndex] < arr2[arr2Length])
                    {
                        arr1[arr1Length] = arr2[arr2Length];
                        arr2Length--;
                    }
                    else
                    {
                        arr1[arr1Length] = arr2[arr2Length];
                        arr2Length--;
                    }
                    arr1Length--;
            }                            
        }


        private void Merge_Two_sorted_Arrays_with_out_3rd_Array_With_duplicate(object sender, EventArgs e)
        {
            /*
             
                Input 
                     arr1   :   1   2   3   3   6   7   8   0   0   0    0
                     arr2   :   3   3   4   10
              
            */

            int[] arr1 = new int[11];
            arr1[0] = 1;
            arr1[1] = 2;
            arr1[2] = 3;
            arr1[3] = 3;
            arr1[4] = 6;
            arr1[5] = 7;
            arr1[6] = 8;
            //arr1[6] = 10;
            int[] arr2 = new int[4];
            arr2[0] = 3;
            arr2[1] = 3;
            arr2[2] = 4;
            arr2[3] = 10; //Best Case O(n+m)


            MessageBox.Show($"Before Arr1 = {Display(arr1)} \n Arr2 = {Display(arr2)}");

            MergeArraysDuplicateValues(arr1, arr2);
            

            MessageBox.Show($"After Arr1 = {Display(arr1)} \n Arr2 = {Display(arr2)}");

        }

        private void Array_Reduction_Cost_Click(object sender, EventArgs e)
        {
            int[] input = new int[] { 1, 2, 3, 4 };
            if (input == null || input.Length == 0)
            {
                MessageBox.Show("Invalid inputs");
            }
            int sum = input[0];
            int reductionCost = 0;
            int incrementer = 1; 
            /*
                Index           :   0   1   2   3
                Input           :   1   2   3   4
                sum             :   10
                incrementer     :   3
                reductionCost   :   9
             
             */

            while (incrementer <= input.Length - 1)
            {
                // incrementer = 3 , sum = 10, reductionCost = 9
                if (incrementer == 1)
                {
                    sum += input[incrementer];
                }
                else
                {
                    reductionCost += sum;
                    sum += input[incrementer];
                }
                incrementer++;
            }

            reductionCost += sum;


            MessageBox.Show($"Array Reduction cost {reductionCost.ToString()}");
        }

        private void Array_Binary_digits_0_to_1_Click(object sender, EventArgs e)
        {
            int[] input = new int[] { 1, 1, 0, 0, 0, 1, 1, 1, 1, 1 };

            if (input == null || input.Length == 0)
            {
                MessageBox.Show("Invalid inputs");
            }

            int start = 0;
            int end = input.Length - 1; //9
            string before = Display(input);
            while (start < end)
            {
                if (input[start] == 0)
                {
                    start++; 
                }
                else if (input[end] == 1)
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
            /*
                60 
             */
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
            //Not Implemented
            MessageBox.Show(this.IntToBinaryString(60));
        }

        private string FindPairs(int[] input, int sum)
        {
            // 1, 2, 10, 4, 6, 8, 8,-20 sum = -16
            if (input == null || input.Length == 0)
            {
                MessageBox.Show("Invalid Inputs");
            }

            StringBuilder builder = new StringBuilder();
            List<int> hashmap = new List<int>();
            int temp = 0;
            for (int i = 0; i < input.Length; i++)
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

            /*
                Input   : 1, 2, 10, 4, 6, 8, 8, -20
                Sum     : -16
             */
            if (input == null || input.Length == 0)
            {
                MessageBox.Show("Invalid Inputs");
            }

            StringBuilder builder = new StringBuilder();
            Dictionary<int, int> hashmap = new Dictionary<int, int>();

            int temp = 0;
            for (int i = 0; i < input.Length; i++)
            {
                temp = sum - input[i];
                if (hashmap.ContainsKey(temp))
                {
                    return new int[,] { { hashmap[temp], i } };
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
            int[] input = new int[] { 1, 2, 10, 4, 6, 8, 8, -20 };
            var t = this.FindPairsAndReturnArray(input, -16);
            MessageBox.Show(this.FindPairs(input, -16));
        }

        private void MajorityElement_Click(object sender, EventArgs e)
        {
            //http://www.geeksforgeeks.org/majority-element/
            //int[] input = new int[] { 1, 2, 3, 4, 5, 6, 8, -20 }; // 8 items
            //int[] input = new int[] { 3, 3, 4, 2, 4, 4, 2, 4, 4 }; // 9
            //int[] input = new int[] { 3, 3, 4, 2, 4, 4, 2, 4 }; // 8
            int[] input = new int[] { 3, 3, 4, 2, 1, 4, 4, 2, 4, 4 };

            int count = 1;
            int majorityIndex = 0;
            int maxOccurance = 1;
            /*
                count = 3;
                majorityIndex = 4;
                maxOccurance = 4; 
                I = 8
             */
            for (int i = 1; i < input.Length; i++)
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
            // https://www.geeksforgeeks.org/find-the-number-occurring-odd-number-of-times/
            // Time complexity : O(n)
            // Space Complexity : O(1)

            int[] input = new int[] { 1, 2, 3, 2, 3, 1, 3 };

            int res = 0;
            for (int i = 0; i < input.Length; i++)
            {
                res = res ^ input[i];
            }

            MessageBox.Show($"Odd Number {res.ToString()}");
        }

        private int GCD(int a, int b)
        {
            /* 
                a=2, b= 7
                a=7, b= 2
                a=2, b=1
                a=1, b=0
            */
            if (b == 0)
            {
                return a;
            }
            return GCD(b, a % b);
        }

        private void leftRotate(int[] arr, int d, int n)
        {
            // input  1, 2, 3, 4, 5, 6, 7
            int i, j, k, temp;
            /* move i-th values of blocks 
                 i = 0, j= 5, d = 6,  k = j + d = 0, temp = arr[i] = 1

                         ---------------------------
                         0     1   2   3   4   5   6
                         ---------------------------
                         1     2   3   4   5   6   7    
                         3     2   3   4   5   6   7    i = 0, j= 0, d = 2,  k = j + d = 2, temp = arr[i] = 1
                         3     2   5   4   5   6   7    i = 0, j= 2, d = 2,  k = j + d = 4, temp = arr[i] = 1
                         3     2   5   4   7   6   7    i = 0, j= 4, d = 2,  k = j + d = 6, temp = arr[i] = 1
                         3     2   5   4   7   6   2    i = 0, j= 6, d = 2,  k = j + d = 8 (8-7) = 1 , temp = arr[i] = 1                         
                         3     4   5   4   7   6   2    i = 0, j= 1, d = 2,  k = j + d = 3 , temp = arr[i] = 1                         
                         3     4   5   6   7   6   2    i = 0, j= 3, d = 2,  k = j + d = 5, temp = arr[i] = 1
                         3     4   5   6   7   6   2    i = 0, j= 5, d = 2,  k = j + d = 7 (7-7 = 0, k = i break), temp = arr[i] = 1
                         3     4   5   6   7   6   2    i = 0, j= 5, d = 2,  k = j + d = 7 (7-7 = 0, k = i break), temp = arr[i] = 1
               */
            for (i = 0; i < this.GCD(d, n); i++)
            {
               
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


        private void Function_rotate_that_rotates_arr_of_size_n_by_d_elements_Click(object sender, EventArgs e)
        {

            /* Time complexity: O(n)
               Auxiliary Space: O(1)
               https://www.geeksforgeeks.org/?p=2398
               Notes : Instead of getting GCD reverse the array from the below
               Step 1   : Input.Length-1 to 0 
               Step 2   : Input.Length-2 to Input.Length -1
               Step 3   : 0 to Input.Length-1-2
            */
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
            int i, j;
            if (d == 0 || d == n)
                return;
            i = d;
            j = n - d;
            while (i != j)
            {
                if (i < j) /*A is shorter*/
                {
                    swap(arr, d - i, d + j - i, i);
                    j -= i;
                }
                else /*B is shorter*/
                {
                    swap(arr, d - i, d, j);
                    i -= j;
                }
                // printArray(arr, 7);
            }
            /*Finally, block swap A and B*/
            swap(arr, d - i, d, i);
        }

        private void btn_Block_swap_algorithm_for_array_rotation_Click(object sender, EventArgs e)
        {
            //http://www.geeksforgeeks.org/block-swap-algorithm-for-array-rotation/

            //Time Complexity : O(n)
            StringBuilder result = new StringBuilder();
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            result.Append($"Before Swap {this.printArray(arr)}");
            this.LeftRotateBlockSwap(arr, 7, arr.Length);
            result.AppendLine($"After Swap {this.printArray(arr)}");
            MessageBox.Show(result.ToString());

        }

       

        public double findMedianSortedArrays(int[] A, int[] B)
        {

            
            int m = A.Length;
            int n = B.Length;
            if (m > n)
            { 
                // to ensure m<=n. Always maching array A is smalles array
                int[] temp = A; A = B; B = temp;
                int tmp = m; m = n; n = tmp;
            }

            
            int iMin = 0, iMax = m, halfLen = (m + n + 1) / 2;
            while (iMin <= iMax)
            {

                /*                    
                    int[] nums1 = new int[] { 2, 3, 4, 5 };
                    int[] nums2 = new int[] { 1, 2, };
                    Before swap m=4, n= 2
                    
                    After swap m=2 , n=4
                    int[] nums1 = new int[] { 1, 2, };
                    int[] nums2 = new int[] { 2, 3, 4, 5 };
                    
                    iMin = 0 Max = 2, halfLen = 3, i = 1, j = 2
                */

                int i = (iMin + iMax) / 2; 
                int j = halfLen - i;       

                if (i < iMax && B[j - 1] > A[i])
                {
                    iMin = iMin + 1; // i is too small
                }
                else if (i > iMin && A[i - 1] > B[j])
                {
                    iMax = iMax - 1; // i is too big
                }
                else
                { // i is perfect
                    int maxLeft = 0;
                    if (i == 0) //When array is empty
                    {
                        maxLeft = B[j - 1];
                    }
                    else if (j == 0) //When array is empty
                    {
                        maxLeft = A[i - 1];
                    }
                    else
                    {
                        maxLeft = Math.Max(A[i - 1], B[j - 1]);
                    }
                    if ((m + n) % 2 == 1)
                    {
                        return maxLeft;
                    }

                    int minRight = 0;
                    if (i == m) //When array is empty
                    {
                        minRight = B[j];
                    }
                    else if (j == n) //When array is empty
                    {
                        minRight = A[i];
                    }
                    else
                    {
                        minRight = Math.Min(B[j], A[i]);
                    }

                    return (maxLeft + minRight) / 2.0; ;
                }
            }
            return 0.0;
        }

        private void btn_Median_of_Two_sorted_arrays_Click(object sender, EventArgs e)
        {
            /*
                Time Complexity         : O(log n)
                Space Complexity        : O(1)
                               
                At first, the searching range is [0, m][0,m]. And the length of this searching range will be reduced by half after each loop. 
                So, we only need log(m) loops. Since we do constant operations in each loop, so the time complexity is 
                O(log(m)). Since m <= n, so the time complexity is O(log(min(m,n))).               
                We only need constant memory to store 9 local variables, so the space complexity is O(1).
            */

            /*
                int[] nums1 = new int[] { 3, 4, 5, 6 };
                int[] nums2 = new int[] { 1, 2, 3, 7 };
                
                int[] nums1 = new int[] { 3, 4, 5, 6 };
                int[] nums2 = new int[] { 1, 2, 3, 7 };     
                
                int[] nums1 = new int[] { 1, 2, 3, 4, 5 };
                int[] nums2 = new int[] { 0, 0, };

                int[] nums1 = new int[] { 2, 3, 4, 5 };
                int[] nums2 = new int[] { 1, 2, };

            */


            //int[] nums1 = new int[] { 2, 3, 4, 5 };
            int[] nums1 = new int[] { };
            int[] nums2 = new int[] { 1, 2, };
            
            MessageBox.Show(this.findMedianSortedArrays(nums1, nums2).ToString());            

        }

        private void btn_Maximum_Rectangular_Area_in_Histogram_Click(object sender, EventArgs e)
        {
            /*
              Time Complexity is O(n)
              Space Complexity is O(2 log n)
            		            _____
		                        |	|
		                        |	|
	                        ____|	|____
	                        |	|	|	|
                        ____|	|	|	|____
                        |	|	|	|	|	 |
                        |	|	|	|	|	 |
                        |___|___|___|___|____|
                    His   1   2	  4	  2	   1
                    Pos   0   1   2   3    4
            */


            int[] heights = new int[] { 1, 2, 4, 2, 1 };
            int tempPos = 0;
            int tempHist = 0;
            Stack pos = new Stack();
            Stack histogram = new Stack();
            int largest = 0;
            for (int i = 0; i < heights.Length; i++)
            {
                int h = heights[i];
                if (histogram.Count == 0 || h >= (int)histogram.Peek())
                {
                    histogram.Push(h);
                    pos.Push(i);
                }
                else
                {
                    while (histogram.Count > 0 && h < (int)histogram.Peek())
                    {
                        tempPos = (int)pos.Pop();
                        tempHist = (int)histogram.Pop();
                        largest = Math.Max(tempHist * (i - tempPos), largest);
                    }
                    histogram.Push(h);
                    pos.Push(tempPos);
                }

            }
            while (histogram.Count > 0)
            {
                tempPos = (int)pos.Pop();
                tempHist = (int)histogram.Pop();
                largest = Math.Max(tempHist * (heights.Length - tempPos), largest);
            }


            MessageBox.Show($"Largest rectangle in histogram is {largest.ToString()} ");

        }

        private void btn_Check_Given_Array_Is_Sorted_Or_Not_Click(object sender, EventArgs e)
        {
            /*
             Time Complexity    :   O(n)
             http://www.geeksforgeeks.org/program-check-array-sorted-not-iterative-recursive/
            */

            int[] input = new int[] { 1, 2, 3, 4, 10, 5 };
            bool? returnValue = null;
            if (input != null && input.Length > 0)
            {
                returnValue = true;
                for (int i = 0; i < input.Length; i++)
                {
                    if (i + 1 < input.Length)
                    {
                        if (input[i] > input[i + 1])
                        {
                            returnValue = false;
                            break;
                        }
                    }
                }
            }

            string result = returnValue != null ? "Empty" : returnValue.Value ? "Sorted" : "Not Sorted";
            MessageBox.Show($"Given array is {result}");

        }

        private void btn_Union_and_Intersection_of_two_sorted_arrays_Click(object sender, EventArgs e)
        {

            /*
             Time Complexity is O(m+n) where m and n is the length of the input 1 and input 2 array respectivey
             http://www.geeksforgeeks.org/union-and-intersection-of-two-sorted-arrays-2/
            */
            int[] input1 = new int[] { 1, 2, 3, 4, 5 };
            int[] input2 = new int[] { 3, 5, 7, 9, 11 };
            StringBuilder intersection = new StringBuilder();
            StringBuilder union = new StringBuilder();
            if (input1 != null && input1.Length > 0 && input2 != null && input2.Length > 0)
            {
                int i = 0, j = 0;

                while (i < input1.Length && j < input2.Length)
                {
                    if (input1[i] < input2[j])
                    {                        
                        union.Append(input1[i] + " ");
                        i++;
                    }
                    else if (input1[i] > input2[j])
                    {                        
                        union.Append(input2[i] + " ");
                        j++;
                    }
                    else
                    {
                        intersection.Append(input1[i] + " ");
                        union.Append(input2[j] + " ");
                        i++;
                        j++;
                    }
                }

                while (i < input1.Length)
                {
                    union.Append(input1[i] + " ");
                    i++;
                }

                while (j < input2.Length)
                {
                    union.Append(input2[j] + " ");
                    j++;
                }

                MessageBox.Show($"Interaction of two sorted arrays are {(intersection.Length > 0 ? intersection.ToString() : "none")} \n"+
                                $"Union of two sorted arrays are {(union.Length > 0 ? union.ToString() : "none")}" );
            }


        }

        private void btn_Find_Union_and_Intersection_of_two_unsorted_arrays_Click(object sender, EventArgs e)
        {
            /*
             Sort both the input arrays and find the union and intersect 
             Time Complexity -
                                Sorting using Merge sort would be O(m log m) + O(n log n) 
                                Union and Intersect would be  O(m+n)
                                Total Comlexity would be O(m log m) + O(n log n) + O(m+n)

            http://www.geeksforgeeks.org/find-union-and-intersection-of-two-unsorted-arrays/

             */
            int[] input1 = new int[] { 7, 1, 5, 2, 3, 6 };
            int[] input2 = new int[] { 3, 8, 6, 20, 7 };
            

        }

        private void btn_Merge_Overlapping_Intervals_Click(object sender, EventArgs e)
        {
            /*
                 Time Complexity - 
                                    Sorting for Merge Sorting is O(n log n )
                                    Overlapping Interval O(n)
                 http://www.geeksforgeeks.org/merging-intervals/
            */
            //int[,] input1 = new int[4, 2] { { 6, 8 }, { 1, 9 }, { 2, 4 }, { 4, 7 } };
            //Interval[] input1 = new Interval[] {
            //                                        new Interval(){Start = 1, End = 9},
            //                                        new Interval(){Start = 2, End = 4},
            //                                        new Interval(){Start = 4, End = 7},
            //                                        new Interval(){Start = 6, End = 8}                                                    
            //                                    };

            Interval[] input1 = new Interval[] {
                                                    new Interval(){Start = 1, End = 3},
                                                    new Interval(){Start = 5, End = 7},
                                                    new Interval(){Start = 10, End = 14},
                                                    new Interval(){Start = 13, End = 18}
                                                };

            if (input1 != null && input1.Length == 0)
            {
                MessageBox.Show("Input is empty");
            }

            StringBuilder overlapping = new StringBuilder();
            Stack<Interval> stack = new Stack<Interval>();
            stack.Push(input1[0]);

            for (int i = 1; i < input1.Length; i++)
            {
                Interval interval = stack.Peek();
                if (interval.End < input1[i].Start)
                {
                    stack.Push(input1[i]);
                }
                else if (interval.End < input1[i].End)
                {
                    interval.End = input1[i].End;
                    stack.Pop();
                    stack.Push(interval);
                }
            }

            while (stack.Count != 0)
            {
                Interval interval = stack.Pop();
                overlapping.Append($"{interval.Start.ToString()} {interval.End.ToString()} \n");
            }

            MessageBox.Show($"Overlapping pair: \n {overlapping.ToString()}");

        }

        // Utility function to find ceiling of r in arr[l..h]
        int FindCeil(int[] arr, int r, int l, int h)
        {
            /*
             Given a sorted array and a value x, the ceiling of x is the smallest element in array greater than or equal to x, 
             and the floor is the greatest element smaller than or equal to x. Assume than the array is sorted in non-decreasing order. 
             Write efficient functions to find floor and ceiling of x.
             For example, let the input array be {1, 2, 8, 10, 10, 12, 19}
                    For x = 0:    floor doesn't exist in array,  ceil  = 1
                    For x = 1:    floor  = 1,  ceil  = 1
                    For x = 5:    floor  = 2,  ceil  = 8
                    For x = 20:   floor  = 19,  ceil doesn't exist in array
            
            freq = 49, 0, 50 
            prefix = 49, 49, 99
            r = 30, l=0, h = 0
            mid = 0
            */

            int mid;
            while (l < h)
            {
                mid = (l + h) / 2; //l + ((h - l) >> 1);  // Same as mid = (l+h)/2
                if (r > arr[mid])
                {
                    l = mid + 1;
                }
                else
                {
                    h = mid;
                }
            }
            return (arr[l] >= r) ? l : -1;
        }

        // The main function that returns a random number from arr[] according to
        // distribution array defined by freq[]. n is size of arrays.
        private int Get_Arbitrary_Probability_Distribution_Fashion(int[] arr, int[] freq, int n)
        {
            // Create and fill prefix array

            /*
                int[] arr = new int[] { 1, 2, 3 };
                int[] freq = new int[] { 49, 0, 50 };              
             */
            int[] prefix = new int[n];
            prefix[0] = freq[0];
            for (int i = 1; i < n; i++)
            {
                prefix[i] = prefix[i - 1] + freq[i];
            }

            //https://msdn.microsoft.com/en-us/library/ctssatww(v=vs.110).aspx
            //By having different seed value to Random constructor which will leads to generate different set of random numbers for each run
            //Random random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            Random random = new Random((int)DateTime.Now.Ticks);

            // prefix[n-1] is sum of all frequencies. Generate a random number
            // with value from 1 to this sum
            int r =(random.Next(1, prefix[n-1]) % prefix[n - 1]) +1; // random.Next(1, prefix[n - 1]); 

            // Find index of ceiling of r in prefix array
            int indexc = FindCeil(prefix, r, 0, n - 1);
            return arr[indexc];
        }

        private void btn_Random_number_generator_in_arbitrary_probability_distribution_fashion_Click(object sender, EventArgs e)
        {
            /*
             * https://www.geeksforgeeks.org/random-number-generator-in-arbitrary-probability-distribution-fashion/
               Time Complexity   : O(n)
               Space Complexity  : O(n)
            */

            int[] arr = new int[] { 1, 2, 3 };
            int[] freq = new int[] { 49, 0, 50 };
            StringBuilder resultBuilder = new StringBuilder();

            // Use a different seed value for every run.

            // Let us generate 10 random numbers accroding to
            // given distribution
            Dictionary<int, int> result = new Dictionary<int, int>();
            int output = 0;
            for (int i = 0; i < 100; i++)
            {

                output = this.Get_Arbitrary_Probability_Distribution_Fashion(arr, freq, arr.Length);
                if (result.ContainsKey(output))
                {
                    result[output]++;
                }
                else
                {
                    result.Add(output, 1);
                }
                
            }
            foreach(var key in result.Keys)
            {
                   resultBuilder.Append($"{key} occurence {result[key]} \n");
            }
            MessageBox.Show($"Random number generator in arbitrary probability distribution {resultBuilder.ToString()}");

        }

        private void btn_Sum_the_first_two_min_elements_from_the_given_array_Click(object sender, EventArgs e)
        {
            /*
                Time Complexity     : O(n)
                Space Complexity    : Since we are not using any addition memory even for swapping.
                input = 1   3   4   6   2    
            firstMin = -1, secondMin = 1
            */
            //int[] input = new int[] { 4, 3, 2, 1, 4, -1 };
            int[] input = new int[] { 3, 5, 4, 1, 4, -1 };
            int firstMin = input[0];
            int secondMin = input[1];

            //Swapping firstMin and secondMin if secondMin is less than second min
            if (secondMin < firstMin)
            {
                secondMin = firstMin + secondMin;
                firstMin = secondMin - firstMin;
                secondMin = secondMin - firstMin;
            }


            for (int i = 2; i < input.Length; i++)
            {       
                if (secondMin > input[i] && firstMin > input[i]) //When firstMin and SecondMin values are greater than currentValue
                {
                    secondMin = firstMin;
                    firstMin = input[i];
                }
                else if (secondMin > input[i] && firstMin < input[i]) //When second value is greater and firstMin value is less than currentValue
                {
                    secondMin = input[i];
                }
            }

            MessageBox.Show($"First Min value :  {firstMin.ToString()} Second Min value : {secondMin.ToString()} Sum : {(firstMin + secondMin).ToString()}");

        }

        private void btn_Arrange_all_zero_in_an_array_toward_right_Click(object sender, EventArgs e)
        {
           
            /*
                Time Complexity     : O(n) - for 1 array, from our input we have list of arrays n being the # of items in single array and
                                      m being the list of arrays so the Time complexity will be O(m*n)
                Space Complexity    : Since we are not using any addition memory even for swapping.
             */

            Dictionary<int, int[]> inputs = new Dictionary<int, int[]>();

            inputs.Add(1, new int[] { 1, 2, 3, 4, 5, 6 });
            inputs.Add(2, new int[] { 1, 0, 2, 0, 3, 0 });
            inputs.Add(3, new int[] { 1, 2, 3, 0, 0, 0 });
            inputs.Add(4, new int[] { 0, 0, 0, 1, 2, 3 });
            inputs.Add(5, new int[] { 0, 0, 0, 1, 0, 0 });
            int lastIndexOfZero = 0;
            StringBuilder result = new StringBuilder();

            foreach (int key in inputs.Keys)
            {
                lastIndexOfZero = 0;
                var input = inputs[key];
                           
                result.Append($"Before swap input array :  {Display(input)} \n");                
                for (int i = 1; i < input.Length; i++)
                {                    
                    if (input[lastIndexOfZero] == 0 && input[i] != 0)
                    {
                        this.Swap(input, lastIndexOfZero, i);
                        lastIndexOfZero++;
                    }
                    else if (input[lastIndexOfZero] != 0)
                    {
                        lastIndexOfZero++;
                    }


                }
                result.Append($"After swap input array: {Display(input)} \n");
            }
            

            MessageBox.Show(result.ToString());
        }

        private void Swap(int[] array, int i, int j)
        {
            array[i] = array[i] + array[j];
            array[j] = array[i] - array[j];
            array[i] = array[i] - array[j];
        }

        private void btn_Max_sub_series_sum_in_an_given_array_Click(object sender, EventArgs e)
        {
            //int[]  input = new int[] { -2, -3, 4, -1, -2, 1, 5, -3 };
            int[] input = new int[] {31, -41, 26, 59, -53, 58, 97, -93, -23, 84};
            int[,] t =  new int[4, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
         
            List<int> result = new List<int>() { 1,2};
             
            int maxSum = 0;
            int sum = 0;
            int startIndex = 0;
            int endIndex = 0;

            if (input==null && input.Length > 0)
            {
                MessageBox.Show("Input array is empty");
            }

            for(int i = 0; i <input.Length; i++)
            {
                sum += input[i];
                if (sum > maxSum)
                {
                    maxSum = sum;
                    endIndex = i;
                }

                if (sum <= 0)
                {
                    maxSum = 0;
                    sum = 0;
                    if (i + 1 < input.Length)
                    {
                        startIndex = i + 1;
                    }
                    endIndex = 0;
                }
            }

            MessageBox.Show($"Largest Subarray Sum in array is {maxSum.ToString()} for the starting index {startIndex.ToString()} and ending index {endIndex.ToString()}");
        }

        private void btn_Reduce_Array_After_removing_input_element_Click(object sender, EventArgs e)
        {
            //int[] input = new int[] { 1, 3, 4, 6, 7, 10, 4, 9};
            //int[] input = new int[] { 1, 3, 4};
            int[] input = new int[] { 1, 4, 3 };
            //int[] input = new int[] { 4, 4 , 4};
            //int[] input = new int[] { 4};
            //int[] input = new int[] { };

            int removeElement = 4;
            int index = -1;
            int i = 0;
            int arraySize = 0;
            for (i = 0; i< input.Length; i++)
            {                
                if (index == -1 && input[i] == removeElement)
                {
                    index = i;
                }
                else if (index > 0 && input[i]!=removeElement)
                {
                    input[index] = input[i];
                    index++;
                }                
            }

            if (index > 0)            
            {                
              arraySize = index;                
            }

            Array.Resize(ref input, arraySize);

            MessageBox.Show(string.Join(",", input));
        }

        private void btn_Find_all_the_integer_value_lies_in_a_array_till_N_Click(object sender, EventArgs e)
        {
            int[] input = new int[] { 1, 2, 3, 3 }; // new int[] { 1, 3, 4, 6, 7, 10, 4, 9 };
            int x = 0;
            for(int i = 0; i<input.Length; i++)
            {
                x |= 1 << (input[i] - 1);
            }

            MessageBox.Show($"All integers for the given input array is {(x == (1<<input.Length)-1 ? "present": "is not present")}");

        }

        private int RobHouse(int[] input, int start, int end)
        {
            int firstOld = 0;
            int secondOld = 0;
            int thirdOld = 0;

            if (input != null && input.Length > 0 && (start < end))
            {
                if (input.Length == 1)
                {
                    return input[0];
                }

                firstOld = input[start];
                secondOld = Math.Max(firstOld, (end - start) >= 2 ? input[start + 1] : secondOld);
                if (end <= 2)
                {
                    thirdOld = Math.Max(firstOld, secondOld);
                }

                int i = 0;
                for (i = start + 2; i < end; i++)
                {
                    thirdOld = Math.Max(input[i] + firstOld, secondOld);
                    firstOld = secondOld;
                    secondOld = thirdOld;
                }
            }
            return thirdOld;
        }

        private void btn_Robbing_a_home_1_Click(object sender, EventArgs e)
        {
            /*
            Time Complexity is O(N)
            Space Complexity is O(1)              
            */
            int[][] inputs = new int[6][];
            inputs[0] = new int[] { 6, 7, 1, 3, 8, 2, 4 };
            inputs[1] = new int[] { 5, 3, 4, 11, 2 };
            inputs[2] = new int[] { };
            inputs[3] = new int[] { 0 };
            inputs[4] = new int[] { 1 };
            inputs[5] = new int[] { 0, 1 };

            StringBuilder result = new StringBuilder();
            int firstOld = 0;
            int secondOld = 0;
            int thirdOld = 0;
            foreach (int[] input in inputs)
            {
                result.AppendLine($"The max value robbed in this house { (input.Length == 0 ? "Empty" : string.Join(",", input))} is {RobHouse(input, 0, input.Length).ToString()}");
            }

            MessageBox.Show(result.ToString());
        }

        private void btn_Robbing_a_home_2_Click(object sender, EventArgs e)
        {
            /*
               You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed. 
               All houses at this place are arranged in a circle. That means the first house is the neighbor of the last one. Meanwhile, 
               adjacent houses have security system connected and it will automatically contact the police if two adjacent houses were 
               broken into on the same night.

               Given a list of non-negative integers representing the amount of money of each house, determine the maximum amount of 
               money you can rob tonight without alerting the police.             

               Time Complexity is O(N)
               Space Complexity is O(1)
           */
            int[][] inputs = new int[7][];
            inputs[0] = new int[] { 6, 7, 1, 3, 8, 2, 4 };
            inputs[1] = new int[] { 5, 3, 4, 11, 2 };
            inputs[2] = new int[] { };
            inputs[3] = new int[] { 0 };
            inputs[4] = new int[] { 1 };
            inputs[5] = new int[] { 0, 1 };
            inputs[6] = new int[] { 0, 0 };



            StringBuilder result = new StringBuilder();
            int zeroToN_1 = 0;
            int oneToN = 0;
            foreach (int[] nums in inputs)
            {
                zeroToN_1 = this.RobHouse(nums, 0, nums.Length - 1);
                oneToN = this.RobHouse(nums, 1, nums.Length);
                result.AppendLine($"The zeroToN_1 is {zeroToN_1.ToString()} and oneToN {oneToN.ToString()} value robbed in this house {(nums.Length == 0 ? "Empty" : string.Join(",", nums)) } is {(Math.Max(zeroToN_1, oneToN).ToString())}");
            }

            MessageBox.Show(result.ToString());
        }
    }
}
