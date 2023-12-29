using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packet.Shared
{
    public class ImmutablePerson
    {
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
    }

    public record ImmutableVechicle
    {
        public int Wheels { get; set; }
        public string? Color { get; set; }
        public string? Brand { get; set; }
    }




}
