using static System.Console;
using System.Globalization;


CultureInfo globalization = CultureInfo.CurrentCulture;
CultureInfo localization = CultureInfo.CurrentUICulture;


WriteLine($"the current globalization culture is {globalization.Name} : {globalization.DisplayName}");
WriteLine($"the current localization culture is {localization.Name} : {localization.DisplayName}");



WriteLine("Enter your Culture");
string? newCulture = ReadLine();

if (!string.IsNullOrWhiteSpace(newCulture))
{
    CultureInfo ci = new CultureInfo(newCulture);
    // change the current cultures
    CultureInfo.CurrentCulture = ci;
    CultureInfo.CurrentUICulture = ci;
}

WriteLine("Enter your name");
string? name = ReadLine();

WriteLine("Enter your date of birth ");
string? dob = ReadLine();

WriteLine("Enter your salary:");
string? salary = ReadLine();

DateTime date = DateTime.Parse(dob);
int minutes = (int)DateTime.Today.Subtract(date).TotalMinutes;
decimal earns = decimal.Parse(salary);


WriteLine($"{name} was born on a {date:dddd}, is minutes {minutes} old, and earns {earns:C}");



ReadLine();

