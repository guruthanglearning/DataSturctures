using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3.Other
{
    public partial class Questions : Form
    {
        public Questions()
        {
            InitializeComponent();
        }

        private void btn_Find_closest_Veg_Resturant_Click(object sender, EventArgs e)
        {
            int totalResturants = 5;
            int[,] allLocations = new int[5, 2] { { 1, 2 }, { 1, -1 }, { 3, 3 },{ 0, 0 },{ 2, 2 } };
            int numResutrants = 2;
            var result = NearestVegetarianRestaurant(3, allLocations, numResutrants);
        }


        private List<List<int>> NearestVegetarianRestaurant(int totalRestaurants,
                                                       int[,] allLocations,
                                                       int numRestaurants)
        {
            /*
             Time Complexity : 
             Inserting location and coordinates into binary tree is O(n) where n being the # of locations
             Traversing the binary tree for finding the location is O(h) where h being the height of the binary tree
             Combining would be O(n) + O(h) = O(n+h);
            */

            Node tree = null;
            int traversalInc = 0;
            if (totalRestaurants <= 0 || allLocations == null ||
                allLocations.Length == 0 || numRestaurants <= 0)
            {
                return null;
            }
            List<List<int>> results = null;
            double location = 0;

            for (int i = 0; i < totalRestaurants; i++)
            {
                location = Math.Sqrt((allLocations[i, 0] * allLocations[i, 0]) + (allLocations[i, 1] * allLocations[i, 1]));
                LocationData ld = new LocationData();
                ld.Location = location;
                ld.Cordinate = new int[1, 2];
                ld.Cordinate[0, 0] = allLocations[i, 0];
                ld.Cordinate[0, 1] = allLocations[i, 1];
                InsertNode(ref tree, ld);
            }

            if (tree != null)
            {
                InOrderTraversal(numRestaurants, ref traversalInc, tree, ref results);
            }

            if (results==null || results.Count == 0)
            {
                MessageBox.Show("No closest resturant found for the user");
            }

            StringBuilder customerClosestRestaurants = new StringBuilder();
            customerClosestRestaurants.Append("Closest resturant found for the user \n");
            foreach (var result in results)
            {
                customerClosestRestaurants.Append("Location  :");
                foreach (var cordinate in result)
                {
                    customerClosestRestaurants.Append(cordinate.ToString() + ",");
                }
                customerClosestRestaurants.Append("\n");
            }
            MessageBox.Show(customerClosestRestaurants.ToString());
            return results;

        }

        private void InsertNode(ref Node tree, LocationData locationData)
        {
            if (tree == null)
            {
                tree = new Node();
                tree.LocationData = locationData;
            }

            if (locationData.Location > tree.LocationData.Location)
            {
                InsertNode(ref tree.Right, locationData);
            }
            else if (locationData.Location < tree.LocationData.Location)
            {
                InsertNode(ref tree.Left, locationData);
            }
        }

        private void InOrderTraversal(int numRestaurants, ref int traversalCount, Node node, ref List<List<int>> result)
        {
            if (traversalCount < numRestaurants)
            {
                if (node != null)
                { 
                    InOrderTraversal(numRestaurants, ref traversalCount, node.Left, ref result);
                    traversalCount++;
                    var cordinate = new List<int>();
                    cordinate.Add(node.LocationData.Cordinate[0, 0]);
                    cordinate.Add(node.LocationData.Cordinate[0, 1]);
                    if (result == null)
                    {
                        result = new List<List<int>>();
                    }
                    result.Add(cordinate);
                    if (traversalCount < numRestaurants)
                    {
                        InOrderTraversal(numRestaurants, ref traversalCount, node.Right, ref result);
                    }
                }
            }
        }

        // METHOD SIGNATURE ENDS
        class Node
        {
            public Node Right;
            public Node Left;
            public LocationData LocationData;
        }
        class LocationData
        {
            public double Location;
            public int[,] Cordinate;
        }
    }
}
