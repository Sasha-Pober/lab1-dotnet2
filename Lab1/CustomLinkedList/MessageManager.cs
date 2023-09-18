using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class MessageManager
    {
        public void OnAdded(object sender, EventArgs e) => Console.WriteLine("Successfully added item");
        public void OnRemoved(object sender, EventArgs e) => Console.WriteLine("Successfully removed item");
        public void OnCleared(object sender, EventArgs e) => Console.WriteLine("Successfully cleared te list");
        public void OnCopied(object sender, EventArgs e) => Console.WriteLine("Successfully copied the list into array");
        public void OnEndPlaced(object sender, EventArgs e) => Console.WriteLine("Successfully added to the end");
        public void OnBeginPlaced(object sender, EventArgs e) => Console.WriteLine("Successfully added to the begin");

    }
}
