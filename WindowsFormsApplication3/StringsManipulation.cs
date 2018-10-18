using System;
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
                    newLength--;
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

            data.Append("\nSimple approach: \n ");
            incr = 0;
            while (incr <= maxNumbers)
            {
                incr++;
                if (incr > maxNumbers)
                {
                    break;
                }

                if (incr%10 > 0)
                {
                    data.Append(incr.ToString() + ",");
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
            StringBuilder result = new StringBuilder();
            int checker = 0;

            for (int i = 0; i < array.Length; i++)
            {
                int val = array[i];

                if ((checker & (1<<val)) > 0)
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


            // Time Complexity  : O(n)
            // Space Complexity : O(min(m,n)) where m is the input character in the dictionary and n is the total input character set
            Dictionary<char, int> index = new Dictionary<char, int>();
            for (int j = 0, i = 0; j < n; j++)
            {
                if (index.ContainsKey(s[j]))
                {
                    i = Math.Max(index[s[j]],i);
                }
                
                ans = Math.Max(ans, j - i + 1);
                index[s[j]] = j + 1;
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
            Dictionary<char, int> _romanMap = new Dictionary<char, int> { { 'I', 1 }, { 'V', 5 }, { 'X', 10 }, { 'L', 50 }, { 'C', 100 }, { 'D', 500 }, { 'M', 1000 } };
            textBox1.Text = "MMMCMXCIX";
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

        private void Query_nth_most_frequent_word_Click(object sender, EventArgs e)
        {
            string word = this.GetNthMostFrequentWord(new string[] { "A", "A", "B", "B", "B", "B", "B", "B", "B", "B", "B", "C" }, 2);


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
            string maxword = string.Empty;                        
            foreach (string word in words)
            {
                if (wordCount.ContainsKey(word))
                {
                    wordCount[word]++;                    
                }
                else
                {
                    wordCount.Add(word, 1);
                }
            }

            int max = 0;
            foreach (string key in wordCount.Keys)
            {

            }

            return string.Empty;
        }

        private void StringToInt_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            long result = 0;
            char c;
            

            for(int i = 0; i <input.Length; i++) 
            {
                c = input[i];
                if (char.IsNumber(c))
                {
                    if (result == 0)
                    {
                        result = Convert.ToInt64(c.ToString());
                    }
                    else
                    {
                        result = (result * 10) + Convert.ToInt64(c.ToString());
                    }
                }
                else
                {
                    break;
                }
            }
            MessageBox.Show(result.ToString());

        }

        private void FibonociSeries_Click(object sender, EventArgs e)
        {
            //https://en.wikipedia.org/wiki/Fibonacci_number
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
                        if (i %2 == 0)
                        {
                            current *= -1;
                        }
                    }
                }
            }
            

            MessageBox.Show($"Fibonacci Series of {textBox1.Text} : {current.ToString()}");
        }

        private int GetPalindromes(string input, int start, int end )
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
            MessageBox.Show($"Max Palondrom sequence {this.GetPalindromes(input,0, input.Length-1)}");
        }

        public int longestPalindromeSubstringEasy(string input)
        {

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

        private void Longest_Palondrome_in_a_given_string_O_Off_N_Click(object sender, EventArgs e)
        {
            //Time Complexity : O(n)
            string input = "abaab";
            MessageBox.Show(this.longestPalindromeSubstringEasy(input).ToString());
        }

        private void btn_Find_index_of_homogenous_continous_charcter_Click(object sender, EventArgs e)
        {
            // string input = "AAAABBCBBBDEEEEEFFFF";
            string input = "DBCAAB";
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
            MessageBox.Show(previousCharIndex >=0 ? $"Homogenous continous character is {input[previousCharIndex].ToString()} and count is {previousCharCount.ToString()}" : "No character exists in continous homogenous.");            
        }

        private Dictionary<char, int> GetCharIndexesInAGivenString(string input)
        {
            var result = new Dictionary<char, int>();
            for(int i = 0; i<input.Length; i++)
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
               Space Complexity is O(1)
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
               Space Complexity is O(1)
             */

            string input = "DBCAAB";
            var result = this.GetCharIndexesInAGivenString(input);
            int index = -1;
            foreach (char c in input)
            {
                if (result[c] != -1)
                {                    
                    if (index == -1 && result[c] ==0)
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

            if (input.Length <= 1 )
            {
                previousString = input;
            }
            else
            {                 
                int i;
                int pos = -1;
                for(i = 1; i<input.Length; i++)
                {
                    pos = input.IndexOf(input[i],start, (i - start));
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
           
            MessageBox.Show($"Longest Substring of an given string {input}  is {previousString}");

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
                    switch(c)
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
                for (int i = 0; i < input1.Length; i ++)
                {
                    char1 = input1[i];
                    char2 = input2[i];
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
            for(int i = 0; i<input.Length; i++)
            {
                for(int j=i+1;j<input.Length; j++)
                {
                    subString = input.Substring(i,  (j-i)+1);
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
            
            if (pos[input.Length-1] == null)
            {
                MessageBox.Show($"No sentence avialable for this input {input} ");
            }
            else
            {
                List<string> result = new List<string>();
                dfs(pos, result, "", input.Length-1);
                StringBuilder outputs = new StringBuilder();
                foreach(string str in result)
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
    }
}