using System.Diagnostics;
using static System.Console;

static void OutputThreadInfo()
{
    Thread thread = Thread.CurrentThread;

    WriteLine($"Thread Id: {thread.ManagedThreadId}, Priority: {thread.Priority}," +
        $"Background:{thread.IsBackground} Name: {thread.Name}");
}

static void MethodA()
{
    WriteLine("Starting Method A...");
    OutputThreadInfo();
    Thread.Sleep(3000);
    WriteLine("Finished Method A");
}


static void MethodB()
{
    WriteLine("Starting Method B...");
    OutputThreadInfo();
    Thread.Sleep(2000);
    WriteLine("Finished Method B.");
}


static void MethodC()
{
    WriteLine("Starting Method C...");
    OutputThreadInfo();
    Thread.Sleep(1000);
    WriteLine("Finished Method C.");
}


static decimal CallWebService()
{
    WriteLine($"Starting call to web service;");
    OutputThreadInfo();
    Thread.Sleep((new Random()).Next(2000, 4000));
    WriteLine("Finished Call to web service");
    return 89.99M;
}

static string CallStoredProcedure(decimal amount)
{
    WriteLine("Starting call to stored procedure....");
    OutputThreadInfo();
    Thread.Sleep((new Random()).Next(2000, 4000));
    WriteLine("finished call to stored procedure");
    return $"12 products cost more than {amount:C}";
}



OutputThreadInfo();
Stopwatch stopwatch = Stopwatch.StartNew();

/*
WriteLine("Running methods syncronosuly on one thread.");

MethodA();
MethodB();
MethodC();
*/
/*
WriteLine("Running meyhods asyncronously on multiple threads.");

Task taskA = new Task(MethodA);
taskA.Start();

Task taskB = Task.Factory.StartNew(MethodB);

Task taskC = Task.Run(MethodC);

Task[] tasks = { taskA, taskB, taskC };
Task.WaitAll(tasks);
*/
WriteLine("Passing the result of one task as an input into another.");

Task<string> task = Task.Factory.StartNew(CallWebService)
                        .ContinueWith(prev => CallStoredProcedure(prev.Result));

WriteLine($"Result: {task.Result}");



WriteLine($"{stopwatch.ElapsedMilliseconds} ms elapsed");