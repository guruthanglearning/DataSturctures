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
    public partial class BitOperators : Form
    {

        /* Bitwise operations
         * 
            	    1	0	0               1   0   0           1   0   0
	                1	1	0               1   1   0           1   1   0
                    ----------              ---------           ----------
              Add   1	0	0           OR  1   1   0       XOR 0   1   0                                        
        */
        public BitOperators()
        {
            InitializeComponent();
        }

        private void btnCompute_XOR_for_the_given_number_Click(object sender, EventArgs e)
        {
            int input = 6;
            int result = 0;
            if (input % 4 == 0)
            {
                result = input;
            }
            else if (input%4 == 1)
            {
                result = 1;
            }
            else if (input%4 == 2)
            {
                result = ++input;
            }
            else if (input % 4 == 3)
            {
                result = 0;
            }

            MessageBox.Show(result.ToString());
            

        }
    }
}
