using Classlib;

try
{
    Person john = new Person();
    john.Name = "Johmn";
    john.DateOfBirth = new DateTime(year:2000, month:2, day:1);

    john.TimeTravel(when: new DateTime(2001, 1, 1));
    john.TimeTravel(when: new DateTime( 1992,  1, 1));

}
catch (PersonException ex)
{
    Console.WriteLine(ex.Message);
}

string name = "Ammar@yahoo.com";
bool valid = name.IsValidEmail();
Console.WriteLine(valid);