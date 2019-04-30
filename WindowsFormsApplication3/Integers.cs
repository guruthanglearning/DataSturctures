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
            int input = 1534236462;
            int quotent = input/10;
            int reminder = 0;
            long reverseInput = input % 10;
             
            while ((Math.Abs(quotent)) > 0)
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
                        lead = processedInput / divisor;
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

        private void btn_Robbing_a_home_1_Click(object sender, EventArgs e)
        {

            /*
             Time Complexity is O(N)
             Space Complexity is O(1)              
             */
            int[][] inputs = new int[2][];
            inputs[0] = new int[] { 6, 7, 1, 3, 8, 2, 4 };
            inputs[1] = new int[] { 5, 3, 4, 11, 2 };
            StringBuilder result = new StringBuilder();
            int firstOld = 0;
            int secondOld = 0;
            int thirdOld = 0;
            foreach (int[] input in inputs)
            {
                firstOld = input[0];
                secondOld = Math.Max(firstOld, input[1]);
                int i = 0;
                for (i = 2; i < input.Length; i++)
                {                    
                    thirdOld = Math.Max(input[i] + firstOld, secondOld);
                    firstOld = secondOld;
                    secondOld = thirdOld;
                }
                //result.AppendLine($"The max value robbed in this house {string.Join(",", input)} is {dp[i-1].ToString()}");            
                result.AppendLine($"The max value robbed in this house {string.Join(",", input)} is {thirdOld.ToString()}");
            }

            MessageBox.Show(result.ToString());
        }
    }
}
