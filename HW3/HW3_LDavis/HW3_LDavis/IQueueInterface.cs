using System;
using System.Collections.Generic;
using System.Text;

namespace HW3_LDavis
{
    // We are working with a FIFO queue interface.

    interface IQueueInterface <T>
    {
        // Add an element to the queue
        // It'll be the first element in the queue if there are no other
        // elements in the queue. 
        // If it's not the first element, the element is then added to 
        // the end of the queue.
        T Push(T element);

        // Remove and return the first element of the queue
        // Will not throw and exception if the queue is empty.
        // That is handled in another class.
        T Pop();

        // Test to see if the queue is empty.
        bool IsEmpty();
    }
}
