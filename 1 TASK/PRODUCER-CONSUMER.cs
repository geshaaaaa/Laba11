using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace produce_consumer
{
    public class PRODUCER_CONSUMER
    {
        Queue<int> que = new Queue<int>();
        object locker = new ();   
        public void Produce()
        {

            for (int i = 1; i < 6; i++)
            {
                int number = new Random().Next(30);
                lock (locker)
                {
                    
                    que.Enqueue(number);
                    Console.WriteLine($"Згенеровано число: {number}");
                }
            }

                Thread.Sleep(1000);
        }
        public void Consume()
        {
            int randnumb;
            for (int i = 1; i < 6; i++)
            {
                lock (locker)
                {
                    if (que.Count > 0)
                    {
                        randnumb = que.Dequeue();
                        Console.WriteLine($"Отримано число: {randnumb}");
                    }
                }
            }

        }


    }
}
