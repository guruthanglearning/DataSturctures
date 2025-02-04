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

            LRUCacheWithDictionaryValueAsLinkedList c = new LRUCacheWithDictionaryValueAsLinkedList(3);

            c.Put("1", "1");
            c.Put("2", "2");
            c.Put("3", "3");
            c.Get("2");


            MessageBox.Show($"Foward list \n{c.DisplayForward()}\n\nBackward list \n{c.DisplayBackward()}");


            /*c.Put("10", "13");
            c.Put("3", "17");
            c.Put("6", "11");
            c.Put("10", "5");
            c.Put("9", "10");
            c.Get("13");
            c.Put("2", "19");
            c.Get("2");
            c.Get("3");
            c.Put("5", "25");
            c.Get("8");
            c.Put("9", "22");
            c.Put("5", "5");
            c.Put("1", "30");
            c.Get("11");
            c.Put("9", "12");
            c.Get("7");
            c.Get("5");
            c.Get("8");
            c.Get("9");
            c.Put("4", "30");
            c.Put("9", "3");
            c.Get("9");
            c.Get("10");
            c.Get("10");
            c.Put("6", "14");
            c.Put("3", "1");
            c.Get("3");
            c.Put("10", "11");
            c.Get("8");
            c.Put("2", "14");
            c.Get("1");
            c.Get("5");
            c.Get("4");
            c.Put("11", "4");
            c.Put("12", "24");
            c.Put("5", "18");
            c.Get("13");
            c.Put("7", "23");
            c.Get("8");
            c.Get("12");
            c.Put("3", "27");
            c.Put("2", "12");
            c.Get("5");
            c.Put("2", "9");
            c.Put("13", "4");
            c.Put("8", "18");
            c.Put("1", "7");
            c.Get("6");
            c.Put("9", "29");
            c.Put("8", "21");
            c.Get("5");
            c.Put("6", "30");
            c.Put("1", "12");
            c.Get("10");
            c.Put("4", "15");
            c.Put("7", "22");
            c.Put("11", "26");
            c.Put("8", "17");
            c.Put("9", "29");
            c.Get("5");
            c.Put("3", "4");
            c.Put("11", "30");
            c.Get("12");
            c.Put("4", "29");
            c.Get("3");
            c.Get("9");
            c.Get("6");
            c.Put("3", "4");
            c.Get("1");
            c.Get("10");
            c.Put("3", "29");
            c.Put("10", "28");
            c.Put("1", "20");
            c.Put("11", "13");
            c.Get("3");
            c.Put("3", "12");
            c.Put("3", "8");
            c.Put("10", "9");
            c.Put("3", "26");
            c.Get("8");
            c.Get("7");
            c.Get("5");
            c.Put("13", "17");
            c.Put("2", "27");
            c.Put("11", "15");
            c.Get("12");
            c.Put("9", "19");
            c.Put("2", "15");
            c.Put("3", "16");
            c.Get("1");
            c.Put("12", "17");
            c.Put("9", "1");
            c.Put("6", "19");
            c.Get("4");
            c.Get("5");
            c.Get("5");
            c.Put("8", "1");
            c.Put("11", "7");
            c.Put("5", "2");
            c.Put("9", "28");
            c.Get("1");
            c.Put("2", "2");
            c.Put("7", "4");
            c.Put("4", "22");
            c.Put("7", "24");
            c.Put("9", "26");
            c.Put("13", "28");
            c.Put("11", "26");
            */


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
        public string Key;
        public DDLinkedList Next;
        public DDLinkedList Previous;
    }

    public interface ICache
    {
        void Put(string dataKey, string data);
        string Get(string key);
    }

    public class LRUCacheWithDictionaryValueAsLinkedList: ICache
    {
        Dictionary<string, DDLinkedList> cacheStorage = new Dictionary<string, DDLinkedList>();
        DDLinkedList runner = null;
        DDLinkedList start = null;
        int capacity = 0;        

        DDLinkedList temp = null;

        public LRUCacheWithDictionaryValueAsLinkedList(int capacity)
        {
            this.capacity = capacity;
        }


        public string Get(string key)
        {
            temp = null;
            cacheStorage.TryGetValue(key, out temp);

            if (temp == null)
            {
                return "-1";
            }


            if (start.Next == null)
            {
                return start.Data;
            }
            else if (temp.Next == null)
            {
                return temp.Data;
            }
            else if (temp.Key == start.Key) // if data is in start location;
            {
                start = start.Next;
                start.Previous = null;
                //temp.Previous = new DDLinkedList();
            }
            else if (temp.Next != null) //
            {
                temp.Previous.Next = temp.Next;
                temp.Next.Previous = temp.Previous;
            }

            temp.Next = null;
            temp.Previous = runner;
            runner.Next = temp;
            runner = runner.Next;
            return temp.Data;

        }

        public void Put(string key, string value)
        {

            temp = null;
            cacheStorage.TryGetValue(key, out temp);
            if (temp != null)
            {
                Get(key);
                temp.Data = value;
            }
            else
            {
                if (cacheStorage.Count == capacity)
                {
                    cacheStorage.Remove(start.Key);
                    if (start.Next == null)
                    {
                        start.Data = value;
                        start.Key = value;
                        runner = start;
                    }
                    else
                    {
                        start = start.Next;
                        start.Previous = null;
                        runner.Next = new DDLinkedList() { Key = key, Data = value, Previous = runner };
                        runner = runner.Next;
                    }
                }
                else
                {
                    if (start == null)
                    {
                        start = new DDLinkedList() { Key = key, Data = value };
                        runner = start;
                    }
                    else
                    {
                        runner.Next = new DDLinkedList() { Key = key, Data = value, Previous = runner };
                        runner = runner.Next;
                    }
                }
                cacheStorage[key] = runner;
            }

        }

        public string DisplayForward()
        {
            StringBuilder result = new StringBuilder();
            DDLinkedList traverse = start;
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
            /*
                1,2,3,4,5, 6
            
                C : 2,3,4,5,6
                F : 4[1],5[1],6[1],2[2],3[2]
                FD: 1[4,5,6]
                    2[2,3]

                Get 2 -                
            */
        }

        public void Put(string dataKey, string data)
        {
            if (Cache.ContainsKey(dataKey))
            {
                return; //this.Get(dataKey);
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

        public void Put(string dataKey, string data)
        {
            
            

            
        }

        public string Get(string key)
        {
            return string.Empty;
        }
    }
}
