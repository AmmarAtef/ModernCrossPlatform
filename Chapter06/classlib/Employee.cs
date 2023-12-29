using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classlib
{
    public class Employee : Person
    {
        public string? EmployeeCode { get; set; }
        public DateTime HireDate { get; set; }

        public override void WriteToConsole()
        {
            Console.WriteLine($"Employee");
        }
    }
}
