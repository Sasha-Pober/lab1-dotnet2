using System;
using System.Collections;
using DataLayer;
class Program
{
    
    static void ShowList<T>(ICollection<T> list)
    {
        foreach (T item in list)
        {
            Console.WriteLine(item);
        }
    }
    static void Main(string[] args)
    {
        CustomLinkedList<string>  list = new CustomLinkedList<string>();
        MessageManager mgr = new MessageManager();

        mgr.InitHandlers(list);

        Console.WriteLine("Adding elements to the end:");

        for (int i = 0; i < 4; i++)
        {
            list.AddLast(new Node<string>($"element{i}"));
        }
        ShowList(list);

        Console.WriteLine();

        Console.WriteLine("Adding items to the begin:");

        list.AddFirst(new Node<string>("element10"));
        ShowList(list);

        Console.WriteLine();



        Console.WriteLine("Adding before specified item:");

        Node<string> elemX = new Node<string>("elementX");
        Node<string> elem5 = new Node<string>("element5");
        list.AddLast(elemX);
        list.AddBefore(elem5, elemX);
        ShowList(list);

        Console.WriteLine();



        Console.WriteLine("Adding after specified item:");

        Node<string> elem6 = new Node<string>("element6");
        list.AddAfter(elem6, elem5);
        ShowList(list);

        Console.WriteLine();


        Console.WriteLine("Finding items:");

        Console.WriteLine($"Found item - {list.Find("element2").Data}");

        Console.WriteLine();


        Console.WriteLine("Removing items:");

        list.Remove("element3");
        ShowList(list);

        Console.WriteLine();



        Console.WriteLine("Removing first item:");

        list.RemoveFirst();
        ShowList(list);

        Console.WriteLine();


        Console.WriteLine("Removing last item:");

        list.RemoveLast();
        ShowList(list);

        Console.WriteLine();



        Console.WriteLine("Copy into the array:");

        string[] arr = new string[list.Count];
        Console.WriteLine("Items of an array:");
        ShowList(arr);
        list.CopyTo(arr, 0);
        Console.WriteLine($"New items of the array");
        ShowList(arr);

        Console.WriteLine();


        Console.WriteLine("Find out if list contains item 'element11':");

        Console.WriteLine(list.Contains("element11"));

        Console.WriteLine();

       

    }
}