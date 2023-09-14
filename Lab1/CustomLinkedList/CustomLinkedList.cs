using System.Collections;

namespace CustomLinkedList
{
    public class CustomLinkedList<T> : ICollection<T>
    {
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
                this.First.Previous = node;
                node.Next = this.First;
                this.First = node;
            }
            Count++;
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
                this.Last.Next = node;
                node.Previous = this.Last;
                this.Last = node;
            }
            Count++;
        }

        public void Clear()
        {
            First = null;
            Last = null;
            Count = 0;
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
                Node<T> prevNode = oldNode.Previous;

                newNode.Previous = prevNode;
                newNode.Next = oldNode;
                oldNode.Previous = newNode;
                prevNode.Next = newNode;
                
            }
            Count++;
        }

        public void AddAfter(Node<T> newNode, Node<T> oldNode)
        {
            if(this.First == null && this.Count == 0)
            {
                AddFirst(newNode);
            }
            else if(this.Last ==oldNode)
            {
                AddLast(newNode);
            }
            else
            {
                Node<T> prevNode = oldNode.Previous;

                prevNode.Next = newNode;
                newNode.Previous = oldNode.Previous;
                newNode.Next = oldNode;
                oldNode.Previous = newNode;
            }
            Count++;

        }

        public void Show()
        {
            Node<T> node = this.First;

            while(node.Next != null)
            {
                Console.WriteLine(node.Data);
                node = node.Next;
            }
            Console.WriteLine(node.Data);
        }

        public void RemoveFirst()
        {
            this.First = this.First.Next;
            this.First.Previous = null;
            Count--;
        }

        public bool Remove(T node)
        {
            if(this.First == null && this.Count == 0)
            {
                Console.WriteLine($"Nothing to remove");
                return false;
            }
            else if(this.First.Data.Equals(node))
            {
                RemoveFirst();
                return true;
            }
            else
            {
                Node<T> prevNode = First;
                Node<T> currNode = prevNode.Next;

                while(currNode != null && !currNode.Data.Equals(node))
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
                return true;
            }
        }

        public void Add(T item)
        {
            AddLast(new Node<T>(item));
        }

        public bool Contains(T item)
        {
            Node<T> node = First;
            while(!node.Data.Equals(item) && node.Next != null)
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

            Node<T> node = First;

            while(node != null)
            {
                array[arrayIndex++] = node.Data;
                node = node.Next;
            }
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