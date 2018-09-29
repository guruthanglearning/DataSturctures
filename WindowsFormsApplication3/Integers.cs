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
            int input = -12345;
            int quotent = input/10;
            int reminder = 0;
            int reverseInput = input % 10;

            while ((Math.Abs(quotent)) > 0)
            {
                reminder = quotent % 10;
                quotent = quotent / 10;
                reverseInput = (reverseInput *  10) + (reminder);                                               
            }           

            MessageBox.Show($"Reverse Integer for {input.ToString()} is {reverseInput.ToString()}");
        }
    }
}
