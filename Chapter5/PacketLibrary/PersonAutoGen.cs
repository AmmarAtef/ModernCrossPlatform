using System;
using System.Collections.Generic;
using System.Text;

namespace Packet.Shared
{
    public partial class Person
    {
        // indexers
        public Person this[int index]
        {
            get
            {
                return Children[index];
            }
            set
            {
                Children[index] = value;
            }
        }

        public string Origin
        {
            get
            {
                return $"{Name} was born on {HomePlanet}";
            }
        }

        public string Greetings => $"{Name} Says 'Hello!'";

        public int Age => DateTime.Now.Year - DateOfBirth.Year;

        public string FavoriteIceCream { get; set; }

        private string favoritePrimaryColor;

        public string FavoritePrimaryColor
        {
            get
            {
                return favoritePrimaryColor;
            }

            set
            {
                switch (value.ToLower())
                {
                    case "red":
                    case "green":
                    case "blue":
                        favoritePrimaryColor = value;
                        break;
                    default:
                        throw new ArgumentException($"{value} is not a primary color. choose from: red, green, blue.");

                }
            }
        }



    }
}
