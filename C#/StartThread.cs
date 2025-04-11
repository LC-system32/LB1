using System;

namespace LB1
{
    class StartThread
    {
        public int Id { get; }
        private int Step { get; }
        public int Millis { get;}

        public volatile bool Running = true;

        public StartThread(int id, int step, int millis)
        {
            Id = id;
            Step = step;
            Millis = millis;
        }

        public void Run()
        {
            int sum = 0;
            int count = 0;

            while (Running)
            {
                sum += Step;
                count++;
            }

            Console.WriteLine($"ID Thread {Id} sum = {sum} count = {count}");
        }
    }
}
