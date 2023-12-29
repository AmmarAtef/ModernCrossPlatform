using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classlib
{
    public class Animal : IDisposable
    {
        public Animal() //constructor
        {
            // allocate any unmanaged resources
        }

        ~Animal() //finalizer aka destructor
        {
            // deallocate any unmanaged resources
        }

        bool disposed = false; //have resources been released
        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }


        protected virtual void Dispose(bool dsiposing)
        {
            if (disposed) return;
            // deallocate unmanaged resources 
            if (dsiposing)
            {
                // deallocate any other managed resource
            }
            disposed = true;    
        }

        public virtual void Move()
        {

        }

        public void write()
        {
            Console.WriteLine($"New Name: Animal");
        }
    }
}
