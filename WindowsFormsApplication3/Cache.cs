using System;
using System.Collections;
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
                LRU -->Removes the least used item from the cache (delete from the starting of the double link list)
                MRU -->Removes the most recently used item from the cache (delete from the end of the double link list)
            */

            LRUCacheWithDictionaryValueAsLinkedList cache = new LRUCacheWithDictionaryValueAsLinkedList();
            cache.Put("A", "A");
            cache.Put("B", "B");
            cache.Put("C", "C");
            //cache.Get("B");
            cache.Put("D", "D");
            cache.Put("E", "E");
            cache.Put("F", "F");
            cache.Put("G", "G");
            cache.Put("H", "H");
            cache.Put("I", "I");
            cache.Put("J", "J");
            cache.Get("A");
            cache.Put("K","K");
            MessageBox.Show($"Foward list \n{cache.DisplayForward()}\n\nBackward list \n{cache.DisplayBackward()}");


        }

        private void btn_Implement_Least_Frequently_Used_Cache_Click(object sender, EventArgs e)
        {
            LFU_LeastFrequentlyUsedCache cache = new LFU_LeastFrequentlyUsedCache();
            cache.Put("A", "A");
            cache.Put("B", "B");
            cache.Put("C", "C");
            cache.Put("A", "A");
            //cache.Get("B");
            //cache.Get("A");
            //cache.Get("C");
            cache.Put("D", "D");
            cache.Get("D");
            cache.Put("E", "E");
            cache.Get("E");
            cache.Put("F", "F");
            cache.Get("F");
            cache.Get("E");
        }

        private void btn_Implement_LRU_using_List_Click(object sender, EventArgs e)
        {
            
        }
    }

    public class DDLinkedList
    {
        public string Data;
        public DDLinkedList Next;
        public DDLinkedList Previous;
    }

    public interface ICache
    {
        string Put(string dataKey, string data);
        string Get(string key);
    }

    public class LRUCacheWithDictionaryValueAsLinkedList: ICache
    {
        Dictionary<string, DDLinkedList> cacheStorage = new Dictionary<string, DDLinkedList>();
        DDLinkedList runner = null;
        DDLinkedList startPointLinkList = null;

        public string Get(string key)
        {
            if (!cacheStorage.ContainsKey(key))
            {
                throw new Exception("Invalid key");
            }


            DDLinkedList tempList = cacheStorage[key];
            
            if (runner.Data == tempList.Data)
            {
                //This means retriving data is present at the end of the list
                return tempList.Data;
            }
            else if (startPointLinkList.Data == tempList.Data)
            {
                //This means retriving data is present at the start of the list
                startPointLinkList = startPointLinkList.Next;
                startPointLinkList.Previous = null;
                tempList.Next = null;
                tempList.Previous = runner;
                runner.Next = tempList;
                runner = runner.Next;  
            }
            else
            { 
                tempList.Previous.Next = tempList.Next;
                tempList.Next.Previous = tempList.Previous;
                tempList.Next = null;
                tempList.Previous = runner;
                runner.Next = tempList;
                runner = runner.Next;
            }             
            return runner.Data;
        }

        public string Put(string dataKey, string data)
        {

            if (string.IsNullOrWhiteSpace(data) || string.IsNullOrWhiteSpace(dataKey))
            {
                throw new Exception("Invalid Input");
            }

            if (cacheStorage.ContainsKey(dataKey))
            {
                throw new Exception("Key already present");
            }

            if (cacheStorage.Count < 5 )
            {    
                
                if (runner == null)
                {
                    runner = new DDLinkedList() { Data = data }; 
                    startPointLinkList = runner;                 
                }
                else
                {
                    runner.Next = new DDLinkedList() { Data = data,Previous = runner };
                    runner = runner.Next;
                }                
                cacheStorage.Add(dataKey, runner);                
            }
            else
            {
                    cacheStorage.Remove(cacheStorage.First().Key);
                    startPointLinkList = startPointLinkList.Next;
                    startPointLinkList.Previous = null;
                    runner.Next = new DDLinkedList() { Data = data, Previous = runner };
                    runner = runner.Next;
                    cacheStorage[dataKey]= runner;            
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
            DDLinkedList traverse = runner;
            while (traverse != null)
            {
                result.Append($"Key = {traverse.Data} Value = {traverse.Data} \n");
                traverse = traverse.Previous;
            }
            return result.ToString();
        }
    }

    public class LFU_LeastFrequentlyUsedCache : ICache
    {

        Dictionary<string, string> Cache = new Dictionary<string, string>();
        Dictionary<string, int> Frequency = new Dictionary<string, int>();
        Dictionary<int, List<string>> FrequencyData = new Dictionary<int, List<string>>();
        int min = 0;

        public LFU_LeastFrequentlyUsedCache()
        {
            FrequencyData.Add(1, new List<string>());
        }

        public string Put(string dataKey, string data)
        {

            if (Cache.ContainsKey(dataKey))
            {            
                return this.Get(dataKey);
            }

            if (Cache.Count >= 5)
            {
                string key = FrequencyData[min].First();
                Frequency.Remove(key);
                Cache.Remove(key);
                FrequencyData[min].Remove(key);
            }

            Cache.Add(dataKey, data);
            Frequency.Add(dataKey, 1);
            FrequencyData[1].Add(dataKey);
            min = 1;
            return data;
           
        }

        public string Get(string dataKey)
        {
            if (Cache.ContainsKey(dataKey))
            {
                int countKey = Frequency[dataKey];
                Frequency[dataKey]++;
                FrequencyData[countKey].Remove(dataKey);

                if (countKey == min && FrequencyData[countKey].Count == 0)
                {
                    min++;
                }

                if (!FrequencyData.ContainsKey(countKey + 1))
                {
                    FrequencyData.Add(countKey + 1, new List<string>());
                }
                FrequencyData[countKey + 1].Add(dataKey);
                return Cache[dataKey];
            }

            throw new Exception("Invalid Key");
        }

    }


    public class LRUCacheWithDictionary : ICache
    {

        ArrayList cache = new ArrayList();

        public string Put(string dataKey, string data)
        {
            
            

            return string.Empty;
        }

        public string Get(string key)
        {
            return string.Empty;
        }
    }
}
