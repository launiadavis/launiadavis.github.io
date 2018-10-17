using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3_LDavis
{
    public class LinkedQueue<T> : IQueueInterface<T>
    {
        private Node<T> Front;
        private Node<T> Rear;

        public LinkedQueue()
        {
            this.Front = null;
            this.Rear = null;
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
                Rear = Front = tmp;    
            }
            else
            {
                Node<T> tmp = new Node<T>(element, null);
                Rear.Next = tmp;
                Rear = tmp;
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
            else if (Front == Rear)
            {
                /// One item is in the  queue
                tmp = Front.Data;
                Front = null;
                Rear = null;
            }
            else
            {
                /// All other cases
                tmp = Front.Data;
                Front = Front.Next;
            }
            return tmp;
        }
          
        public bool IsEmpty()
        {
            if(Front == null && Rear == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
