using Packet.Shared;
using PacketLibrary;
using System.Collections;
using static System.Console;

Person harry = new() { Name = "Harry" };
Person mary = new() { Name = "Mary" };
Person jill = new() { Name = "Jill" };


//// call instance method
//Person baby1 = mary.ProcreateWith(harry);
//baby1.Name = "Gray";


//// call static Method 
//Person baby2 = Person.Procreate(harry, jill);


//// call static method 
//Person baby3 = harry * mary;


//WriteLine($"{harry.Name} has {harry.Children.Count} children.");
//WriteLine($"{mary.Name} has {mary.Children.Count} children.");
//WriteLine($"{jill.Name} has {jill.Children.Count} children.");

//WriteLine(Person.Factorial(5));

//Person p1 = new Person();

//int answer = p1.MethodIWantToCall("Frog");
//WriteLine(answer);
//// create a delegate instance that points to the method


//DelegateWithMatchingSignature d = new(p1.MethodIWantToCall);
//WriteLine(d("Forg"));


//static void Harry_Shout(object? sender, EventArgs e)
//{
//    if (sender is null) return;
//    Person p = (Person)sender;
//    WriteLine($"{p.Name} is this angry: {p.AngerLevel}.");
//}

//harry.Shout += Harry_Shout;


//harry.Poke();
//harry.Poke();
//harry.Poke();
//harry.Poke();



//Console.WriteLine("Nameeeeeeeeeeeeee");
//Trying name1 = new name1();

//Console.WriteLine(typeof(Trying) + ":  " + name1.getName());

//ArrayList arr = new ArrayList();
//arr.Add("ammar");
//arr.Add(new name1());


//Hashtable lookupObject = new();
//lookupObject.Add(1, "Alpha");
//lookupObject.Add(2, "Beta");
//lookupObject.Add(3, "Gamma");
//lookupObject.Add(harry, "Delta");

//WriteLine(lookupObject[2]);

//// generic lookup collection 
//Dictionary<int, string> lookupInString = new Dictionary<int, string>();
//lookupInString.Add(1, "Ammar");
//lookupInString.Add(2, "Mohamed");
//lookupInString.Add(3, "Reem");
//lookupInString.Add(4, "Mariam");

Person[] people =
{
    new()
    {
        Name="Reem"
    },
    new()
    {
        Name="Ammar"
    },
    new()
    {
        Name="Ayman"
    }
};

WriteLine("Initial List of people.");

foreach (Person person in people)
{
    WriteLine(person.Name);
}


WriteLine("Use PersonComparer's IComparer implementation to sort: ");

Array.Sort(people, new PersonComparer());



foreach (Person person in people)
{
    WriteLine(person.Name);
}





