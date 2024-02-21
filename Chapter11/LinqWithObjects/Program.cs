using static System.Console;

string[] names = new string[]
{
    "Michael",
    "Ammar",
    "John",
    "Reem",
    "Pam",
    "Jam"
};


WriteLine("Deferred execution");

var query1 = names.Where(c => c.EndsWith("m"));

var query2 = from name in names where name.StartsWith("m") select name;

// string[] result1 = query1.ToArray();

// List<string> result2 = query2.ToList();
WriteLine(query1);
foreach (string name1 in query1)
{
    WriteLine(name1);
}


static bool NameLongerThanFour(string name)
{
    return name.Length > 4;
}

// var query = names.Where(new Func<string, bool>(NameLongerThanFour));

// var query = names.Where(NameLongerThanFour);


var query  = names.Where(n=>n.Length> 4);

//foreach(string item in query)
//{
//    WriteLine(item);
//}



//WriteLine("Filter and Sort by length");
//var query3 = names.Where(n => n.Length > 4)
//                    .OrderByDescending(n => n.Length);


//foreach (string item in query3)
//{
//    WriteLine(item);
//}


WriteLine("Filtering by type");


List<Exception> exceptions = new List<Exception>()
{
    new ArgumentException(),
    new SystemException(),
    new IndexOutOfRangeException(),
    new InvalidOperationException(),
    new NullReferenceException(),
    new InvalidCastException(),
    new OverflowException(),
    new DivideByZeroException(),
    new ApplicationException()
};




IEnumerable<ArithmeticException> arithmeticExceptions =
    exceptions.OfType<ArithmeticException>();


foreach (ArithmeticException exception in arithmeticExceptions)
{
    WriteLine(exception);
}


