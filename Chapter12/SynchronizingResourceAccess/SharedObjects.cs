using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynchronizingResourceAccess
{
    static class SharedObjects
    {
        public static int Counter;
        public static object conch = new object();
        public static Random Random = new Random();
        public static string? Message;
    }
}
