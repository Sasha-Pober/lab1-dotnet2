using System;
using System.Collections;
using CustomLinkedList;
class Program
{
    static void Main(string[] args)
    {
        CustomLinkedList.CustomLinkedList<string>  list = new CustomLinkedList.CustomLinkedList<string>();

        for (int i = 0; i < 4; i++)
        {
            list.AddLast(new Node<string>($"aboba{i}"));
        }

        /*list.Show();
        Console.WriteLine();

        list.RemoveFirst();

        list.Show();
        Console.WriteLine();

        list.Remove("aboba3");*/

        foreach(var node in list)
        {
            Console.WriteLine(node.ToString());
        }
        Console.WriteLine();

        string[] arr = new string[list.Count];

        list.CopyTo(arr, 3);

        foreach(var node in arr)
        {
            Console.WriteLine(node.ToString());
        }

    }
}