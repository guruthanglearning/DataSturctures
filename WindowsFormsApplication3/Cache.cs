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
    public partial class Cache : Form
    {
        public Cache()
        {
            InitializeComponent();
        }

       
        private void btn_ImplementCache_from_Amazon_Implemented_Dictionary_having_value_as_LinkedList_Click(object sender, EventArgs e)
        {
            /*
                Time Complexity for adding an item to cache is O(1)
                Time Complexity for getting an item from cache is O(1)
            */

            AmazonCacheWithDictionaryValueAsLinkedList cache = new AmazonCacheWithDictionaryValueAsLinkedList();
            cache.Put("A");
            cache.Put("B");
            cache.Put("C");
            cache.Get("B");
            cache.Put("D");
            cache.Put("E");
            cache.Put("F");
            cache.Put("G");
            cache.Put("H");
            cache.Put("I");
            cache.Put("J");
            cache.Put("K");
            MessageBox.Show($"Foward list \n{cache.DisplayForward()}\n\nBackward list \n{cache.DisplayBackward()}");


        }
    }

    public class LinkedList
    {
        public string Data;
        public LinkedList Next;
        public LinkedList Previous;
    }

    public interface IAmazonCache
    {
        string Put(string data);
        string Get(string key);
    }


    public class AmazonCacheWithDictionaryValueAsLinkedList: IAmazonCache
    {
        Dictionary<string, LinkedList> cacheStorage = new Dictionary<string, LinkedList>();
        LinkedList linkList = null;
        LinkedList startPointLinkList = null;
     
        int size = 0;

        public string Get(string key)
        {
            if (!cacheStorage.ContainsKey(key))
            {
                throw new Exception("Invalid key");
            }

            LinkedList tempList = cacheStorage[key];
            tempList.Previous.Next = tempList.Next;
            tempList.Next.Previous = tempList.Previous;
            cacheStorage.Remove(key);
            linkList.Next = new LinkedList() { Data = key, Previous = linkList };
            linkList = linkList.Next;
            cacheStorage.Add(key, linkList);
            return key;
        }

        public string Put(string data)
        {

            if (string.IsNullOrWhiteSpace(data))
            {
                throw new Exception("Invalid Input");
            }

            if (size < 10 )
            {                
                if (linkList == null)
                {
                    linkList = new LinkedList() { Data = data }; 
                    startPointLinkList = linkList;                 
                }
                else
                {
                    linkList.Next = new LinkedList() { Data = data,Previous = linkList };
                    linkList = linkList.Next;
                }                
                cacheStorage.Add(data, linkList);
                size++;                
            }
            else
            {
                string key = startPointLinkList.Data;
                if (cacheStorage.ContainsKey(key))
                {                   
                    startPointLinkList = startPointLinkList.Next;
                    startPointLinkList.Previous = null;
                    linkList.Next = new LinkedList() { Data = data, Previous = linkList };
                    linkList = linkList.Next;
                    cacheStorage[key] = linkList;
                }                                                
            }            
            return data;
        }

        public string DisplayForward()
        {
            StringBuilder result = new StringBuilder();
            LinkedList traverse = startPointLinkList;
            while (traverse != null)
            {
                result.Append($"Key = {traverse.Data} Value = {traverse.Data} \n");
                traverse = traverse.Next;
            }
            return result.ToString();
        }


        public string DisplayBackward()
        {
            StringBuilder result = new StringBuilder();
            LinkedList traverse = linkList;
            while (traverse != null)
            {
                result.Append($"Key = {traverse.Data} Value = {traverse.Data} \n");
                traverse = traverse.Previous;
            }
            return result.ToString();
        }
    }
}
