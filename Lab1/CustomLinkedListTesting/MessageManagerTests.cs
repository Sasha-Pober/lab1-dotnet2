using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace CustomLinkedListTesting
{
    [TestFixture]
    public class MessageManagerTests
    {
        private MessageManager _mgr;
        private CustomLinkedList<string> _list;
        [SetUp]
        public void SetUp() 
        {
            _mgr = new MessageManager();
            _list = new CustomLinkedList<string>(); 
        }

        [Test]
        public void InitHandlers_NoHandlers_TrueReturned()
        {
            bool res = _mgr.InitHandlers(_list);

            Assert.That(res, Is.True);
        }

        [Test]
        public void OnBeginPlacedHandler_AddHandler_TrueReturned()
        {
            var wasCalled = false;

            _mgr.InitHandlers(_list);

            _list.OnBeginPlaced += (o) => wasCalled = true;

            _list.AddFirst(new Node<string>("node"));

            Assert.That(wasCalled, Is.True);

        }

        [Test]
        public void OnAddingHandler_AddHandler_TrueReturned()
        {
            var wasCalled = false;

            _mgr.InitHandlers(_list);
            _list.OnAdding += (o) => wasCalled = true;

            Node<string> node = new("node");
            Node<string> node1 = new("node1");
            _list.AddLast(node);
            _list.AddLast(node1);
            _list.AddAfter(new Node<string>("node2"), node);

            Assert.That(wasCalled, Is.True);
        }

        [Test]
        public void OnClearedHandler_AddHandler_TrueReturned()
        {
            var wasCalled = false;

            _mgr.InitHandlers(_list);
            _list.OnCleared += (o) => wasCalled = true;

            Node<string> node = new("node");
            Node<string> node1 = new("node1");
            _list.AddLast(node);
            _list.AddLast(node1);
            _list.Clear();

            Assert.That(wasCalled, Is.True);
        }

        [Test]
        public void OnRemovingHandler_AddHandler_TrueReturned()
        {
            var wasCalled = false;

            _mgr.InitHandlers(_list);
            _list.OnRemoving += (o) => wasCalled = true;

            Node<string> node = new("node");
            Node<string> node1 = new("node1");
            _list.AddLast(node);
            _list.AddLast(node1);
            _list.RemoveFirst();

            Assert.That(wasCalled, Is.True);
        }

        [Test]
        public void OnCopiedHandler_AddHandler_TrueReturned()
        {
            var wasCalled = false;

            _mgr.InitHandlers(_list);
            _list.OnCopied += (o) => wasCalled = true;

            string[] arr = new string[2];

            Node<string> node = new("node");
            Node<string> node1 = new("node1");
            _list.AddLast(node);
            _list.AddLast(node1);
            _list.CopyTo(arr, 0);

            Assert.That(wasCalled, Is.True);
        }
    }
}
