using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Node<T>
    {
        public T Data { get; }
        public Node<T>? Next { get; set; }
        public Node<T>? Previous { get; set; }
        
        public Node(T data)
        {
            Data = data;
        }

        public bool Equals(Node<T> node)
        {
            return this == node && EqualityComparer<T>.Default.Equals(this.Data, node.Data);
        }
    }
}
