using System;
using System.Threading;
/*Задание 1
Используя Visual Studio, создайте проект по шаблону Console Application. 
Создайте программу, которая будет выводить на экран цепочки падающих символов. Длина каждой 
цепочки задается случайно. Первый символ цепочки – белый, второй символ – светло-зеленый,
остальные символы темно-зеленые. Во время падения цепочки, на каждом шаге, все символы меняют 
свое значение. Дойдя до конца, цепочка исчезает и сверху формируется новая цепочка. Смотрите ниже 
снимок экрана, представленный как образец.*/

namespace Basic_lesson13_1
{
    class Program
    {
        static void line()
        {

        }
        static void Main(string[] args)
        {
            
                Random rand = new Random();
                Console.Write("Press ENTER to start...");
                Console.ReadKey();
                for (int i = 1; i < 30; i++) //120
                {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(rand.Next(2));
                for (int j = 1; j <= 110; j++)
                    {
                    Console.SetCursorPosition(j,i);
                    Console.Write(rand.Next(2));
                    }
                }
                Console.ResetColor();
            for (int i = 2; i < 30; i++)
            {
                if (i > 10)
                {
                    Console.SetCursorPosition(1, i - 10);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(rand.Next(2));
                }
                Console.SetCursorPosition(1, i-1);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(rand.Next(2));
                Console.SetCursorPosition(1,i);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(rand.Next(2));
                Thread.Sleep(100);
                if (i == 29)
                {
                    Console.Clear();
                }

            }
                Console.ReadKey();
            
        }
    }
}
