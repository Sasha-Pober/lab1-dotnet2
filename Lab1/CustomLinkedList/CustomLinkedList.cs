using System.Collections;

namespace DataLayer
{
    public class CustomLinkedList<T> : ICollection<T>
    {
        public delegate void OnActionEventHandler(object sender, EventArgs e);
        public event OnActionEventHandler OnAdding;
        public event OnActionEventHandler OnRemoving;
        public event OnActionEventHandler OnCleared;
        public event OnActionEventHandler OnCopied;
        public event OnActionEventHandler OnEndPlaced;
        public event OnActionEventHandler OnBeginPlaced;

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

            OnBeginPlaced(this, EventArgs.Empty);
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

            OnEndPlaced(this, EventArgs.Empty);
        }

        public void Clear()
        {
            First = null;
            Last = null;
            Count = 0;

            OnCleared(this, EventArgs.Empty);
        }

        public void AddBefore(Node<T> newNode, Node<T> oldNode)
        {
            if (this.First == null && this.Count == 0)
            {
                this.AddFirst(newNode);
            }
            else if (this.First == oldNode)
            {
                AddFirst(newNode);
            }
            else
            {
                Node<T>? prevNode = oldNode.Previous;

                newNode.Previous = prevNode;
                newNode.Next = oldNode;
                oldNode.Previous = newNode;
                prevNode!.Next = newNode;
                
            }
            Count++;

            OnAdding(this, EventArgs.Empty);
        }

        public void AddAfter(Node<T> newNode, Node<T> oldNode)
        {
            if(this.First == null && this.Count == 0)
            {
                AddFirst(newNode);
            }

            if(this.Last == oldNode)
            {
                AddLast(newNode);
            }

            if(this.First == oldNode)
            {
                AddFirst(newNode);
            }
            
            Node<T>? prevNode = oldNode.Previous;

            prevNode!.Next = newNode;
            newNode.Previous = oldNode.Previous;
            newNode.Next = oldNode;
            oldNode.Previous = newNode;
            
            Count++;

            OnAdding(this, EventArgs.Empty);
        }

        public void RemoveFirst()
        {
            this.First = this.First!.Next;
            this.First!.Previous = null;
            Count--;

            OnRemoving(this, EventArgs.Empty);
        }

        public void RemoveLast()
        {
            this.Last = this.Last.Previous;
            this.Last!.Next = null;
            Count--;

            OnRemoving(this, EventArgs.Empty);
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
                OnRemoving(this, EventArgs.Empty);
                return true;

            }
        }

        public void Add(T item)
        {
            AddLast(new Node<T>(item));

            OnAdding(this, EventArgs.Empty);
        }

        public bool Contains(T item)
        {
            Node<T> node = First;
            while(!node!.Data!.Equals(item) && node.Next != null)
            {
                node = node.Next;
            }
            if (node.Data.Equals(item)) return true;
            else return false;
            
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex < 0 || arrayIndex > array.Length) throw new ArgumentOutOfRangeException(nameof(arrayIndex));

            if (array.Length - arrayIndex < Count) throw new Exception("Not enough space in array");

            Node<T>? node = First;

            while(node != null)
            {
                array[arrayIndex++] = node.Data;
                node = node.Next;
            }

            OnCopied(this, EventArgs.Empty);
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
            Node<T> node = First;

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