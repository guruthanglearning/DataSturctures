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
    public partial class BitOperators : Form
    {
        /* Bitwise operations
         * 
            4	    1	0	0               1   0   0           1   0   0
	        6       1	1	0               1   1   0           1   1   0
                    ----------              ---------           ----------
              Add   1	0	0           OR  1   1   0       XOR 0   1   0                                        
        */

        public BitOperators()
        {
            InitializeComponent();
        }

        private void btnCompute_XOR_for_the_given_number_Click(object sender, EventArgs e)
        {
            /*
                https://www.geeksforgeeks.org/calculate-xor-1-n/
                input = 6
                result = 1^2^3^4^5^6
                 01 -->1
                 10 -->2
                ------------
                 11
                 11--->3
                ------------
                 000
                 100---->4
                ------------
                 100
                 101---->5
               ------------
                 001
                 110---->6
               ------------
                 111
                 111--->7
               -------------
                0000
                1000

            Implementation result = 6
             110 -->6 &
             011 -->3 
             ------
             010-->2

             */
            int input = 6;
            int result = 0;            
            if (input % 4 == 0) // If n is a multiple of 4
                result = input;
            else if (input % 4 == 1) // If n%4 gives remainder 1
                result = 1;            
            else if (input % 4 == 2) // If n%4 gives remainder 2
                result = input + 1;
            else 
                result = 0;             // If n%4 gives remainder 3

            MessageBox.Show(result.ToString());
            

        }
    }
}
