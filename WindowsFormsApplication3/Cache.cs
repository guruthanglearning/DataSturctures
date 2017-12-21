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

        private void btn_Implement_Cache_From_Amazon_Click(object sender, EventArgs e)
        {
            /*
             Given an Interface below
             public interface IAmazonCache
             {
                string Put(string data);
                string Get(string key);
             }

             Implement caching 
             What data structure we would be using to implement caching efficiently
             */

            AmazonCache cache = new AmazonCache();
            cache.Put("1");
            cache.Put("2");
            cache.Put("3");
            cache.Put("4");
            cache.Put("5");
            cache.Put("6");
            cache.Get("2");
            cache.Put("7");
            cache.Put("8");
            cache.Put("9");
            cache.Put("10");
            StringBuilder message = new StringBuilder($"Before Accessing Cache \n {cache.Display()}");

            cache.Get("1");
            message.Append($"After Accessing Cache \n {cache.Display()}");

            cache.Put("11");
            message.Append($"After putting new item into Cache when cache size exceeds \n {cache.Display()}");

            MessageBox.Show(message.ToString());
        }



    }    

    public class LinkedList
    {
        public string Data;
        public LinkedList Next;
    }

    public interface IAmazonCache
    {
        string Put(string data);
        string Get(string key);
    }

    public class AmazonCache : IAmazonCache
    {
        Dictionary<string, string> cacheStorage = new Dictionary<string, string>();
        LinkedList linkedList = null;
        LinkedList linkedListStart = null;        
        int size = 0;

        public string Put(string data)
        {
            if (!cacheStorage.ContainsKey(data))
            {
                if (size < 10)
                {                    
                    if (linkedList == null)
                    {
                        linkedList = new LinkedList() { Data = data };
                        linkedListStart = linkedList;
                    }
                    else
                    {
                        linkedList.Next = new LinkedList() { Data = data };
                        linkedList= linkedList.Next;
                    }
                    cacheStorage.Add(data, data);
                    ++size;                    
                }
                else
                {
                    string removeItemKey = linkedListStart.Data;
                    if (cacheStorage.ContainsKey(removeItemKey))
                    {
                        cacheStorage.Remove(removeItemKey);
                    }
                    linkedListStart = linkedListStart.Next;
                    linkedList.Next = new LinkedList() { Data = data };
                    cacheStorage.Add(data, data);
                }                
            }
            return data; 
        }

        public string Get(string key)
        {
            string returnValue = string.Empty;
            if (cacheStorage.ContainsKey(key))
            {
                LinkedList previous = linkedListStart;
                LinkedList current = previous.Next;
                returnValue = cacheStorage[key];
                if (previous.Data == returnValue)
                {
                    previous = previous.Next;
                    linkedListStart = previous;
                    linkedList.Next = new LinkedList() { Data = returnValue };
                    linkedList = linkedList.Next;
                }
                else
                {

                    while (current != null)
                    {
                        if (current.Data == returnValue)
                        {
                            previous.Next = current.Next;
                            current = current.Next;
                            linkedList.Next = new LinkedList() { Data = returnValue };
                            linkedList = linkedList.Next;
                            break;
                        }
                    }
                }
            }
            return returnValue;
        }

        public string Display()
        {
            StringBuilder result = new StringBuilder();
            LinkedList traverse = linkedListStart;
            while (traverse!=null) 
            {               
                result.Append($"Key = {traverse.Data} Value = {traverse.Data} \n");
                traverse = traverse.Next;
            }
            return result.ToString();
        }

    }
}
