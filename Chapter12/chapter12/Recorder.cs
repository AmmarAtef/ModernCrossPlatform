using System.Diagnostics;
using static System.Diagnostics.Process;
using static System.Console;


namespace chapter12
{
    public class Recorder
    {
        private static Stopwatch timer = new Stopwatch();
        private static long bytesPhysicalBefore = 0;
        private static long bytesVirtualBefore = 0;

        public static void Start()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            bytesPhysicalBefore = GetCurrentProcess().WorkingSet64;
            bytesVirtualBefore = GetCurrentProcess().VirtualMemorySize64;
            timer.Restart();

        }

        public static void Stop()
        {
            timer.Stop();
            long bytesPhysicalAfter = GetCurrentProcess().WorkingSet64;

            long bytesVirtualAfter = GetCurrentProcess().VirtualMemorySize64;

            WriteLine($"{bytesPhysicalAfter -bytesPhysicalBefore} physical bytes used.");

            WriteLine($"{bytesVirtualAfter - bytesVirtualBefore} virtual bytes used.");

            WriteLine($"{timer.Elapsed} time span ellapsed.");

            WriteLine($"{timer.ElapsedMilliseconds} total milliseconds ellapsed.");

        }

    }
}