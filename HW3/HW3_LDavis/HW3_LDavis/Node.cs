using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Single linked node class
namespace HW3_LDavis
{
    public class Node<T>
    {
        public T Data { get; set; }
        internal Node<T> Next { get; set; }

        /// <summary>
        /// The following will be moving the pointer from 
        /// the current node to the next node in the queue.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="next"></param>
        public Node(T data, Node<T> next)
        {
            this.Data = data;
            this.Next = next;
        }
    }
}
