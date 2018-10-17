using System;
using System.Collections.Generic;
using System.Linq;

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
            x.Push(new StringBuilder("1"));

            // BFS
            while (n-- > 0) // decrement n by 1
            {
                // Print first element of the queue
                StringBuilder sb = x.Pop();
                output.AddLast(sb.ToString());

                // Make a copy
                StringBuilder sbc = new StringBuilder(sbc.ToString());

                // Left child
                sb.Append('0');
                x.Push(sb);
                // Right child
                sbc.Append('1');
                x.Push(sbc);
                // Decrement n by one
                n--;
            }
            return output;

            // Driver program that will test the above function
            static void main(String[] args)
            {
                int n = 10;
                if (args.Length < 1)
                {
                    Console.WriteLine("Please invoke with the max value to print binary up to, like this: ");
                    Console.WriteLine("\t Main 12");
                    return;
                }
                try
                {
                    n = Int32.Parse(args[0]);
                }
                catch
                {
                    Console.WriteLine("I'm sorry, I can't understand the number: " + args[0]);
                    return;
                }

                LinkedList<string> output = generateBinaryRepresentation(n);
                // Print it right justified with the longest string as the last one
                int maxLength = output.Count();
                foreach(string s in output)
                {
                    for (int i = 0; i < maxLength - s.Length; i++)
                    {
                        Console.WriteLine(" ");
                    }
                    Console.WriteLine(s);
                }
            }
        }
    }
}
