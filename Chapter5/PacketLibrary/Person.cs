using PacketLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Packet.Shared
{
    public partial class Person 
    {
        // data field 
        public int AngerLevel;
        public event EventHandler Shout;

        // method

        public void Poke()
        {
            AngerLevel++;
            if (AngerLevel >= 3)
            {
                // if something is listening...
                if (Shout != null)
                {
                    // ...then call the delegate
                    Shout(this, EventArgs.Empty);
                }
            }
        }


        // fields
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public WondersOfTheAncientWorld FavoriteAncientWonder { get; set; }

        public List<Person> Children = new List<Person>();

        public DateTime Instantiated;
        public string Species = "Homo Sapien";

        public readonly string HomePlanet = "Earth";
        public Person()
        {
            Species = "H";
        }

        public Person(string initialName, string homePlanet)
        {
            Name = initialName;
            Instantiated = DateTime.Now;
            HomePlanet = homePlanet;
        }


        public (string Name, int Number) GetFruit()
        {
            return (Name: "Apple", Number: 7);
        }

        public void Deconstruct(out string name, out DateTime dob)
        {
            name = Name;
            dob = Instantiated;
        }


        public void Deconstruct(out string name, out DateTime dob, out string planetName)
        {
            name = Name;
            dob = Instantiated;
            planetName = HomePlanet;
        }


        public string OptionalParameters(string command = "Run!", double number = 0.0, bool active = true)
        {
            return $"command is {command}, number is {number}, active is {active}";
        }

        public void PassingParams(int x, ref int y, out int z)
        {
            z = 99;
            x++; y++; z++;
        }

        //  static method to "multiply"

        public static Person Procreate(Person p1, Person p2)
        {
            Person baby = new Person()
            {
                Name = $"Baby of {p1.Name} and {p2.Name}"
            };

            p1.Children.Add(baby);
            p2.Children.Add(baby);

            return baby;
        }

        // instance method to "multiply"
        public Person ProcreateWith(Person partner)
        {
            return Procreate(this, partner);
        }

        //operator to "multiply"
        public static Person operator *(Person p1, Person p2)
        {
            return Person.Procreate(p1, p2);
        }



        // method with a local function
        public static int Factorial(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException(
                    $"{nameof(number)} cannot be less than zero.");
            }
            return localFactorial(number);

            int localFactorial(int localNumber)
            {
                if (localNumber < 1) return 1;
                return localNumber * localFactorial(localNumber - 1);
            }
        }


        public int MethodIWantToCall(string input)
        {
            return input.Length; // it doesn't matter what the method does
        }

        
    }

    public delegate int DelegateWithMatchingSignature(string s);


}
