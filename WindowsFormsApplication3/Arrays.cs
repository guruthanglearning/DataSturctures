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

        public double FindMedianSortedArrayNew(int[] nums1, int[] nums2)
        {

            /*
                int[] nums1 = new int[] {1 };
                int[] nums2 = new int[] { 2, 3, 4};
            */

            if ((nums1 == null || nums1.Length == 0) && (nums2==null || nums2.Length == 0))
            {
                return 0;
            }

            int m = nums1.Length;
            int n = nums2.Length;
            int total = m + n;
            int mid = total / 2;
            double median = 0;
            
            if (total % 2 == 0)
            {
                if (m==n)
                {
                    median = (nums1[mid-1] + nums2[mid -n]) / 2.0 ;
                }
                else if (m<n)
                {
                    if (m == 0)
                    {
                        median = (nums2[mid] + nums2[mid - 1]) / 2.0;
                    }
                    else if (mid > m)
                    {
                        median = (nums2[total - mid - 1] + nums2[total - n - 1]) / 2.0;
                    }
                }
                else if (n < m)
                {
                    if (mid > n)
                    {
                        median = (nums1[mid] + nums1[mid-1]) / 2.0;
                    }
                }
            }
            else
            {
                if (mid == 0)
                {
                    //Only 1 items is available in A or B arrays
                    median = nums1.Length == 1 ? nums1[0] : nums2[0];
                }
                else
                {
                    if (m > n)
                    {
                        median = nums1[mid];
                    }
                    else if (m > 0 && n>m)
                    {
                        median = nums2[mid - 1];
                    }
                    else
                    {
                        median = nums2[mid];
                    }

                }
            }
            
            return median;


        }

        public double findMedianSortedArrays(int[] A, int[] B)
        {

            /*             
                int[] nums1 = new int[] { 3, 4, 5  }; --A
                int[] nums2 = new int[] { 1,2, 3 }; --B

            */

            int m = A.Length;
            int n = B.Length;
            if (m > n)
            { // to ensure m<=n. Always maching array A is smalles array
                int[] temp = A; A = B; B = temp;
                int tmp = m; m = n; n = tmp;
            }

            
            int iMin = 0, iMax = m, halfLen = (m + n + 1) / 2;
            while (iMin <= iMax)
            {
                //iMin = 2 Max = 2

                int i = (iMin + iMax) / 2; // i = 2 
                int j = halfLen - i;       // j=1

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
                    if (i == 0)
                    {
                        maxLeft = B[j - 1];
                    }
                    else if (j == 0)
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
                    if (i == m)
                    {
                        minRight = B[j];
                    }
                    else if (j == n)
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
                Time Complexity         : O(log n)
                Space Complexity        : O(1)
                               
                At first, the searching range is [0, m][0,m]. And the length of this searching range will be reduced by half after each loop. 
                So, we only need log(m) loops. Since we do constant operations in each loop, so the time complexity is 
                O(log(m)). Since m <= n, so the time complexity is O(log(min(m,n))).               
                We only need constant memory to store 9 local variables, so the space complexity is O(1).
            */

            int[] nums1 = new int[] { 3, 4, 5 };
            int[] nums2 = new int[] { 1, 2, 3 };
            //MessageBox.Show(this.FindMedianSortedArrayNew(nums1, nums2).ToString()); This will work when nums1 value are smaller thank nums2 array values
            MessageBox.Show(this.findMedianSortedArrays(nums1, nums2).ToString());            

        }

        private void btn_Maximum_Rectangular_Area_in_Histogram_Click(object sender, EventArgs e)
        {
            /*
              Time Complexity is O(n)
              Space Complexity is O(2 logn)
            */

          
            int[] heights = new int[] { 1,2,4,2 };
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
                    while (histogram.Count > 0 &&  h < (int)histogram.Peek())
                    {
                        tempPos = (int)pos.Pop();
                        tempHist = (int)histogram.Pop();
                        largest = Math.Max(tempHist * (i - tempPos), largest);
                    }
                    histogram.Push(h);
                    pos.Push(tempPos);
                }

            }
            while (histogram.Count >0)
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

            int[] input = new int[] {1, 2, 3, 4, 10, 5 };
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

            string result = returnValue !=null ? "Empyt" : returnValue.Value ? "Sorted" : "Not Sorted";
            MessageBox.Show($"Given array is {result}");
            
        }

        private void btn_Union_and_Intersection_of_two_sorted_arrays_Click(object sender, EventArgs e)
        {
            
            /*
             Time Complexity is O(m+n) where m and n is the length of the input 1 and input 2 array respectivey
             http://www.geeksforgeeks.org/union-and-intersection-of-two-sorted-arrays-2/
            */
            int[] input1 = new int[] {1, 2, 3, 4, 5 };
            int[] input2 = new int[] { 3,5,7,9,11 };
            StringBuilder result = new StringBuilder();
            if (input1!=null && input1.Length > 0 && input2!= null && input2.Length > 0)
            {                                 
                int i = 0, j = 0;

                while (i < input1.Length && j< input2.Length)
                {
                    if (input1[i] < input2[j])
                    {
                        i++;
                    }
                    else if (input1[i] > input2[j])
                    {
                        j++;
                    }
                    else
                    {
                        result.Append(input1[i] + " ");
                        i++;
                        j++;
                    }
                }


                MessageBox.Show($"Interaction of two sorted arrays are {(result.Length > 0 ? result.ToString() : "none")}");

            }


        }

        private void btn_Find_Union_and_Intersection_of_two_unsorted_arrays_Click(object sender, EventArgs e)
        {
            /*
             Sort both the input arrays and find the union and intersect 
             Time Complexity -
                                Sorting using Merge sort would be O(m log m) + O(n log n) 
                                Union and Intersect would be  O(m+n)
                                Total Comlexity would be O(m log m) + O(m log n) + O(m+n)

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
            Interval[] input1 = new Interval[] {
                                                    new Interval(){Start = 1, End = 9},
                                                    new Interval(){Start = 2, End = 4},
                                                    new Interval(){Start = 4, End = 7},
                                                    new Interval(){Start = 6, End = 8}                                                    
                                                };
            
            if (input1!=null && input1.Length == 0)
            {
                MessageBox.Show("Input is empty");
            }

            StringBuilder overlapping = new StringBuilder();            
            Stack<Interval> stack = new Stack<Interval>();
            stack.Push(input1[0]);

            for(int i =1; i<input1.Length; i++ )
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
            
            while (stack.Count!=0)
            {
                Interval interval = stack.Pop();
                overlapping.Append($"{interval.Start.ToString()} {interval.End.ToString()} \n");
            }

            MessageBox.Show($"Overlapping pair: \n {overlapping.ToString()}"); 

        }

        // Utility function to find ceiling of r in arr[l..h]
        int FindCeil(int[] arr, int r, int l, int h)
        {
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
            int r = random.Next(1, prefix[n - 1]); //(random.Next(1, prefix[n-1]) % prefix[n - 1]) +1;

            // Find index of ceiling of r in prefix arrat
            int indexc = FindCeil(prefix, r, 0, n - 1);
            return arr[indexc];
        }

        private void btn_Random_number_generator_in_arbitrary_probability_distribution_fashion_Click(object sender, EventArgs e)
        {
            //https://www.geeksforgeeks.org/random-number-generator-in-arbitrary-probability-distribution-fashion/
            //Time Complexity   : O(n)
            //Space Complexity  : O(n)

            int[] arr = new int[] { 1, 2, 3};
            int[] freq = new int[] { 49, 0, 50};
            StringBuilder resultBuilder = new StringBuilder();

            // Use a different seed value for every run.

            // Let us generate 10 random numbers accroding to
            // given distribution
            for (int i = 0; i < 100; i++)
                resultBuilder.Append(this.Get_Arbitrary_Probability_Distribution_Fashion(arr, freq, arr.Length) + " " );

            MessageBox.Show($"Random number generator in arbitrary probability distribution {resultBuilder.ToString()}");

        }
    }
}
