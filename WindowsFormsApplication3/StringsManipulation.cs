using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace WindowsFormsApplication3
{
    public partial class StringsManipulation : Form
    {
        private int elementLevel = -1;
        private int numberOfElements;
        private int[] permutationValue = new int[0];
        private static int atoz = 126;
        private int counter = 0;

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
            for (int i = 1; i <= input; i++)
            {
                if (i == 1)
                {
                    current = 1;
                }
                else
                {
                    if (current < 0)
                    {
                        current *= -1;
                    }

                    // current = 1, previous = 1, temp =1
                    temp = previous;
                    previous = current;
                    current = current + temp;
                    if (isNegativeInput)
                    {
                        if (i % 2 == 0)
                        {
                            current *= -1;
                        }
                    }
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

            string input = "pineapplepenapple";
            List<string> dictionary = new List<string>() { "apple", "pen", "applepen", "pine", "pineapple" };
            /*
              Output:
                [
                  "pine apple pen apple",
                  "pineapple pen apple",
                  "pine applepen apple"
                ]             
             */

            List<string>[] pos = new List<string>[input.Length];
            pos[0] = new List<string>();
            string subString = string.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i + 1; j < input.Length; j++)
                {
                    subString = input.Substring(i, (j - i) + 1);
                    if (dictionary.Contains(subString))
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

            if (pos[input.Length - 1] == null)
            {
                MessageBox.Show($"No sentence avialable for this input {input} ");
            }
            else
            {
                List<string> result = new List<string>();
                dfs(pos, result, "", input.Length - 1);
                StringBuilder outputs = new StringBuilder();
                foreach (string str in result)
                {
                    outputs.Append(str + "\n");
                }

                MessageBox.Show($"The list of words from the given input {input} is \n {outputs.ToString()}");
            }


        }

        public void dfs(List<String>[] pos, List<String> result, String curr, int i)
        {
            if (i <= 0)
            {
                result.Add(curr.Trim());
                return;
            }

            foreach (String s in pos[i])
            {
                String combined = s + " " + curr;
                dfs(pos, result, combined, i - s.Length);
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
                    int i = input.Length - 1;

                    for (; i >= 0; i--)
                    {
                        if (input[i] == ' ')
                        {
                            break;
                        }
                    }
                    result.AppendLine($"Max length is {input.Length - (i + 1)} for the last word in this given string {s}");
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
            inputs.Add(new AddBinaryInputs() { inputA = "11", inputB = "0" });
            inputs.Add(new AddBinaryInputs() { inputA = "11" });
            inputs.Add(new AddBinaryInputs() { inputB = "11" });
            inputs.Add(new AddBinaryInputs() { });
            inputs.Add(new AddBinaryInputs() { inputA = "1111", inputB = "111" });

            StringBuilder result = new StringBuilder();

            foreach (var input in inputs)
            {
                int al = 0;
                int bl = 0;
                int sum = 0;
                int carry = 0;

                StringBuilder binarySum = new StringBuilder();

                if (string.IsNullOrEmpty(input.inputA))
                {
                    result.AppendLine($"Adding two binary {(input.inputA == null ? "A NULL" : input.inputA)} and {(input.inputB == null ? "B NULL" : input.inputB)}  is {(input.inputB == null ? "NULL" : input.inputB)}");
                    continue;
                }
                else if (string.IsNullOrEmpty(input.inputB))
                {
                    result.AppendLine($"Adding two binary {(input.inputA == null ? "A NULL" : input.inputA)} and {(input.inputB == null ? "B NULL" : input.inputB)}  is {(input.inputA == null ? "NULL" : input.inputA)}");
                    continue;
                }

                input.inputA = input.inputA.Trim();
                input.inputB = input.inputB.Trim();

                al = input.inputA.Length - 1;
                bl = input.inputB.Length - 1;

                while (al >= 0 && bl >= 0)
                {
                    sum = carry;
                    sum += (input.inputA[al] - '0');
                    sum += (input.inputB[bl] - '0');
                    carry = sum / 2;
                    binarySum.Insert(0, sum % 2);
                    al--;
                    bl--;
                }

                while (al >= 0)
                {
                    sum = carry;
                    sum += (input.inputA[al] - '0');
                    carry = sum / 2;
                    binarySum.Insert(0, sum % 2);
                    al--;
                }

                while (bl >= 0)
                {
                    sum = carry;
                    sum += (input.inputB[bl] - '0');
                    carry = sum / 2;
                    binarySum.Insert(0, sum % 2);
                    bl--;
                }

                if (carry > 0)
                {
                    binarySum.Insert(0, carry);
                }

                result.AppendLine($"Adding two binary {input.inputA} and {input.inputB}  is {binarySum.ToString()}");
            }

            MessageBox.Show(result.ToString());




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
    }
}

        
   