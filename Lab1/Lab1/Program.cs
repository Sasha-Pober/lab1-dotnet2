using System;
using System.Collections;
using CustomLinkedList;
class Program
{
    static void Main(string[] args)
    {
        CustomLinkedList.LinkedList<string>  list = new CustomLinkedList.LinkedList<string>();

        for (int i = 0; i < 4; i++)
        {
            list.AddLast(new Node<string>($"aboba{i}"));
        }

        list.Show();
        Console.WriteLine();

        list.RemoveFirst();

        list.Show();
        Console.WriteLine();

        list.Remove("aboba3");

        list.Show();
        Console.WriteLine();

    }
}