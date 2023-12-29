using Packet.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace PacketLibrary
{
    public class PersonComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if (x is null || y is null)
            {
                return 0;
            }
            // compare name length 
            int result = x.Name.Length.CompareTo(y.Name.Length);

            //  if they are equal 
            if (result == 0)
            {
                // then compare by the name 
                return x.Name.CompareTo(y.Name);
            }
            else
            {
                return result;
            }








        }
    }
}
