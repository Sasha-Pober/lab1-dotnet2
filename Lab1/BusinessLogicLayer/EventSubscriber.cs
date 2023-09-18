using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLogicLayer
{
    public class EventSubscriber<T> : IEventSubscriber<T>
    {
        private readonly ICustomLinkedList<T> list;
        private readonly IMessageHandler handler;

        public EventSubscriber(ICustomLinkedList<T> _list, IMessageHandler handler)
        {
            this.list = _list;
            this.handler = handler;
        }

        public void initSubscription()
        {
            list.OnAdding += handler.OnAdding;
            list.OnRemoving += handler.OnRemoving;
            list.OnCleared += handler.OnCleared;
            list.OnEndPlaced += handler.OnEndPlaced;
            list.OnBeginPlaced += handler.OnBeginPlaced;
            list.OnCopied += handler.OnCopied;
        }

    }
}
