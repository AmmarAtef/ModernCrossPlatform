using System.Collections.Immutable;

WorkingWithQueues();
static void WorkingWithQueues()
{
    Queue<string> coffee = new Queue<string>();
    coffee.Enqueue("Damir");
    coffee.Enqueue("Andrea");
    coffee.Enqueue("Ronald");
    coffee.Enqueue("Amin");
    coffee.Enqueue("Irina");

    Output("Initial queue from front to back", coffee);


    string served = coffee.Dequeue();
    Console.WriteLine("served: " + served);


    string served2 = coffee.Dequeue();
    Console.WriteLine("served: " + served2);

    Output("Current queue from front to back ", coffee);


    PriorityQueue<string, int> vaccine = new PriorityQueue<string, int>();

    vaccine.Enqueue("mariam", 1);
    vaccine.Enqueue("Reem", 4);
    vaccine.Enqueue("Ahmed", 2);
    vaccine.Enqueue("abdo", 3);

    OutputPQ("Current queue for vaccination:", vaccine.UnorderedItems);

    Console.WriteLine($"{vaccine.Dequeue()} has been vaccinated");
    Console.WriteLine($"{vaccine.Dequeue()} has been vaccinated");


    OutputPQ("Current queue for vaccination:", vaccine.UnorderedItems);

    Console.WriteLine($"{vaccine.Dequeue()} has been vaccinated");

    vaccine.Enqueue("Mark",2);

    Console.WriteLine($"{vaccine.Peek()} will be the next to be vacccinated");


    OutputPQ("Current queue for vaccination", vaccine.UnorderedItems);




}

static void Output(string title, IEnumerable<string> collections)
{
    Console.WriteLine(title);

    foreach (string item in collections)
    {
        Console.WriteLine(item);
    }
}



static void OutputPQ<TELement, TPriority>(string title,
    IEnumerable<(TELement Element, TPriority Priority)> collection)
{
    Console.WriteLine(title);


    foreach ((TELement, TPriority) item in collection)
    {
        Console.WriteLine($"{item.Item1}:{item.Item2}");
    }
}



List<string> cities = new List<string>
{
    "Cairo",
    "London"
};

ImmutableList<string> immutableCities = cities.ToImmutableList();
ImmutableList<string> newCities =
immutableCities.Add("GAZA");


Output("Immutable cities: ", immutableCities);
Output("New list of cities: ", newCities);


Index i1 = new Index(3);
Index i2 = 3;

Index i3 = new Index(5, true);
Index i4 = ^5;

////////////
Range r1 = new Range(new Index(3), new Index(6));
Range r2 = new Range(2,7);
Range r3 = 3..7;
Range r4 = Range.StartAt(3);
Range r5 = Range.EndAt(3);
Range r6 = 3..;
Range r7 = ..7;





