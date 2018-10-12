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
    public partial class OopsConcepts : Form
    {
        public OopsConcepts()
        {
            InitializeComponent();
        }

        public class ProtectedAccessSpecifierBase
        {
            protected int data = 0;

            protected void Display(string input)
            {
                MessageBox.Show(this.GetType() + " " + input);
            }
        }

        public class ProtectedAccessSpecifierDerived : ProtectedAccessSpecifierBase
        {
           public void Display()
            {
                this.data = 100;
            }
        }



        private void btn_Protected_Access_Specifier_Click(object sender, EventArgs e)
        {
            ProtectedAccessSpecifierDerived b = new ProtectedAccessSpecifierDerived();
            b.Display();

        }

        abstract class AbstractClassCreatingInstance
        {
            public AbstractClassCreatingInstance()
            {

            }
        }

        private void btn_Abstract_Class_Click(object sender, EventArgs e)
        {
            AbstractClassCreatingInstance[] i = new AbstractClassCreatingInstance[10];
        }
    }
}
