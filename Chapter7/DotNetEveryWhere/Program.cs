using static System.Console;

WriteLine("I can run everywhere!");

WriteLine($"OS Version is {Environment.OSVersion}");

if (OperatingSystem.IsMacOS())
{
    WriteLine("I am macOS");
}
else if (OperatingSystem.IsWindowsVersionAtLeast(10))
{
    WriteLine($"I am windows 10 or 11");
}
else
{
    WriteLine($"I am some other mysterious OS. ");
}

WriteLine("Press enter to stop me ");
ReadLine();