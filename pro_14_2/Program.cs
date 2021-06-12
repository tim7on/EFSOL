using System;
using System.Threading;
using System.Threading.Tasks;
/*Задание 2 
Создайте два метода, которые будут выполняться в рамках параллельных задач. Организуйте 
вызов этих методов при помощи Invoke таким образом, чтобы основной поток программы 
(метод Main) не остановил свое выполнение.*/
namespace pro_14_2
{
    class Program
    {
        static void Task1()
        {
            for (int i = 0; i < 25; i++)
            {
                Thread.Sleep(100);
                Console.Write("1 ");
            }
        }
        static void Task2()
        {
            for (int i = 0; i < 25; i++)
            {
                Thread.Sleep(100);
                Console.Write("2 ");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Task.Factory.StartNew(() => Parallel.Invoke(Task1, Task2));

            for (int i = 0; i < 25; i++)
            {
                Thread.Sleep(100);
                Console.Write("Main ");
            }
        }
    }
}
