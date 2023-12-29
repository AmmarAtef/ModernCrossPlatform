using static System.Console;
using static System.Console;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
using System.Xml;
using System.IO.Compression;
using System.Text;
using WorkingWithSerialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using NewJson = System.Text.Json.JsonSerializer;


List<Person> people = new List<Person>()
{
    new Person(3000)
    {
        FirstName= "Ammar",
        LastName = "Atef",
        DateOfBirth = new DateTime(1973,3,14)
    },
    new Person(6000)
    {
        FirstName="Mahmoud",
        LastName = "ayman",
        DateOfBirth = new DateTime(1992,12,6),
        Children =  new HashSet<Person>()
        {
            new Person(0)
            {
                FirstName= "ayman",
                LastName = "magdy",
                DateOfBirth = new DateTime(2018,12,6)
            }
        }
    }


};


XmlSerializer xs = new XmlSerializer(people.GetType());

string filePath = Combine(CurrentDirectory, "people.xml");


using (FileStream stream = File.Create(filePath))
{
    xs.Serialize(stream, people);
}

WriteLine($"Written {new FileInfo(filePath).Length} bytes of XML to {filePath}");

WriteLine();
WriteLine(File.ReadAllText(filePath));

using (FileStream xmlLoad = File.Open(filePath, FileMode.Open))
{
    List<Person>? loadedPeople = xs.Deserialize(xmlLoad) as List<Person>;

    if (loadedPeople is not null)
    {
        foreach (Person p in loadedPeople)
        {
            WriteLine($"{p.LastName} has {p.Children?.Count ?? 0}");
        }
    }

}


