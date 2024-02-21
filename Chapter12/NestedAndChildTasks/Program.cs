using static System.Console;

static void OuterMethod()
{
    WriteLine("Outer method starting...");
    Task innerTask = Task.Factory.StartNew(InnerMethod, TaskCreationOptions.AttachedToParent);
    WriteLine("Outer method finished");
}


static void InnerMethod()
{
    WriteLine("Inner method starting...");
    Thread.Sleep(3000);
    WriteLine("Inner Method finished.");
}

Task outerTask = Task.Factory.StartNew(OuterMethod);

outerTask.Wait();

WriteLine("Console app is stopping.");