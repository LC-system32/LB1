using System;
using System.Threading;

namespace LB1
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculationThread[] calcThreads = new CalculationThread[3];
            Thread[] threads = new Thread[3];

            for (int i = 0; i < threads.Length; i++)
            {
                calcThreads[i] = new CalculationThread(i + 1, 2);
                threads[i] = new Thread(calcThreads[i].Run);
                threads[i].Start();
            }

            int[] delays = new int[] { 100000, 80000, 50000 };

            new Thread(() => StopThread(calcThreads, delays)).Start();
        }

        static void StopThread(CalculationThread[] threads, int[] delays)
        {
            for (int i = 0; i < threads.Length; i++)
            {
                int index = i;
                new Thread(() =>
                {
                    Thread.Sleep(delays[index]);
                    threads[index].Running = false;
                }).Start();
            }
        }
    }

    class CalculationThread
    {
        public int Id { get; }
        private int Step { get; }
        public volatile bool Running = true;

        public CalculationThread(int id, int step)
        {
            Id = id;
            Step = step;
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
