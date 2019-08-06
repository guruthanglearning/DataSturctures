using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.UI;

namespace WindowsFormsApplication3
{
    public partial class Pairs : Form
    {
        public Pairs()
        {
            InitializeComponent();
        }

        private void btn_Cons_of_a_and_b_constr_a_pair_car_pair_and_cdr_pair_returns_1st_last_element_of_that_pair_Click(object sender, EventArgs e)
        {
            /*
             cons(a, b) constructs a pair, and car(pair) and cdr(pair) returns the first and last element of that pair. 
             For example, car(cons(3, 4)) returns 3, and cdr(cons(3, 4)) returns 4.
            Given this implementation of cons:

            def cons(a, b):
                def pair(f):
                    return f(a, b)
                return pair
            Implement car and cdr.
             */


            MessageBox.Show($"Car = {Car(new Constt(3, 4)).ToString()} Cdr = {Cdr(new Constt(3, 4)).ToString()}");

        
        }

        

        private object Car(Constt constt)
        {
            return constt.Pair.Item1;

        }

        private object Cdr(Constt constt)
        {
            return constt.Pair.Item2;

        }

        class Constt
        {
            public Tuple<object, object> Pair;

            public Constt (object a, object b)
            {
                if (Pair == null)
                {
                    Pair = new Tuple<object, object>(a, b);
                }                
            }
        }

        

        

    }
}
