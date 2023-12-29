using static System.Console;


string name = "Samantha Jones";
int lengthOfFirst = name.IndexOf(' ');
int lengthOflast = name.Length - lengthOfFirst - 1;

string firstName = name.Substring(0, lengthOfFirst);

string lastName = name.Substring(lengthOfFirst + 1, name.Length - lengthOfFirst - 1);




WriteLine($"First name:{firstName}, Last name:{lastName}");



// using spans 

ReadOnlySpan<char> nameAsSpan = name.AsSpan();

ReadOnlySpan<char> firstNameSpan = name[0..lengthOfFirst];
ReadOnlySpan<Char> secondName = name[^lengthOflast..^0];

WriteLine($"First name:{firstNameSpan}, last name: {secondName}");



ReadLine();