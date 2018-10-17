using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3_LDavis
{
    /// We are working with a FIFO queue interface.

    interface IQueueInterface <T>
    {
        /// <summary>
        /// Add an element to the queue
        /// It'll be the first element in the queue if there are no other
        /// elements in the queue. 
        /// If it's not the first element, the element is then added to 
        /// the end of the queue.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        T Push(T element);


        /// <summary>
        /// Remove and return the first element of the queue
        /// Will not throw and exception if the queue is empty.
        /// That is handled in another class.
        /// </summary>
        /// <returns></returns>
        T Pop();

        /// <summary>
        /// Test to see if the queue is empty.
        /// </summary>
        /// <returns></returns>
        bool IsEmpty();
    }
}
