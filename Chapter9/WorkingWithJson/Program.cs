using static System.Console;
using static System.Console;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
using System.Xml;
using System.IO.Compression;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using NewJson = System.Text.Json;
using WorkingWithJson;
;

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




string jsonPath = Combine(CurrentDirectory, "people.json");

using (StreamWriter jsonStream = File.CreateText(jsonPath))
{
    JsonSerializer json = new JsonSerializer();

    // serialize the object graph into a string
    json.Serialize(jsonStream, people);
}

WriteLine();
WriteLine($"Written {new FileInfo(jsonPath).Length} bytes of json to {jsonPath}");
WriteLine(File.ReadAllText(jsonPath));


using (FileStream jsonLoad = File.Open(jsonPath, FileMode.Open))
{
    List<Person> loadedPeople = await NewJson.JsonSerializer.DeserializeAsync(jsonLoad, typeof(List<Person>)) as List<Person>;

    if (loadedPeople is not null)
    {
        foreach (Person p in loadedPeople)
        {
            WriteLine($"{p.LastName} has {p.Children?.Count ?? 0}");
        }
    }
}


Book cSharp = new Book("Modern Cross Platform")
{
    Author = "Ammar Atef",
    PublishDate = new DateTime(1992, 12, 6),
    Created = DateTimeOffset.UtcNow,
    Pages = 823
};

NewJson.JsonSerializerOptions options = new NewJson.JsonSerializerOptions
{
    IncludeFields = true,
    PropertyNameCaseInsensitive = true,
    WriteIndented = true,
    PropertyNamingPolicy = NewJson.JsonNamingPolicy.CamelCase,
};


string filePath = Combine(CurrentDirectory, "book.json");


using (Stream fileStream = File.Create(filePath))
{
    NewJson.JsonSerializer.Serialize<Book>(fileStream, cSharp, options);
}

WriteLine($"Written {new FileInfo(filePath).Length} bytes of json to {filePath}");
WriteLine();

WriteLine(File.ReadAllText(filePath));















