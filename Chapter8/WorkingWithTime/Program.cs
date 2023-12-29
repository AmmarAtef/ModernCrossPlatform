using System.Globalization;
using static System.Console;


DateTime christmas = new DateTime(2021, 12, 25);

DateTime beforeexam = christmas.Subtract(TimeSpan.FromDays(12));
DateTime afterexam = christmas.Add(TimeSpan.FromDays(12));

WriteLine($"12 days before christmas is {beforeexam}");
WriteLine($"12 days after christmas is {afterexam}");

TimeSpan untilSpan = afterexam - christmas;

WriteLine($"{ untilSpan.TotalMinutes}-{untilSpan.Hours}- {untilSpan.Days}");


WriteLine(CultureInfo.CurrentCulture.Name);

string textDate = "4 July 2021";

DateTime independaceDay = DateTime.Parse(textDate);

WriteLine($"{textDate:d MMMM}");

textDate = "7/4/2021";

independaceDay = DateTime.Parse(textDate);


WriteLine(textDate, CultureInfo.GetCultureInfo("en-US"));

for(int year = 2020; year < 2026; year++)
{
    WriteLine($"{year} is a leap year:{DateTime.IsLeapYear(year)}");
    WriteLine($"there are {DateTime.DaysInMonth(year, 2)}");

}