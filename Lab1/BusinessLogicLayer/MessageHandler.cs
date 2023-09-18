using DataLayer;
namespace BusinessLogicLayer
{
    public class MessageHandler : IMessageHandler
    {
       
        public void OnAdding(object sender, EventArgs e) => Console.WriteLine("Succesfully added item");
        public void OnRemoving(object sender, EventArgs e) => Console.WriteLine("Succesfully removed item");
        public void OnCleared(object sender, EventArgs e) => Console.WriteLine("Succesfully cleared the list");
        public void OnCopied(object sender, EventArgs e) => Console.WriteLine("Succesfully copied list into array");
        public void OnEndPlaced(object sender, EventArgs e) => Console.WriteLine("Succesfully placed item to the end");
        public void OnBeginPlaced(object sender, EventArgs e) => Console.WriteLine("Succesfully placed item to the begin");

    }
}