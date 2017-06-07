﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class StringsManipulation : Form
    {
        private int elementLevel = -1;
        private int numberOfElements;
        private int[] permutationValue = new int[0];

        private char[] inputSet;
        public char[] InputSet
        {
            get { return inputSet; }
            set { inputSet = value; }
        }

        private int permutationCount = 0;
        public int PermutationCount
        {
            get { return permutationCount; }
            set { permutationCount = value; }
        }


        public StringsManipulation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isUniqueCharacter(textBox1.Text))
            {
                MessageBox.Show("All characters are unique chacorrect text");
            }
            else
            {
                MessageBox.Show("Has duplicates character text");
            }
        }

        private bool isUniqueCharacter(string str)
        {
            bool isTrue = true;

            bool[] characters = new Boolean[256];

            for (int i = 0; i < str.Length; i++)
            {
                int j = str[i];
                if (characters[j])
                {
                    isTrue = false;
                    break;
                }
                else
                {
                    characters[j] = true;
                }
            }

            return isTrue;
        }


        private bool isUniqueCharacter2(string str)
        {
            bool isTrue = true;

            int checker = 0;

            for (int i = 0; i < str.Length; i++)
            {
                int val = str[i] - 'a';

                if ((checker & (1 << val)) > 0)
                {
                    isTrue = false;
                }
                else
                {
                    checker |= (1 << val);
                }
            }

            return isTrue;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (isUniqueCharacter2(textBox1.Text))
            {
                MessageBox.Show("All characters are unique character text");
            }
            else
            {
                MessageBox.Show("Has duplicates character text");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StringBuilder data = new StringBuilder();
            foreach (char c in textBox1.Text)
            {
                if (data.ToString().IndexOf(c) == -1)
                {
                    data.Append(c);
                }
            }

            if (data.Length > 0)
            {
                MessageBox.Show(data.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != textBox2.Text.Length)
            {
                MessageBox.Show("No Anagrams");
                return;
            }
            int[] letters = new Int32[256];
            int num_unique_chars = 0;
            int num_completed_t = 0;
            char[] s_array = textBox1.Text.ToCharArray();
            foreach (char c in s_array)
            {
                if (letters[c] == 0)
                    num_unique_chars++;

                ++letters[c];
            }

            for (int i = 0; i < textBox2.Text.Length; i++)
            {
                int c = textBox2.Text[i];
                if (letters[c] == 0)
                {
                    MessageBox.Show("Found more of char c in t than in s.");
                    return;
                }
                --letters[c];
                if (letters[c] == 0)
                {
                    ++num_completed_t;
                    if (num_completed_t == num_unique_chars)
                    {
                        if (i == textBox2.Text.Length - 1)
                        {
                            MessageBox.Show("Anagram.");
                        }
                    }

                }

            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int spaceCount = 0, newLength = 0, length = 0;

            foreach (char c in textBox1.Text)
            {
                if (c.ToString() == " ")
                    spaceCount++;
            }

            newLength = textBox1.Text.Length + spaceCount * 2;
            length = textBox1.Text.Length;
            char[] data = new char[newLength];
            textBox1.Text = textBox1.Text + new string(' ', spaceCount * 2);
            data = textBox1.Text.ToCharArray();

            for (int i = length - 1; i >= 0; i--)
            {
                if (data[i] == ' ')
                {
                    data[newLength - 1] = '0';
                    data[newLength - 2] = '2';
                    data[newLength - 3] = '%';
                    newLength = newLength - 3;
                }
                else
                {
                    data[newLength - 1] = data[i];
                    newLength = newLength - 1;
                }
            }

            textBox1.Text = new string(data);
            MessageBox.Show(new String(data));
        }

        private void button6_Click(object sender, EventArgs e)
        {

            int[,] matrix = new int[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };
            int offset, first, last, top, n;
            n = matrix.GetUpperBound(0) + 1;
            StringBuilder builder = new StringBuilder();

            for (int a = 0; a < n; a++)
            {
                for (int b = 0; b < n; b++)
                {

                    builder.Append(matrix[a, b].ToString() + " , ");
                }
                builder.Append("\n");
            }

            builder.Append("\n \n");


            for (int layer = 0; layer < n / 2; layer++)
            {
                first = layer;
                last = n - 1 - layer;

                for (int i = first; i < last; i++)
                {
                    StringBuilder result = new StringBuilder();

                    offset = i - first;
                    top = matrix[first, i];
                    matrix[first, i] = matrix[last - offset, first];
                    matrix[last - offset, first] = matrix[last, last - offset];
                    matrix[last, last - offset] = matrix[i, last];
                    matrix[i, last] = top;

                    for (int a = 0; a < n; a++)
                    {
                        for (int b = 0; b < n; b++)
                        {

                            result.Append(matrix[a, b].ToString() + " , ");
                        }
                        result.Append("\n");
                    }
                    MessageBox.Show(result.ToString());
                }
            }



            for (int a = 0; a < n; a++)
            {
                for (int b = 0; b < n; b++)
                {

                    builder.Append(matrix[a, b].ToString() + " , ");
                }
                builder.Append("\n");
            }
            MessageBox.Show(builder.ToString());

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //int[,] matrix = new int[,] { { 0, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };
            int[,] matrix = new int[,] { { 0, 1, 2, 3 }, { 4, 5, 6, 7 }, { 8, 9, 10, 11 } };
            int rowSize, columnSize;
            rowSize = matrix.GetUpperBound(0) + 1;
            columnSize = matrix.GetLength(0);
            int[] row = new Int32[rowSize];
            int[] column = new Int32[columnSize];
            StringBuilder builder = new StringBuilder();

            for (int a = 0; a < rowSize; a++)
            {
                for (int b = 0; b < columnSize; b++)
                {

                    builder.Append(matrix[a, b].ToString() + " , ");
                }
                builder.Append("\n");
            }

            builder.Append("\n \n");

            for (int i = 0; i < rowSize; i++)
            {
                for (int j = 0; j < columnSize; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        row[i] = 1;
                        column[j] = 1;
                    }
                }
            }

            for (int i = 0; i < rowSize; i++)
            {
                for (int j = 0; j < columnSize; j++)
                {
                    if (row[i] == 1 || column[j] == 1)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }


            for (int a = 0; a < rowSize; a++)
            {
                for (int b = 0; b < columnSize; b++)
                {

                    builder.Append(matrix[a, b].ToString() + " , ");
                }
                builder.Append("\n");
            }

            MessageBox.Show(builder.ToString());

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Empty string");
            }

            char[] data = textBox1.Text.ToCharArray();
            int tail = 1;
            for (int i = 1; i < data.Length; i++)
            {

                for (int j = 0; j < tail; j++)
                {
                    if (data[i] == data[j])
                    {
                        data[tail] = ' ';
                        break;
                    }
                }

                //if (j == tail)
                //{
                //    data[tail] = data[j];                    
                //}                
                ++tail;

            }


            string str = new string(data);
            MessageBox.Show(str);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Empty string");
                return;
            }

            char[] data = textBox1.Text.ToCharArray();
            bool[] hit = new Boolean[256];
            hit[data[0]] = true;

            for (int i = 1; i < data.Length; i++)
            {
                if (!hit[data[i]])
                {
                    hit[data[i]] = true;
                }
                else
                {
                    data[i] = ' ';
                }
            }


            string str = new string(data);
            MessageBox.Show(str);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int end = 0, start = 0;
            int length = textBox1.Text.Length - 1;
            string sentenace = textBox1.Text;
            int countCharacters = 0;
            end = length;
            StringBuilder datas = new StringBuilder();
            int i;
            for (i = length; i >= 0; i--)
            {
                if (sentenace[i] == ' ')
                {
                    start = i + 1;
                    if (end - 1 != i)
                    {
                        datas.Append(sentenace.Substring(start, (end - start) + 1) + " ");
                        countCharacters++;
                    }
                    end = start - 1;
                }
            }

            start = i + 1;
            datas.Append(sentenace.Substring(start, (end - start) + 1) + " ");
            countCharacters++;
            MessageBox.Show(datas.ToString() + "\n No of words in a sentence:=" + countCharacters.ToString());

        }

        private void button11_Click(object sender, EventArgs e)
        {
            int[,] matrix = new int[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };
            int rowSize, columnSize, n;
            rowSize = matrix.GetUpperBound(0) + 1;
            columnSize = matrix.GetLength(0);
            StringBuilder builder = new StringBuilder();
            n = matrix.GetUpperBound(0) + 1;

            for (int a = 0; a < n; a++)
            {
                for (int b = 0; b < n; b++)
                {

                    builder.Append(matrix[a, b].ToString() + " , ");
                }
                builder.Append("\n");
            }

            builder.Append("\n \n");

            int left = 0, right = columnSize, top = 0, down = rowSize, i, j;
            int[,] spirialmatrix = new int[rowSize, columnSize];
            while (true)
            {

                for (j = left; j < right; j++)
                {
                    builder.Append(matrix[top, j].ToString() + " , ");
                }

                top++;
                if (left > right - 1 || top > down - 1)
                {
                    break;
                }

                for (i = top; i < down; i++)
                {
                    builder.Append(matrix[i, right - 1].ToString() + " , ");
                }

                right--;
                if (left > right - 1 || top > down - 1)
                {
                    break;
                }

                for (j = right - 1; j >= left; j--)
                {
                    builder.Append(matrix[down - 1, j].ToString() + " , ");
                }

                down--;
                if (left > right - 1 || top > down - 1)
                {
                    break;
                }

                for (i = down - 1; i >= top; i--)
                {
                    builder.Append(matrix[i, left].ToString() + " , ");
                }

                left++;
                if (left > right - 1 || top > down - 1)
                {
                    break;
                }
            }

            MessageBox.Show(builder.ToString());

        }

        private void button12_Click(object sender, EventArgs e)
        {
            int[,] matrix = new int[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };
            int rowSize, columnSize, n;
            rowSize = matrix.GetUpperBound(0) + 1;
            columnSize = matrix.GetLength(0);

            StringBuilder builder = new StringBuilder();
            n = matrix.GetUpperBound(0) + 1;

            for (int a = 0; a < n; a++)
            {
                for (int b = 0; b < n; b++)
                {

                    builder.Append(matrix[a, b].ToString() + " , ");
                }
                builder.Append("\n");
            }

            builder.Append("\n \n");

            MessageBox.Show(builder.ToString());



        }

        private void button13_Click(object sender, EventArgs e)
        {
            int maxNumbers = 20;
            int incr = 0;
            int result = incr;
            StringBuilder data = new StringBuilder();

            while (incr <= maxNumbers)
            {
                if (result > 10 && result % 10 != 0)
                {
                    result = result / 10;
                }
                else if (result > 0 && result < 10 && result != 10)
                {
                    data.Append(incr.ToString() + ",");
                    incr++;
                    result = incr;
                }
                else
                {
                    incr++;
                    result = incr;
                }
            }

            MessageBox.Show(data.ToString());

        }

        private void button14_Click(object sender, EventArgs e)
        {
            StringBuilder data = new StringBuilder();
            int[] arraydata = new int[] { 1, 2, 2, 1, 1, 1, 3, 4, 5, 5, 5 };
            int start = 0;
            int end = start + 1;
            int length = arraydata.Length;

            while (end < length)
            {

                while (end < length && arraydata[start] == arraydata[end])
                {
                    arraydata = Move(arraydata, length, end);
                    length = arraydata.Length;
                }
                start = end;
                end = start + 1;
                length = arraydata.Length;
            }

            for (int i = 0; i < arraydata.Length; i++)
            {
                data.Append(arraydata[i] + ",");
            }
            MessageBox.Show(data.ToString());

        }

        private int[] Move(int[] arraydata, int length, int end)
        {

            while (end < length - 1)
            {
                arraydata[end] = arraydata[end + 1];
                end++;
            }

            Array.Resize<int>(ref arraydata, length - 1);
            return arraydata;

        }

        private void button15_Click(object sender, EventArgs e)
        {

            MessageBox.Show(ConvertVowelsToUpper(textBox1.Text));

        }

        private string ConvertVowelsToUpper(string data)
        {
            StringBuilder returndata = new StringBuilder();
            if (data == null)
            {
                throw new NullReferenceException();
            }


            for (int i = 0; i < data.Length; i++)
            {
                switch (data[i])
                {
                    case 'a':
                        {
                            returndata.Append(data[i].ToString().ToUpper());
                            break;
                        }
                    case 'e':
                        {
                            returndata.Append(data[i].ToString().ToUpper());
                            break;
                        }
                    case 'i':
                        {
                            returndata.Append(data[i].ToString().ToUpper());
                            break;
                        }
                    case 'o':
                        {
                            returndata.Append(data[i].ToString().ToUpper());
                            break;
                        }
                    case 'u':
                        {
                            returndata.Append(data[i].ToString().ToUpper());
                            break;
                        }
                    default:
                        {
                            returndata.Append(data[i]);
                            break;
                        }
                }
            }

            return returndata.ToString();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            int[] array = new int[] { 1, 2, 3, 4, 5, 4, 3 };
            Hashtable table = new Hashtable();
            int m = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                table.Add(array[i], m++);
            }
            for (int i = 0; i < table.Count; i++)
            {
                MessageBox.Show(table[array[i]].ToString());

            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            //char[] inputSet = MakeCharArray(textBox1.Text);
            //CalcPermutation(0);
            //int? x = null; int y = x ?? -1;
            //MessageBox.Show(y.ToString());

            int[] array1 = new int[] { 1, 2, 3 };
            int[] array2 = new int[] { 1, 2, 3 };
            int[] sum = this.IncrementByIntArray(array1, array2);
            print(sum);
        }


        /// <summary>
        /// Sums two integer array
        /// </summary>
        /// <param name="intArray1">Source Array List1</param>
        /// <param name="intArray2">Source Array List2</param>
        /// <returns></returns>
        int[] IncrementByIntArray(int[] intArray1, int[] intArray2)
        {
            List<int> sum = new List<int>();
            int[] data = null;
            if (intArray1 != null && intArray2 != null)
            {
                int maxLengthForArray1 = intArray1.Length;
                int maxLengthForArray2 = intArray2.Length;

                int reminder = 0;
                while (maxLengthForArray1 > 0 || maxLengthForArray2 > 0)
                {
                    int result = (maxLengthForArray1 > 0 ? intArray1[maxLengthForArray1 - 1] : 0) +
                                  (maxLengthForArray2 > 0 ? intArray2[maxLengthForArray2 - 1] : 0);

                    sum.Add(result % 10 + reminder);
                    reminder = result / 10;
                    maxLengthForArray1--; maxLengthForArray2--;
                }

                if (reminder > 0)
                {
                    sum.Add(reminder);
                }

                data = new int[sum.Count];
                data = sum.Reverse<int>().ToArray();

            }
            else if (intArray1 == null && intArray2 == null)
            {
                data = null;
            }
            else if (intArray1 != null && intArray2 == null)
            {
                data = intArray1;
            }
            else if (intArray1 == null && intArray2 != null)
            {
                data = intArray2;
            }
            return data;
        }

        void print(int[] array)
        {
            StringBuilder data = new StringBuilder();
            if (array != null)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    data.Append(array[i].ToString() + ",");
                }
            }
            MessageBox.Show(data.ToString());
        }

        public char[] MakeCharArray(string InputString)
        {
            char[] charString = InputString.ToCharArray();
            Array.Resize(ref permutationValue, charString.Length);
            numberOfElements = charString.Length;
            return charString;
        }

        public void CalcPermutation(int k)
        {
            elementLevel++;
            permutationValue.SetValue(elementLevel, k);

            if (elementLevel == numberOfElements)
            {
                OutputPermutation(permutationValue);
            }
            else
            {
                for (int i = 0; i < numberOfElements; i++)
                {
                    if (permutationValue[i] == 0)
                    {
                        CalcPermutation(i);
                    }
                }
            }
            elementLevel--;
            permutationValue.SetValue(0, k);
        }

        private void OutputPermutation(int[] value)
        {
            foreach (int i in value)
            {
                Console.Write(inputSet.GetValue(i - 1));
            }
            Console.WriteLine();
            PermutationCount++;
        }

        private void StringsManipulation_Load(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            string inputJavaScript = @"// This function says 'hello' to the user
function sayHello() {
    var world = 'Hello';
    alert(world);
}";
            bool dontPerformReplacement = false;
            bool singleLineComments = false;
            char[] input = inputJavaScript.ToCharArray();
            for (int i = 0; i < inputJavaScript.Length; i++)
            {
                if (!dontPerformReplacement && inputJavaScript[i] == 47 && (inputJavaScript[i + 1] == 42))
                {
                    dontPerformReplacement = true;
                }
                else if (dontPerformReplacement && inputJavaScript[i] == 42 && inputJavaScript[i + 1] == 47)
                {
                    dontPerformReplacement = false;
                }
                else if (inputJavaScript[i] == 47 && inputJavaScript[i + 1] == 47)
                {
                    singleLineComments = true;
                }
                else if (singleLineComments && inputJavaScript[i] == 10)
                {
                    singleLineComments = false;
                }

                if (!dontPerformReplacement && !singleLineComments)
                {
                    if (inputJavaScript[i] == 39)
                    {
                        input[i] = (char)34;
                    }
                }
            }
            MessageBox.Show(new string(input));
        }

        private void button19_Click(object sender, EventArgs e)
        {
            string a = "ab";
            string b = "zsd";
            if (string.IsNullOrEmpty(a) && string.IsNullOrEmpty(b))
            {
                MessageBox.Show("Empty");
            }
            else if (string.IsNullOrEmpty(a) && !string.IsNullOrEmpty(b))
            {
                MessageBox.Show(b);
            }
            else if (!string.IsNullOrEmpty(a) && string.IsNullOrEmpty(b))
            {
                MessageBox.Show(a);
            }

            int aLength = a.Length;
            int bLength = b.Length;
            int maxLength = aLength >= bLength ? aLength : bLength;
            System.Text.StringBuilder returnString = new System.Text.StringBuilder();
            for (int i = 0; i < maxLength; i++)
            {
                if (i < aLength)
                {
                    returnString.Append(a[i]);
                }
                if (i < bLength)
                {
                    returnString.Append(b[i]);
                }
            }
            MessageBox.Show(returnString.ToString());
        }

        private void button20_Click(object sender, EventArgs e)
        {

            int currency = 1000000000;
            MessageBox.Show(this, NumberToWords(currency));
        }

        private string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000000) > 0)
            {
                words += NumberToWords(number / 1000000000) + " billion ";
                number %= 1000000000;
            }


            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            //MMMCMXCIX
            Dictionary<char, int> _romanMap = new Dictionary<char, int> { { 'I', 1 }, { 'V', 5 }, { 'X', 10 }, { 'L', 50 }, { 'C', 100 }, { 'D', 500 }, { 'M', 1000 } };
            string text = textBox1.Text;
            int totalValue = 0, prevValue = 0;
            foreach (var c in text)
            {
                if (_romanMap.ContainsKey(c))
                {
                    var crtValue = _romanMap[c];
                    totalValue += crtValue;
                    if (prevValue != 0 && prevValue < crtValue)
                    {
                        if ((prevValue == 1 && (crtValue == 5 || crtValue == 10)) ||
                           (prevValue == 10 && (crtValue == 50 || crtValue == 100)) ||
                            (prevValue == 100 && (crtValue == 500 || crtValue == 1000)))
                        {
                            totalValue -= 2 * prevValue;
                        }
                    }
                    prevValue = crtValue;
                }
            }
            MessageBox.Show(totalValue.ToString());

        }
    }
}