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
    public partial class Arrays : Form
    {
        public Arrays()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //int[] arr1 = new int[10];
            //arr1[0] = 4;
            //arr1[1] = 5;
            //arr1[2] = 6;
            //arr1[3] = 7;
            //arr1[4] = 8;
            //arr1[5] = 9;
            //arr1[6] = 10;
            //int[] arr2 = new int[3];
            //arr2[0] = 1;
            //arr2[1] = 2;
            //arr2[2] = 3; //Worst Case O(n+m)

            //int[] arr1 = new int[10];
            //arr1[0] = 1;
            //arr1[1] = 2;
            //arr1[2] = 3;
            //arr1[3] = 7;
            //arr1[4] = 8;
            //arr1[5] = 9;
            //arr1[6] = 10;
            //int[] arr2 = new int[3];
            //arr2[0] = 4;
            //arr2[1] = 5;
            //arr2[2] = 6;//Worst Case O(n+m)

            int[] arr1 = new int[10];
            arr1[0] = 1;
            arr1[1] = 2;
            arr1[2] = 3;
            arr1[3] = 4;
            arr1[4] = 5;
            arr1[5] = 6;
            arr1[6] = 7;
            int[] arr2 = new int[3];
            arr2[0] = 8;
            arr2[1] = 9;
            arr2[2] = 10; //Best Case O(n+m)


            MessageBox.Show($"Before Arr1 = {Display(arr1)} \n Arr2 = {Display(arr2)}");

            MergeArrays(arr1, arr2);
                
            //Merge(arr2, arr1);
            MessageBox.Show($"After Arr1 = {Display(arr1)} \n Arr2 = {Display(arr2)}");

        }

        void MergeArrays(int[] arr1, int[] arr2)
        {
            int arr1Length = arr1.Length-1;
            int arr1LastFilledIndex = this.GetLastFilledArrayIndex(arr1);
            int arr2Length = arr2.Length-1;            

            while(true)
            { 
                if (arr2Length < 0)
                {
                    break;
                }

                if (arr1LastFilledIndex >= 0 &&  arr1[arr1LastFilledIndex] > arr2[arr2Length])
                {
                    arr1[arr1Length] = arr1[arr1LastFilledIndex];
                    arr1[arr1LastFilledIndex] = 0;
                    arr1LastFilledIndex--;
                }
                else
                {
                    arr1[arr1Length] = arr2[arr2Length];
                    arr2Length--;                   
                }
                arr1Length--;
            }
        }

        private int GetLastFilledArrayIndex(int[] array)
        {
            int returnValue = -1;
            for(int i= 0; i<array.Length; i++)
            {
                if (array[i] == 0)
                {
                    returnValue =  i-1;
                    break;
                }
            }
            return returnValue;
        }

        private string Display(int[] arr)
        {
            StringBuilder builder = new StringBuilder();
            arr.ToList().ForEach(e => builder.Append($" {e.ToString()}"));
            return builder.ToString();

        }
    }
}
