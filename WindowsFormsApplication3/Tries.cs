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
    }


    public class Trie
    {

        Trie[] data;        
        bool isLastWord;
        /** Initialize your data structure here. */
        public Trie()
        {
            data = new Trie[26];           
        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            if (string.IsNullOrEmpty(word))
                return;

            int index = 0;

            Trie[]temp = data;
            for(int i = 0; i < word.Length; i++)
            {
                index = word[i] - 'a';
                if (temp[index] == null)
                {
                    temp[index] = new Trie();                            
                }
                if (i == word.Length - 1)
                    temp[index].isLastWord = true;
                else
                    temp = temp[index].data;
            }
            
            
        }

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {

            if (string.IsNullOrEmpty(word) || data == null)
                return false;

            Trie temp = this.Find(word);

            return  (temp!= null && temp.isLastWord);
        }


        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            if (string.IsNullOrEmpty(prefix) || data == null)
                return false;

            Trie temp = this.Find(prefix);

            return (temp != null);
        }

        private Trie Find(string word)
        {
            if (string.IsNullOrEmpty(word) || data == null)
                return null;

            Trie temp = this;
            int index = 0;

            for (int i = 0; i < word.Length; i++)
            {
                index = word[i] - 'a';
                if (temp.data[index] != null)
                    temp = temp.data[index];
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
