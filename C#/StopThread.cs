using System.Linq;
using System.Threading;

namespace LB1
{
    class StopThread
    {
        private StartThread[] threads { get; set; }

        public StopThread(StartThread[] threads, int[] delays)
        {
            this.threads = threads.OrderBy(t => t.Millis).ToArray();
        }

        public void Breaker()
        {
            for (int i = 0; i < threads.Length; i++)
            {
                int sleepTime;

                if (i == 0)
                {
                    sleepTime = threads[i].Millis;
                }
                else
                {
                    sleepTime = threads[i].Millis - threads[i - 1].Millis;
                }

                Thread.Sleep(sleepTime);
                threads[i].Running = false;
            }
        }
    }
}
