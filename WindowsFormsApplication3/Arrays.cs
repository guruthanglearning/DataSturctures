using System;
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

            //int[] arr1 = new int[1];
            //arr1[0] = 0;

            //int[] arr2 = new int[1];
            //arr2[0] = 1;

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
                01 
                10
                ---
                11
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
                for (int i = 0; i < inArray.Length; i++) //0:   1:2      2:2      3:2      Sum = 3
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

            inputs.Add(new int[] { -1, 0, 1, 2, -1, -4 });
            inputs.Add(new int[] { 0, 0, 0 });
            inputs.Add(new int[] { 0, 0, 0, 0 });
            inputs.Add(new int[] { 1, -1, -1, 0 });
            inputs.Add(new int[] { 3, 0, -2, -1, 1, 2 });

            foreach (int[] input in inputs)
            {
                result.AppendLine($"The sum for the given array {string.Join(" ", input)} is");
                var temp = ThreeSum(input);
                foreach (var t in temp)
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
                HashSet<string> dict = new HashSet<string>();


                for (int i = 0; i <= nums.Length - 3; i++)
                {
                    l = i + 1;
                    r = nums.Length - 1;

                    while (l < r)
                    {
                        result = nums[i] + nums[l] + nums[r];
                        if (result == 0)
                        {
                            if (!dict.Contains($"{nums[i]},{nums[l]},{nums[r]}"))
                            {
                                var inList = new List<int>() { nums[i], nums[l], nums[r] };
                                list.Add(inList);
                                dict.Add($"{nums[i]},{nums[l]},{nums[r]}");
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

            for (int i = 0; i < nums.Length; i++) // -1, 2, 1, -4 }, find = 1 
            {
                l = i + 1;
                r = nums.Length - 1;

                while (l < r)
                {
                    cSum = nums[i] + nums[l] + nums[r];

                    if (Math.Abs(cSum - target) < min)
                    {
                        min = Math.Abs(cSum - target);
                        retSum = cSum;
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

            for (int i = 0; i < nums.Length; i++)
            {
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
                result.AppendLine($"H Index is {this.HIndex(input)} for the given input { string.Join(",", input)}");
            }

            MessageBox.Show(result.ToString());
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
    }        
}
 
