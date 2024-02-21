using chapter12;
using static System.Console;

WriteLine("Processing. Please wait....");
Recorder recorder = new Recorder();

Recorder.Start();

int[] largeArrayOfInts = Enumerable.Range(1, 10_000).ToArray();

Thread.Sleep(new Random().Next(5,10)*1000);

Recorder.Stop();