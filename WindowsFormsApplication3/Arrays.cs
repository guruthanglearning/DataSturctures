﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
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

            /*
            
                Given two sorted integer arrays nums1 and nums2, merge nums2 into nums1 as one sorted array.

                The number of elements initialized in nums1 and nums2 are m and n respectively. You may assume that nums1 has enough space 
                (size that is equal to m + n) to hold additional elements from nums2.

                Example 1:
                Input: nums1 = [1,2,3,0,0,0], m = 3, nums2 = [2,5,6], n = 3
                Output: [1,2,2,3,5,6]
                
                Example 2:
                Input: nums1 = [1], m = 1, nums2 = [], n = 0
                Output: [1]


                Constraints:
                0 <= n, m <= 200
                1 <= n + m <= 200
                nums1.length == m + n
                nums2.length == n
                -109 <= nums1[i], nums2[i] <= 109
                
                Hide Hint #1  
                You can easily solve this problem if you simply think about two elements at a time rather than two arrays. We know that each of the individual arrays is sorted. What we don't know is how they will intertwine. Can we take a local decision and arrive at an optimal solution?
                
                Hide Hint #2  
                If you simply consider one element each at a time from the two arrays and make a decision and proceed accordingly, you will arrive at the optimal solution.

                Time Complexity     : O(M+N)
                Space Complexity    : O(1)

            */




            StringBuilder result = new StringBuilder();
            List<ArrayAndValue> inputs = new List<ArrayAndValue>();
            inputs.Add(new ArrayAndValue() { input1 = new int[] { 1, 2, 3, 0, 0, 0 }, m = 3, input2 = new int[] { 2, 5, 6 }, n = 3 });
            inputs.Add(new ArrayAndValue() { input1 = new int[] { 1 }, m = 1, input2 = new int[] { }, n = 0 });
            inputs.Add(new ArrayAndValue() { input1 = new int[] { 0 }, m = 0, input2 = new int[] { 1 }, n = 1 });
            inputs.Add(new ArrayAndValue() { input1 = new int[] { }, m = 0, input2 = new int[] { 1 }, n = 1 });
            inputs.Add(new ArrayAndValue() { input1 = new int[] {4,5,6,0,0,0 }, m = 3, input2 = new int[] { 1,2,3 }, n = 3 });


            foreach (var input in inputs)
            {
                string temp = $"for nums1:{string.Join(",", input.input1)} m : {input.m} and nums2:{string.Join(",", input.input2)} n:{input.n}";
                this.Merge(input.input1, input.m, input.input2, input.n);
                result.AppendLine($"Merge Sorted Array is : {string.Join(",", input.input1)} {temp}");
            }

            MessageBox.Show(result.ToString());

        }


        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            if (nums2 == null || nums2.Length == 0 || n == 0)
                return;

           
            int n1Len = nums1.Length - 1;

            while (n - 1 >= 0 && m - 1 >= 0)
            {
                if (nums2[n - 1] > nums1[m - 1])
                {
                    nums1[n1Len] = nums2[n - 1];
                    n--;
                }
                else
                {
                    nums1[n1Len] = nums1[m - 1];
                    m--;
                }

                n1Len--;
            }

            while (n - 1 >= 0 && nums1.Length > 0)
            {
                nums1[n1Len] = nums2[n - 1];
                n--;
                n1Len--;
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

            while (incrementer < input.Length)
            {
                // incrementer = 3 , sum = 10, reductionCost = 9
                if (incrementer == 1)
                {
                    sum += input[incrementer]; // 3
                }
                else
                {
                    reductionCost += sum; //, 9
                    sum += input[incrementer]; //6, 10
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
                        
                    1111
                       1
                    -------
                    1111
                    

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


            /*
                Time Complexity : O(N)
                Space Complexity : O(N)
             */

            StringBuilder result = new StringBuilder();

            List<int[]> inputs = new List<int[]>();
            inputs.Add(new int[] { 1, 2, 3, 4, 5, 6, 8, -20 });
            inputs.Add(new int[] { 3, 3, 4, 2, 4, 4, 2, 4, 4 });
            inputs.Add(new int[] { 3, 3, 4, 2, 4, 4, 2, 4 });
            inputs.Add(new int[] { 3, 3, 4, 2, 1, 4, 4, 2, 4, 4 });
            inputs.Add(new int[] { 1, 2, 1, 1, 3, 4, 0 });
            inputs.Add(new int[] { 3, 2, 3 });
            inputs.Add(new int[] { 2, 2, 1, 1, 1, 2, 2 });


            foreach (var input in inputs)
            {
                result.AppendLine($"Majority element is {this.FindMajorityElement(input)} for the given input array {(string.Join(",", input))}");
            }

            MessageBox.Show(result.ToString());
        }

        public int FindMajorityElement(int[] nums)
        {

            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            Dictionary<int, int> dict = new Dictionary<int, int>();

            int temp = 0;
            foreach (int i in nums)
            {
                if (dict.TryGetValue(i, out temp))
                {
                    dict[i]++;
                }
                else
                {
                    dict[i] = 1;
                }
            }

            temp = nums.Length / 2;

            foreach (int i in dict.Keys)
            {
                if (dict[i] > temp)
                {
                    return i;
                }
            }

            return 0;


        }

        private void Find_the_Number_Occurring_Odd_Number_of_Times_Click(object sender, EventArgs e)
        {
            // https://www.geeksforgeeks.org/find-the-number-occurring-odd-number-of-times/
            // Time complexity : O(n)
            // Space Complexity : O(1)

            int[] input = new int[] { 1, 2, 3, 2, 3, 1, 3 };
            /*
                00    01  11  00   10  01  00 
                01    10  11  10   11  01  11
                ---   --  --  --   --  --  --
                01    11  00  10   01  00  11
             */
            int res = 0;
            for (int i = 0; i < input.Length; i++)
            {
                res ^= input[i];

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
                while (true)
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

                int[] nums1 = new int[] { 1 };
                int[] nums2 = new int[] { 1 };

            */

            int[] nums1 = new int[] { 2, 3, 4, 5 };
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
            bool returnValue = false;

            if (input == null || input.Length == 0)
            {
                MessageBox.Show("Array is empty");
                return;
            }

            if (input != null && input.Length > 0)
            {
                returnValue = true;
                for (int i = 0; i < input.Length - 1; i++)
                {
                    if (input[i] > input[i + 1])
                    {
                        returnValue = false;
                        break;
                    }

                }
            }

            string result = returnValue ? "Sorted" : "Not Sorted";
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
            int r = (random.Next() % prefix[n - 1]) + 1; // random.Next(1, prefix[n - 1]); 

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
                    if (input[l] > 0)
                    {
                        l++;
                    }
                    else if (input[l] == 0 && input[r] > 0)
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
                        endIndex = i;
                    }

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        endIndex = i;
                    }
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
            /*
                1000
                0100
                -----
                1100   =  4
                

             */
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

                for (int i = 0; i < end; i++) // 6
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


                result.Append($"{string.Join(" ", input)} is {this.MaxDistToClosest(input)}  and {this.MaxDistToClosest_Easy(input)} \n");
            }
            MessageBox.Show(result.ToString());
        }


        private int MaxDistToClosest_Easy(int[] input)
        {
            int distance = 0;

            if (input == null || input.Length == 0)
                return distance;

            int seats = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 0)
                    seats++;
                else
                {
                    if (i == distance)
                        distance = i;
                    else if ((seats + 1) / 2 > distance)
                        distance = (seats + 1) / 2;
                    seats = 0;
                }
            }

            return Math.Max(seats, distance);
        }

        private int MaxDistToClosest(int[] input)
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

            return distance;
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
            tasks.Add(new TaskCoolDown() { Task = new int[] { 1, 1, 1, 1, 1, 1,2,3,4,5,6 }, Cooldown = 2 }); // 123-123

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
            public char[] CharTasks;
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
            //inputs.Add(new int[6] { 2, 4, 7, 9, 2, 4 });
            //inputs.Add(new int[8] { 19, 20, 21, 21, 20, 19, 18, 17 });




            foreach (var input in inputs)
            {
                int xor = 0;
                int y = 0;

                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

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
                stopWatch.Stop();
                result.AppendLine($"Bit Operation - Two unique values are {x} and {y} for the given array {string.Join(" ", input)} and total time is {stopWatch.Elapsed.TotalMilliseconds}");

                stopWatch = new Stopwatch();
                stopWatch.Start();
                HashSet<int> dict = new HashSet<int>();
                foreach (int i in input)
                {
                    if (dict.Contains(i))
                    {
                        dict.Remove(i);
                    }
                    else
                    {
                        dict.Add(i);
                    }
                }

                result.AppendLine($"HashSet - Two unique values are {string.Join(" and ", dict)} for the given array {string.Join(" ", input)} and total time is {stopWatch.Elapsed.TotalMilliseconds}");


                stopWatch.Stop();

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
            public int[] input1;
            public int[] input2;
            public int m;
            public int n;
            public string[] stringinput;
            public string stringVal;
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
            List<MoreThan1ArrayInputs> inputs = new List<MoreThan1ArrayInputs>();
            inputs.Add(new MoreThan1ArrayInputs() { a = new int[] { 2, 4 }, b = new int[] { 16, 32, 96 } }); //3
            inputs.Add(new MoreThan1ArrayInputs() { a = new int[] { 3, 4 }, b = new int[] { 24, 48 } }); //2
            inputs.Add(new MoreThan1ArrayInputs() { a = new int[] { 100, 99, 98, 97, 96, 95, 94, 93, 92, 91 }, b = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 } }); //0
            inputs.Add(new MoreThan1ArrayInputs() { a = new int[] { 2 }, b = new int[] { 20, 30, 12 } }); //1
            inputs.Add(new MoreThan1ArrayInputs() { a = new int[] { 1 }, b = new int[] { 100 } }); //1
            inputs.Add(new MoreThan1ArrayInputs() { a = new int[] { 3, 9, 6 }, b = new int[] { 36, 72 } }); //2       
            inputs.Add(new MoreThan1ArrayInputs() { a = new int[] { 1 }, b = new int[] { 100 } }); //9
            inputs.Add(new MoreThan1ArrayInputs() { a = new int[] { 51 }, b = new int[] { 50 } }); //0
            inputs.Add(new MoreThan1ArrayInputs() { a = new int[] { 2, 3, 6 }, b = new int[] { 42, 84 } }); //2

            int lcm = 0;
            int gcd = 0;
            int counter = 0;
            foreach (var input in inputs)
            {
                counter = 0;
                lcm = this.LCMForArray(input.a);
                gcd = this.GCDForArray(input.b);

                for (int i = lcm; i <= gcd; i += lcm)
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

        public class MoreThan1ArrayInputs
        {
            public int[] a;
            public int[] b;
            public int[] c;
            public int[] d;
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
            inputs.Add(new ArrayAndValue() { input = new int[] { 2, 2, 1, 7, 5, 3, 4 }, find = 4 });
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
                    if (r > 0)
                    {
                        sum += fr[k - r];
                    }
                    else
                    {
                        sum += fr[0];
                    }

                    fr[r]++;

                    /* sum = 3
                        fr : 
                          0:0
                          1:3
                          2:2
                          3:1
                        
                     */

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

            int lv = -1, lk = -1, sv = -1, sk = -1, dicValue = 0;


            foreach (int k in dict.Keys)
            {
                dicValue = dict[k];
                if (dicValue > lv)
                {
                    lv = dicValue;
                    lk = k;
                }
                else if (dicValue == lv)
                {
                    sv = dicValue;
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
            /* string input1 = "101";
            int i1 = input1.Length -1;
            int pow1 = 1;
            int result1 = 0;
            
            while (i1 >=0)
            {
                result1 += ((input1[i1] - '0') * pow1);
                pow1 *= 2;
                i1--;
            }

            MessageBox.Show($"{result1}");
            */



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


        private int? GetInteger(String s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return null;
            }

            int incr = s.Length - 1;
            int pow = 1;
            int val = 0;
            int result = 0;
            while (incr >= 0)
            {
                val = s[incr] - '0';
                if (val > 1)
                {
                    return null;
                }

                result = result + (val * pow);
                pow *= 2;

                if (result > int.MaxValue || result < int.MinValue)
                {
                    return null;
                }

                incr--;
            }
            return result;
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
            int r = height.Length - 1;
            int l = 0;
            while (l < r)
            {
                max = Math.Max(max, Math.Min(height[l], height[r]) * (r - l));

                if (height[l] < height[r])
                {
                    l++;
                }
                else
                {
                    r--;
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
            a.Add(new IntervalRange() { Start = 0, End = 3 });
            a.Add(new IntervalRange() { Start = 2, End = 3 });
            a.Add(new IntervalRange() { Start = 5, End = 12 });
            a.Add(new IntervalRange() { Start = 13, End = 15 });

            List<IntervalRange> b = new List<IntervalRange>();
            b.Add(new IntervalRange() { Start = 1, End = 3 });
            b.Add(new IntervalRange() { Start = 5, End = 7 });
            b.Add(new IntervalRange() { Start = 7, End = 14 });

            StringBuilder result = new StringBuilder();

            result.AppendLine($"Interval 1 : \n{this.PrintIntervals(a)}");
            result.AppendLine($"Interval 2 : \n{this.PrintIntervals(b)}");

            List<IntervalRange> res = MergeIntervals(a, b);

            
            result.AppendLine($"Result  : \n{this.PrintIntervals(res)}");

            MessageBox.Show(result.ToString());
                
        }


        private string PrintIntervals(List<IntervalRange> res)
        {
            StringBuilder result = new StringBuilder();
            foreach (IntervalRange i in res)
            {
                result.AppendLine($"{i.Start},{i.End}");
            }
            return result.ToString();

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
            /*
            
                Given an array nums of n integers, are there elements a, b, c in nums 
                such that a + b + c = 0? Find all unique triplets in the array which gives the sum of zero.
                
                Note: The solution set must not contain duplicate triplets.

                Example:
                Given array nums = [-1, 0, 1, 2, -1, -4],

                A solution set is:
                [
                  [-1, 0, 1],
                  [-1, -1, 2]
                ]


                Time Complexity : O(N) where N is the list of items in the array
                Space Complexity : O(log N)
             */

            List<int[]> inputs = new List<int[]>();
            StringBuilder result = new StringBuilder();

            //inputs.Add(new int[] { -1, 0, 1, 2, -1, -4 });
            //inputs.Add(new int[] { 0, 0, 0 });
            inputs.Add(new int[] { 0, 0, 0, 0 });
            //inputs.Add(new int[] { 1, -1, -1, 0 });
            //inputs.Add(new int[] { 3, 0, -2, -1, 1, 2 });

            foreach (int[] input in inputs)
            {
                result.AppendLine($"The sum for the given array {string.Join(" ", input)} is");
                //var temp = ThreeSum_New(input);
                var temp = ThreeSum(input);
                foreach (var t in temp)
                {
                    result.AppendLine(string.Join(" ", t));
                }
            }

            MessageBox.Show(result.ToString());

        }

        public IList<IList<int>> ThreeSum_New(int[] nums)
        {
            if (nums == null || nums.Length < 3)
                return new List<IList<int>>();

            var result = new List<IList<int>>();
            if (nums.Length == 3 && nums.Sum() == 0)
            {
                result.Add(nums.ToList<int>());
                return result;
            }

            Array.Sort(nums);
            int s = 0;
            int res = 0;

            for (int i = 0; i < nums.Length - 2; i++)
            {
                res = BinarySearch(nums, i + 2, nums.Length - 1, s - (nums[i] + nums[i + 1]));
                if (res > 0 && (nums[i] + nums[i + 1] + nums[res]) == s)
                {
                    result.Add(new List<int> { nums[i], nums[i + 1], nums[res] });
                }
            }

            return result;


        }

        private int BinarySearch(int[] nums, int l, int r, int search)
        {
            if (nums == null || nums.Length == 0)
                return -1;

            int result = -1;
            int mid = 0;

            while (l <= r)
            {
                mid = (l + r) / 2;
                if (nums[mid] == search)
                    return mid;
                else if (nums[mid] > search)
                    r--;
                else
                    l++;
            }


            return result;

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
                for (int i = 0; i < nums.Length - 2; i++)
                {
                    if (!(i == 0 || nums[i] != nums[i - 1]))
                        continue;


                    l = i + 1;
                    r = nums.Length - 1;

                    while (l < r)
                    {
                        result = nums[i] + nums[l] + nums[r];
                        if (result == 0)
                        {
                                list.Add(new List<int>() { nums[i], nums[l], nums[r] });                                                        
                                while (l < nums.Length -1 && nums[l] == nums[l + 1])
                                    l++;
                                while (r < nums.Length - 1 && nums[r] == nums[r - 1])
                                    r--;                                                         
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

        private void btn_New_Year_Chaos_Click(object sender, EventArgs e)
        {
            /*            
                https://www.hackerrank.com/challenges/new-year-chaos/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=arrays&h_r=next-challenge&h_v=zen&h_r=next-challenge&h_v=zen
                https://www.youtube.com/watch?v=YWYF6bOhPW8

                Time Complexity : O(N) where N is the length of the item in the array
                Space Complexity: O(1) constant space
            */


            StringBuilder result = new StringBuilder();
            List<int[]> inputs = new List<int[]>();
            inputs.Add(new int[] { 2, 1, 3, 4, 5 });
            inputs.Add(new int[] { 1, 2, 5, 3, 4, 7, 8, 6 });
            inputs.Add(new int[] { 5, 1, 2, 3, 7, 8, 6, 4 });
            inputs.Add(new int[] { 1, 2, 5, 3, 7, 8, 6, 4 });

            foreach (int[] input in inputs)
            {
                result.AppendLine($"Number pribe for the given queue is {(string.Join(" ", input))} is {this.NewYearChaos(input)}");
            }

            MessageBox.Show(result.ToString());
        }


        private int NewYearChaos(int[] q)
        {
            if (q == null || q.Length == 0)
            {
                return 0;
            }

            int swapCounter = 0;
            for (int i = q.Length - 1; i >= 0; i--) // Length = 4   Data=  1, 2, 5, 3, 7, 8, 6, 4  // 1, 2, 3, 4, 5, 6, 7, 8  
            {
                if (q[i] != i + 1)
                {
                    if (i > 0 && q[i - 1] == i + 1)
                    {
                        swapCounter++;
                        Swap(q, i - 1, i);
                    }
                    else if (i > 1 && q[i - 2] == i + 1)
                    {
                        swapCounter += 2;
                        Swap(q, i - 2, i - 1);
                        Swap(q, i - 1, i);
                    }

                }

            }
            return swapCounter;

        }

        private void btn_3_Sum_Closest_Click(object sender, EventArgs e)
        {
            /*            
               Given an array nums of n integers and an integer target, find three integers in nums such that the sum is 
               closest to target. Return the sum of the three integers. You may assume that each input would have exactly 
               one solution.

                Example: Given array nums = [-1, 2, 1, -4], and target = 1.

                The sum that is closest to the target is 2. (-1 + 2 + 1 = 2).

                Time Complexity : O(n^2)
                Space Complexity : O(1) constant space
           */

            StringBuilder result = new StringBuilder();
            List<ArrayAndValue> inputs = new List<ArrayAndValue>();
            inputs.Add(new ArrayAndValue() { input = new int[] { -1, 2, 1, -4 }, find = 1 });
            inputs.Add(new ArrayAndValue() { input = new int[] { 0,0,0 }, find = 1 });



            foreach (var input in inputs)
            {
                result.AppendLine($"The sum that is closest to the target {input.find} is {this.ThreeSumClosest(input.input, input.find)} for the given input {(string.Join(" ", input.input))} ");
            }

            MessageBox.Show(result.ToString());


        }

        public int ThreeSumClosest(int[] nums, int target)
        {

            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            Array.Sort(nums);
            int l = 0;
            int r = 0;
            int cSum = 0;
            int retSum = 0;
            int min = int.MaxValue;

            for (int i = 0; i < nums.Length; i++) // -4, -1, 1, 2   find = 1 
            {
                l = i + 1;
                r = nums.Length - 1;

                while (l < r)
                {
                    cSum = nums[i] + nums[l] + nums[r];     // -1

                    if (Math.Abs(cSum - target) < min)   //3
                    {
                        min = Math.Abs(cSum - target);  //2
                        retSum = cSum;                  //-1
                    }

                    if (cSum == target)
                    {
                        return cSum;
                    }
                    else if (cSum > target)
                    {
                        r--;
                    }
                    else
                    {
                        l++;
                    }
                }
            }
            return retSum;
        }

        private void btn_Find_Intersection_of_all_Intervals_Click(object sender, EventArgs e)
        {
            /* 
                https://www.geeksforgeeks.org/find-intersection-of-all-intervals/

                Time Complexity  :  O(N) where N is the number of intervals
                Space Complexity :  O(1) constanct space.
             */

            StringBuilder result = new StringBuilder();
            IList<IList<Interval>> inputs = new List<IList<Interval>>();

            inputs.Add(
                new List<Interval>()
                {
                    new Interval() { Start = 1, End = 6 },
                    new Interval() { Start = 2, End = 8 },
                    new Interval() { Start = 3, End = 10 },
                    new Interval() { Start = 5, End = 8 },
                });


            inputs.Add(
                new List<Interval>()
                {
                    new Interval() { Start = 5, End = 8 },
                    new Interval() { Start = 2, End = 8 },
                    new Interval() { Start = 3, End = 10 },
                    new Interval() { Start = 1, End = 6 },
                   
                });

            inputs.Add(
                new List<Interval>()
                {
                    new Interval() { Start = 1, End = 6 },
                    new Interval() { Start = 8, End = 18 }
                });

            Interval? interval = null;
            for(int i = 0; i < inputs.Count; i++)
            {
                interval = this.Intersection_Of_Intervals(inputs[i]);

                if (interval != null)
                {
                    result.AppendLine($"Intersection is {interval.Value.Start} {interval.Value.End} from this intervals \n{this.GetInterval(inputs[i])}");
                }
                else
                {
                    result.AppendLine($"No Intersection from this intervals \n{this.GetInterval(inputs[i])}");
                }
            }

            MessageBox.Show(result.ToString());

        }

        private Interval? Intersection_Of_Intervals(IList<Interval> input)
        {
            if (input == null || input.Count == 0)
            {
                return null;
            }

            Interval cInterval = input[0]; 
            Interval current;

            for(int i = 1; i < input.Count; i++)
            {
                current = input[i];
                if(current.Start > cInterval.Start && current.Start> cInterval.End)
                {
                    return null;
                }
                else
                {
                    cInterval.Start = Math.Max(cInterval.Start, current.Start);
                    cInterval.End = Math.Min(cInterval.End, current.End);
                }                
            }


            return cInterval;

        }

        private string GetInterval(IList<Interval> input)
        {
            StringBuilder result = new StringBuilder();
            foreach(Interval interval in input)
            {
                result.AppendLine($"{interval.Start} {interval.End }");
            }

            return result.ToString();
        }

        private void btn_Count_all_possible_paths_from_top_left_to_bottom_right_of_a_mXn_matrix_Click(object sender, EventArgs e)
        {
            /*
             
                https://www.geeksforgeeks.org/count-possible-paths-top-left-bottom-right-nxm-matrix/
                Time Complexity : O(1)
                Space Complexity : O(1)
             */

            StringBuilder result = new StringBuilder();
            List<Interval> inputs = new List<Interval>();
            inputs.Add(new Interval() { Start = 4, End = 3 });

            foreach(Interval input in inputs)
            {

                int m = input.Start;
                int n = input.End;
                int path = 1;
                for (int i = n; i < (m + n - 1); i++)
                {
                    path *= i;
                    path /= (i - n + 1);
                }
                result.AppendLine($"Total number of paths from top left to bottom for the given matrix coordinates {m} and {n} is {path}");
            }
            MessageBox.Show(result.ToString());

           
        }

        private void btn_Number_of_flips_to_make_coin_head_or_tails_Click(object sender, EventArgs e)
        {
            /*
                Time Complexity     : O(N) where N is the list of integers
                Space Complexity    : O(1) constant
             */

            StringBuilder result = new StringBuilder();
            List<int[]> inputs = new List<int[]>();
            inputs.Add(new int[] { 1, 0, 1, 0, 1, 1 }); //1
            inputs.Add(new int[] { 1, 1, 0, 1, 1 }); // 2
            inputs.Add(new int[] { 0, 1, 0 }); // 0
            inputs.Add(new int[] { 0, 1, 1, 0 }); // 2

            foreach(int[] input in inputs)
            {
                result.AppendLine($"Number of flip is {this.GetFlips(input)} for the given input {string.Join(" ", input)}");
            }

            MessageBox.Show(result.ToString());

        }

        private int GetFlips(int[] input)
        {

            int fhCount = 0;
            int ftCount = 0;
            int fh = 0;
            int ft = 1;

            if (input == null || input.Length == 0)
            {
                return fhCount;
            }

            for(int i = 0; i < input.Length; i++)
            {
                if (input[i] != fh)
                {
                    fhCount++;
                }

                if (input[i] != ft)
                {
                    ftCount++;
                }

                fh = fh == 1 ? 0 : 1;
                ft = ft == 1 ? 0 : 1;
                
            }

            return Math.Min(fhCount,ftCount);
        }

        private void btn_Pair_of_groups_merge_the_group_which_matches_X_and_Y_Click(object sender, EventArgs e)
        {
            List<List<Interval>> inputs = new List<List<Interval>>();

            inputs.Add(new List<Interval>() {   new Interval() { Start = 1, End = 3 }, 
                                                new Interval() { Start = 6, End = 8 },
                                                new Interval() { Start = 10, End = 12 },
                                                new Interval() { Start = 8, End = 3 }
                                            });
        }

        private List<int> MergeIntervalsMatchXAndY(List<Interval> input)
        {
            List<int> result = new List<int>();
            Dictionary<int, HashSet<int>> dict = new Dictionary<int, HashSet<int>>();
            HashSet<int> temp = new HashSet<int>();

            foreach(Interval interval in input)
            {
               if (dict.ContainsKey(interval.Start))
               {
                    temp.Add(interval.Start);
                    //temp.
               }

            }

            return null;
        }

        private void btn_4_Sum_Click(object sender, EventArgs e)
        {

         

            StringBuilder result = new StringBuilder();
            StringBuilder tempResult = new StringBuilder();

            List<ArrayAndValue> inputs = new List<ArrayAndValue>();
            //inputs.Add(new ArrayAndValue() { input = new int[] { 1, 0, -1, 0, -2, 2, 0 }, find = 0 });
            inputs.Add(new ArrayAndValue() { input = new int[] { 0 ,0 ,0 , 0 }, find = 1 });

            foreach (var arrayAndValue in inputs)
            { 
                var temp = this.FourSum(arrayAndValue.input, arrayAndValue.find);
                string str = string.Join(Environment.NewLine, temp.Select(s => string.Join(",",s )));
                result.AppendLine($"4 Sum for the target {arrayAndValue.find} for given input array \n {string.Join(",", arrayAndValue.input)} is {(string.IsNullOrEmpty(str)? "Empty" : str)}  \n ");
            }

            MessageBox.Show(result.ToString());


        }

        public IList<IList<int>> FourSum(int[] nums, int target)
        {

            if (nums == null || nums.Length == 0 || nums.Length <= 3)
            {
                return new List<IList<int>>();
            }

            Array.Sort(nums);
            HashSet<string> dict = new HashSet<string>();
            string dictKey = string.Empty;

            int f = 0;
            int s = 0;
            int l = 0;
            int r = nums.Length - 1;

            List<IList<int>> result = new List<IList<int>>();
            int sum = 0;

            for (f = 0; f < nums.Length; f++)
            {
                s = f + 1;
                for (; s < nums.Length; s++)
                {
                    r = nums.Length - 1;
                    l = s + 1;
                    while (l < r)
                    {
                        sum = nums[f] + nums[s] + nums[l] + nums[r];
                        if (sum == target)
                        {
                            dictKey = $"{nums[f] },{nums[s]},{nums[l]},{nums[r]}";
                            if (!dict.Contains(dictKey))
                            {
                                result.Add(new List<int>() { nums[f], nums[s], nums[l], nums[r] });
                                dict.Add(dictKey);
                            }
                            l++;
                            r--;

                        } 
                        else if (sum < target)
                        {
                            l++;
                        }
                        else
                        {
                            r--;
                        }
                    }
                }
            }
            return result;
        }

        private void btn_Last_Stone_Weight_Click(object sender, EventArgs e)
        {
            /*
            
                We have a collection of stones, each stone has a positive integer weight.

                Each turn, we choose the two heaviest stones and smash them together.  Suppose the stones have weights x and y with x <= y.  The result of this smash is:

                If x == y, both stones are totally destroyed;
                If x != y, the stone of weight x is totally destroyed, and the stone of weight y has new weight y-x.
                At the end, there is at most 1 stone left.  Return the weight of this stone (or 0 if there are no stones left.)

 

                Example 1:

                Input: [2,7,4,1,8,1]
                Output: 1
                Explanation: 
                We combine 7 and 8 to get 1 so the array converts to [2,4,1,1,1] then,
                we combine 2 and 4 to get 2 so the array converts to [2,1,1,1] then,
                we combine 2 and 1 to get 1 so the array converts to [1,1,1] then,
                we combine 1 and 1 to get 0 so the array converts to [1] then that's the value of last stone.
 

                Note:

                1 <= stones.length <= 30
                1 <= stones[i] <= 1000

                Note : Simulate the process. We can do it with a heap, or by sorting some list of stones every time we take a turn.

                Time Complexity     : O(N) where n is the total numbers of input
                Space Complexity    : O(1) Constanct space



             */

            List<int[]> inputs = new List<int[]>() { 
                                                        new int[] { 2, 7, 4, 1, 8, 1 },
                                                        new int[] { 2,2 },

                                                   };
            StringBuilder result = new StringBuilder();

            foreach(int[] input in inputs)
            {

                result.AppendLine($"The weight of the stone is {this.LastStoneWeight(input)} for the given input {string.Join(",", input)}");
            }

            MessageBox.Show(result.ToString());

        }

        public int LastStoneWeight(int[] stones)
        {

            if (stones == null || stones.Length == 0)
            {
                return 0;
            }

            int fmax = 0;
            int smax = 0;
            int fmaxInd = 0;
            int smaxInd = 0;


            while (true)
            {
                fmax = 0;
                fmaxInd = -1;
                smax = 0;
                smaxInd = -1;

                for (int i = 0; i < stones.Length; i++)
                {
                    if (stones[i] == -1)
                        continue;

                    if (stones[i] >= fmax && stones[i] >= smax)
                    {
                        smax = fmax;
                        smaxInd = fmaxInd;
                        fmax = stones[i];
                        fmaxInd = i;
                    }
                    else if (stones[i] > smax)
                    {
                        smax = stones[i];
                        smaxInd = i;
                    }
                }

                if (smaxInd >= 0 && fmaxInd >= 0)
                {
                    stones[smaxInd] = fmax - smax;
                    stones[fmaxInd] = -1;
                }
                else if (fmaxInd == -1 || smaxInd == -1)
                {
                    break;
                }
            }

            return fmax;
        }

     
        private void btn_Contiguous_Array_Click(object sender, EventArgs e)
        {
       

            /*
             
                Given a binary array, find the maximum length of a contiguous subarray with equal number of 0 and 1.

                Example 1:
                Input: [0,1]
                Output: 2
                Explanation: [0, 1] is the longest contiguous subarray with equal number of 0 and 1.
                Example 2:
                Input: [0,1,0]
                Output: 2
                Explanation: [0, 1] (or [1, 0]) is a longest contiguous subarray with equal number of 0 and 1.
                Note: The length of the given binary array will not exceed 50,000.

                Time Complexity : O(N)
                Space Complexity : O(N)

             */



            List<int[]> inputs = new List<int[]>() {
                                                        new int[] { 0,1 },
                                                        new int[] { 0,1, 1 },
                                                        new int[] { 1, 0, 1, 1, 1, 0, 0},
                                                        new int[] { 1, 1, 1, 1},
                                                        new int[] { 0, 0, 1, 1,  0},

                                                   };
            StringBuilder result = new StringBuilder();

            foreach (int[] input in inputs)
            {

                result.AppendLine($"Max length for continous array with equal 0 and 1 is {this.FindMaxLength(input)} for the given input {string.Join(",", input)}");
            }

            MessageBox.Show(result.ToString());
        }


        public int FindMaxLength(int[] nums)
        {

            if (nums == null || nums.Length == 0)
                return 0;

            int sum = 0;
            int maxLength = 0;
            Dictionary<int, int> dict = new Dictionary<int, int>();
            dict[0] = -1;
            int dicValue = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                sum += (nums[i] == 0 ? -1 : 1);

                if (dict.TryGetValue(sum, out dicValue))
                {
                    maxLength = Math.Max(maxLength, i - dicValue);
                }
                else
                {
                    dict[sum] = i;
                }
            }

            return maxLength;


        }


       

        private void btn_Perform_String_Shifts_Click(object sender, EventArgs e)
        {
            int[] nums = new int[4];
            int[] aux = new  int[nums.Length];

            /*
             
            You are given a string s containing lowercase English letters, and a matrix shift, where shift[i] = [direction, amount]:

            direction can be 0 (for left shift) or 1 (for right shift). 
            amount is the amount by which string s is to be shifted.
            A left shift by 1 means remove the first character of s and append it to the end.
            Similarly, a right shift by 1 means remove the last character of s and add it to the beginning.
            Return the final string after all operations.

 

            Example 1:

            Input: s = "abc", shift = [[0,1],[1,2]]
            Output: "cab"
            Explanation: 
            [0,1] means shift to left by 1. "abc" -> "bca"
            [1,2] means shift to right by 2. "bca" -> "cab"
            Example 2:

            Input: s = "abcdefg", shift = [[1,1],[1,1],[0,2],[1,3]]
            Output: "efgabcd"
            Explanation:  
            [1,1] means shift to right by 1. "abcdefg" -> "gabcdef"
            [1,1] means shift to right by 1. "gabcdef" -> "fgabcde"
            [0,2] means shift to left by 2. "fgabcde" -> "abcdefg"
            [1,3] means shift to right by 3. "abcdefg" -> "efgabcd"
 

            Constraints:

            1 <= s.length <= 100
            s only contains lower case English letters.
            1 <= shift.length <= 100
            shift[i].length == 2
            0 <= shift[i][0] <= 1
            0 <= shift[i][1] <= 100 

            Time Complexity     : 
            Space Complexity    :

             */

            StringBuilder result = new StringBuilder();


            List<JaggedArraysWithString> inputs = new List<JaggedArraysWithString>();
            //inputs.Add(new JaggedArraysWithString() { input = "abcdefg", shifts = new int[][] { new int[]{ 1, 1 }, new int[] { 1, 1 }, new int[] { 0, 2 }, new int[] { 1, 3 } } });
            //inputs.Add(new JaggedArraysWithString() { input = "abc", shifts = new int[][] { new int[] { 0, 1 }, new int[] { 1, 2 }} });
            inputs.Add(new JaggedArraysWithString() { input = "yisxjwry", shifts = new int[][] { new int[] { 1, 8 }, new int[] { 1, 4 }, new int[] { 1, 3 }, new int[] { 1, 6 }, new int[] { 0, 6 }, new int[] { 1, 4 }, new int[] { 0, 2 }, new int[] { 0, 1 } } });

            foreach (var input in inputs)
            {

                result.AppendLine(this.PrintData(input)); 
                this.MergeShifts(input.shifts, input.input.Length);
                result.AppendLine($"{this.ShiftStrings(input.input, input.shifts[input.shifts.Length - 1][0], input.shifts[input.shifts.Length - 1][1])}");
            }

            MessageBox.Show(result.ToString());
         }

        private void MergeShifts(int[][] shift, int len)
        {
            for (int i = 0; i < shift.Length - 1; i++)
            {
                if (shift[i + 1][1] == 0)
                {
                    shift[i + 1][0] = shift[i][0];
                    shift[i + 1][1] = shift[i][1];
                }
                else if (shift[i][0] == shift[i + 1][0])
                {
                    shift[i + 1][1] += shift[i][1];
                    if (shift[i + 1][1] >= len)
                    {
                        shift[i + 1][1] -= len;
                    }
                }
                else if (shift[i][0] != shift[i + 1][0])
                {
                    if (shift[i][1] > shift[i + 1][1])
                    {
                        shift[i + 1][1] = shift[i][1] - shift[i + 1][1];
                        shift[i + 1][0] = shift[i][0];
                    }
                    else
                    {
                        shift[i + 1][1] -= shift[i][1];
                    }
                }
            }
        }

        private string PrintData(JaggedArraysWithString input)
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"String shift for the input string {input.input} for the given shifts ");
            for(int i = 0; i < input.shifts.Length; i++)
            {
                result.AppendLine($"{input.shifts[i][0]},{input.shifts[i][1]}");               
            }
            return result.ToString();

        }

        public string ShiftStrings(string input, int direction, int move)
        {
            string result;

            if (direction == 1)
            {
                result = string.Concat(input.Substring(input.Length - move), input.Substring(0, input.Length - move));
            }
            else
            {
                result = string.Concat(input.Substring(move), input.Substring(0, move));
            }

            return result;

        }




        public class JaggedArraysWithString
        {
            public int[][] shifts;
            public string input;
        }

        private void btn_Subarray_Sum_Equals_K_Click(object sender, EventArgs e)
        {
            /*
            
                Given an array of integers and an integer k, you need to find the total number of continuous subarrays whose sum equals to k.

                Example 1:
                Input:nums = [1,1,1], k = 2
                Output: 2

                Time Complexity : O(N)
                Space Complexity : O(N)

            */

            StringBuilder result = new StringBuilder();
            List<Array2n> inputs = new List<Array2n>();
            inputs.Add(new Array2n() {Data = new int[] {10,2,-2,-20,10 }, N= -10 }); //3
            inputs.Add(new Array2n() { Data = new int[] { 1,1,1}, N = 2 }); //2
            inputs.Add(new Array2n() { Data = new int[] { 3,4,7,2,-3,1,4,2 }, N = 7 }); //4
            inputs.Add(new Array2n() { Data = new int[] { 1,2,1,2,1 }, N = 3 }); //4

            foreach (var input in inputs)
            {
                result.AppendLine($"There are {this.SubarraySum(input.Data, input.N)} sub array with in the array { string.Join(",",  input.Data)} ");
            }

            MessageBox.Show(result.ToString());
        }

        public int SubarraySum(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            int counter = 0;
            int sum = 0;
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int temp = 0;

            for (int i = 0; i < nums.Length; i++) //10,2,-2,-20,10    N = -10   counter = 2
            {
                /*
                    10     :   2
                    12      :  1
                   -10      : 1
                    
                */
                sum += nums[i];

                if (sum == k)
                    counter++;

                if (dict.TryGetValue(sum - k, out temp))
                {
                    counter += temp;
                }
                
                if (dict.TryGetValue(sum, out temp))
                {                    
                    dict[sum] +=1;
                }
                else
                {
                    dict[sum] = 1;
                }

            }

            return counter;
        }

        private void btn_Counting_Elements_Click(object sender, EventArgs e)
        {
           

            /*
             Given an integer array arr, count element x such that x + 1 is also in arr.

                If there're duplicates in arr, count them seperately. 

                Example 1:

                Input: arr = [1,2,3]
                Output: 2
                Explanation: 1 and 2 are counted cause 2 and 3 are in arr.
                Example 2:

                Input: arr = [1,1,3,3,5,5,7,7]
                Output: 0
                Explanation: No numbers are counted, cause there's no 2, 4, 6, or 8 in arr.
                Example 3:

                Input: arr = [1,3,2,3,5,0]
                Output: 3
                Explanation: 0, 1 and 2 are counted cause 1, 2 and 3 are in arr.
                Example 4:

                Input: arr = [1,1,2,2]
                Output: 2
                Explanation: Two 1s are counted cause 2 is in arr.
                
                Time Complexity     : O(N) where N is the total nunber of element in the array
                Space Complexity    :O(N)
             
            */



            List<int[]> inputs = new List<int[]>() {
                                                        new int[] {1,2,3},
                                                        new int[] { 1,1,3,3,5,5,7,7 },
                                                        new int[] { 1,3,2,3,5,0},
                                                        new int[] { 1,1,2,2}
                                                   };

            StringBuilder result = new StringBuilder();
            foreach (int[] input in inputs)
            {

                result.AppendLine($"There are {this.CountElements(input)} counting elements for the given input {string.Join(",", input)}");
            }

            MessageBox.Show(result.ToString());
        }

        public int CountElements(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return 0;

            HashSet<int> dict = new HashSet<int>();
            int counter = 0;
            foreach (int i in arr)
                dict.Add(i);

            foreach (int i in arr)
            {
                if (dict.Contains(i + 1))
                    counter++;
            }


            return counter;
        }

        private void btn_Jump_Game_Click(object sender, EventArgs e)
        {
            
            /*
                Given an array of non-negative integers, you are initially positioned at the first index of the array.

                Each element in the array represents your maximum jump length at that position.

                Determine if you are able to reach the last index.

                Example 1:

                Input: [2,3,1,1,4]
                Output: true
                Explanation: Jump 1 step from index 0 to 1, then 3 steps to the last index.
                Example 2:

                Input: [3,2,1,0,4]
                Output: false
                Explanation: You will always arrive at index 3 no matter what. Its maximum
                                jump length is 0, which makes it impossible to reach the last index.
             
                Time Complexity     : O(N)
                Space Complexity    : O(1) 

             */

            List<int[]> inputs = new List<int[]>() {
                                                        new int[] {2,3,1,1,4},
                                                        new int[] { 3,2,1,0,4 },
                                                        new int[] { 2,0,0},
                                                        new int[] { 3,2,1,0,4},
                                                        new int[] { 1,1,0,1},
                                                        new int[] { 3,2,1,0,4},
                                                        new int[] { 1,1,0,1},
                                                        new int[] { 1,1,1,0},
                                                        new int[] { 2,1,0,0},
                                                        new int[] { 1,2,0,1}

                                                   };

            StringBuilder result = new StringBuilder();
            foreach (int[] input in inputs)
            {

                result.AppendLine($"There is a path {(this.CanJump(input) ? ""  : "dont") } exists to jump for the given input {string.Join(",", input)}");
            }

            MessageBox.Show(result.ToString());
        }

        public bool CanJump(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return false;
            }

            int movingIndex = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                if (movingIndex < i)
                    return false;

                movingIndex = Math.Max(movingIndex, i + nums[i]);


            }

            return true;

        }

        public class FirstUnique
        {
            private class DoubleLinkList
            {
                public int Data;
                public DoubleLinkList Next;
                public DoubleLinkList Previous;
            }

            DoubleLinkList start = null;
            DoubleLinkList runner = null;
            Dictionary<int, DoubleLinkList> dict = new Dictionary<int, DoubleLinkList>();


            public FirstUnique(int[] nums)
            {

                
                if (nums != null && nums.Length > 0)
                {
                    foreach (int i in nums)
                    {
                        Add(i);
                    }
                }
            }

            public int ShowFirstUnique()
            {

                int result = -1;
                if (start != null)
                {
                    result = start.Data;
                }
                return result;
            }

            public void Add(int value)
            {
                DoubleLinkList temp;
                if (dict.TryGetValue(value, out temp))
                {
                    if (temp != null)
                    {
                        if (temp.Previous != null)
                        {
                            temp.Previous.Next = temp.Next;
                            if (temp.Next != null)
                            {
                                temp.Next.Previous = temp.Previous;
                            }
                            else
                            {
                                temp.Previous = null;
                            }                     
                        }
                        else
                        {
                            start = start.Next;
                            if (start != null)
                            {
                                start.Previous = null;
                            }
                        }
                        dict[value] = null;
                    }                                  
                }
                else
                {
                    if (start == null)
                    {
                        start = new DoubleLinkList() { Data = value };
                        runner = start;
                    }
                    else
                    {
                        runner.Next = new DoubleLinkList() { Data = value, Previous = runner };
                        runner = runner.Next;
                    }
                    dict[value] = runner;
                }                
            }
        }

        private void btn_First_Unique_Number_Click(object sender, EventArgs e)
        {
            

            bool debug = true;

            if (debug)
            {
                FirstUnique fq = new FirstUnique(new int[] { 2, 3, 5 });
                fq.ShowFirstUnique();
                fq.Add(5);
                fq.ShowFirstUnique();
                fq.Add(2);
                fq.ShowFirstUnique();
                fq.Add(3);
                fq.ShowFirstUnique();
                fq.Add(2);
                fq.ShowFirstUnique();
                fq.Add(6);
                fq.ShowFirstUnique();
            }
            else
            {
                FirstUnique funique = new FirstUnique(new int[] { 392, 59, 691, 331, 805, 15, 180, 248, 114, 62, 643, 401, 316, 764, 793, 234, 821, 304, 441, 905, 983, 815, 38, 560, 526, 259, 995, 343, 165, 648, 995, 945, 401, 414, 44, 16, 224, 423, 933, 452, 152, 893, 116, 570, 343, 317, 263, 311, 600, 928, 573, 859, 540, 739, 244, 994, 409, 429, 892, 277, 413, 481, 88, 445, 744, 706, 971, 136, 233, 250, 584, 619, 439, 316, 601, 120, 245, 252, 187, 844, 48, 139, 412, 778, 316, 929, 8, 182, 839, 868, 15, 793, 31, 733, 987, 69, 212, 319, 594, 485, 955, 598, 543, 68, 947, 719, 552, 763, 520, 543, 487, 62, 740, 694, 293, 52, 599, 998, 414, 479, 292, 954, 195, 846, 143, 384, 186, 113, 490, 956, 64, 708, 654, 701, 297, 187, 236, 514, 607, 409, 462, 427, 87, 503, 566, 835, 17, 327, 395, 4, 87, 605, 24, 293, 141, 648, 62, 919, 749, 291, 760, 322, 84, 274, 306, 734, 495, 550, 925, 434, 848, 869, 873, 904, 442, 772, 858, 9, 729, 956, 85, 404, 882, 305, 674, 172, 398, 582, 915, 428, 475, 516, 459, 939, 239, 673, 837, 227, 262, 921, 506, 8, 110, 122, 294, 187, 964, 941, 168, 380, 803, 698, 886, 361, 464, 1, 162, 30, 955, 264, 225, 347, 302, 553, 771, 492, 2, 694, 764, 147, 608, 620, 455, 378, 367, 306, 303, 5, 306, 467, 973, 233, 579, 923, 965, 137, 586, 499, 896, 941, 372, 854, 483, 794, 610, 746, 751, 64, 106, 229, 939, 966, 40, 962, 75, 27, 136, 215, 687, 439, 414, 416, 564, 963, 789, 171, 364, 229, 327, 77, 31, 493, 900, 972, 639, 355, 262, 832, 315, 148, 824, 559, 763, 320, 76, 802, 882, 685, 399, 63, 843, 304, 551, 710, 774, 519, 275, 883, 204, 576, 387, 808, 709, 912, 363, 99, 82, 959, 626, 304, 604, 716, 273, 468, 807, 352, 379, 708, 246, 825, 638, 434, 974, 402, 153, 46, 275, 946, 883, 202, 37, 925, 649, 431, 562, 310, 445, 713, 578, 521, 814, 616, 670, 963, 667, 852, 984, 813, 168, 969, 270, 729, 877, 795, 232, 908, 402, 312, 431, 946, 386, 463, 692, 458, 93, 330, 492, 390, 619, 819, 573, 903, 147, 363, 354, 625, 783, 358, 991, 292, 476, 757, 660, 83, 872, 523, 135, 750, 835, 793, 749, 777, 740, 665, 993, 779, 259, 921, 215, 551, 838, 244, 47, 976, 782, 907, 63, 448, 945, 115, 730, 180, 423, 895, 909, 407, 138, 955, 282, 919, 429, 894, 935, 124, 469, 459, 503, 135, 667, 530, 543, 60, 157, 600, 947, 792, 417, 528, 349, 622, 285, 738, 575, 48, 885, 809, 661, 405, 965, 923, 721, 209, 582, 587, 185, 825, 974, 67, 349, 745, 953, 2, 628, 404, 226, 165, 299, 811, 366, 935, 215, 440, 196, 218, 348, 266, 810, 565, 126, 988, 520, 855, 305, 255, 72, 987, 714, 496, 159, 673, 268, 645, 658, 572, 600, 898, 166, 942, 431, 864, 373, 702, 201, 257, 14, 588, 483, 730, 870, 610, 804, 106, 315, 780, 204, 986, 223, 259, 442, 333, 690, 504, 492, 874, 344, 73, 391, 56, 797, 852, 581, 879, 40, 12, 792, 802, 940, 696, 562, 312, 165, 306, 391, 241, 410, 284, 248, 296, 89, 682, 238, 262, 647, 245, 257, 23, 389, 451, 227, 270, 635, 401, 589, 268, 839, 94, 279, 973, 827, 657, 129, 699, 674, 142, 304, 682, 515, 688, 173, 413, 788, 766, 189, 239, 864, 80, 516, 488, 129, 662, 294, 138, 714, 772, 970, 239, 704, 51, 358, 916, 975, 653 });
                funique.Add(810);
                funique.Add(357);
                funique.Add(544);
                funique.ShowFirstUnique();
                funique.ShowFirstUnique();
                funique.Add(793);
                funique.ShowFirstUnique();
                funique.Add(766);
                funique.Add(93);
                funique.Add(625);
                funique.Add(546);
                funique.Add(841);
                funique.ShowFirstUnique();
                funique.Add(24);
                funique.Add(33);
                funique.Add(943);
                funique.Add(611);
                funique.Add(665);
                funique.Add(43);
                funique.Add(236);
                funique.Add(493);
                funique.Add(353);
                funique.ShowFirstUnique();
                funique.Add(178);
                funique.Add(128);
                funique.Add(104);
                funique.ShowFirstUnique();
                funique.ShowFirstUnique();
                funique.Add(308);
                funique.Add(727);
                funique.Add(341);
                funique.Add(164);
                funique.Add(658);
                funique.ShowFirstUnique();
                funique.Add(786);
                funique.Add(98);
                funique.Add(523);
                funique.Add(507);
                funique.Add(584);
                funique.Add(768);
                funique.Add(349);
                funique.Add(360);
                funique.Add(647);
                funique.Add(805);
                funique.Add(796);
                funique.Add(18);
                funique.Add(790);
                funique.Add(329);
                funique.ShowFirstUnique();
                funique.Add(737);
                funique.Add(504);
                funique.Add(392);
                funique.Add(191);
                funique.Add(110);
                funique.Add(337);
                funique.Add(379);
                funique.Add(386);
                funique.Add(902);
                funique.ShowFirstUnique();
                funique.ShowFirstUnique();
                funique.Add(864);
                funique.Add(393);
                funique.Add(154);
                funique.Add(316);
                funique.Add(501);
                funique.Add(794);
                funique.Add(52);
                funique.Add(178);
                funique.Add(486);
                funique.Add(738);
                funique.Add(106);
                funique.Add(474);
                funique.Add(344);
                funique.Add(360);
                funique.Add(601);
                funique.Add(945);
                funique.Add(785);
                funique.Add(703);
                funique.Add(117);
                funique.Add(713);
                funique.Add(975);
                funique.Add(333);
                funique.Add(561);
                funique.Add(236);
                funique.Add(626);
                funique.Add(775);
                funique.Add(279);
                funique.Add(302);
                funique.Add(838);
                funique.Add(457);
                funique.Add(705);
                funique.ShowFirstUnique();
                funique.Add(110);
                funique.Add(812);
                funique.Add(618);
                funique.Add(735);
                funique.Add(559);
                funique.Add(419);
                funique.Add(399);
                funique.ShowFirstUnique();
                funique.Add(275);
                funique.Add(427);
                funique.ShowFirstUnique();
                funique.Add(732);
                funique.Add(762);
                funique.Add(689);
                funique.Add(434);
                funique.ShowFirstUnique();
                funique.Add(1000);
                funique.Add(585);
                funique.Add(355);
                funique.Add(124);
                funique.Add(487);
                funique.Add(181);
                funique.ShowFirstUnique();
                funique.Add(700);
                funique.Add(58);
                funique.Add(555);
                funique.ShowFirstUnique();
                funique.Add(470);
                funique.ShowFirstUnique();
                funique.Add(837);
                funique.ShowFirstUnique();
                funique.Add(615);
                funique.Add(636);
                funique.Add(467);
                funique.Add(632);
                funique.Add(81);
                funique.Add(699);
                funique.Add(86);
                funique.Add(662);
                funique.Add(102);
                funique.Add(209);
                funique.ShowFirstUnique();
                funique.Add(399);
                funique.Add(436);
                funique.Add(856);
                funique.Add(357);
                funique.Add(836);
                funique.Add(351);
                funique.Add(31);
                funique.Add(943);
                funique.Add(686);
                funique.Add(271);
                funique.Add(205);
                funique.Add(51);
                funique.Add(964);
                funique.ShowFirstUnique();
                funique.Add(89);
                funique.Add(850);
                funique.ShowFirstUnique();
                funique.Add(158);
                funique.ShowFirstUnique();
                funique.Add(595);
                funique.Add(680);
                funique.Add(39);
                funique.Add(448);
                funique.Add(975);
                funique.ShowFirstUnique();
                funique.Add(135);
                funique.Add(270);
                funique.Add(449);
                funique.Add(806);
                funique.Add(377);
                funique.Add(102);
                funique.Add(983);
                funique.ShowFirstUnique();
                funique.Add(152);
                funique.Add(63);
                funique.Add(368);
                funique.Add(45);
                funique.Add(441);
                funique.Add(950);
                funique.Add(494);
                funique.Add(646);
                funique.Add(327);
                funique.Add(17);
                funique.Add(604);
                funique.Add(298);
                funique.Add(649);
                funique.Add(491);
                funique.Add(255);
                funique.Add(766);
                funique.Add(354);
                funique.Add(993);
                funique.Add(844);
                funique.Add(159);
                funique.ShowFirstUnique();
                funique.Add(874);
                funique.Add(711);
                funique.Add(634);
                funique.Add(727);
                funique.Add(845);
                funique.Add(34);
                funique.Add(193);
                funique.Add(417);
                funique.Add(878);
                funique.Add(577);
                funique.Add(680);
                funique.Add(626);
                funique.Add(365);
                funique.Add(399);
                funique.Add(50);
                funique.Add(560);
                funique.Add(569);
                funique.Add(528);
                funique.Add(225);
                funique.Add(164);
                funique.Add(979);
                funique.ShowFirstUnique();
                funique.Add(673);
                funique.ShowFirstUnique();
                funique.Add(12);
                funique.Add(957);
                funique.Add(854);
                funique.Add(975);
                funique.Add(995);
                funique.Add(76);
                funique.Add(618);
                funique.Add(138);
                funique.Add(131);
                funique.ShowFirstUnique();
                funique.Add(308);
                funique.Add(618);
                funique.Add(464);
                funique.Add(145);
                funique.Add(20);
                funique.Add(816);
                funique.Add(491);
                funique.Add(70);
                funique.Add(553);
                funique.Add(559);
                funique.Add(346);
                funique.Add(124);
                funique.ShowFirstUnique();
                funique.Add(858);
                funique.Add(541);
                funique.Add(350);
                funique.Add(379);
                funique.Add(805);
                funique.Add(986);
                funique.Add(620);
                funique.Add(846);
                funique.Add(724);
                funique.Add(197);
                funique.Add(958);
                funique.Add(659);
                funique.Add(47);
                funique.ShowFirstUnique();
                funique.Add(284);
                funique.Add(714);
                funique.ShowFirstUnique();
                funique.Add(573);
                funique.Add(890);
                funique.Add(431);
                funique.Add(931);
                funique.Add(124);
                funique.Add(284);
                funique.Add(42);
                funique.Add(123);
                funique.Add(875);
                funique.Add(738);
                funique.ShowFirstUnique();
                funique.Add(194);
                funique.Add(539);
                funique.Add(365);
                funique.ShowFirstUnique();
                funique.Add(294);
                funique.Add(805);
                funique.Add(389);
                funique.Add(584);
                funique.Add(995);
                funique.Add(284);
                funique.Add(147);
                funique.Add(897);
                funique.Add(620);
                funique.Add(814);
                funique.Add(199);
                funique.Add(300);
                funique.Add(766);
                funique.Add(343);
                funique.Add(943);
                funique.Add(677);
                funique.Add(40);
                funique.Add(615);
                funique.ShowFirstUnique();
                funique.Add(338);
                funique.Add(760);
                funique.Add(405);
                funique.ShowFirstUnique();
                funique.Add(341);
                funique.Add(577);
                funique.Add(417);
                funique.Add(536);
                funique.Add(944);
                funique.Add(716);
                funique.Add(449);
                funique.Add(27);
                funique.ShowFirstUnique();
                funique.Add(76);
                funique.ShowFirstUnique();
                funique.ShowFirstUnique();
                funique.Add(750);
                funique.Add(99);
                funique.Add(153);
                funique.Add(763);
                funique.Add(482);
                funique.ShowFirstUnique();
                funique.Add(66);
                funique.Add(291);
                funique.Add(292);
                funique.Add(458);
                funique.ShowFirstUnique();
                funique.Add(573);
                funique.Add(66);
                funique.Add(259);
                funique.Add(119);
                funique.Add(342);
                funique.Add(800);
                funique.Add(688);
                funique.Add(883);
                funique.Add(97);
                funique.ShowFirstUnique();
                funique.ShowFirstUnique();
                funique.Add(202);
                funique.Add(349);
                funique.Add(686);
                funique.Add(478);
                funique.Add(419);
                funique.Add(953);
                funique.Add(844);
                funique.Add(253);
                funique.Add(840);
                funique.Add(485);
                funique.Add(72);
                funique.Add(278);
                funique.Add(214);
                funique.Add(650);
                funique.Add(669);
                funique.Add(163);
                funique.Add(263);
                funique.Add(581);
                funique.Add(663);
                funique.ShowFirstUnique();
                funique.Add(258);
                funique.Add(661);
                funique.Add(925);
                funique.Add(435);
                funique.Add(584);
                funique.Add(628);
                funique.Add(307);
                funique.ShowFirstUnique();
                funique.Add(730);
                funique.Add(932);
                funique.ShowFirstUnique();
                funique.Add(170);
                funique.Add(593);
                funique.Add(349);
                funique.Add(366);
                funique.ShowFirstUnique();
                funique.Add(519);
                funique.Add(815);
                funique.ShowFirstUnique();
                funique.Add(830);
                funique.Add(82);
                funique.Add(593);
                funique.Add(418);
                funique.Add(797);
                funique.Add(289);
                funique.Add(159);
                funique.ShowFirstUnique();
                funique.Add(846);
                funique.Add(961);
                funique.Add(850);
                funique.Add(583);
                funique.Add(971);
                funique.Add(92);
                funique.Add(971);
                funique.Add(839);
                funique.Add(501);
                funique.Add(39);
                funique.ShowFirstUnique();
                funique.Add(412);
                funique.Add(785);
                funique.ShowFirstUnique();
                funique.Add(739);
                funique.Add(639);
                funique.Add(472);
                funique.Add(939);
                funique.Add(157);
                funique.Add(407);
                funique.Add(249);
                funique.Add(789);
                funique.Add(211);
                funique.Add(144);
                funique.ShowFirstUnique();
                funique.ShowFirstUnique();
                funique.Add(145);
                funique.Add(601);
                funique.Add(755);
                funique.Add(788);
                funique.Add(902);
                funique.Add(370);
                funique.Add(609);
                funique.Add(638);
                funique.Add(436);
                funique.ShowFirstUnique();
                funique.Add(752);
                funique.Add(690);
                funique.Add(973);
                funique.Add(160);
                funique.Add(345);
                funique.Add(884);
                funique.Add(561);
                funique.Add(851);
                funique.Add(845);
                funique.Add(397);
                funique.Add(396);
                funique.Add(129);
                funique.Add(739);
                funique.Add(973);
                funique.Add(450);
                funique.Add(160);
                funique.Add(473);
                funique.ShowFirstUnique();
                funique.ShowFirstUnique();
                funique.Add(447);
                funique.Add(328);
                funique.Add(452);
                funique.Add(564);
                funique.Add(6);
                funique.Add(707);
                funique.Add(965);
                funique.Add(545);
                funique.Add(928);
                funique.Add(17);
                funique.Add(901);
                funique.Add(858);
                funique.Add(416);
                funique.Add(410);
                funique.Add(842);
                funique.Add(284);
                funique.Add(566);
                funique.Add(569);
                funique.Add(960);
                funique.Add(719);
                funique.Add(443);
                funique.Add(747);
                funique.Add(93);
                funique.Add(47);
                funique.Add(923);
                funique.ShowFirstUnique();
                funique.Add(542);
                funique.ShowFirstUnique();
                funique.Add(392);
                funique.Add(753);
                funique.ShowFirstUnique();
                funique.Add(126);
                funique.Add(659);
                funique.Add(344);
                funique.Add(578);
                funique.Add(792);
                funique.ShowFirstUnique();
                funique.Add(524);
                funique.Add(182);
                funique.Add(899);
                funique.Add(795);
                funique.Add(728);
                funique.Add(424);
                funique.Add(268);
                funique.Add(841);
                funique.Add(459);
                funique.Add(932);
                funique.Add(674);
                funique.Add(857);
                funique.Add(986);
                funique.Add(228);
                funique.Add(700);
                funique.Add(97);
                funique.Add(924);
                funique.Add(460);
                funique.Add(245);
                funique.Add(220);
                funique.Add(214);
                funique.Add(941);
                funique.Add(712);
                funique.Add(801);
                funique.Add(310);
                funique.Add(724);
                funique.Add(452);
                funique.Add(709);
                funique.Add(958);
                funique.Add(410);
                funique.Add(562);
                funique.Add(152);
                funique.Add(873);
                funique.Add(477);
                funique.Add(513);
                funique.Add(378);
                funique.Add(142);
                funique.Add(549);
                funique.ShowFirstUnique();
                funique.Add(83);
                funique.Add(903);
                funique.Add(128);
                funique.Add(545);
                funique.Add(501);
                funique.Add(145);
                funique.Add(923);
                funique.Add(552);
                funique.Add(420);
                funique.Add(970);
                funique.Add(791);
                funique.Add(433);
                funique.Add(740);
                funique.ShowFirstUnique();
                funique.Add(917);
                funique.Add(463);
                funique.Add(112);
                funique.Add(609);
                funique.Add(76);
                funique.Add(173);
                funique.ShowFirstUnique();
                funique.Add(688);
                funique.Add(75);
                funique.ShowFirstUnique();
                funique.Add(102);
                funique.Add(617);
                funique.ShowFirstUnique();
                funique.Add(204);
                funique.Add(321);
                funique.Add(115);
                funique.Add(453);
                funique.Add(66);
                funique.ShowFirstUnique();
                funique.Add(984);
                funique.Add(331);
                funique.Add(871);
                funique.Add(270);
                funique.Add(780);
                funique.Add(387);
                funique.Add(360);
                funique.Add(109);
                funique.Add(684);
                funique.Add(326);
                funique.Add(528);
                funique.Add(429);
                funique.ShowFirstUnique();
                funique.Add(55);
                funique.Add(519);
                funique.Add(148);
                funique.Add(588);
                funique.Add(337);
                funique.ShowFirstUnique();
                funique.Add(591);
                funique.Add(409);
                funique.Add(369);
                funique.ShowFirstUnique();
                funique.ShowFirstUnique();
                funique.Add(440);
                funique.Add(551);
                funique.Add(423);
                funique.Add(729);
                funique.Add(483);
                funique.ShowFirstUnique();
                funique.ShowFirstUnique();
                funique.Add(637);
                funique.Add(732);
                funique.Add(557);
                funique.Add(482);
                funique.Add(936);
                funique.Add(210);
                funique.Add(328);
                funique.ShowFirstUnique();
                funique.ShowFirstUnique();
                funique.Add(23);
                funique.Add(156);
                funique.ShowFirstUnique();
                funique.Add(783);
                funique.Add(618);
                funique.Add(210);
                funique.Add(744);
                funique.Add(292);
                funique.Add(994);
                funique.Add(155);
                funique.ShowFirstUnique();
                funique.Add(729);
                funique.Add(72);
                funique.Add(334);
                funique.Add(174);
                funique.Add(395);
                funique.Add(93);
                funique.Add(268);
                funique.Add(853);
                funique.Add(729);
                funique.ShowFirstUnique();
                funique.Add(929);
                funique.Add(439);
                funique.Add(619);
                funique.Add(832);
                funique.Add(478);
                funique.Add(638);
                funique.Add(654);
                funique.Add(162);
                funique.Add(650);
                funique.Add(747);
                funique.Add(838);
                funique.Add(28);
                funique.Add(747);
                funique.Add(332);
                funique.Add(506);
                funique.Add(215);
                funique.Add(893);
                funique.Add(820);
                funique.Add(621);
                funique.ShowFirstUnique();
                funique.Add(973);
                funique.Add(330);
                funique.Add(647);
                funique.Add(774);
                funique.Add(75);
                funique.Add(314);
                funique.Add(778);
                funique.Add(503);
                funique.ShowFirstUnique();
                funique.Add(885);
                funique.Add(454);
                funique.Add(80);
                funique.Add(84);
                funique.Add(487);
                funique.Add(194);
                funique.Add(551);
                funique.Add(489);
                funique.Add(644);
                funique.Add(615);
                funique.Add(657);
                funique.Add(356);
                funique.Add(636);
                funique.Add(741);
                funique.Add(714);
                funique.ShowFirstUnique();
                funique.Add(83);
                funique.Add(73);
                funique.ShowFirstUnique();
                funique.Add(34);
                funique.ShowFirstUnique();
                funique.Add(675);
                funique.Add(570);
                funique.Add(756);
                funique.Add(375);
                funique.Add(81);
                funique.Add(790);
                funique.Add(323);
                funique.Add(456);
                funique.Add(594);
                funique.Add(590);
                funique.Add(80);
                funique.Add(498);
                funique.Add(651);
                funique.Add(546);
                funique.Add(450);
                funique.ShowFirstUnique();
                funique.Add(722);
                funique.Add(946);
                funique.Add(332);
                funique.Add(154);
                funique.Add(136);
                funique.Add(353);
                funique.Add(22);
                funique.Add(122);
                funique.Add(899);
                funique.Add(672);
                funique.Add(667);
                funique.Add(986);
                funique.Add(357);
                funique.Add(622);
                funique.Add(873);
                funique.Add(866);
                funique.Add(820);
                funique.Add(627);
                funique.Add(820);
                funique.ShowFirstUnique();
                funique.Add(623);
                funique.Add(698);
                funique.Add(685);
                funique.Add(167);
                funique.Add(159);
                funique.Add(345);
                funique.Add(425);
                funique.ShowFirstUnique();
                funique.Add(337);
                funique.Add(699);
                funique.Add(787);
                funique.Add(668);
                funique.Add(77);
                funique.Add(678);
                funique.Add(234);
                funique.ShowFirstUnique();
            }

        }

   
        private void btn_Uncrossed_Lines_Click(object sender, EventArgs e)
        {
       
           /*
            
            We write the integers of A and B (in the order they are given) on two separate horizontal lines.

                Now, we may draw connecting lines: a straight line connecting two numbers A[i] and B[j] such that:

                A[i] == B[j];
                The line we draw does not intersect any other connecting (non-horizontal) line.
                Note that a connecting lines cannot intersect even at the endpoints: each number can only belong to one connecting line.

                Return the maximum number of connecting lines we can draw in this way.

                Example 1:

                Input: A = [1,4,2], B = [1,2,4]
                Output: 2
                Explanation: We can draw 2 uncrossed lines as in the diagram.
                We cannot draw 3 uncrossed lines, because the line from A[1]=4 to B[2]=4 will intersect the line from A[2]=2 to B[1]=2.
                Example 2:

                Input: A = [2,5,1,2,5], B = [10,5,2,1,5,2]
                Output: 3
                Example 3:

                Input: A = [1,3,7,1,7,5], B = [1,9,2,5,1]
                Output: 2
 
                Time Complexity : O(MN)
                Space Complexity : O(MN)

             */

            List<UncrossedLines> inputs = new List<UncrossedLines>() {
                                            new UncrossedLines(){A = new int[]{1,4,2 },  B = new int[]{ 1, 2, 4 } },
                                            new UncrossedLines(){A = new int[]{2,5,1,2,5 },  B = new int[]{ 10, 5, 2, 1, 5, 2 } },
                                            new UncrossedLines(){A = new int[]{1,3,7,1,7,5 },  B = new int[]{ 1, 9, 2, 5, 1 } }
                                          };

            StringBuilder result = new StringBuilder();
            foreach (UncrossedLines input in inputs)
            {

                result.AppendLine($"Number of uncrossed lines are {this.MaxUncrossedLines(input.A, input.B)} for the given input A: {string.Join(",", input.A)} and B: {string.Join(",", input.B)}");
            }

            MessageBox.Show(result.ToString());

        }


        public int MaxUncrossedLines(int[] A, int[] B)
        {

            if (A == null || A.Length == 0 || B == null || B.Length == 0)
                return 0;

            int[][] dict = new int[A.Length + 1][];
            int r = 0;
            int c = 0;

            for (r = 0; r < A.Length + 1; r++)
            {
                dict[r] = new int[B.Length + 1];
            }



            for (r = 0; r < A.Length; r++)
            {
                for (c = 0; c < B.Length; c++)
                {
                    if (A[r] == B[c])
                    {
                        dict[r + 1][c + 1] = 1 + dict[r][c];
                    }
                    else
                    {
                        dict[r + 1][c + 1] = Math.Max(dict[r + 1][c], dict[r][c + 1]);
                    }
                }
            }

            return dict[r][c];
        }

        public class UncrossedLines
        {
            public int[] A;
            public int[] B;
        }

        private void btn_Random_Pick_with_Weight_Click(object sender, EventArgs e)
        {
            /*
                Given an array w of positive integers, where w[i] describes the weight of index i, write a function pickIndex which randomly picks an index in proportion to its weight.

                Note:

                1 <= w.length <= 10000
                1 <= w[i] <= 10^5
                pickIndex will be called at most 10000 times.
                Example 1:

                Input: 
                ["Solution","pickIndex"]
                [[[1]],[]]
                Output: [null,0]
                Example 2:

                Input: 
                ["Solution","pickIndex","pickIndex","pickIndex","pickIndex","pickIndex"]
                [[[1,3]],[],[],[],[],[]]
                Output: [null,0,1,1,1,0]
                Explanation of Input Syntax:

                The input is two lists: the subroutines called and their arguments. Solution's constructor has one argument, the array w. pickIndex has no arguments. Arguments are always wrapped with a list, even if there aren't any.
             */


            List<int[]> inputs = new List<int[]>();
            inputs.Add(new int[] { 1, 3 });
            StringBuilder result = new StringBuilder();
            foreach (int[] input in inputs)
            {
                Solution solution = new Solution(input);

                result.Append($"Random pick weight for the given input {string.Join(",", input)} ");
                result.Append($"is {solution.PickIndex()},{solution.PickIndex()},{solution.PickIndex()},{solution.PickIndex()},{solution.PickIndex()}");
            }

            MessageBox.Show(result.ToString());
        }


        public class Solution
        {

            int[] weight = new int[] { };
            int[] cumW;
            Random rand;

            public Solution(int[] w)
            {
                this.weight = w;
                this.cumW = w;
                this.GenerateRandomWeight();
                rand = new Random();
            }

            public int PickIndex()
            {

                if (cumW == null || cumW.Length == 0)
                    return -1;

                //return GetCumIndex(rand.Next(0, cumW[cumW.Length - 1]));
                int ran = rand.Next(0, cumW[cumW.Length - 1]);
                int result =  Array.BinarySearch(cumW, 0, cumW.Length-1, ran);
                return result;
               // Array.BinarySearch(dp, 0, len, input);

            }

            private void GenerateRandomWeight()
            {
                if (weight == null || weight.Length == 0)
                    return;
                cumW = new int[weight.Length];
                int cs = 0;
                for (int i = 0; i < weight.Length; i++)
                {
                    cs += weight[i];
                    cumW[i] = cs;
                }
            }


            private int GetCumIndex(int findVal)
            {
                int l = 0;
                int r = cumW.Length - 1;
                int m = 0;


                while (l < r)
                {
                    m = (l + r) / 2;
                    if (cumW[m] == findVal)
                        return m;
                    else if (cumW[m] > findVal)
                        r = m - 1;
                    else
                        l = m + 1;
                }

                return l;

            }
        }

        private void btn_Coin_Change_2_Click(object sender, EventArgs e)
        {
            /*
                You are given coins of different denominations and a total amount of money. Write a function to compute the number of combinations that make up that amount. You may assume that you have infinite number of each kind of coin.

                Example 1:
                Input: amount = 5, coins = [1, 2, 5]
                Output: 4
                Explanation: there are four ways to make up the amount:
                5=5
                5=2+2+1
                5=2+1+1+1
                5=1+1+1+1+1

                Example 2:
                Input: amount = 3, coins = [2]
                Output: 0
                Explanation: the amount of 3 cannot be made up just with coins of 2.
                
                Example 3:
                Input: amount = 10, coins = [10] 
                Output: 1
             
             */
   

            List<ArrayAndValue> inputs = new List<ArrayAndValue>();
            inputs.Add(new ArrayAndValue() { input = new int[] { 1, 2, 5 }, find = 5 });
            inputs.Add(new ArrayAndValue() { input = new int[] { 2}, find = 3 });
            inputs.Add(new ArrayAndValue() { input = new int[] { 10 }, find = 10 });
            StringBuilder result = new StringBuilder();
            foreach (var input in inputs)
            {                             
                result.AppendLine ($"There are {this.Change(input.find, input.input)} coin change for the given coins { string.Join(",", input.input)} and amount {input.find}");
            }

            MessageBox.Show(result.ToString());
        }

        public int Change(int amount, int[] coins)
        {
            int[] dict = new int[amount + 1];
            dict[0] = 1;
            for (int r = 0; r < coins.Length; r++)
            {
                for (int c = 1; c < dict.Length; c++)
                {
                    if (c >= coins[r])
                    {
                        dict[c] = dict[c - coins[r]] + dict[c];
                    }
                }
            }
            return dict[dict.Length - 1];
        }

        private void btn_Largest_Divisible_Subset_Click(object sender, EventArgs e)
        {
            /*
                    Given a set of distinct positive integers, find the largest subset such that every pair (Si, Sj) of elements in this subset satisfies:

                    Si % Sj = 0 or Sj % Si = 0.

                    If there are multiple solutions, return any subset is fine.

                    Example 1:

                    Input: [1,2,3]
                    Output: [1,2] (of course, [1,3] will also be ok)
                    Example 2:

                    Input: [1,2,4,8]
                    Output: [1,2,4,8]


                    Time Complexity     : O(NLogN) + O(N^2) + (N) = O(N^2)
                    Space Complexity    : O(N)

            */


            List<int[]> inputs = new List<int[]>();
            inputs.Add(new int[] {1,2,3 });
            inputs.Add(new int[] { 1, 2, 4, 8 });
            StringBuilder result = new StringBuilder();
            foreach (var input in inputs)
            {
                result.AppendLine($"Largest divisible subset  are {string.Join(", ",this.LargestDivisibleSubset(input))} for the given input{ string.Join(",", input)}");
            }
            MessageBox.Show(result.ToString());


        }


        public IList<int> LargestDivisibleSubset(int[] nums)
        {


            List<int> result = new List<int>();
            if (nums == null || nums.Length == 0)
                return result;


            Array.Sort(nums); //O(NLogN)
            int[] dict = Enumerable.Repeat<int>(1, nums.Length).ToArray(); 
            int max = 1;


            for (int i = 1; i < nums.Length; i++) //O(N^2)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] % nums[j] == 0 && (1 + dict[j]) > dict[i])
                        dict[i] = 1 + dict[j];

                    if (dict[i] > max)
                        max = dict[i];
                }
            }

            int prev = -1;


            for (int i = dict.Length - 1; i >= 0; i--) //O(N)
            {
                if (dict[i] == max && (prev % nums[i] == 0 || prev == -1))
                {
                    result.Add(nums[i]);
                    max--;
                    prev = nums[i];
                }
            }


            return result;
        }

        private void btn_H_Index_II_Click(object sender, EventArgs e)
        {

            /*

                Given an array of citations sorted in ascending order (each citation is a non-negative integer) of a researcher, write a function to compute the researcher's h-index.

                According to the definition of h-index on Wikipedia: "A scientist has index h if h of his/her N papers have at least h citations each, and the other N − h papers have no more than h citations each."

                Example:

                Input: citations = [0,1,3,5,6]
                Output: 3 
                Explanation: [0,1,3,5,6] means the researcher has 5 papers in total and each of them had 
                             received 0, 1, 3, 5, 6 citations respectively. 
                             Since the researcher has 3 papers with at least 3 citations each and the remaining 
                             two with no more than 3 citations each, her h-index is 3.
                Note:

                If there are several possible values for h, the maximum one is taken as the h-index.

                Follow up:

                This is a follow up problem to H-Index, where citations is now guaranteed to be sorted in ascending order.
                Could you solve it in logarithmic time complexity?


                Time Complexity         : O(log N)
                Space Complexity        : O(1)

            */


            List<int[]> inputs = new List<int[]>();
            inputs.Add(new int[] { 0, 1, 3, 5, 6 });
            inputs.Add(new int[] { 100 });
            inputs.Add(new int[] { 0 });
            StringBuilder result = new StringBuilder();
            
            foreach (var input in inputs)
            {
                result.AppendLine($"H Index is {this.HIndex_WithExtraSpace(input)} for the given input { string.Join(",", input)}");
                //HIndex_WithExtraSpace(input)
            }

            MessageBox.Show(result.ToString());
        }


        public int HIndex_WithExtraSpace(int[] citations)
        {
            int length = citations.Length;
            int[] buckets = new int[length + 1];

            for (int i = 0; i < length; i++)
            {
                if (citations[i] >= length)
                    buckets[length]++;
                else
                    buckets[citations[i]]++;
            }

            int count = 0;
            for (int i = length; i >= 0; i--)
            {
                count += buckets[i];
                if (count >= i)
                    return i;
            }

            return 0;
        }

        public int HIndex(int[] citations)
        {
            if (citations == null || citations.Length == 0)
                return 0;

            int cl = citations.Length;
            int l = 0;
            int r = citations.Length - 1;
            int m = 0;
            int res = 0;


            while (l <= r)
            {
                m = (l + r) / 2;

                if (citations[m] == (cl - m))
                    return citations[m];
                else if (citations[m] > cl - m)
                    r = m - 1;
                else
                    l = m + 1;

            }
            return cl - l;

        }

        private void btn_Single_Number_II_Click(object sender, EventArgs e)
        {

            
            /*

                Given a non-empty array of integers, every element appears three times except for one, which appears exactly once. Find that single one.
                Note:

                Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory?

                Example 1:

                Input: [2,2,3,2]
                Output: 3
                Example 2:

                Input: [0,1,0,1,0,1,99]
                Output: 99

                Time Complexity         : O(N)
                Space Complexity        : O(1)

            */


            List<int[]> inputs = new List<int[]>();
            inputs.Add(new int[] { 0, 1, 3, 5, 6 });
            inputs.Add(new int[] { 100 });
            inputs.Add(new int[] { 0 });
            StringBuilder result = new StringBuilder();

            foreach (var input in inputs)
            {
                result.AppendLine($"Single Number which is not repeating is {this.SingleNumber(input)} for the given input { string.Join(",", input)}");
            }

            MessageBox.Show(result.ToString());


        }


        public int SingleNumber(int[] nums)
        {

            int s1 = 0;
            int s2 = 0;

            foreach (int i in nums)
            {
                s1 = (s1 ^ i) & (~s2);
                s2 = (s2 ^ i) & (~s1);
            }

            return s1;

        }

        private void btn_Find_the_Duplicate_Number_Click(object sender, EventArgs e)
        {
            
            
            /*
             
            Given an array nums containing n + 1 integers where each integer is between 1 and n (inclusive), prove that at least one duplicate number must exist. Assume that there is only one duplicate number, find the duplicate one.

            Example 1:

            Input: [1,3,4,2,2]
            Output: 2
            Example 2:

            Input: [3,1,3,4,2]
            Output: 3
            Note:

            You must not modify the array (assume the array is read only).
            You must use only constant, O(1) extra space.
            Your runtime complexity should be less than O(n2).
            There is only one duplicate number in the array, but it could be repeated more than once.
             

            Time Complexity     : O(N)
            Space Complexity    : O(1)

            */
            List<int[]> inputs = new List<int[]>();
            inputs.Add(new int[] { 1, 3, 4, 2, 2 });
            inputs.Add(new int[] { 3, 1, 3, 4, 2 });            
            StringBuilder result = new StringBuilder();

            foreach (var input in inputs)
            {
                result.AppendLine($"Duplicate number is  {this.FindDuplicate(input)} for the given input { string.Join(",", input)}");
            }

            MessageBox.Show(result.ToString());
        }

        public int FindDuplicate(int[] nums)
        {
            int num1 = 0;
            int num2 = 0;

            do
            {
                num1 = nums[num1];
                num2 = nums[nums[num2]];
            } while (num1 != num2);

            num1 = 0;

            while (num1!=num2)
            {
                num1 = nums[num1];
                num2 = nums[num2];
            }


            return num2;
            
        }

        private void btn_Top_K_Frequent_Elements_Click(object sender, EventArgs e)
        {
            /*

                Given a non-empty array of integers, return the k most frequent elements.

                Example 1:

                Input: nums = [1,1,1,2,2,3], k = 2
                Output: [1,2]
                Example 2:

                Input: nums = [1], k = 1
                Output: [1]
                Note:

                You may assume k is always valid, 1 ≤ k ≤ number of unique elements.
                Your algorithm's time complexity must be better than O(n log n), where n is the array's size.
                It's guaranteed that the answer is unique, in other words the set of the top k frequent elements is unique.
                You can return the answer in any order.

                Time Complexity             : O(N + log N) which O(N)
                Space Complexity            : O(K) where K is the requent element


            */

            
            List<ArrayAndValue> inputs = new List<ArrayAndValue>();
            inputs.Add(new ArrayAndValue() { input = new int[] { 1, 1, 1, 2, 2, 3 }, find = 2 });
            inputs.Add(new ArrayAndValue() { input = new int[] { 1, 3, 3, 2, 2, 3 }, find = 2 });
            inputs.Add(new ArrayAndValue() { input = new int[] { 1 }, find = 1 });
            inputs.Add(new ArrayAndValue() { input = new int[] { 1,1 }, find = 2 });

            StringBuilder result = new StringBuilder();
            foreach (var sip in inputs)
            {
                result.Append($"The K Frequent Elements are {string.Join(",",this.TopKFrequent(sip.input, sip.find))} for the given int array {string.Join(" ", sip.input)} for the give K {sip.find}  \n");
            }

            MessageBox.Show(result.ToString());


        }


        public int[] TopKFrequent(int[] nums, int k)
        {

            if (nums == null || nums.Length == 0 || nums.Length == k)
                return nums;

            Dictionary<int, int> dict = new Dictionary<int, int>();


            foreach (int j in nums)
            {
                if (!dict.ContainsKey(j))
                    dict[j] = 1;
                else
                    dict[j]++;
            }

            int i = 0;
            Heap[] heap = new Heap[dict.Count];
            foreach (int key in dict.Keys)
            {
                heap[i] = new Heap() { Value = key, Count = dict[key] };
                i++;
            }

            this.BuildHeap(heap);
            int[] result = new int[k];

            for (i = 0; i < k; i++)
            {
                Heapify(heap, 0, heap.Length - 1 - i);
                result[i] = heap[0].Value;
                heap[0] = heap[heap.Length - 1 - i];
            }

            return result;


        }

        private void BuildHeap(Heap[] heap)
        {
            int i = (heap.Length - 1) / 2;

            while (i >= 0)
            {
                Heapify(heap, i, heap.Length - 1);
                i--;
            }
        }

        private void Heapify(Heap[] heap, int i, int n)
        {

            int l = (i * 2);
            int r = (i * 2) + 1;
            int h = i;

            if (l <= n && heap[l].Count > heap[h].Count)
                h = l;
            if (r <= n && heap[r].Count > heap[h].Count)
                h = r;

            if (h != i)
            {
                this.Swap(heap, i, h);
                this.Heapify(heap, h, n);
            }
        }


        private void Swap(Heap[] heap, int i, int j)
        {
            Heap temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }

        public class Heap
        {
            public int Value;
            public int Count;
        }

        private void btn_Single_Number_III_Click(object sender, EventArgs e)
        {
            /*
        
                Given an array of numbers nums, in which exactly two elements appear only once and all the other elements appear exactly twice. Find the two elements that appear only once.
                Example:

                Input:  [1,2,1,3,2,5]
                Output: [3,5]
                Note:

                The order of the result is not important. So in the above example, [5, 3] is also correct.
                Your algorithm should run in linear runtime complexity. Could you implement it using only constant space complexity?

                Time Complexity     : O(N)
                Space Complexity    : O(1)    

            */

            List<int[]> inputs = new List<int[]>();
            inputs.Add(new int[] { 1, 2, 1, 3, 2, 5 });
            
            StringBuilder result = new StringBuilder();

            foreach (var input in inputs)
            {
                result.AppendLine($"Single Number which is not repeating is {string.Join(",",this.SingleNumber_3(input))} for the given input { string.Join(",", input)}");
            }

            MessageBox.Show(result.ToString());
        }

        public int[] SingleNumber_3(int[] nums)
        {
            int bitmask = 0;
            foreach (int num in nums)
                bitmask ^= num;

            int diff = bitmask & (-bitmask);
            int x = 0;

            foreach (int num in nums)
                if ((num & diff) != 0)
                    x ^= num;

            return new int[] { x, bitmask ^ x };
        }

        private void btn_Find_Minimum_in_Rotated_Sorted_Array_II_Click(object sender, EventArgs e)
        {

            
            /*
             
                Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.

                (i.e.,  [0,1,2,4,5,6,7] might become  [4,5,6,7,0,1,2]).

                Find the minimum element.

                The array may contain duplicates.

                Example 1:

                Input: [1,3,5]
                Output: 1
                Example 2:

                Input: [2,2,2,0,1]
                Output: 0
            
                Time Complexity     : O(log N)
                Space Complexity    : O(1);

             */

            List<int[]> inputs = new List<int[]>();
            inputs.Add(new int[] { 3, 1, 3 });
            inputs.Add(new int[] { 1, 2, 3 });
            inputs.Add(new int[] { 2, 2, 2, 1, 2 });
            inputs.Add(new int[] { 1, 2, 1 });
            inputs.Add(new int[] { 3, 1, 1 });
            inputs.Add(new int[] { 10, 1, 10, 10, 10 });

            StringBuilder result = new StringBuilder();
            foreach (var input in inputs)
            {
                result.Append($"Minimum in Rotated Sorted Array is {this.FindMin(input)} for the given  array {string.Join(" ", input)}\n");
            }

            MessageBox.Show(result.ToString());

        }

        public int FindMin(int[] nums)
        {
            if (nums == null && nums.Length == 0)
                return -1;

            int s = 0;
            int e = nums.Length - 1;
            int m = 0;
            
            while (s < e)
            {
                if (s == e)
                    break;

                m = (s + e) / 2;

                if (nums[m] > nums[e])
                    s = m + 1;
                else if (nums[m] < nums[e])
                    e = m;
                else
                    e--;

            }

            return nums[s];

        }

        private void btn_Task_Scheduler_Click(object sender, EventArgs e)
        {
            /*
                    You are given a char array representing tasks CPU need to do. It contains capital letters A to Z where each letter represents a different task. Tasks could be done without the original order of the array. 
                    Each task is done in one unit of time. For each unit of time, the CPU could complete either one task or just be idle.

                    However, there is a non-negative integer n that represents the cooldown period between two same tasks (the same letter in the array), that is that there must be at least n units of time between any two
                    same tasks.

                    You need to return the least number of units of times that the CPU will take to finish all the given tasks.

                    Example 1:

                    Input: tasks = ['A','A','A','B','B','B'], n = 2
                    Output: 8
                    Explanation: 
                    A -> B -> idle -> A -> B -> idle -> A -> B
                    There is at least 2 units of time between any two same tasks.
                    Example 2:

                    Input: tasks = ['A','A','A','B','B','B'], n = 0
                    Output: 6
                    Explanation: On this case any permutation of size 6 would work since n = 0.
                    ["A","A","A","B","B","B"]
                    ["A","B","A","B","A","B"]
                    ["B","B","B","A","A","A"]
                    ...
                    And so on.
                    Example 3:

                    Input: tasks = ["A","A","A","A","A","A","B","C","D","E","F","G"], n = 2
                    Output: 16
                    Explanation: 
                    One possible solution is
                    A -> B -> C -> A -> D -> E -> A -> F -> G -> A -> idle -> idle -> A -> idle -> idle -> A
 

                    Constraints:

                    The number of tasks is in the range [1, 10000].
                    The integer n is in the range [0, 100].


                    Time Complexity     : O(NLogN)
                    Space Complexity    : O(26)
            */

            

            List<TaskCoolDown> tasks = new List<TaskCoolDown>();
            tasks.Add(new TaskCoolDown() { CharTasks = new char[] { 'A', 'A', 'A', 'B', 'B', 'B' }, Cooldown = 2 }); // 1--12-12
            tasks.Add(new TaskCoolDown() { CharTasks = new char[] { 'A', 'A', 'A', 'B', 'B', 'B' }, Cooldown = 0 }); // 123-123
            tasks.Add(new TaskCoolDown() { CharTasks = new char[] { 'A', 'A', 'A', 'A', 'A', 'A', 'B', 'C', 'D', 'E', 'F', 'G' }, Cooldown = 2 }); // 123-123

            StringBuilder message = new StringBuilder();

            foreach (var task in tasks)
            {
                message.AppendLine($"There {this.LeastInterval(task.CharTasks, task.Cooldown)} least number of units of times that the CPU will take to finish all the given tasks {string.Join(",",task.CharTasks)}");

            }
            MessageBox.Show(message.ToString());



        }

        public int LeastInterval(char[] tasks, int n)
        {
            if (tasks == null || tasks.Length == 0)
                return 0;

            int[] dict = new int[26];

            foreach (char c in tasks)
                dict[c - 'A']++;

            Array.Sort(dict);

            int chunk = dict[25] - 1;
            int idle = chunk * n;

            for (int i = 24; i >= 0; i--)
            {
                idle -= Math.Min(chunk, dict[i]);
            }


            return idle < 0 ? tasks.Length : idle + tasks.Length;


        }

        private void btn_Best_Time_to_Buy_and_Sell_Stock_with_Cooldown_Click(object sender, EventArgs e)
        {
            /*
             
                Say you have an array for which the ith element is the price of a given stock on day i.

                Design an algorithm to find the maximum profit. You may complete as many transactions as you like (ie, buy one and sell one share of the stock multiple times) with the following restrictions:

                You may not engage in multiple transactions at the same time (ie, you must sell the stock before you buy again).
                After you sell your stock, you cannot buy stock on next day. (ie, cooldown 1 day)
                Example:

                Input: [1,2,3,0,2]
                Output: 3 
                Explanation: transactions = [buy, sell, cooldown, buy, sell]

                Time Complexity     : O(N)
                Space Complexity    : O(1)

            */

            List<int[]> inputs = new List<int[]>();
            inputs.Add(new int[] { 1,2,3,0,2 });
            
            StringBuilder result = new StringBuilder();

            foreach (var input in inputs)
            {
                result.AppendLine($"Max profit is {this.MaxProfit_3(input)} for the given input { string.Join(",", input)}");
            }

            MessageBox.Show(result.ToString());

        }


        public int MaxProfit_3(int[] prices)
        {
            if (prices == null || prices.Length == 0 || prices.Length == 1)
                return 0;
 
            if (prices.Length == 2)
                if (prices[1] > prices[0])
                    return prices[1] - prices[0];
                else
                    return 0;


            /*
                A = Math.Max(PrevA, PrevC)      // Buy
                B = Math.Max(B,PrevA-prices[i]) // Sell
                C = PrebB + Prices[i]           // Sell            

             */


            int a = 0;            
            int b = -prices[0];            
            int c = 0;
            int t = 0;

            
            for(int i = 1; i < prices.Length; i++)
            {
                t = a;
                a = Math.Max(t, c); 
                c = b + prices[i]; 
                b = Math.Max(b, t - prices[i]); 
                
            }

            return Math.Max(a,c);
            


        }

        private void btn_Find_All_Duplicates_in_an_Array_Click(object sender, EventArgs e)
        {
            /*
                Given an array of integers, 1 ≤ a[i] ≤ n (n = size of array), some elements appear twice and others appear once.

                Find all the elements that appear twice in this array.

                Could you do it without extra space and in O(n) runtime?

                Example:
                Input:
                [4,3,2,7,8,2,3,1]

                Output:
                [2,3]
             
             */

            List<int[]> inputs = new List<int[]>();
            inputs.Add(new int[] { 4, 3, 2, 7, 8, 2, 3, 1 });

            StringBuilder result = new StringBuilder();

            foreach (var input in inputs)
            {
                result.AppendLine($"The duplicate numbers are {string.Join(",", this.FindDuplicates(input))} for the given input { string.Join(",", input)}");
            }

            MessageBox.Show(result.ToString());



        }

        public IList<int> FindDuplicates(int[] nums)
        {

            /* My solution
             
            List<int> result = new List<int>();

            if (nums == null || nums.Length == 0)
                return result;

            HashSet<int> dict = new HashSet<int>();
            foreach (int i in nums)
            {
                if (dict.Contains(i))
                    result.Add(i);
                else
                    dict.Add(i);
            }

            return result; 
            */



            /*
                0 ,1 ,2, 3, 4, 5, 6, 7
                4, 3, 2, 7, 8, 2, 3, 1
                -4 ,-3,-2,-7,  ,  ,-3 ,-1              

            */
            var dups = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var index = Math.Abs(nums[i]) - 1;
                if (nums[index] < 0)
                    dups.Add(index + 1);
                else
                    nums[index] = -nums[index];
            }

            return dups;
        }

        private void btn_Sort_Array_By_Parity_Click(object sender, EventArgs e)
        {
            /*
                Given an array A of non-negative integers, return an array consisting of all the even elements of A, followed by all the odd elements of A.

                You may return any answer array that satisfies this condition.

                Example 1:

                Input: [3,1,2,4]
                Output: [2,4,3,1]
                The outputs [4,2,3,1], [2,4,1,3], and [4,2,1,3] would also be accepted.
            */



            List<int[]> inputs = new List<int[]>();
            inputs.Add(new int[] { 3, 1, 2, 4 });

            StringBuilder result = new StringBuilder();

            foreach (var input in inputs)
            {
                result.AppendLine($"Sort Array By Parity for the given input { string.Join(",", input)}  is {string.Join(",", this.SortArrayByParity(input))} ");
            }

            MessageBox.Show(result.ToString());
        }


        public int[] SortArrayByParity(int[] A)
        {
            if (A == null || A.Length == 0)
                return new int[] { };

            int l = 0;
            int r = A.Length - 1;

            while (l < r)
            {
                if (A[l] % 2 == 1)
                {
                    Swap(A, l, r);
                    r--;
                }
                else
                    l++;

            }

            return A;
        }

        private void btn_Largest_Time_for_Given_Digits_Click(object sender, EventArgs e)
        {
            /*
                    Given an array of 4 digits, return the largest 24 hour time that can be made.

                    The smallest 24 hour time is 00:00, and the largest is 23:59.  Starting from 00:00, a time is larger if more time has elapsed since midnight.

                    Return the answer as a string of length 5.  If no valid time can be made, return an empty string.

 

                    Example 1:

                    Input: [1,2,3,4]
                    Output: "23:41"
                    Example 2:

                    Input: [5,5,5,5]
                    Output: ""
 

                    Note:

                    A.length == 4
                    0 <= A[i] <= 9  

                    Time Complexity     :  Always the elements will be 4 in input array so the number would 4*3*2*1 = 24 O(24) which can be assumed O(1)
                    Space Complexity    : O(1)
             */


            List<int[]> inputs = new List<int[]>();
            inputs.Add(new int[] { 1, 2, 3, 4 });
            inputs.Add(new int[] { 0, 9, 0, 0 });
            inputs.Add(new int[] { 0, 9, 1, 0 });
            inputs.Add(new int[] { 9, 9, 9, 9 });
            inputs.Add(new int[] { 0, 0, 0, 0 });
            inputs.Add(new int[] { 2, 0, 6, 6 });
            
            StringBuilder result = new StringBuilder();

            foreach (var input in inputs)
            {
                result.AppendLine($"Largest Time  for the given input {string.Join(",", input)} is { LargestTimeFromDigits(input)} ");
            }

            MessageBox.Show(result.ToString());
        }

        public string LargestTimeFromDigits(int[] A)
        {
            string hh;
            string mm;
            string result = string.Empty;
            string temp;
            
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        if (!(i == j || j == k || k == i))
                        {
                            hh = $"{A[i]}{A[j]}";
                            mm = $"{A[k]}{A[6 - i - j - k]}";
                            temp = $"{hh}:{mm}";
                            if (hh.CompareTo("24") < 0 && mm.CompareTo("60") < 0 && temp.CompareTo(result) > 0)
                                result = temp;
                        }
                    }
                }
            }

            return result;

        }

        private void btn_Contains_Duplicate_III_Click(object sender, EventArgs e)
        {
            /*
             
                Given an array of integers, find out whether there are two distinct indices i and j in the array such that the absolute difference between nums[i] and nums[j] is at
                most t and the absolute difference between i and j is at most k.

                Example 1:
                Input: nums = [1,2,3,1], k = 3, t = 0
                Output: true

                Example 2:
                    Input: nums = [1,0,1,1], k = 1, t = 2
                    Output: true
            
                Example 3:
                   Input: nums = [1,5,9,1,5,9], k = 2, t = 3
                    Output: false
                Hint #1  
                Time complexity O(n logk) - This will give an indication that sorting is involved for k elements.
               
                Hint #2  
                Use already existing state to evaluate next state - Like, a set of k sorted numbers are only needed to be tracked. When we are processing the next number in array, then we can utilize the existing sorted state and it is not necessary to sort next overlapping set of k numbers again.

                Time Complexity         :   O(nlogk)
                Space Complexity        :   O(N)
             */

            StringBuilder result = new StringBuilder();
            List<Duplicate3> inputs = new List<Duplicate3>();
            //inputs.Add(new Duplicate3() { Input = new int[] { 1, 2, 3, 1 }, T = 0, K = 3 });
            //inputs.Add(new Duplicate3() { Input = new int[] { 1, 0, 1, 1 }, T = 2, K = 1 });
            //inputs.Add(new Duplicate3() { Input = new int[] { 1, 5, 9, 1, 5, 9 }, T = 3, K = 2 });
            //inputs.Add(new Duplicate3() { Input = new int[] { -1, 2147483647 }, T = 2147483647, K = 1 });
            //inputs.Add(new Duplicate3() { Input = new int[] { 2433, 3054, 9952, 6470, 2509, 8502, -8802, -5276, 6559, -9555, -4765, 6399, 6543, 2027, 1723, -3032, -3319, -7726, -1425, -7431, -7492, 4803, 7952, -6603, -784, -8011, 6161, -6955, 5800, 5834, -6310, 1097, 2327, -4007, 8664, -9619, 5922, 518, 9740, 9976, 4257, -7803, 6023, 4189, -5167, -4699, 2441, 5941, 3663, 625, 5402, -3447, 8888, 9040, -4811, -7547, 6822, 1415, 9372, -9262, 4584, 4149, -276, -4019, 198, 608, -4466, 5383, 7871, 3149, -8358, 9270, 3565, -882, -9494, -6475, 9833, -7744, -598, 5299, 5976, 7361, -9444, 3771, -5718, 9051, 3469, -4028, 4216, 5506, -8611, -9744, -8007, 213, -3454, -2420, 6283, -5616, -3508, -1329, 4694, -7219, 2056, 9063, -9648, -7722, -755, -9482, 9078, -8411, -3393, -4395, -1203, -2165, 2170, 8643, -5205, 4050, -9322, 6178, -973, -331, 7559, -7889, 3499, -7195, 7725, -9155, 3899, -5259, 1981, 4766, 595, -7183, 4150, -2062, 3288, 5047, -9789, 1507, -4937, 5909, -3442, -4599, -789, 6931, -3100, -9151, -3665, -4228, -7466, 6393, 6632, -5133, -7684, 4525, 1150, 3826, -6424, -1689, 6206, -5747, 8061, 1502, -3893, -8528, 2387, -6159, -1355, -5789, 1361, -1593, -8955, 4505, 8885, -7793, 8038, -8401, 9688, 6241, 2518, 7115, -7193, -2735, 5665, 8331, -1822, -6938, 3307, 4019, 6020, -8340, -7138, 4478, -6911, -1241, 3829, -5387, -3139, -1707, -187, -9148, -8734, -9570, 4666, -9280, -31, -4474, -5569, 548, 5768, -7954, -9796, 9525, -56, -450, -7316, 5987, 25, -9590, 586, -4942, -8193, -3165, 6832, 1436, -106, -7393, -6921, -9176, 8404, 1220, 9014, 224, 2145, 4099, -3517, -6904, 6707, 3274, 1374, 1868, -2740, -3041, -9858, 6342, -166, -3181, 6941, 1132, -685, -8060, -7796, 5228, 9936, -15, -8382, -76, 4910, -9735, -8025, 9225, -4619, 4279, 5578, 1910, -659, 834, 1501, 7328, -8782, -6110, -4776, 1321, 5721, 2014, 5767, -5541, -7052, -2716, 7768, -5243, -5997, 7162, 3157, -8769, 2776, 3018, 6159, 7571, -3806, -6260, -3565, 5508, 6517, -9469, 9652, 4320, 8409, 7357, 3609, 4760, 1162, -1186, -6994, -2294, 1820, -3094, -9049, -2426, 9577, 7051, -8080, -4335, 3428, 4351, 1729, 9169, 989, 1624, -1275, -577, 5765, -7344, -8206, -4561, 8191, 1709, 4416, 9256, 2439, 3907, -696, 4164, -5627, 3748, -1003, -7352, -9282, 4822, -877, -5078, 2783, -8127, 8810, -5625, -3563, -3644, 4009, -3791, -5544, 3696, -7041, -6941, -54, -2702, -8501, 4985, 7330, 7466, 526, -2886, 8098, -2973, -6142, -8740, -2965, -2264, -8868, -5292, -7997, 8192, -4444, -1954, 1634, 8758, -6569, -5179, -6504, -8153, 1787, 8669, -8513, -9875, 1694, 3144, -9540, -2051, -927, 2037, 1708, -1464, -9667, 6297, 7912, -1327, 785, -3514, 9784, 1840, 3709, -5542, -4282, -8051, 7006, -3899, 9159, 9430, 7492, -2751, -5174, 5860, 1499, -9942, -4468, -5941, 5589, -5699, 5429, 6743, 8444, -2039, -6824, -1257, -5906, 8266, -3831, 5392, 1645, 320, 1572, -9595, -454, 7877, -8070, -8432, -7719, -4199, 6043, -5002, 7800, 2363, -2493, 2626, 3390, 6243, -2734, 7055, 8290, 5547, 2828, -4021, 3943, -5139, 8892, 1597, -7757, 7532, -3109, 8516, 8161, -8882, -3209, 6165, 7309, -1325, 7792, 7918, -3936, 7859, -7681, -4647, -6123, 2293, -9438, -5270, -5978, -4520, -9347, -4569, 7858, 8471, 910, -6564, -9980, -1603, -7042, 5674, 2103, -9855, -9269, 5549, -4239, 4236, 8890, 9624, 1528, 9666, 3458, -643, -6591, -9008, -6535, -5993, -2978, -3478, -4844, 3370, 2072, -5256, -8584, -7659, 4674, -2893, -7729, -2212, 2792, -9012, 5011, 5325, 1698, 9680, 894, -8603, 4059, -4729, -8749, -3854, 2875, -527, -9600, 3236, -6607, -4491, -3488, -1586, -1579, -9039, -372, -2798, 8904, 1688, -1669, -83, -8200, -490, -6849, 9792, 90, -9453, 9725, -3525, -221, 5067, 4441, 796, 5324, 5284, 8709, -5893, 8174, 970, -1067, -9517, 2046, 1590, -2975, 9544, -7984, -7701, 8644, 8456, -212, 77, 5664, -7414, 8321, 7407, -756, 7649, -4851, -1071, 278, -5076, 6462, -8670, -4849, 914, -4500, 5401, -7112, -4464, -7643, -3685, -5307, 1749, 6949, 1478, -6243, 9320, 2516, -798, 9095, 5627, 6327, -185, -6435, 8979, 6985, 4570, 6442, -909, 3919, 1880, 4593, -2440, 2523, 7331, 2662, 4287, 3712, 4071, -2609, -9451, -6762, -5388, -1929, 8572, 3566, 1354, 1957, -147, -1628, 6002, -4368, 8312, -2033, -6340, -4190, -8975, 6894, 177, -3761, 2310, 3794, -8940, 1444, -6522, 325, -1908, -88, -3091, -7472, 5990, -5134, 8089, -9055, -9485, 2582, -6927, 5660, -3187, 8264, 8960, -1842, 3308, -1809, -1378, 2943, 430, 2192, 364, -9458, 1143, 8672, 4037, -7739, 9640, -2534, -272, -3122, 417, 693, -2732, -7286, 8564, -8604, 850, -1055, 9967, -7016, -3601, -1125, -7953, 5331, 2822, 2729, -3483, 1048, -8439, 9281, 2960, 1539, 4929, -5151, 2635, -7023, -8865, -567, -3486, -6882, -1892, 3741, 5260, -7132, -453, 6482, 1433, -8227, 2897, 6354, 686, -9429, -9521, -6943, -329, -4735, 7590, -6850, 8844, 5423, 3169, -2041, 7308, 7823, -7166, 6927, -1738, -1644, -7447, 1238, -9832, -7865, -6837, -7097, 9469, -1927, -7043, 6872, -2683, -5509, 7301, 5147, -3235, 5039, -4323, 6414, 1104, 4745, -6222, 4113, -6663, -5571, 7765, 7034, 7741, -2855, -7126, 5866, -5831, 2790, 9748, 8665, -2383, 761, -690, 4540, 7229, -8187, 10, 6426, -6312, 8287, -8522, -4186, 2083, 8592, 3843, 8052, -9844, 8562, 671, 1969, 4215, 2178, 1686, -9412, -5527, -1193, 6643, -5515, -5389, 3820, -7104, 9546, 1409, 6613, 1086, -3375, 1192, -382, 6891, -4693, -8897, 763, 3457, 2538, -2011, -9687, 5935, 8929, 7525, 3583, -8451, 792, -5564, 7589, 9828, -488, 4846, -268, 5675, -1462, 8345, 2868, -2189, -509, -6179, -1624, 1404, 8326, -5867, 2224, -5598, 2684, 5628, 5000, 5586, -5596, 104, -2182, -5108, -3698, 5107, -8532, 5697, 6932, -6650, 6223, 1950, -7535, 2515, -1153, 2927, 6450, -9417, -668, -2708, -5852, 7896, 4219, -6388, 6457, 8170, 9459, -1415, 2075, -672, 7471, 6784, 909, 3362, 2855, -7060, 276, 2460, 214, -28, 3590, 5360, -1444, -6224, 5706, 5787, -650, -9022, 3981, -9607, -8154, -186, -326, -7585, 758, 5317, -4695, 8878, 3850, 8796, 7252, -2816, 158, -6765, 5338, 848, -7147, 7581, -7842, 3101, 2660, -6171, 9011, -6455, 567, -8751, 8970, 6860, 9899, -1916, -379, 9836, 9812, 5918, 4767, -6087, -6304, -3743, -8908, -870, -7500, 3316, 655, 6576, -4136, 2322, 8475, 678, 4156, -7231, 4017, -2007, 3045, 5605, 6209, 3656, 3533, 3176, 1190, 9311, -6433, 2446, 2022, 2546, -2880, -9502, -3760, 5612, 8343, -3062, 9484, 3510, -7716, 4638, 8716, 5799, -7091, 7261, 4651, -2252, 8911, -2245, -8361, 6840, 8027, -7820, -674, -5250, 916, 935, 9579, 7335, -3061, 47, -1549, 1268, 3737, -3646, -6254, -9574, -3325, -944, -328, -7886, 174, 8521, 2926, -984, 6098, 5908, -2587, 3264, 9396, -6622, 866, 9454, 4568, -6283, -9395, 5571, 1852, 4225, -2240, -4085, -1947, 6282, -402, -3668, 2856, -3157, -1207, -821, -9157, -9706, -3059, -7766, 8096, -4785, -8032, 9549, -246, 2107, -9114, 4969, 8656, -4198, 8862, 4998, 1333, 754, -8272, 8053, -5895, -6466, -8942, 9123, 480, -7590, -7003, 7635, -2787, 3306, -1426, 3121, 5481, -1988, 6581, 1961, 2840, -1485, 8741, -7160, -5012, 5988, 3385, 4146, 7236, -7857, -213, 1522, 6533, 5625, -1393, -7745, 2114, -6554, 5327, -1923, 3620, -475, 7214, -6366, -647, -7150, 8124, 4773, 1379, -2331, 6569, 712, 5142, 8172, 1909, -1775, 6846, 4834, 2139, 2862, 1674, 124, -2143, -6352, 9527, 1032, -2364, 7452, 9555, -6917, 8727, -5303, 1016, 9418, 9009, -4900, -3717, -8094, 9308, -3734, 6889, -9020, -7255, 9136, -6502, 4754, 8007, -3553, 6621, -9887, 7165, -5888, 4871, -5054, 4551, 9497, -8242, -1074, 9346, -6785, 658, 2940, -3551, -7351, 4970, 9875, -549, -2678, 1895, -8681, 8113, 3513, 3814, -603, -1681, -9169, -8353, 8399, -3327, 2397, -5185, 6570, 4196, -5021, 4547, 7128, -8991, 2630, -3355, -6151, 2491, -9736, -1390, -1180, -2960, -5116, 3485, 5002, 901, -7386, 8790, -1962, 190, 3097, -6429, 2815, -8061, -3195, 2311, 100, -9665, -5786, -6537, -8466, 3266, 543, 1628, -5824, 1160, -5396, 7511, 1835, 2279, -114, -5036, -8406, 9729, -2730, -5432, -5807, 7778, 2738, -1692, 2371, -1217, -6721, -9377, 8162, -8638, -5375, 8145, 8178, -3356, 6293, -4336, -7357, 7368, -6077, -2523, 7213, 2478, -6353, 1667, 5499, 357, -222, -6212, 3039, -8204, 2395, -6318, 6422, 6418, -8972, 611, 7211, -7928, -4997, 7603, -375, 9557, 1481, -5260, -8262, -5448, 1860, 9245, 6486, 2144, 6654, 8272, -2350, 8233, -6425, 7723, 777, -9881, -5674, -1631, 8677, -5850, -3087, 9476, 9018, -9287, 9939, -9243, 9752, -4692, -723, -7967, -1476, -1192, 9830, -9362, 8883, 522, -8042, -3363, 7444, -3914, -244, 8514, -6967, -7156, -7691, 5822, 9825, -8379, -8097, -8587, 7845, -1247, -2819, -1971, 3106, 9591, 8243, -3183, -1297, 436, -613, -4664, 3275, -1722, 3780, -4515, 5889, 3360, -1977, 7641, -9092, -9161, 4922, 5750, -5686, 7325, 7172, 7188, 2088, -9067, -9069, 9799, 3221, -6016, 9128, 3584, 6567, 2346, 8128, -9925, -3000, -5769, -6021, -6952, -4603, -9296, 6489, -1540, 3740, -5348, 7338, -1677, 9075, 8051, 6663, 4583, -1560, 839, 8210, 202, -662, -5267, -1508, 3540, 3619, 3932, 4548, 9253, 9637, -5090, -5944, -8771, 119, 6086, -2995, 752, 9013, 2953, -5557, -4612, 6675, 5041, -6322, 2398, -492, -3432, -761, -3458, -5011, -7087, 7520, -2209, -7542, 1658, -325, -2429, -4022, 74, -9715, 2552, 1947, 225, -8295, 5667, -6076, -7314, -8977, -1283, -1980, -4481, -2201, 8209, -1764, 4573, -7808, 5180, -1777, 3166, 5806, 7209, -8236, -6035, 6856, -3128, 3948, -621, -3809, -2982, 1375, 7797, 4703, 7110, -1017, 59, 4900, 934, -922, 994, 6525, 6501, 2339, 6873, -129, 7594, -1638, -9183, 3951, -3346, -1835, -6885, 8763, -2890, 4528, -7086, -7628, 674, -1559, 4207, 8636, -4690, 8623, 9508, -4938, 1200, -4577, 9367, -477, 7040, 332, 8406, 7961, -2565, -2354, -6669, -4539, 9601, -5234, 228, 8594, -6860, -9791, -2421, 7474, 5469, 8668, 7824, -1097, -1706, -1463, 2974, 5177, -3969, -8323, 812, -5971, -4985, -3718, -4129, -8347, 7010, 5698, 457, -5057, 7897, 8286, -2831, 4228, 596, -5468, 3046, 9273, 8415, -1882, -780, -98, 5602, 5749, -5788, 2656, -8492, -8394, 6634, 8417, 3734, -1903, 7248, -519, -5568, 2545, 8859, 2504, 6290, 1660, -3557, 150, -309, -6368, 4431, 1165, 3391, 2127, 8031, 7378, -9922, -5853, -57, 542, 9227, 7591, 7196, -2704, 6468, -6914, 4073, 5595, -3700, 7226, 7182, 3204, 809, -7497, 9755, -8970, -5477, 1988, -9211, -1511, -1062, 1949, -7851, 219, -473, -1227, 5428, 2604, 1151, 4181, 1311, -9044, -5255, -4966, 9299, -544, 3155, 8315, 9055, 3539, 7388, 5090, 8306, -3007, 6095, -7401, -9692, 4504, -9939, 4806, 8132, 5079, -652, 7348, -5793, 3322, 6382, 2307, -510, 8203, 2055, -1829, 4135, -3159, 9616, -3538, 3831, 5726, -5795, 8080, -9708, -5711, 8467, -7158, 6906, 1900, -6248, 775, 6598, -4598, -223, -9909, 8262, -7530, 394, -6971, -24, -645, -397, -5719, 8707, 7291, 6429, 4709, 5630, 6768, -8663, 8642, -3310, -1983, -7944, 9964, -7575, 8795, -2529, 9653, -6987, -8961, -197, -1702, 8049, -5746, -608, -9770, 5676, -6696, 189, -2711, 6745, -3369, -3810, 5868, -8277, -7952, 626, -1430, -3509, 3488, -8656, -5122, 7075, 993, 9723, 2289, -8083, -9210, -7122, -5401, 8797, -9907, 5518, 6113, -6570, 1889, 493, -6660, 2035, 7579, -466, 3134, 8986, -3247, -1030, -5943, 400, 1438, 7588, -4189, -6130, 8621, -9468, 311, -6858, -5649, 1068, -8510, -7100, -584, 6244, -8781, -1261, 3868, -377, 8246, 6078, -8744, 950, 7323, -3103, 3196, -5528, -3263, -9131, 7813, -7330, 5556, 303, 2186, 9606, 4572, -2262, -7085, 7032, 7111, -6397, 4668, -9397, 2294, -9493, -8364, -7706, -7709, 4168, 9379, 4211, -8386, -6412, -4816, -3837, -3708, 1652, 379, 3653, 4975, -2142, 3065, 1362, 6763, 9619, -4068, -8965, 6879, -5581, -5321, -8542, 8715, -904, -7841, 3130, -9837, 3194, -2466, -6277, 347, 8861, -7018, 8332, 6523, 3708, -2630, -3745, -5696, -2317, 6392, -947, 37, -4988, 2217, -5816, -6229, -5365, 3092, -374, 4560, -9258, 1085, -4122, 5030, -8612, 7955, -1472, 2542, 2048, -2391, 3986, 8510, 9570, -1697, 3161, 744, 857, -4502, -7194, 5023, 6069, 1582, 1197, -2651, 2117, -5552, 9809, 292, 617, 9918, -7409, 8469, -3420, 1127, 846, -7994, -3873, 5550, 569, 1761, 2378, -501, 3333, -7064, 2966, -8404, 2040, 6642, -2528, 1536, -7019, -2611, -6446, -3777, -1343, 8063, -1854, 7798, -875, 2737, 6187, 2475, 4443, 372, -3953, 5058, 5357, 2006, 3223, 9884, -5638, -5775, -966, -8441, -8809, -6935, 3517, -2260, -4365, 2963, -8210, -7874, 5998, 404, 159, -6661, -1760, -8357, 9611, -6069, 9843, -1996, -3419, 2896, 4042, 254, -1411, 8353, 4971, 7703, 3439, -7879, -7124, -6098, -6309, 975, 3312, -7177, -8932, 8143, -6402, 6140, -128, 3812, -3922, 7544, -2747, 4543, -7946, 4193, 4176, -3910, -8184, -529, 1665, 3842, 383, 8119, -5986, -4058, -6950, -4454, 8346, 2821, 2406, 5223, -2810, 7416, 4564, 6796, -3911, -1134, -7815, 2308, 2667, -1759, -6319, -2434, 8997, 9184, 6786, 3279, 5902, 4085, -2689, 1809, 4643, -8294, 9324, -5115, 7552, -6100, 3749, -9864, -4881, -1530, 6733, -2408, -2570, -8179, 6184, -3792, 3172, 2605, -4276, -1262, 9231, 2946, -1038, 3051, -8992, 9042, 4555, -1091, -5511, -4948, 9987, 4328, 2147, 689, -7114, -7082, -1685, 1997, 5672, -7783, -869, 3783, -8730, -3328, 5644, 4238, -7389, 973, -9337, 7593, -61, -7438, 3953, 3429, -5310, -384, -8499, 7140, 5780, -4109, 9442, 9370, -9098, -1354, 9760, -2222, -7365, -575, 2964, 3805, 9431, 6412, -6362, -7685, -3578, 7494, -8829, 7340, -2888, 8249, 3650, -876, -6886, -9093, -7708, 2980, -9341, -9191, -4240, 5246, 7820, 7697, -4991, 1593, 7769, 7339, -4232, 3995, 2231, -3963, -5844, -3266, -7537, -7493, -4141, 6808, 5384, 5048, -9170, 5712, -924, 8423, 371, -5932, 5923, 3558, -8380, -8230, 9383, -7626, -8157, 409, -4387, 1903, 638, 2449, -6267, 6561, -2976, 9080, -5755, 2140, -1513, -7012, -301, -6626, 8127, 3644, -2226, -3151, 7515, 6926, 5803, -2346, 5235, -5416, -8194, -1258, -9723, 7521, 4001, 4158, -8830, -3602, -9762, -6728, -3460, -4585, 3278, 3528, 621, 4316, 2121, -8943, 7664, 4326, 6716, 1925, 9981, 6658, 939, -5806, 4744, 2971, -4994, -8645, -5026, -7876, -4137, -2476, 463, -6472, 3676, 1750, 9678, 3414, 6044, 2937, 7049, -7295, -322, -8639, 5993, 8303, -5897, -1830, 6684, 9822, -1466, 8518, -4062, 557, -8867, 4663, -1584, -1148, -2157, -2138, -7017, 3290, -6476, 2285, -9104, -7333, -8247, 7838, -8815, -5612, -1952, 4331, 5911, -3493, 8748, 87, -7224, 3436, -6140, 9195, 8717, -3560, 395, 5517, 8956, -8540, -8784, -6533, 5372, -6974, -4770, -8530, -5980, 1215, -319, -3237, -3679, -8757, 6907, -9319, 7646, 7753, 8483, 4779, 7630, 6143, -5210, -1899, -920, -5636, 3523, 5887, -8329, -2223, 168, -541, 8045, 331, -2224, -6062, 9800, 123, -8041, -7053, 9739, 5662, -7434, -9713, -6354, -7941, -8928, -5412, -6944, 5368, 9213, 456, 9863, 2921, 8126, -7577, -1385, 3673, 5833, 7349, -1263, -8085, 81, -5414, 9662, -461, -1609, -9500, 7982, -5424, -1324, 1229, 895, -2003, -3054, 7386, -7655, -2292, 7286, -4195, 2063, -9065, -5834, -2322, -2020, 4259, 118, -2987, -4907, -8372, -6555, 9575, 6456, 6992, -1346, -6756, -3633, -8192, 3349, -8758, 5409, 6619, -6578, -5170, 3784, -8605, -933, 8196, -9666, 3058, -2193, 131, 9127, 4549, -524, 692, -5006, -6337, -1907, 8186, -9240, -7603, 231, -1214, -5990, 1619, 8990, -5504, 9257, 6339, 5651, 2765, -5723, 1099, -9962, -6964, -9825, -8649, 1131, 1247, 9201, -8514, 662, -240, -9572, -1006, -6047, -8906, -8976, -8408, -4843, 5445, 8740, -8717, 5587, -6741, 3476, -2936, -2005, -5475, -7268, -2618, 7270, 7312, -7674, -9299, 5419, 8314, 5772, 2188, 4368, -512, 8565, 5091, 6198, -1982, -1445, -6491, 9669, -8155, -8661, 9456, 8891, 8134, -8607, 5014, 7054, -1837, 8164, 9463, -5201, -959, -6962, 5156, 2930, -1282, 888, -3387, 1335, 9309, 2512, 8493, -4622, -7853, 4814, 3531, 8816, 4692, 8385, 3606, -7321, -8249, -2413, -6551, -1647, 1744, 5430, 8112, -3441, 9155, 4664, 787, 4994, -7664, 5411, -1604, -2788, 2319, 4461, 1766, -2064, -4243, -9691, -9610, 4901, 4397, -4250, -787, -1179, 7067, -3126, -8022, -4749, -9780, 3171, -2511, -1817, -588, -5224, -2161, 4337, -3695, 1565, -4449, -9168, 4661, -3505, -1825, 3372, -198, -1403, 6379, 3667, -85, -7070, 4601, 1845, -2606, -6276, -6958, 8428, 4976, -1744, 6892, -6385, 6548, -8108, 5297, -9224, 467, 7031, -8966, -2573, 5523, 783, -2162, -8296, 6910, 8307, -6930, -183, -3729, -7909, 7516, -3296, -8950, -4807, 9322, -5617, 779, -3869, -5510, -340, 2292, -5204, -1610, -2359, -9815, 1691, -8817, 2245, 3164, 3578, 1960, 7127, 6895, -6078, -4678, -9298, 8526, -8820, -8269, -7576, -8541, 9522, -702, -8834, 8173, 4755, -7349, -3732, -4061, 2038, -1879, -5639, 2021, 9741, 9711, -526, 844, -1592, 6289, -9483, -9126, 8556, 1096, 454, -4015, -2550, -5343, -5220, 1269, -6233, 6097, -6145, 8278, -8723, -2095, 6061, 2042, 1673, -3046, -6975, -8714, -2042, 9315, 9984, -3111, -3890, -3515, -1986, 2230, 9280, -7402, -3880, -2375, -949, 911, 503, -9122, 2471, -194, 7965, -7347, -6856, 9980, -3096, 2983, 4104, 1493, 8916, -7468, -4545, -7666, -8168, -8708, -5901, -9714, -7831, 6850, 3293, -7252, 3790, 7691, -2825, 6820, -2097, 2151, 4198, -1490, 3222, 4303, 7887, -9840, 280, -12, -7341, -2628, -4873, -9140, -7329, -1312, -7077, 8374, 1511, 7322, 7373, 365, 9022, -5813, -5322, 5921, -8493, -5611, -2328, -34, 9534, -1844, -9437, -2784, 2798, -5717, -6540, -7927, -1220, 7711, 1476, 268, 6294, -6934, 7932, 8207, -5772, -9957, -1001, -8129, 1517, 1063, -3030, 3626, -7624, -2463, 2845, 9879, -248, -7164, -3250, 4434, 2298, 7695, 9359, 6445, -2766, -9441, -3322, 9998, -9977, -2922, -3529, 7345, 8215, 3148, -1608, -5809, 795, 9892, -9781, -4665, 6817, 1448, 5127, -6119, -2687, -6173, 2854, 1896, -5632, 5087, -4052, -6907, -5798, 4953, -4924, 4957, 5720, 6841, 6296, -7922, 9241, -3744, 6013, -3674, 3571, -3038, -9901, 3927, 8276, -6983, -5883, -3637, -8899, 8496, -1953, -4317, -1553, 4954, -4898, -6284, -1109, -9603, -9766, -1483, 1728, 6224, -2100, -4926, 2453, 2728, 1235, 7756, -6444, -2140, -9313, 4608, -3129, 5540, 4530, 6027, 7867, 6276, 3419, 6962, -7738, 6189, -6330, 8805, -8566, -8096, 6333, 9267, 7069, 7489, -1473, -2749, 3434, -1869, 7720, 7076, 3160, 6474, 8962, 7423, 21, -6678, 9731, -436, -8844, -6580, 5880, -7644, 6671, -9026, -4829, -2388, -3349, 4791, -6453, -4038, 6556, 9203, -9002, -8465, -7992, -1083, 9142, 8129, -4278, 650, -5521, 1956, 7367, -754, -8377, 9703, 2562, 3669, -1819, 1227, 374, -6288, -8775, -9725, -3031, 7634, -7799, -1452, -5828, -1170, -3084, -2552, 9482, 808, 2548, -9318, -6176, 9990, -227, 2607, 5074, 6352, -2122, -5556, 8271, -1249, 5379, 3675, 4365, 2031, -4530, 3497, -6767, 9318, -8672, -5214, -8231, -1917, -431, -9575, -3357, 1042, -5148, 3250, -5781, -8764, -3106, -514, 6477, -997, -2244, 9975, 2194, -4688, -8739, -7762, 3703, -9688, 440, -705, 3728, 6883, -1820, -1743, 7839, -4517, 8563, -8072, 1352, -1597, 5407, -8497, 860, 1892, 1719, 1680, 582, -9336, -8024, -7267, 4117, -9448, -4416, -9213, 6868, 438, 7583, -2659, 4306, -5567, -1397, -9045, -2243, -7384, -3035, 1869, -1418, 5196, -5117, -2091, -8063, -5015, -7319, -4566, 9205, 7480, 2047, -6565, 3681, 1965, 7174, 3568, 1168, 5788, 784, -799, 8375, 2586, -1161, -6574, -6729, 2160, -7968, 2760, -8147, 2287, -8254, -1858, -3400, 7785, 2517, 9564, 3139, -220, -8029, -1039, 490, 1366, -9557, -6492, -423, 6316, -1450, -2203, -5202, 7459, 3761, -4140, 6700, 5310, -7550, 5795, -3881, -5641, -4728, -8457, -2633, -6995, 2606, -2907, -5492, -8881, 7969, -3564, -8300, -2156, -5513, -3808, -3778, 7674, 2438, 1579, 3277, -7481, -8005, -695, -1475, -3057, 940, -5312, -231, 7411, -7981, -5826, 833, -7571, 8746, -1137, 3330, 4233, 9790, -4602, -5340, 4131, 2901, -8223, 5525, -9217, 6779, -8031, 649, 468, 7280, -6336, -3783, 8087, 4591, -5726, 3262, 1049, -9295, -1316, 4185, -8795, 8537, 7297, -3202, -1748, -9896, -5440, -9037, -6879, 63, 2676, -1285, 5112, -9611, -5593, -6282, -4261, -5623, 2213, 7501, -2036, 2769, 2284, 8297, -5480, 6647, 9451, -2954, -1211, 5386, 5861, -5324, -1799, 3200, -7180, 676, 7125, -5138, -7544, -2535, 5086, -4361, -8250, -4600, -1741, 653, -776, -1406, -3692, 6995, -3912, -8026, -8310, 3610, 1768, -2499, -8862, -1918, 5470, 8843, 4290, -4905, -5679, -4382, 4995, 8200, -9958, 3376, 9659, 8899, 6836, -169, 1211, 510, -4651, 8524, -4856, 3128, 6221, -6853, -7291, -9923, -6844, -5582, -317, 9026, 9658, -2225, -4156, -2930, 4617, -8356, -6432, -8348, 2098, 9567, -3850, 3725, 9872, 8732, 8913, -2519, -5591, -2653, -2988, 8734, 9485, 7180, 2734, 821, 6218, -2553, 9141, -4626, 9380, 64, 6541, 773, -401, 2993, 1553, -4426, -6227, 3339, -4327, 6310, 6597, -7038, -7092, -8092, 9938, -1213, 8570, 9982, 7095, 2076, -3666, 1714, -3917, 1292, -3222, 117, -4700, -3827, -5225, 6495, -235, 1088, -7903, 6089, 2621, 8591, -5280, -3438, -576, 2326, 5534, 4723, -2864, 4770, -8471, -9633, 5696, -1320, 9930, -774, 5592, 2039, -4718, 2247, -9433, 7491, -6841, 1813, -6148, -7348, 8048, 2809, 6120, 2064, -459, 1170, 6216, -6605, -4579, -1616, 1976, 7642, 7899, -5800, 517, 1178, 1107, 6893, 4730, -2084, -4853, -7832, 4294, 8821, 667, 9585, 4333, 6110, 3880, 53, -2177, 5957, -8728, -8142, -5940, 7698, 5568, -6158, 4242, 3847, 2163, 483, -8207, 7022, -3579, -8345, -3639, 4655, -4214, -7359, -8660, 5621, 5247, 9707, -6727, 2508, 4025, -593, -5039, -664, -5988, -9335, 5541, 4866, 413, 6262, -9116, 2396, -6552, -7690, 2712, 1052, 5876, -5934, -5281, 7449, 1782, -9859, 5007, -8107, -2024, 4097, 7808, -3840, 1133, 1730, -5644, 8055, -6717, -1783, 3723, -6806, 76, -6803, -2860, 7651, 3002, -5862, 4038, 6704, 6436, -5398, 3807, 2732, 7754, -1291, -4971, -5814, 6723, -5872, -1317, -1893, -8343, -6065, 4473, -5028, -5450, 7073, 5878, 8015, -7658, 7276, -2500, 8344, -6238, 5232, 8815, 9061, 1632, 8776, -2830, 32, -5146, -5538, -9924, -5141, 1890, -4059, -3457, 6401, 9029, 3707, -4447, 7237, -6489, 3396, -9306, -8260, -170, -5291, -7382, -983, -6045, 5670, 19, -796, 279, 9927, -1815, 5565, -6657, -7473, -3407, -3211, 602, 5683, -888, 6099, 1854, -9264, -9856, -8482, 3162, 1003, -727, 7508, 7179, -7009, 6746, -918, 3346, 508, -7533, -8139, -3123, 2273, -9219, -2586, -4847, 6096, 2575, -8556, 6217, -6372, -211, 9441, 2110, -6127, 555, 4024, -9971, 660, 5404, 8638, 6853, 1196, 8460, -9654, -3471, 6231, -3723, -805, -1998, -4439, 7099, -4242, -6513, -6757, -4604, -5318, -9218, -6195, 7675, 3086, 521, 3553, 3260, 969, 748, -1158, -6418, -7629, 7364, 8982, -8292, 9959, 2272, 2354, 3661, -6135, -1855, -2508, -7232, 699, 8109, -6738, 5694, -9208, 351, 4986, -1806, -682, -1607, -6668, -5602, 7433, 3649, 6694, -7212, -5248, -7463, 9851, 3354, 1275, -9312, 682, 2624, -9260, 7783, 9448, -2353, 3977, -1360, -3475, 387, 8762, -4506, 8413, 8044, -7579, 8390, 1272, 9944, 6287, -8766, -894, 4697, -2185, 3199, -1340, -9838, -698, -1505, -6464, 69, -55, 9917, -2933, 7687, 3091, 1228, 9735, 2429, 8014, 496, 8793, 9202, -6600, -3465, -4026, -9477, -5145, -4066, 7131, -4931, 8382, 4805, -5779, 5053, -2186, -9032, -304, 8130, 2731, 7894, 5999, -4947, 4301, -660, 2681, -5368, 1060, 9869, -2479, 2276, -4605, -9905, 6810, -4536, 4261, -8349, 7048, 2950, -7179, -2974, 5236, 6203, 8520, -586, -6447, -3843, 8368, 7829, 2028, -5425, -1847, -9592, 2939, -980, -4845, -445, 5725, 6172, -7284, -8506, 6444, 992, -1089, -998, 3498, -8106, -7205, 2691, 1072, 6227, -7265, -3725, 3552, -1033, -6835, -7129, 1287, -8490, -8565, 1818, 2369, -3583, -4087, 4762, -4698, 2842, 4615, -5756, -4954, 3502, -2382, -8196, -3962, -2829, -9407, -7523, 4941, -1028, 6953, -2195, 2275, -1874, -4400, -9645, 1435, 2996, -6931, 6046, -3640, -6897, -9886, -4501, -546, -10000, -9464, 7217, 8764, 3348, 1055, -4220, 1083, 6607, 2489, 6824, 7432, 520, 4072, 4783, -5994, 7541, -3245, 4014, 9919, -7022, -2259, 7425, 6929, 4589, 6458, 9548, 606, -6515, -8438, 5646, -7618, 8180, -1287, -8633, -9563, 8720, 8849, 1828, 2527, 9599, 4815, -842, -2213, 2052, 8302, 8085, -3907, -718, -3887, 5666, -2417, 6377, 865, -6488, 9264, 8876, 2400, 3679, 9551, -7648, -2915, 6794, -6821, -4834, -9515, -3516, -2401, 6653, -6940, 877, 7688, -6209, 2425, -1654, -9984, 4270, 287, 9820, -5357, -9352, -4399, 5217, -4070, 3453, 6214, 9803, -3951, -4425, 8120, 5017, 8420, 7465, 3193, -4179, 3777, -4120, -53, -3212, 7228, -6196, 4339, 5835, 5854, -9613, 8071, 3577, -6713, -618, 1469, 8005, -4928, -886, 5946, -8071, -1891, 7949, 6987, -9525, 7260, -1314, -7026, 5388, 1822, -3278, 6440, 5948, 946, -8062, 5904, 3383, -3556, 6720, -9027, 108, -2700, -7229, -9200, 4126, -9944, 7910, 1121, 1495, 9841, 7036, -3815, -9854, 4133, 2412, -4000, 2934, -6864, 2212, 9479, -4311, 7514, -3339, -3418, -8198, -287, -1040, 1239, 1201, 3546, -1504, 5412, 5158, -6111, 2486, -4132, -9091, 6400, 5596, -4309, -4475, -9828, -4118, -6592, -234, 9164, -2656, -878, -3029, -6320, -3544, -447, 9819, -4020, 7113, 216, -5298, 7886, 6271, 5611, 486, -4792, 1681, -8402, -6193, -9774, 6728, 3563, 7846, 8704, 2669, -2629, 7655, -3900, -4060, 7356, 7529, -6032, -9554, 6356, 6627, 9706, 1089, 944, 1938, 7333, -6039, -5203, 4166, -1564, -1139, 9754, -1008, -2682, -3660, -4478, -725, -3352, 498, 8261, 4904, 1781, -4724, -8956, 410, 4689, -2088, 852, -4653, -1294, 2266, 112, 1934, -1896, 7274, -9835, -8211, -8304, -3421, 5313, 9443, -8444, 1774, 4137, -8238, 7640, 4512, -1344, 1545, -1223, 5545, -9389, -3348, 4300, -115, 7230, -3520, 3796, -6160, 4352, 4804, 5345, -4373, -1437, -8263, -9484, -4817, 244, 9215, -8088, 4312, 938, -7548, 4330, 9753, 7759, 7973, -3812, 6166, -6393, 8335, 6332, 9435, 4706, -8373, -4175, 3881, 6473, 8874, 8725, 2444, 5099, 603, 9523, -3231, -9290, 5747, 1207, -1750, 8527, -5381, 3586, 5585, 4271, 6713, -1481, 7463, -6949, 7170, -448, 8711, 3366, -5554, 4529, -1281, -6236, 1344, -752, 8857, 2498, 8604, 1265, -7185, -2272, -943, -8720, 6111, -3050, 4442, 8778, -9411, 2418, -3039, -8622, 6403, 562, 1046, 907, -5411, -5342, 9801, 1270, 6711, 2232, -2755, -7257, 1232, -713, -2555, -1571, -3127, 9902, -1515, 5679, -1448, -4636, 6222, -8677, 6149, -1489, -391, -7640, 1625, -9372, 7502, -550, 6522, -5458, 1373, 9643, -5190, 3208, 1775, 7904, -3570, -4046, 7008, 3637, -334, -2590, 5853, 2633, -5215, 513, 4091, -2991, 1703, 4292, -7378, -5685, 756, -3870, 6492, -9865, 5884, 4074, -8874, 5054, -7303, -8291, 8686, -4863, -5103, -8132, 7947, 5135, 2206, 7562, 2779, 4267, -1123, -9937, 8657, 8125, 4807, -8902, 5395, -5951, -7991, -7260, -9166, -3539, 2819, 6572, -5500, -2736, -4803, -7079, -4172, -2919, 1803, -4472, 870, 3017, 4817, 9517, -5166, -7399, 8901, 6896, -9843, -1210, -4826, 9916, 5361, 1039, 5989, 6031, -4192, 1203, 1798, -486, -2536, 1689, 6037, -3482, -3779, 9060, 1685, -3015, -3304, 4388, -848, -9353, 4253, -9254, 7012, 9785, -9792, 9374, -7261, 5356, -6490, -9562, -738, -337, 2070, -4067, 6034, 9787, 285, 2533, 3792, -6817, -1451, 2747, 7908, -6758, -3621, -1769, 2180, -3449, -2372, 6205, 4859, -3858, -40, 6188, 9260, -9450, -8226, -1231, -9110, -714, -1233, -8887, 8121, 5078, 9909, -7318, -2968, -2101, 9480, 1915, -8140, -7905, -41, 2539, -1482, 1350, -5042, -3536, -5955, -6604, 4087, 2989, 8150, 3364, 6035, -5136, -3082, 3352, -5653, 7663, 6150, -5622, 2388, -3593, 9855, 514, -3021, 7685, -589, -2712, 425, -8368, -8255, 1592, -9084, -2697, 3773, 8840, -4894, 8544, 9146, -3467, 8641, -8112, 8508, 1071, 9017, -2851, -438, 4728, 4913, -8855, -7562, -8079, -2484, -2543, -2515, -4233, 3287, -126, 4769, 1011, -242, -3047, -8175, 6029, 9596, -8431, -2238, -9141, 2567, -1979, -4782, 4230, 8873, 6494, 9440, -8006, -1781, -273, 8922, -10, -4343, -6998, -8256, 9033, -3789, -4043, 8961, 6197, -3905, -6026, -522, 2358, -2913, 4286, -430, -407, 8193, 5982, 7281, -7309, -8424, -2799, -1678, -2175, -8754, 5045, -3474, -2509, 5151, 4400, 8092, 3838, -7568, 8914, 7119, -4204, -1821, 5439, -6598, -7607, -1460, -7226, 7202, 8628, -3343, 1858, -9527, -9134, -5525, -3093, -1527, 1523, 5773, -2703, -4780, -6629, -6461, -8365, -1839, 6138, -5056, -7995, 1315, -7718, -626, -6335, -2073, 2906, -9356, 3994, 20, -5892, 6263, -2266, -3667, -8658, 8685, -1244, -5437, -7436, 726, 4250, 6092, 2125, -8481, -3747, 7350, 2679, -2447, 7485, 3769, -7157, -3170, 6257, 7017, -8773, -4184, -7790, -5701, -1113, -7336, -1138, 1293, 4296, -91, 85, 5022, -4955, 3554, 7862, -9908, 7644, 9084, -3294, 6999, 488, 2244, -7465, -120, -7934, -1037, -4494, -3271, -8535, -5086, 209, -5805, 9782, 4586, 2675, -2219, 986, 5171, 1526, -8117, 1210, -2636, -9846, -9608, 6137, -4607, -4911, -9490, 7540, -7208, 716, 1254, -256, -4629, 5, -7670, -7006, 6554, 6624, -6399, -6937, 6724, 9047, 7755, -3384, 6935, 6415, -295, 8410, 1414, 8850, -4625, -9338, -7221, -2821, 1905, -855, -941, 4874, 1817, 5342, 4163, -493, 8419, 735, 2, -5979, 4563, 5199, 2577, -2296, 5594, -3506, -3275, 3387, -2812, -3190, 4842, -9683, -6876, -5489, -6831, -7695, 3076, -5245, -9963, 3205, -4082, -5878, 1324, 3242, -4154, 1763, -437, 5507, -3956, 2651, -2002, -1795, 4220, 8581, -5583, 9086, -2745, 3495, -189, 7109, -7371, -8704, 1741, 7616, -4158, -5578, 8000, -3567, 4951, 5566, -6439, -1912, 627, -2675, -4929, 2816, 2437, -386, 6384, -8903, -4538, -3606, 6258, 5748, 709, 4006, -7835, -4358, -6379, -1687, 6135, 4515, 1380, -4404, 307, -285, -8990, -7986, 2892, 2494, -4445, -5506, -9196, 2383, 8311, -5018, -8901, -3468, 2629, 874, 6082, -9734, 5422, -6177, 6969, -2706, -905, -3675, 7285, 3491, -3341, -6867, -7776, 9503, 6744, -7356, 8252, 6365, -735, 4830, 9618, 6318, -4758, 4775, 4044, 1819, -5038, -6900, 8248, 3961, 7561, 9945, -8539, -9053, 5163, -884, 7848, -5186, -7525, 4877, -1832, -9128, -3611, 5716, 7537, 4454, -4422, -9878, -5104, 3344, 4585, -6871, 7970, -2867, -9631, -579, -7948, -7035, -6526, -7549, -4731, -4163, -5796, -97, 7385, -7460, -925, -7538, 18, 7781, -6875, 9067, 3350, 668, 5070, 8965, 9204, -6108, 5337, 9710, 5218, -4764, 1369, -180, 157, -3261, -843, 2881, -6371, 570, 3832, 6948, -6861, -3604, 7183, -5271, -4031, -611, -4958, 5115, 188, 5433, 3273, 6251, 6943, 5446, -6114, -3257, -6265, -6810, -5000, -4493, -2496, -7071, -5923, 4855, 9865, -5402, -9373, 1309, -8436, -6972, 1117, 79, -4448, -5354, 5109, -9729, 1057, 9207, 9074, -7036, -1878, 2614, 1559, -4723, -4969, -2667, 2641, 2173, 3471, 1401, 6028, -7366, 8459, 1471, -4968, 8227, 8998, 1919, 8525, 7600, -2758, 8907, 4432, 6635, -4799, -3417, 6574, 5869, 4619, 3224, -2861, -1814, 5166, -2649, 2694, 9627, 6376, -254, -8635, 565, -9403, -1909, 6311, 691, 3450, -9488, 9996, 7962, -9249, -5908, 8749, 580, 1457, -6473, 9953, -4648, -3173, 4656, 295, 5842, 3664, -3401, -651, -7912, 960, 8837, 3952, -1679, 3570, 7943, -7678, -7557, -9101, -5916, -8648, 1494, -9021, 2899, -8640, -6201, 5105, 2595, 6410, -1027, -1358, -7822, 7558, 9062, -3487, -4836, -9743, 197, -9284, -7891, -8568, 5380, -7774, 9661, 8289, 8403, -3706, -6992, -49, 1756, 5903, 1241, -7646, 8583, -5428, -4352, 6334, -433, 9791, -8525, 2061, -4359, 1182, 267, -6274, 8593, -7355, 5321, -9795, -2709, -7567, 1327, -3635, -7088, -2452, 1191, 5500, 7994, -7307, 7868, -6750, -806, -903, 851, -2993, 8050, 9175, 7043, 8945, -4550, 1221, 2784, 9473, -3188, -3648, 9983, -3946, 1490, -763, -4993, 3393, 4802, -4135, -455, 4852, 3945, 2050, 5040, -7663, -8043, 8871, 7764, 3426, 8767, -9588, -5445, 8430, 7436, 2949, 6156, -2997, -7118, -9108, -558, -1784, -344, 9048, -250, 6983, -4917, 6809, 3340, 5619, 7084, -661, -6627, -7495, 4380, -4548, 6751, 245, -1742, -4570, -3169, -3119, 2818, 2850, -4210, 7986, -7062, 9672, 3195, -9270, -8981, 7751, 9957, -1801, -9952, 1358, 4654, 9447, 9388, 4721, -8581, 1065, -7338, -8654, 5634, 3120, -7688, -5353, 9439, -2723, -3063, 4391, -1930, 2187, -8752, -8946, 5144, -7173, 3084, 3862, -7904, -7900, -1167, 215, 5051, 6219, 8138, 7895, 2417, 4848, -4868, 7088, 5333, -5606, -5162, -9797, 9878, 4761, -499, 6045, -7388, -5857, 4172, -8009, 3261, -6022, -7511, 22, -393, -2945, 4746, 4317, -4188, -3721, -2604, 4965, -4531, 3823, 7617, 1724, -9304, -3596, -2585, -766, 2895, 4302, 5288, -6808, -6313, -5479, 7709, 6252, -1723, 5717, 6075, -7945, 544, -8103, -6244, 8538, -8838, 642, 1179, 4821, -7881, 9226, 4221, 2018, -4920, -7555, 2873, -5894, -62, 4060, -8889, 7044, 1112, 6553, -6095, 1806, 3670, 4659, -2574, -2517, -2404, -6520, 2563, 3243, -3131, 5008, 4635, 2986, 5699, 6321, -68, -7985, -4293, -8013, 5561, -4267, -8299, 6973, -9663, -4036, -45, 4792, -103, -1268, -7834, -1794, -6906, 3991, -8770, 3123, -5457, -1488, -7364, -5760, -6474, -8952, -1656, -9689, -2043, 4554, 8600, -1236, -4874, -4064, 4134, -8500, 273, 7009, -2146, 933, -3056, 6125, -8445, 7206, -7754, 7913, -5405, 1626, 2329, 4469, 3214, -5285, -3638, -4562, 7295, -9442, -6370, 2617, -2941, 7692, 3034, 6279, -5427, 3136, 2725, 1313, 3416, 5570, -6541, -521, -8982, 1998, -1175, 5973, 8712, 7347, -3750, -6585, 7538, -1005, 5714, 1325, -5309, -330, -7873, -3058, -105, 5658, 132, 5956, -3176, 5632, 6112, -8422, 753, -4130, -5859, 7232, -6986, -7599, 8696, 476, -3070, -8789, 4926, 4868, -9773, -4208, 3636, 5280, 5362, -1057, 8924, -2192, 8958, 5738, -4307, -6188, 3480, 6435, -7253, -2034, 2313, 6261, -6763, 8515, -5120, -7998, 5778, -8240, 1936, 2226, -7698, 2136, -1341, 3357, 7305, 4273, -7877, -5512, -5523, 3651, 3865, -6612, 9609, 3538, 305, 1331, -6431, 8612, -364, -3599, -2221, -1047, -5914, 8542, 1952, 3111, 8724, 9132, 683, -7887, 6849, 6344, 5460, 6972, 1473, -9842, 2720, -5592, 2149, 9219, 2069, 8993, 2238, -6377, -3003, -536, -1184, -4496, -9235, -1911, 2360, 9021, -3774, 9170, 2376, 737, 4581, -3255, 1243, -4815, -1782, -7471, 9842, 5645, 9429, 2678, -1163, 8637, 7672, -6945, -5009, -5938, 6869, -162, -3530, 876, -4290, -4827, -8383, 8946, 6152, 6300, 2537, 5265, 6650, -4716, -5708, -5462, -3223, 4898, -609, 7614, 1615, -9457, -1209, -4398, 2699, 2227, -3652, 2683, -3876, 9933, 6805, 5164, -8134, -351, 9856, -7276, 6649, 6715, -3764, 1084, 6291, 250, -3073, 2207, -3771, -1969, 9907, 7519, 8268, 2074, -4594, -3254, 3112, 966, -9138, 4612, -2486, -7789, 5931, -6088, -5325, -8630, -2571, 9920, -9528, -5290, -6614, 3804, 1722, 6940, 511, 5329, -1931, -4739, -4830, -9845, 1884, 8395, -5182, -4709, 5536, 3613, 5609, 9261, -506, 2469, -2661, -6567, 2183, -1667, 8575, 1676, 8757, -9281, 2024, -8003, 8446, 749, -4294, 6865, -2480, -8685, 3462, 5616, 2115, -6350, -9612, 7064, 4457, -6268, -9853, -6004, -1060, -8290, 3602, -9537, -5194, 5690, 1115, -2133, -8727, -2137, 7052, 698, -2634, 4864, -1632, 949, -2589, 6469, 6204, 6680, -8413, 256, 8057, -760, -6225, -1143, -3985, 675, 9395, 9049, -6141, 9758, 2440, -2168, 9391, 2434, 7716, -3490, 7154, -9215, -444, -5821, 2233, 6609, 541, -2389, 8169, 2912, 2572, -7914, 8854, -7206, -4831, 1078, 8831, -2439, -4438, 5005, 7426, 8700, 1364, 2991, -9677, -1122, 9594, -2814, -1259, 2599, 1759, 8713, 9265, 8546, -5532, 4713, -8544, -8998, -4946, -3445, -1889, -8582, -5296, 4729, 9328, 2283, -8274, 2201, 1159, 8088, -8469, -3981, 6551, 9250, -8173, 5900, 2746, 4553, -8785, -7201, -8856, 7400, -7770, -5640, -5081, -9229, -4357, -4730, 9342, -3098, 6629, 2482, -2647, -8369, 558, -8767, 4046, 3654, -2448, -9852, 9991, -296, 8325, -542, -8330, 5546, -3055, 3690, 3745, -8589, -3290, 2454, -7142, -5518, -6679, 8304, 4311, -4915, -1790, -484, -4662, 5240, 1591, 1657, -6246, -2562, -4415, 8324, -2857, -1313, -2086, 869, 829, 9929, 6054, 3873, -820, 4110, -3411, -6893, 381, -6217, -1284, 2741, -962, -667, -7956, -2718, 4793, -6699, -3347, -6584, -2882, 3254, -3616, -3626, -4367, -182, 3816, 3809, 6942, 1655, -2300, -4960, 1695, -3511, -2526, 533, 7204, -9972, 5301, -6499, -7452, -1078, 4256, 4851, -9066, -5391, 315, -4784, -7074, 2556, 6566, 3852, -9732, -282, 9694, 8866, 2714, 2328, -3101, -2363, 1916, -3146, -8756, 4426, 1600, 1487, 7572, 7137, 5350, -2990, -830, 2219, -428, -1715, -4567, 7826, -7373, -3875, -8478, -4696, -3158, -3597, 3103, 3625, 3827, 7306, -4441, 4908, 7995, 9553, -8572, -5647, -6292, -4884, -9889, -3739, -6698, 9701, 6274, 5334, -4676, -2241, -3526, -5918, -3786, -4300, -9564, -9579, 7830, 4801, 8808, 7517, -5238, -3990, 5263, -8788, -2298, -3324, 2587, 8466, 2325, 6348, 6202, -1178, 129, -8819, -7634, -4345, 7834, -9921, 7864, 5478, 1026, -483, 4090, 1735, 6563, 5037, -7625, 2658, -7322, 5255, 3722, 3440, -9409, 4167, 8378, -2406, -2026, 5222, -5473, 8285, 5243, -7408, -5085, -8883, 263, 5315, 3008, 2597, -2380, -4786, -4453, -4314, -4823, -8275, 5532, 3207, -3042, -3657, -6783, 4526, 7300, -2422, 184, 6305, -2575, 5055, 8825, -6873, 2751, -4460, -2054, -7971, -9014, -9390, -8555, 5548, 8064, -743, 6897, 1987, -9647, -3979, -7021, -3683, 6259, 2962, 4578, 3611, -9961, 4227, -1256, 8187, 9274, -1347, -2813, 3482, -6685, 492, -5681, 1881, 196, -5787, 5838, -5549, 8277, 3752, -6272, -1051, -9930, -8149, 4187, -9758, 8829, 3217, 1902, -2783, -6566, -6013, 5745, -969, 5737, 952, 4644, -7293, -7271, 4606, -3459, 1061, -1500, 6800, -2357, -965, -8577, 5633, -9913, -2087, 2265, -8407, -7823, 171, 2611, -1993, -9833, 3652, -2271, 4863, 7488, 1692, -6851, -2595, -9746, -7075, 7563, 842, 2722, 2639, -8922, 8074, -5683, 7661, 3259, 9400, -5819, 4446, 1194, 8887, 1844, -6677, 5351, -78, 7481, 9954, 240, -7391, -9650, -2805, 7487, -5605, 1917, 238, 2534, -9180, 720, 9696, -8054, -9173, 2958, 4291, 6710, -8342, -8052, 8953, -4574, 6688, -4049, 8358, 4537, -7777, 4844, 5221, -4957, 4003, 5704, 6875, -9236, -1375, 7457, 6155, -84, 6109, 1455, -4745, -3961, 6789, -5502, -5080, -1302, -2285, 2342, 7296, -5981, 4245, -8602, 8947, -7929, -2242, -5483, -5168, 247, -9220, -6857, 3265, -1279, -9877, -6568, -6010, 3257, 2711, -2319, -1144, 1982, -3228, 2703, -2920, 8388, 7244, -9307, -2444, -9195, 2782, -1946, 8137, -3882, -6182, -6809, -4640, -1963, 6637, -7398, -7893, 3886, 3080, 2459, -5999, -8328, -3759, 1801, -9787, 5320, 6524, 3801, 3331, 3343, -5931, 3968, 1045, 5557, -8563, 4243, -9951, -5084, -8969, 9217, -3860, -9363, 9286, -7480, 6795, 3802, 974, 1932, -3958, -6470, -6637, 474, 8545, -6705, 3188, 4993, 6132, 3319, -7595, -202, 5959, -2908, 3125, -3833, 8705, -161, -8399, 6004, -8426, -2576, -6773, -1587, -5406, 2171, -4096, 8898, 6571, 83, 8688, -271, -4427, -3562, -2786, -6407, -4092, -669, -8318, -8214, -7782, 8940, -4652, -7665, 9717, 8839, 5278, -3415, -2894, -2060, -2278, -1935, -4178, -6525, -708, -300, 9419, 8056, 9133, -666, 5159, -1507, -675, -6126, 5855, 9794, -4011, 8689, 2569, 4124, 1394, -535, 5945, -5959, -8191, -7110, 9958, -9028, -9568, -9142, 3759, -6997, -2796, -731, -9145, 1891, 5140, -9419, -6805, 4653, 3757, -58, 6555, 727, 7144, -1627, -9763, 9512, 9692, 6406, -5743, -6293, -4535, 8875, -1861, 8111, 5281, -1995, 5898, 3314, 6521, -9513, -8325, -2898, -27, 867, 5340, -7731, 4962, -7014, 1261, 8703, -8641, -5920, 9001, -2081, -2583, -9163, -9072, -1673, 9183, -5921, -9801, -8557, -7058, 9094, -7712, -173, -1725, 6928, -3043, 4763, 3972, -265, -528, -9349, 4894, -1675, -4808, -1554, -8030, 1214, 3975, -9152, -2164, 5066, 4281, 9732, 9533, -9445, -3162, -6106, -7198, -4528, 8754, -9471, -1881, 2598, 780, 1260, 4959, 7253, -7978, -2472, 3958, -5272, 4145, -1509, -3344, 9876, -1978, -4354, -8949, 7068, 7374, -4581, -7536, 9098, -5069, 7085, -6828, -1165, 8817, -8462, -5572, -9989, -6774, 4682, 7157, 4162, -6878, 1007, 902, 4580, 6016, 5663, 8601, -9009, 5519, 7876, -1288, 2627, -8608, 5816, -4025, 9188, -5535, 1062, -9239, -2710, 7816, 2071, 9639, 7121, -214, 4241, 6549, 5432, 5950, 8848, -2291, -9669, -1729, -3542, -9998, 7774, 5097, -9609, 8094, -6428, -1774, 998, 8299, -5792, -3909, -5942, 13, -9541, 8232, 5465, 836, -3574, 2646, -7694, -3434, -5712, 4490, -7785, -8710, 1671, 9540, 4418, 3803, 3386, 6072, 574, -2093, 4784, 4340, -3913, 4223, 9144, 6511, -8115, 3856, -5128, 5102, -9102, -9189, 6275, -7844, -7288, -797, 7324, 4518, 8832, -3273, -5143, 5703, 8165, -3108, -394, 5930, 8424, 6589, -1099, 249, 6357, 5096, -4935, 9358, 2938, 9764, 2859, 9327, -3533, -4433, 5610, 176, -1699, 4521, -5645, -6908, -4456, -316, -2627, -7233, 4260, -8050, 99, 1853, 1111, 8984, 6590, -1570, 3587, 9700, 2191, 2871, -4145, -6613, -4805, 7580, -3577, -3175, -6294, -2028, 3174, -5587, 6008, 4602, 2094, 7587, -2644, -6811, 7147, -5003, -5393, 4681, -7503, -7850, -5485, 5874, -1392, 8738, -3036, 862, 7225, 8155, -8141, -7917, 9912, 3660, -1754, -2158, 1739, 8427, 4727, 9397, -4922, 1402, -9646, 3014, 1799, 8328, 9890, 7456, 1446, 5455, 3022, -3333, -9466, 3209, 3544, 3494, -6529, -6357, 9724, -8715, -7135, -9420, 2218, 997, -7459, 2239, 2195, -9830, -9186, 4647, 3507, -3288, -7713, -4632, -8866, -2247, -6316, -4882, 1213, 5335, -1997, 2419, -9959, 269, -2560, 346, -9201, 161, -9364, -2539, 2082, -8162, 8613, 4430, 7422, 5374, -4513, 2241, -8396, -3983, -8316, -7943, 4344, -5129, 1447, 3140, -451, -5347, -5329, 8412, -7324, 5197, 475, 1462, 6160, 6730, -3167, -1851, -614, 43, 2426, 9057, 1963, 1443, -3819, 7186, 897, -3785, -7358, -6691, -6745, 122, -324, 7326, 899, 255, 7139, 3605, 178, -1094, 3678, 5444, -6518, -8712, 389, -2999, 4882, -19, 3821, 5769, -8690, 4419, 5885, -2527, 4121, -2530, -8794, -8483, -8172, 5143, -7990, -9279, 3173, 7757, -9862, 9582, -6563, -1366, 6249, 7342, -7328, 4178, 5960, 6398, 5809, -1808, 2733, 803, 309, -8485, -2356, -8122, -809, -5619, 2853, -4557, -9761, 3588, -3629, 7496, -208, -3099, -8167, -5446, 1467, 191, 5977, 2126, -4927, -5650, -3137, 5677, -6181, 1255, -3886, 1841, -8841, 7891, 5169, 355, -5709, -5909, -4008, 6614, -9095, -7404, -7553, -1362, -6840, -5839, 2296, 6196, 5805, -1615, -1938, -408, 4599, 4480, -4487, 4148, 5971, -1133, -2210, 4966, -5213, 1923, 6083, 2951, -5222, 9615, -6709, 4974, 9684, -4522, -7654, -8419, 5491, 6042, -7650, 3110, -2815, -3016, -6623, 9501, -4720, -3877, -7450, -3286, 8830, -9459, -5815, 4440, -8875, 549, -4033, 1037, 6077, 4984, 5867, -9096, -9308, -2464, -2231, -8748, -758, 7289, -7901, -3423, -8035, 3987, -9071, -5865, 6055, 7390, 2288, -9212, 6955, -9461, 4076, 2877, -6528, -5983, 5148, -5188, -5366, 4550, 8607, 8647, -4420, 5937, 7509, -2465, 9848, 9471, -5570, 6737, -7699, -916, -457, 2846, 3658, 9092, 6508, 2564, -1387, -6255, -9505, -4419, 9467, -6671, -8261, -2368, -9467, -1234, 6033, 8996, -3302, 4323, -801, -851, -9413, 7880, -1084, -2105, 3263, -7033, 1705, -7924, 3788, -2423, -3519, 4453, 6451, -6979, -9374, -2668, -5827, 4497, 4598, 8076, 6308, 217, 6388, 2543, -3253, -8384, -7441, -822, -5924, 554, -640, -1733, -4411, 9211, 2165, -7136, 9007, -7672, 651, 9410, -2365, -4193, -1296, -4821, -627, -6910, -5420, 316, -8599, 9493, 5367, 9751, 5576, 8046, 3956, -11, 4836, 3666, -6716, -7078, 7582, 7748, -4410, 9291, -9510, 713, 4510, -3624, -2385, -5408, 3733, 7607, 4719, 7166, -7315, -6640, -5550, 5899, -2501, -1755, -1623, 2432, 7636, -274, 9173, -8936, 8770, -7381, 6717, -75, -6766, -4842, 3726, 2600, 2847, 6199, -1547, -9268, 9356, -4768, 2829, -4333, 260, 6870, 3072, -3820, 6505, -1337, 991, -2559, 506, 6465, 8075, 5501, 3073, 9547, 1503, -6642, -8552, -8429, 8398, 8362, -5358, 3621, -7435, -4054, 8397, -3227, -3429, 4392, 5600, -6562, 6131, -7277, -7237, 5405, -5277, 4175, -3380, 8877, 6839, 6245, 8236, -2961, -5230, 7917, 4924, 3674, -9481, 5684, 7442, 999, 5004, -4013, -176, -4573, 5129, -6787, -6052, -3765, -3470, 7936, -3403, -5, -8346, 4007, 5766, 5214, -3002, 8897, 1745, -3925, 531, -7211, 2099, -7279, -136, -9146, 9994, -9534, 4579, -5516, 6129, -7671, 9922, -3794, 7595, -8257, 2019, 609, 6431, 9194, -5044, 6359, -5459, 7762, 5724, 4732, -4381, -6775, 2530, -7563, 4884, 2350, 1577, 8017, 9193, -1664, 3877, 9085, -3868, -8559, -2809, -4023, -3585, 841, -5573, -6342, 8846, -1652, 9008, 7853, -6017, 5824, -2827, -3993, -5083, 3697, -2188, 9824, 2748, -6772, -1703, 3593, -7368, -7962, -1267, 7941, 5979, -181, 6269, -2394, 1662, -7098, 6922, -9329, 8379, 6890, -1674, -5652, 7143, -3587, -1577, 2386, 723, -1859, 2067, 8503, 1789, -1379, -3277, -5481, 4950, 3438, -1216, 1602, 906, 5274, 442, 8320, -8721, -3712, 4611, -3444, 6600, -3878, -2759, 4195, 645, -5253, -5227, 4127, 4415, -2314, -5777, 1779, -8165, 2323, -1846, 6437, -7354, 4964, -9046, -4138, -7305, 8035, -3391, 951, 7371, 1012, -5748, -3024, 2488, 6573, -9806, -6003, 9162, -9428, -4134, -9077, -2802, 1797, 1701, 3443, 7686, 1154, 6803, -7419, -6827, -846, -8807, -5207, 8228, -2220, -6157, -9872, -2258, 7626, 664, 5913, 3088, 2750, 571, -3097, -42, -5362, -8783, -906, -5193, -7631, 5245, 1971, -1676, 7818, 1831, 3135, -6670, -4944, 8745, 807, -7456, 3104, -8278, 1067, 6157, -5077, 9438, -3125, -625, -7637, 875, 2002, 634, -9818, 7387, -2881, 8436, 4343, 3165, 2166, -8916, -8228, 6923, -7931, 3235, -8892, -1350, 133, 7821, -3855, 568, 7875, -1520, -4719, -9847, -4254, 9888, 5849, -9221, -7669, -5319, 8440, 5881, 7129, -6719, -3558, -6200, 2531, -1941, 5062, 7233, 9481, 635, -7518, 5968, -6957, -6307, -6683, -8087, -9643, -4877, -9813, -4970, 3001, -2582, -2616, -5626, -3942, 2015, 2455, -288, 9452, 2301, 416, -5126, -9738, 5403, 8465, 9362, 2659, 830, 884, 2020, -6684, -831, 5414, -7623, 8910, 2954, -591, -7413, -4822, 4506, 7116, -193, -497, -6261, -4029, -2147, -5659, -5629, -6572, -1171, 2988, -4904, 8481, 2300, -4963, -2124, 1087, 6916, -7781, -3395, 8476, -69, -5910, -3836, 3601, -8047, 9461, 8338, 9709, -2334, 8906, -6948, -1526, -6628, 2984, 5531, 449, -5861, 4797, 8977, 1585, 525, -3818, -2835, 7884, -6363, 4435, -5579, -3628, 5290, 6924, 1430, -6558, 9437, -2956, -2840, 9905, -7412, -9033, 6908, 6463, 7565, -874, -7913, -6946, 9416, 2492, 4403, 2706, 1790, 4780, -6509, -5031, 2404, 5837, 5424, -3023, 4335, -4183, -3370, -1351, -4790, 7007, 8680, -9918, -1605, 7560, -9059, -1432, -3132, 6781, -2770, 4346, -6321, 4824, 300, -518, 9702, -3367, 9821, 9106, 6825, -2433, 3332, -8124, -2370, 8851, 647, -5543, -9566, -8517, 706, 7811, 9807, -9892, 5801, -737, -403, 60, -6163, 8115, 7833, -4044, -7093, -3104, 9375, -3722, 4372, 40, -9019, -1199, -6133, 5829, -2655, -7702, 7269, 5230, 7302, 1442, -712, 5192, 8100, -8098, -7437, -35, -4069, 7804, -8113, 2501, 715, 7605, -7416, 7729, 2813, -5637, -6427, -8130, 5895, 5493, -7641, -6164, 8247, 4030, -6794, -3331, -3950, -896, 5343, 6611, -236, -4866, 6678, -9519, -9427, 1567, 7648, -7278, -7055, 6360, -4736, 1731, -8631, -8069, -1531, 9500, -9434, -2744, -6168, 505, 7652, 3744, -1307, -8334, 4541, 3070, -4259, -9038, -4073, -4034, 6900, -868, 5153, -5949, 1814, -1002, -5706, 759, 6254, -7176, -4393, 3131, 5681, 3153, 8241, -6264, 9302, 3282, 6301, -5727, -6478, -9635, 35, 358, 6732, 6000, 978, 459, 5123, 2208, 4987, -4627, 1833, -1512, 7602, -3842, 4275, 7081, -807, 4083, -5925, 4324, -3425, -1414, -2806, 9404, 6302, 1338, 5185, 4930, 9928, 7872, -6736, 6991, -3412, -9621, 9249, -7317, -4091, -9029, 4027, 414, 9995, -3625, 1811, 408, -4093, 199, 9644, -6797, 3841, -6546, 6734, -2494, -4951, 6550, 4140, -6854, 1479, 5211, 3218, -4886, 9683, 1715, 537, 6558, 7405, 3718, 335, 6708, 6506, 471, 820, -9497, -8100, -8816, -5961, 8791, 5719, 3770, -7, 7543, 5743, 8396, 8364, -3550, 1276, -8023, -6714, -7597, -2969, -2879, -5154, -8833, -239, -8693, 7417, -4489, -2876, -7679, 66, -9704, 5623, -2762, 3069, 9156, -2505, -2680, -5273, 3175, -1459, -759, 3035, 4277, 3229, 772, 3867, -1014, -1649, 7993, -7478, -8475, 578, 9236, 5167, -6430, 6141, 3529, -8623, -8621, -3728, 5191, 3635, -9194, 9024, 5582, -9274, -4580, 2625, -6221, -7778, 4968, -1804, 3345, 8743, 5482, -9785, 6516, 1263, 5994, 585, -1646, -6807, -2373, -7661, 1990, -8870, -2782, -8591, 7353, -5635, 7472, 3914, 6888, -657, -624, 4222, -9884, -6689, 3154, -2000, -7061, 3117, -6704, 4101, -1222, -9256, -3757, -5877, -829, -9004, -9273, 5942, 175, -4976, -414, 9233, -3260, -63, -2981, 5796, 8451, -907, 5083, -5268, -1651, 1562, 5528, -3464, 3979, -1243, 8135, 8348, 7097, 7528, -594, -3079, 9829, -2308, -4902, 7486, -1700, 9970, -1906, 1419, -8409, 4421, -5278, -9993, 4004, 3211, -5730, -1224, 2073, 7815, -6404, -5553, 770, 1518, -7004, 8533, 1755, 2791, -8182, -9786, -6575, -6220, 5815, 4862, 8580, -2001, -5812, -6521, 9854, 3143, -9190, -2510, -8683, -1599, 8981, -644, -9996, -8592, 9516, 9417, -4372, 8066, 8886, -8804, 4812, 9845, -2481, -336, -3598, -2280, -249, 9798, 3511, -2171, 6186, -3658, -4430, 8938, 3465, 7550, 3526, -7443, 6193, 8852, 6009, 7192, 2258, -4483, 4517, 6582, -4316, 7747, -812, 9317, 4206, 1586, 724, -1359, -6929, -7728, -3595, -1118, -404, -2108, 9962, -2120, 1641, -1237, 1066, 3687, -1442, 2591, 6493, -4919, -4560, -9302, 2838, -554, 652, -8674, 879, -51, -879, 827, -6866, 3305, 5962, 7625, -7464, 4989, 2839, 7939, -6633, 4903, -7866, -4, -7049, -2489, -1567, 1138, -3966, 799, 6312, 3132, 7344, 5537, 6697, -2937, -4162, 7168, -569, -3656, 2942, 4356, -1321, -7051, -5975, 9757, -4161, 5781, 6030, 7730, -8074, 4698, 3075, 9511, 3422, 3098, 5093, 9050, -4245, -6448, -8835, -1420, 324, -2067, -4778, -1710, 7623, 4662, -740, -2215, 6719, 2476, -1737, 9434, 731, -6213, 1837, -3005, -2283, -6256, -1277, 3717, 6076, 3309, 7684, 9303, -3751, 5276, -3381, 28, 8587, 2915, 2092, -6061, 2306, -2516, -1726, 9102, -3426, 968, 8931, -3189, -3655, 9325, 121, 9507, 8175, -963, 7656, -32, 3114, -5269, 7665, -1895, 8104, 275, 6880, 8019, -852, 1878, -3484, 5189, 3535, -6960, 4093, -3929, -7213, 3633, -8719, -4037, 5986, 8148, 366, 6320, -5739, -5977, -6, -4016, 7660, -9041, 3146, -6651, 9864, 566, 2428, 9536, -7428, -6770, 8880, 5466, 6769, 9289, -516, -489, -2724, -2190, 519, -7162, -467, -2052, -6618, -7760, 6292, -4525, -5790, 6058, 6798, 528, 2999, 139, 9116, 4008, 5818, -6097, -219, 9502, -5208, -7755, -8126, -2664, 8003, -3258, 9613, -885, 5713, 1222, -7651, -6848, -5688, -7775, 985, -9637, 4557, -9812, -5720, 550, -4100, 1769, 1171, 6652, 1130, 1445, -8271, 1184, 7453, 1732, 4532, -3118, -7742, 3388, -670, -883, -989, -9657, 2907, 4129, -7798, 9005, -4870, 7742, -8812, 1303, 3056, -8111, 6884, 8101, 4880, 2825, 4000, -3074, -2301, -7144, -9113, 937, -2537, -4292, 3016, -5283, 778, 2032, 4758, 9352, -8994, -4995, 2560, 9244, 4938, 341, 5139, 3971, -2887, -719, -9716, -2637, 304, -9346, -7614, 6766, -8546, -3699, 7454, -4146, 4992, 4860, 4879, -930, 1422, -7792, 8008, -722, -4353, -511, 2981, -4921, 3861, 8067, 266, 6347, -496, 6176, -3249, -9031, -2761, 3071, 8976, -4452, -9817, -4775, -4287, -9694, 4925, -9421, 3521, 7438, 2081, -434, 5227, 7316, -6965, -6830, -5121, -5891, 7126, 2781, 4345, 6416, 885, -1041, 4203, 6115, -680, 5637, 9777, -3345, -3928, 194, 6062, -5666, 3607, 8671, 4508, -4541, 4455, 4623, 1587, 1927, -5958, 9068, -4045, -7892, -6782, -865, 5686, 4084, -8904, -9973, 3347, -8743, -8951, 6676, 2507, 7167, -2641, 9172, 8779, -157, 6050, -1461, -3973, 8305, -8668, -1168, 3964, -6174, 5924, 819, -9309, 5033, 5618, -74, 5082, 2148, -5258, -2673, -583, 6319, -4424, 4895, 103, -286, 2490, 7863, 2123, 4794, -2950, 8555, -4791, -6118, 336, -6681, 2768, 3830, -3641, -2418, -8848, -6055, 4171, -595, -6667, 6280, -5471, 5355, -5575, -2780, 2524, -3252, -6916, 733, 6861, -863, -873, -7733, -5172, -710, -3427, -6242, -7137, -3489, -8048, -1524, 7445, -9426, 1802, 4080, -9981, -9711, 5077, 7265, -4144, -7759, 1918, 7990, -1301, 5984, -7711, -6359, 8334, -3957, 7483, 5551, 6496, -6223, -5574, 697, -2431, -1433, 7968, -9119, 835, 5892, 1025, 6699, -5725, 9176, 8394, 3859, 4020, -5585, -3279, -9827, 2685, -2497, 1532, 6944, 7763, 3915, -4860, -2564, 2331, 6162, -3994, -1484, 3342, 3631, -5555, -7627, 1629, 6913, 1800, 9411, -6367, -3798, 1282, 3603, -6150, 8989, 193, -474, 9852, -6068, -9705, -7826, 6687, 5722, -9794, -3896, 3392, -751, -4732, -5158, -6799, -5019, 6130, -4497, -6496, -7816, 1284, -5030, -1871, 4757, -1154, 2540, -468, 7942, -3535, -2773, 2861, -9580, 1136, -6743, -6732, 9628, 5524, -8805, 3321, 3138, -8797, -7272, -1159, 5068, 206, 1851, -7715, 8882, -6617, 8244, -5314, 4404, 5225, 728, -8395, 8219, 849, 3627, -357, -9542, 9031, -8973, -5034, 9728, -8687, -2625, 2654, 6340, -4226, -6134, -7960, -7259, 3107, -9755, 7376, 1882, -9480, 739, -8613, -144, 5443, -1976, 3677, 6874, -1240, -70, 8577, 330, 9630, -4682, -5242, 1223, 5020, -9345, 2740, -5067, -6120, -6720, 8921, 7836, 2568, 8963, 5013, 8927, 5554, -5869, -8813, -3848, -5409, -6734, -2299, -9079, 1058, -2392, -4982, -746, 6656, 1627, 407, -2459, -3742, -4431, -3714, 9432, -5998, -8265, -5043, -2518, -4251, 3582, 8152, 9262, -8993, 9923, 5300, 3938, 3163, -2901, -7541, -7350, -9061, -4170, -732, 9832, 5257, 4919, 4255, 4349, -4326, 1074, 1206, 7854, -3110, 2579, 959, -269, 3731, -4809, -3450, 5494, 9394, 54, -6726, -2594, 6253, -1807, 2496, 7750, 1396, -8248, -9052, -1747, 5991, 575, 9817, 6677, 6793, -5687, -6933, 7599, 2034, 971, -2774, 2857, 4032, -6245, -8298, -1758, -1720, -9396, 1524, 3581, -5705, 6081, 1894, -2250, -2119, 5061, 2701, -5364, 2059, -7007, 7760, -1189, 3283, -9193, -6586, 7187, -6710, 5308, 4470, 8291, 2735, 5131, 9556, -6484, 1683, -4880, 8492, 7435, 729, -6144, 9387, -2934, -1521, 7975, 6937, 8464, 9623, -8109, 4646, -2255, 4650, -616, -6711, -5970, 1642, -9130, -4864, 5513, 1764, 6535, 1386, 5680, -2362, -6804, -8321, -5963, -3233, 4502, -8202, -508, 670, 6167, -6901, -3248, -4206, 1477, -7128, 7283, -9616, -4277, -2228, -9954, 7920, -1641, -1182, 2788, -2578, 8442, -2626, -5286, 4878, 3738, 766, -683, -9978, 5106, 3375, -101, 6349, -8344, 1399, 9449, -1805, 3484, -1843, 1299, 7526, 1140, 294, -2811, 109, -7289, -8519, 4691, -9202, 9282, -3383, -5562, -1357, 3152, -4631, 9002, -9810, -915, 7777, -5973, -2646, 4058, 5961, -2227, -2282, 8047, 8500, 7161, 5461, -9599, 8505, 4378, -5823, 6668, -9234, -3976, -2906, -4980, 4184, 6536, -6011, -2572, -5191, 5653, 7059, -4027, -7103, 8123, -6596, -9222, 2997, -6381, -7509, -7155, 7399, -9814, 719, 9240, -974, 1294, 9513, -911, -2924, -6029, 89, 6636, -8593, -8350, -6451, -4344, 6974, 218, 2321, 5103, -6838, -4148, -6834, 4231, -9043, -3940, 6904, -9507, 9235, 7666, 8159, -3428, 7218, 93, -4076, -7752, 9931, 9686, -1120, 2223, 393, 1720, 2264, -4504, 8177, 1453, -6084, -6956, -3974, 8447, -4797, -1140, -3982, 8645, -8101, -9097, 4188, -4191, 1520, 8935, 4627, 8373, 2965, -1802, 3743, 6833, 2280, 610, 6409, 7397, 1757, 823, 2653, -3859, 153, -2467, 7208, 4948, -6187, 5811, -850, -4684, -6471, 9538, -9133, -4081, 3858, 2129, -7312, 3970, -864, -1032, -1939, 310, -2344, 6623, 9153, 2603, 8006, -307, -4568, -1066, -6656, -8360, -2409, 717, 3430, -8208, 6646, -2832, 1810, -837, 7676, 2315, -7140, 4157, 9736, -808, 5373, -1972, -6228, 1788, 4360, 9038, 1983, 8971, -2487, -399, 4826, -7572, 1659, 3415, 1839, 9504, 8105, 8599, -1566, -9722, -9267, 8835, -9682, -7102, 5208, 9993, -2532, -7240, -3267, -5469, 8283, -233, 7888, 2190, -5423, -6216, 7292, -1765, 9636, 708, 2355, 4876, 9999, 3781, 6748, 5385, -3088, 740, -7983, -3141, 3512, 6439, 8836, 4500, 5790, 6859, -8322, 8133, 6641, -5976, 2835, 5934, -150, 6755, -8281, -3814, 3168, -6993, -5915, 1679, 5807, -9821, 4839, 9333, 8519, -4299, -4131, -7894, 9464, 730, -3466, -1092, 1208, -653, 1644, -5818, -1634, -5784, -4876, -2393, 5354, 4902, -691, -3086, -617, -769, 4712, -2546, 2513, -9016, -6094, -380, -847, -895, 9871, -7040, 67, -7418, -2817, -1146, 4240, -6923, 4112, 2952, -898, 5330, -8423, 7654, -1621, 3323, -6769, -2180, -2921, -8287, 3572, 9689, 7633, -6874, 7791, -4910, -9804, -515, 9793, 6815, -8840, 2424, 5560, 9390, 3870, 5352, -411, 6662, -7121, 8972, -7780, -4218, 1119, -977, 5418, -1026, -398, 828, 1449, 6612, -9882, 4450, -3740, 5226, -1562, -4819, -9443, -4252, 1733, -172, -861, -5254, -2145, -5124, 6538, 2852, -2166, -4714, 2334, 4123, 1863, 2297, -7705, 7898, 7370, -1826, -7824, -306, -9289, -9325, 3947, 1913, 956, 2216, -9355, 7243, 2767, 2931, -7878, 4670, 3302, 1504, -8359, 3758, -9956, 8627, -9207, 1291, 806, -3177, -203, 509, 6200, 7737, -9928, -6390, -294, -7218, -4196, -8220, -9233, 2124, -7747, -7864, 8739, -2435, -7080, -9994, -5905, -3632, -9435, -5142, 1535, 3706, 5242, 643, -4885, 8513, 9765, -2654, -3451, 5184, 3860, 5741, 5647, -6197, -5244, 4288, -4609, -8736, 5821, 8486, -6912, -4498, 3445, -3238, 6171, 1942, 3944, -3439, 4630, 4118, 8140, 2353, 8245, -1069, 9234, 6510, -4001, 587, -1068, -6240, 2016, 4886, 7150, 2343, -7002, 2236, -6382, -8091, 9371, -5135, -2742, -3365, 2282, -520, 6775, 4409, 1888, 1992, 6899, 403, -1779, 5671, 411, -5759, -9398, -8799, 2356, -1563, 9671, 2682, 5655, -1082, 2673, 2947, -2377, -9275, -4999, -4383, -3435, 2634, -819, -2046, 9496, 3042, -8452, -7165, -3822, 3905, -5728, 5101, 5845, -3236, -9933, -4534, -9870, -5497, 8079, 3612, 8634, -3787, -2525, -6329, 5639, -897, -47, -9880, 7718, 5435, -9783, -6219, 6672, -8659, 5396, -7818, -2603, -9857, -4356, 3844, 7554, -460, 8781, -7202, -5180, -2160, 6782, 1257, 8768, -2785, 5175, 3616, -9874, 7812, 7173, -5123, -9712, 8214, -2351, -6531, -3473, -6751, 8058, 7415, 5110, 9831, -46, -5070, -1422, 4016, -5228, 3786, -7487, -135, 1807, -4275, -2631, 8954, 2214, 529, 7060, 9900, 7984, -6250, -2106, -1719, -9187, 2925, -2123, -1474, 1073, 9382, -8920, 3890, 3598, 942, 1123, 5277, -4862, -3431, -94, -6503, 1636, 6353, 6168, -5804, -1322, -1766, -5754, 3536, -3274, 8772, 1491, 8660, -2070, -1494, 1451, 4838, 6855, 908, -7584, 1186, -20, 5828, 8013, -1838, 3657, -8125, 1742, 7201, -5832, 8296, -5529, 5498, -1469, -9259, 147, -7811, 4251, -6262, 8151, 5456, 1549, -5433, 2713, 4013, 1022, 5468, -7501, 5071, 6934, 2461, -5333, 9237, 1199, -4225, -6463, -4660, -5621, -2580, -6341, -3697, 9412, 9446, 3284, 5094, 7937, -6113, -5551, 4636, -1888, -919, -6162, -4115, 148, 439, 5758, -1959, 5450, 7450, -2293, -4505, -2953, -9967, 2723, -5431, 5488, -1708, 401, -1598, 6626, 1870, -3388, 8033, -9227, -9391, -4332, -228, -1246, -7800, 8103, 9310, -6376, -3193, -7504, -8095, 2481, 7733, 1758, -3014, -9082, -6066, 6229, -164, 7522, -1643, -8930, 1786, 5539, 195, 42, -7621, -7574, -4103, 4142, 7384, -4014, 9091, 272, -6855, -3984, -2482, -3496, 6651, 9314, -2584, -1622, 2480, 2228, -9003, -7375, -2676, 3433, -9718, -9888, -6690, 9805, 1174, 7934, 3151, -131, 5285, -4712, 361, -2980, 7053, 9926, -7772, -1141, 462, 5398, 9715, 299, -4701, -33, 6088, 8895, -6820, 2736, 4338, 1855, -225, 5981, 4856, 1962, -7099, -5430, -2076, -7899, 4927, -5218, 2041, -6456, -8477, 5732, -7197, -3931, -7580, 5237, -2267, -2305, -902, 7366, -102, 5264, 9145, 3727, -5052, -4375, -3215, 590, 9966, -4891, -5496, -8885, 8437, 2079, 3928, 8011, -7704, 1622, 73, -8923, -5022, 3179, 4226, -4820, -7748, 5306, -3080, 3180, 9747, 4048, 5459, -5097, -5394, 6618, 2385, 1118, -3161, 7739, 677, -4837, 3990, -1580, -8811, 4896, -5661, -2996, -4390, -7111, -530, -5229, -790, 7713, -6263, 7199, -4981, 5025, -7564, -167, 3955, 2373, -3335, 6107, -4409, 5133, -388, 6052, -970, 5267, 98, 481, -8145, 8322, 2719, -5338, -1228, 811, 1865, 6831, 94, -8793, 4680, 6064, -9807, 1594, 1872, 1357, -358, -7692, -8473, 4422, -1235, 6593, 4051, -5378, -6977, 3096, 2100, 34, -381, 2135, -9357, 8377, 7200, -5064, 4321, -5505, 5947, 3397, 5294, 3009, 5120, 672, 791, -3312, 1437, -6149, 9377, 7258, -1413, 3425, 3156, -4841, -8826, -8941, -2566, 5183, -2211, 8978, -9969, -2764, 5914, 7721, -8076, 7938, 9772, -8697, -4303, -7299, 6578, -5838, 4088, -4123, -5236, -4133, -9047, 9423, 6351, -333, -8880, -6423, 3569, -5144, -946, -2756, -2468, -1648, -5247, -5413, 8254, 9158, 7989, 995, -7540, 6065, 8678, -2650, 5983, 5258, -4117, 2689, 3776, -1502, -3547, -6505, 8256, -4168, -741, 3246, -2715, -8948, -4743, -1093, 4675, 8040, 5075, 5448, -9589, 2994, -1164, 1458, -7556, 923, 3686, -8341, -5096, -7153, 9099, -7281, 1355, -4892, 2941, -7109, 3909, -4319, 2193, -4412, -8164, -2378, 7510, -9090, 6690, -2442, -7608, 2644, -1106, -7977, -9423, 8176, 4293, 6270, -7863, -3295, 4477, 1441, 4389, -4432, 8477, -5490, -3251, 5678, 5710, -3580, -6204, 4686, -9393, 5044, 5016, 2944, -77, 223, -7802, -1303, 5377, 8651, -5392, 7358, -8066, 4205, -9535, 4749, 5770, -1630, 5287, -5008, 4429, -2332, 3599, 1795, 6460, -3594, -6978, 9880, -8847, 1304, -6125, -2613, -1989, -1173, 7835, 8809, -5147, -6826, 7190, 5449, -7242, -241, -6479, 3782, -1250, 2229, -5945, -671, -5041, 6664, 9789, 7271, 1082, -305, 2903, 3910, -9536, 1002, -5454, 4621, -2943, 135, -6028, 7011, -5487, 8156, 1339, -9402, -5001, -8523, -948, 6577, -4814, -3229, -2935, 6329, -9571, -6825, -190, 9781, -1721, -7273, -6128, 3500, 2754, 350, 5347, -6694, 831, -607, -1398, 7145, 4232, -2632, 7964, 8870, 3023, 113, -471, -6465, -3872, 6047, 3479, 5149, 6053, -4571, -717, 7596, -844, -5261, -7467, -5071, -8374, 415, -5559, -8662, 3019, 8833, 9713, 8974, -9768, 6682, -5847, 6742, -5736, 3012, 3917, -4760, -8895, 2755, -5594, -1010, 4035, 5339, -2477, -8181, 2370, 3126, -4417, -3926, -2369, -5876, 8773, 2278, -5919, -8669, 4496, -996, -6883, 7105, -4462, -891, -7432, 4272, -9491, -4330, 2010, -4329, -8104, -1499, -9232, -3736, 5608, 4199, 3272, 4116, -2199, -8871, 4466, -6881, 8479, 8149, -6154, -2563, 5113, -8370, -3889, -689, 6863, -3661, 4414, 3982, -6889, -4455, -7484, -7370, 1036, -2469, 7268, -6481, -4624, 3764, 9788, 6007, 1830, 4070, -247, 8213, 4678, -9508, -6630, -3541, -6495, 5932, 1035, -5452, -2801, -720, 7019, 443, 1027, 9750, 3118, 7106, -9696, -2125, -8791, 8327, 1534, 3926, -6394, -8044, -8283, -1377, 7018, -6801, -8028, -4795, 838, -7880, -9919, -9604, -3748, 7790, -8447, -8590, 6504, 5640, -9622, 1650, -432, -9983, -8759, -978, -8579, -6230, -4338, -2059, 2128, 1105, -3495, 5486, -1850, -2114, 3962, 116, -6932, -2287, 2619, 1707, 5688, -9625, -4318, 5978, -5233, -9836, 8733, -8692, 5569, -2852, 2902, 7707, 3028, -4288, -3927, 354, -6311, -1000, 9283, 2246, -934, -487, 9258, -5584, -7786, -174, 9058, -6365, -7345, -4591, 6266, 1617, 3105, 2650, -3172, 591, 890, -1280, -491, -1582, 2095, 8433, -8320, 3797, 2351, -8526, 7706, 7029, -901, 5529, 1450, 5032, 760, -7566, 2858, -449, 4, 1297, 6250, -6815, -1556, 5136, 6464, 5567, -8822, 5896, 7844, 1465, 3698, 70, 3614, -9512, 9802, -4674, -2053, -5875, 9835, -4217, 1440, 5484, -4108, 3693, 5072, -3135, -7961, 963, -7764, 1431, -5801, 1836, 2172, 2640, -3627, 3547, 9010, 2762, -313, 7889, -2622, 5128, 2175, -8331, -555, -7862, 9366, 5980, -9062, -3477, -1007, 6667, 8452, -793, 317, 6982, -1136, 1550, 3011, -8425, -8634, -9605, 9462, -5263, 4081, 7272, 6485, -4621, -9754, 3525, 3030, -3904, -2117, -770, 4688, -9547, -3004, -1680, -7415, -9314, 8400, -5898, -7598, -23, -6652, -2387, -8020, 2969, 2774, 4077, -7858, -4563, 3122, 6921, -4542, 2252, -7323, 3514, 3515, 8784, 9053, -2883, -3766, 1413, 6260, 6902, 4622, -6086, -1142, 7464, 2801, 7389, -7228, -8307, 8867, -1232, 8225, -9509, -9408, -4403, -3996, 8416, 5705, -3077, 2159, -3145, -6682, 8495, -9986, 2391, -5630, 2054, -3733, 4493, -5300, 3822, 8973, 4298, 4445, 8999, -5249, 2759, 8329, -8049, 5641, -2049, -9406, 9771, -8189, 9844, -7700, -7821, 3997, -6239, 5897, -8116, -6798, 9326, -7558, -2148, -9661, 2203, 9166, 5170, -9112, -7955, 7999, 9804, -2726, 2841, 4724, 7659, 9112, -3186, -7294, 2581, -6487, -5732, 5314, 1319, 7566, 6169, -7455, 2330, -4089, 3400, 1252, 9881, 7924, -2460, 5734, -3702, 1951, -2772, 3003, 8819, -3930, 5052, 7770, 4916, 6725, -1058, -1326, 3187, -478, 460, 205, 3459, 2093, 9243, -2178, -2768, -4437, -5465, -638, 535, -5928, -2985, 1030, -5349, -1318, 4620, 3464, -188, -2253, 7925, -8289, 688, 6452, -5384, -1191, 4362, -5695, -1126, -5232, -9118, 4701, 1173, 2756, -8550, 7950, -6880, -4889, -138, 8091, 1598, -6326, -7516, 9660, -4859, -3085, -1177, 1717, 4991, -3949, 5426, -1810, 2745, -7025, -747, 6544, 3884, 8578, -3168, 1406, 8918, 3384, -6054, -3523, -4150, 4153, -159, 1279, 5168, 5938, 9433, -4147, 4354, 3988, 6529, 4095, 145, 3800, -4256, -2104, 7038, 598, 262, -3693, -3117, -3813, -8264, -9991, -3102, -8412, 6491, -8877, 7171, 4696, 4751, 7346, -9819, 8872, 2866, -5456, 1155, 854, -5714, 3407, 2062, -7034, -5444, 3976, 24, -9248, 4089, 9526, 1334, -9080, 584, -7653, -4706, -4564, -813, -4126, 9350, -9025, -4470, 4465, 8557, 6806, -5733, -2624, -6692, -775, 5870, 4192, -7693, -6674, 3739, -1204, 774, -1639, 612, 572, -3762, 5792, -1657, 4980, -3643, 2168, -3561, -2607, 2833, 5319, 6417, 4379, -1694, 5046, -5693, 8827, 2918, 3178, -179, 5709, 4034, 156, 6304, -7908, 1317, -1196, -4925, 2744, -1384, -7966, 3973, 1871, 226, -2823, 6639, -3226, -1446, -2520, -3147, 1945, 5668, 1940, -7028, 7074, -6205, 4640, -2169, 3954, -5351, -2337, -5858, -6577, 9901, -9323, 5464, 164, -753, -1434, 8926, 8943, 6389, 8457, -6788, -5421, 8160, -634, -6190, -9890, -8869, 4165, -2889, -572, -2808, -1836, -22, -4384, -1728, 5544, 8449, 9509, -5710, -2257, -938, 4736, -9551, 629, -9524, 7065, 7222, 1848, 2772, -1111, -2743, -6543, -7743, 9988, 9893, 1808, -1254, 6689, 9093, -2838, -3491, -4048, -8679, 1861, 9614, -8056, -4306, -3682, 8614, -935, -8643, -177, 1385, 2613, 6119, 9210, -9230, -9129, -2909, 6622, -4589, -8301, 1432, -4818, -6458, -9160, -8313, -6122, 8455, 6453, 6670, -3180, -3796, -5547, -5105, 3451, -1145, 9115, 1542, 793, -1048, 1411, -6266, -1535, 8383, -5379, -1798, 8547, -781, -2556, 5735, -9593, 9989, -893, -9550, 3978, 5174, 9530, -9676, 6772, 8179, 8167, -599, 4912, 7577, 2541, -8246, -5491, -195, -8037, -9529, 7802, -8777, 31, 6017, 3189, -7907, 5573, -1035, -5778, 6693, 2189, 5160, -1856, 6106, -6486, -4655, 9148, -8688, -2794, 2086, -7606, -4377, -960, -4389, -175, -6693, -1614, 5089, -6553, -2521, 3779, -1626, 1172, -2187, -9752, -243, 4831, -7498, -4689, 2528, 9850, -9361, 6175, 426, 5963, -7407, -6658, -942, 3891, -8137, -3680, -9011, 208, -1568, -3308, 5851, 7637, -5776, 9347, 2775, -361, 2185, -6497, -3017, -8284, -4005, -4850, 2905, 5179, 8106, 6335, -1602, -890, 7160, 1939, -6836, 7690, -332, -7230, -4508, -8219, 9089, 2409, 9695, -8995, 4819, 2261, -6414, -4518, -9686, -8601, 1630, -4211, -4810, -2031, -2419, 9858, 9100, -8588, 6761, 832, 165, 2445, 2924, 5682, 9774, 7461, 9369, 7935, 4144, 5359, 6802, -908, -2478, 473, 9450, -1688, -2096, 5126, 5701, -1732, -6295, 9275, 500, -9576, 9947, 4737, 9605, -4263, 5162, 9853, -8700, -2214, -4524, -8121, -7569, 4750, -278, -6421, -2453, 9726, -9226, 1599, -8853, -8578, 1256, -255, -871, -5540, -6996, -1157, -2273, 6368, 6105, 2948, 2535, 1047, -6764, 222, -1633, -5734, -7196, -5200, 9298, 5417, -3863, 9277, -7840, -3006, -4443, -4302, -8890, 6362, -260, -6524, -281, 421, -9717, -7645, 7953, 7198, -4641, 1541, 7359, 2990, -2366, 1290, 2182, -2491, 2380, -5660, -479, 9877, -4012, 8654, 3356, 5353, -4984, 7618, 9859, 2778, -4074, -7479, -2313, 7696, -7507, 3504, 2882, -7795, -7546, 9604, 6499, 5850, -3906, -3241, -8695, -642, 8987, 7033, 5916, 6777, -4680, 1498, -2502, 3052, 1783, -8652, -2288, 1271, 8670, -945, 6770, -3045, -4272, -3264, -5382, -9181, -581, 8062, -8232, 7267, -1945, 7419, 1258, 3301, -2094, -8686, -9247, 2458, -6192, 7176, 3329, 6346, -8151, -9979, 1747, 9066, -6638, -8574, -4078, -6375, 2097, 5286, 1198, -1914, -3205, 8001, 3081, -6232, -3540, -1831, -9185, 7758, -2275, -6287, 2057, 4078, -3259, -1588, -6802, 3863, 972, -3811, -6155, -9940, 8218, 9889, 7569, -9228, 801, -3292, -1595, -2352, 7799, 8288, -7123, 2559, -9266, 3158, -5493, 4717, 6950, 9208, 6503, 4906, -3217, 6278, 4139, -4298, -9120, 524, -3947, 5715, 9665, -4754, 3055, -8352, -6395, 1353, -7227, 1286, 2068, 3530, -1364, -7703, 5154, 3713, -4159, 2876, -6373, -795, 7907, -6198, -464, -6547, -5896, -2737, -9903, 7946, 9531, 7881, -3307, 2608, 8893, -1785, 536, 9972, 3811, -1238, 2336, -7963, -957, -5328, -469, 5303, 7843, 5080, 1653, 3924, -9154, 9192, -5439, -5964, -8864, 5118, -9522, 926, -6462, 8782, 9910, -539, -3065, 639, -4457, -7405, 8108, -2660, 2105, 980, 5138, -2696, -9132, -5404, 7832, -6271, 4658, 9338, 1935, -6548, -2010, -3276, -582, 1654, -9375, 6845, 7564, -8216, 8012, 3004, 7329, -2289, -4727, 1901, 183, -6334, 1677, -5561, -800, 243, -3497, 5292, -7561, -141, 5480, 8803, 4109, 1091, -6210, -3805, 8267, 1751, 6032, -8684, 3555, 8629, 8588, 8777, -5282, 7959, -2728, -6829, 3751, 1264, 8360, 6051, 8889, -4878, 7921, 8633, -6852, -4694, 9768, 2078, -2367, 3778, -2456, 1006, -7875, 424, 4645, 9486, 6638, -82, 4402, 1249, -7855, -9455, 2916, 3966, 5613, -2674, 7931, 1028, 8376, -4909, -8570, -9960, -9400, 180, -3705, -7996, -6545, 9016, 845, -8962, -5668, 6240, -8266, -7942, -4556, 352, -4127, -1022, -9486, -8470, 7712, 1614, 564, -7613, -8143, -9693, -823, 5636, -8339, -4707, 4005, -4787, -9698, -899, 4726, -109, -2281, 9445, -552, 1926, -6760, 2251, -9261, -4006, 4382, -8878, -9726, 8687, -8595, -8624, 8920, -6483, -7496, -5698, 8923, 4858, -2870, -8427, -2008, -1695, 6142, 8551, 3920, -6746, 552, 7629, 8131, -9432, -3573, -9405, -3821, -6048, 8237, 701, 7239, 6322, 8401, -5426, -4155, 1153, -5058, 6727, 7911, 7806, -5341, -495, -9358, 6434, 1552, 7998, -7976, 7945, 5477, 5804, 7744, -196, -7047, -6051, -6081, 9331, -7534, 4488, -9721, -4050, 6909, -9474, -677, -1696, -7515, 7482, 384, -226, -8536, 2885, 8295, -7758, 3102, 6317, -417, -4618, -4549, -3437, -7470, -9672, -3964, 6298, -7266, -36, 8497, 4040, -5025, 4710, 8620, -6057, -7453, -1077, 448, 8787, 8549, -1864, -6060, 6385, 2910, 1849, 1613, -2959, 6592, 6617, 8235, 6967, 6729, 898, -8629, -3485, 5617, 700, 881, -7898, -200, 4897, 7098, 5888, 3198, 7037, 7100, 7210, -3738, -3136, -5429, -6647, -3756, -1572, 3592, 3418, 7860, -8524, 2622, 6108, 2436, 8181, 308, 982, 7735, 7506, 3044, -4658, -6954, -4914, 2314, 7223, 1874, -5889, 7985, 3659, -308, 6056, -5035, 4577, 9073, 120, 4832, -8403, -8039, -7734, 3957, -2462, -531, 4799, -4747, -1761, 7752, -6697, 9101, 8585, -4906, -1147, 2831, -9334, 4809, -204, -673, 8666, 1563, -9617, -5320, -6701, 7025, 7287, 9316, 1776, -2414, -3546, -9030, -122, 734, -7519, -7280, 3219, -8019, -8245, -8455, 8512, 4816, 6701, 5121, 9759, -9597, 3410, 8722, 9125, 3855, -1198, 4759, 2274, -1272, -2947, 2886, -5005, -605, -8315, -827, 9705, 1472, 2771, -9671, -7325, -721, 5597, 3813, 7185, 7231, 4128, 8676, 1193, -7461, -7059, 4923, -2390, 5366, 91, 6466, -2666, 6390, 9499, 1904, 1135, 261, 7619, 4218, -4379, 8567, 9415, 9786, -686, -9087, 2705, -9105, 5593, -1510, 3461, 4278, 5381, -4171, -113, -733, -684, 2794, -8545, 1329, -155, 465, -9966, -7369, -3115, 7704, 163, -3011, -8718, 8975, 9796, -7011, 2108, 2529, 2497, 3094, 4208, 8919, -9473, 3685, -7714, 7837, 2420, -6753, 7278, 8197, -2233, -8644, 9389, 8760, 9199, -4533, 5848, -6890, -2017, 3089, 8753, -8305, 5009, -2591, 3141, 1529, -7732, -6795, 6757, 4787, 9862, 6066, 1609, -7486, -79, -2021, 5406, 5736, 4857, -1788, -5833, 5631, 9646, -7848, 6564, 1262, -9198, 9498, 8323, -5948, -7980, -6298, -4613, -8415, 3902, -6085, -5762, -1865, -5507, -629, 1185, -8489, 9111, 4552, -6870, -7667, 9246, -2899, -6324, 3394, -1693, 7102, -2804, 2431, -6018, -3040, 1838, -6275, 7250, 4467, -1172, -3402, -2639, 9186, -5956, 9942, -1056, 920, 4499, 4722, 5145, 6374, 965, -6754, -5954, -7159, -8792, -592, 9742, 3226, 7112, 9886, -791, -6891, -1558, -8666, -1221, -1569, 9763, 5797, -3095, -4465, -2492, -3933, 2167, -5017, 3317, 2000, -3240, 7046, 7380, -7529, -5461, 9675, 7216, 6497, -7090, -4762, -7817, -1185, -6989, 5322, -2078, -6534, 4946, 4539, -3524, -1407, -5771, 3454, -498, 6958, 9668, -7274, 5827, 8365, 227, 1250, -7215, -7192, -6662, -8873, -5675, 3682, 5839, 4889, -979, -6038, -4440, -2204, -8459, -7859, -8225, -65, -6384, 2583, -4800, 7809, 7086, -649, -7769, 3006, 7825, 4861, -7513, 2243, -1124, -2824, -7050, 9190, -370, 4972, -3707, 4849, 4062, 4566, -6167, -5830, 813, 3894, -8803, -1201, 17, 9294, -5074, -1619, 3049, -5654, 7175, 337, 4768, -3243, 7362, 7795, 4065, -5667, -7974, 5794, 1921, -2962, 4224, -4722, -1292, -5181, -4783, -687, 6314, -9670, -6445, -4628, -7296, -9775, -6653, -4289, -5664, -8618, 7513, -8303, 8903, -7959, 6226, 7761, -5153, -8689, 4214, 8726, 4433, -7335, -8520, -4824, -5345, -4213, 1973, -1206, -1884, -7377, -9291, 6411, -2249, -3980, -378, -2797, -1792, 1326, -7940, 7714, -1208, -2310, -7884, -7587, -7139, 7118, -5907, 9891, -9626, -5565, 1513, 9109, -1552, -3374, -5237, 4210, -7869, -5863, -3020, -7326, -955, 6787, -4331, 9590, 2976, -7505, -8327, 6823, 4542, -7735, 1439, -4945, -5099, 1019, -6360, 8339, 5730, 9633, -4663, -4463, 8072, -2151, -9869, -8293, -1079, -2918, 8900, -52, 8589, -8435, -3512, 8561, 3185, -7125, -4340, -5939, 9778, 4854, 644, 6980, 1204, -4324, 900, -3221, 5475, -1310, 4982, -6655, 8699, -8077, 7249, -9382, 2957, -9326, -6737, -3568, -8997, 3192, -2681, -8393, -9449, 1336, -5794, -6913, 5307, 7194, -7975, 3315, 5132, 9697, 755, -596, 3159, 5436, -2942, 7082, 7615, -8243, 353, 9425, -9748, -8999, -3998, 6738, 1547, 1356, 3585, 1141, -8726, -7421, 8605, 204, 1281, 4299, 6610, -201, 1167, -8282, -409, 115, 8697, 5939, 3267, -6338, 7613, -1486, 7238, -6105, -2963, -9514, 3903, 1753, 6299, 344, 6361, 6976, 5060, -6665, 7531, -2792, 7279, 6905, -6869, -7306, -9700, -4547, -9538, -8186, 4827, 6233, -917, 4637, -9841, -688, 5762, -341, 3475, 4105, -1701, -7107, 9174, 3567, -1739, -8496, -7200, -8178, 6857, -2371, 6375, -4962, -2320, -4429, -217, -4176, -5536, -6616, 9797, -4385, -5102, 9340, -3965, 3967, -5682, -8351, 6425, 4888, -3581, 2549, 8964, 6640, 4956, -8131, 9756, -6403, -1684, 3753, -9893, -6639, -2080, -1274, -2136, 5925, 6443, 288, 4559, -2658, 7114, 1966, 3629, -2323, -6800, -600, 1543, 4556, 1125, -6415, -1356, 880, 2060, 9065, -2507, -5603, -2916, -1636, -3204, -8696, -6300, 3825, 6121, 8043, 326, -2098, -1080, 7726, -1957, 2463, 1866, -9237, 8595, -4174, -2071, 96, -6206, 3406, 5967, -5361, -3201, 8842, -534, -1107, 9336, 9230, -8093, 9813, -538, -3885, -8217, 5871, -5075, 2116, -1306, 7220, -8569, 7035, -9751, -418, -9586, 7149, -937, 1176, 5520, 5114, -3399, 397, 8894, 9846, 5583, -5159, 4936, -156, -3321, -1709, -744, 512, -7649, 7013, 8598, -4949, -5692, -366, -3208, 1424, 4396, 2576, -5742, 5462, 3351, 5832, -5534, -7949, -7361, -4490, -2891, -354, 4514, -606, -5842, -6724, -5703, 2758, -7134, 2053, 1525, -1402, -9371, 9971, 9949, -1771, -2826, 9839, 30, -6289, 932, -3532, 1434, -6386, 1670, 8472, -867, 6930, 6122, 2234, 8936, -8218, -7724, 3935, -1121, 6811, 6709, -1073, 185, -7310, 1231, -279, -5520, -1053, 6552, -3191, -3851, 2716, 1077, -6550, 5248, -5767, 1310, -3071, -6178, 6430, 9773, -3754, 3864, 7658, -6597, -16, -5241, 9491, -1763, 9641, 8616, 9254, -2923, 3473, -4094, 5552, -9640, 4381, -5873, 5542, 5629, 613, 9625, 6546, -4691, -1308, 9874, -8388, -604, -5369, 5302, -3361, -3008, -5380, 1697, 3327, 8865, -9658, 6345, -262, 1682, -8040, -6202, -4796, 4798, -4893, 2430, 4945, 3477, -5874, 3869, -7241, -8474, 8434, 9140, 6475, -371, -3690, 3181, 2470, 9657, -4989, -3213, -1135, -1730, 7527, -4956, -1987, -4896, -7932, -2047, -3405, -406, 4262, 9037, 4161, 2401, 5590, -1753, -4756, -3476, -4840, 6343, -8800, -8244, 3506, 4632, 4743, -2085, -6014, -5311, 9167, 3280, -3068, 2143, 1368, 9360, 1110, 1713, 7727, 9151, 2610, 2333, -5785, -3741, -6634, -5176, 2695, -7965, 4408, 4828, 7120, -7210, -1789, 342, -4721, 7499, -9523, -1050, -1787, 290, -5132, -2900, 2793, 48, 9292, 5992, 2407, 5643, -4584, -9630, -5797, -9601, -5334, 51, 8351, 7135, -9823, 0, 8879, 3191, 5622, -4656, -8583, -1887, -2179, 9046, 718, -1456, -2058, -2776, -9384, -2842, 5266, -1797, -3673, 8952, -8488, 1289, 2898, 5522, 7667, 6306, -6043, -1635, -7046, 3615, 1737, -104, 8858, -3143, -3770, 3378, 9663, 1589, -8082, -4861, 8631, 2848, -8463, 6210, -7622, -9136, -7805, -2875, 5581, -5912, 2836, -4773, -6136, 1734, -4794, -1575, -6442, 1556, -2092, 9600, 3879, -778, -2174, -3807, 2485, 5176, 8569, 5369, 2365, -8081, -7609, -4337, -5060, 8279, -6327, -8876, 633, -7565, 1124, 3898, 5391, -8366, 8309, -2376, 2466, -4740, 1575, 5059, 2316, 8499, -8075, -9822, -3861, 8389, 1183, -4593, -9803, 7784, 1226, 3294, 114, 7224, 3403, -9703, 7553, -992, 5295, 7256, -7930, 1876, -4446, 9870, 5708, 4057, -7387, 7732, -5560, 9200, -2454, -1395, -3864, -6792, 2381, 6919, -7287, -4546, 858, 1305, -1304, -9831, -9549, 4961, 5955, -9916, -5066, -8935, -4370, 2374, -7145, 7680, 2464, -7069, 6237, -5558, 2150, 7518, -3174, -2695, -2079, 2867, 8941, -7582, 7948, 4489, -7819, 8675, 6284, -4167, 2700, 6721, 7458, 1372, 1497, 4720, -2251, 6038, 8813, -5741, 3335, -9225, 8371, 7512, 3358, 6760, -1367, -3773, -17, -7298, -2931, -7269, 6965, 7451, 2917, 2698, -9063, -9111, 9019, 1417, -4291, 1403, 891, -6132, 8039, -2542, 5654, -6507, 8968, 5692, -2457, 6386, 9834, -5068, 9457, 8710, 4835, -9868, 2169, -6625, -2235, -4095, -656, 3005, 8912, 1979, 9937, -4992, -5327, 314, 5526, -8376, 5859, 4981, 4788, -5110, -7605, 348, -1117, 2780, 3799, -1328, -335, 4436, 4309, 1928, 7988, 4021, 7197, -833, 172, -9620, -3373, -8362, -3300, -1428, -5100, 2472, 2318, 4022, -9740, 6866, -8778, 1454, 5497, -4987, 1943, -485, -3291, 7014, -2276, 3560, 7402, 3015, -1365, 3941, 5238, 2260, 7136, -3758, 7882, 3401, 2196, -4350, -6419, -6270, 2415, 8381, -3232, 4154, 5271, -2753, 1080, -1611, 8985, -355, 8818, 927, -2402, -2411, 6862, -8851, -2778, 8560, 1246, -6818, 9252, 1527, -3752, -6351, 8655, 322, 8282, -5453, -7923, -4973, 2152, 7307, 1180, -5451, -7591, 8925, 1897, 2262, 2084, -413, -1551, -7593, 8864, -1800, -858, 5318, -312, 8185, -7254, -5063, 8269, 8258, -5350, -5004, -3368, -9085, 615, -1985, -2911, 6804, -2360, -9324, -6019, 918, 65, -95, -5597, 6756, -9192, -3755, 111, 3013, -7839, 5451, 6705, 8386, -5287, 3220, 8622, -8017, -8119, -7545, -7920, -1724, -6733, 5416, -750, 4752, 5447, -9501, 4679, 5312, -3566, 2357, 3922, -5608, -353, -2205, 5434, 9041, 6185, -8617, 2982, 4928, 6686, -4269, 5891, -5752, -8910, -4305, 1767, 2970, -9018, -7979, -9602, -5763, -4511, -9123, -1424, -5053, -1618, -4998, 2197, 2009, 4413, -3894, 302, -926, 8426, -4715, 3421, -8971, 7141, 9149, 12, 3467, 7958, 3213, -9982, -452, 7477, 9915, -3500, 6025, -9577, 1793, 7403, -3943, 9559, 6530, -3053, -2699, 7365, -9776, 1000, -9769, -5851, -5643, -9360, -5780, -4774, 8652, -4315, 5157, -6199, -339, 4777, 5620, -2690, 2225, -30, -8755, 9638, -3852, -8498, -7005, -4450, 7632, -7801, -7422, 2522, 955, -5472, 4708, -5460, -4752, -1714, -887, -9100, 3, -3588, -2617, -1518, 6683, -7586, -4113, -7182, -8746, -7737, 9070, 4174, -291, 8682, -4348, -5628, -7813, -7807, -132, -4675, 3871, 6447, -835, 1034, -7101, -8378, -1606, -7076, 6539, 6990, -940, -2295, -9556, -4451, -4595, -1376, -2152, 7124, 4483, -564, -9305, -2579, 230, 7612, 6408, 9569, 2632, -7251, 5203, -701, -1981, -3954, -206, 5268, 5212, 4748, -2025, -9376, 5043, 229, 7503, -4310, 2574, -6991, 3522, 4217, 9129, 6502, -5522, 3318, 7746, -7327, 7495, 5467, -2384, -3897, 9932, -9652, -7950, 6827, -2066, -1336, 1815, 3203, -8371, 9968, 4753, -237, 3772, -3385, -3067, 5065, 1332, 3730, -4753, 3395, -7494, -9614, -8929, -6203, -9205, -1522, 4209, 8744, -3569, 6423, -9094, -9895, -9175, -356, -2006, -7675, 6378, 5316, -4726, 8184, 7381, -3452, -5422, -6226, -3336, -8547, 3775, 2291, -4634, 8648, -2077, -2905, -7526, 4111, 5638, 192, 1015, 9181, -338, -4936, -6984, -7915, -2725, 6696, 1842, 3701, 789, 3368, 6331, -840, 2479, -1299, -8863, -3171, -8772, 6267, 8881, -2854, -1052, -1065, -8397, -9955, -9344, -6131, -2610, -8774, -4950, -5059, -5029, -8252, -292, -4273, 7334, -2701, 9607, 3597, 1989, -3935, -4637, -2037, -1870, 2805, -5212, 9712, 957, 2802, 447, -6305, 4893, 2270, 1726, -748, 8801, -4552, -6457, -9591, 5843, -1044, -4160, -3372, 8747, 9956, 4412, 7734, 7393, 4684, -5330, -5317, -8515, 8270, 2087, -99, -8551, -8495, -5119, 1893, -6516, 7870, 6698, 7779, -8197, 4978, 3608, -5890, 2267, 1953, 8023, -553, -9784, 6828, 782, 6585, 8301, -5417, -6331, -9811, -5157, 7412, -9103, -5930, 921, 3746, -5209, -7444, -2856, -8114, 8944, -2685, -1926, 5893, 7700, 7900, -4990, 4997, 7873, 3714, -422, -7108, 637, -3775, -3270, -3268, -3414, 593, -4255, 8257, -470, 7576, -5187, -794, 7573, 2421, 5742, 472, 5092, 6236, -9873, -2964, -6434, -8434, -8934, 399, -123, 3839, 2332, 4891, -2399, 6471, -6315, -86, -571, -3662, 2181, 9284, 7379, 5607, -1438, 9376, 3276, 246, 7016, -7483, 1967, 7828, -3078, 323, 6255, 9708, 8769, 9588, 8950, -9351, -8038, 5563, -9303, -4124, 3559, 1616, 9301, 9045, 3996, 4258, -5663, -6963, -8842, -6117, -4587, -1803, 3974, -6571, 362, 7002, -7037, -5837, -9463, -4590, 3409, 5474, -5887, -6702, 4347, 1994, 705, -7551, 45, -9970, 8391, 8806, -7308, -1543, -4010, -6847, -8138, 5252, -5399, 3789, -860, 9357, -6744, -7439, 6918, -9246, -3972, 8022, 1911, 125, 4401, 8158, -3272, -7918, 5733, -3072, 6419, 6396, 9131, -4555, -8089, -3134, 7341, -574, 3201, 2080, -2436, 6749, 2237, 4315, 7132, 5831, 9150, -5192, -1548, -8317, 5224, 6102, 4739, 5130, 3240, 6432, -900, -9462, 9279, -9917, 2450, 6006, 1551, 3389, 883, 4002, 4487, -7833, 3564, 7967, -4499, -7397, 144, 4423, 5928, 7693, 6057, 2484, -7860, 3642, 4119, 6780, -2994, -421, -5223, -9354, 7030, -6152, 5559, 9823, 1569, 282, -5658, 4605, 9406, 4604, -1974, 3031, -5436, -3647, -7235, -2324, 8198, 9727, -8615, -4055, -8821, -2643, 4660, -6426, 3371, -3987, -4349, 7284, -7282, 9339, -5374, 9857, 6595, 201, -7615, -5738, 8619, 491, 6148, 7722, 6996, -9292, -4205, -392, 1638, 3645, -8280, 8584, 7363, -8567, -8212, 7398, 1637, -5297, 3313, -9418, -2820, 5034, -2381, -1190, -5929, 6428, -2844, 6826, -3323, -4514, 3325, -7458, 6151, 4106, -5367, -1523, -2103, -1890, -2112, -8086, -5716, 5081, -6050, -8381, -6485, -7741, -1252, 464, -502, 3989, -2623, 4173, 6882, -1991, -349, 6520, -9178, 478, 5487, -5524, -8706, 4996, 3933, 3715, -3767, -3280, 8370, -4371, 5949, -5860, 9081, -517, 7901, -1537, -1555, 7462, -5051, 5723, 1474, 5229, 2008, 2551, -9632, 7987, 8002, -6611, -3113, 1377, 6545, -2386, -3446, -9446, -9809, 3573, -4241, 1116, -1960, -476, 1991, 1514, 684, -9685, 7902, 8615, -726, -8671, -7440, 9402, 4471, -6759, -9294, -4169, 3381, -9165, -7883, -7543, 7803, 9197, -765, -4772, -1072, 3643, 406, 871, -5731, 2561, -8825, 318, -4413, -6659, 3980, 8855, -2670, -4215, 8783, 9323, 7557, 8330, -630, -6561, 7212, -6573, 7523, -5279, -2514, 3992, 8084, -2598, 4370, -3089, 5181, 6220, 3828, -6968, 9602, -2038, 545, 5783, -9707, -9251, 3934, 4284, 3468, -6902, 9685, -2669, 2403, -7223, 4194, -757, -7916, 8814, 3420, -5900, -8947, -8986, 9077, 5606, 8357, 4033, -4601, -9328, 8571, 1428, 6337, -3776, -3066, 6459, -7611, 1824, -8389, -7677, 5206, 7793, -9414, 5200, -8057, 321, 1349, -1915, 6315, 815, 8701, 3053, 2696, 945, 1029, -9492, -8392, -318, 5442, 444, 8494, -7761, 2880, -6590, -9898, 9992, 2826, 7669, 4444, -5047, 988, 9783, 9300, 5512, 1537, -2741, -9649, -7343, -4280, 2709, -1269, -7973, 8482, -2910, 152, 9224, -2167, 1959, -4952, -6146, -1023, 592, -352, -7027, 9255, 3695, 251, 2592, -9790, 9409, -8959, -5651, -6273, -8195, 4425, -1663, -3737, -2339, -1913, 390, 3736, 7058, -7048, 3245, 343, -9750, 4676, 3108, -2828, 494, 8586, 7814, -7806, 534, -1491, -153, 5771, -9350, -7117, -9058, 2811, 4318, -1396, -8896, -3224, 976, -5802, -199, -2358, 8041, -4972, 1560, 6015, 1500, -4575, -8527, 8478, 3710, -8675, -8837, -5403, 3115, 5344, -1, 3145, -9005, 7893, 7624, -2461, -7852, -2544, -8646, -3461, 825, -4284, 7056, -8008, -5871, 2864, -9034, -3416, 9348, -8068, 6170, 7996, 4229, -2939, 5836, 5754, -706, -5735, -2781, -8491, -3924, -5197, 7865, 7650, 1307, 1546, 1273, 8579, -3443, -8449, -1617, 6526, 6758, 3486, -6500, 4892, -4328, 9216, 5146, -2727, 1508, -8987, 6011, 7163, -9949, -7882, -7362, 182, -5344, 1128, -3090, -4230, 3596, -6033, -8913, 2253, 4366, -5911, -7275, 2248, 3398, -6748, 2344, -2316, 5256, -8564, 7138, 9654, 3441, -838, -4339, 427, 5700, 9426, -9209, -1857, -2754, 1746, 6363, 7974, 5966, -96, -991, 5604, -1944, -8136, -4322, -5189, -5313, -2984, 8020, 8573, 128, 1706, -3537, -3326, 3472, 8224, -3856, -1019, -3603, -6189, 8625, -3784, 7679, 6239, 7396, 9134, -4801, -2795, 9560, -2333, -6755, 9543, 8541, 9873, 7420, -4079, -4143, 1391, -3138, 2904, 9154, 6812, -3012, -8585, -4236, -8852, 9903, 9898, 1278, -1573, 6480, 11, -734, 5010, 2499, 5940, 4947, 4458, -4428, 1672, -2297, -8385, -1273, 1929, -8912, 7702, -1629, 385, 1244, 2573, 4304, -1105, -4032, 2726, 1922, 4179, 429, 2870, 3298, -6700, -1932, 9597, 4942, -7105, -6988, -3681, 2936, 1041, -3545, 8313, -4418, 8118, -6559, 8250, 6838, 3940, -3576, -7376, 8146, -5355, -3617, 7476, 2102, 378, 7003, 9677, 8650, 5905, 3846, -5114, 9229, -7189, -7830, -6074, -6124, -7957, 1509, 7177, -1921, 931, 7745, 1175, -4755, -3314, 7535, 2795, -5526, 4424, 2752, -7779, 2077, -4879, 1886, -8161, -7360, -4608, -3463, -1174, 5857, -5766, 9122, 7604, -1187, -5336, -3817, -8258, -8653, -2917, 4265, 1120, -263, 2668, -8642, -7020, -7220, 1370, 3212, -2141, -6280, 1, 6177, 4507, 4847, -6796, -1589, -4734, 1031, 4438, -345, -5563, -3013, 9808, -2265, -5037, -2217, -9910, -3853, -3921, -7083, -7127, 8234, 9603, 5346, -678, 8692, 3230, 1937, 8517, -8983, -3386, -7740, 1955, 3672, -1013, 5759, 3061, -5972, 6036, 3336, -2234, -3284, 628, 9529, 7254, 4939, 9687, 2521, 7507, 9472, 5933, 2688, 1146, -7531, -6892, -2340, 5349, 102, -303, -5449, 5985, -7633, -3022, -9606, -951, -3397, -1585, 8308, 3334, 7849, -2640, -2869, 6673, 4398, -5678, 5601, -7396, -1295, 6998, 2616, 3561, -5371, -29, 212, 1285, 1152, -6410, 8909, 673, 4825, -8509, 1856, 2483, 1306, 9629, 8915, 9470, -2144, 9248, -7958, 1944, 4685, 3234, -3614, 8860, -3330, 8714, -4017, 4212, -2277, -1690, -8600, 1094, 6367, -1429, -4617, -7856, 356, 6154, 8453, -9678, -67, -9241, -8762, 2743, 6988, 4094, -4157, -1503, -1492, 6481, 2992, 3824, 1205, 3851, -116, -7045, -8741, -4165, -3967, -1225, -9199, 7631, 2254, -3510, 6603, -1860, -8886, 8018, 8336, -968, 6605, 8474, 8251, 4122, 6963, 8617, -9370, -9860, 3311, -4334, -21, 1387, -43, 9866, -8417, 5454, 6407, 6864, 2645, -2321, -4392, -446, 3901, 4576, -4480, -2218, 1126, -1867, 6136, -2270, 7315, -1534, -1115, -8810, 7584, 6519, 3774, 3760, 1823, 725, 7448, -3780, 1142, -2126, 7327, -4407, 4015, -3311, 3337, 5178, -4459, -5508, -383, -2992, -2237, -8984, 1762, -4077, -6532, 1712, -440, -1672, -4623, -350, -1574, -5160, 2718, 2448, 4125, 1558, 3377, -7451, -2904, 8812, -1940, 1907, -5985, 560, -9929, 1043, 1864, 6754, -646, -8102, -1467, 3545, -494, -5856, -7827, 7638, 7234, 3232, 3300, -2760, -4312, -786, 4463, 2005, -6392, -5177, -1478, -369, 6201, -1245, -8985, 6778, -6437, -4364, -854, -3044, 7972, 3557, -2645, 3647, 3456, -8900, 8766, -9594, -6306, -2455, 3921, 5262, 9097, 4600, 3447, -7787, -6286, -2318, 9550, 7134, 9679, -5211, -4977, 8522, 253, -7794, 3047, 6979, 8804, -9310, 1675, -1036, -1054, 8034, 5555, 8751, 7418, -8016, 6938, 3225, 39, -6832, 3735, 6957, -5866, -7146, 7447, 5382, -1371, -6494, 9883, 9182, -641, -6002, -5246, -1999, 8114, 751, 9589, -3826, 6750, 9126, -1152, -2866, 8316, 3182, 7050, -1791, 9312, 1647, 9620, -3664, 2618, -267, 3624, -692, 4348, 743, 2553, 5635, 4538, -8832, -9392, -2029, -9664, -4360, -8476, 3493, -7868, 8093, 9795, -9699, 9059, -6789, -8203, 8566, -6925, -134, -8333, 4511, -2549, 7670, -4757, -4369, -7710, -6166, 5155, -6073, 4592, 9351, 5865, -5952, 3721, -7871, -8505, 9521, 5538, -151, -2693, -6452, -9673, -9203, 2807, 1843, -1370, -1529, 847, -3605, -4408, 2361, -8053, -7429, -8336, -3389, 3833, -4320, 7657, -6786, -8699, -7000, -4114, -6214, 487, -9760, 5390, 8723, 8491, -4766, -3844, -1242, 9492, -2397, -6793, -5274, -665, 1857, 5261, 4460, -6544, 8856, -9083, 8626, -9381, -1901, 3129, 3680, -1431, 8265, -4558, -3823, -1021, -4852, -3285, -1876, -6982, -9915, -9311, 4336, 9840, 78, -283, -2652, 7318, -699, 6234, -4264, 9720, -2765, 1906, 2647, 2106, -5306, -8312, -2443, -4576, 9420, 4920, -8324, -6715, 9000, -9283, 3067, -6241, -3406, 9218, -1042, -2938, 9421, 9514, 9716, -4961, 1412, -6348, 9940, -8691, 4342, 6783, 4459, -2183, -7993, -8176, 3374, -6990, -9829, 3466, 6118, 8021, 3837, 2550, -6922, -5293, 7293, -8446, 6397, -1966, 7189, 6230, -2483, 4501, 281, -400, 7158, 9581, -3121, 4385, 6560, 7683, -2458, 5826, 7689, -7489, -2290, 6116, 7377, 5441, -7477, 3885, -8430, 1877, -8543, 6483, 9096, 237, 1727, -25, -6999, 7275, 479, 8016, -7383, -6742, -5385, 8333, -9945, -3456, -2063, 5786, 1050, 905, -6920, 8530, 2174, -251, -8529, 1468, 6669, -5933, -9250, 8939, 2389, 2648, -4223, -3968, -7554, 3895, -426, 8506, -8562, 5764, 2704, -1334, 5021, -3866, -561, -8979, 1752, -6469, -1967, 7080, -6251, 7360, -1949, -1934, -3832, 8117, 2674, -7773, -8801, -5624, 4907, -9964, 8168, -6040, -4686, -7559, 2620, -4476, -81, -5217, 7930, -4119, 3912, 6195, 9776, -2958, -462, -3686, -7462, 9247, -3069, 9157, -2111, -8464, -9724, 4558, 105, 6001, 367, -92, 3925, 72, 6265, -9639, 2580, -4798, -4053, -4543, 1912, 6163, -3678, 9321, -9730, 5283, 1610, 7259, -9288, 2158, -4244, -2450, -4510, -1305, -2329, -9544, 284, 631, 8554, -8213, -2895, -3130, 7484, 790, 86, -5946, 816, 3093, -1278, -4182, -3448, 1147, -804, 1216, -1497, -5514, -7024, 9152, 36, -465, -6648, -3144, 6528, -1298, -4537, -2013, -4788, 6019, -9339, 2544, -7788, -5995, -4219, -999, 236, 8994, 826, 5535, -1323, 4390, 8902, -2677, 594, 6372, 241, -5537, 33, 4872, 4881, -5927, -792, -825, -3433, 7574, 329, -6771, 6330, -2089, -9285, 9973, -7207, 6604, 2134, -5729, -7668, 2510, 3029, -4341, -1514, 1076, 1711, -1319, 2335, 1699, 5220, -8698, 5879, -4040, -2361, -4871, 6829, -5484, 3836, -3501, 7467, 1580, -4177, 8823, 6387, 8811, 4629, -853, -124, 2884, -3206, -3182, -3671, -2989, 1885, 8480, 7101, -9006, -4313, 3341, 2312, -363, -7662, 8194, 4714, -2261, -1399, -8765, -4899, 5378, -4953, 1581, -3166, 7807, 1506, 27, 7556, 8220, 7926, -9911, 2033, 861, -1686, -9660, -9297, -2427, 2824, -9904, -3010, 5511, 904, -9553, 461, 7534, -1778, 8529, -8939, 4350, 6986, 1867, 6049, 4672, 3304, -6138, 9868, 7609, -6015, 5363, -2072, 4671, 7079, -697, 9682, -9081, 7903, 2967, -3140, 4967, -1024, 1209, -782, -9914, -6624, 452, 4940, 6350, -1374, -6947, -8625, 1557, 3405, 3411, 6073, 1245, 5190, -6438, 9408, 3033, -8150, 5975, -6401, 3270, -2128, 2286, -1886, -2343, -6969, 887, -4203, -5140, 915, -4402, 2761, 2766, 2827, 9941, 4932, -4554, -6843, 5057, -6355, 6565, 6834, -2396, -9520, -1443, 5253, -4887, 7247, 8750, -9300, 646, -4488, 2879, 4735, -8657, -1468, -1752, -6549, -4883, -4035, 7847, -148, 747, -2948, -7725, -3782, -8776, 818, 4067, -1594, -8105, 4182, 9319, -9920, 8183, 5553, 2557, -964, -2847, -628, -8958, -4869, -5618, 6449, -2172, -1933, 7598, 4043, 1108, -8823, -7919, 6718, -9680, 9505, 817, 4648, 7817, 3353, 1700, -5519, -2118, -8703, -9623, 6487, -8428, 7152, 277, 804, -7247, -3337, -7727, -1683, -6034, -6898, -8731, -6301, -6091, 3889, -6959, -3075, 6126, -8967, 1771, -1576, 6994, 3765, -1919, 2477, -7143, -5517, -7588, 736, 9297, 4237, -4761, 9138, 5015, 2132, 4609, 9651, -5899, -5982, -5046, -9253, -729, -7457, -503, -4386, -3198, 1612, -9753, 3949, 3216, -2230, 9593, -5257, -4979, 7740, 3183, -2410, 4625, 7923, -9720, -1018, -73, -6460, -8905, 2133, -3916, 4204, -6706, -4376, 3882, 2933, 840, 2413, -4088, -3636, 5727, 469, 4785, 576, -5464, 6712, -2347, 2955, -5239, 2612, 9860, 6145, 9424, -6422, -7225, 7304, 4494, 9035, -6314, -5656, 5693, -253, 8967, -2475, -163, 8706, -5604, 6228, -1108, 4498, -8241, -2679, -2441, 3478, -8978, 8065, -8879, 9908, 6211, 9894, 5943, -5655, -6031, -5079, 181, 7042, -415, -4325, -513, -5740, 6583, 3496, -6636, -8735, -3521, 9124, -4467, -1873, -1542, -5753, 4018, -9530, 6631, -5337, -3834, 3638, 7242, 232, -7600, -3891, 579, -1293, 4652, 2555, -9943, 1635, 2408, -2012, -6046, -5304, 3542, -6096, 4705, 3373, -4227, -8927, -2239, 7915, 5036, -4532, -783, 7473, 9239, -6109, 7104, 1365, -439, 5394, 4011, 4699, -7167, -9, -4106, -290, 6455, -910, 6194, -7056, 7156, -3883, 6602, -7847, -5546, -2232, 9566, -6894, -788, -5791, 8841, -5634, -3155, -3915, -5284, -3829, -2016, -9561, -7340, 1345, -9990, 207, -9615, -4492, -8709, 6208, 4911, 9329, -9410, -5288, 7546, 451, 1618, -1762, 4120, -9383, 9554, -4606, -7829, -8571, -8335, -8763, 856, 5049, 3448, 7351, 9307, -9158, 1972, 5254, -681, -1480, -5689, -3952, 5173, 6364, 8681, 2959, 92, -7353, -8146, 4677, -5950, -6409, -2752, 6476, 6183, -2009, -6252, 1743, 2865, 967, -929, 1283, 776, 2177, -8188, 7057, -6865, -8760, 4180, 9422, -839, 1780, 8932, -817, -5376, -7730, -8919, 6819, 7178, -1368, 9304, -3048, 1978, 7241, 9690, -8118, 339, 5219, 5116, -1883, -8309, 4524, 6858, -9883, 6144, -6918, 6608, -3591, 1384, -9596, -6482, -4872, 3845, -111, -1880, 8136, -6839, -6001, -1735, 6134, -8918, 2652, -5922, 6534, -5055, 5421, -8467, -7283, 2753, 4756, -1239, 7842, -463, 4935, 9064, 4715, -2593, 687, -5316, 4160, -4888, 5729, 412, -5390, 7701, -5722, -1090, 1139, -4362, -8507, 5785, -5467, 769, 8966, 2872, 2913, 8284, 1623, 5202, -5183, 8367, -9172, 4114, 3704, 2671, -1736, -9078, -3634, 9583, 2786, 984, 1996, -9439, 4079, -6833, 7822, -5879, 3929, -7521, -745, 5907, 9242, 14, -4943, 2422, 6886, 8293, 7855, -6172, -387, 271, -7490, -8705, -2531, -1119, -5751, -6899, -2, 2427, 7263, -3688, -3440, -2862, -4848, 5830, 7699, 4387, -9866, -259, -7527, -6632, -5150, 6867, -1410, 5492, 1850, -6449, 107, 2341, -9179, -6747, 1337, 4535, 3600, 8679, 5279, 7890, 1398, -2115, 6355, -6411, -4565, 2138, 1832, -3895, 6816, -7639, 2894, 5085, -9379, 6562, -8678, 948, -9479, 6018, 3423, 7983, -5614, -1160, 2153, -3586, -8594, 8930, -140, 9345, 1018, 2290, 4399, -6092, -327, -6253, 8957, 8980, 6238, 2411, -5014, -857, 6848, -8078, 8054, -2135, 605, 5763, 1280, 4781, -6863, -1625, 7401, 3247, -3105, -2599, 2636, -4234, 6373, 1515, 8083, 23, -1852, 9118, 6512, 1169, 2851, -5010, -565, -1200, 61, 620, -9343, -4741, 8602, 7504, -3366, 1070, 9745, -4666, 6059, 710, -8779, -3413, -6030, -1840, 8948, -5750, -4187, 2710, 2263, -127, -4519, -6161, 853, 741, -9252, 8663, 391, -3631, -2541, -6269, -4769, 7869, 5019, 896, 4565, -859, -7302, -7756, -3207, 9108, -4616, -6951, 2972, 143, 4885, 8275, -5609, 2642, -4128, -676, 3849, -2050, 4747, -6615, -5061, 8402, 6358, 4914, 9617, 5657, -2533, 6739, 4963, -9985, 7257, -6139, -5095, 2338, 1568, 859, 7028, -416, -7632, -1517, -8004, -4813, 6914, 8037, -2512, -5671, -9992, -7825, -9499, -828, -7947, -8839, -7163, -3332, 7000, -3704, 9861, 4534, -9124, -7367, 9562, 5995, 8439, 5031, 2051, 8142, 82, 4571, -80, -8701, 4012, 3038, -1353, 1225, 6735, 1181, -6812, -8067, -6602, 2221, 1259, 7743, 8340, 3007, 6404, 3369, -2834, -9245, -9834, -6137, 9645, -1717, 3085, -8391, 7245, -5410, 9592, -3001, 5188, -8953, -3790, -4090, -610, 8509, 702, 7885, 788, -6868, -6953, -4495, -7926, 4248, 8535, -314, -6511, -5501, -6749, 892, -7911, 2602, -360, -7417, 1410, 58, 2001, -7517, -8508, -4216, 5104, 2184, 4115, 6371, -8616, -4738, -6768, 538, 5599, -5326, -6582, 3289, -5219, -9798, 2806, 5521, 4649, 762, 1005, -4516, 9189, 6954, -277, 7892, -4164, -1495, -1793, 5775, -2470, -7988, -2767, -7717, -8711, -7528, 943, 3916, -2451, -2395, -8742, -3992, -8963, -4657, -2874, -252, -4654, 2362, -2979, 8558, 7775, -6285, -6631, 6887, 9913, 4491, 234, -1020, -362, 8226, 166, -3677, 2849, 298, 2204, 9165, -5840, 7087, -6156, 1648, 3628, 9979, -60, -2707, -1049, 1038, 179, 1555, -4855, -4661, -6730, -7044, -1086, 4249, 1416, 2268, -7906, -4063, -9223, 8259, -4231, -8332, -707, -771, 8690, 7980, 7909, -5335, -3194, 9306, 5789, 155, 6615, -3888, -2638, 8756, 9558, 7981, 3063, -6237, 5108, 2029, 6531, -3871, 4486, -1183, 7430, -8367, 297, -4777, 2340, -7836, -6718, -2558, -9894, 6854, 3412, -7514, 6277, 6341, -7846, 349, 1148, 3460, -7152, 1314, 4582, -7311, 1021, -2592, 3551, -3436, -258, -923, -7054, -39, -2216, -1081, -9638, 2210, 1008, -1682, 516, 5026, 5289, -3340, 3936, 9401, -1176, -1063, -5917, -8561, 9806, -9023, 8372, -952, -8537, -6291, 7045, 1103, 1134, -5023, 252, 2271, -8753, 8785, -2311, 9733, 7410, -1417, -5221, -7290, 445, 1812, 5872, -7682, -9636, 1639, -9159, 5659, -5607, 8294, -9899, 4883, -8898, 1004, -8737, 5124, -2822, 1826, 7094, 9107, -8843, -1533, -5498, 9365, -4274, 8574, 2141, 5917, 6540, 5375, -988, -6042, 9895, -2490, -4975, -9902, -4642, 2091, -3659, 3050, -5576, -3199, -3424, 4667, 864, -3394, -3481, -8308, -2236, -5377, -2116, 7929, 2364, -7066, 6093, -4553, 5193, -9147, -4065, 7273, -297, 8458, 2900, 5972, -4668, -580, 2837, 3109, 5577, 4979, 1748, -8553, 4100, 656, -5531, 186, 5122, -2330, 8550, -9074, 6190, -6560, 1661, -1332, 648, 669, 1242, 5376, 3100, 2977, -7508, -709, -2818, -6695, 4061, 3853, 8292, -14, -320, 2566, -429, 5558, 9373, -1773, -8148, 6885, 1342, 9730, -3730, 2146, -3480, 4587, 1393, -4711, -9651, -6791, -8229, 1984, 3732, 5825, 4626, 5926, -8738, 6842, -6103, 6901, 49, 8199, -1818, -3768, 9691, -6707, -6067, 6324, 44, -8337, 8742, -9150, -3865, -3499, 9656, 3437, 3408, -2099, 3237, -4974, 6774, -480, -5533, 9466, -4875, -2902, 431, 6691, 9088, -4838, 5952, -4304, 2649, -6888, -8059, 3819, -7925, -8911, -6609, -1905, -3710, 7944, 690, 7966, -2159, -5987, 5504, -1532, -6619, 2250, 7668, 6939, 1212, 4596, 8463, -4633, 1980, -396, -5175, 301, -9850, -6501, 306, 9951, -5198, 5272, 9171, 162, 1318, 340, -9897, -8314, 8350, 9734, 9718, 2589, 8300, 2637, -563, -2600, 2909, 221, -3152, -5589, 7434, 4642, 654, 3068, -8152, 4665, 9762, -5967, 3286, 6461, 5393, 5782, 4054, 5503, -9182, -9214, -4107, 9030, 6232, -3353, -6579, -9569, 4310, 1051, 5198, 9965, 8070, 4624, -5673, 5210, -1380, 5886, -9333, -5438, -7406, 1346, -9587, -986, 4476, -8722, 2348, -7246, 2384, 2474, 75, -9891, -48, 5231, -4615, 7794, 8366, -8893, -8442, 7414, -6328, 4741, -2540, 3252, -3642, -6408, 659, 5873, -168, 7063, 3402, -1965, -4671, -3329, -648, 5813, -2858, 5371, 3527, -2946, 7682, -1487, 5358, 5572, -7964, 4373, 3079, -2903, 3432, -3112, -2665, -1581, -9495, -2928, -373, -7697, 7460, -2194, -5745, 4244, 8217, 7788, -5669, -6383, 9943, 5117, 2995, 7303, -108, -266, -3283, 694, -540, -8045, -7133, 8211, -8224, 56, 1740, -1936, 2987, -1381, 6771, -4667, -7057, -5503, 3328, -8725, -8177, 3379, -2612, -2284, 5413, 7717, 2643, 4375, -9531, 7437, -2949, -4477, 8253, -4394, 9238, -7154, -4321, -5868, 2665, -3879, -7838, -6234, -6183, 3404, 4867, 4452, 4999, 8504, 6264, 6303, -9378, 8673, -4996, -1596, 9924, -2254, 1023, -7363, -9404, 3256, 1312, 5410, 50, 9332, 2869, 29, 2584, 657, -7610, 8721, 8421, -4355, 7978, 2111, 6272, 6071, -4380, 5201, -2196, 6010, -2415, -6973, 5591, 1217, 2209, 1933, -2848, 2932, -4270, 1492, -1339, -1331, 6427, 6381, 6114, 3689, -1545, 2594, -3531, -7039, -6686, 8443, -1103, 947, -2648, 1484, 434, -2885, 3435, 6182, -716, 2945, -6980, 8190, -5400, 6391, -6391, -7184, 7441, -4248, 6490, -7885, -1345, -9070, 4786, 8408, 4191, 4843, -4104, 7026, -1645, 6515, 530, -191, 6174, 3965, 1519, -4125, 6989, -3230, -3033, 3579, 1834, 9263, 1253, 319, 732, 6799, 5505, 7406, -4702, 9814, -9578, 1765, -7203, 6951, -4544, -9936, -1116, 2345, -2601, 1702, 3791, -9465, 1359, -7746, 2468, 9488, 7956, 9489, 345, 3630, 4618, -3305, 9693, 9259, -8170, 2368, -2181, -3615, 4702, 8559, -3932, -4366, 1570, 4516, -2121, 7810, -8033, 9948, -3828, 8869, 7475, 3292, -8729, -7935, 5746, -8453, 286, 4909, -2865, 6248, -4406, -8437, 293, 8010, -6116, 4186, 210, -5072, 5652, 7992, -5697, 5282, 7671, -7867, 402, -7392, 2155, 6101, 4707, 9295, -655, 359, 4704, -5007, 5974, 6405, 4047, 7072, -1731, 2176, 5603, 4363, -1539, 4693, -8421, -5926, 1760, 4610, -9867, 5707, -2635, 4384, -4268, 2520, -2868, 6040, -8270, 2773, 5753, -6053, -9739, -9144, -6339, 9110, -779, 3808, 4716, 5006, -232, 5808, -5040, 1668, -8945, 8826, -7204, 7313, 4837, 4213, -557, 9168, -4229, 1145, 1736, -9099, -6477, 5791, -2304, -2850, -9681, -6398, 5152, 9079, 2911, -9659, -9330, -578, -8614, 242, -5235, 6402, 7530, -724, -3908, 8298, -8610, 666, -2878, -6450, 1847, 7731, -8021, -5226, 239, -4582, 6852, 5527, 9826, -3396, 7841, -8494, 432, 8147, 3720, -3107, -9231, -3816, 922, 1825, -9204, -6936, 3683, 7601, -8637, 9028, 3077, -4279, 9330, -6556, 3027, -9301, -8159, -2416, -9848, -6846, 5141, -5848, -2407, 8144, 8461, -622, 1533, -149, -6517, -623, 6633, -4597, -3026, 501, 9269, -6036, 8490, -4185, -8046, -7488, 1388, 2804, -7570, 4519, -7982, 8540, 928, 4546, -9816, -6620, -1885, 8759, -1419, 4411, 4943, -931, 3271, -1409, -6680, 5420, 4683, -543, -4458, -1557, 8653, -8548, -2551, 3950, -2568, 9392, -4681, -845, -679, -9188, 1993, -3724, 9069, 3032, 2359, -5027, -9164, 4840, -2688, -2032, -2871, 8983, 4915, 597, 1187, 6498, -8924, -2863, -3975, -2839, 95, -5903, -9976, -4669, 9349, 2832, -6332, -4839, 527, -2731, -5774, -976, 1596, 4475, 750, -6649, 9378, -3552, -4246, 4068, -3960, -2498, 8201, -1894, 9468, 4790, 9384, 4977, 9135, 2012, 990, -3028, 9185, -1727, -1653, -4865, 4569, 4687, -3320, 5024, 2721, 5471, -8554, 9054, -4895, 3444, 6580, -7560, 5311, -1465, 5241, 4247, -1849, -632, -5418, -5613, -5386, 3037, 2823, 4361, 9667, -152, -1458, 9610, -6323, 9767, -1169, -1276, -5352, -3548, 681, -209, 6256, -3192, -419, -5633, 3875, 7424, 6366, 1236, -7380, -913, -9559, -1640, -8326, 5275, -2206, -5870, -5770, 2601, 4329, 3785, -8414, 4634, -6454, -427, 8359, 9810, -3684, 6797, 16, 9704, 1796, -2315, -6859, -2184, 2834, -3663, -3178, 1460, 6074, -6364, 4887, -3645, -2075, -6387, -1151, 5970, -3301, 9293, -4142, 6620, 1095, 9847, -5308, 328, -3060, 6692, 1040, 4937, -6064, 3857, -1114, 5784, -4051, 4808, 1429, 466, -4080, 2657, 5575, 2787, -8884, 6336, -4405, 1561, 8255, -3218, -4101, -9584, -5020, -3313, 9198, 4266, 2628, 1298, 3834, -4828, -5902, -9321, 4520, -6186, 6726, 9978, -5494, 7155, 4673, -1756, 3872, 7337, -1601, -1348, 2372, 4873, 1322, -1536, 3562, -953, 1946, 9139, -7427, 3509, 7039, -9057, -7987, 5397, -9539, 9483, 8242, 6024, 9532, -1658, -2129, 5328, 9121, -2200, 9477, 2554, -4436, -6297, -4102, -7683, 954, 5673, -1059, -3390, -4789, 6920, 5348, 1407, -4237, 9288, -4507, -6024, -3114, 5336, -3504, -9793, -6512, 6207, 1930, 7586, 5137, 9025, -8818, 2467, -749, -2779, 4462, 9897, 9006, 3665, 7001, -9422, 5293, -3923, -4221, -9013, -5295, -1612, -7249, 2473, 5239, 8222, -9367, -972, -7420, -8253, -1943, 9337, -5588, -3518, 5437, -3, -2263, 4695, 382, 4234, -2303, 6438, -6523, -639, 8933, 9571, 9130, 3900, 6752, -2729, 1164, -7248, -6493, 2423, 4420, -6646, 6288, -3502, 6773, -7236, -3799, -1098, 7108, 2890, 5273, -1004, 4283, 6753, 1405, -1828, -6169, 8029, -1064, -4486, 7771, 9699, 4437, 9082, -1129, -5758, -3219, 746, 8280, -9582, -2022, -3404, 3463, 1341, 8789, 5323, 8361, -7222, -7234, -7854, -8974, -8850, -4484, -8461, -3649, -6703, 101, 523, 8363, 9904, 925, 7207, 6087, -5957, -9197, 665, 3095, -1373, 8755, 4098, 8188, 2085, 7164, -3064, 7264, 7413, -2719, 1970, 258, -9454, -3479, -7131, 9212, 2979, 8448, -8355, -5113, -3830, -2955, 6094, -7120, 4657, -2437, -9598, 5997, -5275, -1751, 5615, 9290, -834, 6997, -1102, 8352, 7151, -5749, 6215, 5744, 7545, 1899, 4086, 4639, 3556, -1389, -7331, -6056, 3766, -967, 9925, -3156, -2605, 1829, 5543, 3548, 6060, -8199, -6784, 7159, -5822, 2558, 8086, -1166, -1925, 1423, 1079, 4285, 8349, 7421, 3361, -2927, -3835, -5913, -6731, 2220, -3918, 5119, 6479, 4297, -7199, -6278, 3040, 8955, -7937, 9223, 9674, 1389, -2268, 4669, 4960, -9064, 4711, -8831, -3703, 1098, -6644, 2820, -6536, -1745, 1898, 2796, -9024, 2162, 9341, 7916, 8069, 6100, 3000, -7116, 6, 3380, 1224, 6084, 200, 1277, -2110, 5814, -8144, 2891, -3364, -6688, -9498, 8603, 7724, -9629, -2130, -8768, 9296, 4725, 1566, 3082, -3185, -6781, 764, 6655, -5196, 3648, 8917, -9115, -6673, -4153, -8673, 8231, -3607, -1928, -5443, 233, -4703, 8028, 5296, 154, 6681, 6970, 4103, -3242, 1064, 257, 6268, 3249, -8285, -7861, -9871, -5231, -38, -9543, -8502, 7628, 2235, 1584, 8863, 8025, 8418, -2971, -7485, 1908, 4269, 1461, 9271, 6484, 3078, 5205, 1538, -9156, -7430, -7372, -7346, 800, 5209, -826, -3691, 4818, -3262, -3867, 1483, -8205, -7258, -3507, 9403, -3919, 878, -8110, -1772, -4509, 1595, 6801, -4733, -8486, -5989, -1369, -5648, 1486, 7021, -9879, -8702, -3559, -2286, -310, 8824, -3763, 8737, 7429, 3501, -8682, 3848, -3795, -270, -1045, 8511, -2023, -3847, 4631, -8854, 4383, -8456, -9127, 7355, 7490, 5213, 2211, 8597, 3099, -4685, -66, 97, -5360, 9119, -4964, 1489, -2307, -1833, -1951, -9948, -8538, 4479, 3519, 5755, -4635, -9759, -2248, -3282, -9690, -5112, -9656, 2929, 6843, 8095, -9036, 7856, -6358, -130, 8553, -3970, -3898, 2623, -1110, -2312, 5656, 9251, 4358, 5823, 5820, -3651, 2416, -4551, -146, 2812, 768, -5470, -3092, 4796, 6966, 5028, 6785, 4782, 3719, 5890, 8450, 9649, 9113, 5856, 6792, 106, 6685, -6333, -3841, 2025, 8937, 573, 917, -302, -424, -5657, -9941, 9935, -9618, 2920, -5169, 1721, -6044, -2134, 7314, -7680, 4451, 2763, 1195, 1573, -6058, 1964, 6960, 4063, 7827, -9675, -2800, -1968, 9744, -4620, -1202, -6654, -8027, 4235, -4056, -50, -4281, 556, -8504, 4531, -5048, 3508, -9425, 1158, -5960, 8341, -2425, 6586, 3999, 7736, -3620, -4421, -3874, 2390, -1591, 2505, -8909, -6926, -3239, -5765, -3991, -9824, -1226, -7736, 3285, -6072, -1770, -7010, -2746, -8713, -5676, -3009, 4613, -5092, -556, 396, -5173, 9974, -5885, 134, 9117, -7720, -7676, 9698, -7512, 338, 9518, 961, 4983, 4028, 2304, -872, -4704, 2785, 4485, -7573, -4473, 3684, -5724, -2342, -8732, 8868, 3481, 265, -7837, -6191, 4183, -2208, 2377, 9381, -1655, -8398, -3150, -9447, -6041, 1202, 9137, -5216, 26, 3963, -9764, -2547, -7797, 5400, 7536, -2485, 7592, -112, -5935, 6591, -6877, 5740, 5793, -814, -2044, -6143, -472, -9728, 5399, 8532, -9125, -1128, 2101, -566, 2985, -892, -9388, -9906, -6961, -8440, 4364, 6014, 8884, 6741, -2771, -5049, -7673, -3197, 797, 9946, -1449, 5691, 1968, -8, -954, 4023, -6722, -6247, 5305, -4713, -2619, -9167, -6089, 7796, 5757, -3726, -4110, 4545, -6208, -376, -3801, -5715, 4823, 4313, -1188, -2004, 8204, 958, -4854, -5419, -8586, 7352, -1528, 1013, -914, -9641, -1266, 423, -4260, 4041, -4697, 3705, -3289, -4932, -1300, -1662, 4482, -9695, 8317, 8036, -8433, -4396, 695, 1754, -5165, 9023, -700, -8221, -7425, 6702, -9653, 2799, 370, -9802, 2638, 170, 203, 1053, -3076, 6325, 9354, 9187, -3244, -4461, 2817, 8462, 546, -315, 7960, 4307, -3978, -2374, -8123, -5251, -3977, -1659, -3153, -9476, -9487, -1823, 7427, 581, -1229, 7062, -9184, 4614, -4401, -6099, 8260, -275, -72, -7161, -7768, -3944, -5773, 987, 7548, 4376, -9293, -9331, 7991, 3887, 9811, -8363, -2951, 7954, -4397, -7395, -2327, 6454, 392, -9366, -8534, -3210, 1678, -7656, -37, -3623, -6007, 4574, -5811, -9436, 8507, -9320, 3594, -3825, -4442, -1848, -8166, -1076, -9808, 5182, 6012, -3824, 1113, -4578, -8090, 5864, -3901, 8380, -1637, -3938, 1427, 3942, -9849, -8814, 4325, 7776, 6383, 7719, 8281, 141, 4036, -4024, -4897, 8896, -9139, 4252, 2269, 2664, -3034, 4944, -6059, 142, -4750, -2977, -1950, 1251, -2642, -1427, 2935, 7262, -619, -4746, 4813, -3154, 5485, -7771, 1367, -6778, -961, 964, 6394, -4265, -5045, -5721, 1578, -9733, 4049, 2500, 7455, -1561, -2309, -8174, -5880, 3041, 2764, -3527, 1924, 1382, -4391, 6395, -4933, 6981, 9655, -1286, 9020, 4810, 5029, 912, -9106, -500, -13, -7502, 810, 8026, -1538, 7395, -985, 455, -2424, 8078, -59, 3516, 6247, -9581, 5270, 2200, 2814, -4529, -4934, 7083, -9040, 2717, -3256, -7151, -3797, -5600, -9565, 8238, -5062, -8917, -7175, -2045, -762, 3896, -8306, 4607, 1360, -1660, -5845, 8240, -4084, 6104, 4280, -8235, -5118, 2690, 7092, -224, -6374, 1114, -7951, -3179, 3904, -7174, 7093, 1666, -2449, -5615, -4767, -1757, 6821, -216, 8969, 8182, -2986, -2983, 1704, -7647, -1812, -7969, 3888, 327, 46, -8750, 4890, 3297, 3520, 6764, 3984, -4257, 312, -9532, -6459, -3589, 373, -346, 8576, -7524, 5216, 1583, 2978, 1846, 7857, 4474, 7940, 6041, -5474, -8894, 2878, 6594, 7498, 1343, -3802, 6235, 7681, -1338, 7928, -5372, 6703, -1101, 2382, -7804, -1382, -525, -2269, 1248, 9535, -1440, 707, -2833, -6468, 3427, 6242, 2007, -8000, -3995, -71, 1773, -6079, 5291, 8230, 3417, -4923, 2803, 3768, 7431, -8160, 4045, 2004, -5373, -9000, -245, 5584, 9586, -4200, -6296, -1195, 5533, 3641, -7520, -5262, -9861, 7933, 368, -7169, 3639, 5088, 3787, -1479, -4583, -8780, 7319, -1087, -165, -832, -4646, -8259, 6441, -9684, 8009, -9756, 8024, -5904, -5435, 7251, -4649, 5777, -7499, -1096, 6660, -4779, -9380, -7602, 3763, 8780, 721, 9986, 4136, -5684, 4597, 3866, 8202, -1197, 7203, -3572, 9104, -5301, 5760, 2157, -8857, -3513, 9911, 1274, -2155, -1713, -5111, 1376, -6104, 7298, 7610, -6909, -5434, 5495, -6588, -4650, -1309, -7888, 6765, 4448, -3019, 3550, -7270, 9563, 3908, -6180, 9621, -1525, 8189, 6123, 9545, -3592, -110, -3246, 9478, 418, -4939, 6070, 333, 3310, -4212, -9440, 6762, 8032, 6421, 6601, 7979, 9487, -9472, 4949, 7578, 259, 9460, 5817, -6666, 8822, 6139, -8860, -5315, 5751, 2179, 9163, 1821, 5642, -6777, -2446, 5453, 9494, -4139, -4116, 8608, 3021, -1394, 7524, -6406, -3362, -2932, 8274, 1397, -2952, 453, 8640, -8073, -2970, 1020, 5269, -7636, 5076, -9276, 9458, 2462, 9634, -2149, -6862, -4610, -2545, 4588, -3672, 5195, 8582, -3196, 7694, 8847, 4918, 8771, -7424, -6235, 5472, 1381, -9278, 160, -2896, 4495, -5855, -2914, 3064, 5427, 8059, -728, 8659, -6443, -4673, 8153, 6579, 84, 9105, 7240, -9368, -2597, 3589, -2061, 9268, 3133, 5233, -7890, -3731, 1875, 9214, 7997, 3255, -1924, 3818, 738, -1205, 624, -5073, -9286, 711, -8288, 1716, 5134, 9977, 5027, 4190, -3430, 7673, 742, 8828, -1439, 996, -736, 7096, -1383, 1646, 6021, -1251, 7597, -2998, 903, -4659, -6740, 363, -6006, 1266, -9863, -4572, 5964, 539, -7423, 1544, -8454, -2524, 4410, -4748, 7866, -4614, -4687, 8794, 3671, -348, 3248, 7320, 1620, 5731, 8099, -4363, 7647, 8407, 2730, 619, 8429, -2940, -742, -3303, 8543, -3265, -8487, -5397, 6975, -6049, 4820, -8937, 8775, -5825, -5882, 4314, -3225, -8084, 1218, -7765, -1155, 4332, 7184, 9334, 8534, -7171, 1531, -1666, -5677, 5752, 1392, -8858, -1215, 6657, 661, -8472, 7767, 2609, -1011, 3206, 2547, -6887, 9572, 8263, -1904, -4235, 4628, 4369, -1711, -3575, 3269, 6313, -6735, -8796, -7342, -3083, -8733, 2830, -8338, 6616, 7205, 1308, -5846, -4586, -5670, 283, -7872, 4988, 3238, -192, 7004, -125, 1348, 3299, 4853, -4271, -2966, -8596, -143, 7047, -6593, 420, 8342, -8375, -5131, 5687, 1718, -7410, 7255, -4423, -8747, 9749, 4594, -5156, 6776, 3186, -405, -5577, -8828, 1488, -7115, -26, 9490, 9355, -3613, 7078, -5704, 8661, -3522, 7951, -1112, 6103, -4611, -5937, 5944, 873, 8949, 9475, -3184, -8518, -9999, -7209, -1271, 5530, 5515, 9574, -9757, 6005, 930, -9007, -2198, 495, -6405, 6947, 7130, 5774, 499, -8215, 5812, 4800, -154, 7738, 6514, -1470, -368, -9800, -9121, 8166, -442, -3492, 5863, 3048, 3503, -8609, -5359, -2738, 1157, 7555, -2495, -982, 3024, -6905, -4434, 919, -8716, 9519, 2257, -7686, 6542, -284, -4181, 1480, -5486, -785, -1872, -5264, 6433, 8154, 5207, -9585, -5996, 8667, -7750, 1958, -4857, -1642, 9032, 551, 1631, 2023, -2355, 1805, 1177, -6008, -2069, -7635, 4201, 2349, -7394, 3359, -2102, 7089, -8626, -2057, 2003, 4456, -3689, 482, 4771, 6179, -4030, 547, -856, -9805, -160, -2153, 8369, -7753, 8992, -4258, 4811, 4833, -1405, -4965, 9027, 4353, -7400, 2631, 601, -1544, -9820, 248, 563, -8845, -1219, -5441, 4092, 3431, -2671, -8058, -5455, -5610, 767, -5488, -1661, -971, 1418, -1650, -8237, -3025, 5457, -7810, 5326, -8915, -6576, 9398, 3057, -7939, -3469, -9737, 7219, 4151, 2686, -4479, -6025, 2687, -803, -2684, -3299, -3720, 1109, -2926, 1230, 1383, -5966, 9083, -9086, 3655, 4405, 8422, -1698, -3988, 7020, 57, -3334, -9255, 8310, 7470, 9344, 1738, 4305, -6396, 1995, -410, -3590, 8531, -6510, -9719, -6608, 5689, -5953, 9178, 5756, -9401, 5840, 1102, 3604, 3326, -1583, 2119, -1311, -4482, -7244, 1316, 9539, 477, -3749, -9107, -2015, 3483, -3160, -2197, 8959, 3998, -8484, -5707, 3918, -3018, -9470, 169, 6964, -8233, 7831, -7292, 8752, -3839, 4141, 600, -9987, 6903, -8786, -133, 5862, -2853, -5383, -8824, 3795, -3494, 3231, -2567, 187, 630, 6946, -975, -93, -3600, 7780, -6708, 9090, -4374, -5125, 6328, -2176, -7141, 8624, 6575, 4778, -1824, -6090, -862, 1914, 3137, 3210, 291, 7611, -818, -4793, 855, -8120, 3854, 1792, 2122, -3800, 4274, 485, 3281, -6343, 2030, 6878, -9655, -4630, 5779, 7392, 757, 3059, 1530, -6939, 6628, 8694, -9394, -7784, -6093, 3413, 4055, -443, 6630, 3489, 6911, -6508, 8988, -9926, 3876, -694, -9174, -9679, -3027, -5672, -9149, 7404, -3715, -3081, 7336, -1740, -2957, -7181, -3701, 7639, 1588, -3630, 5702, 5844, 1426, -3338, -7301, 9034, 3365, 8489, 9313, 1669, -597, 2588, 6747, -3959, -9503, -3371, 5476, -8925, 5661, 7439, -4414, -3945, 9103, 6063, -8846, -5968, -5820, 9465, -1910, 6507, -7616, 704, -2163, 7906, 7221, 8077, -7594, -3549, 7547, 4386, -6498, -4941, 2026, 1234, -9153, 1873, 6518, 8820, -1920, 9428, 9542, 7840, 2511, 9161, 6369, -2438, 1772, -2090, -2884, -3378, 4096, 5304, -4149, -4523, 9914, -693, -1131, -323, 9766, -3410, -87, -4485, 9837, -8859, 8347, -9263, -1255, -3753, 2442, 2457, -2412, -6976, -7178, -3955, 4533, -298, 8318, 3591, 5161, 1323, 7710, 6915, 5408, -1942, 9036, -9974, 1075, 8853, 745, 3793, 6048, 4341, 2058, -8627, 8761, -1862, 1879, 8609, -9511, 6877, -7589, 8139, -1388, 2405, 9632, 8942, 7027, 8081, 38, 9413, 1607, -7245, 6731, -7689, -631, 9737, 52, 7539, 8157, 9537, -1401, 1784, -6819, 6478, 7773, -9772, 2889, -1704, -993, 559, 3060, 4177, 8788, -1948, 9815, 7570, 1001, 1649, 422, 4738, 3524, -264, -5854, -8169, 360, -4041, 2456, -425, 3142, -654, -7032, -2113, 5685, -482, 8729, -4751, 4200, -5094, -4512, 313, 1640, -4918, 1974, -8808, 4774, -420, -1162, -3200, 5165, 6851, 6153, -3498, 3756, 2394, 6413, -2398, 3090, -2837, 1233, 6532, 3233, 1601, 2708, -5808, -5101, -5545, -5962, 1608, -6542, -8636, 8195, 1985, -5184, 441, 9474, -2132, -5782, -1075, -6147, -5199, -2972, 6818, 4955, -4166, 3124, 1166, 4357, -4781, 2956, 437, -1421, 2975, 8786, -9546, -3609, -4521, 1475, -4559, 6273, -4858, -4710, 2142, 3020, -6594, 9578, -2777, -2400, 8606, -6761, -118, -6115, -359, -8468, -802, 7479, -9068, -5803, -6527, 8387, 3490, 3892, -293, 9838, 1512, -4173, -7214, -2714, -9054, 9673, -6779, 6933, -1471, -6325, 599, -715, 5250, -6400, 5883, 786, -4097, -5065, 2757, -2349, -2035, -18, 3691, -9950, 2156, 7148, 4319, -2503, 6844, 4377, 5920, 1320, 1010, 9780, -1922, -4112, -981, 2666, -9634, 4633, 4503, 7375, -1834, -8996, 1791, -8597, -1668, -5240, -2843, -6641, 1101, -2150, -9317, 9222, -2554, -9272, 9368, 2493, -5590, 3355, 2739, 9143, 814, 6003, -7721, 9721, 3127, -4296, 1621, -8319, 2874, -9015, -8694, -6349, 3268, 6912, 5332, -6942, 3911, 6596, -9399, 2161, 4527, 7382, -2577, 7169, 805, 7090, 4522, -939, -6919, -2302, 8004, -5984, 2049, -5206, 9743, 7575, -8861, -6303, -7095, 2379, -7652, -6413, 6952, -3584, 8102, -5764, -7482, -2027, -3148, -5829, -142, -8531, -3351, -9900, 3320, -5466, -2722, -4347, -7539, 837, -4180, -3382, -481, 8698, 4733, 5875, -4737, 822, -4301, 3742, -6417, -9709, -2082, 5234, -9947, 2089, -3379, -9075, -5013, -3309, -7186, -6842, -2338, 5186, -119, 623, 9622, -533, 6644, 4641, -3120, -9931, -504, 6212, 6173, -3622, -6082, -6599, -587, -7403, 8590, 8337, 3946, 6281, 9180, 6606, -1964, -548, 2303, 8060, -7619, -9035, 9722, -1776, 2514, 7024, -5252, 5958, 4931, 2672, 2414, -4679, 1347, -5032, 3840, -1827, -5346, 5001, -1264, -4867, 6133, -3772, -158, -2326, -395, -7191, -1902, -3669, -8926, 7585, -2791, -3999, 2565, 7091, 270, -3298, -3849, -7094, 9775, 9969, 7551, 5588, 4355, 5298, -2663, 2043, 4952, 2452, -3422, 7317, -7475, -3862, -7583, -2602, -2428, -6538, -2657, 5452, -205, -4202, 6956, 1725, -1975, -261, 1505, -342, -4222, -2014, -8460, 5194, 5761, -4283, 9647, 7041, -2892, -5680, -3920, -3049, 3983, -764, 3537, 7643, 7266, -2620, 9363, 6993, 8708, -4004, 1009, -4901, -7999, -7448, 68, 7181, 4472, 1452, 8683, 6090, 8116, 1161, -3316, -5130, -7921, -4540, -3902, 882, 3993, -5965, -1400, -6813, -1046, 4765, -3287, -2109, 9887, -3727, 4155, -311, -7264, -6752, -2432, -7320, -7814, 2677, 1188, -1423, -1447, -8667, -6790, -7029, -8234, 2888, 3442, 130, -6845, 3883, -5631, 8273, -4209, 1378, -3619, 4130, -2849, 6599, 8484, 8802, -4469, 5927, 1687, -7596, -2279, 5063, 6835, 1408, -6539, -6165, 5819, 6661, -532, -9702, 3634, -5149, -8286, 369, -602, -3306, -1691, -9452, 929, -6903, 1301, 4394, -3052, 6917, 3170, -1955, 7852, -3214, -7617, 8730, -7581, -9627, -8907, 6898, 6309, -7170, 2742, 5915, 7922, -2733, -1372, -5620, 1390, -5339, 9770, 3295, 7787, -3892, -3408, -6675, 7290, 6625, 781, 3228, -6259, 9524, 7879, 1090, 6147, 4603, -5817, -9271, -7612, -6102, 8068, 1033, -6257, 3640, -5294, -711, 4449, 2998, 1977, 1054, -5088, 1149, 4731, -3746, -6207, 6557, -7089, -2569, 962, -2548, -8888, 8618, -367, 9012, 515, -2859, -3610, 4590, 8684, 2375, 7620, 5018, -4072, 2347, -3713, 6961, 7123, -2513, -1363, 2465, -5595, 6971, -568, 9779, -7188, 8845, -1253, 2131, -3216, -7642, -7065, 6814, -6872, 4875, 7705, -7442, -9430, -4151, -6672, 5473, -5109, 6068, 2503, 9670, 167, 8539, 8834, -836, 9015, -5586, -8180, 4056, 9520, -8872, -8849, 9552, -3472, 6679, 5389, -9839, -9010, -8458, -8954, 5069, 7500, -3937, 5954, -3051, -7843, 2281, -8171, 5929, 377, 7645, 6936, -3116, -6231, -9340, 3595, 2410, 6706, 4327, -2793, 9221, 1656, 714, -8201, 5919, -6037, -2872, 4734, 6645, 7542, 7107, -880, 8223, 1516, -4645, -9741, -4835, 1156, 2680, -3037, 1571, 1485, 2324, -5363, 8807, -9460, 1684, -2757, 8731, -3971, 2392, 2578, 2320, -1841, 4169, -8988, -5642, 489, 7627, 6871, 8995, -280, 6323, 2137, -7972, -585, -9995, 5438, 1643, 8435, 2519, -9779, -5702, 8501, 6026, 2502, 4039, 9361, -171, 1340, 4428, 5648, 3087, 7677, -9965, 5502, 3190, 8319, -7592, -9365, -5323, -9348, 7766, 7653, 7383, 3147, 8354, 2724, -663, 4322, 2154, -3555, -4967, 3202, -8002, 8110, 3083, 1651, -6075, -6739, -8405, -4039, 1816, 5894, 3010, 7957, -8190, -7896, -1866, 9598, 80, 2777, 3646, 3043, 2240, -412, -958, -2836, 561, -7638, 2255, 7549, -1620, -1361, 2202, -1012, -7334, 4268, -7763, 5150, 3074, 5100, -9642, 6714, -2170, -2191, -6436, -658, 7332, 7878, 1163, -6606, -551, -441, 8411, 9867, -1453, -4983, -6380, -3398, 497, 6472, -5163, 7819, -1127, -3377, -6218, -8560, -773, -2807, -9927, 5649, -7030, 1400, -6440, 1576, 2570, 8208, 3474, -3670, -2405, -4086, -523, 6181, -2504, -2018, 1975, -2048, -6194, 5042, 2922, 9642, 9714, 7622, -6346, 3688, 2065, 5912, -1749, -2335, -4959, 1464, 8523, 3167, -3453, 4764, -545, 9386, 4917, -2750, -2056, 9565, 9177, 4509, 685, -6645, -866, 8468, 4544, -3281, 7235, 484, -4471, -6184, -6928, -8036, -9516, 3806, 1100, 2615, 6164, 2044, -559, -2083, 5370, -1034, -2379, -8576, 8674, -5843, 616, 6488, 7071, 5579, 3303, -6361, 1330, -4812, 2655, -8158, -6020, 8649, 9039, -2065, 9427, 1420, -5690, 3711, -7476, -8416, -4639, -9573, -7067, 9561, -1665, -8580, 289, 3541, 3618, 7469, 9906, -5783, -1025, 5415, 6085, 9, 1827, 9885, 6146, 583, -8014, 8632, 9746, 433, -6347, 9587, -636, 2017, -4677, -4592, 140, 2844, -8503, 4010, -562, 9608, -1519, 1633, 7905, 9818, 9191, 2352, -6823, 8934, 5650, 3452, -8279, 5003, 388, -7604, 1521, -207, 2317, -5024, 1351, -950, -9771, 5626, -4121, -8273, 151, -4526, -4725, -5881, -921, -7339, -121, -3297, -7256, -8651, 1137, -811, -912, -7013, -2557, -4763, -8099, 6767, 5969, 8221, 3424, -5161, 5463, -4308, -3934, -3612, 8528, -6530, -3650, 2670, -1813, -9315, -9089, 8042, 2096, 264, -1408, 8630, 6788, -5761, -137, -1970, -1230, 8728, 7310, -2127, -107, -7119, 5204, 41, -3846, -9662, 4371, 983, 2797, -5700, 9393, -2748, 8030, -9238, 4439, -89, -7474, -4503, -5265, 1144, -5164, -5799, -6344, -6725, 9648, -9060, 893, -5152, -8989, -9782, 3937, 553, -1796, -2202, 7505, -4908, -4759, 4082, -767, 9209, 7193, -2229, 2066, -6369, 4102, -6070, -5836, 9343, -7660, 6666, -4940, 3239, 1482, 110, 3291, -573, -8443, -4194, 3367, -6712, -6884, 8905, -9456, 7678, -1546, 6128, 2961, 2259, -4744, -6129, -1342, -5539, 8485, -6000, -8968, -7313, -5737, 9072, -1541, 5365, 2919, -6519, -6308, -4742, -8420, 4334, -1705, -8665, -6378, 4690, -8664, -7933, 607, 3810, -6416, 2968, -7263, -730, -6258, -1404, 1295, 3532, 886, -7910, -7989, 9120, 7133, 6881, -7411, 1496, 2506, 15, -8619, -1289, -8512, -739, 1106, 5012, -6924, -8410, -7936, 3119, -4152, -3716, 6968, -9137, -4644, -5530, -8632, 9056, -9938, 8719, 6659, 6791, -5106, -1149, 9220, -6083, -3164, -4111, -1333, 981, -7073, 9266, 8073, -3804, 8107, 4772, 7493, 1605, -7870, 5847, -995, 2366, -8390, 872, 5244, 588, 4143, -1016, 4359, -7084, 4417, -5093, -6514, 2309, -458, 3767, -1132, 4026, 1363, -1270, -1435, 1024, -601, 6509, -6441, -9518, 4393, -5744, -6249, -7601, 8205, 9963, -8558, 1920, 9228, -2967, -7063, -8239, 3969, -3534, 9664, 3815, -8480, -2621, -4833, -8222, 1056, -7791, -1095, -9042, 8206, -3234, 8838, 5187, -389, 2249, 3025, -4846, -4913, -7767, 7478, -1436, -8064, 3632, 9950, -1780, -7426, 5776, 4990, 5496, 88, 4202, 794, 9515, -3124, 7005, -1441, 7850, -210, 6977, -9206, -7510, -9424, 4064, -6664, 3215, 4029, -6153, -9668, 889, 9573, 5490, -2341, 4865, -7657, -2897, 2205, 1554, -7445, 8611, -9076, -1315, -4708, 7789, 7066, -9257, -8628, -849, -230, -8209, -8133, 2810, 632, 2402, 4776, -9135, -7522, 4742, -6080, -4075, 3699, -6005, 913, -3989, 1237, -4285, -3360, -8418, -5478, 9407, -1194, 3492, -6587, -5499, -987, 149, -2581, 2789, -347, 2661, -6009, 8438, -637, 4464, -3376, 428, 2109, -7707, 6080, 3930, -3696, 3906, 1804, -4009, 7372, 3716, 4367, 641, 1710, -9548, 3253, 3066, 450, -9475, -1416, -7385, 4263, 1189, -2846, 3455, 127, 9528, -4262, 4395, -5886, -8957, -1875, 3574, -7106, 2164, -3845, -5476, 5364, 7282, 2112, -6170, -7130, -3163, -117, -6290, -4435, 7227, 3754, 1069, -6121, -6281, 9385, -9953, 4718, 5580, 2222, 2302, 8090, 9160, 9076, 6959, -7239, 4075, -390, 2908, -2430, 4108, 8774, 9681, 8792, 6424, -3358, 5852, -2662, 7246, 5810, 8445, -6356, -5137, 843, -6506, -6581, 1690, -994, -1218, -4643, -816, -2596, -3149, -6480, 8635, -8790, -5463, 7409, 6192, -956, 2887, -8533, 1696, -7337, -7506, 2337, -7845, 6537, 9444, -6896, 863, 1129, -1181, -2717, 7070, 6079, -4683, -6985, 5050, -7938, 3549, 614, 5846, -5991, 2692, 8658, 3817, -9162, 6158, -5992, 5574, 2036, 7927, -2763, -5495, -1613, 1044, -7749, 7103, -3769, -6915, 6547, 2596, -3133, -9073, 3534, -4224, -9242, 4107, -6012, -9912, -6822, 8432, 6286, -6023, -1900, -1863, 1328, 2914, 1693, 7, -9050, 8356, -612, 2090, 5562, 7015, 8702, 4374, 9196, -8620, -4588, -2877, 3505, -6345, 1574, -1767, 7311, 2451, 8392, -8938, -1671, 7408, 386, -9777, -7113, 6813, 3576, 446, -5849, -9545, 3177, -4351, 4536, -2306, -1956, -5016, 8441, -9749, -8931, 8405, -5694, -7828, -4002, -7446, 9436, 8800, -9560, -3857, 4282, 7772, -9416, 8229, 8695, 3241, -8354, -936, 936, -3293, -7897, -6302, 6568, 8097, -1031, 5936, 6039, 7468, -8960, -3582, -6595, 8596, -257, -4825, 1664, 3700, 6527, -5082, 9179, -4238, -5810, 6587, 2928, 7428, -7620, -145, -8647, -1100, 1606, -2474, 3897, -8015, -2769, -3781, 1466, -5447, -7552, 6127, -5107, 4138, 1093, 1954, -5599, 5309, 7122, 8470, -620, 8568, -4717, -2705, -5864, -8549, 7195, 8414, 941, 7728, 5084, -8516, -9496, -8018, 9044, -2139, -4804, 3692, 3244, 3363, 126, -139, 7146, 4031, 1887, 7977, 8498, 2242, 9934, -3318, -9431, 2590, 9568, 8798, 1564, 5598, 6380, -44, 6588, 6091, 8646, 6674, -9415, -2845, 6945, 2199, 7117, 3575, -547, 1999, -5665, -928, -1454, -6601, 7805, -1501, 2702, -7243, -9968, 419, -2944, 5440, -1330, -7902, 2447, 5341, -4286, -1088, 2893, -5289, 5259, 507, -9117, 4066, -6814, -7068, -5884, 5038, -8575, -9876, -3528, -3203, 9719, -9056, -7072, -3455, -5969, -7970, -5713, 5489, 5841, -7379, 8691, -4099, 8662, 8082, 9635, 3338, -7217, -8156, -4253, -64, -703, -8400, 3382, 2256, -8302, -8891, 9506, -5155, 4246, 3617, 8355, -815, -2929, -1853, 9761, 4850, -8448, -1493, -9747, -2074, -8251, 2707, -9506, 6370, -2615, 380, -7723, 4052, 7708, 5728, -5835, -9387, 9595, -3694, -4297, -2207, 3197, 2367, -2488, -8676, -3503, 6847, -3554, -1386, 9960, -4903, -3719, 6285, -9697, 7391, -9727, 3622, 4523, -1958, -772, 504, -5305, -1455, -1061, -824, -2841, -6687, -5442, -5370, 5172, -9644, -184, -777, 9147, 622, -2925, -1816, 7440, 3878, 9738, 137, -2348, -9826, -7696, -4672, 6467, 2883, 953, -5098, -3269, -5566, -2107, 1122, -5662, -1670, 9580, -4670, -5947, 405, 2923, 3036, -1085, 7801, 7971, -615, 3296, -5768, -9767, 3694, 5858, 398, -2698, 5739, -1937, 1302, -9177, -1811, -9558, 4295, -3618, -5089, -2246, -4266, -7751, 5098, -8806, 9985, 3702, -9701, 7369, -8836, 1941, -7433, 5802, -9526, -1043, -6776, -5601, -9048, 3324, -435, 6648, 5479, -2336, -8980, 5882, -8511, 3931, 2585, -4916, 7621, -1845, -1015, -9489, 3518, 9453, -9946, 4595, 4468, -9277, -1984, 5906, -9017, -9171, -1990, 9043, -5299, 4921, 1288, -6981, -3735, 5614, 5458, -3941, -1961, -6211, 5509, -560, 1777, 3026, 604, -2471, -3462, -9624, 9276, 8425, -2686, -5091, -8267, 4841, -2403, 2393, 3543, 2697, 6807, -1009, -9265, -3711, -8450, 5798, -4003, 1219, 9961, -7008, 8487, -4802, -881, 6338, -3948, -385, -3142, -1506, -4930, 577, 3893, -8135, 9278, 3960, -6643, -8055, 4869, -7297, 703, 696, -6676, 7077, 6837, 8799, -4832, 3874, 4899, 2299, 8908, 3258, 5910, 7497, -5841, 4159, -299, -2538, -9799, -3654, -1265, -8761, 1371, 1017, -9674, -4071, -9765, 1059, -768, 5695, -507, 3959, -9731, 3750, -2506, 6420, -1516, 6295, -1104, 6225, -7250, -1477, -1734, -9244, -2019, -3903, 4406, 4308, 1603, 6124, 7394, -7190, -889, -3803, -5332, -9051, 680, -6589, -1496, -9885, -8606, 9769, 1092, -8921, 765, -100, 5624, -1070, -4197, 9849, 824, -990, 3116, 979, -8297, -2739, -9478, 9631, 1395, -1590, 9510, -8787, -1352, -5482, 5483, -1412, 6740, 4427, -7812, 2808, 9827, 7919, 977, 532, 8239, -704, 8384, 2277, 7851, 4789, -3997, -9359, 2532, -8933, -635, 4264, -7849, 4276, 1883, 1785, -5033, -1290, 138, -8276, 6067, 4513, -4105, -5331, -7148, 4561, -2173, 4254, 9353, -1498, -8311, 2487, -505, -8827, 5056, 5073, 1948, 9071, 2727, -238, -6101, 5387, -218, 2593, -4342, 3399, -5395, 6180, -6107, -8944, 8212, 6246, -8655, -1718, -8185, 798, -7895, 334, 4616, 6448, -321, 5251, 7782, -1712, 1859, 1778, -7238, 7883, -4806, -8183, 5901, 5510, -9710, -4295, 5249, 9584, 4575, 4829, 7567, 6500, 2495, 274, 7446, -1746, -3392, 3913, -8680, -633, -7001, -9934, -6583, -178, -7687, -4098, 3835, 1931, 2045, -2561, 5095, 2693, 7608, 7343, -2694, 9206, 4933, -4978, 4484, -3350, -9088, -7168, -7096, -289, -456, 8552, -9385, 6695, -4346, 4795, -4057, 1604, -8268, 9364, 2663, -1029, -9742, 9626, 7321, -6279, -4047, 679, -2040, 8216, 7153, -1248, 71, 6759, -3571, 663, -8034, -2274, -5757, -9975, -7300, 7023, -8479, 2715, -2473, 220, 1456, 6213, 470, 4567, -8065, -6557, -9369, 9232, -6299, 868, -6215, 8928, 9816, -3687, 5516, -1130, 2443, -1349, 2749, 3449, 3729, 3762, 146, -9935, 6736, 2198, 5669, 9087, 2305, 9882, 3747, -1260, -3409, 7861, 5965, 2536, -8724, 722, 173, 4053, -4771, 136, 3470, 3184, -9332, -8745, 3227, -7630, 7749, 2113, -6970, 3446, -9745, 4407, -570, -6635, 5035, -2445, 2843, -2775, 802, 6307, 1510, 9997, -1578, 5953, 296, -2614, 9399, 9004, -8128, -3315, 5125, 1470, 3662, 6584, -3676, -1150, -8573, 4481, 6191, -3317, 7976, 4170, 9114, -1992, -4201, -9552, -9567, 9955, 3150, 4700, -3709, 2011, -3939, -8010, 5431, 5951, 5564, 1459, -6112, 375, -2790, 7443, -4018, 3251, -9932, -2912, -2713, 9414, 924, 8735, -5646, -5936, -3838, -8001, 3755, 6722, -8798, 4132, -7469, -6063, -9988, 4958, -7081, -1600, 5064, 6790, -7015, 4740, -5548, -4890, -9788, 9676, -9533, -9216, 1548, 9335, -5580, 9285, 8431, 1014, 618, -3608, -9327, -1786, 2130, 8171, 2435, 435, 55, -3342, 5514, -7332, 8488, 2973, -2608, 1296, -1391, 6117, 1425, -1716, 4905, -5974, 8951, 7294, -5356, 3724, -5415, 8639, 2800, 376, 2571, -1868, 9003, 8765, 9305, 6978, -5691, 9455, 8454, 8991, -2256, -6027, 62, 2860, 4069, 1300, 1540, 7533, 3487, 6830, -2691, -9109, 3798, -6895, -7285, -3543, 7963, -6420, -1768, 9612, 7786, -5178, -9316, 8736, 1240, -2345, -1212, 540, -4388, -1156, 3113, -3359, 6022, -1994, -2154, 771, 9052, 4197, 8536, 9495, 3062, -2522, -2672, 7874, -9342, -5050, -4207, -4249, 4289, 636, -4378, 7191, 3923, -6175, 7215, 4447, -7578, 7662, 6326, -5195, 1421, -6071, -1457, 5718, 9287, -7374, -9851, -2873, -4247, 4973, -8521, -7031, -7491, -3788, -3354, 9405, -3220, -8598, 4147, -6621, -7390, 4152, 4845, -9386, -2055, 2399, 3939, 5111, 9576, 8473, 6446, -1550, 9541, 7288, -8012, 2104, -7809, -8650, -6389, 1081, 2120, 235, 7914, 8693, 8610, -2721, -4705, -1898, -4042, -9001, 458, 7568, -4912, -9143, -4083, 2295, 4492, 5996, 4870, -3884, 5215, -1335, 6984, -5407, -5266, 1986, -2720, 2525, 7277, -6723, 2013, 7061, 6925, 6513, -932, -2030, -6185, 589, -6966, -215, 8141, 3668, 3580, 1862, -3653, -6780, 502, 1663, 2863, -4638, 2118, 7715, 9650, 8718, -8387, -2803, -3986, 4934, 1770, -9504, -810, -3793, -4596, -2789, 7299, -8964, 5877, -537, -5302, -6467, 7354, 8548, 1463, -6317, -7449, -229, -1877, 5711, 4239, -1973, -6610, -1897, -8914, -2131, -365, -8707, 1794, 3623, -4527, -343, -8163, -2068, 8393, -2588, -5087, -4986, -1565, -7454, -7216, -7187, 1267, -5171, 8163, 640, 4562, 8, 6665, -7149, 8122, -7304, -841, -90, -5127, -7262, 9896, 1611, -590, -2325, -7172, 2526, 2770, 9921, 9272, -9628, -9997, -9778, 5425, -7532, -2692, 7142, 2215, 3985, -6816, 7606, 6876, 211, -9583 }, 
            //                    T = 2147483647, K = 1 });

            inputs.Add(new Duplicate3() { Input = new int[] { -1, -1 }, T = -1, K = 1 });


            foreach (Duplicate3 input in inputs)
            {
                result.AppendLine($"Near by Duplicate is {(this.ContainsNearbyAlmostDuplicate(input.Input, input.K, input.T) ? "":"not")} available for the given array : {string.Join(",",input.Input)}, K : {input.K}, T : {input.T}");
            }


            MessageBox.Show(result.ToString());


        }


        public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
        {
            if (nums.Length <= 1 || t < 0)
                return false;

            var bst = new SortedSet<long>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (i - k - 1 >= 0)
                {
                    bst.Remove(nums[i - k - 1]);
                }

                if (bst.GetViewBetween((long)nums[i] - t, (long)nums[i] + t).Any()) return true;
                bst.Add(nums[i]);
            }

            return false;

        }

        public class Duplicate3
        {
            public int[] Input;
            public int T;
            public int K;

        }

        private void btn_Maximum_Product_Subarray_Click(object sender, EventArgs e)
        {
            /*

                Given an integer array nums, find the contiguous subarray within an array (containing at least one number) which has the largest product.

                Example 1:

                Input: [2,3,-2,4]
                Output: 6
                Explanation: [2,3] has the largest product 6.
                Example 2:

                Input: [-2,0,-1]
                Output: 0
                Explanation: The result cannot be 2, because [-2,-1] is not a subarray.

                Time Complexity         : O(N)
                Space Complexity        : O(1)

            */

            List<int[]> inputs = new List<int[]>();
            inputs.Add(new int[] { 2,3,-2,4 });
            inputs.Add(new int[] { -2,0,-1 });
            inputs.Add(new int[] { -1 });
            inputs.Add(new int[] { -2, 3, -6 });
            StringBuilder result = new StringBuilder();



            foreach (int[] input in inputs)
            {
                result.AppendLine($"Maximum Product Subarray  is {this.MaxProduct(input)} for the given array : {string.Join(",", input)}");
            }


            MessageBox.Show(result.ToString());


        }

        public int MaxProduct(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            int max = nums[0];
            int min = nums[0];
            int result = max;
            int backup = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                backup = max;
                max = Math.Max(nums[i], Math.Max(max * nums[i], min * nums[i]));
                min = Math.Min(nums[i], Math.Min(backup * nums[i], min * nums[i]));
                result = Math.Max(result, max);
            }

            return result;
        }

        private void btn_Largest_Number_Click(object sender, EventArgs e)
        {

            /*
             
                Given a list of non negative integers, arrange them such that they form the largest number.

                Example 1:

                Input: [10,2]
                Output: "210"
                Example 2:

                Input: [3,30,34,5,9]
                Output: "9534330"
             
             */


            List<int[]> inputs = new List<int[]>();
            inputs.Add(new int[] {10, 2 });
            inputs.Add(new int[] { 3, 30, 34, 5, 9 });
            inputs.Add(new int[] { 0,0 });
            StringBuilder result = new StringBuilder();



            foreach (int[] input in inputs)
            {
                result.AppendLine($"Largest Number is {this.LargestNumber(input)} for the given array : {string.Join(",", input)}");
            }


            MessageBox.Show(result.ToString());

        }

        public string LargestNumber(int[] nums)
        {

            long temp = 0;
            string result = "0";

            if (nums == null || nums.Length == 0)
                return result;


            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (($"{nums[i]}{nums[j]}").CompareTo($"{nums[j]}{nums[i]}") < 0)
                        Swap(nums, i, j);

                }
            }

            result = string.Join("", nums);
            if (long.TryParse(result, out temp) && temp == 0)
                result = "0";


            return result;

        }

        private void btn_Subarray_Product_Less_Than_K_Click(object sender, EventArgs e)
        {
            /*
                Your are given an array of positive integers nums.

                Count and print the number of (contiguous) subarrays where the product of all the elements in the subarray is less than k.

                Example 1:
                Input: nums = [10, 5, 2, 6], k = 100
                Output: 8
                Explanation: The 8 subarrays that have product less than 100 are: [10], [5], [2], [6], [10, 5], [5, 2], [2, 6], [5, 2, 6].
                Note that [10, 5, 2] is not included as the product of 100 is not strictly less than k.
                Note:

                0 < nums.length <= 50000.
                0 < nums[i] < 1000.
                0 <= k < 10^6.

                Hint #1  
                For each j, let opt(j) be the smallest i so that nums[i] * nums[i+1] * ... * nums[j] is less than k. opt is an increasing function.
             
             */



            List<ArrayAndValue > inputs = new List<ArrayAndValue>();
            inputs.Add(new ArrayAndValue() { input = new int[] { 10, 5, 2, 6 }, find = 100 });
            inputs.Add(new ArrayAndValue() { input = new int[] { 1, 2, 3 }, find = 0 });
            inputs.Add(new ArrayAndValue() { input = new int[] { 1, 1, 1 }, find = 1 });
            


            StringBuilder result = new StringBuilder();
            foreach (var input in inputs)
            {
                result.Append($"Subarray Product Less Than K is  {this.NumSubarrayProductLessThanK(input.input, input.find)} for the given int array {string.Join(" ", input.input)} for given K {input.find}  \n");
            }

            MessageBox.Show(result.ToString());
        }

        public int NumSubarrayProductLessThanK(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0 || k <= 1)
                return 0;

            int result = 0;
            int product = 1;
            int j = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                product *= nums[i];
                for (; product >= k; j++)
                    product /= nums[j];
                result += 1 + (i - j);
            }

            return result;
        }

        private void btn_First_Missing_Positive_Click(object sender, EventArgs e)
        {
            /*
             
                Given an unsorted integer array, find the smallest missing positive integer.

                Example 1:

                Input: [1,2,0]
                Output: 3
                Example 2:

                Input: [3,4,-1,1]
                Output: 2
                Example 3:

                Input: [7,8,9,11,12]
                Output: 1
                Follow up:

                Your algorithm should run in O(n) time and uses constant extra space.

                Hint #1  
                Think about how you would solve the problem in non-constant space. Can you apply that logic to the existing space?
                Hint #2  
                We don't care about duplicates or non-positive integers
                Hint #3  
                Remember that O(2n) = O(n)

                Time Complexity     : O(N)
                Space Complexity    : non constanct time
            
             */

            List<int[]> inputs = new List<int[]>();
            inputs.Add(new int[] { 1, 2, 0 });
            inputs.Add(new int[] { 3, 4, -1, 1 });
            inputs.Add(new int[] { 7, 8, 9, 11, 12 });
            inputs.Add(new int[] { 1, 1 });
            inputs.Add(new int[] { 1, 0 });
            inputs.Add(new int[] { 1000, -1 });
            inputs.Add(new int[] { -1, -2 });
            inputs.Add(new int[] { 0, -1 });
            inputs.Add(new int[] { 0, 0 });
            inputs.Add(new int[] { });
            inputs.Add(new int[] { -1, -2 });


            StringBuilder result = new StringBuilder();



            foreach (int[] input in inputs)
            {
                result.AppendLine($"For the given array : {string.Join(",", input)} the First missing  positive number is {this.FirstMissingPositive(input)}");
            }


            MessageBox.Show(result.ToString());

        }

        public int FirstMissingPositive(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 1;

            int len = nums.Length;
            for (int i = 0; i < len; i++)
                if (nums[i] <= 0 || nums[i] > len)
                    nums[i] = len + 1;

            int j = 0;
            for (int i = 0; i < len; i++)
            {
                j = Math.Abs(nums[i]);
                if (j > len)
                    continue;
                if (nums[--j] > 0)
                    nums[j] *= -1;
            }


            for (int i = 0; i < len; i++)
            {
                if (nums[i] > 0)
                    return i + 1;
            }

            return len + 1;
        }

        private void btn_Combination_Sum_Click(object sender, EventArgs e)
        {
            /*
                    Given an array of distinct integers candidates and a target integer target, return a list of all unique combinations of candidates where the chosen numbers sum to target. You may return the combinations in any order.

                    The same number may be chosen from candidates an unlimited number of times. Two combinations are unique if the frequency of at least one of the chosen numbers is different.

 

                    Example 1:

                    Input: candidates = [2,3,6,7], target = 7
                    Output: [[2,2,3],[7]]
                    Explanation:
                    2 and 3 are candidates, and 2 + 2 + 3 = 7. Note that 2 can be used multiple times.
                    7 is a candidate, and 7 = 7.
                    These are the only two combinations.
                    Example 2:

                    Input: candidates = [2,3,5], target = 8
                    Output: [[2,2,2,2],[2,3,3],[3,5]]
                    Example 3:

                    Input: candidates = [2], target = 1
                    Output: []
                    Example 4:

                    Input: candidates = [1], target = 1
                    Output: [[1]]
                    Example 5:

                    Input: candidates = [1], target = 2
                    Output: [[1,1]]
 

                    Constraints:

                    1 <= candidates.length <= 30
                    1 <= candidates[i] <= 200
                    All elements of candidates are distinct.
                    1 <= target <= 500
             
                    Time Complexity     : Expoential
                    Space Complexity    : O(1) 
             */


            List<ArrayAndValue> inputs = new List<ArrayAndValue>();
            inputs.Add(new ArrayAndValue() { input = new int[] { 2, 3, 6, 7 }, find = 7 });
            inputs.Add(new ArrayAndValue() { input = new int[] { 2, 3, 5 }, find = 8 });
            inputs.Add(new ArrayAndValue() { input = new int[] { 2 }, find = 1 });
            inputs.Add(new ArrayAndValue() { input = new int[] { 1}, find = 1 });
            inputs.Add(new ArrayAndValue() { input = new int[] { 1}, find = 2 });
            


            StringBuilder result = new StringBuilder();
            foreach (var sip in inputs)
            {
                result.AppendLine($"Combination Sum  for the given int array {string.Join(" ", sip.input)} for given target {sip.find} is  \n");
                foreach (List<int> i in this.CombinationSum(sip.input, sip.find))
                    result.Append($"{string.Join(",",i)}");
                result.AppendLine();


            }

            MessageBox.Show(result.ToString());

        }


        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {

            List<IList<int>> result = new List<IList<int>>();
            List<int> list = new List<int>();
            GetSum(0, target, result, list, candidates);
            return result;

        }



        private void GetSum(int start, int target, List<IList<int>> result, List<int> list, int[] input)
        {            
            if (target < 0)
                return;


            if (target == 0)
                result.Add(new List<int>(list));


            for (int i = start ; i < input.Length; i++)
            {
                list.Add(input[i]);
                GetSum(i,target - input[i], result, list, input);
                list.RemoveAt(list.Count() - 1);
            }

        }

        private void btn_K_diff_Pairs_in_an_Array_Click(object sender, EventArgs e)
        {
            

            /*
                Given an array of integers nums and an integer k, return the number of unique k-diff pairs in the array.

                A k-diff pair is an integer pair (nums[i], nums[j]), where the following are true:

                0 <= i, j < nums.length
                i != j
                a <= b
                b - a == k
 

                Example 1:

                Input: nums = [3,1,4,1,5], k = 2
                Output: 2
                Explanation: There are two 2-diff pairs in the array, (1, 3) and (3, 5).
                Although we have two 1s in the input, we should only return the number of unique pairs.
                Example 2:

                Input: nums = [1,2,3,4,5], k = 1
                Output: 4
                Explanation: There are four 1-diff pairs in the array, (1, 2), (2, 3), (3, 4) and (4, 5).
                Example 3:

                Input: nums = [1,3,1,5,4], k = 0
                Output: 1
                Explanation: There is one 0-diff pair in the array, (1, 1).
                Example 4:

                Input: nums = [1,2,4,4,3,3,0,9,2,3], k = 3
                Output: 2
                Example 5:

                Input: nums = [-1,-2,-3], k = 1
                Output: 2
 

                Constraints:

                1 <= nums.length <= 104
                -107 <= nums[i] <= 107
                0 <= k <= 107



            */
            List<ArrayAndValue> inputs = new List<ArrayAndValue>();
            inputs.Add(new ArrayAndValue() { input = new int[] { 3, 1, 4, 1, 5 }, find = 2 });
            inputs.Add(new ArrayAndValue() { input = new int[] { 1, 2, 3, 4, 5 }, find = 1 });
            inputs.Add(new ArrayAndValue() { input = new int[] { 1, 3, 1, 5, 4 }, find = 0 });
            inputs.Add(new ArrayAndValue() { input = new int[] { 1, 2, 4, 4, 3, 3, 0, 9, 2, 3 }, find = 3 });
            inputs.Add(new ArrayAndValue() { input = new int[] { -1, -2, -3 }, find = 1 });



            StringBuilder result = new StringBuilder();
            foreach (var sip in inputs)
            {
                result.AppendLine($"K-diff Pairs for the given array {string.Join(" ", sip.input)} is {this.K_Diff_Pairs(sip.input,sip.find)}");
            }

            MessageBox.Show(result.ToString());
        }


        public int K_Diff_Pairs(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            Dictionary<int, int> dict = new Dictionary<int, int>();

            /*
                [3,1,4,1,5] 2
                [1,2,3,4,5] 1
                [1,3,1,5,4] 0
                [1,2,4,4,3,3,0,9,2,3] 3
                [-1,-2,-3] 1
            */

            int counter = 0;

            foreach (int i in nums)
            {
                if (!dict.ContainsKey(i))
                    dict[i] = 1;
                else
                    dict[i]++;
            }

            foreach (int key in dict.Keys)
            {
                if (k > 0)
                {
                    if (dict.ContainsKey(key + k))
                        counter++;
                }
                else
                {
                    if (dict[key] > 1)
                        counter++;
                }
            }

            return counter;

        }

        private void btn_Remove_Covered_Intervals_Click(object sender, EventArgs e)
        {
            /*
             
                Given a list of intervals, remove all intervals that are covered by another interval in the list.
                Interval [a,b) is covered by interval [c,d) if and only if c <= a and b <= d.

                After doing so, return the number of remaining intervals.
                Example 1:

                Input: intervals = [[1,4],[3,6],[2,8]]
                Output: 2
                Explanation: Interval [3,6] is covered by [2,8], therefore it is removed.
                Example 2:

                Input: intervals = [[1,4],[2,3]]
                Output: 1
                Example 3:

                Input: intervals = [[0,10],[5,12]]
                Output: 2
                Example 4:

                Input: intervals = [[3,10],[4,10],[5,11]]
                Output: 2
                Example 5:

                Input: intervals = [[1,2],[1,4],[3,4]]
                Output: 1
 

                Constraints:

                1 <= intervals.length <= 1000
                intervals[i].length == 2
                0 <= intervals[i][0] < intervals[i][1] <= 10^5
                All the intervals are unique.
                
                Hint #1  
                How to check if an interval is covered by another?
                
                Hint #2  
                Compare each interval to all others and check if it is covered by any interval.
             
             */

            StringBuilder result = new StringBuilder();
            List<JaggedArraysWithString> inputs = new List<JaggedArraysWithString>();
            inputs.Add(new JaggedArraysWithString() { shifts = new int[][] { new int[]{ 1, 4 }, new int[] { 3, 6 }, new int[] { 2, 8 }} });
            //inputs.Add(new JaggedArraysWithString() { shifts = new int[][] { new int[] { 1 , 4 }, new int[] { 2, 3 }} });
            //inputs.Add(new JaggedArraysWithString() { shifts = new int[][] { new int[] { 0, 10 }, new int[] { 5, 12 }} });
            //inputs.Add(new JaggedArraysWithString() { shifts = new int[][] { new int[] { 3, 10 }, new int[] { 4, 10 }, new int[] { 5, 11 } } });
            //inputs.Add(new JaggedArraysWithString() { shifts = new int[][] { new int[] { 1, 2 }, new int[] { 1, 4 }, new int[] { 3, 4 } } });

            foreach (var input in inputs)
            {

                result.AppendLine($"There are  {this.RemoveCoveredIntervals(input.shifts)} covered intervals for the given input {this.PrintData(input)}");
            }

            MessageBox.Show(result.ToString());








        }

        public int RemoveCoveredIntervals(int[][] intervals)
        {
            int result = 0;
            if (intervals == null || intervals.Length == 0)
                result++;

            Array.Sort(intervals, ((x, y) => x[0] - y[0]));
            int[]temp = new int[2] { -1, -1 };
            

            foreach(var c in intervals)
            {
                if (c[0] > temp[0] && c[1] > temp[1])
                {
                    temp[0] = c[0];
                    result++;
                }

                temp[1] = Math.Max(temp[1], c[1]);
            }


           

            return result;

        }

        private void btn_Find_the_Kth_missing_number_in_a_sorted_Array_Click(object sender, EventArgs e)
        {


            StringBuilder result = new StringBuilder();
            List<ArrayAndValue> inputs = new List<ArrayAndValue>();
            inputs.Add(new ArrayAndValue() {input = new int[] {1,3,5,6 },find = 2 });
            inputs.Add(new ArrayAndValue() { input = new int[] { 1,  3, 5, 6 }, find = 8 });

            foreach(ArrayAndValue input in inputs)
            {
                
            }

            MessageBox.Show(result.ToString());
        }

        private void btn_Rotate_Array_Click(object sender, EventArgs e)
        {
            /*
            
                Given an array, rotate the array to the right by k steps, where k is non-negative.

                Follow up:

                Try to come up as many solutions as you can, there are at least 3 different ways to solve this problem.
                Could you do it in-place with O(1) extra space?
 

                Example 1:

                Input: nums = [1,2,3,4,5,6,7], k = 3
                Output: [5,6,7,1,2,3,4]
                Explanation:
                rotate 1 steps to the right: [7,1,2,3,4,5,6]
                rotate 2 steps to the right: [6,7,1,2,3,4,5]
                rotate 3 steps to the right: [5,6,7,1,2,3,4]
                Example 2:

                Input: nums = [-1,-100,3,99], k = 2
                Output: [3,99,-1,-100]
                Explanation: 
                rotate 1 steps to the right: [99,-1,-100,3]
                rotate 2 steps to the right: [3,99,-1,-100]
 
            
                Constraints:

                1 <= nums.length <= 2 * 104
                -231 <= nums[i] <= 231 - 1
                0 <= k <= 105
             
                Hint #1  
                The easiest solution would use additional memory and that is perfectly fine.
            
                Hint #2  
                The actual trick comes when trying to solve this problem without using any additional memory. This means you need to use the original array somehow to move the elements around. Now, 
                we can place each element in its original location and shift all the elements around it to adjust as that would be too costly and most likely will time out on larger input arrays.
            
                Hint #3  
                One line of thought is based on reversing the array (or parts of it) to obtain the desired result. Think about how reversal might potentially help us out by using an example.
            
                Hint #4  
                The other line of thought is a tad bit complicated but essentially it builds on the idea of placing each element in its original position while keeping track of the element originally in that position. 
                Basically, at every step, we place an element in its rightful position and keep track of the element already there or the one being overwritten in an additional variable. 
                We can't do this in one linear pass and the idea here is based on cyclic-dependencies between elements.
            

             */



            StringBuilder result = new StringBuilder();
            List<ArrayAndValue> inputs = new List<ArrayAndValue>();
            inputs.Add(new ArrayAndValue() { input = new int[] { 1, 2, 3, 4, 5, 6, 7 }, find = 3 });
            inputs.Add(new ArrayAndValue() { input = new int[] { 1}, find = 1 });
            inputs.Add(new ArrayAndValue() { input = new int[] { 1 }, find = 0 });
            inputs.Add(new ArrayAndValue() { input = new int[] { -1, -100, 3, 99 }, find = 2 });

            foreach (ArrayAndValue input in inputs)
            {
                result.AppendLine($"Right rotate for the given array {string.Join(",", input.input)} and K {input.find} is ");
                this.Rotate(input.input, input.find);
                result.Append($"{string.Join(",", input.input)}");
                result.AppendLine("");

            }

            MessageBox.Show(result.ToString());
        }

        public void Rotate(int[] nums, int k)
        {

            if (nums == null || nums.Length == 0 || k == 0)
                return;

            int len = nums.Length;
            k %= len;

            Reverse(nums, 0, len - 1);
            Reverse(nums, 0, k - 1);
            Reverse(nums, k, len - 1);

        }

        public void Reverse(int[] nums, int l, int r)
        {
            int temp = 0;
            while (l < r)
            {
                temp = nums[r];
                nums[r] = nums[l];
                nums[l] = temp;
                r--;
                l++;

            }
        }

        private void btn_Minimum_Domino_Rotations_For_Equal_Row_Click(object sender, EventArgs e)
        {

         
            /*
            
                In a row of dominoes, A[i] and B[i] represent the top and bottom halves of the ith domino.  (A domino is a tile with two numbers from 1 to 6 - one on each half of the tile.)

                We may rotate the ith domino, so that A[i] and B[i] swap values.

                Return the minimum number of rotations so that all the values in A are the same, or all the values in B are the same.

                If it cannot be done, return -1.

 

                Example 1:


                Input: A = [2,1,2,4,2,2], B = [5,2,6,2,3,2]
                Output: 2
                Explanation: 
                The first figure represents the dominoes as given by A and B: before we do any rotations.
                If we rotate the second and fourth dominoes, we can make every value in the top row equal to 2, as indicated by the second figure.
                Example 2:

                Input: A = [3,5,1,2,3], B = [3,6,3,3,4]
                Output: -1
                Explanation: 
                In this case, it is not possible to rotate the dominoes to make one row of values equal.
 

                Constraints:

                2 <= A.length == B.length <= 2 * 104
                1 <= A[i], B[i] <= 6

                Mine : 
                Time Complexity     : O(N+M)
                Space Complexity    : O(N+M)

                Others : 
                Time Complexity     : O(N+M)
                Space Complexity    : O(1)

             */


            StringBuilder result = new StringBuilder();
            List<MoreThan1ArrayInputs> inputs = new List<MoreThan1ArrayInputs>();
            inputs.Add(new MoreThan1ArrayInputs() { a = new int[] { 2, 1, 2, 4, 2, 2 }, b = new int[] { 5, 2, 6, 2, 3, 2 } });
            inputs.Add(new MoreThan1ArrayInputs() { a = new int[] { 3, 5, 1, 2, 3 }, b = new int[] { 3, 6, 3, 3, 4 } });
            inputs.Add(new MoreThan1ArrayInputs() { a = new int[] { 1, 2, 1, 1, 1, 2, 2, 2 }, b = new int[] { 2, 1, 2, 2, 2, 2, 2, 2 } });
            inputs.Add(new MoreThan1ArrayInputs() { a = new int[] { 1, 2, 3, 4, 6 }, b = new int[] { 6, 6, 6, 6, 5 } });
            inputs.Add(new MoreThan1ArrayInputs() { a = new int[] { 2, 1, 1, 1, 2, 2, 2, 1, 1, 2 }, b = new int[] { 1, 1, 2, 1, 1, 1, 1, 2, 1, 1 } });

            foreach (MoreThan1ArrayInputs input in inputs)
            {
                result.AppendLine($"Minimum Domino Rotations For Equal Row with  { this.MinDominoRotations_Mine(input.a, input.b) }  and Others  { this.MinDominoRotations(input.a, input.b)} for the given input array {string.Join(",", input.a)} and {string.Join(",", input.b)}");                

            }

            MessageBox.Show(result.ToString());



        }

        public int MinDominoRotations_Mine(int[] A, int[] B)
        {

            if (A == null || A.Length == 0 || B == null || B.Length == 0 || A.Length != B.Length)
                return -1;

            int result = -1;
            int a = GetDominoValue(A, B);
            int b = GetDominoValue(B, A);

            if (a == -1 || b == -1)
                result = Math.Max(a, b);
            else
                result = Math.Min(a, b);

            return result;

        }


        private int GetDominoValue(int[] A, int[] B)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int counter = 0;
            int val = 0;
            int result = 0;
            int currentKey = 0;


            for (int i = 0; i < A.Length; i++)
            {
                dict.TryGetValue(A[i], out counter);
                dict[A[i]] = counter + 1;
            }


            foreach (int key in dict.Keys)
            {
                if (dict[key] > val)
                {
                    currentKey = key;
                    val = dict[key];
                }
            }

            for (int i = 0; i < B.Length; i++)
            {
                if (B[i] == currentKey && A[i] != B[i])
                {
                    result++;
                }
            }

            return ((currentKey > 0 && (result + dict[currentKey] == A.Length)) ? result : -1);
        }

        public int MinDominoRotations(int[] A, int[] B)
        {

            int numRotationsA0 = Check(A[0], A, B);
            int numRotationsB0 = Check(B[0], A, B);

            if (numRotationsA0 != -1 && numRotationsB0 != -1)
            {
                return Math.Min(numRotationsA0, numRotationsB0);
            }

            if (numRotationsA0 != -1)
                return numRotationsA0;

            return numRotationsB0;
        }

        public int Check(int num, int[] A, int[] B)
        {
            var aRots = 0;
            var bRots = 0;

            for (var i = 0; i < A.Length; ++i)
            {

                if (A[i] != num && B[i] != num)
                    return -1;

                if (A[i] != num)
                {
                    aRots++;
                }

                if (B[i] != num)
                {
                    bRots++;
                }
            }

            return Math.Min(aRots, bRots);
        }

        private void btn_Asteroid_Collision_Click(object sender, EventArgs e)
        {
            /*
                We are given an array asteroids of integers representing asteroids in a row.

                For each asteroid, the absolute value represents its size, and the sign represents its direction (positive meaning right, negative meaning left). Each asteroid moves at the same speed.

                Find out the state of the asteroids after all collisions. If two asteroids meet, the smaller one will explode. If both are the same size, both will explode. Two asteroids moving in the same direction will never meet.

 

                Example 1:

                Input: asteroids = [5,10,-5]
                Output: [5,10]
                Explanation: The 10 and -5 collide resulting in 10.  The 5 and 10 never collide.
                Example 2:

                Input: asteroids = [8,-8]
                Output: []
                Explanation: The 8 and -8 collide exploding each other.
                Example 3:

                Input: asteroids = [10,2,-5]
                Output: [10]
                Explanation: The 2 and -5 collide resulting in -5. The 10 and -5 collide resulting in 10.
                Example 4:

                Input: asteroids = [-2,-1,1,2]
                Output: [-2,-1,1,2]
                Explanation: The -2 and -1 are moving left, while the 1 and 2 are moving right. Asteroids moving the same direction never meet, so no asteroids will meet each other.
 

                Constraints:

                1 <= asteroids <= 104
                -1000 <= asteroids[i] <= 1000
                asteroids[i] != 0
             
                Time Complexity     : O(N)
                Space Complexity    : O(N)
             
             */

            int[] i = new int[0];
            StringBuilder result = new StringBuilder();
            List<int[]> inputs = new List<int[]>();
            inputs.Add(new int[] { 5, 10, -5 });
            //inputs.Add(new int[] { 8, -8 });
            //inputs.Add(new int[] { 10, 2, -5 });
            //inputs.Add(new int[] { -2, -1, 1, 2 });

            foreach (int[] input in inputs)
            {
                result.AppendLine($"Asteroid Collision for the given input array {string.Join(",", input)}  is { this.AsteroidCollision(input)}");

            }

            MessageBox.Show(result.ToString());


        }
        public int[] AsteroidCollision(int[] asteroids)
        {
            if (asteroids == null || asteroids.Length <= 1)
                return asteroids;

            Stack<int> stk = new Stack<int>();
            int temp = 0;
            int resCount = 0;
            foreach (int i in asteroids)
            {
                if (stk.Count == 0)
                    stk.Push(i);
                else
                {                   
                    while (stk.Count > 0)
                    {
                        temp = stk.Peek();
                        if (temp > 0 && i < 0)
                        {
                            if (temp < Math.Abs(i))
                            {
                                stk.Pop();
                                if (stk.Count == 0)
                                {
                                    stk.Push(i);
                                    break;
                                }

                            }
                            else if (temp == Math.Abs(i))
                            {
                                stk.Pop();
                                break;
                            }
                            else
                                break;
                        }
                        else
                        {
                            stk.Push(i);
                            break;
                        }
                    }


                }
            }

            resCount = stk.Count;
            int[] result = new int[resCount];

            while (stk.Count > 0)
                result[--resCount] = stk.Pop();

            return result;



        }

        private void btn_132_Pattern_Click(object sender, EventArgs e)
        {
            /*
                Given an array of n integers nums, a 132 pattern is a subsequence of three integers nums[i], nums[j] and nums[k] such that i < j < k and nums[i] < nums[k] < nums[j].

                Return true if there is a 132 pattern in nums, otherwise, return false.

                Follow up: The O(n^2) is trivial, could you come up with the O(n logn) or the O(n) solution?

 

                Example 1:

                Input: nums = [1,2,3,4]
                Output: false
                Explanation: There is no 132 pattern in the sequence.
                Example 2:

                Input: nums = [3,1,4,2]
                Output: true
                Explanation: There is a 132 pattern in the sequence: [1, 4, 2].
                Example 3:

                Input: nums = [-1,3,2,0]
                Output: true
                Explanation: There are three 132 patterns in the sequence: [-1, 3, 2], [-1, 3, 0] and [-1, 2, 0].
 

                Constraints:

                n == nums.length
                1 <= n <= 104
                -109 <= nums[i] <= 109
 
               Time Complexity      : O(N)
               Space Complexity     : O(N)


             */

            int[] i = new int[0];
            StringBuilder result = new StringBuilder();
            List<int[]> inputs = new List<int[]>();
            //inputs.Add(new int[] { 1,2,3,4 });
            //inputs.Add(new int[] { 3,1,4,2 });
            //inputs.Add(new int[] { -1,3,2,0 });
            //inputs.Add(new int[] {1,0,1,-4,-3});
            inputs.Add(new int[] { 42,43,6,12,3,4,6,11,20 });

            foreach (int[] input in inputs)
            {
                result.AppendLine($"132 pattern {(Find132pattern(input) ? "" : " is not")}  existing for the given input array {string.Join(",", input)}");

            }

            MessageBox.Show(result.ToString());


        }

        public bool Find132pattern(int[] nums)
        {
            bool result = false;
            if (nums == null || nums.Length < 3)
                return result;


            int l = nums.Length;
            int[] min = new int[l];
            min[0] = nums[0];
            Stack<int> s = new Stack<int>();

            for (int i = 1; i < nums.Length; i++)
                min[i] = Math.Min(nums[i], min[i - 1]);


            for (int i = l - 1; i >= 0; i--)
            {
                if (nums[i] > min[i])
                {
                    while (s.Count > 0 && s.Peek() <= min[i])
                        s.Pop();

                    if (s.Count > 0 && s.Peek() < nums[i])
                        return true;
                    s.Push(nums[i]);
                }

            }



            return result;

        }

        private void btn_Summary_Ranges_Click(object sender, EventArgs e)
        {
            /*
             
                You are given a sorted unique integer array nums.

                Return the smallest sorted list of ranges that cover all the numbers in the array exactly. That is, each element of nums is covered by exactly one of the ranges, and there is no integer x such that x is in one of the ranges but not in nums.

                Each range [a,b] in the list should be output as:

                "a->b" if a != b
                "a" if a == b
 

                Example 1:
                Input: nums = [0,1,2,4,5,7]
                Output: ["0->2","4->5","7"]
                Explanation: The ranges are:
                [0,2] --> "0->2"
                [4,5] --> "4->5"
                [7,7] --> "7"

                Example 2:
                Input: nums = [0,2,3,4,6,8,9]
                Output: ["0","2->4","6","8->9"]
                Explanation: The ranges are:
                [0,0] --> "0"
                [2,4] --> "2->4"
                [6,6] --> "6"
                [8,9] --> "8->9"
                
                Example 3:
                Input: nums = []
                Output: []
                
                Example 4:
                Input: nums = [-1]
                Output: ["-1"]
                
                Example 5:
                Input: nums = [0]
                Output: ["0"]
 

                Constraints:

                0 <= nums.length <= 20
                -231 <= nums[i] <= 231 - 1
                All the values of nums are unique.

                Time Complexity     : O(N)
                Space Complexity    : O(1)

             */

            StringBuilder result = new StringBuilder();
            List<int[]> inputs = new List<int[]>();
            inputs.Add(new int[] { 0, 1, 2, 4, 5, 7 });
            inputs.Add(new int[] { 0, 2, 3, 4, 6, 8, 9 });
            inputs.Add(new int[] { });
            inputs.Add(new int[] {-1 });
            inputs.Add(new int[] { 0});

            foreach (int[] input in inputs)
            {
                result.AppendLine($"Summary Ranges for the given input array {(string.Join(",",input))} is {string.Join(" ",SummaryRanges(input))}");

            }

            MessageBox.Show(result.ToString());

        }


        public IList<string> SummaryRanges(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return new List<string>();


            List<string> result = new List<string>();
            int start = nums[0];
            int counter = start;
            int i = 1;
            for (; i < nums.Length; i++)
            {
                if (nums[i] != ++counter)
                {
                    result.Add((start == nums[i - 1] ? $"{start}" : $"{start}->{nums[i - 1]}"));
                    start = nums[i];
                    counter = start;
                }
            }

            result.Add((start == nums[i - 1] ? $"{start}" : $"{start}->{nums[i - 1]}"));

            return result;
        }

        private void btn_Number_of_Longest_Increasing_Subsequence_Click(object sender, EventArgs e)
        {
            /*
             
            Given an integer array nums, return the number of longest increasing subsequences.

            Example 1:
            Input: nums = [1,3,5,4,7]
            Output: 2
            Explanation: The two longest increasing subsequences are [1, 3, 4, 7] and [1, 3, 5, 7].
            
            Example 2:
            Input: nums = [2,2,2,2,2]
            Output: 5
            Explanation: The length of longest continuous increasing subsequence is 1, and there are 5 subsequences' length is 1, so output 5.

            Constraints:

            0 <= nums.length <= 2000
            -106 <= nums[i] <= 106
             
             */

            StringBuilder result = new StringBuilder();
            List<int[]> inputs = new List<int[]>();
            //inputs.Add(new int[] { 1,3,5,4,7 });
            //inputs.Add(new int[] {2,2,2,2,2});
            inputs.Add(new int[] { 1, 2, 4, 3, 5, 4, 7, 2 });
           

            foreach (int[] input in inputs)
            {
                result.AppendLine($"Number of Longest Increasing Subsequence for the given input array {(string.Join(",", input))} is {string.Join(" ", FindNumberOfLIS(input))}");

            }

            MessageBox.Show(result.ToString());


        }

        public int FindNumberOfLIS(int[] nums)
        {
            if (nums == null || nums.Length <= 1)
                return (nums == null ? 0 : nums.Length);



            int[] length = Enumerable.Repeat(1, nums.Length).ToArray<int>();
            int[] count = Enumerable.Repeat(1, nums.Length).ToArray<int>();

            int lis = 0;

            /*
             [1,2,4,3,5,4,7,2]

             */

            for (int i = 1; i < nums.Length; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    if (nums[j] < nums[i])
                    {
                        if (length[j] + 1 > length[i])
                        {
                            length[i] = length[j] + 1;
                            count[i] = count[j];
                        }
                        else if ((length[j] + 1) == length[i])
                        {
                            count[i] += count[j];
                        }
                    }
                }

                lis = Math.Max(lis, length[i]);
            }

            int result = 0;
            for(int i = 0; i < nums.Length; i++)
            {
                if (length[i] == lis)
                    result += count[i];
            }

            return result;

        }

        private void btn_Find_the_Smallest_Divisor_Given_a_Threshold_Click(object sender, EventArgs e)
        {
            /*
                Given an array of integers nums and an integer threshold, we will choose a positive integer divisor and divide all the array by it and sum the result of the division. Find the smallest divisor such that the result mentioned above is less than or equal to threshold.

                Each result of division is rounded to the nearest integer greater than or equal to that element. (For example: 7/3 = 3 and 10/2 = 5).

                It is guaranteed that there will be an answer.

 

                Example 1:

                Input: nums = [1,2,5,9], threshold = 6
                Output: 5
                Explanation: We can get a sum to 17 (1+2+5+9) if the divisor is 1. 
                If the divisor is 4 we can get a sum to 7 (1+1+2+3) and if the divisor is 5 the sum will be 5 (1+1+1+2). 
                Example 2:

                Input: nums = [2,3,5,7,11], threshold = 11
                Output: 3
                Example 3:

                Input: nums = [19], threshold = 5
                Output: 4
 

                Constraints:

                1 <= nums.length <= 5 * 10^4
                1 <= nums[i] <= 10^6
                nums.length <= threshold <= 10^6
                   Hide Hint #1  
                Examine every possible number for solution. Choose the largest of them.
                   Hide Hint #2  
                Use binary search to reduce the time complexity.


                Time Complexity     : Nlog (10^6)
                Space Complexity    : O(1)

             */


            StringBuilder result = new StringBuilder();
            List<ArrayAndValue> inputs = new List<ArrayAndValue>();
            inputs.Add(new ArrayAndValue() { input = new int[] { 1, 2, 5, 9 }, find = 6 });
            inputs.Add(new ArrayAndValue() { input = new int[] { 2, 3, 5, 7, 11 }, find = 11 });
            inputs.Add(new ArrayAndValue() { input = new int[] {19 }, find = 5 });

            foreach (var input in inputs)
            {
                result.AppendLine($"Smallest Divisor Given a Threshold for the given input {(string.Join(" ", input.input))} and threshold  {input.find} is  {this.SmallestDivisor(input.input, input.find)}");
            }

            MessageBox.Show(result.ToString());

        }

        public int SmallestDivisor(int[] nums, int threshold)
        {
            
            if (nums == null || nums.Length == 0)
                return 0;


            int l = 1;
            int r = 1000000;
            int m = 0;
            long s = 0;
            while (l <= r) //This block takes Log N complexity due to binary search approach
            {
                m = l + (r - l) / 2;

                s = GetSum(nums, m);

                if (s > threshold)
                {
                    l = m + 1;
                }
                else
                {
                    r = m - 1;
                }
            }


            return l;


        }

        private long GetSum(int[] nums, int mid)
        {
            //N time complexity
            int sum = 0;
            foreach (int i in nums)
            {
                sum += ((i - 1) / mid) + 1;
            }
            return sum;
        }

        private void btn_Valid_Square_Click(object sender, EventArgs e)
        {
            /*
                    Given the coordinates of four points in 2D space, return whether the four points could construct a square.

                    The coordinate (x,y) of a point is represented by an integer array with two integers.

                    Example:

                    Input: p1 = [0,0], p2 = [1,1], p3 = [1,0], p4 = [0,1]
                    Output: True
 

                    Note:

                    All the input integers are in the range [-10000, 10000].
                    A valid square has four equal sides with positive length and four equal angles (90-degree angles).
                    Input points have no order.
 
                    Time Complexity     : O(1)
                    Space Complexity    : O(1)
           */


            StringBuilder result = new StringBuilder();
            List<MoreThan1ArrayInputs> inputs = new List<MoreThan1ArrayInputs>();
            inputs.Add(new MoreThan1ArrayInputs() { a = new int[] { 0, 0 }, b = new int[] { 1,1}, c = new int[] { 1, 0 }, d = new int[] { 0, 1 } });
            inputs.Add(new MoreThan1ArrayInputs() { a = new int[] { 0, 0 }, b = new int[] { -1, 0 }, c = new int[] { 0, 1 }, d = new int[] { 0, -1 } }); //3

            foreach (var input in inputs)
            {
                result.Append($"Valid Square {(ValidSquare(input.a, input.b, input.c, input.d) ? "" : " not " )} exists for the given points {Environment.NewLine}{input.a[0]} {input.a[1]}{Environment.NewLine}{input.b[0]} {input.b[1]}{Environment.NewLine}{input.c[0]} {input.c[1]}{Environment.NewLine}{input.d[0]} {input.d[1]}");

            }
        }

        public bool ValidSquare(int[] p1, int[] p2, int[] p3, int[] p4)
        {

            HashSet<int> result = new HashSet<int>();
            result.Add(Distance(p1, p2));
            result.Add(Distance(p2, p3));
            result.Add(Distance(p3, p4));
            result.Add(Distance(p1, p4));
            result.Add(Distance(p1, p3));
            result.Add(Distance(p2, p4));

            return !result.Contains(0) && result.Count == 2;





        }

        private int Distance(int[] d1, int[] d2)
        {

            int r1 = d1[0] - d2[0];
            int r2 = d1[1] - d2[1];

            return (r1 * r1) + (r2 * r2);

        }

        private void btn_Permutations_II_Click(object sender, EventArgs e)
        {
            /*
             
                Given a collection of numbers, nums, that might contain duplicates, return all possible unique permutations in any order.

                Example 1:

                Input: nums = [1,1,2]
                Output:
                [[1,1,2],
                 [1,2,1],
                 [2,1,1]]
                Example 2:

                Input: nums = [1,2,3]
                Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]
 

                Constraints:

                1 <= nums.length <= 8
                -10 <= nums[i] <= 10
             

                Time Complexity     : O(N * N!)
                Space Complexity    : O(N * N!)
            */


            List<int[]> inputs = new List<int[]>();
            inputs.Add(new int[] { 1,1,2 });
            inputs.Add(new int[] { 1, 2, 3 });   

            StringBuilder result = new StringBuilder();
            string str = string.Empty;
            foreach (var input in inputs)
            {
                str = $"Permutations II for the given input {(string.Join(",", input))} is";
                var temp = this.PermuteUnique(input);
                foreach (var t in temp)
                {
                    str += $"{string.Join(" ", t)} {Environment.NewLine}";
                }                 
                
                result.AppendLine($"{str}");
            }

            MessageBox.Show(result.ToString());
        }

        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return new List<IList<int>>();


            IList<IList<int>> result = new List<IList<int>>();
            Dictionary<int, int> dict = new Dictionary<int, int>();


            foreach(int i in nums)
            {
                if (!dict.ContainsKey(i))
                    dict[i] = 1;
                else
                    dict[i]++;
            }

            GetArrayPermute(nums, new List<int>(), ref result, dict);

            return result;

        }

        private void GetArrayPermute(int[] input, List<int> data, ref IList<IList<int>> result, Dictionary<int, int> dict)
        {
           if (data.Count == input.Length)
            {
                result.Add(new List<int>(data));
                return;
            }


           foreach(int key in dict.Keys.ToList<int>())
           {
                if (dict[key] == 0)
                    continue;

                data.Add(key);
                dict[key]--;
                GetArrayPermute(input, data, ref result, dict);
                dict[key]++;
                data.RemoveAt(data.Count - 1);
           }

        }

        private void btn_Longest_Mountain_in_Array_Click(object sender, EventArgs e)
        {
            /*
                Let's call any (contiguous) subarray B (of A) a mountain if the following properties hold:

                B.length >= 3
                There exists some 0 < i < B.length - 1 such that B[0] < B[1] < ... B[i-1] < B[i] > B[i+1] > ... > B[B.length - 1]
                (Note that B could be any subarray of A, including the entire array A.)

                Given an array A of integers, return the length of the longest mountain. 

                Return 0 if there is no mountain.

                Example 1:

                Input: [2,1,4,7,3,2,5]
                Output: 5
                Explanation: The largest mountain is [1,4,7,3,2] which has length 5.
                Example 2:

                Input: [2,2,2]
                Output: 0
                Explanation: There is no mountain.
                Note:

                0 <= A.length <= 10000
                0 <= A[i] <= 10000
                Follow up:

                Can you solve it using only one pass?
                Can you solve it in O(1) space? 

                Time Complexity     : O(N)
                Space Complexity    : O(1)

            */

            List<int[]> inputs = new List<int[]>();
            inputs.Add(new int[] { 2, 1, 4, 7, 3, 2, 5 });
            inputs.Add(new int[] { 2, 2, 2 });
            inputs.Add(new int[] { 1, 2, 1 });
            inputs.Add(new int[] { 1, 4, 7, 3, 2, 1, 0 });
            inputs.Add(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });


            StringBuilder result = new StringBuilder();
            string str = string.Empty;
            foreach (var input in inputs)
            {
              
                result.AppendLine($"Longest Mountain for the given array {string.Join(",", input)} is {this.LongestMountain(input)}");
            }

            MessageBox.Show(result.ToString());
        }

        public int LongestMountain(int[] A)
        {
            if (A == null || A.Length <= 2)
                return 0;

            int len = A.Length;
            int result = 0;
            int end = 0; //2

            for (int i = 0; i < len; i = Math.Max(end, i + 1))
            {
                end = i;
                if (end + 1 < len && A[end] < A[end + 1])
                {
                    while (end + 1 < len && A[end] < A[end + 1])
                        end++;

                    if (end + 1 < len && A[end] > A[end + 1])
                    {
                        while (end + 1 < len && A[end] > A[end + 1])
                            end++;

                        result = Math.Max(result, end - i + 1);
                    }
                }
            }

            return result;
        }

        private void btn_Numbers_At_Most_N_Given_Digit_Set_Click(object sender, EventArgs e)
        {
            /*
                Given an array of digits, you can write numbers using each digits[i] as many times as we want.  For example, if digits = ['1','3','5'], we may write numbers such as '13', '551', and '1351315'.

                Return the number of positive integers that can be generated that are less than or equal to a given integer n.

 

                Example 1:

                Input: digits = ["1","3","5","7"], n = 100
                Output: 20
                Explanation: 
                The 20 numbers that can be written are:
                1, 3, 5, 7, 11, 13, 15, 17, 31, 33, 35, 37, 51, 53, 55, 57, 71, 73, 75, 77.
                Example 2:

                Input: digits = ["1","4","9"], n = 1000000000
                Output: 29523
                Explanation: 
                We can write 3 one digit numbers, 9 two digit numbers, 27 three digit numbers,
                81 four digit numbers, 243 five digit numbers, 729 six digit numbers,
                2187 seven digit numbers, 6561 eight digit numbers, and 19683 nine digit numbers.
                In total, this is 29523 integers that can be written using the digits array.
                Example 3:

                Input: digits = ["7"], n = 8
                Output: 1
 

                Constraints:

                1 <= digits.length <= 9
                digits[i].length == 1
                digits[i] is a digit from '1' to '9'.
                All the values in digits are unique.
                1 <= n <= 109
             
                Time Complexity     : O(DN) : where D is Length of the digits and N is Length of N
                Space Complexity    : O(1)
             */

            StringBuilder result = new StringBuilder();
            List<ArrayAndValue> inputs = new List<ArrayAndValue>();
            inputs.Add(new ArrayAndValue() { stringinput = new string[] { "1", "3", "5", "7" }, find = 100 });
            inputs.Add(new ArrayAndValue() { stringinput = new string[] { "1", "4", "9" }, find = 1000000000 });
            inputs.Add(new ArrayAndValue() { stringinput = new string[] { "7" }, find = 8 });

            foreach (var input in inputs)
            {
                result.AppendLine($"Numbers At Most N Given Digit Set for the given input array{(string.Join(" ", input.stringinput))} and number  {input.find} is  {this.AtMostNGivenDigitSet(input.stringinput, input.find)}");
            }

            MessageBox.Show(result.ToString());

        }

        public int AtMostNGivenDigitSet(string[] digits, int n)
        {
            if (digits == null || digits.Length == 0 || n <= 0)
                return 0;

            string N = n.ToString();
            int nl = N.Length;
            int dl = digits.Length;
            bool prefix = false;
            int result = 0;
            int pow = 1;
            for (int i = 1; i < nl; i++)
            {
                pow *= dl;
                result += pow;
             }

            for (int i = 0; i < nl; i++ )
            {
                prefix = false;
                foreach(string d in digits)
                {
                    if (d[0] < N[i])
                        result +=  (int)Math.Pow(dl, nl - i - 1);
                    else if (d[0] == N[i])
                    {
                        prefix = true;
                        break;
                    }
                }
                if (!prefix)
                    return result;
            }

            return result + 1;
        }

        private void btn_Pairs_of_Songs_With_Total_Durations_Divisible_by_60_Click(object sender, EventArgs e)
        {
            /*
            You are given a list of songs where the ith song has a duration of time[i] seconds.

            Return the number of pairs of songs for which their total duration in seconds is 
            divisible by 60. Formally, we want the number of indices i, j such that i < j with 
            (time[i] + time[j]) % 60 == 0. 

            Example 1:
            Input: time = [30,20,150,100,40]
            Output: 3
            Explanation: Three pairs have a total duration divisible by 60:
            (time[0] = 30, time[2] = 150): total duration 180
            (time[1] = 20, time[3] = 100): total duration 120
            (time[1] = 20, time[4] = 40): total duration 60
            
            Example 2:
            Input: time = [60,60,60]
            Output: 3
            Explanation: All three pairs have a total duration of 120, which is divisible by 60.
 

            Constraints:

            1 <= time.length <= 6 * 104
            1 <= time[i] <= 500
               Hide Hint #1  
            We only need to consider each song length modulo 60.
               Hide Hint #2  
            We can count the number of songs with (length % 60) equal to r, and store that in an array of size 60.
 
            Time Complexity     : O(N)
            Space Complexity    : O(1)

             */


            StringBuilder result = new StringBuilder();

            List<int[]> inputs = new List<int[]>();
            inputs.Add(new int[] { 30, 20, 150, 100, 40 });
            inputs.Add(new int[] { 60,60,60 });
        
            foreach (var input in inputs)
            {
                result.AppendLine($"Pairs of Songs With Total Durations Divisible by 60 for the given array {string.Join(",",input)} is {this.NumPairsDivisibleBy60(input)}");
            }

            MessageBox.Show(result.ToString());

        }

        public int NumPairsDivisibleBy60(int[] time)
        {
            if (time == null || time.Length == 0)
                return 0;

            int result = 0;
            int[] dict = new int[60];
            int temp = 0;
        

            foreach (int i in time)
            {
                temp = i % 60;

                if (temp == 0)
                    result += dict[temp];
                else
                    result += dict[60 - temp];

                dict[temp]++;

            }

            return result;

        }

        private void btn_Can_Place_Flowers_Click(object sender, EventArgs e)
        {
            /*
                 You have a long flowerbed in which some of the plots are planted, and some are not. However, 
                 flowers cannot be planted in adjacent plots.

                 Given an integer array flowerbed containing 0's and 1's, where 0 means empty and 1 means not 
                 empty, and an integer n, return if n new flowers can be planted in the flowerbed without 
                 violating the no-adjacent-flowers rule.
             
 
                Example 1:

                Input: flowerbed = [1,0,0,0,1], n = 1
                Output: true
                Example 2:

                Input: flowerbed = [1,0,0,0,1], n = 2
                Output: false
 

                Constraints:

                1 <= flowerbed.length <= 2 * 104
                flowerbed[i] is 0 or 1.
                There are no two adjacent flowers in flowerbed.
                0 <= n <= flowerbed.length
             
                Time Complexity     : O(N)
                Space Complexity    : O(1)

             */

            StringBuilder result = new StringBuilder();
            List<ArrayAndValue> inputs = new List<ArrayAndValue>();
            inputs.Add(new ArrayAndValue() { input = new int[] { 1, 0, 0, 0, 1 }, find = 1 });
            inputs.Add(new ArrayAndValue() { input = new int[] { 1, 0, 0, 0, 1 }, find = 2 });
            inputs.Add(new ArrayAndValue() { input = new int[] { 0,1, 0, 0, 0, 1 }, find = 1 });
            inputs.Add(new ArrayAndValue() { input = new int[] { 1,0,0,0,1,0,0 }, find = 1 });
            inputs.Add(new ArrayAndValue() { input = new int[] { 1, 0, 0, 0, 1, 0, 0 }, find = 2 });
            inputs.Add(new ArrayAndValue() { input = new int[] { 1, 0, 0, 0, 0 }, find = 2 });

            foreach (var input in inputs)
            {
                string flowerBed = string.Join(",", input.input);
                result.AppendLine($"{input.find } Flowers {(this.CanPlaceFlowers(input.input, input.find)? "can" : "cannot")} be place for input array {flowerBed}");
            }

            MessageBox.Show(result.ToString());

        }

        public bool CanPlaceFlowers(int[] flowerbed, int n)
        {

            int len = flowerbed.Length;
            int prev = 0;
            int next = 0;
            int result = 0;

            for (int i = 0; i < len; i++)
            {

                if (flowerbed[i] == 0)
                {
                    prev = i == 0 ? 0 : flowerbed[i - 1];
                    next = i == len - 1 ? 0 : flowerbed[i + 1];

                    if ((prev + next) == 0)
                    {
                        flowerbed[i] = 1;
                        result++;
                    }
                }
            }
            return result >= n;
        }

        private void btn_Remove_Duplicates_from_Sorted_Array_II_Click(object sender, EventArgs e)
        {
            /*
                Given a sorted array nums, remove the duplicates in-place such that duplicates 
                appeared at most twice and return the new length.

                Do not allocate extra space for another array; you must do this by modifying the 
                input array in-place with O(1) extra memory.

                Clarification:

                Confused why the returned value is an integer, but your answer is an array?

                Note that the input array is passed in by reference, which means a modification to 
                the input array will be known to the caller.

                Internally you can think of this:

                // nums is passed in by reference. (i.e., without making a copy)
                int len = removeDuplicates(nums);

                // any modification to nums in your function would be known by the caller.
                // using the length returned by your function, it prints the first len elements.
                for (int i = 0; i < len; i++) {
                    print(nums[i]);
                }
 

                Example 1:

                Input: nums = [1,1,1,2,2,3]
                Output: 5, nums = [1,1,2,2,3]
                Explanation: Your function should return length = 5, with the first five elements of nums being 1, 1, 2, 2 and 3 respectively. It doesn't matter what you leave beyond the returned length.
                Example 2:

                Input: nums = [0,0,1,1,1,1,2,3,3]
                Output: 7, nums = [0,0,1,1,2,3,3]
                Explanation: Your function should return length = 7, with the first seven elements of nums being modified to 0, 0, 1, 1, 2, 3 and 3 respectively. It doesn't matter what values are set beyond the returned length.
 

                Constraints:

                0 <= nums.length <= 3 * 104
                -104 <= nums[i] <= 104
                nums is sorted in ascending order.
             
                Time Complexity     : O(N)
                Space Complexity    : O(1)
             */

            StringBuilder result = new StringBuilder();
            List<int[]> inputs = new List<int[]>();
            inputs.Add(new int[] { 1, 1, 1, 2, 2, 3 });
            inputs.Add(new int[] { 0, 0, 1, 1, 1, 1, 2, 3, 3 });
           
            foreach (var input in inputs)
            {                
                result.AppendLine($"Remove Duplicates from Sorted Array II for the given input {string.Join(",", input)} is {this.RemoveDuplicates(input)}");
            }

            MessageBox.Show(result.ToString());


        }

        public int RemoveDuplicates(int[] nums)
        {

            if (nums == null || nums.Length <= 2)
                return nums == null ? 0 : nums.Length;

            int insertPos = 2;
            int i = 2;
            while (i < nums.Length)
            {
                if (nums[insertPos - 2] != nums[i])
                {
                    nums[insertPos] = nums[i];
                    insertPos++;
                }
                i++;
            }

            Array.Resize(ref nums, insertPos);
            return nums.Length;

        }

        private void btn_Valid_Mountain_Array_Click(object sender, EventArgs e)
        {
            /*
             Given an array of integers arr, return true if and only if it is a valid mountain array.
                
            Recall that arr is a mountain array if and only if:

            arr.length >= 3
            There exists some i with 0 < i < arr.length - 1 such that:
            arr[0] < arr[1] < ... < arr[i - 1] < A[i]
            arr[i] > arr[i + 1] > ... > arr[arr.length - 1]

            Example 1:
            Input: arr = [2,1]
            Output: false
            
            Example 2:
            Input: arr = [3,5,5]
            Output: false
            
            Example 3:
            Input: arr = [0,3,2,1]
            Output: true
 

            Constraints:
            1 <= arr.length <= 104
            0 <= arr[i] <= 104
               Hide Hint #1  
            It's very easy to keep track of a monotonically increasing or decreasing ordering of elements. 
            You just need to be able to determine the start of the valley in the mountain and from that point 
            onwards, it should be a valley i.e. no mini-hills after that. Use this information in regards to 
            the values in the array and you will be able to come up with a straightforward solution.
             
               Time Complexity     : O(N)
               Space Complexity    : O(1)

             */

            StringBuilder result = new StringBuilder();
            List<int[]> inputs = new List<int[]>();
            inputs.Add(new int[] { 2, 1 });
            inputs.Add(new int[] { 3, 5, 5 });
            inputs.Add(new int[] { 0, 3, 2, 1 });
            inputs.Add(new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 });
            inputs.Add(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });    

            foreach (var input in inputs)
            {
                result.AppendLine($"Mountain array {(this.ValidMountainArray(input) ? "" :"not ")} exists for the given input array {string.Join(",", input)} ");
            }

            MessageBox.Show(result.ToString());
        }

        public bool ValidMountainArray(int[] arr)
        {
            if (arr == null || arr.Length < 3 || arr[0] >= arr[1])
                return false;

            bool isDipExists = false;

            int i = 0;
            for (; i < arr.Length - 1; i++)
            {
                if (!isDipExists)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        isDipExists = true;
                    }
                    else if (arr[i] == arr[i + 1])
                        return false;
                }
                else
                {
                    if (arr[i] <= arr[i + 1])
                        return false;
                }
            }
            return isDipExists && true;
        }

        private void btn_Squares_of_a_Sorted_Array_Click(object sender, EventArgs e)
        {
            /*
                Given an integer array nums sorted in non-decreasing order, return an array of the squares of each number sorted in non-decreasing order.

                Example 1:

                Input: nums = [-4,-1,0,3,10]
                Output: [0,1,9,16,100]
                Explanation: After squaring, the array becomes [16,1,0,9,100].
                After sorting, it becomes [0,1,9,16,100].
                Example 2:

                Input: nums = [-7,-3,2,3,11]
                Output: [4,9,9,49,121]
 

                Constraints:

                1 <= nums.length <= 104
                -104 <= nums[i] <= 104
                nums is sorted in non-decreasing order.
             
                Time Complexity         : O(N)
                Space Complexity        : O(N)

             */


            StringBuilder result = new StringBuilder();
            List<int[]> inputs = new List<int[]>();
            inputs.Add(new int[] { -4, -1, 0, 3, 10 });
            inputs.Add(new int[] { -7, -3, 2, 3, 11 });
            inputs.Add(new int[] { -5, -3, -2, -1 });
            inputs.Add(new int[] { -10000, -9999, -7, -5, 0, 0, 10000 });


            foreach (var input in inputs)
            {
                result.AppendLine($" Squares of a Sorted Array is  {string.Join(",",this.SortedSquares(input))} for the given input array {string.Join(",", input)} ");
            }

            MessageBox.Show(result.ToString());

        }


        public int[] SortedSquares(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return nums;

            int[] result = new int[nums.Length];

            // -4, -1, 0, 3, 10

            int i = nums.Length - 1;
            int left = 0;
            int right = 0;
            int b = 0;
            int e = i;

            while (i >= 0)
            {
                left = nums[b] * nums[b];
                right = nums[e] * nums[e];

                if (left > right)
                {
                    result[i--] = left;
                    b++;
                }
                else
                {
                    result[i--] = right;
                    e--;
                }

            }

            return result;
        }

        private void btn_Increasing_Triplet_Subsequence_Click(object sender, EventArgs e)
        {            
            /*
            
                    Given an integer array nums, return true if there exists a triple of indices (i, j, k) such that i < j < k and nums[i] < nums[j] < nums[k]. If no such indices exists, return false.

                    Example 1:

                    Input: nums = [1,2,3,4,5]
                    Output: true
                    Explanation: Any triplet where i < j < k is valid.
                    Example 2:

                    Input: nums = [5,4,3,2,1]
                    Output: false
                    Explanation: No triplet exists.
                    Example 3:

                    Input: nums = [2,1,5,0,4,6]
                    Output: true
                    Explanation: The triplet (3, 4, 5) is valid because nums[3] == 0 < nums[4] == 4 < nums[5] == 6.
 

                    Constraints:

                    1 <= nums.length <= 105
                    -231 <= nums[i] <= 231 - 1
 

                    Follow up: Could you implement a solution that runs in O(n) time complexity and O(1) space complexity?
                    
                    Time Complexity     :   O(N)
                    Space Complexity    :   O(1)
             */

            StringBuilder result = new StringBuilder();
            List<int[]> inputs = new List<int[]>();
            inputs.Add(new int[] { 1, 2, 3, 4, 5 });
            inputs.Add(new int[] { 5, 4, 3, 2, 1 });
            inputs.Add(new int[] { 2, 1, 5, 0, 4, 6 });
            

            foreach (var input in inputs)
            {
                result.AppendLine($"Increasing Triplet Subsequence  {(this.IncreasingTriplet(input) ? "" : " not " )} exists for the given input array {string.Join(",", input)} ");                
            }

            MessageBox.Show(result.ToString());


        }


        
        public bool IncreasingTriplet(int[] nums)
        {
            int left = int.MaxValue, mid = int.MaxValue;
                       
            
            foreach (int n in nums)
            {
                if (n > mid)
                    return true;
                else if (left < n && n < mid)
                {
                    mid = n;
                }
                else if (n < left)
                {
                    left = n;
                }
            }

            return false;
        }

        private void btn_Smallest_Range_II_Click(object sender, EventArgs e)
        {
            /*
                Given an array A of integers, for each integer A[i] we need to choose either x = -K or x = K, and add x to A[i] (only once).
                After this process, we have some array B.
                Return the smallest possible difference between the maximum value of B and the minimum value of B.

                Example 1:
                Input: A = [1], K = 0
                Output: 0
                Explanation: B = [1]

                Example 2:
                Input: A = [0,10], K = 2
                Output: 6
                Explanation: B = [2,8]

                Example 3:
                Input: A = [1,3,6], K = 3
                Output: 3
                Explanation: B = [4,6,3]  

                Note:
                1 <= A.length <= 10000
                0 <= A[i] <= 10000
                0 <= K <= 10000 

                Time Complexity     :   O(NlogN)
                Space Complexity    :   O(1)

             */


            StringBuilder result = new StringBuilder();
            List<Array2n> inputs = new List<Array2n>();
            inputs.Add(new Array2n() { Data = new int[] {1 }, N = 0 });
            inputs.Add(new Array2n() { Data = new int[] { 0, 10 }, N = 2 }); 
            inputs.Add(new Array2n() { Data = new int[] { 1,3,6 }, N = 3 }); 
            inputs.Add(new Array2n() { Data = new int[] { 2,7,2 }, N = 1 }); 

            foreach (var input in inputs)
            {
                result.AppendLine($"Small Range II is {this.SmallestRangeII(input.Data, input.N)} for the given array { string.Join(",", input.Data)} and K : {input.N}");
            }

            MessageBox.Show(result.ToString());
        }


        public int SmallestRangeII(int[] A, int K)
        {
            if (A == null || A.Length == 0)
                return 0;
            
            Array.Sort(A);

            int min = 0;
            int max = 0;
            int len = A.Length;
            int result = A[len - 1] - A[0];

            /*
                        1        3       6                  1        3       6
                        4        0                          4                3
                        4                3                           6       3

             */

            for (int i = 0; i < len - 1; i++)  // 1, 3, 6   3    i = 2
            {
                min = Math.Min(A[0] + K, A[i + 1] - K);   // 3
                max = Math.Max(A[len - 1] - K, A[i] + K); // 4
                result = Math.Min(result, max - min); //3
            }

            return result;
        }

        private void btn_Kth_Missing_Positive_Number_Click(object sender, EventArgs e)
        {
            /*
                Given an array arr of positive integers sorted in a strictly increasing order, and an integer k.
                Find the kth positive integer that is missing from this array.

                Example 1:
                Input: arr = [2,3,4,7,11], k = 5
                Output: 9
                Explanation: The missing positive integers are [1,5,6,8,9,10,12,13,...]. The 5th missing positive integer is 9.
                
                Example 2:
                Input: arr = [1,2,3,4], k = 2
                Output: 6
                Explanation: The missing positive integers are [5,6,7,...]. The 2nd missing positive integer is 6.
 
                Constraints:

                1 <= arr.length <= 1000
                1 <= arr[i] <= 1000
                1 <= k <= 1000
                arr[i] < arr[j] for 1 <= i < j <= arr.length
                
                Hide Hint #1  
                Keep track of how many positive numbers are missing as you scan the array.
            
            
                Time Complexity     : O(N)
                Space Complexity    : O(1)
             */


            StringBuilder result = new StringBuilder();
            List<Array2n> inputs = new List<Array2n>();
            inputs.Add(new Array2n() { Data = new int[] { 2, 3, 4, 7, 11 }, N = 5 });
            inputs.Add(new Array2n() { Data = new int[] { 1, 2, 3, 4 }, N = 2 });
            inputs.Add(new Array2n() { Data = new int[] { 1, 2, 4, 6 }, N = 2 });
            

            foreach (var input in inputs)
            {
                result.AppendLine($"Kth Missing Positive Number mine : {this.FindKthPositive(input.Data, input.N)}  others: {FindKthPositive_Others(input.Data,input.N)} for the given array { string.Join(",", input.Data)} and K : {input.N}");
            }

            MessageBox.Show(result.ToString());
        }

        public int FindKthPositive(int[] arr, int k)
        {            
            if (arr == null || k == 0)
                return 0;


            int missingNumber = 0;
            int arrCounter = 0;
            int i = 1;
            int len = arr.Length;

            /*        
                2,3,4,7,11  k = 5
                1,2,3,4     k = 2
                i = 6   arrCounter = 4  missingNumber = 5  k = 1   AL:4
            */

            while (i <= arr[len - 1] + k) //6
            {
                while (arrCounter < len && i != arr[arrCounter])
                {
                    missingNumber = i;
                    i++;
                    k--;
                    if (k == 0)
                    {
                        return missingNumber;
                    }
                }

                if (arrCounter < len)
                    arrCounter++;
                else
                {
                    missingNumber = i;
                    k--;
                    if (k == 0)
                    {
                        return missingNumber;
                    }
                }

                i++;

            }

            return missingNumber;
        }

        public int FindKthPositive_Others(int[] arr, int k)
        {
            int cntr = 0;
            int missing = 0;
            int answer = 0;
            for (int i = 1; i <= 2001 && missing < k; i++, answer++)
            {
                if (arr[cntr] != i) missing++;
                else if (cntr < arr.Length - 1) cntr++;
            }
            return answer;
        }

        private void btn_Max_Number_of_K_Sum_Pairs_Click(object sender, EventArgs e)
        {
            /*
            
                    You are given an integer array nums and an integer k.
                    In one operation, you can pick two numbers from the array whose sum equals k and remove them from the array.

                    Return the maximum number of operations you can perform on the array.
 
                    Example 1:
                    Input: nums = [1,2,3,4], k = 5
                    Output: 2
                    Explanation: Starting with nums = [1,2,3,4]:
                    - Remove numbers 1 and 4, then nums = [2,3]
                    - Remove numbers 2 and 3, then nums = []
                    There are no more pairs that sum up to 5, hence a total of 2 operations.
                    
                    Example 2:
                    Input: nums = [3,1,3,4,3], k = 6
                    Output: 1
                    Explanation: Starting with nums = [3,1,3,4,3]:
                    - Remove the first two 3's, then nums = [1,4,3]
                    There are no more pairs that sum up to 6, hence a total of 1 operation.
 

                    Constraints:

                    1 <= nums.length <= 105
                    1 <= nums[i] <= 109
                    1 <= k <= 109
                       Hide Hint #1  
                    The abstract problem asks to count the number of disjoint pairs with a given sum k.
                       Hide Hint #2  
                    For each possible value x, it can be paired up with k - x.
                       Hide Hint #3  
                    The number of such pairs equals to min(count(x), count(k-x)), unless that x = k / 2, where the number of such pairs will be floor(count(x) / 2).

                    Time Complexity     : O(N)
                    Space Complexity    : O(N)

             */

            StringBuilder result = new StringBuilder();
            List<Array2n> inputs = new List<Array2n>();
            inputs.Add(new Array2n() { Data = new int[] { 1,2,3,4 }, N = 5 });
            inputs.Add(new Array2n() { Data = new int[] { 3, 1, 3, 4, 3 }, N = 6 });            

            foreach (var input in inputs)
            {
                result.AppendLine($"Max Number of K-Sum Pairs : {this.MaxOperations(input.Data, input.N)}  or the given array { string.Join(",", input.Data)} and K : {input.N}");
            }

            MessageBox.Show(result.ToString());

        }


        public int MaxOperations(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0 || k == 0)
                return 0;

            /*
                [1,2,3,4], k = 5
                [3,1,3,4,3], k = 6
            */

            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (int i in nums)
            {
                if (dict.ContainsKey(i))
                    dict[i] = 1;
                else
                    dict[i]++;
            }

            int result = 0;
            int diff = 0;
            int temp1 = 0;
            int temp2 = 0;


            foreach (int i in nums)
            {
                diff = k - i;
                dict.TryGetValue(diff, out temp1);
                if (temp1 == 0)
                    continue;

                if (diff == i)
                {
                    if (temp1 > 1)
                    {
                        result++;
                        dict[i] -= 2;
                    }
                }
                else
                {
                    dict.TryGetValue(i, out temp2);
                    if ( temp2 > 0)
                    {
                        result++;
                        dict[diff]--;
                        dict[i]--;

                    }
                }
            }


            return result;

        }

        private void btn_Kth_Largest_Element_in_an_Array_Click(object sender, EventArgs e)
        {
            /*
                Find the kth largest element in an unsorted array. Note that it is the kth largest element in the sorted order, not the kth distinct element.

                Example 1:
                Input: [3,2,1,5,6,4] and k = 2
                Output: 5
                
                Example 2:
                Input: [3,2,3,1,2,4,5,5,6] and k = 4
                Output: 4
                Note:
                You may assume k is always valid, 1 ≤ k ≤ array's length.  
            
                Time Complexity     : O(NlogN)
                Space Complexity    : O(N)
             */

            StringBuilder result = new StringBuilder();
            List<Array2n> inputs = new List<Array2n>();
            inputs.Add(new Array2n() { Data = new int[] { 3, 2, 1, 5, 6, 4 }, N = 2 });
            inputs.Add(new Array2n() { Data = new int[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 }, N = 4 });

            foreach (var input in inputs)
            {
                result.AppendLine($"Kth Largest Element in an Array : {this.MaxOperations(input.Data, input.N)}  or the given array { string.Join(",", input.Data)} and K : {input.N}");
            }

            MessageBox.Show(result.ToString());
        }

        public int FindKthLargest(int[] nums, int k)
        {

            if (nums == null || nums.Length == 0)
                return 0;

            List<int> result = new List<int>();
            int index = 0;

            foreach (int i in nums)
            {
                index = Search(result, i);
                result.Insert(index, i);
            }

            return result[result.Count - k];


        }

        public int Search(List<int> data, int target)
        {
            int l = 0; int r = data.Count;
            int m = 0;
            while (l < r) // l = 3   r = 3    //1 2 3
            {
                m = (l + r) / 2; //2
                if (target > data[m])
                    l = m + 1;
                else
                    r = m;
            }

            return l;

        }

        private void btn_Find_the_Most_Competitive_Subsequence_Click(object sender, EventArgs e)
        {

            /*
                Given an integer array nums and a positive integer k, return the most competitive subsequence of nums of size k.

                An array's subsequence is a resulting sequence obtained by erasing some (possibly zero) elements from the array.

                We define that a subsequence a is more competitive than a subsequence b (of the same length) if in the first position where a and b differ, subsequence a has a number less than the corresponding number in b. 
               For example, [1,3,4] is more competitive than [1,3,5] because the first position they differ is at the final number, and 4 is less than 5.

 

                Example 1:

                Input: nums = [3,5,2,6], k = 2
                Output: [2,6]
                Explanation: Among the set of every possible subsequence: {[3,5], [3,2], [3,6], [5,2], [5,6], [2,6]}, [2,6] is the most competitive.
                Example 2:

                Input: nums = [2,4,3,3,5,4,9,6], k = 4
                Output: [2,3,3,4]
 

                Constraints:

                1 <= nums.length <= 105
                0 <= nums[i] <= 109
                1 <= k <= nums.length
                   Hide Hint #1  
                In lexicographical order, the elements to the left have higher priority than those that come after. Can you think of a strategy that incrementally builds the answer from left to right?
                
                Time Complexity         : O(N)
                Space Complexity        : O(N)
            */


            StringBuilder result = new StringBuilder();
            List<Array2n> inputs = new List<Array2n>();
            inputs.Add(new Array2n() { Data = new int[] { 3, 5, 2, 6 }, N = 2 });
            inputs.Add(new Array2n() { Data = new int[] { 2, 4, 3, 3, 5, 4, 9, 6 }, N = 4 });
            inputs.Add(new Array2n() { Data = new int[] { 71, 18, 52, 29, 55, 73, 24, 42, 66, 8, 80, 2 }, N = 3 });
            
            foreach (var input in inputs)
            {
                result.AppendLine($"Most Competitive Subsequence : {string.Join(",",this.MostCompetitive(input.Data, input.N))}  or the given array { string.Join(",", input.Data)} and K : {input.N}");
            }

            MessageBox.Show(result.ToString());

        }


        public int[] MostCompetitive(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0 || k == 0)
                return nums;

            Stack<int> s = new Stack<int>();
            int len = nums.Length;
            /*
                   [3,5,2,6], k = 2
                   [2,4,3,3,5,4,9,6], k = 4   L:7  Q: 2 i :2
            */

            for (int i = 0; i < len; i++)
            {
                while (s.Count > 0 && s.Peek() > nums[i] && (s.Count + len - i > k))
                {
                    s.Pop();
                }
                if (s.Count < k)
                    s.Push(nums[i]);
            }

            int[] result = new int[k];

            while (s.Count > 0)

                result[--k] = s.Pop();

            return result;
        }

        private void btn_Check_If_All_1s_Are_at_Least_Length_K_Places_Away_Click(object sender, EventArgs e)
        {
            /*
             
                Given an array nums of 0s and 1s and an integer k, return True if all 1's are at least k places away from each other, otherwise return False.

                Example 1:
                Input: nums = [1,0,0,0,1,0,0,1], k = 2
                Output: true
                Explanation: Each of the 1s are at least 2 places away from each other.
                
                Example 2:
                Input: nums = [1,0,0,1,0,1], k = 2
                Output: false
                Explanation: The second 1 and third 1 are only one apart from each other.
                
                Example 3:
                Input: nums = [1,1,1,1,1], k = 0
                Output: true
                
                Example 4:
                Input: nums = [0,1,0,1], k = 1
                Output: true
 

                Constraints:

                1 <= nums.length <= 105
                0 <= k <= nums.length
                nums[i] is 0 or 1
                   Hide Hint #1  
                Each time you find a number 1, check whether or not it is K or more places away from the next one. If it's not, return false.
            
                Time Complexity         : O(N)
                Space Complexity        : O(1)
             */

            StringBuilder result = new StringBuilder();
            List<Array2n> inputs = new List<Array2n>();
            inputs.Add(new Array2n() { Data = new int[] { 1, 0, 0, 0, 1, 0, 0, 1 }, N = 2 });
            inputs.Add(new Array2n() { Data = new int[] { 1, 0, 0, 1, 0, 1 }, N = 2 });
            inputs.Add(new Array2n() { Data = new int[] { 1, 1, 1, 1, 1 }, N = 0 });
            inputs.Add(new Array2n() { Data = new int[] { 0, 1, 0, 1 }, N = 1 });

            foreach (var input in inputs)
            {
                result.AppendLine($"Length K Places Away {(this.KLengthApart(input.Data, input.N) ? "" :" not ") }  exists for the given array { string.Join(",", input.Data)} and K : {input.N}");
            }

            MessageBox.Show(result.ToString());
        }
        public bool KLengthApart(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0)
                return false;


            int prevInd = -1;
            /*
                [1,0,0,0,1,0,0,1], k = 2
                [1,0,0,1,0,1], k = 2
                [1,1,1,1,1], k = 0
                [0,1,0,1], k = 1
            */
            for (int i = 0; i < nums.Length; i++)
            {
                if (prevInd > -1)
                {
                    if (nums[i] == 1)
                    {
                        if (i - prevInd - 1 < k)
                            return false;
                        prevInd = i;
                    }

                }
                else if (prevInd == -1 && nums[i] == 1)
                    prevInd = i;
            }
            return true;
        }

        private void btn_Maximum_Gap_Click(object sender, EventArgs e)
        {
            /*
            
                Given an integer array nums, return the maximum difference between two successive elements in its sorted form. If the array contains less than two elements, return 0.
                You must write an algorithm that runs in linear time and uses linear extra space.
                Example 1:
                Input: nums = [3,6,9,1]
                Output: 3

                Explanation: The sorted form of the array is [1,3,6,9], either (3,6) or (6,9) has the maximum difference 3.

                Example 2:
                Input: nums = [10]
                Output: 0
                Explanation: The array contains less than 2 elements, therefore return 0.

                Constraints:
                1 <= nums.length <= 104
                0 <= nums[i] <= 109
             
             */

            long t = 1L;

            StringBuilder result = new StringBuilder();
            List<int[]> inputs = new List<int[]>();
            inputs.Add(new int[] { 3, 6, 9, 1 });
            inputs.Add(new int[] { 10 });

            foreach (var input in inputs)
            {
                result.AppendLine($"Maximum Gap for the given array { string.Join(",", input)} is {this.MaximumGap(input)} ");
            }

            MessageBox.Show(result.ToString());
        }

        public int MaximumGap(int[] nums)
        {
            if (nums == null || nums.Length < 2)
                return 0;

            int max = 0;
            int temp = 0;
            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 1; i++)
            {
                temp = nums[i + 1] - nums[i];
                if (temp > max)
                    max = temp;
            }

            return max;

        }

        private void btn_Maximum_Area_of_a_Piece_of_Cake_After_Horizontal_and_Vertical_Cuts_Click(object sender, EventArgs e)
        {
            /*
                Given a rectangular cake with height h and width w, and two arrays of integers horizontalCuts and verticalCuts where horizontalCuts[i] is the distance from the top of the rectangular cake to the ith horizontal cut and similarly, 
                verticalCuts[j] is the distance from the left of the rectangular cake to the jth vertical cut.

                Return the maximum area of a piece of cake after you cut at each horizontal and vertical position provided in the arrays horizontalCuts and verticalCuts. Since the answer can be a huge number, 
                return this modulo 10^9 + 7.

               Refer this video https://www.youtube.com/watch?v=4XhuvNayp3E&t=297s

              |
              |  
             4----|-------|------------------------------------------------------------
              |   |       |
              |   |       |
             3-   |       |
              |   |       |
              |   |       |
             2----|-------|-------------------------------------------------------------
              |   |       |
              |   |       |
             1----|-------|-------------------------------------------------------------
              |   |       |
              |---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|
              0   1   2   3   4   5

                Example 1:
                Input: h = 5, w = 4, horizontalCuts = [1,2,4], verticalCuts = [1,3]
                Output: 4 
                Explanation: The figure above represents the given rectangular cake. Red lines are the horizontal and vertical cuts. After you cut the cake, the green piece of cake has the maximum area.

                Example 2:
                Input: h = 5, w = 4, horizontalCuts = [3,1], verticalCuts = [1]
                Output: 6
                Explanation: The figure above represents the given rectangular cake. Red lines are the horizontal and vertical cuts. After you cut the cake, the green and yellow pieces of cake have the maximum area.

                Example 3:
                Input: h = 5, w = 4, horizontalCuts = [3], verticalCuts = [3]
                Output: 9
 
                Constraints:

                2 <= h, w <= 10^9
                1 <= horizontalCuts.length < min(h, 10^5)
                1 <= verticalCuts.length < min(w, 10^5)
                1 <= horizontalCuts[i] < h
                1 <= verticalCuts[i] < w
                It is guaranteed that all elements in horizontalCuts are distinct.
                It is guaranteed that all elements in verticalCuts are distinct.

                   Hide Hint #1  
                        Sort the arrays, then compute the maximum difference between two consecutive elements for horizontal cuts and vertical cuts.
                   Hide Hint #2  
                        The answer is the product of these maximum values in horizontal cuts and vertical cuts.             

                Time Complexity  : O(2nlogn) which is O(nlogn)
                Space Complexity : O(1)
             */


            StringBuilder result = new StringBuilder();
            List<ArrayAndValue> inputs = new List<ArrayAndValue>();
            inputs.Add(new ArrayAndValue() { input1 = new int[] { 1, 2, 4 }, m = 3, input2 = new int[] { 1, 3 }, n = 4 });
            inputs.Add(new ArrayAndValue() { input1 = new int[] { 3,1 }, m = 5, input2 = new int[] {1 }, n = 4 });
            inputs.Add(new ArrayAndValue() { input1 = new int[] { 3 }, m = 5, input2 = new int[] { 3 }, n = 4 });
            

            foreach (var input in inputs)
            {
                                
                result.AppendLine($"Maximum Area of a Piece of Cake After Horizontal {string.Join(",", input.input1)} with height :{input.m} and Vertical Cuts {string.Join(",", input.input2)} with width  : {input.n}  is " +
                    $"{this.MaxArea(input.m, input.n, input.input1, input.input2)}");
            }

            MessageBox.Show(result.ToString());
        }

        public int MaxArea(int h, int w, int[] horizontalCuts, int[] verticalCuts)
        {
            int horiMax = 0;
            int vertMax = 0;
            Array.Sort(horizontalCuts);
            Array.Sort(verticalCuts);

            horiMax = GetDiffMax(horizontalCuts, h);
            vertMax = GetDiffMax(verticalCuts, w);


            return (horiMax * vertMax) % 1000000007;

        }

        private int GetDiffMax(int[] cuts, int m)
        {
            int len = cuts.Length;
            int max = 0;
            max = Math.Max(cuts[0], m - cuts[len - 1]);
            for (int i = 1; i < len; i++)
                max = Math.Max(cuts[i] - cuts[i - 1], max);
            return max;

        }

        private void btn_Open_the_Lock_Click(object sender, EventArgs e)
        {
            /*
             
                You have a lock in front of you with 4 circular wheels. Each wheel has 10 slots: '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'.
                The wheels can rotate freely and wrap around: for example we can turn '9' to be '0', or '0' to be '9'. Each move consists of 
                turning one wheel one slot.

                The lock initially starts at '0000', a string representing the state of the 4 wheels.

                You are given a list of deadends dead ends, meaning if the lock displays any of these codes, the wheels of the lock will stop 
                turning and you will be unable to open it.

                Given a target representing the value of the wheels that will unlock the lock, return the minimum total number of turns required  
                to open the lock, or -1 if it is impossible.

                Example 1:
                Input: deadends = ["0201","0101","0102","1212","2002"], target = "0202"
                Output: 6
                Explanation:
                A sequence of valid moves would be "0000" -> "1000" -> "1100" -> "1200" -> "1201" -> "1202" -> "0202".
                Note that a sequence like "0000" -> "0001" -> "0002" -> "0102" -> "0202" would be invalid,
                because the wheels of the lock become stuck after the display becomes the dead end "0102".
   
                Example 2:
                Input: deadends = ["8888"], target = "0009"
                Output: 1
                Explanation:
                We can turn the last wheel in reverse to move from "0000" -> "0009".
                
                Example 3:
                Input: deadends = ["8887","8889","8878","8898","8788","8988","7888","9888"], target = "8888"
                Output: -1
                Explanation:
                We can't reach the target without getting stuck.
    
                Example 4:
                Input: deadends = ["0000"], target = "8888"
                Output: -1
 

                Constraints:

                1 <= deadends.length <= 500
                deadends[i].length == 4
                target.length == 4
                target will not be in the list deadends.
                target and deadends[i] consist of digits only.
            
                Hide Hint #1  
                
                We can think of this problem as a shortest path problem on a graph: there are `10000` nodes (strings `'0000'` to `'9999'`), 
                and there is an edge between two nodes if they differ in one digit, that digit differs by 1 (wrapping around, so `'0'` and `'9'` differ by 1), and if *both* nodes are not in `deadends`.
             
                Time Complexity     : O(N^2 + A^4 + D) where
                                                    N is the number of digits in the lock  
                                                    A is the total number of digits from 0 to 9. 4 is number of digits in the lock
                                                    D is the number of deadlocks
                Space Complexity    : O(D + (N * 2)) where 
                                                        D is the number of deadlocks.
                                                        N is the number of digits in the lock. For each digits we will be storing 2 combination + & -1
                                                    
                                                    
             */

            StringBuilder result = new StringBuilder();
            List<ArrayAndValue> inputs = new List<ArrayAndValue>();
            inputs.Add(new ArrayAndValue() { stringinput = new string[] { "0201", "0101", "0102", "1212", "2002" }, stringVal = "0202" });
            inputs.Add(new ArrayAndValue() { stringinput = new string[] { "8888" }, stringVal = "0009" });
            inputs.Add(new ArrayAndValue() { stringinput = new string[] { "0000" }, stringVal = "8888" });


            foreach (var input in inputs)            
                result.AppendLine($" Open the Lock for the given deadlocks {string.Join(",", input.stringinput)} for the given target: {input.stringVal} is {OpenLock(input.stringinput, input.stringVal)} ");            

            MessageBox.Show(result.ToString());
        }
      
        public int OpenLock(string[] deadends, string target)
        {

            if (string.IsNullOrWhiteSpace(target) || deadends.Length == 0)
                return -1;

            int qSize = 0;
            int result = 0;
            string lck = string.Empty;
            Queue<string> q = new Queue<string>();
            q.Enqueue("0000");
            HashSet<string> hash = new HashSet<string>(deadends);
            if (hash.Contains("0000")) return -1;
            //{ "0201", "0101", "0102", "1212", "2002" }, stringVal = "0202" }
            while (q.Count > 0)
            {
                qSize = q.Count;
                for (int i = 0; i < qSize; i++)
                {
                    lck = q.Dequeue();
                    if (lck.Equals(target))
                        return result;
               
                    foreach (string str in GenerateCombination(lck))
                    {
                        if (!hash.Contains(str))
                        {
                            hash.Add(str);
                            q.Enqueue(str);
                        }
                    }
                }
                result++;
            }

            return -1;
        }


        private List<string> GenerateCombination(string key)
        {
            List<string> result = new List<string>();

            for (int i = 0; i < key.Length; i++)
            {
                int c = key[i] - '0';
                for (short d = -1; d <= 1; d += 2)
                    result.Add($"{key.Substring(0, i)}{(c + d + 10) % 10}{key.Substring(i + 1)}");
            }
            return result;

        }

        private void btn_Longest_Consecutive_Sequence_Click(object sender, EventArgs e)
        {
            /*
             
                Given an unsorted array of integers nums, return the length of the longest consecutive elements sequence.

                You must write an algorithm that runs in O(n) time.
                Example 1:
                Input: nums = [100,4,200,1,3,2]
                Output: 4
                Explanation: The longest consecutive elements sequence is [1, 2, 3, 4]. Therefore its length is 4.
                
                Example 2:
                Input: nums = [0,3,7,2,5,8,4,6,0,1]
                Output: 9 

                Constraints:

                0 <= nums.length <= 105
                -109 <= nums[i] <= 109
             
                Time Complexity     : O(N)
                Space Complexity    : O(N)

             */

            StringBuilder result = new StringBuilder();
            List<int[]> inputs = new List<int[]>();
            inputs.Add(new int[] { 100, 4, 200, 1, 3, 2 });
            inputs.Add(new int[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 });
            inputs.Add(new int[] { 9, 1, 4, 7, 3, -1, 0, 5, 8, -1, 6 });


            foreach (var input in inputs)
                result.AppendLine($"Longest Consecutive Sequence for the given integer {string.Join(",", input)} is {this.LongestConsecutive(input)} ");

            MessageBox.Show(result.ToString());

        }

        public int LongestConsecutive(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            HashSet<int> dict = new HashSet<int>();
            int min = 0;
            int currSeq = 0;
            int prevSeq = 0;
            foreach (int i in nums)
            {
                dict.Add(i);
                min = Math.Min(min, i);
            }

            for (int i = min; i <= nums.Length; i++)
            {
                if (dict.Contains(i))
                    currSeq++;
                else
                {
                    prevSeq = Math.Max(prevSeq, currSeq);
                    currSeq = 0;
                }
            }

            return Math.Max(prevSeq, currSeq);

        }

        private void btn_Min_Cost_Climbing_Stairs_Click(object sender, EventArgs e)
        {

            /*
                    You are given an integer array cost where cost[i] is the cost of ith step on a staircase. Once you pay the cost, you can either climb one or two steps.

                    You can either start from the step with index 0, or the step with index 1.

                    Return the minimum cost to reach the top of the floor.

 

                    Example 1:
                    Input: cost = [10,15,20]
                    Output: 15
                    Explanation: Cheapest is: start on cost[1], pay that cost, and go to the top.
                    
                    Example 2:
                    Input: cost = [1,100,1,1,1,100,1,1,100,1]
                    Output: 6
                    Explanation: Cheapest is: start on cost[0], and only step on 1s, skipping cost[3].
 
                    Constraints:
                    2 <= cost.length <= 1000
                    0 <= cost[i] <= 999
                       Hide Hint #1  
                    Say f[i] is the final cost to climb to the top from step i. Then f[i] = cost[i] + min(f[i+1], f[i+2]).             

                    Time Complexity     :       O(N)
                    Space Complexity    :       O(N)
             */


            StringBuilder result = new StringBuilder();
            List<int[]> inputs = new List<int[]>();
            inputs.Add(new int[] { 10, 15, 20 });
            inputs.Add(new int[] { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 });            

            foreach (var input in inputs)
                result.AppendLine($"Min Cost Climbing Stairs for the given integer {string.Join(",", input)} is {this.MinCostClimbingStairs(input)} ");

            MessageBox.Show(result.ToString());
        }

        public int MinCostClimbingStairs(int[] cost)
        {
            if (cost == null || cost.Length == 0)
                return 0;

            if (cost.Length == 1)
                return cost[0];

            if (cost.Length == 2)
                return Math.Min(cost[0], cost[1]);

            int[] steps = new int[cost.Length];
            steps[0] = cost[0];
            steps[1] = cost[1];

            for (int i = 2; i < cost.Length; i++)
                steps[i] = cost[i] + Math.Min(steps[i - 1], steps[i - 2]);


            return Math.Min(steps[cost.Length - 1], steps[cost.Length - 2]);
        }

        private void btn_Palindrome_Pairs_Click(object sender, EventArgs e)
        {


            /*
             
                Given a list of unique words, return all the pairs of the distinct indices (i, j) in the given list, so that the concatenation of the two words words[i] + words[j] is a palindrome.

                Example 1:

                Input: words = ["abcd","dcba","lls","s","sssll"]
                Output: [[0,1],[1,0],[3,2],[2,4]]
                Explanation: The palindromes are ["dcbaabcd","abcddcba","slls","llssssll"]
                Example 2:

                Input: words = ["bat","tab","cat"]
                Output: [[0,1],[1,0]]
                Explanation: The palindromes are ["battab","tabbat"]
                Example 3:

                Input: words = ["a",""]
                Output: [[0,1],[1,0]]
 

                Constraints:

                1 <= words.length <= 5000
                0 <= words[i].length <= 300
                words[i] consists of lower-case English letters.


                TC      : O(N*K^2)
                SC      : O(N)

             */


            StringBuilder result = new StringBuilder();
            List<string[]> inputs = new List<string[]>();
            inputs.Add(new string[] { "abcd", "dcba", "lls", "s", "sssll" });
            inputs.Add(new string[] { "bat", "tab", "cat" });


            foreach (var input in inputs)
            {
                result.AppendLine($"Palindrome Pairs for the given strings {string.Join(",", input)} is ");
                foreach (var r in this.PalindromePairs(input))
                    result.AppendLine($"{r[0]},{r[1]}");
            }

            MessageBox.Show(result.ToString());
        }

        public IList<IList<int>> PalindromePairs(string[] words)
        {

            IList<IList<int>> result = new List<IList<int>>();

            if (words == null || words.Length <= 1)
                return result;

            /*
                "abcd" ,"dcba"
                 "lls","s"
                 "lls","sssll"
                 "aba",""
                 "s","sssll"
            */

            Dictionary<string, int> dict = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
                if (!dict.ContainsKey(words[i]))
                    dict[words[i]] = i;

            int ind = 0;
            string reverse;

            if (dict.ContainsKey(""))
            {
                ind = dict[""];
                for (int i = 0; i < words.Length; i++)
                    if (ind != i && IsPalidrome(words[i]))
                    {
                        result.Add(new List<int> { i, ind });
                        result.Add(new List<int> { ind, i });
                    }
            }

            for (int i = 0; i < words.Length; i++)
            {
                reverse = string.Join("", words[i].Reverse<char>());
                if (dict.ContainsKey(reverse))
                {
                    ind = dict[reverse];
                    if (ind != i)
                        result.Add(new List<int>() { i, dict[reverse] });
                }
            }


            // "abcd", "dcba", "lls", "s", "sssll"
            string str;
            string l;
            string r;
            for (int i = 0; i < words.Length; i++)
            {
                str = words[i];

                for (int j = 1; j < str.Length; j++)
                {
                    l = str.Substring(0, j);
                    r = str.Substring(j);

                    if (IsPalidrome(l))
                    {
                        reverse = string.Join("", r.Reverse<char>());
                        if (dict.ContainsKey(reverse))
                        {
                            ind = dict[reverse];
                            if (i != ind)
                                result.Add(new List<int>() { ind, i });
                        }
                    }

                    if (IsPalidrome(r))
                    {
                        reverse = string.Join("", l.Reverse<char>());
                        if (dict.ContainsKey(reverse))
                        {
                            ind = dict[reverse];
                            if (i != ind)
                                result.Add(new List<int>() { i, ind });
                        }
                    }

                }
            }


            return result;


        }


        public bool IsPalidrome(string word)
        {
            int l = 0;
            int r = word.Length - 1;

            while (l < r)
            {
                if (word[l++] != word[r--])
                    return false;
            }

            return true;

        }

    }
}

 
