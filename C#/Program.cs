using System.Threading;

namespace LB1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] millis = { 1000, 5000, 9000, 15000, 20000 };
            StartThread[] startThreads = new StartThread[millis.Length];
            Thread[] threads = new Thread[millis.Length];

            for (int i = 0; i < threads.Length; i++)
            {
                startThreads[i] = new StartThread(i + 1, 2, millis[i]);
                threads[i] = new Thread(startThreads[i].Run);
                threads[i].Start();
            }

            new Thread(() => new StopThread(startThreads, millis).Breaker()).Start();
        }
    }
}
