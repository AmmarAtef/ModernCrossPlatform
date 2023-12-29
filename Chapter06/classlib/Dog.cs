using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classlib
{
    public class Dog : Animal
    {
        public sealed override void Move()
        {
            base.Move();
        }

        public new void write()
        {
            Console.WriteLine($"New Name: Dog");
        }
    }

    public class Cat : Dog
    {
    }
}
