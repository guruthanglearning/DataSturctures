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
            int input = -1;
            int.TryParse(textBox1.Text, out input);
            int i = SquareRootForWholeNumber(input, input <3 ? input : input/2); //Complexity is O(log n)
            decimal j = SquareRootInCalculator(input); //Complexity is O(10)

            MessageBox.Show($"Square root For Whole number {input.ToString()} is {i.ToString()} \n In Calculator {input.ToString()} is {j.ToString()} ");
        }
        
        private decimal SquareRootInCalculator(decimal t)
        {
            //http://web.archive.org/web/20100330183043/http://nlindblad.org/2007/04/04/write-your-own-square-root-function
            decimal r = t / 2;
            for (int i = 0; i< 10; i++ ) {
                r = (r + (t / r)) / 2;
            }
            return r;

        }

        private int SquareRootForWholeNumber(int inputValue, int mid, int previous = 0)
        {
            int returnValue = -1;
            if (inputValue <=1)
            {
                return inputValue;
            }
 

            if (mid * mid == inputValue)
            {
                return mid;
            }
            else
            {
                if ((mid * mid) > inputValue)
                {
                    returnValue = SquareRootForWholeNumber(inputValue, mid / 2, mid);
                }
                else
                {
                    returnValue = SquareRootForWholeNumber(inputValue, (mid + previous) / 2, previous);
                }
            }            
            return returnValue;

        }
    }
}
