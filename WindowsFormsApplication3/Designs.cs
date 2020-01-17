using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Designs : Form
    {
        Timer t = new Timer();
        System.Timers.Timer timer = new System.Timers.Timer();
        public Designs()
        {
            InitializeComponent();
        }

        private void btn_Implementation_of_Timer_Class_Click(object sender, EventArgs e)
        {

            //timer.Elapsed += delegate { MessageBox.Show("In build Timer"); };
            //timer.Interval = 1000;
            //timer.Start();
            BackgroundWorker b = new BackgroundWorker();
            //b.DoWork += new DoWorkEventHandler( t.Subscribe(delegate { MessageBox.Show("Custom Timer"); }, 60000));

            btn_Implementation_of_Timer_Class_Suspend_Click(sender, e);
        }

        private void btn_Implementation_of_Timer_Class_Suspend_Click(object sender, EventArgs e)
        {
            //timer.Stop();
            if (t != null)
            {
                t.UnSubscribe();
            }
        }
    }

    interface ITime
    {
        void Subscribe(Action action, int milliSeconds);
        void UnSubscribe();
    }

    public class Timer : ITimer
    {
        Thread t = null;
        Thread t1 = null;
        public void Subscribe(Action action, int milliSeconds)
        {

            if (t == null)
            {
                while (true)
                {
                    t = new Thread(new ThreadStart(action));
                    t1 = new Thread(new ThreadStart(action));                    
                    t.Start();
                    t1.Start();
                    Thread.Sleep(3000);
                }
            }           
        }


       public void UnSubscribe()
       {
            if (t != null)
            {
                t.Abort();
            }
       }

    }

}
