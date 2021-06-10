using System;
using System.Threading;
/*Задание 3 
Создайте приложение, которое может быть запущено только в одном экземпляре (используя 
именованный Mutex). */
namespace pro_12_3
{
    class Program
    {
        static Mutex mutexObj = new Mutex(false, "myMutex");
        static int x = 0;

        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread myThread = new Thread(Count);
                myThread.Name = $"Поток {i}";
                myThread.Start();
            }

            Console.ReadLine();
        }
        public static void Count()
        {
            mutexObj.WaitOne();
            x = 1;
            for (int i = 1; i < 9; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
                x++;
                Thread.Sleep(100);
            }
            mutexObj.ReleaseMutex();
        }
    }
}
