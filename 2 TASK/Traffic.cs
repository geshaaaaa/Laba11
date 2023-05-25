using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lights
{
    public class Traffic
    {
        object locker = new object();
        static Semaphore sem = new Semaphore(3, 3);
        public void Trafficlights()
        {
            for(int i = 1; i < 5 ; i++) 
            {
                Thread myThread = new(Print);
                myThread.Name = $"Світолофор {i}:";
                myThread.Start();

            }
        }
        public void Print()
        {
            while (true)
            {
                Thread.Sleep(1000);

                lock (locker)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} Зелений, Машина їде");
                    Thread.Sleep(1000);

                    sem.WaitOne();
                    Console.WriteLine("Отримати доступ до перехрестя");
                    Console.WriteLine($"{Thread.CurrentThread.Name} Жовтий");
                    Thread.Sleep(1000);
                    sem.WaitOne();
                    Console.WriteLine("Машина чекає");
                    Console.WriteLine($"{Thread.CurrentThread.Name} Червоний");
                    Thread.Sleep(1000);

                    sem.Release();
                }
            }
        }
    }




}

