using static System.Console;


string company = "Microsoft Corp";

bool startsWithM = company.StartsWith('M');
bool containsN = company.Contains('N');

WriteLine($"{company.Trim()}");
WriteLine($"{company}");
WriteLine($"Starts with M:{startsWithM}, contains an N: {containsN}");