﻿using System;
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
            //inputs.Add(new ArrayContainterForSearch() { Input = new int[] { 3, 4, 5, 6, 1, 2 }, Search = 4 });
            //inputs.Add(new ArrayContainterForSearch() { Input = new int[] { 3, 4, 5, 6, 7, 1, 2 }, Search = 3 });
            //inputs.Add(new ArrayContainterForSearch() { Input = new int[] { 5, 6, 7, 8, 9, 10, 1, 2, 3, 4 }, Search = 11 });
            inputs.Add(new ArrayContainterForSearch() { Input = new int[] { 1, 3, 1, 1, 1 }, Search = 3 });


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
                result = this.SearchInRotatedSortedArray(input, search);
                output.Append($"Index of the given number {search} in the given array {string.Join(",",input)} is {result.ToString()}\n");
            }

            MessageBox.Show(output.ToString());

        }

        public int SearchInRotatedSortedArray(int[] nums, int target)
        {
            int? len = nums?.Length == 0 ? 0 : nums?.Length;
            if (len == 0)
            {
                return -1;
            }
            // 4,5,6,7,0,1,2, target = 0
            int start, end;
            start = 0; end = (int)len - 1;
            while (start <= end)
            {
                var mid = start + (end - start) / 2;
                if (nums[mid] == target)
                {
                    return mid; // return index of found number 
                }
                else if (nums[mid] >= nums[start])
                {
                    if (target >= nums[start] && target < nums[mid]) // 0 >= 4  && 0<= 7
                    {
                        end = mid - 1;
                    }
                    else
                    {
                        start = mid + 1;
                    }
                }
                else
                {
                    if (target > nums[mid] && target <= nums[end])  // 8 > 7 
                    {
                        start = mid + 1;
                    }
                    else
                    {
                        end = mid - 1;
                    }
                }

            }
            return -1;
        }



        class ArrayContainterForSearch
        {
            public int[] Input;
            public int Search;
        }

        private void btn_Search_in_Rotated_Sorted_Array_Duplicate_Click(object sender, EventArgs e)
        {


            /*
                Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.

                (i.e., [0,0,1,2,2,5,6] might become [2,5,6,0,0,1,2]).

                You are given a target value to search. If found in the array return true, otherwise return false.

                Example 1:

                Input: nums = [2,5,6,0,0,1,2], target = 0
                Output: true
                Example 2:

                Input: nums = [2,5,6,0,0,1,2], target = 3
                Output: false
                Follow up:

                This is a follow up problem to Search in Rotated Sorted Array, where nums may contain duplicates.
                Would this affect the run-time complexity? How and why?
             
                Time Complexity         : O(log N)
                Space Complexity        : O(1)
             
             */


            StringBuilder result = new StringBuilder();
            List<ArrayContainterForSearch> inputs = new List<ArrayContainterForSearch>();


            inputs.Add(new ArrayContainterForSearch() { Input = new int[] { 2, 5, 6, 0, 0, 1, 2 }, Search = 0 });
            inputs.Add(new ArrayContainterForSearch() { Input = new int[] { 2, 5, 6, 0, 0, 1, 2 }, Search = 3 });
            inputs.Add(new ArrayContainterForSearch() { Input = new int[] { 1 }, Search = 1 });
            inputs.Add(new ArrayContainterForSearch() { Input = new int[] { 3,1 }, Search = 1 });
            inputs.Add(new ArrayContainterForSearch() { Input = new int[] { 1, 3, 1, 1, 1 }, Search = 3 });

            
            foreach (var input in inputs)
            {

                result.AppendLine($"Given number {input.Search} for rotating array with duplicate  {string.Join(",", input.Input)} does {(this.SearchNumberInRotatingArrayWithDuplicate(input.Input, input.Search) ? "" : " not ")} exists ");
            }

            MessageBox.Show(result.ToString());
        }

        public bool SearchNumberInRotatingArrayWithDuplicate(int[] nums, int target)
        {

            if (nums == null || nums.Length == 0)
                return false;
            if (nums.Length == 0 || nums == null) return false;
            int l = 0, r = nums.Length - 1, mid = 0;
            while (l <= r)
            {
                mid = (l + r) / 2;
                if (nums[mid] == target) return true;
                else if (nums[l] < nums[mid])
                {
                    if (nums[l] <= target && nums[mid] > target)                    
                        r = mid - 1;
                    else 
                        l = mid + 1;
                }
                else if (nums[l] > nums[mid])
                {
                    if (nums[r] >= target && nums[mid] < target) 
                        l = mid + 1;
                    else 
                        r = mid - 1;
                }
                else 
                    l++;
            }
            return false;



        }
    }
}
