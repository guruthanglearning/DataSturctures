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

            LRUCacheWithDictionaryValueAsLinkedList cache = new LRUCacheWithDictionaryValueAsLinkedList();
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

    public class DDLinkedList
    {
        public string Data;
        public DDLinkedList Next;
        public DDLinkedList Previous;
    }

    public interface ILRUCache
    {
        string Put(string data);
        string Get(string key);
    }


    public class LRUCacheWithDictionaryValueAsLinkedList: ILRUCache
    {
        Dictionary<string, DDLinkedList> cacheStorage = new Dictionary<string, DDLinkedList>();
        DDLinkedList linkList = null;
        DDLinkedList startPointLinkList = null;
     
        int size = 0;

        public string Get(string key)
        {
            if (!cacheStorage.ContainsKey(key))
            {
                throw new Exception("Invalid key");
            }

            DDLinkedList tempList = cacheStorage[key];
            tempList.Previous.Next = tempList.Next;
            tempList.Next.Previous = tempList.Previous;
            cacheStorage.Remove(key);
            linkList.Next = new DDLinkedList() { Data = key, Previous = linkList };
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
                    linkList = new DDLinkedList() { Data = data }; 
                    startPointLinkList = linkList;                 
                }
                else
                {
                    linkList.Next = new DDLinkedList() { Data = data,Previous = linkList };
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
                    linkList.Next = new DDLinkedList() { Data = data, Previous = linkList };
                    linkList = linkList.Next;
                    cacheStorage.Remove(key);
                    cacheStorage.Add(data,linkList);
                }                                                
            }            
            return data;
        }

        public string DisplayForward()
        {
            StringBuilder result = new StringBuilder();
            DDLinkedList traverse = startPointLinkList;
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
            DDLinkedList traverse = linkList;
            while (traverse != null)
            {
                result.Append($"Key = {traverse.Data} Value = {traverse.Data} \n");
                traverse = traverse.Previous;
            }
            return result.ToString();
        }
    }
}
