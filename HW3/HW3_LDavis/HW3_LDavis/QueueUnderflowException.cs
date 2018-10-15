using System;
using System.Collections.Generic;
using System.Text;

namespace HW3_LDavis
{
    public class QueueUnderflowException : SystemException
    {
        //learned that 'super' in Java is 'base' in C# 
        //from this site https://hackerbits.com/programming/top-10-differences-between-java-and-c/
        public QueueUnderflowException() : base()
        {
         
        }

        public QueueUnderflowException(String message) : base(message)
        {
           
        }
    }
}
