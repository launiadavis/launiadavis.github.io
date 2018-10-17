using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3_LDavis
{
    public class LinkedQueue<T> : IQueueInterface<T>
    {
        private Node<T> front;
        private Node<T> rear;

        public LinkedQueue()
        {
            this.front = null;
            this.rear = null;
        }

        /// <summary>
        /// If an element type returns with a null value then a 
        /// NullReferenceException will be thrown.
        /// Similar to java's NullPointerException
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public T Push(T element)
        {
            if(element == null)
            {
                throw new NullReferenceException();
            }
             if(IsEmpty())
            {
                Node<T> tmp = new Node<T>(element, null);
                rear = front = tmp;    
            }
            else
            {
                Node<T> tmp = new Node<T>(element, null);
                rear.Next = tmp;
                rear = tmp;
            }

            return element;
        }

        /// <summary>
        /// Pulls the elements from the queue and removes it
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            T tmp = default(T);

            if (IsEmpty())
            {
                throw new QueueUnderflowException("The queue was empty when pop was invoked.");
            }
            else if (front == rear)
            {
                /// One item is in the  queue
                tmp = front.Data;
                front = null;
                rear = null;
            }
            else
            {
                /// All other cases
                tmp = front.Data;
                front = front.Next;
            }
            return tmp;
        }
          
        bool IsEmpty()
        {
            if(front == null && rear == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        bool IQueueInterface<T>.IsEmpty()
        {
            throw new NotImplementedException();
        }
    }
}
