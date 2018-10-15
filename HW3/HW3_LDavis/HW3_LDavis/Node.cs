using System;
using System.Collections.Generic;
using System.Text;

namespace HW3_LDavis
{
    public class Node<T>
    {
        public T data;

        public Node<T> next;

        public Node(T data, Node<T> next)
        {
            this.Data = data;
            this.Next = next;
        }
    }
}
