using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class MessageManager
    {
        public void OnAdding(object sender) => Console.WriteLine("Successfully added item");
        public void OnRemoving(object sender) => Console.WriteLine("Successfully removed item");
        public void OnCleared(object sender) => Console.WriteLine("Successfully cleared te list");
        public void OnCopied(object sender) => Console.WriteLine("Successfully copied the list into array");
        public void OnEndPlaced(object sender) => Console.WriteLine("Successfully added to the end");
        public void OnBeginPlaced(object sender) => Console.WriteLine("Successfully added to the begin");

        public void InitHandlers<T>(CustomLinkedList<T> list)
        {
            list.OnAdding += this.OnAdding;
            list.OnRemoving += this.OnRemoving;
            list.OnCleared += this.OnCleared;
            list.OnCopied += this.OnCopied;
            list.OnEndPlaced += this.OnEndPlaced;
            list.OnBeginPlaced += this.OnBeginPlaced;
        }

        public void RemoveAddingHandler<T>(CustomLinkedList<T> list) => list.OnAdding -= this.OnAdding;
        public void RemoveRemovingHandler<T>(CustomLinkedList<T> list) => list.OnRemoving -= this.OnRemoving;
        public void RemoveClearHandler<T>(CustomLinkedList<T> list) => list.OnCleared -= this.OnCleared;
        public void RemoveCopyHandler<T>(CustomLinkedList<T> list) => list.OnCopied -= this.OnCopied;
        public void RemoveEndPlaceHandler<T>(CustomLinkedList<T> list) => list.OnEndPlaced -= this.OnEndPlaced;
        public void RemoveBeginPlaceHandler<T>(CustomLinkedList<T> list) => list.OnBeginPlaced -= this.OnBeginPlaced;

    }
}
