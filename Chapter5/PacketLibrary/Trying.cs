using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PacketLibrary
{
    public abstract class Trying
    {
        public abstract string getName();
    }

    public class name1 : Trying
    {
        public override string getName()
        {
            return "^";
        }
    }

    public class name2 : Trying
    {
        public override string getName()
        {
            return "*";
        }
    }


    public interface Name12
    {
        string getName();
    }

    public class n : Name12
    {
        private string name;

        public n(string n1)
        {
            this.name = n1;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name, name);
        }

        public override bool Equals(object obj)
        {
            return this.name != (obj as n).name;
        }

        public override string ToString()
        {
            return this.name;
        }

        public string getName()
        {
            throw new NotImplementedException();
        }

        
    }
}
