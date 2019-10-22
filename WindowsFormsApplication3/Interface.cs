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
    public partial class Interface : Form
    {
        public Interface()
        {
            InitializeComponent();
        }

        private void Making_Interface_Method_in_Derived_Class_As_Private_Click(object sender, EventArgs e)
        {
            // When we try to instaniate from Interface then Notifier becomes available when we try to 
            // instaniate from Notify class then Notify method does not become available.
            INotify n = new Notify();
            n.Notify();

        }
    }

    public interface INotify
    {
        void Notify();
    }

    public class Notify : INotify
    {
         void INotify.Notify()
        {
            MessageBox.Show("Made INotify.Notify as private method");
        }
        
    }

}
