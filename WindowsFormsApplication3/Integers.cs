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

        private void btn_Fizz_Buzz_Click(object sender, EventArgs e)
        {

            
            /*
            
                Write a program that outputs the string representation of numbers from 1 to n.

                But for multiples of three it should output “Fizz” instead of the number and for the multiples of five output “Buzz”. For numbers which are multiples of both three and five output “FizzBuzz”.

                Example:

                n = 15,

                Return:
                [
                    "1",
                    "2",
                    "Fizz",
                    "4",
                    "Buzz",
                    "Fizz",
                    "7",
                    "8",
                    "Fizz",
                    "Buzz",
                    "11",
                    "Fizz",
                    "13",
                    "14",
                    "FizzBuzz"
                ]

                Time Complexity     : O(N)
                Space Complexity    : O(1)
            */


            List<int> inputs = new List<int>();
            inputs.Add(1);
            inputs.Add(15);
            

            StringBuilder result = new StringBuilder();

            foreach (var input in inputs)
            {
                result.AppendLine($"Fizz Buzz is { string.Join(",", this.FizzBuzz(input))} for the given number is {input}");
            }

            MessageBox.Show(result.ToString());

        }


        public IList<string> FizzBuzz(int n)
        {
            List<string> result = new List<string>();
            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                    result.Add("FizzBuzz");
                else if (i % 5 == 0)    
                    result.Add("Buzz");
                else if (i % 3 == 0)
                    result.Add("Fizz");
                else
                    result.Add($"{i}");
            }

            return result;
        }

        private void btn_Combination_Sum_III_Click(object sender, EventArgs e)
        {
            /*
             
                 Find all possible combinations of k numbers that add up to a number n, given that only numbers from 1 to 9 can be used and each combination should be a unique set of numbers.

                Note:

                All numbers will be positive integers.
                The solution set must not contain duplicate combinations.
                Example 1:

                Input: k = 3, n = 7
                Output: [[1,2,4]]
                Example 2:

                Input: k = 3, n = 9
                Output: [[1,2,6], [1,3,5], [2,3,4]] 
             
             */


            List<TwoInt> inputs = new List<TwoInt>();
            inputs.Add(new TwoInt() {Input1 = 3, Input2 = 7 });
    


            StringBuilder result = new StringBuilder();

            foreach (var input in inputs)
            {
                temp.Clear();
                resultList.Clear();
                result.AppendLine($"Combination Sum 3 is { string.Join(",", this.CombinationSum3(input.Input1, input.Input2))} for the given K : {input.Input1}  and N: {input.Input2} ");
            }

            MessageBox.Show(result.ToString());

        }

        public class TwoInt
        {
            public int Input1;
            public int Input2;
        }

        List<IList<int>> resultList = new List<IList<int>>();
        List<int> temp = new List<int>();
        public IList<IList<int>> CombinationSum3(int k, int n)
        {

            GetSum(1, n, k);
            return resultList;
        }



        private void GetSum(int start, int n, int k)
        {
            if (temp.Count == k)
            {
                if (n == 0)
                    resultList.Add(new List<int>(temp));
                return;
            }

            for (int i = start; i < n; i++)
            {
                temp.Add(i);
                GetSum(start + 1, n - i, k);
                temp.Remove(temp.Count - 1);
            }



        }

        private void btn_Sequential_Digits_Click(object sender, EventArgs e)
        {
            /*
                An integer has sequential digits if and only if each digit in the number is one more than the previous digit.

                Return a sorted list of all the integers in the range [low, high] inclusive that have sequential digits.

 

                Example 1:

                Input: low = 100, high = 300
                Output: [123,234]
                Example 2:

                Input: low = 1000, high = 13000
                Output: [1234,2345,3456,4567,5678,6789,12345]
 

                Constraints:

                Hint #1  
                Generate all numbers with sequential digits and check if they are in the given range.
                
                Hint #2  
                Fix the starting digit then do a recursion that tries to append all valid digits.
             
                Time Complexity     : O(

             */


            List<TwoInt> inputs = new List<TwoInt>();
            inputs.Add(new TwoInt() { Input1 = 100, Input2 = 300 });
            inputs.Add(new TwoInt() { Input1 = 1000, Input2 = 13000 });

            StringBuilder result = new StringBuilder();

            foreach (var input in inputs)
            {
                temp.Clear();
                resultList.Clear();
                result.AppendLine($"Sequential Digits 3 is { string.Join(",", this.SequentialDigits(input.Input1, input.Input2))} for the given low: {input.Input1}  and high: {input.Input2} ");
            }

            MessageBox.Show(result.ToString());

        }

        public IList<int> SequentialDigits(int low, int high)
        {
            var result = new List<int>();
            var queue = new Queue<Tuple<int, int>>();

            for (var i = 1; i < 9; i++)
            {
                queue.Enqueue(Tuple.Create(i, i + 1));
            }

            while (queue.Count != 0)
            {
                var current = queue.Dequeue();
                var prevNum = current.Item1;
                var currentDigit = current.Item2;
                var currentNum = prevNum * 10 + currentDigit;
                if (currentNum > high) continue;
                if (currentNum >= low) result.Add(currentNum);
                if (currentDigit < 9) queue.Enqueue(Tuple.Create(currentNum, currentDigit + 1));
            }

            return result;
        }

        public IList<int> SequentialDigits_Mine(int low, int high)
        {
            string str = "123456789";
            SortedSet<int> dict = new SortedSet<int>();

            for (int i = 0; i < str.Length; i++)
                GenerateNumber(low, high, dict, str.Substring(i));

            return dict.ToList<int>();

        }

        private void GenerateNumber(int low, int high, SortedSet<int> dict, string str)
        {
            if (string.IsNullOrEmpty(str))
                return;

            int number = 0;
            int start = 0;
            while (start < str.Length)
            {
                number = (number * 10) + (str[start] - '0');
                if (number > high)
                    number = 0;
                else if (number >= low && number <= high && !dict.Contains(number))
                    dict.Add(number);

                start++;
            }

        }

        private void btn_Complement_of_Base_10_Integer_Click(object sender, EventArgs e)
        {
            /*
             
             Every non-negative integer N has a binary representation.  For example, 5 can be represented as "101" in binary, 11 as "1011" in binary, and so on.  
             Note that except for N = 0, there are no leading zeroes in any binary representation.

             The complement of a binary representation is the number in binary you get when changing every 1 to a 0 and 0 to a 1.  For example, the complement of "101" in binary is "010" in binary.

             For a given number N in base-10, return the complement of it's binary representation as a base-10 integer.
             
             Time Complexity        : O(1)
             Space Complexity       : O(1)

             */

            List<int> inputs = new List<int>();
            inputs.Add(5);
            inputs.Add(7);
            inputs.Add(10);

            StringBuilder result = new StringBuilder();

            foreach (var input in inputs)
            {
                result.AppendLine($"Complement of Base 10 integer is Other : {BitwiseComplement(input)}  Mine : {BitwiseComplement_My(input)} for the given number is {input}");
            }

            MessageBox.Show(result.ToString());
        }

        public int BitwiseComplement(int N)
        {

            return (N == 0 ? 1 : ((1 << Convert.ToString(N, 2).Length - 1) - 1) ^ N);

        }

        public int BitwiseComplement_My(int N)
        {

            
            
            string binary = Convert.ToString(N, 2);
            StringBuilder build = new StringBuilder();

            foreach (char c in binary)
            {
                build.Append($"{(c == '0' ? 1 : 0)}");
            }

            return Convert.ToInt32(build.ToString(), 2);

        }

        private void btn_Mirror_Reflection_Click(object sender, EventArgs e)
        {
            /*
              
                There is a special square room with mirrors on each of the four walls.  Except for the southwest corner, there are receptors on each of the remaining corners, numbered 0, 1, and 2.

                The square room has walls of length p, and a laser ray from the southwest corner first meets the east wall at a distance q from the 0th receptor.

                Return the number of the receptor that the ray meets first.  (It is guaranteed that the ray will meet a receptor eventually.)

 

                Example 1:

                Input: p = 2, q = 1
                Output: 2
                Explanation: The ray meets receptor 2 the first time it gets reflected back to the left wall.

                Note:

                1 <= p <= 1000
                0 <= q <= p

                Time Complexity         : O(1)
                Space Complexity        : O(1)
             
             */


            List<TwoInt> inputs = new List<TwoInt>();
            inputs.Add(new TwoInt() { Input1 = 2, Input2 = 1 });
            inputs.Add(new TwoInt() { Input1 = 3, Input2 = 1 });

            StringBuilder result = new StringBuilder();
            foreach (var input in inputs)
            {                
                result.AppendLine($"Mirror Relection for the given length of the wall {input.Input1} and east wall distance {input.Input2} is { this.MirrorReflection(input.Input1, input.Input2)} ");
            }

            MessageBox.Show(result.ToString());
        }

        public int MirrorReflection(int p, int q)
        {

            while (p % 2 == 0 && q % 2 == 0)
            {
                p /= 2;
                q /= 2;
            }

            if (p % 2 == 1 && q % 2 == 0) return 0; //p : reflection p : extension
            if (p % 2 == 0 && q % 2 == 1) return 2;
            if (p % 2 == 1 && q % 2 == 1) return 1;

            return -1;



        }

        private void btn_Smallest_Integer_Divisible_by_K_Click(object sender, EventArgs e)
        {
            /*
                Given a positive integer K, you need to find the length of the smallest positive integer N such that N is divisible by K, and N only contains the digit 1.

                Return the length of N. If there is no such N, return -1.

                Note: N may not fit in a 64-bit signed integer.

 

                Example 1:

                Input: K = 1
                Output: 1
                Explanation: The smallest answer is N = 1, which has length 1.
                Example 2:

                Input: K = 2
                Output: -1
                Explanation: There is no such positive integer N divisible by 2.
                Example 3:

                Input: K = 3
                Output: 3
                Explanation: The smallest answer is N = 111, which has length 3.
 

                Constraints:

                1 <= K <= 105
                   Hide Hint #1  
                11111 = 1111 * 10 + 1 We only need to store remainders modulo K.
                   Hide Hint #2  
                If we never get a remainder of 0, why would that happen, and how would we know that?
             
                Time Complexity         : O(K)
                Space Complexity        : O(1)
             */


            List<int> inputs = new List<int>();
            inputs.Add(1);
            inputs.Add(2);
            inputs.Add(3);

            StringBuilder result = new StringBuilder();
            foreach (var input in inputs)
            {
                result.AppendLine($"Smallest Integer Divisible by K: {input} is { this.SmallestRepunitDivByK(input)}");
            }

            MessageBox.Show(result.ToString());
        }

        public int SmallestRepunitDivByK(int K)
        {
            if (K % 2 == 0 || K % 5 == 0)
                return -1;

            int n = 1;
            int l = 1;

            while (n % K != 0)
            {
                n = ((n * 10) + 1) % K;
                l++;
            }

            return l;
        }

        private void btn_The_kth_Factor_of_n_Click(object sender, EventArgs e)
        {

            /*
             
                Given two positive integers n and k.
                A factor of an integer n is defined as an integer i where n % i == 0.
                Consider a list of all factors of n sorted in ascending order, return the kth factor 
                in this list or return -1 if n has less than k factors.

                Example 1:
                Input: n = 12, k = 3
                Output: 3
                Explanation: Factors list is [1, 2, 3, 4, 6, 12], the 3rd factor is 3.
                
                Example 2:
                Input: n = 7, k = 2
                Output: 7
                Explanation: Factors list is [1, 7], the 2nd factor is 7.
                
                Example 3:
                Input: n = 4, k = 4
                Output: -1
                Explanation: Factors list is [1, 2, 4], there is only 3 factors. We should return -1.
                
                Example 4:
                Input: n = 1, k = 1
                Output: 1
                Explanation: Factors list is [1], the 1st factor is 1.
                
                Example 5:
                Input: n = 1000, k = 3
                Output: 4
                Explanation: Factors list is [1, 2, 4, 5, 8, 10, 20, 25, 40, 50, 100, 125, 200, 250, 500, 1000].
 
                Constraints:

                1 <= k <= n <= 1000
                   Hide Hint #1  
                The factors of n will be always in the range [1, n].
                   Hide Hint #2  
                Keep a list of all factors sorted. Loop i from 1 to n and add i if n % i == 0. Return the kth factor if it exist in this list.

                Time Complexity     : O(N)
                Space Complexity    : O(1)
             
             */

            List<TwoInt> inputs = new List<TwoInt>();
            inputs.Add(new TwoInt() { Input1 = 12, Input2 = 3 });
            inputs.Add(new TwoInt() { Input1 = 7, Input2 = 2 });
            inputs.Add(new TwoInt() { Input1 = 4, Input2 = 4 });
            inputs.Add(new TwoInt() { Input1 = 1, Input2 = 1 });
            inputs.Add(new TwoInt() { Input1 = 1000, Input2 = 3 });

            StringBuilder result = new StringBuilder();
            foreach (var input in inputs)
            {
                result.AppendLine($"Kth factor of n for the given N :{input.Input1} and K : {input.Input2} is { this.KthFactor(input.Input1, input.Input2)}");
            }

            MessageBox.Show(result.ToString());

        }
        public int KthFactor(int n, int k)
        {

            int factCount = 0;
            for (int i = 1; i <= n; i++) // 12 3
            {
                if (n % i == 0)
                    factCount++;

                if (factCount == k)
                    return i;
            }

            return -1;
        }

        private void btn_Next_Greater_Element_III_Click(object sender, EventArgs e)
        {
            /*
                Given a positive integer n, find the smallest integer which has exactly the same digits existing in the integer n and is greater in value than n. If no such positive integer exists, return -1.

                Note that the returned integer should fit in 32-bit integer, if there is a valid answer but it does not fit in 32-bit integer, return -1.

 

                Example 1:

                Input: n = 12
                Output: 21
                Example 2:

                Input: n = 21
                Output: -1
 

                Constraints:

                1 <= n <= 231 - 1


                Time Complexity     : O(N) N is the Length of the integer
                Space Complexity    : O(N)
             
             */


            List<int> inputs = new List<int>();
            inputs.Add(12);
            inputs.Add(21);
            inputs.Add(1234321);
            inputs.Add(123456);
            inputs.Add(12222333);
            StringBuilder result = new StringBuilder();
            foreach (var input in inputs)
            {
                result.AppendLine($"Next Greater Element III: is { this.NextGreaterElement(input)} for the given integer value {input}");
            }

            MessageBox.Show(result.ToString());
        }

        public int NextGreaterElement(int n)
        {
            if (n == 0)
                return n;

            char[] digits = n.ToString().ToCharArray();

            int j = digits.Length - 1;
            int i = j - 1;
            long result = 0;
            string digitsResult = null;

            while (i >= 0 && digits[i] >= digits[i + 1])
                i--;

            if (i == -1)
                return -1;

            while (j > i && digits[j] <= digits[i])
                j--;

            Swap(digits, i, j);
            Reverse(digits, i+1);
            digitsResult = new string(digits);
            result = long.Parse(digitsResult);

            if (result > int.MaxValue || result <= n)
                return -1;
            else
                return int.Parse(digitsResult);


        }

        private void Reverse(char[] digits, int s)
        {
            if (digits == null || digits.Length == 0)
                return;

            int e = digits.Length - 1;


            while (s < e)
            {
                Swap(digits, s, e);
                s++;
                e--;
            }
        }

        private void Swap(char[] digits, int i, int j)
        {
            if (digits == null || digits.Length == 0)
                return;

            char t = digits[i];
            digits[i] = digits[j];
            digits[j] = t;
        }

        private void btn_Beautiful_Arrangement_Click(object sender, EventArgs e)
        {
            /*
                Suppose you have n integers labeled 1 through n. A permutation of those n integers perm (1-indexed) is considered a beautiful arrangement if for every i (1 <= i <= n), either of the following is true:

                perm[i] is divisible by i.
                i is divisible by perm[i].
                Given an integer n, return the number of the beautiful arrangements that you can construct.

                Example 1:
                Input: n = 2
                Output: 2
                Explanation: 
                The first beautiful arrangement is [1,2]:
                    - perm[1] = 1 is divisible by i = 1
                    - perm[2] = 2 is divisible by i = 2
                The second beautiful arrangement is [2,1]:
                    - perm[1] = 2 is divisible by i = 1
                    - i = 2 is divisible by perm[2] = 1
                
                Example 2:
                Input: n = 1
                Output: 1
                Constraints:

                1 <= n <= 15
             
                Time Complexity     : O(valid n! permutation)
                Space Complexity    : O(N+1)

             */


            List<int> inputs = new List<int>();
            inputs.Add(1);
            inputs.Add(2);
            inputs.Add(3);            
            StringBuilder result = new StringBuilder();
            foreach (var input in inputs)
            {
                result.AppendLine($"Beautiful Arrangement for the given integer value {input} is { this.CountArrangement(input)} ");
            }

            MessageBox.Show(result.ToString());



        }

        public int CountArrangement(int n)
        {
            int count = 0;
            CountBeautifulArrangement(n, 1, new bool[n+1], ref count);
            return count;
        }

        public void CountBeautifulArrangement(int n, int pos, bool[] visited, ref int count)
        {
            if (pos > n)
                count++;

            for(int i = 1; i<=n ; i++)
            {
                if (!visited[i] && ((pos%i) == 0 || (i % pos) == 0))
                {
                    visited[i] = true;
                    CountBeautifulArrangement(n, pos + 1, visited, ref count);
                    visited[i] = false;
                }
            }
        }

        private void btn_Get_Maximum_in_Generated_Array_Click(object sender, EventArgs e)
        {
            /*
                You are given an integer n. An array nums of length n + 1 is generated in the following way:

                nums[0] = 0
                nums[1] = 1
                nums[2 * i] = nums[i] when 2 <= 2 * i <= n
                nums[2 * i + 1] = nums[i] + nums[i + 1] when 2 <= 2 * i + 1 <= n
                Return the maximum integer in the array nums​​​.

                Example 1:

                Input: n = 7
                Output: 3
                Explanation: According to the given rules:
                  nums[0] = 0
                  nums[1] = 1
                  nums[(1 * 2) = 2] = nums[1] = 1
                  nums[(1 * 2) + 1 = 3] = nums[1] + nums[2] = 1 + 1 = 2
                  nums[(2 * 2) = 4] = nums[2] = 1
                  nums[(2 * 2) + 1 = 5] = nums[2] + nums[3] = 1 + 2 = 3
                  nums[(3 * 2) = 6] = nums[3] = 2
                  nums[(3 * 2) + 1 = 7] = nums[3] + nums[4] = 2 + 1 = 3
                Hence, nums = [0,1,1,2,1,3,2,3], and the maximum is 3.
                Example 2:

                Input: n = 2
                Output: 1
                Explanation: According to the given rules, the maximum between nums[0], nums[1], and nums[2] is 1.
                Example 3:

                Input: n = 3
                Output: 2
                Explanation: According to the given rules, the maximum between nums[0], nums[1], nums[2], and nums[3] is 2.
 

                Constraints:

                0 <= n <= 100
                   Hide Hint #1  
                Try generating the array.
                   Hide Hint #2  
                Make sure not to fall in the base case of 0. 

                Time Complexity     :   O(N)
                Space Complexity    :   O(N)

             */


            List<int> inputs = new List<int>();
            inputs.Add(7);
            inputs.Add(2);
            inputs.Add(3);
            inputs.Add(1);
            StringBuilder result = new StringBuilder();
            foreach (var input in inputs)
            {
                result.AppendLine($"Get Maximum in Generated Array is { this.GetMaximumGenerated(input)} for the given integer {input}");
            }

            MessageBox.Show(result.ToString());
        }

        public int GetMaximumGenerated(int n)
        {
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;

            int temp = 0;
            int[] result = new int[n + 1];
            result[0] = 0;
            result[1] = 1;

            int max = 1;
            

            /*

                  nums[(1 * 2) = 2] = nums[1] = 1
                  nums[(1 * 2) + 1 = 3] = nums[1] + nums[2] = 1 + 1 = 2
                  nums[(2 * 2) = 4] = nums[2] = 1
                  nums[(2 * 2) + 1 = 5] = nums[2] + nums[3] = 1 + 2 = 3
                  nums[(3 * 2) = 6] = nums[3] = 2
                  nums[(3 * 2) + 1 = 7] = nums[3] + nums[4] = 2 + 1 = 3

            */

            for (int i = 1; i <= n; i++)
            {
                temp = i * 2;
                if (temp + 1 > n)
                    break;
                result[temp] = result[i];

                result[temp + 1] = result[i] + result[i + 1];
                max = Math.Max(max, Math.Max(result[temp], result[temp + 1]));

                

            }

            return max;



        }

        private void btn_Count_Sorted_Vowel_Strings_Click(object sender, EventArgs e)
        {
            /*
             
                Given an integer n, return the number of strings of length n that consist only of vowels (a, e, i, o, u) and are lexicographically sorted.

                A string s is lexicographically sorted if for all valid i, s[i] is the same as or comes before s[i+1] in the alphabet.

 

                Example 1:

                Input: n = 1
                Output: 5
                Explanation: The 5 sorted strings that consist of vowels only are ["a","e","i","o","u"].
                Example 2:

                Input: n = 2
                Output: 15
                Explanation: The 15 sorted strings that consist of vowels only are
                ["aa","ae","ai","ao","au","ee","ei","eo","eu","ii","io","iu","oo","ou","uu"].
                Note that "ea" is not a valid string since 'e' comes after 'a' in the alphabet.
                Example 3:

                Input: n = 33
                Output: 66045
 

                Constraints:

                1 <= n <= 50 
                   Hide Hint #1  
                For each character, its possible values will depend on the value of its previous character, because it needs to be not smaller than it.
                   Hide Hint #2  
                Think backtracking. Build a recursive function count(n, last_character) that counts the number of valid strings of length n and whose first characters are not less than last_character.
                   Hide Hint #3  
                In this recursive function, iterate on the possible characters for the first character, which will be all the vowels not less than last_character, and for each possible value c, increase the answer by count(n-1, c).

                Time Complexity     : O(N6)
                Space Complexity    : O(N5)


                We can also achieve this in O(1) by implementing (N+4)(N+3)(N+2)(N+1)/24 which derieves from (N+4)!/N!4!
                

            */

            List<int> inputs = new List<int>();
            inputs.Add(1);
            inputs.Add(2);
            inputs.Add(33);
            
            StringBuilder result = new StringBuilder();
            foreach (var input in inputs)
            {
                result.AppendLine($"Count Sorted Vowel Strings is { this.CountVowelStrings(input)} for the given integer {input}");
            }

            MessageBox.Show(result.ToString());
        }


        public int CountVowelStrings(int n)
        {

            int[][] dp = new int[n+1][];

            for (int i = 0; i <= n; i++)
                dp[i] = new int[6];

            for(int i = 1; i<= n; i++)
                for(int j = 1; j<= 5;j++)                
                    dp[i][j] = (i > 1 ? dp[i-1][j] : 1) + dp[i][j-1];

            return dp[n][5];

        }

        private void btn_Concatenation_of_Consecutive_Binary_Numbers_Click(object sender, EventArgs e)
        {
            /*
                Given an integer n, return the decimal value of the binary string formed by concatenating the binary representations of 1 to n in order, modulo 109 + 7.
                Example 1:
                Input: n = 1
                Output: 1
                Explanation: "1" in binary corresponds to the decimal value 1. 
                
                Example 2:
                Input: n = 3
                Output: 27
                Explanation: In binary, 1, 2, and 3 corresponds to "1", "10", and "11".
                After concatenating them, we have "11011", which corresponds to the decimal value 27.
                
                Example 3:
                Input: n = 12
                Output: 505379714
                Explanation: The concatenation results in "1101110010111011110001001101010111100".
                The decimal value of that is 118505380540.
                After modulo 109 + 7, the result is 505379714.
 

                Constraints:

                1 <= n <= 105
                   Hide Hint #1  
                Express the nth number value in a recursion formula and think about how we can do a fast evaluation.
             
                Time Complexity         : O(N) 
                Space Complexity        : O(1) 

             */

            List<int> inputs = new List<int>();
            inputs.Add(1);
            inputs.Add(2);
            inputs.Add(3);
            inputs.Add(12);
            inputs.Add(42);

            StringBuilder result = new StringBuilder();
            foreach (var input in inputs)
            {
                result.AppendLine($"Concatenation of Consecutive Binary Numbers is { this.ConcatenatedBinary(input)} for the given integer {input}");
            }

            MessageBox.Show(result.ToString());
        }


        public int ConcatenatedBinary(int n)
        {

            
            int mod = 1000000007;
            long sum = 0;
            int len = 0;

            for (int i = 1; i <= n; i++)
            {
                if ((i & (i - 1)) == 0)
                    len++;

                sum = ((sum << len) | i) % mod;

            }

            return Convert.ToInt32(sum % mod);

        }
    }
}

