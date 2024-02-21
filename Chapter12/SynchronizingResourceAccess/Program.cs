using SynchronizingResourceAccess;
using System.Diagnostics;
using static System.Console;

static void MethodA()
{
    lock (SharedObjects.conch)
    {
        for (int i = 0; i < 5; i++)
        {
            Interlocked.Increment(ref SharedObjects.Counter);
            Thread.Sleep(SharedObjects.Random.Next(2000));
            SharedObjects.Message += "A";
            Write(".");
        }
    }
}


static void MethodB()
{
    try
    {
        if (Monitor.TryEnter(SharedObjects.conch, TimeSpan.FromSeconds(15)))
        {

            for (int i = 0; i < 5; i++)
            {
                Interlocked.Increment(ref SharedObjects.Counter);
                Thread.Sleep(SharedObjects.Random.Next(2000));
                SharedObjects.Message += "B";
                Write(".");
            }
        }
        else
        {
            WriteLine("Method A timed out when entering a monitor on conch.");
        }
    }
    finally
    {
        Monitor.Exit(SharedObjects.conch);
    }
}




WriteLine("Please wait for the tasks to complete.");


Stopwatch stopwatch = Stopwatch.StartNew();
Task a = Task.Factory.StartNew(MethodA);
Task b = Task.Factory.StartNew(MethodB);

Task.WaitAll(new Task[] { a, b });
WriteLine();
WriteLine($"Results:{SharedObjects.Message} .");
WriteLine($"{stopwatch.ElapsedMilliseconds:N0} elapsed milliseconds.");

WriteLine($"{SharedObjects.Counter} string modifications.");

