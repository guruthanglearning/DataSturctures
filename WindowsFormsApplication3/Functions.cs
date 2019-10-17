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
    public partial class Functions : Form
    {
        public Functions()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
                Implement int sqrt(int x).
                Compute and return the square root of x, where x is guaranteed to be a non-negative integer.
                Since the return type is an integer, the decimal digits are truncated and only the integer part of the result is returned.

                Example 1:

                Input: 4
                Output: 2
                Example 2:

                Input: 8
                Output: 2
                Explanation: The square root of 8 is 2.82842..., and since the decimal part is truncated, 2 is returned.
                
                Time Complexity     : O(log n)
                Space Complexity    : O(1)
                

             */

            StringBuilder result = new StringBuilder();
            List<int> inputs = new List<int>();
            inputs.Add(4);
            inputs.Add(8);
            inputs.Add(11);
            inputs.Add(int.MaxValue);

            foreach (int input in inputs)
            {
                result.AppendLine($"Square root For Whole number {input.ToString()} is {SquareRootForWholeNumber(input)}");
                    
            }
            
        
            //decimal j = SquareRootInCalculator(input); //Complexity is O(10)



            MessageBox.Show(result.ToString());
        }
        
        private decimal SquareRootInCalculator(decimal t)
        {
        //http://web.archive.org/web/20100330183043/
        //http://nlindblad.org/2007/04/04/write-your-own-square-root-function
            decimal r = t / 2;
            for (int i = 0; i< 10; i++ ) {
                r = (r + (t / r)) / 2;
            }
            return r;

        }

        private long SquareRootForWholeNumber(int inputValue)
        {            
            if (inputValue == 0 || inputValue == 1)
            {
                return inputValue;
            }

            int l = 0;
            int r = inputValue;
            int m = 0;
            

            while (l <= r)
            {
                m =   l + ((r - l) / 2);
                
                if (m == 0)
                {
                    break;
                }

                if (m == (inputValue/m))
                {
                    return m;
                }
                else if ( m < (inputValue / m))
                {
                    l = m + 1;                    
                }
                else
                {
                    r = m - 1;
                }
            }
            return r;
        }

        private void btn_Create_Job_Schedule_which_runs_function_for_a_given_milliseconds_Click(object sender, EventArgs e)
        {
            /*
              Implement a job scheduler which takes in a function f and an integer n, and calls f after n milliseconds.
             */             
            System.Timers.Timer timer = new System.Timers.Timer(2);
            timer.Elapsed += Print;
            timer.Start();
            timer.AutoReset = true;


        }

        private static void Print(Object source, System.Timers.ElapsedEventArgs s)
        {
            MessageBox.Show(DateTime.Now.ToString());
        }
    }
}
