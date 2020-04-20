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

        private void btn_Min_Stack_Click(object sender, EventArgs e)
        {
            MinStack minStack = new MinStack();
            minStack.Push(-2);
            minStack.Push(0);
            minStack.Push(-3);
            minStack.GetMin(); //Returns - 3.
            minStack.Pop();
            minStack.Top(); // Returns 0.
            minStack.GetMin(); // Returns - 2.

            
        }

        public class MinStack
        {

            /** initialize your data structure here. */

            Dictionary<int, MinForKey> dict;
            int i = 0;
            int min = 0;

            public MinStack()
            {
                dict = new Dictionary<int, MinForKey>();
            }

            public void Push(int x)
            {
                if (i > 0)
                {
                    min = dict[i].Min;
                    if (x < min)
                    {
                        min = x;
                    }
                }
                else
                {
                    min = x;
                }

                i++;
                dict[i] = new MinForKey() { Data = x, Min = min };
            }

            public void Pop()
            {
                if (i > 0)
                {
                    dict.Remove(i);
                    i--;
                }
            }

            public int Top()
            {
                if (i > 0)
                    return dict[i].Data;
                return 0;
            }

            public int GetMin()
            {
                if (i > 0)
                    return dict[i].Min;
                return 0;
            }

            public class MinForKey
            {
                public int Data;
                public int Min;
            }

        }

    }
}
