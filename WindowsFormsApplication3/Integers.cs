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

        private void btn_Generate_Pascal_Triangle_Click(object sender, EventArgs e)
        {
            /*
                Given a non-negative integer numRows, generate the first numRows of Pascal's triangle.

                In Pascal's triangle, each number is the sum of the two numbers directly above it.

                Example:

                Input: 5
                Output:
                [
                     [1],
                    [1,1],
                   [1,2,1],
                  [1,3,3,1],
                 [1,4,6,4,1]
                ] 

            Time Complexity :  O(n) where is 
            */

            StringBuilder result = new StringBuilder();
            List<IList<int>> datas = this.GeneratePascalTriange(6);
            foreach(var data in datas)
            {
                result.AppendLine($"{string.Join(" ", data)}");
            }

            MessageBox.Show(result.ToString());

        }

        private List<IList<int>> GeneratePascalTriange(int numRows)
        {
            if (numRows == 0)
            {
                return null;
            }

            List<IList<int>> result = new List<IList<int>>();
            List<int> datas = new List<int>();

            for (int i = 1; i <= numRows; i++)
            {
                datas.Clear();
                if (i == 1)
                {
                    datas.Add(1);
                }
                else if (i == 2)
                {
                    datas.Add(1);
                    datas.Add(1);
                }
                else
                {
                    datas.Add(1);
                    var t = result.Last();
                    for (int j = 0; j < t.Count - 1; j++)
                    {
                        datas.Add(t[j] + t[j + 1]);
                    }

                    datas.Add(1);
                }

                result.Add(new List<int>(datas));
            }

            return result;
        }

        private void btn_Generate_Pascal_Triangle_2_Click(object sender, EventArgs e)
        {
            /*
                Given a non-negative index k where k ≤ 33, return the kth index row of the Pascal's triangle.
                Note that the row index starts from 0. 
                Example:

                Input: 3
                Output: [1,3,3,1]
                Follow up:

                Could you optimize your algorithm to use only O(k) extra space?

                Time Complexity  : O(nk) where n is the number of generation of pascal triangle and k is the number of item in a generation
                Space Complexity : O(k) where k is the number in particular row generation;

             */


            int row = 4;
            IList<int> result = this.GetPascalTriangleRow(row);            
            MessageBox.Show($"The pascal row value is {string.Join(" ", result)} for the row {row}");

        }

        public IList<int> GetPascalTriangleRow(int rowIndex)
        {
            List<int> result = new List<int>();
            if (rowIndex < 0)
            {
                return result;
            }

            Queue<int> q = new Queue<int>();
            int i = 0;

            while (i <= rowIndex)
            {
                if (i == 0)
                {
                    q.Enqueue(1);
                }

                if (i == 1)
                {
                    q.Enqueue(1);
                }

                if (i > 1)
                {

                    int qc = q.Count;
                    int j = 0;
                    int c = 0;
                    int p = 0;
                    q.Enqueue(1);

                    while (j < qc)
                    {
                        if (p == 0 && c == 0)
                        {
                            c = q.Dequeue();
                        }
                        else
                        {
                            p = c;
                            c = q.Dequeue();
                            q.Enqueue(p + c);
                        }

                        j++;
                    }
                    q.Enqueue(1);
                }

                i++;
            }

            result.AddRange(q);
            return result;
        }

        private void btn_Day_of_the_Programmer_Click(object sender, EventArgs e)
        {
            /*
                Leap Years are any year that can be exactly divided by 4 (such as 2016, 2020, 2024, etc)
                except if it can be exactly divided by 100, then it isn't (such as 2100, 2200, etc)
                except if it can be exactly divided by 400, then it is (such as 2000, 2400)

                2020 is divisible by 4 and not divisible by 100

                2020 IS a Leap Year 


             */
            StringBuilder result = new StringBuilder();
            List<int> years = new List<int>();
            //years.Add(2100); //13.09.2100
            years.Add(2016); //12.09.2016
            //years.Add(1700); //12.09.1700
            years.Add(1800); //12.09.2016
            foreach (int year in years)
            {
                result.AppendLine($"256th day for the year {year} is {(this.DayOfProgrammer(year))}");
            }

            MessageBox.Show(result.ToString());

        }

        private string DayOfProgrammer(int year)
        {
            /*
                https://www.hackerrank.com/challenges/day-of-the-programmer/problem?h_r=next-challenge&h_v=zen&h_r=next-challenge&h_v=zen&h_r=next-challenge&h_v=zen&h_r=next-challenge&h_v=zen&h_r=next-challenge&h_v=zen             
                In the Julian calendar, leap years are divisible by ; in the Gregorian calendar, leap years are either of the following:
                Divisible by 400.
                Divisible by 4 and not divisible by 100.
             */

            string result = string.Empty;
            if (year <= 0)
            {
                return null;
            }

            int day = 256 - 243;

            bool isLeapYear = (year < 1918 && year % 4 == 0) || ((year % 400 == 0 || (year % 4 == 0 && year % 100 != 0)));
            if (year == 1918)
            {
                day += 13;
            }
            else
            {
                day = (isLeapYear ? day - 1 : day);
            }

            result = new DateTime(year, 8, 31).AddDays(day).ToString("dd.MM.yyyy");

            return result;

        }

    }
}

