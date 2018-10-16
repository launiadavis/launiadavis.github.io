using System;
using System.Collections.Generic;

namespace HW3_LDavis
{
    public class Program
    {
        static LinkedList<string> generateBinaryRepresentionList(int n)
        {
            // Create an empty queue of strings
            LinkedQueue<StringBuilder> x = new LinkedQueue<StringBuilder>();
            // A list to return the binary values
            LinkedList<string> output = new LinkedList<string>();
            if (n < 1)
            {
                // Negative numbers are not represented in binary values
                // Return the empty list
                return output;
            }

            // Enqueue the first binary number
            x.push(new StringBuilder("1"));

            // BFS
            while (n-- > 0) // decrement n by 1
            {
                // Print first element of the queue
                StringBuilder sb = x.Pop();
                output.AddLast(sb.toString());
            }
        }
    }
}
