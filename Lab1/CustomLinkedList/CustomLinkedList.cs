using System.Collections;

namespace DataLayer
{
    public class CustomLinkedList<T> : ICollection<T>
    {
        public delegate void OnActionEventHandler(object sender);
        public event OnActionEventHandler? OnAdding;
        public event OnActionEventHandler? OnRemoving;
        public event OnActionEventHandler? OnCleared;
        public event OnActionEventHandler? OnCopied;
        public event OnActionEventHandler? OnEndPlaced;
        public event OnActionEventHandler? OnBeginPlaced;

        public Node<T>? First { get; private set;}
        public Node<T>? Last { get; private set;}
        public int Count { get; private set;}
        public bool IsReadOnly => false;

        public CustomLinkedList()
        {
            this.First = null;
            this.Last = null;
        }

        public void AddFirst(Node<T> node)
        {
            if(this.First == null && this.Count == 0)
            {
                this.First = node;
                this.Last = node;
            }
            else
            {
                this.First!.Previous = node;
                node.Next = this.First;
                this.First = node;
            }
            Count++;

            OnBeginPlaced?.Invoke(this);
        }

        public void AddLast(Node<T> node)
        {
            if (this.First == null && this.Count == 0)
            {
                this.First = node;
                this.Last = node;

            }
            else
            {
                this.Last!.Next = node;
                node.Previous = this.Last;
                this.Last = node;
            }
            Count++;
            OnEndPlaced?.Invoke(this);
        }

        public void Clear()
        {
            First = null;
            Last = null;
            Count = 0;

            OnCleared?.Invoke(this);   
        }

        public void AddBefore(Node<T> newNode, Node<T> oldNode)
        {
            if ((this.First == null && this.Count == 0) || this.First == oldNode)
            {
                this.AddFirst(newNode);
                return;
            }

            if (this.Contains(oldNode) == false)
            {
                throw new NullReferenceException("Such node does not exist");
            }
            
            Node<T>? prevNode = oldNode.Previous;

            newNode.Previous = prevNode;
            newNode.Next = oldNode;
            oldNode.Previous = newNode;
            prevNode!.Next = newNode;
               
            Count++;

            OnAdding?.Invoke(this);
        }

        public void AddAfter(Node<T> newNode, Node<T> oldNode)
        {
            if((this.First == null && this.Count == 0) || this.First == oldNode)
            {
                AddFirst(newNode);
                return;
            }

            if(this.Last == oldNode)
            {
                AddLast(newNode);
                return;
            }

            if(this.Contains(oldNode) == false)
            {
                throw new NullReferenceException("Such a node does not exists");
            }
            
            Node<T>? nextNode = oldNode.Next;

            newNode.Previous = oldNode;
            newNode.Next = nextNode;
            nextNode!.Previous = newNode;
            oldNode.Next = newNode;
            
            Count++;

            OnAdding?.Invoke(this);
        }

        public void RemoveFirst()
        {
            if(this.Count == 0)
            {
                Console.WriteLine("There is no item to remove");
                return;
            }

            this.First = this.First!.Next;
            this.First!.Previous = null;
            Count--;

            OnRemoving?.Invoke(this);
        }

        public void RemoveLast()
        {
            if (this.Count == 0)
            {
                Console.WriteLine("There is no item to remove");
                return;
            }

            this.Last = this.Last!.Previous;
            this.Last!.Next = null;
            Count--;

            OnRemoving?.Invoke(this);
        }

        public bool Remove(T node)
        {
            if(this.First == null && this.Count == 0)
            {
                Console.WriteLine($"Nothing to remove");
                return false;
            }
            else if(First!.Data!.Equals(node))
            {
                RemoveFirst();
                return true;
            }
            else
            {
                Node<T>? prevNode = First;
                Node<T>? currNode = prevNode.Next;

                while(currNode != null && !currNode.Data!.Equals(node))
                {
                    prevNode = currNode;
                    currNode = prevNode.Next;
                }

                if (currNode != null)
                {
                    prevNode.Next = currNode.Next;
                    currNode.Next = currNode.Previous;
                }
                Count--;
                OnRemoving?.Invoke(this);
                return true;

            }
        }

        public void Add(T item)
        {
            AddLast(new Node<T>(item));

            OnAdding?.Invoke(this);
        }

        public bool Contains(T item)
        {
            Node<T> node = First!;
            while(!node!.Data!.Equals(item) && node.Next != null)
            {
                node = node.Next;
            }
            if (node.Data.Equals(item)) return true;
            else return false;
            
        }

        private bool Contains(Node<T> item)
        {
            Node<T> node = First!;
            while (!node.Equals(item) && node.Next != null)
            {
                node = node.Next;
            }
            if (node.Equals(item)) return true;
            else return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex < 0 || arrayIndex > array.Length)
            {
                throw new ArgumentOutOfRangeException("Index was out of range");
            }

            if (array.Length - arrayIndex < Count)
            {
                throw new InvalidOperationException("Cannot copy to array: not enough space");
            }

            Node<T>? node = First;

            while(node != null)
            {
                array[arrayIndex++] = node.Data;
                node = node.Next;
            }

            OnCopied?.Invoke(this);
        }

        public Node<T> Find(T item)
        {
            Node<T> node = First!;
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            if(node != null)
            {
                if(item != null )
                {
                    while (node != null)
                    {
                        if (comparer.Equals(node.Data, item))
                        {        
                            return node;
                        }
                        node = node.Next!;
                    }
                }
                else
                {
                    while(node != null)
                    {
                        if(node!.Data == null)
                        {
                            return node;
                        }
                        node = node.Next!;
                    }
                }    
            }
            return null;
        }


        public IEnumerator<T> GetEnumerator()
        {
            Node<T> node = First!;

            while(node != null)
            {
                yield return node.Data;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}