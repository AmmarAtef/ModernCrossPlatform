using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace console
{
    public class Person
    {
        // fields
        public string? Name;    // ? allows null 

        public DateTime DateOfBirth;

        public List<Person> Children = new();


        // methods

        public void WriteToConsole()
        {
            WriteLine($"{Name} was born on a {DateOfBirth:dddd}");
        }

    }
}
