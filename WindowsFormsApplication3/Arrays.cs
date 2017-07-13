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
    public partial class Arrays : Form
    {
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
            arr2[0] = 8;
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
            while (true )
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
                        arr2Incr++;
                        arr1Incr++;

                    }
                    unique.Add(arr1[arr1Incr-1]);
                }             
                else
                {
                    break;
                }
            }

            if (arr1Incr<=arr1LastFilledIndex && arr2Incr > arr2Length)
            {
                while (arr1LastFilledIndex >= arr1Incr)
                {
                    arr1[arr1Length] = arr1[arr1LastFilledIndex];
                    arr1LastFilledIndex--;
                }
                arr2Incr = 0;
            }
            
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
            arr1[3] = 5;
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
            int[] input = new int[] { 1, 2 };
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

        private void Given_an_array_and_a_number_x_check_for_pair_in_Array_with_sum_as_x_Click(object sender, EventArgs e)
        {
            int[] input = new int[] { 1, 2, 10, 4, 6, 8, 8,-20 };
            MessageBox.Show(this.FindPairs(input, -16));
        }

        private void MajorityElement_Click(object sender, EventArgs e)
        {

        }
    }
}
