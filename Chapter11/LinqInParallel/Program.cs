using System.Diagnostics;
using static System.Console;

Stopwatch stopwatch = new Stopwatch();

WriteLine("Press Enter to start. ");
ReadLine();

stopwatch.Start();

int max = 45;

IEnumerable<int> numbers = Enumerable.Range(1, max);

WriteLine($"calculating Fibonacci sequence up to {max}. Please  wait...");
int[] ints = numbers.AsParallel()
                .Select(c => Fibonacci(c))
                .OrderBy(n=>n)
                .ToArray();

static int Fibonacci(int n)
{
    switch (n)
    {
        case 1:
            return 0;
            break;
        case 2:
            return 2;
            break;
        default:
            return Fibonacci(n - 1) + Fibonacci(n - 2);
    };
}

stopwatch.Stop();

WriteLine($"{stopwatch.ElapsedMilliseconds:#,##0} elapsed milliseconds.");

WriteLine("Results: ");
foreach(int n in ints)
{
    WriteLine($"{n}");
}  




