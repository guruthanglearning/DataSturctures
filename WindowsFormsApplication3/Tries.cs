using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Tries : Form
    {
        public Tries()
        {
            InitializeComponent();
        }


      
        private void btn_Implement_Trie_Prefix_Tree_Click(object sender, EventArgs e)
        {
            /*
             
                Implement a trie with insert, search, and startsWith methods.
                Example:

                Trie trie = new Trie();

                trie.insert("apple");
                trie.search("apple");   // returns true
                trie.search("app");     // returns false
                trie.startsWith("app"); // returns true
                trie.insert("app");   
                trie.search("app");     // returns true
                Note:

                You may assume that all inputs are consist of lowercase letters a-z.
                All inputs are guaranteed to be non-empty strings.
                             
             */

            Trie trie = new Trie();
            trie.Insert("apple");
            trie.Insert("app");
            bool s = trie.Search("app");
            s = trie.Search("appl");
            s = trie.Search("ap");
            s = trie.Search("pp");

            s = trie.StartsWith("ap");
            s = trie.StartsWith("aa");
            s = trie.StartsWith("pp");
        }

        private void btn_Stream_of_Characters_Click(object sender, EventArgs e)
        {
            /*

                Implement the StreamChecker class as follows:

                StreamChecker(words): Constructor, init the data structure with the given words.
                query(letter): returns true if and only if for some k >= 1, the last k characters queried (in order from oldest to newest, including this letter just queried) spell one of the words in the given list.
 

                Example:

                StreamChecker streamChecker = new StreamChecker(["cd","f","kl"]); // init the dictionary.
                streamChecker.query('a');          // return false
                streamChecker.query('b');          // return false
                streamChecker.query('c');          // return false
                streamChecker.query('d');          // return true, because 'cd' is in the wordlist
                streamChecker.query('e');          // return false
                streamChecker.query('f');          // return true, because 'f' is in the wordlist
                streamChecker.query('g');          // return false
                streamChecker.query('h');          // return false
                streamChecker.query('i');          // return false
                streamChecker.query('j');          // return false
                streamChecker.query('k');          // return false
                streamChecker.query('l');          // return true, because 'kl' is in the wordlist
 

                Note:

                1 <= words.length <= 2000
                1 <= words[i].length <= 2000
                Words will only consist of lowercase English letters.
                Queries will only consist of lowercase English letters.
                The number of queries is at most 40000.
            
                ["StreamChecker","query","query","query","query","query","query","query","query","query","query","query","query"]
[[["cd","f","kl"]],["a"],["b"],["c"],["d"],["e"],["f"],["g"],["h"],["i"],["j"],["k"],["l"]]

             */

            StringBuilder result = new StringBuilder();
            List<StreamCheckerInputs> inputs = new List<StreamCheckerInputs>();
            //inputs.Add(new StreamCheckerInputs() { words = new string[3] { "cd", "f", "kl" }, chars = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l' } });
            inputs.Add(new StreamCheckerInputs() { words = new string[5] { "ab", "ba", "aaab", "abab", "baa" }, 
                                            chars = new List<char>() { 'a', 'a', 'a', 'a', 'a', 'b', 'a', 'b', 'a', 'b', 'b', 'b', 'a', 'b', 'a', 'b', 'b', 'b', 'b', 'a', 'b', 'a', 'b', 'a', 'a', 'a', 'b', 'a', 'a', 'a' } });            
            foreach (StreamCheckerInputs input in inputs)
            {
                StreamChecker streamChecker = new StreamChecker(input.words);
                result.AppendLine($"Inputs - Words : {string.Join(",", input.words)} Query {string.Join(",", input.chars)}  ");
                foreach(char c in input.chars)
                    result.AppendLine($"{c} - {streamChecker.Query(c)}");
            }

            MessageBox.Show(result.ToString());
            


        }
    }


    public class StreamCheckerInputs
    {
        public string[] words;
        public List<char> chars;
    }

    public class StreamChecker
    {

        Trie trie = new Trie();
        StringBuilder query = new StringBuilder();
        public StreamChecker(string[] words)
        {
            trie = new Trie();
            foreach (string word in words)
                Insert(word);
        }

        public bool Query(char letter)
        {
            query.Insert(0, letter);
            string word = query.ToString();
            Trie[] temp = trie.Node;
            int c = 0;
            bool result = false;

            for (int i = 0; i < word.Length; i++)
            {
                c = word[i] - 'a';
                if (temp[c] != null)
                {
                    if (temp[c].IsLastWord)
                    {
                        result = true;
                        break;
                    }
                    temp = temp[c].Node;

                }
                else
                    break;

            }

            return result;
        }


        private void Insert(string word)
        {
            Trie[] temp = trie.Node;
            int c = 0;
            for (int i = word.Length - 1; i >= 0; i--)
            {
                c = word[i] - 'a';
                if (temp[c] == null)
                {
                    temp[c] = new Trie();
                }

                if (word.Length == word.Length - i)
                    temp[c].IsLastWord = true;
                else
                    temp = temp[c].Node;
            }
        }
    }



    public class Trie
    {

        public Trie[] Node;
        public bool IsLastWord;
        /** Initialize your data structure here. */
        public Trie()
        {
            Node = new Trie[26];           
        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {

          
            if (string.IsNullOrEmpty(word))
                return;

            int index = 0;

            Trie[]temp = Node;
            for(int i = 0; i < word.Length; i++)
            {
                index = word[i] - 'a';
                if (temp[index] == null)
                {
                    temp[index] = new Trie();                            
                }
                if (i == word.Length - 1)
                    temp[index].IsLastWord = true;
                else
                    temp = temp[index].Node;
            }
            
            
        }

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            
            if (string.IsNullOrEmpty(word) || Node == null)
                return false;

            Trie temp = this.Find(word);

            return  (temp!= null && temp.IsLastWord);
        }


        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            if (string.IsNullOrEmpty(prefix) || Node == null)
                return false;

            Trie temp = this.Find(prefix);

            return (temp != null);
        }

        private Trie Find(string word)
        {
            if (string.IsNullOrEmpty(word) || Node == null)
                return null;

            Trie temp = this;
            int index = 0;

            for (int i = 0; i < word.Length; i++)
            {
                index = word[i] - 'a';
                if (temp.Node[index] != null)
                    temp = temp.Node[index];
                else
                {
                    temp = null;
                    break;
                }
            }
            return temp;
        }


    }
}
