using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace WindowsFormsApplication3
{
    public partial class StringsManipulation : Form
    {
        private int elementLevel = -1;
        private int numberOfElements;
        private int[] permutationValue = new int[0];
        private static int atoz = 126;
        private int counter = 0;
        List<char> vowel = new List<char>() { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
        int acounter = 1;


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


            //input =  abca
            /*
                Bit Operator 
                	1	0	0
	                1	1	0
                Add	1	0	0
                OR	1	1	0
                XOR	0	1	0

            Shift left(<<)	
                    23						
		            11	1					
		            5	1					
		            2	1					
		            1	0					
            7 bit	Binary      	0	0	1	0	1	1	1
	            Apply Shift Left	0	1	0	1	1	1	0
	            Hexa	            0	32	0	8	4	2	0
	            Result	            46						
								
            Shift right(>>)	
                    23						
		            11	1					
		            5	1					
		            2	1					
		            1	0					
	            Binary 	            0	0	1	0	1	1	1
	            Apply Shift Right	0	0	0	1	0	1	1
	            Hexa	            0	0	0	8	0	2	1
	            Result	            10						
            */

            int checker = 0;
            for (int i = 0; i < str.Length; i++) //abca
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
            /*
             abc & cba is Anagram
             abc & ceb is not Anagram
             */
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
                        MessageBox.Show("Anagram.");
                        //if (i == textBox2.Text.Length - 1)
                        //{
                        //    MessageBox.Show("Anagram.");
                        //}
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
                    newLength--;
                }
            }

            textBox1.Text = new string(data);
            MessageBox.Show(new String(data));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int[,] matrix = new int[,] {
                                            { 1, 2, 3, 4 },
                                            { 5, 6, 7, 8 },
                                            { 9, 10, 11, 12 },
                                            { 13, 14, 15, 16 }
                                      };

            int offset, first, last, top, n;
            n = matrix.GetLength(0);
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
                first = layer; //0
                last = n - 1 - layer; // 4-1-0= 3
                for (int i = first; i < last; i++)
                {
                    //StringBuilder result = new StringBuilder();
                    offset = i - first; //0
                    top = matrix[first, i];
                    matrix[first, i] = matrix[last - offset, first];
                    matrix[last - offset, first] = matrix[last, last - offset];
                    matrix[last, last - offset] = matrix[i, last];
                    matrix[i, last] = top;

                    //for (int a = 0; a < n; a++)
                    //{
                    //    for (int b = 0; b < n; b++)
                    //    {

                    //        result.Append(matrix[a, b].ToString() + " , ");
                    //    }
                    //    result.Append("\n");
                    //}
                    //MessageBox.Show(result.ToString());
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
            rowSize = matrix.GetLength(0);
            columnSize = matrix.GetLength(1);
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
            //abca tail = 3 i =3
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

            /*
                This is testing
            */

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
                    if (end != i)
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
            rowSize = matrix.GetLength(0);
            columnSize = matrix.GetLength(1);
            StringBuilder builder = new StringBuilder();
            n = matrix.GetLength(0);

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

                builder.Append("\n");
                for (i = top; i < down; i++)
                {
                    builder.Append(matrix[i, right - 1].ToString() + " , ");
                }

                right--;
                if (left > right - 1 || top > down - 1)
                {
                    break;
                }

                builder.Append("\n");
                for (j = right - 1; j >= left; j--)
                {
                    builder.Append(matrix[down - 1, j].ToString() + " , ");
                }

                down--;
                if (left > right - 1 || top > down - 1)
                {
                    break;
                }

                builder.Append("\n");
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
            n = matrix.GetLength(0);

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

            /* 
                Time Complexity :O(n)

             */
            int maxNumbers = 20;
            int incr = 1;
            int result = incr;
            StringBuilder data = new StringBuilder();

            //while (incr <= maxNumbers)
            //{
            //    if (result > 10 && result % 10 != 0)
            //    {
            //        result = result / 10;
            //    }
            //    else if (result > 0 && result < 10 && result != 10)
            //    {
            //        data.Append(incr.ToString() + ",");
            //        incr++;
            //        result = incr;
            //    }
            //    else
            //    {
            //        incr++;
            //        result = incr;
            //    }
            //}

            data.Append("\nSimple approach: \n ");
            incr = 1;
            while (incr <= maxNumbers)
            {

                if (incr % 10 > 0)
                {
                    data.Append(incr.ToString() + ",");
                }
                incr++;
            }

            MessageBox.Show(data.ToString());

        }

        private void button14_Click(object sender, EventArgs e)
        {
            StringBuilder data = new StringBuilder();
            int[] arraydata = new int[] { 1, 2, 2, 1, 1, 1, 3, 4, 5, 5, 5 };
            //int[] arraydata = new int[] { 1, 2, 3, 4, 5, 5 };
            int start = 0;
            int end = start + 1;
            int length = arraydata.Length;

            while (end < length)
            {
                if (arraydata[start] != arraydata[end])
                {
                    arraydata[++start] = arraydata[end];
                }
                end++;
            }
            Array.Resize<int>(ref arraydata, ++start);

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
            StringBuilder result = new StringBuilder();
            int checker = 0;

            for (int i = 0; i < array.Length; i++)
            {
                int val = array[i];

                if ((checker & (1 << val)) > 0)
                {
                    result.Append(array[i].ToString() + ",");
                }
                checker |= (1 << val);
            }

            MessageBox.Show($"Duplicate element in array is {result}");



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
                                  (maxLengthForArray2 > 0 ? intArray2[maxLengthForArray2 - 1] : 0) + reminder;

                    sum.Add(result % 10);
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


        // Given a list of m words, I’d like to query for the nth most frequent word(s). (e.g. Given 1000 words, tell me 


        private void btnLength_Of_Longest_Substring_Without_Repeating_Characters_Click(object sender, EventArgs e)
        {
            /*
                https://leetcode.com/problems/longest-substring-without-repeating-characters/description/
                iven a string, find the length of the longest substring without repeating characters.
                Examples:
                Given "abcabcbb", the answer is "abc", which the length is 3.
                Given "bbbbb", the answer is "b", with the length of 1.
                Given "pwwkew", the answer is "wke", with the length of 3. Note that the answer must be a substring, "pwke" is a subsequence and not a substring.

                Time Complexity  : O(n)
                Space Complexity : O(m) where m is the input character set
             */
            MessageBox.Show(this.lengthOfLongestSubstring("abcac").ToString());
        }


        public int lengthOfLongestSubstring(String s)
        {

            int n = s.Length, ans = 0;
            //using dictionary

            //Time Complexity  : O(n)
            //Space Complexity : O(m) where m is the input character set
            //Using array
            //int[] index = new int[128]; // current index of character
            // try to extend the range [i, j]
            //for (int j = 0, i = 0; j < n; j++)
            //{
            //    i = Math.Max(index[s[j]], i);
            //    ans = Math.Max(ans, j - i + 1);
            //    index[s[j]] = j + 1;
            //}


            /* 
             Time Complexity  : O(n)
             Space Complexity : O(min(m,n)) where m is the input character in the dictionary and n is the total input 
             character set
             
             Input = pwwkew

             abcac

             */
            n = s.Length; ans = 0;
            Dictionary<char, int> index = new Dictionary<char, int>();
            for (int j = 0, i = 0; j < n; j++)
            {
                if (index.ContainsKey(s[j]))
                {
                    i = Math.Max(index[s[j]], i);
                }

                ans = Math.Max(ans, j - i + 1); //
                index[s[j]] = j + 1; //
            }

            return ans;
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

            int currency = 1230000001;
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
            //1101
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
            Dictionary<char, int> _romanMap = new Dictionary<char, int> { { 'I', 1 }, { 'V', 5 }, { 'X', 10 },
                                                                          { 'L', 50 }, { 'C', 100 }, { 'D', 500 },
                                                                          { 'M', 1000 } };
            textBox1.Text = "MMMCMXCIX";
            string text = textBox1.Text;
            int totalValue = 0, prevValue = 0;
            foreach (var c in text)
            {
                if (_romanMap.ContainsKey(c))
                {
                    var crtValue = _romanMap[c]; //C
                    totalValue += crtValue; //4010
                    if (prevValue != 0 && prevValue < crtValue)
                    {
                        if ((prevValue == 1 && (crtValue == 5 || crtValue == 10)) ||
                           (prevValue == 10 && (crtValue == 50 || crtValue == 100)) ||
                            (prevValue == 100 && (crtValue == 500 || crtValue == 1000)))
                        {
                            totalValue -= 2 * prevValue;
                        }
                    }
                    prevValue = crtValue; //X
                }
            }
            MessageBox.Show(totalValue.ToString());

        }

        private void Query_nth_most_frequent_word_Click(object sender, EventArgs e)
        {
            int frequentWord = 2;
            string[] words = new string[] { "A", "A", "B", "B", "B", "B", "B", "B", "B", "B", "B", "C","C" };
            string word = this.GetNthMostFrequentWord(words, frequentWord);
            MessageBox.Show($"{frequentWord} frequent words from the given words {string.Join(",", words)} is {(word == null ? "is Nothing" : word)} ");

        }

        // the 5th most frequent word(s), or the 10th most frequent word(s) etc). Would like to query multiple times for 
        // different n’s. Solution should be optimized for querying.
        public string GetNthMostFrequentWord(string[] words, int nthFrequentWord)
        {
            if (words == null || nthFrequentWord == 0)
            {
                return null;
            }

            Dictionary<string, int> wordCount = new Dictionary<string, int>();
            Dictionary<int, HashSet<string>> freq = new Dictionary<int, HashSet<string>>();
            freq.Add(1, new HashSet<string>() {});
            string maxword = string.Empty;
            int freqKey = 0;
            foreach (string word in words)
            {
                if (wordCount.ContainsKey(word))
                {
                    freqKey = wordCount[word];
                    if (freq.ContainsKey(freqKey))
                    {
                        freq[freqKey].Remove(word);                        
                    }
                    freqKey++;
                    wordCount[word]= freqKey;
                    if (freq.ContainsKey(freqKey))
                    {
                        freq[freqKey].Add(word);
                    }
                    else
                    {
                        freq.Add(freqKey, new HashSet<string>() { word });
                    }
                }
                else
                {
                    wordCount.Add(word, 1);
                    freq[1].Add(word);
                }
            }

            string result = null;

            if (freq.ContainsKey(nthFrequentWord))
            {
                result = string.Join(" ", freq[nthFrequentWord]);
            }

            return result;
        }

        private void StringToInt_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.MyAtoi("52").ToString());
            List<string> inputs = new List<string>();
            inputs.Add("+1");
            inputs.Add("-+1");
            inputs.Add("4193 with words");
            inputs.Add("words and 987");
            inputs.Add("   -42");
            inputs.Add("42");
            inputs.Add("-91283472332");
            inputs.Add("      +0 123");
            inputs.Add("2147483648");
            inputs.Add("-   234");
            inputs.Add("-2147483647");

            StringBuilder outputs = new StringBuilder();
            outputs.Append("Results \n");

            int intValue = 0;
            bool isNegative = false;
            bool isResultAssigned = false;
            long result = 0;
            int continousplusMinus = 0;

            foreach (string str in inputs)
            {
                intValue = 0;
                isNegative = false;
                isResultAssigned = false;
                result = 0;
                continousplusMinus = 0;

                if (string.IsNullOrEmpty(str))
                {
                    result = 0;
                }

                foreach (char c in str)
                {
                    if (continousplusMinus == 2)
                    {
                        result = 0;
                        break;
                    }
                    if (isResultAssigned && !(c >= 48 && c <= 57)) // ascii for 0 is 48 and 9 is 57
                    {
                        break;
                    }
                    else if (c == 32) // ascii value of ' ' is 32
                    {
                        if (isResultAssigned || continousplusMinus > 0)
                        {
                            break;
                        }
                    }
                    else if (c == 43) // '+' is 43
                    {
                        if (isResultAssigned)
                        {
                            break;
                        }
                        continousplusMinus++;
                    }
                    else if (c == 45 && result == 0) //ascii code for '-' is 45
                    {
                        if (isResultAssigned)
                        {
                            break;
                        }
                        continousplusMinus++;
                        isNegative = true;
                    }
                    else if (char.IsNumber(c))
                    {
                        isResultAssigned = true;
                        intValue = Int32.Parse(c.ToString());
                        if (result == 0)
                        {
                            result = intValue;
                        }
                        else
                        {
                            result = (result * 10) + intValue;
                            if (result > int.MaxValue || result < int.MinValue)
                            {
                                result = isNegative ? int.MinValue : int.MaxValue;
                                isNegative = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                if (isNegative)
                {
                    result = result * -1;
                }

                outputs.Append($"{str} is {((int)result).ToString()} \n");
            }
            MessageBox.Show(outputs.ToString());

        }

        private void FibonociSeries_Click(object sender, EventArgs e)
        {
            //https://en.wikipedia.org/wiki/Fibonacci_number
            /* 
               If we look the bidirectional sequence of Fibonacci series for -ve values, -ve's are present for the even numbers like Fib(-2) Fib(-4) Fib (-6)
               so just multiply with - for the fib when n is even number.

                    F−8	F−7	F−6	F−5	F−4	F−3	F−2	F−1	F0	F1	F2	F3	F4	F5	F6	F7	F8
                    −21	13	−8	5	−3	2	−1	1	0	1	1	2	3	5	8	13	21
             
            */
            int input = int.Parse(textBox1.Text);

            bool isNegativeInput = !(input > 0);

            input = (isNegativeInput ? -1 : 1) * input;

            int previous = 0;
            int current = 0;

            int temp = 0;
            int i = 0;
            for (i = 1; i <= input; i++)
            {
                if (i == 1)
                {
                    current = 1;
                }
                else
                {
                    temp = previous;
                    previous = current;
                    current = current + temp;                    
                }
            }

            if (isNegativeInput)
            {
                if ((i -1) % 2 == 0)
                {
                    current *= -1;
                }
            }


            MessageBox.Show($"Fibonacci Series of {textBox1.Text} : {current.ToString()}");
        }

        private int GetPalindromes(string input, int start, int end)
        {
            // Base Case 1: If there is only 1 character
            if (start == end)
                return 1;

            // Base Case 2: If there are only 2 characters and both are same
            if (input[start] == input[end] && start + 1 == end)
            {
                return 2;
            }
            else
            {

                // If the first and last characters match
                if (input[start] == input[end])
                    return GetPalindromes(input, start + 1, end - 1) + 2;

                // If the first and last characters do not match
                return Math.Max(GetPalindromes(input, start, end - 1), GetPalindromes(input, start + 1, end));
            }
        }

        private void Longest_Palondrome_in_a_given_string_Click(object sender, EventArgs e)
        {
            //http://www.geeksforgeeks.org/dynamic-programming-set-12-longest-palindromic-subsequence/
            // Time Complexity : O(n^2)
            string input = "GEEKSFORGEEKS";
            MessageBox.Show($"Max Palondrom sequence {this.GetPalindromes(input, 0, input.Length - 1)}");
        }


        private void Longest_Palondrome_in_a_given_string_O_Off_N_Click(object sender, EventArgs e)
        {
            //Time Complexity : O(n^2)
            string input = "This is madam malayalam";
            MessageBox.Show(this.longestPalindromeSubstringEasy(input).ToString());
        }

        public int longestPalindromeSubstringEasy(string input)
        {
            //GEEKSFORGEEKS
            int longest_substring = 1;

            int x, y;
            int palindrome;

            for (int i = 0; i < input.Length; i++)
            {
                x = i;
                y = i + 1;
                palindrome = 0;
                while (x >= 0 && y < input.Length && input[x] == input[y])
                {
                    x--;
                    y++;
                    palindrome += 2;
                }

                longest_substring = Math.Max(longest_substring, palindrome);

                x = i - 1;
                y = i + 1;
                palindrome = 1;
                while (x >= 0 && y < input.Length && input[x] == input[y])
                {
                    x--;
                    y++;
                    palindrome += 2;
                }
                longest_substring = Math.Max(longest_substring, palindrome);
            }
            return longest_substring;
        }


        private void btn_Find_index_of_homogenous_continous_charcter_Click(object sender, EventArgs e)
        {
            string input = "AAAABBCBBBDEEEEEFFFF";
            //string input = "DBCAAB";
            //string input = "ABCCDEF";
            int previousCharCount = 0;
            int previousCharIndex = -1;
            char previousChar = '\0';
            int currentCharStartIndex = -1;
            int currentCharCount = 1;

            for (int i = 0; i < input.Length; i++)
            {
                if (i + 1 < input.Length)
                {
                    if (input[i] == input[i + 1])
                    {
                        currentCharCount++;
                        if (currentCharStartIndex == -1)
                        {
                            currentCharStartIndex = i;
                        }
                    }
                    else
                    {
                        if (previousCharCount < currentCharCount)
                        {
                            previousCharCount = currentCharCount;
                            previousChar = input[i];
                            previousCharIndex = currentCharStartIndex;
                        }

                        currentCharStartIndex = -1;
                        currentCharCount = 1;
                    }
                }
                else
                {
                    if (previousCharCount < currentCharCount)
                    {
                        previousCharCount = currentCharCount;
                        previousChar = input[i];
                        previousCharIndex = currentCharStartIndex;
                    }
                }
            }
            MessageBox.Show(previousCharIndex >= 0 ? $"Homogenous continous character is {input[previousCharIndex].ToString()} and count is {previousCharCount.ToString()}" : "No character exists in continous homogenous.");
        }

        private Dictionary<char, int> GetCharIndexesInAGivenString(string input)
        {
            var result = new Dictionary<char, int>();
            for (int i = 0; i < input.Length; i++)
            {

                if (!result.ContainsKey(input[i]))
                {
                    result.Add(input[i], i);
                }
                else
                {
                    result[input[i]] = -1;
                }
            }
            return result;
        }

        private void btn_First_Recurring_character_Click(object sender, EventArgs e)
        {
            /*
              Time Complexity is O(n)
              Space Complexity is O(n)
            */

            //string input = "ABCDEFBACBAC";
            string input = "DBCAAB";
            var result = this.GetCharIndexesInAGivenString(input);

            foreach (char c in input)
            {
                if (result[c] == -1)
                {
                    MessageBox.Show($"First recurring character is {c} for the string {input}");
                    break;
                }
            }



        }

        private void btn_First_Non_Occuring_Character_Click(object sender, EventArgs e)
        {
            /*
               Time Complexity is O(n)
               Space Complexity is O(n)
             */

            string input = "DBCAAB";
            var result = this.GetCharIndexesInAGivenString(input);
            int index = -1;
            foreach (char c in input)
            {
                if (result[c] != -1)
                {
                    if (index == -1 && result[c] == 0)
                    {
                        index = 0;
                    }
                    else if (result[c] < index)
                    {
                        index = result[c];
                    }
                }
            }

            MessageBox.Show($"First non repeating character {(index == -1 ? "is not available" : input[index].ToString())} for the string {input}");
        }

        private void btn_Find_max_space_substring_with_in_a_string__Click(object sender, EventArgs e)
        {
            //string input = "    ";
            string input = "ab  tf   xy j1234";
            //string input = "ab ";
            MessageBox.Show($"The max space substring with this string {input} is {this.FindMaxSpaceLengthInString(input)}");

        }

        public int FindMaxSpaceLengthInString(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return -1;
            }
            /* "ab  tf   xy j1234" */
            int previous = 0;
            int current = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ' ')
                {
                    current++;
                }
                else
                {
                    if (current > 0)
                    {
                        if (previous < current)
                        {
                            previous = current;

                        }
                    }
                    current = 0;
                }

                if (previous > (input.Length - i))
                {
                    break;
                }

            }

            if (current > previous)
            {
                previous = current;
            }
            return previous;
        }

        private void btn_Longest_Substring_Without_Repeating_Characters_Click(object sender, EventArgs e)
        {

            //string input = "pwwkew";
            //string input = "abcabcbb";
            //string input = "abc";
            //string input = "bbbbb";   
            // string input = "aabaab!bb";
            // string input = " ";
            // string input = "    ";
            // string input = "au";
            //string input = "   a u";
            //string input = "dvdf";
            //string input = "pwwkew";
            string input = textBox1.Text;
            int start = 0;
            string previousString = string.Empty;

            if (input.Length <= 1)
            {
                previousString = input;
            }
            else
            {
                int i;
                int pos = -1;
                for (i = 1; i < input.Length; i++) //pwwkew i =5
                {
                    pos = input.IndexOf(input[i], start, (i - start));
                    if (pos > -1)
                    {
                        if (previousString.Length < input.Substring(start, i - start).Length)
                        {
                            previousString = input.Substring(start, i - start);
                        }
                        start = pos + 1;
                    }
                }

                if (previousString.Length < input.Substring(start, i - start).Length)
                {
                    previousString = input.Substring(start, i - start);
                }
            }

            HashSet<char> dict = new HashSet<char>();
            int cs = 0, cl = 0, ps = 0, pl = 0;

            for(int i = 0; i < input.Length; i++)
            {
                if (dict.Contains(input[i]))
                {
                    if (pl < cl)
                    {
                        ps = cs;
                        pl = cl;
                    }
                    dict.Clear();
                    cs = i;
                    cl = 0; 
                }
                dict.Add(input[i]);                
                cl++;
            }
            
            if (pl < cl)
            {
                pl = cl;
                ps = cs;
            }
                                 

            MessageBox.Show($"Longest Substring of an given string {input}  is {previousString} \n " +
                            $"With second approach {input.Substring(ps, pl)}");

        }

        private void btn_Reverse_the_string_word_by_word_Click(object sender, EventArgs e)
        {
            string input = "the sky is blue";
            char[] charInputs = input.ToCharArray();
            this.reverseWords(charInputs);
            MessageBox.Show($"Reverse the string word by word for the input string {input} is \n {new string(charInputs)}");

        }

        public void reverseWords(char[] s)
        {
            int i = 0;
            for (int j = 0; j < s.Length; j++)
            {
                if (s[j] == ' ')
                {
                    reverse(s, i, j - 1);
                    i = j + 1;
                }
            }

            reverse(s, i, s.Length - 1);

            reverse(s, 0, s.Length - 1);
        }

        public void reverse(char[] s, int i, int j)
        {
            while (i < j)
            {
                char temp = s[i];
                s[i] = s[j];
                s[j] = temp;
                i++;
                j--;
            }
        }

        private void btn_Evaluate_Reverse_Polish_Notation_Click(object sender, EventArgs e)
        {
            char[] inputs = new char[] { '2', '1', '+', '3', '*' };
            Stack<string> expressions = new Stack<string>();
            List<char> operators = new List<char>() { '+', '-', '/', '*', '^' };
            int result = 0;
            foreach (char c in inputs)
            {
                if (!operators.Contains(c))
                {
                    expressions.Push(c.ToString());
                }
                else
                {
                    switch (c)
                    {
                        case '+':
                            {
                                result = int.Parse(expressions.Pop()) + int.Parse(expressions.Pop());
                                expressions.Push(result.ToString());
                                break;
                            }
                        case '-':
                            {
                                result = int.Parse(expressions.Pop()) - int.Parse(expressions.Pop());
                                expressions.Push(result.ToString());
                                break;
                            }
                        case '/':
                            {
                                result = int.Parse(expressions.Pop()) / int.Parse(expressions.Pop());
                                expressions.Push(result.ToString());
                                break;
                            }
                        case '*':
                            {
                                result = int.Parse(expressions.Pop()) * int.Parse(expressions.Pop());
                                expressions.Push(result.ToString());
                                break;
                            }
                        case '^':
                            {
                                result = int.Parse(expressions.Pop()) ^ int.Parse(expressions.Pop());
                                expressions.Push(result.ToString());
                                break;
                            }
                    }
                }
            }

            MessageBox.Show($"Value for this Reverse Polish Notation {new string(inputs)} is {expressions.Pop()} ");

        }

        private void btn_Isomorphic_Strings_Click(object sender, EventArgs e)
        {
            //string input1 = "abb";
            //string input2 = "cxx";
            string input1 = textBox1.Text;
            string input2 = textBox2.Text;
            Dictionary<char, char> storage = new Dictionary<char, char>();
            char char1;
            char char2;
            bool isIsomorphic = true;

            if (!(string.IsNullOrEmpty(input1) || string.IsNullOrEmpty(input2) || input1.Length != input2.Length))
            {
                for (int i = 0; i < input1.Length; i++)
                {
                    /* 
                       I = 2
                       a --> e
                       d --> g
                    */
                    char1 = input1[i]; // add
                    char2 = input2[i]; // egh
                    if (storage.ContainsKey(char1))
                    {
                        if (storage[char1] != char2)
                        {
                            isIsomorphic = false;
                            break;
                        }
                    }
                    else
                    {
                        if (storage.ContainsValue(char2))
                        {
                            isIsomorphic = false;
                        }
                        storage[char1] = char2;
                    }
                }
            }
            else
            {
                isIsomorphic = false;
            }

            MessageBox.Show($"The given inputs strings {input1} and {input2} is {(isIsomorphic ? "" : "not")} isomorphic strings");
        }


        public class WorkBreak
        {
            public List<string> Dictionary;
            public string input;
        }

        private void btn_Word_Break_cats_and_dogs_Click(object sender, EventArgs e)
        {




            //string input = "catsanddogs";
            //List<string> dictionary = new List<string>() {"cats", "cat", "and", "dogs", "sand", "dog" };

            /*
             Output:
                [
                  "cats and dog",
                  "cat sand dog"
                ]
             */

            //string input = "pineapplepenapple";
            //List<string> dictionary = new List<string>() { "apple", "pen", "applepen", "pine", "pineapple" };
            /*
              Output:
                [
                  "pine apple pen apple",
                  "pineapple pen apple",
                  "pine applepen apple"
                ]             
             */

            StringBuilder result = new StringBuilder();
            List<WorkBreak> inputs = new List<WorkBreak>();
            inputs.Add(new WorkBreak() { input = "leetcode", Dictionary = new List<string>() { "leet", "code" } });
            inputs.Add(new WorkBreak() { input = "applepenapple", Dictionary = new List<string>() { "apple", "pen" } });
            inputs.Add(new WorkBreak() { input = "pineapplepenapple", Dictionary = new List<string>() { "apple", "pen", "applepen", "pine", "pineapple" } });
            inputs.Add(new WorkBreak() { input = "catsandog", Dictionary = new List<string>() { "cats", "dog", "sand", "and", "cat" } });
            inputs.Add(new WorkBreak() { input = "ab", Dictionary = new List<string>() { "a","b" } });
            //inputs.Add(new WorkBreak() { input = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", Dictionary = new List<string>() { "a", "aa", "aaa", "aaaa", "aaaaa", "aaaaaa", "aaaaaaa", "aaaaaaaa", "aaaaaaaaa", "aaaaaaaaaa" } });


            foreach (WorkBreak input in inputs)
            {

                List<string>[] pos = new List<string>[input.input.Length];
                pos[0] = new List<string>();
                string subString = string.Empty;
                for (int i = 0; i < input.input.Length; i++)
                {
                    for (int j = i; j < input.input.Length; j++)
                    {
                        subString = input.input.Substring(i, (j - i) + 1);
                        if (input.Dictionary.Contains(subString))
                        {
                            if (pos[j] == null)
                            {
                                pos[j] = new List<string>();
                                pos[j].Add(subString);
                            }
                            else
                            {
                                pos[j].Add(subString);
                            }
                        }
                    }
                }

                result.AppendLine();
                if (pos[input.input.Length - 1] == null)
                {
                    result.AppendLine($"No sentence avialable for this input {input.input} and for the dictionary {string.Join(",", input.Dictionary)}");
                }
                else
                {
                    List<string> temp = new List<string>();
                    Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
                    dfs(pos, temp, "", input.input.Length - 1, dict);
                    StringBuilder outputs = new StringBuilder();
                    foreach (string str in temp)
                    {
                        outputs.Append(str + "\n");
                    }

                    result.AppendLine($"Sentences avialable are \n  {string.Join(",", temp)} \n for this input {input.input} and for the dictionary {string.Join(",", input.Dictionary)}");
                }
            }

            MessageBox.Show(result.ToString());


        }

        public void dfs(List<String>[] pos, List<String> result, String curr, int i, Dictionary<string, List<string>> dict)
        {
            if (i < 0)
            {
                result.Add(curr.Trim());
                return;
            }

            if (pos[i] == null)
                return;

            foreach (String s in pos[i])
            {
                String combined = s + " " + curr;
                if (dict.ContainsKey(combined))
                {
                    result.AddRange(dict[combined]);
                }
                else
                {
                    dfs(pos, result, combined, i - s.Length, dict);
                }
                dict[combined] = result;
            }
        }

        public int isValid(char c)
        {
            if (c == ' ') return -1;
            else if (c >= '0' && c <= '9') return c - '0';
            else if (c == '+') return -2;
            else if (c == '-') return -3;
            else return -4;
        }
        public int MyAtoi(string str)
        {
            int sign = 1;
            Int64 value = 0;
            bool hasValue = false;
            if (string.IsNullOrEmpty(str)) return 0;

            foreach (char c in str)
            {
                int v = isValid(c);
                if (!hasValue && v == -1) continue;
                else if (!hasValue && v == -2) { sign = 1; hasValue = true; }
                else if (!hasValue && v == -3) { sign = -1; hasValue = true; }
                else if (v == -4) break;
                else if (v >= 0 && v <= 9)
                {
                    hasValue = true;
                    value = value * 10 + v;
                    if (sign == 1 && value > Int32.MaxValue) return Int32.MaxValue;
                    else if (sign == -1 && value * sign < Int32.MinValue) return Int32.MinValue;

                }
                else break;
            }

            return (int)value * sign;
        }

        private void btn_Zig_Zag_String_in_n_Rows_Click(object sender, EventArgs e)
        {
            /*
                Input = "PAYPALISHIRING";
                Output: "PINALSIGYAHRPI"
                Explanation:
                    P     I    N
                    A   L S  I G
                    Y A   H R
                    P     I

                Input = "PAYPALISHIRING"
                Output= "PAHNAPLSIIGYIR"
             */

            Dictionary<string, int> inputs = new Dictionary<string, int>();
            //inputs.Add("PAYPALISHIRING", 4);
            //inputs.Add("PAYPALISHIRING1", 3);
            //inputs.Add("ABC", 1);
            inputs.Add("PAYPALISH", 4);
            StringBuilder result = new StringBuilder();
            foreach (string key in inputs.Keys)
            {

                int numRows = inputs[key];
                string s = key;

                if (numRows > 1)
                {
                    int row = 0;
                    string[] arr = new string[numRows];
                    bool down = true;


                    foreach (char c in s)
                    {
                        arr[row] += c.ToString();
                        if (row == numRows - 1)
                        {
                            down = false;
                        }
                        else if (row == 0)
                        {
                            down = true;
                        }

                        if (down)
                        {
                            row++;
                        }
                        else
                        {
                            row--;
                        }
                    }
                    result.AppendLine($"Zig Zag of {s} is {(string.Join("", arr))}");
                }
                else
                {
                    result.AppendLine($"Zig Zag of {s} is {s}");
                }

            }
            MessageBox.Show(result.ToString());

        }

        private void btn_Regular_Expression_Matching_Click(object sender, EventArgs e)
        {
            /*
             
             Given an input string (s) and a pattern (p), implement regular expression matching with support for '.' and '*'.

                '.' Matches any single character.
                '*' Matches zero or more of the preceding element.
                The matching should cover the entire input string (not partial).

                Note:

                s could be empty and contains only lowercase letters a-z.
                p could be empty and contains only lowercase letters a-z, and characters like . or *.
                Example 1:

                Input:
                s = "aa"
                p = "a"
                Output: false
                Explanation: "a" does not match the entire string "aa".
                Example 2:

                Input:
                s = "aa"
                p = "a*"
                Output: true
                Explanation: '*' means zero or more of the precedeng element, 'a'. Therefore, by repeating 'a' once, it becomes "aa".
                Example 3:

                Input:
                s = "ab"
                p = ".*"
                Output: true
                Explanation: ".*" means "zero or more (*) of any character (.)".
                Example 4:

                Input:
                s = "aab"
                p = "c*a*b"
                Output: true
                Explanation: c can be repeated 0 times, a can be repeated 1 time. Therefore it matches "aab".
                Example 5:

                Input:
                s = "mississippi"
                p = "mis*is*p*."
                Output: false 
            */
            StringBuilder result = new StringBuilder();
            Dictionary<string, string> inputs = new Dictionary<string, string>();
            inputs.Add("a", "aa");
            inputs.Add("a*", "aba");
            inputs.Add(".*", "ab");
            inputs.Add("c* a*b", "aab");
            inputs.Add("mis*is*p*.", "mississippi");




            string input = "aabb";
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("*");
            MessageBox.Show($" {(regex.IsMatch(input) ? "Match" : "No Match")}");

            result.Append($"For the given ");
            foreach (string key in inputs.Keys)
            {
                result.AppendLine($"strings {inputs[key]} and pattern {key}  = {(this.IsMatch(inputs[key], key) ? " Match" : "No Match")}");
            }


            MessageBox.Show(result.ToString());



        }

        private bool IsMatch(string s, string p)
        {
            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(p))
            {
                return false;
            }

            /*
                inputs.Add("a", "aa");
                inputs.Add("a*", "aa");
                inputs.Add(".*", "aa");
                inputs.Add("c*a*b", "aab");
                inputs.Add("mis*is*p*.", "mississippi");

                mis *is * p*.
                mis sis s ippi
            */

            bool[][] lookup = new bool[s.Length][];
            for (int i = 0; i < s.Length; i++)
            {
                lookup[i] = new bool[p.Length];
            }


            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < p.Length; j++)
                {
                    if (p[j] == '*')
                    {
                        if (j > 0 && p[j - 1] == s[i])
                        {
                            lookup[i][j] = lookup[i][j - 1];
                        }
                        else if (j == 0)
                        {
                            lookup[i][j] = true;
                        }
                    }
                    else if (p[j] == '.' || p[j] == s[i])
                    {
                        lookup[i][j] = true;
                    }
                    else
                    {
                        lookup[i][j] = false;
                    }
                }
            }

            return lookup[s.Length - 1][p.Length - 1];

            //lookup[0, 0] = true;

            //for (int j = 1; j <= s.Length; j++)
            //    if (p[j - 1] == '*')
            //    {
            //        lookup[0,j] = lookup[0,j - 1];
            //    }


            //for (int i = 1; i<= s.Length; i++)
            //{
            //    for (int j = 1; j <= p.Length; j++)
            //    {
            //         if (p[j-1] == '*')
            //        {
            //            lookup[i, j] = lookup[i, j - 1] || lookup[i-1, j];
            //        }
            //        else if (p[j-1] == '?' || s[i-1] == p[j-1])
            //        {
            //            lookup[i,j] =  lookup[i - 1, j - 1];
            //        }
            //        else
            //        {
            //            lookup[i, j] = false;
            //        }
            //    }
            //}



            //bool[][] dp = new bool[s.Length + 1][];
            //for(int i = 0; i < dp.Length; i ++)
            //{
            //    dp[i] = new bool[p.Length + 1];
            //}


            //for (int i = s.Length; i >= 0; i--)
            //{
            //    for (int j = p.Length - 1; j >= 0; j--)
            //    {
            //        bool first_match = (i < s.Length &&
            //                               (p[j] == s[i] ||
            //                                p[j] == '.'));
            //        if (j + 1 < p.Length && p[j + 1] == '*')
            //        {
            //            dp[i][j] = dp[i][j + 2] || first_match && dp[i + 1][ j];
            //        }
            //        else
            //        {
            //            dp[i][j] = first_match && dp[i + 1][j + 1];
            //        }
            //    }
            //}
            //return dp[0][0];

        }

        private void btn_Implement_Auto_Complete_Click(object sender, EventArgs e)
        {
            /*
                https://www.geeksforgeeks.org/trie-insert-and-search/
                Time Complexity : 
                    Insert      : O(n) where n is string length
                    Space       : O(126 * n) where 126 is the 
             */
            string[] inputs = new string[] { "the", "there", "their", "them", "target" };

            Trie root = new Trie();

            foreach (string input in inputs)
            {
                this.InsertIntoTrie(root, input);
            }

            MessageBox.Show($"The below are the autocomplete strings {this.Search(root, "the")}   \n\n for the given strings \n\n{string.Join("\n", inputs)}");

        }

        private bool IsLastNode(Trie root)
        {
            for (int i = 0; i < atoz; i++)
            {
                if (root != null && root.Data[i] != null)
                {
                    return false;
                }
            }
            return true;
        }

        private string Search(Trie root, string search)
        {
            Trie temp = root;
            if (string.IsNullOrEmpty(search) || root == null)
                return null;

            List<string> result = new List<string>();

            foreach (char c in search)
            {
                if (temp.Data[c] != null)
                {
                    temp = temp.Data[c];
                }
            }

            this.SearchString(temp, search, result);
            return "\n" + string.Join("\n", result);

        }

        private void SearchString(Trie root, string currentPrefix, List<String> output)
        {
            if (root == null || string.IsNullOrEmpty(currentPrefix) || output == null)
            {
                return;
            }

            if (root.IsLastWord)
            {
                output.Add(currentPrefix);
            }

            if (this.IsLastNode(root))
            {
                return;
            }

            for (int i = 0; i < atoz; i++)
            {
                if (root.Data[i] != null)
                {
                    SearchString(root.Data[i], currentPrefix + (char)i, output);
                }
            }

        }



        private void InsertIntoTrie(Trie root, string stringData)
        {
            if (string.IsNullOrEmpty(stringData))
                return;

            Trie tempRoot = root;

            if (tempRoot == null)
            {
                tempRoot = new Trie();
            }

            foreach (char c in stringData)
            {
                if (tempRoot.Data[c] == null)
                {
                    tempRoot.Data[c] = new Trie();
                }
                tempRoot = tempRoot.Data[c];
            }

            tempRoot.IsLastWord = true;
        }

        class Trie
        {
            public Trie[] Data = new Trie[atoz];
            public bool IsLastWord = false;
        }

        private void btn_Find_the_longest_substring_with_k_unique_characters_in_a_given_string_Click(object sender, EventArgs e)
        {

            /*
             Given an integer k and a string s, find the length of the longest substring that contains at most k distinct characters.
             For example, given s = "abcba" and k = 2, the longest substring with k distinct characters is "bcb".
             https://www.geeksforgeeks.org/find-the-longest-substring-with-k-unique-characters-in-a-given-string/

            "aabbcc", k = 1
            Max substring can be any one from {"aa" , "bb" , "cc"}.

            "aabbcc", k = 2
            Max substring can be any one from {"aabb" , "bbcc"}.

            "aabbcc", k = 3
            There are substrings with exactly 3 unique characters
            {"aabbcc" , "abbcc" , "aabbc" , "abbc" }
            Max is "aabbcc" with length 6.

            "aaabbb", k = 3
            There are only two unique characters, thus show error message. 

             */
            List<StringWithUniqueNCharacter> inputs = new List<StringWithUniqueNCharacter>();
            StringBuilder result = new StringBuilder();
            inputs.Add(new StringWithUniqueNCharacter() { Input = "aabbccd", UniqueCharacterCount = 3 });

            const int alphaBetSize = 256;

            foreach (StringWithUniqueNCharacter input in inputs)
            {
                string str = input.Input;
                int uniqueVal = input.UniqueCharacterCount;
                int[] count = new int[alphaBetSize];

                if (str.Length < uniqueVal)
                {
                    result.Append($"There is no sufficient unique {uniqueVal} for the given string {str} \n");
                    continue;
                }

                count[str[0]]++;
                int curr_start = 0, curr_end = 0, windowSize = 1, windowStart = 0;
                //aabbccd  uniqueval = 3
                for (int i = 1; i < str.Length; i++)//4
                {
                    count[str[i]]++;  // a= 1, b= 2, c=2 d= 1
                    curr_end++; // 6

                    if (!(this.IsMoreUniqueCharacterPresent(count, uniqueVal, alphaBetSize)))
                    {
                        count[str[curr_start]]--;
                        curr_start++; //1
                    }

                    if ((curr_end - curr_start + 1) > (windowSize))
                    {
                        windowSize = curr_end - curr_start + 1; //6
                        windowStart = curr_start; //0
                    }

                }

                result.Append($"Length of the long substring is {(windowSize - windowStart)}  for this {str.Substring(windowStart, windowSize)} with {uniqueVal}  unique value from the given string {str} \n");
            }

            MessageBox.Show(result.ToString());
        }

        private bool IsMoreUniqueCharacterPresent(int[] count, int uniqueVal, int alphaBetSize)
        {
            int val = 0;
            for (int i = 0; i < alphaBetSize; i++)
            {
                if (count[i] > 0)
                    val++;
            }

            return uniqueVal >= val;
        }

        public class StringWithUniqueNCharacter
        {
            public string Input;
            public int UniqueCharacterCount;
        }

        private void btn_Look_and_say_sequence_Click(object sender, EventArgs e)
        {
            int n = 4;
            string result = string.Empty;
            if (n == 1)
            {
                result = "1";
            }
            if (n == 2)
            {
                result = "11";
            }
            result = "11";
            for (int i = 3; i <= n; i++)
            {

                int counter = 1;
                result += "$";
                string temp = string.Empty;

                for (int j = 1; j < result.Length; j++)
                {
                    if (result[j] != result[j - 1])
                    {
                        temp += counter;
                        temp += result[j - 1];
                    }
                    else
                    {
                        counter++;
                    }
                }
                result = temp;
            }

            MessageBox.Show($"Look and easy sequence for the given number {n} is {result} ");


        }

        private void btn_Permutation_of_a_string_Click(object sender, EventArgs e)
        {
            /*
                Time Complexity     : O(n * n!) 
                Space Complexity    : O(26)
                https://www.geeksforgeeks.org/time-complexity-permutations-string/
             */
            List<string> inputs = new List<string>();
            //inputs.Add("abc");
            //inputs.Add("geek");
            inputs.Add("aab");
            StringBuilder result = new StringBuilder();
            foreach (var input in inputs)
            {
                result.Append($"The permutation for the given string {input} is {string.Join(" ", this.GetPermuationOfGivenString(input, string.Empty))} \n");
            }

            MessageBox.Show(result.ToString());
        }

        private List<string> GetPermuationOfGivenString(string input, string currentString)
        {
            List<string> result = new List<string>();
            
            if (input.Length == 0)
            {
                result.Add(currentString);
                return result;
            }

            bool[] vistedChar = new bool[26];
            char currentChar;

            for (int i = 0; i < input.Length; i++)
            {
                currentChar = input[i];

                if (vistedChar[currentChar - 'a'] == false)
                {
                    /*
                        String.Substring(0,0) will be empty
                    */
                    result.AddRange(this.GetPermuationOfGivenString(input.Substring(0, i) + input.Substring(i + 1), currentString + currentChar));
                }
                vistedChar[currentChar - 'a'] = true;
            }

            return result;
        }

        private void btn_Longest_Common_Prefix_Click(object sender, EventArgs e)
        {
            /*
             
                Time Complexity     : O(n*l) where n is the number of items in the list and l is the length of item within each item
                Space Complexity    : O(1) constant space
              
                Write a function to find the longest common prefix string amongst an array of strings.
                If there is no common prefix, return an empty string "".
                
                Example 1:           
                Input: ["flower","flow","flight"]
                Output: "fl"
                Example 2:

                Input: ["dog","racecar","car"]
                Output: ""
                Explanation: There is no common prefix among the input strings.
                Note:

                All given inputs are in lowercase letters a-z 
             
             */

            string[] strs = new string[] { "flower", "flow", "flight" };



            int minLength = this.GetMinLength(strs);
            int index = 0;
            bool proceed = true;

            while (index < minLength && proceed)
            {
                for (int i = 0; i < strs.Length - 1; i++)
                {
                    if (strs[i][index] != strs[i + 1][index])
                    {
                        proceed = false;
                        break;
                    }
                }

                if (proceed)
                {
                    index++;
                }

            }

            MessageBox.Show($"The longest common prefix for the given input strings {string.Join(" ", strs)} is { strs[0].Substring(0, index)}");

        }

        public int GetMinLength(string[] strs)
        {
            int minLength = strs[0].Length;

            for (int i = 1; i < strs.Length; i++)
            {
                minLength = Math.Min(minLength, strs[i].Length);
            }
            return minLength;
        }

        private void btn_Valid_Parentheses_Click(object sender, EventArgs e)
        {
            /*
              
                Time Complexity : O(n) where n is the length of the character in the string
                Space Complexity : O(n) worst case we will be storing all the character is the stack if the input is (((((((

                Given a string containing just the characters '(', ')', '{', '}', '[' and ']',
                determine if the input string is valid.
                An input string is valid if:
                Open brackets must be closed by the same type of brackets.
                Open brackets must be closed in the correct order.
                Note that an empty string is also considered valid.

                Example 1:
                Input: "()"
                Output: true
                Example 2:

                Input: "()[]{}"
                Output: true
                Example 3:

                Input: "(]"
                Output: false
                Example 4:

                Input: "([)]"
                Output: false
                Example 5:

                Input: "{[]}"
                Output: true 
             
             */
            List<string> inputs = new List<string>();
            inputs.Add("()");
            inputs.Add("()[]{}");
            inputs.Add("(]");
            inputs.Add("([)]");
            inputs.Add("{[]}");
            StringBuilder result = new StringBuilder();
            foreach (string input in inputs)
            {
                result.Append($"The given input string {input} is {(this.IsValidWithBraces(input) ? " valid" : " is not valid")} \n");
            }

            MessageBox.Show(result.ToString());
        }

        public bool IsValidWithBraces(string s)
        {

            if (s == string.Empty)
            {
                return true;
            }

            if (s.Length == 0 || s.Length == 1)
            {
                return false;
            }

            //{[]}
            Dictionary<char, char> cd = new Dictionary<char, char>();
            cd.Add(')', '(');
            cd.Add('}', '{');
            cd.Add(']', '[');
            Stack<char> stack = new Stack<char>();
            foreach (char c in s)
            {
                if (!cd.ContainsKey(c))
                {
                    stack.Push(c);
                }
                else
                {
                    if (stack.Count > 0 && stack.Peek() == cd[c])
                    {
                        stack.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }

        private void btn_Implement_strStr_Click(object sender, EventArgs e)
        {


            /*
                Implement strStr().

                Return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.

                Example 1:

                Input: haystack = "hello", needle = "ll"
                Output: 2
                Example 2:

                Input: haystack = "aaaaa", needle = "bba"
                Output: -1
                Clarification:

                What should we return when needle is an empty string? This is a great question to ask during an interview.
                For the purpose of this problem, we will return 0 when needle is an empty string. This is consistent to C's 
                strstr() and Java's indexOf(). Time Complexity : O(m+m) // where m is the length of the haystack and n is the 
                length of the needle

             */

            List<IndexOf> inputs = new List<IndexOf>();
            //inputs.Add(new IndexOf() { input = "mississippi", findIndex = "pi" });     //9
            //inputs.Add(new IndexOf() { input = "mississippi", findIndex = "issip" });  //4
            inputs.Add(new IndexOf() { input = "mississippi", findIndex = "issipi" }); //-1
            //inputs.Add(new IndexOf() { input = "hello", findIndex = "ll" });           //2
            //inputs.Add(new IndexOf() { input = "aaaaa", findIndex = "bb" });           // -1
            //inputs.Add(new IndexOf() { input = "", findIndex = "" });           // -1
            StringBuilder result = new StringBuilder();
            foreach (IndexOf input in inputs)
            {
                result.Append($"The index is {this.FindIndexOf(input.input, input.findIndex)} for the given string {input.input} to find index of {input.findIndex} \n");
            }

            MessageBox.Show(result.ToString());




        }

        private int FindIndexOf(string input, string findIndex)
        {

            if (findIndex == null || input == null || input.Length < findIndex.Length)
            {
                return -1;
            }

            //  input = "mississippi", findIndex = "issipi"  i = 1 index = 1 j = 1
            if (findIndex.Length == 0) return 0;
            int index = -1;
            for (int i = 0, j = 0; i < input.Length; i++)
            {
                if (input[i] == findIndex[j])
                {
                    if (index == -1)
                    {
                        index = i;
                    }
                    j++;
                    if (j == findIndex.Length) return index;
                }
                else
                {
                    if (index != -1)
                    {
                        i = index;
                    }

                    j = 0;
                    index = -1;
                }
            }
            return -1;

        }

        public class IndexOf
        {
            public string input;
            public string findIndex;

        }

        private void btn_Length_of_Last_Word_Click(object sender, EventArgs e)
        {
            /*
                 Time Complexity : O(n) where n is the length of the last word
             */

            List<string> inputs = new List<string>();
            inputs.Add("Hello World");
            inputs.Add("Hello");
            inputs.Add(" World");
            inputs.Add("World ");
            inputs.Add("          ");
            inputs.Add("d");
            inputs.Add("e ");
            inputs.Add(null);

            StringBuilder result = new StringBuilder();

            int[] t = new int[inputs.Count];

            foreach (string s in inputs)
            {
                if (s == null)
                {
                    result.AppendLine($"String is null");
                    continue;
                }

                string input = s.Trim();

                if (input.Length == 0)
                {
                    result.AppendLine($"Max length is 0 for the last word in this given string {s}");
                }
                else
                {                    
                    int len = 0;
                    for (int i = input.Length - 1; i >= 0; i--)
                    {

                        if (input[i] == ' ')
                        {
                            if (len > 0)
                                break;
                        }
                        else
                            len++;
                    }
                    result.AppendLine($"Max length is {len} for the last word in this given string {input}");
                }
            }
            MessageBox.Show(result.ToString());
        }

        private void btn_Add_Binary_Click(object sender, EventArgs e)
        {
            /*
                Given two binary strings, return their sum (also a binary string).
                The input strings are both non-empty and contains only characters 1 or 0.

                Example 1:
                Input: a = "11", b = "1"
                Output: "100"
                
                Example 2:
                Input: a = "1010", b = "1011"
                Output: "10101"
                    
                Time Complexity : O(n+m) where n is the length of the input 1 and m is the length of the input 2
                Space Complexity : O(l) where l is the length of the result 
            
             */

            List<AddBinaryInputs> inputs = new List<AddBinaryInputs>();
            //inputs.Add(new AddBinaryInputs() { inputA = "11", inputB = "1" });
            //inputs.Add(new AddBinaryInputs() { inputA = "11" });
            //inputs.Add(new AddBinaryInputs() { inputB = "11" });
            //inputs.Add(new AddBinaryInputs() { });
            //inputs.Add(new AddBinaryInputs() { inputA = "1111", inputB = "111" });

            StringBuilder result = new StringBuilder();

            foreach (var input in inputs)
            {
                //result.AppendLine($"Adding two binary A :  {input.inputA} and  B : {input.inputB}  is {AddBinaryStringBuilder(input.inputA, input.inputB)}");
                result.AppendLine($"Adding two binary A : {input.inputA} and B : {input.inputB}  is {AddBinaryStack(input.inputA, input.inputB)}");
            }

            MessageBox.Show(result.ToString());

        }

        public string AddBinaryStringBuilder(string inputA, string inputB)
        {
            if (string.IsNullOrEmpty(inputA))
                return inputB;

            if (string.IsNullOrEmpty(inputB))
                return inputA;

            if (string.IsNullOrEmpty(inputA) && string.IsNullOrEmpty(inputB))
                return inputA;


            int al = 0;
            int bl = 0;
            int sum = 0;
            int carry = 0;

            StringBuilder binarySum = new StringBuilder();
            
            inputA = inputA.Trim();
            inputB = inputB.Trim();

            al = inputA.Length - 1;
            bl = inputB.Length - 1;

            while (al >= 0 && bl >= 0)
            {
                sum = carry;
                sum += (inputA[al] - '0');
                sum += (inputB[bl] - '0');
                carry = sum / 2;
                binarySum.Insert(0, sum % 2);
                al--;
                bl--;
            }
            
            while (al >= 0)
            {
                sum = carry;
                sum += (inputA[al] - '0');
                carry = sum / 2;
                binarySum.Insert(0, sum % 2);
                al--;
            }

            while (bl >= 0)
            {
                sum = carry;
                sum += (inputB[bl] - '0');
                carry = sum / 2;
                binarySum.Insert(0, sum % 2);
                bl--;
            }

            if (carry > 0)
            {
                binarySum.Insert(0, carry);
            }

            return binarySum.ToString();

        }

        public string AddBinaryStack(string a, string b)
        {
            if (string.IsNullOrEmpty(a))
                return b;

            if (string.IsNullOrEmpty(b))
                return a;

            if (string.IsNullOrEmpty(a) && string.IsNullOrEmpty(a))
                return b;

            int al = a.Length - 1;
            int bl = b.Length - 1;

            Stack<int> s = new Stack<int>();
            int temp = 0;
            int reminder = 0;


            while (al >= 0 && bl >= 0)
            {
                temp = (a[al] - '0') + (b[bl] - '0') + reminder;
                if (temp > 1)
                {
                    reminder = temp / 2;
                    temp = temp % 2;
                }
                else
                    reminder = 0;
                s.Push(temp);
                al--;
                bl--;

            }

            while (al >= 0)
            {
                temp = (a[al] - '0') + reminder;
                if (temp > 1)
                {
                    reminder = 1;
                    temp = 0;
                }
                else
                    reminder = 0;
                s.Push(temp);
                al--;
            }

            while (bl >= 0)
            {
                temp = (b[bl] - '0') + reminder;
                if (temp > 1)
                {
                    reminder = 1;
                    temp = 0;
                }
                else
                    reminder = 0;
                s.Push(temp);
                bl--;
            }

            if (reminder > 0)
                s.Push(reminder);

            return string.Join("", s);

        }

        public class AddBinaryInputs
        {
            public string inputA;
            public string inputB;
        }

        private void btn_Convert_12hour_Time_to_24_hour_time_Click(object sender, EventArgs e)
        {
            List<string> inputs = new List<string>();
            inputs.Add("07:05:45PM");
            inputs.Add("12:40:22AM");
            inputs.Add("06:40:03AM");
            inputs.Add("12:05:39AM");
            inputs.Add("12:45:54PM");
            inputs.Add("02:34:50PM");
            inputs.Add("04:59:59AM");
            inputs.Add("04:59:59PM");
            inputs.Add("12:00:00AM");
            inputs.Add("11:59:59PM");

            StringBuilder result = new StringBuilder();
            StringBuilder timeFormat = new StringBuilder();
            string amPm;
            string strtime;
            int time = 0;
            string[] timeData;
            foreach (string s in inputs)
            {

                timeData = s.Split(':');
                timeFormat.Clear();

                if (string.IsNullOrEmpty(s) || timeData.Length != 3)
                {
                    result.AppendLine($"Not a valid date {(string.IsNullOrEmpty(s) ? "NULL OR EMPTY" : s)}");
                }

                amPm = timeData[2].Substring(2, 2);
                strtime = timeData[0];
                time = 0;

                if (!(amPm == "PM" || amPm == "AM"))
                {
                    result.AppendLine($"Not a valid date {s}");
                }

                time = Convert.ToInt32(strtime);

                if (time < 0 && time > 24)
                {
                    result.AppendLine($"Not a valid date {s}");
                }

                if (amPm == "PM")
                {
                    timeFormat.Append($"{(time == 12 ? time : (time + 12)).ToString()}");
                }
                else
                {
                    timeFormat.Append($"{(time == 12 ? "00" : time.ToString("00"))}");
                }

                timeFormat.Append($":{timeData[1]}:{timeData[2].Substring(0, 2)}");
                result.AppendLine($"24 hour format is {timeFormat.ToString()} for the given date {s}");
            }

            MessageBox.Show(result.ToString());

        }

        private void btn_Partial_String_Search_Click(object sender, EventArgs e)
        {
            /* 
             
                Note : I have considered case senstivity in my solution if in case we don't want to consider case senstivity we can use ToLower function and 
                       pass the data to IsStringMatch function                       
                Time Complexity  : O(mnp) where n is the length of each word in words collection and pattern match has to be done for 
                                   m words in the words collection.       
                                   p is the length of the pattern string
                Space Complexity : O(1) constant space.
             */

            List<string> words = new List<string>();
            words.Add("ABNCD");
            words.Add("NABCD");
            words.Add("ABCDN");
            words.Add("can");
            words.Add("nnnnn");

            StringBuilder result = new StringBuilder();
            //string crossWordPattern = "can"; //Match
            //string crossWordPattern = "__N__"; //Match
            //string crossWordPattern = "_N__"; // No Match
            //string crossWordPattern = "__n__"; // No Match
            string crossWordPattern = "_____"; // Match


            if (string.IsNullOrEmpty(crossWordPattern))
            {
                MessageBox.Show($"Invalid Pattern");
            }
            else if (words.Count == 0)
            {
                MessageBox.Show($"There is no words in the dictionary to match the Pattern");
            }
            else
            {
                foreach (var word in words)
                {
                    if (IsStringMatch(word, crossWordPattern))
                    {
                        result.AppendLine(word);
                    }
                }

                MessageBox.Show($"{(result.Length == 0 ? "There is no string matching" : "The below are the string that matches") } this { crossWordPattern } pattern \n{result}");
            }
        }

        private bool IsStringMatch(string input, string pattern)
        {
            if (input.Length == pattern.Length)
            {
                char c;
                int i = 0;

                while (i < input.Length)
                {
                    c = pattern[i];

                    if (!(c == '_' || c == input[i]))
                    {
                        return false;
                    }

                    i++;
                }

                return true;
            }

            return false;
        }

        private void btn_Shortest_Standardized_Path_Click(object sender, EventArgs e)
        {
            /*             
                Here's your coding interview problem for today. This problem was asked by Quora.
                Given an absolute pathname that may have . or .. as part of it, return the shortest standardized path.
                For example, given "/usr/bin/../bin/./scripts/../", return "/usr/bin/".

                Time Complexity : O(L) where L is the length of the string
                Space Complexity : O(log L) 
             */

            List<string> inputs = new List<string>();
            inputs.Add("/usr/bin/../bin/./scripts/../"); ///usr/bin/
            inputs.Add("/home/"); // /home
            inputs.Add("/a/./b/../../c/"); // /c
            inputs.Add("/a/.."); // /            
            inputs.Add("/../../../../../a"); // /a
            inputs.Add("/a/./b/./c/./d/"); // /a/b/c/d
            inputs.Add("/a/../.././../../"); // /
            inputs.Add("/a//b//c//////d"); // /a/b/c/d

            Stack<string> stack = new Stack<string>();
            StringBuilder temp = new StringBuilder();
            StringBuilder result = new StringBuilder();

            foreach (string str in inputs)
            {
                stack.Clear();
                temp.Clear();
                foreach (string istr in str.Split('/'))
                {
                    if (string.IsNullOrEmpty(istr) || istr == ".")
                    {
                        continue;
                    }
                    else if (istr == "..")
                    {
                        if (stack.Count > 0)
                        {
                            stack.Pop();
                        }
                    }
                    else
                    {
                        stack.Push(istr);
                    }
                }

                if (stack.Count == 0)
                {
                    temp.Insert(0, "/");
                }
                else
                {
                    while (stack.Count > 0)
                    {
                        temp.Insert(0, "/" + stack.Pop());
                    }
                }

                result.AppendLine($"Shortest Standardized path for this path {str} is {temp.ToString()}");
            }
            MessageBox.Show(result.ToString());
        }

        private void btn_Valid_Palindrome_Click(object sender, EventArgs e)
        {
            /*
                Given a string, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.

                Note: For the purpose of this problem, we define empty string as valid palindrome.

                Example 1:

                Input: "A man, a plan, a canal: Panama"
                Output: true
                Example 2:

                Input: "race a car"
                Output: false
             */

            StringBuilder result = new StringBuilder();
            List<string> inputs = new List<string>();
            //inputs.Add("A man, a plan, a canal: Panama");
            //inputs.Add("race a car");
            //inputs.Add("0P");
            inputs.Add(",M 9y\"yj\"j9 M,");
            foreach (string input in inputs)
            {
                result.AppendLine($"The given string is {(this.IsPalindrome(input) ? "" : "not")} Plandrome");
            }

            MessageBox.Show(result.ToString());
        }


        public bool IsPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return true;
            }

            string input = s.ToLower();
            int start = 0;
            int end = s.Length - 1;
            char sc;
            char ec;

            while (start < end)
            {
                sc = input[start];
                ec = input[end];
                if (!((sc >= 97 && sc <= 122) || (sc >= 48 && sc <= 57)))
                {
                    start++;
                }
                else if (!((ec >= 97 && ec <= 122) || (ec >= 48 && ec <= 57)))
                {
                    end--;
                }
                else if (sc != ec)
                {
                    return false;
                }
                else
                {
                    start++;
                    end--;
                }

            }

            return true;
        }


        public bool IsPalindrome_T(string s)
        {
            if (string.IsNullOrEmpty(s))
                return false;

            string input = s.ToLower();

            int start = 0;
            int end = input.Length - 1;

            while (start < end)
            {
                if (input[start] == 32 || !((input[start] >= 97 && input[end] <= 122) || (input[start] >= 48 && input[end] <= 59))) 
                start++;
            else if (input[start] == 32 || !((input[start] >= 97 && input[end] <= 122) || (input[start] >= 48 && input[end] <= 59))) 
                end--;
            else if (input[start] != input[end])
                    return false;

                start++;
                end--;
            }

            return true;

        }

        private void btn_Longest_Palindromic_Substring_Click(object sender, EventArgs e)
        {
            /*
            
                Given a string s, find the longest palindromic substring in s. You may assume that the maximum length of s is 1000.
                Example 1:

                Input: "babad"
                Output: "bab"
                Note: "aba" is also a valid answer.
                Example 2:

                Input: "cbbd"
                Output: "bb"
             */

            List<string> inputs = new List<string>();
            StringBuilder result = new StringBuilder();
            inputs.Add("babad");
            inputs.Add("cbbd");
            inputs.Add(null);
            inputs.Add("GEEKSFORGEEKS");
            inputs.Add("This is madam malayalam");
            inputs.Add("m");
            string tempResult = string.Empty;
            foreach (string input in inputs)
            {
                tempResult = this.LongestPalindromicSubstring(input);
                result.AppendLine($"The longest plandromic substring for the string {(string.IsNullOrEmpty(input) ? "NULL" : input) } is {(string.IsNullOrEmpty(input) ? "NULL" : tempResult) }");
            }

            MessageBox.Show(result.ToString());


        }

        private string LongestPalindromicSubstring(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return s;
            }


            int j = 0;
            int k = 0;
            int start = 0;
            int length = 1;
            int tempLength = 0;

            for (int i = 0; i < s.Length; i++)
            {
                tempLength = 0;
                j = i;
                k = i + 1;


                while (j >= 0 && j < s.Length && k >= 0 && k < s.Length && s[j] == s[k])
                {
                    j--;
                    k++;
                    tempLength += 2;
                }

                if (tempLength > length)
                {
                    length = Math.Max(tempLength, length);
                    start = j + 1;
                }

                j = i - 1;
                k = i + 1;
                tempLength = 1;
                while (j >= 0 && j < s.Length && k >= 0 && k < s.Length && s[j] == s[k])
                {
                    j--;
                    k++;
                    tempLength += 2;
                }

                if (tempLength > length)
                {
                    length = Math.Max(tempLength, length);
                    start = j + 1;
                }
            }

            return s.Substring(start, length);
        }

        private void btn_Integer_to_Roman_Click(object sender, EventArgs e)
        {
            /*
             
                    Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.
                    Symbol       Value
                    I             1
                    V             5
                    X             10
                    L             50
                    C             100
                    D             500
                    M             1000
                    For example, two is written as II in Roman numeral, just two one's added together. Twelve is written as, XII, which is simply X + II. The number twenty seven is written as XXVII, which is XX + V + II.

                    Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not IIII. Instead, the number four is written as IV. Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as IX. There are six instances where subtraction is used:

                    I can be placed before V (5) and X (10) to make 4 and 9. 
                    X can be placed before L (50) and C (100) to make 40 and 90. 
                    C can be placed before D (500) and M (1000) to make 400 and 900.
                    Given an integer, convert it to a roman numeral. Input is guaranteed to be within the range from 1 to 3999.

                    Example 1:

                    Input: 3
                    Output: "III"
                    Example 2:

                    Input: 4
                    Output: "IV"
                    Example 3:

                    Input: 9
                    Output: "IX"
                    Example 4:

                    Input: 58
                    Output: "LVIII"
                    Explanation: L = 50, V = 5, III = 3.
                    Example 5:

                    Input: 1994
                    Output: "MCMXCIV"
                    Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.

                    Time Complexity : O(N) where N is the length of the input
                    Space Complexity : O(1) constant space
             */


            StringBuilder result = new StringBuilder();
            List<int> inputs = new List<int>();
            inputs.Add(1945);
            inputs.Add(3999);
            inputs.Add(3900);
            inputs.Add(0);
            inputs.Add(58);
            inputs.Add(5);
            inputs.Add(10);
            inputs.Add(11);
            inputs.Add(5);
            inputs.Add(10);
            inputs.Add(50);
            inputs.Add(100);
            inputs.Add(500);
            inputs.Add(1000);

            string res;
            foreach (int input in inputs)
            {
                res = this.IntToRoman(input);
                result.AppendLine($"Roman value for the given integer {input} is {(string.IsNullOrEmpty(res) ? "Empty" : res)}");
            }

            MessageBox.Show(result.ToString());


        }


        private string IntToRoman(int num)
        {            
            if (num == 0)
            {
                return null;
            }

            int val = num;
            int div = 1;
            int rem = 0;
            System.Text.StringBuilder res = new System.Text.StringBuilder();
            Dictionary<int, char> dict = new Dictionary<int, char>();
            dict.Add(1, 'I');
            dict.Add(5, 'V');
            dict.Add(10, 'X');
            dict.Add(50, 'L');
            dict.Add(100, 'C');
            dict.Add(500, 'D');
            dict.Add(1000, 'M');

            while (val >= div)
            {
                div *= 10;
            }

             div /= 10;


            while (val > 0)  // 1945 
            {
                rem = val / div;

                if (rem <= 3)
                {
                    res.Append(new String(dict[div], rem));
                }
                else if (rem == 4)
                {
                    res.Append($"{dict[div]}{dict[div * 5]}");
                }
                else if (rem >= 5 && rem <= 8)
                {
                    res.Append($"{dict[div * 5]}{new String(dict[div], rem - 5) }" );
                }
                else // rem == 9
                {
                    res.Append($"{dict[div]}{dict[div * 10]}");
                }

                val = val % div;
                div /= 10;

            }
            return res.ToString();
        }

        private void btn_Letter_Combinations_of_a_Phone_Number_Click(object sender, EventArgs e)
        {
            /*
                 Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent.

                A mapping of digit to letters (just like on the telephone buttons) is given below. Note that 1 does not map to any letters.
                    
                    2: abc
                    3 : def
                    4 : ghi
                    5 : jkl
                    6 : mno
                    7 : pqrs
                    8 : tuv
                    9 : wxyz

                Example:
                Input: "23"
                Output: ["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"].

                Time Complexity      : O(N * M) where N is the number of character in the input and M is the number of character in the dictionary for the matching character in input 
                Space Complexity     : O(N* M) where N is the number of character in the input and M is the number of character in the dictionary for the matching character in input  
             */

            StringBuilder result = new StringBuilder();
            List<string> inputs = new List<string>() {"23","234", "sdf23","1",""};
            IList<string> output = null;
            foreach(string input in inputs)
            {
                output = this.LetterCombinations(input);
                result.AppendLine($"List of string for the given input {input} is {(output == null ? "Invalid Input" : string.Join(@",", output))}");
            }

            MessageBox.Show(result.ToString());
       
        }

        public IList<string> LetterCombinations(string digits)
        {

            System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex(@"^[2-9]*$");

            if (string.IsNullOrEmpty(digits) || !(r.IsMatch(digits)))
            {
                return null;
            }

            string[] dict = new string[8] { "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
            int key = digits[0] - '2';
                        
            Queue<string> que = new Queue<string>();
            
            foreach (char c in dict[key])
            {
                que.Enqueue($"{c}");
            }

            string s = string.Empty;
            while (que.Count > 0)
            {
                s = que.Peek();

                if (s.Length == digits.Length)
                {
                    break;
                }
               que.Dequeue();

                key = digits[s.Length] - '2';

                foreach (char c in dict[key])
                {
                    que.Enqueue($"{s}{c}");
                }

            }

            return que.ToList<string>();
                
        }

        private void btn_Given_a_sequence_of_words_print_all_anagrams_together_Click(object sender, EventArgs e)
        {
            /* 
                Time Complexity  : O(N*M) N is the list of string and M is the total number of characters
                Space Complexity : O(N + M) 

            */

            StringBuilder result = new StringBuilder();
            List<string> strings = new List<string>() { "cat", "dog", "tac", "god", "act","abc" };
            var anagrams = this.GetListOfAnagrams(strings);
            foreach(List<string> s in anagrams)
            {
                result.AppendLine(string.Join(",",s));
            }
            MessageBox.Show($"The below are the group of anagrams for the given input strings {string.Join(",", strings)} \n\n {result.ToString()}");

        }

        private List<IList<string>> GetListOfAnagrams(List<string> strs)
        {

            if (strs == null || strs.Count == 0)
                return null;

            Dictionary<int, List<string>> dict = new Dictionary<int, List<string>>();
            List<string> temp;
            int dictkey;
            List<IList<string>> result = new List<IList<string>>();
            int[] key = new int[26];

            foreach (string str in strs)
            {
                key = new int[26];
                foreach (char c in str)
                {
                    key[c - 'a']++;
                }

                dictkey = string.Join("", key).GetHashCode();

                if (dict.TryGetValue(dictkey, out temp))
                {
                    temp.Add(str);
                }
                else
                {
                    dict[dictkey] = new List<String>() { str };
                }
            }

            foreach (int k in dict.Keys)
            {
                result.Add(dict[k]);
            }

            return result;

        }

        private void btn_Backspace_String_Compare_Click(object sender, EventArgs e)
        {

            Dictionary<int, int> dict = new Dictionary<int, int>();
            

            List<AddBinaryInputs> inputs = new List<AddBinaryInputs>() { new AddBinaryInputs() { inputA = "ab#c", inputB = "ad#c" } };
            StringBuilder result = new StringBuilder();

            foreach(var  input in inputs)
            {
                result.AppendLine($"Two strings {input.inputA} and {input.inputB} are backspace  {(this.BackspaceCompare(input.inputA, input.inputB) ? "" : " not ")} equal ");
            }

            MessageBox.Show(result.ToString());

        }


        public bool BackspaceCompare(string S, string T)
        {


            if (string.IsNullOrEmpty(S) || string.IsNullOrEmpty(T))
            {
                return false;
            }

            string s1 = this.RemoveBackSpace(S);
            string s2 = this.RemoveBackSpace(T);

            return s1 == s2;

        }

        public string RemoveBackSpace(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }

            Stack<char> stack = new Stack<char>();          

            foreach (char c in s)
            {
                if (c == '#' && stack.Count > 0)
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push(c);
                }
            }

          
            return string.Join("", stack);


        }

    
        private void btn_Valid_Parenthesis_String_2_Click(object sender, EventArgs e)
        {
            /* 
                Given a string containing only three types of characters: '(', ')' and '*', write a function to check whether 
                this string is valid. We define the validity of a string by these rules:
                1.) Any left parenthesis '(' must have a corresponding right parenthesis ')'.
                2.) Any right parenthesis ')' must have a corresponding left parenthesis '('.
                3.) Left parenthesis '(' must go before the corresponding right parenthesis ')'.
                4.) '*' could be treated as a single right parenthesis ')' or a single left parenthesis '(' or an empty string.
                5.) An empty string is also valid.
                Example 1:
                Input: "()"
                Output: True
                
                Example 2:
                Input: "(*)"
                Output: True
                
                Example 3:
                Input: "(*))"
                Output: True
                
                Note:
                    The string size will be in the range [1, 100]. 
            
                Time Complexity     :  O(N)
                Space complexity    :  O(1) constant space 

             */

            StringBuilder result = new StringBuilder();
            List<string> inputs = new List<string>();
            inputs.Add("()");
            inputs.Add("(*)");
            inputs.Add("((*)");
            inputs.Add("(*))");
            inputs.Add("())");
            foreach (string input in inputs)
            {
                result.AppendLine($"The given string {input} is {(this.IsValidParanthesis(input) ? "" : " not ") } valid string");
            }

            MessageBox.Show(result.ToString());

        }


        public bool IsValidParanthesis(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length == 0)
            {
                return true;
            }

            int l = 0;
            int h = 0;

            foreach(char c in input)
            {
                l += c == '(' ? 1 : -1;
                h += c != ')' ? 1 : -1;

                l = l < 0 ? 0: l;

                if (h < 0)
                {
                    return false;
                }

            }
            return l == 0;
            
        }


        private void btn_LongestCommonSubsequence_Click(object sender, EventArgs e)
        {
            /*
             
                Given two strings text1 and text2, return the length of their longest common subsequence.
                A subsequence of a string is a new string generated from the original string with some characters(can be none) deleted without changing the relative order of the remaining characters. (eg, "ace" is a subsequence of "abcde" while "aec" is not). A common subsequence of two strings is a subsequence that is common to both strings.

                If there is no common subsequence, return 0.

                Example 1:

                Input: text1 = "abcde", text2 = "ace" 
                Output: 3  
                Explanation: The longest common subsequence is "ace" and its length is 3.
                Example 2:

                Input: text1 = "abc", text2 = "abc"
                Output: 3
                Explanation: The longest common subsequence is "abc" and its length is 3.
                Example 3:

                Input: text1 = "abc", text2 = "def"
                Output: 0
                Explanation: There is no such common subsequence, so the result is 0.
                
                Time Complexity     : O(M*N)
                Space Complexity    : O(M*N)

             */


            StringBuilder result = new StringBuilder();
            List<IndexOf> inputs = new List<IndexOf>();
            inputs.Add(new IndexOf() {findIndex = "abcde", input="ace" });
            inputs.Add(new IndexOf() { findIndex = "abc", input = "abc" });
            inputs.Add(new IndexOf() { findIndex = "abc", input = "def" });

            foreach (var input in inputs )
            {
                result.AppendLine($"Longest Common Subsequence is {this.LongestCommonSubsequence(input.findIndex, input.input)} for the given strings {input.findIndex} and {input.input}");
            }

            MessageBox.Show(result.ToString());
        }


        public int LongestCommonSubsequence(string text1, string text2)
        {
            if (string.IsNullOrEmpty(text1) || text1.Length == 0)
            {
                return text2.Length;
            }

            if (string.IsNullOrEmpty(text2) || text2.Length == 0)
            {
                return text1.Length;
            }


            int[,] dict = new int[text1.Length + 1, text2.Length + 1];

            for (int row = 0; row < text1.Length; row++)
            {
                for (int col = 0; col < text2.Length; col++)
                {
                    if (text1[row] == text2[col])
                    {
                        dict[row + 1, col + 1] = 1 + dict[row, col];
                    }
                    else
                    {
                        dict[row + 1, col + 1] = Math.Max(dict[row +1, col], dict[row,col+1]);
                    }                    
                }
            }

            return dict[text1.Length, text2.Length];

        }

        private void btn_Find_All_Anagrams_in_a_String_Click(object sender, EventArgs e)
        {
            /*
        
                Given a string s and a non-empty string p, find all the start indices of p's anagrams in s.

                Strings consists of lowercase English letters only and the length of both strings s and p will not be larger than 20,100.

                The order of output does not matter.

                Example 1:

                Input:
                s: "cbaebabacd" p: "abc"

                Output:
                [0, 6]

                Explanation:
                The substring with start index = 0 is "cba", which is an anagram of "abc".
                The substring with start index = 6 is "bac", which is an anagram of "abc".
                Example 2:

                Input:
                s: "abab" p: "ab"

                Output:
                [0, 1, 2]

                Explanation:
                The substring with start index = 0 is "ab", which is an anagram of "ab".
                The substring with start index = 1 is "ba", which is an anagram of "ab".
                The substring with start index = 2 is "ab", which is an anagram of "ab".


                Time Complexity     :  O(N)
                Space Complexity    : O(1)
            */

            StringBuilder result = new StringBuilder();
            Dictionary<string, string> inputs = new Dictionary<string, string>();
            inputs.Add("abc", "cbaebabacd");

            foreach (string key in inputs.Keys)
            {
                result.AppendLine($"The anagram indexes are {string.Join(",",FindAnagrams(inputs[key], key))} for the given string {inputs[key]} and pattern {key} ");
            }


            MessageBox.Show(result.ToString());


        }

        public IList<int> FindAnagrams(string s, string p)
        {

            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(p) )
            {
                return null;
            }

            int[] dict = new int[26];

            foreach(char c in p)
            {
                dict[c - 'a']++;
            }

            List<int> result = new List<int>();

            int startIndex = -1;
            int count = 0;

            for(int i= 0; i < s.Length; i++)
            {
                if (dict[s[i] -'a'] > 0)
                {
                    count++;
                    if (startIndex == -1)
                    {
                        startIndex = i;
                    }

                    if (count == p.Length)
                    {
                        result.Add(startIndex);
                        count = 1;
                        startIndex = i;
                    }
                }
                else
                {
                    startIndex = -1;
                    count = 0;
                }           
            }
            return result;
        }

        private void btn_Permutation_in_String_Click(object sender, EventArgs e)
        {

            /*

                Given two strings s1 and s2, write a function to return true if s2 contains the permutation of s1. In other words, one of the first string's permutations is the substring of the second string. 
            
                Example 1:
                Input: s1 = "ab" s2 = "eidbaooo"
                Output: True
                Explanation: s2 contains one permutation of s1 ("ba").
            
                Example 2:
                Input:s1= "ab" s2 = "eidboaoo"
                Output: False
    
                Time Complexity     : O(alphabetSie* Length of S2 which is N)
                Space Complexity    : O(1)

            */

            StringBuilder result = new StringBuilder();
            Dictionary<string, string> inputs = new Dictionary<string, string>();
            inputs.Add("eidbaooo", "ab");
            inputs.Add("eidboaoo", "ab");
            inputs.Add("dcda","adc");


            foreach (string key in inputs.Keys)
            {
                result.AppendLine($"There is {(this.CheckInclusion(inputs[key], key) ? "" :" no ")}Permutation in String for the given string  {key} and pattern {inputs[key]} ");
            }


            MessageBox.Show(result.ToString());
        }

        public bool CheckInclusion(string s1, string s2)
        {

            if (string.IsNullOrEmpty(s1) || (string.IsNullOrEmpty(s1)))
                return false;

            int[] dic = new int[26];
            
            bool result = false;

            foreach (char ch in s1)
            {
                dic[ch - 'a']++;
            }

            int c = 0;
            int len = s1.Length;
            int p = 0;
            int prevp = 0;
            /*
                 inputs.Add("eidbaooo", "ab");
                 inputs.Add("eidboaoo", "ab");
                 inputs.Add("dcda","adc");
             */
            while (c < s2.Length)
            {
                if (dic[s2[c] - 'a'] > 0)
                {
                    dic[s2[c] - 'a']--;
                    p++;
                }
                else if (p > 0)
                {
                    prevp = p;
                    while (p > 0)
                    {                      
                        dic[s2[c-p] - 'a']++;
                        p--;                                                    
                    }
                    c -= prevp;
                    prevp = 0;
                }
                if (p == len)
                {
                    result = true;
                    break;
                }
                c++;
            }                                            
            return result;

        }

        private void btn_Sort_Characters_By_Frequency_Click(object sender, EventArgs e)
        {
            /*
                Given a string, sort it in decreasing order based on the frequency of characters.

                Example 1:

                Input:
                "tree"

                Output:
                "eert"

                Explanation:
                'e' appears twice while 'r' and 't' both appear once.
                So 'e' must appear before both 'r' and 't'. Therefore "eetr" is also a valid answer.
                Example 2:

                Input:
                "cccaaa"

                Output:
                "cccaaa"

                Explanation:
                Both 'c' and 'a' appear three times, so "aaaccc" is also a valid answer.
                Note that "cacaca" is incorrect, as the same characters must be together.
                Example 3:

                Input:
                "Aabb"

                Output:
                "bbAa"

                Explanation:
                "bbaA" is also a valid answer, but "Aabb" is incorrect.
                 Note that 'A' and 'a' are treated as two different characters.
    
                84ms:
                Time Complexity : O(N)
                Space Complexity: O(1)

                148ms:
                Time Complexity : O(N)
                Space Complexity: O(N)


            */




            StringBuilder result = new StringBuilder();
            List<string> inputs = new List<string>();
            inputs.Add("tree");
            inputs.Add("cccaaa");
            inputs.Add("Aabb");

            foreach (var input in inputs)
            {
                result.AppendLine($"Frequency sort 148 ms is {this.FrequencySort_148ms(input)} for the given strings {input}");
                result.AppendLine($"Frequency sort 84 ms is {this.FrequencySort_84ms(input)} for the given strings {input}");
                
            }

            MessageBox.Show(result.ToString());

        }

        public string FrequencySort_84ms(string s)
        {
            
            var ansi = new int[256];
            foreach (var c in s)
            {
                ansi[c]++;
            }
            var strs = new StringBuilder[s.Length + 1];
            for (var i = 0; i < ansi.Length; i++)
            {
                if (strs[ansi[i]] == null)
                {
                    strs[ansi[i]] = new StringBuilder();
                }
                strs[ansi[i]].Append((char)i, ansi[i]);

            }
            var sb = new StringBuilder();
            for (int i = strs.Length - 1; i >= 0; --i)
            {
                if (strs[i] == null) continue;
                sb.Append(strs[i]);
            }
            return sb.ToString();
        }

        public string FrequencySort_148ms(string s)
        {

            if (string.IsNullOrEmpty(s))
                return s;

            Dictionary<char, int> freq = new Dictionary<char, int>();
            Dictionary<int, HashSet<char>> freqData = new Dictionary<int, HashSet<char>>();
            int maxCounter = 0;
            int counter = 0;
            HashSet<char> temp;

            foreach (char c in s)
            {
                counter = 0;
                temp = null;
                if (!freq.TryGetValue(c, out counter))
                {
                    counter = 1;
                    freq[c] = counter;
                    if (!freqData.TryGetValue(counter, out temp))
                        freqData[counter] = new HashSet<char>() { c };
                    else
                    {
                        temp.Add(c);
                    }
                }
                else
                {
                    freq[c]++;
                    freqData[counter].Remove(c);
                    counter++;
                    freqData.TryGetValue(counter, out temp);
                    if (temp == null)
                    {
                        temp = new HashSet<char>() { c };
                        freqData[counter] = temp;
                    }
                    else
                    {
                        temp.Add(c);
                    }
                }

                if (maxCounter < counter)
                    maxCounter = counter;
            }

            return this.GetSortedString(freqData, maxCounter);
        }

        private string GetSortedString(Dictionary<int, HashSet<char>> freqData, int counter)
        {
            StringBuilder result = new StringBuilder();

            HashSet<char> dict;

            while (counter > 0)
            {
                if (freqData.TryGetValue(counter, out dict))
                {
                    foreach (char c in dict)
                    {
                        result.Append(new String(c, counter));
                    }
                    counter--;
                }
            }


            return result.ToString();
        }

        private void btn_Edit_Distance_Click(object sender, EventArgs e)
        {
            /*
            
            Given two words word1 and word2, find the minimum number of operations required to convert word1 to word2.

            You have the following 3 operations permitted on a word:

            Insert a character
            Delete a character
            Replace a character
            Example 1:

            Input: word1 = "horse", word2 = "ros"
            Output: 3
            Explanation: 
            horse -> rorse (replace 'h' with 'r')
            rorse -> rose (remove 'r')
            rose -> ros (remove 'e')
            Example 2:

            Input: word1 = "intention", word2 = "execution"
            Output: 5
            Explanation: 
            intention -> inention (remove 't')
            inention -> enention (replace 'i' with 'e')
            enention -> exention (replace 'n' with 'x')
            exention -> exection (replace 'n' with 'c')
            exection -> execution (insert 'u')

            Time Complexity         : O(NM)
            Space Complexity        : O(NM)
              
             */

            StringBuilder result = new StringBuilder();
            List<AddBinaryInputs> inputs = new List<AddBinaryInputs>();
            inputs.Add(new AddBinaryInputs() { inputA = "horse", inputB = "ros" });
            inputs.Add(new AddBinaryInputs() { inputA = "intention", inputB = "execution" });

            foreach(var input in inputs)
            {
                result.AppendLine($"Edit Disance is {this.MinDistance(input.inputA, input.inputB)} for the string1 : {input.inputA} and string2: {input.inputB}");
            }

            MessageBox.Show(result.ToString());


        }


        

        public int MinDistance(string word1, string word2)
        {

            if (word1 == null && word2 == null)
                return 0;


            int rl = word1.Length + 1;
            int cl = word2.Length + 1;
            int[][] dict = new int[rl][];

            for (int r = 0; r < rl; r++)
            {
                if (dict[r] == null)
                {
                    dict[r] = new int[cl];
                }

                if (r == 0)
                    dict[r][0] = 0;
                else
                    dict[r][0] = r;
            }

            for (int c = 1; c < cl; c++)
            {
                dict[0][c] = c;
            }


            for (int r = 1; r < rl; r++)
            {
                for (int c = 1; c < cl; c++)
                {
                    if (word1[r - 1] == word2[c - 1])
                        dict[r][c] = dict[r - 1][c - 1];
                    else
                        dict[r][c] = Math.Min(dict[r - 1][c - 1], Math.Min(dict[r][c - 1], dict[r - 1][c]));
                }
            }

            return dict[rl - 1][cl - 1];

        }

        private void btn_Is_Subsequence_Click(object sender, EventArgs e)
        {
            /*

                Given a string s and a string t, check if s is subsequence of t.

                A subsequence of a string is a new string which is formed from the original string by deleting some (can be none) of the characters without disturbing the relative positions of the remaining characters. (ie, "ace" is a subsequence of "abcde" while "aec" is not).

                Follow up:
                If there are lots of incoming S, say S1, S2, ... , Sk where k >= 1B, and you want to check one by one to see if T has its subsequence. In this scenario, how would you change your code?

                Credits:
                Special thanks to @pbrother for adding this problem and creating all test cases.

 

                Example 1:
                Input: s = "abc", t = "ahbgdc"
                Output: true
                
                Example 2:
                Input: s = "axc", t = "ahbgdc"
                Output: false

                Time Complexity         : O(S + T)
                Space Complexity        : O(1)
            */


            StringBuilder result = new StringBuilder();
            List<AddBinaryInputs> inputs = new List<AddBinaryInputs>();
            inputs.Add(new AddBinaryInputs() { inputA = "abc", inputB = "ahbgdc" });
            inputs.Add(new AddBinaryInputs() { inputA = "axc", inputB = "ahbgdc" });
            inputs.Add(new AddBinaryInputs() { inputA = "", inputB = "" });
            inputs.Add(new AddBinaryInputs() { inputA = "abc", inputB = "" });
            inputs.Add(new AddBinaryInputs() { inputA = "abc", inputB = "ahgdb" });

            foreach (var input in inputs)
            {
                result.AppendLine($"Sequence {(this.IsSubsequence(input.inputA, input.inputB) ? "" : "does not")} exists for the string1 : {input.inputA} and string2: {input.inputB}");
            }

            MessageBox.Show(result.ToString());

        }

        public bool IsSubsequence(string s, string t)
        {

            /*
                My solution 

                   int c = 0;
                   int counter = 0;
                   for(int r = 0; r < s.Length; r++)
                   {
                       for(; c < t.Length; c++)
                       {
                           if (s[r] == t[c])
                           {
                               counter++;
                               c++;
                               break;
                           }
                       }
                   }
        
                   return counter == s.Length;

             */

            if (s == "")
                return true;
            if (t == "")
                return false;
            var index = 0;
            var length = s.Length;
            var curChar = s[index];
            foreach (var c in t)
            {
                if (c == curChar)
                {
                    index++;
                    if (index == length)
                        return true;
                    curChar = s[index];
                }
            }
            return false;



        }

        private void btn_Validate_IP_Address_Click(object sender, EventArgs e)
        {
            /*
            
                Write a function to check whether an input string is a valid IPv4 address or IPv6 address or neither.

                IPv4 addresses are canonically represented in dot-decimal notation, which consists of four decimal numbers, each ranging from 0 to 255, separated by dots ("."), e.g.,172.16.254.1;

                Besides, leading zeros in the IPv4 is invalid. For example, the address 172.16.254.01 is invalid.

                IPv6 addresses are represented as eight groups of four hexadecimal digits, each group representing 16 bits. The groups are separated by colons (":"). For example, the address 2001:0db8:85a3:0000:0000:8a2e:0370:7334 is a valid one. Also, we could omit some leading zeros among four hexadecimal digits and some low-case characters in the address to upper-case ones, so 2001:db8:85a3:0:0:8A2E:0370:7334 is also a valid IPv6 address(Omit leading zeros and using upper cases).

                However, we don't replace a consecutive group of zero value with a single empty group using two consecutive colons (::) to pursue simplicity. For example, 2001:0db8:85a3::8A2E:0370:7334 is an invalid IPv6 address.

                Besides, extra leading zeros in the IPv6 is also invalid. For example, the address 02001:0db8:85a3:0000:0000:8a2e:0370:7334 is invalid.

                Note: You may assume there is no extra space or special characters in the input string.

                Example 1:
                Input: "172.16.254.1"

                Output: "IPv4"

                Explanation: This is a valid IPv4 address, return "IPv4".
                Example 2:
                Input: "2001:0db8:85a3:0:0:8A2E:0370:7334"

                Output: "IPv6"

                Explanation: This is a valid IPv6 address, return "IPv6".
                Example 3:
                Input: "256.256.256.256"

                Output: "Neither"

                Explanation: This is neither a IPv4 address nor a IPv6 address.


                Time Complexity         : O(N)
                Space Complexity        : O(1)

             */

            StringBuilder result = new StringBuilder();
            List<string> inputs = new List<string>();
            inputs.Add("172.16.254.1");
            inputs.Add("2001:0db8:85a3:0:0:8A2E:0370:7334");
            inputs.Add("256.256.256.256");
            inputs.Add("2001:0db8:85a3:0:0:8A2E:0370:7334");
            inputs.Add("1.1.1.01");          

            foreach (var input in inputs)
            {
                result.AppendLine($"The given IP address {input } is {this.ValidIPAddress(input)}");
            }

            MessageBox.Show(result.ToString());
        }

        public string ValidIPAddress(string IP)
        {

            string result = "Neither";
            if (IP == null || IP.Length == 0)
                return result;

            if (IP.IndexOf('.') != -1)
            {
                if (IsValidIpv4(IP.Split('.')))
                    result = "IPv4";
            }
            else if (IsValidIpv6(IP.Split(':')))
                result = "IPv6";

            return result;

        }


        private bool IsValidIpv6(string[] ips)
        {
            if (ips == null || ips.Length != 8)
                return false;

            foreach (string ip in ips)
            {
                if (!ValidateIp6(ip))
                    return false;
            }

            return true;
        }


        private bool ValidateIp6(string ip)
        {
            if (ip == null || ip.Length == 0)
                return false;


            if (ip.Length >= 1 && ip.Length <= 4)
            {
                foreach (char c in ip)
                {
                    if (!(
                            (c >= '0' && c <= '9') ||
                            (c >= 'a' && c <= 'f') ||
                            (c >= 'A' && c <= 'F')
                        ))
                        return false;
                }
            }
            else
                return false;


            return true;
        }

        private bool IsValidIpv4(string[] ips)
        {
            if (ips == null || ips.Length != 4)
                return false;

            int result = 0;

            foreach (string ip in ips)
            {
                if (ip.Length >= 1 && ip.Length <= 3)
                {
                    result = Atoi(ip);
                    if (!(result >= 0 && result <= 255))
                        return false;
                }
                else
                    return false;
            }

            return true;
        }

        private int Atoi(string s)
        {

            if (string.IsNullOrEmpty(s) || s[0] == '0')
                return -1;

            int i = 0;
            int result = 0;
            int t = 0;

            while (i < s.Length)
            {
                t = s[i] - '0';
                result = (result * 10) + t;
                i++;
            }

            return result;
        }

        private void btn_Longest_Duplicate_Substring_Click(object sender, EventArgs e)
        {
                  
            /*
            

                Given a string S, consider all duplicated substrings: (contiguous) substrings of S that occur 2 or more times.  (The occurrences may overlap.)

                Return any duplicated substring that has the longest possible length.  (If S does not have a duplicated substring, the answer is "".)

                Example 1:
                Input: "banana"
                Output: "ana"
                
                Example 2:
                Input: "abcd"
                Output: ""
 
                Note:
                2 <= S.length <= 10^5
                S consists of lowercase English letters.
                
                Hint #1  
                Binary search for the length of the answer. (If there's an answer of length 10, then there are answers of length 9, 8, 7, ...)
                
                Hint #2  
                To check whether an answer of length K exists, we can use Rabin-Karp 's algorithm.
             */

            string str = string.Join("", "123", 'c');
                     
        }

        private void btn_Reconstruct_Itinerary_Click(object sender, EventArgs e)
        {
            /*

                Reconstruct Itinerary
                Solution
                Given a list of airline tickets represented by pairs of departure and arrival airports [from, to], reconstruct the itinerary in order. All of the tickets belong to a man who departs from JFK. Thus, the itinerary must begin with JFK.
                
                Note:
                If there are multiple valid itineraries, you should return the itinerary that has the smallest lexical order when read as a single string. For example, the itinerary ["JFK", "LGA"] has a smaller lexical order than ["JFK", "LGB"].
                All airports are represented by three capital letters (IATA code).
                You may assume all tickets form at least one valid itinerary.
                One must use all the tickets once and only once.
                Example 1:

                Input: [["MUC", "LHR"], ["JFK", "MUC"], ["SFO", "SJC"], ["LHR", "SFO"]]
                Output: ["JFK", "MUC", "LHR", "SFO", "SJC"]
                Example 2:

                Input: [["JFK","SFO"],["JFK","ATL"],["SFO","ATL"],["ATL","JFK"],["ATL","SFO"]]
                Output: ["JFK","ATL","JFK","SFO","ATL","SFO"]
                Explanation: Another possible reconstruction is ["JFK","SFO","ATL","JFK","ATL","SFO"].
                             But it is larger in lexical order.
            
                Time Complexity     :   O(N) + O(N Log N)
                Space Complexity    :   O(N) 
             
             */



            StringBuilder result = new StringBuilder();

            List<IList<int>> r = new List<IList<int>>();
            r.Add(new List<int>() { 1, 2 });

            IList<IList<IList<string>>> inputs = new List<IList<IList<string>>>();
            inputs.Add(new List<IList<string>>()
                        {
                            new List<string> { "JFK", "SFO" },
                            new List<string> { "JFK", "ATL" },
                            new List<string> { "SFO", "ATL" },
                            new List<string> {  "ATL", "JFK" },
                            new List<string> {  "ATL", "SFO" }
                        });


            //inputs.Add(new List<IList<string>>()
            //            {
            //                new List<string> { "MUC", "LHR" },
            //                new List<string> { "JFK", "MUC" },
            //                new List<string> { "SFO", "SJC" },
            //                new List<string> {  "LHR", "SFO" }
            //            });

            //inputs.Add(new List<IList<string>>()
            //            {
            //                new List<string> { "JFK", "KUL" },
            //                new List<string> { "JFK", "NRT" },
            //                new List<string> { "NRT", "JFK" }
            //            });

            


            foreach (var input in inputs)
            {                
                result.AppendLine($"The Iternary is {string.Join("-> ", (this.FindItinerary(input))) } for the given input {string.Join(" ",input)} ");
            }

            MessageBox.Show(result.ToString());



        }


        public IList<string> FindItinerary(IList<IList<string>> tickets)
        {
                        
            return this.GetItinerary(this.ParseData(tickets));
        }

        private Dictionary<string, List<string>> ParseData(IList<IList<string>> tickets)
        {
            if (tickets == null || tickets.Count == 0)
                return null;

            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
            List<String> it;

            foreach (var ticket in tickets)
            {
                    if (!dict.TryGetValue(ticket[0], out it))
                        dict[ticket[0]] = new List<string>() { ticket[1] };
                    else
                    {
                        it.Add(ticket[1]);                        
                    }                
            }

            return dict;
        }


        private IList<string> GetItinerary(Dictionary<string, List<string>> itr)
        {
            if (itr == null || itr.Count == 0)
                return new List<string>();

          
            Stack<string> result = new Stack<string>();
            List<string> tempItr;
            Stack<string> s = new Stack<string>();
            s.Push("JFK");
            String t;

            while (s.Count > 0)
            {
                t = s.Peek();
                if (!itr.TryGetValue(t, out tempItr) || tempItr.Count == 0)
                {
                    result.Push(t);
                    s.Pop();
                }
                else
                {
                    if (tempItr.Count > 1 )
                        tempItr.Sort();
                    s.Push(tempItr[0]);
                    tempItr.RemoveAt(0);
                }
            }

            return result.ToList<string>();

        }


        private void  Test()
        {
            CounterCreationDataCollection counterDataCollection = new CounterCreationDataCollection();

            // Add the counter.
            CounterCreationData test1 = new CounterCreationData();
            test1.CounterType = PerformanceCounterType.NumberOfItems32;
            test1.CounterName = "Scheduler: Waiting";
            test1.CounterHelp = "An increasing value indicates the scheduler thread is running and checking the schedule for the next start or stop time.";
            counterDataCollection.Add(test1);

            CounterCreationData test2 = new CounterCreationData();
            test2.CounterType = PerformanceCounterType.NumberOfItems32;
            test2.CounterName = "Processor: Waiting";
            test2.CounterHelp = "An increasing value indicates the subscription processing thread is waiting for the scheduler to signal the start of processing.";
            counterDataCollection.Add(test2);


            CounterCreationData test3 = new CounterCreationData();
            test3.CounterType = PerformanceCounterType.NumberOfItems32;
            test3.CounterName = "Processor: Processing";
            test3.CounterHelp = "An increasing value indicates the subscription processing thread is actively processing subscriptions.";
            counterDataCollection.Add(test3);


            CounterCreationData test4 = new CounterCreationData();
            test4.CounterType = PerformanceCounterType.NumberOfItems32;
            test4.CounterName = "Subscriptions: # processed in latest run";
            test4.CounterHelp = "The total number of subscriptions processed in the current or most recent run.";
            counterDataCollection.Add(test4);

            CounterCreationData test5 = new CounterCreationData();
            test5.CounterType = PerformanceCounterType.NumberOfItems32;
            test5.CounterName = "Subscriptions: Total # processed";
            test5.CounterHelp = "The total number of subscriptions processed since the service was started.";
            counterDataCollection.Add(test5);


            CounterCreationData test6 = new CounterCreationData();
            test6.CounterType = PerformanceCounterType.NumberOfItems32;
            test6.CounterName = "Processor: Busy threads";
            test6.CounterHelp = "The number of subscriptions currently being processed by the worker threads.";
            counterDataCollection.Add(test6);


            CounterCreationData test7 = new CounterCreationData();
            test7.CounterType = PerformanceCounterType.NumberOfItems32;
            test7.CounterName = "Processor: Problem detected";
            test7.CounterHelp = "If this value is not 0 then it appears the processor thread is not responding. The service should be restarted.";
            counterDataCollection.Add(test7);

            CounterCreationData test8 = new CounterCreationData();
            test8.CounterType = PerformanceCounterType.RateOfCountsPerSecond32;
            test8.CounterName = "Processor: Subscriptions per second";
            test8.CounterHelp = "Number of subscriptions processed per second during the current sampling period.";
            counterDataCollection.Add(test8);

            CounterCreationData test9 = new CounterCreationData();
            test9.CounterType = PerformanceCounterType.NumberOfItems32;
            test9.CounterName = "Transact: Total current connections to transact";
            test9.CounterHelp = "The total number of active connections to transact at this moment.";
            counterDataCollection.Add(test9);






            // Create the category.
            PerformanceCounterCategory.Create("ANET ARBTransGen",
                "ANET ARBTransGen",
                PerformanceCounterCategoryType.SingleInstance, counterDataCollection);

        }

        private void btn_Detect_Capital_Click(object sender, EventArgs e)
        {

         
            /*
             
                Given a word, you need to judge whether the usage of capitals in it is right or not.

                We define the usage of capitals in a word to be right when one of the following cases holds:

                All letters in this word are capitals, like "USA".
                All letters in this word are not capitals, like "leetcode".
                Only the first letter in this word is capital, like "Google".
                Otherwise, we define that this word doesn't use capitals in a right way.
 

                Example 1:

                Input: "USA"
                Output: True
 

                Example 2:

                Input: "FlaG"
                Output: False
 

                Note: The input will be a non-empty word consisting of uppercase and lowercase latin letters.

                Time Complexity     : O(N)
                Space Complexity    : O(1)

            */


            StringBuilder result = new StringBuilder();
            List<string> inputs = new List<string>();
            inputs.Add("USA");
            inputs.Add("Google");
            inputs.Add("leetcode");
            inputs.Add("leetCode");
            inputs.Add("123");
            inputs.Add("g");           

            foreach (var input in inputs)
            {
                result.AppendLine($"The given string {input} is Capital {(this.DetectCapitalUse(input) ? "true" : "false")}");
            }

            MessageBox.Show(result.ToString());

           

        }

        public bool DetectCapitalUse(string word)
        {

            if (string.IsNullOrEmpty(word))
                return true;

            if (word.Length == 1)
                return true;

            bool isFullCaps = word[0]  >= 65 && word[0] <= 90 && word[1]  >= 65 && word[1]  <= 90;
            bool isFirstCapsAndSmall = !isFullCaps && word[0] >= 65 && word[0] <= 90 && word[1]  >= 97 && word[1]  <= 122;
            bool isSmall = !isFirstCapsAndSmall && word[0]  >= 97 && word[0]  <= 122 && word[1]  >= 97 && word[1] <= 122;

            if (!isFullCaps && !isFirstCapsAndSmall && !isSmall)
                return false;

            for (int i = 2; i < word.Length; i++)
            {
                if (isFullCaps && !(word[i] >= 65 && word[i]<= 90))
                    return false;
                else if (isFirstCapsAndSmall && !(word[i]  >= 97 && word[i]  <= 122))
                    return false;
                else if (isSmall && !(word[i]  >= 97 && word[i] <= 122))
                    return false;

            }


            return true;
        }

        private void btn_Excel_Sheet_Column_Number_Click(object sender, EventArgs e)
        {
            /*
            
                Given a column title as appear in an Excel sheet, return its corresponding column number.

                For example:

                    A -> 1
                    B -> 2
                    C -> 3
                    ...
                    Z -> 26
                    AA -> 27
                    AB -> 28 
                    ...
                Example 1:

                Input: "A"
                Output: 1
                Example 2:

                Input: "AB"
                Output: 28
                Example 3:

                Input: "ZY"
                Output: 701

                Time Complexity      : O(N)
                Space Complexity     : O(1)

            */

            StringBuilder result = new StringBuilder();
            List<string> inputs = new List<string>();
            inputs.Add("A");
            inputs.Add("ZY");
            inputs.Add("ABA");
            

            foreach (var input in inputs)
            {
                result.AppendLine($"Title To Number is {this.TitleToNumber(input)} for the given input {input}");
            }

            MessageBox.Show(result.ToString());


        }


        public int TitleToNumber(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            int result = 0;
            int pow = 1;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                result += ((s[i] - 'A') + 1) * pow;
                pow *= 26;
            }

            return result;

        }

        private void btn_Iterator_for_Combination_Click(object sender, EventArgs e)
        {
            
            /*
            
                Design an Iterator class, which has:

                A constructor that takes a string characters of sorted distinct lowercase English letters and a number combinationLength as arguments.
                A function next() that returns the next combination of length combinationLength in lexicographical order.
                A function hasNext() that returns True if and only if there exists a next combination.
 

                Example:

                CombinationIterator iterator = new CombinationIterator("abc", 2); // creates the iterator.

                iterator.next(); // returns "ab"
                iterator.hasNext(); // returns true
                iterator.next(); // returns "ac"
                iterator.hasNext(); // returns true
                iterator.next(); // returns "bc"
                iterator.hasNext(); // returns false
 

                Constraints:

                1 <= combinationLength <= characters.length <= 15
                There will be at most 10^4 function calls per test.
                It's guaranteed that all calls of the function next are valid.

            */

            StringBuilder result = new StringBuilder();
            CombinationIterator ci = new CombinationIterator("abc", 2);
            result.AppendLine(ci.Next());
            result.AppendLine(ci.HasNext() ? "true" : "false");
            result.AppendLine(ci.Next());
            result.AppendLine(ci.HasNext() ? "true" : "false");
            result.AppendLine(ci.Next());
            result.AppendLine(ci.HasNext() ? "true" : "false");
            MessageBox.Show(result.ToString());
        }

        public class CombinationIterator
        {

            string datas = null;
            List<string> dict = null;
            int currPos = 0;
            int cl = 0;
            int len = 0;

            public CombinationIterator(string characters, int combinationLength)
            {
                this.datas = characters;
                dict = new List<string>();
                cl = combinationLength;
                ParseData(characters, "");
                len = dict.Count;
            }

            public string Next()
            {

                string result = string.Empty;
                if (currPos < len)
                {
                    result = dict[currPos];
                    currPos++;
                }
                return result;
            }

            public bool HasNext()
            {
                return currPos < len;
            }

            /* 
                ab
                ac
                bc
            */

            private void ParseData(string data, string conc)
            {
                /*
                    abc      ""
                        bc        a
                            c     ab
                */
                if (conc.Length == cl)
                {
                    dict.Add(conc);
                    return;
                }

                if (string.IsNullOrEmpty(data))
                    return;

                for (int i = 0; i < data.Length; i++)
                    ParseData(data.Substring(i + 1), conc + data.Substring(i, 1));

            }
        }

        private void btn_Longest_Palindrome_Click(object sender, EventArgs e)
        {
            /*
                Given a string which consists of lowercase or uppercase letters, find the length of the longest palindromes that can be built with those letters.

                This is case sensitive, for example "Aa" is not considered a palindrome here.

                Note:
                Assume the length of given string will not exceed 1,010.

                Example:

                Input:
                "abccccdd"

                Output:
                7

                Explanation:
                One longest palindrome that can be built is "dccaccd", whose length is 7.

                Time Complexity     : O(N)
                Space Complexity    : O(N)
             
             */


            StringBuilder result = new StringBuilder();
            List<string> inputs = new List<string>();
            inputs.Add("abccccdd");
    

            foreach (var input in inputs)
            {
                result.AppendLine($"Longest Palindrome is {this.LongestPalindrome(input)} for the given input {input}");
            }

            MessageBox.Show(result.ToString());

        }

        public int LongestPalindrome(string s)
        {

            

            if (string.IsNullOrEmpty(s))
                return 0;

            Dictionary<char, int> dict = new Dictionary<char, int>();

            int pos = 0;
            int neg = 0;
            bool isNeg = false;

            foreach (char c in s)
            {
                if (!dict.ContainsKey(c))
                    dict[c] = 1;
                else
                    dict[c]++;
            }

            int temp = 0;
            foreach (char c in dict.Keys)
            {
                temp = dict[c];
                if (temp % 2 == 0)
                    pos += temp;
                else
                {
                    neg += (temp - 1);
                    isNeg = true;
                }
            }

            return pos + neg + (isNeg ? 1 : 0);

        }

        private void btn_Goat_Latin_Click(object sender, EventArgs e)
        {
            /*

                A sentence S is given, composed of words separated by spaces. Each word consists of lowercase and uppercase letters only.

                We would like to convert the sentence to "Goat Latin" (a made-up language similar to Pig Latin.)

                The rules of Goat Latin are as follows:

                If a word begins with a vowel (a, e, i, o, or u), append "ma" to the end of the word.
                For example, the word 'apple' becomes 'applema'.
 
                If a word begins with a consonant (i.e. not a vowel), remove the first letter and append it to the end, then add "ma".
                For example, the word "goat" becomes "oatgma".
 
                Add one letter 'a' to the end of each word per its word index in the sentence, starting with 1.
                For example, the first word gets "a" added to the end, the second word gets "aa" added to the end and so on.
                Return the final sentence representing the conversion from S to Goat Latin. 

 

                Example 1:

                Input: "I speak Goat Latin"
                Output: "Imaa peaksmaaa oatGmaaaa atinLmaaaaa"
                Example 2:

                Input: "The quick brown fox jumped over the lazy dog"
                Output: "heTmaa uickqmaaa rownbmaaaa oxfmaaaaa umpedjmaaaaaa overmaaaaaaa hetmaaaaaaaa azylmaaaaaaaaa ogdmaaaaaaaaaa"
 

                Notes:

                S contains only uppercase, lowercase and spaces. Exactly one space between each word.
                1 <= S.length <= 150.


                Time Complexity     :  O(N)
                Space Complexity    :  O(N)

             */


            StringBuilder result = new StringBuilder();
            List<string> inputs = new List<string>();
            inputs.Add("I speak Goat Latin");
            inputs.Add("The quick brown fox jumped over the lazy dog");

            foreach (var input in inputs)
            {
                acounter = 1;
                result.AppendLine($"Goat Latin for the given input : \n{input} is \n{ToGoatLatin(input)} \n");
            }

            MessageBox.Show(result.ToString());
        }

        public string ToGoatLatin(string S)
        {

            if (string.IsNullOrEmpty(S))
                return S;

            StringBuilder result = new StringBuilder();
            string[] words = S.Split(' ');

            foreach (string word in words)
            {
                result.Append($"{Vowel(word)}{NonVowel(word)}{Repeat(acounter)}{(acounter == words.Length ? "" : " ")}");
                acounter++;
            }

            return result.ToString();

        }

        private string Vowel(string s)
        {
            StringBuilder result = new StringBuilder();
            if (vowel.Contains(s[0]))
            {
                result.Append($"{s}ma");
            }
            return result.ToString();
        }

        private string NonVowel(string s)
        {
            StringBuilder result = new StringBuilder();
            if (!vowel.Contains(s[0]))
            {
                result.Append($"{s.Substring(1)}{s[0]}ma");
            }

            return result.ToString();
        }

        private string Repeat(int n)
        {
            return new String('a', n);
        }

        private void btn_Repeated_Substring_Pattern_Click(object sender, EventArgs e)
        {
            /*
             
                Given a non-empty string check if it can be constructed by taking a substring of it and appending multiple copies of the substring together. You may assume the given string consists of lowercase English letters only and its length will not exceed 10000.

                Example 1:

                Input: "abab"
                Output: True
                Explanation: It's the substring "ab" twice.
                Example 2:

                Input: "aba"
                Output: False
                Example 3:

                Input: "abcabcabcabc"
                Output: True
                Explanation: It's the substring "abc" four times. (And the substring "abcabc" twice.)
             
                Time Complexity     : O(N)
                Space Complexity    : O(N)
             
             */

            StringBuilder result = new StringBuilder();
            List<string> inputs = new List<string>();
            inputs.Add("abab");
            inputs.Add("aba");
            inputs.Add("aabaaba");
            inputs.Add("abcabcabcabc");
            foreach (string input in inputs)
            {
                result.AppendLine($"Repeated Substring pattern {(RepeatedSubstringPattern(input)? "": " not ")} exists for the given input string {input}");
            }
            
            MessageBox.Show(result.ToString());


        }

        public bool RepeatedSubstringPattern(string s)
        {
            if (string.IsNullOrEmpty(s))
                return false;

            string subString = string.Empty;
            string temp = string.Empty;
            int l = s.Length;
            int sl = 0;

            for (int i = 0; i < l/2; i++)
            {
                subString = $"{subString}{s[i]}";
                sl = subString.Length;

                if ((l % sl) == 0)
                {
                    if (s.CompareTo(string.Join("",Enumerable.Repeat(subString, l / subString.Length))) == 0)
                        return true;                    
                }
            }
            return false;
        }

        private void btn_Partition_Labels_Click(object sender, EventArgs e)
        {
            /*

             A string S of lowercase English letters is given. We want to partition this string into as many parts as possible so that each letter appears in at most one part, and return a list of integers representing the size of these parts.
 

            Example 1:

            Input: S = "ababcbacadefegdehijhklij"
            Output: [9,7,8]
            Explanation:
            The partition is "ababcbaca", "defegde", "hijhklij".
            This is a partition so that each letter appears in at most one part.
            A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits S into less parts.
 

            Note:

            S will have length in range [1, 500].
            S will consist of lowercase English letters ('a' to 'z') only.

            Time Complexity     :   O(N)
            Space Complexity    :   O(26)

            */

            StringBuilder result = new StringBuilder();
            List<string> inputs = new List<string>();
            inputs.Add("ababcbacadefegdehijhklij");
            inputs.Add("aba");
            inputs.Add("aabaaba");
            inputs.Add("abcabcabcabc");
            foreach (string input in inputs)
            {
                result.AppendLine($"Partition Labels is  {string.Join(",",PartitionLabels(input))} for the given input string {input}");
            }

            MessageBox.Show(result.ToString());


        }

        public IList<int> PartitionLabels(string S)
        {
            List<int> result = new List<int>();
            if (string.IsNullOrEmpty(S))
                return result;

            int[] dict = new int[26];
            int start = 0;
            int j = 0;

            for (int i = 0; i < S.Length; i++)
                dict[S[i] - 'a'] = i;

            for (int i = 0; i < S.Length; i++)
            {
                j = Math.Max(j, dict[S[i] - 'a']);

                if (i == j)
                {
                    result.Add(j + 1 - start);
                    start = i + 1;
                }

            }

            return result;

        }

        private void btn_Word_Pattern_Click(object sender, EventArgs e)
        {

            /*
             
                Given a pattern and a string str, find if str follows the same pattern.

                Here follow means a full match, such that there is a bijection between a letter in pattern and a non-empty word in str.

                Example 1:

                Input: pattern = "abba", str = "dog cat cat dog"
                Output: true
                Example 2:

                Input:pattern = "abba", str = "dog cat cat fish"
                Output: false
                Example 3:

                Input: pattern = "aaaa", str = "dog cat cat dog"
                Output: false
                Example 4:

                Input: pattern = "abba", str = "dog dog dog dog"
                Output: false
                Notes:
                You may assume pattern contains only lowercase letters, and str contains lowercase letters that may be separated by a single space.

                Time Complexity             : O(N+M)
                Space Complexity            : O(N+M)

            */

            StringBuilder result = new StringBuilder();
            List<AddBinaryInputs> inputs = new List<AddBinaryInputs>();
            inputs.Add(new AddBinaryInputs() { inputA = "abba", inputB = "dog cat cat dog" });
            inputs.Add(new AddBinaryInputs() { inputA = "abba", inputB = "dog cat cat fish" });
            inputs.Add(new AddBinaryInputs() { inputA = "aaaa", inputB = "dog cat cat dog" });
            inputs.Add(new AddBinaryInputs() { inputA = "abba", inputB = "dog dog dog dog" });
                        

            foreach (AddBinaryInputs input in inputs)
            {
                result.AppendLine($"Word Pattern {(WordPattern(input.inputA, input.inputB) ? "": " not ")}  exists given pattern : {input.inputA} and string : {input.inputB}");
            }

            MessageBox.Show(result.ToString());

        }


        public bool WordPattern(string pattern, string str)
        {
            
            

            if (string.IsNullOrEmpty(pattern) || string.IsNullOrEmpty(str))
                return false;

            Dictionary<char, string> ds = new Dictionary<char, string>();
            Dictionary<string, char> dc = new Dictionary<string, char>();
            int charLen = pattern.Length;
            string[] strs = str.Split(' ');

            string temps = null;
            char tempc = '\0';

            if (strs.Length - 1 != charLen - 1)
                return false;

            for (int i = 0; i < charLen; i++)
            {
                ds.TryGetValue(pattern[i], out temps);
                dc.TryGetValue(strs[i], out tempc);

                if (temps == null)
                {
                    ds.Add(pattern[i], strs[i]);
                    temps = strs[i];
                }

                if (tempc == '\0')
                {
                    dc.Add(strs[i], pattern[i]);
                    tempc = pattern[i];
                }

                if (temps.CompareTo(strs[i]) != 0 || tempc != pattern[i])
                    return false;
            }

            return true;
        }

        private void btn_Compare_Version_Numbers_Click(object sender, EventArgs e)
        {
            /*

                Compare two version numbers version1 and version2.
                If version1 > version2 return 1; if version1 < version2 return -1;otherwise return 0.

                You may assume that the version strings are non-empty and contain only digits and the . character.

                The . character does not represent a decimal point and is used to separate number sequences.

                For instance, 2.5 is not "two and a half" or "half way to version three", it is the fifth second-level revision of the second first-level revision.

                You may assume the default revision number for each level of a version number to be 0. For example, version number 3.4 has a revision number of 3 and 4 for its first and second level revision number. Its third and fourth level revision number are both 0.

 

                Example 1:

                Input: version1 = "0.1", version2 = "1.1"
                Output: -1
                Example 2:

                Input: version1 = "1.0.1", version2 = "1"
                Output: 1
                Example 3:

                Input: version1 = "7.5.2.4", version2 = "7.5.3"
                Output: -1
                Example 4:

                Input: version1 = "1.01", version2 = "1.001"
                Output: 0
                Explanation: Ignoring leading zeroes, both “01” and “001" represent the same number “1”
                Example 5:

                Input: version1 = "1.0", version2 = "1.0.0"
                Output: 0
                Explanation: The first version number does not have a third level revision number, which means its third level revision number is default to "0"
 

                Note:

                Version strings are composed of numeric strings separated by dots . and this numeric strings may have leading zeroes.
                Version strings do not start or end with dots, and they will not be two consecutive dots.
            
                Time Complexity      : O(N+M)                
                Space Complexity     : O(N+M)
            */

            StringBuilder result = new StringBuilder();
            List<AddBinaryInputs> inputs = new List<AddBinaryInputs>();
            inputs.Add(new AddBinaryInputs() { inputA = "0.1", inputB = "1.1" });
            inputs.Add(new AddBinaryInputs() { inputA = "1.0.1", inputB = "1" });
            inputs.Add(new AddBinaryInputs() { inputA = "7.5.2.4", inputB = "7.5.3" });
            inputs.Add(new AddBinaryInputs() { inputA = "1.01", inputB = "1.001" });
            inputs.Add(new AddBinaryInputs() { inputA = "1.0", inputB = "1.0.0" });
            inputs.Add(new AddBinaryInputs() { inputA = "01", inputB = "1" });
            inputs.Add(new AddBinaryInputs() { inputA = "1.1", inputB = "1.10" });
            inputs.Add(new AddBinaryInputs() { inputA = "1", inputB = "01" });
            inputs.Add(new AddBinaryInputs() { inputA = "1.2", inputB = "1.10" });
            inputs.Add(new AddBinaryInputs() { inputA = "1", inputB = "01" });
            inputs.Add(new AddBinaryInputs() { inputA = "1.10", inputB = "1.2" });


            foreach (AddBinaryInputs input in inputs)
            {
                result.AppendLine($"Compare Version Numbers is { CompareVersion(input.inputA, input.inputB) }  for the given version 1: {input.inputA} and version 2 : {input.inputB}");
            }

            MessageBox.Show(result.ToString());

        }

        public int CompareVersion(string version1, string version2)
        {
            if (string.IsNullOrEmpty(version1) || string.IsNullOrEmpty(version2))
                return -1;

            string[] v1 = version1.Split('.');
            string[] v2 = version2.Split('.');

            int i = 0;
            int len = Math.Max(v1.Length, v2.Length);
            int result = 0;

            while (i < len)
            {
                result = GetResult(i < v1.Length ? int.Parse(v1[i]) : 0, i < v2.Length ? int.Parse(v2[i]) : 0);
                if (result < 0 || result > 0)
                {
                    break;
                }
                i++;
            }



            return result;
        }

        private int GetResult(int version1, int version2)
        {
            int result = 0;
            if (version1 > version2)
                result = 1;
            else if (version1 < version2)
                result = -1;

            return result;
        }

        private void btn_Bulls_and_Cows_Click(object sender, EventArgs e)
        {
            
            /*
             
                You are playing the following Bulls and Cows game with your friend: You write down a number and ask your friend to guess what the number is. Each time your friend makes a guess, you provide a hint that indicates how many digits in said guess match your secret number exactly in both digit and position (called "bulls") and how many digits match the secret number but locate in the wrong position (called "cows"). Your friend will use successive guesses and hints to eventually derive the secret number.

                Write a function to return a hint according to the secret number and friend's guess, use A to indicate the bulls and B to indicate the cows. 

                Please note that both secret number and friend's guess may contain duplicate digits.

                Example 1:

                Input: secret = "1807", guess = "7810"

                Output: "1A3B"

                Explanation: 1 bull and 3 cows. The bull is 8, the cows are 0, 1 and 7.
                Example 2:

                Input: secret = "1123", guess = "0111"

                Output: "1A1B"

                Explanation: The 1st 1 in friend's guess is a bull, the 2nd or 3rd 1 is a cow.

                Time Complexity     : O(N)
                Space Complexity    : O(10)  which is O(1)

            */


            StringBuilder result = new StringBuilder();
            List<AddBinaryInputs> inputs = new List<AddBinaryInputs>();
            inputs.Add(new AddBinaryInputs() { inputA = "1807", inputB = "7810" });
            inputs.Add(new AddBinaryInputs() { inputA = "1123", inputB = "0111" });

            foreach (AddBinaryInputs input in inputs)
            {
                result.AppendLine($"Bulls and Cows are { GetHint(input.inputA, input.inputB) }  for the given secret : {input.inputA} and guess : {input.inputB}");
            }

            MessageBox.Show(result.ToString());

        }


        public string GetHint(string secret, string guess)
        {
            
            string result = string.Empty;
            int cow = 0;
            int bull = 0;

            int[] dict = new int[10];
            int c = 0;
            int b = 0;
            for (int i = 0; i < secret.Length; i++)
            {
                b = secret[i] - '0';
                c = guess[i] - '0';

                if (b == c)
                    bull++;
                else
                {
                    if (dict[b]++ < 0)
                        cow++;
                    if (dict[c]-- > 0)
                        cow++;
                }
            }

            return $"{bull}A{cow}B";
        }

        private void btn_Find_the_Difference_Click(object sender, EventArgs e)
        {
          


            /*
            
                Given two strings s and t which consist of only lowercase letters.

                String t is generated by random shuffling string s and then add one more letter at a random position.

                Find the letter that was added in t.

                Example:

                Input:
                s = "abcd"
                t = "abcde"

                Output:
                e

                Explanation:
                'e' is the letter that was added.

                Time Complexity     : O(N+M)
                Space Complexity    : O(1)
             
             */

            StringBuilder result = new StringBuilder();
            List<AddBinaryInputs> inputs = new List<AddBinaryInputs>();
            inputs.Add(new AddBinaryInputs() { inputA = "abcd", inputB = "abcde" });
            inputs.Add(new AddBinaryInputs() { inputA = "", inputB = "a" });
            inputs.Add(new AddBinaryInputs() { inputA = "a", inputB = "" });

            foreach (AddBinaryInputs input in inputs)
            {
                result.AppendLine($"Difference for the given string 1 : {input.inputA} and string 2 : {input.inputB} is  { FindTheDifference(input.inputA, input.inputB) }");
            }

            MessageBox.Show(result.ToString());

        }

        public char FindTheDifference(string s, string t)
        {

            int result = 0;

            foreach (char c in t)
                result += c;

            foreach (char c in s)
                result -= c;

            return (char)Math.Abs(result);
        }

        private void btn_Word_Break_Click(object sender, EventArgs e)
        {        
            /*
                Given a non-empty string s and a dictionary wordDict containing a list of non-empty words, determine if s can be segmented into a space-separated sequence of one or more dictionary words.

                Note:

                The same word in the dictionary may be reused multiple times in the segmentation.
                You may assume the dictionary does not contain duplicate words.
                Example 1:

                Input: s = "leetcode", wordDict = ["leet", "code"]
                Output: true
                Explanation: Return true because "leetcode" can be segmented as "leet code".
                Example 2:

                Input: s = "applepenapple", wordDict = ["apple", "pen"]
                Output: true
                Explanation: Return true because "applepenapple" can be segmented as "apple pen apple".
                             Note that you are allowed to reuse a dictionary word.
                Example 3:

                Input: s = "catsandog", wordDict = ["cats", "dog", "sand", "and", "cat"]
                Output: false 

                Time Complexity     : O(N)
                Space Complexity    : O(N)

             */

            StringBuilder result = new StringBuilder();
            List<WorkBreak> inputs = new List<WorkBreak>();
            //inputs.Add(new WorkBreak() { input = "leetcode", Dictionary = new List<string>() { "leet", "code" } });
            //inputs.Add(new WorkBreak() { input = "applepenapple", Dictionary = new List<string>() { "apple", "pen" } });
            //inputs.Add(new WorkBreak() { input = "catsandog", Dictionary = new List<string>() { "cats", "dog", "sand", "and", "cat" } });
            //inputs.Add(new WorkBreak() { input = "aaaaaaa", Dictionary = new List<string>() { "aaaa", "aaa" } });
            inputs.Add(new WorkBreak() { input = "goalspecial", Dictionary = new List<string>() { "go", "goal", "goals", "special" } });

            foreach (WorkBreak input in inputs)
            {
                Dictionary<string, bool> dict = new Dictionary<string, bool>();
                //result.AppendLine($"Word Break is {(this.WordBreak_Working(input.input, input.Dictionary, dict) ? "": " not ")} possible for the given string {input.input} and for the dictionary {string.Join(",", input.Dictionary)}");
                result.AppendLine($"Word Break is {(this.WordBreak(input.input, input.Dictionary) ? "" : " not ")} possible for the given string {input.input} and for the dictionary {string.Join(",", input.Dictionary)}");
            }


            MessageBox.Show(result.ToString());
        }


        public bool WordBreak_Working(string s, IList<string> wordDict, Dictionary<string, bool> dict)
        {
            /*            
                "catsandog"
                "sand"
                "og"
                ["cats", "dog", "sand", "and", "cat"]        
            */

            string temp = string.Empty;
            if (wordDict.Contains(s))
                return true;

            if (dict.ContainsKey(s))
                return dict[s];

            for (int i = 1; i <= s.Length; i++)
            {
                temp = s.Substring(0, i);
                if (wordDict.Contains(temp) && WordBreak_Working(s.Substring(i), wordDict, dict))
                {
                    dict[s] = true;
                    return true;
                }
            }

            dict[s] = false;
            return false;

        }

        public bool WordBreak(string s, IList<string> wordDict)
        {

            int left = 0;
            int right = 1;
            bool result = false;
            string temp = string.Empty;
            Dictionary<string, bool> dict = new Dictionary<string, bool>();

            /*

                "aaaaaaa"  //7
                ["aaaa","aaa"]

            */


            int i = 0;
            int j = 0;
            
            for (; i < s.Length; i++)
            {
                dict.TryGetValue(s.Substring(i), out result);

                if (wordDict.Contains(s.Substring(i)) || result)
                {
                    result = true;
                    i += s.Substring(i).Length - 1;
                    continue;
                }

                for( j = 1; j <= s.Length - i; j++)
                {
                    temp = s.Substring(i, j);

                    dict.TryGetValue(temp, out result);

                    if (result || wordDict.Contains(temp))
                    {

                        result = true;                       
                        dict[temp] = true;
                        j--;
                        break;
                    }
                    else
                        result = false;
                }

                if ((i + j) == s.Length-1)
                    break;                
                i += j;
            }

            return result;
        }

        private void btn_Buddy_Strings_Click(object sender, EventArgs e)
        {


            

            /*
                Given two strings A and B of lowercase letters, return true if you can swap two letters in A so the result is equal to B, otherwise, return false.

                Swapping letters is defined as taking two indices i and j (0-indexed) such that i != j and swapping the characters at A[i] and A[j]. For example, swapping at indices 0 and 2 in "abcd" results in "cbad".

                Example 1:

                Input: A = "ab", B = "ba"
                Output: true
                Explanation: You can swap A[0] = 'a' and A[1] = 'b' to get "ba", which is equal to B.
                Example 2:

                Input: A = "ab", B = "ab"
                Output: false
                Explanation: The only letters you can swap are A[0] = 'a' and A[1] = 'b', which results in "ba" != B.
                Example 3:

                Input: A = "aa", B = "aa"
                Output: true
                Explanation: You can swap A[0] = 'a' and A[1] = 'a' to get "aa", which is equal to B.
                Example 4:

                Input: A = "aaaaaaabc", B = "aaaaaaacb"
                Output: true
                Example 5:

                Input: A = "", B = "aa"
                Output: false
 

                Constraints:

                0 <= A.length <= 20000
                0 <= B.length <= 20000
                A and B consist of lowercase letters


                Time Complexity     : O(NM)
                Space Complexity    : O(NM)

             */



            StringBuilder result = new StringBuilder();
            List<AddBinaryInputs> inputs = new List<AddBinaryInputs>();
            inputs.Add(new AddBinaryInputs() { inputA = "ab", inputB = "ba" });
            inputs.Add(new AddBinaryInputs() { inputA = "ab", inputB = "ab" });
            inputs.Add(new AddBinaryInputs() { inputA = "aa", inputB = "aa" });
            inputs.Add(new AddBinaryInputs() { inputA = "aaaaaaabc", inputB = "aaaaaaacb" });
            inputs.Add(new AddBinaryInputs() { inputA = "", inputB = "aa" });
            inputs.Add(new AddBinaryInputs() { inputA = "abcd", inputB = "badc" });

            foreach (AddBinaryInputs input in inputs)
            {
                result.AppendLine($"Buddy Strings for the given string 1 : {input.inputA} and string 2 : {input.inputB} is  { BuddyStrings(input.inputA, input.inputB) }");
            }

            MessageBox.Show(result.ToString());
        }


        public bool BuddyStrings(string A, string B)
        {
            if (string.IsNullOrEmpty(A) || string.IsNullOrEmpty(B) || A.Length != B.Length)
                return false;

            HashSet<int> dict = new HashSet<int>();
            List<int> indexes = new List<int>();

            if (A.CompareTo(B) == 0)
            {
                foreach (char c in A)
                {
                    if (dict.Contains(c))
                        return true;
                    dict.Add(c);
                }
                return false;
            }


            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] != B[i])
                    indexes.Add(i);

            }

            return (indexes.Count == 2 && A[indexes[0]] == B[indexes[1]] && A[indexes[1]] == B[indexes[0]]);

        }

        private void btn_Remove_Duplicate_Letters_Load(object sender, EventArgs e)
        {
            /*
                Given a string s, remove duplicate letters so that every letter appears once and only once. You must make sure your result is the smallest in lexicographical order among all possible results.

                Note: This question is the same as 1081: https://leetcode.com/problems/smallest-subsequence-of-distinct-characters/

 

                Example 1:

                Input: s = "bcabc"
                Output: "abc"
                Example 2:

                Input: s = "cbacdcbc"
                Output: "acdb"
 

                Constraints:

                1 <= s.length <= 104
                s consists of lowercase English letters.
                   Hide Hint #1  
                Greedily try to add one missing character. How to check if adding some character will not cause problems ? Use bit-masks to check whether you will be able to complete the sub-sequence
                if you add the character at some index i.

                Time Complexity     : O(N)
                Space Complexity    : O(26)
             */

            StringBuilder result = new StringBuilder();
            List<string> inputs = new List<string>();
            inputs.Add("bcabc");
            //inputs.Add("cbacdcbc");            

            foreach (string input in inputs)
            {
                result.AppendLine($"Removed duplicate letters is {this.RemoveDuplicateLetters(input)} for the given string is {input}");
            }

            MessageBox.Show(result.ToString());
        }

        public string RemoveDuplicateLetters(string s)
        {
            if (s == null || s.Length == 0)
                return s;

            StringBuilder result = new StringBuilder();
            int[] charlastIndex = new int[26];
            HashSet<char> dict = new HashSet<char>();
            Stack<char> chars = new Stack<char>();
            char c = '\0';

            for (int i = 0; i < s.Length; i++)
                charlastIndex[s[i] - 'a'] = i;

            for (int i = 0; i < s.Length; i++)
            {
                c = s[i];

                if (dict.Contains(c))
                    continue;

                while (chars.Count > 0 && chars.Peek() > c && i < charlastIndex[chars.Peek() - 'a'])
                {
                    dict.Remove(chars.Pop());                    
                    
                }

                chars.Push(c);
                dict.Add(c); //acdb

            }

            while (chars.Count > 0)
                result.Insert(0, chars.Pop());

            return result.ToString();
        }

        private void btn_Consecutive_Characters_Click(object sender, EventArgs e)
        {
            /*
             
            Consecutive Characters

            Solution
            Given a string s, the power of the string is the maximum length of a non-empty substring that contains only one unique character.

            Return the power of the string.

 

            Example 1:

            Input: s = "leetcode"
            Output: 2
            Explanation: The substring "ee" is of length 2 with the character 'e' only.
            Example 2:

            Input: s = "abbcccddddeeeeedcba"
            Output: 5
            Explanation: The substring "eeeee" is of length 5 with the character 'e' only.
            Example 3:

            Input: s = "triplepillooooow"
            Output: 5
            Example 4:

            Input: s = "hooraaaaaaaaaaay"
            Output: 11
            Example 5:

            Input: s = "tourist"
            Output: 1
 

            Constraints:

            1 <= s.length <= 500
            s contains only lowercase English letters.
               Hide Hint #1  
            Keep an array power where power[i] is the maximum power of the i-th character.
               Hide Hint #2  
            The answer is max(power[i]).

            Time Complexity     : O(N)
            Space Complexity    : O(1)
             
             */

            StringBuilder result = new StringBuilder();
            List<string> inputs = new List<string>();
            inputs.Add("leetcode");
            inputs.Add("abbcccddddeeeeedcba");
            inputs.Add("triplepillooooow");
            inputs.Add("hooraaaaaaaaaaay");
            inputs.Add("tourist");

            foreach (string input in inputs)
            {
                result.AppendLine($"Consecutive Characters {MaxPower(input)} for the given input string {input}");
            }

            MessageBox.Show(result.ToString());

        }


        public int MaxPower(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            int prev = 0;
            int curr = 1;
            char prevChar = s[0];

            for (int i = 1; i < s.Length; i++)
            {
                if (prevChar == s[i])
                    curr++;
                else
                {
                    prev = Math.Max(curr, prev);
                    curr = 1;
                    prevChar = s[i];

                }
            }

            return curr > prev ? curr : prev;
        }

        private void btn_Decode_String_Click(object sender, EventArgs e)
        {
            /*
            
                Given an encoded string, return its decoded string.

                The encoding rule is: k[encoded_string], where the encoded_string inside the square brackets is being repeated exactly k times. Note that k is guaranteed to be a positive integer.

                You may assume that the input string is always valid; No extra white spaces, square brackets are well-formed, etc.

                Furthermore, you may assume that the original data does not contain any digits and that digits are only for those repeat numbers, k. For example, there won't be input like 3a or 2[4].

 

                Example 1:

                Input: s = "3[a]2[bc]"
                Output: "aaabcbc"
                Example 2:

                Input: s = "3[a2[c]]"
                Output: "accaccacc"
                Example 3:

                Input: s = "2[abc]3[cd]ef"
                Output: "abcabccdcdcdef"
                Example 4:

                Input: s = "abc3[cd]xyz"
                Output: "abccdcdcdxyz"
 

                Constraints:

                1 <= s.length <= 30
                s consists of lowercase English letters, digits, and square brackets '[]'.
                s is guaranteed to be a valid input.
                All the integers in s are in the range [1, 300].
             
                Time Complexity     : O(N)
                Space Complexity    : O(N)
             
             
             
             */


            StringBuilder result = new StringBuilder();
            List<string> inputs = new List<string>();
            inputs.Add("3[a]2[bc]");
            inputs.Add("3[a2[c]]");
            inputs.Add("2[abc]3[cd]ef");
            inputs.Add("abc3[cd]xyz");
            inputs.Add("3[z]2[2[y]pq4[2[jk]e1[f]]]ef");

            foreach (string input in inputs)
            {
                result.AppendLine($"For the given string : { input } decoded string is {Environment.NewLine}{DecodeString(input)} {Environment.NewLine}{DecodeString_WithOneStack(input)} ");
            }

            MessageBox.Show(result.ToString());
        }

        public string DecodeString_WithOneStack(string s)
        {
            int N = s.Length;
            int cur = 0;
            Stack<char> st = new Stack<char>();

            while (cur < N)
            {
                char c = s[cur++];

                if (']' == c)
                {
                    string repeat = "";
                    int repeat_num = 0;
                    string dec = "";

                    while ('[' != st.Peek())
                        repeat = st.Pop() + repeat;

                    st.Pop();

                    int i = 1;
                    while (st.Count > 0 && char.IsNumber(st.Peek()))
                    {
                        repeat_num = repeat_num + (int)(st.Pop() - '0') * i;
                        i = i * 10;
                    }

                    dec = String.Concat(Enumerable.Repeat(repeat, repeat_num));
                    foreach (char r in dec) st.Push(r);

                }
                else
                {
                    st.Push(c);
                }
            }

            char[] ans = st.ToArray();
            Array.Reverse(ans);

            return new string(ans);
        }


        public string DecodeString(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return s;

            Stack<int> r = new Stack<int>();
            Stack<string> str = new Stack<string>();

            string result = string.Empty;
            StringBuilder temp = new StringBuilder();

            int i = 0;
            int ival = 0;

            while (i < s.Length)
            {
                if (char.IsNumber(s[i]))
                {
                    ival = s[i] - '0';
                    i++;

                    while (char.IsNumber(s[i]))
                    {
                        ival = (ival * 10) + (s[i] - '0');
                        i++;
                    }
                    r.Push(ival);
                }
                else if (s[i] == '[')
                {
                    str.Push(result);
                    i++;
                    result = string.Empty;
                }
                else if (s[i] == ']')
                {
                    temp.Clear();
                    temp.Append(str.Pop());
                    temp.Append(String.Concat(Enumerable.Repeat(result, r.Pop())));
                    result = temp.ToString();
                    i++;
                }
                else
                {
                    result += s[i];
                    i++;
                }


            }

            return result;



        }

        private void btn_Unique_Morse_Code_Words_Click(object sender, EventArgs e)
        {
            /*
                International Morse Code defines a standard encoding where each letter is mapped to a series of dots and dashes, as follows: "a" maps to ".-", "b" maps to "-...", "c" maps to "-.-.", and so on.

                For convenience, the full table for the 26 letters of the English alphabet is given below:

                [".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."]
                Now, given a list of words, each word can be written as a concatenation of the Morse code of each letter. For example, "cab" can be written as "-.-..--...", (which is the concatenation "-.-." + ".-" + "-..."). We'll call such a concatenation, the transformation of a word.

                Return the number of different transformations among all words we have.

                Example:
                Input: words = ["gin", "zen", "gig", "msg"]
                Output: 2
                Explanation: 
                The transformation of each word is:
                "gin" -> "--...-."
                "zen" -> "--...-."
                "gig" -> "--...--."
                "msg" -> "--...--."

                There are 2 different transformations, "--...-." and "--...--.".
                Note:

                The length of words will be at most 100.
                Each words[i] will have length in range [1, 12].
                words[i] will only consist of lowercase letters.
                
                Time Complexity     : O(N * L) N is the number of words and L is the length of the words.
                Space Complexity    : O(N * L)
             */

            StringBuilder result = new StringBuilder();
            List<string[]> inputs = new List<string[]>();
            inputs.Add(new string[] { "gin", "zen", "gig", "msg" });
            

            foreach (string[] input in inputs)
            {
                result.AppendLine($"Unique Morse Code Words is {UniqueMorseRepresentations(input)} for the given string {string.Join(",", input)}");
            }

            MessageBox.Show(result.ToString());
        }

        public int UniqueMorseRepresentations(string[] words)
        {
            if (words == null || words.Length == 0)
                return 0;
            HashSet<string> result = new HashSet<string>();
            string[] dict = new string[] { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
            StringBuilder ws = new StringBuilder();


            foreach(string word in words)
            {
                ws.Clear();
                foreach (char c in word)
                {
                    ws.Append(dict[c - 'a']);
                }

                result.Add(ws.ToString());
            }



            return result.Count;

        }

        private void btn_Basic_Calculator_II_Click(object sender, EventArgs e)
        {
            /*
             

                Un completed solution and needs to be worked on
                Implement a basic calculator to evaluate a simple expression string.

                The expression string contains only non-negative integers, +, -, *, / operators and empty spaces . The integer division should truncate toward zero.

                Example 1:

                Input: "3+2*2"
                Output: 7
                Example 2:

                Input: " 3/2 "
                Output: 1
                Example 3:

                Input: " 3+5 / 2 "
                Output: 5
                Note:

                You may assume that the given expression is always valid.
                Do not use the eval built-in library function.
             
             */


            StringBuilder result = new StringBuilder();
            List<string> inputs = new List<string>();
            //inputs.Add("3+2*2");
            //inputs.Add("3+2*2");
            //inputs.Add(" 3/2 ");
            inputs.Add(" 3+5 / 2 ");
            //inputs.Add("1");
            //inputs.Add("42");
            //inputs.Add("1337");

            foreach (string input in inputs)
            {
                result.AppendLine($"Basic calculator value for the given string {string.Join(",", input)}  is {Calculate(input)} ");
            }

            MessageBox.Show(result.ToString());

        }

        public int Calculate(String s)
        {
            if (string.IsNullOrWhiteSpace(s)) 
                return 0;
            int length = s.Length;
            int currentNumber = 0,  // 2
            lastNumber = 0,         // 3
            result = 0;             // 0
            char operation = '+';  // + 

            for (int i = 0; i < length; i++)
            {                
                char currentChar = s[i];
                if (currentChar == ' ')
                    continue;
                else if (char.IsNumber(currentChar))
                {
                    currentNumber = (currentNumber * 10) + (currentChar - '0');
                }
                if (!char.IsNumber(currentChar) && !char.IsNumber(currentChar) || i == length - 1)
                {
                    if (operation == '+' || operation == '-')
                    {
                        result += lastNumber;
                        lastNumber = (operation == '+') ? currentNumber : -currentNumber;
                    }
                    else if (operation == '*')
                    {
                        lastNumber = lastNumber * currentNumber;
                    }
                    else if (operation == '/')
                    {
                        lastNumber = lastNumber / currentNumber;
                    }
                    operation = currentChar;
                    currentNumber = 0;
                }
            }

            result += lastNumber;
            return result;
        }

        private void btn_Palindrome_Partitioning_Click(object sender, EventArgs e)
        {
            /*
                    Given a string s, partition s such that every substring of the partition is a palindrome. Return all possible palindrome partitioning of s.

                    A palindrome string is a string that reads the same backward as forward.

                    Example 1:
                    Input: s = "aab"
                    Output: [["a","a","b"],["aa","b"]]
                    
                    Example 2:
                    Input: s = "a"
                    Output: [["a"]]
 
                    Constraints:

                    1 <= s.length <= 16
                    s contains only lowercase English letters.          
            
                    Time Complexity         : O(N 2^n) exponential
                    Space Complexity        : O(N)
             
             */

            StringBuilder result = new StringBuilder();
            List<string> inputs = new List<string>();
            //inputs.Add("aab");
            //inputs.Add("a");
            inputs.Add("abbab");
            

            foreach (string input in inputs)
            {
                var res = this.Partition(input);
                result.AppendLine($"Palindrome Partitioning for the given string {string.Join(",", input)}  is ");
                foreach (var r in res)
                {
                    result.AppendLine($"{string.Join(",",r)}");
                }                                
            }

            MessageBox.Show(result.ToString());


        }


        public IList<IList<string>> Partition(string s)
        {
            if (string.IsNullOrEmpty(s))
                return new List<IList<string>>();

            List<IList<string>> result = new List<IList<string>>();
            GeneratePartition(s, new List<string>(), ref result);
            return result;


        }


        private void GeneratePartition(string s, List<string> current, ref List<IList<string>> result)
        {
            if (string.IsNullOrEmpty(s))
            {
                result.Add(new List<string>(current));
                
            }

            string left = string.Empty;
            string right = string.Empty;

            for (int i = 1; i <= s.Length; i++)
            {

                left = s.Substring(0, i);
                right = s.Substring(i);

                if (IsPalindromeForStringPartition(left))
                {
                    var copy = new List<string>(current);
                    copy.Add(left);
                    GeneratePartition(right, copy, ref result);                    
                    
                }
            }


        }



        private bool IsPalindromeForStringPartition(string s)
        {
            if (string.IsNullOrEmpty(s))
                return false;

            int i = 0;
            int j = s.Length - 1;

            while (i <= j)
            {
                if (s[i] != s[j])
                    return false;
                i++;
                j--;
            }

            return true;

        }
    }
}

        
   