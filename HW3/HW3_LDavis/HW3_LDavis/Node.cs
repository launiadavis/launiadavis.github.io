using System;
using System.Collections.Generic;
using System.Text;

// Single linked node class
namespace HW3_LDavis
{
    public class Node<T>
    {
        public T data;

        public Node<T> next;

        public Node(T data, Node<T> next)
        {
            this.data = data;
            this.next = next;
        }
    }
}
