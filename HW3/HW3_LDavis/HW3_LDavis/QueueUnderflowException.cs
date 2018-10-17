using System;
using System.Collections.Generic;
using System.Text;

namespace HW3_LDavis
{
    public class QueueUnderflowException : SystemException
    {
        /// learned that 'super' in Java is 'base' in C# 
        /// from this site https://hackerbits.com/programming/top-10-differences-between-java-and-c/

        /// <summary>
        /// Running a test to check for any operations that were ran
        /// on an empty queue.
        /// </summary>

        public QueueUnderflowException() : base()
        {
         
        }

        /// <summary>
        /// There will be a return string message that will inform
        /// user of the incorrect/illegal operation perfomred in the program.
        /// </summary>
        public QueueUnderflowException(String message) : base(message)
        {
           
        }
    }
}
