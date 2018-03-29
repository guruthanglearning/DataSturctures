using System;
using System.Collections;
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
    public partial class Stacks : Form
    {
        public Stacks()
        {
            InitializeComponent();
        }


        private void btn_Implement_Stack_as_a_queue_Click(object sender, EventArgs e)
        {
            StringBuilder result = new StringBuilder();
            StackAsQueue que = new StackAsQueue();
            que.Enque(1);
            que.Enque(2);
            que.Enque(3);
            que.Enque(4);

            while (true)
            {
                try
                {
                    result.Append($"{que.Deque().ToString()} ");
                }
                catch (Exception)
                {
                    break;
                }
            }

            MessageBox.Show($"Items in the Queues {result.ToString()}");



        }


        public class StackAsQueue
        {
            Stack queue;

            public StackAsQueue()
            {
                queue = new Stack();
            }

            public int Deque()
            {
                if (queue.Count == 0)
                {
                    throw new InvalidOperationException("Queue is empty");
                }

                if (queue.Count == 1)
                {
                    return (int)queue.Pop();
                }

                int item = (int)queue.Pop();
                int result = Deque();
                queue.Push(item);
                return result;
            }

            public void Enque(int input)
            {
                queue.Push(input);
            }
        }



    }
}
