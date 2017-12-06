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

            int checker = 0;

            //input =  abca

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


        // Given a list of m words, I’d like to query for the nth most frequent word(s). (e.g. Given 1000 words, tell me 
       

        private void btnLongest_Substring_Without_Repeating_Characters_Click(object sender, EventArgs e)
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
            MessageBox.Show(this.lengthOfLongestSubstring("abcaa").ToString());
        }


        public int lengthOfLongestSubstring(String s)
        {
           
            int n = s.Length, ans = 0;
            int[] index = new int[128]; // current index of character
                                        // try to extend the range [i, j]
            for (int j = 0, i = 0; j < n; j++)
            {
                i = Math.Max(index[s[j]], i);
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

            string input = "AAAABBCBBBDEEEEEFFFF";
            //string input = "ABCCDEF";
            int previousCharCount = 0;
            int previousCharIndex = -1;
            int currentCharStartIndex = -1;
            var previousChar = input[0];            
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

            
            MessageBox.Show(previousCharIndex >=0 ? input[previousCharIndex].ToString() : "No character exists in continous homogenous.");

        }

    }
}