using System;
using System.Net.Http.Headers;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a value:");
        Console.WriteLine("1 : Linked List");
        Console.WriteLine("0 : Exit");

        string? mainInput = Console.ReadLine(); // Renamed variable to avoid conflict

        if (mainInput != null)
        {
            if (int.TryParse(mainInput, out int option))
            {
                HandleOptions(option);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
        else
        {
            Console.WriteLine("No input provided.");
        }
    }

    static void HandleOptions(int option)
    {
        switch (option)
        {
            case 0:
                Console.WriteLine("Exiting the program.");
                Environment.Exit(0);
                break;
            case 1:
                HandleLinkedOption(option);
                break;
            default:
                Console.WriteLine("Invalid option selected.");
                break;
        }
    }

    static void HandleLinkedOption(int option)
    {
        Console.WriteLine("Which datastructure problem you want to run in LinkedIn:");
        Console.WriteLine("1 : Merge K List using Priority Queues");
        string? linkedInput = Console.ReadLine(); // Renamed variable to avoid conflict

        if (linkedInput != null)
        {
            if (!int.TryParse(linkedInput, out int subOption))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }

        DataStructure_Ext_Console.LinkedList linkedList = new DataStructure_Ext_Console.LinkedList();

        switch (option)
        {
            case 1:
                {
                    // Fixing the issue by properly initializing the array of ListNode
                    DataStructure_Ext_Console.ListNode[] list = new DataStructure_Ext_Console.ListNode[3];
                    list[0] = linkedList.GenerateLinkedList(new int[] { 1, 4, 5 });
                    list[1] = linkedList.GenerateLinkedList(new int[] { 1, 3, 4 });
                    list[2] = linkedList.GenerateLinkedList(new int[] { 2, 6 });
                    linkedList.MergeLinkedListGPT(list);
                    break;
                }
            default:
                Console.WriteLine("Invalid option selected.");
                break;
        }

        Console.WriteLine("Want to continue to run LinkedList questions Yes(Y)/No(N)");
        string? continueInput = Console.ReadLine(); // Renamed variable to avoid conflict
        if (continueInput != null)
        {
            if (continueInput.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                HandleLinkedOption(1);
            }
            else if (continueInput.Equals("N", StringComparison.OrdinalIgnoreCase))
            {
                Main(null); // Restart the main method
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter Y or N.");
            }
        }
    }

    static void LinkedListOperations()
    {
        Console.WriteLine("Performing Linked List operations...");
        // Call methods from LinkedList.cs here
    }
}
