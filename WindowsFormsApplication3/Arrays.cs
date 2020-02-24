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
        private int max;

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

            //int[] arr1 = new int[10];
            //arr1[0] = 1;
            //arr1[1] = 2;
            //arr1[2] = 3;
            //arr1[3] = 4;
            //arr1[4] = 5;
            //arr1[5] = 6;
            //arr1[6] = 7;
            //int[] arr2 = new int[3];
            //arr2[0] = 3;
            //arr2[1] = 9;
            //arr2[2] = 10; //Best Case O(n+m)

            int[] arr1 = new int[1];
            arr1[0] = 0;

            int[] arr2 = new int[1];
            arr2[0] = 1;

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
                    i = 8   insert = 4
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
            Array.Resize(ref buffer, insert + 1);



            MessageBox.Show(string.Join(",", buffer));
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
                reductionCost   :   19

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
                //s = 0 e = 9
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
            var binary = string.Empty;
            /*
                60 ->30->15->7->3->
                     0  ->0->1->1->1->1
                     111100
             */

            while (number > 0)
            {
                // Logical AND the number and prepend it to the result string        
                /*
                    2|60
                    2|30 - 0
                    2|15 - 0
                    2|7  - 1
                    2|3  - 1
                    1|1
                        
                 */
                binary = (number & 1) + binary;
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
            //int[] input = new int[] { 3, 3, 4, 2, 1, 4, 4, 2, 4, 4 };
            int[] input = new int[] { 1, 2, 1, 1, 3, 4, 0 };
            int count = 1;
            int majorityIndex = 0;
            int maxOccurance = 1;
            /*
                count = 3;
                majorityIndex = 5;
                maxOccurance = 4; 
                I = 10
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
            /*
                01 
                10
                ---
                11
             */
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
            
            if (b == 0)
            {
                return a;
            }
            return GCD(b, a % b);
            */
            int temp = 0;
            while (b != 0)
            {
                temp = b;
                b = a % b;
                a = temp;
            }

            return a;
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
            /* Instead of moving one by one, divide the array in different sets where number of sets is equal to GCD of n and d and move the elements within sets.             
               If GCD is 1 as is for the above example array(n = 7 and d = 2) */
            int max = this.GCD(d, n);
            for (i = 0; i < max; i++)
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
               Input    : 1    2   3   4   5   6   7    Rotate by 2
               Output   : 3    4   5   6   7   1   2
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
                    int[] nums1 = new int[] { 1, 2, };   1 2 2 3 4 5
                    int[] nums2 = new int[] { 2, 3, 4, 5 };
                    
                    iMin = 0 Max = 2, halfLen = 3, i = 1, j = 2
                    iMin = 1 (iMin +1) Max = 2, halfLen = 3, i = 1, j = 2
                    iMin = 2 (iMin +1) Max = 2, halfLen = 3, i = 2, j = 1
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
                {
                    // i is perfect
                    int maxLeft = 0;
                    if (i == 0) //When A array is empty
                    {
                        maxLeft = B[j - 1];
                    }
                    else if (j == 0) //When B array is empty
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
                    if (i == m) //When A array is empty
                    {
                        minRight = B[j];
                    }
                    else if (j == n) //When B array is empty
                    {
                        minRight = A[i];
                    }
                    else
                    {
                        minRight = Math.Min(B[j], A[i]);
                    }

                    return (maxLeft + minRight) / 2.0;
                }
            }
            return 0.0;
        }

        private void btn_Median_of_Two_sorted_arrays_Click(object sender, EventArgs e)
        {
            /*
                Time Complexity         : O(log (min(m,n))
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

                int[] nums1 = new int[] { 2, 3, 4, 5 };
                int[] nums2 = new int[] { };

                int[] nums1 = new int[] {1, 3 };
                int[] nums2 = new int[] { 1, 2, };


            */

            int[] nums1 = new int[] { 1 };
            int[] nums2 = new int[] { 1 };


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

                MessageBox.Show($"Interaction of two sorted arrays are {(intersection.Length > 0 ? intersection.ToString() : "none")} \n" +
                                $"Union of two sorted arrays are {(union.Length > 0 ? union.ToString() : "none")}");
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
        int FindCeil(int[] arr, int r)
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
            int l = 0, h = arr.Length - 1;
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
            // Create and fill prefix arraywV730v(!W10x1106()

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
            //Random random = new Random((int)DateTime.Now.Ticks);
            Random random = new Random();


            // prefix[n-1] is sum of all frequencies. Generate a random number
            // with value from 1 to this sum
            int r = (random.Next(1, prefix[n - 1]) % prefix[n - 1]) + 1; // random.Next(1, prefix[n - 1]); 

            // Find index of ceiling of r in prefix array
            int indexc = FindCeil(prefix, r);
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
            foreach (var key in result.Keys)
            {
                resultBuilder.Append($"{key} occurence {result[key]} \n");
            }
            MessageBox.Show($"Random number generator in arbitrary probability distribution {resultBuilder.ToString()}");

        }

        private void btn_Sum_the_first_two_min_elements_from_the_given_array_Click(object sender, EventArgs e)
        {
            /*
                Time Complexity     : O(n)
                Space Complexity    : O(1)
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
                Time Complexity     : O(n) - for 1st array, from our input we have list of arrays, n being the # of items in single array and
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
                int l = 0;
                int r = input.Length - 1;
                while (l <= r)
                {
                    if (input[l] == 0)
                    {
                        l++;
                    }
                    else if (input[l] > 0 && input[r] == 0)
                    {
                        Swap(input, l, r);
                    }
                    else
                    {
                        r--;
                    }
                }


                //for (int i = 1; i < input.Length; i++)
                //{
                //    if (input[lastIndexOfZero] == 0 && input[i] != 0)
                //    {
                //        this.Swap(input, lastIndexOfZero, i);
                //        lastIndexOfZero++;
                //    }
                //    else if (input[lastIndexOfZero] != 0)
                //    {
                //        lastIndexOfZero++;
                //    }
                //}

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
            /*int[]  input = new int[] { -2, -3, 4, -1, -2, 1, 5, -3 };
             Input: [-2,1,-3,4,-1,2,1,-5,4],
             */

            List<int[]> inputs = new List<int[]>();
            inputs.Add(new int[] { 31, -41, 26, 59, -53, 58, 97, -93, -23, 84 });
            inputs.Add(new int[] { -2, -1 });
            inputs.Add(new int[] { });
            inputs.Add(new int[] { 4, -1, 2 });
            inputs.Add(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 });

            StringBuilder result = new StringBuilder();

            foreach (int[] input in inputs)
            {
                int maxSum = int.MinValue;
                int sum = 0;
                int startIndex = 0;
                int endIndex = 0;

                if (input == null || input.Length == 0)
                {
                    result.Append("Input array is empty \n");
                    continue;
                }

                for (int i = 0; i < input.Length; i++)
                {
                    //31, -41, 26, 59, -53, 58, 97, -93, -23, 84
                    sum += input[i];

                    if (sum < input[i])
                    {
                        sum = input[i];
                        startIndex = i;
                    }

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        endIndex = i;
                    }

                    //if (sum > maxSum)
                    //{
                    //    maxSum = sum;
                    //    endIndex = i;
                    //}

                    //if (sum <= 0)
                    //{
                    //    maxSum = 0;
                    //    sum = 0;
                    //    if (i + 1 < input.Length)
                    //    {
                    //        startIndex = i + 1;
                    //    }
                    //    endIndex = 0;
                    //}
                }
                result.Append($"Largest Subarray Sum in array is {maxSum.ToString()} for the given array {string.Join(" ", input)} starting index {startIndex.ToString()} and ending index {endIndex.ToString()} \n");
            }
            MessageBox.Show(result.ToString());
        }

        private void btn_Reduce_Array_After_removing_input_element_Click(object sender, EventArgs e)
        {
            //int[] input = new int[] { 1, 3, 4, 6, 7, 10, 4, 9};
            //int[] input = new int[] { 1, 3, 4};
            //int[] input = new int[] { 1, 4, 3 };
            //int[] input = new int[] { 4, 4 , 4};
            //int[] input = new int[] { 4};
            //int[] input = new int[] { };
            //int[] input = new int[] { 3,2,2,3 }; //3
            //int[] input = new int[] { 0, 1, 2, 2, 3, 0, 4, 2 };
            int[] input = new int[] { 0, 1, 3, 4, 5, 6 };
            int removeElement = 2;
            int index = -1;
            int i = 0;
            for (i = 0; i < input.Length; i++)
            {
                // index = 5 i = 7
                if (index == -1 && input[i] == removeElement)
                {
                    index = i;
                }
                else if (index >= 0 && input[i] != removeElement)
                {
                    input[index] = input[i];
                    index++;
                }
            }

            if (index > 0)
            {
                Array.Resize(ref input, index);
            }



            MessageBox.Show(string.Join(",", input));
        }

        private void btn_Find_all_the_integer_value_lies_in_a_array_till_N_Click(object sender, EventArgs e)
        {
            int[] input = new int[] { 4, 2, 1, 3 }; //new int[] { 1, 2, 3, 3 }; //
            int x = 0;
            for (int i = 0; i < input.Length; i++)
            {
                x |= 1 << (input[i] - 1); //
            }

            MessageBox.Show($"All integers for the given input array is {(x == (1 << input.Length) - 1 ? "present" : "is not present")}");

        }

        private int RobHouse(int[] input, int start, int end)
        {

            /*
                int[][] inputs = new int[8][];
                inputs[0] = new int[] { 6, 7, 1, 3, 8, 2, 4 };
                inputs[1] = new int[] { 5, 3, 4, 11, 2 };
                inputs[2] = new int[] { };
                inputs[3] = new int[] { 0 };
                inputs[4] = new int[] { 1 };
                inputs[5] = new int[] { 0, 1 };
                inputs[6] = new int[] { 2, 4, 6, 2, 5 };
                inputs[7] = new int[] { 5, 1, 1, 5 };
             */

            int firstOld = 0;
            int secondOld = 0;
            int thirdOld = 0;

            if (input != null && input.Length > 0 && (start < end))
            {
                if (input.Length == 1)
                {
                    return input[0];
                }


                // 6, 7, 1, 3, 8, 2, 4
                firstOld = input[start];            //6
                secondOld = input[start + 1]; //7
                if (end <= 2)
                {
                    thirdOld = Math.Max(firstOld, secondOld);
                    return thirdOld;
                }

                int i = 0;
                for (i = 2; i < end; i++) // 6
                {
                    thirdOld = Math.Max(input[i] + firstOld, secondOld); //
                    firstOld = secondOld; //12
                    secondOld = thirdOld; //15
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
            int[][] inputs = new int[8][];
            inputs[0] = new int[] { 6, 7, 1, 3, 8, 2, 4 };
            inputs[1] = new int[] { 5, 3, 4, 11, 2 };
            inputs[2] = new int[] { };
            inputs[3] = new int[] { 0 };
            inputs[4] = new int[] { 1 };
            inputs[5] = new int[] { 0, 1 };
            inputs[6] = new int[] { 2, 4, 6, 2, 5 };
            inputs[7] = new int[] { 5, 1, 1, 5 };

            StringBuilder result = new StringBuilder();

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

            /*
             Index  :   0   1   2   3   4   5   6
             Input  :   6   7   1   3   8   2   4
            */

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

        private void btn_Array_Puzzle_1_Click(object sender, EventArgs e)
        {

            /* https://www.geeksforgeeks.org/product-array-puzzle-set-2-o1-space/
             
            Given an array arr[] of n integers, construct a Product Array prod[] (of same size) such that prod[i] is 
            equal to the product of all the elements of arr[] except arr[i]. Solve it without division 
            operator and in O(n).

            Example:

            Input : arr[] = {10, 3, 5, 6, 2}
            Output : prod[] = {180, 600, 360, 300, 900}

            Time Complexity     :   O(n)   
            Space Complexity    :   O(n)

             */


            StringBuilder result = new StringBuilder();
            int[] input = new int[] { 1, 2, 3, 4, 5 };
            int n = input.Length;

            int i, temp = 1;

            /* Allocate memory for the product 
            array */
            int[] prod = Enumerable.Repeat(1, n).ToArray<int>();


            /* In this loop, temp variable contains 
            product of elements on left side 
            excluding arr[i] */
            for (i = 0; i < n; i++)
            {
                /* 0 : 1  t : 1         input[0] = 1
                   1 : 1  t : 1         input[1] = 2
                   2 : 2  t : 2         input[2] = 3
                   3 : 6  t : 6         input[3] = 4
                   4 : 24 t : 24        input[4] = 5
                */
                prod[i] = temp;
                temp *= input[i];
            }

            /* Initialize temp to 1 for product on  
            right side */
            temp = 1;

            /* In this loop, temp variable contains 
            product of elements on right side  
            excluding arr[i] */
            for (i = n - 1; i >= 0; i--)
            {
                /* 
                    input
                    0 : 1
                    1 : 2
                    2 : 3
                    3 : 4
                    4 : 5

                     p
                     0 : 1  t : 1
                     1 : 1  t : 2
                     2 : 2  t : 6
                     3 : 6  t : 24
                     4 : 24 t : 120

                     t : 1 
                     4 : 24    t : 5  
                     3 : 30    t : 20
                     2 : 40    t : 60
                     1 : 60    t : 120
                     0 : 120   t : 120 
               */

                prod[i] *= temp;
                temp *= input[i];
            }

            /* print the constructed prod array */
            for (i = 0; i < n; i++)
                result.Append(prod[i].ToString() + " ");

            MessageBox.Show(result.ToString());

            //double EPS = 1e-9;
            //double sum = 0;
            //for (int i = 0; i < n; i++)
            //    sum += Math.Log10(input[i]);

            //// output product for each  
            //// index anti log to find 
            //// original product value 
            //for (int i = 0; i < n; i++)
            //    result.Append((int)EPS + (Math.Pow(10.00,
            //                   sum - Math.Log10(input[i]))) + " ");

            //MessageBox.Show(result.ToString());
        }

        private void btn_Robbing_a_home_3_Click(object sender, EventArgs e)
        {
            //Refer LinkedListForm.cs;
            LinkedListForm form = new LinkedListForm();
            form.btn_Robbing_a_home_3_Click(sender, e);
        }

        private void btn_Arrange_Char_Array_R_G_B_In_Place_Click(object sender, EventArgs e)
        {
            char[] inputs = new char[] { 'G', 'R', 'R', 'G', 'B', 'B', 'G' };

            int l = 0;
            int h = inputs.Length - 1;
            int m = 0;
            char t;
            StringBuilder result = new StringBuilder();
            result.Append("Input character array \nbefore arranging : " + string.Join(",", inputs));

            while (m <= h) // l = 2, m = 4, h = 4
            {

                /*
                        'G','R','R','G','B','B','G'
                        'R','G','R','G','B','B','G'
                        'R','R','G','G','B','B','G'
                        'R','R','G','G','G','B','B'


                 */
                switch (inputs[m])
                {
                    case 'R':
                        {
                            t = inputs[m];
                            inputs[m] = inputs[l];
                            inputs[l] = t;
                            l++;
                            m++;
                            break;
                        }
                    case 'G':
                        {
                            m++;
                            break;
                        }
                    case 'B':
                        {
                            t = inputs[h];
                            inputs[h] = inputs[m];
                            inputs[m] = t;
                            h--;
                            break;
                        }
                }
            }
            result.Append("\nafter arranging : " + string.Join(",", inputs));

            MessageBox.Show(result.ToString());
        }

        private void btn_Finding_Missing_Integer_from_the_given_array_Click(object sender, EventArgs e)
        {
            /* This code will work only if you missing anyone number and if you have only one zero or 
             * one -negative number.
             
              Time Complexity is O(N) Linear time
              Space Complexity is O(1)


             */

            //Wrong solution revisit

            StringBuilder result = new StringBuilder();

            List<int[]> inputs = new List<int[]>();
            inputs.Add(new int[] { 1, 2, 3, 0, 4 }); // 0 
            inputs.Add(new int[] { 1, 2, 0, 4, 5 }); //3
            inputs.Add(new int[] { 4, 3, 0, 2, 1 }); // 0
            inputs.Add(new int[] { 3, 4, 0, 7, 2, 1, 6 }); //5
            inputs.Add(new int[] { }); // 0

            foreach (int[] input in inputs)
            {
                int missing = 0;
                if (input.Length == 0)
                {
                    result.AppendLine("Input array is empty");
                    continue;
                }

                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] <= 0)
                    {
                        missing ^= i ^ 0;
                    }
                    else
                    {
                        missing ^= i ^ input[i];
                    }
                }

                result.AppendLine($"Missing number is {missing} for the given array {string.Join(" ", input)}");

            }

            MessageBox.Show(result.ToString());

            /*int[] nums = new int[] { 1,2,3,5 };
            int missing = nums.Length;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] <= 0)
                {
                    missing ^= i ^ 0;
                }
                else
                {
                    missing ^= i ^ nums[i];
                }
            }

            MessageBox.Show($"Missing number is {missing.ToString()}");
            */

        }

        private void btn_No_of_ways_to_Encode_for_the_given_int_array_based_on_A_Z_Click(object sender, EventArgs e)
        {
            /*
                Given the mapping a = 1, b = 2, ... z = 26, and an encoded message, count the number of ways it can be decoded.
                For example, the message '111' would give 3, since it could be decoded as 'aaa', 'ka', and 'ak'.

                Time Complexity  : O(n)
                Space Complexity : O(1)
            */

            int[] input = new int[] { 1, 2, 3, 9 };

            int first = 1;
            int second = 1;
            int third = 0;

            if (input.Length > 0)
            {
                if (input.Length == 1)
                {
                    third = 1;
                }

                for (int i = 2; i <= input.Length; i++)
                {
                    //i = 4

                    if (input[i - 1] > 0)
                    {
                        third = second; // 3
                    }

                    if ((input[i - 2] == 1) || (input[i - 2] == 2 && input[i - 1] < 7))
                    {
                        third += first; //3
                        first = second; //2
                        second = third; //3
                    }
                }

                MessageBox.Show($"We can decode {third} times for the given int array { string.Join(",", input)}");

            }

        }

        private void btn_Length_Of_The_Longest_Increasing_Subsequence_Click(object sender, EventArgs e)
        {
            /*
             Given an array of numbers, find the length of the longest increasing subsequence in the array. 
             The subsequence does not necessarily have to be contiguous.
             For example, given the array [0, 8, 4, 12, 2, 10, 6, 14, 1, 9, 5, 13, 3, 11, 7, 15], the longest increasing 
             subsequence has length 6: it is 0, 2, 6, 9, 11, 15.

             Time Complexity  : O(nlogn) -->Binary Search complexity is Log n and we are doing this for n items
             Space Complexity : O(n)     -->Worst case scenario we are storing n items in the new memory.
             */
            int[] inputs = new int[] { 0, 8, 4, 12, 2, 10, 6, 14, 1, 9, 5, 13, 3, 11, 7, 15 };

            int[] dp = new int[inputs.Length];
            int len = 0;
            foreach (int input in inputs)
            {
                //https://www.geeksforgeeks.org/how-to-use-array-binarysearch-method-in-c-sharp-set-1/#3rd
                int i = Array.BinarySearch(dp, 0, len, input);
                if (i < 0)
                {
                    i = -(i + 1);
                }
                dp[i] = input;
                if (i == len)
                {
                    len++;
                }
            }

            MessageBox.Show($"Length of the longest increasing subquence of a given array {string.Join(",", inputs)} is {len} and subsequence array is {string.Join(",", dp)}");

        }

        private void btn_Validate_Email_and_Count_Valid_Emails_Click(object sender, EventArgs e)
        {
            /*
                Every email consists of a local name and a domain name, separated by the @ sign.
                For example, in alice@leetcode.com, alice is the local name, and leetcode.com is the domain name.
                Besides lowercase letters, these emails may contain '.'s or '+'s.
                If you add periods ('.') between some characters in the local name part of an email address, mail 
                sent there will be forwarded to the same address without dots in the local name.  
                For example, "alice.z@leetcode.com" and "alicez@leetcode.com" forward to the same email address.  
                (Note that this rule does not apply for domain names.)
                If you add a plus ('+') in the local name, everything after the first plus sign will be ignored. This allows certain 
                emails to be filtered, 
                for example m.y+name@email.com will be forwarded to my@email.com.  (Again, this rule does not apply for domain names.)
                It is possible to use both of these rules at the same time.
                Given a list of emails, we send one email to each address in the list.  How many different addresses actually receive mails? 

                Example 1:

                Input: ["test.email+alex@leetcode.com","test.e.mail+bob.cathy@leetcode.com","testemail+david@lee.tcode.com"]
                Output: 2
                Explanation: "testemail@leetcode.com" and "testemail@leetcode.com" actually receive mails 

                Note:
                1 <= emails[i].length <= 100
                1 <= emails.length <= 100
                Each emails[i] contains exactly one '@' character.
                All local and domain names are non-empty.
                Local names do not start with a '+' character.

             */

            string[] emails = new string[] {"fg.r.u.uzj+o.pw@kziczvh.com", "r.cyo.g+d.h+b.ja@tgsg.z.com", "fg.r.u.uzj+o.f.d@kziczvh.com",
                                            "r.cyo.g+ng.r.iq@tgsg.z.com", "fg.r.u.uzj+lp.k@kziczvh.com", "r.cyo.g+n.h.e+n.g@tgsg.z.com",
                                            "fg.r.u.uzj+k+p.j@kziczvh.com", "fg.r.u.uzj+w.y+b@kziczvh.com", "r.cyo.g+x+d.c+f.t@tgsg.z.com",
                                             "r.cyo.g+x+t.y.l.i@tgsg.z.com", "r.cyo.g+brxxi@tgsg.z.com", "r.cyo.g+z+dr.k.u@tgsg.z.com",
                                            "r.cyo.g+d+l.c.n+g@tgsg.z.com", "fg.r.u.uzj+vq.o@kziczvh.com", "fg.r.u.uzj+uzq@kziczvh.com",
                                            "fg.r.u.uzj+mvz@kziczvh.com", "fg.r.u.uzj+taj@kziczvh.com", "fg.r.u.uzj+fek@kziczvh.com"};
            int result = 0;
            StringBuilder msg = new StringBuilder();
            foreach (string email in emails)
            {
                if (IsValidEmail(email))
                {
                    result++;
                    msg.AppendLine($"This email {email} is valid");
                }
                else
                {
                    msg.AppendLine($"This email {email} is not valid");
                }

            }

            MessageBox.Show($"There are {result} valid emails\n {msg.ToString()}");

        }

        private bool IsValidEmail(string email)
        {
            int index = email.IndexOf('@');
            int counter = 0;

            while (index > 0)
            {
                index = email.IndexOf('.', index + 1);
                if (index > 0)
                {
                    counter++;
                }

                if (counter > 1)
                {
                    break;
                }
            }

            return counter == 1;
        }

        private void btn_Given_array_of_2_integers_which_makes_max_sum_of_min_of_ai_bi_for_all_i_to_n_Click(object sender, EventArgs e)
        {



            /*
                Given an array of 2n integers, your task is to group these integers into n pairs of integer, 
                say (a1, b1), (a2, b2), ..., (an, bn) which makes sum of min(ai, bi) for all i from 1 to n as 
                large as possible.

                Example 1:
                Input: [1,4,3,2]

                Output: 4
                Explanation: n is 2, and the maximum sum of pairs is 4 = min(1, 2) + min(3, 4).
                Note:
                n is a positive integer, which is in the range of [1, 10000].
                All the integers in the array will be in the range of [-10000, 10000].


                n = 3, values in array is will : [1,4,3,2,5,6]
                No of pairs is 3 since n =3.
                {1,4}{3,2},{5,6}, so min all the pairs will be 1,2,5 which has the sum of 8 

                After sorting the array 1, 2, 3, 4, 5, 6, the pairs will be {1,2}{3,4}{5,6}, 
                so min of all the pairs will be 1,3,5 which has the sum of 9 which has the largest value.
              
                Time Complexity : O(nlogn)
                Space Complexity : O(1) 

             */

            List<Array2n> inputs = new List<Array2n>();
            inputs.Add(new Array2n() { N = 2, Data = new int[] { 4, 1, 2, 3 } }); // 1,2,3,4,5,6 = 9
            inputs.Add(new Array2n() { N = 3, Data = new int[] { 4, 5, 6, 1, 2, 3 } }); // 1,2,3,4,5,6 = 9

            StringBuilder result = new StringBuilder();
            string output = string.Empty;
            foreach (Array2n input in inputs)
            {
                output = string.Join(" ", input.Data);
                Array.Sort(input.Data);
                int sum = 0;
                for (int i = 0; i < input.Data.Length; i += 2)
                {
                    sum += input.Data[i];
                }

                MessageBox.Show($"Max sum is {sum} for the given input array is {output} \n");
            }


        }

        public class Array2n
        {
            public int N;
            public int[] Data;

            public Array2n()
            {
                Data = new int[2 * N];
            }
        }

        private void btn_Maximize_Distance_to_Closest_Person_Click(object sender, EventArgs e)
        {
            /*
                In a row of seats, 1 represents a person sitting in that seat, and 0 represents that the 
                seat is empty. There is at least one empty seat, and at least one person sitting.
                Alex wants to sit in the seat such that the distance between him and the closest person to him is maximized. 
                Return that maximum distance to closest person.

                Example 1:

                Input: [1,0,0,0,1,0,1]
                Output: 2
                Explanation: 
                If Alex sits in the second open seat (seats[2]), then the closest person has distance 2.
                If Alex sits in any other open seat, the closest person has distance 1.
                Thus, the maximum distance to the closest person is 2.
                Example 2:

                Input: [1,0,0,0]
                Output: 3
                Explanation: 
                If Alex sits in the last seat, the closest person is 3 seats away.
                This is the maximum distance possible, so the answer is 3.
                Note:

                1 <= seats.length <= 20000
                seats contains only 0s or 1s, at least one 0, and at least one 1.

             */
            List<int[]> inputs = new List<int[]>();
            inputs.Add(new int[] { 1, 0, 0, 0, 1, 0, 1 });
            inputs.Add(new int[] { 1, 0, 0, 0 });
            StringBuilder result = new StringBuilder();
            result.Append("The max distance for the given input arrays are\n");
            foreach (int[] input in inputs)
            {
                int distance = 0;
                int front = 0;
                int previous = -1;
                int left = 0;
                int right = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    //1, 0, 0, 0, 1, 0, 1
                    // i = 6 previous = 6 front = 6 distance = 2 left = 1 right = 1
                    if (input[i] == 1)
                    {
                        previous = i;
                    }
                    else
                    {
                        while (front < input.Length && (input[front] == 0 || front < i))
                        {
                            front++;
                        }

                        left = previous == -1 ? input.Length : i - previous;
                        right = front == input.Length ? input.Length : front - i;
                        distance = Math.Max(distance, Math.Min(left, right));
                    }
                }

                result.Append($"{string.Join(" ", input)} is {distance} \n");
            }
            MessageBox.Show(result.ToString());
        }

        private void btn_Garden_No_Adjacent_Click(object sender, EventArgs e)
        {

            /*
                This problem is equalvent to find the longest subarray with 2 distinct values in it https://leetcode.com/problems/fruit-into-baskets/discuss/170745/C++JavaPython-Longest-Subarray-With-2-Elements

                In a row of trees, the i-th tree produces fruit with type tree[i].
                You start at any tree of your choice, then repeatedly perform the following steps:

                Add one piece of fruit from this tree to your baskets.  If you cannot, stop.
                Move to the next tree to the right of the current tree.  If there is no tree to the right, stop.
                Note that you do not have any choice after the initial choice of starting tree: you must perform step 1, 
                then step 2, then back to step 1, then step 2, and so on until you stop.

                You have two baskets, and each basket can carry any quantity of fruit, but you want each basket to only 
                carry one type of fruit each.

                What is the total amount of fruit you can collect with this procedure?

                Example 1:

                Input: [1,2,1]
                Output: 3
                Explanation: We can collect [1,2,1].
                Example 2:

                Input: [0,1,2,2]
                Output: 3
                Explanation: We can collect [1,2,2].
                If we started at the first tree, we would only collect [0, 1].
                Example 3:

                Input: [1,2,3,2,2]
                Output: 4
                Explanation: We can collect [2,3,2,2].
                If we started at the first tree, we would only collect [1, 2].
                Example 4:

                Input: [3,3,3,1,2,1,1,2,3,3,4]
                Output: 5
                Explanation: We can collect [1,2,1,1,2].
                If we started at the first tree or the eighth tree, we would only collect 4 fruits.
 

                Note:

                1 <= tree.length <= 40000
                0 <= tree[i] < tree.length

                
             */
            List<int[]> inputs = new List<int[]>();
            inputs.Add(new int[] { 1, 2, 1 });
            inputs.Add(new int[] { 0, 1, 2, 2 });
            inputs.Add(new int[] { 1, 2, 3, 2, 2 });
            inputs.Add(new int[] { 3, 3, 3, 1, 2, 1, 1, 2, 3, 3, 4 });
            StringBuilder result = new StringBuilder();
            int last = 0;
            int secondLast = 0;
            int Max = 0;
            int secondMax = 0;
            int final = 0;
            int currentValue = 0;
            foreach (int[] input in inputs)
            {

                /*  1   2   1
                    Last = 0 SecondLast = 0      LastMax = 0        SecondLastMax = 0       Final = 0
                 
                    I       Current Value       Last    SecondLast      LastMax         SecondLastMax       Final  
                    ==============================================================================================
                    0           1                 0         1              1                 1              1
                    1           2                 1         2              2                 1              2
                    2           1                 2         1              3                 1              3
                    
                 */
                currentValue = 0;
                last = 0;
                secondLast = 0;
                max = 0;
                secondMax = 0;
                final = 0; //
                for (int i = 0; i < input.Length; i++)
                {
                    currentValue = input[i];
                    max = currentValue == last || currentValue == secondLast ? max + 1 : secondMax + 1;
                    secondMax = currentValue == secondLast ? secondMax + 1 : 1;

                    if (currentValue != secondLast)
                    {
                        last = secondLast;
                        secondLast = currentValue;
                    }

                    final = Math.Max(final, max);
                }

                result.Append($"Longest subarray is {final} for the array {string.Join(" ", input)} \n");

            }

            MessageBox.Show(result.ToString());
        }

        private void btn_Garden_with_flower_type_Click(object sender, EventArgs e)
        {
            /*
                You have N gardens, labelled 1 to N.  In each garden, you want to plant one of 4 types of flowers. 
                paths[i] = [x, y] describes the existence of a bidirectional path from garden x to garden y.
                Also, there is no garden that has more than 3 paths coming into or leaving it.
                Your task is to choose a flower type for each garden such that, for any two gardens connected by a path, they have different types of flowers.
                Return any such a choice as an array answer, where answer[i] is the type of flower planted in the (i+1)-th garden.  
                The flower types are denoted 1, 2, 3, or 4.  It is guaranteed an answer exists.

                Example 1:

                Input: N = 3, paths = [[1,2],[2,3],[3,1]]
                Output: [1,2,3]
                Example 2:

                Input: N = 4, paths = [[1,2],[3,4]]
                Output: [1,2,1,2]
                Example 3:

                Input: N = 4, paths = [[1,2],[2,3],[3,4],[4,1],[1,3],[2,4]]
                Output: [1,2,3,4]

                Note:

                1 <= N <= 10000
                0 <= paths.size <= 20000
                No garden has 4 or more paths coming into or leaving it.
                It is guaranteed an answer exists.

                Complexity: 
                Time O(N) with O(paths) = O(1.5N)
                Space O(N)
             */

            List<Gardens> inputs = new List<Gardens>();

            inputs.Add(new Gardens
            {
                GardensCordinates = new List<GardensCordinates>() {
                                                                        new GardensCordinates() {X= 1, Y=2 },
                                                                        new GardensCordinates() {X= 2, Y=3 },
                                                                        new GardensCordinates() {X= 3, Y=1 }
                                                                  },
                NoOfGardens = 3
            });

            inputs.Add(new Gardens
            {
                GardensCordinates = new List<GardensCordinates>() {
                                                                        new GardensCordinates() {X= 1, Y=2 },
                                                                        new GardensCordinates() {X= 3, Y=4 }

                                                                  },
                NoOfGardens = 4
            });
            inputs.Add(new Gardens
            {
                GardensCordinates = new List<GardensCordinates>() {
                                                                        new GardensCordinates() {X= 1, Y=2 },
                                                                        new GardensCordinates() {X= 2, Y=3 },
                                                                        new GardensCordinates() {X= 3, Y=4 },
                                                                        new GardensCordinates() {X= 4, Y=1 },
                                                                        new GardensCordinates() {X= 1, Y=3 },
                                                                        new GardensCordinates() {X= 2, Y=4 }
                                                                  },
                NoOfGardens = 4
            });

            StringBuilder result = new StringBuilder();

            foreach (var input in inputs)
            {
                int[] flowerTypeForGarden = Enumerable.Repeat(1, input.NoOfGardens).ToArray<int>();
                bool proceed = true;
                int min = 0;
                int max = 0;

                while (proceed)
                {
                    proceed = false;
                    foreach (GardensCordinates cord in input.GardensCordinates)
                    {
                        min = Math.Min(cord.X, cord.Y);
                        max = Math.Max(cord.X, cord.Y);

                        if (flowerTypeForGarden[min - 1] == flowerTypeForGarden[max - 1])
                        {
                            proceed = true;
                            flowerTypeForGarden[max - 1] = flowerTypeForGarden[max - 1] == 4 ? 1 : flowerTypeForGarden[max - 1] + 1;
                        }
                    }

                }

                result.Append($"The Garden with different flower types are {string.Join(" ", flowerTypeForGarden)} \n");
            }

            MessageBox.Show(result.ToString());

        }

        public class Gardens
        {
            public List<GardensCordinates> GardensCordinates;
            public int NoOfGardens;
        }

        public class GardensCordinates
        {
            public int X;
            public int Y;

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btn_Given_a_list_of_tasks_to_run_with_cooldown_interval_find_min_number_of_time_slots_Click(object sender, EventArgs e)
        {
            /*
                Given a list of input tasks to run, and the cooldown interval, output the minimum number of time slots required to run them. 
	            Tasks: 1, 1, 2, 1, 2 
	            Recovery interval (cooldown): 2 
	            Output: 8 (order is 1 _ _ 1 2 _ 1 2 ) 

	            Task 1,2,3,1,2,3
	            Recovery interval (cooldown): = 3
	            Output: 7 (order is 1 2 3 _ 1 2 3 )                

                Time Complexity     : O(n)
                Space Complexity    : O(n)
             */

            List<TaskCoolDown> tasks = new List<TaskCoolDown>();
            tasks.Add(new TaskCoolDown() { Task = new int[] { 1, 1, 2, 1, 2 }, Cooldown = 2 }); // 1--12-12
            tasks.Add(new TaskCoolDown() { Task = new int[] { 1, 2, 3, 1, 2, 3 }, Cooldown = 3 }); // 123-123
            StringBuilder message = new StringBuilder();

            foreach (var task in tasks)
            {
                /*  
                    1, 1, 2, 1, 2               2
                    1--1,2-1,2
                   
                    Dictionary
                    1- 6
                    2-0                    
                 */

                Dictionary<int, int> taskEntry = new Dictionary<int, int>();
                int result = 0;
                int taskIndex = 0;
                int last = 0;
                while (taskIndex < task.Task.Length)
                {
                    if (!taskEntry.ContainsKey(task.Task[taskIndex]))
                    {
                        taskEntry[task.Task[taskIndex]] = result;
                        taskIndex++;
                    }
                    else
                    {
                        // result = 8 taskIndex = 5
                        last = taskEntry[task.Task[taskIndex]]; // 1 --> 6, 2 -->7
                        if ((result - last) > task.Cooldown)
                        {
                            taskEntry[task.Task[taskIndex]] = result;
                            taskIndex++;
                        }
                    }
                    result++;
                }

                message.Append($"The minimum number of time slots required to run is {result} to run {string.Join(" ", task.Task)} \n ");

            }
            MessageBox.Show(message.ToString());

        }

        public class TaskCoolDown
        {
            public int[] Task;
            public int Cooldown;
        }

        private void btn_Find_Peak_in_an_integer_array_Click(object sender, EventArgs e)
        {

            /*                
                Time Complexity  : O(log N)
                Space Complexity : Constant space O(1)
            */

            List<int[]> inputs = new List<int[]>();
            inputs.Add(new int[] { 2, 3, 4, 5, 6, 7, 8, 10, 9 }); // 7
            inputs.Add(new int[] { -4, -3, -2, -1, 1, 2, 3, 0 }); // 7
            inputs.Add(new int[] { 9, 10, 1, 2, 3 }); // 1
            inputs.Add(new int[] { 1 }); // -1
            inputs.Add(new int[] { 1, 2 }); // -1
            inputs.Add(new int[] { 2, 1 }); // 1
            inputs.Add(new int[] { }); // -1
            inputs.Add(new int[] { 1, 2, 3, 1 }); // 2
            inputs.Add(new int[] { 1, 2, 1, 3, 5, 6, 4 }); // 5

            StringBuilder result = new StringBuilder();
            foreach (int[] input in inputs)
            {
                int l = 0;
                int r = input.Length - 1;
                int m = -1;

                if (input.Length == 0 || input.Length == 1)
                {
                    result.Append($"The peak index is -1 for the given int array {string.Join(" ", input)} \n");
                    continue;
                }

                //-4, -3, -2, -1, 1, 2, 3, 0  
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

                result.Append($"The peak index is {m} for the given int array {string.Join(" ", input)} \n");
            }


            MessageBox.Show(result.ToString());
        }

        private void btn_Search_Insert_Position_Click(object sender, EventArgs e)
        {

            /*     
                Given a sorted array and a target value, return the index if the target is found. 
                If not, return the index where it would be if it were inserted in order.
                You may assume no duplicates in the array.

                Example 1:

                Input: [1,3,5,6], 5
                Output: 2
                Example 2:

                Input: [1,3,5,6], 2
                Output: 1
                Example 3:

                Input: [1,3,5,6], 7
                Output: 4
                Example 4:

                Input: [1,3,5,6], 0
                Output: 0 

                Time Complexity  : O(log N)
                Space Complexity : Constant space O(1)
            */

            List<ArrayAndValue> inputs = new List<ArrayAndValue>();
            inputs.Add(new ArrayAndValue() { input = new int[] { 1, 3, 5, 6 }, find = 5 });
            inputs.Add(new ArrayAndValue() { input = new int[] { 1, 3, 5, 6 }, find = 2 });
            inputs.Add(new ArrayAndValue() { input = new int[] { 1, 3, 5, 6 }, find = 7 });
            inputs.Add(new ArrayAndValue() { input = new int[] { 1, 3, 5, 6 }, find = 0 });
            inputs.Add(new ArrayAndValue() { input = new int[] { 1, 3, 5, 6 }, find = 1 });
            inputs.Add(new ArrayAndValue() { input = new int[] { 1 }, find = 1 });
            inputs.Add(new ArrayAndValue() { input = new int[] { 1, 2 }, find = 2 });



            StringBuilder result = new StringBuilder();
            foreach (var sip in inputs)
            {
                result.Append($"The search insert index is {this.FindSearchInsert(sip.input, sip.find)} for the given int array {string.Join(" ", sip.input)} for given search {sip.find}  \n");
            }

            MessageBox.Show(result.ToString());
        }

        private int FindSearchInsert(int[] input, int find)
        {
            int l = 0;
            int r = input.Length - 1;
            int m = -1;
            while (l <= r)
            {
                m = (l + r) / 2;

                if (input[m] == find)
                {
                    return m;
                }
                else if (input[m] < find)
                {
                    l = m + 1;
                }
                else
                {
                    r = m - 1;
                }
            }
            return r + 1;
        }

        private void btn_Find_the_two_elements_that_appear_only_once_Click(object sender, EventArgs e)
        {
            /*                             
               
                Given an array of numbers nums, in which exactly two elements appear only once and all the other elements appear exactly twice. 
                Find the two elements that appear only once.

                Example:
                Input:  [1,2,1,3,2,5]
                Output: [3,5]
                Note:

                The order of the result is not important. So in the above example, [5, 3] is also correct.
                Your algorithm should run in linear runtime complexity. Could you implement it using only constant space complexity?
                https://leetcode.com/problems/single-number-iii/discuss/390157/Python-2-line-and-O(1)-space-solutions-with-explanation
            

                Let us see an example. arr[] = {2, 4, 7, 9, 2, 4}
                1) Get the XOR of all the elements.
                     xor = 2^4^7^9^2^4 = 14 (1110)
                2) Get a number which has only one set bit of the xor.   
                   Since we can easily get the rightmost set bit, let us use it.
                     set_bit_no = xor & ~(xor-1) = (1110) & ~(1101) = 0010
                   Now set_bit_no will have only set as rightmost set bit of xor.
                3) Now divide the elements in two sets and do xor of         
                   elements in each set and we get the non-repeating 
                   elements 7 and 9. Please see the implementation for this step.

            */
            StringBuilder result = new StringBuilder();
            List<int[]> inputs = new List<int[]>();
            inputs.Add(new int[8] { 2, 4, 6, 8, 10, 2, 6, 8 });
            inputs.Add(new int[6] { 2, 4, 7, 9, 2, 4 });
            inputs.Add(new int[8] { 19, 20, 21, 21, 20, 19, 18, 17 });

            foreach (var input in inputs)
            {
                int xor = 0;
                int y = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    xor ^= input[i];
                }

                /* 14 - Binary
                    1110
                    0001 -->1s compliment
                    0001 Adding 1
                    ----
                    0010 --> 2s Compliment

                    1110(14) & 0010 (-14)
                    becomes 2
                 */

                int set_bit_no = xor & ~(xor - 1);
                int x = 0; y = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    if ((input[i] & set_bit_no) > 0)
                    {
                        x = x ^ input[i];
                    }
                    else
                    {
                        y = y ^ input[i];
                    }

                }

                result.AppendLine($"Two unique values are {x} and {y} for the given array {string.Join(" ", input)}");

            }

            MessageBox.Show(result.ToString());




        }

        private void btn_Plus_One_Click(object sender, EventArgs e)
        {
            /*
                Given a non-empty array of digits representing a non-negative integer, plus one to the integer.
                The digits are stored such that the most significant digit is at the head of the list, and each element 
                in the array contain a single digit. You may assume the integer does not contain any leading zero, 
                except the number 0 itself.

                Example 1:

                Input: [1,2,3]
                Output: [1,2,4]
                Explanation: The array represents the integer 123.
                Example 2:

                Input: [4,3,2,1]
                Output: [4,3,2,2]
                Explanation: The array represents the integer 4321. 

             */
            StringBuilder result = new StringBuilder();
            List<int[]> inputs = new List<int[]>();
            inputs.Add(new int[3] { 1, 2, 3 });
            inputs.Add(new int[4] { 9, 9, 9, 9 });
            inputs.Add(new int[4] { 8, 9, 9, 9 });
            foreach (var input in inputs)
            {

                if (input.Length == 0)
                {
                    result.AppendLine("Input array is empty");
                    continue;
                }
                int reminder = 0;

                for (int i = input.Length - 1; i >= 0; i--)
                {

                    input[i] += (i == input.Length - 1 ? 1 : reminder);
                    reminder = 0;

                    if (input[i] == 10)
                    {
                        input[i] = 0;
                        reminder = 1;
                    }
                    else
                    {
                        reminder = 0;
                        break;
                    }
                }

                if (reminder > 0)
                {
                    int[] reminderArray = new int[input.Length + 1];
                    Array.Copy(input, 0, reminderArray, 1, input.Length);
                    reminderArray[0] = reminder;
                    result.AppendLine($"Plus one of the array is {string.Join(" ", reminderArray)}");
                }
                else
                {
                    result.AppendLine($"Plus one of the array is {string.Join(" ", input)}");
                }


            }

            MessageBox.Show(result.ToString());
        }

        private void btn_Min_Max_Sum_Click(object sender, EventArgs e)
        {
            StringBuilder result = new StringBuilder();
            List<int[]> inputs = new List<int[]>();
            inputs.Add(new int[5] { 1, 3, 5, 7, 9 });
            inputs.Add(new int[4] { 1, 2, 3, 4 });
            inputs.Add(new int[4] { 8, 9, 9, 9 });
            inputs.Add(new int[] { });
            foreach (var input in inputs)
            {
                int len = input.Length;
                if (len == 0)
                {
                    result.AppendLine("Input array is empty");
                    continue;
                }

                long min = 0;
                long max = 0;
                long sum = 0;
                int val = 0;

                if (len == 1)
                {
                    result.AppendLine($"Min is {input[0]} Max is {input[0]} for the given array {string.Join(" ", input)}");
                    continue;
                }
                else
                {
                    if (input[0] > input[1])
                    {
                        min = input[1];
                        max = input[0];
                    }
                    else
                    {
                        min = input[0];
                        max = input[1];
                    }

                    sum = min + max;
                }


                for (int i = 2; i < input.Length; i++)
                {
                    val = input[i];
                    sum += val;
                    if (val < min)
                    {
                        min = val;
                    }
                    else if (val > max)
                    {
                        max = val;
                    }
                }

                result.AppendLine($"Min is {sum - max} Max is {sum - min} for the given array {string.Join(" ", input)}");
            }

            MessageBox.Show(result.ToString());
        }

        private void btn_Array_partition_based_on_Pivot_Click(object sender, EventArgs e)
        {
            /*             
                Given a pivot x, and a list lst, partition the list into three parts.

                The first part contains all elements in lst that are less than x
                The second part contains all elements in lst that are equal to x
                The third part contains all elements in lst that are larger than x
                Ordering within a part can be arbitrary.

                For example, given x = 10 and lst = [9, 12, 3, 5, 14, 10, 10], one partition 
                may be [9, 3, 5, 10, 10, 12, 14]. 

                Time Complexity  : O(n)
                Space Complexity : Constanct space            
             */

            List<ArrayAndValue> inputs = new List<ArrayAndValue>();
            inputs.Add(new ArrayAndValue() { input = new int[] { 9, 12, 3, 5, 14, 10, 10 }, find = 10 });
            inputs.Add(new ArrayAndValue() { input = new int[] { }, find = 10 });
            inputs.Add(new ArrayAndValue() { input = new int[] { -1, -3, -4, 0, 1, 2 }, find = -1 });

            StringBuilder result = new StringBuilder();

            int l = 0;
            int m = 0;
            int h = 0;
            int temp = 0;
            string initialArray;
            foreach (var arrayAndValue in inputs)
            {
                int[] input = arrayAndValue.input;
                if (input.Length == 0)
                {
                    result.AppendLine("Array is empty");
                    continue;
                }

                initialArray = string.Join(" ", input);

                l = 0;
                m = 0;
                h = input.Length - 1;
                temp = 0;

                while (m <= h)
                {
                    if (input[m] < arrayAndValue.find)
                    {
                        temp = input[l];
                        input[l] = input[m];
                        input[m] = temp;
                        l++;
                        m++;
                    }
                    else if (input[m] == arrayAndValue.find)
                    {
                        m++;
                    }
                    else
                    {
                        temp = input[h];
                        input[h] = input[m];
                        input[m] = temp;
                        h--;
                    }
                }

                result.AppendLine($"Partition of the array is {string.Join(" ", input)} for the given array {initialArray} ");
            }

            MessageBox.Show(result.ToString());


        }




        public class ArrayAndValue
        {
            public int[] input;
            public int find;
        }

        private void btn_Blow_out_tallest_candles_Click(object sender, EventArgs e)
        {
            /*             
                You are in charge of the cake for your niece's birthday and have decided the cake will have one candle for 
                each year of her total age. When she blows out the candles, she’ll only be able to blow out the tallest ones. 
                Your task is to find out how many candles she can successfully blow out.

                For example, if your niece is turning 4 years old, and the cake will have  candles of height 4, 4, 1, 3,
                she will be able to blow out  candles successfully, since the tallest candles are of height  
                and there are  such candles.

                Function Description

                Complete the function birthdayCakeCandles in the editor below. It must return an integer representing the number
                of candles she can blow out.

                birthdayCakeCandles has the following parameter(s):

                ar: an array of integers representing candle heights
                Input Format

                The first line contains a single integer, n , denoting the number of candles on the cake.
                The second line contains  space-separated integers, where each integer i describes the height of candle  i.

                Constraints

                Output Format

                Return the number of candles that can be blown out on a new line.

                Sample Input 0

                4
                3 2 1 3
                Sample Output 0

                2
                Explanation 0

                We have one candle of height 1, one candle of height 2, and two candles of height 3. Your niece only blows out the
                tallest candles, meaning the candles where height = 3. Because there are 2 such candles, 
                we print 2 on a new line.

                Time Complexity : O(n) where n is the length of the input array
                Space Complexity: Constanct space                
            */

            List<int[]> inputs = new List<int[]>();
            inputs.Add(new int[] { 3, 1, 2, 3 });
            inputs.Add(new int[] { 18, 90, 90, 13, 90, 75, 90, 8, 90, 43 });
            inputs.Add(new int[] { 82, 49, 82, 82, 41, 82, 15, 63, 38, 25 });
            inputs.Add(new int[] { 44, 53, 31, 27, 77, 60, 66, 77, 26, 36 });

            StringBuilder result = new StringBuilder();
            int maxCandle = 0;
            int maxCandleCount = 0;

            foreach (var input in inputs)
            {
                maxCandle = input[0];
                maxCandleCount = 1;

                for (int i = 1; i < input.Length; i++)
                {

                    if (input[i] > maxCandle)
                    {
                        maxCandle = input[i];
                        maxCandleCount = 1;
                    }
                    else if (input[i] == maxCandle)
                    {
                        maxCandleCount++;
                    }

                }
                result.AppendLine($"Candle height is { maxCandle } and count is {maxCandleCount} for the given height of candles {string.Join(" ", input)} ");
            }

            MessageBox.Show(result.ToString());

        }

        private void btn_Between_Sets_Click(object sender, EventArgs e)
        {
            /*
              https://www.hackerrank.com/challenges/between-two-sets/problem?h_r=next-challenge&h_v=zen&h_r=next-challenge&h_v=zen&h_r=next-challenge&h_v=zen
              https://www.hackerrank.com/challenges/between-two-sets/forum

                1. find the LCM of all the integers of array A.
                2. find the GCD of all the integers of array B.
                3. Count the number of multiples (ie 2) of LCM that evenly divides the GCD.

              Time Complexity : O(m + n) + O(log p)  where m is the total elements in array a 
                                                           n is the total elements in array b
                                                           p is number of iteration to find the sets
                                                                    
              */

            StringBuilder result = new StringBuilder();
            List<TwoArrayInputs> inputs = new List<TwoArrayInputs>();
            inputs.Add(new TwoArrayInputs() { a = new int[] { 2, 4 }, b = new int[] { 16, 32, 96 } }); //3
            inputs.Add(new TwoArrayInputs() { a = new int[] { 3, 4 }, b = new int[] { 24, 48 } }); //2
            inputs.Add(new TwoArrayInputs() { a = new int[] { 100, 99, 98, 97, 96, 95, 94, 93, 92, 91 }, b = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 } }); //0
            inputs.Add(new TwoArrayInputs() { a = new int[] { 2 }, b = new int[] { 20, 30, 12 } }); //1
            inputs.Add(new TwoArrayInputs() { a = new int[] { 1 }, b = new int[] { 100 } }); //1
            inputs.Add(new TwoArrayInputs() { a = new int[] { 3, 9, 6 }, b = new int[] { 36, 72 } }); //2       
            inputs.Add(new TwoArrayInputs() { a = new int[] { 1 }, b = new int[] { 100 } }); //9
            inputs.Add(new TwoArrayInputs() { a = new int[] { 51 }, b = new int[] { 50 } }); //0
            inputs.Add(new TwoArrayInputs() { a = new int[] { 2, 3, 6 }, b = new int[] { 42, 84 } }); //2

            int lcm = 0;
            int gcd = 0;
            int counter = 0;
            foreach (var input in inputs)
            {
                counter = 0;
                lcm = this.LCMForArray(input.a);
                gcd = this.GCDForArray(input.b);

                for (int i = lcm, j = 2; i <= gcd; i += lcm, j++)
                {
                    if ((gcd % i) == 0)
                    {
                        counter++;
                    }
                }

                result.AppendLine($"There are {counter} number of integers available between the two arrays a = {string.Join(" ", input.a)} and array b = {string.Join(" ", input.b)}");
            }

            MessageBox.Show(result.ToString());

        }

        public int GCDForArray(int[] input)
        {
            int result = input[0];
            for (int i = 1; i < input.Length; i++)
            {
                result = this.GCD(result, input[i]);
            }
            return result;
        }

        public int LCMForArray(int[] input)
        {
            int result = input[0];
            for (int i = 1; i < input.Length; i++)
            {
                result = (result * input[i]) / this.GCD(result, input[i]);
            }
            return result;
        }

        public class TwoArrayInputs
        {
            public int[] a;
            public int[] b;
        }

        private int LCM(int a, int b)
        {
            return (a * b) / this.GCD(a, b);
        }

        private void btn_Breaking_the_records_Click(object sender, EventArgs e)
        {
            /*
                
                Maria plays college basketball and wants to go pro. Each season she maintains a record of her
                play. She tabulates the number of times she breaks her season record for most points and 
                least points in a game. Points scored in the first game establish her record for the season,
                and she begins counting from there. For example, assume her scores for the season are 
                represented in the array . Scores are in the same order as the games played. She would 
                tabulate her results as follows:

                    Count
                    Game  Score  Minimum  Maximum   Min Max
                     0      12     12       12       0   0
                     1      24     12       24       0   1
                     2      10     10       24       1   1
                     3      24     10       24       1   1

                Given Maria's scores for a season, find and print the number of times she breaks her 
                records for most and least points scored during the season. 

                https://www.hackerrank.com/challenges/breaking-best-and-worst-records/problem?h_r=next-challenge&h_v=zen
            
                Time Complexity  : O(n)
                Space Complexity : Constact space.
             */

            StringBuilder result = new StringBuilder();
            List<int[]> inputs = new List<int[]>();
            inputs.Add(new int[] { 10, 5, 20, 20, 4, 5, 2, 25, 1 });
            inputs.Add(new int[] { 3, 4, 21, 36, 10, 28, 35, 5, 24, 42 });
            inputs.Add(new int[] { 17, 45, 41, 60, 17, 41, 76, 43, 51, 40, 89, 92, 34, 6, 64, 7, 37, 81, 32, 50 });
            inputs.Add(new int[] { 100, 45, 41, 60, 17, 41, 45, 43, 100, 40, 89, 92, 34, 6, 64, 7, 37, 81, 32, 50 });
            inputs.Add(new int[] { 503, 503, 503, 503, 503, 503, 503, 503, 503, 503, 503, 503, 503, 503,
                                   503, 503, 503, 503, 503, 503, 503, 503, 503, 503, 503, 503, 503, 503,
                                   503, 503, 503, 503, 503, 503, 503, 503, 503, 503, 503, 503, 503, 503,
                                   503, 503, 503, 503, 503, 503, 503, 503, 503, 503, 503, 503, 503, 503,
                                   503, 503, 503, 503, 503, 503, 503, 503, 503, 503, 503, 503, 503, 503,
                                   503, 503, 503, 503, 503, 503, 503, 503, 503, 503, 503, 503, 503, 503,
                                   503, 503, 503, 503, 503, 503, 503, 503, 503, 503, 503, 503, 503, 503,
                                   503, 503 });

            foreach (int[] input in inputs) // 10, 5, 20, 20, 4, 5, 2, 25, 1
            {
                int[] returnRes = new int[2];
                if (input.Length > 0)
                {
                    int minS = input[0];
                    int maxS = minS;

                    for (int i = 0; i < input.Length; i++)
                    {
                        if (input[i] < minS)
                        {
                            minS = input[i];
                            returnRes[1]++;
                        }
                        else if (input[i] > maxS)
                        {
                            maxS = input[i];
                            returnRes[0]++;
                        }
                    }

                }
                result.AppendLine($"Max score : {returnRes[0]} and Min score {returnRes[1]} for this game {(string.Join(" ", input))}");
            }

            MessageBox.Show(result.ToString());

        }

        private void btn_BirthDay_Chocolate_Click(object sender, EventArgs e)
        {
            /*
            
                https://www.hackerrank.com/challenges/the-birthday-bar/problem?h_r=next-challenge&h_v=zen&h_r=next-challenge&h_v=zen

                Time Complexity  : O(n)
                Space Complexity : Constact time
            */

            StringBuilder result = new StringBuilder();
            List<BirthDayChocolate> inputs = new List<BirthDayChocolate>();
            inputs.Add(new BirthDayChocolate() { ChocolateBoxNumber = new int[] { 1, 2, 1, 3, 2 }, Birthday = 3, BirthMonth = 2 });
            inputs.Add(new BirthDayChocolate() { ChocolateBoxNumber = new int[] { 1, 1, 1, 1, 1 }, Birthday = 3, BirthMonth = 2 });
            inputs.Add(new BirthDayChocolate() { ChocolateBoxNumber = new int[] { 4, 1 }, Birthday = 1, BirthMonth = 1 });
            inputs.Add(new BirthDayChocolate() { ChocolateBoxNumber = new int[] { 4, 5, 4, 2, 4, 5, 2, 3, 2, 1, 1, 5, 4 }, Birthday = 15, BirthMonth = 4 });
            inputs.Add(new BirthDayChocolate() { ChocolateBoxNumber = new int[] { 2, 2, 2, 1, 3, 2, 2, 3, 3, 1, 4, 1, 3, 2, 2, 1, 2, 2, 4, 2, 2, 3, 5, 3, 4, 3, 2, 1, 4, 5, 4 }, Birthday = 10, BirthMonth = 4 });
            foreach (var input in inputs)
            {
                result.AppendLine($"No of ways cholocates are divided is {this.FindNumberOfBirthdayChocolateCanbeDivide(input.ChocolateBoxNumber, input.Birthday, input.BirthMonth)} for the given array {(string.Join(" ", input.ChocolateBoxNumber))}  birthday {input.Birthday} birthmonth {input.BirthMonth}");
            }

            MessageBox.Show(result.ToString());
        }

        public class BirthDayChocolate
        {
            public int[] ChocolateBoxNumber;
            public int Birthday;
            public int BirthMonth;
        }

        public int FindNumberOfBirthdayChocolateCanbeDivide(int[] s, int d, int m)
        {

            if (s.Length == 0)
            {
                return 0;
            }

            int result = 0;
            int counter = 0;
            int sum = 0;

            /* 
                Input = 1, 2, 1, 3, 2   
                d = 3 
                m = 2

                Input = 4, 5, 4, 2, 4, 5, 2, 3, 2, 1, 1, 5, 4 
                d = 15
                m = 4
            */

            for (int i = 0; i < s.Length; i++)
            {
                counter++;
                sum += s[i];

                if (counter == m)
                {
                    if (sum == d)
                    {
                        result++;
                    }

                    counter--;
                    sum -= s[i - (m - 1)];
                }
            }

            return result;

        }


        private void btn_Divsible_Sum_Pairs_Click(object sender, EventArgs e)
        {

            /*
                Refered : https://www.geeksforgeeks.org/count-pairs-in-array-whose-sum-is-divisible-by-k/
                https://www.geeksforgeeks.org/count-number-of-pairs-in-array-having-sum-divisible-by-k-set-2/
                https://www.hackerrank.com/challenges/divisible-sum-pairs/problem?h_r=next-challenge&h_v=zen&h_r=next-challenge&h_v=zen&h_r=next-challenge&h_v=zen
                Time Complexity : O(N)
                Space Complexity : O(1)

                Approach: In the previous post, an approach using hashing is discussed. In this article, 
                another approach using hashing is discussed. The idea is to traverse the array, find (arr[i] % k) and 
                keep track of these values in the hash.

                The stepwise algorithm is:
                
                Find x = arr[i] % k.
                This array element can be paired with array elements having mod value k-x. This count of array elements
                is stored in hash. So add that count to answer.
                Increment count for x in hash.
                In case value of x is zero, then it can be paired only with elements having 0 mod value.

            */
            StringBuilder result = new StringBuilder();
            List<ArrayAndValue> inputs = new List<ArrayAndValue>();
            inputs.Add(new ArrayAndValue() { input = new int[] { 2, 2, 1, 7, 5, 3 }, find = 4 });
            inputs.Add(new ArrayAndValue() { input = new int[] { 1, 3, 2, 6, 1 }, find = 4 });
            inputs.Add(new ArrayAndValue() { input = new int[] { 1, 3, 2, 6, 1, 2 }, find = 3 });
            inputs.Add(new ArrayAndValue() { input = new int[] { 5, 9, 10, 7, 4 }, find = 2 });
            inputs.Add(new ArrayAndValue() { input = new int[] { 29, 97, 52, 86, 27, 89, 77, 19, 99, 96 }, find = 3 });


            foreach (var input in inputs)
            {
                int[] inArray = input.input;
                int[] fr = new int[input.find];
                int k = input.find;
                int sum = 0;
                int r = 0;
                for (int i = 0; i < inArray.Length; i++)
                {
                    r = inArray[i] % k;
                    if (r != 0)
                    {
                        sum += fr[k - r];
                    }
                    else
                    {
                        sum += fr[0];
                    }

                    fr[r]++;

                }
                result.AppendLine($"There are {sum} pairs which are divisible by {k} from the given array {string.Join(" ", inArray)}");


            }

            MessageBox.Show(result.ToString());

        }

        private void btn_Migratory_Birds_Click(object sender, EventArgs e)
        {

            /*
                https://www.hackerrank.com/challenges/migratory-birds/problem?h_r=next-challenge&h_v=zen&h_r=next-challenge&h_v=zen&h_r=next-challenge&h_v=zen&h_r=next-challenge&h_v=zen
                Time Complexity : O(n) where n is the list of items in the given input
                Space Complexity: O(n) where n is the list of unique items in the given input list
            */


            StringBuilder result = new StringBuilder();
            List<int[]> inputs = new List<int[]>();
            inputs.Add(new int[] { 1, 4, 4, 4, 5, 3 }); //4
            inputs.Add(new int[] { 2, 4, 3, 2, 3, 1, 2, 1, 3, 3 }); //3
            inputs.Add(new int[] { 1, 2, 3, 4, 5, 4, 3, 2, 1, 3, 4 }); //3
            //inputs.Add(new int[] {5,2,2,2,4,1,1,2,4,2,2,2,4,1,2,4,1,2,4,4,3,2,3,1,3,3,4,3,5,2,5,3,4,1,3,2,3,3,3,5,2,4,1,5,4,5,4,4,4,5,3,2,1,1,3,1,1,5,5,3,5,2,2,4,5,2,4,3,2,4,4,5,3,2,3,2,4,5,2,2,3,5,2,3,1,3,3,2,4,3,5,4,3,1,3,3,2,4,4,3,5,3,3,3,5,1,3,5,5,2,5,2,3,4,3,3,2,1,3,1,2,3,2,4,2,3,3,3,3,4,3,3,1,1,5,1,3,4,5,5,3,3,1,5,5,5,5,2,3,1,3,2,3,5,5,1,1,3,4,1,1,2,4,4,4,1,2,3,3,2,1,5,3,1,1,2,2,1,5,2,1,1,4,2,4,5,2,2,2,1,1,1,3,2,4,5,1,4,4,1,5,2,1,4,3,5,4,2,1,5,5,5,2,1,4,5,2,2,1,2,4,3,2,4,3,3,5,3,5,1,4,1,2,4,2,1,5,5,1,1,5,5,1,3,5,2,5,4,1,1,2,1,5,2,3,3,1,1,2,2,5,2,1,3,5,5,4,2,5,5,4,2,1,3,3,1,2,5,5,1,4,4,5,4,3,2,4,5,1,4,1,2,2,4,5,3,3,5,1,4,2,5,1,5,3,3,2,4,3,5,1,2,4,2,3,4,4,4,4,3,4,5,1,2,3,1,5,2,2,3,5,4,5,3,2,3,3,3,1,4,2,3,3,4,4,3,2,2,2,2,1,4,2,3,1,4,4,5,4,1,3,1,2,3,4,3,2,2,3,2,3,5,2,3,3,1,1,3,4,1,2,3,3,4,5,3,2,4,2,2,3,1,3,1,3,1,2,1,1,4,3,3,1,3,4,1,4,4,5,5,2,5,4,2,5,4,1,3,1,2,2,5,4,4,2,2,5,4,2,3,5,5,1,3,1,2,1,2,1,2,5,4,5,4,3,5,1,4,5,1,5,5,2,3,2,3,5,1,1,4,4,5,5,5,4,5,2,4,2,3,3,2,4,2,5,2,3,3,2,4,3,5,3,4,5,5,2,1,4,5,2,1,2,5,1,1,3,3,5,5,4,2,4,3,1,3,1,4,3,1,2,2,4,5,4,4,3,5,5,4,4,4,2,2,5,4,4,1,1,4,5,4,3,4,3,3,2,3,2,3,5,5,5,5,2,1,1,5,3,4,3,2,1,3,4,2,4,2,4,1,3,5,3,3,1,1,3,3,2,3,2,4,4,5,2,1,4,1,1,3,2,1,5,2,2,1,4,4,2,1,2,5,3,2,2,2,1,2,3,4,3,2,2,3,3,4,2,2,5,4,2,1,2,5,1,2,1,2,3,5,3,2,5,3,3,1,5,5,5,5,5,2,4,2,5,2,2,4,3,3,3,1,2,5,1,2,1,3,1,5,3,2,4,1,3,5,5,5,3,2,3,4,1,5,5,5,1,4,1,2,4,4,3,1,4,1,1,5,5,3,4,5,1,2,2,4,2,4,4,5,4,3,5,1,2,5,1,4,2,5,3,2,1,5,5,3,4,2,2,4,2,4,3,3,5,1,1,4,2,1,3,2,3,1,3,1,4,4,3,2,5,2,5,4,2,3,5,4,5,2,5,4,1,5,5,4,4,2,4,5,4,1,4,2,2,5,5,3,1,4,2,1,1,5,3,2,4,1,5,5,4,5,4,5,5,3,1,4,4,3,2,4,2,4,5,4,2,5,5,3,5,4,1,1,1,3,4,3,2,1,2,3,5,2,5,1,1,4,3,5,3,3,4,3,1,1,1,3,2,5,2,3,1,1,4,2,3,3,3,3,4,2,2,2,3,4,5,1,4,1,4,2,2,2,4,4,5,3,3,3,5,1,1,1,1,3,2,3,3,5,5,3,5,2,2,4,3,4,3,2,1,1,1,2,5,4,3,1,3,4,2,1,2,4,5,5,5,4,2,4,4,5,2,2,2,4,5,2,5,3,5,3,1,2,4,2,2,2,5,2,2,2,5,5,4,2,2,4,4,2,3,2,1,2,1,1,4,5,4,3,1,1,4,2,1,5,5,2,4,2,5,2,3,5,5,1,4,5,3,2,1,2,4,2,3,3,2,4,3,5,4,2,3,1,2,4,2,5,3,1,2,5,5,1,4,4,5,5,5,1,1,4,3,5,5,2,5,2,4,5,2,5,2,1,2,4,2,2,4,4,4,2,3,5,5,2,1,5,4,1,4,5,3,5,4,2,5,3,1,4,3,4,5,1,5,5,1,5,4,1,1,1,1,2,3,2,4,1,3,3,1,5,4,3,5,3,2,3,4,3,2,1,3,4,4,5,4,5,2,2,1,5,3,5,5,4,4,1,4,1,3,3,5,4,5,4,1,3,5,3,1,5,2,5,5,4,3,2,5,1,2,5,2,5,4,4,5,3,5,1,1,3,3,4,4,4,4,4,2,2,3,5,4,4,1,2,2,2,1,4,5,5,5,3,5,2,1,5,2,3,1,5,2,4,1,2,3,2,3,3,2,3,5,2,1,5,3,5,1,5,3,4,5,4,2,1,2,2,5,4,1,1,3,3,3,5,2,4,3,1,1,1,1,1,5,2,1,3,3,5,5,4,3,2,5,4,5,5,3,4,4,1,1,4,3,2,3,1,4,1,2,2,5,3,4,3,4,4,5,1,1,5,4,4,5,1,2,1,2,5,1,1,5,2,2,2,5,1,4,1,4,4,3,4,2,1,1,5,4,5,5,3,4,2,3,2,5,1,3,2,5,1,2,2,5,5,1,1,1,4,1,5,1,1,4,4,2,5,5,3,4,3,5,2,4,3,4,5,2,1,2,3,2,1,3,4,1,1,2,5,5,1,4,4,5,2,2,5,5,5,5,5,3,3,4,1,3,5,1,4,5,4,4,1,5,3,1,4,3,4,5,1,3,4,4,2,1,2,3,1,4,5,1,4,1,5,4,5,5,2,1,5,4,4,1,5,5,4,5,1,5,5,5,5,4,5,4,2,3,2,5,5,2,5,5,2,2,2,2,2,5,1,1,3,5,3,1,2,1,1,2,5,1,1,4,4,1,3,3,3,5,4,1,5,4,4,3,5,4,2,3,2,1,1,1,4,5,2,5,2,3,3,2,1,1,4,1,4,4,3,2,3,4,2,5,1,2,3,4,2,3,3,2,4,4,3,4,4,3,4,2,4,2,2,4,1,2,5,5,3,4,2,1,1,2,1,4,2,4,3,2,5,1,3,2,1,2,5,2,1,5,4,4,3,5,1,3,5,1,3,4,2,3,1,1,4,4,4,2,2,4,2,3,4,1,4,3,2,5,5,1,3,2,1,4,3,4,1,4,1,1,4,1,5,2,2,5,2,1,2,5,1,5,4,4,2,1,2,2,1,3,4,5,5,2,3,3,4,3,2,5,3,3,2,4,4,5,1,1,1,2,4,2,4,3,3,2,2,1,1,3,2,4,1,5,1,3,2,4,2,4,4,1,4,5,5,2,1,4,1,1,5,1,1,1,5,2,4,5,1,2,3,5,2,5,1,1,5,5,2,1,4,3,3,1,2,1,5,1,2,2,3,3,3,1,1,4,2,2,2,3,1,5,2,3,1,5,5,2,5,5,3,3,3,2,2,2,4,5,3,1,4,4,2,4,1,2,2,2,3,4,2,5,4,1,2,1,5,4,5,4,2,4,1,2,3,3,2,3,1,4,2,4,5,3,2,3,3,4,4,2,5,3,4,4,3,1,1,3,2,5,3,2,1,5,2,5,1,3,1,3,4,4,4,1,5,4,5,2,1,4,2,2,5,1,5,3,1,2,5,2,3,2,1,2,3,1,4,1,1,5,1,4,2,3,4,5,1,4,4,2,1,4,2,3,3,2,1,2,4,1,2,3,5,4,3,2,1,5,4,1,4,3,1,5,4,5,4,4,3,5,2,1,1,1,3,3,1,4,4,4,3,1,3,1,3,4,4,4,5,4,5,1,5,4,2,2,3,5,1,5,1,5,3,1,1,2,1,4,1,5,4,1,4,2,5,2,1,5,5,4,3,1,3,2,4,5,1,5,1,3,1,1,4,2,5,4,4,3,5,2,4,5,5,5,3,2,5,4,3,5,4,4,1,3,2,1,3,2,3,5,3,2,4,1,5,3,4,2,5,1,4,5,3,3,2,5,4,1,3,5,3,1,4,4,5,3,5,5,5,1,4,2,2,1,2,2,2,3,2,3,2,5,3,4,1,1,1,5,5,1,4,5,2,5,3,4,3,2,3,2,5,1,4,4,1,4,5,5,1,2,1,4,1,5,2,5,2,4,2,5,3,4,5,1,3,4,2,5,3,1,4,1,5,5,4,2,5,4,2,2,1,3,2,5,5,4,5,4,3,1,4,2,5,4,2,4,2,4,4,4,5,4,3,1,2,2,5,3,4,4,2,1,3,5,3,5,4,3,3,3,3,4,1,1,3,1,3,1,2,3,2,3,1,2,3,5,2,5,3,3,4,2,5,4,3,4,5,4,5,5,1,2,3,5,2,1,3,3,3,5,3,3,5,4,3,3,5,3,4,1,3,2,4,5,5,2,3,3,1,3,2,2,3,2,1,4,1,1,4,2,2,3,3,2,5,3,1,5,1,5,1,5,4,3,3,2,2,3,2,1,5,2,2,2,2,2,3,5,4,1,4,1,1,1,1,2,2,2,3,4,1,5,2,1,3,1,2,5,4,2,5,2,3,4,2,3,4,3,2,4,5,4,4,4,5,1,3,3,5,1,3,2,2,1,3,5,5,1,2,5,1,5,3,5,5,5,3,2,3,3,5,3,2,5,4,2,1,1,2,3,5,2,1,4,5,3,1,4,4,5,3,5,4,4,4,4,2,5,5,4,5,3,4,1,2,3,1,5,4,4,3,4,3,3,3,5,3,5,2,2,1,3,3,4,1,4,3,4,4,4,1,1,5,1,2,5,3,1,5,2,4,2,4,1,4,3,3,5,4,3,3,1,4,5,1,3,2,1,4,5,5,4,3,3,2,5,2,3,3,2,5,1,3,4,4,4,1,4,2,1,2,2,1,4,3,2,1,4,5,2,4,3,3,4,2,1,2,2,3,3,3,2,2,1,4,4,5,3,1,3,5,5,2,1,3,4,2,3,5,4,2,2,5,4,1,1,5,4,5,4,5,2,1,1,5,5,1,4,5,4,3,2,1,1,5,5,3,5,5,4,4,3,1,5,5,1,1,2,5,2,2,2,5,1,4,3,3,2,2,3,3,3,2,5,2,3,5,1,3,3,2,3,3,4,1,1,1,4,3,3,2,1,5,3,1,5,5,3,4,2,2,5,3,2,3,5,5,2,4,5,2,2,3,2,3,4,2,5,3,3,3,1,2,1,3,1,4,4,4,4,3,3,3,5,5,2,5,2,2,3,5,4,3,2,5,1,4,4,2,4,1,1,5,3,2,3,4,5,1,2,4,5,3,5,4,1,3,4,3,5,4,4,2,3,4,2,1,3,5,2,4,3,1,4,1,4,4,3,2,2,5,1,4,3,4,5,1,1,5,1,3,3,4,3,2,3,2,3,5,3,1,4,2,2,5,4,2,2,3,2,5,5,5,5,4,3,4,3,1,2,4,3,2,4,4,1,4,3,3,2,3,5,5,1,5,1,4,1,1,1,3,5,1,4,5,5,3,3,4,5,4,5,5,1,5,1,5,2,3,4,3,1,1,2,4,3,1,3,1,4,1,4,1,3,3,4,4,2,4,3,1,3,3,3,5,3,1,3,2,4,3,3,4,2,1,2,4,4,5,1,3,1,5,5,1,4,2,2,1,3,1,1,1,4,5,2,5,1,4,3,5,4,4,1,3,1,5,4,1,4,5,4,2,1,3,2,4,4,5,1,2,1,4,4,1,4,3,5,3,4,1,1,2,5,5,2,1,3,4,1,5,3,2,2,4,3,1,1,2,4,3,4,3,4,1,1,4,2,5,2,1,4,5,4,5,5,4,5,5,5,2,5,1,4,4,2,3,1,5,3,4,2,5,1,4,1,2,5,1,2,4,1,2,3,2,5,2,1,1,5,3,1,1,5,4,1,5,4,5,3,3,3,5,3,3,1,1,4,5,1,4,2,5,3,2,2,2,2,4,3,2,4,3,3,3,3,2,4,1,3,2,3,1,2,3,3,1,3,3,2,5,2,5,3,2,5,3,2,5,1,2,1,1,1,5,3,1,4,2,5,5,5,5,1,1,4,5,5,1,5,5,1,4,5,2,2,3,3,4,1,4,5,1,4,5,4,3,5,5,3,2,5,5,1,5,5,5,3,1,1,5,2,1,5,3,3,1,3,2,2,2,2,5,1,4,5,2,4,3,3,4,5,5,4,2,1,3,4,3,2,1,2,2,5,5,5,1,2,4,2,2,5,2,2,2,5,1,5,3,5,2,2,2,3,4,3,1,3,4,1,3,3,5,4,2,1,1,4,4,5,1,1,3,2,2,5,1,2,3,2,2,3,1,4,2,2,4,5,2,2,2,5,4,3,5,2,3,3,5,3,5,5,5,3,1,5,3,5,1,3,4,2,5,5,2,4,5,3,4,3,5,2,2,2,5,3,4,5,1,4,4,4,4,4,3,5,1,5,2,2,5,3,4,1,4,1,2,3,5,4,2,3,3,2,3,1,4,2,5,2,1,1,2,5,2,3,2,5,4,5,2,5,4,5,5,1,1,4,1,5,2,1,3,3,5,4,5,4,5,5,3,1,3,5,1,5,1,2,2,1,4,5,3,5,5,1,2,3,3,4,3,5,1,4,3,5,5,3,1,4,3,2,3,3,3,4,2,3,4,5,1,4,1,1,1,4,2,1,1,5,4,3,1,3,5,5,2,2,3,5,3,2,4,5,4,1,5,2,4,3,4,1,4,1,4,5,1,1,5,4,5,4,5,4,4,4,5,1,3,4,2,3,1,3,4,3,5,3,5,2,2,1,3,5,2,2,1,2,3,3,5,1,5,1,1,5,2,1,1,2,3,4,3,1,2,4,3,1,1,3,4,2,3,4,2,5,5,2,1,1,5,3,1,1,4,2,1,4,1,3,2,3,2,3,5,5,3,1,4,1,5,2,5,5,3,3,1,3,5,1,2,5,2,3,5,1,4,4,3,3,2,2,4,4,4,4,5,5,2,4,4,4,5,1,3,3,1,1,4,5,3,1,4,4,4,2,2,3,5,4,5,4,5,5,5,3,5,2,1,3,5,3,1,1,5,1,3,5,5,5,5,1,1,5,3,5,5,4,2,2,1,3,2,2,3,4,5,4,4,4,1,3,5,4,1,1,3,5,3,3,1,1,4,2,4,1,5,2,1,3,4,4,5,5,2,1,4,2,2,5,1,3,2,5,3,2,5,2,5,1,1,3,4,2,2,4,2,5,1,4,4,2,1,3,1,5,4,3,5,2,3,1,5,3,1,1,2,4,1,2,3,1,1,2,4,4,4,4,2,1,1,4,5,1,2,1,5,3,5,2,3,5,5,4,4,1,3,3,5,2,5,3,5,4,3,3,3,4,4,3,3,4,4,4,3,2,1,1,3,5,1,3,2,2,4,4,3,5,2,5,3,5,5,1,2,3,1,2,2,4,1,4,4,1,4,4,4,3,4,4,3,2,5,3,1,5,5,3,3,2,2,1,5,1,5,1,4,4,1,3,4,2,1,2,4,2,4,5,2,1,5,1,4,3,5,3,5,4,5,4,4,4,4,1,3,1,5,2,1,2,3,2,3,2,5,4,3,3,2,2,1,5,4,1,3,3,3,3,4,3,2,5,2,5,2,3,3,3,1,2,5,5,2,3,5,3,2,5,2,2,2,5,5,2,3,1,3,3,3,3,5,4,5,1,2,4,4,4,4,4,1,4,3,2,1,4,1,1,5,2,3,2,3,5,1,2,1,2,3,4,3,1,1,2,1,3,4,4,2,1,1,5,3,5,4,2,3,5,2,3,3,5,5,4,2,5,1,3,2,1,3,1,5,4,5,3,1,3,4,2,3,1,4,3,2,2,1,2,1,4,2,3,4,5,1,4,1,2,5,2,2,4,2,2,5,2,5,4,4,1,1,4,3,2,3,1,1,4,2,2,1,3,4,3,4,2,1,2,1,3,1,3,1,5,1,5,4,1,5,4,1,4,2,4,2,3,2,4,4,4,2,5,2,5,5,5,4,5,3,5,5,1,1,4,1,4,5,5,3,2,2,1,1,2,2,1,4,5,3,1,2,1,4,2,5,3,2,1,3,2,2,1,2,4,3,4,4,1,5,4,1,3,3,5,4,3,3,5,1,5,2,5,2,4,5,5,4,1,3,3,1,3,3,1,1,4,2,1,2,2,1,5,3,2,2,4,2,1,3,3,2,4,2,5,5,3,1,1,1,5,5,1,2,5,3,4,2,3,5,1,2,2,3,2,1,1,4,5,4,5,5,1,5,4,2,2,1,1,3,1,1,5,2,5,3,4,4,1,3,1,4,3,2,1,2,1,4,1,3,4,5,3,2,1,4,4,1,1,3,2,2,1,5,1,4,1,1,1,2,2,5,5,5,1,1,5,3,2,5,2,1,3,3,5,4,3,1,2,3,3,3,5,1,5,5,4,5,5,5,4,1,3,3,1,4,3,3,2,3,4,3,2,4,1,2,5,1,4,3,1,3,1,4,4,5,4,4,1,1,5,2,2,4,5,2,2,5,3,2,5,5,2,2,2,3,2,5,4,2,5,5,3,2,4,4,1,5,4,4,1,1,3,2,5,5,3,1,5,3,2,4,3,3,4,3,2,5,2,2,1,1,1,4,3,3,1,1,4,4,2,4,1,1,5,1,2,3,2,3,2,1,3,4,5,2,1,4,2,4,3,2,2,4,1,3,4,1,3,4,5,2,4,3,5,1,3,1,2,5,5,1,1,3,2,4,1,4,5,1,4,5,1,1,5,1,1,1,3,1,4,1,2,3,5,3,3,4,3,4,2,2,2,3,3,1,1,4,1,5,5,2,3,1,5,4,2,4,2,3,4,1,1,4,3,3,4,5,1,1,3,5,5,1,2,1,3,2,3,3,3,2,2,5,5,1,3,1,5,2,2,5,5,2,5,5,4,2,5,5,3,4,4,4,5,2,2,2,4,4,5,3,4,2,4,3,1,4,5,2,5,1,1,3,4,3,1,5,3,1,4,4,3,2,4,4,3,3,4,4,2,5,1,4,4,1,2,1,5,3,5,3,5,1,5,2,3,1,5,4,5,2,4,4,4,5,3,1,4,3,4,4,3,1,5,3,3,1,3,1,5,5,4,4,2,2,1,4,3,3,4,2,1,5,2,2,5,2,5,2,3,5,1,5,2,1,3,3,5,2,1,3,1,5,4,4,2,3,3,5,5,1,3,3,5,1,2,5,4,3,3,2,5,5,3,3,3,1,5,5,1,1,4,2,5,3,5,3,3,1,2,2,3,1,4,4,1,2,3,4,2,2,1,2,3,4,5,5,3,3,4,2,1,4,3,1,4,5,1,1,5,3,4,5,2,1,3,5,5,4,5,4,1,4,3,5,2,2,4,5,5,1,3,4,1,3,2,1,2,2,3,2,5,5,2,4,4,1,5,2,3,1,1,1,4,2,3,2,5,4,5,1,2,5,1,3,3,1,3,4,5,4,1,1,3,1,2,4,2,5,3,4,1,4,3,2,1,4,2,2,1,1,4,3,2,4,2,2,2,2,1,3,5,5,1,5,2,2,5,5,5,2,5,4,3,3,5,3,3,2,4,5,5,2,1,5,4,3,3,5,4,4,2,2,4,3,4,4,5,1,5,1,1,4,4,1,3,1,4,4,4,1,3,2,4,5,3,4,2,4,1,1,2,1,3,2,1,2,1,2,5,2,2,1,2,4,4,5,1,2,4,3,4,3,5,4,2,5,3,3,4,1,3,4,5,5,5,2,4,4,4,2,3,1,2,1,5,2,3,5,5,3,5,2,1,2,2,2,5,2,3,4,3,2,5,3,4,3,3,2,2,2,2,1,5,1,2,4,5,4,5,1,3,4,3,5,4,3,4,1,2,4,4,4,3,5,2,1,4,5,1,1,2,3,2,5,1,2,4,3,3,2,5,2,2,5,5,1,3,4,1,4,2,1,5,1,1,5,5,5,2,3,1,1,3,4,1,4,5,2,5,1,3,5,4,1,1,4,2,5,3,1,3,5,2,2,3,2,5,3,3,4,5,1,2,4,3,1,5,3,4,1,4,5,1,4,5,5,1,5,1,4,4,4,5,4,4,5,1,2,1,1,5,1,3,5,4,1,4,4,3,3,2,3,4,4,3,5,5,5,1,1,1,1,2,3,3,3,5,1,1,3,4,4,3,2,4,1,1,2,2,3,2,1,3,5,2,3,1,1,1,2,2,1,1,5,1,2,4,1,3,1,2,1,4,1,4,3,5,1,5,3,5,1,5,1,4,1,3,1,1,3,2,1,2,2,4,5,4,2,5,4,3,5,5,1,3,1,1,2,5,3,1,5,1,1,1,2,3,4,4,3,1,2,2,4,5,4,4,2,3,5,2,2,5,3,2,5,3,4,2,5,4,1,5,3,1,4,4,5,5,5,4,3,5,5,4,2,2,2,5,3,4,5,4,1,2,2,4,1,3,1,3,4,3,1,2,1,2,5,4,2,3,2,4,3,2,4,3,3,3,4,5,1,2,5,1,4,5,4,3,2,3,1,1,4,4,5,3,2,1,4,3,2,5,4,2,1,2,5,5,4,3,4,5,1,5,2,1,4,4,4,5,5,3,2,3,5,5,2,2,1,4,2,4,1,4,3,2,3,2,3,5,1,2,4,3,1,1,2,4,5,3,3,1,3,4,1,4,5,2,3,3,2,3,4,1,2,4,2,4,4,4,4,5,1,5,5,1,4,1,2,3,1,1,1,1,5,1,1,1,5,5,4,1,1,5,2,1,1,3,5,1,1,3,2,5,2,2,2,1,2,3,5,2,2,4,4,5,3,1,3,2,3,4,2,2,1,5,4,5,1,2,1,3,3,5,1,3,3,5,1,4,4,5,3,4,2,4,1,4,5,5,4,1,2,3,4,3,3,2,3,3,5,5,1,3,2,1,2,4,1,2,2,1,3,2,2,1,4,3,5,3,5,2,1,4,1,3,3,5,2,2,2,3,5,3,1,4,4,2,1,4,1,1,4,4,2,3,3,1,3,3,5,1,5,1,5,3,2,4,5,1,5,3,4,3,4,3,3,3,5,3,3,5,5,4,2,4,5,4,4,4,3,5,3,4,5,2,5,1,4,2,1,3,5,3,5,4,2,5,3,4,5,2,4,1,4,1,2,4,5,5,3,3,1,3,2,1,4,2,5,3,4,1,2,1,1,1,5,1,3,1,1,3,1,1,3,5,3,2,5,5,3,2,5,5,2,1,4,1,5,1,3,1,4,4,3,3,3,2,3,4,2,3,4,4,2,4,3,3,1,5,4,4,3,2,4,5,5,5,4,1,2,4,5,1,3,1,1,5,3,3,1,3,4,2,3,1,4,3,3,3,1,4,4,5,2,3,2,5,2,1,2,3,1,4,1,3,4,1,2,5,2,5,5,2,5,2,3,4,1,4,1,2,3,3,1,1,5,1,4,1,5,2,3,2,4,2,2,4,5,2,4,1,4,1,1,5,2,3,5,1,3,3,3,2,4,3,1,4,1,2,4,1,4,4,2,1,2,5,4,1,5,3,4,2,1,3,5,5,5,3,4,3,1,4,2,4,2,3,5,2,2,3,4,4,1,1,2,4,4,4,1,3,3,3,1,5,3,3,2,1,5,1,4,3,2,1,5,1,4,4,4,5,3,1,1,2,1,3,4,2,1,2,1,5,1,5,4,1,2,4,1,1,5,2,1,3,3,1,5,4,5,2,1,1,5,1,2,3,2,3,4,4,3,4,2,4,5,5,4,5,3,3,1,2,3,1,2,3,2,1,5,5,5,3,3,4,4,3,1,4,2,3,4,2,3,1,5,1,3,2,3,4,5,1,1,5,1,4,2,4,1,2,1,5,1,2,3,2,5,1,2,3,3,2,3,5,2,2,5,1,5,3,2,5,5,5,2,1,1,1,2,4,5,3,5,1,4,5,3,2,5,2,4,5,1,2,4,3,5,3,4,1,3,3,4,2,5,2,3,1,5,2,2,5,1,2,4,2,4,4,1,1,5,1,3,4,3,5,5,4,2,3,5,1,1,1,4,5,1,2,3,2,2,3,1,4,4,4,1,1,4,1,1,2,3,5,1,5,3,3,3,5,4,5,5,4,1,2,5,1,4,4,1,4,4,3,2,5,4,2,5,2,4,5,4,2,1,3,2,1,2,2,1,2,2,4,2,1,4,5,5,3,2,1,3,2,2,2,4,1,5,2,2,2,1,3,1,4,4,5,2,5,5,1,5,1,1,3,4,5,1,4,3,2,2,5,5,4,1,4,5,2,1,4,4,2,5,1,4,1,4,5,5,5,1,1,4,2,5,2,2,4,3,2,4,2,1,1,5,2,1,3,5,1,4,3,2,2,5,1,5,3,5,3,5,1,1,3,5,1,4,3,1,5,3,1,3,2,1,1,4,1,4,1,4,3,1,2,1,3,3,5,1,1,5,5,5,1,1,2,4,2,2,5,4,2,4,1,5,5,4,1,1,1,5,5,2,1,1,2,3,1,3,5,4,3,2,3,3,4,4,5,4,2,3,1,5,4,2,5,4,4,5,4,5,5,2,2,5,3,5,4,4,1,5,5,5,2,5,2,2,3,3,3,1,3,2,1,1,5,1,5,4,1,5,3,5,2,1,3,3,4,4,1,5,2,4,4,5,5,1,2,3,4,1,3,4,2,5,4,2,1,5,5,2,4,2,5,2,5,1,5,3,5,1,5,5,4,5,1,2,4,5,2,2,1,4,2,5,1,5,1,5,4,4,5,2,5,5,5,1,2,2,3,5,2,4,2,3,3,1,1,3,4,3,1,5,2,2,5,5,2,4,2,5,1,2,3,4,4,4,3,3,3,2,3,4,5,4,5,1,3,1,5,5,2,5,3,4,1,1,1,4,1,3,1,1,4,1,3,1,5,1,5,1,4,5,4,5,2,1,4,5,1,3,1,3,2,2,1,1,1,2,3,5,1,3,4,2,3,3,4,4,4,2,2,5,1,3,2,4,4,2,1,5,2,3,2,1,3,1,3,4,2,2,5,1,2,4,4,3,1,4,4,5,1,3,4,5,5,2,4,2,5,1,5,2,4,4,5,3,5,5,2,3,2,2,3,4,1,1,3,5,2,1,1,5,5,4,3,5,4,4,2,5,4,1,4,2,2,5,1,3,2,4,3,2,4,1,2,1,2,2,3,4,1,3,2,4,5,1,4,3,2,5,1,3,2,3,5,1,3,2,4,3,3,1,3,4,2,4,3,5,5,3,4,2,5,1,2,4,1,4,1,5,3,3,2,3,3,2,2,2,1,1,1,4,4,2,4,5,5,2,2,1,4,3,1,4,3,1,3,5,3,3,3,2,3,5,5,4,5,2,1,3,1,3,4,3,1,1,5,1,5,2,3,4,3,5,1,2,4,4,4,1,3,4,3,3,1,1,4,4,5,3,2,4,1,2,1,2,4,5,2,2,4,5,1,4,3,4,2,3,5,2,1,1,4,1,2,5,3,1,2,1,2,2,3,5,5,2,1,5,2,1,5,3,5,5,1,1,3,1,2,2,4,5,4,5,3,1,1,3,5,3,1,4,3,4,2,4,4,1,2,4,3,2,4,4,2,5,5,2,1,4,5,4,2,1,2,4,1,4,4,2,1,2,3,1,3,1,5,2,3,2,1,2,3,5,3,5,4,3,1,3,5,3,3,1,5,5,4,4,5,1,5,1,2,3,1,5,5,5,5,2,2,3,5,3,1,2,4,3,1,1,4,4,2,4,3,5,1,2,2,5,5,4,5,2,3,4,1,4,1,4,3,4,1,3,5,4,5,1,1,1,5,1,2,3,2,5,5,4,2,3,3,3,3,3,5,5,5,4,3,1,4,2,5,2,1,2,3,4,4,2,5,2,2,5,2,1,3,1,3,2,3,5,3,1,1,3,3,2,1,2,4,5,5,4,2,5,3,3,1,1,4,3,1,4,4,3,1,3,5,3,5,5,4,1,5,4,5,1,4,4,1,1,2,4,3,4,2,5,2,1,4,2,3,3,3,2,5,2,4,2,5,1,3,4,5,4,5,3,4,3,5,3,5,3,3,1,3,4,2,1,4,4,2,2,4,5,4,3,4,5,5,2,4,5,4,3,4,5,2,2,3,1,4,4,1,1,4,3,2,5,2,1,2,4,5,4,2,1,1,3,3,2,3,2,1,5,2,3,1,3,5,1,4,4,4,3,2,2,1,5,5,1,1,5,5,5,2,3,1,5,3,4,1,5,5,4,5,4,5,4,5,2,1,2,4,4,2,1,4,1,4,5,4,3,1,1,4,5,3,1,1,2,4,2,4,4,2,1,4,2,1,3,1,3,2,2,1,2,1,4,2,4,3,5,5,4,3,4,4,4,1,3,1,2,4,3,4,3,3,5,2,4,4,4,4,3,3,1,5,4,1,3,1,3,4,1,3,1,1,4,2,5,2,2,4,3,1,2,3,1,3,5,1,2,1,1,3,2,2,2,1,1,2,4,4,3,5,2,1,2,3,3,4,4,3,3,1,3,3,5,2,5,3,1,4,4,2,1,1,5,3,2,3,4,1,4,3,5,4,5,1,3,5,4,1,1,2,2,4,4,2,1,3,3,1,5,2,4,4,2,2,5,4,5,1,2,4,1,3,3,3,5,5,5,5,3,5,4,5,4,4,5,5,4,4,2,4,4,1,2,1,1,3,1,1,5,4,1,5,4,3,2,2,4,2,2,5,4,2,3,1,3,3,4,2,1,4,1,5,2,2,5,1,3,3,2,1,4,5,1,1,5,5,5,5,4,1,3,3,4,1,1,2,1,2,1,4,3,4,3,5,2,1,4,3,1,3,1,5,3,3,5,2,1,2,3,3,1,5,5,5,3,3,1,4,4,3,3,1,5,1,5,2,2,4,3,5,5,2,4,4,1,2,4,5,2,5,1,3,4,3,1,3,2,5,2,4,4,4,3,4,4,3,4,2,5,3,3,4,5,3,5,3,2,4,2,5,1,1,2,1,2,4,5,5,4,2,5,2,4,2,2,1,4,1,2,3,3,1,4,1,3,1,4,2,1,1,4,5,4,5,1,5,5,5,3,1,2,5,4,3,4,5,4,5,4,1,2,3,2,2,2,4,1,2,1,4,3,3,3,4,4,4,3,4,5,4,4,4,5,5,4,3,1,2,5,3,5,4,4,4,3,4,5,5,5,4,3,5,5,1,5,3,5,5,3,1,4,4,4,5,1,3,1,4,5,4,1,3,2,3,2,4,1,4,5,5,5,4,1,3,4,5,1,2,3,4,2,1,1,2,3,2,3,3,5,3,5,1,5,5,1,3,3,3,1,4,2,5,2,3,1,3,3,2,2,3,3,5,2,1,1,5,4,4,5,2,4,2,1,3,5,1,4,4,2,4,5,3,1,3,5,3,4,2,1,5,5,2,4,1,4,5,1,5,5,4,1,3,3,3,3,2,4,2,1,2,2,4,1,1,2,1,5,1,4,3,3,2,1,2,2,4,3,3,3,3,3,1,4,5,2,3,5,1,5,4,1,4,1,1,3,2,3,5,5,2,5,3,4,3,4,5,2,3,1,2,4,2,3,3,4,3,5,3,2,3,3,2,1,2,3,1,4,3,3,4,1,5,4,4,4,3,3,2,1,2,4,3,3,4,1,1,5,1,1,4,4,3,4,2,2,2,5,2,1,4,4,3,5,3,3,1,1,5,1,1,5,5,1,5,5,5,1,3,4,2,2,4,2,5,3,2,2,2,4,4,4,1,4,4,4,3,5,3,2,4,3,1,1,3,4,3,2,3,1,1,5,3,2,2,4,2,1,5,5,5,3,2,1,1,5,1,4,1,3,1,1,2,5,5,1,4,5,1,5,5,1,3,2,2,3,4,3,2,1,4,4,5,2,1,3,3,4,4,3,4,3,3,3,5,2,3,5,1,5,2,3,1,5,4,1,5,1,2,4,4,5,2,2,5,3,4,3,5,2,1,5,4,3,5,3,4,4,4,2,3,4,4,3,4,3,2,1,2,5,2,2,5,3,4,4,4,4,4,3,1,2,5,4,4,4,2,4,5,2,5,1,4,5,1,5,5,2,3,5,1,5,5,1,2,2,1,5,4,5,3,5,3,4,4,3,1,2,3,4,3,3,2,5,4,5,3,4,3,3,4,3,1,4,3,3,4,1,2,4,5,4,1,2,1,1,5,5,3,3,3,5,2,3,2,1,5,1,1,1,2,2,1,1,3,3,1,2,5,5,3,4,2,1,2,3,1,3,2,3,5,1,3,5,2,4,4,2,1,1,3,4,3,2,2,5,2,5,3,1,2,1,3,5,1,1,3,5,2,4,3,1,2,4,1,4,5,1,5,5,3,1,5,1,2,2,3,4,3,4,1,5,5,1,3,5,3,5,1,1,5,2,1,4,5,1,4,3,5,4,4,5,2,4,4,3,3,5,4,5,2,3,3,1,5,2,5,4,5,3,5,1,2,4,2,3,1,5,5,3,5,5,4,4,2,3,1,1,3,5,4,4,3,4,5,5,5,2,4,2,5,4,1,4,4,2,2,1,1,4,4,5,5,2,1,2,1,1,2,4,1,1,3,5,2,1,5,5,4,1,3,5,2,4,1,1,2,1,4,1,3,3,3,3,5,2,5,1,1,4,3,1,5,2,2,2,5,5,4,1,3,2,3,4,3,5,4,3,3,4,4,4,2,4,1,4,5,5,1,2,5,1,2,5,2,2,2,3,2,4,1,5,2,4,5,1,4,2,4,3,3,3,2,4,5,4,4,4,2,1,4,5,3,2,4,1,3,1,4,2,5,5,2,3,1,2,5,1,4,2,5,1,2,1,1,5,3,4,1,1,3,5,3,2,4,5,2,2,3,5,3,5,1,4,1,4,2,2,2,5,4,3,3,2,1,2,4,1,4,5,3,1,5,1,1,2,2,4,2,2,3,2,4,3,3,2,2,1,3,2,5,1,2,5,2,3,3,3,2,2,5,2,2,1,1,3,5,3,3,4,5,3,4,5,5,5,5,4,2,3,4,4,1,1,5,4,2,3,4,4,1,1,5,3,2,2,5,3,1,3,2,2,4,1,1,2,5,5,2,3,5,3,4,4,2,3,4,3,2,3,3,1,1,3,5,5,4,3,4,1,2,1,3,1,3,4,3,3,4,2,5,1,3,3,5,5,3,2,5,5,3,2,4,5,4,2,1,5,3,4,1,4,4,2,2,5,5,3,3,5,5,3,1,5,3,2,4,1,3,1,2,5,3,1,5,5,4,1,3,4,1,1,2,4,1,3,4,1,2,4,4,1,1,3,3,5,3,4,5,4,2,1,1,3,1,3,4,4,5,4,4,3,4,3,4,2,4,4,2,1,1,5,1,1,5,5,4,1,3,3,5,1,4,4,1,3,3,4,1,2,1,2,2,5,3,5,3,1,5,2,3,1,5,5,4,4,1,3,3,5,3,1,4,3,5,2,1,1,2,4,2,3,3,2,5,3,5,2,5,1,4,3,1,3,2,3,1,2,2,2,1,1,4,4,5,4,4,2,3,2,2,2,2,1,2,5,5,1,5,4,1,5,1,5,5,3,1,5,3,2,1,2,5,3,5,3,5,5,4,3,3,2,1,5,5,1,3,2,1,4,5,4,5,3,3,2,4,2,3,2,2,3,1,3,1,3,2,4,5,5,2,1,1,4,2,3,4,2,4,2,2,5,5,2,4,4,1,5,5,1,5,1,3,5,4,1,2,5,1,3,5,3,1,3,1,1,5,2,4,5,1,1,2,5,4,5,4,5,3,1,4,3,2,5,1,1,3,2,3,5,3,1,1,5,3,5,3,4,3,1,2,3,1,3,1,4,2,1,1,2,2,2,5,2,3,2,1,2,4,3,4,2,4,5,1,3,3,1,2,3,5,2,4,1,3,5,4,5,4,2,1,3,4,4,1,4,4,4,5,3,2,4,2,3,4,4,4,5,1,3,1,4,4,1,5,2,2,5,5,1,1,2,4,3,5,4,3,4,1,5,2,5,1,5,5,3,1,1,4,4,2,2,2,2,4,3,3,3,5,4,5,1,2,4,4,2,3,5,3,5,5,5,2,2,2,2,1,4,2,3,1,3,1,2,1,3,4,5,5,3,1,1,5,4,2,3,1,4,4,3,2,1,1,2,4,5,5,2,4,5,3,4,5,5,3,3,2,1,5,1,2,2,5,1,1,2,5,2,4,4,3,1,3,1,5,5,5,4,4,1,2,4,4,2,5,5,3,3,2,5,3,3,3,3,4,5,2,5,1,3,1,1,2,3,5,2,3,1,2,2,4,1,1,3,5,1,1,3,4,5,4,5,5,3,3,4,3,1,1,2,3,1,2,3,1,5,4,5,1,1,1,5,5,3,3,3,1,4,3,3,3,2,3,4,5,4,2,5,5,5,3,2,3,3,5,1,4,3,4,2,1,4,4,5,2,4,3,5,1,3,1,5,4,1,1,1,4,1,4,3,2,4,1,3,1,2,3,5,3,2,1,1,3,5,1,1,1,2,2,1,5,4,4,4,1,1,3,1,2,4,2,5,4,3,2,5,1,2,3,5,3,2,5,5,2,1,5,5,2,4,4,3,5,3,2,1,1,4,2,1,1,2,5,5,3,3,1,4,1,1,5,1,1,2,2,5,2,4,4,2,1,2,3,3,3,2,3,1,2,4,3,5,4,3,3,4,5,3,2,2,4,1,4,5,4,2,4,2,2,4,3,3,5,5,2,4,3,4,1,1,3,1,5,1,2,1,4,5,4,3,5,2,1,3,4,5,5,4,2,3,2,3,5,2,5,3,1,2,4,5,2,4,3,4,4,1,4,3,2,5,5,2,5,1,1,2,1,1,2,4,5,2,3,2,2,1,2,5,2,1,4,2,1,3,5,5,2,4,4,2,4,5,3,3,4,3,3,3,2,1,5,1,4,4,1,4,3,1,1,5,4,4,3,5,5,4,5,1,2,5,4,3,1,2,3,3,3,3,2,4,4,5,1,4,1,1,5,5,3,5,5,1,5,1,4,2,5,1,1,1,2,2,2,1,5,5,1,2,5,4,1,5,4,1,5,4,4,4,3,3,2,2,4,3,5,1,1,2,1,3,5,4,5,1,5,5,3,5,4,2,4,2,1,4,3,2,3,3,2,3,5,4,4,5,2,2,5,4,3,1,4,4,4,3,5,4,3,2,2,1,2,4,2,2,5,1,5,4,2,4,2,4,1,2,4,5,3,3,1,2,2,2,1,2,4,5,3,2,1,1,3,3,1,2,4,3,3,3,3,2,2,4,3,5,1,5,2,2,1,1,1,1,4,1,1,3,4,5,2,1,2,1,2,5,1,4,2,1,3,2,1,3,3,3,4,1,1,3,5,1,2,1,2,5,3,3,2,5,3,4,5,2,1,3,2,5,3,1,5,3,5,3,2,2,2,4,4,1,4,2,2,1,3,3,1,5,3,3,1,5,3,2,5,3,3,2,4,2,5,3,3,3,2,4,3,1,2,4,2,5,1,2,4,3,2,2,2,1,2,2,2,1,5,2,3,4,2,3,3,3,3,5,3,1,1,5,5,1,3,2,1,2,1,5,2,3,2,5,1,3,3,1,3,2,1,1,3,1,2,1,4,4,4,3,1,1,1,3,3,1,5,2,3,1,5,3,2,4,4,5,1,1,4,3,1,3,2,4,2,3,4,2,1,4,4,3,3,2,3,2,1,5,1,4,4,4,2,3,1,3,1,3,1,2,2,4,3,4,4,5,3,5,1,3,5,3,5,3,3,3,3,2,4,1,4,1,4,1,5,1,3,3,4,1,1,3,4,4,4,5,4,1,5,5,3,1,5,2,4,3,4,3,1,1,5,4,1,2,3,2,2,4,3,4,3,5,2,4,3,4,4,4,5,5,2,5,4,2,1,2,4,3,4,5,4,1,3,2,1,1,5,1,4,2,4,3,4,1,1,4,1,2,4,5,4,3,4,4,4,3,2,5,5,4,5,5,5,4,4,4,3,4,4,2,3,4,2,4,3,3,5,5,3,4,5,2,1,1,4,5,4,5,3,2,3,5,4,1,4,3,1,4,4,3,4,4,4,2,4,1,1,4,3,4,1,3,5,3,5,1,4,3,3,3,1,4,2,4,5,2,1,5,3,5,1,5,4,2,1,3,4,1,2,1,1,5,3,2,5,3,3,3,1,4,3,1,4,1,3,5,4,1,2,4,1,2,4,4,4,4,2,1,3,1,2,2,4,5,4,5,3,1,1,2,5,3,5,2,2,2,5,2,4,4,2,1,2,4,2,5,4,5,2,1,1,5,2,4,5,1,2,5,4,4,5,4,1,2,3,3,4,4,1,3,5,5,2,5,4,1,3,3,3,5,4,3,2,2,5,2,5,3,3,3,3,1,3,3,2,3,2,1,3,2,3,1,3,3,3,1,5,2,3,2,2,4,5,3,1,5,4,1,1,1,4,5,3,1,3,1,1,4,4,1,2,2,2,4,2,3,3,3,2,2,3,2,5,3,4,5,1,5,5,1,3,1,3,4,1,5,3,4,2,5,2,4,2,5,2,4,5,1,2,2,1,2,2,5,5,3,4,4,1,3,2,2,4,5,2,2,2,3,4,5,5,3,3,1,4,4,4,5,2,3,5,3,5,1,4,4,4,1,2,1,2,2,4,2,3,5,1,3,3,1,5,2,5,5,3,4,2,3,1,5,4,1,5,3,3,5,1,3,3,4,2,4,3,3,5,1,4,2,2,5,2,3,2,1,4,1,3,4,2,4,3,5,1,4,5,3,5,5,5,4,4,1,2,5,1,5,1,4,1,5,2,4,5,5,1,4,1,4,5,4,4,1,3,3,3,5,5,4,4,4,4,1,2,2,3,1,4,5,1,4,1,5,1,1,5,1,5,4,4,1,4,3,2,2,5,2,3,5,4,2,2,4,4,1,1,3,3,1,5,3,3,5,4,5,1,1,2,1,3,5,3,3,5,2,5,5,1,1,3,2,4,4,5,3,1,5,3,2,3,1,3,3,3,1,5,5,2,5,2,3,1,5,2,5,5,4,3,2,1,3,1,5,3,4,1,4,4,5,1,4,3,3,2,4,3,5,4,5,2,4,5,4,5,4,4,5,4,1,5,4,3,1,5,5,4,4,1,5,4,4,5,2,5,1,1,4,5,3,5,5,2,3,1,4,4,1,5,5,3,5,5,4,1,4,3,2,2,4,1,1,1,3,4,3,1,4,3,1,2,5,2,3,5,5,3,3,5,4,3,4,3,3,1,1,5,2,2,2,4,1,1,5,5,2,1,5,1,2,1,3,5,3,3,3,4,1,2,3,3,4,2,4,4,3,4,3,1,4,4,5,3,5,3,2,5,5,1,2,4,4,2,2,3,5,5,3,3,1,1,1,2,5,2,3,5,3,3,2,1,2,4,4,4,2,1,1,3,5,3,4,2,1,1,3,2,4,5,4,2,3,2,1,3,1,4,2,4,3,5,5,1,1,3,4,5,1,4,5,3,2,3,2,4,1,1,2,5,2,4,4,3,5,4,3,5,4,4,5,4,1,3,5,2,2,2,4,4,3,4,1,3,1,3,2,5,5,2,3,4,3,2,1,5,5,3,5,1,3,1,3,1,5,1,3,2,1,5,1,4,2,5,1,1,3,3,2,5,1,2,3,2,5,5,5,2,3,2,5,2,4,5,4,1,5,4,1,5,5,5,4,1,1,3,4,2,2,3,2,4,1,5,4,1,5,3,2,1,5,4,3,2,4,3,5,3,5,3,5,4,3,4,5,2,3,4,5,4,2,2,3,5,4,4,2,5,1,2,2,5,3,3,4,4,1,5,1,4,2,2,5,5,3,4,2,3,4,2,4,1,3,1,1,1,5,5,3,1,2,1,3,2,4,1,1,4,1,5,4,2,4,5,1,3,2,3,5,3,1,1,4,3,4,3,5,3,2,1,1,3,5,2,4,4,2,5,3,4,1,1,2,3,1,1,5,3,2,5,4,2,5,1,5,1,3,4,3,1,1,1,2,1,3,5,1,4,1,4,1,1,5,2,3,1,4,4,1,4,1,4,4,2,4,2,5,1,4,5,5,5,4,4,1,4,5,4,3,5,3,3,1,5,4,5,1,2,4,4,3,1,5,3,3,4,4,2,1,5,3,4,3,1,1,5,5,4,3,1,4,2,3,2,4,1,3,1,4,4,5,3,1,3,4,1,5,1,4,3,3,5,5,3,3,1,3,3,2,2,1,2,1,5,2,3,1,4,1,3,5,2,2,1,5,2,2,2,5,2,3,4,1,2,3,4,5,2,5,1,3,3,4,2,5,1,5,2,1,3,1,1,4,3,5,3,4,3,5,2,1,5,5,3,2,5,2,4,5,3,5,3,2,4,5,3,1,1,5,3,2,3,3,4,3,5,3,5,4,2,3,1,3,3,3,1,4,3,5,5,1,5,5,3,4,5,5,4,3,4,4,4,5,4,1,5,1,2,2,5,3,2,1,4,1,3,5,5,2,3,3,1,5,5,2,3,2,4,4,2,4,3,5,2,5,3,5,5,4,4,4,5,5,4,4,1,3,4,4,1,3,4,3,5,2,3,2,4,4,5,1,1,1,4,5,2,3,3,4,3,2,1,1,2,1,5,3,3,3,4,5,1,1,3,4,5,1,3,4,3,1,5,5,5,1,1,1,5,3,1,2,4,4,1,4,2,5,4,3,3,5,1,4,2,1,2,3,2,4,5,5,4,3,3,1,2,5,1,3,2,2,4,2,3,5,1,5,5,5,5,3,4,1,3,3,4,4,4,5,1,2,4,3,3,1,2,2,3,5,4,4,4,5,3,3,1,2,1,2,3,4,2,4,1,5,2,1,4,2,1,1,4,4,3,4,4,4,4,4,2,4,2,3,1,2,1,4,1,5,5,2,2,5,2,5,5,3,5,4,2,4,1,1,1,5,3,2,4,3,3,3,4,2,5,4,5,4,3,5,4,5,4,2,4,1,1,1,3,3,1,3,2,5,5,3,4,5,1,5,5,1,3,2,2,3,5,2,3,3,1,5,5,2,5,4,2,5,1,2,5,1,1,3,1,1,4,5,1,1,1,3,3,1,2,1,3,4,1,1,5,3,3,2,1,4,1,3,4,5,4,5,4,1,2,4,4,1,1,4,4,4,1,1,2,2,5,5,1,5,4,2,5,1,5,3,4,4,4,2,5,1,1,2,5,4,2,5,5,4,3,4,5,4,4,3,5,2,5,4,1,1,2,4,4,3,1,2,4,4,3,1,1,2,5,4,2,5,2,5,5,2,3,2,2,4,3,4,4,5,3,2,4,4,3,5,2,5,4,4,2,4,5,4,1,2,4,3,3,3,3,3,4,5,4,4,4,2,3,2,4,1,5,1,2,1,2,5,3,5,1,2,2,4,3,4,4,5,1,3,1,4,5,5,4,4,3,5,3,1,4,3,5,5,3,3,2,5,5,2,2,2,1,3,3,3,5,2,1,2,5,4,1,1,1,4,2,3,2,3,5,3,2,4,5,1,3,3,5,1,2,2,3,3,5,2,2,4,2,3,1,5,5,4,1,4,2,5,4,4,5,3,3,1,5,4,5,5,2,4,1,4,3,5,4,1,5,5,3,2,5,2,3,4,5,2,1,5,1,4,3,4,2,2,3,3,5,4,2,2,4,4,5,2,1,5,4,2,1,5,1,2,1,4,3,5,1,4,1,2,4,3,3,5,1,1,1,4,3,4,2,1,3,3,4,5,2,1,4,5,4,2,1,2,5,4,3,2,1,2,4,4,3,4,3,3,4,5,3,2,1,1,1,3,4,5,4,3,5,5,5,3,2,2,4,5,4,1,5,2,1,5,5,3,3,5,5,3,1,1,5,1,1,4,3,2,4,2,1,1,1,2,1,3,4,4,1,2,4,4,5,4,1,5,3,5,2,4,3,4,3,4,1,3,2,3,1,5,5,5,2,3,3,4,1,2,2,5,5,1,4,3,2,1,1,1,2,3,3,2,1,5,1,3,5,3,5,2,4,3,3,4,4,5,2,4,2,1,2,4,4,3,3,3,2,1,3,4,3,3,3,2,5,3,3,4,2,2,2,2,1,1,5,5,5,3,5,5,1,2,5,1,3,1,2,4,4,1,1,4,4,4,3,4,4,2,3,1,3,4,3,4,2,5,4,5,4,1,2,4,3,5,5,2,1,1,1,1,4,2,2,3,4,1,2,5,2,5,1,2,4,1,2,3,1,3,1,3,4,4,1,1,1,2,3,2,5,4,3,4,5,2,4,1,3,2,4,4,5,3,2,2,5,2,5,4,5,3,4,4,5,2,2,1,1,2,2,5,3,5,4,5,4,2,3,1,3,4,4,2,1,3,5,2,5,2,4,3,1,3,2,3,4,3,3,1,2,1,4,5,1,1,4,2,4,1,1,3,5,2,5,2,1,1,3,2,2,4,2,4,4,5,3,1,2,4,4,4,1,3,2,1,5,2,3,5,3,5,2,5,5,2,2,5,3,4,1,3,2,2,5,2,4,4,3,2,3,3,2,3,4,1,3,1,3,5,2,5,2,4,1,4,2,2,4,2,1,1,4,3,1,4,1,1,1,4,1,3,2,5,3,5,4,1,3,5,3,1,5,2,4,2,1,2,2,4,1,2,3,5,2,5,1,2,1,3,2,4,2,2,1,3,3,4,5,5,1,4,3,2,3,3,4,1,4,5,4,5,4,2,5,3,2,1,4,5,4,2,3,3,3,3,4,2,1,3,4,2,1,3,3,3,2,2,2,2,3,4,2,2,2,1,1,4,5,3,2,2,5,5,5,4,1,1,4,2,5,2,5,4,1,4,5,2,1,2,2,4,1,3,1,4,1,1,1,5,3,5,5,2,3,4,5,4,4,1,4,3,4,2,2,2,3,5,1,1,2,4,5,3,2,5,1,5,2,4,4,5,2,3,4,1,4,4,3,3,1,3,2,3,5,3,3,4,1,3,4,2,3,3,3,3,5,2,1,2,5,5,3,4,5,2,1,4,2,2,5,3,4,4,4,3,5,4,3,5,5,3,2,3,3,5,5,3,5,3,1,3,4,3,3,2,2,1,3,5,2,3,4,3,2,1,4,4,4,5,4,3,5,2,2,5,4,4,1,1,3,2,4,4,3,3,2,5,4,5,1,2,2,2,2,4,4,1,2,4,2,5,5,4,3,2,4,4,1,2,4,5,2,4,3,3,5,5,4,1,5,1,3,2,1,1,5,3,1,5,3,3,4,5,1,4,5,5,2,1,1,4,3,3,1,1,2,1,2,1,2,2,2,4,2,3,2,4,4,2,2,3,4,3,4,4,3,5,5,1,4,3,1,4,5,3,5,3,4,3,4,5,1,2,5,4,1,5,4,4,5,3,1,3,4,5,5,5,1,1,5,1,5,2,5,2,5,5,1,1,1,3,2,3,4,5,1,3,5,3,1,5,5,1,2,3,3,5,4,1,5,4,1,3,2,3,2,2,5,3,5,5,1,5,4,4,4,1,3,3,1,4,4,2,2,4,2,3,5,4,1,3,1,4,2,4,1,2,3,2,1,3,1,4,4,5,4,5,3,4,2,4,4,1,1,5,2,4,4,4,2,5,2,2,3,2,4,3,4,3,1,2,5,3,1,2,5,5,4,4,5,2,3,2,2,4,3,3,1,5,3,2,4,3,5,2,1,1,3,3,1,1,1,1,1,2,2,4,3,4,2,3,1,4,1,4,4,2,3,4,2,2,1,3,4,4,5,4,4,1,1,2,3,3,4,1,5,5,4,3,1,5,5,1,4,3,4,2,2,2,2,3,4,4,5,5,1,5,4,5,2,2,5,4,5,2,4,4,3,2,3,4,2,2,3,3,1,2,3,1,3,4,3,1,4,5,5,5,5,3,3,5,1,1,5,2,1,1,4,1,4,1,2,1,4,4,3,1,1,1,3,3,5,3,2,4,1,5,5,3,3,3,4,5,1,5,5,2,1,4,5,4,4,4,2,3,1,3,1,1,4,2,5,5,2,1,1,3,2,1,1,2,4,3,4,3,4,1,4,4,4,1,4,1,3,2,4,1,5,1,1,5,1,2,5,5,5,3,2,1,5,4,3,3,4,4,4,2,1,1,1,1,1,2,3,2,5,5,5,5,2,3,1,4,3,1,2,4,5,5,1,1,2,3,3,2,2,2,2,3,3,3,1,5,2,2,1,1,1,1,4,5,1,4,4,2,4,1,5,1,1,2,2,1,2,2,2,4,4,2,1,3,3,3,4,5,1,3,3,5,3,2,4,4,2,1,5,4,1,1,3,3,3,4,5,1,3,1,1,1,5,1,2,2,2,5,2,5,4,2,1,3,4,5,4,4,1,4,5,4,2,3,2,2,4,4,5,1,2,3,1,4,3,4,5,5,2,1,1,1,4,2,3,1,1,2,4,4,5,5,5,1,3,3,5,2,3,2,3,5,4,3,3,3,1,3,1,1,2,1,4,4,2,3,2,2,3,1,1,1,4,3,1,1,5,2,3,1,3,2,1,2,2,1,2,2,4,1,4,4,1,2,2,2,1,3,1,5,4,2,2,4,3,3,2,1,5,5,2,5,5,3,3,5,3,4,3,2,5,3,2,4,5,4,1,5,5,1,5,2,5,1,4,5,1,1,4,5,1,1,2,3,2,5,3,3,5,5,3,4,1,4,4,2,5,5,3,5,1,1,4,4,4,2,5,2,3,5,4,2,1,5,5,5,2,3,3,3,2,3,4,3,4,2,5,1,3,4,5,1,2,5,1,2,5,1,5,5,5,2,2,3,2,3,5,5,4,1,1,4,4,5,1,2,3,4,5,3,1,5,3,4,4,1,3,4,1,5,1,3,4,2,2,4,3,1,1,1,5,3,3,5,5,3,5,5,5,4,1,1,1,4,2,1,2,2,1,1,4,5,5,4,5,1,5,2,3,5,1,5,4,4,4,5,3,2,4,5,3,5,1,5,5,4,2,4,1,5,3,4,3,3,1,2,4,4,1,3,4,4,4,4,2,3,3,2,2,1,5,5,2,2,5,2,4,1,2,1,2,2,3,5,2,1,4,3,3,4,5,5,1,5,1,3,5,3,2,1,3,2,4,2,2,3,1,4,2,4,2,2,3,1,2,2,1,2,4,3,4,3,4,2,4,2,5,2,2,5,3,2,3,1,2,2,5,5,2,3,1,1,5,1,1,2,4,2,5,5,3,5,3,4,5,3,2,3,5,5,5,4,3,5,2,2,4,1,5,3,2,4,1,4,3,1,2,3,2,1,5,5,1,3,3,3,4,2,1,4,4,3,4,2,2,4,3,1,3,4,4,5,5,2,3,1,4,4,2,5,5,3,4,1,1,1,2,5,5,2,3,2,3,1,1,3,1,1,3,3,1,2,4,4,4,2,3,1,5,3,4,1,2,5,3,5,4,3,5,2,3,5,2,3,2,4,4,4,4,3,4,2,4,5,4,1,5,1,2,4,4,3,1,4,5,4,4,3,5,1,3,1,5,4,2,3,5,3,2,4,1,1,4,2,1,5,3,2,2,3,4,1,1,4,5,1,4,5,5,4,3,4,3,5,3,5,3,4,3,2,1,4,2,1,3,5,4,3,5,3,4,4,5,3,3,1,5,5,3,5,2,3,4,2,2,2,1,2,3,1,4,2,2,1,4,1,2,3,2,5,5,5,4,2,1,3,5,4,4,4,1,5,5,2,5,3,1,5,1,1,5,4,3,1,3,1,5,4,4,2,1,5,3,3,1,3,4,4,4,5,4,1,5,1,1,3,5,2,2,1,5,4,2,2,4,1,2,4,4,1,3,2,4,5,1,2,2,5,4,3,4,5,2,5,5,1,3,4,5,4,5,3,1,2,3,1,3,2,2,1,3,2,3,5,2,4,1,1,3,4,1,5,2,1,4,2,1,4,1,4,5,5,2,4,4,5,4,1,2,5,5,4,1,1,4,3,2,4,1,2,1,5,1,2,4,3,5,1,2,3,1,5,5,3,4,2,4,4,3,1,3,5,5,4,1,5,5,1,4,1,5,1,3,4,5,5,2,2,3,1,3,3,2,2,1,4,3,1,2,3,5,4,2,4,1,3,4,4,3,2,3,3,3,4,3,4,3,3,1,2,4,3,5,2,5,2,5,3,3,4,5,1,1,3,2,3,1,4,2,5,1,5,5,3,2,2,4,4,4,3,2,4,1,4,4,5,1,5,2,5,3,2,5,5,5,3,4,2,5,3,3,1,3,3,2,4,1,5,3,2,4,1,1,2,3,4,5,4,5,4,4,1,5,2,1,4,4,1,3,2,4,4,2,5,2,5,1,2,5,3,4,1,3,2,2,1,4,1,4,4,1,5,2,2,4,1,4,4,2,4,5,4,5,4,4,3,4,3,1,5,4,3,4,4,2,1,2,2,4,5,5,5,5,4,3,1,3,2,5,3,5,1,5,3,1,2,4,2,3,1,4,1,1,4,1,1,1,2,2,4,2,4,4,3,4,2,4,1,4,4,3,2,5,5,4,3,3,1,5,5,1,2,4,4,4,2,3,3,2,5,4,1,5,2,3,5,2,2,5,1,2,3,1,2,2,4,1,3,2,3,4,1,1,1,5,1,4,3,5,3,3,5,2,1,5,1,1,1,3,5,4,5,4,5,4,1,1,5,2,3,2,2,4,1,4,3,1,1,2,1,4,1,5,5,5,1,4,2,2,2,1,5,4,5,4,4,3,3,4,4,1,5,1,1,4,5,3,4,1,1,5,5,2,1,4,1,2,2,1,1,4,3,4,5,2,5,1,4,1,1,4,5,1,2,4,1,4,4,3,5,4,4,2,3,1,2,2,4,5,3,3,2,2,2,5,2,3,2,4,2,1,2,5,5,4,1,3,3,2,5,4,2,4,1,4,3,3,4,2,5,3,3,1,5,2,4,4,1,5,5,3,5,2,5,4,1,2,3,4,1,4,2,5,4,4,2,3,5,2,5,5,4,1,3,5,2,3,3,5,1,5,3,5,4,3,3,1,3,2,1,2,2,4,2,1,2,1,3,1,4,4,4,1,4,2,2,1,3,3,3,4,4,5,3,3,1,3,2,2,1,3,4,2,3,3,3,4,3,3,1,5,2,2,1,4,1,1,1,5,2,4,1,2,5,2,3,5,1,3,5,5,2,1,3,5,3,5,5,4,2,4,1,2,5,5,2,2,5,2,5,3,2,4,1,1,5,1,2,5,2,4,1,1,3,5,1,2,4,2,3,5,5,2,3,5,1,2,3,4,4,4,5,3,2,1,3,1,1,2,4,3,2,5,1,5,4,2,3,3,1,4,2,5,5,5,3,5,5,5,1,3,4,5,4,4,4,2,3,3,4,4,5,2,1,1,3,3,3,3,4,1,5,2,3,3,1,1,5,1,5,3,5,2,2,5,2,3,2,5,4,3,1,4,5,4,1,4,4,2,1,3,1,4,4,3,1,1,4,5,2,3,4,2,3,1,2,4,3,3,3,3,2,4,4,5,1,3,3,3,1,3,1,2,1,3,4,2,4,5,4,2,5,2,5,3,4,3,1,4,1,4,3,2,5,2,5,1,5,2,4,3,1,5,5,5,2,4,1,2,4,4,3,2,3,1,3,1,1,3,5,5,2,4,5,1,1,4,1,1,5,5,2,2,2,3,4,2,4,2,4,1,1,3,3,5,4,4,1,1,3,5,2,5,1,3,1,4,5,1,4,4,5,2,3,5,3,1,3,2,4,4,1,1,5,1,5,1,3,3,3,3,2,4,4,4,5,4,2,2,2,5,3,1,3,3,4,1,5,3,1,5,4,2,1,2,5,5,1,4,4,5,1,3,1,4,2,2,5,3,3,5,4,4,4,3,1,2,3,1,5,5,5,5,3,4,5,3,4,4,1,1,1,5,5,2,5,3,2,2,3,2,3,5,1,3,4,2,3,1,5,4,3,5,2,2,3,5,1,4,5,1,3,3,4,1,5,2,5,2,5,1,1,1,1,3,5,1,3,4,5,4,5,2,5,3,4,1,1,2,3,2,2,5,4,2,4,5,2,1,2,1,4,5,2,5,4,2,4,5,1,3,5,4,4,3,4,2,3,3,5,5,1,5,5,5,5,2,1,4,4,4,4,2,3,1,1,5,4,2,3,3,2,4,5,2,4,4,2,1,5,5,5,5,2,3,5,2,5,4,4,3,1,2,4,3,5,4,5,3,3,4,5,4,2,3,3,5,4,4,4,4,1,1,4,1,2,5,1,2,3,4,2,1,3,1,2,2,2,1,4,5,5,2,3,5,2,3,2,2,2,5,5,1,2,2,1,5,5,2,5,4,1,3,4,1,5,1,3,2,4,2,5,5,3,5,4,1,5,2,1,3,2,3,4,3,3,1,1,4,2,3,2,5,5,5,4,4,5,4,2,4,4,4,1,1,4,5,2,1,1,2,1,3,1,1,4,4,4,1,5,3,4,2,4,2,5,1,4,2,4,3,3,5,4,5,3,4,1,5,4,1,4,2,2,4,2,5,3,5,2,5,3,3,5,3,1,2,3,2,5,1,5,5,3,2,2,4,4,5,3,3,1,2,5,4,5,5,1,5,4,4,1,3,3,4,1,2,4,5,1,3,3,2,4,2,1,2,1,3,2,1,3,3,1,1,3,3,3,4,1,3,5,2,4,4,1,3,5,3,1,2,2,5,2,3,5,4,3,2,1,1,4,2,3,5,2,4,1,4,3,3,5,3,5,3,2,5,2,4,3,2,3,5,2,2,2,5,3,1,2,3,5,2,1,5,4,2,3,1,4,3,5,4,4,1,1,5,2,1,2,5,1,1,1,4,1,5,3,4,5,5,1,2,4,5,2,5,1,1,4,2,1,1,2,4,1,5,4,4,4,4,3,4,4,4,5,5,5,4,1,5,5,1,3,1,1,2,4,5,3,2,5,4,2,4,2,2,2,4,4,1,1,3,3,4,2,5,3,4,1,2,2,3,3,2,4,4,1,2,1,3,5,2,4,5,1,1,4,1,5,4,2,5,4,3,5,4,2,1,5,1,5,5,2,2,2,3,2,2,4,5,1,1,2,1,2,3,5,2,3,4,2,4,4,4,1,3,2,3,5,5,1,4,5,3,3,4,1,1,5,1,5,2,5,2,2,2,4,5,2,3,5,2,1,3,3,3,5,3,5,5,5,3,5,2,4,5,5,3,3,2,3,4,1,5,1,4,5,4,3,3,1,4,5,3,5,4,2,5,1,2,4,3,1,3,4,5,4,1,1,3,5,2,3,3,3,1,5,2,3,2,2,2,4,2,5,5,3,5,5,2,1,2,1,1,5,1,2,2,4,1,5,5,5,3,5,1,1,3,5,3,3,5,1,2,2,4,4,1,2,1,1,2,3,2,3,4,4,4,1,1,4,4,1,3,1,4,3,3,1,4,3,3,3,5,4,4,3,2,1,1,1,4,5,2,1,4,4,4,3,3,1,5,5,4,5,1,2,3,5,2,2,4,4,4,2,2,4,2,1,3,2,5,5,2,1,4,5,1,5,5,3,3,3,2,5,3,5,1,1,3,5,1,5,1,1,2,2,5,4,3,1,2,2,3,2,1,4,5,5,4,5,2,5,3,5,4,1,1,5,5,1,2,1,3,2,3,4,2,1,5,4,1,1,5,3,2,2,4,1,3,4,3,3,3,4,4,5,3,1,5,4,2,5,2,5,3,1,5,3,4,2,1,3,3,5,1,2,2,2,3,4,3,4,4,2,3,3,4,4,3,1,4,3,1,2,5,2,2,2,2,5,2,5,3,4,1,4,3,3,2,2,5,2,5,3,2,5,3,3,1,3,1,3,4,5,2,2,3,1,5,5,5,1,3,4,1,1,5,2,2,4,2,4,3,2,1,5,3,4,5,3,5,3,4,4,2,4,5,2,1,3,1,5,4,1,3,5,2,1,2,4,3,3,2,1,4,4,4,5,2,2,3,3,2,1,4,2,3,5,1,1,1,1,3,4,5,1,3,5,2,3,4,2,2,2,2,3,4,5,2,5,5,1,2,4,1,5,5,4,1,1,3,3,4,2,4,1,5,4,5,4,5,3,1,3,2,1,1,1,3,3,4,2,1,2,3,4,5,2,4,4,5,5,3,3,4,5,3,5,4,3,4,1,5,2,1,5,3,4,5,3,2,3,5,3,3,1,3,3,2,2,3,4,1,5,2,2,1,5,5,1,2,4,4,4,2,2,1,5,4,5,5,4,4,2,5,3,4,2,5,2,1,2,3,3,2,1,3,1,3,2,2,5,1,2,5,4,1,3,5,5,2,1,5,2,5,4,4,4,1,3,4,5,1,4,1,3,5,2,3,3,2,5,1,5,5,5,4,3,1,3,5,2,1,3,4,2,3,2,3,1,4,4,1,1,1,5,4,2,2,2,4,4,4,4,3,5,2,4,3,3,2,3,5,5,1,5,5,4,2,4,2,4,3,1,2,3,4,2,5,1,5,5,3,4,1,4,1,2,1,2,4,4,4,2,4,5,1,2,3,1,4,2,5,4,5,1,1,5,2,2,4,2,3,5,3,3,2,1,3,4,2,3,2,1,1,2,1,5,3,5,1,3,4,2,4,5,3,4,1,4,4,3,3,1,5,3,1,1,5,5,4,4,1,2,5,1,4,3,3,1,2,5,1,4,3,2,1,3,2,1,4,5,1,2,2,5,3,3,2,4,2,3,2,4,5,2,1,2,4,4,2,2,5,3,4,5,4,1,5,2,3,3,5,2,1,2,2,5,3,4,3,5,1,5,3,2,2,1,3,2,3,1,2,5,5,5,4,2,4,5,5,1,4,4,3,2,5,2,1,5,2,5,2,1,3,3,2,4,3,4,5,3,4,3,5,3,4,1,5,2,4,1,1,4,2,5,1,3,1,2,2,5,2,5,2,5,1,2,2,4,1,4,4,2,5,2,5,3,5,5,4,2,5,2,3,2,4,2,2,3,3,3,3,4,3,1,4,2,5,4,2,1,3,1,1,4,4,3,4,1,3,5,5,2,2,5,2,3,2,4,3,2,1,1,1,5,5,4,1,4,4,1,4,5,4,5,5,2,4,5,4,4,5,4,4,3,1,2,4,3,4,2,1,5,3,3,3,1,3,4,5,3,4,3,1,5,2,1,1,5,1,4,5,3,5,3,5,3,1,1,1,2,5,1,4,2,5,4,1,5,2,3,2,4,2,4,1,3,5,1,3,5,2,3,4,3,1,1,5,2,5,4,3,3,1,2,5,1,3,1,2,4,4,3,5,3,3,1,5,1,2,2,2,3,1,3,4,3,5,4,3,4,3,3,2,3,2,5,4,1,2,5,2,2,4,5,4,3,3,1,5,2,4,2,4,1,3,5,4,2,2,1,3,5,4,1,1,3,3,3,4,4,3,1,1,3,3,2,2,5,3,3,2,4,3,2,3,3,1,2,3,1,5,1,4,3,1,4,5,5,5,3,3,5,2,1,5,2,5,5,4,1,5,1,5,5,2,4,1,3,4,3,5,2,3,2,5,3,3,3,5,5,3,1,4,4,4,5,3,4,3,2,1,2,3,5,3,4,2,2,2,5,4,4,4,2,1,4,2,4,5,1,3,3,2,5,4,2,1,5,4,3,2,1,5,5,1,3,1,3,4,4,3,4,3,2,1,1,2,1,5,2,1,2,4,1,4,1,1,3,3,5,5,5,5,1,1,5,4,1,2,1,5,5,5,3,4,2,5,4,1,2,4,1,4,4,1,1,3,4,3,4,2,4,2,2,4,2,3,5,5,1,4,3,4,4,1,4,2,3,3,4,3,4,1,5,3,1,3,4,1,2,2,2,2,4,4,4,5,4,4,2,3,2,3,1,4,2,1,5,1,2,3,4,5,1,3,5,3,5,1,5,3,3,5,1,1,2,2,4,2,3,5,5,1,3,4,5,3,3,5,4,2,1,4,3,2,1,1,1,2,5,1,5,4,5,2,2,5,2,2,1,2,5,2,4,3,4,2,2,5,5,4,3,2,4,4,3,2,4,1,3,4,2,3,1,3,5,4,1,3,5,1,4,4,1,4,3,1,4,4,1,1,4,2,3,2,2,5,1,5,5,3,5,2,3,5,5,3,5,4,5,2,1,2,1,2,2,2,2,4,3,2,1,3,4,4,3,5,2,3,2,3,4,3,2,3,5,1,1,2,4,3,5,5,4,1,3,3,3,5,3,2,1,4,4,4,1,1,2,2,3,1,2,5,5,1,2,1,3,5,5,3,1,4,3,2,1,3,3,3,3,4,2,3,4,3,3,4,4,2,3,1,1,4,1,5,3,5,5,5,5,1,2,2,3,3,4,3,5,2,3,2,1,3,5,5,3,2,3,1,5,3,5,1,4,5,2,1,3,5,2,1,2,4,1,5,5,1,5,1,3,3,5,3,4,2,2,5,5,2,1,2,1,3,4,3,2,2,3,3,5,1,1,4,4,5,5,3,1,3,4,4,5,4,3,4,1,3,3,5,4,1,2,3,1,2,2,3,2,3,1,5,2,2,5,5,3,3,3,1,3,2,4,4,5,4,1,3,4,5,5,5,4,4,2,4,3,3,4,2,3,1,2,2,3,5,2,3,4,2,1,1,4,3,4,1,5,2,1,4,1,1,5,5,5,1,3,4,4,2,5,2,2,3,1,5,4,3,1,5,1,3,2,1,4,1,1,3,5,2,2,1,2,5,2,4,4,2,3,1,3,2,2,4,1,2,1,5,5,1,2,1,2,1,3,4,5,1,3,4,2,4,3,4,2,5,5,1,2,1,2,5,2,4,5,3,2,5,2,1,1,3,3,2,4,2,1,3,4,2,4,5,4,4,4,3,3,3,4,1,4,5,2,3,3,1,5,5,1,4,5,5,1,3,3,1,4,5,4,2,4,5,3,2,5,5,2,4,1,4,1,4,5,2,3,5,3,4,3,5,4,2,3,5,3,5,2,5,4,2,2,2,1,2,2,3,5,1,1,5,3,3,4,2,1,3,5,1,2,3,4,1,1,2,2,3,3,3,1,2,4,1,3,3,3,1,5,3,4,5,4,3,3,3,3,1,5,2,3,2,3,2,2,5,1,4,1,4,2,2,3,3,5,2,1,3,5,2,4,3,4,3,3,2,3,3,2,3,2,2,5,1,5,5,5,5,5,1,2,2,4,4,4,5,2,5,2,5,4,3,1,2,5,5,3,5,1,5,1,1,1,5,2,2,4,5,5,2,1,3,3,4,4,3,3,4,5,4,5,4,3,4,4,2,4,5,1,3,5,1,5,4,3,3,5,2,5,4,1,2,2,2,2,1,4,3,2,2,3,3,5,2,4,2,2,2,4,3,4,4,2,5,1,4,1,1,3,3,2,1,4,1,4,5,4,5,4,1,3,1,3,1,5,1,5,4,2,5,4,3,4,5,2,3,1,4,5,4,3,5,3,1,1,2,1,3,5,1,4,4,4,1,1,4,3,1,2,5,5,3,5,2,2,5,2,5,3,1,4,1,1,1,4,1,4,5,4,3,2,2,2,5,3,3,2,2,5,2,3,5,3,1,2,5,2,2,1,5,2,5,2,4,5,1,3,4,1,2,4,2,1,1,5,2,4,5,5,4,1,4,5,1,3,5,1,1,5,5,1,3,1,4,3,2,2,1,2,1,1,1,3,5,4,5,2,3,3,2,2,3,1,1,1,5,2,3,5,4,3,4,1,1,3,4,5,3,5,3,4,5,4,1,2,5,5,2,3,4,5,4,3,2,1,5,3,2,5,1,2,3,3,3,4,5,2,5,4,2,4,3,1,3,3,5,4,4,4,4,4,1,1,5,4,3,2,3,4,2,2,5,2,4,4,2,1,5,1,1,1,2,1,5,4,3,2,3,2,2,5,4,3,2,1,3,1,4,5,3,2,1,3,2,1,5,3,3,5,1,2,2,3,2,2,2,5,5,1,1,4,4,5,1,1,5,3,2,5,1,5,5,5,2,2,1,5,3,2,2,2,1,5,1,1,2,1,1,1,1,3,4,5,3,1,1,3,5,5,1,4,4,5,5,1,2,5,5,1,1,3,4,1,3,4,1,4,1,5,3,2,4,5,5,5,1,2,1,3,2,2,1,3,5,3,5,1,5,3,3,4,3,2,4,5,1,5,4,1,1,2,1,5,3,5,1,5,5,4,5,3,1,2,1,4,5,5,3,4,1,5,1,1,1,5,5,5,3,1,4,4,1,5,3,1,4,2,2,1,5,2,1,1,4,4,4,5,2,2,5,4,5,5,2,3,5,1,2,2,4,2,2,1,1,3,2,2,2,3,1,3,4,3,4,4,5,3,2,3,4,5,5,3,3,4,2,1,2,4,3,2,1,1,5,2,4,5,2,1,5,5,1,2,1,1,4,4,3,1,2,2,3,3,2,2,1,3,1,5,2,1,4,5,5,4,5,1,5,2,1,4,2,2,4,5,5,3,3,3,5,5,1,2,2,3,2,2,4,5,4,3,5,3,2,2,5,4,1,5,5,1,4,4,2,5,5,2,5,5,1,3,3,2,5,1,5,4,2,1,5,3,4,3,4,1,5,3,2,5,3,1,1,5,5,4,4,5,5,2,5,1,3,4,1,4,5,4,5,2,3,2,3,3,1,3,5,5,3,1,3,2,4,4,1,3,1,4,3,5,5,5,3,3,5,3,2,1,2,3,2,1,2,2,3,2,3,5,2,4,4,5,4,5,5,5,5,5,2,1,4,4,4,1,2,4,1,2,1,3,1,4,2,3,5,4,4,3,4,1,3,2,3,1,5,4,1,1,2,5,2,2,3,1,3,2,5,5,5,2,5,3,2,3,3,5,3,5,4,5,1,3,5,5,4,4,1,4,4,3,2,2,5,2,3,5,2,1,5,4,3,4,4,1,4,3,5,1,2,5,3,2,2,5,3,3,2,3,4,3,5,4,1,4,2,5,5,3,1,5,4,2,3,4,3,2,1,5,1,3,4,4,3,3,4,2,5,1,1,3,1,4,5,5,4,4,1,1,3,5,1,3,4,3,1,5,5,4,2,2,5,1,1,2,3,3,2,4,2,3,2,4,5,4,1,1,1,3,5,2,1,5,1,2,1,2,5,4,1,1,1,3,1,3,5,4,4,5,1,5,5,5,5,2,1,1,3,2,3,3,2,4,3,5,3,4,1,3,1,2,2,1,1,3,4,1,4,5,2,4,2,2,5,3,4,5,4,4,5,1,5,2,1,1,4,1,2,4,1,5,2,1,2,5,3,1,5,2,1,3,3,3,3,2,2,5,3,5,5,1,2,2,3,5,3,5,2,4,2,5,3,5,4,4,4,3,2,4,3,3,5,4,2,1,1,5,4,1,2,5,4,4,4,5,5,4,2,2,1,4,5,4,5,5,2,5,5,5,3,5,5,1,5,2,2,1,5,5,4,4,4,2,5,5,2,4,3,2,1,1,1,2,1,2,3,3,4,4,4,1,1,2,3,2,5,3,2,4,3,2,3,4,4,5,5,4,1,1,1,3,3,1,4,5,4,2,1,3,3,5,1,1,1,4,5,4,1,2,2,1,2,3,5,2,1,3,3,4,3,1,2,3,3,1,2,3,1,1,4,4,4,4,4,4,1,1,1,2,5,3,4,2,3,1,1,1,4,5,1,5,4,4,5,3,2,2,5,2,3,5,5,5,2,3,4,1,1,1,1,5,5,5,4,5,4,3,2,4,5,5,3,3,3,4,4,5,2,5,1,2,2,2,3,4,5,2,3,5,4,5,4,5,3,4,4,5,1,1,3,5,4,1,4,1,3,5,5,4,4,1,3,5,4,1,1,2,3,2,3,4,4,1,2,4,1,1,1,2,1,4,4,2,5,1,4,3,2,1,3,3,4,2,5,2,4,5,5,4,3,5,3,3,5,3,1,5,1,5,1,2,1,3,1,4,1,4,5,2,1,1,5,1,4,2,4,3,2,2,4,1,5,5,4,2,2,1,5,5,3,5,5,4,2,5,5,2,1,4,3,4,1,1,4,2,2,1,2,5,2,4,4,5,1,4,3,1,4,5,2,2,5,3,2,2,2,2,1,3,2,4,1,2,1,3,2,1,1,5,1,4,5,4,4,5,5,5,5,5,2,1,3,3,3,5,5,2,5,3,3,5,1,1,5,4,3,2,1,2,2,2,2,4,4,5,3,4,1,1,4,2,1,5,5,3,3,4,1,3,1,1,2,5,2,4,4,4,1,1,1,1,1,5,2,4,4,2,3,3,3,4,2,2,1,4,2,3,4,4,3,2,1,5,4,3,5,5,1,1,2,4,2,4,2,3,1,1,5,2,2,3,3,4,1,5,1,4,2,2,2,4,2,4,5,5,2,4,4,1,5,3,4,3,2,5,4,4,1,2,5,1,3,1,2,5,3,5,1,4,3,5,1,4,2,2,5,2,3,3,5,5,3,4,5,1,5,1,1,1,4,4,5,4,1,1,2,5,5,3,4,5,1,3,2,5,1,4,1,1,5,5,2,1,5,1,5,5,5,5,1,5,5,3,4,3,5,2,5,4,3,5,5,1,4,2,1,5,3,2,4,4,3,5,5,2,3,4,3,3,1,1,4,5,1,2,2,5,1,1,4,5,2,4,3,5,5,1,2,5,3,3,5,4,5,3,1,2,3,2,2,2,3,5,2,4,1,2,2,2,5,2,1,2,1,3,2,4,3,3,5,5,4,4,5,4,1,1,3,5,2,3,4,4,1,5,3,3,2,3,2,5,1,2,4,1,2,4,2,5,4,1,2,3,4,1,4,5,2,4,5,3,2,3,3,5,4,3,5,2,3,4,5,5,4,5,4,4,3,4,5,3,3,2,2,2,3,1,3,3,3,3,5,4,5,4,3,5,2,4,5,4,5,4,1,3,4,3,1,3,1,1,1,5,2,3,1,1,1,1,3,1,5,5,1,1,1,5,1,2,4,1,5,1,5,5,4,4,1,5,4,2,1,3,3,5,5,2,5,4,4,5,5,1,1,1,4,3,1,4,1,1,3,2,1,2,4,4,1,1,5,1,1,2,1,1,1,5,5,3,5,1,4,2,5,3,3,5,5,3,4,4,5,2,5,2,4,1,1,4,1,2,3,5,1,5,3,3,4,3,2,5,3,2,5,2,2,3,5,1,3,2,2,5,5,4,4,3,2,2,4,2,5,4,2,3,2,1,3,5,1,2,5,4,3,1,2,1,5,4,2,5,1,3,2,5,1,1,5,4,5,1,1,3,4,5,2,2,2,5,5,5,3,3,4,1,2,3,1,5,2,2,3,5,5,5,4,4,1,4,1,3,4,1,2,1,2,5,1,4,5,1,5,2,5,2,1,2,2,2,4,1,4,5,2,3,4,1,3,5,3,1,1,5,3,1,3,2,1,3,5,4,4,5,3,4,1,4,3,5,3,4,1,1,1,5,2,3,1,5,4,4,3,3,1,4,1,5,4,2,1,1,5,2,2,5,3,5,4,1,4,5,2,1,2,2,5,5,4,2,5,1,3,5,4,3,1,1,3,1,2,5,2,3,3,3,1,1,2,3,3,5,3,4,1,4,4,4,4,2,2,1,1,5,4,2,4,2,5,2,2,1,5,2,2,5,1,2,4,3,5,1,2,1,3,3,2,5,5,1,5,2,5,5,1,2,5,1,3,5,1,3,1,3,3,3,5,2,3,5,2,2,5,4,2,5,4,4,3,2,5,4,2,1,3,4,4,4,2,3,1,4,2,3,2,3,3,2,4,4,1,5,3,3,4,1,5,3,5,1,5,3,2,2,1,4,2,2,2,1,5,5,2,4,2,2,4,5,2,2,1,1,3,2,5,1,4,5,2,1,5,1,4,1,3,4,3,1,2,2,4,3,5,3,5,4,3,5,1,3,1,5,1,2,1,4,2,4,5,5,4,5,5,5,1,5,5,1,1,1,5,1,5,1,1,1,1,1,4,5,1,2,5,2,2,3,2,5,3,1,3,3,5,4,1,2,1,3,3,1,2,3,4,5,4,5,3,4,4,5,4,4,4,3,3,1,3,3,1,3,2,3,3,2,5,1,3,2,1,4,1,4,4,2,5,2,1,2,2,2,4,3,5,1,1,2,2,1,2,3,2,3,5,1,1,2,2,1,2,3,4,1,1,3,1,3,4,4,1,1,3,2,3,4,4,4,4,4,1,5,5,4,4,1,4,5,5,1,5,4,3,5,5,1,4,4,5,1,4,3,5,1,4,1,5,3,5,2,5,4,2,3,4,4,2,3,5,4,4,5,5,5,5,1,1,4,1,2,2,5,4,4,5,3,1,5,4,1,2,2,4,1,5,2,3,4,2,4,1,3,1,3,5,2,4,1,2,5,1,2,3,2,3,4,2,3,5,2,5,3,3,1,2,4,5,5,5,5,4,4,4,4,4,2,2,3,4,4,4,3,5,3,5,2,3,1,5,4,4,5,2,5,5,3,5,4,1,5,5,1,1,1,2,5,5,5,4,1,2,1,3,1,2,3,3,1,3,4,2,3,3,1,3,1,1,4,1,5,5,1,3,3,4,2,4,3,5,4,5,1,4,4,2,4,4,1,5,4,3,3,5,4,3,2,5,2,2,2,3,2,5,2,2,5,3,4,4,4,4,2,3,4,4,1,4,1,1,2,5,1,2,5,4,3,2,3,1,3,5,1,2,5,3,5,3,3,3,5,1,3,4,3,3,4,5,1,5,2,4,4,2,4,4,4,4,1,4,3,3,2,5,2,2,3,4,4,1,3,3,3,5,4,4,5,5,3,5,1,5,2,1,2,1,5,3,3,3,3,2,2,4,2,2,3,5,2,1,2,1,4,4,4,5,2,2,3,3,1,3,1,4,5,1,3,3,1,5,3,3,5,3,5,4,2,2,4,3,1,1,3,4,2,3,2,2,2,1,2,3,1,4,3,3,1,1,1,2,2,4,4,3,3,2,3,2,2,4,1,4,3,3,1,3,2,4,1,1,1,4,1,2,5,5,3,3,5,1,5,1,1,5,1,4,5,2,2,4,3,3,4,5,1,4,3,5,4,3,4,2,2,2,3,2,2,3,1,1,3,3,1,5,2,2,5,4,1,3,4,5,5,4,5,3,4,2,1,5,1,3,4,5,1,5,2,2,2,3,2,2,2,3,1,5,4,3,4,1,2,4,2,5,3,5,3,1,1,1,2,2,4,4,4,2,1,3,3,3,5,3,4,4,5,2,5,2,1,3,4,1,1,1,5,4,1,5,2,4,3,3,4,5,3,4,3,5,5,1,1,2,3,1,1,4,5,4,4,3,1,5,5,4,3,2,1,5,1,5,2,5,2,3,4,1,3,1,2,3,1,5,3,3,1,5,2,2,3,4,4,5,3,4,3,4,3,2,4,2,4,3,4,3,4,2,5,2,5,3,2,5,3,3,2,2,2,5,1,5,2,2,5,2,5,3,4,5,3,1,5,5,3,3,5,3,2,1,2,5,4,4,2,5,4,2,5,4,2,1,1,5,5,2,1,2,3,4,4,2,3,2,5,4,5,5,2,5,2,4,4,3,2,2,2,5,3,1,5,1,3,5,1,3,5,5,2,5,4,5,5,5,3,5,5,1,2,3,5,5,3,4,2,3,2,4,4,4,5,1,4,2,2,3,4,3,3,4,4,4,2,2,2,5,5,2,3,2,3,1,3,4,4,3,1,3,5,2,4,5,5,4,1,4,2,4,5,2,2,4,2,1,2,4,2,2,1,2,5,2,2,5,3,2,3,4,3,2,1,1,1,2,4,2,4,4,4,2,3,1,2,1,3,3,5,1,3,5,2,2,1,2,2,3,3,3,2,5,4,2,2,1,4,1,3,2,4,5,4,3,5,1,5,3,4,5,3,4,4,4,1,2,3,4,3,2,5,2,1,4,1,3,1,1,2,3,5,2,1,3,4,1,2,5,1,5,3,3,5,3,5,3,4,1,3,4,2,4,3,3,2,4,2,2,4,1,3,5,2,3,5,2,5,1,2,2,1,2,5,3,1,5,2,5,1,4,4,2,4,1,4,5,4,2,3,3,5,3,2,5,5,5,5,5,1,5,1,3,3,3,2,1,4,5,5,5,1,3,4,4,4,1,1,5,3,1,4,1,2,5,5,5,5,2,1,4,1,1,2,2,3,4,2,2,1,3,2,2,4,4,3,4,5,3,4,5,5,2,5,1,3,2,2,4,2,1,2,2,1,4,3,2,4,2,5,5,2,5,3,3,1,1,4,3,3,2,3,1,2,3,5,3,3,4,1,4,1,5,2,3,2,1,2,2,3,5,4,5,5,3,5,1,1,4,2,4,2,1,2,5,1,2,3,3,3,2,3,3,3,5,3,5,4,5,2,2,1,1,4,4,3,2,4,2,5,1,3,1,5,5,3,4,5,1,4,4,3,2,2,2,3,3,5,1,5,2,5,3,4,1,4,1,5,2,4,4,2,5,2,4,5,2,2,2,4,1,5,1,5,3,4,3,3,3,4,1,4,3,1,1,3,5,2,4,2,4,3,3,5,2,2,2,2,4,5,1,1,4,4,5,2,5,4,4,1,1,2,4,4,5,3,5,5,4,5,1,2,4,4,4,1,2,1,5,4,3,2,4,1,3,2,2,2,3,3,1,1,2,2,5,5,1,5,5,1,2,4,1,1,3,2,3,4,2,1,3,5,4,2,1,4,1,2,3,2,1,4,5,3,4,1,3,3,4,2,1,1,4,5,5,2,4,1,3,5,2,2,2,1,5,3,5,5,4,1,2,1,5,4,5,3,4,3,5,2,2,2,4,1,3,4,4,4,2,1,1,1,2,5,3,4,4,4,3,5,5,2,1,1,5,4,5,4,1,3,4,2,5,1,3,4,3,2,2,4,1,4,5,2,2,3,4,3,2,2,5,4,5,4,1,4,2,4,4,1,3,5,3,1,3,4,5,3,5,4,1,5,4,5,1,2,1,2,2,4,1,4,3,4,5,2,1,3,4,2,4,1,1,5,5,5,5,1,2,1,1,5,4,1,1,3,2,4,5,2,4,5,3,3,1,1,4,3,1,1,5,2,5,5,4,1,1,3,3,5,5,1,3,5,5,2,5,4,4,4,1,1,3,1,2,2,1,1,1,3,5,2,3,3,1,2,4,1,2,3,1,4,4,4,5,5,5,2,4,3,2,5,3,1,3,2,3,4,3,4,1,2,2,2,4,3,5,3,5,2,1,1,4,2,4,3,2,3,4,3,4,2,5,1,5,4,4,5,2,3,1,4,1,5,4,2,1,5,4,3,5,1,3,2,2,5,2,4,2,2,2,1,5,3,5,2,4,2,2,5,1,4,4,5,1,2,1,5,5,5,3,4,3,3,4,2,2,3,2,1,5,2,3,2,4,5,4,3,4,1,5,3,2,1,2,5,3,4,4,2,3,2,4,4,4,2,4,3,2,3,2,3,2,1,5,1,3,4,1,2,5,5,5,3,1,5,2,2,2,4,5,5,4,1,1,2,1,3,5,3,4,3,5,3,2,3,5,3,2,2,3,3,1,2,2,2,3,4,1,5,2,5,3,1,3,3,5,3,4,5,3,3,2,5,4,3,4,5,2,3,3,2,4,5,2,2,1,5,3,5,3,2,1,3,4,3,4,2,3,1,1,1,2,4,1,1,5,4,4,1,4,4,3,2,5,1,3,4,1,5,4,4,3,2,4,4,4,4,5,2,5,2,5,4,3,2,1,2,4,2,3,3,5,3,1,2,2,4,1,5,4,3,5,5,5,2,2,5,1,1,2,2,2,1,4,1,2,2,4,3,5,4,3,4,4,2,2,1,2,4,2,2,1,4,4,1,2,3,2,4,4,5,2,4,5,1,4,4,3,3,2,5,4,3,5,5,5,5,4,1,5,2,3,3,4,4,1,5,2,2,5,4,1,5,1,2,4,3,1,4,1,5,2,1,2,4,2,1,3,1,5,4,4,5,1,2,3,1,2,3,1,2,4,3,3,2,2,5,3,2,3,4,1,4,2,5,1,4,2,4,2,3,4,5,2,4,2,4,5,4,5,5,4,2,5,1,3,1,5,5,2,1,2,3,5,3,4,5,3,2,2,3,2,5,5,4,4,2,2,4,3,1,1,3,5,5,1,2,4,4,5,4,3,3,4,5,3,1,2,3,5,3,5,5,2,1,1,3,2,2,2,4,3,3,5,2,3,5,2,2,4,2,2,4,1,2,3,5,4,2,1,3,1,4,2,4,4,1,3,3,4,5,1,3,5,2,5,1,1,3,1,4,5,1,2,5,5,1,1,1,1,1,4,4,1,5,3,3,3,2,2,3,2,4,4,1,4,4,5,4,4,2,3,4,4,1,3,1,4,1,5,3,4,4,3,3,3,4,1,2,2,3,4,1,4,2,3,4,1,5,3,1,3,3,1,3,5,4,1,3,4,3,5,3,1,2,5,3,3,5,1,1,4,2,4,2,5,2,5,2,4,1,5,5,4,1,3,3,5,5,4,4,4,5,2,1,2,5,3,4,1,4,3,3,2,2,3,4,2,1,1,5,1,2,4,3,3,2,2,4,4,3,4,5,4,5,4,2,3,5,2,3,1,4,1,1,1,2,1,1,2,4,3,5,1,3,4,4,1,5,4,2,1,4,5,3,3,2,1,3,2,1,3,2,5,4,2,5,3,3,1,3,5,1,3,5,3,5,3,1,4,2,5,2,3,4,1,5,2,1,2,4,2,1,2,2,2,5,3,2,2,1,5,2,3,4,1,5,4,1,4,2,5,1,1,3,5,5,3,3,1,3,2,2,1,1,5,2,4,4,4,3,3,5,2,5,1,1,4,1,3,2,4,3,4,2,1,2,1,5,3,1,2,1,5,1,1,5,5,3,1,2,2,1,3,2,3,2,3,3,3,2,5,2,2,2,5,3,5,2,2,1,1,1,1,1,3,1,2,1,1,3,2,1,5,2,4,3,2,1,1,3,3,1,3,3,4,5,4,5,4,1,2,4,1,1,2,1,1,3,2,2,5,5,1,5,2,1,2,2,4,2,4,1,3,1,4,4,5,1,2,3,5,4,3,5,4,2,2,2,2,1,3,2,4,2,5,1,1,4,5,3,1,2,1,1,4,3,5,1,5,4,1,2,4,4,5,3,1,2,5,5,5,4,5,4,5,2,1,2,3,3,3,2,1,2,2,3,4,4,1,1,5,5,3,4,5,4,5,5,2,3,2,5,1,3,5,4,4,3,4,2,3,5,4,4,1,2,3,1,2,4,1,3,2,5,2,4,2,4,1,5,3,4,1,5,4,3,2,1,1,1,1,2,2,1,3,2,1,3,1,1,1,3,4,5,1,4,1,3,4,5,2,2,4,1,4,2,1,4,1,5,4,2,4,3,4,4,1,4,3,4,4,3,2,3,5,5,2,2,4,4,1,1,5,5,1,5,1,4,5,2,3,1,4,5,3,3,5,1,5,1,2,3,1,3,2,1,2,1,2,4,4,5,1,1,4,1,1,4,1,5,1,5,4,3,5,5,1,3,3,2,2,4,4,3,1,5,5,2,5,5,5,1,4,3,4,1,4,1,1,5,5,4,4,1,3,5,4,2,4,5,1,3,5,1,1,1,4,4,2,2,3,3,3,3,1,3,5,5,1,4,5,3,5,2,2,1,3,3,5,3,5,5,3,1,2,4,5,1,4,4,5,4,4,2,2,4,3,4,1,4,4,2,2,2,5,3,5,3,2,3,4,5,1,4,3,2,3,1,2,3,1,5,3,1,2,3,2,1,1,5,4,5,1,1,4,2,1,4,4,5,1,5,2,1,1,5,5,4,2,5,5,3,1,5,3,4,1,5,2,2,3,5,4,2,1,5,4,3,2,3,3,4,2,2,2,3,1,2,4,1,2,4,5,2,2,4,5,2,3,1,5,3,4,3,3,1,3,5,4,1,3,4,2,2,1,2,1,4,2,1,5,2,4,3,4,3,5,4,1,2,4,2,1,5,5,4,1,5,5,3,3,1,4,3,1,2,3,1,4,1,5,4,2,2,5,2,3,3,2,2,1,3,5,4,1,3,4,2,5,2,3,4,4,5,2,1,5,5,1,1,4,4,3,3,3,1,3,5,3,1,1,4,2,4,2,5,5,2,4,3,4,3,3,2,5,4,5,4,2,1,4,4,5,1,2,1,1,5,2,1,1,4,5,3,4,1,1,2,4,2,1,1,2,4,3,5,1,2,4,5,2,3,1,5,3,5,4,2,1,3,2,4,3,4,4,5,1,1,1,5,4,3,5,2,3,2,3,5,2,1,2,3,2,2,2,1,4,2,3,5,1,4,2,5,2,3,1,4,4,4,5,3,1,2,1,3,3,4,2,1,3,2,4,3,2,1,2,4,5,1,1,4,5,3,1,4,5,1,4,1,1,5,2,5,4,1,3,2,5,4,2,2,2,4,2,2,2,1,4,3,4,4,5,1,2,2,4,2,2,1,2,4,5,5,2,4,4,5,4,4,1,5,1,2,3,5,4,5,5,5,1,5,4,4,2,3,1,2,3,2,3,3,2,4,3,3,4,1,4,3,3,1,4,5,3,4,1,3,3,5,3,4,3,1,3,1,2,5,2,4,4,1,5,2,4,5,2,1,5,4,1,3,3,3,1,5,3,3,2,2,3,3,2,4,3,4,2,4,2,5,4,3,5,2,2,4,3,4,5,3,4,3,1,2,3,4,2,4,4,3,4,5,1,3,3,3,1,4,3,4,5,4,3,4,2,1,5,4,2,1,5,3,4,1,2,2,5,2,3,4,5,1,4,4,3,3,1,3,2,3,3,4,5,1,3,5,5,2,4,2,5,2,5,3,2,4,4,5,1,5,3,4,4,4,4,4,3,4,1,1,4,5,4,3,1,4,3,5,4,1,5,2,4,3,3,1,2,3,4,5,5,1,3,5,2,3,1,5,4,2,3,5,3,3,5,1,3,4,3,3,2,4,5,1,3,1,1,3,5,4,2,1,2,4,5,1,5,1,3,1,1,4,4,2,4,2,4,2,1,3,4,5,3,3,2,2,2,5,2,5,2,2,5,4,2,3,3,3,3,4,4,4,2,5,5,1,3,2,4,2,2,5,3,2,5,5,4,1,3,2,2,3,3,3,1,5,5,5,4,1,3,1,5,4,3,4,1,4,2,5,4,5,2,5,3,1,3,4,1,1,5,4,2,4,3,4,4,5,5,5,4,5,1,1,3,5,4,1,2,3,1,3,4,1,1,3,2,5,5,1,1,2,3,5,2,3,2,5,1,3,4,2,1,5,4,3,5,5,2,1,1,2,5,1,2,3,1,5,5,3,4,3,2,1,2,4,2,5,1,4,2,5,1,2,5,5,1,2,2,2,5,1,2,1,2,2,1,4,2,4,2,1,4,3,3,4,3,4,2,5,2,2,5,4,4,5,5,4,5,3,4,2,5,5,1,2,2,2,3,2,4,1,5,2,3,2,1,3,5,4,1,2,5,3,1,4,1,4,1,3,5,5,5,5,4,3,3,4,3,5,1,1,2,2,4,3,1,1,1,5,4,4,5,3,3,3,1,2,4,2,5,1,3,2,1,2,2,2,2,2,4,1,1,4,4,5,3,4,5,2,5,1,3,1,5,1,1,5,4,3,1,5,2,1,2,5,1,3,1,5,3,1,1,4,5,3,1,5,2,2,1,4,2,5,4,3,3,5,2,5,5,5,5,2,5,4,1,4,2,1,1,1,2,3,5,2,2,5,2,5,3,2,3,5,2,2,4,2,1,3,3,3,5,2,4,5,2,1,5,3,2,2,1,3,5,1,2,1,4,5,4,1,5,3,2,2,5,2,5,5,1,4,4,3,5,3,2,3,3,2,4,4,1,3,4,2,2,3,5,2,2,2,1,3,3,3,1,5,4,2,2,2,2,2,3,4,3,1,2,1,4,1,4,3,1,4,4,4,3,4,1,5,2,1,5,4,5,4,5,2,1,1,2,2,1,1,1,4,5,1,2,4,2,3,2,2,3,4,1,4,2,4,4,3,1,3,4,1,2,3,3,5,5,3,2,2,2,5,3,3,1,3,1,5,2,5,4,5,3,4,5,2,4,1,5,5,4,3,1,2,4,5,3,5,3,1,1,2,2,2,4,4,1,2,2,2,2,3,1,3,3,1,2,3,4,2,1,5,1,3,5,2,1,1,5,5,3,3,2,2,1,5,2,2,4,4,3,2,4,5,4,4,5,4,4,3,4,1,5,4,1,3,5,2,5,3,1,2,2,3,5,2,1,5,1,4,2,5,3,5,4,2,1,4,2,4,1,1,5,3,2,1,3,5,1,4,3,1,2,4,3,2,5,1,3,2,3,1,3,5,1,5,3,2,3,1,3,4,2,2,1,1,2,2,5,4,5,4,3,1,4,1,4,5,1,5,5,4,1,3,5,3,3,3,3,4,3,3,1,4,5,4,2,5,1,2,4,5,5,5,2,2,1,2,5,1,2,4,1,3,5,1,2,3,4,4,3,3,1,2,1,3,3,4,1,2,2,2,5,1,5,1,4,3,4,4,2,3,3,2,2,5,3,4,3,5,1,3,4,4,3,4,3,5,4,2,3,3,2,5,4,5,1,2,5,5,5,3,5,3,4,1,1,2,3,1,5,4,2,3,2,4,3,5,2,4,5,3,3,5,2,5,2,3,2,2,2,3,1,5,2,2,3,5,5,3,5,3,1,1,5,5,3,2,4,5,5,2,3,2,5,3,2,3,1,1,2,5,2,1,4,2,4,5,5,5,3,2,4,5,5,1,3,5,1,3,4,1,2,5,4,3,3,4,4,4,2,2,2,1,2,4,3,4,2,4,1,4,4,1,5,2,1,5,2,3,2,5,2,4,4,4,1,2,1,1,4,1,4,4,3,3,5,1,2,1,3,4,1,2,3,3,4,2,4,3,3,2,5,4,3,1,2,3,5,1,5,5,2,4,5,4,3,3,1,5,2,3,4,2,2,1,4,3,2,5,1,3,3,5,5,3,1,2,1,4,4,1,2,5,3,1,1,4,4,1,2,2,4,5,4,5,4,1,1,1,3,2,3,3,5,5,4,5,3,4,5,1,1,4,2,2,3,4,5,2,4,3,1,1,1,4,3,1,1,4,2,5,3,3,1,3,5,1,2,2,1,4,1,4,3,1,1,1,5,3,1,1,5,2,5,5,1,5,4,2,5,4,2,2,2,4,2,5,4,5,1,5,5,2,1,2,4,4,3,5,3,3,4,4,2,1,4,2,4,2,5,3,3,4,2,1,1,3,3,1,5,1,5,4,2,3,4,2,2,2,4,4,4,3,1,5,5,1,1,2,2,2,2,1,2,3,2,5,5,1,4,3,3,3,5,4,4,2,2,2,3,4,5,2,4,2,1,2,4,4,3,5,1,1,4,1,4,1,5,3,3,2,1,1,4,1,1,4,3,3,5,5,3,2,1,4,1,2,3,4,1,3,1,5,3,4,1,3,5,4,3,1,4,1,1,5,1,5,5,5,5,4,5,4,4,1,5,1,1,2,3,2,5,5,2,1,4,5,2,3,5,4,5,4,2,3,2,5,4,5,3,5,4,4,5,2,5,4,1,3,2,4,4,5,5,3,4,3,5,4,2,4,2,3,4,2,5,5,5,2,3,2,1,4,3,3,4,4,1,3,1,2,2,5,4,4,2,2,3,4,3,5,5,2,4,1,3,2,4,5,3,2,5,1,1,2,4,4,2,1,1,2,4,1,1,2,1,2,1,2,3,5,3,4,5,1,2,5,2,3,1,1,5,2,3,3,5,1,1,4,2,2,5,5,1,1,1,2,2,1,3,1,3,1,5,5,3,1,4,5,2,3,3,4,4,1,4,5,4,1,5,5,2,1,5,2,4,3,5,4,2,4,4,5,3,4,1,3,5,5,4,3,3,1,4,2,3,2,2,1,5,5,1,2,5,5,1,5,4,2,1,4,4,4,1,3,3,1,1,2,2,3,4,4,5,1,1,4,5,3,2,1,5,5,5,5,1,5,4,1,3,1,5,4,4,5,5,2,3,4,3,4,2,2,2,5,3,5,4,3,2,4,2,2,1,4,1,1,3,5,5,5,1,4,1,5,4,4,4,3,1,1,2,3,1,3,3,5,1,4,5,4,1,2,3,3,1,1,1,2,3,2,4,5,5,5,1,5,5,5,4,5,2,5,4,4,1,2,5,2,2,1,4,4,5,1,1,1,2,5,4,4,1,3,1,3,5,2,1,2,3,3,5,1,2,4,1,5,2,3,4,4,3,3,1,3,3,4,2,2,1,5,3,2,3,5,5,4,1,2,2,2,4,5,3,4,1,3,4,3,1,1,4,5,5,1,3,4,5,4,2,5,4,3,3,5,4,4,5,4,3,2,1,5,5,1,4,3,4,1,4,5,5,4,4,5,1,2,5,2,4,1,3,1,1,2,4,4,1,4,1,5,3,3,1,4,2,4,4,3,1,4,4,1,4,3,5,5,2,2,5,5,5,5,5,2,1,2,3,5,5,2,3,5,2,1,4,5,2,4,1,3,1,4,5,5,1,3,3,4,3,5,1,5,2,4,3,1,2,1,1,1,3,1,2,3,4,4,4,4,1,2,5,1,1,1,5,5,3,3,2,5,2,1,5,3,4,4,5,5,2,3,1,5,1,3,5,3,1,2,3,4,5,2,5,5,1,5,3,1,5,3,2,3,3,5,1,5,4,3,3,5,2,1,2,1,1,5,4,3,5,4,1,3,1,1,2,1,4,3,1,5,5,3,4,2,5,5,5,2,4,1,2,3,5,1,4,4,1,4,2,3,4,4,4,2,5,4,3,2,1,1,2,4,1,2,3,4,2,5,1,1,1,3,4,1,3,5,3,3,5,3,5,5,3,1,5,5,5,2,5,4,2,3,5,4,5,3,2,3,3,2,4,4,1,5,4,5,4,2,2,1,1,3,3,5,1,1,4,2,1,2,4,3,5,5,3,3,5,5,1,5,3,4,5,4,3,4,4,4,4,3,2,1,2,5,3,4,2,3,5,5,3,4,4,3,4,4,2,5,4,2,3,3,5,1,4,5,1,1,3,1,4,5,4,3,4,5,3,2,2,5,4,1,3,1,5,5,4,1,3,4,5,4,2,4,4,3,2,5,2,2,5,4,2,1,2,2,1,4,4,2,1,3,4,5,2,2,4,5,4,2,3,2,1,3,4,3,1,1,5,1,5,4,1,1,4,3,1,5,1,4,4,5,3,4,3,4,4,1,4,5,1,4,4,2,1,4,5,5,3,2,5,3,2,5,2,3,5,3,2,2,5,1,1,1,2,2,4,5,4,3,2,2,2,5,3,1,5,2,1,3,2,1,1,4,5,3,1,5,3,4,3,5,2,5,4,3,1,2,3,5,3,5,4,1,2,1,4,5,3,3,3,3,5,3,5,5,3,2,4,2,2,5,2,2,4,1,2,2,4,5,1,1,2,5,4,2,3,4,2,1,1,3,2,3,2,5,4,2,3,4,2,2,2,5,3,1,5,4,3,4,2,4,3,3,4,3,4,5,1,3,3,5,2,2,5,4,1,1,5,2,1,4,2,4,2,3,3,5,5,1,4,2,2,3,1,1,4,1,4,4,5,3,4,4,5,2,5,4,5,2,1,2,2,1,1,4,1,4,2,3,1,1,3,2,1,4,1,3,5,2,5,1,4,5,2,4,3,2,2,3,1,4,3,2,1,5,4,4,4,2,5,2,5,4,2,3,1,4,1,5,3,5,4,1,3,5,2,1,3,5,1,3,2,3,3,1,3,2,1,3,2,2,2,3,2,2,4,4,2,3,1,2,4,4,3,2,4,5,2,3,4,3,2,3,2,4,1,2,4,1,2,4,2,1,2,4,5,3,2,3,2,1,1,5,4,4,2,1,1,2,4,2,3,2,2,5,1,5,2,5,2,3,3,3,3,1,2,3,4,1,4,4,2,2,5,4,1,1,4,4,1,3,5,4,4,3,2,5,4,5,1,3,3,4,2,2,1,2,2,5,1,1,3,3,3,4,5,1,5,5,1,4,5,5,5,1,5,5,5,4,5,4,2,5,4,1,4,2,5,3,2,1,4,3,2,4,5,1,5,5,4,1,1,3,2,1,2,3,1,3,4,1,2,2,5,3,5,4,2,5,5,2,1,3,1,5,4,2,3,3,3,5,1,1,1,5,3,3,5,5,4,4,4,2,1,4,2,3,3,4,2,5,4,2,1,5,1,4,1,4,3,2,4,5,4,5,4,1,2,5,5,2,3,4,3,1,5,5,4,4,3,5,2,5,5,3,5,3,3,1,5,5,1,1,1,5,3,4,4,1,4,2,1,2,5,4,4,3,5,2,3,1,3,4,3,1,2,1,5,5,5,1,5,2,5,1,5,1,2,5,4,3,1,4,4,4,1,4,4,5,4,1,3,1,1,4,4,4,5,2,1,1,4,3,5,3,4,2,3,2,4,5,1,1,3,1,1,4,5,3,4,5,1,1,1,4,4,4,2,2,3,3,1,4,4,4,4,1,3,3,4,5,5,5,4,4,1,3,3,5,5,5,4,5,4,5,3,3,2,1,5,1,3,3,2,2,1,5,5,3,5,3,1,4,2,5,2,4,5,5,1,2,1,4,5,3,1,2,5,5,1,5,1,1,4,5,2,4,5,5,4,2,5,4,3,4,1,2,2,3,1,5,3,5,5,5,2,2,3,3,1,3,2,2,5,4,1,5,3,2,5,3,1,5,5,5,1,5,2,3,4,4,1,2,3,2,1,1,5,3,2,2,5,3,2,2,4,4,2,3,5,2,3,3,1,4,5,5,1,2,2,2,5,1,3,4,4,5,4,1,3,2,2,5,2,3,2,2,4,1,3,3,1,4,1,1,5,3,1,2,3,3,2,4,4,2,5,1,5,5,3,5,1,1,3,1,3,3,2,4,3,1,2,1,3,4,5,4,5,4,1,3,5,1,5,4,2,4,2,2,5,2,4,2,2,5,5,3,4,5,5,1,5,5,1,1,1,5,4,1,4,4,5,4,5,3,3,2,4,1,5,4,1,1,5,1,1,2,3,3,2,5,4,3,5,3,3,5,4,4,5,5,3,3,5,3,5,1,1,4,4,4,2,3,5,4,1,1,4,3,4,5,3,4,3,4,5,5,1,1,2,5,2,2,2,2,4,2,5,5,5,4,4,5,2,5,4,3,5,5,2,2,5,3,2,1,5,3,2,1,4,1,4,1,1,5,1,4,5,5,1,4,5,1,4,3,2,5,5,2,2,2,5,3,5,2,4,4,4,2,1,3,2,2,2,1,2,3,3,1,2,3,2,5,3,5,5,4,2,5,4,2,4,1,3,3,5,5,5,5,4,5,1,1,3,5,3,5,4,4,2,3,2,3,1,5,3,5,3,3,1,1,5,1,5,4,2,1,5,5,4,3,3,2,5,4,5,2,4,3,5,2,5,3,5,2,2,2,1,1,3,2,2,1,1,3,1,3,2,4,2,2,5,3,1,5,4,4,2,4,2,1,5,3,4,2,1,4,1,1,2,2,4,5,3,3,4,3,4,2,2,2,5,2,3,4,4,1,4,5,1,3,3,5,5,1,5,4,5,5,1,2,2,2,4,2,5,3,2,4,1,3,2,5,3,1,5,4,2,4,3,5,5,4,5,3,2,3,4,3,1,4,2,1,4,3,4,4,5,3,4,3,5,3,2,3,5,2,1,5,3,3,4,4,5,1,3,2,2,2,4,3,5,1,2,2,5,5,2,2,3,2,1,2,4,4,2,3,1,5,2,1,3,2,4,2,2,1,2,2,1,4,5,5,5,3,5,1,1,3,5,3,1,4,2,1,4,4,3,4,3,5,5,3,1,3,5,5,3,4,2,4,3,2,3,4,1,4,2,3,1,1,2,4,1,3,3,2,4,5,2,3,4,1,1,4,3,3,5,2,4,1,3,3,3,4,1,1,3,1,5,5,5,5,3,3,3,5,3,3,2,1,4,1,3,4,3,2,4,3,2,2,1,2,3,3,1,3,4,2,5,3,2,1,3,3,5,4,5,5,2,5,2,1,2,1,4,5,3,3,3,4,2,4,5,1,1,4,4,2,2,3,2,2,5,1,3,4,3,3,4,1,2,5,1,3,2,3,1,3,5,3,2,3,1,2,4,4,3,1,3,1,1,3,3,5,5,4,3,2,4,3,1,4,3,1,1,3,1,5,4,4,1,3,4,3,5,1,5,4,1,2,2,5,1,4,1,1,1,1,5,1,1,5,4,5,4,3,5,2,3,2,1,3,2,4,3,1,4,3,4,4,2,3,2,5,3,3,4,4,5,2,2,2,2,1,2,1,2,1,5,1,1,5,4,3,2,5,3,3,3,5,3,4,3,2,4,1,1,5,2,4,5,5,5,5,1,1,2,3,1,1,2,3,4,3,4,5,5,4,4,4,3,4,5,2,2,1,4,5,5,3,5,1,4,5,2,5,1,4,4,3,3,1,4,1,2,1,3,1,5,3,5,1,2,1,5,1,4,1,1,1,5,5,2,4,1,2,4,1,4,3,5,5,5,5,2,5,3,4,5,4,5,1,4,2,5,1,4,2,4,4,3,4,3,4,2,4,1,5,3,2,4,4,1,5,1,5,4,5,4,5,5,5,2,1,4,2,2,1,4,3,2,4,2,2,5,4,5,4,1,1,1,4,4,4,2,1,2,1,2,5,2,4,1,2,3,1,1,1,5,2,5,4,3,4,3,2,4,4,4,5,1,5,2,3,3,2,5,1,3,4,4,3,1,1,2,4,2,1,5,5,2,2,3,1,1,5,5,3,5,1,5,5,4,5,1,3,2,4,3,5,5,1,3,4,3,3,4,4,3,1,2,2,4,4,3,4,3,4,1,5,1,5,5,3,2,4,2,1,4,1,4,2,5,4,3,2,3,1,4,3,5,3,2,1,4,3,1,5,1,2,3,1,4,5,3,4,4,2,5,1,4,5,3,2,3,5,1,5,5,4,4,4,4,1,5,4,4,4,1,5,3,4,1,1,4,4,2,3,5,5,5,1,1,3,5,2,2,2,3,4,4,1,4,1,3,5,5,5,1,5,1,1,5,4,4,3,3,3,3,4,4,3,2,3,1,2,3,5,5,5,5,4,3,2,4,4,5,5,3,1,1,5,1,2,2,4,5,2,5,4,4,1,4,5,1,5,1,5,5,3,5,3,3,3,3,5,3,2,3,1,2,3,5,4,1,5,3,5,4,2,2,1,4,1,2,3,1,3,2,4,4,2,4,1,2,4,1,5,2,1,2,2,2,4,5,1,2,3,1,5,1,3,2,3,4,1,4,2,5,4,2,5,2,1,5,4,4,4,1,5,4,4,4,2,4,4,2,5,2,1,3,2,2,5,5,3,1,5,4,2,1,5,4,2,2,2,4,5,1,5,4,3,2,3,1,2,2,3,1,1,1,5,3,2,4,1,2,5,5,1,5,5,2,2,5,1,2,2,4,2,4,4,4,4,5,2,5,3,2,3,1,2,3,5,4,1,2,1,1,5,2,3,3,2,4,2,4,5,2,1,2,5,2,4,4,1,3,4,4,5,1,1,5,4,4,4,2,4,1,4,1,3,4,1,4,4,2,1,2,3,5,5,3,2,2,5,4,2,1,2,4,4,2,4,1,4,1,5,5,4,5,2,4,2,1,3,1,4,5,2,1,3,4,3,5,3,4,1,5,1,4,2,2,4,1,4,4,5,4,4,4,3,5,2,4,3,1,3,4,1,1,2,3,5,2,1,5,2,1,3,5,3,3,2,5,5,1,2,2,3,1,1,4,1,5,2,4,3,2,1,1,5,2,5,4,4,1,5,1,2,4,3,4,2,3,4,5,1,3,5,2,2,1,2,1,2,2,5,3,1,4,2,2,1,5,2,1,3,1,1,3,5,3,3,4,5,5,1,3,5,1,2,1,1,1,2,1,1,5,1,5,5,2,1,3,5,5,2,5,5,4,1,2,1,1,2,5,5,5,2,1,4,2,1,1,3,4,4,3,5,4,3,4,1,5,5,3,4,2,3,1,1,3,4,4,3,4,1,3,1,1,3,5,2,1,4,4,4,4,5,3,5,5,4,1,2,4,2,1,4,2,4,2,2,2,4,3,3,5,2,2,3,1,1,1,2,3,5,3,4,3,1,4,4,1,5,2,2,1,4,1,4,3,4,1,2,3,2,5,1,3,4,4,5,5,1,1,1,3,5,2,3,5,2,1,3,5,1,4,4,2,3,3,4,5,3,2,1,4,5,3,5,1,1,1,5,3,4,5,1,5,4,1,5,1,2,4,1,4,1,3,4,4,5,3,1,1,3,4,4,3,5,5,2,3,4,3,5,1,3,4,2,4,3,3,3,1,4,1,3,4,2,3,1,2,1,5,5,3,1,1,2,5,5,4,4,1,4,1,5,3,5,1,4,4,4,5,5,2,2,4,5,1,4,5,3,1,5,1,2,2,1,3,4,1,3,2,1,5,2,2,2,3,3,4,2,4,1,3,2,2,1,3,5,5,2,4,1,1,4,3,1,3,3,4,2,3,3,4,3,3,3,5,5,2,4,4,2,2,2,4,5,5,3,5,2,1,4,1,5,5,2,3,4,2,5,4,5,1,5,3,1,1,3,4,4,1,3,2,3,2,2,5,4,5,2,1,2,2,3,3,2,2,5,2,1,2,1,5,2,3,2,4,1,3,3,2,5,4,2,1,2,1,2,3,1,3,4,4,5,1,3,3,5,5,3,2,2,4,5,2,4,2,1,1,1,1,5,4,1,1,4,1,1,2,4,5,4,1,5,3,4,3,3,5,5,3,4,4,5,1,4,2,4,5,2,3,1,4,4,4,3,3,3,2,2,5,4,5,4,3,1,2,3,5,5,1,5,4,2,5,2,2,1,3,1,5,5,3,5,4,2,1,5,1,1,3,2,3,1,5,1,5,4,1,1,2,5,2,2,5,3,4,5,2,4,1,1,2,2,5,4,2,1,5,1,5,3,5,5,2,3,3,2,2,1,2,2,2,3,3,2,3,3,3,3,5,3,3,2,5,3,4,2,3,3,1,5,3,3,4,4,2,2,3,2,4,5,1,5,5,5,3,1,3,4,5,2,3,5,1,5,3,3,5,4,1,3,2,1,1,2,5,2,2,1,1,1,5,1,5,1,3,2,2,3,1,1,2,5,3,4,5,4,4,5,5,1,1,3,4,3,5,5,3,5,4,1,1,1,4,3,3,3,2,4,1,2,2,3,1,1,3,2,2,4,3,2,4,1,4,5,4,3,3,4,2,2,5,3,3,4,5,5,3,4,2,2,4,5,4,3,2,2,3,4,2,1,1,1,5,4,5,4,3,4,2,2,3,5,2,3,4,3,5,5,5,1,1,4,2,3,4,2,3,2,3,4,3,3,4,3,1,1,5,4,4,5,1,2,2,3,4,5,4,2,5,5,2,2,2,1,1,2,1,2,2,2,5,2,5,1,2,1,5,3,4,2,1,3,1,5,4,3,2,4,4,4,1,1,2,1,1,3,3,3,4,5,2,5,4,5,4,4,5,3,1,1,3,1,3,4,4,2,3,5,2,4,1,1,5,5,5,1,4,1,1,3,1,1,1,5,2,5,5,3,1,3,5,3,3,3,5,2,3,1,3,3,4,4,4,5,4,1,5,1,4,5,1,4,4,5,2,2,4,1,1,2,2,3,2,4,3,5,2,2,3,3,5,5,2,3,2,2,3,3,1,4,3,3,4,5,4,5,5,5,5,3,1,1,4,3,3,4,4,3,3,2,4,4,3,4,3,4,1,4,2,2,1,3,1,5,2,1,1,4,4,3,1,5,4,5,1,4,4,4,1,1,4,4,1,1,3,5,3,2,4,4,5,4,1,3,5,2,2,4,4,1,5,2,5,1,3,3,1,4,2,5,1,2,5,3,5,4,4,2,2,5,3,4,5,2,3,4,4,1,5,3,4,1,3,1,3,4,3,4,2,5,4,2,1,5,1,1,3,2,3,3,4,3,2,5,2,2,1,2,5,1,2,2,2,2,1,5,1,1,3,1,5,1,5,3,5,2,5,2,4,4,5,5,2,3,2,2,3,1,4,5,2,4,5,5,3,3,3,4,2,1,4,1,5,1,5,5,5,2,4,5,4,4,3,1,5,3,2,4,1,4,1,2,3,5,3,1,4,2,1,2,4,3,3,2,1,5,5,2,3,3,1,4,2,4,4,2,2,3,2,3,5,2,5,3,5,1,1,5,1,3,4,2,5,2,1,2,4,3,5,4,1,2,4,2,4,1,2,2,5,2,1,2,4,3,5,1,1,2,2,2,3,3,1,1,4,4,3,4,3,5,4,2,2,2,4,4,2,4,2,3,4,5,3,5,3,3,5,2,3,2,2,5,4,2,2,1,2,5,4,3,3,4,4,4,1,1,5,2,2,1,1,1,1,2,1,3,3,4,4,3,1,2,2,5,2,4,5,4,2,4,3,3,4,5,5,2,4,1,5,2,5,4,1,2,3,4,5,5,1,1,5,4,5,4,5,3,2,3,3,2,1,3,4,1,1,5,4,5,5,2,1,1,5,2,3,1,4,2,2,2,4,5,1,5,1,4,5,5,1,1,3,5,1,2,4,2,2,4,5,4,5,5,2,4,2,5,4,1,2,5,3,3,5,5,4,2,5,1,4,4,3,4,5,1,2,5,5,2,4,5,3,2,2,1,4,3,5,1,2,3,3,3,3,2,1,4,4,3,1,3,4,5,3,1,1,5,4,4,1,3,5,5,3,4,5,5,3,1,3,1,1,2,5,5,3,2,1,4,1,3,2,5,5,4,4,5,3,5,4,5,2,1,5,3,2,2,4,2,4,1,2,5,5,2,4,4,4,2,4,1,3,4,3,1,3,4,4,4,3,5,4,1,4,4,3,5,1,3,4,1,1,1,4,1,3,1,1,4,3,4,5,4,5,5,5,2,4,3,4,5,4,2,1,3,5,2,3,3,4,1,1,1,1,4,3,4,1,5,3,2,1,5,3,3,3,4,2,2,3,4,5,2,5,2,3,5,4,3,2,3,4,4,4,1,3,3,2,2,5,2,1,1,4,3,5,4,2,4,1,1,2,5,5,3,2,5,1,1,5,1,2,5,5,4,2,4,4,1,2,3,3,1,3,5,2,4,2,4,1,3,2,1,4,4,1,2,4,4,5,2,4,3,5,4,5,4,1,3,4,3,1,3,3,3,2,1,1,4,2,3,3,3,5,4,4,2,5,1,5,4,3,5,5,2,3,4,4,5,1,5,1,1,4,1,4,1,5,5,1,4,1,5,4,2,4,2,2,3,2,2,3,4,2,2,1,5,4,4,3,5,5,1,4,1,2,2,1,5,3,1,5,4,2,4,3,1,5,1,4,5,2,4,2,1,3,4,3,2,3,5,1,4,1,3,2,3,2,3,3,1,5,2,1,2,4,3,4,2,1,4,3,3,1,4,1,1,3,3,3,3,2,3,2,4,1,3,3,3,4,4,3,2,2,5,4,5,5,5,2,1,1,1,1,3,1,1,1,3,3,3,4,1,4,5,1,2,4,1,3,1,3,3,3,5,2,1,3,5,2,2,2,4,4,3,4,3,4,3,3,2,5,1,5,1,5,4,3,3,5,3,5,3,2,2,4,3,3,1,3,1,5,3,3,4,3,3,2,4,3,2,5,3,5,4,3,1,3,1,3,3,1,3,3,4,3,2,2,2,1,3,1,1,1,4,1,1,4,3,5,2,3,1,5,3,5,5,2,1,4,1,4,5,5,5,4,3,5,1,5,2,3,2,5,4,2,5,5,2,2,4,3,4,1,1,1,5,4,4,1,1,2,3,5,4,3,5,1,2,5,5,4,2,5,2,4,5,2,2,1,2,4,3,5,5,1,4,4,5,4,3,3,2,3,3,1,2,5,1,4,4,5,3,1,2,2,1,1,5,4,4,2,1,5,5,5,4,3,1,3,2,4,5,2,3,4,3,1,2,5,2,2,4,5,1,4,4,4,2,5,4,3,3,3,4,2,1,3,2,1,2,3,1,4,2,4,4,5,1,2,4,1,5,2,5,3,3,4,4,2,2,4,2,3,5,5,5,4,4,3,1,4,4,2,1,2,5,4,3,5,5,5,3,4,2,1,1,4,4,2,3,5,4,2,1,4,4,1,5,5,2,2,5,3,5,3,3,1,5,2,3,2,4,3,3,5,2,5,4,5,3,5,2,5,4,4,3,4,1,3,4,5,2,4,4,3,1,2,1,5,4,4,3,1,1,4,1,4,4,1,2,4,1,1,3,2,4,5,5,5,5,4,4,4,2,5,2,1,1,2,1,1,1,5,5,5,3,5,2,1,3,1,5,5,4,4,4,3,3,1,3,4,3,5,1,3,1,3,4,3,4,2,4,5,3,3,1,2,5,4,3,1,5,2,3,2,3,4,4,4,1,3,3,2,1,4,1,2,3,2,4,5,4,4,3,4,5,2,2,5,4,3,2,4,5,2,4,2,4,3,3,2,4,3,4,4,2,1,3,3,1,5,5,2,3,4,1,4,5,5,3,4,3,1,3,4,5,4,3,1,1,2,5,4,3,1,3,2,1,2,3,5,3,5,4,4,4,1,4,2,4,5,1,5,2,2,5,2,3,3,2,3,3,5,1,1,4,2,1,5,1,2,1,3,5,1,5,5,1,1,4,1,2,4,5,4,5,2,3,2,5,4,4,5,2,5,3,1,5,5,2,3,4,4,1,1,5,2,4,5,2,2,3,1,3,2,4,5,2,1,4,3,3,3,2,2,5,1,3,2,4,3,3,5,3,3,2,2,3,5,2,2,2,2,1,4,1,1,4,1,3,4,3,4,1,2,3,4,4,2,1,2,5,4,5,5,4,5,3,1,2,2,5,2,4,2,3,3,1,3,2,5,4,4,4,5,4,4,1,1,1,5,1,4,1,5,3,4,1,2,4,1,2,4,3,2,5,5,2,5,4,4,3,4,3,5,5,1,5,1,5,1,4,4,1,2,2,1,3,4,4,4,3,3,1,2,4,5,3,3,2,5,3,4,5,3,2,4,4,3,5,2,4,5,4,3,4,5,2,2,5,2,1,4,5,3,4,4,5,2,5,1,3,1,3,3,3,2,1,3,2,3,1,4,5,5,3,2,2,4,4,4,4,2,3,5,3,1,3,1,4,4,3,5,3,2,5,2,5,4,2,3,5,5,3,4,3,3,2,4,4,1,2,2,2,4,1,2,4,4,1,3,1,3,2,2,3,4,3,1,4,3,3,4,3,1,3,2,1,2,3,5,3,3,4,3,5,4,2,2,3,3,3,1,3,2,2,3,5,3,1,3,1,3,2,2,1,1,1,2,4,1,2,2,1,2,2,4,2,4,4,5,5,3,5,5,5,2,2,2,4,5,1,5,4,4,3,5,2,4,2,2,2,1,2,4,5,3,1,5,4,5,5,2,2,4,4,4,1,1,4,2,5,5,3,2,3,4,4,4,3,5,3,4,5,1,4,4,4,1,5,3,5,2,5,2,2,2,2,2,3,4,2,3,2,3,5,3,5,4,2,1,3,1,3,4,2,4,2,3,2,4,5,2,4,5,5,4,3,2,2,1,1,3,4,1,3,5,3,1,1,2,1,5,4,3,3,3,3,4,4,3,4,1,5,3,1,1,2,1,4,5,5,5,1,5,3,2,4,5,2,1,1,3,4,4,1,5,5,3,2,1,1,3,2,1,2,3,5,1,4,2,1,5,5,2,3,2,1,4,3,5,3,1,4,2,5,4,1,1,1,5,5,5,5,2,4,5,2,4,3,5,2,4,5,5,4,2,1,3,5,5,4,3,1,1,2,3,4,4,4,3,3,2,1,4,5,3,5,1,1,4,3,5,5,2,3,5,4,5,3,1,1,1,4,3,5,3,2,5,4,3,1,5,1,3,1,4,3,5,1,3,4,2,3,2,4,1,1,2,5,2,1,1,5,1,4,3,1,3,1,2,2,3,3,3,2,4,1,5,1,2,3,3,5,4,4,4,2,5,5,4,1,4,2,4,4,5,1,5,4,5,2,4,3,1,4,1,4,1,2,2,1,4,1,3,4,4,5,5,3,4,5,1,2,2,3,2,5,4,4,4,1,5,3,4,2,4,4,1,2,3,1,3,5,3,3,1,1,5,4,3,1,1,3,1,3,2,4,5,5,3,3,1,1,3,5,3,1,1,1,3,1,3,4,1,1,5,3,4,5,2,4,3,3,2,1,4,1,4,2,3,3,3,5,5,2,2,1,4,2,5,3,3,1,1,5,5,2,3,4,3,2,3,2,4,2,2,5,3,4,3,3,3,3,1,4,3,4,4,2,1,4,4,4,5,1,3,5,4,2,4,1,2,2,3,2,1,4,5,4,1,5,1,2,5,4,2,5,3,1,2,3,3,5,4,2,2,1,3,1,1,4,4,1,4,4,5,1,2,3,5,5,4,5,2,1,2,3,5,2,5,2,2,1,5,4,1,2,5,2,3,5,5,2,5,5,2,2,4,4,5,2,2,4,1,1,1,4,1,3,4,5,2,3,1,3,5,1,3,3,5,3,1,3,3,5,1,3,4,3,1,5,5,3,5,5,4,2,4,3,4,3,5,1,5,5,5,5,4,4,1,5,4,3,3,5,1,3,4,1,3,2,1,5,4,4,3,3,2,4,2,3,1,1,4,5,4,5,2,2,5,4,5,4,2,1,5,3,4,1,1,2,4,5,1,1,1,1,2,2,2,1,1,1,3,3,1,4,4,2,3,3,4,4,3,5,5,2,4,3,3,5,4,1,5,3,2,5,3,5,4,2,1,2,2,5,1,3,3,4,2,5,3,3,2,1,4,5,2,3,1,1,3,4,4,4,1,2,2,3,5,2,1,1,2,4,1,4,3,2,4,3,3,5,1,4,1,5,5,1,3,2,3,3,1,3,1,2,3,2,4,4,4,2,5,2,5,5,1,4,4,1,5,5,2,5,1,5,2,5,4,3,2,1,2,5,1,4,1,5,1,3,1,5,1,2,5,2,5,3,3,4,3,1,3,1,5,1,5,2,1,2,4,1,5,4,1,5,5,1,4,4,3,3,5,2,5,1,4,4,4,4,1,5,5,4,3,2,2,2,3,3,2,3,5,1,3,4,5,3,2,1,3,1,4,3,2,2,2,5,3,4,1,4,5,3,4,3,2,3,2,5,2,5,4,4,4,2,1,2,3,3,4,2,1,4,2,2,3,3,5,4,5,5,4,2,2,5,1,1,3,1,2,3,5,5,5,2,3,5,4,3,2,2,4,2,4,1,4,1,1,4,1,1,2,1,2,2,5,2,2,1,4,3,1,3,4,2,2,4,4,2,4,2,5,1,3,3,3,2,3,1,5,5,4,4,2,5,1,4,1,1,5,3,2,4,4,3,2,5,3,2,5,3,3,5,1,4,1,1,2,5,4,5,1,4,5,5,3,3,4,2,4,5,4,3,5,3,3,2,3,2,3,3,5,4,2,2,4,3,2,1,5,3,1,3,5,3,4,5,3,5,1,1,3,5,1,2,5,4,2,2,5,2,4,1,1,1,5,3,5,4,1,3,4,5,4,2,1,5,4,3,5,4,5,3,2,3,1,3,2,5,2,3,4,3,3,1,4,1,1,3,5,3,3,1,2,4,5,3,5,2,3,5,1,5,2,3,3,3,4,1,5,1,4,3,3,3,5,5,3,4,2,4,5,3,3,5,1,5,2,1,5,2,2,3,5,3,5,2,1,4,3,4,4,5,2,2,4,5,1,4,4,4,3,5,2,3,3,1,4,2,3,4,5,3,3,1,4,1,3,4,5,4,5,2,3,1,4,1,4,4,4,4,1,2,2,2,3,2,3,3,1,3,4,2,3,2,4,3,3,1,2,4,1,4,1,5,1,3,3,4,5,5,3,3,4,1,2,5,3,5,4,5,3,4,1,4,1,5,5,5,4,5,5,2,1,3,3,5,5,2,5,2,2,3,5,5,5,1,1,2,4,2,1,1,2,5,3,1,5,4,3,1,4,1,1,4,5,2,3,3,1,5,3,4,3,2,4,4,4,3,3,4,3,5,1,2,2,4,1,3,3,3,1,5,1,2,2,2,4,4,4,4,3,1,5,2,5,5,5,3,3,5,3,2,2,4,2,4,4,5,5,3,1,5,3,2,3,2,4,5,2,4,5,3,3,5,2,5,1,2,4,4,5,3,4,3,5,1,3,4,5,4,3,1,2,1,5,5,2,2,5,4,5,4,4,5,4,5,4,3,1,4,3,5,5,3,3,4,4,5,5,1,5,3,2,2,5,4,3,2,4,4,2,3,5,4,3,2,1,4,1,4,4,4,4,2,5,5,4,1,5,5,4,1,3,4,5,5,1,3,4,4,1,3,5,2,2,1,1,3,1,3,1,4,1,4,4,5,2,4,4,3,2,2,4,3,4,2,3,4,4,2,4,3,5,2,4,5,5,3,4,1,1,4,2,3,3,4,3,3,4,2,1,5,5,4,3,3,5,4,1,3,1,4,1,3,1,5,3,4,4,3,4,2,2,3,3,3,4,5,3,2,5,2,4,2,5,2,5,4,1,4,3,3,1,2,4,3,5,4,3,5,3,3,5,2,5,3,3,5,5,1,4,3,3,2,1,3,2,1,4,1,1,3,3,4,1,5,1,1,1,4,5,1,4,2,1,3,2,5,5,4,2,2,5,1,3,2,1,3,1,2,5,3,3,4,5,1,3,2,1,3,4,3,5,2,3,1,4,5,4,1,1,2,1,5,5,4,5,2,1,5,5,2,3,1,2,4,5,1,4,2,2,3,2,1,1,2,2,2,1,2,2,1,3,5,3,3,4,2,2,1,2,4,3,2,2,1,5,1,4,4,4,3,4,5,4,1,5,4,1,1,4,3,1,2,5,3,2,4,2,3,5,5,4,2,5,4,4,5,4,5,5,1,5,4,3,5,2,5,2,3,4,5,3,1,5,4,3,5,2,1,2,3,4,4,2,3,2,2,4,3,4,2,4,1,3,4,2,3,3,1,2,4,1,5,2,4,3,2,2,1,1,5,2,1,5,1,4,2,4,3,3,2,4,3,1,4,2,1,2,3,5,5,3,2,2,2,2,2,3,4,4,4,1,4,4,2,4,3,4,3,5,5,4,1,2,2,4,5,3,2,2,2,1,5,3,3,5,3,2,5,3,5,3,1,1,5,1,2,1,3,2,5,2,5,1,2,4,1,1,1,3,4,1,4,4,1,2,5,3,2,3,5,4,2,3,4,3,5,1,2,4,1,3,3,5,1,1,3,4,1,1,5,1,5,3,4,2,2,2,2,2,4,4,3,5,2,1,3,5,1,3,3,3,4,3,3,5,2,3,1,1,5,5,5,1,1,2,1,5,2,5,1,3,4,5,5,3,2,3,1,1,1,3,4,2,3,3,5,5,5,5,3,2,4,2,5,4,2,4,5,5,3,2,1,1,4,5,4,2,5,5,4,2,2,4,4,4,5,1,1,1,3,1,1,2,3,2,5,2,5,1,5,4,3,1,3,1,1,2,2,4,5,1,3,3,4,5,3,3,2,4,1,3,4,2,5,3,5,4,1,3,3,3,1,1,3,1,5,5,2,1,5,2,2,3,1,3,3,4,5,5,5,4,2,4,4,4,5,2,5,5,5,1,1,5,3,3,5,3,5,2,4,1,3,5,1,5,4,2,5,5,3,2,2,1,5,2,5,3,3,5,2,4,2,4,5,2,5,4,2,3,3,1,2,1,3,4,2,1,5,1,1,3,5,1,2,4,5,5,3,3,3,3,5,5,5,5,4,3,2,4,5,5,1,5,2,1,3,3,1,1,1,1,4,4,2,2,2,5,2,4,1,2,2,3,2,2,4,1,5,2,4,4,2,1,2,4,2,2,3,3,5,3,1,1,1,1,1,4,2,3,2,5,1,4,1,1,4,2,1,5,2,3,1,1,5,4,4,5,1,3,2,5,2,2,4,1,1,1,5,4,1,1,3,4,3,3,4,4,1,4,4,1,3,2,4,3,3,5,3,5,3,1,2,1,5,3,4,4,4,5,2,1,4,2,3,1,2,5,2,2,4,1,5,4,3,5,5,5,3,5,4,1,1,2,5,1,2,1,1,5,5,1,5,4,2,5,1,5,1,1,5,4,5,2,1,5,3,5,4,3,4,2,4,5,2,3,4,5,2,5,4,3,4,3,1,1,3,5,2,3,5,4,1,2,1,4,5,4,4,3,1,3,3,2,2,5,4,4,3,5,4,2,4,2,5,3,4,4,4,5,1,2,4,4,1,4,2,2,1,1,5,4,2,3,3,2,1,5,4,2,3,4,2,1,2,2,2,5,2,3,3,1,3,5,1,4,4,2,2,4,4,3,5,3,2,4,3,1,2,3,2,3,5,3,5,5,2,5,1,4,2,5,4,5,1,5,5,4,1,4,5,2,4,5,2,5,2,1,3,4,3,2,1,1,2,4,2,2,5,5,3,5,5,1,1,3,1,1,5,1,4,5,5,2,3,4,2,5,3,4,3,1,4,4,1,5,4,2,1,3,5,4,3,4,3,4,4,2,5,2,3,4,5,2,1,3,4,3,1,4,3,3,5,5,2,3,5,4,3,5,4,3,2,5,3,2,3,5,2,4,4,3,1,5,2,4,5,1,2,5,1,1,3,5,5,4,1,4,2,3,5,4,1,3,1,3,5,4,5,1,4,5,2,3,5,2,2,4,3,4,4,1,3,3,3,3,3,2,4,3,3,5,1,5,3,5,4,1,5,3,4,5,2,5,2,3,4,4,4,5,1,3,1,1,4,2,3,3,5,1,5,4,1,5,3,1,3,1,5,4,3,2,3,4,3,1,4,5,5,5,5,4,5,3,5,5,5,5,4,5,1,2,3,1,3,5,3,4,3,2,2,3,5,1,2,2,2,4,2,3,4,4,1,5,2,5,1,2,4,4,4,2,4,3,5,5,1,1,5,1,4,1,1,4,1,4,5,3,3,4,4,1,3,5,1,2,2,5,3,4,2,1,3,5,3,1,4,5,5,4,3,1,5,2,2,4,4,5,3,5,1,2,5,2,1,5,5,3,2,4,4,5,5,3,2,4,4,2,4,1,2,2,5,5,4,4,2,2,4,4,3,5,1,1,5,4,2,4,4,3,5,2,5,3,3,1,3,1,5,5,2,4,4,5,5,5,5,2,1,3,5,5,4,3,1,2,2,3,2,5,1,2,1,4,5,4,5,5,3,1,3,2,2,4,1,1,2,3,2,2,1,2,5,4,1,2,2,2,1,3,5,1,1,4,5,1,2,2,1,1,4,4,4,1,4,4,5,2,2,2,5,4,3,4,1,3,3,4,2,2,4,2,5,1,1,5,5,4,1,5,3,1,3,4,2,3,3,3,3,5,3,2,5,3,2,3,5,4,1,5,1,3,2,3,4,1,2,1,2,2,5,1,2,3,5,1,3,1,1,4,3,3,2,3,3,1,3,2,1,1,1,3,2,4,5,4,2,3,4,2,3,5,2,2,5,2,5,5,3,2,5,5,3,5,1,4,4,2,2,4,1,4,4,3,5,3,3,5,3,1,2,4,4,5,4,3,3,1,3,5,5,5,4,1,4,1,2,5,4,1,1,5,4,2,2,4,1,1,3,3,4,5,1,1,1,5,2,4,3,5,1,5,5,2,3,5,5,2,4,5,1,2,1,3,1,3,5,1,5,1,4,1,2,5,2,4,5,4,3,4,1,5,1,3,4,2,5,1,1,4,3,4,3,5,4,5,2,3,3,5,5,2,2,5,5,5,2,4,5,2,1,1,1,3,2,4,5,1,2,5,4,3,3,4,1,3,2,4,4,2,3,4,5,2,2,3,5,4,3,5,1,2,5,2,2,5,2,2,4,1,3,3,5,3,3,1,4,5,4,4,1,5,3,1,2,2,5,5,4,2,5,2,3,2,2,4,1,2,5,2,1,2,3,2,1,3,3,3,2,3,1,1,5,3,2,2,1,4,1,3,2,5,1,4,4,3,2,3,5,3,5,5,4,3,5,2,5,4,1,5,3,2,4,2,3,2,3,4,4,2,2,1,3,2,3,1,5,2,5,1,4,2,3,4,5,2,4,1,3,5,1,1,5,4,2,2,3,5,2,5,3,2,5,4,4,3,3,5,3,4,2,3,2,2,4,4,3,3,3,5,5,1,4,1,3,5,1,1,2,1,1,1,5,3,5,4,4,3,1,1,5,1,5,2,1,2,4,1,2,1,4,2,1,3,3,3,2,4,4,1,5,4,1,2,5,4,4,1,4,3,5,4,2,1,5,2,3,3,4,2,2,3,2,4,2,5,5,4,3,1,3,3,1,5,3,4,1,4,2,4,3,4,2,1,3,3,4,4,3,3,4,5,3,4,2,1,1,5,4,2,5,3,2,5,3,1,5,4,3,4,4,5,5,5,2,4,3,3,3,2,3,4,2,1,1,2,3,5,4,3,3,1,3,1,1,2,1,4,3,1,3,5,2,4,2,1,4,4,4,1,1,3,4,5,1,1,4,1,3,4,5,2,3,2,3,5,5,4,3,4,2,4,5,3,4,4,5,1,4,3,2,2,4,4,4,3,5,2,3,3,4,3,3,4,2,2,2,1,1,5,3,2,4,4,5,1,3,4,4,4,1,4,3,1,4,3,1,1,5,1,2,2,1,3,5,5,2,1,1,4,5,2,3,4,2,5,4,5,3,1,5,4,2,3,2,1,4,2,3,2,3,1,2,5,4,5,4,3,5,3,3,1,5,5,4,1,5,3,1,5,3,4,3,1,4,2,2,2,2,1,5,2,1,3,1,5,5,4,1,3,4,3,2,3,1,4,5,4,4,5,1,2,3,1,4,5,1,1,4,5,1,1,1,4,2,3,5,5,2,4,4,5,5,2,4,5,1,3,5,2,2,2,3,5,5,5,5,4,1,1,1,1,2,5,1,3,5,4,2,1,4,3,2,1,2,5,2,3,1,3,3,1,3,2,3,5,4,5,3,1,2,3,5,1,1,1,4,5,4,4,5,5,4,4,1,3,5,3,2,2,1,2,5,2,3,3,1,4,5,3,4,4,5,4,3,1,3,3,3,1,1,1,2,1,3,2,2,1,3,4,5,2,5,3,4,1,1,5,4,5,5,1,4,4,2,4,5,3,2,5,3,3,1,2,2,1,3,2,1,3,3,2,1,2,3,5,3,3,1,2,5,4,2,1,3,4,4,2,5,4,2,5,1,3,2,4,3,2,5,5,5,3,1,1,4,2,5,5,3,5,4,5,3,5,5,1,3,5,5,4,2,1,5,1,5,4,5,1,1,5,2,2,2,1,1,1,1,1,5,2,2,3,3,1,3,3,4,1,3,4,1,3,1,2,2,2,3,3,2,4,2,4,3,4,4,1,5,4,5,2,1,4,2,1,5,1,5,4,2,3,4,4,1,2,4,1,2,5,5,1,1,3,3,4,2,5,2,3,1,5,2,3,3,3,5,2,4,2,5,1,2,4,5,5,2,3,3,1,2,1,1,3,2,3,5,2,2,4,2,3,2,1,1,4,4,2,2,5,5,4,1,5,3,2,3,1,4,2,2,5,5,3,3,2,2,3,3,1,5,5,3,4,3,4,3,3,1,1,4,4,2,3,2,5,3,3,4,3,2,5,3,4,3,4,5,1,2,2,5,4,3,5,2,1,2,2,5,3,3,4,4,3,4,4,1,3,4,3,4,2,3,3,1,5,4,2,5,4,1,5,2,5,2,1,5,1,3,5,2,2,2,3,3,2,4,4,4,1,4,4,5,3,4,2,1,5,1,1,2,4,4,4,1,4,5,3,5,4,1,5,4,1,4,2,5,1,2,1,4,2,5,2,4,3,2,3,3,5,4,2,5,1,4,2,5,3,4,1,3,5,3,2,1,4,5,1,4,3,2,3,5,1,5,4,2,4,1,3,4,2,4,2,5,3,3,4,5,4,2,1,2,4,2,5,2,2,2,2,5,3,1,2,1,1,2,3,3,1,5,3,3,1,5,3,4,4,1,2,1,5,4,2,3,4,2,1,2,2,5,2,1,2,2,2,1,3,2,1,3,1,4,2,1,1,1,1,1,2,2,3,5,4,4,5,4,4,3,4,1,3,3,4,4,2,3,2,2,2,4,1,1,1,4,4,3,3,3,1,2,2,5,1,2,4,5,5,5,1,3,4,3,5,5,3,2,2,4,3,1,5,3,2,2,3,5,3,3,2,4,2,2,5,5,1,5,3,3,3,2,1,2,2,2,2,5,5,5,5,5,3,2,4,2,2,1,1,1,1,3,4,4,3,1,1,4,4,1,5,3,5,2,1,2,1,1,2,5,5,4,1,5,1,3,2,4,4,4,1,4,2,1,3,1,3,1,3,4,5,3,5,3,2,3,4,3,1,3,5,1,5,1,4,4,2,4,1,2,3,1,5,2,4,3,3,3,1,2,3,2,2,2,3,3,4,3,5,4,3,3,5,3,1,4,5,5,4,1,1,1,5,2,3,1,5,2,5,2,4,1,5,1,5,2,2,5,4,1,2,5,2,3,5,2,1,3,4,3,3,2,4,3,5,1,2,3,4,5,1,2,2,2,2,5,4,3,5,3,2,1,2,3,3,4,4,2,1,3,2,5,2,3,4,5,1,5,4,1,4,5,4,2,1,4,1,5,2,3,1,5,4,4,2,2,3,4,3,1,1,1,4,1,1,1,2,2,1,5,5,4,3,3,1,4,2,2,2,4,2,4,1,1,4,3,4,1,1,4,2,4,4,4,2,4,1,1,5,5,4,3,3,2,3,5,4,3,5,3,2,3,2,5,4,3,2,5,5,3,4,5,2,4,4,1,4,3,5,1,5,2,1,1,2,3,5,3,2,1,2,3,2,2,5,3,4,1,2,4,2,3,2,5,5,5,5,2,4,2,4,1,1,3,2,2,5,5,2,4,3,2,5,3,2,5,1,5,1,4,1,2,3,3,5,2,4,5,3,2,3,2,1,3,4,2,2,2,4,3,1,1,3,4,2,2,4,4,1,4,3,2,1,2,2,4,5,3,3,3,2,4,4,2,1,3,5,2,2,5,5,5,4,3,2,4,1,2,1,2,1,4,2,3,5,2,4,2,5,4,4,1,5,1,3,2,3,4,1,2,5,4,1,2,4,5,2,1,5,1,2,4,5,4,3,4,4,4,5,2,5,1,2,2,2,5,3,3,1,3,5,2,5,4,5,3,4,4,2,2,4,3,2,1,2,4,4,3,4,3,3,3,4,2,4,4,3,5,3,3,3,3,3,5,5,4,3,4,3,4,4,5,5,5,2,1,5,1,2,1,3,5,3,4,3,1,1,2,1,4,3,5,4,2,2,1,1,1,3,2,1,4,3,4,4,2,1,5,1,2,1,3,1,5,2,1,3,1,2,3,4,2,2,5,3,2,5,3,5,4,1,4,4,5,3,1,2,2,5,2,2,2,4,4,1,1,2,2,2,5,4,4,2,1,3,5,1,3,2,1,2,1,3,4,2,1,3,2,4,3,4,3,5,2,4,3,4,1,4,4,4,3,2,1,1,2,1,1,2,4,5,1,3,3,3,5,2,2,5,4,1,2,5,1,3,4,1,5,4,2,4,5,5,4,4,2,5,3,2,3,1,1,2,4,3,1,5,4,1,2,1,1,3,2,5,1,2,4,1,3,3,1,2,4,1,1,4,1,1,1,5,3,3,1,1,5,2,5,1,4,1,5,5,1,2,1,1,5,5,5,1,3,1,1,2,4,3,3,5,4,1,1,4,2,3,4,3,4,1,5,5,3,3,5,2,4,4,2,4,1,2,5,1,4,5,4,1,1,5,1,3,3,5,5,5,3,4,4,2,3,1,2,5,5,2,3,4,4,2,5,5,2,2,4,5,4,1,4,4,5,1,1,1,2,5,1,5,1,4,3,1,4,4,3,5,3,1,3,2,5,5,2,2,2,5,2,2,4,2,3,3,2,3,2,5,1,1,3,4,3,1,3,4,5,1,5,1,2,1,5,2,4,5,3,5,4,1,1,5,5,4,1,3,3,2,3,4,5,3,5,5,5,3,5,4,2,3,4,1,3,1,4,1,4,4,3,1,3,1,3,5,5,3,4,5,3,4,4,3,3,4,2,1,4,4,1,1,1,4,3,2,3,5,3,1,1,3,1,2,4,1,4,4,1,4,1,3,4,3,5,3,5,4,1,1,3,1,1,4,3,3,5,1,1,4,5,1,3,4,2,4,4,4,5,3,3,3,1,4,2,5,4,1,1,5,1,3,3,5,3,3,5,3,5,3,5,1,2,2,1,1,4,4,3,3,4,3,4,4,1,1,4,3,4,2,2,4,3,5,5,2,5,4,1,5,3,1,2,1,3,1,2,1,3,3,1,3,1,2,2,3,2,5,2,4,1,1,2,4,4,5,1,5,4,1,4,2,4,2,2,4,1,4,5,5,1,5,3,4,3,5,4,3,5,1,2,4,3,2,3,1,5,5,3,3,5,4,3,5,2,5,1,2,5,2,1,5,3,2,1,1,4,2,1,1,3,2,2,5,3,2,1,4,5,3,2,2,1,1,4,2,4,1,1,3,3,1,3,2,4,3,1,4,5,4,2,3,2,5,2,2,3,2,2,4,5,4,1,4,4,4,1,3,2,1,5,2,3,1,5,2,2,4,1,5,3,2,3,5,4,1,1,5,2,3,5,4,3,4,2,5,1,2,2,1,3,3,5,4,5,4,4,2,5,5,2,5,3,2,5,3,3,3,2,1,3,1,1,2,3,4,3,5,1,4,5,2,1,4,3,5,4,4,4,5,1,1,1,3,2,5,3,4,4,2,5,1,1,3,2,3,1,3,3,5,3,1,2,1,4,2,2,3,2,5,2,5,5,1,2,2,5,2,4,1,1,1,4,3,5,1,4,4,3,5,3,2,1,3,5,3,1,5,4,2,2,1,5,5,4,1,3,1,3,2,1,2,5,5,3,3,4,2,5,1,5,2,5,4,4,3,1,1,5,2,5,1,5,3,3,3,2,5,1,4,3,4,5,1,2,1,3,4,4,1,1,3,5,1,4,2,4,1,1,1,4,1,3,4,2,1,3,3,3,4,4,4,2,4,3,5,5,5,2,5,3,5,5,4,2,2,2,3,5,4,4,1,3,2,4,2,1,1,1,5,4,5,2,4,5,5,2,5,5,4,3,4,1,5,3,1,2,4,5,2,2,1,1,2,1,1,4,2,1,3,1,4,2,3,5,3,4,3,5,2,1,3,3,5,1,1,1,2,4,1,4,5,5,3,3,1,5,1,2,3,3,5,1,1,4,5,2,5,3,2,1,5,4,5,3,5,3,3,4,3,1,3,1,4,2,4,4,4,2,1,2,2,1,2,2,2,5,1,2,4,2,2,1,2,5,4,1,1,2,4,2,3,1,3,5,3,3,5,4,5,5,1,4,1,1,2,1,1,3,5,4,5,3,5,5,1,2,2,1,5,2,3,5,1,5,1,3,3,2,1,2,2,3,4,2,4,2,2,3,5,2,3,5,4,4,4,5,3,5,5,3,2,2,3,2,5,3,2,1,2,4,4,3,5,5,2,4,1,4,1,3,1,1,4,3,1,5,1,4,2,4,3,2,1,2,1,2,1,3,3,4,4,5,4,5,5,3,4,5,4,1,4,2,2,3,1,2,3,1,2,1,5,4,4,1,4,3,2,3,5,2,1,5,2,5,1,1,4,2,5,5,2,5,5,3,1,3,3,2,4,5,2,1,1,3,3,4,3,4,3,3,5,3,1,1,3,2,1,4,5,1,3,2,5,5,5,1,5,4,5,4,5,3,1,2,1,4,2,4,4,5,1,2,2,4,5,5,5,4,2,2,4,1,4,2,4,3,3,4,1,1,4,5,1,5,5,2,4,3,2,2,2,3,3,2,4,1,1,1,2,3,5,5,2,4,4,3,3,1,3,3,5,5,5,5,1,3,5,3,2,5,2,4,3,4,5,1,2,2,4,1,1,2,5,4,3,3,2,1,5,5,3,1,4,2,4,5,3,2,4,3,2,1,4,1,4,4,3,1,4,4,5,4,1,1,1,3,4,5,5,1,2,3,3,4,2,1,3,2,5,1,2,5,1,5,4,4,5,3,2,1,4,1,4,1,2,1,1,3,1,4,4,1,2,2,1,5,3,3,5,2,5,4,1,2,1,2,5,3,5,5,4,3,3,2,4,3,4,2,3,3,5,4,1,4,4,4,1,4,1,3,1,5,2,2,5,1,2,1,1,2,2,2,5,3,2,5,1,1,1,3,4,5,5,4,5,3,5,3,2,5,5,1,4,1,2,5,3,4,5,3,4,1,3,5,3,4,5,4,4,2,3,5,1,5,4,1,1,5,4,4,1,1,1,3,1,4,2,2,1,3,5,3,3,5,1,2,1,5,5,5,4,4,3,2,2,3,5,1,5,1,4,4,1,1,2,3,5,5,4,5,2,3,5,1,5,3,1,5,1,2,2,3,5,4,5,5,4,4,5,5,4,5,2,5,2,5,1,5,1,1,3,3,4,1,3,5,4,3,5,1,5,3,4,2,1,1,5,5,1,5,1,2,2,1,4,1,4,4,4,1,2,1,5,3,5,1,1,3,1,3,5,3,5,3,5,3,4,2,2,4,3,5,2,4,1,5,3,4,3,1,5,3,3,3,1,1,1,3,2,2,2,5,5,1,4,4,5,3,3,5,1,1,5,3,4,2,4,4,5,1,3,1,4,1,3,3,2,4,5,4,3,3,3,4,5,2,1,3,2,4,4,4,4,3,5,4,5,2,2,1,2,5,1,5,4,3,3,3,4,5,2,3,4,2,3,4,2,5,5,1,5,5,2,4,4,5,1,1,3,4,1,4,4,3,5,3,2,1,2,1,5,1,5,5,1,3,4,3,1,5,1,2,3,2,5,1,2,2,3,5,2,4,3,2,1,5,5,5,4,4,2,3,1,1,5,2,4,3,2,5,1,4,4,4,5,1,3,3,2,3,4,1,2,3,2,3,4,2,2,2,4,4,4,5,4,5,3,4,1,1,5,5,5,3,1,3,3,3,1,1,3,1,3,5,4,1,3,3,1,2,4,4,3,4,5,1,3,4,3,2,5,2,5,5,5,3,5,1,3,1,2,2,5,2,5,3,5,1,1,5,2,3,4,3,4,5,4,1,1,4,2,5,1,1,5,3,4,1,4,1,1,2,4,2,4,1,3,1,2,2,4,3,3,3,3,1,3,4,4,3,3,5,1,2,1,2,4,5,1,2,2,2,3,2,3,4,1,3,1,4,3,3,2,2,3,1,2,5,5,1,4,5,3,4,3,1,4,5,2,2,4,1,4,2,2,4,3,3,4,5,5,2,4,4,3,2,1,1,2,3,4,5,4,3,3,2,3,4,5,5,2,5,3,4,3,2,4,5,2,2,2,5,1,3,3,3,1,2,1,1,1,1,3,5,4,2,1,5,3,1,4,5,5,5,2,1,2,2,5,4,5,1,1,4,4,5,4,2,1,4,3,4,2,2,3,3,2,5,3,5,4,4,4,3,3,2,4,3,5,5,2,3,1,5,3,4,5,4,1,3,5,2,4,1,5,5,3,5,2,1,5,2,3,4,3,2,1,3,5,1,2,1,5,2,4,5,4,1,5,3,2,2,5,2,2,4,5,5,1,5,2,1,3,2,1,2,2,2,3,2,3,2,2,4,2,4,2,3,3,5,5,4,4,1,4,1,1,5,1,1,4,2,2,4,3,5,3,2,5,2,3,4,5,5,2,4,2,2,5,4,1,1,4,1,1,3,1,4,3,5,2,1,1,5,2,1,3,5,4,3,3,3,5,1,3,4,1,2,4,2,1,3,2,4,2,5,3,2,2,1,3,1,2,4,3,2,5,5,1,2,2,5,4,5,4,3,2,4,5,2,1,2,3,1,1,2,3,4,5,4,4,3,4,4,2,4,1,4,2,3,1,3,5,1,4,5,2,2,4,5,4,1,1,5,2,4,2,5,2,2,5,2,1,2,1,1,3,3,4,5,3,1,2,4,5,2,2,5,4,4,1,4,1,1,3,2,5,3,1,5,1,2,1,5,1,3,4,4,2,1,5,4,2,2,2,3,2,2,5,3,5,2,2,1,3,3,1,3,5,3,4,5,1,2,4,4,3,2,5,2,4,4,2,4,1,5,5,5,1,3,3,1,3,2,2,3,1,3,1,1,5,4,4,2,2,5,1,1,1,2,5,1,2,5,5,2,3,5,1,4,5,5,2,2,5,5,1,4,5,5,1,3,2,3,5,3,1,4,5,4,5,2,3,3,4,5,4,1,3,1,1,2,4,2,4,5,5,5,1,5,4,3,1,5,1,1,2,5,2,3,3,1,1,3,4,3,1,1,2,1,1,4,4,3,2,2,2,4,1,1,3,1,3,3,3,2,3,2,4,4,4,2,4,2,2,5,3,2,3,5,1,3,3,2,2,1,5,2,4,2,1,3,4,1,2,3,3,3,3,1,3,4,3,5,4,4,4,2,2,3,1,4,2,5,1,2,5,2,1,3,4,5,2,4,5,3,5,1,3,5,4,3,2,5,5,2,4,2,1,4,5,1,4,5,3,3,1,3,2,4,5,2,3,4,5,4,5,5,5,1,1,5,4,1,3,4,4,5,4,1,5,5,2,3,5,5,1,4,4,5,3,1,4,5,4,5,5,2,1,5,2,2,4,4,5,1,5,5,4,3,1,2,3,2,4,5,2,4,3,5,3,2,1,3,5,3,5,4,1,1,5,1,4,4,1,3,3,4,2,1,2,3,4,5,3,3,1,2,1,4,4,1,4,5,3,5,3,3,3,5,5,4,2,3,4,3,4,4,3,2,4,5,1,1,1,4,2,5,5,1,2,3,3,1,3,3,4,2,1,5,2,2,3,4,5,5,5,4,1,2,2,3,5,1,1,4,4,4,2,2,3,2,1,4,1,1,1,5,2,3,5,3,2,1,3,3,5,3,5,3,4,4,2,4,3,5,1,4,4,1,1,2,5,5,1,2,5,2,2,1,5,2,1,1,5,4,3,2,1,4,2,5,4,3,3,2,1,3,5,2,1,2,1,4,2,4,3,4,2,2,4,1,5,3,4,4,1,1,2,1,1,2,2,1,1,4,2,2,1,1,3,1,2,4,5,2,3,5,5,2,3,4,1,1,3,2,1,5,2,1,3,5,2,5,2,3,5,4,2,5,4,3,2,3,4,1,4,5,3,4,5,1,4,3,4,5,4,1,2,5,2,2,1,1,2,4,4,1,4,4,4,2,3,1,1,2,1,3,2,5,3,1,1,2,3,4,3,1,4,1,2,1,2,2,3,4,2,4,5,3,3,1,2,5,3,2,1,5,3,1,5,4,3,4,2,1,5,1,5,5,4,5,3,3,3,1,5,2,4,2,5,2,1,4,3,3,5,1,5,2,1,5,2,4,5,2,2,5,2,3,4,4,4,1,1,2,1,3,4,4,5,1,4,4,1,1,3,2,2,1,5,5,4,4,3,5,3,3,1,5,3,4,3,3,3,3,2,3,3,4,3,4,1,4,4,1,2,2,2,3,3,5,1,4,4,2,3,5,3,5,1,1,5,1,2,4,2,1,5,4,2,2,1,3,4,5,5,4,3,5,4,1,3,1,5,3,3,4,5,3,1,1,4,3,1,3,5,3,4,3,2,5,5,3,4,1,4,2,1,5,5,1,4,4,1,2,1,1,1,5,3,1,4,1,1,5,1,3,3,3,2,2,4,4,2,1,2,5,5,3,5,1,2,1,1,5,4,5,5,4,2,3,1,4,3,4,4,2,3,1,2,4,3,3,1,2,2,4,3,3,3,5,2,5,2,3,1,4,5,5,3,3,2,1,3,3,4,3,5,3,2,5,1,4,4,4,3,1,1,1,1,1,3,2,3,1,5,1,4,3,3,5,1,2,2,3,5,4,4,1,1,4,2,4,3,2,5,2,4,2,5,5,4,4,1,5,2,2,3,5,2,2,1,2,5,5,5,1,2,5,5,1,4,1,4,2,2,3,1,3,4,4,5,3,4,5,3,1,5,2,4,4,1,3,5,3,5,4,5,5,2,4,2,4,3,2,3,2,5,4,1,4,5,4,2,1,5,4,1,5,5,5,4,1,5,4,2,5,4,4,3,1,4,3,2,5,4,1,5,1,4,2,4,4,2,2,3,3,5,5,2,3,4,2,4,4,1,1,4,1,4,4,1,5,4,3,2,2,1,3,2,4,3,3,4,2,4,5,2,1,1,2,2,1,4,2,2,5,4,3,4,4,1,2,3,4,5,1,5,4,4,1,1,2,3,3,3,2,2,2,3,4,1,3,4,3,2,4,1,2,4,4,5,4,4,3,5,1,5,5,5,3,1,3,5,4,2,5,2,1,4,4,3,2,1,4,3,3,1,2,5,2,5,3,4,3,5,5,4,4,5,1,2,4,4,5,3,3,2,2,1,2,5,4,4,4,3,3,5,4,1,2,2,1,1,5,3,2,2,2,3,4,5,1,3,1,4,2,1,3,5,2,5,5,5,2,2,5,5,3,4,4,3,4,3,2,2,5,5,2,3,1,2,4,3,4,5,5,4,2,4,1,2,3,1,5,4,2,2,1,3,4,2,4,1,1,4,2,1,2,4,2,3,3,3,3,1,4,1,3,3,3,1,1,5,2,2,2,2,1,1,4,4,1,1,3,3,2,1,1,5,1,4,2,4,2,2,4,1,2,3,5,2,2,5,3,2,5,2,2,2,2,3,2,2,4,1,2,5,5,3,1,1,3,3,5,2,1,1,2,5,3,2,3,3,4,1,5,4,4,4,3,1,4,2,2,3,2,4,5,3,5,4,3,5,2,4,4,3,3,4,5,5,4,2,2,3,5,3,1,5,3,5,2,2,3,1,5,1,1,4,1,1,2,2,4,2,3,4,5,2,3,5,2,4,5,4,5,4,1,2,2,4,3,4,2,5,5,2,3,4,2,1,5,5,4,2,4,3,4,3,5,5,3,4,2,2,1,1,5,4,3,1,4,5,3,4,3,3,3,4,1,1,5,2,5,2,5,5,5,3,2,4,4,4,4,2,1,5,2,1,4,1,1,1,4,5,3,3,2,5,3,1,4,2,3,4,3,2,4,2,4,4,5,3,1,5,4,3,3,4,4,2,3,3,1,1,1,1,3,3,4,3,1,3,3,4,4,1,5,1,1,4,1,5,3,5,1,5,3,5,2,1,4,2,3,5,1,4,2,4,1,4,4,3,1,2,5,4,3,4,5,5,3,4,1,5,5,2,5,2,3,5,3,4,4,5,4,5,4,1,5,2,3,5,3,2,2,3,3,2,5,3,1,3,1,4,4,2,5,5,1,3,2,2,1,5,3,5,5,2,3,3,4,4,3,1,3,2,3,1,3,3,1,4,4,5,2,4,3,2,2,4,1,2,1,2,4,4,2,1,4,3,3,4,2,2,2,1,2,1,3,2,3,4,5,4,1,1,2,1,3,3,1,4,5,4,5,4,1,1,1,5,3,3,2,3,3,4,5,3,1,3,1,1,5,1,1,4,4,4,4,4,4,5,4,4,3,4,4,4,1,4,4,2,4,1,1,1,4,3,5,1,2,1,1,4,1,2,1,1,1,2,3,5,1,1,2,1,3,1,2,4,4,3,1,5,1,1,5,4,5,5,3,4,5,1,2,2,1,4,5,1,1,1,4,3,1,4,5,2,4,5,3,1,3,2,1,4,5,2,5,2,5,5,4,3,3,3,4,5,4,5,2,3,2,5,5,5,4,3,3,4,3,3,5,5,2,2,3,5,4,2,2,5,5,3,3,4,1,2,1,1,2,2,4,1,5,2,3,4,5,5,2,1,1,1,2,3,5,3,1,4,1,3,3,1,5,3,3,5,4,1,4,5,3,1,1,1,4,1,5,1,3,3,1,2,3,3,4,1,3,4,2,1,1,3,4,3,1,3,5,5,3,4,2,3,2,3,3,4,2,3,5,2,1,4,5,3,1,2,3,2,5,2,1,4,5,5,2,4,3,2,3,1,5,2,2,2,2,5,1,2,1,5,2,3,5,5,4,1,3,5,5,1,4,3,1,1,1,1,3,4,1,4,2,5,2,1,3,1,3,4,4,4,1,3,5,4,4,5,2,5,3,1,1,1,4,3,4,2,2,3,2,3,5,1,1,5,1,2,4,1,1,2,1,1,3,5,1,5,2,3,1,3,4,1,1,2,5,3,1,5,3,3,4,4,1,5,2,5,2,1,5,2,4,3,4,2,4,4,5,1,2,2,4,1,4,4,4,3,5,4,2,2,2,3,3,4,4,5,5,4,2,4,5,2,2,2,4,2,3,3,1,1,1,2,3,2,4,2,5,4,2,4,4,2,4,1,4,5,5,5,3,2,2,2,3,2,2,4,3,1,2,3,1,1,3,2,1,3,3,4,3,5,1,3,4,5,4,4,1,1,1,5,2,3,5,2,4,1,3,4,2,1,3,1,4,3,3,3,5,1,3,1,4,1,4,2,4,3,1,3,4,3,3,3,3,3,3,4,1,4,1,2,4,1,2,2,5,5,4,2,3,1,2,2,5,3,2,2,2,1,3,3,3,3,5,1,4,2,2,2,2,4,1,4,3,2,2,3,1,2,4,5,5,4,4,5,3,1,1,3,3,1,2,3,2,2,4,2,1,2,5,4,3,3,2,3,5,2,1,3,1,2,4,1,5,2,2,3,3,1,4,3,3,2,3,3,5,2,2,1,4,5,2,2,4,1,2,4,2,5,1,3,3,1,2,4,1,1,1,5,1,4,5,1,1,1,5,2,5,3,2,4,2,4,4,3,3,1,5,3,2,4,1,1,1,4,5,4,2,3,1,4,4,1,5,3,2,4,5,3,2,1,2,3,1,4,5,5,4,2,3,2,3,5,5,2,5,1,5,5,2,1,5,2,2,2,3,3,1,2,3,3,5,5,4,3,5,5,5,3,1,3,2,4,5,1,5,3,5,5,3,5,2,4,2,5,3,5,2,2,1,2,4,5,1,5,5,5,4,3,2,4,4,3,4,5,4,4,5,3,3,1,1,1,3,3,4,4,4,2,1,3,5,3,3,4,1,1,1,5,3,5,3,2,1,3,2,2,5,3,3,5,1,1,3,2,4,1,4,2,1,1,2,4,5,5,3,3,4,2,5,4,5,2,3,3,3,5,5,2,3,4,5,4,3,2,4,2,1,4,3,1,3,5,4,4,2,5,5,2,3,1,5,4,2,3,5,2,4,4,2,1,3,5,4,3,3,4,5,3,3,1,5,1,4,4,1,1,5,4,1,4,3,1,1,1,1,3,5,1,5,5,2,1,2,2,3,4,1,5,1,4,5,2,2,4,5,2,2,2,1,5,3,2,2,3,3,5,4,5,3,5,5,2,2,2,2,2,5,5,5,3,1,5,5,1,2,5,2,4,3,1,2,4,5,5,4,1,4,5,3,1,5,3,2,1,2,2,3,5,2,4,2,2,2,5,1,5,5,1,5,4,5,3,5,3,5,2,4,5,4,3,1,4,2,1,4,4,4,4,2,4,2,3,4,1,3,2,4,2,1,2,1,1,1,1,3,3,1,5,1,2,3,5,4,4,3,3,5,4,2,3,1,1,2,2,1,5,5,3,1,2,5,3,1,4,4,1,2,1,3,3,5,3,2,1,1,5,5,3,4,3,2,3,2,1,4,5,5,1,1,4,3,4,5,2,1,3,5,1,2,1,4,1,3,4,3,4,3,3,4,2,5,4,3,5,2,2,5,1,1,3,5,4,3,3,3,5,5,5,3,4,2,4,2,3,5,2,3,2,1,5,5,3,3,3,1,1,5,2,4,4,5,5,3,5,2,3,1,2,1,2,4,4,5,5,3,2,5,5,4,3,3,5,4,5,4,5,2,3,1,4,4,1,1,4,5,3,5,2,3,1,2,4,3,2,5,2,4,5,5,1,4,5,3,4,1,5,3,5,5,5,5,3,3,5,3,3,2,1,5,2,3,1,4,5,1,2,3,4,3,5,3,1,3,1,2,1,1,5,4,3,4,3,3,3,1,4,3,2,4,3,4,5,3,3,5,2,2,1,2,2,2,1,5,1,2,2,1,2,5,4,5,4,2,4,4,1,2,5,1,5,5,5,1,5,1,2,2,2,2,3,4,5,1,2,5,3,1,3,3,3,2,2,5,5,4,4,5,5,4,2,2,1,2,5,5,5,4,5,5,1,2,2,5,1,4,2,5,4,2,3,3,3,3,3,5,3,3,1,5,5,1,5,3,1,2,2,1,2,3,4,3,5,2,2,2,2,4,5,3,1,4,5,4,1,2,3,1,2,4,5,5,1,1,5,3,3,3,3,2,4,5,1,2,2,5,4,3,4,5,3,1,5,3,2,5,2,4,2,3,3,4,3,5,4,1,1,4,1,1,3,4,5,1,1,1,3,2,4,2,1,5,3,2,5,2,5,4,5,2,4,1,5,3,4,2,4,3,5,4,3,1,2,3,4,4,1,2,3,2,4,5,1,3,3,3,1,5,4,1,4,4,4,3,1,4,4,5,2,5,1,3,4,2,3,1,3,5,4,5,2,2,5,2,3,3,2,3,5,4,2,5,5,5,4,5,5,3,1,4,1,5,2,3,5,4,4,5,1,5,2,4,3,1,3,2,2,3,4,5,5,3,3,2,3,4,1,2,4,5,3,3,1,2,2,1,4,4,5,3,2,4,3,1,5,2,1,5,3,4,4,2,2,5,4,1,4,4,2,1,5,1,5,4,4,4,5,2,2,2,3,4,1,2,1,5,4,3,3,4,2,4,2,1,3,2,4,1,4,1,4,4,4,5,2,2,2,4,1,2,1,1,3,3,5,2,5,4,4,2,1,4,1,4,5,2,4,4,2,3,5,2,2,5,5,1,5,4,1,1,3,5,5,5,4,1,2,4,3,3,4,2,2,5,5,5,3,2,1,2,2,4,2,5,3,3,3,4,2,3,2,2,5,3,5,2,1,5,2,4,4,1,5,2,5,1,1,5,2,4,1,4,2,2,1,4,5,4,4,3,4,2,3,3,4,2,2,3,5,1,2,1,1,5,4,1,3,3,5,3,2,5,5,3,3,2,2,1,2,2,5,5,3,4,2,2,2,4,2,4,2,1,4,1,2,5,2,1,4,2,2,5,1,3,3,2,4,4,4,4,5,2,1,3,3,5,2,3,3,3,2,5,2,5,1,1,3,3,2,3,4,5,2,2,3,1,3,3,3,2,1,3,1,4,1,1,4,2,3,4,5,1,2,4,3,2,3,5,3,5,4,4,5,3,4,1,3,3,4,4,5,4,1,3,2,3,2,3,2,1,4,2,2,3,5,3,1,4,1,1,2,3,5,5,5,1,1,3,4,3,5,4,2,2,1,5,5,3,2,3,4,5,3,1,2,5,3,5,4,1,4,3,1,4,2,5,3,2,3,2,3,1,5,1,4,3,1,1,2,5,4,5,1,5,1,5,4,5,4,5,3,4,3,2,5,5,3,4,2,1,4,2,5,2,1,2,3,5,2,2,4,3,2,5,1,3,4,2,1,1,3,3,1,2,2,3,4,4,2,1,4,3,3,4,1,2,5,2,1,5,2,4,4,3,4,5,3,5,1,1,5,1,1,4,5,4,2,5,3,4,5,1,4,5,2,3,5,2,4,5,2,4,4,4,3,2,2,3,4,1,1,4,2,2,5,1,2,5,4,2,1,4,3,1,3,4,2,3,1,2,4,4,3,4,1,3,2,2,1,1,3,3,4,5,5,3,5,4,4,2,3,5,3,5,1,3,3,1,3,3,5,2,2,1,5,3,5,4,5,3,1,5,2,1,3,2,5,1,5,3,3,5,5,3,3,1,2,5,5,5,2,1,5,4,2,5,1,1,2,2,1,1,3,3,5,5,2,4,4,4,5,4,3,1,5,3,2,1,2,2,4,1,1,5,2,2,5,3,3,5,3,5,2,2,4,1,1,4,4,5,4,3,2,1,3,1,5,4,1,5,2,5,1,4,2,5,1,1,4,1,5,5,4,5,5,2,5,3,2,4,3,4,3,4,4,2,3,3,4,1,4,4,5,3,1,3,5,3,5,5,3,2,4,1,5,3,5,1,2,4,5,3,1,2,2,5,3,3,3,5,5,2,2,2,2,5,1,2,2,3,2,1,1,4,3,4,2,4,5,4,2,4,1,5,4,4,3,3,3,2,2,3,4,3,3,5,2,1,1,3,3,2,2,2,5,1,4,1,3,4,5,2,4,5,2,3,2,2,3,1,2,3,5,2,5,5,1,2,2,4,2,5,2,2,2,1,2,5,2,3,2,3,2,3,5,3,3,4,4,5,4,2,2,3,2,1,2,3,5,4,1,1,5,5,3,3,3,4,4,5,5,5,5,4,2,4,2,2,1,1,4,2,3,5,2,3,3,1,5,4,5,2,1,5,5,3,2,1,2,2,2,2,5,4,3,3,5,1,4,5,4,2,5,5,4,2,4,3,3,5,1,4,2,2,3,3,4,3,3,2,3,1,3,4,4,1,5,5,1,3,5,4,5,4,3,2,4,4,4,1,1,4,5,4,3,4,1,2,4,2,5,4,1,5,5,1,3,1,3,1,3,5,3,3,3,2,1,1,5,1,4,1,2,3,4,5,4,3,5,5,5,4,4,1,3,5,4,3,5,5,3,5,3,2,1,3,4,2,1,2,4,5,2,5,1,2,1,2,2,3,2,4,3,1,5,2,1,4,4,3,2,4,2,2,4,5,4,2,2,1,2,4,3,5,1,4,4,1,4,1,4,2,2,4,2,3,3,2,1,2,2,3,2,4,2,1,1,4,5,3,2,2,1,4,5,4,1,4,3,2,4,1,1,2,3,2,5,2,5,1,5,4,4,3,4,1,1,4,2,2,3,1,3,5,4,1,4,5,1,5,1,1,4,3,5,4,3,1,5,3,2,2,3,4,5,5,2,2,3,3,1,4,1,4,3,3,4,2,1,3,2,3,3,1,2,4,3,2,3,3,1,3,5,3,3,3,1,2,4,1,3,2,5,2,3,1,4,3,1,4,2,2,5,2,2,2,5,1,1,2,3,2,3,5,5,5,5,2,4,2,3,3,5,2,4,2,1,5,1,3,3,4,2,5,2,4,3,5,5,1,4,5,1,4,1,5,3,4,5,1,2,4,4,4,1,2,2,5,4,2,5,4,4,2,4,2,5,4,2,4,2,2,1,2,1,4,2,4,1,2,4,1,1,4,3,1,1,5,1,3,3,1,2,5,4,1,3,1,3,3,5,1,2,1,2,2,3,5,5,5,1,1,4,2,1,2,2,1,4,3,2,1,3,4,5,2,3,3,3,2,2,5,4,3,5,5,5,1,4,4,4,5,4,3,4,5,2,2,2,3,4,4,2,1,1,5,1,5,1,4,4,2,5,3,2,3,3,5,2,3,3,4,4,5,3,1,5,1,2,2,5,1,5,2,2,2,2,2,1,2,1,1,5,1,2,5,2,3,4,3,2,4,5,3,1,5,2,5,4,2,2,1,3,2,2,3,3,5,5,5,2,5,4,3,2,5,4,3,1,2,3,2,4,1,1,4,3,2,2,2,3,2,4,3,2,5,2,5,3,2,3,1,4,4,2,4,2,1,3,1,1,2,4,4,5,1,2,2,3,3,1,4,2,1,3,2,2,2,4,5,2,1,2,1,1,5,5,4,4,4,1,3,3,4,3,1,1,1,4,4,2,2,4,1,4,3,4,1,1,5,4,5,3,4,3,1,2,2,2,2,2,4,4,1,3,5,1,3,4,4,5,4,2,4,1,5,2,3,5,1,5,2,2,5,5,5,1,4,1,1,4,3,5,3,2,4,3,3,5,4,5,2,5,4,4,4,5,3,5,4,1,2,2,2,3,4,4,3,4,1,3,3,2,4,5,5,1,2,5,2,2,5,2,5,5,4,4,4,1,1,4,5,4,5,2,3,1,3,3,4,5,1,3,5,1,3,1,4,5,3,1,2,4,2,2,5,2,4,2,4,1,4,2,4,4,3,4,2,2,4,3,2,2,4,3,3,4,3,5,2,5,3,3,5,4,2,5,2,5,4,3,4,2,1,2,3,4,4,3,4,3,3,2,4,2,5,5,4,2,4,5,1,1,2,4,4,3,1,1,3,1,2,2,2,5,2,3,2,5,3,2,1,3,4,1,3,2,1,5,4,3,4,4,1,5,5,5,3,2,3,1,4,5,3,1,2,1,3,3,2,1,1,3,3,2,5,5,1,1,2,1,5,4,5,5,5,4,3,5,4,1,5,4,2,3,4,2,3,2,5,1,5,4,3,3,3,4,5,4,3,5,3,2,3,3,2,3,3,2,1,5,2,1,2,4,2,3,3,4,5,5,2,2,1,5,3,3,5,2,1,1,2,2,2,5,5,5,4,4,4,2,3,3,4,1,4,1,2,3,3,3,4,4,1,4,3,3,1,5,4,3,5,4,4,1,4,5,5,4,5,4,4,5,3,2,3,3,1,5,1,3,5,1,5,1,4,3,2,1,3,4,1,5,5,5,5,4,1,5,3,3,4,1,3,4,5,2,2,2,3,3,5,5,3,4,3,4,1,2,5,4,2,2,1,3,5,1,3,1,3,5,4,2,3,2,2,3,3,2,4,3,1,3,2,5,3,4,5,5,2,1,2,5,5,4,1,5,3,5,1,2,5,5,3,1,5,4,1,2,3,2,3,3,1,5,2,4,4,4,5,2,2,2,2,4,2,4,5,1,4,1,2,2,1,5,4,1,3,3,5,4,5,5,4,3,3,5,3,2,3,2,5,5,1,1,1,2,2,1,4,3,1,2,4,3,2,4,5,3,1,3,3,4,4,5,3,5,2,4,4,4,3,2,3,1,2,1,4,4,2,1,1,1,5,4,5,4,2,2,2,4,2,1,5,4,3,3,1,5,1,3,2,2,2,2,5,5,2,4,5,2,5,5,3,5,3,2,1,1,2,4,4,2,1,2,2,4,1,2,5,4,3,3,4,1,3,5,5,1,2,3,2,5,2,3,3,4,1,3,3,5,5,5,2,1,4,2,1,5,5,5,3,5,4,1,2,5,1,2,2,4,4,5,3,5,2,3,4,1,4,1,4,2,1,2,4,5,2,3,1,1,5,3,5,5,2,4,3,1,4,3,2,4,2,4,2,4,5,2,2,2,1,1,4,2,4,5,4,4,4,1,2,5,2,4,3,3,3,5,1,2,3,5,2,5,2,1,4,4,1,5,5,5,3,3,5,3,1,4,5,3,2,2,4,1,5,3,4,2,4,5,4,2,2,3,4,2,5,2,2,1,3,3,2,4,2,2,3,2,2,5,3,5,2,5,5,4,4,5,3,3,4,1,3,1,4,4,4,1,5,2,2,3,3,2,1,4,4,1,2,4,2,4,1,1,5,5,4,1,4,4,3,1,4,2,4,5,5,1,1,2,4,2,4,1,2,1,1,2,1,5,5,2,1,1,1,4,5,3,5,5,5,2,3,4,4,5,1,2,3,4,5,1,1,2,3,3,3,5,4,2,3,2,3,2,3,1,5,4,5,4,2,1,5,3,4,1,2,3,2,1,2,4,1,1,3,5,1,1,4,2,4,3,1,1,5,3,1,3,4,5,5,5,1,1,3,2,4,5,2,3,5,4,4,2,1,1,2,1,3,4,1,4,4,1,3,1,3,3,4,3,2,1,2,3,3,1,1,4,2,4,1,1,3,4,5,3,5,2,1,1,2,5,4,3,3,4,1,4,5,2,3,5,2,4,2,3,2,5,3,3,1,2,4,3,5,1,2,5,1,5,1,2,2,5,4,4,4,2,5,5,1,3,5,3,5,2,2,2,4,4,2,2,4,5,3,4,2,5,3,5,1,1,1,5,3,1,1,3,3,1,1,1,1,1,2,5,1,2,3,3,4,3,3,4,1,1,4,1,3,1,5,5,5,5,1,1,3,2,1,2,4,3,4,4,1,4,4,4,1,2,1,4,5,5,3,4,5,4,3,2,1,2,5,2,1,4,1,1,5,2,4,5,3,4,4,4,4,4,5,2,3,5,1,4,3,5,2,2,3,3,3,5,2,4,2,5,3,4,4,3,2,3,4,4,5,5,2,5,3,1,1,5,3,5,5,4,1,2,5,3,4,2,5,2,2,5,4,1,4,1,4,2,4,4,2,2,1,2,4,4,2,1,3,5,1,4,3,1,5,5,4,2,3,1,4,5,4,1,4,2,1,1,2,2,5,4,2,2,2,2,3,5,1,3,4,2,5,5,4,4,4,4,4,4,5,5,1,5,5,5,5,5,5,4,1,4,2,1,3,3,3,3,3,3,5,2,3,1,5,3,5,1,2,2,1,5,5,3,1,5,1,1,4,1,1,3,3,2,1,5,5,2,5,1,4,2,1,1,1,3,4,5,3,5,5,3,3,1,2,5,4,4,3,4,3,4,3,4,5,1,2,1,5,4,5,1,1,1,5,4,3,4,4,3,1,2,4,1,1,4,5,2,5,3,2,3,1,4,3,1,1,1,4,2,2,4,4,2,2,1,1,2,2,5,1,4,1,5,1,3,1,3,2,3,4,3,4,4,1,2,4,2,1,5,5,4,4,1,3,3,3,4,1,3,2,3,3,4,5,2,2,5,4,5,1,2,1,2,4,4,1,5,4,1,5,4,3,5,2,3,2,1,3,5,4,1,4,5,5,3,3,5,1,2,4,2,4,4,5,3,2,5,2,2,4,5,1,4,1,3,4,4,2,4,2,1,5,4,4,4,1,5,2,2,3,4,1,5,2,5,5,1,2,2,5,2,1,2,5,5,4,5,4,3,3,5,4,5,4,1,2,2,3,1,2,3,4,5,2,5,1,3,3,5,1,5,2,5,5,1,1,2,5,3,2,4,5,4,5,2,2,2,4,3,5,3,1,5,2,2,2,2,2,1,2,3,1,1,2,5,2,5,1,2,2,3,2,4,1,2,3,1,1,4,2,2,3,2,5,1,4,5,4,3,4,4,3,1,1,4,5,1,5,4,1,5,3,1,3,2,4,3,5,1,5,3,5,4,2,3,3,1,2,3,4,5,4,1,4,5,3,5,2,3,5,5,3,2,3,5,4,1,1,5,4,2,3,4,3,5,3,1,4,2,2,3,1,4,4,4,4,4,3,3,3,1,4,5,5,2,1,5,2,2,2,4,1,5,4,2,1,4,4,1,4,2,2,1,3,4,5,3,3,1,4,2,1,2,5,4,2,2,1,2,1,1,4,2,5,1,5,1,1,1,3,2,5,4,1,2,1,4,5,4,2,4,1,3,1,3,5,1,1,5,5,4,4,2,5,4,2,1,3,4,3,2,2,2,3,3,4,3,4,4,1,3,1,4,1,1,5,1,5,5,1,3,4,5,3,3,2,3,1,3,2,1,1,2,3,1,4,4,1,3,3,3,2,4,3,5,1,5,4,5,3,4,2,5,3,2,4,1,5,5,4,5,4,2,3,4,2,5,1,5,2,3,2,4,3,2,1,4,5,4,2,3,3,3,4,4,2,3,1,2,3,5,2,2,5,3,3,2,5,2,1,1,4,3,5,1,1,3,1,3,2,1,5,2,3,2,3,2,3,3,2,2,4,1,1,3,1,1,3,4,4,3,3,1,2,1,3,5,5,1,2,2,2,2,5,4,3,4,5,4,3,3,3,4,3,1,4,1,1,3,3,5,3,1,5,5,3,1,3,2,2,1,1,4,1,2,3,5,2,2,5,1,4,5,2,2,1,5,1,2,1,2,1,1,5,3,4,3,3,3,1,1,3,5,1,5,5,5,5,5,4,5,2,4,5,4,2,1,2,2,2,4,3,2,2,5,1,4,3,2,1,1,5,3,5,5,3,1,2,2,4,3,5,3,1,5,4,1,4,3,1,5,4,3,4,3,5,4,3,4,3,5,3,3,5,4,4,5,3,3,4,2,5,1,1,2,3,2,5,5,3,2,5,4,1,5,4,3,3,4,5,2,1,3,3,4,5,5,2,5,3,4,1,2,5,4,3,3,5,5,2,1,3,1,2,3,2,4,5,1,1,1,5,3,5,4,4,5,1,2,5,4,4,1,5,4,2,4,2,2,1,2,1,1,4,2,3,2,5,3,1,3,1,4,1,5,5,5,1,4,1,4,4,3,2,4,2,3,2,3,1,4,3,5,3,3,5,1,2,2,1,1,1,3,1,3,3,4,4,4,2,1,5,4,3,1,3,3,5,1,3,3,1,2,4,5,2,3,4,3,4,4,2,5,2,1,5,3,4,3,2,5,1,1,3,4,2,1,3,4,1,2,5,1,1,3,1,1,4,2,1,4,1,4,5,5,3,2,1,2,4,1,3,5,2,4,1,1,3,4,3,4,3,5,5,3,4,3,2,5,1,3,2,4,5,2,3,1,2,3,3,5,4,2,1,3,5,3,4,4,5,2,2,5,1,1,2,4,4,2,3,2,1,1,4,5,5,2,4,4,5,2,2,3,3,3,1,2,5,1,3,4,1,5,5,3,5,4,2,5,4,1,2,5,1,1,3,5,1,5,3,4,2,3,5,4,5,4,5,1,2,2,3,2,3,1,1,2,2,2,2,5,1,2,3,4,5,1,1,1,4,3,1,5,5,1,5,5,1,3,2,3,1,1,1,5,4,4,5,4,2,5,5,5,5,5,5,2,5,5,1,5,3,1,3,5,2,2,5,1,4,5,3,3,5,4,1,5,5,1,5,2,4,2,3,1,1,1,1,2,2,4,5,3,1,3,2,2,1,4,5,5,1,3,4,1,4,1,3,4,5,2,3,1,3,3,4,4,5,2,3,2,1,2,5,1,1,2,2,5,5,1,1,4,5,2,2,5,2,1,5,5,5,1,2,4,4,4,1,2,5,3,5,3,1,2,2,3,3,2,2,2,4,2,1,3,5,5,4,1,1,4,5,1,2,2,4,2,2,5,5,4,1,3,1,4,5,5,4,5,3,3,2,2,5,1,1,3,2,2,5,4,4,5,1,4,2,2,5,2,4,5,2,3,5,1,3,5,4,4,2,2,1,3,4,1,5,2,1,1,4,3,1,5,3,4,2,4,2,5,4,3,4,5,3,5,1,3,5,3,3,1,4,4,3,5,3,5,5,3,5,4,3,5,5,1,2,5,3,4,3,4,1,5,4,5,3,1,3,1,5,2,3,1,1,1,1,5,5,5,5,3,1,2,3,5,2,3,3,5,3,5,3,1,2,3,5,5,4,3,3,3,2,4,4,1,3,3,2,2,1,4,3,5,5,4,4,1,2,5,5,5,5,3,3,1,3,5,1,1,3,5,1,4,5,4,4,4,1,1,2,5,4,4,5,3,4,3,1,2,5,5,1,2,5,2,3,4,1,5,2,4,3,3,3,5,5,1,2,3,1,2,2,4,2,3,4,1,1,1,3,5,3,1,2,1,1,3,5,2,2,5,3,4,4,2,2,1,2,1,2,5,3,3,3,5,4,5,2,2,3,5,2,1,1,5,4,1,5,5,1,5,4,3,1,2,1,4,5,3,3,2,2,5,1,2,5,3,1,1,2,3,4,1,1,5,1,1,3,4,1,4,2,5,5,3,3,2,4,5,3,2,3,3,4,1,4,3,2,1,1,3,2,3,4,1,1,1,1,5,4,5,1,5,3,3,5,3,4,3,2,4,3,2,5,4,1,5,5,4,2,3,3,3,5,2,1,5,3,4,3,4,1,2,2,3,2,4,5,3,3,4,5,3,2,5,5,1,2,5,5,1,2,2,4,1,2,1,3,3,2,3,1,3,2,4,4,3,4,5,3,2,1,1,4,3,4,4,4,2,4,1,5,3,1,2,1,1,2,2,1,1,2,5,3,1,1,4,3,4,1,4,4,2,2,3,2,3,1,2,2,5,4,4,3,4,2,1,5,1,3,2,5,4,3,5,3,3,2,1,4,4,1,2,3,1,1,5,4,4,2,4,4,5,1,4,1,1,4,1,2,4,5,1,3,3,4,2,1,4,3,4,5,2,4,4,1,1,2,4,5,2,5,2,4,1,1,1,5,2,4,4,1,4,3,3,1,2,4,1,2,5,4,1,5,1,5,1,1,4,1,3,3,3,2,2,5,3,4,2,3,2,3,1,2,4,1,4,1,2,2,1,4,2,2,4,2,4,1,4,3,2,3,3,1,3,1,1,3,2,2,5,3,5,4,5,4,5,1,3,4,1,1,3,2,2,2,1,5,2,1,4,1,1,3,4,5,4,3,5,1,4,2,5,4,4,5,4,4,1,1,4,4,4,5,4,4,1,2,4,5,4,4,2,2,3,1,1,1,3,5,3,2,5,2,3,3,4,1,2,1,4,3,2,4,4,4,3,2,2,4,2,1,4,1,2,1,4,3,5,3,3,1,2,1,3,5,1,4,5,2,4,1,1,5,3,3,2,3,3,1,3,1,5,5,3,5,2,1,2,5,4,5,4,4,5,5,1,4,1,4,1,5,3,3,4,5,5,5,4,3,2,4,4,4,2,1,1,5,2,5,2,1,4,5,3,3,5,3,5,4,2,4,1,4,5,3,4,4,5,3,5,5,1,1,3,1,4,5,3,4,2,3,4,5,5,2,4,4,4,5,5,3,4,1,4,5,1,5,1,2,2,4,3,3,5,5,2,1,5,2,1,1,3,5,3,1,2,2,2,1,4,4,1,3,4,5,3,4,1,4,1,3,4,1,4,1,5,2,3,2,2,4,2,3,3,4,1,1,2,1,2,5,3,3,4,4,5,3,2,1,1,2,1,1,4,4,2,1,4,3,4,4,3,4,5,3,5,1,3,3,4,2,1,2,4,2,2,5,4,3,2,5,5,4,5,2,5,5,2,3,3,2,3,2,4,5,4,3,5,5,4,4,4,3,3,5,4,2,5,4,1,1,4,5,4,4,2,1,5,4,1,3,2,5,5,4,1,1,4,4,1,2,3,1,3,1,4,4,1,3,3,3,2,2,4,3,3,4,3,5,2,4,5,2,2,5,3,2,4,2,2,5,1,4,2,1,4,1,2,5,3,4,5,3,1,2,1,2,5,1,1,4,2,2,5,2,1,3,2,1,2,5,4,4,5,5,2,2,4,5,4,4,4,3,2,2,5,3,3,5,2,2,3,4,3,2,1,4,3,1,2,2,2,1,2,3,1,3,1,3,5,5,4,2,4,4,3,2,4,1,4,1,3,5,2,2,4,3,4,3,5,4,2,2,1,3,5,2,2,1,1,3,2,5,3,5,3,4,2,5,2,5,4,2,1,3,1,2,3,3,4,1,1,4,1,3,5,1,1,5,5,5,4,2,5,1,2,5,5,5,1,5,1,2,5,3,3,1,2,1,2,2,1,4,2,5,1,3,2,5,1,3,3,3,5,3,3,4,4,2,5,4,5,4,2,1,4,4,3,4,1,4,5,1,2,3,4,3,4,2,5,2,1,3,4,4,3,2,3,1,2,3,4,3,4,3,2,4,5,2,4,2,5,5,2,2,4,2,2,5,5,2,4,4,4,1,1,5,4,1,4,4,3,4,5,4,5,2,2,4,2,4,5,3,5,2,2,1,5,1,5,3,1,4,3,4,5,1,1,5,3,4,4,3,1,4,3,3,3,1,4,2,1,4,2,2,2,2,2,1,1,5,5,5,5,3,4,4,2,2,4,4,2,4,5,3,2,4,4,5,1,1,2,4,5,1,1,4,3,3,3,5,1,5,3,5,3,5,3,5,5,1,2,2,1,5,1,3,5,1,5,5,3,4,2,3,4,4,4,3,5,5,4,1,2,4,1,4,1,4,1,3,1,4,4,5,5,2,5,4,3,3,5,1,2,5,5,5,1,1,4,1,5,4,1,2,3,2,4,4,1,5,3,4,2,5,4,4,4,2,4,1,3,5,2,4,5,5,3,1,2,3,1,4,4,3,4,4,5,3,3,5,1,3,5,1,4,1,4,1,2,1,4,4,2,1,1,5,4,4,2,1,5,4,1,3,1,5,2,5,2,2,2,3,1,5,4,3,2,2,4,2,2,1,5,2,5,3,1,5,1,5,4,3,1,2,1,2,4,2,5,1,1,3,4,3,5,5,3,2,5,2,1,2,5,3,2,4,2,5,4,5,2,3,5,4,1,2,2,5,1,5,1,2,2,3,5,5,5,1,1,4,2,4,5,5,1,3,5,3,1,1,2,1,2,5,1,5,1,1,2,5,5,4,1,2,5,2,4,4,2,3,4,5,2,5,5,3,1,4,1,5,2,1,5,5,4,2,3,4,2,2,1,1,5,1,2,1,2,3,3,3,3,1,1,2,4,3,1,3,5,5,5,5,1,5,3,3,3,3,5,5,5,2,1,1,5,2,3,1,4,1,3,3,1,4,1,5,3,1,5,5,5,1,1,3,3,3,3,5,1,3,1,5,3,1,5,3,1,1,4,1,2,4,5,1,4,3,5,5,4,4,5,2,2,2,5,4,5,5,1,1,1,2,4,5,2,5,4,1,4,3,3,4,4,1,1,1,4,1,1,5,2,3,2,1,1,4,4,4,1,1,2,3,2,5,1,1,3,5,5,2,1,1,3,5,1,3,3,3,4,2,5,3,4,4,5,1,5,4,3,2,4,1,2,4,5,2,5,2,5,5,2,5,5,1,4,1,4,4,2,1,2,5,3,1,3,1,5,3,1,2,2,3,5,5,5,4,1,5,2,2,4,4,4,3,5,1,4,1,4,3,1,1,2,2,5,4,4,2,1,3,1,2,1,4,4,2,3,3,4,5,4,5,1,4,2,1,1,1,4,2,4,5,5,4,4,5,1,4,2,3,4,4,2,5,4,2,5,2,5,4,4,2,4,4,2,4,5,1,3,4,1,1,3,1,1,2,5,4,1,5,5,5,3,3,5,4,2,3,5,1,2,4,3,1,1,5,1,5,1,4,5,1,3,1,4,1,4,1,2,3,1,1,2,4,3,3,5,3,5,3,3,2,4,4,3,2,1,4,2,2,4,2,4,5,1,2,5,1,5,2,2,2,1,4,2,4,4,4,1,2,1,2,3,3,1,1,4,3,3,3,3,1,3,5,2,2,4,2,3,1,5,3,5,3,5,4,2,2,2,1,3,2,4,4,3,5,3,2,1,1,4,4,4,2,2,4,2,3,3,5,3,1,1,3,2,2,1,1,2,4,2,4,4,4,4,1,1,2,1,1,4,3,1,5,1,1,2,2,5,4,1,5,1,1,1,2,3,2,3,1,1,1,2,5,4,1,3,3,4,1,4,1,4,4,1,5,2,2,3,1,4,5,4,4,4,3,5,2,1,3,2,2,2,1,1,2,1,1,4,2,3,4,1,5,4,3,1,1,3,4,5,4,4,4,4,4,3,1,3,3,3,4,2,1,1,5,1,2,5,2,3,5,2,5,4,3,4,3,1,1,3,1,2,2,2,4,2,2,2,1,1,2,1,2,4,4,3,1,1,2,5,5,2,1,3,1,5,5,3,2,2,5,1,1,5,1,1,4,1,3,5,4,4,2,4,2,1,1,1,4,2,5,2,4,1,2,1,1,3,1,4,2,2,5,4,5,1,4,4,2,5,2,3,3,3,2,3,1,3,2,3,1,2,5,2,5,2,5,3,5,5,3,4,4,5,4,5,5,2,1,1,2,1,5,3,1,1,3,2,3,5,2,5,3,3,2,4,5,4,1,1,2,2,4,4,5,2,1,5,1,4,5,5,1,3,2,4,4,3,5,4,5,2,1,4,2,3,2,1,2,3,5,5,2,1,2,4,1,2,5,1,4,3,5,2,4,5,1,2,2,2,1,3,4,1,4,4,4,5,3,4,3,1,3,4,2,5,5,3,1,2,4,3,5,1,4,5,2,3,2,4,3,1,1,1,2,2,2,4,1,5,3,5,2,1,4,3,5,1,3,2,1,4,4,1,2,2,2,5,4,4,5,4,4,1,4,5,2,2,4,4,3,5,2,1,2,2,2,3,1,4,2,2,3,1,1,2,1,2,5,3,2,1,1,4,4,5,3,4,5,5,3,4,2,5,5,3,3,2,5,2,1,5,3,2,5,2,4,3,5,5,4,3,5,4,5,3,2,3,4,4,5,4,2,2,1,3,1,1,3,4,3,1,2,4,2,1,3,2,4,1,3,3,5,3,5,1,2,4,5,5,2,3,4,2,2,5,4,5,3,2,1,2,3,2,4,3,4,2,2,4,1,4,2,2,1,5,4,2,1,3,1,2,4,4,5,3,4,2,1,5,4,4,3,5,4,1,1,3,4,1,5,1,2,1,3,1,2,1,1,5,3,3,5,1,5,3,5,2,2,2,1,4,3,4,3,3,4,1,1,4,3,2,4,1,5,1,3,2,4,3,4,4,4,1,4,1,2,1,5,4,4,2,1,2,2,5,1,3,5,2,4,5,3,5,3,1,3,3,1,1,1,4,5,4,3,4,5,3,5,3,3,1,2,4,2,3,1,4,5,4,1,5,4,3,4,2,2,5,2,1,1,1,5,4,2,5,1,4,2,1,2,5,4,5,1,3,4,4,4,2,3,5,4,4,5,4,3,5,2,2,4,2,1,3,4,1,5,1,3,2,2,5,3,3,1,5,1,3,2,4,3,5,2,3,2,5,3,3,2,4,2,2,2,2,3,3,3,1,3,4,2,1,1,1,1,3,5,3,4,5,5,3,1,1,2,2,3,3,3,3,3,4,3,4,4,3,1,3,2,5,2,2,5,1,1,4,3,5,2,3,5,4,3,1,1,4,1,2,4,2,4,4,4,5,4,5,1,1,5,4,3,4,1,4,5,5,2,4,2,2,5,5,5,3,2,4,1,3,2,2,1,3,5,4,5,2,3,1,2,4,1,3,4,2,2,3,5,1,3,2,4,4,3,4,3,2,2,5,5,1,1,3,5,2,3,4,3,4,2,2,1,2,2,4,4,3,4,1,3,3,3,1,4,5,4,1,5,4,5,2,5,3,2,5,5,5,1,4,2,5,1,5,2,1,4,2,1,4,4,2,4,5,3,4,1,2,3,2,3,3,3,2,5,2,3,4,5,5,1,1,2,4,2,5,3,2,4,3,4,4,5,5,1,1,1,5,2,1,3,1,3,1,1,1,1,3,5,4,3,1,4,1,2,1,4,3,4,3,3,5,4,1,4,2,4,2,1,5,4,4,5,1,4,3,5,4,4,4,4,1,3,2,1,1,5,4,4,3,2,1,5,3,4,4,1,4,2,2,4,5,1,3,3,2,5,1,1,3,2,5,5,5,1,2,5,2,1,1,4,2,5,4,3,1,1,1,5,4,3,5,2,5,2,1,5,4,5,5,1,5,4,1,5,1,5,3,2,3,3,4,3,5,5,2,2,2,1,2,3,2,2,4,3,2,3,1,5,2,3,3,4,3,3,2,1,3,2,5,1,5,4,1,5,2,3,3,1,3,3,3,2,5,3,3,4,5,2,1,3,5,5,1,3,5,1,4,3,2,5,5,3,5,4,3,4,3,2,3,3,2,2,3,5,5,4,4,2,4,4,4,1,5,2,3,2,1,5,4,5,1,5,1,2,5,4,3,2,1,5,2,2,1,5,1,1,2,1,3,4,5,4,3,1,1,3,4,2,3,5,3,4,4,3,1,4,1,3,2,1,1,4,3,5,1,1,4,5,2,2,3,4,3,5,2,1,2,3,4,3,2,3,4,4,4,5,5,2,2,5,1,4,4,4,5,1,4,2,4,2,2,3,5,3,2,5,2,1,2,2,2,1,4,4,1,3,3,1,1,5,3,5,4,1,1,3,4,3,2,4,1,2,1,1,2,1,5,1,3,4,3,2,5,3,4,2,4,3,1,2,4,5,3,5,2,5,4,5,2,1,4,4,1,1,1,3,2,2,4,1,3,3,1,3,1,4,1,4,3,2,3,3,4,3,5,2,2,5,4,2,5,3,4,2,1,4,4,1,5,4,4,1,3,3,3,4,1,5,5,2,5,1,1,1,5,3,3,2,4,5,5,2,4,4,3,4,4,1,1,2,4,4,2,5,3,2,2,4,5,1,1,2,4,3,2,2,2,4,4,5,1,3,5,2,1,4,3,2,2,4,4,3,5,1,5,2,1,4,2,1,2,1,4,5,2,2,2,4,3,5,3,1,2,2,2,3,5,1,5,4,4,2,3,5,2,3,1,4,4,5,5,3,3,4,4,1,5,3,4,4,2,3,2,1,4,3,1,2,3,3,5,4,2,1,1,3,1,1,3,2,1,1,1,2,5,5,5,4,1,1,3,4,2,2,2,2,2,3,2,3,1,1,3,4,3,5,1,2,3,2,4,3,1,5,3,2,5,4,4,2,5,2,5,2,1,2,1,5,1,4,5,2,2,3,5,1,3,3,5,1,2,5,5,3,3,5,2,2,3,2,2,5,5,4,4,2,4,5,1,4,1,3,3,5,2,3,3,2,1,4,1,1,4,5,2,2,3,3,4,5,2,2,5,5,5,4,1,1,2,4,3,2,3,4,1,5,4,1,2,4,2,1,5,4,1,1,1,5,5,1,2,3,1,2,2,1,4,1,5,1,4,1,3,1,3,1,1,5,3,3,3,1,2,3,2,2,1,2,4,1,4,4,5,1,4,2,5,1,2,1,4,3,2,3,5,3,1,1,4,1,3,1,1,3,5,4,5,5,5,2,4,2,1,3,1,1,1,4,1,3,5,4,1,1,4,1,4,1,3,5,4,5,4,2,5,3,1,4,1,2,5,4,1,1,1,1,1,4,3,3,4,2,4,2,1,4,5,5,3,2,2,4,1,4,3,5,1,5,4,2,3,3,2,1,1,3,1,2,2,3,1,2,5,3,3,5,1,2,3,4,2,5,2,3,1,5,1,4,2,4,5,4,5,2,1,1,5,2,5,4,5,5,4,2,5,5,2,1,4,4,3,3,5,3,4,4,3,2,3,3,2,4,3,2,2,1,1,1,5,1,1,5,1,1,5,4,2,2,1,3,3,4,5,5,3,3,5,3,1,4,3,3,1,4,2,2,4,1,5,5,1,5,1,3,5,3,2,2,2,5,3,4,2,2,4,5,5,1,1,2,4,2,5,1,5,2,2,1,3,2,1,4,4,1,4,1,4,3,4,4,2,3,3,2,5,5,3,4,3,3,4,5,1,5,5,2,5,1,2,3,4,1,5,1,1,1,1,4,1,4,5,3,2,5,5,4,1,3,3,3,3,5,2,4,5,5,2,3,5,4,5,1,4,3,2,2,3,1,1,4,3,4,5,5,4,3,1,3,3,1,5,4,3,2,2,1,4,2,1,2,5,5,2,4,4,3,1,2,2,5,4,5,4,4,5,3,5,5,4,1,4,5,5,2,2,4,2,1,3,1,2,5,5,1,5,5,4,2,2,5,3,1,5,4,5,5,4,3,3,3,5,5,5,1,4,5,3,4,2,1,1,5,2,4,3,1,2,4,2,2,1,4,5,1,4,2,2,2,3,5,3,1,1,4,3,5,1,4,3,2,4,1,5,2,4,4,1,2,1,1,1,3,1,4,5,4,5,1,1,2,2,1,3,4,1,1,4,3,3,1,2,5,1,2,5,4,1,2,1,4,4,1,1,3,2,4,3,4,2,5,1,1,4,1,3,5,1,5,5,1,5,3,4,5,3,4,4,3,1,4,4,5,5,5,4,1,2,3,2,5,4,2,4,5,1,4,3,1,1,1,2,4,3,4,1,2,4,2,1,5,4,4,1,3,5,1,2,3,3,3,4,3,5,1,4,1,2,5,1,5,5,2,4,1,3,5,2,3,1,1,2,1,4,3,3,2,2,4,5,4,2,2,2,5,4,5,2,1,4,4,3,1,3,2,4,4,2,5,3,2,3,5,3,3,1,2,2,5,4,1,4,1,5,1,5,4,2,5,5,5,2,3,4,1,4,3,4,1,4,5,1,2,4,2,1,3,4,4,3,1,1,2,4,1,5,2,1,5,3,5,2,2,3,2,2,5,4,4,3,4,2,5,1,3,1,4,1,3,5,1,3,1,2,4,1,4,3,2,5,3,3,3,2,4,2,5,2,1,2,4,1,4,4,3,5,2,4,2,4,4,3,2,1,5,5,3,5,5,1,3,2,4,4,1,4,1,5,1,1,4,3,4,2,5,1,4,5,4,1,2,1,1,2,5,2,3,2,1,1,2,4,4,3,2,5,2,2,3,5,5,1,3,2,5,3,5,1,1,1,2,5,3,1,4,5,5,3,2,1,4,3,3,4,1,5,3,2,3,4,5,5,2,4,1,3,1,1,4,2,4,2,4,2,4,2,3,3,4,3,1,5,5,4,1,3,2,4,3,4,4,1,5,1,1,2,3,3,3,3,5,3,4,5,2,4,4,1,3,5,1,4,3,4,2,1,1,1,3,1,1,2,2,3,1,4,5,5,5,3,3,3,1,2,2,2,4,4,4,1,5,2,2,1,5,1,2,3,2,5,3,4,2,5,3,4,4,5,4,2,2,2,3,3,2,4,3,4,1,3,1,5,3,5,1,5,3,1,4,5,1,1,2,1,3,3,4,5,1,5,4,1,3,4,2,4,2,1,5,2,3,1,2,2,3,5,2,3,5,5,1,3,2,1,5,2,5,5,5,1,4,5,2,5,4,1,1,4,4,5,4,4,3,1,4,2,2,3,1,3,2,4,2,1,3,2,1,3,1,2,1,4,1,1,3,4,4,5,2,5,2,4,2,4,5,2,5,2,4,2,4,3,2,4,3,4,5,5,2,5,5,4,5,1,1,5,2,4,3,5,5,1,3,3,5,5,4,2,2,4,5,2,1,5,5,3,2,1,4,3,2,5,3,5,5,4,4,1,1,2,4,5,2,4,3,4,4,1,4,5,3,4,1,3,4,4,3,3,2,4,5,2,5,5,2,2,1,5,3,5,1,5,4,5,2,5,5,5,2,3,4,3,1,2,2,1,2,5,4,1,2,3,2,2,1,5,3,5,3,2,5,2,5,3,1,1,5,1,4,2,3,4,3,1,3,4,3,3,4,5,1,5,1,4,3,5,3,4,5,2,3,4,5,3,1,3,3,5,3,4,2,5,2,4,1,3,4,5,2,4,1,3,1,1,1,2,2,5,1,2,1,2,1,5,1,1,1,2,3,3,1,4,2,3,2,1,4,2,3,5,1,4,4,5,4,1,2,3,1,2,2,4,4,5,3,3,1,2,2,3,4,4,3,1,4,5,2,3,4,1,3,1,1,4,2,4,3,5,2,3,3,4,2,4,5,5,5,1,2,1,5,2,2,5,4,1,4,1,1,4,1,1,5,2,5,2,1,2,3,5,4,1,4,1,4,2,2,4,4,1,2,5,4,3,5,1,4,2,3,3,4,1,1,3,3,5,1,1,3,1,2,4,5,2,4,4,1,4,2,3,4,3,1,4,4,2,3,5,5,1,2,2,3,1,4,5,2,3,4,4,4,2,4,4,5,1,1,1,5,4,1,1,1,4,5,2,4,1,3,4,5,3,3,4,2,4,4,4,4,1,4,1,4,2,2,5,5,1,2,1,1,1,5,4,4,3,4,3,3,1,1,1,1,5,4,5,1,4,3,1,3,5,3,4,3,5,4,5,5,5,2,4,1,1,4,3,3,2,3,2,2,4,1,1,4,3,2,1,3,4,5,5,5,3,1,4,3,5,4,5,1,1,5,2,2,5,3,2,4,2,1,5,2,1,2,3,4,3,5,3,2,1,2,4,3,4,2,4,2,1,5,1,4,4,2,3,4,1,2,5,3,1,4,4,5,4,5,5,3,5,1,4,4,2,2,4,5,5,1,2,1,1,1,1,2,4,4,3,1,4,1,1,2,1,2,1,2,4,2,2,5,2,2,3,2,2,1,3,3,1,4,4,2,2,5,1,1,3,1,2,2,1,2,4,4,3,2,5,2,5,1,3,3,3,5,4,3,1,3,4,4,5,3,5,1,4,5,2,2,1,2,4,3,3,2,5,1,1,4,1,1,3,1,4,5,5,3,1,1,3,2,2,5,2,2,5,1,2,3,4,1,5,2,1,2,4,2,5,2,5,4,5,2,4,4,4,1,2,2,1,5,1,4,4,1,5,5,2,1,1,1,5,3,1,3,4,2,1,4,4,2,5,3,5,3,5,3,4,2,5,5,5,1,3,1,4,4,3,1,4,1,2,5,5,3,2,4,3,2,4,2,3,5,4,3,3,2,2,1,1,5,5,2,5,1,2,2,3,2,4,2,2,3,2,3,5,4,4,4,4,5,2,1,3,2,3,1,3,4,3,5,1,3,2,5,4,5,3,2,4,3,1,5,1,1,1,5,2,3,1,1,3,2,2,4,4,1,2,4,5,3,5,4,4,1,1,5,2,1,4,1,5,2,3,2,2,4,4,5,5,3,1,1,3,5,2,5,5,5,5,3,5,3,2,2,2,1,1,2,3,3,2,2,3,3,5,1,1,3,1,4,5,1,5,5,2,5,3,1,5,5,1,5,2,5,5,4,4,2,5,1,2,1,3,5,5,4,3,5,1,5,2,2,5,4,1,4,4,5,1,2,5,1,3,4,2,4,3,4,3,2,3,2,2,5,1,3,2,2,3,5,1,2,1,4,1,4,5,5,5,3,3,3,5,4,5,4,5,3,2,5,5,4,2,5,4,2,2,1,4,4,3,2,2,5,4,5,5,1,1,1,2,2,2,5,3,1,5,1,2,3,2,5,4,5,1,2,5,2,4,5,2,1,3,3,3,3,1,5,3,3,4,3,2,3,2,5,3,5,3,3,1,1,1,5,3,5,4,5,5,5,5,3,4,3,5,1,4,4,1,2,4,4,2,2,3,4,2,3,4,1,5,1,2,3,4,1,1,5,3,2,1,2,3,5,4,1,3,3,4,3,3,2,3,3,5,4,5,1,3,5,3,2,4,3,1,5,2,1,3,1,1,5,4,4,1,1,1,1,4,5,5,3,4,5,5,3,3,2,5,1,3,2,1,1,1,3,4,5,1,5,3,1,5,1,4,2,3,3,4,1,4,4,1,2,4,5,1,4,5,3,5,5,3,5,5,3,5,5,5,5,3,5,3,1,5,4,5,5,2,4,1,5,2,4,2,3,4,3,4,3,5,2,1,3,5,5,4,1,2,4,4,2,2,5,2,1,3,4,1,1,2,3,2,3,3,4,3,4,3,2,4,1,1,4,1,1,3,5,5,2,5,4,4,2,4,1,2,5,5,3,5,2,4,4,2,2,2,4,2,3,1,2,5,5,3,3,3,5,1,1,3,2,3,2,4,3,3,1,1,2,4,4,5,3,1,3,5,3,3,2,3,3,4,1,1,3,3,5,4,4,3,1,1,4,4,1,5,1,1,2,2,3,4,2,3,5,5,3,2,5,2,3,5,1,5,5,3,2,2,5,1,3,2,2,3,1,5,2,1,3,1,4,2,2,1,4,2,3,4,1,2,3,5,5,3,1,5,3,2,4,3,2,3,2,3,2,1,5,1,4,4,5,2,5,3,1,4,3,1,1,5,1,2,5,4,5,4,2,2,1,5,5,3,2,2,5,5,2,2,2,4,5,5,2,5,3,2,1,1,4,4,1,1,3,2,4,4,5,3,2,3,2,2,2,2,2,3,2,4,3,2,3,4,5,1,5,5,2,5,4,3,3,1,4,2,2,1,2,2,1,2,1,5,1,1,2,2,5,1,2,2,3,5,1,5,3,5,1,2,5,1,1,2,2,3,2,3,2,3,2,5,1,3,4,1,3,5,5,2,3,5,1,3,3,2,5,5,4,1,4,1,4,1,1,1,2,3,3,4,4,2,2,2,3,5,5,5,2,4,5,5,3,2,2,2,4,5,5,1,4,1,4,5,2,1,2,5,1,4,1,3,2,4,3,4,4,4,4,2,2,5,3,3,1,3,2,2,4,3,1,1,1,3,5,5,1,4,3,1,5,1,2,4,4,4,5,1,1,2,1,2,2,5,2,1,1,5,1,3,1,1,2,5,5,1,1,2,2,5,5,5,5,2,3,5,2,3,3,4,5,5,1,1,5,1,5,4,4,1,5,3,4,3,3,2,3,4,5,3,3,5,3,4,4,2,2,5,3,1,3,4,2,2,2,5,2,1,5,4,4,5,3,1,5,3,2,1,2,5,1,4,4,2,3,3,3,1,5,5,3,5,5,4,5,2,3,5,1,5,2,3,2,3,1,5,2,2,1,5,1,1,2,3,3,5,1,4,2,4,3,3,2,3,3,5,2,2,1,4,1,3,3,4,5,2,1,3,4,4,1,2,5,2,4,4,4,3,1,5,5,2,1,2,2,4,2,2,5,3,5,2,3,1,5,4,4,4,2,4,4,5,1,5,2,4,1,4,4,5,4,1,1,2,4,4,2,1,1,5,3,2,3,3,4,2,5,1,3,4,4,4,4,2,1,5,2,5,1,3,2,4,4,1,4,2,4,4,5,5,1,3,1,5,4,1,5,4,1,1,5,5,3,5,3,1,1,2,1,2,5,5,3,2,2,1,2,1,5,1,1,2,5,2,5,4,5,2,4,4,1,5,3,1,2,3,1,2,2,4,5,1,3,5,3,1,3,5,5,1,4,2,1,3,5,1,3,5,2,5,2,1,3,2,4,2,3,3,3,2,4,3,3,5,3,1,1,1,1,5,5,2,3,4,3,1,1,2,1,2,1,5,3,3,2,5,5,3,1,2,4,1,2,5,4,2,5,2,5,2,3,5,3,4,5,2,4,3,1,3,1,1,3,5,1,2,3,1,3,5,3,2,3,1,1,5,5,5,5,3,4,4,1,3,3,5,2,4,3,2,2,3,2,5,4,3,3,4,4,2,1,3,1,3,4,3,4,2,2,3,1,4,4,1,5,4,4,4,4,4,1,5,1,5,4,3,4,5,2,3,2,1,2,3,2,1,2,3,1,1,5,5,3,4,5,4,3,4,4,2,1,2,5,1,1,2,1,3,3,5,3,3,2,2,2,3,5,1,4,5,2,3,3,1,3,4,5,3,1,1,2,3,4,5,3,3,4,5,2,4,2,5,3,4,5,5,1,5,5,1,4,1,4,2,4,4,4,5,3,1,3,2,3,4,1,4,5,1,1,4,1,5,3,4,2,1,3,4,2,1,5,5,3,2,3,4,1,2,1,3,5,3,4,4,1,2,5,3,2,4,1,3,3,2,5,5,5,1,4,2,3,2,3,2,5,5,3,3,3,2,3,3,4,2,5,1,5,1,4,3,4,2,2,1,5,2,5,4,1,5,1,2,2,5,5,5,4,5,5,4,2,3,5,2,3,1,2,1,5,2,2,1,1,3,4,3,5,5,2,4,2,4,4,2,1,5,3,1,4,4,1,1,5,1,5,3,5,2,5,5,4,1,5,2,5,5,3,4,1,2,1,5,3,5,2,1,2,1,5,3,1,3,1,2,2,1,3,4,3,2,4,5,1,3,4,4,5,2,2,1,2,2,3,3,5,4,4,3,1,2,5,1,2,1,5,4,2,2,4,5,5,5,3,2,3,1,4,5,3,4,4,2,4,4,3,2,1,1,1,4,2,1,5,2,4,1,5,4,4,5,5,1,4,2,4,5,5,2,1,5,4,2,2,2,1,3,4,3,3,4,4,5,2,2,1,4,1,2,5,3,5,2,4,4,5,1,3,5,2,4,3,2,4,5,4,2,4,5,4,5,3,2,1,5,3,2,2,3,2,1,5,4,4,4,2,2,4,4,5,2,5,2,2,4,1,2,5,1,4,5,1,1,4,2,2,1,2,3,1,4,2,2,5,4,4,1,1,4,3,5,5,2,4,1,4,4,4,4,3,1,5,2,4,3,5,3,4,2,3,4,4,4,1,4,1,1,4,4,2,4,4,3,4,5,2,2,5,2,5,4,3,4,2,2,3,3,1,3,3,4,3,3,5,3,2,4,3,1,4,2,1,2,2,3,1,3,5,1,1,2,1,3,5,5,2,5,2,1,4,3,2,5,3,1,4,1,3,2,1,3,1,5,5,3,1,1,1,2,1,2,5,1,3,5,2,5,3,3,2,1,2,3,1,4,5,2,3,2,4,4,2,1,3,3,1,3,2,4,2,5,5,3,5,2,4,4,3,4,3,5,1,2,3,3,4,4,2,4,2,4,5,4,5,4,5,1,1,4,5,4,3,3,2,2,5,2,4,4,1,4,5,3,4,4,2,2,3,5,1,1,1,3,4,2,5,2,2,3,3,4,2,4,3,1,5,1,1,1,5,2,3,1,1,3,1,1,1,4,5,5,3,2,4,3,3,4,3,1,1,1,4,1,2,5,3,1,1,4,3,5,3,3,1,5,1,3,5,4,2,3,4,2,1,2,2,4,5,1,1,5,4,2,3,1,1,3,5,5,4,1,1,1,5,3,4,5,4,3,2,2,5,1,5,2,3,5,1,4,3,5,5,1,1,4,4,1,1,3,5,2,5,3,3,1,2,2,5,4,5,3,3,5,3,3,2,4,5,1,4,1,5,1,2,3,4,1,4,5,4,2,1,1,3,5,2,5,2,4,4,4,3,5,3,4,4,5,4,2,4,1,1,4,4,1,5,3,3,1,3,4,4,3,2,5,4,4,3,3,2,2,4,5,2,4,3,4,5,1,1,2,5,4,2,2,5,3,3,5,5,5,3,4,1,2,1,1,1,4,4,4,4,1,1,1,4,4,4,4,2,5,2,3,1,3,1,5,1,5,4,2,3,2,3,5,3,3,2,5,2,2,5,1,3,4,3,3,3,5,2,3,4,1,1,2,3,1,3,5,2,2,1,5,4,4,2,5,3,4,1,3,2,2,1,1,3,5,5,1,1,5,1,4,5,2,4,2,1,2,4,3,5,2,2,1,5,4,3,3,5,2,3,1,2,2,4,5,2,5,2,3,1,5,4,5,3,4,3,5,4,1,4,5,4,1,3,1,2,3,4,2,2,4,5,4,4,3,5,3,2,1,5,5,3,5,2,4,1,3,1,4,4,4,4,2,1,4,3,5,2,1,3,3,4,2,4,2,3,1,3,1,4,1,4,1,3,1,4,2,3,2,4,3,5,2,5,1,3,3,3,2,3,1,3,1,1,5,4,4,1,1,3,3,4,5,2,4,5,5,5,1,2,1,5,1,3,4,3,3,5,3,3,3,1,2,4,3,5,1,5,2,2,5,5,2,4,5,3,4,3,4,1,4,5,4,5,2,2,3,1,2,4,3,2,2,1,1,2,5,3,1,5,1,2,5,4,1,1,4,1,1,5,3,5,3,4,3,2,2,4,2,4,5,1,3,4,3,1,2,1,3,3,3,4,2,3,4,3,5,1,5,4,1,5,5,3,3,2,5,5,4,4,3,2,2,1,3,5,1,5,3,5,1,2,2,3,2,5,4,1,5,1,1,5,5,1,1,4,5,1,2,3,4,1,5,1,4,3,4,3,4,1,3,3,1,1,1,4,1,5,4,5,1,4,1,3,3,1,4,4,5,5,4,5,5,5,5,3,4,5,5,1,4,2,2,2,3,5,5,3,1,3,1,1,5,2,3,3,4,3,1,3,5,4,4,2,1,2,4,2,1,2,1,4,1,5,3,2,5,1,2,3,1,1,4,5,2,3,2,2,5,5,1,3,2,3,5,3,2,4,2,5,2,4,1,4,2,5,2,4,5,3,3,2,1,3,3,3,1,4,5,4,1,5,5,3,4,2,1,1,1,1,4,3,4,2,1,5,4,5,5,4,3,1,5,1,4,3,4,1,1,5,4,3,5,2,4,4,3,3,3,2,3,3,5,5,3,3,5,4,5,2,5,4,2,1,4,3,5,2,5,3,1,1,2,4,3,4,3,2,4,3,3,3,5,4,4,4,3,4,4,5,4,3,1,3,5,3,1,4,5,2,3,2,1,2,2,3,2,2,5,2,3,2,5,5,5,5,1,2,5,3,3,5,4,5,3,2,5,5,5,3,3,2,4,1,4,1,4,1,5,4,1,2,5,4,1,2,3,1,4,4,5,3,3,1,5,3,3,1,5,4,2,4,4,1,5,5,1,2,3,4,2,5,3,3,3,2,3,1,5,5,3,1,2,4,4,5,4,3,3,3,1,4,1,4,5,1,3,4,4,1,5,5,5,4,5,3,3,5,4,1,3,1,5,4,2,1,2,3,4,4,4,1,1,3,5,3,3,2,5,3,2,3,4,4,2,4,1,4,1,3,4,4,5,3,2,2,3,2,2,1,1,4,5,1,5,4,4,1,2,1,2,3,4,1,2,4,4,4,1,1,2,2,1,1,4,1,2,5,5,2,1,4,2,3,1,2,2,4,2,1,5,5,4,3,4,5,4,2,2,3,4,1,2,3,3,5,1,1,2,5,5,2,3,3,4,4,3,1,1,1,5,1,2,2,4,1,5,1,1,3,4,4,4,2,3,3,2,3,5,1,3,5,3,2,2,1,1,1,5,2,3,3,3,2,4,4,2,2,4,5,4,3,4,2,3,2,3,3,3,5,1,3,1,4,1,4,2,3,5,3,4,2,1,2,4,4,4,3,4,2,5,5,5,1,5,2,1,5,1,4,1,4,4,3,3,4,3,5,2,5,2,3,2,2,2,2,4,5,1,1,3,2,2,2,4,4,4,4,2,4,2,3,2,4,3,1,5,1,2,3,4,2,5,5,5,4,3,1,4,4,2,4,4,3,4,5,5,1,2,5,1,1,1,2,1,5,4,4,1,2,4,3,2,2,4,5,5,4,1,2,3,5,3,1,1,3,1,4,4,1,2,1,4,5,3,1,5,5,2,4,1,1,3,1,1,3,2,3,5,4,1,4,1,5,4,3,2,2,2,1,1,5,5,4,3,5,1,3,1,5,2,4,5,1,1,2,4,1,4,2,5,3,5,1,4,5,5,4,4,4,1,1,2,3,2,4,2,5,5,5,2,4,2,2,3,1,1,5,5,2,4,1,2,2,2,3,1,4,3,3,3,4,4,5,2,2,3,2,1,5,4,4,1,5,2,2,3,3,1,1,1,4,4,1,5,3,2,2,5,5,1,3,4,4,2,4,3,4,1,4,1,2,5,2,1,4,5,5,5,3,4,3,5,1,5,5,4,4,2,5,3,4,1,5,3,2,1,5,2,1,2,3,5,2,5,1,4,2,1,4,5,2,1,3,1,2,5,1,2,5,5,1,3,3,4,1,5,3,2,3,4,1,1,2,3,4,5,1,3,4,4,4,1,1,3,2,2,4,5,2,3,5,2,5,1,5,1,1,3,5,1,5,3,3,1,5,3,1,1,2,1,5,2,1,4,2,5,4,1,1,5,5,4,1,2,1,1,1,3,5,1,5,2,5,5,3,2,4,4,1,2,4,1,2,4,5,5,1,3,3,5,3,2,2,5,5,5,1,5,4,3,5,1,3,5,5,2,1,2,3,2,4,5,1,5,4,4,1,4,5,5,3,1,4,5,4,3,5,4,2,3,3,1,1,4,5,2,5,3,1,5,5,4,4,3,3,3,5,3,5,2,1,3,1,4,5,2,5,2,3,2,1,2,4,3,3,1,4,4,4,3,3,1,1,3,4,2,5,4,3,5,5,1,1,5,3,4,1,2,3,4,3,1,2,3,4,4,4,4,5,3,1,3,3,5,3,1,2,3,2,3,4,5,2,4,2,4,3,1,5,1,1,1,1,1,5,4,3,1,3,2,1,3,3,4,1,4,2,4,5,1,4,2,1,2,5,5,2,4,2,1,5,4,3,2,3,4,5,4,1,1,5,1,3,3,5,3,2,5,5,1,2,1,2,4,1,2,5,4,4,3,2,2,2,3,3,5,5,1,2,4,3,3,1,1,3,3,2,2,5,1,5,5,3,3,2,2,4,2,4,5,4,1,1,4,1,2,3,3,2,5,4,5,1,1,3,3,1,1,4,1,4,5,3,5,4,5,1,2,4,3,2,2,2,4,5,4,4,1,5,5,4,1,5,3,5,3,4,5,5,5,2,3,1,3,3,5,1,4,3,3,5,4,2,1,1,5,5,1,1,2,4,4,2,5,5,2,5,4,4,2,3,2,4,5,5,4,5,2,2,1,4,1,1,4,4,3,5,3,3,4,1,4,4,4,2,2,4,3,2,4,4,1,4,3,4,4,3,5,3,5,1,3,4,1,3,1,2,4,4,3,5,3,2,1,1,2,1,1,2,4,1,2,4,3,4,1,4,2,4,5,1,3,1,1,2,5,1,5,5,2,3,3,5,5,4,1,2,1,2,2,1,2,3,1,4,1,2,1,3,1,3,3,4,3,1,4,2,5,1,5,4,4,5,4,3,5,1,5,3,3,1,4,3,3,1,5,5,2,3,3,5,1,3,2,1,1,4,1,2,5,5,5,3,5,5,5,2,3,5,3,3,3,1,3,2,5,3,2,1,1,4,2,5,4,1,2,2,3,1,2,1,2,5,2,3,1,4,1,5,5,5,5,5,3,5,3,1,3,3,4,4,3,5,4,4,3,3,4,1,4,3,4,3,5,3,2,5,4,3,3,5,4,3,1,4,4,4,5,1,5,5,3,1,5,4,4,4,5,1,5,4,2,4,3,2,4,3,3,2,4,1,4,4,3,1,2,3,3,3,2,3,3,5,4,3,3,1,1,2,4,2,2,3,2,1,3,3,5,1,4,1,1,5,1,5,3,4,2,1,4,3,3,1,1,5,3,4,5,3,4,1,3,5,1,3,3,5,4,4,5,2,4,1,2,1,3,1,4,2,3,3,1,2,5,2,2,4,2,4,3,5,4,2,2,1,5,2,5,4,5,5,5,4,2,5,4,4,4,4,2,5,4,4,3,5,4,4,3,4,1,2,5,4,5,1,2,1,3,2,1,2,2,1,2,1,5,3,3,4,3,3,4,4,1,1,3,1,1,1,1,1,3,3,5,5,5,5,4,5,4,4,5,4,5,5,4,5,4,2,3,1,5,3,4,5,1,3,1,1,3,1,2,2,3,3,2,1,2,5,3,1,5,4,2,3,4,4,5,2,1,2,5,3,3,4,4,1,1,1,3,2,1,5,5,4,1,4,1,2,4,4,2,2,3,2,5,5,2,3,4,2,2,1,4,1,3,3,1,4,2,1,5,5,2,4,4,3,3,1,4,4,3,2,2,4,1,1,5,4,1,1,4,1,2,5,1,5,1,4,2,1,5,3,4,2,5,5,1,5,2,3,2,2,1,3,3,2,3,5,4,4,4,5,2,4,2,2,2,1,1,5,5,1,2,2,3,2,2,3,5,3,3,2,3,5,2,2,4,3,2,2,5,3,4,1,4,3,5,1,1,5,1,3,4,4,5,3,2,3,4,4,4,5,2,5,3,1,5,2,5,5,1,2,3,5,3,3,5,1,1,2,4,5,5,2,4,4,1,4,4,2,1,1,2,1,5,3,3,1,3,4,3,3,2,1,2,3,2,2,2,3,5,1,5,3,5,4,3,3,2,1,5,3,4,1,1,4,5,4,5,2,3,4,1,1,3,4,3,2,5,4,1,2,5,3,1,5,4,4,2,2,3,1,2,1,1,4,3,1,1,3,3,1,5,3,5,2,2,4,1,5,3,5,3,1,2,5,2,5,3,2,5,3,2,3,2,5,4,1,4,2,5,2,4,5,3,4,3,1,1,2,3,4,1,1,5,5,1,1,3,3,3,5,2,2,5,2,3,5,1,3,3,4,2,4,5,3,4,1,3,3,2,1,5,5,5,3,1,3,5,4,5,3,1,5,5,2,1,5,3,5,3,1,3,1,1,5,5,3,5,3,1,4,2,4,4,1,1,5,5,5,1,5,2,3,1,2,1,3,3,3,4,4,2,4,4,5,2,5,1,4,5,5,1,3,5,1,5,2,4,3,5,2,4,1,5,5,2,3,5,5,1,2,1,2,3,2,1,3,5,4,5,5,2,4,3,5,1,4,2,3,4,2,1,5,3,5,5,5,2,5,1,5,5,5,4,4,2,5,3,2,1,1,1,5,5,5,2,5,1,2,5,1,5,4,2,5,3,4,2,3,5,2,4,1,3,2,5,2,4,4,4,5,3,3,3,2,4,2,1,2,3,4,5,5,1,2,1,1,4,3,5,2,5,3,3,5,1,4,4,1,4,2,5,1,5,5,5,2,3,5,2,4,3,2,4,2,1,3,2,4,1,5,2,3,5,3,2,5,4,4,2,4,3,1,3,2,3,4,4,2,5,5,1,2,5,1,1,2,2,3,2,5,5,5,5,3,4,3,2,5,3,4,2,5,5,3,2,1,5,4,4,3,1,4,2,1,5,2,5,1,5,4,4,1,5,1,2,2,4,1,4,2,3,2,4,4,2,3,5,4,5,2,4,5,3,1,5,3,4,3,3,3,1,3,5,4,3,3,4,5,3,4,1,1,2,5,2,3,4,4,3,4,2,1,2,1,3,4,3,4,2,4,3,2,5,4,1,4,3,3,5,1,5,1,3,5,3,4,4,5,2,5,1,4,3,2,1,4,2,4,1,5,1,3,5,5,5,2,3,4,2,2,3,5,5,2,3,4,3,3,2,4,3,5,3,2,4,5,2,5,4,1,5,4,1,1,1,3,5,4,3,5,3,4,4,2,4,2,2,4,4,1,3,2,1,4,5,3,2,3,5,3,4,3,4,2,3,1,1,5,2,1,5,4,1,1,4,1,3,1,4,2,4,4,1,5,5,1,2,4,1,4,3,3,1,3,3,2,4,5,2,4,5,4,4,1,5,5,4,4,2,5,4,1,5,2,5,5,1,2,1,2,4,5,2,3,3,2,3,2,4,1,5,5,1,1,3,5,3,4,2,3,5,3,4,4,1,2,1,3,4,1,3,3,2,2,1,2,4,3,3,1,2,1,5,3,4,1,4,3,3,4,5,3,4,3,4,4,2,1,3,5,3,5,2,5,5,4,4,5,1,5,3,2,3,3,3,5,5,4,3,2,5,2,3,4,1,1,5,2,3,1,4,3,2,3,4,4,3,4,2,3,2,1,2,3,4,5,4,5,3,4,5,3,3,2,1,2,1,3,4,1,5,5,4,4,5,5,4,2,1,2,2,3,5,2,4,3,2,4,2,2,4,2,1,5,2,5,3,5,4,5,5,1,1,4,4,4,3,5,5,5,4,4,5,2,3,3,1,2,3,2,4,1,5,2,2,3,2,2,2,2,2,2,4,4,4,3,1,2,1,2,5,2,1,4,1,5,4,3,3,3,2,5,1,2,2,2,5,2,1,5,5,3,4,2,3,4,3,2,2,5,5,3,1,5,4,1,5,2,1,4,4,3,2,4,2,1,1,4,2,3,4,4,3,5,5,5,5,1,1,3,4,4,5,5,4,5,3,2,1,2,4,2,5,3,3,1,1,3,3,3,2,3,4,1,1,5,5,1,2,5,3,5,5,3,1,1,3,5,1,1,3,3,4,1,4,4,2,2,1,3,5,2,1,2,3,5,3,3,3,1,3,2,4,3,2,5,4,3,3,3,2,3,2,1,4,2,2,2,3,3,2,1,5,2,1,1,4,3,4,5,2,2,2,3,2,5,2,4,2,1,4,5,5,3,4,3,5,4,1,4,1,4,1,3,2,1,3,5,4,3,2,3,2,4,1,3,5,4,1,4,5,4,2,4,4,3,4,2,4,4,1,2,2,4,2,1,2,3,5,3,3,1,5,3,3,1,3,5,4,4,4,2,5,2,2,2,4,5,4,1,4,5,3,2,3,5,1,4,3,2,4,4,4,4,3,4,2,5,2,3,2,5,1,2,2,1,3,1,1,1,5,2,2,2,4,1,4,2,4,4,5,4,4,5,3,3,4,2,5,4,5,5,4,5,2,4,3,2,3,5,1,5,2,5,3,3,3,4,5,3,3,2,2,4,1,4,2,1,2,4,5,3,2,5,4,5,1,3,5,1,4,2,5,2,2,5,5,1,4,3,1,2,2,1,3,4,2,5,1,2,1,3,5,1,1,5,3,5,2,4,3,1,4,3,1,1,5,2,5,2,1,4,4,2,2,4,5,5,4,1,5,3,5,4,4,3,1,5,5,5,5,4,4,3,4,2,5,3,4,4,5,1,1,5,1,2,3,2,1,3,5,3,5,5,5,3,2,3,1,3,2,1,5,2,4,2,2,1,5,3,2,5,4,2,2,4,1,4,1,2,5,3,4,5,1,2,2,5,3,3,3,1,4,1,5,3,1,4,2,1,1,5,4,5,2,5,4,5,3,3,2,5,3,2,4,2,1,1,4,3,5,2,5,3,2,1,2,3,1,3,3,5,3,4,5,3,1,5,4,1,3,2,4,3,5,2,5,1,4,5,5,5,3,1,4,2,2,3,2,5,3,4,3,2,4,2,4,4,1,5,4,5,2,2,2,3,4,5,3,1,2,3,4,1,3,2,2,3,1,1,2,4,4,3,5,3,4,1,2,3,3,4,2,5,3,3,1,1,1,1,3,3,2,3,2,5,3,4,4,4,2,5,2,4,2,4,5,2,1,4,4,5,5,3,4,1,3,2,1,1,4,2,1,2,3,3,5,2,1,5,3,2,2,3,5,5,3,1,1,2,5,1,3,5,5,4,5,5,1,2,5,4,4,3,5,5,4,5,5,4,5,3,5,1,1,2,3,3,5,3,1,5,1,4,2,4,2,5,5,5,1,5,4,4,5,4,2,3,5,4,4,1,3,5,4,1,5,1,4,5,4,3,5,3,2,3,5,1,1,1,3,5,2,1,4,2,4,2,5,1,4,3,5,2,5,2,2,1,3,3,3,5,3,5,5,2,2,3,3,1,3,1,1,4,3,1,4,1,1,1,4,5,2,5,3,4,3,3,2,4,2,3,1,3,4,4,5,4,4,5,2,2,4,2,3,3,4,3,2,4,3,4,4,4,1,4,3,4,5,2,5,2,1,5,5,1,1,3,5,4,5,1,2,4,2,1,2,1,2,2,4,5,2,3,5,4,2,4,1,2,1,5,1,5,3,4,5,5,4,3,3,3,3,5,4,3,1,5,4,1,1,3,2,1,2,4,1,4,5,2,3,4,1,3,2,4,2,3,5,3,2,5,2,3,3,1,3,3,1,5,3,5,2,4,1,3,2,3,2,3,2,2,2,2,3,3,2,1,4,3,3,4,5,3,1,2,3,1,5,3,5,3,2,2,4,5,1,4,4,3,3,2,2,4,3,2,4,1,4,4,2,4,2,2,3,4,2,5,3,4,1,4,1,5,5,4,5,4,5,5,4,2,3,5,5,1,2,1,1,3,2,5,2,3,5,2,5,5,4,3,2,5,1,5,5,2,1,3,1,1,2,5,4,5,3,5,2,5,5,2,4,4,1,5,4,3,2,5,5,1,3,4,1,1,1,4,2,1,5,3,5,1,1,1,4,2,4,1,1,1,5,1,4,1,1,4,1,1,4,3,2,3,3,3,1,4,4,4,4,2,3,4,2,2,1,4,3,1,3,2,4,1,3,5,1,1,2,1,3,3,2,1,4,3,4,1,1,2,5,1,4,3,4,5,3,1,4,2,4,5,5,4,4,1,3,5,2,1,1,5,1,2,5,2,3,5,5,2,5,1,2,2,3,4,1,5,4,2,5,5,4,2,2,2,4,3,4,4,4,4,1,5,5,5,4,1,5,5,1,4,2,4,1,3,1,3,2,2,1,2,5,1,2,3,4,2,5,3,4,3,4,1,5,1,1,5,3,1,4,3,4,1,2,1,2,1,2,5,1,5,5,2,4,5,1,3,4,5,4,2,1,4,2,2,5,4,2,2,4,5,1,5,2,2,3,4,1,4,5,5,1,2,2,4,1,4,4,2,1,1,3,3,5,4,3,1,3,5,3,4,3,3,3,5,5,4,3,2,2,5,4,4,5,2,3,1,4,2,1,5,1,5,4,4,3,2,4,2,4,4,1,4,1,2,3,4,2,4,3,5,1,4,2,5,5,2,2,5,5,5,3,5,4,4,3,4,1,5,1,1,5,5,3,4,2,2,1,5,2,3,1,3,3,3,4,5,3,5,3,4,5,2,2,1,5,3,5,3,3,3,2,1,2,3,5,4,1,3,5,3,5,2,4,1,5,3,4,4,3,5,1,5,1,4,1,3,5,4,3,1,1,5,2,4,1,1,4,2,2,4,2,4,3,1,4,4,2,5,5,1,2,1,3,2,2,2,3,1,2,3,3,3,1,1,2,3,3,1,1,1,2,3,2,2,1,4,1,5,1,4,3,2,1,2,4,1,2,5,3,4,5,3,2,5,4,1,3,3,3,2,1,3,1,1,4,1,3,5,2,5,5,4,5,4,5,1,1,5,1,1,1,2,2,5,1,4,5,1,3,3,4,1,5,3,4,3,1,3,3,3,1,4,5,3,1,2,5,4,5,2,3,4,3,5,5,1,5,4,5,5,2,5,2,5,2,1,1,4,5,2,4,5,3,4,4,1,2,4,4,5,3,5,5,3,1,1,1,4,2,2,2,1,5,5,2,3,1,5,1,5,4,3,5,3,3,4,1,5,4,2,4,1,3,5,2,1,4,4,2,1,5,4,3,3,3,1,4,4,4,2,1,4,5,1,3,5,3,3,3,3,3,5,1,4,4,4,3,2,2,3,2,1,4,2,4,4,2,4,5,2,1,3,4,1,5,1,3,1,3,2,3,5,1,3,5,2,4,5,1,3,3,5,5,3,4,4,5,1,4,3,4,3,3,3,1,3,5,2,2,1,4,5,5,3,3,4,1,2,1,1,2,1,4,5,3,3,3,5,1,5,5,5,3,2,4,1,4,5,4,1,3,2,4,1,1,5,5,5,4,2,2,5,4,3,2,2,4,2,4,2,5,4,5,3,3,1,2,1,1,5,2,1,4,1,2,4,2,5,4,1,1,4,4,2,3,2,3,3,5,2,4,3,2,4,4,2,2,2,3,3,4,5,2,2,3,2,4,5,3,5,3,1,4,1,1,2,2,3,2,4,5,4,1,3,1,5,4,3,5,5,3,1,1,1,4,1,5,2,1,2,1,5,3,4,1,1,4,2,3,3,3,1,1,4,2,2,3,4,3,4,3,3,4,2,1,5,3,4,2,2,4,5,2,3,3,4,2,1,4,3,4,5,2,4,1,4,3,3,1,1,1,2,3,1,1,5,5,2,1,4,3,3,2,3,5,2,2,2,2,1,4,4,2,5,4,5,2,2,5,2,3,2,1,3,2,2,2,5,4,2,5,1,2,5,4,3,4,2,4,3,1,4,2,1,3,5,4,5,4,3,5,1,1,5,4,2,1,3,4,2,4,1,3,4,4,2,5,4,5,5,2,3,3,5,5,4,3,5,3,4,3,2,1,1,2,5,1,1,2,1,2,4,1,4,4,1,1,5,1,4,1,1,1,1,4,3,3,4,2,2,1,3,4,3,1,3,2,2,1,3,1,3,4,3,3,3,5,3,1,5,1,5,1,4,5,5,5,3,2,1,5,1,1,1,1,3,3,1,4,3,4,4,5,4,4,3,3,4,5,5,4,1,5,2,4,2,4,5,2,1,4,2,4,1,3,1,4,3,4,5,5,3,5,3,1,3,4,4,4,1,2,2,2,3,1,2,2,4,1,1,3,4,3,2,1,4,1,4,3,2,3,2,3,1,1,1,5,3,3,2,3,3,5,5,1,4,4,2,2,3,2,2,1,5,2,3,3,3,5,5,1,5,5,4,3,2,5,1,5,2,3,4,1,4,2,2,5,1,3,4,2,4,5,3,5,5,3,4,3,3,2,2,2,2,1,4,1,4,5,2,3,5,4,5,3,5,5,5,1,4,2,1,4,2,2,3,5,5,1,1,2,1,4,1,4,3,2,4,2,1,3,1,2,5,4,3,1,1,4,2,3,1,4,4,3,1,5,4,5,4,2,2,1,1,5,3,2,4,3,3,3,1,2,2,5,3,1,1,1,3,5,2,2,4,3,3,3,2,3,2,2,1,2,4,2,4,1,2,2,5,2,1,1,5,2,1,2,5,1,1,3,1,5,5,1,5,5,3,1,4,5,2,4,2,1,3,5,5,2,3,1,3,4,4,5,3,3,3,4,5,5,2,1,2,3,2,1,5,1,2,1,2,1,5,4,3,2,5,5,2,3,2,5,3,5,2,2,3,3,2,3,2,5,4,5,3,3,5,4,3,1,3,4,3,4,4,5,5,4,5,4,5,2,2,5,3,1,4,1,3,5,1,4,2,5,2,2,1,4,5,4,1,3,5,3,5,1,3,1,5,3,2,3,1,1,5,3,5,1,5,2,4,1,1,4,5,2,2,4,4,4,5,2,2,5,3,5,4,1,3,1,2,5,2,4,1,4,1,2,4,4,4,4,5,1,3,2,4,2,5,5,3,4,5,2,4,4,3,2,3,4,2,4,3,3,2,2,2,1,2,1,4,3,5,1,3,2,4,5,3,3,4,4,5,2,1,5,2,4,3,3,4,1,5,4,5,4,4,5,4,3,3,1,4,1,2,3,5,4,4,2,2,5,5,5,3,4,5,1,1,3,4,2,1,3,4,1,3,3,5,3,2,1,4,1,5,4,3,4,4,2,3,4,5,1,2,3,3,2,3,4,4,2,2,1,5,1,3,1,2,2,5,4,5,3,4,4,2,5,1,4,1,1,4,4,1,4,4,5,4,3,3,3,5,1,2,5,3,4,4,4,3,5,4,5,5,5,3,4,1,4,4,5,4,4,4,4,4,5,2,2,1,2,2,4,5,1,3,1,5,3,2,1,4,4,5,4,3,4,1,3,1,4,1,3,1,3,5,4,1,5,5,5,1,5,1,2,2,4,5,3,5,3,2,3,3,5,5,4,3,5,5,2,1,2,4,5,4,5,4,2,4,4,1,3,1,2,2,3,1,5,5,2,3,5,3,3,3,5,4,1,2,5,2,1,2,5,1,1,1,2,3,3,2,3,4,1,2,1,3,4,3,2,3,4,3,4,4,4,5,3,2,5,3,1,1,2,5,4,3,2,4,1,3,5,4,1,2,2,1,1,2,4,3,2,3,1,2,1,4,5,3,2,1,2,4,3,4,2,5,3,3,4,3,3,3,3,1,3,4,5,5,4,3,1,5,4,1,5,1,2,4,4,5,5,1,3,5,3,5,5,2,3,4,2,2,5,1,4,1,3,2,5,3,2,2,3,2,4,2,3,5,1,4,1,3,2,3,4,5,4,1,2,3,2,1,2,1,2,2,4,2,5,1,4,3,4,3,3,3,3,4,5,3,5,3,2,2,5,5,4,3,5,4,3,1,4,5,1,1,2,4,3,5,1,4,2,3,3,1,1,2,4,5,3,4,3,5,4,1,1,5,2,5,2,2,3,2,5,1,1,1,3,4,5,1,1,2,3,2,3,5,5,1,3,5,5,2,3,5,3,2,1,5,2,2,3,4,1,4,5,5,1,5,5,3,1,3,4,5,3,5,4,3,4,1,2,5,4,5,2,3,4,3,1,4,3,5,5,2,5,1,1,3,4,3,3,1,4,5,1,3,2,2,1,5,2,4,3,5,2,4,4,4,5,2,5,2,5,5,5,3,4,5,5,2,5,4,3,5,3,4,5,3,5,4,4,2,3,4,3,2,3,4,2,2,3,4,5,1,5,2,2,3,2,4,5,2,3,3,5,2,4,3,5,3,2,5,4,4,3,3,1,4,5,3,4,2,1,3,4,2,1,3,1,2,1,1,2,5,4,3,2,1,1,2,5,3,1,5,5,5,5,5,2,4,3,4,1,5,3,2,4,2,3,2,3,5,4,2,1,1,2,5,2,3,2,1,3,5,4,2,1,5,3,5,4,3,1,1,5,2,1,1,5,1,1,1,3,3,4,4,3,2,3,3,5,3,2,5,5,3,1,1,5,1,2,5,1,1,2,2,1,3,3,5,5,3,3,1,2,4,4,5,3,5,1,2,3,2,3,5,3,5,5,4,3,3,3,1,5,4,4,4,5,1,1,4,3,5,2,1,1,4,4,4,3,1,5,4,3,3,4,4,2,3,4,5,3,1,3,1,2,5,5,1,3,3,4,2,4,2,1,3,3,4,5,5,5,1,5,4,1,5,3,1,2,4,5,4,1,5,5,4,3,5,3,3,1,3,5,2,3,5,2,5,2,4,4,4,3,3,1,1,4,1,3,1,3,4,5,2,5,1,5,4,2,5,4,3,2,2,4,1,4,1,4,3,5,2,4,5,1,3,3,5,4,2,2,4,3,4,2,3,3,4,5,2,1,5,5,5,3,3,5,2,3,1,4,5,2,2,5,2,4,1,4,3,5,4,3,4,2,1,3,4,5,3,1,5,4,1,2,3,5,1,3,2,4,2,5,1,5,1,1,4,1,2,3,1,2,3,2,4,2,1,2,3,2,1,1,4,2,4,4,4,3,2,1,5,3,4,1,2,4,3,5,5,5,2,4,5,4,2,3,5,4,5,2,3,3,1,3,5,5,5,3,5,5,5,5,5,1,3,3,5,1,4,3,5,1,4,3,4,1,4,2,2,3,2,5,1,2,5,1,4,2,5,4,4,4,4,2,5,1,4,3,5,4,4,2,5,5,5,5,4,1,3,2,5,4,4,3,1,3,3,3,4,2,4,1,3,3,4,3,5,1,4,1,3,3,2,3,4,3,5,4,1,4,5,5,1,3,1,1,3,3,4,5,2,4,4,1,1,2,2,5,4,5,3,3,2,3,1,5,1,1,4,5,1,3,5,4,4,5,1,4,1,1,3,2,1,2,1,2,1,4,4,4,4,3,3,4,3,1,1,5,3,1,5,5,2,2,5,1,4,4,1,4,2,4,4,2,3,1,2,2,3,5,2,3,3,2,5,3,1,3,5,4,2,2,4,4,3,2,3,3,3,5,1,5,5,3,1,2,4,5,2,1,4,3,4,3,3,1,5,5,5,3,2,2,5,4,3,5,3,3,5,4,3,2,1,3,1,4,4,2,5,2,3,1,2,4,2,3,4,3,4,5,1,2,1,1,4,2,5,4,4,4,5,3,1,5,4,2,2,1,1,4,4,2,5,5,3,4,2,5,5,2,2,1,2,2,1,3,1,5,3,1,4,2,5,5,3,2,5,3,4,2,1,3,2,1,3,1,4,2,5,1,5,2,4,3,2,5,4,3,3,2,5,2,1,4,3,1,4,4,4,4,3,3,5,5,3,2,3,3,2,2,2,1,2,5,3,3,1,3,4,5,5,4,3,1,3,3,4,5,2,1,4,4,1,5,2,4,4,5,4,1,3,1,2,4,1,4,1,1,2,2,1,1,5,5,1,4,4,4,5,1,5,1,4,3,3,5,2,3,3,3,1,3,1,1,3,4,5,5,2,4,1,4,1,3,5,4,1,4,4,3,2,1,3,1,2,4,4,1,1,2,4,4,2,3,1,1,1,2,5,3,4,4,5,1,2,2,5,2,1,2,5,1,3,5,4,5,1,2,3,5,5,4,2,5,5,2,3,2,3,3,3,1,2,1,1,1,4,3,1,2,5,2,3,4,3,1,1,3,4,3,1,4,1,3,1,5,1,4,1,3,5,3,1,1,3,3,4,1,3,5,4,3,3,1,1,1,4,1,2,2,1,1,4,2,4,4,3,4,5,5,3,3,5,2,4,4,5,3,3,5,5,5,4,3,2,1,2,1,4,4,4,4,5,5,2,2,5,1,4,3,5,3,5,4,3,5,1,1,4,2,3,1,2,2,2,1,2,2,1,5,3,2,1,4,1,4,4,1,5,5,5,3,5,5,1,1,5,5,5,5,3,4,2,3,5,2,2,5,4,1,2,2,5,4,2,3,2,3,5,2,1,2,4,4,4,4,3,1,2,3,5,2,4,1,3,3,4,4,4,1,1,5,4,3,4,4,5,4,5,2,2,2,2,2,1,5,5,4,3,5,4,4,5,5,1,2,2,1,5,3,4,4,2,4,4,5,2,1,5,5,2,5,3,4,4,2,4,1,1,3,4,5,2,1,5,2,5,3,3,1,4,4,4,3,1,5,4,5,4,2,5,4,1,5,4,2,5,3,2,3,3,3,1,4,2,5,2,1,3,5,1,3,4,2,2,4,2,5,1,5,2,5,2,4,5,4,1,4,5,1,5,1,1,4,3,4,5,2,5,1,1,3,2,5,2,5,1,1,2,4,4,2,3,5,3,5,2,4,5,2,3,3,1,5,3,1,2,3,2,4,4,5,1,1,2,1,3,2,2,5,2,1,2,2,2,4,5,1,2,5,1,5,4,3,4,4,3,4,2,4,1,5,1,1,2,2,3,3,3,2,2,3,2,2,4,2,4,5,2,1,2,3,5,3,3,4,5,4,3,1,1,5,5,3,1,3,3,2,3,3,2,4,4,4,5,5,4,2,4,5,5,2,1,3,4,2,3,5,4,5,2,4,3,5,1,4,3,4,2,4,5,2,1,5,3,4,5,3,4,5,1,1,2,4,4,4,5,5,2,2,5,2,3,5,5,1,3,5,2,4,1,5,3,2,3,2,5,4,5,5,4,3,3,2,2,2,3,1,2,4,3,2,2,5,2,3,3,1,1,2,5,3,2,5,2,4,5,5,2,3,2,4,3,5,1,5,5,5,3,3,4,3,5,5,3,5,3,2,2,4,2,5,3,5,1,3,1,2,3,3,3,2,1,1,4,2,3,4,5,4,1,5,1,3,1,1,3,4,4,3,5,3,5,2,4,2,1,2,4,3,4,1,2,1,4,1,1,3,4,4,5,1,1,1,3,4,2,1,2,5,1,4,3,4,1,5,1,5,4,3,1,4,2,5,1,4,3,5,4,4,1,1,1,4,3,1,3,4,4,4,5,1,1,1,5,3,5,2,3,1,1,1,3,4,2,1,5,4,1,4,4,1,4,1,5,2,2,3,5,4,4,5,2,1,1,1,3,4,5,4,5,5,3,4,2,2,5,3,2,3,2,4,3,3,5,4,5,1,1,3,4,4,5,5,4,4,1,3,4,4,2,2,3,4,5,5,3,1,5,4,2,3,1,3,1,2,2,3,2,1,3,1,3,1,5,5,5,4,2,1,2,3,5,4,2,2,3,1,3,5,4,5,1,3,2,1,5,3,3,1,2,3,2,2,4,1,2,3,4,1,2,5,5,5,3,2,1,2,3,4,4,2,3,4,1,2,1,2,1,4,4,1,4,1,5,1,4,2,2,5,5,3,2,4,1,3,5,4,4,3,1,3,1,4,3,2,3,5,5,3,2,2,4,5,1,1,5,3,4,5,4,5,5,2,3,1,1,5,2,2,1,2,5,2,2,5,4,5,1,3,4,3,2,3,3,1,4,2,4,4,4,4,5,3,1,5,3,3,1,1,3,5,1,4,4,2,5,1,5,3,1,3,3,1,5,3,3,5,5,3,2,5,4,1,1,1,1,5,1,5,3,1,1,5,5,3,2,4,4,1,5,1,3,3,3,4,5,2,3,5,4,4,5,2,5,1,4,1,4,2,2,4,3,2,4,5,3,1,4,3,3,5,2,5,3,2,1,3,4,1,5,5,3,3,1,4,1,5,2,5,2,1,1,2,1,4,5,3,3,1,2,5,1,4,5,3,5,5,3,1,2,3,2,5,1,3,2,5,4,2,2,5,5,2,5,4,2,1,3,3,3,1,5,5,5,4,4,2,3,5,3,5,2,4,3,2,2,5,3,4,3,4,1,4,5,2,1,5,3,1,5,4,4,3,3,4,5,3,3,3,4,4,3,3,4,2,1,1,5,2,2,1,3,3,5,5,3,4,5,4,4,1,4,4,3,4,5,3,3,3,2,4,2,2,5,5,1,3,3,5,3,1,3,1,5,1,1,4,5,4,2,5,5,1,4,2,2,4,4,1,4,4,4,1,3,5,5,4,3,2,2,1,4,2,2,5,3,5,1,1,4,3,5,2,2,2,5,4,2,2,3,5,3,2,3,4,4,5,4,5,5,3,5,2,2,4,5,2,4,2,1,4,2,5,3,3,2,4,3,1,3,2,3,3,2,4,3,3,1,1,2,3,1,4,3,2,4,2,2,1,5,1,1,2,5,1,5,1,2,3,5,1,3,2,1,1,4,2,4,1,5,1,4,5,5,4,4,3,4,4,5,3,4,3,1,2,5,1,2,5,2,3,3,1,5,1,2,4,3,2,1,2,2,4,2,2,2,4,3,5,4,4,2,5,1,3,3,2,2,5,2,5,2,2,4,1,4,2,5,1,2,5,2,3,4,3,2,4,5,5,4,5,4,3,3,4,4,1,3,3,2,5,3,3,1,4,3,2,5,3,3,5,4,1,4,1,5,5,5,5,2,1,5,4,2,5,4,5,3,1,2,5,3,2,2,5,2,1,5,4,1,2,2,3,2,3,4,2,4,3,1,2,1,1,2,3,2,2,2,4,2,1,5,4,1,5,4,2,3,3,5,1,5,3,4,4,4,2,3,1,3,1,2,3,2,4,5,4,5,3,5,3,2,1,5,4,3,1,4,5,5,1,2,2,4,3,5,4,2,3,5,1,3,5,1,4,1,3,4,3,5,4,4,4,3,4,1,2,4,1,4,1,5,5,1,3,5,3,3,2,3,2,5,2,4,5,1,1,5,3,4,3,2,2,2,5,2,4,2,4,4,4,3,5,1,1,1,3,4,5,5,4,1,5,3,1,2,1,2,1,3,4,4,1,3,4,4,1,2,2,3,5,5,4,3,1,2,3,4,4,1,5,5,5,4,1,1,4,1,5,2,2,1,5,2,1,4,5,2,1,5,1,5,2,2,1,4,5,1,1,4,1,3,2,4,5,5,4,1,5,3,4,4,3,1,5,3,4,4,2,2,2,5,2,3,3,5,3,2,2,1,5,3,1,5,5,1,4,5,5,3,3,2,2,3,2,4,2,5,4,3,2,5,5,4,4,2,4,3,1,2,4,3,1,4,1,5,2,5,2,4,3,1,2,4,1,3,1,3,1,4,5,4,5,4,5,5,2,1,5,2,2,3,4,5,1,3,5,4,4,2,3,5,3,2,2,5,1,4,2,3,3,5,1,3,1,5,2,5,3,3,3,4,3,3,4,1,4,3,2,3,3,1,5,1,4,5,3,1,3,1,5,5,2,2,1,2,1,1,1,5,1,1,3,5,2,3,1,3,4,5,5,2,1,3,2,3,1,3,4,2,2,2,4,3,5,2,2,3,3,4,1,1,2,3,5,5,3,4,3,2,5,3,1,1,1,2,4,4,2,5,4,5,1,2,3,1,3,3,4,1,3,3,1,4,3,4,4,3,1,4,4,1,3,2,4,3,5,3,5,5,1,3,5,5,2,3,5,4,1,3,2,1,3,5,2,1,4,5,3,2,1,2,1,4,3,1,5,2,1,2,3,2,5,1,4,3,2,2,5,1,1,3,4,5,5,1,4,4,4,4,4,2,4,2,2,3,4,4,4,1,4,3,3,2,4,1,1,4,2,3,2,4,1,2,4,3,4,5,1,1,3,1,3,1,2,4,5,2,3,2,4,2,3,3,2,3,2,2,3,3,4,1,2,1,1,4,1,5,4,1,5,5,4,1,1,2,4,3,4,5,3,1,1,5,1,3,5,1,2,3,2,5,3,2,5,4,4,3,1,2,5,5,1,2,4,2,5,4,1,4,2,2,4,5,1,1,5,5,4,3,1,3,5,4,5,2,5,4,1,2,2,3,2,4,5,2,5,5,1,3,2,2,1,1,3,4,2,2,2,3,1,3,2,4,2,1,5,1,1,2,5,3,4,5,5,1,3,3,5,4,5,3,5,1,2,4,1,2,4,5,3,3,1,1,1,2,5,3,3,4,3,4,4,5,2,2,2,1,2,2,5,3,3,2,3,5,5,2,1,3,5,1,4,5,4,2,4,3,2,3,2,2,3,3,3,2,3,1,1,2,4,3,3,5,4,1,4,4,2,4,5,3,2,5,1,3,1,5,3,5,3,1,3,1,5,1,4,4,4,4,5,3,4,4,5,4,3,5,2,4,1,3,2,1,5,1,5,4,5,2,1,1,3,4,4,2,5,5,5,1,3,2,5,2,5,4,3,5,5,3,1,5,3,4,2,3,4,1,1,1,3,4,1,1,4,4,3,3,5,1,2,4,5,4,5,3,5,4,3,5,4,5,2,1,1,3,5,2,4,2,3,3,1,2,5,1,2,3,5,1,4,3,4,4,1,2,1,5,1,5,4,4,1,1,5,4,4,1,1,4,5,2,2,3,4,5,3,2,1,3,1,3,4,5,5,2,1,2,3,4,1,1,1,1,1,4,1,1,3,1,2,5,2,3,5,5,5,4,3,4,5,2,2,5,1,2,4,4,2,2,3,1,2,5,2,5,4,1,5,3,4,4,1,1,1,5,2,5,2,2,4,5,4,1,5,5,2,1,1,1,3,3,2,5,5,5,1,5,5,4,1,2,5,4,5,3,1,5,2,5,1,1,4,3,4,2,3,3,1,1,3,5,1,5,2,5,1,2,1,1,5,4,3,3,3,3,2,3,2,4,5,4,1,1,5,1,2,1,2,1,3,2,5,4,3,1,4,4,2,4,4,4,5,1,2,3,3,5,3,1,3,2,1,5,5,2,1,2,4,2,1,1,2,1,5,3,2,3,2,5,2,1,5,3,2,1,2,2,2,5,2,2,4,3,2,3,4,5,4,1,2,3,4,5,2,5,2,5,3,3,1,1,2,3,1,2,5,3,4,2,3,2,5,3,2,5,2,4,2,3,3,5,1,1,1,1,2,2,2,4,2,4,4,2,5,3,2,5,2,4,1,1,4,2,5,3,3,2,2,4,3,4,3,2,3,3,2,3,4,3,1,5,1,1,4,4,1,3,5,2,5,3,4,2,4,4,1,2,3,2,4,2,5,5,1,3,5,1,4,1,1,4,3,2,2,2,1,4,1,4,2,2,5,1,1,2,1,5,2,1,4,2,3,3,5,2,5,1,2,1,3,5,4,1,1,1,1,1,1,2,3,3,5,2,4,3,5,1,1,3,3,3,4,4,1,3,4,4,5,4,1,2,5,2,4,2,5,5,2,3,5,2,3,3,5,5,1,3,2,2,3,3,2,5,5,3,4,3,3,4,4,2,2,1,4,5,4,1,2,1,4,2,2,1,2,1,5,1,1,1,1,5,4,2,5,2,2,5,5,5,4,4,1,3,3,4,4,4,4,2,1,1,3,3,5,2,3,2,2,4,1,4,3,4,1,2,5,5,4,3,4,1,3,2,5,5,5,5,1,1,3,2,2,3,3,4,5,4,2,2,3,1,5,1,4,4,4,4,1,3,1,2,4,5,2,3,1,1,2,4,5,1,4,1,4,3,2,4,2,4,2,4,2,4,4,1,4,1,2,1,1,5,2,3,5,3,5,4,2,3,1,4,5,1,3,4,5,5,3,5,4,3,3,1,4,3,3,1,5,1,5,4,5,5,2,3,4,1,1,3,5,3,3,5,3,1,1,1,4,1,4,3,4,3,2,1,1,5,5,5,2,3,2,4,5,5,4,5,3,5,1,5,1,1,2,3,3,5,4,1,1,2,1,2,3,3,5,4,2,5,3,5,5,4,5,5,5,2,5,4,1,3,5,1,3,4,1,3,2,3,3,5,5,4,4,3,2,3,2,5,3,1,3,1,4,2,5,4,2,2,4,2,5,3,5,2,1,3,3,5,5,1,5,4,5,2,2,4,2,1,3,4,2,5,5,3,3,4,4,2,2,3,5,4,2,3,4,1,1,3,5,2,2,4,4,1,3,1,1,3,2,3,4,5,3,1,5,2,2,4,2,2,3,2,3,2,3,3,5,5,3,1,1,4,1,2,5,5,5,3,3,1,3,1,4,5,5,5,2,2,2,5,1,1,4,3,2,4,3,3,4,5,5,5,2,1,2,1,3,3,1,5,4,5,4,5,5,2,3,5,5,3,3,5,3,2,2,4,3,2,1,1,1,5,3,3,5,3,4,5,3,2,1,5,4,5,2,1,1,5,1,2,2,4,5,4,1,4,3,2,3,5,5,5,1,1,4,5,2,4,1,2,5,1,3,2,3,3,5,1,3,1,3,5,5,1,5,2,2,5,5,5,1,1,5,4,3,5,3,5,4,4,3,4,5,1,5,4,5,1,4,5,5,4,4,5,3,1,5,2,3,1,1,5,5,1,1,3,1,1,5,2,3,2,3,1,4,1,2,2,5,1,4,4,5,2,1,4,5,2,1,2,5,2,4,3,4,2,1,1,1,3,3,5,5,4,1,3,2,2,4,4,2,1,1,3,2,2,4,5,5,4,3,5,1,2,3,1,4,3,2,5,5,3,4,2,3,3,1,1,1,4,3,3,5,1,4,2,5,5,4,4,4,3,2,5,1,5,5,2,4,5,5,2,4,4,5,2,1,3,5,4,1,4,3,2,1,5,3,2,1,5,1,4,1,4,2,2,1,4,2,1,4,3,2,3,3,5,3,3,4,5,4,1,2,4,1,5,3,5,2,2,3,2,4,2,2,2,1,5,2,5,5,1,5,2,4,2,5,2,4,5,1,3,1,5,2,4,4,2,5,1,1,1,1,1,3,4,5,4,1,3,2,2,1,5,2,4,3,1,5,1,2,1,3,1,3,1,4,5,5,3,2,2,3,4,1,5,1,4,5,3,1,5,5,2,5,5,4,1,2,1,1,3,2,5,5,3,2,4,1,1,1,3,5,3,1,2,5,1,4,3,5,2,4,2,4,4,1,3,2,5,4,1,2,2,4,5,1,1,2,4,5,5,1,4,4,4,2,5,5,4,3,3,5,3,3,3,1,2,2,4,5,2,5,2,3,2,4,2,2,5,2,4,3,1,1,5,3,1,5,4,3,4,5,1,3,1,1,5,4,1,2,4,5,1,1,4,2,5,5,4,3,1,5,4,3,4,4,1,3,1,4,1,4,4,5,2,5,5,5,1,4,3,1,3,3,4,5,3,1,2,3,1,5,1,2,1,5,1,1,5,2,5,1,4,5,5,2,3,1,1,2,5,2,5,4,4,1,1,3,1,1,1,4,1,4,4,2,3,3,5,1,4,4,2,4,5,2,2,2,4,2,5,5,4,5,4,5,4,4,2,1,5,3,4,4,3,4,5,2,2,2,4,4,5,4,2,1,2,3,3,2,4,2,5,2,4,1,3,1,1,4,2,4,4,3,3,1,1,3,2,1,1,3,3,1,3,1,4,2,1,5,3,5,1,5,5,1,3,1,3,4,5,2,1,3,5,3,5,4,5,4,4,1,1,1,1,3,3,1,3,2,4,3,2,4,4,1,2,5,3,1,5,2,1,5,4,1,3,4,4,4,5,3,2,5,1,2,1,5,2,1,4,4,4,5,5,3,3,1,1,3,3,3,2,1,2,3,2,3,5,4,3,4,1,4,3,2,1,2,4,1,2,5,5,4,2,3,2,5,5,4,4,2,1,5,3,3,5,5,3,1,2,3,5,5,1,5,1,5,4,5,5,5,1,5,4,3,2,4,4,4,1,4,4,1,1,2,3,4,5,1,5,4,3,1,4,2,3,5,2,4,4,2,1,5,3,5,1,1,3,2,4,3,4,2,2,5,2,1,4,1,1,4,2,2,4,5,2,1,5,3,3,5,1,5,5,2,4,4,2,2,5,2,3,2,1,2,2,2,1,5,2,3,1,4,3,1,3,3,1,3,3,1,3,1,5,5,3,2,5,5,5,4,4,1,3,3,5,1,5,4,2,1,3,1,1,4,5,4,4,2,5,1,5,3,4,1,3,2,3,2,5,5,5,4,2,5,5,2,5,3,3,4,3,4,4,3,3,2,3,1,1,3,1,3,1,4,1,5,3,5,1,2,4,1,5,4,3,3,1,4,4,3,3,1,4,4,5,5,2,3,2,2,2,5,5,1,4,3,5,3,3,2,5,5,1,2,4,5,4,2,1,3,4,1,5,1,1,4,1,4,2,4,2,5,2,1,2,4,3,3,1,2,2,1,5,5,2,4,3,3,3,2,3,5,2,2,4,2,1,2,2,3,4,4,1,4,1,2,4,3,4,1,1,3,2,2,3,2,4,5,1,1,4,4,1,4,1,3,2,1,4,3,4,4,1,1,1,2,2,4,3,1,4,2,1,5,4,1,3,5,3,5,4,5,4,4,3,4,4,5,2,2,4,1,3,5,5,2,1,2,1,5,3,5,4,3,1,2,3,2,1,4,3,5,5,2,5,2,2,2,2,3,4,1,5,3,2,5,3,3,3,4,2,5,5,5,4,4,5,3,1,1,4,3,3,3,5,2,1,4,2,1,1,1,3,3,1,1,5,4,4,1,3,4,1,5,3,4,4,2,4,5,5,4,2,1,4,3,3,1,2,1,3,1,3,3,2,5,5,5,4,2,3,2,5,2,4,5,1,3,2,5,5,5,3,5,3,1,5,1,5,5,4,4,2,4,2,4,3,5,4,2,1,2,4,1,1,2,3,1,3,4,4,5,3,4,1,4,1,5,5,4,1,4,4,4,5,4,2,1,2,5,1,4,1,1,4,4,4,1,5,3,5,3,4,2,3,1,3,1,3,2,2,4,1,4,5,2,1,4,5,4,5,4,3,1,2,4,4,1,1,2,5,3,5,3,3,4,4,3,5,2,1,5,5,5,2,1,1,1,3,2,4,3,5,4,3,4,5,5,2,2,4,4,4,3,5,4,1,4,1,3,1,4,1,3,1,4,1,5,2,2,3,1,2,1,1,2,2,5,4,2,4,3,5,3,3,3,2,2,2,2,2,3,5,5,3,5,2,1,5,2,4,2,3,4,2,5,1,4,1,1,5,3,4,3,3,1,3,3,4,1,1,2,5,1,5,1,3,2,1,1,1,2,3,4,5,5,3,2,2,2,5,3,4,2,3,3,1,3,2,5,3,1,3,2,3,4,2,4,2,5,3,5,1,3,1,4,1,1,3,5,1,5,2,3,2,3,1,2,4,3,3,3,2,1,5,3,4,1,4,4,3,5,5,5,4,2,4,4,5,5,4,1,1,4,2,4,3,4,4,5,5,3,1,1,3,2,4,1,2,3,5,4,4,4,1,3,5,4,1,2,5,2,2,3,3,3,1,1,2,1,3,4,5,2,4,1,5,1,2,2,4,2,4,3,5,3,3,1,4,1,5,3,1,2,4,3,5,2,2,1,3,1,2,4,1,4,1,5,4,4,4,5,1,3,4,5,4,3,5,5,2,2,5,4,4,2,5,5,5,4,4,1,2,4,4,2,4,4,4,5,4,2,1,1,2,5,3,5,3,1,4,4,1,3,4,1,4,3,2,4,2,4,5,1,4,1,3,3,5,1,5,2,4,2,1,2,3,3,3,3,5,2,3,5,3,1,3,3,2,4,2,3,5,1,5,5,3,4,1,4,4,1,4,4,4,5,4,1,4,1,5,3,2,2,1,2,1,3,4,2,1,4,2,4,4,5,1,4,2,5,1,1,2,2,3,4,3,5,2,5,5,3,5,1,5,5,4,2,4,4,1,5,3,2,2,1,5,5,4,4,5,4,3,1,2,4,4,1,1,3,5,1,5,1,5,4,4,5,1,2,3,3,4,3,1,3,5,3,3,2,2,3,5,2,2,3,2,1,1,4,4,2,3,2,2,3,5,1,4,4,1,1,2,3,4,5,3,2,4,3,3,4,2,5,4,1,5,2,5,3,4,4,5,2,4,5,4,4,4,5,2,3,5,3,3,3,5,2,1,3,5,5,1,4,5,2,3,4,5,5,1,2,3,5,1,4,1,2,2,3,3,1,5,5,4,3,3,3,4,4,2,5,5,2,2,2,1,2,3,3,2,3,3,4,5,2,4,5,5,2,5,1,4,4,1,4,1,3,1,5,4,4,3,1,5,3,2,1,4,5,4,1,1,2,5,1,5,4,2,1,2,4,2,2,4,4,4,3,3,3,2,3,2,4,1,4,3,3,1,2,2,3,4,3,2,5,2,2,4,2,1,2,4,2,2,5,3,1,3,2,5,5,2,2,5,3,2,2,2,4,4,4,3,3,2,1,5,4,4,3,4,4,3,5,2,1,2,2,1,3,3,3,3,5,5,4,5,4,2,2,4,4,5,1,4,3,5,3,4,2,4,5,5,1,1,5,5,3,4,4,2,5,4,1,2,1,2,4,1,4,4,3,1,2,4,3,1,4,1,5,1,3,3,2,4,4,5,2,5,2,2,4,5,4,3,4,1,2,4,1,1,2,5,1,4,1,3,1,3,4,2,1,1,5,2,5,2,3,5,4,5,5,3,5,4,4,1,1,1,4,5,5,3,4,2,5,4,5,2,1,1,5,4,4,4,1,3,3,4,5,1,3,3,1,4,1,2,3,3,5,2,2,3,5,3,3,1,1,1,2,1,2,1,5,2,3,3,3,3,4,2,3,4,2,2,4,4,3,3,4,4,4,2,2,3,3,3,2,3,2,3,3,3,5,1,1,1,1,5,4,1,2,4,1,5,5,3,1,3,2,3,1,3,2,2,3,5,1,5,1,5,2,3,5,5,3,1,3,2,1,2,5,5,2,2,3,3,2,5,3,4,2,1,3,5,4,3,1,4,4,3,3,2,2,2,5,2,2,4,3,4,2,1,4,5,5,5,3,4,2,2,3,1,2,5,3,2,4,3,3,5,2,1,3,5,2,5,3,4,2,5,5,2,2,1,2,5,4,4,3,2,5,5,1,3,3,3,5,3,4,5,5,4,3,3,4,4,5,4,5,2,4,5,2,2,4,3,4,4,3,4,2,3,3,2,1,1,5,4,1,2,2,3,5,3,5,4,1,1,2,1,2,1,1,2,3,3,5,5,1,4,3,5,1,1,5,5,5,1,2,2,4,2,3,5,4,1,4,4,1,4,4,5,3,2,2,4,4,3,4,1,3,4,5,2,3,4,4,4,5,4,3,4,1,5,5,5,4,4,2,4,3,2,5,4,4,5,5,1,1,5,4,4,4,3,4,5,3,1,2,1,2,4,4,2,5,1,2,3,3,3,5,4,1,5,2,3,2,1,5,2,5,3,1,3,2,4,2,3,1,3,2,1,4,3,3,1,2,2,3,2,2,5,5,3,1,4,1,3,4,4,1,3,1,3,3,4,1,1,5,1,2,5,2,5,2,3,3,4,5,2,3,1,1,2,5,3,2,2,1,1,1,1,4,4,2,4,2,5,4,3,3,2,1,3,4,1,5,5,5,4,5,5,3,2,2,1,5,1,4,3,1,1,3,3,2,2,3,1,3,4,3,2,5,4,4,2,3,4,3,4,2,3,1,4,3,3,5,1,3,3,5,5,5,2,2,1,1,4,4,5,1,1,3,5,2,2,1,4,3,4,4,5,2,2,5,4,4,4,1,1,3,4,4,3,2,4,3,4,3,5,5,5,3,4,2,4,4,5,3,5,3,5,5,2,4,1,3,1,2,3,5,1,4,1,2,1,1,4,5,1,5,4,2,1,3,2,5,3,1,3,1,3,3,5,3,5,4,4,1,2,4,5,4,5,5,3,3,4,3,1,1,3,4,3,2,5,2,1,3,4,1,3,1,5,1,1,5,3,5,4,3,5,4,1,3,3,5,1,4,1,2,4,5,3,3,2,4,5,2,4,1,2,4,5,1,2,5,2,4,3,2,5,4,4,1,2,2,2,2,1,4,2,4,5,1,1,4,5,3,1,2,3,3,4,3,5,3,2,1,1,4,2,5,4,4,4,4,5,4,2,3,1,2,5,3,2,3,3,3,2,5,3,2,5,3,3,4,5,2,5,4,4,4,1,3,2,4,3,3,5,3,4,3,4,4,3,4,1,4,1,3,5,4,1,5,2,2,5,2,2,3,1,5,4,1,4,4,2,5,1,2,5,4,5,2,3,1,4,1,2,4,1,1,4,5,2,3,2,5,1,5,1,5,5,1,3,1,4,5,2,3,5,5,4,1,3,2,5,1,1,4,1,2,4,2,4,2,5,3,1,3,2,3,1,3,5,4,1,2,5,4,5,5,5,5,4,1,2,4,2,3,3,3,2,5,1,4,3,4,3,4,2,3,1,2,2,5,2,5,1,3,3,4,4,2,1,3,3,2,5,3,2,3,5,3,4,4,3,2,3,4,5,1,4,3,2,2,4,4,2,2,5,1,5,5,1,4,3,5,4,2,4,4,1,5,4,4,1,4,5,1,2,1,1,1,3,2,2,2,4,5,1,4,1,2,5,3,2,5,4,2,4,5,4,3,2,2,5,1,3,5,2,5,2,3,4,3,1,5,5,2,5,2,2,1,4,1,3,4,4,2,3,5,1,4,1,3,4,5,3,5,2,2,4,1,2,1,3,4,3,3,4,4,1,5,4,3,2,2,2,3,4,4,4,1,1,1,4,5,3,2,3,5,2,3,3,3,2,3,4,3,4,2,2,3,5,4,1,3,5,3,3,3,1,4,2,3,2,2,1,3,2,4,2,5,5,3,2,3,4,2,1,2,1,4,3,2,2,4,5,1,5,1,3,4,2,2,5,1,4,2,1,5,3,1,1,1,1,1,2,3,3,1,2,3,4,1,3,4,1,3,2,2,1,5,1,5,2,3,4,4,1,4,5,3,3,4,5,4,4,4,2,3,1,5,4,5,2,2,5,5,4,3,5,5,1,4,4,1,1,5,1,3,1,5,2,2,1,4,5,1,2,2,5,5,4,5,3,3,3,5,4,5,2,5,1,1,2,5,5,4,5,3,3,2,3,1,5,2,1,2,4,3,2,3,5,5,1,5,4,4,4,4,4,4,5,1,5,1,4,2,5,3,2,3,1,2,4,2,3,4,2,2,5,5,3,2,2,3,4,3,2,4,2,3,4,1,4,4,5,4,4,5,4,3,1,5,5,2,4,5,3,3,4,1,3,4,3,4,2,5,5,5,2,1,4,2,3,5,3,5,5,1,3,2,5,4,4,4,3,5,3,3,4,4,3,1,4,5,3,3,5,4,5,3,1,2,2,4,5,1,2,4,4,5,4,1,3,2,3,5,2,1,5,2,5,3,1,1,3,3,4,4,5,3,2,2,1,4,5,2,2,4,2,4,4,4,4,5,2,2,3,4,4,3,5,1,1,3,1,3,1,2,3,2,2,5,3,4,2,2,2,1,1,3,4,5,5,5,1,4,5,5,1,5,3,5,3,2,1,2,1,1,3,4,4,4,1,5,3,5,5,5,1,3,1,4,5,5,2,5,2,1,4,2,4,1,2,4,5,1,1,1,1,3,1,2,3,5,3,5,1,4,4,3,4,2,3,1,1,2,3,4,5,1,2,2,5,5,2,1,3,4,1,5,5,3,1,3,1,3,4,5,2,2,4,2,3,3,4,2,4,3,5,4,2,3,1,5,4,1,3,3,4,4,2,3,3,2,1,4,1,2,5,3,1,3,2,1,4,3,5,3,1,4,2,2,4,2,1,5,4,4,2,5,5,2,3,2,1,4,1,2,2,1,5,2,1,2,2,4,2,5,4,1,3,1,3,1,5,1,1,5,1,3,1,5,4,1,5,5,5,3,5,2,2,4,3,3,1,5,5,1,2,5,4,5,2,1,1,5,4,3,5,1,4,1,1,3,5,1,3,1,1,3,1,1,5,5,5,3,4,5,4,5,3,5,5,3,5,4,1,3,2,3,4,3,2,4,1,1,4,3,2,5,2,4,5,2,3,3,4,3,4,4,4,3,5,1,4,3,4,1,1,5,2,2,1,3,3,3,5,3,2,2,5,5,2,5,4,2,4,3,4,1,2,1,5,4,4,5,1,5,1,4,1,1,5,3,3,5,2,3,3,2,1,5,3,2,3,4,2,1,4,1,3,2,3,1,4,2,2,2,2,4,5,1,4,4,2,2,3,2,2,5,2,4,2,5,4,4,3,3,3,2,3,5,3,2,2,3,5,4,4,4,3,2,3,2,2,4,3,1,1,3,3,3,3,1,5,2,5,1,1,4,1,5,1,1,2,3,1,3,2,1,1,5,2,5,1,2,4,5,4,1,3,3,4,4,4,4,3,5,2,4,3,3,2,4,5,3,5,1,3,1,4,2,1,2,2,3,4,4,3,4,3,1,2,4,2,3,5,3,3,2,4,2,1,1,2,1,5,1,5,4,1,5,1,4,1,4,1,2,2,3,3,2,5,2,2,4,1,5,4,4,3,3,5,5,3,4,3,2,1,3,4,3,5,5,2,3,2,5,4,5,3,4,5,1,2,1,5,4,1,4,2,3,5,3,1,3,5,4,5,3,3,2,1,3,3,2,4,2,2,2,1,2,1,4,1,5,1,5,1,2,4,3,4,4,5,3,2,3,4,5,3,3,5,3,1,2,2,3,1,5,2,1,4,5,1,4,2,4,3,1,4,1,3,4,2,4,4,3,4,2,5,2,5,4,4,2,4,4,4,4,3,3,2,4,5,2,4,5,3,5,1,3,5,4,5,3,1,4,4,1,4,5,1,5,4,4,1,3,2,4,5,4,2,5,4,4,5,3,4,4,1,1,3,5,4,5,5,3,1,3,5,3,1,2,1,1,5,1,3,5,3,5,2,3,2,5,1,5,5,4,3,4,3,4,1,3,1,5,5,4,2,4,3,4,3,3,3,2,3,3,2,3,2,2,1,3,4,5,1,3,2,1,4,1,3,1,5,3,4,1,5,1,2,2,2,1,2,1,1,4,4,5,2,2,3,1,1,4,2,4,2,5,5,3,4,2,3,4,1,3,4,4,5,1,3,3,3,4,2,5,3,5,5,3,5,4,2,5,4,1,1,1,5,1,1,2,2,2,4,1,1,5,2,2,4,4,4,2,5,5,2,2,2,2,3,3,4,3,2,3,1,5,5,4,1,4,3,4,1,3,4,5,2,5,5,5,4,3,4,2,4,2,1,4,3,1,4,5,3,2,2,2,1,3,2,2,5,1,4,5,3,5,5,1,2,2,4,4,2,2,1,1,2,4,4,3,4,2,4,1,2,1,4,2,1,3,3,5,1,2,1,5,3,2,4,2,1,1,4,1,3,5,5,5,3,5,4,1,5,1,2,1,3,3,3,2,5,2,5,3,2,5,5,4,1,4,3,1,5,3,3,3,1,1,3,1,3,5,3,5,2,2,1,5,3,1,3,1,3,4,4,1,4,1,3,1,4,1,4,1,3,4,5,5,1,3,5,3,5,1,3,5,5,3,2,4,2,4,1,5,4,3,4,3,3,4,1,5,5,5,2,2,5,1,5,3,1,4,2,1,3,1,4,4,2,1,1,4,4,1,4,5,2,4,5,4,2,3,4,4,4,3,2,1,3,2,3,5,1,3,5,5,4,5,2,3,3,1,5,4,1,5,4,1,5,5,2,4,4,3,1,1,3,3,5,1,2,3,2,4,5,4,4,2,2,2,3,4,1,4,2,3,4,5,2,1,1,4,2,4,2,5,2,1,4,4,4,3,1,3,3,1,3,4,2,2,4,2,3,5,2,1,3,4,2,4,1,1,1,1,5,3,3,4,3,5,2,3,2,5,2,3,2,1,3,2,3,3,5,3,5,3,1,5,3,5,1,1,2,1,1,2,2,5,5,1,4,5,4,5,4,3,5,2,1,5,2,2,1,1,1,3,5,3,4,5,4,2,3,4,1,4,1,5,2,3,1,5,5,1,1,3,4,1,2,4,1,3,5,4,5,4,3,1,4,5,1,1,1,1,3,2,5,1,1,4,4,1,3,4,5,5,3,3,4,1,5,4,5,5,5,3,4,5,4,2,3,1,3,1,1,5,2,1,4,1,3,4,1,3,4,4,2,1,1,2,1,1,4,2,1,3,1,1,1,1,5,4,2,3,4,1,4,1,2,2,4,5,1,4,4,5,3,3,3,1,2,4,1,3,5,2,1,4,4,4,4,1,3,2,1,4,4,4,3,1,1,4,5,2,3,4,3,1,3,5,1,1,4,1,5,1,3,5,5,5,4,5,2,5,5,5,2,2,5,5,1,1,5,2,3,1,4,3,1,5,5,2,5,4,4,5,1,5,3,3,3,2,2,4,4,4,4,2,3,2,5,2,3,2,4,1,3,2,5,3,3,2,2,3,3,4,5,5,2,2,3,1,5,4,1,3,4,3,4,2,3,5,5,3,3,1,5,2,3,4,2,4,1,3,1,2,2,3,4,4,3,3,3,3,5,4,3,1,3,2,3,4,4,4,2,3,5,1,1,3,2,5,1,1,3,2,3,3,5,4,1,5,1,1,5,5,4,4,2,1,5,4,3,5,5,3,5,5,3,5,1,4,1,2,1,4,1,5,4,5,3,4,5,3,1,4,4,2,5,5,4,1,3,2,3,4,3,5,2,2,3,1,1,5,3,5,1,4,5,5,1,4,5,5,5,2,4,3,3,2,2,1,4,3,1,4,4,3,1,4,5,5,1,1,4,5,2,5,2,3,2,1,4,5,2,2,5,3,2,4,2,1,4,3,4,5,1,5,1,5,2,5,1,3,3,1,2,5,5,3,4,4,3,5,2,3,1,3,5,5,3,3,1,3,1,2,1,2,2,5,3,1,2,4,4,1,2,1,5,5,1,4,5,4,5,2,2,3,4,4,2,2,3,3,2,5,4,3,4,4,2,5,3,2,5,1,5,1,2,2,3,5,2,4,1,3,2,2,4,5,2,5,4,5,2,5,4,4,4,1,4,3,4,4,2,2,2,4,2,2,5,5,2,5,5,2,1,2,4,5,3,5,4,3,2,4,1,2,5,2,2,2,2,2,4,3,3,5,2,4,2,3,1,5,5,3,1,1,2,5,1,1,3,5,4,3,5,1,5,5,4,4,5,5,4,4,3,3,4,5,2,3,3,2,2,1,2,3,4,3,5,2,3,4,2,2,5,5,1,3,4,1,1,4,4,1,3,4,1,4,5,5,5,4,2,5,5,2,4,5,1,5,1,3,4,2,5,3,2,4,1,1,3,4,5,3,1,5,4,5,4,1,5,3,3,1,5,1,3,5,3,4,4,4,3,1,1,5,1,4,2,2,5,3,1,3,3,1,2,3,1,3,3,1,2,3,5,5,1,5,2,5,2,4,2,4,3,3,5,2,5,5,3,5,5,4,1,5,4,5,4,4,2,5,4,3,1,5,4,5,5,1,4,2,3,3,2,2,2,1,4,1,2,2,5,4,1,2,4,2,5,2,3,2,3,4,1,1,4,5,1,3,3,1,3,2,2,1,3,5,3,2,2,5,1,4,1,3,4,3,5,1,2,3,2,2,3,3,1,2,3,3,2,4,4,5,4,2,2,2,1,5,2,5,5,4,5,5,3,3,1,4,4,5,2,5,3,2,2,3,3,5,5,1,1,2,4,5,4,3,3,3,4,2,2,1,3,3,1,4,3,2,4,4,5,4,2,2,5,5,3,5,2,2,2,4,5,2,1,2,4,5,2,5,1,2,5,4,1,4,4,2,1,1,4,3,5,5,4,2,5,5,1,1,1,1,2,3,3,4,1,3,3,5,4,1,2,2,1,4,4,3,4,5,5,4,1,1,4,4,5,4,4,3,1,5,3,3,2,4,3,3,4,2,4,4,3,4,2,1,4,1,1,1,5,4,5,4,1,1,1,4,1,2,5,5,2,3,3,2,5,5,5,5,5,4,4,4,4,4,5,2,1,4,5,1,3,3,4,1,3,2,5,3,4,2,3,3,5,5,4,3,2,5,1,1,4,1,2,2,2,4,5,5,5,4,5,5,2,3,3,3,4,5,1,4,4,2,5,4,4,3,2,4,2,2,4,4,2,2,2,2,5,3,4,1,1,5,4,1,3,2,2,3,4,1,3,4,2,5,2,3,1,3,3,4,5,4,2,2,3,5,4,4,4,2,1,1,2,3,3,5,5,2,1,2,5,1,5,3,5,1,1,2,4,1,4,4,3,1,5,2,2,2,4,1,1,2,4,3,1,2,3,4,3,3,4,5,1,4,2,3,5,4,2,4,1,4,2,1,5,4,1,5,2,2,3,4,2,3,3,2,4,2,4,3,4,2,2,4,5,2,2,5,1,1,4,4,1,3,3,5,1,2,3,4,1,4,5,1,4,4,2,1,5,2,3,5,5,1,4,1,5,4,3,3,4,4,4,4,3,5,2,2,5,1,2,1,1,3,3,5,4,1,5,4,3,4,5,1,1,2,2,3,5,3,5,4,1,3,4,4,2,1,1,1,2,5,1,3,5,1,4,4,3,4,1,5,4,4,1,2,3,1,4,2,4,4,3,3,5,4,3,5,4,3,4,3,1,5,3,2,5,1,5,3,2,2,4,3,1,1,5,3,4,2,2,1,4,1,2,2,4,2,4,2,1,2,5,3,5,1,5,5,5,2,1,2,5,2,4,1,3,5,5,2,1,1,1,3,2,1,3,3,5,5,5,1,5,1,4,5,3,1,5,3,1,3,2,2,5,1,5,1,5,4,2,1,5,2,4,3,2,2,4,2,5,2,3,4,2,3,5,4,4,5,4,1,4,3,5,5,1,3,4,5,3,3,4,3,3,4,4,4,3,2,3,3,5,5,2,2,3,1,4,5,4,1,2,4,5,1,4,1,1,1,4,1,4,4,4,3,2,5,5,3,2,2,5,1,3,5,3,4,2,3,1,4,4,4,4,1,5,2,4,5,2,4,3,5,2,1,3,2,3,3,2,3,4,2,3,1,2,3,3,4,2,3,3,2,3,4,3,4,2,3,2,3,2,4,5,1,4,1,2,1,2,5,4,1,4,3,4,5,1,2,3,4,3,2,1,2,3,4,5,1,5,1,1,4,3,4,2,4,3,5,5,3,4,2,3,2,1,3,5,4,2,3,1,3,3,3,4,5,1,1,2,2,1,3,3,3,4,2,3,5,4,5,2,4,5,3,3,2,1,5,5,3,1,2,3,1,3,1,1,5,4,4,2,2,2,1,2,2,1,2,3,4,1,3,1,2,2,3,5,5,1,5,1,4,1,4,4,2,2,3,3,3,1,5,5,2,1,3,4,1,2,2,3,2,1,2,5,5,5,3,1,5,2,2,3,3,2,4,4,2,3,1,5,3,5,2,4,1,3,2,5,2,4,3,3,1,5,5,3,2,2,1,2,2,3,4,5,3,3,3,1,5,5,4,1,3,2,2,2,3,4,2,1,4,3,5,3,4,1,2,4,5,1,5,5,1,5,4,1,3,2,4,1,2,4,3,5,1,4,3,4,5,2,5,3,4,2,4,1,5,1,5,3,4,2,2,2,4,5,3,1,2,3,1,2,5,1,3,4,2,5,3,2,2,5,4,5,4,3,1,2,5,4,1,2,1,5,4,3,1,1,2,1,2,5,2,3,3,3,5,1,3,4,1,5,3,5,5,1,3,1,4,1,1,2,5,4,2,3,5,3,1,4,5,5,3,3,1,1,3,3,3,2,2,2,2,2,1,1,4,1,5,1,1,3,5,5,3,2,2,3,3,5,3,5,5,1,5,5,3,1,4,3,3,4,4,1,3,5,1,1,4,3,3,3,3,3,4,4,3,3,1,1,4,5,2,1,2,5,5,5,1,3,5,4,3,5,4,3,4,4,4,1,2,5,5,1,5,1,3,5,5,3,2,4,5,4,1,1,4,5,5,2,3,1,5,5,4,1,5,1,4,4,5,5,2,2,5,2,1,1,4,4,3,2,3,4,3,5,3,1,5,4,5,2,4,1,4,1,1,3,2,2,2,3,4,1,3,2,3,5,2,2,2,4,2,3,3,5,5,2,3,3,2,4,4,5,5,3,3,3,2,4,4,3,1,4,4,4,4,4,2,4,1,4,4,2,4,4,4,4,5,1,5,4,3,4,2,5,3,1,2,1,3,2,5,4,3,3,3,5,3,3,2,4,2,2,4,5,2,1,3,4,5,5,2,2,1,1,1,1,2,1,4,1,1,2,5,3,3,4,1,4,5,4,1,2,5,3,5,3,4,4,2,1,5,3,4,3,3,1,5,3,3,2,2,4,4,4,4,2,5,1,5,5,1,4,2,4,4,4,5,4,1,4,1,4,5,1,2,4,5,1,5,2,5,3,5,1,5,4,4,2,4,2,1,3,1,3,4,1,4,3,4,5,2,2,2,5,1,1,5,5,4,3,1,2,2,2,1,2,1,4,5,4,1,1,3,3,2,3,1,5,2,1,3,5,4,3,4,3,3,2,1,1,4,5,2,1,2,4,3,2,4,4,4,4,4,3,2,1,5,5,4,1,4,2,5,1,1,3,4,5,4,4,3,5,5,2,3,5,1,4,3,1,3,3,5,5,3,4,1,1,5,3,5,1,3,5,3,4,4,3,3,3,2,2,3,1,3,1,2,4,2,4,3,5,3,4,1,1,4,5,4,1,3,2,4,4,2,1,2,2,2,5,2,4,5,2,1,2,1,5,5,2,3,1,2,3,3,2,4,1,1,2,3,2,4,5,2,3,3,5,5,3,5,1,1,4,1,2,5,5,5,2,1,4,3,1,5,2,3,5,4,2,4,2,5,3,5,1,4,4,2,4,3,2,4,4,3,1,1,4,4,4,1,2,2,3,2,1,1,4,2,3,5,5,2,5,2,4,5,4,4,2,1,1,2,1,4,5,2,2,5,2,5,1,5,5,5,4,1,2,5,4,4,2,2,2,2,3,3,4,4,4,4,2,1,2,5,5,3,1,5,5,1,3,5,4,4,3,1,4,1,1,5,2,2,5,5,1,3,5,2,3,5,4,4,3,1,5,2,5,2,1,1,1,1,4,4,4,3,2,5,2,4,1,1,4,1,5,1,3,3,3,3,2,4,5,3,4,2,2,5,4,1,4,2,3,3,2,4,3,5,5,3,4,4,2,3,3,3,5,5,3,1,3,1,1,1,4,1,1,2,5,5,3,1,1,1,4,3,1,2,1,5,2,5,1,5,1,3,1,5,4,5,4,4,5,5,5,2,2,3,3,5,3,3,5,5,4,3,5,2,2,5,3,2,3,2,5,3,2,1,1,1,4,3,2,3,5,1,2,1,5,2,3,2,4,5,1,4,4,4,3,4,3,1,2,2,2,1,5,3,5,1,1,3,4,4,2,1,3,3,1,2,1,2,5,4,4,5,3,5,4,1,3,4,3,5,1,3,4,1,4,3,2,3,2,5,1,2,2,1,3,2,1,4,3,4,2,4,2,1,2,5,1,3,3,4,2,5,3,5,2,5,3,5,5,5,4,5,1,3,1,1,2,4,2,5,3,3,1,4,3,4,4,1,4,4,5,2,3,2,2,4,1,1,5,1,5,3,5,3,5,3,1,1,1,2,3,3,3,5,3,2,2,1,3,1,5,3,1,2,1,1,1,4,5,1,2,1,5,1,5,1,1,5,1,3,2,4,3,4,5,4,5,2,5,2,5,2,2,4,2,1,1,4,5,4,2,3,1,3,4,1,5,3,5,4,2,2,1,3,1,3,1,3,1,3,5,1,5,3,5,4,5,1,4,1,4,4,5,5,5,5,5,4,1,4,2,5,1,5,4,1,3,5,5,5,1,3,1,5,4,1,4,4,4,4,3,4,1,1,2,1,3,1,2,3,4,2,5,2,1,1,4,5,2,2,1,2,4,3,5,1,4,1,2,3,4,3,1,2,1,2,2,4,5,2,3,4,3,3,2,4,5,5,1,2,5,4,5,2,2,3,1,2,2,3,2,5,1,3,2,4,4,1,4,2,5,2,4,1,4,1,4,2,2,4,4,5,5,3,5,5,3,3,4,1,4,5,4,4,4,2,1,1,2,2,4,4,2,2,1,1,3,2,5,5,5,1,5,3,3,4,5,4,1,1,5,2,2,1,2,5,4,2,3,3,3,4,3,4,4,2,1,3,5,2,5,4,2,4,2,5,4,4,1,4,2,5,2,2,1,1,2,1,5,5,4,4,1,3,5,1,3,2,4,4,4,5,1,3,4,1,3,5,3,4,1,3,3,2,5,5,4,5,5,2,1,1,5,2,2,3,3,3,3,2,1,4,5,2,2,5,5,4,3,3,4,1,2,5,1,2,5,4,5,1,4,3,3,2,2,3,5,5,5,4,3,3,4,5,5,3,3,4,4,4,3,5,5,4,1,1,3,3,2,1,3,4,2,5,3,5,5,5,1,3,3,2,2,1,1,1,4,4,1,1,5,1,2,2,1,3,4,1,3,4,5,4,4,5,3,1,2,5,4,4,2,3,5,5,1,3,4,4,2,1,5,1,4,4,2,1,5,4,2,2,3,5,1,4,4,2,4,1,5,2,3,3,2,1,3,5,2,1,1,1,1,4,4,1,5,4,4,3,3,5,1,3,1,5,3,4,1,1,4,5,3,3,3,5,3,5,3,3,2,1,2,2,3,5,2,2,2,2,5,2,5,2,5,2,5,1,1,4,2,2,5,4,2,4,5,4,2,1,2,3,4,5,2,5,1,2,4,2,1,1,4,5,3,1,2,5,1,2,1,1,1,4,2,1,1,4,4,3,5,2,1,4,3,4,2,1,1,3,3,3,5,4,3,3,2,4,3,1,4,4,1,4,3,2,3,5,5,5,2,4,2,3,5,5,3,5,5,2,1,5,3,3,4,5,2,2,2,4,3,1,3,4,1,4,1,3,5,2,1,5,5,4,4,4,1,5,2,1,2,1,4,5,5,2,1,5,2,1,4,5,3,5,5,4,3,2,5,1,2,3,3,2,2,4,1,3,1,2,4,5,5,1,5,2,2,2,4,5,3,3,5,2,3,4,1,3,1,1,3,1,5,5,4,5,2,1,2,1,4,2,1,3,2,2,2,2,2,2,2,5,1,2,1,1,3,2,5,5,2,5,3,5,3,5,1,2,4,2,2,1,3,2,5,2,3,5,5,4,2,5,5,3,4,1,1,2,3,3,5,3,3,4,1,2,2,5,2,1,4,3,1,2,5,2,1,3,4,2,3,3,1,1,5,4,3,1,2,5,4,5,1,1,4,2,3,3,5,5,1,3,3,4,1,5,5,4,1,5,5,2,3,5,5,5,4,4,2,5,5,2,2,4,5,1,1,3,1,2,3,1,5,4,2,2,3,1,4,1,4,5,4,3,5,5,3,5,3,3,2,2,1,2,3,3,5,3,3,5,4,5,4,1,4,4,1,5,5,1,2,4,5,2,4,1,2,2,2,5,1,5,1,2,5,4,1,3,4,2,4,1,4,3,1,3,4,4,4,4,3,2,2,1,3,5,5,3,3,1,3,4,4,3,2,1,3,2,5,2,2,2,1,1,5,3,1,5,4,1,2,3,1,3,4,1,5,2,1,5,2,2,4,4,1,4,2,5,4,4,4,1,3,4,1,3,4,1,5,3,2,2,3,3,5,5,3,5,5,2,1,1,1,4,3,5,5,1,3,3,3,5,5,2,5,1,3,3,1,4,2,2,1,5,4,5,2,1,3,4,4,2,3,5,5,3,1,1,2,3,5,2,2,1,2,4,5,2,2,1,4,2,4,3,5,4,1,3,1,1,5,5,3,2,5,2,4,1,1,1,3,1,5,3,3,4,4,1,3,1,2,4,3,1,3,3,5,2,3,5,2,5,3,1,4,4,3,4,5,2,5,4,3,2,1,5,1,4,4,4,1,2,5,1,1,2,5,5,1,4,5,4,5,1,4,1,2,3,1,2,1,3,1,3,4,5,1,2,1,2,2,3,4,1,5,1,3,4,4,3,2,4,3,5,3,4,5,3,4,4,1,3,2,1,3,2,4,1,3,5,2,2,4,1,5,4,4,4,2,2,1,5,2,5,3,1,2,2,2,2,3,2,5,3,4,3,1,4,1,2,5,2,3,4,5,1,5,4,4,3,2,2,4,4,3,5,5,3,3,3,2,1,3,2,3,4,1,1,4,3,4,3,5,4,2,2,3,5,4,1,5,5,4,5,4,1,1,5,2,5,1,2,2,4,4,4,2,5,5,2,2,4,3,5,4,3,3,5,2,4,3,1,2,4,4,5,4,5,3,3,2,1,2,3,2,4,1,4,1,1,1,2,3,5,3,1,2,3,2,1,2,3,1,1,3,2,4,5,5,2,1,5,5,2,3,1,3,4,5,5,5,3,1,5,4,5,5,3,3,1,3,5,2,1,4,1,3,1,5,5,2,5,2,4,1,1,1,2,1,5,3,5,4,1,2,2,4,4,4,3,2,3,2,5,5,2,5,2,1,3,1,3,1,4,2,1,2,4,4,4,1,2,2,2,4,4,5,5,4,2,5,5,1,1,5,4,3,4,5,4,5,3,2,3,5,5,2,3,2,2,2,1,5,3,4,1,2,2,2,1,1,2,3,1,3,2,4,4,2,5,3,4,5,2,5,2,1,1,4,3,3,4,2,1,5,3,2,2,2,5,1,1,1,1,2,5,2,2,4,1,1,5,5,3,3,5,3,3,5,2,5,1,4,3,2,1,3,5,1,2,5,3,5,3,2,4,3,3,5,1,2,2,1,5,4,3,3,1,5,1,5,3,1,1,1,1,4,2,4,2,1,4,1,5,2,4,4,3,2,5,4,3,1,5,1,5,2,5,2,1,3,4,3,5,2,2,4,4,5,4,3,5,2,3,1,1,5,5,5,4,3,5,4,2,2,3,5,5,1,3,2,3,1,2,4,2,3,5,4,4,5,1,3,1,2,5,4,3,3,3,2,3,3,5,4,3,4,2,5,5,3,5,1,4,5,1,5,3,5,1,2,2,5,5,4,2,5,4,3,5,5,3,1,3,4,4,4,3,4,3,1,2,1,3,3,4,3,3,2,4,3,4,2,1,3,3,4,5,5,5,2,2,5,3,1,4,4,5,2,1,2,1,4,4,1,2,2,3,1,3,1,3,1,4,3,5,1,2,1,3,1,2,3,1,5,4,2,5,5,4,1,2,3,2,2,4,5,3,5,5,1,1,3,2,3,4,5,5,1,2,5,4,1,5,5,2,1,3,4,4,1,2,5,3,5,2,3,5,4,4,1,3,2,2,4,1,4,1,3,1,5,3,2,1,2,4,5,4,1,4,3,5,2,3,5,4,5,2,3,3,2,1,3,3,1,1,3,5,5,5,2,2,5,5,3,2,1,2,1,2,4,5,1,5,4,5,5,3,5,4,4,3,4,5,4,4,5,5,1,2,3,2,4,5,4,2,5,3,3,2,3,4,3,5,2,4,5,1,1,3,3,2,3,5,3,2,2,4,3,2,1,2,4,3,1,4,2,4,4,1,4,4,5,2,5,2,1,2,3,3,1,3,4,3,4,3,2,3,5,2,1,4,1,5,1,1,5,2,3,5,3,2,4,3,2,2,2,4,4,4,3,2,2,2,2,2,5,2,2,1,4,1,2,1,2,3,1,2,4,3,5,2,2,2,2,3,2,2,5,5,4,2,2,5,1,4,2,3,5,4,4,3,3,1,2,1,5,4,2,3,2,3,5,3,2,2,1,5,4,1,3,1,1,5,5,3,1,2,5,2,5,3,3,1,4,4,2,5,2,1,2,2,5,3,5,4,5,4,5,1,3,3,2,1,1,3,5,4,4,5,2,2,5,2,1,1,1,2,3,1,4,5,3,4,4,5,5,2,3,4,3,3,5,4,2,1,4,5,3,5,3,1,2,1,1,3,2,1,1,3,2,4,5,1,4,3,1,4,5,1,3,1,1,1,1,4,5,5,3,4,2,5,4,5,2,1,3,3,2,2,3,5,1,5,5,5,5,3,4,2,3,3,4,2,4,3,1,4,2,3,5,2,1,3,3,3,4,3,2,5,3,5,2,2,3,3,1,5,2,5,3,2,4,3,1,2,1,2,5,2,2,3,5,5,3,2,4,1,1,1,1,5,2,3,1,5,5,3,4,5,3,3,4,1,4,3,2,4,1,3,4,1,5,2,1,3,3,3,5,4,3,3,4,3,2,5,3,4,4,4,5,3,1,1,5,3,1,3,3,3,1,4,2,3,5,1,2,2,2,3,2,1,1,5,1,3,4,5,5,3,3,4,3,3,1,3,5,5,1,2,2,4,5,3,1,3,5,5,2,4,3,2,2,1,4,4,3,1,2,2,4,1,1,2,4,3,5,1,3,1,1,3,2,2,2,2,3,5,5,2,1,2,1,4,4,4,5,2,5,2,5,1,3,4,1,3,1,3,2,3,5,3,3,2,5,3,3,4,1,1,2,5,3,5,3,5,5,3,3,4,2,4,3,2,2,4,2,3,3,3,2,3,2,3,2,3,5,2,4,1,5,3,5,5,1,2,1,1,4,2,1,4,4,1,2,3,1,5,1,2,5,4,4,3,4,1,3,3,3,4,3,2,1,5,2,5,4,1,2,5,5,1,4,2,4,4,1,3,3,3,1,1,2,5,2,1,3,4,3,5,3,5,4,1,1,1,4,2,2,5,1,2,2,4,2,2,5,3,4,4,2,5,1,2,2,5,2,1,3,3,3,4,1,1,4,2,1,5,5,1,2,5,5,3,4,3,5,4,5,1,2,2,2,5,2,2,2,3,3,4,1,5,4,4,4,4,2,4,4,2,3,4,4,3,5,3,2,5,1,4,3,5,2,2,3,2,5,4,4,1,3,4,4,1,2,5,4,5,4,4,1,3,1,1,2,5,4,3,5,4,4,5,3,3,5,3,4,1,1,4,3,4,1,5,4,4,5,4,5,4,5,5,1,3,2,3,1,2,2,5,1,1,5,2,3,2,1,3,4,5,4,5,2,3,2,5,3,5,2,3,4,1,5,4,2,5,3,1,2,5,3,2,2,4,3,2,2,5,5,1,2,3,4,4,5,2,1,4,3,1,4,3,3,1,4,5,3,3,4,3,5,3,4,5,4,3,3,1,3,1,2,2,5,3,4,2,5,4,5,5,4,1,3,3,2,2,3,1,4,5,3,5,4,5,1,4,1,2,1,1,3,4,4,3,4,3,2,2,1,2,5,4,2,2,4,3,4,4,5,2,5,2,4,5,5,1,3,3,2,1,5,1,5,2,3,2,3,2,3,1,4,4,5,5,1,3,3,1,5,5,4,5,3,4,2,5,3,4,2,3,1,5,2,3,5,2,4,5,1,4,2,3,5,4,1,2,4,2,5,5,1,3,5,4,5,1,2,1,1,5,1,4,4,3,5,2,3,5,3,1,5,3,3,1,3,2,5,2,1,1,2,1,1,2,3,4,2,2,5,3,2,2,4,4,4,1,5,1,1,3,3,2,5,2,1,3,5,2,4,4,4,4,4,5,3,5,1,4,1,3,3,5,1,4,1,2,3,5,2,1,5,1,5,3,2,3,4,4,3,2,1,1,2,3,2,2,1,5,5,2,3,2,4,2,3,1,4,3,4,5,2,1,5,3,1,3,1,3,3,2,4,4,5,4,4,3,5,3,4,4,2,1,4,5,5,1,4,2,5,2,2,3,3,4,4,4,1,2,5,2,3,5,1,5,3,4,2,2,2,1,2,2,5,4,1,3,3,2,1,5,4,4,5,5,3,3,4,3,5,1,4,2,2,1,3,2,3,5,2,4,3,3,4,3,2,4,1,2,3,4,2,3,2,5,4,1,3,3,4,1,4,2,2,3,1,4,4,5,1,3,3,2,2,5,3,5,1,4,2,1,5,3,4,1,2,1,3,1,1,5,5,2,2,5,4,3,2,1,3,1,3,4,2,3,2,3,4,3,4,1,3,3,5,1,3,5,1,3,5,1,2,4,1,1,3,1,4,2,5,2,3,4,5,1,5,2,4,2,5,1,4,1,4,3,5,1,3,5,3,2,3,1,5,5,4,5,1,1,2,4,5,4,4,4,4,1,5,5,2,4,1,2,2,5,1,1,3,1,1,1,2,2,2,2,2,5,2,2,4,3,2,4,5,5,1,4,5,3,3,4,4,5,3,5,5,3,1,5,1,3,3,1,4,5,3,2,3,5,2,1,3,5,2,5,4,5,5,3,1,2,5,5,4,1,5,5,4,1,4,3,3,5,2,4,5,1,2,2,5,4,5,3,2,3,1,4,4,4,1,5,5,4,4,3,1,4,4,1,2,1,2,5,5,3,5,5,2,1,2,3,1,3,3,4,5,2,2,3,4,2,3,3,3,1,4,4,4,5,2,1,1,2,5,5,3,4,4,3,2,5,3,1,3,4,5,4,5,2,4,2,5,1,3,4,1,4,1,5,1,3,2,3,3,1,1,1,4,1,3,3,5,4,2,4,1,3,1,3,4,4,1,1,2,5,3,2,1,1,5,1,1,1,3,5,2,1,4,3,3,2,2,4,3,3,1,3,1,2,2,1,2,1,5,1,2,1,3,1,3,5,2,2,4,2,5,4,3,4,4,2,3,2,4,1,4,4,4,5,5,5,5,1,5,2,3,5,1,3,4,3,3,1,2,4,1,2,3,2,1,3,3,2,1,4,1,5,5,4,2,1,3,3,5,5,2,1,1,3,2,3,4,2,5,2,3,2,2,1,3,2,4,5,3,4,5,1,5,3,1,2,2,2,3,3,1,2,5,2,5,5,2,2,3,3,4,1,1,1,2,1,2,4,2,1,2,4,2,2,3,5,5,2,5,1,5,3,5,1,2,4,4,1,1,5,1,5,4,4,3,1,5,5,3,4,5,2,4,3,1,5,1,3,5,5,1,4,4,2,3,2,4,2,2,3,4,4,3,2,2,2,5,4,5,4,2,2,2,5,5,3,4,4,4,4,2,2,3,4,5,4,2,1,4,3,3,3,1,2,4,2,3,2,2,3,5,4,5,1,2,3,1,4,3,2,1,4,1,4,3,2,1,1,1,2,2,4,5,3,2,5,4,1,3,3,5,3,5,5,5,2,5,2,4,3,3,4,1,4,4,4,5,3,1,5,3,3,3,1,4,4,5,1,5,3,2,4,4,4,1,3,1,1,4,1,5,2,1,1,1,4,2,2,1,2,2,5,3,3,3,4,2,1,4,1,1,4,1,5,1,5,2,4,1,4,4,2,2,3,1,2,4,3,5,5,1,1,3,3,3,4,5,3,2,1,4,3,5,5,1,5,4,2,1,5,4,2,3,5,4,5,3,2,1,1,2,5,2,1,2,2,3,2,5,3,4,4,1,2,3,3,3,3,3,3,5,5,4,2,2,2,1,1,4,5,2,3,4,1,4,4,3,5,1,4,3,2,1,4,4,4,4,2,2,1,1,1,3,4,1,2,5,2,4,5,1,4,1,1,4,3,3,3,1,3,1,3,5,3,1,2,1,5,4,3,3,3,2,2,4,5,5,3,1,2,3,1,4,5,1,3,2,4,2,4,5,3,3,5,5,4,2,3,1,2,2,5,4,3,2,4,2,3,4,1,5,3,3,2,2,3,5,1,1,2,4,1,3,5,3,4,1,4,4,5,4,1,5,3,5,5,4,5,4,4,2,1,1,2,5,1,5,3,3,4,2,4,5,4,4,1,4,4,2,3,4,4,1,1,3,1,5,2,3,4,1,2,3,1,3,5,5,3,3,3,1,5,2,1,1,1,5,2,3,5,4,2,3,1,1,2,1,2,2,4,1,4,5,5,5,2,5,4,4,3,5,1,5,4,4,4,2,1,2,3,4,2,1,5,1,5,5,4,1,3,4,1,4,2,5,1,3,1,1,1,3,2,4,1,4,2,4,2,2,1,5,2,1,5,5,4,1,2,5,2,2,5,1,1,1,4,5,4,1,1,3,4,2,4,4,1,1,3,2,4,5,3,1,1,3,3,4,2,1,1,5,5,5,1,1,3,1,3,4,5,2,2,5,3,1,4,3,1,1,1,4,2,1,4,3,4,5,5,3,2,3,2,5,2,1,2,5,3,2,2,2,5,1,4,5,4,3,1,4,4,1,3,3,1,3,4,3,4,2,4,4,5,3,3,4,5,1,4,1,3,3,4,2,1,4,3,2,1,5,1,4,5,4,3,2,1,2,1,4,5,5,1,2,5,3,4,2,4,5,4,3,2,2,2,2,2,3,4,1,5,3,5,1,1,5,1,1,4,4,2,3,3,2,1,1,3,5,5,1,5,4,1,5,1,1,3,2,1,3,3,3,5,5,1,1,1,1,3,5,4,4,3,1,1,4,4,2,5,2,1,1,2,3,5,1,4,5,1,4,3,1,3,2,3,3,2,1,2,3,5,2,2,3,2,2,2,1,3,3,5,4,2,3,3,5,3,2,2,1,4,3,5,2,3,2,1,2,5,4,2,5,4,3,4,5,1,1,4,5,1,4,3,1,1,5,1,5,4,5,3,2,4,2,4,1,4,5,5,1,5,2,1,5,5,5,4,1,3,3,5,3,1,2,4,3,2,1,5,3,5,2,1,4,5,2,2,3,3,3,3,3,4,5,3,3,4,4,4,5,2,1,1,4,3,4,2,4,2,1,1,4,2,3,1,1,1,1,2,4,2,1,3,3,3,2,2,3,3,5,3,1,3,2,1,2,2,5,4,5,1,3,3,4,5,4,5,1,3,5,3,1,4,4,2,3,4,1,2,3,2,2,2,5,4,2,5,5,2,3,1,4,5,5,4,3,3,2,3,5,2,2,5,5,3,2,4,2,1,4,3,5,5,4,1,3,2,4,2,4,3,1,5,5,4,4,5,5,5,5,5,2,5,1,4,4,3,2,5,5,1,2,3,2,2,2,2,3,5,3,1,2,2,1,3,3,4,1,5,2,5,2,5,4,4,5,4,5,4,5,5,3,1,5,4,2,5,2,5,4,1,5,3,3,1,5,1,4,2,1,2,1,1,1,5,5,5,1,3,4,5,2,4,3,4,3,5,3,4,2,2,4,4,5,5,2,5,5,4,5,2,1,3,2,1,1,4,2,3,4,3,1,1,1,3,2,3,3,5,4,3,5,4,1,4,4,1,4,2,1,5,3,2,4,3,4,4,5,4,5,1,5,4,4,5,1,1,5,1,4,1,4,2,4,3,5,1,1,3,5,2,2,5,4,4,5,5,2,1,1,3,4,4,4,4,4,1,2,5,1,5,1,1,4,1,3,5,5,4,5,4,1,3,3,3,5,3,1,2,3,1,5,2,2,2,1,3,3,3,3,4,1,4,4,2,1,4,4,1,3,4,3,1,2,5,5,2,5,1,2,2,4,4,4,1,3,2,5,3,4,4,3,1,3,5,2,2,3,5,4,3,4,1,2,3,1,1,3,2,3,1,1,3,4,2,1,4,4,5,4,2,2,5,3,5,5,1,3,3,1,3,3,1,3,1,1,5,3,4,5,2,1,1,5,4,5,2,4,1,5,3,2,5,4,4,3,3,4,1,3,5,3,1,2,5,5,2,4,2,1,2,3,2,4,3,3,5,5,2,4,4,1,5,1,2,5,5,2,4,5,4,5,3,2,3,5,4,5,5,1,4,2,2,2,3,1,2,4,5,5,2,5,2,4,2,5,4,1,3,2,5,3,4,4,5,2,4,5,4,3,5,5,1,4,2,4,2,1,5,1,4,1,2,4,2,5,2,2,5,1,1,3,1,1,4,5,2,3,1,5,5,5,2,2,4,2,5,3,2,1,1,4,3,1,2,4,3,1,2,2,3,2,4,5,5,5,2,2,4,1,3,5,5,5,3,3,2,1,2,4,5,3,2,3,1,4,1,1,1,3,4,2,4,3,5,4,5,2,3,1,2,1,2,3,2,3,4,3,5,5,2,3,5,5,4,3,2,4,5,5,2,5,4,2,2,2,2,3,5,5,2,4,1,5,3,4,1,2,5,2,5,5,1,4,3,1,1,2,2,1,1,2,3,3,1,2,4,2,1,3,2,3,3,1,5,3,4,4,5,1,4,3,5,2,3,2,5,5,2,1,3,2,2,2,5,1,4,4,4,5,3,3,5,5,3,2,3,3,2,2,5,1,4,3,1,5,4,2,1,5,3,1,3,1,4,4,3,1,2,2,5,3,2,1,5,2,4,1,4,3,5,4,2,3,2,1,4,5,4,2,1,3,3,5,5,1,2,1,1,1,3,3,1,3,3,1,5,1,3,1,5,2,5,1,3,3,5,4,1,5,5,4,5,1,4,5,2,4,1,3,3,2,2,3,1,3,5,4,4,2,2,3,2,2,1,1,1,4,5,4,2,5,4,1,5,3,1,2,1,2,1,3,2,5,3,2,1,1,5,4,4,1,3,3,3,3,4,3,3,3,4,2,2,3,1,3,1,2,1,1,2,5,3,3,4,4,3,4,1,4,2,3,4,4,1,2,4,2,3,5,2,2,3,3,5,5,2,1,1,1,2,4,2,5,3,1,5,2,2,4,1,5,1,4,1,3,1,4,1,5,1,1,4,3,5,2,2,2,4,3,2,4,5,5,5,2,2,4,1,5,2,3,5,2,5,2,2,3,2,3,4,1,3,2,4,3,1,3,3,3,3,4,2,5,3,3,1,3,5,5,2,2,5,4,3,1,5,5,3,2,1,4,4,5,3,5,5,1,3,1,3,2,5,2,4,2,5,2,1,3,5,3,3,2,2,2,2,1,3,2,2,1,4,3,1,5,5,3,1,3,2,5,4,1,4,5,4,1,1,5,3,3,5,4,5,4,3,2,5,4,1,3,2,1,2,2,4,3,4,1,2,2,5,5,2,5,5,3,2,2,3,4,1,1,4,3,2,2,1,1,5,2,4,5,3,2,2,2,5,1,1,2,5,3,5,5,4,2,1,4,1,4,1,2,1,4,5,2,5,1,5,4,2,5,2,1,4,1,1,2,5,5,2,2,5,1,1,3,3,4,2,1,1,5,4,1,5,3,5,1,1,4,3,1,3,2,5,5,1,3,5,4,1,1,1,2,2,2,2,2,5,2,5,2,1,3,5,4,2,3,3,5,2,5,1,2,2,2,2,4,3,5,4,3,5,1,3,2,2,5,4,5,5,5,2,5,5,3,4,4,4,1,1,2,3,2,1,1,2,5,1,4,2,4,4,4,4,4,1,3,3,4,2,2,3,4,4,2,1,1,4,5,3,4,5,3,5,5,3,5,1,1,2,2,5,1,4,2,4,5,1,2,2,5,3,4,3,5,4,4,1,1,5,4,5,3,2,2,1,5,4,2,3,3,1,4,1,2,1,4,2,3,1,1,1,2,1,4,4,3,3,5,4,4,1,3,2,4,2,3,4,1,1,5,1,3,4,2,3,4,5,1,5,5,5,4,1,3,3,1,1,4,1,3,3,2,4,3,3,3,2,4,1,2,1,1,4,2,5,2,4,3,5,2,2,2,4,1,2,2,2,5,1,2,2,2,1,3,3,1,2,2,5,2,3,2,5,1,5,4,2,2,5,2,2,5,1,2,1,2,5,3,1,3,2,1,2,3,3,1,4,4,5,2,5,3,5,1,4,1,1,4,5,1,5,1,2,3,3,2,4,1,4,1,2,2,5,5,5,5,5,3,4,2,4,5,1,3,2,1,4,3,1,5,1,5,1,3,4,3,4,5,2,5,3,4,5,4,4,1,4,4,4,4,4,5,2,4,1,2,1,5,4,1,1,3,3,2,5,4,5,1,2,5,1,4,2,2,2,5,4,4,3,1,5,1,4,2,1,1,1,1,1,1,1,5,5,4,1,3,1,1,4,5,3,5,1,2,3,2,4,5,1,5,2,5,5,1,2,2,5,5,2,5,1,3,2,4,3,1,3,5,3,5,4,3,2,2,1,2,4,1,4,4,3,5,1,3,3,5,1,4,2,3,4,5,2,3,2,4,1,5,2,1,4,1,3,5,5,1,1,1,2,5,5,5,1,1,1,5,5,3,2,5,5,1,3,5,5,5,5,5,2,5,4,4,4,4,1,4,2,2,2,3,5,1,1,2,3,2,3,2,1,2,4,1,3,2,1,3,4,1,4,3,4,3,1,1,4,2,2,2,2,3,1,5,4,5,3,3,2,3,5,2,5,3,5,4,2,1,3,2,4,4,3,4,5,1,1,4,5,4,2,3,1,3,4,2,4,2,1,5,3,2,3,3,4,3,1,1,1,5,5,3,2,5,1,3,2,3,1,5,1,3,2,5,4,3,2,5,5,3,3,1,2,1,2,5,1,5,1,5,5,2,4,4,4,2,5,3,4,1,5,5,4,3,3,2,1,3,5,2,1,5,3,2,1,1,5,2,3,5,2,1,4,3,1,1,2,3,4,1,3,5,1,4,5,3,3,1,1,5,1,5,2,4,1,1,5,2,1,3,1,3,4,2,1,3,2,4,3,1,5,4,4,2,3,4,5,4,1,4,1,4,4,1,3,5,2,3,2,3,3,2,3,1,4,4,4,3,5,5,4,1,2,2,2,1,5,1,2,2,5,2,2,4,1,5,3,3,5,4,3,1,5,2,3,3,3,3,1,5,3,5,2,3,3,3,4,3,2,4,1,5,1,1,4,1,5,4,5,3,2,5,1,3,2,3,1,3,5,5,5,1,1,1,5,4,3,5,1,4,3,3,5,3,5,1,3,4,4,3,4,5,3,4,2,4,4,3,5,3,3,3,3,5,4,2,4,4,1,3,5,1,4,4,3,1,1,1,3,4,1,4,1,4,4,2,4,4,3,5,3,5,1,4,5,1,5,3,4,5,3,2,5,5,5,1,2,4,4,2,3,3,4,4,3,2,4,3,2,2,1,3,1,1,3,4,3,1,1,3,5,4,5,3,2,1,4,1,2,2,5,4,4,2,1,5,2,2,1,5,3,1,1,1,5,4,2,3,3,1,4,2,5,1,2,5,4,2,1,4,5,4,1,1,4,2,4,2,4,5,3,3,1,1,3,3,1,5,1,5,2,5,3,4,4,1,5,5,3,1,2,1,5,3,4,1,1,1,1,1,1,1,2,4,1,5,3,4,4,3,4,1,5,2,5,3,4,2,5,1,2,1,4,4,2,5,5,3,2,1,1,3,4,4,4,3,3,4,5,5,2,1,5,1,5,4,2,2,3,5,3,1,5,4,4,5,5,1,5,3,3,5,3,3,1,1,4,1,1,4,4,1,1,4,2,2,3,1,3,1,1,5,2,2,1,3,5,2,3,3,1,5,3,3,4,1,1,5,5,4,4,2,3,2,1,4,2,5,5,3,1,4,2,1,4,2,5,5,2,4,1,5,2,2,3,4,2,3,2,3,3,4,2,3,4,1,1,1,2,2,2,1,3,2,5,3,1,3,2,5,2,2,4,5,1,5,1,5,3,4,3,4,4,2,5,2,4,5,1,3,2,4,2,3,5,2,5,1,1,2,1,5,4,1,4,1,2,1,4,5,3,2,4,2,3,4,5,4,1,2,1,1,5,2,1,1,5,3,1,2,4,5,5,3,3,4,3,5,1,4,1,3,1,5,2,4,4,3,2,3,5,2,3,4,5,1,4,2,2,5,2,5,1,3,4,5,4,1,4,3,1,1,5,5,4,1,2,1,1,4,4,2,1,4,1,3,5,2,4,4,4,4,5,1,3,4,3,1,3,2,1,1,2,2,4,1,4,5,5,2,4,5,1,1,5,5,5,3,3,3,1,4,5,2,3,2,2,1,5,5,5,5,1,5,3,2,4,3,4,2,5,4,2,3,3,2,5,4,1,5,5,1,2,3,5,4,5,3,1,4,3,4,3,4,2,4,4,1,4,2,1,1,5,1,3,1,1,1,2,2,2,3,1,1,5,5,1,2,5,3,1,2,2,1,3,3,1,3,2,2,1,3,5,4,1,5,3,1,1,4,2,2,3,4,5,3,5,2,4,3,2,4,5,4,3,3,5,3,3,3,4,5,2,5,1,2,3,5,5,5,5,4,2,1,1,2,2,1,3,4,5,3,4,3,5,4,5,3,3,2,3,3,3,5,4,1,2,3,5,3,2,3,3,3,2,2,2,3,4,1,2,1,1,2,2,5,1,1,3,1,1,1,3,4,5,2,1,1,5,4,3,4,5,2,3,2,4,3,5,3,1,4,2,2,2,4,5,2,5,5,2,4,2,5,1,3,1,2,3,2,3,1,5,1,2,5,4,4,3,2,3,2,5,4,4,2,5,3,5,3,5,4,2,4,3,1,2,1,4,4,4,4,3,1,1,2,5,3,4,2,2,2,4,3,3,1,5,2,5,3,1,4,3,3,2,5,5,4,5,4,3,2,3,4,2,1,4,4,1,3,1,3,5,4,4,3,5,2,1,4,2,3,2,3,2,3,2,2,4,1,3,5,2,5,1,2,4,2,5,2,5,2,5,4,2,1,1,2,2,4,3,1,4,3,5,2,5,5,1,3,1,5,2,1,5,1,4,1,2,5,4,5,4,5,1,5,1,3,1,4,4,2,4,5,3,5,1,3,1,4,1,3,5,1,4,2,2,5,3,1,5,3,5,1,1,2,2,1,5,3,1,2,2,4,4,4,3,1,3,2,2,1,1,3,2,4,2,4,1,1,2,1,5,3,1,3,5,4,2,2,1,4,1,1,3,3,5,5,1,5,5,1,5,3,1,4,5,1,5,2,4,5,1,4,5,4,2,2,4,1,4,3,4,1,1,1,2,2,1,2,4,4,2,4,4,2,3,3,2,4,4,5,1,2,2,4,2,5,5,5,2,2,2,5,1,5,5,3,1,1,1,4,5,5,3,3,2,3,5,4,5,4,1,1,4,5,3,5,2,5,5,4,1,3,3,1,5,5,1,4,4,1,5,3,5,4,1,2,1,5,2,2,4,2,2,1,2,4,2,3,3,3,1,5,5,4,5,4,2,2,1,5,2,1,5,5,2,3,3,1,5,2,4,4,1,3,2,5,1,2,1,5,3,3,3,2,3,3,4,2,1,4,2,3,3,3,5,4,2,4,5,5,1,5,2,4,4,3,1,2,2,1,4,4,4,1,5,3,5,1,2,3,5,5,3,4,3,4,3,3,3,4,2,5,4,3,5,4,2,2,3,3,5,2,3,5,3,3,3,5,5,2,1,1,3,1,1,4,1,2,1,3,5,4,1,4,1,5,4,4,2,2,5,3,2,2,2,5,2,1,1,5,3,4,5,1,5,5,1,2,2,2,4,4,5,5,4,1,4,4,5,5,5,5,2,3,3,3,5,1,5,5,5,1,3,2,5,4,3,2,4,2,4,1,3,1,5,1,2,5,2,4,2,5,5,4,1,4,4,5,1,1,5,2,4,1,5,5,1,2,4,4,1,4,3,1,2,4,1,2,1,4,5,2,5,2,5,1,1,2,5,2,1,1,1,3,3,5,2,5,1,3,1,2,3,4,3,1,2,4,4,4,2,1,1,4,2,3,4,1,3,3,4,3,4,4,3,2,1,2,3,2,3,1,3,3,5,4,1,1,1,3,3,4,5,5,5,3,1,2,1,2,3,4,5,4,5,4,1,5,1,3,1,4,1,2,5,1,4,3,4,2,4,2,3,3,4,5,5,5,2,5,3,3,5,3,5,1,4,3,2,1,2,2,4,1,5,3,3,1,2,2,4,5,5,4,4,1,2,1,5,2,2,4,1,2,5,4,1,3,3,1,1,1,3,3,4,1,1,4,3,2,2,3,1,3,5,4,1,3,4,2,2,2,2,4,1,3,1,3,2,5,2,2,2,1,3,3,4,2,3,4,2,1,4,1,5,4,5,1,4,5,3,4,5,3,4,5,1,3,4,2,5,3,3,4,4,5,4,1,5,4,1,1,1,3,3,1,5,1,2,2,2,5,3,1,2,4,1,1,1,3,3,3,2,5,4,2,1,5,1,3,4,4,4,5,4,2,4,5,3,5,5,5,3,5,3,1,2,1,3,1,2,5,1,1,5,1,3,4,5,2,2,4,5,2,2,5,4,5,1,2,2,2,4,1,3,2,2,2,5,3,2,2,2,2,4,3,3,3,4,3,1,3,2,5,5,4,5,2,4,2,4,4,2,4,2,5,3,2,4,3,2,3,5,4,2,3,2,4,4,5,3,5,3,2,2,3,2,1,1,3,5,1,1,3,2,2,2,2,5,3,2,2,1,4,1,4,4,2,3,5,5,1,3,4,4,1,1,2,1,4,5,3,1,1,5,1,1,2,4,1,2,2,5,1,2,1,5,2,5,5,2,4,5,4,4,4,3,1,5,5,4,4,1,2,4,2,4,2,2,3,2,5,5,1,2,1,4,5,3,5,3,2,2,1,4,1,4,1,4,1,5,4,2,1,5,2,3,3,5,4,2,1,1,4,5,2,4,1,1,3,4,2,5,2,5,5,4,1,5,1,3,2,3,2,4,4,2,5,3,3,3,2,2,1,1,3,4,1,4,5,3,3,4,4,5,1,1,2,3,3,4,4,4,5,5,3,2,3,3,4,3,2,1,3,1,2,3,4,5,1,3,1,4,4,1,5,1,2,1,5,3,2,4,1,5,3,5,3,1,2,4,4,2,4,2,4,1,1,2,2,1,1,2,1,3,5,4,4,4,4,3,5,5,4,3,3,2,2,1,5,2,3,5,3,3,5,4,3,4,2,2,2,3,5,3,4,1,1,2,1,5,4,1,1,4,2,4,2,3,4,3,5,1,4,2,4,1,2,2,3,1,5,2,4,3,3,1,1,3,2,1,4,4,1,5,2,5,3,3,1,5,2,4,4,3,3,1,5,1,2,1,5,1,3,2,5,1,3,1,4,2,3,3,2,2,4,3,3,4,1,2,3,4,5,5,1,2,1,5,1,2,1,2,1,3,5,2,4,5,5,2,2,1,5,5,3,3,3,3,2,1,3,2,4,3,1,3,1,4,3,5,3,4,1,1,2,5,2,3,2,2,5,1,3,2,5,5,1,3,2,5,2,2,1,4,4,1,5,1,4,3,1,1,4,1,4,2,2,2,1,2,4,5,1,5,3,2,3,5,1,5,3,2,2,2,5,3,3,5,1,2,5,5,2,5,4,2,1,3,4,4,3,4,2,4,5,1,5,4,5,3,3,5,2,3,3,4,1,2,4,2,3,3,4,3,3,5,1,3,4,2,3,3,2,2,2,3,3,1,2,2,1,1,2,1,1,5,2,1,2,5,1,4,1,4,4,3,3,3,3,1,2,3,5,3,4,4,5,1,5,4,4,5,2,2,1,5,2,2,3,3,1,2,5,1,3,3,1,5,4,2,3,5,2,2,4,4,2,1,2,5,3,4,5,3,1,3,4,3,2,3,3,1,3,2,5,3,4,3,5,2,3,4,2,4,5,3,4,1,2,4,3,3,2,2,4,3,1,4,3,4,3,2,5,1,1,1,5,1,3,4,5,2,4,4,4,2,5,3,4,2,3,1,5,4,4,3,2,1,2,5,4,5,4,4,3,1,1,5,1,3,2,1,4,2,3,2,2,3,4,1,3,5,3,5,1,5,1,3,1,1,2,2,3,4,2,1,1,3,3,2,1,5,3,2,2,4,5,1,5,2,1,3,3,5,3,2,3,2,2,4,1,4,2,2,2,5,2,5,5,2,1,4,2,5,1,5,1,5,4,2,1,4,3,1,4,5,1,5,5,2,2,3,4,3,2,5,2,5,5,1,1,1,4,2,3,5,4,2,4,5,2,4,5,2,2,3,3,2,3,4,3,4,4,4,2,1,4,4,5,5,2,4,5,1,1,4,1,1,3,3,2,1,2,5,5,3,3,1,1,4,4,5,2,3,5,2,3,5,3,5,3,5,3,5,5,5,3,2,1,3,2,2,4,4,2,5,2,3,5,5,1,1,3,3,3,5,1,4,1,2,3,1,2,3,3,3,2,2,3,3,2,3,5,4,5,2,5,2,3,2,1,5,3,2,2,5,4,1,4,3,3,1,1,3,2,1,3,4,5,5,1,1,4,1,2,3,4,1,5,3,1,1,4,5,3,4,1,2,3,5,4,1,3,4,5,5,4,2,1,2,2,2,3,5,5,4,4,5,5,5,1,5,4,3,3,5,4,5,5,3,4,5,2,2,2,3,3,3,1,2,1,3,2,2,4,1,1,1,5,3,3,1,4,1,2,3,2,4,4,1,2,5,1,4,3,4,3,3,3,3,5,4,2,3,1,4,1,5,1,5,2,1,3,4,1,2,3,1,2,5,1,1,4,3,3,2,3,1,1,2,2,1,5,3,3,4,4,2,4,1,3,5,5,2,1,5,4,3,1,1,1,3,4,3,1,2,3,2,4,4,5,1,3,1,4,1,5,5,1,3,3,5,3,3,3,1,5,4,5,3,1,5,1,3,5,3,5,5,1,1,5,4,4,1,5,5,1,4,1,1,2,4,4,2,5,4,3,4,2,3,2,5,2,4,2,4,5,3,1,5,3,5,5,1,4,1,2,3,3,4,1,1,3,5,4,1,1,3,2,3,1,2,4,4,1,2,1,5,1,5,2,2,4,3,4,2,5,5,4,3,5,2,3,1,3,4,5,2,1,4,2,3,3,5,1,2,1,1,2,3,4,4,1,5,1,2,5,2,2,4,3,2,4,2,1,1,4,3,4,2,2,1,3,5,1,2,4,4,5,4,5,3,2,4,2,3,3,4,3,4,2,2,3,4,3,5,1,3,3,5,5,3,1,3,5,5,3,5,1,2,5,5,2,5,1,1,1,5,2,5,3,4,3,4,2,1,1,3,3,2,4,1,5,5,1,3,1,5,3,1,5,5,5,4,1,3,4,4,5,1,3,2,3,3,2,1,3,3,5,5,2,4,4,4,1,4,2,1,2,3,5,2,5,4,5,2,5,3,2,1,3,5,2,2,5,1,2,4,5,3,4,1,5,3,2,3,4,5,1,2,2,4,3,5,5,1,2,4,1,4,1,4,2,5,4,5,3,1,1,4,4,3,4,5,4,3,1,5,3,4,3,1,2,3,4,3,3,1,5,3,3,1,1,4,3,2,3,3,5,5,3,5,4,2,1,1,3,5,2,1,2,3,1,5,1,5,3,1,2,2,1,5,4,4,4,5,2,4,4,4,4,2,2,5,4,1,4,2,5,4,4,4,3,3,1,2,1,4,5,2,3,2,1,2,1,5,1,4,2,1,3,1,4,2,4,5,3,1,5,2,5,1,1,1,5,4,4,2,4,3,3,3,3,3,3,3,3,2,5,4,3,3,2,3,2,2,2,5,4,2,4,3,1,5,1,1,4,5,1,2,4,2,1,4,2,1,2,2,1,2,4,4,3,4,1,5,4,3,3,5,1,4,2,2,2,1,2,4,1,2,4,5,4,2,4,4,1,5,1,2,5,5,4,3,2,2,4,5,5,4,4,5,4,3,1,2,1,1,2,4,3,4,2,5,1,1,3,1,1,2,3,5,5,1,3,4,1,5,2,2,1,2,4,1,4,1,3,3,4,4,5,5,3,1,5,4,1,1,5,3,5,2,4,2,4,3,2,5,4,1,4,3,5,3,1,2,5,3,1,4,3,5,4,2,3,2,2,2,3,4,5,5,1,3,3,5,4,2,3,4,2,1,1,3,5,5,3,5,5,3,1,5,3,2,4,3,1,2,4,1,3,3,3,3,2,1,5,2,1,1,5,2,5,4,4,5,2,3,1,1,4,3,2,4,3,4,3,4,3,1,4,4,3,2,1,2,2,3,2,1,3,5,1,2,3,1,1,4,4,5,4,3,4,5,5,5,4,3,1,5,3,2,1,4,2,4,2,4,4,4,1,3,1,1,5,2,3,1,2,5,1,5,3,1,5,4,2,1,1,3,4,2,5,2,5,3,5,1,4,4,2,5,4,3,3,3,5,3,3,5,2,4,1,5,1,5,3,4,2,1,1,2,4,2,1,2,4,3,1,4,4,4,1,5,4,3,3,3,3,4,1,1,2,4,3,1,3,3,4,4,3,4,3,2,4,5,4,1,4,3,1,2,1,1,4,2,3,4,5,5,2,5,2,3,1,5,5,2,2,1,1,3,3,5,1,1,5,2,1,3,4,4,4,5,5,3,4,1,1,2,5,3,5,3,2,1,2,5,4,3,2,5,3,2,4,1,4,1,1,5,5,3,4,2,5,1,1,2,1,4,5,4,4,1,2,4,1,5,5,4,3,4,3,4,5,2,3,1,1,4,4,4,2,5,2,1,4,2,1,2,1,1,2,5,3,2,3,5,5,3,1,5,3,1,5,2,2,2,2,3,3,1,2,4,2,2,1,2,1,3,3,2,5,2,1,5,1,5,5,4,3,5,2,3,3,2,4,3,3,2,4,3,1,3,2,1,1,2,5,2,4,5,5,1,4,2,4,2,2,1,5,2,1,5,1,2,5,1,5,4,4,3,4,1,3,2,5,3,4,4,3,5,4,5,2,3,3,5,3,3,5,5,4,5,5,4,4,5,5,5,3,1,2,5,2,1,5,1,3,3,1,1,5,2,3,2,2,2,3,1,5,4,4,2,1,3,4,1,2,2,2,3,3,1,2,4,3,1,5,4,5,1,3,1,1,3,2,2,5,2,2,2,1,4,1,4,1,1,1,3,3,4,5,2,5,1,5,3,5,2,4,4,5,4,4,1,4,4,2,4,3,1,2,1,4,4,2,4,2,5,2,2,4,5,2,3,3,4,3,3,5,5,4,3,4,4,3,5,4,4,5,2,2,4,1,5,1,5,3,1,4,3,5,1,4,2,3,3,5,5,2,5,2,3,3,1,3,1,2,2,5,5,2,5,4,4,3,3,4,2,3,2,5,1,4,3,4,1,2,3,3,2,4,2,3,1,4,1,3,4,1,1,3,4,5,5,5,5,5,5,3,1,4,5,2,1,5,2,3,1,2,2,2,5,5,5,4,2,1,2,2,4,4,2,5,1,1,2,2,1,2,2,2,4,4,2,5,5,3,1,1,3,2,2,1,5,5,2,2,5,5,4,5,3,3,2,3,4,2,2,3,1,4,4,5,3,3,5,5,5,4,3,2,1,2,3,3,3,3,2,5,3,4,4,5,1,4,5,4,5,1,3,2,4,5,2,1,5,4,5,1,1,5,4,5,4,5,2,5,1,1,2,5,3,1,2,1,3,1,3,4,2,1,1,3,1,5,5,1,4,1,4,1,2,3,1,5,1,5,1,1,4,2,2,4,3,2,1,1,3,2,3,1,2,3,3,1,2,3,3,2,3,4,1,1,3,3,3,1,5,2,3,3,2,1,1,3,1,2,2,3,3,4,1,4,4,3,2,2,1,5,5,4,3,1,4,5,4,2,2,1,1,2,5,2,5,2,4,4,4,2,5,3,3,1,2,1,3,2,5,5,4,2,1,4,2,4,3,2,5,4,3,1,2,3,1,4,4,2,1,4,3,1,2,3,4,3,2,3,3,4,3,3,1,1,2,1,3,3,3,1,2,3,1,5,1,2,4,2,4,1,1,4,3,3,1,1,5,5,1,1,4,5,4,1,2,2,1,1,5,1,5,3,3,4,5,3,5,3,4,3,4,1,5,2,1,5,2,2,4,3,1,2,2,3,5,5,4,3,5,2,1,3,2,4,1,3,4,4,3,1,5,3,3,4,3,4,4,4,4,5,3,4,2,1,5,3,5,1,1,2,2,1,4,1,3,2,1,1,1,4,1,5,1,4,3,4,1,4,1,1,3,1,4,5,5,1,4,5,3,4,1,5,2,2,5,3,2,2,4,5,2,2,4,1,1,4,3,4,4,4,5,5,3,2,5,5,5,2,5,3,5,3,3,2,3,5,1,4,1,2,3,3,2,4,2,5,4,4,3,2,5,3,3,2,2,5,5,2,5,5,1,3,4,5,3,5,2,5,3,1,3,5,3,2,1,4,3,3,4,1,4,1,1,5,5,1,4,4,1,5,4,1,2,2,4,4,2,3,1,4,2,2,2,2,2,4,3,4,5,2,5,1,4,5,5,3,1,2,2,3,4,3,5,1,4,1,3,3,2,4,2,4,3,5,5,1,3,2,5,5,5,2,1,4,3,1,2,2,4,2,5,3,2,5,5,3,3,4,5,3,4,1,4,3,3,4,2,4,1,1,3,1,2,3,1,4,1,5,4,4,1,4,2,2,4,2,1,3,1,1,1,3,5,4,3,4,2,3,5,5,5,1,5,1,3,2,3,2,5,4,4,3,4,4,3,4,2,1,1,3,2,1,1,4,1,4,4,5,4,4,1,1,2,5,2,3,5,2,1,2,2,1,4,1,2,2,1,3,5,1,3,1,3,5,4,5,5,3,4,5,1,4,2,4,5,4,4,2,3,5,1,2,3,4,1,2,1,2,1,3,5,1,3,4,4,2,2,3,2,5,4,4,3,4,5,3,1,1,3,3,4,2,4,1,5,3,4,1,5,2,2,1,3,1,1,5,5,4,1,3,5,1,4,5,4,2,5,5,2,1,3,5,1,2,4,4,3,1,2,2,4,1,4,3,2,2,3,3,5,2,2,2,3,4,2,2,3,5,4,4,3,1,3,3,2,3,4,4,1,1,5,4,1,5,3,3,1,3,2,5,1,2,4,4,4,2,3,1,1,5,2,5,3,1,1,4,3,5,5,4,4,1,1,1,1,3,4,1,4,2,4,5,4,2,1,5,3,1,3,2,4,1,1,2,2,1,5,2,3,4,4,1,4,3,5,4,1,4,4,2,3,1,5,5,1,5,2,1,2,4,5,3,3,4,4,2,1,5,4,1,4,3,4,5,3,4,2,5,2,3,3,5,5,2,3,5,5,3,1,1,5,2,2,1,4,4,3,5,3,2,2,3,5,5,4,2,3,3,4,4,5,5,3,2,3,5,3,5,4,4,1,3,4,4,2,2,2,5,1,3,4,1,2,3,2,1,4,1,1,2,3,5,4,5,4,3,4,2,2,4,1,1,5,2,3,4,3,2,1,3,1,5,5,5,2,5,3,5,1,3,2,3,1,3,2,1,4,4,4,3,5,1,4,4,2,3,4,5,4,3,1,3,3,2,3,2,5,2,1,2,3,4,3,5,4,4,5,1,3,4,3,5,5,2,5,5,1,4,1,4,1,1,1,5,4,1,2,4,5,1,5,2,5,5,2,4,3,3,1,4,1,1,5,4,5,2,3,3,1,4,2,4,2,5,3,3,4,5,5,2,1,3,4,1,1,2,2,2,2,1,5,1,3,5,3,3,3,2,1,1,5,5,4,3,3,2,4,3,2,2,1,5,1,1,3,1,4,5,1,5,4,4,2,5,4,5,2,5,2,4,2,4,3,2,3,3,5,5,2,3,4,5,3,2,1,2,2,2,3,4,3,5,1,3,2,4,1,1,1,5,2,4,3,3,4,3,1,3,5,1,5,4,3,2,3,3,5,2,3,2,5,1,5,3,4,1,5,4,4,3,5,5,4,4,3,5,4,4,2,1,1,3,1,5,1,3,2,5,5,1,4,3,3,5,3,3,3,3,4,5,1,3,2,1,1,4,1,4,2,1,4,4,3,1,2,2,4,1,3,5,5,3,2,3,1,2,4,2,5,2,5,1,3,1,2,3,2,4,2,5,1,4,4,3,3,1,5,3,4,3,5,1,3,4,3,1,4,4,5,2,4,3,5,2,1,3,5,4,1,1,3,1,5,4,4,4,1,3,4,2,4,1,3,5,2,2,5,4,2,5,2,2,2,1,2,5,5,5,3,4,5,4,3,4,1,2,1,2,5,3,5,2,5,5,3,1,5,2,5,2,4,4,3,4,5,2,1,2,3,5,3,3,5,3,1,3,4,2,3,3,2,4,2,3,3,1,5,2,4,5,4,4,5,2,1,4,5,4,1,2,5,3,3,4,5,5,4,1,4,3,4,2,1,1,1,3,2,5,5,1,5,5,3,5,3,3,5,1,4,1,3,3,2,2,1,2,3,3,5,3,4,3,3,4,1,4,4,1,2,3,4,4,1,3,3,3,3,1,4,4,1,3,3,1,1,2,4,5,5,1,2,1,4,1,3,5,2,1,1,1,3,3,3,1,5,5,5,1,4,2,3,1,2,3,4,1,2,5,2,1,5,3,4,3,1,1,1,1,4,2,1,4,5,1,2,4,5,5,3,2,4,2,5,3,2,2,4,1,5,2,5,4,2,3,1,3,3,4,3,2,3,3,2,3,5,3,4,5,2,1,4,1,5,3,2,5,1,4,2,1,2,2,4,4,2,5,1,1,3,2,1,4,3,3,4,3,5,1,4,2,5,5,1,4,5,3,2,1,3,2,1,4,2,5,2,2,5,3,1,4,3,1,2,1,5,2,2,2,1,5,3,1,4,3,2,5,4,4,2,3,4,4,4,1,3,1,2,4,4,1,1,3,2,3,1,1,3,4,2,4,2,2,3,5,2,5,2,5,3,5,3,2,3,1,5,5,3,5,4,2,3,3,4,4,2,3,4,3,3,2,2,4,2,3,1,2,5,2,1,2,5,1,5,2,1,3,5,4,5,1,1,3,3,4,4,3,3,2,1,2,4,2,3,3,4,1,3,5,1,3,3,1,5,3,2,4,1,4,3,2,4,1,5,3,1,3,4,3,2,3,5,5,5,3,4,1,4,5,4,1,5,2,3,3,1,2,5,5,2,5,4,2,1,3,4,3,2,3,3,4,2,2,3,1,2,3,5,5,5,2,4,5,4,1,3,3,2,4,2,5,3,5,1,4,4,5,4,3,4,1,1,3,1,3,5,1,5,4,2,5,3,4,3,4,2,2,2,3,2,5,4,5,3,1,1,4,5,5,1,2,3,4,1,4,2,5,2,4,4,2,3,1,4,1,3,3,3,4,1,3,4,1,2,5,1,1,2,3,3,3,1,2,1,2,1,5,2,4,5,3,4,5,5,3,4,3,4,3,5,4,1,2,4,4,5,3,1,5,5,3,2,4,2,5,5,4,1,5,1,2,2,4,2,4,2,3,2,3,5,2,4,4,3,4,5,1,1,5,2,5,1,5,4,3,1,5,5,1,2,4,1,1,3,3,3,2,2,5,5,3,1,3,5,4,3,3,1,4,5,5,1,2,2,5,3,4,4,5,3,3,5,1,2,5,1,1,5,1,2,2,2,1,3,1,2,3,3,5,3,3,3,4,5,2,1,3,2,2,4,1,2,2,3,5,1,3,3,3,4,5,2,2,3,3,1,4,4,2,5,2,1,3,4,3,2,3,3,4,1,5,4,1,5,1,2,4,2,1,5,4,2,2,2,5,4,1,3,5,4,2,1,5,2,5,1,5,2,4,2,3,1,2,3,5,5,3,3,3,5,5,3,2,4,3,2,4,5,4,4,5,1,1,1,4,3,4,3,5,3,1,2,4,2,1,5,5,2,4,4,1,3,1,2,3,3,5,1,1,1,5,1,2,4,1,2,3,4,3,3,5,5,4,2,2,5,4,1,5,2,3,5,3,4,4,1,1,4,1,3,1,3,2,1,1,2,1,1,3,4,2,3,5,2,2,2,2,2,1,5,3,1,5,3,1,2,3,5,2,1,3,2,5,3,1,3,4,1,4,1,2,3,2,1,2,4,2,2,5,3,3,3,3,3,4,4,3,2,5,2,1,5,4,2,2,3,1,2,2,2,5,4,1,3,3,5,5,3,5,2,1,2,4,5,2,5,4,2,3,5,3,3,4,4,3,5,1,1,4,1,1,2,5,1,3,2,5,4,2,4,4,2,1,4,4,2,1,4,1,3,1,1,4,2,5,5,1,3,5,1,5,4,2,3,3,1,2,1,3,3,2,5,2,3,1,1,1,1,5,5,2,5,4,5,4,2,4,1,4,2,1,3,5,2,3,1,1,1,3,3,2,3,3,4,3,2,5,5,4,4,1,1,2,1,5,4,5,2,3,5,1,5,2,4,1,1,1,1,3,1,1,4,1,1,2,1,5,2,5,1,1,5,4,2,4,4,2,2,3,3,1,5,1,3,4,3,4,2,4,4,2,4,2,5,2,3,1,4,2,1,1,5,3,1,5,2,1,1,4,5,3,4,1,1,3,2,4,5,4,5,1,2,3,2,1,2,4,5,4,1,2,4,3,2,2,5,2,4,4,5,5,5,4,3,4,4,4,5,5,5,5,4,1,1,3,5,4,5,3,5,3,2,5,5,5,5,1,3,2,2,2,2,2,1,3,4,3,2,4,1,2,3,3,1,1,5,3,5,4,1,1,3,1,2,2,5,4,4,4,2,5,1,4,5,1,5,3,1,5,1,5,4,4,2,3,2,5,5,2,1,4,5,3,1,1,5,4,2,1,3,5,1,2,5,3,5,5,1,4,1,5,3,3,4,5,5,1,5,5,2,4,4,5,2,4,1,3,3,1,3,5,2,5,5,4,1,5,1,5,1,1,2,2,1,1,2,1,5,1,3,5,1,5,4,5,2,1,2,5,4,1,4,2,1,3,4,3,1,4,4,2,5,1,4,2,5,2,2,2,3,3,2,3,3,5,4,4,1,3,1,3,3,5,2,2,2,1,3,3,2,5,2,4,2,3,4,3,2,1,3,5,4,4,1,3,3,4,4,3,1,5,3,1,4,2,4,1,1,1,4,5,4,4,1,1,1,4,2,5,5,3,5,4,3,2,5,3,5,4,3,1,2,3,3,5,3,4,3,5,1,2,5,3,4,2,2,3,2,3,4,2,3,2,1,2,2,2,4,3,1,4,2,1,5,3,5,3,2,5,4,4,1,5,5,4,3,1,1,2,1,4,4,3,2,2,1,1,5,1,2,2,5,1,4,1,1,4,5,2,3,3,1,5,4,1,3,4,2,2,5,2,4,4,2,4,1,5,5,4,3,2,1,2,4,4,5,1,3,5,4,3,3,3,4,2,2,4,5,4,4,1,2,1,5,4,2,5,4,4,3,3,3,1,3,2,4,1,1,1,3,4,4,5,1,4,4,1,4,4,4,1,2,3,4,4,5,5,2,4,1,3,3,2,4,3,2,3,1,3,1,5,5,2,3,1,1,4,2,1,3,1,2,2,3,4,2,1,2,5,1,5,1,2,3,3,1,5,5,5,2,4,3,4,4,1,3,3,1,4,4,4,1,2,1,3,5,1,5,4,5,4,2,5,3,1,2,5,3,1,2,5,2,1,4,3,5,3,2,5,2,4,3,4,2,4,1,4,1,1,3,5,2,1,5,1,1,1,2,3,2,4,5,5,4,4,1,3,5,3,2,5,1,3,2,5,2,5,1,2,1,1,3,4,5,3,2,5,4,2,4,3,5,2,4,2,1,3,2,2,4,3,1,2,5,4,1,1,1,2,3,2,2,5,2,5,2,1,5,4,2,1,3,4,3,4,3,4,4,1,3,5,5,2,2,4,1,4,4,3,4,1,2,5,2,1,2,1,3,3,5,2,5,3,4,3,3,2,5,4,1,3,3,5,3,4,4,3,2,4,2,4,1,4,3,1,4,3,2,3,4,4,3,5,4,4,3,5,5,3,2,3,1,3,5,3,4,2,1,5,2,2,3,3,4,1,3,2,1,2,2,2,3,1,4,2,5,4,5,3,3,1,1,3,4,1,2,5,1,4,2,5,1,2,5,1,2,2,3,5,3,1,1,1,5,4,4,3,5,3,3,4,3,5,1,1,1,2,5,3,2,3,5,4,2,3,1,2,4,4,1,2,5,4,3,2,2,2,4,4,1,5,2,5,5,4,2,1,4,3,4,2,1,2,4,2,5,1,4,1,1,1,5,3,5,5,4,3,1,3,4,1,3,4,5,1,2,4,3,3,4,1,1,1,3,2,1,2,1,1,2,5,3,5,1,2,2,1,2,1,2,4,5,5,1,1,2,1,4,2,5,5,3,1,4,3,3,5,2,1,1,4,4,4,4,3,5,1,4,5,3,1,4,5,1,3,5,2,2,3,2,1,1,5,1,1,1,2,4,5,3,1,4,1,3,2,2,1,4,3,1,5,3,5,5,2,1,5,4,2,1,4,4,1,2,1,2,4,4,4,5,3,5,5,2,3,1,5,2,1,1,1,2,2,3,1,4,3,3,2,5,1,3,4,4,5,2,1,4,5,5,5,1,5,2,2,2,1,3,2,1,3,1,1,2,3,5,1,4,4,1,3,4,3,1,4,2,5,4,5,4,1,3,2,4,2,1,2,3,1,5,3,3,1,4,3,3,2,4,3,2,3,5,2,3,1,3,4,2,5,4,5,3,1,1,2,2,1,3,3,1,1,3,1,5,4,3,3,4,5,5,4,5,3,3,3,3,1,1,2,5,5,5,4,4,3,4,2,3,2,1,2,3,5,5,4,4,2,5,5,2,3,3,4,3,4,1,3,1,3,4,2,2,3,5,4,5,5,4,4,5,1,1,3,5,2,2,2,2,3,4,5,4,5,1,1,4,5,3,2,3,3,3,3,2,4,1,2,2,1,2,1,2,2,4,4,2,4,3,3,4,3,5,5,1,1,1,2,2,2,5,2,2,3,3,4,3,1,3,5,5,5,5,5,2,4,1,2,1,1,3,2,3,2,2,5,2,4,4,4,5,5,1,1,5,3,1,2,4,4,1,4,3,3,3,4,3,5,5,3,4,1,3,2,1,2,4,3,4,5,4,3,3,5,3,1,1,3,5,5,2,4,2,5,1,3,2,3,4,3,4,1,1,4,3,4,3,4,3,1,2,2,5,2,2,2,4,5,5,3,2,2,2,2,1,4,3,4,5,2,5,2,5,2,2,5,4,3,3,2,2,3,5,4,4,5,5,4,4,2,4,2,2,3,1,1,5,2,2,2,4,5,5,5,4,5,2,1,1,3,2,4,3,2,4,3,3,5,5,5,2,2,1,5,3,2,3,3,1,5,2,3,1,5,4,4,4,3,5,1,4,4,3,1,1,1,1,5,2,3,3,5,3,3,4,4,2,1,4,2,3,2,1,4,3,3,3,3,5,1,2,2,1,4,4,2,3,5,3,5,1,3,4,4,5,3,2,1,2,2,5,4,4,4,4,4,3,2,4,1,2,2,2,1,4,4,4,3,5,1,4,2,4,4,3,4,1,4,1,3,1,2,1,4,3,3,5,3,1,2,4,3,3,2,4,1,3,2,3,5,3,1,1,5,5,5,2,4,2,2,1,3,3,4,3,1,1,2,2,3,5,3,4,5,1,5,1,4,5,1,5,5,1,2,5,5,4,1,2,4,4,1,4,5,2,5,1,4,5,1,3,2,2,3,2,1,1,2,3,3,4,5,1,4,5,4,3,5,1,5,1,4,2,5,1,2,4,5,1,3,1,3,1,2,3,5,5,3,1,5,4,5,3,1,3,4,1,3,5,2,3,2,4,1,2,3,2,5,4,1,3,2,1,1,5,5,5,4,5,4,5,3,4,4,2,2,5,2,5,3,1,1,5,1,4,2,3,4,4,5,1,1,1,3,4,4,2,5,2,3,3,4,4,5,1,2,2,3,3,5,2,3,3,2,2,2,3,3,5,2,4,3,5,2,3,2,5,1,2,4,3,3,2,3,5,5,2,4,2,5,1,1,1,3,2,5,4,2,1,4,1,4,3,3,3,1,2,4,3,1,2,3,3,2,3,4,1,5,3,4,1,1,5,4,5,2,3,2,2,5,4,4,3,1,5,1,1,1,4,4,5,4,3,5,3,1,2,5,1,1,4,4,5,4,4,3,1,4,2,1,3,5,1,2,5,5,3,1,2,1,2,5,3,1,1,1,1,3,2,3,2,4,5,2,1,4,5,1,5,5,1,1,1,5,3,1,4,3,4,3,5,1,3,2,2,5,2,3,2,4,4,3,2,4,2,3,5,3,1,4,5,2,1,2,1,2,1,1,1,2,1,3,3,1,4,5,3,5,3,5,4,3,5,3,4,2,5,2,5,2,2,5,2,1,3,4,2,3,1,1,1,5,2,3,1,3,3,5,4,5,5,3,3,2,4,4,2,2,1,5,2,5,5,5,4,4,4,5,5,3,1,1,5,3,2,2,4,3,4,3,2,5,5,5,4,5,2,2,1,3,1,2,1,5,5,5,2,5,3,1,4,5,3,3,1,5,2,3,5,5,5,5,4,2,4,4,4,4,5,2,3,1,1,3,2,1,4,1,5,5,4,1,2,3,2,3,3,1,5,3,3,1,1,4,1,2,4,2,3,5,5,2,5,4,3,2,3,3,3,3,5,1,4,4,2,1,4,2,5,1,1,3,5,5,5,5,3,3,3,2,1,3,3,3,4,1,4,1,1,3,1,3,3,3,3,3,5,2,4,3,2,1,4,2,3,1,4,2,3,3,1,1,4,2,2,1,4,5,4,3,2,1,4,4,1,2,5,1,2,3,2,2,1,3,4,4,4,4,1,4,3,1,2,4,1,5,4,2,4,5,2,4,4,4,3,4,4,5,4,5,3,4,4,2,2,2,2,3,5,2,4,2,5,3,5,5,5,3,1,5,1,4,4,3,5,1,2,3,2,3,3,4,4,5,5,3,3,5,1,1,4,2,5,4,3,5,3,4,4,5,5,1,5,5,5,4,3,4,1,1,2,5,2,2,5,5,2,1,5,5,2,3,3,4,3,4,3,1,5,3,2,3,4,3,4,3,3,3,3,2,1,4,1,4,4,5,2,1,4,2,2,5,1,1,1,3,3,2,2,2,3,5,3,5,5,1,2,4,2,2,1,2,4,1,3,5,2,5,2,4,2,5,5,1,2,3,2,5,4,4,1,5,2,1,1,2,3,1,1,2,1,5,5,3,3,2,1,1,2,5,1,1,2,5,3,4,4,5,4,2,3,1,5,1,3,4,5,5,3,3,3,5,4,3,3,5,1,4,4,4,2,3,2,2,1,3,1,5,1,2,5,4,2,1,2,2,4,1,2,3,5,5,1,5,1,2,1,3,3,5,3,3,5,1,2,4,5,4,5,4,4,1,5,5,3,1,1,2,4,3,2,2,3,4,5,5,5,3,3,4,2,3,3,2,4,3,5,1,2,1,2,4,5,2,2,4,1,5,1,4,5,3,5,1,3,3,3,2,1,4,2,2,5,4,1,2,5,2,4,4,1,1,1,4,2,1,1,1,2,3,5,3,5,2,3,3,3,2,2,1,1,1,3,4,2,2,3,5,5,3,4,4,4,5,1,5,2,3,1,3,1,5,3,3,5,1,1,2,5,3,5,3,1,1,2,4,4,4,1,5,5,5,4,4,5,4,2,5,4,5,3,2,4,2,2,3,3,3,1,3,5,3,2,4,1,5,4,3,3,4,5,4,1,5,3,3,4,1,4,2,5,5,1,1,5,1,1,5,3,4,3,5,5,2,1,2,5,3,5,2,4,2,5,5,1,3,5,5,5,4,5,3,5,2,5,3,2,4,4,3,4,4,5,3,1,2,4,4,3,3,5,3,4,4,2,4,3,2,3,4,2,5,4,2,2,2,2,2,2,3,4,1,1,4,1,3,3,1,2,3,5,3,2,2,5,2,5,1,4,3,5,3,5,4,2,5,3,3,3,3,2,4,3,1,4,3,5,2,2,2,4,2,4,4,5,2,4,3,5,1,2,3,2,4,1,3,5,4,4,4,4,1,5,5,1,4,3,1,3,4,5,1,3,2,4,4,2,2,4,1,2,2,2,4,3,3,3,1,1,4,1,4,1,5,4,1,1,3,1,2,1,5,3,3,1,2,4,2,1,5,3,3,4,2,2,2,5,1,2,4,2,2,3,5,4,5,4,1,4,2,5,4,5,5,3,1,4,2,4,2,4,1,3,4,3,3,5,3,2,3,5,3,2,1,3,5,1,3,3,3,3,5,3,3,1,3,1,2,5,5,4,2,3,5,4,3,4,4,5,5,4,2,2,4,2,1,1,3,4,2,5,4,3,1,4,2,4,5,5,5,3,5,1,4,2,5,2,1,3,2,5,5,5,4,3,4,4,2,4,3,4,5,2,3,3,4,2,3,3,5,2,5,3,1,1,3,1,2,3,2,1,1,4,4,2,3,4,5,5,4,5,1,1,2,3,1,4,5,1,1,2,1,5,4,3,1,4,1,2,3,5,3,2,2,4,2,2,5,4,4,4,5,5,3,4,4,5,2,3,3,1,1,1,4,2,4,2,4,3,3,1,5,4,5,2,2,5,4,4,1,5,3,1,2,5,4,2,1,5,2,5,5,4,5,5,5,4,3,1,1,4,5,3,2,1,2,2,1,4,2,1,5,5,5,2,3,2,1,1,4,3,5,3,3,2,5,4,3,4,1,2,2,2,4,4,5,2,5,4,3,4,4,2,2,4,3,5,5,2,5,1,1,1,5,5,1,3,4,2,5,3,5,2,3,2,3,2,3,3,4,2,1,5,5,1,4,2,1,3,5,5,4,4,3,2,5,3,5,4,1,3,5,3,4,3,2,1,1,4,3,4,5,2,4,4,4,5,1,4,4,5,1,2,2,3,2,4,3,3,1,1,3,3,5,4,1,5,1,4,5,3,2,5,5,5,1,5,3,4,4,1,2,3,1,3,4,1,3,1,1,2,4,4,4,4,5,3,3,5,1,3,4,5,4,2,4,2,3,5,4,4,2,1,3,1,1,2,5,3,2,2,3,1,1,5,1,3,4,5,2,3,5,3,3,3,5,2,4,3,5,3,4,3,3,5,2,5,1,4,1,1,5,1,5,3,5,5,5,2,5,1,5,5,3,4,2,4,2,2,4,2,2,2,5,2,3,3,5,1,4,3,3,3,3,4,4,4,5,4,1,3,5,5,5,4,1,2,5,1,2,2,1,4,1,5,2,2,1,1,1,3,2,3,1,1,2,4,3,3,1,2,3,4,4,4,3,1,4,2,2,1,3,1,5,5,5,1,2,2,2,4,2,5,4,2,4,1,4,5,1,4,4,4,1,1,2,1,3,1,5,2,1,1,5,2,1,2,4,2,1,5,5,2,4,3,5,4,5,4,2,1,2,1,1,5,2,5,5,3,2,3,1,5,5,1,5,2,2,3,5,5,1,3,4,1,2,5,4,5,4,2,2,4,4,2,2,1,5,4,4,4,4,3,3,1,3,3,3,2,1,3,4,5,1,5,5,1,1,4,2,5,3,5,3,1,2,5,4,3,1,5,4,5,2,3,3,1,1,3,4,2,5,2,1,3,2,3,5,3,2,3,2,4,5,2,1,5,2,2,5,4,4,2,4,1,3,4,5,1,1,1,5,2,4,2,2,5,5,3,2,3,5,5,4,3,5,4,5,2,5,3,4,4,3,5,2,1,4,2,3,1,3,4,2,5,5,2,4,4,5,5,5,5,1,5,5,1,3,3,2,1,5,1,2,1,3,3,2,2,1,3,4,2,3,4,5,5,4,4,3,5,1,3,3,4,5,3,3,2,5,4,1,5,1,4,3,5,3,1,2,5,1,3,4,5,3,5,1,4,1,2,2,5,1,2,1,1,2,5,3,3,1,1,2,1,4,5,2,5,3,3,4,3,2,1,3,3,3,3,5,3,4,1,4,5,2,5,4,1,4,2,1,5,4,2,5,3,5,5,1,2,3,3,3,4,1,5,4,4,3,3,3,5,3,2,2,2,1,2,1,2,2,3,3,4,2,4,5,4,4,1,5,5,4,1,4,1,3,5,5,5,2,2,4,3,4,2,4,2,5,5,5,2,3,3,4,4,5,1,3,2,4,1,4,4,5,3,5,4,3,5,5,3,2,4,4,2,4,5,1,2,3,5,3,2,1,5,3,3,4,5,3,3,5,1,1,1,4,4,4,2,4,5,2,4,2,2,4,3,1,2,1,3,5,4,5,3,4,3,4,1,3,1,2,1,4,5,1,3,3,4,1,3,3,5,3,4,2,2,1,1,4,1,2,1,4,3,4,2,2,3,2,5,3,5,4,3,1,3,3,4,1,2,1,2,4,2,1,2,4,5,3,4,2,1,5,3,4,4,2,1,4,5,2,3,4,5,5,5,4,4,4,2,3,4,1,2,3,1,1,3,2,5,4,5,5,1,1,3,3,4,3,3,4,2,5,5,5,2,3,4,4,4,1,4,1,3,4,5,4,1,4,5,2,4,5,3,4,5,5,5,2,2,3,2,2,4,1,1,2,2,3,4,5,2,3,5,3,4,4,5,4,5,1,3,1,3,3,2,1,4,5,1,3,4,2,3,2,5,2,2,3,5,5,5,5,2,5,4,4,5,2,1,2,5,1,5,5,3,5,1,3,4,5,5,1,5,3,2,4,1,5,5,1,2,3,2,1,1,3,2,4,3,2,5,2,2,3,4,5,3,2,1,5,3,5,2,5,5,2,5,3,1,3,4,4,5,2,1,3,2,4,3,1,1,3,1,3,4,1,3,5,3,4,3,3,1,1,4,5,1,4,1,4,5,3,3,1,4,4,5,5,1,4,2,5,5,2,5,3,5,5,4,5,1,3,5,5,5,5,2,3,3,1,3,2,4,2,1,5,5,2,1,4,3,2,5,3,5,3,1,2,5,2,2,4,3,3,3,2,4,2,3,3,5,4,3,2,3,3,2,1,2,4,1,2,2,1,2,1,4,1,5,4,3,5,1,4,4,5,2,5,3,4,4,2,5,4,5,3,3,3,4,3,1,5,5,5,1,4,3,1,2,1,1,3,3,5,4,2,4,2,2,2,2,3,4,3,3,5,3,1,4,5,1,5,5,3,5,1,4,2,2,2,1,4,5,2,3,3,2,2,1,2,1,5,1,2,1,3,5,3,4,4,5,2,4,4,5,5,5,5,4,3,1,3,5,4,5,1,3,4,5,5,5,2,1,3,5,3,2,4,4,5,3,2,3,3,1,4,1,2,5,5,1,5,5,1,5,1,1,1,5,3,2,5,2,3,5,5,2,2,1,1,5,3,3,5,4,5,4,4,5,3,1,3,1,5,3,1,5,2,5,4,5,5,4,5,4,1,4,2,1,3,4,3,1,1,4,3,4,1,1,2,5,5,3,5,3,3,5,4,5,2,1,4,1,1,1,4,4,3,3,1,4,1,1,3,2,5,1,3,1,1,1,3,4,5,5,2,3,3,2,3,4,2,2,4,4,1,5,2,3,5,1,5,2,5,2,5,2,5,4,4,1,3,2,2,1,4,1,1,3,3,4,2,1,5,5,3,2,4,3,2,4,2,1,3,5,3,3,1,5,3,5,5,1,1,5,4,4,1,4,2,4,5,2,2,2,3,5,2,3,2,1,3,5,2,1,1,3,4,2,3,5,3,3,4,2,3,1,1,1,2,2,2,5,5,2,2,4,4,5,3,5,4,3,5,5,3,5,4,1,3,3,1,5,2,3,5,2,5,4,1,3,1,4,4,4,4,3,4,5,5,5,4,1,2,5,4,1,2,3,4,5,1,5,5,4,2,3,5,3,1,4,3,3,5,4,3,1,4,4,2,1,2,4,2,4,3,4,3,3,3,5,5,4,2,1,4,4,5,2,1,5,5,2,3,2,2,4,3,2,5,1,4,3,1,3,5,2,5,4,3,5,4,3,4,4,1,2,3,5,1,5,5,3,3,2,3,2,3,4,2,3,5,1,4,1,2,2,2,1,5,3,3,3,2,1,4,2,2,1,5,3,4,1,2,1,5,1,1,3,4,5,3,1,5,4,1,1,1,3,5,2,4,5,3,2,3,3,5,4,2,2,5,1,4,4,4,2,1,3,3,3,3,1,1,3,3,5,3,2,5,1,2,1,5,4,2,3,3,3,1,1,4,1,3,1,5,3,2,3,1,2,4,5,1,4,2,2,1,5,4,3,1,1,5,5,2,5,3,1,1,5,2,1,5,4,3,3,4,2,2,5,5,3,1,3,1,1,2,3,5,2,5,5,4,3,4,5,1,5,1,1,5,5,5,2,5,1,5,5,5,5,1,5,4,3,5,3,5,4,3,2,3,3,3,5,2,4,4,4,5,3,5,1,2,2,1,2,2,2,5,4,3,5,2,5,5,2,1,3,1,2,3,2,1,1,2,1,1,3,5,5,4,4,3,1,5,5,1,3,3,2,2,3,2,5,4,5,4,5,4,2,5,5,1,4,5,5,3,1,1,2,1,2,3,1,3,1,1,4,4,1,2,5,2,4,3,1,5,3,3,5,4,1,4,4,5,5,2,3,2,3,1,2,1,2,3,3,5,5,3,3,3,4,2,2,5,4,4,2,2,4,4,1,3,4,2,1,4,2,4,3,2,1,1,2,3,5,3,3,4,5,2,1,1,2,1,1,4,2,1,2,4,4,2,2,1,4,2,5,1,1,1,4,3,4,5,4,4,1,2,4,3,4,2,1,4,2,5,4,5,1,3,4,3,5,1,3,5,3,1,4,3,1,5,3,4,2,2,4,1,2,4,5,5,1,1,1,1,5,1,5,4,4,5,5,5,1,2,3,2,2,1,3,2,5,3,3,1,2,2,2,5,2,1,3,4,1,4,2,4,1,5,1,3,2,4,2,1,4,4,4,1,3,4,3,1,1,3,2,2,2,2,2,3,1,4,5,5,5,2,2,1,1,2,2,1,4,3,4,4,2,2,1,5,2,2,3,1,5,5,5,5,3,2,4,4,1,4,4,5,3,4,4,4,5,4,3,5,5,1,3,4,3,2,4,3,5,2,1,5,4,2,4,1,2,5,5,1,2,4,5,2,2,1,4,1,4,2,2,2,1,3,4,2,4,2,2,3,1,2,5,4,5,3,3,2,1,5,2,5,3,1,5,3,1,5,2,4,1,3,3,5,3,2,5,2,1,3,1,2,5,5,1,2,3,2,3,1,2,3,1,2,2,4,2,2,5,4,3,5,1,5,3,5,5,4,3,5,1,1,1,4,3,3,4,1,4,2,3,3,1,3,1,4,3,2,3,2,3,2,1,1,5,4,2,5,3,2,5,1,2,5,4,2,2,1,1,5,3,3,5,3,1,3,4,5,4,2,4,5,5,5,5,4,2,5,3,5,4,5,4,4,2,4,2,4,5,1,5,1,3,2,1,5,3,3,4,4,5,5,3,1,5,1,4,1,1,4,3,3,5,4,2,1,1,1,4,3,1,1,3,1,1,1,2,5,4,2,5,1,1,5,5,5,2,1,1,5,4,2,3,4,1,5,4,4,1,3,3,1,4,5,3,5,1,2,4,3,3,5,5,2,4,2,1,3,2,3,3,3,1,4,1,3,5,5,2,5,4,1,2,4,1,5,1,2,5,2,5,1,4,1,2,4,1,2,3,1,3,4,3,5,1,4,4,2,4,5,3,1,2,2,5,4,4,5,5,5,3,4,5,2,1,5,1,3,2,4,2,4,3,5,5,4,5,2,2,3,1,2,5,3,2,2,1,1,1,5,5,3,4,2,5,1,5,1,1,4,4,2,2,2,1,2,2,4,5,4,1,5,5,4,1,1,3,4,5,5,4,3,2,4,5,4,5,3,2,5,4,3,5,1,4,5,2,4,2,4,2,2,1,1,4,1,2,1,2,5,3,5,4,2,1,2,2,2,2,4,3,4,5,1,3,1,3,5,3,3,2,2,4,3,5,4,3,2,1,1,5,4,1,1,4,2,2,4,5,3,1,2,2,4,1,5,5,3,3,4,3,5,3,2,5,3,3,1,1,1,2,3,3,2,3,1,5,3,2,1,4,5,3,4,2,4,5,1,3,5,3,5,2,1,2,1,3,5,2,1,5,1,5,4,3,1,2,5,2,4,1,4,3,5,2,2,1,3,3,5,3,5,1,4,5,1,2,5,2,4,5,1,2,4,1,5,1,5,4,2,5,1,1,3,2,1,5,4,4,1,1,3,1,3,4,1,5,3,5,5,4,4,3,5,3,4,2,4,3,2,5,3,4,4,3,2,2,1,5,2,3,4,5,4,4,5,1,5,5,1,5,1,2,3,3,3,3,3,1,4,3,5,4,1,4,1,3,4,1,3,3,4,3,3,5,2,3,4,4,2,3,1,2,5,4,4,2,2,4,4,1,3,2,1,2,4,4,2,3,2,1,1,3,2,2,1,3,4,4,4,3,3,4,2,1,4,4,2,1,1,2,4,3,4,3,2,3,1,2,5,4,5,3,3,3,1,1,1,1,5,2,5,3,5,4,4,5,3,4,5,5,4,3,4,2,3,2,2,3,2,3,4,3,1,5,5,3,3,4,1,1,1,4,1,3,4,3,4,2,2,2,3,2,2,2,1,3,4,1,1,4,5,4,5,1,1,1,1,3,3,5,5,3,5,4,5,1,1,1,5,3,2,3,4,5,4,5,3,5,2,1,1,3,3,4,2,2,3,2,4,1,4,1,3,5,2,4,4,3,4,1,2,1,4,5,1,5,4,4,3,2,4,4,5,4,5,4,2,1,1,1,4,1,1,4,2,5,3,4,4,4,1,2,3,1,1,3,4,5,1,2,1,5,4,1,2,3,5,5,5,4,2,1,5,2,3,3,5,5,2,3,5,5,2,5,3,4,2,1,2,5,5,5,2,2,5,1,5,2,2,5,4,2,3,1,1,5,3,2,3,4,2,1,2,4,1,1,2,3,1,1,5,1,2,5,2,2,1,4,5,5,1,1,4,2,4,1,4,3,1,3,3,1,4,2,4,1,4,1,4,5,3,1,3,5,1,4,5,2,2,3,3,1,5,5,3,3,1,1,3,3,3,2,3,5,1,3,4,2,4,1,3,2,1,2,1,5,1,1,4,2,3,4,4,4,4,3,3,5,5,3,2,4,2,2,1,3,4,5,3,2,3,1,1,3,5,1,4,4,5,2,1,3,1,4,3,5,1,1,2,1,2,2,4,3,2,4,4,4,5,4,5,5,1,4,4,1,4,5,4,5,2,5,5,1,1,5,2,3,2,4,3,4,3,4,4,3,1,2,1,4,1,1,1,5,3,3,1,1,4,1,2,2,5,1,5,3,2,5,3,3,3,5,1,5,1,3,1,3,1,1,4,1,4,2,5,1,2,2,5,3,2,3,5,4,3,2,4,5,3,2,4,3,5,3,2,4,5,1,3,3,5,4,1,1,4,4,1,5,4,4,3,3,5,4,2,2,4,1,5,3,4,2,4,3,1,5,3,4,4,2,4,3,3,2,2,2,2,2,3,2,5,2,3,4,1,4,1,2,2,3,3,4,1,2,1,2,2,1,2,4,3,5,5,3,4,5,3,3,2,3,1,4,2,1,2,2,2,5,2,1,3,5,4,2,1,3,3,4,2,2,2,2,5,3,5,4,2,1,4,1,5,4,5,1,5,4,3,5,3,5,1,2,1,5,1,1,2,5,1,3,2,3,3,4,1,5,3,1,1,2,1,4,1,1,1,4,4,4,4,3,5,5,2,5,1,4,4,5,4,3,3,2,3,4,4,1,2,1,4,1,3,4,2,4,1,5,3,4,5,5,2,1,5,1,4,4,4,5,2,4,2,4,5,1,4,1,4,4,5,3,3,5,2,5,3,2,5,2,3,3,1,2,5,1,1,2,5,4,4,5,1,5,4,5,3,5,1,4,3,5,1,3,4,2,5,2,1,2,1,3,2,5,1,4,5,4,5,5,2,5,2,1,1,2,3,4,5,3,3,5,1,2,5,5,5,3,4,3,2,4,4,1,1,1,1,2,2,3,2,3,2,1,5,1,2,5,2,2,1,2,4,4,1,1,3,4,2,2,3,4,2,2,5,5,1,2,1,2,5,3,4,2,1,3,1,1,5,2,1,2,3,4,2,4,4,3,4,2,3,1,1,1,2,5,1,3,4,3,5,2,5,5,5,4,4,4,2,5,5,4,1,5,5,4,4,2,4,1,2,3,4,1,3,3,1,5,2,4,2,3,3,5,3,4,1,5,4,1,4,2,4,1,3,1,4,4,2,3,5,5,2,3,4,2,3,4,3,5,5,2,5,5,5,3,4,5,2,5,1,5,5,3,3,1,1,5,4,2,3,5,4,2,1,3,4,2,4,2,5,5,3,5,5,1,5,4,3,5,4,3,1,2,4,4,5,5,5,3,2,5,1,2,1,2,2,2,5,1,4,3,4,3,4,5,4,1,2,2,5,5,1,2,5,4,3,1,4,5,2,3,3,1,2,5,3,1,2,5,4,2,4,1,1,5,3,2,1,5,1,1,5,2,2,2,1,5,1,2,2,5,5,5,5,1,4,1,2,1,5,5,2,4,5,4,4,2,4,5,2,3,1,5,1,2,2,1,1,1,4,2,3,1,2,3,3,4,5,3,3,1,4,5,3,2,4,4,5,2,4,5,3,5,1,2,1,3,4,1,4,1,1,5,2,1,2,3,3,4,2,3,1,2,3,4,2,5,4,4,3,3,4,2,2,1,1,2,5,3,2,5,1,1,5,4,5,2,5,3,1,1,4,4,3,3,4,3,1,5,4,4,1,1,1,3,1,5,1,4,4,4,3,1,3,2,4,3,4,2,1,3,4,3,1,4,4,4,3,5,5,4,1,1,2,3,4,1,3,2,5,2,4,1,3,2,1,1,5,3,5,1,2,5,4,3,3,3,5,5,4,3,4,4,3,2,1,1,3,3,3,3,1,3,4,2,1,5,2,4,4,2,4,3,3,4,5,3,2,4,4,5,4,3,5,3,4,4,2,5,5,1,3,1,5,4,2,1,5,2,4,1,3,2,2,1,2,3,4,2,4,1,4,3,2,1,2,2,5,3,3,4,5,3,2,4,1,3,2,2,3,2,4,2,4,2,4,5,1,1,1,5,3,4,3,5,3,1,5,5,2,2,1,5,4,3,5,1,4,2,2,5,3,5,1,1,4,2,3,1,1,5,1,3,4,2,5,3,4,2,4,2,4,5,2,3,1,1,1,5,2,1,1,1,4,4,2,1,3,1,4,5,3,2,4,1,3,5,5,1,5,2,5,2,3,4,4,3,4,1,4,2,4,4,2,1,1,4,3,3,2,4,4,3,4,1,3,2,5,3,3,4,3,4,5,5,4,4,1,4,1,3,1,5,1,3,3,1,3,2,4,1,5,5,4,2,2,5,4,2,4,4,2,1,2,2,3,5,1,1,4,1,5,3,5,2,3,4,1,1,1,1,1,4,4,5,3,3,4,5,5,5,4,4,5,1,4,2,1,1,5,4,2,4,4,3,5,5,4,4,3,1,3,4,3,2,2,5,5,1,5,2,5,3,2,3,5,3,3,4,4,5,3,4,5,1,1,2,2,4,5,1,4,2,3,2,1,3,4,5,5,4,5,4,2,2,1,3,1,3,2,2,5,4,3,1,5,4,3,4,1,1,5,5,4,5,3,2,4,4,1,1,4,1,4,3,1,1,4,3,2,1,5,4,1,2,2,3,1,4,3,4,2,4,2,2,1,2,4,3,1,3,4,1,2,3,1,5,1,1,5,1,3,1,1,5,2,1,3,4,4,3,1,3,1,4,5,2,4,5,4,2,4,2,4,5,3,2,4,3,3,3,3,2,3,3,4,4,3,1,2,5,5,3,1,5,2,2,1,3,3,4,1,5,2,3,2,5,5,4,4,4,5,3,4,5,2,1,3,1,4,3,3,3,4,3,4,1,2,1,1,2,2,3,4,1,3,2,5,3,4,5,3,5,3,2,1,5,1,3,5,4,3,4,3,1,1,3,2,2,3,4,2,1,5,1,4,3,5,4,2,2,3,3,4,2,3,1,5,3,2,3,4,2,4,4,3,3,4,3,2,2,4,5,3,4,1,2,1,5,5,4,5,1,3,3,3,4,4,3,3,3,4,5,3,5,5,4,1,3,4,1,5,2,1,3,4,3,5,1,4,3,3,4,1,3,2,4,5,4,1,2,3,2,4,2,2,4,5,4,3,3,3,1,2,4,4,1,2,2,1,2,1,4,4,3,3,4,1,4,2,2,5,5,4,3,4,1,5,2,3,2,2,3,3,2,4,4,3,1,4,5,1,4,3,3,5,2,4,3,1,3,3,4,4,2,5,3,2,2,1,3,2,5,1,3,4,5,5,1,1,5,3,2,1,5,5,1,5,4,5,5,2,2,5,1,1,3,2,5,2,2,3,4,3,3,3,4,2,5,4,2,1,3,3,5,1,5,5,5,4,2,4,1,4,4,3,3,3,1,3,3,3,5,5,2,2,5,4,3,5,1,3,1,4,1,4,1,2,2,2,5,3,4,4,2,5,1,2,5,3,4,2,3,3,4,2,5,5,5,3,2,2,1,4,3,5,4,1,2,4,5,3,4,5,3,1,1,3,3,4,2,2,1,4,4,3,4,5,4,1,4,2,3,4,3,3,5,1,3,3,3,5,2,5,4,5,2,5,1,5,1,2,5,2,1,4,2,5,4,2,2,4,5,1,5,5,4,5,3,3,4,4,4,4,1,5,3,2,4,4,1,2,2,2,4,5,2,2,2,3,1,5,4,2,3,1,1,3,1,2,3,1,4,2,4,5,3,2,2,2,5,1,1,3,1,4,4,3,2,2,5,2,5,4,2,3,5,2,5,1,4,3,4,2,3,3,3,5,2,4,5,2,3,1,2,3,2,1,5,4,2,5,5,2,3,4,1,2,1,3,5,3,3,1,4,3,2,2,5,4,1,2,5,4,1,1,2,5,2,1,2,2,4,1,3,3,3,3,1,1,2,1,2,5,3,2,2,1,2,2,2,2,4,1,1,1,5,2,1,1,1,5,2,5,1,2,5,3,4,1,3,1,5,5,1,2,2,1,4,5,4,4,4,1,5,3,5,3,4,1,3,3,2,3,1,2,5,2,1,5,5,1,3,1,3,4,5,1,3,3,3,1,3,5,3,3,5,4,1,1,1,4,2,3,5,1,5,1,4,2,2,1,2,5,3,1,4,5,3,1,5,1,5,4,1,4,1,1,5,3,2,3,3,5,5,4,1,4,1,4,5,4,2,3,4,3,4,1,2,5,4,3,5,1,5,2,3,5,4,2,4,4,3,1,1,2,2,3,3,5,4,4,4,5,2,5,3,3,3,4,3,5,3,4,4,3,3,4,1,5,5,1,2,4,4,3,3,1,1,2,4,2,5,1,2,4,3,3,1,4,3,4,2,4,4,4,1,5,1,4,2,4,5,2,2,4,5,1,5,1,3,1,4,5,5,1,2,2,1,2,2,5,5,3,4,4,2,2,2,1,2,2,3,3,1,4,4,3,4,4,2,1,1,3,5,5,5,4,4,2,1,1,1,5,5,5,2,1,4,3,5,2,5,5,1,4,3,4,1,4,5,3,4,1,1,2,4,5,1,2,5,4,1,5,2,1,2,2,1,3,5,2,3,1,5,5,5,4,4,3,1,4,1,1,1,5,5,3,4,2,3,5,5,3,3,5,2,5,4,4,3,5,4,4,1,2,1,1,1,3,3,1,5,4,4,5,1,1,3,5,1,5,2,5,5,4,3,4,3,4,2,5,3,1,3,5,3,4,1,1,1,2,4,3,5,1,4,3,1,4,1,3,5,3,4,3,2,4,5,3,5,1,5,1,2,4,4,3,2,1,2,2,3,1,1,5,4,3,3,2,4,3,5,4,5,1,5,2,2,5,5,4,4,4,1,3,1,1,1,1,1,2,3,1,3,4,1,1,3,1,4,2,1,3,1,1,3,4,4,1,4,5,2,2,2,2,4,1,4,2,5,3,1,5,3,4,5,3,4,3,1,3,4,5,5,1,3,3,2,1,5,2,2,4,4,1,3,1,5,3,5,2,4,3,1,3,5,2,4,3,2,4,5,2,5,3,3,2,1,2,5,4,2,1,3,4,1,4,2,2,3,2,5,2,3,2,2,3,2,1,3,4,4,3,2,3,4,4,5,2,1,3,1,5,2,3,4,1,1,5,3,3,3,3,2,3,3,5,4,5,1,3,1,2,2,2,5,1,5,5,2,2,2,4,4,4,3,5,5,1,4,1,3,4,1,1,4,1,4,4,1,4,1,3,5,3,3,2,4,3,1,4,4,3,4,3,5,4,4,3,3,4,1,1,4,5,1,2,2,4,2,4,1,2,2,4,2,5,5,4,2,2,3,3,4,2,5,4,2,5,2,4,2,3,4,2,4,3,3,3,1,5,4,2,4,5,5,3,3,4,1,4,5,2,4,5,4,4,5,5,4,2,4,4,5,5,3,3,2,2,5,4,3,4,1,2,4,4,1,3,5,1,1,2,4,3,1,1,2,5,4,3,2,1,1,3,5,5,2,1,5,4,2,5,4,3,4,3,3,5,1,3,3,5,2,4,3,1,2,2,4,2,5,5,1,2,3,2,5,5,5,3,3,4,4,1,4,5,4,1,5,3,2,5,5,5,2,2,3,2,2,5,3,5,2,3,2,2,2,1,3,3,3,1,4,2,2,3,5,3,3,4,5,1,1,2,3,3,5,5,5,3,1,4,3,5,2,4,5,2,3,3,3,5,3,4,5,3,1,5,2,1,1,5,5,4,1,3,4,5,2,4,5,5,4,5,5,2,4,5,5,2,1,4,5,5,2,3,5,1,2,5,4,3,2,2,2,5,2,3,4,2,5,1,1,5,4,2,3,1,2,4,1,5,5,5,4,4,1,5,4,3,5,1,3,5,4,4,2,5,4,3,3,5,3,3,4,1,3,5,2,3,5,4,4,3,1,3,3,3,2,3,2,5,3,3,1,2,3,1,1,4,4,1,3,3,1,2,3,1,1,5,1,1,3,4,4,2,5,1,1,2,2,5,2,4,1,2,5,1,4,4,3,4,1,4,3,3,5,4,4,2,3,3,5,5,4,4,3,5,4,3,1,2,5,1,3,4,5,5,3,1,3,5,5,1,5,2,4,2,4,1,2,3,1,1,3,1,3,4,2,2,3,2,4,4,5,4,3,4,3,2,1,2,5,1,5,5,3,2,2,1,4,1,3,1,3,3,3,3,4,4,3,1,3,3,2,4,5,1,3,5,3,2,5,5,1,4,3,4,3,4,3,2,3,2,3,2,3,1,1,1,4,4,2,4,3,4,5,4,1,2,3,3,4,3,3,1,4,5,4,2,3,3,2,2,3,4,5,2,1,3,3,1,3,3,2,4,4,2,3,2,3,4,1,2,5,1,4,1,1,2,5,5,5,4,5,3,4,5,2,3,4,2,1,1,5,1,5,4,5,1,3,1,1,3,1,4,2,4,3,1,4,3,1,4,4,3,5,5,3,3,3,5,5,4,1,1,3,2,3,1,5,4,2,1,2,2,5,4,2,5,3,5,4,5,2,1,3,1,5,4,5,2,3,2,1,1,4,1,3,2,1,2,2,2,5,3,4,2,4,2,3,1,2,3,2,2,3,5,1,3,4,3,3,2,1,3,5,2,1,4,2,1,5,2,3,1,5,4,4,3,1,4,4,3,5,4,1,4,4,5,4,4,1,4,1,2,3,5,5,5,2,4,2,4,5,5,5,4,4,5,4,2,5,1,5,2,1,3,1,1,3,1,3,1,3,3,1,3,4,4,3,4,4,4,4,5,1,2,3,5,2,2,2,3,1,4,2,3,1,3,5,5,1,5,3,3,3,2,4,5,3,1,1,3,5,2,4,1,5,5,4,5,4,5,3,3,1,4,5,1,2,5,3,5,5,4,2,1,1,3,4,4,1,2,4,5,4,3,1,2,5,5,3,1,2,2,2,2,5,5,3,2,4,4,2,3,3,2,2,5,4,5,1,3,3,2,1,2,4,3,4,1,3,5,3,5,1,2,5,4,2,1,1,4,2,2,4,1,3,4,5,3,4,2,4,1,3,3,2,1,5,2,2,2,2,1,1,1,1,2,2,1,2,3,5,1,3,5,2,4,4,2,2,5,3,2,4,2,4,3,2,1,5,1,2,3,4,4,3,5,4,4,2,3,2,5,5,3,1,5,3,1,3,3,2,4,3,5,5,4,2,3,1,4,3,5,5,3,1,2,2,2,3,1,1,3,3,2,3,3,1,2,3,1,2,1,4,4,1,4,2,2,3,5,5,5,2,2,1,2,3,2,5,2,2,2,5,1,4,5,3,1,1,1,5,5,2,5,4,2,2,2,4,3,4,1,1,2,2,5,3,3,1,4,1,4,2,1,2,5,1,1,2,1,3,1,3,3,1,5,3,2,2,5,5,3,5,3,1,3,1,2,2,5,4,4,5,2,4,5,5,4,4,2,4,5,1,5,1,4,2,2,1,3,3,2,2,4,3,3,1,4,4,1,2,2,1,1,4,1,1,1,1,3,3,5,1,3,2,3,3,2,1,4,1,3,4,1,4,1,2,2,4,5,1,2,2,3,4,3,4,2,3,1,2,3,1,2,4,2,2,3,3,3,4,4,5,5,2,1,3,3,3,3,1,2,1,5,1,4,3,4,1,3,4,4,1,3,2,4,4,2,5,4,1,4,4,2,5,2,4,3,1,4,4,2,5,4,2,5,1,3,1,5,1,4,4,4,3,1,5,5,5,1,3,5,1,4,5,5,1,3,3,3,1,5,2,2,2,4,5,3,1,3,2,2,5,2,3,3,3,4,5,1,3,2,2,1,2,4,3,5,2,4,5,4,5,4,5,4,1,2,4,5,4,2,2,1,2,2,2,5,4,5,5,5,2,2,2,1,3,2,4,5,4,5,5,2,4,5,3,2,1,4,3,2,2,4,4,3,1,4,5,5,1,5,5,2,2,4,1,4,2,5,3,2,1,5,1,5,4,3,5,3,1,4,5,4,3,1,3,4,5,1,4,1,1,4,4,4,2,2,4,3,2,4,3,2,3,1,3,1,1,2,4,1,5,2,2,3,3,5,2,1,1,1,1,3,5,3,3,1,1,2,3,3,5,2,4,2,1,5,4,2,2,1,5,5,5,3,3,2,5,2,4,3,2,2,4,2,3,3,2,1,2,4,5,2,4,4,4,4,3,5,4,1,1,5,2,2,1,2,4,5,2,4,4,5,5,3,2,5,3,4,2,3,4,2,2,3,3,1,3,2,3,1,4,3,2,1,3,4,5,4,4,3,4,5,1,4,4,3,2,4,3,2,2,3,4,3,2,1,3,5,4,1,3,5,3,3,2,3,4,5,4,3,1,3,1,3,1,5,2,4,3,4,5,1,5,5,2,5,3,4,1,3,2,5,3,2,4,4,5,5,1,5,2,5,1,5,4,5,4,1,1,2,3,4,1,2,4,2,5,4,1,1,1,1,4,5,1,1,3,2,4,1,2,5,1,4,3,2,5,5,3,3,4,4,5,4,2,3,4,2,4,5,2,4,4,4,4,5,3,4,4,2,2,3,1,1,3,1,4,3,4,2,2,5,3,5,5,3,1,4,5,2,2,4,5,1,3,4,2,3,2,5,1,2,1,4,2,5,3,4,3,2,2,1,2,2,4,1,5,4,4,3,2,2,5,5,5,5,1,3,2,3,1,2,5,5,4,5,1,2,5,5,4,4,5,4,5,4,5,4,2,1,2,1,1,5,4,4,5,4,4,2,4,4,2,5,2,5,2,1,4,2,5,5,4,3,2,1,5,2,2,3,1,3,3,5,2,5,2,4,3,1,3,1,5,3,2,5,1,4,1,3,4,4,2,3,3,1,2,1,1,5,3,1,2,4,5,2,3,5,5,2,5,5,4,3,2,1,3,1,1,5,1,4,5,1,1,4,1,5,5,1,3,2,1,1,5,2,3,2,4,1,2,5,2,3,3,5,2,1,3,5,2,2,5,2,3,2,3,3,5,1,1,1,2,1,1,3,3,1,5,3,4,2,5,3,1,1,1,4,1,3,1,3,4,3,2,4,4,3,3,3,1,1,4,1,2,3,2,1,5,2,5,2,3,5,1,5,4,4,3,1,2,4,2,2,1,3,1,3,2,2,4,4,1,3,2,1,1,4,2,2,1,5,2,1,1,2,4,5,2,5,3,4,2,3,2,5,4,3,3,2,2,1,5,4,2,2,3,3,3,3,4,2,1,4,4,1,4,4,4,4,1,1,1,3,4,3,2,2,4,2,4,1,1,2,4,4,2,4,2,4,4,2,1,4,1,4,1,1,1,2,2,4,3,2,4,5,2,1,3,1,5,4,1,2,3,2,2,3,2,3,3,3,3,2,3,1,4,3,1,5,1,1,2,3,3,5,5,2,1,3,2,3,3,1,4,2,4,2,1,2,5,4,4,4,4,3,3,5,4,1,2,1,1,5,4,5,5,3,5,2,3,3,3,5,3,4,4,2,1,5,5,5,5,2,1,3,5,4,1,5,1,4,1,4,1,5,3,2,2,5,2,5,4,3,4,2,1,5,1,2,2,1,2,3,3,4,4,1,2,4,5,4,4,4,3,2,5,5,3,4,5,2,2,1,1,4,2,2,4,4,2,3,3,1,4,1,5,1,1,1,1,2,3,1,5,5,5,4,3,4,2,2,5,3,2,5,5,5,5,4,1,1,3,2,1,2,5,2,3,4,3,4,1,4,3,2,4,3,5,1,5,2,1,2,1,5,2,4,1,1,1,3,5,1,2,2,3,5,5,3,2,5,5,1,3,4,2,2,5,4,3,4,4,5,4,4,3,5,2,1,1,2,5,5,5,5,2,2,5,3,3,3,5,5,2,3,2,1,1,5,3,2,4,4,3,5,1,1,1,2,3,5,1,5,2,2,4,1,3,4,5,3,1,1,4,3,4,1,1,4,1,5,2,3,5,4,4,1,2,2,3,4,3,2,3,5,4,2,4,3,5,4,1,4,5,4,3,1,2,1,4,5,1,2,1,5,5,3,1,1,4,3,4,1,3,2,2,5,5,2,1,3,2,4,3,5,1,3,1,1,1,5,5,4,3,5,5,5,2,5,4,2,1,3,2,2,1,3,5,1,4,3,3,4,4,1,2,4,3,5,1,5,5,3,1,1,1,4,2,4,1,3,5,5,3,1,4,3,5,2,4,4,3,2,2,3,2,5,5,4,2,3,1,5,5,3,2,4,2,5,4,3,3,2,4,5,4,3,2,3,2,4,5,1,1,4,5,5,1,4,1,2,3,4,3,4,2,3,5,2,5,3,1,4,3,5,1,1,5,3,5,1,1,1,5,4,3,4,1,3,1,3,3,4,1,1,1,4,1,3,2,4,4,4,5,1,5,4,4,2,1,1,3,4,1,5,2,4,1,3,2,3,2,3,2,2,2,3,5,5,4,3,5,2,2,4,2,1,2,3,5,2,1,1,2,2,1,5,1,5,5,5,2,1,4,2,5,1,3,3,4,3,1,5,2,2,4,3,4,1,3,1,4,3,1,3,1,3,3,5,3,1,3,2,2,2,4,4,4,2,2,1,4,4,2,5,4,1,4,4,4,1,3,1,5,2,5,2,1,4,5,3,2,2,5,3,4,4,2,2,5,3,2,3,2,2,3,4,4,2,1,5,4,2,2,1,3,1,4,3,4,3,5,4,5,3,5,1,2,5,1,5,3,4,2,3,1,3,4,4,1,3,5,4,5,1,2,2,1,2,4,3,4,2,3,1,3,1,4,5,5,4,4,3,5,3,1,3,4,3,4,2,4,5,4,2,3,2,4,1,4,1,4,3,3,4,2,1,2,2,1,4,4,3,3,1,3,3,1,1,1,1,2,5,2,3,5,4,5,4,3,2,2,3,2,4,5,4,2,5,3,5,3,2,3,1,2,1,3,2,3,2,3,2,3,3,2,2,4,2,5,1,1,3,4,1,2,1,5,4,5,5,4,4,5,2,5,2,4,3,5,3,3,3,5,5,5,3,4,4,2,4,4,4,3,2,3,5,3,4,1,3,2,3,5,4,1,1,4,1,5,2,2,5,5,4,1,1,5,5,4,1,1,5,5,3,1,3,4,2,3,1,5,4,5,4,1,5,2,3,5,2,3,1,2,3,2,5,3,3,5,4,3,4,1,4,5,1,3,4,2,5,4,3,1,4,1,5,1,1,2,1,2,1,1,5,5,3,3,3,2,5,3,4,3,4,5,4,2,2,5,5,1,4,5,4,1,1,1,1,5,3,3,3,5,1,2,1,5,4,1,4,4,4,5,5,2,4,3,2,1,5,2,4,5,5,1,5,2,1,2,1,1,2,1,4,4,3,5,1,1,2,5,5,1,4,2,1,5,1,1,3,4,3,3,4,1,4,3,2,4,2,3,4,4,4,5,5,3,5,1,2,4,3,2,1,4,1,1,5,3,1,5,4,1,4,1,1,4,1,2,1,2,1,1,1,1,3,3,4,1,2,5,3,2,5,5,3,3,3,4,2,1,1,4,5,4,3,3,1,5,3,2,4,5,5,3,1,4,5,4,2,1,5,5,3,4,4,2,1,3,5,1,2,3,2,1,4,1,5,5,1,3,5,4,2,3,4,4,3,3,1,1,2,4,4,4,4,1,5,1,4,5,4,3,2,1,1,2,2,4,2,5,4,2,5,2,5,1,3,2,2,3,1,3,5,1,2,5,5,5,2,5,3,4,4,5,5,5,4,3,4,4,2,2,4,5,2,2,1,2,5,5,1,1,4,5,5,3,5,4,5,5,2,5,3,2,3,2,5,2,1,5,2,2,1,5,2,1,1,5,3,2,5,2,3,5,5,2,4,3,4,3,4,4,5,3,3,1,1,3,4,1,1,4,1,3,3,3,4,1,2,2,3,3,5,2,5,4,5,5,4,1,4,5,2,4,4,4,5,3,1,4,5,1,2,2,5,3,4,1,5,3,1,2,2,3,4,2,3,4,1,4,5,2,3,2,1,3,1,3,4,4,2,4,5,3,1,4,3,5,5,4,2,3,4,5,4,1,2,2,5,3,4,2,2,2,2,3,4,2,5,1,1,5,5,1,2,4,2,3,1,2,4,2,5,1,5,2,5,4,3,3,5,4,1,4,2,1,3,1,5,2,2,3,4,3,2,1,1,4,4,1,3,4,4,3,5,5,2,3,2,2,3,2,2,2,4,4,5,4,1,5,4,2,5,3,4,4,4,4,3,1,2,1,2,4,1,3,2,2,4,3,3,3,2,3,3,1,1,1,3,4,1,4,5,2,3,4,2,5,1,3,1,4,2,5,4,5,3,1,4,1,4,5,4,4,3,2,1,5,1,4,2,5,3,5,3,2,4,3,3,2,3,2,3,5,4,4,3,4,3,4,2,1,2,1,3,1,2,5,5,3,3,2,5,2,1,5,1,2,5,4,4,2,3,4,2,2,5,2,3,1,3,4,4,3,5,4,5,3,4,2,3,3,3,1,1,2,2,3,5,5,5,1,3,3,1,1,2,5,4,5,4,1,5,4,3,2,4,4,3,3,5,5,1,5,4,5,5,4,3,1,3,4,5,5,3,3,2,1,5,5,4,4,4,2,2,2,2,3,2,4,2,3,1,1,1,2,2,5,1,4,5,1,3,5,3,4,2,2,3,2,4,3,1,5,4,3,5,2,1,1,4,5,4,1,1,2,3,4,3,2,4,3,4,4,2,4,1,5,2,5,5,1,2,1,4,1,4,1,2,3,4,3,2,2,3,4,1,3,2,5,5,4,2,1,5,2,2,1,4,3,3,3,5,5,4,1,1,1,2,5,5,5,2,1,1,3,2,3,4,3,2,2,1,1,3,3,3,2,2,1,1,4,5,5,1,3,4,5,5,3,5,4,5,2,2,1,5,1,1,5,2,4,2,4,1,2,4,3,5,5,3,4,1,5,4,2,3,2,1,1,2,5,2,5,4,5,2,1,2,3,2,5,4,2,5,1,3,3,1,4,2,4,4,2,5,4,5,2,1,3,5,4,5,4,5,1,5,2,2,1,2,4,1,4,2,1,2,1,5,1,3,5,3,5,5,4,1,5,1,2,1,2,1,1,1,2,5,4,5,2,3,1,5,2,5,3,3,1,2,4,4,3,4,1,3,1,3,3,5,1,4,5,4,2,3,4,1,5,2,5,3,1,2,4,2,1,3,1,2,1,4,1,1,5,5,3,3,5,5,3,5,1,2,2,2,1,4,2,2,1,1,5,1,2,1,1,1,3,3,4,4,4,2,2,1,4,4,1,3,3,2,3,4,4,2,4,4,3,4,4,4,2,5,5,3,1,5,4,5,5,2,4,2,5,2,4,3,2,1,4,1,2,3,5,1,1,5,4,2,4,1,2,3,1,5,1,5,2,4,1,2,5,3,4,1,4,4,1,2,4,3,4,5,4,1,1,3,3,5,3,3,5,1,5,3,5,4,2,1,2,1,1,2,3,5,4,3,5,4,1,1,2,4,1,2,1,4,2,3,5,3,1,1,5,1,3,1,3,5,4,4,1,5,1,3,5,2,4,1,1,4,2,3,4,4,5,4,4,4,3,2,4,3,5,1,1,2,4,1,2,1,1,2,3,5,3,4,3,3,5,2,2,4,4,4,3,2,2,3,3,3,2,5,5,1,2,4,4,1,4,5,3,3,3,1,3,2,1,1,3,3,4,3,5,1,4,4,4,3,3,2,4,5,1,3,4,1,1,3,1,5,1,3,1,1,3,1,4,5,5,5,2,3,5,5,1,3,5,3,2,1,1,2,4,4,5,2,3,5,1,4,3,2,1,1,1,4,3,1,1,5,3,4,5,2,3,2,2,1,3,4,5,3,5,5,4,2,5,5,1,1,5,5,5,2,1,5,5,1,1,3,1,4,4,2,4,4,2,5,4,1,5,2,3,1,1,1,1,3,4,4,5,5,2,5,1,2,5,5,5,4,1,1,4,2,3,4,3,4,2,5,5,1,3,1,1,2,1,4,2,5,2,4,5,4,4,3,4,4,3,5,5,1,1,2,3,4,2,5,4,2,5,5,2,2,2,4,2,4,1,3,5,5,5,1,1,2,4,2,1,1,5,3,4,1,1,5,4,2,4,4,4,4,4,2,3,3,2,1,3,4,2,4,1,2,5,4,2,2,5,2,4,5,1,3,1,4,4,3,3,3,3,5,2,2,1,2,1,4,5,2,4,1,2,4,4,1,1,1,2,2,3,4,2,4,4,2,3,1,4,1,5,1,3,2,1,4,5,3,2,5,3,4,3,3,1,5,4,5,2,5,1,1,2,2,1,1,1,3,1,3,1,2,1,5,1,5,5,3,5,1,2,1,5,1,4,1,3,5,4,2,4,1,2,3,2,4,3,4,2,2,4,4,1,5,2,3,3,2,3,4,3,2,5,5,1,5,2,3,1,5,5,5,1,5,2,1,3,5,1,4,5,4,5,3,5,5,5,3,5,2,5,2,2,4,3,5,4,5,1,5,5,5,5,2,3,3,5,3,4,2,4,4,1,3,4,4,5,5,2,4,1,2,4,4,5,5,2,2,3,4,4,2,5,1,2,4,5,3,5,1,5,5,5,2,5,1,1,5,5,4,4,3,1,1,5,5,2,2,3,5,2,3,5,5,4,1,3,2,3,1,3,1,5,3,2,3,1,1,1,1,2,4,5,1,5,4,3,5,5,1,5,3,2,5,2,1,4,1,2,4,1,3,3,2,3,4,1,1,5,4,1,5,4,5,3,1,2,5,5,5,1,1,1,4,3,1,5,1,1,2,2,4,3,4,3,1,2,4,4,5,1,4,4,2,4,3,4,4,5,3,5,1,3,4,4,3,4,2,4,3,5,5,2,1,1,2,4,5,2,2,1,3,5,4,3,4,4,5,3,1,5,5,2,4,4,5,5,3,2,2,2,4,4,4,3,3,3,4,1,5,2,3,3,5,3,2,2,2,5,5,5,4,2,3,5,2,1,2,5,1,2,1,3,5,2,5,2,4,3,2,2,3,2,4,3,4,4,2,1,3,5,3,5,5,5,1,3,2,1,5,3,3,1,4,3,5,5,1,3,5,2,1,3,4,1,1,1,2,4,4,4,5,1,5,4,5,1,5,4,1,5,4,3,2,2,5,2,2,5,5,2,4,3,1,4,3,3,5,1,3,5,2,2,4,3,2,1,5,3,1,2,2,1,5,2,3,1,5,5,4,1,1,5,4,1,2,3,5,2,4,2,5,1,2,1,4,2,5,2,1,5,4,1,5,4,2,1,4,2,5,3,5,4,5,3,5,1,1,2,5,1,1,5,2,5,1,4,4,1,4,4,3,1,3,5,4,2,1,3,5,1,5,4,3,5,5,5,1,5,1,1,2,4,2,5,1,1,1,2,3,2,1,5,5,1,3,5,2,3,4,1,5,3,1,1,4,2,2,3,2,4,4,4,1,2,5,1,3,1,4,5,3,2,2,5,5,2,2,3,1,3,3,5,4,3,4,3,3,1,4,3,4,4,4,5,5,3,2,1,4,5,3,5,3,2,5,5,5,2,5,2,1,2,2,5,3,1,4,4,4,1,4,1,5,2,2,3,4,3,1,2,4,4,3,2,3,2,1,4,5,2,5,5,3,3,4,2,3,4,2,1,5,5,4,1,1,2,5,1,2,5,3,4,1,1,2,5,5,2,4,5,5,2,5,4,3,4,5,2,5,5,1,5,2,2,3,4,4,4,3,5,3,5,1,4,1,4,3,3,4,2,2,4,2,2,3,2,4,2,5,2,5,2,2,2,4,4,1,4,1,1,2,3,2,5,2,2,1,1,5,3,1,4,2,1,2,3,3,2,3,3,2,5,1,1,3,3,4,1,1,1,5,3,3,3,1,3,2,3,5,1,2,4,4,4,1,3,5,3,5,4,5,2,2,1,4,2,5,4,2,4,3,1,2,1,5,1,1,3,4,5,1,5,4,1,3,3,3,1,4,2,5,4,5,4,5,4,4,2,5,3,5,1,5,2,3,4,4,1,5,2,1,1,2,2,5,3,4,1,1,2,2,3,4,2,4,5,2,1,5,4,3,5,2,1,2,1,2,4,5,5,3,4,3,5,2,4,4,3,4,5,4,3,3,3,3,1,2,5,2,1,5,1,5,4,3,1,3,4,2,2,4,5,2,1,1,1,3,1,3,1,4,3,5,1,4,5,3,3,4,1,2,5,5,2,2,5,3,5,5,2,5,4,4,3,4,2,1,3,1,3,4,1,4,5,5,4,5,1,1,3,4,2,2,3,3,4,3,2,3,4,1,5,5,4,3,5,1,4,3,1,2,3,4,5,5,3,3,2,2,5,4,3,2,3,1,4,1,2,4,1,5,1,4,5,4,3,4,4,2,3,2,3,4,1,1,3,3,3,5,1,5,1,3,1,3,3,4,5,4,2,1,2,3,5,1,2,3,4,3,4,2,4,3,3,4,1,2,1,1,3,5,5,4,2,5,3,1,3,4,4,3,1,5,5,2,5,5,5,5,1,1,2,1,3,4,5,5,2,1,5,1,4,1,1,1,5,4,1,3,1,5,5,5,2,4,5,2,3,3,5,1,3,4,4,4,3,4,1,3,4,2,2,5,2,4,4,2,4,4,2,2,5,3,1,5,5,2,2,4,2,5,3,2,5,4,3,1,4,4,5,2,3,2,2,2,3,4,5,5,2,5,3,5,4,5,5,3,3,3,4,2,3,2,4,4,1,3,4,3,3,3,5,1,1,4,3,4,1,1,5,3,3,2,4,1,2,3,2,2,1,2,1,5,4,5,2,5,3,4,3,3,3,1,4,3,1,3,4,2,5,1,5,4,2,5,2,2,3,3,5,3,4,3,3,3,1,3,1,1,2,4,3,3,2,1,3,1,3,3,3,4,5,4,3,3,2,4,4,5,5,2,4,1,2,4,1,5,5,2,5,1,5,2,2,4,5,3,3,3,5,3,4,4,4,3,5,1,1,5,3,1,4,5,4,2,5,1,4,1,5,3,3,3,2,3,5,4,4,5,3,4,2,3,3,3,4,1,1,1,5,4,3,4,4,3,3,4,2,3,1,5,5,4,2,1,4,1,1,5,1,3,3,2,5,2,4,5,2,5,1,3,3,4,3,4,2,4,5,4,3,4,1,4,5,5,2,3,2,1,1,3,5,5,2,2,4,1,5,3,1,2,4,1,5,3,2,5,1,2,2,4,1,2,5,5,2,2,2,3,3,3,5,3,1,2,5,3,4,3,4,5,3,1,2,1,2,3,5,4,1,3,1,3,2,1,1,5,4,3,3,3,4,4,4,3,2,3,4,5,1,3,1,3,3,3,5,1,2,4,2,2,2,5,2,5,2,5,4,4,5,4,3,4,1,5,1,4,3,2,3,1,5,4,2,1,4,5,4,5,4,1,5,3,2,5,2,2,2,3,4,4,2,5,4,3,2,4,2,4,1,2,5,4,5,2,1,4,5,4,1,1,4,3,2,4,1,3,2,5,5,4,5,4,1,3,3,2,5,1,4,3,5,1,4,3,4,1,4,5,5,2,5,3,5,5,5,3,2,1,4,3,3,5,1,2,5,1,1,1,1,2,5,1,4,5,2,5,5,3,1,3,1,3,2,1,2,4,2,5,2,2,3,4,5,3,4,1,1,5,3,1,5,1,3,3,2,1,2,4,4,1,4,3,5,3,1,4,2,5,4,5,5,2,1,5,4,5,2,5,2,1,1,2,1,5,3,3,4,2,1,5,2,4,5,1,1,4,5,1,4,2,3,4,1,5,2,3,5,3,1,5,5,2,4,3,1,2,4,3,3,1,4,1,1,2,1,5,1,4,4,2,4,2,1,3,5,4,3,5,4,4,4,2,1,4,3,3,5,1,3,2,1,5,2,1,4,3,2,5,4,2,1,3,2,2,3,3,2,3,2,2,4,2,3,2,5,5,4,4,4,4,3,1,1,3,2,1,1,5,5,5,3,2,3,2,3,3,5,1,4,2,5,2,4,1,4,3,2,1,1,1,5,3,3,3,2,2,3,1,2,1,1,5,3,5,1,5,2,3,5,1,1,3,5,5,3,1,3,1,3,1,1,4,1,1,5,2,4,4,4,4,2,4,4,2,5,2,5,5,3,3,2,4,3,2,2,4,3,2,1,2,5,3,2,2,2,3,4,1,1,3,1,5,2,1,1,4,1,1,3,4,5,3,4,2,1,1,3,5,2,5,2,1,1,1,1,3,1,5,3,1,1,5,2,3,1,2,2,3,4,4,2,1,4,4,4,2,4,3,1,4,2,4,1,3,5,3,4,4,4,1,2,3,2,3,3,1,5,1,2,2,2,5,5,3,5,4,5,2,1,3,3,5,5,4,5,2,2,4,1,1,1,1,5,2,3,4,4,2,4,2,5,1,3,2,3,3,2,5,1,3,2,2,2,1,1,2,2,2,3,4,5,2,2,4,5,3,3,1,3,2,3,2,2,3,2,1,3,5,3,1,3,2,3,1,1,1,2,2,4,4,2,1,5,5,5,2,3,3,3,2,4,5,5,2,2,1,4,5,5,2,1,5,5,1,3,1,2,4,3,4,4,4,4,3,1,5,2,5,1,5,3,5,1,4,4,2,3,1,2,1,1,4,4,1,3,5,1,4,4,3,5,4,3,5,1,1,3,5,3,4,2,5,1,5,3,3,1,5,1,5,2,2,3,1,5,2,3,5,4,2,1,2,4,3,2,3,2,3,2,5,3,4,4,1,2,5,1,2,2,2,5,3,3,2,2,1,3,4,1,2,4,2,3,3,4,1,1,2,5,4,1,2,4,3,2,2,3,4,3,2,2,3,3,1,4,5,5,3,4,5,5,1,5,1,3,1,2,2,1,4,2,4,4,4,3,4,2,2,3,2,2,3,3,5,5,5,3,2,2,1,2,3,1,4,2,3,1,1,3,4,2,4,2,5,4,3,2,3,2,1,1,2,5,4,3,4,2,5,2,5,2,3,1,5,1,3,5,2,2,1,1,5,1,5,2,1,1,4,4,1,5,5,1,4,1,1,4,1,2,2,5,4,5,5,2,1,4,4,3,5,3,1,1,3,1,1,4,5,4,1,4,1,1,4,4,2,1,2,4,1,5,3,5,5,5,5,3,1,4,4,4,2,4,1,4,2,3,1,2,1,1,1,3,3,4,5,3,5,3,4,4,4,2,4,4,4,2,1,3,5,2,2,4,5,1,4,4,1,1,5,5,3,3,5,2,5,1,2,2,4,4,2,2,2,3,2,4,1,5,4,2,3,1,5,4,1,2,2,5,1,4,2,4,5,1,3,3,5,4,5,3,5,3,2,2,1,5,3,5,4,2,2,1,2,4,4,2,5,4,4,4,1,4,1,5,1,3,5,3,1,4,4,4,5,4,5,3,1,2,2,4,2,2,3,4,5,3,5,1,4,2,3,5,1,1,3,3,1,1,5,1,2,2,1,3,3,1,5,1,4,5,3,4,1,2,4,3,4,5,3,5,1,3,4,1,2,2,2,3,4,5,1,2,2,3,5,2,4,2,4,2,4,2,1,1,4,5,4,4,3,5,3,5,4,1,1,2,2,4,4,1,4,1,3,3,1,1,3,1,1,3,4,2,4,2,5,1,3,3,2,5,2,5,5,3,4,2,2,3,5,3,1,2,1,4,4,4,3,5,2,1,2,4,2,2,2,4,3,4,3,5,3,3,5,4,5,3,2,3,4,3,2,4,2,4,1,3,3,1,5,5,2,2,3,4,2,3,4,5,5,1,5,4,2,4,1,1,3,2,1,2,2,2,2,2,3,3,2,3,1,3,3,3,1,3,4,3,2,3,4,2,2,1,2,2,5,2,1,2,5,5,4,5,3,1,4,1,5,4,4,4,1,2,5,3,2,4,5,4,1,4,3,5,5,3,1,1,4,2,3,1,3,5,1,2,2,5,2,2,5,5,5,4,4,1,3,5,3,2,5,3,5,4,4,1,3,4,4,1,4,2,3,4,3,1,3,1,1,4,3,5,1,1,5,4,4,4,5,1,5,1,1,1,1,5,1,2,1,5,4,4,2,4,5,1,5,5,3,5,1,2,4,5,1,3,1,2,4,1,5,3,2,1,1,1,1,3,1,1,2,5,3,3,1,3,4,2,5,5,3,3,5,1,1,2,4,5,5,5,3,2,1,3,1,5,3,3,3,3,5,2,3,4,5,2,5,5,4,5,2,2,2,1,1,2,2,3,2,2,2,2,4,1,4,2,1,1,2,5,5,1,5,5,3,5,5,3,3,4,4,2,4,4,2,1,2,5,1,1,2,2,2,4,4,4,1,4,3,4,2,3,2,5,1,4,4,5,3,3,3,1,4,1,5,4,4,2,2,1,3,1,3,2,4,5,2,4,2,3,3,5,3,3,1,4,2,5,3,5,1,4,5,1,3,1,5,5,5,3,2,5,1,5,4,5,2,5,4,5,4,5,2,5,5,2,1,2,4,5,3,1,2,1,2,2,3,2,5,4,1,4,5,2,2,1,5,4,2,4,3,2,2,1,5,1,1,1,5,5,5,5,5,3,3,5,3,4,3,1,5,2,5,5,1,1,3,3,4,5,4,5,3,3,5,1,3,4,3,5,2,5,2,2,5,5,1,1,4,2,4,4,3,1,2,1,2,3,5,5,2,3,4,2,3,4,3,5,1,4,3,4,5,4,2,1,1,2,2,1,3,3,2,5,5,3,4,3,3,4,4,5,5,2,3,4,3,3,4,4,1,3,2,5,5,3,3,3,1,3,2,1,2,1,4,4,3,1,2,2,2,3,1,3,1,5,2,4,3,4,2,5,3,1,4,1,2,3,2,3,1,2,2,1,1,2,4,1,5,2,2,2,4,3,1,2,1,2,1,1,5,4,2,1,2,2,4,5,2,4,2,4,3,2,3,2,1,4,3,1,3,2,4,4,1,3,5,4,3,5,3,2,4,4,2,3,1,1,4,2,2,1,3,5,4,5,5,4,3,2,5,5,3,3,4,5,2,1,4,5,3,3,1,1,4,2,2,1,2,2,2,3,2,1,3,3,3,1,4,4,1,2,3,3,4,5,1,2,2,5,2,3,4,4,3,4,3,4,1,5,2,2,5,2,4,3,2,4,3,4,3,5,1,2,5,3,2,1,1,1,4,4,2,1,5,3,4,1,3,1,5,1,1,1,2,2,4,1,5,1,2,2,2,4,2,5,3,1,2,4,1,4,2,1,4,4,1,4,2,4,2,3,2,1,2,4,3,5,1,5,5,2,2,4,5,2,1,1,4,1,3,2,3,4,5,2,5,5,2,2,1,4,1,1,1,4,3,2,4,1,2,4,1,3,1,2,4,4,5,3,1,4,1,3,3,1,1,2,1,3,4,3,1,2,2,1,4,2,3,3,1,3,5,1,4,3,5,1,1,5,3,1,4,4,2,2,2,1,5,2,1,1,2,1,2,2,2,2,2,4,4,1,5,5,1,3,4,5,1,5,3,3,4,4,1,4,4,5,5,1,3,1,2,4,2,2,5,1,3,2,3,2,5,4,3,1,4,3,3,3,1,4,4,4,5,1,1,4,4,1,2,1,5,1,1,5,1,2,5,5,5,4,5,4,4,5,3,1,4,2,1,1,5,2,2,5,4,3,1,3,2,3,3,1,2,1,3,1,4,5,4,3,5,2,2,5,2,3,1,2,4,2,2,3,1,2,5,1,1,4,3,5,1,2,3,4,4,1,1,1,2,1,5,3,5,1,4,5,1,5,3,1,4,1,5,2,2,1,2,1,3,3,3,3,3,1,2,2,1,2,2,3,3,3,3,4,4,2,5,4,1,4,2,4,2,2,5,4,2,1,2,1,4,1,2,4,2,2,2,4,2,2,5,3,1,5,3,3,4,4,4,5,3,3,3,1,4,4,1,4,2,5,5,1,4,5,5,4,4,2,2,5,1,4,4,5,4,5,4,4,4,4,5,5,4,3,3,4,2,3,1,1,2,1,4,3,5,1,3,1,5,5,4,3,5,4,1,3,1,2,2,1,3,2,2,1,4,4,5,4,2,3,4,5,5,4,1,4,3,1,4,1,4,1,3,2,3,2,3,5,3,1,4,4,4,1,1,2,5,4,4,2,3,2,1,3,4,2,2,1,4,1,3,2,5,2,5,2,5,5,1,2,1,2,3,4,3,4,4,3,2,2,5,1,1,5,2,3,3,2,5,3,5,4,4,3,1,5,2,1,1,1,4,4,3,5,5,2,2,4,1,1,5,5,4,2,1,1,2,2,5,4,5,5,1,5,3,2,3,1,4,5,5,4,3,1,4,3,2,3,5,3,4,1,3,2,4,4,4,2,4,3,3,2,3,2,3,5,1,1,1,4,4,3,1,2,4,3,1,2,4,5,1,5,5,4,5,1,4,4,3,2,4,5,2,2,5,1,1,2,2,3,3,4,5,5,4,5,3,4,3,5,3,1,5,5,4,2,5,4,2,4,4,4,4,3,2,1,4,1,2,1,2,5,4,5,3,3,2,5,1,1,2,4,3,1,1,5,5,3,1,2,1,3,3,3,1,3,5,1,3,1,3,4,5,4,4,4,4,3,5,3,3,3,3,5,2,3,1,4,2,1,5,3,3,5,1,1,3,5,2,3,4,3,1,1,2,3,5,4,1,2,1,4,4,3,3,1,4,5,2,2,2,1,2,2,2,5,4,5,5,4,2,1,1,4,4,5,2,4,5,2,3,4,2,4,2,3,3,2,1,2,5,5,2,1,4,3,4,2,5,3,4,3,2,3,5,1,2,2,2,4,4,1,2,2,2,2,4,3,4,4,5,2,2,1,1,1,2,1,3,3,2,3,2,2,3,5,2,5,2,1,3,1,2,3,5,5,4,5,4,4,2,3,2,4,5,3,5,3,4,2,1,1,4,1,2,1,3,5,1,1,1,4,1,4,3,5,5,2,4,4,3,4,1,5,3,5,4,3,1,3,5,5,3,3,4,5,5,3,1,1,4,3,3,2,5,3,2,1,2,4,4,2,5,1,1,5,1,1,3,3,4,2,4,3,2,3,1,2,4,4,4,4,3,5,3,4,4,1,2,3,3,3,1,1,3,3,4,3,2,4,3,2,5,5,3,3,2,2,3,5,2,5,4,5,5,5,1,1,2,4,5,3,5,3,3,1,2,1,3,5,2,1,3,2,4,2,2,5,1,3,1,1,4,1,2,4,4,2,3,1,5,5,3,1,2,1,4,4,5,2,5,4,5,5,2,1,5,5,5,4,5,2,2,3,4,2,1,2,1,1,3,4,1,2,2,3,3,3,2,5,3,2,2,2,3,2,4,1,4,1,2,4,2,3,5,4,5,2,2,4,2,2,5,5,3,3,2,2,4,3,4,4,4,3,2,1,5,5,4,4,1,3,2,1,3,4,3,5,2,1,1,5,1,2,2,2,4,3,3,2,4,1,4,5,5,5,3,5,4,3,5,1,3,2,5,4,1,3,1,1,5,1,2,5,2,5,3,1,2,4,5,2,5,2,4,5,3,2,4,1,3,1,5,2,1,2,5,2,1,3,2,2,3,2,5,3,1,4,1,1,4,2,5,5,4,4,4,2,3,2,1,3,1,1,2,1,3,5,2,3,4,1,1,1,2,3,1,3,4,4,2,1,5,3,3,2,2,4,3,4,5,4,3,5,1,1,4,1,4,4,2,4,4,4,1,1,3,3,5,3,3,1,1,4,1,2,3,1,3,1,4,3,3,2,4,5,1,5,3,1,4,2,1,1,3,2,3,1,1,1,2,3,3,2,2,5,4,4,1,1,5,2,5,5,5,1,3,5,4,1,5,1,4,1,2,3,3,5,4,1,2,4,2,3,3,3,1,5,5,5,4,5,1,4,1,1,2,4,3,2,3,2,1,1,2,4,3,2,5,4,2,3,4,2,5,4,4,3,4,2,2,3,2,5,3,3,1,1,1,4,5,2,2,4,2,3,1,5,5,4,2,4,3,1,4,4,5,4,2,1,3,2,5,1,2,2,5,5,1,1,2,2,3,1,1,1,2,1,4,1,4,3,5,1,1,2,1,1,3,1,3,3,5,5,3,2,3,3,3,1,3,2,2,1,5,3,3,3,4,2,4,5,5,5,5,5,1,2,1,4,4,4,5,3,1,5,3,1,2,2,3,4,4,1,5,5,4,5,5,1,1,2,5,1,5,4,1,4,3,4,1,1,2,1,2,4,1,4,2,5,5,5,3,2,2,3,2,5,2,3,3,2,1,2,3,5,2,3,3,3,2,2,3,2,5,5,3,5,2,3,4,1,1,1,1,4,2,1,2,2,5,1,3,3,1,5,5,1,3,4,5,4,3,1,5,5,2,2,2,3,4,5,3,5,1,5,1,5,5,1,2,2,4,4,4,2,2,2,2,3,3,5,5,1,3,2,1,4,5,5,3,2,2,3,4,4,3,4,3,4,1,1,5,1,5,3,1,4,5,2,2,5,4,2,2,5,3,3,5,2,2,2,3,5,4,4,4,5,5,4,2,3,3,4,3,4,1,1,2,5,4,1,4,4,2,1,2,2,5,5,3,5,1,1,5,4,2,5,1,1,1,2,3,5,1,4,5,2,1,2,2,3,3,2,1,5,4,1,2,4,3,5,4,2,4,4,3,4,3,5,4,2,5,3,4,5,3,5,5,4,5,2,2,3,1,2,3,5,4,5,3,4,5,1,5,1,4,2,1,4,4,1,4,5,4,1,1,3,2,5,2,2,4,5,4,3,5,2,2,1,5,1,4,3,3,4,2,5,5,5,3,3,2,1,5,3,3,2,4,2,3,3,2,2,5,3,3,5,3,4,5,4,1,4,4,5,2,1,5,2,3,3,5,3,3,1,2,2,2,5,4,4,5,3,3,2,2,4,1,3,5,1,4,1,5,5,5,2,1,1,1,2,5,3,1,4,4,5,4,1,2,3,3,5,2,5,4,2,3,2,2,2,3,4,2,5,4,3,5,4,5,4,2,4,1,2,4,1,1,1,4,4,3,5,3,3,5,2,3,4,1,3,4,5,1,2,5,4,3,2,1,2,4,5,2,2,5,5,2,4,1,5,1,3,2,3,4,4,1,2,2,4,2,4,5,2,2,1,1,3,4,1,1,4,5,1,5,2,1,3,2,5,1,2,2,3,5,1,4,2,5,1,3,2,5,1,2,1,3,1,3,3,3,2,1,4,2,2,1,3,1,3,5,1,4,1,3,1,2,3,3,3,1,5,1,5,3,4,4,1,2,1,4,3,2,2,2,1,4,5,5,5,5,2,2,2,2,4,1,1,1,4,2,5,1,5,2,5,3,2,5,3,2,4,1,5,3,2,4,5,3,1,1,4,3,5,1,1,1,5,5,4,5,3,5,1,3,4,4,3,5,2,3,4,5,3,1,2,3,4,5,2,2,5,3,5,3,5,3,4,2,3,1,1,4,4,5,1,1,2,2,1,1,3,5,1,5,3,1,5,5,3,4,3,1,5,2,4,4,5,3,1,2,5,5,5,5,5,2,5,4,5,4,4,1,4,3,1,2,5,4,4,4,2,3,4,1,2,4,3,4,3,4,4,3,4,5,4,5,2,5,4,5,3,5,1,1,3,5,1,5,3,2,3,1,2,5,5,5,1,2,2,3,5,5,1,5,3,3,1,5,3,3,1,5,3,4,1,3,4,5,4,5,3,2,3,3,4,4,2,5,4,1,3,5,5,2,3,1,1,3,1,4,1,5,2,5,5,3,4,5,2,4,2,4,4,5,2,3,3,3,3,1,2,2,5,4,3,2,3,4,3,1,5,4,2,5,5,5,1,5,2,5,4,4,1,5,3,3,2,3,2,3,2,3,5,3,1,4,2,2,4,4,1,3,2,3,3,3,2,3,5,4,1,3,2,5,1,3,2,1,4,5,3,3,5,2,3,5,4,1,1,5,2,2,3,2,2,2,4,2,5,1,3,1,2,5,4,3,3,4,3,2,1,4,5,2,2,2,3,5,3,2,1,4,3,4,3,4,5,5,1,3,3,3,1,1,1,1,3,1,1,3,2,5,4,5,3,1,3,4,3,4,5,2,4,5,1,3,2,4,3,4,1,5,1,3,1,2,3,1,3,4,3,5,2,2,4,5,3,1,4,3,2,5,2,1,2,2,5,3,3,3,5,3,1,5,2,2,3,4,5,3,5,2,4,4,3,2,1,1,5,5,5,5,3,1,5,5,3,3,5,1,4,4,5,1,4,5,3,5,4,3,2,4,5,5,2,2,3,1,2,2,5,3,4,5,5,5,1,5,1,1,4,2,5,4,5,3,3,3,4,3,5,3,2,1,4,5,5,5,5,3,5,2,1,4,2,2,2,3,5,1,1,5,4,2,1,3,4,4,1,4,4,4,4,4,4,3,2,2,1,2,5,2,5,1,5,2,4,1,5,2,4,5,3,5,1,2,5,4,2,2,5,1,4,2,2,5,3,3,1,4,2,5,2,2,4,5,3,5,2,4,1,3,1,2,1,4,1,2,4,3,1,3,4,3,1,2,3,2,2,4,2,1,3,4,2,5,4,4,5,2,4,1,1,4,2,1,1,5,4,4,3,2,3,1,2,4,2,4,4,5,1,4,2,5,3,1,1,4,5,5,1,1,5,3,3,5,1,2,1,3,2,2,3,3,3,5,5,1,5,5,4,3,5,2,3,1,2,1,5,5,5,1,4,3,2,3,2,5,4,1,3,4,2,1,2,5,2,2,2,2,5,3,4,2,2,5,1,4,5,3,4,3,3,2,2,3,3,1,5,5,5,4,1,5,1,3,4,2,3,3,5,1,2,1,1,1,5,4,5,2,2,1,5,4,2,2,5,5,1,5,1,5,1,1,2,2,1,2,3,2,3,4,3,2,1,1,5,3,1,1,2,4,3,2,1,3,5,1,4,3,1,1,5,2,3,2,2,3,5,1,1,5,5,2,4,2,5,1,2,3,2,4,5,5,1,2,2,1,3,3,5,4,5,5,5,5,2,4,5,5,4,3,1,1,5,1,2,3,4,1,3,2,1,1,5,5,3,2,3,5,3,1,1,1,1,3,4,4,1,2,3,4,3,1,2,5,1,1,2,1,4,1,5,3,1,2,1,3,1,3,1,5,4,1,3,2,4,2,1,5,1,5,5,2,3,3,4,1,3,1,1,1,5,4,4,5,5,3,3,3,5,3,4,5,5,1,4,1,2,5,2,5,2,5,4,3,5,4,4,2,5,3,5,3,4,5,5,3,2,2,5,1,5,2,3,2,1,4,5,1,1,5,3,4,5,5,1,5,3,4,3,3,2,4,4,5,4,1,2,3,5,4,5,5,4,4,5,4,4,2,4,4,2,5,5,3,1,5,2,2,5,3,1,3,1,5,2,4,1,3,5,1,4,5,2,1,3,1,2,3,3,4,5,4,3,3,3,2,5,2,4,5,3,5,1,3,5,2,2,5,3,4,3,3,3,3,1,3,1,3,3,4,1,2,5,1,1,5,2,4,1,3,3,4,2,3,5,4,1,5,2,5,1,3,3,1,4,1,1,4,5,4,4,4,3,4,4,5,1,3,2,4,5,4,5,3,1,1,4,3,5,4,1,1,4,2,5,5,1,3,3,3,1,1,2,5,1,1,2,4,4,5,5,2,1,2,2,3,5,2,5,2,4,5,4,3,4,5,4,4,4,4,1,4,2,4,1,3,4,5,2,5,2,1,2,1,5,4,4,3,5,5,5,2,4,1,2,5,2,1,1,5,5,1,3,5,1,3,1,2,1,1,1,1,5,3,4,4,5,5,1,4,3,4,4,2,4,1,5,5,3,3,2,5,2,5,5,5,1,2,4,2,2,4,3,1,3,1,3,5,1,1,5,5,5,3,3,2,1,4,5,3,5,1,1,2,4,5,4,3,4,5,3,3,2,5,1,3,1,5,5,4,1,3,2,4,1,4,3,1,1,1,2,3,5,1,3,4,3,1,1,5,2,4,1,1,3,2,5,1,4,1,2,5,5,2,4,4,5,5,5,1,4,3,3,3,5,5,3,5,4,4,5,3,4,3,5,4,4,3,3,2,4,5,3,2,4,4,2,5,1,4,1,4,2,3,4,1,4,5,4,3,1,3,2,4,1,5,3,5,2,3,2,1,1,1,3,5,1,1,4,4,5,2,4,3,4,3,1,3,2,1,5,1,1,1,3,2,4,5,3,4,5,5,2,5,3,4,1,5,3,3,4,1,4,5,1,5,3,4,5,2,3,5,4,3,2,3,4,4,4,3,3,5,5,5,1,3,1,2,3,3,5,5,5,2,1,3,5,5,1,1,1,3,5,1,1,1,2,3,4,1,1,3,2,4,2,2,1,2,3,4,3,2,2,1,3,1,5,5,5,1,3,4,3,2,2,1,1,1,5,1,2,1,4,2,4,4,5,5,5,2,3,3,3,2,5,2,3,2,5,2,2,2,1,3,5,2,1,5,4,2,3,2,5,3,5,5,1,1,1,5,5,2,3,3,5,2,3,1,3,2,2,1,1,3,1,2,1,1,2,2,4,4,4,1,2,1,2,3,5,2,2,3,1,3,2,1,5,1,4,4,4,4,2,2,3,5,2,1,5,5,2,3,1,1,5,1,4,2,3,1,3,1,3,1,3,3,3,1,1,1,5,3,4,5,5,4,3,2,1,1,5,4,3,1,1,4,3,1,4,1,3,3,2,3,5,2,4,5,3,5,2,5,5,3,3,1,5,1,4,1,2,5,5,2,3,2,5,2,2,4,1,3,1,5,1,4,4,1,2,2,5,2,2,3,3,4,5,3,1,1,4,1,2,1,4,4,3,4,1,3,3,1,2,3,1,1,4,3,3,4,3,3,3,3,5,2,1,5,1,4,3,2,3,2,2,1,2,5,5,2,1,3,5,4,1,5,2,1,4,5,3,2,2,3,5,3,5,4,1,5,2,3,2,3,5,3,2,3,5,1,2,3,5,2,5,1,4,4,3,5,3,2,1,1,1,4,2,2,4,2,3,3,4,1,2,1,4,2,1,5,3,2,3,1,1,1,5,3,1,1,1,4,2,3,4,1,2,2,2,5,1,2,5,1,3,2,4,4,5,3,1,2,4,4,4,5,2,5,1,5,2,4,5,4,1,5,3,5,3,2,3,5,1,5,2,2,2,3,1,3,2,2,5,3,1,4,4,3,2,3,3,5,1,5,5,5,5,4,3,3,4,1,5,3,4,1,2,2,2,1,1,5,2,1,1,5,1,3,2,1,1,4,3,4,3,5,2,1,5,2,5,4,5,4,1,5,3,1,3,3,5,1,5,1,5,3,1,5,3,4,4,2,4,4,2,4,1,2,1,2,1,1,2,1,4,4,4,3,1,1,3,5,2,3,2,4,4,1,4,5,2,3,4,5,4,2,5,5,1,1,1,5,5,1,5,1,5,5,5,2,5,4,3,2,4,3,5,1,5,2,5,3,2,2,3,3,1,2,4,4,2,5,1,3,4,3,2,4,4,1,3,2,4,4,3,3,1,4,4,5,3,4,4,3,1,1,2,1,3,1,5,3,5,2,4,5,1,4,1,2,4,1,5,3,5,3,5,3,3,3,5,1,4,5,5,1,5,5,4,4,3,2,4,4,1,1,5,2,1,2,3,4,4,1,5,1,1,2,1,3,3,1,2,1,1,2,2,1,4,2,2,4,5,5,4,2,5,4,3,2,1,5,2,5,4,4,4,2,2,2,5,5,2,2,1,4,5,4,2,3,2,2,1,5,4,1,4,1,5,5,2,5,4,4,4,1,1,3,3,4,2,1,1,5,2,5,5,2,4,1,3,3,1,5,5,1,5,5,2,1,5,2,2,4,2,4,3,1,3,3,2,2,5,2,2,2,1,1,3,3,4,2,5,5,1,1,3,1,2,4,2,3,5,2,1,2,5,2,4,3,4,5,5,4,2,3,5,4,2,4,3,2,1,2,5,3,5,3,5,2,1,5,3,3,1,2,3,4,1,4,4,2,2,3,4,3,2,2,1,1,4,3,1,3,3,2,2,2,2,1,4,5,1,3,2,2,3,3,3,5,2,4,5,2,4,1,1,2,5,2,3,3,3,1,3,1,5,5,1,5,2,3,3,2,1,2,3,1,2,4,5,5,1,3,5,5,1,5,2,5,5,1,2,5,2,2,5,5,1,4,4,4,3,2,3,2,2,2,3,3,2,3,1,3,5,5,5,3,3,1,1,5,5,4,4,1,5,1,5,5,3,2,2,3,3,4,2,2,4,1,1,3,2,3,4,3,3,4,2,5,1,4,5,2,1,2,3,5,2,1,2,3,3,4,5,5,1,4,2,5,5,4,4,2,5,5,5,3,1,4,5,5,1,3,3,5,5,4,5,5,2,1,4,1,2,5,2,1,3,4,3,2,2,5,1,5,3,3,1,5,2,4,4,1,4,3,4,2,3,3,2,4,4,2,2,2,5,2,4,5,2,3,1,5,3,2,3,2,1,3,3,1,1,5,4,2,1,3,2,2,4,2,1,1,4,1,4,3,3,4,3,1,1,1,3,2,3,4,5,5,4,2,1,1,1,4,5,1,2,5,2,2,3,1,1,5,4,2,1,5,1,5,4,4,1,4,2,2,1,3,5,1,2,5,2,1,5,1,2,4,3,4,4,3,4,2,3,5,1,5,2,1,5,5,2,3,1,4,3,3,3,4,2,2,4,1,5,3,4,2,3,1,5,3,5,4,3,2,1,4,4,1,4,3,4,4,5,5,1,3,3,2,4,5,1,2,3,5,4,5,4,1,1,1,4,5,4,1,3,5,4,5,2,2,3,5,5,1,5,3,4,4,4,3,3,1,3,3,3,3,5,5,3,2,5,4,4,2,1,1,1,3,1,4,5,5,2,3,2,2,5,3,3,1,1,1,1,5,2,5,3,2,2,3,2,2,4,3,5,1,3,5,5,2,1,2,4,5,4,2,5,1,3,1,5,3,5,2,5,3,2,2,5,1,5,5,4,1,1,3,1,3,1,3,5,3,5,2,2,1,4,3,2,2,4,1,1,2,4,3,4,4,2,4,2,1,3,5,5,5,2,4,3,2,1,1,1,3,5,4,4,1,4,2,3,5,5,3,4,1,3,2,4,1,3,3,1,2,4,4,2,2,3,1,1,2,1,2,2,5,5,4,4,5,5,4,4,4,1,4,1,2,5,5,5,5,1,1,1,2,4,1,2,1,5,5,5,4,4,2,5,5,1,2,1,1,1,4,1,1,2,4,3,1,2,3,2,2,5,4,2,1,1,5,5,3,1,4,2,3,5,4,1,1,4,3,4,1,4,5,1,1,2,2,2,3,5,4,2,4,2,3,4,1,4,5,3,4,4,5,4,5,2,1,5,5,3,3,4,2,5,1,3,4,3,5,1,4,4,5,1,2,5,2,3,1,2,4,1,4,5,3,2,1,1,3,1,3,2,1,1,1,2,1,4,2,4,5,5,2,5,5,2,5,4,5,2,4,2,2,1,5,4,4,2,3,5,5,4,3,4,3,5,3,3,5,3,4,3,1,1,3,5,4,4,1,1,1,4,5,2,1,4,5,1,4,1,2,3,2,3,3,3,4,1,3,1,5,3,3,5,3,5,2,4,2,4,4,2,5,1,1,2,5,5,3,5,5,3,3,4,2,4,4,1,4,5,2,1,1,5,4,3,2,2,2,1,3,3,1,4,1,2,2,1,1,3,3,5,3,1,5,1,4,2,1,1,4,1,5,4,5,3,1,2,2,2,5,4,4,5,2,4,4,4,3,2,2,5,1,5,3,1,4,4,3,5,5,3,4,4,4,3,3,2,3,5,5,3,3,1,2,1,1,2,2,3,2,3,1,1,2,2,4,1,4,5,1,2,4,3,3,3,5,5,2,5,5,3,5,2,2,2,2,5,1,1,5,4,1,3,2,1,4,1,5,4,2,1,1,2,4,2,1,4,2,4,1,5,3,5,1,2,4,1,3,2,1,3,5,5,3,2,1,5,5,5,2,1,2,2,2,4,5,1,3,5,1,4,5,1,1,3,1,5,1,2,3,3,2,1,1,5,2,4,4,2,5,4,3,2,4,5,5,2,2,5,2,2,5,3,5,1,5,2,5,1,1,5,1,5,2,1,1,4,1,4,1,4,4,5,3,4,2,3,1,3,1,5,3,2,2,2,2,1,5,4,3,3,5,4,1,5,2,5,3,5,4,4,3,3,5,3,4,2,2,3,4,3,2,4,4,3,4,4,3,2,4,1,2,3,4,3,4,2,3,5,1,5,5,2,5,2,4,2,4,3,1,5,4,2,1,1,3,4,2,2,3,1,2,4,3,4,5,5,3,2,2,4,2,5,3,4,1,2,4,3,5,3,1,1,3,1,1,4,4,1,1,4,2,3,3,1,3,1,3,5,5,4,2,1,2,1,1,5,3,5,2,5,5,2,2,2,4,1,1,3,3,4,3,3,5,5,1,1,1,3,2,1,1,4,2,3,2,4,2,2,2,3,3,1,2,1,4,5,4,1,2,2,1,2,2,2,3,2,5,1,5,5,4,1,3,3,3,5,3,5,5,1,5,1,3,5,4,3,4,5,1,5,2,2,4,3,4,2,2,3,3,3,1,5,2,2,5,2,2,4,2,3,2,1,4,3,1,3,1,5,1,3,4,5,4,3,1,1,1,2,4,4,2,5,1,5,3,4,4,1,2,2,2,1,5,1,4,2,2,3,2,2,2,1,5,5,1,3,3,5,1,3,2,1,5,1,5,5,4,1,3,1,3,2,5,3,1,5,5,2,3,3,2,4,1,5,4,3,2,3,4,2,5,4,2,2,1,2,5,3,4,2,5,5,2,5,2,5,3,2,2,1,2,1,4,5,4,5,5,5,1,2,1,4,2,3,2,3,1,5,5,3,5,1,5,3,3,3,1,4,2,4,1,2,5,4,5,3,1,4,4,4,2,3,3,2,5,4,3,2,1,3,5,1,3,1,3,2,2,5,5,5,2,3,4,3,2,4,1,5,2,5,3,3,4,3,3,5,5,4,3,4,3,1,5,2,4,1,1,2,2,5,2,2,1,3,2,4,4,3,2,5,5,5,5,1,3,2,2,3,4,4,4,1,1,3,2,4,1,5,2,2,2,3,3,4,3,5,4,4,1,5,5,4,5,1,5,3,1,1,2,3,3,4,5,4,1,2,5,1,5,5,4,5,3,5,1,3,2,3,3,4,2,4,5,4,1,1,3,5,4,1,1,5,4,5,5,1,4,2,2,4,5,2,1,4,4,4,4,5,5,3,3,3,4,5,2,4,3,2,5,3,3,1,2,2,4,2,4,5,5,4,2,1,4,1,1,5,4,5,2,2,4,1,5,5,1,4,5,4,3,5,1,1,3,5,5,5,5,2,5,2,4,5,1,4,4,3,2,2,2,1,3,5,2,5,4,1,3,1,3,1,1,5,1,5,4,2,3,3,4,2,4,4,2,2,5,2,2,3,5,3,5,5,5,1,4,1,5,5,3,3,5,2,4,2,2,5,1,5,4,5,1,3,5,2,1,5,1,1,3,5,2,2,1,5,1,2,2,5,2,1,3,5,5,5,2,3,2,1,3,5,4,3,2,2,2,2,2,4,1,3,3,2,5,2,5,3,5,2,2,5,5,5,1,4,2,3,2,4,4,5,4,4,4,4,4,2,3,4,2,2,2,1,1,2,3,3,2,5,4,5,3,2,2,5,3,3,1,4,5,3,5,3,2,5,2,2,3,1,3,4,2,5,1,2,5,5,3,1,5,5,3,1,5,5,2,5,3,2,3,1,5,5,1,5,2,4,3,4,1,1,1,5,2,4,5,3,3,2,3,2,4,5,1,1,3,4,2,2,2,3,3,1,1,3,5,2,3,1,4,3,4,4,4,2,1,4,5,3,3,5,1,4,5,4,3,1,2,1,3,4,2,1,3,1,2,4,2,2,2,4,5,4,1,3,5,1,3,4,5,3,2,3,3,5,1,5,4,4,5,3,5,3,5,3,2,4,5,4,3,3,1,1,5,4,2,1,3,2,5,2,4,5,3,1,5,3,2,3,4,2,1,4,3,4,4,3,2,2,1,5,2,5,1,5,4,4,4,5,4,3,2,1,4,4,3,5,1,5,2,3,5,5,3,5,5,2,5,4,3,3,5,2,1,2,5,4,3,5,3,2,1,2,4,3,5,4,3,3,1,1,3,4,2,2,1,1,1,1,4,5,3,1,4,4,1,1,4,2,1,2,3,2,1,2,5,4,1,3,5,2,5,2,5,3,1,1,5,1,5,1,3,1,3,2,3,2,1,5,4,3,3,1,2,5,5,4,2,1,3,2,3,5,4,5,5,4,3,2,5,1,2,2,5,3,1,3,2,5,4,5,2,5,5,4,4,2,3,4,5,4,5,5,2,4,1,4,1,3,4,5,1,3,1,3,5,4,3,3,4,5,3,4,3,5,5,4,3,3,4,2,4,4,2,3,2,3,4,5,3,3,3,5,1,1,3,2,5,4,2,3,1,5,4,1,3,3,5,1,4,4,3,2,1,4,2,1,5,1,3,4,5,1,4,1,3,1,1,5,5,4,4,4,5,5,2,4,1,2,1,4,3,1,1,1,2,5,5,4,1,2,5,5,4,2,4,2,4,2,1,3,3,3,2,2,4,4,4,2,1,1,3,5,4,4,3,1,1,5,3,2,3,4,1,2,3,3,1,2,1,3,4,2,4,2,1,2,1,4,1,4,4,2,1,2,5,2,3,1,4,5,2,3,3,3,3,1,1,5,5,4,5,1,3,4,5,2,3,4,2,3,1,3,4,2,5,4,5,2,2,4,4,5,1,4,3,4,3,1,4,4,4,5,4,3,3,2,3,3,3,1,1,4,5,4,4,3,1,3,2,5,1,4,4,4,5,1,3,5,2,3,2,4,3,1,2,5,3,2,1,5,4,2,1,5,2,3,2,2,3,1,2,5,4,5,5,1,5,4,5,4,2,4,1,5,2,5,4,2,3,1,5,2,4,3,4,5,4,5,2,2,2,2,5,3,1,4,5,3,3,5,4,4,5,3,1,1,3,1,4,3,4,4,5,4,4,1,5,3,2,5,4,2,4,2,3,1,1,4,5,5,1,1,1,1,5,5,3,4,5,5,5,1,5,3,2,4,4,3,4,5,4,4,5,2,2,3,2,5,5,4,5,1,3,4,2,5,2,1,5,2,1,1,5,1,2,1,1,2,5,1,1,5,3,2,2,1,3,2,1,3,2,3,1,5,5,4,4,1,3,2,4,2,4,4,5,2,5,1,3,1,5,5,2,3,5,3,4,5,3,5,4,5,3,5,3,2,5,2,1,4,2,2,1,5,3,2,1,5,3,4,2,3,3,4,3,5,3,3,2,4,1,1,2,4,5,5,1,5,4,5,5,1,1,5,3,2,4,5,2,5,2,1,2,1,2,3,2,5,1,4,4,4,5,2,2,2,5,5,5,4,4,1,4,3,5,1,3,4,2,3,2,2,4,1,1,3,4,4,2,5,2,4,3,3,2,2,3,3,1,4,5,3,1,1,1,4,5,1,2,2,4,1,5,2,5,4,2,5,2,1,5,5,3,2,5,3,5,3,1,1,2,3,3,2,1,5,3,1,5,5,4,5,3,2,3,1,5,2,5,2,3,5,1,3,2,3,3,4,5,3,1,2,3,2,2,5,3,4,5,5,5,1,3,4,2,2,1,5,2,3,5,5,2,1,3,5,2,5,5,1,1,2,3,5,1,4,5,1,5,1,2,4,1,3,4,5,3,2,3,3,2,5,5,5,3,5,5,4,3,3,5,5,3,1,5,3,1,5,3,5,2,5,1,5,4,5,1,1,5,2,1,3,5,4,2,5,3,1,1,4,1,3,3,2,5,5,2,4,1,4,5,4,5,4,2,2,1,5,5,5,1,4,3,1,1,1,2,1,5,4,2,4,1,1,3,4,3,2,2,3,4,1,4,5,5,1,1,4,4,3,4,1,2,4,4,4,2,5,5,3,5,1,1,5,4,3,3,4,1,1,5,2,2,1,2,5,2,4,3,5,2,5,2,5,1,1,1,3,5,4,3,1,3,4,1,2,5,2,2,1,2,4,5,5,4,5,1,4,5,2,2,3,5,1,3,4,2,3,1,3,4,3,3,2,3,3,1,5,3,3,3,3,1,4,4,3,4,2,3,3,1,2,2,1,2,1,4,2,3,2,2,2,2,4,3,4,1,1,4,3,2,5,2,5,5,4,2,3,3,4,5,2,2,3,1,3,1,3,5,1,2,5,3,3,5,5,2,1,4,4,3,2,5,3,4,4,5,1,3,5,5,4,2,1,2,2,5,4,4,4,3,4,3,2,3,3,2,2,2,5,2,2,5,5,3,3,3,4,2,2,1,2,4,1,4,3,1,5,4,5,4,1,2,2,1,3,5,5,2,2,4,3,5,4,4,4,2,4,2,2,2,3,4,3,1,1,3,3,5,2,2,2,4,3,2,3,1,5,1,2,3,1,2,1,2,4,4,2,3,5,5,5,4,5,3,4,4,4,5,5,4,3,1,4,3,2,4,5,3,5,3,2,4,1,1,4,2,2,1,1,3,5,2,4,1,2,4,3,4,1,1,2,2,1,1,3,2,1,1,5,2,3,5,4,5,5,3,4,1,1,5,1,1,1,2,1,4,4,3,3,5,4,5,2,1,1,2,1,2,1,2,2,5,2,3,1,3,1,1,1,1,5,4,3,2,3,4,5,5,1,5,2,5,5,5,4,2,1,2,2,2,3,1,3,1,5,3,1,1,1,1,3,1,4,3,5,5,1,5,1,3,2,5,2,4,5,3,2,4,5,2,5,5,3,3,4,1,5,3,5,1,1,5,4,4,1,1,2,3,4,4,1,1,5,2,3,4,4,3,1,3,5,4,4,1,4,4,1,1,3,4,2,5,2,4,3,3,3,1,2,2,3,3,1,2,5,3,2,1,4,5,5,3,4,3,4,4,1,4,4,1,1,5,3,5,3,4,5,4,3,2,2,2,1,4,3,4,3,5,1,2,1,2,2,2,4,1,2,5,2,5,2,3,4,1,2,4,5,1,5,1,1,3,2,2,4,5,4,3,4,5,1,4,3,3,4,4,1,5,1,1,1,4,3,2,2,3,3,4,5,5,5,2,1,5,5,1,4,5,3,3,5,3,2,5,1,3,2,1,5,2,4,2,4,2,4,3,3,3,3,5,4,4,4,1,5,5,4,3,3,2,3,1,3,2,5,4,2,1,5,2,3,1,2,4,4,4,3,2,5,3,2,2,2,5,1,1,5,1,5,5,2,2,1,4,5,1,1,5,2,4,3,3,3,4,5,3,3,1,3,2,4,1,5,5,3,3,1,5,5,3,3,3,3,5,4,5,3,4,1,4,2,3,1,1,3,5,1,2,1,1,1,2,5,3,5,2,5,1,3,2,2,1,4,3,5,3,4,3,3,4,2,4,5,1,1,2,3,3,3,3,3,4,2,5,5,3,5,2,3,3,3,1,3,4,5,3,2,2,5,5,4,2,5,4,3,5,3,4,3,4,4,5,3,3,5,5,3,2,2,3,5,5,3,1,5,2,3,4,2,3,2,3,1,4,1,1,1,2,4,2,1,2,4,2,4,1,4,3,2,5,4,4,1,2,5,2,3,4,1,4,3,4,1,1,4,4,4,1,2,4,4,5,3,5,1,2,1,4,3,1,5,1,5,2,3,2,2,4,4,4,4,4,2,3,3,3,5,4,1,2,2,2,4,3,1,2,1,2,2,5,4,2,4,3,5,2,2,4,5,2,1,3,1,1,4,4,4,4,3,1,3,1,1,3,4,4,3,1,5,4,1,3,1,1,5,1,5,4,5,2,4,1,5,4,4,5,1,4,5,3,5,4,1,4,5,4,5,2,4,2,3,5,1,4,1,1,1,2,3,4,1,2,1,2,2,3,3,2,4,1,3,2,3,5,4,3,4,3,5,5,2,5,5,3,2,2,1,4,1,4,2,5,4,3,4,1,3,5,5,2,3,3,3,5,2,1,3,3,1,1,4,2,2,1,2,5,4,2,5,5,1,3,2,5,2,5,3,4,4,5,3,3,3,4,3,2,5,5,3,5,2,2,1,4,1,1,1,5,4,3,3,2,5,1,5,1,1,2,1,1,4,2,4,3,1,5,3,2,5,5,4,2,5,4,3,3,1,2,3,5,2,1,3,3,2,4,4,5,3,3,4,3,4,3,5,3,4,3,2,4,3,4,3,4,1,3,5,5,3,5,2,4,5,5,1,5,4,2,1,1,4,4,2,3,2,3,2,1,2,1,5,1,2,2,4,5,5,2,3,1,1,1,3,4,2,2,4,3,3,5,3,2,4,5,2,4,4,4,4,1,2,2,2,1,2,2,2,2,5,2,2,5,1,3,3,2,1,4,5,3,1,4,2,2,5,2,3,3,3,2,3,5,3,3,2,5,3,1,2,2,2,4,3,4,3,3,2,3,4,4,4,2,1,3,4,3,3,4,3,1,5,3,1,3,4,3,1,2,2,3,2,5,2,4,5,2,1,2,4,3,4,4,5,1,3,2,5,4,1,2,3,3,2,4,2,5,2,2,2,1,3,4,1,5,1,5,2,2,1,5,5,4,1,2,5,4,2,1,1,3,4,3,3,2,1,3,3,3,5,5,2,2,3,2,5,3,3,2,4,2,2,1,4,1,5,5,1,1,3,4,3,5,5,1,5,5,3,4,4,2,4,1,4,3,5,1,5,5,2,3,4,3,1,1,1,3,3,5,3,4,5,2,2,1,2,4,5,1,5,3,4,3,2,5,5,1,5,5,5,3,4,1,1,3,1,3,3,5,1,5,3,3,3,2,2,3,2,5,4,1,1,3,4,2,4,5,3,1,3,5,4,1,5,4,1,2,4,3,5,2,4,4,4,4,5,1,4,3,3,3,4,2,1,5,3,1,5,1,5,1,1,4,2,3,5,5,3,5,4,4,2,5,3,1,3,3,2,3,3,2,4,2,4,4,2,4,3,1,1,1,2,2,1,4,4,1,2,4,5,4,4,1,2,3,2,3,5,5,1,2,2,3,3,4,5,2,1,2,4,3,5,2,3,3,1,4,5,5,5,4,1,1,3,5,1,2,1,3,3,3,5,5,1,5,4,4,2,2,2,2,3,4,5,4,3,3,5,3,2,5,1,1,4,1,1,5,5,4,4,3,5,5,1,2,2,1,1,2,5,5,5,1,2,1,3,2,4,3,1,5,5,1,5,4,4,3,5,5,4,1,4,5,5,1,5,3,5,2,4,4,1,3,3,3,5,5,4,4,1,4,5,5,2,3,5,2,4,3,2,5,2,3,5,5,3,3,1,5,5,2,3,2,5,1,5,5,4,1,5,2,1,3,4,2,4,1,3,2,2,5,3,5,1,1,1,4,3,3,3,4,3,1,3,5,1,1,1,3,4,5,4,4,2,1,1,2,4,2,4,1,3,4,4,1,1,4,1,4,3,1,5,3,5,2,1,4,4,1,4,2,4,5,3,1,2,5,4,2,4,3,1,4,5,4,5,1,3,4,3,1,2,5,3,5,3,4,1,1,2,1,4,3,5,5,2,3,1,5,2,2,1,5,1,5,5,5,2,1,2,3,2,1,1,3,5,2,4,1,3,1,4,5,4,2,4,4,5,4,1,4,4,5,5,2,5,2,1,5,1,4,5,4,3,1,5,2,4,1,4,1,5,5,2,1,4,2,3,2,3,2,5,5,2,3,5,1,2,3,4,5,2,3,4,1,2,1,5,3,2,2,3,5,4,3,5,2,2,5,3,3,2,2,1,2,2,4,2,5,5,2,1,4,3,5,2,2,2,1,3,5,5,4,5,4,2,2,3,1,4,3,3,4,5,3,2,5,2,2,1,5,4,3,4,1,4,4,2,5,3,1,4,4,5,5,5,3,4,4,3,1,4,4,1,3,3,5,1,2,2,1,1,3,4,5,3,3,5,3,4,3,3,2,2,3,2,3,3,1,4,3,2,4,3,4,2,1,2,3,3,1,3,2,3,4,3,3,2,3,1,5,5,3,4,5,3,1,3,1,1,1,4,1,3,1,1,1,3,1,2,1,4,3,3,4,5,2,3,1,1,3,5,1,5,5,4,1,5,1,5,3,4,5,1,1,5,4,4,2,1,1,4,4,5,1,1,4,4,4,3,4,1,4,4,2,2,5,1,4,4,3,5,2,5,1,2,1,4,1,4,3,1,1,1,5,2,4,4,5,2,3,5,5,5,1,2,4,1,2,4,1,1,3,5,5,5,4,1,3,2,4,5,5,3,5,3,1,1,1,4,3,3,4,5,1,1,3,5,5,4,3,5,3,1,2,2,5,2,5,2,5,1,2,3,1,4,1,1,5,4,3,3,1,2,2,5,2,5,4,3,1,4,3,5,1,1,4,1,3,1,1,1,2,3,5,1,2,1,5,5,5,5,5,3,2,2,4,2,1,5,5,4,2,3,1,2,1,5,2,2,5,5,5,3,5,2,3,3,5,5,3,2,2,3,2,1,2,1,2,4,4,5,1,4,3,1,5,3,2,4,4,3,2,3,3,5,4,2,5,4,2,3,3,3,5,3,2,2,2,5,1,4,1,3,5,4,4,4,4,2,2,5,1,4,5,4,2,2,5,4,4,3,2,4,2,2,5,3,4,2,4,4,5,2,4,5,3,3,3,5,1,5,4,4,4,2,5,2,5,3,4,3,1,1,1,5,1,2,5,2,1,3,3,2,4,3,2,2,4,5,4,1,2,1,2,3,4,5,2,3,3,4,1,5,4,4,1,1,5,3,1,4,4,5,2,1,3,4,4,1,1,5,4,1,2,5,3,1,3,3,5,4,3,5,1,3,4,3,4,2,3,1,3,4,5,3,3,2,4,4,1,1,5,1,3,4,5,3,4,5,2,2,4,3,5,2,5,3,3,2,2,3,2,2,4,3,2,2,5,2,4,1,2,2,5,2,2,1,3,5,3,3,5,5,4,2,1,4,1,1,2,1,5,5,5,4,1,2,4,4,3,1,2,4,4,1,4,3,2,2,3,1,1,2,3,4,2,1,5,1,3,4,1,5,1,1,3,2,1,2,1,5,2,1,3,1,4,1,2,3,2,2,1,1,2,4,1,2,3,5,2,3,2,4,4,4,1,5,4,2,3,1,5,4,3,5,3,3,1,3,2,2,2,5,4,2,2,2,1,1,4,4,2,1,3,5,2,3,1,2,1,4,1,2,4,2,3,4,5,2,3,5,1,4,4,4,2,5,4,4,2,5,3,3,2,3,1,5,2,4,4,1,1,4,1,3,4,3,3,5,5,3,3,5,5,4,1,3,5,1,4,2,1,3,4,1,2,3,4,4,1,1,5,1,4,5,2,1,3,1,2,1,2,2,5,1,4,5,5,2,3,4,4,4,5,1,3,4,4,4,5,2,4,1,5,3,5,5,3,2,1,5,3,3,2,5,5,3,3,1,3,1,3,4,3,2,2,3,3,2,1,1,2,3,1,3,1,3,5,2,3,3,2,2,1,5,3,1,4,3,3,5,1,4,2,2,5,4,3,1,2,2,1,4,2,4,3,2,4,2,3,5,2,2,1,4,4,3,3,2,1,3,2,2,5,1,5,3,5,4,1,3,4,2,2,4,2,2,1,4,1,3,5,3,3,4,3,5,5,5,2,2,3,3,4,3,1,2,1,3,4,3,1,1,4,5,1,4,2,4,1,2,2,5,1,2,1,2,4,1,5,5,1,4,1,4,3,3,5,5,4,2,3,2,3,1,2,3,1,4,1,2,3,4,3,1,3,4,4,3,3,5,2,3,2,3,3,1,1,3,5,1,4,1,3,1,2,1,1,4,3,2,2,1,5,2,2,3,4,4,3,5,5,1,2,4,2,5,3,2,5,3,3,5,4,1,5,5,5,5,1,3,3,5,2,3,5,3,4,5,5,4,1,3,5,1,5,4,5,1,1,2,5,4,1,4,1,4,4,5,5,5,1,3,3,2,1,3,3,2,1,4,1,3,5,5,3,4,4,1,4,4,1,2,4,4,3,1,1,5,5,4,3,5,2,2,2,1,3,2,1,5,4,3,4,1,2,1,1,2,4,5,5,5,3,5,5,4,1,1,2,2,4,5,5,3,4,1,4,1,3,4,4,1,2,5,3,1,2,1,4,3,3,2,5,2,1,3,4,4,1,5,1,1,3,3,3,3,4,3,2,2,2,1,3,3,5,3,3,3,2,1,5,2,3,4,1,5,3,5,3,5,2,5,2,3,1,5,4,5,5,5,2,5,4,5,3,2,2,2,3,3,4,1,3,4,4,2,3,4,1,2,1,1,1,2,1,5,4,2,2,3,2,2,4,2,1,4,1,4,3,4,1,2,3,5,2,4,4,1,2,4,3,3,1,3,5,4,1,2,5,5,4,1,3,4,5,2,3,1,3,4,5,2,3,2,3,3,1,2,3,5,5,3,5,2,5,5,2,4,2,4,3,5,2,2,5,2,2,5,1,3,3,5,4,4,1,3,4,1,5,1,1,1,2,4,5,1,3,1,4,1,1,1,5,4,3,2,2,3,5,2,3,3,1,1,3,5,2,1,5,1,5,5,4,1,1,4,2,1,4,5,1,4,2,1,1,1,3,3,2,2,1,1,4,4,5,1,1,4,1,1,4,1,2,3,2,4,2,3,2,3,3,3,5,3,5,4,3,3,2,5,4,1,2,5,1,3,5,3,5,5,4,3,1,3,3,5,2,4,1,5,5,3,4,5,4,4,5,4,5,2,1,5,3,3,5,2,3,1,1,4,1,1,1,4,2,3,3,4,2,3,4,2,5,2,3,3,5,3,5,3,4,2,4,1,5,1,5,3,3,4,4,1,5,1,1,2,1,3,5,2,5,2,1,1,3,4,4,4,4,4,1,2,1,5,2,2,5,1,5,3,5,4,2,2,1,2,4,3,1,5,2,2,2,4,2,3,2,2,5,1,5,2,3,5,4,3,1,5,5,5,1,1,3,4,3,3,3,5,5,2,3,1,3,5,4,4,3,1,1,4,4,5,1,3,4,2,2,1,1,2,4,5,1,3,1,3,5,4,3,5,4,5,3,1,5,1,5,5,5,3,3,2,1,2,5,1,3,3,5,5,2,2,4,3,1,4,4,3,4,1,1,3,4,2,4,5,4,4,4,1,3,3,5,3,4,3,4,5,2,3,1,2,2,5,3,5,3,4,4,2,4,2,4,3,2,3,1,5,3,2,4,1,3,2,2,4,3,1,1,1,5,5,4,5,2,4,4,1,4,4,2,5,5,1,4,2,2,1,2,4,4,1,5,2,4,3,3,5,2,1,3,3,2,3,1,2,2,3,1,2,4,2,3,5,4,5,5,4,4,3,2,1,5,1,1,1,1,2,3,4,1,5,1,3,5,5,2,5,1,3,5,3,5,4,1,4,3,5,4,2,5,5,5,2,4,3,4,2,3,5,3,2,5,3,5,5,3,5,2,3,1,3,2,4,1,4,4,5,3,3,2,2,4,2,1,3,5,3,1,1,2,1,3,3,4,2,4,1,3,3,3,3,4,4,1,5,4,5,1,5,5,2,4,4,5,3,1,1,2,5,5,2,3,4,5,5,1,4,3,5,3,5,5,2,4,5,2,4,1,5,5,1,2,2,2,1,5,1,5,1,2,1,3,2,5,4,3,5,1,5,1,2,1,4,2,3,3,5,1,2,5,3,5,1,1,5,4,1,2,1,2,1,2,5,4,1,3,2,1,2,1,4,4,4,5,3,4,1,3,1,3,4,1,1,5,3,4,1,2,4,4,5,1,4,5,5,3,2,2,4,5,2,5,1,1,3,1,1,5,2,5,2,3,5,4,4,2,4,4,4,2,2,1,1,1,3,5,3,4,1,5,3,4,4,2,3,4,5,1,3,5,1,4,4,2,2,2,4,5,2,1,1,4,5,4,3,5,5,4,4,2,2,1,3,1,3,2,4,1,4,4,1,1,1,2,5,1,1,3,3,3,4,4,4,1,4,4,4,1,1,4,4,3,4,1,5,2,5,1,3,1,4,2,1,2,5,5,1,5,2,4,4,3,4,3,4,2,3,3,4,1,4,2,1,5,4,3,4,1,1,2,3,2,4,5,3,3,2,4,3,4,3,1,3,3,1,4,5,1,5,1,5,3,1,1,2,4,5,2,3,4,2,4,4,1,2,1,5,1,5,1,1,2,1,2,3,1,2,3,1,3,5,3,5,3,3,5,1,5,3,4,5,4,5,5,4,5,2,2,4,1,4,1,3,5,5,1,5,3,5,4,4,4,3,4,1,3,4,5,1,3,3,4,2,1,2,3,2,5,4,1,1,5,1,5,1,1,1,4,2,1,3,5,4,4,5,3,5,1,1,5,4,2,1,1,4,2,2,1,2,4,5,5,4,4,4,1,3,3,1,2,5,3,4,3,1,2,2,5,4,5,1,1,5,3,2,4,1,3,2,3,3,3,2,2,5,1,1,3,4,5,4,5,3,4,3,1,5,1,5,5,1,2,2,3,3,1,3,1,1,3,2,2,1,1,3,5,3,4,4,5,5,3,1,1,3,1,2,4,2,4,1,2,3,4,2,4,4,1,5,3,5,4,1,5,3,3,2,3,5,3,3,4,5,1,4,1,3,3,3,2,5,5,3,3,3,5,1,1,3,2,1,2,2,1,1,1,2,4,1,5,1,1,5,5,3,4,1,3,3,5,3,2,3,5,3,1,1,4,2,4,5,4,1,1,3,2,1,2,3,4,4,3,2,5,4,4,3,3,5,3,3,4,5,3,1,5,1,4,2,2,1,4,5,3,3,3,1,4,2,2,4,3,1,4,3,4,2,3,2,1,5,5,2,3,1,4,1,5,1,4,4,3,1,5,2,4,5,2,1,2,1,5,2,4,2,3,2,1,4,2,2,5,5,5,1,5,1,3,3,5,3,4,4,1,4,5,4,5,3,1,3,1,1,3,4,4,2,3,5,1,3,5,3,2,4,1,2,4,1,3,4,3,5,1,3,1,1,4,5,2,5,4,5,3,5,3,1,4,4,4,2,4,1,5,1,1,4,4,2,4,1,1,3,3,5,5,2,2,1,1,5,3,3,3,1,1,3,3,2,1,1,1,3,2,2,4,5,1,2,4,2,1,3,5,5,5,5,2,1,3,2,5,2,1,3,2,3,4,1,4,1,5,3,3,4,2,4,1,2,4,5,4,1,4,5,5,3,1,1,3,4,1,2,5,5,1,3,4,5,2,3,3,4,3,3,5,1,1,5,1,5,1,2,2,1,1,2,4,3,2,4,3,3,1,4,1,2,5,3,5,4,5,1,3,1,2,3,5,4,5,3,3,1,4,3,3,5,2,2,4,5,2,5,1,4,1,4,5,5,3,2,4,4,5,2,3,2,2,2,2,4,3,3,1,4,4,5,4,1,3,3,2,1,5,5,2,5,2,1,2,1,4,4,1,5,3,3,1,4,1,2,3,1,2,2,4,4,2,4,1,5,4,3,5,1,4,3,4,1,5,2,3,5,3,3,3,1,5,1,5,1,5,5,1,3,2,5,5,2,1,5,3,1,2,2,2,2,4,5,3,5,3,5,1,5,1,4,2,1,4,4,3,5,4,1,3,5,3,4,3,3,3,3,4,2,5,3,1,2,5,4,4,5,4,4,4,2,3,3,5,3,5,1,3,1,3,4,4,2,2,4,1,1,1,5,2,1,1,3,5,1,4,5,3,1,1,4,2,2,2,3,4,5,5,4,5,1,1,1,5,4,5,4,5,4,5,5,4,5,2,4,4,2,3,4,4,5,3,4,5,3,2,2,1,2,4,3,5,1,5,2,3,4,5,4,1,3,5,5,5,3,1,1,4,5,3,2,1,4,4,5,2,1,4,2,1,3,5,2,5,1,3,5,1,1,5,3,2,2,4,1,1,3,2,1,3,4,4,4,5,5,4,2,1,4,2,5,3,5,5,5,1,1,1,2,2,5,2,5,2,4,5,1,4,1,3,4,3,5,5,1,1,4,4,3,5,1,4,4,3,4,4,1,4,3,4,3,1,2,4,2,2,3,2,3,1,1,4,4,3,1,1,2,3,2,4,1,3,3,5,5,4,4,3,3,4,1,4,2,3,2,5,4,5,3,5,2,2,5,2,5,3,2,4,2,3,1,5,5,2,2,5,4,5,3,4,2,1,2,2,4,3,5,4,4,4,5,1,4,2,5,5,3,3,4,2,4,4,3,1,1,3,5,1,3,2,4,2,4,1,2,3,4,4,3,1,4,4,1,3,5,4,4,1,1,3,5,2,3,5,3,2,3,1,1,2,3,5,5,2,4,1,3,2,1,4,2,4,5,2,5,1,4,2,3,4,5,1,1,2,3,5,3,4,3,2,1,5,3,1,2,4,3,5,4,5,2,3,2,2,2,1,3,4,5,1,4,2,2,4,3,2,3,3,5,2,5,5,2,4,5,1,4,5,5,4,1,3,2,2,2,5,1,4,1,2,4,3,2,1,3,3,4,3,3,4,2,4,4,4,2,3,1,3,2,1,4,4,3,1,4,3,2,4,2,2,4,5,2,2,4,3,3,3,5,4,3,5,1,5,1,3,4,4,1,2,5,5,4,2,4,2,2,4,5,2,1,5,5,1,3,4,3,3,2,5,3,3,1,1,5,2,2,2,2,1,1,2,2,1,1,4,3,2,4,4,3,2,1,3,5,5,1,2,2,2,3,4,4,3,2,2,3,1,1,3,5,1,5,1,4,2,1,5,1,3,1,3,2,3,2,2,2,3,1,5,5,2,5,5,2,1,5,4,2,5,3,2,2,1,5,1,5,2,2,5,2,1,4,2,3,3,5,2,3,4,1,2,3,4,3,1,3,2,2,1,1,1,3,2,1,1,4,2,2,5,4,1,2,1,5,5,4,4,2,4,1,4,1,5,5,5,4,4,3,4,5,5,5,3,3,3,5,4,1,3,1,4,2,3,3,2,5,5,4,3,5,5,4,5,2,3,3,5,2,4,2,5,4,4,2,4,1,2,1,1,4,1,1,1,5,1,2,4,3,4,5,2,3,5,5,3,1,5,1,1,4,1,5,5,1,4,3,1,4,3,2,4,1,2,4,3,5,3,4,3,5,1,5,2,5,1,3,3,5,2,4,4,5,5,1,4,1,2,3,1,3,4,5,2,5,2,4,3,2,3,3,3,4,1,2,3,5,2,1,1,4,5,3,5,3,2,4,3,2,3,1,4,1,3,3,1,4,3,5,4,5,2,2,3,4,1,3,5,2,1,3,5,1,4,5,3,5,1,5,4,1,1,3,2,2,3,3,2,5,2,5,5,1,3,1,1,1,4,5,5,4,4,2,4,3,3,5,3,4,4,5,4,4,2,2,3,5,1,3,1,1,2,3,5,2,3,2,4,3,2,3,1,4,4,2,2,1,3,4,4,3,2,3,5,5,1,4,4,1,3,3,5,5,5,3,2,4,3,4,5,5,4,2,1,4,2,4,2,2,3,1,1,2,3,2,4,2,3,3,3,3,5,1,5,4,4,5,3,1,4,1,4,5,5,2,4,5,3,1,3,4,4,4,5,2,2,5,4,5,3,2,2,5,5,1,3,4,4,5,5,5,3,4,5,1,5,4,2,2,5,4,1,5,3,2,2,1,2,3,5,1,2,3,5,3,2,2,3,1,5,4,4,5,1,2,5,3,5,5,5,4,3,1,3,5,3,4,5,4,2,4,2,1,4,3,4,1,4,4,4,3,5,2,1,4,5,2,5,4,2,5,1,3,2,5,4,4,5,5,2,4,2,1,5,3,3,4,5,3,2,4,3,5,1,3,1,2,5,1,1,2,2,5,2,3,4,3,3,1,1,5,4,1,4,5,2,4,1,2,2,4,3,5,4,5,4,5,1,2,3,1,4,3,2,3,3,2,1,3,5,4,4,1,2,2,2,4,2,2,4,4,1,2,4,3,1,3,2,4,3,4,1,3,1,5,3,1,5,4,4,2,5,2,2,3,1,2,2,4,5,1,1,5,4,1,3,5,4,5,1,1,4,2,5,4,2,4,5,5,2,2,1,1,5,5,4,2,2,2,4,5,3,3,5,2,1,2,2,4,5,5,1,5,3,1,1,3,2,3,4,2,1,4,3,5,1,4,4,5,1,5,5,4,5,3,3,5,3,3,5,5,3,1,4,3,1,1,2,5,3,2,5,1,5,2,1,2,5,1,4,2,5,5,2,2,2,1,3,1,2,5,3,3,5,2,3,4,4,2,5,1,4,1,1,5,1,5,4,5,4,3,3,5,5,3,4,4,1,5,1,5,2,5,5,5,2,5,5,4,4,5,1,5,4,3,4,2,3,3,2,2,5,5,1,2,3,3,2,3,3,3,3,3,4,5,4,1,5,5,4,2,2,4,3,1,1,3,4,2,4,1,2,2,2,1,3,3,1,3,1,5,3,3,1,3,4,5,2,1,4,1,3,5,4,1,4,1,2,1,2,2,5,5,4,1,1,5,4,3,4,5,1,1,3,5,4,1,4,5,1,3,3,1,3,3,3,1,1,4,4,4,3,5,3,4,3,2,2,5,1,3,2,4,1,3,4,2,5,3,3,2,3,3,2,1,1,3,3,4,4,1,4,3,1,2,1,3,4,2,5,5,2,2,5,1,5,3,4,2,4,2,1,5,1,3,3,3,3,4,5,1,4,3,1,4,5,5,5,3,3,5,3,5,2,5,3,3,2,2,3,1,1,3,1,3,1,2,5,1,1,3,3,2,4,1,3,4,5,4,4,4,1,3,4,2,4,2,1,1,3,2,4,2,1,4,5,2,4,3,3,2,3,1,2,4,3,4,3,2,4,4,5,1,5,4,2,3,5,4,4,4,4,3,3,1,2,4,3,1,5,2,4,3,2,1,5,1,5,5,4,1,1,1,1,4,5,3,5,1,4,1,1,2,3,1,3,3,3,1,2,2,2,4,5,5,4,4,4,2,3,1,5,4,4,4,3,1,3,1,2,3,2,5,4,2,4,3,5,3,1,3,5,3,3,3,4,1,1,3,4,5,1,3,2,2,1,2,5,5,3,2,1,1,1,5,5,4,4,2,2,2,5,4,1,1,4,4,5,2,3,4,4,4,3,1,3,4,4,2,2,4,3,3,5,3,1,1,5,4,5,3,5,2,4,1,5,4,2,5,3,2,4,5,3,4,2,2,5,3,1,4,5,5,1,5,1,3,3,3,3,1,1,2,1,2,1,2,1,4,3,2,3,5,2,5,5,2,3,2,1,1,1,5,5,5,2,5,3,3,5,5,3,3,2,4,1,2,3,1,1,5,4,5,2,3,5,4,5,5,5,3,3,4,1,2,5,5,3,2,4,3,3,1,4,4,2,2,1,2,2,3,4,1,2,4,2,3,3,5,5,4,3,5,3,3,3,5,1,2,4,5,3,4,2,2,4,5,1,2,3,2,3,5,2,4,1,3,2,1,5,2,3,1,5,2,3,2,1,3,3,1,1,5,1,4,3,3,1,4,4,1,4,3,4,1,2,2,4,3,5,2,2,3,3,4,4,1,2,1,4,4,2,4,3,3,1,5,2,1,2,2,5,2,3,4,3,3,1,1,2,3,1,3,2,2,3,4,4,4,4,1,3,4,1,3,2,5,2,1,5,3,2,2,2,1,5,3,3,4,4,4,2,1,1,1,4,3,1,5,2,2,3,2,3,1,4,2,5,1,4,4,3,2,5,4,4,2,3,1,2,3,5,5,2,1,2,3,5,3,5,4,3,3,4,1,2,1,5,1,1,2,4,4,1,1,3,4,2,5,3,2,3,3,5,3,5,4,4,2,5,2,4,2,4,3,5,1,5,4,5,5,3,2,5,5,4,3,5,5,3,5,5,2,4,2,2,1,5,5,1,4,5,5,4,5,5,5,5,2,5,4,5,3,4,2,2,1,4,2,1,1,4,1,4,2,3,4,3,2,1,3,5,4,1,3,4,2,4,3,1,5,3,1,5,4,3,3,3,4,3,2,1,3,2,2,1,5,4,4,2,2,2,3,3,4,5,4,2,5,5,2,2,5,1,1,1,1,4,3,3,2,1,1,3,2,1,3,5,3,4,2,4,5,4,3,5,1,2,1,2,2,2,4,5,4,2,3,5,3,5,4,5,4,3,2,5,1,5,5,4,1,5,2,4,3,2,3,3,1,3,3,3,2,1,3,5,5,3,4,5,1,3,4,2,4,1,2,5,4,3,4,1,2,2,4,4,4,1,3,3,5,2,5,5,4,1,1,5,5,3,3,3,1,2,4,5,3,2,1,5,3,1,1,1,1,3,5,2,4,5,1,2,5,3,4,4,5,5,5,3,5,4,5,2,4,3,3,4,2,1,5,1,3,5,4,4,2,2,2,4,3,1,3,3,3,3,1,1,1,4,4,4,5,5,4,1,3,2,2,3,2,2,5,2,5,4,3,1,2,5,2,5,3,1,4,3,4,2,1,2,1,3,5,5,3,4,1,1,5,1,3,5,1,5,2,4,4,1,3,1,5,1,5,2,5,3,4,1,4,3,5,3,3,4,5,1,5,1,2,5,3,3,4,5,3,3,3,5,2,2,5,3,3,5,2,1,4,2,1,4,2,2,5,2,1,5,1,2,1,3,2,4,2,1,3,1,5,1,3,1,5,2,4,4,1,1,2,4,2,2,2,3,2,4,3,5,5,2,4,5,1,4,1,1,5,3,1,1,3,2,3,4,4,5,3,3,1,3,2,4,3,3,1,5,1,2,2,3,2,1,4,5,4,4,3,5,4,3,4,4,1,1,4,2,4,5,2,2,3,1,1,5,5,5,1,2,3,2,1,3,3,4,5,3,4,4,4,1,1,4,3,1,2,3,2,1,5,1,4,3,5,5,5,5,4,4,3,5,3,4,2,5,5,2,3,4,4,2,3,4,5,3,2,5,1,3,4,4,5,4,1,4,1,5,1,4,4,1,2,2,4,3,5,1,1,5,2,3,4,4,2,2,2,1,4,3,1,2,2,2,2,2,5,3,2,5,5,4,1,3,1,4,4,1,4,5,3,2,5,1,2,2,4,4,4,3,1,4,3,2,3,1,5,1,4,5,4,3,1,4,2,1,2,5,2,2,5,3,1,3,1,4,3,4,1,5,4,5,5,3,3,1,5,4,3,5,4,4,2,1,4,3,5,1,1,3,5,1,4,4,3,3,2,4,5,5,2,3,1,3,5,5,5,2,2,3,3,4,4,1,2,2,1,5,2,4,2,3,2,5,3,5,4,4,3,2,1,4,5,5,2,5,2,4,5,2,5,2,3,1,4,1,3,5,2,2,3,1,4,1,2,3,1,1,2,2,2,3,2,4,1,1,2,3,3,4,2,3,4,5,4,1,5,4,5,5,4,5,3,2,5,2,2,5,5,1,4,1,5,5,3,4,5,5,4,4,2,4,5,4,2,3,2,2,3,2,3,3,3,1,3,4,4,5,1,5,5,5,3,3,2,3,2,1,5,3,4,1,1,4,4,2,2,4,2,2,4,5,5,1,2,4,4,2,1,4,1,3,2,3,4,5,4,2,3,3,1,3,4,2,5,4,3,3,4,4,4,4,4,1,3,5,1,5,5,1,2,2,4,5,1,5,5,1,5,2,1,1,3,3,3,5,1,1,2,2,5,5,4,1,1,1,3,3,5,5,4,3,1,2,4,2,4,1,1,1,1,1,2,5,3,4,5,1,3,2,4,4,5,2,1,1,3,1,4,2,2,1,1,5,2,3,3,5,4,2,2,5,1,1,2,4,5,5,4,2,3,1,3,2,3,2,1,4,1,2,2,4,5,3,4,5,3,1,4,1,3,4,5,1,4,2,3,5,2,5,1,4,4,1,3,3,1,1,4,4,4,4,2,4,2,3,5,5,2,1,4,5,5,2,3,3,1,3,5,1,2,1,4,3,1,1,5,2,2,2,5,1,3,5,5,5,1,2,4,2,5,5,1,2,4,3,3,2,4,1,5,3,2,2,5,1,3,4,4,2,1,4,5,1,1,4,3,1,4,4,5,3,1,2,5,3,3,4,4,3,2,1,5,1,5,4,4,4,3,4,3,3,5,1,5,1,5,3,3,5,1,2,2,2,1,1,2,4,3,2,2,4,1,4,3,3,3,1,2,3,4,5,1,5,4,5,2,3,3,5,4,3,1,4,1,2,3,1,1,4,3,4,4,4,3,5,4,5,5,2,3,5,5,4,2,2,4,1,2,1,2,4,4,5,4,5,1,4,2,3,2,4,2,2,4,1,2,3,1,2,5,4,3,2,5,2,4,4,3,5,2,3,4,5,3,4,5,2,1,1,1,5,3,4,4,4,5,2,3,2,4,4,1,3,3,4,4,5,4,2,2,2,2,4,5,4,4,1,4,4,5,3,2,1,4,1,2,3,1,2,3,2,3,2,4,1,1,4,3,3,3,1,1,1,2,5,1,4,3,1,1,3,3,4,5,5,5,5,4,5,4,3,4,2,2,5,3,3,3,2,4,2,5,3,5,5,5,3,3,5,4,2,1,3,4,3,4,1,4,2,5,2,2,2,5,1,3,1,3,3,3,4,4,5,2,5,2,5,3,2,1,4,5,3,3,1,2,5,4,4,5,1,5,1,1,3,5,5,2,1,4,3,3,2,2,1,1,2,3,2,4,4,2,3,1,2,4,2,1,3,4,1,3,5,2,5,4,1,1,2,5,1,2,2,2,1,5,3,2,4,3,5,4,4,5,3,5,1,2,5,1,5,5,5,2,5,3,3,2,2,2,4,3,4,3,1,3,4,2,1,4,2,2,5,1,3,2,1,4,1,5,2,3,1,2,2,3,2,3,1,1,3,3,5,3,4,4,5,2,1,3,3,5,3,5,2,4,1,4,3,2,3,1,4,2,1,1,2,4,3,5,2,2,1,3,5,2,1,1,3,2,4,4,4,3,1,2,1,4,2,2,2,5,3,2,3,2,2,4,1,5,1,2,3,1,2,2,4,5,2,2,2,1,1,5,4,1,1,5,1,4,1,2,4,4,4,5,1,5,3,1,5,5,5,1,1,3,3,3,5,4,2,3,3,1,1,5,5,4,3,5,4,3,1,4,3,3,5,2,2,2,2,1,4,5,1,5,1,5,1,5,5,4,2,4,4,2,2,5,1,1,1,5,3,1,5,4,1,1,4,4,1,2,1,2,2,2,4,3,4,2,4,2,3,4,3,5,2,4,3,4,5,2,2,2,2,1,5,3,5,1,3,3,4,1,3,3,5,5,5,3,4,3,2,4,5,3,2,2,2,2,3,4,5,3,1,2,4,4,1,4,4,5,2,2,1,2,2,2,1,1,2,5,1,3,3,3,2,4,4,2,3,3,4,2,3,2,5,4,4,1,2,4,3,5,5,2,5,3,4,4,4,3,2,1,4,1,4,4,5,3,2,2,3,3,1,2,5,5,4,1,2,2,1,5,5,4,1,4,3,3,1,3,4,2,4,1,3,3,2,5,2,4,3,5,4,3,5,1,3,2,1,5,4,1,3,5,2,2,1,1,3,2,2,1,3,3,2,1,3,5,5,4,1,1,1,2,4,1,4,4,1,3,5,2,1,3,4,2,1,2,3,4,4,1,1,4,5,5,3,5,5,3,5,5,5,1,2,5,1,3,1,2,5,5,1,4,1,2,1,1,1,5,2,1,1,3,3,1,5,3,2,1,4,3,4,1,5,3,5,5,1,5,1,4,5,5,2,3,2,4,4,5,3,2,3,1,5,5,2,1,4,3,5,5,4,5,5,2,5,4,2,2,2,3,5,4,5,4,2,4,3,3,1,2,3,3,1,4,2,4,4,4,5,5,5,5,1,5,5,2,5,1,4,2,3,1,3,1,5,3,4,1,4,3,5,1,3,4,4,3,5,5,4,4,4,2,1,3,2,1,4,3,3,4,2,1,2,2,1,5,5,2,2,4,3,5,5,3,1,1,2,1,2,5,4,5,3,4,2,4,2,5,5,3,4,5,4,3,3,4,1,5,3,1,3,1,2,3,5,1,4,2,4,1,3,4,4,5,1,5,2,2,3,2,1,4,3,1,4,3,1,1,1,3,5,1,4,3,1,5,4,2,3,5,1,3,5,4,1,5,1,4,5,2,2,1,4,3,4,3,3,5,2,3,4,1,4,3,4,4,2,5,4,1,1,1,4,4,4,5,2,4,2,4,3,2,1,2,3,1,2,3,1,3,3,5,3,2,1,5,4,1,5,1,1,5,3,2,1,3,3,4,5,3,5,3,2,1,3,4,5,1,3,5,3,5,1,4,5,5,3,2,2,4,1,1,3,5,5,3,4,2,5,5,3,3,4,2,1,5,3,3,4,2,2,3,2,5,3,1,1,3,4,3,3,4,1,4,3,2,5,2,3,5,4,4,3,5,1,3,2,5,4,5,1,2,5,2,3,4,1,1,3,5,1,1,3,1,2,1,2,4,1,2,5,3,2,4,1,1,5,1,2,2,2,4,2,3,2,5,5,4,1,2,3,3,4,1,2,1,4,3,1,2,3,3,5,1,5,2,3,4,1,1,4,4,1,4,5,3,2,2,2,5,1,1,5,5,1,3,1,1,2,4,2,3,4,2,5,1,5,5,5,4,2,4,3,2,3,1,4,1,2,3,2,3,5,3,1,3,1,5,3,2,2,2,5,4,1,1,1,1,3,3,2,2,4,1,3,1,3,3,1,4,2,1,1,5,1,2,4,4,4,5,2,5,1,2,5,5,3,3,3,2,4,5,1,4,5,4,2,4,3,2,3,4,3,2,4,3,2,5,5,3,1,3,3,2,5,4,5,2,2,5,5,4,3,5,3,5,1,5,5,4,1,3,3,5,1,1,5,1,1,2,5,3,1,1,5,4,4,1,2,5,3,5,5,1,4,3,5,4,1,5,4,3,4,5,2,2,4,5,1,4,2,5,4,3,2,2,1,2,2,3,5,3,4,3,5,3,2,3,3,3,2,3,2,4,5,4,1,5,1,1,5,2,2,2,4,5,3,3,2,5,1,4,2,1,5,2,5,4,2,5,4,2,4,3,4,4,3,3,2,2,5,2,1,1,4,5,4,3,1,3,1,3,4,5,1,3,5,1,5,1,5,4,3,5,1,1,3,1,3,4,5,5,2,2,4,5,5,5,2,3,1,5,3,5,5,4,2,5,4,4,5,5,2,3,5,1,4,5,3,3,1,4,3,2,3,2,2,5,1,1,5,4,3,2,5,5,3,2,4,5,1,1,2,4,4,5,4,4,1,1,2,2,4,5,1,1,3,4,5,4,1,3,3,5,1,5,4,1,1,5,2,1,5,1,3,4,5,2,1,3,1,3,1,3,5,3,1,4,1,3,2,3,5,2,5,4,4,3,5,3,1,5,4,4,5,1,2,2,2,3,2,4,3,4,2,3,5,4,4,3,3,1,5,2,3,3,3,5,2,4,1,3,4,1,2,4,5,4,4,1,5,5,2,3,4,5,3,3,5,2,4,5,1,2,2,2,5,1,4,2,1,1,4,5,3,4,5,5,2,1,5,3,5,3,3,4,3,5,3,3,1,3,3,2,4,2,5,5,3,4,2,5,3,5,2,4,5,5,2,1,4,1,1,4,5,1,5,1,4,5,2,4,1,2,5,3,3,2,4,5,4,4,2,3,2,1,1,4,5,2,1,5,5,3,1,5,1,3,2,3,2,5,4,5,4,3,2,1,3,4,3,1,1,3,5,5,2,5,1,2,2,2,3,3,5,3,3,2,1,3,1,4,3,3,5,5,3,2,2,3,4,1,3,5,4,2,3,2,2,4,4,5,1,5,4,4,5,5,2,3,3,1,4,2,4,1,2,1,4,5,1,4,5,2,5,4,5,3,4,5,5,4,1,4,2,3,5,2,4,5,4,4,2,5,4,2,5,3,3,5,5,2,2,3,1,2,1,5,4,3,4,5,3,4,5,2,2,1,4,3,4,5,5,4,5,3,5,4,4,2,4,3,3,1,3,1,2,4,5,3,1,5,5,4,4,4,4,1,2,3,3,3,1,1,1,3,1,5,2,5,3,5,4,5,1,3,4,3,5,4,4,4,4,4,1,1,5,4,5,1,5,3,2,5,3,4,3,3,3,2,5,3,5,2,4,5,5,4,3,3,5,3,3,2,2,1,1,1,3,5,4,5,2,5,3,3,1,5,2,1,1,2,1,2,3,2,5,3,3,2,3,1,2,4,1,5,3,4,1,5,1,5,4,3,4,5,3,5,2,1,3,3,2,3,5,1,2,5,3,1,1,2,4,5,2,1,5,5,3,5,1,5,3,3,3,1,5,1,4,5,4,1,1,2,1,2,4,3,1,5,3,2,2,2,3,5,2,4,4,1,3,1,5,3,3,3,3,4,4,3,3,5,4,5,2,4,5,4,2,2,1,1,1,2,4,5,4,3,1,3,1,5,3,2,3,5,5,3,2,5,4,3,1,5,3,5,5,5,3,3,4,4,5,2,1,1,3,3,1,5,4,5,4,2,2,5,1,5,4,2,4,2,1,1,5,2,3,4,4,5,4,5,5,3,4,5,1,2,3,5,1,2,3,2,2,2,4,3,1,3,1,3,3,3,2,3,5,3,4,3,3,1,4,1,3,5,4,1,3,3,3,1,3,4,2,4,1,3,5,2,4,5,1,3,1,2,2,5,4,5,3,4,1,2,5,4,2,4,5,4,2,1,5,2,2,3,5,5,2,1,2,5,5,1,2,4,5,5,4,5,5,5,2,4,2,3,3,5,1,3,2,4,5,3,4,1,1,4,2,1,5,5,1,3,4,4,3,5,3,4,4,3,4,2,4,4,1,5,3,5,4,5,1,1,1,5,2,4,1,5,5,4,3,3,1,3,2,5,4,2,1,2,5,2,4,3,5,5,4,3,4,1,3,5,4,5,2,3,1,2,4,5,5,3,2,4,5,3,5,4,5,1,3,3,3,3,2,4,4,5,2,1,3,2,4,5,2,2,1,2,5,1,4,1,1,3,2,5,1,4,3,4,1,1,5,5,3,3,2,1,5,5,1,4,1,3,3,3,4,2,3,3,1,2,4,3,4,1,3,1,3,1,3,1,4,2,3,5,2,5,2,3,5,5,1,1,2,3,2,4,2,2,5,5,2,3,5,3,2,2,5,3,1,3,3,4,1,4,5,3,2,5,4,3,2,2,5,5,3,1,4,2,1,3,1,1,5,4,1,4,5,5,1,5,1,2,5,1,3,4,2,5,4,1,2,3,4,4,2,1,2,4,4,3,1,2,2,2,1,3,4,1,5,5,3,5,3,3,2,2,4,4,2,1,1,4,4,1,2,2,4,1,1,2,4,2,1,4,3,5,2,3,2,1,1,1,1,1,5,5,1,2,4,5,4,2,2,3,5,2,1,2,4,5,5,3,4,1,1,3,5,1,3,5,2,1,1,5,3,5,5,3,3,3,3,5,5,2,3,5,1,5,2,5,5,4,1,3,3,4,5,1,4,1,3,2,2,2,3,1,3,4,4,5,2,1,3,4,1,1,3,3,4,4,2,3,4,3,2,1,5,4,3,1,2,2,3,3,3,1,4,4,2,2,2,2,3,1,4,5,3,4,1,2,2,3,3,2,1,5,4,4,5,4,5,1,5,3,1,4,1,1,5,4,2,1,4,1,3,3,4,4,4,1,2,2,4,3,1,3,4,4,5,1,3,4,3,1,4,1,1,3,1,2,5,1,2,5,2,5,5,2,2,1,2,5,3,1,3,3,1,2,3,3,3,5,3,2,2,4,3,1,2,3,1,5,3,4,1,1,4,2,5,4,3,1,5,3,3,3,2,2,1,2,4,2,2,3,4,1,3,3,3,1,5,3,4,3,3,5,4,3,2,3,5,5,4,3,5,3,5,1,1,2,1,4,1,2,1,5,1,5,3,2,1,1,3,5,4,1,1,3,4,2,1,5,3,3,5,5,2,1,4,1,4,3,1,5,3,5,3,3,4,3,4,4,5,5,5,5,4,1,4,5,4,4,1,5,5,5,1,3,5,3,2,5,3,3,5,4,3,3,2,4,5,1,3,4,2,5,5,3,4,2,3,1,1,5,4,1,2,2,3,5,1,1,5,5,5,4,1,2,4,5,4,3,3,5,4,1,1,1,5,3,5,4,3,1,5,1,5,1,3,5,2,5,5,1,4,3,2,3,2,5,1,1,1,3,1,1,3,3,4,1,5,2,4,5,3,5,1,5,5,2,5,3,1,2,5,3,5,1,1,4,3,1,1,5,5,1,5,4,1,3,4,5,4,1,5,1,3,4,2,4,2,3,1,1,5,4,5,5,3,3,1,3,2,2,3,2,1,2,5,2,4,1,3,5,1,3,2,2,4,2,2,5,3,3,2,5,1,2,5,1,4,4,3,4,4,1,5,1,1,1,3,5,4,1,3,4,3,2,3,3,1,2,2,5,3,3,1,4,5,5,5,4,2,1,5,5,3,3,4,1,1,4,3,3,3,2,5,2,3,2,4,2,5,5,5,1,1,5,4,5,5,4,5,3,4,5,4,2,1,4,5,3,4,2,1,2,2,2,2,3,3,3,5,4,2,1,2,5,3,5,4,2,5,3,4,4,3,2,1,1,1,4,2,5,2,3,3,4,2,5,5,5,2,2,2,3,1,4,5,3,1,4,4,2,3,1,4,3,2,5,3,4,1,3,1,1,3,5,2,1,4,3,2,4,2,3,2,1,3,2,4,4,5,4,2,2,5,5,1,4,2,5,2,5,2,2,2,5,4,3,5,5,5,2,3,4,5,1,4,2,1,1,5,2,3,2,1,1,3,3,3,1,5,5,2,4,4,2,5,4,4,4,4,2,4,3,4,5,2,4,4,4,5,4,2,5,5,2,5,3,2,5,3,5,1,2,4,4,4,4,4,4,1,3,5,3,2,2,5,1,4,1,2,1,1,4,5,3,5,2,4,4,2,1,4,3,4,2,5,5,3,5,1,4,1,2,1,4,3,4,2,5,1,1,2,1,5,5,1,2,3,4,5,4,1,2,4,4,5,3,3,3,5,2,3,4,5,1,5,2,5,3,3,2,2,3,3,4,3,2,1,4,2,2,1,5,4,1,5,4,2,3,5,1,1,4,4,3,4,1,1,3,4,4,4,5,2,3,4,4,5,5,3,2,1,4,3,3,1,1,3,5,1,4,3,4,3,4,4,2,1,3,2,1,3,1,2,5,1,2,1,4,1,4,4,4,1,2,1,3,4,1,5,4,5,3,3,4,5,1,1,2,3,2,2,1,1,2,4,3,3,1,2,3,1,1,3,5,4,3,4,2,1,4,2,4,1,4,1,3,4,1,4,5,5,2,2,5,3,5,2,2,3,3,4,1,5,2,1,5,3,4,2,4,3,4,1,2,5,1,1,5,1,2,5,1,3,3,4,3,5,4,1,4,2,5,4,4,3,3,1,4,5,5,5,4,3,4,1,5,5,2,3,4,3,3,2,3,2,4,1,1,4,1,2,3,2,4,2,2,2,4,2,1,4,2,2,4,1,3,1,4,1,2,3,5,3,5,5,1,2,1,2,4,5,5,5,2,3,3,4,3,2,1,5,1,3,4,2,5,1,3,5,2,1,1,4,2,1,2,5,2,1,4,1,3,4,4,4,1,1,2,5,1,4,1,1,4,2,4,4,4,1,3,5,4,5,5,2,4,3,1,2,5,2,1,2,3,2,5,1,4,5,3,5,2,1,1,5,2,5,5,5,2,4,3,3,4,2,5,4,5,5,4,3,3,1,5,5,5,2,1,3,3,1,3,3,1,4,1,2,1,4,1,1,4,4,5,4,1,2,5,1,2,4,2,1,1,3,5,1,1,3,2,5,2,2,4,3,3,4,3,4,5,3,3,1,3,4,1,5,4,5,1,1,3,5,4,3,4,3,5,3,2,5,4,5,4,2,1,2,2,3,3,1,2,3,5,3,2,1,5,3,5,1,5,1,4,3,5,4,5,2,3,3,2,1,4,5,2,1,4,5,4,5,1,4,2,4,1,5,4,3,4,1,5,2,2,3,3,4,4,2,5,3,1,3,3,3,4,3,1,5,3,4,1,3,2,5,2,3,5,2,3,5,1,4,3,5,3,2,1,1,4,1,2,3,3,3,2,2,2,1,1,3,5,4,1,4,4,4,1,1,5,4,4,3,4,1,2,5,3,5,3,1,4,5,3,1,2,2,3,3,4,4,2,5,1,4,3,1,1,5,5,2,1,3,1,3,2,4,3,4,1,1,5,2,1,1,4,2,1,1,4,4,1,3,1,1,4,2,3,2,5,3,3,3,3,2,4,2,4,2,4,5,2,1,1,3,4,4,3,3,2,2,4,5,3,3,4,1,2,4,3,5,2,1,1,5,3,1,5,5,3,2,5,1,5,1,4,2,5,3,3,4,2,3,2,5,5,1,3,1,4,1,1,3,3,5,3,4,3,4,1,4,4,2,3,2,1,2,2,4,4,5,5,3,1,3,1,4,5,4,3,4,3,1,2,4,1,3,5,4,4,1,4,2,5,1,5,3,3,3,5,5,5,1,5,1,3,4,1,2,2,2,5,5,5,5,2,3,4,4,3,4,5,5,4,4,3,2,1,1,2,2,1,4,4,3,2,4,3,4,4,5,1,1,3,4,1,3,5,5,3,4,1,3,2,3,2,2,4,4,3,4,4,1,1,4,2,3,5,4,1,2,5,3,5,3,4,3,1,3,5,5,5,1,4,2,4,2,3,2,3,3,3,4,5,1,4,1,5,3,4,4,1,1,5,2,3,2,2,5,3,4,5,5,1,2,1,5,2,1,5,1,5,2,4,2,1,5,3,2,3,5,5,3,3,3,1,1,5,2,4,2,2,4,4,2,4,2,2,2,1,3,1,4,1,5,3,3,1,2,2,5,5,4,5,1,4,5,1,1,1,2,3,4,1,5,4,4,1,3,2,3,3,1,3,3,4,3,5,5,3,2,4,3,4,5,5,2,2,4,4,2,4,3,2,1,5,1,2,2,2,2,1,1,2,3,4,4,1,3,1,2,4,4,5,5,3,3,2,2,2,5,2,4,2,3,4,3,5,2,4,5,4,3,2,3,2,2,3,3,3,2,2,5,4,4,4,5,3,2,2,2,3,2,2,1,3,4,2,5,3,5,5,1,5,1,3,2,1,4,5,5,5,5,1,2,1,5,2,1,5,4,3,2,3,3,2,2,2,4,1,5,4,3,5,5,5,1,2,4,5,1,1,2,2,3,2,5,4,2,3,3,5,3,4,1,2,5,4,1,4,3,3,2,2,1,2,1,1,5,5,4,3,2,3,1,4,2,3,4,3,3,4,2,1,3,5,2,2,5,3,3,4,5,4,2,3,5,1,3,2,3,4,3,2,1,5,3,1,2,1,4,5,3,4,5,4,2,2,4,4,5,4,2,5,4,2,2,2,5,3,2,4,4,3,4,1,2,3,2,4,4,4,5,2,1,3,4,4,1,1,5,4,1,3,3,1,2,3,1,2,4,5,1,3,5,1,5,2,4,2,5,2,1,4,1,3,2,5,2,4,2,4,1,4,3,4,4,3,4,4,1,3,4,1,2,1,4,5,5,1,5,1,5,3,4,1,3,4,2,2,3,1,2,4,4,4,1,4,4,2,1,4,4,1,1,1,3,2,5,4,4,2,1,1,5,4,5,5,4,5,1,5,4,5,5,4,3,5,4,1,1,1,4,2,2,3,5,3,1,4,1,1,1,4,3,5,1,3,2,1,2,4,2,4,5,2,5,5,3,1,4,3,5,5,1,3,1,5,1,2,2,4,2,3,2,5,5,4,4,4,1,1,2,2,1,4,3,4,1,2,5,5,5,2,5,3,2,5,2,4,1,4,4,2,4,5,5,1,5,2,2,3,4,3,2,5,2,1,4,4,4,5,4,5,3,1,4,1,3,1,1,5,2,5,4,4,3,3,1,2,2,4,4,3,4,1,1,2,3,2,5,4,1,2,1,2,1,1,2,4,4,2,1,1,2,5,5,5,2,3,2,2,1,4,5,2,3,3,4,3,3,2,2,2,2,2,1,4,5,5,3,5,4,2,4,3,3,4,1,1,4,3,5,4,4,4,5,1,5,5,2,5,5,3,2,5,5,2,4,4,1,4,4,4,2,4,1,2,2,1,3,1,3,4,5,3,2,2,3,4,4,4,2,3,3,1,1,3,3,5,1,1,3,2,1,5,5,4,1,5,2,4,1,5,5,1,1,2,2,1,5,3,4,3,2,1,1,1,1,2,4,1,2,2,2,1,2,5,3,3,4,2,2,5,1,3,5,4,1,4,3,4,4,5,4,2,2,2,2,2,1,5,2,5,1,3,3,3,3,1,1,1,2,5,2,5,3,3,1,4,2,4,2,2,4,1,1,3,4,4,1,2,2,5,2,5,2,5,4,3,1,1,2,1,2,2,4,4,2,3,5,1,3,5,1,1,3,2,2,1,2,4,5,2,1,2,4,5,3,4,1,4,1,5,5,3,2,4,2,4,5,1,5,2,5,5,5,5,2,4,4,3,5,5,2,3,1,4,2,2,3,3,3,5,1,5,1,5,2,3,2,5,1,3,3,1,4,4,5,2,5,1,3,3,4,5,4,2,2,5,5,5,2,2,2,1,2,1,1,1,3,2,3,1,3,1,5,3,1,1,5,2,2,4,5,5,1,1,5,3,5,2,3,2,3,3,1,4,1,4,1,3,5,3,5,5,2,5,2,3,1,3,4,1,4,5,5,1,4,3,2,4,1,4,5,2,1,3,2,5,5,1,2,4,4,2,3,1,1,2,4,1,3,1,4,5,4,2,5,1,5,2,1,4,2,3,4,5,3,2,3,2,4,4,4,1,5,1,2,4,2,2,5,4,3,2,3,5,4,2,3,5,3,5,2,2,1,3,3,4,3,5,3,1,5,4,1,1,1,5,3,5,5,2,1,5,5,5,2,1,1,1,5,5,4,1,5,3,4,3,1,1,1,5,5,4,2,4,4,4,1,2,4,4,2,3,5,3,2,2,5,3,5,5,3,1,2,2,2,3,5,3,5,2,5,3,2,5,2,1,2,1,5,1,3,2,3,3,1,1,2,1,3,3,3,3,5,5,4,3,2,5,3,2,2,3,1,5,1,5,3,5,5,4,2,4,4,4,2,1,5,2,1,5,4,4,2,2,3,1,5,1,2,1,2,4,3,4,3,4,4,5,4,1,2,5,2,4,3,4,1,4,5,4,1,3,5,3,5,5,4,3,1,1,3,4,5,1,2,3,4,5,2,1,4,3,4,3,3,2,5,2,3,5,1,4,3,3,4,2,2,3,5,2,3,5,4,3,1,1,2,5,5,5,4,2,5,5,5,1,4,1,3,5,2,3,2,4,2,3,4,1,4,5,5,2,1,5,4,2,5,4,4,2,4,5,1,3,1,5,2,4,5,1,3,5,3,1,1,5,5,4,3,4,5,5,2,4,4,2,2,5,5,5,5,5,5,4,3,4,1,3,4,3,1,1,5,5,3,4,3,3,2,4,2,4,2,4,5,4,5,1,1,5,3,1,5,3,1,5,4,2,4,3,4,5,3,5,4,4,2,2,3,4,2,3,3,5,5,3,4,4,3,3,3,3,5,4,3,3,5,3,5,4,3,2,5,1,4,2,4,2,1,2,5,2,5,1,5,2,3,3,5,5,1,4,2,3,1,1,3,2,1,1,2,5,3,3,5,1,5,1,5,5,1,2,3,2,4,4,1,5,2,3,4,1,1,1,5,4,4,2,4,2,3,4,2,4,2,1,5,5,5,5,4,5,5,1,3,5,1,3,5,1,3,5,2,3,5,3,3,3,3,1,2,2,4,2,3,5,4,2,5,2,3,5,1,1,1,1,3,3,4,5,4,2,2,4,4,3,5,3,1,2,5,1,5,5,5,3,3,2,5,4,1,1,2,5,5,4,1,4,3,5,3,4,3,1,5,4,5,1,1,1,4,5,2,5,2,3,4,3,1,3,3,3,1,2,4,3,1,2,4,5,4,5,2,4,4,3,1,1,2,5,1,1,1,4,2,4,1,2,1,4,1,5,5,3,3,4,1,3,2,5,1,1,2,3,1,4,4,3,1,1,1,4,2,5,1,2,2,5,4,3,3,3,1,1,2,1,5,5,1,3,1,1,1,2,4,4,4,4,2,2,1,2,3,2,5,3,1,4,3,4,3,4,3,2,5,3,4,2,3,3,4,2,2,2,4,1,5,1,1,1,1,3,2,5,2,4,5,1,1,3,4,2,5,4,4,5,4,2,5,2,3,3,3,4,1,2,5,3,5,2,5,1,3,5,1,2,5,1,3,1,3,5,2,3,5,4,2,4,1,4,5,3,3,3,5,5,3,5,1,3,4,4,3,1,2,3,1,2,5,3,2,1,1,3,2,3,3,5,1,1,4,4,1,3,4,5,4,2,3,1,3,4,4,5,1,5,1,3,1,4,2,1,5,1,4,1,3,2,3,1,2,1,1,4,1,3,3,4,1,3,5,5,3,3,4,1,5,4,2,5,2,1,2,3,4,1,5,1,2,3,1,5,2,2,1,3,1,1,3,3,1,4,5,3,2,2,1,2,4,3,5,1,4,2,3,5,4,2,3,1,4,2,4,2,1,1,1,4,1,4,4,1,3,4,1,1,4,1,1,3,1,5,4,2,3,5,2,1,2,2,2,2,2,5,2,1,1,4,2,5,2,3,3,3,4,5,2,1,1,1,5,1,3,1,2,1,1,5,3,2,5,2,4,4,1,1,2,3,3,3,3,4,4,4,4,2,2,2,3,4,2,3,1,2,2,4,5,5,1,3,5,2,5,1,3,4,2,3,3,1,2,5,5,3,5,4,2,1,1,3,4,3,2,3,4,3,2,4,2,1,2,2,1,2,3,2,2,2,2,4,2,2,4,5,4,5,3,2,4,4,4,1,2,3,2,1,5,3,5,2,4,2,5,1,3,4,4,2,5,2,4,4,4,5,4,2,3,2,5,1,1,2,2,4,2,5,1,2,4,5,5,1,2,1,1,5,3,2,2,5,2,1,1,5,3,5,2,2,1,4,2,2,2,1,4,4,5,5,3,2,4,5,3,3,1,3,1,4,4,1,2,2,2,3,3,2,4,1,3,1,1,4,1,1,1,4,4,2,2,4,4,5,5,1,1,1,4,1,4,3,4,1,4,2,5,5,4,5,3,1,5,1,4,5,3,4,5,3,1,3,2,3,1,5,3,5,4,4,5,4,1,1,2,4,3,5,4,5,3,1,2,1,4,1,1,2,3,4,4,4,2,2,2,4,3,1,2,3,1,2,1,4,2,1,4,2,1,4,3,4,2,4,3,2,4,3,4,2,5,2,3,5,4,3,4,4,4,2,4,2,5,5,4,3,2,1,3,5,5,4,4,3,2,3,3,3,5,5,4,5,1,1,1,4,2,5,5,2,2,4,1,3,2,1,4,3,1,4,4,2,4,1,1,4,2,1,3,1,3,1,4,2,3,5,1,4,3,2,2,3,2,3,3,2,2,4,2,5,2,4,2,3,3,1,1,5,2,4,2,3,4,1,4,5,1,5,3,3,2,2,4,1,3,3,3,5,3,1,3,5,3,5,2,2,2,1,3,5,4,4,1,5,5,2,4,4,4,1,2,3,5,5,4,3,1,1,2,2,2,5,5,3,2,2,3,3,5,3,4,1,4,5,3,4,4,1,4,5,3,5,1,1,5,1,1,2,1,2,5,5,5,4,3,2,3,1,4,4,5,1,2,5,3,3,2,3,2,1,3,1,5,3,3,2,1,5,4,2,2,2,3,1,2,4,2,5,4,5,2,2,2,5,1,5,4,4,4,1,2,1,5,3,3,3,1,3,3,4,2,5,1,4,1,4,4,4,5,1,2,4,1,1,4,1,4,1,1,1,2,4,5,3,2,3,3,3,5,2,1,5,1,1,5,1,3,4,4,3,2,4,2,3,1,2,1,4,4,1,1,3,4,3,5,4,4,5,5,2,5,5,2,2,1,3,2,5,1,2,4,2,2,3,4,5,4,2,5,2,3,3,3,5,3,4,2,3,3,5,1,3,2,3,4,3,3,1,4,4,1,4,2,3,3,5,2,3,2,4,5,3,4,5,2,5,3,2,4,2,2,2,2,4,5,3,3,4,2,5,5,3,1,4,1,1,3,4,4,3,3,5,2,3,3,1,3,4,2,2,1,5,3,1,1,5,3,4,5,4,3,4,2,4,4,4,2,4,5,4,3,1,1,2,4,1,1,4,3,4,5,1,4,5,2,2,2,4,3,4,3,2,1,1,4,1,4,4,2,1,2,3,1,5,2,3,2,5,2,1,2,4,5,5,1,1,3,5,4,1,4,2,5,2,2,1,1,1,2,1,2,5,4,2,5,5,3,4,2,1,3,5,5,5,2,2,5,1,4,2,4,1,5,1,5,3,4,3,2,4,4,5,5,5,5,5,1,3,2,4,5,1,1,2,1,5,2,2,1,3,3,5,5,1,5,3,1,1,3,2,3,2,3,2,2,3,1,4,2,5,4,5,2,5,2,1,1,2,5,1,3,3,5,2,2,2,3,4,1,1,1,5,3,2,5,5,5,1,3,1,2,1,1,5,2,3,2,3,3,3,4,3,3,2,3,2,2,4,1,1,4,4,4,4,2,1,1,1,5,3,4,4,1,4,4,1,3,5,1,1,3,5,2,3,5,3,1,4,2,1,3,5,1,4,5,4,5,4,3,4,4,1,4,3,2,5,5,2,4,1,1,2,1,3,1,1,3,4,2,3,3,2,4,5,1,2,5,5,5,2,2,1,5,3,1,5,4,4,1,4,5,3,2,5,4,3,4,2,4,5,1,4,1,2,2,2,5,1,2,4,1,4,5,1,2,2,3,2,4,2,5,4,4,1,1,2,5,2,2,5,3,1,5,3,2,1,3,4,5,4,5,5,1,2,5,4,2,1,2,5,2,4,4,2,3,4,5,4,3,3,4,2,3,1,3,5,3,5,2,1,3,1,5,4,4,3,2,5,1,5,1,4,1,2,3,1,4,2,3,4,3,1,5,3,3,5,4,5,5,2,5,1,1,2,5,1,1,3,4,2,4,5,5,4,1,5,5,3,1,5,1,5,3,3,3,5,3,2,5,4,4,3,2,2,1,2,5,2,3,3,2,4,3,4,2,5,4,1,3,2,5,5,5,2,2,1,4,5,2,5,1,5,3,5,4,5,3,3,5,3,4,1,1,5,2,3,2,4,3,1,4,5,3,2,3,1,4,3,5,5,5,1,2,3,4,1,3,3,3,3,4,2,5,4,1,4,1,2,2,2,3,5,1,2,1,5,5,2,3,3,4,2,2,5,2,4,3,4,4,3,2,3,4,2,4,4,1,4,4,1,5,3,2,3,2,1,3,1,4,3,3,3,4,2,5,1,3,3,1,3,5,2,5,2,5,2,4,2,2,2,2,3,3,1,1,3,5,5,4,4,3,1,1,4,4,2,4,5,4,2,4,2,2,3,4,3,4,1,4,4,5,4,4,5,3,2,2,5,3,4,2,3,3,4,5,3,2,1,4,1,3,3,5,5,2,5,3,4,5,1,4,5,4,1,4,2,5,5,3,1,5,4,5,4,1,1,1,2,2,4,2,2,4,5,5,1,4,5,1,2,5,3,2,5,4,2,5,1,1,4,2,5,1,1,5,1,5,1,2,3,2,1,5,1,4,1,5,1,1,3,3,1,3,5,1,3,1,1,1,4,2,1,3,4,4,2,1,3,3,4,1,2,3,5,4,4,3,3,5,5,1,2,3,3,4,5,5,3,1,5,2,2,2,1,4,3,4,1,5,1,3,5,5,1,5,1,5,2,5,2,3,4,2,5,1,1,3,4,4,3,2,1,1,1,1,2,2,4,4,2,2,3,2,4,4,1,4,4,5,3,3,1,4,5,2,4,1,5,2,3,2,1,3,3,5,1,1,2,2,3,1,2,3,1,2,4,3,1,4,1,4,2,2,4,2,1,5,2,5,2,1,4,2,5,5,3,4,1,2,5,4,2,4,3,1,4,3,4,5,1,5,3,4,3,2,4,1,5,1,4,5,3,2,1,2,1,4,2,3,2,5,2,1,1,3,2,2,3,2,3,2,1,2,4,1,4,1,2,3,4,3,5,4,3,4,3,3,2,5,4,4,5,5,3,4,1,3,2,1,1,2,1,1,1,5,1,2,1,4,5,3,3,5,1,3,2,3,2,3,3,2,1,3,3,5,1,5,5,1,1,5,4,4,3,5,5,1,1,2,1,5,5,2,5,1,2,1,4,1,5,4,4,5,4,3,3,3,4,3,1,1,1,2,5,1,1,4,3,4,4,4,2,2,4,2,1,1,1,3,2,2,3,3,5,5,3,5,3,5,1,5,1,2,2,1,3,3,2,3,4,3,3,5,1,3,5,5,3,3,2,1,1,5,1,2,1,4,3,3,5,5,4,3,5,2,3,4,4,3,5,1,1,4,2,3,3,2,4,1,5,3,5,4,5,4,2,2,3,5,1,3,4,5,4,2,2,2,2,4,2,4,5,3,1,2,2,4,1,3,1,3,2,5,4,2,5,4,5,1,1,3,3,1,4,2,2,5,4,4,3,3,2,3,5,5,2,2,5,2,3,3,4,2,5,3,4,4,3,4,4,4,2,2,5,5,2,5,4,1,4,3,5,4,5,3,3,2,2,3,1,4,4,2,2,4,3,5,5,1,2,2,1,1,1,5,3,3,5,3,2,3,4,2,5,4,1,2,1,2,2,1,2,5,5,1,2,2,5,1,2,4,3,2,5,1,1,5,3,2,2,3,5,1,2,4,4,1,3,5,2,1,3,2,3,1,1,5,4,1,5,3,4,4,2,1,4,2,5,5,2,2,1,1,4,3,4,1,2,1,2,2,4,4,4,3,4,2,2,1,1,3,2,3,3,2,1,1,5,4,2,4,5,3,3,3,4,3,4,1,2,3,1,2,4,4,4,5,2,5,1,3,4,5,4,1,3,5,1,5,4,4,4,4,2,4,3,5,4,1,2,1,4,4,3,5,2,3,2,5,1,5,3,3,4,4,1,4,1,1,4,1,5,3,1,1,5,4,4,5,3,5,1,4,1,1,1,5,5,1,3,2,5,3,2,3,2,1,3,2,5,5,2,1,1,4,3,4,2,5,2,1,1,5,4,2,2,5,5,2,3,3,4,4,1,5,4,2,3,2,1,3,3,5,4,4,3,5,4,4,2,2,5,4,4,4,4,4,3,3,2,1,5,2,1,4,3,4,4,5,5,1,5,5,2,1,4,2,2,1,1,4,2,4,4,4,1,3,3,5,4,1,4,3,2,5,4,4,1,3,3,2,5,1,1,5,5,2,5,5,1,5,2,5,2,5,3,5,1,1,4,1,1,5,4,1,2,2,2,2,2,2,1,4,2,5,4,3,2,5,5,2,3,5,1,2,1,4,4,4,4,1,2,3,4,1,3,2,2,3,5,4,4,1,2,4,1,3,1,3,5,2,4,1,2,4,3,4,5,5,5,1,1,3,2,2,5,3,2,3,3,4,1,3,5,3,2,3,5,4,2,4,1,2,3,1,1,1,2,3,5,2,4,4,4,1,3,5,2,1,4,1,2,1,4,4,3,2,2,1,4,3,2,3,1,3,5,1,1,2,2,1,2,5,4,4,2,2,4,3,1,4,4,4,4,5,3,2,1,3,1,3,4,5,4,3,4,2,5,1,3,5,5,1,4,4,1,5,5,2,4,2,2,4,5,3,2,5,4,4,3,3,1,2,4,2,3,5,1,2,1,1,5,5,5,2,2,5,2,4,2,2,1,5,3,4,5,1,1,4,4,4,4,5,5,1,1,4,5,4,5,1,5,2,1,1,3,2,3,3,5,3,3,4,2,1,1,1,2,4,3,4,5,5,2,2,3,2,4,1,4,1,4,5,2,3,4,4,5,1,4,4,4,2,1,4,3,5,1,3,4,1,5,1,1,5,1,5,2,3,5,1,3,2,4,3,2,2,2,1,4,4,2,5,2,5,2,1,2,1,1,4,4,3,1,3,5,2,2,3,1,3,4,5,5,4,5,5,1,1,1,3,3,3,5,3,3,3,4,3,3,2,5,4,5,4,5,2,4,3,2,5,2,5,3,3,4,4,3,2,3,5,1,3,5,2,3,3,5,5,1,3,4,3,3,1,5,3,4,2,4,3,3,2,2,3,2,2,4,1,1,5,3,3,2,5,3,4,4,3,1,5,3,4,3,1,1,5,1,4,1,3,4,4,3,3,1,1,2,5,4,2,2,2,4,2,5,3,4,1,1,2,4,3,1,4,4,1,2,3,5,3,2,4,4,4,1,5,5,4,2,2,1,3,1,1,3,3,2,5,3,4,3,1,3,4,1,5,2,5,4,3,5,2,4,5,2,3,3,3,2,3,5,5,3,5,5,4,5,3,3,1,1,5,5,3,3,2,5,3,4,4,1,2,3,1,2,2,5,1,2,4,3,5,5,5,3,4,4,2,2,2,3,2,2,2,1,2,2,3,3,4,1,4,1,2,5,2,3,1,1,5,4,3,1,2,2,2,2,1,4,1,4,5,3,2,4,3,5,4,4,4,4,4,2,4,1,1,4,2,2,1,1,5,5,4,3,4,4,5,1,5,5,4,2,4,3,1,1,3,2,3,5,3,2,1,3,3,3,3,1,1,2,5,1,4,3,5,5,2,2,4,1,2,4,3,5,3,2,3,2,3,1,4,4,5,3,5,2,2,2,4,2,5,2,1,2,1,5,5,2,2,2,3,1,5,2,2,1,5,1,1,5,1,5,2,1,4,1,4,5,4,1,4,2,2,2,5,5,4,5,3,4,5,2,1,1,5,1,1,2,2,3,4,2,5,4,1,4,1,2,5,4,3,4,2,4,5,4,3,1,4,4,5,5,1,5,4,3,3,3,1,1,1,1,4,2,5,3,2,1,4,4,5,1,1,3,3,5,3,2,5,5,2,2,2,3,3,4,3,5,5,1,5,2,3,4,1,3,3,3,2,1,1,1,4,4,4,5,5,2,4,5,4,3,1,1,5,5,2,3,2,4,1,2,3,4,5,2,5,5,3,2,4,3,1,2,3,1,5,1,1,5,3,1,3,2,5,5,4,1,1,1,4,5,2,2,5,2,1,4,2,5,4,5,5,1,2,3,3,3,2,3,1,5,2,2,2,1,4,1,4,4,5,2,4,1,1,1,5,2,5,1,1,4,2,1,3,2,4,3,1,5,5,2,2,1,3,3,2,1,2,3,3,4,4,1,2,2,5,1,4,3,1,4,3,1,2,2,1,4,5,5,3,5,3,4,3,2,4,4,4,5,2,5,3,3,2,3,1,2,1,1,5,4,4,3,3,4,5,2,2,4,2,2,4,2,3,1,3,3,3,4,2,3,5,3,1,3,4,4,2,4,2,2,5,1,5,1,4,4,4,3,3,3,3,2,1,1,3,1,4,2,5,2,2,2,3,1,5,1,5,2,4,4,2,3,3,3,4,2,4,5,4,1,5,4,3,5,2,2,4,2,5,1,1,4,5,1,3,4,2,4,5,1,5,1,3,2,1,3,5,4,3,5,2,3,4,2,4,4,4,1,3,1,4,3,3,1,3,4,2,5,2,4,2,3,5,5,3,4,2,2,4,3,5,3,3,1,2,2,3,3,3,4,3,5,2,4,5,3,1,4,4,3,5,1,2,3,5,5,1,5,3,2,2,5,3,1,3,3,5,1,2,1,1,2,2,5,4,3,4,1,5,1,1,1,4,4,4,2,5,1,1,2,5,3,3,2,5,5,2,3,4,5,2,2,5,4,1,2,2,2,5,4,2,1,3,4,3,1,4,4,1,2,3,1,3,1,3,2,4,5,3,5,5,5,4,4,5,4,1,4,3,1,4,4,2,4,3,2,2,3,2,5,3,5,1,1,4,5,3,5,5,2,2,3,2,1,2,5,5,2,1,4,4,4,3,3,5,1,3,4,5,4,1,4,3,2,3,1,2,5,5,1,5,5,5,2,1,2,3,4,5,2,1,5,3,1,5,3,1,4,3,2,2,3,4,1,5,2,1,4,5,3,2,4,4,4,3,2,3,1,2,5,2,4,3,2,5,5,2,2,4,5,3,1,1,2,2,5,5,2,2,1,1,4,5,1,4,5,2,4,5,5,2,2,2,5,1,5,1,2,1,4,5,1,1,2,3,2,2,1,3,4,1,3,1,4,1,3,3,5,3,5,4,4,5,5,3,1,1,4,1,1,4,5,3,3,1,4,5,4,3,3,5,4,2,2,3,4,1,5,3,2,4,5,1,4,1,5,5,2,3,3,5,3,1,3,3,5,4,4,4,2,4,2,3,5,3,4,2,5,4,5,5,4,4,2,2,4,2,5,5,5,5,2,3,1,1,4,2,5,5,2,2,2,5,2,4,1,1,1,4,5,4,3,5,4,2,4,2,4,5,1,3,3,5,1,2,3,1,5,4,4,5,4,3,3,1,4,5,3,4,2,3,3,2,4,5,4,3,1,3,1,3,3,5,1,4,5,5,1,4,1,1,1,1,1,5,2,2,4,4,2,2,3,3,4,2,1,3,5,3,5,4,2,1,5,5,5,4,3,5,3,4,5,2,3,1,4,2,1,1,4,3,5,1,5,3,5,1,5,5,2,2,2,1,4,5,5,5,1,3,1,2,5,3,2,5,3,5,3,5,5,4,5,2,4,2,1,4,5,2,5,5,5,1,4,3,1,3,1,2,5,2,1,4,4,2,1,4,4,3,4,5,2,3,5,5,4,5,4,1,4,3,3,2,4,2,3,3,4,2,1,2,4,5,5,5,1,1,1,1,2,5,5,3,5,4,2,1,2,4,1,4,5,2,1,2,3,1,5,1,4,5,5,5,4,5,3,4,5,3,2,1,4,1,4,5,1,1,5,2,2,1,5,2,2,2,5,3,3,4,5,3,2,4,5,1,5,3,3,3,1,2,1,4,3,3,4,4,4,5,2,2,3,1,5,4,4,1,5,3,2,1,2,1,4,3,4,3,4,3,5,3,4,4,1,3,2,2,5,5,3,2,1,4,2,3,3,4,5,4,2,4,3,3,4,2,4,3,3,4,4,1,3,2,4,2,5,3,2,2,4,3,3,5,3,5,4,5,5,3,2,3,4,2,4,1,1,4,4,3,3,2,3,4,3,2,3,4,4,3,4,1,2,4,5,3,2,4,4,2,2,5,5,3,2,2,2,1,1,5,4,4,2,2,3,5,4,4,2,4,4,4,1,5,3,1,2,3,1,5,3,5,4,5,1,1,2,1,2,1,3,3,2,3,5,4,3,1,5,4,2,1,4,1,2,5,4,2,4,4,2,4,1,3,3,1,5,5,1,4,5,3,5,5,3,2,3,3,2,5,1,4,3,2,2,4,1,2,2,2,3,2,1,2,1,1,4,5,2,1,5,5,3,2,3,2,3,4,4,5,1,3,1,2,4,4,5,4,2,4,4,4,3,4,5,1,1,2,3,3,1,5,3,4,4,5,1,3,5,5,2,3,4,4,5,1,4,5,4,2,1,5,5,3,4,1,4,4,2,2,1,1,3,2,4,3,2,5,2,2,4,2,3,2,4,2,2,5,5,2,5,3,4,5,1,5,2,3,4,4,2,4,4,4,4,2,3,2,1,5,5,4,3,3,1,5,4,2,5,3,4,4,4,4,1,1,2,4,2,4,5,1,2,5,2,1,4,2,2,2,5,2,4,3,1,2,5,2,5,1,3,4,5,2,3,3,1,1,5,1,1,3,1,3,3,3,1,5,2,1,5,4,5,1,5,5,5,4,5,3,2,4,5,4,3,1,2,4,4,4,1,4,1,1,1,3,1,1,1,2,3,1,4,5,4,2,5,2,5,5,5,2,4,1,2,1,4,4,1,3,1,5,3,4,1,3,2,5,2,4,4,2,5,5,4,5,3,1,2,5,4,4,2,4,1,2,3,5,4,3,3,5,3,1,4,2,1,3,5,1,2,4,1,5,3,2,4,5,5,4,5,3,3,3,4,4,4,2,5,4,5,1,1,1,2,3,4,1,5,4,2,3,1,4,3,2,3,1,2,4,2,4,2,3,1,5,2,1,3,3,5,2,3,3,2,2,4,3,3,5,4,1,1,3,2,4,1,3,4,4,1,5,1,3,1,1,4,2,4,4,3,5,4,4,4,1,2,2,1,5,2,2,2,2,3,2,4,2,1,4,4,5,2,4,3,1,2,1,5,3,3,2,2,1,3,3,3,4,3,1,3,1,1,3,4,3,3,2,4,5,5,2,3,4,1,1,3,3,2,3,4,1,3,5,4,5,2,5,2,1,4,4,1,3,3,2,5,4,2,5,1,3,2,5,3,4,2,2,4,4,4,3,2,2,5,1,4,3,3,2,5,2,5,3,2,5,4,3,2,2,4,4,4,3,1,5,2,4,1,2,4,1,5,4,4,5,2,3,3,2,3,3,3,5,1,3,2,2,1,2,2,3,3,3,4,3,4,4,1,5,3,1,3,4,3,4,1,5,1,3,3,1,1,4,4,5,3,5,4,5,2,5,1,1,5,1,4,2,4,5,3,2,1,2,2,5,3,2,5,5,1,4,4,5,2,1,2,1,2,5,4,4,2,4,4,3,5,4,3,2,5,4,4,3,3,3,5,3,1,1,2,3,4,1,1,5,3,5,2,5,4,5,2,5,2,2,5,3,1,2,4,3,1,2,2,3,2,3,3,2,3,4,2,4,5,5,4,4,3,5,3,1,3,2,3,5,2,4,3,5,1,4,1,5,3,3,5,5,5,2,2,5,3,5,1,1,5,1,2,2,1,2,3,4,5,2,1,2,2,4,3,4,4,5,1,3,2,5,4,3,2,4,3,1,5,1,1,1,1,5,2,2,1,5,4,5,3,1,5,1,1,3,2,1,4,3,4,5,4,3,5,4,5,2,5,5,1,3,3,4,1,2,2,2,5,3,2,4,5,5,3,2,5,4,3,4,2,3,1,2,3,3,2,2,1,2,3,5,5,3,2,5,5,4,5,2,3,4,2,5,5,2,1,4,5,5,1,5,4,4,5,4,4,2,1,3,1,5,2,1,2,2,1,1,4,1,1,4,2,1,1,2,2,2,1,4,1,3,4,1,1,3,2,2,2,1,2,5,4,4,3,3,1,2,1,3,3,2,4,1,1,1,3,1,2,4,2,1,5,2,4,1,1,2,2,1,3,2,3,4,5,4,2,2,1,4,4,1,2,4,2,1,3,1,3,2,2,4,4,3,2,2,5,3,5,3,4,1,1,3,4,1,3,1,5,3,4,5,1,1,2,4,5,1,1,3,3,4,5,1,4,5,2,1,1,5,3,5,5,3,2,2,4,5,2,5,3,2,1,5,4,5,4,5,4,4,2,1,3,5,2,4,2,1,2,2,5,5,1,4,1,5,3,1,4,1,3,2,1,4,3,5,4,1,5,5,2,4,3,4,1,4,2,2,2,1,2,4,3,1,5,2,3,3,2,2,4,4,2,4,4,5,4,1,1,3,5,1,3,5,1,2,4,3,4,3,2,3,4,2,3,2,2,5,5,1,3,2,2,1,3,1,3,2,4,5,2,4,4,4,5,4,5,4,3,5,3,2,1,5,3,5,5,5,4,5,4,1,2,2,1,1,2,3,1,1,4,2,5,5,5,4,1,2,3,1,5,4,4,1,5,4,1,2,4,2,4,5,2,3,2,1,4,5,3,2,5,3,2,5,5,4,4,3,4,5,3,1,4,5,5,4,5,1,2,4,5,4,3,5,5,5,1,3,2,3,5,4,4,2,3,4,3,3,2,2,4,2,2,2,1,2,5,3,1,5,5,1,5,5,1,1,5,1,1,4,1,1,3,2,4,4,2,2,5,3,2,4,2,4,3,5,2,4,4,4,2,3,4,1,4,2,1,3,5,2,5,3,3,4,3,4,5,3,5,4,5,4,3,2,2,4,2,5,2,4,2,5,3,2,4,2,3,1,5,2,1,3,1,4,4,5,4,3,2,5,3,3,2,5,4,4,3,1,1,1,1,1,1,5,3,5,5,1,3,5,1,5,3,4,3,2,2,5,1,4,5,2,2,4,2,3,4,2,2,2,2,4,3,4,2,5,1,5,4,2,5,5,2,5,5,5,3,1,1,5,4,4,3,3,5,4,1,2,5,5,5,3,3,1,4,1,2,3,1,1,1,2,4,2,4,4,4,1,5,3,2,2,2,4,2,1,2,3,1,3,4,4,2,5,3,2,4,1,4,1,2,3,4,4,4,2,1,1,1,4,1,1,5,5,3,3,1,1,1,3,3,5,5,5,1,2,4,1,2,2,5,2,1,5,4,5,4,2,3,1,1,5,2,1,5,1,5,4,5,1,4,5,1,1,1,4,1,4,1,3,4,2,3,1,4,5,4,2,2,3,3,5,5,5,4,2,5,2,4,4,3,1,1,4,2,4,2,3,1,1,2,4,1,5,1,2,2,4,4,3,4,5,5,5,3,1,3,1,4,3,5,1,1,5,2,5,4,1,3,5,2,4,2,4,1,4,2,4,5,5,1,3,4,1,3,4,4,5,4,2,5,4,3,1,5,5,2,2,3,5,4,1,3,3,4,3,5,5,5,4,2,5,1,4,5,1,5,2,4,3,3,2,5,5,3,5,3,3,2,4,3,4,4,5,3,4,5,3,3,5,2,3,3,2,5,5,3,5,3,4,2,2,4,3,2,5,1,1,1,2,3,4,4,3,1,1,5,5,1,5,1,1,2,3,4,2,3,1,3,5,2,3,4,2,3,1,5,3,5,2,3,2,1,5,3,3,1,3,2,1,2,1,3,4,2,5,1,2,3,4,1,2,2,3,1,2,4,3,3,2,1,2,5,1,2,3,3,5,3,3,2,2,1,4,4,2,4,2,2,2,2,2,3,4,5,4,1,4,1,2,5,3,2,2,2,1,3,4,3,1,5,3,1,1,1,3,1,3,5,4,3,4,5,3,2,3,2,1,4,1,2,4,4,1,2,5,4,2,3,4,3,3,4,2,3,1,2,5,4,4,1,5,2,1,4,1,4,4,5,3,3,1,4,4,5,1,2,3,4,4,3,1,1,4,3,5,3,2,5,4,1,5,5,4,2,4,4,5,1,4,3,5,5,3,3,3,2,2,5,2,5,4,1,2,1,5,3,5,3,2,5,1,2,2,1,5,1,1,4,2,2,3,2,4,1,2,1,3,3,5,4,3,4,2,5,2,1,3,3,3,5,4,3,2,5,1,2,2,3,2,1,4,3,4,4,5,4,3,3,5,3,1,5,1,2,4,3,4,5,3,3,1,1,3,2,4,2,4,5,3,5,4,5,2,1,1,1,2,4,4,5,4,3,4,5,4,2,4,2,5,4,1,1,4,5,5,4,5,3,4,4,4,2,5,1,2,5,1,5,4,5,5,1,2,2,4,3,5,4,5,5,1,5,5,5,5,1,4,5,1,1,1,1,2,5,1,2,3,3,3,5,1,5,4,2,1,1,3,4,5,3,4,3,2,2,3,4,2,1,5,3,2,2,5,1,4,3,1,5,1,1,3,2,3,2,5,2,1,4,2,5,4,2,5,2,1,1,5,1,1,1,2,2,4,1,5,1,4,1,5,2,1,1,4,5,4,1,4,2,2,4,5,5,1,5,4,2,5,2,5,2,2,3,4,2,1,5,3,5,4,3,1,4,4,3,3,1,3,4,5,5,1,3,1,3,4,3,4,2,5,4,4,2,3,4,2,3,1,4,5,4,4,4,4,1,5,1,2,5,3,3,4,3,1,2,1,2,1,4,2,4,5,2,1,3,2,5,5,1,4,2,4,4,3,5,2,5,1,1,1,4,1,5,3,1,1,5,5,2,3,1,2,5,3,4,4,3,4,4,2,4,1,3,1,1,5,3,5,1,4,3,2,5,2,4,2,1,4,5,2,2,4,5,3,2,1,5,4,1,5,5,5,2,5,5,1,4,2,2,2,4,5,3,5,3,4,4,3,2,4,3,3,5,1,2,4,1,3,2,4,2,1,5,3,3,1,3,5,3,5,2,4,5,5,1,5,3,5,5,1,4,3,4,2,3,2,4,3,4,2,4,1,3,4,5,5,5,2,5,2,5,4,5,3,2,5,2,3,5,5,5,3,1,2,1,5,5,1,3,3,1,3,5,2,5,4,3,2,4,4,5,3,4,2,5,3,5,3,3,2,2,3,1,4,4,1,3,3,2,3,5,1,3,5,2,5,3,2,5,4,1,2,1,1,1,4,5,2,5,3,3,3,3,1,5,3,4,2,5,1,3,1,2,3,5,4,2,1,3,4,5,5,3,2,2,3,3,3,1,3,2,4,3,2,1,1,3,1,5,3,3,5,5,2,2,2,2,5,3,2,5,3,3,4,5,5,1,2,4,2,4,4,5,2,2,4,2,5,5,5,2,1,5,5,1,1,3,4,1,2,3,1,3,5,1,1,3,3,5,4,4,5,2,4,5,1,4,4,3,2,4,3,3,1,2,2,5,3,1,1,1,2,3,3,2,4,3,2,4,1,1,5,3,5,2,3,4,4,2,1,3,4,4,2,5,2,5,1,2,3,1,3,5,5,4,4,4,4,1,5,1,1,3,5,1,1,5,3,2,3,4,2,4,2,5,3,4,5,1,5,3,5,5,1,5,5,2,5,2,4,3,3,1,5,5,2,2,5,5,1,1,4,2,5,3,3,4,1,5,4,1,1,4,3,1,5,4,5,2,2,2,2,4,4,5,2,5,1,3,3,4,4,1,1,5,2,4,1,2,1,1,1,5,2,3,3,4,4,5,4,2,3,4,3,3,5,4,3,4,4,3,4,4,1,4,3,2,3,1,4,5,4,3,1,3,4,1,1,1,1,3,2,4,4,4,2,5,2,3,5,4,1,3,2,5,5,4,2,1,3,1,2,2,4,5,5,1,3,5,4,5,4,4,5,3,5,5,3,2,4,4,3,1,2,5,5,2,1,2,3,4,2,2,5,1,5,5,1,1,2,5,1,3,1,1,5,5,3,5,3,3,1,2,1,5,3,3,4,2,1,1,5,1,1,2,2,1,4,4,2,3,4,4,1,3,3,2,2,2,3,5,4,2,5,4,3,5,1,5,3,4,1,4,4,5,4,1,1,5,2,1,5,2,2,2,3,5,5,4,2,1,4,3,5,3,3,1,5,1,4,4,5,2,4,1,5,5,3,2,5,3,5,1,3,1,2,4,3,3,1,1,1,1,4,5,2,5,1,2,2,5,1,4,5,4,1,2,1,4,5,4,3,2,3,5,3,4,2,4,4,4,1,5,5,3,3,3,3,4,3,2,3,4,1,3,1,3,3,3,2,5,5,5,3,1,3,4,5,3,3,3,4,3,1,2,1,5,3,1,1,1,2,5,4,3,5,5,2,2,4,1,5,3,3,1,4,4,5,3,3,4,2,2,1,2,4,3,3,3,2,1,3,3,5,4,3,4,5,1,1,3,4,3,5,1,3,5,1,2,5,3,4,1,1,1,5,3,2,2,1,2,3,2,1,4,1,5,1,3,3,2,4,5,5,2,3,4,3,1,1,4,1,1,3,2,3,1,4,3,5,2,4,5,4,1,2,3,4,2,5,5,4,3,1,2,1,4,1,3,3,5,2,2,5,3,5,3,5,4,4,2,4,1,1,3,2,3,4,4,5,1,1,4,2,3,1,1,1,5,1,4,2,3,2,1,5,1,4,3,4,1,5,5,4,1,4,3,1,1,3,4,1,1,4,4,1,1,1,4,1,4,4,1,5,2,4,2,1,1,1,2,4,5,5,3,4,4,5,1,4,2,4,2,5,1,3,3,3,1,4,2,3,1,4,2,2,1,3,1,1,2,3,2,4,4,5,5,3,3,3,3,3,4,5,2,1,5,2,5,2,3,2,1,1,3,1,5,2,4,1,2,5,1,5,2,2,4,5,2,5,4,2,5,3,3,3,5,3,2,1,1,2,2,5,4,2,2,4,3,1,4,4,5,4,4,3,1,1,2,3,1,5,4,4,2,3,2,2,5,3,1,2,5,3,1,2,4,3,4,4,1,3,2,3,2,2,3,5,5,5,4,4,5,3,4,3,4,5,1,5,4,1,4,5,1,4,3,1,3,1,2,1,5,4,5,4,1,1,2,2,4,5,2,5,1,2,5,3,1,2,1,1,4,5,3,4,2,3,4,5,3,4,4,3,2,3,2,5,4,3,3,5,2,2,5,4,2,3,2,4,4,2,2,2,1,5,4,1,1,3,2,3,2,4,5,4,5,2,4,3,4,1,4,2,4,1,4,1,4,4,4,3,2,1,4,4,2,4,5,3,2,3,5,3,1,3,5,1,3,1,4,1,1,4,4,5,2,4,5,3,1,2,2,5,3,2,5,3,5,4,3,2,5,5,2,1,2,4,4,1,4,3,1,2,3,1,3,2,4,4,5,2,3,5,2,1,1,3,1,2,5,2,1,5,3,1,2,1,3,3,3,3,5,2,3,2,3,4,3,5,4,1,3,4,5,1,5,2,4,3,1,4,2,2,4,2,5,4,1,1,2,4,2,4,1,1,1,5,4,1,2,1,3,4,4,4,2,4,1,2,2,1,2,2,3,5,3,3,3,5,3,1,2,2,4,1,5,3,4,3,2,4,4,3,4,4,2,4,3,1,1,3,3,2,4,4,2,5,5,5,4,1,3,4,5,5,5,3,1,3,1,4,1,1,1,1,5,4,5,4,1,4,1,4,2,5,4,3,2,3,1,2,1,4,4,3,4,2,5,5,5,4,1,3,1,5,3,2,1,5,5,4,3,3,3,2,3,2,3,3,1,4,3,5,5,3,4,2,5,5,5,1,1,2,5,5,5,2,4,4,2,3,5,2,2,4,1,3,5,3,2,5,2,3,1,5,2,4,3,5,5,5,2,1,4,1,5,2,4,1,1,3,4,2,4,2,4,5,5,3,3,1,1,1,5,5,2,1,5,1,4,4,3,2,4,4,1,4,5,4,2,3,3,5,5,2,4,1,3,2,5,1,5,1,1,1,2,4,4,2,1,5,3,3,1,2,2,3,5,2,4,1,2,4,2,2,1,1,1,1,2,2,4,4,3,4,1,4,1,1,3,2,1,5,5,2,1,2,5,1,1,2,2,2,1,1,4,1,4,5,5,4,2,4,1,2,5,1,1,3,4,4,4,5,5,2,3,5,2,5,5,5,2,5,1,1,3,3,2,2,4,4,3,5,2,3,1,4,5,2,5,2,3,2,1,2,1,2,3,4,1,1,1,3,2,1,2,2,3,3,4,4,5,2,4,1,4,5,5,4,2,4,2,4,3,2,1,3,3,2,1,1,2,4,3,3,4,5,5,1,2,2,5,3,2,1,2,4,5,1,2,1,2,3,4,1,4,4,3,2,2,5,2,2,2,4,4,3,5,3,2,5,1,5,1,2,1,4,3,5,3,3,4,4,4,1,4,3,2,4,5,4,4,1,4,3,3,5,5,4,5,3,5,2,5,3,3,1,2,2,1,4,5,2,2,3,4,5,5,3,1,3,4,4,5,4,3,2,4,3,5,2,3,2,1,5,5,4,3,3,1,3,2,4,4,3,1,1,3,5,1,4,3,4,4,5,5,5,3,2,1,4,3,5,3,2,5,5,5,2,5,1,3,5,4,4,2,3,2,3,4,2,4,2,3,5,4,1,2,5,5,2,5,5,5,2,2,5,5,1,2,4,4,4,1,5,3,4,5,5,5,4,3,4,5,1,3,3,3,5,5,3,2,2,3,2,4,2,4,3,3,4,1,2,2,3,1,3,2,2,3,3,2,3,1,3,2,3,1,3,1,3,3,1,5,5,5,5,3,5,3,2,2,5,1,4,1,2,3,1,3,2,2,1,1,5,3,5,3,3,2,3,3,5,5,1,5,1,3,2,1,2,2,2,5,1,3,3,2,2,5,5,5,1,2,2,4,4,5,5,2,5,4,5,5,5,2,5,2,3,5,1,1,1,4,2,4,5,5,2,3,2,2,4,3,2,3,1,5,1,4,3,5,5,4,1,5,5,5,5,5,3,4,1,1,2,4,2,1,4,3,5,1,3,1,4,1,4,5,1,5,4,3,1,3,5,5,2,4,5,1,5,2,5,4,5,1,3,1,3,5,5,5,5,2,2,3,3,4,4,2,2,1,2,1,4,1,3,2,2,2,5,2,3,5,1,1,2,4,5,4,3,3,5,3,3,2,1,3,5,4,1,2,4,4,5,1,2,3,5,4,2,3,5,3,3,3,1,2,4,3,5,4,5,1,5,1,3,5,2,3,5,5,4,2,5,1,2,5,5,1,3,1,4,3,2,2,1,4,1,3,3,1,5,2,2,3,4,1,5,5,4,1,5,5,4,3,4,1,1,5,5,1,4,2,1,3,4,3,5,1,4,5,4,1,1,1,2,3,3,3,4,1,5,1,4,3,4,2,1,2,3,5,2,2,3,1,5,5,3,3,1,3,4,3,4,1,5,3,2,4,4,1,1,3,4,2,5,4,5,2,2,4,2,5,3,1,5,3,5,3,1,2,5,5,3,3,3,4,1,5,1,2,1,4,3,2,2,2,5,5,2,3,3,4,2,5,5,1,2,5,3,3,4,2,2,5,5,1,1,3,3,4,1,3,4,4,2,1,5,5,2,3,2,4,1,2,1,2,3,3,5,4,2,2,3,3,4,3,2,3,3,2,4,5,5,2,1,1,4,3,1,5,1,5,3,2,3,5,5,2,1,5,4,4,3,2,5,5,1,2,1,5,2,4,1,2,1,5,2,4,2,4,5,2,3,2,2,3,3,3,4,5,2,5,3,3,5,1,3,2,2,2,1,2,4,2,4,3,1,3,4,1,1,5,4,4,5,5,2,1,4,4,2,2,4,3,3,1,4,4,5,2,4,5,3,3,4,2,2,4,2,2,1,2,4,5,2,3,4,1,4,5,4,4,2,3,1,3,4,3,4,2,3,4,5,5,5,5,3,4,5,3,3,1,5,3,1,5,1,4,4,5,5,4,1,1,5,1,2,1,1,4,1,5,4,2,3,1,4,3,3,2,2,2,2,5,4,1,2,2,4,2,2,2,5,4,5,2,3,3,3,5,4,5,3,3,5,3,2,5,5,3,5,3,1,2,4,1,5,3,4,2,2,4,2,1,1,5,4,3,4,3,4,5,4,2,3,2,3,1,2,1,2,5,5,2,3,4,5,4,1,4,1,1,1,1,2,1,1,2,2,3,3,5,5,5,2,3,5,5,3,1,5,4,1,1,1,1,2,5,4,4,1,2,4,4,1,4,3,5,2,1,1,3,3,1,3,4,5,5,3,5,4,4,1,3,1,4,3,1,1,3,3,1,1,3,2,4,5,5,4,3,5,5,4,4,5,5,4,4,2,3,4,1,3,5,3,5,2,2,4,5,3,3,2,5,4,1,4,3,1,1,4,5,5,2,5,3,5,4,5,3,2,2,4,2,4,1,3,1,3,4,5,3,1,5,1,2,4,5,3,2,4,1,2,1,3,5,4,2,1,2,2,2,2,2,3,3,5,1,1,2,4,1,1,4,1,3,4,2,5,5,2,1,3,4,2,3,1,4,3,4,4,2,1,5,3,5,2,4,1,1,1,3,5,3,2,2,5,5,1,3,1,4,5,5,5,3,5,4,4,1,3,3,1,2,2,3,5,4,4,3,4,3,1,3,4,2,3,5,1,4,2,1,4,3,3,2,4,5,3,5,3,2,4,5,5,4,3,5,5,4,3,4,4,2,2,3,2,5,4,2,4,2,2,3,4,1,4,2,1,4,1,3,3,5,4,5,3,1,2,1,1,3,2,3,5,3,3,3,2,2,5,2,4,5,5,3,3,4,1,5,5,5,2,3,5,3,1,3,4,4,5,4,2,2,5,5,2,1,2,4,5,3,2,4,4,3,1,4,2,4,2,3,1,3,2,4,5,3,4,4,2,1,2,3,3,5,1,1,2,4,1,5,2,2,4,2,3,2,2,4,2,2,5,4,5,5,1,4,2,3,2,4,1,4,5,2,2,4,5,5,1,1,2,1,5,4,2,5,1,1,1,4,5,1,3,3,4,5,4,2,1,2,5,1,2,3,4,1,3,5,3,1,1,1,2,1,2,4,5,3,2,2,5,2,3,4,3,5,1,1,2,4,5,3,3,4,1,2,1,5,1,2,2,2,3,2,3,3,5,4,3,2,5,5,3,3,4,2,4,1,2,4,1,1,4,1,3,5,3,2,1,3,5,1,4,4,3,1,4,5,2,1,5,2,5,2,4,4,4,3,5,5,5,1,4,2,2,5,5,3,4,5,3,1,1,2,1,2,1,1,2,5,5,2,3,3,1,2,3,4,3,2,5,5,2,1,5,3,2,1,1,3,3,2,1,5,1,4,5,4,5,2,5,3,1,1,5,3,4,5,4,4,2,1,3,3,4,3,2,1,1,1,1,5,1,5,5,4,1,4,2,1,2,3,5,4,4,5,3,4,3,4,5,2,3,4,1,4,5,5,2,3,3,5,4,2,2,1,2,2,4,5,4,3,4,4,4,1,1,4,4,5,4,1,1,2,4,4,3,5,3,5,1,4,3,3,5,1,2,5,3,2,5,3,2,3,5,2,1,5,2,2,2,4,2,2,2,2,1,1,5,1,4,1,1,3,2,4,2,5,2,2,2,5,3,4,5,5,1,1,5,3,2,3,5,3,1,5,3,4,3,2,2,4,4,2,4,5,1,5,5,5,4,4,4,4,1,5,2,3,2,5,4,5,5,4,1,4,5,2,5,5,2,2,2,4,2,5,2,5,2,5,2,3,3,3,4,5,2,3,5,5,1,3,5,1,4,5,1,5,2,4,4,4,5,4,5,3,4,1,4,5,2,4,5,2,5,3,1,1,1,2,3,4,2,3,5,2,1,1,3,5,2,4,3,3,1,4,2,1,3,5,2,5,5,2,2,1,5,2,4,4,3,4,2,1,2,5,4,2,3,2,3,2,3,4,3,3,2,4,4,1,3,5,5,4,3,5,3,5,4,3,5,3,1,5,4,4,3,5,4,5,5,3,5,3,2,2,1,3,1,2,3,3,5,5,2,4,5,1,1,2,4,3,3,5,4,1,4,2,4,4,5,3,1,1,3,1,4,3,4,5,2,3,5,5,1,4,4,2,5,5,2,1,4,2,4,1,1,1,4,2,1,1,2,1,2,2,5,1,5,1,3,4,4,2,4,2,2,1,1,5,4,4,1,4,3,2,2,3,1,3,2,2,5,4,2,5,2,5,4,3,4,4,4,3,3,5,3,2,5,1,5,1,5,1,1,5,5,4,3,3,4,3,1,1,3,5,2,3,4,3,5,4,1,2,1,2,1,5,3,2,3,3,2,1,1,2,2,5,4,5,4,1,5,1,3,3,4,1,5,3,4,2,5,2,5,5,3,4,4,2,1,2,3,2,3,2,5,4,2,3,5,5,2,5,3,5,2,1,5,5,4,4,2,4,2,2,2,1,2,4,3,2,5,4,5,1,4,2,1,5,2,4,1,2,1,2,4,2,1,2,5,1,5,2,3,4,3,1,3,4,1,2,1,2,4,1,4,4,1,2,4,2,5,5,1,5,2,4,5,1,3,1,2,4,5,4,1,5,1,5,2,2,1,2,3,5,1,1,5,5,2,4,2,4,3,1,5,4,4,2,2,1,3,3,4,2,3,5,1,1,2,3,3,4,1,5,1,3,3,1,2,4,2,1,5,4,2,5,3,1,3,3,5,2,4,2,3,2,2,5,1,5,2,1,2,5,2,5,3,2,1,3,3,5,4,4,5,3,1,1,3,2,3,2,4,4,4,4,5,2,2,3,3,2,3,4,2,3,1,2,1,2,1,4,2,5,2,3,2,1,3,4,4,5,3,1,4,1,2,2,5,4,4,2,3,4,3,1,5,5,4,2,5,1,5,5,1,5,2,5,2,5,4,3,4,1,1,1,2,1,5,5,5,1,5,1,2,4,1,2,2,5,1,4,4,4,3,1,5,5,1,1,5,4,4,1,2,1,5,3,1,3,4,3,4,5,4,1,3,5,3,2,5,1,1,4,2,5,4,3,5,5,2,5,1,1,3,5,3,4,1,1,5,1,1,4,1,3,5,5,4,4,2,3,1,5,2,1,4,1,2,5,1,1,4,5,2,5,2,2,3,3,4,5,1,5,1,1,4,2,4,1,1,4,1,2,5,2,4,2,3,3,5,3,4,1,3,5,2,4,1,4,5,1,3,4,2,2,3,5,2,5,2,1,2,2,2,5,5,5,4,5,2,4,1,5,4,4,2,4,2,5,5,3,3,2,1,5,1,1,1,4,3,3,3,1,1,3,3,5,1,2,4,4,3,1,4,4,1,2,3,1,3,5,4,1,4,3,5,5,4,5,1,1,1,2,2,1,3,3,5,1,4,5,5,2,5,5,5,2,5,1,1,2,3,4,4,3,2,4,5,4,5,4,3,3,5,3,5,2,3,1,2,1,4,1,4,5,2,2,3,1,3,1,4,4,1,5,1,5,5,3,5,3,2,3,5,4,1,5,2,5,1,1,4,4,2,3,4,2,2,1,3,2,5,4,5,3,3,4,4,5,5,3,2,4,2,2,1,3,2,5,3,5,2,5,3,5,2,1,3,1,4,3,1,4,3,4,3,2,1,1,2,5,2,3,3,5,5,5,2,5,5,2,1,2,2,2,5,3,5,5,4,4,4,3,4,5,1,3,5,3,4,5,5,3,4,5,3,5,2,5,1,3,3,4,2,3,3,4,3,5,2,2,1,1,1,1,1,1,5,1,4,5,5,5,4,3,5,3,3,4,3,5,2,4,2,3,5,1,2,2,1,3,2,4,3,5,2,1,1,5,2,3,2,3,4,5,3,2,5,1,1,4,2,1,5,3,3,5,2,3,5,4,2,3,1,1,4,1,2,5,3,1,3,1,3,5,3,1,3,1,4,2,5,2,2,5,3,1,4,3,2,1,3,4,1,5,2,1,2,3,5,1,2,2,1,5,5,3,4,2,2,1,1,1,1,1,3,1,5,3,4,3,5,5,5,1,1,3,1,4,5,4,3,5,2,4,1,3,5,2,2,2,2,3,2,1,3,3,3,1,4,4,2,3,2,5,4,4,1,1,4,1,1,3,1,4,1,1,4,1,2,2,5,3,5,3,1,2,5,1,5,5,4,4,2,5,2,5,5,5,2,1,1,1,1,2,5,3,2,3,1,3,5,2,4,2,2,1,2,4,2,1,2,5,4,1,5,3,1,3,5,5,4,1,2,2,2,3,2,1,2,3,4,2,3,3,1,2,4,1,2,4,4,4,1,2,4,1,4,2,2,4,1,5,2,5,4,1,3,5,4,4,5,5,5,4,1,1,4,5,4,4,3,3,5,3,5,5,3,4,2,5,3,2,4,2,4,4,2,2,3,4,5,1,2,1,3,3,3,4,3,1,1,1,3,5,3,1,5,1,1,1,3,3,5,1,5,2,1,3,4,3,5,1,4,2,3,2,3,2,4,3,3,5,4,5,3,2,4,3,3,5,4,5,2,5,3,3,1,3,1,3,5,2,4,5,1,3,4,3,3,1,1,2,4,3,5,2,4,2,2,2,1,3,5,1,3,1,2,3,5,2,1,2,1,4,1,3,5,4,5,3,5,4,2,2,3,4,4,3,3,5,4,5,5,4,4,3,5,3,4,1,4,2,5,5,2,2,3,4,1,1,2,1,3,2,2,4,3,2,4,3,3,2,1,1,1,2,4,1,1,3,4,5,4,3,1,2,1,1,1,3,3,2,5,2,1,5,4,5,1,2,2,4,3,5,3,4,1,2,3,1,2,3,5,2,3,3,1,5,2,5,5,1,2,5,1,1,3,4,4,5,4,5,3,5,2,1,1,4,4,5,2,5,2,1,1,2,3,3,1,5,4,2,2,4,4,2,4,4,3,3,4,2,4,2,5,1,2,2,5,2,1,4,2,1,1,3,3,2,2,1,4,5,5,5,1,3,2,2,1,5,5,2,4,1,2,5,2,3,4,3,4,2,1,1,3,4,5,4,3,4,5,2,2,4,4,2,5,4,4,2,3,4,4,2,2,3,5,5,1,1,4,5,2,5,5,4,4,1,1,3,4,3,4,2,4,3,4,2,1,4,4,3,1,2,1,3,3,3,4,2,2,3,1,2,3,2,1,5,4,5,4,2,5,1,3,2,5,1,2,4,1,2,5,1,1,3,5,4,3,1,5,1,2,1,1,5,5,5,5,1,4,2,2,5,5,3,2,1,5,5,4,1,4,3,5,5,4,5,5,4,1,1,5,3,2,3,1,2,3,4,3,1,1,3,4,1,3,1,1,5,2,3,4,1,3,3,1,2,3,3,5,5,3,4,1,2,2,3,5,2,2,3,5,3,1,2,5,5,3,1,3,3,2,4,1,4,1,4,3,2,4,5,4,2,2,1,1,4,1,2,1,2,4,3,4,5,1,1,5,3,1,2,4,3,5,5,5,3,4,4,2,4,4,5,2,3,5,3,3,1,1,5,1,1,3,5,3,3,1,3,5,1,1,2,3,3,4,5,2,5,2,2,1,5,4,2,2,1,4,5,4,1,5,4,5,4,3,5,2,1,1,3,5,3,4,3,1,4,4,5,2,3,1,5,5,3,3,5,2,2,4,2,4,2,3,4,5,1,3,5,2,2,1,5,1,2,4,3,2,4,5,1,5,1,4,4,5,5,5,5,3,5,4,5,2,2,5,5,2,5,3,3,2,1,2,2,1,4,3,4,1,1,4,3,4,3,5,2,3,3,2,1,5,4,4,4,5,5,1,5,5,1,5,3,3,1,3,2,3,5,1,4,5,2,3,5,1,3,2,3,1,1,4,5,4,2,5,2,4,2,5,5,5,1,2,3,1,5,3,3,5,5,2,4,3,5,1,1,4,2,2,2,2,5,5,1,2,1,3,3,1,1,4,1,4,1,5,3,2,2,2,1,1,2,1,2,4,3,1,3,2,5,2,4,4,1,5,2,5,1,2,3,3,2,2,1,5,2,3,5,3,4,1,1,4,1,1,3,2,5,2,1,2,2,1,4,1,3,5,1,2,2,1,3,4,4,5,2,4,1,4,3,1,1,1,4,1,4,2,3,4,5,3,1,3,2,5,2,2,3,4,2,2,3,1,5,4,3,4,4,3,1,1,1,5,2,3,5,5,3,4,3,2,4,5,3,2,5,3,5,1,4,4,4,1,1,2,2,3,4,2,2,3,4,5,1,4,1,5,1,5,3,4,4,5,1,1,2,3,2,5,4,3,1,5,2,3,4,5,3,3,3,5,5,3,4,1,3,1,3,2,2,5,5,1,1,2,1,3,2,3,4,2,1,1,3,1,4,3,5,3,2,5,3,5,4,3,4,4,1,2,4,2,4,1,2,3,4,4,4,1,4,3,2,1,2,4,2,5,1,4,2,4,5,2,3,2,3,5,3,1,3,4,4,2,2,2,1,1,1,4,2,5,2,5,1,5,5,2,5,5,5,1,5,4,5,1,5,3,2,1,2,3,4,2,5,2,4,1,4,3,4,4,2,1,2,5,2,2,2,2,4,3,5,3,1,4,4,5,2,2,3,1,5,1,1,4,3,5,1,5,1,3,1,5,5,5,1,2,1,4,5,3,5,3,4,5,3,1,3,3,3,4,4,4,2,1,5,2,4,2,3,4,2,1,2,2,4,4,4,4,3,1,2,4,1,3,1,3,3,1,2,1,3,2,4,1,3,1,2,2,5,3,5,4,1,2,4,5,3,1,3,1,4,5,2,5,5,3,3,1,4,4,3,4,4,4,1,4,2,1,3,2,5,2,3,3,1,5,5,4,5,3,4,4,4,1,5,4,5,1,5,4,2,3,2,4,5,5,2,2,1,5,2,3,3,5,2,5,1,5,3,1,3,3,5,4,5,4,1,1,3,4,5,4,2,4,2,2,5,1,1,2,3,1,1,1,5,1,5,2,1,1,1,3,4,1,4,2,3,5,2,3,5,1,5,5,5,1,2,4,2,1,1,1,4,2,3,2,2,2,1,4,4,2,1,5,5,5,2,5,1,1,3,2,3,1,1,4,4,1,3,3,5,1,1,5,3,1,4,5,5,2,2,1,3,3,1,5,4,4,3,2,2,5,3,3,4,4,3,1,4,1,5,2,1,5,3,1,1,3,1,5,1,2,1,2,1,4,1,2,1,4,5,1,1,4,3,4,3,4,4,1,5,1,5,1,1,1,5,5,5,4,3,4,2,3,4,4,1,1,5,4,5,4,4,4,5,1,1,1,1,2,3,2,2,3,4,4,1,5,3,3,4,1,1,5,5,3,5,1,4,1,3,1,5,3,3,4,5,5,4,4,4,3,4,2,4,3,1,2,2,5,3,1,4,4,5,4,4,1,1,1,2,1,5,3,2,3,2,5,2,3,5,5,3,2,3,2,1,1,4,5,5,1,2,2,1,3,3,4,2,1,5,2,1,5,5,1,4,3,3,3,1,2,2,4,5,2,1,3,1,5,4,4,5,3,2,3,3,2,3,3,4,3,4,3,4,4,2,4,1,1,1,2,5,5,4,1,3,2,4,3,4,5,1,2,1,5,4,1,2,5,2,3,3,1,5,3,2,3,1,1,3,1,4,5,2,3,4,5,5,1,1,3,4,1,1,3,5,5,4,4,4,5,4,2,3,2,4,1,3,2,2,1,3,4,5,3,4,1,4,1,2,4,3,4,2,3,1,4,1,3,1,4,2,5,4,2,2,2,5,2,4,3,2,3,2,3,4,2,2,4,3,5,4,3,2,5,3,4,2,2,5,5,2,3,4,4,3,1,2,5,1,4,5,2,3,4,4,1,2,4,2,2,3,2,4,5,1,2,1,3,4,2,3,1,2,1,3,3,5,5,4,1,1,5,2,4,1,3,5,1,5,5,3,5,1,4,2,5,2,5,4,4,1,3,2,2,3,3,4,3,2,3,5,1,5,2,2,1,1,2,3,5,3,2,4,5,3,2,2,5,2,2,3,1,4,2,5,3,3,1,1,3,2,4,1,2,2,5,4,5,5,1,2,1,4,2,4,4,3,2,2,4,1,1,1,5,1,5,1,2,4,4,1,3,4,4,4,2,2,4,5,1,2,1,3,2,4,2,3,2,5,4,5,4,5,3,5,2,4,3,5,4,2,1,3,2,1,4,3,2,3,1,4,5,2,1,4,3,4,1,4,4,2,2,5,1,1,3,5,5,5,1,3,4,2,1,5,2,5,4,2,1,4,2,3,2,4,3,4,2,4,4,1,1,5,2,4,2,2,3,1,5,5,1,1,4,1,1,5,2,1,2,3,2,5,3,2,3,4,1,1,4,3,2,2,3,3,1,1,2,2,5,2,4,5,3,4,4,2,1,4,5,2,4,5,3,2,1,2,4,4,3,2,2,1,5,5,4,4,1,5,5,2,5,2,1,5,4,2,1,2,5,4,5,3,5,2,2,1,2,5,3,3,4,4,3,1,1,3,1,5,2,1,5,3,1,1,3,4,2,4,4,3,2,5,5,3,3,3,1,2,2,5,1,4,4,4,2,4,2,5,2,3,5,5,2,3,4,2,1,1,5,4,1,2,4,3,2,5,3,5,5,5,1,1,5,3,2,2,3,4,1,5,3,3,2,1,3,3,2,2,5,1,3,1,5,5,4,4,1,4,4,2,2,5,5,1,5,2,4,2,1,4,3,1,3,4,5,5,2,2,5,3,3,3,1,3,5,1,3,2,4,4,3,5,2,1,2,3,2,5,2,5,2,5,4,5,3,4,1,5,5,2,5,4,2,3,2,5,5,3,2,2,5,3,3,1,2,1,2,1,4,2,1,3,1,2,2,3,5,1,2,3,1,3,5,1,2,1,1,1,4,1,1,4,1,1,5,1,1,3,2,2,1,3,5,2,3,3,4,2,3,5,3,2,3,5,5,2,3,4,5,2,2,3,4,1,1,2,4,3,4,3,5,2,3,2,2,3,2,3,5,1,4,1,4,2,3,4,5,5,1,2,5,3,2,5,4,1,4,3,5,3,2,4,1,2,4,3,5,3,4,4,4,3,2,5,4,5,4,2,5,5,3,5,5,2,1,4,5,5,1,5,4,5,2,5,2,4,1,5,2,1,4,5,5,5,1,2,2,3,5,5,3,1,2,3,5,2,5,2,2,4,3,1,1,3,3,4,2,1,5,5,1,3,1,5,3,3,4,2,3,5,4,4,4,5,4,2,5,3,2,4,2,1,4,3,3,5,1,4,2,4,1,1,5,3,3,3,3,4,4,3,2,5,4,1,2,2,5,4,4,4,3,2,3,3,2,1,2,2,2,1,1,4,1,4,1,1,1,2,3,2,3,1,5,1,4,2,4,2,4,2,2,4,2,3,2,5,5,4,1,1,3,5,5,2,5,5,3,1,1,1,1,4,4,5,3,1,4,4,1,3,2,5,1,5,1,2,4,5,3,1,5,2,3,1,3,5,3,5,5,2,2,1,5,3,5,4,3,4,4,4,5,1,4,4,1,5,2,2,4,2,1,3,3,3,3,3,2,3,3,5,2,2,1,3,1,5,3,4,4,4,1,1,2,2,1,3,4,1,5,1,4,2,1,4,4,1,2,4,5,3,2,2,2,5,1,1,2,5,2,3,2,5,1,2,2,1,4,4,1,3,5,5,3,5,1,1,1,2,4,4,5,5,3,3,1,4,3,5,1,4,4,2,5,4,3,3,3,1,3,3,2,5,5,3,2,4,1,3,2,5,4,5,5,1,5,4,1,5,5,3,2,1,1,3,4,2,4,4,3,1,4,4,1,3,2,1,5,5,4,4,5,4,1,3,1,1,4,1,1,3,4,1,3,2,4,1,1,5,1,3,2,5,3,3,4,1,3,2,1,3,4,1,4,3,4,2,5,5,5,3,2,3,2,2,5,4,1,1,4,3,5,4,2,2,4,3,5,3,1,5,1,1,3,1,3,5,5,5,4,2,5,5,5,3,2,1,4,3,3,4,4,5,4,5,3,3,1,2,2,1,2,2,5,3,3,2,1,4,2,5,4,5,2,3,2,2,1,1,1,2,1,2,1,1,2,4,5,5,2,4,2,2,1,3,3,2,5,1,2,5,1,4,1,4,2,1,4,1,4,4,1,4,2,5,4,4,2,5,1,4,4,3,3,2,2,2,1,4,1,4,2,1,1,3,4,2,3,4,1,3,5,4,4,5,2,4,2,4,5,2,2,1,4,5,4,2,3,4,1,2,5,5,3,1,1,1,4,4,3,3,4,2,1,2,1,2,2,5,2,4,2,5,5,1,5,4,3,1,3,5,1,4,2,3,2,3,2,3,5,5,3,4,3,1,3,4,5,3,3,2,1,3,5,5,4,1,3,2,1,4,4,2,1,1,4,4,1,1,5,2,4,5,5,2,1,5,2,2,1,4,5,2,4,2,2,1,3,2,3,4,1,4,1,1,2,5,4,3,4,4,3,4,1,3,2,2,5,5,3,5,5,2,1,1,1,5,1,3,4,5,4,3,4,4,3,3,1,3,1,5,2,4,4,5,4,5,2,5,4,2,3,2,3,2,4,3,5,2,3,2,5,3,5,1,2,1,3,5,2,2,3,4,4,2,2,1,1,1,4,1,3,5,4,1,4,5,3,2,2,5,4,2,3,3,1,3,1,5,4,5,4,4,2,3,2,3,1,4,1,2,3,5,1,1,4,2,2,1,3,2,5,2,3,4,1,2,4,5,1,4,3,1,5,4,5,5,1,2,1,3,3,1,4,1,5,1,4,5,5,3,3,5,5,2,5,1,2,4,5,5,5,4,2,3,3,4,1,4,5,3,4,1,4,2,1,4,2,2,5,5,2,2,3,2,2,4,3,5,3,3,5,4,1,5,2,1,1,4,3,2,5,3,2,1,1,5,3,4,4,1,1,1,4,5,1,1,4,4,3,2,3,4,1,2,2,1,3,5,4,2,5,3,1,5,3,2,5,2,4,2,1,1,5,1,5,5,5,2,2,1,3,5,4,2,1,4,1,3,2,1,1,4,2,3,2,3,3,5,3,1,5,4,3,3,3,2,5,1,3,4,4,1,3,2,2,5,1,1,4,1,3,3,1,1,4,5,2,3,1,2,3,1,1,1,1,3,1,3,3,2,5,1,3,5,1,2,2,3,3,4,1,5,5,2,3,3,2,5,4,4,5,2,1,3,3,5,5,2,3,2,3,2,5,5,2,4,2,1,3,5,3,2,5,3,1,2,3,1,4,5,3,1,4,4,1,2,1,1,1,1,5,2,4,5,5,4,5,5,1,1,3,2,2,1,4,2,5,3,4,2,4,3,5,1,5,5,2,4,1,3,2,4,3,2,2,3,5,3,1,2,4,2,3,3,4,5,2,5,3,1,1,3,1,2,5,2,4,4,4,1,3,3,1,4,2,4,1,2,3,3,5,3,3,5,3,5,2,4,1,4,2,3,2,4,5,2,1,5,5,3,2,2,3,1,2,5,4,5,4,3,3,3,2,4,4,2,4,1,1,2,5,3,5,1,2,2,4,2,1,1,3,1,3,2,4,4,1,4,2,4,1,4,2,4,3,2,5,1,2,4,1,5,3,4,3,2,3,5,2,4,3,5,4,2,2,1,4,4,5,2,1,2,3,2,2,4,1,4,2,2,1,2,4,2,2,1,4,4,2,3,4,3,5,5,1,3,3,5,3,3,5,1,4,2,1,3,1,1,5,5,2,5,3,4,4,5,3,3,4,2,2,3,3,3,3,1,1,3,2,2,4,4,1,1,4,4,3,4,5,5,1,5,3,3,5,3,4,4,5,5,3,1,3,3,4,3,1,3,5,5,4,5,5,2,2,5,5,3,5,3,1,2,4,4,1,5,2,4,2,2,3,4,4,1,2,2,4,5,3,1,5,3,1,5,5,1,1,5,3,3,2,2,4,5,2,5,4,5,2,2,5,5,4,2,2,3,4,2,4,5,1,2,1,3,5,2,2,2,2,3,2,3,5,2,3,1,5,5,4,4,3,5,2,4,1,1,5,5,1,3,2,3,4,3,1,2,1,5,1,4,1,2,1,5,5,4,5,1,4,3,3,5,5,3,3,3,5,4,2,2,3,3,5,1,5,3,3,1,5,1,1,2,5,5,5,2,4,5,4,2,4,2,5,2,5,2,3,4,2,4,4,1,3,1,2,5,1,4,5,3,2,2,4,3,5,3,5,2,3,3,3,3,3,2,5,3,5,3,3,3,5,5,5,1,3,1,1,4,3,3,5,4,5,3,1,5,2,5,2,3,5,1,2,3,3,2,4,5,5,4,2,2,1,5,5,2,1,1,2,1,1,2,2,1,4,2,1,4,3,1,1,3,3,2,5,4,5,3,4,3,2,5,2,2,5,2,1,3,4,5,3,1,3,3,5,2,3,4,1,4,5,3,1,5,3,3,4,4,1,4,5,4,3,4,2,3,5,4,5,4,1,4,5,5,5,4,4,3,3,4,2,3,1,3,5,5,2,1,2,1,5,2,2,2,5,3,5,4,2,2,5,4,2,2,1,3,2,1,5,2,5,5,3,3,1,5,5,2,5,2,4,5,5,2,5,2,3,5,3,5,5,2,4,3,5,3,2,4,2,2,3,4,2,5,2,5,2,4,4,2,4,1,5,2,3,1,3,3,1,2,3,3,3,2,3,5,5,1,5,2,1,5,4,2,1,3,4,2,4,1,3,2,2,5,3,1,4,4,3,1,3,5,1,4,4,1,2,3,3,1,2,5,3,2,3,4,4,4,1,2,2,1,4,5,5,2,2,5,2,4,3,4,5,5,3,5,1,2,2,1,3,4,4,2,5,2,3,2,2,2,4,5,3,5,4,1,4,5,3,3,3,1,2,3,1,4,2,2,3,1,5,3,4,1,2,1,5,2,1,2,1,3,2,2,2,2,5,1,3,2,5,1,4,1,1,1,1,1,4,1,2,1,1,3,4,3,2,1,1,5,4,5,5,4,2,4,4,3,1,3,1,4,1,4,2,3,5,1,1,5,5,5,2,1,5,1,5,5,1,1,1,4,5,1,1,1,1,1,5,1,1,4,2,3,2,4,1,4,2,1,4,3,4,5,3,3,1,5,3,5,4,2,5,2,1,3,4,2,5,4,4,1,4,4,1,3,2,3,2,4,4,1,4,5,5,1,4,1,3,5,4,2,5,3,2,5,1,4,3,5,1,3,1,1,2,2,4,1,2,3,3,5,4,3,1,3,1,3,3,5,1,3,2,1,1,4,1,3,3,2,5,4,2,3,1,3,3,4,2,3,3,3,2,2,5,3,3,4,1,5,2,1,2,2,1,1,4,5,4,5,1,1,1,3,1,3,3,2,1,4,2,2,3,1,2,1,3,1,1,5,3,4,3,4,5,1,2,3,2,5,3,5,5,5,5,2,4,4,5,5,5,1,1,3,5,5,5,1,2,1,3,3,2,1,2,2,5,5,5,3,1,2,2,4,5,5,4,1,4,4,3,1,2,1,2,2,5,2,1,4,4,5,3,5,2,5,1,5,2,5,2,1,1,2,4,2,3,4,2,5,4,1,4,1,3,3,2,4,1,4,1,1,3,5,3,3,4,2,5,4,3,3,3,2,5,3,1,3,3,2,2,1,2,5,3,1,1,1,1,2,5,3,4,1,4,3,3,3,2,4,3,5,4,2,5,5,5,1,2,4,4,3,4,5,1,4,3,1,1,2,1,1,1,4,3,4,4,1,5,5,3,2,4,5,3,1,4,2,2,2,5,4,5,1,2,1,4,4,4,3,5,4,2,5,5,5,3,3,2,4,4,3,4,1,4,3,2,2,5,5,3,3,3,3,2,4,3,2,5,1,3,5,5,5,5,1,5,1,4,2,5,4,5,2,3,1,3,3,1,1,2,2,2,3,1,1,5,3,4,2,5,5,2,1,1,3,2,4,4,5,5,4,4,3,5,4,3,2,2,4,2,2,1,1,2,5,4,3,3,5,1,2,2,4,5,5,1,3,1,5,3,3,1,3,4,1,2,3,2,1,3,5,5,1,5,4,4,3,5,4,2,1,2,4,5,2,4,5,1,3,3,5,2,2,4,5,1,4,4,2,2,4,3,3,5,2,4,4,3,2,4,3,2,5,4,4,4,5,5,4,5,3,2,3,2,5,5,3,3,2,1,5,5,2,5,5,5,2,2,2,3,3,4,4,5,4,2,5,5,4,1,3,2,2,5,4,2,4,2,2,4,5,4,3,1,1,2,5,2,4,1,3,4,2,5,2,3,3,5,3,2,3,2,4,4,3,15,2,2,2,4,1,1,2,4,2,2,2,4,1,2,4,1,2,4,4,3,2,3,1,3,3,4,3,5,2,5,3,4,1,3,2,3,3,3,5,2,4,1,5,4,5,4,4,4,5,3,2,1,1,3,1,1,5,5,3,5,2,2,4,5,2,4,3,2,4,4,5,3,2,3,2,4,5,2,2,3,5,2,3,1,3,3,2,4,3,5,4,3,1,3,3,2,4,4,3,5,3,3,3,5,1,3,5,5,2,5,2,3,4,3,3,2,1,3,1,2,3,2,4,2,3,3,3,3,4,3,3,1,1,5,1,3,4,5,5,3,3,1,5,5,5,5,2,3,1,3,2,3,5,5,1,1,3,4,1,1,2,4,4,4,1,2,3,3,2,1,5,3,1,1,2,2,1,5,2,1,1,4,2,4,5,2,2,2,1,1,1,3,2,4,5,1,4,4,1,5,2,1,4,3,5,4,2,1,5,5,5,2,1,4,5,2,2,1,2,4,3,2,4,3,3,5,3,5,1,4,1,2,4,2,1,5,5,1,1,5,5,1,3,5,2,5,4,1,1,2,1,5,2,3,3,1,1,2,2,5,2,1,3,5,5,4,2,5,5,4,2,1,3,3,1,2,5,5,1,4,4,5,4,3,2,4,5,1,4,1,2,2,4,5,3,3,5,1,4,2,5,1,5,3,3,2,4,3,5,1,2,4,2,3,4,4,4,4,3,4,5,1,2,3,1,5,2,2,3,5,4,5,3,2,3,3,3,1,4,2,3,3,4,4,3,2,2,2,2,1,4,2,3,1,4,4,5,4,1,3,1,2,3,4,3,2,2,3,2,3,5,2,3,3,1,1,3,4,1,2,3,3,4,5,3,2,4,2,2,3,1,3,1,3,1,2,1,1,4,3,3,1,3,4,1,4,4,5,5,2,5,4,2,5,4,1,3,1,2,2,5,4,4,2,2,5,4,2,3,5,5,1,3,1,2,1,2,1,2,5,4,5,4,3,5,1,4,5,1,5,5,2,3,2,3,5,1,1,4,4,5,5,5,4,5,2,4,2,3,3,2,4,2,5,2,3,3,2,4,3,5,3,4,5,5,2,1,4,5,2,1,2,5,1,1,3,3,5,5,4,2,4,3,1,3,1,4,3,1,2,2,4,5,4,4,3,5,5,4,4,4,2,2,5,4,4,1,1,4,5,4,3,4,3,3,2,3,2,3,5,5,5,5,2,1,1,5,3,4,3,2,1,3,4,2,4,2,4,1,3,5,3,3,1,1,3,3,2,3,2,4,4,5,2,1,4,1,1,3,2,1,5,2,2,1,4,4,2,1,2,5,3,2,2,2,1,2,3,4,3,2,2,3,3,4,2,2,5,4,2,1,2,5,1,2,1,2,3,5,3,2,5,3,3,1,5,5,5,5,5,2,4,2,5,2,2,4,3,3,3,1,2,5,1,2,1,3,1,5,3,2,4,1,3,5,5,5,3,2,3,4,1,5,5,5,1,4,1,2,4,4,3,1,4,1,1,5,5,3,4,5,1,2,2,4,2,4,4,5,4,3,5,1,2,5,1,4,2,5,3,2,1,5,5,3,4,2,2,4,2,4,3,3,5,1,1,4,2,1,3,2,3,1,3,1,4,4,3,2,5,2,5,4,2,3,5,4,5,2,5,4,1,5,5,4,4,2,4,5,4,1,4,2,2,5,5,3,1,4,2,1,1,5,3,2,4,1,5,5,4,5,4,5,5,3,1,4,4,3,2,4,2,4,5,4,2,5,5,3,5,4,1,1,1,3,4,3,2,1,2,3,5,2,5,1,1,4,3,5,3,3,4,3,1,1,1,3,2,5,2,3,1,1,4,2,3,3,3,3,4,2,2,2,3,4,5,1,4,1,4,2,2,2,4,4,5,3,3,3,5,1,1,1,1,3,2,3,3,5,5,3,5,2,2,4,3,4,3,2,1,1,1,2,5,4,3,1,3,4,2,1,2,4,5,5,5,4,2,4,4,5,2,2,2,4,5,2,5,3,5,3,1,2,4,2,2,2,5,2,2,2,5,5,4,2,2,4,4,2,3,2,1,2,1,1,4,5,4,3,1,1,4,2,1,5,5,2,4,2,5,2,3,5,5,1,4,5,3,2,1,2,4,2,3,3,2,4,3,5,4,2,3,1,2,4,2,5,3,1,2,5,5,1,4,4,5,5,5,1,1,4,3,5,5,2,5,2,4,5,2,5,2,1,2,4,2,2,4,4,4,2,3,5,5,2,1,5,4,1,4,5,3,5,4,2,5,3,1,4,3,4,5,1,5,5,1,5,4,1,1,1,1,2,3,2,4,1,3,3,1,5,4,3,5,3,2,3,4,3,2,1,3,4,4,5,4,5,2,2,1,5,3,5,5,4,4,1,4,1,3,3,5,4,5,4,1,3,5,3,1,5,2,5,5,4,3,2,5,1,2,5,2,5,4,4,5,3,5,1,1,3,3,4,4,4,4,4,2,2,3,5,4,4,1,2,2,2,1,4,5,5,5,3,5,2,1,5,2,3,1,5,2,4,1,2,3,2,3,3,2,3,5,2,1,5,3,5,1,5,3,4,5,4,2,1,2,2,5,4,1,1,3,3,3,5,2,4,3,1,1,1,1,1,5,2,1,3,3,5,5,4,3,2,5,4,5,5,3,4,4,1,1,4,3,2,3,1,4,1,2,2,5,3,4,3,4,4,5,1,1,5,4,4,5,1,2,1,2,5,1,1,5,2,2,2,5,1,4,1,4,4,3,4,2,1,1,5,4,5,5,3,4,2,3,2,5,1,3,2,5,1,2,2,5,5,1,1,1,4,1,5,1,1,4,4,2,5,5,3,4,3,5,2,4,3,4,5,2,1,2,3,2,1,3,4,1,1,2,5,5,1,4,4,5,2,2,5,5,5,5,5,3,3,4,1,3,5,1,4,5,4,4,1,5,3,1,4,3,4,5,1,3,4,4,2,1,2,3,1,4,5,1,4,1,5,4,5,5,2,1,5,4,4,1,5,5,4,5,1,5,5,5,5,4,5,4,2,3,2,5,5,2,5,5,2,2,2,2,2,5,1,1,3,5,3,1,2,1,1,2,5,1,1,4,4,1,3,3,3,5,4,1,5,4,4,3,5,4,2,3,2,1,1,1,4,5,2,5,2,3,3,2,1,1,4,1,4,4,3,2,3,4,2,5,1,2,3,4,2,3,3,2,4,4,3,4,4,3,4,2,4,2,2,4,1,2,5,5,3,4,2,1,1,2,1,4,2,4,3,2,5,1,3,2,1,2,5,2,1,5,4,4,3,5,1,3,5,1,3,4,2,3,1,1,4,4,4,2,2,4,2,3,4,1,4,3,2,5,5,1,3,2,1,4,3,4,1,4,1,1,4,1,5,2,2,5,2,1,2,5,1,5,4,4,2,1,2,2,1,3,4,5,5,2,3,3,4,3,2,5,3,3,2,4,4,5,1,1,1,2,4,2,4,3,3,2,2,1,1,3,2,4,1,5,1,3,2,4,2,4,4,1,4,5,5,2,1,4,1,1,5,1,1,1,5,2,4,5,1,2,3,5,2,5,1,1,5,5,2,1,4,3,3,1,2,1,5,1,2,2,3,3,3,1,1,4,2,2,2,3,1,5,2,3,1,5,5,2,5,5,3,3,3,2,2,2,4,5,3,1,4,4,2,4,1,2,2,2,3,4,2,5,4,1,2,1,5,4,5,4,2,4,1,2,3,3,2,3,1,4,2,4,5,3,2,3,3,4,4,2,5,3,4,4,3,1,1,3,2,5,3,2,1,5,2,5,1,3,1,3,4,4,4,1,5,4,5,2,1,4,2,2,5,1,5,3,1,2,5,2,3,2,1,2,3,1,4,1,1,5,1,4,2,3,4,5,1,4,4,2,1,4,2,3,3,2,1,2,4,1,2,3,5,4,3,2,1,5,4,1,4,3,1,5,4,5,4,4,3,5,2,1,1,1,3,3,1,4,4,4,3,1,3,1,3,4,4,4,5,4,5,1,5,4,2,2,3,5,1,5,1,5,3,1,1,2,1,4,1,5,4,1,4,2,5,2,1,5,5,4,3,1,3,2,4,5,1,5,1,3,1,1,4,2,5,4,4,3,5,2,4,5,5,5,3,2,5,4,3,5,4,4,1,3,2,1,3,2,3,5,3,2,4,1,5,3,4,2,5,1,4,5,3,3,2,5,4,1,3,5,3,1,4,4,5,3,5,5,5,1,4,2,2,1,2,2,2,3,2,3,2,5,3,4,1,1,1,5,5,1,4,5,2,5,3,4,3,2,3,2,5,1,4,4,1,4,5,5,1,2,1,4,1,5,2,5,2,4,2,5,3,4,5,1,3,4,2,5,3,1,4,1,5,5,4,2,5,4,2,2,1,3,2,5,5,4,5,4,3,1,4,2,5,4,2,4,2,4,4,4,5,4,3,1,2,2,5,3,4,4,2,1,3,5,3,5,4,3,3,3,3,4,1,1,3,1,3,1,2,3,2,3,1,2,3,5,2,5,3,3,4,2,5,4,3,4,5,4,5,5,1,2,3,5,2,1,3,3,3,5,3,3,5,4,3,3,5,3,4,1,3,2,4,5,5,2,3,3,1,3,2,2,3,2,1,4,1,1,4,2,2,3,3,2,5,3,1,5,1,5,1,5,4,3,3,2,2,3,2,1,5,2,2,2,2,2,3,5,4,1,4,1,1,1,1,2,2,2,3,4,1,5,2,1,3,1,2,5,4,2,5,2,3,4,2,3,4,3,2,4,5,4,4,4,5,1,3,3,5,1,3,2,2,1,3,5,5,1,2,5,1,5,3,5,5,5,3,2,3,3,5,3,2,5,4,2,1,1,2,3,5,2,1,4,5,3,1,4,4,5,3,5,4,4,4,4,2,5,5,4,5,3,4,1,2,3,1,5,4,4,3,4,3,3,3,5,3,5,2,2,1,3,3,4,1,4,3,4,4,4,1,1,5,1,2,5,3,1,5,2,4,2,4,1,4,3,3,5,4,3,3,1,4,5,1,3,2,1,4,5,5,4,3,3,2,5,2,3,3,2,5,1,3,4,4,4,1,4,2,1,2,2,1,4,3,2,1,4,5,2,4,3,3,4,2,1,2,2,3,3,3,2,2,1,4,4,5,3,1,3,5,5,2,1,3,4,2,3,5,4,2,2,5,4,1,1,5,4,5,4,5,2,1,1,5,5,1,4,5,4,3,2,1,1,5,5,3,5,5,4,4,3,1,5,5,1,1,2,5,2,2,2,5,1,4,3,3,2,2,3,3,3,2,5,2,3,5,1,3,3,2,3,3,4,1,1,1,4,3,3,2,1,5,3,1,5,5,3,4,2,2,5,3,2,3,5,5,2,4,5,2,2,3,2,3,4,2,5,3,3,3,1,2,1,3,1,4,4,4,4,3,3,3,5,5,2,5,2,2,3,5,4,3,2,5,1,4,4,2,4,1,1,5,3,2,3,4,5,1,2,4,5,3,5,4,1,3,4,3,5,4,4,2,3,4,2,1,3,5,2,4,3,1,4,1,4,4,3,2,2,5,1,4,3,4,5,1,1,5,1,3,3,4,3,2,3,2,3,5,3,1,4,2,2,5,4,2,2,3,2,5,5,5,5,4,3,4,3,1,2,4,3,2,4,4,1,4,3,3,2,3,5,5,1,5,1,4,1,1,1,3,5,1,4,5,5,3,3,4,5,4,5,5,1,5,1,5,2,3,4,3,1,1,2,4,3,1,3,1,4,1,4,1,3,3,4,4,2,4,3,1,3,3,3,5,3,1,3,2,4,3,3,4,2,1,2,4,4,5,1,3,1,5,5,1,4,2,2,1,3,1,1,1,4,5,2,5,1,4,3,5,4,4,1,3,1,5,4,1,4,5,4,2,1,3,2,4,4,5,1,2,1,4,4,1,4,3,5,3,4,1,1,2,5,5,2,1,3,4,1,5,3,2,2,4,3,1,1,2,4,3,4,3,4,1,1,4,2,5,2,1,4,5,4,5,5,4,5,5,5,2,5,1,4,4,2,3,1,5,3,4,2,5,1,4,1,2,5,1,2,4,1,2,3,2,5,2,1,1,5,3,1,1,5,4,1,5,4,5,3,3,3,5,3,3,1,1,4,5,1,4,2,5,3,2,2,2,2,4,3,2,4,3,3,3,3,2,4,1,3,2,3,1,2,3,3,1,3,3,2,5,2,5,3,2,5,3,2,5,1,2,1,1,1,5,3,1,4,2,5,5,5,5,1,1,4,5,5,1,5,5,1,4,5,2,2,3,3,4,1,4,5,1,4,5,4,3,5,5,3,2,5,5,1,5,5,5,3,1,1,5,2,1,5,3,3,1,3,2,2,2,2,5,1,4,5,2,4,3,3,4,5,5,4,2,1,3,4,3,2,1,2,2,5,5,5,1,2,4,2,2,5,2,2,2,5,1,5,3,5,2,2,2,3,4,3,1,3,4,1,3,3,5,4,2,1,1,4,4,5,1,1,3,2,2,5,1,2,3,2,2,3,1,4,2,2,4,5,2,2,2,5,4,3,5,2,3,3,5,3,5,5,5,3,1,5,3,5,1,3,4,2,5,5,2,4,5,3,4,3,5,2,2,2,5,3,4,5,1,4,4,4,4,4,3,5,1,5,2,2,5,3,4,1,4,1,2,3,5,4,2,3,3,2,3,1,4,2,5,2,1,1,2,5,2,3,2,5,4,5,2,5,4,5,5,1,1,4,1,5,2,1,3,3,5,4,5,4,5,5,3,1,3,5,1,5,1,2,2,1,4,5,3,5,5,1,2,3,3,4,3,5,1,4,3,5,5,3,1,4,3,2,3,3,3,4,2,3,4,5,1,4,1,1,1,4,2,1,1,5,4,3,1,3,5,5,2,2,3,5,3,2,4,5,4,1,5,2,4,3,4,1,4,1,4,5,1,1,5,4,5,4,5,4,4,4,5,1,3,4,2,3,1,3,4,3,5,3,5,2,2,1,3,5,2,2,1,2,3,3,5,1,5,1,1,5,2,1,1,2,3,4,3,1,2,4,3,1,1,3,4,2,3,4,2,5,5,2,1,1,5,3,1,1,4,2,1,4,1,3,2,3,2,3,5,5,3,1,4,1,5,2,5,5,3,3,1,3,5,1,2,5,2,3,5,1,4,4,3,3,2,2,4,4,4,4,5,5,2,4,4,4,5,1,3,3,1,1,4,5,3,1,4,4,4,2,2,3,5,4,5,4,5,5,5,3,5,2,1,3,5,3,1,1,5,1,3,5,5,5,5,1,1,5,3,5,5,4,2,2,1,3,2,2,3,4,5,4,4,4,1,3,5,4,1,1,3,5,3,3,1,1,4,2,4,1,5,2,1,3,4,4,5,5,2,1,4,2,2,5,1,3,2,5,3,2,5,2,5,1,1,3,4,2,2,4,2,5,1,4,4,2,1,3,1,5,4,3,5,2,3,1,5,3,1,1,2,4,1,2,3,1,1,2,4,4,4,4,2,1,1,4,5,1,2,1,5,3,5,2,3,5,5,4,4,1,3,3,5,2,5,3,5,4,3,3,3,4,4,3,3,4,4,4,3,2,1,1,3,5,1,3,2,2,4,4,3,5,2,5,3,5,5,1,2,3,1,2,2,4,1,4,4,1,4,4,4,3,4,4,3,2,5,3,1,5,5,3,3,2,2,1,5,1,5,1,4,4,1,3,4,2,1,2,4,2,4,5,2,1,5,1,4,3,5,3,5,4,5,4,4,4,4,1,3,1,5,2,1,2,3,2,3,2,5,4,3,3,2,2,1,5,4,1,3,3,3,3,4,3,2,5,2,5,2,3,3,3,1,2,5,5,2,3,5,3,2,5,2,2,2,5,5,2,3,1,3,3,3,3,5,4,5,1,2,4,4,4,4,4,1,4,3,2,1,4,1,1,5,2,3,2,3,5,1,2,1,2,3,4,3,1,1,2,1,3,4,4,2,1,1,5,3,5,4,2,3,5,2,3,3,5,5,4,2,5,1,3,2,1,3,1,5,4,5,3,1,3,4,2,3,1,4,3,2,2,1,2,1,4,2,3,4,5,1,4,1,2,5,2,2,4,2,2,5,2,5,4,4,1,1,4,3,2,3,1,1,4,2,2,1,3,4,3,4,2,1,2,1,3,1,3,1,5,1,5,4,1,5,4,1,4,2,4,2,3,2,4,4,4,2,5,2,5,5,5,4,5,3,5,5,1,1,4,1,4,5,5,3,2,2,1,1,2,2,1,4,5,3,1,2,1,4,2,5,3,2,1,3,2,2,1,2,4,3,4,4,1,5,4,1,3,3,5,4,3,3,5,1,5,2,5,2,4,5,5,4,1,3,3,1,3,3,1,1,4,2,1,2,2,1,5,3,2,2,4,2,1,3,3,2,4,2,5,5,3,1,1,1,5,5,1,2,5,3,4,2,3,5,1,2,2,3,2,1,1,4,5,4,5,5,1,5,4,2,2,1,1,3,1,1,5,2,5,3,4,4,1,3,1,4,3,2,1,2,1,4,1,3,4,5,3,2,1,4,4,1,1,3,2,2,1,5,1,4,1,1,1,2,2,5,5,5,1,1,5,3,2,5,2,1,3,3,5,4,3,1,2,3,3,3,5,1,5,5,4,5,5,5,4,1,3,3,1,4,3,3,2,3,4,3,2,4,1,2,5,1,4,3,1,3,1,4,4,5,4,4,1,1,5,2,2,4,5,2,2,5,3,2,5,5,2,2,2,3,2,5,4,2,5,5,3,2,4,4,1,5,4,4,1,1,3,2,5,5,3,1,5,3,2,4,3,3,4,3,2,5,2,2,1,1,1,4,3,3,1,1,4,4,2,4,1,1,5,1,2,3,2,3,2,1,3,4,5,2,1,4,2,4,3,2,2,4,1,3,4,1,3,4,5,2,4,3,5,1,3,1,2,5,5,1,1,3,2,4,1,4,5,1,4,5,1,1,5,1,1,1,3,1,4,1,2,3,5,3,3,4,3,4,2,2,2,3,3,1,1,4,1,5,5,2,3,1,5,4,2,4,2,3,4,1,1,4,3,3,4,5,1,1,3,5,5,1,2,1,3,2,3,3,3,2,2,5,5,1,3,1,5,2,2,5,5,2,5,5,4,2,5,5,3,4,4,4,5,2,2,2,4,4,5,3,4,2,4,3,1,4,5,2,5,1,1,3,4,3,1,5,3,1,4,4,3,2,4,4,3,3,4,4,2,5,1,4,4,1,2,1,5,3,5,3,5,1,5,2,3,1,5,4,5,2,4,4,4,5,3,1,4,3,4,4,3,1,5,3,3,1,3,1,5,5,4,4,2,2,1,4,3,3,4,2,1,5,2,2,5,2,5,2,3,5,1,5,2,1,3,3,5,2,1,3,1,5,4,4,2,3,3,5,5,1,3,3,5,1,2,5,4,3,3,2,5,5,3,3,3,1,5,5,1,1,4,2,5,3,5,3,3,1,2,2,3,1,4,4,1,2,3,4,2,2,1,2,3,4,5,5,3,3,4,2,1,4,3,1,4,5,1,1,5,3,4,5,2,1,3,5,5,4,5,4,1,4,3,5,2,2,4,5,5,1,3,4,1,3,2,1,2,2,3,2,5,5,2,4,4,1,5,2,3,1,1,1,4,2,3,2,5,4,5,1,2,5,1,3,3,1,3,4,5,4,1,1,3,1,2,4,2,5,3,4,1,4,3,2,1,4,2,2,1,1,4,3,2,4,2,2,2,2,1,3,5,5,1,5,2,2,5,5,5,2,5,4,3,3,5,3,3,2,4,5,5,2,1,5,4,3,3,5,4,4,2,2,4,3,4,4,5,1,5,1,1,4,4,1,3,1,4,4,4,1,3,2,4,5,3,4,2,4,1,1,2,1,3,2,1,2,1,2,5,2,2,1,2,4,4,5,1,2,4,3,4,3,5,4,2,5,3,3,4,1,3,4,5,5,5,2,4,4,4,2,3,1,2,1,5,2,3,5,5,3,5,2,1,2,2,2,5,2,3,4,3,2,5,3,4,3,3,2,2,2,2,1,5,1,2,4,5,4,5,1,3,4,3,5,4,3,4,1,2,4,4,4,3,5,2,1,4,5,1,1,2,3,2,5,1,2,4,3,3,2,5,2,2,5,5,1,3,4,1,4,2,1,5,1,1,5,5,5,2,3,1,1,3,4,1,4,5,2,5,1,3,5,4,1,1,4,2,5,3,1,3,5,2,2,3,2,5,3,3,4,5,1,2,4,3,1,5,3,4,1,4,5,1,4,5,5,1,5,1,4,4,4,5,4,4,5,1,2,1,1,5,1,3,5,4,1,4,4,3,3,2,3,4,4,3,5,5,5,1,1,1,1,2,3,3,3,5,1,1,3,4,4,3,2,4,1,1,2,2,3,2,1,3,5,2,3,1,1,1,2,2,1,1,5,1,2,4,1,3,1,2,1,4,1,4,3,5,1,5,3,5,1,5,1,4,1,3,1,1,3,2,1,2,2,4,5,4,2,5,4,3,5,5,1,3,1,1,2,5,3,1,5,1,1,1,2,3,4,4,3,1,2,2,4,5,4,4,2,3,5,2,2,5,3,2,5,3,4,2,5,4,1,5,3,1,4,4,5,5,5,4,3,5,5,4,2,2,2,5,3,4,5,4,1,2,2,4,1,3,1,3,4,3,1,2,1,2,5,4,2,3,2,4,3,2,4,3,3,3,4,5,1,2,5,1,4,5,4,3,2,3,1,1,4,4,5,3,2,1,4,3,2,5,4,2,1,2,5,5,4,3,4,5,1,5,2,1,4,4,4,5,5,3,2,3,5,5,2,2,1,4,2,4,1,4,3,2,3,2,3,5,1,2,4,3,1,1,2,4,5,3,3,1,3,4,1,4,5,2,3,3,2,3,4,1,2,4,2,4,4,4,4,5,1,5,5,1,4,1,2,3,1,1,1,1,5,1,1,1,5,5,4,1,1,5,2,1,1,3,5,1,1,3,2,5,2,2,2,1,2,3,5,2,2,4,4,5,3,1,3,2,3,4,2,2,1,5,4,5,1,2,1,3,3,5,1,3,3,5,1,4,4,5,3,4,2,4,1,4,5,5,4,1,2,3,4,3,3,2,3,3,5,5,1,3,2,1,2,4,1,2,2,1,3,2,2,1,4,3,5,3,5,2,1,4,1,3,3,5,2,2,2,3,5,3,1,4,4,2,1,4,1,1,4,4,2,3,3,1,3,3,5,1,5,1,5,3,2,4,5,1,5,3,4,3,4,3,3,3,5,3,3,5,5,4,2,4,5,4,4,4,3,5,3,4,5,2,5,1,4,2,1,3,5,3,5,4,2,5,3,4,5,2,4,1,4,1,2,4,5,5,3,3,1,3,2,1,4,2,5,3,4,1,2,1,1,1,5,1,3,1,1,3,1,1,3,5,3,2,5,5,3,2,5,5,2,1,4,1,5,1,3,1,4,4,3,3,3,2,3,4,2,3,4,4,2,4,3,3,1,5,4,4,3,2,4,5,5,5,4,1,2,4,5,1,3,1,1,5,3,3,1,3,4,2,3,1,4,3,3,3,1,4,4,5,2,3,2,5,2,1,2,3,1,4,1,3,4,1,2,5,2,5,5,2,5,2,3,4,1,4,1,2,3,3,1,1,5,1,4,1,5,2,3,2,4,2,2,4,5,2,4,1,4,1,1,5,2,3,5,1,3,3,3,2,4,3,1,4,1,2,4,1,4,4,2,1,2,5,4,1,5,3,4,2,1,3,5,5,5,3,4,3,1,4,2,4,2,3,5,2,2,3,4,4,1,1,2,4,4,4,1,3,3,3,1,5,3,3,2,1,5,1,4,3,2,1,5,1,4,4,4,5,3,1,1,2,1,3,4,2,1,2,1,5,1,5,4,1,2,4,1,1,5,2,1,3,3,1,5,4,5,2,1,1,5,1,2,3,2,3,4,4,3,4,2,4,5,5,4,5,3,3,1,2,3,1,2,3,2,1,5,5,5,3,3,4,4,3,1,4,2,3,4,2,3,1,5,1,3,2,3,4,5,1,1,5,1,4,2,4,1,2,1,5,1,2,3,2,5,1,2,3,3,2,3,5,2,2,5,1,5,3,2,5,5,5,2,1,1,1,2,4,5,3,5,1,4,5,3,2,5,2,4,5,1,2,4,3,5,3,4,1,3,3,4,2,5,2,3,1,5,2,2,5,1,2,4,2,4,4,1,1,5,1,3,4,3,5,5,4,2,3,5,1,1,1,4,5,1,2,3,2,2,3,1,4,4,4,1,1,4,1,1,2,3,5,1,5,3,3,3,5,4,5,5,4,1,2,5,1,4,4,1,4,4,3,2,5,4,2,5,2,4,5,4,2,1,3,2,1,2,2,1,2,2,4,2,1,4,5,5,3,2,1,3,2,2,2,4,1,5,2,2,2,1,3,1,4,4,5,2,5,5,1,5,1,1,3,4,5,1,4,3,2,2,5,5,4,1,4,5,2,1,4,4,2,5,1,4,1,4,5,5,5,1,1,4,2,5,2,2,4,3,2,4,2,1,1,5,2,1,3,5,1,4,3,2,2,5,1,5,3,5,3,5,1,1,3,5,1,4,3,1,5,3,1,3,2,1,1,4,1,4,1,4,3,1,2,1,3,3,5,1,1,5,5,5,1,1,2,4,2,2,5,4,2,4,1,5,5,4,1,1,1,5,5,2,1,1,2,3,1,3,5,4,3,2,3,3,4,4,5,4,2,3,1,5,4,2,5,4,4,5,4,5,5,2,2,5,3,5,4,4,1,5,5,5,2,5,2,2,3,3,3,1,3,2,1,1,5,1,5,4,1,5,3,5,2,1,3,3,4,4,1,5,2,4,4,5,5,1,2,3,4,1,3,4,2,5,4,2,1,5,5,2,4,2,5,2,5,1,5,3,5,1,5,5,4,5,1,2,4,5,2,2,1,4,2,5,1,5,1,5,4,4,5,2,5,5,5,1,2,2,3,5,2,4,2,3,3,1,1,3,4,3,1,5,2,2,5,5,2,4,2,5,1,2,3,4,4,4,3,3,3,2,3,4,5,4,5,1,3,1,5,5,2,5,3,4,1,1,1,4,1,3,1,1,4,1,3,1,5,1,5,1,4,5,4,5,2,1,4,5,1,3,1,3,2,2,1,1,1,2,3,5,1,3,4,2,3,3,4,4,4,2,2,5,1,3,2,4,4,2,1,5,2,3,2,1,3,1,3,4,2,2,5,1,2,4,4,3,1,4,4,5,1,3,4,5,5,2,4,2,5,1,5,2,4,4,5,3,5,5,2,3,2,2,3,4,1,1,3,5,2,1,1,5,5,4,3,5,4,4,2,5,4,1,4,2,2,5,1,3,2,4,3,2,4,1,2,1,2,2,3,4,1,3,2,4,5,1,4,3,2,5,1,3,2,3,5,1,3,2,4,3,3,1,3,4,2,4,3,5,5,3,4,2,5,1,2,4,1,4,1,5,3,3,2,3,3,2,2,2,1,1,1,4,4,2,4,5,5,2,2,1,4,3,1,4,3,1,3,5,3,3,3,2,3,5,5,4,5,2,1,3,1,3,4,3,1,1,5,1,5,2,3,4,3,5,1,2,4,4,4,1,3,4,3,3,1,1,4,4,5,3,2,4,1,2,1,2,4,5,2,2,4,5,1,4,3,4,2,3,5,2,1,1,4,1,2,5,3,1,2,1,2,2,3,5,5,2,1,5,2,1,5,3,5,5,1,1,3,1,2,2,4,5,4,5,3,1,1,3,5,3,1,4,3,4,2,4,4,1,2,4,3,2,4,4,2,5,5,2,1,4,5,4,2,1,2,4,1,4,4,2,1,2,3,1,3,1,5,2,3,2,1,2,3,5,3,5,4,3,1,3,5,3,3,1,5,5,4,4,5,1,5,1,2,3,1,5,5,5,5,2,2,3,5,3,1,2,4,3,1,1,4,4,2,4,3,5,1,2,2,5,5,4,5,2,3,4,1,4,1,4,3,4,1,3,5,4,5,1,1,1,5,1,2,3,2,5,5,4,2,3,3,3,3,3,5,5,5,4,3,1,4,2,5,2,1,2,3,4,4,2,5,2,2,5,2,1,3,1,3,2,3,5,3,1,1,3,3,2,1,2,4,5,5,4,2,5,3,3,1,1,4,3,1,4,4,3,1,3,5,3,5,5,4,1,5,4,5,1,4,4,1,1,2,4,3,4,2,5,2,1,4,2,3,3,3,2,5,2,4,2,5,1,3,4,5,4,5,3,4,3,5,3,5,3,3,1,3,4,2,1,4,4,2,2,4,5,4,3,4,5,5,2,4,5,4,3,4,5,2,2,3,1,4,4,1,1,4,3,2,5,2,1,2,4,5,4,2,1,1,3,3,2,3,2,1,5,2,3,1,3,5,1,4,4,4,3,2,2,1,5,5,1,1,5,5,5,2,3,1,5,3,4,1,5,5,4,5,4,5,4,5,2,1,2,4,4,2,1,4,1,4,5,4,3,1,1,4,5,3,1,1,2,4,2,4,4,2,1,4,2,1,3,1,3,2,2,1,2,1,4,2,4,3,5,5,4,3,4,4,4,1,3,1,2,4,3,4,3,3,5,2,4,4,4,4,3,3,1,5,4,1,3,1,3,4,1,3,1,1,4,2,5,2,2,4,3,1,2,3,1,3,5,1,2,1,1,3,2,2,2,1,1,2,4,4,3,5,2,1,2,3,3,4,4,3,3,1,3,3,5,2,5,3,1,4,4,2,1,1,5,3,2,3,4,1,4,3,5,4,5,1,3,5,4,1,1,2,2,4,4,2,1,3,3,1,5,2,4,4,2,2,5,4,5,1,2,4,1,3,3,3,5,5,5,5,3,5,4,5,4,4,5,5,4,4,2,4,4,1,2,1,1,3,1,1,5,4,1,5,4,3,2,2,4,2,2,5,4,2,3,1,3,3,4,2,1,4,1,5,2,2,5,1,3,3,2,1,4,5,1,1,5,5,5,5,4,1,3,3,4,1,1,2,1,2,1,4,3,4,3,5,2,1,4,3,1,3,1,5,3,3,5,2,1,2,3,3,1,5,5,5,3,3,1,4,4,3,3,1,5,1,5,2,2,4,3,5,5,2,4,4,1,2,4,5,2,5,1,3,4,3,1,3,2,5,2,4,4,4,3,4,4,3,4,2,5,3,3,4,5,3,5,3,2,4,2,5,1,1,2,1,2,4,5,5,4,2,5,2,4,2,2,1,4,1,2,3,3,1,4,1,3,1,4,2,1,1,4,5,4,5,1,5,5,5,3,1,2,5,4,3,4,5,4,5,4,1,2,3,2,2,2,4,1,2,1,4,3,3,3,4,4,4,3,4,5,4,4,4,5,5,4,3,1,2,5,3,5,4,4,4,3,4,5,5,5,4,3,5,5,1,5,3,5,5,3,1,4,4,4,5,1,3,1,4,5,4,1,3,2,3,2,4,1,4,5,5,5,4,1,3,4,5,1,2,3,4,2,1,1,2,3,2,3,3,5,3,5,1,5,5,1,3,3,3,1,4,2,5,2,3,1,3,3,2,2,3,3,5,2,1,1,5,4,4,5,2,4,2,1,3,5,1,4,4,2,4,5,3,1,3,5,3,4,2,1,5,5,2,4,1,4,5,1,5,5,4,1,3,3,3,3,2,4,2,1,2,2,4,1,1,2,1,5,1,4,3,3,2,1,2,2,4,3,3,3,3,3,1,4,5,2,3,5,1,5,4,1,4,1,1,3,2,3,5,5,2,5,3,4,3,4,5,2,3,1,2,4,2,3,3,4,3,5,3,2,3,3,2,1,2,3,1,4,3,3,4,1,5,4,4,4,3,3,2,1,2,4,3,3,4,1,1,5,1,1,4,4,3,4,2,2,2,5,2,1,4,4,3,5,3,3,1,1,5,1,1,5,5,1,5,5,5,1,3,4,2,2,4,2,5,3,2,2,2,4,4,4,1,4,4,4,3,5,3,2,4,3,1,1,3,4,3,2,3,1,1,5,3,2,2,4,2,1,5,5,5,3,2,1,1,5,1,4,1,3,1,1,2,5,5,1,4,5,1,5,5,1,3,2,2,3,4,3,2,1,4,4,5,2,1,3,3,4,4,3,4,3,3,3,5,2,3,5,1,5,2,3,1,5,4,1,5,1,2,4,4,5,2,2,5,3,4,3,5,2,1,5,4,3,5,3,4,4,4,2,3,4,4,3,4,3,2,1,2,5,2,2,5,3,4,4,4,4,4,3,1,2,5,4,4,4,2,4,5,2,5,1,4,5,1,5,5,2,3,5,1,5,5,1,2,2,1,5,4,5,3,5,3,4,4,3,1,2,3,4,3,3,2,5,4,5,3,4,3,3,4,3,1,4,3,3,4,1,2,4,5,4,1,2,1,1,5,5,3,3,3,5,2,3,2,1,5,1,1,1,2,2,1,1,3,3,1,2,5,5,3,4,2,1,2,3,1,3,2,3,5,1,3,5,2,4,4,2,1,1,3,4,3,2,2,5,2,5,3,1,2,1,3,5,1,1,3,5,2,4,3,1,2,4,1,4,5,1,5,5,3,1,5,1,2,2,3,4,3,4,1,5,5,1,3,5,3,5,1,1,5,2,1,4,5,1,4,3,5,4,4,5,2,4,4,3,3,5,4,5,2,3,3,1,5,2,5,4,5,3,5,1,2,4,2,3,1,5,5,3,5,5,4,4,2,3,1,1,3,5,4,4,3,4,5,5,5,2,4,2,5,4,1,4,4,2,2,1,1,4,4,5,5,2,1,2,1,1,2,4,1,1,3,5,2,1,5,5,4,1,3,5,2,4,1,1,2,1,4,1,3,3,3,3,5,2,5,1,1,4,3,1,5,2,2,2,5,5,4,1,3,2,3,4,3,5,4,3,3,4,4,4,2,4,1,4,5,5,1,2,5,1,2,5,2,2,2,3,2,4,1,5,2,4,5,1,4,2,4,3,3,3,2,4,5,4,4,4,2,1,4,5,3,2,4,1,3,1,4,2,5,5,2,3,1,2,5,1,4,2,5,1,2,1,1,5,3,4,1,1,3,5,3,2,4,5,2,2,3,5,3,5,1,4,1,4,2,2,2,5,4,3,3,2,1,2,4,1,4,5,3,1,5,1,1,2,2,4,2,2,3,2,4,3,3,2,2,1,3,2,5,1,2,5,2,3,3,3,2,2,5,2,2,1,1,3,5,3,3,4,5,3,4,5,5,5,5,4,2,3,4,4,1,1,5,4,2,3,4,4,1,1,5,3,2,2,5,3,1,3,2,2,4,1,1,2,5,5,2,3,5,3,4,4,2,3,4,3,2,3,3,1,1,3,5,5,4,3,4,1,2,1,3,1,3,4,3,3,4,2,5,1,3,3,5,5,3,2,5,5,3,2,4,5,4,2,1,5,3,4,1,4,4,2,2,5,5,3,3,5,5,3,1,5,3,2,4,1,3,1,2,5,3,1,5,5,4,1,3,4,1,1,2,4,1,3,4,1,2,4,4,1,1,3,3,5,3,4,5,4,2,1,1,3,1,3,4,4,5,4,4,3,4,3,4,2,4,4,2,1,1,5,1,1,5,5,4,1,3,3,5,1,4,4,1,3,3,4,1,2,1,2,2,5,3,5,3,1,5,2,3,1,5,5,4,4,1,3,3,5,3,1,4,3,5,2,1,1,2,4,2,3,3,2,5,3,5,2,5,1,4,3,1,3,2,3,1,2,2,2,1,1,4,4,5,4,4,2,3,2,2,2,2,1,2,5,5,1,5,4,1,5,1,5,5,3,1,5,3,2,1,2,5,3,5,3,5,5,4,3,3,2,1,5,5,1,3,2,1,4,5,4,5,3,3,2,4,2,3,2,2,3,1,3,1,3,2,4,5,5,2,1,1,4,2,3,4,2,4,2,2,5,5,2,4,4,1,5,5,1,5,1,3,5,4,1,2,5,1,3,5,3,1,3,1,1,5,2,4,5,1,1,2,5,4,5,4,5,3,1,4,3,2,5,1,1,3,2,3,5,3,1,1,5,3,5,3,4,3,1,2,3,1,3,1,4,2,1,1,2,2,2,5,2,3,2,1,2,4,3,4,2,4,5,1,3,3,1,2,3,5,2,4,1,3,5,4,5,4,2,1,3,4,4,1,4,4,4,5,3,2,4,2,3,4,4,4,5,1,3,1,4,4,1,5,2,2,5,5,1,1,2,4,3,5,4,3,4,1,5,2,5,1,5,5,3,1,1,4,4,2,2,2,2,4,3,3,3,5,4,5,1,2,4,4,2,3,5,3,5,5,5,2,2,2,2,1,4,2,3,1,3,1,2,1,3,4,5,5,3,1,1,5,4,2,3,1,4,4,3,2,1,1,2,4,5,5,2,4,5,3,4,5,5,3,3,2,1,5,1,2,2,5,1,1,2,5,2,4,4,3,1,3,1,5,5,5,4,4,1,2,4,4,2,5,5,3,3,2,5,3,3,3,3,4,5,2,5,1,3,1,1,2,3,5,2,3,1,2,2,4,1,1,3,5,1,1,3,4,5,4,5,5,3,3,4,3,1,1,2,3,1,2,3,1,5,4,5,1,1,1,5,5,3,3,3,1,4,3,3,3,2,3,4,5,4,2,5,5,5,3,2,3,3,5,1,4,3,4,2,1,4,4,5,2,4,3,5,1,3,1,5,4,1,1,1,4,1,4,3,2,4,1,3,1,2,3,5,3,2,1,1,3,5,1,1,1,2,2,1,5,4,4,4,1,1,3,1,2,4,2,5,4,3,2,5,1,2,3,5,3,2,5,5,2,1,5,5,2,4,4,3,5,3,2,1,1,4,2,1,1,2,5,5,3,3,1,4,1,1,5,1,1,2,2,5,2,4,4,2,1,2,3,3,3,2,3,1,2,4,3,5,4,3,3,4,5,3,2,2,4,1,4,5,4,2,4,2,2,4,3,3,5,5,2,4,3,4,1,1,3,1,5,1,2,1,4,5,4,3,5,2,1,3,4,5,5,4,2,3,2,3,5,2,5,3,1,2,4,5,2,4,3,4,4,1,4,3,2,5,5,2,5,1,1,2,1,1,2,4,5,2,3,2,2,1,2,5,2,1,4,2,1,3,5,5,2,4,4,2,4,5,3,3,4,3,3,3,2,1,5,1,4,4,1,4,3,1,1,5,4,4,3,5,5,4,5,1,2,5,4,3,1,2,3,3,3,3,2,4,4,5,1,4,1,1,5,5,3,5,5,1,5,1,4,2,5,1,1,1,2,2,2,1,5,5,1,2,5,4,1,5,4,1,5,4,4,4,3,3,2,2,4,3,5,1,1,2,1,3,5,4,5,1,5,5,3,5,4,2,4,2,1,4,3,2,3,3,2,3,5,4,4,5,2,2,5,4,3,1,4,4,4,3,5,4,3,2,2,1,2,4,2,2,5,1,5,4,2,4,2,4,1,2,4,5,3,3,1,2,2,2,1,2,4,5,3,2,1,1,3,3,1,2,4,3,3,3,3,2,2,4,3,5,1,5,2,2,1,1,1,1,4,1,1,3,4,5,2,1,2,1,2,5,1,4,2,1,3,2,1,3,3,3,4,1,1,3,5,1,2,1,2,5,3,3,2,5,3,4,5,2,1,3,2,5,3,1,5,3,5,3,2,2,2,4,4,1,4,2,2,1,3,3,1,5,3,3,1,5,3,2,5,3,3,2,4,2,5,3,3,3,2,4,3,1,2,4,2,5,1,2,4,3,2,2,2,1,2,2,2,1,5,2,3,4,2,3,3,3,3,5,3,1,1,5,5,1,3,2,1,2,1,5,2,3,2,5,1,3,3,1,3,2,1,1,3,1,2,1,4,4,4,3,1,1,1,3,3,1,5,2,3,1,5,3,2,4,4,5,1,1,4,3,1,3,2,4,2,3,4,2,1,4,4,3,3,2,3,2,1,5,1,4,4,4,2,3,1,3,1,3,1,2,2,4,3,4,4,5,3,5,1,3,5,3,5,3,3,3,3,2,4,1,4,1,4,1,5,1,3,3,4,1,1,3,4,4,4,5,4,1,5,5,3,1,5,2,4,3,4,3,1,1,5,4,1,2,3,2,2,4,3,4,3,5,2,4,3,4,4,4,5,5,2,5,4,2,1,2,4,3,4,5,4,1,3,2,1,1,5,1,4,2,4,3,4,1,1,4,1,2,4,5,4,3,4,4,4,3,2,5,5,4,5,5,5,4,4,4,3,4,4,2,3,4,2,4,3,3,5,5,3,4,5,2,1,1,4,5,4,5,3,2,3,5,4,1,4,3,1,4,4,3,4,4,4,2,4,1,1,4,3,4,1,3,5,3,5,1,4,3,3,3,1,4,2,4,5,2,1,5,3,5,1,5,4,2,1,3,4,1,2,1,1,5,3,2,5,3,3,3,1,4,3,1,4,1,3,5,4,1,2,4,1,2,4,4,4,4,2,1,3,1,2,2,4,5,4,5,3,1,1,2,5,3,5,2,2,2,5,2,4,4,2,1,2,4,2,5,4,5,2,1,1,5,2,4,5,1,2,5,4,4,5,4,1,2,3,3,4,4,1,3,5,5,2,5,4,1,3,3,3,5,4,3,2,2,5,2,5,3,3,3,3,1,3,3,2,3,2,1,3,2,3,1,3,3,3,1,5,2,3,2,2,4,5,3,1,5,4,1,1,1,4,5,3,1,3,1,1,4,4,1,2,2,2,4,2,3,3,3,2,2,3,2,5,3,4,5,1,5,5,1,3,1,3,4,1,5,3,4,2,5,2,4,2,5,2,4,5,1,2,2,1,2,2,5,5,3,4,4,1,3,2,2,4,5,2,2,2,3,4,5,5,3,3,1,4,4,4,5,2,3,5,3,5,1,4,4,4,1,2,1,2,2,4,2,3,5,1,3,3,1,5,2,5,5,3,4,2,3,1,5,4,1,5,3,3,5,1,3,3,4,2,4,3,3,5,1,4,2,2,5,2,3,2,1,4,1,3,4,2,4,3,5,1,4,5,3,5,5,5,4,4,1,2,5,1,5,1,4,1,5,2,4,5,5,1,4,1,4,5,4,4,1,3,3,3,5,5,4,4,4,4,1,2,2,3,1,4,5,1,4,1,5,1,1,5,1,5,4,4,1,4,3,2,2,5,2,3,5,4,2,2,4,4,1,1,3,3,1,5,3,3,5,4,5,1,1,2,1,3,5,3,3,5,2,5,5,1,1,3,2,4,4,5,3,1,5,3,2,3,1,3,3,3,1,5,5,2,5,2,3,1,5,2,5,5,4,3,2,1,3,1,5,3,4,1,4,4,5,1,4,3,3,2,4,3,5,4,5,2,4,5,4,5,4,4,5,4,1,5,4,3,1,5,5,4,4,1,5,4,4,5,2,5,1,1,4,5,3,5,5,2,3,1,4,4,1,5,5,3,5,5,4,1,4,3,2,2,4,1,1,1,3,4,3,1,4,3,1,2,5,2,3,5,5,3,3,5,4,3,4,3,3,1,1,5,2,2,2,4,1,1,5,5,2,1,5,1,2,1,3,5,3,3,3,4,1,2,3,3,4,2,4,4,3,4,3,1,4,4,5,3,5,3,2,5,5,1,2,4,4,2,2,3,5,5,3,3,1,1,1,2,5,2,3,5,3,3,2,1,2,4,4,4,2,1,1,3,5,3,4,2,1,1,3,2,4,5,4,2,3,2,1,3,1,4,2,4,3,5,5,1,1,3,4,5,1,4,5,3,2,3,2,4,1,1,2,5,2,4,4,3,5,4,3,5,4,4,5,4,1,3,5,2,2,2,4,4,3,4,1,3,1,3,2,5,5,2,3,4,3,2,1,5,5,3,5,1,3,1,3,1,5,1,3,2,1,5,1,4,2,5,1,1,3,3,2,5,1,2,3,2,5,5,5,2,3,2,5,2,4,5,4,1,5,4,1,5,5,5,4,1,1,3,4,2,2,3,2,4,1,5,4,1,5,3,2,1,5,4,3,2,4,3,5,3,5,3,5,4,3,4,5,2,3,4,5,4,2,2,3,5,4,4,2,5,1,2,2,5,3,3,4,4,1,5,1,4,2,2,5,5,3,4,2,3,4,2,4,1,3,1,1,1,5,5,3,1,2,1,3,2,4,1,1,4,1,5,4,2,4,5,1,3,2,3,5,3,1,1,4,3,4,3,5,3,2,1,1,3,5,2,4,4,2,5,3,4,1,1,2,3,1,1,5,3,2,5,4,2,5,1,5,1,3,4,3,1,1,1,2,1,3,5,1,4,1,4,1,1,5,2,3,1,4,4,1,4,1,4,4,2,4,2,5,1,4,5,5,5,4,4,1,4,5,4,3,5,3,3,1,5,4,5,1,2,4,4,3,1,5,3,3,4,4,2,1,5,3,4,3,1,1,5,5,4,3,1,4,2,3,2,4,1,3,1,4,4,5,3,1,3,4,1,5,1,4,3,3,5,5,3,3,1,3,3,2,2,1,2,1,5,2,3,1,4,1,3,5,2,2,1,5,2,2,2,5,2,3,4,1,2,3,4,5,2,5,1,3,3,4,2,5,1,5,2,1,3,1,1,4,3,5,3,4,3,5,2,1,5,5,3,2,5,2,4,5,3,5,3,2,4,5,3,1,1,5,3,2,3,3,4,3,5,3,5,4,2,3,1,3,3,3,1,4,3,5,5,1,5,5,3,4,5,5,4,3,4,4,4,5,4,1,5,1,2,2,5,3,2,1,4,1,3,5,5,2,3,3,1,5,5,2,3,2,4,4,2,4,3,5,2,5,3,5,5,4,4,4,5,5,4,4,1,3,4,4,1,3,4,3,5,2,3,2,4,4,5,1,1,1,4,5,2,3,3,4,3,2,1,1,2,1,5,3,3,3,4,5,1,1,3,4,5,1,3,4,3,1,5,5,5,1,1,1,5,3,1,2,4,4,1,4,2,5,4,3,3,5,1,4,2,1,2,3,2,4,5,5,4,3,3,1,2,5,1,3,2,2,4,2,3,5,1,5,5,5,5,3,4,1,3,3,4,4,4,5,1,2,4,3,3,1,2,2,3,5,4,4,4,5,3,3,1,2,1,2,3,4,2,4,1,5,2,1,4,2,1,1,4,4,3,4,4,4,4,4,2,4,2,3,1,2,1,4,1,5,5,2,2,5,2,5,5,3,5,4,2,4,1,1,1,5,3,2,4,3,3,3,4,2,5,4,5,4,3,5,4,5,4,2,4,1,1,1,3,3,1,3,2,5,5,3,4,5,1,5,5,1,3,2,2,3,5,2,3,3,1,5,5,2,5,4,2,5,1,2,5,1,1,3,1,1,4,5,1,1,1,3,3,1,2,1,3,4,1,1,5,3,3,2,1,4,1,3,4,5,4,5,4,1,2,4,4,1,1,4,4,4,1,1,2,2,5,5,1,5,4,2,5,1,5,3,4,4,4,2,5,1,1,2,5,4,2,5,5,4,3,4,5,4,4,3,5,2,5,4,1,1,2,4,4,3,1,2,4,4,3,1,1,2,5,4,2,5,2,5,5,2,3,2,2,4,3,4,4,5,3,2,4,4,3,5,2,5,4,4,2,4,5,4,1,2,4,3,3,3,3,3,4,5,4,4,4,2,3,2,4,1,5,1,2,1,2,5,3,5,1,2,2,4,3,4,4,5,1,3,1,4,5,5,4,4,3,5,3,1,4,3,5,5,3,3,2,5,5,2,2,2,1,3,3,3,5,2,1,2,5,4,1,1,1,4,2,3,2,3,5,3,2,4,5,1,3,3,5,1,2,2,3,3,5,2,2,4,2,3,1,5,5,4,1,4,2,5,4,4,5,3,3,1,5,4,5,5,2,4,1,4,3,5,4,1,5,5,3,2,5,2,3,4,5,2,1,5,1,4,3,4,2,2,3,3,5,4,2,2,4,4,5,2,1,5,4,2,1,5,1,2,1,4,3,5,1,4,1,2,4,3,3,5,1,1,1,4,3,4,2,1,3,3,4,5,2,1,4,5,4,2,1,2,5,4,3,2,1,2,4,4,3,4,3,3,4,5,3,2,1,1,1,3,4,5,4,3,5,5,5,3,2,2,4,5,4,1,5,2,1,5,5,3,3,5,5,3,1,1,5,1,1,4,3,2,4,2,1,1,1,2,1,3,4,4,1,2,4,4,5,4,1,5,3,5,2,4,3,4,3,4,1,3,2,3,1,5,5,5,2,3,3,4,1,2,2,5,5,1,4,3,2,1,1,1,2,3,3,2,1,5,1,3,5,3,5,2,4,3,3,4,4,5,2,4,2,1,2,4,4,3,3,3,2,1,3,4,3,3,3,2,5,3,3,4,2,2,2,2,1,1,5,5,5,3,5,5,1,2,5,1,3,1,2,4,4,1,1,4,4,4,3,4,4,2,3,1,3,4,3,4,2,5,4,5,4,1,2,4,3,5,5,2,1,1,1,1,4,2,2,3,4,1,2,5,2,5,1,2,4,1,2,3,1,3,1,3,4,4,1,1,1,2,3,2,5,4,3,4,5,2,4,1,3,2,4,4,5,3,2,2,5,2,5,4,5,3,4,4,5,2,2,1,1,2,2,5,3,5,4,5,4,2,3,1,3,4,4,2,1,3,5,2,5,2,4,3,1,3,2,3,4,3,3,1,2,1,4,5,1,1,4,2,4,1,1,3,5,2,5,2,1,1,3,2,2,4,2,4,4,5,3,1,2,4,4,4,1,3,2,1,5,2,3,5,3,5,2,5,5,2,2,5,3,4,1,3,2,2,5,2,4,4,3,2,3,3,2,3,4,1,3,1,3,5,2,5,2,4,1,4,2,2,4,2,1,1,4,3,1,4,1,1,1,4,1,3,2,5,3,5,4,1,3,5,3,1,5,2,4,2,1,2,2,4,1,2,3,5,2,5,1,2,1,3,2,4,2,2,1,3,3,4,5,5,1,4,3,2,3,3,4,1,4,5,4,5,4,2,5,3,2,1,4,5,4,2,3,3,3,3,4,2,1,3,4,2,1,3,3,3,2,2,2,2,3,4,2,2,2,1,1,4,5,3,2,2,5,5,5,4,1,1,4,2,5,2,5,4,1,4,5,2,1,2,2,4,1,3,1,4,1,1,1,5,3,5,5,2,3,4,5,4,4,1,4,3,4,2,2,2,3,5,1,1,2,4,5,3,2,5,1,5,2,4,4,5,2,3,4,1,4,4,3,3,1,3,2,3,5,3,3,4,1,3,4,2,3,3,3,3,5,2,1,2,5,5,3,4,5,2,1,4,2,2,5,3,4,4,4,3,5,4,3,5,5,3,2,3,3,5,5,3,5,3,1,3,4,3,3,2,2,1,3,5,2,3,4,3,2,1,4,4,4,5,4,3,5,2,2,5,4,4,1,1,3,2,4,4,3,3,2,5,4,5,1,2,2,2,2,4,4,1,2,4,2,5,5,4,3,2,4,4,1,2,4,5,2,4,3,3,5,5,4,1,5,1,3,2,1,1,5,3,1,5,3,3,4,5,1,4,5,5,2,1,1,4,3,3,1,1,2,1,2,1,2,2,2,4,2,3,2,4,4,2,2,3,4,3,4,4,3,5,5,1,4,3,1,4,5,3,5,3,4,3,4,5,1,2,5,4,1,5,4,4,5,3,1,3,4,5,5,5,1,1,5,1,5,2,5,2,5,5,1,1,1,3,2,3,4,5,1,3,5,3,1,5,5,1,2,3,3,5,4,1,5,4,1,3,2,3,2,2,5,3,5,5,1,5,4,4,4,1,3,3,1,4,4,2,2,4,2,3,5,4,1,3,1,4,2,4,1,2,3,2,1,3,1,4,4,5,4,5,3,4,2,4,4,1,1,5,2,4,4,4,2,5,2,2,3,2,4,3,4,3,1,2,5,3,1,2,5,5,4,4,5,2,3,2,2,4,3,3,1,5,3,2,4,3,5,2,1,1,3,3,1,1,1,1,1,2,2,4,3,4,2,3,1,4,1,4,4,2,3,4,2,2,1,3,4,4,5,4,4,1,1,2,3,3,4,1,5,5,4,3,1,5,5,1,4,3,4,2,2,2,2,3,4,4,5,5,1,5,4,5,2,2,5,4,5,2,4,4,3,2,3,4,2,2,3,3,1,2,3,1,3,4,3,1,4,5,5,5,5,3,3,5,1,1,5,2,1,1,4,1,4,1,2,1,4,4,3,1,1,1,3,3,5,3,2,4,1,5,5,3,3,3,4,5,1,5,5,2,1,4,5,4,4,4,2,3,1,3,1,1,4,2,5,5,2,1,1,3,2,1,1,2,4,3,4,3,4,1,4,4,4,1,4,1,3,2,4,1,5,1,1,5,1,2,5,5,5,3,2,1,5,4,3,3,4,4,4,2,1,1,1,1,1,2,3,2,5,5,5,5,2,3,1,4,3,1,2,4,5,5,1,1,2,3,3,2,2,2,2,3,3,3,1,5,2,2,1,1,1,1,4,5,1,4,4,2,4,1,5,1,1,2,2,1,2,2,2,4,4,2,1,3,3,3,4,5,1,3,3,5,3,2,4,4,2,1,5,4,1,1,3,3,3,4,5,1,3,1,1,1,5,1,2,2,2,5,2,5,4,2,1,3,4,5,4,4,1,4,5,4,2,3,2,2,4,4,5,1,2,3,1,4,3,4,5,5,2,1,1,1,4,2,3,1,1,2,4,4,5,5,5,1,3,3,5,2,3,2,3,5,4,3,3,3,1,3,1,1,2,1,4,4,2,3,2,2,3,1,1,1,4,3,1,1,5,2,3,1,3,2,1,2,2,1,2,2,4,1,4,4,1,2,2,2,1,3,1,5,4,2,2,4,3,3,2,1,5,5,2,5,5,3,3,5,3,4,3,2,5,3,2,4,5,4,1,5,5,1,5,2,5,1,4,5,1,1,4,5,1,1,2,3,2,5,3,3,5,5,3,4,1,4,4,2,5,5,3,5,1,1,4,4,4,2,5,2,3,5,4,2,1,5,5,5,2,3,3,3,2,3,4,3,4,2,5,1,3,4,5,1,2,5,1,2,5,1,5,5,5,2,2,3,2,3,5,5,4,1,1,4,4,5,1,2,3,4,5,3,1,5,3,4,4,1,3,4,1,5,1,3,4,2,2,4,3,1,1,1,5,3,3,5,5,3,5,5,5,4,1,1,1,4,2,1,2,2,1,1,4,5,5,4,5,1,5,2,3,5,1,5,4,4,4,5,3,2,4,5,3,5,1,5,5,4,2,4,1,5,3,4,3,3,1,2,4,4,1,3,4,4,4,4,2,3,3,2,2,1,5,5,2,2,5,2,4,1,2,1,2,2,3,5,2,1,4,3,3,4,5,5,1,5,1,3,5,3,2,1,3,2,4,2,2,3,1,4,2,4,2,2,3,1,2,2,1,2,4,3,4,3,4,2,4,2,5,2,2,5,3,2,3,1,2,2,5,5,2,3,1,1,5,1,1,2,4,2,5,5,3,5,3,4,5,3,2,3,5,5,5,4,3,5,2,2,4,1,5,3,2,4,1,4,3,1,2,3,2,1,5,5,1,3,3,3,4,2,1,4,4,3,4,2,2,4,3,1,3,4,4,5,5,2,3,1,4,4,2,5,5,3,4,1,1,1,2,5,5,2,3,2,3,1,1,3,1,1,3,3,1,2,4,4,4,2,3,1,5,3,4,1,2,5,3,5,4,3,5,2,3,5,2,3,2,4,4,4,4,3,4,2,4,5,4,1,5,1,2,4,4,3,1,4,5,4,4,3,5,1,3,1,5,4,2,3,5,3,2,4,1,1,4,2,1,5,3,2,2,3,4,1,1,4,5,1,4,5,5,4,3,4,3,5,3,5,3,4,3,2,1,4,2,1,3,5,4,3,5,3,4,4,5,3,3,1,5,5,3,5,2,3,4,2,2,2,1,2,3,1,4,2,2,1,4,1,2,3,2,5,5,5,4,2,1,3,5,4,4,4,1,5,5,2,5,3,1,5,1,1,5,4,3,1,3,1,5,4,4,2,1,5,3,3,1,3,4,4,4,5,4,1,5,1,1,3,5,2,2,1,5,4,2,2,4,1,2,4,4,1,3,2,4,5,1,2,2,5,4,3,4,5,2,5,5,1,3,4,5,4,5,3,1,2,3,1,3,2,2,1,3,2,3,5,2,4,1,1,3,4,1,5,2,1,4,2,1,4,1,4,5,5,2,4,4,5,4,1,2,5,5,4,1,1,4,3,2,4,1,2,1,5,1,2,4,3,5,1,2,3,1,5,5,3,4,2,4,4,3,1,3,5,5,4,1,5,5,1,4,1,5,1,3,4,5,5,2,2,3,1,3,3,2,2,1,4,3,1,2,3,5,4,2,4,1,3,4,4,3,2,3,3,3,4,3,4,3,3,1,2,4,3,5,2,5,2,5,3,3,4,5,1,1,3,2,3,1,4,2,5,1,5,5,3,2,2,4,4,4,3,2,4,1,4,4,5,1,5,2,5,3,2,5,5,5,3,4,2,5,3,3,1,3,3,2,4,1,5,3,2,4,1,1,2,3,4,5,4,5,4,4,1,5,2,1,4,4,1,3,2,4,4,2,5,2,5,1,2,5,3,4,1,3,2,2,1,4,1,4,4,1,5,2,2,4,1,4,4,2,4,5,4,5,4,4,3,4,3,1,5,4,3,4,4,2,1,2,2,4,5,5,5,5,4,3,1,3,2,5,3,5,1,5,3,1,2,4,2,3,1,4,1,1,4,1,1,1,2,2,4,2,4,4,3,4,2,4,1,4,4,3,2,5,5,4,3,3,1,5,5,1,2,4,4,4,2,3,3,2,5,4,1,5,2,3,5,2,2,5,1,2,3,1,2,2,4,1,3,2,3,4,1,1,1,5,1,4,3,5,3,3,5,2,1,5,1,1,1,3,5,4,5,4,5,4,1,1,5,2,3,2,2,4,1,4,3,1,1,2,1,4,1,5,5,5,1,4,2,2,2,1,5,4,5,4,4,3,3,4,4,1,5,1,1,4,5,3,4,1,1,5,5,2,1,4,1,2,2,1,1,4,3,4,5,2,5,1,4,1,1,4,5,1,2,4,1,4,4,3,5,4,4,2,3,1,2,2,4,5,3,3,2,2,2,5,2,3,2,4,2,1,2,5,5,4,1,3,3,2,5,4,2,4,1,4,3,3,4,2,5,3,3,1,5,2,4,4,1,5,5,3,5,2,5,4,1,2,3,4,1,4,2,5,4,4,2,3,5,2,5,5,4,1,3,5,2,3,3,5,1,5,3,5,4,3,3,1,3,2,1,2,2,4,2,1,2,1,3,1,4,4,4,1,4,2,2,1,3,3,3,4,4,5,3,3,1,3,2,2,1,3,4,2,3,3,3,4,3,3,1,5,2,2,1,4,1,1,1,5,2,4,1,2,5,2,3,5,1,3,5,5,2,1,3,5,3,5,5,4,2,4,1,2,5,5,2,2,5,2,5,3,2,4,1,1,5,1,2,5,2,4,1,1,3,5,1,2,4,2,3,5,5,2,3,5,1,2,3,4,4,4,5,3,2,1,3,1,1,2,4,3,2,5,1,5,4,2,3,3,1,4,2,5,5,5,3,5,5,5,1,3,4,5,4,4,4,2,3,3,4,4,5,2,1,1,3,3,3,3,4,1,5,2,3,3,1,1,5,1,5,3,5,2,2,5,2,3,2,5,4,3,1,4,5,4,1,4,4,2,1,3,1,4,4,3,1,1,4,5,2,3,4,2,3,1,2,4,3,3,3,3,2,4,4,5,1,3,3,3,1,3,1,2,1,3,4,2,4,5,4,2,5,2,5,3,4,3,1,4,1,4,3,2,5,2,5,1,5,2,4,3,1,5,5,5,2,4,1,2,4,4,3,2,3,1,3,1,1,3,5,5,2,4,5,1,1,4,1,1,5,5,2,2,2,3,4,2,4,2,4,1,1,3,3,5,4,4,1,1,3,5,2,5,1,3,1,4,5,1,4,4,5,2,3,5,3,1,3,2,4,4,1,1,5,1,5,1,3,3,3,3,2,4,4,4,5,4,2,2,2,5,3,1,3,3,4,1,5,3,1,5,4,2,1,2,5,5,1,4,4,5,1,3,1,4,2,2,5,3,3,5,4,4,4,3,1,2,3,1,5,5,5,5,3,4,5,3,4,4,1,1,1,5,5,2,5,3,2,2,3,2,3,5,1,3,4,2,3,1,5,4,3,5,2,2,3,5,1,4,5,1,3,3,4,1,5,2,5,2,5,1,1,1,1,3,5,1,3,4,5,4,5,2,5,3,4,1,1,2,3,2,2,5,4,2,4,5,2,1,2,1,4,5,2,5,4,2,4,5,1,3,5,4,4,3,4,2,3,3,5,5,1,5,5,5,5,2,1,4,4,4,4,2,3,1,1,5,4,2,3,3,2,4,5,2,4,4,2,1,5,5,5,5,2,3,5,2,5,4,4,3,1,2,4,3,5,4,5,3,3,4,5,4,2,3,3,5,4,4,4,4,1,1,4,1,2,5,1,2,3,4,2,1,3,1,2,2,2,1,4,5,5,2,3,5,2,3,2,2,2,5,5,1,2,2,1,5,5,2,5,4,1,3,4,1,5,1,3,2,4,2,5,5,3,5,4,1,5,2,1,3,2,3,4,3,3,1,1,4,2,3,2,5,5,5,4,4,5,4,2,4,4,4,1,1,4,5,2,1,1,2,1,3,1,1,4,4,4,1,5,3,4,2,4,2,5,1,4,2,4,3,3,5,4,5,3,4,1,5,4,1,4,2,2,4,2,5,3,5,2,5,3,3,5,3,1,2,3,2,5,1,5,5,3,2,2,4,4,5,3,3,1,2,5,4,5,5,1,5,4,4,1,3,3,4,1,2,4,5,1,3,3,2,4,2,1,2,1,3,2,1,3,3,1,1,3,3,3,4,1,3,5,2,4,4,1,3,5,3,1,2,2,5,2,3,5,4,3,2,1,1,4,2,3,5,2,4,1,4,3,3,5,3,5,3,2,5,2,4,3,2,3,5,2,2,2,5,3,1,2,3,5,2,1,5,4,2,3,1,4,3,5,4,4,1,1,5,2,1,2,5,1,1,1,4,1,5,3,4,5,5,1,2,4,5,2,5,1,1,4,2,1,1,2,4,1,5,4,4,4,4,3,4,4,4,5,5,5,4,1,5,5,1,3,1,1,2,4,5,3,2,5,4,2,4,2,2,2,4,4,1,1,3,3,4,2,5,3,4,1,2,2,3,3,2,4,4,1,2,1,3,5,2,4,5,1,1,4,1,5,4,2,5,4,3,5,4,2,1,5,1,5,5,2,2,2,3,2,2,4,5,1,1,2,1,2,3,5,2,3,4,2,4,4,4,1,3,2,3,5,5,1,4,5,3,3,4,1,1,5,1,5,2,5,2,2,2,4,5,2,3,5,2,1,3,3,3,5,3,5,5,5,3,5,2,4,5,5,3,3,2,3,4,1,5,1,4,5,4,3,3,1,4,5,3,5,4,2,5,1,2,4,3,1,3,4,5,4,1,1,3,5,2,3,3,3,1,5,2,3,2,2,2,4,2,5,5,3,5,5,2,1,2,1,1,5,1,2,2,4,1,5,5,5,3,5,1,1,3,5,3,3,5,1,2,2,4,4,1,2,1,1,2,3,2,3,4,4,4,1,1,4,4,1,3,1,4,3,3,1,4,3,3,3,5,4,4,3,2,1,1,1,4,5,2,1,4,4,4,3,3,1,5,5,4,5,1,2,3,5,2,2,4,4,4,2,2,4,2,1,3,2,5,5,2,1,4,5,1,5,5,3,3,3,2,5,3,5,1,1,3,5,1,5,1,1,2,2,5,4,3,1,2,2,3,2,1,4,5,5,4,5,2,5,3,5,4,1,1,5,5,1,2,1,3,2,3,4,2,1,5,4,1,1,5,3,2,2,4,1,3,4,3,3,3,4,4,5,3,1,5,4,2,5,2,5,3,1,5,3,4,2,1,3,3,5,1,2,2,2,3,4,3,4,4,2,3,3,4,4,3,1,4,3,1,2,5,2,2,2,2,5,2,5,3,4,1,4,3,3,2,2,5,2,5,3,2,5,3,3,1,3,1,3,4,5,2,2,3,1,5,5,5,1,3,4,1,1,5,2,2,4,2,4,3,2,1,5,3,4,5,3,5,3,4,4,2,4,5,2,1,3,1,5,4,1,3,5,2,1,2,4,3,3,2,1,4,4,4,5,2,2,3,3,2,1,4,2,3,5,1,1,1,1,3,4,5,1,3,5,2,3,4,2,2,2,2,3,4,5,2,5,5,1,2,4,1,5,5,4,1,1,3,3,4,2,4,1,5,4,5,4,5,3,1,3,2,1,1,1,3,3,4,2,1,2,3,4,5,2,4,4,5,5,3,3,4,5,3,5,4,3,4,1,5,2,1,5,3,4,5,3,2,3,5,3,3,1,3,3,2,2,3,4,1,5,2,2,1,5,5,1,2,4,4,4,2,2,1,5,4,5,5,4,4,2,5,3,4,2,5,2,1,2,3,3,2,1,3,1,3,2,2,5,1,2,5,4,1,3,5,5,2,1,5,2,5,4,4,4,1,3,4,5,1,4,1,3,5,2,3,3,2,5,1,5,5,5,4,3,1,3,5,2,1,3,4,2,3,2,3,1,4,4,1,1,1,5,4,2,2,2,4,4,4,4,3,5,2,4,3,3,2,3,5,5,1,5,5,4,2,4,2,4,3,1,2,3,4,2,5,1,5,5,3,4,1,4,1,2,1,2,4,4,4,2,4,5,1,2,3,1,4,2,5,4,5,1,1,5,2,2,4,2,3,5,3,3,2,1,3,4,2,3,2,1,1,2,1,5,3,5,1,3,4,2,4,5,3,4,1,4,4,3,3,1,5,3,1,1,5,5,4,4,1,2,5,1,4,3,3,1,2,5,1,4,3,2,1,3,2,1,4,5,1,2,2,5,3,3,2,4,2,3,2,4,5,2,1,2,4,4,2,2,5,3,4,5,4,1,5,2,3,3,5,2,1,2,2,5,3,4,3,5,1,5,3,2,2,1,3,2,3,1,2,5,5,5,4,2,4,5,5,1,4,4,3,2,5,2,1,5,2,5,2,1,3,3,2,4,3,4,5,3,4,3,5,3,4,1,5,2,4,1,1,4,2,5,1,3,1,2,2,5,2,5,2,5,1,2,2,4,1,4,4,2,5,2,5,3,5,5,4,2,5,2,3,2,4,2,2,3,3,3,3,4,3,1,4,2,5,4,2,1,3,1,1,4,4,3,4,1,3,5,5,2,2,5,2,3,2,4,3,2,1,1,1,5,5,4,1,4,4,1,4,5,4,5,5,2,4,5,4,4,5,4,4,3,1,2,4,3,4,2,1,5,3,3,3,1,3,4,5,3,4,3,1,5,2,1,1,5,1,4,5,3,5,3,5,3,1,1,1,2,5,1,4,2,5,4,1,5,2,3,2,4,2,4,1,3,5,1,3,5,2,3,4,3,1,1,5,2,5,4,3,3,1,2,5,1,3,1,2,4,4,3,5,3,3,1,5,1,2,2,2,3,1,3,4,3,5,4,3,4,3,3,2,3,2,5,4,1,2,5,2,2,4,5,4,3,3,1,5,2,4,2,4,1,3,5,4,2,2,1,3,5,4,1,1,3,3,3,4,4,3,1,1,3,3,2,2,5,3,3,2,4,3,2,3,3,1,2,3,1,5,1,4,3,1,4,5,5,5,3,3,5,2,1,5,2,5,5,4,1,5,1,5,5,2,4,1,3,4,3,5,2,3,2,5,3,3,3,5,5,3,1,4,4,4,5,3,4,3,2,1,2,3,5,3,4,2,2,2,5,4,4,4,2,1,4,2,4,5,1,3,3,2,5,4,2,1,5,4,3,2,1,5,5,1,3,1,3,4,4,3,4,3,2,1,1,2,1,5,2,1,2,4,1,4,1,1,3,3,5,5,5,5,1,1,5,4,1,2,1,5,5,5,3,4,2,5,4,1,2,4,1,4,4,1,1,3,4,3,4,2,4,2,2,4,2,3,5,5,1,4,3,4,4,1,4,2,3,3,4,3,4,1,5,3,1,3,4,1,2,2,2,2,4,4,4,5,4,4,2,3,2,3,1,4,2,1,5,1,2,3,4,5,1,3,5,3,5,1,5,3,3,5,1,1,2,2,4,2,3,5,5,1,3,4,5,3,3,5,4,2,1,4,3,2,1,1,1,2,5,1,5,4,5,2,2,5,2,2,1,2,5,2,4,3,4,2,2,5,5,4,3,2,4,4,3,2,4,1,3,4,2,3,1,3,5,4,1,3,5,1,4,4,1,4,3,1,4,4,1,1,4,2,3,2,2,5,1,5,5,3,5,2,3,5,5,3,5,4,5,2,1,2,1,2,2,2,2,4,3,2,1,3,4,4,3,5,2,3,2,3,4,3,2,3,5,1,1,2,4,3,5,5,4,1,3,3,3,5,3,2,1,4,4,4,1,1,2,2,3,1,2,5,5,1,2,1,3,5,5,3,1,4,3,2,1,3,3,3,3,4,2,3,4,3,3,4,4,2,3,1,1,4,1,5,3,5,5,5,5,1,2,2,3,3,4,3,5,2,3,2,1,3,5,5,3,2,3,1,5,3,5,1,4,5,2,1,3,5,2,1,2,4,1,5,5,1,5,1,3,3,5,3,4,2,2,5,5,2,1,2,1,3,4,3,2,2,3,3,5,1,1,4,4,5,5,3,1,3,4,4,5,4,3,4,1,3,3,5,4,1,2,3,1,2,2,3,2,3,1,5,2,2,5,5,3,3,3,1,3,2,4,4,5,4,1,3,4,5,5,5,4,4,2,4,3,3,4,2,3,1,2,2,3,5,2,3,4,2,1,1,4,3,4,1,5,2,1,4,1,1,5,5,5,1,3,4,4,2,5,2,2,3,1,5,4,3,1,5,1,3,2,1,4,1,1,3,5,2,2,1,2,5,2,4,4,2,3,1,3,2,2,4,1,2,1,5,5,1,2,1,2,1,3,4,5,1,3,4,2,4,3,4,2,5,5,1,2,1,2,5,2,4,5,3,2,5,2,1,1,3,3,2,4,2,1,3,4,2,4,5,4,4,4,3,3,3,4,1,4,5,2,3,3,1,5,5,1,4,5,5,1,3,3,1,4,5,4,2,4,5,3,2,5,5,2,4,1,4,1,4,5,2,3,5,3,4,3,5,4,2,3,5,3,5,2,5,4,2,2,2,1,2,2,3,5,1,1,5,3,3,4,2,1,3,5,1,2,3,4,1,1,2,2,3,3,3,1,2,4,1,3,3,3,1,5,3,4,5,4,3,3,3,3,1,5,2,3,2,3,2,2,5,1,4,1,4,2,2,3,3,5,2,1,3,5,2,4,3,4,3,3,2,3,3,2,3,2,2,5,1,5,5,5,5,5,1,2,2,4,4,4,5,2,5,2,5,4,3,1,2,5,5,3,5,1,5,1,1,1,5,2,2,4,5,5,2,1,3,3,4,4,3,3,4,5,4,5,4,3,4,4,2,4,5,1,3,5,1,5,4,3,3,5,2,5,4,1,2,2,2,2,1,4,3,2,2,3,3,5,2,4,2,2,2,4,3,4,4,2,5,1,4,1,1,3,3,2,1,4,1,4,5,4,5,4,1,3,1,3,1,5,1,5,4,2,5,4,3,4,5,2,3,1,4,5,4,3,5,3,1,1,2,1,3,5,1,4,4,4,1,1,4,3,1,2,5,5,3,5,2,2,5,2,5,3,1,4,1,1,1,4,1,4,5,4,3,2,2,2,5,3,3,2,2,5,2,3,5,3,1,2,5,2,2,1,5,2,5,2,4,5,1,3,4,1,2,4,2,1,1,5,2,4,5,5,4,1,4,5,1,3,5,1,1,5,5,1,3,1,4,3,2,2,1,2,1,1,1,3,5,4,5,2,3,3,2,2,3,1,1,1,5,2,3,5,4,3,4,1,1,3,4,5,3,5,3,4,5,4,1,2,5,5,2,3,4,5,4,3,2,1,5,3,2,5,1,2,3,3,3,4,5,2,5,4,2,4,3,1,3,3,5,4,4,4,4,4,1,1,5,4,3,2,3,4,2,2,5,2,4,4,2,1,5,1,1,1,2,1,5,4,3,2,3,2,2,5,4,3,2,1,3,1,4,5,3,2,1,3,2,1,5,3,3,5,1,2,2,3,2,2,2,5,5,1,1,4,4,5,1,1,5,3,2,5,1,5,5,5,2,2,1,5,3,2,2,2,1,5,1,1,2,1,1,1,1,3,4,5,3,1,1,3,5,5,1,4,4,5,5,1,2,5,5,1,1,3,4,1,3,4,1,4,1,5,3,2,4,5,5,5,1,2,1,3,2,2,1,3,5,3,5,1,5,3,3,4,3,2,4,5,1,5,4,1,1,2,1,5,3,5,1,5,5,4,5,3,1,2,1,4,5,5,3,4,1,5,1,1,1,5,5,5,3,1,4,4,1,5,3,1,4,2,2,1,5,2,1,1,4,4,4,5,2,2,5,4,5,5,2,3,5,1,2,2,4,2,2,1,1,3,2,2,2,3,1,3,4,3,4,4,5,3,2,3,4,5,5,3,3,4,2,1,2,4,3,2,1,1,5,2,4,5,2,1,5,5,1,2,1,1,4,4,3,1,2,2,3,3,2,2,1,3,1,5,2,1,4,5,5,4,5,1,5,2,1,4,2,2,4,5,5,3,3,3,5,5,1,2,2,3,2,2,4,5,4,3,5,3,2,2,5,4,1,5,5,1,4,4,2,5,5,2,5,5,1,3,3,2,5,1,5,4,2,1,5,3,4,3,4,1,5,3,2,5,3,1,1,5,5,4,4,5,5,2,5,1,3,4,1,4,5,4,5,2,3,2,3,3,1,3,5,5,3,1,3,2,4,4,1,3,1,4,3,5,5,5,3,3,5,3,2,1,2,3,2,1,2,2,3,2,3,5,2,4,4,5,4,5,5,5,5,5,2,1,4,4,4,1,2,4,1,2,1,3,1,4,2,3,5,4,4,3,4,1,3,2,3,1,5,4,1,1,2,5,2,2,3,1,3,2,5,5,5,2,5,3,2,3,3,5,3,5,4,5,1,3,5,5,4,4,1,4,4,3,2,2,5,2,3,5,2,1,5,4,3,4,4,1,4,3,5,1,2,5,3,2,2,5,3,3,2,3,4,3,5,4,1,4,2,5,5,3,1,5,4,2,3,4,3,2,1,5,1,3,4,4,3,3,4,2,5,1,1,3,1,4,5,5,4,4,1,1,3,5,1,3,4,3,1,5,5,4,2,2,5,1,1,2,3,3,2,4,2,3,2,4,5,4,1,1,1,3,5,2,1,5,1,2,1,2,5,4,1,1,1,3,1,3,5,4,4,5,1,5,5,5,5,2,1,1,3,2,3,3,2,4,3,5,3,4,1,3,1,2,2,1,1,3,4,1,4,5,2,4,2,2,5,3,4,5,4,4,5,1,5,2,1,1,4,1,2,4,1,5,2,1,2,5,3,1,5,2,1,3,3,3,3,2,2,5,3,5,5,1,2,2,3,5,3,5,2,4,2,5,3,5,4,4,4,3,2,4,3,3,5,4,2,1,1,5,4,1,2,5,4,4,4,5,5,4,2,2,1,4,5,4,5,5,2,5,5,5,3,5,5,1,5,2,2,1,5,5,4,4,4,2,5,5,2,4,3,2,1,1,1,2,1,2,3,3,4,4,4,1,1,2,3,2,5,3,2,4,3,2,3,4,4,5,5,4,1,1,1,3,3,1,4,5,4,2,1,3,3,5,1,1,1,4,5,4,1,2,2,1,2,3,5,2,1,3,3,4,3,1,2,3,3,1,2,3,1,1,4,4,4,4,4,4,1,1,1,2,5,3,4,2,3,1,1,1,4,5,1,5,4,4,5,3,2,2,5,2,3,5,5,5,2,3,4,1,1,1,1,5,5,5,4,5,4,3,2,4,5,5,3,3,3,4,4,5,2,5,1,2,2,2,3,4,5,2,3,5,4,5,4,5,3,4,4,5,1,1,3,5,4,1,4,1,3,5,5,4,4,1,3,5,4,1,1,2,3,2,3,4,4,1,2,4,1,1,1,2,1,4,4,2,5,1,4,3,2,1,3,3,4,2,5,2,4,5,5,4,3,5,3,3,5,3,1,5,1,5,1,2,1,3,1,4,1,4,5,2,1,1,5,1,4,2,4,3,2,2,4,1,5,5,4,2,2,1,5,5,3,5,5,4,2,5,5,2,1,4,3,4,1,1,4,2,2,1,2,5,2,4,4,5,1,4,3,1,4,5,2,2,5,3,2,2,2,2,1,3,2,4,1,2,1,3,2,1,1,5,1,4,5,4,4,5,5,5,5,5,2,1,3,3,3,5,5,2,5,3,3,5,1,1,5,4,3,2,1,2,2,2,2,4,4,5,3,4,1,1,4,2,1,5,5,3,3,4,1,3,1,1,2,5,2,4,4,4,1,1,1,1,1,5,2,4,4,2,3,3,3,4,2,2,1,4,2,3,4,4,3,2,1,5,4,3,5,5,1,1,2,4,2,4,2,3,1,1,5,2,2,3,3,4,1,5,1,4,2,2,2,4,2,4,5,5,2,4,4,1,5,3,4,3,2,5,4,4,1,2,5,1,3,1,2,5,3,5,1,4,3,5,1,4,2,2,5,2,3,3,5,5,3,4,5,1,5,1,1,1,4,4,5,4,1,1,2,5,5,3,4,5,1,3,2,5,1,4,1,1,5,5,2,1,5,1,5,5,5,5,1,5,5,3,4,3,5,2,5,4,3,5,5,1,4,2,1,5,3,2,4,4,3,5,5,2,3,4,3,3,1,1,4,5,1,2,2,5,1,1,4,5,2,4,3,5,5,1,2,5,3,3,5,4,5,3,1,2,3,2,2,2,3,5,2,4,1,2,2,2,5,2,1,2,1,3,2,4,3,3,5,5,4,4,5,4,1,1,3,5,2,3,4,4,1,5,3,3,2,3,2,5,1,2,4,1,2,4,2,5,4,1,2,3,4,1,4,5,2,4,5,3,2,3,3,5,4,3,5,2,3,4,5,5,4,5,4,4,3,4,5,3,3,2,2,2,3,1,3,3,3,3,5,4,5,4,3,5,2,4,5,4,5,4,1,3,4,3,1,3,1,1,1,5,2,3,1,1,1,1,3,1,5,5,1,1,1,5,1,2,4,1,5,1,5,5,4,4,1,5,4,2,1,3,3,5,5,2,5,4,4,5,5,1,1,1,4,3,1,4,1,1,3,2,1,2,4,4,1,1,5,1,1,2,1,1,1,5,5,3,5,1,4,2,5,3,3,5,5,3,4,4,5,2,5,2,4,1,1,4,1,2,3,5,1,5,3,3,4,3,2,5,3,2,5,2,2,3,5,1,3,2,2,5,5,4,4,3,2,2,4,2,5,4,2,3,2,1,3,5,1,2,5,4,3,1,2,1,5,4,2,5,1,3,2,5,1,1,5,4,5,1,1,3,4,5,2,2,2,5,5,5,3,3,4,1,2,3,1,5,2,2,3,5,5,5,4,4,1,4,1,3,4,1,2,1,2,5,1,4,5,1,5,2,5,2,1,2,2,2,4,1,4,5,2,3,4,1,3,5,3,1,1,5,3,1,3,2,1,3,5,4,4,5,3,4,1,4,3,5,3,4,1,1,1,5,2,3,1,5,4,4,3,3,1,4,1,5,4,2,1,1,5,2,2,5,3,5,4,1,4,5,2,1,2,2,5,5,4,2,5,1,3,5,4,3,1,1,3,1,2,5,2,3,3,3,1,1,2,3,3,5,3,4,1,4,4,4,4,2,2,1,1,5,4,2,4,2,5,2,2,1,5,2,2,5,1,2,4,3,5,1,2,1,3,3,2,5,5,1,5,2,5,5,1,2,5,1,3,5,1,3,1,3,3,3,5,2,3,5,2,2,5,4,2,5,4,4,3,2,5,4,2,1,3,4,4,4,2,3,1,4,2,3,2,3,3,2,4,4,1,5,3,3,4,1,5,3,5,1,5,3,2,2,1,4,2,2,2,1,5,5,2,4,2,2,4,5,2,2,1,1,3,2,5,1,4,5,2,1,5,1,4,1,3,4,3,1,2,2,4,3,5,3,5,4,3,5,1,3,1,5,1,2,1,4,2,4,5,5,4,5,5,5,1,5,5,1,1,1,5,1,5,1,1,1,1,1,4,5,1,2,5,2,2,3,2,5,3,1,3,3,5,4,1,2,1,3,3,1,2,3,4,5,4,5,3,4,4,5,4,4,4,3,3,1,3,3,1,3,2,3,3,2,5,1,3,2,1,4,1,4,4,2,5,2,1,2,2,2,4,3,5,1,1,2,2,1,2,3,2,3,5,1,1,2,2,1,2,3,4,1,1,3,1,3,4,4,1,1,3,2,3,4,4,4,4,4,1,5,5,4,4,1,4,5,5,1,5,4,3,5,5,1,4,4,5,1,4,3,5,1,4,1,5,3,5,2,5,4,2,3,4,4,2,3,5,4,4,5,5,5,5,1,1,4,1,2,2,5,4,4,5,3,1,5,4,1,2,2,4,1,5,2,3,4,2,4,1,3,1,3,5,2,4,1,2,5,1,2,3,2,3,4,2,3,5,2,5,3,3,1,2,4,5,5,5,5,4,4,4,4,4,2,2,3,4,4,4,3,5,3,5,2,3,1,5,4,4,5,2,5,5,3,5,4,1,5,5,1,1,1,2,5,5,5,4,1,2,1,3,1,2,3,3,1,3,4,2,3,3,1,3,1,1,4,1,5,5,1,3,3,4,2,4,3,5,4,5,1,4,4,2,4,4,1,5,4,3,3,5,4,3,2,5,2,2,2,3,2,5,2,2,5,3,4,4,4,4,2,3,4,4,1,4,1,1,2,5,1,2,5,4,3,2,3,1,3,5,1,2,5,3,5,3,3,3,5,1,3,4,3,3,4,5,1,5,2,4,4,2,4,4,4,4,1,4,3,3,2,5,2,2,3,4,4,1,3,3,3,5,4,4,5,5,3,5,1,5,2,1,2,1,5,3,3,3,3,2,2,4,2,2,3,5,2,1,2,1,4,4,4,5,2,2,3,3,1,3,1,4,5,1,3,3,1,5,3,3,5,3,5,4,2,2,4,3,1,1,3,4,2,3,2,2,2,1,2,3,1,4,3,3,1,1,1,2,2,4,4,3,3,2,3,2,2,4,1,4,3,3,1,3,2,4,1,1,1,4,1,2,5,5,3,3,5,1,5,1,1,5,1,4,5,2,2,4,3,3,4,5,1,4,3,5,4,3,4,2,2,2,3,2,2,3,1,1,3,3,1,5,2,2,5,4,1,3,4,5,5,4,5,3,4,2,1,5,1,3,4,5,1,5,2,2,2,3,2,2,2,3,1,5,4,3,4,1,2,4,2,5,3,5,3,1,1,1,2,2,4,4,4,2,1,3,3,3,5,3,4,4,5,2,5,2,1,3,4,1,1,1,5,4,1,5,2,4,3,3,4,5,3,4,3,5,5,1,1,2,3,1,1,4,5,4,4,3,1,5,5,4,3,2,1,5,1,5,2,5,2,3,4,1,3,1,2,3,1,5,3,3,1,5,2,2,3,4,4,5,3,4,3,4,3,2,4,2,4,3,4,3,4,2,5,2,5,3,2,5,3,3,2,2,2,5,1,5,2,2,5,2,5,3,4,5,3,1,5,5,3,3,5,3,2,1,2,5,4,4,2,5,4,2,5,4,2,1,1,5,5,2,1,2,3,4,4,2,3,2,5,4,5,5,2,5,2,4,4,3,2,2,2,5,3,1,5,1,3,5,1,3,5,5,2,5,4,5,5,5,3,5,5,1,2,3,5,5,3,4,2,3,2,4,4,4,5,1,4,2,2,3,4,3,3,4,4,4,2,2,2,5,5,2,3,2,3,1,3,4,4,3,1,3,5,2,4,5,5,4,1,4,2,4,5,2,2,4,2,1,2,4,2,2,1,2,5,2,2,5,3,2,3,4,3,2,1,1,1,2,4,2,4,4,4,2,3,1,2,1,3,3,5,1,3,5,2,2,1,2,2,3,3,3,2,5,4,2,2,1,4,1,3,2,4,5,4,3,5,1,5,3,4,5,3,4,4,4,1,2,3,4,3,2,5,2,1,4,1,3,1,1,2,3,5,2,1,3,4,1,2,5,1,5,3,3,5,3,5,3,4,1,3,4,2,4,3,3,2,4,2,2,4,1,3,5,2,3,5,2,5,1,2,2,1,2,5,3,1,5,2,5,1,4,4,2,4,1,4,5,4,2,3,3,5,3,2,5,5,5,5,5,1,5,1,3,3,3,2,1,4,5,5,5,1,3,4,4,4,1,1,5,3,1,4,1,2,5,5,5,5,2,1,4,1,1,2,2,3,4,2,2,1,3,2,2,4,4,3,4,5,3,4,5,5,2,5,1,3,2,2,4,2,1,2,2,1,4,3,2,4,2,5,5,2,5,3,3,1,1,4,3,3,2,3,1,2,3,5,3,3,4,1,4,1,5,2,3,2,1,2,2,3,5,4,5,5,3,5,1,1,4,2,4,2,1,2,5,1,2,3,3,3,2,3,3,3,5,3,5,4,5,2,2,1,1,4,4,3,2,4,2,5,1,3,1,5,5,3,4,5,1,4,4,3,2,2,2,3,3,5,1,5,2,5,3,4,1,4,1,5,2,4,4,2,5,2,4,5,2,2,2,4,1,5,1,5,3,4,3,3,3,4,1,4,3,1,1,3,5,2,4,2,4,3,3,5,2,2,2,2,4,5,1,1,4,4,5,2,5,4,4,1,1,2,4,4,5,3,5,5,4,5,1,2,4,4,4,1,2,1,5,4,3,2,4,1,3,2,2,2,3,3,1,1,2,2,5,5,1,5,5,1,2,4,1,1,3,2,3,4,2,1,3,5,4,2,1,4,1,2,3,2,1,4,5,3,4,1,3,3,4,2,1,1,4,5,5,2,4,1,3,5,2,2,2,1,5,3,5,5,4,1,2,1,5,4,5,3,4,3,5,2,2,2,4,1,3,4,4,4,2,1,1,1,2,5,3,4,4,4,3,5,5,2,1,1,5,4,5,4,1,3,4,2,5,1,3,4,3,2,2,4,1,4,5,2,2,3,4,3,2,2,5,4,5,4,1,4,2,4,4,1,3,5,3,1,3,4,5,3,5,4,1,5,4,5,1,2,1,2,2,4,1,4,3,4,5,2,1,3,4,2,4,1,1,5,5,5,5,1,2,1,1,5,4,1,1,3,2,4,5,2,4,5,3,3,1,1,4,3,1,1,5,2,5,5,4,1,1,3,3,5,5,1,3,5,5,2,5,4,4,4,1,1,3,1,2,2,1,1,1,3,5,2,3,3,1,2,4,1,2,3,1,4,4,4,5,5,5,2,4,3,2,5,3,1,3,2,3,4,3,4,1,2,2,2,4,3,5,3,5,2,1,1,4,2,4,3,2,3,4,3,4,2,5,1,5,4,4,5,2,3,1,4,1,5,4,2,1,5,4,3,5,1,3,2,2,5,2,4,2,2,2,1,5,3,5,2,4,2,2,5,1,4,4,5,1,2,1,5,5,5,3,4,3,3,4,2,2,3,2,1,5,2,3,2,4,5,4,3,4,1,5,3,2,1,2,5,3,4,4,2,3,2,4,4,4,2,4,3,2,3,2,3,2,1,5,1,3,4,1,2,5,5,5,3,1,5,2,2,2,4,5,5,4,1,1,2,1,3,5,3,4,3,5,3,2,3,5,3,2,2,3,3,1,2,2,2,3,4,1,5,2,5,3,1,3,3,5,3,4,5,3,3,2,5,4,3,4,5,2,3,3,2,4,5,2,2,1,5,3,5,3,2,1,3,4,3,4,2,3,1,1,1,2,4,1,1,5,4,4,1,4,4,3,2,5,1,3,4,1,5,4,4,3,2,4,4,4,4,5,2,5,2,5,4,3,2,1,2,4,2,3,3,5,3,1,2,2,4,1,5,4,3,5,5,5,2,2,5,1,1,2,2,2,1,4,1,2,2,4,3,5,4,3,4,4,2,2,1,2,4,2,2,1,4,4,1,2,3,2,4,4,5,2,4,5,1,4,4,3,3,2,5,4,3,5,5,5,5,4,1,5,2,3,3,4,4,1,5,2,2,5,4,1,5,1,2,4,3,1,4,1,5,2,1,2,4,2,1,3,1,5,4,4,5,1,2,3,1,2,3,1,2,4,3,3,2,2,5,3,2,3,4,1,4,2,5,1,4,2,4,2,3,4,5,2,4,2,4,5,4,5,5,4,2,5,1,3,1,5,5,2,1,2,3,5,3,4,5,3,2,2,3,2,5,5,4,4,2,2,4,3,1,1,3,5,5,1,2,4,4,5,4,3,3,4,5,3,1,2,3,5,3,5,5,2,1,1,3,2,2,2,4,3,3,5,2,3,5,2,2,4,2,2,4,1,2,3,5,4,2,1,3,1,4,2,4,4,1,3,3,4,5,1,3,5,2,5,1,1,3,1,4,5,1,2,5,5,1,1,1,1,1,4,4,1,5,3,3,3,2,2,3,2,4,4,1,4,4,5,4,4,2,3,4,4,1,3,1,4,1,5,3,4,4,3,3,3,4,1,2,2,3,4,1,4,2,3,4,1,5,3,1,3,3,1,3,5,4,1,3,4,3,5,3,1,2,5,3,3,5,1,1,4,2,4,2,5,2,5,2,4,1,5,5,4,1,3,3,5,5,4,4,4,5,2,1,2,5,3,4,1,4,3,3,2,2,3,4,2,1,1,5,1,2,4,3,3,2,2,4,4,3,4,5,4,5,4,2,3,5,2,3,1,4,1,1,1,2,1,1,2,4,3,5,1,3,4,4,1,5,4,2,1,4,5,3,3,2,1,3,2,1,3,2,5,4,2,5,3,3,1,3,5,1,3,5,3,5,3,1,4,2,5,2,3,4,1,5,2,1,2,4,2,1,2,2,2,5,3,2,2,1,5,2,3,4,1,5,4,1,4,2,5,1,1,3,5,5,3,3,1,3,2,2,1,1,5,2,4,4,4,3,3,5,2,5,1,1,4,1,3,2,4,3,4,2,1,2,1,5,3,1,2,1,5,1,1,5,5,3,1,2,2,1,3,2,3,2,3,3,3,2,5,2,2,2,5,3,5,2,2,1,1,1,1,1,3,1,2,1,1,3,2,1,5,2,4,3,2,1,1,3,3,1,3,3,4,5,4,5,4,1,2,4,1,1,2,1,1,3,2,2,5,5,1,5,2,1,2,2,4,2,4,1,3,1,4,4,5,1,2,3,5,4,3,5,4,2,2,2,2,1,3,2,4,2,5,1,1,4,5,3,1,2,1,1,4,3,5,1,5,4,1,2,4,4,5,3,1,2,5,5,5,4,5,4,5,2,1,2,3,3,3,2,1,2,2,3,4,4,1,1,5,5,3,4,5,4,5,5,2,3,2,5,1,3,5,4,4,3,4,2,3,5,4,4,1,2,3,1,2,4,1,3,2,5,2,4,2,4,1,5,3,4,1,5,4,3,2,1,1,1,1,2,2,1,3,2,1,3,1,1,1,3,4,5,1,4,1,3,4,5,2,2,4,1,4,2,1,4,1,5,4,2,4,3,4,4,1,4,3,4,4,3,2,3,5,5,2,2,4,4,1,1,5,5,1,5,1,4,5,2,3,1,4,5,3,3,5,1,5,1,2,3,1,3,2,1,2,1,2,4,4,5,1,1,4,1,1,4,1,5,1,5,4,3,5,5,1,3,3,2,2,4,4,3,1,5,5,2,5,5,5,1,4,3,4,1,4,1,1,5,5,4,4,1,3,5,4,2,4,5,1,3,5,1,1,1,4,4,2,2,3,3,3,3,1,3,5,5,1,4,5,3,5,2,2,1,3,3,5,3,5,5,3,1,2,4,5,1,4,4,5,4,4,2,2,4,3,4,1,4,4,2,2,2,5,3,5,3,2,3,4,5,1,4,3,2,3,1,2,3,1,5,3,1,2,3,2,1,1,5,4,5,1,1,4,2,1,4,4,5,1,5,2,1,1,5,5,4,2,5,5,3,1,5,3,4,1,5,2,2,3,5,4,2,1,5,4,3,2,3,3,4,2,2,2,3,1,2,4,1,2,4,5,2,2,4,5,2,3,1,5,3,4,3,3,1,3,5,4,1,3,4,2,2,1,2,1,4,2,1,5,2,4,3,4,3,5,4,1,2,4,2,1,5,5,4,1,5,5,3,3,1,4,3,1,2,3,1,4,1,5,4,2,2,5,2,3,3,2,2,1,3,5,4,1,3,4,2,5,2,3,4,4,5,2,1,5,5,1,1,4,4,3,3,3,1,3,5,3,1,1,4,2,4,2,5,5,2,4,3,4,3,3,2,5,4,5,4,2,1,4,4,5,1,2,1,1,5,2,1,1,4,5,3,4,1,1,2,4,2,1,1,2,4,3,5,1,2,4,5,2,3,1,5,3,5,4,2,1,3,2,4,3,4,4,5,1,1,1,5,4,3,5,2,3,2,3,5,2,1,2,3,2,2,2,1,4,2,3,5,1,4,2,5,2,3,1,4,4,4,5,3,1,2,1,3,3,4,2,1,3,2,4,3,2,1,2,4,5,1,1,4,5,3,1,4,5,1,4,1,1,5,2,5,4,1,3,2,5,4,2,2,2,4,2,2,2,1,4,3,4,4,5,1,2,2,4,2,2,1,2,4,5,5,2,4,4,5,4,4,1,5,1,2,3,5,4,5,5,5,1,5,4,4,2,3,1,2,3,2,3,3,2,4,3,3,4,1,4,3,3,1,4,5,3,4,1,3,3,5,3,4,3,1,3,1,2,5,2,4,4,1,5,2,4,5,2,1,5,4,1,3,3,3,1,5,3,3,2,2,3,3,2,4,3,4,2,4,2,5,4,3,5,2,2,4,3,4,5,3,4,3,1,2,3,4,2,4,4,3,4,5,1,3,3,3,1,4,3,4,5,4,3,4,2,1,5,4,2,1,5,3,4,1,2,2,5,2,3,4,5,1,4,4,3,3,1,3,2,3,3,4,5,1,3,5,5,2,4,2,5,2,5,3,2,4,4,5,1,5,3,4,4,4,4,4,3,4,1,1,4,5,4,3,1,4,3,5,4,1,5,2,4,3,3,1,2,3,4,5,5,1,3,5,2,3,1,5,4,2,3,5,3,3,5,1,3,4,3,3,2,4,5,1,3,1,1,3,5,4,2,1,2,4,5,1,5,1,3,1,1,4,4,2,4,2,4,2,1,3,4,5,3,3,2,2,2,5,2,5,2,2,5,4,2,3,3,3,3,4,4,4,2,5,5,1,3,2,4,2,2,5,3,2,5,5,4,1,3,2,2,3,3,3,1,5,5,5,4,1,3,1,5,4,3,4,1,4,2,5,4,5,2,5,3,1,3,4,1,1,5,4,2,4,3,4,4,5,5,5,4,5,1,1,3,5,4,1,2,3,1,3,4,1,1,3,2,5,5,1,1,2,3,5,2,3,2,5,1,3,4,2,1,5,4,3,5,5,2,1,1,2,5,1,2,3,1,5,5,3,4,3,2,1,2,4,2,5,1,4,2,5,1,2,5,5,1,2,2,2,5,1,2,1,2,2,1,4,2,4,2,1,4,3,3,4,3,4,2,5,2,2,5,4,4,5,5,4,5,3,4,2,5,5,1,2,2,2,3,2,4,1,5,2,3,2,1,3,5,4,1,2,5,3,1,4,1,4,1,3,5,5,5,5,4,3,3,4,3,5,1,1,2,2,4,3,1,1,1,5,4,4,5,3,3,3,1,2,4,2,5,1,3,2,1,2,2,2,2,2,4,1,1,4,4,5,3,4,5,2,5,1,3,1,5,1,1,5,4,3,1,5,2,1,2,5,1,3,1,5,3,1,1,4,5,3,1,5,2,2,1,4,2,5,4,3,3,5,2,5,5,5,5,2,5,4,1,4,2,1,1,1,2,3,5,2,2,5,2,5,3,2,3,5,2,2,4,2,1,3,3,3,5,2,4,5,2,1,5,3,2,2,1,3,5,1,2,1,4,5,4,1,5,3,2,2,5,2,5,5,1,4,4,3,5,3,2,3,3,2,4,4,1,3,4,2,2,3,5,2,2,2,1,3,3,3,1,5,4,2,2,2,2,2,3,4,3,1,2,1,4,1,4,3,1,4,4,4,3,4,1,5,2,1,5,4,5,4,5,2,1,1,2,2,1,1,1,4,5,1,2,4,2,3,2,2,3,4,1,4,2,4,4,3,1,3,4,1,2,3,3,5,5,3,2,2,2,5,3,3,1,3,1,5,2,5,4,5,3,4,5,2,4,1,5,5,4,3,1,2,4,5,3,5,3,1,1,2,2,2,4,4,1,2,2,2,2,3,1,3,3,1,2,3,4,2,1,5,1,3,5,2,1,1,5,5,3,3,2,2,1,5,2,2,4,4,3,2,4,5,4,4,5,4,4,3,4,1,5,4,1,3,5,2,5,3,1,2,2,3,5,2,1,5,1,4,2,5,3,5,4,2,1,4,2,4,1,1,5,3,2,1,3,5,1,4,3,1,2,4,3,2,5,1,3,2,3,1,3,5,1,5,3,2,3,1,3,4,2,2,1,1,2,2,5,4,5,4,3,1,4,1,4,5,1,5,5,4,1,3,5,3,3,3,3,4,3,3,1,4,5,4,2,5,1,2,4,5,5,5,2,2,1,2,5,1,2,4,1,3,5,1,2,3,4,4,3,3,1,2,1,3,3,4,1,2,2,2,5,1,5,1,4,3,4,4,2,3,3,2,2,5,3,4,3,5,1,3,4,4,3,4,3,5,4,2,3,3,2,5,4,5,1,2,5,5,5,3,5,3,4,1,1,2,3,1,5,4,2,3,2,4,3,5,2,4,5,3,3,5,2,5,2,3,2,2,2,3,1,5,2,2,3,5,5,3,5,3,1,1,5,5,3,2,4,5,5,2,3,2,5,3,2,3,1,1,2,5,2,1,4,2,4,5,5,5,3,2,4,5,5,1,3,5,1,3,4,1,2,5,4,3,3,4,4,4,2,2,2,1,2,4,3,4,2,4,1,4,4,1,5,2,1,5,2,3,2,5,2,4,4,4,1,2,1,1,4,1,4,4,3,3,5,1,2,1,3,4,1,2,3,3,4,2,4,3,3,2,5,4,3,1,2,3,5,1,5,5,2,4,5,4,3,3,1,5,2,3,4,2,2,1,4,3,2,5,1,3,3,5,5,3,1,2,1,4,4,1,2,5,3,1,1,4,4,1,2,2,4,5,4,5,4,1,1,1,3,2,3,3,5,5,4,5,3,4,5,1,1,4,2,2,3,4,5,2,4,3,1,1,1,4,3,1,1,4,2,5,3,3,1,3,5,1,2,2,1,4,1,4,3,1,1,1,5,3,1,1,5,2,5,5,1,5,4,2,5,4,2,2,2,4,2,5,4,5,1,5,5,2,1,2,4,4,3,5,3,3,4,4,2,1,4,2,4,2,5,3,3,4,2,1,1,3,3,1,5,1,5,4,2,3,4,2,2,2,4,4,4,3,1,5,5,1,1,2,2,2,2,1,2,3,2,5,5,1,4,3,3,3,5,4,4,2,2,2,3,4,5,2,4,2,1,2,4,4,3,5,1,1,4,1,4,1,5,3,3,2,1,1,4,1,1,4,3,3,5,5,3,2,1,4,1,2,3,4,1,3,1,5,3,4,1,3,5,4,3,1,4,1,1,5,1,5,5,5,5,4,5,4,4,1,5,1,1,2,3,2,5,5,2,1,4,5,2,3,5,4,5,4,2,3,2,5,4,5,3,5,4,4,5,2,5,4,1,3,2,4,4,5,5,3,4,3,5,4,2,4,2,3,4,2,5,5,5,2,3,2,1,4,3,3,4,4,1,3,1,2,2,5,4,4,2,2,3,4,3,5,5,2,4,1,3,2,4,5,3,2,5,1,1,2,4,4,2,1,1,2,4,1,1,2,1,2,1,2,3,5,3,4,5,1,2,5,2,3,1,1,5,2,3,3,5,1,1,4,2,2,5,5,1,1,1,2,2,1,3,1,3,1,5,5,3,1,4,5,2,3,3,4,4,1,4,5,4,1,5,5,2,1,5,2,4,3,5,4,2,4,4,5,3,4,1,3,5,5,4,3,3,1,4,2,3,2,2,1,5,5,1,2,5,5,1,5,4,2,1,4,4,4,1,3,3,1,1,2,2,3,4,4,5,1,1,4,5,3,2,1,5,5,5,5,1,5,4,1,3,1,5,4,4,5,5,2,3,4,3,4,2,2,2,5,3,5,4,3,2,4,2,2,1,4,1,1,3,5,5,5,1,4,1,5,4,4,4,3,1,1,2,3,1,3,3,5,1,4,5,4,1,2,3,3,1,1,1,2,3,2,4,5,5,5,1,5,5,5,4,5,2,5,4,4,1,2,5,2,2,1,4,4,5,1,1,1,2,5,4,4,1,3,1,3,5,2,1,2,3,3,5,1,2,4,1,5,2,3,4,4,3,3,1,3,3,4,2,2,1,5,3,2,3,5,5,4,1,2,2,2,4,5,3,4,1,3,4,3,1,1,4,5,5,1,3,4,5,4,2,5,4,3,3,5,4,4,5,4,3,2,1,5,5,1,4,3,4,1,4,5,5,4,4,5,1,2,5,2,4,1,3,1,1,2,4,4,1,4,1,5,3,3,1,4,2,4,4,3,1,4,4,1,4,3,5,5,2,2,5,5,5,5,5,2,1,2,3,5,5,2,3,5,2,1,4,5,2,4,1,3,1,4,5,5,1,3,3,4,3,5,1,5,2,4,3,1,2,1,1,1,3,1,2,3,4,4,4,4,1,2,5,1,1,1,5,5,3,3,2,5,2,1,5,3,4,4,5,5,2,3,1,5,1,3,5,3,1,2,3,4,5,2,5,5,1,5,3,1,5,3,2,3,3,5,1,5,4,3,3,5,2,1,2,1,1,5,4,3,5,4,1,3,1,1,2,1,4,3,1,5,5,3,4,2,5,5,5,2,4,1,2,3,5,1,4,4,1,4,2,3,4,4,4,2,5,4,3,2,1,1,2,4,1,2,3,4,2,5,1,1,1,3,4,1,3,5,3,3,5,3,5,5,3,1,5,5,5,2,5,4,2,3,5,4,5,3,2,3,3,2,4,4,1,5,4,5,4,2,2,1,1,3,3,5,1,1,4,2,1,2,4,3,5,5,3,3,5,5,1,5,3,4,5,4,3,4,4,4,4,3,2,1,2,5,3,4,2,3,5,5,3,4,4,3,4,4,2,5,4,2,3,3,5,1,4,5,1,1,3,1,4,5,4,3,4,5,3,2,2,5,4,1,3,1,5,5,4,1,3,4,5,4,2,4,4,3,2,5,2,2,5,4,2,1,2,2,1,4,4,2,1,3,4,5,2,2,4,5,4,2,3,2,1,3,4,3,1,1,5,1,5,4,1,1,4,3,1,5,1,4,4,5,3,4,3,4,4,1,4,5,1,4,4,2,1,4,5,5,3,2,5,3,2,5,2,3,5,3,2,2,5,1,1,1,2,2,4,5,4,3,2,2,2,5,3,1,5,2,1,3,2,1,1,4,5,3,1,5,3,4,3,5,2,5,4,3,1,2,3,5,3,5,4,1,2,1,4,5,3,3,3,3,5,3,5,5,3,2,4,2,2,5,2,2,4,1,2,2,4,5,1,1,2,5,4,2,3,4,2,1,1,3,2,3,2,5,4,2,3,4,2,2,2,5,3,1,5,4,3,4,2,4,3,3,4,3,4,5,1,3,3,5,2,2,5,4,1,1,5,2,1,4,2,4,2,3,3,5,5,1,4,2,2,3,1,1,4,1,4,4,5,3,4,4,5,2,5,4,5,2,1,2,2,1,1,4,1,4,2,3,1,1,3,2,1,4,1,3,5,2,5,1,4,5,2,4,3,2,2,3,1,4,3,2,1,5,4,4,4,2,5,2,5,4,2,3,1,4,1,5,3,5,4,1,3,5,2,1,3,5,1,3,2,3,3,1,3,2,1,3,2,2,2,3,2,2,4,4,2,3,1,2,4,4,3,2,4,5,2,3,4,3,2,3,2,4,1,2,4,1,2,4,2,1,2,4,5,3,2,3,2,1,1,5,4,4,2,1,1,2,4,2,3,2,2,5,1,5,2,5,2,3,3,3,3,1,2,3,4,1,4,4,2,2,5,4,1,1,4,4,1,3,5,4,4,3,2,5,4,5,1,3,3,4,2,2,1,2,2,5,1,1,3,3,3,4,5,1,5,5,1,4,5,5,5,1,5,5,5,4,5,4,2,5,4,1,4,2,5,3,2,1,4,3,2,4,5,1,5,5,4,1,1,3,2,1,2,3,1,3,4,1,2,2,5,3,5,4,2,5,5,2,1,3,1,5,4,2,3,3,3,5,1,1,1,5,3,3,5,5,4,4,4,2,1,4,2,3,3,4,2,5,4,2,1,5,1,4,1,4,3,2,4,5,4,5,4,1,2,5,5,2,3,4,3,1,5,5,4,4,3,5,2,5,5,3,5,3,3,1,5,5,1,1,1,5,3,4,4,1,4,2,1,2,5,4,4,3,5,2,3,1,3,4,3,1,2,1,5,5,5,1,5,2,5,1,5,1,2,5,4,3,1,4,4,4,1,4,4,5,4,1,3,1,1,4,4,4,5,2,1,1,4,3,5,3,4,2,3,2,4,5,1,1,3,1,1,4,5,3,4,5,1,1,1,4,4,4,2,2,3,3,1,4,4,4,4,1,3,3,4,5,5,5,4,4,1,3,3,5,5,5,4,5,4,5,3,3,2,1,5,1,3,3,2,2,1,5,5,3,5,3,1,4,2,5,2,4,5,5,1,2,1,4,5,3,1,2,5,5,1,5,1,1,4,5,2,4,5,5,4,2,5,4,3,4,1,2,2,3,1,5,3,5,5,5,2,2,3,3,1,3,2,2,5,4,1,5,3,2,5,3,1,5,5,5,1,5,2,3,4,4,1,2,3,2,1,1,5,3,2,2,5,3,2,2,4,4,2,3,5,2,3,3,1,4,5,5,1,2,2,2,5,1,3,4,4,5,4,1,3,2,2,5,2,3,2,2,4,1,3,3,1,4,1,1,5,3,1,2,3,3,2,4,4,2,5,1,5,5,3,5,1,1,3,1,3,3,2,4,3,1,2,1,3,4,5,4,5,4,1,3,5,1,5,4,2,4,2,2,5,2,4,2,2,5,5,3,4,5,5,1,5,5,1,1,1,5,4,1,4,4,5,4,5,3,3,2,4,1,5,4,1,1,5,1,1,2,3,3,2,5,4,3,5,3,3,5,4,4,5,5,3,3,5,3,5,1,1,4,4,4,2,3,5,4,1,1,4,3,4,5,3,4,3,4,5,5,1,1,2,5,2,2,2,2,4,2,5,5,5,4,4,5,2,5,4,3,5,5,2,2,5,3,2,1,5,3,2,1,4,1,4,1,1,5,1,4,5,5,1,4,5,1,4,3,2,5,5,2,2,2,5,3,5,2,4,4,4,2,1,3,2,2,2,1,2,3,3,1,2,3,2,5,3,5,5,4,2,5,4,2,4,1,3,3,5,5,5,5,4,5,1,1,3,5,3,5,4,4,2,3,2,3,1,5,3,5,3,3,1,1,5,1,5,4,2,1,5,5,4,3,3,2,5,4,5,2,4,3,5,2,5,3,5,2,2,2,1,1,3,2,2,1,1,3,1,3,2,4,2,2,5,3,1,5,4,4,2,4,2,1,5,3,4,2,1,4,1,1,2,2,4,5,3,3,4,3,4,2,2,2,5,2,3,4,4,1,4,5,1,3,3,5,5,1,5,4,5,5,1,2,2,2,4,2,5,3,2,4,1,3,2,5,3,1,5,4,2,4,3,5,5,4,5,3,2,3,4,3,1,4,2,1,4,3,4,4,5,3,4,3,5,3,2,3,5,2,1,5,3,3,4,4,5,1,3,2,2,2,4,3,5,1,2,2,5,5,2,2,3,2,1,2,4,4,2,3,1,5,2,1,3,2,4,2,2,1,2,2,1,4,5,5,5,3,5,1,1,3,5,3,1,4,2,1,4,4,3,4,3,5,5,3,1,3,5,5,3,4,2,4,3,2,3,4,1,4,2,3,1,1,2,4,1,3,3,2,4,5,2,3,4,1,1,4,3,3,5,2,4,1,3,3,3,4,1,1,3,1,5,5,5,5,3,3,3,5,3,3,2,1,4,1,3,4,3,2,4,3,2,2,1,2,3,3,1,3,4,2,5,3,2,1,3,3,5,4,5,5,2,5,2,1,2,1,4,5,3,3,3,4,2,4,5,1,1,4,4,2,2,3,2,2,5,1,3,4,3,3,4,1,2,5,1,3,2,3,1,3,5,3,2,3,1,2,4,4,3,1,3,1,1,3,3,5,5,4,3,2,4,3,1,4,3,1,1,3,1,5,4,4,1,3,4,3,5,1,5,4,1,2,2,5,1,4,1,1,1,1,5,1,1,5,4,5,4,3,5,2,3,2,1,3,2,4,3,1,4,3,4,4,2,3,2,5,3,3,4,4,5,2,2,2,2,1,2,1,2,1,5,1,1,5,4,3,2,5,3,3,3,5,3,4,3,2,4,1,1,5,2,4,5,5,5,5,1,1,2,3,1,1,2,3,4,3,4,5,5,4,4,4,3,4,5,2,2,1,4,5,5,3,5,1,4,5,2,5,1,4,4,3,3,1,4,1,2,1,3,1,5,3,5,1,2,1,5,1,4,1,1,1,5,5,2,4,1,2,4,1,4,3,5,5,5,5,2,5,3,4,5,4,5,1,4,2,5,1,4,2,4,4,3,4,3,4,2,4,1,5,3,2,4,4,1,5,1,5,4,5,4,5,5,5,2,1,4,2,2,1,4,3,2,4,2,2,5,4,5,4,1,1,1,4,4,4,2,1,2,1,2,5,2,4,1,2,3,1,1,1,5,2,5,4,3,4,3,2,4,4,4,5,1,5,2,3,3,2,5,1,3,4,4,3,1,1,2,4,2,1,5,5,2,2,3,1,1,5,5,3,5,1,5,5,4,5,1,3,2,4,3,5,5,1,3,4,3,3,4,4,3,1,2,2,4,4,3,4,3,4,1,5,1,5,5,3,2,4,2,1,4,1,4,2,5,4,3,2,3,1,4,3,5,3,2,1,4,3,1,5,1,2,3,1,4,5,3,4,4,2,5,1,4,5,3,2,3,5,1,5,5,4,4,4,4,1,5,4,4,4,1,5,3,4,1,1,4,4,2,3,5,5,5,1,1,3,5,2,2,2,3,4,4,1,4,1,3,5,5,5,1,5,1,1,5,4,4,3,3,3,3,4,4,3,2,3,1,2,3,5,5,5,5,4,3,2,4,4,5,5,3,1,1,5,1,2,2,4,5,2,5,4,4,1,4,5,1,5,1,5,5,3,5,3,3,3,3,5,3,2,3,1,2,3,5,4,1,5,3,5,4,2,2,1,4,1,2,3,1,3,2,4,4,2,4,1,2,4,1,5,2,1,2,2,2,4,5,1,2,3,1,5,1,3,2,3,4,1,4,2,5,4,2,5,2,1,5,4,4,4,1,5,4,4,4,2,4,4,2,5,2,1,3,2,2,5,5,3,1,5,4,2,1,5,4,2,2,2,4,5,1,5,4,3,2,3,1,2,2,3,1,1,1,5,3,2,4,1,2,5,5,1,5,5,2,2,5,1,2,2,4,2,4,4,4,4,5,2,5,3,2,3,1,2,3,5,4,1,2,1,1,5,2,3,3,2,4,2,4,5,2,1,2,5,2,4,4,1,3,4,4,5,1,1,5,4,4,4,2,4,1,4,1,3,4,1,4,4,2,1,2,3,5,5,3,2,2,5,4,2,1,2,4,4,2,4,1,4,1,5,5,4,5,2,4,2,1,3,1,4,5,2,1,3,4,3,5,3,4,1,5,1,4,2,2,4,1,4,4,5,4,4,4,3,5,2,4,3,1,3,4,1,1,2,3,5,2,1,5,2,1,3,5,3,3,2,5,5,1,2,2,3,1,1,4,1,5,2,4,3,2,1,1,5,2,5,4,4,1,5,1,2,4,3,4,2,3,4,5,1,3,5,2,2,1,2,1,2,2,5,3,1,4,2,2,1,5,2,1,3,1,1,3,5,3,3,4,5,5,1,3,5,1,2,1,1,1,2,1,1,5,1,5,5,2,1,3,5,5,2,5,5,4,1,2,1,1,2,5,5,5,2,1,4,2,1,1,3,4,4,3,5,4,3,4,1,5,5,3,4,2,3,1,1,3,4,4,3,4,1,3,1,1,3,5,2,1,4,4,4,4,5,3,5,5,4,1,2,4,2,1,4,2,4,2,2,2,4,3,3,5,2,2,3,1,1,1,2,3,5,3,4,3,1,4,4,1,5,2,2,1,4,1,4,3,4,1,2,3,2,5,1,3,4,4,5,5,1,1,1,3,5,2,3,5,2,1,3,5,1,4,4,2,3,3,4,5,3,2,1,4,5,3,5,1,1,1,5,3,4,5,1,5,4,1,5,1,2,4,1,4,1,3,4,4,5,3,1,1,3,4,4,3,5,5,2,3,4,3,5,1,3,4,2,4,3,3,3,1,4,1,3,4,2,3,1,2,1,5,5,3,1,1,2,5,5,4,4,1,4,1,5,3,5,1,4,4,4,5,5,2,2,4,5,1,4,5,3,1,5,1,2,2,1,3,4,1,3,2,1,5,2,2,2,3,3,4,2,4,1,3,2,2,1,3,5,5,2,4,1,1,4,3,1,3,3,4,2,3,3,4,3,3,3,5,5,2,4,4,2,2,2,4,5,5,3,5,2,1,4,1,5,5,2,3,4,2,5,4,5,1,5,3,1,1,3,4,4,1,3,2,3,2,2,5,4,5,2,1,2,2,3,3,2,2,5,2,1,2,1,5,2,3,2,4,1,3,3,2,5,4,2,1,2,1,2,3,1,3,4,4,5,1,3,3,5,5,3,2,2,4,5,2,4,2,1,1,1,1,5,4,1,1,4,1,1,2,4,5,4,1,5,3,4,3,3,5,5,3,4,4,5,1,4,2,4,5,2,3,1,4,4,4,3,3,3,2,2,5,4,5,4,3,1,2,3,5,5,1,5,4,2,5,2,2,1,3,1,5,5,3,5,4,2,1,5,1,1,3,2,3,1,5,1,5,4,1,1,2,5,2,2,5,3,4,5,2,4,1,1,2,2,5,4,2,1,5,1,5,3,5,5,2,3,3,2,2,1,2,2,2,3,3,2,3,3,3,3,5,3,3,2,5,3,4,2,3,3,1,5,3,3,4,4,2,2,3,2,4,5,1,5,5,5,3,1,3,4,5,2,3,5,1,5,3,3,5,4,1,3,2,1,1,2,5,2,2,1,1,1,5,1,5,1,3,2,2,3,1,1,2,5,3,4,5,4,4,5,5,1,1,3,4,3,5,5,3,5,4,1,1,1,4,3,3,3,2,4,1,2,2,3,1,1,3,2,2,4,3,2,4,1,4,5,4,3,3,4,2,2,5,3,3,4,5,5,3,4,2,2,4,5,4,3,2,2,3,4,2,1,1,1,5,4,5,4,3,4,2,2,3,5,2,3,4,3,5,5,5,1,1,4,2,3,4,2,3,2,3,4,3,3,4,3,1,1,5,4,4,5,1,2,2,3,4,5,4,2,5,5,2,2,2,1,1,2,1,2,2,2,5,2,5,1,2,1,5,3,4,2,1,3,1,5,4,3,2,4,4,4,1,1,2,1,1,3,3,3,4,5,2,5,4,5,4,4,5,3,1,1,3,1,3,4,4,2,3,5,2,4,1,1,5,5,5,1,4,1,1,3,1,1,1,5,2,5,5,3,1,3,5,3,3,3,5,2,3,1,3,3,4,4,4,5,4,1,5,1,4,5,1,4,4,5,2,2,4,1,1,2,2,3,2,4,3,5,2,2,3,3,5,5,2,3,2,2,3,3,1,4,3,3,4,5,4,5,5,5,5,3,1,1,4,3,3,4,4,3,3,2,4,4,3,4,3,4,1,4,2,2,1,3,1,5,2,1,1,4,4,3,1,5,4,5,1,4,4,4,1,1,4,4,1,1,3,5,3,2,4,4,5,4,1,3,5,2,2,4,4,1,5,2,5,1,3,3,1,4,2,5,1,2,5,3,5,4,4,2,2,5,3,4,5,2,3,4,4,1,5,3,4,1,3,1,3,4,3,4,2,5,4,2,1,5,1,1,3,2,3,3,4,3,2,5,2,2,1,2,5,1,2,2,2,2,1,5,1,1,3,1,5,1,5,3,5,2,5,2,4,4,5,5,2,3,2,2,3,1,4,5,2,4,5,5,3,3,3,4,2,1,4,1,5,1,5,5,5,2,4,5,4,4,3,1,5,3,2,4,1,4,1,2,3,5,3,1,4,2,1,2,4,3,3,2,1,5,5,2,3,3,1,4,2,4,4,2,2,3,2,3,5,2,5,3,5,1,1,5,1,3,4,2,5,2,1,2,4,3,5,4,1,2,4,2,4,1,2,2,5,2,1,2,4,3,5,1,1,2,2,2,3,3,1,1,4,4,3,4,3,5,4,2,2,2,4,4,2,4,2,3,4,5,3,5,3,3,5,2,3,2,2,5,4,2,2,1,2,5,4,3,3,4,4,4,1,1,5,2,2,1,1,1,1,2,1,3,3,4,4,3,1,2,2,5,2,4,5,4,2,4,3,3,4,5,5,2,4,1,5,2,5,4,1,2,3,4,5,5,1,1,5,4,5,4,5,3,2,3,3,2,1,3,4,1,1,5,4,5,5,2,1,1,5,2,3,1,4,2,2,2,4,5,1,5,1,4,5,5,1,1,3,5,1,2,4,2,2,4,5,4,5,5,2,4,2,5,4,1,2,5,3,3,5,5,4,2,5,1,4,4,3,4,5,1,2,5,5,2,4,5,3,2,2,1,4,3,5,1,2,3,3,3,3,2,1,4,4,3,1,3,4,5,3,1,1,5,4,4,1,3,5,5,3,4,5,5,3,1,3,1,1,2,5,5,3,2,1,4,1,3,2,5,5,4,4,5,3,5,4,5,2,1,5,3,2,2,4,2,4,1,2,5,5,2,4,4,4,2,4,1,3,4,3,1,3,4,4,4,3,5,4,1,4,4,3,5,1,3,4,1,1,1,4,1,3,1,1,4,3,4,5,4,5,5,5,2,4,3,4,5,4,2,1,3,5,2,3,3,4,1,1,1,1,4,3,4,1,5,3,2,1,5,3,3,3,4,2,2,3,4,5,2,5,2,3,5,4,3,2,3,4,4,4,1,3,3,2,2,5,2,1,1,4,3,5,4,2,4,1,1,2,5,5,3,2,5,1,1,5,1,2,5,5,4,2,4,4,1,2,3,3,1,3,5,2,4,2,4,1,3,2,1,4,4,1,2,4,4,5,2,4,3,5,4,5,4,1,3,4,3,1,3,3,3,2,1,1,4,2,3,3,3,5,4,4,2,5,1,5,4,3,5,5,2,3,4,4,5,1,5,1,1,4,1,4,1,5,5,1,4,1,5,4,2,4,2,2,3,2,2,3,4,2,2,1,5,4,4,3,5,5,1,4,1,2,2,1,5,3,1,5,4,2,4,3,1,5,1,4,5,2,4,2,1,3,4,3,2,3,5,1,4,1,3,2,3,2,3,3,1,5,2,1,2,4,3,4,2,1,4,3,3,1,4,1,1,3,3,3,3,2,3,2,4,1,3,3,3,4,4,3,2,2,5,4,5,5,5,2,1,1,1,1,3,1,1,1,3,3,3,4,1,4,5,1,2,4,1,3,1,3,3,3,5,2,1,3,5,2,2,2,4,4,3,4,3,4,3,3,2,5,1,5,1,5,4,3,3,5,3,5,3,2,2,4,3,3,1,3,1,5,3,3,4,3,3,2,4,3,2,5,3,5,4,3,1,3,1,3,3,1,3,3,4,3,2,2,2,1,3,1,1,1,4,1,1,4,3,5,2,3,1,5,3,5,5,2,1,4,1,4,5,5,5,4,3,5,1,5,2,3,2,5,4,2,5,5,2,2,4,3,4,1,1,1,5,4,4,1,1,2,3,5,4,3,5,1,2,5,5,4,2,5,2,4,5,2,2,1,2,4,3,5,5,1,4,4,5,4,3,3,2,3,3,1,2,5,1,4,4,5,3,1,2,2,1,1,5,4,4,2,1,5,5,5,4,3,1,3,2,4,5,2,3,4,3,1,2,5,2,2,4,5,1,4,4,4,2,5,4,3,3,3,4,2,1,3,2,1,2,3,1,4,2,4,4,5,1,2,4,1,5,2,5,3,3,4,4,2,2,4,2,3,5,5,5,4,4,3,1,4,4,2,1,2,5,4,3,5,5,5,3,4,2,1,1,4,4,2,3,5,4,2,1,4,4,1,5,5,2,2,5,3,5,3,3,1,5,2,3,2,4,3,3,5,2,5,4,5,3,5,2,5,4,4,3,4,1,3,4,5,2,4,4,3,1,2,1,5,4,4,3,1,1,4,1,4,4,1,2,4,1,1,3,2,4,5,5,5,5,4,4,4,2,5,2,1,1,2,1,1,1,5,5,5,3,5,2,1,3,1,5,5,4,4,4,3,3,1,3,4,3,5,1,3,1,3,4,3,4,2,4,5,3,3,1,2,5,4,3,1,5,2,3,2,3,4,4,4,1,3,3,2,1,4,1,2,3,2,4,5,4,4,3,4,5,2,2,5,4,3,2,4,5,2,4,2,4,3,3,2,4,3,4,4,2,1,3,3,1,5,5,2,3,4,1,4,5,5,3,4,3,1,3,4,5,4,3,1,1,2,5,4,3,1,3,2,1,2,3,5,3,5,4,4,4,1,4,2,4,5,1,5,2,2,5,2,3,3,2,3,3,5,1,1,4,2,1,5,1,2,1,3,5,1,5,5,1,1,4,1,2,4,5,4,5,2,3,2,5,4,4,5,2,5,3,1,5,5,2,3,4,4,1,1,5,2,4,5,2,2,3,1,3,2,4,5,2,1,4,3,3,3,2,2,5,1,3,2,4,3,3,5,3,3,2,2,3,5,2,2,2,2,1,4,1,1,4,1,3,4,3,4,1,2,3,4,4,2,1,2,5,4,5,5,4,5,3,1,2,2,5,2,4,2,3,3,1,3,2,5,4,4,4,5,4,4,1,1,1,5,1,4,1,5,3,4,1,2,4,1,2,4,3,2,5,5,2,5,4,4,3,4,3,5,5,1,5,1,5,1,4,4,1,2,2,1,3,4,4,4,3,3,1,2,4,5,3,3,2,5,3,4,5,3,2,4,4,3,5,2,4,5,4,3,4,5,2,2,5,2,1,4,5,3,4,4,5,2,5,1,3,1,3,3,3,2,1,3,2,3,1,4,5,5,3,2,2,4,4,4,4,2,3,5,3,1,3,1,4,4,3,5,3,2,5,2,5,4,2,3,5,5,3,4,3,3,2,4,4,1,2,2,2,4,1,2,4,4,1,3,1,3,2,2,3,4,3,1,4,3,3,4,3,1,3,2,1,2,3,5,3,3,4,3,5,4,2,2,3,3,3,1,3,2,2,3,5,3,1,3,1,3,2,2,1,1,1,2,4,1,2,2,1,2,2,4,2,4,4,5,5,3,5,5,5,2,2,2,4,5,1,5,4,4,3,5,2,4,2,2,2,1,2,4,5,3,1,5,4,5,5,2,2,4,4,4,1,1,4,2,5,5,3,2,3,4,4,4,3,5,3,4,5,1,4,4,4,1,5,3,5,2,5,2,2,2,2,2,3,4,2,3,2,3,5,3,5,4,2,1,3,1,3,4,2,4,2,3,2,4,5,2,4,5,5,4,3,2,2,1,1,3,4,1,3,5,3,1,1,2,1,5,4,3,3,3,3,4,4,3,4,1,5,3,1,1,2,1,4,5,5,5,1,5,3,2,4,5,2,1,1,3,4,4,1,5,5,3,2,1,1,3,2,1,2,3,5,1,4,2,1,5,5,2,3,2,1,4,3,5,3,1,4,2,5,4,1,1,1,5,5,5,5,2,4,5,2,4,3,5,2,4,5,5,4,2,1,3,5,5,4,3,1,1,2,3,4,4,4,3,3,2,1,4,5,3,5,1,1,4,3,5,5,2,3,5,4,5,3,1,1,1,4,3,5,3,2,5,4,3,1,5,1,3,1,4,3,5,1,3,4,2,3,2,4,1,1,2,5,2,1,1,5,1,4,3,1,3,1,2,2,3,3,3,2,4,1,5,1,2,3,3,5,4,4,4,2,5,5,4,1,4,2,4,4,5,1,5,4,5,2,4,3,1,4,1,4,1,2,2,1,4,1,3,4,4,5,5,3,4,5,1,2,2,3,2,5,4,4,4,1,5,3,4,2,4,4,1,2,3,1,3,5,3,3,1,1,5,4,3,1,1,3,1,3,2,4,5,5,3,3,1,1,3,5,3,1,1,1,3,1,3,4,1,1,5,3,4,5,2,4,3,3,2,1,4,1,4,2,3,3,3,5,5,2,2,1,4,2,5,3,3,1,1,5,5,2,3,4,3,2,3,2,4,2,2,5,3,4,3,3,3,3,1,4,3,4,4,2,1,4,4,4,5,1,3,5,4,2,4,1,2,2,3,2,1,4,5,4,1,5,1,2,5,4,2,5,3,1,2,3,3,5,4,2,2,1,3,1,1,4,4,1,4,4,5,1,2,3,5,5,4,5,2,1,2,3,5,2,5,2,2,1,5,4,1,2,5,2,3,5,5,2,5,5,2,2,4,4,5,2,2,4,1,1,1,4,1,3,4,5,2,3,1,3,5,1,3,3,5,3,1,3,3,5,1,3,4,3,1,5,5,3,5,5,4,2,4,3,4,3,5,1,5,5,5,5,4,4,1,5,4,3,3,5,1,3,4,1,3,2,1,5,4,4,3,3,2,4,2,3,1,1,4,5,4,5,2,2,5,4,5,4,2,1,5,3,4,1,1,2,4,5,1,1,1,1,2,2,2,1,1,1,3,3,1,4,4,2,3,3,4,4,3,5,5,2,4,3,3,5,4,1,5,3,2,5,3,5,4,2,1,2,2,5,1,3,3,4,2,5,3,3,2,1,4,5,2,3,1,1,3,4,4,4,1,2,2,3,5,2,1,1,2,4,1,4,3,2,4,3,3,5,1,4,1,5,5,1,3,2,3,3,1,3,1,2,3,2,4,4,4,2,5,2,5,5,1,4,4,1,5,5,2,5,1,5,2,5,4,3,2,1,2,5,1,4,1,5,1,3,1,5,1,2,5,2,5,3,3,4,3,1,3,1,5,1,5,2,1,2,4,1,5,4,1,5,5,1,4,4,3,3,5,2,5,1,4,4,4,4,1,5,5,4,3,2,2,2,3,3,2,3,5,1,3,4,5,3,2,1,3,1,4,3,2,2,2,5,3,4,1,4,5,3,4,3,2,3,2,5,2,5,4,4,4,2,1,2,3,3,4,2,1,4,2,2,3,3,5,4,5,5,4,2,2,5,1,1,3,1,2,3,5,5,5,2,3,5,4,3,2,2,4,2,4,1,4,1,1,4,1,1,2,1,2,2,5,2,2,1,4,3,1,3,4,2,2,4,4,2,4,2,5,1,3,3,3,2,3,1,5,5,4,4,2,5,1,4,1,1,5,3,2,4,4,3,2,5,3,2,5,3,3,5,1,4,1,1,2,5,4,5,1,4,5,5,3,3,4,2,4,5,4,3,5,3,3,2,3,2,3,3,5,4,2,2,4,3,2,1,5,3,1,3,5,3,4,5,3,5,1,1,3,5,1,2,5,4,2,2,5,2,4,1,1,1,5,3,5,4,1,3,4,5,4,2,1,5,4,3,5,4,5,3,2,3,1,3,2,5,2,3,4,3,3,1,4,1,1,3,5,3,3,1,2,4,5,3,5,2,3,5,1,5,2,3,3,3,4,1,5,1,4,3,3,3,5,5,3,4,2,4,5,3,3,5,1,5,2,1,5,2,2,3,5,3,5,2,1,4,3,4,4,5,2,2,4,5,1,4,4,4,3,5,2,3,3,1,4,2,3,4,5,3,3,1,4,1,3,4,5,4,5,2,3,1,4,1,4,4,4,4,1,2,2,2,3,2,3,3,1,3,4,2,3,2,4,3,3,1,2,4,1,4,1,5,1,3,3,4,5,5,3,3,4,1,2,5,3,5,4,5,3,4,1,4,1,5,5,5,4,5,5,2,1,3,3,5,5,2,5,2,2,3,5,5,5,1,1,2,4,2,1,1,2,5,3,1,5,4,3,1,4,1,1,4,5,2,3,3,1,5,3,4,3,2,4,4,4,3,3,4,3,5,1,2,2,4,1,3,3,3,1,5,1,2,2,2,4,4,4,4,3,1,5,2,5,5,5,3,3,5,3,2,2,4,2,4,4,5,5,3,1,5,3,2,3,2,4,5,2,4,5,3,3,5,2,5,1,2,4,4,5,3,4,3,5,1,3,4,5,4,3,1,2,1,5,5,2,2,5,4,5,4,4,5,4,5,4,3,1,4,3,5,5,3,3,4,4,5,5,1,5,3,2,2,5,4,3,2,4,4,2,3,5,4,3,2,1,4,1,4,4,4,4,2,5,5,4,1,5,5,4,1,3,4,5,5,1,3,4,4,1,3,5,2,2,1,1,3,1,3,1,4,1,4,4,5,2,4,4,3,2,2,4,3,4,2,3,4,4,2,4,3,5,2,4,5,5,3,4,1,1,4,2,3,3,4,3,3,4,2,1,5,5,4,3,3,5,4,1,3,1,4,1,3,1,5,3,4,4,3,4,2,2,3,3,3,4,5,3,2,5,2,4,2,5,2,5,4,1,4,3,3,1,2,4,3,5,4,3,5,3,3,5,2,5,3,3,5,5,1,4,3,3,2,1,3,2,1,4,1,1,3,3,4,1,5,1,1,1,4,5,1,4,2,1,3,2,5,5,4,2,2,5,1,3,2,1,3,1,2,5,3,3,4,5,1,3,2,1,3,4,3,5,2,3,1,4,5,4,1,1,2,1,5,5,4,5,2,1,5,5,2,3,1,2,4,5,1,4,2,2,3,2,1,1,2,2,2,1,2,2,1,3,5,3,3,4,2,2,1,2,4,3,2,2,1,5,1,4,4,4,3,4,5,4,1,5,4,1,1,4,3,1,2,5,3,2,4,2,3,5,5,4,2,5,4,4,5,4,5,5,1,5,4,3,5,2,5,2,3,4,5,3,1,5,4,3,5,2,1,2,3,4,4,2,3,2,2,4,3,4,2,4,1,3,4,2,3,3,1,2,4,1,5,2,4,3,2,2,1,1,5,2,1,5,1,4,2,4,3,3,2,4,3,1,4,2,1,2,3,5,5,3,2,2,2,2,2,3,4,4,4,1,4,4,2,4,3,4,3,5,5,4,1,2,2,4,5,3,2,2,2,1,5,3,3,5,3,2,5,3,5,3,1,1,5,1,2,1,3,2,5,2,5,1,2,4,1,1,1,3,4,1,4,4,1,2,5,3,2,3,5,4,2,3,4,3,5,1,2,4,1,3,3,5,1,1,3,4,1,1,5,1,5,3,4,2,2,2,2,2,4,4,3,5,2,1,3,5,1,3,3,3,4,3,3,5,2,3,1,1,5,5,5,1,1,2,1,5,2,5,1,3,4,5,5,3,2,3,1,1,1,3,4,2,3,3,5,5,5,5,3,2,4,2,5,4,2,4,5,5,3,2,1,1,4,5,4,2,5,5,4,2,2,4,4,4,5,1,1,1,3,1,1,2,3,2,5,2,5,1,5,4,3,1,3,1,1,2,2,4,5,1,3,3,4,5,3,3,2,4,1,3,4,2,5,3,5,4,1,3,3,3,1,1,3,1,5,5,2,1,5,2,2,3,1,3,3,4,5,5,5,4,2,4,4,4,5,2,5,5,5,1,1,5,3,3,5,3,5,2,4,1,3,5,1,5,4,2,5,5,3,2,2,1,5,2,5,3,3,5,2,4,2,4,5,2,5,4,2,3,3,1,2,1,3,4,2,1,5,1,1,3,5,1,2,4,5,5,3,3,3,3,5,5,5,5,4,3,2,4,5,5,1,5,2,1,3,3,1,1,1,1,4,4,2,2,2,5,2,4,1,2,2,3,2,2,4,1,5,2,4,4,2,1,2,4,2,2,3,3,5,3,1,1,1,1,1,4,2,3,2,5,1,4,1,1,4,2,1,5,2,3,1,1,5,4,4,5,1,3,2,5,2,2,4,1,1,1,5,4,1,1,3,4,3,3,4,4,1,4,4,1,3,2,4,3,3,5,3,5,3,1,2,1,5,3,4,4,4,5,2,1,4,2,3,1,2,5,2,2,4,1,5,4,3,5,5,5,3,5,4,1,1,2,5,1,2,1,1,5,5,1,5,4,2,5,1,5,1,1,5,4,5,2,1,5,3,5,4,3,4,2,4,5,2,3,4,5,2,5,4,3,4,3,1,1,3,5,2,3,5,4,1,2,1,4,5,4,4,3,1,3,3,2,2,5,4,4,3,5,4,2,4,2,5,3,4,4,4,5,1,2,4,4,1,4,2,2,1,1,5,4,2,3,3,2,1,5,4,2,3,4,2,1,2,2,2,5,2,3,3,1,3,5,1,4,4,2,2,4,4,3,5,3,2,4,3,1,2,3,2,3,5,3,5,5,2,5,1,4,2,5,4,5,1,5,5,4,1,4,5,2,4,5,2,5,2,1,3,4,3,2,1,1,2,4,2,2,5,5,3,5,5,1,1,3,1,1,5,1,4,5,5,2,3,4,2,5,3,4,3,1,4,4,1,5,4,2,1,3,5,4,3,4,3,4,4,2,5,2,3,4,5,2,1,3,4,3,1,4,3,3,5,5,2,3,5,4,3,5,4,3,2,5,3,2,3,5,2,4,4,3,1,5,2,4,5,1,2,5,1,1,3,5,5,4,1,4,2,3,5,4,1,3,1,3,5,4,5,1,4,5,2,3,5,2,2,4,3,4,4,1,3,3,3,3,3,2,4,3,3,5,1,5,3,5,4,1,5,3,4,5,2,5,2,3,4,4,4,5,1,3,1,1,4,2,3,3,5,1,5,4,1,5,3,1,3,1,5,4,3,2,3,4,3,1,4,5,5,5,5,4,5,3,5,5,5,5,4,5,1,2,3,1,3,5,3,4,3,2,2,3,5,1,2,2,2,4,2,3,4,4,1,5,2,5,1,2,4,4,4,2,4,3,5,5,1,1,5,1,4,1,1,4,1,4,5,3,3,4,4,1,3,5,1,2,2,5,3,4,2,1,3,5,3,1,4,5,5,4,3,1,5,2,2,4,4,5,3,5,1,2,5,2,1,5,5,3,2,4,4,5,5,3,2,4,4,2,4,1,2,2,5,5,4,4,2,2,4,4,3,5,1,1,5,4,2,4,4,3,5,2,5,3,3,1,3,1,5,5,2,4,4,5,5,5,5,2,1,3,5,5,4,3,1,2,2,3,2,5,1,2,1,4,5,4,5,5,3,1,3,2,2,4,1,1,2,3,2,2,1,2,5,4,1,2,2,2,1,3,5,1,1,4,5,1,2,2,1,1,4,4,4,1,4,4,5,2,2,2,5,4,3,4,1,3,3,4,2,2,4,2,5,1,1,5,5,4,1,5,3,1,3,4,2,3,3,3,3,5,3,2,5,3,2,3,5,4,1,5,1,3,2,3,4,1,2,1,2,2,5,1,2,3,5,1,3,1,1,4,3,3,2,3,3,1,3,2,1,1,1,3,2,4,5,4,2,3,4,2,3,5,2,2,5,2,5,5,3,2,5,5,3,5,1,4,4,2,2,4,1,4,4,3,5,3,3,5,3,1,2,4,4,5,4,3,3,1,3,5,5,5,4,1,4,1,2,5,4,1,1,5,4,2,2,4,1,1,3,3,4,5,1,1,1,5,2,4,3,5,1,5,5,2,3,5,5,2,4,5,1,2,1,3,1,3,5,1,5,1,4,1,2,5,2,4,5,4,3,4,1,5,1,3,4,2,5,1,1,4,3,4,3,5,4,5,2,3,3,5,5,2,2,5,5,5,2,4,5,2,1,1,1,3,2,4,5,1,2,5,4,3,3,4,1,3,2,4,4,2,3,4,5,2,2,3,5,4,3,5,1,2,5,2,2,5,2,2,4,1,3,3,5,3,3,1,4,5,4,4,1,5,3,1,2,2,5,5,4,2,5,2,3,2,2,4,1,2,5,2,1,2,3,2,1,3,3,3,2,3,1,1,5,3,2,2,1,4,1,3,2,5,1,4,4,3,2,3,5,3,5,5,4,3,5,2,5,4,1,5,3,2,4,2,3,2,3,4,4,2,2,1,3,2,3,1,5,2,5,1,4,2,3,4,5,2,4,1,3,5,1,1,5,4,2,2,3,5,2,5,3,2,5,4,4,3,3,5,3,4,2,3,2,2,4,4,3,3,3,5,5,1,4,1,3,5,1,1,2,1,1,1,5,3,5,4,4,3,1,1,5,1,5,2,1,2,4,1,2,1,4,2,1,3,3,3,2,4,4,1,5,4,1,2,5,4,4,1,4,3,5,4,2,1,5,2,3,3,4,2,2,3,2,4,2,5,5,4,3,1,3,3,1,5,3,4,1,4,2,4,3,4,2,1,3,3,4,4,3,3,4,5,3,4,2,1,1,5,4,2,5,3,2,5,3,1,5,4,3,4,4,5,5,5,2,4,3,3,3,2,3,4,2,1,1,2,3,5,4,3,3,1,3,1,1,2,1,4,3,1,3,5,2,4,2,1,4,4,4,1,1,3,4,5,1,1,4,1,3,4,5,2,3,2,3,5,5,4,3,4,2,4,5,3,4,4,5,1,4,3,2,2,4,4,4,3,5,2,3,3,4,3,3,4,2,2,2,1,1,5,3,2,4,4,5,1,3,4,4,4,1,4,3,1,4,3,1,1,5,1,2,2,1,3,5,5,2,1,1,4,5,2,3,4,2,5,4,5,3,1,5,4,2,3,2,1,4,2,3,2,3,1,2,5,4,5,4,3,5,3,3,1,5,5,4,1,5,3,1,5,3,4,3,1,4,2,2,2,2,1,5,2,1,3,1,5,5,4,1,3,4,3,2,3,1,4,5,4,4,5,1,2,3,1,4,5,1,1,4,5,1,1,1,4,2,3,5,5,2,4,4,5,5,2,4,5,1,3,5,2,2,2,3,5,5,5,5,4,1,1,1,1,2,5,1,3,5,4,2,1,4,3,2,1,2,5,2,3,1,3,3,1,3,2,3,5,4,5,3,1,2,3,5,1,1,1,4,5,4,4,5,5,4,4,1,3,5,3,2,2,1,2,5,2,3,3,1,4,5,3,4,4,5,4,3,1,3,3,3,1,1,1,2,1,3,2,2,1,3,4,5,2,5,3,4,1,1,5,4,5,5,1,4,4,2,4,5,3,2,5,3,3,1,2,2,1,3,2,1,3,3,2,1,2,3,5,3,3,1,2,5,4,2,1,3,4,4,2,5,4,2,5,1,3,2,4,3,2,5,5,5,3,1,1,4,2,5,5,3,5,4,5,3,5,5,1,3,5,5,4,2,1,5,1,5,4,5,1,1,5,2,2,2,1,1,1,1,1,5,2,2,3,3,1,3,3,4,1,3,4,1,3,1,2,2,2,3,3,2,4,2,4,3,4,4,1,5,4,5,2,1,4,2,1,5,1,5,4,2,3,4,4,1,2,4,1,2,5,5,1,1,3,3,4,2,5,2,3,1,5,2,3,3,3,5,2,4,2,5,1,2,4,5,5,2,3,3,1,2,1,1,3,2,3,5,2,2,4,2,3,2,1,1,4,4,2,2,5,5,4,1,5,3,2,3,1,4,2,2,5,5,3,3,2,2,3,3,1,5,5,3,4,3,4,3,3,1,1,4,4,2,3,2,5,3,3,4,3,2,5,3,4,3,4,5,1,2,2,5,4,3,5,2,1,2,2,5,3,3,4,4,3,4,4,1,3,4,3,4,2,3,3,1,5,4,2,5,4,1,5,2,5,2,1,5,1,3,5,2,2,2,3,3,2,4,4,4,1,4,4,5,3,4,2,1,5,1,1,2,4,4,4,1,4,5,3,5,4,1,5,4,1,4,2,5,1,2,1,4,2,5,2,4,3,2,3,3,5,4,2,5,1,4,2,5,3,4,1,3,5,3,2,1,4,5,1,4,3,2,3,5,1,5,4,2,4,1,3,4,2,4,2,5,3,3,4,5,4,2,1,2,4,2,5,2,2,2,2,5,3,1,2,1,1,2,3,3,1,5,3,3,1,5,3,4,4,1,2,1,5,4,2,3,4,2,1,2,2,5,2,1,2,2,2,1,3,2,1,3,1,4,2,1,1,1,1,1,2,2,3,5,4,4,5,4,4,3,4,1,3,3,4,4,2,3,2,2,2,4,1,1,1,4,4,3,3,3,1,2,2,5,1,2,4,5,5,5,1,3,4,3,5,5,3,2,2,4,3,1,5,3,2,2,3,5,3,3,2,4,2,2,5,5,1,5,3,3,3,2,1,2,2,2,2,5,5,5,5,5,3,2,4,2,2,1,1,1,1,3,4,4,3,1,1,4,4,1,5,3,5,2,1,2,1,1,2,5,5,4,1,5,1,3,2,4,4,4,1,4,2,1,3,1,3,1,3,4,5,3,5,3,2,3,4,3,1,3,5,1,5,1,4,4,2,4,1,2,3,1,5,2,4,3,3,3,1,2,3,2,2,2,3,3,4,3,5,4,3,3,5,3,1,4,5,5,4,1,1,1,5,2,3,1,5,2,5,2,4,1,5,1,5,2,2,5,4,1,2,5,2,3,5,2,1,3,4,3,3,2,4,3,5,1,2,3,4,5,1,2,2,2,2,5,4,3,5,3,2,1,2,3,3,4,4,2,1,3,2,5,2,3,4,5,1,5,4,1,4,5,4,2,1,4,1,5,2,3,1,5,4,4,2,2,3,4,3,1,1,1,4,1,1,1,2,2,1,5,5,4,3,3,1,4,2,2,2,4,2,4,1,1,4,3,4,1,1,4,2,4,4,4,2,4,1,1,5,5,4,3,3,2,3,5,4,3,5,3,2,3,2,5,4,3,2,5,5,3,4,5,2,4,4,1,4,3,5,1,5,2,1,1,2,3,5,3,2,1,2,3,2,2,5,3,4,1,2,4,2,3,2,5,5,5,5,2,4,2,4,1,1,3,2,2,5,5,2,4,3,2,5,3,2,5,1,5,1,4,1,2,3,3,5,2,4,5,3,2,3,2,1,3,4,2,2,2,4,3,1,1,3,4,2,2,4,4,1,4,3,2,1,2,2,4,5,3,3,3,2,4,4,2,1,3,5,2,2,5,5,5,4,3,2,4,1,2,1,2,1,4,2,3,5,2,4,2,5,4,4,1,5,1,3,2,3,4,1,2,5,4,1,2,4,5,2,1,5,1,2,4,5,4,3,4,4,4,5,2,5,1,2,2,2,5,3,3,1,3,5,2,5,4,5,3,4,4,2,2,4,3,2,1,2,4,4,3,4,3,3,3,4,2,4,4,3,5,3,3,3,3,3,5,5,4,3,4,3,4,4,5,5,5,2,1,5,1,2,1,3,5,3,4,3,1,1,2,1,4,3,5,4,2,2,1,1,1,3,2,1,4,3,4,4,2,1,5,1,2,1,3,1,5,2,1,3,1,2,3,4,2,2,5,3,2,5,3,5,4,1,4,4,5,3,1,2,2,5,2,2,2,4,4,1,1,2,2,2,5,4,4,2,1,3,5,1,3,2,1,2,1,3,4,2,1,3,2,4,3,4,3,5,2,4,3,4,1,4,4,4,3,2,1,1,2,1,1,2,4,5,1,3,3,3,5,2,2,5,4,1,2,5,1,3,4,1,5,4,2,4,5,5,4,4,2,5,3,2,3,1,1,2,4,3,1,5,4,1,2,1,1,3,2,5,1,2,4,1,3,3,1,2,4,1,1,4,1,1,1,5,3,3,1,1,5,2,5,1,4,1,5,5,1,2,1,1,5,5,5,1,3,1,1,2,4,3,3,5,4,1,1,4,2,3,4,3,4,1,5,5,3,3,5,2,4,4,2,4,1,2,5,1,4,5,4,1,1,5,1,3,3,5,5,5,3,4,4,2,3,1,2,5,5,2,3,4,4,2,5,5,2,2,4,5,4,1,4,4,5,1,1,1,2,5,1,5,1,4,3,1,4,4,3,5,3,1,3,2,5,5,2,2,2,5,2,2,4,2,3,3,2,3,2,5,1,1,3,4,3,1,3,4,5,1,5,1,2,1,5,2,4,5,3,5,4,1,1,5,5,4,1,3,3,2,3,4,5,3,5,5,5,3,5,4,2,3,4,1,3,1,4,1,4,4,3,1,3,1,3,5,5,3,4,5,3,4,4,3,3,4,2,1,4,4,1,1,1,4,3,2,3,5,3,1,1,3,1,2,4,1,4,4,1,4,1,3,4,3,5,3,5,4,1,1,3,1,1,4,3,3,5,1,1,4,5,1,3,4,2,4,4,4,5,3,3,3,1,4,2,5,4,1,1,5,1,3,3,5,3,3,5,3,5,3,5,1,2,2,1,1,4,4,3,3,4,3,4,4,1,1,4,3,4,2,2,4,3,5,5,2,5,4,1,5,3,1,2,1,3,1,2,1,3,3,1,3,1,2,2,3,2,5,2,4,1,1,2,4,4,5,1,5,4,1,4,2,4,2,2,4,1,4,5,5,1,5,3,4,3,5,4,3,5,1,2,4,3,2,3,1,5,5,3,3,5,4,3,5,2,5,1,2,5,2,1,5,3,2,1,1,4,2,1,1,3,2,2,5,3,2,1,4,5,3,2,2,1,1,4,2,4,1,1,3,3,1,3,2,4,3,1,4,5,4,2,3,2,5,2,2,3,2,2,4,5,4,1,4,4,4,1,3,2,1,5,2,3,1,5,2,2,4,1,5,3,2,3,5,4,1,1,5,2,3,5,4,3,4,2,5,1,2,2,1,3,3,5,4,5,4,4,2,5,5,2,5,3,2,5,3,3,3,2,1,3,1,1,2,3,4,3,5,1,4,5,2,1,4,3,5,4,4,4,5,1,1,1,3,2,5,3,4,4,2,5,1,1,3,2,3,1,3,3,5,3,1,2,1,4,2,2,3,2,5,2,5,5,1,2,2,5,2,4,1,1,1,4,3,5,1,4,4,3,5,3,2,1,3,5,3,1,5,4,2,2,1,5,5,4,1,3,1,3,2,1,2,5,5,3,3,4,2,5,1,5,2,5,4,4,3,1,1,5,2,5,1,5,3,3,3,2,5,1,4,3,4,5,1,2,1,3,4,4,1,1,3,5,1,4,2,4,1,1,1,4,1,3,4,2,1,3,3,3,4,4,4,2,4,3,5,5,5,2,5,3,5,5,4,2,2,2,3,5,4,4,1,3,2,4,2,1,1,1,5,4,5,2,4,5,5,2,5,5,4,3,4,1,5,3,1,2,4,5,2,2,1,1,2,1,1,4,2,1,3,1,4,2,3,5,3,4,3,5,2,1,3,3,5,1,1,1,2,4,1,4,5,5,3,3,1,5,1,2,3,3,5,1,1,4,5,2,5,3,2,1,5,4,5,3,5,3,3,4,3,1,3,1,4,2,4,4,4,2,1,2,2,1,2,2,2,5,1,2,4,2,2,1,2,5,4,1,1,2,4,2,3,1,3,5,3,3,5,4,5,5,1,4,1,1,2,1,1,3,5,4,5,3,5,5,1,2,2,1,5,2,3,5,1,5,1,3,3,2,1,2,2,3,4,2,4,2,2,3,5,2,3,5,4,4,4,5,3,5,5,3,2,2,3,2,5,3,2,1,2,4,4,3,5,5,2,4,1,4,1,3,1,1,4,3,1,5,1,4,2,4,3,2,1,2,1,2,1,3,3,4,4,5,4,5,5,3,4,5,4,1,4,2,2,3,1,2,3,1,2,1,5,4,4,1,4,3,2,3,5,2,1,5,2,5,1,1,4,2,5,5,2,5,5,3,1,3,3,2,4,5,2,1,1,3,3,4,3,4,3,3,5,3,1,1,3,2,1,4,5,1,3,2,5,5,5,1,5,4,5,4,5,3,1,2,1,4,2,4,4,5,1,2,2,4,5,5,5,4,2,2,4,1,4,2,4,3,3,4,1,1,4,5,1,5,5,2,4,3,2,2,2,3,3,2,4,1,1,1,2,3,5,5,2,4,4,3,3,1,3,3,5,5,5,5,1,3,5,3,2,5,2,4,3,4,5,1,2,2,4,1,1,2,5,4,3,3,2,1,5,5,3,1,4,2,4,5,3,2,4,3,2,1,4,1,4,4,3,1,4,4,5,4,1,1,1,3,4,5,5,1,2,3,3,4,2,1,3,2,5,1,2,5,1,5,4,4,5,3,2,1,4,1,4,1,2,1,1,3,1,4,4,1,2,2,1,5,3,3,5,2,5,4,1,2,1,2,5,3,5,5,4,3,3,2,4,3,4,2,3,3,5,4,1,4,4,4,1,4,1,3,1,5,2,2,5,1,2,1,1,2,2,2,5,3,2,5,1,1,1,3,4,5,5,4,5,3,5,3,2,5,5,1,4,1,2,5,3,4,5,3,4,1,3,5,3,4,5,4,4,2,3,5,1,5,4,1,1,5,4,4,1,1,1,3,1,4,2,2,1,3,5,3,3,5,1,2,1,5,5,5,4,4,3,2,2,3,5,1,5,1,4,4,1,1,2,3,5,5,4,5,2,3,5,1,5,3,1,5,1,2,2,3,5,4,5,5,4,4,5,5,4,5,2,5,2,5,1,5,1,1,3,3,4,1,3,5,4,3,5,1,5,3,4,2,1,1,5,5,1,5,1,2,2,1,4,1,4,4,4,1,2,1,5,3,5,1,1,3,1,3,5,3,5,3,5,3,4,2,2,4,3,5,2,4,1,5,3,4,3,1,5,3,3,3,1,1,1,3,2,2,2,5,5,1,4,4,5,3,3,5,1,1,5,3,4,2,4,4,5,1,3,1,4,1,3,3,2,4,5,4,3,3,3,4,5,2,1,3,2,4,4,4,4,3,5,4,5,2,2,1,2,5,1,5,4,3,3,3,4,5,2,3,4,2,3,4,2,5,5,1,5,5,2,4,4,5,1,1,3,4,1,4,4,3,5,3,2,1,2,1,5,1,5,5,1,3,4,3,1,5,1,2,3,2,5,1,2,2,3,5,2,4,3,2,1,5,5,5,4,4,2,3,1,1,5,2,4,3,2,5,1,4,4,4,5,1,3,3,2,3,4,1,2,3,2,3,4,2,2,2,4,4,4,5,4,5,3,4,1,1,5,5,5,3,1,3,3,3,1,1,3,1,3,5,4,1,3,3,1,2,4,4,3,4,5,1,3,4,3,2,5,2,5,5,5,3,5,1,3,1,2,2,5,2,5,3,5,1,1,5,2,3,4,3,4,5,4,1,1,4,2,5,1,1,5,3,4,1,4,1,1,2,4,2,4,1,3,1,2,2,4,3,3,3,3,1,3,4,4,3,3,5,1,2,1,2,4,5,1,2,2,2,3,2,3,4,1,3,1,4,3,3,2,2,3,1,2,5,5,1,4,5,3,4,3,1,4,5,2,2,4,1,4,2,2,4,3,3,4,5,5,2,4,4,3,2,1,1,2,3,4,5,4,3,3,2,3,4,5,5,2,5,3,4,3,2,4,5,2,2,2,5,1,3,3,3,1,2,1,1,1,1,3,5,4,2,1,5,3,1,4,5,5,5,2,1,2,2,5,4,5,1,1,4,4,5,4,2,1,4,3,4,2,2,3,3,2,5,3,5,4,4,4,3,3,2,4,3,5,5,2,3,1,5,3,4,5,4,1,3,5,2,4,1,5,5,3,5,2,1,5,2,3,4,3,2,1,3,5,1,2,1,5,2,4,5,4,1,5,3,2,2,5,2,2,4,5,5,1,5,2,1,3,2,1,2,2,2,3,2,3,2,2,4,2,4,2,3,3,5,5,4,4,1,4,1,1,5,1,1,4,2,2,4,3,5,3,2,5,2,3,4,5,5,2,4,2,2,5,4,1,1,4,1,1,3,1,4,3,5,2,1,1,5,2,1,3,5,4,3,3,3,5,1,3,4,1,2,4,2,1,3,2,4,2,5,3,2,2,1,3,1,2,4,3,2,5,5,1,2,2,5,4,5,4,3,2,4,5,2,1,2,3,1,1,2,3,4,5,4,4,3,4,4,2,4,1,4,2,3,1,3,5,1,4,5,2,2,4,5,4,1,1,5,2,4,2,5,2,2,5,2,1,2,1,1,3,3,4,5,3,1,2,4,5,2,2,5,4,4,1,4,1,1,3,2,5,3,1,5,1,2,1,5,1,3,4,4,2,1,5,4,2,2,2,3,2,2,5,3,5,2,2,1,3,3,1,3,5,3,4,5,1,2,4,4,3,2,5,2,4,4,2,4,1,5,5,5,1,3,3,1,3,2,2,3,1,3,1,1,5,4,4,2,2,5,1,1,1,2,5,1,2,5,5,2,3,5,1,4,5,5,2,2,5,5,1,4,5,5,1,3,2,3,5,3,1,4,5,4,5,2,3,3,4,5,4,1,3,1,1,2,4,2,4,5,5,5,1,5,4,3,1,5,1,1,2,5,2,3,3,1,1,3,4,3,1,1,2,1,1,4,4,3,2,2,2,4,1,1,3,1,3,3,3,2,3,2,4,4,4,2,4,2,2,5,3,2,3,5,1,3,3,2,2,1,5,2,4,2,1,3,4,1,2,3,3,3,3,1,3,4,3,5,4,4,4,2,2,3,1,4,2,5,1,2,5,2,1,3,4,5,2,4,5,3,5,1,3,5,4,3,2,5,5,2,4,2,1,4,5,1,4,5,3,3,1,3,2,4,5,2,3,4,5,4,5,5,5,1,1,5,4,1,3,4,4,5,4,1,5,5,2,3,5,5,1,4,4,5,3,1,4,5,4,5,5,2,1,5,2,2,4,4,5,1,5,5,4,3,1,2,3,2,4,5,2,4,3,5,3,2,1,3,5,3,5,4,1,1,5,1,4,4,1,3,3,4,2,1,2,3,4,5,3,3,1,2,1,4,4,1,4,5,3,5,3,3,3,5,5,4,2,3,4,3,4,4,3,2,4,5,1,1,1,4,2,5,5,1,2,3,3,1,3,3,4,2,1,5,2,2,3,4,5,5,5,4,1,2,2,3,5,1,1,4,4,4,2,2,3,2,1,4,1,1,1,5,2,3,5,3,2,1,3,3,5,3,5,3,4,4,2,4,3,5,1,4,4,1,1,2,5,5,1,2,5,2,2,1,5,2,1,1,5,4,3,2,1,4,2,5,4,3,3,2,1,3,5,2,1,2,1,4,2,4,3,4,2,2,4,1,5,3,4,4,1,1,2,1,1,2,2,1,1,4,2,2,1,1,3,1,2,4,5,2,3,5,5,2,3,4,1,1,3,2,1,5,2,1,3,5,2,5,2,3,5,4,2,5,4,3,2,3,4,1,4,5,3,4,5,1,4,3,4,5,4,1,2,5,2,2,1,1,2,4,4,1,4,4,4,2,3,1,1,2,1,3,2,5,3,1,1,2,3,4,3,1,4,1,2,1,2,2,3,4,2,4,5,3,3,1,2,5,3,2,1,5,3,1,5,4,3,4,2,1,5,1,5,5,4,5,3,3,3,1,5,2,4,2,5,2,1,4,3,3,5,1,5,2,1,5,2,4,5,2,2,5,2,3,4,4,4,1,1,2,1,3,4,4,5,1,4,4,1,1,3,2,2,1,5,5,4,4,3,5,3,3,1,5,3,4,3,3,3,3,2,3,3,4,3,4,1,4,4,1,2,2,2,3,3,5,1,4,4,2,3,5,3,5,1,1,5,1,2,4,2,1,5,4,2,2,1,3,4,5,5,4,3,5,4,1,3,1,5,3,3,4,5,3,1,1,4,3,1,3,5,3,4,3,2,5,5,3,4,1,4,2,1,5,5,1,4,4,1,2,1,1,1,5,3,1,4,1,1,5,1,3,3,3,2,2,4,4,2,1,2,5,5,3,5,1,2,1,1,5,4,5,5,4,2,3,1,4,3,4,4,2,3,1,2,4,3,3,1,2,2,4,3,3,3,5,2,5,2,3,1,4,5,5,3,3,2,1,3,3,4,3,5,3,2,5,1,4,4,4,3,1,1,1,1,1,3,2,3,1,5,1,4,3,3,5,1,2,2,3,5,4,4,1,1,4,2,4,3,2,5,2,4,2,5,5,4,4,1,5,2,2,3,5,2,2,1,2,5,5,5,1,2,5,5,1,4,1,4,2,2,3,1,3,4,4,5,3,4,5,3,1,5,2,4,4,1,3,5,3,5,4,5,5,2,4,2,4,3,2,3,2,5,4,1,4,5,4,2,1,5,4,1,5,5,5,4,1,5,4,2,5,4,4,3,1,4,3,2,5,4,1,5,1,4,2,4,4,2,2,3,3,5,5,2,3,4,2,4,4,1,1,4,1,4,4,1,5,4,3,2,2,1,3,2,4,3,3,4,2,4,5,2,1,1,2,2,1,4,2,2,5,4,3,4,4,1,2,3,4,5,1,5,4,4,1,1,2,3,3,3,2,2,2,3,4,1,3,4,3,2,4,1,2,4,4,5,4,4,3,5,1,5,5,5,3,1,3,5,4,2,5,2,1,4,4,3,2,1,4,3,3,1,2,5,2,5,3,4,3,5,5,4,4,5,1,2,4,4,5,3,3,2,2,1,2,5,4,4,4,3,3,5,4,1,2,2,1,1,5,3,2,2,2,3,4,5,1,3,1,4,2,1,3,5,2,5,5,5,2,2,5,5,3,4,4,3,4,3,2,2,5,5,2,3,1,2,4,3,4,5,5,4,2,4,1,2,3,1,5,4,2,2,1,3,4,2,4,1,1,4,2,1,2,4,2,3,3,3,3,1,4,1,3,3,3,1,1,5,2,2,2,2,1,1,4,4,1,1,3,3,2,1,1,5,1,4,2,4,2,2,4,1,2,3,5,2,2,5,3,2,5,2,2,2,2,3,2,2,4,1,2,5,5,3,1,1,3,3,5,2,1,1,2,5,3,2,3,3,4,1,5,4,4,4,3,1,4,2,2,3,2,4,5,3,5,4,3,5,2,4,4,3,3,4,5,5,4,2,2,3,5,3,1,5,3,5,2,2,3,1,5,1,1,4,1,1,2,2,4,2,3,4,5,2,3,5,2,4,5,4,5,4,1,2,2,4,3,4,2,5,5,2,3,4,2,1,5,5,4,2,4,3,4,3,5,5,3,4,2,2,1,1,5,4,3,1,4,5,3,4,3,3,3,4,1,1,5,2,5,2,5,5,5,3,2,4,4,4,4,2,1,5,2,1,4,1,1,1,4,5,3,3,2,5,3,1,4,2,3,4,3,2,4,2,4,4,5,3,1,5,4,3,3,4,4,2,3,3,1,1,1,1,3,3,4,3,1,3,3,4,4,1,5,1,1,4,1,5,3,5,1,5,3,5,2,1,4,2,3,5,1,4,2,4,1,4,4,3,1,2,5,4,3,4,5,5,3,4,1,5,5,2,5,2,3,5,3,4,4,5,4,5,4,1,5,2,3,5,3,2,2,3,3,2,5,3,1,3,1,4,4,2,5,5,1,3,2,2,1,5,3,5,5,2,3,3,4,4,3,1,3,2,3,1,3,3,1,4,4,5,2,4,3,2,2,4,1,2,1,2,4,4,2,1,4,3,3,4,2,2,2,1,2,1,3,2,3,4,5,4,1,1,2,1,3,3,1,4,5,4,5,4,1,1,1,5,3,3,2,3,3,4,5,3,1,3,1,1,5,1,1,4,4,4,4,4,4,5,4,4,3,4,4,4,1,4,4,2,4,1,1,1,4,3,5,1,2,1,1,4,1,2,1,1,1,2,3,5,1,1,2,1,3,1,2,4,4,3,1,5,1,1,5,4,5,5,3,4,5,1,2,2,1,4,5,1,1,1,4,3,1,4,5,2,4,5,3,1,3,2,1,4,5,2,5,2,5,5,4,3,3,3,4,5,4,5,2,3,2,5,5,5,4,3,3,4,3,3,5,5,2,2,3,5,4,2,2,5,5,3,3,4,1,2,1,1,2,2,4,1,5,2,3,4,5,5,2,1,1,1,2,3,5,3,1,4,1,3,3,1,5,3,3,5,4,1,4,5,3,1,1,1,4,1,5,1,3,3,1,2,3,3,4,1,3,4,2,1,1,3,4,3,1,3,5,5,3,4,2,3,2,3,3,4,2,3,5,2,1,4,5,3,1,2,3,2,5,2,1,4,5,5,2,4,3,2,3,1,5,2,2,2,2,5,1,2,1,5,2,3,5,5,4,1,3,5,5,1,4,3,1,1,1,1,3,4,1,4,2,5,2,1,3,1,3,4,4,4,1,3,5,4,4,5,2,5,3,1,1,1,4,3,4,2,2,3,2,3,5,1,1,5,1,2,4,1,1,2,1,1,3,5,1,5,2,3,1,3,4,1,1,2,5,3,1,5,3,3,4,4,1,5,2,5,2,1,5,2,4,3,4,2,4,4,5,1,2,2,4,1,4,4,4,3,5,4,2,2,2,3,3,4,4,5,5,4,2,4,5,2,2,2,4,2,3,3,1,1,1,2,3,2,4,2,5,4,2,4,4,2,4,1,4,5,5,5,3,2,2,2,3,2,2,4,3,1,2,3,1,1,3,2,1,3,3,4,3,5,1,3,4,5,4,4,1,1,1,5,2,3,5,2,4,1,3,4,2,1,3,1,4,3,3,3,5,1,3,1,4,1,4,2,4,3,1,3,4,3,3,3,3,3,3,4,1,4,1,2,4,1,2,2,5,5,4,2,3,1,2,2,5,3,2,2,2,1,3,3,3,3,5,1,4,2,2,2,2,4,1,4,3,2,2,3,1,2,4,5,5,4,4,5,3,1,1,3,3,1,2,3,2,2,4,2,1,2,5,4,3,3,2,3,5,2,1,3,1,2,4,1,5,2,2,3,3,1,4,3,3,2,3,3,5,2,2,1,4,5,2,2,4,1,2,4,2,5,1,3,3,1,2,4,1,1,1,5,1,4,5,1,1,1,5,2,5,3,2,4,2,4,4,3,3,1,5,3,2,4,1,1,1,4,5,4,2,3,1,4,4,1,5,3,2,4,5,3,2,1,2,3,1,4,5,5,4,2,3,2,3,5,5,2,5,1,5,5,2,1,5,2,2,2,3,3,1,2,3,3,5,5,4,3,5,5,5,3,1,3,2,4,5,1,5,3,5,5,3,5,2,4,2,5,3,5,2,2,1,2,4,5,1,5,5,5,4,3,2,4,4,3,4,5,4,4,5,3,3,1,1,1,3,3,4,4,4,2,1,3,5,3,3,4,1,1,1,5,3,5,3,2,1,3,2,2,5,3,3,5,1,1,3,2,4,1,4,2,1,1,2,4,5,5,3,3,4,2,5,4,5,2,3,3,3,5,5,2,3,4,5,4,3,2,4,2,1,4,3,1,3,5,4,4,2,5,5,2,3,1,5,4,2,3,5,2,4,4,2,1,3,5,4,3,3,4,5,3,3,1,5,1,4,4,1,1,5,4,1,4,3,1,1,1,1,3,5,1,5,5,2,1,2,2,3,4,1,5,1,4,5,2,2,4,5,2,2,2,1,5,3,2,2,3,3,5,4,5,3,5,5,2,2,2,2,2,5,5,5,3,1,5,5,1,2,5,2,4,3,1,2,4,5,5,4,1,4,5,3,1,5,3,2,1,2,2,3,5,2,4,2,2,2,5,1,5,5,1,5,4,5,3,5,3,5,2,4,5,4,3,1,4,2,1,4,4,4,4,2,4,2,3,4,1,3,2,4,2,1,2,1,1,1,1,3,3,1,5,1,2,3,5,4,4,3,3,5,4,2,3,1,1,2,2,1,5,5,3,1,2,5,3,1,4,4,1,2,1,3,3,5,3,2,1,1,5,5,3,4,3,2,3,2,1,4,5,5,1,1,4,3,4,5,2,1,3,5,1,2,1,4,1,3,4,3,4,3,3,4,2,5,4,3,5,2,2,5,1,1,3,5,4,3,3,3,5,5,5,3,4,2,4,2,3,5,2,3,2,1,5,5,3,3,3,1,1,5,2,4,4,5,5,3,5,2,3,1,2,1,2,4,4,5,5,3,2,5,5,4,3,3,5,4,5,4,5,2,3,1,4,4,1,1,4,5,3,5,2,3,1,2,4,3,2,5,2,4,5,5,1,4,5,3,4,1,5,3,5,5,5,5,3,3,5,3,3,2,1,5,2,3,1,4,5,1,2,3,4,3,5,3,1,3,1,2,1,1,5,4,3,4,3,3,3,1,4,3,2,4,3,4,5,3,3,5,2,2,1,2,2,2,1,5,1,2,2,1,2,5,4,5,4,2,4,4,1,2,5,1,5,5,5,1,5,1,2,2,2,2,3,4,5,1,2,5,3,1,3,3,3,2,2,5,5,4,4,5,5,4,2,2,1,2,5,5,5,4,5,5,1,2,2,5,1,4,2,5,4,2,3,3,3,3,3,5,3,3,1,5,5,1,5,3,1,2,2,1,2,3,4,3,5,2,2,2,2,4,5,3,1,4,5,4,1,2,3,1,2,4,5,5,1,1,5,3,3,3,3,2,4,5,1,2,2,5,4,3,4,5,3,1,5,3,2,5,2,4,2,3,3,4,3,5,4,1,1,4,1,1,3,4,5,1,1,1,3,2,4,2,1,5,3,2,5,2,5,4,5,2,4,1,5,3,4,2,4,3,5,4,3,1,2,3,4,4,1,2,3,2,4,5,1,3,3,3,1,5,4,1,4,4,4,3,1,4,4,5,2,5,1,3,4,2,3,1,3,5,4,5,2,2,5,2,3,3,2,3,5,4,2,5,5,5,4,5,5,3,1,4,1,5,2,3,5,4,4,5,1,5,2,4,3,1,3,2,2,3,4,5,5,3,3,2,3,4,1,2,4,5,3,3,1,2,2,1,4,4,5,3,2,4,3,1,5,2,1,5,3,4,4,2,2,5,4,1,4,4,2,1,5,1,5,4,4,4,5,2,2,2,3,4,1,2,1,5,4,3,3,4,2,4,2,1,3,2,4,1,4,1,4,4,4,5,2,2,2,4,1,2,1,1,3,3,5,2,5,4,4,2,1,4,1,4,5,2,4,4,2,3,5,2,2,5,5,1,5,4,1,1,3,5,5,5,4,1,2,4,3,3,4,2,2,5,5,5,3,2,1,2,2,4,2,5,3,3,3,4,2,3,2,2,5,3,5,2,1,5,2,4,4,1,5,2,5,1,1,5,2,4,1,4,2,2,1,4,5,4,4,3,4,2,3,3,4,2,2,3,5,1,2,1,1,5,4,1,3,3,5,3,2,5,5,3,3,2,2,1,2,2,5,5,3,4,2,2,2,4,2,4,2,1,4,1,2,5,2,1,4,2,2,5,1,3,3,2,4,4,4,4,5,2,1,3,3,5,2,3,3,3,2,5,2,5,1,1,3,3,2,3,4,5,2,2,3,1,3,3,3,2,1,3,1,4,1,1,4,2,3,4,5,1,2,4,3,2,3,5,3,5,4,4,5,3,4,1,3,3,4,4,5,4,1,3,2,3,2,3,2,1,4,2,2,3,5,3,1,4,1,1,2,3,5,5,5,1,1,3,4,3,5,4,2,2,1,5,5,3,2,3,4,5,3,1,2,5,3,5,4,1,4,3,1,4,2,5,3,2,3,2,3,1,5,1,4,3,1,1,2,5,4,5,1,5,1,5,4,5,4,5,3,4,3,2,5,5,3,4,2,1,4,2,5,2,1,2,3,5,2,2,4,3,2,5,1,3,4,2,1,1,3,3,1,2,2,3,4,4,2,1,4,3,3,4,1,2,5,2,1,5,2,4,4,3,4,5,3,5,1,1,5,1,1,4,5,4,2,5,3,4,5,1,4,5,2,3,5,2,4,5,2,4,4,4,3,2,2,3,4,1,1,4,2,2,5,1,2,5,4,2,1,4,3,1,3,4,2,3,1,2,4,4,3,4,1,3,2,2,1,1,3,3,4,5,5,3,5,4,4,2,3,5,3,5,1,3,3,1,3,3,5,2,2,1,5,3,5,4,5,3,1,5,2,1,3,2,5,1,5,3,3,5,5,3,3,1,2,5,5,5,2,1,5,4,2,5,1,1,2,2,1,1,3,3,5,5,2,4,4,4,5,4,3,1,5,3,2,1,2,2,4,1,1,5,2,2,5,3,3,5,3,5,2,2,4,1,1,4,4,5,4,3,2,1,3,1,5,4,1,5,2,5,1,4,2,5,1,1,4,1,5,5,4,5,5,2,5,3,2,4,3,4,3,4,4,2,3,3,4,1,4,4,5,3,1,3,5,3,5,5,3,2,4,1,5,3,5,1,2,4,5,3,1,2,2,5,3,3,3,5,5,2,2,2,2,5,1,2,2,3,2,1,1,4,3,4,2,4,5,4,2,4,1,5,4,4,3,3,3,2,2,3,4,3,3,5,2,1,1,3,3,2,2,2,5,1,4,1,3,4,5,2,4,5,2,3,2,2,3,1,2,3,5,2,5,5,1,2,2,4,2,5,2,2,2,1,2,5,2,3,2,3,2,3,5,3,3,4,4,5,4,2,2,3,2,1,2,3,5,4,1,1,5,5,3,3,3,4,4,5,5,5,5,4,2,4,2,2,1,1,4,2,3,5,2,3,3,1,5,4,5,2,1,5,5,3,2,1,2,2,2,2,5,4,3,3,5,1,4,5,4,2,5,5,4,2,4,3,3,5,1,4,2,2,3,3,4,3,3,2,3,1,3,4,4,1,5,5,1,3,5,4,5,4,3,2,4,4,4,1,1,4,5,4,3,4,1,2,4,2,5,4,1,5,5,1,3,1,3,1,3,5,3,3,3,2,1,1,5,1,4,1,2,3,4,5,4,3,5,5,5,4,4,1,3,5,4,3,5,5,3,5,3,2,1,3,4,2,1,2,4,5,2,5,1,2,1,2,2,3,2,4,3,1,5,2,1,4,4,3,2,4,2,2,4,5,4,2,2,1,2,4,3,5,1,4,4,1,4,1,4,2,2,4,2,3,3,2,1,2,2,3,2,4,2,1,1,4,5,3,2,2,1,4,5,4,1,4,3,2,4,1,1,2,3,2,5,2,5,1,5,4,4,3,4,1,1,4,2,2,3,1,3,5,4,1,4,5,1,5,1,1,4,3,5,4,3,1,5,3,2,2,3,4,5,5,2,2,3,3,1,4,1,4,3,3,4,2,1,3,2,3,3,1,2,4,3,2,3,3,1,3,5,3,3,3,1,2,4,1,3,2,5,2,3,1,4,3,1,4,2,2,5,2,2,2,5,1,1,2,3,2,3,5,5,5,5,2,4,2,3,3,5,2,4,2,1,5,1,3,3,4,2,5,2,4,3,5,5,1,4,5,1,4,1,5,3,4,5,1,2,4,4,4,1,2,2,5,4,2,5,4,4,2,4,2,5,4,2,4,2,2,1,2,1,4,2,4,1,2,4,1,1,4,3,1,1,5,1,3,3,1,2,5,4,1,3,1,3,3,5,1,2,1,2,2,3,5,5,5,1,1,4,2,1,2,2,1,4,3,2,1,3,4,5,2,3,3,3,2,2,5,4,3,5,5,5,1,4,4,4,5,4,3,4,5,2,2,2,3,4,4,2,1,1,5,1,5,1,4,4,2,5,3,2,3,3,5,2,3,3,4,4,5,3,1,5,1,2,2,5,1,5,2,2,2,2,2,1,2,1,1,5,1,2,5,2,3,4,3,2,4,5,3,1,5,2,5,4,2,2,1,3,2,2,3,3,5,5,5,2,5,4,3,2,5,4,3,1,2,3,2,4,1,1,4,3,2,2,2,3,2,4,3,2,5,2,5,3,2,3,1,4,4,2,4,2,1,3,1,1,2,4,4,5,1,2,2,3,3,1,4,2,1,3,2,2,2,4,5,2,1,2,1,1,5,5,4,4,4,1,3,3,4,3,1,1,1,4,4,2,2,4,1,4,3,4,1,1,5,4,5,3,4,3,1,2,2,2,2,2,4,4,1,3,5,1,3,4,4,5,4,2,4,1,5,2,3,5,1,5,2,2,5,5,5,1,4,1,1,4,3,5,3,2,4,3,3,5,4,5,2,5,4,4,4,5,3,5,4,1,2,2,2,3,4,4,3,4,1,3,3,2,4,5,5,1,2,5,2,2,5,2,5,5,4,4,4,1,1,4,5,4,5,2,3,1,3,3,4,5,1,3,5,1,3,1,4,5,3,1,2,4,2,2,5,2,4,2,4,1,4,2,4,4,3,4,2,2,4,3,2,2,4,3,3,4,3,5,2,5,3,3,5,4,2,5,2,5,4,3,4,2,1,2,3,4,4,3,4,3,3,2,4,2,5,5,4,2,4,5,1,1,2,4,4,3,1,1,3,1,2,2,2,5,2,3,2,5,3,2,1,3,4,1,3,2,1,5,4,3,4,4,1,5,5,5,3,2,3,1,4,5,3,1,2,1,3,3,2,1,1,3,3,2,5,5,1,1,2,1,5,4,5,5,5,4,3,5,4,1,5,4,2,3,4,2,3,2,5,1,5,4,3,3,3,4,5,4,3,5,3,2,3,3,2,3,3,2,1,5,2,1,2,4,2,3,3,4,5,5,2,2,1,5,3,3,5,2,1,1,2,2,2,5,5,5,4,4,4,2,3,3,4,1,4,1,2,3,3,3,4,4,1,4,3,3,1,5,4,3,5,4,4,1,4,5,5,4,5,4,4,5,3,2,3,3,1,5,1,3,5,1,5,1,4,3,2,1,3,4,1,5,5,5,5,4,1,5,3,3,4,1,3,4,5,2,2,2,3,3,5,5,3,4,3,4,1,2,5,4,2,2,1,3,5,1,3,1,3,5,4,2,3,2,2,3,3,2,4,3,1,3,2,5,3,4,5,5,2,1,2,5,5,4,1,5,3,5,1,2,5,5,3,1,5,4,1,2,3,2,3,3,1,5,2,4,4,4,5,2,2,2,2,4,2,4,5,1,4,1,2,2,1,5,4,1,3,3,5,4,5,5,4,3,3,5,3,2,3,2,5,5,1,1,1,2,2,1,4,3,1,2,4,3,2,4,5,3,1,3,3,4,4,5,3,5,2,4,4,4,3,2,3,1,2,1,4,4,2,1,1,1,5,4,5,4,2,2,2,4,2,1,5,4,3,3,1,5,1,3,2,2,2,2,5,5,2,4,5,2,5,5,3,5,3,2,1,1,2,4,4,2,1,2,2,4,1,2,5,4,3,3,4,1,3,5,5,1,2,3,2,5,2,3,3,4,1,3,3,5,5,5,2,1,4,2,1,5,5,5,3,5,4,1,2,5,1,2,2,4,4,5,3,5,2,3,4,1,4,1,4,2,1,2,4,5,2,3,1,1,5,3,5,5,2,4,3,1,4,3,2,4,2,4,2,4,5,2,2,2,1,1,4,2,4,5,4,4,4,1,2,5,2,4,3,3,3,5,1,2,3,5,2,5,2,1,4,4,1,5,5,5,3,3,5,3,1,4,5,3,2,2,4,1,5,3,4,2,4,5,4,2,2,3,4,2,5,2,2,1,3,3,2,4,2,2,3,2,2,5,3,5,2,5,5,4,4,5,3,3,4,1,3,1,4,4,4,1,5,2,2,3,3,2,1,4,4,1,2,4,2,4,1,1,5,5,4,1,4,4,3,1,4,2,4,5,5,1,1,2,4,2,4,1,2,1,1,2,1,5,5,2,1,1,1,4,5,3,5,5,5,2,3,4,4,5,1,2,3,4,5,1,1,2,3,3,3,5,4,2,3,2,3,2,3,1,5,4,5,4,2,1,5,3,4,1,2,3,2,1,2,4,1,1,3,5,1,1,4,2,4,3,1,1,5,3,1,3,4,5,5,5,1,1,3,2,4,5,2,3,5,4,4,2,1,1,2,1,3,4,1,4,4,1,3,1,3,3,4,3,2,1,2,3,3,1,1,4,2,4,1,1,3,4,5,3,5,2,1,1,2,5,4,3,3,4,1,4,5,2,3,5,2,4,2,3,2,5,3,3,1,2,4,3,5,1,2,5,1,5,1,2,2,5,4,4,4,2,5,5,1,3,5,3,5,2,2,2,4,4,2,2,4,5,3,4,2,5,3,5,1,1,1,5,3,1,1,3,3,1,1,1,1,1,2,5,1,2,3,3,4,3,3,4,1,1,4,1,3,1,5,5,5,5,1,1,3,2,1,2,4,3,4,4,1,4,4,4,1,2,1,4,5,5,3,4,5,4,3,2,1,2,5,2,1,4,1,1,5,2,4,5,3,4,4,4,4,4,5,2,3,5,1,4,3,5,2,2,3,3,3,5,2,4,2,5,3,4,4,3,2,3,4,4,5,5,2,5,3,1,1,5,3,5,5,4,1,2,5,3,4,2,5,2,2,5,4,1,4,1,4,2,4,4,2,2,1,2,4,4,2,1,3,5,1,4,3,1,5,5,4,2,3,1,4,5,4,1,4,2,1,1,2,2,5,4,2,2,2,2,3,5,1,3,4,2,5,5,4,4,4,4,4,4,5,5,1,5,5,5,5,5,5,4,1,4,2,1,3,3,3,3,3,3,5,2,3,1,5,3,5,1,2,2,1,5,5,3,1,5,1,1,4,1,1,3,3,2,1,5,5,2,5,1,4,2,1,1,1,3,4,5,3,5,5,3,3,1,2,5,4,4,3,4,3,4,3,4,5,1,2,1,5,4,5,1,1,1,5,4,3,4,4,3,1,2,4,1,1,4,5,2,5,3,2,3,1,4,3,1,1,1,4,2,2,4,4,2,2,1,1,2,2,5,1,4,1,5,1,3,1,3,2,3,4,3,4,4,1,2,4,2,1,5,5,4,4,1,3,3,3,4,1,3,2,3,3,4,5,2,2,5,4,5,1,2,1,2,4,4,1,5,4,1,5,4,3,5,2,3,2,1,3,5,4,1,4,5,5,3,3,5,1,2,4,2,4,4,5,3,2,5,2,2,4,5,1,4,1,3,4,4,2,4,2,1,5,4,4,4,1,5,2,2,3,4,1,5,2,5,5,1,2,2,5,2,1,2,5,5,4,5,4,3,3,5,4,5,4,1,2,2,3,1,2,3,4,5,2,5,1,3,3,5,1,5,2,5,5,1,1,2,5,3,2,4,5,4,5,2,2,2,4,3,5,3,1,5,2,2,2,2,2,1,2,3,1,1,2,5,2,5,1,2,2,3,2,4,1,2,3,1,1,4,2,2,3,2,5,1,4,5,4,3,4,4,3,1,1,4,5,1,5,4,1,5,3,1,3,2,4,3,5,1,5,3,5,4,2,3,3,1,2,3,4,5,4,1,4,5,3,5,2,3,5,5,3,2,3,5,4,1,1,5,4,2,3,4,3,5,3,1,4,2,2,3,1,4,4,4,4,4,3,3,3,1,4,5,5,2,1,5,2,2,2,4,1,5,4,2,1,4,4,1,4,2,2,1,3,4,5,3,3,1,4,2,1,2,5,4,2,2,1,2,1,1,4,2,5,1,5,1,1,1,3,2,5,4,1,2,1,4,5,4,2,4,1,3,1,3,5,1,1,5,5,4,4,2,5,4,2,1,3,4,3,2,2,2,3,3,4,3,4,4,1,3,1,4,1,1,5,1,5,5,1,3,4,5,3,3,2,3,1,3,2,1,1,2,3,1,4,4,1,3,3,3,2,4,3,5,1,5,4,5,3,4,2,5,3,2,4,1,5,5,4,5,4,2,3,4,2,5,1,5,2,3,2,4,3,2,1,4,5,4,2,3,3,3,4,4,2,3,1,2,3,5,2,2,5,3,3,2,5,2,1,1,4,3,5,1,1,3,1,3,2,1,5,2,3,2,3,2,3,3,2,2,4,1,1,3,1,1,3,4,4,3,3,1,2,1,3,5,5,1,2,2,2,2,5,4,3,4,5,4,3,3,3,4,3,1,4,1,1,3,3,5,3,1,5,5,3,1,3,2,2,1,1,4,1,2,3,5,2,2,5,1,4,5,2,2,1,5,1,2,1,2,1,1,5,3,4,3,3,3,1,1,3,5,1,5,5,5,5,5,4,5,2,4,5,4,2,1,2,2,2,4,3,2,2,5,1,4,3,2,1,1,5,3,5,5,3,1,2,2,4,3,5,3,1,5,4,1,4,3,1,5,4,3,4,3,5,4,3,4,3,5,3,3,5,4,4,5,3,3,4,2,5,1,1,2,3,2,5,5,3,2,5,4,1,5,4,3,3,4,5,2,1,3,3,4,5,5,2,5,3,4,1,2,5,4,3,3,5,5,2,1,3,1,2,3,2,4,5,1,1,1,5,3,5,4,4,5,1,2,5,4,4,1,5,4,2,4,2,2,1,2,1,1,4,2,3,2,5,3,1,3,1,4,1,5,5,5,1,4,1,4,4,3,2,4,2,3,2,3,1,4,3,5,3,3,5,1,2,2,1,1,1,3,1,3,3,4,4,4,2,1,5,4,3,1,3,3,5,1,3,3,1,2,4,5,2,3,4,3,4,4,2,5,2,1,5,3,4,3,2,5,1,1,3,4,2,1,3,4,1,2,5,1,1,3,1,1,4,2,1,4,1,4,5,5,3,2,1,2,4,1,3,5,2,4,1,1,3,4,3,4,3,5,5,3,4,3,2,5,1,3,2,4,5,2,3,1,2,3,3,5,4,2,1,3,5,3,4,4,5,2,2,5,1,1,2,4,4,2,3,2,1,1,4,5,5,2,4,4,5,2,2,3,3,3,1,2,5,1,3,4,1,5,5,3,5,4,2,5,4,1,2,5,1,1,3,5,1,5,3,4,2,3,5,4,5,4,5,1,2,2,3,2,3,1,1,2,2,2,2,5,1,2,3,4,5,1,1,1,4,3,1,5,5,1,5,5,1,3,2,3,1,1,1,5,4,4,5,4,2,5,5,5,5,5,5,2,5,5,1,5,3,1,3,5,2,2,5,1,4,5,3,3,5,4,1,5,5,1,5,2,4,2,3,1,1,1,1,2,2,4,5,3,1,3,2,2,1,4,5,5,1,3,4,1,4,1,3,4,5,2,3,1,3,3,4,4,5,2,3,2,1,2,5,1,1,2,2,5,5,1,1,4,5,2,2,5,2,1,5,5,5,1,2,4,4,4,1,2,5,3,5,3,1,2,2,3,3,2,2,2,4,2,1,3,5,5,4,1,1,4,5,1,2,2,4,2,2,5,5,4,1,3,1,4,5,5,4,5,3,3,2,2,5,1,1,3,2,2,5,4,4,5,1,4,2,2,5,2,4,5,2,3,5,1,3,5,4,4,2,2,1,3,4,1,5,2,1,1,4,3,1,5,3,4,2,4,2,5,4,3,4,5,3,5,1,3,5,3,3,1,4,4,3,5,3,5,5,3,5,4,3,5,5,1,2,5,3,4,3,4,1,5,4,5,3,1,3,1,5,2,3,1,1,1,1,5,5,5,5,3,1,2,3,5,2,3,3,5,3,5,3,1,2,3,5,5,4,3,3,3,2,4,4,1,3,3,2,2,1,4,3,5,5,4,4,1,2,5,5,5,5,3,3,1,3,5,1,1,3,5,1,4,5,4,4,4,1,1,2,5,4,4,5,3,4,3,1,2,5,5,1,2,5,2,3,4,1,5,2,4,3,3,3,5,5,1,2,3,1,2,2,4,2,3,4,1,1,1,3,5,3,1,2,1,1,3,5,2,2,5,3,4,4,2,2,1,2,1,2,5,3,3,3,5,4,5,2,2,3,5,2,1,1,5,4,1,5,5,1,5,4,3,1,2,1,4,5,3,3,2,2,5,1,2,5,3,1,1,2,3,4,1,1,5,1,1,3,4,1,4,2,5,5,3,3,2,4,5,3,2,3,3,4,1,4,3,2,1,1,3,2,3,4,1,1,1,1,5,4,5,1,5,3,3,5,3,4,3,2,4,3,2,5,4,1,5,5,4,2,3,3,3,5,2,1,5,3,4,3,4,1,2,2,3,2,4,5,3,3,4,5,3,2,5,5,1,2,5,5,1,2,2,4,1,2,1,3,3,2,3,1,3,2,4,4,3,4,5,3,2,1,1,4,3,4,4,4,2,4,1,5,3,1,2,1,1,2,2,1,1,2,5,3,1,1,4,3,4,1,4,4,2,2,3,2,3,1,2,2,5,4,4,3,4,2,1,5,1,3,2,5,4,3,5,3,3,2,1,4,4,1,2,3,1,1,5,4,4,2,4,4,5,1,4,1,1,4,1,2,4,5,1,3,3,4,2,1,4,3,4,5,2,4,4,1,1,2,4,5,2,5,2,4,1,1,1,5,2,4,4,1,4,3,3,1,2,4,1,2,5,4,1,5,1,5,1,1,4,1,3,3,3,2,2,5,3,4,2,3,2,3,1,2,4,1,4,1,2,2,1,4,2,2,4,2,4,1,4,3,2,3,3,1,3,1,1,3,2,2,5,3,5,4,5,4,5,1,3,4,1,1,3,2,2,2,1,5,2,1,4,1,1,3,4,5,4,3,5,1,4,2,5,4,4,5,4,4,1,1,4,4,4,5,4,4,1,2,4,5,4,4,2,2,3,1,1,1,3,5,3,2,5,2,3,3,4,1,2,1,4,3,2,4,4,4,3,2,2,4,2,1,4,1,2,1,4,3,5,3,3,1,2,1,3,5,1,4,5,2,4,1,1,5,3,3,2,3,3,1,3,1,5,5,3,5,2,1,2,5,4,5,4,4,5,5,1,4,1,4,1,5,3,3,4,5,5,5,4,3,2,4,4,4,2,1,1,5,2,5,2,1,4,5,3,3,5,3,5,4,2,4,1,4,5,3,4,4,5,3,5,5,1,1,3,1,4,5,3,4,2,3,4,5,5,2,4,4,4,5,5,3,4,1,4,5,1,5,1,2,2,4,3,3,5,5,2,1,5,2,1,1,3,5,3,1,2,2,2,1,4,4,1,3,4,5,3,4,1,4,1,3,4,1,4,1,5,2,3,2,2,4,2,3,3,4,1,1,2,1,2,5,3,3,4,4,5,3,2,1,1,2,1,1,4,4,2,1,4,3,4,4,3,4,5,3,5,1,3,3,4,2,1,2,4,2,2,5,4,3,2,5,5,4,5,2,5,5,2,3,3,2,3,2,4,5,4,3,5,5,4,4,4,3,3,5,4,2,5,4,1,1,4,5,4,4,2,1,5,4,1,3,2,5,5,4,1,1,4,4,1,2,3,1,3,1,4,4,1,3,3,3,2,2,4,3,3,4,3,5,2,4,5,2,2,5,3,2,4,2,2,5,1,4,2,1,4,1,2,5,3,4,5,3,1,2,1,2,5,1,1,4,2,2,5,2,1,3,2,1,2,5,4,4,5,5,2,2,4,5,4,4,4,3,2,2,5,3,3,5,2,2,3,4,3,2,1,4,3,1,2,2,2,1,2,3,1,3,1,3,5,5,4,2,4,4,3,2,4,1,4,1,3,5,2,2,4,3,4,3,5,4,2,2,1,3,5,2,2,1,1,3,2,5,3,5,3,4,2,5,2,5,4,2,1,3,1,2,3,3,4,1,1,4,1,3,5,1,1,5,5,5,4,2,5,1,2,5,5,5,1,5,1,2,5,3,3,1,2,1,2,2,1,4,2,5,1,3,2,5,1,3,3,3,5,3,3,4,4,2,5,4,5,4,2,1,4,4,3,4,1,4,5,1,2,3,4,3,4,2,5,2,1,3,4,4,3,2,3,1,2,3,4,3,4,3,2,4,5,2,4,2,5,5,2,2,4,2,2,5,5,2,4,4,4,1,1,5,4,1,4,4,3,4,5,4,5,2,2,4,2,4,5,3,5,2,2,1,5,1,5,3,1,4,3,4,5,1,1,5,3,4,4,3,1,4,3,3,3,1,4,2,1,4,2,2,2,2,2,1,1,5,5,5,5,3,4,4,2,2,4,4,2,4,5,3,2,4,4,5,1,1,2,4,5,1,1,4,3,3,3,5,1,5,3,5,3,5,3,5,5,1,2,2,1,5,1,3,5,1,5,5,3,4,2,3,4,4,4,3,5,5,4,1,2,4,1,4,1,4,1,3,1,4,4,5,5,2,5,4,3,3,5,1,2,5,5,5,1,1,4,1,5,4,1,2,3,2,4,4,1,5,3,4,2,5,4,4,4,2,4,1,3,5,2,4,5,5,3,1,2,3,1,4,4,3,4,4,5,3,3,5,1,3,5,1,4,1,4,1,2,1,4,4,2,1,1,5,4,4,2,1,5,4,1,3,1,5,2,5,2,2,2,3,1,5,4,3,2,2,4,2,2,1,5,2,5,3,1,5,1,5,4,3,1,2,1,2,4,2,5,1,1,3,4,3,5,5,3,2,5,2,1,2,5,3,2,4,2,5,4,5,2,3,5,4,1,2,2,5,1,5,1,2,2,3,5,5,5,1,1,4,2,4,5,5,1,3,5,3,1,1,2,1,2,5,1,5,1,1,2,5,5,4,1,2,5,2,4,4,2,3,4,5,2,5,5,3,1,4,1,5,2,1,5,5,4,2,3,4,2,2,1,1,5,1,2,1,2,3,3,3,3,1,1,2,4,3,1,3,5,5,5,5,1,5,3,3,3,3,5,5,5,2,1,1,5,2,3,1,4,1,3,3,1,4,1,5,3,1,5,5,5,1,1,3,3,3,3,5,1,3,1,5,3,1,5,3,1,1,4,1,2,4,5,1,4,3,5,5,4,4,5,2,2,2,5,4,5,5,1,1,1,2,4,5,2,5,4,1,4,3,3,4,4,1,1,1,4,1,1,5,2,3,2,1,1,4,4,4,1,1,2,3,2,5,1,1,3,5,5,2,1,1,3,5,1,3,3,3,4,2,5,3,4,4,5,1,5,4,3,2,4,1,2,4,5,2,5,2,5,5,2,5,5,1,4,1,4,4,2,1,2,5,3,1,3,1,5,3,1,2,2,3,5,5,5,4,1,5,2,2,4,4,4,3,5,1,4,1,4,3,1,1,2,2,5,4,4,2,1,3,1,2,1,4,4,2,3,3,4,5,4,5,1,4,2,1,1,1,4,2,4,5,5,4,4,5,1,4,2,3,4,4,2,5,4,2,5,2,5,4,4,2,4,4,2,4,5,1,3,4,1,1,3,1,1,2,5,4,1,5,5,5,3,3,5,4,2,3,5,1,2,4,3,1,1,5,1,5,1,4,5,1,3,1,4,1,4,1,2,3,1,1,2,4,3,3,5,3,5,3,3,2,4,4,3,2,1,4,2,2,4,2,4,5,1,2,5,1,5,2,2,2,1,4,2,4,4,4,1,2,1,2,3,3,1,1,4,3,3,3,3,1,3,5,2,2,4,2,3,1,5,3,5,3,5,4,2,2,2,1,3,2,4,4,3,5,3,2,1,1,4,4,4,2,2,4,2,3,3,5,3,1,1,3,2,2,1,1,2,4,2,4,4,4,4,1,1,2,1,1,4,3,1,5,1,1,2,2,5,4,1,5,1,1,1,2,3,2,3,1,1,1,2,5,4,1,3,3,4,1,4,1,4,4,1,5,2,2,3,1,4,5,4,4,4,3,5,2,1,3,2,2,2,1,1,2,1,1,4,2,3,4,1,5,4,3,1,1,3,4,5,4,4,4,4,4,3,1,3,3,3,4,2,1,1,5,1,2,5,2,3,5,2,5,4,3,4,3,1,1,3,1,2,2,2,4,2,2,2,1,1,2,1,2,4,4,3,1,1,2,5,5,2,1,3,1,5,5,3,2,2,5,1,1,5,1,1,4,1,3,5,4,4,2,4,2,1,1,1,4,2,5,2,4,1,2,1,1,3,1,4,2,2,5,4,5,1,4,4,2,5,2,3,3,3,2,3,1,3,2,3,1,2,5,2,5,2,5,3,5,5,3,4,4,5,4,5,5,2,1,1,2,1,5,3,1,1,3,2,3,5,2,5,3,3,2,4,5,4,1,1,2,2,4,4,5,2,1,5,1,4,5,5,1,3,2,4,4,3,5,4,5,2,1,4,2,3,2,1,2,3,5,5,2,1,2,4,1,2,5,1,4,3,5,2,4,5,1,2,2,2,1,3,4,1,4,4,4,5,3,4,3,1,3,4,2,5,5,3,1,2,4,3,5,1,4,5,2,3,2,4,3,1,1,1,2,2,2,4,1,5,3,5,2,1,4,3,5,1,3,2,1,4,4,1,2,2,2,5,4,4,5,4,4,1,4,5,2,2,4,4,3,5,2,1,2,2,2,3,1,4,2,2,3,1,1,2,1,2,5,3,2,1,1,4,4,5,3,4,5,5,3,4,2,5,5,3,3,2,5,2,1,5,3,2,5,2,4,3,5,5,4,3,5,4,5,3,2,3,4,4,5,4,2,2,1,3,1,1,3,4,3,1,2,4,2,1,3,2,4,1,3,3,5,3,5,1,2,4,5,5,2,3,4,2,2,5,4,5,3,2,1,2,3,2,4,3,4,2,2,4,1,4,2,2,1,5,4,2,1,3,1,2,4,4,5,3,4,2,1,5,4,4,3,5,4,1,1,3,4,1,5,1,2,1,3,1,2,1,1,5,3,3,5,1,5,3,5,2,2,2,1,4,3,4,3,3,4,1,1,4,3,2,4,1,5,1,3,2,4,3,4,4,4,1,4,1,2,1,5,4,4,2,1,2,2,5,1,3,5,2,4,5,3,5,3,1,3,3,1,1,1,4,5,4,3,4,5,3,5,3,3,1,2,4,2,3,1,4,5,4,1,5,4,3,4,2,2,5,2,1,1,1,5,4,2,5,1,4,2,1,2,5,4,5,1,3,4,4,4,2,3,5,4,4,5,4,3,5,2,2,4,2,1,3,4,1,5,1,3,2,2,5,3,3,1,5,1,3,2,4,3,5,2,3,2,5,3,3,2,4,2,2,2,2,3,3,3,1,3,4,2,1,1,1,1,3,5,3,4,5,5,3,1,1,2,2,3,3,3,3,3,4,3,4,4,3,1,3,2,5,2,2,5,1,1,4,3,5,2,3,5,4,3,1,1,4,1,2,4,2,4,4,4,5,4,5,1,1,5,4,3,4,1,4,5,5,2,4,2,2,5,5,5,3,2,4,1,3,2,2,1,3,5,4,5,2,3,1,2,4,1,3,4,2,2,3,5,1,3,2,4,4,3,4,3,2,2,5,5,1,1,3,5,2,3,4,3,4,2,2,1,2,2,4,4,3,4,1,3,3,3,1,4,5,4,1,5,4,5,2,5,3,2,5,5,5,1,4,2,5,1,5,2,1,4,2,1,4,4,2,4,5,3,4,1,2,3,2,3,3,3,2,5,2,3,4,5,5,1,1,2,4,2,5,3,2,4,3,4,4,5,5,1,1,1,5,2,1,3,1,3,1,1,1,1,3,5,4,3,1,4,1,2,1,4,3,4,3,3,5,4,1,4,2,4,2,1,5,4,4,5,1,4,3,5,4,4,4,4,1,3,2,1,1,5,4,4,3,2,1,5,3,4,4,1,4,2,2,4,5,1,3,3,2,5,1,1,3,2,5,5,5,1,2,5,2,1,1,4,2,5,4,3,1,1,1,5,4,3,5,2,5,2,1,5,4,5,5,1,5,4,1,5,1,5,3,2,3,3,4,3,5,5,2,2,2,1,2,3,2,2,4,3,2,3,1,5,2,3,3,4,3,3,2,1,3,2,5,1,5,4,1,5,2,3,3,1,3,3,3,2,5,3,3,4,5,2,1,3,5,5,1,3,5,1,4,3,2,5,5,3,5,4,3,4,3,2,3,3,2,2,3,5,5,4,4,2,4,4,4,1,5,2,3,2,1,5,4,5,1,5,1,2,5,4,3,2,1,5,2,2,1,5,1,1,2,1,3,4,5,4,3,1,1,3,4,2,3,5,3,4,4,3,1,4,1,3,2,1,1,4,3,5,1,1,4,5,2,2,3,4,3,5,2,1,2,3,4,3,2,3,4,4,4,5,5,2,2,5,1,4,4,4,5,1,4,2,4,2,2,3,5,3,2,5,2,1,2,2,2,1,4,4,1,3,3,1,1,5,3,5,4,1,1,3,4,3,2,4,1,2,1,1,2,1,5,1,3,4,3,2,5,3,4,2,4,3,1,2,4,5,3,5,2,5,4,5,2,1,4,4,1,1,1,3,2,2,4,1,3,3,1,3,1,4,1,4,3,2,3,3,4,3,5,2,2,5,4,2,5,3,4,2,1,4,4,1,5,4,4,1,3,3,3,4,1,5,5,2,5,1,1,1,5,3,3,2,4,5,5,2,4,4,3,4,4,1,1,2,4,4,2,5,3,2,2,4,5,1,1,2,4,3,2,2,2,4,4,5,1,3,5,2,1,4,3,2,2,4,4,3,5,1,5,2,1,4,2,1,2,1,4,5,2,2,2,4,3,5,3,1,2,2,2,3,5,1,5,4,4,2,3,5,2,3,1,4,4,5,5,3,3,4,4,1,5,3,4,4,2,3,2,1,4,3,1,2,3,3,5,4,2,1,1,3,1,1,3,2,1,1,1,2,5,5,5,4,1,1,3,4,2,2,2,2,2,3,2,3,1,1,3,4,3,5,1,2,3,2,4,3,1,5,3,2,5,4,4,2,5,2,5,2,1,2,1,5,1,4,5,2,2,3,5,1,3,3,5,1,2,5,5,3,3,5,2,2,3,2,2,5,5,4,4,2,4,5,1,4,1,3,3,5,2,3,3,2,1,4,1,1,4,5,2,2,3,3,4,5,2,2,5,5,5,4,1,1,2,4,3,2,3,4,1,5,4,1,2,4,2,1,5,4,1,1,1,5,5,1,2,3,1,2,2,1,4,1,5,1,4,1,3,1,3,1,1,5,3,3,3,1,2,3,2,2,1,2,4,1,4,4,5,1,4,2,5,1,2,1,4,3,2,3,5,3,1,1,4,1,3,1,1,3,5,4,5,5,5,2,4,2,1,3,1,1,1,4,1,3,5,4,1,1,4,1,4,1,3,5,4,5,4,2,5,3,1,4,1,2,5,4,1,1,1,1,1,4,3,3,4,2,4,2,1,4,5,5,3,2,2,4,1,4,3,5,1,5,4,2,3,3,2,1,1,3,1,2,2,3,1,2,5,3,3,5,1,2,3,4,2,5,2,3,1,5,1,4,2,4,5,4,5,2,1,1,5,2,5,4,5,5,4,2,5,5,2,1,4,4,3,3,5,3,4,4,3,2,3,3,2,4,3,2,2,1,1,1,5,1,1,5,1,1,5,4,2,2,1,3,3,4,5,5,3,3,5,3,1,4,3,3,1,4,2,2,4,1,5,5,1,5,1,3,5,3,2,2,2,5,3,4,2,2,4,5,5,1,1,2,4,2,5,1,5,2,2,1,3,2,1,4,4,1,4,1,4,3,4,4,2,3,3,2,5,5,3,4,3,3,4,5,1,5,5,2,5,1,2,3,4,1,5,1,1,1,1,4,1,4,5,3,2,5,5,4,1,3,3,3,3,5,2,4,5,5,2,3,5,4,5,1,4,3,2,2,3,1,1,4,3,4,5,5,4,3,1,3,3,1,5,4,3,2,2,1,4,2,1,2,5,5,2,4,4,3,1,2,2,5,4,5,4,4,5,3,5,5,4,1,4,5,5,2,2,4,2,1,3,1,2,5,5,1,5,5,4,2,2,5,3,1,5,4,5,5,4,3,3,3,5,5,5,1,4,5,3,4,2,1,1,5,2,4,3,1,2,4,2,2,1,4,5,1,4,2,2,2,3,5,3,1,1,4,3,5,1,4,3,2,4,1,5,2,4,4,1,2,1,1,1,3,1,4,5,4,5,1,1,2,2,1,3,4,1,1,4,3,3,1,2,5,1,2,5,4,1,2,1,4,4,1,1,3,2,4,3,4,2,5,1,1,4,1,3,5,1,5,5,1,5,3,4,5,3,4,4,3,1,4,4,5,5,5,4,1,2,3,2,5,4,2,4,5,1,4,3,1,1,1,2,4,3,4,1,2,4,2,1,5,4,4,1,3,5,1,2,3,3,3,4,3,5,1,4,1,2,5,1,5,5,2,4,1,3,5,2,3,1,1,2,1,4,3,3,2,2,4,5,4,2,2,2,5,4,5,2,1,4,4,3,1,3,2,4,4,2,5,3,2,3,5,3,3,1,2,2,5,4,1,4,1,5,1,5,4,2,5,5,5,2,3,4,1,4,3,4,1,4,5,1,2,4,2,1,3,4,4,3,1,1,2,4,1,5,2,1,5,3,5,2,2,3,2,2,5,4,4,3,4,2,5,1,3,1,4,1,3,5,1,3,1,2,4,1,4,3,2,5,3,3,3,2,4,2,5,2,1,2,4,1,4,4,3,5,2,4,2,4,4,3,2,1,5,5,3,5,5,1,3,2,4,4,1,4,1,5,1,1,4,3,4,2,5,1,4,5,4,1,2,1,1,2,5,2,3,2,1,1,2,4,4,3,2,5,2,2,3,5,5,1,3,2,5,3,5,1,1,1,2,5,3,1,4,5,5,3,2,1,4,3,3,4,1,5,3,2,3,4,5,5,2,4,1,3,1,1,4,2,4,2,4,2,4,2,3,3,4,3,1,5,5,4,1,3,2,4,3,4,4,1,5,1,1,2,3,3,3,3,5,3,4,5,2,4,4,1,3,5,1,4,3,4,2,1,1,1,3,1,1,2,2,3,1,4,5,5,5,3,3,3,1,2,2,2,4,4,4,1,5,2,2,1,5,1,2,3,2,5,3,4,2,5,3,4,4,5,4,2,2,2,3,3,2,4,3,4,1,3,1,5,3,5,1,5,3,1,4,5,1,1,2,1,3,3,4,5,1,5,4,1,3,4,2,4,2,1,5,2,3,1,2,2,3,5,2,3,5,5,1,3,2,1,5,2,5,5,5,1,4,5,2,5,4,1,1,4,4,5,4,4,3,1,4,2,2,3,1,3,2,4,2,1,3,2,1,3,1,2,1,4,1,1,3,4,4,5,2,5,2,4,2,4,5,2,5,2,4,2,4,3,2,4,3,4,5,5,2,5,5,4,5,1,1,5,2,4,3,5,5,1,3,3,5,5,4,2,2,4,5,2,1,5,5,3,2,1,4,3,2,5,3,5,5,4,4,1,1,2,4,5,2,4,3,4,4,1,4,5,3,4,1,3,4,4,3,3,2,4,5,2,5,5,2,2,1,5,3,5,1,5,4,5,2,5,5,5,2,3,4,3,1,2,2,1,2,5,4,1,2,3,2,2,1,5,3,5,3,2,5,2,5,3,1,1,5,1,4,2,3,4,3,1,3,4,3,3,4,5,1,5,1,4,3,5,3,4,5,2,3,4,5,3,1,3,3,5,3,4,2,5,2,4,1,3,4,5,2,4,1,3,1,1,1,2,2,5,1,2,1,2,1,5,1,1,1,2,3,3,1,4,2,3,2,1,4,2,3,5,1,4,4,5,4,1,2,3,1,2,2,4,4,5,3,3,1,2,2,3,4,4,3,1,4,5,2,3,4,1,3,1,1,4,2,4,3,5,2,3,3,4,2,4,5,5,5,1,2,1,5,2,2,5,4,1,4,1,1,4,1,1,5,2,5,2,1,2,3,5,4,1,4,1,4,2,2,4,4,1,2,5,4,3,5,1,4,2,3,3,4,1,1,3,3,5,1,1,3,1,2,4,5,2,4,4,1,4,2,3,4,3,1,4,4,2,3,5,5,1,2,2,3,1,4,5,2,3,4,4,4,2,4,4,5,1,1,1,5,4,1,1,1,4,5,2,4,1,3,4,5,3,3,4,2,4,4,4,4,1,4,1,4,2,2,5,5,1,2,1,1,1,5,4,4,3,4,3,3,1,1,1,1,5,4,5,1,4,3,1,3,5,3,4,3,5,4,5,5,5,2,4,1,1,4,3,3,2,3,2,2,4,1,1,4,3,2,1,3,4,5,5,5,3,1,4,3,5,4,5,1,1,5,2,2,5,3,2,4,2,1,5,2,1,2,3,4,3,5,3,2,1,2,4,3,4,2,4,2,1,5,1,4,4,2,3,4,1,2,5,3,1,4,4,5,4,5,5,3,5,1,4,4,2,2,4,5,5,1,2,1,1,1,1,2,4,4,3,1,4,1,1,2,1,2,1,2,4,2,2,5,2,2,3,2,2,1,3,3,1,4,4,2,2,5,1,1,3,1,2,2,1,2,4,4,3,2,5,2,5,1,3,3,3,5,4,3,1,3,4,4,5,3,5,1,4,5,2,2,1,2,4,3,3,2,5,1,1,4,1,1,3,1,4,5,5,3,1,1,3,2,2,5,2,2,5,1,2,3,4,1,5,2,1,2,4,2,5,2,5,4,5,2,4,4,4,1,2,2,1,5,1,4,4,1,5,5,2,1,1,1,5,3,1,3,4,2,1,4,4,2,5,3,5,3,5,3,4,2,5,5,5,1,3,1,4,4,3,1,4,1,2,5,5,3,2,4,3,2,4,2,3,5,4,3,3,2,2,1,1,5,5,2,5,1,2,2,3,2,4,2,2,3,2,3,5,4,4,4,4,5,2,1,3,2,3,1,3,4,3,5,1,3,2,5,4,5,3,2,4,3,1,5,1,1,1,5,2,3,1,1,3,2,2,4,4,1,2,4,5,3,5,4,4,1,1,5,2,1,4,1,5,2,3,2,2,4,4,5,5,3,1,1,3,5,2,5,5,5,5,3,5,3,2,2,2,1,1,2,3,3,2,2,3,3,5,1,1,3,1,4,5,1,5,5,2,5,3,1,5,5,1,5,2,5,5,4,4,2,5,1,2,1,3,5,5,4,3,5,1,5,2,2,5,4,1,4,4,5,1,2,5,1,3,4,2,4,3,4,3,2,3,2,2,5,1,3,2,2,3,5,1,2,1,4,1,4,5,5,5,3,3,3,5,4,5,4,5,3,2,5,5,4,2,5,4,2,2,1,4,4,3,2,2,5,4,5,5,1,1,1,2,2,2,5,3,1,5,1,2,3,2,5,4,5,1,2,5,2,4,5,2,1,3,3,3,3,1,5,3,3,4,3,2,3,2,5,3,5,3,3,1,1,1,5,3,5,4,5,5,5,5,3,4,3,5,1,4,4,1,2,4,4,2,2,3,4,2,3,4,1,5,1,2,3,4,1,1,5,3,2,1,2,3,5,4,1,3,3,4,3,3,2,3,3,5,4,5,1,3,5,3,2,4,3,1,5,2,1,3,1,1,5,4,4,1,1,1,1,4,5,5,3,4,5,5,3,3,2,5,1,3,2,1,1,1,3,4,5,1,5,3,1,5,1,4,2,3,3,4,1,4,4,1,2,4,5,1,4,5,3,5,5,3,5,5,3,5,5,5,5,3,5,3,1,5,4,5,5,2,4,1,5,2,4,2,3,4,3,4,3,5,2,1,3,5,5,4,1,2,4,4,2,2,5,2,1,3,4,1,1,2,3,2,3,3,4,3,4,3,2,4,1,1,4,1,1,3,5,5,2,5,4,4,2,4,1,2,5,5,3,5,2,4,4,2,2,2,4,2,3,1,2,5,5,3,3,3,5,1,1,3,2,3,2,4,3,3,1,1,2,4,4,5,3,1,3,5,3,3,2,3,3,4,1,1,3,3,5,4,4,3,1,1,4,4,1,5,1,1,2,2,3,4,2,3,5,5,3,2,5,2,3,5,1,5,5,3,2,2,5,1,3,2,2,3,1,5,2,1,3,1,4,2,2,1,4,2,3,4,1,2,3,5,5,3,1,5,3,2,4,3,2,3,2,3,2,1,5,1,4,4,5,2,5,3,1,4,3,1,1,5,1,2,5,4,5,4,2,2,1,5,5,3,2,2,5,5,2,2,2,4,5,5,2,5,3,2,1,1,4,4,1,1,3,2,4,4,5,3,2,3,2,2,2,2,2,3,2,4,3,2,3,4,5,1,5,5,2,5,4,3,3,1,4,2,2,1,2,2,1,2,1,5,1,1,2,2,5,1,2,2,3,5,1,5,3,5,1,2,5,1,1,2,2,3,2,3,2,3,2,5,1,3,4,1,3,5,5,2,3,5,1,3,3,2,5,5,4,1,4,1,4,1,1,1,2,3,3,4,4,2,2,2,3,5,5,5,2,4,5,5,3,2,2,2,4,5,5,1,4,1,4,5,2,1,2,5,1,4,1,3,2,4,3,4,4,4,4,2,2,5,3,3,1,3,2,2,4,3,1,1,1,3,5,5,1,4,3,1,5,1,2,4,4,4,5,1,1,2,1,2,2,5,2,1,1,5,1,3,1,1,2,5,5,1,1,2,2,5,5,5,5,2,3,5,2,3,3,4,5,5,1,1,5,1,5,4,4,1,5,3,4,3,3,2,3,4,5,3,3,5,3,4,4,2,2,5,3,1,3,4,2,2,2,5,2,1,5,4,4,5,3,1,5,3,2,1,2,5,1,4,4,2,3,3,3,1,5,5,3,5,5,4,5,2,3,5,1,5,2,3,2,3,1,5,2,2,1,5,1,1,2,3,3,5,1,4,2,4,3,3,2,3,3,5,2,2,1,4,1,3,3,4,5,2,1,3,4,4,1,2,5,2,4,4,4,3,1,5,5,2,1,2,2,4,2,2,5,3,5,2,3,1,5,4,4,4,2,4,4,5,1,5,2,4,1,4,4,5,4,1,1,2,4,4,2,1,1,5,3,2,3,3,4,2,5,1,3,4,4,4,4,2,1,5,2,5,1,3,2,4,4,1,4,2,4,4,5,5,1,3,1,5,4,1,5,4,1,1,5,5,3,5,3,1,1,2,1,2,5,5,3,2,2,1,2,1,5,1,1,2,5,2,5,4,5,2,4,4,1,5,3,1,2,3,1,2,2,4,5,1,3,5,3,1,3,5,5,1,4,2,1,3,5,1,3,5,2,5,2,1,3,2,4,2,3,3,3,2,4,3,3,5,3,1,1,1,1,5,5,2,3,4,3,1,1,2,1,2,1,5,3,3,2,5,5,3,1,2,4,1,2,5,4,2,5,2,5,2,3,5,3,4,5,2,4,3,1,3,1,1,3,5,1,2,3,1,3,5,3,2,3,1,1,5,5,5,5,3,4,4,1,3,3,5,2,4,3,2,2,3,2,5,4,3,3,4,4,2,1,3,1,3,4,3,4,2,2,3,1,4,4,1,5,4,4,4,4,4,1,5,1,5,4,3,4,5,2,3,2,1,2,3,2,1,2,3,1,1,5,5,3,4,5,4,3,4,4,2,1,2,5,1,1,2,1,3,3,5,3,3,2,2,2,3,5,1,4,5,2,3,3,1,3,4,5,3,1,1,2,3,4,5,3,3,4,5,2,4,2,5,3,4,5,5,1,5,5,1,4,1,4,2,4,4,4,5,3,1,3,2,3,4,1,4,5,1,1,4,1,5,3,4,2,1,3,4,2,1,5,5,3,2,3,4,1,2,1,3,5,3,4,4,1,2,5,3,2,4,1,3,3,2,5,5,5,1,4,2,3,2,3,2,5,5,3,3,3,2,3,3,4,2,5,1,5,1,4,3,4,2,2,1,5,2,5,4,1,5,1,2,2,5,5,5,4,5,5,4,2,3,5,2,3,1,2,1,5,2,2,1,1,3,4,3,5,5,2,4,2,4,4,2,1,5,3,1,4,4,1,1,5,1,5,3,5,2,5,5,4,1,5,2,5,5,3,4,1,2,1,5,3,5,2,1,2,1,5,3,1,3,1,2,2,1,3,4,3,2,4,5,1,3,4,4,5,2,2,1,2,2,3,3,5,4,4,3,1,2,5,1,2,1,5,4,2,2,4,5,5,5,3,2,3,1,4,5,3,4,4,2,4,4,3,2,1,1,1,4,2,1,5,2,4,1,5,4,4,5,5,1,4,2,4,5,5,2,1,5,4,2,2,2,1,3,4,3,3,4,4,5,2,2,1,4,1,2,5,3,5,2,4,4,5,1,3,5,2,4,3,2,4,5,4,2,4,5,4,5,3,2,1,5,3,2,2,3,2,1,5,4,4,4,2,2,4,4,5,2,5,2,2,4,1,2,5,1,4,5,1,1,4,2,2,1,2,3,1,4,2,2,5,4,4,1,1,4,3,5,5,2,4,1,4,4,4,4,3,1,5,2,4,3,5,3,4,2,3,4,4,4,1,4,1,1,4,4,2,4,4,3,4,5,2,2,5,2,5,4,3,4,2,2,3,3,1,3,3,4,3,3,5,3,2,4,3,1,4,2,1,2,2,3,1,3,5,1,1,2,1,3,5,5,2,5,2,1,4,3,2,5,3,1,4,1,3,2,1,3,1,5,5,3,1,1,1,2,1,2,5,1,3,5,2,5,3,3,2,1,2,3,1,4,5,2,3,2,4,4,2,1,3,3,1,3,2,4,2,5,5,3,5,2,4,4,3,4,3,5,1,2,3,3,4,4,2,4,2,4,5,4,5,4,5,1,1,4,5,4,3,3,2,2,5,2,4,4,1,4,5,3,4,4,2,2,3,5,1,1,1,3,4,2,5,2,2,3,3,4,2,4,3,1,5,1,1,1,5,2,3,1,1,3,1,1,1,4,5,5,3,2,4,3,3,4,3,1,1,1,4,1,2,5,3,1,1,4,3,5,3,3,1,5,1,3,5,4,2,3,4,2,1,2,2,4,5,1,1,5,4,2,3,1,1,3,5,5,4,1,1,1,5,3,4,5,4,3,2,2,5,1,5,2,3,5,1,4,3,5,5,1,1,4,4,1,1,3,5,2,5,3,3,1,2,2,5,4,5,3,3,5,3,3,2,4,5,1,4,1,5,1,2,3,4,1,4,5,4,2,1,1,3,5,2,5,2,4,4,4,3,5,3,4,4,5,4,2,4,1,1,4,4,1,5,3,3,1,3,4,4,3,2,5,4,4,3,3,2,2,4,5,2,4,3,4,5,1,1,2,5,4,2,2,5,3,3,5,5,5,3,4,1,2,1,1,1,4,4,4,4,1,1,1,4,4,4,4,2,5,2,3,1,3,1,5,1,5,4,2,3,2,3,5,3,3,2,5,2,2,5,1,3,4,3,3,3,5,2,3,4,1,1,2,3,1,3,5,2,2,1,5,4,4,2,5,3,4,1,3,2,2,1,1,3,5,5,1,1,5,1,4,5,2,4,2,1,2,4,3,5,2,2,1,5,4,3,3,5,2,3,1,2,2,4,5,2,5,2,3,1,5,4,5,3,4,3,5,4,1,4,5,4,1,3,1,2,3,4,2,2,4,5,4,4,3,5,3,2,1,5,5,3,5,2,4,1,3,1,4,4,4,4,2,1,4,3,5,2,1,3,3,4,2,4,2,3,1,3,1,4,1,4,1,3,1,4,2,3,2,4,3,5,2,5,1,3,3,3,2,3,1,3,1,1,5,4,4,1,1,3,3,4,5,2,4,5,5,5,1,2,1,5,1,3,4,3,3,5,3,3,3,1,2,4,3,5,1,5,2,2,5,5,2,4,5,3,4,3,4,1,4,5,4,5,2,2,3,1,2,4,3,2,2,1,1,2,5,3,1,5,1,2,5,4,1,1,4,1,1,5,3,5,3,4,3,2,2,4,2,4,5,1,3,4,3,1,2,1,3,3,3,4,2,3,4,3,5,1,5,4,1,5,5,3,3,2,5,5,4,4,3,2,2,1,3,5,1,5,3,5,1,2,2,3,2,5,4,1,5,1,1,5,5,1,1,4,5,1,2,3,4,1,5,1,4,3,4,3,4,1,3,3,1,1,1,4,1,5,4,5,1,4,1,3,3,1,4,4,5,5,4,5,5,5,5,3,4,5,5,1,4,2,2,2,3,5,5,3,1,3,1,1,5,2,3,3,4,3,1,3,5,4,4,2,1,2,4,2,1,2,1,4,1,5,3,2,5,1,2,3,1,1,4,5,2,3,2,2,5,5,1,3,2,3,5,3,2,4,2,5,2,4,1,4,2,5,2,4,5,3,3,2,1,3,3,3,1,4,5,4,1,5,5,3,4,2,1,1,1,1,4,3,4,2,1,5,4,5,5,4,3,1,5,1,4,3,4,1,1,5,4,3,5,2,4,4,3,3,3,2,3,3,5,5,3,3,5,4,5,2,5,4,2,1,4,3,5,2,5,3,1,1,2,4,3,4,3,2,4,3,3,3,5,4,4,4,3,4,4,5,4,3,1,3,5,3,1,4,5,2,3,2,1,2,2,3,2,2,5,2,3,2,5,5,5,5,1,2,5,3,3,5,4,5,3,2,5,5,5,3,3,2,4,1,4,1,4,1,5,4,1,2,5,4,1,2,3,1,4,4,5,3,3,1,5,3,3,1,5,4,2,4,4,1,5,5,1,2,3,4,2,5,3,3,3,2,3,1,5,5,3,1,2,4,4,5,4,3,3,3,1,4,1,4,5,1,3,4,4,1,5,5,5,4,5,3,3,5,4,1,3,1,5,4,2,1,2,3,4,4,4,1,1,3,5,3,3,2,5,3,2,3,4,4,2,4,1,4,1,3,4,4,5,3,2,2,3,2,2,1,1,4,5,1,5,4,4,1,2,1,2,3,4,1,2,4,4,4,1,1,2,2,1,1,4,1,2,5,5,2,1,4,2,3,1,2,2,4,2,1,5,5,4,3,4,5,4,2,2,3,4,1,2,3,3,5,1,1,2,5,5,2,3,3,4,4,3,1,1,1,5,1,2,2,4,1,5,1,1,3,4,4,4,2,3,3,2,3,5,1,3,5,3,2,2,1,1,1,5,2,3,3,3,2,4,4,2,2,4,5,4,3,4,2,3,2,3,3,3,5,1,3,1,4,1,4,2,3,5,3,4,2,1,2,4,4,4,3,4,2,5,5,5,1,5,2,1,5,1,4,1,4,4,3,3,4,3,5,2,5,2,3,2,2,2,2,4,5,1,1,3,2,2,2,4,4,4,4,2,4,2,3,2,4,3,1,5,1,2,3,4,2,5,5,5,4,3,1,4,4,2,4,4,3,4,5,5,1,2,5,1,1,1,2,1,5,4,4,1,2,4,3,2,2,4,5,5,4,1,2,3,5,3,1,1,3,1,4,4,1,2,1,4,5,3,1,5,5,2,4,1,1,3,1,1,3,2,3,5,4,1,4,1,5,4,3,2,2,2,1,1,5,5,4,3,5,1,3,1,5,2,4,5,1,1,2,4,1,4,2,5,3,5,1,4,5,5,4,4,4,1,1,2,3,2,4,2,5,5,5,2,4,2,2,3,1,1,5,5,2,4,1,2,2,2,3,1,4,3,3,3,4,4,5,2,2,3,2,1,5,4,4,1,5,2,2,3,3,1,1,1,4,4,1,5,3,2,2,5,5,1,3,4,4,2,4,3,4,1,4,1,2,5,2,1,4,5,5,5,3,4,3,5,1,5,5,4,4,2,5,3,4,1,5,3,2,1,5,2,1,2,3,5,2,5,1,4,2,1,4,5,2,1,3,1,2,5,1,2,5,5,1,3,3,4,1,5,3,2,3,4,1,1,2,3,4,5,1,3,4,4,4,1,1,3,2,2,4,5,2,3,5,2,5,1,5,1,1,3,5,1,5,3,3,1,5,3,1,1,2,1,5,2,1,4,2,5,4,1,1,5,5,4,1,2,1,1,1,3,5,1,5,2,5,5,3,2,4,4,1,2,4,1,2,4,5,5,1,3,3,5,3,2,2,5,5,5,1,5,4,3,5,1,3,5,5,2,1,2,3,2,4,5,1,5,4,4,1,4,5,5,3,1,4,5,4,3,5,4,2,3,3,1,1,4,5,2,5,3,1,5,5,4,4,3,3,3,5,3,5,2,1,3,1,4,5,2,5,2,3,2,1,2,4,3,3,1,4,4,4,3,3,1,1,3,4,2,5,4,3,5,5,1,1,5,3,4,1,2,3,4,3,1,2,3,4,4,4,4,5,3,1,3,3,5,3,1,2,3,2,3,4,5,2,4,2,4,3,1,5,1,1,1,1,1,5,4,3,1,3,2,1,3,3,4,1,4,2,4,5,1,4,2,1,2,5,5,2,4,2,1,5,4,3,2,3,4,5,4,1,1,5,1,3,3,5,3,2,5,5,1,2,1,2,4,1,2,5,4,4,3,2,2,2,3,3,5,5,1,2,4,3,3,1,1,3,3,2,2,5,1,5,5,3,3,2,2,4,2,4,5,4,1,1,4,1,2,3,3,2,5,4,5,1,1,3,3,1,1,4,1,4,5,3,5,4,5,1,2,4,3,2,2,2,4,5,4,4,1,5,5,4,1,5,3,5,3,4,5,5,5,2,3,1,3,3,5,1,4,3,3,5,4,2,1,1,5,5,1,1,2,4,4,2,5,5,2,5,4,4,2,3,2,4,5,5,4,5,2,2,1,4,1,1,4,4,3,5,3,3,4,1,4,4,4,2,2,4,3,2,4,4,1,4,3,4,4,3,5,3,5,1,3,4,1,3,1,2,4,4,3,5,3,2,1,1,2,1,1,2,4,1,2,4,3,4,1,4,2,4,5,1,3,1,1,2,5,1,5,5,2,3,3,5,5,4,1,2,1,2,2,1,2,3,1,4,1,2,1,3,1,3,3,4,3,1,4,2,5,1,5,4,4,5,4,3,5,1,5,3,3,1,4,3,3,1,5,5,2,3,3,5,1,3,2,1,1,4,1,2,5,5,5,3,5,5,5,2,3,5,3,3,3,1,3,2,5,3,2,1,1,4,2,5,4,1,2,2,3,1,2,1,2,5,2,3,1,4,1,5,5,5,5,5,3,5,3,1,3,3,4,4,3,5,4,4,3,3,4,1,4,3,4,3,5,3,2,5,4,3,3,5,4,3,1,4,4,4,5,1,5,5,3,1,5,4,4,4,5,1,5,4,2,4,3,2,4,3,3,2,4,1,4,4,3,1,2,3,3,3,2,3,3,5,4,3,3,1,1,2,4,2,2,3,2,1,3,3,5,1,4,1,1,5,1,5,3,4,2,1,4,3,3,1,1,5,3,4,5,3,4,1,3,5,1,3,3,5,4,4,5,2,4,1,2,1,3,1,4,2,3,3,1,2,5,2,2,4,2,4,3,5,4,2,2,1,5,2,5,4,5,5,5,4,2,5,4,4,4,4,2,5,4,4,3,5,4,4,3,4,1,2,5,4,5,1,2,1,3,2,1,2,2,1,2,1,5,3,3,4,3,3,4,4,1,1,3,1,1,1,1,1,3,3,5,5,5,5,4,5,4,4,5,4,5,5,4,5,4,2,3,1,5,3,4,5,1,3,1,1,3,1,2,2,3,3,2,1,2,5,3,1,5,4,2,3,4,4,5,2,1,2,5,3,3,4,4,1,1,1,3,2,1,5,5,4,1,4,1,2,4,4,2,2,3,2,5,5,2,3,4,2,2,1,4,1,3,3,1,4,2,1,5,5,2,4,4,3,3,1,4,4,3,2,2,4,1,1,5,4,1,1,4,1,2,5,1,5,1,4,2,1,5,3,4,2,5,5,1,5,2,3,2,2,1,3,3,2,3,5,4,4,4,5,2,4,2,2,2,1,1,5,5,1,2,2,3,2,2,3,5,3,3,2,3,5,2,2,4,3,2,2,5,3,4,1,4,3,5,1,1,5,1,3,4,4,5,3,2,3,4,4,4,5,2,5,3,1,5,2,5,5,1,2,3,5,3,3,5,1,1,2,4,5,5,2,4,4,1,4,4,2,1,1,2,1,5,3,3,1,3,4,3,3,2,1,2,3,2,2,2,3,5,1,5,3,5,4,3,3,2,1,5,3,4,1,1,4,5,4,5,2,3,4,1,1,3,4,3,2,5,4,1,2,5,3,1,5,4,4,2,2,3,1,2,1,1,4,3,1,1,3,3,1,5,3,5,2,2,4,1,5,3,5,3,1,2,5,2,5,3,2,5,3,2,3,2,5,4,1,4,2,5,2,4,5,3,4,3,1,1,2,3,4,1,1,5,5,1,1,3,3,3,5,2,2,5,2,3,5,1,3,3,4,2,4,5,3,4,1,3,3,2,1,5,5,5,3,1,3,5,4,5,3,1,5,5,2,1,5,3,5,3,1,3,1,1,5,5,3,5,3,1,4,2,4,4,1,1,5,5,5,1,5,2,3,1,2,1,3,3,3,4,4,2,4,4,5,2,5,1,4,5,5,1,3,5,1,5,2,4,3,5,2,4,1,5,5,2,3,5,5,1,2,1,2,3,2,1,3,5,4,5,5,2,4,3,5,1,4,2,3,4,2,1,5,3,5,5,5,2,5,1,5,5,5,4,4,2,5,3,2,1,1,1,5,5,5,2,5,1,2,5,1,5,4,2,5,3,4,2,3,5,2,4,1,3,2,5,2,4,4,4,5,3,3,3,2,4,2,1,2,3,4,5,5,1,2,1,1,4,3,5,2,5,3,3,5,1,4,4,1,4,2,5,1,5,5,5,2,3,5,2,4,3,2,4,2,1,3,2,4,1,5,2,3,5,3,2,5,4,4,2,4,3,1,3,2,3,4,4,2,5,5,1,2,5,1,1,2,2,3,2,5,5,5,5,3,4,3,2,5,3,4,2,5,5,3,2,1,5,4,4,3,1,4,2,1,5,2,5,1,5,4,4,1,5,1,2,2,4,1,4,2,3,2,4,4,2,3,5,4,5,2,4,5,3,1,5,3,4,3,3,3,1,3,5,4,3,3,4,5,3,4,1,1,2,5,2,3,4,4,3,4,2,1,2,1,3,4,3,4,2,4,3,2,5,4,1,4,3,3,5,1,5,1,3,5,3,4,4,5,2,5,1,4,3,2,1,4,2,4,1,5,1,3,5,5,5,2,3,4,2,2,3,5,5,2,3,4,3,3,2,4,3,5,3,2,4,5,2,5,4,1,5,4,1,1,1,3,5,4,3,5,3,4,4,2,4,2,2,4,4,1,3,2,1,4,5,3,2,3,5,3,4,3,4,2,3,1,1,5,2,1,5,4,1,1,4,1,3,1,4,2,4,4,1,5,5,1,2,4,1,4,3,3,1,3,3,2,4,5,2,4,5,4,4,1,5,5,4,4,2,5,4,1,5,2,5,5,1,2,1,2,4,5,2,3,3,2,3,2,4,1,5,5,1,1,3,5,3,4,2,3,5,3,4,4,1,2,1,3,4,1,3,3,2,2,1,2,4,3,3,1,2,1,5,3,4,1,4,3,3,4,5,3,4,3,4,4,2,1,3,5,3,5,2,5,5,4,4,5,1,5,3,2,3,3,3,5,5,4,3,2,5,2,3,4,1,1,5,2,3,1,4,3,2,3,4,4,3,4,2,3,2,1,2,3,4,5,4,5,3,4,5,3,3,2,1,2,1,3,4,1,5,5,4,4,5,5,4,2,1,2,2,3,5,2,4,3,2,4,2,2,4,2,1,5,2,5,3,5,4,5,5,1,1,4,4,4,3,5,5,5,4,4,5,2,3,3,1,2,3,2,4,1,5,2,2,3,2,2,2,2,2,2,4,4,4,3,1,2,1,2,5,2,1,4,1,5,4,3,3,3,2,5,1,2,2,2,5,2,1,5,5,3,4,2,3,4,3,2,2,5,5,3,1,5,4,1,5,2,1,4,4,3,2,4,2,1,1,4,2,3,4,4,3,5,5,5,5,1,1,3,4,4,5,5,4,5,3,2,1,2,4,2,5,3,3,1,1,3,3,3,2,3,4,1,1,5,5,1,2,5,3,5,5,3,1,1,3,5,1,1,3,3,4,1,4,4,2,2,1,3,5,2,1,2,3,5,3,3,3,1,3,2,4,3,2,5,4,3,3,3,2,3,2,1,4,2,2,2,3,3,2,1,5,2,1,1,4,3,4,5,2,2,2,3,2,5,2,4,2,1,4,5,5,3,4,3,5,4,1,4,1,4,1,3,2,1,3,5,4,3,2,3,2,4,1,3,5,4,1,4,5,4,2,4,4,3,4,2,4,4,1,2,2,4,2,1,2,3,5,3,3,1,5,3,3,1,3,5,4,4,4,2,5,2,2,2,4,5,4,1,4,5,3,2,3,5,1,4,3,2,4,4,4,4,3,4,2,5,2,3,2,5,1,2,2,1,3,1,1,1,5,2,2,2,4,1,4,2,4,4,5,4,4,5,3,3,4,2,5,4,5,5,4,5,2,4,3,2,3,5,1,5,2,5,3,3,3,4,5,3,3,2,2,4,1,4,2,1,2,4,5,3,2,5,4,5,1,3,5,1,4,2,5,2,2,5,5,1,4,3,1,2,2,1,3,4,2,5,1,2,1,3,5,1,1,5,3,5,2,4,3,1,4,3,1,1,5,2,5,2,1,4,4,2,2,4,5,5,4,1,5,3,5,4,4,3,1,5,5,5,5,4,4,3,4,2,5,3,4,4,5,1,1,5,1,2,3,2,1,3,5,3,5,5,5,3,2,3,1,3,2,1,5,2,4,2,2,1,5,3,2,5,4,2,2,4,1,4,1,2,5,3,4,5,1,2,2,5,3,3,3,1,4,1,5,3,1,4,2,1,1,5,4,5,2,5,4,5,3,3,2,5,3,2,4,2,1,1,4,3,5,2,5,3,2,1,2,3,1,3,3,5,3,4,5,3,1,5,4,1,3,2,4,3,5,2,5,1,4,5,5,5,3,1,4,2,2,3,2,5,3,4,3,2,4,2,4,4,1,5,4,5,2,2,2,3,4,5,3,1,2,3,4,1,3,2,2,3,1,1,2,4,4,3,5,3,4,1,2,3,3,4,2,5,3,3,1,1,1,1,3,3,2,3,2,5,3,4,4,4,2,5,2,4,2,4,5,2,1,4,4,5,5,3,4,1,3,2,1,1,4,2,1,2,3,3,5,2,1,5,3,2,2,3,5,5,3,1,1,2,5,1,3,5,5,4,5,5,1,2,5,4,4,3,5,5,4,5,5,4,5,3,5,1,1,2,3,3,5,3,1,5,1,4,2,4,2,5,5,5,1,5,4,4,5,4,2,3,5,4,4,1,3,5,4,1,5,1,4,5,4,3,5,3,2,3,5,1,1,1,3,5,2,1,4,2,4,2,5,1,4,3,5,2,5,2,2,1,3,3,3,5,3,5,5,2,2,3,3,1,3,1,1,4,3,1,4,1,1,1,4,5,2,5,3,4,3,3,2,4,2,3,1,3,4,4,5,4,4,5,2,2,4,2,3,3,4,3,2,4,3,4,4,4,1,4,3,4,5,2,5,2,1,5,5,1,1,3,5,4,5,1,2,4,2,1,2,1,2,2,4,5,2,3,5,4,2,4,1,2,1,5,1,5,3,4,5,5,4,3,3,3,3,5,4,3,1,5,4,1,1,3,2,1,2,4,1,4,5,2,3,4,1,3,2,4,2,3,5,3,2,5,2,3,3,1,3,3,1,5,3,5,2,4,1,3,2,3,2,3,2,2,2,2,3,3,2,1,4,3,3,4,5,3,1,2,3,1,5,3,5,3,2,2,4,5,1,4,4,3,3,2,2,4,3,2,4,1,4,4,2,4,2,2,3,4,2,5,3,4,1,4,1,5,5,4,5,4,5,5,4,2,3,5,5,1,2,1,1,3,2,5,2,3,5,2,5,5,4,3,2,5,1,5,5,2,1,3,1,1,2,5,4,5,3,5,2,5,5,2,4,4,1,5,4,3,2,5,5,1,3,4,1,1,1,4,2,1,5,3,5,1,1,1,4,2,4,1,1,1,5,1,4,1,1,4,1,1,4,3,2,3,3,3,1,4,4,4,4,2,3,4,2,2,1,4,3,1,3,2,4,1,3,5,1,1,2,1,3,3,2,1,4,3,4,1,1,2,5,1,4,3,4,5,3,1,4,2,4,5,5,4,4,1,3,5,2,1,1,5,1,2,5,2,3,5,5,2,5,1,2,2,3,4,1,5,4,2,5,5,4,2,2,2,4,3,4,4,4,4,1,5,5,5,4,1,5,5,1,4,2,4,1,3,1,3,2,2,1,2,5,1,2,3,4,2,5,3,4,3,4,1,5,1,1,5,3,1,4,3,4,1,2,1,2,1,2,5,1,5,5,2,4,5,1,3,4,5,4,2,1,4,2,2,5,4,2,2,4,5,1,5,2,2,3,4,1,4,5,5,1,2,2,4,1,4,4,2,1,1,3,3,5,4,3,1,3,5,3,4,3,3,3,5,5,4,3,2,2,5,4,4,5,2,3,1,4,2,1,5,1,5,4,4,3,2,4,2,4,4,1,4,1,2,3,4,2,4,3,5,1,4,2,5,5,2,2,5,5,5,3,5,4,4,3,4,1,5,1,1,5,5,3,4,2,2,1,5,2,3,1,3,3,3,4,5,3,5,3,4,5,2,2,1,5,3,5,3,3,3,2,1,2,3,5,4,1,3,5,3,5,2,4,1,5,3,4,4,3,5,1,5,1,4,1,3,5,4,3,1,1,5,2,4,1,1,4,2,2,4,2,4,3,1,4,4,2,5,5,1,2,1,3,2,2,2,3,1,2,3,3,3,1,1,2,3,3,1,1,1,2,3,2,2,1,4,1,5,1,4,3,2,1,2,4,1,2,5,3,4,5,3,2,5,4,1,3,3,3,2,1,3,1,1,4,1,3,5,2,5,5,4,5,4,5,1,1,5,1,1,1,2,2,5,1,4,5,1,3,3,4,1,5,3,4,3,1,3,3,3,1,4,5,3,1,2,5,4,5,2,3,4,3,5,5,1,5,4,5,5,2,5,2,5,2,1,1,4,5,2,4,5,3,4,4,1,2,4,4,5,3,5,5,3,1,1,1,4,2,2,2,1,5,5,2,3,1,5,1,5,4,3,5,3,3,4,1,5,4,2,4,1,3,5,2,1,4,4,2,1,5,4,3,3,3,1,4,4,4,2,1,4,5,1,3,5,3,3,3,3,3,5,1,4,4,4,3,2,2,3,2,1,4,2,4,4,2,4,5,2,1,3,4,1,5,1,3,1,3,2,3,5,1,3,5,2,4,5,1,3,3,5,5,3,4,4,5,1,4,3,4,3,3,3,1,3,5,2,2,1,4,5,5,3,3,4,1,2,1,1,2,1,4,5,3,3,3,5,1,5,5,5,3,2,4,1,4,5,4,1,3,2,4,1,1,5,5,5,4,2,2,5,4,3,2,2,4,2,4,2,5,4,5,3,3,1,2,1,1,5,2,1,4,1,2,4,2,5,4,1,1,4,4,2,3,2,3,3,5,2,4,3,2,4,4,2,2,2,3,3,4,5,2,2,3,2,4,5,3,5,3,1,4,1,1,2,2,3,2,4,5,4,1,3,1,5,4,3,5,5,3,1,1,1,4,1,5,2,1,2,1,5,3,4,1,1,4,2,3,3,3,1,1,4,2,2,3,4,3,4,3,3,4,2,1,5,3,4,2,2,4,5,2,3,3,4,2,1,4,3,4,5,2,4,1,4,3,3,1,1,1,2,3,1,1,5,5,2,1,4,3,3,2,3,5,2,2,2,2,1,4,4,2,5,4,5,2,2,5,2,3,2,1,3,2,2,2,5,4,2,5,1,2,5,4,3,4,2,4,3,1,4,2,1,3,5,4,5,4,3,5,1,1,5,4,2,1,3,4,2,4,1,3,4,4,2,5,4,5,5,2,3,3,5,5,4,3,5,3,4,3,2,1,1,2,5,1,1,2,1,2,4,1,4,4,1,1,5,1,4,1,1,1,1,4,3,3,4,2,2,1,3,4,3,1,3,2,2,1,3,1,3,4,3,3,3,5,3,1,5,1,5,1,4,5,5,5,3,2,1,5,1,1,1,1,3,3,1,4,3,4,4,5,4,4,3,3,4,5,5,4,1,5,2,4,2,4,5,2,1,4,2,4,1,3,1,4,3,4,5,5,3,5,3,1,3,4,4,4,1,2,2,2,3,1,2,2,4,1,1,3,4,3,2,1,4,1,4,3,2,3,2,3,1,1,1,5,3,3,2,3,3,5,5,1,4,4,2,2,3,2,2,1,5,2,3,3,3,5,5,1,5,5,4,3,2,5,1,5,2,3,4,1,4,2,2,5,1,3,4,2,4,5,3,5,5,3,4,3,3,2,2,2,2,1,4,1,4,5,2,3,5,4,5,3,5,5,5,1,4,2,1,4,2,2,3,5,5,1,1,2,1,4,1,4,3,2,4,2,1,3,1,2,5,4,3,1,1,4,2,3,1,4,4,3,1,5,4,5,4,2,2,1,1,5,3,2,4,3,3,3,1,2,2,5,3,1,1,1,3,5,2,2,4,3,3,3,2,3,2,2,1,2,4,2,4,1,2,2,5,2,1,1,5,2,1,2,5,1,1,3,1,5,5,1,5,5,3,1,4,5,2,4,2,1,3,5,5,2,3,1,3,4,4,5,3,3,3,4,5,5,2,1,2,3,2,1,5,1,2,1,2,1,5,4,3,2,5,5,2,3,2,5,3,5,2,2,3,3,2,3,2,5,4,5,3,3,5,4,3,1,3,4,3,4,4,5,5,4,5,4,5,2,2,5,3,1,4,1,3,5,1,4,2,5,2,2,1,4,5,4,1,3,5,3,5,1,3,1,5,3,2,3,1,1,5,3,5,1,5,2,4,1,1,4,5,2,2,4,4,4,5,2,2,5,3,5,4,1,3,1,2,5,2,4,1,4,1,2,4,4,4,4,5,1,3,2,4,2,5,5,3,4,5,2,4,4,3,2,3,4,2,4,3,3,2,2,2,1,2,1,4,3,5,1,3,2,4,5,3,3,4,4,5,2,1,5,2,4,3,3,4,1,5,4,5,4,4,5,4,3,3,1,4,1,2,3,5,4,4,2,2,5,5,5,3,4,5,1,1,3,4,2,1,3,4,1,3,3,5,3,2,1,4,1,5,4,3,4,4,2,3,4,5,1,2,3,3,2,3,4,4,2,2,1,5,1,3,1,2,2,5,4,5,3,4,4,2,5,1,4,1,1,4,4,1,4,4,5,4,3,3,3,5,1,2,5,3,4,4,4,3,5,4,5,5,5,3,4,1,4,4,5,4,4,4,4,4,5,2,2,1,2,2,4,5,1,3,1,5,3,2,1,4,4,5,4,3,4,1,3,1,4,1,3,1,3,5,4,1,5,5,5,1,5,1,2,2,4,5,3,5,3,2,3,3,5,5,4,3,5,5,2,1,2,4,5,4,5,4,2,4,4,1,3,1,2,2,3,1,5,5,2,3,5,3,3,3,5,4,1,2,5,2,1,2,5,1,1,1,2,3,3,2,3,4,1,2,1,3,4,3,2,3,4,3,4,4,4,5,3,2,5,3,1,1,2,5,4,3,2,4,1,3,5,4,1,2,2,1,1,2,4,3,2,3,1,2,1,4,5,3,2,1,2,4,3,4,2,5,3,3,4,3,3,3,3,1,3,4,5,5,4,3,1,5,4,1,5,1,2,4,4,5,5,1,3,5,3,5,5,2,3,4,2,2,5,1,4,1,3,2,5,3,2,2,3,2,4,2,3,5,1,4,1,3,2,3,4,5,4,1,2,3,2,1,2,1,2,2,4,2,5,1,4,3,4,3,3,3,3,4,5,3,5,3,2,2,5,5,4,3,5,4,3,1,4,5,1,1,2,4,3,5,1,4,2,3,3,1,1,2,4,5,3,4,3,5,4,1,1,5,2,5,2,2,3,2,5,1,1,1,3,4,5,1,1,2,3,2,3,5,5,1,3,5,5,2,3,5,3,2,1,5,2,2,3,4,1,4,5,5,1,5,5,3,1,3,4,5,3,5,4,3,4,1,2,5,4,5,2,3,4,3,1,4,3,5,5,2,5,1,1,3,4,3,3,1,4,5,1,3,2,2,1,5,2,4,3,5,2,4,4,4,5,2,5,2,5,5,5,3,4,5,5,2,5,4,3,5,3,4,5,3,5,4,4,2,3,4,3,2,3,4,2,2,3,4,5,1,5,2,2,3,2,4,5,2,3,3,5,2,4,3,5,3,2,5,4,4,3,3,1,4,5,3,4,2,1,3,4,2,1,3,1,2,1,1,2,5,4,3,2,1,1,2,5,3,1,5,5,5,5,5,2,4,3,4,1,5,3,2,4,2,3,2,3,5,4,2,1,1,2,5,2,3,2,1,3,5,4,2,1,5,3,5,4,3,1,1,5,2,1,1,5,1,1,1,3,3,4,4,3,2,3,3,5,3,2,5,5,3,1,1,5,1,2,5,1,1,2,2,1,3,3,5,5,3,3,1,2,4,4,5,3,5,1,2,3,2,3,5,3,5,5,4,3,3,3,1,5,4,4,4,5,1,1,4,3,5,2,1,1,4,4,4,3,1,5,4,3,3,4,4,2,3,4,5,3,1,3,1,2,5,5,1,3,3,4,2,4,2,1,3,3,4,5,5,5,1,5,4,1,5,3,1,2,4,5,4,1,5,5,4,3,5,3,3,1,3,5,2,3,5,2,5,2,4,4,4,3,3,1,1,4,1,3,1,3,4,5,2,5,1,5,4,2,5,4,3,2,2,4,1,4,1,4,3,5,2,4,5,1,3,3,5,4,2,2,4,3,4,2,3,3,4,5,2,1,5,5,5,3,3,5,2,3,1,4,5,2,2,5,2,4,1,4,3,5,4,3,4,2,1,3,4,5,3,1,5,4,1,2,3,5,1,3,2,4,2,5,1,5,1,1,4,1,2,3,1,2,3,2,4,2,1,2,3,2,1,1,4,2,4,4,4,3,2,1,5,3,4,1,2,4,3,5,5,5,2,4,5,4,2,3,5,4,5,2,3,3,1,3,5,5,5,3,5,5,5,5,5,1,3,3,5,1,4,3,5,1,4,3,4,1,4,2,2,3,2,5,1,2,5,1,4,2,5,4,4,4,4,2,5,1,4,3,5,4,4,2,5,5,5,5,4,1,3,2,5,4,4,3,1,3,3,3,4,2,4,1,3,3,4,3,5,1,4,1,3,3,2,3,4,3,5,4,1,4,5,5,1,3,1,1,3,3,4,5,2,4,4,1,1,2,2,5,4,5,3,3,2,3,1,5,1,1,4,5,1,3,5,4,4,5,1,4,1,1,3,2,1,2,1,2,1,4,4,4,4,3,3,4,3,1,1,5,3,1,5,5,2,2,5,1,4,4,1,4,2,4,4,2,3,1,2,2,3,5,2,3,3,2,5,3,1,3,5,4,2,2,4,4,3,2,3,3,3,5,1,5,5,3,1,2,4,5,2,1,4,3,4,3,3,1,5,5,5,3,2,2,5,4,3,5,3,3,5,4,3,2,1,3,1,4,4,2,5,2,3,1,2,4,2,3,4,3,4,5,1,2,1,1,4,2,5,4,4,4,5,3,1,5,4,2,2,1,1,4,4,2,5,5,3,4,2,5,5,2,2,1,2,2,1,3,1,5,3,1,4,2,5,5,3,2,5,3,4,2,1,3,2,1,3,1,4,2,5,1,5,2,4,3,2,5,4,3,3,2,5,2,1,4,3,1,4,4,4,4,3,3,5,5,3,2,3,3,2,2,2,1,2,5,3,3,1,3,4,5,5,4,3,1,3,3,4,5,2,1,4,4,1,5,2,4,4,5,4,1,3,1,2,4,1,4,1,1,2,2,1,1,5,5,1,4,4,4,5,1,5,1,4,3,3,5,2,3,3,3,1,3,1,1,3,4,5,5,2,4,1,4,1,3,5,4,1,4,4,3,2,1,3,1,2,4,4,1,1,2,4,4,2,3,1,1,1,2,5,3,4,4,5,1,2,2,5,2,1,2,5,1,3,5,4,5,1,2,3,5,5,4,2,5,5,2,3,2,3,3,3,1,2,1,1,1,4,3,1,2,5,2,3,4,3,1,1,3,4,3,1,4,1,3,1,5,1,4,1,3,5,3,1,1,3,3,4,1,3,5,4,3,3,1,1,1,4,1,2,2,1,1,4,2,4,4,3,4,5,5,3,3,5,2,4,4,5,3,3,5,5,5,4,3,2,1,2,1,4,4,4,4,5,5,2,2,5,1,4,3,5,3,5,4,3,5,1,1,4,2,3,1,2,2,2,1,2,2,1,5,3,2,1,4,1,4,4,1,5,5,5,3,5,5,1,1,5,5,5,5,3,4,2,3,5,2,2,5,4,1,2,2,5,4,2,3,2,3,5,2,1,2,4,4,4,4,3,1,2,3,5,2,4,1,3,3,4,4,4,1,1,5,4,3,4,4,5,4,5,2,2,2,2,2,1,5,5,4,3,5,4,4,5,5,1,2,2,1,5,3,4,4,2,4,4,5,2,1,5,5,2,5,3,4,4,2,4,1,1,3,4,5,2,1,5,2,5,3,3,1,4,4,4,3,1,5,4,5,4,2,5,4,1,5,4,2,5,3,2,3,3,3,1,4,2,5,2,1,3,5,1,3,4,2,2,4,2,5,1,5,2,5,2,4,5,4,1,4,5,1,5,1,1,4,3,4,5,2,5,1,1,3,2,5,2,5,1,1,2,4,4,2,3,5,3,5,2,4,5,2,3,3,1,5,3,1,2,3,2,4,4,5,1,1,2,1,3,2,2,5,2,1,2,2,2,4,5,1,2,5,1,5,4,3,4,4,3,4,2,4,1,5,1,1,2,2,3,3,3,2,2,3,2,2,4,2,4,5,2,1,2,3,5,3,3,4,5,4,3,1,1,5,5,3,1,3,3,2,3,3,2,4,4,4,5,5,4,2,4,5,5,2,1,3,4,2,3,5,4,5,2,4,3,5,1,4,3,4,2,4,5,2,1,5,3,4,5,3,4,5,1,1,2,4,4,4,5,5,2,2,5,2,3,5,5,1,3,5,2,4,1,5,3,2,3,2,5,4,5,5,4,3,3,2,2,2,3,1,2,4,3,2,2,5,2,3,3,1,1,2,5,3,2,5,2,4,5,5,2,3,2,4,3,5,1,5,5,5,3,3,4,3,5,5,3,5,3,2,2,4,2,5,3,5,1,3,1,2,3,3,3,2,1,1,4,2,3,4,5,4,1,5,1,3,1,1,3,4,4,3,5,3,5,2,4,2,1,2,4,3,4,1,2,1,4,1,1,3,4,4,5,1,1,1,3,4,2,1,2,5,1,4,3,4,1,5,1,5,4,3,1,4,2,5,1,4,3,5,4,4,1,1,1,4,3,1,3,4,4,4,5,1,1,1,5,3,5,2,3,1,1,1,3,4,2,1,5,4,1,4,4,1,4,1,5,2,2,3,5,4,4,5,2,1,1,1,3,4,5,4,5,5,3,4,2,2,5,3,2,3,2,4,3,3,5,4,5,1,1,3,4,4,5,5,4,4,1,3,4,4,2,2,3,4,5,5,3,1,5,4,2,3,1,3,1,2,2,3,2,1,3,1,3,1,5,5,5,4,2,1,2,3,5,4,2,2,3,1,3,5,4,5,1,3,2,1,5,3,3,1,2,3,2,2,4,1,2,3,4,1,2,5,5,5,3,2,1,2,3,4,4,2,3,4,1,2,1,2,1,4,4,1,4,1,5,1,4,2,2,5,5,3,2,4,1,3,5,4,4,3,1,3,1,4,3,2,3,5,5,3,2,2,4,5,1,1,5,3,4,5,4,5,5,2,3,1,1,5,2,2,1,2,5,2,2,5,4,5,1,3,4,3,2,3,3,1,4,2,4,4,4,4,5,3,1,5,3,3,1,1,3,5,1,4,4,2,5,1,5,3,1,3,3,1,5,3,3,5,5,3,2,5,4,1,1,1,1,5,1,5,3,1,1,5,5,3,2,4,4,1,5,1,3,3,3,4,5,2,3,5,4,4,5,2,5,1,4,1,4,2,2,4,3,2,4,5,3,1,4,3,3,5,2,5,3,2,1,3,4,1,5,5,3,3,1,4,1,5,2,5,2,1,1,2,1,4,5,3,3,1,2,5,1,4,5,3,5,5,3,1,2,3,2,5,1,3,2,5,4,2,2,5,5,2,5,4,2,1,3,3,3,1,5,5,5,4,4,2,3,5,3,5,2,4,3,2,2,5,3,4,3,4,1,4,5,2,1,5,3,1,5,4,4,3,3,4,5,3,3,3,4,4,3,3,4,2,1,1,5,2,2,1,3,3,5,5,3,4,5,4,4,1,4,4,3,4,5,3,3,3,2,4,2,2,5,5,1,3,3,5,3,1,3,1,5,1,1,4,5,4,2,5,5,1,4,2,2,4,4,1,4,4,4,1,3,5,5,4,3,2,2,1,4,2,2,5,3,5,1,1,4,3,5,2,2,2,5,4,2,2,3,5,3,2,3,4,4,5,4,5,5,3,5,2,2,4,5,2,4,2,1,4,2,5,3,3,2,4,3,1,3,2,3,3,2,4,3,3,1,1,2,3,1,4,3,2,4,2,2,1,5,1,1,2,5,1,5,1,2,3,5,1,3,2,1,1,4,2,4,1,5,1,4,5,5,4,4,3,4,4,5,3,4,3,1,2,5,1,2,5,2,3,3,1,5,1,2,4,3,2,1,2,2,4,2,2,2,4,3,5,4,4,2,5,1,3,3,2,2,5,2,5,2,2,4,1,4,2,5,1,2,5,2,3,4,3,2,4,5,5,4,5,4,3,3,4,4,1,3,3,2,5,3,3,1,4,3,2,5,3,3,5,4,1,4,1,5,5,5,5,2,1,5,4,2,5,4,5,3,1,2,5,3,2,2,5,2,1,5,4,1,2,2,3,2,3,4,2,4,3,1,2,1,1,2,3,2,2,2,4,2,1,5,4,1,5,4,2,3,3,5,1,5,3,4,4,4,2,3,1,3,1,2,3,2,4,5,4,5,3,5,3,2,1,5,4,3,1,4,5,5,1,2,2,4,3,5,4,2,3,5,1,3,5,1,4,1,3,4,3,5,4,4,4,3,4,1,2,4,1,4,1,5,5,1,3,5,3,3,2,3,2,5,2,4,5,1,1,5,3,4,3,2,2,2,5,2,4,2,4,4,4,3,5,1,1,1,3,4,5,5,4,1,5,3,1,2,1,2,1,3,4,4,1,3,4,4,1,2,2,3,5,5,4,3,1,2,3,4,4,1,5,5,5,4,1,1,4,1,5,2,2,1,5,2,1,4,5,2,1,5,1,5,2,2,1,4,5,1,1,4,1,3,2,4,5,5,4,1,5,3,4,4,3,1,5,3,4,4,2,2,2,5,2,3,3,5,3,2,2,1,5,3,1,5,5,1,4,5,5,3,3,2,2,3,2,4,2,5,4,3,2,5,5,4,4,2,4,3,1,2,4,3,1,4,1,5,2,5,2,4,3,1,2,4,1,3,1,3,1,4,5,4,5,4,5,5,2,1,5,2,2,3,4,5,1,3,5,4,4,2,3,5,3,2,2,5,1,4,2,3,3,5,1,3,1,5,2,5,3,3,3,4,3,3,4,1,4,3,2,3,3,1,5,1,4,5,3,1,3,1,5,5,2,2,1,2,1,1,1,5,1,1,3,5,2,3,1,3,4,5,5,2,1,3,2,3,1,3,4,2,2,2,4,3,5,2,2,3,3,4,1,1,2,3,5,5,3,4,3,2,5,3,1,1,1,2,4,4,2,5,4,5,1,2,3,1,3,3,4,1,3,3,1,4,3,4,4,3,1,4,4,1,3,2,4,3,5,3,5,5,1,3,5,5,2,3,5,4,1,3,2,1,3,5,2,1,4,5,3,2,1,2,1,4,3,1,5,2,1,2,3,2,5,1,4,3,2,2,5,1,1,3,4,5,5,1,4,4,4,4,4,2,4,2,2,3,4,4,4,1,4,3,3,2,4,1,1,4,2,3,2,4,1,2,4,3,4,5,1,1,3,1,3,1,2,4,5,2,3,2,4,2,3,3,2,3,2,2,3,3,4,1,2,1,1,4,1,5,4,1,5,5,4,1,1,2,4,3,4,5,3,1,1,5,1,3,5,1,2,3,2,5,3,2,5,4,4,3,1,2,5,5,1,2,4,2,5,4,1,4,2,2,4,5,1,1,5,5,4,3,1,3,5,4,5,2,5,4,1,2,2,3,2,4,5,2,5,5,1,3,2,2,1,1,3,4,2,2,2,3,1,3,2,4,2,1,5,1,1,2,5,3,4,5,5,1,3,3,5,4,5,3,5,1,2,4,1,2,4,5,3,3,1,1,1,2,5,3,3,4,3,4,4,5,2,2,2,1,2,2,5,3,3,2,3,5,5,2,1,3,5,1,4,5,4,2,4,3,2,3,2,2,3,3,3,2,3,1,1,2,4,3,3,5,4,1,4,4,2,4,5,3,2,5,1,3,1,5,3,5,3,1,3,1,5,1,4,4,4,4,5,3,4,4,5,4,3,5,2,4,1,3,2,1,5,1,5,4,5,2,1,1,3,4,4,2,5,5,5,1,3,2,5,2,5,4,3,5,5,3,1,5,3,4,2,3,4,1,1,1,3,4,1,1,4,4,3,3,5,1,2,4,5,4,5,3,5,4,3,5,4,5,2,1,1,3,5,2,4,2,3,3,1,2,5,1,2,3,5,1,4,3,4,4,1,2,1,5,1,5,4,4,1,1,5,4,4,1,1,4,5,2,2,3,4,5,3,2,1,3,1,3,4,5,5,2,1,2,3,4,1,1,1,1,1,4,1,1,3,1,2,5,2,3,5,5,5,4,3,4,5,2,2,5,1,2,4,4,2,2,3,1,2,5,2,5,4,1,5,3,4,4,1,1,1,5,2,5,2,2,4,5,4,1,5,5,2,1,1,1,3,3,2,5,5,5,1,5,5,4,1,2,5,4,5,3,1,5,2,5,1,1,4,3,4,2,3,3,1,1,3,5,1,5,2,5,1,2,1,1,5,4,3,3,3,3,2,3,2,4,5,4,1,1,5,1,2,1,2,1,3,2,5,4,3,1,4,4,2,4,4,4,5,1,2,3,3,5,3,1,3,2,1,5,5,2,1,2,4,2,1,1,2,1,5,3,2,3,2,5,2,1,5,3,2,1,2,2,2,5,2,2,4,3,2,3,4,5,4,1,2,3,4,5,2,5,2,5,3,3,1,1,2,3,1,2,5,3,4,2,3,2,5,3,2,5,2,4,2,3,3,5,1,1,1,1,2,2,2,4,2,4,4,2,5,3,2,5,2,4,1,1,4,2,5,3,3,2,2,4,3,4,3,2,3,3,2,3,4,3,1,5,1,1,4,4,1,3,5,2,5,3,4,2,4,4,1,2,3,2,4,2,5,5,1,3,5,1,4,1,1,4,3,2,2,2,1,4,1,4,2,2,5,1,1,2,1,5,2,1,4,2,3,3,5,2,5,1,2,1,3,5,4,1,1,1,1,1,1,2,3,3,5,2,4,3,5,1,1,3,3,3,4,4,1,3,4,4,5,4,1,2,5,2,4,2,5,5,2,3,5,2,3,3,5,5,1,3,2,2,3,3,2,5,5,3,4,3,3,4,4,2,2,1,4,5,4,1,2,1,4,2,2,1,2,1,5,1,1,1,1,5,4,2,5,2,2,5,5,5,4,4,1,3,3,4,4,4,4,2,1,1,3,3,5,2,3,2,2,4,1,4,3,4,1,2,5,5,4,3,4,1,3,2,5,5,5,5,1,1,3,2,2,3,3,4,5,4,2,2,3,1,5,1,4,4,4,4,1,3,1,2,4,5,2,3,1,1,2,4,5,1,4,1,4,3,2,4,2,4,2,4,2,4,4,1,4,1,2,1,1,5,2,3,5,3,5,4,2,3,1,4,5,1,3,4,5,5,3,5,4,3,3,1,4,3,3,1,5,1,5,4,5,5,2,3,4,1,1,3,5,3,3,5,3,1,1,1,4,1,4,3,4,3,2,1,1,5,5,5,2,3,2,4,5,5,4,5,3,5,1,5,1,1,2,3,3,5,4,1,1,2,1,2,3,3,5,4,2,5,3,5,5,4,5,5,5,2,5,4,1,3,5,1,3,4,1,3,2,3,3,5,5,4,4,3,2,3,2,5,3,1,3,1,4,2,5,4,2,2,4,2,5,3,5,2,1,3,3,5,5,1,5,4,5,2,2,4,2,1,3,4,2,5,5,3,3,4,4,2,2,3,5,4,2,3,4,1,1,3,5,2,2,4,4,1,3,1,1,3,2,3,4,5,3,1,5,2,2,4,2,2,3,2,3,2,3,3,5,5,3,1,1,4,1,2,5,5,5,3,3,1,3,1,4,5,5,5,2,2,2,5,1,1,4,3,2,4,3,3,4,5,5,5,2,1,2,1,3,3,1,5,4,5,4,5,5,2,3,5,5,3,3,5,3,2,2,4,3,2,1,1,1,5,3,3,5,3,4,5,3,2,1,5,4,5,2,1,1,5,1,2,2,4,5,4,1,4,3,2,3,5,5,5,1,1,4,5,2,4,1,2,5,1,3,2,3,3,5,1,3,1,3,5,5,1,5,2,2,5,5,5,1,1,5,4,3,5,3,5,4,4,3,4,5,1,5,4,5,1,4,5,5,4,4,5,3,1,5,2,3,1,1,5,5,1,1,3,1,1,5,2,3,2,3,1,4,1,2,2,5,1,4,4,5,2,1,4,5,2,1,2,5,2,4,3,4,2,1,1,1,3,3,5,5,4,1,3,2,2,4,4,2,1,1,3,2,2,4,5,5,4,3,5,1,2,3,1,4,3,2,5,5,3,4,2,3,3,1,1,1,4,3,3,5,1,4,2,5,5,4,4,4,3,2,5,1,5,5,2,4,5,5,2,4,4,5,2,1,3,5,4,1,4,3,2,1,5,3,2,1,5,1,4,1,4,2,2,1,4,2,1,4,3,2,3,3,5,3,3,4,5,4,1,2,4,1,5,3,5,2,2,3,2,4,2,2,2,1,5,2,5,5,1,5,2,4,2,5,2,4,5,1,3,1,5,2,4,4,2,5,1,1,1,1,1,3,4,5,4,1,3,2,2,1,5,2,4,3,1,5,1,2,1,3,1,3,1,4,5,5,3,2,2,3,4,1,5,1,4,5,3,1,5,5,2,5,5,4,1,2,1,1,3,2,5,5,3,2,4,1,1,1,3,5,3,1,2,5,1,4,3,5,2,4,2,4,4,1,3,2,5,4,1,2,2,4,5,1,1,2,4,5,5,1,4,4,4,2,5,5,4,3,3,5,3,3,3,1,2,2,4,5,2,5,2,3,2,4,2,2,5,2,4,3,1,1,5,3,1,5,4,3,4,5,1,3,1,1,5,4,1,2,4,5,1,1,4,2,5,5,4,3,1,5,4,3,4,4,1,3,1,4,1,4,4,5,2,5,5,5,1,4,3,1,3,3,4,5,3,1,2,3,1,5,1,2,1,5,1,1,5,2,5,1,4,5,5,2,3,1,1,2,5,2,5,4,4,1,1,3,1,1,1,4,1,4,4,2,3,3,5,1,4,4,2,4,5,2,2,2,4,2,5,5,4,5,4,5,4,4,2,1,5,3,4,4,3,4,5,2,2,2,4,4,5,4,2,1,2,3,3,2,4,2,5,2,4,1,3,1,1,4,2,4,4,3,3,1,1,3,2,1,1,3,3,1,3,1,4,2,1,5,3,5,1,5,5,1,3,1,3,4,5,2,1,3,5,3,5,4,5,4,4,1,1,1,1,3,3,1,3,2,4,3,2,4,4,1,2,5,3,1,5,2,1,5,4,1,3,4,4,4,5,3,2,5,1,2,1,5,2,1,4,4,4,5,5,3,3,1,1,3,3,3,2,1,2,3,2,3,5,4,3,4,1,4,3,2,1,2,4,1,2,5,5,4,2,3,2,5,5,4,4,2,1,5,3,3,5,5,3,1,2,3,5,5,1,5,1,5,4,5,5,5,1,5,4,3,2,4,4,4,1,4,4,1,1,2,3,4,5,1,5,4,3,1,4,2,3,5,2,4,4,2,1,5,3,5,1,1,3,2,4,3,4,2,2,5,2,1,4,1,1,4,2,2,4,5,2,1,5,3,3,5,1,5,5,2,4,4,2,2,5,2,3,2,1,2,2,2,1,5,2,3,1,4,3,1,3,3,1,3,3,1,3,1,5,5,3,2,5,5,5,4,4,1,3,3,5,1,5,4,2,1,3,1,1,4,5,4,4,2,5,1,5,3,4,1,3,2,3,2,5,5,5,4,2,5,5,2,5,3,3,4,3,4,4,3,3,2,3,1,1,3,1,3,1,4,1,5,3,5,1,2,4,1,5,4,3,3,1,4,4,3,3,1,4,4,5,5,2,3,2,2,2,5,5,1,4,3,5,3,3,2,5,5,1,2,4,5,4,2,1,3,4,1,5,1,1,4,1,4,2,4,2,5,2,1,2,4,3,3,1,2,2,1,5,5,2,4,3,3,3,2,3,5,2,2,4,2,1,2,2,3,4,4,1,4,1,2,4,3,4,1,1,3,2,2,3,2,4,5,1,1,4,4,1,4,1,3,2,1,4,3,4,4,1,1,1,2,2,4,3,1,4,2,1,5,4,1,3,5,3,5,4,5,4,4,3,4,4,5,2,2,4,1,3,5,5,2,1,2,1,5,3,5,4,3,1,2,3,2,1,4,3,5,5,2,5,2,2,2,2,3,4,1,5,3,2,5,3,3,3,4,2,5,5,5,4,4,5,3,1,1,4,3,3,3,5,2,1,4,2,1,1,1,3,3,1,1,5,4,4,1,3,4,1,5,3,4,4,2,4,5,5,4,2,1,4,3,3,1,2,1,3,1,3,3,2,5,5,5,4,2,3,2,5,2,4,5,1,3,2,5,5,5,3,5,3,1,5,1,5,5,4,4,2,4,2,4,3,5,4,2,1,2,4,1,1,2,3,1,3,4,4,5,3,4,1,4,1,5,5,4,1,4,4,4,5,4,2,1,2,5,1,4,1,1,4,4,4,1,5,3,5,3,4,2,3,1,3,1,3,2,2,4,1,4,5,2,1,4,5,4,5,4,3,1,2,4,4,1,1,2,5,3,5,3,3,4,4,3,5,2,1,5,5,5,2,1,1,1,3,2,4,3,5,4,3,4,5,5,2,2,4,4,4,3,5,4,1,4,1,3,1,4,1,3,1,4,1,5,2,2,3,1,2,1,1,2,2,5,4,2,4,3,5,3,3,3,2,2,2,2,2,3,5,5,3,5,2,1,5,2,4,2,3,4,2,5,1,4,1,1,5,3,4,3,3,1,3,3,4,1,1,2,5,1,5,1,3,2,1,1,1,2,3,4,5,5,3,2,2,2,5,3,4,2,3,3,1,3,2,5,3,1,3,2,3,4,2,4,2,5,3,5,1,3,1,4,1,1,3,5,1,5,2,3,2,3,1,2,4,3,3,3,2,1,5,3,4,1,4,4,3,5,5,5,4,2,4,4,5,5,4,1,1,4,2,4,3,4,4,5,5,3,1,1,3,2,4,1,2,3,5,4,4,4,1,3,5,4,1,2,5,2,2,3,3,3,1,1,2,1,3,4,5,2,4,1,5,1,2,2,4,2,4,3,5,3,3,1,4,1,5,3,1,2,4,3,5,2,2,1,3,1,2,4,1,4,1,5,4,4,4,5,1,3,4,5,4,3,5,5,2,2,5,4,4,2,5,5,5,4,4,1,2,4,4,2,4,4,4,5,4,2,1,1,2,5,3,5,3,1,4,4,1,3,4,1,4,3,2,4,2,4,5,1,4,1,3,3,5,1,5,2,4,2,1,2,3,3,3,3,5,2,3,5,3,1,3,3,2,4,2,3,5,1,5,5,3,4,1,4,4,1,4,4,4,5,4,1,4,1,5,3,2,2,1,2,1,3,4,2,1,4,2,4,4,5,1,4,2,5,1,1,2,2,3,4,3,5,2,5,5,3,5,1,5,5,4,2,4,4,1,5,3,2,2,1,5,5,4,4,5,4,3,1,2,4,4,1,1,3,5,1,5,1,5,4,4,5,1,2,3,3,4,3,1,3,5,3,3,2,2,3,5,2,2,3,2,1,1,4,4,2,3,2,2,3,5,1,4,4,1,1,2,3,4,5,3,2,4,3,3,4,2,5,4,1,5,2,5,3,4,4,5,2,4,5,4,4,4,5,2,3,5,3,3,3,5,2,1,3,5,5,1,4,5,2,3,4,5,5,1,2,3,5,1,4,1,2,2,3,3,1,5,5,4,3,3,3,4,4,2,5,5,2,2,2,1,2,3,3,2,3,3,4,5,2,4,5,5,2,5,1,4,4,1,4,1,3,1,5,4,4,3,1,5,3,2,1,4,5,4,1,1,2,5,1,5,4,2,1,2,4,2,2,4,4,4,3,3,3,2,3,2,4,1,4,3,3,1,2,2,3,4,3,2,5,2,2,4,2,1,2,4,2,2,5,3,1,3,2,5,5,2,2,5,3,2,2,2,4,4,4,3,3,2,1,5,4,4,3,4,4,3,5,2,1,2,2,1,3,3,3,3,5,5,4,5,4,2,2,4,4,5,1,4,3,5,3,4,2,4,5,5,1,1,5,5,3,4,4,2,5,4,1,2,1,2,4,1,4,4,3,1,2,4,3,1,4,1,5,1,3,3,2,4,4,5,2,5,2,2,4,5,4,3,4,1,2,4,1,1,2,5,1,4,1,3,1,3,4,2,1,1,5,2,5,2,3,5,4,5,5,3,5,4,4,1,1,1,4,5,5,3,4,2,5,4,5,2,1,1,5,4,4,4,1,3,3,4,5,1,3,3,1,4,1,2,3,3,5,2,2,3,5,3,3,1,1,1,2,1,2,1,5,2,3,3,3,3,4,2,3,4,2,2,4,4,3,3,4,4,4,2,2,3,3,3,2,3,2,3,3,3,5,1,1,1,1,5,4,1,2,4,1,5,5,3,1,3,2,3,1,3,2,2,3,5,1,5,1,5,2,3,5,5,3,1,3,2,1,2,5,5,2,2,3,3,2,5,3,4,2,1,3,5,4,3,1,4,4,3,3,2,2,2,5,2,2,4,3,4,2,1,4,5,5,5,3,4,2,2,3,1,2,5,3,2,4,3,3,5,2,1,3,5,2,5,3,4,2,5,5,2,2,1,2,5,4,4,3,2,5,5,1,3,3,3,5,3,4,5,5,4,3,3,4,4,5,4,5,2,4,5,2,2,4,3,4,4,3,4,2,3,3,2,1,1,5,4,1,2,2,3,5,3,5,4,1,1,2,1,2,1,1,2,3,3,5,5,1,4,3,5,1,1,5,5,5,1,2,2,4,2,3,5,4,1,4,4,1,4,4,5,3,2,2,4,4,3,4,1,3,4,5,2,3,4,4,4,5,4,3,4,1,5,5,5,4,4,2,4,3,2,5,4,4,5,5,1,1,5,4,4,4,3,4,5,3,1,2,1,2,4,4,2,5,1,2,3,3,3,5,4,1,5,2,3,2,1,5,2,5,3,1,3,2,4,2,3,1,3,2,1,4,3,3,1,2,2,3,2,2,5,5,3,1,4,1,3,4,4,1,3,1,3,3,4,1,1,5,1,2,5,2,5,2,3,3,4,5,2,3,1,1,2,5,3,2,2,1,1,1,1,4,4,2,4,2,5,4,3,3,2,1,3,4,1,5,5,5,4,5,5,3,2,2,1,5,1,4,3,1,1,3,3,2,2,3,1,3,4,3,2,5,4,4,2,3,4,3,4,2,3,1,4,3,3,5,1,3,3,5,5,5,2,2,1,1,4,4,5,1,1,3,5,2,2,1,4,3,4,4,5,2,2,5,4,4,4,1,1,3,4,4,3,2,4,3,4,3,5,5,5,3,4,2,4,4,5,3,5,3,5,5,2,4,1,3,1,2,3,5,1,4,1,2,1,1,4,5,1,5,4,2,1,3,2,5,3,1,3,1,3,3,5,3,5,4,4,1,2,4,5,4,5,5,3,3,4,3,1,1,3,4,3,2,5,2,1,3,4,1,3,1,5,1,1,5,3,5,4,3,5,4,1,3,3,5,1,4,1,2,4,5,3,3,2,4,5,2,4,1,2,4,5,1,2,5,2,4,3,2,5,4,4,1,2,2,2,2,1,4,2,4,5,1,1,4,5,3,1,2,3,3,4,3,5,3,2,1,1,4,2,5,4,4,4,4,5,4,2,3,1,2,5,3,2,3,3,3,2,5,3,2,5,3,3,4,5,2,5,4,4,4,1,3,2,4,3,3,5,3,4,3,4,4,3,4,1,4,1,3,5,4,1,5,2,2,5,2,2,3,1,5,4,1,4,4,2,5,1,2,5,4,5,2,3,1,4,1,2,4,1,1,4,5,2,3,2,5,1,5,1,5,5,1,3,1,4,5,2,3,5,5,4,1,3,2,5,1,1,4,1,2,4,2,4,2,5,3,1,3,2,3,1,3,5,4,1,2,5,4,5,5,5,5,4,1,2,4,2,3,3,3,2,5,1,4,3,4,3,4,2,3,1,2,2,5,2,5,1,3,3,4,4,2,1,3,3,2,5,3,2,3,5,3,4,4,3,2,3,4,5,1,4,3,2,2,4,4,2,2,5,1,5,5,1,4,3,5,4,2,4,4,1,5,4,4,1,4,5,1,2,1,1,1,3,2,2,2,4,5,1,4,1,2,5,3,2,5,4,2,4,5,4,3,2,2,5,1,3,5,2,5,2,3,4,3,1,5,5,2,5,2,2,1,4,1,3,4,4,2,3,5,1,4,1,3,4,5,3,5,2,2,4,1,2,1,3,4,3,3,4,4,1,5,4,3,2,2,2,3,4,4,4,1,1,1,4,5,3,2,3,5,2,3,3,3,2,3,4,3,4,2,2,3,5,4,1,3,5,3,3,3,1,4,2,3,2,2,1,3,2,4,2,5,5,3,2,3,4,2,1,2,1,4,3,2,2,4,5,1,5,1,3,4,2,2,5,1,4,2,1,5,3,1,1,1,1,1,2,3,3,1,2,3,4,1,3,4,1,3,2,2,1,5,1,5,2,3,4,4,1,4,5,3,3,4,5,4,4,4,2,3,1,5,4,5,2,2,5,5,4,3,5,5,1,4,4,1,1,5,1,3,1,5,2,2,1,4,5,1,2,2,5,5,4,5,3,3,3,5,4,5,2,5,1,1,2,5,5,4,5,3,3,2,3,1,5,2,1,2,4,3,2,3,5,5,1,5,4,4,4,4,4,4,5,1,5,1,4,2,5,3,2,3,1,2,4,2,3,4,2,2,5,5,3,2,2,3,4,3,2,4,2,3,4,1,4,4,5,4,4,5,4,3,1,5,5,2,4,5,3,3,4,1,3,4,3,4,2,5,5,5,2,1,4,2,3,5,3,5,5,1,3,2,5,4,4,4,3,5,3,3,4,4,3,1,4,5,3,3,5,4,5,3,1,2,2,4,5,1,2,4,4,5,4,1,3,2,3,5,2,1,5,2,5,3,1,1,3,3,4,4,5,3,2,2,1,4,5,2,2,4,2,4,4,4,4,5,2,2,3,4,4,3,5,1,1,3,1,3,1,2,3,2,2,5,3,4,2,2,2,1,1,3,4,5,5,5,1,4,5,5,1,5,3,5,3,2,1,2,1,1,3,4,4,4,1,5,3,5,5,5,1,3,1,4,5,5,2,5,2,1,4,2,4,1,2,4,5,1,1,1,1,3,1,2,3,5,3,5,1,4,4,3,4,2,3,1,1,2,3,4,5,1,2,2,5,5,2,1,3,4,1,5,5,3,1,3,1,3,4,5,2,2,4,2,3,3,4,2,4,3,5,4,2,3,1,5,4,1,3,3,4,4,2,3,3,2,1,4,1,2,5,3,1,3,2,1,4,3,5,3,1,4,2,2,4,2,1,5,4,4,2,5,5,2,3,2,1,4,1,2,2,1,5,2,1,2,2,4,2,5,4,1,3,1,3,1,5,1,1,5,1,3,1,5,4,1,5,5,5,3,5,2,2,4,3,3,1,5,5,1,2,5,4,5,2,1,1,5,4,3,5,1,4,1,1,3,5,1,3,1,1,3,1,1,5,5,5,3,4,5,4,5,3,5,5,3,5,4,1,3,2,3,4,3,2,4,1,1,4,3,2,5,2,4,5,2,3,3,4,3,4,4,4,3,5,1,4,3,4,1,1,5,2,2,1,3,3,3,5,3,2,2,5,5,2,5,4,2,4,3,4,1,2,1,5,4,4,5,1,5,1,4,1,1,5,3,3,5,2,3,3,2,1,5,3,2,3,4,2,1,4,1,3,2,3,1,4,2,2,2,2,4,5,1,4,4,2,2,3,2,2,5,2,4,2,5,4,4,3,3,3,2,3,5,3,2,2,3,5,4,4,4,3,2,3,2,2,4,3,1,1,3,3,3,3,1,5,2,5,1,1,4,1,5,1,1,2,3,1,3,2,1,1,5,2,5,1,2,4,5,4,1,3,3,4,4,4,4,3,5,2,4,3,3,2,4,5,3,5,1,3,1,4,2,1,2,2,3,4,4,3,4,3,1,2,4,2,3,5,3,3,2,4,2,1,1,2,1,5,1,5,4,1,5,1,4,1,4,1,2,2,3,3,2,5,2,2,4,1,5,4,4,3,3,5,5,3,4,3,2,1,3,4,3,5,5,2,3,2,5,4,5,3,4,5,1,2,1,5,4,1,4,2,3,5,3,1,3,5,4,5,3,3,2,1,3,3,2,4,2,2,2,1,2,1,4,1,5,1,5,1,2,4,3,4,4,5,3,2,3,4,5,3,3,5,3,1,2,2,3,1,5,2,1,4,5,1,4,2,4,3,1,4,1,3,4,2,4,4,3,4,2,5,2,5,4,4,2,4,4,4,4,3,3,2,4,5,2,4,5,3,5,1,3,5,4,5,3,1,4,4,1,4,5,1,5,4,4,1,3,2,4,5,4,2,5,4,4,5,3,4,4,1,1,3,5,4,5,5,3,1,3,5,3,1,2,1,1,5,1,3,5,3,5,2,3,2,5,1,5,5,4,3,4,3,4,1,3,1,5,5,4,2,4,3,4,3,3,3,2,3,3,2,3,2,2,1,3,4,5,1,3,2,1,4,1,3,1,5,3,4,1,5,1,2,2,2,1,2,1,1,4,4,5,2,2,3,1,1,4,2,4,2,5,5,3,4,2,3,4,1,3,4,4,5,1,3,3,3,4,2,5,3,5,5,3,5,4,2,5,4,1,1,1,5,1,1,2,2,2,4,1,1,5,2,2,4,4,4,2,5,5,2,2,2,2,3,3,4,3,2,3,1,5,5,4,1,4,3,4,1,3,4,5,2,5,5,5,4,3,4,2,4,2,1,4,3,1,4,5,3,2,2,2,1,3,2,2,5,1,4,5,3,5,5,1,2,2,4,4,2,2,1,1,2,4,4,3,4,2,4,1,2,1,4,2,1,3,3,5,1,2,1,5,3,2,4,2,1,1,4,1,3,5,5,5,3,5,4,1,5,1,2,1,3,3,3,2,5,2,5,3,2,5,5,4,1,4,3,1,5,3,3,3,1,1,3,1,3,5,3,5,2,2,1,5,3,1,3,1,3,4,4,1,4,1,3,1,4,1,4,1,3,4,5,5,1,3,5,3,5,1,3,5,5,3,2,4,2,4,1,5,4,3,4,3,3,4,1,5,5,5,2,2,5,1,5,3,1,4,2,1,3,1,4,4,2,1,1,4,4,1,4,5,2,4,5,4,2,3,4,4,4,3,2,1,3,2,3,5,1,3,5,5,4,5,2,3,3,1,5,4,1,5,4,1,5,5,2,4,4,3,1,1,3,3,5,1,2,3,2,4,5,4,4,2,2,2,3,4,1,4,2,3,4,5,2,1,1,4,2,4,2,5,2,1,4,4,4,3,1,3,3,1,3,4,2,2,4,2,3,5,2,1,3,4,2,4,1,1,1,1,5,3,3,4,3,5,2,3,2,5,2,3,2,1,3,2,3,3,5,3,5,3,1,5,3,5,1,1,2,1,1,2,2,5,5,1,4,5,4,5,4,3,5,2,1,5,2,2,1,1,1,3,5,3,4,5,4,2,3,4,1,4,1,5,2,3,1,5,5,1,1,3,4,1,2,4,1,3,5,4,5,4,3,1,4,5,1,1,1,1,3,2,5,1,1,4,4,1,3,4,5,5,3,3,4,1,5,4,5,5,5,3,4,5,4,2,3,1,3,1,1,5,2,1,4,1,3,4,1,3,4,4,2,1,1,2,1,1,4,2,1,3,1,1,1,1,5,4,2,3,4,1,4,1,2,2,4,5,1,4,4,5,3,3,3,1,2,4,1,3,5,2,1,4,4,4,4,1,3,2,1,4,4,4,3,1,1,4,5,2,3,4,3,1,3,5,1,1,4,1,5,1,3,5,5,5,4,5,2,5,5,5,2,2,5,5,1,1,5,2,3,1,4,3,1,5,5,2,5,4,4,5,1,5,3,3,3,2,2,4,4,4,4,2,3,2,5,2,3,2,4,1,3,2,5,3,3,2,2,3,3,4,5,5,2,2,3,1,5,4,1,3,4,3,4,2,3,5,5,3,3,1,5,2,3,4,2,4,1,3,1,2,2,3,4,4,3,3,3,3,5,4,3,1,3,2,3,4,4,4,2,3,5,1,1,3,2,5,1,1,3,2,3,3,5,4,1,5,1,1,5,5,4,4,2,1,5,4,3,5,5,3,5,5,3,5,1,4,1,2,1,4,1,5,4,5,3,4,5,3,1,4,4,2,5,5,4,1,3,2,3,4,3,5,2,2,3,1,1,5,3,5,1,4,5,5,1,4,5,5,5,2,4,3,3,2,2,1,4,3,1,4,4,3,1,4,5,5,1,1,4,5,2,5,2,3,2,1,4,5,2,2,5,3,2,4,2,1,4,3,4,5,1,5,1,5,2,5,1,3,3,1,2,5,5,3,4,4,3,5,2,3,1,3,5,5,3,3,1,3,1,2,1,2,2,5,3,1,2,4,4,1,2,1,5,5,1,4,5,4,5,2,2,3,4,4,2,2,3,3,2,5,4,3,4,4,2,5,3,2,5,1,5,1,2,2,3,5,2,4,1,3,2,2,4,5,2,5,4,5,2,5,4,4,4,1,4,3,4,4,2,2,2,4,2,2,5,5,2,5,5,2,1,2,4,5,3,5,4,3,2,4,1,2,5,2,2,2,2,2,4,3,3,5,2,4,2,3,1,5,5,3,1,1,2,5,1,1,3,5,4,3,5,1,5,5,4,4,5,5,4,4,3,3,4,5,2,3,3,2,2,1,2,3,4,3,5,2,3,4,2,2,5,5,1,3,4,1,1,4,4,1,3,4,1,4,5,5,5,4,2,5,5,2,4,5,1,5,1,3,4,2,5,3,2,4,1,1,3,4,5,3,1,5,4,5,4,1,5,3,3,1,5,1,3,5,3,4,4,4,3,1,1,5,1,4,2,2,5,3,1,3,3,1,2,3,1,3,3,1,2,3,5,5,1,5,2,5,2,4,2,4,3,3,5,2,5,5,3,5,5,4,1,5,4,5,4,4,2,5,4,3,1,5,4,5,5,1,4,2,3,3,2,2,2,1,4,1,2,2,5,4,1,2,4,2,5,2,3,2,3,4,1,1,4,5,1,3,3,1,3,2,2,1,3,5,3,2,2,5,1,4,1,3,4,3,5,1,2,3,2,2,3,3,1,2,3,3,2,4,4,5,4,2,2,2,1,5,2,5,5,4,5,5,3,3,1,4,4,5,2,5,3,2,2,3,3,5,5,1,1,2,4,5,4,3,3,3,4,2,2,1,3,3,1,4,3,2,4,4,5,4,2,2,5,5,3,5,2,2,2,4,5,2,1,2,4,5,2,5,1,2,5,4,1,4,4,2,1,1,4,3,5,5,4,2,5,5,1,1,1,1,2,3,3,4,1,3,3,5,4,1,2,2,1,4,4,3,4,5,5,4,1,1,4,4,5,4,4,3,1,5,3,3,2,4,3,3,4,2,4,4,3,4,2,1,4,1,1,1,5,4,5,4,1,1,1,4,1,2,5,5,2,3,3,2,5,5,5,5,5,4,4,4,4,4,5,2,1,4,5,1,3,3,4,1,3,2,5,3,4,2,3,3,5,5,4,3,2,5,1,1,4,1,2,2,2,4,5,5,5,4,5,5,2,3,3,3,4,5,1,4,4,2,5,4,4,3,2,4,2,2,4,4,2,2,2,2,5,3,4,1,1,5,4,1,3,2,2,3,4,1,3,4,2,5,2,3,1,3,3,4,5,4,2,2,3,5,4,4,4,2,1,1,2,3,3,5,5,2,1,2,5,1,5,3,5,1,1,2,4,1,4,4,3,1,5,2,2,2,4,1,1,2,4,3,1,2,3,4,3,3,4,5,1,4,2,3,5,4,2,4,1,4,2,1,5,4,1,5,2,2,3,4,2,3,3,2,4,2,4,3,4,2,2,4,5,2,2,5,1,1,4,4,1,3,3,5,1,2,3,4,1,4,5,1,4,4,2,1,5,2,3,5,5,1,4,1,5,4,3,3,4,4,4,4,3,5,2,2,5,1,2,1,1,3,3,5,4,1,5,4,3,4,5,1,1,2,2,3,5,3,5,4,1,3,4,4,2,1,1,1,2,5,1,3,5,1,4,4,3,4,1,5,4,4,1,2,3,1,4,2,4,4,3,3,5,4,3,5,4,3,4,3,1,5,3,2,5,1,5,3,2,2,4,3,1,1,5,3,4,2,2,1,4,1,2,2,4,2,4,2,1,2,5,3,5,1,5,5,5,2,1,2,5,2,4,1,3,5,5,2,1,1,1,3,2,1,3,3,5,5,5,1,5,1,4,5,3,1,5,3,1,3,2,2,5,1,5,1,5,4,2,1,5,2,4,3,2,2,4,2,5,2,3,4,2,3,5,4,4,5,4,1,4,3,5,5,1,3,4,5,3,3,4,3,3,4,4,4,3,2,3,3,5,5,2,2,3,1,4,5,4,1,2,4,5,1,4,1,1,1,4,1,4,4,4,3,2,5,5,3,2,2,5,1,3,5,3,4,2,3,1,4,4,4,4,1,5,2,4,5,2,4,3,5,2,1,3,2,3,3,2,3,4,2,3,1,2,3,3,4,2,3,3,2,3,4,3,4,2,3,2,3,2,4,5,1,4,1,2,1,2,5,4,1,4,3,4,5,1,2,3,4,3,2,1,2,3,4,5,1,5,1,1,4,3,4,2,4,3,5,5,3,4,2,3,2,1,3,5,4,2,3,1,3,3,3,4,5,1,1,2,2,1,3,3,3,4,2,3,5,4,5,2,4,5,3,3,2,1,5,5,3,1,2,3,1,3,1,1,5,4,4,2,2,2,1,2,2,1,2,3,4,1,3,1,2,2,3,5,5,1,5,1,4,1,4,4,2,2,3,3,3,1,5,5,2,1,3,4,1,2,2,3,2,1,2,5,5,5,3,1,5,2,2,3,3,2,4,4,2,3,1,5,3,5,2,4,1,3,2,5,2,4,3,3,1,5,5,3,2,2,1,2,2,3,4,5,3,3,3,1,5,5,4,1,3,2,2,2,3,4,2,1,4,3,5,3,4,1,2,4,5,1,5,5,1,5,4,1,3,2,4,1,2,4,3,5,1,4,3,4,5,2,5,3,4,2,4,1,5,1,5,3,4,2,2,2,4,5,3,1,2,3,1,2,5,1,3,4,2,5,3,2,2,5,4,5,4,3,1,2,5,4,1,2,1,5,4,3,1,1,2,1,2,5,2,3,3,3,5,1,3,4,1,5,3,5,5,1,3,1,4,1,1,2,5,4,2,3,5,3,1,4,5,5,3,3,1,1,3,3,3,2,2,2,2,2,1,1,4,1,5,1,1,3,5,5,3,2,2,3,3,5,3,5,5,1,5,5,3,1,4,3,3,4,4,1,3,5,1,1,4,3,3,3,3,3,4,4,3,3,1,1,4,5,2,1,2,5,5,5,1,3,5,4,3,5,4,3,4,4,4,1,2,5,5,1,5,1,3,5,5,3,2,4,5,4,1,1,4,5,5,2,3,1,5,5,4,1,5,1,4,4,5,5,2,2,5,2,1,1,4,4,3,2,3,4,3,5,3,1,5,4,5,2,4,1,4,1,1,3,2,2,2,3,4,1,3,2,3,5,2,2,2,4,2,3,3,5,5,2,3,3,2,4,4,5,5,3,3,3,2,4,4,3,1,4,4,4,4,4,2,4,1,4,4,2,4,4,4,4,5,1,5,4,3,4,2,5,3,1,2,1,3,2,5,4,3,3,3,5,3,3,2,4,2,2,4,5,2,1,3,4,5,5,2,2,1,1,1,1,2,1,4,1,1,2,5,3,3,4,1,4,5,4,1,2,5,3,5,3,4,4,2,1,5,3,4,3,3,1,5,3,3,2,2,4,4,4,4,2,5,1,5,5,1,4,2,4,4,4,5,4,1,4,1,4,5,1,2,4,5,1,5,2,5,3,5,1,5,4,4,2,4,2,1,3,1,3,4,1,4,3,4,5,2,2,2,5,1,1,5,5,4,3,1,2,2,2,1,2,1,4,5,4,1,1,3,3,2,3,1,5,2,1,3,5,4,3,4,3,3,2,1,1,4,5,2,1,2,4,3,2,4,4,4,4,4,3,2,1,5,5,4,1,4,2,5,1,1,3,4,5,4,4,3,5,5,2,3,5,1,4,3,1,3,3,5,5,3,4,1,1,5,3,5,1,3,5,3,4,4,3,3,3,2,2,3,1,3,1,2,4,2,4,3,5,3,4,1,1,4,5,4,1,3,2,4,4,2,1,2,2,2,5,2,4,5,2,1,2,1,5,5,2,3,1,2,3,3,2,4,1,1,2,3,2,4,5,2,3,3,5,5,3,5,1,1,4,1,2,5,5,5,2,1,4,3,1,5,2,3,5,4,2,4,2,5,3,5,1,4,4,2,4,3,2,4,4,3,1,1,4,4,4,1,2,2,3,2,1,1,4,2,3,5,5,2,5,2,4,5,4,4,2,1,1,2,1,4,5,2,2,5,2,5,1,5,5,5,4,1,2,5,4,4,2,2,2,2,3,3,4,4,4,4,2,1,2,5,5,3,1,5,5,1,3,5,4,4,3,1,4,1,1,5,2,2,5,5,1,3,5,2,3,5,4,4,3,1,5,2,5,2,1,1,1,1,4,4,4,3,2,5,2,4,1,1,4,1,5,1,3,3,3,3,2,4,5,3,4,2,2,5,4,1,4,2,3,3,2,4,3,5,5,3,4,4,2,3,3,3,5,5,3,1,3,1,1,1,4,1,1,2,5,5,3,1,1,1,4,3,1,2,1,5,2,5,1,5,1,3,1,5,4,5,4,4,5,5,5,2,2,3,3,5,3,3,5,5,4,3,5,2,2,5,3,2,3,2,5,3,2,1,1,1,4,3,2,3,5,1,2,1,5,2,3,2,4,5,1,4,4,4,3,4,3,1,2,2,2,1,5,3,5,1,1,3,4,4,2,1,3,3,1,2,1,2,5,4,4,5,3,5,4,1,3,4,3,5,1,3,4,1,4,3,2,3,2,5,1,2,2,1,3,2,1,4,3,4,2,4,2,1,2,5,1,3,3,4,2,5,3,5,2,5,3,5,5,5,4,5,1,3,1,1,2,4,2,5,3,3,1,4,3,4,4,1,4,4,5,2,3,2,2,4,1,1,5,1,5,3,5,3,5,3,1,1,1,2,3,3,3,5,3,2,2,1,3,1,5,3,1,2,1,1,1,4,5,1,2,1,5,1,5,1,1,5,1,3,2,4,3,4,5,4,5,2,5,2,5,2,2,4,2,1,1,4,5,4,2,3,1,3,4,1,5,3,5,4,2,2,1,3,1,3,1,3,1,3,5,1,5,3,5,4,5,1,4,1,4,4,5,5,5,5,5,4,1,4,2,5,1,5,4,1,3,5,5,5,1,3,1,5,4,1,4,4,4,4,3,4,1,1,2,1,3,1,2,3,4,2,5,2,1,1,4,5,2,2,1,2,4,3,5,1,4,1,2,3,4,3,1,2,1,2,2,4,5,2,3,4,3,3,2,4,5,5,1,2,5,4,5,2,2,3,1,2,2,3,2,5,1,3,2,4,4,1,4,2,5,2,4,1,4,1,4,2,2,4,4,5,5,3,5,5,3,3,4,1,4,5,4,4,4,2,1,1,2,2,4,4,2,2,1,1,3,2,5,5,5,1,5,3,3,4,5,4,1,1,5,2,2,1,2,5,4,2,3,3,3,4,3,4,4,2,1,3,5,2,5,4,2,4,2,5,4,4,1,4,2,5,2,2,1,1,2,1,5,5,4,4,1,3,5,1,3,2,4,4,4,5,1,3,4,1,3,5,3,4,1,3,3,2,5,5,4,5,5,2,1,1,5,2,2,3,3,3,3,2,1,4,5,2,2,5,5,4,3,3,4,1,2,5,1,2,5,4,5,1,4,3,3,2,2,3,5,5,5,4,3,3,4,5,5,3,3,4,4,4,3,5,5,4,1,1,3,3,2,1,3,4,2,5,3,5,5,5,1,3,3,2,2,1,1,1,4,4,1,1,5,1,2,2,1,3,4,1,3,4,5,4,4,5,3,1,2,5,4,4,2,3,5,5,1,3,4,4,2,1,5,1,4,4,2,1,5,4,2,2,3,5,1,4,4,2,4,1,5,2,3,3,2,1,3,5,2,1,1,1,1,4,4,1,5,4,4,3,3,5,1,3,1,5,3,4,1,1,4,5,3,3,3,5,3,5,3,3,2,1,2,2,3,5,2,2,2,2,5,2,5,2,5,2,5,1,1,4,2,2,5,4,2,4,5,4,2,1,2,3,4,5,2,5,1,2,4,2,1,1,4,5,3,1,2,5,1,2,1,1,1,4,2,1,1,4,4,3,5,2,1,4,3,4,2,1,1,3,3,3,5,4,3,3,2,4,3,1,4,4,1,4,3,2,3,5,5,5,2,4,2,3,5,5,3,5,5,2,1,5,3,3,4,5,2,2,2,4,3,1,3,4,1,4,1,3,5,2,1,5,5,4,4,4,1,5,2,1,2,1,4,5,5,2,1,5,2,1,4,5,3,5,5,4,3,2,5,1,2,3,3,2,2,4,1,3,1,2,4,5,5,1,5,2,2,2,4,5,3,3,5,2,3,4,1,3,1,1,3,1,5,5,4,5,2,1,2,1,4,2,1,3,2,2,2,2,2,2,2,5,1,2,1,1,3,2,5,5,2,5,3,5,3,5,1,2,4,2,2,1,3,2,5,2,3,5,5,4,2,5,5,3,4,1,1,2,3,3,5,3,3,4,1,2,2,5,2,1,4,3,1,2,5,2,1,3,4,2,3,3,1,1,5,4,3,1,2,5,4,5,1,1,4,2,3,3,5,5,1,3,3,4,1,5,5,4,1,5,5,2,3,5,5,5,4,4,2,5,5,2,2,4,5,1,1,3,1,2,3,1,5,4,2,2,3,1,4,1,4,5,4,3,5,5,3,5,3,3,2,2,1,2,3,3,5,3,3,5,4,5,4,1,4,4,1,5,5,1,2,4,5,2,4,1,2,2,2,5,1,5,1,2,5,4,1,3,4,2,4,1,4,3,1,3,4,4,4,4,3,2,2,1,3,5,5,3,3,1,3,4,4,3,2,1,3,2,5,2,2,2,1,1,5,3,1,5,4,1,2,3,1,3,4,1,5,2,1,5,2,2,4,4,1,4,2,5,4,4,4,1,3,4,1,3,4,1,5,3,2,2,3,3,5,5,3,5,5,2,1,1,1,4,3,5,5,1,3,3,3,5,5,2,5,1,3,3,1,4,2,2,1,5,4,5,2,1,3,4,4,2,3,5,5,3,1,1,2,3,5,2,2,1,2,4,5,2,2,1,4,2,4,3,5,4,1,3,1,1,5,5,3,2,5,2,4,1,1,1,3,1,5,3,3,4,4,1,3,1,2,4,3,1,3,3,5,2,3,5,2,5,3,1,4,4,3,4,5,2,5,4,3,2,1,5,1,4,4,4,1,2,5,1,1,2,5,5,1,4,5,4,5,1,4,1,2,3,1,2,1,3,1,3,4,5,1,2,1,2,2,3,4,1,5,1,3,4,4,3,2,4,3,5,3,4,5,3,4,4,1,3,2,1,3,2,4,1,3,5,2,2,4,1,5,4,4,4,2,2,1,5,2,5,3,1,2,2,2,2,3,2,5,3,4,3,1,4,1,2,5,2,3,4,5,1,5,4,4,3,2,2,4,4,3,5,5,3,3,3,2,1,3,2,3,4,1,1,4,3,4,3,5,4,2,2,3,5,4,1,5,5,4,5,4,1,1,5,2,5,1,2,2,4,4,4,2,5,5,2,2,4,3,5,4,3,3,5,2,4,3,1,2,4,4,5,4,5,3,3,2,1,2,3,2,4,1,4,1,1,1,2,3,5,3,1,2,3,2,1,2,3,1,1,3,2,4,5,5,2,1,5,5,2,3,1,3,4,5,5,5,3,1,5,4,5,5,3,3,1,3,5,2,1,4,1,3,1,5,5,2,5,2,4,1,1,1,2,1,5,3,5,4,1,2,2,4,4,4,3,2,3,2,5,5,2,5,2,1,3,1,3,1,4,2,1,2,4,4,4,1,2,2,2,4,4,5,5,4,2,5,5,1,1,5,4,3,4,5,4,5,3,2,3,5,5,2,3,2,2,2,1,5,3,4,1,2,2,2,1,1,2,3,1,3,2,4,4,2,5,3,4,5,2,5,2,1,1,4,3,3,4,2,1,5,3,2,2,2,5,1,1,1,1,2,5,2,2,4,1,1,5,5,3,3,5,3,3,5,2,5,1,4,3,2,1,3,5,1,2,5,3,5,3,2,4,3,3,5,1,2,2,1,5,4,3,3,1,5,1,5,3,1,1,1,1,4,2,4,2,1,4,1,5,2,4,4,3,2,5,4,3,1,5,1,5,2,5,2,1,3,4,3,5,2,2,4,4,5,4,3,5,2,3,1,1,5,5,5,4,3,5,4,2,2,3,5,5,1,3,2,3,1,2,4,2,3,5,4,4,5,1,3,1,2,5,4,3,3,3,2,3,3,5,4,3,4,2,5,5,3,5,1,4,5,1,5,3,5,1,2,2,5,5,4,2,5,4,3,5,5,3,1,3,4,4,4,3,4,3,1,2,1,3,3,4,3,3,2,4,3,4,2,1,3,3,4,5,5,5,2,2,5,3,1,4,4,5,2,1,2,1,4,4,1,2,2,3,1,3,1,3,1,4,3,5,1,2,1,3,1,2,3,1,5,4,2,5,5,4,1,2,3,2,2,4,5,3,5,5,1,1,3,2,3,4,5,5,1,2,5,4,1,5,5,2,1,3,4,4,1,2,5,3,5,2,3,5,4,4,1,3,2,2,4,1,4,1,3,1,5,3,2,1,2,4,5,4,1,4,3,5,2,3,5,4,5,2,3,3,2,1,3,3,1,1,3,5,5,5,2,2,5,5,3,2,1,2,1,2,4,5,1,5,4,5,5,3,5,4,4,3,4,5,4,4,5,5,1,2,3,2,4,5,4,2,5,3,3,2,3,4,3,5,2,4,5,1,1,3,3,2,3,5,3,2,2,4,3,2,1,2,4,3,1,4,2,4,4,1,4,4,5,2,5,2,1,2,3,3,1,3,4,3,4,3,2,3,5,2,1,4,1,5,1,1,5,2,3,5,3,2,4,3,2,2,2,4,4,4,3,2,2,2,2,2,5,2,2,1,4,1,2,1,2,3,1,2,4,3,5,2,2,2,2,3,2,2,5,5,4,2,2,5,1,4,2,3,5,4,4,3,3,1,2,1,5,4,2,3,2,3,5,3,2,2,1,5,4,1,3,1,1,5,5,3,1,2,5,2,5,3,3,1,4,4,2,5,2,1,2,2,5,3,5,4,5,4,5,1,3,3,2,1,1,3,5,4,4,5,2,2,5,2,1,1,1,2,3,1,4,5,3,4,4,5,5,2,3,4,3,3,5,4,2,1,4,5,3,5,3,1,2,1,1,3,2,1,1,3,2,4,5,1,4,3,1,4,5,1,3,1,1,1,1,4,5,5,3,4,2,5,4,5,2,1,3,3,2,2,3,5,1,5,5,5,5,3,4,2,3,3,4,2,4,3,1,4,2,3,5,2,1,3,3,3,4,3,2,5,3,5,2,2,3,3,1,5,2,5,3,2,4,3,1,2,1,2,5,2,2,3,5,5,3,2,4,1,1,1,1,5,2,3,1,5,5,3,4,5,3,3,4,1,4,3,2,4,1,3,4,1,5,2,1,3,3,3,5,4,3,3,4,3,2,5,3,4,4,4,5,3,1,1,5,3,1,3,3,3,1,4,2,3,5,1,2,2,2,3,2,1,1,5,1,3,4,5,5,3,3,4,3,3,1,3,5,5,1,2,2,4,5,3,1,3,5,5,2,4,3,2,2,1,4,4,3,1,2,2,4,1,1,2,4,3,5,1,3,1,1,3,2,2,2,2,3,5,5,2,1,2,1,4,4,4,5,2,5,2,5,1,3,4,1,3,1,3,2,3,5,3,3,2,5,3,3,4,1,1,2,5,3,5,3,5,5,3,3,4,2,4,3,2,2,4,2,3,3,3,2,3,2,3,2,3,5,2,4,1,5,3,5,5,1,2,1,1,4,2,1,4,4,1,2,3,1,5,1,2,5,4,4,3,4,1,3,3,3,4,3,2,1,5,2,5,4,1,2,5,5,1,4,2,4,4,1,3,3,3,1,1,2,5,2,1,3,4,3,5,3,5,4,1,1,1,4,2,2,5,1,2,2,4,2,2,5,3,4,4,2,5,1,2,2,5,2,1,3,3,3,4,1,1,4,2,1,5,5,1,2,5,5,3,4,3,5,4,5,1,2,2,2,5,2,2,2,3,3,4,1,5,4,4,4,4,2,4,4,2,3,4,4,3,5,3,2,5,1,4,3,5,2,2,3,2,5,4,4,1,3,4,4,1,2,5,4,5,4,4,1,3,1,1,2,5,4,3,5,4,4,5,3,3,5,3,4,1,1,4,3,4,1,5,4,4,5,4,5,4,5,5,1,3,2,3,1,2,2,5,1,1,5,2,3,2,1,3,4,5,4,5,2,3,2,5,3,5,2,3,4,1,5,4,2,5,3,1,2,5,3,2,2,4,3,2,2,5,5,1,2,3,4,4,5,2,1,4,3,1,4,3,3,1,4,5,3,3,4,3,5,3,4,5,4,3,3,1,3,1,2,2,5,3,4,2,5,4,5,5,4,1,3,3,2,2,3,1,4,5,3,5,4,5,1,4,1,2,1,1,3,4,4,3,4,3,2,2,1,2,5,4,2,2,4,3,4,4,5,2,5,2,4,5,5,1,3,3,2,1,5,1,5,2,3,2,3,2,3,1,4,4,5,5,1,3,3,1,5,5,4,5,3,4,2,5,3,4,2,3,1,5,2,3,5,2,4,5,1,4,2,3,5,4,1,2,4,2,5,5,1,3,5,4,5,1,2,1,1,5,1,4,4,3,5,2,3,5,3,1,5,3,3,1,3,2,5,2,1,1,2,1,1,2,3,4,2,2,5,3,2,2,4,4,4,1,5,1,1,3,3,2,5,2,1,3,5,2,4,4,4,4,4,5,3,5,1,4,1,3,3,5,1,4,1,2,3,5,2,1,5,1,5,3,2,3,4,4,3,2,1,1,2,3,2,2,1,5,5,2,3,2,4,2,3,1,4,3,4,5,2,1,5,3,1,3,1,3,3,2,4,4,5,4,4,3,5,3,4,4,2,1,4,5,5,1,4,2,5,2,2,3,3,4,4,4,1,2,5,2,3,5,1,5,3,4,2,2,2,1,2,2,5,4,1,3,3,2,1,5,4,4,5,5,3,3,4,3,5,1,4,2,2,1,3,2,3,5,2,4,3,3,4,3,2,4,1,2,3,4,2,3,2,5,4,1,3,3,4,1,4,2,2,3,1,4,4,5,1,3,3,2,2,5,3,5,1,4,2,1,5,3,4,1,2,1,3,1,1,5,5,2,2,5,4,3,2,1,3,1,3,4,2,3,2,3,4,3,4,1,3,3,5,1,3,5,1,3,5,1,2,4,1,1,3,1,4,2,5,2,3,4,5,1,5,2,4,2,5,1,4,1,4,3,5,1,3,5,3,2,3,1,5,5,4,5,1,1,2,4,5,4,4,4,4,1,5,5,2,4,1,2,2,5,1,1,3,1,1,1,2,2,2,2,2,5,2,2,4,3,2,4,5,5,1,4,5,3,3,4,4,5,3,5,5,3,1,5,1,3,3,1,4,5,3,2,3,5,2,1,3,5,2,5,4,5,5,3,1,2,5,5,4,1,5,5,4,1,4,3,3,5,2,4,5,1,2,2,5,4,5,3,2,3,1,4,4,4,1,5,5,4,4,3,1,4,4,1,2,1,2,5,5,3,5,5,2,1,2,3,1,3,3,4,5,2,2,3,4,2,3,3,3,1,4,4,4,5,2,1,1,2,5,5,3,4,4,3,2,5,3,1,3,4,5,4,5,2,4,2,5,1,3,4,1,4,1,5,1,3,2,3,3,1,1,1,4,1,3,3,5,4,2,4,1,3,1,3,4,4,1,1,2,5,3,2,1,1,5,1,1,1,3,5,2,1,4,3,3,2,2,4,3,3,1,3,1,2,2,1,2,1,5,1,2,1,3,1,3,5,2,2,4,2,5,4,3,4,4,2,3,2,4,1,4,4,4,5,5,5,5,1,5,2,3,5,1,3,4,3,3,1,2,4,1,2,3,2,1,3,3,2,1,4,1,5,5,4,2,1,3,3,5,5,2,1,1,3,2,3,4,2,5,2,3,2,2,1,3,2,4,5,3,4,5,1,5,3,1,2,2,2,3,3,1,2,5,2,5,5,2,2,3,3,4,1,1,1,2,1,2,4,2,1,2,4,2,2,3,5,5,2,5,1,5,3,5,1,2,4,4,1,1,5,1,5,4,4,3,1,5,5,3,4,5,2,4,3,1,5,1,3,5,5,1,4,4,2,3,2,4,2,2,3,4,4,3,2,2,2,5,4,5,4,2,2,2,5,5,3,4,4,4,4,2,2,3,4,5,4,2,1,4,3,3,3,1,2,4,2,3,2,2,3,5,4,5,1,2,3,1,4,3,2,1,4,1,4,3,2,1,1,1,2,2,4,5,3,2,5,4,1,3,3,5,3,5,5,5,2,5,2,4,3,3,4,1,4,4,4,5,3,1,5,3,3,3,1,4,4,5,1,5,3,2,4,4,4,1,3,1,1,4,1,5,2,1,1,1,4,2,2,1,2,2,5,3,3,3,4,2,1,4,1,1,4,1,5,1,5,2,4,1,4,4,2,2,3,1,2,4,3,5,5,1,1,3,3,3,4,5,3,2,1,4,3,5,5,1,5,4,2,1,5,4,2,3,5,4,5,3,2,1,1,2,5,2,1,2,2,3,2,5,3,4,4,1,2,3,3,3,3,3,3,5,5,4,2,2,2,1,1,4,5,2,3,4,1,4,4,3,5,1,4,3,2,1,4,4,4,4,2,2,1,1,1,3,4,1,2,5,2,4,5,1,4,1,1,4,3,3,3,1,3,1,3,5,3,1,2,1,5,4,3,3,3,2,2,4,5,5,3,1,2,3,1,4,5,1,3,2,4,2,4,5,3,3,5,5,4,2,3,1,2,2,5,4,3,2,4,2,3,4,1,5,3,3,2,2,3,5,1,1,2,4,1,3,5,3,4,1,4,4,5,4,1,5,3,5,5,4,5,4,4,2,1,1,2,5,1,5,3,3,4,2,4,5,4,4,1,4,4,2,3,4,4,1,1,3,1,5,2,3,4,1,2,3,1,3,5,5,3,3,3,1,5,2,1,1,1,5,2,3,5,4,2,3,1,1,2,1,2,2,4,1,4,5,5,5,2,5,4,4,3,5,1,5,4,4,4,2,1,2,3,4,2,1,5,1,5,5,4,1,3,4,1,4,2,5,1,3,1,1,1,3,2,4,1,4,2,4,2,2,1,5,2,1,5,5,4,1,2,5,2,2,5,1,1,1,4,5,4,1,1,3,4,2,4,4,1,1,3,2,4,5,3,1,1,3,3,4,2,1,1,5,5,5,1,1,3,1,3,4,5,2,2,5,3,1,4,3,1,1,1,4,2,1,4,3,4,5,5,3,2,3,2,5,2,1,2,5,3,2,2,2,5,1,4,5,4,3,1,4,4,1,3,3,1,3,4,3,4,2,4,4,5,3,3,4,5,1,4,1,3,3,4,2,1,4,3,2,1,5,1,4,5,4,3,2,1,2,1,4,5,5,1,2,5,3,4,2,4,5,4,3,2,2,2,2,2,3,4,1,5,3,5,1,1,5,1,1,4,4,2,3,3,2,1,1,3,5,5,1,5,4,1,5,1,1,3,2,1,3,3,3,5,5,1,1,1,1,3,5,4,4,3,1,1,4,4,2,5,2,1,1,2,3,5,1,4,5,1,4,3,1,3,2,3,3,2,1,2,3,5,2,2,3,2,2,2,1,3,3,5,4,2,3,3,5,3,2,2,1,4,3,5,2,3,2,1,2,5,4,2,5,4,3,4,5,1,1,4,5,1,4,3,1,1,5,1,5,4,5,3,2,4,2,4,1,4,5,5,1,5,2,1,5,5,5,4,1,3,3,5,3,1,2,4,3,2,1,5,3,5,2,1,4,5,2,2,3,3,3,3,3,4,5,3,3,4,4,4,5,2,1,1,4,3,4,2,4,2,1,1,4,2,3,1,1,1,1,2,4,2,1,3,3,3,2,2,3,3,5,3,1,3,2,1,2,2,5,4,5,1,3,3,4,5,4,5,1,3,5,3,1,4,4,2,3,4,1,2,3,2,2,2,5,4,2,5,5,2,3,1,4,5,5,4,3,3,2,3,5,2,2,5,5,3,2,4,2,1,4,3,5,5,4,1,3,2,4,2,4,3,1,5,5,4,4,5,5,5,5,5,2,5,1,4,4,3,2,5,5,1,2,3,2,2,2,2,3,5,3,1,2,2,1,3,3,4,1,5,2,5,2,5,4,4,5,4,5,4,5,5,3,1,5,4,2,5,2,5,4,1,5,3,3,1,5,1,4,2,1,2,1,1,1,5,5,5,1,3,4,5,2,4,3,4,3,5,3,4,2,2,4,4,5,5,2,5,5,4,5,2,1,3,2,1,1,4,2,3,4,3,1,1,1,3,2,3,3,5,4,3,5,4,1,4,4,1,4,2,1,5,3,2,4,3,4,4,5,4,5,1,5,4,4,5,1,1,5,1,4,1,4,2,4,3,5,1,1,3,5,2,2,5,4,4,5,5,2,1,1,3,4,4,4,4,4,1,2,5,1,5,1,1,4,1,3,5,5,4,5,4,1,3,3,3,5,3,1,2,3,1,5,2,2,2,1,3,3,3,3,4,1,4,4,2,1,4,4,1,3,4,3,1,2,5,5,2,5,1,2,2,4,4,4,1,3,2,5,3,4,4,3,1,3,5,2,2,3,5,4,3,4,1,2,3,1,1,3,2,3,1,1,3,4,2,1,4,4,5,4,2,2,5,3,5,5,1,3,3,1,3,3,1,3,1,1,5,3,4,5,2,1,1,5,4,5,2,4,1,5,3,2,5,4,4,3,3,4,1,3,5,3,1,2,5,5,2,4,2,1,2,3,2,4,3,3,5,5,2,4,4,1,5,1,2,5,5,2,4,5,4,5,3,2,3,5,4,5,5,1,4,2,2,2,3,1,2,4,5,5,2,5,2,4,2,5,4,1,3,2,5,3,4,4,5,2,4,5,4,3,5,5,1,4,2,4,2,1,5,1,4,1,2,4,2,5,2,2,5,1,1,3,1,1,4,5,2,3,1,5,5,5,2,2,4,2,5,3,2,1,1,4,3,1,2,4,3,1,2,2,3,2,4,5,5,5,2,2,4,1,3,5,5,5,3,3,2,1,2,4,5,3,2,3,1,4,1,1,1,3,4,2,4,3,5,4,5,2,3,1,2,1,2,3,2,3,4,3,5,5,2,3,5,5,4,3,2,4,5,5,2,5,4,2,2,2,2,3,5,5,2,4,1,5,3,4,1,2,5,2,5,5,1,4,3,1,1,2,2,1,1,2,3,3,1,2,4,2,1,3,2,3,3,1,5,3,4,4,5,1,4,3,5,2,3,2,5,5,2,1,3,2,2,2,5,1,4,4,4,5,3,3,5,5,3,2,3,3,2,2,5,1,4,3,1,5,4,2,1,5,3,1,3,1,4,4,3,1,2,2,5,3,2,1,5,2,4,1,4,3,5,4,2,3,2,1,4,5,4,2,1,3,3,5,5,1,2,1,1,1,3,3,1,3,3,1,5,1,3,1,5,2,5,1,3,3,5,4,1,5,5,4,5,1,4,5,2,4,1,3,3,2,2,3,1,3,5,4,4,2,2,3,2,2,1,1,1,4,5,4,2,5,4,1,5,3,1,2,1,2,1,3,2,5,3,2,1,1,5,4,4,1,3,3,3,3,4,3,3,3,4,2,2,3,1,3,1,2,1,1,2,5,3,3,4,4,3,4,1,4,2,3,4,4,1,2,4,2,3,5,2,2,3,3,5,5,2,1,1,1,2,4,2,5,3,1,5,2,2,4,1,5,1,4,1,3,1,4,1,5,1,1,4,3,5,2,2,2,4,3,2,4,5,5,5,2,2,4,1,5,2,3,5,2,5,2,2,3,2,3,4,1,3,2,4,3,1,3,3,3,3,4,2,5,3,3,1,3,5,5,2,2,5,4,3,1,5,5,3,2,1,4,4,5,3,5,5,1,3,1,3,2,5,2,4,2,5,2,1,3,5,3,3,2,2,2,2,1,3,2,2,1,4,3,1,5,5,3,1,3,2,5,4,1,4,5,4,1,1,5,3,3,5,4,5,4,3,2,5,4,1,3,2,1,2,2,4,3,4,1,2,2,5,5,2,5,5,3,2,2,3,4,1,1,4,3,2,2,1,1,5,2,4,5,3,2,2,2,5,1,1,2,5,3,5,5,4,2,1,4,1,4,1,2,1,4,5,2,5,1,5,4,2,5,2,1,4,1,1,2,5,5,2,2,5,1,1,3,3,4,2,1,1,5,4,1,5,3,5,1,1,4,3,1,3,2,5,5,1,3,5,4,1,1,1,2,2,2,2,2,5,2,5,2,1,3,5,4,2,3,3,5,2,5,1,2,2,2,2,4,3,5,4,3,5,1,3,2,2,5,4,5,5,5,2,5,5,3,4,4,4,1,1,2,3,2,1,1,2,5,1,4,2,4,4,4,4,4,1,3,3,4,2,2,3,4,4,2,1,1,4,5,3,4,5,3,5,5,3,5,1,1,2,2,5,1,4,2,4,5,1,2,2,5,3,4,3,5,4,4,1,1,5,4,5,3,2,2,1,5,4,2,3,3,1,4,1,2,1,4,2,3,1,1,1,2,1,4,4,3,3,5,4,4,1,3,2,4,2,3,4,1,1,5,1,3,4,2,3,4,5,1,5,5,5,4,1,3,3,1,1,4,1,3,3,2,4,3,3,3,2,4,1,2,1,1,4,2,5,2,4,3,5,2,2,2,4,1,2,2,2,5,1,2,2,2,1,3,3,1,2,2,5,2,3,2,5,1,5,4,2,2,5,2,2,5,1,2,1,2,5,3,1,3,2,1,2,3,3,1,4,4,5,2,5,3,5,1,4,1,1,4,5,1,5,1,2,3,3,2,4,1,4,1,2,2,5,5,5,5,5,3,4,2,4,5,1,3,2,1,4,3,1,5,1,5,1,3,4,3,4,5,2,5,3,4,5,4,4,1,4,4,4,4,4,5,2,4,1,2,1,5,4,1,1,3,3,2,5,4,5,1,2,5,1,4,2,2,2,5,4,4,3,1,5,1,4,2,1,1,1,1,1,1,1,5,5,4,1,3,1,1,4,5,3,5,1,2,3,2,4,5,1,5,2,5,5,1,2,2,5,5,2,5,1,3,2,4,3,1,3,5,3,5,4,3,2,2,1,2,4,1,4,4,3,5,1,3,3,5,1,4,2,3,4,5,2,3,2,4,1,5,2,1,4,1,3,5,5,1,1,1,2,5,5,5,1,1,1,5,5,3,2,5,5,1,3,5,5,5,5,5,2,5,4,4,4,4,1,4,2,2,2,3,5,1,1,2,3,2,3,2,1,2,4,1,3,2,1,3,4,1,4,3,4,3,1,1,4,2,2,2,2,3,1,5,4,5,3,3,2,3,5,2,5,3,5,4,2,1,3,2,4,4,3,4,5,1,1,4,5,4,2,3,1,3,4,2,4,2,1,5,3,2,3,3,4,3,1,1,1,5,5,3,2,5,1,3,2,3,1,5,1,3,2,5,4,3,2,5,5,3,3,1,2,1,2,5,1,5,1,5,5,2,4,4,4,2,5,3,4,1,5,5,4,3,3,2,1,3,5,2,1,5,3,2,1,1,5,2,3,5,2,1,4,3,1,1,2,3,4,1,3,5,1,4,5,3,3,1,1,5,1,5,2,4,1,1,5,2,1,3,1,3,4,2,1,3,2,4,3,1,5,4,4,2,3,4,5,4,1,4,1,4,4,1,3,5,2,3,2,3,3,2,3,1,4,4,4,3,5,5,4,1,2,2,2,1,5,1,2,2,5,2,2,4,1,5,3,3,5,4,3,1,5,2,3,3,3,3,1,5,3,5,2,3,3,3,4,3,2,4,1,5,1,1,4,1,5,4,5,3,2,5,1,3,2,3,1,3,5,5,5,1,1,1,5,4,3,5,1,4,3,3,5,3,5,1,3,4,4,3,4,5,3,4,2,4,4,3,5,3,3,3,3,5,4,2,4,4,1,3,5,1,4,4,3,1,1,1,3,4,1,4,1,4,4,2,4,4,3,5,3,5,1,4,5,1,5,3,4,5,3,2,5,5,5,1,2,4,4,2,3,3,4,4,3,2,4,3,2,2,1,3,1,1,3,4,3,1,1,3,5,4,5,3,2,1,4,1,2,2,5,4,4,2,1,5,2,2,1,5,3,1,1,1,5,4,2,3,3,1,4,2,5,1,2,5,4,2,1,4,5,4,1,1,4,2,4,2,4,5,3,3,1,1,3,3,1,5,1,5,2,5,3,4,4,1,5,5,3,1,2,1,5,3,4,1,1,1,1,1,1,1,2,4,1,5,3,4,4,3,4,1,5,2,5,3,4,2,5,1,2,1,4,4,2,5,5,3,2,1,1,3,4,4,4,3,3,4,5,5,2,1,5,1,5,4,2,2,3,5,3,1,5,4,4,5,5,1,5,3,3,5,3,3,1,1,4,1,1,4,4,1,1,4,2,2,3,1,3,1,1,5,2,2,1,3,5,2,3,3,1,5,3,3,4,1,1,5,5,4,4,2,3,2,1,4,2,5,5,3,1,4,2,1,4,2,5,5,2,4,1,5,2,2,3,4,2,3,2,3,3,4,2,3,4,1,1,1,2,2,2,1,3,2,5,3,1,3,2,5,2,2,4,5,1,5,1,5,3,4,3,4,4,2,5,2,4,5,1,3,2,4,2,3,5,2,5,1,1,2,1,5,4,1,4,1,2,1,4,5,3,2,4,2,3,4,5,4,1,2,1,1,5,2,1,1,5,3,1,2,4,5,5,3,3,4,3,5,1,4,1,3,1,5,2,4,4,3,2,3,5,2,3,4,5,1,4,2,2,5,2,5,1,3,4,5,4,1,4,3,1,1,5,5,4,1,2,1,1,4,4,2,1,4,1,3,5,2,4,4,4,4,5,1,3,4,3,1,3,2,1,1,2,2,4,1,4,5,5,2,4,5,1,1,5,5,5,3,3,3,1,4,5,2,3,2,2,1,5,5,5,5,1,5,3,2,4,3,4,2,5,4,2,3,3,2,5,4,1,5,5,1,2,3,5,4,5,3,1,4,3,4,3,4,2,4,4,1,4,2,1,1,5,1,3,1,1,1,2,2,2,3,1,1,5,5,1,2,5,3,1,2,2,1,3,3,1,3,2,2,1,3,5,4,1,5,3,1,1,4,2,2,3,4,5,3,5,2,4,3,2,4,5,4,3,3,5,3,3,3,4,5,2,5,1,2,3,5,5,5,5,4,2,1,1,2,2,1,3,4,5,3,4,3,5,4,5,3,3,2,3,3,3,5,4,1,2,3,5,3,2,3,3,3,2,2,2,3,4,1,2,1,1,2,2,5,1,1,3,1,1,1,3,4,5,2,1,1,5,4,3,4,5,2,3,2,4,3,5,3,1,4,2,2,2,4,5,2,5,5,2,4,2,5,1,3,1,2,3,2,3,1,5,1,2,5,4,4,3,2,3,2,5,4,4,2,5,3,5,3,5,4,2,4,3,1,2,1,4,4,4,4,3,1,1,2,5,3,4,2,2,2,4,3,3,1,5,2,5,3,1,4,3,3,2,5,5,4,5,4,3,2,3,4,2,1,4,4,1,3,1,3,5,4,4,3,5,2,1,4,2,3,2,3,2,3,2,2,4,1,3,5,2,5,1,2,4,2,5,2,5,2,5,4,2,1,1,2,2,4,3,1,4,3,5,2,5,5,1,3,1,5,2,1,5,1,4,1,2,5,4,5,4,5,1,5,1,3,1,4,4,2,4,5,3,5,1,3,1,4,1,3,5,1,4,2,2,5,3,1,5,3,5,1,1,2,2,1,5,3,1,2,2,4,4,4,3,1,3,2,2,1,1,3,2,4,2,4,1,1,2,1,5,3,1,3,5,4,2,2,1,4,1,1,3,3,5,5,1,5,5,1,5,3,1,4,5,1,5,2,4,5,1,4,5,4,2,2,4,1,4,3,4,1,1,1,2,2,1,2,4,4,2,4,4,2,3,3,2,4,4,5,1,2,2,4,2,5,5,5,2,2,2,5,1,5,5,3,1,1,1,4,5,5,3,3,2,3,5,4,5,4,1,1,4,5,3,5,2,5,5,4,1,3,3,1,5,5,1,4,4,1,5,3,5,4,1,2,1,5,2,2,4,2,2,1,2,4,2,3,3,3,1,5,5,4,5,4,2,2,1,5,2,1,5,5,2,3,3,1,5,2,4,4,1,3,2,5,1,2,1,5,3,3,3,2,3,3,4,2,1,4,2,3,3,3,5,4,2,4,5,5,1,5,2,4,4,3,1,2,2,1,4,4,4,1,5,3,5,1,2,3,5,5,3,4,3,4,3,3,3,4,2,5,4,3,5,4,2,2,3,3,5,2,3,5,3,3,3,5,5,2,1,1,3,1,1,4,1,2,1,3,5,4,1,4,1,5,4,4,2,2,5,3,2,2,2,5,2,1,1,5,3,4,5,1,5,5,1,2,2,2,4,4,5,5,4,1,4,4,5,5,5,5,2,3,3,3,5,1,5,5,5,1,3,2,5,4,3,2,4,2,4,1,3,1,5,1,2,5,2,4,2,5,5,4,1,4,4,5,1,1,5,2,4,1,5,5,1,2,4,4,1,4,3,1,2,4,1,2,1,4,5,2,5,2,5,1,1,2,5,2,1,1,1,3,3,5,2,5,1,3,1,2,3,4,3,1,2,4,4,4,2,1,1,4,2,3,4,1,3,3,4,3,4,4,3,2,1,2,3,2,3,1,3,3,5,4,1,1,1,3,3,4,5,5,5,3,1,2,1,2,3,4,5,4,5,4,1,5,1,3,1,4,1,2,5,1,4,3,4,2,4,2,3,3,4,5,5,5,2,5,3,3,5,3,5,1,4,3,2,1,2,2,4,1,5,3,3,1,2,2,4,5,5,4,4,1,2,1,5,2,2,4,1,2,5,4,1,3,3,1,1,1,3,3,4,1,1,4,3,2,2,3,1,3,5,4,1,3,4,2,2,2,2,4,1,3,1,3,2,5,2,2,2,1,3,3,4,2,3,4,2,1,4,1,5,4,5,1,4,5,3,4,5,3,4,5,1,3,4,2,5,3,3,4,4,5,4,1,5,4,1,1,1,3,3,1,5,1,2,2,2,5,3,1,2,4,1,1,1,3,3,3,2,5,4,2,1,5,1,3,4,4,4,5,4,2,4,5,3,5,5,5,3,5,3,1,2,1,3,1,2,5,1,1,5,1,3,4,5,2,2,4,5,2,2,5,4,5,1,2,2,2,4,1,3,2,2,2,5,3,2,2,2,2,4,3,3,3,4,3,1,3,2,5,5,4,5,2,4,2,4,4,2,4,2,5,3,2,4,3,2,3,5,4,2,3,2,4,4,5,3,5,3,2,2,3,2,1,1,3,5,1,1,3,2,2,2,2,5,3,2,2,1,4,1,4,4,2,3,5,5,1,3,4,4,1,1,2,1,4,5,3,1,1,5,1,1,2,4,1,2,2,5,1,2,1,5,2,5,5,2,4,5,4,4,4,3,1,5,5,4,4,1,2,4,2,4,2,2,3,2,5,5,1,2,1,4,5,3,5,3,2,2,1,4,1,4,1,4,1,5,4,2,1,5,2,3,3,5,4,2,1,1,4,5,2,4,1,1,3,4,2,5,2,5,5,4,1,5,1,3,2,3,2,4,4,2,5,3,3,3,2,2,1,1,3,4,1,4,5,3,3,4,4,5,1,1,2,3,3,4,4,4,5,5,3,2,3,3,4,3,2,1,3,1,2,3,4,5,1,3,1,4,4,1,5,1,2,1,5,3,2,4,1,5,3,5,3,1,2,4,4,2,4,2,4,1,1,2,2,1,1,2,1,3,5,4,4,4,4,3,5,5,4,3,3,2,2,1,5,2,3,5,3,3,5,4,3,4,2,2,2,3,5,3,4,1,1,2,1,5,4,1,1,4,2,4,2,3,4,3,5,1,4,2,4,1,2,2,3,1,5,2,4,3,3,1,1,3,2,1,4,4,1,5,2,5,3,3,1,5,2,4,4,3,3,1,5,1,2,1,5,1,3,2,5,1,3,1,4,2,3,3,2,2,4,3,3,4,1,2,3,4,5,5,1,2,1,5,1,2,1,2,1,3,5,2,4,5,5,2,2,1,5,5,3,3,3,3,2,1,3,2,4,3,1,3,1,4,3,5,3,4,1,1,2,5,2,3,2,2,5,1,3,2,5,5,1,3,2,5,2,2,1,4,4,1,5,1,4,3,1,1,4,1,4,2,2,2,1,2,4,5,1,5,3,2,3,5,1,5,3,2,2,2,5,3,3,5,1,2,5,5,2,5,4,2,1,3,4,4,3,4,2,4,5,1,5,4,5,3,3,5,2,3,3,4,1,2,4,2,3,3,4,3,3,5,1,3,4,2,3,3,2,2,2,3,3,1,2,2,1,1,2,1,1,5,2,1,2,5,1,4,1,4,4,3,3,3,3,1,2,3,5,3,4,4,5,1,5,4,4,5,2,2,1,5,2,2,3,3,1,2,5,1,3,3,1,5,4,2,3,5,2,2,4,4,2,1,2,5,3,4,5,3,1,3,4,3,2,3,3,1,3,2,5,3,4,3,5,2,3,4,2,4,5,3,4,1,2,4,3,3,2,2,4,3,1,4,3,4,3,2,5,1,1,1,5,1,3,4,5,2,4,4,4,2,5,3,4,2,3,1,5,4,4,3,2,1,2,5,4,5,4,4,3,1,1,5,1,3,2,1,4,2,3,2,2,3,4,1,3,5,3,5,1,5,1,3,1,1,2,2,3,4,2,1,1,3,3,2,1,5,3,2,2,4,5,1,5,2,1,3,3,5,3,2,3,2,2,4,1,4,2,2,2,5,2,5,5,2,1,4,2,5,1,5,1,5,4,2,1,4,3,1,4,5,1,5,5,2,2,3,4,3,2,5,2,5,5,1,1,1,4,2,3,5,4,2,4,5,2,4,5,2,2,3,3,2,3,4,3,4,4,4,2,1,4,4,5,5,2,4,5,1,1,4,1,1,3,3,2,1,2,5,5,3,3,1,1,4,4,5,2,3,5,2,3,5,3,5,3,5,3,5,5,5,3,2,1,3,2,2,4,4,2,5,2,3,5,5,1,1,3,3,3,5,1,4,1,2,3,1,2,3,3,3,2,2,3,3,2,3,5,4,5,2,5,2,3,2,1,5,3,2,2,5,4,1,4,3,3,1,1,3,2,1,3,4,5,5,1,1,4,1,2,3,4,1,5,3,1,1,4,5,3,4,1,2,3,5,4,1,3,4,5,5,4,2,1,2,2,2,3,5,5,4,4,5,5,5,1,5,4,3,3,5,4,5,5,3,4,5,2,2,2,3,3,3,1,2,1,3,2,2,4,1,1,1,5,3,3,1,4,1,2,3,2,4,4,1,2,5,1,4,3,4,3,3,3,3,5,4,2,3,1,4,1,5,1,5,2,1,3,4,1,2,3,1,2,5,1,1,4,3,3,2,3,1,1,2,2,1,5,3,3,4,4,2,4,1,3,5,5,2,1,5,4,3,1,1,1,3,4,3,1,2,3,2,4,4,5,1,3,1,4,1,5,5,1,3,3,5,3,3,3,1,5,4,5,3,1,5,1,3,5,3,5,5,1,1,5,4,4,1,5,5,1,4,1,1,2,4,4,2,5,4,3,4,2,3,2,5,2,4,2,4,5,3,1,5,3,5,5,1,4,1,2,3,3,4,1,1,3,5,4,1,1,3,2,3,1,2,4,4,1,2,1,5,1,5,2,2,4,3,4,2,5,5,4,3,5,2,3,1,3,4,5,2,1,4,2,3,3,5,1,2,1,1,2,3,4,4,1,5,1,2,5,2,2,4,3,2,4,2,1,1,4,3,4,2,2,1,3,5,1,2,4,4,5,4,5,3,2,4,2,3,3,4,3,4,2,2,3,4,3,5,1,3,3,5,5,3,1,3,5,5,3,5,1,2,5,5,2,5,1,1,1,5,2,5,3,4,3,4,2,1,1,3,3,2,4,1,5,5,1,3,1,5,3,1,5,5,5,4,1,3,4,4,5,1,3,2,3,3,2,1,3,3,5,5,2,4,4,4,1,4,2,1,2,3,5,2,5,4,5,2,5,3,2,1,3,5,2,2,5,1,2,4,5,3,4,1,5,3,2,3,4,5,1,2,2,4,3,5,5,1,2,4,1,4,1,4,2,5,4,5,3,1,1,4,4,3,4,5,4,3,1,5,3,4,3,1,2,3,4,3,3,1,5,3,3,1,1,4,3,2,3,3,5,5,3,5,4,2,1,1,3,5,2,1,2,3,1,5,1,5,3,1,2,2,1,5,4,4,4,5,2,4,4,4,4,2,2,5,4,1,4,2,5,4,4,4,3,3,1,2,1,4,5,2,3,2,1,2,1,5,1,4,2,1,3,1,4,2,4,5,3,1,5,2,5,1,1,1,5,4,4,2,4,3,3,3,3,3,3,3,3,2,5,4,3,3,2,3,2,2,2,5,4,2,4,3,1,5,1,1,4,5,1,2,4,2,1,4,2,1,2,2,1,2,4,4,3,4,1,5,4,3,3,5,1,4,2,2,2,1,2,4,1,2,4,5,4,2,4,4,1,5,1,2,5,5,4,3,2,2,4,5,5,4,4,5,4,3,1,2,1,1,2,4,3,4,2,5,1,1,3,1,1,2,3,5,5,1,3,4,1,5,2,2,1,2,4,1,4,1,3,3,4,4,5,5,3,1,5,4,1,1,5,3,5,2,4,2,4,3,2,5,4,1,4,3,5,3,1,2,5,3,1,4,3,5,4,2,3,2,2,2,3,4,5,5,1,3,3,5,4,2,3,4,2,1,1,3,5,5,3,5,5,3,1,5,3,2,4,3,1,2,4,1,3,3,3,3,2,1,5,2,1,1,5,2,5,4,4,5,2,3,1,1,4,3,2,4,3,4,3,4,3,1,4,4,3,2,1,2,2,3,2,1,3,5,1,2,3,1,1,4,4,5,4,3,4,5,5,5,4,3,1,5,3,2,1,4,2,4,2,4,4,4,1,3,1,1,5,2,3,1,2,5,1,5,3,1,5,4,2,1,1,3,4,2,5,2,5,3,5,1,4,4,2,5,4,3,3,3,5,3,3,5,2,4,1,5,1,5,3,4,2,1,1,2,4,2,1,2,4,3,1,4,4,4,1,5,4,3,3,3,3,4,1,1,2,4,3,1,3,3,4,4,3,4,3,2,4,5,4,1,4,3,1,2,1,1,4,2,3,4,5,5,2,5,2,3,1,5,5,2,2,1,1,3,3,5,1,1,5,2,1,3,4,4,4,5,5,3,4,1,1,2,5,3,5,3,2,1,2,5,4,3,2,5,3,2,4,1,4,1,1,5,5,3,4,2,5,1,1,2,1,4,5,4,4,1,2,4,1,5,5,4,3,4,3,4,5,2,3,1,1,4,4,4,2,5,2,1,4,2,1,2,1,1,2,5,3,2,3,5,5,3,1,5,3,1,5,2,2,2,2,3,3,1,2,4,2,2,1,2,1,3,3,2,5,2,1,5,1,5,5,4,3,5,2,3,3,2,4,3,3,2,4,3,1,3,2,1,1,2,5,2,4,5,5,1,4,2,4,2,2,1,5,2,1,5,1,2,5,1,5,4,4,3,4,1,3,2,5,3,4,4,3,5,4,5,2,3,3,5,3,3,5,5,4,5,5,4,4,5,5,5,3,1,2,5,2,1,5,1,3,3,1,1,5,2,3,2,2,2,3,1,5,4,4,2,1,3,4,1,2,2,2,3,3,1,2,4,3,1,5,4,5,1,3,1,1,3,2,2,5,2,2,2,1,4,1,4,1,1,1,3,3,4,5,2,5,1,5,3,5,2,4,4,5,4,4,1,4,4,2,4,3,1,2,1,4,4,2,4,2,5,2,2,4,5,2,3,3,4,3,3,5,5,4,3,4,4,3,5,4,4,5,2,2,4,1,5,1,5,3,1,4,3,5,1,4,2,3,3,5,5,2,5,2,3,3,1,3,1,2,2,5,5,2,5,4,4,3,3,4,2,3,2,5,1,4,3,4,1,2,3,3,2,4,2,3,1,4,1,3,4,1,1,3,4,5,5,5,5,5,5,3,1,4,5,2,1,5,2,3,1,2,2,2,5,5,5,4,2,1,2,2,4,4,2,5,1,1,2,2,1,2,2,2,4,4,2,5,5,3,1,1,3,2,2,1,5,5,2,2,5,5,4,5,3,3,2,3,4,2,2,3,1,4,4,5,3,3,5,5,5,4,3,2,1,2,3,3,3,3,2,5,3,4,4,5,1,4,5,4,5,1,3,2,4,5,2,1,5,4,5,1,1,5,4,5,4,5,2,5,1,1,2,5,3,1,2,1,3,1,3,4,2,1,1,3,1,5,5,1,4,1,4,1,2,3,1,5,1,5,1,1,4,2,2,4,3,2,1,1,3,2,3,1,2,3,3,1,2,3,3,2,3,4,1,1,3,3,3,1,5,2,3,3,2,1,1,3,1,2,2,3,3,4,1,4,4,3,2,2,1,5,5,4,3,1,4,5,4,2,2,1,1,2,5,2,5,2,4,4,4,2,5,3,3,1,2,1,3,2,5,5,4,2,1,4,2,4,3,2,5,4,3,1,2,3,1,4,4,2,1,4,3,1,2,3,4,3,2,3,3,4,3,3,1,1,2,1,3,3,3,1,2,3,1,5,1,2,4,2,4,1,1,4,3,3,1,1,5,5,1,1,4,5,4,1,2,2,1,1,5,1,5,3,3,4,5,3,5,3,4,3,4,1,5,2,1,5,2,2,4,3,1,2,2,3,5,5,4,3,5,2,1,3,2,4,1,3,4,4,3,1,5,3,3,4,3,4,4,4,4,5,3,4,2,1,5,3,5,1,1,2,2,1,4,1,3,2,1,1,1,4,1,5,1,4,3,4,1,4,1,1,3,1,4,5,5,1,4,5,3,4,1,5,2,2,5,3,2,2,4,5,2,2,4,1,1,4,3,4,4,4,5,5,3,2,5,5,5,2,5,3,5,3,3,2,3,5,1,4,1,2,3,3,2,4,2,5,4,4,3,2,5,3,3,2,2,5,5,2,5,5,1,3,4,5,3,5,2,5,3,1,3,5,3,2,1,4,3,3,4,1,4,1,1,5,5,1,4,4,1,5,4,1,2,2,4,4,2,3,1,4,2,2,2,2,2,4,3,4,5,2,5,1,4,5,5,3,1,2,2,3,4,3,5,1,4,1,3,3,2,4,2,4,3,5,5,1,3,2,5,5,5,2,1,4,3,1,2,2,4,2,5,3,2,5,5,3,3,4,5,3,4,1,4,3,3,4,2,4,1,1,3,1,2,3,1,4,1,5,4,4,1,4,2,2,4,2,1,3,1,1,1,3,5,4,3,4,2,3,5,5,5,1,5,1,3,2,3,2,5,4,4,3,4,4,3,4,2,1,1,3,2,1,1,4,1,4,4,5,4,4,1,1,2,5,2,3,5,2,1,2,2,1,4,1,2,2,1,3,5,1,3,1,3,5,4,5,5,3,4,5,1,4,2,4,5,4,4,2,3,5,1,2,3,4,1,2,1,2,1,3,5,1,3,4,4,2,2,3,2,5,4,4,3,4,5,3,1,1,3,3,4,2,4,1,5,3,4,1,5,2,2,1,3,1,1,5,5,4,1,3,5,1,4,5,4,2,5,5,2,1,3,5,1,2,4,4,3,1,2,2,4,1,4,3,2,2,3,3,5,2,2,2,3,4,2,2,3,5,4,4,3,1,3,3,2,3,4,4,1,1,5,4,1,5,3,3,1,3,2,5,1,2,4,4,4,2,3,1,1,5,2,5,3,1,1,4,3,5,5,4,4,1,1,1,1,3,4,1,4,2,4,5,4,2,1,5,3,1,3,2,4,1,1,2,2,1,5,2,3,4,4,1,4,3,5,4,1,4,4,2,3,1,5,5,1,5,2,1,2,4,5,3,3,4,4,2,1,5,4,1,4,3,4,5,3,4,2,5,2,3,3,5,5,2,3,5,5,3,1,1,5,2,2,1,4,4,3,5,3,2,2,3,5,5,4,2,3,3,4,4,5,5,3,2,3,5,3,5,4,4,1,3,4,4,2,2,2,5,1,3,4,1,2,3,2,1,4,1,1,2,3,5,4,5,4,3,4,2,2,4,1,1,5,2,3,4,3,2,1,3,1,5,5,5,2,5,3,5,1,3,2,3,1,3,2,1,4,4,4,3,5,1,4,4,2,3,4,5,4,3,1,3,3,2,3,2,5,2,1,2,3,4,3,5,4,4,5,1,3,4,3,5,5,2,5,5,1,4,1,4,1,1,1,5,4,1,2,4,5,1,5,2,5,5,2,4,3,3,1,4,1,1,5,4,5,2,3,3,1,4,2,4,2,5,3,3,4,5,5,2,1,3,4,1,1,2,2,2,2,1,5,1,3,5,3,3,3,2,1,1,5,5,4,3,3,2,4,3,2,2,1,5,1,1,3,1,4,5,1,5,4,4,2,5,4,5,2,5,2,4,2,4,3,2,3,3,5,5,2,3,4,5,3,2,1,2,2,2,3,4,3,5,1,3,2,4,1,1,1,5,2,4,3,3,4,3,1,3,5,1,5,4,3,2,3,3,5,2,3,2,5,1,5,3,4,1,5,4,4,3,5,5,4,4,3,5,4,4,2,1,1,3,1,5,1,3,2,5,5,1,4,3,3,5,3,3,3,3,4,5,1,3,2,1,1,4,1,4,2,1,4,4,3,1,2,2,4,1,3,5,5,3,2,3,1,2,4,2,5,2,5,1,3,1,2,3,2,4,2,5,1,4,4,3,3,1,5,3,4,3,5,1,3,4,3,1,4,4,5,2,4,3,5,2,1,3,5,4,1,1,3,1,5,4,4,4,1,3,4,2,4,1,3,5,2,2,5,4,2,5,2,2,2,1,2,5,5,5,3,4,5,4,3,4,1,2,1,2,5,3,5,2,5,5,3,1,5,2,5,2,4,4,3,4,5,2,1,2,3,5,3,3,5,3,1,3,4,2,3,3,2,4,2,3,3,1,5,2,4,5,4,4,5,2,1,4,5,4,1,2,5,3,3,4,5,5,4,1,4,3,4,2,1,1,1,3,2,5,5,1,5,5,3,5,3,3,5,1,4,1,3,3,2,2,1,2,3,3,5,3,4,3,3,4,1,4,4,1,2,3,4,4,1,3,3,3,3,1,4,4,1,3,3,1,1,2,4,5,5,1,2,1,4,1,3,5,2,1,1,1,3,3,3,1,5,5,5,1,4,2,3,1,2,3,4,1,2,5,2,1,5,3,4,3,1,1,1,1,4,2,1,4,5,1,2,4,5,5,3,2,4,2,5,3,2,2,4,1,5,2,5,4,2,3,1,3,3,4,3,2,3,3,2,3,5,3,4,5,2,1,4,1,5,3,2,5,1,4,2,1,2,2,4,4,2,5,1,1,3,2,1,4,3,3,4,3,5,1,4,2,5,5,1,4,5,3,2,1,3,2,1,4,2,5,2,2,5,3,1,4,3,1,2,1,5,2,2,2,1,5,3,1,4,3,2,5,4,4,2,3,4,4,4,1,3,1,2,4,4,1,1,3,2,3,1,1,3,4,2,4,2,2,3,5,2,5,2,5,3,5,3,2,3,1,5,5,3,5,4,2,3,3,4,4,2,3,4,3,3,2,2,4,2,3,1,2,5,2,1,2,5,1,5,2,1,3,5,4,5,1,1,3,3,4,4,3,3,2,1,2,4,2,3,3,4,1,3,5,1,3,3,1,5,3,2,4,1,4,3,2,4,1,5,3,1,3,4,3,2,3,5,5,5,3,4,1,4,5,4,1,5,2,3,3,1,2,5,5,2,5,4,2,1,3,4,3,2,3,3,4,2,2,3,1,2,3,5,5,5,2,4,5,4,1,3,3,2,4,2,5,3,5,1,4,4,5,4,3,4,1,1,3,1,3,5,1,5,4,2,5,3,4,3,4,2,2,2,3,2,5,4,5,3,1,1,4,5,5,1,2,3,4,1,4,2,5,2,4,4,2,3,1,4,1,3,3,3,4,1,3,4,1,2,5,1,1,2,3,3,3,1,2,1,2,1,5,2,4,5,3,4,5,5,3,4,3,4,3,5,4,1,2,4,4,5,3,1,5,5,3,2,4,2,5,5,4,1,5,1,2,2,4,2,4,2,3,2,3,5,2,4,4,3,4,5,1,1,5,2,5,1,5,4,3,1,5,5,1,2,4,1,1,3,3,3,2,2,5,5,3,1,3,5,4,3,3,1,4,5,5,1,2,2,5,3,4,4,5,3,3,5,1,2,5,1,1,5,1,2,2,2,1,3,1,2,3,3,5,3,3,3,4,5,2,1,3,2,2,4,1,2,2,3,5,1,3,3,3,4,5,2,2,3,3,1,4,4,2,5,2,1,3,4,3,2,3,3,4,1,5,4,1,5,1,2,4,2,1,5,4,2,2,2,5,4,1,3,5,4,2,1,5,2,5,1,5,2,4,2,3,1,2,3,5,5,3,3,3,5,5,3,2,4,3,2,4,5,4,4,5,1,1,1,4,3,4,3,5,3,1,2,4,2,1,5,5,2,4,4,1,3,1,2,3,3,5,1,1,1,5,1,2,4,1,2,3,4,3,3,5,5,4,2,2,5,4,1,5,2,3,5,3,4,4,1,1,4,1,3,1,3,2,1,1,2,1,1,3,4,2,3,5,2,2,2,2,2,1,5,3,1,5,3,1,2,3,5,2,1,3,2,5,3,1,3,4,1,4,1,2,3,2,1,2,4,2,2,5,3,3,3,3,3,4,4,3,2,5,2,1,5,4,2,2,3,1,2,2,2,5,4,1,3,3,5,5,3,5,2,1,2,4,5,2,5,4,2,3,5,3,3,4,4,3,5,1,1,4,1,1,2,5,1,3,2,5,4,2,4,4,2,1,4,4,2,1,4,1,3,1,1,4,2,5,5,1,3,5,1,5,4,2,3,3,1,2,1,3,3,2,5,2,3,1,1,1,1,5,5,2,5,4,5,4,2,4,1,4,2,1,3,5,2,3,1,1,1,3,3,2,3,3,4,3,2,5,5,4,4,1,1,2,1,5,4,5,2,3,5,1,5,2,4,1,1,1,1,3,1,1,4,1,1,2,1,5,2,5,1,1,5,4,2,4,4,2,2,3,3,1,5,1,3,4,3,4,2,4,4,2,4,2,5,2,3,1,4,2,1,1,5,3,1,5,2,1,1,4,5,3,4,1,1,3,2,4,5,4,5,1,2,3,2,1,2,4,5,4,1,2,4,3,2,2,5,2,4,4,5,5,5,4,3,4,4,4,5,5,5,5,4,1,1,3,5,4,5,3,5,3,2,5,5,5,5,1,3,2,2,2,2,2,1,3,4,3,2,4,1,2,3,3,1,1,5,3,5,4,1,1,3,1,2,2,5,4,4,4,2,5,1,4,5,1,5,3,1,5,1,5,4,4,2,3,2,5,5,2,1,4,5,3,1,1,5,4,2,1,3,5,1,2,5,3,5,5,1,4,1,5,3,3,4,5,5,1,5,5,2,4,4,5,2,4,1,3,3,1,3,5,2,5,5,4,1,5,1,5,1,1,2,2,1,1,2,1,5,1,3,5,1,5,4,5,2,1,2,5,4,1,4,2,1,3,4,3,1,4,4,2,5,1,4,2,5,2,2,2,3,3,2,3,3,5,4,4,1,3,1,3,3,5,2,2,2,1,3,3,2,5,2,4,2,3,4,3,2,1,3,5,4,4,1,3,3,4,4,3,1,5,3,1,4,2,4,1,1,1,4,5,4,4,1,1,1,4,2,5,5,3,5,4,3,2,5,3,5,4,3,1,2,3,3,5,3,4,3,5,1,2,5,3,4,2,2,3,2,3,4,2,3,2,1,2,2,2,4,3,1,4,2,1,5,3,5,3,2,5,4,4,1,5,5,4,3,1,1,2,1,4,4,3,2,2,1,1,5,1,2,2,5,1,4,1,1,4,5,2,3,3,1,5,4,1,3,4,2,2,5,2,4,4,2,4,1,5,5,4,3,2,1,2,4,4,5,1,3,5,4,3,3,3,4,2,2,4,5,4,4,1,2,1,5,4,2,5,4,4,3,3,3,1,3,2,4,1,1,1,3,4,4,5,1,4,4,1,4,4,4,1,2,3,4,4,5,5,2,4,1,3,3,2,4,3,2,3,1,3,1,5,5,2,3,1,1,4,2,1,3,1,2,2,3,4,2,1,2,5,1,5,1,2,3,3,1,5,5,5,2,4,3,4,4,1,3,3,1,4,4,4,1,2,1,3,5,1,5,4,5,4,2,5,3,1,2,5,3,1,2,5,2,1,4,3,5,3,2,5,2,4,3,4,2,4,1,4,1,1,3,5,2,1,5,1,1,1,2,3,2,4,5,5,4,4,1,3,5,3,2,5,1,3,2,5,2,5,1,2,1,1,3,4,5,3,2,5,4,2,4,3,5,2,4,2,1,3,2,2,4,3,1,2,5,4,1,1,1,2,3,2,2,5,2,5,2,1,5,4,2,1,3,4,3,4,3,4,4,1,3,5,5,2,2,4,1,4,4,3,4,1,2,5,2,1,2,1,3,3,5,2,5,3,4,3,3,2,5,4,1,3,3,5,3,4,4,3,2,4,2,4,1,4,3,1,4,3,2,3,4,4,3,5,4,4,3,5,5,3,2,3,1,3,5,3,4,2,1,5,2,2,3,3,4,1,3,2,1,2,2,2,3,1,4,2,5,4,5,3,3,1,1,3,4,1,2,5,1,4,2,5,1,2,5,1,2,2,3,5,3,1,1,1,5,4,4,3,5,3,3,4,3,5,1,1,1,2,5,3,2,3,5,4,2,3,1,2,4,4,1,2,5,4,3,2,2,2,4,4,1,5,2,5,5,4,2,1,4,3,4,2,1,2,4,2,5,1,4,1,1,1,5,3,5,5,4,3,1,3,4,1,3,4,5,1,2,4,3,3,4,1,1,1,3,2,1,2,1,1,2,5,3,5,1,2,2,1,2,1,2,4,5,5,1,1,2,1,4,2,5,5,3,1,4,3,3,5,2,1,1,4,4,4,4,3,5,1,4,5,3,1,4,5,1,3,5,2,2,3,2,1,1,5,1,1,1,2,4,5,3,1,4,1,3,2,2,1,4,3,1,5,3,5,5,2,1,5,4,2,1,4,4,1,2,1,2,4,4,4,5,3,5,5,2,3,1,5,2,1,1,1,2,2,3,1,4,3,3,2,5,1,3,4,4,5,2,1,4,5,5,5,1,5,2,2,2,1,3,2,1,3,1,1,2,3,5,1,4,4,1,3,4,3,1,4,2,5,4,5,4,1,3,2,4,2,1,2,3,1,5,3,3,1,4,3,3,2,4,3,2,3,5,2,3,1,3,4,2,5,4,5,3,1,1,2,2,1,3,3,1,1,3,1,5,4,3,3,4,5,5,4,5,3,3,3,3,1,1,2,5,5,5,4,4,3,4,2,3,2,1,2,3,5,5,4,4,2,5,5,2,3,3,4,3,4,1,3,1,3,4,2,2,3,5,4,5,5,4,4,5,1,1,3,5,2,2,2,2,3,4,5,4,5,1,1,4,5,3,2,3,3,3,3,2,4,1,2,2,1,2,1,2,2,4,4,2,4,3,3,4,3,5,5,1,1,1,2,2,2,5,2,2,3,3,4,3,1,3,5,5,5,5,5,2,4,1,2,1,1,3,2,3,2,2,5,2,4,4,4,5,5,1,1,5,3,1,2,4,4,1,4,3,3,3,4,3,5,5,3,4,1,3,2,1,2,4,3,4,5,4,3,3,5,3,1,1,3,5,5,2,4,2,5,1,3,2,3,4,3,4,1,1,4,3,4,3,4,3,1,2,2,5,2,2,2,4,5,5,3,2,2,2,2,1,4,3,4,5,2,5,2,5,2,2,5,4,3,3,2,2,3,5,4,4,5,5,4,4,2,4,2,2,3,1,1,5,2,2,2,4,5,5,5,4,5,2,1,1,3,2,4,3,2,4,3,3,5,5,5,2,2,1,5,3,2,3,3,1,5,2,3,1,5,4,4,4,3,5,1,4,4,3,1,1,1,1,5,2,3,3,5,3,3,4,4,2,1,4,2,3,2,1,4,3,3,3,3,5,1,2,2,1,4,4,2,3,5,3,5,1,3,4,4,5,3,2,1,2,2,5,4,4,4,4,4,3,2,4,1,2,2,2,1,4,4,4,3,5,1,4,2,4,4,3,4,1,4,1,3,1,2,1,4,3,3,5,3,1,2,4,3,3,2,4,1,3,2,3,5,3,1,1,5,5,5,2,4,2,2,1,3,3,4,3,1,1,2,2,3,5,3,4,5,1,5,1,4,5,1,5,5,1,2,5,5,4,1,2,4,4,1,4,5,2,5,1,4,5,1,3,2,2,3,2,1,1,2,3,3,4,5,1,4,5,4,3,5,1,5,1,4,2,5,1,2,4,5,1,3,1,3,1,2,3,5,5,3,1,5,4,5,3,1,3,4,1,3,5,2,3,2,4,1,2,3,2,5,4,1,3,2,1,1,5,5,5,4,5,4,5,3,4,4,2,2,5,2,5,3,1,1,5,1,4,2,3,4,4,5,1,1,1,3,4,4,2,5,2,3,3,4,4,5,1,2,2,3,3,5,2,3,3,2,2,2,3,3,5,2,4,3,5,2,3,2,5,1,2,4,3,3,2,3,5,5,2,4,2,5,1,1,1,3,2,5,4,2,1,4,1,4,3,3,3,1,2,4,3,1,2,3,3,2,3,4,1,5,3,4,1,1,5,4,5,2,3,2,2,5,4,4,3,1,5,1,1,1,4,4,5,4,3,5,3,1,2,5,1,1,4,4,5,4,4,3,1,4,2,1,3,5,1,2,5,5,3,1,2,1,2,5,3,1,1,1,1,3,2,3,2,4,5,2,1,4,5,1,5,5,1,1,1,5,3,1,4,3,4,3,5,1,3,2,2,5,2,3,2,4,4,3,2,4,2,3,5,3,1,4,5,2,1,2,1,2,1,1,1,2,1,3,3,1,4,5,3,5,3,5,4,3,5,3,4,2,5,2,5,2,2,5,2,1,3,4,2,3,1,1,1,5,2,3,1,3,3,5,4,5,5,3,3,2,4,4,2,2,1,5,2,5,5,5,4,4,4,5,5,3,1,1,5,3,2,2,4,3,4,3,2,5,5,5,4,5,2,2,1,3,1,2,1,5,5,5,2,5,3,1,4,5,3,3,1,5,2,3,5,5,5,5,4,2,4,4,4,4,5,2,3,1,1,3,2,1,4,1,5,5,4,1,2,3,2,3,3,1,5,3,3,1,1,4,1,2,4,2,3,5,5,2,5,4,3,2,3,3,3,3,5,1,4,4,2,1,4,2,5,1,1,3,5,5,5,5,3,3,3,2,1,3,3,3,4,1,4,1,1,3,1,3,3,3,3,3,5,2,4,3,2,1,4,2,3,1,4,2,3,3,1,1,4,2,2,1,4,5,4,3,2,1,4,4,1,2,5,1,2,3,2,2,1,3,4,4,4,4,1,4,3,1,2,4,1,5,4,2,4,5,2,4,4,4,3,4,4,5,4,5,3,4,4,2,2,2,2,3,5,2,4,2,5,3,5,5,5,3,1,5,1,4,4,3,5,1,2,3,2,3,3,4,4,5,5,3,3,5,1,1,4,2,5,4,3,5,3,4,4,5,5,1,5,5,5,4,3,4,1,1,2,5,2,2,5,5,2,1,5,5,2,3,3,4,3,4,3,1,5,3,2,3,4,3,4,3,3,3,3,2,1,4,1,4,4,5,2,1,4,2,2,5,1,1,1,3,3,2,2,2,3,5,3,5,5,1,2,4,2,2,1,2,4,1,3,5,2,5,2,4,2,5,5,1,2,3,2,5,4,4,1,5,2,1,1,2,3,1,1,2,1,5,5,3,3,2,1,1,2,5,1,1,2,5,3,4,4,5,4,2,3,1,5,1,3,4,5,5,3,3,3,5,4,3,3,5,1,4,4,4,2,3,2,2,1,3,1,5,1,2,5,4,2,1,2,2,4,1,2,3,5,5,1,5,1,2,1,3,3,5,3,3,5,1,2,4,5,4,5,4,4,1,5,5,3,1,1,2,4,3,2,2,3,4,5,5,5,3,3,4,2,3,3,2,4,3,5,1,2,1,2,4,5,2,2,4,1,5,1,4,5,3,5,1,3,3,3,2,1,4,2,2,5,4,1,2,5,2,4,4,1,1,1,4,2,1,1,1,2,3,5,3,5,2,3,3,3,2,2,1,1,1,3,4,2,2,3,5,5,3,4,4,4,5,1,5,2,3,1,3,1,5,3,3,5,1,1,2,5,3,5,3,1,1,2,4,4,4,1,5,5,5,4,4,5,4,2,5,4,5,3,2,4,2,2,3,3,3,1,3,5,3,2,4,1,5,4,3,3,4,5,4,1,5,3,3,4,1,4,2,5,5,1,1,5,1,1,5,3,4,3,5,5,2,1,2,5,3,5,2,4,2,5,5,1,3,5,5,5,4,5,3,5,2,5,3,2,4,4,3,4,4,5,3,1,2,4,4,3,3,5,3,4,4,2,4,3,2,3,4,2,5,4,2,2,2,2,2,2,3,4,1,1,4,1,3,3,1,2,3,5,3,2,2,5,2,5,1,4,3,5,3,5,4,2,5,3,3,3,3,2,4,3,1,4,3,5,2,2,2,4,2,4,4,5,2,4,3,5,1,2,3,2,4,1,3,5,4,4,4,4,1,5,5,1,4,3,1,3,4,5,1,3,2,4,4,2,2,4,1,2,2,2,4,3,3,3,1,1,4,1,4,1,5,4,1,1,3,1,2,1,5,3,3,1,2,4,2,1,5,3,3,4,2,2,2,5,1,2,4,2,2,3,5,4,5,4,1,4,2,5,4,5,5,3,1,4,2,4,2,4,1,3,4,3,3,5,3,2,3,5,3,2,1,3,5,1,3,3,3,3,5,3,3,1,3,1,2,5,5,4,2,3,5,4,3,4,4,5,5,4,2,2,4,2,1,1,3,4,2,5,4,3,1,4,2,4,5,5,5,3,5,1,4,2,5,2,1,3,2,5,5,5,4,3,4,4,2,4,3,4,5,2,3,3,4,2,3,3,5,2,5,3,1,1,3,1,2,3,2,1,1,4,4,2,3,4,5,5,4,5,1,1,2,3,1,4,5,1,1,2,1,5,4,3,1,4,1,2,3,5,3,2,2,4,2,2,5,4,4,4,5,5,3,4,4,5,2,3,3,1,1,1,4,2,4,2,4,3,3,1,5,4,5,2,2,5,4,4,1,5,3,1,2,5,4,2,1,5,2,5,5,4,5,5,5,4,3,1,1,4,5,3,2,1,2,2,1,4,2,1,5,5,5,2,3,2,1,1,4,3,5,3,3,2,5,4,3,4,1,2,2,2,4,4,5,2,5,4,3,4,4,2,2,4,3,5,5,2,5,1,1,1,5,5,1,3,4,2,5,3,5,2,3,2,3,2,3,3,4,2,1,5,5,1,4,2,1,3,5,5,4,4,3,2,5,3,5,4,1,3,5,3,4,3,2,1,1,4,3,4,5,2,4,4,4,5,1,4,4,5,1,2,2,3,2,4,3,3,1,1,3,3,5,4,1,5,1,4,5,3,2,5,5,5,1,5,3,4,4,1,2,3,1,3,4,1,3,1,1,2,4,4,4,4,5,3,3,5,1,3,4,5,4,2,4,2,3,5,4,4,2,1,3,1,1,2,5,3,2,2,3,1,1,5,1,3,4,5,2,3,5,3,3,3,5,2,4,3,5,3,4,3,3,5,2,5,1,4,1,1,5,1,5,3,5,5,5,2,5,1,5,5,3,4,2,4,2,2,4,2,2,2,5,2,3,3,5,1,4,3,3,3,3,4,4,4,5,4,1,3,5,5,5,4,1,2,5,1,2,2,1,4,1,5,2,2,1,1,1,3,2,3,1,1,2,4,3,3,1,2,3,4,4,4,3,1,4,2,2,1,3,1,5,5,5,1,2,2,2,4,2,5,4,2,4,1,4,5,1,4,4,4,1,1,2,1,3,1,5,2,1,1,5,2,1,2,4,2,1,5,5,2,4,3,5,4,5,4,2,1,2,1,1,5,2,5,5,3,2,3,1,5,5,1,5,2,2,3,5,5,1,3,4,1,2,5,4,5,4,2,2,4,4,2,2,1,5,4,4,4,4,3,3,1,3,3,3,2,1,3,4,5,1,5,5,1,1,4,2,5,3,5,3,1,2,5,4,3,1,5,4,5,2,3,3,1,1,3,4,2,5,2,1,3,2,3,5,3,2,3,2,4,5,2,1,5,2,2,5,4,4,2,4,1,3,4,5,1,1,1,5,2,4,2,2,5,5,3,2,3,5,5,4,3,5,4,5,2,5,3,4,4,3,5,2,1,4,2,3,1,3,4,2,5,5,2,4,4,5,5,5,5,1,5,5,1,3,3,2,1,5,1,2,1,3,3,2,2,1,3,4,2,3,4,5,5,4,4,3,5,1,3,3,4,5,3,3,2,5,4,1,5,1,4,3,5,3,1,2,5,1,3,4,5,3,5,1,4,1,2,2,5,1,2,1,1,2,5,3,3,1,1,2,1,4,5,2,5,3,3,4,3,2,1,3,3,3,3,5,3,4,1,4,5,2,5,4,1,4,2,1,5,4,2,5,3,5,5,1,2,3,3,3,4,1,5,4,4,3,3,3,5,3,2,2,2,1,2,1,2,2,3,3,4,2,4,5,4,4,1,5,5,4,1,4,1,3,5,5,5,2,2,4,3,4,2,4,2,5,5,5,2,3,3,4,4,5,1,3,2,4,1,4,4,5,3,5,4,3,5,5,3,2,4,4,2,4,5,1,2,3,5,3,2,1,5,3,3,4,5,3,3,5,1,1,1,4,4,4,2,4,5,2,4,2,2,4,3,1,2,1,3,5,4,5,3,4,3,4,1,3,1,2,1,4,5,1,3,3,4,1,3,3,5,3,4,2,2,1,1,4,1,2,1,4,3,4,2,2,3,2,5,3,5,4,3,1,3,3,4,1,2,1,2,4,2,1,2,4,5,3,4,2,1,5,3,4,4,2,1,4,5,2,3,4,5,5,5,4,4,4,2,3,4,1,2,3,1,1,3,2,5,4,5,5,1,1,3,3,4,3,3,4,2,5,5,5,2,3,4,4,4,1,4,1,3,4,5,4,1,4,5,2,4,5,3,4,5,5,5,2,2,3,2,2,4,1,1,2,2,3,4,5,2,3,5,3,4,4,5,4,5,1,3,1,3,3,2,1,4,5,1,3,4,2,3,2,5,2,2,3,5,5,5,5,2,5,4,4,5,2,1,2,5,1,5,5,3,5,1,3,4,5,5,1,5,3,2,4,1,5,5,1,2,3,2,1,1,3,2,4,3,2,5,2,2,3,4,5,3,2,1,5,3,5,2,5,5,2,5,3,1,3,4,4,5,2,1,3,2,4,3,1,1,3,1,3,4,1,3,5,3,4,3,3,1,1,4,5,1,4,1,4,5,3,3,1,4,4,5,5,1,4,2,5,5,2,5,3,5,5,4,5,1,3,5,5,5,5,2,3,3,1,3,2,4,2,1,5,5,2,1,4,3,2,5,3,5,3,1,2,5,2,2,4,3,3,3,2,4,2,3,3,5,4,3,2,3,3,2,1,2,4,1,2,2,1,2,1,4,1,5,4,3,5,1,4,4,5,2,5,3,4,4,2,5,4,5,3,3,3,4,3,1,5,5,5,1,4,3,1,2,1,1,3,3,5,4,2,4,2,2,2,2,3,4,3,3,5,3,1,4,5,1,5,5,3,5,1,4,2,2,2,1,4,5,2,3,3,2,2,1,2,1,5,1,2,1,3,5,3,4,4,5,2,4,4,5,5,5,5,4,3,1,3,5,4,5,1,3,4,5,5,5,2,1,3,5,3,2,4,4,5,3,2,3,3,1,4,1,2,5,5,1,5,5,1,5,1,1,1,5,3,2,5,2,3,5,5,2,2,1,1,5,3,3,5,4,5,4,4,5,3,1,3,1,5,3,1,5,2,5,4,5,5,4,5,4,1,4,2,1,3,4,3,1,1,4,3,4,1,1,2,5,5,3,5,3,3,5,4,5,2,1,4,1,1,1,4,4,3,3,1,4,1,1,3,2,5,1,3,1,1,1,3,4,5,5,2,3,3,2,3,4,2,2,4,4,1,5,2,3,5,1,5,2,5,2,5,2,5,4,4,1,3,2,2,1,4,1,1,3,3,4,2,1,5,5,3,2,4,3,2,4,2,1,3,5,3,3,1,5,3,5,5,1,1,5,4,4,1,4,2,4,5,2,2,2,3,5,2,3,2,1,3,5,2,1,1,3,4,2,3,5,3,3,4,2,3,1,1,1,2,2,2,5,5,2,2,4,4,5,3,5,4,3,5,5,3,5,4,1,3,3,1,5,2,3,5,2,5,4,1,3,1,4,4,4,4,3,4,5,5,5,4,1,2,5,4,1,2,3,4,5,1,5,5,4,2,3,5,3,1,4,3,3,5,4,3,1,4,4,2,1,2,4,2,4,3,4,3,3,3,5,5,4,2,1,4,4,5,2,1,5,5,2,3,2,2,4,3,2,5,1,4,3,1,3,5,2,5,4,3,5,4,3,4,4,1,2,3,5,1,5,5,3,3,2,3,2,3,4,2,3,5,1,4,1,2,2,2,1,5,3,3,3,2,1,4,2,2,1,5,3,4,1,2,1,5,1,1,3,4,5,3,1,5,4,1,1,1,3,5,2,4,5,3,2,3,3,5,4,2,2,5,1,4,4,4,2,1,3,3,3,3,1,1,3,3,5,3,2,5,1,2,1,5,4,2,3,3,3,1,1,4,1,3,1,5,3,2,3,1,2,4,5,1,4,2,2,1,5,4,3,1,1,5,5,2,5,3,1,1,5,2,1,5,4,3,3,4,2,2,5,5,3,1,3,1,1,2,3,5,2,5,5,4,3,4,5,1,5,1,1,5,5,5,2,5,1,5,5,5,5,1,5,4,3,5,3,5,4,3,2,3,3,3,5,2,4,4,4,5,3,5,1,2,2,1,2,2,2,5,4,3,5,2,5,5,2,1,3,1,2,3,2,1,1,2,1,1,3,5,5,4,4,3,1,5,5,1,3,3,2,2,3,2,5,4,5,4,5,4,2,5,5,1,4,5,5,3,1,1,2,1,2,3,1,3,1,1,4,4,1,2,5,2,4,3,1,5,3,3,5,4,1,4,4,5,5,2,3,2,3,1,2,1,2,3,3,5,5,3,3,3,4,2,2,5,4,4,2,2,4,4,1,3,4,2,1,4,2,4,3,2,1,1,2,3,5,3,3,4,5,2,1,1,2,1,1,4,2,1,2,4,4,2,2,1,4,2,5,1,1,1,4,3,4,5,4,4,1,2,4,3,4,2,1,4,2,5,4,5,1,3,4,3,5,1,3,5,3,1,4,3,1,5,3,4,2,2,4,1,2,4,5,5,1,1,1,1,5,1,5,4,4,5,5,5,1,2,3,2,2,1,3,2,5,3,3,1,2,2,2,5,2,1,3,4,1,4,2,4,1,5,1,3,2,4,2,1,4,4,4,1,3,4,3,1,1,3,2,2,2,2,2,3,1,4,5,5,5,2,2,1,1,2,2,1,4,3,4,4,2,2,1,5,2,2,3,1,5,5,5,5,3,2,4,4,1,4,4,5,3,4,4,4,5,4,3,5,5,1,3,4,3,2,4,3,5,2,1,5,4,2,4,1,2,5,5,1,2,4,5,2,2,1,4,1,4,2,2,2,1,3,4,2,4,2,2,3,1,2,5,4,5,3,3,2,1,5,2,5,3,1,5,3,1,5,2,4,1,3,3,5,3,2,5,2,1,3,1,2,5,5,1,2,3,2,3,1,2,3,1,2,2,4,2,2,5,4,3,5,1,5,3,5,5,4,3,5,1,1,1,4,3,3,4,1,4,2,3,3,1,3,1,4,3,2,3,2,3,2,1,1,5,4,2,5,3,2,5,1,2,5,4,2,2,1,1,5,3,3,5,3,1,3,4,5,4,2,4,5,5,5,5,4,2,5,3,5,4,5,4,4,2,4,2,4,5,1,5,1,3,2,1,5,3,3,4,4,5,5,3,1,5,1,4,1,1,4,3,3,5,4,2,1,1,1,4,3,1,1,3,1,1,1,2,5,4,2,5,1,1,5,5,5,2,1,1,5,4,2,3,4,1,5,4,4,1,3,3,1,4,5,3,5,1,2,4,3,3,5,5,2,4,2,1,3,2,3,3,3,1,4,1,3,5,5,2,5,4,1,2,4,1,5,1,2,5,2,5,1,4,1,2,4,1,2,3,1,3,4,3,5,1,4,4,2,4,5,3,1,2,2,5,4,4,5,5,5,3,4,5,2,1,5,1,3,2,4,2,4,3,5,5,4,5,2,2,3,1,2,5,3,2,2,1,1,1,5,5,3,4,2,5,1,5,1,1,4,4,2,2,2,1,2,2,4,5,4,1,5,5,4,1,1,3,4,5,5,4,3,2,4,5,4,5,3,2,5,4,3,5,1,4,5,2,4,2,4,2,2,1,1,4,1,2,1,2,5,3,5,4,2,1,2,2,2,2,4,3,4,5,1,3,1,3,5,3,3,2,2,4,3,5,4,3,2,1,1,5,4,1,1,4,2,2,4,5,3,1,2,2,4,1,5,5,3,3,4,3,5,3,2,5,3,3,1,1,1,2,3,3,2,3,1,5,3,2,1,4,5,3,4,2,4,5,1,3,5,3,5,2,1,2,1,3,5,2,1,5,1,5,4,3,1,2,5,2,4,1,4,3,5,2,2,1,3,3,5,3,5,1,4,5,1,2,5,2,4,5,1,2,4,1,5,1,5,4,2,5,1,1,3,2,1,5,4,4,1,1,3,1,3,4,1,5,3,5,5,4,4,3,5,3,4,2,4,3,2,5,3,4,4,3,2,2,1,5,2,3,4,5,4,4,5,1,5,5,1,5,1,2,3,3,3,3,3,1,4,3,5,4,1,4,1,3,4,1,3,3,4,3,3,5,2,3,4,4,2,3,1,2,5,4,4,2,2,4,4,1,3,2,1,2,4,4,2,3,2,1,1,3,2,2,1,3,4,4,4,3,3,4,2,1,4,4,2,1,1,2,4,3,4,3,2,3,1,2,5,4,5,3,3,3,1,1,1,1,5,2,5,3,5,4,4,5,3,4,5,5,4,3,4,2,3,2,2,3,2,3,4,3,1,5,5,3,3,4,1,1,1,4,1,3,4,3,4,2,2,2,3,2,2,2,1,3,4,1,1,4,5,4,5,1,1,1,1,3,3,5,5,3,5,4,5,1,1,1,5,3,2,3,4,5,4,5,3,5,2,1,1,3,3,4,2,2,3,2,4,1,4,1,3,5,2,4,4,3,4,1,2,1,4,5,1,5,4,4,3,2,4,4,5,4,5,4,2,1,1,1,4,1,1,4,2,5,3,4,4,4,1,2,3,1,1,3,4,5,1,2,1,5,4,1,2,3,5,5,5,4,2,1,5,2,3,3,5,5,2,3,5,5,2,5,3,4,2,1,2,5,5,5,2,2,5,1,5,2,2,5,4,2,3,1,1,5,3,2,3,4,2,1,2,4,1,1,2,3,1,1,5,1,2,5,2,2,1,4,5,5,1,1,4,2,4,1,4,3,1,3,3,1,4,2,4,1,4,1,4,5,3,1,3,5,1,4,5,2,2,3,3,1,5,5,3,3,1,1,3,3,3,2,3,5,1,3,4,2,4,1,3,2,1,2,1,5,1,1,4,2,3,4,4,4,4,3,3,5,5,3,2,4,2,2,1,3,4,5,3,2,3,1,1,3,5,1,4,4,5,2,1,3,1,4,3,5,1,1,2,1,2,2,4,3,2,4,4,4,5,4,5,5,1,4,4,1,4,5,4,5,2,5,5,1,1,5,2,3,2,4,3,4,3,4,4,3,1,2,1,4,1,1,1,5,3,3,1,1,4,1,2,2,5,1,5,3,2,5,3,3,3,5,1,5,1,3,1,3,1,1,4,1,4,2,5,1,2,2,5,3,2,3,5,4,3,2,4,5,3,2,4,3,5,3,2,4,5,1,3,3,5,4,1,1,4,4,1,5,4,4,3,3,5,4,2,2,4,1,5,3,4,2,4,3,1,5,3,4,4,2,4,3,3,2,2,2,2,2,3,2,5,2,3,4,1,4,1,2,2,3,3,4,1,2,1,2,2,1,2,4,3,5,5,3,4,5,3,3,2,3,1,4,2,1,2,2,2,5,2,1,3,5,4,2,1,3,3,4,2,2,2,2,5,3,5,4,2,1,4,1,5,4,5,1,5,4,3,5,3,5,1,2,1,5,1,1,2,5,1,3,2,3,3,4,1,5,3,1,1,2,1,4,1,1,1,4,4,4,4,3,5,5,2,5,1,4,4,5,4,3,3,2,3,4,4,1,2,1,4,1,3,4,2,4,1,5,3,4,5,5,2,1,5,1,4,4,4,5,2,4,2,4,5,1,4,1,4,4,5,3,3,5,2,5,3,2,5,2,3,3,1,2,5,1,1,2,5,4,4,5,1,5,4,5,3,5,1,4,3,5,1,3,4,2,5,2,1,2,1,3,2,5,1,4,5,4,5,5,2,5,2,1,1,2,3,4,5,3,3,5,1,2,5,5,5,3,4,3,2,4,4,1,1,1,1,2,2,3,2,3,2,1,5,1,2,5,2,2,1,2,4,4,1,1,3,4,2,2,3,4,2,2,5,5,1,2,1,2,5,3,4,2,1,3,1,1,5,2,1,2,3,4,2,4,4,3,4,2,3,1,1,1,2,5,1,3,4,3,5,2,5,5,5,4,4,4,2,5,5,4,1,5,5,4,4,2,4,1,2,3,4,1,3,3,1,5,2,4,2,3,3,5,3,4,1,5,4,1,4,2,4,1,3,1,4,4,2,3,5,5,2,3,4,2,3,4,3,5,5,2,5,5,5,3,4,5,2,5,1,5,5,3,3,1,1,5,4,2,3,5,4,2,1,3,4,2,4,2,5,5,3,5,5,1,5,4,3,5,4,3,1,2,4,4,5,5,5,3,2,5,1,2,1,2,2,2,5,1,4,3,4,3,4,5,4,1,2,2,5,5,1,2,5,4,3,1,4,5,2,3,3,1,2,5,3,1,2,5,4,2,4,1,1,5,3,2,1,5,1,1,5,2,2,2,1,5,1,2,2,5,5,5,5,1,4,1,2,1,5,5,2,4,5,4,4,2,4,5,2,3,1,5,1,2,2,1,1,1,4,2,3,1,2,3,3,4,5,3,3,1,4,5,3,2,4,4,5,2,4,5,3,5,1,2,1,3,4,1,4,1,1,5,2,1,2,3,3,4,2,3,1,2,3,4,2,5,4,4,3,3,4,2,2,1,1,2,5,3,2,5,1,1,5,4,5,2,5,3,1,1,4,4,3,3,4,3,1,5,4,4,1,1,1,3,1,5,1,4,4,4,3,1,3,2,4,3,4,2,1,3,4,3,1,4,4,4,3,5,5,4,1,1,2,3,4,1,3,2,5,2,4,1,3,2,1,1,5,3,5,1,2,5,4,3,3,3,5,5,4,3,4,4,3,2,1,1,3,3,3,3,1,3,4,2,1,5,2,4,4,2,4,3,3,4,5,3,2,4,4,5,4,3,5,3,4,4,2,5,5,1,3,1,5,4,2,1,5,2,4,1,3,2,2,1,2,3,4,2,4,1,4,3,2,1,2,2,5,3,3,4,5,3,2,4,1,3,2,2,3,2,4,2,4,2,4,5,1,1,1,5,3,4,3,5,3,1,5,5,2,2,1,5,4,3,5,1,4,2,2,5,3,5,1,1,4,2,3,1,1,5,1,3,4,2,5,3,4,2,4,2,4,5,2,3,1,1,1,5,2,1,1,1,4,4,2,1,3,1,4,5,3,2,4,1,3,5,5,1,5,2,5,2,3,4,4,3,4,1,4,2,4,4,2,1,1,4,3,3,2,4,4,3,4,1,3,2,5,3,3,4,3,4,5,5,4,4,1,4,1,3,1,5,1,3,3,1,3,2,4,1,5,5,4,2,2,5,4,2,4,4,2,1,2,2,3,5,1,1,4,1,5,3,5,2,3,4,1,1,1,1,1,4,4,5,3,3,4,5,5,5,4,4,5,1,4,2,1,1,5,4,2,4,4,3,5,5,4,4,3,1,3,4,3,2,2,5,5,1,5,2,5,3,2,3,5,3,3,4,4,5,3,4,5,1,1,2,2,4,5,1,4,2,3,2,1,3,4,5,5,4,5,4,2,2,1,3,1,3,2,2,5,4,3,1,5,4,3,4,1,1,5,5,4,5,3,2,4,4,1,1,4,1,4,3,1,1,4,3,2,1,5,4,1,2,2,3,1,4,3,4,2,4,2,2,1,2,4,3,1,3,4,1,2,3,1,5,1,1,5,1,3,1,1,5,2,1,3,4,4,3,1,3,1,4,5,2,4,5,4,2,4,2,4,5,3,2,4,3,3,3,3,2,3,3,4,4,3,1,2,5,5,3,1,5,2,2,1,3,3,4,1,5,2,3,2,5,5,4,4,4,5,3,4,5,2,1,3,1,4,3,3,3,4,3,4,1,2,1,1,2,2,3,4,1,3,2,5,3,4,5,3,5,3,2,1,5,1,3,5,4,3,4,3,1,1,3,2,2,3,4,2,1,5,1,4,3,5,4,2,2,3,3,4,2,3,1,5,3,2,3,4,2,4,4,3,3,4,3,2,2,4,5,3,4,1,2,1,5,5,4,5,1,3,3,3,4,4,3,3,3,4,5,3,5,5,4,1,3,4,1,5,2,1,3,4,3,5,1,4,3,3,4,1,3,2,4,5,4,1,2,3,2,4,2,2,4,5,4,3,3,3,1,2,4,4,1,2,2,1,2,1,4,4,3,3,4,1,4,2,2,5,5,4,3,4,1,5,2,3,2,2,3,3,2,4,4,3,1,4,5,1,4,3,3,5,2,4,3,1,3,3,4,4,2,5,3,2,2,1,3,2,5,1,3,4,5,5,1,1,5,3,2,1,5,5,1,5,4,5,5,2,2,5,1,1,3,2,5,2,2,3,4,3,3,3,4,2,5,4,2,1,3,3,5,1,5,5,5,4,2,4,1,4,4,3,3,3,1,3,3,3,5,5,2,2,5,4,3,5,1,3,1,4,1,4,1,2,2,2,5,3,4,4,2,5,1,2,5,3,4,2,3,3,4,2,5,5,5,3,2,2,1,4,3,5,4,1,2,4,5,3,4,5,3,1,1,3,3,4,2,2,1,4,4,3,4,5,4,1,4,2,3,4,3,3,5,1,3,3,3,5,2,5,4,5,2,5,1,5,1,2,5,2,1,4,2,5,4,2,2,4,5,1,5,5,4,5,3,3,4,4,4,4,1,5,3,2,4,4,1,2,2,2,4,5,2,2,2,3,1,5,4,2,3,1,1,3,1,2,3,1,4,2,4,5,3,2,2,2,5,1,1,3,1,4,4,3,2,2,5,2,5,4,2,3,5,2,5,1,4,3,4,2,3,3,3,5,2,4,5,2,3,1,2,3,2,1,5,4,2,5,5,2,3,4,1,2,1,3,5,3,3,1,4,3,2,2,5,4,1,2,5,4,1,1,2,5,2,1,2,2,4,1,3,3,3,3,1,1,2,1,2,5,3,2,2,1,2,2,2,2,4,1,1,1,5,2,1,1,1,5,2,5,1,2,5,3,4,1,3,1,5,5,1,2,2,1,4,5,4,4,4,1,5,3,5,3,4,1,3,3,2,3,1,2,5,2,1,5,5,1,3,1,3,4,5,1,3,3,3,1,3,5,3,3,5,4,1,1,1,4,2,3,5,1,5,1,4,2,2,1,2,5,3,1,4,5,3,1,5,1,5,4,1,4,1,1,5,3,2,3,3,5,5,4,1,4,1,4,5,4,2,3,4,3,4,1,2,5,4,3,5,1,5,2,3,5,4,2,4,4,3,1,1,2,2,3,3,5,4,4,4,5,2,5,3,3,3,4,3,5,3,4,4,3,3,4,1,5,5,1,2,4,4,3,3,1,1,2,4,2,5,1,2,4,3,3,1,4,3,4,2,4,4,4,1,5,1,4,2,4,5,2,2,4,5,1,5,1,3,1,4,5,5,1,2,2,1,2,2,5,5,3,4,4,2,2,2,1,2,2,3,3,1,4,4,3,4,4,2,1,1,3,5,5,5,4,4,2,1,1,1,5,5,5,2,1,4,3,5,2,5,5,1,4,3,4,1,4,5,3,4,1,1,2,4,5,1,2,5,4,1,5,2,1,2,2,1,3,5,2,3,1,5,5,5,4,4,3,1,4,1,1,1,5,5,3,4,2,3,5,5,3,3,5,2,5,4,4,3,5,4,4,1,2,1,1,1,3,3,1,5,4,4,5,1,1,3,5,1,5,2,5,5,4,3,4,3,4,2,5,3,1,3,5,3,4,1,1,1,2,4,3,5,1,4,3,1,4,1,3,5,3,4,3,2,4,5,3,5,1,5,1,2,4,4,3,2,1,2,2,3,1,1,5,4,3,3,2,4,3,5,4,5,1,5,2,2,5,5,4,4,4,1,3,1,1,1,1,1,2,3,1,3,4,1,1,3,1,4,2,1,3,1,1,3,4,4,1,4,5,2,2,2,2,4,1,4,2,5,3,1,5,3,4,5,3,4,3,1,3,4,5,5,1,3,3,2,1,5,2,2,4,4,1,3,1,5,3,5,2,4,3,1,3,5,2,4,3,2,4,5,2,5,3,3,2,1,2,5,4,2,1,3,4,1,4,2,2,3,2,5,2,3,2,2,3,2,1,3,4,4,3,2,3,4,4,5,2,1,3,1,5,2,3,4,1,1,5,3,3,3,3,2,3,3,5,4,5,1,3,1,2,2,2,5,1,5,5,2,2,2,4,4,4,3,5,5,1,4,1,3,4,1,1,4,1,4,4,1,4,1,3,5,3,3,2,4,3,1,4,4,3,4,3,5,4,4,3,3,4,1,1,4,5,1,2,2,4,2,4,1,2,2,4,2,5,5,4,2,2,3,3,4,2,5,4,2,5,2,4,2,3,4,2,4,3,3,3,1,5,4,2,4,5,5,3,3,4,1,4,5,2,4,5,4,4,5,5,4,2,4,4,5,5,3,3,2,2,5,4,3,4,1,2,4,4,1,3,5,1,1,2,4,3,1,1,2,5,4,3,2,1,1,3,5,5,2,1,5,4,2,5,4,3,4,3,3,5,1,3,3,5,2,4,3,1,2,2,4,2,5,5,1,2,3,2,5,5,5,3,3,4,4,1,4,5,4,1,5,3,2,5,5,5,2,2,3,2,2,5,3,5,2,3,2,2,2,1,3,3,3,1,4,2,2,3,5,3,3,4,5,1,1,2,3,3,5,5,5,3,1,4,3,5,2,4,5,2,3,3,3,5,3,4,5,3,1,5,2,1,1,5,5,4,1,3,4,5,2,4,5,5,4,5,5,2,4,5,5,2,1,4,5,5,2,3,5,1,2,5,4,3,2,2,2,5,2,3,4,2,5,1,1,5,4,2,3,1,2,4,1,5,5,5,4,4,1,5,4,3,5,1,3,5,4,4,2,5,4,3,3,5,3,3,4,1,3,5,2,3,5,4,4,3,1,3,3,3,2,3,2,5,3,3,1,2,3,1,1,4,4,1,3,3,1,2,3,1,1,5,1,1,3,4,4,2,5,1,1,2,2,5,2,4,1,2,5,1,4,4,3,4,1,4,3,3,5,4,4,2,3,3,5,5,4,4,3,5,4,3,1,2,5,1,3,4,5,5,3,1,3,5,5,1,5,2,4,2,4,1,2,3,1,1,3,1,3,4,2,2,3,2,4,4,5,4,3,4,3,2,1,2,5,1,5,5,3,2,2,1,4,1,3,1,3,3,3,3,4,4,3,1,3,3,2,4,5,1,3,5,3,2,5,5,1,4,3,4,3,4,3,2,3,2,3,2,3,1,1,1,4,4,2,4,3,4,5,4,1,2,3,3,4,3,3,1,4,5,4,2,3,3,2,2,3,4,5,2,1,3,3,1,3,3,2,4,4,2,3,2,3,4,1,2,5,1,4,1,1,2,5,5,5,4,5,3,4,5,2,3,4,2,1,1,5,1,5,4,5,1,3,1,1,3,1,4,2,4,3,1,4,3,1,4,4,3,5,5,3,3,3,5,5,4,1,1,3,2,3,1,5,4,2,1,2,2,5,4,2,5,3,5,4,5,2,1,3,1,5,4,5,2,3,2,1,1,4,1,3,2,1,2,2,2,5,3,4,2,4,2,3,1,2,3,2,2,3,5,1,3,4,3,3,2,1,3,5,2,1,4,2,1,5,2,3,1,5,4,4,3,1,4,4,3,5,4,1,4,4,5,4,4,1,4,1,2,3,5,5,5,2,4,2,4,5,5,5,4,4,5,4,2,5,1,5,2,1,3,1,1,3,1,3,1,3,3,1,3,4,4,3,4,4,4,4,5,1,2,3,5,2,2,2,3,1,4,2,3,1,3,5,5,1,5,3,3,3,2,4,5,3,1,1,3,5,2,4,1,5,5,4,5,4,5,3,3,1,4,5,1,2,5,3,5,5,4,2,1,1,3,4,4,1,2,4,5,4,3,1,2,5,5,3,1,2,2,2,2,5,5,3,2,4,4,2,3,3,2,2,5,4,5,1,3,3,2,1,2,4,3,4,1,3,5,3,5,1,2,5,4,2,1,1,4,2,2,4,1,3,4,5,3,4,2,4,1,3,3,2,1,5,2,2,2,2,1,1,1,1,2,2,1,2,3,5,1,3,5,2,4,4,2,2,5,3,2,4,2,4,3,2,1,5,1,2,3,4,4,3,5,4,4,2,3,2,5,5,3,1,5,3,1,3,3,2,4,3,5,5,4,2,3,1,4,3,5,5,3,1,2,2,2,3,1,1,3,3,2,3,3,1,2,3,1,2,1,4,4,1,4,2,2,3,5,5,5,2,2,1,2,3,2,5,2,2,2,5,1,4,5,3,1,1,1,5,5,2,5,4,2,2,2,4,3,4,1,1,2,2,5,3,3,1,4,1,4,2,1,2,5,1,1,2,1,3,1,3,3,1,5,3,2,2,5,5,3,5,3,1,3,1,2,2,5,4,4,5,2,4,5,5,4,4,2,4,5,1,5,1,4,2,2,1,3,3,2,2,4,3,3,1,4,4,1,2,2,1,1,4,1,1,1,1,3,3,5,1,3,2,3,3,2,1,4,1,3,4,1,4,1,2,2,4,5,1,2,2,3,4,3,4,2,3,1,2,3,1,2,4,2,2,3,3,3,4,4,5,5,2,1,3,3,3,3,1,2,1,5,1,4,3,4,1,3,4,4,1,3,2,4,4,2,5,4,1,4,4,2,5,2,4,3,1,4,4,2,5,4,2,5,1,3,1,5,1,4,4,4,3,1,5,5,5,1,3,5,1,4,5,5,1,3,3,3,1,5,2,2,2,4,5,3,1,3,2,2,5,2,3,3,3,4,5,1,3,2,2,1,2,4,3,5,2,4,5,4,5,4,5,4,1,2,4,5,4,2,2,1,2,2,2,5,4,5,5,5,2,2,2,1,3,2,4,5,4,5,5,2,4,5,3,2,1,4,3,2,2,4,4,3,1,4,5,5,1,5,5,2,2,4,1,4,2,5,3,2,1,5,1,5,4,3,5,3,1,4,5,4,3,1,3,4,5,1,4,1,1,4,4,4,2,2,4,3,2,4,3,2,3,1,3,1,1,2,4,1,5,2,2,3,3,5,2,1,1,1,1,3,5,3,3,1,1,2,3,3,5,2,4,2,1,5,4,2,2,1,5,5,5,3,3,2,5,2,4,3,2,2,4,2,3,3,2,1,2,4,5,2,4,4,4,4,3,5,4,1,1,5,2,2,1,2,4,5,2,4,4,5,5,3,2,5,3,4,2,3,4,2,2,3,3,1,3,2,3,1,4,3,2,1,3,4,5,4,4,3,4,5,1,4,4,3,2,4,3,2,2,3,4,3,2,1,3,5,4,1,3,5,3,3,2,3,4,5,4,3,1,3,1,3,1,5,2,4,3,4,5,1,5,5,2,5,3,4,1,3,2,5,3,2,4,4,5,5,1,5,2,5,1,5,4,5,4,1,1,2,3,4,1,2,4,2,5,4,1,1,1,1,4,5,1,1,3,2,4,1,2,5,1,4,3,2,5,5,3,3,4,4,5,4,2,3,4,2,4,5,2,4,4,4,4,5,3,4,4,2,2,3,1,1,3,1,4,3,4,2,2,5,3,5,5,3,1,4,5,2,2,4,5,1,3,4,2,3,2,5,1,2,1,4,2,5,3,4,3,2,2,1,2,2,4,1,5,4,4,3,2,2,5,5,5,5,1,3,2,3,1,2,5,5,4,5,1,2,5,5,4,4,5,4,5,4,5,4,2,1,2,1,1,5,4,4,5,4,4,2,4,4,2,5,2,5,2,1,4,2,5,5,4,3,2,1,5,2,2,3,1,3,3,5,2,5,2,4,3,1,3,1,5,3,2,5,1,4,1,3,4,4,2,3,3,1,2,1,1,5,3,1,2,4,5,2,3,5,5,2,5,5,4,3,2,1,3,1,1,5,1,4,5,1,1,4,1,5,5,1,3,2,1,1,5,2,3,2,4,1,2,5,2,3,3,5,2,1,3,5,2,2,5,2,3,2,3,3,5,1,1,1,2,1,1,3,3,1,5,3,4,2,5,3,1,1,1,4,1,3,1,3,4,3,2,4,4,3,3,3,1,1,4,1,2,3,2,1,5,2,5,2,3,5,1,5,4,4,3,1,2,4,2,2,1,3,1,3,2,2,4,4,1,3,2,1,1,4,2,2,1,5,2,1,1,2,4,5,2,5,3,4,2,3,2,5,4,3,3,2,2,1,5,4,2,2,3,3,3,3,4,2,1,4,4,1,4,4,4,4,1,1,1,3,4,3,2,2,4,2,4,1,1,2,4,4,2,4,2,4,4,2,1,4,1,4,1,1,1,2,2,4,3,2,4,5,2,1,3,1,5,4,1,2,3,2,2,3,2,3,3,3,3,2,3,1,4,3,1,5,1,1,2,3,3,5,5,2,1,3,2,3,3,1,4,2,4,2,1,2,5,4,4,4,4,3,3,5,4,1,2,1,1,5,4,5,5,3,5,2,3,3,3,5,3,4,4,2,1,5,5,5,5,2,1,3,5,4,1,5,1,4,1,4,1,5,3,2,2,5,2,5,4,3,4,2,1,5,1,2,2,1,2,3,3,4,4,1,2,4,5,4,4,4,3,2,5,5,3,4,5,2,2,1,1,4,2,2,4,4,2,3,3,1,4,1,5,1,1,1,1,2,3,1,5,5,5,4,3,4,2,2,5,3,2,5,5,5,5,4,1,1,3,2,1,2,5,2,3,4,3,4,1,4,3,2,4,3,5,1,5,2,1,2,1,5,2,4,1,1,1,3,5,1,2,2,3,5,5,3,2,5,5,1,3,4,2,2,5,4,3,4,4,5,4,4,3,5,2,1,1,2,5,5,5,5,2,2,5,3,3,3,5,5,2,3,2,1,1,5,3,2,4,4,3,5,1,1,1,2,3,5,1,5,2,2,4,1,3,4,5,3,1,1,4,3,4,1,1,4,1,5,2,3,5,4,4,1,2,2,3,4,3,2,3,5,4,2,4,3,5,4,1,4,5,4,3,1,2,1,4,5,1,2,1,5,5,3,1,1,4,3,4,1,3,2,2,5,5,2,1,3,2,4,3,5,1,3,1,1,1,5,5,4,3,5,5,5,2,5,4,2,1,3,2,2,1,3,5,1,4,3,3,4,4,1,2,4,3,5,1,5,5,3,1,1,1,4,2,4,1,3,5,5,3,1,4,3,5,2,4,4,3,2,2,3,2,5,5,4,2,3,1,5,5,3,2,4,2,5,4,3,3,2,4,5,4,3,2,3,2,4,5,1,1,4,5,5,1,4,1,2,3,4,3,4,2,3,5,2,5,3,1,4,3,5,1,1,5,3,5,1,1,1,5,4,3,4,1,3,1,3,3,4,1,1,1,4,1,3,2,4,4,4,5,1,5,4,4,2,1,1,3,4,1,5,2,4,1,3,2,3,2,3,2,2,2,3,5,5,4,3,5,2,2,4,2,1,2,3,5,2,1,1,2,2,1,5,1,5,5,5,2,1,4,2,5,1,3,3,4,3,1,5,2,2,4,3,4,1,3,1,4,3,1,3,1,3,3,5,3,1,3,2,2,2,4,4,4,2,2,1,4,4,2,5,4,1,4,4,4,1,3,1,5,2,5,2,1,4,5,3,2,2,5,3,4,4,2,2,5,3,2,3,2,2,3,4,4,2,1,5,4,2,2,1,3,1,4,3,4,3,5,4,5,3,5,1,2,5,1,5,3,4,2,3,1,3,4,4,1,3,5,4,5,1,2,2,1,2,4,3,4,2,3,1,3,1,4,5,5,4,4,3,5,3,1,3,4,3,4,2,4,5,4,2,3,2,4,1,4,1,4,3,3,4,2,1,2,2,1,4,4,3,3,1,3,3,1,1,1,1,2,5,2,3,5,4,5,4,3,2,2,3,2,4,5,4,2,5,3,5,3,2,3,1,2,1,3,2,3,2,3,2,3,3,2,2,4,2,5,1,1,3,4,1,2,1,5,4,5,5,4,4,5,2,5,2,4,3,5,3,3,3,5,5,5,3,4,4,2,4,4,4,3,2,3,5,3,4,1,3,2,3,5,4,1,1,4,1,5,2,2,5,5,4,1,1,5,5,4,1,1,5,5,3,1,3,4,2,3,1,5,4,5,4,1,5,2,3,5,2,3,1,2,3,2,5,3,3,5,4,3,4,1,4,5,1,3,4,2,5,4,3,1,4,1,5,1,1,2,1,2,1,1,5,5,3,3,3,2,5,3,4,3,4,5,4,2,2,5,5,1,4,5,4,1,1,1,1,5,3,3,3,5,1,2,1,5,4,1,4,4,4,5,5,2,4,3,2,1,5,2,4,5,5,1,5,2,1,2,1,1,2,1,4,4,3,5,1,1,2,5,5,1,4,2,1,5,1,1,3,4,3,3,4,1,4,3,2,4,2,3,4,4,4,5,5,3,5,1,2,4,3,2,1,4,1,1,5,3,1,5,4,1,4,1,1,4,1,2,1,2,1,1,1,1,3,3,4,1,2,5,3,2,5,5,3,3,3,4,2,1,1,4,5,4,3,3,1,5,3,2,4,5,5,3,1,4,5,4,2,1,5,5,3,4,4,2,1,3,5,1,2,3,2,1,4,1,5,5,1,3,5,4,2,3,4,4,3,3,1,1,2,4,4,4,4,1,5,1,4,5,4,3,2,1,1,2,2,4,2,5,4,2,5,2,5,1,3,2,2,3,1,3,5,1,2,5,5,5,2,5,3,4,4,5,5,5,4,3,4,4,2,2,4,5,2,2,1,2,5,5,1,1,4,5,5,3,5,4,5,5,2,5,3,2,3,2,5,2,1,5,2,2,1,5,2,1,1,5,3,2,5,2,3,5,5,2,4,3,4,3,4,4,5,3,3,1,1,3,4,1,1,4,1,3,3,3,4,1,2,2,3,3,5,2,5,4,5,5,4,1,4,5,2,4,4,4,5,3,1,4,5,1,2,2,5,3,4,1,5,3,1,2,2,3,4,2,3,4,1,4,5,2,3,2,1,3,1,3,4,4,2,4,5,3,1,4,3,5,5,4,2,3,4,5,4,1,2,2,5,3,4,2,2,2,2,3,4,2,5,1,1,5,5,1,2,4,2,3,1,2,4,2,5,1,5,2,5,4,3,3,5,4,1,4,2,1,3,1,5,2,2,3,4,3,2,1,1,4,4,1,3,4,4,3,5,5,2,3,2,2,3,2,2,2,4,4,5,4,1,5,4,2,5,3,4,4,4,4,3,1,2,1,2,4,1,3,2,2,4,3,3,3,2,3,3,1,1,1,3,4,1,4,5,2,3,4,2,5,1,3,1,4,2,5,4,5,3,1,4,1,4,5,4,4,3,2,1,5,1,4,2,5,3,5,3,2,4,3,3,2,3,2,3,5,4,4,3,4,3,4,2,1,2,1,3,1,2,5,5,3,3,2,5,2,1,5,1,2,5,4,4,2,3,4,2,2,5,2,3,1,3,4,4,3,5,4,5,3,4,2,3,3,3,1,1,2,2,3,5,5,5,1,3,3,1,1,2,5,4,5,4,1,5,4,3,2,4,4,3,3,5,5,1,5,4,5,5,4,3,1,3,4,5,5,3,3,2,1,5,5,4,4,4,2,2,2,2,3,2,4,2,3,1,1,1,2,2,5,1,4,5,1,3,5,3,4,2,2,3,2,4,3,1,5,4,3,5,2,1,1,4,5,4,1,1,2,3,4,3,2,4,3,4,4,2,4,1,5,2,5,5,1,2,1,4,1,4,1,2,3,4,3,2,2,3,4,1,3,2,5,5,4,2,1,5,2,2,1,4,3,3,3,5,5,4,1,1,1,2,5,5,5,2,1,1,3,2,3,4,3,2,2,1,1,3,3,3,2,2,1,1,4,5,5,1,3,4,5,5,3,5,4,5,2,2,1,5,1,1,5,2,4,2,4,1,2,4,3,5,5,3,4,1,5,4,2,3,2,1,1,2,5,2,5,4,5,2,1,2,3,2,5,4,2,5,1,3,3,1,4,2,4,4,2,5,4,5,2,1,3,5,4,5,4,5,1,5,2,2,1,2,4,1,4,2,1,2,1,5,1,3,5,3,5,5,4,1,5,1,2,1,2,1,1,1,2,5,4,5,2,3,1,5,2,5,3,3,1,2,4,4,3,4,1,3,1,3,3,5,1,4,5,4,2,3,4,1,5,2,5,3,1,2,4,2,1,3,1,2,1,4,1,1,5,5,3,3,5,5,3,5,1,2,2,2,1,4,2,2,1,1,5,1,2,1,1,1,3,3,4,4,4,2,2,1,4,4,1,3,3,2,3,4,4,2,4,4,3,4,4,4,2,5,5,3,1,5,4,5,5,2,4,2,5,2,4,3,2,1,4,1,2,3,5,1,1,5,4,2,4,1,2,3,1,5,1,5,2,4,1,2,5,3,4,1,4,4,1,2,4,3,4,5,4,1,1,3,3,5,3,3,5,1,5,3,5,4,2,1,2,1,1,2,3,5,4,3,5,4,1,1,2,4,1,2,1,4,2,3,5,3,1,1,5,1,3,1,3,5,4,4,1,5,1,3,5,2,4,1,1,4,2,3,4,4,5,4,4,4,3,2,4,3,5,1,1,2,4,1,2,1,1,2,3,5,3,4,3,3,5,2,2,4,4,4,3,2,2,3,3,3,2,5,5,1,2,4,4,1,4,5,3,3,3,1,3,2,1,1,3,3,4,3,5,1,4,4,4,3,3,2,4,5,1,3,4,1,1,3,1,5,1,3,1,1,3,1,4,5,5,5,2,3,5,5,1,3,5,3,2,1,1,2,4,4,5,2,3,5,1,4,3,2,1,1,1,4,3,1,1,5,3,4,5,2,3,2,2,1,3,4,5,3,5,5,4,2,5,5,1,1,5,5,5,2,1,5,5,1,1,3,1,4,4,2,4,4,2,5,4,1,5,2,3,1,1,1,1,3,4,4,5,5,2,5,1,2,5,5,5,4,1,1,4,2,3,4,3,4,2,5,5,1,3,1,1,2,1,4,2,5,2,4,5,4,4,3,4,4,3,5,5,1,1,2,3,4,2,5,4,2,5,5,2,2,2,4,2,4,1,3,5,5,5,1,1,2,4,2,1,1,5,3,4,1,1,5,4,2,4,4,4,4,4,2,3,3,2,1,3,4,2,4,1,2,5,4,2,2,5,2,4,5,1,3,1,4,4,3,3,3,3,5,2,2,1,2,1,4,5,2,4,1,2,4,4,1,1,1,2,2,3,4,2,4,4,2,3,1,4,1,5,1,3,2,1,4,5,3,2,5,3,4,3,3,1,5,4,5,2,5,1,1,2,2,1,1,1,3,1,3,1,2,1,5,1,5,5,3,5,1,2,1,5,1,4,1,3,5,4,2,4,1,2,3,2,4,3,4,2,2,4,4,1,5,2,3,3,2,3,4,3,2,5,5,1,5,2,3,1,5,5,5,1,5,2,1,3,5,1,4,5,4,5,3,5,5,5,3,5,2,5,2,2,4,3,5,4,5,1,5,5,5,5,2,3,3,5,3,4,2,4,4,1,3,4,4,5,5,2,4,1,2,4,4,5,5,2,2,3,4,4,2,5,1,2,4,5,3,5,1,5,5,5,2,5,1,1,5,5,4,4,3,1,1,5,5,2,2,3,5,2,3,5,5,4,1,3,2,3,1,3,1,5,3,2,3,1,1,1,1,2,4,5,1,5,4,3,5,5,1,5,3,2,5,2,1,4,1,2,4,1,3,3,2,3,4,1,1,5,4,1,5,4,5,3,1,2,5,5,5,1,1,1,4,3,1,5,1,1,2,2,4,3,4,3,1,2,4,4,5,1,4,4,2,4,3,4,4,5,3,5,1,3,4,4,3,4,2,4,3,5,5,2,1,1,2,4,5,2,2,1,3,5,4,3,4,4,5,3,1,5,5,2,4,4,5,5,3,2,2,2,4,4,4,3,3,3,4,1,5,2,3,3,5,3,2,2,2,5,5,5,4,2,3,5,2,1,2,5,1,2,1,3,5,2,5,2,4,3,2,2,3,2,4,3,4,4,2,1,3,5,3,5,5,5,1,3,2,1,5,3,3,1,4,3,5,5,1,3,5,2,1,3,4,1,1,1,2,4,4,4,5,1,5,4,5,1,5,4,1,5,4,3,2,2,5,2,2,5,5,2,4,3,1,4,3,3,5,1,3,5,2,2,4,3,2,1,5,3,1,2,2,1,5,2,3,1,5,5,4,1,1,5,4,1,2,3,5,2,4,2,5,1,2,1,4,2,5,2,1,5,4,1,5,4,2,1,4,2,5,3,5,4,5,3,5,1,1,2,5,1,1,5,2,5,1,4,4,1,4,4,3,1,3,5,4,2,1,3,5,1,5,4,3,5,5,5,1,5,1,1,2,4,2,5,1,1,1,2,3,2,1,5,5,1,3,5,2,3,4,1,5,3,1,1,4,2,2,3,2,4,4,4,1,2,5,1,3,1,4,5,3,2,2,5,5,2,2,3,1,3,3,5,4,3,4,3,3,1,4,3,4,4,4,5,5,3,2,1,4,5,3,5,3,2,5,5,5,2,5,2,1,2,2,5,3,1,4,4,4,1,4,1,5,2,2,3,4,3,1,2,4,4,3,2,3,2,1,4,5,2,5,5,3,3,4,2,3,4,2,1,5,5,4,1,1,2,5,1,2,5,3,4,1,1,2,5,5,2,4,5,5,2,5,4,3,4,5,2,5,5,1,5,2,2,3,4,4,4,3,5,3,5,1,4,1,4,3,3,4,2,2,4,2,2,3,2,4,2,5,2,5,2,2,2,4,4,1,4,1,1,2,3,2,5,2,2,1,1,5,3,1,4,2,1,2,3,3,2,3,3,2,5,1,1,3,3,4,1,1,1,5,3,3,3,1,3,2,3,5,1,2,4,4,4,1,3,5,3,5,4,5,2,2,1,4,2,5,4,2,4,3,1,2,1,5,1,1,3,4,5,1,5,4,1,3,3,3,1,4,2,5,4,5,4,5,4,4,2,5,3,5,1,5,2,3,4,4,1,5,2,1,1,2,2,5,3,4,1,1,2,2,3,4,2,4,5,2,1,5,4,3,5,2,1,2,1,2,4,5,5,3,4,3,5,2,4,4,3,4,5,4,3,3,3,3,1,2,5,2,1,5,1,5,4,3,1,3,4,2,2,4,5,2,1,1,1,3,1,3,1,4,3,5,1,4,5,3,3,4,1,2,5,5,2,2,5,3,5,5,2,5,4,4,3,4,2,1,3,1,3,4,1,4,5,5,4,5,1,1,3,4,2,2,3,3,4,3,2,3,4,1,5,5,4,3,5,1,4,3,1,2,3,4,5,5,3,3,2,2,5,4,3,2,3,1,4,1,2,4,1,5,1,4,5,4,3,4,4,2,3,2,3,4,1,1,3,3,3,5,1,5,1,3,1,3,3,4,5,4,2,1,2,3,5,1,2,3,4,3,4,2,4,3,3,4,1,2,1,1,3,5,5,4,2,5,3,1,3,4,4,3,1,5,5,2,5,5,5,5,1,1,2,1,3,4,5,5,2,1,5,1,4,1,1,1,5,4,1,3,1,5,5,5,2,4,5,2,3,3,5,1,3,4,4,4,3,4,1,3,4,2,2,5,2,4,4,2,4,4,2,2,5,3,1,5,5,2,2,4,2,5,3,2,5,4,3,1,4,4,5,2,3,2,2,2,3,4,5,5,2,5,3,5,4,5,5,3,3,3,4,2,3,2,4,4,1,3,4,3,3,3,5,1,1,4,3,4,1,1,5,3,3,2,4,1,2,3,2,2,1,2,1,5,4,5,2,5,3,4,3,3,3,1,4,3,1,3,4,2,5,1,5,4,2,5,2,2,3,3,5,3,4,3,3,3,1,3,1,1,2,4,3,3,2,1,3,1,3,3,3,4,5,4,3,3,2,4,4,5,5,2,4,1,2,4,1,5,5,2,5,1,5,2,2,4,5,3,3,3,5,3,4,4,4,3,5,1,1,5,3,1,4,5,4,2,5,1,4,1,5,3,3,3,2,3,5,4,4,5,3,4,2,3,3,3,4,1,1,1,5,4,3,4,4,3,3,4,2,3,1,5,5,4,2,1,4,1,1,5,1,3,3,2,5,2,4,5,2,5,1,3,3,4,3,4,2,4,5,4,3,4,1,4,5,5,2,3,2,1,1,3,5,5,2,2,4,1,5,3,1,2,4,1,5,3,2,5,1,2,2,4,1,2,5,5,2,2,2,3,3,3,5,3,1,2,5,3,4,3,4,5,3,1,2,1,2,3,5,4,1,3,1,3,2,1,1,5,4,3,3,3,4,4,4,3,2,3,4,5,1,3,1,3,3,3,5,1,2,4,2,2,2,5,2,5,2,5,4,4,5,4,3,4,1,5,1,4,3,2,3,1,5,4,2,1,4,5,4,5,4,1,5,3,2,5,2,2,2,3,4,4,2,5,4,3,2,4,2,4,1,2,5,4,5,2,1,4,5,4,1,1,4,3,2,4,1,3,2,5,5,4,5,4,1,3,3,2,5,1,4,3,5,1,4,3,4,1,4,5,5,2,5,3,5,5,5,3,2,1,4,3,3,5,1,2,5,1,1,1,1,2,5,1,4,5,2,5,5,3,1,3,1,3,2,1,2,4,2,5,2,2,3,4,5,3,4,1,1,5,3,1,5,1,3,3,2,1,2,4,4,1,4,3,5,3,1,4,2,5,4,5,5,2,1,5,4,5,2,5,2,1,1,2,1,5,3,3,4,2,1,5,2,4,5,1,1,4,5,1,4,2,3,4,1,5,2,3,5,3,1,5,5,2,4,3,1,2,4,3,3,1,4,1,1,2,1,5,1,4,4,2,4,2,1,3,5,4,3,5,4,4,4,2,1,4,3,3,5,1,3,2,1,5,2,1,4,3,2,5,4,2,1,3,2,2,3,3,2,3,2,2,4,2,3,2,5,5,4,4,4,4,3,1,1,3,2,1,1,5,5,5,3,2,3,2,3,3,5,1,4,2,5,2,4,1,4,3,2,1,1,1,5,3,3,3,2,2,3,1,2,1,1,5,3,5,1,5,2,3,5,1,1,3,5,5,3,1,3,1,3,1,1,4,1,1,5,2,4,4,4,4,2,4,4,2,5,2,5,5,3,3,2,4,3,2,2,4,3,2,1,2,5,3,2,2,2,3,4,1,1,3,1,5,2,1,1,4,1,1,3,4,5,3,4,2,1,1,3,5,2,5,2,1,1,1,1,3,1,5,3,1,1,5,2,3,1,2,2,3,4,4,2,1,4,4,4,2,4,3,1,4,2,4,1,3,5,3,4,4,4,1,2,3,2,3,3,1,5,1,2,2,2,5,5,3,5,4,5,2,1,3,3,5,5,4,5,2,2,4,1,1,1,1,5,2,3,4,4,2,4,2,5,1,3,2,3,3,2,5,1,3,2,2,2,1,1,2,2,2,3,4,5,2,2,4,5,3,3,1,3,2,3,2,2,3,2,1,3,5,3,1,3,2,3,1,1,1,2,2,4,4,2,1,5,5,5,2,3,3,3,2,4,5,5,2,2,1,4,5,5,2,1,5,5,1,3,1,2,4,3,4,4,4,4,3,1,5,2,5,1,5,3,5,1,4,4,2,3,1,2,1,1,4,4,1,3,5,1,4,4,3,5,4,3,5,1,1,3,5,3,4,2,5,1,5,3,3,1,5,1,5,2,2,3,1,5,2,3,5,4,2,1,2,4,3,2,3,2,3,2,5,3,4,4,1,2,5,1,2,2,2,5,3,3,2,2,1,3,4,1,2,4,2,3,3,4,1,1,2,5,4,1,2,4,3,2,2,3,4,3,2,2,3,3,1,4,5,5,3,4,5,5,1,5,1,3,1,2,2,1,4,2,4,4,4,3,4,2,2,3,2,2,3,3,5,5,5,3,2,2,1,2,3,1,4,2,3,1,1,3,4,2,4,2,5,4,3,2,3,2,1,1,2,5,4,3,4,2,5,2,5,2,3,1,5,1,3,5,2,2,1,1,5,1,5,2,1,1,4,4,1,5,5,1,4,1,1,4,1,2,2,5,4,5,5,2,1,4,4,3,5,3,1,1,3,1,1,4,5,4,1,4,1,1,4,4,2,1,2,4,1,5,3,5,5,5,5,3,1,4,4,4,2,4,1,4,2,3,1,2,1,1,1,3,3,4,5,3,5,3,4,4,4,2,4,4,4,2,1,3,5,2,2,4,5,1,4,4,1,1,5,5,3,3,5,2,5,1,2,2,4,4,2,2,2,3,2,4,1,5,4,2,3,1,5,4,1,2,2,5,1,4,2,4,5,1,3,3,5,4,5,3,5,3,2,2,1,5,3,5,4,2,2,1,2,4,4,2,5,4,4,4,1,4,1,5,1,3,5,3,1,4,4,4,5,4,5,3,1,2,2,4,2,2,3,4,5,3,5,1,4,2,3,5,1,1,3,3,1,1,5,1,2,2,1,3,3,1,5,1,4,5,3,4,1,2,4,3,4,5,3,5,1,3,4,1,2,2,2,3,4,5,1,2,2,3,5,2,4,2,4,2,4,2,1,1,4,5,4,4,3,5,3,5,4,1,1,2,2,4,4,1,4,1,3,3,1,1,3,1,1,3,4,2,4,2,5,1,3,3,2,5,2,5,5,3,4,2,2,3,5,3,1,2,1,4,4,4,3,5,2,1,2,4,2,2,2,4,3,4,3,5,3,3,5,4,5,3,2,3,4,3,2,4,2,4,1,3,3,1,5,5,2,2,3,4,2,3,4,5,5,1,5,4,2,4,1,1,3,2,1,2,2,2,2,2,3,3,2,3,1,3,3,3,1,3,4,3,2,3,4,2,2,1,2,2,5,2,1,2,5,5,4,5,3,1,4,1,5,4,4,4,1,2,5,3,2,4,5,4,1,4,3,5,5,3,1,1,4,2,3,1,3,5,1,2,2,5,2,2,5,5,5,4,4,1,3,5,3,2,5,3,5,4,4,1,3,4,4,1,4,2,3,4,3,1,3,1,1,4,3,5,1,1,5,4,4,4,5,1,5,1,1,1,1,5,1,2,1,5,4,4,2,4,5,1,5,5,3,5,1,2,4,5,1,3,1,2,4,1,5,3,2,1,1,1,1,3,1,1,2,5,3,3,1,3,4,2,5,5,3,3,5,1,1,2,4,5,5,5,3,2,1,3,1,5,3,3,3,3,5,2,3,4,5,2,5,5,4,5,2,2,2,1,1,2,2,3,2,2,2,2,4,1,4,2,1,1,2,5,5,1,5,5,3,5,5,3,3,4,4,2,4,4,2,1,2,5,1,1,2,2,2,4,4,4,1,4,3,4,2,3,2,5,1,4,4,5,3,3,3,1,4,1,5,4,4,2,2,1,3,1,3,2,4,5,2,4,2,3,3,5,3,3,1,4,2,5,3,5,1,4,5,1,3,1,5,5,5,3,2,5,1,5,4,5,2,5,4,5,4,5,2,5,5,2,1,2,4,5,3,1,2,1,2,2,3,2,5,4,1,4,5,2,2,1,5,4,2,4,3,2,2,1,5,1,1,1,5,5,5,5,5,3,3,5,3,4,3,1,5,2,5,5,1,1,3,3,4,5,4,5,3,3,5,1,3,4,3,5,2,5,2,2,5,5,1,1,4,2,4,4,3,1,2,1,2,3,5,5,2,3,4,2,3,4,3,5,1,4,3,4,5,4,2,1,1,2,2,1,3,3,2,5,5,3,4,3,3,4,4,5,5,2,3,4,3,3,4,4,1,3,2,5,5,3,3,3,1,3,2,1,2,1,4,4,3,1,2,2,2,3,1,3,1,5,2,4,3,4,2,5,3,1,4,1,2,3,2,3,1,2,2,1,1,2,4,1,5,2,2,2,4,3,1,2,1,2,1,1,5,4,2,1,2,2,4,5,2,4,2,4,3,2,3,2,1,4,3,1,3,2,4,4,1,3,5,4,3,5,3,2,4,4,2,3,1,1,4,2,2,1,3,5,4,5,5,4,3,2,5,5,3,3,4,5,2,1,4,5,3,3,1,1,4,2,2,1,2,2,2,3,2,1,3,3,3,1,4,4,1,2,3,3,4,5,1,2,2,5,2,3,4,4,3,4,3,4,1,5,2,2,5,2,4,3,2,4,3,4,3,5,1,2,5,3,2,1,1,1,4,4,2,1,5,3,4,1,3,1,5,1,1,1,2,2,4,1,5,1,2,2,2,4,2,5,3,1,2,4,1,4,2,1,4,4,1,4,2,4,2,3,2,1,2,4,3,5,1,5,5,2,2,4,5,2,1,1,4,1,3,2,3,4,5,2,5,5,2,2,1,4,1,1,1,4,3,2,4,1,2,4,1,3,1,2,4,4,5,3,1,4,1,3,3,1,1,2,1,3,4,3,1,2,2,1,4,2,3,3,1,3,5,1,4,3,5,1,1,5,3,1,4,4,2,2,2,1,5,2,1,1,2,1,2,2,2,2,2,4,4,1,5,5,1,3,4,5,1,5,3,3,4,4,1,4,4,5,5,1,3,1,2,4,2,2,5,1,3,2,3,2,5,4,3,1,4,3,3,3,1,4,4,4,5,1,1,4,4,1,2,1,5,1,1,5,1,2,5,5,5,4,5,4,4,5,3,1,4,2,1,1,5,2,2,5,4,3,1,3,2,3,3,1,2,1,3,1,4,5,4,3,5,2,2,5,2,3,1,2,4,2,2,3,1,2,5,1,1,4,3,5,1,2,3,4,4,1,1,1,2,1,5,3,5,1,4,5,1,5,3,1,4,1,5,2,2,1,2,1,3,3,3,3,3,1,2,2,1,2,2,3,3,3,3,4,4,2,5,4,1,4,2,4,2,2,5,4,2,1,2,1,4,1,2,4,2,2,2,4,2,2,5,3,1,5,3,3,4,4,4,5,3,3,3,1,4,4,1,4,2,5,5,1,4,5,5,4,4,2,2,5,1,4,4,5,4,5,4,4,4,4,5,5,4,3,3,4,2,3,1,1,2,1,4,3,5,1,3,1,5,5,4,3,5,4,1,3,1,2,2,1,3,2,2,1,4,4,5,4,2,3,4,5,5,4,1,4,3,1,4,1,4,1,3,2,3,2,3,5,3,1,4,4,4,1,1,2,5,4,4,2,3,2,1,3,4,2,2,1,4,1,3,2,5,2,5,2,5,5,1,2,1,2,3,4,3,4,4,3,2,2,5,1,1,5,2,3,3,2,5,3,5,4,4,3,1,5,2,1,1,1,4,4,3,5,5,2,2,4,1,1,5,5,4,2,1,1,2,2,5,4,5,5,1,5,3,2,3,1,4,5,5,4,3,1,4,3,2,3,5,3,4,1,3,2,4,4,4,2,4,3,3,2,3,2,3,5,1,1,1,4,4,3,1,2,4,3,1,2,4,5,1,5,5,4,5,1,4,4,3,2,4,5,2,2,5,1,1,2,2,3,3,4,5,5,4,5,3,4,3,5,3,1,5,5,4,2,5,4,2,4,4,4,4,3,2,1,4,1,2,1,2,5,4,5,3,3,2,5,1,1,2,4,3,1,1,5,5,3,1,2,1,3,3,3,1,3,5,1,3,1,3,4,5,4,4,4,4,3,5,3,3,3,3,5,2,3,1,4,2,1,5,3,3,5,1,1,3,5,2,3,4,3,1,1,2,3,5,4,1,2,1,4,4,3,3,1,4,5,2,2,2,1,2,2,2,5,4,5,5,4,2,1,1,4,4,5,2,4,5,2,3,4,2,4,2,3,3,2,1,2,5,5,2,1,4,3,4,2,5,3,4,3,2,3,5,1,2,2,2,4,4,1,2,2,2,2,4,3,4,4,5,2,2,1,1,1,2,1,3,3,2,3,2,2,3,5,2,5,2,1,3,1,2,3,5,5,4,5,4,4,2,3,2,4,5,3,5,3,4,2,1,1,4,1,2,1,3,5,1,1,1,4,1,4,3,5,5,2,4,4,3,4,1,5,3,5,4,3,1,3,5,5,3,3,4,5,5,3,1,1,4,3,3,2,5,3,2,1,2,4,4,2,5,1,1,5,1,1,3,3,4,2,4,3,2,3,1,2,4,4,4,4,3,5,3,4,4,1,2,3,3,3,1,1,3,3,4,3,2,4,3,2,5,5,3,3,2,2,3,5,2,5,4,5,5,5,1,1,2,4,5,3,5,3,3,1,2,1,3,5,2,1,3,2,4,2,2,5,1,3,1,1,4,1,2,4,4,2,3,1,5,5,3,1,2,1,4,4,5,2,5,4,5,5,2,1,5,5,5,4,5,2,2,3,4,2,1,2,1,1,3,4,1,2,2,3,3,3,2,5,3,2,2,2,3,2,4,1,4,1,2,4,2,3,5,4,5,2,2,4,2,2,5,5,3,3,2,2,4,3,4,4,4,3,2,1,5,5,4,4,1,3,2,1,3,4,3,5,2,1,1,5,1,2,2,2,4,3,3,2,4,1,4,5,5,5,3,5,4,3,5,1,3,2,5,4,1,3,1,1,5,1,2,5,2,5,3,1,2,4,5,2,5,2,4,5,3,2,4,1,3,1,5,2,1,2,5,2,1,3,2,2,3,2,5,3,1,4,1,1,4,2,5,5,4,4,4,2,3,2,1,3,1,1,2,1,3,5,2,3,4,1,1,1,2,3,1,3,4,4,2,1,5,3,3,2,2,4,3,4,5,4,3,5,1,1,4,1,4,4,2,4,4,4,1,1,3,3,5,3,3,1,1,4,1,2,3,1,3,1,4,3,3,2,4,5,1,5,3,1,4,2,1,1,3,2,3,1,1,1,2,3,3,2,2,5,4,4,1,1,5,2,5,5,5,1,3,5,4,1,5,1,4,1,2,3,3,5,4,1,2,4,2,3,3,3,1,5,5,5,4,5,1,4,1,1,2,4,3,2,3,2,1,1,2,4,3,2,5,4,2,3,4,2,5,4,4,3,4,2,2,3,2,5,3,3,1,1,1,4,5,2,2,4,2,3,1,5,5,4,2,4,3,1,4,4,5,4,2,1,3,2,5,1,2,2,5,5,1,1,2,2,3,1,1,1,2,1,4,1,4,3,5,1,1,2,1,1,3,1,3,3,5,5,3,2,3,3,3,1,3,2,2,1,5,3,3,3,4,2,4,5,5,5,5,5,1,2,1,4,4,4,5,3,1,5,3,1,2,2,3,4,4,1,5,5,4,5,5,1,1,2,5,1,5,4,1,4,3,4,1,1,2,1,2,4,1,4,2,5,5,5,3,2,2,3,2,5,2,3,3,2,1,2,3,5,2,3,3,3,2,2,3,2,5,5,3,5,2,3,4,1,1,1,1,4,2,1,2,2,5,1,3,3,1,5,5,1,3,4,5,4,3,1,5,5,2,2,2,3,4,5,3,5,1,5,1,5,5,1,2,2,4,4,4,2,2,2,2,3,3,5,5,1,3,2,1,4,5,5,3,2,2,3,4,4,3,4,3,4,1,1,5,1,5,3,1,4,5,2,2,5,4,2,2,5,3,3,5,2,2,2,3,5,4,4,4,5,5,4,2,3,3,4,3,4,1,1,2,5,4,1,4,4,2,1,2,2,5,5,3,5,1,1,5,4,2,5,1,1,1,2,3,5,1,4,5,2,1,2,2,3,3,2,1,5,4,1,2,4,3,5,4,2,4,4,3,4,3,5,4,2,5,3,4,5,3,5,5,4,5,2,2,3,1,2,3,5,4,5,3,4,5,1,5,1,4,2,1,4,4,1,4,5,4,1,1,3,2,5,2,2,4,5,4,3,5,2,2,1,5,1,4,3,3,4,2,5,5,5,3,3,2,1,5,3,3,2,4,2,3,3,2,2,5,3,3,5,3,4,5,4,1,4,4,5,2,1,5,2,3,3,5,3,3,1,2,2,2,5,4,4,5,3,3,2,2,4,1,3,5,1,4,1,5,5,5,2,1,1,1,2,5,3,1,4,4,5,4,1,2,3,3,5,2,5,4,2,3,2,2,2,3,4,2,5,4,3,5,4,5,4,2,4,1,2,4,1,1,1,4,4,3,5,3,3,5,2,3,4,1,3,4,5,1,2,5,4,3,2,1,2,4,5,2,2,5,5,2,4,1,5,1,3,2,3,4,4,1,2,2,4,2,4,5,2,2,1,1,3,4,1,1,4,5,1,5,2,1,3,2,5,1,2,2,3,5,1,4,2,5,1,3,2,5,1,2,1,3,1,3,3,3,2,1,4,2,2,1,3,1,3,5,1,4,1,3,1,2,3,3,3,1,5,1,5,3,4,4,1,2,1,4,3,2,2,2,1,4,5,5,5,5,2,2,2,2,4,1,1,1,4,2,5,1,5,2,5,3,2,5,3,2,4,1,5,3,2,4,5,3,1,1,4,3,5,1,1,1,5,5,4,5,3,5,1,3,4,4,3,5,2,3,4,5,3,1,2,3,4,5,2,2,5,3,5,3,5,3,4,2,3,1,1,4,4,5,1,1,2,2,1,1,3,5,1,5,3,1,5,5,3,4,3,1,5,2,4,4,5,3,1,2,5,5,5,5,5,2,5,4,5,4,4,1,4,3,1,2,5,4,4,4,2,3,4,1,2,4,3,4,3,4,4,3,4,5,4,5,2,5,4,5,3,5,1,1,3,5,1,5,3,2,3,1,2,5,5,5,1,2,2,3,5,5,1,5,3,3,1,5,3,3,1,5,3,4,1,3,4,5,4,5,3,2,3,3,4,4,2,5,4,1,3,5,5,2,3,1,1,3,1,4,1,5,2,5,5,3,4,5,2,4,2,4,4,5,2,3,3,3,3,1,2,2,5,4,3,2,3,4,3,1,5,4,2,5,5,5,1,5,2,5,4,4,1,5,3,3,2,3,2,3,2,3,5,3,1,4,2,2,4,4,1,3,2,3,3,3,2,3,5,4,1,3,2,5,1,3,2,1,4,5,3,3,5,2,3,5,4,1,1,5,2,2,3,2,2,2,4,2,5,1,3,1,2,5,4,3,3,4,3,2,1,4,5,2,2,2,3,5,3,2,1,4,3,4,3,4,5,5,1,3,3,3,1,1,1,1,3,1,1,3,2,5,4,5,3,1,3,4,3,4,5,2,4,5,1,3,2,4,3,4,1,5,1,3,1,2,3,1,3,4,3,5,2,2,4,5,3,1,4,3,2,5,2,1,2,2,5,3,3,3,5,3,1,5,2,2,3,4,5,3,5,2,4,4,3,2,1,1,5,5,5,5,3,1,5,5,3,3,5,1,4,4,5,1,4,5,3,5,4,3,2,4,5,5,2,2,3,1,2,2,5,3,4,5,5,5,1,5,1,1,4,2,5,4,5,3,3,3,4,3,5,3,2,1,4,5,5,5,5,3,5,2,1,4,2,2,2,3,5,1,1,5,4,2,1,3,4,4,1,4,4,4,4,4,4,3,2,2,1,2,5,2,5,1,5,2,4,1,5,2,4,5,3,5,1,2,5,4,2,2,5,1,4,2,2,5,3,3,1,4,2,5,2,2,4,5,3,5,2,4,1,3,1,2,1,4,1,2,4,3,1,3,4,3,1,2,3,2,2,4,2,1,3,4,2,5,4,4,5,2,4,1,1,4,2,1,1,5,4,4,3,2,3,1,2,4,2,4,4,5,1,4,2,5,3,1,1,4,5,5,1,1,5,3,3,5,1,2,1,3,2,2,3,3,3,5,5,1,5,5,4,3,5,2,3,1,2,1,5,5,5,1,4,3,2,3,2,5,4,1,3,4,2,1,2,5,2,2,2,2,5,3,4,2,2,5,1,4,5,3,4,3,3,2,2,3,3,1,5,5,5,4,1,5,1,3,4,2,3,3,5,1,2,1,1,1,5,4,5,2,2,1,5,4,2,2,5,5,1,5,1,5,1,1,2,2,1,2,3,2,3,4,3,2,1,1,5,3,1,1,2,4,3,2,1,3,5,1,4,3,1,1,5,2,3,2,2,3,5,1,1,5,5,2,4,2,5,1,2,3,2,4,5,5,1,2,2,1,3,3,5,4,5,5,5,5,2,4,5,5,4,3,1,1,5,1,2,3,4,1,3,2,1,1,5,5,3,2,3,5,3,1,1,1,1,3,4,4,1,2,3,4,3,1,2,5,1,1,2,1,4,1,5,3,1,2,1,3,1,3,1,5,4,1,3,2,4,2,1,5,1,5,5,2,3,3,4,1,3,1,1,1,5,4,4,5,5,3,3,3,5,3,4,5,5,1,4,1,2,5,2,5,2,5,4,3,5,4,4,2,5,3,5,3,4,5,5,3,2,2,5,1,5,2,3,2,1,4,5,1,1,5,3,4,5,5,1,5,3,4,3,3,2,4,4,5,4,1,2,3,5,4,5,5,4,4,5,4,4,2,4,4,2,5,5,3,1,5,2,2,5,3,1,3,1,5,2,4,1,3,5,1,4,5,2,1,3,1,2,3,3,4,5,4,3,3,3,2,5,2,4,5,3,5,1,3,5,2,2,5,3,4,3,3,3,3,1,3,1,3,3,4,1,2,5,1,1,5,2,4,1,3,3,4,2,3,5,4,1,5,2,5,1,3,3,1,4,1,1,4,5,4,4,4,3,4,4,5,1,3,2,4,5,4,5,3,1,1,4,3,5,4,1,1,4,2,5,5,1,3,3,3,1,1,2,5,1,1,2,4,4,5,5,2,1,2,2,3,5,2,5,2,4,5,4,3,4,5,4,4,4,4,1,4,2,4,1,3,4,5,2,5,2,1,2,1,5,4,4,3,5,5,5,2,4,1,2,5,2,1,1,5,5,1,3,5,1,3,1,2,1,1,1,1,5,3,4,4,5,5,1,4,3,4,4,2,4,1,5,5,3,3,2,5,2,5,5,5,1,2,4,2,2,4,3,1,3,1,3,5,1,1,5,5,5,3,3,2,1,4,5,3,5,1,1,2,4,5,4,3,4,5,3,3,2,5,1,3,1,5,5,4,1,3,2,4,1,4,3,1,1,1,2,3,5,1,3,4,3,1,1,5,2,4,1,1,3,2,5,1,4,1,2,5,5,2,4,4,5,5,5,1,4,3,3,3,5,5,3,5,4,4,5,3,4,3,5,4,4,3,3,2,4,5,3,2,4,4,2,5,1,4,1,4,2,3,4,1,4,5,4,3,1,3,2,4,1,5,3,5,2,3,2,1,1,1,3,5,1,1,4,4,5,2,4,3,4,3,1,3,2,1,5,1,1,1,3,2,4,5,3,4,5,5,2,5,3,4,1,5,3,3,4,1,4,5,1,5,3,4,5,2,3,5,4,3,2,3,4,4,4,3,3,5,5,5,1,3,1,2,3,3,5,5,5,2,1,3,5,5,1,1,1,3,5,1,1,1,2,3,4,1,1,3,2,4,2,2,1,2,3,4,3,2,2,1,3,1,5,5,5,1,3,4,3,2,2,1,1,1,5,1,2,1,4,2,4,4,5,5,5,2,3,3,3,2,5,2,3,2,5,2,2,2,1,3,5,2,1,5,4,2,3,2,5,3,5,5,1,1,1,5,5,2,3,3,5,2,3,1,3,2,2,1,1,3,1,2,1,1,2,2,4,4,4,1,2,1,2,3,5,2,2,3,1,3,2,1,5,1,4,4,4,4,2,2,3,5,2,1,5,5,2,3,1,1,5,1,4,2,3,1,3,1,3,1,3,3,3,1,1,1,5,3,4,5,5,4,3,2,1,1,5,4,3,1,1,4,3,1,4,1,3,3,2,3,5,2,4,5,3,5,2,5,5,3,3,1,5,1,4,1,2,5,5,2,3,2,5,2,2,4,1,3,1,5,1,4,4,1,2,2,5,2,2,3,3,4,5,3,1,1,4,1,2,1,4,4,3,4,1,3,3,1,2,3,1,1,4,3,3,4,3,3,3,3,5,2,1,5,1,4,3,2,3,2,2,1,2,5,5,2,1,3,5,4,1,5,2,1,4,5,3,2,2,3,5,3,5,4,1,5,2,3,2,3,5,3,2,3,5,1,2,3,5,2,5,1,4,4,3,5,3,2,1,1,1,4,2,2,4,2,3,3,4,1,2,1,4,2,1,5,3,2,3,1,1,1,5,3,1,1,1,4,2,3,4,1,2,2,2,5,1,2,5,1,3,2,4,4,5,3,1,2,4,4,4,5,2,5,1,5,2,4,5,4,1,5,3,5,3,2,3,5,1,5,2,2,2,3,1,3,2,2,5,3,1,4,4,3,2,3,3,5,1,5,5,5,5,4,3,3,4,1,5,3,4,1,2,2,2,1,1,5,2,1,1,5,1,3,2,1,1,4,3,4,3,5,2,1,5,2,5,4,5,4,1,5,3,1,3,3,5,1,5,1,5,3,1,5,3,4,4,2,4,4,2,4,1,2,1,2,1,1,2,1,4,4,4,3,1,1,3,5,2,3,2,4,4,1,4,5,2,3,4,5,4,2,5,5,1,1,1,5,5,1,5,1,5,5,5,2,5,4,3,2,4,3,5,1,5,2,5,3,2,2,3,3,1,2,4,4,2,5,1,3,4,3,2,4,4,1,3,2,4,4,3,3,1,4,4,5,3,4,4,3,1,1,2,1,3,1,5,3,5,2,4,5,1,4,1,2,4,1,5,3,5,3,5,3,3,3,5,1,4,5,5,1,5,5,4,4,3,2,4,4,1,1,5,2,1,2,3,4,4,1,5,1,1,2,1,3,3,1,2,1,1,2,2,1,4,2,2,4,5,5,4,2,5,4,3,2,1,5,2,5,4,4,4,2,2,2,5,5,2,2,1,4,5,4,2,3,2,2,1,5,4,1,4,1,5,5,2,5,4,4,4,1,1,3,3,4,2,1,1,5,2,5,5,2,4,1,3,3,1,5,5,1,5,5,2,1,5,2,2,4,2,4,3,1,3,3,2,2,5,2,2,2,1,1,3,3,4,2,5,5,1,1,3,1,2,4,2,3,5,2,1,2,5,2,4,3,4,5,5,4,2,3,5,4,2,4,3,2,1,2,5,3,5,3,5,2,1,5,3,3,1,2,3,4,1,4,4,2,2,3,4,3,2,2,1,1,4,3,1,3,3,2,2,2,2,1,4,5,1,3,2,2,3,3,3,5,2,4,5,2,4,1,1,2,5,2,3,3,3,1,3,1,5,5,1,5,2,3,3,2,1,2,3,1,2,4,5,5,1,3,5,5,1,5,2,5,5,1,2,5,2,2,5,5,1,4,4,4,3,2,3,2,2,2,3,3,2,3,1,3,5,5,5,3,3,1,1,5,5,4,4,1,5,1,5,5,3,2,2,3,3,4,2,2,4,1,1,3,2,3,4,3,3,4,2,5,1,4,5,2,1,2,3,5,2,1,2,3,3,4,5,5,1,4,2,5,5,4,4,2,5,5,5,3,1,4,5,5,1,3,3,5,5,4,5,5,2,1,4,1,2,5,2,1,3,4,3,2,2,5,1,5,3,3,1,5,2,4,4,1,4,3,4,2,3,3,2,4,4,2,2,2,5,2,4,5,2,3,1,5,3,2,3,2,1,3,3,1,1,5,4,2,1,3,2,2,4,2,1,1,4,1,4,3,3,4,3,1,1,1,3,2,3,4,5,5,4,2,1,1,1,4,5,1,2,5,2,2,3,1,1,5,4,2,1,5,1,5,4,4,1,4,2,2,1,3,5,1,2,5,2,1,5,1,2,4,3,4,4,3,4,2,3,5,1,5,2,1,5,5,2,3,1,4,3,3,3,4,2,2,4,1,5,3,4,2,3,1,5,3,5,4,3,2,1,4,4,1,4,3,4,4,5,5,1,3,3,2,4,5,1,2,3,5,4,5,4,1,1,1,4,5,4,1,3,5,4,5,2,2,3,5,5,1,5,3,4,4,4,3,3,1,3,3,3,3,5,5,3,2,5,4,4,2,1,1,1,3,1,4,5,5,2,3,2,2,5,3,3,1,1,1,1,5,2,5,3,2,2,3,2,2,4,3,5,1,3,5,5,2,1,2,4,5,4,2,5,1,3,1,5,3,5,2,5,3,2,2,5,1,5,5,4,1,1,3,1,3,1,3,5,3,5,2,2,1,4,3,2,2,4,1,1,2,4,3,4,4,2,4,2,1,3,5,5,5,2,4,3,2,1,1,1,3,5,4,4,1,4,2,3,5,5,3,4,1,3,2,4,1,3,3,1,2,4,4,2,2,3,1,1,2,1,2,2,5,5,4,4,5,5,4,4,4,1,4,1,2,5,5,5,5,1,1,1,2,4,1,2,1,5,5,5,4,4,2,5,5,1,2,1,1,1,4,1,1,2,4,3,1,2,3,2,2,5,4,2,1,1,5,5,3,1,4,2,3,5,4,1,1,4,3,4,1,4,5,1,1,2,2,2,3,5,4,2,4,2,3,4,1,4,5,3,4,4,5,4,5,2,1,5,5,3,3,4,2,5,1,3,4,3,5,1,4,4,5,1,2,5,2,3,1,2,4,1,4,5,3,2,1,1,3,1,3,2,1,1,1,2,1,4,2,4,5,5,2,5,5,2,5,4,5,2,4,2,2,1,5,4,4,2,3,5,5,4,3,4,3,5,3,3,5,3,4,3,1,1,3,5,4,4,1,1,1,4,5,2,1,4,5,1,4,1,2,3,2,3,3,3,4,1,3,1,5,3,3,5,3,5,2,4,2,4,4,2,5,1,1,2,5,5,3,5,5,3,3,4,2,4,4,1,4,5,2,1,1,5,4,3,2,2,2,1,3,3,1,4,1,2,2,1,1,3,3,5,3,1,5,1,4,2,1,1,4,1,5,4,5,3,1,2,2,2,5,4,4,5,2,4,4,4,3,2,2,5,1,5,3,1,4,4,3,5,5,3,4,4,4,3,3,2,3,5,5,3,3,1,2,1,1,2,2,3,2,3,1,1,2,2,4,1,4,5,1,2,4,3,3,3,5,5,2,5,5,3,5,2,2,2,2,5,1,1,5,4,1,3,2,1,4,1,5,4,2,1,1,2,4,2,1,4,2,4,1,5,3,5,1,2,4,1,3,2,1,3,5,5,3,2,1,5,5,5,2,1,2,2,2,4,5,1,3,5,1,4,5,1,1,3,1,5,1,2,3,3,2,1,1,5,2,4,4,2,5,4,3,2,4,5,5,2,2,5,2,2,5,3,5,1,5,2,5,1,1,5,1,5,2,1,1,4,1,4,1,4,4,5,3,4,2,3,1,3,1,5,3,2,2,2,2,1,5,4,3,3,5,4,1,5,2,5,3,5,4,4,3,3,5,3,4,2,2,3,4,3,2,4,4,3,4,4,3,2,4,1,2,3,4,3,4,2,3,5,1,5,5,2,5,2,4,2,4,3,1,5,4,2,1,1,3,4,2,2,3,1,2,4,3,4,5,5,3,2,2,4,2,5,3,4,1,2,4,3,5,3,1,1,3,1,1,4,4,1,1,4,2,3,3,1,3,1,3,5,5,4,2,1,2,1,1,5,3,5,2,5,5,2,2,2,4,1,1,3,3,4,3,3,5,5,1,1,1,3,2,1,1,4,2,3,2,4,2,2,2,3,3,1,2,1,4,5,4,1,2,2,1,2,2,2,3,2,5,1,5,5,4,1,3,3,3,5,3,5,5,1,5,1,3,5,4,3,4,5,1,5,2,2,4,3,4,2,2,3,3,3,1,5,2,2,5,2,2,4,2,3,2,1,4,3,1,3,1,5,1,3,4,5,4,3,1,1,1,2,4,4,2,5,1,5,3,4,4,1,2,2,2,1,5,1,4,2,2,3,2,2,2,1,5,5,1,3,3,5,1,3,2,1,5,1,5,5,4,1,3,1,3,2,5,3,1,5,5,2,3,3,2,4,1,5,4,3,2,3,4,2,5,4,2,2,1,2,5,3,4,2,5,5,2,5,2,5,3,2,2,1,2,1,4,5,4,5,5,5,1,2,1,4,2,3,2,3,1,5,5,3,5,1,5,3,3,3,1,4,2,4,1,2,5,4,5,3,1,4,4,4,2,3,3,2,5,4,3,2,1,3,5,1,3,1,3,2,2,5,5,5,2,3,4,3,2,4,1,5,2,5,3,3,4,3,3,5,5,4,3,4,3,1,5,2,4,1,1,2,2,5,2,2,1,3,2,4,4,3,2,5,5,5,5,1,3,2,2,3,4,4,4,1,1,3,2,4,1,5,2,2,2,3,3,4,3,5,4,4,1,5,5,4,5,1,5,3,1,1,2,3,3,4,5,4,1,2,5,1,5,5,4,5,3,5,1,3,2,3,3,4,2,4,5,4,1,1,3,5,4,1,1,5,4,5,5,1,4,2,2,4,5,2,1,4,4,4,4,5,5,3,3,3,4,5,2,4,3,2,5,3,3,1,2,2,4,2,4,5,5,4,2,1,4,1,1,5,4,5,2,2,4,1,5,5,1,4,5,4,3,5,1,1,3,5,5,5,5,2,5,2,4,5,1,4,4,3,2,2,2,1,3,5,2,5,4,1,3,1,3,1,1,5,1,5,4,2,3,3,4,2,4,4,2,2,5,2,2,3,5,3,5,5,5,1,4,1,5,5,3,3,5,2,4,2,2,5,1,5,4,5,1,3,5,2,1,5,1,1,3,5,2,2,1,5,1,2,2,5,2,1,3,5,5,5,2,3,2,1,3,5,4,3,2,2,2,2,2,4,1,3,3,2,5,2,5,3,5,2,2,5,5,5,1,4,2,3,2,4,4,5,4,4,4,4,4,2,3,4,2,2,2,1,1,2,3,3,2,5,4,5,3,2,2,5,3,3,1,4,5,3,5,3,2,5,2,2,3,1,3,4,2,5,1,2,5,5,3,1,5,5,3,1,5,5,2,5,3,2,3,1,5,5,1,5,2,4,3,4,1,1,1,5,2,4,5,3,3,2,3,2,4,5,1,1,3,4,2,2,2,3,3,1,1,3,5,2,3,1,4,3,4,4,4,2,1,4,5,3,3,5,1,4,5,4,3,1,2,1,3,4,2,1,3,1,2,4,2,2,2,4,5,4,1,3,5,1,3,4,5,3,2,3,3,5,1,5,4,4,5,3,5,3,5,3,2,4,5,4,3,3,1,1,5,4,2,1,3,2,5,2,4,5,3,1,5,3,2,3,4,2,1,4,3,4,4,3,2,2,1,5,2,5,1,5,4,4,4,5,4,3,2,1,4,4,3,5,1,5,2,3,5,5,3,5,5,2,5,4,3,3,5,2,1,2,5,4,3,5,3,2,1,2,4,3,5,4,3,3,1,1,3,4,2,2,1,1,1,1,4,5,3,1,4,4,1,1,4,2,1,2,3,2,1,2,5,4,1,3,5,2,5,2,5,3,1,1,5,1,5,1,3,1,3,2,3,2,1,5,4,3,3,1,2,5,5,4,2,1,3,2,3,5,4,5,5,4,3,2,5,1,2,2,5,3,1,3,2,5,4,5,2,5,5,4,4,2,3,4,5,4,5,5,2,4,1,4,1,3,4,5,1,3,1,3,5,4,3,3,4,5,3,4,3,5,5,4,3,3,4,2,4,4,2,3,2,3,4,5,3,3,3,5,1,1,3,2,5,4,2,3,1,5,4,1,3,3,5,1,4,4,3,2,1,4,2,1,5,1,3,4,5,1,4,1,3,1,1,5,5,4,4,4,5,5,2,4,1,2,1,4,3,1,1,1,2,5,5,4,1,2,5,5,4,2,4,2,4,2,1,3,3,3,2,2,4,4,4,2,1,1,3,5,4,4,3,1,1,5,3,2,3,4,1,2,3,3,1,2,1,3,4,2,4,2,1,2,1,4,1,4,4,2,1,2,5,2,3,1,4,5,2,3,3,3,3,1,1,5,5,4,5,1,3,4,5,2,3,4,2,3,1,3,4,2,5,4,5,2,2,4,4,5,1,4,3,4,3,1,4,4,4,5,4,3,3,2,3,3,3,1,1,4,5,4,4,3,1,3,2,5,1,4,4,4,5,1,3,5,2,3,2,4,3,1,2,5,3,2,1,5,4,2,1,5,2,3,2,2,3,1,2,5,4,5,5,1,5,4,5,4,2,4,1,5,2,5,4,2,3,1,5,2,4,3,4,5,4,5,2,2,2,2,5,3,1,4,5,3,3,5,4,4,5,3,1,1,3,1,4,3,4,4,5,4,4,1,5,3,2,5,4,2,4,2,3,1,1,4,5,5,1,1,1,1,5,5,3,4,5,5,5,1,5,3,2,4,4,3,4,5,4,4,5,2,2,3,2,5,5,4,5,1,3,4,2,5,2,1,5,2,1,1,5,1,2,1,1,2,5,1,1,5,3,2,2,1,3,2,1,3,2,3,1,5,5,4,4,1,3,2,4,2,4,4,5,2,5,1,3,1,5,5,2,3,5,3,4,5,3,5,4,5,3,5,3,2,5,2,1,4,2,2,1,5,3,2,1,5,3,4,2,3,3,4,3,5,3,3,2,4,1,1,2,4,5,5,1,5,4,5,5,1,1,5,3,2,4,5,2,5,2,1,2,1,2,3,2,5,1,4,4,4,5,2,2,2,5,5,5,4,4,1,4,3,5,1,3,4,2,3,2,2,4,1,1,3,4,4,2,5,2,4,3,3,2,2,3,3,1,4,5,3,1,1,1,4,5,1,2,2,4,1,5,2,5,4,2,5,2,1,5,5,3,2,5,3,5,3,1,1,2,3,3,2,1,5,3,1,5,5,4,5,3,2,3,1,5,2,5,2,3,5,1,3,2,3,3,4,5,3,1,2,3,2,2,5,3,4,5,5,5,1,3,4,2,2,1,5,2,3,5,5,2,1,3,5,2,5,5,1,1,2,3,5,1,4,5,1,5,1,2,4,1,3,4,5,3,2,3,3,2,5,5,5,3,5,5,4,3,3,5,5,3,1,5,3,1,5,3,5,2,5,1,5,4,5,1,1,5,2,1,3,5,4,2,5,3,1,1,4,1,3,3,2,5,5,2,4,1,4,5,4,5,4,2,2,1,5,5,5,1,4,3,1,1,1,2,1,5,4,2,4,1,1,3,4,3,2,2,3,4,1,4,5,5,1,1,4,4,3,4,1,2,4,4,4,2,5,5,3,5,1,1,5,4,3,3,4,1,1,5,2,2,1,2,5,2,4,3,5,2,5,2,5,1,1,1,3,5,4,3,1,3,4,1,2,5,2,2,1,2,4,5,5,4,5,1,4,5,2,2,3,5,1,3,4,2,3,1,3,4,3,3,2,3,3,1,5,3,3,3,3,1,4,4,3,4,2,3,3,1,2,2,1,2,1,4,2,3,2,2,2,2,4,3,4,1,1,4,3,2,5,2,5,5,4,2,3,3,4,5,2,2,3,1,3,1,3,5,1,2,5,3,3,5,5,2,1,4,4,3,2,5,3,4,4,5,1,3,5,5,4,2,1,2,2,5,4,4,4,3,4,3,2,3,3,2,2,2,5,2,2,5,5,3,3,3,4,2,2,1,2,4,1,4,3,1,5,4,5,4,1,2,2,1,3,5,5,2,2,4,3,5,4,4,4,2,4,2,2,2,3,4,3,1,1,3,3,5,2,2,2,4,3,2,3,1,5,1,2,3,1,2,1,2,4,4,2,3,5,5,5,4,5,3,4,4,4,5,5,4,3,1,4,3,2,4,5,3,5,3,2,4,1,1,4,2,2,1,1,3,5,2,4,1,2,4,3,4,1,1,2,2,1,1,3,2,1,1,5,2,3,5,4,5,5,3,4,1,1,5,1,1,1,2,1,4,4,3,3,5,4,5,2,1,1,2,1,2,1,2,2,5,2,3,1,3,1,1,1,1,5,4,3,2,3,4,5,5,1,5,2,5,5,5,4,2,1,2,2,2,3,1,3,1,5,3,1,1,1,1,3,1,4,3,5,5,1,5,1,3,2,5,2,4,5,3,2,4,5,2,5,5,3,3,4,1,5,3,5,1,1,5,4,4,1,1,2,3,4,4,1,1,5,2,3,4,4,3,1,3,5,4,4,1,4,4,1,1,3,4,2,5,2,4,3,3,3,1,2,2,3,3,1,2,5,3,2,1,4,5,5,3,4,3,4,4,1,4,4,1,1,5,3,5,3,4,5,4,3,2,2,2,1,4,3,4,3,5,1,2,1,2,2,2,4,1,2,5,2,5,2,3,4,1,2,4,5,1,5,1,1,3,2,2,4,5,4,3,4,5,1,4,3,3,4,4,1,5,1,1,1,4,3,2,2,3,3,4,5,5,5,2,1,5,5,1,4,5,3,3,5,3,2,5,1,3,2,1,5,2,4,2,4,2,4,3,3,3,3,5,4,4,4,1,5,5,4,3,3,2,3,1,3,2,5,4,2,1,5,2,3,1,2,4,4,4,3,2,5,3,2,2,2,5,1,1,5,1,5,5,2,2,1,4,5,1,1,5,2,4,3,3,3,4,5,3,3,1,3,2,4,1,5,5,3,3,1,5,5,3,3,3,3,5,4,5,3,4,1,4,2,3,1,1,3,5,1,2,1,1,1,2,5,3,5,2,5,1,3,2,2,1,4,3,5,3,4,3,3,4,2,4,5,1,1,2,3,3,3,3,3,4,2,5,5,3,5,2,3,3,3,1,3,4,5,3,2,2,5,5,4,2,5,4,3,5,3,4,3,4,4,5,3,3,5,5,3,2,2,3,5,5,3,1,5,2,3,4,2,3,2,3,1,4,1,1,1,2,4,2,1,2,4,2,4,1,4,3,2,5,4,4,1,2,5,2,3,4,1,4,3,4,1,1,4,4,4,1,2,4,4,5,3,5,1,2,1,4,3,1,5,1,5,2,3,2,2,4,4,4,4,4,2,3,3,3,5,4,1,2,2,2,4,3,1,2,1,2,2,5,4,2,4,3,5,2,2,4,5,2,1,3,1,1,4,4,4,4,3,1,3,1,1,3,4,4,3,1,5,4,1,3,1,1,5,1,5,4,5,2,4,1,5,4,4,5,1,4,5,3,5,4,1,4,5,4,5,2,4,2,3,5,1,4,1,1,1,2,3,4,1,2,1,2,2,3,3,2,4,1,3,2,3,5,4,3,4,3,5,5,2,5,5,3,2,2,1,4,1,4,2,5,4,3,4,1,3,5,5,2,3,3,3,5,2,1,3,3,1,1,4,2,2,1,2,5,4,2,5,5,1,3,2,5,2,5,3,4,4,5,3,3,3,4,3,2,5,5,3,5,2,2,1,4,1,1,1,5,4,3,3,2,5,1,5,1,1,2,1,1,4,2,4,3,1,5,3,2,5,5,4,2,5,4,3,3,1,2,3,5,2,1,3,3,2,4,4,5,3,3,4,3,4,3,5,3,4,3,2,4,3,4,3,4,1,3,5,5,3,5,2,4,5,5,1,5,4,2,1,1,4,4,2,3,2,3,2,1,2,1,5,1,2,2,4,5,5,2,3,1,1,1,3,4,2,2,4,3,3,5,3,2,4,5,2,4,4,4,4,1,2,2,2,1,2,2,2,2,5,2,2,5,1,3,3,2,1,4,5,3,1,4,2,2,5,2,3,3,3,2,3,5,3,3,2,5,3,1,2,2,2,4,3,4,3,3,2,3,4,4,4,2,1,3,4,3,3,4,3,1,5,3,1,3,4,3,1,2,2,3,2,5,2,4,5,2,1,2,4,3,4,4,5,1,3,2,5,4,1,2,3,3,2,4,2,5,2,2,2,1,3,4,1,5,1,5,2,2,1,5,5,4,1,2,5,4,2,1,1,3,4,3,3,2,1,3,3,3,5,5,2,2,3,2,5,3,3,2,4,2,2,1,4,1,5,5,1,1,3,4,3,5,5,1,5,5,3,4,4,2,4,1,4,3,5,1,5,5,2,3,4,3,1,1,1,3,3,5,3,4,5,2,2,1,2,4,5,1,5,3,4,3,2,5,5,1,5,5,5,3,4,1,1,3,1,3,3,5,1,5,3,3,3,2,2,3,2,5,4,1,1,3,4,2,4,5,3,1,3,5,4,1,5,4,1,2,4,3,5,2,4,4,4,4,5,1,4,3,3,3,4,2,1,5,3,1,5,1,5,1,1,4,2,3,5,5,3,5,4,4,2,5,3,1,3,3,2,3,3,2,4,2,4,4,2,4,3,1,1,1,2,2,1,4,4,1,2,4,5,4,4,1,2,3,2,3,5,5,1,2,2,3,3,4,5,2,1,2,4,3,5,2,3,3,1,4,5,5,5,4,1,1,3,5,1,2,1,3,3,3,5,5,1,5,4,4,2,2,2,2,3,4,5,4,3,3,5,3,2,5,1,1,4,1,1,5,5,4,4,3,5,5,1,2,2,1,1,2,5,5,5,1,2,1,3,2,4,3,1,5,5,1,5,4,4,3,5,5,4,1,4,5,5,1,5,3,5,2,4,4,1,3,3,3,5,5,4,4,1,4,5,5,2,3,5,2,4,3,2,5,2,3,5,5,3,3,1,5,5,2,3,2,5,1,5,5,4,1,5,2,1,3,4,2,4,1,3,2,2,5,3,5,1,1,1,4,3,3,3,4,3,1,3,5,1,1,1,3,4,5,4,4,2,1,1,2,4,2,4,1,3,4,4,1,1,4,1,4,3,1,5,3,5,2,1,4,4,1,4,2,4,5,3,1,2,5,4,2,4,3,1,4,5,4,5,1,3,4,3,1,2,5,3,5,3,4,1,1,2,1,4,3,5,5,2,3,1,5,2,2,1,5,1,5,5,5,2,1,2,3,2,1,1,3,5,2,4,1,3,1,4,5,4,2,4,4,5,4,1,4,4,5,5,2,5,2,1,5,1,4,5,4,3,1,5,2,4,1,4,1,5,5,2,1,4,2,3,2,3,2,5,5,2,3,5,1,2,3,4,5,2,3,4,1,2,1,5,3,2,2,3,5,4,3,5,2,2,5,3,3,2,2,1,2,2,4,2,5,5,2,1,4,3,5,2,2,2,1,3,5,5,4,5,4,2,2,3,1,4,3,3,4,5,3,2,5,2,2,1,5,4,3,4,1,4,4,2,5,3,1,4,4,5,5,5,3,4,4,3,1,4,4,1,3,3,5,1,2,2,1,1,3,4,5,3,3,5,3,4,3,3,2,2,3,2,3,3,1,4,3,2,4,3,4,2,1,2,3,3,1,3,2,3,4,3,3,2,3,1,5,5,3,4,5,3,1,3,1,1,1,4,1,3,1,1,1,3,1,2,1,4,3,3,4,5,2,3,1,1,3,5,1,5,5,4,1,5,1,5,3,4,5,1,1,5,4,4,2,1,1,4,4,5,1,1,4,4,4,3,4,1,4,4,2,2,5,1,4,4,3,5,2,5,1,2,1,4,1,4,3,1,1,1,5,2,4,4,5,2,3,5,5,5,1,2,4,1,2,4,1,1,3,5,5,5,4,1,3,2,4,5,5,3,5,3,1,1,1,4,3,3,4,5,1,1,3,5,5,4,3,5,3,1,2,2,5,2,5,2,5,1,2,3,1,4,1,1,5,4,3,3,1,2,2,5,2,5,4,3,1,4,3,5,1,1,4,1,3,1,1,1,2,3,5,1,2,1,5,5,5,5,5,3,2,2,4,2,1,5,5,4,2,3,1,2,1,5,2,2,5,5,5,3,5,2,3,3,5,5,3,2,2,3,2,1,2,1,2,4,4,5,1,4,3,1,5,3,2,4,4,3,2,3,3,5,4,2,5,4,2,3,3,3,5,3,2,2,2,5,1,4,1,3,5,4,4,4,4,2,2,5,1,4,5,4,2,2,5,4,4,3,2,4,2,2,5,3,4,2,4,4,5,2,4,5,3,3,3,5,1,5,4,4,4,2,5,2,5,3,4,3,1,1,1,5,1,2,5,2,1,3,3,2,4,3,2,2,4,5,4,1,2,1,2,3,4,5,2,3,3,4,1,5,4,4,1,1,5,3,1,4,4,5,2,1,3,4,4,1,1,5,4,1,2,5,3,1,3,3,5,4,3,5,1,3,4,3,4,2,3,1,3,4,5,3,3,2,4,4,1,1,5,1,3,4,5,3,4,5,2,2,4,3,5,2,5,3,3,2,2,3,2,2,4,3,2,2,5,2,4,1,2,2,5,2,2,1,3,5,3,3,5,5,4,2,1,4,1,1,2,1,5,5,5,4,1,2,4,4,3,1,2,4,4,1,4,3,2,2,3,1,1,2,3,4,2,1,5,1,3,4,1,5,1,1,3,2,1,2,1,5,2,1,3,1,4,1,2,3,2,2,1,1,2,4,1,2,3,5,2,3,2,4,4,4,1,5,4,2,3,1,5,4,3,5,3,3,1,3,2,2,2,5,4,2,2,2,1,1,4,4,2,1,3,5,2,3,1,2,1,4,1,2,4,2,3,4,5,2,3,5,1,4,4,4,2,5,4,4,2,5,3,3,2,3,1,5,2,4,4,1,1,4,1,3,4,3,3,5,5,3,3,5,5,4,1,3,5,1,4,2,1,3,4,1,2,3,4,4,1,1,5,1,4,5,2,1,3,1,2,1,2,2,5,1,4,5,5,2,3,4,4,4,5,1,3,4,4,4,5,2,4,1,5,3,5,5,3,2,1,5,3,3,2,5,5,3,3,1,3,1,3,4,3,2,2,3,3,2,1,1,2,3,1,3,1,3,5,2,3,3,2,2,1,5,3,1,4,3,3,5,1,4,2,2,5,4,3,1,2,2,1,4,2,4,3,2,4,2,3,5,2,2,1,4,4,3,3,2,1,3,2,2,5,1,5,3,5,4,1,3,4,2,2,4,2,2,1,4,1,3,5,3,3,4,3,5,5,5,2,2,3,3,4,3,1,2,1,3,4,3,1,1,4,5,1,4,2,4,1,2,2,5,1,2,1,2,4,1,5,5,1,4,1,4,3,3,5,5,4,2,3,2,3,1,2,3,1,4,1,2,3,4,3,1,3,4,4,3,3,5,2,3,2,3,3,1,1,3,5,1,4,1,3,1,2,1,1,4,3,2,2,1,5,2,2,3,4,4,3,5,5,1,2,4,2,5,3,2,5,3,3,5,4,1,5,5,5,5,1,3,3,5,2,3,5,3,4,5,5,4,1,3,5,1,5,4,5,1,1,2,5,4,1,4,1,4,4,5,5,5,1,3,3,2,1,3,3,2,1,4,1,3,5,5,3,4,4,1,4,4,1,2,4,4,3,1,1,5,5,4,3,5,2,2,2,1,3,2,1,5,4,3,4,1,2,1,1,2,4,5,5,5,3,5,5,4,1,1,2,2,4,5,5,3,4,1,4,1,3,4,4,1,2,5,3,1,2,1,4,3,3,2,5,2,1,3,4,4,1,5,1,1,3,3,3,3,4,3,2,2,2,1,3,3,5,3,3,3,2,1,5,2,3,4,1,5,3,5,3,5,2,5,2,3,1,5,4,5,5,5,2,5,4,5,3,2,2,2,3,3,4,1,3,4,4,2,3,4,1,2,1,1,1,2,1,5,4,2,2,3,2,2,4,2,1,4,1,4,3,4,1,2,3,5,2,4,4,1,2,4,3,3,1,3,5,4,1,2,5,5,4,1,3,4,5,2,3,1,3,4,5,2,3,2,3,3,1,2,3,5,5,3,5,2,5,5,2,4,2,4,3,5,2,2,5,2,2,5,1,3,3,5,4,4,1,3,4,1,5,1,1,1,2,4,5,1,3,1,4,1,1,1,5,4,3,2,2,3,5,2,3,3,1,1,3,5,2,1,5,1,5,5,4,1,1,4,2,1,4,5,1,4,2,1,1,1,3,3,2,2,1,1,4,4,5,1,1,4,1,1,4,1,2,3,2,4,2,3,2,3,3,3,5,3,5,4,3,3,2,5,4,1,2,5,1,3,5,3,5,5,4,3,1,3,3,5,2,4,1,5,5,3,4,5,4,4,5,4,5,2,1,5,3,3,5,2,3,1,1,4,1,1,1,4,2,3,3,4,2,3,4,2,5,2,3,3,5,3,5,3,4,2,4,1,5,1,5,3,3,4,4,1,5,1,1,2,1,3,5,2,5,2,1,1,3,4,4,4,4,4,1,2,1,5,2,2,5,1,5,3,5,4,2,2,1,2,4,3,1,5,2,2,2,4,2,3,2,2,5,1,5,2,3,5,4,3,1,5,5,5,1,1,3,4,3,3,3,5,5,2,3,1,3,5,4,4,3,1,1,4,4,5,1,3,4,2,2,1,1,2,4,5,1,3,1,3,5,4,3,5,4,5,3,1,5,1,5,5,5,3,3,2,1,2,5,1,3,3,5,5,2,2,4,3,1,4,4,3,4,1,1,3,4,2,4,5,4,4,4,1,3,3,5,3,4,3,4,5,2,3,1,2,2,5,3,5,3,4,4,2,4,2,4,3,2,3,1,5,3,2,4,1,3,2,2,4,3,1,1,1,5,5,4,5,2,4,4,1,4,4,2,5,5,1,4,2,2,1,2,4,4,1,5,2,4,3,3,5,2,1,3,3,2,3,1,2,2,3,1,2,4,2,3,5,4,5,5,4,4,3,2,1,5,1,1,1,1,2,3,4,1,5,1,3,5,5,2,5,1,3,5,3,5,4,1,4,3,5,4,2,5,5,5,2,4,3,4,2,3,5,3,2,5,3,5,5,3,5,2,3,1,3,2,4,1,4,4,5,3,3,2,2,4,2,1,3,5,3,1,1,2,1,3,3,4,2,4,1,3,3,3,3,4,4,1,5,4,5,1,5,5,2,4,4,5,3,1,1,2,5,5,2,3,4,5,5,1,4,3,5,3,5,5,2,4,5,2,4,1,5,5,1,2,2,2,1,5,1,5,1,2,1,3,2,5,4,3,5,1,5,1,2,1,4,2,3,3,5,1,2,5,3,5,1,1,5,4,1,2,1,2,1,2,5,4,1,3,2,1,2,1,4,4,4,5,3,4,1,3,1,3,4,1,1,5,3,4,1,2,4,4,5,1,4,5,5,3,2,2,4,5,2,5,1,1,3,1,1,5,2,5,2,3,5,4,4,2,4,4,4,2,2,1,1,1,3,5,3,4,1,5,3,4,4,2,3,4,5,1,3,5,1,4,4,2,2,2,4,5,2,1,1,4,5,4,3,5,5,4,4,2,2,1,3,1,3,2,4,1,4,4,1,1,1,2,5,1,1,3,3,3,4,4,4,1,4,4,4,1,1,4,4,3,4,1,5,2,5,1,3,1,4,2,1,2,5,5,1,5,2,4,4,3,4,3,4,2,3,3,4,1,4,2,1,5,4,3,4,1,1,2,3,2,4,5,3,3,2,4,3,4,3,1,3,3,1,4,5,1,5,1,5,3,1,1,2,4,5,2,3,4,2,4,4,1,2,1,5,1,5,1,1,2,1,2,3,1,2,3,1,3,5,3,5,3,3,5,1,5,3,4,5,4,5,5,4,5,2,2,4,1,4,1,3,5,5,1,5,3,5,4,4,4,3,4,1,3,4,5,1,3,3,4,2,1,2,3,2,5,4,1,1,5,1,5,1,1,1,4,2,1,3,5,4,4,5,3,5,1,1,5,4,2,1,1,4,2,2,1,2,4,5,5,4,4,4,1,3,3,1,2,5,3,4,3,1,2,2,5,4,5,1,1,5,3,2,4,1,3,2,3,3,3,2,2,5,1,1,3,4,5,4,5,3,4,3,1,5,1,5,5,1,2,2,3,3,1,3,1,1,3,2,2,1,1,3,5,3,4,4,5,5,3,1,1,3,1,2,4,2,4,1,2,3,4,2,4,4,1,5,3,5,4,1,5,3,3,2,3,5,3,3,4,5,1,4,1,3,3,3,2,5,5,3,3,3,5,1,1,3,2,1,2,2,1,1,1,2,4,1,5,1,1,5,5,3,4,1,3,3,5,3,2,3,5,3,1,1,4,2,4,5,4,1,1,3,2,1,2,3,4,4,3,2,5,4,4,3,3,5,3,3,4,5,3,1,5,1,4,2,2,1,4,5,3,3,3,1,4,2,2,4,3,1,4,3,4,2,3,2,1,5,5,2,3,1,4,1,5,1,4,4,3,1,5,2,4,5,2,1,2,1,5,2,4,2,3,2,1,4,2,2,5,5,5,1,5,1,3,3,5,3,4,4,1,4,5,4,5,3,1,3,1,1,3,4,4,2,3,5,1,3,5,3,2,4,1,2,4,1,3,4,3,5,1,3,1,1,4,5,2,5,4,5,3,5,3,1,4,4,4,2,4,1,5,1,1,4,4,2,4,1,1,3,3,5,5,2,2,1,1,5,3,3,3,1,1,3,3,2,1,1,1,3,2,2,4,5,1,2,4,2,1,3,5,5,5,5,2,1,3,2,5,2,1,3,2,3,4,1,4,1,5,3,3,4,2,4,1,2,4,5,4,1,4,5,5,3,1,1,3,4,1,2,5,5,1,3,4,5,2,3,3,4,3,3,5,1,1,5,1,5,1,2,2,1,1,2,4,3,2,4,3,3,1,4,1,2,5,3,5,4,5,1,3,1,2,3,5,4,5,3,3,1,4,3,3,5,2,2,4,5,2,5,1,4,1,4,5,5,3,2,4,4,5,2,3,2,2,2,2,4,3,3,1,4,4,5,4,1,3,3,2,1,5,5,2,5,2,1,2,1,4,4,1,5,3,3,1,4,1,2,3,1,2,2,4,4,2,4,1,5,4,3,5,1,4,3,4,1,5,2,3,5,3,3,3,1,5,1,5,1,5,5,1,3,2,5,5,2,1,5,3,1,2,2,2,2,4,5,3,5,3,5,1,5,1,4,2,1,4,4,3,5,4,1,3,5,3,4,3,3,3,3,4,2,5,3,1,2,5,4,4,5,4,4,4,2,3,3,5,3,5,1,3,1,3,4,4,2,2,4,1,1,1,5,2,1,1,3,5,1,4,5,3,1,1,4,2,2,2,3,4,5,5,4,5,1,1,1,5,4,5,4,5,4,5,5,4,5,2,4,4,2,3,4,4,5,3,4,5,3,2,2,1,2,4,3,5,1,5,2,3,4,5,4,1,3,5,5,5,3,1,1,4,5,3,2,1,4,4,5,2,1,4,2,1,3,5,2,5,1,3,5,1,1,5,3,2,2,4,1,1,3,2,1,3,4,4,4,5,5,4,2,1,4,2,5,3,5,5,5,1,1,1,2,2,5,2,5,2,4,5,1,4,1,3,4,3,5,5,1,1,4,4,3,5,1,4,4,3,4,4,1,4,3,4,3,1,2,4,2,2,3,2,3,1,1,4,4,3,1,1,2,3,2,4,1,3,3,5,5,4,4,3,3,4,1,4,2,3,2,5,4,5,3,5,2,2,5,2,5,3,2,4,2,3,1,5,5,2,2,5,4,5,3,4,2,1,2,2,4,3,5,4,4,4,5,1,4,2,5,5,3,3,4,2,4,4,3,1,1,3,5,1,3,2,4,2,4,1,2,3,4,4,3,1,4,4,1,3,5,4,4,1,1,3,5,2,3,5,3,2,3,1,1,2,3,5,5,2,4,1,3,2,1,4,2,4,5,2,5,1,4,2,3,4,5,1,1,2,3,5,3,4,3,2,1,5,3,1,2,4,3,5,4,5,2,3,2,2,2,1,3,4,5,1,4,2,2,4,3,2,3,3,5,2,5,5,2,4,5,1,4,5,5,4,1,3,2,2,2,5,1,4,1,2,4,3,2,1,3,3,4,3,3,4,2,4,4,4,2,3,1,3,2,1,4,4,3,1,4,3,2,4,2,2,4,5,2,2,4,3,3,3,5,4,3,5,1,5,1,3,4,4,1,2,5,5,4,2,4,2,2,4,5,2,1,5,5,1,3,4,3,3,2,5,3,3,1,1,5,2,2,2,2,1,1,2,2,1,1,4,3,2,4,4,3,2,1,3,5,5,1,2,2,2,3,4,4,3,2,2,3,1,1,3,5,1,5,1,4,2,1,5,1,3,1,3,2,3,2,2,2,3,1,5,5,2,5,5,2,1,5,4,2,5,3,2,2,1,5,1,5,2,2,5,2,1,4,2,3,3,5,2,3,4,1,2,3,4,3,1,3,2,2,1,1,1,3,2,1,1,4,2,2,5,4,1,2,1,5,5,4,4,2,4,1,4,1,5,5,5,4,4,3,4,5,5,5,3,3,3,5,4,1,3,1,4,2,3,3,2,5,5,4,3,5,5,4,5,2,3,3,5,2,4,2,5,4,4,2,4,1,2,1,1,4,1,1,1,5,1,2,4,3,4,5,2,3,5,5,3,1,5,1,1,4,1,5,5,1,4,3,1,4,3,2,4,1,2,4,3,5,3,4,3,5,1,5,2,5,1,3,3,5,2,4,4,5,5,1,4,1,2,3,1,3,4,5,2,5,2,4,3,2,3,3,3,4,1,2,3,5,2,1,1,4,5,3,5,3,2,4,3,2,3,1,4,1,3,3,1,4,3,5,4,5,2,2,3,4,1,3,5,2,1,3,5,1,4,5,3,5,1,5,4,1,1,3,2,2,3,3,2,5,2,5,5,1,3,1,1,1,4,5,5,4,4,2,4,3,3,5,3,4,4,5,4,4,2,2,3,5,1,3,1,1,2,3,5,2,3,2,4,3,2,3,1,4,4,2,2,1,3,4,4,3,2,3,5,5,1,4,4,1,3,3,5,5,5,3,2,4,3,4,5,5,4,2,1,4,2,4,2,2,3,1,1,2,3,2,4,2,3,3,3,3,5,1,5,4,4,5,3,1,4,1,4,5,5,2,4,5,3,1,3,4,4,4,5,2,2,5,4,5,3,2,2,5,5,1,3,4,4,5,5,5,3,4,5,1,5,4,2,2,5,4,1,5,3,2,2,1,2,3,5,1,2,3,5,3,2,2,3,1,5,4,4,5,1,2,5,3,5,5,5,4,3,1,3,5,3,4,5,4,2,4,2,1,4,3,4,1,4,4,4,3,5,2,1,4,5,2,5,4,2,5,1,3,2,5,4,4,5,5,2,4,2,1,5,3,3,4,5,3,2,4,3,5,1,3,1,2,5,1,1,2,2,5,2,3,4,3,3,1,1,5,4,1,4,5,2,4,1,2,2,4,3,5,4,5,4,5,1,2,3,1,4,3,2,3,3,2,1,3,5,4,4,1,2,2,2,4,2,2,4,4,1,2,4,3,1,3,2,4,3,4,1,3,1,5,3,1,5,4,4,2,5,2,2,3,1,2,2,4,5,1,1,5,4,1,3,5,4,5,1,1,4,2,5,4,2,4,5,5,2,2,1,1,5,5,4,2,2,2,4,5,3,3,5,2,1,2,2,4,5,5,1,5,3,1,1,3,2,3,4,2,1,4,3,5,1,4,4,5,1,5,5,4,5,3,3,5,3,3,5,5,3,1,4,3,1,1,2,5,3,2,5,1,5,2,1,2,5,1,4,2,5,5,2,2,2,1,3,1,2,5,3,3,5,2,3,4,4,2,5,1,4,1,1,5,1,5,4,5,4,3,3,5,5,3,4,4,1,5,1,5,2,5,5,5,2,5,5,4,4,5,1,5,4,3,4,2,3,3,2,2,5,5,1,2,3,3,2,3,3,3,3,3,4,5,4,1,5,5,4,2,2,4,3,1,1,3,4,2,4,1,2,2,2,1,3,3,1,3,1,5,3,3,1,3,4,5,2,1,4,1,3,5,4,1,4,1,2,1,2,2,5,5,4,1,1,5,4,3,4,5,1,1,3,5,4,1,4,5,1,3,3,1,3,3,3,1,1,4,4,4,3,5,3,4,3,2,2,5,1,3,2,4,1,3,4,2,5,3,3,2,3,3,2,1,1,3,3,4,4,1,4,3,1,2,1,3,4,2,5,5,2,2,5,1,5,3,4,2,4,2,1,5,1,3,3,3,3,4,5,1,4,3,1,4,5,5,5,3,3,5,3,5,2,5,3,3,2,2,3,1,1,3,1,3,1,2,5,1,1,3,3,2,4,1,3,4,5,4,4,4,1,3,4,2,4,2,1,1,3,2,4,2,1,4,5,2,4,3,3,2,3,1,2,4,3,4,3,2,4,4,5,1,5,4,2,3,5,4,4,4,4,3,3,1,2,4,3,1,5,2,4,3,2,1,5,1,5,5,4,1,1,1,1,4,5,3,5,1,4,1,1,2,3,1,3,3,3,1,2,2,2,4,5,5,4,4,4,2,3,1,5,4,4,4,3,1,3,1,2,3,2,5,4,2,4,3,5,3,1,3,5,3,3,3,4,1,1,3,4,5,1,3,2,2,1,2,5,5,3,2,1,1,1,5,5,4,4,2,2,2,5,4,1,1,4,4,5,2,3,4,4,4,3,1,3,4,4,2,2,4,3,3,5,3,1,1,5,4,5,3,5,2,4,1,5,4,2,5,3,2,4,5,3,4,2,2,5,3,1,4,5,5,1,5,1,3,3,3,3,1,1,2,1,2,1,2,1,4,3,2,3,5,2,5,5,2,3,2,1,1,1,5,5,5,2,5,3,3,5,5,3,3,2,4,1,2,3,1,1,5,4,5,2,3,5,4,5,5,5,3,3,4,1,2,5,5,3,2,4,3,3,1,4,4,2,2,1,2,2,3,4,1,2,4,2,3,3,5,5,4,3,5,3,3,3,5,1,2,4,5,3,4,2,2,4,5,1,2,3,2,3,5,2,4,1,3,2,1,5,2,3,1,5,2,3,2,1,3,3,1,1,5,1,4,3,3,1,4,4,1,4,3,4,1,2,2,4,3,5,2,2,3,3,4,4,1,2,1,4,4,2,4,3,3,1,5,2,1,2,2,5,2,3,4,3,3,1,1,2,3,1,3,2,2,3,4,4,4,4,1,3,4,1,3,2,5,2,1,5,3,2,2,2,1,5,3,3,4,4,4,2,1,1,1,4,3,1,5,2,2,3,2,3,1,4,2,5,1,4,4,3,2,5,4,4,2,3,1,2,3,5,5,2,1,2,3,5,3,5,4,3,3,4,1,2,1,5,1,1,2,4,4,1,1,3,4,2,5,3,2,3,3,5,3,5,4,4,2,5,2,4,2,4,3,5,1,5,4,5,5,3,2,5,5,4,3,5,5,3,5,5,2,4,2,2,1,5,5,1,4,5,5,4,5,5,5,5,2,5,4,5,3,4,2,2,1,4,2,1,1,4,1,4,2,3,4,3,2,1,3,5,4,1,3,4,2,4,3,1,5,3,1,5,4,3,3,3,4,3,2,1,3,2,2,1,5,4,4,2,2,2,3,3,4,5,4,2,5,5,2,2,5,1,1,1,1,4,3,3,2,1,1,3,2,1,3,5,3,4,2,4,5,4,3,5,1,2,1,2,2,2,4,5,4,2,3,5,3,5,4,5,4,3,2,5,1,5,5,4,1,5,2,4,3,2,3,3,1,3,3,3,2,1,3,5,5,3,4,5,1,3,4,2,4,1,2,5,4,3,4,1,2,2,4,4,4,1,3,3,5,2,5,5,4,1,1,5,5,3,3,3,1,2,4,5,3,2,1,5,3,1,1,1,1,3,5,2,4,5,1,2,5,3,4,4,5,5,5,3,5,4,5,2,4,3,3,4,2,1,5,1,3,5,4,4,2,2,2,4,3,1,3,3,3,3,1,1,1,4,4,4,5,5,4,1,3,2,2,3,2,2,5,2,5,4,3,1,2,5,2,5,3,1,4,3,4,2,1,2,1,3,5,5,3,4,1,1,5,1,3,5,1,5,2,4,4,1,3,1,5,1,5,2,5,3,4,1,4,3,5,3,3,4,5,1,5,1,2,5,3,3,4,5,3,3,3,5,2,2,5,3,3,5,2,1,4,2,1,4,2,2,5,2,1,5,1,2,1,3,2,4,2,1,3,1,5,1,3,1,5,2,4,4,1,1,2,4,2,2,2,3,2,4,3,5,5,2,4,5,1,4,1,1,5,3,1,1,3,2,3,4,4,5,3,3,1,3,2,4,3,3,1,5,1,2,2,3,2,1,4,5,4,4,3,5,4,3,4,4,1,1,4,2,4,5,2,2,3,1,1,5,5,5,1,2,3,2,1,3,3,4,5,3,4,4,4,1,1,4,3,1,2,3,2,1,5,1,4,3,5,5,5,5,4,4,3,5,3,4,2,5,5,2,3,4,4,2,3,4,5,3,2,5,1,3,4,4,5,4,1,4,1,5,1,4,4,1,2,2,4,3,5,1,1,5,2,3,4,4,2,2,2,1,4,3,1,2,2,2,2,2,5,3,2,5,5,4,1,3,1,4,4,1,4,5,3,2,5,1,2,2,4,4,4,3,1,4,3,2,3,1,5,1,4,5,4,3,1,4,2,1,2,5,2,2,5,3,1,3,1,4,3,4,1,5,4,5,5,3,3,1,5,4,3,5,4,4,2,1,4,3,5,1,1,3,5,1,4,4,3,3,2,4,5,5,2,3,1,3,5,5,5,2,2,3,3,4,4,1,2,2,1,5,2,4,2,3,2,5,3,5,4,4,3,2,1,4,5,5,2,5,2,4,5,2,5,2,3,1,4,1,3,5,2,2,3,1,4,1,2,3,1,1,2,2,2,3,2,4,1,1,2,3,3,4,2,3,4,5,4,1,5,4,5,5,4,5,3,2,5,2,2,5,5,1,4,1,5,5,3,4,5,5,4,4,2,4,5,4,2,3,2,2,3,2,3,3,3,1,3,4,4,5,1,5,5,5,3,3,2,3,2,1,5,3,4,1,1,4,4,2,2,4,2,2,4,5,5,1,2,4,4,2,1,4,1,3,2,3,4,5,4,2,3,3,1,3,4,2,5,4,3,3,4,4,4,4,4,1,3,5,1,5,5,1,2,2,4,5,1,5,5,1,5,2,1,1,3,3,3,5,1,1,2,2,5,5,4,1,1,1,3,3,5,5,4,3,1,2,4,2,4,1,1,1,1,1,2,5,3,4,5,1,3,2,4,4,5,2,1,1,3,1,4,2,2,1,1,5,2,3,3,5,4,2,2,5,1,1,2,4,5,5,4,2,3,1,3,2,3,2,1,4,1,2,2,4,5,3,4,5,3,1,4,1,3,4,5,1,4,2,3,5,2,5,1,4,4,1,3,3,1,1,4,4,4,4,2,4,2,3,5,5,2,1,4,5,5,2,3,3,1,3,5,1,2,1,4,3,1,1,5,2,2,2,5,1,3,5,5,5,1,2,4,2,5,5,1,2,4,3,3,2,4,1,5,3,2,2,5,1,3,4,4,2,1,4,5,1,1,4,3,1,4,4,5,3,1,2,5,3,3,4,4,3,2,1,5,1,5,4,4,4,3,4,3,3,5,1,5,1,5,3,3,5,1,2,2,2,1,1,2,4,3,2,2,4,1,4,3,3,3,1,2,3,4,5,1,5,4,5,2,3,3,5,4,3,1,4,1,2,3,1,1,4,3,4,4,4,3,5,4,5,5,2,3,5,5,4,2,2,4,1,2,1,2,4,4,5,4,5,1,4,2,3,2,4,2,2,4,1,2,3,1,2,5,4,3,2,5,2,4,4,3,5,2,3,4,5,3,4,5,2,1,1,1,5,3,4,4,4,5,2,3,2,4,4,1,3,3,4,4,5,4,2,2,2,2,4,5,4,4,1,4,4,5,3,2,1,4,1,2,3,1,2,3,2,3,2,4,1,1,4,3,3,3,1,1,1,2,5,1,4,3,1,1,3,3,4,5,5,5,5,4,5,4,3,4,2,2,5,3,3,3,2,4,2,5,3,5,5,5,3,3,5,4,2,1,3,4,3,4,1,4,2,5,2,2,2,5,1,3,1,3,3,3,4,4,5,2,5,2,5,3,2,1,4,5,3,3,1,2,5,4,4,5,1,5,1,1,3,5,5,2,1,4,3,3,2,2,1,1,2,3,2,4,4,2,3,1,2,4,2,1,3,4,1,3,5,2,5,4,1,1,2,5,1,2,2,2,1,5,3,2,4,3,5,4,4,5,3,5,1,2,5,1,5,5,5,2,5,3,3,2,2,2,4,3,4,3,1,3,4,2,1,4,2,2,5,1,3,2,1,4,1,5,2,3,1,2,2,3,2,3,1,1,3,3,5,3,4,4,5,2,1,3,3,5,3,5,2,4,1,4,3,2,3,1,4,2,1,1,2,4,3,5,2,2,1,3,5,2,1,1,3,2,4,4,4,3,1,2,1,4,2,2,2,5,3,2,3,2,2,4,1,5,1,2,3,1,2,2,4,5,2,2,2,1,1,5,4,1,1,5,1,4,1,2,4,4,4,5,1,5,3,1,5,5,5,1,1,3,3,3,5,4,2,3,3,1,1,5,5,4,3,5,4,3,1,4,3,3,5,2,2,2,2,1,4,5,1,5,1,5,1,5,5,4,2,4,4,2,2,5,1,1,1,5,3,1,5,4,1,1,4,4,1,2,1,2,2,2,4,3,4,2,4,2,3,4,3,5,2,4,3,4,5,2,2,2,2,1,5,3,5,1,3,3,4,1,3,3,5,5,5,3,4,3,2,4,5,3,2,2,2,2,3,4,5,3,1,2,4,4,1,4,4,5,2,2,1,2,2,2,1,1,2,5,1,3,3,3,2,4,4,2,3,3,4,2,3,2,5,4,4,1,2,4,3,5,5,2,5,3,4,4,4,3,2,1,4,1,4,4,5,3,2,2,3,3,1,2,5,5,4,1,2,2,1,5,5,4,1,4,3,3,1,3,4,2,4,1,3,3,2,5,2,4,3,5,4,3,5,1,3,2,1,5,4,1,3,5,2,2,1,1,3,2,2,1,3,3,2,1,3,5,5,4,1,1,1,2,4,1,4,4,1,3,5,2,1,3,4,2,1,2,3,4,4,1,1,4,5,5,3,5,5,3,5,5,5,1,2,5,1,3,1,2,5,5,1,4,1,2,1,1,1,5,2,1,1,3,3,1,5,3,2,1,4,3,4,1,5,3,5,5,1,5,1,4,5,5,2,3,2,4,4,5,3,2,3,1,5,5,2,1,4,3,5,5,4,5,5,2,5,4,2,2,2,3,5,4,5,4,2,4,3,3,1,2,3,3,1,4,2,4,4,4,5,5,5,5,1,5,5,2,5,1,4,2,3,1,3,1,5,3,4,1,4,3,5,1,3,4,4,3,5,5,4,4,4,2,1,3,2,1,4,3,3,4,2,1,2,2,1,5,5,2,2,4,3,5,5,3,1,1,2,1,2,5,4,5,3,4,2,4,2,5,5,3,4,5,4,3,3,4,1,5,3,1,3,1,2,3,5,1,4,2,4,1,3,4,4,5,1,5,2,2,3,2,1,4,3,1,4,3,1,1,1,3,5,1,4,3,1,5,4,2,3,5,1,3,5,4,1,5,1,4,5,2,2,1,4,3,4,3,3,5,2,3,4,1,4,3,4,4,2,5,4,1,1,1,4,4,4,5,2,4,2,4,3,2,1,2,3,1,2,3,1,3,3,5,3,2,1,5,4,1,5,1,1,5,3,2,1,3,3,4,5,3,5,3,2,1,3,4,5,1,3,5,3,5,1,4,5,5,3,2,2,4,1,1,3,5,5,3,4,2,5,5,3,3,4,2,1,5,3,3,4,2,2,3,2,5,3,1,1,3,4,3,3,4,1,4,3,2,5,2,3,5,4,4,3,5,1,3,2,5,4,5,1,2,5,2,3,4,1,1,3,5,1,1,3,1,2,1,2,4,1,2,5,3,2,4,1,1,5,1,2,2,2,4,2,3,2,5,5,4,1,2,3,3,4,1,2,1,4,3,1,2,3,3,5,1,5,2,3,4,1,1,4,4,1,4,5,3,2,2,2,5,1,1,5,5,1,3,1,1,2,4,2,3,4,2,5,1,5,5,5,4,2,4,3,2,3,1,4,1,2,3,2,3,5,3,1,3,1,5,3,2,2,2,5,4,1,1,1,1,3,3,2,2,4,1,3,1,3,3,1,4,2,1,1,5,1,2,4,4,4,5,2,5,1,2,5,5,3,3,3,2,4,5,1,4,5,4,2,4,3,2,3,4,3,2,4,3,2,5,5,3,1,3,3,2,5,4,5,2,2,5,5,4,3,5,3,5,1,5,5,4,1,3,3,5,1,1,5,1,1,2,5,3,1,1,5,4,4,1,2,5,3,5,5,1,4,3,5,4,1,5,4,3,4,5,2,2,4,5,1,4,2,5,4,3,2,2,1,2,2,3,5,3,4,3,5,3,2,3,3,3,2,3,2,4,5,4,1,5,1,1,5,2,2,2,4,5,3,3,2,5,1,4,2,1,5,2,5,4,2,5,4,2,4,3,4,4,3,3,2,2,5,2,1,1,4,5,4,3,1,3,1,3,4,5,1,3,5,1,5,1,5,4,3,5,1,1,3,1,3,4,5,5,2,2,4,5,5,5,2,3,1,5,3,5,5,4,2,5,4,4,5,5,2,3,5,1,4,5,3,3,1,4,3,2,3,2,2,5,1,1,5,4,3,2,5,5,3,2,4,5,1,1,2,4,4,5,4,4,1,1,2,2,4,5,1,1,3,4,5,4,1,3,3,5,1,5,4,1,1,5,2,1,5,1,3,4,5,2,1,3,1,3,1,3,5,3,1,4,1,3,2,3,5,2,5,4,4,3,5,3,1,5,4,4,5,1,2,2,2,3,2,4,3,4,2,3,5,4,4,3,3,1,5,2,3,3,3,5,2,4,1,3,4,1,2,4,5,4,4,1,5,5,2,3,4,5,3,3,5,2,4,5,1,2,2,2,5,1,4,2,1,1,4,5,3,4,5,5,2,1,5,3,5,3,3,4,3,5,3,3,1,3,3,2,4,2,5,5,3,4,2,5,3,5,2,4,5,5,2,1,4,1,1,4,5,1,5,1,4,5,2,4,1,2,5,3,3,2,4,5,4,4,2,3,2,1,1,4,5,2,1,5,5,3,1,5,1,3,2,3,2,5,4,5,4,3,2,1,3,4,3,1,1,3,5,5,2,5,1,2,2,2,3,3,5,3,3,2,1,3,1,4,3,3,5,5,3,2,2,3,4,1,3,5,4,2,3,2,2,4,4,5,1,5,4,4,5,5,2,3,3,1,4,2,4,1,2,1,4,5,1,4,5,2,5,4,5,3,4,5,5,4,1,4,2,3,5,2,4,5,4,4,2,5,4,2,5,3,3,5,5,2,2,3,1,2,1,5,4,3,4,5,3,4,5,2,2,1,4,3,4,5,5,4,5,3,5,4,4,2,4,3,3,1,3,1,2,4,5,3,1,5,5,4,4,4,4,1,2,3,3,3,1,1,1,3,1,5,2,5,3,5,4,5,1,3,4,3,5,4,4,4,4,4,1,1,5,4,5,1,5,3,2,5,3,4,3,3,3,2,5,3,5,2,4,5,5,4,3,3,5,3,3,2,2,1,1,1,3,5,4,5,2,5,3,3,1,5,2,1,1,2,1,2,3,2,5,3,3,2,3,1,2,4,1,5,3,4,1,5,1,5,4,3,4,5,3,5,2,1,3,3,2,3,5,1,2,5,3,1,1,2,4,5,2,1,5,5,3,5,1,5,3,3,3,1,5,1,4,5,4,1,1,2,1,2,4,3,1,5,3,2,2,2,3,5,2,4,4,1,3,1,5,3,3,3,3,4,4,3,3,5,4,5,2,4,5,4,2,2,1,1,1,2,4,5,4,3,1,3,1,5,3,2,3,5,5,3,2,5,4,3,1,5,3,5,5,5,3,3,4,4,5,2,1,1,3,3,1,5,4,5,4,2,2,5,1,5,4,2,4,2,1,1,5,2,3,4,4,5,4,5,5,3,4,5,1,2,3,5,1,2,3,2,2,2,4,3,1,3,1,3,3,3,2,3,5,3,4,3,3,1,4,1,3,5,4,1,3,3,3,1,3,4,2,4,1,3,5,2,4,5,1,3,1,2,2,5,4,5,3,4,1,2,5,4,2,4,5,4,2,1,5,2,2,3,5,5,2,1,2,5,5,1,2,4,5,5,4,5,5,5,2,4,2,3,3,5,1,3,2,4,5,3,4,1,1,4,2,1,5,5,1,3,4,4,3,5,3,4,4,3,4,2,4,4,1,5,3,5,4,5,1,1,1,5,2,4,1,5,5,4,3,3,1,3,2,5,4,2,1,2,5,2,4,3,5,5,4,3,4,1,3,5,4,5,2,3,1,2,4,5,5,3,2,4,5,3,5,4,5,1,3,3,3,3,2,4,4,5,2,1,3,2,4,5,2,2,1,2,5,1,4,1,1,3,2,5,1,4,3,4,1,1,5,5,3,3,2,1,5,5,1,4,1,3,3,3,4,2,3,3,1,2,4,3,4,1,3,1,3,1,3,1,4,2,3,5,2,5,2,3,5,5,1,1,2,3,2,4,2,2,5,5,2,3,5,3,2,2,5,3,1,3,3,4,1,4,5,3,2,5,4,3,2,2,5,5,3,1,4,2,1,3,1,1,5,4,1,4,5,5,1,5,1,2,5,1,3,4,2,5,4,1,2,3,4,4,2,1,2,4,4,3,1,2,2,2,1,3,4,1,5,5,3,5,3,3,2,2,4,4,2,1,1,4,4,1,2,2,4,1,1,2,4,2,1,4,3,5,2,3,2,1,1,1,1,1,5,5,1,2,4,5,4,2,2,3,5,2,1,2,4,5,5,3,4,1,1,3,5,1,3,5,2,1,1,5,3,5,5,3,3,3,3,5,5,2,3,5,1,5,2,5,5,4,1,3,3,4,5,1,4,1,3,2,2,2,3,1,3,4,4,5,2,1,3,4,1,1,3,3,4,4,2,3,4,3,2,1,5,4,3,1,2,2,3,3,3,1,4,4,2,2,2,2,3,1,4,5,3,4,1,2,2,3,3,2,1,5,4,4,5,4,5,1,5,3,1,4,1,1,5,4,2,1,4,1,3,3,4,4,4,1,2,2,4,3,1,3,4,4,5,1,3,4,3,1,4,1,1,3,1,2,5,1,2,5,2,5,5,2,2,1,2,5,3,1,3,3,1,2,3,3,3,5,3,2,2,4,3,1,2,3,1,5,3,4,1,1,4,2,5,4,3,1,5,3,3,3,2,2,1,2,4,2,2,3,4,1,3,3,3,1,5,3,4,3,3,5,4,3,2,3,5,5,4,3,5,3,5,1,1,2,1,4,1,2,1,5,1,5,3,2,1,1,3,5,4,1,1,3,4,2,1,5,3,3,5,5,2,1,4,1,4,3,1,5,3,5,3,3,4,3,4,4,5,5,5,5,4,1,4,5,4,4,1,5,5,5,1,3,5,3,2,5,3,3,5,4,3,3,2,4,5,1,3,4,2,5,5,3,4,2,3,1,1,5,4,1,2,2,3,5,1,1,5,5,5,4,1,2,4,5,4,3,3,5,4,1,1,1,5,3,5,4,3,1,5,1,5,1,3,5,2,5,5,1,4,3,2,3,2,5,1,1,1,3,1,1,3,3,4,1,5,2,4,5,3,5,1,5,5,2,5,3,1,2,5,3,5,1,1,4,3,1,1,5,5,1,5,4,1,3,4,5,4,1,5,1,3,4,2,4,2,3,1,1,5,4,5,5,3,3,1,3,2,2,3,2,1,2,5,2,4,1,3,5,1,3,2,2,4,2,2,5,3,3,2,5,1,2,5,1,4,4,3,4,4,1,5,1,1,1,3,5,4,1,3,4,3,2,3,3,1,2,2,5,3,3,1,4,5,5,5,4,2,1,5,5,3,3,4,1,1,4,3,3,3,2,5,2,3,2,4,2,5,5,5,1,1,5,4,5,5,4,5,3,4,5,4,2,1,4,5,3,4,2,1,2,2,2,2,3,3,3,5,4,2,1,2,5,3,5,4,2,5,3,4,4,3,2,1,1,1,4,2,5,2,3,3,4,2,5,5,5,2,2,2,3,1,4,5,3,1,4,4,2,3,1,4,3,2,5,3,4,1,3,1,1,3,5,2,1,4,3,2,4,2,3,2,1,3,2,4,4,5,4,2,2,5,5,1,4,2,5,2,5,2,2,2,5,4,3,5,5,5,2,3,4,5,1,4,2,1,1,5,2,3,2,1,1,3,3,3,1,5,5,2,4,4,2,5,4,4,4,4,2,4,3,4,5,2,4,4,4,5,4,2,5,5,2,5,3,2,5,3,5,1,2,4,4,4,4,4,4,1,3,5,3,2,2,5,1,4,1,2,1,1,4,5,3,5,2,4,4,2,1,4,3,4,2,5,5,3,5,1,4,1,2,1,4,3,4,2,5,1,1,2,1,5,5,1,2,3,4,5,4,1,2,4,4,5,3,3,3,5,2,3,4,5,1,5,2,5,3,3,2,2,3,3,4,3,2,1,4,2,2,1,5,4,1,5,4,2,3,5,1,1,4,4,3,4,1,1,3,4,4,4,5,2,3,4,4,5,5,3,2,1,4,3,3,1,1,3,5,1,4,3,4,3,4,4,2,1,3,2,1,3,1,2,5,1,2,1,4,1,4,4,4,1,2,1,3,4,1,5,4,5,3,3,4,5,1,1,2,3,2,2,1,1,2,4,3,3,1,2,3,1,1,3,5,4,3,4,2,1,4,2,4,1,4,1,3,4,1,4,5,5,2,2,5,3,5,2,2,3,3,4,1,5,2,1,5,3,4,2,4,3,4,1,2,5,1,1,5,1,2,5,1,3,3,4,3,5,4,1,4,2,5,4,4,3,3,1,4,5,5,5,4,3,4,1,5,5,2,3,4,3,3,2,3,2,4,1,1,4,1,2,3,2,4,2,2,2,4,2,1,4,2,2,4,1,3,1,4,1,2,3,5,3,5,5,1,2,1,2,4,5,5,5,2,3,3,4,3,2,1,5,1,3,4,2,5,1,3,5,2,1,1,4,2,1,2,5,2,1,4,1,3,4,4,4,1,1,2,5,1,4,1,1,4,2,4,4,4,1,3,5,4,5,5,2,4,3,1,2,5,2,1,2,3,2,5,1,4,5,3,5,2,1,1,5,2,5,5,5,2,4,3,3,4,2,5,4,5,5,4,3,3,1,5,5,5,2,1,3,3,1,3,3,1,4,1,2,1,4,1,1,4,4,5,4,1,2,5,1,2,4,2,1,1,3,5,1,1,3,2,5,2,2,4,3,3,4,3,4,5,3,3,1,3,4,1,5,4,5,1,1,3,5,4,3,4,3,5,3,2,5,4,5,4,2,1,2,2,3,3,1,2,3,5,3,2,1,5,3,5,1,5,1,4,3,5,4,5,2,3,3,2,1,4,5,2,1,4,5,4,5,1,4,2,4,1,5,4,3,4,1,5,2,2,3,3,4,4,2,5,3,1,3,3,3,4,3,1,5,3,4,1,3,2,5,2,3,5,2,3,5,1,4,3,5,3,2,1,1,4,1,2,3,3,3,2,2,2,1,1,3,5,4,1,4,4,4,1,1,5,4,4,3,4,1,2,5,3,5,3,1,4,5,3,1,2,2,3,3,4,4,2,5,1,4,3,1,1,5,5,2,1,3,1,3,2,4,3,4,1,1,5,2,1,1,4,2,1,1,4,4,1,3,1,1,4,2,3,2,5,3,3,3,3,2,4,2,4,2,4,5,2,1,1,3,4,4,3,3,2,2,4,5,3,3,4,1,2,4,3,5,2,1,1,5,3,1,5,5,3,2,5,1,5,1,4,2,5,3,3,4,2,3,2,5,5,1,3,1,4,1,1,3,3,5,3,4,3,4,1,4,4,2,3,2,1,2,2,4,4,5,5,3,1,3,1,4,5,4,3,4,3,1,2,4,1,3,5,4,4,1,4,2,5,1,5,3,3,3,5,5,5,1,5,1,3,4,1,2,2,2,5,5,5,5,2,3,4,4,3,4,5,5,4,4,3,2,1,1,2,2,1,4,4,3,2,4,3,4,4,5,1,1,3,4,1,3,5,5,3,4,1,3,2,3,2,2,4,4,3,4,4,1,1,4,2,3,5,4,1,2,5,3,5,3,4,3,1,3,5,5,5,1,4,2,4,2,3,2,3,3,3,4,5,1,4,1,5,3,4,4,1,1,5,2,3,2,2,5,3,4,5,5,1,2,1,5,2,1,5,1,5,2,4,2,1,5,3,2,3,5,5,3,3,3,1,1,5,2,4,2,2,4,4,2,4,2,2,2,1,3,1,4,1,5,3,3,1,2,2,5,5,4,5,1,4,5,1,1,1,2,3,4,1,5,4,4,1,3,2,3,3,1,3,3,4,3,5,5,3,2,4,3,4,5,5,2,2,4,4,2,4,3,2,1,5,1,2,2,2,2,1,1,2,3,4,4,1,3,1,2,4,4,5,5,3,3,2,2,2,5,2,4,2,3,4,3,5,2,4,5,4,3,2,3,2,2,3,3,3,2,2,5,4,4,4,5,3,2,2,2,3,2,2,1,3,4,2,5,3,5,5,1,5,1,3,2,1,4,5,5,5,5,1,2,1,5,2,1,5,4,3,2,3,3,2,2,2,4,1,5,4,3,5,5,5,1,2,4,5,1,1,2,2,3,2,5,4,2,3,3,5,3,4,1,2,5,4,1,4,3,3,2,2,1,2,1,1,5,5,4,3,2,3,1,4,2,3,4,3,3,4,2,1,3,5,2,2,5,3,3,4,5,4,2,3,5,1,3,2,3,4,3,2,1,5,3,1,2,1,4,5,3,4,5,4,2,2,4,4,5,4,2,5,4,2,2,2,5,3,2,4,4,3,4,1,2,3,2,4,4,4,5,2,1,3,4,4,1,1,5,4,1,3,3,1,2,3,1,2,4,5,1,3,5,1,5,2,4,2,5,2,1,4,1,3,2,5,2,4,2,4,1,4,3,4,4,3,4,4,1,3,4,1,2,1,4,5,5,1,5,1,5,3,4,1,3,4,2,2,3,1,2,4,4,4,1,4,4,2,1,4,4,1,1,1,3,2,5,4,4,2,1,1,5,4,5,5,4,5,1,5,4,5,5,4,3,5,4,1,1,1,4,2,2,3,5,3,1,4,1,1,1,4,3,5,1,3,2,1,2,4,2,4,5,2,5,5,3,1,4,3,5,5,1,3,1,5,1,2,2,4,2,3,2,5,5,4,4,4,1,1,2,2,1,4,3,4,1,2,5,5,5,2,5,3,2,5,2,4,1,4,4,2,4,5,5,1,5,2,2,3,4,3,2,5,2,1,4,4,4,5,4,5,3,1,4,1,3,1,1,5,2,5,4,4,3,3,1,2,2,4,4,3,4,1,1,2,3,2,5,4,1,2,1,2,1,1,2,4,4,2,1,1,2,5,5,5,2,3,2,2,1,4,5,2,3,3,4,3,3,2,2,2,2,2,1,4,5,5,3,5,4,2,4,3,3,4,1,1,4,3,5,4,4,4,5,1,5,5,2,5,5,3,2,5,5,2,4,4,1,4,4,4,2,4,1,2,2,1,3,1,3,4,5,3,2,2,3,4,4,4,2,3,3,1,1,3,3,5,1,1,3,2,1,5,5,4,1,5,2,4,1,5,5,1,1,2,2,1,5,3,4,3,2,1,1,1,1,2,4,1,2,2,2,1,2,5,3,3,4,2,2,5,1,3,5,4,1,4,3,4,4,5,4,2,2,2,2,2,1,5,2,5,1,3,3,3,3,1,1,1,2,5,2,5,3,3,1,4,2,4,2,2,4,1,1,3,4,4,1,2,2,5,2,5,2,5,4,3,1,1,2,1,2,2,4,4,2,3,5,1,3,5,1,1,3,2,2,1,2,4,5,2,1,2,4,5,3,4,1,4,1,5,5,3,2,4,2,4,5,1,5,2,5,5,5,5,2,4,4,3,5,5,2,3,1,4,2,2,3,3,3,5,1,5,1,5,2,3,2,5,1,3,3,1,4,4,5,2,5,1,3,3,4,5,4,2,2,5,5,5,2,2,2,1,2,1,1,1,3,2,3,1,3,1,5,3,1,1,5,2,2,4,5,5,1,1,5,3,5,2,3,2,3,3,1,4,1,4,1,3,5,3,5,5,2,5,2,3,1,3,4,1,4,5,5,1,4,3,2,4,1,4,5,2,1,3,2,5,5,1,2,4,4,2,3,1,1,2,4,1,3,1,4,5,4,2,5,1,5,2,1,4,2,3,4,5,3,2,3,2,4,4,4,1,5,1,2,4,2,2,5,4,3,2,3,5,4,2,3,5,3,5,2,2,1,3,3,4,3,5,3,1,5,4,1,1,1,5,3,5,5,2,1,5,5,5,2,1,1,1,5,5,4,1,5,3,4,3,1,1,1,5,5,4,2,4,4,4,1,2,4,4,2,3,5,3,2,2,5,3,5,5,3,1,2,2,2,3,5,3,5,2,5,3,2,5,2,1,2,1,5,1,3,2,3,3,1,1,2,1,3,3,3,3,5,5,4,3,2,5,3,2,2,3,1,5,1,5,3,5,5,4,2,4,4,4,2,1,5,2,1,5,4,4,2,2,3,1,5,1,2,1,2,4,3,4,3,4,4,5,4,1,2,5,2,4,3,4,1,4,5,4,1,3,5,3,5,5,4,3,1,1,3,4,5,1,2,3,4,5,2,1,4,3,4,3,3,2,5,2,3,5,1,4,3,3,4,2,2,3,5,2,3,5,4,3,1,1,2,5,5,5,4,2,5,5,5,1,4,1,3,5,2,3,2,4,2,3,4,1,4,5,5,2,1,5,4,2,5,4,4,2,4,5,1,3,1,5,2,4,5,1,3,5,3,1,1,5,5,4,3,4,5,5,2,4,4,2,2,5,5,5,5,5,5,4,3,4,1,3,4,3,1,1,5,5,3,4,3,3,2,4,2,4,2,4,5,4,5,1,1,5,3,1,5,3,1,5,4,2,4,3,4,5,3,5,4,4,2,2,3,4,2,3,3,5,5,3,4,4,3,3,3,3,5,4,3,3,5,3,5,4,3,2,5,1,4,2,4,2,1,2,5,2,5,1,5,2,3,3,5,5,1,4,2,3,1,1,3,2,1,1,2,5,3,3,5,1,5,1,5,5,1,2,3,2,4,4,1,5,2,3,4,1,1,1,5,4,4,2,4,2,3,4,2,4,2,1,5,5,5,5,4,5,5,1,3,5,1,3,5,1,3,5,2,3,5,3,3,3,3,1,2,2,4,2,3,5,4,2,5,2,3,5,1,1,1,1,3,3,4,5,4,2,2,4,4,3,5,3,1,2,5,1,5,5,5,3,3,2,5,4,1,1,2,5,5,4,1,4,3,5,3,4,3,1,5,4,5,1,1,1,4,5,2,5,2,3,4,3,1,3,3,3,1,2,4,3,1,2,4,5,4,5,2,4,4,3,1,1,2,5,1,1,1,4,2,4,1,2,1,4,1,5,5,3,3,4,1,3,2,5,1,1,2,3,1,4,4,3,1,1,1,4,2,5,1,2,2,5,4,3,3,3,1,1,2,1,5,5,1,3,1,1,1,2,4,4,4,4,2,2,1,2,3,2,5,3,1,4,3,4,3,4,3,2,5,3,4,2,3,3,4,2,2,2,4,1,5,1,1,1,1,3,2,5,2,4,5,1,1,3,4,2,5,4,4,5,4,2,5,2,3,3,3,4,1,2,5,3,5,2,5,1,3,5,1,2,5,1,3,1,3,5,2,3,5,4,2,4,1,4,5,3,3,3,5,5,3,5,1,3,4,4,3,1,2,3,1,2,5,3,2,1,1,3,2,3,3,5,1,1,4,4,1,3,4,5,4,2,3,1,3,4,4,5,1,5,1,3,1,4,2,1,5,1,4,1,3,2,3,1,2,1,1,4,1,3,3,4,1,3,5,5,3,3,4,1,5,4,2,5,2,1,2,3,4,1,5,1,2,3,1,5,2,2,1,3,1,1,3,3,1,4,5,3,2,2,1,2,4,3,5,1,4,2,3,5,4,2,3,1,4,2,4,2,1,1,1,4,1,4,4,1,3,4,1,1,4,1,1,3,1,5,4,2,3,5,2,1,2,2,2,2,2,5,2,1,1,4,2,5,2,3,3,3,4,5,2,1,1,1,5,1,3,1,2,1,1,5,3,2,5,2,4,4,1,1,2,3,3,3,3,4,4,4,4,2,2,2,3,4,2,3,1,2,2,4,5,5,1,3,5,2,5,1,3,4,2,3,3,1,2,5,5,3,5,4,2,1,1,3,4,3,2,3,4,3,2,4,2,1,2,2,1,2,3,2,2,2,2,4,2,2,4,5,4,5,3,2,4,4,4,1,2,3,2,1,5,3,5,2,4,2,5,1,3,4,4,2,5,2,4,4,4,5,4,2,3,2,5,1,1,2,2,4,2,5,1,2,4,5,5,1,2,1,1,5,3,2,2,5,2,1,1,5,3,5,2,2,1,4,2,2,2,1,4,4,5,5,3,2,4,5,3,3,1,3,1,4,4,1,2,2,2,3,3,2,4,1,3,1,1,4,1,1,1,4,4,2,2,4,4,5,5,1,1,1,4,1,4,3,4,1,4,2,5,5,4,5,3,1,5,1,4,5,3,4,5,3,1,3,2,3,1,5,3,5,4,4,5,4,1,1,2,4,3,5,4,5,3,1,2,1,4,1,1,2,3,4,4,4,2,2,2,4,3,1,2,3,1,2,1,4,2,1,4,2,1,4,3,4,2,4,3,2,4,3,4,2,5,2,3,5,4,3,4,4,4,2,4,2,5,5,4,3,2,1,3,5,5,4,4,3,2,3,3,3,5,5,4,5,1,1,1,4,2,5,5,2,2,4,1,3,2,1,4,3,1,4,4,2,4,1,1,4,2,1,3,1,3,1,4,2,3,5,1,4,3,2,2,3,2,3,3,2,2,4,2,5,2,4,2,3,3,1,1,5,2,4,2,3,4,1,4,5,1,5,3,3,2,2,4,1,3,3,3,5,3,1,3,5,3,5,2,2,2,1,3,5,4,4,1,5,5,2,4,4,4,1,2,3,5,5,4,3,1,1,2,2,2,5,5,3,2,2,3,3,5,3,4,1,4,5,3,4,4,1,4,5,3,5,1,1,5,1,1,2,1,2,5,5,5,4,3,2,3,1,4,4,5,1,2,5,3,3,2,3,2,1,3,1,5,3,3,2,1,5,4,2,2,2,3,1,2,4,2,5,4,5,2,2,2,5,1,5,4,4,4,1,2,1,5,3,3,3,1,3,3,4,2,5,1,4,1,4,4,4,5,1,2,4,1,1,4,1,4,1,1,1,2,4,5,3,2,3,3,3,5,2,1,5,1,1,5,1,3,4,4,3,2,4,2,3,1,2,1,4,4,1,1,3,4,3,5,4,4,5,5,2,5,5,2,2,1,3,2,5,1,2,4,2,2,3,4,5,4,2,5,2,3,3,3,5,3,4,2,3,3,5,1,3,2,3,4,3,3,1,4,4,1,4,2,3,3,5,2,3,2,4,5,3,4,5,2,5,3,2,4,2,2,2,2,4,5,3,3,4,2,5,5,3,1,4,1,1,3,4,4,3,3,5,2,3,3,1,3,4,2,2,1,5,3,1,1,5,3,4,5,4,3,4,2,4,4,4,2,4,5,4,3,1,1,2,4,1,1,4,3,4,5,1,4,5,2,2,2,4,3,4,3,2,1,1,4,1,4,4,2,1,2,3,1,5,2,3,2,5,2,1,2,4,5,5,1,1,3,5,4,1,4,2,5,2,2,1,1,1,2,1,2,5,4,2,5,5,3,4,2,1,3,5,5,5,2,2,5,1,4,2,4,1,5,1,5,3,4,3,2,4,4,5,5,5,5,5,1,3,2,4,5,1,1,2,1,5,2,2,1,3,3,5,5,1,5,3,1,1,3,2,3,2,3,2,2,3,1,4,2,5,4,5,2,5,2,1,1,2,5,1,3,3,5,2,2,2,3,4,1,1,1,5,3,2,5,5,5,1,3,1,2,1,1,5,2,3,2,3,3,3,4,3,3,2,3,2,2,4,1,1,4,4,4,4,2,1,1,1,5,3,4,4,1,4,4,1,3,5,1,1,3,5,2,3,5,3,1,4,2,1,3,5,1,4,5,4,5,4,3,4,4,1,4,3,2,5,5,2,4,1,1,2,1,3,1,1,3,4,2,3,3,2,4,5,1,2,5,5,5,2,2,1,5,3,1,5,4,4,1,4,5,3,2,5,4,3,4,2,4,5,1,4,1,2,2,2,5,1,2,4,1,4,5,1,2,2,3,2,4,2,5,4,4,1,1,2,5,2,2,5,3,1,5,3,2,1,3,4,5,4,5,5,1,2,5,4,2,1,2,5,2,4,4,2,3,4,5,4,3,3,4,2,3,1,3,5,3,5,2,1,3,1,5,4,4,3,2,5,1,5,1,4,1,2,3,1,4,2,3,4,3,1,5,3,3,5,4,5,5,2,5,1,1,2,5,1,1,3,4,2,4,5,5,4,1,5,5,3,1,5,1,5,3,3,3,5,3,2,5,4,4,3,2,2,1,2,5,2,3,3,2,4,3,4,2,5,4,1,3,2,5,5,5,2,2,1,4,5,2,5,1,5,3,5,4,5,3,3,5,3,4,1,1,5,2,3,2,4,3,1,4,5,3,2,3,1,4,3,5,5,5,1,2,3,4,1,3,3,3,3,4,2,5,4,1,4,1,2,2,2,3,5,1,2,1,5,5,2,3,3,4,2,2,5,2,4,3,4,4,3,2,3,4,2,4,4,1,4,4,1,5,3,2,3,2,1,3,1,4,3,3,3,4,2,5,1,3,3,1,3,5,2,5,2,5,2,4,2,2,2,2,3,3,1,1,3,5,5,4,4,3,1,1,4,4,2,4,5,4,2,4,2,2,3,4,3,4,1,4,4,5,4,4,5,3,2,2,5,3,4,2,3,3,4,5,3,2,1,4,1,3,3,5,5,2,5,3,4,5,1,4,5,4,1,4,2,5,5,3,1,5,4,5,4,1,1,1,2,2,4,2,2,4,5,5,1,4,5,1,2,5,3,2,5,4,2,5,1,1,4,2,5,1,1,5,1,5,1,2,3,2,1,5,1,4,1,5,1,1,3,3,1,3,5,1,3,1,1,1,4,2,1,3,4,4,2,1,3,3,4,1,2,3,5,4,4,3,3,5,5,1,2,3,3,4,5,5,3,1,5,2,2,2,1,4,3,4,1,5,1,3,5,5,1,5,1,5,2,5,2,3,4,2,5,1,1,3,4,4,3,2,1,1,1,1,2,2,4,4,2,2,3,2,4,4,1,4,4,5,3,3,1,4,5,2,4,1,5,2,3,2,1,3,3,5,1,1,2,2,3,1,2,3,1,2,4,3,1,4,1,4,2,2,4,2,1,5,2,5,2,1,4,2,5,5,3,4,1,2,5,4,2,4,3,1,4,3,4,5,1,5,3,4,3,2,4,1,5,1,4,5,3,2,1,2,1,4,2,3,2,5,2,1,1,3,2,2,3,2,3,2,1,2,4,1,4,1,2,3,4,3,5,4,3,4,3,3,2,5,4,4,5,5,3,4,1,3,2,1,1,2,1,1,1,5,1,2,1,4,5,3,3,5,1,3,2,3,2,3,3,2,1,3,3,5,1,5,5,1,1,5,4,4,3,5,5,1,1,2,1,5,5,2,5,1,2,1,4,1,5,4,4,5,4,3,3,3,4,3,1,1,1,2,5,1,1,4,3,4,4,4,2,2,4,2,1,1,1,3,2,2,3,3,5,5,3,5,3,5,1,5,1,2,2,1,3,3,2,3,4,3,3,5,1,3,5,5,3,3,2,1,1,5,1,2,1,4,3,3,5,5,4,3,5,2,3,4,4,3,5,1,1,4,2,3,3,2,4,1,5,3,5,4,5,4,2,2,3,5,1,3,4,5,4,2,2,2,2,4,2,4,5,3,1,2,2,4,1,3,1,3,2,5,4,2,5,4,5,1,1,3,3,1,4,2,2,5,4,4,3,3,2,3,5,5,2,2,5,2,3,3,4,2,5,3,4,4,3,4,4,4,2,2,5,5,2,5,4,1,4,3,5,4,5,3,3,2,2,3,1,4,4,2,2,4,3,5,5,1,2,2,1,1,1,5,3,3,5,3,2,3,4,2,5,4,1,2,1,2,2,1,2,5,5,1,2,2,5,1,2,4,3,2,5,1,1,5,3,2,2,3,5,1,2,4,4,1,3,5,2,1,3,2,3,1,1,5,4,1,5,3,4,4,2,1,4,2,5,5,2,2,1,1,4,3,4,1,2,1,2,2,4,4,4,3,4,2,2,1,1,3,2,3,3,2,1,1,5,4,2,4,5,3,3,3,4,3,4,1,2,3,1,2,4,4,4,5,2,5,1,3,4,5,4,1,3,5,1,5,4,4,4,4,2,4,3,5,4,1,2,1,4,4,3,5,2,3,2,5,1,5,3,3,4,4,1,4,1,1,4,1,5,3,1,1,5,4,4,5,3,5,1,4,1,1,1,5,5,1,3,2,5,3,2,3,2,1,3,2,5,5,2,1,1,4,3,4,2,5,2,1,1,5,4,2,2,5,5,2,3,3,4,4,1,5,4,2,3,2,1,3,3,5,4,4,3,5,4,4,2,2,5,4,4,4,4,4,3,3,2,1,5,2,1,4,3,4,4,5,5,1,5,5,2,1,4,2,2,1,1,4,2,4,4,4,1,3,3,5,4,1,4,3,2,5,4,4,1,3,3,2,5,1,1,5,5,2,5,5,1,5,2,5,2,5,3,5,1,1,4,1,1,5,4,1,2,2,2,2,2,2,1,4,2,5,4,3,2,5,5,2,3,5,1,2,1,4,4,4,4,1,2,3,4,1,3,2,2,3,5,4,4,1,2,4,1,3,1,3,5,2,4,1,2,4,3,4,5,5,5,1,1,3,2,2,5,3,2,3,3,4,1,3,5,3,2,3,5,4,2,4,1,2,3,1,1,1,2,3,5,2,4,4,4,1,3,5,2,1,4,1,2,1,4,4,3,2,2,1,4,3,2,3,1,3,5,1,1,2,2,1,2,5,4,4,2,2,4,3,1,4,4,4,4,5,3,2,1,3,1,3,4,5,4,3,4,2,5,1,3,5,5,1,4,4,1,5,5,2,4,2,2,4,5,3,2,5,4,4,3,3,1,2,4,2,3,5,1,2,1,1,5,5,5,2,2,5,2,4,2,2,1,5,3,4,5,1,1,4,4,4,4,5,5,1,1,4,5,4,5,1,5,2,1,1,3,2,3,3,5,3,3,4,2,1,1,1,2,4,3,4,5,5,2,2,3,2,4,1,4,1,4,5,2,3,4,4,5,1,4,4,4,2,1,4,3,5,1,3,4,1,5,1,1,5,1,5,2,3,5,1,3,2,4,3,2,2,2,1,4,4,2,5,2,5,2,1,2,1,1,4,4,3,1,3,5,2,2,3,1,3,4,5,5,4,5,5,1,1,1,3,3,3,5,3,3,3,4,3,3,2,5,4,5,4,5,2,4,3,2,5,2,5,3,3,4,4,3,2,3,5,1,3,5,2,3,3,5,5,1,3,4,3,3,1,5,3,4,2,4,3,3,2,2,3,2,2,4,1,1,5,3,3,2,5,3,4,4,3,1,5,3,4,3,1,1,5,1,4,1,3,4,4,3,3,1,1,2,5,4,2,2,2,4,2,5,3,4,1,1,2,4,3,1,4,4,1,2,3,5,3,2,4,4,4,1,5,5,4,2,2,1,3,1,1,3,3,2,5,3,4,3,1,3,4,1,5,2,5,4,3,5,2,4,5,2,3,3,3,2,3,5,5,3,5,5,4,5,3,3,1,1,5,5,3,3,2,5,3,4,4,1,2,3,1,2,2,5,1,2,4,3,5,5,5,3,4,4,2,2,2,3,2,2,2,1,2,2,3,3,4,1,4,1,2,5,2,3,1,1,5,4,3,1,2,2,2,2,1,4,1,4,5,3,2,4,3,5,4,4,4,4,4,2,4,1,1,4,2,2,1,1,5,5,4,3,4,4,5,1,5,5,4,2,4,3,1,1,3,2,3,5,3,2,1,3,3,3,3,1,1,2,5,1,4,3,5,5,2,2,4,1,2,4,3,5,3,2,3,2,3,1,4,4,5,3,5,2,2,2,4,2,5,2,1,2,1,5,5,2,2,2,3,1,5,2,2,1,5,1,1,5,1,5,2,1,4,1,4,5,4,1,4,2,2,2,5,5,4,5,3,4,5,2,1,1,5,1,1,2,2,3,4,2,5,4,1,4,1,2,5,4,3,4,2,4,5,4,3,1,4,4,5,5,1,5,4,3,3,3,1,1,1,1,4,2,5,3,2,1,4,4,5,1,1,3,3,5,3,2,5,5,2,2,2,3,3,4,3,5,5,1,5,2,3,4,1,3,3,3,2,1,1,1,4,4,4,5,5,2,4,5,4,3,1,1,5,5,2,3,2,4,1,2,3,4,5,2,5,5,3,2,4,3,1,2,3,1,5,1,1,5,3,1,3,2,5,5,4,1,1,1,4,5,2,2,5,2,1,4,2,5,4,5,5,1,2,3,3,3,2,3,1,5,2,2,2,1,4,1,4,4,5,2,4,1,1,1,5,2,5,1,1,4,2,1,3,2,4,3,1,5,5,2,2,1,3,3,2,1,2,3,3,4,4,1,2,2,5,1,4,3,1,4,3,1,2,2,1,4,5,5,3,5,3,4,3,2,4,4,4,5,2,5,3,3,2,3,1,2,1,1,5,4,4,3,3,4,5,2,2,4,2,2,4,2,3,1,3,3,3,4,2,3,5,3,1,3,4,4,2,4,2,2,5,1,5,1,4,4,4,3,3,3,3,2,1,1,3,1,4,2,5,2,2,2,3,1,5,1,5,2,4,4,2,3,3,3,4,2,4,5,4,1,5,4,3,5,2,2,4,2,5,1,1,4,5,1,3,4,2,4,5,1,5,1,3,2,1,3,5,4,3,5,2,3,4,2,4,4,4,1,3,1,4,3,3,1,3,4,2,5,2,4,2,3,5,5,3,4,2,2,4,3,5,3,3,1,2,2,3,3,3,4,3,5,2,4,5,3,1,4,4,3,5,1,2,3,5,5,1,5,3,2,2,5,3,1,3,3,5,1,2,1,1,2,2,5,4,3,4,1,5,1,1,1,4,4,4,2,5,1,1,2,5,3,3,2,5,5,2,3,4,5,2,2,5,4,1,2,2,2,5,4,2,1,3,4,3,1,4,4,1,2,3,1,3,1,3,2,4,5,3,5,5,5,4,4,5,4,1,4,3,1,4,4,2,4,3,2,2,3,2,5,3,5,1,1,4,5,3,5,5,2,2,3,2,1,2,5,5,2,1,4,4,4,3,3,5,1,3,4,5,4,1,4,3,2,3,1,2,5,5,1,5,5,5,2,1,2,3,4,5,2,1,5,3,1,5,3,1,4,3,2,2,3,4,1,5,2,1,4,5,3,2,4,4,4,3,2,3,1,2,5,2,4,3,2,5,5,2,2,4,5,3,1,1,2,2,5,5,2,2,1,1,4,5,1,4,5,2,4,5,5,2,2,2,5,1,5,1,2,1,4,5,1,1,2,3,2,2,1,3,4,1,3,1,4,1,3,3,5,3,5,4,4,5,5,3,1,1,4,1,1,4,5,3,3,1,4,5,4,3,3,5,4,2,2,3,4,1,5,3,2,4,5,1,4,1,5,5,2,3,3,5,3,1,3,3,5,4,4,4,2,4,2,3,5,3,4,2,5,4,5,5,4,4,2,2,4,2,5,5,5,5,2,3,1,1,4,2,5,5,2,2,2,5,2,4,1,1,1,4,5,4,3,5,4,2,4,2,4,5,1,3,3,5,1,2,3,1,5,4,4,5,4,3,3,1,4,5,3,4,2,3,3,2,4,5,4,3,1,3,1,3,3,5,1,4,5,5,1,4,1,1,1,1,1,5,2,2,4,4,2,2,3,3,4,2,1,3,5,3,5,4,2,1,5,5,5,4,3,5,3,4,5,2,3,1,4,2,1,1,4,3,5,1,5,3,5,1,5,5,2,2,2,1,4,5,5,5,1,3,1,2,5,3,2,5,3,5,3,5,5,4,5,2,4,2,1,4,5,2,5,5,5,1,4,3,1,3,1,2,5,2,1,4,4,2,1,4,4,3,4,5,2,3,5,5,4,5,4,1,4,3,3,2,4,2,3,3,4,2,1,2,4,5,5,5,1,1,1,1,2,5,5,3,5,4,2,1,2,4,1,4,5,2,1,2,3,1,5,1,4,5,5,5,4,5,3,4,5,3,2,1,4,1,4,5,1,1,5,2,2,1,5,2,2,2,5,3,3,4,5,3,2,4,5,1,5,3,3,3,1,2,1,4,3,3,4,4,4,5,2,2,3,1,5,4,4,1,5,3,2,1,2,1,4,3,4,3,4,3,5,3,4,4,1,3,2,2,5,5,3,2,1,4,2,3,3,4,5,4,2,4,3,3,4,2,4,3,3,4,4,1,3,2,4,2,5,3,2,2,4,3,3,5,3,5,4,5,5,3,2,3,4,2,4,1,1,4,4,3,3,2,3,4,3,2,3,4,4,3,4,1,2,4,5,3,2,4,4,2,2,5,5,3,2,2,2,1,1,5,4,4,2,2,3,5,4,4,2,4,4,4,1,5,3,1,2,3,1,5,3,5,4,5,1,1,2,1,2,1,3,3,2,3,5,4,3,1,5,4,2,1,4,1,2,5,4,2,4,4,2,4,1,3,3,1,5,5,1,4,5,3,5,5,3,2,3,3,2,5,1,4,3,2,2,4,1,2,2,2,3,2,1,2,1,1,4,5,2,1,5,5,3,2,3,2,3,4,4,5,1,3,1,2,4,4,5,4,2,4,4,4,3,4,5,1,1,2,3,3,1,5,3,4,4,5,1,3,5,5,2,3,4,4,5,1,4,5,4,2,1,5,5,3,4,1,4,4,2,2,1,1,3,2,4,3,2,5,2,2,4,2,3,2,4,2,2,5,5,2,5,3,4,5,1,5,2,3,4,4,2,4,4,4,4,2,3,2,1,5,5,4,3,3,1,5,4,2,5,3,4,4,4,4,1,1,2,4,2,4,5,1,2,5,2,1,4,2,2,2,5,2,4,3,1,2,5,2,5,1,3,4,5,2,3,3,1,1,5,1,1,3,1,3,3,3,1,5,2,1,5,4,5,1,5,5,5,4,5,3,2,4,5,4,3,1,2,4,4,4,1,4,1,1,1,3,1,1,1,2,3,1,4,5,4,2,5,2,5,5,5,2,4,1,2,1,4,4,1,3,1,5,3,4,1,3,2,5,2,4,4,2,5,5,4,5,3,1,2,5,4,4,2,4,1,2,3,5,4,3,3,5,3,1,4,2,1,3,5,1,2,4,1,5,3,2,4,5,5,4,5,3,3,3,4,4,4,2,5,4,5,1,1,1,2,3,4,1,5,4,2,3,1,4,3,2,3,1,2,4,2,4,2,3,1,5,2,1,3,3,5,2,3,3,2,2,4,3,3,5,4,1,1,3,2,4,1,3,4,4,1,5,1,3,1,1,4,2,4,4,3,5,4,4,4,1,2,2,1,5,2,2,2,2,3,2,4,2,1,4,4,5,2,4,3,1,2,1,5,3,3,2,2,1,3,3,3,4,3,1,3,1,1,3,4,3,3,2,4,5,5,2,3,4,1,1,3,3,2,3,4,1,3,5,4,5,2,5,2,1,4,4,1,3,3,2,5,4,2,5,1,3,2,5,3,4,2,2,4,4,4,3,2,2,5,1,4,3,3,2,5,2,5,3,2,5,4,3,2,2,4,4,4,3,1,5,2,4,1,2,4,1,5,4,4,5,2,3,3,2,3,3,3,5,1,3,2,2,1,2,2,3,3,3,4,3,4,4,1,5,3,1,3,4,3,4,1,5,1,3,3,1,1,4,4,5,3,5,4,5,2,5,1,1,5,1,4,2,4,5,3,2,1,2,2,5,3,2,5,5,1,4,4,5,2,1,2,1,2,5,4,4,2,4,4,3,5,4,3,2,5,4,4,3,3,3,5,3,1,1,2,3,4,1,1,5,3,5,2,5,4,5,2,5,2,2,5,3,1,2,4,3,1,2,2,3,2,3,3,2,3,4,2,4,5,5,4,4,3,5,3,1,3,2,3,5,2,4,3,5,1,4,1,5,3,3,5,5,5,2,2,5,3,5,1,1,5,1,2,2,1,2,3,4,5,2,1,2,2,4,3,4,4,5,1,3,2,5,4,3,2,4,3,1,5,1,1,1,1,5,2,2,1,5,4,5,3,1,5,1,1,3,2,1,4,3,4,5,4,3,5,4,5,2,5,5,1,3,3,4,1,2,2,2,5,3,2,4,5,5,3,2,5,4,3,4,2,3,1,2,3,3,2,2,1,2,3,5,5,3,2,5,5,4,5,2,3,4,2,5,5,2,1,4,5,5,1,5,4,4,5,4,4,2,1,3,1,5,2,1,2,2,1,1,4,1,1,4,2,1,1,2,2,2,1,4,1,3,4,1,1,3,2,2,2,1,2,5,4,4,3,3,1,2,1,3,3,2,4,1,1,1,3,1,2,4,2,1,5,2,4,1,1,2,2,1,3,2,3,4,5,4,2,2,1,4,4,1,2,4,2,1,3,1,3,2,2,4,4,3,2,2,5,3,5,3,4,1,1,3,4,1,3,1,5,3,4,5,1,1,2,4,5,1,1,3,3,4,5,1,4,5,2,1,1,5,3,5,5,3,2,2,4,5,2,5,3,2,1,5,4,5,4,5,4,4,2,1,3,5,2,4,2,1,2,2,5,5,1,4,1,5,3,1,4,1,3,2,1,4,3,5,4,1,5,5,2,4,3,4,1,4,2,2,2,1,2,4,3,1,5,2,3,3,2,2,4,4,2,4,4,5,4,1,1,3,5,1,3,5,1,2,4,3,4,3,2,3,4,2,3,2,2,5,5,1,3,2,2,1,3,1,3,2,4,5,2,4,4,4,5,4,5,4,3,5,3,2,1,5,3,5,5,5,4,5,4,1,2,2,1,1,2,3,1,1,4,2,5,5,5,4,1,2,3,1,5,4,4,1,5,4,1,2,4,2,4,5,2,3,2,1,4,5,3,2,5,3,2,5,5,4,4,3,4,5,3,1,4,5,5,4,5,1,2,4,5,4,3,5,5,5,1,3,2,3,5,4,4,2,3,4,3,3,2,2,4,2,2,2,1,2,5,3,1,5,5,1,5,5,1,1,5,1,1,4,1,1,3,2,4,4,2,2,5,3,2,4,2,4,3,5,2,4,4,4,2,3,4,1,4,2,1,3,5,2,5,3,3,4,3,4,5,3,5,4,5,4,3,2,2,4,2,5,2,4,2,5,3,2,4,2,3,1,5,2,1,3,1,4,4,5,4,3,2,5,3,3,2,5,4,4,3,1,1,1,1,1,1,5,3,5,5,1,3,5,1,5,3,4,3,2,2,5,1,4,5,2,2,4,2,3,4,2,2,2,2,4,3,4,2,5,1,5,4,2,5,5,2,5,5,5,3,1,1,5,4,4,3,3,5,4,1,2,5,5,5,3,3,1,4,1,2,3,1,1,1,2,4,2,4,4,4,1,5,3,2,2,2,4,2,1,2,3,1,3,4,4,2,5,3,2,4,1,4,1,2,3,4,4,4,2,1,1,1,4,1,1,5,5,3,3,1,1,1,3,3,5,5,5,1,2,4,1,2,2,5,2,1,5,4,5,4,2,3,1,1,5,2,1,5,1,5,4,5,1,4,5,1,1,1,4,1,4,1,3,4,2,3,1,4,5,4,2,2,3,3,5,5,5,4,2,5,2,4,4,3,1,1,4,2,4,2,3,1,1,2,4,1,5,1,2,2,4,4,3,4,5,5,5,3,1,3,1,4,3,5,1,1,5,2,5,4,1,3,5,2,4,2,4,1,4,2,4,5,5,1,3,4,1,3,4,4,5,4,2,5,4,3,1,5,5,2,2,3,5,4,1,3,3,4,3,5,5,5,4,2,5,1,4,5,1,5,2,4,3,3,2,5,5,3,5,3,3,2,4,3,4,4,5,3,4,5,3,3,5,2,3,3,2,5,5,3,5,3,4,2,2,4,3,2,5,1,1,1,2,3,4,4,3,1,1,5,5,1,5,1,1,2,3,4,2,3,1,3,5,2,3,4,2,3,1,5,3,5,2,3,2,1,5,3,3,1,3,2,1,2,1,3,4,2,5,1,2,3,4,1,2,2,3,1,2,4,3,3,2,1,2,5,1,2,3,3,5,3,3,2,2,1,4,4,2,4,2,2,2,2,2,3,4,5,4,1,4,1,2,5,3,2,2,2,1,3,4,3,1,5,3,1,1,1,3,1,3,5,4,3,4,5,3,2,3,2,1,4,1,2,4,4,1,2,5,4,2,3,4,3,3,4,2,3,1,2,5,4,4,1,5,2,1,4,1,4,4,5,3,3,1,4,4,5,1,2,3,4,4,3,1,1,4,3,5,3,2,5,4,1,5,5,4,2,4,4,5,1,4,3,5,5,3,3,3,2,2,5,2,5,4,1,2,1,5,3,5,3,2,5,1,2,2,1,5,1,1,4,2,2,3,2,4,1,2,1,3,3,5,4,3,4,2,5,2,1,3,3,3,5,4,3,2,5,1,2,2,3,2,1,4,3,4,4,5,4,3,3,5,3,1,5,1,2,4,3,4,5,3,3,1,1,3,2,4,2,4,5,3,5,4,5,2,1,1,1,2,4,4,5,4,3,4,5,4,2,4,2,5,4,1,1,4,5,5,4,5,3,4,4,4,2,5,1,2,5,1,5,4,5,5,1,2,2,4,3,5,4,5,5,1,5,5,5,5,1,4,5,1,1,1,1,2,5,1,2,3,3,3,5,1,5,4,2,1,1,3,4,5,3,4,3,2,2,3,4,2,1,5,3,2,2,5,1,4,3,1,5,1,1,3,2,3,2,5,2,1,4,2,5,4,2,5,2,1,1,5,1,1,1,2,2,4,1,5,1,4,1,5,2,1,1,4,5,4,1,4,2,2,4,5,5,1,5,4,2,5,2,5,2,2,3,4,2,1,5,3,5,4,3,1,4,4,3,3,1,3,4,5,5,1,3,1,3,4,3,4,2,5,4,4,2,3,4,2,3,1,4,5,4,4,4,4,1,5,1,2,5,3,3,4,3,1,2,1,2,1,4,2,4,5,2,1,3,2,5,5,1,4,2,4,4,3,5,2,5,1,1,1,4,1,5,3,1,1,5,5,2,3,1,2,5,3,4,4,3,4,4,2,4,1,3,1,1,5,3,5,1,4,3,2,5,2,4,2,1,4,5,2,2,4,5,3,2,1,5,4,1,5,5,5,2,5,5,1,4,2,2,2,4,5,3,5,3,4,4,3,2,4,3,3,5,1,2,4,1,3,2,4,2,1,5,3,3,1,3,5,3,5,2,4,5,5,1,5,3,5,5,1,4,3,4,2,3,2,4,3,4,2,4,1,3,4,5,5,5,2,5,2,5,4,5,3,2,5,2,3,5,5,5,3,1,2,1,5,5,1,3,3,1,3,5,2,5,4,3,2,4,4,5,3,4,2,5,3,5,3,3,2,2,3,1,4,4,1,3,3,2,3,5,1,3,5,2,5,3,2,5,4,1,2,1,1,1,4,5,2,5,3,3,3,3,1,5,3,4,2,5,1,3,1,2,3,5,4,2,1,3,4,5,5,3,2,2,3,3,3,1,3,2,4,3,2,1,1,3,1,5,3,3,5,5,2,2,2,2,5,3,2,5,3,3,4,5,5,1,2,4,2,4,4,5,2,2,4,2,5,5,5,2,1,5,5,1,1,3,4,1,2,3,1,3,5,1,1,3,3,5,4,4,5,2,4,5,1,4,4,3,2,4,3,3,1,2,2,5,3,1,1,1,2,3,3,2,4,3,2,4,1,1,5,3,5,2,3,4,4,2,1,3,4,4,2,5,2,5,1,2,3,1,3,5,5,4,4,4,4,1,5,1,1,3,5,1,1,5,3,2,3,4,2,4,2,5,3,4,5,1,5,3,5,5,1,5,5,2,5,2,4,3,3,1,5,5,2,2,5,5,1,1,4,2,5,3,3,4,1,5,4,1,1,4,3,1,5,4,5,2,2,2,2,4,4,5,2,5,1,3,3,4,4,1,1,5,2,4,1,2,1,1,1,5,2,3,3,4,4,5,4,2,3,4,3,3,5,4,3,4,4,3,4,4,1,4,3,2,3,1,4,5,4,3,1,3,4,1,1,1,1,3,2,4,4,4,2,5,2,3,5,4,1,3,2,5,5,4,2,1,3,1,2,2,4,5,5,1,3,5,4,5,4,4,5,3,5,5,3,2,4,4,3,1,2,5,5,2,1,2,3,4,2,2,5,1,5,5,1,1,2,5,1,3,1,1,5,5,3,5,3,3,1,2,1,5,3,3,4,2,1,1,5,1,1,2,2,1,4,4,2,3,4,4,1,3,3,2,2,2,3,5,4,2,5,4,3,5,1,5,3,4,1,4,4,5,4,1,1,5,2,1,5,2,2,2,3,5,5,4,2,1,4,3,5,3,3,1,5,1,4,4,5,2,4,1,5,5,3,2,5,3,5,1,3,1,2,4,3,3,1,1,1,1,4,5,2,5,1,2,2,5,1,4,5,4,1,2,1,4,5,4,3,2,3,5,3,4,2,4,4,4,1,5,5,3,3,3,3,4,3,2,3,4,1,3,1,3,3,3,2,5,5,5,3,1,3,4,5,3,3,3,4,3,1,2,1,5,3,1,1,1,2,5,4,3,5,5,2,2,4,1,5,3,3,1,4,4,5,3,3,4,2,2,1,2,4,3,3,3,2,1,3,3,5,4,3,4,5,1,1,3,4,3,5,1,3,5,1,2,5,3,4,1,1,1,5,3,2,2,1,2,3,2,1,4,1,5,1,3,3,2,4,5,5,2,3,4,3,1,1,4,1,1,3,2,3,1,4,3,5,2,4,5,4,1,2,3,4,2,5,5,4,3,1,2,1,4,1,3,3,5,2,2,5,3,5,3,5,4,4,2,4,1,1,3,2,3,4,4,5,1,1,4,2,3,1,1,1,5,1,4,2,3,2,1,5,1,4,3,4,1,5,5,4,1,4,3,1,1,3,4,1,1,4,4,1,1,1,4,1,4,4,1,5,2,4,2,1,1,1,2,4,5,5,3,4,4,5,1,4,2,4,2,5,1,3,3,3,1,4,2,3,1,4,2,2,1,3,1,1,2,3,2,4,4,5,5,3,3,3,3,3,4,5,2,1,5,2,5,2,3,2,1,1,3,1,5,2,4,1,2,5,1,5,2,2,4,5,2,5,4,2,5,3,3,3,5,3,2,1,1,2,2,5,4,2,2,4,3,1,4,4,5,4,4,3,1,1,2,3,1,5,4,4,2,3,2,2,5,3,1,2,5,3,1,2,4,3,4,4,1,3,2,3,2,2,3,5,5,5,4,4,5,3,4,3,4,5,1,5,4,1,4,5,1,4,3,1,3,1,2,1,5,4,5,4,1,1,2,2,4,5,2,5,1,2,5,3,1,2,1,1,4,5,3,4,2,3,4,5,3,4,4,3,2,3,2,5,4,3,3,5,2,2,5,4,2,3,2,4,4,2,2,2,1,5,4,1,1,3,2,3,2,4,5,4,5,2,4,3,4,1,4,2,4,1,4,1,4,4,4,3,2,1,4,4,2,4,5,3,2,3,5,3,1,3,5,1,3,1,4,1,1,4,4,5,2,4,5,3,1,2,2,5,3,2,5,3,5,4,3,2,5,5,2,1,2,4,4,1,4,3,1,2,3,1,3,2,4,4,5,2,3,5,2,1,1,3,1,2,5,2,1,5,3,1,2,1,3,3,3,3,5,2,3,2,3,4,3,5,4,1,3,4,5,1,5,2,4,3,1,4,2,2,4,2,5,4,1,1,2,4,2,4,1,1,1,5,4,1,2,1,3,4,4,4,2,4,1,2,2,1,2,2,3,5,3,3,3,5,3,1,2,2,4,1,5,3,4,3,2,4,4,3,4,4,2,4,3,1,1,3,3,2,4,4,2,5,5,5,4,1,3,4,5,5,5,3,1,3,1,4,1,1,1,1,5,4,5,4,1,4,1,4,2,5,4,3,2,3,1,2,1,4,4,3,4,2,5,5,5,4,1,3,1,5,3,2,1,5,5,4,3,3,3,2,3,2,3,3,1,4,3,5,5,3,4,2,5,5,5,1,1,2,5,5,5,2,4,4,2,3,5,2,2,4,1,3,5,3,2,5,2,3,1,5,2,4,3,5,5,5,2,1,4,1,5,2,4,1,1,3,4,2,4,2,4,5,5,3,3,1,1,1,5,5,2,1,5,1,4,4,3,2,4,4,1,4,5,4,2,3,3,5,5,2,4,1,3,2,5,1,5,1,1,1,2,4,4,2,1,5,3,3,1,2,2,3,5,2,4,1,2,4,2,2,1,1,1,1,2,2,4,4,3,4,1,4,1,1,3,2,1,5,5,2,1,2,5,1,1,2,2,2,1,1,4,1,4,5,5,4,2,4,1,2,5,1,1,3,4,4,4,5,5,2,3,5,2,5,5,5,2,5,1,1,3,3,2,2,4,4,3,5,2,3,1,4,5,2,5,2,3,2,1,2,1,2,3,4,1,1,1,3,2,1,2,2,3,3,4,4,5,2,4,1,4,5,5,4,2,4,2,4,3,2,1,3,3,2,1,1,2,4,3,3,4,5,5,1,2,2,5,3,2,1,2,4,5,1,2,1,2,3,4,1,4,4,3,2,2,5,2,2,2,4,4,3,5,3,2,5,1,5,1,2,1,4,3,5,3,3,4,4,4,1,4,3,2,4,5,4,4,1,4,3,3,5,5,4,5,3,5,2,5,3,3,1,2,2,1,4,5,2,2,3,4,5,5,3,1,3,4,4,5,4,3,2,4,3,5,2,3,2,1,5,5,4,3,3,1,3,2,4,4,3,1,1,3,5,1,4,3,4,4,5,5,5,3,2,1,4,3,5,3,2,5,5,5,2,5,1,3,5,4,4,2,3,2,3,4,2,4,2,3,5,4,1,2,5,5,2,5,5,5,2,2,5,5,1,2,4,4,4,1,5,3,4,5,5,5,4,3,4,5,1,3,3,3,5,5,3,2,2,3,2,4,2,4,3,3,4,1,2,2,3,1,3,2,2,3,3,2,3,1,3,2,3,1,3,1,3,3,1,5,5,5,5,3,5,3,2,2,5,1,4,1,2,3,1,3,2,2,1,1,5,3,5,3,3,2,3,3,5,5,1,5,1,3,2,1,2,2,2,5,1,3,3,2,2,5,5,5,1,2,2,4,4,5,5,2,5,4,5,5,5,2,5,2,3,5,1,1,1,4,2,4,5,5,2,3,2,2,4,3,2,3,1,5,1,4,3,5,5,4,1,5,5,5,5,5,3,4,1,1,2,4,2,1,4,3,5,1,3,1,4,1,4,5,1,5,4,3,1,3,5,5,2,4,5,1,5,2,5,4,5,1,3,1,3,5,5,5,5,2,2,3,3,4,4,2,2,1,2,1,4,1,3,2,2,2,5,2,3,5,1,1,2,4,5,4,3,3,5,3,3,2,1,3,5,4,1,2,4,4,5,1,2,3,5,4,2,3,5,3,3,3,1,2,4,3,5,4,5,1,5,1,3,5,2,3,5,5,4,2,5,1,2,5,5,1,3,1,4,3,2,2,1,4,1,3,3,1,5,2,2,3,4,1,5,5,4,1,5,5,4,3,4,1,1,5,5,1,4,2,1,3,4,3,5,1,4,5,4,1,1,1,2,3,3,3,4,1,5,1,4,3,4,2,1,2,3,5,2,2,3,1,5,5,3,3,1,3,4,3,4,1,5,3,2,4,4,1,1,3,4,2,5,4,5,2,2,4,2,5,3,1,5,3,5,3,1,2,5,5,3,3,3,4,1,5,1,2,1,4,3,2,2,2,5,5,2,3,3,4,2,5,5,1,2,5,3,3,4,2,2,5,5,1,1,3,3,4,1,3,4,4,2,1,5,5,2,3,2,4,1,2,1,2,3,3,5,4,2,2,3,3,4,3,2,3,3,2,4,5,5,2,1,1,4,3,1,5,1,5,3,2,3,5,5,2,1,5,4,4,3,2,5,5,1,2,1,5,2,4,1,2,1,5,2,4,2,4,5,2,3,2,2,3,3,3,4,5,2,5,3,3,5,1,3,2,2,2,1,2,4,2,4,3,1,3,4,1,1,5,4,4,5,5,2,1,4,4,2,2,4,3,3,1,4,4,5,2,4,5,3,3,4,2,2,4,2,2,1,2,4,5,2,3,4,1,4,5,4,4,2,3,1,3,4,3,4,2,3,4,5,5,5,5,3,4,5,3,3,1,5,3,1,5,1,4,4,5,5,4,1,1,5,1,2,1,1,4,1,5,4,2,3,1,4,3,3,2,2,2,2,5,4,1,2,2,4,2,2,2,5,4,5,2,3,3,3,5,4,5,3,3,5,3,2,5,5,3,5,3,1,2,4,1,5,3,4,2,2,4,2,1,1,5,4,3,4,3,4,5,4,2,3,2,3,1,2,1,2,5,5,2,3,4,5,4,1,4,1,1,1,1,2,1,1,2,2,3,3,5,5,5,2,3,5,5,3,1,5,4,1,1,1,1,2,5,4,4,1,2,4,4,1,4,3,5,2,1,1,3,3,1,3,4,5,5,3,5,4,4,1,3,1,4,3,1,1,3,3,1,1,3,2,4,5,5,4,3,5,5,4,4,5,5,4,4,2,3,4,1,3,5,3,5,2,2,4,5,3,3,2,5,4,1,4,3,1,1,4,5,5,2,5,3,5,4,5,3,2,2,4,2,4,1,3,1,3,4,5,3,1,5,1,2,4,5,3,2,4,1,2,1,3,5,4,2,1,2,2,2,2,2,3,3,5,1,1,2,4,1,1,4,1,3,4,2,5,5,2,1,3,4,2,3,1,4,3,4,4,2,1,5,3,5,2,4,1,1,1,3,5,3,2,2,5,5,1,3,1,4,5,5,5,3,5,4,4,1,3,3,1,2,2,3,5,4,4,3,4,3,1,3,4,2,3,5,1,4,2,1,4,3,3,2,4,5,3,5,3,2,4,5,5,4,3,5,5,4,3,4,4,2,2,3,2,5,4,2,4,2,2,3,4,1,4,2,1,4,1,3,3,5,4,5,3,1,2,1,1,3,2,3,5,3,3,3,2,2,5,2,4,5,5,3,3,4,1,5,5,5,2,3,5,3,1,3,4,4,5,4,2,2,5,5,2,1,2,4,5,3,2,4,4,3,1,4,2,4,2,3,1,3,2,4,5,3,4,4,2,1,2,3,3,5,1,1,2,4,1,5,2,2,4,2,3,2,2,4,2,2,5,4,5,5,1,4,2,3,2,4,1,4,5,2,2,4,5,5,1,1,2,1,5,4,2,5,1,1,1,4,5,1,3,3,4,5,4,2,1,2,5,1,2,3,4,1,3,5,3,1,1,1,2,1,2,4,5,3,2,2,5,2,3,4,3,5,1,1,2,4,5,3,3,4,1,2,1,5,1,2,2,2,3,2,3,3,5,4,3,2,5,5,3,3,4,2,4,1,2,4,1,1,4,1,3,5,3,2,1,3,5,1,4,4,3,1,4,5,2,1,5,2,5,2,4,4,4,3,5,5,5,1,4,2,2,5,5,3,4,5,3,1,1,2,1,2,1,1,2,5,5,2,3,3,1,2,3,4,3,2,5,5,2,1,5,3,2,1,1,3,3,2,1,5,1,4,5,4,5,2,5,3,1,1,5,3,4,5,4,4,2,1,3,3,4,3,2,1,1,1,1,5,1,5,5,4,1,4,2,1,2,3,5,4,4,5,3,4,3,4,5,2,3,4,1,4,5,5,2,3,3,5,4,2,2,1,2,2,4,5,4,3,4,4,4,1,1,4,4,5,4,1,1,2,4,4,3,5,3,5,1,4,3,3,5,1,2,5,3,2,5,3,2,3,5,2,1,5,2,2,2,4,2,2,2,2,1,1,5,1,4,1,1,3,2,4,2,5,2,2,2,5,3,4,5,5,1,1,5,3,2,3,5,3,1,5,3,4,3,2,2,4,4,2,4,5,1,5,5,5,4,4,4,4,1,5,2,3,2,5,4,5,5,4,1,4,5,2,5,5,2,2,2,4,2,5,2,5,2,5,2,3,3,3,4,5,2,3,5,5,1,3,5,1,4,5,1,5,2,4,4,4,5,4,5,3,4,1,4,5,2,4,5,2,5,3,1,1,1,2,3,4,2,3,5,2,1,1,3,5,2,4,3,3,1,4,2,1,3,5,2,5,5,2,2,1,5,2,4,4,3,4,2,1,2,5,4,2,3,2,3,2,3,4,3,3,2,4,4,1,3,5,5,4,3,5,3,5,4,3,5,3,1,5,4,4,3,5,4,5,5,3,5,3,2,2,1,3,1,2,3,3,5,5,2,4,5,1,1,2,4,3,3,5,4,1,4,2,4,4,5,3,1,1,3,1,4,3,4,5,2,3,5,5,1,4,4,2,5,5,2,1,4,2,4,1,1,1,4,2,1,1,2,1,2,2,5,1,5,1,3,4,4,2,4,2,2,1,1,5,4,4,1,4,3,2,2,3,1,3,2,2,5,4,2,5,2,5,4,3,4,4,4,3,3,5,3,2,5,1,5,1,5,1,1,5,5,4,3,3,4,3,1,1,3,5,2,3,4,3,5,4,1,2,1,2,1,5,3,2,3,3,2,1,1,2,2,5,4,5,4,1,5,1,3,3,4,1,5,3,4,2,5,2,5,5,3,4,4,2,1,2,3,2,3,2,5,4,2,3,5,5,2,5,3,5,2,1,5,5,4,4,2,4,2,2,2,1,2,4,3,2,5,4,5,1,4,2,1,5,2,4,1,2,1,2,4,2,1,2,5,1,5,2,3,4,3,1,3,4,1,2,1,2,4,1,4,4,1,2,4,2,5,5,1,5,2,4,5,1,3,1,2,4,5,4,1,5,1,5,2,2,1,2,3,5,1,1,5,5,2,4,2,4,3,1,5,4,4,2,2,1,3,3,4,2,3,5,1,1,2,3,3,4,1,5,1,3,3,1,2,4,2,1,5,4,2,5,3,1,3,3,5,2,4,2,3,2,2,5,1,5,2,1,2,5,2,5,3,2,1,3,3,5,4,4,5,3,1,1,3,2,3,2,4,4,4,4,5,2,2,3,3,2,3,4,2,3,1,2,1,2,1,4,2,5,2,3,2,1,3,4,4,5,3,1,4,1,2,2,5,4,4,2,3,4,3,1,5,5,4,2,5,1,5,5,1,5,2,5,2,5,4,3,4,1,1,1,2,1,5,5,5,1,5,1,2,4,1,2,2,5,1,4,4,4,3,1,5,5,1,1,5,4,4,1,2,1,5,3,1,3,4,3,4,5,4,1,3,5,3,2,5,1,1,4,2,5,4,3,5,5,2,5,1,1,3,5,3,4,1,1,5,1,1,4,1,3,5,5,4,4,2,3,1,5,2,1,4,1,2,5,1,1,4,5,2,5,2,2,3,3,4,5,1,5,1,1,4,2,4,1,1,4,1,2,5,2,4,2,3,3,5,3,4,1,3,5,2,4,1,4,5,1,3,4,2,2,3,5,2,5,2,1,2,2,2,5,5,5,4,5,2,4,1,5,4,4,2,4,2,5,5,3,3,2,1,5,1,1,1,4,3,3,3,1,1,3,3,5,1,2,4,4,3,1,4,4,1,2,3,1,3,5,4,1,4,3,5,5,4,5,1,1,1,2,2,1,3,3,5,1,4,5,5,2,5,5,5,2,5,1,1,2,3,4,4,3,2,4,5,4,5,4,3,3,5,3,5,2,3,1,2,1,4,1,4,5,2,2,3,1,3,1,4,4,1,5,1,5,5,3,5,3,2,3,5,4,1,5,2,5,1,1,4,4,2,3,4,2,2,1,3,2,5,4,5,3,3,4,4,5,5,3,2,4,2,2,1,3,2,5,3,5,2,5,3,5,2,1,3,1,4,3,1,4,3,4,3,2,1,1,2,5,2,3,3,5,5,5,2,5,5,2,1,2,2,2,5,3,5,5,4,4,4,3,4,5,1,3,5,3,4,5,5,3,4,5,3,5,2,5,1,3,3,4,2,3,3,4,3,5,2,2,1,1,1,1,1,1,5,1,4,5,5,5,4,3,5,3,3,4,3,5,2,4,2,3,5,1,2,2,1,3,2,4,3,5,2,1,1,5,2,3,2,3,4,5,3,2,5,1,1,4,2,1,5,3,3,5,2,3,5,4,2,3,1,1,4,1,2,5,3,1,3,1,3,5,3,1,3,1,4,2,5,2,2,5,3,1,4,3,2,1,3,4,1,5,2,1,2,3,5,1,2,2,1,5,5,3,4,2,2,1,1,1,1,1,3,1,5,3,4,3,5,5,5,1,1,3,1,4,5,4,3,5,2,4,1,3,5,2,2,2,2,3,2,1,3,3,3,1,4,4,2,3,2,5,4,4,1,1,4,1,1,3,1,4,1,1,4,1,2,2,5,3,5,3,1,2,5,1,5,5,4,4,2,5,2,5,5,5,2,1,1,1,1,2,5,3,2,3,1,3,5,2,4,2,2,1,2,4,2,1,2,5,4,1,5,3,1,3,5,5,4,1,2,2,2,3,2,1,2,3,4,2,3,3,1,2,4,1,2,4,4,4,1,2,4,1,4,2,2,4,1,5,2,5,4,1,3,5,4,4,5,5,5,4,1,1,4,5,4,4,3,3,5,3,5,5,3,4,2,5,3,2,4,2,4,4,2,2,3,4,5,1,2,1,3,3,3,4,3,1,1,1,3,5,3,1,5,1,1,1,3,3,5,1,5,2,1,3,4,3,5,1,4,2,3,2,3,2,4,3,3,5,4,5,3,2,4,3,3,5,4,5,2,5,3,3,1,3,1,3,5,2,4,5,1,3,4,3,3,1,1,2,4,3,5,2,4,2,2,2,1,3,5,1,3,1,2,3,5,2,1,2,1,4,1,3,5,4,5,3,5,4,2,2,3,4,4,3,3,5,4,5,5,4,4,3,5,3,4,1,4,2,5,5,2,2,3,4,1,1,2,1,3,2,2,4,3,2,4,3,3,2,1,1,1,2,4,1,1,3,4,5,4,3,1,2,1,1,1,3,3,2,5,2,1,5,4,5,1,2,2,4,3,5,3,4,1,2,3,1,2,3,5,2,3,3,1,5,2,5,5,1,2,5,1,1,3,4,4,5,4,5,3,5,2,1,1,4,4,5,2,5,2,1,1,2,3,3,1,5,4,2,2,4,4,2,4,4,3,3,4,2,4,2,5,1,2,2,5,2,1,4,2,1,1,3,3,2,2,1,4,5,5,5,1,3,2,2,1,5,5,2,4,1,2,5,2,3,4,3,4,2,1,1,3,4,5,4,3,4,5,2,2,4,4,2,5,4,4,2,3,4,4,2,2,3,5,5,1,1,4,5,2,5,5,4,4,1,1,3,4,3,4,2,4,3,4,2,1,4,4,3,1,2,1,3,3,3,4,2,2,3,1,2,3,2,1,5,4,5,4,2,5,1,3,2,5,1,2,4,1,2,5,1,1,3,5,4,3,1,5,1,2,1,1,5,5,5,5,1,4,2,2,5,5,3,2,1,5,5,4,1,4,3,5,5,4,5,5,4,1,1,5,3,2,3,1,2,3,4,3,1,1,3,4,1,3,1,1,5,2,3,4,1,3,3,1,2,3,3,5,5,3,4,1,2,2,3,5,2,2,3,5,3,1,2,5,5,3,1,3,3,2,4,1,4,1,4,3,2,4,5,4,2,2,1,1,4,1,2,1,2,4,3,4,5,1,1,5,3,1,2,4,3,5,5,5,3,4,4,2,4,4,5,2,3,5,3,3,1,1,5,1,1,3,5,3,3,1,3,5,1,1,2,3,3,4,5,2,5,2,2,1,5,4,2,2,1,4,5,4,1,5,4,5,4,3,5,2,1,1,3,5,3,4,3,1,4,4,5,2,3,1,5,5,3,3,5,2,2,4,2,4,2,3,4,5,1,3,5,2,2,1,5,1,2,4,3,2,4,5,1,5,1,4,4,5,5,5,5,3,5,4,5,2,2,5,5,2,5,3,3,2,1,2,2,1,4,3,4,1,1,4,3,4,3,5,2,3,3,2,1,5,4,4,4,5,5,1,5,5,1,5,3,3,1,3,2,3,5,1,4,5,2,3,5,1,3,2,3,1,1,4,5,4,2,5,2,4,2,5,5,5,1,2,3,1,5,3,3,5,5,2,4,3,5,1,1,4,2,2,2,2,5,5,1,2,1,3,3,1,1,4,1,4,1,5,3,2,2,2,1,1,2,1,2,4,3,1,3,2,5,2,4,4,1,5,2,5,1,2,3,3,2,2,1,5,2,3,5,3,4,1,1,4,1,1,3,2,5,2,1,2,2,1,4,1,3,5,1,2,2,1,3,4,4,5,2,4,1,4,3,1,1,1,4,1,4,2,3,4,5,3,1,3,2,5,2,2,3,4,2,2,3,1,5,4,3,4,4,3,1,1,1,5,2,3,5,5,3,4,3,2,4,5,3,2,5,3,5,1,4,4,4,1,1,2,2,3,4,2,2,3,4,5,1,4,1,5,1,5,3,4,4,5,1,1,2,3,2,5,4,3,1,5,2,3,4,5,3,3,3,5,5,3,4,1,3,1,3,2,2,5,5,1,1,2,1,3,2,3,4,2,1,1,3,1,4,3,5,3,2,5,3,5,4,3,4,4,1,2,4,2,4,1,2,3,4,4,4,1,4,3,2,1,2,4,2,5,1,4,2,4,5,2,3,2,3,5,3,1,3,4,4,2,2,2,1,1,1,4,2,5,2,5,1,5,5,2,5,5,5,1,5,4,5,1,5,3,2,1,2,3,4,2,5,2,4,1,4,3,4,4,2,1,2,5,2,2,2,2,4,3,5,3,1,4,4,5,2,2,3,1,5,1,1,4,3,5,1,5,1,3,1,5,5,5,1,2,1,4,5,3,5,3,4,5,3,1,3,3,3,4,4,4,2,1,5,2,4,2,3,4,2,1,2,2,4,4,4,4,3,1,2,4,1,3,1,3,3,1,2,1,3,2,4,1,3,1,2,2,5,3,5,4,1,2,4,5,3,1,3,1,4,5,2,5,5,3,3,1,4,4,3,4,4,4,1,4,2,1,3,2,5,2,3,3,1,5,5,4,5,3,4,4,4,1,5,4,5,1,5,4,2,3,2,4,5,5,2,2,1,5,2,3,3,5,2,5,1,5,3,1,3,3,5,4,5,4,1,1,3,4,5,4,2,4,2,2,5,1,1,2,3,1,1,1,5,1,5,2,1,1,1,3,4,1,4,2,3,5,2,3,5,1,5,5,5,1,2,4,2,1,1,1,4,2,3,2,2,2,1,4,4,2,1,5,5,5,2,5,1,1,3,2,3,1,1,4,4,1,3,3,5,1,1,5,3,1,4,5,5,2,2,1,3,3,1,5,4,4,3,2,2,5,3,3,4,4,3,1,4,1,5,2,1,5,3,1,1,3,1,5,1,2,1,2,1,4,1,2,1,4,5,1,1,4,3,4,3,4,4,1,5,1,5,1,1,1,5,5,5,4,3,4,2,3,4,4,1,1,5,4,5,4,4,4,5,1,1,1,1,2,3,2,2,3,4,4,1,5,3,3,4,1,1,5,5,3,5,1,4,1,3,1,5,3,3,4,5,5,4,4,4,3,4,2,4,3,1,2,2,5,3,1,4,4,5,4,4,1,1,1,2,1,5,3,2,3,2,5,2,3,5,5,3,2,3,2,1,1,4,5,5,1,2,2,1,3,3,4,2,1,5,2,1,5,5,1,4,3,3,3,1,2,2,4,5,2,1,3,1,5,4,4,5,3,2,3,3,2,3,3,4,3,4,3,4,4,2,4,1,1,1,2,5,5,4,1,3,2,4,3,4,5,1,2,1,5,4,1,2,5,2,3,3,1,5,3,2,3,1,1,3,1,4,5,2,3,4,5,5,1,1,3,4,1,1,3,5,5,4,4,4,5,4,2,3,2,4,1,3,2,2,1,3,4,5,3,4,1,4,1,2,4,3,4,2,3,1,4,1,3,1,4,2,5,4,2,2,2,5,2,4,3,2,3,2,3,4,2,2,4,3,5,4,3,2,5,3,4,2,2,5,5,2,3,4,4,3,1,2,5,1,4,5,2,3,4,4,1,2,4,2,2,3,2,4,5,1,2,1,3,4,2,3,1,2,1,3,3,5,5,4,1,1,5,2,4,1,3,5,1,5,5,3,5,1,4,2,5,2,5,4,4,1,3,2,2,3,3,4,3,2,3,5,1,5,2,2,1,1,2,3,5,3,2,4,5,3,2,2,5,2,2,3,1,4,2,5,3,3,1,1,3,2,4,1,2,2,5,4,5,5,1,2,1,4,2,4,4,3,2,2,4,1,1,1,5,1,5,1,2,4,4,1,3,4,4,4,2,2,4,5,1,2,1,3,2,4,2,3,2,5,4,5,4,5,3,5,2,4,3,5,4,2,1,3,2,1,4,3,2,3,1,4,5,2,1,4,3,4,1,4,4,2,2,5,1,1,3,5,5,5,1,3,4,2,1,5,2,5,4,2,1,4,2,3,2,4,3,4,2,4,4,1,1,5,2,4,2,2,3,1,5,5,1,1,4,1,1,5,2,1,2,3,2,5,3,2,3,4,1,1,4,3,2,2,3,3,1,1,2,2,5,2,4,5,3,4,4,2,1,4,5,2,4,5,3,2,1,2,4,4,3,2,2,1,5,5,4,4,1,5,5,2,5,2,1,5,4,2,1,2,5,4,5,3,5,2,2,1,2,5,3,3,4,4,3,1,1,3,1,5,2,1,5,3,1,1,3,4,2,4,4,3,2,5,5,3,3,3,1,2,2,5,1,4,4,4,2,4,2,5,2,3,5,5,2,3,4,2,1,1,5,4,1,2,4,3,2,5,3,5,5,5,1,1,5,3,2,2,3,4,1,5,3,3,2,1,3,3,2,2,5,1,3,1,5,5,4,4,1,4,4,2,2,5,5,1,5,2,4,2,1,4,3,1,3,4,5,5,2,2,5,3,3,3,1,3,5,1,3,2,4,4,3,5,2,1,2,3,2,5,2,5,2,5,4,5,3,4,1,5,5,2,5,4,2,3,2,5,5,3,2,2,5,3,3,1,2,1,2,1,4,2,1,3,1,2,2,3,5,1,2,3,1,3,5,1,2,1,1,1,4,1,1,4,1,1,5,1,1,3,2,2,1,3,5,2,3,3,4,2,3,5,3,2,3,5,5,2,3,4,5,2,2,3,4,1,1,2,4,3,4,3,5,2,3,2,2,3,2,3,5,1,4,1,4,2,3,4,5,5,1,2,5,3,2,5,4,1,4,3,5,3,2,4,1,2,4,3,5,3,4,4,4,3,2,5,4,5,4,2,5,5,3,5,5,2,1,4,5,5,1,5,4,5,2,5,2,4,1,5,2,1,4,5,5,5,1,2,2,3,5,5,3,1,2,3,5,2,5,2,2,4,3,1,1,3,3,4,2,1,5,5,1,3,1,5,3,3,4,2,3,5,4,4,4,5,4,2,5,3,2,4,2,1,4,3,3,5,1,4,2,4,1,1,5,3,3,3,3,4,4,3,2,5,4,1,2,2,5,4,4,4,3,2,3,3,2,1,2,2,2,1,1,4,1,4,1,1,1,2,3,2,3,1,5,1,4,2,4,2,4,2,2,4,2,3,2,5,5,4,1,1,3,5,5,2,5,5,3,1,1,1,1,4,4,5,3,1,4,4,1,3,2,5,1,5,1,2,4,5,3,1,5,2,3,1,3,5,3,5,5,2,2,1,5,3,5,4,3,4,4,4,5,1,4,4,1,5,2,2,4,2,1,3,3,3,3,3,2,3,3,5,2,2,1,3,1,5,3,4,4,4,1,1,2,2,1,3,4,1,5,1,4,2,1,4,4,1,2,4,5,3,2,2,2,5,1,1,2,5,2,3,2,5,1,2,2,1,4,4,1,3,5,5,3,5,1,1,1,2,4,4,5,5,3,3,1,4,3,5,1,4,4,2,5,4,3,3,3,1,3,3,2,5,5,3,2,4,1,3,2,5,4,5,5,1,5,4,1,5,5,3,2,1,1,3,4,2,4,4,3,1,4,4,1,3,2,1,5,5,4,4,5,4,1,3,1,1,4,1,1,3,4,1,3,2,4,1,1,5,1,3,2,5,3,3,4,1,3,2,1,3,4,1,4,3,4,2,5,5,5,3,2,3,2,2,5,4,1,1,4,3,5,4,2,2,4,3,5,3,1,5,1,1,3,1,3,5,5,5,4,2,5,5,5,3,2,1,4,3,3,4,4,5,4,5,3,3,1,2,2,1,2,2,5,3,3,2,1,4,2,5,4,5,2,3,2,2,1,1,1,2,1,2,1,1,2,4,5,5,2,4,2,2,1,3,3,2,5,1,2,5,1,4,1,4,2,1,4,1,4,4,1,4,2,5,4,4,2,5,1,4,4,3,3,2,2,2,1,4,1,4,2,1,1,3,4,2,3,4,1,3,5,4,4,5,2,4,2,4,5,2,2,1,4,5,4,2,3,4,1,2,5,5,3,1,1,1,4,4,3,3,4,2,1,2,1,2,2,5,2,4,2,5,5,1,5,4,3,1,3,5,1,4,2,3,2,3,2,3,5,5,3,4,3,1,3,4,5,3,3,2,1,3,5,5,4,1,3,2,1,4,4,2,1,1,4,4,1,1,5,2,4,5,5,2,1,5,2,2,1,4,5,2,4,2,2,1,3,2,3,4,1,4,1,1,2,5,4,3,4,4,3,4,1,3,2,2,5,5,3,5,5,2,1,1,1,5,1,3,4,5,4,3,4,4,3,3,1,3,1,5,2,4,4,5,4,5,2,5,4,2,3,2,3,2,4,3,5,2,3,2,5,3,5,1,2,1,3,5,2,2,3,4,4,2,2,1,1,1,4,1,3,5,4,1,4,5,3,2,2,5,4,2,3,3,1,3,1,5,4,5,4,4,2,3,2,3,1,4,1,2,3,5,1,1,4,2,2,1,3,2,5,2,3,4,1,2,4,5,1,4,3,1,5,4,5,5,1,2,1,3,3,1,4,1,5,1,4,5,5,3,3,5,5,2,5,1,2,4,5,5,5,4,2,3,3,4,1,4,5,3,4,1,4,2,1,4,2,2,5,5,2,2,3,2,2,4,3,5,3,3,5,4,1,5,2,1,1,4,3,2,5,3,2,1,1,5,3,4,4,1,1,1,4,5,1,1,4,4,3,2,3,4,1,2,2,1,3,5,4,2,5,3,1,5,3,2,5,2,4,2,1,1,5,1,5,5,5,2,2,1,3,5,4,2,1,4,1,3,2,1,1,4,2,3,2,3,3,5,3,1,5,4,3,3,3,2,5,1,3,4,4,1,3,2,2,5,1,1,4,1,3,3,1,1,4,5,2,3,1,2,3,1,1,1,1,3,1,3,3,2,5,1,3,5,1,2,2,3,3,4,1,5,5,2,3,3,2,5,4,4,5,2,1,3,3,5,5,2,3,2,3,2,5,5,2,4,2,1,3,5,3,2,5,3,1,2,3,1,4,5,3,1,4,4,1,2,1,1,1,1,5,2,4,5,5,4,5,5,1,1,3,2,2,1,4,2,5,3,4,2,4,3,5,1,5,5,2,4,1,3,2,4,3,2,2,3,5,3,1,2,4,2,3,3,4,5,2,5,3,1,1,3,1,2,5,2,4,4,4,1,3,3,1,4,2,4,1,2,3,3,5,3,3,5,3,5,2,4,1,4,2,3,2,4,5,2,1,5,5,3,2,2,3,1,2,5,4,5,4,3,3,3,2,4,4,2,4,1,1,2,5,3,5,1,2,2,4,2,1,1,3,1,3,2,4,4,1,4,2,4,1,4,2,4,3,2,5,1,2,4,1,5,3,4,3,2,3,5,2,4,3,5,4,2,2,1,4,4,5,2,1,2,3,2,2,4,1,4,2,2,1,2,4,2,2,1,4,4,2,3,4,3,5,5,1,3,3,5,3,3,5,1,4,2,1,3,1,1,5,5,2,5,3,4,4,5,3,3,4,2,2,3,3,3,3,1,1,3,2,2,4,4,1,1,4,4,3,4,5,5,1,5,3,3,5,3,4,4,5,5,3,1,3,3,4,3,1,3,5,5,4,5,5,2,2,5,5,3,5,3,1,2,4,4,1,5,2,4,2,2,3,4,4,1,2,2,4,5,3,1,5,3,1,5,5,1,1,5,3,3,2,2,4,5,2,5,4,5,2,2,5,5,4,2,2,3,4,2,4,5,1,2,1,3,5,2,2,2,2,3,2,3,5,2,3,1,5,5,4,4,3,5,2,4,1,1,5,5,1,3,2,3,4,3,1,2,1,5,1,4,1,2,1,5,5,4,5,1,4,3,3,5,5,3,3,3,5,4,2,2,3,3,5,1,5,3,3,1,5,1,1,2,5,5,5,2,4,5,4,2,4,2,5,2,5,2,3,4,2,4,4,1,3,1,2,5,1,4,5,3,2,2,4,3,5,3,5,2,3,3,3,3,3,2,5,3,5,3,3,3,5,5,5,1,3,1,1,4,3,3,5,4,5,3,1,5,2,5,2,3,5,1,2,3,3,2,4,5,5,4,2,2,1,5,5,2,1,1,2,1,1,2,2,1,4,2,1,4,3,1,1,3,3,2,5,4,5,3,4,3,2,5,2,2,5,2,1,3,4,5,3,1,3,3,5,2,3,4,1,4,5,3,1,5,3,3,4,4,1,4,5,4,3,4,2,3,5,4,5,4,1,4,5,5,5,4,4,3,3,4,2,3,1,3,5,5,2,1,2,1,5,2,2,2,5,3,5,4,2,2,5,4,2,2,1,3,2,1,5,2,5,5,3,3,1,5,5,2,5,2,4,5,5,2,5,2,3,5,3,5,5,2,4,3,5,3,2,4,2,2,3,4,2,5,2,5,2,4,4,2,4,1,5,2,3,1,3,3,1,2,3,3,3,2,3,5,5,1,5,2,1,5,4,2,1,3,4,2,4,1,3,2,2,5,3,1,4,4,3,1,3,5,1,4,4,1,2,3,3,1,2,5,3,2,3,4,4,4,1,2,2,1,4,5,5,2,2,5,2,4,3,4,5,5,3,5,1,2,2,1,3,4,4,2,5,2,3,2,2,2,4,5,3,5,4,1,4,5,3,3,3,1,2,3,1,4,2,2,3,1,5,3,4,1,2,1,5,2,1,2,1,3,2,2,2,2,5,1,3,2,5,1,4,1,1,1,1,1,4,1,2,1,1,3,4,3,2,1,1,5,4,5,5,4,2,4,4,3,1,3,1,4,1,4,2,3,5,1,1,5,5,5,2,1,5,1,5,5,1,1,1,4,5,1,1,1,1,1,5,1,1,4,2,3,2,4,1,4,2,1,4,3,4,5,3,3,1,5,3,5,4,2,5,2,1,3,4,2,5,4,4,1,4,4,1,3,2,3,2,4,4,1,4,5,5,1,4,1,3,5,4,2,5,3,2,5,1,4,3,5,1,3,1,1,2,2,4,1,2,3,3,5,4,3,1,3,1,3,3,5,1,3,2,1,1,4,1,3,3,2,5,4,2,3,1,3,3,4,2,3,3,3,2,2,5,3,3,4,1,5,2,1,2,2,1,1,4,5,4,5,1,1,1,3,1,3,3,2,1,4,2,2,3,1,2,1,3,1,1,5,3,4,3,4,5,1,2,3,2,5,3,5,5,5,5,2,4,4,5,5,5,1,1,3,5,5,5,1,2,1,3,3,2,1,2,2,5,5,5,3,1,2,2,4,5,5,4,1,4,4,3,1,2,1,2,2,5,2,1,4,4,5,3,5,2,5,1,5,2,5,2,1,1,2,4,2,3,4,2,5,4,1,4,1,3,3,2,4,1,4,1,1,3,5,3,3,4,2,5,4,3,3,3,2,5,3,1,3,3,2,2,1,2,5,3,1,1,1,1,2,5,3,4,1,4,3,3,3,2,4,3,5,4,2,5,5,5,1,2,4,4,3,4,5,1,4,3,1,1,2,1,1,1,4,3,4,4,1,5,5,3,2,4,5,3,1,4,2,2,2,5,4,5,1,2,1,4,4,4,3,5,4,2,5,5,5,3,3,2,4,4,3,4,1,4,3,2,2,5,5,3,3,3,3,2,4,3,2,5,1,3,5,5,5,5,1,5,1,4,2,5,4,5,2,3,1,3,3,1,1,2,2,2,3,1,1,5,3,4,2,5,5,2,1,1,3,2,4,4,5,5,4,4,3,5,4,3,2,2,4,2,2,1,1,2,5,4,3,3,5,1,2,2,4,5,5,1,3,1,5,3,3,1,3,4,1,2,3,2,1,3,5,5,1,5,4,4,3,5,4,2,1,2,4,5,2,4,5,1,3,3,5,2,2,4,5,1,4,4,2,2,4,3,3,5,2,4,4,3,2,4,3,2,5,4,4,4,5,5,4,5,3,2,3,2,5,5,3,3,2,1,5,5,2,5,5,5,2,2,2,3,3,4,4,5,4,2,5,5,4,1,3,2,2,5,4,2,4,2,2,4,5,4,3,1,1,2,5,2,4,1,3,4,2,5,2,3,3,5,3,2,3,2,4,4,3,1 });

            foreach (int[] input in inputs)
            {
                result.AppendLine($"The bird sited is {this.MigratoryBirds(input)} for this given array {string.Join(" ", input)}");
            }

            MessageBox.Show(result.ToString());

        }

        private int MigratoryBirds(int[] input)
        {
            if (input.Length == 0)
            {
                return 0;
            }

            Dictionary<int, int> dict = new Dictionary<int, int>();

            foreach (int i in input)
            {
                if (!dict.ContainsKey(i))
                {
                    dict.Add(i, 1);
                }
                else
                {
                    dict[i]++;
                }
            }

            int lv = -1, lk = -1, sv = -1, sk = -1;

            foreach (int k in dict.Keys)
            {
                if (dict[k] > lv)
                {
                    lv = dict[k];
                    lk = k;
                }
                else if (dict[k] == lv)
                {
                    sv = dict[k];
                    sk = k;
                }
            }

            return lv > sv ? lk : Math.Min(sk, lk);

        }

        private void btn_Best_Time_to_Buy_and_Sell_Stock_Click(object sender, EventArgs e)
        {
            /*
                Say you have an array for which the ith element is the price of a given stock on day i.

                If you were only permitted to complete at most one transaction 
                (i.e., buy one and sell one share of the stock), 
                design an algorithm to find the maximum profit.

                Note that you cannot sell a stock before you buy one.

                Example 1:

                Input: [7,1,5,3,6,4]
                Output: 5
                Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
                             Not 7-1 = 6, as selling price needs to be larger than buying price.
                Example 2:

                Input: [7,6,4,3,1]
                Output: 0
                Explanation: In this case, no transaction is done, i.e. max profit = 0.

                Time Complexity : O(n)
                Space Complexity: Constant space;

            */



            StringBuilder builder = new StringBuilder();
            List<int[]> inputs = new List<int[]>();
            inputs.Add(new int[] { 7, 1, 5, 3, 6, 4 }); //5
            inputs.Add(new int[] { 3, 2, 6, 5, 0, 3 }); //4
            inputs.Add(new int[] { 2, 4, 1 }); //2
            inputs.Add(new int[] { 1, 2 }); //1
            inputs.Add(new int[] { 7, 6, 4, 3, 1 }); //0

            foreach (int[] input in inputs)
            {
                builder.AppendLine($"The max stock price is {this.MaxProfit(input)} for the given input {(string.Join(" ", input))}");
            }

            MessageBox.Show(builder.ToString());
        }

        private int MaxProfit(int[] prices)
        {
            if (prices.Length == 0 || prices.Length == 1)
            {
                return 0;
            }

            int pmax = 0;
            int pmin = 0;
            int p = 0;
            int c = 0;
            int min = prices[0];
            int max = min;

            // 7, 1, 5, 3, 6, 4 // 2, 4, 1
            for (int i = 1; i < prices.Length; i++)
            {

                if (prices[i] < min)
                {
                    if ((pmax - pmin) < (max - min))
                    {
                        pmax = max;
                        pmin = min;
                    }
                    min = prices[i];
                    max = min;
                }
                else if (prices[i] > max)
                {
                    max = prices[i];
                }
            }

            p = pmax - pmin;
            c = max - min;

            return p > c ? p : c;
        }

        private void btn_Socks_Merchant_Click(object sender, EventArgs e)
        {

            /*            
                https://www.hackerrank.com/challenges/sock-merchant/problem
                Time Complexity  : O(N)
                Space Complexity : O(N)

             */
            StringBuilder result = new StringBuilder();
            List<int[]> inputs = new List<int[]>();
            inputs.Add(new int[] { 10, 20, 20, 10, 10, 30, 50, 10, 20 });
            inputs.Add(new int[] { 6, 5, 2, 3, 5, 2, 2, 1, 1, 5, 1, 3, 3, 3, 5 });
            inputs.Add(new int[] { 4, 5, 5, 5, 6, 6, 4, 1, 4, 4, 3, 6, 6, 3, 6, 1, 4, 5, 5, 5 });


            foreach (var input in inputs)
            {
                result.AppendLine($"There are  {this.sockMerchant(input)} pairs available for the given input {string.Join(" ", input)}");

            }

            MessageBox.Show(result.ToString());

        }

        public int sockMerchant(int[] ar)
        {
            int n = ar.Length;
            if (n == 0 || n == 1)
            {
                return 0;
            }

            HashSet<int> dic = new HashSet<int>();
            int counter = 0;

            foreach (int i in ar)
            {
                if (dic.Contains(i))  // Hashset.Contains is O(1) 
                {
                    counter++;
                    dic.Remove(i);
                }
                else
                {
                    dic.Add(i);
                }
            }

            return counter;

        }

        private void btn_Steps_To_Make_0_from_binary_Click(object sender, EventArgs e)
        {
            //int.Parse("10",System.Globalization.NumberStyles.Number)
            /*
            9.)A non-negative integer variable V is given. There are two actions available that modify its value: 
                • if V is odd, subtract 1 from it; 
                • if V is even, divide it by 2. 

                These actions are performed until the value of V becomes 0.
                For example, if V initially contains value 28, it will become 0 after seven steps: 7
                • V contains value 28, which is even: divide by 2 and obtain 14; 
                • V contains value 14, which is even: divide by 2 and obtain 7; 
                • V contains value 7, which is odd: subtract 1 and obtain 6; 
                • V contains value 6, which is even: divide by 2 and obtain 3; 
                • V contains value 3, which is odd: subtract 1 and obtain 2; 
                • V contains value 2, which is even: divide by 2 and obtain 1; 
                • V contains value 1, which is odd: subtract 1 and obtain 0. 

                Write a function: 
                class Solution 
                { 
	                public int solution(string S)
	                {
	                }
                } 
                that, given a zero-indexed string S consisting of N characters containing a binary representation of the initial value of variable V, 
                returns the number of steps after which the value o V will become 0, as described above. 

                For example, given string S = "011100" the function should return 7, because string S represents the number 28 and 28 becomes 0 after seven steps, 
                as explained above. 
                Write an efficient algorithm for the following assumptions: 
                • N is an integer within the range [1..1,000,000]; 
                • string S consists only of the characters "0" and/or "1"; 
                • the binary representation is big-endian, i.e. the first character of string S corresponds to the most significant bit;
                • the binary representation may contain leading zeros. 
 

             
             */

            StringBuilder result = new StringBuilder();
            List<string> inputs = new List<string>();
            long temp = int.MaxValue;
            inputs.Add("011100"); //28  and 7 steps to make it 0
            inputs.Add(""); //0 steps 
            inputs.Add(Convert.ToString(int.MaxValue, 2)); //int.MaxValue             
            inputs.Add(Convert.ToString(temp + 1, 2)); //int.MaxValue + 1 and 0 steps 
            inputs.Add(Convert.ToString(int.MinValue, 2)); //int.MinValue and 0 steps

            int steps = 0;
            int val = 0;
            foreach (string input in inputs)
            {
                steps = 0;
                val = 0;
                if (!string.IsNullOrEmpty(input) && input.Length > 0 && input.Length <= 32)
                {
                    val = this.ConvertBinaryToInt(input);
                    if (val > 0)
                    {
                        steps = this.solution(val);
                    }
                }
                result.AppendLine($"There are {steps} to make 0 for the given binary input {input} and its integer is {val}");

            }

            MessageBox.Show(result.ToString());
        }


        private int ConvertBinaryToInt(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return -1;
            }
            long power = 1;
            int counter = input.Length - 1;
            int val = 0;
            long result = 0;

            while (counter >= 0)
            {
                val = input[counter] - '0';
                if (!(val >= 0 && val < 2))
                {
                    return -1;
                }

                result += (val * power);
                power = power * 2;

                if (result > int.MaxValue || power > int.MaxValue)
                {
                    result = -1;
                    break;
                }

                counter--;
            }

            return (int)result;
        }

        private int solution(int input)
        {
            int step = 0;

            int val = input;
            while (val != 0)
            {
                if ((val % 2) == 1)
                {
                    val--;
                }
                else
                {
                    val = val / 2;
                }
                step++;
            }

            return step;
        }

        private void btn_Best_Time_to_Buy_and_Sell_Stock_II_Click(object sender, EventArgs e)
        {
            /*
             Say you have an array for which the ith element is the price of a given stock on day i.

            Design an algorithm to find the maximum profit. You may complete as many transactions as you like 
            (i.e., buy one and sell one share of the stock multiple times).

            Note: You may not engage in multiple transactions at the same time 
            (i.e., you must sell the stock before you buy again).

            Example 1:

            Input: [7,1,5,3,6,4]
            Output: 7
            Explanation: Buy on day 2 (price = 1) and sell on day 3 (price = 5), profit = 5-1 = 4.
                         Then buy on day 4 (price = 3) and sell on day 5 (price = 6), profit = 6-3 = 3.
            Example 2:

            Input: [1,2,3,4,5]
            Output: 4
            Explanation: Buy on day 1 (price = 1) and sell on day 5 (price = 5), profit = 5-1 = 4.
                         Note that you cannot buy on day 1, buy on day 2 and sell them later, as you are
                         engaging multiple transactions at the same time. You must sell before buying again.
            Example 3:

            Input: [7,6,4,3,1]
            Output: 0
            Explanation: In this case, no transaction is done, i.e. max profit = 0.
              

            Time Complexity : O(N) where N is the list of items in the given array
            Space Complexity: Constanct space

             */

            StringBuilder result = new StringBuilder();
            List<int[]> inputs = new List<int[]>();
            inputs.Add(new int[] { 7, 1, 5, 3, 6, 4 }); //7
            inputs.Add(new int[] { 1, 2, 3, 4, 5 });   //4
            inputs.Add(new int[] { 7, 6, 4, 3, 1 });   //0

            foreach (int[] input in inputs)
            {
                result.AppendLine($"Max for profit is {this.MaxProfit_2(input)} for the given input {(string.Join(" ", input))}");
            }


            MessageBox.Show(result.ToString());
        }

        public int MaxProfit_2(int[] prices)
        {
            if (prices.Length == 0)
            {
                return 0;
            }

            int profit = 0;
            int bought = prices[0];
            int sell = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > bought)
                {
                    profit += (prices[i] - bought);
                }
                bought = prices[i];
            }

            return profit;
        }

        private void btn_Container_With_Most_Water_Click(object sender, EventArgs e)
        {
            /*
                https://leetcode.com/problems/container-with-most-water/
                Given n non-negative integers a1, a2, ..., an , where each represents a point at coordinate (i, ai). n vertical lines are drawn such that the two 
                endpoints of line i is at (i, ai) and (i, 0). Find two lines, which together with x-axis forms a container, such that the container contains the most water.
                Note: You may not slant the container and n is at least 2.


                The above vertical lines are represented by array [1,8,6,2,5,4,8,3,7]. In this case, the max area of water (blue section) the container can contain is 49.

                Example:

                Input: [1,8,6,2,5,4,8,3,7]
                Output: 49
             
                Time Complexity : O(n) where n is the number of values in array
                Space Complexity: O(1) constant space
             */

            int[] a = null;
            List<int[]> inputs = new List<int[]>();
            StringBuilder builder = new StringBuilder();
            inputs.Add(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 });
            inputs.Add(new int[] { 2, 3, 4, 5, 18, 17, 6 });
            inputs.Add(new int[] { 1, 2, 1 });
            inputs.Add(new int[] { 1, 1 });

            foreach (int[] input in inputs)
            {
                builder.AppendLine($"The max area is {(this.MaxArea(input))} for the given input {(string.Join(" ", input))}");
            }

            MessageBox.Show(builder.ToString());

        }

        public int MaxArea(int[] height)
        {
            if (height == null || height.Length == 0)
            {
                return 0;
            }

            int max = 0;
            int l = height.Length - 1;
            int i = 0;
            while (i < l)
            {
                max = Math.Max(max, Math.Min(height[i], height[l]) * (l - i));

                if (height[i] < height[l])
                {
                    i++;
                }
                else
                {
                    l--;
                }
            }
            return max;
        }

        private void btn_Merge_Overlapping_Intervals_with_DSets_Click(object sender, EventArgs e)
        {

            /*
                 Time Complexity  : (M + N) where M is the number of internals in List A and N is the number of internals in List B
                 Space Complexity : O(M+N) 
             */

            List<IntervalRange> a = new List<IntervalRange>();
            //a.Add(new IntervalRange() { Start = 0, End = 3 });
            //a.Add(new IntervalRange() { Start = 2, End = 3 });
            //a.Add(new IntervalRange() { Start = 5, End = 12 });
            //a.Add(new IntervalRange() { Start = 13, End = 15 });

            List<IntervalRange> b = new List<IntervalRange>();
            b.Add(new IntervalRange() { Start = 1, End = 3 });
            b.Add(new IntervalRange() { Start = 5, End = 7 });
            b.Add(new IntervalRange() { Start = 7, End = 14 });

            List<IntervalRange> res = MergeIntervals(a, b);

            foreach (IntervalRange i in res)
            {
                Console.WriteLine($"{i.Start},{i.End}");
            }

        }

        public class IntervalRange
        {
            public int Start;
            public int End;
        }

        public List<IntervalRange> MergeIntervals(List<IntervalRange> a, List<IntervalRange> b)
        {
            List<IntervalRange> res = null;

            if ((a == null || a.Count == 0) && (b == null || b.Count == 0))
            {
                return null;
            }

            Stack<IntervalRange> stack = new Stack<IntervalRange>();
            int length = a == null ? 0 : a.Count;
            length = Math.Max(length, (b == null ? 0 : b.Count));

            int i = 0;

            while (i < length)
            {
                if (i < a.Count)
                {
                    Merge(stack, a[i]);
                }

                if (i < b.Count)
                {
                    Merge(stack, b[i]);
                }

                i++;
            }

            if (stack.Count > 0)
            {
                res = new List<IntervalRange>();
                while (stack.Count > 0)
                {
                    res.Insert(0, stack.Pop());
                }
            }

            return res;

        }

        private void Merge(Stack<IntervalRange> s, IntervalRange interval)
        {

            if (s != null & interval != null)
            {
                if (s.Count == 0)
                {
                    s.Push(interval);
                }
                else
                {
                    IntervalRange temp = s.Peek();
                    if (temp.End < interval.Start)
                    {
                        s.Push(interval);
                    }
                    else if (temp.End <= interval.End)
                    {
                        interval.Start = Math.Min(temp.Start, interval.Start);
                        s.Pop();
                        s.Push(interval);
                    }
                }
            }
        }

        private void btn_3_Sum_Click(object sender, EventArgs e)
        {
            List<int[]> inputs = new List<int[]>();
            StringBuilder result = new StringBuilder();

            inputs.Add(new int[] { -1, 0, 1, 2, -1, -4 });
            inputs.Add(new int[] { 0, 0, 0 });
            inputs.Add(new int[] { 0, 0, 0, 0 });
            inputs.Add(new int[] { 1, -1, -1, 0 });
            inputs.Add(new int[] { 3, 0, -2, -1, 1, 2 });

            foreach (int[] input in inputs)
            {
                result.AppendLine($"The sum for the given array {string.Join(" ", input)} is");
                var temp = ThreeSum(input);
                foreach(var t in temp)
                {
                    result.AppendLine(string.Join(" ", t));
                }
            }

            MessageBox.Show(result.ToString());

        }

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> list = new List<IList<int>>();
            if (nums == null || nums.Length == 0 || nums.Length < 3)
            {
                return list;
            }

            if (nums.Length == 3 && nums.Sum() == 0)
            {
                list.Add(nums);
            }
            else
            {
                Array.Sort(nums);
                int l = 0;
                int r = 0;
                int result = 0;

                for (int i = 0; i <= nums.Length - 3; i++)
                {
                    l = i + 1;
                    r = nums.Length - 1;

                    while (l < r)
                    {
                        result = nums[i] + nums[l] + nums[r];
                        if (result == 0)
                        {
                            if (list.Where(w => w[0] == nums[i] && w[1] == nums[l] && w[2] == nums[r]).Count() == 0)
                            { 
                                var inList = new List<int>() { nums[i], nums[l], nums[r] };                            
                                list.Add(inList);
                            }
                            l++;
                            r--;
                        }
                        else if (result > 0)
                        {
                            r--;
                            
                        }
                        else
                        {
                            l++;
                        }
                    }
                }
            }

            return list;
        }



    }
}
