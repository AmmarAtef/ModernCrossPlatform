using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classlib
{
    public class DvdPlayer : IPlayable
    {
        public void Pause()
        {
            Console.WriteLine("DVD player is pausing");
        }

        public void Play()
        {
            Console.WriteLine("DVD player is playing");
        }
    }
}
