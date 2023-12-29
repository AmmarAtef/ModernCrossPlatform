namespace Classlib
{
    public class Person : IGamePlayer, IkeyHolder
    {
        public string? Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public void Lose()
        {

        }

        void IGamePlayer.Lose()
        {

        }

        public virtual void WriteToConsole()
        {
            Console.WriteLine($"person");
        }

        public override string ToString()
        {
            return $"{Name} is a {base.ToString()}";
        }

        public void TimeTravel(DateTime when)
        {
            if (when <= DateOfBirth)
            {
                throw new PersonException($"If you travel back in time to a date earlier than your");
            }
            else
            {
                Console.WriteLine($"welcome to {when:yyyy}");
            }
        }

    }
}