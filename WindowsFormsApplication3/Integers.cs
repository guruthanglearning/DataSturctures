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

               Time Complexity : O(N*m)
               Space Complexity : O(N)
                
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
            int pow = 1;
            while(n > 0) //n = 255
            {
                reminder = n % 10;
                temp = this.GetRotateNumber(reminder);
                if (temp < 0)
                {
                    return false;
                }
                rotateNumber = rotateNumber + (temp * pow); // 522
                pow*=10;
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

                result.Add(datas);
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
                In the Julian calendar, leap years are divisible by 4 ; in the Gregorian calendar, 
                leap years are either of the following:
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

        private void btn_Drawing_Book_Click(object sender, EventArgs e)
        {
            /*
                https://www.hackerrank.com/challenges/drawing-book/problem?h_r=next-challenge&h_v=zen&h_r=next-challenge&h_v=zen&h_r=next-challenge&h_v=zen&h_r=next-challenge&h_v=zen&h_r=next-challenge&h_v=zen&h_r=next-challenge&h_v=zen&h_r=next-challenge&h_v=zen&h_r=next-challenge&h_v=zen
                Time Complexity : O(1)

             */

            StringBuilder result = new StringBuilder();
            List<Point> inputs = new List<Point>();
            inputs.Add(new Point() {X = 6, Y = 5 });
            inputs.Add(new Point() {X = 6, Y = 6 });
            inputs.Add(new Point() {X = 100, Y = 60});
            inputs.Add(new Point() {X = 100, Y = 30 });
            inputs.Add(new Point() {X = 83246, Y = 78132 });            
            foreach (Point input in inputs)
            {
                int n = input.X;
                int m = n;
                int p = input.Y;
                int minFlip = 0;
                if (n == 0 || p == 0 || p > n || n == p)
                {
                    minFlip = 0;
                }
                else
                {
                    if (m % 2 == 0)
                    {
                        m++;
                    }

                    minFlip = Math.Min(p / 2, (m - p) / 2);   
                }

                result.AppendLine($"Min flip for {p} page in total pages {n} is  {minFlip} ");
            }

            MessageBox.Show(result.ToString());
            


        }

        private void btn_Clock_Angle_Click(object sender, EventArgs e)
        {
          
            /*
             
            https://en.wikipedia.org/wiki/Clock_angle_problem
            
            Hour makes 360 degree in 12 hours with degree of angle as 0.5      
            Min makes 360 degree in 1 hour  with degree of angle as 6

            So we can use one of the below formula 

            Formula 1 :
                Hour angle = ((60 * hour) + M) * 0.5
                Min angle = 6 * Min
                HourMinAngle =  Math.Abs(Hour angle - Min angle)
                Angle = Math.Min(360 - HourMinAngle, HourMinAngle)
            
                Time Complexity : O(1)
                Space Complexity : O(1) 

             */

            List<Point> hourMins = new List<Point>();
            StringBuilder result = new StringBuilder();

            hourMins.Add(new Point() {X =12, Y = 45 });
            hourMins.Add(new Point() { X = 3, Y = 30 });
            hourMins.Add(new Point() { X = 14, Y = 23 });

            foreach (Point hourMin in hourMins)
            {
                result.AppendLine($"The angle is {(this.GetClockAngle(hourMin.X, hourMin.Y))} for the hour : {hourMin.X} and Min : {hourMin.Y} ");
            }

            MessageBox.Show(result.ToString());

        }

        public double GetClockAngle(int hour, int min)
        {
          
            if (hour < 0 || hour > 24 || min < 0 || min > 60)
            {
                return 0;
            }

            if (hour > 12)
            {
                hour -= 12;
            }
            
                
            if (hour == 12)
            {
                hour = 0;
            }

            if (min == 60)
            {
                min = 0;
                hour += 1;
            }

            double angle =  Math.Abs( (0.5 * ((60 * hour) + min)) - (6 * min));

            return Math.Min(360 - angle, angle);


        }

        private void btn_Happy_Numbers_Click(object sender, EventArgs e)
        {
            /* 
             
                A happy number is a number defined by the following process: Starting with any positive integer, replace the number by the sum of the squares of its digits, and repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1. Those numbers for which this process ends in 1 are happy numbers.

                Return True if n is a happy number, and False if not.

                Example: 

                Input: 19
                Output: true
                Explanation: 
                12 + 92 = 82
                82 + 22 = 68
                62 + 82 = 100
                12 + 02 + 02 = 1
             */

            List<int> inputs = new List<int>() { 19 };
            StringBuilder result = new StringBuilder();

            foreach(int input in inputs)
            {
                result.AppendLine($"{input} is {(this.IsHappy(input)? "" : "not") } happy number");
            }
            MessageBox.Show(result.ToString());
            

        }



        public bool IsHappy(int n)
        {

            if (n == 0 || n == 1)
            {
                return n == 1;
            }

            HashSet<int> dict = new HashSet<int>() { n};
            int sum = n;
            bool result = false;

            while (true)
            {
                sum = this.GetSumedNumber(sum);
                if (sum == 1)
                {
                    result = true;
                    break;
                }
                else if (dict.Contains(sum))
                {
                    result = false;
                    break;
                }
                else
                {
                    dict.Add(sum);
                }

            }
            return result;
        }

        private int GetSumedNumber(int n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }

            int q = n / 10;
            int r = n % 10;
            int sum = r * r;

            while (q > 0)
            {
                r = q % 10;
                sum += (r * r);
                q = q / 10;
            }

            return sum;
        }

        private void btn_Bitwise_AND_of_Numbers_Range_Click(object sender, EventArgs e)
        {
            /*
             
                Given a range [m, n] where 0 <= m <= n <= 2147483647, return the bitwise AND of all numbers in this range, inclusive.

                Example 1:

                Input: [5,7]
                Output: 4
                Example 2:

                Input: [0,1]
                Output: 0

                Time Complexity     : O(log N)
                Space Complexity    : O(1) 

             */

            StringBuilder result = new StringBuilder();
            List<Point> inputs = new List<Point>();
            inputs.Add(new Point() { X = 5, Y = 7 });

            foreach(var input in inputs)
            {
                result.AppendLine($"The number is {this.RangeBitwiseAnd(input.X, input.Y)} for the given bitwise AND of numbers range {input.X} and {input.Y}");
            }

            MessageBox.Show(result.ToString());

        }


        public int RangeBitwiseAnd(int m, int n)
        {

            int counter = 0;

            while (m!=n)
            {
                m >>= 1;
                n >>= 1;
                counter++;
            }

            m <<= counter;

            return m;
        }

        private void btn_Number_Complement_Click(object sender, EventArgs e)
        {
            /*
             
                Given a positive integer num, output its complement number. The complement strategy is to flip the bits of its binary representation.
 
                Example 1:

                Input: num = 5
                Output: 2
                Explanation: The binary representation of 5 is 101 (no leading zero bits), and its complement is 010. So you need to output 2.
                Example 2:

                Input: num = 1
                Output: 0
                Explanation: The binary representation of 1 is 1 (no leading zero bits), and its complement is 0. So you need to output 0.
 
                Time Complexity     : O(log N)
                Space Complexity    : O(1)

             */

            StringBuilder result = new StringBuilder();
            int[] inputs = new int[] { 5, 1, 2 };

           foreach(int input in inputs)
            {
                result.AppendLine($"Number complement is {this.FindComplement(input)} for the given number {input}");
            }

            MessageBox.Show(result.ToString());

            
        }

        public int FindComplement(int num)
        {
           
            int compliment = 0;
            int power = 1;
            while(num > 0)
            {
                compliment += (num % 2 == 0 ? 1 : 0) * power;
                num >>= 1;
                power*=2;
            }

            return compliment;


        }

        private void btn_Remove_K_Digits_Click(object sender, EventArgs e)
        {
            /*
                Given a non-negative integer num represented as a string, remove k digits from the number so that the new number is the smallest possible.

                Note:
                The length of num is less than 10002 and will be ≥ k.
                The given num does not contain any leading zero.
                Example 1:

                Input: num = "1432219", k = 3
                Output: "1219"
                Explanation: Remove the three digits 4, 3, and 2 to form the new number 1219 which is the smallest.
                Example 2:

                Input: num = "10200", k = 1
                Output: "200"
                Explanation: Remove the leading 1 and the number is 200. Note that the output must not contain leading zeroes.
                Example 3:

                Input: num = "10", k = 2
                Output: "0"
                Explanation: Remove all the digits from the number and it is left with nothing which is 0.
    
            */

            StringBuilder result = new StringBuilder();
            List<RemoveKDigits> inputs = new List<RemoveKDigits>();
            //inputs.Add(new RemoveKDigits() { Digits = "1432219", RemoveDigits = 3 });
            //inputs.Add(new RemoveKDigits() { Digits = "10200", RemoveDigits = 1 });
            //inputs.Add(new RemoveKDigits() { Digits = "10", RemoveDigits = 0 });
            inputs.Add(new RemoveKDigits() { Digits = "9", RemoveDigits = 1 });
            inputs.Add(new RemoveKDigits() { Digits = "123", RemoveDigits = 1 });


            foreach (var input in inputs)
            {
                result.AppendLine($"New digits is {this.RemoveKdigits(input.Digits, input.RemoveDigits)} for the given digits {input.Digits} and remove digits {input.RemoveDigits}");
            }

            MessageBox.Show(result.ToString());

        }

        public class RemoveKDigits
        {
            public string Digits;
            public int RemoveDigits;
        }

        public string RemoveKdigits(string num, int k)
        {
            if (k == 0 || string.IsNullOrEmpty(num))
                return num;
            
            Stack<char> stack = new Stack<char>();
            StringBuilder result = new StringBuilder();

            foreach(char c in num)
            {
               
                    while(stack.Count> 0 && (c - '0') < (stack.Peek() - '0') && k > 0)
                    {
                        stack.Pop();
                        k--;
                    }
                    if (!(stack.Count == 0 &&  c == '0' ))                       
                        stack.Push(c);               
            }

            
            while(stack.Count > 0)
            {
                if (k != 0)
                {
                    k--;
                    stack.Pop();
                    continue;
                }

                result.Insert(0, stack.Pop());
            }

            return result.Length == 0 ? "0" : result.ToString();
        }

        private void btn_Counting_Bits_Click(object sender, EventArgs e)
        {
           

            /*
                Given a non negative integer number num. For every numbers i in the range 0 ≤ i ≤ num calculate the number of 1's in their binary representation and return them as an array.

                Example 1:

                Input: 2
                Output: [0,1,1]
                Example 2:

                Input: 5
                Output: [0,1,1,2,1,2]
                Follow up:

                It is very easy to come up with a solution with run time O(n*sizeof(integer)). But can you do it in linear time O(n) /possibly in a single pass?
                Space complexity should be O(n).
                Can you do it like a boss? Do it without using any builtin function like __builtin_popcount in c++ or in any other language.
             
                Hint #1
                    You should make use of what you have produced already.
                Hint #2  
                    Divide the numbers in ranges like [2-3], [4-7], [8-15] and so on. And try to generate new range from previous.
                Hint #3  
                    Or does the odd/even status of the number help you in calculating the number of 1s?
             */

            StringBuilder result = new StringBuilder();
            List<int> inputs = new List<int>();
            inputs.Add(2);
            inputs.Add(5);

            foreach (var input in inputs)
            {
                result.AppendLine($"Counting bits is {string.Join(",", this.CountBits(input))} for the given digits {input}");
            }

            MessageBox.Show(result.ToString());

        }

        public int[] CountBits(int num)
        {
            int[] result = new int[num + 1];

            int rem = 0;
            int quo = 0;

            for (int i = 0; i <= num; i++)
            {
                if (i < 2)
                    result[i] = i;
                else
                {
                    rem = i % 2;
                    quo = i >> 1;
                    result[i] = result[quo] + rem;
                }
            }

            return result;
        }

        private void btn_Power_of_Two_Click(object sender, EventArgs e)
        {
            /*
             
                Given an integer, write a function to determine if it is a power of two.

                Example 1:
                Input: 1
                Output: true 
                Explanation: 20 = 1
                
                Example 2:
                Input: 16
                Output: true
                Explanation: 24 = 16
                
                Example 3:
                Input: 218
                Output: false

                Time Complexity         : O(log N)
                Space Complexity        : O(1)

             */

            StringBuilder result = new StringBuilder();
            List<int> inputs = new List<int>();
            inputs.Add(1);
            inputs.Add(16);
            inputs.Add(218);
            inputs.Add(-16);

            foreach (var input in inputs)
            {
                result.AppendLine($"The given integer {input} is {(this.IsPowerOfTwo(input) ? "": "not")} power of 2 ");
            }

            MessageBox.Show(result.ToString());

        }

        public bool IsPowerOfTwo(int n)
        {

            // We can also use (n & (n-1) == 0) to determine power of 2
            if (n <= 0)
                return false;
            
            while (n > 1)
            {
                if (n % 2 == 1)
                {
                    return false;
                }
                n >>= 1;
            } // you can also perform the above by checking this by AND operator n & 1 if its 0 then n>>=1 else return false
            return true;

        }

        private void btn_Permutation_Sequence_Click(object sender, EventArgs e)
        {
            /*
             
                    The set [1,2,3,...,n] contains a total of n! unique permutations.
                    By listing and labeling all of the permutations in order, we get the following sequence for n = 3:

                    "123"
                    "132"
                    "213"
                    "231"
                    "312"
                    "321"
                    Given n and k, return the kth permutation sequence.

                    Note:

                    Given n will be between 1 and 9 inclusive.
                    Given k will be between 1 and n! inclusive.
                    Example 1:

                    Input: n = 3, k = 3
                    Output: "213"
                    Example 2:

                    Input: n = 4, k = 9
                    Output: "2314"
                
                    Time Complexity     :  O(N)
                    Space Complexity    :  O(N)
             */




            StringBuilder result = new StringBuilder();
            Dictionary<int, int> inputs = new Dictionary<int, int>();
            inputs.Add(3, 3);
            inputs.Add(2, 3);
            inputs.Add(1, 3);
            inputs.Add(4, 9);



            foreach (var input in inputs.Keys)
            {
                result.AppendLine($"Permutation sequence for {inputs[input]} is {this.GetPermutation(inputs[input], input) } at the level  {input}");
            }

            MessageBox.Show(result.ToString());

        }


        public string GetPermutation(int n, int k)
        {

            if (k == 0)
                return n.ToString();

            StringBuilder result = new StringBuilder();
            List<int> input = new List<int>();
            List<int> fact = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                input.Add(i);
            }

            fact.Add(1);
            int p = 1;
            for (int i = 1; i < n; i++)
            {
                p *= i;
                fact.Add(p);
            }

           
            int index = 0;

           
            while (n > 1)
            {

                index = k / fact[n-1];
                index = (k % fact[n - 1] == 0 ? index - 1 : index);
                result.Append(input[index]);
                input.RemoveAt(index);
                k -= fact[n-1] * (index);
                n--;
            }

            result.Append(string.Join("",input));


            return result.ToString();
        }


        private void btn_Hamming_Distance_Click(object sender, EventArgs e)
        {

            



            /*

                The Hamming distance between two integers is the number of positions at which the corresponding bits are different.

                Given two integers x and y, calculate the Hamming distance.

                Note:
                0 ≤ x, y < 231.

                Example:

                Input: x = 1, y = 4

                Output: 2

                Explanation:
                1   (0 0 0 1)
                4   (0 1 0 0)
                       ↑   ↑

                The above arrows point to positions where the corresponding bits are different.

                Time Complexity     : O(N) where N is the number of bits in two numbers
                Space Complexity    : O(1)

            */
            List<Point> inputs = new List<Point>();
            inputs.Add(new Point() {X = 1, Y= 4 });
            
            StringBuilder result = new StringBuilder();

            foreach (var input in inputs)
            {
                result.AppendLine($"Hamming Distance between {input.X}  and {input.Y} is { this.HammingDistance(input.X, input.Y)} ");
            }

            MessageBox.Show(result.ToString());


        }

        public int HammingDistance(int x, int y)
        {

            int res = x ^ y;
            int dis = 0;

            while (res != 0)
            {
                if ((res & 1) != 0)
                    dis++;
                res >>= 1;

            }

            return dis;

        }

        private void btn_Pow_x_n_Click(object sender, EventArgs e)
        {
            /*
             
                Implement pow(x, n), which calculates x raised to the power n (xn).

                Example 1:

                Input: 2.00000, 10
                Output: 1024.00000
                Example 2:

                Input: 2.10000, 3
                Output: 9.26100
                Example 3:

                Input: 2.00000, -2
                Output: 0.25000
                Explanation: 2-2 = 1/22 = 1/4 = 0.25
                Note:

                -100.0 < x < 100.0
                n is a 32-bit signed integer, within the range [−231, 231 − 1]

            */

            List<PowerOf> inputs = new List<PowerOf>();
            inputs.Add(new PowerOf() { X = 1.00, N = int.MinValue });

            StringBuilder result = new StringBuilder();

            foreach (var input in inputs)
            {
                result.AppendLine($"Power ({input.X}, {input.N} ) {this.MyPow(input.X, input.N)}");
            }

            MessageBox.Show(result.ToString());

        


        }

        public class PowerOf
        {
            public double X;
            public int N;
        }


        public double MyPow(double x, int n)
        {

            double result = 0;
            long p = n;

            if (n < 0)
                result = 1 / (Pow(x, -p));
            else if (n == 0)
                result = 1;
            else
                result = Pow(x, n);

            return result;
        }

        private double Pow(double x, long n)
        {

            if (n == 1)
                return x;

            double result = 0;
            result = Pow(x * x, n / 2);

            if ((n % 2) == 1)
                result *= x;

            return result;
        }

        private void btn_Add_Digits_Click(object sender, EventArgs e)
        {
            /*
             
                Given a non-negative integer num, repeatedly add all its digits until the result has only one digit.

                Example:

                Input: 38
                Output: 2 
                Explanation: The process is like: 3 + 8 = 11, 1 + 1 = 2. 
                             Since 2 has only one digit, return it.
                Follow up:
                Could you do it without any loop/recursion in O(1) runtime?

                   Hide Hint #1  
                A naive implementation of the above process is trivial. Could you come up with other methods?
                   Hide Hint #2  
                What are all the possible results?
                   Hide Hint #3  
                How do they occur, periodically or randomly?
                   Hide Hint #4  
                You may find this Wikipedia article useful.

            */


            List<int> inputs = new List<int>();
            inputs.Add(38);
            inputs.Add(123);
            inputs.Add(8912);

            StringBuilder result = new StringBuilder();

            foreach (var input in inputs)
            {
                result.AppendLine($"Add Digits is {AddDigits(input)} for the given number is {input}");
            }

            MessageBox.Show(result.ToString());

        }



        public int AddDigits(int num)
        {
            int result = 0; ;

            while (true)
            {
                result += num % 10;
                num = num / 10;

                if (num < 10)
                {
                    result += num;
                    if (result < 10)
                        break;
                    num = result;
                    result = 0;
                }
            }

            return result;
        }

        private void btn_Power_of_Four_Click(object sender, EventArgs e)
        {
            /*             
                Given an integer (signed 32 bits), write a function to check whether it is a power of 4.

                Example 1:

                Input: 16
                Output: true
                Example 2:

                Input: 5
                Output: false
             
                Time Complexity     :   O(1)
                Space Complexity    :   O(1)

             */


            StringBuilder result = new StringBuilder();
            List<int> inputs = new List<int>();
            inputs.Add(1);
            inputs.Add(4);
            inputs.Add(7);
            inputs.Add(8);
            inputs.Add(15);
            inputs.Add(16);
            
            foreach (var input in inputs)
            {
                result.AppendLine($"The given integer {input} is {(this.IsPowerOfFour(input) ? "" : "not")} power of 4 ");
            }

            MessageBox.Show(result.ToString());

        }

        public bool IsPowerOfFour(int n)
        {
            return (n & (n - 1)) == 0 && (n % 3) == 1;
        }
    }
}

