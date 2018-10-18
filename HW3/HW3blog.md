# Homework 3 Blog

## The Assignment

At the beginning of this homework assignment we had to make sure our environment was
set up but downloading and installing Visual Studio IDE. After that we were to download
a zip file that contained java files. After downloading the files we were to review the 
code, compile and run the code. Below is a result of what the java files do in a windows
command line.

```
C:\Users\launi>cd

C:\Users\launi>cd C:\Users\launi\Documents\CS460\HW3\DownloadedJava

C:\Users\launi\Documents\CS460\HW3\DownloadedJava>java Main 12
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

C:\Users\launi\Documents\CS460\HW3\DownloadedJava>java Main -12
Exception in thread "main" java.util.NoSuchElementException
        at java.util.LinkedList.getLast(Unknown Source)
        at Main.main(Main.java:89)

C:\Users\launi\Documents\CS460\HW3\DownloadedJava>java Main a
I'm sorry, I can't understand the number: a
```

What the java files did essentially was print the binary representation of all numbers from 1 up to n (as shown in the cmd code above). This is accomplished by using a FIFO queue to perform a level order (i.e. BFS) traversal of a virtual binary tree that looks like this:

                      1
                  /       \
                 10       11
                /  \     /  \
             100  101  110  111

Once we had an understanding of what the java files did it was now time to move on to translating the java code into c#. When I began this process I followed along with the notes in class about some of the syntax for c#. I also used Microsoft's Documentation for c# for guidance in how to translate parts of the java code.

For the most part, what I had learned from this assignment was that there weren't a lot of noticeable differences between java and c#. Just small changes for syntax. As and example, in QueueUndreflowException.java, the method 'super()' is used and in c# instead of typing super it is 'base()' as the reference to the parent class.

```java
public class QueueUnderflowException extends RuntimeException
{
  public QueueUnderflowException()
  {
    super();
  }

  public QueueUnderflowException(String message)
  {
    super(message);
  }
}
```
```cs
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
```

The most notable difference when translating the code was that the exception that can be thrown in the QueueInterfac.java file couldn't be written inside of the IQueueInterface.cs file. Instead the exception had to be written in the LinkedQueue.cs file for when the queue is empty and pop was envoked on it. Below are visuals of the code differences.

```java
public interface QueueInterface<T>
{
    /**
     * Add an element to the rear of the queue
     * 
     * @return the element that was enqueued
     */
    T push(T element);

    /**
     * Remove and return the front element.
     * 
     * @throws Thrown if the queue is empty
     */
    T pop() throws QueueUnderflowException;

    /**
     * Test if the queue is empty
     * 
     * @return true if the queue is empty; otherwise false
     */
    boolean isEmpty();
}
```
Portion of code from the QueueInterface.java file.
```cs
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
```
Portion of code from the LinkedQueue.cs file.

During this assignment we were also to work on a feature branch. I had called that branch 'HW3'. We were to make several commits on that branch before we were to merge back to our master at the end of this assignment. Below is a graph representaion of that branch merging executed for this assignment.

```
LDavis@LauniaPC:/mnt/c/Users/launi/Documents/CS460/Homework/launiadavis.github.io$ git log --oneline --graph
*   6fcb2dc Merge branch 'HW3' into 'master' of https://github.com/launiadavis/launiadavis.github.io
|\
| * 4acee25 Update README.md
* | 9794b02 updating ignore file
* | 356c13d removing old project, setup was wrong
* | 39f82b5 final commit for HW3
* | e29984f finalizing XML comment fixes
* | d2a27f0 some XML comment fixes
* | cb9a7ed third commit for HW3
* | 821716b second commit HW3
* | fe5538e git ignore is added
* | b10a930 first commit HW3
|/
* 
```

Finally, we have come down to the conclusion of this segment. So did the translation work? It sure did! Go on and check out the HW3 Demo link on my portfolio and see what happened!
