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
    public partial class Integers : Form
    {
        public Integers()
        {
            InitializeComponent();
        }

        private void btn_Reverse_Integer_Click(object sender, EventArgs e)
        {          
            int input = -2147;
            int quotent = input/10;
            int reminder = 0;
            long reverseInput = input % 10;
             
            while (Math.Abs(quotent) > 0)
            {
                reminder = quotent % 10;
                quotent = quotent / 10;
                reverseInput = (reverseInput * 10) + (reminder);
                if (reverseInput > int.MaxValue || reverseInput < int.MinValue)
                {
                    reverseInput = 0;
                    break;
                }
            }

            MessageBox.Show($"Reverse Integer for {input.ToString()} is {reverseInput.ToString()}");
        }

        private void btn_Check_the_given_integer_is_Plandrom_Click(object sender, EventArgs e)
        {
            List<int> inputs = new List<int>() {121, -121, 10 };
            StringBuilder result = new StringBuilder();
            
            foreach (int x in inputs)
            {
                int divisor = 1;
                int processedInput = x;
                int lead = 0;
                int trail = 0;
                bool IsPalindrome = true;

                if (x < 0)
                {
                    IsPalindrome = false;
                }

                if (IsPalindrome)
                {
                    while (processedInput / divisor >= 10)
                    {
                        divisor *= 10;
                    }

                    while (processedInput != 0)
                    {
                        lead = processedInput / divisor; //121
                        trail = processedInput % 10;
                        if (lead != trail)
                        {
                            IsPalindrome = false;
                            break;
                        }

                        processedInput = (processedInput % divisor) / 10;
                        divisor /= 100;
                    }
                }
                result.Append($"The given number {x.ToString()} is {(IsPalindrome ? "" : "not")} Palndrome \n");
            }

            MessageBox.Show(result.ToString());
        }

        private void btn_Count_no_of_steps_can_be_climbed_for_the_given_N_Click(object sender, EventArgs e)
        {
            /*
             https://www.geeksforgeeks.org/count-ways-reach-nth-stair/
             https://www.youtube.com/watch?v=5o-kdjv7FD0&t=125s
             
             0,1,2,3,4
             0,1,2,4
             0,1,3,4
             0,2,3,4
             0,2,4             

             */

            int n = 4;
            int total = 0;
            if (n == 0 || n == 1)
            {
                total = 1;
            }
            else
            {
                int f = 1;
                int s = 1;             
                for (int i = 2; i <= n; i++)
                {
                    /*
                        f=1     s=2     total = 0
                        i=2     f=1     s=1     total = 2
                        i=3     f=1     s=2     total = 3
                        i=4     f=2     s=3     total = 5
                     */

                    total = 0;
                    total = f + s;
                    f = s;
                    s = total;
                }
            }

            MessageBox.Show($"There are {total.ToString()}  number of ways to climb for the given {n.ToString()} steps");

        }

        private int NumOfWaysToClimbSteps(int n, int[] x)
        {
            /* x is nothing but the no of steps allowed to take
             
                int n = 5;
                int[] stairs = new int[3] { 1, 3, 5 };
              
                steps[0]= 1  totalNoOfWaysToClimbStep = 0
                steps[1]= 1  i = 1 totalNoOfWaysToClimbStep = 1
                steps[2]= 1  i = 2 totalNoOfWaysToClimbStep = 1
                steps[3]= 2  i = 3 totalNoOfWaysToClimbStep = 2
                steps[4]= 3  i = 4 totalNoOfWaysToClimbStep = 3
                steps[5]= 5  i = 5 totalNoOfWaysToClimbStep = 5
                
             */

            int totalNoOfWaysToClimbStep = 0;
            int[] steps = new int[n + 1];
            steps[0] = 1;
            
            for (int i = 1; i <= n; i++)
            {
                totalNoOfWaysToClimbStep = 0;
                foreach (int j in x)
                {
                    if ((i-j) >= 0)
                    {
                        totalNoOfWaysToClimbStep += steps[i - j];
                    }
                }
                steps[i] = totalNoOfWaysToClimbStep;
            }

            return steps[n];
        }

        private void btn_No_of_ways_to_climb_N_staircase_for_the_give_X_staircase_Click(object sender, EventArgs e)
        {
            int n = 5; //n stairs
            int[] stairs = new int[3] { 1, 3, 5 }; // # of stairs

            /* 
              The below are the steps can be taken
                 0,1,3,5                 
                 0,1,5
                 0,3,5
                 0,5
             */

            
            MessageBox.Show($"There were {this.NumOfWaysToClimbSteps(n,stairs).ToString()} number of ways to climb {n.ToString()} stairs case for the given staircase {string.Join(",",stairs)} ");
        }

        private void btn_Rotated_Digits_Click(object sender, EventArgs e)
        {
             
            /*
                X is a good number if after rotating each digit individually by 180 degrees, we get a valid number that is different from X.  
                Each digit must be rotated - we cannot choose to leave it alone.

                A number is valid if each digit remains a digit after rotation. 0, 1, and 8 rotate to themselves; 2 and 5 rotate to each other; 6 and 9 rotate to each other, and the rest of the numbers do not rotate to any other number and become invalid.

                Now given a positive number N, how many numbers X from 1 to N are good?

                Example:
                Input: 10
                Output: 4
                Explanation: 
                There are four good numbers in the range [1, 10] : 2, 5, 6, 9.
                Note that 1 and 10 are not good numbers, since they remain unchanged after rotating.

                Time Complexity is O(N) where N is the input

             */

            int input = 12;
            int validNumbers = 0;
            
            for(int i = 0;i <=input; i++)
            {
                if (IsGoodNumber(i))
                {
                    validNumbers++;
                }
            }

            MessageBox.Show($"There were {validNumbers} numbers after rotating from 0.. {input}");
        }

        private bool IsGoodNumber(int n)
        {
            int originalNumber = n;
            int reminder = 0;
            int rotateNumber = 0;
            int temp = 0;
            int pow = 0;
            while(n > 0)
            {
                reminder = n % 10;
                temp = this.GetRotateNumber(reminder);
                if (temp < 0)
                {
                    return false;
                }
                rotateNumber = rotateNumber + (temp * (int)Math.Pow(10.0,pow)); // 522
                pow++;
                n = n / 10;

            }
            return originalNumber!= rotateNumber;
        }

        private int GetRotateNumber(int n)
        {
            if (n == 0 || n == 1 || n == 8)
            {
                return n;
            }

            int returnValue = -1;

            switch (n)
            {
                case 2:
                    {
                        returnValue = 5;
                        break;
                    }
                case 5:
                    {
                        returnValue = 2;
                        break;
                    }
                case 6:
                    {
                        returnValue = 9;
                        break;
                    }
                case 9:
                    {
                        returnValue = 6;
                        break;
                    }
                default:
                    {
                        returnValue = -1;
                        break;
                    }
            }

            return returnValue;




        }

    }
}

