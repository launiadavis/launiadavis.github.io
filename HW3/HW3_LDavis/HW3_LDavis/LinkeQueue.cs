using System;
using System.Collections.Generic;
using System.Text;

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

        public T Push(T element)
        {
            if(element == null)
            {
                throw new NullReferenceException();
            }
             if (IsEmpty())
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

        public T Pop()
        {
            T temp = default(T);

            if(IsEmpty())
            {
                throw new QueueUnderflowException("The queueu was empty when poped was envoked.");
            }
        }
    }
}
