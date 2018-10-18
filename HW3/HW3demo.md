# Homework 3 Demo

Since there was no html files to use for our demos (like in the previous two assignments), I will be placing in a segment of code from my Windows command line that shows the results of my c# translation.

Here it is!

```
C:\Users\launi\Documents\CS460\HW3\HW3\HW3\bin\Debug>HW3 12
           1
          10
          11
         100
         101
         110
         111
        1000
        1001
        1010
        1011
        1100

C:\Users\launi\Documents\CS460\HW3\HW3\HW3\bin\Debug>
C:\Users\launi\Documents\CS460\HW3\HW3\HW3\bin\Debug>HW3 a
I'm sorry, I can't understand the number: a

C:\Users\launi\Documents\CS460\HW3\HW3\HW3\bin\Debug>HW3 -10

C:\Users\launi\Documents\CS460\HW3\HW3\HW3\bin\Debug>HW3 5
    1
   10
   11
  100
  101

```

As you can see for when I typed in 'HW3 12' and 'HW3 5' the binary representations were printed out starting from 1 up to n (in this case 12 and 5). After each one was popped from the queue, a new binary representation can be seen as shown above.

Now what if a positive number isn't typed in? Well if a non-integer value was typed in the program would catch this an display the following message and that the program couldn't understand the number. But what about negative numbers? In this program, it would return an empty string for negative numbers that were inputed.