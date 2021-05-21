using System;

namespace Lesson8_task3
{
    class Program
    {
        static void Main(string[] args)
        {
            /*            Задание 3
            Имеется N клиентов, которым компания производитель должна доставить товар. Сколько существует
            возможных маршрутов доставки товара, с учетом того, что товар будет доставлять одна машина?
            Используя Visual Studio, создайте проект по шаблону Console Application.
            Напишите программу, которая будет рассчитывать и выводить на экран количество возможных
            вариантов доставки товара.Для решения задачи, используйте факториал N!, рассчитываемый с
            помощью рекурсии. Объясните, почему не рекомендуется использовать рекурсию для расчета
            факториала.Укажите слабые места данного подхода.
            */
            int clients = 5;
            Console.WriteLine("Возможных вариантов маршрутов {0}", Recursion(clients));
            static int Recursion(int counter, int fractal = 1)
            {
                Console.WriteLine(counter);
                if (counter != 0)
                {
                    return counter * Recursion(--counter);
                }
                return 1;
            }

        }
    }
}
